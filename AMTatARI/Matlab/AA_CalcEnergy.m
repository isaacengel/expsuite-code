function meta=AA_CalcEnergy(hM, meta)

% AA_CalcEnergy               - calculate the energy of IR
%
% meta.pos=AA_CalcEnergy(hM, meta.pos)
% 
% AA_CalcEnergy calculates the energy of each IR and appends this
% information to meta.pos in two additional columns. 
% AA_CalcEnergy works with stereo record channels only.
%
% Input: 
%  hM: data matrix with impulse respnoses (IR): 
%      dim 1: time in samples
%      dim 2: each IR
%      dim 3: each record channel
%  meta.pos: matrix with position information of an IR
%          [azi ele channel azi' ele' lateral polar]
%
% Output:
%  meta.pos: matrix with additional informations
%          [azi ele channel azi' ele' lateral polar energy_left energy_right]
%
% Piotr Majdak, 19.12.2007
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
for ii=1:size(hM,2)
  hM1=double(squeeze(hM(:,ii,:)));
  meta.pos(ii,[col col+1])=10*log10((sum(hM1.*hM1)));
end