function Obj=AA_SOFAsaveSimpleFreeFieldHRIRLAS(filename,ObjSource,meta,stimPar)

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
Obj.Data.SamplingRate_Units='Hertz';

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

% LAS speaker positions
if any(meta.pos(:,2) > 90) % check for non-updated meta.pos (Channel ID in 2nd column)
    positions = table2array(readtable('SpeakerPositionsLAS.csv','HeaderLines',1));
    N_items= length(unique(meta.itemidx));
    meta.pos(:,1:2) = repmat(positions(:,1:2),N_items,1);
    meta.pos(:,1) = mod(meta.pos(:,1) + meta.azimuth + 360, 360);
    
    % filter positions: spacing > 0.01m
    [x,y,z] = sph2cart(deg2rad(meta.pos(:,1)), deg2rad(meta.pos(:,2)), 1.2);
    positions_cart = round([x,y,z],2);
    [~, unique_idx, ~] = unique(positions_cart,'stable','rows');
    
    % update meta/Obj Data
    meta.pos = meta.pos(unique_idx,:);
    meta.itemidx = meta.itemidx(unique_idx);
    meta.lat = meta.lat(unique_idx,:);
    meta.amp = meta.amp(unique_idx);
    meta.azimuth = meta.azimuth(unique_idx);
    meta.freq = meta.freq(unique_idx);
    meta.description = meta.description(unique_idx);
    ObjSource.Data.IR = ObjSource.Data.IR(unique_idx,:,:);
    Obj.Data.IR = Obj.Data.IR(unique_idx,:,:);
end

Obj.ListenerPosition = [0 0 0];
Obj.ListenerView = [1 0 0];
Obj.ListenerUp = [0 0 1];
Obj.SourcePosition = [meta.pos(1:size(ObjSource.Data.IR,1),1) meta.pos(1:size(ObjSource.Data.IR,1),2) 1.2*ones(size(ObjSource.Data.IR,1),1)];

%% Fill with some additional data
Obj.GLOBAL_History='Created with AMTatARI';
if size(meta.pos,2)>2, Obj=SOFAaddVariable(Obj,'MeasurementSourceAudioChannel','M',meta.pos(1:size(ObjSource.Data.IR,1),3)); end
Obj=SOFAaddVariable(Obj,'MeasurementAudioLatency','MR',meta.lat);

Obj.GLOBAL_History='Measured and created with AMTatARI';
Obj.GLOBAL_License='Creative Commons Attribution-ShareAlike 3.0 Unported License';
Obj.GLOBAL_Organization='Acoustics Research Institute, Austrian Academy of Sciences';
Obj.GLOBAL_DatabaseName = 'ARI';
Obj.GLOBAL_References = 'Majdak, P., Goupell, M. J., and Laback, B. (2010). "3-D localization of virtual sound sources: effects of visual environment, pointing method, and training," Atten Percept Psychophys 72, 454-469.';
Obj.GLOBAL_Title = 'HRTF C';
Obj.GLOBAL_ReceiverDescription = 'In-the-ear microphones (KE-4-211-2, Sennheiser) connected via amplifiers (FP-MP1, RDL) to the digital audio interface (ADI-8, RME). Left and right ears correspond to the first and second receivers, respectively.';
Obj.GLOBAL_Origin ='Acoustically measured';
Obj.GLOBAL_Comment = 'In-the-ear microphone measurement with blocked-ear canal method.';
Obj.GLOBAL_Comment = SOFAappendText(Obj,'GLOBAL_Comment','Subject was seated in the center of the sphere and wore microphones. A 6-s exponential frequency sweep (20 to 20000 Hz) used. Raw data were equalized with the loudspeaker-microphone reference measurement in the frequency range from 20 to 20000 Hz, then temporally windowed.');
Obj.GLOBAL_AuthorContact = 'piotr@majdak.com;michael.mihocic@oeaw.ac.at';
Obj.GLOBAL_RoomDescription = 'Semi-anechoic room  (3.2m × 3.2m × 3.5m)';
Obj.GLOBAL_RoomLocation = 'Vienna, Austria';
Obj.GLOBAL_SourceDescription = 'Nintey-one loudspeakers (the variation in the frequency response was +/- 3 dB in the range from 90 to 33000 Hz) were mounted at fixed positions on the sphere with a distance of 17.9° ± 4.2° (max: 23.8°).';
Obj.GLOBAL_EmitterDescription = 'KEF E301';

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