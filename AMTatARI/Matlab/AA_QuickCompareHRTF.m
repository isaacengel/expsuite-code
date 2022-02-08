function AA_QuickCompareHRTF(sofaFile1,sofaFile2,itdThresh,magThresh,freqRange)

if ~exist('itdThresh','var')
    itdThresh = 200e-6; % itd delta threshold (s)
end
if ~exist('magThresh','var')
    magThresh = 15; % low frequency magnitude threshold (dB)
end
if ~exist('freqRange','var')
    freqRange = [200 1500]; % frequency range checked in the magnitude comparison
end

sofa1 = SOFAload(sofaFile1);
sofa2 = SOFAload(sofaFile2);

[h1,fs_ref,az,el] = sofa2hrtf(sofa1);
[h2,fs,az_,el_] = sofa2hrtf(sofa2);

% Resample if needed
if fs~=fs_ref
    h1 = resample(h1,fs,fs_ref);
end

assert(all(abs(az-az_)<0.01) && all(abs(el-el_)<0.01),'directions mismatch!')
clear fs_ref az_ el_

% Zeropad if needed
nfftlen = 2^nextpow2(max(size(h1,1),size(h2,1)));

% Check low-freq magnitude delta
% dtf1 = getDTF(h1,fs);
% dtf2 = getDTF(h2,fs);
H1 = ffth(h1,nfftlen);
H2 = ffth(h2,nfftlen);
nfreqs = size(H1,1);
f = linspace(0,fs/2,nfreqs);
ind = f>freqRange(1) & f<freqRange(2);
magD = abs( db(abs(H1(ind,:,:))) - db(abs(H2(ind,:,:))) );
if any(abs(magD(:)) > magThresh)
    error('Big low-frequency magnitude mismatch!')
end

% Check ITD delta
itd1 = itdestimator(permute(h1,[2,3,1]),'fs',fs,'Threshold',...
    'lp','upper_cutfreq', 3000,'butterpoly', 10, 'threshlvl', -10);
itd2 = itdestimator(permute(h2,[2,3,1]),'fs',fs,'Threshold',...
    'lp','upper_cutfreq', 3000,'butterpoly', 10, 'threshlvl', -10);
itdD = abs(itd1-itd2);
if any(abs(itdD) > itdThresh)
    error('Big ITD mismatch!')
end
