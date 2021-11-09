function output = FW_GETVocoderEl(S,srate_old,srate_new,El,lower,upper,GR,divFac)
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% GETVocoder, uses adapted version from  Loca CTC                         %
%   stimNew = input signal                                                %
%   srate   = sampling rate                                               %
%   channum = numbers of channels                                         %
%   lower   = lower frequ. limit                                          %
%   upper   = upper frequ. limit                                          %
%   PulseRem= pulse removal, not used for ElecRang test                   %
%   GaussRate = rate of gaussian pulses                             
%
% v1.3   86.04.2016  Theresa Loss
%                    fixed bug with frequency variable, add scaling factor
%                    for GET normalization
% v1.2   15.04.2016: moved loading of '.mat' file to later location, so
%                    loading is not necessary for LoudSca
% v1.1   14.04.2016: Theresa Loss
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

if length(S) > 1
    S = S(2:end);
    El = El(2:end);
end

%Get frequency bands
channum = 12;
alpha=0.33;  %12 channels maximum
   
                                                
% Synthesis: These are the crossover frequencies that the output signal is 
% mapped to

crossoverfreqs = logspace( log10(lower), log10(upper), channum + 1);
syncrnfreq(:,1)=crossoverfreqs(1:end-1);
syncrnfreq(:,2)=crossoverfreqs(2:end);
for i=1:channum
    cf(i) = sqrt( syncrnfreq(i,1)*syncrnfreq(i,2) );
end

%Get stimulation rate, pulse rate is 100 pps due to limitations for 
%high pulse rates

GaussRate = repmat(100,1,channum); %GaussRate if original rate is too high
%hier noch switch to pre-rendered falls zu lang oder so ? 
% if duration > 0.5 


Sn = [];
    

% Run through all channels
for count = 1: length(S)
     l = El(count);
     stim = S{count};
     
     
     %% Make Envelope
     gap        = min(unique(stim(:,5)));
     idx        = cumsum([1;stim(:,5)]);
     nsamples   = idx(end);     % number of samples
     Ns         = size(stim,1);
     stimSig    = zeros(nsamples,1);  % signal, empty
      
     i = 0;
     for i = 1:Ns-1
         amp = stim(i,2);
         stimSig(idx(i):idx(i)+gap-1,1) = amp;
     end    
           
    %Resample with Kaiser window to avoid gibbs phenomenon
    order = 1;
    alpha2 = 20;
    [env,~]= resample(stimSig,srate_new,srate_old,order,alpha2);
    
    if count == 1
        envlength = length(env);
    else
        env = env(1:envlength);
        warning('Check length of envelopes, there is a mismatch!')
    end
        

    %% Get pulse rate
    
    duration=nsamples/srate_old;       %time format 
    Gamma = alpha*cf(l);               %equivalent rect. bw 
    sigma = 1/sqrt(2*pi*Gamma);
    N = ceil(duration * GaussRate(l)); %number of pulses     
    
    tpulse_re = 2*sigma;               %pulse duration real (2 times 
                                       %standard deviation)
                                       
    tpulse_re_all = 2./sqrt(2*pi*alpha*cf);
    tpulse_th = duration/Ns;
    
    t    = 0:1/srate_new:duration;
    told = 0:1/srate_old:duration;
    told = told(1:end-1);
    
    Genv = zeros(length(told),1);
    prate_original = Ns/duration;   %original pulse rate
    
    
    if duration > 0.6 || prate_original > 200   %use original pulse rate 
                                                 %if file is small or pulse
                                                 %rate is low
        load('FW_GET100.mat');    %load predefined pulses if file is too 
                                  %long
        GETtrain = GETout(1:nsamples,l);
        %downsample to fs acoustic
        GET = resample(GETtrain,srate_new,srate_old,order,alpha2);
        
        
        
    else
    
        if prate_original/Gamma*10 > 3.75   %GaussRate(count)/Gamma*10 > 3.75
            % delay pulses by half a period so first Gaussian pulse doesn't
            % start at a max


             if  tpulse_re < tpulse_th     %pulse width small enough for 
                                              %pulse rate
                 lim = Ns;
             else
                lim = N;
             end

            for n = 1:lim             %loop for all pulses  
                if  tpulse_re < tpulse_th     %pulse width small enough for 
                                              %pulse rate
                    T = idx(n)/srate_old; %???????????????
                else 
                    T = (n-0.5)/N*duration;
                end
                pulse = sqrt(Gamma) * exp(-pi*(Gamma*(told-T)).^2);  
                Genv = pulse' + Genv;            
            end 

            %modulate carrier
            GETtrain = Genv .*sin(2*pi*cf(l)*told');

        else 
            % delay pulses by half a period so first Gaussian pulse doesn't
            % start at a max    
            T = 1/Gamma*1.5;% 0.5/GaussRate(l)*duration;       
            pulse = sqrt(Gamma) * exp(-pi*(Gamma*(told-T)).^2)...
                                        .*sin(2*pi*cf(l)*told);    

            Genv = pulse';

            if  tpulse_re < tpulse_th     %pulse width small enough for 
                                              %pulse rate
                 lim = Ns;
            else
                lim = N;
            end

            for n = 2:lim-1            %loop for all pulses  
                if  tpulse_re < tpulse_th     
                    step = stim(n,5);
                else 
                    step = ceil(srate_old/GaussRate(l));                
                end

            %Replicate pulses

                pulse = circshift(pulse,[1 step]); 

                %plot(pulse)
                Genv = pulse' + Genv;  
                %plot(Genv)
            end
            GETtrain = Genv;
        end

        %downsample to fs acoustic
        GET = resample(GETtrain,srate_new,srate_old,order,alpha2);

        %normalize energy
        Energy = norm(GET)/sqrt(length(t));
            
        GET = GET/Energy;
        GET = GET/divFac;%apply normalization factor for wav rendering
        
        
    end

    out = GET .* env;    %Modulate with envelope
    Sn = [Sn;out'];      %Store signal
    

end

out = sum(Sn,1);         %add all channels

output = out;            %output signal 


