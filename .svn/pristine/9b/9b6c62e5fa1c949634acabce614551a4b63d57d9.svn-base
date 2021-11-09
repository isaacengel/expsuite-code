function [Obj,meta]=AA_AverageSpectral(Obj, recfilter, meta)

% AA_AverageSpectral            - Append the average complex spectrum to hM
%
% [Obj,meta]= ... 
%           AA_AverageSpectral ...
% (Obj, recfilter, meta)
%
% Average complex spectra of each record channel indexed by the index recfilter.
% The result is an IR for each record channel which are appended to hM. 
% Input:
%  Obj: SOFA object with impulse responses (IR)
%  recfilter: cell array with indicies of IRs to be averaged for each
%      record channel.
%  meta: contains meta data:
%   amp: excitation amplitude of an item
%   itemidx: item list index of an IR
%   lat: latency (in samples) of an IR
%   pos: matrix with position information of an IR
%          [azi ele channel azi' ele' lateral polar]
%
% Output: 
%  hM: Old hM and the new average 
%  meta: just updated.
%
% 
% (c) Piotr Majdak 2007
% Last change: 06.2014 by Michael Mihocic, upgrade to SOFA structure
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

rec=size(hM,3);
hAVG=zeros(size(hM,1),1,rec);
maximag=-Inf;
for ii=1:rec
  hM1=squeeze(double(hM(:,recfilter{ii},ii)));
  sM1=fft(hM1);
  sAVG=(10.^(mean(log10(abs(sM1)).').')).*exp(1i*mean((angle(sM1)).').');
  h=ifft(sAVG);
  hAVG(:,1,ii)=real(h);
  maximag=max([maximag max(max(abs(imag(h))))]);
end

if maximag > 1E-8 
  warning(['Maximum imaginary part was: ' num2str(maximag)]);
end

%   % test IRs
% figure; hold on;
% for ii=1:size(hM,2)
%   plot(etc(squeeze(hM(:,ii,1))));
% end
% plot(etc(squeeze(hAVG(:,1,1))),'r');

%  % test spectrum
% for ii=1:size(hM,2)
%   spect(fft(squeeze(hM(:,ii,1))),'w');
% end
% spect(fft(squeeze(hAVG(:,1,1))),'w','r')
  % append the average to the end of the matrix 
hM(:,end+1,:)=hAVG;
Obj.Data.IR=shiftdim(hM,1); % SOFA object
if isfield(meta,'amp'); meta.amp=[meta.amp; meta.amp(1)]; end
if isfield(meta,'itemidx'); meta.itemidx=[meta.itemidx; 0]; end
if isfield(meta,'lat'); meta.lat=[meta.lat; mean(meta.lat)]; end
if isfield(meta,'pos')
  meta.pos=[meta.pos; NaN(1,size(meta.pos,2))];
  meta.pos(end,2)=meta.pos(1,2);
  meta.pos(end,3)=meta.pos(1,3); 
end


