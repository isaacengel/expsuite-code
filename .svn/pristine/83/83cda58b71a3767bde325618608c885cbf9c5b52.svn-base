function ch=AA_CalcSaveEMP(stimPar, hM1, meta, ch, amp, fu, fo, flen, fn)

% function ch=AA_CalcSaveEMP(stimPar, hM1, meta, ch, amp, fu, fo, flen, fn)
% 
% channel CH of hM is used
% STIMPAR: stimulation parameters
% META: meta data
% AMP: amplitude of target [dB]
% FU, FO: start and end frequency of target [Hz]
% FLEN: length of the result filter [samples]
% FN: file name
% 
% Last change: 06.2014 by Michael Mihocic

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence. 
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
% See the Licence for the specific language governing  permissions and limitations under the Licence. 
  
fs=stimPar.SamplingRate;
  % extract one channel
hM1=squeeze(hM1(:,:,ch));
%flen=size(hM1,1);

  % create target spectrum
target = ones(ceil(flen/2), 1)*10^(amp/20);
target(1:(round(fu/fs*(flen))-1)) = 0;
target((round(fo/fs*(flen))+1):end) = 0;
targetf=flipud(target);
if mod(flen,2)==0
  target=[target; targetf];
else
  target=[target; targetf(1:end-1)];
end

  % emphasis filter and equalize
hEMP=single(zeros(flen, size(hM1,2)));
for ii=1:size(hM1,2)
  sEMP=target./fft(hM1(:,1),flen);
  hEMP(:,ii)=single(real((ifft(sEMP))));
end

chEMP=meta.pos(:,3);
save(fn, 'hEMP','chEMP');
ch=unique(chEMP);   % channels found
