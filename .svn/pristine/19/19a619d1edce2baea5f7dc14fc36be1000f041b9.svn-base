function [stimNew, stimParNew] = FW_AppendCISPulseTrain(stimVec, stimPar, ElMat, PulseNr, PulsePer, offset, Strat)

% Append a interleaved pulse train with several electrodes similar to CIS strategy to stimVec.
%
% [stimOut, stimPar] = FW_AppendCISPulseTrain(stimVec, stimPar, ElMat, PulseNr,PulsePer, offset, Strat)
%
% Use [] for any optional parameter. The non given parameter will be read from stimPar.
% ElMat is a matrix containing data for each electrode in a row. Columns of ElMat are:
%    [ EL AMP RANGE PHDUR Val1 Val2 ]
%
% In electrical GenMode AMP is in current units.
% In acoustical GenMode AMP is in dB, RANGE is ignored and EL points to the associated freqPar.
% PulseNr gives the number of pulses for each electrode. PulsePer is the pulse period in time units
% for each electrode. Offset shifts the stimulus by given number of samples.
%
% Optional, using Strat you can choose the stimulation strategy. Only one strategy
% was implemeted until now (Strat=0): distribute all pulses uniformly within the pulse period.
%
% Val1 and Val2 are ignored, nonetheless they must be set to zero.

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

% v1.0 10.11.2003 Piotr Majdak
% 18.04.2013: Electrical RIB2 added, Katharina Egger

fs = stimPar.SamplingRate;

if isempty(ElMat)
    return;
end
if size(ElMat,2) ~= 6
    error('ElMat must be a matrix with 6 columns.');
end
if isempty(PulseNr)
    PulseNr = stimPar.PulseNr;
end
if isempty(PulsePer)
    PulsePer = stimPar.PulsePeriod;
end
if ~exist('Strat','var')
    Strat = 0;
elseif isempty(Strat)
    Strat = 0;
end
if Strat ~= 0
    error('Only Strat=0 implemented until now...');
end

nn = size(ElMat,1);     % number of electrodes
switch Strat
    case 0   % divide the PulsePer equdistant, distribute any rounding uniformly
        summ=PulsePer;
        for ii = 1:nn
            x = round(summ / (nn - ii+1));
            summ = summ - x;
            if ElMat(ii,4) == 0
                ElMat(ii,4) = stimPar.PhDur;
            end
            if ElMat(ii,1) < 1
                error('EL must be a positive, integer value');
            end
            % save PulsePer for this EL
            ElMat(ii,5) = max([x 2 * ElMat(ii,4) + 1]); % pulse per. smaller 2*PhDur+1 not allowed
        end
end

switch stimPar.GenMode
    case 0  % electrical RIB
        % create offset
        if offset ~= 0
            gap = FW_RIBGap(stimPar, offset);
        else
            gap = [];
        end
        % pulses for each electrode
        pulse = [];
        for ii=1:nn
            pulse = [pulse; FW_RIBPulse(stimPar, ElMat(ii,1),ElMat(ii,2),ElMat(ii,3),ElMat(ii,4),ElMat(ii,5));];
        end
        % create stimulation sequence
        stimNew = [stimVec; gap; repmat(pulse, PulseNr, 1)];
        stimParNew = stimPar;
        
    case 1  % acoustical
        % create single pulses for each electrode
        pulse=zeros(PulsePer*(PulseNr+1), nn);
        po=0; % pulse offset
        for ii=1:nn
            pulse(:,ii) = [ zeros(po,1); ...
                repmat([ones(ElMat(ii,4),1)*(10.^(ElMat(ii,2)/20)); zeros(PulsePer-ElMat(ii,4),1);],PulseNr,1); ...
                zeros(PulsePer-po,1)];
            po=po+ElMat(ii,5);
        end
        % generate pulse trains for each electrode
        %stim = repmat(pulse, PulseNr, 1);
        % wanna bandpass filtered pulse train?
        firstEl = min(ElMat(:,1));
        lastEl = max(ElMat(:,1));
        if isfield(stimPar,'freqPar')
            if lastEl <= length(stimPar.freqPar.Bandwidth)
                % only if freqPar for each electrode is given
                if prod(stimPar.freqPar.Bandwidth) ~= 0 && sum(stimPar.freqPar.Bandwidth(firstEl:lastEl)<fs/2) == lastEl-firstEl+1
                    pulse=FW_FilterPulses(pulse,stimPar.freqPar.CenterFreq,stimPar.freqPar.Bandwidth,fs);
                end
            end
        end
        % sum each electrode stimulus
        stim=sum(pulse(1:PulseNr*PulsePer,:)')';
        % wanna fade?
        if stimPar.FadeIn ~= 0 || stimPar.FadeOut ~= 0
            stim = FW_fade(stim, PulsePer*PulseNr, stimPar.FadeIn, stimPar.FadeOut);
        end
        % append offset and stimulus to existing part
        stimNew = [stimVec; zeros(offset,1); stim];
        stimParNew = stimPar;
        
        
    case 2  % electrical NIC
        stimNew = stimVec;
        stimNew.electrodes = [stimNew.electrodes; repmat(ElMat(:,1), PulseNr,1)];
        stimNew.current_levels = [stimNew.current_levels; repmat(ElMat(:,2), PulseNr,1)];
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
        
        % pulses for each electrode
        pulse = [];
        for ii = 1:nn
            pulse = [pulse; [ElMat(ii,5), ElMat(ii,4), ElMat(ii,1), ElMat(ii,2), ElMat(ii,3)]];
        end
        
        % create stimulation sequence
        stimNew = [stimVec; gap; repmat(pulse, PulseNr, 1)];
        stimParNew = stimPar;
end

