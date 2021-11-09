% calc EQU, HRTF, DTF
% Required: loaded raw data and "ref1 processed" filter as FILT file
% Last change: 03.07.2014 by Michael Mihocic, SOFA structure upgrade

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

numproc=22;proc=1;
h=waitbar(proc/numproc, ['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Equalize raw'], 'CreateCancelBtn','close');
p=get(h,'position'); p(2)=p(2)+75; set(h, 'position',p);
proc=proc+1;

%% Calc EQU 
Obj=AA_Equalize(stimPar,Obj,meta,-30,300,18000,4800,[stimPar.WorkDir '\' stimPar.ID '_FILT_ref1 processed']);
waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Save equ']); proc=proc+1;
TempWorkDir=stimPar.WorkDir;
stimPar.WorkDir='';
AA_SOFAsaveSimpleFreeFieldHRIR([TempWorkDir '\' stimPar.ID '_M_equ.sofa'],Obj,meta,stimPar);

%% calc HRTFs
[Obj.Data.IR]=shiftdim(AA_Window(shiftdim(Obj.Data.IR,2),2832-2400,48,48,2400),1);
waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Window equ']); proc=proc+1;
[Obj.Data.IR]=shiftdim(AA_Window(shiftdim(Obj.Data.IR,2),2400-0,0,0,0),1);
waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Smooth Cepstral']); proc=proc+1;
[Obj,cepsX]=AA_SmoothCepstral(Obj,182);
waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Save SOFA hrtf']); proc=proc+1;
AA_SOFAsaveSimpleFreeFieldHRIR([TempWorkDir '\' stimPar.ID '_M_hrtf.sofa'],Obj,meta,stimPar);
waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Window hrtf']); proc=proc+1;
[Obj.Data.IR]=shiftdim(AA_Window(shiftdim(Obj.Data.IR,2),352-96,24,12,96),1);
waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Save SOFA hrtf 256']); proc=proc+1;
AA_SOFAsaveSimpleFreeFieldHRIR([TempWorkDir '\' stimPar.ID '_M_hrtf 256.sofa'],Obj,meta,stimPar);

%% calc CTFs
waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Load equ']); proc=proc+1;
[Obj, meta, stimPar] = AA_SOFAload([TempWorkDir '\' stimPar.ID '_M_equ.sofa']);
waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Average Cepstral']); proc=proc+1;
[Obj,meta]=AA_AverageCepstral(Obj,meta);
waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Window equ']); proc=proc+1;
[Obj.Data.IR]=shiftdim(AA_Window(shiftdim(Obj.Data.IR,2),1200-0,144,0,0),1);
waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Smooth Cepstral']); proc=proc+1;
[Obj,cepsX]=AA_SmoothCepstral(Obj,182);
waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Window']); proc=proc+1;
[Obj.Data.IR]=shiftdim(AA_Window(shiftdim(Obj.Data.IR,2),240-0,24,0,0),1);
waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Save ctf']); proc=proc+1;
AA_SOFAsaveGeneralFIR([TempWorkDir '\' stimPar.ID '_M_ctf.sofa'],Obj,meta,stimPar);
waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Save ctf filter']); proc=proc+1;
AA_CalcSaveFILT(shiftdim(Obj.Data.IR,2),meta,[TempWorkDir '\' stimPar.ID '_FILT_ctf']);
waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Load equ']); proc=proc+1;

%% calc DTFs
[Obj, meta, stimPar] = AA_SOFAload([TempWorkDir '\' stimPar.ID '_M_equ.sofa']);
waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Equalize equ']); proc=proc+1;
Obj=AA_Equalize(stimPar,Obj,meta,-30,300,18000,7200,[TempWorkDir '\' stimPar.ID '_FILT_ctf']);
waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Window']); proc=proc+1;
[Obj.Data.IR]=shiftdim(AA_Window(shiftdim(Obj.Data.IR,2),6432-6000,144,48,6000),1);
waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Zero-padding (Window)']); proc=proc+1;
[Obj.Data.IR]=shiftdim(AA_Window(shiftdim(Obj.Data.IR,2),2400-0,0,0,0),1);
waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Smooth Cepstral']); proc=proc+1;
[Obj,cepsX]=AA_SmoothCepstral(Obj,182);
waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Save dtf']); proc=proc+1;
AA_SOFAsaveSimpleFreeFieldHRIR([TempWorkDir '\' stimPar.ID '_M_dtf.sofa'],Obj,meta,stimPar);
waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Window dtf']); proc=proc+1;
[Obj.Data.IR]=shiftdim(AA_Window(shiftdim(Obj.Data.IR,2),352-96,24,12,96),1);
waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Save SOFA dtf 256']); proc=proc+1;
AA_SOFAsaveSimpleFreeFieldHRIR([TempWorkDir '\' stimPar.ID '_M_dtf 256.sofa'],Obj,meta,stimPar);

stimPar.WorkDir=TempWorkDir;
delete(h);