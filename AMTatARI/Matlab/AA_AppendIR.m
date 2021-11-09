function [hM,meta]=AA_AppendIR(hM,hMNEW,meta,aziNEW,eleNEW)

% AA_AppendIR             - append an IR to hM
%
% [hM,meta]=AA_AppendIR(hM,hMNEW,meta,aziNEW,eleNEW)
%
% Input: 
%  hM: data matrix with impulse resposes (IR): 
%  hMNEW: new IR to be appended. Must have the correct size!
%  meta: hM structured meta data
%  aziNEW: azimuth of the new IR
%  eleNEW: elevation of the new IR
% 
% Piotr Majdak, 17.5.2006
% Last change: 05.10.2011 by Michael Mihocic, upgrade to structured meta
%  data hM version 2.0.0


% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

  % copy the data
hM(:,end+1,:)=hMNEW;
meta.amp=[meta.amp; NaN];
meta.itemidx=[itemidx; NaN];
meta.lat=[meta.lat; mean(meta.lat)];
meta.pos=[meta.pos; NaN(1,size(pos,2))];
meta.pos(end,1)=aziNEW;
meta.pos(end,2)=eleNEW;

clear h ii *NEW
