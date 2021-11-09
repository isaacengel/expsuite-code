<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLevelDancer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents cmdGroupStimulate As System.Windows.Forms.Button
    Public WithEvents _cmdGroup_3 As System.Windows.Forms.Button
    Public WithEvents _cmdGroup_2 As System.Windows.Forms.Button
    Public WithEvents _cmdGroup_1 As System.Windows.Forms.Button
    Public WithEvents _cmdGroup_0 As System.Windows.Forms.Button
    Public WithEvents Label15 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents chkDelayed As System.Windows.Forms.CheckBox
    Public WithEvents optLeftFirst As System.Windows.Forms.RadioButton
    Public WithEvents optRightFirst As System.Windows.Forms.RadioButton
    Public WithEvents lblNameL As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents _sldL_0 As System.Windows.Forms.TrackBar
    Public WithEvents _chkGroupR_0 As System.Windows.Forms.CheckBox
    Public WithEvents _chkGroupL_0 As System.Windows.Forms.CheckBox
    Public WithEvents _sbStatusBar_Panel1 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents _sbStatusBar_Panel2 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents _sbStatusBar_Panel3 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents _sbStatusBar_Panel4 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents _sbStatusBar_Panel5 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents sbStatusBar As System.Windows.Forms.StatusStrip
    Public WithEvents _sldR_0 As System.Windows.Forms.TrackBar
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents _lblDynamicR_0 As System.Windows.Forms.Label
    Public WithEvents _lblDynamicL_0 As System.Windows.Forms.Label
    Public WithEvents _lblTHRR_0 As System.Windows.Forms.Label
    Public WithEvents _lblMCLR_0 As System.Windows.Forms.Label
    Public WithEvents _lblTHRL_0 As System.Windows.Forms.Label
    Public WithEvents _lblMCLL_0 As System.Windows.Forms.Label
    Public WithEvents _lblLevelR_0 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents _lineGrid_4 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents _lineGrid_5 As System.Windows.Forms.Label
    Public WithEvents _lblChR_0 As System.Windows.Forms.Label
    Public WithEvents _lblChL_0 As System.Windows.Forms.Label
    Public WithEvents _lineGrid_6 As System.Windows.Forms.Label
    Public WithEvents lblLevelLabel As System.Windows.Forms.Label
    Public WithEvents _lineGrid_0 As System.Windows.Forms.Label
    Public WithEvents _lineGrid_1 As System.Windows.Forms.Label
    Public WithEvents _lineGrid_2 As System.Windows.Forms.Label
    Public WithEvents _lineGrid_3 As System.Windows.Forms.Label
    Public WithEvents lblTHRLabel As System.Windows.Forms.Label
    Public WithEvents lblMCLLabel As System.Windows.Forms.Label
    Public WithEvents _lblLevelL_0 As System.Windows.Forms.Label
    Public WithEvents _lblCh_0 As System.Windows.Forms.Label
    Public WithEvents chkGroupL As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
    Public WithEvents chkGroupR As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
    Public WithEvents cmdGroup As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    Public WithEvents lblCh As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblChL As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblChR As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblDynamicL As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblDynamicR As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblLevelL As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblLevelR As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblDrL As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblDrR As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblMCLL As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblMCLR As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblTHRL As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lblTHRR As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lineGrid As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents lineSplit As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents mnuParametersLoad As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuParametersImport As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuFileBar0 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuParametersExport As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuParametersExportAmpElPairs As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuFileBar1 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuParameters As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuViewStimulus As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuView As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLevelDancer))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdGroupStimulate = New System.Windows.Forms.Button()
        Me._cmdGroup_3 = New System.Windows.Forms.Button()
        Me._cmdGroup_2 = New System.Windows.Forms.Button()
        Me._cmdGroup_1 = New System.Windows.Forms.Button()
        Me._cmdGroup_0 = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtPulsePeriodL = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtDuration = New System.Windows.Forms.TextBox()
        Me.chkDelayed = New System.Windows.Forms.CheckBox()
        Me.optLeftFirst = New System.Windows.Forms.RadioButton()
        Me.optRightFirst = New System.Windows.Forms.RadioButton()
        Me.lblNameL = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me._sldL_0 = New System.Windows.Forms.TrackBar()
        Me._chkGroupR_0 = New System.Windows.Forms.CheckBox()
        Me._chkGroupL_0 = New System.Windows.Forms.CheckBox()
        Me.sbStatusBar = New System.Windows.Forms.StatusStrip()
        Me._sbStatusBar_Panel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._sbStatusBar_Panel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._sbStatusBar_Panel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._sbStatusBar_Panel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._sbStatusBar_Panel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me._sldR_0 = New System.Windows.Forms.TrackBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me._lblDynamicR_0 = New System.Windows.Forms.Label()
        Me._lblDynamicL_0 = New System.Windows.Forms.Label()
        Me._lblTHRR_0 = New System.Windows.Forms.Label()
        Me._lblMCLR_0 = New System.Windows.Forms.Label()
        Me._lblTHRL_0 = New System.Windows.Forms.Label()
        Me._lblMCLL_0 = New System.Windows.Forms.Label()
        Me._lblLevelR_0 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me._lineGrid_4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me._lineGrid_5 = New System.Windows.Forms.Label()
        Me._lblChR_0 = New System.Windows.Forms.Label()
        Me._lblChL_0 = New System.Windows.Forms.Label()
        Me._lineGrid_6 = New System.Windows.Forms.Label()
        Me.lblLevelLabel = New System.Windows.Forms.Label()
        Me._lineGrid_0 = New System.Windows.Forms.Label()
        Me._lineGrid_1 = New System.Windows.Forms.Label()
        Me._lineGrid_2 = New System.Windows.Forms.Label()
        Me._lineGrid_3 = New System.Windows.Forms.Label()
        Me.lblTHRLabel = New System.Windows.Forms.Label()
        Me.lblMCLLabel = New System.Windows.Forms.Label()
        Me._lblLevelL_0 = New System.Windows.Forms.Label()
        Me._lblCh_0 = New System.Windows.Forms.Label()
        Me.chkGroupL = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(Me.components)
        Me.chkGroupR = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(Me.components)
        Me.cmdGroup = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me.lblCh = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblChL = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblChR = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblDynamicL = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblDynamicR = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblLevelL = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblLevelR = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblDrL = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me._lblDrL_0 = New System.Windows.Forms.Label()
        Me.lblDrR = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me._lblDrR_0 = New System.Windows.Forms.Label()
        Me.lblMCLL = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblMCLR = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTHRL = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTHRR = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lineGrid = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me._lineGrid_7 = New System.Windows.Forms.Label()
        Me._lineGrid_8 = New System.Windows.Forms.Label()
        Me.lineSplit = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.mnuParameters = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuParametersReload = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuParametersResetToTHR = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuParametersResetPhDur = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuParametersLoad = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuParametersImport = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileBar0 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuParametersExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuParametersExportAmpElPairs = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileBar1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpShortcuts = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewStimulus = New System.Windows.Forms.ToolStripMenuItem()
        Me._txtPhDurL_0 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me._lblPhDurL_0 = New System.Windows.Forms.Label()
        Me._txtPhDurR_0 = New System.Windows.Forms.TextBox()
        Me._lblPhDurR_0 = New System.Windows.Forms.Label()
        Me.panelData = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAppendPulseTrain = New System.Windows.Forms.TextBox()
        Me.cmbAppendPulseTrain = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblPulseRateR = New System.Windows.Forms.Label()
        Me.lblPulseRateL = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPulsePeriodR = New System.Windows.Forms.TextBox()
        Me.lblLevelLabelDR = New System.Windows.Forms.Label()
        Me.rDR = New System.Windows.Forms.RadioButton()
        Me.rCU = New System.Windows.Forms.RadioButton()
        CType(Me._sldL_0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sbStatusBar.SuspendLayout()
        CType(Me._sldR_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkGroupL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkGroupR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblChL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblChR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDynamicL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDynamicR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblLevelL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblLevelR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDrL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDrR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMCLL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMCLR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTHRL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTHRR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lineGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lineSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainMenu1.SuspendLayout()
        Me.panelData.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdGroupStimulate
        '
        Me.cmdGroupStimulate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGroupStimulate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGroupStimulate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGroupStimulate.Image = CType(resources.GetObject("cmdGroupStimulate.Image"), System.Drawing.Image)
        Me.cmdGroupStimulate.Location = New System.Drawing.Point(414, 20)
        Me.cmdGroupStimulate.Name = "cmdGroupStimulate"
        Me.cmdGroupStimulate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGroupStimulate.Size = New System.Drawing.Size(45, 45)
        Me.cmdGroupStimulate.TabIndex = 44
        Me.cmdGroupStimulate.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdGroupStimulate.UseVisualStyleBackColor = False
        '
        '_cmdGroup_3
        '
        Me._cmdGroup_3.BackColor = System.Drawing.SystemColors.Control
        Me._cmdGroup_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdGroup_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGroup.SetIndex(Me._cmdGroup_3, CType(3, Short))
        Me._cmdGroup_3.Location = New System.Drawing.Point(356, 44)
        Me._cmdGroup_3.Name = "_cmdGroup_3"
        Me._cmdGroup_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdGroup_3.Size = New System.Drawing.Size(49, 21)
        Me._cmdGroup_3.TabIndex = 43
        Me._cmdGroup_3.Text = "Right"
        Me._cmdGroup_3.UseVisualStyleBackColor = False
        '
        '_cmdGroup_2
        '
        Me._cmdGroup_2.BackColor = System.Drawing.SystemColors.Control
        Me._cmdGroup_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdGroup_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGroup.SetIndex(Me._cmdGroup_2, CType(2, Short))
        Me._cmdGroup_2.Location = New System.Drawing.Point(304, 44)
        Me._cmdGroup_2.Name = "_cmdGroup_2"
        Me._cmdGroup_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdGroup_2.Size = New System.Drawing.Size(49, 21)
        Me._cmdGroup_2.TabIndex = 42
        Me._cmdGroup_2.Text = "Left"
        Me._cmdGroup_2.UseVisualStyleBackColor = False
        '
        '_cmdGroup_1
        '
        Me._cmdGroup_1.BackColor = System.Drawing.SystemColors.Control
        Me._cmdGroup_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdGroup_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGroup.SetIndex(Me._cmdGroup_1, CType(1, Short))
        Me._cmdGroup_1.Location = New System.Drawing.Point(356, 20)
        Me._cmdGroup_1.Name = "_cmdGroup_1"
        Me._cmdGroup_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdGroup_1.Size = New System.Drawing.Size(49, 21)
        Me._cmdGroup_1.TabIndex = 41
        Me._cmdGroup_1.Text = "Right"
        Me._cmdGroup_1.UseVisualStyleBackColor = False
        '
        '_cmdGroup_0
        '
        Me._cmdGroup_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdGroup_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdGroup_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGroup.SetIndex(Me._cmdGroup_0, CType(0, Short))
        Me._cmdGroup_0.Location = New System.Drawing.Point(304, 20)
        Me._cmdGroup_0.Name = "_cmdGroup_0"
        Me._cmdGroup_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdGroup_0.Size = New System.Drawing.Size(49, 21)
        Me._cmdGroup_0.TabIndex = 38
        Me._cmdGroup_0.Text = "Left"
        Me._cmdGroup_0.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(334, 4)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(36, 13)
        Me.Label15.TabIndex = 52
        Me.Label15.Text = "Group"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(230, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(68, 12)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "Uncheck All:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(237, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Check All:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(159, 60)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(20, 13)
        Me.Label17.TabIndex = 41
        Me.Label17.Text = "ms"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(227, 74)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 13)
        Me.Label16.TabIndex = 40
        Me.Label16.Text = "Pulse Period:"
        '
        'txtPulsePeriodL
        '
        Me.txtPulsePeriodL.Location = New System.Drawing.Point(304, 71)
        Me.txtPulsePeriodL.MaxLength = 10
        Me.txtPulsePeriodL.Name = "txtPulsePeriodL"
        Me.txtPulsePeriodL.Size = New System.Drawing.Size(49, 20)
        Me.txtPulsePeriodL.TabIndex = 102
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 60)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(92, 13)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "Stimulus Duration:"
        '
        'txtDuration
        '
        Me.txtDuration.Location = New System.Drawing.Point(104, 57)
        Me.txtDuration.MaxLength = 10
        Me.txtDuration.Name = "txtDuration"
        Me.txtDuration.Size = New System.Drawing.Size(49, 20)
        Me.txtDuration.TabIndex = 101
        '
        'chkDelayed
        '
        Me.chkDelayed.AutoSize = True
        Me.chkDelayed.BackColor = System.Drawing.SystemColors.Control
        Me.chkDelayed.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkDelayed.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkDelayed.Location = New System.Drawing.Point(16, 12)
        Me.chkDelayed.Name = "chkDelayed"
        Me.chkDelayed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkDelayed.Size = New System.Drawing.Size(65, 17)
        Me.chkDelayed.TabIndex = 36
        Me.chkDelayed.Text = "Delayed"
        Me.chkDelayed.UseVisualStyleBackColor = False
        '
        'optLeftFirst
        '
        Me.optLeftFirst.BackColor = System.Drawing.SystemColors.Control
        Me.optLeftFirst.Cursor = System.Windows.Forms.Cursors.Default
        Me.optLeftFirst.Enabled = False
        Me.optLeftFirst.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optLeftFirst.Location = New System.Drawing.Point(84, 6)
        Me.optLeftFirst.Name = "optLeftFirst"
        Me.optLeftFirst.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optLeftFirst.Size = New System.Drawing.Size(73, 17)
        Me.optLeftFirst.TabIndex = 35
        Me.optLeftFirst.Text = "Left first"
        Me.optLeftFirst.UseVisualStyleBackColor = False
        '
        'optRightFirst
        '
        Me.optRightFirst.BackColor = System.Drawing.SystemColors.Control
        Me.optRightFirst.Cursor = System.Windows.Forms.Cursors.Default
        Me.optRightFirst.Enabled = False
        Me.optRightFirst.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optRightFirst.Location = New System.Drawing.Point(84, 22)
        Me.optRightFirst.Name = "optRightFirst"
        Me.optRightFirst.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optRightFirst.Size = New System.Drawing.Size(73, 17)
        Me.optRightFirst.TabIndex = 34
        Me.optRightFirst.Text = "Right first"
        Me.optRightFirst.UseVisualStyleBackColor = False
        '
        'lblNameL
        '
        Me.lblNameL.BackColor = System.Drawing.SystemColors.Control
        Me.lblNameL.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblNameL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNameL.Location = New System.Drawing.Point(48, 94)
        Me.lblNameL.Name = "lblNameL"
        Me.lblNameL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNameL.Size = New System.Drawing.Size(137, 17)
        Me.lblNameL.TabIndex = 29
        Me.lblNameL.Text = "Max Mustermann"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(8, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Name:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_sldL_0
        '
        Me._sldL_0.AutoSize = False
        Me._sldL_0.Location = New System.Drawing.Point(61, 411)
        Me._sldL_0.Maximum = 128
        Me._sldL_0.Name = "_sldL_0"
        Me._sldL_0.Orientation = System.Windows.Forms.Orientation.Vertical
        Me._sldL_0.Size = New System.Drawing.Size(28, 157)
        Me._sldL_0.TabIndex = 22
        Me._sldL_0.TickFrequency = 10
        '
        '_chkGroupR_0
        '
        Me._chkGroupR_0.BackColor = System.Drawing.SystemColors.Control
        Me._chkGroupR_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkGroupR_0.Enabled = False
        Me._chkGroupR_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkGroupR.SetIndex(Me._chkGroupR_0, CType(0, Short))
        Me._chkGroupR_0.Location = New System.Drawing.Point(104, 271)
        Me._chkGroupR_0.Name = "_chkGroupR_0"
        Me._chkGroupR_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkGroupR_0.Size = New System.Drawing.Size(13, 25)
        Me._chkGroupR_0.TabIndex = 16
        Me._chkGroupR_0.UseVisualStyleBackColor = False
        '
        '_chkGroupL_0
        '
        Me._chkGroupL_0.BackColor = System.Drawing.SystemColors.Control
        Me._chkGroupL_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._chkGroupL_0.Enabled = False
        Me._chkGroupL_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkGroupL.SetIndex(Me._chkGroupL_0, CType(0, Short))
        Me._chkGroupL_0.Location = New System.Drawing.Point(68, 271)
        Me._chkGroupL_0.Name = "_chkGroupL_0"
        Me._chkGroupL_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chkGroupL_0.Size = New System.Drawing.Size(13, 25)
        Me._chkGroupL_0.TabIndex = 14
        Me._chkGroupL_0.UseVisualStyleBackColor = False
        '
        'sbStatusBar
        '
        Me.sbStatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._sbStatusBar_Panel1, Me._sbStatusBar_Panel2, Me._sbStatusBar_Panel3, Me._sbStatusBar_Panel4, Me._sbStatusBar_Panel5})
        Me.sbStatusBar.Location = New System.Drawing.Point(0, 706)
        Me.sbStatusBar.Name = "sbStatusBar"
        Me.sbStatusBar.Size = New System.Drawing.Size(494, 22)
        Me.sbStatusBar.TabIndex = 0
        '
        '_sbStatusBar_Panel1
        '
        Me._sbStatusBar_Panel1.AutoSize = False
        Me._sbStatusBar_Panel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._sbStatusBar_Panel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._sbStatusBar_Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me._sbStatusBar_Panel1.Name = "_sbStatusBar_Panel1"
        Me._sbStatusBar_Panel1.Size = New System.Drawing.Size(95, 22)
        Me._sbStatusBar_Panel1.Spring = True
        Me._sbStatusBar_Panel1.Text = "Status"
        Me._sbStatusBar_Panel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me._sbStatusBar_Panel1.ToolTipText = "Current Status"
        '
        '_sbStatusBar_Panel2
        '
        Me._sbStatusBar_Panel2.AutoSize = False
        Me._sbStatusBar_Panel2.BackColor = System.Drawing.SystemColors.Control
        Me._sbStatusBar_Panel2.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._sbStatusBar_Panel2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._sbStatusBar_Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me._sbStatusBar_Panel2.Name = "_sbStatusBar_Panel2"
        Me._sbStatusBar_Panel2.Size = New System.Drawing.Size(96, 22)
        Me._sbStatusBar_Panel2.ToolTipText = "Implant type used for the LEFT ear"
        '
        '_sbStatusBar_Panel3
        '
        Me._sbStatusBar_Panel3.AutoSize = False
        Me._sbStatusBar_Panel3.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._sbStatusBar_Panel3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._sbStatusBar_Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me._sbStatusBar_Panel3.Name = "_sbStatusBar_Panel3"
        Me._sbStatusBar_Panel3.Size = New System.Drawing.Size(96, 22)
        Me._sbStatusBar_Panel3.ToolTipText = "Implant type used for the RIGHT ear"
        '
        '_sbStatusBar_Panel4
        '
        Me._sbStatusBar_Panel4.AutoSize = False
        Me._sbStatusBar_Panel4.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._sbStatusBar_Panel4.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._sbStatusBar_Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me._sbStatusBar_Panel4.Name = "_sbStatusBar_Panel4"
        Me._sbStatusBar_Panel4.Size = New System.Drawing.Size(96, 22)
        Me._sbStatusBar_Panel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_sbStatusBar_Panel5
        '
        Me._sbStatusBar_Panel5.AutoSize = False
        Me._sbStatusBar_Panel5.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._sbStatusBar_Panel5.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._sbStatusBar_Panel5.Margin = New System.Windows.Forms.Padding(0)
        Me._sbStatusBar_Panel5.Name = "_sbStatusBar_Panel5"
        Me._sbStatusBar_Panel5.Size = New System.Drawing.Size(96, 22)
        Me._sbStatusBar_Panel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_sldR_0
        '
        Me._sldR_0.AutoSize = False
        Me._sldR_0.Location = New System.Drawing.Point(90, 411)
        Me._sldR_0.Maximum = 128
        Me._sldR_0.Name = "_sldR_0"
        Me._sldR_0.Orientation = System.Windows.Forms.Orientation.Vertical
        Me._sldR_0.Size = New System.Drawing.Size(33, 157)
        Me._sldR_0.TabIndex = 23
        Me._sldR_0.TickFrequency = 10
        Me._sldR_0.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label3.Location = New System.Drawing.Point(0, 609)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(60, 29)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Dyn. range (dB)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblDynamicR_0
        '
        Me._lblDynamicR_0.BackColor = System.Drawing.Color.Transparent
        Me._lblDynamicR_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDynamicR_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDynamicR.SetIndex(Me._lblDynamicR_0, CType(0, Short))
        Me._lblDynamicR_0.Location = New System.Drawing.Point(95, 612)
        Me._lblDynamicR_0.Margin = New System.Windows.Forms.Padding(0)
        Me._lblDynamicR_0.Name = "_lblDynamicR_0"
        Me._lblDynamicR_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDynamicR_0.Size = New System.Drawing.Size(28, 29)
        Me._lblDynamicR_0.TabIndex = 24
        Me._lblDynamicR_0.Text = "XXX"
        Me._lblDynamicR_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblDynamicL_0
        '
        Me._lblDynamicL_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblDynamicL_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDynamicL_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDynamicL.SetIndex(Me._lblDynamicL_0, CType(0, Short))
        Me._lblDynamicL_0.Location = New System.Drawing.Point(63, 612)
        Me._lblDynamicL_0.Margin = New System.Windows.Forms.Padding(0)
        Me._lblDynamicL_0.Name = "_lblDynamicL_0"
        Me._lblDynamicL_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDynamicL_0.Size = New System.Drawing.Size(29, 29)
        Me._lblDynamicL_0.TabIndex = 25
        Me._lblDynamicL_0.Text = "XXX"
        '
        '_lblTHRR_0
        '
        Me._lblTHRR_0.BackColor = System.Drawing.Color.Transparent
        Me._lblTHRR_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTHRR_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTHRR.SetIndex(Me._lblTHRR_0, CType(0, Short))
        Me._lblTHRR_0.Location = New System.Drawing.Point(88, 590)
        Me._lblTHRR_0.Margin = New System.Windows.Forms.Padding(0)
        Me._lblTHRR_0.Name = "_lblTHRR_0"
        Me._lblTHRR_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTHRR_0.Size = New System.Drawing.Size(34, 14)
        Me._lblTHRR_0.TabIndex = 21
        Me._lblTHRR_0.Text = "1999"
        Me._lblTHRR_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblMCLR_0
        '
        Me._lblMCLR_0.BackColor = System.Drawing.Color.Transparent
        Me._lblMCLR_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMCLR_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMCLR.SetIndex(Me._lblMCLR_0, CType(0, Short))
        Me._lblMCLR_0.Location = New System.Drawing.Point(88, 318)
        Me._lblMCLR_0.Margin = New System.Windows.Forms.Padding(0)
        Me._lblMCLR_0.Name = "_lblMCLR_0"
        Me._lblMCLR_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMCLR_0.Size = New System.Drawing.Size(34, 14)
        Me._lblMCLR_0.TabIndex = 19
        Me._lblMCLR_0.Text = "1999"
        Me._lblMCLR_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblTHRL_0
        '
        Me._lblTHRL_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblTHRL_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTHRL_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTHRL.SetIndex(Me._lblTHRL_0, CType(0, Short))
        Me._lblTHRL_0.Location = New System.Drawing.Point(63, 575)
        Me._lblTHRL_0.Margin = New System.Windows.Forms.Padding(0)
        Me._lblTHRL_0.Name = "_lblTHRL_0"
        Me._lblTHRL_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTHRL_0.Size = New System.Drawing.Size(34, 15)
        Me._lblTHRL_0.TabIndex = 8
        Me._lblTHRL_0.Text = "1999"
        '
        '_lblMCLL_0
        '
        Me._lblMCLL_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblMCLL_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblMCLL_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMCLL.SetIndex(Me._lblMCLL_0, CType(0, Short))
        Me._lblMCLL_0.Location = New System.Drawing.Point(63, 303)
        Me._lblMCLL_0.Margin = New System.Windows.Forms.Padding(0)
        Me._lblMCLL_0.Name = "_lblMCLL_0"
        Me._lblMCLL_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMCLL_0.Size = New System.Drawing.Size(34, 15)
        Me._lblMCLL_0.TabIndex = 9
        Me._lblMCLL_0.Text = "1999"
        '
        '_lblLevelR_0
        '
        Me._lblLevelR_0.BackColor = System.Drawing.Color.Transparent
        Me._lblLevelR_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLevelR_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLevelR_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLevelR.SetIndex(Me._lblLevelR_0, CType(0, Short))
        Me._lblLevelR_0.Location = New System.Drawing.Point(69, 389)
        Me._lblLevelR_0.Margin = New System.Windows.Forms.Padding(0)
        Me._lblLevelR_0.Name = "_lblLevelR_0"
        Me._lblLevelR_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLevelR_0.Size = New System.Drawing.Size(52, 15)
        Me._lblLevelR_0.TabIndex = 20
        Me._lblLevelR_0.Text = "1055"
        Me._lblLevelR_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label2.Location = New System.Drawing.Point(4, 271)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(51, 20)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Group"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lineGrid_4
        '
        Me._lineGrid_4.BackColor = System.Drawing.SystemColors.WindowText
        Me.lineGrid.SetIndex(Me._lineGrid_4, CType(4, Short))
        Me._lineGrid_4.Location = New System.Drawing.Point(44, 299)
        Me._lineGrid_4.Name = "_lineGrid_4"
        Me._lineGrid_4.Size = New System.Drawing.Size(128, 1)
        Me._lineGrid_4.TabIndex = 48
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label1.Location = New System.Drawing.Point(4, 207)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Electrode"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lineGrid_5
        '
        Me._lineGrid_5.BackColor = System.Drawing.SystemColors.WindowText
        Me.lineGrid.SetIndex(Me._lineGrid_5, CType(5, Short))
        Me._lineGrid_5.Location = New System.Drawing.Point(44, 231)
        Me._lineGrid_5.Name = "_lineGrid_5"
        Me._lineGrid_5.Size = New System.Drawing.Size(128, 1)
        Me._lineGrid_5.TabIndex = 49
        '
        '_lblChR_0
        '
        Me._lblChR_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblChR_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblChR_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblChR.SetIndex(Me._lblChR_0, CType(0, Short))
        Me._lblChR_0.Location = New System.Drawing.Point(100, 235)
        Me._lblChR_0.Name = "_lblChR_0"
        Me._lblChR_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblChR_0.Size = New System.Drawing.Size(21, 28)
        Me._lblChR_0.TabIndex = 11
        Me._lblChR_0.Text = "R"
        Me._lblChR_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblChL_0
        '
        Me._lblChL_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblChL_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblChL_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblChL.SetIndex(Me._lblChL_0, CType(0, Short))
        Me._lblChL_0.Location = New System.Drawing.Point(64, 235)
        Me._lblChL_0.Name = "_lblChL_0"
        Me._lblChL_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblChL_0.Size = New System.Drawing.Size(21, 28)
        Me._lblChL_0.TabIndex = 10
        Me._lblChL_0.Text = "L"
        Me._lblChL_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lineGrid_6
        '
        Me._lineGrid_6.BackColor = System.Drawing.SystemColors.WindowText
        Me.lineGrid.SetIndex(Me._lineGrid_6, CType(6, Short))
        Me._lineGrid_6.Location = New System.Drawing.Point(44, 371)
        Me._lineGrid_6.Name = "_lineGrid_6"
        Me._lineGrid_6.Size = New System.Drawing.Size(128, 1)
        Me._lineGrid_6.TabIndex = 50
        '
        'lblLevelLabel
        '
        Me.lblLevelLabel.BackColor = System.Drawing.SystemColors.Control
        Me.lblLevelLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLevelLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLevelLabel.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblLevelLabel.Location = New System.Drawing.Point(12, 375)
        Me.lblLevelLabel.Name = "lblLevelLabel"
        Me.lblLevelLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLevelLabel.Size = New System.Drawing.Size(43, 26)
        Me.lblLevelLabel.TabIndex = 6
        Me.lblLevelLabel.Text = "Level (cu)"
        Me.lblLevelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_lineGrid_0
        '
        Me._lineGrid_0.BackColor = System.Drawing.SystemColors.WindowText
        Me.lineGrid.SetIndex(Me._lineGrid_0, CType(0, Short))
        Me._lineGrid_0.Location = New System.Drawing.Point(44, 267)
        Me._lineGrid_0.Name = "_lineGrid_0"
        Me._lineGrid_0.Size = New System.Drawing.Size(128, 1)
        Me._lineGrid_0.TabIndex = 52
        '
        '_lineGrid_1
        '
        Me._lineGrid_1.BackColor = System.Drawing.SystemColors.WindowText
        Me.lineGrid.SetIndex(Me._lineGrid_1, CType(1, Short))
        Me._lineGrid_1.Location = New System.Drawing.Point(44, 335)
        Me._lineGrid_1.Name = "_lineGrid_1"
        Me._lineGrid_1.Size = New System.Drawing.Size(128, 1)
        Me._lineGrid_1.TabIndex = 53
        '
        '_lineGrid_2
        '
        Me._lineGrid_2.BackColor = System.Drawing.SystemColors.WindowText
        Me.lineGrid.SetIndex(Me._lineGrid_2, CType(2, Short))
        Me._lineGrid_2.Location = New System.Drawing.Point(44, 571)
        Me._lineGrid_2.Name = "_lineGrid_2"
        Me._lineGrid_2.Size = New System.Drawing.Size(124, 1)
        Me._lineGrid_2.TabIndex = 54
        '
        '_lineGrid_3
        '
        Me._lineGrid_3.BackColor = System.Drawing.SystemColors.WindowText
        Me.lineGrid.SetIndex(Me._lineGrid_3, CType(3, Short))
        Me._lineGrid_3.Location = New System.Drawing.Point(44, 607)
        Me._lineGrid_3.Name = "_lineGrid_3"
        Me._lineGrid_3.Size = New System.Drawing.Size(112, 1)
        Me._lineGrid_3.TabIndex = 55
        '
        'lblTHRLabel
        '
        Me.lblTHRLabel.BackColor = System.Drawing.SystemColors.Control
        Me.lblTHRLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTHRLabel.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblTHRLabel.Location = New System.Drawing.Point(-3, 580)
        Me.lblTHRLabel.Name = "lblTHRLabel"
        Me.lblTHRLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTHRLabel.Size = New System.Drawing.Size(59, 18)
        Me.lblTHRLabel.TabIndex = 4
        Me.lblTHRLabel.Text = "THR (cu)"
        Me.lblTHRLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMCLLabel
        '
        Me.lblMCLLabel.BackColor = System.Drawing.SystemColors.Control
        Me.lblMCLLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMCLLabel.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblMCLLabel.Location = New System.Drawing.Point(-1, 309)
        Me.lblMCLLabel.Name = "lblMCLLabel"
        Me.lblMCLLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMCLLabel.Size = New System.Drawing.Size(57, 23)
        Me.lblMCLLabel.TabIndex = 3
        Me.lblMCLLabel.Text = "MCL (cu)"
        Me.lblMCLLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLevelL_0
        '
        Me._lblLevelL_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblLevelL_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLevelL_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLevelL_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLevelL.SetIndex(Me._lblLevelL_0, CType(0, Short))
        Me._lblLevelL_0.Location = New System.Drawing.Point(63, 375)
        Me._lblLevelL_0.Margin = New System.Windows.Forms.Padding(0)
        Me._lblLevelL_0.Name = "_lblLevelL_0"
        Me._lblLevelL_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLevelL_0.Size = New System.Drawing.Size(55, 14)
        Me._lblLevelL_0.TabIndex = 2
        Me._lblLevelL_0.Text = "1055"
        '
        '_lblCh_0
        '
        Me._lblCh_0.BackColor = System.Drawing.Color.Transparent
        Me._lblCh_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblCh_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCh_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblCh_0.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblCh.SetIndex(Me._lblCh_0, CType(0, Short))
        Me._lblCh_0.Location = New System.Drawing.Point(60, 199)
        Me._lblCh_0.Name = "_lblCh_0"
        Me._lblCh_0.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me._lblCh_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCh_0.Size = New System.Drawing.Size(64, 492)
        Me._lblCh_0.TabIndex = 5
        Me._lblCh_0.Text = "1"
        Me._lblCh_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdGroup
        '
        '
        '_lblDrL_0
        '
        Me._lblDrL_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblDrL_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDrL_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDrL_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDrL.SetIndex(Me._lblDrL_0, CType(0, Short))
        Me._lblDrL_0.Location = New System.Drawing.Point(63, 339)
        Me._lblDrL_0.Margin = New System.Windows.Forms.Padding(0)
        Me._lblDrL_0.Name = "_lblDrL_0"
        Me._lblDrL_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDrL_0.Size = New System.Drawing.Size(55, 14)
        Me._lblDrL_0.TabIndex = 70
        Me._lblDrL_0.Text = "1055"
        '
        '_lblDrR_0
        '
        Me._lblDrR_0.BackColor = System.Drawing.Color.Transparent
        Me._lblDrR_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblDrR_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblDrR_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDrR.SetIndex(Me._lblDrR_0, CType(0, Short))
        Me._lblDrR_0.Location = New System.Drawing.Point(69, 353)
        Me._lblDrR_0.Margin = New System.Windows.Forms.Padding(0)
        Me._lblDrR_0.Name = "_lblDrR_0"
        Me._lblDrR_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblDrR_0.Size = New System.Drawing.Size(52, 15)
        Me._lblDrR_0.TabIndex = 71
        Me._lblDrR_0.Text = "1055"
        Me._lblDrR_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lineGrid_7
        '
        Me._lineGrid_7.BackColor = System.Drawing.SystemColors.WindowText
        Me.lineGrid.SetIndex(Me._lineGrid_7, CType(7, Short))
        Me._lineGrid_7.Location = New System.Drawing.Point(44, 640)
        Me._lineGrid_7.Name = "_lineGrid_7"
        Me._lineGrid_7.Size = New System.Drawing.Size(112, 1)
        Me._lineGrid_7.TabIndex = 60
        '
        '_lineGrid_8
        '
        Me._lineGrid_8.BackColor = System.Drawing.SystemColors.WindowText
        Me.lineGrid.SetIndex(Me._lineGrid_8, CType(8, Short))
        Me._lineGrid_8.Location = New System.Drawing.Point(44, 407)
        Me._lineGrid_8.Name = "_lineGrid_8"
        Me._lineGrid_8.Size = New System.Drawing.Size(128, 1)
        Me._lineGrid_8.TabIndex = 66
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuParameters, Me.mnuView})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(494, 24)
        Me.MainMenu1.TabIndex = 58
        '
        'mnuParameters
        '
        Me.mnuParameters.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuParametersReload, Me.mnuParametersResetToTHR, Me.mnuParametersResetPhDur, Me.mnuParametersLoad, Me.mnuParametersImport, Me.mnuFileBar0, Me.mnuParametersExport, Me.mnuParametersExportAmpElPairs, Me.mnuFileBar1, Me.mnuExit})
        Me.mnuParameters.Name = "mnuParameters"
        Me.mnuParameters.Size = New System.Drawing.Size(78, 20)
        Me.mnuParameters.Text = "&Parameters"
        '
        'mnuParametersReload
        '
        Me.mnuParametersReload.Name = "mnuParametersReload"
        Me.mnuParametersReload.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.mnuParametersReload.Size = New System.Drawing.Size(270, 22)
        Me.mnuParametersReload.Text = "&Reload From Application"
        '
        'mnuParametersResetToTHR
        '
        Me.mnuParametersResetToTHR.Name = "mnuParametersResetToTHR"
        Me.mnuParametersResetToTHR.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.mnuParametersResetToTHR.Size = New System.Drawing.Size(270, 22)
        Me.mnuParametersResetToTHR.Text = "Reset Amplitudes to &THR"
        '
        'mnuParametersResetPhDur
        '
        Me.mnuParametersResetPhDur.Name = "mnuParametersResetPhDur"
        Me.mnuParametersResetPhDur.Size = New System.Drawing.Size(270, 22)
        Me.mnuParametersResetPhDur.Text = "Reset Phase Durations to the Fitting"
        '
        'mnuParametersLoad
        '
        Me.mnuParametersLoad.Name = "mnuParametersLoad"
        Me.mnuParametersLoad.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.mnuParametersLoad.Size = New System.Drawing.Size(270, 22)
        Me.mnuParametersLoad.Text = "&Load from BLBManu-Settings"
        '
        'mnuParametersImport
        '
        Me.mnuParametersImport.Name = "mnuParametersImport"
        Me.mnuParametersImport.Size = New System.Drawing.Size(270, 22)
        Me.mnuParametersImport.Text = "&Import Amplitudes"
        '
        'mnuFileBar0
        '
        Me.mnuFileBar0.Name = "mnuFileBar0"
        Me.mnuFileBar0.Size = New System.Drawing.Size(267, 6)
        '
        'mnuParametersExport
        '
        Me.mnuParametersExport.Name = "mnuParametersExport"
        Me.mnuParametersExport.Size = New System.Drawing.Size(270, 22)
        Me.mnuParametersExport.Text = "&Export Amplitudes"
        '
        'mnuParametersExportAmpElPairs
        '
        Me.mnuParametersExportAmpElPairs.Name = "mnuParametersExportAmpElPairs"
        Me.mnuParametersExportAmpElPairs.Size = New System.Drawing.Size(270, 22)
        Me.mnuParametersExportAmpElPairs.Text = "Export &Binaural Amp-El-Pairs"
        '
        'mnuFileBar1
        '
        Me.mnuFileBar1.Name = "mnuFileBar1"
        Me.mnuFileBar1.Size = New System.Drawing.Size(267, 6)
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(270, 22)
        Me.mnuExit.Text = "E&xit"
        '
        'mnuView
        '
        Me.mnuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelpShortcuts, Me.mnuViewStimulus})
        Me.mnuView.Name = "mnuView"
        Me.mnuView.Size = New System.Drawing.Size(44, 20)
        Me.mnuView.Text = "&View"
        '
        'mnuHelpShortcuts
        '
        Me.mnuHelpShortcuts.Name = "mnuHelpShortcuts"
        Me.mnuHelpShortcuts.Size = New System.Drawing.Size(241, 22)
        Me.mnuHelpShortcuts.Text = "&Shortcuts"
        '
        'mnuViewStimulus
        '
        Me.mnuViewStimulus.Name = "mnuViewStimulus"
        Me.mnuViewStimulus.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.mnuViewStimulus.Size = New System.Drawing.Size(241, 22)
        Me.mnuViewStimulus.Text = "Stimulus Before &Assembling"
        '
        '_txtPhDurL_0
        '
        Me._txtPhDurL_0.Location = New System.Drawing.Point(61, 644)
        Me._txtPhDurL_0.MaxLength = 10
        Me._txtPhDurL_0.Name = "_txtPhDurL_0"
        Me._txtPhDurL_0.Size = New System.Drawing.Size(30, 20)
        Me._txtPhDurL_0.TabIndex = 59
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label10.Location = New System.Drawing.Point(-6, 650)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(64, 32)
        Me.Label10.TabIndex = 61
        Me.Label10.Text = "Phase (µs) dur. (tu)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblPhDurL_0
        '
        Me._lblPhDurL_0.Location = New System.Drawing.Point(63, 669)
        Me._lblPhDurL_0.Margin = New System.Windows.Forms.Padding(0)
        Me._lblPhDurL_0.Name = "_lblPhDurL_0"
        Me._lblPhDurL_0.Size = New System.Drawing.Size(28, 13)
        Me._lblPhDurL_0.TabIndex = 62
        Me._lblPhDurL_0.Text = "XXX"
        '
        '_txtPhDurR_0
        '
        Me._txtPhDurR_0.Location = New System.Drawing.Point(92, 644)
        Me._txtPhDurR_0.MaxLength = 10
        Me._txtPhDurR_0.Name = "_txtPhDurR_0"
        Me._txtPhDurR_0.Size = New System.Drawing.Size(30, 20)
        Me._txtPhDurR_0.TabIndex = 63
        '
        '_lblPhDurR_0
        '
        Me._lblPhDurR_0.Location = New System.Drawing.Point(94, 669)
        Me._lblPhDurR_0.Margin = New System.Windows.Forms.Padding(0)
        Me._lblPhDurR_0.Name = "_lblPhDurR_0"
        Me._lblPhDurR_0.Size = New System.Drawing.Size(28, 13)
        Me._lblPhDurR_0.TabIndex = 64
        Me._lblPhDurR_0.Text = "XXX"
        '
        'panelData
        '
        Me.panelData.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.panelData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelData.Controls.Add(Me.Label9)
        Me.panelData.Controls.Add(Me.Label8)
        Me.panelData.Controls.Add(Me.txtAppendPulseTrain)
        Me.panelData.Controls.Add(Me.cmbAppendPulseTrain)
        Me.panelData.Controls.Add(Me.Label13)
        Me.panelData.Controls.Add(Me.Label12)
        Me.panelData.Controls.Add(Me.lblPulseRateR)
        Me.panelData.Controls.Add(Me.lblPulseRateL)
        Me.panelData.Controls.Add(Me.Label6)
        Me.panelData.Controls.Add(Me.txtPulsePeriodR)
        Me.panelData.Controls.Add(Me.lblNameL)
        Me.panelData.Controls.Add(Me.Label5)
        Me.panelData.Controls.Add(Me.cmdGroupStimulate)
        Me.panelData.Controls.Add(Me._cmdGroup_3)
        Me.panelData.Controls.Add(Me._cmdGroup_2)
        Me.panelData.Controls.Add(Me.txtPulsePeriodL)
        Me.panelData.Controls.Add(Me._cmdGroup_1)
        Me.panelData.Controls.Add(Me.Label17)
        Me.panelData.Controls.Add(Me._cmdGroup_0)
        Me.panelData.Controls.Add(Me.optRightFirst)
        Me.panelData.Controls.Add(Me.Label15)
        Me.panelData.Controls.Add(Me.Label16)
        Me.panelData.Controls.Add(Me.Label7)
        Me.panelData.Controls.Add(Me.optLeftFirst)
        Me.panelData.Controls.Add(Me.Label4)
        Me.panelData.Controls.Add(Me.chkDelayed)
        Me.panelData.Controls.Add(Me.Label14)
        Me.panelData.Controls.Add(Me.txtDuration)
        Me.panelData.Location = New System.Drawing.Point(12, 27)
        Me.panelData.Name = "panelData"
        Me.panelData.Size = New System.Drawing.Size(470, 154)
        Me.panelData.TabIndex = 65
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(255, 126)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "Parameters:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(8, 126)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(97, 13)
        Me.Label8.TabIndex = 61
        Me.Label8.Text = "AppendPulseTrain:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtAppendPulseTrain
        '
        Me.txtAppendPulseTrain.Location = New System.Drawing.Point(324, 123)
        Me.txtAppendPulseTrain.Name = "txtAppendPulseTrain"
        Me.txtAppendPulseTrain.Size = New System.Drawing.Size(135, 20)
        Me.txtAppendPulseTrain.TabIndex = 106
        '
        'cmbAppendPulseTrain
        '
        Me.cmbAppendPulseTrain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAppendPulseTrain.FormattingEnabled = True
        Me.cmbAppendPulseTrain.Location = New System.Drawing.Point(110, 123)
        Me.cmbAppendPulseTrain.Name = "cmbAppendPulseTrain"
        Me.cmbAppendPulseTrain.Size = New System.Drawing.Size(137, 21)
        Me.cmbAppendPulseTrain.TabIndex = 59
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(234, 97)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 13)
        Me.Label13.TabIndex = 58
        Me.Label13.Text = "Pulse Rate:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(411, 97)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 13)
        Me.Label12.TabIndex = 57
        Me.Label12.Text = "pps"
        '
        'lblPulseRateR
        '
        Me.lblPulseRateR.BackColor = System.Drawing.SystemColors.Control
        Me.lblPulseRateR.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPulseRateR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPulseRateR.Location = New System.Drawing.Point(353, 97)
        Me.lblPulseRateR.Name = "lblPulseRateR"
        Me.lblPulseRateR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPulseRateR.Size = New System.Drawing.Size(42, 13)
        Me.lblPulseRateR.TabIndex = 56
        Me.lblPulseRateR.Text = "6000"
        Me.lblPulseRateR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPulseRateL
        '
        Me.lblPulseRateL.BackColor = System.Drawing.SystemColors.Control
        Me.lblPulseRateL.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPulseRateL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPulseRateL.Location = New System.Drawing.Point(301, 97)
        Me.lblPulseRateL.Name = "lblPulseRateL"
        Me.lblPulseRateL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPulseRateL.Size = New System.Drawing.Size(42, 13)
        Me.lblPulseRateL.TabIndex = 55
        Me.lblPulseRateL.Text = "6000"
        Me.lblPulseRateL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(411, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 13)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "µs"
        '
        'txtPulsePeriodR
        '
        Me.txtPulsePeriodR.Location = New System.Drawing.Point(356, 71)
        Me.txtPulsePeriodR.MaxLength = 10
        Me.txtPulsePeriodR.Name = "txtPulsePeriodR"
        Me.txtPulsePeriodR.Size = New System.Drawing.Size(49, 20)
        Me.txtPulsePeriodR.TabIndex = 103
        '
        'lblLevelLabelDR
        '
        Me.lblLevelLabelDR.BackColor = System.Drawing.SystemColors.Control
        Me.lblLevelLabelDR.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLevelLabelDR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLevelLabelDR.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblLevelLabelDR.Location = New System.Drawing.Point(12, 339)
        Me.lblLevelLabelDR.Name = "lblLevelLabelDR"
        Me.lblLevelLabelDR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLevelLabelDR.Size = New System.Drawing.Size(43, 26)
        Me.lblLevelLabelDR.TabIndex = 67
        Me.lblLevelLabelDR.Text = "Level (DR)"
        Me.lblLevelLabelDR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rDR
        '
        Me.rDR.AutoSize = True
        Me.rDR.Location = New System.Drawing.Point(7, 345)
        Me.rDR.Name = "rDR"
        Me.rDR.Size = New System.Drawing.Size(14, 13)
        Me.rDR.TabIndex = 68
        Me.rDR.TabStop = True
        Me.rDR.UseVisualStyleBackColor = True
        '
        'rCU
        '
        Me.rCU.AutoSize = True
        Me.rCU.Location = New System.Drawing.Point(7, 381)
        Me.rCU.Name = "rCU"
        Me.rCU.Size = New System.Drawing.Size(14, 13)
        Me.rCU.TabIndex = 69
        Me.rCU.TabStop = True
        Me.rCU.UseVisualStyleBackColor = True
        '
        'frmLevelDancer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(494, 728)
        Me.Controls.Add(Me._lblDrR_0)
        Me.Controls.Add(Me._lblDrL_0)
        Me.Controls.Add(Me.rCU)
        Me.Controls.Add(Me.rDR)
        Me.Controls.Add(Me.lblLevelLabelDR)
        Me.Controls.Add(Me._lineGrid_8)
        Me.Controls.Add(Me.panelData)
        Me.Controls.Add(Me._lblPhDurR_0)
        Me.Controls.Add(Me._txtPhDurR_0)
        Me.Controls.Add(Me._lblPhDurL_0)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me._lineGrid_7)
        Me.Controls.Add(Me._txtPhDurL_0)
        Me.Controls.Add(Me._sldL_0)
        Me.Controls.Add(Me._chkGroupR_0)
        Me.Controls.Add(Me._chkGroupL_0)
        Me.Controls.Add(Me.sbStatusBar)
        Me.Controls.Add(Me._sldR_0)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me._lblDynamicR_0)
        Me.Controls.Add(Me._lblDynamicL_0)
        Me.Controls.Add(Me._lblTHRR_0)
        Me.Controls.Add(Me._lblMCLR_0)
        Me.Controls.Add(Me._lblTHRL_0)
        Me.Controls.Add(Me._lblMCLL_0)
        Me.Controls.Add(Me._lblLevelR_0)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me._lineGrid_4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me._lineGrid_5)
        Me.Controls.Add(Me._lblChR_0)
        Me.Controls.Add(Me._lblChL_0)
        Me.Controls.Add(Me._lineGrid_6)
        Me.Controls.Add(Me.lblLevelLabel)
        Me.Controls.Add(Me._lineGrid_0)
        Me.Controls.Add(Me._lineGrid_1)
        Me.Controls.Add(Me._lineGrid_2)
        Me.Controls.Add(Me._lineGrid_3)
        Me.Controls.Add(Me.lblTHRLabel)
        Me.Controls.Add(Me.lblMCLLabel)
        Me.Controls.Add(Me._lblLevelL_0)
        Me.Controls.Add(Me._lblCh_0)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(75, 41)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1500, 766)
        Me.Name = "frmLevelDancer"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Level Dancer"
        CType(Me._sldL_0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sbStatusBar.ResumeLayout(False)
        Me.sbStatusBar.PerformLayout()
        CType(Me._sldR_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkGroupL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkGroupR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblChL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblChR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDynamicL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDynamicR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblLevelL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblLevelR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDrL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDrR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMCLL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMCLR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTHRL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTHRR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lineGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lineSplit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.panelData.ResumeLayout(False)
        Me.panelData.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents mnuParametersReload As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtPulsePeriodL As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtDuration As System.Windows.Forms.TextBox
    Friend WithEvents mnuParametersResetToTHR As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuHelpShortcuts As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _txtPhDurL_0 As System.Windows.Forms.TextBox
    Public WithEvents _lineGrid_7 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents _lblPhDurL_0 As System.Windows.Forms.Label
    Friend WithEvents _txtPhDurR_0 As System.Windows.Forms.TextBox
    Friend WithEvents _lblPhDurR_0 As System.Windows.Forms.Label
    Friend WithEvents panelData As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPulsePeriodR As System.Windows.Forms.TextBox
    Public WithEvents lblPulseRateL As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents lblPulseRateR As System.Windows.Forms.Label
    Friend WithEvents mnuParametersResetPhDur As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAppendPulseTrain As System.Windows.Forms.TextBox
    Friend WithEvents cmbAppendPulseTrain As System.Windows.Forms.ComboBox
    Public WithEvents _lineGrid_8 As System.Windows.Forms.Label
    Public WithEvents lblLevelLabelDR As System.Windows.Forms.Label
    Friend WithEvents rDR As System.Windows.Forms.RadioButton
    Friend WithEvents rCU As System.Windows.Forms.RadioButton
    Public WithEvents _lblDrR_0 As System.Windows.Forms.Label
    Public WithEvents _lblDrL_0 As System.Windows.Forms.Label
End Class