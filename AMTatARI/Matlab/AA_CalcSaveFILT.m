function ch=AA_CalcSaveFILT(hM, meta, fn)

% AA_CalcSaveFILT             - save hM data in a filter format
%
% ch=AA_CalcSaveFILT(hM, meta, fn)
% 
% AA_CalcSaveFILT saves the data in hM, stimPar and meta.pos in a format 
% which is used by AA_Equalize or AA_Filter. The filename fn is used
% to save the data. In fn, hM is saved as hFILT. The information about the
% audio channel is extracted from meta.pos and saved as chFILT. 
%
% Input:
%  hM: data matrix with impulse respnoses (IR): 
%      dim 1: time in samples
%      dim 2: each IR
%      dim 3: each record channel
%      hM is saved as hFILT in fn.
%  meta: hM structured meta data
%      The channel column is saved as chFILT in fn.
%  fn: file name of the filter file.  
%
% Output: 
%  CH: unique channels found in hM. Just for information...
%
% Piotr Majdak, 13.9.2005
% Last change: 05.10.2011 by Michael Mihocic, upgrade to structured meta
%  data hM version 2.0.0


% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

% fs=stimPar.SamplingRate;
hFILT = hM;
chFILT=meta.pos(:,3);
save(fn, 'hFILT','chFILT');
ch=unique(chFILT);   % channels found
