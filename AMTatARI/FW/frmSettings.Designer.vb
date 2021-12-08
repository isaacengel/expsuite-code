<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSettings
#Region "Windows Form Designer generated code "
    <System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        Me.IsInitializing = True
        InitializeComponent()
        Me.IsInitializing = False
    End Sub
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents cmdOK As System.Windows.Forms.Button
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents cmdApply As System.Windows.Forms.Button
    Public WithEvents _optDeviceType_1 As System.Windows.Forms.RadioButton
    Public WithEvents _optDeviceType_0 As System.Windows.Forms.RadioButton
    Public WithEvents fraDeviceType As System.Windows.Forms.GroupBox
    Public WithEvents chkSilentMode As System.Windows.Forms.CheckBox
    Public WithEvents cmdDestinationFromSetting As System.Windows.Forms.Button
    Public WithEvents chkNewWorkDir As System.Windows.Forms.CheckBox
    Public WithEvents txtDestinationDir As System.Windows.Forms.TextBox
    Public WithEvents chkTempDir As System.Windows.Forms.CheckBox
    Public WithEvents cmdDestinationDir As System.Windows.Forms.Button
    Public WithEvents Label32 As System.Windows.Forms.Label
    Public WithEvents fraWorkDir As System.Windows.Forms.GroupBox
    Public WithEvents cmbDataDir As System.Windows.Forms.ListBox
    Public WithEvents cmdDataDir As System.Windows.Forms.Button
    Public WithEvents txtDataDir As System.Windows.Forms.TextBox
    Public WithEvents fraDataDir As System.Windows.Forms.GroupBox
    Public WithEvents chkTTUse As System.Windows.Forms.CheckBox
    Public WithEvents fraTurntable As System.Windows.Forms.GroupBox
    Public WithEvents tabGeneral As System.Windows.Forms.TabPage
    Public WithEvents _Label14_0 As System.Windows.Forms.Label
    Public WithEvents _Label2_0 As System.Windows.Forms.Label
    Public WithEvents _Label3_0 As System.Windows.Forms.Label
    Public WithEvents _Label5_0 As System.Windows.Forms.Label
    Public WithEvents _lblMinDist_0 As System.Windows.Forms.Label
    Public WithEvents _Label6_0 As System.Windows.Forms.Label
    Public WithEvents _lblPPer_0 As System.Windows.Forms.Label
    Public WithEvents _lblCycPer_0 As System.Windows.Forms.Label
    Public WithEvents _Label9_0 As System.Windows.Forms.Label
    Public WithEvents _Label6_4 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents _txtMinDist_0 As System.Windows.Forms.TextBox
    Public WithEvents _txtFittFile_0 As System.Windows.Forms.TextBox
    Public WithEvents _txtFName_0 As System.Windows.Forms.TextBox
    Public WithEvents _txtLName_0 As System.Windows.Forms.TextBox
    Public WithEvents _cmdFittBrowse_0 As System.Windows.Forms.Button
    Public WithEvents _lstChInfo_0 As System.Windows.Forms.ListBox
    Public WithEvents cmdSourceDir As System.Windows.Forms.Button
    Public WithEvents txtSourceDir As System.Windows.Forms.TextBox
    Public WithEvents _cmdFittClear_0 As System.Windows.Forms.Button
    Public WithEvents _cmdFittReload_0 As System.Windows.Forms.Button
    Public WithEvents _cmdFittResetPhDur_0 As System.Windows.Forms.Button
    Public WithEvents tabFittingLeft As System.Windows.Forms.TabPage
    Public WithEvents _Label14_1 As System.Windows.Forms.Label
    Public WithEvents _Label2_1 As System.Windows.Forms.Label
    Public WithEvents _Label3_1 As System.Windows.Forms.Label
    Public WithEvents _Label5_1 As System.Windows.Forms.Label
    Public WithEvents _lblMinDist_1 As System.Windows.Forms.Label
    Public WithEvents _Label6_1 As System.Windows.Forms.Label
    Public WithEvents _lblPPer_1 As System.Windows.Forms.Label
    Public WithEvents _lblCycPer_1 As System.Windows.Forms.Label
    Public WithEvents _Label9_1 As System.Windows.Forms.Label
    Public WithEvents _Label6_5 As System.Windows.Forms.Label
    Public WithEvents _txtMinDist_1 As System.Windows.Forms.TextBox
    Public WithEvents _txtFittFile_1 As System.Windows.Forms.TextBox
    Public WithEvents _txtFName_1 As System.Windows.Forms.TextBox
    Public WithEvents _txtLName_1 As System.Windows.Forms.TextBox
    Public WithEvents _cmdFittBrowse_1 As System.Windows.Forms.Button
    Public WithEvents _lstChInfo_1 As System.Windows.Forms.ListBox
    Public WithEvents _cmdFittClear_1 As System.Windows.Forms.Button
    Public WithEvents _cmdFittReload_1 As System.Windows.Forms.Button
    Public WithEvents _cmdFittResetPhDur_1 As System.Windows.Forms.Button
    Public WithEvents tabFittingRight As System.Windows.Forms.TabPage
    Public WithEvents lblExpDescription As System.Windows.Forms.Label
    Public WithEvents lblExpID As System.Windows.Forms.Label
    Public WithEvents txtDescription As System.Windows.Forms.TextBox
    Public WithEvents txtID As System.Windows.Forms.TextBox
    Public WithEvents tabDescription As System.Windows.Forms.TabPage
    Public WithEvents lblKeyCode As System.Windows.Forms.Label
    Public WithEvents cmdExpGetValue As System.Windows.Forms.Button
    Public WithEvents txtExpValue As System.Windows.Forms.TextBox
    Public WithEvents txtExpResponse As System.Windows.Forms.TextBox
    Public WithEvents cmdExpGetResponse As System.Windows.Forms.Button
    Public WithEvents cmdExpDisableResponse As System.Windows.Forms.Button
    Public WithEvents cmdExpEnableResponse As System.Windows.Forms.Button
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents cmdExpResize As System.Windows.Forms.Button
    Public WithEvents txtExpLeft As System.Windows.Forms.TextBox
    Public WithEvents txtExpWidth As System.Windows.Forms.TextBox
    Public WithEvents txtExpTop As System.Windows.Forms.TextBox
    Public WithEvents txtExpHeight As System.Windows.Forms.TextBox
    Public WithEvents cmdExpGetSize As System.Windows.Forms.Button
    Public WithEvents cmdExpSetSize As System.Windows.Forms.Button
    Public WithEvents _lblExp_0 As System.Windows.Forms.Label
    Public WithEvents _lblExp_1 As System.Windows.Forms.Label
    Public WithEvents _lblExp_2 As System.Windows.Forms.Label
    Public WithEvents _lblExp_3 As System.Windows.Forms.Label
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents lstExpFlags As System.Windows.Forms.CheckedListBox
    Public WithEvents chkAlwaysOnTop As System.Windows.Forms.CheckBox
    Public WithEvents cmdExpBlankScreen As System.Windows.Forms.Button
    Public WithEvents cmdExpHide As System.Windows.Forms.Button
    Public WithEvents cmdExpShow As System.Windows.Forms.Button
    Public WithEvents cmdExpStartScreen As System.Windows.Forms.Button
    Public WithEvents cmdExpStimScreen As System.Windows.Forms.Button
    Public WithEvents cmdExpNextScreen As System.Windows.Forms.Button
    Public WithEvents cmdExpEndScreen As System.Windows.Forms.Button
    Public WithEvents Frame3 As System.Windows.Forms.GroupBox
    Public WithEvents cmbHUI As System.Windows.Forms.ComboBox
    Public WithEvents tabExperimentScreen As System.Windows.Forms.TabPage
    Public WithEvents lblSignal As System.Windows.Forms.Label
    Public WithEvents cmbRangeL As System.Windows.Forms.ComboBox
    Public WithEvents Label17 As System.Windows.Forms.Label
    Public WithEvents _Label3_2 As System.Windows.Forms.Label
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents lblMCLL As System.Windows.Forms.Label
    Public WithEvents lblTHRL As System.Windows.Forms.Label
    Public WithEvents lblDynamicL As System.Windows.Forms.Label
    Public WithEvents lblLevelL As System.Windows.Forms.Label
    Public WithEvents fraElectricalL As System.Windows.Forms.GroupBox
    Public WithEvents cmbRangeR As System.Windows.Forms.ComboBox
    Public WithEvents lblDynamicR As System.Windows.Forms.Label
    Public WithEvents lblTHRR As System.Windows.Forms.Label
    Public WithEvents lblMCLR As System.Windows.Forms.Label
    Public WithEvents lblLevelR As System.Windows.Forms.Label
    Public WithEvents fraElectricalR As System.Windows.Forms.GroupBox
    Public WithEvents cmbElL As System.Windows.Forms.ComboBox
    Public WithEvents cmbElR As System.Windows.Forms.ComboBox
    Public WithEvents txtMCLR As System.Windows.Forms.TextBox
    Public WithEvents txtTHRR As System.Windows.Forms.TextBox
    Public WithEvents txtAmpR As System.Windows.Forms.TextBox
    Public WithEvents txtSPLOffsetR As System.Windows.Forms.TextBox
    Public WithEvents txtCenterFreqR As System.Windows.Forms.TextBox
    Public WithEvents txtBandwidthR As System.Windows.Forms.TextBox
    Public WithEvents fraAcousticR As System.Windows.Forms.GroupBox
    Public WithEvents txtMCLL As System.Windows.Forms.TextBox
    Public WithEvents txtTHRL As System.Windows.Forms.TextBox
    Public WithEvents txtAmpL As System.Windows.Forms.TextBox
    Public WithEvents txtSPLOffsetL As System.Windows.Forms.TextBox
    Public WithEvents txtCenterFreqL As System.Windows.Forms.TextBox
    Public WithEvents txtBandwidthL As System.Windows.Forms.TextBox
    Public WithEvents lblMCL As System.Windows.Forms.Label
    Public WithEvents lblTHR As System.Windows.Forms.Label
    Public WithEvents lblAmp As System.Windows.Forms.Label
    Public WithEvents lblSPLOffset As System.Windows.Forms.Label
    Public WithEvents lblCenterFreq As System.Windows.Forms.Label
    Public WithEvents lblBandwidth As System.Windows.Forms.Label
    Public WithEvents fraAcousticL As System.Windows.Forms.GroupBox
    Public WithEvents txtPhDurL As System.Windows.Forms.TextBox
    Public WithEvents lblPhDur As System.Windows.Forms.Label
    Public WithEvents lblPhDurQuantized As System.Windows.Forms.Label
    Public WithEvents lblPhDurL As System.Windows.Forms.Label
    Public WithEvents fraSignalL As System.Windows.Forms.GroupBox
    Public WithEvents txtPhDurR As System.Windows.Forms.TextBox
    Public WithEvents lblPhDurR As System.Windows.Forms.Label
    Public WithEvents fraSignalR As System.Windows.Forms.GroupBox
    Public WithEvents cmdElAddL As System.Windows.Forms.Button
    Public WithEvents cmdElDelL As System.Windows.Forms.Button
    Public WithEvents cmdElDelR As System.Windows.Forms.Button
    Public WithEvents cmdElAddR As System.Windows.Forms.Button
    Public WithEvents cmdSignalImport As System.Windows.Forms.Button
    Public WithEvents tabChannels As System.Windows.Forms.TabPage
    Public WithEvents cmdAudioSynthDis As System.Windows.Forms.Button
    Public WithEvents cmbAudioSynthCh As System.Windows.Forms.ListBox
    Public WithEvents _optAudioSynthDAC_0 As System.Windows.Forms.RadioButton
    Public WithEvents _optAudioSynthDAC_1 As System.Windows.Forms.RadioButton
    Public WithEvents _optAudioSynthDAC_2 As System.Windows.Forms.RadioButton
    Public WithEvents fraAudioDACMulti As System.Windows.Forms.GroupBox
    Public WithEvents _optAudioDitherLeft_0 As System.Windows.Forms.RadioButton
    Public WithEvents _optAudioDitherLeft_1 As System.Windows.Forms.RadioButton
    Public WithEvents _optAudioDitherLeft_2 As System.Windows.Forms.RadioButton
    Public WithEvents fraAudioDACLeft As System.Windows.Forms.GroupBox
    Public WithEvents _optAudioDitherRight_2 As System.Windows.Forms.RadioButton
    Public WithEvents _optAudioDitherRight_1 As System.Windows.Forms.RadioButton
    Public WithEvents _optAudioDitherRight_0 As System.Windows.Forms.RadioButton
    Public WithEvents fraAudioDACRight As System.Windows.Forms.GroupBox
    Public WithEvents _txtAudioDitherPar1_1 As System.Windows.Forms.TextBox
    Public WithEvents _cmbAudioDither_1 As System.Windows.Forms.ComboBox
    Public WithEvents _txtAudioDitherLC_1 As System.Windows.Forms.TextBox
    Public WithEvents _txtAudioDitherHC_1 As System.Windows.Forms.TextBox
    Public WithEvents _lblAudio_7 As System.Windows.Forms.Label
    Public WithEvents _lblAudio_8 As System.Windows.Forms.Label
    Public WithEvents _lblAudio_9 As System.Windows.Forms.Label
    Public WithEvents Label46 As System.Windows.Forms.Label
    Public WithEvents _lblAudioDitherAmp_1 As System.Windows.Forms.Label
    Public WithEvents _fraAudioDither_1 As System.Windows.Forms.GroupBox
    Public WithEvents _txtAudioDitherPar1_0 As System.Windows.Forms.TextBox
    Public WithEvents _txtAudioDitherLC_0 As System.Windows.Forms.TextBox
    Public WithEvents _txtAudioDitherHC_0 As System.Windows.Forms.TextBox
    Public WithEvents _cmbAudioDither_0 As System.Windows.Forms.ComboBox
    Public WithEvents _lblAudio_4 As System.Windows.Forms.Label
    Public WithEvents _lblAudioDitherAmp_0 As System.Windows.Forms.Label
    Public WithEvents Label35 As System.Windows.Forms.Label
    Public WithEvents _lblAudio_6 As System.Windows.Forms.Label
    Public WithEvents _lblAudio_5 As System.Windows.Forms.Label
    Public WithEvents _fraAudioDither_0 As System.Windows.Forms.GroupBox
    Public WithEvents txtFadeOut As System.Windows.Forms.TextBox
    Public WithEvents txtFadeIn As System.Windows.Forms.TextBox
    Public WithEvents txtResolution As System.Windows.Forms.TextBox
    Public WithEvents txtSamplingRate As System.Windows.Forms.TextBox
    Public WithEvents _lblAudio_3 As System.Windows.Forms.Label
    Public WithEvents _lblAudio_2 As System.Windows.Forms.Label
    Public WithEvents _lblAudio_1 As System.Windows.Forms.Label
    Public WithEvents _lblAudio_0 As System.Windows.Forms.Label
    Public WithEvents tabAudio As System.Windows.Forms.TabPage
    Public WithEvents lblPreStimVisuOffset As System.Windows.Forms.Label
    Public WithEvents lblExpType As System.Windows.Forms.Label
    Public WithEvents lblInterStimBreak As System.Windows.Forms.Label
    Public WithEvents lblItemRepetition As System.Windows.Forms.Label
    Public WithEvents _lblStimOffset_2 As System.Windows.Forms.Label
    Public WithEvents lblPreStimBreak As System.Windows.Forms.Label
    Public WithEvents lblPostStimVisuOffset As System.Windows.Forms.Label
    Public WithEvents lblStimOffsetU As System.Windows.Forms.Label
    Public WithEvents _lblPreStimBreakU_0 As System.Windows.Forms.Label
    Public WithEvents _lblPreStimVisuOffsetU_1 As System.Windows.Forms.Label
    Public WithEvents _lblInterStimBreakU_2 As System.Windows.Forms.Label
    Public WithEvents _lblPostStimVisuOffsetU_3 As System.Windows.Forms.Label
    Public WithEvents txtPreStimVisu As System.Windows.Forms.TextBox
    Public WithEvents cmbExpType As System.Windows.Forms.ComboBox
    Public WithEvents txtInterStimBreak As System.Windows.Forms.TextBox
    Public WithEvents txtRepetition As System.Windows.Forms.TextBox
    Public WithEvents txtOffsetL As System.Windows.Forms.TextBox
    Public WithEvents txtOffsetR As System.Windows.Forms.TextBox
    Public WithEvents txtPreStimBreak As System.Windows.Forms.TextBox
    Public WithEvents txtPostStimVisu As System.Windows.Forms.TextBox
    Public WithEvents chkBreak As System.Windows.Forms.CheckBox
    Public WithEvents txtBreak As System.Windows.Forms.TextBox
    Public WithEvents cmbBreak As System.Windows.Forms.ComboBox
    Public WithEvents tabProcedure As System.Windows.Forms.TabPage
    Public WithEvents cmbVariables As System.Windows.Forms.ListBox
    Public WithEvents cmdVariablesPaste As System.Windows.Forms.Button
    Public WithEvents cmdVariablesDir As System.Windows.Forms.Button
    Public WithEvents cmdVariablesBrowse As System.Windows.Forms.Button
    Public WithEvents cmdVariablesUp As System.Windows.Forms.Button
    Public WithEvents cmdVariablesDown As System.Windows.Forms.Button
    Public WithEvents txtVariablesFlags As System.Windows.Forms.TextBox
    Public WithEvents txtVariablesDescr As System.Windows.Forms.TextBox
    Public WithEvents cmdVariablesDefault As System.Windows.Forms.Button
    Public WithEvents _lstVariables_0 As System.Windows.Forms.ListBox
    Public WithEvents txtVariables As System.Windows.Forms.TextBox
    Public WithEvents cmdVariablesAdd As System.Windows.Forms.Button
    Public WithEvents cmdVariablesRemove As System.Windows.Forms.Button
    Public WithEvents cmdVariablesClear As System.Windows.Forms.Button
    Public WithEvents Label50 As System.Windows.Forms.Label
    Public WithEvents Label22 As System.Windows.Forms.Label
    Public WithEvents lblVarValues As System.Windows.Forms.Label
    Public WithEvents tabVariables As System.Windows.Forms.TabPage
    Public WithEvents _cmdConstCmd_0 As System.Windows.Forms.Button
    Public WithEvents _txtConstValue_0 As System.Windows.Forms.TextBox
    Public WithEvents _lblConstUnit_0 As System.Windows.Forms.Label
    Public WithEvents _lblConstName_0 As System.Windows.Forms.Label
    Public WithEvents tabConstants As System.Windows.Forms.TabPage
    Public WithEvents cmbTrackerRepRate As System.Windows.Forms.ComboBox
    Public WithEvents cmbTrackerPosScaling As System.Windows.Forms.ComboBox
    Public WithEvents chkTrackerUse As System.Windows.Forms.CheckBox
    Public WithEvents lblTrackerTimeOut As System.Windows.Forms.Label
    Public WithEvents lblTrackerUse As System.Windows.Forms.Label
    Public WithEvents lblTrackerRepRate As System.Windows.Forms.Label
    Public WithEvents lblTrackerPosScaling As System.Windows.Forms.Label
    Public WithEvents lblTrackerRepRateUnits As System.Windows.Forms.Label
    Public WithEvents lblTrackerPosScalingUnits As System.Windows.Forms.Label
    Public WithEvents fraTrackerSettings As System.Windows.Forms.GroupBox
    Public WithEvents _cmdTrackerSetOffset_0 As System.Windows.Forms.Button
    Public WithEvents _cmdTrackerSetValues_0 As System.Windows.Forms.Button
    Public WithEvents _lblTrackerR_0 As System.Windows.Forms.Label
    Public WithEvents _lblTrackerE_0 As System.Windows.Forms.Label
    Public WithEvents _lblTrackerA_0 As System.Windows.Forms.Label
    Public WithEvents _lblTrackerZ_0 As System.Windows.Forms.Label
    Public WithEvents _lblTrackerY_0 As System.Windows.Forms.Label
    Public WithEvents _lblTrackerLabR_0 As System.Windows.Forms.Label
    Public WithEvents _lblTrackerLabE_0 As System.Windows.Forms.Label
    Public WithEvents _lblTrackerLabZ_0 As System.Windows.Forms.Label
    Public WithEvents _lblTrackerLabY_0 As System.Windows.Forms.Label
    Public WithEvents _lblTrackerX_0 As System.Windows.Forms.Label
    Public WithEvents _lblTrackerLabA_0 As System.Windows.Forms.Label
    Public WithEvents _lblTrackerLabX_0 As System.Windows.Forms.Label
    Public WithEvents _fraTrackerSensor_0 As System.Windows.Forms.GroupBox
    Public WithEvents _cmdTrackerSetOffset_1 As System.Windows.Forms.Button
    Public WithEvents _cmdTrackerSetValues_1 As System.Windows.Forms.Button
    Public WithEvents _lblTrackerLabX_1 As System.Windows.Forms.Label
    Public WithEvents _lblTrackerLabA_1 As System.Windows.Forms.Label
    Public WithEvents _lblTrackerX_1 As System.Windows.Forms.Label
    Public WithEvents _lblTrackerLabY_1 As System.Windows.Forms.Label
    Public WithEvents _lblTrackerLabZ_1 As System.Windows.Forms.Label
    Public WithEvents _lblTrackerLabE_1 As System.Windows.Forms.Label
    Public WithEvents _lblTrackerLabR_1 As System.Windows.Forms.Label
    Public WithEvents _lblTrackerY_1 As System.Windows.Forms.Label
    Public WithEvents _lblTrackerZ_1 As System.Windows.Forms.Label
    Public WithEvents _lblTrackerA_1 As System.Windows.Forms.Label
    Public WithEvents _lblTrackerE_1 As System.Windows.Forms.Label
    Public WithEvents _lblTrackerR_1 As System.Windows.Forms.Label
    Public WithEvents _fraTrackerSensor_1 As System.Windows.Forms.GroupBox
    Public WithEvents chkTrackerSaveData As System.Windows.Forms.CheckBox
    Public WithEvents tabTracker As System.Windows.Forms.TabPage
    Public WithEvents _Label8_0 As System.Windows.Forms.Label
    Public WithEvents _Label8_1 As System.Windows.Forms.Label
    Public WithEvents chkViWoSendData As System.Windows.Forms.CheckBox
    Public WithEvents txtViWoAvgHead As System.Windows.Forms.TextBox
    Public WithEvents txtViWoAvgPointer As System.Windows.Forms.TextBox
    Public WithEvents lstViWoWorlds As System.Windows.Forms.ListBox
    Public WithEvents lstViWoParameters As System.Windows.Forms.ListBox
    Public WithEvents txtViWoInteger As System.Windows.Forms.TextBox
    Public WithEvents _fraViWoParameter_0 As System.Windows.Forms.GroupBox
    Public WithEvents cmdViWoColor As System.Windows.Forms.Button
    Public WithEvents shpViWoColor As System.Windows.Forms.Label
    Public WithEvents _fraViWoParameter_1 As System.Windows.Forms.GroupBox
    Public WithEvents _cmdViWoSendParameters_0 As System.Windows.Forms.Button
    Public WithEvents _txtViWoPosition_2 As System.Windows.Forms.TextBox
    Public WithEvents _txtViWoPosition_1 As System.Windows.Forms.TextBox
    Public WithEvents _txtViWoPosition_0 As System.Windows.Forms.TextBox
    Public WithEvents _fraViWoParameter_2 As System.Windows.Forms.GroupBox
    Public WithEvents _cmdViWoSendParameters_1 As System.Windows.Forms.Button
    Public WithEvents tabVirtualWorld As System.Windows.Forms.TabPage
    Public WithEvents tabSettings As System.Windows.Forms.TabControl
    Public WithEvents tmrExpResize As System.Windows.Forms.Timer
    Public WithEvents tmrTracker As System.Windows.Forms.Timer
    Public dlgCommonDialogColor As System.Windows.Forms.ColorDialog
    Public WithEvents tmrRealTime As System.Windows.Forms.Timer
    Public WithEvents lblRealTime As System.Windows.Forms.Label
    Public WithEvents cmbAudioDither As Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray
    Public WithEvents cmdFittBrowse As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    Public WithEvents cmdConstCmd As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    Public WithEvents cmdFittClear As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    Public WithEvents cmdFittReload As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    Public WithEvents cmdFittResetPhDur As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    Public WithEvents cmdTrackerSetOffset As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    Public WithEvents cmdTrackerSetValues As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    Public WithEvents cmdViWoSendParameters As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    Public WithEvents fraAudioDither As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
    Public WithEvents fraTrackerSensor As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
    Public WithEvents fraViWoParameter As Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray
    Public WithEvents lblAudio As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblAudioDitherAmp As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblConstName As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblConstUnit As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblCycPer As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblExp As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblInterStimBreakU As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblMinDist As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblPPer As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblImpType As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblPostStimVisuOffsetU As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblPreStimBreakU As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblPreStimVisuOffsetU As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblStimOffset As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblTrackerA As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblTrackerARange As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblTrackerE As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblTrackerERange As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblTrackerLabA As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblTrackerLabE As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblTrackerLabR As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblTrackerLabX As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblTrackerLabY As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblTrackerLabZ As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblTrackerR As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblTrackerRRange As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblTrackerX As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblTrackerXRange As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblTrackerY As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblTrackerYRange As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblTrackerZ As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblTrackerZRange As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lstChInfo As Microsoft.VisualBasic.Compatibility.VB6.ListBoxArray
    Public WithEvents lstVariables As Microsoft.VisualBasic.Compatibility.VB6.ListBoxArray
    Public WithEvents optAudioDitherLeft As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
    Public WithEvents optAudioDitherRight As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
    Public WithEvents optAudioSynthDAC As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
    Public WithEvents txtAudioDitherHC As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents txtAudioDitherLC As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents txtAudioDitherPar1 As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents txtConstValue As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents txtFName As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents txtFittFile As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents txtLName As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents txtMinDist As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents txtViWoPosition As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents txtViWoPar As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.pbProgress = New System.Windows.Forms.ProgressBar()
        Me.lblRealTime = New System.Windows.Forms.Label()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdDestinationFromSetting = New System.Windows.Forms.Button()
        Me.txtDestinationDir = New System.Windows.Forms.TextBox()
        Me.cmdDestinationDir = New System.Windows.Forms.Button()
        Me.cmdDataDir = New System.Windows.Forms.Button()
        Me.txtDataDir = New System.Windows.Forms.TextBox()
        Me.txtSourceDir = New System.Windows.Forms.TextBox()
        Me._cmdFittClear_0 = New System.Windows.Forms.Button()
        Me._cmdFittReload_0 = New System.Windows.Forms.Button()
        Me._cmdFittClear_1 = New System.Windows.Forms.Button()
        Me._cmdFittReload_1 = New System.Windows.Forms.Button()
        Me.txtPreStimVisu = New System.Windows.Forms.TextBox()
        Me.cmbExpType = New System.Windows.Forms.ComboBox()
        Me.txtInterStimBreak = New System.Windows.Forms.TextBox()
        Me.txtRepetition = New System.Windows.Forms.TextBox()
        Me.txtOffsetL = New System.Windows.Forms.TextBox()
        Me.txtOffsetR = New System.Windows.Forms.TextBox()
        Me.txtPreStimBreak = New System.Windows.Forms.TextBox()
        Me.txtPostStimVisu = New System.Windows.Forms.TextBox()
        Me.txtBreak = New System.Windows.Forms.TextBox()
        Me.cmbBreak = New System.Windows.Forms.ComboBox()
        Me.cmdVariablesPaste = New System.Windows.Forms.Button()
        Me.cmdVariablesDir = New System.Windows.Forms.Button()
        Me.cmdVariablesBrowse = New System.Windows.Forms.Button()
        Me.cmdVariablesUp = New System.Windows.Forms.Button()
        Me.cmdVariablesDown = New System.Windows.Forms.Button()
        Me.cmdVariablesDefault = New System.Windows.Forms.Button()
        Me.cmdVariablesAdd = New System.Windows.Forms.Button()
        Me.cmdVariablesRemove = New System.Windows.Forms.Button()
        Me.cmdVariablesClear = New System.Windows.Forms.Button()
        Me._cmdConstCmd_0 = New System.Windows.Forms.Button()
        Me.cmdFittEdit_0 = New System.Windows.Forms.Button()
        Me.cmdFittEdit_1 = New System.Windows.Forms.Button()
        Me._cmdFittResetPhDur_0 = New System.Windows.Forms.Button()
        Me._cmdFittResetPhDur_1 = New System.Windows.Forms.Button()
        Me.cmdSignalImport = New System.Windows.Forms.Button()
        Me.cmbAudioSynthCh = New System.Windows.Forms.ListBox()
        Me.cmbDuplicate = New System.Windows.Forms.Button()
        Me.txtSourceDirCopy = New System.Windows.Forms.TextBox()
        Me.cmdAnalysisSetting = New System.Windows.Forms.Button()
        Me.OexpMode = New System.Windows.Forms.NumericUpDown()
        Me.chkOverrideExpMode = New System.Windows.Forms.CheckBox()
        Me._optDeviceType_5 = New System.Windows.Forms.RadioButton()
        Me._optDeviceType_4 = New System.Windows.Forms.RadioButton()
        Me._optDeviceType_3 = New System.Windows.Forms.RadioButton()
        Me._optDeviceType_2 = New System.Windows.Forms.RadioButton()
        Me._optDeviceType_1 = New System.Windows.Forms.RadioButton()
        Me._optDeviceType_0 = New System.Windows.Forms.RadioButton()
        Me.ckbUseDataChannel = New System.Windows.Forms.CheckBox()
        Me.ckbUseTriggerChannel = New System.Windows.Forms.CheckBox()
        Me._lblTrackerR_0 = New System.Windows.Forms.Label()
        Me._lblTrackerE_0 = New System.Windows.Forms.Label()
        Me._lblTrackerA_0 = New System.Windows.Forms.Label()
        Me._lblTrackerZ_0 = New System.Windows.Forms.Label()
        Me._lblTrackerY_0 = New System.Windows.Forms.Label()
        Me._lblTrackerX_0 = New System.Windows.Forms.Label()
        Me._lblTrackerX_1 = New System.Windows.Forms.Label()
        Me._lblTrackerY_1 = New System.Windows.Forms.Label()
        Me._lblTrackerZ_1 = New System.Windows.Forms.Label()
        Me._lblTrackerA_1 = New System.Windows.Forms.Label()
        Me._lblTrackerE_1 = New System.Windows.Forms.Label()
        Me._lblTrackerR_1 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.tabSettings = New System.Windows.Forms.TabControl()
        Me.tabGeneral = New System.Windows.Forms.TabPage()
        Me.fraDeviceType = New System.Windows.Forms.GroupBox()
        Me.chkDoNotConnectToDevice = New System.Windows.Forms.CheckBox()
        Me.fraWorkDir = New System.Windows.Forms.GroupBox()
        Me.chkSilentMode = New System.Windows.Forms.CheckBox()
        Me.chkNewWorkDir = New System.Windows.Forms.CheckBox()
        Me.chkTempDir = New System.Windows.Forms.CheckBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.fraDataDir = New System.Windows.Forms.GroupBox()
        Me.cmbDataDir = New System.Windows.Forms.ListBox()
        Me.fraTurntable = New System.Windows.Forms.GroupBox()
        Me.chkTTUse = New System.Windows.Forms.CheckBox()
        Me.tabFittingLeft = New System.Windows.Forms.TabPage()
        Me._Label7_0 = New System.Windows.Forms.Label()
        Me._lblImpType_0 = New System.Windows.Forms.Label()
        Me._Label14_0 = New System.Windows.Forms.Label()
        Me._Label2_0 = New System.Windows.Forms.Label()
        Me._Label3_0 = New System.Windows.Forms.Label()
        Me._Label5_0 = New System.Windows.Forms.Label()
        Me._lblMinDist_0 = New System.Windows.Forms.Label()
        Me._Label6_0 = New System.Windows.Forms.Label()
        Me._lblPPer_0 = New System.Windows.Forms.Label()
        Me._lblCycPer_0 = New System.Windows.Forms.Label()
        Me._Label9_0 = New System.Windows.Forms.Label()
        Me._Label6_4 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me._txtMinDist_0 = New System.Windows.Forms.TextBox()
        Me._txtFittFile_0 = New System.Windows.Forms.TextBox()
        Me._txtFName_0 = New System.Windows.Forms.TextBox()
        Me._txtLName_0 = New System.Windows.Forms.TextBox()
        Me._cmdFittBrowse_0 = New System.Windows.Forms.Button()
        Me._lstChInfo_0 = New System.Windows.Forms.ListBox()
        Me.cmdSourceDir = New System.Windows.Forms.Button()
        Me.tabFittingRight = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me._lblImpType_1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me._Label14_1 = New System.Windows.Forms.Label()
        Me._Label2_1 = New System.Windows.Forms.Label()
        Me._Label3_1 = New System.Windows.Forms.Label()
        Me._Label5_1 = New System.Windows.Forms.Label()
        Me._lblMinDist_1 = New System.Windows.Forms.Label()
        Me._Label6_1 = New System.Windows.Forms.Label()
        Me._lblPPer_1 = New System.Windows.Forms.Label()
        Me._lblCycPer_1 = New System.Windows.Forms.Label()
        Me._Label9_1 = New System.Windows.Forms.Label()
        Me._Label6_5 = New System.Windows.Forms.Label()
        Me._txtMinDist_1 = New System.Windows.Forms.TextBox()
        Me._txtFittFile_1 = New System.Windows.Forms.TextBox()
        Me._txtFName_1 = New System.Windows.Forms.TextBox()
        Me._txtLName_1 = New System.Windows.Forms.TextBox()
        Me._cmdFittBrowse_1 = New System.Windows.Forms.Button()
        Me._lstChInfo_1 = New System.Windows.Forms.ListBox()
        Me.tabDescription = New System.Windows.Forms.TabPage()
        Me.lblExpDescription = New System.Windows.Forms.Label()
        Me.lblExpID = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.tabExperimentScreen = New System.Windows.Forms.TabPage()
        Me.lblKeyCode = New System.Windows.Forms.Label()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.cmdExpShowResponseCodes = New System.Windows.Forms.Button()
        Me.cmdExpGetValue = New System.Windows.Forms.Button()
        Me.txtExpValue = New System.Windows.Forms.TextBox()
        Me.txtExpResponse = New System.Windows.Forms.TextBox()
        Me.cmdExpGetResponse = New System.Windows.Forms.Button()
        Me.cmdExpDisableResponse = New System.Windows.Forms.Button()
        Me.cmdExpEnableResponse = New System.Windows.Forms.Button()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.cmdExpSetSmall = New System.Windows.Forms.Button()
        Me.cmdExpSetDefault = New System.Windows.Forms.Button()
        Me.cmdExpResize = New System.Windows.Forms.Button()
        Me.txtExpLeft = New System.Windows.Forms.TextBox()
        Me.txtExpWidth = New System.Windows.Forms.TextBox()
        Me.txtExpTop = New System.Windows.Forms.TextBox()
        Me.txtExpHeight = New System.Windows.Forms.TextBox()
        Me.cmdExpGetSize = New System.Windows.Forms.Button()
        Me.cmdExpSetSize = New System.Windows.Forms.Button()
        Me._lblExp_0 = New System.Windows.Forms.Label()
        Me._lblExp_1 = New System.Windows.Forms.Label()
        Me._lblExp_2 = New System.Windows.Forms.Label()
        Me._lblExp_3 = New System.Windows.Forms.Label()
        Me.Frame3 = New System.Windows.Forms.GroupBox()
        Me.lstExpFlags = New System.Windows.Forms.CheckedListBox()
        Me.chkAlwaysOnTop = New System.Windows.Forms.CheckBox()
        Me.cmdExpBlankScreen = New System.Windows.Forms.Button()
        Me.cmdExpHide = New System.Windows.Forms.Button()
        Me.cmdExpShow = New System.Windows.Forms.Button()
        Me.cmdExpStartScreen = New System.Windows.Forms.Button()
        Me.cmdExpStimScreen = New System.Windows.Forms.Button()
        Me.cmdExpNextScreen = New System.Windows.Forms.Button()
        Me.cmdExpEndScreen = New System.Windows.Forms.Button()
        Me.cmbHUI = New System.Windows.Forms.ComboBox()
        Me.tabChannels = New System.Windows.Forms.TabPage()
        Me.cmdElDelL = New System.Windows.Forms.Button()
        Me.fraSignalR = New System.Windows.Forms.GroupBox()
        Me.txtPhDurR = New System.Windows.Forms.TextBox()
        Me.lblPhDurR = New System.Windows.Forms.Label()
        Me.cmdElDelR = New System.Windows.Forms.Button()
        Me.cmdElAddR = New System.Windows.Forms.Button()
        Me.cmdElAddL = New System.Windows.Forms.Button()
        Me.lblSignal = New System.Windows.Forms.Label()
        Me.cmbElL = New System.Windows.Forms.ComboBox()
        Me.cmbElR = New System.Windows.Forms.ComboBox()
        Me.fraSignalL = New System.Windows.Forms.GroupBox()
        Me.txtPhDurL = New System.Windows.Forms.TextBox()
        Me.lblPhDur = New System.Windows.Forms.Label()
        Me.lblPhDurQuantized = New System.Windows.Forms.Label()
        Me.lblPhDurL = New System.Windows.Forms.Label()
        Me.fraElectricalL = New System.Windows.Forms.GroupBox()
        Me.sldL = New System.Windows.Forms.TrackBar()
        Me.cmbRangeL = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me._Label3_2 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMCLL = New System.Windows.Forms.Label()
        Me.lblTHRL = New System.Windows.Forms.Label()
        Me.lblDynamicL = New System.Windows.Forms.Label()
        Me.lblLevelL = New System.Windows.Forms.Label()
        Me.fraElectricalR = New System.Windows.Forms.GroupBox()
        Me.sldR = New System.Windows.Forms.TrackBar()
        Me.cmbRangeR = New System.Windows.Forms.ComboBox()
        Me.lblDynamicR = New System.Windows.Forms.Label()
        Me.lblTHRR = New System.Windows.Forms.Label()
        Me.lblMCLR = New System.Windows.Forms.Label()
        Me.lblLevelR = New System.Windows.Forms.Label()
        Me.fraAcousticL = New System.Windows.Forms.GroupBox()
        Me.txtMCLL = New System.Windows.Forms.TextBox()
        Me.txtTHRL = New System.Windows.Forms.TextBox()
        Me.txtAmpL = New System.Windows.Forms.TextBox()
        Me.txtSPLOffsetL = New System.Windows.Forms.TextBox()
        Me.txtCenterFreqL = New System.Windows.Forms.TextBox()
        Me.txtBandwidthL = New System.Windows.Forms.TextBox()
        Me.lblMCL = New System.Windows.Forms.Label()
        Me.lblTHR = New System.Windows.Forms.Label()
        Me.lblAmp = New System.Windows.Forms.Label()
        Me.lblSPLOffset = New System.Windows.Forms.Label()
        Me.lblCenterFreq = New System.Windows.Forms.Label()
        Me.lblBandwidth = New System.Windows.Forms.Label()
        Me.fraAcousticR = New System.Windows.Forms.GroupBox()
        Me.txtMCLR = New System.Windows.Forms.TextBox()
        Me.txtTHRR = New System.Windows.Forms.TextBox()
        Me.txtAmpR = New System.Windows.Forms.TextBox()
        Me.txtSPLOffsetR = New System.Windows.Forms.TextBox()
        Me.txtCenterFreqR = New System.Windows.Forms.TextBox()
        Me.txtBandwidthR = New System.Windows.Forms.TextBox()
        Me.tabAudio = New System.Windows.Forms.TabPage()
        Me._fraAudioDither_1 = New System.Windows.Forms.GroupBox()
        Me.sldAudioDitherAmp_1 = New System.Windows.Forms.TrackBar()
        Me._txtAudioDitherPar1_1 = New System.Windows.Forms.TextBox()
        Me._cmbAudioDither_1 = New System.Windows.Forms.ComboBox()
        Me._txtAudioDitherLC_1 = New System.Windows.Forms.TextBox()
        Me._txtAudioDitherHC_1 = New System.Windows.Forms.TextBox()
        Me._lblAudio_7 = New System.Windows.Forms.Label()
        Me._lblAudio_8 = New System.Windows.Forms.Label()
        Me._lblAudio_9 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me._lblAudioDitherAmp_1 = New System.Windows.Forms.Label()
        Me._fraAudioDither_0 = New System.Windows.Forms.GroupBox()
        Me.sldAudioDitherAmp_0 = New System.Windows.Forms.TrackBar()
        Me._txtAudioDitherPar1_0 = New System.Windows.Forms.TextBox()
        Me._txtAudioDitherLC_0 = New System.Windows.Forms.TextBox()
        Me._txtAudioDitherHC_0 = New System.Windows.Forms.TextBox()
        Me._cmbAudioDither_0 = New System.Windows.Forms.ComboBox()
        Me._lblAudio_4 = New System.Windows.Forms.Label()
        Me._lblAudioDitherAmp_0 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me._lblAudio_6 = New System.Windows.Forms.Label()
        Me._lblAudio_5 = New System.Windows.Forms.Label()
        Me.txtFadeOut = New System.Windows.Forms.TextBox()
        Me.txtFadeIn = New System.Windows.Forms.TextBox()
        Me.txtResolution = New System.Windows.Forms.TextBox()
        Me.txtSamplingRate = New System.Windows.Forms.TextBox()
        Me._lblAudio_3 = New System.Windows.Forms.Label()
        Me._lblAudio_2 = New System.Windows.Forms.Label()
        Me._lblAudio_1 = New System.Windows.Forms.Label()
        Me._lblAudio_0 = New System.Windows.Forms.Label()
        Me.fraVocBox = New System.Windows.Forms.GroupBox()
        Me.facScaletxt = New System.Windows.Forms.Label()
        Me.facScalelbl = New System.Windows.Forms.TextBox()
        Me.NoiseVoc = New System.Windows.Forms.RadioButton()
        Me.GetVoc = New System.Windows.Forms.RadioButton()
        Me.facScalelbl2 = New System.Windows.Forms.TextBox()
        Me.facScaletxt2 = New System.Windows.Forms.Label()
        Me.fraAudioDACMulti = New System.Windows.Forms.GroupBox()
        Me.cmdAudioSynthAllA = New System.Windows.Forms.Button()
        Me.cmdAudioSynthAllB = New System.Windows.Forms.Button()
        Me.cmdAudioSynthDis = New System.Windows.Forms.Button()
        Me._optAudioSynthDAC_0 = New System.Windows.Forms.RadioButton()
        Me._optAudioSynthDAC_1 = New System.Windows.Forms.RadioButton()
        Me._optAudioSynthDAC_2 = New System.Windows.Forms.RadioButton()
        Me.fraAudioDACLeft = New System.Windows.Forms.GroupBox()
        Me._optAudioDitherLeft_0 = New System.Windows.Forms.RadioButton()
        Me._optAudioDitherLeft_1 = New System.Windows.Forms.RadioButton()
        Me._optAudioDitherLeft_2 = New System.Windows.Forms.RadioButton()
        Me.fraAudioDACRight = New System.Windows.Forms.GroupBox()
        Me._optAudioDitherRight_2 = New System.Windows.Forms.RadioButton()
        Me._optAudioDitherRight_1 = New System.Windows.Forms.RadioButton()
        Me._optAudioDitherRight_0 = New System.Windows.Forms.RadioButton()
        Me.tabProcedure = New System.Windows.Forms.TabPage()
        Me.txtExperimentItemRange = New System.Windows.Forms.Label()
        Me.lblPreStimVisuOffset = New System.Windows.Forms.Label()
        Me.lblExpType = New System.Windows.Forms.Label()
        Me.lblInterStimBreak = New System.Windows.Forms.Label()
        Me.lblItemRepetition = New System.Windows.Forms.Label()
        Me._lblStimOffset_2 = New System.Windows.Forms.Label()
        Me.lblPreStimBreak = New System.Windows.Forms.Label()
        Me.lblPostStimVisuOffset = New System.Windows.Forms.Label()
        Me.lblStimOffsetU = New System.Windows.Forms.Label()
        Me._lblPreStimBreakU_0 = New System.Windows.Forms.Label()
        Me._lblPreStimVisuOffsetU_1 = New System.Windows.Forms.Label()
        Me._lblInterStimBreakU_2 = New System.Windows.Forms.Label()
        Me._lblPostStimVisuOffsetU_3 = New System.Windows.Forms.Label()
        Me.chkBreak = New System.Windows.Forms.CheckBox()
        Me.tabVariables = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.txtVariablesDescr = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cmbVariables = New System.Windows.Forms.ListBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txtVariables = New System.Windows.Forms.TextBox()
        Me._lstVariables_0 = New System.Windows.Forms.ListBox()
        Me.lblVarValues = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.txtVariablesFlags = New System.Windows.Forms.TextBox()
        Me.tabConstants = New System.Windows.Forms.TabPage()
        Me._txtConstValue_0 = New System.Windows.Forms.TextBox()
        Me._lblConstUnit_0 = New System.Windows.Forms.Label()
        Me._lblConstName_0 = New System.Windows.Forms.Label()
        Me.tabTracker = New System.Windows.Forms.TabPage()
        Me.fraTrackerSettings = New System.Windows.Forms.GroupBox()
        Me.cmbTrackerRepRate = New System.Windows.Forms.ComboBox()
        Me.cmbTrackerPosScaling = New System.Windows.Forms.ComboBox()
        Me.chkTrackerUse = New System.Windows.Forms.CheckBox()
        Me.lblTrackerTimeOut = New System.Windows.Forms.Label()
        Me.lblTrackerUse = New System.Windows.Forms.Label()
        Me.lblTrackerRepRate = New System.Windows.Forms.Label()
        Me.lblTrackerPosScaling = New System.Windows.Forms.Label()
        Me.lblTrackerRepRateUnits = New System.Windows.Forms.Label()
        Me.lblTrackerPosScalingUnits = New System.Windows.Forms.Label()
        Me._fraTrackerSensor_0 = New System.Windows.Forms.GroupBox()
        Me._lblTrackerR_Range_0 = New System.Windows.Forms.Label()
        Me._lblTrackerY_Range_0 = New System.Windows.Forms.Label()
        Me._lblTrackerZ_Range_0 = New System.Windows.Forms.Label()
        Me._lblTrackerX_Range_0 = New System.Windows.Forms.Label()
        Me._lblTrackerE_Range_0 = New System.Windows.Forms.Label()
        Me._lblTrackerA_Range_0 = New System.Windows.Forms.Label()
        Me._cmdTrackerSetOffset_0 = New System.Windows.Forms.Button()
        Me._cmdTrackerSetValues_0 = New System.Windows.Forms.Button()
        Me._lblTrackerLabR_0 = New System.Windows.Forms.Label()
        Me._lblTrackerLabE_0 = New System.Windows.Forms.Label()
        Me._lblTrackerLabZ_0 = New System.Windows.Forms.Label()
        Me._lblTrackerLabY_0 = New System.Windows.Forms.Label()
        Me._lblTrackerLabA_0 = New System.Windows.Forms.Label()
        Me._lblTrackerLabX_0 = New System.Windows.Forms.Label()
        Me._fraTrackerSensor_1 = New System.Windows.Forms.GroupBox()
        Me._lblTrackerR_Range_1 = New System.Windows.Forms.Label()
        Me._lblTrackerY_Range_1 = New System.Windows.Forms.Label()
        Me._lblTrackerZ_Range_1 = New System.Windows.Forms.Label()
        Me._lblTrackerX_Range_1 = New System.Windows.Forms.Label()
        Me._lblTrackerE_Range_1 = New System.Windows.Forms.Label()
        Me._lblTrackerA_Range_1 = New System.Windows.Forms.Label()
        Me._cmdTrackerSetOffset_1 = New System.Windows.Forms.Button()
        Me._cmdTrackerSetValues_1 = New System.Windows.Forms.Button()
        Me._lblTrackerLabX_1 = New System.Windows.Forms.Label()
        Me._lblTrackerLabA_1 = New System.Windows.Forms.Label()
        Me._lblTrackerLabY_1 = New System.Windows.Forms.Label()
        Me._lblTrackerLabZ_1 = New System.Windows.Forms.Label()
        Me._lblTrackerLabE_1 = New System.Windows.Forms.Label()
        Me._lblTrackerLabR_1 = New System.Windows.Forms.Label()
        Me.chkTrackerSaveData = New System.Windows.Forms.CheckBox()
        Me.tabVirtualWorld = New System.Windows.Forms.TabPage()
        Me._fraViWoParameter_3 = New System.Windows.Forms.GroupBox()
        Me._txtViWoPar_0 = New System.Windows.Forms.TextBox()
        Me._txtViWoPar_3 = New System.Windows.Forms.TextBox()
        Me._txtViWoPar_2 = New System.Windows.Forms.TextBox()
        Me._txtViWoPar_1 = New System.Windows.Forms.TextBox()
        Me._fraViWoParameter_0 = New System.Windows.Forms.GroupBox()
        Me.txtViWoInteger = New System.Windows.Forms.TextBox()
        Me._fraViWoParameter_2 = New System.Windows.Forms.GroupBox()
        Me._txtViWoPosition_2 = New System.Windows.Forms.TextBox()
        Me._txtViWoPosition_1 = New System.Windows.Forms.TextBox()
        Me._txtViWoPosition_0 = New System.Windows.Forms.TextBox()
        Me._fraViWoParameter_1 = New System.Windows.Forms.GroupBox()
        Me.cmdViWoColor = New System.Windows.Forms.Button()
        Me.shpViWoColor = New System.Windows.Forms.Label()
        Me._Label8_0 = New System.Windows.Forms.Label()
        Me._Label8_1 = New System.Windows.Forms.Label()
        Me.chkViWoSendData = New System.Windows.Forms.CheckBox()
        Me.txtViWoAvgHead = New System.Windows.Forms.TextBox()
        Me.txtViWoAvgPointer = New System.Windows.Forms.TextBox()
        Me.lstViWoWorlds = New System.Windows.Forms.ListBox()
        Me.lstViWoParameters = New System.Windows.Forms.ListBox()
        Me._cmdViWoSendParameters_0 = New System.Windows.Forms.Button()
        Me._cmdViWoSendParameters_1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tmrExpResize = New System.Windows.Forms.Timer(Me.components)
        Me.tmrTracker = New System.Windows.Forms.Timer(Me.components)
        Me.dlgCommonDialogColor = New System.Windows.Forms.ColorDialog()
        Me.tmrRealTime = New System.Windows.Forms.Timer(Me.components)
        Me.cmbAudioDither = New Microsoft.VisualBasic.Compatibility.VB6.ComboBoxArray(Me.components)
        Me.cmdFittBrowse = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me.cmdConstCmd = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me.cmdFittClear = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me.cmdFittReload = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me.cmdFittResetPhDur = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me.cmdTrackerSetOffset = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me.cmdTrackerSetValues = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me.cmdViWoSendParameters = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me.fraAudioDither = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(Me.components)
        Me.fraTrackerSensor = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(Me.components)
        Me.fraViWoParameter = New Microsoft.VisualBasic.Compatibility.VB6.GroupBoxArray(Me.components)
        Me.lblAudio = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblAudioDitherAmp = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblConstName = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblConstUnit = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblCycPer = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblExp = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblInterStimBreakU = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblMinDist = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblPPer = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblImpType = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblPostStimVisuOffsetU = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblPreStimBreakU = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblPreStimVisuOffsetU = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblStimOffset = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerA = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerARange = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerE = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerERange = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerLabA = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerLabE = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerLabR = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerLabX = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerLabY = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerLabZ = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerR = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerRRange = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerX = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerXRange = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerY = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerYRange = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerZ = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerZRange = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lstChInfo = New Microsoft.VisualBasic.Compatibility.VB6.ListBoxArray(Me.components)
        Me.lstVariables = New Microsoft.VisualBasic.Compatibility.VB6.ListBoxArray(Me.components)
        Me.optAudioDitherLeft = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(Me.components)
        Me.optAudioDitherRight = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(Me.components)
        Me.optAudioSynthDAC = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(Me.components)
        Me.optDeviceType = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(Me.components)
        Me.txtAudioDitherHC = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.txtAudioDitherLC = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.txtAudioDitherPar1 = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.txtConstValue = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.txtFName = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.txtFittFile = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.txtLName = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.txtMinDist = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.txtViWoPosition = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.txtViWoPar = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.PanelBottom.SuspendLayout
        CType(Me.OexpMode,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tabSettings.SuspendLayout
        Me.tabGeneral.SuspendLayout
        Me.fraDeviceType.SuspendLayout
        Me.fraWorkDir.SuspendLayout
        Me.fraDataDir.SuspendLayout
        Me.fraTurntable.SuspendLayout
        Me.tabFittingLeft.SuspendLayout
        Me.tabFittingRight.SuspendLayout
        Me.tabDescription.SuspendLayout
        Me.tabExperimentScreen.SuspendLayout
        Me.Frame1.SuspendLayout
        Me.Frame2.SuspendLayout
        Me.Frame3.SuspendLayout
        Me.tabChannels.SuspendLayout
        Me.fraSignalR.SuspendLayout
        Me.fraSignalL.SuspendLayout
        Me.fraElectricalL.SuspendLayout
        CType(Me.sldL,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraElectricalR.SuspendLayout
        CType(Me.sldR,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraAcousticL.SuspendLayout
        Me.fraAcousticR.SuspendLayout
        Me.tabAudio.SuspendLayout
        Me._fraAudioDither_1.SuspendLayout
        CType(Me.sldAudioDitherAmp_1,System.ComponentModel.ISupportInitialize).BeginInit
        Me._fraAudioDither_0.SuspendLayout
        CType(Me.sldAudioDitherAmp_0,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraVocBox.SuspendLayout
        Me.fraAudioDACMulti.SuspendLayout
        Me.fraAudioDACLeft.SuspendLayout
        Me.fraAudioDACRight.SuspendLayout
        Me.tabProcedure.SuspendLayout
        Me.tabVariables.SuspendLayout
        Me.SplitContainer2.Panel1.SuspendLayout
        Me.SplitContainer2.Panel2.SuspendLayout
        Me.SplitContainer2.SuspendLayout
        Me.SplitContainer1.Panel1.SuspendLayout
        Me.SplitContainer1.Panel2.SuspendLayout
        Me.SplitContainer1.SuspendLayout
        Me.tabConstants.SuspendLayout
        Me.tabTracker.SuspendLayout
        Me.fraTrackerSettings.SuspendLayout
        Me._fraTrackerSensor_0.SuspendLayout
        Me._fraTrackerSensor_1.SuspendLayout
        Me.tabVirtualWorld.SuspendLayout
        Me._fraViWoParameter_3.SuspendLayout
        Me._fraViWoParameter_0.SuspendLayout
        Me._fraViWoParameter_2.SuspendLayout
        Me._fraViWoParameter_1.SuspendLayout
        CType(Me.cmbAudioDither,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cmdFittBrowse,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cmdConstCmd,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cmdFittClear,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cmdFittReload,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cmdFittResetPhDur,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cmdTrackerSetOffset,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cmdTrackerSetValues,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cmdViWoSendParameters,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.fraAudioDither,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.fraTrackerSensor,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.fraViWoParameter,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblAudio,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblAudioDitherAmp,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblConstName,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblConstUnit,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblCycPer,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblExp,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblInterStimBreakU,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblMinDist,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblPPer,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblImpType,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblPostStimVisuOffsetU,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblPreStimBreakU,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblPreStimVisuOffsetU,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblStimOffset,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblTrackerA,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblTrackerARange,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblTrackerE,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblTrackerERange,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblTrackerLabA,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblTrackerLabE,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblTrackerLabR,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblTrackerLabX,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblTrackerLabY,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblTrackerLabZ,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblTrackerR,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblTrackerRRange,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblTrackerX,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblTrackerXRange,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblTrackerY,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblTrackerYRange,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblTrackerZ,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lblTrackerZRange,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lstChInfo,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lstVariables,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.optAudioDitherLeft,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.optAudioDitherRight,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.optAudioSynthDAC,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.optDeviceType,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtAudioDitherHC,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtAudioDitherLC,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtAudioDitherPar1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtConstValue,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtFName,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtFittFile,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtLName,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtMinDist,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtViWoPosition,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtViWoPar,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'PanelBottom
        '
        Me.PanelBottom.Controls.Add(Me.pbProgress)
        Me.PanelBottom.Controls.Add(Me.lblRealTime)
        Me.PanelBottom.Controls.Add(Me.cmdOK)
        Me.PanelBottom.Controls.Add(Me.cmdApply)
        Me.PanelBottom.Controls.Add(Me.cmdCancel)
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 604)
        Me.PanelBottom.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(739, 86)
        Me.PanelBottom.TabIndex = 291
        '
        'pbProgress
        '
        Me.pbProgress.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbProgress.Location = New System.Drawing.Point(0, 58)
        Me.pbProgress.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pbProgress.Name = "pbProgress"
        Me.pbProgress.Size = New System.Drawing.Size(739, 28)
        Me.pbProgress.TabIndex = 290
        '
        'lblRealTime
        '
        Me.lblRealTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRealTime.BackColor = System.Drawing.SystemColors.Control
        Me.lblRealTime.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblRealTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRealTime.ForeColor = System.Drawing.Color.Red
        Me.lblRealTime.Location = New System.Drawing.Point(147, 28)
        Me.lblRealTime.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRealTime.Name = "lblRealTime"
        Me.lblRealTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblRealTime.Size = New System.Drawing.Size(232, 22)
        Me.lblRealTime.TabIndex = 289
        Me.lblRealTime.Text = "Real-time parameter changed"
        Me.lblRealTime.Visible = False
        '
        'cmdOK
        '
        Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(389, 20)
        Me.cmdOK.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(97, 31)
        Me.cmdOK.TabIndex = 0
        Me.cmdOK.Tag = "OK"
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'cmdApply
        '
        Me.cmdApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdApply.BackColor = System.Drawing.SystemColors.Control
        Me.cmdApply.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdApply.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdApply.Location = New System.Drawing.Point(605, 20)
        Me.cmdApply.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdApply.Size = New System.Drawing.Size(97, 31)
        Me.cmdApply.TabIndex = 2
        Me.cmdApply.Tag = "&Apply"
        Me.cmdApply.Text = "&Apply"
        Me.cmdApply.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(499, 20)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(97, 31)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Tag = "Cancel"
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdDestinationFromSetting
        '
        Me.cmdDestinationFromSetting.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDestinationFromSetting.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDestinationFromSetting.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDestinationFromSetting.Location = New System.Drawing.Point(509, 54)
        Me.cmdDestinationFromSetting.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdDestinationFromSetting.Name = "cmdDestinationFromSetting"
        Me.cmdDestinationFromSetting.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDestinationFromSetting.Size = New System.Drawing.Size(33, 26)
        Me.cmdDestinationFromSetting.TabIndex = 280
        Me.cmdDestinationFromSetting.Text = "!!!"
        Me.ToolTip1.SetToolTip(Me.cmdDestinationFromSetting, "Copy directory from settings directory")
        Me.cmdDestinationFromSetting.UseVisualStyleBackColor = False
        '
        'txtDestinationDir
        '
        Me.txtDestinationDir.AcceptsReturn = True
        Me.txtDestinationDir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDestinationDir.BackColor = System.Drawing.SystemColors.Window
        Me.txtDestinationDir.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDestinationDir.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDestinationDir.Location = New System.Drawing.Point(128, 54)
        Me.txtDestinationDir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDestinationDir.MaxLength = 0
        Me.txtDestinationDir.Name = "txtDestinationDir"
        Me.txtDestinationDir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDestinationDir.Size = New System.Drawing.Size(332, 22)
        Me.txtDestinationDir.TabIndex = 96
        Me.ToolTip1.SetToolTip(Me.txtDestinationDir, "where to write all log files?")
        '
        'cmdDestinationDir
        '
        Me.cmdDestinationDir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDestinationDir.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDestinationDir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDestinationDir.Location = New System.Drawing.Point(469, 53)
        Me.cmdDestinationDir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdDestinationDir.Name = "cmdDestinationDir"
        Me.cmdDestinationDir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDestinationDir.Size = New System.Drawing.Size(33, 26)
        Me.cmdDestinationDir.TabIndex = 115
        Me.cmdDestinationDir.Text = "..."
        Me.ToolTip1.SetToolTip(Me.cmdDestinationDir, "Browse directory")
        Me.cmdDestinationDir.UseVisualStyleBackColor = False
        '
        'cmdDataDir
        '
        Me.cmdDataDir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDataDir.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDataDir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDataDir.Location = New System.Drawing.Point(549, 90)
        Me.cmdDataDir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdDataDir.Name = "cmdDataDir"
        Me.cmdDataDir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDataDir.Size = New System.Drawing.Size(33, 26)
        Me.cmdDataDir.TabIndex = 120
        Me.cmdDataDir.Text = "..."
        Me.ToolTip1.SetToolTip(Me.cmdDataDir, "Browse directory")
        Me.cmdDataDir.UseVisualStyleBackColor = False
        '
        'txtDataDir
        '
        Me.txtDataDir.AcceptsReturn = True
        Me.txtDataDir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDataDir.BackColor = System.Drawing.SystemColors.Window
        Me.txtDataDir.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDataDir.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDataDir.Location = New System.Drawing.Point(27, 90)
        Me.txtDataDir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDataDir.MaxLength = 0
        Me.txtDataDir.Name = "txtDataDir"
        Me.txtDataDir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDataDir.Size = New System.Drawing.Size(515, 22)
        Me.txtDataDir.TabIndex = 119
        Me.ToolTip1.SetToolTip(Me.txtDataDir, "Data Directory")
        '
        'txtSourceDir
        '
        Me.txtSourceDir.AcceptsReturn = True
        Me.txtSourceDir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSourceDir.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSourceDir.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSourceDir.Location = New System.Drawing.Point(183, 41)
        Me.txtSourceDir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSourceDir.MaxLength = 0
        Me.txtSourceDir.Name = "txtSourceDir"
        Me.txtSourceDir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSourceDir.Size = New System.Drawing.Size(428, 22)
        Me.txtSourceDir.TabIndex = 91
        Me.ToolTip1.SetToolTip(Me.txtSourceDir, "Source Directory")
        '
        '_cmdFittClear_0
        '
        Me._cmdFittClear_0.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._cmdFittClear_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdFittClear_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdFittClear_0.Image = CType(resources.GetObject("_cmdFittClear_0.Image"), System.Drawing.Image)
        Me.cmdFittClear.SetIndex(Me._cmdFittClear_0, CType(0, Short))
        Me._cmdFittClear_0.Location = New System.Drawing.Point(549, 71)
        Me._cmdFittClear_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._cmdFittClear_0.Name = "_cmdFittClear_0"
        Me._cmdFittClear_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdFittClear_0.Size = New System.Drawing.Size(33, 26)
        Me._cmdFittClear_0.TabIndex = 207
        Me._cmdFittClear_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdFittClear_0, "Release fitting file from experiment")
        Me._cmdFittClear_0.UseVisualStyleBackColor = False
        '
        '_cmdFittReload_0
        '
        Me._cmdFittReload_0.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._cmdFittReload_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdFittReload_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdFittReload_0.Image = CType(resources.GetObject("_cmdFittReload_0.Image"), System.Drawing.Image)
        Me._cmdFittReload_0.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdFittReload.SetIndex(Me._cmdFittReload_0, CType(0, Short))
        Me._cmdFittReload_0.Location = New System.Drawing.Point(585, 71)
        Me._cmdFittReload_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._cmdFittReload_0.Name = "_cmdFittReload_0"
        Me._cmdFittReload_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdFittReload_0.Size = New System.Drawing.Size(33, 26)
        Me._cmdFittReload_0.TabIndex = 227
        Me._cmdFittReload_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdFittReload_0, "Reload fitting file from disk")
        Me._cmdFittReload_0.UseVisualStyleBackColor = False
        '
        '_cmdFittClear_1
        '
        Me._cmdFittClear_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._cmdFittClear_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdFittClear_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdFittClear_1.Image = CType(resources.GetObject("_cmdFittClear_1.Image"), System.Drawing.Image)
        Me.cmdFittClear.SetIndex(Me._cmdFittClear_1, CType(1, Short))
        Me._cmdFittClear_1.Location = New System.Drawing.Point(549, 71)
        Me._cmdFittClear_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._cmdFittClear_1.Name = "_cmdFittClear_1"
        Me._cmdFittClear_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdFittClear_1.Size = New System.Drawing.Size(33, 26)
        Me._cmdFittClear_1.TabIndex = 208
        Me._cmdFittClear_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdFittClear_1, "Release fitting file from experiment")
        Me._cmdFittClear_1.UseVisualStyleBackColor = False
        '
        '_cmdFittReload_1
        '
        Me._cmdFittReload_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._cmdFittReload_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdFittReload_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdFittReload_1.Image = CType(resources.GetObject("_cmdFittReload_1.Image"), System.Drawing.Image)
        Me._cmdFittReload_1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdFittReload.SetIndex(Me._cmdFittReload_1, CType(1, Short))
        Me._cmdFittReload_1.Location = New System.Drawing.Point(585, 71)
        Me._cmdFittReload_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._cmdFittReload_1.Name = "_cmdFittReload_1"
        Me._cmdFittReload_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdFittReload_1.Size = New System.Drawing.Size(33, 26)
        Me._cmdFittReload_1.TabIndex = 228
        Me._cmdFittReload_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me._cmdFittReload_1, "Reload fitting file from disk")
        Me._cmdFittReload_1.UseVisualStyleBackColor = False
        '
        'txtPreStimVisu
        '
        Me.txtPreStimVisu.AcceptsReturn = True
        Me.txtPreStimVisu.BackColor = System.Drawing.SystemColors.Window
        Me.txtPreStimVisu.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPreStimVisu.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPreStimVisu.Location = New System.Drawing.Point(249, 107)
        Me.txtPreStimVisu.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPreStimVisu.MaxLength = 10
        Me.txtPreStimVisu.Name = "txtPreStimVisu"
        Me.txtPreStimVisu.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPreStimVisu.Size = New System.Drawing.Size(69, 22)
        Me.txtPreStimVisu.TabIndex = 132
        Me.ToolTip1.SetToolTip(Me.txtPreStimVisu, "Duration of a visual flash before the acoustical stimulus begins.")
        '
        'cmbExpType
        '
        Me.cmbExpType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbExpType.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbExpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbExpType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbExpType.Location = New System.Drawing.Point(175, 33)
        Me.cmbExpType.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbExpType.Name = "cmbExpType"
        Me.cmbExpType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbExpType.Size = New System.Drawing.Size(475, 24)
        Me.cmbExpType.TabIndex = 129
        Me.ToolTip1.SetToolTip(Me.cmbExpType, "Selects the experiment type.")
        '
        'txtInterStimBreak
        '
        Me.txtInterStimBreak.AcceptsReturn = True
        Me.txtInterStimBreak.BackColor = System.Drawing.SystemColors.Window
        Me.txtInterStimBreak.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInterStimBreak.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtInterStimBreak.Location = New System.Drawing.Point(249, 142)
        Me.txtInterStimBreak.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtInterStimBreak.MaxLength = 10
        Me.txtInterStimBreak.Name = "txtInterStimBreak"
        Me.txtInterStimBreak.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtInterStimBreak.Size = New System.Drawing.Size(69, 22)
        Me.txtInterStimBreak.TabIndex = 133
        Me.ToolTip1.SetToolTip(Me.txtInterStimBreak, "Break between two stimuli in a stimulation sequence. Any visual offset are not in" &
        "cluded.")
        '
        'txtRepetition
        '
        Me.txtRepetition.AcceptsReturn = True
        Me.txtRepetition.BackColor = System.Drawing.SystemColors.Window
        Me.txtRepetition.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRepetition.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRepetition.Location = New System.Drawing.Point(404, 374)
        Me.txtRepetition.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtRepetition.MaxLength = 10
        Me.txtRepetition.Name = "txtRepetition"
        Me.txtRepetition.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRepetition.Size = New System.Drawing.Size(69, 22)
        Me.txtRepetition.TabIndex = 141
        Me.ToolTip1.SetToolTip(Me.txtRepetition, "Number of repetitions using ""Add repetition"" command. No order/channel combinatio" &
        "n included!")
        '
        'txtOffsetL
        '
        Me.txtOffsetL.AcceptsReturn = True
        Me.txtOffsetL.BackColor = System.Drawing.SystemColors.Window
        Me.txtOffsetL.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOffsetL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOffsetL.Location = New System.Drawing.Point(212, 201)
        Me.txtOffsetL.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtOffsetL.MaxLength = 10
        Me.txtOffsetL.Name = "txtOffsetL"
        Me.txtOffsetL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOffsetL.Size = New System.Drawing.Size(69, 22)
        Me.txtOffsetL.TabIndex = 135
        Me.ToolTip1.SetToolTip(Me.txtOffsetL, "Offset added to the begin of each stimulus to allow time shifting in any directio" &
        "n. Channel Left.")
        '
        'txtOffsetR
        '
        Me.txtOffsetR.AcceptsReturn = True
        Me.txtOffsetR.BackColor = System.Drawing.SystemColors.Window
        Me.txtOffsetR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOffsetR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOffsetR.Location = New System.Drawing.Point(287, 201)
        Me.txtOffsetR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtOffsetR.MaxLength = 10
        Me.txtOffsetR.Name = "txtOffsetR"
        Me.txtOffsetR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOffsetR.Size = New System.Drawing.Size(69, 22)
        Me.txtOffsetR.TabIndex = 136
        Me.ToolTip1.SetToolTip(Me.txtOffsetR, "Offset added to the begin of each stimulus to allow time shifting in any directio" &
        "n. Channel Right.")
        '
        'txtPreStimBreak
        '
        Me.txtPreStimBreak.AcceptsReturn = True
        Me.txtPreStimBreak.BackColor = System.Drawing.SystemColors.Window
        Me.txtPreStimBreak.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPreStimBreak.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPreStimBreak.Location = New System.Drawing.Point(249, 82)
        Me.txtPreStimBreak.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPreStimBreak.MaxLength = 10
        Me.txtPreStimBreak.Name = "txtPreStimBreak"
        Me.txtPreStimBreak.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPreStimBreak.Size = New System.Drawing.Size(69, 22)
        Me.txtPreStimBreak.TabIndex = 131
        Me.ToolTip1.SetToolTip(Me.txtPreStimBreak, "Break before the stimulus sequence starts. Pre-Stimulus Visual Offset is not incl" &
        "uded.")
        '
        'txtPostStimVisu
        '
        Me.txtPostStimVisu.AcceptsReturn = True
        Me.txtPostStimVisu.BackColor = System.Drawing.SystemColors.Window
        Me.txtPostStimVisu.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPostStimVisu.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPostStimVisu.Location = New System.Drawing.Point(249, 166)
        Me.txtPostStimVisu.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPostStimVisu.MaxLength = 10
        Me.txtPostStimVisu.Name = "txtPostStimVisu"
        Me.txtPostStimVisu.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPostStimVisu.Size = New System.Drawing.Size(69, 22)
        Me.txtPostStimVisu.TabIndex = 134
        Me.ToolTip1.SetToolTip(Me.txtPostStimVisu, "Duration of a visual flash after the acoustical stimulus ends.")
        '
        'txtBreak
        '
        Me.txtBreak.AcceptsReturn = True
        Me.txtBreak.BackColor = System.Drawing.SystemColors.Window
        Me.txtBreak.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBreak.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBreak.Location = New System.Drawing.Point(249, 330)
        Me.txtBreak.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBreak.MaxLength = 10
        Me.txtBreak.Name = "txtBreak"
        Me.txtBreak.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBreak.Size = New System.Drawing.Size(69, 22)
        Me.txtBreak.TabIndex = 138
        Me.ToolTip1.SetToolTip(Me.txtBreak, "Number of repetitions using ""Add repetition"" command. No order/channel combinatio" &
        "n included!")
        '
        'cmbBreak
        '
        Me.cmbBreak.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbBreak.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBreak.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbBreak.Location = New System.Drawing.Point(324, 330)
        Me.cmbBreak.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbBreak.Name = "cmbBreak"
        Me.cmbBreak.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbBreak.Size = New System.Drawing.Size(112, 24)
        Me.cmbBreak.TabIndex = 139
        Me.ToolTip1.SetToolTip(Me.cmbBreak, "Selects the experiment type.")
        '
        'cmdVariablesPaste
        '
        Me.cmdVariablesPaste.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdVariablesPaste.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdVariablesPaste.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdVariablesPaste.Location = New System.Drawing.Point(322, 122)
        Me.cmdVariablesPaste.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdVariablesPaste.Name = "cmdVariablesPaste"
        Me.cmdVariablesPaste.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdVariablesPaste.Size = New System.Drawing.Size(83, 26)
        Me.cmdVariablesPaste.TabIndex = 279
        Me.cmdVariablesPaste.Text = "Paste"
        Me.ToolTip1.SetToolTip(Me.cmdVariablesPaste, "Paste variables from clipboard")
        Me.cmdVariablesPaste.UseVisualStyleBackColor = False
        '
        'cmdVariablesDir
        '
        Me.cmdVariablesDir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdVariablesDir.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdVariablesDir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdVariablesDir.Location = New System.Drawing.Point(322, 63)
        Me.cmdVariablesDir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdVariablesDir.Name = "cmdVariablesDir"
        Me.cmdVariablesDir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdVariablesDir.Size = New System.Drawing.Size(83, 26)
        Me.cmdVariablesDir.TabIndex = 278
        Me.cmdVariablesDir.Text = "Add Dir..."
        Me.ToolTip1.SetToolTip(Me.cmdVariablesDir, "Browse directory")
        Me.cmdVariablesDir.UseVisualStyleBackColor = False
        '
        'cmdVariablesBrowse
        '
        Me.cmdVariablesBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdVariablesBrowse.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdVariablesBrowse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdVariablesBrowse.Location = New System.Drawing.Point(322, 92)
        Me.cmdVariablesBrowse.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdVariablesBrowse.Name = "cmdVariablesBrowse"
        Me.cmdVariablesBrowse.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdVariablesBrowse.Size = New System.Drawing.Size(83, 26)
        Me.cmdVariablesBrowse.TabIndex = 277
        Me.cmdVariablesBrowse.Text = "Add File..."
        Me.ToolTip1.SetToolTip(Me.cmdVariablesBrowse, "Browse filename")
        Me.cmdVariablesBrowse.UseVisualStyleBackColor = False
        '
        'cmdVariablesUp
        '
        Me.cmdVariablesUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdVariablesUp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdVariablesUp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdVariablesUp.Image = CType(resources.GetObject("cmdVariablesUp.Image"), System.Drawing.Image)
        Me.cmdVariablesUp.Location = New System.Drawing.Point(280, 63)
        Me.cmdVariablesUp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdVariablesUp.Name = "cmdVariablesUp"
        Me.cmdVariablesUp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdVariablesUp.Size = New System.Drawing.Size(31, 28)
        Me.cmdVariablesUp.TabIndex = 233
        Me.cmdVariablesUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdVariablesUp, "Move selected value one position up")
        Me.cmdVariablesUp.UseVisualStyleBackColor = False
        '
        'cmdVariablesDown
        '
        Me.cmdVariablesDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdVariablesDown.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdVariablesDown.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdVariablesDown.Image = CType(resources.GetObject("cmdVariablesDown.Image"), System.Drawing.Image)
        Me.cmdVariablesDown.Location = New System.Drawing.Point(280, 170)
        Me.cmdVariablesDown.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdVariablesDown.Name = "cmdVariablesDown"
        Me.cmdVariablesDown.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdVariablesDown.Size = New System.Drawing.Size(31, 28)
        Me.cmdVariablesDown.TabIndex = 232
        Me.cmdVariablesDown.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdVariablesDown, "Move selected value one position down")
        Me.cmdVariablesDown.UseVisualStyleBackColor = False
        '
        'cmdVariablesDefault
        '
        Me.cmdVariablesDefault.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdVariablesDefault.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdVariablesDefault.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdVariablesDefault.Location = New System.Drawing.Point(322, 151)
        Me.cmdVariablesDefault.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdVariablesDefault.Name = "cmdVariablesDefault"
        Me.cmdVariablesDefault.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdVariablesDefault.Size = New System.Drawing.Size(83, 26)
        Me.cmdVariablesDefault.TabIndex = 154
        Me.cmdVariablesDefault.Text = "Default"
        Me.ToolTip1.SetToolTip(Me.cmdVariablesDefault, "Fill the variables with default values." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Shortcuts:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Ctrl+D " & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & "→ Fill selected" &
        " variable with default values" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Ctrl+Shift+D " & Global.Microsoft.VisualBasic.ChrW(9) & "→ Fill ALL variables with default" &
        " values")
        Me.cmdVariablesDefault.UseVisualStyleBackColor = False
        '
        'cmdVariablesAdd
        '
        Me.cmdVariablesAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdVariablesAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdVariablesAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdVariablesAdd.Location = New System.Drawing.Point(322, 7)
        Me.cmdVariablesAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdVariablesAdd.Name = "cmdVariablesAdd"
        Me.cmdVariablesAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdVariablesAdd.Size = New System.Drawing.Size(83, 26)
        Me.cmdVariablesAdd.TabIndex = 147
        Me.cmdVariablesAdd.Text = "Add"
        Me.ToolTip1.SetToolTip(Me.cmdVariablesAdd, "Add value to the end of the list")
        Me.cmdVariablesAdd.UseVisualStyleBackColor = False
        '
        'cmdVariablesRemove
        '
        Me.cmdVariablesRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdVariablesRemove.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdVariablesRemove.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdVariablesRemove.Image = CType(resources.GetObject("cmdVariablesRemove.Image"), System.Drawing.Image)
        Me.cmdVariablesRemove.Location = New System.Drawing.Point(280, 134)
        Me.cmdVariablesRemove.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdVariablesRemove.Name = "cmdVariablesRemove"
        Me.cmdVariablesRemove.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdVariablesRemove.Size = New System.Drawing.Size(31, 28)
        Me.cmdVariablesRemove.TabIndex = 151
        Me.cmdVariablesRemove.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdVariablesRemove, "Delete selected value")
        Me.cmdVariablesRemove.UseVisualStyleBackColor = False
        '
        'cmdVariablesClear
        '
        Me.cmdVariablesClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdVariablesClear.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdVariablesClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdVariablesClear.Location = New System.Drawing.Point(322, 181)
        Me.cmdVariablesClear.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdVariablesClear.Name = "cmdVariablesClear"
        Me.cmdVariablesClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdVariablesClear.Size = New System.Drawing.Size(83, 26)
        Me.cmdVariablesClear.TabIndex = 153
        Me.cmdVariablesClear.Text = "Clear"
        Me.ToolTip1.SetToolTip(Me.cmdVariablesClear, "Clear the list")
        Me.cmdVariablesClear.UseVisualStyleBackColor = False
        '
        '_cmdConstCmd_0
        '
        Me._cmdConstCmd_0.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._cmdConstCmd_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdConstCmd_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdConstCmd.SetIndex(Me._cmdConstCmd_0, CType(0, Short))
        Me._cmdConstCmd_0.Location = New System.Drawing.Point(519, 25)
        Me._cmdConstCmd_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._cmdConstCmd_0.Name = "_cmdConstCmd_0"
        Me._cmdConstCmd_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdConstCmd_0.Size = New System.Drawing.Size(32, 26)
        Me._cmdConstCmd_0.TabIndex = 229
        Me._cmdConstCmd_0.Text = "..."
        Me.ToolTip1.SetToolTip(Me._cmdConstCmd_0, "Browse file")
        Me._cmdConstCmd_0.UseVisualStyleBackColor = False
        '
        'cmdFittEdit_0
        '
        Me.cmdFittEdit_0.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFittEdit_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFittEdit_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFittEdit_0.Image = CType(resources.GetObject("cmdFittEdit_0.Image"), System.Drawing.Image)
        Me.cmdFittEdit_0.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdFittEdit_0.Location = New System.Drawing.Point(621, 71)
        Me.cmdFittEdit_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdFittEdit_0.Name = "cmdFittEdit_0"
        Me.cmdFittEdit_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFittEdit_0.Size = New System.Drawing.Size(33, 26)
        Me.cmdFittEdit_0.TabIndex = 235
        Me.cmdFittEdit_0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdFittEdit_0, "Edit Fitting File")
        Me.cmdFittEdit_0.UseVisualStyleBackColor = False
        '
        'cmdFittEdit_1
        '
        Me.cmdFittEdit_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFittEdit_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFittEdit_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFittEdit_1.Image = CType(resources.GetObject("cmdFittEdit_1.Image"), System.Drawing.Image)
        Me.cmdFittEdit_1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdFittEdit_1.Location = New System.Drawing.Point(621, 71)
        Me.cmdFittEdit_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdFittEdit_1.Name = "cmdFittEdit_1"
        Me.cmdFittEdit_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFittEdit_1.Size = New System.Drawing.Size(33, 26)
        Me.cmdFittEdit_1.TabIndex = 236
        Me.cmdFittEdit_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdFittEdit_1, "Edit Fitting File")
        Me.cmdFittEdit_1.UseVisualStyleBackColor = False
        '
        '_cmdFittResetPhDur_0
        '
        Me._cmdFittResetPhDur_0.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me._cmdFittResetPhDur_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdFittResetPhDur_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFittResetPhDur.SetIndex(Me._cmdFittResetPhDur_0, CType(0, Short))
        Me._cmdFittResetPhDur_0.Location = New System.Drawing.Point(8, 465)
        Me._cmdFittResetPhDur_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._cmdFittResetPhDur_0.Name = "_cmdFittResetPhDur_0"
        Me._cmdFittResetPhDur_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdFittResetPhDur_0.Size = New System.Drawing.Size(136, 47)
        Me._cmdFittResetPhDur_0.TabIndex = 234
        Me._cmdFittResetPhDur_0.Text = "Reset Phase Durations"
        Me.ToolTip1.SetToolTip(Me._cmdFittResetPhDur_0, "Set the Phase Durations in the Signal tab to the default values (from the fitting" &
        " file)")
        Me._cmdFittResetPhDur_0.UseVisualStyleBackColor = False
        '
        '_cmdFittResetPhDur_1
        '
        Me._cmdFittResetPhDur_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me._cmdFittResetPhDur_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdFittResetPhDur_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFittResetPhDur.SetIndex(Me._cmdFittResetPhDur_1, CType(1, Short))
        Me._cmdFittResetPhDur_1.Location = New System.Drawing.Point(8, 465)
        Me._cmdFittResetPhDur_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._cmdFittResetPhDur_1.Name = "_cmdFittResetPhDur_1"
        Me._cmdFittResetPhDur_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdFittResetPhDur_1.Size = New System.Drawing.Size(136, 47)
        Me._cmdFittResetPhDur_1.TabIndex = 235
        Me._cmdFittResetPhDur_1.Text = "Reset Phase Durations"
        Me.ToolTip1.SetToolTip(Me._cmdFittResetPhDur_1, "Set the Phase Durations in the Signal tab to the default values (from the fitting" &
        " file)")
        Me._cmdFittResetPhDur_1.UseVisualStyleBackColor = False
        '
        'cmdSignalImport
        '
        Me.cmdSignalImport.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSignalImport.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSignalImport.Location = New System.Drawing.Point(460, 28)
        Me.cmdSignalImport.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdSignalImport.Name = "cmdSignalImport"
        Me.cmdSignalImport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSignalImport.Size = New System.Drawing.Size(115, 26)
        Me.cmdSignalImport.TabIndex = 206
        Me.cmdSignalImport.Text = "Import Amp's"
        Me.ToolTip1.SetToolTip(Me.cmdSignalImport, "Not implemented for acoustic stimulation!")
        Me.cmdSignalImport.UseVisualStyleBackColor = False
        '
        'cmbAudioSynthCh
        '
        Me.cmbAudioSynthCh.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbAudioSynthCh.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbAudioSynthCh.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbAudioSynthCh.IntegralHeight = False
        Me.cmbAudioSynthCh.ItemHeight = 16
        Me.cmbAudioSynthCh.Location = New System.Drawing.Point(16, 20)
        Me.cmbAudioSynthCh.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbAudioSynthCh.Name = "cmbAudioSynthCh"
        Me.cmbAudioSynthCh.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbAudioSynthCh.Size = New System.Drawing.Size(221, 154)
        Me.cmbAudioSynthCh.TabIndex = 213
        Me.ToolTip1.SetToolTip(Me.cmbAudioSynthCh, "You can use buttons 'A' and 'B' to set the synthesizers and 'D' to disable curren" &
        "t channel.")
        '
        'cmbDuplicate
        '
        Me.cmbDuplicate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDuplicate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbDuplicate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbDuplicate.Image = CType(resources.GetObject("cmbDuplicate.Image"), System.Drawing.Image)
        Me.cmbDuplicate.Location = New System.Drawing.Point(280, 98)
        Me.cmbDuplicate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbDuplicate.Name = "cmbDuplicate"
        Me.cmbDuplicate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbDuplicate.Size = New System.Drawing.Size(31, 28)
        Me.cmbDuplicate.TabIndex = 293
        Me.cmbDuplicate.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmbDuplicate, "Duplicate selected value")
        Me.cmbDuplicate.UseVisualStyleBackColor = False
        '
        'txtSourceDirCopy
        '
        Me.txtSourceDirCopy.AcceptsReturn = True
        Me.txtSourceDirCopy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSourceDirCopy.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSourceDirCopy.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSourceDirCopy.Location = New System.Drawing.Point(183, 41)
        Me.txtSourceDirCopy.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSourceDirCopy.MaxLength = 0
        Me.txtSourceDirCopy.Name = "txtSourceDirCopy"
        Me.txtSourceDirCopy.ReadOnly = True
        Me.txtSourceDirCopy.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSourceDirCopy.Size = New System.Drawing.Size(428, 22)
        Me.txtSourceDirCopy.TabIndex = 238
        Me.ToolTip1.SetToolTip(Me.txtSourceDirCopy, "Source Directory")
        '
        'cmdAnalysisSetting
        '
        Me.cmdAnalysisSetting.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAnalysisSetting.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAnalysisSetting.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAnalysisSetting.Location = New System.Drawing.Point(549, 54)
        Me.cmdAnalysisSetting.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdAnalysisSetting.Name = "cmdAnalysisSetting"
        Me.cmdAnalysisSetting.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAnalysisSetting.Size = New System.Drawing.Size(33, 26)
        Me.cmdAnalysisSetting.TabIndex = 291
        Me.cmdAnalysisSetting.Text = "A"
        Me.ToolTip1.SetToolTip(Me.cmdAnalysisSetting, "Create Analysis Setting")
        Me.cmdAnalysisSetting.UseVisualStyleBackColor = False
        '
        'OexpMode
        '
        Me.OexpMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OexpMode.ForeColor = System.Drawing.Color.DarkRed
        Me.OexpMode.Location = New System.Drawing.Point(199, 426)
        Me.OexpMode.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.OexpMode.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.OexpMode.Name = "OexpMode"
        Me.OexpMode.Size = New System.Drawing.Size(61, 23)
        Me.OexpMode.TabIndex = 232
        Me.ToolTip1.SetToolTip(Me.OexpMode, "Override experiment with a different mode. Please check if your AFC/IFC combinati" &
        "on allows using the desired experiment type!")
        '
        'chkOverrideExpMode
        '
        Me.chkOverrideExpMode.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkOverrideExpMode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkOverrideExpMode.Location = New System.Drawing.Point(8, 426)
        Me.chkOverrideExpMode.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkOverrideExpMode.Name = "chkOverrideExpMode"
        Me.chkOverrideExpMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkOverrideExpMode.Size = New System.Drawing.Size(288, 25)
        Me.chkOverrideExpMode.TabIndex = 233
        Me.chkOverrideExpMode.Text = "Override Exp. Mode to:"
        Me.ToolTip1.SetToolTip(Me.chkOverrideExpMode, "Override experiment with a different mode. Please check if your AFC/IFC combinati" &
        "on allows using the desired experiment type!")
        Me.chkOverrideExpMode.UseVisualStyleBackColor = False
        '
        '_optDeviceType_5
        '
        Me._optDeviceType_5.AutoSize = True
        Me._optDeviceType_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._optDeviceType_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optDeviceType.SetIndex(Me._optDeviceType_5, CType(5, Short))
        Me._optDeviceType_5.Location = New System.Drawing.Point(33, 59)
        Me._optDeviceType_5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._optDeviceType_5.Name = "_optDeviceType_5"
        Me._optDeviceType_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optDeviceType_5.Size = New System.Drawing.Size(111, 21)
        Me._optDeviceType_5.TabIndex = 92
        Me._optDeviceType_5.TabStop = True
        Me._optDeviceType_5.Text = "Audio (Unity)"
        Me.ToolTip1.SetToolTip(Me._optDeviceType_5, "Audio signal, output via Unity")
        Me._optDeviceType_5.UseVisualStyleBackColor = False
        '
        '_optDeviceType_4
        '
        Me._optDeviceType_4.AutoSize = True
        Me._optDeviceType_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._optDeviceType_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optDeviceType.SetIndex(Me._optDeviceType_4, CType(4, Short))
        Me._optDeviceType_4.Location = New System.Drawing.Point(191, 108)
        Me._optDeviceType_4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._optDeviceType_4.Name = "_optDeviceType_4"
        Me._optDeviceType_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optDeviceType_4.Size = New System.Drawing.Size(188, 21)
        Me._optDeviceType_4.TabIndex = 91
        Me._optDeviceType_4.TabStop = True
        Me._optDeviceType_4.Text = "Electrical (Vocoder/WAV)"
        Me.ToolTip1.SetToolTip(Me._optDeviceType_4, "Electric signal, vocoder, output via Pd")
        Me._optDeviceType_4.UseVisualStyleBackColor = False
        '
        '_optDeviceType_3
        '
        Me._optDeviceType_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._optDeviceType_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optDeviceType.SetIndex(Me._optDeviceType_3, CType(3, Short))
        Me._optDeviceType_3.Location = New System.Drawing.Point(191, 59)
        Me._optDeviceType_3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._optDeviceType_3.Name = "_optDeviceType_3"
        Me._optDeviceType_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optDeviceType_3.Size = New System.Drawing.Size(144, 21)
        Me._optDeviceType_3.TabIndex = 90
        Me._optDeviceType_3.TabStop = True
        Me._optDeviceType_3.Text = "Electrical (RIB2)"
        Me.ToolTip1.SetToolTip(Me._optDeviceType_3, "Electric signal, output via RIB2")
        Me._optDeviceType_3.UseVisualStyleBackColor = False
        '
        '_optDeviceType_2
        '
        Me._optDeviceType_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._optDeviceType_2.Enabled = False
        Me._optDeviceType_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optDeviceType.SetIndex(Me._optDeviceType_2, CType(2, Short))
        Me._optDeviceType_2.Location = New System.Drawing.Point(191, 84)
        Me._optDeviceType_2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._optDeviceType_2.Name = "_optDeviceType_2"
        Me._optDeviceType_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optDeviceType_2.Size = New System.Drawing.Size(144, 21)
        Me._optDeviceType_2.TabIndex = 88
        Me._optDeviceType_2.TabStop = True
        Me._optDeviceType_2.Text = "Electrical (NIC)"
        Me.ToolTip1.SetToolTip(Me._optDeviceType_2, "Electric signal, output via NIC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(not implemented yet)")
        Me._optDeviceType_2.UseVisualStyleBackColor = False
        '
        '_optDeviceType_1
        '
        Me._optDeviceType_1.AutoSize = True
        Me._optDeviceType_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._optDeviceType_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optDeviceType.SetIndex(Me._optDeviceType_1, CType(1, Short))
        Me._optDeviceType_1.Location = New System.Drawing.Point(33, 34)
        Me._optDeviceType_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._optDeviceType_1.Name = "_optDeviceType_1"
        Me._optDeviceType_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optDeviceType_1.Size = New System.Drawing.Size(96, 21)
        Me._optDeviceType_1.TabIndex = 87
        Me._optDeviceType_1.TabStop = True
        Me._optDeviceType_1.Text = "Audio (Pd)"
        Me.ToolTip1.SetToolTip(Me._optDeviceType_1, "Audio signal, output via Pd")
        Me._optDeviceType_1.UseVisualStyleBackColor = False
        '
        '_optDeviceType_0
        '
        Me._optDeviceType_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._optDeviceType_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optDeviceType.SetIndex(Me._optDeviceType_0, CType(0, Short))
        Me._optDeviceType_0.Location = New System.Drawing.Point(191, 34)
        Me._optDeviceType_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._optDeviceType_0.Name = "_optDeviceType_0"
        Me._optDeviceType_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optDeviceType_0.Size = New System.Drawing.Size(144, 21)
        Me._optDeviceType_0.TabIndex = 86
        Me._optDeviceType_0.TabStop = True
        Me._optDeviceType_0.Text = "Electrical (RIB)"
        Me.ToolTip1.SetToolTip(Me._optDeviceType_0, "Electric signal, output via RIB")
        Me._optDeviceType_0.UseVisualStyleBackColor = False
        '
        'ckbUseDataChannel
        '
        Me.ckbUseDataChannel.AutoSize = True
        Me.ckbUseDataChannel.Location = New System.Drawing.Point(68, 106)
        Me.ckbUseDataChannel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ckbUseDataChannel.Name = "ckbUseDataChannel"
        Me.ckbUseDataChannel.Size = New System.Drawing.Size(141, 21)
        Me.ckbUseDataChannel.TabIndex = 226
        Me.ckbUseDataChannel.Text = "Use data channel"
        Me.ToolTip1.SetToolTip(Me.ckbUseDataChannel, "Use data channel to transmit digital information via audio channel")
        Me.ckbUseDataChannel.UseVisualStyleBackColor = True
        '
        'ckbUseTriggerChannel
        '
        Me.ckbUseTriggerChannel.AutoSize = True
        Me.ckbUseTriggerChannel.Location = New System.Drawing.Point(235, 106)
        Me.ckbUseTriggerChannel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ckbUseTriggerChannel.Name = "ckbUseTriggerChannel"
        Me.ckbUseTriggerChannel.Size = New System.Drawing.Size(154, 21)
        Me.ckbUseTriggerChannel.TabIndex = 227
        Me.ckbUseTriggerChannel.Text = "Use trigger channel"
        Me.ToolTip1.SetToolTip(Me.ckbUseTriggerChannel, "Use data channel to transmit digital information via audio channel")
        Me.ckbUseTriggerChannel.UseVisualStyleBackColor = True
        '
        '_lblTrackerR_0
        '
        Me._lblTrackerR_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerR_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerR.SetIndex(Me._lblTrackerR_0, CType(0, Short))
        Me._lblTrackerR_0.Location = New System.Drawing.Point(359, 49)
        Me._lblTrackerR_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerR_0.Name = "_lblTrackerR_0"
        Me._lblTrackerR_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerR_0.Size = New System.Drawing.Size(71, 16)
        Me._lblTrackerR_0.TabIndex = 258
        Me._lblTrackerR_0.Text = "0"
        Me._lblTrackerR_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me._lblTrackerR_0, "Click to set range")
        '
        '_lblTrackerE_0
        '
        Me._lblTrackerE_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerE_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerE.SetIndex(Me._lblTrackerE_0, CType(0, Short))
        Me._lblTrackerE_0.Location = New System.Drawing.Point(291, 49)
        Me._lblTrackerE_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerE_0.Name = "_lblTrackerE_0"
        Me._lblTrackerE_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerE_0.Size = New System.Drawing.Size(71, 16)
        Me._lblTrackerE_0.TabIndex = 257
        Me._lblTrackerE_0.Text = "0"
        Me._lblTrackerE_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me._lblTrackerE_0, "Click to set range")
        '
        '_lblTrackerA_0
        '
        Me._lblTrackerA_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerA_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerA.SetIndex(Me._lblTrackerA_0, CType(0, Short))
        Me._lblTrackerA_0.Location = New System.Drawing.Point(209, 49)
        Me._lblTrackerA_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerA_0.Name = "_lblTrackerA_0"
        Me._lblTrackerA_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerA_0.Size = New System.Drawing.Size(71, 16)
        Me._lblTrackerA_0.TabIndex = 256
        Me._lblTrackerA_0.Text = "0"
        Me._lblTrackerA_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me._lblTrackerA_0, "Click to set range")
        '
        '_lblTrackerZ_0
        '
        Me._lblTrackerZ_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerZ_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerZ.SetIndex(Me._lblTrackerZ_0, CType(0, Short))
        Me._lblTrackerZ_0.Location = New System.Drawing.Point(123, 49)
        Me._lblTrackerZ_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerZ_0.Name = "_lblTrackerZ_0"
        Me._lblTrackerZ_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerZ_0.Size = New System.Drawing.Size(57, 16)
        Me._lblTrackerZ_0.TabIndex = 255
        Me._lblTrackerZ_0.Text = "0"
        Me._lblTrackerZ_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me._lblTrackerZ_0, "Click to set range")
        '
        '_lblTrackerY_0
        '
        Me._lblTrackerY_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerY_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerY.SetIndex(Me._lblTrackerY_0, CType(0, Short))
        Me._lblTrackerY_0.Location = New System.Drawing.Point(68, 49)
        Me._lblTrackerY_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerY_0.Name = "_lblTrackerY_0"
        Me._lblTrackerY_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerY_0.Size = New System.Drawing.Size(57, 16)
        Me._lblTrackerY_0.TabIndex = 254
        Me._lblTrackerY_0.Text = "0"
        Me._lblTrackerY_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me._lblTrackerY_0, "Click to set range")
        '
        '_lblTrackerX_0
        '
        Me._lblTrackerX_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerX_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerX.SetIndex(Me._lblTrackerX_0, CType(0, Short))
        Me._lblTrackerX_0.Location = New System.Drawing.Point(15, 49)
        Me._lblTrackerX_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerX_0.Name = "_lblTrackerX_0"
        Me._lblTrackerX_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerX_0.Size = New System.Drawing.Size(57, 16)
        Me._lblTrackerX_0.TabIndex = 249
        Me._lblTrackerX_0.Text = "0"
        Me._lblTrackerX_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me._lblTrackerX_0, "Click to set range")
        '
        '_lblTrackerX_1
        '
        Me._lblTrackerX_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerX_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerX.SetIndex(Me._lblTrackerX_1, CType(1, Short))
        Me._lblTrackerX_1.Location = New System.Drawing.Point(15, 49)
        Me._lblTrackerX_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerX_1.Name = "_lblTrackerX_1"
        Me._lblTrackerX_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerX_1.Size = New System.Drawing.Size(57, 16)
        Me._lblTrackerX_1.TabIndex = 270
        Me._lblTrackerX_1.Text = "0"
        Me._lblTrackerX_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me._lblTrackerX_1, "Click to set range")
        '
        '_lblTrackerY_1
        '
        Me._lblTrackerY_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerY_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerY.SetIndex(Me._lblTrackerY_1, CType(1, Short))
        Me._lblTrackerY_1.Location = New System.Drawing.Point(68, 49)
        Me._lblTrackerY_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerY_1.Name = "_lblTrackerY_1"
        Me._lblTrackerY_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerY_1.Size = New System.Drawing.Size(57, 16)
        Me._lblTrackerY_1.TabIndex = 265
        Me._lblTrackerY_1.Text = "0"
        Me._lblTrackerY_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me._lblTrackerY_1, "Click to set range")
        '
        '_lblTrackerZ_1
        '
        Me._lblTrackerZ_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerZ_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerZ.SetIndex(Me._lblTrackerZ_1, CType(1, Short))
        Me._lblTrackerZ_1.Location = New System.Drawing.Point(123, 49)
        Me._lblTrackerZ_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerZ_1.Name = "_lblTrackerZ_1"
        Me._lblTrackerZ_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerZ_1.Size = New System.Drawing.Size(57, 16)
        Me._lblTrackerZ_1.TabIndex = 264
        Me._lblTrackerZ_1.Text = "0"
        Me._lblTrackerZ_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me._lblTrackerZ_1, "Click to set range")
        '
        '_lblTrackerA_1
        '
        Me._lblTrackerA_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerA_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerA.SetIndex(Me._lblTrackerA_1, CType(1, Short))
        Me._lblTrackerA_1.Location = New System.Drawing.Point(209, 49)
        Me._lblTrackerA_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerA_1.Name = "_lblTrackerA_1"
        Me._lblTrackerA_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerA_1.Size = New System.Drawing.Size(71, 16)
        Me._lblTrackerA_1.TabIndex = 263
        Me._lblTrackerA_1.Text = "0"
        Me._lblTrackerA_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me._lblTrackerA_1, "Click to set range")
        '
        '_lblTrackerE_1
        '
        Me._lblTrackerE_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerE_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerE.SetIndex(Me._lblTrackerE_1, CType(1, Short))
        Me._lblTrackerE_1.Location = New System.Drawing.Point(291, 49)
        Me._lblTrackerE_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerE_1.Name = "_lblTrackerE_1"
        Me._lblTrackerE_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerE_1.Size = New System.Drawing.Size(71, 16)
        Me._lblTrackerE_1.TabIndex = 262
        Me._lblTrackerE_1.Text = "0"
        Me._lblTrackerE_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me._lblTrackerE_1, "Click to set range")
        '
        '_lblTrackerR_1
        '
        Me._lblTrackerR_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerR_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerR.SetIndex(Me._lblTrackerR_1, CType(1, Short))
        Me._lblTrackerR_1.Location = New System.Drawing.Point(359, 49)
        Me._lblTrackerR_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerR_1.Name = "_lblTrackerR_1"
        Me._lblTrackerR_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerR_1.Size = New System.Drawing.Size(71, 16)
        Me._lblTrackerR_1.TabIndex = 261
        Me._lblTrackerR_1.Text = "0"
        Me._lblTrackerR_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me._lblTrackerR_1, "Click to set range")
        '
        'txtID
        '
        Me.txtID.AcceptsReturn = True
        Me.txtID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtID.BackColor = System.Drawing.SystemColors.Window
        Me.txtID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtID.Location = New System.Drawing.Point(220, 58)
        Me.txtID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtID.MaxLength = 0
        Me.txtID.Name = "txtID"
        Me.txtID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtID.Size = New System.Drawing.Size(431, 22)
        Me.txtID.TabIndex = 38
        Me.ToolTip1.SetToolTip(Me.txtID, "The experiment ID is used for file and folder names creations, and when specific " &
        "scripts are loaded (application-dependent).")
        '
        'tabSettings
        '
        Me.tabSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabSettings.Controls.Add(Me.tabGeneral)
        Me.tabSettings.Controls.Add(Me.tabFittingLeft)
        Me.tabSettings.Controls.Add(Me.tabFittingRight)
        Me.tabSettings.Controls.Add(Me.tabDescription)
        Me.tabSettings.Controls.Add(Me.tabExperimentScreen)
        Me.tabSettings.Controls.Add(Me.tabChannels)
        Me.tabSettings.Controls.Add(Me.tabAudio)
        Me.tabSettings.Controls.Add(Me.tabProcedure)
        Me.tabSettings.Controls.Add(Me.tabVariables)
        Me.tabSettings.Controls.Add(Me.tabConstants)
        Me.tabSettings.Controls.Add(Me.tabTracker)
        Me.tabSettings.Controls.Add(Me.tabVirtualWorld)
        Me.tabSettings.ItemSize = New System.Drawing.Size(42, 18)
        Me.tabSettings.Location = New System.Drawing.Point(16, 0)
        Me.tabSettings.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabSettings.Multiline = True
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.SelectedIndex = 5
        Me.tabSettings.Size = New System.Drawing.Size(696, 583)
        Me.tabSettings.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.tabSettings.TabIndex = 4
        '
        'tabGeneral
        '
        Me.tabGeneral.Controls.Add(Me.fraDeviceType)
        Me.tabGeneral.Controls.Add(Me.fraWorkDir)
        Me.tabGeneral.Controls.Add(Me.fraDataDir)
        Me.tabGeneral.Controls.Add(Me.fraTurntable)
        Me.tabGeneral.Location = New System.Drawing.Point(4, 40)
        Me.tabGeneral.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabGeneral.Name = "tabGeneral"
        Me.tabGeneral.Size = New System.Drawing.Size(688, 539)
        Me.tabGeneral.TabIndex = 0
        Me.tabGeneral.Text = "General"
        Me.tabGeneral.UseVisualStyleBackColor = True
        '
        'fraDeviceType
        '
        Me.fraDeviceType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraDeviceType.Controls.Add(Me._optDeviceType_5)
        Me.fraDeviceType.Controls.Add(Me._optDeviceType_4)
        Me.fraDeviceType.Controls.Add(Me._optDeviceType_3)
        Me.fraDeviceType.Controls.Add(Me.chkDoNotConnectToDevice)
        Me.fraDeviceType.Controls.Add(Me._optDeviceType_2)
        Me.fraDeviceType.Controls.Add(Me._optDeviceType_1)
        Me.fraDeviceType.Controls.Add(Me._optDeviceType_0)
        Me.fraDeviceType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraDeviceType.Location = New System.Drawing.Point(43, 20)
        Me.fraDeviceType.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraDeviceType.Name = "fraDeviceType"
        Me.fraDeviceType.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraDeviceType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraDeviceType.Size = New System.Drawing.Size(592, 172)
        Me.fraDeviceType.TabIndex = 85
        Me.fraDeviceType.TabStop = False
        Me.fraDeviceType.Text = "Signal (Output):"
        '
        'chkDoNotConnectToDevice
        '
        Me.chkDoNotConnectToDevice.AutoSize = True
        Me.chkDoNotConnectToDevice.Location = New System.Drawing.Point(77, 138)
        Me.chkDoNotConnectToDevice.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkDoNotConnectToDevice.Name = "chkDoNotConnectToDevice"
        Me.chkDoNotConnectToDevice.Size = New System.Drawing.Size(186, 21)
        Me.chkDoNotConnectToDevice.TabIndex = 89
        Me.chkDoNotConnectToDevice.Text = "Do not connect to output"
        Me.chkDoNotConnectToDevice.UseVisualStyleBackColor = True
        '
        'fraWorkDir
        '
        Me.fraWorkDir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraWorkDir.Controls.Add(Me.cmdAnalysisSetting)
        Me.fraWorkDir.Controls.Add(Me.chkSilentMode)
        Me.fraWorkDir.Controls.Add(Me.cmdDestinationFromSetting)
        Me.fraWorkDir.Controls.Add(Me.chkNewWorkDir)
        Me.fraWorkDir.Controls.Add(Me.txtDestinationDir)
        Me.fraWorkDir.Controls.Add(Me.chkTempDir)
        Me.fraWorkDir.Controls.Add(Me.cmdDestinationDir)
        Me.fraWorkDir.Controls.Add(Me.Label32)
        Me.fraWorkDir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraWorkDir.Location = New System.Drawing.Point(43, 193)
        Me.fraWorkDir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraWorkDir.Name = "fraWorkDir"
        Me.fraWorkDir.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraWorkDir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraWorkDir.Size = New System.Drawing.Size(592, 134)
        Me.fraWorkDir.TabIndex = 95
        Me.fraWorkDir.TabStop = False
        Me.fraWorkDir.Text = "Output directory:"
        '
        'chkSilentMode
        '
        Me.chkSilentMode.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkSilentMode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkSilentMode.Location = New System.Drawing.Point(27, 108)
        Me.chkSilentMode.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkSilentMode.Name = "chkSilentMode"
        Me.chkSilentMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkSilentMode.Size = New System.Drawing.Size(412, 21)
        Me.chkSilentMode.TabIndex = 290
        Me.chkSilentMode.Text = "Silent Mode (no logging to files or list)"
        Me.chkSilentMode.UseVisualStyleBackColor = False
        '
        'chkNewWorkDir
        '
        Me.chkNewWorkDir.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkNewWorkDir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkNewWorkDir.Location = New System.Drawing.Point(27, 89)
        Me.chkNewWorkDir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkNewWorkDir.Name = "chkNewWorkDir"
        Me.chkNewWorkDir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkNewWorkDir.Size = New System.Drawing.Size(412, 21)
        Me.chkNewWorkDir.TabIndex = 236
        Me.chkNewWorkDir.Text = "Create Working Directory (Syntax: Root\ID_Date_Time\)"
        Me.chkNewWorkDir.UseVisualStyleBackColor = False
        '
        'chkTempDir
        '
        Me.chkTempDir.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkTempDir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkTempDir.Location = New System.Drawing.Point(27, 21)
        Me.chkTempDir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkTempDir.Name = "chkTempDir"
        Me.chkTempDir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkTempDir.Size = New System.Drawing.Size(364, 32)
        Me.chkTempDir.TabIndex = 116
        Me.chkTempDir.Text = "Use temporary directory of windows"
        Me.chkTempDir.UseVisualStyleBackColor = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(21, 59)
        Me.Label32.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label32.Size = New System.Drawing.Size(101, 17)
        Me.Label32.TabIndex = 117
        Me.Label32.Text = "Root directory:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'fraDataDir
        '
        Me.fraDataDir.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraDataDir.Controls.Add(Me.cmbDataDir)
        Me.fraDataDir.Controls.Add(Me.cmdDataDir)
        Me.fraDataDir.Controls.Add(Me.txtDataDir)
        Me.fraDataDir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraDataDir.Location = New System.Drawing.Point(43, 330)
        Me.fraDataDir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraDataDir.Name = "fraDataDir"
        Me.fraDataDir.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraDataDir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraDataDir.Size = New System.Drawing.Size(592, 129)
        Me.fraDataDir.TabIndex = 118
        Me.fraDataDir.TabStop = False
        Me.fraDataDir.Text = "Data directories:"
        '
        'cmbDataDir
        '
        Me.cmbDataDir.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDataDir.BackColor = System.Drawing.SystemColors.Window
        Me.cmbDataDir.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbDataDir.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbDataDir.ItemHeight = 16
        Me.cmbDataDir.Location = New System.Drawing.Point(27, 25)
        Me.cmbDataDir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbDataDir.Name = "cmbDataDir"
        Me.cmbDataDir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbDataDir.Size = New System.Drawing.Size(515, 52)
        Me.cmbDataDir.TabIndex = 291
        '
        'fraTurntable
        '
        Me.fraTurntable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraTurntable.Controls.Add(Me.chkTTUse)
        Me.fraTurntable.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraTurntable.Location = New System.Drawing.Point(43, 462)
        Me.fraTurntable.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraTurntable.Name = "fraTurntable"
        Me.fraTurntable.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraTurntable.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraTurntable.Size = New System.Drawing.Size(592, 59)
        Me.fraTurntable.TabIndex = 275
        Me.fraTurntable.TabStop = False
        Me.fraTurntable.Text = "Turntable"
        '
        'chkTTUse
        '
        Me.chkTTUse.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkTTUse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkTTUse.Location = New System.Drawing.Point(27, 22)
        Me.chkTTUse.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkTTUse.Name = "chkTTUse"
        Me.chkTTUse.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkTTUse.Size = New System.Drawing.Size(192, 28)
        Me.chkTTUse.TabIndex = 276
        Me.chkTTUse.Text = "Use Turntable"
        Me.chkTTUse.UseVisualStyleBackColor = False
        '
        'tabFittingLeft
        '
        Me.tabFittingLeft.Controls.Add(Me._Label7_0)
        Me.tabFittingLeft.Controls.Add(Me._lblImpType_0)
        Me.tabFittingLeft.Controls.Add(Me.cmdFittEdit_0)
        Me.tabFittingLeft.Controls.Add(Me._Label14_0)
        Me.tabFittingLeft.Controls.Add(Me._Label2_0)
        Me.tabFittingLeft.Controls.Add(Me._Label3_0)
        Me.tabFittingLeft.Controls.Add(Me._Label5_0)
        Me.tabFittingLeft.Controls.Add(Me._lblMinDist_0)
        Me.tabFittingLeft.Controls.Add(Me._Label6_0)
        Me.tabFittingLeft.Controls.Add(Me._lblPPer_0)
        Me.tabFittingLeft.Controls.Add(Me._lblCycPer_0)
        Me.tabFittingLeft.Controls.Add(Me._Label9_0)
        Me.tabFittingLeft.Controls.Add(Me._Label6_4)
        Me.tabFittingLeft.Controls.Add(Me.Label4)
        Me.tabFittingLeft.Controls.Add(Me._txtMinDist_0)
        Me.tabFittingLeft.Controls.Add(Me._txtFittFile_0)
        Me.tabFittingLeft.Controls.Add(Me._txtFName_0)
        Me.tabFittingLeft.Controls.Add(Me._txtLName_0)
        Me.tabFittingLeft.Controls.Add(Me._cmdFittBrowse_0)
        Me.tabFittingLeft.Controls.Add(Me._lstChInfo_0)
        Me.tabFittingLeft.Controls.Add(Me.cmdSourceDir)
        Me.tabFittingLeft.Controls.Add(Me.txtSourceDir)
        Me.tabFittingLeft.Controls.Add(Me._cmdFittClear_0)
        Me.tabFittingLeft.Controls.Add(Me._cmdFittReload_0)
        Me.tabFittingLeft.Controls.Add(Me._cmdFittResetPhDur_0)
        Me.tabFittingLeft.Location = New System.Drawing.Point(4, 40)
        Me.tabFittingLeft.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabFittingLeft.Name = "tabFittingLeft"
        Me.tabFittingLeft.Size = New System.Drawing.Size(688, 539)
        Me.tabFittingLeft.TabIndex = 1
        Me.tabFittingLeft.Text = "Fitting Left"
        Me.tabFittingLeft.UseVisualStyleBackColor = True
        '
        '_Label7_0
        '
        Me._Label7_0.AutoSize = True
        Me._Label7_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label7_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label7_0.Location = New System.Drawing.Point(80, 171)
        Me._Label7_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label7_0.Name = "_Label7_0"
        Me._Label7_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label7_0.Size = New System.Drawing.Size(93, 17)
        Me._Label7_0.TabIndex = 236
        Me._Label7_0.Text = "Implant Type:"
        Me._Label7_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblImpType_0
        '
        Me._lblImpType_0.AutoSize = True
        Me._lblImpType_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblImpType_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblImpType.SetIndex(Me._lblImpType_0, CType(0, Short))
        Me._lblImpType_0.Location = New System.Drawing.Point(183, 171)
        Me._lblImpType_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblImpType_0.Name = "_lblImpType_0"
        Me._lblImpType_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblImpType_0.Size = New System.Drawing.Size(35, 17)
        Me._lblImpType_0.TabIndex = 237
        Me._lblImpType_0.Text = "XXX"
        '
        '_Label14_0
        '
        Me._Label14_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label14_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label14_0.Location = New System.Drawing.Point(88, 78)
        Me._Label14_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label14_0.Name = "_Label14_0"
        Me._Label14_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label14_0.Size = New System.Drawing.Size(85, 20)
        Me._Label14_0.TabIndex = 20
        Me._Label14_0.Text = "Fitting file:"
        Me._Label14_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Label2_0
        '
        Me._Label2_0.AutoSize = True
        Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_0.Location = New System.Drawing.Point(93, 112)
        Me._Label2_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label2_0.Name = "_Label2_0"
        Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_0.Size = New System.Drawing.Size(80, 17)
        Me._Label2_0.TabIndex = 21
        Me._Label2_0.Text = "First Name:"
        Me._Label2_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Label3_0
        '
        Me._Label3_0.AutoSize = True
        Me._Label3_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label3_0.Location = New System.Drawing.Point(92, 142)
        Me._Label3_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label3_0.Name = "_Label3_0"
        Me._Label3_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_0.Size = New System.Drawing.Size(80, 17)
        Me._Label3_0.TabIndex = 22
        Me._Label3_0.Text = "Last Name:"
        Me._Label3_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Label5_0
        '
        Me._Label5_0.AutoSize = True
        Me._Label5_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label5_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label5_0.Location = New System.Drawing.Point(77, 199)
        Me._Label5_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label5_0.Name = "_Label5_0"
        Me._Label5_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label5_0.Size = New System.Drawing.Size(93, 17)
        Me._Label5_0.TabIndex = 23
        Me._Label5_0.Text = "Min Distance:"
        Me._Label5_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblMinDist_0
        '
        Me._lblMinDist_0.AutoSize = True
        Me._lblMinDist_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMinDist_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMinDist.SetIndex(Me._lblMinDist_0, CType(0, Short))
        Me._lblMinDist_0.Location = New System.Drawing.Point(276, 199)
        Me._lblMinDist_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblMinDist_0.Name = "_lblMinDist_0"
        Me._lblMinDist_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMinDist_0.Size = New System.Drawing.Size(82, 17)
        Me._lblMinDist_0.TabIndex = 24
        Me._lblMinDist_0.Text = "tu = XXX µs"
        '
        '_Label6_0
        '
        Me._Label6_0.AutoSize = True
        Me._Label6_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label6_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label6_0.Location = New System.Drawing.Point(83, 229)
        Me._Label6_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label6_0.Name = "_Label6_0"
        Me._Label6_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label6_0.Size = New System.Drawing.Size(91, 17)
        Me._Label6_0.TabIndex = 25
        Me._Label6_0.Text = "Pulse period:"
        Me._Label6_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblPPer_0
        '
        Me._lblPPer_0.AutoSize = True
        Me._lblPPer_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPPer_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPPer.SetIndex(Me._lblPPer_0, CType(0, Short))
        Me._lblPPer_0.Location = New System.Drawing.Point(183, 229)
        Me._lblPPer_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblPPer_0.Name = "_lblPPer_0"
        Me._lblPPer_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPPer_0.Size = New System.Drawing.Size(35, 17)
        Me._lblPPer_0.TabIndex = 26
        Me._lblPPer_0.Text = "XXX"
        '
        '_lblCycPer_0
        '
        Me._lblCycPer_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCycPer_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCycPer.SetIndex(Me._lblCycPer_0, CType(0, Short))
        Me._lblCycPer_0.Location = New System.Drawing.Point(183, 254)
        Me._lblCycPer_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblCycPer_0.Name = "_lblCycPer_0"
        Me._lblCycPer_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCycPer_0.Size = New System.Drawing.Size(177, 16)
        Me._lblCycPer_0.TabIndex = 29
        Me._lblCycPer_0.Text = "XXX"
        '
        '_Label9_0
        '
        Me._Label9_0.AutoSize = True
        Me._Label9_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label9_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label9_0.Location = New System.Drawing.Point(95, 254)
        Me._Label9_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label9_0.Name = "_Label9_0"
        Me._Label9_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label9_0.Size = New System.Drawing.Size(78, 17)
        Me._Label9_0.TabIndex = 30
        Me._Label9_0.Text = "Time base:"
        Me._Label9_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Label6_4
        '
        Me._Label6_4.AutoSize = True
        Me._Label6_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label6_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label6_4.Location = New System.Drawing.Point(4, 283)
        Me._Label6_4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label6_4.Name = "_Label6_4"
        Me._Label6_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label6_4.Size = New System.Drawing.Size(138, 17)
        Me._Label6_4.TabIndex = 33
        Me._Label6_4.Text = "Channel information:"
        '
        'Label4
        '
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(52, 46)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(123, 16)
        Me.Label4.TabIndex = 94
        Me.Label4.Text = "Source Directory:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_txtMinDist_0
        '
        Me._txtMinDist_0.AcceptsReturn = True
        Me._txtMinDist_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtMinDist_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMinDist.SetIndex(Me._txtMinDist_0, CType(0, Short))
        Me._txtMinDist_0.Location = New System.Drawing.Point(183, 194)
        Me._txtMinDist_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._txtMinDist_0.MaxLength = 0
        Me._txtMinDist_0.Name = "_txtMinDist_0"
        Me._txtMinDist_0.ReadOnly = True
        Me._txtMinDist_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtMinDist_0.Size = New System.Drawing.Size(84, 22)
        Me._txtMinDist_0.TabIndex = 6
        '
        '_txtFittFile_0
        '
        Me._txtFittFile_0.AcceptsReturn = True
        Me._txtFittFile_0.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._txtFittFile_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFittFile_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFittFile.SetIndex(Me._txtFittFile_0, CType(0, Short))
        Me._txtFittFile_0.Location = New System.Drawing.Point(183, 73)
        Me._txtFittFile_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._txtFittFile_0.MaxLength = 0
        Me._txtFittFile_0.Name = "_txtFittFile_0"
        Me._txtFittFile_0.ReadOnly = True
        Me._txtFittFile_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFittFile_0.Size = New System.Drawing.Size(321, 22)
        Me._txtFittFile_0.TabIndex = 10
        '
        '_txtFName_0
        '
        Me._txtFName_0.AcceptsReturn = True
        Me._txtFName_0.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._txtFName_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFName_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFName.SetIndex(Me._txtFName_0, CType(0, Short))
        Me._txtFName_0.Location = New System.Drawing.Point(183, 108)
        Me._txtFName_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._txtFName_0.MaxLength = 0
        Me._txtFName_0.Name = "_txtFName_0"
        Me._txtFName_0.ReadOnly = True
        Me._txtFName_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFName_0.Size = New System.Drawing.Size(321, 22)
        Me._txtFName_0.TabIndex = 11
        Me._txtFName_0.Text = "XXX"
        '
        '_txtLName_0
        '
        Me._txtLName_0.AcceptsReturn = True
        Me._txtLName_0.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._txtLName_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtLName_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLName.SetIndex(Me._txtLName_0, CType(0, Short))
        Me._txtLName_0.Location = New System.Drawing.Point(183, 138)
        Me._txtLName_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._txtLName_0.MaxLength = 0
        Me._txtLName_0.Name = "_txtLName_0"
        Me._txtLName_0.ReadOnly = True
        Me._txtLName_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtLName_0.Size = New System.Drawing.Size(321, 22)
        Me._txtLName_0.TabIndex = 12
        Me._txtLName_0.Text = "XXX"
        '
        '_cmdFittBrowse_0
        '
        Me._cmdFittBrowse_0.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._cmdFittBrowse_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdFittBrowse_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFittBrowse.SetIndex(Me._cmdFittBrowse_0, CType(0, Short))
        Me._cmdFittBrowse_0.Location = New System.Drawing.Point(513, 71)
        Me._cmdFittBrowse_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._cmdFittBrowse_0.Name = "_cmdFittBrowse_0"
        Me._cmdFittBrowse_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdFittBrowse_0.Size = New System.Drawing.Size(33, 26)
        Me._cmdFittBrowse_0.TabIndex = 27
        Me._cmdFittBrowse_0.Text = "..."
        Me._cmdFittBrowse_0.UseVisualStyleBackColor = False
        '
        '_lstChInfo_0
        '
        Me._lstChInfo_0.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._lstChInfo_0.BackColor = System.Drawing.SystemColors.Window
        Me._lstChInfo_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lstChInfo_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstChInfo.SetIndex(Me._lstChInfo_0, CType(0, Short))
        Me._lstChInfo_0.ItemHeight = 16
        Me._lstChInfo_0.Location = New System.Drawing.Point(152, 283)
        Me._lstChInfo_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._lstChInfo_0.Name = "_lstChInfo_0"
        Me._lstChInfo_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lstChInfo_0.Size = New System.Drawing.Size(501, 228)
        Me._lstChInfo_0.TabIndex = 34
        '
        'cmdSourceDir
        '
        Me.cmdSourceDir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSourceDir.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSourceDir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSourceDir.Location = New System.Drawing.Point(620, 39)
        Me.cmdSourceDir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdSourceDir.Name = "cmdSourceDir"
        Me.cmdSourceDir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSourceDir.Size = New System.Drawing.Size(35, 26)
        Me.cmdSourceDir.TabIndex = 92
        Me.cmdSourceDir.Text = "..."
        Me.cmdSourceDir.UseVisualStyleBackColor = False
        '
        'tabFittingRight
        '
        Me.tabFittingRight.Controls.Add(Me.Label5)
        Me.tabFittingRight.Controls.Add(Me._lblImpType_1)
        Me.tabFittingRight.Controls.Add(Me.txtSourceDirCopy)
        Me.tabFittingRight.Controls.Add(Me.Label2)
        Me.tabFittingRight.Controls.Add(Me.cmdFittEdit_1)
        Me.tabFittingRight.Controls.Add(Me._Label14_1)
        Me.tabFittingRight.Controls.Add(Me._Label2_1)
        Me.tabFittingRight.Controls.Add(Me._Label3_1)
        Me.tabFittingRight.Controls.Add(Me._Label5_1)
        Me.tabFittingRight.Controls.Add(Me._lblMinDist_1)
        Me.tabFittingRight.Controls.Add(Me._Label6_1)
        Me.tabFittingRight.Controls.Add(Me._lblPPer_1)
        Me.tabFittingRight.Controls.Add(Me._lblCycPer_1)
        Me.tabFittingRight.Controls.Add(Me._Label9_1)
        Me.tabFittingRight.Controls.Add(Me._Label6_5)
        Me.tabFittingRight.Controls.Add(Me._txtMinDist_1)
        Me.tabFittingRight.Controls.Add(Me._txtFittFile_1)
        Me.tabFittingRight.Controls.Add(Me._txtFName_1)
        Me.tabFittingRight.Controls.Add(Me._txtLName_1)
        Me.tabFittingRight.Controls.Add(Me._cmdFittBrowse_1)
        Me.tabFittingRight.Controls.Add(Me._lstChInfo_1)
        Me.tabFittingRight.Controls.Add(Me._cmdFittClear_1)
        Me.tabFittingRight.Controls.Add(Me._cmdFittReload_1)
        Me.tabFittingRight.Controls.Add(Me._cmdFittResetPhDur_1)
        Me.tabFittingRight.Location = New System.Drawing.Point(4, 40)
        Me.tabFittingRight.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabFittingRight.Name = "tabFittingRight"
        Me.tabFittingRight.Size = New System.Drawing.Size(688, 539)
        Me.tabFittingRight.TabIndex = 2
        Me.tabFittingRight.Text = "Fitting Right"
        Me.tabFittingRight.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(80, 171)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(93, 17)
        Me.Label5.TabIndex = 239
        Me.Label5.Text = "Implant Type:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblImpType_1
        '
        Me._lblImpType_1.AutoSize = True
        Me._lblImpType_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblImpType_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblImpType.SetIndex(Me._lblImpType_1, CType(1, Short))
        Me._lblImpType_1.Location = New System.Drawing.Point(183, 171)
        Me._lblImpType_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblImpType_1.Name = "_lblImpType_1"
        Me._lblImpType_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblImpType_1.Size = New System.Drawing.Size(35, 17)
        Me._lblImpType_1.TabIndex = 240
        Me._lblImpType_1.Text = "XXX"
        '
        'Label2
        '
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(52, 46)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(123, 16)
        Me.Label2.TabIndex = 237
        Me.Label2.Text = "Source Directory:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Label14_1
        '
        Me._Label14_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label14_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label14_1.Location = New System.Drawing.Point(88, 78)
        Me._Label14_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label14_1.Name = "_Label14_1"
        Me._Label14_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label14_1.Size = New System.Drawing.Size(85, 20)
        Me._Label14_1.TabIndex = 13
        Me._Label14_1.Text = "Fitting file:"
        Me._Label14_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Label2_1
        '
        Me._Label2_1.AutoSize = True
        Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_1.Location = New System.Drawing.Point(93, 112)
        Me._Label2_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label2_1.Name = "_Label2_1"
        Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_1.Size = New System.Drawing.Size(80, 17)
        Me._Label2_1.TabIndex = 14
        Me._Label2_1.Text = "First Name:"
        Me._Label2_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Label3_1
        '
        Me._Label3_1.AutoSize = True
        Me._Label3_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label3_1.Location = New System.Drawing.Point(92, 142)
        Me._Label3_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label3_1.Name = "_Label3_1"
        Me._Label3_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_1.Size = New System.Drawing.Size(80, 17)
        Me._Label3_1.TabIndex = 15
        Me._Label3_1.Text = "Last Name:"
        Me._Label3_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Label5_1
        '
        Me._Label5_1.AutoSize = True
        Me._Label5_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label5_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label5_1.Location = New System.Drawing.Point(77, 199)
        Me._Label5_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label5_1.Name = "_Label5_1"
        Me._Label5_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label5_1.Size = New System.Drawing.Size(93, 17)
        Me._Label5_1.TabIndex = 16
        Me._Label5_1.Text = "Min Distance:"
        Me._Label5_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblMinDist_1
        '
        Me._lblMinDist_1.AutoSize = True
        Me._lblMinDist_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMinDist_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMinDist.SetIndex(Me._lblMinDist_1, CType(1, Short))
        Me._lblMinDist_1.Location = New System.Drawing.Point(276, 199)
        Me._lblMinDist_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblMinDist_1.Name = "_lblMinDist_1"
        Me._lblMinDist_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMinDist_1.Size = New System.Drawing.Size(82, 17)
        Me._lblMinDist_1.TabIndex = 17
        Me._lblMinDist_1.Text = "tu = XXX µs"
        '
        '_Label6_1
        '
        Me._Label6_1.AutoSize = True
        Me._Label6_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label6_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label6_1.Location = New System.Drawing.Point(83, 229)
        Me._Label6_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label6_1.Name = "_Label6_1"
        Me._Label6_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label6_1.Size = New System.Drawing.Size(91, 17)
        Me._Label6_1.TabIndex = 18
        Me._Label6_1.Text = "Pulse period:"
        Me._Label6_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblPPer_1
        '
        Me._lblPPer_1.AutoSize = True
        Me._lblPPer_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPPer_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPPer.SetIndex(Me._lblPPer_1, CType(1, Short))
        Me._lblPPer_1.Location = New System.Drawing.Point(183, 229)
        Me._lblPPer_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblPPer_1.Name = "_lblPPer_1"
        Me._lblPPer_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPPer_1.Size = New System.Drawing.Size(35, 17)
        Me._lblPPer_1.TabIndex = 19
        Me._lblPPer_1.Text = "XXX"
        '
        '_lblCycPer_1
        '
        Me._lblCycPer_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCycPer_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCycPer.SetIndex(Me._lblCycPer_1, CType(1, Short))
        Me._lblCycPer_1.Location = New System.Drawing.Point(183, 254)
        Me._lblCycPer_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblCycPer_1.Name = "_lblCycPer_1"
        Me._lblCycPer_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCycPer_1.Size = New System.Drawing.Size(145, 16)
        Me._lblCycPer_1.TabIndex = 31
        Me._lblCycPer_1.Text = "XXX"
        '
        '_Label9_1
        '
        Me._Label9_1.AutoSize = True
        Me._Label9_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label9_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label9_1.Location = New System.Drawing.Point(95, 254)
        Me._Label9_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label9_1.Name = "_Label9_1"
        Me._Label9_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label9_1.Size = New System.Drawing.Size(78, 17)
        Me._Label9_1.TabIndex = 32
        Me._Label9_1.Text = "Time base:"
        Me._Label9_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Label6_5
        '
        Me._Label6_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label6_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label6_5.Location = New System.Drawing.Point(4, 283)
        Me._Label6_5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label6_5.Name = "_Label6_5"
        Me._Label6_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label6_5.Size = New System.Drawing.Size(147, 16)
        Me._Label6_5.TabIndex = 36
        Me._Label6_5.Text = "Channel information:"
        '
        '_txtMinDist_1
        '
        Me._txtMinDist_1.AcceptsReturn = True
        Me._txtMinDist_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtMinDist_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMinDist.SetIndex(Me._txtMinDist_1, CType(1, Short))
        Me._txtMinDist_1.Location = New System.Drawing.Point(183, 194)
        Me._txtMinDist_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._txtMinDist_1.MaxLength = 0
        Me._txtMinDist_1.Name = "_txtMinDist_1"
        Me._txtMinDist_1.ReadOnly = True
        Me._txtMinDist_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtMinDist_1.Size = New System.Drawing.Size(84, 22)
        Me._txtMinDist_1.TabIndex = 5
        '
        '_txtFittFile_1
        '
        Me._txtFittFile_1.AcceptsReturn = True
        Me._txtFittFile_1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._txtFittFile_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFittFile_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFittFile.SetIndex(Me._txtFittFile_1, CType(1, Short))
        Me._txtFittFile_1.Location = New System.Drawing.Point(183, 73)
        Me._txtFittFile_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._txtFittFile_1.MaxLength = 0
        Me._txtFittFile_1.Name = "_txtFittFile_1"
        Me._txtFittFile_1.ReadOnly = True
        Me._txtFittFile_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFittFile_1.Size = New System.Drawing.Size(321, 22)
        Me._txtFittFile_1.TabIndex = 7
        '
        '_txtFName_1
        '
        Me._txtFName_1.AcceptsReturn = True
        Me._txtFName_1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._txtFName_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFName_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFName.SetIndex(Me._txtFName_1, CType(1, Short))
        Me._txtFName_1.Location = New System.Drawing.Point(183, 108)
        Me._txtFName_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._txtFName_1.MaxLength = 0
        Me._txtFName_1.Name = "_txtFName_1"
        Me._txtFName_1.ReadOnly = True
        Me._txtFName_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFName_1.Size = New System.Drawing.Size(321, 22)
        Me._txtFName_1.TabIndex = 8
        Me._txtFName_1.Text = "XXX"
        '
        '_txtLName_1
        '
        Me._txtLName_1.AcceptsReturn = True
        Me._txtLName_1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._txtLName_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtLName_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLName.SetIndex(Me._txtLName_1, CType(1, Short))
        Me._txtLName_1.Location = New System.Drawing.Point(183, 138)
        Me._txtLName_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._txtLName_1.MaxLength = 0
        Me._txtLName_1.Name = "_txtLName_1"
        Me._txtLName_1.ReadOnly = True
        Me._txtLName_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtLName_1.Size = New System.Drawing.Size(321, 22)
        Me._txtLName_1.TabIndex = 9
        Me._txtLName_1.Text = "XXX"
        '
        '_cmdFittBrowse_1
        '
        Me._cmdFittBrowse_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._cmdFittBrowse_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdFittBrowse_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFittBrowse.SetIndex(Me._cmdFittBrowse_1, CType(1, Short))
        Me._cmdFittBrowse_1.Location = New System.Drawing.Point(513, 71)
        Me._cmdFittBrowse_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._cmdFittBrowse_1.Name = "_cmdFittBrowse_1"
        Me._cmdFittBrowse_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdFittBrowse_1.Size = New System.Drawing.Size(33, 26)
        Me._cmdFittBrowse_1.TabIndex = 28
        Me._cmdFittBrowse_1.Text = "..."
        Me._cmdFittBrowse_1.UseVisualStyleBackColor = False
        '
        '_lstChInfo_1
        '
        Me._lstChInfo_1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._lstChInfo_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lstChInfo_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstChInfo.SetIndex(Me._lstChInfo_1, CType(1, Short))
        Me._lstChInfo_1.ItemHeight = 16
        Me._lstChInfo_1.Location = New System.Drawing.Point(152, 283)
        Me._lstChInfo_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._lstChInfo_1.Name = "_lstChInfo_1"
        Me._lstChInfo_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lstChInfo_1.Size = New System.Drawing.Size(501, 228)
        Me._lstChInfo_1.TabIndex = 35
        '
        'tabDescription
        '
        Me.tabDescription.Controls.Add(Me.lblExpDescription)
        Me.tabDescription.Controls.Add(Me.lblExpID)
        Me.tabDescription.Controls.Add(Me.txtDescription)
        Me.tabDescription.Controls.Add(Me.txtID)
        Me.tabDescription.Location = New System.Drawing.Point(4, 40)
        Me.tabDescription.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabDescription.Name = "tabDescription"
        Me.tabDescription.Size = New System.Drawing.Size(688, 539)
        Me.tabDescription.TabIndex = 3
        Me.tabDescription.Text = "Description"
        Me.tabDescription.UseVisualStyleBackColor = True
        '
        'lblExpDescription
        '
        Me.lblExpDescription.AutoSize = True
        Me.lblExpDescription.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblExpDescription.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblExpDescription.Location = New System.Drawing.Point(65, 122)
        Me.lblExpDescription.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblExpDescription.Name = "lblExpDescription"
        Me.lblExpDescription.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblExpDescription.Size = New System.Drawing.Size(172, 17)
        Me.lblExpDescription.TabIndex = 37
        Me.lblExpDescription.Text = "Description of experiment:"
        '
        'lblExpID
        '
        Me.lblExpID.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblExpID.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblExpID.Location = New System.Drawing.Point(81, 63)
        Me.lblExpID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblExpID.Name = "lblExpID"
        Me.lblExpID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblExpID.Size = New System.Drawing.Size(137, 16)
        Me.lblExpID.TabIndex = 157
        Me.lblExpID.Text = "Experiment ID:"
        Me.lblExpID.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtDescription
        '
        Me.txtDescription.AcceptsReturn = True
        Me.txtDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDescription.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDescription.Location = New System.Drawing.Point(19, 156)
        Me.txtDescription.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDescription.MaxLength = 0
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDescription.Size = New System.Drawing.Size(632, 308)
        Me.txtDescription.TabIndex = 39
        '
        'tabExperimentScreen
        '
        Me.tabExperimentScreen.Controls.Add(Me.lblKeyCode)
        Me.tabExperimentScreen.Controls.Add(Me.Frame1)
        Me.tabExperimentScreen.Controls.Add(Me.Frame2)
        Me.tabExperimentScreen.Controls.Add(Me.Frame3)
        Me.tabExperimentScreen.Controls.Add(Me.cmbHUI)
        Me.tabExperimentScreen.Location = New System.Drawing.Point(4, 40)
        Me.tabExperimentScreen.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabExperimentScreen.Name = "tabExperimentScreen"
        Me.tabExperimentScreen.Size = New System.Drawing.Size(688, 539)
        Me.tabExperimentScreen.TabIndex = 4
        Me.tabExperimentScreen.Text = "Experiment Screen"
        Me.tabExperimentScreen.UseVisualStyleBackColor = True
        '
        'lblKeyCode
        '
        Me.lblKeyCode.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblKeyCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblKeyCode.Location = New System.Drawing.Point(31, 460)
        Me.lblKeyCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblKeyCode.Name = "lblKeyCode"
        Me.lblKeyCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblKeyCode.Size = New System.Drawing.Size(211, 16)
        Me.lblKeyCode.TabIndex = 293
        Me.lblKeyCode.Text = "Press any key to see the code"
        Me.lblKeyCode.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.cmdExpShowResponseCodes)
        Me.Frame1.Controls.Add(Me.cmdExpGetValue)
        Me.Frame1.Controls.Add(Me.txtExpValue)
        Me.Frame1.Controls.Add(Me.txtExpResponse)
        Me.Frame1.Controls.Add(Me.cmdExpGetResponse)
        Me.Frame1.Controls.Add(Me.cmdExpDisableResponse)
        Me.Frame1.Controls.Add(Me.cmdExpEnableResponse)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(11, 258)
        Me.Frame1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(247, 165)
        Me.Frame1.TabIndex = 44
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Response:"
        '
        'cmdExpShowResponseCodes
        '
        Me.cmdExpShowResponseCodes.Location = New System.Drawing.Point(7, 126)
        Me.cmdExpShowResponseCodes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdExpShowResponseCodes.Name = "cmdExpShowResponseCodes"
        Me.cmdExpShowResponseCodes.Size = New System.Drawing.Size(232, 32)
        Me.cmdExpShowResponseCodes.TabIndex = 163
        Me.cmdExpShowResponseCodes.Text = "Show Response Codes"
        Me.cmdExpShowResponseCodes.UseVisualStyleBackColor = True
        '
        'cmdExpGetValue
        '
        Me.cmdExpGetValue.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExpGetValue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExpGetValue.Location = New System.Drawing.Point(8, 95)
        Me.cmdExpGetValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdExpGetValue.Name = "cmdExpGetValue"
        Me.cmdExpGetValue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExpGetValue.Size = New System.Drawing.Size(113, 26)
        Me.cmdExpGetValue.TabIndex = 162
        Me.cmdExpGetValue.Text = "Get Value"
        Me.cmdExpGetValue.UseVisualStyleBackColor = False
        '
        'txtExpValue
        '
        Me.txtExpValue.AcceptsReturn = True
        Me.txtExpValue.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtExpValue.Enabled = False
        Me.txtExpValue.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtExpValue.Location = New System.Drawing.Point(143, 95)
        Me.txtExpValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtExpValue.MaxLength = 0
        Me.txtExpValue.Name = "txtExpValue"
        Me.txtExpValue.ReadOnly = True
        Me.txtExpValue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExpValue.Size = New System.Drawing.Size(64, 22)
        Me.txtExpValue.TabIndex = 161
        Me.txtExpValue.Text = "XXX"
        Me.txtExpValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtExpResponse
        '
        Me.txtExpResponse.AcceptsReturn = True
        Me.txtExpResponse.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtExpResponse.Enabled = False
        Me.txtExpResponse.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtExpResponse.Location = New System.Drawing.Point(143, 62)
        Me.txtExpResponse.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtExpResponse.MaxLength = 0
        Me.txtExpResponse.Name = "txtExpResponse"
        Me.txtExpResponse.ReadOnly = True
        Me.txtExpResponse.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExpResponse.Size = New System.Drawing.Size(64, 22)
        Me.txtExpResponse.TabIndex = 48
        Me.txtExpResponse.Text = "XXX"
        Me.txtExpResponse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdExpGetResponse
        '
        Me.cmdExpGetResponse.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExpGetResponse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExpGetResponse.Location = New System.Drawing.Point(8, 62)
        Me.cmdExpGetResponse.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdExpGetResponse.Name = "cmdExpGetResponse"
        Me.cmdExpGetResponse.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExpGetResponse.Size = New System.Drawing.Size(113, 26)
        Me.cmdExpGetResponse.TabIndex = 47
        Me.cmdExpGetResponse.Text = "Get Response"
        Me.cmdExpGetResponse.UseVisualStyleBackColor = False
        '
        'cmdExpDisableResponse
        '
        Me.cmdExpDisableResponse.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExpDisableResponse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExpDisableResponse.Location = New System.Drawing.Point(128, 28)
        Me.cmdExpDisableResponse.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdExpDisableResponse.Name = "cmdExpDisableResponse"
        Me.cmdExpDisableResponse.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExpDisableResponse.Size = New System.Drawing.Size(111, 26)
        Me.cmdExpDisableResponse.TabIndex = 46
        Me.cmdExpDisableResponse.Text = "Disable"
        Me.cmdExpDisableResponse.UseVisualStyleBackColor = False
        '
        'cmdExpEnableResponse
        '
        Me.cmdExpEnableResponse.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExpEnableResponse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExpEnableResponse.Location = New System.Drawing.Point(8, 28)
        Me.cmdExpEnableResponse.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdExpEnableResponse.Name = "cmdExpEnableResponse"
        Me.cmdExpEnableResponse.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExpEnableResponse.Size = New System.Drawing.Size(113, 26)
        Me.cmdExpEnableResponse.TabIndex = 45
        Me.cmdExpEnableResponse.Text = "Enable"
        Me.cmdExpEnableResponse.UseVisualStyleBackColor = False
        '
        'Frame2
        '
        Me.Frame2.Controls.Add(Me.cmdExpSetSmall)
        Me.Frame2.Controls.Add(Me.cmdExpSetDefault)
        Me.Frame2.Controls.Add(Me.cmdExpResize)
        Me.Frame2.Controls.Add(Me.txtExpLeft)
        Me.Frame2.Controls.Add(Me.txtExpWidth)
        Me.Frame2.Controls.Add(Me.txtExpTop)
        Me.Frame2.Controls.Add(Me.txtExpHeight)
        Me.Frame2.Controls.Add(Me.cmdExpGetSize)
        Me.Frame2.Controls.Add(Me.cmdExpSetSize)
        Me.Frame2.Controls.Add(Me._lblExp_0)
        Me.Frame2.Controls.Add(Me._lblExp_1)
        Me.Frame2.Controls.Add(Me._lblExp_2)
        Me.Frame2.Controls.Add(Me._lblExp_3)
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(11, 16)
        Me.Frame2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(247, 235)
        Me.Frame2.TabIndex = 49
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Screen arrangement:"
        '
        'cmdExpSetSmall
        '
        Me.cmdExpSetSmall.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExpSetSmall.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExpSetSmall.Location = New System.Drawing.Point(145, 149)
        Me.cmdExpSetSmall.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdExpSetSmall.Name = "cmdExpSetSmall"
        Me.cmdExpSetSmall.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExpSetSmall.Size = New System.Drawing.Size(89, 68)
        Me.cmdExpSetSmall.TabIndex = 58
        Me.cmdExpSetSmall.Text = "Small Debug Screen"
        Me.cmdExpSetSmall.UseVisualStyleBackColor = False
        '
        'cmdExpSetDefault
        '
        Me.cmdExpSetDefault.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExpSetDefault.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExpSetDefault.Location = New System.Drawing.Point(44, 149)
        Me.cmdExpSetDefault.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdExpSetDefault.Name = "cmdExpSetDefault"
        Me.cmdExpSetDefault.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExpSetDefault.Size = New System.Drawing.Size(89, 68)
        Me.cmdExpSetDefault.TabIndex = 57
        Me.cmdExpSetDefault.Text = "Primary Full Screen"
        Me.cmdExpSetDefault.UseVisualStyleBackColor = False
        '
        'cmdExpResize
        '
        Me.cmdExpResize.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExpResize.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExpResize.Location = New System.Drawing.Point(145, 37)
        Me.cmdExpResize.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdExpResize.Name = "cmdExpResize"
        Me.cmdExpResize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExpResize.Size = New System.Drawing.Size(89, 26)
        Me.cmdExpResize.TabIndex = 52
        Me.cmdExpResize.Text = "Arrange"
        Me.cmdExpResize.UseVisualStyleBackColor = False
        '
        'txtExpLeft
        '
        Me.txtExpLeft.AcceptsReturn = True
        Me.txtExpLeft.AutoCompleteCustomSource.AddRange(New String() {"0", "800", "1280", "1922"})
        Me.txtExpLeft.BackColor = System.Drawing.SystemColors.Window
        Me.txtExpLeft.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtExpLeft.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtExpLeft.Location = New System.Drawing.Point(73, 25)
        Me.txtExpLeft.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtExpLeft.MaxLength = 10
        Me.txtExpLeft.Name = "txtExpLeft"
        Me.txtExpLeft.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExpLeft.Size = New System.Drawing.Size(57, 22)
        Me.txtExpLeft.TabIndex = 40
        Me.txtExpLeft.Text = "XXX"
        Me.txtExpLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtExpWidth
        '
        Me.txtExpWidth.AcceptsReturn = True
        Me.txtExpWidth.BackColor = System.Drawing.SystemColors.Window
        Me.txtExpWidth.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtExpWidth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtExpWidth.Location = New System.Drawing.Point(75, 54)
        Me.txtExpWidth.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtExpWidth.MaxLength = 10
        Me.txtExpWidth.Name = "txtExpWidth"
        Me.txtExpWidth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExpWidth.Size = New System.Drawing.Size(57, 22)
        Me.txtExpWidth.TabIndex = 41
        Me.txtExpWidth.Text = "XXX"
        Me.txtExpWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtExpTop
        '
        Me.txtExpTop.AcceptsReturn = True
        Me.txtExpTop.BackColor = System.Drawing.SystemColors.Window
        Me.txtExpTop.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtExpTop.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtExpTop.Location = New System.Drawing.Point(75, 84)
        Me.txtExpTop.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtExpTop.MaxLength = 10
        Me.txtExpTop.Name = "txtExpTop"
        Me.txtExpTop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExpTop.Size = New System.Drawing.Size(57, 22)
        Me.txtExpTop.TabIndex = 42
        Me.txtExpTop.Text = "XXX"
        Me.txtExpTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtExpHeight
        '
        Me.txtExpHeight.AcceptsReturn = True
        Me.txtExpHeight.BackColor = System.Drawing.SystemColors.Window
        Me.txtExpHeight.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtExpHeight.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtExpHeight.Location = New System.Drawing.Point(75, 113)
        Me.txtExpHeight.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtExpHeight.MaxLength = 10
        Me.txtExpHeight.Name = "txtExpHeight"
        Me.txtExpHeight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExpHeight.Size = New System.Drawing.Size(57, 22)
        Me.txtExpHeight.TabIndex = 43
        Me.txtExpHeight.Text = "XXX"
        Me.txtExpHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdExpGetSize
        '
        Me.cmdExpGetSize.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExpGetSize.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExpGetSize.Location = New System.Drawing.Point(145, 68)
        Me.cmdExpGetSize.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdExpGetSize.Name = "cmdExpGetSize"
        Me.cmdExpGetSize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExpGetSize.Size = New System.Drawing.Size(89, 26)
        Me.cmdExpGetSize.TabIndex = 51
        Me.cmdExpGetSize.Text = "Get"
        Me.cmdExpGetSize.UseVisualStyleBackColor = False
        '
        'cmdExpSetSize
        '
        Me.cmdExpSetSize.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExpSetSize.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExpSetSize.Location = New System.Drawing.Point(145, 98)
        Me.cmdExpSetSize.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdExpSetSize.Name = "cmdExpSetSize"
        Me.cmdExpSetSize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExpSetSize.Size = New System.Drawing.Size(89, 26)
        Me.cmdExpSetSize.TabIndex = 50
        Me.cmdExpSetSize.Text = "Set"
        Me.cmdExpSetSize.UseVisualStyleBackColor = False
        '
        '_lblExp_0
        '
        Me._lblExp_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblExp_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblExp.SetIndex(Me._lblExp_0, CType(0, Short))
        Me._lblExp_0.Location = New System.Drawing.Point(28, 30)
        Me._lblExp_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblExp_0.Name = "_lblExp_0"
        Me._lblExp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblExp_0.Size = New System.Drawing.Size(37, 14)
        Me._lblExp_0.TabIndex = 56
        Me._lblExp_0.Text = "Left:"
        Me._lblExp_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblExp_1
        '
        Me._lblExp_1.AutoSize = True
        Me._lblExp_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblExp_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblExp.SetIndex(Me._lblExp_1, CType(1, Short))
        Me._lblExp_1.Location = New System.Drawing.Point(16, 59)
        Me._lblExp_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblExp_1.Name = "_lblExp_1"
        Me._lblExp_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblExp_1.Size = New System.Drawing.Size(48, 17)
        Me._lblExp_1.TabIndex = 55
        Me._lblExp_1.Text = "Width:"
        Me._lblExp_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblExp_2
        '
        Me._lblExp_2.AutoSize = True
        Me._lblExp_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblExp_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblExp.SetIndex(Me._lblExp_2, CType(2, Short))
        Me._lblExp_2.Location = New System.Drawing.Point(28, 89)
        Me._lblExp_2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblExp_2.Name = "_lblExp_2"
        Me._lblExp_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblExp_2.Size = New System.Drawing.Size(37, 17)
        Me._lblExp_2.TabIndex = 54
        Me._lblExp_2.Text = "Top:"
        Me._lblExp_2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblExp_3
        '
        Me._lblExp_3.AutoSize = True
        Me._lblExp_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblExp_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblExp.SetIndex(Me._lblExp_3, CType(3, Short))
        Me._lblExp_3.Location = New System.Drawing.Point(12, 118)
        Me._lblExp_3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblExp_3.Name = "_lblExp_3"
        Me._lblExp_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblExp_3.Size = New System.Drawing.Size(53, 17)
        Me._lblExp_3.TabIndex = 53
        Me._lblExp_3.Text = "Height:"
        Me._lblExp_3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Frame3
        '
        Me.Frame3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Frame3.Controls.Add(Me.OexpMode)
        Me.Frame3.Controls.Add(Me.lstExpFlags)
        Me.Frame3.Controls.Add(Me.chkAlwaysOnTop)
        Me.Frame3.Controls.Add(Me.cmdExpBlankScreen)
        Me.Frame3.Controls.Add(Me.cmdExpHide)
        Me.Frame3.Controls.Add(Me.cmdExpShow)
        Me.Frame3.Controls.Add(Me.cmdExpStartScreen)
        Me.Frame3.Controls.Add(Me.cmdExpStimScreen)
        Me.Frame3.Controls.Add(Me.cmdExpNextScreen)
        Me.Frame3.Controls.Add(Me.cmdExpEndScreen)
        Me.Frame3.Controls.Add(Me.chkOverrideExpMode)
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(265, 16)
        Me.Frame3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(403, 460)
        Me.Frame3.TabIndex = 57
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Screen control:"
        '
        'lstExpFlags
        '
        Me.lstExpFlags.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstExpFlags.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstExpFlags.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstExpFlags.IntegralHeight = False
        Me.lstExpFlags.Location = New System.Drawing.Point(11, 49)
        Me.lstExpFlags.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lstExpFlags.Name = "lstExpFlags"
        Me.lstExpFlags.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstExpFlags.Size = New System.Drawing.Size(380, 255)
        Me.lstExpFlags.TabIndex = 231
        '
        'chkAlwaysOnTop
        '
        Me.chkAlwaysOnTop.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkAlwaysOnTop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAlwaysOnTop.Location = New System.Drawing.Point(15, 25)
        Me.chkAlwaysOnTop.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkAlwaysOnTop.Name = "chkAlwaysOnTop"
        Me.chkAlwaysOnTop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkAlwaysOnTop.Size = New System.Drawing.Size(145, 25)
        Me.chkAlwaysOnTop.TabIndex = 84
        Me.chkAlwaysOnTop.Text = "Always on top"
        Me.chkAlwaysOnTop.UseVisualStyleBackColor = False
        '
        'cmdExpBlankScreen
        '
        Me.cmdExpBlankScreen.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExpBlankScreen.Enabled = False
        Me.cmdExpBlankScreen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExpBlankScreen.Location = New System.Drawing.Point(8, 363)
        Me.cmdExpBlankScreen.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdExpBlankScreen.Name = "cmdExpBlankScreen"
        Me.cmdExpBlankScreen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExpBlankScreen.Size = New System.Drawing.Size(120, 26)
        Me.cmdExpBlankScreen.TabIndex = 64
        Me.cmdExpBlankScreen.Text = "Blank"
        Me.cmdExpBlankScreen.UseVisualStyleBackColor = False
        '
        'cmdExpHide
        '
        Me.cmdExpHide.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExpHide.Enabled = False
        Me.cmdExpHide.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExpHide.Location = New System.Drawing.Point(259, 363)
        Me.cmdExpHide.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdExpHide.Name = "cmdExpHide"
        Me.cmdExpHide.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExpHide.Size = New System.Drawing.Size(120, 26)
        Me.cmdExpHide.TabIndex = 63
        Me.cmdExpHide.Text = "Hide"
        Me.cmdExpHide.UseVisualStyleBackColor = False
        '
        'cmdExpShow
        '
        Me.cmdExpShow.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExpShow.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExpShow.Location = New System.Drawing.Point(8, 314)
        Me.cmdExpShow.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdExpShow.Name = "cmdExpShow"
        Me.cmdExpShow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExpShow.Size = New System.Drawing.Size(252, 41)
        Me.cmdExpShow.TabIndex = 62
        Me.cmdExpShow.Text = "Init && Show"
        Me.cmdExpShow.UseVisualStyleBackColor = False
        '
        'cmdExpStartScreen
        '
        Me.cmdExpStartScreen.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExpStartScreen.Enabled = False
        Me.cmdExpStartScreen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExpStartScreen.Location = New System.Drawing.Point(133, 363)
        Me.cmdExpStartScreen.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdExpStartScreen.Name = "cmdExpStartScreen"
        Me.cmdExpStartScreen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExpStartScreen.Size = New System.Drawing.Size(120, 26)
        Me.cmdExpStartScreen.TabIndex = 61
        Me.cmdExpStartScreen.Text = "Start"
        Me.cmdExpStartScreen.UseVisualStyleBackColor = False
        '
        'cmdExpStimScreen
        '
        Me.cmdExpStimScreen.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExpStimScreen.Enabled = False
        Me.cmdExpStimScreen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExpStimScreen.Location = New System.Drawing.Point(8, 393)
        Me.cmdExpStimScreen.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdExpStimScreen.Name = "cmdExpStimScreen"
        Me.cmdExpStimScreen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExpStimScreen.Size = New System.Drawing.Size(120, 26)
        Me.cmdExpStimScreen.TabIndex = 60
        Me.cmdExpStimScreen.Text = "Stimulation"
        Me.cmdExpStimScreen.UseVisualStyleBackColor = False
        '
        'cmdExpNextScreen
        '
        Me.cmdExpNextScreen.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExpNextScreen.Enabled = False
        Me.cmdExpNextScreen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExpNextScreen.Location = New System.Drawing.Point(133, 393)
        Me.cmdExpNextScreen.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdExpNextScreen.Name = "cmdExpNextScreen"
        Me.cmdExpNextScreen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExpNextScreen.Size = New System.Drawing.Size(120, 26)
        Me.cmdExpNextScreen.TabIndex = 59
        Me.cmdExpNextScreen.Text = "Next/Feedback"
        Me.cmdExpNextScreen.UseVisualStyleBackColor = False
        '
        'cmdExpEndScreen
        '
        Me.cmdExpEndScreen.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExpEndScreen.Enabled = False
        Me.cmdExpEndScreen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExpEndScreen.Location = New System.Drawing.Point(259, 393)
        Me.cmdExpEndScreen.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdExpEndScreen.Name = "cmdExpEndScreen"
        Me.cmdExpEndScreen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExpEndScreen.Size = New System.Drawing.Size(120, 26)
        Me.cmdExpEndScreen.TabIndex = 58
        Me.cmdExpEndScreen.Text = "End"
        Me.cmdExpEndScreen.UseVisualStyleBackColor = False
        '
        'cmbHUI
        '
        Me.cmbHUI.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbHUI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHUI.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbHUI.Location = New System.Drawing.Point(11, 431)
        Me.cmbHUI.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbHUI.Name = "cmbHUI"
        Me.cmbHUI.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbHUI.Size = New System.Drawing.Size(245, 24)
        Me.cmbHUI.TabIndex = 163
        '
        'tabChannels
        '
        Me.tabChannels.Controls.Add(Me.cmdElDelL)
        Me.tabChannels.Controls.Add(Me.fraSignalR)
        Me.tabChannels.Controls.Add(Me.cmdElDelR)
        Me.tabChannels.Controls.Add(Me.cmdElAddR)
        Me.tabChannels.Controls.Add(Me.cmdElAddL)
        Me.tabChannels.Controls.Add(Me.lblSignal)
        Me.tabChannels.Controls.Add(Me.cmbElL)
        Me.tabChannels.Controls.Add(Me.cmbElR)
        Me.tabChannels.Controls.Add(Me.cmdSignalImport)
        Me.tabChannels.Controls.Add(Me.fraSignalL)
        Me.tabChannels.Controls.Add(Me.fraElectricalL)
        Me.tabChannels.Controls.Add(Me.fraElectricalR)
        Me.tabChannels.Controls.Add(Me.fraAcousticL)
        Me.tabChannels.Controls.Add(Me.fraAcousticR)
        Me.tabChannels.Location = New System.Drawing.Point(4, 40)
        Me.tabChannels.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabChannels.Name = "tabChannels"
        Me.tabChannels.Size = New System.Drawing.Size(688, 539)
        Me.tabChannels.TabIndex = 5
        Me.tabChannels.Text = "Signal"
        Me.tabChannels.UseVisualStyleBackColor = True
        '
        'cmdElDelL
        '
        Me.cmdElDelL.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdElDelL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdElDelL.Location = New System.Drawing.Point(289, 41)
        Me.cmdElDelL.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdElDelL.Name = "cmdElDelL"
        Me.cmdElDelL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdElDelL.Size = New System.Drawing.Size(19, 23)
        Me.cmdElDelL.TabIndex = 203
        Me.cmdElDelL.Text = "-"
        Me.cmdElDelL.UseVisualStyleBackColor = False
        '
        'fraSignalR
        '
        Me.fraSignalR.Controls.Add(Me.txtPhDurR)
        Me.fraSignalR.Controls.Add(Me.lblPhDurR)
        Me.fraSignalR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraSignalR.Location = New System.Drawing.Point(360, 321)
        Me.fraSignalR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraSignalR.Name = "fraSignalR"
        Me.fraSignalR.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraSignalR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraSignalR.Size = New System.Drawing.Size(227, 95)
        Me.fraSignalR.TabIndex = 200
        Me.fraSignalR.TabStop = False
        '
        'txtPhDurR
        '
        Me.txtPhDurR.AcceptsReturn = True
        Me.txtPhDurR.BackColor = System.Drawing.SystemColors.Window
        Me.txtPhDurR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPhDurR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPhDurR.Location = New System.Drawing.Point(21, 20)
        Me.txtPhDurR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPhDurR.MaxLength = 10
        Me.txtPhDurR.Name = "txtPhDurR"
        Me.txtPhDurR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPhDurR.Size = New System.Drawing.Size(69, 22)
        Me.txtPhDurR.TabIndex = 110
        '
        'lblPhDurR
        '
        Me.lblPhDurR.AutoSize = True
        Me.lblPhDurR.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPhDurR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPhDurR.Location = New System.Drawing.Point(43, 49)
        Me.lblPhDurR.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPhDurR.Name = "lblPhDurR"
        Me.lblPhDurR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPhDurR.Size = New System.Drawing.Size(30, 17)
        Me.lblPhDurR.TabIndex = 201
        Me.lblPhDurR.Text = "- / -"
        Me.lblPhDurR.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdElDelR
        '
        Me.cmdElDelR.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdElDelR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdElDelR.Location = New System.Drawing.Point(421, 41)
        Me.cmdElDelR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdElDelR.Name = "cmdElDelR"
        Me.cmdElDelR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdElDelR.Size = New System.Drawing.Size(19, 23)
        Me.cmdElDelR.TabIndex = 204
        Me.cmdElDelR.Text = "-"
        Me.cmdElDelR.UseVisualStyleBackColor = False
        '
        'cmdElAddR
        '
        Me.cmdElAddR.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdElAddR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdElAddR.Location = New System.Drawing.Point(421, 14)
        Me.cmdElAddR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdElAddR.Name = "cmdElAddR"
        Me.cmdElAddR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdElAddR.Size = New System.Drawing.Size(19, 23)
        Me.cmdElAddR.TabIndex = 205
        Me.cmdElAddR.Text = "+"
        Me.cmdElAddR.UseVisualStyleBackColor = False
        '
        'cmdElAddL
        '
        Me.cmdElAddL.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdElAddL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdElAddL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdElAddL.Location = New System.Drawing.Point(289, 14)
        Me.cmdElAddL.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdElAddL.Name = "cmdElAddL"
        Me.cmdElAddL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdElAddL.Size = New System.Drawing.Size(19, 23)
        Me.cmdElAddL.TabIndex = 202
        Me.cmdElAddL.Text = "+"
        Me.cmdElAddL.UseVisualStyleBackColor = False
        '
        'lblSignal
        '
        Me.lblSignal.AutoSize = True
        Me.lblSignal.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSignal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSignal.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblSignal.Location = New System.Drawing.Point(21, 27)
        Me.lblSignal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSignal.Name = "lblSignal"
        Me.lblSignal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSignal.Size = New System.Drawing.Size(198, 25)
        Me.lblSignal.TabIndex = 142
        Me.lblSignal.Text = "Electrode/Channel:"
        Me.lblSignal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbElL
        '
        Me.cmbElL.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbElL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbElL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbElL.Location = New System.Drawing.Point(240, 27)
        Me.cmbElL.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbElL.Name = "cmbElL"
        Me.cmbElL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbElL.Size = New System.Drawing.Size(48, 24)
        Me.cmbElL.TabIndex = 130
        '
        'cmbElR
        '
        Me.cmbElR.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbElR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbElR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbElR.Location = New System.Drawing.Point(372, 27)
        Me.cmbElR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbElR.Name = "cmbElR"
        Me.cmbElR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbElR.Size = New System.Drawing.Size(48, 24)
        Me.cmbElR.TabIndex = 143
        '
        'fraSignalL
        '
        Me.fraSignalL.Controls.Add(Me.txtPhDurL)
        Me.fraSignalL.Controls.Add(Me.lblPhDur)
        Me.fraSignalL.Controls.Add(Me.lblPhDurQuantized)
        Me.fraSignalL.Controls.Add(Me.lblPhDurL)
        Me.fraSignalL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraSignalL.Location = New System.Drawing.Point(29, 321)
        Me.fraSignalL.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraSignalL.Name = "fraSignalL"
        Me.fraSignalL.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraSignalL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraSignalL.Size = New System.Drawing.Size(320, 95)
        Me.fraSignalL.TabIndex = 196
        Me.fraSignalL.TabStop = False
        '
        'txtPhDurL
        '
        Me.txtPhDurL.AcceptsReturn = True
        Me.txtPhDurL.BackColor = System.Drawing.SystemColors.Window
        Me.txtPhDurL.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPhDurL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPhDurL.Location = New System.Drawing.Point(225, 20)
        Me.txtPhDurL.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPhDurL.MaxLength = 10
        Me.txtPhDurL.Name = "txtPhDurL"
        Me.txtPhDurL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPhDurL.Size = New System.Drawing.Size(69, 22)
        Me.txtPhDurL.TabIndex = 103
        '
        'lblPhDur
        '
        Me.lblPhDur.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPhDur.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPhDur.Location = New System.Drawing.Point(8, 25)
        Me.lblPhDur.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPhDur.Name = "lblPhDur"
        Me.lblPhDur.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPhDur.Size = New System.Drawing.Size(211, 16)
        Me.lblPhDur.TabIndex = 199
        Me.lblPhDur.Text = "Phase duration: [us]:"
        Me.lblPhDur.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblPhDurQuantized
        '
        Me.lblPhDurQuantized.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPhDurQuantized.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPhDurQuantized.Location = New System.Drawing.Point(67, 49)
        Me.lblPhDurQuantized.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPhDurQuantized.Name = "lblPhDurQuantized"
        Me.lblPhDurQuantized.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPhDurQuantized.Size = New System.Drawing.Size(152, 36)
        Me.lblPhDurQuantized.TabIndex = 198
        Me.lblPhDurQuantized.Text = "Quantized: [samples]: [us]: "
        Me.lblPhDurQuantized.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblPhDurL
        '
        Me.lblPhDurL.AutoSize = True
        Me.lblPhDurL.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPhDurL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPhDurL.Location = New System.Drawing.Point(243, 49)
        Me.lblPhDurL.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPhDurL.Name = "lblPhDurL"
        Me.lblPhDurL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPhDurL.Size = New System.Drawing.Size(30, 17)
        Me.lblPhDurL.TabIndex = 197
        Me.lblPhDurL.Text = "- / -"
        Me.lblPhDurL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraElectricalL
        '
        Me.fraElectricalL.Controls.Add(Me.sldL)
        Me.fraElectricalL.Controls.Add(Me.cmbRangeL)
        Me.fraElectricalL.Controls.Add(Me.Label17)
        Me.fraElectricalL.Controls.Add(Me._Label3_2)
        Me.fraElectricalL.Controls.Add(Me.Label16)
        Me.fraElectricalL.Controls.Add(Me.Label7)
        Me.fraElectricalL.Controls.Add(Me.Label1)
        Me.fraElectricalL.Controls.Add(Me.lblMCLL)
        Me.fraElectricalL.Controls.Add(Me.lblTHRL)
        Me.fraElectricalL.Controls.Add(Me.lblDynamicL)
        Me.fraElectricalL.Controls.Add(Me.lblLevelL)
        Me.fraElectricalL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraElectricalL.Location = New System.Drawing.Point(29, 57)
        Me.fraElectricalL.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraElectricalL.Name = "fraElectricalL"
        Me.fraElectricalL.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraElectricalL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraElectricalL.Size = New System.Drawing.Size(320, 257)
        Me.fraElectricalL.TabIndex = 65
        Me.fraElectricalL.TabStop = False
        Me.fraElectricalL.Text = "Left:"
        '
        'sldL
        '
        Me.sldL.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.sldL.Location = New System.Drawing.Point(245, 25)
        Me.sldL.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.sldL.Maximum = 127
        Me.sldL.Name = "sldL"
        Me.sldL.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.sldL.Size = New System.Drawing.Size(56, 193)
        Me.sldL.TabIndex = 84
        Me.sldL.TickFrequency = 10
        Me.sldL.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        Me.sldL.Value = 8
        '
        'cmbRangeL
        '
        Me.cmbRangeL.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbRangeL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRangeL.Enabled = False
        Me.cmbRangeL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbRangeL.Location = New System.Drawing.Point(245, 222)
        Me.cmbRangeL.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbRangeL.Name = "cmbRangeL"
        Me.cmbRangeL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbRangeL.Size = New System.Drawing.Size(48, 24)
        Me.cmbRangeL.TabIndex = 66
        '
        'Label17
        '
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(56, 162)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(49, 25)
        Me.Label17.TabIndex = 83
        Me.Label17.Text = "THR"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Label3_2
        '
        Me._Label3_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label3_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label3_2.Location = New System.Drawing.Point(24, 126)
        Me._Label3_2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label3_2.Name = "_Label3_2"
        Me._Label3_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label3_2.Size = New System.Drawing.Size(81, 20)
        Me._Label3_2.TabIndex = 82
        Me._Label3_2.Text = "Dyn. range"
        Me._Label3_2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label16
        '
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label16.Location = New System.Drawing.Point(143, 219)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(92, 25)
        Me.Label16.TabIndex = 81
        Me.Label16.Text = "Range:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label7.Location = New System.Drawing.Point(43, 89)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(60, 30)
        Me.Label7.TabIndex = 80
        Me.Label7.Text = "Amp"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(56, 44)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(49, 25)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "MCL"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMCLL
        '
        Me.lblMCLL.BackColor = System.Drawing.SystemColors.Control
        Me.lblMCLL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMCLL.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMCLL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMCLL.Location = New System.Drawing.Point(109, 39)
        Me.lblMCLL.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMCLL.Name = "lblMCLL"
        Me.lblMCLL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMCLL.Size = New System.Drawing.Size(112, 36)
        Me.lblMCLL.TabIndex = 78
        Me.lblMCLL.Text = "XXX"
        Me.lblMCLL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTHRL
        '
        Me.lblTHRL.BackColor = System.Drawing.SystemColors.Control
        Me.lblTHRL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTHRL.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTHRL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTHRL.Location = New System.Drawing.Point(109, 158)
        Me.lblTHRL.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTHRL.Name = "lblTHRL"
        Me.lblTHRL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTHRL.Size = New System.Drawing.Size(112, 36)
        Me.lblTHRL.TabIndex = 77
        Me.lblTHRL.Text = "XXX"
        Me.lblTHRL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblDynamicL
        '
        Me.lblDynamicL.BackColor = System.Drawing.SystemColors.Control
        Me.lblDynamicL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDynamicL.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDynamicL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDynamicL.Location = New System.Drawing.Point(109, 123)
        Me.lblDynamicL.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDynamicL.Name = "lblDynamicL"
        Me.lblDynamicL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDynamicL.Size = New System.Drawing.Size(112, 26)
        Me.lblDynamicL.TabIndex = 76
        Me.lblDynamicL.Text = "XXX"
        Me.lblDynamicL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLevelL
        '
        Me.lblLevelL.BackColor = System.Drawing.SystemColors.Control
        Me.lblLevelL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLevelL.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLevelL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLevelL.Location = New System.Drawing.Point(109, 84)
        Me.lblLevelL.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLevelL.Name = "lblLevelL"
        Me.lblLevelL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLevelL.Size = New System.Drawing.Size(112, 36)
        Me.lblLevelL.TabIndex = 72
        Me.lblLevelL.Text = "XXX"
        Me.lblLevelL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraElectricalR
        '
        Me.fraElectricalR.Controls.Add(Me.sldR)
        Me.fraElectricalR.Controls.Add(Me.cmbRangeR)
        Me.fraElectricalR.Controls.Add(Me.lblDynamicR)
        Me.fraElectricalR.Controls.Add(Me.lblTHRR)
        Me.fraElectricalR.Controls.Add(Me.lblMCLR)
        Me.fraElectricalR.Controls.Add(Me.lblLevelR)
        Me.fraElectricalR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraElectricalR.Location = New System.Drawing.Point(360, 57)
        Me.fraElectricalR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraElectricalR.Name = "fraElectricalR"
        Me.fraElectricalR.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraElectricalR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraElectricalR.Size = New System.Drawing.Size(227, 257)
        Me.fraElectricalR.TabIndex = 68
        Me.fraElectricalR.TabStop = False
        Me.fraElectricalR.Text = "Right:"
        '
        'sldR
        '
        Me.sldR.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.sldR.Location = New System.Drawing.Point(21, 25)
        Me.sldR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.sldR.Maximum = 127
        Me.sldR.Name = "sldR"
        Me.sldR.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.sldR.Size = New System.Drawing.Size(56, 193)
        Me.sldR.TabIndex = 76
        Me.sldR.TickFrequency = 8
        Me.sldR.Value = 8
        '
        'cmbRangeR
        '
        Me.cmbRangeR.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbRangeR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRangeR.Enabled = False
        Me.cmbRangeR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbRangeR.Location = New System.Drawing.Point(21, 222)
        Me.cmbRangeR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbRangeR.Name = "cmbRangeR"
        Me.cmbRangeR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbRangeR.Size = New System.Drawing.Size(48, 24)
        Me.cmbRangeR.TabIndex = 69
        '
        'lblDynamicR
        '
        Me.lblDynamicR.BackColor = System.Drawing.SystemColors.Control
        Me.lblDynamicR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDynamicR.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDynamicR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDynamicR.Location = New System.Drawing.Point(81, 123)
        Me.lblDynamicR.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDynamicR.Name = "lblDynamicR"
        Me.lblDynamicR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDynamicR.Size = New System.Drawing.Size(112, 26)
        Me.lblDynamicR.TabIndex = 75
        Me.lblDynamicR.Text = "XXX"
        Me.lblDynamicR.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTHRR
        '
        Me.lblTHRR.BackColor = System.Drawing.SystemColors.Control
        Me.lblTHRR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTHRR.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTHRR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTHRR.Location = New System.Drawing.Point(81, 158)
        Me.lblTHRR.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTHRR.Name = "lblTHRR"
        Me.lblTHRR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTHRR.Size = New System.Drawing.Size(112, 36)
        Me.lblTHRR.TabIndex = 74
        Me.lblTHRR.Text = "XXX"
        Me.lblTHRR.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMCLR
        '
        Me.lblMCLR.BackColor = System.Drawing.SystemColors.Control
        Me.lblMCLR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMCLR.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMCLR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMCLR.Location = New System.Drawing.Point(81, 39)
        Me.lblMCLR.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMCLR.Name = "lblMCLR"
        Me.lblMCLR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMCLR.Size = New System.Drawing.Size(112, 36)
        Me.lblMCLR.TabIndex = 73
        Me.lblMCLR.Text = "XXX"
        Me.lblMCLR.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLevelR
        '
        Me.lblLevelR.BackColor = System.Drawing.SystemColors.Control
        Me.lblLevelR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLevelR.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLevelR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLevelR.Location = New System.Drawing.Point(81, 84)
        Me.lblLevelR.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLevelR.Name = "lblLevelR"
        Me.lblLevelR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLevelR.Size = New System.Drawing.Size(112, 36)
        Me.lblLevelR.TabIndex = 71
        Me.lblLevelR.Text = "XXX"
        Me.lblLevelR.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraAcousticL
        '
        Me.fraAcousticL.Controls.Add(Me.txtMCLL)
        Me.fraAcousticL.Controls.Add(Me.txtTHRL)
        Me.fraAcousticL.Controls.Add(Me.txtAmpL)
        Me.fraAcousticL.Controls.Add(Me.txtSPLOffsetL)
        Me.fraAcousticL.Controls.Add(Me.txtCenterFreqL)
        Me.fraAcousticL.Controls.Add(Me.txtBandwidthL)
        Me.fraAcousticL.Controls.Add(Me.lblMCL)
        Me.fraAcousticL.Controls.Add(Me.lblTHR)
        Me.fraAcousticL.Controls.Add(Me.lblAmp)
        Me.fraAcousticL.Controls.Add(Me.lblSPLOffset)
        Me.fraAcousticL.Controls.Add(Me.lblCenterFreq)
        Me.fraAcousticL.Controls.Add(Me.lblBandwidth)
        Me.fraAcousticL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraAcousticL.Location = New System.Drawing.Point(11, 116)
        Me.fraAcousticL.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraAcousticL.Name = "fraAcousticL"
        Me.fraAcousticL.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraAcousticL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraAcousticL.Size = New System.Drawing.Size(320, 257)
        Me.fraAcousticL.TabIndex = 145
        Me.fraAcousticL.TabStop = False
        Me.fraAcousticL.Text = "Left:"
        '
        'txtMCLL
        '
        Me.txtMCLL.AcceptsReturn = True
        Me.txtMCLL.BackColor = System.Drawing.SystemColors.Window
        Me.txtMCLL.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMCLL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMCLL.Location = New System.Drawing.Point(225, 207)
        Me.txtMCLL.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtMCLL.MaxLength = 10
        Me.txtMCLL.Name = "txtMCLL"
        Me.txtMCLL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMCLL.Size = New System.Drawing.Size(69, 22)
        Me.txtMCLL.TabIndex = 102
        '
        'txtTHRL
        '
        Me.txtTHRL.AcceptsReturn = True
        Me.txtTHRL.BackColor = System.Drawing.SystemColors.Window
        Me.txtTHRL.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTHRL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTHRL.Location = New System.Drawing.Point(225, 177)
        Me.txtTHRL.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTHRL.MaxLength = 10
        Me.txtTHRL.Name = "txtTHRL"
        Me.txtTHRL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTHRL.Size = New System.Drawing.Size(69, 22)
        Me.txtTHRL.TabIndex = 101
        '
        'txtAmpL
        '
        Me.txtAmpL.AcceptsReturn = True
        Me.txtAmpL.BackColor = System.Drawing.SystemColors.Window
        Me.txtAmpL.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAmpL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAmpL.Location = New System.Drawing.Point(225, 59)
        Me.txtAmpL.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAmpL.MaxLength = 10
        Me.txtAmpL.Name = "txtAmpL"
        Me.txtAmpL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAmpL.Size = New System.Drawing.Size(69, 22)
        Me.txtAmpL.TabIndex = 97
        '
        'txtSPLOffsetL
        '
        Me.txtSPLOffsetL.AcceptsReturn = True
        Me.txtSPLOffsetL.BackColor = System.Drawing.SystemColors.Window
        Me.txtSPLOffsetL.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSPLOffsetL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSPLOffsetL.Location = New System.Drawing.Point(225, 89)
        Me.txtSPLOffsetL.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSPLOffsetL.MaxLength = 10
        Me.txtSPLOffsetL.Name = "txtSPLOffsetL"
        Me.txtSPLOffsetL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSPLOffsetL.Size = New System.Drawing.Size(69, 22)
        Me.txtSPLOffsetL.TabIndex = 98
        '
        'txtCenterFreqL
        '
        Me.txtCenterFreqL.AcceptsReturn = True
        Me.txtCenterFreqL.BackColor = System.Drawing.SystemColors.Window
        Me.txtCenterFreqL.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCenterFreqL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCenterFreqL.Location = New System.Drawing.Point(225, 118)
        Me.txtCenterFreqL.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCenterFreqL.MaxLength = 10
        Me.txtCenterFreqL.Name = "txtCenterFreqL"
        Me.txtCenterFreqL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCenterFreqL.Size = New System.Drawing.Size(69, 22)
        Me.txtCenterFreqL.TabIndex = 99
        '
        'txtBandwidthL
        '
        Me.txtBandwidthL.AcceptsReturn = True
        Me.txtBandwidthL.BackColor = System.Drawing.SystemColors.Window
        Me.txtBandwidthL.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBandwidthL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBandwidthL.Location = New System.Drawing.Point(225, 148)
        Me.txtBandwidthL.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBandwidthL.MaxLength = 10
        Me.txtBandwidthL.Name = "txtBandwidthL"
        Me.txtBandwidthL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBandwidthL.Size = New System.Drawing.Size(69, 22)
        Me.txtBandwidthL.TabIndex = 100
        '
        'lblMCL
        '
        Me.lblMCL.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMCL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMCL.Location = New System.Drawing.Point(8, 212)
        Me.lblMCL.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMCL.Name = "lblMCL"
        Me.lblMCL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMCL.Size = New System.Drawing.Size(211, 16)
        Me.lblMCL.TabIndex = 160
        Me.lblMCL.Text = "MCL [dB]:"
        Me.lblMCL.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTHR
        '
        Me.lblTHR.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTHR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTHR.Location = New System.Drawing.Point(8, 182)
        Me.lblTHR.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTHR.Name = "lblTHR"
        Me.lblTHR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTHR.Size = New System.Drawing.Size(211, 16)
        Me.lblTHR.TabIndex = 159
        Me.lblTHR.Text = "THR [dB]:"
        Me.lblTHR.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblAmp
        '
        Me.lblAmp.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAmp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAmp.Location = New System.Drawing.Point(8, 64)
        Me.lblAmp.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAmp.Name = "lblAmp"
        Me.lblAmp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAmp.Size = New System.Drawing.Size(211, 16)
        Me.lblAmp.TabIndex = 155
        Me.lblAmp.Text = "Amplitude [dB FS]:"
        Me.lblAmp.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSPLOffset
        '
        Me.lblSPLOffset.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSPLOffset.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSPLOffset.Location = New System.Drawing.Point(8, 94)
        Me.lblSPLOffset.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSPLOffset.Name = "lblSPLOffset"
        Me.lblSPLOffset.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSPLOffset.Size = New System.Drawing.Size(211, 16)
        Me.lblSPLOffset.TabIndex = 152
        Me.lblSPLOffset.Text = "FS to SPL offset [dB]:"
        Me.lblSPLOffset.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblCenterFreq
        '
        Me.lblCenterFreq.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCenterFreq.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCenterFreq.Location = New System.Drawing.Point(8, 123)
        Me.lblCenterFreq.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCenterFreq.Name = "lblCenterFreq"
        Me.lblCenterFreq.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCenterFreq.Size = New System.Drawing.Size(211, 16)
        Me.lblCenterFreq.TabIndex = 150
        Me.lblCenterFreq.Text = "Center frequency [Hz]:"
        Me.lblCenterFreq.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblBandwidth
        '
        Me.lblBandwidth.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblBandwidth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBandwidth.Location = New System.Drawing.Point(8, 153)
        Me.lblBandwidth.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBandwidth.Name = "lblBandwidth"
        Me.lblBandwidth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBandwidth.Size = New System.Drawing.Size(211, 16)
        Me.lblBandwidth.TabIndex = 148
        Me.lblBandwidth.Text = "Bandwidth [Hz]:"
        Me.lblBandwidth.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'fraAcousticR
        '
        Me.fraAcousticR.Controls.Add(Me.txtMCLR)
        Me.fraAcousticR.Controls.Add(Me.txtTHRR)
        Me.fraAcousticR.Controls.Add(Me.txtAmpR)
        Me.fraAcousticR.Controls.Add(Me.txtSPLOffsetR)
        Me.fraAcousticR.Controls.Add(Me.txtCenterFreqR)
        Me.fraAcousticR.Controls.Add(Me.txtBandwidthR)
        Me.fraAcousticR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraAcousticR.Location = New System.Drawing.Point(360, 57)
        Me.fraAcousticR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraAcousticR.Name = "fraAcousticR"
        Me.fraAcousticR.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraAcousticR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraAcousticR.Size = New System.Drawing.Size(227, 257)
        Me.fraAcousticR.TabIndex = 144
        Me.fraAcousticR.TabStop = False
        Me.fraAcousticR.Text = "Right:"
        '
        'txtMCLR
        '
        Me.txtMCLR.AcceptsReturn = True
        Me.txtMCLR.BackColor = System.Drawing.SystemColors.Window
        Me.txtMCLR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMCLR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMCLR.Location = New System.Drawing.Point(21, 207)
        Me.txtMCLR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtMCLR.MaxLength = 10
        Me.txtMCLR.Name = "txtMCLR"
        Me.txtMCLR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMCLR.Size = New System.Drawing.Size(69, 22)
        Me.txtMCLR.TabIndex = 109
        '
        'txtTHRR
        '
        Me.txtTHRR.AcceptsReturn = True
        Me.txtTHRR.BackColor = System.Drawing.SystemColors.Window
        Me.txtTHRR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTHRR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTHRR.Location = New System.Drawing.Point(21, 177)
        Me.txtTHRR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTHRR.MaxLength = 10
        Me.txtTHRR.Name = "txtTHRR"
        Me.txtTHRR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTHRR.Size = New System.Drawing.Size(69, 22)
        Me.txtTHRR.TabIndex = 108
        '
        'txtAmpR
        '
        Me.txtAmpR.AcceptsReturn = True
        Me.txtAmpR.BackColor = System.Drawing.SystemColors.Window
        Me.txtAmpR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAmpR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAmpR.Location = New System.Drawing.Point(21, 59)
        Me.txtAmpR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAmpR.MaxLength = 10
        Me.txtAmpR.Name = "txtAmpR"
        Me.txtAmpR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAmpR.Size = New System.Drawing.Size(69, 22)
        Me.txtAmpR.TabIndex = 104
        '
        'txtSPLOffsetR
        '
        Me.txtSPLOffsetR.AcceptsReturn = True
        Me.txtSPLOffsetR.BackColor = System.Drawing.SystemColors.Window
        Me.txtSPLOffsetR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSPLOffsetR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSPLOffsetR.Location = New System.Drawing.Point(21, 89)
        Me.txtSPLOffsetR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSPLOffsetR.MaxLength = 10
        Me.txtSPLOffsetR.Name = "txtSPLOffsetR"
        Me.txtSPLOffsetR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSPLOffsetR.Size = New System.Drawing.Size(69, 22)
        Me.txtSPLOffsetR.TabIndex = 105
        '
        'txtCenterFreqR
        '
        Me.txtCenterFreqR.AcceptsReturn = True
        Me.txtCenterFreqR.BackColor = System.Drawing.SystemColors.Window
        Me.txtCenterFreqR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCenterFreqR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCenterFreqR.Location = New System.Drawing.Point(21, 118)
        Me.txtCenterFreqR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCenterFreqR.MaxLength = 10
        Me.txtCenterFreqR.Name = "txtCenterFreqR"
        Me.txtCenterFreqR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCenterFreqR.Size = New System.Drawing.Size(69, 22)
        Me.txtCenterFreqR.TabIndex = 106
        '
        'txtBandwidthR
        '
        Me.txtBandwidthR.AcceptsReturn = True
        Me.txtBandwidthR.BackColor = System.Drawing.SystemColors.Window
        Me.txtBandwidthR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBandwidthR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBandwidthR.Location = New System.Drawing.Point(21, 148)
        Me.txtBandwidthR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBandwidthR.MaxLength = 10
        Me.txtBandwidthR.Name = "txtBandwidthR"
        Me.txtBandwidthR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBandwidthR.Size = New System.Drawing.Size(69, 22)
        Me.txtBandwidthR.TabIndex = 107
        '
        'tabAudio
        '
        Me.tabAudio.Controls.Add(Me.ckbUseTriggerChannel)
        Me.tabAudio.Controls.Add(Me.ckbUseDataChannel)
        Me.tabAudio.Controls.Add(Me._fraAudioDither_1)
        Me.tabAudio.Controls.Add(Me._fraAudioDither_0)
        Me.tabAudio.Controls.Add(Me.txtFadeOut)
        Me.tabAudio.Controls.Add(Me.txtFadeIn)
        Me.tabAudio.Controls.Add(Me.txtResolution)
        Me.tabAudio.Controls.Add(Me.txtSamplingRate)
        Me.tabAudio.Controls.Add(Me._lblAudio_3)
        Me.tabAudio.Controls.Add(Me._lblAudio_2)
        Me.tabAudio.Controls.Add(Me._lblAudio_1)
        Me.tabAudio.Controls.Add(Me._lblAudio_0)
        Me.tabAudio.Controls.Add(Me.fraVocBox)
        Me.tabAudio.Controls.Add(Me.fraAudioDACMulti)
        Me.tabAudio.Controls.Add(Me.fraAudioDACLeft)
        Me.tabAudio.Controls.Add(Me.fraAudioDACRight)
        Me.tabAudio.Location = New System.Drawing.Point(4, 40)
        Me.tabAudio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabAudio.Name = "tabAudio"
        Me.tabAudio.Size = New System.Drawing.Size(688, 539)
        Me.tabAudio.TabIndex = 6
        Me.tabAudio.Text = "Audio"
        Me.tabAudio.UseVisualStyleBackColor = True
        '
        '_fraAudioDither_1
        '
        Me._fraAudioDither_1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._fraAudioDither_1.Controls.Add(Me.sldAudioDitherAmp_1)
        Me._fraAudioDither_1.Controls.Add(Me._txtAudioDitherPar1_1)
        Me._fraAudioDither_1.Controls.Add(Me._cmbAudioDither_1)
        Me._fraAudioDither_1.Controls.Add(Me._txtAudioDitherLC_1)
        Me._fraAudioDither_1.Controls.Add(Me._txtAudioDitherHC_1)
        Me._fraAudioDither_1.Controls.Add(Me._lblAudio_7)
        Me._fraAudioDither_1.Controls.Add(Me._lblAudio_8)
        Me._fraAudioDither_1.Controls.Add(Me._lblAudio_9)
        Me._fraAudioDither_1.Controls.Add(Me.Label46)
        Me._fraAudioDither_1.Controls.Add(Me._lblAudioDitherAmp_1)
        Me._fraAudioDither_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraAudioDither.SetIndex(Me._fraAudioDither_1, CType(1, Short))
        Me._fraAudioDither_1.Location = New System.Drawing.Point(4, 230)
        Me._fraAudioDither_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._fraAudioDither_1.Name = "_fraAudioDither_1"
        Me._fraAudioDither_1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._fraAudioDither_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraAudioDither_1.Size = New System.Drawing.Size(644, 90)
        Me._fraAudioDither_1.TabIndex = 184
        Me._fraAudioDither_1.TabStop = False
        Me._fraAudioDither_1.Text = "Synthesizer B:"
        '
        'sldAudioDitherAmp_1
        '
        Me.sldAudioDitherAmp_1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sldAudioDitherAmp_1.AutoSize = False
        Me.sldAudioDitherAmp_1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.sldAudioDitherAmp_1.Location = New System.Drawing.Point(17, 54)
        Me.sldAudioDitherAmp_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.sldAudioDitherAmp_1.Maximum = 1000
        Me.sldAudioDitherAmp_1.Name = "sldAudioDitherAmp_1"
        Me.sldAudioDitherAmp_1.Size = New System.Drawing.Size(419, 30)
        Me.sldAudioDitherAmp_1.TabIndex = 227
        Me.sldAudioDitherAmp_1.TickFrequency = 10
        Me.sldAudioDitherAmp_1.TickStyle = System.Windows.Forms.TickStyle.None
        '
        '_txtAudioDitherPar1_1
        '
        Me._txtAudioDitherPar1_1.AcceptsReturn = True
        Me._txtAudioDitherPar1_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._txtAudioDitherPar1_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtAudioDitherPar1_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtAudioDitherPar1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAudioDitherPar1.SetIndex(Me._txtAudioDitherPar1_1, CType(1, Short))
        Me._txtAudioDitherPar1_1.Location = New System.Drawing.Point(541, 10)
        Me._txtAudioDitherPar1_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._txtAudioDitherPar1_1.MaxLength = 10
        Me._txtAudioDitherPar1_1.Name = "_txtAudioDitherPar1_1"
        Me._txtAudioDitherPar1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtAudioDitherPar1_1.Size = New System.Drawing.Size(80, 22)
        Me._txtAudioDitherPar1_1.TabIndex = 225
        '
        '_cmbAudioDither_1
        '
        Me._cmbAudioDither_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbAudioDither_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbAudioDither_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbAudioDither.SetIndex(Me._cmbAudioDither_1, CType(1, Short))
        Me._cmbAudioDither_1.Location = New System.Drawing.Point(28, 25)
        Me._cmbAudioDither_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._cmbAudioDither_1.Name = "_cmbAudioDither_1"
        Me._cmbAudioDither_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbAudioDither_1.Size = New System.Drawing.Size(96, 24)
        Me._cmbAudioDither_1.TabIndex = 188
        '
        '_txtAudioDitherLC_1
        '
        Me._txtAudioDitherLC_1.AcceptsReturn = True
        Me._txtAudioDitherLC_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._txtAudioDitherLC_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtAudioDitherLC_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtAudioDitherLC_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAudioDitherLC.SetIndex(Me._txtAudioDitherLC_1, CType(1, Short))
        Me._txtAudioDitherLC_1.Location = New System.Drawing.Point(541, 34)
        Me._txtAudioDitherLC_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._txtAudioDitherLC_1.MaxLength = 10
        Me._txtAudioDitherLC_1.Name = "_txtAudioDitherLC_1"
        Me._txtAudioDitherLC_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtAudioDitherLC_1.Size = New System.Drawing.Size(80, 22)
        Me._txtAudioDitherLC_1.TabIndex = 186
        '
        '_txtAudioDitherHC_1
        '
        Me._txtAudioDitherHC_1.AcceptsReturn = True
        Me._txtAudioDitherHC_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._txtAudioDitherHC_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtAudioDitherHC_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtAudioDitherHC_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAudioDitherHC.SetIndex(Me._txtAudioDitherHC_1, CType(1, Short))
        Me._txtAudioDitherHC_1.Location = New System.Drawing.Point(541, 59)
        Me._txtAudioDitherHC_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._txtAudioDitherHC_1.MaxLength = 10
        Me._txtAudioDitherHC_1.Name = "_txtAudioDitherHC_1"
        Me._txtAudioDitherHC_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtAudioDitherHC_1.Size = New System.Drawing.Size(80, 22)
        Me._txtAudioDitherHC_1.TabIndex = 187
        '
        '_lblAudio_7
        '
        Me._lblAudio_7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._lblAudio_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblAudio_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAudio.SetIndex(Me._lblAudio_7, CType(7, Short))
        Me._lblAudio_7.Location = New System.Drawing.Point(444, 15)
        Me._lblAudio_7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblAudio_7.Name = "_lblAudio_7"
        Me._lblAudio_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblAudio_7.Size = New System.Drawing.Size(85, 16)
        Me._lblAudio_7.TabIndex = 226
        Me._lblAudio_7.Text = "Par1:"
        Me._lblAudio_7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblAudio_8
        '
        Me._lblAudio_8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._lblAudio_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblAudio_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAudio.SetIndex(Me._lblAudio_8, CType(8, Short))
        Me._lblAudio_8.Location = New System.Drawing.Point(435, 37)
        Me._lblAudio_8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblAudio_8.Name = "_lblAudio_8"
        Me._lblAudio_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblAudio_8.Size = New System.Drawing.Size(105, 16)
        Me._lblAudio_8.TabIndex = 192
        Me._lblAudio_8.Text = "Low Cut [Hz]:"
        '
        '_lblAudio_9
        '
        Me._lblAudio_9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._lblAudio_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblAudio_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAudio.SetIndex(Me._lblAudio_9, CType(9, Short))
        Me._lblAudio_9.Location = New System.Drawing.Point(432, 63)
        Me._lblAudio_9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblAudio_9.Name = "_lblAudio_9"
        Me._lblAudio_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblAudio_9.Size = New System.Drawing.Size(99, 16)
        Me._lblAudio_9.TabIndex = 191
        Me._lblAudio_9.Text = "High Cut [Hz]:"
        '
        'Label46
        '
        Me.Label46.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label46.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label46.Location = New System.Drawing.Point(141, 34)
        Me.Label46.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label46.Name = "Label46"
        Me.Label46.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label46.Size = New System.Drawing.Size(103, 25)
        Me.Label46.TabIndex = 190
        Me.Label46.Text = "Amp [dB FS]:"
        '
        '_lblAudioDitherAmp_1
        '
        Me._lblAudioDitherAmp_1.AutoSize = True
        Me._lblAudioDitherAmp_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblAudioDitherAmp_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblAudioDitherAmp_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAudioDitherAmp.SetIndex(Me._lblAudioDitherAmp_1, CType(1, Short))
        Me._lblAudioDitherAmp_1.Location = New System.Drawing.Point(245, 34)
        Me._lblAudioDitherAmp_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblAudioDitherAmp_1.Name = "_lblAudioDitherAmp_1"
        Me._lblAudioDitherAmp_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblAudioDitherAmp_1.Size = New System.Drawing.Size(48, 17)
        Me._lblAudioDitherAmp_1.TabIndex = 189
        Me._lblAudioDitherAmp_1.Text = "XXXX"
        Me._lblAudioDitherAmp_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_fraAudioDither_0
        '
        Me._fraAudioDither_0.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._fraAudioDither_0.Controls.Add(Me.sldAudioDitherAmp_0)
        Me._fraAudioDither_0.Controls.Add(Me._txtAudioDitherPar1_0)
        Me._fraAudioDither_0.Controls.Add(Me._txtAudioDitherLC_0)
        Me._fraAudioDither_0.Controls.Add(Me._txtAudioDitherHC_0)
        Me._fraAudioDither_0.Controls.Add(Me._cmbAudioDither_0)
        Me._fraAudioDither_0.Controls.Add(Me._lblAudio_4)
        Me._fraAudioDither_0.Controls.Add(Me._lblAudioDitherAmp_0)
        Me._fraAudioDither_0.Controls.Add(Me.Label35)
        Me._fraAudioDither_0.Controls.Add(Me._lblAudio_6)
        Me._fraAudioDither_0.Controls.Add(Me._lblAudio_5)
        Me._fraAudioDither_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraAudioDither.SetIndex(Me._fraAudioDither_0, CType(0, Short))
        Me._fraAudioDither_0.Location = New System.Drawing.Point(4, 137)
        Me._fraAudioDither_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._fraAudioDither_0.Name = "_fraAudioDither_0"
        Me._fraAudioDither_0.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._fraAudioDither_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraAudioDither_0.Size = New System.Drawing.Size(644, 90)
        Me._fraAudioDither_0.TabIndex = 175
        Me._fraAudioDither_0.TabStop = False
        Me._fraAudioDither_0.Text = "Synthesizer A:"
        '
        'sldAudioDitherAmp_0
        '
        Me.sldAudioDitherAmp_0.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sldAudioDitherAmp_0.AutoSize = False
        Me.sldAudioDitherAmp_0.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.sldAudioDitherAmp_0.Location = New System.Drawing.Point(17, 54)
        Me.sldAudioDitherAmp_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.sldAudioDitherAmp_0.Maximum = 1000
        Me.sldAudioDitherAmp_0.Name = "sldAudioDitherAmp_0"
        Me.sldAudioDitherAmp_0.Size = New System.Drawing.Size(419, 30)
        Me.sldAudioDitherAmp_0.TabIndex = 225
        Me.sldAudioDitherAmp_0.TickFrequency = 10
        Me.sldAudioDitherAmp_0.TickStyle = System.Windows.Forms.TickStyle.None
        '
        '_txtAudioDitherPar1_0
        '
        Me._txtAudioDitherPar1_0.AcceptsReturn = True
        Me._txtAudioDitherPar1_0.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._txtAudioDitherPar1_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtAudioDitherPar1_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtAudioDitherPar1_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAudioDitherPar1.SetIndex(Me._txtAudioDitherPar1_0, CType(0, Short))
        Me._txtAudioDitherPar1_0.Location = New System.Drawing.Point(541, 10)
        Me._txtAudioDitherPar1_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._txtAudioDitherPar1_0.MaxLength = 10
        Me._txtAudioDitherPar1_0.Name = "_txtAudioDitherPar1_0"
        Me._txtAudioDitherPar1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtAudioDitherPar1_0.Size = New System.Drawing.Size(80, 22)
        Me._txtAudioDitherPar1_0.TabIndex = 223
        '
        '_txtAudioDitherLC_0
        '
        Me._txtAudioDitherLC_0.AcceptsReturn = True
        Me._txtAudioDitherLC_0.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._txtAudioDitherLC_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtAudioDitherLC_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtAudioDitherLC_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAudioDitherLC.SetIndex(Me._txtAudioDitherLC_0, CType(0, Short))
        Me._txtAudioDitherLC_0.Location = New System.Drawing.Point(541, 34)
        Me._txtAudioDitherLC_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._txtAudioDitherLC_0.MaxLength = 10
        Me._txtAudioDitherLC_0.Name = "_txtAudioDitherLC_0"
        Me._txtAudioDitherLC_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtAudioDitherLC_0.Size = New System.Drawing.Size(80, 22)
        Me._txtAudioDitherLC_0.TabIndex = 178
        '
        '_txtAudioDitherHC_0
        '
        Me._txtAudioDitherHC_0.AcceptsReturn = True
        Me._txtAudioDitherHC_0.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._txtAudioDitherHC_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtAudioDitherHC_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtAudioDitherHC_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAudioDitherHC.SetIndex(Me._txtAudioDitherHC_0, CType(0, Short))
        Me._txtAudioDitherHC_0.Location = New System.Drawing.Point(541, 59)
        Me._txtAudioDitherHC_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._txtAudioDitherHC_0.MaxLength = 10
        Me._txtAudioDitherHC_0.Name = "_txtAudioDitherHC_0"
        Me._txtAudioDitherHC_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtAudioDitherHC_0.Size = New System.Drawing.Size(80, 22)
        Me._txtAudioDitherHC_0.TabIndex = 177
        '
        '_cmbAudioDither_0
        '
        Me._cmbAudioDither_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmbAudioDither_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbAudioDither_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbAudioDither.SetIndex(Me._cmbAudioDither_0, CType(0, Short))
        Me._cmbAudioDither_0.Location = New System.Drawing.Point(28, 25)
        Me._cmbAudioDither_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._cmbAudioDither_0.Name = "_cmbAudioDither_0"
        Me._cmbAudioDither_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmbAudioDither_0.Size = New System.Drawing.Size(96, 24)
        Me._cmbAudioDither_0.TabIndex = 176
        '
        '_lblAudio_4
        '
        Me._lblAudio_4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._lblAudio_4.BackColor = System.Drawing.Color.Transparent
        Me._lblAudio_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblAudio_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAudio.SetIndex(Me._lblAudio_4, CType(4, Short))
        Me._lblAudio_4.Location = New System.Drawing.Point(435, 15)
        Me._lblAudio_4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblAudio_4.Name = "_lblAudio_4"
        Me._lblAudio_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblAudio_4.Size = New System.Drawing.Size(95, 16)
        Me._lblAudio_4.TabIndex = 224
        Me._lblAudio_4.Text = "Par1:"
        Me._lblAudio_4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblAudioDitherAmp_0
        '
        Me._lblAudioDitherAmp_0.AutoSize = True
        Me._lblAudioDitherAmp_0.BackColor = System.Drawing.Color.Transparent
        Me._lblAudioDitherAmp_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblAudioDitherAmp_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblAudioDitherAmp_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAudioDitherAmp.SetIndex(Me._lblAudioDitherAmp_0, CType(0, Short))
        Me._lblAudioDitherAmp_0.Location = New System.Drawing.Point(245, 34)
        Me._lblAudioDitherAmp_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblAudioDitherAmp_0.Name = "_lblAudioDitherAmp_0"
        Me._lblAudioDitherAmp_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblAudioDitherAmp_0.Size = New System.Drawing.Size(48, 17)
        Me._lblAudioDitherAmp_0.TabIndex = 183
        Me._lblAudioDitherAmp_0.Text = "XXXX"
        Me._lblAudioDitherAmp_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label35.Location = New System.Drawing.Point(141, 34)
        Me.Label35.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label35.Size = New System.Drawing.Size(103, 25)
        Me.Label35.TabIndex = 182
        Me.Label35.Text = "Amp [dB FS]:"
        '
        '_lblAudio_6
        '
        Me._lblAudio_6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._lblAudio_6.BackColor = System.Drawing.Color.Transparent
        Me._lblAudio_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblAudio_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAudio.SetIndex(Me._lblAudio_6, CType(6, Short))
        Me._lblAudio_6.Location = New System.Drawing.Point(433, 64)
        Me._lblAudio_6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblAudio_6.Name = "_lblAudio_6"
        Me._lblAudio_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblAudio_6.Size = New System.Drawing.Size(107, 20)
        Me._lblAudio_6.TabIndex = 181
        Me._lblAudio_6.Text = "High Cut [Hz]:"
        '
        '_lblAudio_5
        '
        Me._lblAudio_5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._lblAudio_5.BackColor = System.Drawing.Color.Transparent
        Me._lblAudio_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblAudio_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAudio.SetIndex(Me._lblAudio_5, CType(5, Short))
        Me._lblAudio_5.Location = New System.Drawing.Point(436, 38)
        Me._lblAudio_5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblAudio_5.Name = "_lblAudio_5"
        Me._lblAudio_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblAudio_5.Size = New System.Drawing.Size(100, 16)
        Me._lblAudio_5.TabIndex = 180
        Me._lblAudio_5.Text = "Low Cut [Hz]:"
        '
        'txtFadeOut
        '
        Me.txtFadeOut.AcceptsReturn = True
        Me.txtFadeOut.BackColor = System.Drawing.SystemColors.Window
        Me.txtFadeOut.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFadeOut.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFadeOut.Location = New System.Drawing.Point(399, 58)
        Me.txtFadeOut.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFadeOut.MaxLength = 10
        Me.txtFadeOut.Name = "txtFadeOut"
        Me.txtFadeOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFadeOut.Size = New System.Drawing.Size(69, 22)
        Me.txtFadeOut.TabIndex = 114
        '
        'txtFadeIn
        '
        Me.txtFadeIn.AcceptsReturn = True
        Me.txtFadeIn.BackColor = System.Drawing.SystemColors.Window
        Me.txtFadeIn.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFadeIn.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFadeIn.Location = New System.Drawing.Point(159, 58)
        Me.txtFadeIn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFadeIn.MaxLength = 10
        Me.txtFadeIn.Name = "txtFadeIn"
        Me.txtFadeIn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFadeIn.Size = New System.Drawing.Size(69, 22)
        Me.txtFadeIn.TabIndex = 113
        '
        'txtResolution
        '
        Me.txtResolution.AcceptsReturn = True
        Me.txtResolution.BackColor = System.Drawing.SystemColors.Window
        Me.txtResolution.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtResolution.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtResolution.Location = New System.Drawing.Point(425, 23)
        Me.txtResolution.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtResolution.MaxLength = 10
        Me.txtResolution.Name = "txtResolution"
        Me.txtResolution.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtResolution.Size = New System.Drawing.Size(43, 22)
        Me.txtResolution.TabIndex = 112
        '
        'txtSamplingRate
        '
        Me.txtSamplingRate.AcceptsReturn = True
        Me.txtSamplingRate.BackColor = System.Drawing.SystemColors.Window
        Me.txtSamplingRate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSamplingRate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSamplingRate.Location = New System.Drawing.Point(159, 23)
        Me.txtSamplingRate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSamplingRate.MaxLength = 10
        Me.txtSamplingRate.Name = "txtSamplingRate"
        Me.txtSamplingRate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSamplingRate.Size = New System.Drawing.Size(107, 22)
        Me.txtSamplingRate.TabIndex = 111
        '
        '_lblAudio_3
        '
        Me._lblAudio_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblAudio_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAudio.SetIndex(Me._lblAudio_3, CType(3, Short))
        Me._lblAudio_3.Location = New System.Drawing.Point(283, 63)
        Me._lblAudio_3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblAudio_3.Name = "_lblAudio_3"
        Me._lblAudio_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblAudio_3.Size = New System.Drawing.Size(104, 16)
        Me._lblAudio_3.TabIndex = 165
        Me._lblAudio_3.Text = "Fade Out [ms]:"
        Me._lblAudio_3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblAudio_2
        '
        Me._lblAudio_2.AutoSize = True
        Me._lblAudio_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblAudio_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAudio.SetIndex(Me._lblAudio_2, CType(2, Short))
        Me._lblAudio_2.Location = New System.Drawing.Point(64, 63)
        Me._lblAudio_2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblAudio_2.Name = "_lblAudio_2"
        Me._lblAudio_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblAudio_2.Size = New System.Drawing.Size(89, 17)
        Me._lblAudio_2.TabIndex = 164
        Me._lblAudio_2.Text = "Fade In [ms]:"
        Me._lblAudio_2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblAudio_1
        '
        Me._lblAudio_1.AutoSize = True
        Me._lblAudio_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblAudio_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAudio.SetIndex(Me._lblAudio_1, CType(1, Short))
        Me._lblAudio_1.Location = New System.Drawing.Point(311, 27)
        Me._lblAudio_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblAudio_1.Name = "_lblAudio_1"
        Me._lblAudio_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblAudio_1.Size = New System.Drawing.Size(106, 17)
        Me._lblAudio_1.TabIndex = 128
        Me._lblAudio_1.Text = "Resolution [bit]:"
        Me._lblAudio_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblAudio_0
        '
        Me._lblAudio_0.AutoSize = True
        Me._lblAudio_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblAudio_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAudio.SetIndex(Me._lblAudio_0, CType(0, Short))
        Me._lblAudio_0.Location = New System.Drawing.Point(27, 28)
        Me._lblAudio_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblAudio_0.Name = "_lblAudio_0"
        Me._lblAudio_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblAudio_0.Size = New System.Drawing.Size(128, 17)
        Me._lblAudio_0.TabIndex = 127
        Me._lblAudio_0.Text = "Sampling rate [Hz]:"
        Me._lblAudio_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'fraVocBox
        '
        Me.fraVocBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraVocBox.Controls.Add(Me.facScaletxt)
        Me.fraVocBox.Controls.Add(Me.facScalelbl)
        Me.fraVocBox.Controls.Add(Me.NoiseVoc)
        Me.fraVocBox.Controls.Add(Me.GetVoc)
        Me.fraVocBox.Controls.Add(Me.facScalelbl2)
        Me.fraVocBox.Controls.Add(Me.facScaletxt2)
        Me.fraVocBox.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraVocBox.Location = New System.Drawing.Point(477, 18)
        Me.fraVocBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraVocBox.Name = "fraVocBox"
        Me.fraVocBox.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraVocBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraVocBox.Size = New System.Drawing.Size(171, 103)
        Me.fraVocBox.TabIndex = 225
        Me.fraVocBox.TabStop = False
        Me.fraVocBox.Text = "Vocoder Type:"
        '
        'facScaletxt
        '
        Me.facScaletxt.BackColor = System.Drawing.Color.Transparent
        Me.facScaletxt.Cursor = System.Windows.Forms.Cursors.Default
        Me.facScaletxt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.facScaletxt.Location = New System.Drawing.Point(8, 74)
        Me.facScaletxt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.facScaletxt.Name = "facScaletxt"
        Me.facScaletxt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.facScaletxt.Size = New System.Drawing.Size(100, 16)
        Me.facScaletxt.TabIndex = 220
        Me.facScaletxt.Text = "Scaling Factor"
        '
        'facScalelbl
        '
        Me.facScalelbl.AcceptsReturn = True
        Me.facScalelbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.facScalelbl.BackColor = System.Drawing.SystemColors.Window
        Me.facScalelbl.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.facScalelbl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.facScalelbl.Location = New System.Drawing.Point(109, 70)
        Me.facScalelbl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.facScalelbl.MaxLength = 10
        Me.facScalelbl.Name = "facScalelbl"
        Me.facScalelbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.facScalelbl.Size = New System.Drawing.Size(52, 22)
        Me.facScalelbl.TabIndex = 219
        '
        'NoiseVoc
        '
        Me.NoiseVoc.AutoSize = True
        Me.NoiseVoc.Cursor = System.Windows.Forms.Cursors.Default
        Me.NoiseVoc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.NoiseVoc.Location = New System.Drawing.Point(8, 20)
        Me.NoiseVoc.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NoiseVoc.Name = "NoiseVoc"
        Me.NoiseVoc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NoiseVoc.Size = New System.Drawing.Size(122, 21)
        Me.NoiseVoc.TabIndex = 212
        Me.NoiseVoc.TabStop = True
        Me.NoiseVoc.Text = "Noise Vocoder"
        Me.NoiseVoc.UseVisualStyleBackColor = False
        '
        'GetVoc
        '
        Me.GetVoc.Cursor = System.Windows.Forms.Cursors.Default
        Me.GetVoc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GetVoc.Location = New System.Drawing.Point(8, 43)
        Me.GetVoc.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GetVoc.Name = "GetVoc"
        Me.GetVoc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GetVoc.Size = New System.Drawing.Size(133, 23)
        Me.GetVoc.TabIndex = 211
        Me.GetVoc.TabStop = True
        Me.GetVoc.Text = "GET Vocoder"
        Me.GetVoc.UseVisualStyleBackColor = False
        '
        'facScalelbl2
        '
        Me.facScalelbl2.AcceptsReturn = True
        Me.facScalelbl2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.facScalelbl2.BackColor = System.Drawing.SystemColors.Window
        Me.facScalelbl2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.facScalelbl2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.facScalelbl2.Location = New System.Drawing.Point(647, 415)
        Me.facScalelbl2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.facScalelbl2.MaxLength = 10
        Me.facScalelbl2.Name = "facScalelbl2"
        Me.facScalelbl2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.facScalelbl2.Size = New System.Drawing.Size(80, 22)
        Me.facScalelbl2.TabIndex = 226
        '
        'facScaletxt2
        '
        Me.facScaletxt2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.facScaletxt2.BackColor = System.Drawing.Color.Transparent
        Me.facScaletxt2.Cursor = System.Windows.Forms.Cursors.Default
        Me.facScaletxt2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.facScaletxt2.Location = New System.Drawing.Point(407, 34)
        Me.facScaletxt2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.facScaletxt2.Name = "facScaletxt2"
        Me.facScaletxt2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.facScaletxt2.Size = New System.Drawing.Size(95, 16)
        Me.facScaletxt2.TabIndex = 226
        Me.facScaletxt2.Text = "Scaling Factor"
        Me.facScaletxt2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'fraAudioDACMulti
        '
        Me.fraAudioDACMulti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fraAudioDACMulti.Controls.Add(Me.cmdAudioSynthAllA)
        Me.fraAudioDACMulti.Controls.Add(Me.cmdAudioSynthAllB)
        Me.fraAudioDACMulti.Controls.Add(Me.cmdAudioSynthDis)
        Me.fraAudioDACMulti.Controls.Add(Me.cmbAudioSynthCh)
        Me.fraAudioDACMulti.Controls.Add(Me._optAudioSynthDAC_0)
        Me.fraAudioDACMulti.Controls.Add(Me._optAudioSynthDAC_1)
        Me.fraAudioDACMulti.Controls.Add(Me._optAudioSynthDAC_2)
        Me.fraAudioDACMulti.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraAudioDACMulti.Location = New System.Drawing.Point(4, 324)
        Me.fraAudioDACMulti.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraAudioDACMulti.Name = "fraAudioDACMulti"
        Me.fraAudioDACMulti.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraAudioDACMulti.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraAudioDACMulti.Size = New System.Drawing.Size(644, 182)
        Me.fraAudioDACMulti.TabIndex = 209
        Me.fraAudioDACMulti.TabStop = False
        Me.fraAudioDACMulti.Text = "Channel:"
        '
        'cmdAudioSynthAllA
        '
        Me.cmdAudioSynthAllA.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAudioSynthAllA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAudioSynthAllA.Location = New System.Drawing.Point(459, 38)
        Me.cmdAudioSynthAllA.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdAudioSynthAllA.Name = "cmdAudioSynthAllA"
        Me.cmdAudioSynthAllA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAudioSynthAllA.Size = New System.Drawing.Size(155, 27)
        Me.cmdAudioSynthAllA.TabIndex = 224
        Me.cmdAudioSynthAllA.Text = "Synth A: All Channels"
        Me.cmdAudioSynthAllA.UseVisualStyleBackColor = False
        '
        'cmdAudioSynthAllB
        '
        Me.cmdAudioSynthAllB.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAudioSynthAllB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAudioSynthAllB.Location = New System.Drawing.Point(459, 69)
        Me.cmdAudioSynthAllB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdAudioSynthAllB.Name = "cmdAudioSynthAllB"
        Me.cmdAudioSynthAllB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAudioSynthAllB.Size = New System.Drawing.Size(155, 27)
        Me.cmdAudioSynthAllB.TabIndex = 223
        Me.cmdAudioSynthAllB.Text = "Synth B: All Channels"
        Me.cmdAudioSynthAllB.UseVisualStyleBackColor = False
        '
        'cmdAudioSynthDis
        '
        Me.cmdAudioSynthDis.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAudioSynthDis.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAudioSynthDis.Location = New System.Drawing.Point(333, 20)
        Me.cmdAudioSynthDis.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdAudioSynthDis.Name = "cmdAudioSynthDis"
        Me.cmdAudioSynthDis.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAudioSynthDis.Size = New System.Drawing.Size(120, 78)
        Me.cmdAudioSynthDis.TabIndex = 222
        Me.cmdAudioSynthDis.Text = "Disable All Channels"
        Me.cmdAudioSynthDis.UseVisualStyleBackColor = False
        '
        '_optAudioSynthDAC_0
        '
        Me._optAudioSynthDAC_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._optAudioSynthDAC_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optAudioSynthDAC.SetIndex(Me._optAudioSynthDAC_0, CType(0, Short))
        Me._optAudioSynthDAC_0.Location = New System.Drawing.Point(247, 26)
        Me._optAudioSynthDAC_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._optAudioSynthDAC_0.Name = "_optAudioSynthDAC_0"
        Me._optAudioSynthDAC_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optAudioSynthDAC_0.Size = New System.Drawing.Size(103, 21)
        Me._optAudioSynthDAC_0.TabIndex = 212
        Me._optAudioSynthDAC_0.TabStop = True
        Me._optAudioSynthDAC_0.Text = "Disabled"
        Me._optAudioSynthDAC_0.UseVisualStyleBackColor = False
        '
        '_optAudioSynthDAC_1
        '
        Me._optAudioSynthDAC_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._optAudioSynthDAC_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optAudioSynthDAC.SetIndex(Me._optAudioSynthDAC_1, CType(1, Short))
        Me._optAudioSynthDAC_1.Location = New System.Drawing.Point(247, 48)
        Me._optAudioSynthDAC_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._optAudioSynthDAC_1.Name = "_optAudioSynthDAC_1"
        Me._optAudioSynthDAC_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optAudioSynthDAC_1.Size = New System.Drawing.Size(88, 23)
        Me._optAudioSynthDAC_1.TabIndex = 211
        Me._optAudioSynthDAC_1.TabStop = True
        Me._optAudioSynthDAC_1.Text = "Synth A"
        Me._optAudioSynthDAC_1.UseVisualStyleBackColor = False
        '
        '_optAudioSynthDAC_2
        '
        Me._optAudioSynthDAC_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._optAudioSynthDAC_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optAudioSynthDAC.SetIndex(Me._optAudioSynthDAC_2, CType(2, Short))
        Me._optAudioSynthDAC_2.Location = New System.Drawing.Point(247, 71)
        Me._optAudioSynthDAC_2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._optAudioSynthDAC_2.Name = "_optAudioSynthDAC_2"
        Me._optAudioSynthDAC_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optAudioSynthDAC_2.Size = New System.Drawing.Size(88, 23)
        Me._optAudioSynthDAC_2.TabIndex = 210
        Me._optAudioSynthDAC_2.TabStop = True
        Me._optAudioSynthDAC_2.Text = "Synth B"
        Me._optAudioSynthDAC_2.UseVisualStyleBackColor = False
        '
        'fraAudioDACLeft
        '
        Me.fraAudioDACLeft.Controls.Add(Me._optAudioDitherLeft_0)
        Me.fraAudioDACLeft.Controls.Add(Me._optAudioDitherLeft_1)
        Me.fraAudioDACLeft.Controls.Add(Me._optAudioDitherLeft_2)
        Me.fraAudioDACLeft.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraAudioDACLeft.Location = New System.Drawing.Point(4, 324)
        Me.fraAudioDACLeft.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraAudioDACLeft.Name = "fraAudioDACLeft"
        Me.fraAudioDACLeft.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraAudioDACLeft.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraAudioDACLeft.Size = New System.Drawing.Size(161, 100)
        Me.fraAudioDACLeft.TabIndex = 218
        Me.fraAudioDACLeft.TabStop = False
        Me.fraAudioDACLeft.Text = "Channel Left:"
        '
        '_optAudioDitherLeft_0
        '
        Me._optAudioDitherLeft_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._optAudioDitherLeft_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optAudioDitherLeft.SetIndex(Me._optAudioDitherLeft_0, CType(0, Short))
        Me._optAudioDitherLeft_0.Location = New System.Drawing.Point(21, 25)
        Me._optAudioDitherLeft_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._optAudioDitherLeft_0.Name = "_optAudioDitherLeft_0"
        Me._optAudioDitherLeft_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optAudioDitherLeft_0.Size = New System.Drawing.Size(91, 22)
        Me._optAudioDitherLeft_0.TabIndex = 221
        Me._optAudioDitherLeft_0.TabStop = True
        Me._optAudioDitherLeft_0.Text = "Disabled"
        Me._optAudioDitherLeft_0.UseVisualStyleBackColor = False
        '
        '_optAudioDitherLeft_1
        '
        Me._optAudioDitherLeft_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._optAudioDitherLeft_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optAudioDitherLeft.SetIndex(Me._optAudioDitherLeft_1, CType(1, Short))
        Me._optAudioDitherLeft_1.Location = New System.Drawing.Point(21, 47)
        Me._optAudioDitherLeft_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._optAudioDitherLeft_1.Name = "_optAudioDitherLeft_1"
        Me._optAudioDitherLeft_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optAudioDitherLeft_1.Size = New System.Drawing.Size(91, 22)
        Me._optAudioDitherLeft_1.TabIndex = 220
        Me._optAudioDitherLeft_1.TabStop = True
        Me._optAudioDitherLeft_1.Text = "Synth A"
        Me._optAudioDitherLeft_1.UseVisualStyleBackColor = False
        '
        '_optAudioDitherLeft_2
        '
        Me._optAudioDitherLeft_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._optAudioDitherLeft_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optAudioDitherLeft.SetIndex(Me._optAudioDitherLeft_2, CType(2, Short))
        Me._optAudioDitherLeft_2.Location = New System.Drawing.Point(21, 69)
        Me._optAudioDitherLeft_2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._optAudioDitherLeft_2.Name = "_optAudioDitherLeft_2"
        Me._optAudioDitherLeft_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optAudioDitherLeft_2.Size = New System.Drawing.Size(91, 21)
        Me._optAudioDitherLeft_2.TabIndex = 219
        Me._optAudioDitherLeft_2.TabStop = True
        Me._optAudioDitherLeft_2.Text = "Synth B"
        Me._optAudioDitherLeft_2.UseVisualStyleBackColor = False
        '
        'fraAudioDACRight
        '
        Me.fraAudioDACRight.Controls.Add(Me._optAudioDitherRight_2)
        Me.fraAudioDACRight.Controls.Add(Me._optAudioDitherRight_1)
        Me.fraAudioDACRight.Controls.Add(Me._optAudioDitherRight_0)
        Me.fraAudioDACRight.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraAudioDACRight.Location = New System.Drawing.Point(176, 324)
        Me.fraAudioDACRight.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraAudioDACRight.Name = "fraAudioDACRight"
        Me.fraAudioDACRight.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraAudioDACRight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraAudioDACRight.Size = New System.Drawing.Size(167, 100)
        Me.fraAudioDACRight.TabIndex = 214
        Me.fraAudioDACRight.TabStop = False
        Me.fraAudioDACRight.Text = "Channel Right:"
        '
        '_optAudioDitherRight_2
        '
        Me._optAudioDitherRight_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._optAudioDitherRight_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optAudioDitherRight.SetIndex(Me._optAudioDitherRight_2, CType(2, Short))
        Me._optAudioDitherRight_2.Location = New System.Drawing.Point(32, 68)
        Me._optAudioDitherRight_2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._optAudioDitherRight_2.Name = "_optAudioDitherRight_2"
        Me._optAudioDitherRight_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optAudioDitherRight_2.Size = New System.Drawing.Size(97, 23)
        Me._optAudioDitherRight_2.TabIndex = 217
        Me._optAudioDitherRight_2.TabStop = True
        Me._optAudioDitherRight_2.Text = "Synth B"
        Me._optAudioDitherRight_2.UseVisualStyleBackColor = False
        '
        '_optAudioDitherRight_1
        '
        Me._optAudioDitherRight_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._optAudioDitherRight_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optAudioDitherRight.SetIndex(Me._optAudioDitherRight_1, CType(1, Short))
        Me._optAudioDitherRight_1.Location = New System.Drawing.Point(32, 47)
        Me._optAudioDitherRight_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._optAudioDitherRight_1.Name = "_optAudioDitherRight_1"
        Me._optAudioDitherRight_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optAudioDitherRight_1.Size = New System.Drawing.Size(87, 22)
        Me._optAudioDitherRight_1.TabIndex = 216
        Me._optAudioDitherRight_1.TabStop = True
        Me._optAudioDitherRight_1.Text = "Synth A"
        Me._optAudioDitherRight_1.UseVisualStyleBackColor = False
        '
        '_optAudioDitherRight_0
        '
        Me._optAudioDitherRight_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._optAudioDitherRight_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optAudioDitherRight.SetIndex(Me._optAudioDitherRight_0, CType(0, Short))
        Me._optAudioDitherRight_0.Location = New System.Drawing.Point(32, 25)
        Me._optAudioDitherRight_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._optAudioDitherRight_0.Name = "_optAudioDitherRight_0"
        Me._optAudioDitherRight_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optAudioDitherRight_0.Size = New System.Drawing.Size(101, 22)
        Me._optAudioDitherRight_0.TabIndex = 215
        Me._optAudioDitherRight_0.TabStop = True
        Me._optAudioDitherRight_0.Text = "Disabled"
        Me._optAudioDitherRight_0.UseVisualStyleBackColor = False
        '
        'tabProcedure
        '
        Me.tabProcedure.Controls.Add(Me.txtExperimentItemRange)
        Me.tabProcedure.Controls.Add(Me.lblPreStimVisuOffset)
        Me.tabProcedure.Controls.Add(Me.lblExpType)
        Me.tabProcedure.Controls.Add(Me.lblInterStimBreak)
        Me.tabProcedure.Controls.Add(Me.lblItemRepetition)
        Me.tabProcedure.Controls.Add(Me._lblStimOffset_2)
        Me.tabProcedure.Controls.Add(Me.lblPreStimBreak)
        Me.tabProcedure.Controls.Add(Me.lblPostStimVisuOffset)
        Me.tabProcedure.Controls.Add(Me.lblStimOffsetU)
        Me.tabProcedure.Controls.Add(Me._lblPreStimBreakU_0)
        Me.tabProcedure.Controls.Add(Me._lblPreStimVisuOffsetU_1)
        Me.tabProcedure.Controls.Add(Me._lblInterStimBreakU_2)
        Me.tabProcedure.Controls.Add(Me._lblPostStimVisuOffsetU_3)
        Me.tabProcedure.Controls.Add(Me.txtPreStimVisu)
        Me.tabProcedure.Controls.Add(Me.cmbExpType)
        Me.tabProcedure.Controls.Add(Me.txtInterStimBreak)
        Me.tabProcedure.Controls.Add(Me.txtRepetition)
        Me.tabProcedure.Controls.Add(Me.txtOffsetL)
        Me.tabProcedure.Controls.Add(Me.txtOffsetR)
        Me.tabProcedure.Controls.Add(Me.txtPreStimBreak)
        Me.tabProcedure.Controls.Add(Me.txtPostStimVisu)
        Me.tabProcedure.Controls.Add(Me.chkBreak)
        Me.tabProcedure.Controls.Add(Me.txtBreak)
        Me.tabProcedure.Controls.Add(Me.cmbBreak)
        Me.tabProcedure.Location = New System.Drawing.Point(4, 40)
        Me.tabProcedure.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabProcedure.Name = "tabProcedure"
        Me.tabProcedure.Size = New System.Drawing.Size(688, 539)
        Me.tabProcedure.TabIndex = 7
        Me.tabProcedure.Text = "Procedure"
        Me.tabProcedure.UseVisualStyleBackColor = True
        '
        'txtExperimentItemRange
        '
        Me.txtExperimentItemRange.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtExperimentItemRange.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtExperimentItemRange.Location = New System.Drawing.Point(67, 290)
        Me.txtExperimentItemRange.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtExperimentItemRange.Name = "txtExperimentItemRange"
        Me.txtExperimentItemRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExperimentItemRange.Size = New System.Drawing.Size(371, 16)
        Me.txtExperimentItemRange.TabIndex = 175
        Me.txtExperimentItemRange.Text = "Experiment Item Range: All Items"
        '
        'lblPreStimVisuOffset
        '
        Me.lblPreStimVisuOffset.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPreStimVisuOffset.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPreStimVisuOffset.Location = New System.Drawing.Point(3, 111)
        Me.lblPreStimVisuOffset.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPreStimVisuOffset.Name = "lblPreStimVisuOffset"
        Me.lblPreStimVisuOffset.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPreStimVisuOffset.Size = New System.Drawing.Size(232, 16)
        Me.lblPreStimVisuOffset.TabIndex = 122
        Me.lblPreStimVisuOffset.Text = "Pre-Stimulus Visual Offset:"
        Me.lblPreStimVisuOffset.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblExpType
        '
        Me.lblExpType.AutoSize = True
        Me.lblExpType.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblExpType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblExpType.Location = New System.Drawing.Point(48, 37)
        Me.lblExpType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblExpType.Name = "lblExpType"
        Me.lblExpType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblExpType.Size = New System.Drawing.Size(118, 17)
        Me.lblExpType.TabIndex = 123
        Me.lblExpType.Text = "Experiment Type:"
        Me.lblExpType.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblInterStimBreak
        '
        Me.lblInterStimBreak.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblInterStimBreak.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInterStimBreak.Location = New System.Drawing.Point(3, 146)
        Me.lblInterStimBreak.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInterStimBreak.Name = "lblInterStimBreak"
        Me.lblInterStimBreak.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblInterStimBreak.Size = New System.Drawing.Size(232, 16)
        Me.lblInterStimBreak.TabIndex = 124
        Me.lblInterStimBreak.Text = "Interstimulus break:"
        Me.lblInterStimBreak.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblItemRepetition
        '
        Me.lblItemRepetition.AutoSize = True
        Me.lblItemRepetition.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblItemRepetition.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblItemRepetition.Location = New System.Drawing.Point(249, 378)
        Me.lblItemRepetition.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblItemRepetition.Name = "lblItemRepetition"
        Me.lblItemRepetition.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblItemRepetition.Size = New System.Drawing.Size(145, 17)
        Me.lblItemRepetition.TabIndex = 125
        Me.lblItemRepetition.Text = "Repetitions per block:"
        Me.lblItemRepetition.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblStimOffset_2
        '
        Me._lblStimOffset_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblStimOffset_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStimOffset.SetIndex(Me._lblStimOffset_2, CType(2, Short))
        Me._lblStimOffset_2.Location = New System.Drawing.Point(69, 206)
        Me._lblStimOffset_2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblStimOffset_2.Name = "_lblStimOffset_2"
        Me._lblStimOffset_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblStimOffset_2.Size = New System.Drawing.Size(135, 16)
        Me._lblStimOffset_2.TabIndex = 126
        Me._lblStimOffset_2.Text = "Stimulus Offset:"
        Me._lblStimOffset_2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblPreStimBreak
        '
        Me.lblPreStimBreak.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPreStimBreak.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPreStimBreak.Location = New System.Drawing.Point(3, 86)
        Me.lblPreStimBreak.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPreStimBreak.Name = "lblPreStimBreak"
        Me.lblPreStimBreak.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPreStimBreak.Size = New System.Drawing.Size(232, 16)
        Me.lblPreStimBreak.TabIndex = 3
        Me.lblPreStimBreak.Text = "Prestimulus break:"
        Me.lblPreStimBreak.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPostStimVisuOffset
        '
        Me.lblPostStimVisuOffset.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPostStimVisuOffset.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPostStimVisuOffset.Location = New System.Drawing.Point(3, 171)
        Me.lblPostStimVisuOffset.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPostStimVisuOffset.Name = "lblPostStimVisuOffset"
        Me.lblPostStimVisuOffset.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPostStimVisuOffset.Size = New System.Drawing.Size(232, 16)
        Me.lblPostStimVisuOffset.TabIndex = 169
        Me.lblPostStimVisuOffset.Text = "Post-Stimulus Visual Offset:"
        Me.lblPostStimVisuOffset.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblStimOffsetU
        '
        Me.lblStimOffsetU.AutoSize = True
        Me.lblStimOffsetU.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStimOffsetU.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStimOffsetU.Location = New System.Drawing.Point(367, 206)
        Me.lblStimOffsetU.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStimOffsetU.Name = "lblStimOffsetU"
        Me.lblStimOffsetU.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStimOffsetU.Size = New System.Drawing.Size(23, 17)
        Me.lblStimOffsetU.TabIndex = 170
        Me.lblStimOffsetU.Text = "us"
        '
        '_lblPreStimBreakU_0
        '
        Me._lblPreStimBreakU_0.AutoSize = True
        Me._lblPreStimBreakU_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPreStimBreakU_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPreStimBreakU.SetIndex(Me._lblPreStimBreakU_0, CType(0, Short))
        Me._lblPreStimBreakU_0.Location = New System.Drawing.Point(324, 87)
        Me._lblPreStimBreakU_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblPreStimBreakU_0.Name = "_lblPreStimBreakU_0"
        Me._lblPreStimBreakU_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPreStimBreakU_0.Size = New System.Drawing.Size(26, 17)
        Me._lblPreStimBreakU_0.TabIndex = 171
        Me._lblPreStimBreakU_0.Text = "ms"
        '
        '_lblPreStimVisuOffsetU_1
        '
        Me._lblPreStimVisuOffsetU_1.AutoSize = True
        Me._lblPreStimVisuOffsetU_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPreStimVisuOffsetU_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPreStimVisuOffsetU.SetIndex(Me._lblPreStimVisuOffsetU_1, CType(1, Short))
        Me._lblPreStimVisuOffsetU_1.Location = New System.Drawing.Point(324, 112)
        Me._lblPreStimVisuOffsetU_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblPreStimVisuOffsetU_1.Name = "_lblPreStimVisuOffsetU_1"
        Me._lblPreStimVisuOffsetU_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPreStimVisuOffsetU_1.Size = New System.Drawing.Size(26, 17)
        Me._lblPreStimVisuOffsetU_1.TabIndex = 172
        Me._lblPreStimVisuOffsetU_1.Text = "ms"
        '
        '_lblInterStimBreakU_2
        '
        Me._lblInterStimBreakU_2.AutoSize = True
        Me._lblInterStimBreakU_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblInterStimBreakU_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInterStimBreakU.SetIndex(Me._lblInterStimBreakU_2, CType(2, Short))
        Me._lblInterStimBreakU_2.Location = New System.Drawing.Point(324, 146)
        Me._lblInterStimBreakU_2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblInterStimBreakU_2.Name = "_lblInterStimBreakU_2"
        Me._lblInterStimBreakU_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblInterStimBreakU_2.Size = New System.Drawing.Size(26, 17)
        Me._lblInterStimBreakU_2.TabIndex = 173
        Me._lblInterStimBreakU_2.Text = "ms"
        '
        '_lblPostStimVisuOffsetU_3
        '
        Me._lblPostStimVisuOffsetU_3.AutoSize = True
        Me._lblPostStimVisuOffsetU_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblPostStimVisuOffsetU_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPostStimVisuOffsetU.SetIndex(Me._lblPostStimVisuOffsetU_3, CType(3, Short))
        Me._lblPostStimVisuOffsetU_3.Location = New System.Drawing.Point(324, 171)
        Me._lblPostStimVisuOffsetU_3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblPostStimVisuOffsetU_3.Name = "_lblPostStimVisuOffsetU_3"
        Me._lblPostStimVisuOffsetU_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblPostStimVisuOffsetU_3.Size = New System.Drawing.Size(26, 17)
        Me._lblPostStimVisuOffsetU_3.TabIndex = 174
        Me._lblPostStimVisuOffsetU_3.Text = "ms"
        '
        'chkBreak
        '
        Me.chkBreak.CausesValidation = False
        Me.chkBreak.Checked = True
        Me.chkBreak.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBreak.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkBreak.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkBreak.Location = New System.Drawing.Point(87, 332)
        Me.chkBreak.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkBreak.Name = "chkBreak"
        Me.chkBreak.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkBreak.Size = New System.Drawing.Size(156, 23)
        Me.chkBreak.TabIndex = 137
        Me.chkBreak.Text = "Make a break after "
        Me.chkBreak.UseVisualStyleBackColor = False
        '
        'tabVariables
        '
        Me.tabVariables.Controls.Add(Me.SplitContainer2)
        Me.tabVariables.Location = New System.Drawing.Point(4, 40)
        Me.tabVariables.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabVariables.Name = "tabVariables"
        Me.tabVariables.Size = New System.Drawing.Size(688, 539)
        Me.tabVariables.TabIndex = 8
        Me.tabVariables.Text = "Variables"
        Me.tabVariables.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.Location = New System.Drawing.Point(4, 4)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtVariablesDescr)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label22)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbVariables)
        Me.SplitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer2.Size = New System.Drawing.Size(677, 522)
        Me.SplitContainer2.SplitterDistance = 261
        Me.SplitContainer2.SplitterWidth = 5
        Me.SplitContainer2.TabIndex = 295
        '
        'txtVariablesDescr
        '
        Me.txtVariablesDescr.AcceptsReturn = True
        Me.txtVariablesDescr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVariablesDescr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVariablesDescr.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVariablesDescr.Location = New System.Drawing.Point(16, 134)
        Me.txtVariablesDescr.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtVariablesDescr.MaxLength = 0
        Me.txtVariablesDescr.Multiline = True
        Me.txtVariablesDescr.Name = "txtVariablesDescr"
        Me.txtVariablesDescr.ReadOnly = True
        Me.txtVariablesDescr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVariablesDescr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtVariablesDescr.Size = New System.Drawing.Size(649, 104)
        Me.txtVariablesDescr.TabIndex = 194
        Me.txtVariablesDescr.Text = "Text1"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(4, 10)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label22.Size = New System.Drawing.Size(71, 17)
        Me.Label22.TabIndex = 158
        Me.Label22.Text = "Variables:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbVariables
        '
        Me.cmbVariables.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbVariables.BackColor = System.Drawing.SystemColors.Window
        Me.cmbVariables.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbVariables.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbVariables.ItemHeight = 16
        Me.cmbVariables.Location = New System.Drawing.Point(83, 10)
        Me.cmbVariables.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbVariables.Name = "cmbVariables"
        Me.cmbVariables.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbVariables.Size = New System.Drawing.Size(583, 116)
        Me.cmbVariables.TabIndex = 292
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(8, 4)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtVariables)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbDuplicate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdVariablesPaste)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdVariablesClear)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdVariablesDefault)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdVariablesAdd)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdVariablesBrowse)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdVariablesDir)
        Me.SplitContainer1.Panel1.Controls.Add(Me._lstVariables_0)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdVariablesDown)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdVariablesUp)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdVariablesRemove)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblVarValues)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label50)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtVariablesFlags)
        Me.SplitContainer1.Size = New System.Drawing.Size(665, 249)
        Me.SplitContainer1.SplitterDistance = 411
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 294
        '
        'txtVariables
        '
        Me.txtVariables.AcceptsReturn = True
        Me.txtVariables.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVariables.BackColor = System.Drawing.SystemColors.Window
        Me.txtVariables.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVariables.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVariables.Location = New System.Drawing.Point(8, 7)
        Me.txtVariables.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtVariables.MaxLength = 0
        Me.txtVariables.Name = "txtVariables"
        Me.txtVariables.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVariables.Size = New System.Drawing.Size(302, 22)
        Me.txtVariables.TabIndex = 146
        '
        '_lstVariables_0
        '
        Me._lstVariables_0.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._lstVariables_0.BackColor = System.Drawing.SystemColors.Window
        Me._lstVariables_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lstVariables_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstVariables.SetIndex(Me._lstVariables_0, CType(0, Short))
        Me._lstVariables_0.ItemHeight = 16
        Me._lstVariables_0.Location = New System.Drawing.Point(8, 63)
        Me._lstVariables_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._lstVariables_0.Name = "_lstVariables_0"
        Me._lstVariables_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lstVariables_0.Size = New System.Drawing.Size(259, 180)
        Me._lstVariables_0.TabIndex = 149
        Me._lstVariables_0.Visible = False
        '
        'lblVarValues
        '
        Me.lblVarValues.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblVarValues.AutoSize = True
        Me.lblVarValues.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblVarValues.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblVarValues.Location = New System.Drawing.Point(4, 37)
        Me.lblVarValues.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVarValues.Name = "lblVarValues"
        Me.lblVarValues.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVarValues.Size = New System.Drawing.Size(55, 17)
        Me.lblVarValues.TabIndex = 121
        Me.lblVarValues.Text = "Values:"
        '
        'Label50
        '
        Me.Label50.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label50.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label50.Location = New System.Drawing.Point(8, 37)
        Me.Label50.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label50.Name = "Label50"
        Me.Label50.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label50.Size = New System.Drawing.Size(113, 16)
        Me.Label50.TabIndex = 193
        Me.Label50.Text = "Restrictions:"
        '
        'txtVariablesFlags
        '
        Me.txtVariablesFlags.AcceptsReturn = True
        Me.txtVariablesFlags.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVariablesFlags.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVariablesFlags.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVariablesFlags.Location = New System.Drawing.Point(12, 63)
        Me.txtVariablesFlags.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtVariablesFlags.MaxLength = 0
        Me.txtVariablesFlags.Multiline = True
        Me.txtVariablesFlags.Name = "txtVariablesFlags"
        Me.txtVariablesFlags.ReadOnly = True
        Me.txtVariablesFlags.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVariablesFlags.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtVariablesFlags.Size = New System.Drawing.Size(229, 180)
        Me.txtVariablesFlags.TabIndex = 195
        Me.txtVariablesFlags.Text = "Text1"
        '
        'tabConstants
        '
        Me.tabConstants.AutoScroll = True
        Me.tabConstants.Controls.Add(Me._cmdConstCmd_0)
        Me.tabConstants.Controls.Add(Me._txtConstValue_0)
        Me.tabConstants.Controls.Add(Me._lblConstUnit_0)
        Me.tabConstants.Controls.Add(Me._lblConstName_0)
        Me.tabConstants.Location = New System.Drawing.Point(4, 40)
        Me.tabConstants.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabConstants.Name = "tabConstants"
        Me.tabConstants.Size = New System.Drawing.Size(688, 539)
        Me.tabConstants.TabIndex = 9
        Me.tabConstants.Text = "Constants"
        Me.tabConstants.UseVisualStyleBackColor = True
        '
        '_txtConstValue_0
        '
        Me._txtConstValue_0.AcceptsReturn = True
        Me._txtConstValue_0.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._txtConstValue_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtConstValue_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtConstValue_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtConstValue.SetIndex(Me._txtConstValue_0, CType(0, Short))
        Me._txtConstValue_0.Location = New System.Drawing.Point(307, 26)
        Me._txtConstValue_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._txtConstValue_0.MaxLength = 0
        Me._txtConstValue_0.MinimumSize = New System.Drawing.Size(52, 4)
        Me._txtConstValue_0.Name = "_txtConstValue_0"
        Me._txtConstValue_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtConstValue_0.Size = New System.Drawing.Size(200, 22)
        Me._txtConstValue_0.TabIndex = 167
        Me._txtConstValue_0.Text = "value"
        '
        '_lblConstUnit_0
        '
        Me._lblConstUnit_0.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._lblConstUnit_0.AutoSize = True
        Me._lblConstUnit_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblConstUnit_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblConstUnit.SetIndex(Me._lblConstUnit_0, CType(0, Short))
        Me._lblConstUnit_0.Location = New System.Drawing.Point(551, 30)
        Me._lblConstUnit_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblConstUnit_0.Name = "_lblConstUnit_0"
        Me._lblConstUnit_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblConstUnit_0.Size = New System.Drawing.Size(38, 17)
        Me._lblConstUnit_0.TabIndex = 168
        Me._lblConstUnit_0.Text = "units"
        '
        '_lblConstName_0
        '
        Me._lblConstName_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblConstName_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblConstName.SetIndex(Me._lblConstName_0, CType(0, Short))
        Me._lblConstName_0.Location = New System.Drawing.Point(25, 30)
        Me._lblConstName_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblConstName_0.Name = "_lblConstName_0"
        Me._lblConstName_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblConstName_0.Size = New System.Drawing.Size(273, 17)
        Me._lblConstName_0.TabIndex = 166
        Me._lblConstName_0.Text = "constant name:"
        Me._lblConstName_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tabTracker
        '
        Me.tabTracker.Controls.Add(Me.fraTrackerSettings)
        Me.tabTracker.Controls.Add(Me._fraTrackerSensor_0)
        Me.tabTracker.Controls.Add(Me._fraTrackerSensor_1)
        Me.tabTracker.Controls.Add(Me.chkTrackerSaveData)
        Me.tabTracker.Location = New System.Drawing.Point(4, 40)
        Me.tabTracker.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabTracker.Name = "tabTracker"
        Me.tabTracker.Size = New System.Drawing.Size(688, 539)
        Me.tabTracker.TabIndex = 10
        Me.tabTracker.Text = "Tracker"
        Me.tabTracker.UseVisualStyleBackColor = True
        '
        'fraTrackerSettings
        '
        Me.fraTrackerSettings.Controls.Add(Me.cmbTrackerRepRate)
        Me.fraTrackerSettings.Controls.Add(Me.cmbTrackerPosScaling)
        Me.fraTrackerSettings.Controls.Add(Me.chkTrackerUse)
        Me.fraTrackerSettings.Controls.Add(Me.lblTrackerTimeOut)
        Me.fraTrackerSettings.Controls.Add(Me.lblTrackerUse)
        Me.fraTrackerSettings.Controls.Add(Me.lblTrackerRepRate)
        Me.fraTrackerSettings.Controls.Add(Me.lblTrackerPosScaling)
        Me.fraTrackerSettings.Controls.Add(Me.lblTrackerRepRateUnits)
        Me.fraTrackerSettings.Controls.Add(Me.lblTrackerPosScalingUnits)
        Me.fraTrackerSettings.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraTrackerSettings.Location = New System.Drawing.Point(19, 25)
        Me.fraTrackerSettings.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraTrackerSettings.Name = "fraTrackerSettings"
        Me.fraTrackerSettings.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fraTrackerSettings.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraTrackerSettings.Size = New System.Drawing.Size(611, 90)
        Me.fraTrackerSettings.TabIndex = 237
        Me.fraTrackerSettings.TabStop = False
        '
        'cmbTrackerRepRate
        '
        Me.cmbTrackerRepRate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTrackerRepRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTrackerRepRate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbTrackerRepRate.Location = New System.Drawing.Point(123, 34)
        Me.cmbTrackerRepRate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbTrackerRepRate.Name = "cmbTrackerRepRate"
        Me.cmbTrackerRepRate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbTrackerRepRate.Size = New System.Drawing.Size(64, 24)
        Me.cmbTrackerRepRate.TabIndex = 240
        '
        'cmbTrackerPosScaling
        '
        Me.cmbTrackerPosScaling.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTrackerPosScaling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTrackerPosScaling.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbTrackerPosScaling.Location = New System.Drawing.Point(400, 34)
        Me.cmbTrackerPosScaling.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbTrackerPosScaling.Name = "cmbTrackerPosScaling"
        Me.cmbTrackerPosScaling.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbTrackerPosScaling.Size = New System.Drawing.Size(69, 24)
        Me.cmbTrackerPosScaling.TabIndex = 239
        '
        'chkTrackerUse
        '
        Me.chkTrackerUse.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkTrackerUse.Location = New System.Drawing.Point(21, 0)
        Me.chkTrackerUse.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkTrackerUse.Name = "chkTrackerUse"
        Me.chkTrackerUse.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkTrackerUse.Size = New System.Drawing.Size(119, 21)
        Me.chkTrackerUse.TabIndex = 238
        Me.chkTrackerUse.Text = "Use Tracker"
        Me.chkTrackerUse.UseVisualStyleBackColor = False
        '
        'lblTrackerTimeOut
        '
        Me.lblTrackerTimeOut.AutoSize = True
        Me.lblTrackerTimeOut.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTrackerTimeOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrackerTimeOut.ForeColor = System.Drawing.Color.Red
        Me.lblTrackerTimeOut.Location = New System.Drawing.Point(224, 64)
        Me.lblTrackerTimeOut.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTrackerTimeOut.Name = "lblTrackerTimeOut"
        Me.lblTrackerTimeOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTrackerTimeOut.Size = New System.Drawing.Size(74, 17)
        Me.lblTrackerTimeOut.TabIndex = 274
        Me.lblTrackerTimeOut.Text = "Time Out"
        Me.lblTrackerTimeOut.Visible = False
        '
        'lblTrackerUse
        '
        Me.lblTrackerUse.BackColor = System.Drawing.SystemColors.Control
        Me.lblTrackerUse.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTrackerUse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerUse.Location = New System.Drawing.Point(11, 0)
        Me.lblTrackerUse.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTrackerUse.Name = "lblTrackerUse"
        Me.lblTrackerUse.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTrackerUse.Size = New System.Drawing.Size(44, 21)
        Me.lblTrackerUse.TabIndex = 273
        Me.lblTrackerUse.Text = "      "
        '
        'lblTrackerRepRate
        '
        Me.lblTrackerRepRate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTrackerRepRate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerRepRate.Location = New System.Drawing.Point(11, 39)
        Me.lblTrackerRepRate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTrackerRepRate.Name = "lblTrackerRepRate"
        Me.lblTrackerRepRate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTrackerRepRate.Size = New System.Drawing.Size(103, 16)
        Me.lblTrackerRepRate.TabIndex = 244
        Me.lblTrackerRepRate.Text = "Repetition Rate:"
        Me.lblTrackerRepRate.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTrackerPosScaling
        '
        Me.lblTrackerPosScaling.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTrackerPosScaling.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerPosScaling.Location = New System.Drawing.Point(288, 39)
        Me.lblTrackerPosScaling.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTrackerPosScaling.Name = "lblTrackerPosScaling"
        Me.lblTrackerPosScaling.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTrackerPosScaling.Size = New System.Drawing.Size(104, 16)
        Me.lblTrackerPosScaling.TabIndex = 243
        Me.lblTrackerPosScaling.Text = "Position Scaling:"
        Me.lblTrackerPosScaling.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTrackerRepRateUnits
        '
        Me.lblTrackerRepRateUnits.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTrackerRepRateUnits.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerRepRateUnits.Location = New System.Drawing.Point(192, 39)
        Me.lblTrackerRepRateUnits.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTrackerRepRateUnits.Name = "lblTrackerRepRateUnits"
        Me.lblTrackerRepRateUnits.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTrackerRepRateUnits.Size = New System.Drawing.Size(109, 16)
        Me.lblTrackerRepRateUnits.TabIndex = 242
        Me.lblTrackerRepRateUnits.Text = "values/s:"
        '
        'lblTrackerPosScalingUnits
        '
        Me.lblTrackerPosScalingUnits.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTrackerPosScalingUnits.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerPosScalingUnits.Location = New System.Drawing.Point(475, 39)
        Me.lblTrackerPosScalingUnits.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTrackerPosScalingUnits.Name = "lblTrackerPosScalingUnits"
        Me.lblTrackerPosScalingUnits.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTrackerPosScalingUnits.Size = New System.Drawing.Size(60, 16)
        Me.lblTrackerPosScalingUnits.TabIndex = 241
        Me.lblTrackerPosScalingUnits.Text = "inch"
        '
        '_fraTrackerSensor_0
        '
        Me._fraTrackerSensor_0.Controls.Add(Me._lblTrackerR_Range_0)
        Me._fraTrackerSensor_0.Controls.Add(Me._lblTrackerY_Range_0)
        Me._fraTrackerSensor_0.Controls.Add(Me._lblTrackerZ_Range_0)
        Me._fraTrackerSensor_0.Controls.Add(Me._lblTrackerX_Range_0)
        Me._fraTrackerSensor_0.Controls.Add(Me._lblTrackerE_Range_0)
        Me._fraTrackerSensor_0.Controls.Add(Me._lblTrackerA_Range_0)
        Me._fraTrackerSensor_0.Controls.Add(Me._cmdTrackerSetOffset_0)
        Me._fraTrackerSensor_0.Controls.Add(Me._cmdTrackerSetValues_0)
        Me._fraTrackerSensor_0.Controls.Add(Me._lblTrackerR_0)
        Me._fraTrackerSensor_0.Controls.Add(Me._lblTrackerE_0)
        Me._fraTrackerSensor_0.Controls.Add(Me._lblTrackerA_0)
        Me._fraTrackerSensor_0.Controls.Add(Me._lblTrackerZ_0)
        Me._fraTrackerSensor_0.Controls.Add(Me._lblTrackerY_0)
        Me._fraTrackerSensor_0.Controls.Add(Me._lblTrackerLabR_0)
        Me._fraTrackerSensor_0.Controls.Add(Me._lblTrackerLabE_0)
        Me._fraTrackerSensor_0.Controls.Add(Me._lblTrackerLabZ_0)
        Me._fraTrackerSensor_0.Controls.Add(Me._lblTrackerLabY_0)
        Me._fraTrackerSensor_0.Controls.Add(Me._lblTrackerX_0)
        Me._fraTrackerSensor_0.Controls.Add(Me._lblTrackerLabA_0)
        Me._fraTrackerSensor_0.Controls.Add(Me._lblTrackerLabX_0)
        Me._fraTrackerSensor_0.Enabled = False
        Me._fraTrackerSensor_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraTrackerSensor.SetIndex(Me._fraTrackerSensor_0, CType(0, Short))
        Me._fraTrackerSensor_0.Location = New System.Drawing.Point(19, 153)
        Me._fraTrackerSensor_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._fraTrackerSensor_0.Name = "_fraTrackerSensor_0"
        Me._fraTrackerSensor_0.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._fraTrackerSensor_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraTrackerSensor_0.Size = New System.Drawing.Size(611, 95)
        Me._fraTrackerSensor_0.TabIndex = 245
        Me._fraTrackerSensor_0.TabStop = False
        Me._fraTrackerSensor_0.Text = "Sensor 0:"
        '
        '_lblTrackerR_Range_0
        '
        Me._lblTrackerR_Range_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerR_Range_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerR_Range_0.ForeColor = System.Drawing.Color.Gray
        Me.lblTrackerRRange.SetIndex(Me._lblTrackerR_Range_0, CType(0, Short))
        Me._lblTrackerR_Range_0.Location = New System.Drawing.Point(359, 70)
        Me._lblTrackerR_Range_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerR_Range_0.Name = "_lblTrackerR_Range_0"
        Me._lblTrackerR_Range_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerR_Range_0.Size = New System.Drawing.Size(71, 16)
        Me._lblTrackerR_Range_0.TabIndex = 292
        Me._lblTrackerR_Range_0.Text = "0"
        Me._lblTrackerR_Range_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerY_Range_0
        '
        Me._lblTrackerY_Range_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerY_Range_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerY_Range_0.ForeColor = System.Drawing.Color.Gray
        Me.lblTrackerYRange.SetIndex(Me._lblTrackerY_Range_0, CType(0, Short))
        Me._lblTrackerY_Range_0.Location = New System.Drawing.Point(61, 70)
        Me._lblTrackerY_Range_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerY_Range_0.Name = "_lblTrackerY_Range_0"
        Me._lblTrackerY_Range_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerY_Range_0.Size = New System.Drawing.Size(71, 16)
        Me._lblTrackerY_Range_0.TabIndex = 293
        Me._lblTrackerY_Range_0.Text = "0"
        Me._lblTrackerY_Range_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerZ_Range_0
        '
        Me._lblTrackerZ_Range_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerZ_Range_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerZ_Range_0.ForeColor = System.Drawing.Color.Gray
        Me.lblTrackerZRange.SetIndex(Me._lblTrackerZ_Range_0, CType(0, Short))
        Me._lblTrackerZ_Range_0.Location = New System.Drawing.Point(116, 70)
        Me._lblTrackerZ_Range_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerZ_Range_0.Name = "_lblTrackerZ_Range_0"
        Me._lblTrackerZ_Range_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerZ_Range_0.Size = New System.Drawing.Size(71, 16)
        Me._lblTrackerZ_Range_0.TabIndex = 292
        Me._lblTrackerZ_Range_0.Text = "0"
        Me._lblTrackerZ_Range_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerX_Range_0
        '
        Me._lblTrackerX_Range_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerX_Range_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerX_Range_0.ForeColor = System.Drawing.Color.Gray
        Me.lblTrackerXRange.SetIndex(Me._lblTrackerX_Range_0, CType(0, Short))
        Me._lblTrackerX_Range_0.Location = New System.Drawing.Point(8, 70)
        Me._lblTrackerX_Range_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerX_Range_0.Name = "_lblTrackerX_Range_0"
        Me._lblTrackerX_Range_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerX_Range_0.Size = New System.Drawing.Size(71, 16)
        Me._lblTrackerX_Range_0.TabIndex = 291
        Me._lblTrackerX_Range_0.Text = "0"
        Me._lblTrackerX_Range_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerE_Range_0
        '
        Me._lblTrackerE_Range_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerE_Range_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerE_Range_0.ForeColor = System.Drawing.Color.Gray
        Me.lblTrackerERange.SetIndex(Me._lblTrackerE_Range_0, CType(0, Short))
        Me._lblTrackerE_Range_0.Location = New System.Drawing.Point(291, 70)
        Me._lblTrackerE_Range_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerE_Range_0.Name = "_lblTrackerE_Range_0"
        Me._lblTrackerE_Range_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerE_Range_0.Size = New System.Drawing.Size(71, 16)
        Me._lblTrackerE_Range_0.TabIndex = 290
        Me._lblTrackerE_Range_0.Text = "0"
        Me._lblTrackerE_Range_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerA_Range_0
        '
        Me._lblTrackerA_Range_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerA_Range_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerA_Range_0.ForeColor = System.Drawing.Color.Gray
        Me.lblTrackerARange.SetIndex(Me._lblTrackerA_Range_0, CType(0, Short))
        Me._lblTrackerA_Range_0.Location = New System.Drawing.Point(209, 70)
        Me._lblTrackerA_Range_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerA_Range_0.Name = "_lblTrackerA_Range_0"
        Me._lblTrackerA_Range_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerA_Range_0.Size = New System.Drawing.Size(71, 16)
        Me._lblTrackerA_Range_0.TabIndex = 289
        Me._lblTrackerA_Range_0.Text = "0"
        Me._lblTrackerA_Range_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_cmdTrackerSetOffset_0
        '
        Me._cmdTrackerSetOffset_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdTrackerSetOffset_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdTrackerSetOffset.SetIndex(Me._cmdTrackerSetOffset_0, CType(0, Short))
        Me._cmdTrackerSetOffset_0.Location = New System.Drawing.Point(479, 49)
        Me._cmdTrackerSetOffset_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._cmdTrackerSetOffset_0.Name = "_cmdTrackerSetOffset_0"
        Me._cmdTrackerSetOffset_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdTrackerSetOffset_0.Size = New System.Drawing.Size(100, 26)
        Me._cmdTrackerSetOffset_0.TabIndex = 288
        Me._cmdTrackerSetOffset_0.Text = "Set Offset..."
        Me._cmdTrackerSetOffset_0.UseVisualStyleBackColor = False
        '
        '_cmdTrackerSetValues_0
        '
        Me._cmdTrackerSetValues_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdTrackerSetValues_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdTrackerSetValues.SetIndex(Me._cmdTrackerSetValues_0, CType(0, Short))
        Me._cmdTrackerSetValues_0.Location = New System.Drawing.Point(479, 20)
        Me._cmdTrackerSetValues_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._cmdTrackerSetValues_0.Name = "_cmdTrackerSetValues_0"
        Me._cmdTrackerSetValues_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdTrackerSetValues_0.Size = New System.Drawing.Size(100, 26)
        Me._cmdTrackerSetValues_0.TabIndex = 247
        Me._cmdTrackerSetValues_0.Text = "Set Values..."
        Me._cmdTrackerSetValues_0.UseVisualStyleBackColor = False
        '
        '_lblTrackerLabR_0
        '
        Me._lblTrackerLabR_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerLabR_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerLabR_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerLabR.SetIndex(Me._lblTrackerLabR_0, CType(0, Short))
        Me._lblTrackerLabR_0.Location = New System.Drawing.Point(372, 25)
        Me._lblTrackerLabR_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerLabR_0.Name = "_lblTrackerLabR_0"
        Me._lblTrackerLabR_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerLabR_0.Size = New System.Drawing.Size(41, 16)
        Me._lblTrackerLabR_0.TabIndex = 253
        Me._lblTrackerLabR_0.Text = "Roll"
        Me._lblTrackerLabR_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerLabE_0
        '
        Me._lblTrackerLabE_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerLabE_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerLabE_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerLabE.SetIndex(Me._lblTrackerLabE_0, CType(0, Short))
        Me._lblTrackerLabE_0.Location = New System.Drawing.Point(287, 25)
        Me._lblTrackerLabE_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerLabE_0.Name = "_lblTrackerLabE_0"
        Me._lblTrackerLabE_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerLabE_0.Size = New System.Drawing.Size(85, 16)
        Me._lblTrackerLabE_0.TabIndex = 252
        Me._lblTrackerLabE_0.Text = "Elevation"
        Me._lblTrackerLabE_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerLabZ_0
        '
        Me._lblTrackerLabZ_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerLabZ_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerLabZ_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerLabZ.SetIndex(Me._lblTrackerLabZ_0, CType(0, Short))
        Me._lblTrackerLabZ_0.Location = New System.Drawing.Point(129, 25)
        Me._lblTrackerLabZ_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerLabZ_0.Name = "_lblTrackerLabZ_0"
        Me._lblTrackerLabZ_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerLabZ_0.Size = New System.Drawing.Size(44, 16)
        Me._lblTrackerLabZ_0.TabIndex = 251
        Me._lblTrackerLabZ_0.Text = "Z"
        Me._lblTrackerLabZ_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerLabY_0
        '
        Me._lblTrackerLabY_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerLabY_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerLabY_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerLabY.SetIndex(Me._lblTrackerLabY_0, CType(0, Short))
        Me._lblTrackerLabY_0.Location = New System.Drawing.Point(75, 25)
        Me._lblTrackerLabY_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerLabY_0.Name = "_lblTrackerLabY_0"
        Me._lblTrackerLabY_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerLabY_0.Size = New System.Drawing.Size(44, 16)
        Me._lblTrackerLabY_0.TabIndex = 250
        Me._lblTrackerLabY_0.Text = "Y"
        Me._lblTrackerLabY_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerLabA_0
        '
        Me._lblTrackerLabA_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerLabA_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerLabA_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerLabA.SetIndex(Me._lblTrackerLabA_0, CType(0, Short))
        Me._lblTrackerLabA_0.Location = New System.Drawing.Point(208, 25)
        Me._lblTrackerLabA_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerLabA_0.Name = "_lblTrackerLabA_0"
        Me._lblTrackerLabA_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerLabA_0.Size = New System.Drawing.Size(77, 21)
        Me._lblTrackerLabA_0.TabIndex = 248
        Me._lblTrackerLabA_0.Text = "Azimuth"
        Me._lblTrackerLabA_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerLabX_0
        '
        Me._lblTrackerLabX_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerLabX_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerLabX_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerLabX.SetIndex(Me._lblTrackerLabX_0, CType(0, Short))
        Me._lblTrackerLabX_0.Location = New System.Drawing.Point(21, 25)
        Me._lblTrackerLabX_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerLabX_0.Name = "_lblTrackerLabX_0"
        Me._lblTrackerLabX_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerLabX_0.Size = New System.Drawing.Size(44, 16)
        Me._lblTrackerLabX_0.TabIndex = 246
        Me._lblTrackerLabX_0.Text = "X"
        Me._lblTrackerLabX_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_fraTrackerSensor_1
        '
        Me._fraTrackerSensor_1.Controls.Add(Me._lblTrackerR_Range_1)
        Me._fraTrackerSensor_1.Controls.Add(Me._lblTrackerY_Range_1)
        Me._fraTrackerSensor_1.Controls.Add(Me._lblTrackerZ_Range_1)
        Me._fraTrackerSensor_1.Controls.Add(Me._lblTrackerX_Range_1)
        Me._fraTrackerSensor_1.Controls.Add(Me._lblTrackerE_Range_1)
        Me._fraTrackerSensor_1.Controls.Add(Me._lblTrackerA_Range_1)
        Me._fraTrackerSensor_1.Controls.Add(Me._cmdTrackerSetOffset_1)
        Me._fraTrackerSensor_1.Controls.Add(Me._cmdTrackerSetValues_1)
        Me._fraTrackerSensor_1.Controls.Add(Me._lblTrackerLabX_1)
        Me._fraTrackerSensor_1.Controls.Add(Me._lblTrackerLabA_1)
        Me._fraTrackerSensor_1.Controls.Add(Me._lblTrackerX_1)
        Me._fraTrackerSensor_1.Controls.Add(Me._lblTrackerLabY_1)
        Me._fraTrackerSensor_1.Controls.Add(Me._lblTrackerLabZ_1)
        Me._fraTrackerSensor_1.Controls.Add(Me._lblTrackerLabE_1)
        Me._fraTrackerSensor_1.Controls.Add(Me._lblTrackerLabR_1)
        Me._fraTrackerSensor_1.Controls.Add(Me._lblTrackerY_1)
        Me._fraTrackerSensor_1.Controls.Add(Me._lblTrackerZ_1)
        Me._fraTrackerSensor_1.Controls.Add(Me._lblTrackerA_1)
        Me._fraTrackerSensor_1.Controls.Add(Me._lblTrackerE_1)
        Me._fraTrackerSensor_1.Controls.Add(Me._lblTrackerR_1)
        Me._fraTrackerSensor_1.Enabled = False
        Me._fraTrackerSensor_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraTrackerSensor.SetIndex(Me._fraTrackerSensor_1, CType(1, Short))
        Me._fraTrackerSensor_1.Location = New System.Drawing.Point(19, 251)
        Me._fraTrackerSensor_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._fraTrackerSensor_1.Name = "_fraTrackerSensor_1"
        Me._fraTrackerSensor_1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._fraTrackerSensor_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraTrackerSensor_1.Size = New System.Drawing.Size(611, 95)
        Me._fraTrackerSensor_1.TabIndex = 259
        Me._fraTrackerSensor_1.TabStop = False
        Me._fraTrackerSensor_1.Text = "Sensor 1:"
        '
        '_lblTrackerR_Range_1
        '
        Me._lblTrackerR_Range_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerR_Range_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerR_Range_1.ForeColor = System.Drawing.Color.Gray
        Me.lblTrackerRRange.SetIndex(Me._lblTrackerR_Range_1, CType(1, Short))
        Me._lblTrackerR_Range_1.Location = New System.Drawing.Point(359, 70)
        Me._lblTrackerR_Range_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerR_Range_1.Name = "_lblTrackerR_Range_1"
        Me._lblTrackerR_Range_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerR_Range_1.Size = New System.Drawing.Size(71, 16)
        Me._lblTrackerR_Range_1.TabIndex = 297
        Me._lblTrackerR_Range_1.Text = "0"
        Me._lblTrackerR_Range_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerY_Range_1
        '
        Me._lblTrackerY_Range_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerY_Range_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerY_Range_1.ForeColor = System.Drawing.Color.Gray
        Me.lblTrackerYRange.SetIndex(Me._lblTrackerY_Range_1, CType(1, Short))
        Me._lblTrackerY_Range_1.Location = New System.Drawing.Point(61, 70)
        Me._lblTrackerY_Range_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerY_Range_1.Name = "_lblTrackerY_Range_1"
        Me._lblTrackerY_Range_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerY_Range_1.Size = New System.Drawing.Size(71, 16)
        Me._lblTrackerY_Range_1.TabIndex = 299
        Me._lblTrackerY_Range_1.Text = "0"
        Me._lblTrackerY_Range_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerZ_Range_1
        '
        Me._lblTrackerZ_Range_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerZ_Range_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerZ_Range_1.ForeColor = System.Drawing.Color.Gray
        Me.lblTrackerZRange.SetIndex(Me._lblTrackerZ_Range_1, CType(1, Short))
        Me._lblTrackerZ_Range_1.Location = New System.Drawing.Point(116, 70)
        Me._lblTrackerZ_Range_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerZ_Range_1.Name = "_lblTrackerZ_Range_1"
        Me._lblTrackerZ_Range_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerZ_Range_1.Size = New System.Drawing.Size(71, 16)
        Me._lblTrackerZ_Range_1.TabIndex = 298
        Me._lblTrackerZ_Range_1.Text = "0"
        Me._lblTrackerZ_Range_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerX_Range_1
        '
        Me._lblTrackerX_Range_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerX_Range_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerX_Range_1.ForeColor = System.Drawing.Color.Gray
        Me.lblTrackerXRange.SetIndex(Me._lblTrackerX_Range_1, CType(1, Short))
        Me._lblTrackerX_Range_1.Location = New System.Drawing.Point(8, 70)
        Me._lblTrackerX_Range_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerX_Range_1.Name = "_lblTrackerX_Range_1"
        Me._lblTrackerX_Range_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerX_Range_1.Size = New System.Drawing.Size(71, 16)
        Me._lblTrackerX_Range_1.TabIndex = 296
        Me._lblTrackerX_Range_1.Text = "0"
        Me._lblTrackerX_Range_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerE_Range_1
        '
        Me._lblTrackerE_Range_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerE_Range_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerE_Range_1.ForeColor = System.Drawing.Color.Gray
        Me.lblTrackerERange.SetIndex(Me._lblTrackerE_Range_1, CType(1, Short))
        Me._lblTrackerE_Range_1.Location = New System.Drawing.Point(291, 70)
        Me._lblTrackerE_Range_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerE_Range_1.Name = "_lblTrackerE_Range_1"
        Me._lblTrackerE_Range_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerE_Range_1.Size = New System.Drawing.Size(71, 16)
        Me._lblTrackerE_Range_1.TabIndex = 295
        Me._lblTrackerE_Range_1.Text = "0"
        Me._lblTrackerE_Range_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerA_Range_1
        '
        Me._lblTrackerA_Range_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerA_Range_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerA_Range_1.ForeColor = System.Drawing.Color.Gray
        Me.lblTrackerARange.SetIndex(Me._lblTrackerA_Range_1, CType(1, Short))
        Me._lblTrackerA_Range_1.Location = New System.Drawing.Point(209, 70)
        Me._lblTrackerA_Range_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerA_Range_1.Name = "_lblTrackerA_Range_1"
        Me._lblTrackerA_Range_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerA_Range_1.Size = New System.Drawing.Size(71, 16)
        Me._lblTrackerA_Range_1.TabIndex = 294
        Me._lblTrackerA_Range_1.Text = "0"
        Me._lblTrackerA_Range_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_cmdTrackerSetOffset_1
        '
        Me._cmdTrackerSetOffset_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdTrackerSetOffset_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdTrackerSetOffset.SetIndex(Me._cmdTrackerSetOffset_1, CType(1, Short))
        Me._cmdTrackerSetOffset_1.Location = New System.Drawing.Point(479, 49)
        Me._cmdTrackerSetOffset_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._cmdTrackerSetOffset_1.Name = "_cmdTrackerSetOffset_1"
        Me._cmdTrackerSetOffset_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdTrackerSetOffset_1.Size = New System.Drawing.Size(100, 26)
        Me._cmdTrackerSetOffset_1.TabIndex = 287
        Me._cmdTrackerSetOffset_1.Text = "Set Offset..."
        Me._cmdTrackerSetOffset_1.UseVisualStyleBackColor = False
        '
        '_cmdTrackerSetValues_1
        '
        Me._cmdTrackerSetValues_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdTrackerSetValues_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdTrackerSetValues.SetIndex(Me._cmdTrackerSetValues_1, CType(1, Short))
        Me._cmdTrackerSetValues_1.Location = New System.Drawing.Point(479, 20)
        Me._cmdTrackerSetValues_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._cmdTrackerSetValues_1.Name = "_cmdTrackerSetValues_1"
        Me._cmdTrackerSetValues_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdTrackerSetValues_1.Size = New System.Drawing.Size(100, 26)
        Me._cmdTrackerSetValues_1.TabIndex = 260
        Me._cmdTrackerSetValues_1.Text = "Set Values..."
        Me._cmdTrackerSetValues_1.UseVisualStyleBackColor = False
        '
        '_lblTrackerLabX_1
        '
        Me._lblTrackerLabX_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerLabX_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerLabX_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerLabX.SetIndex(Me._lblTrackerLabX_1, CType(1, Short))
        Me._lblTrackerLabX_1.Location = New System.Drawing.Point(21, 25)
        Me._lblTrackerLabX_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerLabX_1.Name = "_lblTrackerLabX_1"
        Me._lblTrackerLabX_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerLabX_1.Size = New System.Drawing.Size(44, 16)
        Me._lblTrackerLabX_1.TabIndex = 272
        Me._lblTrackerLabX_1.Text = "X"
        Me._lblTrackerLabX_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerLabA_1
        '
        Me._lblTrackerLabA_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerLabA_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerLabA_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerLabA.SetIndex(Me._lblTrackerLabA_1, CType(1, Short))
        Me._lblTrackerLabA_1.Location = New System.Drawing.Point(208, 25)
        Me._lblTrackerLabA_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerLabA_1.Name = "_lblTrackerLabA_1"
        Me._lblTrackerLabA_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerLabA_1.Size = New System.Drawing.Size(77, 16)
        Me._lblTrackerLabA_1.TabIndex = 271
        Me._lblTrackerLabA_1.Text = "Azimuth"
        Me._lblTrackerLabA_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerLabY_1
        '
        Me._lblTrackerLabY_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerLabY_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerLabY_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerLabY.SetIndex(Me._lblTrackerLabY_1, CType(1, Short))
        Me._lblTrackerLabY_1.Location = New System.Drawing.Point(75, 25)
        Me._lblTrackerLabY_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerLabY_1.Name = "_lblTrackerLabY_1"
        Me._lblTrackerLabY_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerLabY_1.Size = New System.Drawing.Size(44, 16)
        Me._lblTrackerLabY_1.TabIndex = 269
        Me._lblTrackerLabY_1.Text = "Y"
        Me._lblTrackerLabY_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerLabZ_1
        '
        Me._lblTrackerLabZ_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerLabZ_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerLabZ_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerLabZ.SetIndex(Me._lblTrackerLabZ_1, CType(1, Short))
        Me._lblTrackerLabZ_1.Location = New System.Drawing.Point(129, 25)
        Me._lblTrackerLabZ_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerLabZ_1.Name = "_lblTrackerLabZ_1"
        Me._lblTrackerLabZ_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerLabZ_1.Size = New System.Drawing.Size(44, 16)
        Me._lblTrackerLabZ_1.TabIndex = 268
        Me._lblTrackerLabZ_1.Text = "Z"
        Me._lblTrackerLabZ_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerLabE_1
        '
        Me._lblTrackerLabE_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerLabE_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerLabE_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerLabE.SetIndex(Me._lblTrackerLabE_1, CType(1, Short))
        Me._lblTrackerLabE_1.Location = New System.Drawing.Point(291, 25)
        Me._lblTrackerLabE_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerLabE_1.Name = "_lblTrackerLabE_1"
        Me._lblTrackerLabE_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerLabE_1.Size = New System.Drawing.Size(81, 21)
        Me._lblTrackerLabE_1.TabIndex = 267
        Me._lblTrackerLabE_1.Text = "Elevation"
        Me._lblTrackerLabE_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerLabR_1
        '
        Me._lblTrackerLabR_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerLabR_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTrackerLabR_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerLabR.SetIndex(Me._lblTrackerLabR_1, CType(1, Short))
        Me._lblTrackerLabR_1.Location = New System.Drawing.Point(372, 25)
        Me._lblTrackerLabR_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblTrackerLabR_1.Name = "_lblTrackerLabR_1"
        Me._lblTrackerLabR_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerLabR_1.Size = New System.Drawing.Size(41, 21)
        Me._lblTrackerLabR_1.TabIndex = 266
        Me._lblTrackerLabR_1.Text = "Roll"
        Me._lblTrackerLabR_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'chkTrackerSaveData
        '
        Me.chkTrackerSaveData.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkTrackerSaveData.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkTrackerSaveData.Location = New System.Drawing.Point(24, 123)
        Me.chkTrackerSaveData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkTrackerSaveData.Name = "chkTrackerSaveData"
        Me.chkTrackerSaveData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkTrackerSaveData.Size = New System.Drawing.Size(263, 21)
        Me.chkTrackerSaveData.TabIndex = 281
        Me.chkTrackerSaveData.Text = "Save data to a file"
        Me.chkTrackerSaveData.UseVisualStyleBackColor = False
        '
        'tabVirtualWorld
        '
        Me.tabVirtualWorld.Controls.Add(Me._fraViWoParameter_3)
        Me.tabVirtualWorld.Controls.Add(Me._fraViWoParameter_0)
        Me.tabVirtualWorld.Controls.Add(Me._fraViWoParameter_2)
        Me.tabVirtualWorld.Controls.Add(Me._fraViWoParameter_1)
        Me.tabVirtualWorld.Controls.Add(Me._Label8_0)
        Me.tabVirtualWorld.Controls.Add(Me._Label8_1)
        Me.tabVirtualWorld.Controls.Add(Me.chkViWoSendData)
        Me.tabVirtualWorld.Controls.Add(Me.txtViWoAvgHead)
        Me.tabVirtualWorld.Controls.Add(Me.txtViWoAvgPointer)
        Me.tabVirtualWorld.Controls.Add(Me.lstViWoWorlds)
        Me.tabVirtualWorld.Controls.Add(Me.lstViWoParameters)
        Me.tabVirtualWorld.Controls.Add(Me._cmdViWoSendParameters_0)
        Me.tabVirtualWorld.Controls.Add(Me._cmdViWoSendParameters_1)
        Me.tabVirtualWorld.Location = New System.Drawing.Point(4, 40)
        Me.tabVirtualWorld.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabVirtualWorld.Name = "tabVirtualWorld"
        Me.tabVirtualWorld.Size = New System.Drawing.Size(688, 539)
        Me.tabVirtualWorld.TabIndex = 11
        Me.tabVirtualWorld.Text = "ViWo"
        Me.tabVirtualWorld.UseVisualStyleBackColor = True
        '
        '_fraViWoParameter_3
        '
        Me._fraViWoParameter_3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._fraViWoParameter_3.Controls.Add(Me._txtViWoPar_0)
        Me._fraViWoParameter_3.Controls.Add(Me._txtViWoPar_3)
        Me._fraViWoParameter_3.Controls.Add(Me._txtViWoPar_2)
        Me._fraViWoParameter_3.Controls.Add(Me._txtViWoPar_1)
        Me._fraViWoParameter_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraViWoParameter.SetIndex(Me._fraViWoParameter_3, CType(3, Short))
        Me._fraViWoParameter_3.Location = New System.Drawing.Point(380, 209)
        Me._fraViWoParameter_3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._fraViWoParameter_3.Name = "_fraViWoParameter_3"
        Me._fraViWoParameter_3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._fraViWoParameter_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraViWoParameter_3.Size = New System.Drawing.Size(241, 144)
        Me._fraViWoParameter_3.TabIndex = 305
        Me._fraViWoParameter_3.TabStop = False
        Me._fraViWoParameter_3.Text = "Parameters:"
        '
        '_txtViWoPar_0
        '
        Me._txtViWoPar_0.AcceptsReturn = True
        Me._txtViWoPar_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtViWoPar_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtViWoPar_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtViWoPar.SetIndex(Me._txtViWoPar_0, CType(0, Short))
        Me._txtViWoPar_0.Location = New System.Drawing.Point(75, 20)
        Me._txtViWoPar_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._txtViWoPar_0.MaxLength = 0
        Me._txtViWoPar_0.Name = "_txtViWoPar_0"
        Me._txtViWoPar_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtViWoPar_0.Size = New System.Drawing.Size(101, 22)
        Me._txtViWoPar_0.TabIndex = 302
        '
        '_txtViWoPar_3
        '
        Me._txtViWoPar_3.AcceptsReturn = True
        Me._txtViWoPar_3.BackColor = System.Drawing.SystemColors.Window
        Me._txtViWoPar_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtViWoPar_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtViWoPar.SetIndex(Me._txtViWoPar_3, CType(3, Short))
        Me._txtViWoPar_3.Location = New System.Drawing.Point(75, 112)
        Me._txtViWoPar_3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._txtViWoPar_3.MaxLength = 0
        Me._txtViWoPar_3.Name = "_txtViWoPar_3"
        Me._txtViWoPar_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtViWoPar_3.Size = New System.Drawing.Size(101, 22)
        Me._txtViWoPar_3.TabIndex = 305
        '
        '_txtViWoPar_2
        '
        Me._txtViWoPar_2.AcceptsReturn = True
        Me._txtViWoPar_2.BackColor = System.Drawing.SystemColors.Window
        Me._txtViWoPar_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtViWoPar_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtViWoPar.SetIndex(Me._txtViWoPar_2, CType(2, Short))
        Me._txtViWoPar_2.Location = New System.Drawing.Point(75, 81)
        Me._txtViWoPar_2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._txtViWoPar_2.MaxLength = 0
        Me._txtViWoPar_2.Name = "_txtViWoPar_2"
        Me._txtViWoPar_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtViWoPar_2.Size = New System.Drawing.Size(101, 22)
        Me._txtViWoPar_2.TabIndex = 304
        '
        '_txtViWoPar_1
        '
        Me._txtViWoPar_1.AcceptsReturn = True
        Me._txtViWoPar_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtViWoPar_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtViWoPar_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtViWoPar.SetIndex(Me._txtViWoPar_1, CType(1, Short))
        Me._txtViWoPar_1.Location = New System.Drawing.Point(75, 50)
        Me._txtViWoPar_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._txtViWoPar_1.MaxLength = 0
        Me._txtViWoPar_1.Name = "_txtViWoPar_1"
        Me._txtViWoPar_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtViWoPar_1.Size = New System.Drawing.Size(101, 22)
        Me._txtViWoPar_1.TabIndex = 303
        '
        '_fraViWoParameter_0
        '
        Me._fraViWoParameter_0.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._fraViWoParameter_0.Controls.Add(Me.txtViWoInteger)
        Me._fraViWoParameter_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraViWoParameter.SetIndex(Me._fraViWoParameter_0, CType(0, Short))
        Me._fraViWoParameter_0.Location = New System.Drawing.Point(387, 177)
        Me._fraViWoParameter_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._fraViWoParameter_0.Name = "_fraViWoParameter_0"
        Me._fraViWoParameter_0.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._fraViWoParameter_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraViWoParameter_0.Size = New System.Drawing.Size(241, 144)
        Me._fraViWoParameter_0.TabIndex = 296
        Me._fraViWoParameter_0.TabStop = False
        Me._fraViWoParameter_0.Text = "Number/String:"
        '
        'txtViWoInteger
        '
        Me.txtViWoInteger.AcceptsReturn = True
        Me.txtViWoInteger.BackColor = System.Drawing.SystemColors.Window
        Me.txtViWoInteger.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtViWoInteger.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtViWoInteger.Location = New System.Drawing.Point(16, 59)
        Me.txtViWoInteger.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtViWoInteger.MaxLength = 0
        Me.txtViWoInteger.Name = "txtViWoInteger"
        Me.txtViWoInteger.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtViWoInteger.Size = New System.Drawing.Size(208, 22)
        Me.txtViWoInteger.TabIndex = 297
        '
        '_fraViWoParameter_2
        '
        Me._fraViWoParameter_2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._fraViWoParameter_2.Controls.Add(Me._txtViWoPosition_2)
        Me._fraViWoParameter_2.Controls.Add(Me._txtViWoPosition_1)
        Me._fraViWoParameter_2.Controls.Add(Me._txtViWoPosition_0)
        Me._fraViWoParameter_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraViWoParameter.SetIndex(Me._fraViWoParameter_2, CType(2, Short))
        Me._fraViWoParameter_2.Location = New System.Drawing.Point(419, 180)
        Me._fraViWoParameter_2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._fraViWoParameter_2.Name = "_fraViWoParameter_2"
        Me._fraViWoParameter_2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._fraViWoParameter_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraViWoParameter_2.Size = New System.Drawing.Size(241, 144)
        Me._fraViWoParameter_2.TabIndex = 301
        Me._fraViWoParameter_2.TabStop = False
        Me._fraViWoParameter_2.Text = "Position:"
        '
        '_txtViWoPosition_2
        '
        Me._txtViWoPosition_2.AcceptsReturn = True
        Me._txtViWoPosition_2.BackColor = System.Drawing.SystemColors.Window
        Me._txtViWoPosition_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtViWoPosition_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtViWoPosition.SetIndex(Me._txtViWoPosition_2, CType(2, Short))
        Me._txtViWoPosition_2.Location = New System.Drawing.Point(75, 98)
        Me._txtViWoPosition_2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._txtViWoPosition_2.MaxLength = 0
        Me._txtViWoPosition_2.Name = "_txtViWoPosition_2"
        Me._txtViWoPosition_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtViWoPosition_2.Size = New System.Drawing.Size(101, 22)
        Me._txtViWoPosition_2.TabIndex = 304
        '
        '_txtViWoPosition_1
        '
        Me._txtViWoPosition_1.AcceptsReturn = True
        Me._txtViWoPosition_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtViWoPosition_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtViWoPosition_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtViWoPosition.SetIndex(Me._txtViWoPosition_1, CType(1, Short))
        Me._txtViWoPosition_1.Location = New System.Drawing.Point(75, 60)
        Me._txtViWoPosition_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._txtViWoPosition_1.MaxLength = 0
        Me._txtViWoPosition_1.Name = "_txtViWoPosition_1"
        Me._txtViWoPosition_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtViWoPosition_1.Size = New System.Drawing.Size(101, 22)
        Me._txtViWoPosition_1.TabIndex = 303
        '
        '_txtViWoPosition_0
        '
        Me._txtViWoPosition_0.AcceptsReturn = True
        Me._txtViWoPosition_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtViWoPosition_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtViWoPosition_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtViWoPosition.SetIndex(Me._txtViWoPosition_0, CType(0, Short))
        Me._txtViWoPosition_0.Location = New System.Drawing.Point(75, 25)
        Me._txtViWoPosition_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._txtViWoPosition_0.MaxLength = 0
        Me._txtViWoPosition_0.Name = "_txtViWoPosition_0"
        Me._txtViWoPosition_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtViWoPosition_0.Size = New System.Drawing.Size(101, 22)
        Me._txtViWoPosition_0.TabIndex = 302
        '
        '_fraViWoParameter_1
        '
        Me._fraViWoParameter_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._fraViWoParameter_1.Controls.Add(Me.cmdViWoColor)
        Me._fraViWoParameter_1.Controls.Add(Me.shpViWoColor)
        Me._fraViWoParameter_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraViWoParameter.SetIndex(Me._fraViWoParameter_1, CType(1, Short))
        Me._fraViWoParameter_1.Location = New System.Drawing.Point(388, 177)
        Me._fraViWoParameter_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._fraViWoParameter_1.Name = "_fraViWoParameter_1"
        Me._fraViWoParameter_1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._fraViWoParameter_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraViWoParameter_1.Size = New System.Drawing.Size(241, 144)
        Me._fraViWoParameter_1.TabIndex = 298
        Me._fraViWoParameter_1.TabStop = False
        Me._fraViWoParameter_1.Text = "Color:"
        '
        'cmdViWoColor
        '
        Me.cmdViWoColor.BackColor = System.Drawing.SystemColors.Control
        Me.cmdViWoColor.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdViWoColor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdViWoColor.Location = New System.Drawing.Point(80, 84)
        Me.cmdViWoColor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdViWoColor.Name = "cmdViWoColor"
        Me.cmdViWoColor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdViWoColor.Size = New System.Drawing.Size(87, 26)
        Me.cmdViWoColor.TabIndex = 299
        Me.cmdViWoColor.Text = "Choose"
        Me.cmdViWoColor.UseVisualStyleBackColor = False
        '
        'shpViWoColor
        '
        Me.shpViWoColor.BackColor = System.Drawing.SystemColors.Window
        Me.shpViWoColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.shpViWoColor.Location = New System.Drawing.Point(101, 34)
        Me.shpViWoColor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.shpViWoColor.Name = "shpViWoColor"
        Me.shpViWoColor.Size = New System.Drawing.Size(43, 35)
        Me.shpViWoColor.TabIndex = 300
        '
        '_Label8_0
        '
        Me._Label8_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label8_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label8_0.Location = New System.Drawing.Point(472, 39)
        Me._Label8_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label8_0.Name = "_Label8_0"
        Me._Label8_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label8_0.Size = New System.Drawing.Size(93, 16)
        Me._Label8_0.TabIndex = 285
        Me._Label8_0.Text = "Head [ms]:"
        Me._Label8_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Label8_1
        '
        Me._Label8_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label8_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label8_1.Location = New System.Drawing.Point(469, 64)
        Me._Label8_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label8_1.Name = "_Label8_1"
        Me._Label8_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label8_1.Size = New System.Drawing.Size(96, 16)
        Me._Label8_1.TabIndex = 286
        Me._Label8_1.Text = "Pointer [ms]:"
        Me._Label8_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'chkViWoSendData
        '
        Me.chkViWoSendData.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkViWoSendData.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkViWoSendData.Location = New System.Drawing.Point(23, 34)
        Me.chkViWoSendData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkViWoSendData.Name = "chkViWoSendData"
        Me.chkViWoSendData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkViWoSendData.Size = New System.Drawing.Size(333, 31)
        Me.chkViWoSendData.TabIndex = 282
        Me.chkViWoSendData.Text = "Send Tracker Data. Use Average windows:"
        Me.chkViWoSendData.UseVisualStyleBackColor = False
        '
        'txtViWoAvgHead
        '
        Me.txtViWoAvgHead.AcceptsReturn = True
        Me.txtViWoAvgHead.BackColor = System.Drawing.SystemColors.Window
        Me.txtViWoAvgHead.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtViWoAvgHead.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtViWoAvgHead.Location = New System.Drawing.Point(573, 34)
        Me.txtViWoAvgHead.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtViWoAvgHead.MaxLength = 10
        Me.txtViWoAvgHead.Name = "txtViWoAvgHead"
        Me.txtViWoAvgHead.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtViWoAvgHead.Size = New System.Drawing.Size(53, 22)
        Me.txtViWoAvgHead.TabIndex = 283
        '
        'txtViWoAvgPointer
        '
        Me.txtViWoAvgPointer.AcceptsReturn = True
        Me.txtViWoAvgPointer.BackColor = System.Drawing.SystemColors.Window
        Me.txtViWoAvgPointer.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtViWoAvgPointer.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtViWoAvgPointer.Location = New System.Drawing.Point(573, 59)
        Me.txtViWoAvgPointer.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtViWoAvgPointer.MaxLength = 10
        Me.txtViWoAvgPointer.Name = "txtViWoAvgPointer"
        Me.txtViWoAvgPointer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtViWoAvgPointer.Size = New System.Drawing.Size(53, 22)
        Me.txtViWoAvgPointer.TabIndex = 284
        '
        'lstViWoWorlds
        '
        Me.lstViWoWorlds.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstViWoWorlds.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstViWoWorlds.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstViWoWorlds.ItemHeight = 16
        Me.lstViWoWorlds.Location = New System.Drawing.Point(37, 94)
        Me.lstViWoWorlds.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lstViWoWorlds.Name = "lstViWoWorlds"
        Me.lstViWoWorlds.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstViWoWorlds.Size = New System.Drawing.Size(591, 52)
        Me.lstViWoWorlds.TabIndex = 294
        '
        'lstViWoParameters
        '
        Me.lstViWoParameters.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstViWoParameters.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstViWoParameters.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstViWoParameters.ItemHeight = 16
        Me.lstViWoParameters.Location = New System.Drawing.Point(37, 177)
        Me.lstViWoParameters.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lstViWoParameters.Name = "lstViWoParameters"
        Me.lstViWoParameters.Size = New System.Drawing.Size(340, 260)
        Me.lstViWoParameters.TabIndex = 295
        '
        '_cmdViWoSendParameters_0
        '
        Me._cmdViWoSendParameters_0.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._cmdViWoSendParameters_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdViWoSendParameters_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdViWoSendParameters.SetIndex(Me._cmdViWoSendParameters_0, CType(0, Short))
        Me._cmdViWoSendParameters_0.Location = New System.Drawing.Point(451, 384)
        Me._cmdViWoSendParameters_0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._cmdViWoSendParameters_0.Name = "_cmdViWoSendParameters_0"
        Me._cmdViWoSendParameters_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdViWoSendParameters_0.Size = New System.Drawing.Size(145, 26)
        Me._cmdViWoSendParameters_0.TabIndex = 306
        Me._cmdViWoSendParameters_0.Text = "Send to ViWo"
        Me._cmdViWoSendParameters_0.UseVisualStyleBackColor = False
        '
        '_cmdViWoSendParameters_1
        '
        Me._cmdViWoSendParameters_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._cmdViWoSendParameters_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdViWoSendParameters_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdViWoSendParameters.SetIndex(Me._cmdViWoSendParameters_1, CType(1, Short))
        Me._cmdViWoSendParameters_1.Location = New System.Drawing.Point(451, 414)
        Me._cmdViWoSendParameters_1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._cmdViWoSendParameters_1.Name = "_cmdViWoSendParameters_1"
        Me._cmdViWoSendParameters_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdViWoSendParameters_1.Size = New System.Drawing.Size(145, 26)
        Me._cmdViWoSendParameters_1.TabIndex = 307
        Me._cmdViWoSendParameters_1.Text = "Send to MIDI"
        Me._cmdViWoSendParameters_1.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(32, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 226
        Me.Label3.Text = "Par1:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tmrExpResize
        '
        Me.tmrExpResize.Interval = 125
        '
        'tmrTracker
        '
        Me.tmrTracker.Interval = 200
        '
        'tmrRealTime
        '
        Me.tmrRealTime.Interval = 500
        '
        'cmbAudioDither
        '
        '
        'cmdFittBrowse
        '
        '
        'cmdConstCmd
        '
        '
        'cmdFittClear
        '
        '
        'cmdFittReload
        '
        '
        'cmdFittResetPhDur
        '
        '
        'cmdTrackerSetOffset
        '
        '
        'cmdTrackerSetValues
        '
        '
        'cmdViWoSendParameters
        '
        '
        'lblTrackerA
        '
        '
        'lblTrackerARange
        '
        '
        'lblTrackerE
        '
        '
        'lblTrackerERange
        '
        '
        'lblTrackerR
        '
        '
        'lblTrackerRRange
        '
        '
        'lblTrackerX
        '
        '
        'lblTrackerXRange
        '
        '
        'lblTrackerY
        '
        '
        'lblTrackerYRange
        '
        '
        'lblTrackerZ
        '
        '
        'lblTrackerZRange
        '
        '
        'lstVariables
        '
        '
        'optAudioDitherLeft
        '
        '
        'optAudioDitherRight
        '
        '
        'optAudioSynthDAC
        '
        '
        'optDeviceType
        '
        '
        'txtAudioDitherHC
        '
        '
        'txtAudioDitherLC
        '
        '
        'txtAudioDitherPar1
        '
        '
        'txtConstValue
        '
        '
        'txtViWoPosition
        '
        '
        'txtViWoPar
        '
        '
        'TextBox1
        '
        Me.TextBox1.AcceptsReturn = True
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox1.Location = New System.Drawing.Point(108, 62)
        Me.TextBox1.MaxLength = 10
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox1.Size = New System.Drawing.Size(61, 22)
        Me.TextBox1.TabIndex = 225
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(739, 690)
        Me.Controls.Add(Me.PanelBottom)
        Me.Controls.Add(Me.tabSettings)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(307, 336)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(754, 728)
        Me.Name = "frmSettings"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Tag = "Options"
        Me.Text = "Settings"
        Me.PanelBottom.ResumeLayout(false)
        CType(Me.OexpMode,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabSettings.ResumeLayout(false)
        Me.tabGeneral.ResumeLayout(false)
        Me.fraDeviceType.ResumeLayout(false)
        Me.fraDeviceType.PerformLayout
        Me.fraWorkDir.ResumeLayout(false)
        Me.fraWorkDir.PerformLayout
        Me.fraDataDir.ResumeLayout(false)
        Me.fraDataDir.PerformLayout
        Me.fraTurntable.ResumeLayout(false)
        Me.tabFittingLeft.ResumeLayout(false)
        Me.tabFittingLeft.PerformLayout
        Me.tabFittingRight.ResumeLayout(false)
        Me.tabFittingRight.PerformLayout
        Me.tabDescription.ResumeLayout(false)
        Me.tabDescription.PerformLayout
        Me.tabExperimentScreen.ResumeLayout(false)
        Me.Frame1.ResumeLayout(false)
        Me.Frame1.PerformLayout
        Me.Frame2.ResumeLayout(false)
        Me.Frame2.PerformLayout
        Me.Frame3.ResumeLayout(false)
        Me.tabChannels.ResumeLayout(false)
        Me.tabChannels.PerformLayout
        Me.fraSignalR.ResumeLayout(false)
        Me.fraSignalR.PerformLayout
        Me.fraSignalL.ResumeLayout(false)
        Me.fraSignalL.PerformLayout
        Me.fraElectricalL.ResumeLayout(false)
        Me.fraElectricalL.PerformLayout
        CType(Me.sldL,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraElectricalR.ResumeLayout(false)
        Me.fraElectricalR.PerformLayout
        CType(Me.sldR,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraAcousticL.ResumeLayout(false)
        Me.fraAcousticL.PerformLayout
        Me.fraAcousticR.ResumeLayout(false)
        Me.fraAcousticR.PerformLayout
        Me.tabAudio.ResumeLayout(false)
        Me.tabAudio.PerformLayout
        Me._fraAudioDither_1.ResumeLayout(false)
        Me._fraAudioDither_1.PerformLayout
        CType(Me.sldAudioDitherAmp_1,System.ComponentModel.ISupportInitialize).EndInit
        Me._fraAudioDither_0.ResumeLayout(false)
        Me._fraAudioDither_0.PerformLayout
        CType(Me.sldAudioDitherAmp_0,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraVocBox.ResumeLayout(false)
        Me.fraVocBox.PerformLayout
        Me.fraAudioDACMulti.ResumeLayout(false)
        Me.fraAudioDACLeft.ResumeLayout(false)
        Me.fraAudioDACRight.ResumeLayout(false)
        Me.tabProcedure.ResumeLayout(false)
        Me.tabProcedure.PerformLayout
        Me.tabVariables.ResumeLayout(false)
        Me.SplitContainer2.Panel1.ResumeLayout(false)
        Me.SplitContainer2.Panel1.PerformLayout
        Me.SplitContainer2.Panel2.ResumeLayout(false)
        Me.SplitContainer2.ResumeLayout(false)
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel1.PerformLayout
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        Me.SplitContainer1.Panel2.PerformLayout
        Me.SplitContainer1.ResumeLayout(false)
        Me.tabConstants.ResumeLayout(false)
        Me.tabConstants.PerformLayout
        Me.tabTracker.ResumeLayout(false)
        Me.fraTrackerSettings.ResumeLayout(false)
        Me.fraTrackerSettings.PerformLayout
        Me._fraTrackerSensor_0.ResumeLayout(false)
        Me._fraTrackerSensor_1.ResumeLayout(false)
        Me.tabVirtualWorld.ResumeLayout(false)
        Me.tabVirtualWorld.PerformLayout
        Me._fraViWoParameter_3.ResumeLayout(false)
        Me._fraViWoParameter_3.PerformLayout
        Me._fraViWoParameter_0.ResumeLayout(false)
        Me._fraViWoParameter_0.PerformLayout
        Me._fraViWoParameter_2.ResumeLayout(false)
        Me._fraViWoParameter_2.PerformLayout
        Me._fraViWoParameter_1.ResumeLayout(false)
        CType(Me.cmbAudioDither,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmdFittBrowse,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmdConstCmd,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmdFittClear,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmdFittReload,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmdFittResetPhDur,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmdTrackerSetOffset,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmdTrackerSetValues,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmdViWoSendParameters,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.fraAudioDither,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.fraTrackerSensor,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.fraViWoParameter,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblAudio,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblAudioDitherAmp,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblConstName,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblConstUnit,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblCycPer,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblExp,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblInterStimBreakU,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblMinDist,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblPPer,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblImpType,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblPostStimVisuOffsetU,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblPreStimBreakU,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblPreStimVisuOffsetU,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblStimOffset,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblTrackerA,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblTrackerARange,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblTrackerE,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblTrackerERange,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblTrackerLabA,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblTrackerLabE,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblTrackerLabR,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblTrackerLabX,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblTrackerLabY,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblTrackerLabZ,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblTrackerR,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblTrackerRRange,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblTrackerX,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblTrackerXRange,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblTrackerY,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblTrackerYRange,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblTrackerZ,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lblTrackerZRange,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lstChInfo,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lstVariables,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.optAudioDitherLeft,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.optAudioDitherRight,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.optAudioSynthDAC,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.optDeviceType,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtAudioDitherHC,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtAudioDitherLC,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtAudioDitherPar1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtConstValue,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtFName,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtFittFile,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtLName,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtMinDist,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtViWoPosition,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtViWoPar,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents sldL As System.Windows.Forms.TrackBar
    Friend WithEvents sldR As System.Windows.Forms.TrackBar
    Friend WithEvents sldAudioDitherAmp_1 As System.Windows.Forms.TrackBar
    Friend WithEvents sldAudioDitherAmp_0 As System.Windows.Forms.TrackBar
    Friend WithEvents pbProgress As System.Windows.Forms.ProgressBar
    Public WithEvents cmdFittEdit_0 As System.Windows.Forms.Button
    Public WithEvents cmdFittEdit_1 As System.Windows.Forms.Button
    Friend WithEvents PanelBottom As System.Windows.Forms.Panel
    Public WithEvents _optDeviceType_2 As System.Windows.Forms.RadioButton
    Friend WithEvents cmdExpShowResponseCodes As System.Windows.Forms.Button
    Public WithEvents cmdAudioSynthAllB As System.Windows.Forms.Button
    Public WithEvents cmdAudioSynthAllA As System.Windows.Forms.Button
    Public WithEvents cmdExpSetDefault As System.Windows.Forms.Button
    Public WithEvents cmbDuplicate As System.Windows.Forms.Button
    Public WithEvents chkDoNotConnectToDevice As System.Windows.Forms.CheckBox
    Public WithEvents txtSourceDirCopy As System.Windows.Forms.TextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents txtExperimentItemRange As System.Windows.Forms.Label
    Public WithEvents cmdExpSetSmall As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Public WithEvents cmdAnalysisSetting As System.Windows.Forms.Button
    Public WithEvents _optDeviceType_3 As System.Windows.Forms.RadioButton
    Protected WithEvents optDeviceType As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
    Public WithEvents _fraViWoParameter_3 As System.Windows.Forms.GroupBox
    Public WithEvents _txtViWoPar_0 As System.Windows.Forms.TextBox
    Public WithEvents _txtViWoPar_3 As System.Windows.Forms.TextBox
    Public WithEvents _txtViWoPar_2 As System.Windows.Forms.TextBox
    Public WithEvents _txtViWoPar_1 As System.Windows.Forms.TextBox
    Public WithEvents _txtViWoPar_4 As System.Windows.Forms.TextBox
    Friend WithEvents OexpMode As System.Windows.Forms.NumericUpDown
    Public WithEvents chkOverrideExpMode As System.Windows.Forms.CheckBox
    Public WithEvents _optDeviceType_4 As System.Windows.Forms.RadioButton
    Public WithEvents fraVocBox As System.Windows.Forms.GroupBox
    Public WithEvents NoiseVoc As System.Windows.Forms.RadioButton
    Public WithEvents GetVoc As System.Windows.Forms.RadioButton
    Public WithEvents facScalelbl As System.Windows.Forms.TextBox
    Public WithEvents facScaletxt As System.Windows.Forms.Label
    Public WithEvents TextBox1 As System.Windows.Forms.TextBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents facScalelbl2 As System.Windows.Forms.TextBox
    Public WithEvents facScaletxt2 As System.Windows.Forms.Label
    Public WithEvents _optDeviceType_5 As System.Windows.Forms.RadioButton
    Public WithEvents ckbUseDataChannel As System.Windows.Forms.CheckBox
    Public WithEvents ckbUseTriggerChannel As System.Windows.Forms.CheckBox
    Public WithEvents _lblTrackerA_Range_0 As Label
    Public WithEvents _lblTrackerE_Range_0 As Label
    Public WithEvents _lblTrackerR_Range_0 As Label
    Public WithEvents _lblTrackerY_Range_0 As Label
    Public WithEvents _lblTrackerZ_Range_0 As Label
    Public WithEvents _lblTrackerX_Range_0 As Label
    Public WithEvents _lblTrackerR_Range_1 As Label
    Public WithEvents _lblTrackerY_Range_1 As Label
    Public WithEvents _lblTrackerZ_Range_1 As Label
    Public WithEvents _lblTrackerX_Range_1 As Label
    Public WithEvents _lblTrackerE_Range_1 As Label
    Public WithEvents _lblTrackerA_Range_1 As Label
    Public WithEvents _Label7_0 As Label
    Public WithEvents _lblImpType_0 As Label
    Public WithEvents Label5 As Label
    Public WithEvents _lblImpType_1 As Label
#End Region
End Class