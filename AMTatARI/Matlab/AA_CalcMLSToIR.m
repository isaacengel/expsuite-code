function [h,idx,rellat,pos,amp] = AA_CalcMLSToIR(mlsvec,name,bit,rep,azi,ele,ch,amp)

% AA_CalcMLSToIR            - calculate IR from MLS system identification
%
% [h,idx,rellat,pos,amp] = AA_CalcMLStoIR(mlsvec,name,bit,rep,azi,ele,ch,amp)
%
% AA_CalcMLSToIR calculates IRs from output of a system excited by the MLS. 
% The output signal must be stored in a WAV file, which is given by a file
% name. 
% 
% Input: 
%  mlsvec: excitation signal containing the MLS, including repetitions
%  name: filename of response signal, must be a cell array
%  bit: order of MLS
%  rep: # of repetitions of MLS used
%
% Output:
%  h: impulse response (matrix if name is a matrix)
%  idx: [1 size(h,1)], used by AMT@ARI
%  rellat: relative latency in samples
%
% Pio Majdak, 6.4.2005
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

if ~exist('bit','var')
    error('Order of MLS not set');
end
if ~exist('rep','var')
    error('Repetition number not set');
end

n=2^bit-1; % length of mls 
m=rep; %number of blocks
h=zeros(n,size(name,2));

for jj=1:size(name,2)
	y = audioread(name{jj})';
    if m==1
            % only one repetition
        temp=xcorr(y(1:n),[mlsvec(1:n); mlsvec(1:n)]);
        h2=temp(n+1:2*n);
    	h2=h2./(n+1);
        h(:,jj)=h2';
    elseif m==2
            % two repetitions, discard last blocks    
    	idx=1;
        mlsidx = 1;
        temp=xcorr(y(idx:idx+n),mlsvec(mlsidx:mlsidx+2*n-1));
        h2=temp(n+1:2*n);
        %idx=idx+n;        
        %mlsidx=mlsidx+n;
        h2=h2./(n+1);
        h(:,jj)=h2';
    else
            % more than two repetitions -> best SNR
    	idx=n+1;
        mlsidx = n+1;            
        for ii=2:m-1  % discard first and last blocks to provide true circular convolution
            temp=xcorr(y(idx:idx+n),mlsvec(mlsidx:mlsidx+2*n-1)); 
            h2(ii,:)=temp(n+1:2*n);
            idx=idx+n;
            mlsidx=mlsidx+n;
        end
        h2=h2./(n+1);
        h(:,jj)=mean(h2)';        
    end
end
h=[h(end,:); h(1:end-1,:)];
idx= [1 size(h,1)];
[val1,rellat]=max(h);
rellat=rellat-1;   
if exist('azi','var')
  pos=[azi ele ch];
else
  pos=[NaN NaN NaN];
end
if ~exist('amp','var')
  amp=NaN;
end
