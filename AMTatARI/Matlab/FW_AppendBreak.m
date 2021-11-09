function [stimNew, stimPar] = FW_AppendBreak(stimVec, stimPar, len)

% Append a break to stimVec
% [stimNew, stimPar] = FW_AppendBreak(stimVec, stimPar, len)
% Use [] for any optional parameter. The non given parameter will be read from stimPar.

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence. 
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
% See the Licence for the specific language governing  permissions and limitations under the Licence. 

% v1.0 17.10.2003 Piotr Majdak
% 18.04.2013: Electrical RIB2 added, Katharina Egger

if isempty(len)
    len = stimPar.PulsePeriod;
end

switch stimPar.GenMode
    case {0, 3}  % electrical RIB / RIB2
        stimNew = [stimVec; FW_RIBGap(stimPar, len)];
        
    case {1,4}  % acoustical
        stimNew = [stimVec; zeros(round(len),1)];
        
    case 2  % electrical NIC
        stimNew = stimVec;        
end
