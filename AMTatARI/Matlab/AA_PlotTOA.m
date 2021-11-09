function [IdxM]=AA_PlotTOA(stimPar, meta, toa, flags, IdxM)

% AA_PlotTOA                - Plot Time-Of-Arrival
%
% [IdxM]=AA_PlotTOA(stimPar, meta, toa, flags, IdxM)
%
% AA_PlotTOA is plotting figures of toa input; depending on the
% flags a 2D- or a 3D-figure is displayed
% 
% Input:
%   stimPar: stimulation parameters (ARI HRTF format)
% 
%   meta: hM structured meta data
% 
%   toa: data matrix with time of arrival (TOA) for each impulse response (IR):
%       dim 1: each IR
%       dim 2: each record channel
% 
%   flags: Plotting parameters:
%       0: 2D geodetic
%		1: not implemented
%		2: 3D horizontal-polar (azimuth, elevation)
%		3: 3D geodetic (lateral, polar)
% 
%   IdxM (optional):
%		position matrix
%		if Matrix IdxM is given it will not be calculated	
% 
% Output:
%   IdxM:
%		position matrix
% 
% Example:  AA_PlotTOA(stimPar, meta, toa, 3, IdxM)
%       
% Harald Ziegelwanger, Michael Mihocic 05.09.2011
% Last change: 05.10.2011 by Michael Mihocic, upgrade to structured meta
%  data hM version 2.0.0


% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

if bitand(flags,2) == 2 % (3D)
    if ~exist('IdxM','var')
        h=waitbar(0, 'Please Wait... Calculating IdxM', 'CreateCancelBtn','close'); %progress bar
        zz=0; % counter for progress bar
        IdxM=zeros(360,181);
        l=size(meta.pos,1);

        if bitand(flags,1) == 0 % geodetic (3D)
            azimuth=meta.pos(:,1)/360*2*pi;
            elevation=meta.pos(:,2)/360*2*pi;
            for ii=0:1:359
                for jj=-90:1:90
                    psi=sin(ones(l,1)*jj/360*2*pi).*sin(elevation) + ...
                    cos(ones(l,1)*jj/360*2*pi).*cos(elevation).*cos(ones(l,1)*ii/360*2*pi-azimuth);
                    [x,idx]=min(acos(psi));
                    IdxM(ii+1,jj+91)=idx;
                end
                zz=zz+1;
                waitbar(zz/360,h);
            end

        else % horizontal-polar (3D)
            lateral=meta.pos(:,6)/360*2*pi;
            polar=meta.pos(:,7)/360*2*pi;
            for ii=-89:1:270
                for jj=-90:1:90
                    psi=sin(ones(l,1)*jj/360*2*pi).*sin(lateral) + ...
                    cos(ones(l,1)*jj/360*2*pi).*cos(lateral).*cos(ones(l,1)*ii/360*2*pi-polar);
                    [x,idx]=min(acos(psi));
                    IdxM(ii+90,jj+91)=idx;
                end
                zz=zz+1;
                waitbar(zz/360,h);
            end
        end
        delete(h);
        clear x; clear zz;
    end
end

for chan=1:size(toa,2)
    toachan = toa(:,chan);
    figure;
    if bitand(flags,2) == 0 % geodetic 2D

        for ele=transpose(unique(meta.pos(:,2)))
            if mod(ele,2)
                plot(circshift(meta.pos(meta.pos(:,2)==ele,1),length(meta.pos(meta.pos(:,2)==ele,1))/2), ...
                     toachan(circshift((find(meta.pos(:,2)==ele)),length(meta.pos(meta.pos(:,2)==ele,1))/2))*stimPar.SamplingRate/1000)
            else
                plot(meta.pos(meta.pos(:,2)==ele,1),toachan(meta.pos(:,2)==ele)*stimPar.SamplingRate/1000)
            end
            hold on
         end
        title(['TOA #' num2str(chan)])
        xlabel('Azimuth [deg]')
        ylabel('Samples')
        legend(num2str(unique(meta.pos(:,2)))); 
    else % 3D
        if bitand(flags,1) == 0 % geodetic (3D)
           M=zeros(181,360);
           for ii=1:360
               for jj=1:181
                   M(jj,ii)=toachan(IdxM(ii,jj));
               end
           end            
           surface(0:1:359,0:1:180,M)
           axis([0 359 0 180])
           xlabel('azimuth')  
           ylabel('elevation')
        else % horizontal-polar (3D)
            M=zeros(360,181);
            for ii=1:360
                for jj=1:181
                    M(ii,jj)=toachan(IdxM(ii,jj));
                end
            end
            surface(-90:1:90,-89:1:270,M)
            axis([-90 90 -89 270])   
            xlabel('lateral')
            ylabel('polar')
        end

        axis square
        shading interp
        colorbar
        view(0,90)
        title(['TOA #' num2str(chan)])
    end
end
