% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.


  % save hLIN as WAV
wavwrite(double(hLIN)./max(max(abs(double(hLIN))))*(1-(2^((-1)*(stimPar.Resolution-1)))), ...
  stimPar.SamplingRate,stimPar.Resolution, ...
  [stimPar.StimFileName '_IR.wav']);
  % save posLIN, idxLIN as CSV
dlmwrite([stimPar.StimFileName '_pos.csv'], posLIN, 'delimiter',';');
dlmwrite([stimPar.StimFileName '_idx.csv'], idxLIN, 'delimiter',';');
  % extract file name prefix

  % create XML-metafile
%stimPar.ID='rar';
    % create header
xml='<?xml version="1.0" encoding="UTF-8"?>'; 
xml=[xml '<AFile ID="' stimPar.ID '" SR="' num2str(stimPar.SamplingRate) ...
         '" CH="' num2str(size(hLIN,2)) '" File="' stimPar.StimFileName '_IR.wav">'];
    % create segments
for ii=1:size(posLIN,1)
  jj=max([0; find(cumsum(IRnrLIN)<ii)])+1;   % index of itemnrLIN
  xml=[xml '<ASeg ID="IR_' num2str(ii) ... 
          '" P="' num2str(idxLIN(ii,1)-1) ...
          '" L="' num2str(idxLIN(ii,2)-idxLIN(ii,1)+1) ...
          '" CH="0" azimuth="' num2str(posLIN(ii,1)) ...
          '" elevation="' num2str(posLIN(ii,2)) ...
          '" latency="' num2str(latLIN(ii)) ...
          '" amplitude="' num2str(ampLIN(jj)) ...
          '" itemnr="' num2str(itemnrLIN(jj)) ...
          '" DACchannel="' num2str(posLIN(ii,3)) ...
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
