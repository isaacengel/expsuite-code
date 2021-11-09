function [hLIN,idx,rellat,htotal,h]=AA_CalcSweepToIR(name,sw,isw,ISD,fs,N,lat,len,IRoffset,GMPar)

% [hLIN,idx,rellat,htotal,h]=AA_CalcSweepToIR(stimVec,StimPar,sw,isw,ISD,N,lat,len,IRoffset)
%
% INPUT:
%   NAME: cell array with the file names of the joined output signal
%   SW, ISW: sweep and inverse sweep signals
%   ISD: Inter Sweep Distance in samples for each system, ISD(1)==0
%   FS: sampling frequency in Hz
%   N: number of systems
%   LAT: expected latency of each system in samples
%   LEN: length of every IR in samples
%   IROFFSET: extend of the begin (IRoffset(1)) and the end (IRoffset(2)) of each IR in samples
%   GMPAR: gabor multiplier parameters. Pass only using gabor multiplier
%     method (not implemented yet)
% 
% OUTPUT:
%   hLIN: linear IRs, separeted and reshaped to linear order
%   IDX: indicies of systems in hLIN, begin (IDX(:,1)) and the end (IDX(:,2)) of each IR
%   RELLAT: latency of each systems (relative to LAT) in samples
%   HTOTAL: IR of the joined output

% 
% last update: 12.2016 by M.Mihocic: wavread replaced by audioread
%


% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

  % system parameters
T=length(sw);
m=length(audioread(name{1})); % get length of record
nges=m+T;
if len<1
  error('Set length of IR to at least 1 sample.');
end
  % create variables
if version('-release')==14
    h=zeros(sum(IRoffset)+len,N,'single');  
    hLIN=zeros(numel(h),size(name,2),'single');
    htotal=zeros(nges,size(name,2),'single');
else
    h=single(zeros(sum(IRoffset)+len,N));  
    hLIN=single(zeros(numel(h),size(name,2)));
    htotal=single(zeros(nges,size(name,2)));
end
rellat=zeros(N, size(name,2));
idx= [(0:N-1)'*size(h,1)+1  (1:N)'*size(h,1)];
nfft=2.^ceil(log2(nges));   % set fft length to 2^n to optimize calculation (about 20%)

for jj=1:size(name,2)
    % read signal
	y = audioread(name{jj});
   % calc total IR
  htemp=single(real(ifft(fft(y,nfft).*fft(isw,nfft)))/T);
  htotal(:,jj)=htemp(1:nges);
    % separate linear IR of each system
  for ii=1:N
    ibeg=T+(ISD(ii))+lat(ii)-IRoffset(1);
    iend=T+(ISD(ii))+lat(ii)+len+IRoffset(2)-1;
    h(:,ii)=htotal(ibeg:iend,jj);
        % estimate the latency time
    [val1,idx1]=max(abs(double(h(:,ii))));
    rellat(ii,jj)=double(idx1)-1;   
  end
    % order linearly
  hLIN(:,jj)=reshape(h,[],1);
end
