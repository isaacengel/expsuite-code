function [meta]=AA_CalcTOA(hM,meta,stimPar,method,plotdata,p0)

% AA_CalcTOA               - Calculate Time-of-arrival
%
% [meta]=AA_CalcTOA(hM,meta,stimPar,method,plotdata,p0)
% 
% AA_CalcTOA estimates the Time-of-Arrival for each column in inputdata hM
% and corrects the results with a geometrical model of a sphere. Choose
% between 5 estimation-typs.
%
% Input:
%   hM: data matrix with impulse respnoses (IR) (ARI HRTF format): 
%       dim 1: time in samples
%       dim 2: each IR
%       dim 3: each record channel
%
%   meta: hM structured meta data
% 
%   stimPar: stimulation parameters
% 
%   method: select one of five estimation procedures
%       1: Threshold-Detection
%       2: Centroid of squared IR
%       3: Mean Groupdelay
%       4: Minimal-Phase Cross-Correlation
%       5: Filtered Minimal-Phase Cross-Correlation
% 
%   plotdata (optional):
%       1: Plot figures
%
%   p0 (optional): startvalues for lsqcurvefit
%       dim 1: [sphere-radius in m; azimut of ear in radiants; elevation of ear in radiants; direction-independent delay in seconds]
%       dim 2: each record channel 
%
% Output:
%   meta: updated with meta.toa: data matrix with time of arrival (TOA) for each impulse response (IR):
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

if ~exist('method','var')
    method=4;
end

if ~exist('plotdata','var')
    plotdata=0;
end

if ~exist('p0','var')
    p0=[[0.08; pi/2; 0; 0.0001] [0.08; -pi/2; 0; 0.0001]];
end
p0=transpose(p0);

% if ~exist('channelnames','var')
%     channelnames=['l';'r'];
% end

hM_min=AA_MinimalPhase(hM);
TOA_est=zeros(size(hM,2),size(hM,3));
p=zeros(size(p0));
threshold=2;

%--------------------------------------------------------------------------
%-------------------------Estimate-Time-of-Arrival-------------------------
%--------------------------------------------------------------------------

switch method
    case 1 %---------------------------Threshold---------------------------
        for ii=1:size(hM,2)
            for ch=1:size(hM,3)
                TOA_est(ii,ch)=find(hM(:,ii,ch)>max(hM(:,ii,ch))/2,1);
            end
        end
    case 2 %---------------------------Centroid----------------------------
        for ii=1:size(hM,2)
            for ch=1:size(hM,3)
                TOA_est(ii,ch)=find(cumsum(hM(:,ii,ch).^2)>(sum(hM(:,ii,ch).^2)/2),1);
            end
        end
        threshold=2;
    case 3 %---------------------------Groupdelay--------------------------
        for ii=1:size(hM,2)
            for ch=1:size(hM,3)
                [Gd,F]=grpdelay(transpose(double(hM(:,ii,ch))),1,size(hM,1),stimPar.SamplingRate);
                TOA_est(ii,ch)=median(Gd(find(F<500):find(F>2000)));
            end
        end
    case 4 %---------------------------Minimal-Phase-----------------------
        corrcoeff=zeros(size(hM,2),size(hM,3));
        for ii=1:size(hM,2)
            for ch=1:size(hM,3)
                [c,lag]=xcorr(transpose(squeeze(hM(:,ii,ch))),transpose(squeeze(hM_min(:,ii,ch))),size(hM,1)-1,'coeff');
                [corrcoeff(ii,ch),i]=max(abs(c));
                TOA_est(ii,ch)=lag(i);
            end
        end
    case 5 %---------------------------Minimal-Phase-(filtered)------------
        [b,a]=butter(4,2/24);
        hM_fil=filter(b,a,hM);
        hM_min_fil=filter(b,a,hM_min);
        corrcoeff=zeros(size(hM,2),size(hM,3));
        for ii=1:size(hM,2)
            for ch=1:size(hM,3)
            	[c,lag]=xcorr(transpose(squeeze(hM_fil(:,ii,ch))),transpose(squeeze(hM_min_fil(:,ii,ch))),size(hM,1)-1,'coeff');
                [corrcoeff(ii,ch),i]=max(abs(c));
                TOA_est(ii,ch)=lag(i);
            end
        end
        threshold=5;
end

meta.toa=zeros(size(hM,2),size(hM,3));


%--------------------------------------------------------------------------
%------------------------Fit-Model-to-estimated-TOA------------------------
%--------------------------------------------------------------------------

for ch=1:size(hM,3)
    coeffs=zeros(22,5);
    p0(ch,4)=min(TOA_est(:,ch))/stimPar.SamplingRate;
    
    % First identification of outliers using slope
    indicator=zeros(size(hM,2),1); %indicates roughly outliers with hugh slope
    slope=zeros(size(hM,2),1);
    for ele=transpose(unique(meta.pos(:,2))) %calculate slope for each elevation along azimut
    	idx=find(meta.pos(:,2)==ele);
    	for ii=1:length(idx)-1
            slope(idx(ii),1)=TOA_est(idx(ii+1),ch)-TOA_est(idx(ii),ch);
        end
    end
    sloperms=sqrt(sum(slope.^2)/length(slope));
    for ele=transpose(unique(meta.pos(:,2)))
    	idx=find(meta.pos(:,2)==ele);
    	for ii=1:length(idx)-1
            if abs(slope(idx(ii+1)))>sloperms && abs(slope(idx(ii)))>sloperms
                indicator(idx(ii+1),1)=1;
            end
        end
    end

    % Fit AA_SphereModel to TOA_est for each elevation without identified
    % outliers 1
    for ele=transpose(unique(meta.pos(:,2)))
    	idx=find(meta.pos(:,2)==ele & indicator==0);%corrcoeff(:,ch)>=min(corrcoeff(:,ch))+0.2 & 
        x=meta.pos(idx,1:2)*pi/180;
        y=TOA_est(idx,ch)/stimPar.SamplingRate;
        p(ch,:)=lsqcurvefit(@AA_SphereModel,p0(ch,:),x,y,p0(ch,:)-[0.06 pi/4 pi/4 0],p0(ch,:)+[0.06 pi/4 pi/4 0.001],optimset('Display','off'));
        %p=nlinfit(x,y,@AA_SphereModel,p0(ch,:),statset('DerivStep',[0.001 pi/1800 pi/1800 0.000001]));
        clear idx
        idx=find(meta.pos(:,2)==ele);
        meta.toa(idx,ch)=AA_SphereModel(p(ch,:),meta.pos(idx,1:2)*pi/180)*stimPar.SamplingRate;
    end
    
    % Second identification of outliers using slope and error
    error=meta.toa(:,ch)-TOA_est(:,ch);
    indicator2=zeros(size(indicator));
    for ele=transpose(unique(meta.pos(:,2)))
        idx=find(meta.pos(:,2)==ele);
        rms=sqrt(sum(error(idx).^2)/length(error(idx)));
        indicator2(idx(abs(error(idx))>rms | indicator(idx)==1))=ones(length(find(abs(error(idx))>rms | indicator(idx)==1)),1);
    end
    indicator=indicator2; clear indicator2;
    
    % Fit AA_SphereModel to TOA_est for each elevation without identified
    % outliers 2
    ii=0;
    for ele=transpose(unique(meta.pos(:,2)))
        ii=ii+1;
        idx=find(meta.pos(:,2)==ele & indicator==0);
        x=meta.pos(idx,1:2)*pi/180;
        y=TOA_est(idx,ch)/stimPar.SamplingRate;
        p(ch,:)=lsqcurvefit(@AA_SphereModel,p0(ch,:),x,y,p0(ch,:)-[0.06 pi/4 pi/4 0],p0(ch,:)+[0.06 pi/4 pi/4 0.001],optimset('Display','off'));
        %p=nlinfit(x,y,@AA_SphereModel,p0(ch,:));
        clear idx
        idx=find(meta.pos(:,2)==ele);
        coeffs(ii,:)=[ele p(ch,:)];
        meta.toa(idx,ch)=AA_SphereModel(p(ch,:),meta.pos(idx,1:2)*pi/180)*stimPar.SamplingRate;
    end

    p0(ch,:)=[mean(coeffs(:,2)) mean(coeffs(:,3)) mean(coeffs(:,4)) min(coeffs(:,5))];
    clear coeffs;

    % Third identification of outliers using slope-ratio
    % (= "slope(TOA_est)/slope(meta.toa)") and error
    slope_model=zeros(size(hM,2),1);
    for ele=transpose(unique(meta.pos(:,2)))
        idx=find(meta.pos(:,2)==ele);
        for ii=1:length(idx)-1
            slope_model(idx(ii),1)=meta.toa(idx(ii+1),ch)-meta.toa(idx(ii),ch);
        end
        clear idx
    end
    indicator=zeros(size(hM,2),1);
    error=(meta.toa(:,ch)-TOA_est(:,ch));
    for ele=transpose(unique(meta.pos(:,2)))
        idx=find(meta.pos(:,2)==ele);
        for ii=2:length(idx)-1
            if abs(error(idx(ii)))>threshold && abs(slope(idx(ii-1))/slope_model(idx(ii-1)))>2 && abs(slope(idx(ii))/slope_model(idx(ii)))>2 || ...
                    abs(error(idx(ii)))>4 && abs(slope(idx(ii-1))/slope_model(idx(ii-1)))>2 || ...
                    abs(error(idx(ii)))>4 && abs(slope(idx(ii))/slope_model(idx(ii)))>2
                indicator(idx(ii))=1;
            end
        end
    end

    % Fit AA_SphereModel to TOA_est without identified outliers 1
    idx=find(indicator==0);
    x=meta.pos(idx,1:2)*pi/180;
    y=TOA_est(idx,ch)/stimPar.SamplingRate;
    p(ch,:)=lsqcurvefit(@AA_SphereModel,p0(ch,:),x,y,p0(ch,:)-[0.06 pi/4 pi/4 0],p0(ch,:)+[0.06 pi/4 pi/4 0.001],optimset('Display','off'));
    %p=nlinfit(x,y,@AA_SphereModel,p0(ch,:));    
    meta.toa(:,ch)=AA_SphereModel(p(ch,:),meta.pos(:,1:2)*pi/180)*stimPar.SamplingRate;

    % Fourth identification of outliers using slope-ratio
    % (= "slope(TOA_est)/slope(meta.toa)") and error
    slope_model=zeros(size(hM,2),1);
    for ele=transpose(unique(meta.pos(:,2)))
        idx=find(meta.pos(:,2)==ele);
        for ii=1:length(idx)-1
            slope_model(idx(ii),1)=meta.toa(idx(ii+1))-meta.toa(idx(ii));
        end
        clear idx
    end
    indicator=zeros(size(hM,2),1);
    error=(meta.toa(:,ch)-TOA_est(:,ch));
    for ele=transpose(unique(meta.pos(:,2)))
        idx=find(meta.pos(:,2)==ele);
        for ii=2:length(idx)-1
            if abs(error(idx(ii)))>9 || ...
                    abs(error(idx(ii)))>threshold && abs(slope(idx(ii-1))/slope_model(idx(ii-1)))>2 && abs(slope(idx(ii))/slope_model(idx(ii)))>2 || ...
                    abs(error(idx(ii)))>4 && abs(slope(idx(ii-1))/slope_model(idx(ii-1)))>2 || ...
                    abs(error(idx(ii)))>4 && abs(slope(idx(ii))/slope_model(idx(ii)))>2
                indicator(idx(ii))=1;
            end
        end
    end
    
    % Fit AA_SphereModel to TOA_est without identified outliers 2
    idx=find(indicator==0);
    x=meta.pos(idx,1:2)*pi/180;
    y=TOA_est(idx,ch)/stimPar.SamplingRate;
    p(ch,:)=lsqcurvefit(@AA_SphereModel,p0(ch,:),x,y,p0(ch,:)-[0.06 pi/4 pi/4 0],p0(ch,:)+[0.06 pi/4 pi/4 0.001],optimset('Display','off'));
    %p=nlinfit(x,y,@AA_SphereModel,p0(ch,:));    
    meta.toa(:,ch)=AA_SphereModel(p(ch,:),meta.pos(:,1:2)*pi/180)*stimPar.SamplingRate;

    error=meta.toa(:,ch)-TOA_est(:,ch);
    for ii=1:length(TOA_est)
        if error(ii) < 2 && error(ii) > -2
            error(ii)=0;
        end
    end
    
%--------------------------------------------------------------------------
%-------------------------------Plot-results-------------------------------
%--------------------------------------------------------------------------
    if plotdata == 1
        if ~exist('IdxM','var') % first run of AA_PlotTOA ?
            IdxM=AA_PlotTOA(stimPar, meta, meta.toa(:,ch), 3);
        else
            AA_PlotTOA(stimPar, meta, meta.toa(:,ch), 3, IdxM);
        end
        title(['Delay Ch' num2str(ch)])
        zlabel('time')
    
        AA_PlotTOA(stimPar, meta, error, 3, IdxM);
        title(['Error Ch' num2str(ch)])
        zlabel('time')
    
        ii=0;
        for ele=transpose(unique(meta.pos(:,2)))
            ii=ii+1;
            if ii==10
                [ax,h1]=AA_suplabel(['TOA Ch' num2str(ch)],'t');
                set(h1,'FontSize',12)
                ii=1;
            end
            if ii==1
                figure
            end
            subplot(3,3,ii)
            if mod(ele,2)
                plot(circshift(meta.pos(meta.pos(:,2)==ele,1),round(length(meta.pos(meta.pos(:,2)==ele,1))/2)), ...
                    meta.toa(circshift((find(meta.pos(:,2)==ele)),round(length(meta.pos(meta.pos(:,2)==ele,1))/2)),ch))
                hold on
                plot(circshift(meta.pos(meta.pos(:,2)==ele,1),round(length(meta.pos(meta.pos(:,2)==ele,1))/2)), ...
                    TOA_est(circshift((find(meta.pos(:,2)==ele)),round(length(meta.pos(meta.pos(:,2)==ele,1))/2)),ch),'r')
                plot(circshift(meta.pos(meta.pos(:,2)==ele & indicator==1,1),round(length(meta.pos(meta.pos(:,2)==ele & indicator==1,1))/2)), ...
                    indicator(circshift((find(meta.pos(:,2)==ele & indicator==1)),round(length(meta.pos(meta.pos(:,2)==ele & indicator==1,1))/2))).*...
                    TOA_est(circshift((find(meta.pos(:,2)==ele & indicator==1)),round(length(meta.pos(meta.pos(:,2)==ele & indicator==1,1))/2)),ch),'g+')
            else
                plot(meta.pos(meta.pos(:,2)==ele,1),meta.toa(meta.pos(:,2)==ele,ch))
                hold on
                plot(meta.pos(meta.pos(:,2)==ele,1),TOA_est(meta.pos(:,2)==ele,ch),'r')
                plot(meta.pos(meta.pos(:,2)==ele & indicator==1,1),indicator(meta.pos(:,2)==ele & indicator==1).*...
                    TOA_est(meta.pos(:,2)==ele & indicator==1,ch),'g+')
            end
            title(['Elevation: ' num2str(ele) '°'])
            axis([0 360 min(min(TOA_est)) max(max(TOA_est))])
            xlabel('Azimut in °')
            ylabel('time in samples')
        end
        [ax,h1]=AA_suplabel(['TOA Ch' num2str(ch)],'t');
        set(h1,'FontSize',12)
    end
end

p=transpose(p.*(ones(size(p,1),1)*[100 180/pi 180/pi 1000000]));

end