function Obj=AA_SOFAsaveGeneralFIRLAS(filename,ObjSource,meta,stimPar)

% Obj=AA_SOFAsaveGeneralFIR(filename,ObjSource,meta,stimPar)      - save HRTF in SOFA format
%
% 
% AA_SOFAsaveGeneralFIR converts hM, meta and stimPar variables to SOFA format
%     and saves the data to filename in SimpleFreeFieldHRIR convention.
% 
% Input:
%     filename: Output file (SOFA format)
%     ObjSource: HRTF data matrix
%     meta:     HRTF meta data
%     stimPar:  HRTF stimulation parameter
%
% Outout:
%     Obj:      SOFA object
% Michael Mihocic 29.05.2013
% Last update: Michael Mihocic 17.04.2020, minor bugs fixed
% 

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence. 
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
% See the Licence for the specific language governing  permissions and limitations under the Licence. 

% TempWorkDir=stimPar.WorkDir; % don't save WorkDir in stimPar
stimPar.WorkDir=''; % clear original folder name
        
%% Get an empty conventions structure
Obj = SOFAgetConventions('GeneralFIR');

%% Fill data with data
Obj.Data.IR = ObjSource.Data.IR;
Obj.Data.SamplingRate = stimPar.SamplingRate;
Obj.Data.SamplingRate_Units='Hertz';
Obj.Data.Delay=zeros(1,size(Obj.Data.IR,2));

%% Fill with attributes
if isfield(stimPar, 'SubjectID'), Obj.GLOBAL_ListenerShortName = stimPar.SubjectID; end
% if isfield(stimPar,'Application')
%     if isfield(stimPar.Application,'Name'), Obj.GLOBAL_ApplicationName = stimPar.Application.Name; end
%     if isfield(stimPar.Application,'Version'), Obj.GLOBAL_ApplicationVersion = stimPar.Application.Version; end
% end

%% Fill the mandatory variables
% Add LAS speaker positions
if any(meta.pos(:,2) > 90) % check for non-updated meta.pos (Channel ID in 2nd column)
    positions = table2array(readtable('SpeakerPositionsLAS.csv','HeaderLines',1));
    N_items= length(unique(meta.itemidx));
    meta.pos(:,1:2) = repmat(positions(:,1:2),N_items,1);
    meta.pos(:,1) = mod(meta.pos(:,1) + meta.azimuth + 360, 360);
end

Obj.ReceiverPosition=repmat([0 0 0],size(ObjSource.Data.IR,2),1);
Obj.ListenerPosition = [0 0 0];
Obj.SourcePosition = [meta.pos(1:size(ObjSource.Data.IR,1),1) meta.pos(1:size(ObjSource.Data.IR,1),2) 1.2*ones(size(ObjSource.Data.IR,1),1)];

%% Fill with some additional data
if size(meta.pos,2)>2, Obj=SOFAaddVariable(Obj,'MeasurementSourceAudioChannel','M',meta.pos(1:size(ObjSource.Data.IR,1),3)); end
Obj=SOFAaddVariable(Obj,'MeasurementAudioLatency','MR',meta.lat);
Obj=SOFAaddVariable(Obj,'ItemIndex','M',meta.itemidx);
if isfield(meta,'azimuth'), Obj=SOFAaddVariable(Obj,'ItemAzimuth','M',meta.azimuth); end
if isfield(meta,'freq'), Obj=SOFAaddVariable(Obj,'ItemFreq','M',meta.freq); end
if isfield(meta,'amp'), Obj=SOFAaddVariable(Obj,'ItemAmp','M',meta.amp); end
% if isfield(meta,'description'), Obj=SOFAaddVariable(Obj,'ItemDescription','MS',meta.description); end
if isfield(meta,'description') % existing description field? 
    if min(cellfun('isempty',meta.description))==0  % at least one field not empty
        Obj=SOFAaddVariable(Obj,'ItemDescription','MS',meta.description);
    end
end

%% Edit with metadata
Obj.GLOBAL_History='Measured and created with AMTatARI';
Obj.GLOBAL_License='Creative Commons Attribution-ShareAlike 3.0 Unported License';
Obj.GLOBAL_Organization='Acoustics Research Institute, Austrian Academy of Sciences';
Obj.GLOBAL_DatabaseName = 'ARI';
Obj.GLOBAL_References = '';
Obj.GLOBAL_Title = 'Unknown';
Obj.GLOBAL_ReceiverDescription = '';
Obj.GLOBAL_Origin ='Acoustically measured';
Obj.GLOBAL_Comment = '';
Obj.GLOBAL_AuthorContact = 'piotr@majdak.com;michael.mihocic@oeaw.ac.at';
Obj.GLOBAL_RoomDescription = 'Semi-anechoic room  (3.2m × 3.2m × 3.5m)';
Obj.GLOBAL_RoomLocation = 'Vienna, Austria';
Obj.GLOBAL_SourceDescription = '';
Obj.GLOBAL_EmitterDescription = '';

% set obligatory metadata
% Obj.GLOBAL_DatabaseName = 'ARI';     
if isfield(stimPar,'Application')
  Obj.GLOBAL_ApplicationName = stimPar.Application.Name;
  Obj.GLOBAL_ApplicationVersion = stimPar.Application.Version;
else
  Obj.GLOBAL_ApplicationName = 'AMTatARI';
  Obj.GLOBAL_ApplicationVersion = stimPar.Version;
end

%% Update dimensions
Obj=SOFAupdateDimensions(Obj);

Obj=SOFAsave(filename, Obj, 1); % Save SOFA file

% stimPar.WorkDir=TempWorkDir; % restore original stimPar WorkDir folder name ???