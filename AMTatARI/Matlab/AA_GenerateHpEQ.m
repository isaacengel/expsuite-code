function AA_GenerateHpEQ(sofaname,workdir,settingsfile,itemlistfile,doplots,targetFs,taps,masiero)

% Process headphone measurements and generate HpEQ filter.

gain = 0; % in dB; TODO: input this as a parameter

% To save figures
figdir = [workdir,'/plots'];
if ~isfolder(figdir)
    mkdir(figdir)
end

if ~exist('taps','var')
    taps = 4096;
end

if ~exist('masiero','var')
    % If masiero==1, instead of average, we will use average + 1std as
    % suggested in a paper by B. Masiero and J. Fels (TODO: include
    % reference), to avoid deep notches
    masiero = 0;
end

%% Load settings
settings = AA_ReadSettingsFile(settingsfile);
fs = settings.fs;
% irLen = round(settings.irLen*fs/1e3); % in samples; NOTE: we could use a different value here
irLen = taps; % for headphone measurements we can safely use long IRs
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

%% Calculate HRIRs
itemlist = readtable(itemlistfile,'Delimiter',',');
indAz = find(isnan(itemlist.Azimuth)); % ignore rows with defined azimuth
numAz = numel(indAz);
count = 1;
h = [];
for i=1:numAz
    row = indAz(i);
    id = itemlist.Index(row);
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
    for ch=1:2
        ons = AKonsetDetect(ir(:,ch));
        % NOTE: alternatively, we could measure the system latency and
        % use that instead of detect the onset
        ibeg=int32(ons-irOffset(1));
        iend = ibeg + irLen - 1;
        h(:,count,ch)=ir(ibeg:iend,ch);
    end
    count = count+1;
    
end

if size(h,2) == 0
    warning('No headphone recordings were found.')
    return
elseif size(h,2) < numAz
    warning('Some headphone recordings were not found.')
end

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

%% Save HRIRs and calculate filters

% Make avg IR for each ear
taps_minphase = 2^20; % we want a big number of taps for the minphase reconstruction to work well
h_avg = zeros(taps,2);
for ch=1:2
    IR = h(:,:,ch);
    IR = [IR; zeros(taps_minphase - size(IR,1), size(IR,2))]; % zero pad
    FR = ffth(IR,taps_minphase,1);
    FR_mag = abs(FR); % magnitude
    FR_avg = mean(FR_mag,2); % mean
    if masiero == 1
        FR_std = std(FR_mag,0,2); % std
        FR_avg = FR_avg + FR_std;
    end
    FR_avg_mp = makeMinPhase(FR_avg);
    IR_avg = iffth(FR_avg_mp);
    IR_avg = IR_avg(1:taps,:); % trim
    win_hann = hann(2*taps-1); % hann window
    IR_avg = IR_avg.*win_hann(taps:end); % apply hann window
    h_avg(:,ch) = IR_avg;
end

% Make avg IR, averaging both ears
for ch=1:2
    IR = [h(:,:,1),h(:,:,2)];
    IR = [IR; zeros(taps_minphase - size(IR,1), size(IR,2))]; % zero pad
    FR = ffth(IR,taps_minphase,1);
    FR_mag = abs(FR); % magnitude
    FR_avg = mean(FR_mag,2); % mean
    if masiero == 1
        FR_std = std(FR_mag,0,2); % std
        FR_avg = FR_avg + FR_std;
    end
    FR_avg_mp = makeMinPhase(FR_avg);
    IR_avg = iffth(FR_avg_mp);
    IR_avg = IR_avg(1:taps,:); % trim
    win_hann = hann(2*taps-1); % hann window
    IR_avg = IR_avg.*win_hann(taps:end); % apply hann window
    h_avg_both = IR_avg;
end

if doplots
    figure('pos',[10 60 1000 340]);
    for ch=1:3
        subplot(1,3,ch)
        % Prepare legend
        dummy_lines = plot([NaN,NaN],'color','k','LineWidth',2); hold on;
        if ch<3
            AKp(h(:,:,ch),'m2d','fs',fs)
            AKp(h_avg(:,ch),'m2d','fs',fs,'lw',2,'c','k')
        else
            AKp([h(:,:,1),h(:,:,2)],'m2d','fs',fs)
            AKp(h_avg_both,'m2d','fs',fs,'lw',2,'c','k')
        end
        if ch==1
            title('Left ear')
        elseif ch==2
            title('Right ear')
        else
            title('Both ears')
        end
        % Show legend
        if masiero == 1
            legend(dummy_lines,{'Avg + 1std'},'Location','southwest')
        else
            legend(dummy_lines,{'Avg'},'Location','southwest')
        end
    end
    sgtitle('Headphone response (all measurements + average)')
    saveas(gcf,sprintf('%s/%s_avg_headphone_response.png',figdir,sofaname))
    close(gcf)
end
      
% Get HpEQ filter (minimum phase) for each ear
H = ffth(h_avg);
nfreqs = size(H,1);
fvec = linspace(0,fs/2,nfreqs);
[~,ind1khz] = min(abs(fvec-1000));
maxAmp = 15; % TODO: enter as parameter
frac = 0.25; % TODO: enter as parameter
flims = [50 16000]; % TODO: enter as parameter
for ch=1:2
    T = H(ind1khz,ch); % flat target frequency response, calibrated at 1khz
    EQ(:,ch) = autoreg_minphase(H(:,ch),T,fs,maxAmp,frac,flims);
    eq(:,ch) = iffth(EQ(:,ch));
end

% Get HpEQ filter, averaging both ears
H_both = ffth(h_avg_both);
T = H_both(ind1khz); % flat target frequency response, calibrated at 1khz
EQ_both = autoreg_minphase(H_both,T,fs,maxAmp,frac,flims);
eq_both = iffth(EQ_both);

if doplots
    figure('pos',[10 60 1000 340]);
    for ch=1:3
        subplot(1,3,ch)
        if ch<3
            AKp(h_avg(:,ch),'m2d','fs',fs,'lw',2,'c','k')
            AKp(eq(:,ch),'m2d','fs',fs,'lw',2,'c','b')
            y = iffth( ffth(h_avg(:,ch)) .* ffth(eq(:,ch)) );
            AKp(y,'m2d','fs',fs,'lw',2,'c','r')
        else
            AKp(h_avg_both,'m2d','fs',fs,'lw',2,'c','k')
            AKp(eq_both,'m2d','fs',fs,'lw',2,'c','b')
            y = iffth( ffth(h_avg_both) .* ffth(eq_both) );
            AKp(y,'m2d','fs',fs,'lw',2,'c','r')
        end
        if ch==1
            title('Left ear')
        elseif ch==2
            title('Right ear')
        else
            title('Both ears')
        end
        % Show legend
        legend({'Before EQ','EQ filter','After EQ'},'Location','southwest')
        ylim([-40 20])
    end
    sgtitle('Headphone response before and after EQ')
    saveas(gcf,sprintf('%s/%s_headphone_EQ.png',figdir,sofaname))
    close(gcf)
end
    
eq_original = eq;
eq_both_original = eq_both;
fs_original = fs;
clear eq eq_both fs

for i=1:numel(targetFs)

    fs = targetFs(i);
    
    tFsdir = sprintf('%s/HPEQ/%0.2dkHz',workdir,round(fs/1000));
    if ~isfolder(tFsdir)
        mkdir(tFsdir)
    end
    
    % Resample if needed
    if fs ~= fs_original
        eq = resample(eq_original,fs,fs_original);
        eq_both = resample(eq_both_original,fs,fs_original);
    else
        eq = eq_original;
        eq_both = eq_both_original;
    end
    
    % Save all IRs + avg (minimum phase) + EQ filter
    filename = sprintf('%s/%s_headphoneEQ_%0.2dkHz',tFsdir,sofaname,round(fs/1000));
    save(filename,'h','h_avg','h_avg_both','eq','eq_both','fs','fs_original')
    fprintf('Saved all heapdhone IRs and filters in %s.mat...\n',filename)
    audiowrite([filename,'.wav'],eq_both,fs,'BitsPerSample',32)
    fprintf('Saved headphone EQ filter as %s.wav...\n',filename)
 
end
