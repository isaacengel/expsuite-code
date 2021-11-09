% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.


function hrtf_UpdateSOFAmetadata

% Source files and target file
files = dir('hrtf_M_*.sofa'); 

% Compression
compression=1;
% Convert data to datatype single?
convert2single=1;

% Start conversion
warning ('OFF','SOFA:upgrade'); % switch off warnings on upgrade the conventions
warning ('OFF','SOFA:save');    % switch off warnings on save

for ii=1:length(files) % for each file
	title=strrep(strrep(files(ii).name,'hrtf_M_',''),'.sofa','');
	switch title
		case 'hrtf C'
			title='HRTF';
			comment=[];
		case 'dtf C'
			title='DTF';
			comment='Directional transfer functions calculated according to Majdak et al. (2011)';
		otherwise
			title='Unknown';
			comment=[];
	end
		% Load
	Obj=SOFAload(files(ii).name);
		% Update
	Obj.GLOBAL_License='Creative Commons Attribution-ShareAlike 3.0 Unported License';
	Obj.GLOBAL_Organization='Acoustics Research Institute, Austrian Academy of Sciences';
	Obj.GLOBAL_Origin ='http://www.oeaw.ac.at/isf/hrtf';
	Obj.GLOBAL_AuthorContact = 'piotr@majdak.com;michael.mihocic@oeaw.ac.at';
	Obj.GLOBAL_RoomDescription = 'Customized IAC semi-anechoic room  (6.2m × 5.5m × 2.9m)';
	Obj.GLOBAL_RoomLocation = 'Vienna, Austria';
	Obj.GLOBAL_SourceDescription = 'Twenty-two loudspeakers (the variation in the frequency response was +/- 4 dB in the range from 200 to 16000 Hz) were mounted at fixed elevations from 210º to 80º. They were driven by amplifiers adapted from Edirol MA-5D active loudspeaker systems. The loudspeakers and the arc were covered with acoustic damping material to reduce the intensity of reflections. The total harmonic distortion of the loudspeaker-amplifier systems was on average 0.19% (at 63-dB SPL and 1 kHz).';
	Obj.GLOBAL_EmitterDescription = 'VIFA 10 BGS';

	Obj.GLOBAL_DatabaseName = 'ARI';
	Obj.GLOBAL_Title = title;
	Obj.GLOBAL_ListenerShortName='unknown';

	Obj.GLOBAL_References = 'Majdak, P., Goupell, M. J., and Laback, B. (2010). "3-D localization of virtual sound sources: effects of visual environment, pointing method, and training," Atten Percept Psychophys 72, 454-469.';
	Obj.GLOBAL_ReceiverDescription = 'In-the-ear microphones (KE-4-211-2, Sennheiser) connected via amplifiers (FP-MP1, RDL) to the digital audio interface (ADI-8, RME). Left and right ears correspond to the first and second receivers, respectively.';

	Obj.GLOBAL_Comment = 'In-the-ear microphone measurement with blocked-ear canal method.';
	Obj.GLOBAL_Comment = SOFAappendText(Obj,'GLOBAL_Comment','Subject was seated in the center of the arc and wore microphones. A 1728.8-ms exponential frequency sweep (50 to 20000 Hz) used. Raw data were equalized with the loudspeaker-microphone reference measurement in the frequency range from 300 to 18000 Hz, then cepstrally smoothed and temporally windowed.');
	if ~isempty(comment), Obj.GLOBAL_Comment = SOFAappendText(Obj,'GLOBAL_Comment',comment); end;

	Obj.GLOBAL_History = ['measurement,equalize,window,zero-padding (window),smooth cepstral,window' SOFAdefinitions('EOL') ...
												'DTFs calculated: CTF calculated, raw data cepstrally smoothed, temporally windowed.' ];

		% Backup old and save
	copyfile(files(ii).name,['~' files(ii).name],'f');
	delete(files(ii).name);
	SOFAsave(files(ii).name, Obj, compression);
end

