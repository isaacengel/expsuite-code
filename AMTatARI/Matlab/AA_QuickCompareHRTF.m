function AA_QuickCompareHRTF(sofaFile1,sofaFile2,itdThresh,magThresh,freqRange)

%itdThresh = 200e-6; % itd delta threshold (s)
%magThresh = 15; % low frequency magnitude threshold (dB)
%freqRange = [200 1500]; % frequency range checked in the magnitude comparison

sofa1 = SOFAload(sofaFile1);
sofa2 = SOFAload(sofaFile2);

[h1,fs,az,el] = sofa2hrtf(sofa1);
[h2,fs_,az_,el_] = sofa2hrtf(sofa2);

assert(fs==fs_,'sampling rate mismatch!')
assert(all(abs(az-az_)<0.01) && all(abs(el-el_)<0.01),'directions mismatch!')
clear fs_ az_ el_

% Check low-freq magnitude delta
% dtf1 = getDTF(h1,fs);
% dtf2 = getDTF(h2,fs);
H1 = ffth(h1);
H2 = ffth(h2);
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
