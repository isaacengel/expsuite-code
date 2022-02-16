function Obj=AA_SOFAsaveSimpleFreeFieldHRIRImperialCollege(filename,ObjSource,meta,stimPar)

% Obj=AA_SOFAsaveSimpleFreeFieldHRIR(filename,ObjSource,meta,stimPar)      - save HRTF in SOFA format
%
% 
% AA_SOFAsaveSimpleFreeFieldHRIR converts hM, meta and stimPar variables to SOFA format
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
Obj = SOFAgetConventions('SimpleFreeFieldHRIR');

%% Fill data with data
% Obj.Data.IR = shiftdim(hM,1); % hM is [N M R], data.IR must be [M R N]
Obj.Data.IR = ObjSource.Data.IR;
Obj.Data.SamplingRate = stimPar.SamplingRate;
Obj.Data.SamplingRate_Units='hertz';

if isfield(meta,'delay') && ~isempty(meta.delay)
    Obj.Data.Delay = meta.delay;
end

%% Fill with attributes
if isfield(stimPar, 'SubjectID'), Obj.GLOBAL_ListenerShortName = stimPar.SubjectID; end
% if isfield(stimPar,'Application')
%     if isfield(stimPar.Application,'Name'), Obj.GLOBAL_ApplicationName = stimPar.Application.Name; end
%     if isfield(stimPar.Application,'Version'), Obj.GLOBAL_ApplicationVersion = stimPar.Application.Version; end
% end

%% Fill the mandatory variables
if size(ObjSource.Data.IR,2) == 1 % only one channel
    Obj.ReceiverPosition = Obj.ReceiverPosition(1,:); % remove second channel
elseif size(ObjSource.Data.IR,2) > 2 % more than 2 channels, set all receiver positions to zero
    Obj.ReceiverPosition = repmat([0 0 0],size(ObjSource.Data.IR,2),1);
end
Obj.ListenerPosition = [0 0 0];
Obj.ListenerView = [1 0 0];
Obj.ListenerUp = [0 0 1];
Obj.SourcePosition = [meta.pos(1:size(ObjSource.Data.IR,1),1) meta.pos(1:size(ObjSource.Data.IR,1),2) meta.pos(1:size(ObjSource.Data.IR,1),3)]; % 1.2*ones(size(ObjSource.Data.IR,1),1)];

%% Fill with some additional data
Obj.GLOBAL_History='Created with AMTatARI';
if size(meta.pos,2)>2, Obj=SOFAaddVariable(Obj,'MeasurementSourceAudioChannel','M',meta.pos(1:size(ObjSource.Data.IR,1),3)); end
% Obj=SOFAaddVariable(Obj,'MeasurementAudioLatency','MR',meta.lat);

Obj.GLOBAL_History='Measured and created with AMTatARI';
Obj.GLOBAL_License='Creative Commons Attribution-ShareAlike 3.0 Unported License';
Obj.GLOBAL_Organization='Imperial College London';
Obj.GLOBAL_DatabaseName = 'AXD HRTF database';
Obj.GLOBAL_References = 'N/A';
Obj.GLOBAL_Title = 'HRTF C';
Obj.GLOBAL_ReceiverDescription = 'In-the-ear microphones (Knowles FG-23329-P07) connected via a RODE VXLR adapter to the digital audio interface (RME BabyFace Pro FS). Left and right ears correspond to the first and second receivers, respectively.';
Obj.GLOBAL_Origin ='Acoustically measured';
Obj.GLOBAL_Comment = 'In-the-ear microphone measurement with blocked-ear canal method.';
Obj.GLOBAL_Comment = SOFAappendText(Obj,'GLOBAL_Comment','Subject was seated in the center of the arc and wore microphones. A 500ms exponential frequency sweep (20 to 22000 Hz) used.');
%Obj.GLOBAL_Comment = SOFAappendText(Obj,'GLOBAL_Comment','Data were equalized with the loudspeaker-microphone reference measurement in the frequency range from 50 to 18000 Hz, then temporally windowed.');
Obj.GLOBAL_AuthorContact = 'l.picinali@imperial.ac.uk;isaac.engel@imperial.ac.uk';
Obj.GLOBAL_RoomDescription = 'Customized IAC semi-anechoic room  (6.2m × 5.5m × 2.9m)';
Obj.GLOBAL_RoomLocation = 'London, UK';
Obj.GLOBAL_SourceDescription = 'Twenty-three loudspeakers were mounted at fixed elevations from -45º to 225º. The loudspeakers and the arc were covered with acoustic damping material to reduce the intensity of reflections.';
Obj.GLOBAL_EmitterDescription = 'N/A';

% set obligatory variables
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