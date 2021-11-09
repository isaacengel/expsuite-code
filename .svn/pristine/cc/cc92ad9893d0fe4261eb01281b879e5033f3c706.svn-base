function FW_ShowStimulus (stimVec, stimPar, ttitle, flags, axi, varargin)

% FW_ShowStimulus (stimVec, stimPar, ttitle, flags [,axis [, parameters]])
%
% stimVec: plot vector (in acoustical domain matrix is allowed)
% stimPar: stimPar structure with important parameters
% ttitle: Title of the plot
% flags: Flags telling how to plot the vector/matrix
% axis: Optional. [Xmin Xmax Ymin Ymax] of the plot. Units are in compliance to the flags
% varargin: Optional. varargin{1}: legend; varargin{2}: legend y axis; varargin{3}: intervall for y axis
%
%
% Flags:
%   Bit 0: time domain [0] / frequency domain [1] (up to fs/2)
%   Bit 1..3: scaling of the X-axis
%   Bit 4..6: scaling of the Y-axis
%   Bit 7: enable matrix mode
%   Bit 8,9,10: plot mode
%
% Plot mode (matrix mode disabled):
%     0: plot (1 line/column)
%   256: specgram (1 figure/column) (function expiring in MATLAB)
%   512: spectrogram (1 figure/column) (replacing specgram)
%
% Plot mode (matrix mode enabled):
%     0: color plot [Parameters: Y label, Y scaling vector]
%   256: waterfall [Parameters: Y label, Y scaling vector]
%   512: mesh [Parameters: Y label, Y scaling vector]
%   768: stretched 2d plot [Parameters: Y label, Y scaling vector, stretching factor]
%  1024: surface 
%
% Scaling of the x-axis:
%	 in time domain:
%   0: samples
%   2: time in s
%   4: time in ms
%   6: time in us
%  in frequency domain:
%   0: bins, lin
%   2: Hz, lin
%   4: kHz, lin
%   6: -
%   8: bins, log10
%   10: Hz, log10
%   12: kHz, log10
%   14: ERB scaled
%  in specgram mode the scaling of x-axis sets the FFT resolution:
%   0: 64 samples
%   2: 128 samples
%   4: 256 samples
%   6: 512 samples
%   8: 1024 samples
%  10: 2048 samples
%  12: 4096 samples
%
% Scaling of the y-axis:
%   0: lin
%   16: abs
%   32: ETC, 20*log10(abs(sig))
%   48: stimVec(:,:,1) - stimVec(:,:,2)
%   64: abs( stimVec(:,:,1) - stimVec(:,:,2) )
%   80: 20*log10(abs( stimVec(:,:,1) - stimVec(:,:,2) ))
%   96: normalized ETC 
%  in specgram mode the scaling of the y-axis has no meaning.
%
% Last updates:
%  FW v1.1.27 (16.09.2020)
%  - bug fixed when using in Unity mode
%  FW v1.1.9 (16.04.2020)
%  - implementation of spectrogram (will replace specgram in future MATLAB versions)
%

% ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
% Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
% Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
% You may not use this work except in compliance with the Licence. 
% You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
% Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
% See the Licence for the specific language governing  permissions and limitations under the Licence. 

warning('off','all');
stimVec=double(stimVec);
if ~exist('axi','var')
  axi=[];
end
fs=stimPar.SamplingRate;
    
switch stimPar.GenMode
  
    %% Electrical
case {0, 3}  % electrical
  
  [stimSig, els] = FW_stimVec2Sig(stimVec, stimPar, stimPar.SamplingRate);
  if ~exist('flags', 'var')
    beg=input('Start of plot (in ms):');
    ende=input(['End of plot (in ms, max:' num2str(length(stimSig)*1000/fs) 'ms):']);  
  else
    beg=0;
    ende=3500;
  end  
  begS=min([round(beg/1000*fs) length(stimSig)])+1;
  endeS=min([round(ende/1000*fs) length(stimSig)]);
  ende=endeS*1000/fs;
  valididx=find(els>0);
  figure;
  if isempty(valididx)
    set(gcf,'Name','Empty vector');
    return
  end
  set(gcf,'PaperType','A4');  
  validels=els(valididx);
  n=length(validels);
  for ii=n:-1:1
    if validels(ii)>0
      subplot(n,1,n-ii+1);
      %plot(beg:1000/fs:(length(stimSig(begS:endeS,find(validels(ii)==els)))-1)*1000/fs+beg, stimSig(begS:endeS,find(validels(ii)==els)));      
      plot(beg:1000/fs:(length(stimSig(begS:endeS,ii))-1)*1000/fs+beg, stimSig(begS:endeS,valididx(ii)));
      ylabel(['#' num2str(validels(ii))]);
      axis([beg ende -127 127]);
    end
  end
  xlabel('Time in ms');
  
  %% Acoustical
case {1, 4, 5}  % acoustical

  if bitand(flags,128) == 0 
      % matrix mode disabled
      % --------------------
    if ~isempty(find(size(stimVec))<2)   % ignore empty dimensions
      stimVec=squeeze(stimVec);
    end
    if ~ismatrix(stimVec) 
      error('Can not show stimulus with more than two dimensions.');
    end
    if size(stimVec,1)==1   % row vector? -> transpose to columns vector
      stimVec=stimVec';
    end
    switch bitand(flags,256+512+1024)   % switch plot modes
        %% acoustical - 2D plot
      case 0   % plot mode
        figure;
        set(gcf,'PaperType','A4');
        if bitand(flags,1) == 0         % time/freq domain?
            % time domain
          [xax,xlab]=ScaleXTime(stimVec,flags,fs);
          [vec,ylab]=ScaleData(stimVec,flags,fs);
          switch nargin
            case {4, 5} % no optional parameters passed
              ylab=[];
              yax=[];
              leg=ttitle;
            case 6   % Y-label given, its the legend prefix
              leg=varargin{1};
              yax=[];
            case 7  % Y-label (legend prefix) and Y-axis given
              leg=varargin{1};
              yax=varargin{2};
            case 8  % n==3 % Y-label, Y-axis and third parameter
              leg=varargin{1};
              yax=varargin{2};                
          end
          if length(yax)>1
            [yax,idx]=sort(yax);             % sort data
            vec=vec(:, idx);
          end
             % plot signal          
          plot(xax,vec);
          xlabel(xlab);
          ylabel(ylab);
          title(ttitle);
          zoom on;
          if isempty(leg)
            ylab='Item';
          end
          if isempty(yax)
            yax=0:size(vec,2)-1;
          end
          if length(yax)<size(vec,2)
            yax=repmat(yax(1),size(vec,2),1);
          end
            c=cell(size(vec,2),1);
            for ii=1:size(vec,2)
              c{ii}=[leg ': ' num2str(yax(ii))];
            end
          if size(vec,2)<30  % show legend only for less than 30 items
            legend(c, 'Location', 'Best');
          end
          if ~isempty(axi)
            axis(axi);
          end          
        else
            % frequency domain                    
          idx=find(sum(abs(stimVec))==0);   % remove zero signals
          if ~isempty(idx)
              stimVec(:,idx)=NaN(size(stimVec,1),length(idx));
          end
          [vec,xax,xlab]=ScaleXFreq(stimVec,flags,fs);
          [vec,ylab]=ScaleData(vec,flags,fs);
          switch nargin
            case {4, 5} % no optional parameters passed
              ylab=[];
              yax=[];
              leg=ttitle;
            case 6   % Y-label given, its the legend prefix
              leg=varargin{1};
              yax=[];
            case 7  % Y-label (legend prefix) and Y-axis given
              leg=varargin{1};
              yax=varargin{2};
            case 8 % n==3 % Y-label, Y-axis and third parameter
              leg=varargin{1};
              yax=varargin{2};         
          end
          if length(yax)>1
            [yax,idx]=sort(yax);             % sort data
            vec=vec(:, idx);
          end
            % plot signal
          if bitand(flags,8) == 0                
            plot(xax,vec);      % lin x-axis
          elseif bitand(flags,8+4+2) == 14
            plot(xax,vec); % ERB scaled
            setERBticks;
          else                
            semilogx(xax,vec);  % log y-axis
          end
          xlabel(xlab);
          ylabel(ylab);
          title(ttitle);
          zoom on;
          if isempty(leg)
            ylab='Item';
          end
          if isempty(yax)
            yax=0:size(vec,2)-1;
          end
          if length(yax)<size(vec,2)
            yax=repmat(yax(1),size(vec,2),1);
          end
          if size(vec,2)<30  % show legend only for less than 30 items
            c=cell(size(vec,2),1);
            for ii=1:size(vec,2)
              c{ii}=[leg ': ' num2str(yax(ii))];
            end
            legend(c, 'Location', 'Best');
          end
          if ~isempty(axi)
            axis(axi);
          end          
          if ~isempty(axi)
            axis(axi);
          end          
        end % time/freq domain
         %% Acoustical - Specgram mode
      case {256, 512} % specgram, spectrogram mode
        switch bitand(flags,14)         % check the FFT resolution
          case 0
            nfft=64;
          case 2
            nfft=128;
          case 4
            nfft=256;
          case 6
            nfft=512;
          case 8
            nfft=1024;
          case 10
            nfft=2048;
          case 12
            nfft=4096;
        end
        vec=stimVec;
           % plot signal
        for ii=1:size(stimVec,2)
          figure;
          set(gcf,'PaperType','A4');
          if bitand(flags,256) == 256
              specgram(vec(:,ii),nfft,fs);
          elseif bitand(flags,512) == 512
              spectrogram(vec(:,ii),hanning(nfft),length(hanning(nfft))/2,nfft,fs,'yaxis');  
          end   
          title(ttitle);
          xlabel(['Time in s, window size: ' num2str(nfft) ' samples']);
          ylabel(['Frequency in Hz; Record #' num2str(ii)]);
          zoom on;
          if ~isempty(axi)
            axis(axi);
          end          
        end         
    end  % switch plot mode
    %% Acoustical - Matrix mode
  else
      % matrix mode enabled
      % -------------------
%     if ~isempty(find(size(stimVec))<2)   % ignore empty dimensions
%       stimVec=squeeze(stimVec);
%     end
    switch nargin
      case {4, 5}          % no optional parameters passed
        ylab=[];
        yax=[];
        par3=[];
      case 6    % Y-label given
        ylab=varargin{1};
        yax=[];
        par3=[];
      case 7    % Y-label and Y-axis given
        ylab=varargin{1};
        yax=varargin{2};
        par3=[];
      case 8    % n==3 % Y-label, Y-axis and third parameter
        ylab=varargin{1};
        yax=varargin{2};
        par3=varargin{3};
    end
    if ~ismatrix(stimVec) 
      stimVec=squeeze(stimVec);
      yax=[];
      ylab='Record channel';
    end
    if size(stimVec,2)<2 
      error('Use vector mode (2D) to show a single vector!');
    end
    if ~ismatrix(stimVec) 
      error('Can not show stimuli with more than two dimensions.');
    end
    if isempty(yax)
      yax=0:size(stimVec,2)-1;
    end              
    
    
    if bitand(flags,1) == 0         % time/freq domain?
        %% Acoustical - Matrix - Time domain
      [xax,xlab]=ScaleXTime(stimVec,flags,fs);
      if isempty(ylab)
        [vec,ylab]=ScaleData(stimVec,flags,fs);
      else
        [vec,ylabnew]=ScaleData(stimVec,flags,fs);
      end
      if isempty(yax)
        yax=0:size(stimVec,2)-1;
      end
      [yax,idx]=sort(yax);
      vec=vec(:, idx);
         % plot signal
      figure;
      set(gcf,'PaperType','A4');
      switch bitand(flags,256+512+1024)                 
        case 0    % pcolor
          % hier nachschauen ob yax monoton ist...
          pcolor(xax,yax,vec');
          shading interp;
          ylabel(ylab);
          if ~isempty(axi)
            axis(axi(1:4));
            if length(axi)==6
              caxis([axi(5) axi(6)]);
            end
          end      
          colorbar;
        case 256    % water fall
          % hier nachschauen ob yax monoton ist...
          waterfall(xax,yax,vec');
          ylabel(ylab);
          if ~isempty(axi)
            axis(axi(1:4));
            if length(axi)==6
              caxis([axi(5) axi(6)]);
            end
          end      
        case 512    % 3d-plot
          % hier nachschauen ob yax monoton ist...
          mesh(xax,yax,vec');
          ylabel(ylab);
          if ~isempty(axi)
            axis(axi(1:4));
            if length(axi)==6
              caxis([axi(5) axi(6)]);
            end
          end      
        case 768    % stretched plot, par3=offset
          if isempty(par3)
            par3=0.000001;
          end
          plot(xax', vec+repmat(0:par3:par3*size(vec,2)-par3, size(vec,1),1))
          ylabel([ylabnew '; separation: ' num2str(par3)]);
          if size(stimVec,2)>1
            if isempty(ylab)
              ylab='Item';
            end
            if isempty(yax)
              yax=0:size(stimVec,2)-1;
            end
            if size(stimVec,2)<30  % show legend only for less than 30 items
              c=cell(size(stimVec,2),1);
              for ii=1:size(stimVec,2)
                c{ii}=[ylab ': ' num2str(yax(ii))];
              end
              legend(c, 'Location', 'Best');
            end
          end
          if ~isempty(axi)
            axis(axi(1:4));
          end      
        case 1024   % surface                  
          surf(xax,yax,vec');
          shading interp;
          ylabel(ylab);
          if ~isempty(axi)
            axis(axi(1:4));
            if length(axi)==6
              caxis([axi(5) axi(6)]);
            end
          end      
          colorbar;
      end
      xlabel(xlab);
      title(ttitle);
      zoom on;

    else
        %% Acoustical - Matrix - Frequency domain
      idx=find(sum(abs(stimVec))==0);   % remove zero signals
      if ~isempty(idx)
          stimVec(:,idx)=NaN(size(stimVec,1),length(idx));
      end
        % sort along the yax
      [yax,idx]=sort(yax);
      stimVec=stimVec(:, idx);
      [vec,xax,xlab]=ScaleXFreq(stimVec,flags,fs);
      if isempty(ylab)
        [vec,ylab]=ScaleData(vec,flags,fs);
      else
        [vec,ylabnew]=ScaleData(vec,flags,fs);
      end
      figure;
      set(gcf,'PaperType','A4');
      switch bitand(flags,256+512+1024)                 
        case 0    % pcolor
          if bitand(flags,8) == 0                
            % hier nachschauen ob yax monoton ist...
            pcolor(xax,yax,vec');      % lin x-axis
          elseif bitand(flags,8+4+2) == 14
            % hier nachschauen ob yax monoton ist...
            pcolor(xax,yax,vec');   % erb scaled
            setERBticks;
          else
            semilogx(xax,vec);  % log y-axis
          end
          shading interp;
          ylabel(ylab);          
          if ~isempty(axi)
            axis(axi(1:4));
            if length(axi)==6
              caxis([axi(5) axi(6)]);
            end
          end      
          colorbar;
        case 256    % water fall
          waterfall(xax,yax,vec');
          ylabel(ylab);          
          if ~isempty(axi)
            axis(axi(1:4));
            if length(axi)==6
              caxis([axi(5) axi(6)]);
            end
          end      
        case 512    % 3d-plot
          mesh(xax,yax,vec');
          ylabel(ylab);
        case 768    % stretched plot
          if isempty(par3)
            par3=0.0000001;
          end          
          if bitand(flags,8) == 0                
            plot(xax', vec+repmat(0:par3:par3*size(vec,2)-par3, size(vec,1),1)); %lin
          elseif bitand(flags,8+4+2) == 14
            plot(xax', vec+repmat(0:par3:par3*size(vec,2)-par3, size(vec,1),1)); % ERB
            setERBticks;
          else
            semilogx(xax',vec+repmat(0:par3:par3*size(vec,2)-par3, size(vec,1),1));  % log y-axis
          end
          ylabel([ylabnew '; separation: ' num2str(par3)]);
          if size(stimVec,2)>1
            if isempty(ylab)
              ylab='Item';
            end
            if isempty(yax)
              yax=0:size(stimVec,2)-1;
            end
            if size(stimVec,2)<30  % show legend only for less than 30 items
              c=cell(size(stimVec,2),1);
              for ii=1:size(stimVec,2)
                c{ii}=[ylab ': ' num2str(yax(ii))];
              end
              legend(c, 'Location', 'Best');
            end
          end
          if ~isempty(axi)
            axis(axi(1:4));
          end      
        case 1024   % surface                  
          surf(xax,yax,vec');
          shading interp;
          ylabel(ylab);
          if ~isempty(axi)
            axis(axi(1:4));
            if length(axi)==6
              caxis([axi(5) axi(6)]);
            end
          end      
          colorbar;
      end
      xlabel(xlab);
      title(ttitle);
      zoom on;
    end % time/freq domain
  end % check matrix mode
end % switch gen mode
warning('on','all');

% ------------------------------------------------------------------------
function [xax,xlab]=ScaleXTime(stimVec,flags,fs)
  xax = 0:size(stimVec,1)-1;
  xlab = 'time in samples';
  switch bitand(flags,8+4+2) % check scaling of the x-axis
  case 2
    xax=0:1/fs:(size(stimVec,1)-1)/fs;
    xlab='time in s';
  case 4
    xax=0:1000/fs:1000*(size(stimVec,1)-1)/fs;
    xlab='time in ms';
  case 6
    xax=0:1000000/fs:1000000*(size(stimVec,1)-1)/fs;
    xlab='time in us';
  end                  
  
% ------------------------------------------------------------------------
function [vec,ylab]=ScaleData(stimVec,flags,~)
  vec=stimVec;  % check scaling of the y-axis
  ylab='data (linear)';
  switch bitand(flags,112)
    case 16
      vec=abs(vec);
      ylab='absolute values of data';
    case 32
      vec=20*log10(abs(vec));
      ylab='data in dB(RMS)';
    case 48
      if length(size(vec))==3
        vec=vec(:,:,1)-vec(:,:,2);
      elseif length(size(vec))==2
        vec=vec(:,1)-vec(:,2);
      else
        error('Scale data to difference: Input must be a matrix with at least two vectors');
      end
      ylab='difference';
    case 64
      if length(size(vec))==3
        vec=abs(vec(:,:,1))-abs(vec(:,:,2));
      elseif length(size(vec))==2
        vec=abs(vec(:,1))-abs(vec(:,2));
      else
        error('Scale data to absolute difference: Input must be a matrix with at least two vectors');
      end
      ylab='absolute difference';
    case 80
      if length(size(vec))==3
        vec=20*log10(abs(vec(:,:,1)-vec(:,:,2)));
      elseif length(size(vec))==2
        vec=20*log10(abs(vec(:,1)-vec(:,2)));
        ylab='absolute difference, in dB(RMS)';
      else
        error('Scale data to abs. difference in dB(RMS): Input must be a matrix with at least two vectors');
      end
    case 96
      vec=20*log10(abs(vec./max(max(abs(vec)))));
      ylab='normalized data in dB(RMS)';
  end

% ------------------------------------------------------------------------  
function [vec,xax,xlab]=ScaleXFreq(stimVec,flags,fs)
  vec = abs(fft(stimVec));
  vec=vec(1:end/2,:,:);
  xax=0:size(vec,1)-1;
  xlab='frequency in bins up to fs/2';               
  switch bitand(flags,8+4+2)  % check scaling of the x-axis
    case {2, 10}
      xax=0:fs/size(stimVec,1):fs/size(stimVec,1)*(size(vec,1)-1);
      xlab='frequency in Hz';
    case {4, 12}
      xax=0:fs/size(stimVec,1)/1000:fs/size(stimVec,1)*(size(vec,1)-1)/1000;
      xlab='frequency in kHz';
    case 6
      xax=log10(1:size(xfa,1));
    case 14
      xax=0:fs/size(stimVec,1):fs/size(stimVec,1)*(size(vec,1)-1);
      xax=21.4*log10(4.37*xax/1000+1);  % convert to ERB
      xlab='frequency in kHz, ERB scaled';
  end                

% ------------------------------------------------------------------------

function setERBticks()
    % label x axis correct 
tick=get(gca,'XTick');      % get the ticks of plot/pcolor
ticklab=cell(1,size(tick,2));
fc=(10.^(tick/21.4)-1)/4.37*1000;   % return them to f
labs=[100 200 500 1000 2000 5000 10000 15000 20000];    % mask of possible labels, sorted asc.
ii= labs>min(fc);
labsmin=labs(ii);
ii= labsmin<max(fc);
lim=(10.^(get(gca,'XLim')/21.4)-1)/4.37*1000;   % find bounds of axes
labs=[min(lim) labsmin(ii) max(lim)];    % set all frequencies to label
erb=21.4*log10(4.37*labs/1000+1);        % transform to erb
set(gca,'XTickMode','manual');
set(gca,'XTick',erb);                       % and set ticks
for ii=1:length(labs);
    ticklab(ii)={sprintf('%2.1f',labs(ii)/1000)};   % and labels in kHz
end
set(gca,'XTickLabelMode','manual');
set(gca,'XTickLabel',ticklab);

grid on;        % show grid, just for fun
set(gca,'Layer','top');
