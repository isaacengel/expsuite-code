function [Tnewcorr,Ttot,ti,ISD,SNR]=AA_MESM(eta,K,L1,L2,N,fstart,fend,Tmin)

% [Tnewcorr,Ttot,ti,ISD]=AA_MESM(eta,K,L1,L2,N,fstart,fend,Tmin)
% calculate parameters for MESM, Overlap and Interleave
% 
% based on Majdak, Balazs, and Laback (2006) J Audio Eng Soc 55:623-637


% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

c=log(fend/fstart);
Tnew=((eta-1)*L1+L2)*c/log(2);  % Eq. 6
idx=find(Tnew<Tmin);
Tnewcorr=Tnew;  % Tnewcorr => T' from Eq. 6
Tnewcorr(idx)=Tmin;
tauK=log(K)/c*Tnewcorr; % Eq. 7
overlap=tauK+eta*L1;
Tgrp=Tnewcorr+eta*L1; % Eq. 8
Ttot=Tgrp+(N./eta-1).*(tauK+eta*L1); % Eq. 13 with substituted Eq 8
SNR=10*log10(Tnewcorr/Tmin);
i=(1:N)';
ti=zeros(N,length(eta));
for ii=1:length(eta)
  ti(:,ii)=L1*(i-1)+floor((i-1)./eta(ii))*tauK(ii);
end
if nargout>3,
    ISD=[0; diff(ti)];
end
