function AA_SOFAstart

% AA_SOFAstart      - start SOFA
%
% 
% AA_SOFAstart adds the subfolder SOFA to MATLAB paths and runs SOFAstart if
%   SOFA was not started yet.
%
% Michael Mihocic 28.05.2013

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence. 
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
% See the Licence for the specific language governing  permissions and limitations under the Licence. 

if exist('SOFAstart','file')==0
    addpath([fileparts(which('AA_SOFAstart')) filesep 'SOFA' filesep 'API_MO']);
end
SOFAstart;