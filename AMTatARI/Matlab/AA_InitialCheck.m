function AA_InitialCheck(workdir,settingsfile,itemlistfile,target_gain,lr_dif)

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
if ~exist('target_gain','var')
    target_gain = [];
end
if ~exist('lr_dif','var')
    lr_dif = [];
end

extra_offset = 0.003; % extra length (s) included before and after each IR

r = 1.5; % TODO: verify this is the correct distance from speaker driver to arc center
gain = 0; % in dB; TODO: input this as a parameter

%% Load settings
settings = AA_ReadSettingsFile(settingsfile);
fs = settings.fs;
isdList = settings.isdList;
srcList = settings.srcList;
irLen = round(settings.irLen*fs/1e3); % in samples
irOffset = round(settings.irOffset*fs/1e3); % in samples
target_gain_tmp = settings.initial_check_target_gain;
lr_dif_tmp = settings.initial_check_lr_dif;
clear settings

% Check if these two have not been used as parameters
if isempty(target_gain)
    if ~isempty(target_gain_tmp)
        target_gain = target_gain_tmp;
    else
        target_gain = -32; % default value
    end
end
if isempty(lr_dif)
    if ~isempty(lr_dif_tmp)
        lr_dif = lr_dif_tmp;
    else
        lr_dif = 10; % default value
    end
end
clear target_gain_tmp lr_dif_tmp

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

% for j=1:numEl
%     ind = srcList(:,2)==el(j);
%     lat(j) = srcList(ind,3)*fs/1e6; % in samples
%     ibeg = int32(swlen+(ISD(j))+lat(j)-irOffset(1)) - extra_offset;
%     iend = ibeg + irLen - 1 + 2*extra_offset;
%     for ch=1:2
%         h(:,count,ch)=ir(ibeg:iend,ch);
%     end
%     pos(count,:) = [az,el(j),r];
%     count = count+1;
% end

% Check HRIR peak
% peaks = squeeze(db(max(abs(h),[],1)));
peaks = db(max(abs(ir),[],1));
err_msg = "";
if any(peaks(:,1) < target_gain)
    err_msg = sprintf("%sLeft mic: IR peak was lower than expected (<%ddB). Check mic and/or speakers.\n",err_msg,target_gain);
end
if any(peaks(:,2) < target_gain)
    err_msg = sprintf("%sRight mic: IR peak was lower than expected (<%ddB). Check mic and/or speakers.\n",err_msg,target_gain);
end
if any(abs(peaks(:,1)-peaks(:,2)) > lr_dif)
    err_msg = sprintf("%sL and R mics showed important gain differences (>%ddB). Check mics.\n",err_msg,lr_dif);
end
if err_msg~=""
    error(err_msg)
end
    