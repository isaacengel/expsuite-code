function [stimVec,invsweep]=AA_AppendExpSweep(stimVec,stimPar,fstart,fend,T)

% AA_AppendExpSweep             - append an exponential sweep to a vector
%
% [stimVec,invsweep]=AA_AppendExpSweep(stimVec,stimPar,fstart,fend,T)
%
% AA_AppendExpSweep generates an exponential sweep and appends it to stimVec.
% Additionally, an inverse sweep is created - inverse in terms of
% convolution. The inverse sweep is normalized to suite in a WAV file.
%
% Input:
%  stimVec: existing vector (stimulus)
%  stimPar: structure with information about the system
%  fstart: start frequency of the sweep (in Hz)
%  fend: end freqeuncy of the sweep (in Hz)
%  T: length of the sweep (in samples);
%
% Output:
%  stimVec: stimVec with appended exponential sweep
%  invsweep: inverse exponential sweep
%
% Piotr Majdak 06.04.2006


% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

  % convert parameters
fs=stimPar.SamplingRate;
T=T/fs;
w1=2*pi*fstart;
w2=2*pi*fend;
  % calculate sweep constants
K=T*w1/log(w2/w1);
L=T/log(w2/w1);
  % create sweep
t=0:1/fs:T-1/fs;
sweep=sin(K*(exp(t/L)-1));
sweep=FW_fade(sweep',0,stimPar.FadeIn,stimPar.FadeOut)';
stimVec=[stimVec sweep];

  % create inverse sweep
n=length(sweep);
attn=0:-6*log2(w2/w1)/n:6*(-log2(w2/w1)+log2(w2/w1)/n);
attn=10.^(attn/20+1);
invsweep=fliplr(sweep).*attn;
invsweep=invsweep/max(abs(invsweep))*(1-(2^((-1)*(stimPar.Resolution-1))));   % normalise

  % normalise inv sweep to the result of deconvolution = n
%xf=20*log10(abs(fft(invsweep).*fft(sweep))/n);
%g=mean(xf(floor(fstart/fs*n):floor(fend/fs*n)));
%invsweep=invsweep./10^(g/20);  
