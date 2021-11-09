% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

function [hMnew, stimPar]=AA_Resample(stimPar, hM, fsnew)

fs=stimPar.SamplingRate;
hMnew=zeros(ceil(fsnew/fs*size(hM,1)), size(hM,2), size(hM,3), 'single');
for jj=1:size(hM,3)
  for ii=1:size(hM,2)
    hMnew(:,ii,jj)=single(resample(double(squeeze(hM(:,ii,jj))), ...
      fsnew, fs));
  end
end
stimPar.SamplingRate = fsnew;