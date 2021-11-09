Option Strict On
Option Explicit On
#Region "ExpSuite License"
'ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
'Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
'Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
'You may not use this work except in compliance with the Licence. 
'You may obtain a copy of the Licence at: http://joinup.ec.europa.eu/software/page/eupl
'Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
'See the Licence for the specific language governing  permissions and limitations under the Licence. 
#End Region
''' <summary>
''' FrameWork - Declarations and general methods.
''' </summary>
''' <remarks></remarks>
Module FWintern
    ''' <summary>
    ''' Major version number of framework.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const FW_MAJOR As Short = 1
    ''' <summary>
    ''' Minor version number of framework.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const FW_MINOR As Short = 1
    ''' <summary>
    ''' Revision of framework.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const FW_REVISION As Short = 52
    ''' <summary>
    ''' Label of the framework branch. Put your own label here if your branch differs from the original release.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const FW_BRANCH As String = ""
    ''' <summary>
    ''' Status bar fields.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const STB_STATUS As Short = 0
   ''' <summary>
    ''' Status bar fields.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const STB_LEFT As Short = 1
   ''' <summary>
    ''' Status bar fields.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const STB_RIGHT As Short = 2
   ''' <summary>
    ''' Status bar fields
    ''' </summary>
    ''' <remarks></remarks>
    Public Const STB_ELAPSEDTIME As Short = 3
   ''' <summary>
    ''' Status bar fields.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const STB_REMAININGTIME As Short = 4
   ''' <summary>
    ''' Status bar fields.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const STB_REALTIME As Short = 5
    ''' <summary>
    ''' Text in the experimental screen showing seconds until a break.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const TEXT_BREAKSECONDS As String = " Sekunden bis zur Pause"
   ''' <summary>
    ''' Text in the experimental screen showing one minute until a break.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const TEXT_BREAKMINUTE As String = "1 Minute bis zur Pause"
   ''' <summary>
    ''' Text in the experimental screen showing minutes until a break.
    ''' </summary>
    ''' <remarks></remarks>
    ''' <seealso cref="gvarExp"/>
    Public Const TEXT_BREAKMINUTES As String = " Minuten bis zur Pause"
    ''' <summary>
    ''' Define if dark mode (for example for EEG) will be used. Will cause a black screen in experiment window.
    ''' </summary>
    ''' <remarks>true = dark mode on; default: false</remarks>
    Public gbDarkMode As Boolean

    Public Const rLEFT As Short = 0
    Public Const rRIGHT As Short = 1
    Public Const rSTART As Short = 256
    Public Const rNEXT As Short = 257
    Public Const rCANCEL As Short = 258

   ''' <summary>
    ''' Structure for the synthesizer (Settings/Audio).
    ''' </summary>
    ''' <remarks>This structure describes all parameters of a synthesizer unit, which can be set
    ''' in Settings/Audio.
    ''' There are 2 synthesizer units available via YAMI at the moment.
    ''' The parameters are saved in gAudioSynth() with the number of synthesizer unit as index.
    ''' Depending on the type of signal addition parameter Par1 may be used.
    ''' The signal is band passed with between LowCut and HighCut frequencies.</remarks>
    Public Structure AudioSynth
        ''' <summary>
        ''' Signal Type of signal to generate: <li>0: Not used</li><li>1: Pink noise</li><li>2: White noise</li><li>3: Cosine</li><li>4: Low pass filtered white noise, 4th order butterworth</li><li>5: Low pass filtered white noise, 16th order butterworth</li>
        ''' </summary>
        ''' <remarks></remarks>
        Dim Signal As Integer
        ''' <summary>
        ''' Upper cut off frequency [Hz]
        ''' </summary>
        ''' <remarks></remarks>
        Dim HighCut As Double
        ''' <summary>
        ''' LowCut Lower cut off frequency [Hz]
        ''' </summary>
        ''' <remarks></remarks>
        Dim LowCut As Double
        ''' <summary>
        ''' Additional parameter depending on Signal. Frequency [Hz] for Signal = Cosine; Low cut off frequency [Hz] for Signal = LP white noise.
        ''' </summary>
        ''' <remarks></remarks>
        Dim Par1 As Double
        ''' <summary>
        ''' Volume in dB FS.
        ''' </summary>
        ''' <remarks></remarks>
        Dim Vol As Double
    End Structure


   ''' <summary>
    ''' Structure for an experimental Variable (Settings/Variable)
    ''' </summary>
    ''' <remarks>This structure describes all properties of a variable which can be found in Settings/Variables.
    ''' The data are saved in gvarExp() with the variable index as index.
    ''' gvarExp() must be resized to the proper length and set correctly in:
    ''' <li>Events.OnLoad</li>
    ''' <li>Callback on change or load of settings</li>
    ''' <li>Callback on change of experiment type</li></remarks>
    ''' <seealso cref="gvarExp"/>
    Public Structure ExpVariable
        ''' <summary>
        ''' Array containing the values set in Settings/Variables.
        ''' </summary>
        ''' <remarks></remarks>
        Dim varValue() As String
        ''' <summary>
        ''' Description of the variable, more than one line allowed.
        ''' </summary>
        ''' <remarks></remarks>
        Dim szDescription As String
        ''' <summary>
        ''' Name of the variable. Use a short name.
        ''' </summary>
        ''' <remarks></remarks>
        Dim szName As String
        ''' <summary>
        ''' Unit of the variable. Leave blank if not used.
        ''' </summary>
        ''' <remarks></remarks>
        Dim szUnit As String
        ''' <summary>
        ''' Default values. Leave blank if not used. Separate by ; for more values.
        ''' </summary>
        ''' <remarks></remarks>
        Dim szDefault As String
        ''' <summary>
        ''' Flags restricting the values, see VariableFlags for more details.
        ''' </summary>
        ''' <remarks></remarks>
        Dim Flags As VariableFlags
        ''' <summary>
        ''' Minimum value, if the restriction vfMin was set.
        ''' </summary>
        ''' <remarks></remarks>
        Dim dMin As Double
        ''' <summary>
        ''' Maximum value, if the restriction vfMax was set.
        ''' </summary>
        ''' <remarks></remarks>
        Dim dMax As Double
    End Structure

   ''' <summary>
    ''' Structure for an experimental Constant (Settings/Constants)
    ''' </summary>
    ''' <remarks>This structure describes all properties of a constant which can be found in Settings/Constants.
    ''' The data are saved in gconstExp() with the constant index as index.
    ''' gconstExp() must be resized to the proper length and set correctly in:
    ''' <li>Events.OnLoad</li>
    ''' <li>Callback on change or load of settings</li>
    ''' <li>Callback on change of experiment type</li></remarks>
    Public Structure ExpConstant
        ''' <summary>
        ''' The values set in Settings/Constants.
        ''' </summary>
        ''' <remarks></remarks>
        Dim varValue As String
        ''' <summary>
        ''' Default value.
        ''' </summary>
        ''' <remarks></remarks>
        Dim varDefault As String
        ''' <summary>
        ''' Description of the constant, appears in a tooltip of the constant.
        ''' </summary>
        ''' <remarks></remarks>
        Dim szDescription As String
        ''' <summary>
        ''' Name of the constant. Use a short name.
        ''' </summary>
        ''' <remarks></remarks>
        Dim szName As String
        ''' <summary>
        ''' Unit of the constant. Leave blank if not used.
        ''' </summary>
        ''' <remarks></remarks>
        Dim szUnit As String
        ''' <summary>
        ''' Flags restricting the values, see VariableFlags for more details.
        ''' </summary>
        ''' <remarks></remarks>
        Dim Flags As VariableFlags
        ''' <summary>
        ''' Minimum value, if the restriction vfMin was set.
        ''' </summary>
        ''' <remarks></remarks>
        Dim dMin As Double
        ''' <summary>
        ''' Maximum value, if the restriction vfMax was set.
        ''' </summary>
        ''' <remarks></remarks>
        Dim dMax As Double
    End Structure


   ''' <summary>
    ''' Flags to restrict the content of Constants or Variables.
    ''' </summary>
    ''' <remarks>Select the type of content (string, numeric, directory of file name) and then use a proper
    ''' restriction. The Variables can be linked to each other, which means, that number of values in one variable
    ''' must match the number of values in another one. E.g. link Amplitude and Electrode, if for every electrode another amplitude must exist.</remarks>
    Public Enum VariableFlags
        ' flag types
        ''' <summary>
        ''' Constant/Variable is a string. See String flags for further restrictions.
        ''' </summary>
        ''' <remarks></remarks>
        vfString = 0
        ''' <summary>
        ''' Constant/Variable is numeric. See Numeric flags for further restrictions.
        ''' </summary>
        ''' <remarks></remarks>
        vfNumeric = 3
        ''' <summary>
        ''' Constant/Variable is a directory.
        ''' </summary>
        ''' <remarks></remarks>
        vfDirectory = 2
        ''' <summary>
        ''' Constant/Variable is a file name. See Filename flags for further restrictions. Use the Unit parameter to set the file name mask (e.g. *.txt)
        ''' </summary>
        ''' <remarks></remarks>
        vfFileName = 1
        ''' <summary>
        ''' Constant/Variable is a left electrode from Settings/Signal. On default, the AMP is checked to be between THR and MCL.
        ''' </summary>
        ''' <remarks></remarks>
        vfElectrodeL = 4
        ''' <summary>
        ''' Constant/Variable is a right electrode from Settings/Signal. See Electrode flags for further restrictions.
        ''' </summary>
        ''' <remarks></remarks>
        vfElectrodeR = 5
        ''' <summary>
        ''' Mask of the flag type. Use "MyFlags AND vfFlagTypeMask" to retrieve the type of the flag.
        ''' </summary>
        ''' <remarks></remarks>
        vfFlagTypeMask = &HF
        ' numeric only
        ''' <summary>
        ''' Restrict to integer.
        ''' </summary>
        ''' <remarks></remarks>
        vfInteger = &H10
        ''' <summary><c>Numeric Flags: </c>
        ''' Must not be zero.
        ''' </summary>
        ''' <remarks></remarks>
        vfNonZero = &H20
        ''' <summary><c>Numeric Flags: </c>
        ''' Must be positive integer.
        ''' </summary>
        ''' <remarks></remarks>
        vfMinTimeDelay = &H100
        ''' <summary><c>Numeric/Electrode Flags: </c>
        ''' Sets a restriction to a minimum value. Use the Min parameter to set the range.
        ''' </summary>
        ''' <remarks></remarks>
        vfMin = &H200
        ''' <summary><c>Numeric/Electrode Flags: </c>
        ''' Sets a restriction to a maximum value. Use the Max parameter to set the range.
        ''' </summary>
        ''' <remarks></remarks>
        vfMax = &H400
        ''' <summary><c>Numeric Flags: </c>
        ''' The value is dependent on the Offset parameter in Settings/Procedure.
        ''' </summary>
        ''' <remarks></remarks>
        vfOffsetDependent = &H800
        ''' <summary><c>Electrode Flags: </c>
        ''' Content can be a vector of electrodes, separated by blank or semicolon (not both!).
        ''' </summary>
        ''' <remarks></remarks>
        vfVectorized = &H1000
        ' electrode only
        ''' <summary><c>Electrode Flags: </c>
        ''' Do not check the AMP field to be higher then the THR field (from Settings/Signal)
        ''' </summary>
        ''' <remarks></remarks>
        vfNoTHRCheck = &H10
        ''' <summary><c>Electrode Flags: </c>
        ''' Do not check the AMP field to be higher then the MCL field (from Settings/Signal)
        ''' </summary>
        ''' <remarks></remarks>
        vfNoMCLCheck = &H20
        '  vfMin = &H200&
        '  vfMax = &H400&
        '  vfVectorized = &H1000&
        ' non-numeric only
        ''' <summary><c>String Flags: </c>
        ''' Content must not be empty.
        ''' </summary>
        ''' <remarks></remarks>
        vfNonEmpty = &H10
        ''' <summary><c>String Flags: </c>
        ''' Content must be chosen one from a list given in Unit string. Use the Unit parameter to set the list of atoms selected by ;
        ''' </summary>
        ''' <remarks></remarks>
        vfEnumeration = &H20
        ''' <summary><c>String Flags: </c>
        ''' Content is case sensitive.
        ''' </summary>
        ''' <remarks></remarks>
        vfCaseSensitive = &H40
        ''' <summary><c>String Flags: </c>
        ''' Content will be converted to upper case.
        ''' </summary>
        ''' <remarks></remarks>
        vfUpperCase = &H80
        ''' <summary><c>String Flags: </c>
        ''' Content will be converted to lower case.
        ''' </summary>
        ''' <remarks></remarks>
        vfLowerCase = &H100
        ' filename only
        ''' <summary><c>File name Flags: </c>
        ''' Absolute file name including path name.
        ''' </summary>
        ''' <remarks></remarks>
        vfAbsolute = &H0
        ''' <summary><c>File name Flags: </c>
        ''' File name, relative to the data directory #1 (index = 0)
        ''' </summary>
        ''' <remarks></remarks>
        vfRelativeDataDir1 = &H10
        ''' <summary><c>File name Flags: </c>
        ''' File name, relative to the data directory #2 (index = 1)
        ''' </summary>
        ''' <remarks></remarks>
        vfRelativeDataDir2 = &H20
        ''' <summary><c>File name Flags: </c>
        ''' File name, relative to the data directory #3 (index = 2)
        ''' </summary>
        ''' <remarks></remarks>
        vfRelativeDataDir3 = &H30
        ''' <summary><c>File name Flags: </c>
        ''' File name, relative to the data directory #4 (index = 3)
        ''' </summary>
        ''' <remarks></remarks>
        vfRelativeDataDir4 = &H40
        ''' <summary><c>File name Flags: </c>
        ''' File name, relative to the data directory #5 (index = 4)
        ''' </summary>
        ''' <remarks></remarks>
        vfRelativeDataDir5 = &H50
        ''' <summary><c>File name Flags: </c>
        ''' File name, relative to the data directory #6 (index = 5)
        ''' </summary>
        ''' <remarks></remarks>
        vfRelativeDataDir6 = &H60
        ''' <summary><c>File name Flags: </c>
        ''' File name, relative to the data directory #7 (index = 6)
        ''' </summary>
        ''' <remarks></remarks>
        vfRelativeDataDir7 = &H70
        ' system flags
        ''' <summary><c>System Flags: </c>
        ''' Constant will be hidden. Works for Constants only, use vfDisabled for Variables instead.
        ''' </summary>
        ''' <remarks></remarks>
        vfHidden = &H4000
        ''' <summary><c>System Flags: </c>
        ''' Constant/Variable will be disabled.
        ''' </summary>
        ''' <remarks></remarks>
        vfDisabled = &H8000
        ' linking flags (reserve 4 bits)
        ''' <summary><c>Link Flags: </c>
        ''' Use this flag to link variables to each other by multiplying this flag with the (index+1) of the linked variable. E.g. If the Amplitude is the third variable (gvarExp(2)) and you want to link Electrode to Amplitude, then the flag will be: vfLinked * 3. The link only to the first 15 variables is allowed.
        ''' </summary>
        ''' <remarks></remarks>
        vfLinked = &H10000
    End Enum

    Public Enum ServeDataEnum
        SendSettings1 = 0
        SendSettings = 1
        ChangeSettings1 = 2
        ChangeSettings = 3
        ItemlistColCountListStatus1 = 4
        ItemlistColCountListStatus = 5
        Itemlist = 6
        ListStatus = 7
        ChangeListStatus = 8
        ChangeItemStatus = 9
        ChangeItem = 10
        NextItem = 11
        Renumber = 12
        Clear = 13
        Close = 14
        StartExp = 15
        EveryItem = 16
        ThirdLast = 17
        SecondLast = 18
        LastItem = 19
        EndOfExperiment = 20
        ErrorInExperiment = 21
        Break = 22
        EndOfBlock = 23
    End Enum

    Public Enum ModeEnum As Integer
        SettingsFilename = 1
        DecodeSettings = 4
        LoadSettings = 5
        ChangeCell = 10
        Renumber = 20
        ChangeItemStatus = 30
        DecodeListStatus = 31
        SendStrings = 41
        SendBytes = 42
        DecodeNextItem = 43
        DecodeItemList = 44
        DecodeColumnHeaders = 45
        DecodeListandHeaders = 46
        'SetBufferSmall = 50
        'SetBufferMedium = 51
        'SetBufferLarge = 52
        CreateRows = 100
        ChangeToBlockingMode = 101
        'StillConnected = 666
        StartExperiment = 899
        BeepEveryItem = 900
        BeepThirdLast = 901
        BeepSecondLast = 902
        BeepLastItem = 903
        BeepEndOfExperiment = 904
        BeepError = 905
        BeepBreak = 906
        BeepBlockEnd = 907
        Disconnect = 1000
    End Enum

    Public Enum ItemListPostfixIndex
        piNothing = 0
        piFresh = 1
        piBegin = 2
        piResponse = 3
        piUser = 256
    End Enum

    Public Enum WarningSwitches
        wsNotShuffledOnExpStart = 1
        wsNotRepOnExpStart = 2
        wsExpPerformedOnShuffle = 4
        wsResponseItemListOnExpRep = 8
        RealTimeParameterChange = 16
    End Enum

    Public Enum AutomatisationFlags
        IgnoreOptionWarnings = 1
        IgnoreHUIWarnings = 2
        ContinueExperiment = 4
        StartAtSelectedItem = 8
    End Enum

    ' data used by framework
   ''' <summary>
    ''' Do we need to convert the VB6-framework settings to the .NET-framework settings?
    ''' </summary>
    ''' <remarks></remarks>
    Public gblnIsDotNETSetting As Boolean
   ''' <summary>
    ''' Fitt4Fun instances .
    ''' </summary>
    ''' <remarks></remarks>
    Friend F4FL As Implant
    ''' <summary>
    ''' Fitt4Fun instances .
    ''' </summary>
    ''' <remarks></remarks>
    Public F4FR As Implant
   ''' <summary>
    ''' Title of Settings.
    ''' </summary>
    ''' <remarks></remarks>
    Public gszSettingTitle As String
   ''' <summary>
    ''' File name of Settings.
    ''' </summary>
    ''' <remarks></remarks>
    Public gszSettingFileName As String
   ''' <summary>
    ''' Settings dialog visible/unvisible.
    ''' </summary>
    ''' <remarks></remarks>
    Public gblnSettingsForm As Boolean
   ''' <summary>
    ''' Settings changed?
    ''' </summary>
    ''' <remarks></remarks>
    Public gblnSettingsChanged As Boolean

    ''' <summary>
    ''' Settings loaded?
    ''' </summary>
    ''' <remarks></remarks>
    Public gblnSettingsLoaded As Boolean

    ''' <summary>
    ''' Settings loaded?
    ''' </summary>
    ''' <remarks></remarks>
    Public gblnSettingsLoaded1 As Boolean

    ''' <summary>
    ''' Settings loaded?
    ''' </summary>
    ''' <remarks></remarks>
    Public gblnSettingsLoaded2 As Boolean
    ''' <summary>
    ''' Connected to output?
    ''' </summary>
    ''' <remarks></remarks>
    Public gblnOutputStable As Boolean
   ''' <summary>
    ''' Show Stimulus before stimulation activated?
    ''' </summary>
    ''' <remarks></remarks>
    Public gblnShowStimulus As Boolean
   ''' <summary>
    ''' Cancel an action?
    ''' </summary>
    ''' <remarks>Cancel is: click on Cancel button (main form), ESC in an experiment</remarks>
    Public gblnCancel As Boolean
    ''' <summary>
    ''' Experiment running?
    ''' </summary>
    ''' <remarks></remarks>
    Public gblnExperiment As Boolean
    ''' <summary>
    ''' YAMI Version (YAMI returns version when connecting)
    ''' </summary>
    ''' <remarks></remarks>
    Public gszYamiVersion As String
   ''' <summary>
    ''' Sampling Rate of YAMI (Settings/Audio)
    ''' </summary>
    ''' <remarks></remarks>
    Public glPlayerSampleRate As Integer
   ''' <summary>
    ''' Must be TRUE to continue connection. See Events.OnConnect.
    ''' </summary>
    ''' <remarks></remarks>
    Public gblnConnectLeft As Boolean
   ''' <summary>
    ''' Must be TRUE to continue connection. See Events.OnConnect.
    ''' </summary>
    ''' <remarks></remarks>
    Public gblnConnectRight As Boolean
   ''' <summary>
    ''' Item List (Instance of clsItemList)
    ''' </summary>
    ''' <remarks></remarks>
    Public ItemList As clsItemList
   ''' <summary>
    ''' Data Directory (Instance of clsDataDirectory)
    ''' </summary>
    ''' <remarks></remarks>
    Public DataDirectory As clsDataDirectory
   ''' <summary>
    ''' Data Directory (Instance of clsDataDirectory)
    ''' </summary>
    ''' <remarks></remarks>
    Public AppResourcesDirectory As String
    ''' <summary>
    ''' Global FrameWork Directory (for shared files, e.g. wave, RIB2,...)
    ''' </summary>
    ''' <remarks></remarks>
    Public FwGlobalDir As String
   ''' <summary>
    ''' Ignore MIDI Messages.
    ''' </summary>
    ''' <remarks></remarks>
    Public gblnMIDIIgnore As Boolean

    Public gstLeft As STIMULUSPARAMETER
    Public gstRight As STIMULUSPARAMETER
    Public gblnFittLeftLoaded As Boolean
    Public gblnFittRightLoaded As Boolean
    Public gblnFirstExperiment As Boolean
    Public gblnStimulationDone As Boolean
    Public gcurHPFrequency As Long
    Public gcurHPTic As Long
    Public glOrder As Integer
    Public gblnSilenceCreated As Boolean
    Public gblnItemListShuffled As Boolean
    Public gblnItemListRepeated As Boolean
    Public glConnectionFlags As Integer

    Public Delegate Sub OnChangeDelegate(ByVal ExpType As Integer)
    Public glOnSettingsChangeAddr As OnChangeDelegate
    Public Delegate Sub OnSetDelegate()
    Public glOnSettingsSetAddr As OnSetDelegate
    Public Delegate Sub OnLoadDelegate()
    Public glOnSettingsLoadAddr As OnLoadDelegate
    Public Delegate Sub OnExpTypeChangeDelegate(ByVal lOld As Integer, ByVal lNew As Integer)
    Public glOnSettingsExpTypeChangeAddr As OnExpTypeChangeDelegate
    Public Delegate Sub OnOutputDeviceChangeDelegate(ByVal lOld As ExpSuite.GENMODE, ByVal lNew As ExpSuite.GENMODE)
    Public glOnOutputDeviceChangeAddr As OnOutputDeviceChangeDelegate
    Public Delegate Sub OnBreakDelegate()
    Public gOnBreakAddr As OnBreakDelegate

    Public Delegate Sub OnResponseDelegate(ByVal Response As Integer)

    Public piItemListPostfixIndex As ItemListPostfixIndex
    Public gszFileName As String
    ''Public glOutputPlay As Integer
    ''' <summary>
    ''' Bit Array where the corresponding channel is set to true when a play command is sent to pd.
    ''' When the channel finished playing pd will send a command that sets the channel bit to false again.
    ''' Channels start counting with 0. (0, 1, 2, ...)
    ''' </summary>
    ''' <remarks></remarks>
    Public glOutputPlay As New BitArray(PLAYER_MAXCHANNELS)
    Public glOutputRecord As Integer
    Public gblnOutputResponded As Boolean
    Public gblnRemoteMonitorServerEnabled As Boolean
    Public gszRemoteMonitorServerAdress As String
    Public gblnRemoteMonitorled As Boolean
    Public gblnRemoteClientConnected As Boolean
    Public gblnRemoteClientListen As Boolean
    Public gblnRemoteServerConnected As Boolean
    Public gblnRemoteConnectOutput As Boolean
    Public gblnRemoteBlockIncommingMessages As Boolean
    Public gblnRemoteServerDisconnected As Boolean
    Public gblnRemoteMonitorFollowCurrentItem As Boolean = True
    Public gblnRemoteMonitorUpdateSettings As Boolean
    Public gszGotSettings As String = ""
    Public gblnAcceptSettings As Boolean
    Public gblnRemoteClicked As Boolean
    Public glRemoteClickCounter As Integer = 0
    Public gblnTrackerLog As Boolean
    Public ddTemp As clsDataDirectory
    Public gfreqDef(1) As clsFREQUENCY
    Public gblnWaitAfterBreak As Boolean = False
    Public glAppendPulseTrainIndex As Integer = 0
    Public gszAppendPulseTrain As String = ""

    'Applicationtitle and version for checking Application in RemoteMonitor
    ''' <summary>
    ''' Application title.
    ''' </summary>
    ''' <remarks></remarks>
    Public gszAPP_TITLE As String
    ''' <summary>
    ''' Application version numer.
    ''' </summary>
    ''' <remarks></remarks>
    Public gszAPP_VERSION As String

    Public Const bufferSmall As Integer = 15
    Public Const bufferMedium As Integer = 127
    Public Const bufferLarge As Integer = 2047

    ' data about different types of experiment
   ''' <summary>
    ''' Array with names of experiment types.
    ''' </summary>
    ''' <remarks></remarks>
    Public gszExpTypeNames(ExpTypeNumber - 1) As String
   ''' <summary>
    ''' Mode of experiment for frmExp, contact Piotr...
    ''' </summary>
    ''' <remarks></remarks>
    Public glExpMode(ExpTypeNumber - 1) As Integer
   ''' <summary>
    ''' Number of intervals in a stimulus sequence
    ''' </summary>
    ''' <remarks></remarks>
    Public glExpIFC(ExpTypeNumber - 1) As Integer
   ''' <summary>
    ''' Alternative Forced Choices, number of possible responses.
    ''' </summary>
    ''' <remarks></remarks>
    Public glExpAFC(ExpTypeNumber - 1) As Integer
   ''' <summary>
    ''' Request text, appears in the experiment form.
    ''' </summary>
    ''' <remarks></remarks>
    Public gszExpRequestText(ExpTypeNumber - 1) As String
   ''' <summary>
    ''' Descriptions of response buttons, separated by ;
    ''' </summary>
    ''' <remarks></remarks>
    Public gszExpResponseNames(ExpTypeNumber - 1) As String
    ''' <summary>
    ''' Vocoder Type
    ''' </summary>
    ''' <remarks></remarks>
    Public VocType(2) As Integer

    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)

    ''' <summary>
    ''' Item List Extension
    ''' </summary>
    ''' <remarks>Must be defined by application developer in Config.bat. A leading dot ('.') is removed.</remarks>
    Public gszItemListExtension As String = ItemListExtension.TrimStart(CChar("."))


   ''' <summary>
    ''' High Precision Counter support.
    ''' </summary>
    ''' <param name="curStart">Old value of HP counter, WaitHP updates curStart to the new.</param>
    ''' <param name="lDelay">Optional delay in ms. If not given, WaitHP returns immediatly updating curStart only.</param>
    ''' <returns>Boolean. Canceled or not.</returns>
    ''' <remarks>WaitHP returns with the current value of the High Precision (HP) counter of Windows
    ''' and/or waits a given delay lDelay. <br>
    ''' Cancel button on the main window or HUI/Keyboard cancel the waiting.</br></remarks>
    Public Function WaitHP(ByRef curStart As Long, Optional ByVal lDelay As Integer = 0) As Boolean
        Dim curStop As Long = 0
        Dim lResp As Integer = 0
        If lDelay > 0 Then
            gblnCancel = False
            curStart += CLng(lDelay) * gcurHPFrequency \ 1000
            Do
                Windows.Forms.Application.DoEvents()
                QueryPerformanceCounter(curStop)
                If lResp = rCANCEL Then gblnCancel = True
            Loop Until curStop >= curStart Or gblnCancel
        End If
        QueryPerformanceCounter(curStart)
        WaitHP = gblnCancel

    End Function

   ''' <summary>
    ''' High Precision Counter support with deactivation.
    ''' </summary>
    ''' <param name="curStart">ld value of HP counter, WaitHP updates curStart to the new.</param>
    ''' <param name="lDelay">Optional delay in ms. If not given, WaitHP returns immediatly updating curStart only.</param>
    ''' <returns>Boolean. Canceled or not.</returns>
    ''' <remarks>WaitHP returns with the current value of the High Precision (HP) counter of Windows
    ''' and/or waits a given delay lDelay. <br>
    ''' Cancel button on the main window or HUI/Keyboard cancel the waiting.
    ''' Additional, the thread will be deactivated while waiting.</br></remarks>
    Public Function WaitSleepHP(ByRef curStart As Long, Optional ByVal lDelay As Integer = 0) As Boolean
        Dim curStop As Long
        Dim lResp As Integer
        If lDelay > 0 Then
            gblnCancel = False
            curStart += CLng(lDelay) * gcurHPFrequency \ 1000
            Sleep(lDelay)
            Do
                Windows.Forms.Application.DoEvents()
                QueryPerformanceCounter(curStop)
                If lResp = rCANCEL Then gblnCancel = True
            Loop Until curStop >= curStart Or gblnCancel
        End If
        QueryPerformanceCounter(curStart)
        WaitSleepHP = gblnCancel

    End Function



   ''' <summary>
    ''' Get the number of experimental constants.
    ''' </summary>
    ''' <returns>Number of experimental constants.</returns>
    ''' <remarks></remarks>
    Public Function GetUboundConstants() As Integer
        On Error GoTo NoArray

        If IsNothing(gconstExp) Then 'No constants
            GoTo NoArray
        Else
            Return UBound(gconstExp)
        End If
        On Error GoTo 0
NoArray:
        Return -1
        On Error GoTo 0
    End Function

   ''' <summary>
    ''' Get the number of experimental variables.
    ''' </summary>
    ''' <returns>Number of experimental variables.</returns>
    ''' <remarks></remarks>
    Public Function GetUboundVariables() As Integer
        If gvarExp Is Nothing Then Return -1
        Return UBound(gvarExp)
    End Function

    'Public Sub BeepOnEveryItem()
    '    Beep(1000, 100)
    'End Sub

    'Public Sub BeepOnThird()
    '    Beep(1000, 100)
    '    Beep(50, 200)
    '    Beep(1000, 100)
    'End Sub
    'Public Sub BeepOnSecond()
    '    Beep(1000, 100)
    '    Beep(50, 200)
    '    Beep(1000, 100)
    '    Beep(50, 200)
    '    Beep(1000, 100)
    'End Sub
    'Public Sub BeepOnLast()
    '    Beep(1000, 100)
    '    Beep(50, 200)
    '    Beep(1000, 100)
    '    Beep(50, 200)
    '    Beep(1000, 100)
    '    Beep(50, 200)
    '    Beep(1000, 100)
    'End Sub
    Public Sub PlayWaveOnEnd()
        If My.Computer.FileSystem.FileExists(AppResourcesDirectory & "\endofexperiment.wav") Then
            My.Computer.Audio.Play(AppResourcesDirectory & "\endofexperiment.wav", AudioPlayMode.Background)
            'ElseIf My.Computer.FileSystem.FileExists("..\Resources\endofexperiment.wav") Then
            '    My.Computer.Audio.Play("..\Resources\endofexperiment.wav", AudioPlayMode.Background)
        End If
    End Sub

    Public Sub PlayWaveOnBreak()
        If My.Computer.FileSystem.FileExists(AppResourcesDirectory & "\break.wav") Then
            My.Computer.Audio.Play(AppResourcesDirectory & "\break.wav", AudioPlayMode.Background)
            'ElseIf My.Computer.FileSystem.FileExists("..\Resources\endofexperiment.wav") Then
            '    My.Computer.Audio.Play("..\Resources\endofexperiment.wav", AudioPlayMode.Background)
        End If
    End Sub

    Public Sub PlayWaveOnError()
        If My.Computer.FileSystem.FileExists(AppResourcesDirectory & "\error.wav") Then
            My.Computer.Audio.Play(AppResourcesDirectory & "\error.wav", AudioPlayMode.Background)
        End If
    End Sub

    Public Sub PlayWaveOnLastItem()
        If My.Computer.FileSystem.FileExists(AppResourcesDirectory & "\lastitem.wav") Then
            My.Computer.Audio.Play(AppResourcesDirectory & "\lastitem.wav", AudioPlayMode.Background)
        End If
    End Sub

    Public Sub PlayWaveOnSecondLastItem()
        If My.Computer.FileSystem.FileExists(AppResourcesDirectory & "\secondlastitem.wav") Then
            My.Computer.Audio.Play(AppResourcesDirectory & "\secondlastitem.wav", AudioPlayMode.Background)
        End If
    End Sub

    'Public Sub PlayWaveOnThirdLastItem()
    '    If My.Computer.FileSystem.FileExists(AppResourcesDirectory & "\thirdlastitem.wav") Then
    '        My.Computer.Audio.Play(AppResourcesDirectory & "\thirdlastitem.wav", AudioPlayMode.Background)
    '    End If
    'End Sub

    'Public Sub BeepOnEnd()
    '    Beep(500, 100)
    '    Beep(666, 100)
    '    Beep(1000, 100)
    '    Beep(50, 200)
    '    Beep(500, 100)
    '    Beep(666, 100)
    '    Beep(1000, 100)
    '    Beep(50, 200)
    '    Beep(500, 100)
    '    Beep(666, 100)
    '    Beep(1000, 100)
    'End Sub
    'Public Sub BeepOnError()
    '    Beep(2000, 100)
    '    Beep(50, 100)
    '    Beep(2000, 100)
    '    Beep(50, 100)
    '    Beep(2000, 100)
    '    Beep(50, 100)
    '    Beep(2000, 100)
    '    Beep(50, 100)
    '    Beep(2000, 100)
    'End Sub

    'Public Sub BeepOnBlockEnd()
    '    Beep(500, 100)
    '    Beep(666, 100)
    '    Beep(500, 100)
    'End Sub

    'Public Sub BeepOnBreak()
    '    Beep(1000, 100)
    '    Beep(666, 100)
    '    Beep(500, 100)
    '    Beep(50, 200)
    '    Beep(1000, 100)
    '    Beep(666, 100)
    '    Beep(500, 100)
    '    Beep(50, 200)
    '    Beep(1000, 100)
    '    Beep(666, 100)
    '    Beep(500, 100)
    '    Beep(50, 200)
    'End Sub


   ''' <summary>
    ''' Get the next file version and number the file name.
    ''' </summary>
    ''' <param name="szFile">File name to search, will be updated to the next available version.</param>
    ''' <param name="szExt">Extension of the file.</param>
    ''' <remarks>GetNextFileVersion seeks for all files with the file name szFile and returns
    ''' the file name labeled with next available version. <br>
    ''' E.g. Given szName = "test" and szExt=".txt", if files "test.txt" and "test (2).txt" exist
    ''' the new szName will be "test (2).txt".</br></remarks>
    Public Sub GetNextFileVersion(ByRef szFile As String, ByVal szExt As String)
        Dim szX As String
        Dim lX, lMax As Integer

        If Len(szFile) = 0 Then Exit Sub
        If Mid(szExt, 1, 1) <> "." Then szExt = "." & szExt ' insert . to extension
        szX = Dir(szFile & szExt)
        If Len(szX) = 0 Then Return ' nothing found -> leave file name as is...
        'lX = 1
        ' first version found, seek for max. version number
        szX = Dir(szFile & " (*" & szExt)
        lMax = 1
        While Len(szX) <> 0
            lX = CInt(Val(Mid(szX, Len(szFile) + 3)))
            If lX > lMax Then lMax = lX
            szX = Dir()
        End While
        szFile = szFile & " (" & TStr(lMax + 1) & ")"

    End Sub

    '

    '       Return frmSettings.CheckValue(szX, varExp.szName, varExp.Flags, varExp.szUnit, varExp.dMin, varExp.dMax)

    '   End Function

   ''' <summary>
    ''' Check a Variable against restrictions.
    ''' </summary>
    ''' <param name="szX">String with the context to be checked. Caution: if the Variable should be of numeric type, the variant data type will change to Double.</param>
    ''' <param name="varExp">Variable with all restriction data.</param>
    ''' <param name="freqParL"></param>
    ''' <param name="freqParR"></param>
    ''' <returns>String with error descriptions or empty if the content passed the check.</returns>
    ''' <remarks></remarks>
    Public Function CheckVariable(ByRef szX As String, ByRef varExp As ExpVariable, _
                              ByVal freqParL() As clsFREQUENCY, _
                             ByVal freqParR() As clsFREQUENCY) As String
        If IsNothing(freqParL) Then
            Return CheckValue(szX, varExp.szName, varExp.Flags, varExp.szUnit, _
                                varExp.dMin, varExp.dMax, gfreqParL, gfreqParR)
        Else
            Return CheckValue(szX, varExp.szName, varExp.Flags, varExp.szUnit, _
                                varExp.dMin, varExp.dMax, freqParL, freqParR)
        End If

    End Function


   ''' <summary>
    ''' Check a Constant against restrictions.
    ''' </summary>
    ''' <param name="szX">String with the context to be checked. Caution: if the Constant should be of numeric type, the variant data type will change to Double.</param>
    ''' <param name="constExp">onstant with all restriction data.</param>
    ''' <param name="freqParL"></param>
    ''' <param name="freqParR"></param>
    ''' <returns>String with error descriptions or empty if the content passed the check.</returns>
    ''' <remarks></remarks>
    Public Function CheckConstant(ByVal szX As String, ByVal constExp As ExpConstant, _
                             ByVal freqParL() As clsFREQUENCY, _
                             ByVal freqParR() As clsFREQUENCY) As String

        If IsNothing(freqParL) Then
            Return CheckValue(szX, constExp.szName, constExp.Flags, constExp.szUnit, _
                                constExp.dMin, constExp.dMax, gfreqParL, gfreqParR)
        Else
            Return CheckValue(szX, constExp.szName, constExp.Flags, constExp.szUnit, _
                                constExp.dMin, constExp.dMax, freqParL, freqParR)
        End If

    End Function

   ''' <summary>
    ''' Check a value against from Variables or Constants its restrictions. <br>
    ''' Don't use CheckValue directly, use FWIntern.CheckVariable or FWIntern.CheckConstant instead.</br>
    ''' </summary>
    ''' <param name="szX"></param>
    ''' <param name="szName"></param>
    ''' <param name="Flags"></param>
    ''' <param name="szUnit"></param>
    ''' <param name="dMin"></param>
    ''' <param name="dMax"></param>
    ''' <param name="freqParL"></param>
    ''' <param name="freqParR"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckValue(ByRef szX As String, ByVal szName As String, _
                ByVal Flags As FWintern.VariableFlags, ByVal szUnit As String, _
                ByVal dMin As Double, ByVal dMax As Double, _
                ByVal freqParL() As clsFREQUENCY, ByVal freqParR() As clsFREQUENCY) As String
        Dim lY, lZ As Integer
        Dim szErr As String = ""
        Dim szChar As String = ""
        Dim szArr() As String
        Dim szT, szNew As String

        Select Case (Flags And 15)
            Case FWintern.VariableFlags.vfNumeric ' numeric values
                If (Flags And FWintern.VariableFlags.vfVectorized) = FWintern.VariableFlags.vfVectorized Then
                    If InStr(1, szX, " ") > 0 Then szChar = " "
                    If InStr(1, szX, ";") > 0 Then szChar = ";"
                    If Len(szChar) > 0 Then
                        ' vector found
                        szArr = Split(szX, szChar)
                        szNew = ""
                        For lZ = 0 To GetUbound(szArr)
                            szT = szArr(lZ)
                            If Len(szT) > 0 Then
                                szErr += CheckNumeric(szT, szName, Flags, dMin, dMax)
                                If Len(szErr) = 0 Then szNew = szNew + szChar + szT
                            End If
                        Next
                        If Len(szNew) > 0 Then szX = Mid(szNew, 2)
                    Else
                        ' scalar found
                        szErr = CheckNumeric(szX, szName, Flags, dMin, dMax)
                    End If
                Else ' not vectorized
                    szErr = CheckNumeric(szX, szName, Flags, dMin, dMax)
                End If 'not vectorized

            Case FWintern.VariableFlags.vfElectrodeL, FWintern.VariableFlags.vfElectrodeR ' electrodes
                If (Flags And FWintern.VariableFlags.vfVectorized) = FWintern.VariableFlags.vfVectorized Then
                    If InStr(1, szX, " ") > 0 Then szChar = " "
                    If InStr(1, szX, ";") > 0 Then szChar = ";"
                    If Len(szChar) > 0 Then
                        ' vector found
                        szArr = Split(szX, szChar)
                        szNew = ""
                        For lZ = 0 To GetUbound(szArr)
                            szT = szArr(lZ)
                            If Len(szT) > 0 Then
                                szErr &= CheckElectrode(szT, szName, Flags, dMin, dMax, freqParL, freqParR)
                                If Len(szErr) = 0 Then szNew = szNew + szChar + szT
                            End If
                        Next
                        If Len(szNew) > 0 Then szX = Mid(szNew, 2)
                    Else
                        ' scalar found
                        szErr = CheckElectrode(szX, szName, Flags, dMin, dMax, freqParL, freqParR)
                    End If
                Else ' not vectorized
                    szErr = CheckElectrode(szX, szName, Flags, dMin, dMax, freqParL, freqParR)
                End If 'not vectorized

            Case FWintern.VariableFlags.vfFileName ' file name
            Case FWintern.VariableFlags.vfDirectory ' directory

            Case FWintern.VariableFlags.vfString ' string
                If (Flags And FWintern.VariableFlags.vfNonEmpty) > 0 And Len(szX) = 0 Then szErr = szErr & szName & " must not be empty." & vbCrLf
                If (Flags And FWintern.VariableFlags.vfEnumeration) <> 0 Then
                    If (Flags And FWintern.VariableFlags.vfCaseSensitive) <> 0 Then
                        szArr = Split(szUnit, ";")
                        For lY = 0 To UBound(szArr)
                            If szX = szArr(lY) Then Exit For
                        Next
                        If lY > UBound(szArr) Then szErr = szErr & "Allowed values (case sensitive!): " & szUnit & vbCrLf
                    Else
                        szArr = Split(szUnit, ";")
                        For lY = 0 To UBound(szArr)
                            If LCase(szX) = LCase(szArr(lY)) Then Exit For
                        Next
                        If lY > UBound(szArr) Then szErr = szErr & "Allowed values: " & szUnit & vbCrLf
                    End If
                End If
                If (Flags And FWintern.VariableFlags.vfUpperCase) <> 0 Then szX = UCase(szX)
                If (Flags And FWintern.VariableFlags.vfLowerCase) <> 0 Then szX = LCase(szX)
        End Select

        Return szErr
    End Function

    Private Function CheckNumeric(ByRef varX As String, ByVal szName As String, _
                        ByVal Flags As FWintern.VariableFlags, ByVal dMin As Double, ByVal dMax As Double) As String
        Dim szErr As String
        Dim dblX As Double

        szErr = ""

        If Not IsNumeric(varX) Then
            szErr = szErr & szName & " must be numeric." & vbCrLf
        Else
            dblX = Val(varX)
            If (Flags And FWintern.VariableFlags.vfInteger) <> 0 And (InStr(varX, ".") > 0 Or InStr(varX, ",") > 0) Then szErr = szErr & szName & ": not an integer." & vbCrLf
            If (Flags And FWintern.VariableFlags.vfInteger) <> 0 Then dblX = Math.Round(dblX) 'internal value
            If (Flags And FWintern.VariableFlags.vfNonZero) <> 0 And (dblX = 0) Then szErr = szErr & szName & ": values equal 0 not allowed." & vbCrLf
            If (Flags And FWintern.VariableFlags.vfMin) <> 0 And (dblX < dMin) Then szErr = szErr & szName & ": values below " & TStr(dMin) & " not allowed." & vbCrLf
            If (Flags And FWintern.VariableFlags.vfMax) <> 0 And (dblX > dMax) Then szErr = szErr & szName & ": values greater than " & TStr(dMax) & " not allowed." & vbCrLf
            If (Flags And FWintern.VariableFlags.vfMinTimeDelay) <> 0 Then
                dblX = Math.Round(dblX)
                If dblX < 0 Then szErr = szErr & szName & " must be a positive time delay" & vbCrLf
            End If
            varX = TStr(dblX)
        End If

        CheckNumeric = szErr
    End Function

   ''' <summary>
    ''' Check Electrode.
    ''' </summary>
    ''' <param name="varX">Value to check.</param>
    ''' <param name="szName">Name of the Variable/Constant.</param>
    ''' <param name="Flags">Flags of the Variable/Constant.</param>
    ''' <param name="dMin">Lower limit</param>
    ''' <param name="dMax">Upper limit.</param>
    ''' <param name="freqParL"></param>
    ''' <param name="freqParR"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckElectrode(ByVal varX As String, ByVal szName As String, _
                ByVal Flags As FWintern.VariableFlags, ByVal dMin As Double, ByVal dMax As Double, _
                ByVal freqParL() As clsFREQUENCY, ByVal freqParR() As clsFREQUENCY) As String

        Dim szCh, szErr As String
        Dim lEl, lX, lCh As Integer
        Dim sTHR, sMCL, sAmp As Double
        'Dim sX As Single ' some additional roving - not used now

        szErr = ""
        szCh = ""
        'sX = 0

        If Not IsNumeric(varX) Then Return szErr & szName & " must be numeric." & vbCrLf

        ' determine electrode and side
        If (Flags And FWintern.VariableFlags.vfFlagTypeMask) = FWintern.VariableFlags.vfElectrodeL Then
            szCh = "Left" : lCh = 0
        ElseIf (Flags And FWintern.VariableFlags.vfFlagTypeMask) = FWintern.VariableFlags.vfElectrodeR Then
            szCh = "Right" : lCh = 1
        Else
            Err.Raise(0, "CheckElectrode", "Flags not set to Electrode")
        End If

        ' check for valid index
        lEl = CInt(Math.Round(Val(varX)))
        If lEl < 1 Then Return szErr & "Value must be a " & LCase(szCh) & " " & "channel" & vbCrLf

        ' check for min/max
        If (Flags And FWintern.VariableFlags.vfMin) > 0 And (lEl < dMin) Then Return szErr & szName & ": values below " & TStr(dMin) & " not allowed." & vbCrLf
        If (Flags And FWintern.VariableFlags.vfMax) > 0 And (lEl > dMax) Then Return szErr & szName & ": values greater than " & TStr(dMax) & " not allowed." & vbCrLf

        ' check if defined
        If lCh = 1 Then lX = GetUbound(freqParR) + 1 Else lX = GetUbound(freqParL) + 1
        If lEl > lX Then Return szErr & szCh & " " & "channel" & " #" & TStr(lEl) & " not defined" & vbCrLf

        ' check THR or MCL?
        If (Flags And FWintern.VariableFlags.vfNoMCLCheck) = 0 Or (Flags And FWintern.VariableFlags.vfNoTHRCheck) = 0 Then
            ' get MCL, THR, and Amplitude
            If lCh = 1 Then
                sMCL = freqParR(lEl - 1).sMCL : sTHR = freqParR(lEl - 1).sTHR : sAmp = freqParR(lEl - 1).sAmp
            Else
                sMCL = freqParL(lEl - 1).sMCL : sTHR = freqParL(lEl - 1).sTHR : sAmp = freqParL(lEl - 1).sAmp
            End If
            ' check if disabled
            If sMCL <= sTHR Then
                szErr = szErr & szCh & " " & "channel" & " #" & TStr(lEl) & ": disabled." & vbCrLf
            Else
                ' check MCL
                If (sAmp > sMCL) And ((Flags And FWintern.VariableFlags.vfNoMCLCheck) = 0) Then szErr = szErr & szCh & " " & "channel" & " #" & TStr(lEl) & ": Amplitude (" & TStr(sAmp) & ") is higher than MCL (" & TStr(sMCL) & "). " & vbCrLf
                ' check THR
                If (sAmp < sTHR) And ((Flags And FWintern.VariableFlags.vfNoTHRCheck) = 0) Then szErr = szErr & szCh & " " & "channel" & " #" & TStr(lEl) & ": Amplitude (" & TStr(sAmp) & ") is lower than THR (" & TStr(sTHR) & "). " & vbCrLf
            End If
        End If
        Return szErr

    End Function


End Module