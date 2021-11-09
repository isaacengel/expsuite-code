function meta=AA_CalcXCorr(hM, meta)

%   meta=AA_CalcXCorr(hM, meta)
% Calculate the time lag in the x-correlation
% between two record channels
% The time lag will be appended as the last column to meta.pos
% 
% Last change: 05.10.2011 by Michael Mihocic, upgrade to structured meta
%  data hM version 2.0.0


% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

col=size(meta.pos,2)+1;
win=hanning(size(hM,1)*2-1);
for ii=1:size(hM,2)
  hM1=double(squeeze(hM(:,ii,:)));
  [c,lag]=xcorr(hM1(:,1), hM1(:,2));
  [y,i]=max(abs(c).*win);
  meta.pos(ii,col)=lag(i);
  meta.pos(ii,col+1)=y;
end
