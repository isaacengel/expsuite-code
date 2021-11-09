function polar3ortho(r,res,varargin)

% polar3ortho(r,res,...)
%
% R: radius of the circles. If R is negative, a simple head in center will
% be drawn.
% res: resolution in deg
% further argument can be given, see PLOT for details


% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

hold on;
th=0:res:360-res;
if r<0
  r=abs(r);
  mode=1;
else
  mode=0;
end
[x,y]=pol2cart(deg2rad(th),r);
plot3(x,y,zeros(1,length(x)),varargin{:});
plot3(y,zeros(1,length(x)),x,varargin{:});
if mode==1
  plot3(r,0,0,'rx');
  [x,y,z]=sphere(10);
  surf(x*r*0.1,y*r*0.1,z*r*0.1);
  [x,y,z]=cylinder([0.1*r 0.2*r 0],10);
  surf(z*0.1*r+0.1*r,x*0.1*r,y*0.1*r);
end
xlabel('X');
ylabel('Y');
zlabel('Z');

