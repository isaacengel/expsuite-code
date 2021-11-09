function hM2=AA_MinimalPhase(hM)

% AA_MinimalPhase               - Replace the phase by minimal phase
%
% hM2=AA_MinimalPhase(hM);
%
% Replace the phase spectrum of hM by the minimal phase. The minimal phase
% is calculated using hilbert transformation.
%
% Input:
%  hM: data matrix with impulse respnoses (IR): 
%      dim 1: time in samples
%      dim 2: each IR
%      dim 3: each record channel
%
% Output:
%  hM2: hM with minimal phase
%
% Piotr Majdak, 26.5.2006
 % last change: 30.07.2014 by Michael Mihocic
 
% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence. 
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
% See the Licence for the specific language governing  permissions and limitations under the Licence. 

n=size(hM,1);
itnr=size(hM,2);
rec=size(hM,3);
hM2=zeros(size(hM));

for jj=1:rec
  for ii=1:itnr
    h=squeeze(hM(:,ii,jj));
      % decompose signal
    amp1=abs(fft(h))+eps; % eps to prevent exactly 0/0

      % transform
    amp2=amp1;
    an2u=-imag(hilbert(log(amp1))); % minimal phase

        % reconstruct signal from amp2 and an2u
          % build a symmetrical phase 
    an2u=an2u(1:floor(n/2)+1);
    an2u=[an2u; -flipud(an2u(2:end+mod(n,2)-1))];
    an2=an2u-round(an2u/2/pi)*2*pi;  % wrap around +/-pi: wrap(x)=x-round(x/2/pi)*2*pi
          % amplitude
    amp2=amp2(1:floor(n/2)+1);
    amp2=[amp2; flipud(amp2(2:end+mod(n,2)-1))];
          % back to time domain
    h2=real(ifft(amp2.*exp(1i*an2)));
    hM2(:,ii,jj)=h2;
    if max(max(max(isnan(hM2)))) == 1
      error (['AA_MinimalPhase: Error in hM matrix index: (:,' num2str(ii) ',' num2str(jj) ')']);
    end
  end
end
