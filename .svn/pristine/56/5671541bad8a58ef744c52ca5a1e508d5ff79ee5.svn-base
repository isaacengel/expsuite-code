function polar3(th,phi,r,varargin)

% polar3(th,phi,r,...)
% 
% th,phi,r: spherical coordinates of vector [in rad]
% further argument can be given, see PLOT for details


% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

[x,y,z]=sph2cart(th,phi,r);
if length(x)==1
  x=repmat(x,max(length(y),length(z)),1);
end
if length(y)==1
  y=repmat(y,max(length(y),length(x)),1);
end
if length(z)==1
  z=repmat(z,max(length(x),length(z)),1);
end

plot3(x,y,z,varargin{:});
rotate3d on;