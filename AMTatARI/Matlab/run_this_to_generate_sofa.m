
% This script is copied to every new measurement folder so you can 
% conveniently generate the SOFA files from Matlab.

%% Settings (EDIT AS NEEDED)

name     = 'MyHRTF';          
doplots  = 1; % Show some plots
saveRaw  = 1; % Save raw HRTF (50ms long, no window) in SOFA format (0,1)
saveWin  = 1; % Save windowed HRTF (5ms long with fade in/out) in SOFA format (0,1)
saveEQ   = 1; % Save HRTF equalised by free field measurement in SOFA format (0,1)
saveEQmp = 1; % Same as above, but use minimum-phase EQ (0,1)
saveITD  = 1; % Save time-aligned HRTFs in SOFA and 3DTI formats (0,1)
targetFs = [44100,48000,96000]; % Sampling frequency (Hz)

reference_eq = '../../Reference measurements/reference_eq.mat'; % you usually don't want to change this

%% Run
thisdir = cd;
amt_start();
cd(thisdir);
AA_GenerateSOFA(name,'.','settings.AMTatARI','itemlist.itl.csv',reference_eq,doplots,saveRaw,saveWin,saveEQ,saveEQmp,saveITD,targetFs)
AA_GenerateHpEQ(name,'.','settings.AMTatARI','itemlist.itl.csv',doplots,targetFs)