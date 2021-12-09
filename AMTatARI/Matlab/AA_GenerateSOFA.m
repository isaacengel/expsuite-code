function AA_GenerateSOFA(sofaname,workdir,settingsfile,itemlistfile,referencefile,doplots,saveRaw,saveEQ,saveITD,save3DTI,targetFs)

% Process recorded sweeps into SOFA files.
% This replaces all the VisualBasic code from the IRToolbox, and can be run
% from Matlab directly


r = 1.5; % TODO: verify this is the correct distance from speaker driver to arc center
gain = 30; % in dB; TODO: input this as a parameter

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

% irLen = 512; % fixed to 512 samples in this version
% irOffset = [1 0]*fs/1e3; % end offset not used in this version

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
        ibeg=int32(swlen+(ISD(j))+lat(j)-irOffset(1)); % NOTE: harcoded the -1000 for a test
        %iend=int32(swlen+(ISD(j))+lat(j)+irLen+irOffset(2)-1);
        iend = ibeg + irLen - 1;
        for ch=1:2
            h(:,count,ch)=ir(ibeg:iend,ch);
        end
        pos(count,:) = [az,el(j),r];
        count = count+1;
    end
end

if size(h,2) < numAz*numEl
    warning('Some azimuths were skipped because the recordings were not found.')
end

%% Get directions into a nice format
ndirs = size(h,2);
az = pos(:,1);
el = pos(:,2);

%% Window HRIRs
fadelen = 32;
t = linspace(0,pi/2,fadelen).';
fadein = sin(t).^2;
fadeout = cos(t).^2;
win = [fadein; ones(irLen-2*fadelen,1); fadeout];
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

if saveEQ || saveITD || save3DTI
    s = load(referencefile);
    ref_el = s.el;
    ref_eq = s.eq;
    clear s
    
    convlen = irLen+size(ref_eq,1)-1;
    nfft = 2^nextpow2(convlen);

    heq = zeros(irLen,ndirs,2);
    for i=1:numel(ref_el) 
        ind = ref_el(i) == el;
        tmp = iffth( ffth(h(:,ind,:),nfft) .* ffth(ref_eq(:,i,:),nfft) );
        win = [ones(irLen-fadelen,1); fadeout];
        heq(:,ind,:) = win.*tmp(1:irLen,:,:);
    end   
    
end

%% Ensure that all elevations are between -90 and 90
ind = el>90;
az(ind) = mod(az(ind)+180,360);
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
    halign = zeros(size(heq));
    [~,onset_seconds] = itdestimator(permute(heq,[2,3,1]),'fs',fs,'threshlvl',-10);
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
        Obj.Data.IR=shiftdim(h_re,1);
        newobj = AA_SOFAsaveSimpleFreeFieldHRIRImperialCollege(sprintf('%s/%s_Raw_%0.2dkHz.sofa',workdir,sofaname,round(tFs/1000)),Obj,meta,stimPar);
        if doplots
            figure, SOFAplotHRTF(newobj,'MagHorizontal');
            title(sprintf('Magnitude Horizontal plane: %s Raw %0.2dkHz',sofaname,round(tFs/1000)));
            saveas(gcf,sprintf('%s/%s_Raw_%0.2dkHz_MagHorPlane.png',figdir,sofaname,round(tFs/1000)))
        end
    end

    % Equalised
    if saveEQ
        if tFs ~= fs
            heq_re = resample(heq,tFs,fs);
        end
        Obj.Data.IR=shiftdim(heq_re,1);
        newobj = AA_SOFAsaveSimpleFreeFieldHRIRImperialCollege(sprintf('%s/%s_EQ_%0.2dkHz.sofa',workdir,sofaname,round(tFs/1000)),Obj,meta,stimPar);
        if doplots
            figure, SOFAplotHRTF(newobj,'MagHorizontal');
            title(sprintf('Magnitude Horizontal plane: %s EQ %0.2dkHz',sofaname,round(tFs/1000)));
            saveas(gcf,sprintf('%s/%s_EQ_%0.2dkHz_MagHorPlane.png',figdir,sofaname,round(tFs/1000)))
        end
    end

    % Aligned
    if saveITD || save3DTI
        if tFs ~= fs
            halign_re = resample(halign,tFs,fs);
        end
        Obj.Data.IR=shiftdim(halign_re,1);
        newobj = AA_SOFAsaveSimpleFreeFieldHRIRImperialCollege(sprintf('%s/%s_Aligned_%0.2dkHz.sofa',workdir,sofaname,round(tFs/1000)),Obj,meta,stimPar);
        if doplots
            figure, SOFAplotHRTF(newobj,'MagHorizontal');
            title(sprintf('Magnitude Horizontal plane: %s Aligned %0.2dkHz',sofaname,round(tFs/1000)));
            saveas(gcf,sprintf('%s/%s_Aligned_%0.2dkHz_MagHorPlane.png',figdir,sofaname,round(tFs/1000)))
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
if doplots
    AA_QuickPlotIR(sofaname,workdir,settingsfile,itemlistfile)
end

end