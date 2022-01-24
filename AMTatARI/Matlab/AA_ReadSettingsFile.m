function settings = AA_ReadSettingsFile(settingsfile)

% Read settings file and put contents in cell array
fid = fopen(settingsfile);
linecount = 1;
while 1
    tline = fgetl(fid);
    if ~ischar(tline)
        break
    end
    tmp = strsplit(tline,'=');
    A(linecount,1) = string(tmp{1});
    A(linecount,2) = string(tmp{2});
    linecount = linecount + 1;
end
fclose(fid);

% Extract source list
ind = find(A(:,1)=="Frequency List Left");
for i=1:numel(ind)
    tmp = str2num(A(ind(i),2));
    settings.srcList(i,1) = i; % source index
    settings.srcList(i,2) = tmp(1); % elevation in deg
    settings.srcList(i,3) = tmp(3); % latency in us
end

% Extract azimuth list
ind = find(A(:,1)=="Azimuth group List");
for i=1:numel(ind)
    settings.azList(i) = str2num(A(ind(i),2));
end

% Extract ISD list
ind = find(A(:,1)=="ISD List");
for i=1:numel(ind)
    settings.isdList(i) = str2num(A(ind(i),2));
end

% Extract IR length in ms
ind = find(A(:,1)=="Length of IRs");
settings.irLen = str2num(A(ind,2));

% Extract IR offsets in ms
ind1 = find(A(:,1)=="Begin offset of IR");
settings.irOffset(1) = str2num(A(ind1,2));
ind2 = find(A(:,1)=="End offset of IR");
settings.irOffset(2) = str2num(A(ind1,2));

% Extract sampling rate
ind = find(A(:,1)=="Sampling Rate");
settings.fs = str2num(A(ind,2));

% Extract initial check absolute threshold
ind = find(A(:,1)=="Initial IR check absolute threshold");
if ~isempty(ind)
    settings.initial_check_target_gain = str2num(A(ind,2));
else
    settings.initial_check_target_gain = [];
end

% Extract initial check left/right threshold
ind = find(A(:,1)=="Initial IR check left/right threshold");
if ~isempty(ind)
    settings.initial_check_lr_dif = str2num(A(ind,2));
else
    settings.initial_check_lr_dif = [];
end
