function AA_SanityCheck(workdir,settingsfile,itemlistfile)

% Check any HP and/or HRTF measurement done until this point and raises
% errors if any problem is found

% If any parameter is missing, default to the typical value
if ~exist('workdir','var')
    workdir = '.';
end
if ~exist('settingsfile','var')
    settingsfile = 'settings.AMTatARI';
end
if ~exist('itemlistfile','var')
    itemlistfile = 'itemlist.itl.csv';
end

%% Load settings
gain = 20; % for HRTF plots
hpIrLen = 2048;
settings = AA_ReadSettingsFile(settingsfile);
fs = settings.fs;
isdList = settings.isdList;
srcList = settings.srcList;
irLen = round(settings.irLen*fs/1e3); % in samples
irOffset = round(settings.irOffset*fs/1e3); % in samples
clear settings

%% Window settings
rawlen = 0.05 * fs; % for the raw HRIRs we keep 50 ms
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

%% First, check headphone measurements, if any


%% Calculate HRIRs
itemlist = readtable(itemlistfile,'Delimiter',',');
indAz_HP = find(isnan(itemlist.Azimuth)); % ignore rows with defined azimuth
indAz_HRTF = find(~isnan(itemlist.Azimuth)); % ignore rows wihout azimuth
numAz_HP = numel(indAz_HP);
numAz_HRTF = numel(indAz_HRTF);
countHP = 0;
countHRTF = 0;
warningCount = 0;

%% First, calculate all headphone IRs
h = [];
cliplist = [];
invertlist = [];
lrlist = [];
snrlist = [];
for i=1:numAz_HP
    row = indAz_HP(i);
    id = itemlist.Index(row);
    % Deconvolve
    ir = [];
    for ch=1:2
        file = sprintf('%s/AMTatARI_%0.4d_adc%d.wav',workdir,id,ch-1);
        if ~isfile(file)
            continue
        end
        [x,fs_] = audioread(file); % read recording
        if max(abs(x(:))) >= 0.99
            cliplist = [cliplist,id];
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
    ons = zeros(2,1);
    for ch=1:2
        [~,ons(ch)] = max(abs(ir(:,ch)));
        ibeg=int32(ons(ch)-irOffset(1));
        iend = ibeg + hpIrLen - 1;
        h(:,id,ch)=ir(ibeg:iend,ch);
    end
    
    % Check left/right order
    if ons(1) > ons(2)
        invertlist = [invertlist,id];
    end
    
    % Compare left/right energy
    nrgL = sum(h(:,id,1).^2,1);
    nrgR = sum(h(:,id,2).^2,1);
    dBdif = abs(10*log10(nrgL./nrgR));
    dBdif = mean(dBdif);
    dBdifThreshold = 2; % TODO: pass as a parameter
    if dBdif > dBdifThreshold
        lrlist = [lrlist,id];
    end

    % Check SNR
    SNRthresh = 60; % TODO; pass as parameter
    pad = round(0.0005 * fs); % look for the floor at 0.5ms before onset (empirically set)
    [peakL(id),onsL(id)] = max(db(abs(h(:,id,1))),[],1);
    [peakR(id),onsR(id)] = max(db(abs(h(:,id,2))),[],1);
    floorL(id) = mean(db(abs(h(1:onsL-pad,id,1))),1);
    floorR(id) = mean(db(abs(h(1:onsR-pad,id,2))),1);
    if (peakL(id)-floorL(id)) < SNRthresh || (peakR(id)-floorR(id)) < SNRthresh
        snrlist = [snrlist,id];
    end
    
    countHP = countHP + 1;

end

% Show dialog for clipping
if ~isempty(cliplist)
    dlg = errordlg(['CRITICAL: The microphone clipped for headphone measurements',sprintf(' #%d',cliplist),'. Please reduce the microphone gain and repeat all measurements.'],'Microphone clipped!');
    uiwait(dlg)
    return
end

% Show dialog for left/right order
if ~isempty(invertlist)
    dlg = errordlg(['CRITICAL: Left/right channels seem to be inverted for headphone measurements',sprintf(' #%d',cliplist),'. Please check microphones and headphones and repeat the measurements.'],'Left/right channels inverted!');
    uiwait(dlg)
    return
end

% Show dialog for left/right mismatch
if ~isempty(lrlist)
    warningCount = warningCount + 1;
    dlg = warndlg([sprintf('WARNING: left and right channels show a difference in energy greater than %0.2f dB for headphone measurements',dBdifThreshold),sprintf(' #%d',lrlist),' (see figure). Please consider checking the microphones. Click OK to close the plots and continue.'],'Left/right mismatch');
    figure('pos',[12 91 1065 420])
    subplot(1,2,1),AKp(h(:,lrlist,1),'et2d','fs',fs), title('Left'), legend(repmat("Measurement #",numel(lrlist),1)+string(lrlist).','fontsize',7)
    subplot(1,2,2),AKp(h(:,lrlist,2),'et2d','fs',fs), title('Right'), legend(repmat("Measurement #",numel(lrlist),1)+string(lrlist).','fontsize',7)
    sgtitle('Warning: left/right mismatch in headphone IRs')
    uiwait(dlg);
    close(gcf)
end

% Show dialog for SNR warning
if ~isempty(snrlist)
    warningCount = warningCount + 1;
    dlg = warndlg([sprintf('WARNING: the SNR between the IR peak and the onset noise floor is smaller than %0.2f dB for headphone measurements',SNRthresh),sprintf(' #%d',snrlist),' (see figure). Please consider checking the microphones. Click OK to close the plots and continue.'],'Low SNR');
    figure('pos',[12 91 1065 420])
    subplot(1,2,1)
    AKp(h(1:round(0.003*fs),snrlist,1),'et2d','fs',fs), hold on
    plot([0,3],[mean(peakL(snrlist)-SNRthresh),mean(peakL(snrlist)-SNRthresh)],'k--','LineWidth',2)
    title('Left'), legend([(repmat("Measurement #",numel(snrlist),1)+string(snrlist).');"Noise floor should be below this"],'location','se','fontsize',7)
    subplot(1,2,2)
    AKp(h(1:round(0.003*fs),snrlist,2),'et2d','fs',fs), hold on
    plot([0,3],[mean(peakR(snrlist)-SNRthresh),mean(peakR(snrlist)-SNRthresh)],'k--','LineWidth',2)
    title('Right'), legend([(repmat("Measurement #",numel(snrlist),1)+string(snrlist).');"Noise floor should be below this"],'location','se','fontsize',7)
    sgtitle('Warning: low onset SNR in headphone IRs')
    uiwait(dlg);
    close(gcf)
end

%% Then check the HRTFs

h = [];
cliplist = [];
snrlist = [];
nrglist = [];
pos = [];

for i=1:numAz_HRTF
    
    row = indAz_HRTF(i);
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
        if max(abs(x(:))) >= 0.99
            cliplist = [cliplist,id];
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
        iend = ibeg + rawlen - 1;
        
        countHRTF = countHRTF+1;
        for ch=1:2
            h(:,countHRTF,ch) = ir(ibeg:iend,ch).*db2mag(gain); % apply gain
            extralength_plot = [250 250]; % TODO: parameter
            hext(:,countHRTF,ch) = ir(ibeg-extralength_plot(1):ibeg+irLen+extralength_plot(2),ch).*db2mag(gain);
        end
               
        % Check SNR
        SNRthresh = 60; % TODO; pass as parameter
        pad = round(0.0005 * fs); % look for the floor at 0.5ms before onset (empirically set)
        [peakL(countHRTF),onsL(countHRTF)] = max(db(abs(h(:,countHRTF,1))),[],1);
        [peakR(countHRTF),onsR(countHRTF)] = max(db(abs(h(:,countHRTF,2))),[],1);
        floorL(countHRTF) = mean(db(abs(h(1:onsL-pad,countHRTF,1))),1);
        floorR(countHRTF) = mean(db(abs(h(1:onsR-pad,countHRTF,2))),1);
        if (peakL(countHRTF)-floorL(countHRTF)) < SNRthresh || (peakR(countHRTF)-floorR(countHRTF)) < SNRthresh
            snrlist = [snrlist,countHRTF];
        end
            
        % Window HRIR and check energy loss
        hwin(:,countHRTF,:) = win.*h(1:irLen,countHRTF,:);
        % Check energy loss
        nrg = sum(abs(h(:,countHRTF,:)).^2,'all');
        nrgwin = sum(abs(hwin(:,countHRTF,:)).^2,'all');
        nrgloss = 1-nrgwin/nrg;
        nrgThresh = 0.1; % TODO: pass as parameter
        if nrgloss>nrgThresh
            nrglist = [nrglist,countHRTF];
        end
            
        pos(countHRTF,:) = [az,el(j)];
    end  
     
end

% Show dialog for clipping
if ~isempty(cliplist)
    dlg = errordlg(['CRITICAL: The microphone clipped for HRTF measurements',sprintf(' #%d',cliplist),'. Please reduce the microphone gain and repeat all measurements.'],'Microphone clipped!');
    uiwait(dlg)
    return
end

% Show dialog for SNR warning
if ~isempty(snrlist)
    warningCount = warningCount + 1;
    azlist = pos(snrlist,1);
    ellist = pos(snrlist,2);
    len = numel(snrlist);
    strlist = repmat("[az=",len,1) + string(azlist(:)) + repmat(",el=",len,1) + string(ellist(:)) + repmat("]",len,1);
    dlg = warndlg([sprintf('WARNING: the SNR between the IR peak and the onset noise floor is smaller than %0.2f dB for %d HRTF measurements',SNRthresh,len),' (see figure). Please consider checking microphones and measurement conditions. Click OK to close the plots and continue.'],'Low SNR');
    figure('pos',[12 91 1357 785])
    subplot(2,1,1)
    AKp(h(1:round(0.003*fs),snrlist,1),'et2d','fs',fs), hold on
    plot([0,3],[mean(peakL(snrlist)-SNRthresh),mean(peakL(snrlist)-SNRthresh)],'k--','LineWidth',2)
    title('Left'), legend([strlist;"Noise floor should be below this"],'location','se','fontsize',7)
    subplot(2,1,2)
    AKp(h(1:round(0.003*fs),snrlist,2),'et2d','fs',fs), hold on
    plot([0,3],[mean(peakR(snrlist)-SNRthresh),mean(peakR(snrlist)-SNRthresh)],'k--','LineWidth',2)
    title('Right'), legend([strlist;"Noise floor should be below this"],'location','se','fontsize',7)
    sgtitle('Warning: low onset SNR in HRIRs. The noise floor should be below the black line.')
    uiwait(dlg);
    close(gcf)
end

% Show dialog for energy loss
if ~isempty(nrglist)
    warningCount = warningCount + 1;
    ears = {'Left','Right'};
    azlist = pos(nrglist,1);
    ellist = pos(nrglist,2);
    len = numel(nrglist);
    strlist = repmat("[az=",len,1) + string(azlist(:)) + repmat(",el=",len,1) + string(ellist(:)) + repmat("]",len,1);
    dlg = warndlg([sprintf('WARNING: more than %0.2f%% of the HRIR energy was lost when windowing for %d HRTF measurements',nrgThresh*100,len),' (see figure). Please consider checking the microhpones, measurement conditions and latency in general. Click OK to close the plots and continue.'],'Big energy loss when windowing');
    figure('pos',[12 91 1357 785])
    for ch=1:2
        subplot(2,1,ch)
        AKp(hext(:,nrglist,ch),'et2d','fs',fs), hold on 
        % Plot window and show title
        winplot = [zeros(extralength_plot(1),1);win;zeros(extralength_plot(2),1)];
        yyaxis('right')
        plot([(0:irLen+extralength_plot(1)+extralength_plot(2)-1)*1000/fs],winplot,'r-.','LineWidth',1.5)
        ax = gca; ax.YAxis(2).Color = 'r';
        ylabel('Window amplitude')
        title(sprintf('%s',ears{ch}))
        legend([strlist;"Window"],'location','se','fontsize',7)
    end
    sgtitle('Warning: large energy loss when windowing HRIRs. The red window should cover the whole HRIR.')
    uiwait(dlg);
    close(gcf)
end

%% Finished dialog
if warningCount == 0  
    dlg = helpdlg(sprintf('Finished sanity check! A total of %d headphone measurements and %d HRTF measurements were evaluated. No warnings were shown. Click OK to continue.',countHP,countHRTF),'Finished sanity check');
else
    dlg = warndlg(sprintf('Finished sanity check! A total of %d headphone measurements and %d HRTF measurements were evaluated. %d warnings were shown. Click OK to continue.',countHP,countHRTF,warningCount),'Finished sanity check');
end
uiwait(dlg)

