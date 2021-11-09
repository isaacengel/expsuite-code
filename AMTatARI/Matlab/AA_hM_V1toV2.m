% Convert hM to new format hM v.2
% Last change: 12.10.2011 by Michael Mihocic, upgrade to structured meta
%  data hM version 2.0.0
%
%	- Load hM v1
% 	- Run script
%   - Save hM


% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

if exist('subjectID','var')
    stimPar.SubjectID=subjectID;
end
if exist('posLIN','var') % transfer *LIN to meta
    meta.pos=posLIN;
end
if exist('itemidxLIN','var')
    meta.itemidx=itemidxLIN;
end
if exist('latLIN','var')
    meta.lat=latLIN;
end
if exist('toaLIN','var')
    meta.toa=toaLIN;
end

if exist('ampLIN','var')
    meta.amp=zeros(size(hM,2),1);
    jj=1;
    for ii=1:size(ampLIN,1)
        for kk=1:IRnrLIN(ii)
            meta.amp(jj)=ampLIN(ii);
            jj=jj+1;
        end
    end
end

stimPar.Version='2.0.0';
clear subjectID ii jj kk posLIN itemidxLIN latLIN toaLIN ampLIN IRnrLIN itemnrLIN;
