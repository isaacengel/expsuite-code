function out = FW_NoiseVocoderEl (S,srate_old,srate_new,El,lower,upper,stimpar,VocType)
% function for converting an electric into an acoustic signal by using a
% noise vocoder
%
% out     =  output signal
% srate_old = electric fs
% srate_new = acoustic fs
% El        = electrodes
% lower     = lower boundary of frequencies
% upper     = upper boundary of frequencies
% stimpar   = stimulus parameter
%
% v1.1   18.04.2016: Theresa Loss, selected vocoder changed
% v1.0   14.04.2016: Theresa Loss

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

% Cut first electrode
if length(S) > 1
    S = S(2:end);
    El = El(2:end);
end

% Define corner frequencies (bandwidths) for channels, same as in
% appendSTIM
 
channum=12;  %Number of channels
originalcrossoverfreqs = logspace( log10(lower), log10(upper), channum + 1);
ElNum = length(S);
for i=1:channum
   crnfreq(i,1)=originalcrossoverfreqs(i);
   crnfreq(i,2)=originalcrossoverfreqs(i+1);
end

% Filter signal in bands
d = 0.5*srate_new;
order = 4;

for i=1:channum
    cf(i) = sqrt(crnfreq(i,1)*crnfreq(i,2));
    [b, a]=butter(order,[crnfreq(i,1)/d crnfreq(i,2)/d]);
    bv(i,:)=b;
    av(i,:)=a;
    [H(i,:),w] = freqz(b,a);
end

 
%Plot the different frequency channels
x = w/pi*srate_new/2;
cfreq = zeros(size(x));

for i = 1:channum
    [m,~] = find(x <= crnfreq(i));
    cfreq(m(end)) = 1;
end

%% Synthesis with noise bands  

Sn = [];
A = [];

i = 0;
for count = 1:ElNum
    l = El(count); 
    stim = S{count};
        
    %Make Envelope
    N   = sum(stim(:,5));    % number of samples
    gap = min(unique(stim(:,5)));
    idx = cumsum([1;stim(:,5)]);
    L   = size(stim,1);
    stimSig = zeros(N,ElNum);  % signal, empty
      
    for i = 1:L-1
        amp = stim(i,2);
        %stimSig(idx(i):idx(i+1)-1,count) = amp;
        stimSig(idx(i):idx(i)+gap-1,count) = amp;
    end
        
    %Resample with Kaiser window to avoid gibbs phenomenon
    
    order = 1;
    alpha = 20;
    [a,~]= resample(stimSig(:,count),srate_new,srate_old,order,alpha);
%     f0 = filtord(y)

    factor = stimpar.DivisionFactor;
    
%     test = str2num(VocType(end));  

    test = 3;
    
    switch test
        case 1  
            
            %1) filter(noise*bands)
            out = filter(bv(l,:),av(l,:),randn(length(a),1)/factor.*a);
            
        case 2
            
            %2) filter(filter(noise)*bands)
            noise = filter(bv(l,:),av(l,:),randn(length(a),1)/factor);
            out = filter(bv(l,:),av(l,:),noise.*a);
        
        case 3
            
            %3) filter(noise)*bands with env_noise removed
            noise = randn(length(a),1)/factor;
            envs =  abs(hilbert(noise));
            noise = noise ./envs;
            out = noise .* a;
            
            
        case 4
            
            %4) TP + filter
            [bf, af]=butter(1,8000/(srate_new*0.5),'low'); 
            %figure
            %plot(a)
            %hold on
            a = filter(bf,af,a);
            %plot(a,'g')
            noise = filter(bv(l,:),av(l,:),randn(length(a),1)/factor);
            out = filter(bv(l,:),av(l,:),noise.*a);

        case 5

            %5) TP + filter
            [bf, af]=butter(1,800/(srate_new*0.5),'low'); 
            signal = filter(bf,af,a);
            signal = signal/max(abs(signal)) * max(abs(a)); %scale amplitude            
            
            noise = randn(length(a),1);
%             envs =  abs(hilbert(noise));
%             noise = noise ./envs;
            noise = filter(bv(l,:),av(l,:),noise/factor);
            out = filter(bv(l,:),av(l,:),noise.*a);
            out = out/max(abs(out)) * max(abs(a)); %scale amplitude
            
    end
    
   


    %out = filter(bv(l,:),av(l,:),randn(length(a),1)).* filter(bv(l,:),av(l,:),a);

  %  plot(out)
    Sn = [Sn;out'];
    

end

out = sum(Sn,1);
