function Obj=AA_Filter(stimPar, Obj, meta, flen, fn)

% Objnew=AA_Filter(stimPar, Obj, meta, flen, fn)
%
% all channels of hM will be filtered
% flen: length of the result matrix [samples]
% fn: filename of the filter matrix
% 
% Last change: 06.2014 by Michael Mihocic, upgrade to SOFA structure

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

fs=stimPar.SamplingRate;

  % load all filters
load(fn);
h=double(hFILT);
ch=chFILT;
if flen<(size(hFILT,1)+size(hM,1))
  error(['The resulting impulse response must be longer than the sum of filter length (' ... 
          num2str(size(hFILT,1)/fs*1000) 'ms) and hM length (' ...
          num2str(size(hM,1)/fs*1000) 'ms).']);
end
clear hFILT chFILT;
chM=unique(meta.pos(:,3)); % all unique channels in hM1

  % create one joined filter matrix
sFILT=zeros(flen,length(chM),size(hM,3));
if ch==Inf
    % filter record channels - copy first play channel to all another...
  for ii=1:length(chM)
    for rec=1:size(hM,3) % for each REC 
      sFILT(:,ii,rec)=fft(h(:,1,rec),flen);
    end
  end
else
    % filter play channels
  for ii=1:length(chM) % for each unique channel      
    idx=find(ch==chM(ii),1);
    if isempty(idx)
      error(['Channel #' num2str(chM(ii)) ' not found in the equalization filter matrix.']);
    end
    for rec=1:size(hM,3) % for each REC 
      sFILT(:,ii,rec)=fft(h(:,idx,rec),flen);
    end
  end
end

  % create target spectrum
% target = ones(ceil(flen/2), 1)*10^(amp/20);
% target(1:(round(fu/fs*(flen))-1)) = 0;
% target((round(fo/fs*(flen))+1):end) = 0;
% targetf=flipud(target);
% if mod(flen,2)==0
%   target=[target; targetf];
% else
%   target=[target; targetf(1:end-1)];
% end

  % emphasis filter and equalize
hMnew=single(zeros(flen,length(chM),size(hM,3)));
for ii=1:size(hM,2) % for each channel
  idx= chM==meta.pos(ii,3);
  for rec=1:size(hM,3) % for each REC
    hMnew(:,ii,rec)=single(real((ifft( fft(hM(:,ii,rec),flen).*squeeze(sFILT(:,idx,rec)) ))));
  end
end

Obj.Data.IR=shiftdim(hMnew,1); % SOFA object
