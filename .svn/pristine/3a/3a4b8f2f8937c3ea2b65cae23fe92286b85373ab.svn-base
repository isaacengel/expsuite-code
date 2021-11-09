function [Obj, ceps]=AA_SmoothCepstral(Obj, winsize)

% AA_SmoothCepstral               - Cepstral smoothing
%
% [Obj, ceps]=AA_SmoothCepstral(Obj, winsize)
%
% Smooth the spectrum of hM using a low-quefrency lifter. The lifter is 
% implemented as cepstral window of size winsize.
%
% Input: 
%  Obj: SOFA object with impulse responses (IR)
%  winsize: the width if the cepstral window. Defines the low-quefrency of the lifter
% 
% Output: 
%
%  Obj: smoothed hM
%  ceps: not windowed complex cepstra of hM
%
% Piotr Majdak, 5.4.2006
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

  % allocate vectors 
ceps=zeros(size(hM));
nd=zeros(size(hM,2),size(hM,3));
rec=size(hM,3);
N=size(hM,2);
  % calculate cepstrum
warning off;
h=waitbar(0, 'smoothing cepstral in progress...', 'CreateCancelBtn','close');
for jj=1:rec
  for ii=1:N
    [ceps(:,ii,jj), nd(ii,jj)]=cceps(double(hM(:,ii,jj)));
  end
  waitbar(jj/2/rec,h);
end
% mn_plot(squeeze(etc(ceps(:,:,1),1)));    

  % smooth cepstral
cepwin=[ones(winsize,1); zeros(size(hM,1)-2*winsize,1); ones(winsize,1)];
% cepwin=[FW_fade(ones(winsize,1),winsize,0,floor(0.25*winsize)); ...
%         zeros(size(hM,1)-2*winsize,1); 
%         FW_fade(ones(winsize,1),winsize,floor(0.25*winsize),9)];
% figure;
% plot(cepwin);
hMnew=zeros(size(hM),'single');
for jj=1:rec
  for ii=1:N
%     hMnew(:,ii,jj)=fftshift(icceps(ceps(:,ii,jj).*cepwin,nd(ii,jj)));    
    hMnew(:,ii,jj)=single(icceps(ceps(:,ii,jj).*cepwin,nd(ii,jj)));    
  end
  waitbar(jj/2/rec+0.5,h);
end

Obj.Data.IR=shiftdim(hMnew,1); % SOFA object

delete(h);