function [stim, x] = FW_RIBPulse(stimPar, El, Amp, Range, PhDur, PulsePer)

% FW_RIBPulse - generate a sequence matrix for either RIB or RIB2 stimulation file.
%
% stim = FW_RIBPulse(stimPar, El, Amp,Range, PhDur, PulsePer);
%
% RIB:
% stim's columns are: [El Amp Range PhDur mdist modifier]
% where:
%   PhDur >= 16
%   2*PhDur+1 <= mdist <= 1024
%   modifier: 0 for pulse, 2 for a gap
%
% RIB2:
% stim's columns are: [PulsePer, PhDur, El, Amp, Range]
% where:
%   PhDur >= PhDurMin


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
        if PhDur < 16
            error (['PhDur: phase duration smaller than ' num2str(round(16*stimPar.TimeBase)) 'us is not allowed']);
        end
        
        if PulsePer <= PulsePerMax
            % no gap necessary
            stim = [El Amp Range PhDur PulsePer 0]; % 0...pulse
        else
            % gap(s) necessary
            PulseDur = 2 * PhDur + 1;
            Rest = mod(PulsePer - PulseDur, PulsePerMax);
            MDist = Rest + PulseDur;
            % can we attach the rest of gap to the pulse ?
            if MDist <= PulsePerMax
                % yes -> generate a longer pulse...
                stim = [El Amp Range PhDur MDist 0]; % 0...pulse
                % ...and the gaps
                GapNr = fix((PulsePer - PulseDur) / PulsePerMax);
                if GapNr ~= 0
                    stim = [stim; repmat([1 1 0 PhDur PulsePerMax 2], GapNr, 1)]; % 2...gap
                end
            else
                % no -> the rest of gap must be splited,
                Rest1 = fix(Rest / 2);
                Rest2 = Rest - Rest1;
                MDist = Rest1 + PulseDur;
                % attach half of it to the pulse and the other half of it to an extra gap
                stim = [El Amp Range PhDur MDist 0; 1 1 0 PhDur Rest2 2]; % pulse+gap
                % insert all other gaps
                GapNr = fix((PulsePer - PulseDur) / PulsePerMax);
                if GapNr ~= 0
                    stim = [stim; repmat([1 1 0 PhDur PulsePerMax 2], GapNr, 1)]; % 2...gap
                end
            end
        end        
    case {3,4}  % electrical RIB2
        switch stimPar.Device
            case 'C40P'
                PhDurMin = 16;
            case 'Pulsar'
                PhDurMin = 15;
            case 'Acoustic'  %hier noch Sinnvolles hin!
                PhDurMin = 15;
        end
%         if PhDur < PhDurMin
%             error (['PhDur: phase duration smaller than ' num2str(round(PhDurMin * stimPar.TimeBase)) 'us is not allowed']);
%         end
        
        stim = [PulsePer, PhDur, El, Amp, Range];        
end

x=size(stim,1);


