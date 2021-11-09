function [p,ii]=AA_REALmedianplane(hM, meta, mode, sens)
% [p,idx]=AA_REALmedianplane(hM, meta, mode, sens);
% plot the positions which stand for the real median plane
% The positions are choosen upon on the mode:
% ITD: seek for IACC with the max. lag of SENS (0 samples per default)
% ILD: seek for ILD smaller SENS dB (1 dB per default)
%
% p: new meta.pos with new data in last columns
% idx: index of positions in the real median plane
% Last change: 05.10.2011 by Michael Mihocic, upgrade to structured meta
%  data hM version 2.0.0
  

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

if mode=='ITD'
  p=AA_CalcXCorr(hM, meta);
  if ~exist('sens')
    sens=0;
  end
  ii=find(abs(p(:,8))<=sens);
elseif mode=='ILD'
  p=AA_CalcEnergy(hM, meta);
  if ~exist('sens')
    sens=1;
  end
  ii=find(abs(p(:,8)-p(:,9))<sens);
else
  error('Use ILD or ITD as mode');
end
p0=p(ii,:);

figure;
polar3ortho(-1,5);
polar3(deg2rad(p0(:,1)), deg2rad(p0(:,2)),ones(length(p0),1),'rx');
view(2);
title(mode);