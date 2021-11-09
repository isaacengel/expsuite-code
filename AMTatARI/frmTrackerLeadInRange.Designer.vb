<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmTrackerLeadInRange
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
	Public WithEvents pbInRange As System.Windows.Forms.ProgressBar
	Public WithEvents tmrTracker As System.Windows.Forms.Timer
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents _shpMax_5 As System.Windows.Forms.Label
	Public WithEvents _shpMin_5 As System.Windows.Forms.Label
	Public WithEvents _shpMax_4 As System.Windows.Forms.Label
	Public WithEvents _shpMin_4 As System.Windows.Forms.Label
	Public WithEvents _shpMax_3 As System.Windows.Forms.Label
	Public WithEvents _shpMin_3 As System.Windows.Forms.Label
	Public WithEvents _shpMax_2 As System.Windows.Forms.Label
	Public WithEvents _shpMin_2 As System.Windows.Forms.Label
	Public WithEvents _shpMax_1 As System.Windows.Forms.Label
	Public WithEvents _shpMin_1 As System.Windows.Forms.Label
	Public WithEvents _shpMax_0 As System.Windows.Forms.Label
	Public WithEvents _shpMin_0 As System.Windows.Forms.Label
	Public WithEvents _lblTrackerLabX_0 As System.Windows.Forms.Label
	Public WithEvents _lblTrackerLabA_0 As System.Windows.Forms.Label
	Public WithEvents _lblTrackerX_0 As System.Windows.Forms.Label
	Public WithEvents _lblTrackerLabY_0 As System.Windows.Forms.Label
	Public WithEvents _lblTrackerLabZ_0 As System.Windows.Forms.Label
	Public WithEvents _lblTrackerLabE_0 As System.Windows.Forms.Label
	Public WithEvents _lblTrackerLabR_0 As System.Windows.Forms.Label
	Public WithEvents _lblTrackerY_0 As System.Windows.Forms.Label
	Public WithEvents _lblTrackerZ_0 As System.Windows.Forms.Label
	Public WithEvents _lblTrackerA_0 As System.Windows.Forms.Label
	Public WithEvents _lblTrackerE_0 As System.Windows.Forms.Label
	Public WithEvents _lblTrackerR_0 As System.Windows.Forms.Label
	Public WithEvents fraTrackerSensor As System.Windows.Forms.GroupBox
	Public WithEvents lblStatus As System.Windows.Forms.Label
	Public WithEvents lblTrackerA As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lblTrackerE As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lblTrackerLabA As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lblTrackerLabE As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lblTrackerLabR As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lblTrackerLabX As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lblTrackerLabY As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lblTrackerLabZ As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lblTrackerR As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lblTrackerX As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lblTrackerY As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents lblTrackerZ As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents shpMax As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents shpMin As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTrackerLeadInRange))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pbInRange = New System.Windows.Forms.ProgressBar()
        Me.tmrTracker = New System.Windows.Forms.Timer(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.fraTrackerSensor = New System.Windows.Forms.GroupBox()
        Me._shpMax_5 = New System.Windows.Forms.Label()
        Me._shpMin_5 = New System.Windows.Forms.Label()
        Me._shpMax_4 = New System.Windows.Forms.Label()
        Me._shpMin_4 = New System.Windows.Forms.Label()
        Me._shpMax_3 = New System.Windows.Forms.Label()
        Me._shpMin_3 = New System.Windows.Forms.Label()
        Me._shpMax_2 = New System.Windows.Forms.Label()
        Me._shpMin_2 = New System.Windows.Forms.Label()
        Me._shpMax_1 = New System.Windows.Forms.Label()
        Me._shpMin_1 = New System.Windows.Forms.Label()
        Me._shpMax_0 = New System.Windows.Forms.Label()
        Me._shpMin_0 = New System.Windows.Forms.Label()
        Me._lblTrackerLabX_0 = New System.Windows.Forms.Label()
        Me._lblTrackerLabA_0 = New System.Windows.Forms.Label()
        Me._lblTrackerX_0 = New System.Windows.Forms.Label()
        Me._lblTrackerLabY_0 = New System.Windows.Forms.Label()
        Me._lblTrackerLabZ_0 = New System.Windows.Forms.Label()
        Me._lblTrackerLabE_0 = New System.Windows.Forms.Label()
        Me._lblTrackerLabR_0 = New System.Windows.Forms.Label()
        Me._lblTrackerY_0 = New System.Windows.Forms.Label()
        Me._lblTrackerZ_0 = New System.Windows.Forms.Label()
        Me._lblTrackerA_0 = New System.Windows.Forms.Label()
        Me._lblTrackerE_0 = New System.Windows.Forms.Label()
        Me._lblTrackerR_0 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblTrackerA = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerE = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerLabA = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerLabE = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerLabR = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerLabX = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerLabY = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerLabZ = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerR = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerX = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerY = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.lblTrackerZ = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.shpMax = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.shpMin = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.fraTrackerSensor.SuspendLayout()
        CType(Me.lblTrackerA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTrackerE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTrackerLabA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTrackerLabE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTrackerLabR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTrackerLabX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTrackerLabY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTrackerLabZ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTrackerR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTrackerX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTrackerY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTrackerZ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.shpMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.shpMin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbInRange
        '
        Me.pbInRange.Location = New System.Drawing.Point(16, 156)
        Me.pbInRange.Name = "pbInRange"
        Me.pbInRange.Size = New System.Drawing.Size(325, 21)
        Me.pbInRange.TabIndex = 15
        '
        'tmrTracker
        '
        Me.tmrTracker.Interval = 1
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(124, 240)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(101, 25)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'fraTrackerSensor
        '
        Me.fraTrackerSensor.BackColor = System.Drawing.SystemColors.Control
        Me.fraTrackerSensor.Controls.Add(Me._shpMax_5)
        Me.fraTrackerSensor.Controls.Add(Me._shpMin_5)
        Me.fraTrackerSensor.Controls.Add(Me._shpMax_4)
        Me.fraTrackerSensor.Controls.Add(Me._shpMin_4)
        Me.fraTrackerSensor.Controls.Add(Me._shpMax_3)
        Me.fraTrackerSensor.Controls.Add(Me._shpMin_3)
        Me.fraTrackerSensor.Controls.Add(Me._shpMax_2)
        Me.fraTrackerSensor.Controls.Add(Me._shpMin_2)
        Me.fraTrackerSensor.Controls.Add(Me._shpMax_1)
        Me.fraTrackerSensor.Controls.Add(Me._shpMin_1)
        Me.fraTrackerSensor.Controls.Add(Me._shpMax_0)
        Me.fraTrackerSensor.Controls.Add(Me._shpMin_0)
        Me.fraTrackerSensor.Controls.Add(Me._lblTrackerLabX_0)
        Me.fraTrackerSensor.Controls.Add(Me._lblTrackerLabA_0)
        Me.fraTrackerSensor.Controls.Add(Me._lblTrackerX_0)
        Me.fraTrackerSensor.Controls.Add(Me._lblTrackerLabY_0)
        Me.fraTrackerSensor.Controls.Add(Me._lblTrackerLabZ_0)
        Me.fraTrackerSensor.Controls.Add(Me._lblTrackerLabE_0)
        Me.fraTrackerSensor.Controls.Add(Me._lblTrackerLabR_0)
        Me.fraTrackerSensor.Controls.Add(Me._lblTrackerY_0)
        Me.fraTrackerSensor.Controls.Add(Me._lblTrackerZ_0)
        Me.fraTrackerSensor.Controls.Add(Me._lblTrackerA_0)
        Me.fraTrackerSensor.Controls.Add(Me._lblTrackerE_0)
        Me.fraTrackerSensor.Controls.Add(Me._lblTrackerR_0)
        Me.fraTrackerSensor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraTrackerSensor.Location = New System.Drawing.Point(16, 12)
        Me.fraTrackerSensor.Name = "fraTrackerSensor"
        Me.fraTrackerSensor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraTrackerSensor.Size = New System.Drawing.Size(325, 141)
        Me.fraTrackerSensor.TabIndex = 0
        Me.fraTrackerSensor.TabStop = False
        Me.fraTrackerSensor.Text = "Data:"
        '
        '_shpMax_5
        '
        Me._shpMax_5.BackColor = System.Drawing.Color.Transparent
        Me._shpMax_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.shpMax.SetIndex(Me._shpMax_5, CType(5, Short))
        Me._shpMax_5.Location = New System.Drawing.Point(276, 100)
        Me._shpMax_5.Name = "_shpMax_5"
        Me._shpMax_5.Size = New System.Drawing.Size(17, 17)
        Me._shpMax_5.TabIndex = 0
        '
        '_shpMin_5
        '
        Me._shpMin_5.BackColor = System.Drawing.Color.Transparent
        Me._shpMin_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.shpMin.SetIndex(Me._shpMin_5, CType(5, Short))
        Me._shpMin_5.Location = New System.Drawing.Point(276, 76)
        Me._shpMin_5.Name = "_shpMin_5"
        Me._shpMin_5.Size = New System.Drawing.Size(17, 17)
        Me._shpMin_5.TabIndex = 1
        '
        '_shpMax_4
        '
        Me._shpMax_4.BackColor = System.Drawing.Color.Transparent
        Me._shpMax_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.shpMax.SetIndex(Me._shpMax_4, CType(4, Short))
        Me._shpMax_4.Location = New System.Drawing.Point(226, 100)
        Me._shpMax_4.Name = "_shpMax_4"
        Me._shpMax_4.Size = New System.Drawing.Size(17, 17)
        Me._shpMax_4.TabIndex = 2
        '
        '_shpMin_4
        '
        Me._shpMin_4.BackColor = System.Drawing.Color.Transparent
        Me._shpMin_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.shpMin.SetIndex(Me._shpMin_4, CType(4, Short))
        Me._shpMin_4.Location = New System.Drawing.Point(226, 76)
        Me._shpMin_4.Name = "_shpMin_4"
        Me._shpMin_4.Size = New System.Drawing.Size(17, 17)
        Me._shpMin_4.TabIndex = 3
        '
        '_shpMax_3
        '
        Me._shpMax_3.BackColor = System.Drawing.Color.Transparent
        Me._shpMax_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.shpMax.SetIndex(Me._shpMax_3, CType(3, Short))
        Me._shpMax_3.Location = New System.Drawing.Point(176, 100)
        Me._shpMax_3.Name = "_shpMax_3"
        Me._shpMax_3.Size = New System.Drawing.Size(17, 17)
        Me._shpMax_3.TabIndex = 4
        '
        '_shpMin_3
        '
        Me._shpMin_3.BackColor = System.Drawing.Color.Transparent
        Me._shpMin_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.shpMin.SetIndex(Me._shpMin_3, CType(3, Short))
        Me._shpMin_3.Location = New System.Drawing.Point(176, 76)
        Me._shpMin_3.Name = "_shpMin_3"
        Me._shpMin_3.Size = New System.Drawing.Size(17, 17)
        Me._shpMin_3.TabIndex = 5
        '
        '_shpMax_2
        '
        Me._shpMax_2.BackColor = System.Drawing.Color.Transparent
        Me._shpMax_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.shpMax.SetIndex(Me._shpMax_2, CType(2, Short))
        Me._shpMax_2.Location = New System.Drawing.Point(116, 100)
        Me._shpMax_2.Name = "_shpMax_2"
        Me._shpMax_2.Size = New System.Drawing.Size(17, 17)
        Me._shpMax_2.TabIndex = 6
        '
        '_shpMin_2
        '
        Me._shpMin_2.BackColor = System.Drawing.Color.Transparent
        Me._shpMin_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.shpMin.SetIndex(Me._shpMin_2, CType(2, Short))
        Me._shpMin_2.Location = New System.Drawing.Point(116, 76)
        Me._shpMin_2.Name = "_shpMin_2"
        Me._shpMin_2.Size = New System.Drawing.Size(17, 17)
        Me._shpMin_2.TabIndex = 7
        '
        '_shpMax_1
        '
        Me._shpMax_1.BackColor = System.Drawing.Color.Transparent
        Me._shpMax_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.shpMax.SetIndex(Me._shpMax_1, CType(1, Short))
        Me._shpMax_1.Location = New System.Drawing.Point(70, 100)
        Me._shpMax_1.Name = "_shpMax_1"
        Me._shpMax_1.Size = New System.Drawing.Size(17, 17)
        Me._shpMax_1.TabIndex = 8
        '
        '_shpMin_1
        '
        Me._shpMin_1.BackColor = System.Drawing.Color.Transparent
        Me._shpMin_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.shpMin.SetIndex(Me._shpMin_1, CType(1, Short))
        Me._shpMin_1.Location = New System.Drawing.Point(70, 76)
        Me._shpMin_1.Name = "_shpMin_1"
        Me._shpMin_1.Size = New System.Drawing.Size(17, 17)
        Me._shpMin_1.TabIndex = 9
        '
        '_shpMax_0
        '
        Me._shpMax_0.BackColor = System.Drawing.Color.Transparent
        Me._shpMax_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.shpMax.SetIndex(Me._shpMax_0, CType(0, Short))
        Me._shpMax_0.Location = New System.Drawing.Point(24, 100)
        Me._shpMax_0.Name = "_shpMax_0"
        Me._shpMax_0.Size = New System.Drawing.Size(17, 17)
        Me._shpMax_0.TabIndex = 10
        '
        '_shpMin_0
        '
        Me._shpMin_0.BackColor = System.Drawing.Color.Transparent
        Me._shpMin_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.shpMin.SetIndex(Me._shpMin_0, CType(0, Short))
        Me._shpMin_0.Location = New System.Drawing.Point(24, 76)
        Me._shpMin_0.Name = "_shpMin_0"
        Me._shpMin_0.Size = New System.Drawing.Size(17, 17)
        Me._shpMin_0.TabIndex = 11
        '
        '_lblTrackerLabX_0
        '
        Me._lblTrackerLabX_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblTrackerLabX_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerLabX_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerLabX.SetIndex(Me._lblTrackerLabX_0, CType(0, Short))
        Me._lblTrackerLabX_0.Location = New System.Drawing.Point(16, 20)
        Me._lblTrackerLabX_0.Name = "_lblTrackerLabX_0"
        Me._lblTrackerLabX_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerLabX_0.Size = New System.Drawing.Size(33, 13)
        Me._lblTrackerLabX_0.TabIndex = 12
        Me._lblTrackerLabX_0.Text = "X"
        Me._lblTrackerLabX_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerLabA_0
        '
        Me._lblTrackerLabA_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblTrackerLabA_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerLabA_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerLabA.SetIndex(Me._lblTrackerLabA_0, CType(0, Short))
        Me._lblTrackerLabA_0.Location = New System.Drawing.Point(160, 20)
        Me._lblTrackerLabA_0.Name = "_lblTrackerLabA_0"
        Me._lblTrackerLabA_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerLabA_0.Size = New System.Drawing.Size(47, 13)
        Me._lblTrackerLabA_0.TabIndex = 11
        Me._lblTrackerLabA_0.Text = "Azimuth"
        Me._lblTrackerLabA_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerX_0
        '
        Me._lblTrackerX_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblTrackerX_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerX_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerX.SetIndex(Me._lblTrackerX_0, CType(0, Short))
        Me._lblTrackerX_0.Location = New System.Drawing.Point(16, 40)
        Me._lblTrackerX_0.Name = "_lblTrackerX_0"
        Me._lblTrackerX_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerX_0.Size = New System.Drawing.Size(33, 13)
        Me._lblTrackerX_0.TabIndex = 10
        Me._lblTrackerX_0.Text = "0"
        Me._lblTrackerX_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerLabY_0
        '
        Me._lblTrackerLabY_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblTrackerLabY_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerLabY_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerLabY.SetIndex(Me._lblTrackerLabY_0, CType(0, Short))
        Me._lblTrackerLabY_0.Location = New System.Drawing.Point(62, 20)
        Me._lblTrackerLabY_0.Name = "_lblTrackerLabY_0"
        Me._lblTrackerLabY_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerLabY_0.Size = New System.Drawing.Size(33, 13)
        Me._lblTrackerLabY_0.TabIndex = 9
        Me._lblTrackerLabY_0.Text = "Y"
        Me._lblTrackerLabY_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerLabZ_0
        '
        Me._lblTrackerLabZ_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblTrackerLabZ_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerLabZ_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerLabZ.SetIndex(Me._lblTrackerLabZ_0, CType(0, Short))
        Me._lblTrackerLabZ_0.Location = New System.Drawing.Point(108, 20)
        Me._lblTrackerLabZ_0.Name = "_lblTrackerLabZ_0"
        Me._lblTrackerLabZ_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerLabZ_0.Size = New System.Drawing.Size(33, 13)
        Me._lblTrackerLabZ_0.TabIndex = 8
        Me._lblTrackerLabZ_0.Text = "Z"
        Me._lblTrackerLabZ_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerLabE_0
        '
        Me._lblTrackerLabE_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblTrackerLabE_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerLabE_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerLabE.SetIndex(Me._lblTrackerLabE_0, CType(0, Short))
        Me._lblTrackerLabE_0.Location = New System.Drawing.Point(210, 20)
        Me._lblTrackerLabE_0.Name = "_lblTrackerLabE_0"
        Me._lblTrackerLabE_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerLabE_0.Size = New System.Drawing.Size(55, 13)
        Me._lblTrackerLabE_0.TabIndex = 7
        Me._lblTrackerLabE_0.Text = "Elevation"
        Me._lblTrackerLabE_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerLabR_0
        '
        Me._lblTrackerLabR_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblTrackerLabR_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerLabR_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerLabR.SetIndex(Me._lblTrackerLabR_0, CType(0, Short))
        Me._lblTrackerLabR_0.Location = New System.Drawing.Point(272, 20)
        Me._lblTrackerLabR_0.Name = "_lblTrackerLabR_0"
        Me._lblTrackerLabR_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerLabR_0.Size = New System.Drawing.Size(25, 13)
        Me._lblTrackerLabR_0.TabIndex = 6
        Me._lblTrackerLabR_0.Text = "Roll"
        Me._lblTrackerLabR_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerY_0
        '
        Me._lblTrackerY_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblTrackerY_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerY_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerY.SetIndex(Me._lblTrackerY_0, CType(0, Short))
        Me._lblTrackerY_0.Location = New System.Drawing.Point(62, 40)
        Me._lblTrackerY_0.Name = "_lblTrackerY_0"
        Me._lblTrackerY_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerY_0.Size = New System.Drawing.Size(33, 13)
        Me._lblTrackerY_0.TabIndex = 5
        Me._lblTrackerY_0.Text = "0"
        Me._lblTrackerY_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerZ_0
        '
        Me._lblTrackerZ_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblTrackerZ_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerZ_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerZ.SetIndex(Me._lblTrackerZ_0, CType(0, Short))
        Me._lblTrackerZ_0.Location = New System.Drawing.Point(108, 40)
        Me._lblTrackerZ_0.Name = "_lblTrackerZ_0"
        Me._lblTrackerZ_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerZ_0.Size = New System.Drawing.Size(33, 13)
        Me._lblTrackerZ_0.TabIndex = 4
        Me._lblTrackerZ_0.Text = "0"
        Me._lblTrackerZ_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerA_0
        '
        Me._lblTrackerA_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblTrackerA_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerA_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerA.SetIndex(Me._lblTrackerA_0, CType(0, Short))
        Me._lblTrackerA_0.Location = New System.Drawing.Point(160, 40)
        Me._lblTrackerA_0.Name = "_lblTrackerA_0"
        Me._lblTrackerA_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerA_0.Size = New System.Drawing.Size(49, 13)
        Me._lblTrackerA_0.TabIndex = 3
        Me._lblTrackerA_0.Text = "0"
        Me._lblTrackerA_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerE_0
        '
        Me._lblTrackerE_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblTrackerE_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerE_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerE.SetIndex(Me._lblTrackerE_0, CType(0, Short))
        Me._lblTrackerE_0.Location = New System.Drawing.Point(210, 40)
        Me._lblTrackerE_0.Name = "_lblTrackerE_0"
        Me._lblTrackerE_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerE_0.Size = New System.Drawing.Size(49, 13)
        Me._lblTrackerE_0.TabIndex = 2
        Me._lblTrackerE_0.Text = "0"
        Me._lblTrackerE_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblTrackerR_0
        '
        Me._lblTrackerR_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblTrackerR_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTrackerR_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTrackerR.SetIndex(Me._lblTrackerR_0, CType(0, Short))
        Me._lblTrackerR_0.Location = New System.Drawing.Point(260, 40)
        Me._lblTrackerR_0.Name = "_lblTrackerR_0"
        Me._lblTrackerR_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTrackerR_0.Size = New System.Drawing.Size(49, 13)
        Me._lblTrackerR_0.TabIndex = 1
        Me._lblTrackerR_0.Text = "0"
        Me._lblTrackerR_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStatus.Location = New System.Drawing.Point(20, 184)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStatus.Size = New System.Drawing.Size(313, 37)
        Me.lblStatus.TabIndex = 14
        Me.lblStatus.Text = "Status"
        '
        'frmTrackerLeadInRange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(360, 272)
        Me.Controls.Add(Me.pbInRange)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.fraTrackerSensor)
        Me.Controls.Add(Me.lblStatus)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTrackerLeadInRange"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.Text = "Lead subject into trackes ranges"
        Me.fraTrackerSensor.ResumeLayout(False)
        CType(Me.lblTrackerA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTrackerE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTrackerLabA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTrackerLabE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTrackerLabR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTrackerLabX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTrackerLabY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTrackerLabZ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTrackerR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTrackerX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTrackerY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTrackerZ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.shpMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.shpMin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class