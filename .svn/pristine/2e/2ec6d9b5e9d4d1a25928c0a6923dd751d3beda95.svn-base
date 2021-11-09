function pos=AA_CalcPositions(pos, flip5)
% pos=AA_CalcPositions(pos, flip5)
%
% Decode the coordinates of the measurement system to
% polar coordinates system with continuous azimut (elevation=[0,90]; 
% azimuth=[0,360). Calculate the coordinates to polar continuous elevation 
% (elevation=[0,180]; azimut=[-90,+90]) and to binaural coordinates
% (lateral angle=[-90,+90]; polar angle=[0,180]).
% 
% flip5: set to 1 if all *5 elevation positions are to be rotated by 180°
% in its azimuth; examples: 
% azi 0, ele 0  -> no change
% azi 0, ele 5  -> azi 180, ele 5
% azi 0, ele 10 -> no change
% azi 0, ele 15 -> azi 180, ele 15
% 
%
% The result matrix has following columns:
% 1: azimuth
% 2: elevation
% 3: channel
% 4: azimuth, continuous elevation
% 5: elevation, continuous elevation
% 6: lateral angle, binaural coordinates
% 7: polar angle, binaural coordinates


% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

if ~exist("flip5","var"); flip5 = 0; end

if flip5 == 1
    % decode all 5°-elevations from 180° azimuth offset
    mark=mod(pos(:,2),10) & 5; % mark all mps with 5° elevations
    idx=find(mark==1); % get index of these positions
    pos(idx,1)=mod(pos(idx,1)+180,360);
end

  % calculate polar coordinates with continuous elevation
for ii=1:size(pos,1)
  azi=pos(ii,1);
  ele=pos(ii,2);
  if azi>=0 && azi<=90
    pos(ii,4)=azi;
    pos(ii,5)=ele;
  elseif azi>90 && azi<=270
    pos(ii,4)=azi-180;
    pos(ii,5)=180-ele;
  elseif azi>270 && azi<360
    pos(ii,4)=azi-360;
    pos(ii,5)=ele;
  elseif isnan(azi)
    pos(ii,4)=NaN;
    pos(ii,5)=NaN;
  else
    error('Invalid azimuth');
  end
end
  % calculate horizontal-polar coordinates (lateral/polar angles)
[pos(:,6), pos(:,7)] = geo2horpolar(pos(:,1), pos(:,2));
pos(:,6) = round(100*pos(:,6)) / 100;
pos(:,7) = round(100*pos(:,7)) / 100;