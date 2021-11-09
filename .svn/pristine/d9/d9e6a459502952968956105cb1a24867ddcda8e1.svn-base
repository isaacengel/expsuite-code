% create warped hrtf
% Thomas Walder, 26.08.09, PM (4.9.2009)
% linear warping from fu to fo


% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.


fu = 2800; % (Hz), don't warp below fu
fo = 16000; % (Hz), consider up to fo
fowarped = 8500; % (Hz), warp between fu and fo to fu and fowarped
floorlevel = -70; % level (dB) above fowarped


%init
fs = stimPar.SamplingRate;
N = fs;
fscala = [0:fs/N:fs-fs/N]';
hM_warped = zeros(512,size(hM,2),size(hM,3));

fuindex = max(find(fscala <= fu));
fowindex = min(find(fscala >= fowarped));
foindex = min(find(fscala >= fo));
yi = ones(fs/2+1,1)*(10^(floorlevel/20));
flin1 = [fscala(1:fuindex-1)];
flin2 = [linspace(fscala(fuindex),fscala(foindex),fowindex-fuindex+1)]';
xi = [flin1 ; flin2];
x = fscala(1:foindex);

for el = 1:size(hM,2)
  disp(el);
  for canal = 1:size(hM,3)

      % interpolate
      H = fft(double(squeeze(hM(:,el,canal))),N);
      Y = H(1:foindex);
      yi(1:length(xi),1) = interp1(x, Y, xi,'linear');

      yges=([yi; conj(flipud(yi(2:end-1)))]);
      hges = ifft([yges(1:end)],length(yges));
      hges=fftshift(ifft(yges));
      hwin=hges(fs/2-256:fs/2+768);
      hwinfade = FW_fade(hwin,512,24,96,192);
      hM_warped(1:end,el,canal)=single(hwin);
            
    end
end

hMold=hM;
hM = hM_warped;
clear hM_warped