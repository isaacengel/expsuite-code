function [stimNew, stimParNew] = FW_AppendPulseTrain(stimVec, stimPar, amp, range, el, phdur, pulsenr, pulseper, offset)

% Append a straight pulse train to stimVec.
% [stimOut, stimPar] = FW_AppendPulseTrain(stimVec, stimPar, amp, range, el, phdur, pulsenr, pulseper, offset)
% Use [] for any optional parameter. The non given parameter will be read from stimPar.
% Parameter:
%   amp in dB

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

% v1.2 13.02.2017 input variables 'mode' and 'flag' removed, cause a crash
%   in applications and were not used
% v1.1 02.05.2016: Theresa Loss, Electric Vocoder option added
% v1.0 17.10.2003 Piotr Majdak
% 07.03.2006: Include dB FS to dB SPL offset Florian Wippel
% 18.04.2013: Electrical RIB2 added, Katharina Egger
        
fs = stimPar.SamplingRate;

if isempty(amp)
    amp = stimPar.Amp;
end
if isempty(range)
    range = stimPar.Range;
end
if isempty(el)
    el= stimPar.Electrode;
end
% if isempty(phdur)
%     phdur = stimPar.PhDur;
% end
if isempty(pulsenr)
    pulsenr = stimPar.PulseNr;
end
if isempty(pulseper)
    pulseper = stimPar.PulsePeriod;
end
if isempty(offset)
    offset = stimPar.Offset;
end
  
switch stimPar.GenMode
    case 0  % electrical RIB
        if offset ~= 0
            gap = FW_RIBGap(stimPar, offset);
        else
            gap = [];
        end
        pulse = FW_RIBPulse(stimPar, el,amp,range,phdur,pulseper);
        stimNew = [stimVec; gap; repmat(pulse, pulsenr, 1)];
        stimParNew = stimPar;
        
    case 1  % acoustical
        % generate pulse train
        pulse = [ones(phdur,1)*(10.^(amp/20)); zeros(pulseper-phdur,1)];
        stim = repmat(pulse, pulsenr, 1);
        % wanna bandpass filtered pulse train?
        if isfield(stimPar,'freqPar')
            if el <= length(stimPar.freqPar.Bandwidth)
                bw = stimPar.freqPar.Bandwidth(el);
                if bw ~= 0 && bw < (fs /2)
                    stim = FW_FilterPulses(stim, stimPar.freqPar.CenterFreq(el), bw, fs);
                end
            end
                  
            stim = stim * 10^(-stimPar.freqPar.SPLOffset(el)/20);
        end
        if stimPar.FadeIn ~= 0 || stimPar.FadeOut ~= 0
            stim = FW_fade(stim, pulseper*pulsenr, stimPar.FadeIn, stimPar.FadeOut);
        end
        stimNew = [stimVec; zeros(offset,1); stim];
        stimParNew = stimPar;
        
        
    case 2  % electrical NIC
        stimNew = stimVec;
        stimNew.electrodes = [stimNew.electrodes; el*ones(pulsenr,1)];
        stimNew.current_levels = [stimNew.current_levels; amp*ones(pulsenr,1)];
        stimParNew = stimPar;
        
    case {3,4}  % electrical RIB2
        % restrictions for legacy data streams
        switch stimPar.Device
            case 'C40P'
                PhDurMin = 16;
                MinDist = 33;
            case 'Pulsar'
                PhDurMin = 15;
                MinDist = 33;
            case 'Acoustic'  %hier noch Sinnvolles hin!
                PhDurMin = 15;
                MinDist = 33;
        end
        if phdur < PhDurMin
            error (['PhDur: phase duration smaller than ' num2str(round(PhDurMin * stimPar.TimeBase)) 'us is not allowed']);
        end
        if isempty(stimVec) && offset < MinDist     % for the very first pulse in a stm-file, offset must be at least minimum distance
            error (['Offset: offset smaller than ' num2str(round(MinDist * stimPar.TimeBase)) 'us is not allowed']);
        end        
        
        % create offset
        if offset ~= 0
            gap = FW_RIBGap(stimPar, offset);
        else
            gap = [];
        end
       
        
        % create pulse
        pulse = FW_RIBPulse(stimPar, el, amp, range, phdur, pulseper);
        
        % create stimulation sequence
        stimNew = [stimVec; gap; repmat(pulse, pulsenr, 1)];
        stimParNew = stimPar;
end




