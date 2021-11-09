function hMnew=AA_Window(hM, siglen, fadeout, fadein, offset)

% AA_Window                 - window data in time domain
%
% hMnew=AA_Window(hM, siglen, fadeout, fadein,offset)
% 
% AA_Window windows the data in hM using a rectangular window of length
% siglen. The window begins at offset. Additionally, the windowed result is 
% faded in (from begin to fadein) and out (from fadeout to the end). 
%
% Input:
%  hM: data matrix with impulse respnoses (IR):
%      dim 1: time in samples
%      dim 2: each IR
%      dim 3: each record channel
%  siglen: length of the window in samples
%  fadeout: length of the fade out (Hanning window) in samples
%  fadein: length of the fade in (Hanning window) in samples
%  offset: offset (or shift) of the window in samples. 
%
% Output: 
%  hMnew: windowed hM data
%
% Piotr Majdak, 13.1.2006

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.


hMnew=single(zeros(siglen,size(hM,2), size(hM,3)));
for rec=1:size(hM,3) % for each REC
  for ii=1:size(hM,2) % for each channel
    hMnew(:,ii,rec)=single(FW_fade(squeeze(double(hM(:,ii,rec))), siglen,fadein,fadeout,offset));
  end
end