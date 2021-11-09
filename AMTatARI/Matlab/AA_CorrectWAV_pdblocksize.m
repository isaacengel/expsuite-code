% 
% function AA_CorrectWAV_pdblocksize
% Correct WAV File when pd-blocksize error occures
% --
% function out = AA_CorrectWAV_pdblocksize(fn, length)
% input parameters:
% - fn = filename (e.g.: 'c:\wavfile_adc0.wav')
% - len = length of offset, a value of 64 (pd: 1 block) moves the signal for 64 samples to the LEFT when plotting Time Domain 
% 
% last update: 12.2016 by M.Mihocic: wavread replaced by audioread
%


% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

function out = AA_CorrectWAV_pdblocksize(fn, len);

clear data;
clear datanew;

data=audioread(fn);
wavwrite(data,48000,16,[fn '.BACKUP']); 
datanew=data((len+1):length(data));
datanew((length(data)-(len-1)):(length(data)))=0;
wavwrite(datanew,48000,16,fn);            
  
['FINISHED correction of '  fn]