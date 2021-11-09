function [Data] = FW_DataChannelImport(stimVec, stimPar, Nsamp, QAMsize)
% Import audio file and (re-)convert stream to a data string
% channel
% Input Parameter:
%   stimVec:    Audio vector with the data
%   fs:         sampling Rate
%   Nsamp:      number of samples per symbol in modulation
%   QAMsize:    alphabet size of QAM, must be an integer power of two
% Output:
%   Data:       demodulated string
% 

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

%% Prepare
showfigures=0;
fs=stimPar.SamplingRate;
fc=fs/4;
M=QAMsize;

%% channel
% rx=awgn(stimVec,40,'measured');
% rx=audioread(fn);
rx=stimVec;
if showfigures,
    subplot(4,1,4);
    plot(rx,'r:');
end

%% passband demod
carrier=sqrt(2)*exp(1i*2*pi*fc*(0:1/fs:(length(rx)-1)/fs)); 
ydemod = rx'.*conj(carrier);
if showfigures,
    subplot(4,1,3); hold on;
    plot(real(ydemod),'b:','LineWidth',2)
    plot(imag(ydemod),'g:','LineWidth',2);
end

%% filter and downsampling
span=6;
rolloff=0.25;
h = rcosdesign(rolloff, span, Nsamp);
yfilt=upfirdn(ydemod, h, 1, Nsamp);
yfilt=yfilt(span+1:end-span);
if showfigures,
    subplot(4,1,2); hold on;
    plot(real(xenc),'b:','LineWidth',2); 
    plot(imag(xenc),'g:','LineWidth',2);
end

%% demod
ytr=qamdemod(yfilt, M);
if showfigures,
    subplot(4,1,1);
    plot(ytr,'r:','LineWidth',2);
end

%% decode
bimo=de2bi(ytr);
bio=reshape([bimo(:); zeros(mod(8-mod(length(bimo(:)),8),8),1)],[],8);
Data=char(bi2de(bio))';
Data=Data(5:end);
if showfigures, disp(Data); end

%% For debugging
% [numErrors, ber] = biterr(xtr, ytr);
% fprintf('\nThe bit error rate = %5.2e, based on %d errors\n', ber, numErrors)