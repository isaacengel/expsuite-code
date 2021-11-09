function FW_PlotResults(xvec, yvec, zvec, tit, xlab, ylab, zlab)

% FW_PlotResults(xvec, yvec, zvec, tit, xlab, ylab, zlab)
%
% XVEC: vector with X-values
% YVEC: vector with Y-values corresponding to XVEC
% ZVEC: vector with values corresponding to different groups in YVEC
%       use ZVEC=[] for only one group in YVEC
% TIT:  title of figure
% XLAB: x-label
% YLAB: y-label
% ZLAB: description of ZVEC, placed in the legend
%
% Test with:
%  xxx=[100 200 300 400 100 300 700 200 0 100 500 700 900];
%  yyy=[5 7 10 20 5.5 8 10 4 1 3 5 7 9 ];
%  zzz=[1 1 1 1 200 200 200 200 5.5 5.5 5.5 5.5 5.5];
%  FW_PlotResults(xxx,yyy,zzz,'Results', 'ITD FS', 'Mean', 'Jitter');

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence. 
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
% See the Licence for the specific language governing  permissions and limitations under the Licence. 

col='brkgcmy';
sym='ox+*sdv';

figure;
hold on;
title(tit);
xlabel(xlab);
ylabel(ylab);
zval=unique(zvec);
if length(zval)<2
  zval=1;
  zvec=ones(length(xvec),1);
end
leg=cell(length(zval),1);
for zz=1:length(zval)
  idx=find(strcmp(zvec,zval(zz)));
  xy=sortrows([xvec(idx)' yvec(idx)']);
  plot(xy(:,1), xy(:,2), [col(mod(zz-1,length(col))+1) sym(mod(zz-1,length(col))+1) '-']);
  if isnumeric(cell2mat(zval(zz)))
    leg{zz}=[zlab '=' num2str(cell2mat(zval(zz)))];
  else
    leg{zz}=[zlab '=' cell2mat(zval(zz))];
  end
end
if length(zval)>1
  legend(leg);
end
set(gcf,'PaperType','A4');
zoom on;