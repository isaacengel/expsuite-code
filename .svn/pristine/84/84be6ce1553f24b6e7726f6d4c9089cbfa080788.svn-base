function [Obj, meta, stimPar] = AA_SOFAload(filename)

% [Obj, meta] = AA_SOFAload(filename)      - load HRTF in SOFA format
%
% AA_SOFAload loads a SOFA file
% 
% Input:
%     filename: Input file (SOFA format)
% 
% Output:
%     Obj:      HRTF data matrix
%     meta:     HRTF meta data
%
% Michael Mihocic 29.05.2013
%   Last update: 06.2014 by Michael Mihocic
% 

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence. 
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
% See the Licence for the specific language governing  permissions and limitations under the Licence. 


Obj = SOFAload(filename); % load SOFA file but ...
[~, meta, stimPar]=AA_SOFAconvertSOFA2ARI(Obj); % ... keep the Obj data und just convert the meta and stimPar data