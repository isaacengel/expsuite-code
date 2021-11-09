function mp=AA_CreateHRTFItemList(beg,res,ende,ele0)

% mp=AA_CreateHRTFItemList(beg,res,ende,ele0)
% 
% beg: azimuth at the begin of a group
% res: resolution within a group
% ende: azimuth at the end of a group
% ele0: vector with elevations in the median plane
% mp=[azi elenr ele1 ele2 ... eleN]
% azi: coded azimuth, +180° foe every elevation in 5° grid
% elenr: number of elevations for given azi
% eleX: elevations, NaN if not used


% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

rt=2.5;      % resolution of turntable;
aziele0=[0 90 180 270];

if ~exist('res','var')
  beg= [0   45  90    270 270+45];      % begin eines sektors in °
  ende=[45  90 270 270+45    360];      % ende eines sektors in °
  res= [2.5  5   5      5    2.5];      % azimut: auflösung an referenzebene in °
end
azi0=[];
for ii=1:length(res)
  azi0=[azi0 beg(ii):res(ii):ende(ii)-res(ii)];
end

if ~exist('ele0','var')
  ele0=[-30 -25 -20 -15 -10 -5 0 5 10 15 20 25 30 35 50 45 50 55 60 70 80]; % alle benutzte elevationen 
end

    % % äquidistante bogenlänge entlang der Kugeloberfläche (nur bis 45°)
polar3ortho(-1,5,'r');
for ii=1:length(ele0)
  polar3(deg2rad(azi0'),deg2rad(repmat(ele0(ii),length(azi0),1)),1,'bx');
end
mp=[];
dU=deg2rad(res);    % abstand zweier punkte am kreis für res°
for jj=1:length(dU)
  for ii=1:length(ele0)
    n=floor(deg2rad(ende(jj)-beg(jj))*cos(deg2rad(ele0(ii)))./dU(jj));
    azi=beg(jj):(ende(jj)-beg(jj))/n:ende(jj)-(ende(jj)-beg(jj))/n;
    azi=round(azi./rt)*rt;
    if azi<90 | (azi > 180 & azi < 270)
      azi=floor(azi./rt)*rt;
    else
      azi=ceil(azi./rt)*rt;
    end
    mp=[mp; azi' repmat(ele0(ii),length(azi),1)];
  end
end

  % add ele0 for each azi in aziele0
for ii=1:length(aziele0)
  if ~isempty(find(mp(:,1)==aziele0(ii)))
    mpadd=[repmat(aziele0(ii),length(ele0),1) ele0'];
    mp=[mp; mpadd];
  end
end

mp=unique(mp,'rows');
polar3(deg2rad(mp(:,1)),deg2rad(mp(:,2)),1,'r.');
view(90,90);

  % adapt all 5°-elevations to 180° azimuth offset
mark=mod(mp(:,2),10) & 5; % mark all mps with 5° elevations
idx=find(mark==1); % get index of these mps
%mp2=mp;
mp(idx,1)=mod(mp(idx,1)+180,360);
mp=sortrows(mp);

  % create matrix azi x ele
mm=repmat(NaN, length(unique(mp(:,1))), length(ele0)+2);
mm(:,1)=unique(mp(:,1));
for ii=1:size(mm,1)
  idx=find(mp(:,1)==mm(ii,1));
  mm(ii,3:length(idx)+2)=mp(idx,2)';
  mm(ii,2)=length(idx);
end
mp=mm(:,1:max(mm(:,2))+2);
