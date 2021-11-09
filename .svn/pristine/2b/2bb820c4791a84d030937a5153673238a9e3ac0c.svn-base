function [azi,ele]=hor2geo(lat,pol)
% HOR2GEO converts coordinates in horizontal polar format to geodetic ones
% Usage:  [azi,ele]=hor2geo(lat,pol)
% Input arguments:
%       lat:        lateral angle   (-90 <= lat <= 90)
%       pol:        polar angle     (-90 <= pol < 270)
% Output arguments:
%       azi:        azimuth angle   (  0 <= azi < 360)
%       ele:        elevation angle (-90 <= ele <= 90)
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Robert Baumgartner, OEAW Acoustical Research Institute
% latest update: 2010-08-23
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

if lat==90
    azi=lat;
    ele=0;
    azi=mod(azi+360,360);
else
    lat=deg2rad(mod(lat+360,360));
    pol=deg2rad(mod(pol+360,360));
    ele=asin(cos(lat)*sin(pol));
    if cos(ele)==0
        azi=0;
    else
        azi=real(rad2deg(asin(sin(lat)/cos(ele))));
    end
    ele=rad2deg(ele);
    if pol > pi/2 && pol< 3*pi/2
        azi=180-azi;
    end
    azi=mod(azi+360,360);
end
end