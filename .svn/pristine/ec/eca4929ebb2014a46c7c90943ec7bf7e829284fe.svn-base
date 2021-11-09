function [Objnew, metanew]=AA_MergeChannels(Obj, meta, map)

% function [Objnew, metanew]=AA_MergeChannels(Obj, meta, map)
% 
% If MAP is a row vector, single record channels are copied from play channels
% (ID given in MAP) to create hMnew with one play channel (ID=Inf) only.
%
% If MAP is a column vector, single record channels (index given in MAP) are
% copied from play channels to create hMnew with one record channel only.
% Index values of 0 in MAP will be ignored.
%
%
% Example: map = [1 4 13] means: 
% - copy hM(:,idx(i),1) to hMnew(:,1,1)
% - copy hM(:,idx(i),2) to hMnew(:,1,2)
% - copy hM(:,idx(i),3) to hMnew(:,1,3)
% where idx(i) is the index of IR with channel ID==map(i)
%
% Example: map = [1 0 1 2 0] means:
% - copy hM(:,idx(1),1) to hMnew(:,1,1)
% - copy hM(:,idx(3),1) to hMnew(:,2,1)
% - copy hM(:,idx(4),2) to hMnew(:,3,1)
% where idx(i) is the index of the first IR with the unique channel ID with
% index i. idx(i)=find(unique(meta.pos(:,3))==i,1,'first')
% 
% Last change: 06.2014 by Michael Mihocic, upgrade to SOFA structure,
%   headphones merging improved
% 

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence. 
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
% See the Licence for the specific language governing  permissions and limitations under the Licence. 
  
if isempty(map)
  error('MAP must be set to a valid vector');
end

if isfield(Obj,'Data')
   hM=shiftdim(Obj.Data.IR,2); % new SOFA
else
  hM=Obj; % old ARI format
end

if size(map,1)>1
  if size(map,2)>1
    error('MAP must be a row or column vector.');
  end
  % many columns -> row vector -> map to one play channel (eg. headphones)

  hMnew=single(zeros(size(hM,1),1, length(map)));
  for ii=1:length(map) 
    idx=find(meta.pos(:,2)==map(ii));
    if isempty(idx)
      error(['Channel ID ' num2str(map(ii)) 'not found.']);
    end
    hMnew(:,1:size(idx,1),ii)=hM(:,idx,ii); % improved to merge more hp items
  end

  metanew.pos=NaN(size(meta.pos,1)/2, size(meta.pos,2));
  metanew.pos(:,3)=Inf;
  metanew.amp=meta.amp(1);
%   metanew.lat=NaN;
%   metanew.toa=NaN;
%   metanew.itemidx=NaN;
  metanew.itemidx=meta.itemidx(1:2:end);
  metanew.lat(:,1)=meta.lat(1:2:end,1);
  metanew.lat(:,2)=meta.lat(2:2:end,2);
%   meta.amp=repmat(80,[5,1]);
else
    % many rows -> column vector -> map to one record channel
  hMnew=single(zeros(size(hM,1),length(find(map~=0)),1));
  ch=unique(meta.pos(:,3));
  if length(ch)~=length(map)
    error('MAP must have the length of the vector with unique channel IDs');
  end
  jj=1;
  for ii=1:length(find(map~=0))
    if map(ii)>0
      idx=find(meta.pos(:,3)==ch(jj),1,'first');
      hMnew(:,ii,1)=hM(:,idx,map(ii));
      metanew.pos(jj,:)=meta.pos(idx,:);
      metanew.amp(jj)=meta.amp(idx);
      metanew.lat(jj)=meta.lat(jj);
      if isfield(meta,'toa')
          metanew.toa(jj)=meta.toa(jj);
      end
      metanew.itemidx(jj)=meta.itemidx(idx);
      jj=jj+1;
    end
  end
end

Objnew.Data.IR=shiftdim(hMnew,1); % SOFA object
    