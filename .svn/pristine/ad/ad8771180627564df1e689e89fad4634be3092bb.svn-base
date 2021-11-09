function [SINAD,THDN,Fsig,Ethdn,Esum] = AA_CalcSINAD(sig,f,span,N,fs,ttitle)

% [SINAD,THDN,Fsig,Ethdn,Esum] = AA_CalcSINAD(sig,f,span,N,fs,ttitle)
%
% Calculate SINAD and some other values from a signal
%
% sig:  input signal
% f:    frequency of the stimulation sine [Hz]. 
% span: range span in which the f0 peak will be seeked [Hz]
%       the range is [f-span ... f+span]
% N:    order of noth filter, B=[0.8*f...1.2*f]
% fs:   sampling frequency
% ttitle: title of the plot, if left empty no plots are generated.
%
% Output:
% SINAD:Signal In Noise And Distortion in dB
% THDN: SINAD in % (=THD+Noise)
% Fsig: frequency of found f0
% Ethdn:energy of harmonic distortion and noise (signal without f0)
% Esum: energy of total signal
% 
%      


% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.
 
N=N*2;

    % plot or not...
if exist('ttitle','var')
    pplot=1;
else
    pplot=0;
end
    % catch zero signal
if sum(abs(sig))==0
    SINAD=NaN;
    Ethdn=NaN;
    Esum=NaN;
    THDN=NaN;
    Fsig=NaN;
    if pplot 
        figure;
        plot(sig);
    end
else
    warning('off','all');
    if f==0
        % f not specified, only noise calculation
        Ethdn=0;
        SINAD=0;
        THDN=0;
        Esum=0;
        
            % calculate DTF
        H=abs(fft(sig,fs))/fs;

		if pplot
            figure;
            plot(20*log10(H));
            hold on;
            legend('signal');
            xlabel('f in Hz    SINAD=N/A');
            ylabel('amp in dB');
            title(ttitle);
            hold off;
		end    
    else
        if length(sig)<fs+N
            error('Signal must be longer than fs+N');
        end
            % calculate DTF from N
        H=abs(fft(sig,fs))/fs;
            % find main peak in range [f-span...f+span]
		bin=f-span+1:f+span+1;
		Asig=max(H(bin));
		Fsig=find(H(bin)==Asig)+f-span-1;
        Fsig=round(mean(Fsig));
            % filter signal
		fN=fs/2; % nyquist-f		
                % notch filter
        Bb=fir1(N/2,[(0.8*Fsig)/fN (1.2*Fsig)/fN],'stop',kaiser(N/2+1,8));
                % high pass to remove DC and 50Hz
        Bh=fir1(N/2,(0.2*Fsig)/fN,'high',kaiser(N/2+1,8));
                % merge filters
        B=conv(Bb,Bh);
		NADsig=filter(B,1,sig(1:N+fs));
        NADh=abs(fft(NADsig,fs))/fs;
      	% cut the transient
        Ethdn=sum(NADsig(N+1:fs+N).^2);
        Esum=sum(sig(1:fs).^2);
		SINAD=20*log10(Ethdn/Esum);
        THDN=sqrt(Ethdn/Esum)*100;
        Esum=10*log10(Esum);
        Ethdn=10*log10(Ethdn);
  
    	if pplot
            figure;
            plot(20*log10(H));
            hold on;
            plot(Fsig+1,20*log10(H(Fsig+1)),'rx');
            plot(20*log10(NADh),'g');

            legend('original signal','f_0 peak found','filtered signal');
            xlabel(['f in Hz    SINAD=' num2str(SINAD) 'dB  THDN=' num2str(THDN) '%']);
            ylabel('amp in dB');
            title(ttitle);
            hold off;
    	end
    end
end

warning('on','all');

