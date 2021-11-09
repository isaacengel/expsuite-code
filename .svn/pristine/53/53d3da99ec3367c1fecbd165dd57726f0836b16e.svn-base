function [Obj,meta]=AA_MergeItems(Obj, rec1, rec2, meta)
% Merge two items after a splitted reference measurement
% -> copy all elevations of item REC2 rec channel 2 to item REC1 with a 
% valid rec channel 1
%
% Last change: 06.2019 by Michael Mihocic: azimuth, freq, description added
% 
   
% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence. 
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
% See the Licence for the specific language governing  permissions and limitations under the Licence. 

if isfield(Obj,'Data')
   hM=shiftdim(Obj.Data.IR,2); % new SOFA
else
  hM=Obj; % old format
end

if isempty(rec1), rec1=unique(meta.itemidx); end

if numel(rec1)==1 % "old style"
      % copy data
    si= meta.itemidx==rec2;
    di=find(meta.itemidx==rec1);
    hM(:,di,2)=hM(:,si,2);
      % truncate the data 
    meta.amp=meta.amp(di);
    meta.azimuth=meta.azimuth(di);
    meta.freq=meta.freq(di);
    meta.description=meta.description(di);
    hM=hM(:,di,:);
    meta.itemidx=meta.itemidx(di);
    meta.lat=meta.lat(di);
    meta.pos=meta.pos(di,:);
else
    di=find(meta.itemidx==rec1(1));
    for ii=2:length(rec1)
        si= meta.itemidx==rec1(ii);
        hM(:,di,ii)=hM(:,si,rec1(ii)); 
        meta.lat(di,ii)=meta.lat(si,rec1(ii));
    end
    hM=hM(:,di,:);
    meta.lat=meta.lat(di,:);
    if isfield(meta,'amp'); meta.amp=meta.amp(di); end
    if isfield(meta,'azimuth'); meta.azimuth=meta.azimuth(di); end
    if isfield(meta,'freq'); meta.freq=meta.freq(di); end
    if isfield(meta,'description'); meta.description=meta.description(di); end
    meta.itemidx=meta.itemidx(di);
    meta.pos=meta.pos(di,:);    
end

Obj.Data.IR=shiftdim(hM,1); % SOFA object
