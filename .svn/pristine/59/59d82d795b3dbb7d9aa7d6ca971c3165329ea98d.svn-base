% calc EQU, HRTF, DTF
% Required: loaded raw data and "ref1 processed" filter as FILT file
% Output: "hrtf LAS.sofa"; "dtf LAS.sofa"
% Last changes:
%  24.11.2020 by Michael Mihocic: equalize: range adapted to 20-18000Hz (instead of 20-20000Hz)
%  19.08.2020 by Michael Mihocic: LAS adaptions, output files renamed
%  12.08.2020 by Christian Blöcher: LAS adapted
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

% get LAS positions
if any(meta.pos(:,2) > 90) % check for non-updated meta.pos (Channel ID in 2nd column)
    positions = table2array(readtable('SpeakerPositionsLAS.csv','HeaderLines',1));
    N_items= length(unique(meta.itemidx));
    meta.pos(:,1:2) = repmat(positions(:,1:2),N_items,1);
    meta.pos(:,1) = mod(meta.pos(:,1) + meta.azimuth + 360, 360);

    % filter positions: spacing > 0.01m
    [x,y,z] = sph2cart(deg2rad(meta.pos(:,1)), deg2rad(meta.pos(:,2)), 1.2);
    positions_cart = round([x,y,z],2);
    [~, unique_idx, ~] = unique(positions_cart,'stable','rows');

    % update meta/Obj Data
    meta.pos = meta.pos(unique_idx,:);
    meta.itemidx = meta.itemidx(unique_idx);
    meta.lat = meta.lat(unique_idx,:);
    meta.amp = meta.amp(unique_idx);
    meta.azimuth = meta.azimuth(unique_idx);
    meta.freq = meta.freq(unique_idx);
    meta.description = meta.description(unique_idx);
    Obj.Data.IR = Obj.Data.IR(unique_idx,:,:);
end

numproc=7;proc=1;
 h=waitbar(proc/numproc, ['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Equalize raw'], 'CreateCancelBtn','close');
p=get(h,'position'); p(2)=p(2)+75; set(h, 'position',p); proc=proc+1;
% Calc EQU 
% hM=AA_Equalize(stimPar,hM,meta,-30,50,18000,4800,[stimPar.WorkDir '\' stimPar.ID '_FILT_ref1 processed']);
Obj=AA_Equalize(stimPar,Obj,meta,-30,20,18000,4800,[stimPar.WorkDir '\' stimPar.ID '_FILT_ref1 processed']); %%% LAS specific start/end frequencies
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
[Obj,cepsX]=AA_SmoothCepstral(Obj,182); %%% no Cepstral Smoothening?
 waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Window hrtf']); proc=proc+1;
% [hM]=AA_Window(hM,352-96,24,12,96);
[Obj.Data.IR]=shiftdim(AA_Window(shiftdim(Obj.Data.IR,2),352-96,24,12,96),1);
 waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Save SOFA hrtf LAS']); proc=proc+1;
HRTF=AA_SOFAsaveSimpleFreeFieldHRIRLAS([TempWorkDir '\' stimPar.ID '_M_hrtf LAS.sofa'],Obj,meta,stimPar); %%% LAS specific save function

 % calc DTFs
 waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): HRTF --> DTF']); proc=proc+1;
 HRTF.GLOBAL_Title = 'DTF LAS';
 HRTF.GLOBAL_Comment = SOFAappendText(HRTF,'GLOBAL_Comment','Directional transfer functions calculated according to Majdak et al. (2011)');
Obj=SOFAhrtf2dtf(HRTF,50,18000); % dtf
if find(isnan(Obj.Data.IR))
    error('>> Error when calculating DTF: Data.IR contains NaN(s)!');
end
waitbar(proc/numproc,h,['Calculating in progress (' num2str(proc) '/' num2str(numproc) '): Save SOFA dtf LAS']); proc=proc+1;
SOFAsave([TempWorkDir '\' stimPar.ID '_M_dtf LAS.sofa'],Obj,1);

stimPar.WorkDir=TempWorkDir;
delete(h);

% format meta data for plotting
[~, meta, stimPar]=AA_SOFAconvertSOFA2ARI(Obj);

