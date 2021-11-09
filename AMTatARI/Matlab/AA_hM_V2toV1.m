% Convert hM v.2 to old format
% Last change: 12.10.2011 by Michael Mihocic, upgrade to structured meta
%  data hM version 2.0.0
%
%	- Load hM v2
% 	- Run script
%   - Save hM


% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

if isfield(stimPar,'SubjectID')
    subjectID=stimPar.SubjectID;
else
    subjectID='';
end

% transfer *LIN to meta
posLIN=meta.pos;
itemidxLIN=meta.itemidx;
itemnrLIN=unique(itemidxLIN);
latLIN=meta.lat;

if isfield(meta,'toa')
    toaLIN=meta.toa;
end

IRnrLIN=zeros(length(unique(itemidxLIN)),1);
ampLIN=zeros(length(unique(itemidxLIN)),1);

jj=1;
for ii=1:length(IRnrLIN)
    IRnrLIN(ii)=length(find(itemnrLIN(ii)==itemidxLIN));
    ampLIN(ii)=meta.amp(jj);
    jj=jj+IRnrLIN(ii);
end

stimPar.Version='1';
clear stimPar.SubjectID ii jj kk meta;