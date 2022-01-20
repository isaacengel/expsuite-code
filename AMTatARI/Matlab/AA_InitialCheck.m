function AA_InitialCheck(workdir,settingsfile,itemlistfile,target_gain,lr_dif,varargin)

% Initial check before HRTF measurement, to ensure mics/speakers are OK.
% The check is run only on the first item of the list (first azimuth).

% target_gain = -15; % minimum expected peak gain in dB for all IRs
% lr_dif = 5; % maximum peak gain difference allowed between L and R channels
extra_offset = 0.003; % extra length (s) included before and after each IR

r = 1.5; % TODO: verify this is the correct distance from speaker driver to arc center
gain = 0; % in dB; TODO: input this as a parameter

% To save figures
figdir = [workdir,'/plots'];
if ~isfolder(figdir)
    mkdir(figdir)
end

if ischar(target_gain)
    target_gain = str2num(target_gain);
end
if ischar(lr_dif)
    lr_dif = str2num(lr_dif);
end

%% Load settings
settings = AA_ReadSettingsFile(settingsfile);
fs = settings.fs;
isdList = settings.isdList;
srcList = settings.srcList;
irLen = round(settings.irLen*fs/1e3); % in samples
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

%% Prepare inter-sweep delay list
ISD = zeros(size(isdList));
for i=1:numel(isdList)
    ISD(i) = sum(isdList(1:i))*fs/1000; % in samples
end

%% Calculate HRIRs
itemlist = readtable(itemlistfile,'Delimiter',',');
indAz = find(~isnan(itemlist.Azimuth)); % ignore rows without defined azimuth
row = indAz(1); % only first row
count = 1;
pos = [];
h = [];

az = mod(360-itemlist.Azimuth(row),360); % source az = - turntable az
id = itemlist.Index(row);
el = str2num(itemlist.Elevation{row});
numEl = numel(el);

% Deconvolve
ir = [];
for ch=1:2
    file = sprintf('%s/AMTatARI_%0.4d_adc%d.wav',workdir,id,ch-1);
    if ~isfile(file)
        error('Audio file not found! Please run the first item of the list before doing the initial check. To do so, select the first item and click ''Stimulate selected''.')
    end
    [x,fs_] = audioread(file); % read recording
    if max(abs(x(:))) >= 1
        error('The microphone clipped! Please reduce the microphone gain on the audio interface and repeat the measurments.')
    end
    x = x.*db2mag(gain); % apply gain
    assert(fs==fs_,'Sampling frequency mismatch!')
    convlen = size(x,1) + swlen - 1;
    nfft = 2^nextpow2(convlen);
    irtemp = ifft( fft(x,nfft) .* fft(invsweep,nfft) );
    ir(:,ch) = irtemp(1:convlen);
end

for j=1:numEl
    ind = srcList(:,2)==el(j);
    lat(j) = srcList(ind,3)*fs/1e6; % in samples
    ibeg=int32(swlen+(ISD(j))+lat(j)-irOffset(1)) - extra_offset;
    iend = ibeg + irLen - 1 + extra_offset;
    for ch=1:2
        h(:,count,ch)=ir(ibeg:iend,ch);
    end
    pos(count,:) = [az,el(j),r];
    count = count+1;
end

% Check HRIR peak
peaks = squeeze(db(max(abs(h),[],1)));
err_msg = "";
if any(peaks(:,1) < target_gain)
    err_msg = sprintf("%sLeft mic: some IR peaks were below the target (<%ddB). Check mic and/or speakers.\n",err_msg,target_gain);
end
if any(peaks(:,2) < target_gain)
    err_msg = sprintf("%sRight mic: some IR peaks were below the target (<%ddB). Check mic and/or speakers.\n",err_msg,target_gain);
end
if any(abs(peaks(:,1)-peaks(:,2)) > lr_dif)
    err_msg = sprintf("%sL and R mics showed important gain differences (>%ddB). Check mics.\n",err_msg,lr_dif);
end
if err_msg~=""
    error(err_msg)
end
    