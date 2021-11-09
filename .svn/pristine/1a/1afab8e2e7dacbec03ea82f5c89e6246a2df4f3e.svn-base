
% AA_CalcLinearMatrix             - calc *LIN data from *C
%
% Piotr Majdak, 8.5.2006
% Last change: 04.2019 by Michael Mihocic: azimuth, frequency and
%   description added to LIN structure
%

  % all internal variables are named *Q
  % they can be cleared by: clear *Q
% Two variables are required:
  %ibegQ=1;
  %iendQ=6;
% ----------


% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

  % get the length of IRs
recQ=zeros(size(hC,2),1);
lenQ=recQ;
itemnrLIN=recQ;
IRnrLIN=recQ;

  % get the number of valid items
nrQ=0;
for iQ=ibegQ:iendQ
  sQ=size(hC{iQ});
  if sQ(2)~=0
    nrQ=nrQ+1;
    recQ(nrQ)=sQ(2);
    lenQ(nrQ)=sQ(1);
    itemnrLIN(nrQ)=iQ;
    IRnrLIN(nrQ)=size(idxC{iQ},1);
  end
end

if nrQ==0
  clear *Q
  error('Only empty IRs found.');
end

  % truncate the vectors to valid length
recQ=recQ(1:nrQ);      % number of record streams for each non-empty item
lenQ=lenQ(1:nrQ);    % length of IR for each non-empty item
itemnrLIN=itemnrLIN(1:nrQ);  % item number 
IRnrLIN=IRnrLIN(1:nrQ); % number of IRs for one item
itemidxLIN=zeros(sum(IRnrLIN),1); % item index for an IR

  % check the number record streams
if ~isempty(find(recQ(1)~=recQ,1))
  clear *Q
  error('Only equal number of record streams in all IRs provided!');
end
recQ=recQ(1);

  % create linear matrices
hLIN=single(zeros(sum(lenQ),recQ));
idxLIN=zeros(sum(IRnrLIN),2);
posLIN=zeros(sum(IRnrLIN),3);
ampLIN=zeros(nrQ,1);
aziLIN=zeros(nrQ,1);
freqLIN=zeros(nrQ,1);
%descLIN=strings(nrQ,1);
latLIN=zeros(sum(IRnrLIN),recQ);

  % for each non-empty item
jQ=1;
idxQ=0;
for iQ=1:nrQ
  posLIN(jQ:jQ+IRnrLIN(iQ)-1,:) = posC{itemnrLIN(iQ)};
  latLIN(jQ:jQ+IRnrLIN(iQ)-1,:) = latC{itemnrLIN(iQ)};
  ampLIN(iQ) = ampC{itemnrLIN(iQ)};
  aziLIN(iQ) = aziC{itemnrLIN(iQ)};
  freqLIN(iQ) = freqC{itemnrLIN(iQ)};
  descLIN{iQ} = descC{itemnrLIN(iQ)};
  idxLIN(jQ:jQ+IRnrLIN(iQ)-1,:) = idxC{itemnrLIN(iQ)}+idxQ;  
  idxQ=idxLIN(jQ+IRnrLIN(iQ)-1,2);
  % [idxLIN(jQ,1) idxQ]
  hLIN(idxLIN(jQ,1):idxQ,:) = hC{itemnrLIN(iQ)};
  itemidxLIN(jQ:jQ+IRnrLIN(iQ)-1)=itemnrLIN(iQ);
  jQ=jQ+IRnrLIN(iQ);
end
clear *Q
% create a matrix of all IRs:
%   hM=reshape(hLIN,idxLIN(1,2),[]);
% get IRs of an item:
%   hITEM=hM(idxLIN(sum(itemnrLIN(1:item-1))+1,1):idxLIN(sum(itemnrLIN(1:item)),2))';
% get all IRs of one item X:
%   hM(find(itemidxLIN==X),:,:)
% browse all IRs:
%   mn_plot(etc(double(hM)));
