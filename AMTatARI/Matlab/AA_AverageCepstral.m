function [ObjOut,meta] = AA_AverageCepstral (Obj,meta)

% AA_AverageCepstral            - Average of log-amplitude spectra
%
% [Obj,meta] = AA_AverageCepstral (Obj,meta)
%
% Input:
%  Obj: SOFA object with impulse responses (IR)
%  meta: hM structured meta data
%      amp: excitation amplitude of an item
%      itemidx: item list index of an IR
%      lat: latency (in samples) of an IR
%      pos: matrix with position information of an IR
%            [azi ele channel azi' ele' lateral polar]
%
% Output: 
%  Obj: IR as the average log-frequency amplitude spectrum of each record
%       channel in hM. The phase information is the minimum phase.
%  meta: just updated.
%
% 
% (c) Piotr Majdak 2007
% Last change: 07.2014 by Michael Mihocic, upgrade to SOFA structure
% 

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence. 
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
% See the Licence for the specific language governing  permissions and limitations under the Licence. 
      
if isfield(Obj,'Data')
   hM=shiftdim(Obj.Data.IR,2); % new SOFA
else
  hM=Obj; % old format
end

n=size(hM,1);
itnr=size(hM,2);
rec=size(hM,3);

ctf=zeros(n,1,rec);
% figure;
% fax=0:stimPar.SamplingRate/n:stimPar.SamplingRate-stimPar.SamplingRate/n;
% hold on;
% col=['b' 'r' 'g' 'k'];
for jj=1:rec
      % calc mean amplitude spectrum
  amp=zeros(n,itnr);
  for ii=1:itnr
    amp(:,ii)=log(abs(fft(double(squeeze(hM(:,ii,jj))))));    
  end
  amp1=mean(amp,2);  % CTF in log
  amp2=exp(amp1);   % CTF lin
  
    % calc minimal phase 
  an2u=-imag(hilbert(amp1)); % minimal phase
    % reconstruct signal from amp2 and an2u
        % build an antisymmetrical phase 
  an2u=an2u(1:floor(n/2)+1);
  an2u=[an2u; -flipud(an2u(2:end+mod(n,2)-1))];
  an2=an2u-round(an2u/2/pi)*2*pi;  % wrap around +/-pi: wrap(x)=x-round(x/2/pi)*2*pi
        % amplitude
  amp2=amp2(1:floor(n/2)+1);
  amp2=[amp2; flipud(amp2(2:end+mod(n,2)-1))];
        % back to time domain
  h2=real(ifft(amp2.*exp(1i*an2)));
  ctf(:,1,jj)=h2;
  % spect(fft(ctf(:,jj)), stimPar.SamplingRate, col(jj));
  % c{jj}=['rec #' num2str(jj)];

end

ObjOut.Data.IR=shiftdim(ctf,1); % SOFA object

% xlabel('Frequency in Hz');
% ylabel('Relative Amplitude in dB');
% title('Common Transfer Function');
% legend(c);


if isfield(meta,'amp'); meta.amp=meta.amp(1); end
meta.itemidx=0;
if isfield(meta,'lat'); meta.lat=mean(meta.lat); end
if isfield(meta,'pos')
  meta.pos=NaN(1,size(meta.pos,2));
  meta.pos(1,3)=Inf;
end

