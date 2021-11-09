% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

fs=48000;
shift=10;

h=squeeze(hM(:,1,1));
% h=[1; zeros(1000,1)];

h=circshift(h,shift);
n=length(h);
fax=0:fs/length(h):fs-fs/length(h);
g=grpdelay(h,1,length(h),'whole',fs);
amp=abs(fft(h));
an1=angle(fft(h));    % original angle, wrapped
an1u=unwrap(an1);     % original angle, unwrapped
an2u=zeros(n,1);      % angle from grpdelay, unwrapped
g1=zeros(floor(n/2)+1,1);        % group delay from an1
for ii=1:n
  an2u(ii)=-2*pi*g(ii)*(ii-1)/n + an1(1);
end
for ii=2:floor(n/2)+1
  g1(ii)=-n*an1u(ii)/2/pi/(ii);     % da gibt's noch Probleme!!!
end
g1(1)=g1(2);

an2=an2u-round(an2u/2/pi)*2*pi;  % wrap around +/-pi: wrap(x)=x-round(x/2/pi)*2*pi
h1=real(ifft(amp.*exp(i*an1)));
h2=real(ifft(amp.*exp(i*an2)));
g2=grpdelay(h2,1,n,'whole',fs);

%   % compare phase: original (fft, unwrap) vs. reconstructed from grpdelay
% figure;
% plot(fax,an1u,'b', fax,an2u,'r');
% axis([0 48000 -100000 +100000]);
% 
%   % compare group delay: grpdelay vs. reconstructed from unwrapped angle
% figure; hold on;
% plot(fax,g);
% plot(fax, g1,'r');
% axis([0 48000 -100000 +100000]);
% 
 % compare wrapped phases and unwraped again (how good is unwrap?)
figure;
plot(fax,an1,'b', fax,an2,'r');
figure;
plot(fax,unwrap(an1),'b', fax,unwrap(an2),'r');

% %  compare the original, from freq., and from grpdelay reconstructed IR
% figure; hold on;
% plot(etc(h));
% plot(etc(h2),'r');
% plot(etc(h1),'g');
% figure;
% spect(fft(h),fs);
% spect(fft(h1),fs,'r');
% spect(fft(h2),fs,'g');

