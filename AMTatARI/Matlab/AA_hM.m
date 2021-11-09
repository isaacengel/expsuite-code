% Convert LIN structure to hM v3.0.1 (SOFA structure)
% 12.06.2019 Piotr Majdak: Processing of single record channels. 
%               gRecStream: number of record channels - 1
% 
% Last update: 17.04.2020 by Michael Mihocic: bug fixed when transferring
% amplitude values to meta data
%

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence. 
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
% See the Licence for the specific language governing  permissions and limitations under the Licence. 

Obj.Data.IR=reshape(hLIN,idxLIN(1,2),size(idxLIN,1),gRecStream+1);
if ndims(Obj.Data.IR)==2
    Obj.Data.IR(:,:,2)=0;
    Obj.Data.IR=shiftdim(Obj.Data.IR,1);
    Obj.Data.IR=Obj.Data.IR(:,1,:);
else
    Obj.Data.IR=shiftdim(Obj.Data.IR,1);
end

if exist('subjectID','var')
    stimPar.SubjectID=subjectID;
%     Obj.GLOBAL_ListenerShortName = stimPar.SubjectID; % SOFA
end

if exist('posLIN','var') % transfer *LIN to meta
    meta.pos=posLIN;
%     Obj.SourcePosition = [meta.pos(1:size(Obj.Data.IR,1),1) meta.pos(1:size(Obj.Data.IR,1),2) 1.2*ones(size(Obj.Data.IR,1),1)]; % SOFA
%     if size(meta.pos,2)>2, Obj.MeasurementSourceAudioChannel=meta.pos(1:size(Obj.Data.IR,1),3); end; % SOFA
end
if exist('itemidxLIN','var')
    meta.itemidx=itemidxLIN;
end
if exist('latLIN','var')
    meta.lat=latLIN;
%     Obj.MeasurementAudioLatency=meta.lat; % SOFA
end
if exist('toaLIN','var')
    meta.toa=toaLIN;
end

%% amplitude
if exist('ampLIN','var')
    meta.amp=zeros(size(Obj.Data.IR,1),1);
    jj=1;
    for ii=1:size(ampLIN,1)
        for kk=1:IRnrLIN(ii)
            meta.amp(jj)=ampLIN(ii);
            jj=jj+1;
        end
    end
end

%% azimuth
if exist('aziLIN','var')
    meta.azimuth=zeros(size(Obj.Data.IR,1),1);
    jj=1;
    for ii=1:size(aziLIN,1)
        for kk=1:IRnrLIN(ii)
            meta.azimuth(jj)=aziLIN(ii);
            jj=jj+1;
        end
    end
end

%% frequency
if exist('freqLIN','var')
    meta.freq=zeros(size(Obj.Data.IR,1),1);
    jj=1;
    for ii=1:size(freqLIN,1)
        for kk=1:IRnrLIN(ii)
            meta.freq(jj)=freqLIN(ii);
            jj=jj+1;
        end
    end
end

%% description
if exist('descLIN','var')
    meta.description=cell(size(Obj.Data.IR,1),1);
    jj=1;
    for ii=1:size(descLIN,2)
        for kk=1:IRnrLIN(ii)
            meta.description{jj}=descLIN{ii};
            jj=jj+1;
        end
    end
end

stimPar.Version='3.0.1';
clear subjectID ii jj kk posLIN itemidxLIN latLIN toaLIN ampLIN aziLIN freqLIN descLIN IRnrLIN itemnrLIN hM;
