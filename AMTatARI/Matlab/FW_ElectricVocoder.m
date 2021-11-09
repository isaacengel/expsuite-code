function  FW_ElectricVocoder(stim,stimpar,range,phdur,VocType,srate_new,divFac,outputname)
%Function for calling different types of vocoders
%
%stim       = stimulation matrix
%range      = range information of CI
%phdur      = phase information, used if impact of phase duration is used 
%             for acoustic conversion
%VocType    = used vocoder
%srate_new  = acoustic sampling rate
%divFac     = division factor for noise vocoder
%outputname = name of wavefile
%
% v1.2   28.04.2016: Theresa Loss, error message changed, division factor
%                    format changed to double, removed silence problem
% v1.1   15.04.2016: Theresa Loss
%                     changes for ITDGaps method, ITDGaps is coded with '0' electrode,
%                     therefore some changes for MCL and THR had to be applied
% v1.0   14.04.2016: Theresa Loss

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.


if size(stim,2) == 1 && unique(stim) == 0   %create silence file
    wavedata = stim;
    audiowrite(outputname,wavedata,srate_new)
else

    %Convert format if in wrong order
    if (max(stim(:,1)) > 12 && size(stim,2) == 5)  %electrode not in first column, rotate matrix
        savem = stim;
        stim = [savem(:,3:5),savem(:,2),savem(:,1)];
        flag = zeros(size(savem(:,5)));
        stim = [stim,flag];       
        stim = stim(2:end,:);   %delete first row since there is a '0' in there
                                %for the electrode number

    elseif (max(stim(:,3)) < 12 && size(stim,2) == 6)  %CIS format
%         stim = stim;
    else
        error('specified matrix format needs to be converted')
    end

       
    %Get variables
    if length(divFac) > 1
        stimpar.DivisionFactor = str2num([num2str(divFac(1)),'.',num2str(divFac(2))]);
    else
        stimpar.DivisionFactor = divFac;
    end
        
    maxEl = max(stim(:,1));
    El = sort(unique(stim(:,1)));
    len = length(El);
    val = size(stim,2);


    %% Convert Amplitudes

    %Read amplitudes in double format
    ran = [str2num([num2str(range(1)),'.',num2str(range(2))]),...
        str2num([num2str(range(3)),'.',num2str(range(4))])...
        str2num([num2str(range(5)),'.',num2str(range(6))])...
        str2num([num2str(range(7)),'.',num2str(range(8))])]';

    if sum(ran == 0) > 0
        error('Range values not specified for amplitude conversion')
    end


    % %Consider impact of phase duration
    % phdur_min = phdur(1);
    % phdur_max = phdur(2);
    % 
    % 
    % if length(unique(stim(:,4))) > 1
    %     phdur_new = stim(:,4)./phdur_min .* stim(:,2);
    %     idx =  phdur_new <= phdur_max;
    %     stim(idx,4) = phdur_new;
    %      
    % end


    % Check MCL and convert to absolute values
    MCL = ran(stimpar.freqPar.Range+1)' .* (stimpar.freqPar.MCL +1);  
    THR = ran(stimpar.freqPar.Range+1)' .* (stimpar.freqPar.THR +1);

    % For ITDGaps, add MCL and THR value for virtual electrode!
    if any(El == 0)
        MCL = [MCL,MCL(end)];
        THR = [THR,THR(end)];
    end
    
    num = stim(:,1);
    num(num == 0) = length(MCL);   %for ITDGaps, MCL for electrode 0 does not exist
    
    %Check if any values are above MCL, normally does not happen anyway
    if stim(:,2) > MCL(num)'
        stim(:,2) = MCL(num)';
    end

    %Get range of CI signal
    Ma = zeros(length(MCL),1);
    Mi = zeros(length(MCL),1);
%     i = 0;
    
    for i = 1:len
        n = find(stim(:,1) == El(i));
        
         
        Ma(num(n)) =  max(ran(stim(n,3)+1) .*(stim(n,2)+1));
        Mi(num(n)) =  min(ran(stim(n,3)+1) .*(stim(n,2)+1));
        
        if (El(1) == 0)
            El(1) = 13;
            stim(n,1) = 13;
        end

        if Ma(El(i)) == Mi(El(i))   %if only one value is used set THR as lower bound
            Mi(El(i)) = THR(El(i));
        end
    end

%     fac = mag2db((Ma - Mi)./(MCL - THR)');

    %Get stimulation current
    stim(:,2) = ran(stim(:,3)+1) .* (stim(:,2)+1);  %range current step*(value+1)
    %hier überall neu 1 statt 3;)
    
    divid = (MCL(num)-THR(num))';
    divid(divid == 0) = 1000; %avoid division by zero
    stim(:,2) = (stim(:,2) - THR(num)')./divid; %convert range to [0,1]
    
    %Expansion
    stimpar.c = 800;
    stim(:,2) =  1/stimpar.c * ((1+stimpar.c).^stim(:,2)-1);
    
    %Convert to acoustic level
    peak =  1/stimpar.c * ((1+stimpar.c)-1); %1 anyway    
    
    stim(:,2) = stim(:,2) / peak;   
   

    %% Convert to "next" format 

    %Get same number of samples for each electrode
%     i = 0;
    N = zeros(length(El),1);
    for i = 1:length(El)
        N(i) = sum(stim(:,1) == El(i));
    end


    S = cell(len,1);

    stimOld = stim;  %save for distance correction

    %Make big matrix
    for i = 1:len
        idx = find(stim(:,1) == El(i));

        for k = 2:length(idx)    %Create distance to previous pulse, same chn
            stim(idx(k),5) = sum(stimOld(idx(k-1)+1:idx(k),5)); 
        end
        S{i} = stim(idx,:);         %save all levels       
    end

    clear stim;

    %If input is in RIB format, convert to RIB2 format!
%     imptype = 'old';
  
    for i = 1:len
        stim = S{i};

        if  any(stim(:,2)==0) || any(stim(:,6)==2)
            n1 = find(stim(:,2) == 0);
            n2 = find(stim(:,6) == 2);
            n = unique([n1;n2]);
            for ii = 1:length(n)
                idx = n(ii);
                if idx == 1
                    %if first pulse is zero, set amplitude zero
                    stim(idx,2) = 0;               
                elseif idx~=1 && idx~=size(stim,1)
                    % for all breaks within the pulse sequence (not at the 
                    % beginning nor at the end)

                    % add break duration to distance of subsequent pulse
                    stim(idx-1,5) = stim(idx-1,5) + stim(idx,5);   

                    % delete 'break pulse'
                    stim = stim([1:idx-1, idx+1:end],:);     

                    % removing a break (row) of stimmat results in lower 
                    %indices subsequent breaks
                    n = n - 1;        

                elseif idx == size(stim,1)
                    % remove break at the end of the pulse sequence
                    %stim = stim(1:end-1,:);
                    stim(idx-1,5) = stim(idx-1,5) + stim(idx,5);                
                    stim = stim([1:idx-1, idx+1:end],:);     
                end
            end
            % total number of pulses
            npulse = size(stim,1);
        elseif  all(stim(:,2)==0)||all(stim(:,6)==2)   % only breaks, no pulses        
                % add up all single breaks to one joined break
                breakdur = sum(stim(:,5));
                stim = [stim(1,1:4),breakdur,stim(1,6)];
                npulse = 0;
        end

        % control distance values
        % stim(:,5) ... distance to the next pulse (33..max)
        if min(stim(:,5)) < 33
            error( 'Illegal distance values were found in stimulation data ...matrix.' )
        end

        S{i} = stim;
    end


    %% Choose Vocoder

    %get sampling rates
    srate_old = stimpar.SamplingRate;

    lower = 300;
    upper = 8500;

    if  strcmp(VocType,'GET')
         out = FW_GETVocoderEl(S,srate_old,srate_new,El,lower,upper,...
             VocType,stimpar.DivisionFactor); 

    elseif strcmp(VocType,'Noise')
         out = FW_NoiseVocoderEl(S,srate_old,srate_new,El,lower,upper,...
             stimpar,VocType);     

    else 
        error('Specified vocoder type not implemented')
    end

%     %% Pre-emphasis reverse
%     [b a]=butter(1,1200/(srate_new*0.5),'low'); 
%     wavedata=filter(b,a,out);
%     wavedata = wavedata/max(abs(wavedata))* max(abs(out)); % Scale Amplitude
     wavedata = out;
 
    %% Write data to wav-file
    if sum(find(abs(wavedata)>1))
        error(['Clipping, maximum value was ',num2str(max(abs(wavedata)))...
            ,', Scaling Factor was ',num2str(stimpar.DivisionFactor)])
    end
    
% p = audioplayer(wavedata,srate_new);
% play(p)
    audiowrite(outputname,wavedata,srate_new)
end