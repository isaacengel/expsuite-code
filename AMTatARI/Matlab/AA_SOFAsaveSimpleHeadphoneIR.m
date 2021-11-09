function Obj=AA_SOFAsaveSimpleHeadphoneIR(filename,ObjSource,meta,stimPar)

% Obj=AA_SOFAsaveSimpleHeadphoneIR(filename,ObjSource,meta,stimPar)      - save HRTF in SOFA format
%
% 
% AA_SOFAsaveSimpleHeadphoneIR converts hM, meta and stimPar variables to SOFA format
%     and saves the data to filename in SOFAsaveSimpleHeadphoneIR convention.
% 
% Input:
%     filename:  Output file (SOFA format)
%     ObjSource: HRTF data matrix
%     meta:      HRTF meta data
%     stimPar:   HRTF stimulation parameter
%
% Outout:
%     Obj:      SOFA object
% Michael Mihocic 17.04.2020
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
Obj = SOFAgetConventions('SimpleHeadphoneIR','m');

%% Fill data with data
Obj.Data.IR = ObjSource.Data.IR;
Obj.Data.SamplingRate = stimPar.SamplingRate;
Obj.Data.SamplingRate_Units='Hertz';
% Obj.Data.Delay=zeros(1,size(Obj.Data.IR,2));
if isfield(ObjSource.Data,'Delay') 
  Obj.Data.Delay = ObjSource.Data.Delay;
else
  Obj.Data.Delay = [0 0];
end

%% Fill with attributes
if isfield(stimPar, 'SubjectID'), Obj.GLOBAL_ListenerShortName = stimPar.SubjectID; end
Obj.GLOBAL_ListenerDescription='Human listener';

%% Fill the mandatory variables
% if size(ObjSource.Data.IR,2) == 2 % default, 2 receivers
    Obj.ReceiverPosition=[0,0.09,0;0,-0.09,0];
% else
%     Obj.ReceiverPosition=repmat([0 0 0],size(ObjSource.Data.IR,2),1);
% end
Obj.ListenerPosition = [0 0 0];
% Obj.SourcePosition = [meta.pos(1:size(ObjSource.Data.IR,1),1) meta.pos(1:size(ObjSource.Data.IR,1),2) 1.2*ones(size(ObjSource.Data.IR,1),1)];
Obj.SourcePosition = Obj.ListenerPosition;
Obj.EmitterPosition = Obj.ReceiverPosition;

%% Fill with some additional data
if size(meta.pos,2)>2, Obj=SOFAaddVariable(Obj,'MeasurementSourceAudioChannel','M',meta.pos(1:size(ObjSource.Data.IR,1),3)); end
Obj=SOFAaddVariable(Obj,'MeasurementAudioLatency','MR',meta.lat);
Obj=SOFAaddVariable(Obj,'ItemIndex','M',meta.itemidx);
% if isfield(meta,'azimuth'), Obj=SOFAaddVariable(Obj,'ItemAzimuth','M',meta.azimuth); end
% if isfield(meta,'freq'), Obj=SOFAaddVariable(Obj,'ItemFreq','M',meta.freq); end
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
Obj.GLOBAL_Title = 'HPIR';
Obj.GLOBAL_ReceiverDescription = 'In-the-ear microphones (KE-4-211-2, Sennheiser) connected via amplifiers (FP-MP1, RDL) to the digital audio interface (ADI-8, RME). Left and right ears correspond to the first and second receivers, respectively.';
Obj.GLOBAL_Origin ='Acoustically measured';
Obj.GLOBAL_Comment = 'In-the-ear microphone measurement with blocked-ear canal method.';
Obj.GLOBAL_Comment = SOFAappendText(Obj,'GLOBAL_Comment','A 1728.8-ms exponential frequency sweep (50 to 20000 Hz) used.');
Obj.GLOBAL_Comment = SOFAappendText(Obj,'GLOBAL_Comment','Between each measurement, the headphones were took down and placed back on the head');
Obj.GLOBAL_AuthorContact = 'piotr@majdak.com;michael.mihocic@oeaw.ac.at';
Obj.GLOBAL_RoomDescription = 'Customized IAC semi-anechoic room  (6.2m × 5.5m × 2.9m)';
Obj.GLOBAL_RoomLocation = 'Vienna, Austria';
Obj.GLOBAL_SourceDescription = 'Over-ear open headphones';
Obj.GLOBAL_SourceManufacturer = 'Sennheiser';
Obj.GLOBAL_SourceModel = 'HD 580';
Obj.GLOBAL_SourceURI = '';
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
% Obj.GLOBAL_Organization = 'Acoustics Research Institute, Austrian Academy of Sciences'; 
% Obj.GLOBAL_AuthorContact = 'piotr@majdak.com;michael.mihocic@oeaw.ac.at';

%% Update dimensions
Obj=SOFAupdateDimensions(Obj);

Obj=SOFAsave(filename, Obj, 1); % Save SOFA file

% stimPar.WorkDir=TempWorkDir; % restore original stimPar WorkDir folder name ???