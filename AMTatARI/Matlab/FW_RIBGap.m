function [stim, x]= FW_RIBGap(stimPar, Gap)

% FW_RIBGap - generate a gap matrix for a RIB stimulation file.
%
% stim = FW_RIBGap(stimPar, Gap);
%
% RIB:
% stim's columns are: [1 1 PhDurMin 0 mdist 2]
% where:
%   Gap >= 33
%   PhDurMin = 16
%   32 < mdist < 1025
%
% RIB2:
% stim's columns are: [Gap, PhDurMin, 1, 0, 0]
% where: 
%   Gap >= 33
%   PhDurMin = 16


% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

switch stimPar.GenMode
    case {0}  % electrical RIB
        
        PulsePerMax = 1024;
        PhDurMin = 16;
        
        if Gap < 2*PhDurMin+1
            error (['Gap: gap duration smaller than ' num2str(round((2*PhDurMin+1)*stimPar.TimeBase)) 'us is not allowed']);
        end
        
        if Gap <= PulsePerMax
            % append a single gap
            stim = [1 1 0 PhDurMin Gap 2];
        else
            % multiple gaps necessary
            GapNr = fix(Gap / PulsePerMax) - 1;
            Rest = Gap - GapNr * PulsePerMax;
            Rest1 = fix(Rest / 2);
            Rest2 = Rest - Rest1;
            % attach the two halfs of the rest of gap
            stim = [1 1 0 PhDurMin Rest1 2; 1 1 0 PhDurMin Rest2 2];
            % insert all full gaps
            if GapNr > 0
                stim = [stim; repmat([1 1 0 PhDurMin PulsePerMax 2], GapNr,1)];
            end
        end
        
        
    case {3,4}  % electrical RIB2
        PhDurMin = 16;      % for Pulsar implants PhDurMin is 15, however when a gap is created phase duration has no influence as long as it is > PhDurMin
%         MinDist = 33;
        
%         if Gap < MinDist
%             error (['Gap: gap duration smaller than ' num2str(round(MinDist * stimPar.TimeBase)) 'us is not allowed']);
%         end
        
        stim = [Gap, PhDurMin, 0, 0, 0];
end

x=size(stim,1);
