;ExpSuite Installation packages - software installer for ExpSuite applications
;Copyright (C) 2010-2021 Acoustics Research Institute - Austrian Academy of Sciences; Guillem Quer Romeo, Michael Mihocic
;Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
;You may not use this work except in compliance with the Licence.
;You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
;Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
;See the Licence for the specific language governing  permissions and limitations under the Licence.

;****Preprocessor****
;See http://www.jrsoftware.org/ispphelp/
#include <it_download.iss>
#define DXRequired "4.04.00.0904" ; \
  We look for the application executable in order to get the name and all the necessary information such as the GUID and the AppVersion.
#define AppName StringChange(FindGetFileName(FindFirst('..\bin\*.exe',0)),".exe","")
#define GUID "{"+GetStringFileInfo('..\bin\'+AppName+'.exe',"ProductName")+"}"
#define AppVersion GetFileVersion('..\bin\'+AppName+'.exe')
#define AppCopyRight GetFileCopyright('..\bin\'+AppName+'.exe') ; \
  ; \
  We check if the setup is being run by the Installer assistant, and if so, we'll take the path set in the installer assistant as installation directory.
#define EIA ReadReg(HKEY_LOCAL_MACHINE, 'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{EB6EABF9-56E9-430D-96C3-E365AA6A50CB}_is1','InstallLocation')
#if EIA
  #define AppPath ReadReg(HKEY_LOCAL_MACHINE, 'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{EB6EABF9-56E9-430D-96C3-E365AA6A50CB}_is1','InstallLocation')
#else
  #define AppPath '{pf}\ExpSuite\'+AppName
#endif ; \
  We'll look for up to six pdf documents in order to include them to the start menu.

#define pdf1
#define pdf2
#define pdf3
#define pdf4
#define pdf5
#define pdf6
#define FindHandle FindFirst('..\doc\*.pdf',0) ; \
  ; \
  If there's one or more pdf files we won't get any memory access violation. Otherwise we must skip looking for more pdf files.
#if FindHandle!=0
  #define pdf1 StringChange(FindGetFileName(FindHandle),".pdf","")
  #expr FindNext(FindHandle)
  #define pdf2 StringChange(FindGetFileName(FindHandle),".pdf","")
  #expr FindNext(FindHandle)
  #define pdf3 StringChange(FindGetFileName(FindHandle),".pdf","")
  #expr FindNext(FindHandle)
  #define pdf4 StringChange(FindGetFileName(FindHandle),".pdf","")
  #expr FindNext(FindHandle)
  #define pdf5 StringChange(FindGetFileName(FindHandle),".pdf","")
  #expr FindNext(FindHandle)
  #define pdf6 StringChange(FindGetFileName(FindHandle),".pdf","")
#endif ; \
  ****Inno Setup Script**** ; \
  See http://www.innosetup.org/ishelp/
[Setup]
AppId={{#GUID}
AppName={#AppName}
AppVersion={#AppVersion}
VersionInfoVersion={#AppVersion}
AppVerName=ExpSuite - {#AppName} {#AppVersion}
AppPublisher=Acoustics Research Institute - Austrian Academy of Sciences
AppPublisherURL=https://www.oeaw.ac.at/isf/
AppSupportURL=https://www.oeaw.ac.at/isf/expsuite/
AppUpdatesURL=https://sourceforge.net/projects/expsuite/files/Applications/{#AppName}
AppReadmeFile=https://sourceforge.net/projects/expsuite/files/Applications/{#AppName}/history.txt
UsePreviousAppDir=yes
DefaultDirName={#AppPath}
DefaultGroupName=ExpSuite\{#AppName}
DisableProgramGroupPage=yes
LicenseFile=.\license.txt
OutputDir=..\..\FrameWork\SourceforgeReleases\Applications\{#AppName}\
OutputBaseFilename={#AppName}_setup_{#AppVersion}
Compression=lzma2/ultra64
SolidCompression=yes
SetupIconFile=..\Icon.ico
UninstallDisplayIcon={app}\{#AppName}.exe
AppCopyright={#AppCopyRight}
ChangesAssociations=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "..\bin\{#AppName}.exe"; DestDir: "{app}";
Source: "..\bin\*.dll"; DestDir: "{app}"; Flags: skipifsourcedoesntexist
Source: "..\MATLAB\*"; DestDir: "{app}\Matlab"; Flags: recursesubdirs createallsubdirs skipifsourcedoesntexist
Source: "..\Test\*"; DestDir: "{commonappdata}\Expsuite\{#AppName}\Test"; Flags: recursesubdirs createallsubdirs skipifsourcedoesntexist
Source: "..\doc\*"; DestDir: "{app}\doc"; Excludes: "*.rtf,*.sxw,*.odt,*.odg"; Flags: recursesubdirs createallsubdirs skipifsourcedoesntexist
Source: "..\Resources\Application\*"; DestDir: "{app}"; Flags: recursesubdirs createallsubdirs skipifsourcedoesntexist
Source: ".\inpout32.dll"; DestDir: "{win}"; Flags: onlyifdoesntexist sharedfile
Source: "..\history.txt"; DestDir: "{app}\doc";
Source: "..\FW\FWhistory.txt"; DestDir: "{app}\doc";

[Dirs]
Name: "{app}\doc"; Permissions: everyone-full
Name: "{app}\RIB2"; Permissions: everyone-full
Name: "{app}\MATLAB"; Permissions: everyone-full
Name: "{commonappdata}\Expsuite\{#AppName}"; Permissions: everyone-full

;Start Menu Items:
[Icons]
Name: "{group}\{#AppName}"; Filename: "{app}\{#AppName}.exe"
Name: "{group}\History"; Filename: "{app}\doc\history.txt"
Name: "{group}\{cm:UninstallProgram,{#AppName}}"; Filename: "{uninstallexe}"
Name: "{group}\{cm:ProgramOnTheWeb,Acoustics Research Institute}"; Filename: "https://www.oeaw.ac.at/isf/"
Name: "{commondesktop}\{#AppName}"; Filename: "{app}\{#AppName}.exe"; Tasks: desktopicon
;Only the found pdf files will be included (Flag createonlyiffileexists)
Name: "{group}\{#pdf1}"; Filename: "{app}\doc\{#pdf1}.pdf"; Flags: createonlyiffileexists
Name: "{group}\{#pdf2}"; Filename: "{app}\doc\{#pdf2}.pdf"; Flags: createonlyiffileexists
Name: "{group}\{#pdf3}"; Filename: "{app}\doc\{#pdf3}.pdf"; Flags: createonlyiffileexists
Name: "{group}\{#pdf4}"; Filename: "{app}\doc\{#pdf4}.pdf"; Flags: createonlyiffileexists
Name: "{group}\{#pdf5}"; Filename: "{app}\doc\{#pdf5}.pdf"; Flags: createonlyiffileexists
Name: "{group}\{#pdf6}"; Filename: "{app}\doc\{#pdf6}.pdf"; Flags: createonlyiffileexists

;Creating this registries we link the app extension to the app we just installed. We also create and open connected registry. This registries will be deleted when uninstalling (Flag uninsdeletekey)
[Registry]
Root: HKCR; Subkey: ".{#AppName}"; ValueType: string; ValueData: "{#AppName}"; Flags: uninsdeletekey
Root: HKCR; Subkey: "{#AppName}"; ValueType: string; ValueData: "{#AppName} Setting Files"; Flags: uninsdeletekey
Root: HKCR; Subkey: "{#AppName}\shell\Open\command"; ValueType: string; ValueData: """{app}\{#AppName}.exe"" ""%1"""; Flags: uninsdeletekey
Root: HKCR; Subkey: "{#AppName}\shell\Open Connected\command"; ValueType: string; ValueData: """{app}\{#AppName}.exe"" ""%1""/C"; Flags: uninsdeletekey
Root: HKCR; Subkey: "{#AppName}\DefaultIcon"; ValueType: string; ValueData: """{app}\{#AppName}.exe"",0"; Flags: uninsdeletekey

; Delete ExpSuite folder if it's the last app to be uninstalled.
[UninstallDelete]
Type: dirifempty; name: "{app}\.."

[Run]
Filename: "{app}\{#AppName}.exe"; Description: "{cm:LaunchProgram,{#StringChange(AppName, "&", "&&")}}"; Flags: shellexec postinstall skipifsilent; Check: Not LaunchMe
Filename: "{app}\{#AppName}.exe"; Description: "{cm:LaunchProgram,{#StringChange(AppName, "&", "&&")}}"; Flags: shellexec postinstall; Check: LaunchMe

;****Pascal Inno Setup Script section****
;See http://www.innosetup.org/ishelp/ (Pascal Scripting section)
[Code]

function LaunchMe(): Boolean;
begin
  Result := False;
    if ExpandConstant('{param:LaunchApp|False}') = 'True' then begin
      Result := True;
    end;
end;

//We define a new variable type in order to be able to return an array with a function.
type arrvaluedata = array[1..4] of integer;

//Function which calculates the potency of two given numbers. Note that does not handle the case base=0
//It's used to parse the version number. Called by the function ParseVersion()
function potency(base: integer; exponent: integer): integer;
var
i: integer;
begin
Result:=1;
for i:=1 to exponent do
  Result:= base*Result;
end;

//Function that standardizes versioning strings in order to be able to manage both three and four number versioning numbers.
//Limitations: so far it only accepts three and four number versioning: x.x.x or x.x.x.x
//To be able to manage also two or even one number version numbers include the following code:
//    else if dot=0 then result:= str+'.0.0.0'
//    else if dot=1 then result:= str+'.0.0'
function DefaultVersioning(str: string): string;
var
i: integer;
dot: integer;
begin
for i:=1 to length(str) do
  if str[i]='.' then dot:=dot+1;
if dot=2 then result:= str+'.0'
else if dot=3 then result:= str
else result:= '0.0.0.0'
end;

//This function gets a string containing any software versioning and returns an array with the numbers parsed. Used to compare versions.
function ParseVersion(value: string): arrvaluedata;
var
position: integer;
i: integer;
t: integer;
version: arrvaluedata;
begin
value:= value+'.';
repeat
  t:= t+1;
  position:= Pos('.',value);
  delete(value,position,1);
  for i:= position-1 downto 1 do
    begin
    version[t]:= version[t]+strtoint(value[i])*potency(10,position-i-1);
    delete(value,i,1);
    end;
until position=0;
Result:= version;
end;

//Gets two strings containing software versioning and returns true if first value data is higher than the second
function CompareVersions(string1: string; string2: string): boolean; //returns true if first value data is higher or equal than the second
var
valuedata1: arrvaluedata;
valuedata2: arrvaluedata;
finish: boolean;
i: integer;
begin
valuedata1:= ParseVersion(DefaultVersioning(string1));
valuedata2:= ParseVersion(DefaultVersioning(string2));
repeat
  i:= i+1;
  if (valuedata1[i]<>valuedata2[i]) then finish:= True
  else finish:= False;
until ((finish) OR (i=4));
if (finish AND (valuedata1[i]<valuedata2[i])) then result:=False
else result:= True;
end;

//This function downloads the app history file and parses it in order to get the Newest Version number.
//It stores the history file in a temporary folder.
function GetNewestVersion(): string;
var
historyfile : AnsiString;
i: integer;
newest_version: string;
found: boolean;
begin
itd_downloadfile('http://heanet.dl.sourceforge.net/project/expsuite/Applications/{#AppName}/history.txt',expandconstant('{tmp}\{#AppName}.txt'));
loadstringfromfile(expandconstant('{tmp}\{#AppName}.txt'),historyfile);
found:= False;
if Pos('-', historyfile)<>0 then
  begin
  repeat
  i:= i+1;
  if (strtointdef(historyfile[i],0)<>0) OR (historyfile[i]='0') then
    if (historyfile[i+1]='.') or (historyfile[i+2]='.') or (historyfile[i+3]='.')  then
      if (historyfile[i-1]='v') and (historyfile[i-2]=' ') and (historyfile[i-3]='*') and (historyfile[i-4]='*') and (historyfile[i-5]='*') then
      found:=True;
  until found=True;
  repeat
    newest_version:= newest_version + historyfile[i];
    i:=i+1;
  until (strtointdef(historyfile[i],-1)=-1) and (historyfile[i]<>'.');
  end;
result:= DefaultVersioning(newest_version);
end;

//Function called by Inno Setup just before the setup is initialized
//We check if the computer has DirectX and .NetFramework installed before doing anything. We also check if there's any newer version available to download or if the user already has an equal or higher version installed in his computer.
//If the necessary software is not installed (that's DirectX and .NetFramework) the setup will be quited.
function InitializeSetup(): Boolean;
var
dxversion: string;
softversion: string;
path: string;
newest_version: string;
errorcode: integer;
begin
Result := True;
RegQueryStringValue(HKEY_LOCAL_MACHINE, 'SOFTWARE\Microsoft\DirectX\','Version', dxversion);
newest_version:= GetNewestVersion();

if CompareVersions('{#AppVersion}',newest_version)=False then
  if msgbox('A newer version of {#AppName} is available: {#AppName} v'+newest_version+#13#13'Would you like to download it?', mbConfirmation,MB_YESNO)=idYes then
    begin
    itd_downloadfile('http://heanet.dl.sourceforge.net/project/expsuite/Applications/{#AppName}/{#AppName}_setup_'+newest_version+'.exe',expandconstant('{tmp}\{#AppName}_setup_'+newest_version+'.exe'));
    shellexec('',expandconstant('{tmp}\{#AppName}_setup_'+newest_version+'.exe'),' ',' ',SW_SHOW,ewNoWait,errorcode);
    result:= False;
    end;
//Assuming the app extension is linked to the application we search for the executable reading the registry and take the version number to compare it with the one we're going to install.
if (RegKeyExists(HKEY_CLASSES_ROOT, '{#AppName}') = True) and (Result=True) then
  begin
  RegQueryStringValue(HKEY_CLASSES_ROOT, '{#AppName}\DefaultIcon','', path);
  StringChangeEx(path,'"','',True);
  StringChangeEx(path,',0','',True);
  GetVersionNumbersString(path,softversion);
  if CompareVersions(softversion,'{#AppVersion}')=True then
    if msgbox('You already have an equal or higher version of {#AppName} installed.'#13#13'Do you want to quit the setup?',mbConfirmation,MB_YESNO)= idYes then Result:=False;
  end;

if CompareVersions(dxversion,'{#DXrequired}')=False then
  begin
  MsgBox ('DirectX 9.0c or higher is required', mbError, MB_OK);
  Result := False;
  end;

if (RegKeyExists(HKEY_LOCAL_MACHINE, 'SOFTWARE\Microsoft\.NETFramework') = False) and (Result=True) then
  begin
  MsgBox('.NET Framework is not installed on your computer.',mbError, MB_OK);
  Result := False;
  end;
end;

//Function called everytime next button is clicked.
//If a prev version of the software was installed and the user chooses a diferent directory (to keep two software versions in the same computer for example) we warn the user about what we're going to do.
function NextButtonClick(CurPageID: Integer): Boolean;
var
path: string;
begin
//Check for extension to be linked with application
Result := True;
if (CurPageID = wpSelectDir) and (RegKeyExists(HKEY_CLASSES_ROOT, '{#AppName}')=True)then
  begin
  //Again we assume the app extension is linked to the app if installed
  RegQueryStringValue(HKEY_CLASSES_ROOT, '{#AppName}\DefaultIcon','', path);
  //We need to modify the string got from the registry in order to compare it with the one entered in the wizard. That is ereasing AppName.exe from the path and some other characters.
  StringChangeEx(path,'"','',True);
  StringChangeEx(path,'\{#AppName}.exe,0','',True);
  if comparestr(path,expandconstant('{app}'))<>0 then
    begin
    if (MsgBox ('You are choosing a diferent directory for {#AppName}.'#13#13'Everything will be linked to this installed version and you will have to manually uninstall the other versions.'#13#13'Do you want to continue?', mbConfirmation, MB_YESNO)=idNo) then
      //Returning False will avoid from continuing to the next wizard page.
      Result:= False;
    end;
  end;
end;

//Skips the select app dir, license & finished/run pages if ExpSuite Installer assistant is running (useless if running in silent or verysilent modes)
//Obsolete so far by the way the setup is being called by the installer assistant.
function ShouldSkipPage(PageID: Integer): Boolean;
begin
if ((PageID = wpLicense)AND (RegKeyExists(HKEY_LOCAL_MACHINE, 'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{EB6EABF9-56E9-430D-96C3-E365AA6A50CB}_is1')))OR((PageID = wpSelectDir) AND (RegKeyExists(HKEY_LOCAL_MACHINE, 'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{EB6EABF9-56E9-430D-96C3-E365AA6A50CB}_is1')))OR((PageID = wpFinished) AND (RegKeyExists(HKEY_LOCAL_MACHINE, 'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{EB6EABF9-56E9-430D-96C3-E365AA6A50CB}_is1'))) then
  Result:= True
end;

//Ask for option files to be deleted or not. They're expected to be in All Users App data.
//It also tries to delete ExpSuite folder if it's empty.
//Note 1: The whole folder is deleted
//Note 2: In this case we're deleting a folder which we especially created to store the option files. But note that under any circumstance we want to "simply" delete all what's inside the installation directory. Imagine the consequences if C:\Windows is the installation directory
procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
var
mRes : integer;
//path : string;
//machine_name: string;
//file_path: string;
begin
  case CurUninstallStep of
    usUninstall:
      begin
        mRes := MsgBox('Do you want to delete your option files?', mbConfirmation, MB_YESNO or MB_DEFBUTTON2)
        if mRes = IDYES then
          begin
            DelTree(expandconstant('{commonappdata}')+'\Expsuite\{#AppName}',True,True,True);
            RemoveDir(expandconstant('{commonappdata}')+'\Expsuite')
//            MsgBox ('Option files removed', mbInformation, MB_OK);
          End
        else
//          MsgBox ('Option files will not be removed', mbInformation, MB_OK);
      end;
  end;
end;
