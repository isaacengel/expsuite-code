% calc REF
% required: reference items as SOFA object
%   Last updates: 
%   - 03.2021 by Michael Mihocic: Azi: NaN->0 conversion only if field Obj.SourcePosition exists
%   - 01.2021 by Michael Mihocic: Azi=NaN converted to Azi=0
%   - 06.2014 by Michael Mihocic: upgrade to SOFA structure

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence. 
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
% See the Licence for the specific language governing  permissions and limitations under the Licence. 

[Obj,meta]=AA_MergeItems(Obj,[],[],meta);
TempWorkDir=stimPar.WorkDir;
stimPar.WorkDir='';

if isfield(Obj, 'SourcePosition')
    Obj.SourcePosition(isnan(Obj.SourcePosition(:,1)))=0; % replace azi=NaNs by zeros
end
% save([TempWorkDir '\' stimPar.ID '_M_ref1.mat'],'hM','meta','stimPar');
AA_SOFAsaveGeneralFIR([TempWorkDir '\' stimPar.ID '_M_ref1.sofa'],Obj,meta,stimPar);
% stimPar.WorkDir=TempWorkDir;
[Obj,cepsX]=AA_SmoothCepstral(Obj,182);

% [hM]=AA_Window(hM,336-72,48,24,72); 
[Obj.Data.IR]=shiftdim(AA_Window(shiftdim(Obj.Data.IR,2),336-72,48,24,72),1);

% hM=AA_MinimalPhase(hM);
[Obj.Data.IR]=shiftdim(AA_MinimalPhase(shiftdim(Obj.Data.IR,2)),1);
% save([TempWorkDir '\' stimPar.ID '_M_ref1 processed.mat'],'hM','meta','stimPar');
AA_SOFAsaveGeneralFIR([TempWorkDir '\' stimPar.ID '_M_ref1 processed.sofa'],Obj,meta,stimPar);

AA_CalcSaveFILT(shiftdim(Obj.Data.IR,2),meta,[TempWorkDir '\' stimPar.ID '_FILT_ref1 processed']); 

stimPar.WorkDir=TempWorkDir;