function AA_Remove(idx)

  % get the data from the base workspace
  % Last change: 05.10.2011 by Michael Mihocic, upgrade to structured meta
  %  data hM version 2.0.0


% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

hM = evalin('base','hM');
meta.amp=evalin('base','meta.amp');
meta.itemidx=evalin('base','meta.itemidx');
meta.lat=evalin('base','meta.lat');
meta.pos=evalin('base','meta.pos');
if ~isfield(meta,'toa')
    meta.toa=zeros(size(meta.lat));
end
meta.lat=evalin('base','meta.lat');

  % manipulate data
hM=hM(:,[1:idx-1 idx+1:end],:);
% meta.itemidx=meta.itemidx(idx);  % get the index of the IR
meta.itemidx=meta.itemidx([1:idx-1 idx+1:end],:);
meta.pos=meta.pos([1:idx-1 idx+1:end],:);
meta.lat=meta.lat([1:idx-1 idx+1:end],:);
meta.amp=meta.amp; % amplitude does not change
meta.toa=meta.toa([1:idx-1 idx+1:end],:);

  % save data in the base workspace
assignin('base','hM',hM);
assignin('base','meta.amp',meta.amp);
assignin('base','meta.itemidx',meta.itemidx);
assignin('base','meta.lat',meta.lat);
assignin('base','meta.pos',meta.pos);
assignin('base','meta.toa',meta.toa);

  