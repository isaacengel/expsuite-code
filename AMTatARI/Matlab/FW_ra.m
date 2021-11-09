function signal = FW_ra(signal,fs,timeS)

% function signal = FW_ra(signal,fs,timeS)
% 
%   signal: input signal
%   fs: sampling rate
%   timeS: ramp time in ms

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence. 
% You may obtain a copy of the Licence at: http://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
% See the Licence for the specific language governing  permissions and limitations under the Licence. 

size = length(signal);
time = timeS/1000;
rs = round(time*fs); 

for i=1:(rs-1)
   ampfac = 0.5 - 0.5*cos(pi*i/rs);
   signal(i) = ampfac*signal(i);
end

for i=(size-rs+1):size 
   ampfac = 0.5 - 0.5*cos(pi*(size-i)/rs);
	signal(i) = ampfac*signal(i);
end
