function AA_ARI2STx(hM,meta,stimPar)

% AA_ARI2STx - Convert ARI HRTF data to STx HRTF format
% 
% AA_ARI2STx(hM,meta,stimPar)
%
% Input:
%  hM: ARI HRTF data
%  meta: hM structured meta data
%  stimPar: contains:
%   stimPar.Resolution: Resolution for wav file (eg. 16, 24,...)
%   stimPar.SamplingRate: Sampling rate for wav file (eg. 44100, 48000,...)
%   stimPar.StimFileName: Output file name
%   stimPar.ID: Experiment ID

% 
% (see ARI HRTF format doc for further details)
% 
% Michael Mihocic & Piotr Majdak, 08.04.2011
% Last change: 05.10.2011 by Michael Mihocic, upgrade to structured meta
%  data hM version 2.0.0


% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

% Convert hM to hLIN and idxLIN
hLIN=reshape(hM,size(hM,2)*size(hM,1),size(hM,3));
idxLIN=zeros(size(hM,2),size(hM,3));

for ii=1:size(hM,3)
    idxLIN(:,ii)=1 + (size(hM,1)-1)*(ii-1)  :size(hM,1):size(hM,1)*size(hM,2);
end

% save hLIN as WAV
wavwrite(double(hLIN)./max(max(abs(double(hLIN))))*(1-(2^((-1)*(stimPar.Resolution-1)))), ...
  stimPar.SamplingRate,stimPar.Resolution, ...
  [stimPar.StimFileName '_IR.wav']);
  % save meta.pos, idxLIN as CSV
dlmwrite([stimPar.StimFileName '_pos.csv'], meta.pos, 'delimiter',';');
dlmwrite([stimPar.StimFileName '_idx.csv'], idxLIN, 'delimiter',';');
  % extract file name prefix

  % create XML-metafile
%stimPar.ID='rar';
    % create header
xml='<?xml version="1.0" encoding="UTF-8"?>'; 
xml=[xml '<AFile ID="' stimPar.ID '" SR="' num2str(stimPar.SamplingRate) ...
         '" CH="' num2str(size(hLIN,2)) '" File="' stimPar.StimFileName '_IR.wav">'];
    % create segments
for ii=1:size(meta.pos,1)
  xml=[xml '<ASeg ID="IR_' num2str(ii) ... 
          '" P="' num2str(idxLIN(ii,1)-1) ...
          '" L="' num2str(idxLIN(ii,2)-idxLIN(ii,1)+1) ...
          '" CH="0" azimuth="' num2str(meta.pos(ii,1)) ...
          '" elevation="' num2str(meta.pos(ii,2)) ...
          '" latency="' num2str(meta.lat(ii)) ...
          '" amplitude="' num2str(meta.amp(ii)) ...
          '" DACchannel="' num2str(meta.pos(ii,3)) ...
          '"/>'];
end
     % create footer
xml=[xml '</AFile>'];
    % save file
fid=fopen([stimPar.StimFileName '_IR.wav.xml'], 'w');
fprintf(fid,'%s',xml);
fclose(fid);
  % clear temp. data
clear xml fid jj ii 
