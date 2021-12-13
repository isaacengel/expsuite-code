function AA_QuickPlotIR(plotname,workdir,settingsfile,itemlistfile)

% Shows a bunch of plots of the recorded IR as a sanity check.

r = 1.5; % TODO: verify this is the correct distance from speaker driver to arc center
gain = 0; % in dB; TODO: input this as a parameter
ears = {'Left','Right'};

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
        if max(abs(x(:))) >= 1
            warning('The microphone clipped! Please reduce the microphone gain on the audio interface and repeat the measurments')
        end
        x = x.*db2mag(gain); % apply gain
        assert(fs==fs_,'Sampling frequency mismatch!')
        
        % Plots
        subplot(3,2,ch), AKp(x,'et2d','fs',fs)
        title(sprintf('Raw recording, %s (time)',ears{ch})), ylim([-70 0])
        fvec = linspace(0,fs/2,2048);
        subplot(3,2,2+ch), spectrogram(x,1024,32,fvec,fs,'yaxis')
        caxis([-120 -40]) % adjust color axis
        title(sprintf('Raw recording, %s (spectrogram)',ears{ch}))
        
        convlen = size(x,1) + swlen - 1;
        nfft = 2^nextpow2(convlen);
        irtemp = ifft( fft(x,nfft) .* fft(invsweep,nfft) );
        ir(:,ch) = irtemp(1:convlen);
        
        % Plots
        subplot(3,2,4+ch), AKp(ir(:,ch),'et2d','fs',fs)
        title(sprintf('IR, %s (time)',ears{ch})), ylim([-120 -20])
        sgtitle(sprintf('%s, Raw recordings and IRs, Az=%d°',plotname,az),'interpreter','none')
        
    end
    % If files were not found, skip this azimuth
    if size(ir,2) < 2
        close(fig)
        continue
    end
    
    % Save figure
%     savefig(fig,sprintf('%s/%s_Az%0.3d_Raw',figdir,plotname,az))
    saveas(fig,sprintf('%s/%s_Az%0.3d_Raw.png',figdir,plotname,az))

    % Separate HRIRs and plot
    fig = figure('pos',[21.8000 83.4000 1.1176e+03 600]);
    colors = parula(numEl+1);
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
            subplot(2,1,ch)
            AKp(ir(ibeg-extralength_plot:iend+extralength_plot,ch),'et2d','fs',fs,'c',colors(j,:)), hold on
        end
        pos(count,:) = [az,el(j),r];
       
        count = count+1;
    end
    
    % Plot window and show title
    winplot = [zeros(extralength_plot,1);win;zeros(extralength_plot,1)];
    for ch=1:2
        subplot(2,1,ch), ylim([-120 -20])
        yyaxis('right')
        plot([(0:irLen+2*extralength_plot-1)*1000/fs],winplot,'r-.','LineWidth',1.5)
        ax = gca; ax.YAxis(2).Color = 'r';
        ylabel('Window amplitude')
        title(sprintf('%s',ears{ch}))
    end
    
    % Legend
    leg = {};
    for j=1:numEl
        leg{j} = strcat('El=',num2str(el(j)),'°');
    end
    leg{numEl+1} = 'Window';
    legend(leg,'FontSize',6,'Position',[0.0067 0.2775 0.0720 0.4738])
    
    sgtitle(sprintf('%s, Aligned IRs, Az=%d° (time)',plotname,az),'interpreter','none')
    
    % Save figure
%     savefig(fig,sprintf('%s/%s_Az%0.3d_AlignedIRs',figdir,plotname,az))
    saveas(fig,sprintf('%s/%s_Az%0.3d_AlignedIRs.png',figdir,plotname,az))
    
end

%% Window HRIRs

h = win.*h(1:irLen,:,:);

quickplotHRTF(h,fs)
ndirs = size(h,2);
sgtitle(sprintf('%s, all %d HRIRs after applying window and gain',plotname,ndirs),'interpreter','none')

% Save figure
% savefig(gcf,sprintf('%s/%s_AllIRs',figdir,plotname))
saveas(gcf,sprintf('%s/%s_AllIRs.png',figdir,plotname))

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
    grid on, xlim([0 irLen/fs*1000]), ylim([-120, -20])
    xlabel('Time (ms)'), ylabel('Amplitude (dB)')
    subplot(2,2,2), plot(t,db(abs(h(:,:,2))),'Color',[0.4 0.4 0.4],'LineWidth',0.5), hold on
    plot(t,db(havg(:,:,2)),'k','LineWidth',2), title('Right HRIRs (time)')
    grid on, xlim([0 irLen/fs*1000]), ylim([-120, -20])
    xlabel('Time (ms)'), ylabel('Amplitude (dB)')
    subplot(2,2,3), semilogx(f,db(abs(H(:,:,1))),'Color',[0.4 0.4 0.4],'LineWidth',0.5), hold on
    semilogx(f,db(Hmag_avg(:,:,1)),'k','LineWidth',2), title('Left HRIRs (mag. spectra)')
    grid on, xlim([f(2) fs/2]), ylim([-60, 0])
    xlabel('Frequency (Hz)'), ylabel('Amplitude (dB)')
    subplot(2,2,4), semilogx(f,db(abs(H(:,:,2))),'Color',[0.4 0.4 0.4],'LineWidth',0.5), hold on
    semilogx(f,db(Hmag_avg(:,:,2)),'k','LineWidth',2),title('Right HRIRs (mag. spectra)')
    grid on, xlim([f(2) fs/2]), ylim([-60, 0])
    xlabel('Frequency (Hz)'), ylabel('Amplitude (dB)')
end
