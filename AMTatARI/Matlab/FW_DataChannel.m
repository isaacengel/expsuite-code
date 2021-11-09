function [stimVec, stimPar] = FW_DataChannel(~, stimPar, DataString, Nsamp, QAMsize, offset)
% Convert the string 'DataString' to data that can be transmitted via audio
% channel
% Input Parameter:
%   stimVec:    (not used)
%   stimPar:    stimulation parameter (eg. stimPar.SamplingRate)
%   DataString: string to be transmitted
%   Nsamp:      number of samples per symbol in modulation
%   QAMsize:    alphabet size of QAM, must be an integer power of two
% Output:
%   stimVec:    data stream to be assembled as audio file
%   stimPar:    (not modified)
% 
%  Test:
%    stimPar.SamplingRate=48000;
%    stimVec=FW_DataChannel([], stimPar, 'ABCabcäöü', 16, 4);
%    FW_DataChannelImport(stimVec, stimPar, 16, 4)

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

%% For debugging
% Nsamp=16;
% QAMsize=4;
% stimPar.SamplingRate=48000;
% DataString='ABÖé';

%% Prepare
showfigures=0;
fs=stimPar.SamplingRate;
fc=fs/4;
M=QAMsize;
if ~exist('offset','var'), offset=0; end

%% Encode
if showfigures, disp(DataString); end
bi=de2bi([repmat(255,1,4) double(DataString)]);
bim=reshape([bi(:); zeros(mod(log2(M)-mod(length(bi(:)),log2(M)),log2(M)),1)],[],log2(M));
xtr=bi2de(bim)';

if showfigures,
    subplot(4,1,1); hold on;
    stem(xtr);
    title('xtr');
end

%% Quadrant Amplitude Modulation
xenc = qammod(xtr,M);
% disp(['StringQAM: ' StringQAM]);
if showfigures,
    subplot(4,1,2); hold on;
    plot(real(xenc)); 
    plot(imag(xenc),'g');
    title('xenc');
end

%% baseband shaping
span=6;
rolloff=0.25;
h = rcosdesign(rolloff, span, Nsamp);
xfilt=upfirdn(real(xenc), h, Nsamp)+1i*upfirdn(imag(xenc), h, Nsamp);

if showfigures,
    subplot(4,1,3);    hold on;
    plot(real(xfilt),'b')
    plot(imag(xfilt),'g');
    title('shaped');
end

%% Modulator
carrier=sqrt(2)*exp(1i*2*pi*fc*(0:1/fs:(length(xfilt)-1)/fs)); 
stimVec = real(xfilt.*carrier)';
stimVec = stimVec/max(abs(stimVec));
stimVec = [zeros(offset,1); stimVec];
if showfigures,
    subplot(4,1,4);
    plot(stimVec); hold on;
end

% %% channel
% rx=awgn(stimVec,40,'measured');
% % audiowrite('test.wav',stimVec,fs);
% subplot(4,1,4);
% plot(rx,'r');
% 
% %% passband demod
% ydemod = rx.*conj(carrier);
% subplot(4,1,3); hold on;
% plot(real(ydemod),'b','LineWidth',2)
% plot(imag(ydemod),'g','LineWidth',2);
% title('shaped');
% 
% %% filter and downsampling
% yfilt=upfirdn(ydemod, h, 1, Nsamp);
% yfilt=yfilt(span+1:end-span);
% subplot(4,1,2); hold on;
% plot(real(xenc),'LineWidth',2); 
% plot(imag(xenc),'g','LineWidth',2);
% title('xenc');
% 
% %% demod
% ytr=qamdemod(yfilt, M);
% subplot(4,1,1);
% plot(ytr,'r:','LineWidth',2);

% [numErrors, ber] = biterr(xtr, ytr);
% fprintf('\nThe bit error rate = %5.2e, based on %d errors\n', ber, numErrors)
