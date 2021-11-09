function [Obj, ggm]=AA_Augment(stimPar, Obj, flow, fhigh, amplow, high, plotdata)

% AA_Augment                - add energy to low frequency region to hM
%
% [Obj, gdm]=AA_Augment(stimPar, Obj, flow, fhigh, amplow, high, plotdata);
%
% Augment the low frequency region of hM up to FLOW by setting the amplitude
% AMPLOW (in dB) and the group delay to average of hM between FLOW and FHIGH.
% If AMPLOW is empty (or not given) AMPLOW will be the log-average amplitude 
% between FLOW and FHIGH for every vector in hM.
% Set HIGH to a nonempty value to additionally augment the high frequency region (from FHIGH).
% Set PLOTDATA to 1 to plot the group delay and the amplitude of the
% original data.
% GDM is a matrix containing the group delay of the low frequency region in
% samples for every vector in hM.
% 
% AA_Augment produces some problems in HRTFs. The lateral error increases 
% in a localization task. 
%
% Piotr Majdak, 8.11.2006
% Last change: 06.2014 by Michael Mihocic, upgrade to SOFA structure
% 

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence. 
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
% See the Licence for the specific language governing  permissions and limitations under the Licence. 
      
if isfield(Obj,'Data')
   hM=shiftdim(Obj.Data.IR,2); % new SOFA
else
  hM=Obj; % old format
end

if ~exist('high','var')
  high=[];
end

if ~exist('plotdata','var')
  plotdata=0;
end

if ~exist('amplow','var')
  amplow=[];
else
  amplow=10^(amplow/20);
end

fs=stimPar.SamplingRate;
n=size(hM,1);
itnr=size(hM,2);
rec=size(hM,3);

if plotdata==0
  klow=round(flow/fs*n);
  if klow<2
    warning(['FLOW too low (KLOW=' num2str(klow) '). No augmentation for low frequency region.']);
  end
  khigh=round(fhigh/fs*n);
  ggm=zeros(itnr,rec);
  hM2=zeros(size(hM),'single');
end
if plotdata==1
  figure;
  subplot(2,1,1); hold on; title('Original group delay');
  subplot(2,1,2); hold on; title('Original amplitude');
end
for jj=1:rec
  for ii=1:itnr
    h=double(squeeze(hM(:,ii,jj)));
        % decompose in group delay, phase and amplitude
    sp=fft(h);
    amp1=abs(sp);
    an1u=unwrap(angle(sp));     % original angle, unwrapped

      % plot the original data
    if plotdata==1  
      subplot(2,1,1); plot(grpdelay(h,1,length(h),'whole',fs)); 
      subplot(2,1,2); plot(20*log10(amp1)); 
    end

      % transform
    if plotdata==0
        % copy data
      amp2=amp1;
      an2u=zeros(ceil(n/2)+1,1);
        % get the phase slope (=group delay)
      gg=(an1u(khigh)-an1u(klow))/(khigh-klow);   % get it from the phase
        % get it from the group delay 
        %  -> better accuracy but slowlier
%       g1=grpdelay(h,1,length(h),'whole',fs); 
%       gg=-mean(g1(klow:khigh))/n*2*pi;  
      ggm(ii,jj)=-(gg)*n/2/pi;  % save the group delay
              % augment the low frequency region with constant group delay
      an2u(1:klow+1)=0:gg:gg*(klow);
      an2u(klow+1:end)=an1u(klow+1:length(an2u))-an1u(klow+1)+an2u(klow+1);
      % disp([10^(mean(log10(amp2(klow:khigh))))  mean(amp2(klow:khigh))]);
      if isempty(amplow)
        amp2(1:klow-1)=10^(mean(log10(amp2(klow:khigh))));
      else
        amp2(1:klow-1)=amplow;
      end
              % augment the high frequency region with constant group delay
      if ~isempty(high)
        an2u(khigh:end)=an2u(khigh)+(0:gg:gg*(length(an2u)-khigh));        
%         amp2(khigh:end)=amp2(khigh);
        amp2(khigh:end)=10^(high/20);
%         if isempty(amplow)
%           amp2(khigh:end)=10^(mean(log10(amp2(klow:khigh))));
%         else
%           amp2(khigh:end)=amplow;
%         end
      end

          % reconstruct signal
            % build a symmetrical phase 
      an2u=an2u(1:floor(n/2)+1);
      an2u=[an2u; -flipud(an2u(2:end+mod(n,2)-1))];
      an2=an2u-round(an2u/2/pi)*2*pi;  % wrap around +/-pi: wrap(x)=x-round(x/2/pi)*2*pi
            % amplitude
      amp2=amp2(1:floor(n/2)+1);
      amp2=[amp2; flipud(amp2(2:end+mod(n,2)-1))];
            % back to time domain
      h2=real(ifft(amp2.*exp(1i*an2)));
      hM2(:,ii,jj)=single(h2);
        % check odd/even symmetry of x
      % x=an2u;
      % xf=flipud(x(ceil(n/2)+1:end));  
      % figure; plot(x(1:n/2)); hold on; plot([x(1); -xf],'r'); title('Symmetry check');

  %     figure; title('Phase: original vs. augmented');
  %     plot(an1u); hold on; plot(unwrap(an2),'r');
  % 
  %     figure; title('Group delay: original vs. augmented');
  %     plot(g1); hold on; a=axis; plot(g2,'r'); axis(a);
  % 
  %     figure; hold on; title('IR original vs. augmented');
  %     plot(etc(h1)); plot(etc(h2),'r');
  % 
  %     figure; spect(fft(h),fs); spect(fft(h2),fs,'r');
  %     title('Spectrum original vs. augmented');
    end
  end
end

Obj.Data.IR=shiftdim(hM2,1); % SOFA object
