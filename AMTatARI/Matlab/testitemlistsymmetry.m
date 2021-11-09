%
% Test the meta.pos for symmetric positions
% and create a hM which consists of left ear HRTFs only
%  Last change: 22.09.2011 by Michael Mihocic, upgrade to structured meta
%   data hM version 2.0.0
    

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence.
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
% See the Licence for the specific language governing  permissions and limitations under the Licence.

azi=meta.pos(:,1);
ele=meta.pos(:,2);
meta.pos2=meta.pos;

idxL=[]; idxR=[];
err=[];
jj=[];
for ii=1:length(meta.pos)
  jj=find(ele==ele(ii) & azi==mod(360-azi(ii),360));
  len(ii)=length(jj);
  if length(jj)==1
    idxL=[idxL ii];
    idxR=[idxR jj];
  else
    disp(meta.pos(ii,:));
    err=[err ii];
  end
end

if isempty(err)
  disp('Symmetry confirmed');
else
  [azi(err) ele(err) mod(360-azi(err),360) ele(err)]
  disp('Symmetry problems for the above positions');
end

disp('Hit return to create symmetric hM and remove the problematic positions');
pause

hM(:,idxL,2)=hM(:,idxR,1);
for ii=length(err):-1:1
  disp(['Removing #' num2str(err(ii)) ]);
  AA_Remove(err(ii));
end
