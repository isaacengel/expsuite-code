function out = FW_fade(inp, len, fadein, fadeout, offset)

% FW_FADE crop/extend and fade in/out a vector.
%
% OUT = FW_FADE(INP, LEN, FADEIN, FADEOUT, OFFSET) crops or extends with zeros the signal INP
% up to length LEN. Additionally, the result is faded in/out using HANN window with 
% the length FADEIN/FADEOUT, respectively. If given, an offset can be added to show
% where the real signal begins.
%
% When used to crop signal, INP is cropped first, then faded out. 
% When used to extend signal, INP is faded out first, then extended too provide fading.
% 
% INP:     vector with signal (1xN or Nx1)
% LEN:     length of signal OUT (without OFFSET)
% FADEIN:  number of samples to fade in, beginning from OFFSET
% FADEOUT: number of samples to fade out, ending at the end of OUT (without OFFSET)
% OFFSET:  number of offset samples before FADEIN, optional
% OUT:     cropped/extended and faded vector
% 
% Setting a parameter to 0 disables corresponding functionality.

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence. 
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
% See the Licence for the specific language governing  permissions and limitations under the Licence. 

% 7.11.2003
% 22.08.2005: improvement: INP may be 1xN or Nx1 now.
% Piotr Majdak (piotr@majdak.com)

ss=length(inp);    % get length of inp
	% offset
if ~exist('offset','var')
	offset = 0;
end
offset=round(offset);
len=round(len);
fadein=round(fadein);
fadeout=round(fadeout);
if offset>ss
	error('OFFSET is greater than signal length');
end
	% create new input signal discarding offset
inp2=inp(1+offset:end);
ss=length(inp2);

  % fade in
if fadein ~= 0 
  if fadein > ss
    error('FADEIN is greater than signal length');
  end
  han=hanning(fadein*2);
  if size(inp2,1)==1
    han=han';
  end
  inp2(1:fadein) = inp2(1:fadein).*han(1:fadein);
end
  % fade out window
  
if len == 0    
  len = ss;
end
if len <= ss
    % crop and fade out
  out=inp2(1:len);
    % fade out
  if fadeout ~= 0
    if fadeout > len
      error('FADEOUT is greater than cropped signal length');
    end
    han = hanning(2*fadeout);
    if size(out,1)==1
      han=han';
    end
    out(len-fadeout+1:end)=out(len-fadeout+1:end).*han(fadeout+1:end);
  end
else
    % fade out and extend
  if fadeout ~= 0
    if fadeout > ss
      error('FADEOUT is greater than signal length');
    end
    han = hanning(2*fadeout);
    inp2(ss-fadeout+1:end)=inp2(ss-fadeout+1:end).*han(fadeout+1:end);
  end
  out = [zeros(offset,1); inp2; zeros(len-ss,1)];
end
