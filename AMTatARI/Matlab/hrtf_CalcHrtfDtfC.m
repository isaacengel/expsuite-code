% calc EQU, HRTF, DTF
% Required: loaded raw data and "ref1 processed" filter as FILT file
% Output: "hrtf C.sofa"; "dtf C.sofa"
% Last changes:
%  28.03.2019 by Michael Mihocic, upgrade to hrf/dtf C (270°->270°)
%  03.07.2014 by Michael Mihocic, upgrade to SOFA structure
%  03.03.2014 by Michael Mihocic, check for NaN(s) after DTF calculation
%  27.01.2014 by Piotr Majdak, DTF calculation based on HRTFs using SOFA API
%  29.05.2013 by Michael Mihocic, upgrade to SOFA


% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

numproc=7;proc=1;
 h=waitbar(proc/numproc, ['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Equalize raw'], 'CreateCancelBtn','close');
p=get(h,'position'); p(2)=p(2)+75; set(h, 'position',p); proc=proc+1;
% Calc EQU 
% hM=AA_Equalize(stimPar,hM,meta,-30,50,18000,4800,[stimPar.WorkDir '\' stimPar.ID '_FILT_ref1 processed']);
Obj=AA_Equalize(stimPar,Obj,meta,-30,50,18000,4800,[stimPar.WorkDir '\' stimPar.ID '_FILT_ref1 processed']);
TempWorkDir=stimPar.WorkDir;
stimPar.WorkDir='';

% calc HRTFs
 waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Window equ']); proc=proc+1;
% [hM]=AA_Window(hM,2832-2400,48,48,2400);
[Obj.Data.IR]=shiftdim(AA_Window(shiftdim(Obj.Data.IR,2),2832-2400,48,48,2400),1);
% [hM]=AA_Window(hM,2400-0,0,0,0);
[Obj.Data.IR]=shiftdim(AA_Window(shiftdim(Obj.Data.IR,2),2400-0,0,0,0),1);

 waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Smooth Cepstral']); proc=proc+1;
% [hM,cepsX]=AA_SmoothCepstral(hM,182);
[Obj,cepsX]=AA_SmoothCepstral(Obj,182);
 waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Window hrtf']); proc=proc+1;
% [hM]=AA_Window(hM,352-96,24,12,96);
[Obj.Data.IR]=shiftdim(AA_Window(shiftdim(Obj.Data.IR,2),352-96,24,12,96),1);
 waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Save SOFA hrtf C']); proc=proc+1;
HRTF=AA_SOFAsaveSimpleFreeFieldHRIR([TempWorkDir '\' stimPar.ID '_M_hrtf C.sofa'],Obj,meta,stimPar);

 % calc DTFs
 waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): HRTF --> DTF']); proc=proc+1;
 HRTF.GLOBAL_Title = 'DTF C';
 HRTF.GLOBAL_Comment = SOFAappendText(HRTF,'GLOBAL_Comment','Directional transfer functions calculated according to Majdak et al. (2011)');
Obj=SOFAhrtf2dtf(HRTF,50,18000); % dtf
if find(isnan(Obj.Data.IR))
    error('>> Error when calculating DTF: Data.IR contains NaN(s)!');
end
waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Save SOFA dtf C']); proc=proc+1;
SOFAsave([TempWorkDir '\' stimPar.ID '_M_dtf C.sofa'],Obj,1);
stimPar.WorkDir=TempWorkDir;
delete(h);