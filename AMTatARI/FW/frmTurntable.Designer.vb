<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmTurntable
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
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
	Public WithEvents _cmdMoveValue_5 As System.Windows.Forms.Button
	Public WithEvents _cmdMoveValue_4 As System.Windows.Forms.Button
	Public WithEvents _cmdMoveValue_3 As System.Windows.Forms.Button
	Public WithEvents _cmdMoveValue_2 As System.Windows.Forms.Button
	Public WithEvents _cmdMoveValue_1 As System.Windows.Forms.Button
	Public WithEvents _cmdMoveValue_0 As System.Windows.Forms.Button
	Public WithEvents cmdSetForced As System.Windows.Forms.Button
	Public WithEvents tmrUnload As System.Windows.Forms.Timer
	Public WithEvents cmdMove As System.Windows.Forms.Button
	Public WithEvents txtReqPos As System.Windows.Forms.TextBox
	Public WithEvents cmdResetCW As System.Windows.Forms.Button
	Public WithEvents cmdResetCCW As System.Windows.Forms.Button
	Public WithEvents cmdCCW As System.Windows.Forms.Button
	Public WithEvents cmdCW As System.Windows.Forms.Button
	Public WithEvents tmrRefresh As System.Windows.Forms.Timer
    Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents pbTime As System.Windows.Forms.ProgressBar
	Public WithEvents lblTrueAzi As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents lblCurrentAzi As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents shpStep As System.Windows.Forms.Label
    Public WithEvents lblStepMark As System.Windows.Forms.Label
    Public WithEvents shpZero As System.Windows.Forms.Label
    Public WithEvents lblZeroMark As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents cmdMoveValue As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTurntable))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._cmdMoveValue_5 = New System.Windows.Forms.Button()
        Me._cmdMoveValue_4 = New System.Windows.Forms.Button()
        Me._cmdMoveValue_3 = New System.Windows.Forms.Button()
        Me._cmdMoveValue_2 = New System.Windows.Forms.Button()
        Me._cmdMoveValue_1 = New System.Windows.Forms.Button()
        Me._cmdMoveValue_0 = New System.Windows.Forms.Button()
        Me.cmdSetForced = New System.Windows.Forms.Button()
        Me.tmrUnload = New System.Windows.Forms.Timer(Me.components)
        Me.cmdMove = New System.Windows.Forms.Button()
        Me.txtReqPos = New System.Windows.Forms.TextBox()
        Me.cmdResetCW = New System.Windows.Forms.Button()
        Me.cmdResetCCW = New System.Windows.Forms.Button()
        Me.cmdCCW = New System.Windows.Forms.Button()
        Me.cmdCW = New System.Windows.Forms.Button()
        Me.tmrRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.pbTime = New System.Windows.Forms.ProgressBar()
        Me.lblTrueAzi = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblCurrentAzi = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.shpStep = New System.Windows.Forms.Label()
        Me.lblStepMark = New System.Windows.Forms.Label()
        Me.shpZero = New System.Windows.Forms.Label()
        Me.lblZeroMark = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdMoveValue = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me._cmdMoveValue_6 = New System.Windows.Forms.Button()
        Me._cmdMoveValue_7 = New System.Windows.Forms.Button()
        Me._cmdMoveValue_8 = New System.Windows.Forms.Button()
        Me._cmdMoveValue_9 = New System.Windows.Forms.Button()
        Me._cmdMoveValue_10 = New System.Windows.Forms.Button()
        Me._cmdMoveValue_11 = New System.Windows.Forms.Button()
        Me.sbStatus = New System.Windows.Forms.StatusStrip()
        Me.sbStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmdPullBrake = New System.Windows.Forms.Button()
        Me.cmdGet = New System.Windows.Forms.Button()
        Me.tmrBrake = New System.Windows.Forms.Timer(Me.components)
        Me.tmrDelayed = New System.Windows.Forms.Timer(Me.components)
        Me.txtReqSpeed = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdSetSpeed = New System.Windows.Forms.Button()
        Me._cmdMoveValue_12 = New System.Windows.Forms.Button()
        Me._cmdMoveValue_13 = New System.Windows.Forms.Button()
        CType(Me.cmdMoveValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sbStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        '_cmdMoveValue_5
        '
        Me._cmdMoveValue_5.BackColor = System.Drawing.SystemColors.Control
        Me._cmdMoveValue_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdMoveValue_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdMoveValue_5.Image = CType(resources.GetObject("_cmdMoveValue_5.Image"), System.Drawing.Image)
        Me._cmdMoveValue_5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdMoveValue.SetIndex(Me._cmdMoveValue_5, CType(5, Short))
        Me._cmdMoveValue_5.Location = New System.Drawing.Point(42, 168)
        Me._cmdMoveValue_5.Name = "_cmdMoveValue_5"
        Me._cmdMoveValue_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdMoveValue_5.Size = New System.Drawing.Size(55, 27)
        Me._cmdMoveValue_5.TabIndex = 22
        Me._cmdMoveValue_5.Text = "+10�"
        Me._cmdMoveValue_5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._cmdMoveValue_5.UseVisualStyleBackColor = False
        '
        '_cmdMoveValue_4
        '
        Me._cmdMoveValue_4.BackColor = System.Drawing.SystemColors.Control
        Me._cmdMoveValue_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdMoveValue_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdMoveValue_4.Image = CType(resources.GetObject("_cmdMoveValue_4.Image"), System.Drawing.Image)
        Me._cmdMoveValue_4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdMoveValue.SetIndex(Me._cmdMoveValue_4, CType(4, Short))
        Me._cmdMoveValue_4.Location = New System.Drawing.Point(233, 168)
        Me._cmdMoveValue_4.Name = "_cmdMoveValue_4"
        Me._cmdMoveValue_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdMoveValue_4.Size = New System.Drawing.Size(53, 27)
        Me._cmdMoveValue_4.TabIndex = 21
        Me._cmdMoveValue_4.Text = "-10�"
        Me._cmdMoveValue_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me._cmdMoveValue_4.UseVisualStyleBackColor = False
        '
        '_cmdMoveValue_3
        '
        Me._cmdMoveValue_3.BackColor = System.Drawing.SystemColors.Control
        Me._cmdMoveValue_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdMoveValue_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdMoveValue.SetIndex(Me._cmdMoveValue_3, CType(3, Short))
        Me._cmdMoveValue_3.Location = New System.Drawing.Point(102, 169)
        Me._cmdMoveValue_3.Name = "_cmdMoveValue_3"
        Me._cmdMoveValue_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdMoveValue_3.Size = New System.Drawing.Size(41, 27)
        Me._cmdMoveValue_3.TabIndex = 20
        Me._cmdMoveValue_3.Text = "90�"
        Me._cmdMoveValue_3.UseVisualStyleBackColor = False
        '
        '_cmdMoveValue_2
        '
        Me._cmdMoveValue_2.BackColor = System.Drawing.SystemColors.Control
        Me._cmdMoveValue_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdMoveValue_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdMoveValue.SetIndex(Me._cmdMoveValue_2, CType(2, Short))
        Me._cmdMoveValue_2.Location = New System.Drawing.Point(183, 169)
        Me._cmdMoveValue_2.Name = "_cmdMoveValue_2"
        Me._cmdMoveValue_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdMoveValue_2.Size = New System.Drawing.Size(41, 27)
        Me._cmdMoveValue_2.TabIndex = 19
        Me._cmdMoveValue_2.Text = "270�"
        Me._cmdMoveValue_2.UseVisualStyleBackColor = False
        '
        '_cmdMoveValue_1
        '
        Me._cmdMoveValue_1.BackColor = System.Drawing.SystemColors.Control
        Me._cmdMoveValue_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdMoveValue_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdMoveValue.SetIndex(Me._cmdMoveValue_1, CType(1, Short))
        Me._cmdMoveValue_1.Location = New System.Drawing.Point(142, 182)
        Me._cmdMoveValue_1.Name = "_cmdMoveValue_1"
        Me._cmdMoveValue_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdMoveValue_1.Size = New System.Drawing.Size(41, 27)
        Me._cmdMoveValue_1.TabIndex = 18
        Me._cmdMoveValue_1.Text = "180�"
        Me._cmdMoveValue_1.UseVisualStyleBackColor = False
        '
        '_cmdMoveValue_0
        '
        Me._cmdMoveValue_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdMoveValue_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdMoveValue_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdMoveValue.SetIndex(Me._cmdMoveValue_0, CType(0, Short))
        Me._cmdMoveValue_0.Location = New System.Drawing.Point(142, 154)
        Me._cmdMoveValue_0.Name = "_cmdMoveValue_0"
        Me._cmdMoveValue_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdMoveValue_0.Size = New System.Drawing.Size(41, 27)
        Me._cmdMoveValue_0.TabIndex = 17
        Me._cmdMoveValue_0.Text = "0�"
        Me._cmdMoveValue_0.UseVisualStyleBackColor = False
        '
        'cmdSetForced
        '
        Me.cmdSetForced.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSetForced.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSetForced.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSetForced.Location = New System.Drawing.Point(227, 57)
        Me.cmdSetForced.Name = "cmdSetForced"
        Me.cmdSetForced.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSetForced.Size = New System.Drawing.Size(35, 27)
        Me.cmdSetForced.TabIndex = 13
        Me.cmdSetForced.Text = "Set"
        Me.cmdSetForced.UseVisualStyleBackColor = False
        '
        'tmrUnload
        '
        Me.tmrUnload.Interval = 10
        '
        'cmdMove
        '
        Me.cmdMove.BackColor = System.Drawing.SystemColors.Control
        Me.cmdMove.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdMove.Location = New System.Drawing.Point(268, 57)
        Me.cmdMove.Name = "cmdMove"
        Me.cmdMove.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdMove.Size = New System.Drawing.Size(45, 27)
        Me.cmdMove.TabIndex = 11
        Me.cmdMove.Text = "Move"
        Me.cmdMove.UseVisualStyleBackColor = False
        '
        'txtReqPos
        '
        Me.txtReqPos.AcceptsReturn = True
        Me.txtReqPos.BackColor = System.Drawing.SystemColors.Window
        Me.txtReqPos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReqPos.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReqPos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReqPos.Location = New System.Drawing.Point(127, 51)
        Me.txtReqPos.MaxLength = 0
        Me.txtReqPos.Name = "txtReqPos"
        Me.txtReqPos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReqPos.Size = New System.Drawing.Size(66, 35)
        Me.txtReqPos.TabIndex = 10
        Me.txtReqPos.Text = "0"
        '
        'cmdResetCW
        '
        Me.cmdResetCW.BackColor = System.Drawing.SystemColors.Control
        Me.cmdResetCW.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdResetCW.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdResetCW.Image = CType(resources.GetObject("cmdResetCW.Image"), System.Drawing.Image)
        Me.cmdResetCW.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdResetCW.Location = New System.Drawing.Point(230, 200)
        Me.cmdResetCW.Name = "cmdResetCW"
        Me.cmdResetCW.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdResetCW.Size = New System.Drawing.Size(87, 27)
        Me.cmdResetCW.TabIndex = 9
        Me.cmdResetCW.Text = "Reset CW"
        Me.cmdResetCW.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdResetCW.UseVisualStyleBackColor = False
        '
        'cmdResetCCW
        '
        Me.cmdResetCCW.BackColor = System.Drawing.SystemColors.Control
        Me.cmdResetCCW.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdResetCCW.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdResetCCW.Image = CType(resources.GetObject("cmdResetCCW.Image"), System.Drawing.Image)
        Me.cmdResetCCW.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdResetCCW.Location = New System.Drawing.Point(10, 200)
        Me.cmdResetCCW.Name = "cmdResetCCW"
        Me.cmdResetCCW.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdResetCCW.Size = New System.Drawing.Size(87, 27)
        Me.cmdResetCCW.TabIndex = 8
        Me.cmdResetCCW.Text = "Reset CCW"
        Me.cmdResetCCW.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdResetCCW.UseVisualStyleBackColor = False
        '
        'cmdCCW
        '
        Me.cmdCCW.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCCW.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCCW.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCCW.Image = CType(resources.GetObject("cmdCCW.Image"), System.Drawing.Image)
        Me.cmdCCW.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCCW.Location = New System.Drawing.Point(72, 99)
        Me.cmdCCW.Name = "cmdCCW"
        Me.cmdCCW.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCCW.Size = New System.Drawing.Size(59, 27)
        Me.cmdCCW.TabIndex = 7
        Me.cmdCCW.Text = "CCW"
        Me.cmdCCW.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCCW.UseVisualStyleBackColor = False
        '
        'cmdCW
        '
        Me.cmdCW.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCW.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCW.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCW.Image = CType(resources.GetObject("cmdCW.Image"), System.Drawing.Image)
        Me.cmdCW.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCW.Location = New System.Drawing.Point(196, 99)
        Me.cmdCW.Name = "cmdCW"
        Me.cmdCW.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCW.Size = New System.Drawing.Size(59, 27)
        Me.cmdCW.TabIndex = 6
        Me.cmdCW.Text = "CW"
        Me.cmdCW.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCW.UseVisualStyleBackColor = False
        '
        'tmrRefresh
        '
        Me.tmrRefresh.Enabled = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Firebrick
        Me.cmdCancel.Location = New System.Drawing.Point(10, 239)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(307, 41)
        Me.cmdCancel.TabIndex = 0
        Me.cmdCancel.Text = "STOP"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'pbTime
        '
        Me.pbTime.Location = New System.Drawing.Point(10, 286)
        Me.pbTime.Name = "pbTime"
        Me.pbTime.Size = New System.Drawing.Size(307, 29)
        Me.pbTime.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbTime.TabIndex = 1
        '
        'lblTrueAzi
        '
        Me.lblTrueAzi.BackColor = System.Drawing.SystemColors.Control
        Me.lblTrueAzi.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTrueAzi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrueAzi.Location = New System.Drawing.Point(136, 37)
        Me.lblTrueAzi.Name = "lblTrueAzi"
        Me.lblTrueAzi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTrueAzi.Size = New System.Drawing.Size(57, 13)
        Me.lblTrueAzi.TabIndex = 16
        Me.lblTrueAzi.Text = "888,5�"
        Me.lblTrueAzi.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(29, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(94, 21)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Current Azimuth:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblCurrentAzi
        '
        Me.lblCurrentAzi.BackColor = System.Drawing.SystemColors.Control
        Me.lblCurrentAzi.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCurrentAzi.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentAzi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCurrentAzi.Location = New System.Drawing.Point(122, 8)
        Me.lblCurrentAzi.Name = "lblCurrentAzi"
        Me.lblCurrentAzi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCurrentAzi.Size = New System.Drawing.Size(84, 29)
        Me.lblCurrentAzi.TabIndex = 14
        Me.lblCurrentAzi.Text = "888,5�"
        Me.lblCurrentAzi.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(190, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(14, 36)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "�"
        '
        'shpStep
        '
        Me.shpStep.BackColor = System.Drawing.Color.Transparent
        Me.shpStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.shpStep.Location = New System.Drawing.Point(300, 28)
        Me.shpStep.Name = "shpStep"
        Me.shpStep.Size = New System.Drawing.Size(17, 17)
        Me.shpStep.TabIndex = 23
        '
        'lblStepMark
        '
        Me.lblStepMark.BackColor = System.Drawing.SystemColors.Control
        Me.lblStepMark.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStepMark.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStepMark.Location = New System.Drawing.Point(224, 28)
        Me.lblStepMark.Name = "lblStepMark"
        Me.lblStepMark.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStepMark.Size = New System.Drawing.Size(62, 17)
        Me.lblStepMark.TabIndex = 4
        Me.lblStepMark.Text = "Step Mark:"
        Me.lblStepMark.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'shpZero
        '
        Me.shpZero.BackColor = System.Drawing.Color.Transparent
        Me.shpZero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.shpZero.Location = New System.Drawing.Point(300, 8)
        Me.shpZero.Name = "shpZero"
        Me.shpZero.Size = New System.Drawing.Size(17, 17)
        Me.shpZero.TabIndex = 24
        '
        'lblZeroMark
        '
        Me.lblZeroMark.AutoSize = True
        Me.lblZeroMark.BackColor = System.Drawing.SystemColors.Control
        Me.lblZeroMark.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblZeroMark.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblZeroMark.Location = New System.Drawing.Point(227, 8)
        Me.lblZeroMark.Name = "lblZeroMark"
        Me.lblZeroMark.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblZeroMark.Size = New System.Drawing.Size(59, 13)
        Me.lblZeroMark.TabIndex = 3
        Me.lblZeroMark.Text = "Zero Mark:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(19, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Requested Azimuth:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdMoveValue
        '
        '
        '_cmdMoveValue_6
        '
        Me._cmdMoveValue_6.BackColor = System.Drawing.SystemColors.Control
        Me._cmdMoveValue_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdMoveValue_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdMoveValue_6.Image = CType(resources.GetObject("_cmdMoveValue_6.Image"), System.Drawing.Image)
        Me._cmdMoveValue_6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdMoveValue.SetIndex(Me._cmdMoveValue_6, CType(6, Short))
        Me._cmdMoveValue_6.Location = New System.Drawing.Point(42, 99)
        Me._cmdMoveValue_6.Name = "_cmdMoveValue_6"
        Me._cmdMoveValue_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdMoveValue_6.Size = New System.Drawing.Size(89, 27)
        Me._cmdMoveValue_6.TabIndex = 28
        Me._cmdMoveValue_6.Text = "Move CCW"
        Me._cmdMoveValue_6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._cmdMoveValue_6.UseVisualStyleBackColor = False
        '
        '_cmdMoveValue_7
        '
        Me._cmdMoveValue_7.BackColor = System.Drawing.SystemColors.Control
        Me._cmdMoveValue_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdMoveValue_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdMoveValue_7.Image = CType(resources.GetObject("_cmdMoveValue_7.Image"), System.Drawing.Image)
        Me._cmdMoveValue_7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdMoveValue.SetIndex(Me._cmdMoveValue_7, CType(7, Short))
        Me._cmdMoveValue_7.Location = New System.Drawing.Point(195, 99)
        Me._cmdMoveValue_7.Name = "_cmdMoveValue_7"
        Me._cmdMoveValue_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdMoveValue_7.Size = New System.Drawing.Size(89, 27)
        Me._cmdMoveValue_7.TabIndex = 30
        Me._cmdMoveValue_7.Text = "Move CW"
        Me._cmdMoveValue_7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me._cmdMoveValue_7.UseVisualStyleBackColor = False
        '
        '_cmdMoveValue_8
        '
        Me._cmdMoveValue_8.BackColor = System.Drawing.SystemColors.Control
        Me._cmdMoveValue_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdMoveValue_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdMoveValue_8.Image = CType(resources.GetObject("_cmdMoveValue_8.Image"), System.Drawing.Image)
        Me._cmdMoveValue_8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdMoveValue.SetIndex(Me._cmdMoveValue_8, CType(8, Short))
        Me._cmdMoveValue_8.Location = New System.Drawing.Point(7, 207)
        Me._cmdMoveValue_8.Name = "_cmdMoveValue_8"
        Me._cmdMoveValue_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdMoveValue_8.Size = New System.Drawing.Size(87, 27)
        Me._cmdMoveValue_8.TabIndex = 32
        Me._cmdMoveValue_8.Text = "-360� CCW"
        Me._cmdMoveValue_8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._cmdMoveValue_8.UseVisualStyleBackColor = False
        '
        '_cmdMoveValue_9
        '
        Me._cmdMoveValue_9.BackColor = System.Drawing.SystemColors.Control
        Me._cmdMoveValue_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdMoveValue_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdMoveValue_9.Image = CType(resources.GetObject("_cmdMoveValue_9.Image"), System.Drawing.Image)
        Me._cmdMoveValue_9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdMoveValue.SetIndex(Me._cmdMoveValue_9, CType(9, Short))
        Me._cmdMoveValue_9.Location = New System.Drawing.Point(230, 166)
        Me._cmdMoveValue_9.Name = "_cmdMoveValue_9"
        Me._cmdMoveValue_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdMoveValue_9.Size = New System.Drawing.Size(87, 27)
        Me._cmdMoveValue_9.TabIndex = 31
        Me._cmdMoveValue_9.Text = "+360� CW"
        Me._cmdMoveValue_9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me._cmdMoveValue_9.UseVisualStyleBackColor = False
        '
        '_cmdMoveValue_10
        '
        Me._cmdMoveValue_10.BackColor = System.Drawing.SystemColors.Control
        Me._cmdMoveValue_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdMoveValue_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdMoveValue_10.Image = CType(resources.GetObject("_cmdMoveValue_10.Image"), System.Drawing.Image)
        Me._cmdMoveValue_10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdMoveValue.SetIndex(Me._cmdMoveValue_10, CType(10, Short))
        Me._cmdMoveValue_10.Location = New System.Drawing.Point(233, 197)
        Me._cmdMoveValue_10.Name = "_cmdMoveValue_10"
        Me._cmdMoveValue_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdMoveValue_10.Size = New System.Drawing.Size(53, 27)
        Me._cmdMoveValue_10.TabIndex = 37
        Me._cmdMoveValue_10.Text = "-1�"
        Me._cmdMoveValue_10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me._cmdMoveValue_10.UseVisualStyleBackColor = False
        '
        '_cmdMoveValue_11
        '
        Me._cmdMoveValue_11.BackColor = System.Drawing.SystemColors.Control
        Me._cmdMoveValue_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdMoveValue_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdMoveValue_11.Image = CType(resources.GetObject("_cmdMoveValue_11.Image"), System.Drawing.Image)
        Me._cmdMoveValue_11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdMoveValue.SetIndex(Me._cmdMoveValue_11, CType(11, Short))
        Me._cmdMoveValue_11.Location = New System.Drawing.Point(41, 197)
        Me._cmdMoveValue_11.Name = "_cmdMoveValue_11"
        Me._cmdMoveValue_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdMoveValue_11.Size = New System.Drawing.Size(55, 27)
        Me._cmdMoveValue_11.TabIndex = 38
        Me._cmdMoveValue_11.Text = "+1�"
        Me._cmdMoveValue_11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._cmdMoveValue_11.UseVisualStyleBackColor = False
        '
        'sbStatus
        '
        Me.sbStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sbStatusLabel})
        Me.sbStatus.Location = New System.Drawing.Point(0, 319)
        Me.sbStatus.Name = "sbStatus"
        Me.sbStatus.Size = New System.Drawing.Size(329, 22)
        Me.sbStatus.TabIndex = 25
        Me.sbStatus.Text = "Status Bar"
        '
        'sbStatusLabel
        '
        Me.sbStatusLabel.Name = "sbStatusLabel"
        Me.sbStatusLabel.Size = New System.Drawing.Size(59, 17)
        Me.sbStatusLabel.Text = "Status Bar"
        '
        'cmdPullBrake
        '
        Me.cmdPullBrake.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPullBrake.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPullBrake.Location = New System.Drawing.Point(100, 207)
        Me.cmdPullBrake.Name = "cmdPullBrake"
        Me.cmdPullBrake.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPullBrake.Size = New System.Drawing.Size(122, 27)
        Me.cmdPullBrake.TabIndex = 26
        Me.cmdPullBrake.Text = "Pull Brake"
        Me.cmdPullBrake.UseVisualStyleBackColor = False
        '
        'cmdGet
        '
        Me.cmdGet.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGet.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGet.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGet.Location = New System.Drawing.Point(252, 37)
        Me.cmdGet.Name = "cmdGet"
        Me.cmdGet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGet.Size = New System.Drawing.Size(34, 27)
        Me.cmdGet.TabIndex = 27
        Me.cmdGet.Text = "Get"
        Me.cmdGet.UseVisualStyleBackColor = False
        '
        'tmrBrake
        '
        Me.tmrBrake.Interval = 500
        '
        'tmrDelayed
        '
        Me.tmrDelayed.Interval = 1000
        '
        'txtReqSpeed
        '
        Me.txtReqSpeed.AcceptsReturn = True
        Me.txtReqSpeed.BackColor = System.Drawing.SystemColors.Window
        Me.txtReqSpeed.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReqSpeed.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReqSpeed.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReqSpeed.Location = New System.Drawing.Point(127, 94)
        Me.txtReqSpeed.MaxLength = 0
        Me.txtReqSpeed.Name = "txtReqSpeed"
        Me.txtReqSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReqSpeed.Size = New System.Drawing.Size(66, 35)
        Me.txtReqSpeed.TabIndex = 33
        Me.txtReqSpeed.Text = "0"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(19, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Speeed:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(190, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(44, 36)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "�/s"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdSetSpeed
        '
        Me.cmdSetSpeed.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSetSpeed.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSetSpeed.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSetSpeed.Location = New System.Drawing.Point(227, 99)
        Me.cmdSetSpeed.Name = "cmdSetSpeed"
        Me.cmdSetSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSetSpeed.Size = New System.Drawing.Size(35, 27)
        Me.cmdSetSpeed.TabIndex = 36
        Me.cmdSetSpeed.Text = "Set"
        Me.cmdSetSpeed.UseVisualStyleBackColor = False
        '
        '_cmdMoveValue_12
        '
        Me._cmdMoveValue_12.BackColor = System.Drawing.SystemColors.Control
        Me._cmdMoveValue_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdMoveValue_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdMoveValue_12.Image = CType(resources.GetObject("_cmdMoveValue_12.Image"), System.Drawing.Image)
        Me.cmdMoveValue.SetIndex(Me._cmdMoveValue_12, CType(12, Short))
        Me._cmdMoveValue_12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me._cmdMoveValue_12.Location = New System.Drawing.Point(42, 139)
        Me._cmdMoveValue_12.Name = "_cmdMoveValue_12"
        Me._cmdMoveValue_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdMoveValue_12.Size = New System.Drawing.Size(55, 27)
        Me._cmdMoveValue_12.TabIndex = 39
        Me._cmdMoveValue_12.Text = "+90�"
        Me._cmdMoveValue_12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._cmdMoveValue_12.UseVisualStyleBackColor = False
        '
        '_cmdMoveValue_13
        '
        Me._cmdMoveValue_13.BackColor = System.Drawing.SystemColors.Control
        Me._cmdMoveValue_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdMoveValue_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdMoveValue_13.Image = CType(resources.GetObject("_cmdMoveValue_13.Image"), System.Drawing.Image)
        Me.cmdMoveValue.SetIndex(Me._cmdMoveValue_13, CType(13, Short))
        Me._cmdMoveValue_13.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me._cmdMoveValue_13.Location = New System.Drawing.Point(233, 139)
        Me._cmdMoveValue_13.Name = "_cmdMoveValue_13"
        Me._cmdMoveValue_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdMoveValue_13.Size = New System.Drawing.Size(53, 27)
        Me._cmdMoveValue_13.TabIndex = 40
        Me._cmdMoveValue_13.Text = "-90�"
        Me._cmdMoveValue_13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me._cmdMoveValue_13.UseVisualStyleBackColor = False
        '
        'frmTurntable
        '
        Me.AcceptButton = Me.cmdCancel
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(329, 341)
        Me.Controls.Add(Me._cmdMoveValue_13)
        Me.Controls.Add(Me._cmdMoveValue_12)
        Me.Controls.Add(Me._cmdMoveValue_11)
        Me.Controls.Add(Me._cmdMoveValue_10)
        Me.Controls.Add(Me.txtReqSpeed)
        Me.Controls.Add(Me.cmdSetSpeed)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me._cmdMoveValue_7)
        Me.Controls.Add(Me._cmdMoveValue_6)
        Me.Controls.Add(Me.cmdGet)
        Me.Controls.Add(Me.sbStatus)
        Me.Controls.Add(Me._cmdMoveValue_5)
        Me.Controls.Add(Me._cmdMoveValue_4)
        Me.Controls.Add(Me._cmdMoveValue_3)
        Me.Controls.Add(Me._cmdMoveValue_2)
        Me.Controls.Add(Me._cmdMoveValue_1)
        Me.Controls.Add(Me._cmdMoveValue_0)
        Me.Controls.Add(Me.cmdSetForced)
        Me.Controls.Add(Me.cmdMove)
        Me.Controls.Add(Me.txtReqPos)
        Me.Controls.Add(Me.cmdResetCW)
        Me.Controls.Add(Me.cmdResetCCW)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.pbTime)
        Me.Controls.Add(Me.lblTrueAzi)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblCurrentAzi)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.shpStep)
        Me.Controls.Add(Me.lblStepMark)
        Me.Controls.Add(Me.shpZero)
        Me.Controls.Add(Me.lblZeroMark)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdPullBrake)
        Me.Controls.Add(Me.cmdCCW)
        Me.Controls.Add(Me.cmdCW)
        Me.Controls.Add(Me._cmdMoveValue_8)
        Me.Controls.Add(Me._cmdMoveValue_9)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmTurntable"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = false
        Me.Text = "Turntable"
        CType(Me.cmdMoveValue,System.ComponentModel.ISupportInitialize).EndInit
        Me.sbStatus.ResumeLayout(false)
        Me.sbStatus.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents sbStatus As System.Windows.Forms.StatusStrip
    Public WithEvents cmdPullBrake As Button
    Public WithEvents cmdGet As Button
    Friend WithEvents sbStatusLabel As ToolStripStatusLabel
    Public WithEvents _cmdMoveValue_6 As Button
    Public WithEvents _cmdMoveValue_7 As Button
    Private WithEvents tmrBrake As Timer
    Public WithEvents _cmdMoveValue_8 As Button
    Public WithEvents _cmdMoveValue_9 As Button
    Friend WithEvents tmrDelayed As Timer
    Public WithEvents txtReqSpeed As TextBox
    Public WithEvents Label3 As Label
    Public WithEvents Label4 As Label
    Public WithEvents cmdSetSpeed As Button
    Public WithEvents _cmdMoveValue_10 As Button
    Public WithEvents _cmdMoveValue_11 As Button
    Public WithEvents _cmdMoveValue_12 As Button
    Public WithEvents _cmdMoveValue_13 As Button
#End Region
End Class