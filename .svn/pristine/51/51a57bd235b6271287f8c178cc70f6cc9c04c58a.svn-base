function y=CalcETC(x,mode)

% y=pm_etc(x,mode)      calc logarithmic energy time curve
%
% mode =1:  normalize to peak value of the matrix
%      =2:  normalize to each peak value in every row

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.


if ~exist('mode','var')  
    mode = 0;
end
warning('off','all');
if mode == 1
    peak = max(max(x.^2));
    x = (x.^2)/peak;
elseif mode == 2
    peak = max(x.^2);
    peakm = repmat(peak,size(x,1),1);
    x=(x.^2)./peakm;
else
    x = (x.^2);
end
y=10*log10(x);
warning('on','all');