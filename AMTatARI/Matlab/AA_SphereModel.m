% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.


function y=AA_SphereModel(p,x)
  y=p(1)/343.*( ...
	       (sign(sin(p(3)).*sin(x(:,2))+cos(p(3)).*cos(x(:,2)).*cos(p(2)-x(:,1)))/2+0.5).* ...
	       (1-sin(p(3)).*sin(x(:,2))-cos(p(3)).*cos(x(:,2)).*cos(p(2)-x(:,1)))+ ...
	       (-sign(sin(p(3)).*sin(x(:,2))+cos(p(3)).*cos(x(:,2)).*cos(p(2)-x(:,1)))/2+0.5).* ...
	       (1+acos(sin(p(3)).*sin(x(:,2))+cos(p(3))*cos(x(:,2)).*cos(p(2)-x(:,1)))-pi/2))+p(4);
end