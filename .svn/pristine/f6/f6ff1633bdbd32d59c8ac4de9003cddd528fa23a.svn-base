function Obj=AA_ConvertARI2SOFA(hM,meta,stimPar)
% OBJ=AA_ConvertARI2SOFA(hM,meta,stimPar) converts the HRTFs described in hM, meta, and
% stimPar (see ARI HRTF format) to a SOFA object.
%

% Copyright (C) 2012-2021 Acoustics Research Institute - Austrian Academy of Sciences;
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "License")
% You may not use this work except in compliance with the License.
% You may obtain a copy of the License at: http://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the License for the specific language governing  permissions and limitations under the License. 

% Last update: Michael Mihocic 30.08.2013

%% Get an empty conventions structure
if size(hM,3)==2, 
  Obj = SOFAgetConventions('SimpleFreeFieldHRIR');
else
  Obj = SOFAgetConventions('GeneralFIR');
end

%% Fill data with data
Obj.Data.IR = shiftdim(hM,1); % hM is [N M R], data.IR must be [M R N]
Obj.Data.SamplingRate = stimPar.SamplingRate;
if size(hM,3)~=2, Obj.Data.Delay=zeros(1,size(hM,3)); end

%% Fill with attributes
if isfield(stimPar, 'SubjectID'), Obj.GLOBAL_ListenerShortName = stimPar.SubjectID; end
if isfield(stimPar,'Application')
    if isfield(stimPar.Application,'Name'), Obj.GLOBAL_ApplicationName = stimPar.Application.Name; end
    if isfield(stimPar.Application,'Version'), Obj.GLOBAL_ApplicationVersion = stimPar.Application.Version; end
end

%% Fill the mandatory variables
  % SimpleFreeFieldHRIR 0.2
    % Obj.ListenerPosition = [1.2 0 0];
    % Obj.ListenerView = [-1 0 0];
    % Obj.ListenerUp = [0 0 1];
    % Obj.ListenerRotation = [meta.pos(1:size(hM,2),1) meta.pos(1:size(hM,2),2) zeros(size(hM,2),1)];
  % SimpleFreeFieldHRIR 0.3
if size(hM,3)~=2, Obj.ReceiverPosition=repmat([0 0 0],size(hM,3),1); end
Obj.ListenerPosition = [0 0 0];
if size(hM,3)==2, Obj.ListenerView = [1 0 0]; end
if size(hM,3)==2, Obj.ListenerUp = [0 0 1]; end
Obj.SourcePosition = [meta.pos(1:size(hM,2),1) meta.pos(1:size(hM,2),2) 1.2*ones(size(hM,2),1)];

%% Fill with some additional data
Obj.GLOBAL_History='Created with AMTatARI';
if size(meta.pos,2)>2, Obj=SOFAaddVariable(Obj,'MeasurementSourceAudioChannel','M',meta.pos(1:size(hM,2),3)); end
Obj=SOFAaddVariable(Obj,'MeasurementAudioLatency','MR',meta.lat);

Obj.GLOBAL_License='Creative Commons Attribution-ShareAlike 3.0 Unported License';
Obj.GLOBAL_Organization='Acoustics Research Institute, Austrian Academy of Sciences';
Obj.GLOBAL_DatabaseName = 'ARI';
Obj.GLOBAL_References = 'Majdak, P., Goupell, M. J., and Laback, B. (2010). "3-D localization of virtual sound sources: effects of visual environment, pointing method, and training," Atten Percept Psychophys 72, 454-469.';
Obj.GLOBAL_Title = 'HRTF C';
Obj.GLOBAL_ReceiverDescription = 'In-the-ear microphones (KE-4-211-2, Sennheiser) connected via amplifiers (FP-MP1, RDL) to the digital audio interface (ADI-8, RME). Left and right ears correspond to the first and second receivers, respectively.';
Obj.GLOBAL_Origin ='Acoustically measured';
Obj.GLOBAL_Comment = 'In-the-ear microphone measurement with blocked-ear canal method.';
Obj.GLOBAL_Comment = SOFAappendText(Obj,'GLOBAL_Comment','Subject was seated in the center of the arc and wore microphones. A 1728.8-ms exponential frequency sweep (50 to 20000 Hz) used. Raw data were equalized with the loudspeaker-microphone reference measurement in the frequency range from 50 to 18000 Hz, then temporally windowed.');
Obj.GLOBAL_AuthorContact = 'piotr@majdak.com;michael.mihocic@oeaw.ac.at';
Obj.GLOBAL_RoomDescription = 'Customized IAC semi-anechoic room  (6.2m × 5.5m × 2.9m)';
Obj.GLOBAL_RoomLocation = 'Vienna, Austria';
Obj.GLOBAL_SourceDescription = 'Twenty-two loudspeakers (the variation in the frequency response was +/- 4 dB in the range from 200 to 16000 Hz) were mounted at fixed elevations from 210º to 80º. They were driven by amplifiers adapted from Edirol MA-5D active loudspeaker systems. The loudspeakers and the arc were covered with acoustic damping material to reduce the intensity of reflections. The total harmonic distortion of the loudspeaker-amplifier systems was on average 0.19% (at 63-dB SPL and 1 kHz).';
Obj.GLOBAL_EmitterDescription = 'VIFA 10 BGS';

%% Update dimensions
Obj=SOFAupdateDimensions(Obj);
