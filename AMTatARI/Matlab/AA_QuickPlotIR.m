function AA_QuickPlotIR(plotname,workdir,settingsfile,itemlistfile)

% Shows a bunch of plots of the recorded IR as a sanity check.

r = 1.5; % TODO: verify this is the correct distance from speaker driver to arc center
gain = 30; % in dB; TODO: input this as a parameter
ears = {'Left','Right'};

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

%% Window settings (TODO: consider assymetrical window or longer fade out)
fadelen = 32;
t = linspace(0,pi/2,fadelen).';
fadein = sin(t).^2;
fadeout = cos(t).^2;
win = [fadein; ones(irLen-2*fadelen,1); fadeout];

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
extralength_plot = 250; % samples
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
    fig = figure('pos',[14.6000 49.8000 798.4000 638.4000]);
    % Deconvolve
    ir = [];
    for ch=1:2
        file = sprintf('%s/AMTatARI_%0.4d_adc%d.wav',workdir,id,ch-1);
        if ~isfile(file)
            continue
        end
        [x,fs_] = audioread(file); % read recording
        assert(fs==fs_,'Sampling frequency mismatch!')
        
        % Plots
        subplot(3,2,ch), AKp(x,'et2d','fs',fs)
        title(sprintf('Raw recording, %s (time)',ears{ch})), ylim([-100 0])
        fvec = linspace(0,fs/2,2048);
        subplot(3,2,2+ch), spectrogram(x,1024,32,fvec,fs,'yaxis')
        cax = caxis; caxis([cax(2)-70 cax(2)]) % adjust color axis
        title(sprintf('Raw recording, %s (spectrogram)',ears{ch}))
        
        convlen = size(x,1) + swlen - 1;
        nfft = 2^nextpow2(convlen);
        irtemp = ifft( fft(x,nfft) .* fft(invsweep,nfft) );
        ir(:,ch) = irtemp(1:convlen);
        
        % Plots
        subplot(3,2,4+ch), AKp(ir(:,ch),'et2d','fs',fs)
        title(sprintf('IR, %s (time)',ears{ch})), ylim([-140 -40])
        sgtitle(sprintf('%s, Raw recordings and IRs, Az=%d°',plotname,az),'interpreter','none')
        
    end
    % If files were not found, skip this azimuth
    if size(ir,2) < 2
        warning('Could not find files for azimuth %d. Skipping...',az)
        close(fig)
        continue
    end

    % Separate HRIRs and plot
    figure('pos',[21.8000 83.4000 1.1176e+03 340.8000])
    colors = parula(numEl+1);
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
        
        % Plots
        AKp(ir(ibeg-extralength_plot:iend+extralength_plot,ch),'et2d','fs',fs,'c',colors(j,:)), hold on
%         AKp(h(:,count,ch),'et2d','fs',fs,'c',colors(j,:)), hold on
        
        count = count+1;
    end
    
    yyaxis('right')
    winplot = [zeros(extralength_plot,1);win;zeros(extralength_plot,1)];
    plot([(0:irLen+2*extralength_plot-1)*1000/fs],winplot,'r-.','LineWidth',1.5)
    ax = gca; ax.YAxis(2).Color = 'r';
    ylabel('Window amplitude')
   
    % Legend
    leg = {};
    for j=1:numEl
        leg{j} = strcat('El=',num2str(el(j)),'°');
    end
    leg{numEl+1} = 'Window';
    legend(leg,'FontSize',6,'Position',[0.0078 0.1063 0.0714 0.8342])
    
    title(sprintf('%s, Aligned IRs, Az=%d°, %s (time)',plotname,az,ears{ch}),'interpreter','none')
    
end

%% Window HRIRs

hwin = win.*h(1:irLen,:,:);

% Apply gain
h = hwin.*db2mag(gain);
clear hwin

quickplotHRTF(h,fs)
ndirs = size(h,2);
sgtitle(sprintf('%s, all %d HRIRs after applying window and gain',plotname,ndirs),'interpreter','none')

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

% function quickplotHRIR(h,fs)
%     figure('pos',[5 145.8000 1040 447.2000])
%     subplot(2,2,1), AKp(h(:,:,1),'et2d','fs',fs),title('Left'),hold on
%     subplot(2,2,2), AKp(h(:,:,2),'et2d','fs',fs),title('Right'),hold on
%     subplot(2,2,3), AKp(h(:,:,1),'m2d','fs',fs),hold on
%     subplot(2,2,4), AKp(h(:,:,2),'m2d','fs',fs),hold on
% end