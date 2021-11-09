function [stimVec, stimPar] = FW_Trigger(~, stimPar)
% Create a trigger signal that can be used as onset trigger for signal playback
%
% Input Parameter:
%   stimVec:    (not used)
%   stimPar:    stimulation parameter (eg. stimPar.SamplingRate)
% Output:
%   stimVec:    data stream to be assembled as audio file
%   stimPar:    (not modified)

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

fs=stimPar.SamplingRate; % sampling rate of the audio signal
fsd=1000;   % sampling rate of the trigger channel

%% Encode as binaury
stimVec=[ones(4,1); -ones(4,1)];

%% upsample to the audio sampling rate
stimVec=resample(stimVec, fs, fsd);
