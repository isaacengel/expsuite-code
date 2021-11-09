function out = FW_FilterPulses(stim, cf, bw, srate, flag)

% FW_FILTERPULSES Filters pulse sequence 
% out = FW_FilterPulses(stim, cf, bw, srate, flag) filters each column of the input vector applying specified filter settings
% The output signal is normalized to the maximum value in the input sequence    
% stim  input vector
% cf    center frequency (in Hz)
% bw    bandwidth (in Hz) 
% The cut-off frequencies are calculated such that the center frequency
% corresponds to their geometric mean with optional parameter flag =
% 'geometric'
% When stim is a matrix, FW_filterpulses operates on each column.

% This filter produces completely separated clicks at (modulation depth of 96 %) for rates up to 400 pps 
% References: Carlyon et al.(2002): -3 dB points: 3900,5400 Hz; slopes: 48 dB /oct 
%             van Wieringen et al. (2003): -3 dB points: 3900-5300 Hz; slopes: 24 dB /1/2 octave

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence. 
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
% See the Licence for the specific language governing  permissions and limitations under the Licence. 

% v1.0 19.11.2003 Bernhard Laback
% v1.1 09.05.2012 Changed so that the center frequency corresponds to
% geometric mean of the specified cutoff-frequencies (optional parameter
% flag = 'geometric')
% v1.2 23.09.2013 Bugfix: flag is now really optional 

%Constants
order=3;

%Determine maximum value in input sequence
maxValue = max(max(stim));

if exist('flag','var') && strcmp(flag,'geometric')
    if bw < 10
       error('Bandwidth must be > 10!');
    end
    fl=(-bw+(sqrt(bw^2-4*-1*cf^2 ))) /2;
    fu=fl+bw;
else %arithmetic
    fl = cf-(bw/2);    
    fu = cf+(bw/2);
end



if fl <= 0 || fu >= srate/2
   error('Cutoff frequencies exceed the allowed range!');
end

[B,A]=butter(order,[ fl/(srate/2) fu/(srate/2) ]);

stimF=filter(B,A,stim);

%Normalize to maximum value in input sequence (maxValue)
fac = max(max(stimF))/maxValue;
out=stimF/fac;



