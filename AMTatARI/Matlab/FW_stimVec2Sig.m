function [stimSig, els] = FW_stimVec2Sig(stimVec, stimPar, ~)

% convert the electric stimulation matrix to signals. Used by FW_ShowStimulus

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

switch stimPar.GenMode
    case 0      % RIB
        N = sum(stimVec(:,5));    % number of samples
        % if modifier is given set the corresponding electrodes to 0
        if size(stimVec,2)==6
            idx= stimVec(:,6)==2;
            stimVec(idx,1)=0;
        end
        els=unique(stimVec(:,1));   % vector of electrodes
        els=els(els~=0);  % remove gaps
        els=sort(els);
        stimSig = zeros(N,length(els),'int8');   % signal, empty
        idx=cumsum([1; stimVec(1:end-1,5)]);    % index of the begin of every pulse in signal
        for ii=1:length(els)
            elidx=find(stimVec(:,1)==els(ii));    % index of pulses for electrode els(ii)
            phdur=stimVec(elidx,4);
            sigidx=idx(elidx);
            if length(unique(phdur))==1
                % only one value of phase duration for all pulses on this electrode
                elmat=int32(reshape(repmat(sigidx, 1, phdur(1)) + repmat(0:phdur(1)-1, length(sigidx),1),[],1)); % create a pulse (width: phdur(1))
                amp=reshape(repmat(int8(stimVec(elidx,2)), 1, phdur(1)),[],1); % get amplitudes and resize to pulse width
                stimSig(elmat,ii)=amp;  % copy amps for this electrode: positive phase
                elmat=elmat+phdur(1);
                stimSig(elmat,ii)=-amp;  % copy amps for this electrode: negative phase
            else
                error('Variable phase duration not implemented yet...');
            end
        end
        
        
        % for ii=1:length(els)
        %   if sum(abs(stimSig(:,ii)))==0
        %     els(ii)=-els(ii);
        %   end
        % end
        
    case {3,4}      % RIB2
        N = sum(stimVec(:,1));    % number of samples
        % if modifier is given set the corresponding electrodes to 0
        if size(stimVec,2)==5
            idx= stimVec(:,4)==0;
            stimVec(idx,3)=0;
        end
        els=unique(stimVec(:,3));   % vector of electrodes
        els=els(els~=0);  % remove gaps
        els=sort(els);
        stimSig = zeros(N,length(els),'int8');   % signal, empty
        idx=cumsum([1; stimVec(1:end-1,1)]);    % index of the begin of every pulse in signal
        for ii=1:length(els)
            elidx=find(stimVec(:,3)==els(ii));    % index of pulses for electrode els(ii)
            phdur=stimVec(elidx,2);
            sigidx=idx(elidx);
            if length(unique(phdur))==1
                % only one value of phase duration for all pulses on this electrode
                elmat=int32(reshape(repmat(sigidx, 1, phdur(1)) + repmat(0:phdur(1)-1, length(sigidx),1),[],1)); % create a pulse (width: phdur(1))
                amp=reshape(repmat(int8(stimVec(elidx,4)), 1, phdur(1)),[],1); % get amplitudes and resize to pulse width
                stimSig(elmat,ii)=amp;  % copy amps for this electrode: positive phase
                elmat=elmat+phdur(1);
                stimSig(elmat,ii)=-amp;  % copy amps for this electrode: negative phase
            else
                error('Variable phase duration not implemented yet...');
            end
        end
end


