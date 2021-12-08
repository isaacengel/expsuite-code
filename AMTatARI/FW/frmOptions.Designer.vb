<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmOptions
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
	Public WithEvents fraSample4 As System.Windows.Forms.GroupBox
	Public WithEvents _picOptions_3 As System.Windows.Forms.Panel
	Public WithEvents fraSample3 As System.Windows.Forms.GroupBox
	Public WithEvents _picOptions_2 As System.Windows.Forms.Panel
	Public WithEvents fraSample2 As System.Windows.Forms.GroupBox
	Public WithEvents _picOptions_1 As System.Windows.Forms.Panel
	Public WithEvents chkAutoBackupLogFile As System.Windows.Forms.CheckBox
	Public WithEvents chkUseBeepExp As System.Windows.Forms.CheckBox
	Public WithEvents cmbBeepExp As System.Windows.Forms.ComboBox
	Public WithEvents cmdBeepExp As System.Windows.Forms.Button
	Public WithEvents chkBeepOnItem As System.Windows.Forms.CheckBox
	Public WithEvents _sstOptions_GeneralTab As System.Windows.Forms.TabPage
	Public WithEvents cmbPlayerHPR As System.Windows.Forms.ComboBox
	Public WithEvents cmbPlayerHPL As System.Windows.Forms.ComboBox
	Public WithEvents chkPlayerFreeze As System.Windows.Forms.CheckBox
	Public WithEvents cmbPlayerMIDIInDevice As System.Windows.Forms.ComboBox
	Public WithEvents cmbPlayerMIDIOutDevice As System.Windows.Forms.ComboBox
	Public WithEvents chkPlayerNoGUI As System.Windows.Forms.CheckBox
	Public WithEvents chkPlayerKillOnDisconnect As System.Windows.Forms.CheckBox
	Public WithEvents cmbPlayerChannels As System.Windows.Forms.ComboBox
	Public WithEvents cmbPlayerDevice As System.Windows.Forms.ComboBox
	Public WithEvents chkPlayerNoADC As System.Windows.Forms.CheckBox
	Public WithEvents chkPlayerASIO As System.Windows.Forms.CheckBox
	Public WithEvents txtPlayerFileName As System.Windows.Forms.TextBox
    Public WithEvents txtYAMIAddr As System.Windows.Forms.TextBox
    Public WithEvents txtYAMIPort As System.Windows.Forms.TextBox
    Public WithEvents txtLocalYAMIAddr As System.Windows.Forms.TextBox
    Public WithEvents txtLocalYAMIPort As System.Windows.Forms.TextBox
    Public WithEvents Label22 As System.Windows.Forms.Label
    Public WithEvents Label21 As System.Windows.Forms.Label
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents Label15 As System.Windows.Forms.Label
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents _sstOptions_PdTab As System.Windows.Forms.TabPage
    Public WithEvents cmdMATLABPath As System.Windows.Forms.Button
    Public WithEvents txtMATLABPath As System.Windows.Forms.TextBox
    Public WithEvents txtMATLABServer As System.Windows.Forms.TextBox
    Public WithEvents chkUseMATLAB As System.Windows.Forms.CheckBox
    Public WithEvents lblMATLABPath As System.Windows.Forms.Label
    Public WithEvents Label18 As System.Windows.Forms.Label
    Public WithEvents Label17 As System.Windows.Forms.Label
    Public WithEvents _sstOptions_MatlabTab As System.Windows.Forms.TabPage
    Public WithEvents cmbComLeft As System.Windows.Forms.ComboBox
    Public WithEvents cmbComRight As System.Windows.Forms.ComboBox
    Public WithEvents txtRIBServer As System.Windows.Forms.TextBox
    Public WithEvents chkSimulation As System.Windows.Forms.CheckBox
    Public WithEvents _Label2_0 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents _sstOptions_RIBTab As System.Windows.Forms.TabPage
    Public WithEvents txtCSVQuota As System.Windows.Forms.TextBox
    Public WithEvents txtCSVDelimiter As System.Windows.Forms.TextBox
    Public WithEvents _Label9_1 As System.Windows.Forms.Label
    Public WithEvents _Label9_0 As System.Windows.Forms.Label
    Public WithEvents _sstOptions_ItemListTab As System.Windows.Forms.TabPage
    Public WithEvents chkTRLog As System.Windows.Forms.CheckBox
    Public WithEvents txtTRSettingsInterval As System.Windows.Forms.TextBox
    Public WithEvents cmbTRSensorCount As System.Windows.Forms.ComboBox
    Public WithEvents chkTRSimulation As System.Windows.Forms.CheckBox
    Public WithEvents cmbTRBaudrate As System.Windows.Forms.ComboBox
    Public WithEvents cmbTRCom As System.Windows.Forms.ComboBox
    Public WithEvents _Label2_5 As System.Windows.Forms.Label
    Public WithEvents _Label2_4 As System.Windows.Forms.Label
    Public WithEvents lblTRSensorCount As System.Windows.Forms.Label
    Public WithEvents _Label2_2 As System.Windows.Forms.Label
    Public WithEvents _Label2_1 As System.Windows.Forms.Label
    Public WithEvents _sstOptions_TrackerTab As System.Windows.Forms.TabPage
    Public WithEvents txtTTOffset As System.Windows.Forms.TextBox
    Public WithEvents cmbTTLPT As System.Windows.Forms.ComboBox
    Public WithEvents _Label2_8 As System.Windows.Forms.Label
    Public WithEvents _Label2_7 As System.Windows.Forms.Label
    Public WithEvents _Label2_6 As System.Windows.Forms.Label
    Public WithEvents _sstOptions_TurntableTab As System.Windows.Forms.TabPage
    Public WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents Label20 As System.Windows.Forms.Label
    Public WithEvents lblLocalViwoAddr As System.Windows.Forms.Label
    Public WithEvents txtViWoAddress As System.Windows.Forms.TextBox
    Public WithEvents txtViWoPort As System.Windows.Forms.TextBox
    Public WithEvents cmdViWoReconnect As System.Windows.Forms.Button
    Public WithEvents _sstOptions_TabPage7 As System.Windows.Forms.TabPage
    Public WithEvents sstOptions As System.Windows.Forms.TabControl
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOptions))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtViWoAddress = New System.Windows.Forms.TextBox()
        Me.cmdJoypadRemove = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtPlayerFileName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkEnableRemoteMonitorServer = New System.Windows.Forms.CheckBox()
        Me.txtRemoteServer = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkCheckForUpdates = New System.Windows.Forms.CheckBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.UpdateInterval = New System.Windows.Forms.NumericUpDown()
        Me.cmdOptionsDir = New System.Windows.Forms.Button()
        Me.chkPlayWaveExp = New System.Windows.Forms.CheckBox()
        Me.cmbWaveEndExp = New System.Windows.Forms.Button()
        Me.cmdBeepExp = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.chkPlayerKillOnDisconnect = New System.Windows.Forms.CheckBox()
        Me.chkPlayerOSC = New System.Windows.Forms.CheckBox()
        Me.chkViWoOSC = New System.Windows.Forms.CheckBox()
        Me.chkPlayerNoADC = New System.Windows.Forms.CheckBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cmbPlayerADCDevice = New System.Windows.Forms.ComboBox()
        Me.cmbPlayerDevice = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtDACName = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmbADCName = New System.Windows.Forms.ComboBox()
        Me.cmbDACName = New System.Windows.Forms.ComboBox()
        Me.btnListDevices = New System.Windows.Forms.Button()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtADCName = New System.Windows.Forms.TextBox()
        Me.rdbAudioIndex = New System.Windows.Forms.RadioButton()
        Me.rdbAudioName = New System.Windows.Forms.RadioButton()
        Me._sstOptions_PdTab = New System.Windows.Forms.TabPage()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.cmbDataChannel = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cmdYAMIPath = New System.Windows.Forms.Button()
        Me.cmbPlayerHPR = New System.Windows.Forms.ComboBox()
        Me.cmbPlayerHPL = New System.Windows.Forms.ComboBox()
        Me.chkPlayerFreeze = New System.Windows.Forms.CheckBox()
        Me.cmbPlayerMIDIInDevice = New System.Windows.Forms.ComboBox()
        Me.cmbPlayerMIDIOutDevice = New System.Windows.Forms.ComboBox()
        Me.chkPlayerNoGUI = New System.Windows.Forms.CheckBox()
        Me.cmbPlayerChannels = New System.Windows.Forms.ComboBox()
        Me.chkPlayerASIO = New System.Windows.Forms.CheckBox()
        Me.txtYAMIAddr = New System.Windows.Forms.TextBox()
        Me.txtYAMIPort = New System.Windows.Forms.TextBox()
        Me.txtLocalYAMIAddr = New System.Windows.Forms.TextBox()
        Me.txtLocalYAMIPort = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbTriggerChannel = New System.Windows.Forms.ComboBox()
        Me.chkAutoBackupLogFileSilent = New System.Windows.Forms.CheckBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.lblPullBrake = New System.Windows.Forms.Label()
        Me.numTT4ABrakeTimer = New System.Windows.Forms.NumericUpDown()
        Me.ckbIncludeHeadersInClipboard = New System.Windows.Forms.CheckBox()
        Me.ckbTT4AAllowPreRotation = New System.Windows.Forms.CheckBox()
        Me.chkAutoBackupItemList = New System.Windows.Forms.CheckBox()
        Me.chkDisableSetOptimalColWidth = New System.Windows.Forms.CheckBox()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdApply = New System.Windows.Forms.Button()
        Me._picOptions_3 = New System.Windows.Forms.Panel()
        Me.fraSample4 = New System.Windows.Forms.GroupBox()
        Me._picOptions_2 = New System.Windows.Forms.Panel()
        Me.fraSample3 = New System.Windows.Forms.GroupBox()
        Me._picOptions_1 = New System.Windows.Forms.Panel()
        Me.fraSample2 = New System.Windows.Forms.GroupBox()
        Me.sstOptions = New System.Windows.Forms.TabControl()
        Me._sstOptions_GeneralTab = New System.Windows.Forms.TabPage()
        Me.cmbPriority = New System.Windows.Forms.ComboBox()
        Me.cmbWavExp = New System.Windows.Forms.ComboBox()
        Me.cmbBeepExp = New System.Windows.Forms.ComboBox()
        Me.chkBeepOnItem = New System.Windows.Forms.CheckBox()
        Me.txtOptionsFile = New System.Windows.Forms.TextBox()
        Me.lblOptionsFile = New System.Windows.Forms.Label()
        Me.cmbLogMode = New System.Windows.Forms.ComboBox()
        Me.chkAutoBackupLogFile = New System.Windows.Forms.CheckBox()
        Me.chkUseBeepExp = New System.Windows.Forms.CheckBox()
        Me._sstOptions_ItemListTab = New System.Windows.Forms.TabPage()
        Me.gbWarnings = New System.Windows.Forms.GroupBox()
        Me.btnDisableAllWarnings = New System.Windows.Forms.Button()
        Me.btnEnableAllWarnings = New System.Windows.Forms.Button()
        Me.chkResponseItemListOnExpRep = New System.Windows.Forms.CheckBox()
        Me.chkExpPerformedOnShuffle = New System.Windows.Forms.CheckBox()
        Me.chkNotShuffledOnExpStart = New System.Windows.Forms.CheckBox()
        Me.chkNotRepOnExpStart = New System.Windows.Forms.CheckBox()
        Me.chkUseFileNaming = New System.Windows.Forms.CheckBox()
        Me.gbCSVExportImport = New System.Windows.Forms.GroupBox()
        Me.tbItemListPreview = New System.Windows.Forms.TextBox()
        Me._Label9_0 = New System.Windows.Forms.Label()
        Me._Label9_1 = New System.Windows.Forms.Label()
        Me.txtCSVQuota = New System.Windows.Forms.TextBox()
        Me.txtCSVDelimiter = New System.Windows.Forms.TextBox()
        Me._sstOptions_UnityTab = New System.Windows.Forms.TabPage()
        Me.lblUnityLocalPort = New System.Windows.Forms.Label()
        Me.txtUnityAddr = New System.Windows.Forms.TextBox()
        Me.txtUnityPort = New System.Windows.Forms.TextBox()
        Me.txtUnityLocalPort = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me._sstOptions_RIBTab = New System.Windows.Forms.TabPage()
        Me.lblRIBPath = New System.Windows.Forms.Label()
        Me.cmdRIBPath = New System.Windows.Forms.Button()
        Me.txtRIBPath = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbComLeft = New System.Windows.Forms.ComboBox()
        Me.cmbComRight = New System.Windows.Forms.ComboBox()
        Me.txtRIBServer = New System.Windows.Forms.TextBox()
        Me.chkSimulation = New System.Windows.Forms.CheckBox()
        Me._Label2_0 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me._sstOptions_RIB2Tab = New System.Windows.Forms.TabPage()
        Me.lblRIB2Path = New System.Windows.Forms.Label()
        Me.cmdRIB2Path = New System.Windows.Forms.Button()
        Me.txtRIB2Path = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtRIB2Device = New System.Windows.Forms.TextBox()
        Me.chkRIB2Simulation = New System.Windows.Forms.CheckBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me._sstOptions_MatlabTab = New System.Windows.Forms.TabPage()
        Me.cmdMATLABPath = New System.Windows.Forms.Button()
        Me.txtMATLABPath = New System.Windows.Forms.TextBox()
        Me.chkUseMATLAB = New System.Windows.Forms.CheckBox()
        Me.txtMATLABServer = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblMATLABPath = New System.Windows.Forms.Label()
        Me._sstOptions_TrackerTab = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.textBoxUDPport = New System.Windows.Forms.TextBox()
        Me.buttonBrowseOSCstreamerFile = New System.Windows.Forms.Button()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.textBoxOSCstreamerFile = New System.Windows.Forms.TextBox()
        Me.buttonBrowseMotiveFile = New System.Windows.Forms.Button()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.textBoxMotiveFile = New System.Windows.Forms.TextBox()
        Me.rdbTrackerOptitrack = New System.Windows.Forms.RadioButton()
        Me.rdbTrackerDisabled = New System.Windows.Forms.RadioButton()
        Me.rdbTrackerYAMI = New System.Windows.Forms.RadioButton()
        Me.pTrackerYAMI = New System.Windows.Forms.Panel()
        Me.cmbTRCom = New System.Windows.Forms.ComboBox()
        Me._Label2_1 = New System.Windows.Forms.Label()
        Me._Label2_2 = New System.Windows.Forms.Label()
        Me._Label2_4 = New System.Windows.Forms.Label()
        Me.txtTRSettingsInterval = New System.Windows.Forms.TextBox()
        Me._Label2_5 = New System.Windows.Forms.Label()
        Me.cmbTRBaudrate = New System.Windows.Forms.ComboBox()
        Me.chkTRSimulation = New System.Windows.Forms.CheckBox()
        Me.lblTRSensorCount = New System.Windows.Forms.Label()
        Me.rdbTrackerViWo = New System.Windows.Forms.RadioButton()
        Me.chkTRLog = New System.Windows.Forms.CheckBox()
        Me.cmbTRSensorCount = New System.Windows.Forms.ComboBox()
        Me._sstOptions_TurntableTab = New System.Windows.Forms.TabPage()
        Me.textBoxTTspeed = New System.Windows.Forms.NumericUpDown()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.textBoxTTport = New System.Windows.Forms.TextBox()
        Me.textBoxTTIPaddress = New System.Windows.Forms.TextBox()
        Me.rdbTTImperial = New System.Windows.Forms.RadioButton()
        Me.rdbTTOutline = New System.Windows.Forms.RadioButton()
        Me.rdbTTFourAudio = New System.Windows.Forms.RadioButton()
        Me.rdbTTDisabled = New System.Windows.Forms.RadioButton()
        Me.pTTOutline = New System.Windows.Forms.Panel()
        Me.cmbTTLPT = New System.Windows.Forms.ComboBox()
        Me._Label2_6 = New System.Windows.Forms.Label()
        Me.txtTTOffset = New System.Windows.Forms.TextBox()
        Me._Label2_7 = New System.Windows.Forms.Label()
        Me.pTTFourAudio = New System.Windows.Forms.Panel()
        Me.txtTT4AOffset = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.lblTTFourAudio = New System.Windows.Forms.Label()
        Me.btnTTFourAudioInit = New System.Windows.Forms.Button()
        Me._Label2_8 = New System.Windows.Forms.Label()
        Me._sstOptions_TabPage7 = New System.Windows.Forms.TabPage()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblLocalViwoAddr = New System.Windows.Forms.Label()
        Me.txtViWoPort = New System.Windows.Forms.TextBox()
        Me.cmdViWoReconnect = New System.Windows.Forms.Button()
        Me._sstOptions_Joypad = New System.Windows.Forms.TabPage()
        Me.lblJoyInfo = New System.Windows.Forms.Label()
        Me.lstJoypads = New System.Windows.Forms.ListBox()
        Me.cmdJoypadAdd = New System.Windows.Forms.Button()
        Me.dgvJoypad = New System.Windows.Forms.DataGridView()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me._sstOptions_NICTab = New System.Windows.Forms.TabPage()
        Me.lblNICPath = New System.Windows.Forms.Label()
        Me.cmdNICPath = New System.Windows.Forms.Button()
        Me.txtNICPath = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cmbComLeftNIC = New System.Windows.Forms.ComboBox()
        Me.cmbComRightNIC = New System.Windows.Forms.ComboBox()
        Me.txtNICServer = New System.Windows.Forms.TextBox()
        Me.chkSimulationNIC = New System.Windows.Forms.CheckBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.pbStatus = New System.Windows.Forms.ProgressBar()
        CType(Me.UpdateInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me._sstOptions_PdTab.SuspendLayout()
        CType(Me.numTT4ABrakeTimer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._picOptions_3.SuspendLayout()
        Me._picOptions_2.SuspendLayout()
        Me._picOptions_1.SuspendLayout()
        Me.sstOptions.SuspendLayout()
        Me._sstOptions_GeneralTab.SuspendLayout()
        Me._sstOptions_ItemListTab.SuspendLayout()
        Me.gbWarnings.SuspendLayout()
        Me.gbCSVExportImport.SuspendLayout()
        Me._sstOptions_UnityTab.SuspendLayout()
        Me._sstOptions_RIBTab.SuspendLayout()
        Me._sstOptions_RIB2Tab.SuspendLayout()
        Me._sstOptions_MatlabTab.SuspendLayout()
        Me._sstOptions_TrackerTab.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pTrackerYAMI.SuspendLayout()
        Me._sstOptions_TurntableTab.SuspendLayout()
        CType(Me.textBoxTTspeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pTTOutline.SuspendLayout()
        Me.pTTFourAudio.SuspendLayout()
        Me._sstOptions_TabPage7.SuspendLayout()
        Me._sstOptions_Joypad.SuspendLayout()
        CType(Me.dgvJoypad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me._sstOptions_NICTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtViWoAddress
        '
        Me.txtViWoAddress.AcceptsReturn = True
        Me.txtViWoAddress.BackColor = System.Drawing.SystemColors.Window
        Me.txtViWoAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtViWoAddress.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtViWoAddress.Location = New System.Drawing.Point(159, 39)
        Me.txtViWoAddress.Margin = New System.Windows.Forms.Padding(4)
        Me.txtViWoAddress.MaxLength = 0
        Me.txtViWoAddress.Name = "txtViWoAddress"
        Me.txtViWoAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtViWoAddress.Size = New System.Drawing.Size(185, 22)
        Me.txtViWoAddress.TabIndex = 73
        Me.ToolTip1.SetToolTip(Me.txtViWoAddress, "Leave empty to disable the ViWo functionality")
        '
        'cmdJoypadRemove
        '
        Me.cmdJoypadRemove.BackColor = System.Drawing.SystemColors.Control
        Me.cmdJoypadRemove.BackgroundImage = CType(resources.GetObject("cmdJoypadRemove.BackgroundImage"), System.Drawing.Image)
        Me.cmdJoypadRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmdJoypadRemove.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdJoypadRemove.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdJoypadRemove.Location = New System.Drawing.Point(348, 289)
        Me.cmdJoypadRemove.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdJoypadRemove.Name = "cmdJoypadRemove"
        Me.cmdJoypadRemove.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdJoypadRemove.Size = New System.Drawing.Size(28, 26)
        Me.cmdJoypadRemove.TabIndex = 152
        Me.cmdJoypadRemove.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdJoypadRemove, "Delete selected value")
        Me.cmdJoypadRemove.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(12, 48)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(105, 21)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "Logging Mode:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.Label12, "Add flags to combine Logging Modes")
        '
        'txtPlayerFileName
        '
        Me.txtPlayerFileName.AcceptsReturn = True
        Me.txtPlayerFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPlayerFileName.BackColor = System.Drawing.SystemColors.Window
        Me.txtPlayerFileName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPlayerFileName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPlayerFileName.Location = New System.Drawing.Point(132, 15)
        Me.txtPlayerFileName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPlayerFileName.MaxLength = 0
        Me.txtPlayerFileName.Name = "txtPlayerFileName"
        Me.txtPlayerFileName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPlayerFileName.Size = New System.Drawing.Size(413, 22)
        Me.txtPlayerFileName.TabIndex = 30
        Me.ToolTip1.SetToolTip(Me.txtPlayerFileName, "YAMI batch file in ""pd"" subfolder")
        '
        'Label1
        '
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(13, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(129, 20)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "YAMI Start File:"
        Me.ToolTip1.SetToolTip(Me.Label1, "YAMI batch file in ""pd"" subfolder")
        '
        'chkEnableRemoteMonitorServer
        '
        Me.chkEnableRemoteMonitorServer.AutoSize = True
        Me.chkEnableRemoteMonitorServer.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkEnableRemoteMonitorServer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkEnableRemoteMonitorServer.Location = New System.Drawing.Point(20, 32)
        Me.chkEnableRemoteMonitorServer.Margin = New System.Windows.Forms.Padding(4)
        Me.chkEnableRemoteMonitorServer.Name = "chkEnableRemoteMonitorServer"
        Me.chkEnableRemoteMonitorServer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkEnableRemoteMonitorServer.Size = New System.Drawing.Size(446, 21)
        Me.chkEnableRemoteMonitorServer.TabIndex = 30
        Me.chkEnableRemoteMonitorServer.Text = "Enable Remote Monitor Server (application needs to be restarted)"
        Me.ToolTip1.SetToolTip(Me.chkEnableRemoteMonitorServer, "Check to allow clients to connect to your computer")
        Me.chkEnableRemoteMonitorServer.UseVisualStyleBackColor = False
        '
        'txtRemoteServer
        '
        Me.txtRemoteServer.AcceptsReturn = True
        Me.txtRemoteServer.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRemoteServer.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRemoteServer.Location = New System.Drawing.Point(237, 28)
        Me.txtRemoteServer.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRemoteServer.MaxLength = 0
        Me.txtRemoteServer.Name = "txtRemoteServer"
        Me.txtRemoteServer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRemoteServer.Size = New System.Drawing.Size(264, 22)
        Me.txtRemoteServer.TabIndex = 32
        Me.ToolTip1.SetToolTip(Me.txtRemoteServer, "Enter IP adress or computer name in network")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(20, 32)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(207, 17)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Default Remote Monitor Server:"
        Me.ToolTip1.SetToolTip(Me.Label9, "Enter IP adress or computer name in network")
        '
        'chkCheckForUpdates
        '
        Me.chkCheckForUpdates.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkCheckForUpdates.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkCheckForUpdates.Location = New System.Drawing.Point(16, 170)
        Me.chkCheckForUpdates.Margin = New System.Windows.Forms.Padding(4)
        Me.chkCheckForUpdates.Name = "chkCheckForUpdates"
        Me.chkCheckForUpdates.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkCheckForUpdates.Size = New System.Drawing.Size(207, 21)
        Me.chkCheckForUpdates.TabIndex = 48
        Me.chkCheckForUpdates.Text = "Check for updates every"
        Me.ToolTip1.SetToolTip(Me.chkCheckForUpdates, "Automatically check for updates when starting application")
        Me.chkCheckForUpdates.UseVisualStyleBackColor = False
        '
        'Label28
        '
        Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(293, 169)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label28.Size = New System.Drawing.Size(107, 21)
        Me.Label28.TabIndex = 50
        Me.Label28.Text = "days"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.Label28, "Update interval [days]; 0=everytime the application is started")
        '
        'UpdateInterval
        '
        Me.UpdateInterval.Location = New System.Drawing.Point(228, 169)
        Me.UpdateInterval.Margin = New System.Windows.Forms.Padding(4)
        Me.UpdateInterval.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.UpdateInterval.Name = "UpdateInterval"
        Me.UpdateInterval.Size = New System.Drawing.Size(57, 22)
        Me.UpdateInterval.TabIndex = 49
        Me.ToolTip1.SetToolTip(Me.UpdateInterval, "Update interval [days]; 0=everytime the application is started")
        '
        'cmdOptionsDir
        '
        Me.cmdOptionsDir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOptionsDir.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOptionsDir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOptionsDir.Location = New System.Drawing.Point(612, 209)
        Me.cmdOptionsDir.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdOptionsDir.Name = "cmdOptionsDir"
        Me.cmdOptionsDir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOptionsDir.Size = New System.Drawing.Size(32, 26)
        Me.cmdOptionsDir.TabIndex = 121
        Me.cmdOptionsDir.Text = "..."
        Me.ToolTip1.SetToolTip(Me.cmdOptionsDir, "Browse directory")
        Me.cmdOptionsDir.UseVisualStyleBackColor = False
        '
        'chkPlayWaveExp
        '
        Me.chkPlayWaveExp.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkPlayWaveExp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkPlayWaveExp.Location = New System.Drawing.Point(16, 89)
        Me.chkPlayWaveExp.Margin = New System.Windows.Forms.Padding(4)
        Me.chkPlayWaveExp.Name = "chkPlayWaveExp"
        Me.chkPlayWaveExp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPlayWaveExp.Size = New System.Drawing.Size(363, 23)
        Me.chkPlayWaveExp.TabIndex = 122
        Me.chkPlayWaveExp.Text = "Play Wave Files in experiment"
        Me.ToolTip1.SetToolTip(Me.chkPlayWaveExp, "Wave files are played when starting break or finishing experiment. Files must be " &
        "available in subdirectory '\Resources\Application'")
        Me.chkPlayWaveExp.UseVisualStyleBackColor = False
        '
        'cmbWaveEndExp
        '
        Me.cmbWaveEndExp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbWaveEndExp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbWaveEndExp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbWaveEndExp.Location = New System.Drawing.Point(603, 84)
        Me.cmbWaveEndExp.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbWaveEndExp.Name = "cmbWaveEndExp"
        Me.cmbWaveEndExp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbWaveEndExp.Size = New System.Drawing.Size(51, 26)
        Me.cmbWaveEndExp.TabIndex = 123
        Me.cmbWaveEndExp.Text = "Test"
        Me.ToolTip1.SetToolTip(Me.cmbWaveEndExp, "Test (play) wave file")
        Me.cmbWaveEndExp.UseVisualStyleBackColor = False
        '
        'cmdBeepExp
        '
        Me.cmdBeepExp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdBeepExp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBeepExp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBeepExp.Location = New System.Drawing.Point(723, 188)
        Me.cmdBeepExp.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdBeepExp.Name = "cmdBeepExp"
        Me.cmdBeepExp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBeepExp.Size = New System.Drawing.Size(52, 26)
        Me.cmdBeepExp.TabIndex = 37
        Me.cmdBeepExp.Text = "Test"
        Me.ToolTip1.SetToolTip(Me.cmdBeepExp, "Test beep")
        Me.cmdBeepExp.UseVisualStyleBackColor = False
        Me.cmdBeepExp.Visible = False
        '
        'Label29
        '
        Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(12, 129)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label29.Size = New System.Drawing.Size(120, 21)
        Me.Label29.TabIndex = 128
        Me.Label29.Text = "Program Priority:"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.Label29, "Add flags to combine Logging Modes")
        '
        'chkPlayerKillOnDisconnect
        '
        Me.chkPlayerKillOnDisconnect.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkPlayerKillOnDisconnect.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkPlayerKillOnDisconnect.Location = New System.Drawing.Point(247, 47)
        Me.chkPlayerKillOnDisconnect.Margin = New System.Windows.Forms.Padding(4)
        Me.chkPlayerKillOnDisconnect.Name = "chkPlayerKillOnDisconnect"
        Me.chkPlayerKillOnDisconnect.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPlayerKillOnDisconnect.Size = New System.Drawing.Size(184, 23)
        Me.chkPlayerKillOnDisconnect.TabIndex = 60
        Me.chkPlayerKillOnDisconnect.Text = "Kill pd on disconnect"
        Me.ToolTip1.SetToolTip(Me.chkPlayerKillOnDisconnect, "Kill pd instance when application disconnects")
        Me.chkPlayerKillOnDisconnect.UseVisualStyleBackColor = False
        '
        'chkPlayerOSC
        '
        Me.chkPlayerOSC.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkPlayerOSC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkPlayerOSC.Location = New System.Drawing.Point(299, 412)
        Me.chkPlayerOSC.Margin = New System.Windows.Forms.Padding(4)
        Me.chkPlayerOSC.Name = "chkPlayerOSC"
        Me.chkPlayerOSC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPlayerOSC.Size = New System.Drawing.Size(208, 23)
        Me.chkPlayerOSC.TabIndex = 61
        Me.chkPlayerOSC.Text = "Comply with OSC standard"
        Me.ToolTip1.SetToolTip(Me.chkPlayerOSC, "If no parameter is set in OSC messages, a '0' (zero) will be sent as parameter." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
        "Could cause problems in old versions of YAMI/ViWo!")
        Me.chkPlayerOSC.UseVisualStyleBackColor = False
        Me.chkPlayerOSC.Visible = False
        '
        'chkViWoOSC
        '
        Me.chkViWoOSC.AutoSize = True
        Me.chkViWoOSC.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkViWoOSC.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkViWoOSC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkViWoOSC.Location = New System.Drawing.Point(43, 113)
        Me.chkViWoOSC.Margin = New System.Windows.Forms.Padding(4)
        Me.chkViWoOSC.Name = "chkViWoOSC"
        Me.chkViWoOSC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkViWoOSC.Size = New System.Drawing.Size(197, 21)
        Me.chkViWoOSC.TabIndex = 92
        Me.chkViWoOSC.Text = "Comply with OSC standard"
        Me.ToolTip1.SetToolTip(Me.chkViWoOSC, "If no parameter is set in OSC messages, a '0' (zero) will be sent as parameter." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
        "Could cause problems in old versions of YAMI/ViWo!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        Me.chkViWoOSC.UseVisualStyleBackColor = False
        Me.chkViWoOSC.Visible = False
        '
        'chkPlayerNoADC
        '
        Me.chkPlayerNoADC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkPlayerNoADC.AutoSize = True
        Me.chkPlayerNoADC.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkPlayerNoADC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkPlayerNoADC.Location = New System.Drawing.Point(547, 85)
        Me.chkPlayerNoADC.Margin = New System.Windows.Forms.Padding(4)
        Me.chkPlayerNoADC.Name = "chkPlayerNoADC"
        Me.chkPlayerNoADC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPlayerNoADC.Size = New System.Drawing.Size(80, 21)
        Me.chkPlayerNoADC.TabIndex = 33
        Me.chkPlayerNoADC.Text = "No ADC"
        Me.ToolTip1.SetToolTip(Me.chkPlayerNoADC, "No ADC = no audio input (microphones eg.)")
        Me.chkPlayerNoADC.UseVisualStyleBackColor = False
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label36.Location = New System.Drawing.Point(147, 86)
        Me.Label36.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label36.Name = "Label36"
        Me.Label36.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label36.Size = New System.Drawing.Size(40, 17)
        Me.Label36.TabIndex = 97
        Me.Label36.Text = "ADC:"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.Label36, "ADC / input device name, case-sensitive, ASIO must be enabled, syntax: ""ASIO:[int" &
        "erface name]"" or ""MMIO:[interface name]""")
        '
        'cmbPlayerADCDevice
        '
        Me.cmbPlayerADCDevice.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPlayerADCDevice.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbPlayerADCDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlayerADCDevice.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbPlayerADCDevice.Location = New System.Drawing.Point(65, 82)
        Me.cmbPlayerADCDevice.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPlayerADCDevice.Name = "cmbPlayerADCDevice"
        Me.cmbPlayerADCDevice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbPlayerADCDevice.Size = New System.Drawing.Size(64, 24)
        Me.cmbPlayerADCDevice.TabIndex = 36
        Me.ToolTip1.SetToolTip(Me.cmbPlayerADCDevice, "ADC / input device")
        '
        'cmbPlayerDevice
        '
        Me.cmbPlayerDevice.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPlayerDevice.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbPlayerDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlayerDevice.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbPlayerDevice.Location = New System.Drawing.Point(67, 49)
        Me.cmbPlayerDevice.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPlayerDevice.Name = "cmbPlayerDevice"
        Me.cmbPlayerDevice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbPlayerDevice.Size = New System.Drawing.Size(64, 24)
        Me.cmbPlayerDevice.TabIndex = 35
        Me.ToolTip1.SetToolTip(Me.cmbPlayerDevice, "DAC / output device")
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(147, 54)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(40, 17)
        Me.Label13.TabIndex = 55
        Me.Label13.Text = "DAC:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.Label13, "DAC / output device name, case-sensitive, ASIO must be enabled, syntax: ""ASIO:[in" &
        "terface name]"" or ""MMIO:[interface name]""")
        '
        'txtDACName
        '
        Me.txtDACName.AcceptsReturn = True
        Me.txtDACName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDACName.BackColor = System.Drawing.SystemColors.Window
        Me.txtDACName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDACName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDACName.Location = New System.Drawing.Point(197, 49)
        Me.txtDACName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDACName.MaxLength = 0
        Me.txtDACName.Name = "txtDACName"
        Me.txtDACName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDACName.Size = New System.Drawing.Size(331, 22)
        Me.txtDACName.TabIndex = 98
        Me.ToolTip1.SetToolTip(Me.txtDACName, "case-sensitive, ASIO must be enabled, syntax: ""ASIO:[interface name]"" or ""MMIO:[i" &
        "nterface name]""")
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.cmbADCName)
        Me.GroupBox3.Controls.Add(Me.cmbDACName)
        Me.GroupBox3.Controls.Add(Me.btnListDevices)
        Me.GroupBox3.Controls.Add(Me.Label38)
        Me.GroupBox3.Controls.Add(Me.Label39)
        Me.GroupBox3.Controls.Add(Me.txtADCName)
        Me.GroupBox3.Controls.Add(Me.rdbAudioIndex)
        Me.GroupBox3.Controls.Add(Me.Label36)
        Me.GroupBox3.Controls.Add(Me.cmbPlayerADCDevice)
        Me.GroupBox3.Controls.Add(Me.txtDACName)
        Me.GroupBox3.Controls.Add(Me.rdbAudioName)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.cmbPlayerDevice)
        Me.GroupBox3.Controls.Add(Me.chkPlayerNoADC)
        Me.GroupBox3.Location = New System.Drawing.Point(17, 78)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(635, 118)
        Me.GroupBox3.TabIndex = 100
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Audio Device(s)"
        Me.ToolTip1.SetToolTip(Me.GroupBox3, "Select either audio device name or index")
        '
        'cmbADCName
        '
        Me.cmbADCName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbADCName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbADCName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbADCName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbADCName.Location = New System.Drawing.Point(540, 23)
        Me.cmbADCName.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbADCName.Name = "cmbADCName"
        Me.cmbADCName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbADCName.Size = New System.Drawing.Size(85, 24)
        Me.cmbADCName.TabIndex = 128
        Me.cmbADCName.Visible = False
        '
        'cmbDACName
        '
        Me.cmbDACName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDACName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbDACName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDACName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbDACName.Location = New System.Drawing.Point(536, 16)
        Me.cmbDACName.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbDACName.Name = "cmbDACName"
        Me.cmbDACName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbDACName.Size = New System.Drawing.Size(85, 24)
        Me.cmbDACName.TabIndex = 127
        Me.cmbDACName.Visible = False
        '
        'btnListDevices
        '
        Me.btnListDevices.Location = New System.Drawing.Point(417, 16)
        Me.btnListDevices.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnListDevices.Name = "btnListDevices"
        Me.btnListDevices.Size = New System.Drawing.Size(112, 27)
        Me.btnListDevices.TabIndex = 104
        Me.btnListDevices.Text = "List Devices"
        Me.ToolTip1.SetToolTip(Me.btnListDevices, "List currently available devices. Text can be entered in the DAC/ADC text fields " &
        "below to be independent of index values. Text me be truncated in message box.")
        Me.btnListDevices.UseVisualStyleBackColor = True
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label38.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label38.Location = New System.Drawing.Point(16, 87)
        Me.Label38.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label38.Size = New System.Drawing.Size(40, 17)
        Me.Label38.TabIndex = 103
        Me.Label38.Text = "ADC:"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.Label38, "ADC / input device")
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label39.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label39.Location = New System.Drawing.Point(16, 54)
        Me.Label39.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label39.Size = New System.Drawing.Size(40, 17)
        Me.Label39.TabIndex = 102
        Me.Label39.Text = "DAC:"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.Label39, "DAC / output device")
        '
        'txtADCName
        '
        Me.txtADCName.AcceptsReturn = True
        Me.txtADCName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtADCName.BackColor = System.Drawing.SystemColors.Window
        Me.txtADCName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtADCName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtADCName.Location = New System.Drawing.Point(197, 82)
        Me.txtADCName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtADCName.MaxLength = 0
        Me.txtADCName.Name = "txtADCName"
        Me.txtADCName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtADCName.Size = New System.Drawing.Size(331, 22)
        Me.txtADCName.TabIndex = 101
        Me.ToolTip1.SetToolTip(Me.txtADCName, "case-sensitive, ASIO must be enabled, syntax: ""ASIO:[interface name]"" or ""MMIO:[i" &
        "nterface name]""")
        '
        'rdbAudioIndex
        '
        Me.rdbAudioIndex.AutoSize = True
        Me.rdbAudioIndex.Location = New System.Drawing.Point(20, 21)
        Me.rdbAudioIndex.Margin = New System.Windows.Forms.Padding(4)
        Me.rdbAudioIndex.Name = "rdbAudioIndex"
        Me.rdbAudioIndex.Size = New System.Drawing.Size(73, 21)
        Me.rdbAudioIndex.TabIndex = 1
        Me.rdbAudioIndex.TabStop = True
        Me.rdbAudioIndex.Text = "Indices"
        Me.rdbAudioIndex.UseVisualStyleBackColor = True
        '
        'rdbAudioName
        '
        Me.rdbAudioName.AutoSize = True
        Me.rdbAudioName.Location = New System.Drawing.Point(151, 21)
        Me.rdbAudioName.Margin = New System.Windows.Forms.Padding(4)
        Me.rdbAudioName.Name = "rdbAudioName"
        Me.rdbAudioName.Size = New System.Drawing.Size(228, 21)
        Me.rdbAudioName.TabIndex = 0
        Me.rdbAudioName.TabStop = True
        Me.rdbAudioName.Text = "Names (ASIO must be enabled)"
        Me.ToolTip1.SetToolTip(Me.rdbAudioName, "case-sensitive, ASIO must be enabled, syntax: ""ASIO:[interface name]"" or ""MMIO:[i" &
        "nterface name]""")
        Me.rdbAudioName.UseVisualStyleBackColor = True
        '
        '_sstOptions_PdTab
        '
        Me._sstOptions_PdTab.Controls.Add(Me.GroupBox3)
        Me._sstOptions_PdTab.Controls.Add(Me.Label35)
        Me._sstOptions_PdTab.Controls.Add(Me.cmbDataChannel)
        Me._sstOptions_PdTab.Controls.Add(Me.Label23)
        Me._sstOptions_PdTab.Controls.Add(Me.chkPlayerOSC)
        Me._sstOptions_PdTab.Controls.Add(Me.cmdYAMIPath)
        Me._sstOptions_PdTab.Controls.Add(Me.cmbPlayerHPR)
        Me._sstOptions_PdTab.Controls.Add(Me.cmbPlayerHPL)
        Me._sstOptions_PdTab.Controls.Add(Me.chkPlayerFreeze)
        Me._sstOptions_PdTab.Controls.Add(Me.cmbPlayerMIDIInDevice)
        Me._sstOptions_PdTab.Controls.Add(Me.cmbPlayerMIDIOutDevice)
        Me._sstOptions_PdTab.Controls.Add(Me.chkPlayerNoGUI)
        Me._sstOptions_PdTab.Controls.Add(Me.chkPlayerKillOnDisconnect)
        Me._sstOptions_PdTab.Controls.Add(Me.cmbPlayerChannels)
        Me._sstOptions_PdTab.Controls.Add(Me.chkPlayerASIO)
        Me._sstOptions_PdTab.Controls.Add(Me.txtPlayerFileName)
        Me._sstOptions_PdTab.Controls.Add(Me.txtYAMIAddr)
        Me._sstOptions_PdTab.Controls.Add(Me.txtYAMIPort)
        Me._sstOptions_PdTab.Controls.Add(Me.txtLocalYAMIAddr)
        Me._sstOptions_PdTab.Controls.Add(Me.txtLocalYAMIPort)
        Me._sstOptions_PdTab.Controls.Add(Me.Label22)
        Me._sstOptions_PdTab.Controls.Add(Me.Label21)
        Me._sstOptions_PdTab.Controls.Add(Me.Label16)
        Me._sstOptions_PdTab.Controls.Add(Me.Label15)
        Me._sstOptions_PdTab.Controls.Add(Me.Label14)
        Me._sstOptions_PdTab.Controls.Add(Me.Label1)
        Me._sstOptions_PdTab.Controls.Add(Me.Label4)
        Me._sstOptions_PdTab.Controls.Add(Me.Label5)
        Me._sstOptions_PdTab.Controls.Add(Me.Label7)
        Me._sstOptions_PdTab.Controls.Add(Me.Label8)
        Me._sstOptions_PdTab.Controls.Add(Me.Label10)
        Me._sstOptions_PdTab.Controls.Add(Me.Label11)
        Me._sstOptions_PdTab.Controls.Add(Me.cmbTriggerChannel)
        Me._sstOptions_PdTab.Location = New System.Drawing.Point(4, 40)
        Me._sstOptions_PdTab.Margin = New System.Windows.Forms.Padding(4)
        Me._sstOptions_PdTab.Name = "_sstOptions_PdTab"
        Me._sstOptions_PdTab.Size = New System.Drawing.Size(675, 461)
        Me._sstOptions_PdTab.TabIndex = 1
        Me._sstOptions_PdTab.Text = "Audio (Pd)"
        Me.ToolTip1.SetToolTip(Me._sstOptions_PdTab, "ASIO must be enabled. Syntax: ""ASIO:[interface name]"" or ""MMIO:[interface name]""")
        Me._sstOptions_PdTab.UseVisualStyleBackColor = True
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label35.Location = New System.Drawing.Point(79, 311)
        Me.Label35.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label35.Size = New System.Drawing.Size(112, 17)
        Me.Label35.TabIndex = 95
        Me.Label35.Text = "Trigger channel:"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbDataChannel
        '
        Me.cmbDataChannel.BackColor = System.Drawing.SystemColors.Window
        Me.cmbDataChannel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbDataChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDataChannel.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbDataChannel.Location = New System.Drawing.Point(391, 306)
        Me.cmbDataChannel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbDataChannel.Name = "cmbDataChannel"
        Me.cmbDataChannel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbDataChannel.Size = New System.Drawing.Size(64, 24)
        Me.cmbDataChannel.TabIndex = 43
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(287, 311)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(96, 17)
        Me.Label23.TabIndex = 93
        Me.Label23.Text = "Data channel:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdYAMIPath
        '
        Me.cmdYAMIPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdYAMIPath.Location = New System.Drawing.Point(571, 15)
        Me.cmdYAMIPath.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdYAMIPath.Name = "cmdYAMIPath"
        Me.cmdYAMIPath.Size = New System.Drawing.Size(33, 26)
        Me.cmdYAMIPath.TabIndex = 31
        Me.cmdYAMIPath.Text = "..."
        Me.cmdYAMIPath.UseVisualStyleBackColor = True
        '
        'cmbPlayerHPR
        '
        Me.cmbPlayerHPR.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPlayerHPR.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbPlayerHPR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlayerHPR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbPlayerHPR.Location = New System.Drawing.Point(389, 272)
        Me.cmbPlayerHPR.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPlayerHPR.Name = "cmbPlayerHPR"
        Me.cmbPlayerHPR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbPlayerHPR.Size = New System.Drawing.Size(64, 24)
        Me.cmbPlayerHPR.TabIndex = 41
        '
        'cmbPlayerHPL
        '
        Me.cmbPlayerHPL.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPlayerHPL.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbPlayerHPL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlayerHPL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbPlayerHPL.Location = New System.Drawing.Point(196, 272)
        Me.cmbPlayerHPL.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPlayerHPL.Name = "cmbPlayerHPL"
        Me.cmbPlayerHPL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbPlayerHPL.Size = New System.Drawing.Size(64, 24)
        Me.cmbPlayerHPL.TabIndex = 40
        '
        'chkPlayerFreeze
        '
        Me.chkPlayerFreeze.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkPlayerFreeze.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkPlayerFreeze.Location = New System.Drawing.Point(17, 412)
        Me.chkPlayerFreeze.Margin = New System.Windows.Forms.Padding(4)
        Me.chkPlayerFreeze.Name = "chkPlayerFreeze"
        Me.chkPlayerFreeze.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPlayerFreeze.Size = New System.Drawing.Size(303, 23)
        Me.chkPlayerFreeze.TabIndex = 62
        Me.chkPlayerFreeze.Text = "Freeze application thread on stimulation"
        Me.chkPlayerFreeze.UseVisualStyleBackColor = False
        '
        'cmbPlayerMIDIInDevice
        '
        Me.cmbPlayerMIDIInDevice.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPlayerMIDIInDevice.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbPlayerMIDIInDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlayerMIDIInDevice.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbPlayerMIDIInDevice.Location = New System.Drawing.Point(389, 238)
        Me.cmbPlayerMIDIInDevice.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPlayerMIDIInDevice.Name = "cmbPlayerMIDIInDevice"
        Me.cmbPlayerMIDIInDevice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbPlayerMIDIInDevice.Size = New System.Drawing.Size(64, 24)
        Me.cmbPlayerMIDIInDevice.TabIndex = 39
        '
        'cmbPlayerMIDIOutDevice
        '
        Me.cmbPlayerMIDIOutDevice.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPlayerMIDIOutDevice.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbPlayerMIDIOutDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlayerMIDIOutDevice.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbPlayerMIDIOutDevice.Location = New System.Drawing.Point(196, 238)
        Me.cmbPlayerMIDIOutDevice.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPlayerMIDIOutDevice.Name = "cmbPlayerMIDIOutDevice"
        Me.cmbPlayerMIDIOutDevice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbPlayerMIDIOutDevice.Size = New System.Drawing.Size(64, 24)
        Me.cmbPlayerMIDIOutDevice.TabIndex = 38
        '
        'chkPlayerNoGUI
        '
        Me.chkPlayerNoGUI.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkPlayerNoGUI.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkPlayerNoGUI.Location = New System.Drawing.Point(132, 48)
        Me.chkPlayerNoGUI.Margin = New System.Windows.Forms.Padding(4)
        Me.chkPlayerNoGUI.Name = "chkPlayerNoGUI"
        Me.chkPlayerNoGUI.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPlayerNoGUI.Size = New System.Drawing.Size(93, 20)
        Me.chkPlayerNoGUI.TabIndex = 34
        Me.chkPlayerNoGUI.Text = "No GUI"
        Me.chkPlayerNoGUI.UseVisualStyleBackColor = False
        '
        'cmbPlayerChannels
        '
        Me.cmbPlayerChannels.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPlayerChannels.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbPlayerChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlayerChannels.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbPlayerChannels.Location = New System.Drawing.Point(196, 203)
        Me.cmbPlayerChannels.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPlayerChannels.Name = "cmbPlayerChannels"
        Me.cmbPlayerChannels.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbPlayerChannels.Size = New System.Drawing.Size(64, 24)
        Me.cmbPlayerChannels.TabIndex = 37
        '
        'chkPlayerASIO
        '
        Me.chkPlayerASIO.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkPlayerASIO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkPlayerASIO.Location = New System.Drawing.Point(17, 48)
        Me.chkPlayerASIO.Margin = New System.Windows.Forms.Padding(4)
        Me.chkPlayerASIO.Name = "chkPlayerASIO"
        Me.chkPlayerASIO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPlayerASIO.Size = New System.Drawing.Size(109, 20)
        Me.chkPlayerASIO.TabIndex = 32
        Me.chkPlayerASIO.Text = "Use ASIO"
        Me.chkPlayerASIO.UseVisualStyleBackColor = False
        '
        'txtYAMIAddr
        '
        Me.txtYAMIAddr.AcceptsReturn = True
        Me.txtYAMIAddr.BackColor = System.Drawing.SystemColors.Window
        Me.txtYAMIAddr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtYAMIAddr.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtYAMIAddr.Location = New System.Drawing.Point(132, 347)
        Me.txtYAMIAddr.Margin = New System.Windows.Forms.Padding(4)
        Me.txtYAMIAddr.MaxLength = 0
        Me.txtYAMIAddr.Name = "txtYAMIAddr"
        Me.txtYAMIAddr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtYAMIAddr.Size = New System.Drawing.Size(199, 22)
        Me.txtYAMIAddr.TabIndex = 50
        '
        'txtYAMIPort
        '
        Me.txtYAMIPort.AcceptsReturn = True
        Me.txtYAMIPort.BackColor = System.Drawing.SystemColors.Window
        Me.txtYAMIPort.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtYAMIPort.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtYAMIPort.Location = New System.Drawing.Point(391, 347)
        Me.txtYAMIPort.Margin = New System.Windows.Forms.Padding(4)
        Me.txtYAMIPort.MaxLength = 5
        Me.txtYAMIPort.Name = "txtYAMIPort"
        Me.txtYAMIPort.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtYAMIPort.Size = New System.Drawing.Size(64, 22)
        Me.txtYAMIPort.TabIndex = 51
        '
        'txtLocalYAMIAddr
        '
        Me.txtLocalYAMIAddr.AcceptsReturn = True
        Me.txtLocalYAMIAddr.BackColor = System.Drawing.SystemColors.Window
        Me.txtLocalYAMIAddr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLocalYAMIAddr.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLocalYAMIAddr.Location = New System.Drawing.Point(132, 377)
        Me.txtLocalYAMIAddr.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLocalYAMIAddr.MaxLength = 0
        Me.txtLocalYAMIAddr.Name = "txtLocalYAMIAddr"
        Me.txtLocalYAMIAddr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLocalYAMIAddr.Size = New System.Drawing.Size(199, 22)
        Me.txtLocalYAMIAddr.TabIndex = 52
        '
        'txtLocalYAMIPort
        '
        Me.txtLocalYAMIPort.AcceptsReturn = True
        Me.txtLocalYAMIPort.BackColor = System.Drawing.SystemColors.Window
        Me.txtLocalYAMIPort.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLocalYAMIPort.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLocalYAMIPort.Location = New System.Drawing.Point(391, 377)
        Me.txtLocalYAMIPort.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLocalYAMIPort.MaxLength = 5
        Me.txtLocalYAMIPort.Name = "txtLocalYAMIPort"
        Me.txtLocalYAMIPort.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLocalYAMIPort.Size = New System.Drawing.Size(64, 22)
        Me.txtLocalYAMIPort.TabIndex = 53
        '
        'Label22
        '
        Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(341, 277)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label22.Size = New System.Drawing.Size(40, 21)
        Me.Label22.TabIndex = 89
        Me.Label22.Text = "right:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label21
        '
        Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(4, 277)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label21.Size = New System.Drawing.Size(187, 21)
        Me.Label21.TabIndex = 87
        Me.Label21.Text = "Headphone's channel left:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label16
        '
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(277, 244)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(108, 16)
        Me.Label16.TabIndex = 71
        Me.Label16.Text = "MIDI In device:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label15
        '
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(72, 242)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(119, 16)
        Me.Label15.TabIndex = 68
        Me.Label15.Text = "MIDI Out device:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label14
        '
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(76, 208)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(112, 21)
        Me.Label14.TabIndex = 57
        Me.Label14.Text = "Max. channels:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(13, 352)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(53, 20)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "YAMI:"
        '
        'Label5
        '
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(59, 352)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(69, 20)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Address:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(340, 351)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(47, 21)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Port:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(13, 382)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(49, 16)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Local:"
        '
        'Label10
        '
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(55, 382)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(73, 21)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Address:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(348, 382)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(38, 17)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Port:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbTriggerChannel
        '
        Me.cmbTriggerChannel.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTriggerChannel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTriggerChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTriggerChannel.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbTriggerChannel.Location = New System.Drawing.Point(196, 306)
        Me.cmbTriggerChannel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbTriggerChannel.Name = "cmbTriggerChannel"
        Me.cmbTriggerChannel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbTriggerChannel.Size = New System.Drawing.Size(64, 24)
        Me.cmbTriggerChannel.TabIndex = 42
        '
        'chkAutoBackupLogFileSilent
        '
        Me.chkAutoBackupLogFileSilent.AutoSize = True
        Me.chkAutoBackupLogFileSilent.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkAutoBackupLogFileSilent.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAutoBackupLogFileSilent.Location = New System.Drawing.Point(291, 17)
        Me.chkAutoBackupLogFileSilent.Margin = New System.Windows.Forms.Padding(4)
        Me.chkAutoBackupLogFileSilent.Name = "chkAutoBackupLogFileSilent"
        Me.chkAutoBackupLogFileSilent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkAutoBackupLogFileSilent.Size = New System.Drawing.Size(146, 21)
        Me.chkAutoBackupLogFileSilent.TabIndex = 129
        Me.chkAutoBackupLogFileSilent.Text = "...without Dialogue"
        Me.ToolTip1.SetToolTip(Me.chkAutoBackupLogFileSilent, "Save Log File without a file dialogue when Disconnecting")
        Me.chkAutoBackupLogFileSilent.UseVisualStyleBackColor = False
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label42.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label42.Location = New System.Drawing.Point(183, 86)
        Me.Label42.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label42.Name = "Label42"
        Me.Label42.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label42.Size = New System.Drawing.Size(163, 17)
        Me.Label42.TabIndex = 70
        Me.Label42.Text = "seconds after movement"
        Me.ToolTip1.SetToolTip(Me.Label42, "Pull brake xxx seconds after last movement, except if an experiment is running." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
        "0: immediatly" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-1: disabled")
        '
        'lblPullBrake
        '
        Me.lblPullBrake.AutoSize = True
        Me.lblPullBrake.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPullBrake.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPullBrake.Location = New System.Drawing.Point(21, 86)
        Me.lblPullBrake.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPullBrake.Name = "lblPullBrake"
        Me.lblPullBrake.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPullBrake.Size = New System.Drawing.Size(75, 17)
        Me.lblPullBrake.TabIndex = 71
        Me.lblPullBrake.Text = "Pull brake:"
        Me.lblPullBrake.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.lblPullBrake, "Pull brake xxx seconds after last movement, except if an experiment is running." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
        "0: immediatly" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-1: disabled")
        '
        'numTT4ABrakeTimer
        '
        Me.numTT4ABrakeTimer.Location = New System.Drawing.Point(105, 82)
        Me.numTT4ABrakeTimer.Margin = New System.Windows.Forms.Padding(4)
        Me.numTT4ABrakeTimer.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
        Me.numTT4ABrakeTimer.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.numTT4ABrakeTimer.Name = "numTT4ABrakeTimer"
        Me.numTT4ABrakeTimer.Size = New System.Drawing.Size(69, 22)
        Me.numTT4ABrakeTimer.TabIndex = 72
        Me.ToolTip1.SetToolTip(Me.numTT4ABrakeTimer, "Pull brake xxx seconds after last movement, except if an experiment is running." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
        "0: immediatly" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-1: disabled")
        Me.numTT4ABrakeTimer.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'ckbIncludeHeadersInClipboard
        '
        Me.ckbIncludeHeadersInClipboard.AutoSize = True
        Me.ckbIncludeHeadersInClipboard.Location = New System.Drawing.Point(16, 98)
        Me.ckbIncludeHeadersInClipboard.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbIncludeHeadersInClipboard.Name = "ckbIncludeHeadersInClipboard"
        Me.ckbIncludeHeadersInClipboard.Size = New System.Drawing.Size(380, 21)
        Me.ckbIncludeHeadersInClipboard.TabIndex = 85
        Me.ckbIncludeHeadersInClipboard.Text = "Include columns' header texts in clipboard-copy (Ctrl+C)"
        Me.ToolTip1.SetToolTip(Me.ckbIncludeHeadersInClipboard, "When copying content of item list, include also the corresponding column headers'" &
        " text in clipboard. Only valid if more than one cell is selected.")
        Me.ckbIncludeHeadersInClipboard.UseVisualStyleBackColor = True
        '
        'ckbTT4AAllowPreRotation
        '
        Me.ckbTT4AAllowPreRotation.AutoSize = True
        Me.ckbTT4AAllowPreRotation.Location = New System.Drawing.Point(25, 118)
        Me.ckbTT4AAllowPreRotation.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbTT4AAllowPreRotation.Name = "ckbTT4AAllowPreRotation"
        Me.ckbTT4AAllowPreRotation.Size = New System.Drawing.Size(272, 21)
        Me.ckbTT4AAllowPreRotation.TabIndex = 73
        Me.ckbTT4AAllowPreRotation.Text = "Allow pre-rotation during previous item"
        Me.ToolTip1.SetToolTip(Me.ckbTT4AAllowPreRotation, "Allow the command for rotation being sent already during previous item, in order " &
        "to save measurement time.")
        Me.ckbTT4AAllowPreRotation.UseVisualStyleBackColor = True
        '
        'chkAutoBackupItemList
        '
        Me.chkAutoBackupItemList.AutoSize = True
        Me.chkAutoBackupItemList.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkAutoBackupItemList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAutoBackupItemList.Location = New System.Drawing.Point(16, 17)
        Me.chkAutoBackupItemList.Margin = New System.Windows.Forms.Padding(4)
        Me.chkAutoBackupItemList.Name = "chkAutoBackupItemList"
        Me.chkAutoBackupItemList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkAutoBackupItemList.Size = New System.Drawing.Size(227, 21)
        Me.chkAutoBackupItemList.TabIndex = 126
        Me.chkAutoBackupItemList.Text = "Backup item list in output folder"
        Me.ToolTip1.SetToolTip(Me.chkAutoBackupItemList, "A backup of the current item list is saved in the output folder, the file name ha" &
        "s the prefix '~'")
        Me.chkAutoBackupItemList.UseVisualStyleBackColor = False
        '
        'chkDisableSetOptimalColWidth
        '
        Me.chkDisableSetOptimalColWidth.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkDisableSetOptimalColWidth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkDisableSetOptimalColWidth.Location = New System.Drawing.Point(16, 71)
        Me.chkDisableSetOptimalColWidth.Margin = New System.Windows.Forms.Padding(4)
        Me.chkDisableSetOptimalColWidth.Name = "chkDisableSetOptimalColWidth"
        Me.chkDisableSetOptimalColWidth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkDisableSetOptimalColWidth.Size = New System.Drawing.Size(433, 21)
        Me.chkDisableSetOptimalColWidth.TabIndex = 127
        Me.chkDisableSetOptimalColWidth.Text = "Disable automatic adjusting of column width"
        Me.ToolTip1.SetToolTip(Me.chkDisableSetOptimalColWidth, "By default, column width of some columns is reduced during several processes. Thi" &
        "s can slow the performance in long item lists.")
        Me.chkDisableSetOptimalColWidth.UseVisualStyleBackColor = False
        '
        'cmdOK
        '
        Me.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(197, 562)
        Me.cmdOK.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(97, 31)
        Me.cmdOK.TabIndex = 0
        Me.cmdOK.Tag = "OK"
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(307, 562)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(97, 31)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Tag = "Cancel"
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdApply
        '
        Me.cmdApply.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdApply.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdApply.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdApply.Location = New System.Drawing.Point(413, 562)
        Me.cmdApply.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdApply.Size = New System.Drawing.Size(97, 31)
        Me.cmdApply.TabIndex = 2
        Me.cmdApply.Tag = "&Apply"
        Me.cmdApply.Text = "&Apply"
        Me.cmdApply.UseVisualStyleBackColor = False
        '
        '_picOptions_3
        '
        Me._picOptions_3.BackColor = System.Drawing.SystemColors.Control
        Me._picOptions_3.Controls.Add(Me.fraSample4)
        Me._picOptions_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._picOptions_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._picOptions_3.Location = New System.Drawing.Point(-1777, 39)
        Me._picOptions_3.Margin = New System.Windows.Forms.Padding(4)
        Me._picOptions_3.Name = "_picOptions_3"
        Me._picOptions_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picOptions_3.Size = New System.Drawing.Size(505, 310)
        Me._picOptions_3.TabIndex = 4
        '
        'fraSample4
        '
        Me.fraSample4.BackColor = System.Drawing.SystemColors.Control
        Me.fraSample4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraSample4.Location = New System.Drawing.Point(45, 42)
        Me.fraSample4.Margin = New System.Windows.Forms.Padding(4)
        Me.fraSample4.Name = "fraSample4"
        Me.fraSample4.Padding = New System.Windows.Forms.Padding(4)
        Me.fraSample4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraSample4.Size = New System.Drawing.Size(181, 166)
        Me.fraSample4.TabIndex = 8
        Me.fraSample4.TabStop = False
        Me.fraSample4.Tag = "Sample 4"
        Me.fraSample4.Text = "Sample 4"
        '
        '_picOptions_2
        '
        Me._picOptions_2.BackColor = System.Drawing.SystemColors.Control
        Me._picOptions_2.Controls.Add(Me.fraSample3)
        Me._picOptions_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._picOptions_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._picOptions_2.Location = New System.Drawing.Point(-1777, 39)
        Me._picOptions_2.Margin = New System.Windows.Forms.Padding(4)
        Me._picOptions_2.Name = "_picOptions_2"
        Me._picOptions_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picOptions_2.Size = New System.Drawing.Size(505, 310)
        Me._picOptions_2.TabIndex = 6
        '
        'fraSample3
        '
        Me.fraSample3.BackColor = System.Drawing.SystemColors.Control
        Me.fraSample3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraSample3.Location = New System.Drawing.Point(37, 33)
        Me.fraSample3.Margin = New System.Windows.Forms.Padding(4)
        Me.fraSample3.Name = "fraSample3"
        Me.fraSample3.Padding = New System.Windows.Forms.Padding(4)
        Me.fraSample3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraSample3.Size = New System.Drawing.Size(181, 166)
        Me.fraSample3.TabIndex = 7
        Me.fraSample3.TabStop = False
        Me.fraSample3.Tag = "Sample 3"
        Me.fraSample3.Text = "Sample 3"
        '
        '_picOptions_1
        '
        Me._picOptions_1.BackColor = System.Drawing.SystemColors.Control
        Me._picOptions_1.Controls.Add(Me.fraSample2)
        Me._picOptions_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._picOptions_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._picOptions_1.Location = New System.Drawing.Point(-1777, 39)
        Me._picOptions_1.Margin = New System.Windows.Forms.Padding(4)
        Me._picOptions_1.Name = "_picOptions_1"
        Me._picOptions_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._picOptions_1.Size = New System.Drawing.Size(505, 310)
        Me._picOptions_1.TabIndex = 3
        '
        'fraSample2
        '
        Me.fraSample2.BackColor = System.Drawing.SystemColors.Control
        Me.fraSample2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraSample2.Location = New System.Drawing.Point(28, 26)
        Me.fraSample2.Margin = New System.Windows.Forms.Padding(4)
        Me.fraSample2.Name = "fraSample2"
        Me.fraSample2.Padding = New System.Windows.Forms.Padding(4)
        Me.fraSample2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraSample2.Size = New System.Drawing.Size(181, 166)
        Me.fraSample2.TabIndex = 5
        Me.fraSample2.TabStop = False
        Me.fraSample2.Tag = "Sample 2"
        Me.fraSample2.Text = "Sample 2"
        '
        'sstOptions
        '
        Me.sstOptions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sstOptions.Controls.Add(Me._sstOptions_GeneralTab)
        Me.sstOptions.Controls.Add(Me._sstOptions_ItemListTab)
        Me.sstOptions.Controls.Add(Me._sstOptions_PdTab)
        Me.sstOptions.Controls.Add(Me._sstOptions_UnityTab)
        Me.sstOptions.Controls.Add(Me._sstOptions_RIBTab)
        Me.sstOptions.Controls.Add(Me._sstOptions_RIB2Tab)
        Me.sstOptions.Controls.Add(Me._sstOptions_MatlabTab)
        Me.sstOptions.Controls.Add(Me._sstOptions_TrackerTab)
        Me.sstOptions.Controls.Add(Me._sstOptions_TurntableTab)
        Me.sstOptions.Controls.Add(Me._sstOptions_TabPage7)
        Me.sstOptions.Controls.Add(Me._sstOptions_Joypad)
        Me.sstOptions.Controls.Add(Me.TabPage1)
        Me.sstOptions.ItemSize = New System.Drawing.Size(42, 18)
        Me.sstOptions.Location = New System.Drawing.Point(11, 15)
        Me.sstOptions.Margin = New System.Windows.Forms.Padding(4)
        Me.sstOptions.Multiline = True
        Me.sstOptions.Name = "sstOptions"
        Me.sstOptions.SelectedIndex = 0
        Me.sstOptions.Size = New System.Drawing.Size(683, 505)
        Me.sstOptions.TabIndex = 9
        '
        '_sstOptions_GeneralTab
        '
        Me._sstOptions_GeneralTab.Controls.Add(Me.chkAutoBackupLogFileSilent)
        Me._sstOptions_GeneralTab.Controls.Add(Me.cmbPriority)
        Me._sstOptions_GeneralTab.Controls.Add(Me.Label29)
        Me._sstOptions_GeneralTab.Controls.Add(Me.cmbWavExp)
        Me._sstOptions_GeneralTab.Controls.Add(Me.cmbWaveEndExp)
        Me._sstOptions_GeneralTab.Controls.Add(Me.chkPlayWaveExp)
        Me._sstOptions_GeneralTab.Controls.Add(Me.cmbBeepExp)
        Me._sstOptions_GeneralTab.Controls.Add(Me.chkBeepOnItem)
        Me._sstOptions_GeneralTab.Controls.Add(Me.cmdOptionsDir)
        Me._sstOptions_GeneralTab.Controls.Add(Me.Label28)
        Me._sstOptions_GeneralTab.Controls.Add(Me.UpdateInterval)
        Me._sstOptions_GeneralTab.Controls.Add(Me.chkCheckForUpdates)
        Me._sstOptions_GeneralTab.Controls.Add(Me.txtOptionsFile)
        Me._sstOptions_GeneralTab.Controls.Add(Me.lblOptionsFile)
        Me._sstOptions_GeneralTab.Controls.Add(Me.Label12)
        Me._sstOptions_GeneralTab.Controls.Add(Me.cmbLogMode)
        Me._sstOptions_GeneralTab.Controls.Add(Me.chkAutoBackupLogFile)
        Me._sstOptions_GeneralTab.Controls.Add(Me.chkUseBeepExp)
        Me._sstOptions_GeneralTab.Controls.Add(Me.cmdBeepExp)
        Me._sstOptions_GeneralTab.Location = New System.Drawing.Point(4, 40)
        Me._sstOptions_GeneralTab.Margin = New System.Windows.Forms.Padding(4)
        Me._sstOptions_GeneralTab.Name = "_sstOptions_GeneralTab"
        Me._sstOptions_GeneralTab.Size = New System.Drawing.Size(675, 461)
        Me._sstOptions_GeneralTab.TabIndex = 0
        Me._sstOptions_GeneralTab.Text = "General"
        Me._sstOptions_GeneralTab.UseVisualStyleBackColor = True
        '
        'cmbPriority
        '
        Me.cmbPriority.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPriority.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbPriority.Location = New System.Drawing.Point(128, 127)
        Me.cmbPriority.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPriority.Name = "cmbPriority"
        Me.cmbPriority.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbPriority.Size = New System.Drawing.Size(199, 24)
        Me.cmbPriority.TabIndex = 127
        '
        'cmbWavExp
        '
        Me.cmbWavExp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbWavExp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbWavExp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWavExp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbWavExp.Location = New System.Drawing.Point(255, 84)
        Me.cmbWavExp.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbWavExp.Name = "cmbWavExp"
        Me.cmbWavExp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbWavExp.Size = New System.Drawing.Size(339, 24)
        Me.cmbWavExp.TabIndex = 126
        '
        'cmbBeepExp
        '
        Me.cmbBeepExp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbBeepExp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbBeepExp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBeepExp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbBeepExp.Location = New System.Drawing.Point(485, 129)
        Me.cmbBeepExp.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbBeepExp.Name = "cmbBeepExp"
        Me.cmbBeepExp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbBeepExp.Size = New System.Drawing.Size(168, 24)
        Me.cmbBeepExp.TabIndex = 36
        Me.cmbBeepExp.Visible = False
        '
        'chkBeepOnItem
        '
        Me.chkBeepOnItem.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkBeepOnItem.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkBeepOnItem.Location = New System.Drawing.Point(451, 114)
        Me.chkBeepOnItem.Margin = New System.Windows.Forms.Padding(4)
        Me.chkBeepOnItem.Name = "chkBeepOnItem"
        Me.chkBeepOnItem.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkBeepOnItem.Size = New System.Drawing.Size(204, 22)
        Me.chkBeepOnItem.TabIndex = 38
        Me.chkBeepOnItem.Text = "... on every item"
        Me.chkBeepOnItem.UseVisualStyleBackColor = False
        Me.chkBeepOnItem.Visible = False
        '
        'txtOptionsFile
        '
        Me.txtOptionsFile.AcceptsReturn = True
        Me.txtOptionsFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOptionsFile.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtOptionsFile.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOptionsFile.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOptionsFile.Location = New System.Drawing.Point(128, 210)
        Me.txtOptionsFile.Margin = New System.Windows.Forms.Padding(4)
        Me.txtOptionsFile.MaxLength = 0
        Me.txtOptionsFile.Name = "txtOptionsFile"
        Me.txtOptionsFile.ReadOnly = True
        Me.txtOptionsFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOptionsFile.Size = New System.Drawing.Size(465, 22)
        Me.txtOptionsFile.TabIndex = 46
        '
        'lblOptionsFile
        '
        Me.lblOptionsFile.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblOptionsFile.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOptionsFile.Location = New System.Drawing.Point(12, 210)
        Me.lblOptionsFile.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOptionsFile.Name = "lblOptionsFile"
        Me.lblOptionsFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblOptionsFile.Size = New System.Drawing.Size(105, 25)
        Me.lblOptionsFile.TabIndex = 47
        Me.lblOptionsFile.Text = "Options File:"
        Me.lblOptionsFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbLogMode
        '
        Me.cmbLogMode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbLogMode.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbLogMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLogMode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbLogMode.Location = New System.Drawing.Point(128, 44)
        Me.cmbLogMode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbLogMode.Name = "cmbLogMode"
        Me.cmbLogMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbLogMode.Size = New System.Drawing.Size(465, 24)
        Me.cmbLogMode.TabIndex = 43
        '
        'chkAutoBackupLogFile
        '
        Me.chkAutoBackupLogFile.AutoSize = True
        Me.chkAutoBackupLogFile.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkAutoBackupLogFile.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAutoBackupLogFile.Location = New System.Drawing.Point(16, 17)
        Me.chkAutoBackupLogFile.Margin = New System.Windows.Forms.Padding(4)
        Me.chkAutoBackupLogFile.Name = "chkAutoBackupLogFile"
        Me.chkAutoBackupLogFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkAutoBackupLogFile.Size = New System.Drawing.Size(246, 21)
        Me.chkAutoBackupLogFile.TabIndex = 29
        Me.chkAutoBackupLogFile.Text = "Save Log File when Disconnecting"
        Me.chkAutoBackupLogFile.UseVisualStyleBackColor = False
        '
        'chkUseBeepExp
        '
        Me.chkUseBeepExp.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkUseBeepExp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkUseBeepExp.Location = New System.Drawing.Point(405, 129)
        Me.chkUseBeepExp.Margin = New System.Windows.Forms.Padding(4)
        Me.chkUseBeepExp.Name = "chkUseBeepExp"
        Me.chkUseBeepExp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkUseBeepExp.Size = New System.Drawing.Size(269, 21)
        Me.chkUseBeepExp.TabIndex = 35
        Me.chkUseBeepExp.Text = "Use Beeps in experiment (32bit OS)"
        Me.chkUseBeepExp.UseVisualStyleBackColor = False
        Me.chkUseBeepExp.Visible = False
        '
        '_sstOptions_ItemListTab
        '
        Me._sstOptions_ItemListTab.Controls.Add(Me.gbWarnings)
        Me._sstOptions_ItemListTab.Controls.Add(Me.chkUseFileNaming)
        Me._sstOptions_ItemListTab.Controls.Add(Me.chkDisableSetOptimalColWidth)
        Me._sstOptions_ItemListTab.Controls.Add(Me.chkAutoBackupItemList)
        Me._sstOptions_ItemListTab.Controls.Add(Me.ckbIncludeHeadersInClipboard)
        Me._sstOptions_ItemListTab.Controls.Add(Me.gbCSVExportImport)
        Me._sstOptions_ItemListTab.Location = New System.Drawing.Point(4, 40)
        Me._sstOptions_ItemListTab.Margin = New System.Windows.Forms.Padding(4)
        Me._sstOptions_ItemListTab.Name = "_sstOptions_ItemListTab"
        Me._sstOptions_ItemListTab.Size = New System.Drawing.Size(675, 461)
        Me._sstOptions_ItemListTab.TabIndex = 4
        Me._sstOptions_ItemListTab.Text = "Item List"
        Me._sstOptions_ItemListTab.UseVisualStyleBackColor = True
        '
        'gbWarnings
        '
        Me.gbWarnings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbWarnings.Controls.Add(Me.btnDisableAllWarnings)
        Me.gbWarnings.Controls.Add(Me.btnEnableAllWarnings)
        Me.gbWarnings.Controls.Add(Me.chkResponseItemListOnExpRep)
        Me.gbWarnings.Controls.Add(Me.chkExpPerformedOnShuffle)
        Me.gbWarnings.Controls.Add(Me.chkNotShuffledOnExpStart)
        Me.gbWarnings.Controls.Add(Me.chkNotRepOnExpStart)
        Me.gbWarnings.Location = New System.Drawing.Point(5, 127)
        Me.gbWarnings.Margin = New System.Windows.Forms.Padding(4)
        Me.gbWarnings.Name = "gbWarnings"
        Me.gbWarnings.Padding = New System.Windows.Forms.Padding(4)
        Me.gbWarnings.Size = New System.Drawing.Size(663, 142)
        Me.gbWarnings.TabIndex = 129
        Me.gbWarnings.TabStop = False
        Me.gbWarnings.Text = "Warnings"
        '
        'btnDisableAllWarnings
        '
        Me.btnDisableAllWarnings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDisableAllWarnings.Location = New System.Drawing.Point(555, 59)
        Me.btnDisableAllWarnings.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDisableAllWarnings.Name = "btnDisableAllWarnings"
        Me.btnDisableAllWarnings.Size = New System.Drawing.Size(85, 28)
        Me.btnDisableAllWarnings.TabIndex = 48
        Me.btnDisableAllWarnings.Text = "Disable all"
        Me.btnDisableAllWarnings.UseVisualStyleBackColor = True
        '
        'btnEnableAllWarnings
        '
        Me.btnEnableAllWarnings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEnableAllWarnings.Location = New System.Drawing.Point(555, 23)
        Me.btnEnableAllWarnings.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEnableAllWarnings.Name = "btnEnableAllWarnings"
        Me.btnEnableAllWarnings.Size = New System.Drawing.Size(85, 28)
        Me.btnEnableAllWarnings.TabIndex = 47
        Me.btnEnableAllWarnings.Text = "Enable all"
        Me.btnEnableAllWarnings.UseVisualStyleBackColor = True
        '
        'chkResponseItemListOnExpRep
        '
        Me.chkResponseItemListOnExpRep.AutoSize = True
        Me.chkResponseItemListOnExpRep.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkResponseItemListOnExpRep.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkResponseItemListOnExpRep.Location = New System.Drawing.Point(11, 105)
        Me.chkResponseItemListOnExpRep.Margin = New System.Windows.Forms.Padding(4)
        Me.chkResponseItemListOnExpRep.Name = "chkResponseItemListOnExpRep"
        Me.chkResponseItemListOnExpRep.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkResponseItemListOnExpRep.Size = New System.Drawing.Size(409, 21)
        Me.chkResponseItemListOnExpRep.TabIndex = 46
        Me.chkResponseItemListOnExpRep.Text = "Warn if item list contains responses on experiment repetition"
        Me.chkResponseItemListOnExpRep.UseVisualStyleBackColor = False
        '
        'chkExpPerformedOnShuffle
        '
        Me.chkExpPerformedOnShuffle.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkExpPerformedOnShuffle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkExpPerformedOnShuffle.Location = New System.Drawing.Point(11, 78)
        Me.chkExpPerformedOnShuffle.Margin = New System.Windows.Forms.Padding(4)
        Me.chkExpPerformedOnShuffle.Name = "chkExpPerformedOnShuffle"
        Me.chkExpPerformedOnShuffle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkExpPerformedOnShuffle.Size = New System.Drawing.Size(379, 21)
        Me.chkExpPerformedOnShuffle.TabIndex = 45
        Me.chkExpPerformedOnShuffle.Text = "Warn if experiment performed on shuffle "
        Me.chkExpPerformedOnShuffle.UseVisualStyleBackColor = False
        '
        'chkNotShuffledOnExpStart
        '
        Me.chkNotShuffledOnExpStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkNotShuffledOnExpStart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkNotShuffledOnExpStart.Location = New System.Drawing.Point(11, 23)
        Me.chkNotShuffledOnExpStart.Margin = New System.Windows.Forms.Padding(4)
        Me.chkNotShuffledOnExpStart.Name = "chkNotShuffledOnExpStart"
        Me.chkNotShuffledOnExpStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkNotShuffledOnExpStart.Size = New System.Drawing.Size(379, 21)
        Me.chkNotShuffledOnExpStart.TabIndex = 43
        Me.chkNotShuffledOnExpStart.Text = "Warn if not shuffled on experiment start"
        Me.chkNotShuffledOnExpStart.UseVisualStyleBackColor = False
        '
        'chkNotRepOnExpStart
        '
        Me.chkNotRepOnExpStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkNotRepOnExpStart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkNotRepOnExpStart.Location = New System.Drawing.Point(11, 50)
        Me.chkNotRepOnExpStart.Margin = New System.Windows.Forms.Padding(4)
        Me.chkNotRepOnExpStart.Name = "chkNotRepOnExpStart"
        Me.chkNotRepOnExpStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkNotRepOnExpStart.Size = New System.Drawing.Size(379, 21)
        Me.chkNotRepOnExpStart.TabIndex = 44
        Me.chkNotRepOnExpStart.Text = "Warn if not repeated on experiment start"
        Me.chkNotRepOnExpStart.UseVisualStyleBackColor = False
        '
        'chkUseFileNaming
        '
        Me.chkUseFileNaming.AutoSize = True
        Me.chkUseFileNaming.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkUseFileNaming.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkUseFileNaming.Location = New System.Drawing.Point(16, 44)
        Me.chkUseFileNaming.Margin = New System.Windows.Forms.Padding(4)
        Me.chkUseFileNaming.Name = "chkUseFileNaming"
        Me.chkUseFileNaming.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkUseFileNaming.Size = New System.Drawing.Size(422, 21)
        Me.chkUseFileNaming.TabIndex = 128
        Me.chkUseFileNaming.Text = "Save Item List: Use file naming according to file structure rules"
        Me.chkUseFileNaming.UseVisualStyleBackColor = False
        '
        'gbCSVExportImport
        '
        Me.gbCSVExportImport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbCSVExportImport.Controls.Add(Me.tbItemListPreview)
        Me.gbCSVExportImport.Controls.Add(Me._Label9_0)
        Me.gbCSVExportImport.Controls.Add(Me._Label9_1)
        Me.gbCSVExportImport.Controls.Add(Me.txtCSVQuota)
        Me.gbCSVExportImport.Controls.Add(Me.txtCSVDelimiter)
        Me.gbCSVExportImport.Location = New System.Drawing.Point(4, 276)
        Me.gbCSVExportImport.Margin = New System.Windows.Forms.Padding(4)
        Me.gbCSVExportImport.Name = "gbCSVExportImport"
        Me.gbCSVExportImport.Padding = New System.Windows.Forms.Padding(4)
        Me.gbCSVExportImport.Size = New System.Drawing.Size(663, 134)
        Me.gbCSVExportImport.TabIndex = 86
        Me.gbCSVExportImport.TabStop = False
        Me.gbCSVExportImport.Text = "CSV Export/Import"
        '
        'tbItemListPreview
        '
        Me.tbItemListPreview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbItemListPreview.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbItemListPreview.Location = New System.Drawing.Point(221, 15)
        Me.tbItemListPreview.Margin = New System.Windows.Forms.Padding(4)
        Me.tbItemListPreview.Multiline = True
        Me.tbItemListPreview.Name = "tbItemListPreview"
        Me.tbItemListPreview.Size = New System.Drawing.Size(433, 111)
        Me.tbItemListPreview.TabIndex = 47
        Me.tbItemListPreview.Text = "tbItemListPreview"
        '
        '_Label9_0
        '
        Me._Label9_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label9_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label9_0.Location = New System.Drawing.Point(8, 38)
        Me._Label9_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label9_0.Name = "_Label9_0"
        Me._Label9_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label9_0.Size = New System.Drawing.Size(135, 16)
        Me._Label9_0.TabIndex = 43
        Me._Label9_0.Text = "Delimiter character:"
        Me._Label9_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Label9_1
        '
        Me._Label9_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label9_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label9_1.Location = New System.Drawing.Point(8, 65)
        Me._Label9_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label9_1.Name = "_Label9_1"
        Me._Label9_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label9_1.Size = New System.Drawing.Size(135, 16)
        Me._Label9_1.TabIndex = 45
        Me._Label9_1.Text = "Quota character:"
        Me._Label9_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtCSVQuota
        '
        Me.txtCSVQuota.AcceptsReturn = True
        Me.txtCSVQuota.BackColor = System.Drawing.SystemColors.Window
        Me.txtCSVQuota.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCSVQuota.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCSVQuota.Location = New System.Drawing.Point(152, 60)
        Me.txtCSVQuota.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCSVQuota.MaxLength = 0
        Me.txtCSVQuota.Name = "txtCSVQuota"
        Me.txtCSVQuota.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCSVQuota.Size = New System.Drawing.Size(21, 22)
        Me.txtCSVQuota.TabIndex = 46
        Me.txtCSVQuota.Text = """"
        '
        'txtCSVDelimiter
        '
        Me.txtCSVDelimiter.AcceptsReturn = True
        Me.txtCSVDelimiter.BackColor = System.Drawing.SystemColors.Window
        Me.txtCSVDelimiter.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCSVDelimiter.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCSVDelimiter.Location = New System.Drawing.Point(152, 33)
        Me.txtCSVDelimiter.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCSVDelimiter.MaxLength = 0
        Me.txtCSVDelimiter.Name = "txtCSVDelimiter"
        Me.txtCSVDelimiter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCSVDelimiter.Size = New System.Drawing.Size(21, 22)
        Me.txtCSVDelimiter.TabIndex = 44
        Me.txtCSVDelimiter.Text = ","
        '
        '_sstOptions_UnityTab
        '
        Me._sstOptions_UnityTab.Controls.Add(Me.lblUnityLocalPort)
        Me._sstOptions_UnityTab.Controls.Add(Me.txtUnityAddr)
        Me._sstOptions_UnityTab.Controls.Add(Me.txtUnityPort)
        Me._sstOptions_UnityTab.Controls.Add(Me.txtUnityLocalPort)
        Me._sstOptions_UnityTab.Controls.Add(Me.Label31)
        Me._sstOptions_UnityTab.Controls.Add(Me.Label32)
        Me._sstOptions_UnityTab.Controls.Add(Me.Label34)
        Me._sstOptions_UnityTab.Controls.Add(Me.Label37)
        Me._sstOptions_UnityTab.Location = New System.Drawing.Point(4, 40)
        Me._sstOptions_UnityTab.Margin = New System.Windows.Forms.Padding(4)
        Me._sstOptions_UnityTab.Name = "_sstOptions_UnityTab"
        Me._sstOptions_UnityTab.Padding = New System.Windows.Forms.Padding(4)
        Me._sstOptions_UnityTab.Size = New System.Drawing.Size(675, 461)
        Me._sstOptions_UnityTab.TabIndex = 2
        Me._sstOptions_UnityTab.Text = "Audio (Unity)"
        Me._sstOptions_UnityTab.UseVisualStyleBackColor = True
        '
        'lblUnityLocalPort
        '
        Me.lblUnityLocalPort.AutoSize = True
        Me.lblUnityLocalPort.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblUnityLocalPort.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUnityLocalPort.Location = New System.Drawing.Point(23, 65)
        Me.lblUnityLocalPort.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUnityLocalPort.Name = "lblUnityLocalPort"
        Me.lblUnityLocalPort.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblUnityLocalPort.Size = New System.Drawing.Size(250, 17)
        Me.lblUnityLocalPort.TabIndex = 91
        Me.lblUnityLocalPort.Text = "Local:   Address: see Audio (Pd)/Local"
        '
        'txtUnityAddr
        '
        Me.txtUnityAddr.AcceptsReturn = True
        Me.txtUnityAddr.BackColor = System.Drawing.SystemColors.Window
        Me.txtUnityAddr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUnityAddr.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtUnityAddr.Location = New System.Drawing.Point(141, 23)
        Me.txtUnityAddr.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUnityAddr.MaxLength = 0
        Me.txtUnityAddr.Name = "txtUnityAddr"
        Me.txtUnityAddr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtUnityAddr.Size = New System.Drawing.Size(180, 22)
        Me.txtUnityAddr.TabIndex = 20
        '
        'txtUnityPort
        '
        Me.txtUnityPort.AcceptsReturn = True
        Me.txtUnityPort.BackColor = System.Drawing.SystemColors.Window
        Me.txtUnityPort.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUnityPort.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtUnityPort.Location = New System.Drawing.Point(381, 23)
        Me.txtUnityPort.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUnityPort.MaxLength = 5
        Me.txtUnityPort.Name = "txtUnityPort"
        Me.txtUnityPort.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtUnityPort.Size = New System.Drawing.Size(64, 22)
        Me.txtUnityPort.TabIndex = 21
        '
        'txtUnityLocalPort
        '
        Me.txtUnityLocalPort.AcceptsReturn = True
        Me.txtUnityLocalPort.BackColor = System.Drawing.SystemColors.Window
        Me.txtUnityLocalPort.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUnityLocalPort.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtUnityLocalPort.Location = New System.Drawing.Point(381, 60)
        Me.txtUnityLocalPort.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUnityLocalPort.MaxLength = 5
        Me.txtUnityLocalPort.Name = "txtUnityLocalPort"
        Me.txtUnityLocalPort.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtUnityLocalPort.Size = New System.Drawing.Size(64, 22)
        Me.txtUnityLocalPort.TabIndex = 25
        '
        'Label31
        '
        Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(23, 28)
        Me.Label31.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label31.Size = New System.Drawing.Size(53, 20)
        Me.Label31.TabIndex = 29
        Me.Label31.Text = "Unity:"
        '
        'Label32
        '
        Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(68, 28)
        Me.Label32.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label32.Size = New System.Drawing.Size(69, 20)
        Me.Label32.TabIndex = 28
        Me.Label32.Text = "Address:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label34
        '
        Me.Label34.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.Location = New System.Drawing.Point(331, 27)
        Me.Label34.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label34.Size = New System.Drawing.Size(47, 21)
        Me.Label34.TabIndex = 27
        Me.Label34.Text = "Port:"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label37.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label37.Location = New System.Drawing.Point(339, 65)
        Me.Label37.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label37.Size = New System.Drawing.Size(38, 17)
        Me.Label37.TabIndex = 22
        Me.Label37.Text = "Port:"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_sstOptions_RIBTab
        '
        Me._sstOptions_RIBTab.Controls.Add(Me.lblRIBPath)
        Me._sstOptions_RIBTab.Controls.Add(Me.cmdRIBPath)
        Me._sstOptions_RIBTab.Controls.Add(Me.txtRIBPath)
        Me._sstOptions_RIBTab.Controls.Add(Me.Label2)
        Me._sstOptions_RIBTab.Controls.Add(Me.cmbComLeft)
        Me._sstOptions_RIBTab.Controls.Add(Me.cmbComRight)
        Me._sstOptions_RIBTab.Controls.Add(Me.txtRIBServer)
        Me._sstOptions_RIBTab.Controls.Add(Me.chkSimulation)
        Me._sstOptions_RIBTab.Controls.Add(Me._Label2_0)
        Me._sstOptions_RIBTab.Controls.Add(Me.Label3)
        Me._sstOptions_RIBTab.Controls.Add(Me.Label6)
        Me._sstOptions_RIBTab.Location = New System.Drawing.Point(4, 40)
        Me._sstOptions_RIBTab.Margin = New System.Windows.Forms.Padding(4)
        Me._sstOptions_RIBTab.Name = "_sstOptions_RIBTab"
        Me._sstOptions_RIBTab.Size = New System.Drawing.Size(675, 461)
        Me._sstOptions_RIBTab.TabIndex = 3
        Me._sstOptions_RIBTab.Text = "RIB"
        Me._sstOptions_RIBTab.UseVisualStyleBackColor = True
        '
        'lblRIBPath
        '
        Me.lblRIBPath.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRIBPath.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblRIBPath.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRIBPath.Location = New System.Drawing.Point(71, 222)
        Me.lblRIBPath.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRIBPath.Name = "lblRIBPath"
        Me.lblRIBPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblRIBPath.Size = New System.Drawing.Size(707, 187)
        Me.lblRIBPath.TabIndex = 87
        Me.lblRIBPath.Text = "Allowed path names: absolute OR relative to:"
        '
        'cmdRIBPath
        '
        Me.cmdRIBPath.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRIBPath.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRIBPath.Location = New System.Drawing.Point(444, 187)
        Me.cmdRIBPath.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdRIBPath.Name = "cmdRIBPath"
        Me.cmdRIBPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRIBPath.Size = New System.Drawing.Size(33, 26)
        Me.cmdRIBPath.TabIndex = 86
        Me.cmdRIBPath.Text = "..."
        Me.cmdRIBPath.UseVisualStyleBackColor = False
        '
        'txtRIBPath
        '
        Me.txtRIBPath.AcceptsReturn = True
        Me.txtRIBPath.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRIBPath.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRIBPath.Location = New System.Drawing.Point(199, 187)
        Me.txtRIBPath.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRIBPath.MaxLength = 0
        Me.txtRIBPath.Name = "txtRIBPath"
        Me.txtRIBPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRIBPath.Size = New System.Drawing.Size(217, 22)
        Me.txtRIBPath.TabIndex = 85
        '
        'Label2
        '
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(47, 191)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(143, 20)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "Path to RIB Files:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbComLeft
        '
        Me.cmbComLeft.BackColor = System.Drawing.SystemColors.Window
        Me.cmbComLeft.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbComLeft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComLeft.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbComLeft.Location = New System.Drawing.Point(199, 69)
        Me.cmbComLeft.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbComLeft.Name = "cmbComLeft"
        Me.cmbComLeft.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbComLeft.Size = New System.Drawing.Size(117, 24)
        Me.cmbComLeft.TabIndex = 25
        '
        'cmbComRight
        '
        Me.cmbComRight.BackColor = System.Drawing.SystemColors.Window
        Me.cmbComRight.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbComRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComRight.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbComRight.Location = New System.Drawing.Point(199, 108)
        Me.cmbComRight.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbComRight.Name = "cmbComRight"
        Me.cmbComRight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbComRight.Size = New System.Drawing.Size(117, 24)
        Me.cmbComRight.TabIndex = 24
        '
        'txtRIBServer
        '
        Me.txtRIBServer.AcceptsReturn = True
        Me.txtRIBServer.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRIBServer.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRIBServer.Location = New System.Drawing.Point(199, 148)
        Me.txtRIBServer.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRIBServer.MaxLength = 0
        Me.txtRIBServer.Name = "txtRIBServer"
        Me.txtRIBServer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRIBServer.Size = New System.Drawing.Size(217, 22)
        Me.txtRIBServer.TabIndex = 23
        '
        'chkSimulation
        '
        Me.chkSimulation.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSimulation.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkSimulation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkSimulation.Location = New System.Drawing.Point(93, 32)
        Me.chkSimulation.Margin = New System.Windows.Forms.Padding(4)
        Me.chkSimulation.Name = "chkSimulation"
        Me.chkSimulation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkSimulation.Size = New System.Drawing.Size(124, 25)
        Me.chkSimulation.TabIndex = 22
        Me.chkSimulation.Text = "Simulate RIB:"
        Me.chkSimulation.UseVisualStyleBackColor = False
        '
        '_Label2_0
        '
        Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_0.Location = New System.Drawing.Point(40, 74)
        Me._Label2_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label2_0.Name = "_Label2_0"
        Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_0.Size = New System.Drawing.Size(149, 21)
        Me._Label2_0.TabIndex = 28
        Me._Label2_0.Text = "COM port, Left RIB:"
        Me._Label2_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(33, 113)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(156, 21)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "COM port, Right RIB:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(89, 153)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(100, 16)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "RIB server:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_sstOptions_RIB2Tab
        '
        Me._sstOptions_RIB2Tab.Controls.Add(Me.lblRIB2Path)
        Me._sstOptions_RIB2Tab.Controls.Add(Me.cmdRIB2Path)
        Me._sstOptions_RIB2Tab.Controls.Add(Me.txtRIB2Path)
        Me._sstOptions_RIB2Tab.Controls.Add(Me.Label30)
        Me._sstOptions_RIB2Tab.Controls.Add(Me.txtRIB2Device)
        Me._sstOptions_RIB2Tab.Controls.Add(Me.chkRIB2Simulation)
        Me._sstOptions_RIB2Tab.Controls.Add(Me.Label33)
        Me._sstOptions_RIB2Tab.Location = New System.Drawing.Point(4, 40)
        Me._sstOptions_RIB2Tab.Margin = New System.Windows.Forms.Padding(4)
        Me._sstOptions_RIB2Tab.Name = "_sstOptions_RIB2Tab"
        Me._sstOptions_RIB2Tab.Padding = New System.Windows.Forms.Padding(4)
        Me._sstOptions_RIB2Tab.Size = New System.Drawing.Size(675, 461)
        Me._sstOptions_RIB2Tab.TabIndex = 11
        Me._sstOptions_RIB2Tab.Text = "RIB2"
        Me._sstOptions_RIB2Tab.UseVisualStyleBackColor = True
        '
        'lblRIB2Path
        '
        Me.lblRIB2Path.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRIB2Path.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblRIB2Path.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRIB2Path.Location = New System.Drawing.Point(71, 145)
        Me.lblRIB2Path.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRIB2Path.Name = "lblRIB2Path"
        Me.lblRIB2Path.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblRIB2Path.Size = New System.Drawing.Size(707, 187)
        Me.lblRIB2Path.TabIndex = 98
        Me.lblRIB2Path.Text = "Allowed path names: absolute OR relative to:"
        '
        'cmdRIB2Path
        '
        Me.cmdRIB2Path.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRIB2Path.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRIB2Path.Location = New System.Drawing.Point(444, 108)
        Me.cmdRIB2Path.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdRIB2Path.Name = "cmdRIB2Path"
        Me.cmdRIB2Path.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRIB2Path.Size = New System.Drawing.Size(33, 26)
        Me.cmdRIB2Path.TabIndex = 97
        Me.cmdRIB2Path.Text = "..."
        Me.cmdRIB2Path.UseVisualStyleBackColor = False
        '
        'txtRIB2Path
        '
        Me.txtRIB2Path.AcceptsReturn = True
        Me.txtRIB2Path.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRIB2Path.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRIB2Path.Location = New System.Drawing.Point(199, 108)
        Me.txtRIB2Path.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRIB2Path.MaxLength = 0
        Me.txtRIB2Path.Name = "txtRIB2Path"
        Me.txtRIB2Path.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRIB2Path.Size = New System.Drawing.Size(217, 22)
        Me.txtRIB2Path.TabIndex = 96
        '
        'Label30
        '
        Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(47, 112)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label30.Size = New System.Drawing.Size(143, 20)
        Me.Label30.TabIndex = 95
        Me.Label30.Text = "Path to RIB2 Files:"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtRIB2Device
        '
        Me.txtRIB2Device.AcceptsReturn = True
        Me.txtRIB2Device.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRIB2Device.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRIB2Device.Location = New System.Drawing.Point(199, 69)
        Me.txtRIB2Device.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRIB2Device.MaxLength = 0
        Me.txtRIB2Device.Name = "txtRIB2Device"
        Me.txtRIB2Device.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRIB2Device.Size = New System.Drawing.Size(217, 22)
        Me.txtRIB2Device.TabIndex = 89
        '
        'chkRIB2Simulation
        '
        Me.chkRIB2Simulation.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkRIB2Simulation.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkRIB2Simulation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkRIB2Simulation.Location = New System.Drawing.Point(80, 32)
        Me.chkRIB2Simulation.Margin = New System.Windows.Forms.Padding(4)
        Me.chkRIB2Simulation.Name = "chkRIB2Simulation"
        Me.chkRIB2Simulation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkRIB2Simulation.Size = New System.Drawing.Size(137, 25)
        Me.chkRIB2Simulation.TabIndex = 88
        Me.chkRIB2Simulation.Text = "Simulate RIB2:"
        Me.chkRIB2Simulation.UseVisualStyleBackColor = False
        '
        'Label33
        '
        Me.Label33.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(37, 74)
        Me.Label33.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label33.Size = New System.Drawing.Size(152, 16)
        Me.Label33.TabIndex = 92
        Me.Label33.Text = "Device name, IO-card:"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_sstOptions_MatlabTab
        '
        Me._sstOptions_MatlabTab.Controls.Add(Me.cmdMATLABPath)
        Me._sstOptions_MatlabTab.Controls.Add(Me.txtMATLABPath)
        Me._sstOptions_MatlabTab.Controls.Add(Me.chkUseMATLAB)
        Me._sstOptions_MatlabTab.Controls.Add(Me.txtMATLABServer)
        Me._sstOptions_MatlabTab.Controls.Add(Me.Label17)
        Me._sstOptions_MatlabTab.Controls.Add(Me.Label18)
        Me._sstOptions_MatlabTab.Controls.Add(Me.lblMATLABPath)
        Me._sstOptions_MatlabTab.Location = New System.Drawing.Point(4, 40)
        Me._sstOptions_MatlabTab.Margin = New System.Windows.Forms.Padding(4)
        Me._sstOptions_MatlabTab.Name = "_sstOptions_MatlabTab"
        Me._sstOptions_MatlabTab.Size = New System.Drawing.Size(675, 461)
        Me._sstOptions_MatlabTab.TabIndex = 2
        Me._sstOptions_MatlabTab.Text = "Matlab"
        Me._sstOptions_MatlabTab.UseVisualStyleBackColor = True
        '
        'cmdMATLABPath
        '
        Me.cmdMATLABPath.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdMATLABPath.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdMATLABPath.Location = New System.Drawing.Point(427, 95)
        Me.cmdMATLABPath.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdMATLABPath.Name = "cmdMATLABPath"
        Me.cmdMATLABPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdMATLABPath.Size = New System.Drawing.Size(33, 26)
        Me.cmdMATLABPath.TabIndex = 83
        Me.cmdMATLABPath.Text = "..."
        Me.cmdMATLABPath.UseVisualStyleBackColor = False
        '
        'txtMATLABPath
        '
        Me.txtMATLABPath.AcceptsReturn = True
        Me.txtMATLABPath.BackColor = System.Drawing.SystemColors.Window
        Me.txtMATLABPath.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMATLABPath.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMATLABPath.Location = New System.Drawing.Point(187, 95)
        Me.txtMATLABPath.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMATLABPath.MaxLength = 0
        Me.txtMATLABPath.Name = "txtMATLABPath"
        Me.txtMATLABPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMATLABPath.Size = New System.Drawing.Size(217, 22)
        Me.txtMATLABPath.TabIndex = 82
        '
        'chkUseMATLAB
        '
        Me.chkUseMATLAB.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkUseMATLAB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkUseMATLAB.Location = New System.Drawing.Point(32, 39)
        Me.chkUseMATLAB.Margin = New System.Windows.Forms.Padding(4)
        Me.chkUseMATLAB.Name = "chkUseMATLAB"
        Me.chkUseMATLAB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkUseMATLAB.Size = New System.Drawing.Size(257, 26)
        Me.chkUseMATLAB.TabIndex = 78
        Me.chkUseMATLAB.Text = "Use MATLAB"
        Me.chkUseMATLAB.UseVisualStyleBackColor = False
        '
        'txtMATLABServer
        '
        Me.txtMATLABServer.AcceptsReturn = True
        Me.txtMATLABServer.BackColor = System.Drawing.SystemColors.Window
        Me.txtMATLABServer.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMATLABServer.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMATLABServer.Location = New System.Drawing.Point(187, 65)
        Me.txtMATLABServer.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMATLABServer.MaxLength = 0
        Me.txtMATLABServer.Name = "txtMATLABServer"
        Me.txtMATLABServer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMATLABServer.Size = New System.Drawing.Size(217, 22)
        Me.txtMATLABServer.TabIndex = 79
        '
        'Label17
        '
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(32, 70)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(143, 20)
        Me.Label17.TabIndex = 80
        Me.Label17.Text = "Server computer:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label18
        '
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(32, 100)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(143, 20)
        Me.Label18.TabIndex = 81
        Me.Label18.Text = "Path to Matlab files:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMATLABPath
        '
        Me.lblMATLABPath.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMATLABPath.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMATLABPath.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMATLABPath.Location = New System.Drawing.Point(23, 137)
        Me.lblMATLABPath.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMATLABPath.Name = "lblMATLABPath"
        Me.lblMATLABPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMATLABPath.Size = New System.Drawing.Size(757, 271)
        Me.lblMATLABPath.TabIndex = 84
        Me.lblMATLABPath.Text = "Allowed path names: absolute OR relative to:"
        '
        '_sstOptions_TrackerTab
        '
        Me._sstOptions_TrackerTab.Controls.Add(Me.Panel2)
        Me._sstOptions_TrackerTab.Location = New System.Drawing.Point(4, 40)
        Me._sstOptions_TrackerTab.Margin = New System.Windows.Forms.Padding(4)
        Me._sstOptions_TrackerTab.Name = "_sstOptions_TrackerTab"
        Me._sstOptions_TrackerTab.Size = New System.Drawing.Size(675, 461)
        Me._sstOptions_TrackerTab.TabIndex = 5
        Me._sstOptions_TrackerTab.Text = "Tracker"
        Me._sstOptions_TrackerTab.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label45)
        Me.Panel2.Controls.Add(Me.textBoxUDPport)
        Me.Panel2.Controls.Add(Me.buttonBrowseOSCstreamerFile)
        Me.Panel2.Controls.Add(Me.Label44)
        Me.Panel2.Controls.Add(Me.textBoxOSCstreamerFile)
        Me.Panel2.Controls.Add(Me.buttonBrowseMotiveFile)
        Me.Panel2.Controls.Add(Me.Label43)
        Me.Panel2.Controls.Add(Me.textBoxMotiveFile)
        Me.Panel2.Controls.Add(Me.rdbTrackerOptitrack)
        Me.Panel2.Controls.Add(Me.rdbTrackerDisabled)
        Me.Panel2.Controls.Add(Me.rdbTrackerYAMI)
        Me.Panel2.Controls.Add(Me.pTrackerYAMI)
        Me.Panel2.Controls.Add(Me.lblTRSensorCount)
        Me.Panel2.Controls.Add(Me.rdbTrackerViWo)
        Me.Panel2.Controls.Add(Me.chkTRLog)
        Me.Panel2.Controls.Add(Me.cmbTRSensorCount)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(675, 461)
        Me.Panel2.TabIndex = 90
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(128, 407)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(171, 17)
        Me.Label45.TabIndex = 98
        Me.Label45.Text = "UDP port (Optitrack only):"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'textBoxUDPport
        '
        Me.textBoxUDPport.Location = New System.Drawing.Point(305, 404)
        Me.textBoxUDPport.Name = "textBoxUDPport"
        Me.textBoxUDPport.Size = New System.Drawing.Size(65, 22)
        Me.textBoxUDPport.TabIndex = 97
        '
        'buttonBrowseOSCstreamerFile
        '
        Me.buttonBrowseOSCstreamerFile.Location = New System.Drawing.Point(580, 377)
        Me.buttonBrowseOSCstreamerFile.Name = "buttonBrowseOSCstreamerFile"
        Me.buttonBrowseOSCstreamerFile.Size = New System.Drawing.Size(34, 23)
        Me.buttonBrowseOSCstreamerFile.TabIndex = 96
        Me.buttonBrowseOSCstreamerFile.Text = "..."
        Me.buttonBrowseOSCstreamerFile.UseVisualStyleBackColor = True
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(34, 380)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(265, 17)
        Me.Label44.TabIndex = 95
        Me.Label44.Text = "Motive OSCstreamer file (Optitrack only):"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'textBoxOSCstreamerFile
        '
        Me.textBoxOSCstreamerFile.Location = New System.Drawing.Point(305, 377)
        Me.textBoxOSCstreamerFile.Name = "textBoxOSCstreamerFile"
        Me.textBoxOSCstreamerFile.Size = New System.Drawing.Size(268, 22)
        Me.textBoxOSCstreamerFile.TabIndex = 94
        '
        'buttonBrowseMotiveFile
        '
        Me.buttonBrowseMotiveFile.Location = New System.Drawing.Point(580, 349)
        Me.buttonBrowseMotiveFile.Name = "buttonBrowseMotiveFile"
        Me.buttonBrowseMotiveFile.Size = New System.Drawing.Size(34, 23)
        Me.buttonBrowseMotiveFile.TabIndex = 93
        Me.buttonBrowseMotiveFile.Text = "..."
        Me.buttonBrowseMotiveFile.UseVisualStyleBackColor = True
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(76, 352)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(223, 17)
        Me.Label43.TabIndex = 92
        Me.Label43.Text = "Motive project file (Optitrack only):"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'textBoxMotiveFile
        '
        Me.textBoxMotiveFile.Location = New System.Drawing.Point(305, 349)
        Me.textBoxMotiveFile.Name = "textBoxMotiveFile"
        Me.textBoxMotiveFile.Size = New System.Drawing.Size(268, 22)
        Me.textBoxMotiveFile.TabIndex = 91
        '
        'rdbTrackerOptitrack
        '
        Me.rdbTrackerOptitrack.AutoSize = True
        Me.rdbTrackerOptitrack.Location = New System.Drawing.Point(16, 101)
        Me.rdbTrackerOptitrack.Margin = New System.Windows.Forms.Padding(4)
        Me.rdbTrackerOptitrack.Name = "rdbTrackerOptitrack"
        Me.rdbTrackerOptitrack.Size = New System.Drawing.Size(86, 21)
        Me.rdbTrackerOptitrack.TabIndex = 90
        Me.rdbTrackerOptitrack.TabStop = True
        Me.rdbTrackerOptitrack.Text = "Optitrack"
        Me.rdbTrackerOptitrack.UseVisualStyleBackColor = True
        '
        'rdbTrackerDisabled
        '
        Me.rdbTrackerDisabled.AutoSize = True
        Me.rdbTrackerDisabled.Location = New System.Drawing.Point(16, 17)
        Me.rdbTrackerDisabled.Margin = New System.Windows.Forms.Padding(4)
        Me.rdbTrackerDisabled.Name = "rdbTrackerDisabled"
        Me.rdbTrackerDisabled.Size = New System.Drawing.Size(135, 21)
        Me.rdbTrackerDisabled.TabIndex = 86
        Me.rdbTrackerDisabled.TabStop = True
        Me.rdbTrackerDisabled.Text = "Tracker disabled"
        Me.rdbTrackerDisabled.UseVisualStyleBackColor = True
        '
        'rdbTrackerYAMI
        '
        Me.rdbTrackerYAMI.AutoSize = True
        Me.rdbTrackerYAMI.Location = New System.Drawing.Point(16, 73)
        Me.rdbTrackerYAMI.Margin = New System.Windows.Forms.Padding(4)
        Me.rdbTrackerYAMI.Name = "rdbTrackerYAMI"
        Me.rdbTrackerYAMI.Size = New System.Drawing.Size(114, 21)
        Me.rdbTrackerYAMI.TabIndex = 88
        Me.rdbTrackerYAMI.TabStop = True
        Me.rdbTrackerYAMI.Text = "YAMI Tracker"
        Me.rdbTrackerYAMI.UseVisualStyleBackColor = True
        '
        'pTrackerYAMI
        '
        Me.pTrackerYAMI.Controls.Add(Me.cmbTRCom)
        Me.pTrackerYAMI.Controls.Add(Me._Label2_1)
        Me.pTrackerYAMI.Controls.Add(Me._Label2_2)
        Me.pTrackerYAMI.Controls.Add(Me._Label2_4)
        Me.pTrackerYAMI.Controls.Add(Me.txtTRSettingsInterval)
        Me.pTrackerYAMI.Controls.Add(Me._Label2_5)
        Me.pTrackerYAMI.Controls.Add(Me.cmbTRBaudrate)
        Me.pTrackerYAMI.Controls.Add(Me.chkTRSimulation)
        Me.pTrackerYAMI.Location = New System.Drawing.Point(38, 200)
        Me.pTrackerYAMI.Margin = New System.Windows.Forms.Padding(4)
        Me.pTrackerYAMI.Name = "pTrackerYAMI"
        Me.pTrackerYAMI.Size = New System.Drawing.Size(395, 143)
        Me.pTrackerYAMI.TabIndex = 89
        '
        'cmbTRCom
        '
        Me.cmbTRCom.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTRCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTRCom.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbTRCom.Location = New System.Drawing.Point(193, 0)
        Me.cmbTRCom.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbTRCom.Name = "cmbTRCom"
        Me.cmbTRCom.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbTRCom.Size = New System.Drawing.Size(117, 24)
        Me.cmbTRCom.TabIndex = 47
        '
        '_Label2_1
        '
        Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_1.Location = New System.Drawing.Point(55, 5)
        Me._Label2_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label2_1.Name = "_Label2_1"
        Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_1.Size = New System.Drawing.Size(135, 16)
        Me._Label2_1.TabIndex = 48
        Me._Label2_1.Text = "COM port:"
        Me._Label2_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Label2_2
        '
        Me._Label2_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_2.Location = New System.Drawing.Point(55, 39)
        Me._Label2_2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label2_2.Name = "_Label2_2"
        Me._Label2_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_2.Size = New System.Drawing.Size(135, 16)
        Me._Label2_2.TabIndex = 50
        Me._Label2_2.Text = "Baud rate:"
        Me._Label2_2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Label2_4
        '
        Me._Label2_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_4.Location = New System.Drawing.Point(0, 108)
        Me._Label2_4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label2_4.Name = "_Label2_4"
        Me._Label2_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_4.Size = New System.Drawing.Size(187, 20)
        Me._Label2_4.TabIndex = 59
        Me._Label2_4.Text = "Update interval in Settings:"
        '
        'txtTRSettingsInterval
        '
        Me.txtTRSettingsInterval.AcceptsReturn = True
        Me.txtTRSettingsInterval.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRSettingsInterval.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTRSettingsInterval.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTRSettingsInterval.Location = New System.Drawing.Point(193, 105)
        Me.txtTRSettingsInterval.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTRSettingsInterval.MaxLength = 10
        Me.txtTRSettingsInterval.Name = "txtTRSettingsInterval"
        Me.txtTRSettingsInterval.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTRSettingsInterval.Size = New System.Drawing.Size(93, 22)
        Me.txtTRSettingsInterval.TabIndex = 58
        '
        '_Label2_5
        '
        Me._Label2_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_5.Location = New System.Drawing.Point(296, 108)
        Me._Label2_5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label2_5.Name = "_Label2_5"
        Me._Label2_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_5.Size = New System.Drawing.Size(39, 22)
        Me._Label2_5.TabIndex = 60
        Me._Label2_5.Text = "ms"
        '
        'cmbTRBaudrate
        '
        Me.cmbTRBaudrate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTRBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTRBaudrate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbTRBaudrate.Location = New System.Drawing.Point(193, 34)
        Me.cmbTRBaudrate.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbTRBaudrate.Name = "cmbTRBaudrate"
        Me.cmbTRBaudrate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbTRBaudrate.Size = New System.Drawing.Size(117, 24)
        Me.cmbTRBaudrate.TabIndex = 49
        '
        'chkTRSimulation
        '
        Me.chkTRSimulation.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkTRSimulation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkTRSimulation.Location = New System.Drawing.Point(123, 75)
        Me.chkTRSimulation.Margin = New System.Windows.Forms.Padding(4)
        Me.chkTRSimulation.Name = "chkTRSimulation"
        Me.chkTRSimulation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkTRSimulation.Size = New System.Drawing.Size(155, 22)
        Me.chkTRSimulation.TabIndex = 52
        Me.chkTRSimulation.Text = "Simulate Tracker:"
        Me.chkTRSimulation.UseVisualStyleBackColor = False
        '
        'lblTRSensorCount
        '
        Me.lblTRSensorCount.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTRSensorCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTRSensorCount.Location = New System.Drawing.Point(41, 143)
        Me.lblTRSensorCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTRSensorCount.Name = "lblTRSensorCount"
        Me.lblTRSensorCount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTRSensorCount.Size = New System.Drawing.Size(135, 16)
        Me.lblTRSensorCount.TabIndex = 51
        Me.lblTRSensorCount.Text = "Number of Sensors:"
        '
        'rdbTrackerViWo
        '
        Me.rdbTrackerViWo.AutoSize = True
        Me.rdbTrackerViWo.Location = New System.Drawing.Point(16, 46)
        Me.rdbTrackerViWo.Margin = New System.Windows.Forms.Padding(4)
        Me.rdbTrackerViWo.Name = "rdbTrackerViWo"
        Me.rdbTrackerViWo.Size = New System.Drawing.Size(115, 21)
        Me.rdbTrackerViWo.TabIndex = 87
        Me.rdbTrackerViWo.TabStop = True
        Me.rdbTrackerViWo.Text = "ViWo Tracker"
        Me.rdbTrackerViWo.UseVisualStyleBackColor = True
        '
        'chkTRLog
        '
        Me.chkTRLog.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkTRLog.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkTRLog.Location = New System.Drawing.Point(44, 167)
        Me.chkTRLog.Margin = New System.Windows.Forms.Padding(4)
        Me.chkTRLog.Name = "chkTRLog"
        Me.chkTRLog.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkTRLog.Size = New System.Drawing.Size(353, 25)
        Me.chkTRLog.TabIndex = 85
        Me.chkTRLog.Text = "Log responses to trackerlog.csv (volatile option)"
        Me.chkTRLog.UseVisualStyleBackColor = False
        '
        'cmbTRSensorCount
        '
        Me.cmbTRSensorCount.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTRSensorCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTRSensorCount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbTRSensorCount.Location = New System.Drawing.Point(232, 140)
        Me.cmbTRSensorCount.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbTRSensorCount.Name = "cmbTRSensorCount"
        Me.cmbTRSensorCount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbTRSensorCount.Size = New System.Drawing.Size(93, 24)
        Me.cmbTRSensorCount.TabIndex = 53
        '
        '_sstOptions_TurntableTab
        '
        Me._sstOptions_TurntableTab.Controls.Add(Me.textBoxTTspeed)
        Me._sstOptions_TurntableTab.Controls.Add(Me.Label48)
        Me._sstOptions_TurntableTab.Controls.Add(Me.Label47)
        Me._sstOptions_TurntableTab.Controls.Add(Me.Label46)
        Me._sstOptions_TurntableTab.Controls.Add(Me.textBoxTTport)
        Me._sstOptions_TurntableTab.Controls.Add(Me.textBoxTTIPaddress)
        Me._sstOptions_TurntableTab.Controls.Add(Me.rdbTTImperial)
        Me._sstOptions_TurntableTab.Controls.Add(Me.rdbTTOutline)
        Me._sstOptions_TurntableTab.Controls.Add(Me.rdbTTFourAudio)
        Me._sstOptions_TurntableTab.Controls.Add(Me.rdbTTDisabled)
        Me._sstOptions_TurntableTab.Controls.Add(Me.pTTOutline)
        Me._sstOptions_TurntableTab.Location = New System.Drawing.Point(4, 40)
        Me._sstOptions_TurntableTab.Margin = New System.Windows.Forms.Padding(4)
        Me._sstOptions_TurntableTab.Name = "_sstOptions_TurntableTab"
        Me._sstOptions_TurntableTab.Size = New System.Drawing.Size(675, 461)
        Me._sstOptions_TurntableTab.TabIndex = 6
        Me._sstOptions_TurntableTab.Text = "Turntable"
        Me._sstOptions_TurntableTab.UseVisualStyleBackColor = True
        '
        'textBoxTTspeed
        '
        Me.textBoxTTspeed.DecimalPlaces = 1
        Me.textBoxTTspeed.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.textBoxTTspeed.Location = New System.Drawing.Point(200, 166)
        Me.textBoxTTspeed.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.textBoxTTspeed.Minimum = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.textBoxTTspeed.Name = "textBoxTTspeed"
        Me.textBoxTTspeed.Size = New System.Drawing.Size(60, 22)
        Me.textBoxTTspeed.TabIndex = 80
        Me.textBoxTTspeed.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(45, 168)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(149, 17)
        Me.Label48.TabIndex = 79
        Me.Label48.Text = "Default speed (deg/s):"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(250, 136)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(38, 17)
        Me.Label47.TabIndex = 77
        Me.Label47.Text = "Port:"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(45, 136)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(79, 17)
        Me.Label46.TabIndex = 76
        Me.Label46.Text = "IP address:"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'textBoxTTport
        '
        Me.textBoxTTport.Location = New System.Drawing.Point(292, 133)
        Me.textBoxTTport.Name = "textBoxTTport"
        Me.textBoxTTport.Size = New System.Drawing.Size(58, 22)
        Me.textBoxTTport.TabIndex = 75
        '
        'textBoxTTIPaddress
        '
        Me.textBoxTTIPaddress.Location = New System.Drawing.Point(130, 133)
        Me.textBoxTTIPaddress.Name = "textBoxTTIPaddress"
        Me.textBoxTTIPaddress.Size = New System.Drawing.Size(100, 22)
        Me.textBoxTTIPaddress.TabIndex = 74
        '
        'rdbTTImperial
        '
        Me.rdbTTImperial.AutoSize = True
        Me.rdbTTImperial.Location = New System.Drawing.Point(16, 101)
        Me.rdbTTImperial.Margin = New System.Windows.Forms.Padding(4)
        Me.rdbTTImperial.Name = "rdbTTImperial"
        Me.rdbTTImperial.Size = New System.Drawing.Size(245, 21)
        Me.rdbTTImperial.TabIndex = 73
        Me.rdbTTImperial.Text = "Imperial College Custom Turntable"
        Me.rdbTTImperial.UseVisualStyleBackColor = False
        '
        'rdbTTOutline
        '
        Me.rdbTTOutline.AutoSize = True
        Me.rdbTTOutline.Location = New System.Drawing.Point(16, 73)
        Me.rdbTTOutline.Margin = New System.Windows.Forms.Padding(4)
        Me.rdbTTOutline.Name = "rdbTTOutline"
        Me.rdbTTOutline.Size = New System.Drawing.Size(104, 21)
        Me.rdbTTOutline.TabIndex = 68
        Me.rdbTTOutline.Text = "Outline ST2"
        Me.rdbTTOutline.UseVisualStyleBackColor = True
        '
        'rdbTTFourAudio
        '
        Me.rdbTTFourAudio.AutoSize = True
        Me.rdbTTFourAudio.Location = New System.Drawing.Point(16, 46)
        Me.rdbTTFourAudio.Margin = New System.Windows.Forms.Padding(4)
        Me.rdbTTFourAudio.Name = "rdbTTFourAudio"
        Me.rdbTTFourAudio.Size = New System.Drawing.Size(130, 21)
        Me.rdbTTFourAudio.TabIndex = 67
        Me.rdbTTFourAudio.Text = "Four Audio ANT"
        Me.rdbTTFourAudio.UseVisualStyleBackColor = True
        '
        'rdbTTDisabled
        '
        Me.rdbTTDisabled.AutoSize = True
        Me.rdbTTDisabled.Checked = True
        Me.rdbTTDisabled.Location = New System.Drawing.Point(16, 17)
        Me.rdbTTDisabled.Margin = New System.Windows.Forms.Padding(4)
        Me.rdbTTDisabled.Name = "rdbTTDisabled"
        Me.rdbTTDisabled.Size = New System.Drawing.Size(112, 21)
        Me.rdbTTDisabled.TabIndex = 66
        Me.rdbTTDisabled.TabStop = True
        Me.rdbTTDisabled.Text = "No Turntable"
        Me.rdbTTDisabled.UseVisualStyleBackColor = True
        '
        'pTTOutline
        '
        Me.pTTOutline.Controls.Add(Me.cmbTTLPT)
        Me.pTTOutline.Controls.Add(Me._Label2_6)
        Me.pTTOutline.Controls.Add(Me.txtTTOffset)
        Me.pTTOutline.Controls.Add(Me._Label2_7)
        Me.pTTOutline.Controls.Add(Me.pTTFourAudio)
        Me.pTTOutline.Controls.Add(Me._Label2_8)
        Me.pTTOutline.Location = New System.Drawing.Point(38, 185)
        Me.pTTOutline.Margin = New System.Windows.Forms.Padding(4)
        Me.pTTOutline.Name = "pTTOutline"
        Me.pTTOutline.Size = New System.Drawing.Size(592, 246)
        Me.pTTOutline.TabIndex = 71
        '
        'cmbTTLPT
        '
        Me.cmbTTLPT.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTTLPT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTTLPT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbTTLPT.Location = New System.Drawing.Point(105, 10)
        Me.cmbTTLPT.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbTTLPT.Name = "cmbTTLPT"
        Me.cmbTTLPT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbTTLPT.Size = New System.Drawing.Size(117, 24)
        Me.cmbTTLPT.TabIndex = 61
        '
        '_Label2_6
        '
        Me._Label2_6.AutoSize = True
        Me._Label2_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_6.Location = New System.Drawing.Point(4, 14)
        Me._Label2_6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label2_6.Name = "_Label2_6"
        Me._Label2_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_6.Size = New System.Drawing.Size(67, 17)
        Me._Label2_6.TabIndex = 62
        Me._Label2_6.Text = "LPT port:"
        Me._Label2_6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtTTOffset
        '
        Me.txtTTOffset.AcceptsReturn = True
        Me.txtTTOffset.BackColor = System.Drawing.SystemColors.Window
        Me.txtTTOffset.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTTOffset.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTTOffset.Location = New System.Drawing.Point(105, 49)
        Me.txtTTOffset.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTTOffset.MaxLength = 10
        Me.txtTTOffset.Name = "txtTTOffset"
        Me.txtTTOffset.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTTOffset.Size = New System.Drawing.Size(69, 22)
        Me.txtTTOffset.TabIndex = 63
        '
        '_Label2_7
        '
        Me._Label2_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_7.Location = New System.Drawing.Point(183, 54)
        Me._Label2_7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label2_7.Name = "_Label2_7"
        Me._Label2_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_7.Size = New System.Drawing.Size(39, 16)
        Me._Label2_7.TabIndex = 64
        Me._Label2_7.Text = "deg"
        '
        'pTTFourAudio
        '
        Me.pTTFourAudio.Controls.Add(Me.ckbTT4AAllowPreRotation)
        Me.pTTFourAudio.Controls.Add(Me.numTT4ABrakeTimer)
        Me.pTTFourAudio.Controls.Add(Me.Label42)
        Me.pTTFourAudio.Controls.Add(Me.lblPullBrake)
        Me.pTTFourAudio.Controls.Add(Me.txtTT4AOffset)
        Me.pTTFourAudio.Controls.Add(Me.Label40)
        Me.pTTFourAudio.Controls.Add(Me.Label41)
        Me.pTTFourAudio.Controls.Add(Me.lblTTFourAudio)
        Me.pTTFourAudio.Controls.Add(Me.btnTTFourAudioInit)
        Me.pTTFourAudio.Location = New System.Drawing.Point(0, 0)
        Me.pTTFourAudio.Margin = New System.Windows.Forms.Padding(4)
        Me.pTTFourAudio.Name = "pTTFourAudio"
        Me.pTTFourAudio.Size = New System.Drawing.Size(592, 246)
        Me.pTTFourAudio.TabIndex = 72
        '
        'txtTT4AOffset
        '
        Me.txtTT4AOffset.AcceptsReturn = True
        Me.txtTT4AOffset.BackColor = System.Drawing.SystemColors.Window
        Me.txtTT4AOffset.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTT4AOffset.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTT4AOffset.Location = New System.Drawing.Point(105, 49)
        Me.txtTT4AOffset.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTT4AOffset.MaxLength = 10
        Me.txtTT4AOffset.Name = "txtTT4AOffset"
        Me.txtTT4AOffset.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTT4AOffset.Size = New System.Drawing.Size(69, 22)
        Me.txtTT4AOffset.TabIndex = 66
        Me.txtTT4AOffset.Text = "0"
        '
        'Label40
        '
        Me.Label40.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label40.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label40.Location = New System.Drawing.Point(183, 54)
        Me.Label40.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label40.Name = "Label40"
        Me.Label40.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label40.Size = New System.Drawing.Size(39, 16)
        Me.Label40.TabIndex = 67
        Me.Label40.Text = "deg"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label41.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label41.Location = New System.Drawing.Point(21, 54)
        Me.Label41.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label41.Name = "Label41"
        Me.Label41.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label41.Size = New System.Drawing.Size(50, 17)
        Me.Label41.TabIndex = 68
        Me.Label41.Text = "Offset:"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTTFourAudio
        '
        Me.lblTTFourAudio.AutoSize = True
        Me.lblTTFourAudio.Location = New System.Drawing.Point(160, 15)
        Me.lblTTFourAudio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTTFourAudio.Name = "lblTTFourAudio"
        Me.lblTTFourAudio.Size = New System.Drawing.Size(105, 17)
        Me.lblTTFourAudio.TabIndex = 1
        Me.lblTTFourAudio.Text = "lblTTFourAudio"
        '
        'btnTTFourAudioInit
        '
        Me.btnTTFourAudioInit.Location = New System.Drawing.Point(25, 10)
        Me.btnTTFourAudioInit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnTTFourAudioInit.Name = "btnTTFourAudioInit"
        Me.btnTTFourAudioInit.Size = New System.Drawing.Size(103, 26)
        Me.btnTTFourAudioInit.TabIndex = 0
        Me.btnTTFourAudioInit.Text = "Init Library"
        Me.btnTTFourAudioInit.UseVisualStyleBackColor = True
        '
        '_Label2_8
        '
        Me._Label2_8.AutoSize = True
        Me._Label2_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_8.Location = New System.Drawing.Point(21, 54)
        Me._Label2_8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._Label2_8.Name = "_Label2_8"
        Me._Label2_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_8.Size = New System.Drawing.Size(50, 17)
        Me._Label2_8.TabIndex = 65
        Me._Label2_8.Text = "Offset:"
        Me._Label2_8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_sstOptions_TabPage7
        '
        Me._sstOptions_TabPage7.Controls.Add(Me.chkViWoOSC)
        Me._sstOptions_TabPage7.Controls.Add(Me.Label19)
        Me._sstOptions_TabPage7.Controls.Add(Me.Label20)
        Me._sstOptions_TabPage7.Controls.Add(Me.lblLocalViwoAddr)
        Me._sstOptions_TabPage7.Controls.Add(Me.txtViWoAddress)
        Me._sstOptions_TabPage7.Controls.Add(Me.txtViWoPort)
        Me._sstOptions_TabPage7.Controls.Add(Me.cmdViWoReconnect)
        Me._sstOptions_TabPage7.Location = New System.Drawing.Point(4, 40)
        Me._sstOptions_TabPage7.Margin = New System.Windows.Forms.Padding(4)
        Me._sstOptions_TabPage7.Name = "_sstOptions_TabPage7"
        Me._sstOptions_TabPage7.Size = New System.Drawing.Size(675, 461)
        Me._sstOptions_TabPage7.TabIndex = 7
        Me._sstOptions_TabPage7.Text = "ViWo"
        Me._sstOptions_TabPage7.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(29, 44)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(128, 16)
        Me.Label19.TabIndex = 75
        Me.Label19.Text = "ViWo:    Address:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label20
        '
        Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(353, 43)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label20.Size = New System.Drawing.Size(39, 17)
        Me.Label20.TabIndex = 76
        Me.Label20.Text = "Port:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLocalViwoAddr
        '
        Me.lblLocalViwoAddr.AutoSize = True
        Me.lblLocalViwoAddr.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLocalViwoAddr.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLocalViwoAddr.Location = New System.Drawing.Point(39, 80)
        Me.lblLocalViwoAddr.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLocalViwoAddr.Name = "lblLocalViwoAddr"
        Me.lblLocalViwoAddr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLocalViwoAddr.Size = New System.Drawing.Size(396, 17)
        Me.lblLocalViwoAddr.TabIndex = 90
        Me.lblLocalViwoAddr.Text = "Local:   Address: see Audio (Pd)/Local                  Port: 10005"
        '
        'txtViWoPort
        '
        Me.txtViWoPort.AcceptsReturn = True
        Me.txtViWoPort.BackColor = System.Drawing.SystemColors.Window
        Me.txtViWoPort.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtViWoPort.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtViWoPort.Location = New System.Drawing.Point(393, 39)
        Me.txtViWoPort.Margin = New System.Windows.Forms.Padding(4)
        Me.txtViWoPort.MaxLength = 5
        Me.txtViWoPort.Name = "txtViWoPort"
        Me.txtViWoPort.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtViWoPort.Size = New System.Drawing.Size(64, 22)
        Me.txtViWoPort.TabIndex = 74
        '
        'cmdViWoReconnect
        '
        Me.cmdViWoReconnect.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdViWoReconnect.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdViWoReconnect.Location = New System.Drawing.Point(451, 75)
        Me.cmdViWoReconnect.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdViWoReconnect.Name = "cmdViWoReconnect"
        Me.cmdViWoReconnect.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdViWoReconnect.Size = New System.Drawing.Size(103, 26)
        Me.cmdViWoReconnect.TabIndex = 91
        Me.cmdViWoReconnect.Text = "Reconnect"
        Me.cmdViWoReconnect.UseVisualStyleBackColor = False
        '
        '_sstOptions_Joypad
        '
        Me._sstOptions_Joypad.Controls.Add(Me.lblJoyInfo)
        Me._sstOptions_Joypad.Controls.Add(Me.lstJoypads)
        Me._sstOptions_Joypad.Controls.Add(Me.cmdJoypadRemove)
        Me._sstOptions_Joypad.Controls.Add(Me.cmdJoypadAdd)
        Me._sstOptions_Joypad.Controls.Add(Me.dgvJoypad)
        Me._sstOptions_Joypad.Location = New System.Drawing.Point(4, 40)
        Me._sstOptions_Joypad.Margin = New System.Windows.Forms.Padding(4)
        Me._sstOptions_Joypad.Name = "_sstOptions_Joypad"
        Me._sstOptions_Joypad.Padding = New System.Windows.Forms.Padding(4)
        Me._sstOptions_Joypad.Size = New System.Drawing.Size(675, 461)
        Me._sstOptions_Joypad.TabIndex = 8
        Me._sstOptions_Joypad.Text = "Joypad"
        Me._sstOptions_Joypad.UseVisualStyleBackColor = True
        '
        'lblJoyInfo
        '
        Me.lblJoyInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblJoyInfo.Location = New System.Drawing.Point(316, 322)
        Me.lblJoyInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblJoyInfo.Name = "lblJoyInfo"
        Me.lblJoyInfo.Size = New System.Drawing.Size(348, 124)
        Me.lblJoyInfo.TabIndex = 154
        Me.lblJoyInfo.Text = "JoypadInfo"
        '
        'lstJoypads
        '
        Me.lstJoypads.FormattingEnabled = True
        Me.lstJoypads.ItemHeight = 16
        Me.lstJoypads.Location = New System.Drawing.Point(11, 290)
        Me.lstJoypads.Margin = New System.Windows.Forms.Padding(4)
        Me.lstJoypads.Name = "lstJoypads"
        Me.lstJoypads.Size = New System.Drawing.Size(284, 84)
        Me.lstJoypads.TabIndex = 153
        '
        'cmdJoypadAdd
        '
        Me.cmdJoypadAdd.BackgroundImage = CType(resources.GetObject("cmdJoypadAdd.BackgroundImage"), System.Drawing.Image)
        Me.cmdJoypadAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmdJoypadAdd.Location = New System.Drawing.Point(312, 289)
        Me.cmdJoypadAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdJoypadAdd.Name = "cmdJoypadAdd"
        Me.cmdJoypadAdd.Size = New System.Drawing.Size(28, 26)
        Me.cmdJoypadAdd.TabIndex = 2
        Me.cmdJoypadAdd.UseVisualStyleBackColor = True
        '
        'dgvJoypad
        '
        Me.dgvJoypad.AllowUserToAddRows = False
        Me.dgvJoypad.AllowUserToDeleteRows = False
        Me.dgvJoypad.AllowUserToResizeRows = False
        Me.dgvJoypad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvJoypad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvJoypad.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvJoypad.Location = New System.Drawing.Point(4, 4)
        Me.dgvJoypad.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvJoypad.Name = "dgvJoypad"
        Me.dgvJoypad.RowHeadersWidth = 51
        Me.dgvJoypad.Size = New System.Drawing.Size(667, 278)
        Me.dgvJoypad.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 40)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(675, 461)
        Me.TabPage1.TabIndex = 10
        Me.TabPage1.Text = "Remote Monitor"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtRemoteServer)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 164)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(636, 144)
        Me.GroupBox2.TabIndex = 35
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Client Settings"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chkEnableRemoteMonitorServer)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 12)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(636, 144)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Server Settings"
        '
        '_sstOptions_NICTab
        '
        Me._sstOptions_NICTab.Controls.Add(Me.lblNICPath)
        Me._sstOptions_NICTab.Controls.Add(Me.cmdNICPath)
        Me._sstOptions_NICTab.Controls.Add(Me.txtNICPath)
        Me._sstOptions_NICTab.Controls.Add(Me.Label24)
        Me._sstOptions_NICTab.Controls.Add(Me.cmbComLeftNIC)
        Me._sstOptions_NICTab.Controls.Add(Me.cmbComRightNIC)
        Me._sstOptions_NICTab.Controls.Add(Me.txtNICServer)
        Me._sstOptions_NICTab.Controls.Add(Me.chkSimulationNIC)
        Me._sstOptions_NICTab.Controls.Add(Me.Label25)
        Me._sstOptions_NICTab.Controls.Add(Me.Label26)
        Me._sstOptions_NICTab.Controls.Add(Me.Label27)
        Me._sstOptions_NICTab.Location = New System.Drawing.Point(4, 22)
        Me._sstOptions_NICTab.Name = "_sstOptions_NICTab"
        Me._sstOptions_NICTab.Padding = New System.Windows.Forms.Padding(3)
        Me._sstOptions_NICTab.Size = New System.Drawing.Size(734, 334)
        Me._sstOptions_NICTab.TabIndex = 9
        Me._sstOptions_NICTab.Text = "NIC"
        Me._sstOptions_NICTab.UseVisualStyleBackColor = True
        '
        'lblNICPath
        '
        Me.lblNICPath.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNICPath.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblNICPath.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNICPath.Location = New System.Drawing.Point(53, 180)
        Me.lblNICPath.Name = "lblNICPath"
        Me.lblNICPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNICPath.Size = New System.Drawing.Size(530, 152)
        Me.lblNICPath.TabIndex = 98
        Me.lblNICPath.Text = "Allowed path names: absolute OR relative to:"
        '
        'cmdNICPath
        '
        Me.cmdNICPath.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdNICPath.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdNICPath.Location = New System.Drawing.Point(333, 152)
        Me.cmdNICPath.Name = "cmdNICPath"
        Me.cmdNICPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdNICPath.Size = New System.Drawing.Size(25, 21)
        Me.cmdNICPath.TabIndex = 97
        Me.cmdNICPath.Text = "..."
        Me.cmdNICPath.UseVisualStyleBackColor = False
        '
        'txtNICPath
        '
        Me.txtNICPath.AcceptsReturn = True
        Me.txtNICPath.BackColor = System.Drawing.SystemColors.Window
        Me.txtNICPath.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNICPath.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNICPath.Location = New System.Drawing.Point(149, 152)
        Me.txtNICPath.MaxLength = 0
        Me.txtNICPath.Name = "txtNICPath"
        Me.txtNICPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNICPath.Size = New System.Drawing.Size(164, 22)
        Me.txtNICPath.TabIndex = 96
        '
        'Label24
        '
        Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(35, 155)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(107, 16)
        Me.Label24.TabIndex = 95
        Me.Label24.Text = "Path to NIC Files:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbComLeftNIC
        '
        Me.cmbComLeftNIC.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbComLeftNIC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComLeftNIC.Enabled = False
        Me.cmbComLeftNIC.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbComLeftNIC.Location = New System.Drawing.Point(149, 56)
        Me.cmbComLeftNIC.Name = "cmbComLeftNIC"
        Me.cmbComLeftNIC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbComLeftNIC.Size = New System.Drawing.Size(89, 24)
        Me.cmbComLeftNIC.TabIndex = 91
        '
        'cmbComRightNIC
        '
        Me.cmbComRightNIC.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbComRightNIC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComRightNIC.Enabled = False
        Me.cmbComRightNIC.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbComRightNIC.Location = New System.Drawing.Point(149, 88)
        Me.cmbComRightNIC.Name = "cmbComRightNIC"
        Me.cmbComRightNIC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbComRightNIC.Size = New System.Drawing.Size(89, 24)
        Me.cmbComRightNIC.TabIndex = 90
        '
        'txtNICServer
        '
        Me.txtNICServer.AcceptsReturn = True
        Me.txtNICServer.BackColor = System.Drawing.SystemColors.Window
        Me.txtNICServer.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNICServer.Enabled = False
        Me.txtNICServer.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNICServer.Location = New System.Drawing.Point(149, 120)
        Me.txtNICServer.MaxLength = 0
        Me.txtNICServer.Name = "txtNICServer"
        Me.txtNICServer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNICServer.Size = New System.Drawing.Size(164, 22)
        Me.txtNICServer.TabIndex = 89
        '
        'chkSimulationNIC
        '
        Me.chkSimulationNIC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSimulationNIC.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkSimulationNIC.Enabled = False
        Me.chkSimulationNIC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkSimulationNIC.Location = New System.Drawing.Point(70, 26)
        Me.chkSimulationNIC.Name = "chkSimulationNIC"
        Me.chkSimulationNIC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkSimulationNIC.Size = New System.Drawing.Size(93, 20)
        Me.chkSimulationNIC.TabIndex = 88
        Me.chkSimulationNIC.Text = "Simulate NIC:"
        Me.chkSimulationNIC.UseVisualStyleBackColor = False
        '
        'Label25
        '
        Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label25.Enabled = False
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(30, 60)
        Me.Label25.Name = "Label25"
        Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label25.Size = New System.Drawing.Size(112, 17)
        Me.Label25.TabIndex = 94
        Me.Label25.Text = "COM port, Left NIC:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label26
        '
        Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label26.Enabled = False
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(25, 92)
        Me.Label26.Name = "Label26"
        Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label26.Size = New System.Drawing.Size(117, 17)
        Me.Label26.TabIndex = 93
        Me.Label26.Text = "COM port, Right NIC:"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label27
        '
        Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label27.Enabled = False
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(67, 124)
        Me.Label27.Name = "Label27"
        Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label27.Size = New System.Drawing.Size(75, 13)
        Me.Label27.TabIndex = 92
        Me.Label27.Text = "NIC server:"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'pbStatus
        '
        Me.pbStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbStatus.Location = New System.Drawing.Point(0, 601)
        Me.pbStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.pbStatus.Name = "pbStatus"
        Me.pbStatus.Size = New System.Drawing.Size(712, 28)
        Me.pbStatus.TabIndex = 10
        '
        'frmOptions
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(712, 629)
        Me.Controls.Add(Me.pbStatus)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me._picOptions_3)
        Me.Controls.Add(Me._picOptions_2)
        Me.Controls.Add(Me._picOptions_1)
        Me.Controls.Add(Me.sstOptions)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(309, 166)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(723, 655)
        Me.Name = "frmOptions"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Tag = "Options"
        Me.Text = "Program options"
        CType(Me.UpdateInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me._sstOptions_PdTab.ResumeLayout(False)
        Me._sstOptions_PdTab.PerformLayout()
        CType(Me.numTT4ABrakeTimer, System.ComponentModel.ISupportInitialize).EndInit()
        Me._picOptions_3.ResumeLayout(False)
        Me._picOptions_2.ResumeLayout(False)
        Me._picOptions_1.ResumeLayout(False)
        Me.sstOptions.ResumeLayout(False)
        Me._sstOptions_GeneralTab.ResumeLayout(False)
        Me._sstOptions_GeneralTab.PerformLayout()
        Me._sstOptions_ItemListTab.ResumeLayout(False)
        Me._sstOptions_ItemListTab.PerformLayout()
        Me.gbWarnings.ResumeLayout(False)
        Me.gbWarnings.PerformLayout()
        Me.gbCSVExportImport.ResumeLayout(False)
        Me.gbCSVExportImport.PerformLayout()
        Me._sstOptions_UnityTab.ResumeLayout(False)
        Me._sstOptions_UnityTab.PerformLayout()
        Me._sstOptions_RIBTab.ResumeLayout(False)
        Me._sstOptions_RIBTab.PerformLayout()
        Me._sstOptions_RIB2Tab.ResumeLayout(False)
        Me._sstOptions_RIB2Tab.PerformLayout()
        Me._sstOptions_MatlabTab.ResumeLayout(False)
        Me._sstOptions_MatlabTab.PerformLayout()
        Me._sstOptions_TrackerTab.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pTrackerYAMI.ResumeLayout(False)
        Me.pTrackerYAMI.PerformLayout()
        Me._sstOptions_TurntableTab.ResumeLayout(False)
        Me._sstOptions_TurntableTab.PerformLayout()
        CType(Me.textBoxTTspeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pTTOutline.ResumeLayout(False)
        Me.pTTOutline.PerformLayout()
        Me.pTTFourAudio.ResumeLayout(False)
        Me.pTTFourAudio.PerformLayout()
        Me._sstOptions_TabPage7.ResumeLayout(False)
        Me._sstOptions_TabPage7.PerformLayout()
        Me._sstOptions_Joypad.ResumeLayout(False)
        CType(Me.dgvJoypad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me._sstOptions_NICTab.ResumeLayout(False)
        Me._sstOptions_NICTab.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbStatus As System.Windows.Forms.ProgressBar
    Friend WithEvents _sstOptions_Joypad As System.Windows.Forms.TabPage
    Friend WithEvents dgvJoypad As System.Windows.Forms.DataGridView
    Friend WithEvents cmdJoypadAdd As System.Windows.Forms.Button
    Public WithEvents cmdJoypadRemove As System.Windows.Forms.Button
    Friend WithEvents lstJoypads As System.Windows.Forms.ListBox
    Friend WithEvents lblJoyInfo As System.Windows.Forms.Label
    Public WithEvents _sstOptions_NICTab As System.Windows.Forms.TabPage
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents cmbLogMode As System.Windows.Forms.ComboBox
    Public WithEvents cmdRIBPath As System.Windows.Forms.Button
    Public WithEvents txtRIBPath As System.Windows.Forms.TextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents lblRIBPath As System.Windows.Forms.Label
    Public WithEvents lblNICPath As System.Windows.Forms.Label
    Public WithEvents cmdNICPath As System.Windows.Forms.Button
    Public WithEvents txtNICPath As System.Windows.Forms.TextBox
    Public WithEvents Label24 As System.Windows.Forms.Label
    Public WithEvents cmbComLeftNIC As System.Windows.Forms.ComboBox
    Public WithEvents cmbComRightNIC As System.Windows.Forms.ComboBox
    Public WithEvents txtNICServer As System.Windows.Forms.TextBox
    Public WithEvents chkSimulationNIC As System.Windows.Forms.CheckBox
    Public WithEvents Label25 As System.Windows.Forms.Label
    Public WithEvents Label26 As System.Windows.Forms.Label
    Public WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cmdYAMIPath As System.Windows.Forms.Button
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Public WithEvents chkEnableRemoteMonitorServer As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents txtRemoteServer As System.Windows.Forms.TextBox
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents txtOptionsFile As System.Windows.Forms.TextBox
    Public WithEvents lblOptionsFile As System.Windows.Forms.Label
    Public WithEvents chkCheckForUpdates As System.Windows.Forms.CheckBox
    Public WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents UpdateInterval As System.Windows.Forms.NumericUpDown
    Friend WithEvents _sstOptions_RIB2Tab As System.Windows.Forms.TabPage
    Public WithEvents lblRIB2Path As System.Windows.Forms.Label
    Public WithEvents cmdRIB2Path As System.Windows.Forms.Button
    Public WithEvents txtRIB2Path As System.Windows.Forms.TextBox
    Public WithEvents txtRIB2Device As System.Windows.Forms.TextBox
    Public WithEvents chkRIB2Simulation As System.Windows.Forms.CheckBox
    Public WithEvents Label33 As System.Windows.Forms.Label
    Public WithEvents Label30 As System.Windows.Forms.Label
    Public WithEvents cmdOptionsDir As System.Windows.Forms.Button
    Public WithEvents chkPlayWaveExp As System.Windows.Forms.CheckBox
    Public WithEvents cmbWaveEndExp As System.Windows.Forms.Button
    Public WithEvents cmbWavExp As System.Windows.Forms.ComboBox
    Public WithEvents Label29 As System.Windows.Forms.Label
    Public WithEvents cmbPriority As System.Windows.Forms.ComboBox
    Public WithEvents chkPlayerOSC As System.Windows.Forms.CheckBox
    Public WithEvents chkViWoOSC As System.Windows.Forms.CheckBox
    Friend WithEvents _sstOptions_UnityTab As System.Windows.Forms.TabPage
    Public WithEvents txtUnityAddr As System.Windows.Forms.TextBox
    Public WithEvents txtUnityPort As System.Windows.Forms.TextBox
    Public WithEvents txtUnityLocalPort As System.Windows.Forms.TextBox
    Public WithEvents Label31 As System.Windows.Forms.Label
    Public WithEvents Label32 As System.Windows.Forms.Label
    Public WithEvents Label34 As System.Windows.Forms.Label
    Public WithEvents Label37 As System.Windows.Forms.Label
    Public WithEvents lblUnityLocalPort As System.Windows.Forms.Label
    Friend WithEvents rdbTrackerYAMI As System.Windows.Forms.RadioButton
    Friend WithEvents rdbTrackerViWo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbTrackerDisabled As System.Windows.Forms.RadioButton
    Friend WithEvents pTrackerYAMI As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Public WithEvents cmbDataChannel As System.Windows.Forms.ComboBox
    Public WithEvents Label23 As System.Windows.Forms.Label
    Public WithEvents cmbTriggerChannel As System.Windows.Forms.ComboBox
    Public WithEvents Label35 As System.Windows.Forms.Label
    Public WithEvents cmbPlayerADCDevice As System.Windows.Forms.ComboBox
    Public WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbAudioIndex As System.Windows.Forms.RadioButton
    Public WithEvents txtDACName As System.Windows.Forms.TextBox
    Friend WithEvents rdbAudioName As System.Windows.Forms.RadioButton
    Public WithEvents txtADCName As System.Windows.Forms.TextBox
    Public WithEvents Label38 As System.Windows.Forms.Label
    Public WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents btnListDevices As Button
    Public WithEvents cmbADCName As ComboBox
    Public WithEvents cmbDACName As ComboBox
    Public WithEvents chkAutoBackupLogFileSilent As CheckBox
    Friend WithEvents rdbTTOutline As RadioButton
    Friend WithEvents rdbTTFourAudio As RadioButton
    Friend WithEvents rdbTTDisabled As RadioButton
    Friend WithEvents pTTOutline As Panel
    Friend WithEvents pTTFourAudio As Panel
    Friend WithEvents btnTTFourAudioInit As Button
    Friend WithEvents lblTTFourAudio As Label
    Public WithEvents txtTT4AOffset As TextBox
    Public WithEvents Label40 As Label
    Public WithEvents Label41 As Label
    Public WithEvents Label42 As Label
    Public WithEvents lblPullBrake As Label
    Friend WithEvents numTT4ABrakeTimer As NumericUpDown
    Friend WithEvents ckbIncludeHeadersInClipboard As CheckBox
    Friend WithEvents ckbTT4AAllowPreRotation As CheckBox
    Friend WithEvents gbCSVExportImport As GroupBox
    Public WithEvents chkUseFileNaming As CheckBox
    Public WithEvents chkDisableSetOptimalColWidth As CheckBox
    Public WithEvents chkAutoBackupItemList As CheckBox
    Friend WithEvents gbWarnings As GroupBox
    Public WithEvents chkResponseItemListOnExpRep As CheckBox
    Public WithEvents chkExpPerformedOnShuffle As CheckBox
    Public WithEvents chkNotShuffledOnExpStart As CheckBox
    Public WithEvents chkNotRepOnExpStart As CheckBox
    Friend WithEvents btnDisableAllWarnings As Button
    Friend WithEvents btnEnableAllWarnings As Button
    Friend WithEvents tbItemListPreview As TextBox
    Friend WithEvents rdbTrackerOptitrack As RadioButton
    Friend WithEvents rdbTTImperial As RadioButton
    Friend WithEvents buttonBrowseMotiveFile As Button
    Friend WithEvents Label43 As Label
    Friend WithEvents textBoxMotiveFile As TextBox
    Friend WithEvents Label45 As Label
    Friend WithEvents textBoxUDPport As TextBox
    Friend WithEvents buttonBrowseOSCstreamerFile As Button
    Friend WithEvents Label44 As Label
    Friend WithEvents textBoxOSCstreamerFile As TextBox
    Friend WithEvents Label47 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents textBoxTTport As TextBox
    Friend WithEvents textBoxTTIPaddress As TextBox
    Friend WithEvents textBoxTTspeed As NumericUpDown
    Friend WithEvents Label48 As Label
#End Region
End Class