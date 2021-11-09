function [Obj,stimPar,meta]=AA_LoadhM(stimParOld, filename)

% Load hM from .m file
% 
% function [hM,stimPar,meta,formatversion]=AA_LoadhM(filename)
% 
% Input: 
%  filename: full path and file to be loaded (containing hM, stimPar and
%   meta)
% 
% Output: 
%  hM: data matrix with impulse respnoses (IR): 
%      dim 1: time in samples
%      dim 2: each IR
%      dim 3: each record channel
%  stimPar: structure with information about the hM data
%  meta: hM structured meta data
%  formatversion: stimPar.Version, if existing in loaded file, otherwise: 1
% 
% Last update: 06.2014 by Michael Mihocic
% 

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence. 
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
% See the Licence for the specific language governing  permissions and limitations under the Licence. 

    try    
        load(filename);
%         if isfield(stimPar,'Version')
%             formatversion=stimPar.Version;
%         else
%             formatversion=1;
%         end
        AA_hM_V1toV2;
        names=fieldnames(stimPar);
        for ii=1:length(names) % update loaded fields only
            stimParOld=setfield(stimParOld,names{ii},getfield(stimPar,names{ii}));
        end
        Obj.Data.IR = shiftdim(hM,1);
        stimPar=stimParOld;
        stimPar.Version='3.0.0';
%         formatversion=3;
%         AA_hM;
    catch  % no valid file?
        clear Obj hM meta formatversion;
    end
end