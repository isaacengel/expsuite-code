function AA_GenerateSOFA(sofaname,workdir,settingsfile,itemlistfile,referencefile,doplots,saveRaw,saveEQ,saveEQmp,saveITD,save3DTI,targetFs)

% Process recorded sweeps into SOFA files.
% This replaces all the VisualBasic code from the IRToolbox, and can be run
% from Matlab directly

r = 1.5; % TODO: verify this is the correct distance from speaker driver to arc center
gain = 0; % in dB; TODO: input this as a parameter

% To save figures
figdir = [workdir,'/plots'];
if ~isfolder(figdir)
    mkdir(figdir)
end

%% Load settings

settings = AA_ReadSettingsFile(settingsfile);
fs = settings.fs;
isdList = settings.isdList;
srcList = settings.srcList;
irLen = round(settings.irLen*fs/1e3); % in samples
irOffset = round(settings.irOffset*fs/1e3); % in samples
clear settings

%% Window settings
fadelenin = 16;
fadelenout = 128;
tin = linspace(0,pi/2,fadelenin).';
tout = linspace(0,pi/2,fadelenout).';
fadein = sin(tin).^2;
fadeout = cos(tout).^2;
win = [fadein; ones(irLen-fadelenin-fadelenout,1); fadeout];

%% Load sweep files
sweepfile = [workdir,'/expsweep.wav'];
[sweep,fs_] = audioread(sweepfile);
assert(fs==fs_,'Sampling frequency mismatch!')
invsweepfile = [workdir,'/invexpsweep.wav'];
[invsweep,fs_] = audioread(invsweepfile);
assert(fs==fs_,'Sampling frequency mismatch!')

%% Normalise inverse sweep so that the deconvolution has 0dB magnitude
swlen = size(invsweep,1);
nfft = 2^nextpow2(swlen);
tmp = fft(sweep,nfft).*fft(invsweep,nfft);
amp = abs(tmp(round(nfft*1000/fs))); % normalize at 1khz
invsweep = invsweep./amp;
clear tmp amp

%% Prepare inter-sweep delay list
ISD = zeros(size(isdList));
for i=1:numel(isdList)
    ISD(i) = sum(isdList(1:i))*fs/1000; % in samples
end

%% Calculate HRIRs
itemlist = readtable(itemlistfile,'Delimiter',',');
indAz = find(~isnan(itemlist.Azimuth)); % ignore rows without defined azimuth
numAz = numel(indAz);
count = 1;
pos = [];
h = [];
for i=1:numAz
    row = indAz(i);
    az = mod(360-itemlist.Azimuth(row),360); % source az = - turntable az
    id = itemlist.Index(row);
    el = str2num(itemlist.Elevation{row});
    numEl = numel(el);
    % Deconvolve
    ir = [];
    for ch=1:2
        file = sprintf('%s/AMTatARI_%0.4d_adc%d.wav',workdir,id,ch-1);
        if ~isfile(file)
            continue
        end
        [x,fs_] = audioread(file); % read recording
        if max(abs(x(:))) >= 1
            warning('The microphone clipped for Az=%d! Consider reducing the microphone gain and repeating the measurement.',itemlist.Azimuth(row))
        end
        assert(fs==fs_,'Sampling frequency mismatch!')
        convlen = size(x,1) + swlen - 1;
        nfft = 2^nextpow2(convlen);
        irtemp = ifft( fft(x,nfft) .* fft(invsweep,nfft) );
        ir(:,ch) = irtemp(1:convlen);
    end
    % If files were not found, skip this azimuth
    if size(ir,2) < 2
        continue
    end
    
    % Separate HRIRs
    for j=1:numEl
        ind = srcList(:,2)==el(j);
        lat(j) = srcList(ind,3)*fs/1e6; % in samples
        % NOTE: in this version, the initial offset is counted as part of
        % the IR length. The end offset is not used.
        ibeg=int32(swlen+(ISD(j))+lat(j)-irOffset(1));
        %iend=int32(swlen+(ISD(j))+lat(j)+irLen+irOffset(2)-1);
        iend = ibeg + irLen - 1;
        for ch=1:2
            h(:,count,ch)=ir(ibeg:iend,ch);
        end
        pos(count,:) = [az,el(j),r];
        count = count+1;
    end
end

if size(h,2) == 0
    warning('No HRTF recordings were found.')
    return
elseif size(h,2) < numAz*numEl
    warning('Some azimuths were skipped because the corresponding HRTF recordings were not found.')
end

%% Remove redundant directions
az = pos(:,1);
el = pos(:,2);
[lat,pol] = sph2hor(az,el);
[~,ind] = unique([lat,pol],'rows');
ind = sort(ind);
h = h(:,ind,:);
az = az(ind);
el = el(ind);
ndirs = size(h,2);

%% Window HRIRs

hwin = win.*h(1:irLen,:,:);

% Check energy loss
nrg = sum(abs(h(:)).^2);
nrgwin = sum(abs(hwin(:)).^2);
nrgloss = 1-nrgwin/nrg;
if nrgloss>0.01
    warning('%0.2f%% of the IR energy was lost after windowing. Maybe something went wrong. Please check plots.',nrgloss*100)
end

% Apply gain
h = hwin.*db2mag(gain);
clear hwin

%% Equalise by reference measurement

if saveEQ 
    s = load(referencefile);
    ref_el = s.el;
    ref_eq = s.eq;
    ref_delay = s.delay;
    clear s
    
    convlen = irLen+size(ref_eq,1)-1;
    nfft = 2^nextpow2(convlen);
    safety = 64; % 64 samples at 96kHz is around 0.67 ms which is enough to cover the head diameter and some more

    heq = zeros(irLen,ndirs,2);
    count = 0;
    show_warning = 0;
    for i=1:numel(ref_el) 
        ind = ref_el(i) == el;
        count = count + sum(ind);
        tmp = iffth( ffth(h(:,ind,:),nfft) .* ffth(ref_eq(:,i,:),nfft) );
        tmp = circshift(tmp,-ref_delay+safety);
        heq(:,ind,:) = win.*tmp(1:irLen,:,:);

        % Check energy loss
        nrg = sum(abs(tmp).^2,'all');
        nrgwin = sum(abs(heq(:,ind,:)).^2,'all');
        nrgloss = 1-nrgwin/nrg;
        if nrgloss>0.02
            show_warning = 1;
%             warning('%0.2f%% of the IR energy was lost after windowing. Maybe something went wrong. Please check plots.',nrgloss*100)
%             figure
%             subplot(2,2,1), AKp(tmp(:,:,1),'et2d','fs',fs), title('Before window L')
%             subplot(2,2,2), AKp(tmp(:,:,2),'et2d','fs',fs), title('Before window R')
%             subplot(2,2,3), AKp(heq(:,ind,1),'et2d','fs',fs), title('After window L')
%             subplot(2,2,4), AKp(heq(:,ind,2),'et2d','fs',fs), title('After window R')
%             sgtitle(sprintf('el=%d',ref_el(i)))
        end
    end
    if show_warning == 1
        warning('More than 2%% of the HRTF energy was lost when windowing after equalisation. Maybe something went wrong.')
    end

end

%% Equalise by reference measurement (minimum phase version)

if saveEQmp || saveITD || save3DTI
    
    s = load(referencefile);
    ref_el = s.el;
    ref_eq = s.eq;
    clear s
    
    winhann = hann(size(ref_eq,1));
    padlen = 2^16;
    ref_eq_pad = [zeros((padlen-size(ref_eq,1))/2,size(ref_eq,2),size(ref_eq,3));winhann.*ref_eq;zeros((padlen-size(ref_eq,1))/2,size(ref_eq,2),size(ref_eq,3))];
    ref_EQ = ffth(ref_eq_pad);
    ref_EQmp = makeMinPhase(abs(ref_EQ));
    ref_eqmp = iffth(ref_EQmp);
    
    convlen = irLen+size(ref_eqmp,1)-1;
    nfft = 2^nextpow2(convlen);

    heqmp = zeros(irLen,ndirs,2);
    count = 0;
    show_warning = 0;
    for i=1:numel(ref_el) 
        ind = ref_el(i) == el;
        count = count + sum(ind);
        tmp = iffth( ffth(h(:,ind,:),nfft) .* ffth(ref_eqmp(:,i,:),nfft) );
        heqmp(:,ind,:) = win.*tmp(1:irLen,:,:);

        % Check energy loss
        nrg = sum(abs(tmp).^2,'all');
        nrgwin = sum(abs(heq(:,ind,:)).^2,'all');
        nrgloss = 1-nrgwin/nrg;
        if nrgloss>0.02
            show_warning = 1;
%             warning('%0.2f%% of the IR energy was lost after windowing. Maybe something went wrong. Please check plots.',nrgloss*100)
%             figure
%             subplot(2,2,1), AKp(tmp(:,:,1),'et2d','fs',fs), title('Before window L')
%             subplot(2,2,2), AKp(tmp(:,:,2),'et2d','fs',fs), title('Before window R')
%             subplot(2,2,3), AKp(heq(:,ind,1),'et2d','fs',fs), title('After window L')
%             subplot(2,2,4), AKp(heq(:,ind,2),'et2d','fs',fs), title('After window R')
%             sgtitle(sprintf('el=%d',ref_el(i)))
        end
    end  
    
    if show_warning == 1
        warning('More than 2%% of the HRTF energy was lost when windowing after min-phase equalisation. Maybe something went wrong.')
    end
    
end


%% Ensure that all elevations are between -90 and 90
ind = el>90;
az(ind) = mod(az(ind)+180,360); % azimuth is inverted (turntable =/= speakers)
el(ind) = 180-el(ind);
pos(:,1) = az;
pos(:,2) = el;

%% Perform ALFE

% NOTE: not using it for now since it has a very small effect

%In this section the lower frequency components below a certain frequency
%xover are replaced by a frequecy-shaped dirac. The ALFE algorithm is done
%on the equalized dataset in order to benefit from the constant frequency
%response towards low frequencies. 

% xover = [200 300];
% nfreqs = size(Heq,1);
% n_link = round(xover / (fs/nfreqs)) + 1;
% ALFE_abs = db(mean(abs(Heq(n_link(1):n_link(2),:,:)),'all'));
% halfe(:,:,1) = ALFE_fd(heq(:,:,1),'f_link', xover,'fs',fs,'L_target',ALFE_abs);
% halfe(:,:,2) = ALFE_fd(heq(:,:,2),'f_link', xover,'fs',fs,'L_target',ALFE_abs);
% 
% if doplots
%     Halfe = ffth(halfe);
%     quickplotHRTF(Halfe,fs)
%     sgtitle('HRTF after EQ+ALFE')
%     quickplotHRIR(halfe,fs)
%     sgtitle('HRIRs after EQ+ALFE')
% end

%% Remove ITDs

if saveITD || save3DTI

    pad = round(0.0006*fs); % 0.6ms padding (empirically set)
    halign = zeros(size(heqmp));
    [~,onset_seconds] = itdestimator(permute(heqmp,[2,3,1]),'fs',fs,'threshlvl',-10);
    onset_samples = round(onset_seconds*fs);
    for i=1:ndirs
        for ch=1:2
            halign(:,i,ch) = circshift(heq(:,i,ch),pad-onset_samples(i,ch),1);
        end
    end

end
    
%% Save SOFA files

meta.pos = pos;
stimPar.Version = '3.0.1'; % copied from AA_hM

for i=1:numel(targetFs)

    tFs = targetFs(i);
    stimPar.SamplingRate = tFs;
    
    % Raw HRIRs
    if saveRaw
        if tFs ~= fs
            h_re = resample(h,tFs,fs);
        else
            h_re = h;
        end
        % Zero-pad to next multiple of two
        hlen = 2^nextpow2(size(h_re,1));
        h_re = [h_re;zeros(hlen-size(h_re,1),size(h_re,2),size(h_re,3))];
        % Save SOFA
        Obj.Data.IR=shiftdim(h_re,1);
        newobj = AA_SOFAsaveSimpleFreeFieldHRIRImperialCollege(sprintf('%s/%s_Raw_%0.2dkHz.sofa',workdir,sofaname,round(tFs/1000)),Obj,meta,stimPar);
        if doplots
            figure('pos',[10.6000 63.4000 695.2000 284.8000])
            subplot(1,2,1), SOFAplotHRTF(newobj,'MagHorizontal', 1); xlim([0 20000]), ylim([-180 180]), title('Left')
            subplot(1,2,2), SOFAplotHRTF(newobj,'MagHorizontal', 2); xlim([0 20000]), ylim([-180 180]), title('Right')
            sgtitle(sprintf('Magnitude Horizontal plane: %s Raw %0.2dkHz',sofaname,round(tFs/1000)));
            saveas(gcf,sprintf('%s/%s_Raw_%0.2dkHz_MagHorPlane.png',figdir,sofaname,round(tFs/1000)))
            quickplotHRTF(h_re,tFs)
            sgtitle(sprintf('%s_Raw_%0.2dkHz, all %d HRIRs',sofaname,round(tFs/1000),size(h_re,2)),'interpreter','none')
            saveas(gcf,sprintf('%s/%s_Raw_%0.2dkHz_AllHRIRs.png',figdir,sofaname,round(tFs/1000)))
            quickplotITD(h_re,pos,tFs)
            title(sprintf('%s_Raw_%0.2dkHz, ITDs',sofaname,round(tFs/1000)),'interpreter','none')
            saveas(gcf,sprintf('%s/%s_Raw_%0.2dkHz_ITDs.png',figdir,sofaname,round(tFs/1000)))
        end
    end

    % Equalised
    if saveEQ
        if tFs ~= fs
            heq_re = resample(heq,tFs,fs);
        else
            heq_re = heq;
        end
        % Zero-pad to next multiple of two
        hlen = 2^nextpow2(size(heq_re,1));
        heq_re = [heq_re;zeros(hlen-size(heq_re,1),size(heq_re,2),size(heq_re,3))];
        % Save SOFA
        Obj.Data.IR=shiftdim(heq_re,1);
        newobj = AA_SOFAsaveSimpleFreeFieldHRIRImperialCollege(sprintf('%s/%s_EQ_%0.2dkHz.sofa',workdir,sofaname,round(tFs/1000)),Obj,meta,stimPar);
        if doplots
            figure('pos',[10.6000 63.4000 695.2000 284.8000])
            subplot(1,2,1), SOFAplotHRTF(newobj,'MagHorizontal', 1); xlim([0 20000]), ylim([-180 180]), title('Left')
            subplot(1,2,2), SOFAplotHRTF(newobj,'MagHorizontal', 2); xlim([0 20000]), ylim([-180 180]), title('Right')
            sgtitle(sprintf('Magnitude Horizontal plane: %s EQ %0.2dkHz',sofaname,round(tFs/1000)));
            saveas(gcf,sprintf('%s/%s_EQ_%0.2dkHz_MagHorPlane.png',figdir,sofaname,round(tFs/1000)))
            quickplotHRTF(heq_re,tFs)
            sgtitle(sprintf('%s_EQ_%0.2dkHz, all %d HRIRs',sofaname,round(tFs/1000),size(heq_re,2)),'interpreter','none')
            saveas(gcf,sprintf('%s/%s_EQ_%0.2dkHz_AllHRIRs.png',figdir,sofaname,round(tFs/1000)))
            quickplotITD(heq_re,pos,tFs)
            title(sprintf('%s_EQ_%0.2dkHz, ITDs',sofaname,round(tFs/1000)),'interpreter','none')
            saveas(gcf,sprintf('%s/%s_EQ_%0.2dkHz_ITDs.png',figdir,sofaname,round(tFs/1000)))
        end
    end
    
    % Equalised minimum phase
    if saveEQmp
        if tFs ~= fs
            heqmp_re = resample(heqmp,tFs,fs);
        else
            heqmp_re = heqmp;
        end
        % Zero-pad to next multiple of two
        hlen = 2^nextpow2(size(heqmp_re,1));
        heqmp_re = [heqmp_re;zeros(hlen-size(heqmp_re,1),size(heqmp_re,2),size(heqmp_re,3))];
        % Save SOFA
        Obj.Data.IR=shiftdim(heqmp_re,1);
        newobj = AA_SOFAsaveSimpleFreeFieldHRIRImperialCollege(sprintf('%s/%s_EQmp_%0.2dkHz.sofa',workdir,sofaname,round(tFs/1000)),Obj,meta,stimPar);
        if doplots
            figure('pos',[10.6000 63.4000 695.2000 284.8000])
            subplot(1,2,1), SOFAplotHRTF(newobj,'MagHorizontal', 1); xlim([0 20000]), ylim([-180 180]), title('Left')
            subplot(1,2,2), SOFAplotHRTF(newobj,'MagHorizontal', 2); xlim([0 20000]), ylim([-180 180]), title('Right')
            sgitle(sprintf('Magnitude Horizontal plane: %s EQmp %0.2dkHz',sofaname,round(tFs/1000)));
            saveas(gcf,sprintf('%s/%s_EQmp_%0.2dkHz_MagHorPlane.png',figdir,sofaname,round(tFs/1000)))
            quickplotHRTF(heqmp_re,tFs)
            sgtitle(sprintf('%s_EQmp_%0.2dkHz, all %d HRIRs',sofaname,round(tFs/1000),size(heqmp_re,2)),'interpreter','none')
            saveas(gcf,sprintf('%s/%s_EQmp_%0.2dkHz_AllHRIRs.png',figdir,sofaname,round(tFs/1000)))
            quickplotITD(heqmp_re,pos,tFs)
            title(sprintf('%s_EQmp_%0.2dkHz, ITDs',sofaname,round(tFs/1000)),'interpreter','none')
            saveas(gcf,sprintf('%s/%s_EQmp_%0.2dkHz_ITDs.png',figdir,sofaname,round(tFs/1000)))
        end
    end

    % Aligned
    if saveITD || save3DTI
        if tFs ~= fs
            halign_re = resample(halign,tFs,fs);
        else
            halign_re = halign;
        end
        % Zero-pad to next multiple of two
        hlen = 2^nextpow2(size(halign_re,1));
        halign_re = [halign_re;zeros(hlen-size(halign_re,1),size(halign_re,2),size(halign_re,3))];
        % Save SOFA
        Obj.Data.IR=shiftdim(halign_re,1);
        newobj = AA_SOFAsaveSimpleFreeFieldHRIRImperialCollege(sprintf('%s/%s_Aligned_%0.2dkHz.sofa',workdir,sofaname,round(tFs/1000)),Obj,meta,stimPar);
        if doplots
            figure('pos',[10.6000 63.4000 695.2000 284.8000])
            subplot(1,2,1), SOFAplotHRTF(newobj,'MagHorizontal', 1); xlim([0 20000]), ylim([-180 180]), title('Left')
            subplot(1,2,2), SOFAplotHRTF(newobj,'MagHorizontal', 2); xlim([0 20000]), ylim([-180 180]), title('Right')
            sgtitle(sprintf('Magnitude Horizontal plane: %s Aligned %0.2dkHz',sofaname,round(tFs/1000)));
            saveas(gcf,sprintf('%s/%s_Aligned_%0.2dkHz_MagHorPlane.png',figdir,sofaname,round(tFs/1000)))
            quickplotHRTF(halign_re,tFs)
            sgtitle(sprintf('%s_Aligned_%0.2dkHz, all %d HRIRs',sofaname,round(tFs/1000),size(halign_re,2)),'interpreter','none')
            saveas(gcf,sprintf('%s/%s_Aligned_%0.2dkHz_AllHRIRs.png',figdir,sofaname,round(tFs/1000)))
            quickplotITD(halign_re,pos,tFs)
            title(sprintf('%s_Aligned_%0.2dkHz, ITDs',sofaname,round(tFs/1000)),'interpreter','none')
            saveas(gcf,sprintf('%s/%s_Aligned_%0.2dkHz_ITDs.png',figdir,sofaname,round(tFs/1000)))
        end
    end

    % Save as .3dti
    if save3DTI
        scriptPath = which('AA_GenerateSOFA');
        exePath = ['"',scriptPath(1:end-17),'HRTF_SOFATo3DTI.exe"'];
        system( sprintf('%s -i %s_Aligned_%0.2dkHz.sofa -o %s_Aligned_%0.2dkHz.3dti-hrtf',exePath,sofaname,round(tFs/1000),sofaname,round(tFs/1000)) );
        if ~saveITD
            system( sprintf('rm %s_Aligned_%0.2dkHz.sofa',sofaname,round(tFs/1000)) )
        end
    end
    
end

%% Plots
% NOTE: in the current version it takes too long (3 plots per azimuth)
%if doplots
    %AA_QuickPlotIR(sofaname,workdir,settingsfile,itemlistfile)
%end

end

%% Aux functions

function quickplotHRTF(h,fs)
    H = ffth(h);
    nfreqs = size(H,1);
    irLen = size(h,1);
    f = linspace(0,fs/2,nfreqs).';
    t = 1000*(0:(irLen-1))/fs; % in ms
    havg = mean(abs(h),2);
    Hmag_avg = mean(abs(H),2); % avg across directions
    figure('pos',[7.4000 48.2000 808.8000 606.4000])
    subplot(2,2,1), plot([nan nan],[nan nan],'k','LineWidth',2), hold on
    plot(t,db(abs(h(:,:,1))),'Color',[0.4 0.4 0.4],'LineWidth',0.5), title('Left HRIRs (time)')
    plot(t,db(havg(:,:,1)),'k','LineWidth',2)
    legend('Mean')
    grid on, xlim([0 irLen/fs*1000]), ylim([-70, -10])
    xlabel('Time (ms)'), ylabel('Amplitude (dB)')
    subplot(2,2,2), plot(t,db(abs(h(:,:,2))),'Color',[0.4 0.4 0.4],'LineWidth',0.5), hold on
    plot(t,db(havg(:,:,2)),'k','LineWidth',2), title('Right HRIRs (time)')
    grid on, xlim([0 irLen/fs*1000]), ylim([-70, -10])
    xlabel('Time (ms)'), ylabel('Amplitude (dB)')
    subplot(2,2,3), semilogx(f,db(abs(H(:,:,1))),'Color',[0.4 0.4 0.4],'LineWidth',0.5), hold on
    semilogx(f,db(Hmag_avg(:,:,1)),'k','LineWidth',2), title('Left HRIRs (mag. spectra)')
    grid on, xlim([f(2) fs/2]), ylim([-45, 15])
    xlabel('Frequency (Hz)'), ylabel('Amplitude (dB)')
    subplot(2,2,4), semilogx(f,db(abs(H(:,:,2))),'Color',[0.4 0.4 0.4],'LineWidth',0.5), hold on
    semilogx(f,db(Hmag_avg(:,:,2)),'k','LineWidth',2),title('Right HRIRs (mag. spectra)')
    grid on, xlim([f(2) fs/2]), ylim([-45, 15])
    xlabel('Frequency (Hz)'), ylabel('Amplitude (dB)')
end

function quickplotITD(h,pos,fs)
    itd = itdestimator(permute(h,[2,3,1]),'fs',fs,'threshlvl',-10);
    az = pos(:,1);
    el = pos(:,2);
    unique_el = sort(unique(el));
    leg = {};
    colors = parula(numel(unique_el)+1);
    figure('pos',[42 79 560 420])
    for i=1:numel(unique_el)
        curr_el = unique_el(i);
        ind = find(abs(el-curr_el)<0.1);
        [~,order] = sort(az(ind));
        ind = ind(order);
        curr_az = az(ind);
        curr_itd = itd(ind);
        plot(curr_az,curr_itd,'color',colors(i,:)), hold on
        leg{i} = strcat('El=',num2str(curr_el),'°');
    end
    grid on, ylim([-8e-4 8e-4])
    legend(leg,'fontsize',6,'location','se')
    title('ITD')
    xlabel('Azimuth (°)'), ylabel('t (s)')
end