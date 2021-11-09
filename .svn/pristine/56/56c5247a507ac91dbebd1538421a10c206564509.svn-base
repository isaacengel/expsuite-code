function [THD,res,Ethd,Esig,Esum] = AA_CalcTHD(sig,f,span,fs,theta,ttitle)

% [THD,res,Ethd,Esig,Esum] = AA_CalcTHD(sig,f,span,fs,theta,ttitle)
%
% Calculate THD and some other values from a signal
%
% sig:  input signal
% f:    frequency of the stimulation sine [Hz]. Set f to 0 to calculate
%       noise only
% span: range span in which all peaks will be seeked [Hz]
%       the range is [f-span ... f+span]
% fs:   sampling frequency
% theta:the product of max. of amplitude of noise between harmonics
%       and theta is the threshold for marking bins as valid, used 
%       in the calculation of energy of each peak:
%       if amp_of_peak > theta*max_of_amp_of_noise then use this bin
% ttitle: title of the plot, if left empty no plots are generated.
%
% Output:
% THD:  total harmonic distortion in %
% Ethd: energy of harmonic distortion in dB
% res:  matrix of results for each peak found, begining with f0
%       [ f[Hz] | Amp[dB] | Energy[dB] | # of bins used for calculation ]
% Esig: energy of harmonic signal
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

warning('off','all');

    % calculate DTF
if numel(sig)==0
    dFsig=2*pi*f/fs;
    sig=cos(0:dFsig:2*pi*f-dFsig)';
end
H=(fft(sig,fs))/fs;

    % plot or not...
if exist('ttitle','var')
    pplot=1;
    figure;
    plot(20*log10(abs(H)));
    hold on;
else
    pplot=0;
end
    % catch zero signal
if sum(abs(sig))==0
    THD = NaN;
    Ethdn=NaN;
    res=[NaN NaN NaN 0];
    Esum=NaN;
    %Psum=NaN;
    if pplot 
        plot(sig);
    end
end



    % energy and power of broadband signal
Esum=sum( H.*conj(H))*fs;


    % find main peak in range [f-span...f+span]
if f~=0
	bin=f-span+1:f+span+1;
	Asig=max(abs(H(bin)));
	Fsig=find(abs(H(bin))==Asig)+f-span-1;
    Fsig=round(mean(Fsig));
	Nhd=floor(fs/2/Fsig)-1;     % # of hds
        % init vectors
	Fhd=zeros(Nhd,1);
	Ninter=zeros(Nhd,1);
	Ehd=zeros(Nhd,1);
	Bins=zeros(Nhd,1);
	%ENinter=zeros(Nhd,1);
	Fcur=Fsig;
	Flast=0;
        % for each harmonic distortion
	for ii=1: Nhd
            % find current peak in range [Fcur-span...Fcur+span]
        bin=Fcur-span+1:Fcur+span+1;
        if pplot
            plot(bin,20*log10(abs(H(bin))),'yd');
        end
        [y,idx] = max(abs(H(bin)));
        Fcur=idx+Fcur-span-1;
        Fhd(ii)=Fcur;       % new peak at Fcur found
        if pplot
            plot(Fcur+1,20*log10(abs(H(Fcur+1))),'r*');
        end
            % seek for the max noise amplitude between current and last HD
        bin=round((Fcur-Flast)*0.25+Flast)+1:round((Fcur-Flast)*0.75+Flast)+1;
        Ninter(ii)=max(abs(H(bin)));
        %ENinter(ii)=2*sum(H(bin).*conj(H(bin)))*fs;
        if pplot
            plot(bin,repmat(20*log10(Ninter(ii)),length(bin),1), 'k');
        end
            %  calc energy of current HD
            %  current HD is sum of energy of bins above the threshold:
            %  threshold is (theta * max_amp_of_noise_between_two_hds)
        bin=Fcur-span+1:Fcur+span+1;
        thr=theta*Ninter(ii);
        if pplot
            plot(bin,repmat(20*log10(thr),length(bin),1), 'g.');
        end
        amp=find(abs(H(bin)) > thr)+Fcur-span;
        Bins(ii) = length(amp);
        if ~isempty(amp)
            if pplot
                plot(amp,repmat(20*log10(thr),Bins(ii),1), 'g^');
            end
            Ehd(ii)=2*sum( H(amp).* conj(H(amp)) )*fs;
        else
            if pplot
                plot(floor(fs/2),20*log10(abs(H(floor(fs/2)))), 'g^');  % dummy, just to get a legend
            end
        end
        Flast=Fcur;         % F of last peak
        Fcur=round(Fcur+mean(Fsig));     % estimate the position of new peak
	end
        
        % stimulation signal
	Esig=Ehd(1);
	%Asig=abs(H(Fhd(1)+1));
        % energy, power of thd
	Ethd=sum(Ehd(2:end));
	THD=sqrt(Ethd/(Ethd+Esig))*100;
	Ethd=10*log10(Ethd);
	Esig=10*log10(Esig);

    res=[Fhd 20*log10(abs(H(Fhd+1))) 10*log10(Ehd)  Bins];

    if pplot
        legend('signal','search for peak range','peak found','max of noise','threshold of peak energy','bins above threshold');
        xlabel(['f in Hz    THD=' num2str(THD) '%']);
        ylabel('amp in dB');
        title(ttitle);
        hold off;
	  end
        
    
else
    % f not specified, only noise calculation
    res=[];
    Ethd=0;
    THD=0;
    
	if pplot
        legend('signal');
        xlabel('f in Hz    THD=N/A');
        ylabel('amp in dB');
        title(ttitle);
        hold off;
	end    
end

Esum=10*log10(Esum);

%disp(['Sum: Esum=' num2str(Esum)   ' dB   Psum=' num2str(Psum) ' dB/Hz']);

warning('on','all');