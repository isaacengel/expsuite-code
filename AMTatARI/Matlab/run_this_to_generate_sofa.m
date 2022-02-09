
% This script is copied to every new measurement folder so you can 
% conveniently generate the SOFA files from Matlab.

%% Settings (EDIT AS NEEDED)

name     = 'MyHRTF';          
doplots  = 1;       % Show some plots
saveRaw  = 1;       % Save HRTF in SOFA format (0,1)
saveEQ   = 0;       % Save HRTF equalised by reference in SOFA format (0,1)
saveEQmp = 0;       % Same as above, but use minimum-phase EQ (0,1)
saveITD  = 0;       % Save time-aligned HRTF in SOFA format (0,1)
save3DTI = 0;       % Save time-aligned HRTF in .3dti format (0,1)
targetFs = 96000;   % Sampling frequency (Hz)

reference_eq = '../Reference measurements/reference_eq.mat'; % you usually don't want to change this

%% Run
thisdir = cd;
amt_start();
cd(thisdir);
AA_GenerateSOFA(name,'.','settings.AMTatARI','itemlist.itl.csv',reference_eq,doplots,saveRaw,saveEQ,saveEQmp,saveITD,save3DTI,targetFs)
AA_GenerateHpEQ(name,'.','settings.AMTatARI','itemlist.itl.csv',doplots,targetFs)