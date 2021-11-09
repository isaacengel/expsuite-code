
function AA_SaveMat(file,Obj,meta,stimPar,flags)

% function AA_SaveMat(file,Obj,meta,stimPar,flags)

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.


% szVer = version('-release');

hM=shiftdim(Obj.Data.IR,2);
stimPar.WorkDir='';

if strcmp(flags,'-V6')
    save(file,'hM','stimPar','meta','-V6');
else
    save(file,'hM','stimPar','meta');
%     save([TempWorkDir '\' stimPar.ID '_M_" & szY & ".mat'],'shiftdim(Obj.Data.IR',2)','stimPar','meta','-V6');
end