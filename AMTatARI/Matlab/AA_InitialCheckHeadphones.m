function AA_InitialCheckHeadphones(workdir,settingsfile,itemlistfile)

% Initial check before HRTF measurement, to ensure mics/speakers are OK.
% The check is run only on the first item of the list (first azimuth).

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

taps = 2048;

%% Load settings
settings = AA_ReadSettingsFile(settingsfile);
fs = settings.fs;
% irLen = round(settings.irLen*fs/1e3); % in samples; NOTE: we could use a different value here
irLen = taps; % for headphone measurements we can safely use long IRs
irOffset = round(settings.irOffset*fs/1e3); % in samples
clear settings

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
        [~,ons(ch)] = max(abs(ir(:,ch)));
        % NOTE: alternatively, we could measure the system latency and
        % use that instead of detect the onset
        ibeg=int32(ons(ch)-irOffset(1));
        iend = ibeg + irLen - 1;
        h(:,count,ch)=ir(ibeg:iend,ch);
    end
    if ons(1) > ons(2)
        error('It seems that left/right channels are inverted! Check mics and headphones.')
    end
    count = count+1;
    
end

if size(h,2) == 0
    error('No headphone recordings were found. Please do at least one headphone measurment before running the initial check.')
end

% Compare left/right energy (RMS)
nrgL = sum(h(:,:,1).^2,1);
nrgR = sum(h(:,:,2).^2,1);
dBdif = abs(10*log10(nrgL./nrgR));
dBdif = mean(dBdif);
threshold = 1; % TODO: pass as a parameter
if dBdif > threshold
    figure
    subplot(1,2,1),AKp(h(:,:,1),'et2d','fs',fs), title('Left')
    subplot(1,2,2),AKp(h(:,:,2),'et2d','fs',fs), title('Right')
    sgtitle('Headphone Impulse Responses: large left/right mismatch!')
    error('Left and right channels show a difference of %0.2f dB (see figure). Please check the microphones',dBdif)
end

% Check IR peak
SNRthresh = 60; % TODO; pass as parameter
pad = round(0.0005 * fs); % look for the floor at 0.5ms before onset (empirically set)
[peakL,onsL] = max(db(abs(h(:,:,1))),[],1);
[peakR,onsR] = max(db(abs(h(:,:,2))),[],1);
floorL = mean(db(abs(h(1:onsL-pad,:,1))),1);
floorR = mean(db(abs(h(1:onsR-pad,:,2))),1);
if any((peakL-floorL) < SNRthresh) || any((peakR-floorR) < SNRthresh)
    figure
    subplot(1,2,1),AKp(h(:,:,1),'et2d','fs',fs), title('Left')
    subplot(1,2,2),AKp(h(:,:,2),'et2d','fs',fs), title('Right')
    sgtitle('Headphone Impulse Responses: high noise error!')
    error('The noise floor before the onset is very high (see figure). Please check the microphones')
end


    