function scale=AA_Preemphasize(stimPar, preempfn, fn)

% scale=AA_Preemphasize(stimPar, preempfn, fn)
%
% STIMPAR
% PREEMPFN: File name of the preemphasis matrix with hEMP and chEMP
% FN: Prefix of excitation signals:
%    - FN.wav will be loaded
%    - preemphasis filters will be applied
%    - all preemphisized filters will be normalized (scaled by SCALE)
%    - result will be saved as FN_CH.wav
%
% SCALE: scaling factor for normalisation (linear, not dB)

% 
% last updates: 
%   02.2021 by M.Mihocic: wavwrite replaced by audiowrite
%   12.2016 by M.Mihocic: wavread replaced by audioread
%

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

load(preempfn); % returns with hEMP and chEMP
in=audioread(fn);
len=length(in)+size(hEMP,1);
swm=zeros(len,size(hEMP,2));
idx=zeros(size(hEMP,2),1);
for ii=1:size(hEMP,2)
  idx(ii)=find(chEMP==chEMP(ii),1);
  swm(:,ii)=real(ifft(fft(in,len) .* fft(double(hEMP(:,idx(ii))),len)));
end

scale=max(max(abs(swm)))/(1-(2^((-1)*(stimPar.Resolution-1))));
swm=swm./scale;

for ii=1:size(hEMP,2)
%   wavwrite(swm(:,ii),stimPar.SamplingRate, stimPar.Resolution, [fn '_CH' num2str(chEMP(idx(ii)))]);
%   wavwrite(Y,FS,FILENAME)  ->   AUDIOWRITE(FILENAME,Y,FS)
  audiowrite([fn '_CH' num2str(chEMP(idx(ii)))], swm(:,ii), stimPar.SamplingRate, 'BitsPerSample', stimPar.Resolution);
end
