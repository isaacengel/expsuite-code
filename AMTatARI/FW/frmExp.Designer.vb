<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmExp
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
    Public WithEvents _cmdResponse_203 As System.Windows.Forms.Button
	Public WithEvents _cmdResponse_202 As System.Windows.Forms.Button
	Public WithEvents _cmdResponse_201 As System.Windows.Forms.Button
	Public WithEvents _cmdResponse_200 As System.Windows.Forms.Button
	Public WithEvents _lblVisu_201 As System.Windows.Forms.Label
	Public WithEvents _lblStim_2 As System.Windows.Forms.Label
	Public WithEvents _lblVisu_200 As System.Windows.Forms.Label
    Public WithEvents _cmdResponse_0 As System.Windows.Forms.Button
	Public WithEvents _lblVisu_0 As System.Windows.Forms.Label
    Public WithEvents _lblStim_0 As System.Windows.Forms.Label
    Public WithEvents _cmdResponse_4 As System.Windows.Forms.Button
    Public WithEvents _lblVisu_4 As System.Windows.Forms.Label
    Public WithEvents _lblStim_4 As System.Windows.Forms.Label
    Public WithEvents tmrBreak As System.Windows.Forms.Timer
	Public WithEvents _txtNum_100 As System.Windows.Forms.TextBox
	Public WithEvents _cmdResponse_100 As System.Windows.Forms.Button
	Public WithEvents _lblVisu_100 As System.Windows.Forms.Label
	Public WithEvents _lblStim_1 As System.Windows.Forms.Label
    Public WithEvents _cmdResponse_300 As System.Windows.Forms.Button
	Public WithEvents _lblStim_3 As System.Windows.Forms.Label
	Public WithEvents _lblVisu_300 As System.Windows.Forms.Label
    Public WithEvents cmdStart As System.Windows.Forms.Button
	Public WithEvents lblStart As System.Windows.Forms.Label
    Public WithEvents tmrStimScreenNone As System.Windows.Forms.Timer
	Public WithEvents picLogo As System.Windows.Forms.PictureBox
	Public WithEvents lblDebug As System.Windows.Forms.Label
    Public WithEvents lblEnd As System.Windows.Forms.Label
    Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents pbProgress As System.Windows.Forms.ProgressBar
	Public WithEvents lblProgress As System.Windows.Forms.Label
    Public WithEvents cmdNext As System.Windows.Forms.Button
    Public WithEvents lblFeedback As System.Windows.Forms.Label
	Public WithEvents lblActive As System.Windows.Forms.Label
	Public WithEvents lblInactive As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExp))
        Me._cmdResponse_203 = New System.Windows.Forms.Button()
        Me._cmdResponse_202 = New System.Windows.Forms.Button()
        Me._cmdResponse_201 = New System.Windows.Forms.Button()
        Me._cmdResponse_200 = New System.Windows.Forms.Button()
        Me._lblVisu_201 = New System.Windows.Forms.Label()
        Me._lblStim_2 = New System.Windows.Forms.Label()
        Me._lblVisu_200 = New System.Windows.Forms.Label()
        Me._cmdResponse_0 = New System.Windows.Forms.Button()
        Me._lblVisu_0 = New System.Windows.Forms.Label()
        Me._lblStim_0 = New System.Windows.Forms.Label()
        Me._cmdResponse_4 = New System.Windows.Forms.Button()
        Me._lblStim_4 = New System.Windows.Forms.Label()
        Me._lblVisu_4 = New System.Windows.Forms.Label()
        Me.tmrBreak = New System.Windows.Forms.Timer(Me.components)
        Me._txtNum_100 = New System.Windows.Forms.TextBox()
        Me._cmdResponse_100 = New System.Windows.Forms.Button()
        Me._lblVisu_100 = New System.Windows.Forms.Label()
        Me._lblStim_1 = New System.Windows.Forms.Label()
        Me._cmdResponse_300 = New System.Windows.Forms.Button()
        Me._lblStim_3 = New System.Windows.Forms.Label()
        Me._lblVisu_300 = New System.Windows.Forms.Label()
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.tmrStimScreenNone = New System.Windows.Forms.Timer(Me.components)
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.lblDebug = New System.Windows.Forms.Label()
        Me.lblEnd = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.pbProgress = New System.Windows.Forms.ProgressBar()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.lblFeedback = New System.Windows.Forms.Label()
        Me.lblActive = New System.Windows.Forms.Label()
        Me.lblInactive = New System.Windows.Forms.Label()
        Me.tabExp = New System.Windows.Forms.TabControl()
        Me.tabBlank = New System.Windows.Forms.TabPage()
        Me.tabStart = New System.Windows.Forms.TabPage()
        Me.tabEnd = New System.Windows.Forms.TabPage()
        Me.tabMode0 = New System.Windows.Forms.TabPage()
        Me.pbMode0 = New System.Windows.Forms.PictureBox()
        Me.tabMode1 = New System.Windows.Forms.TabPage()
        Me.tabMode2 = New System.Windows.Forms.TabPage()
        Me.tabMode3 = New System.Windows.Forms.TabPage()
        Me.tabMode4 = New System.Windows.Forms.TabPage()
        Me.tabMode5 = New System.Windows.Forms.TabPage()
        Me.lblMode5Scroll = New System.Windows.Forms.Label()
        Me.Mode5TrackBar = New System.Windows.Forms.TrackBar()
        Me._cmdResponse_5 = New System.Windows.Forms.Button()
        Me._lblVisu_5 = New System.Windows.Forms.Label()
        Me._lblStim_5 = New System.Windows.Forms.Label()
        Me.tabMode6 = New System.Windows.Forms.TabPage()
        Me.p6 = New System.Windows.Forms.Panel()
        Me.p6Text = New System.Windows.Forms.TextBox()
        Me.pb6Right = New System.Windows.Forms.PictureBox()
        Me.pb6Left = New System.Windows.Forms.PictureBox()
        Me._cmdResponse_6 = New System.Windows.Forms.Button()
        Me._lblStim_6 = New System.Windows.Forms.Label()
        Me._lblVisu_6 = New System.Windows.Forms.Label()
        Me.tabMode7 = New System.Windows.Forms.TabPage()
        Me.gbQ7b = New System.Windows.Forms.GroupBox()
        Me.tblQ7b = New System.Windows.Forms.TableLayoutPanel()
        Me.rb7b5 = New System.Windows.Forms.RadioButton()
        Me.lblQ7b = New System.Windows.Forms.Label()
        Me.rb7b2 = New System.Windows.Forms.RadioButton()
        Me.rb7b1 = New System.Windows.Forms.RadioButton()
        Me.rb7b4 = New System.Windows.Forms.RadioButton()
        Me.rb7b3 = New System.Windows.Forms.RadioButton()
        Me.gbQ7c = New System.Windows.Forms.GroupBox()
        Me.tblQ7c = New System.Windows.Forms.TableLayoutPanel()
        Me.rb7c5 = New System.Windows.Forms.RadioButton()
        Me.lblQ7c = New System.Windows.Forms.Label()
        Me.rb7c2 = New System.Windows.Forms.RadioButton()
        Me.rb7c1 = New System.Windows.Forms.RadioButton()
        Me.rb7c4 = New System.Windows.Forms.RadioButton()
        Me.rb7c3 = New System.Windows.Forms.RadioButton()
        Me.gbQ7d = New System.Windows.Forms.GroupBox()
        Me.tblQ7d = New System.Windows.Forms.TableLayoutPanel()
        Me.rb7d5 = New System.Windows.Forms.RadioButton()
        Me.rb7d2 = New System.Windows.Forms.RadioButton()
        Me.rb7d1 = New System.Windows.Forms.RadioButton()
        Me.rb7d4 = New System.Windows.Forms.RadioButton()
        Me.rb7d3 = New System.Windows.Forms.RadioButton()
        Me.lblQ7d = New System.Windows.Forms.Label()
        Me.gbQ7a = New System.Windows.Forms.GroupBox()
        Me.tblQ7a = New System.Windows.Forms.TableLayoutPanel()
        Me.rb7a5 = New System.Windows.Forms.RadioButton()
        Me.lblQ7a = New System.Windows.Forms.Label()
        Me.rb7a2 = New System.Windows.Forms.RadioButton()
        Me.rb7a1 = New System.Windows.Forms.RadioButton()
        Me.rb7a4 = New System.Windows.Forms.RadioButton()
        Me.rb7a3 = New System.Windows.Forms.RadioButton()
        Me._cmdResponse_700 = New System.Windows.Forms.Button()
        Me._lblVisu_7 = New System.Windows.Forms.Label()
        Me.tbResponse = New System.Windows.Forms.TrackBar()
        Me._lblStim_7 = New System.Windows.Forms.Label()
        Me.tbPlay = New System.Windows.Forms.TrackBar()
        Me.fraProgress = New System.Windows.Forms.Panel()
        Me.lblProgressText = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabExp.SuspendLayout()
        Me.tabBlank.SuspendLayout()
        Me.tabStart.SuspendLayout()
        Me.tabEnd.SuspendLayout()
        Me.tabMode0.SuspendLayout()
        CType(Me.pbMode0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMode1.SuspendLayout()
        Me.tabMode2.SuspendLayout()
        Me.tabMode3.SuspendLayout()
        Me.tabMode4.SuspendLayout()
        Me.tabMode5.SuspendLayout()
        CType(Me.Mode5TrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMode6.SuspendLayout()
        Me.p6.SuspendLayout()
        CType(Me.pb6Right, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb6Left, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMode7.SuspendLayout()
        Me.gbQ7b.SuspendLayout()
        Me.tblQ7b.SuspendLayout()
        Me.gbQ7c.SuspendLayout()
        Me.tblQ7c.SuspendLayout()
        Me.gbQ7d.SuspendLayout()
        Me.tblQ7d.SuspendLayout()
        Me.gbQ7a.SuspendLayout()
        Me.tblQ7a.SuspendLayout()
        CType(Me.tbResponse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPlay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraProgress.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        '_cmdResponse_203
        '
        Me._cmdResponse_203.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me._cmdResponse_203.BackColor = System.Drawing.SystemColors.Control
        Me._cmdResponse_203.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdResponse_203.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmdResponse_203.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdResponse_203.Location = New System.Drawing.Point(8, 295)
        Me._cmdResponse_203.Name = "_cmdResponse_203"
        Me._cmdResponse_203.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdResponse_203.Size = New System.Drawing.Size(140, 41)
        Me._cmdResponse_203.TabIndex = 29
        Me._cmdResponse_203.Tag = "Response 4"
        Me._cmdResponse_203.Text = "4"
        Me._cmdResponse_203.UseVisualStyleBackColor = True
        '
        '_cmdResponse_202
        '
        Me._cmdResponse_202.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me._cmdResponse_202.BackColor = System.Drawing.SystemColors.Control
        Me._cmdResponse_202.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdResponse_202.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmdResponse_202.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdResponse_202.Location = New System.Drawing.Point(606, 295)
        Me._cmdResponse_202.Name = "_cmdResponse_202"
        Me._cmdResponse_202.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdResponse_202.Size = New System.Drawing.Size(140, 41)
        Me._cmdResponse_202.TabIndex = 28
        Me._cmdResponse_202.Tag = "Response 3"
        Me._cmdResponse_202.Text = "3"
        Me._cmdResponse_202.UseVisualStyleBackColor = True
        '
        '_cmdResponse_201
        '
        Me._cmdResponse_201.Anchor = System.Windows.Forms.AnchorStyles.None
        Me._cmdResponse_201.BackColor = System.Drawing.SystemColors.Control
        Me._cmdResponse_201.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdResponse_201.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmdResponse_201.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdResponse_201.Location = New System.Drawing.Point(312, 581)
        Me._cmdResponse_201.Name = "_cmdResponse_201"
        Me._cmdResponse_201.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdResponse_201.Size = New System.Drawing.Size(140, 41)
        Me._cmdResponse_201.TabIndex = 27
        Me._cmdResponse_201.Tag = "Response 2"
        Me._cmdResponse_201.Text = "2"
        Me._cmdResponse_201.UseVisualStyleBackColor = True
        '
        '_cmdResponse_200
        '
        Me._cmdResponse_200.Anchor = System.Windows.Forms.AnchorStyles.None
        Me._cmdResponse_200.BackColor = System.Drawing.SystemColors.Control
        Me._cmdResponse_200.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdResponse_200.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmdResponse_200.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdResponse_200.Location = New System.Drawing.Point(312, 16)
        Me._cmdResponse_200.Name = "_cmdResponse_200"
        Me._cmdResponse_200.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdResponse_200.Size = New System.Drawing.Size(140, 41)
        Me._cmdResponse_200.TabIndex = 23
        Me._cmdResponse_200.Tag = "Response 1"
        Me._cmdResponse_200.Text = "1"
        Me._cmdResponse_200.UseVisualStyleBackColor = True
        '
        '_lblVisu_201
        '
        Me._lblVisu_201.Anchor = System.Windows.Forms.AnchorStyles.None
        Me._lblVisu_201.BackColor = System.Drawing.SystemColors.Control
        Me._lblVisu_201.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._lblVisu_201.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblVisu_201.Font = New System.Drawing.Font("Arial", 99.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblVisu_201.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblVisu_201.Location = New System.Drawing.Point(292, 385)
        Me._lblVisu_201.Name = "_lblVisu_201"
        Me._lblVisu_201.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblVisu_201.Size = New System.Drawing.Size(180, 180)
        Me._lblVisu_201.TabIndex = 26
        Me._lblVisu_201.Tag = "Visu 2"
        Me._lblVisu_201.Text = "2"
        Me._lblVisu_201.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblStim_2
        '
        Me._lblStim_2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._lblStim_2.BackColor = System.Drawing.SystemColors.Control
        Me._lblStim_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblStim_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblStim_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblStim_2.Location = New System.Drawing.Point(154, 301)
        Me._lblStim_2.Name = "_lblStim_2"
        Me._lblStim_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblStim_2.Size = New System.Drawing.Size(446, 64)
        Me._lblStim_2.TabIndex = 25
        Me._lblStim_2.Tag = "Request"
        Me._lblStim_2.Text = "Ist der zweite Stimulus HÖHER oder TIEFER?"
        Me._lblStim_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblVisu_200
        '
        Me._lblVisu_200.Anchor = System.Windows.Forms.AnchorStyles.None
        Me._lblVisu_200.BackColor = System.Drawing.SystemColors.Control
        Me._lblVisu_200.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._lblVisu_200.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblVisu_200.Font = New System.Drawing.Font("Arial", 99.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblVisu_200.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblVisu_200.Location = New System.Drawing.Point(292, 70)
        Me._lblVisu_200.Name = "_lblVisu_200"
        Me._lblVisu_200.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblVisu_200.Size = New System.Drawing.Size(180, 180)
        Me._lblVisu_200.TabIndex = 24
        Me._lblVisu_200.Tag = "Visu 1"
        Me._lblVisu_200.Text = "1"
        Me._lblVisu_200.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_cmdResponse_0
        '
        Me._cmdResponse_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdResponse_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdResponse_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmdResponse_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdResponse_0.Location = New System.Drawing.Point(52, 457)
        Me._cmdResponse_0.Name = "_cmdResponse_0"
        Me._cmdResponse_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdResponse_0.Size = New System.Drawing.Size(113, 45)
        Me._cmdResponse_0.TabIndex = 8
        Me._cmdResponse_0.Tag = "Response 1"
        Me._cmdResponse_0.Text = "1"
        Me._cmdResponse_0.UseVisualStyleBackColor = True
        '
        '_lblVisu_0
        '
        Me._lblVisu_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblVisu_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._lblVisu_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblVisu_0.Font = New System.Drawing.Font("Arial", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblVisu_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblVisu_0.Location = New System.Drawing.Point(68, 39)
        Me._lblVisu_0.Name = "_lblVisu_0"
        Me._lblVisu_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblVisu_0.Size = New System.Drawing.Size(149, 140)
        Me._lblVisu_0.TabIndex = 11
        Me._lblVisu_0.Tag = "Visu 1"
        Me._lblVisu_0.Text = "1"
        Me._lblVisu_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblStim_0
        '
        Me._lblStim_0.AutoSize = True
        Me._lblStim_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblStim_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblStim_0.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblStim_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblStim_0.Location = New System.Drawing.Point(31, 357)
        Me._lblStim_0.Name = "_lblStim_0"
        Me._lblStim_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblStim_0.Size = New System.Drawing.Size(214, 56)
        Me._lblStim_0.TabIndex = 7
        Me._lblStim_0.Tag = "Request"
        Me._lblStim_0.Text = "Request"
        Me._lblStim_0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_cmdResponse_4
        '
        Me._cmdResponse_4.BackColor = System.Drawing.SystemColors.Control
        Me._cmdResponse_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdResponse_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmdResponse_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdResponse_4.Location = New System.Drawing.Point(417, 98)
        Me._cmdResponse_4.Name = "_cmdResponse_4"
        Me._cmdResponse_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdResponse_4.Size = New System.Drawing.Size(113, 45)
        Me._cmdResponse_4.TabIndex = 13
        Me._cmdResponse_4.Tag = "Response 1"
        Me._cmdResponse_4.Text = "1"
        Me._cmdResponse_4.UseVisualStyleBackColor = True
        '
        '_lblStim_4
        '
        Me._lblStim_4.AutoSize = True
        Me._lblStim_4.BackColor = System.Drawing.SystemColors.Control
        Me._lblStim_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblStim_4.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblStim_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblStim_4.Location = New System.Drawing.Point(262, 20)
        Me._lblStim_4.Name = "_lblStim_4"
        Me._lblStim_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblStim_4.Size = New System.Drawing.Size(214, 56)
        Me._lblStim_4.TabIndex = 12
        Me._lblStim_4.Tag = "Request"
        Me._lblStim_4.Text = "Request"
        Me._lblStim_4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblVisu_4
        '
        Me._lblVisu_4.BackColor = System.Drawing.SystemColors.Control
        Me._lblVisu_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._lblVisu_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblVisu_4.Font = New System.Drawing.Font("Arial", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblVisu_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblVisu_4.Location = New System.Drawing.Point(194, 98)
        Me._lblVisu_4.Name = "_lblVisu_4"
        Me._lblVisu_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblVisu_4.Size = New System.Drawing.Size(149, 140)
        Me._lblVisu_4.TabIndex = 14
        Me._lblVisu_4.Tag = "Visu 1"
        Me._lblVisu_4.Text = "1"
        Me._lblVisu_4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tmrBreak
        '
        Me.tmrBreak.Interval = 250
        '
        '_txtNum_100
        '
        Me._txtNum_100.BackColor = System.Drawing.SystemColors.Window
        Me._txtNum_100.Cursor = System.Windows.Forms.Cursors.Default
        Me._txtNum_100.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtNum_100.ForeColor = System.Drawing.SystemColors.WindowText
        Me._txtNum_100.Location = New System.Drawing.Point(27, 494)
        Me._txtNum_100.MaxLength = 10
        Me._txtNum_100.Name = "_txtNum_100"
        Me._txtNum_100.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtNum_100.Size = New System.Drawing.Size(160, 44)
        Me._txtNum_100.TabIndex = 21
        '
        '_cmdResponse_100
        '
        Me._cmdResponse_100.BackColor = System.Drawing.SystemColors.Control
        Me._cmdResponse_100.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdResponse_100.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmdResponse_100.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdResponse_100.Location = New System.Drawing.Point(198, 480)
        Me._cmdResponse_100.Name = "_cmdResponse_100"
        Me._cmdResponse_100.Size = New System.Drawing.Size(113, 69)
        Me._cmdResponse_100.TabIndex = 17
        Me._cmdResponse_100.Tag = "Response 1"
        Me._cmdResponse_100.Text = "1"
        Me._cmdResponse_100.UseVisualStyleBackColor = True
        '
        '_lblVisu_100
        '
        Me._lblVisu_100.BackColor = System.Drawing.SystemColors.Control
        Me._lblVisu_100.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._lblVisu_100.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblVisu_100.Font = New System.Drawing.Font("Arial", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblVisu_100.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblVisu_100.Location = New System.Drawing.Point(68, 39)
        Me._lblVisu_100.Name = "_lblVisu_100"
        Me._lblVisu_100.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblVisu_100.Size = New System.Drawing.Size(149, 113)
        Me._lblVisu_100.TabIndex = 18
        Me._lblVisu_100.Tag = "Visu 1"
        Me._lblVisu_100.Text = "1"
        Me._lblVisu_100.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblStim_1
        '
        Me._lblStim_1.AutoSize = True
        Me._lblStim_1.BackColor = System.Drawing.SystemColors.Control
        Me._lblStim_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblStim_1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblStim_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblStim_1.Location = New System.Drawing.Point(23, 327)
        Me._lblStim_1.Name = "_lblStim_1"
        Me._lblStim_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblStim_1.Size = New System.Drawing.Size(354, 19)
        Me._lblStim_1.TabIndex = 19
        Me._lblStim_1.Tag = "Request"
        Me._lblStim_1.Text = "Ist der zweite Stimulus HÖHER oder TIEFER?"
        Me._lblStim_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_cmdResponse_300
        '
        Me._cmdResponse_300.BackColor = System.Drawing.SystemColors.Control
        Me._cmdResponse_300.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdResponse_300.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmdResponse_300.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdResponse_300.Location = New System.Drawing.Point(150, 496)
        Me._cmdResponse_300.Name = "_cmdResponse_300"
        Me._cmdResponse_300.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdResponse_300.Size = New System.Drawing.Size(113, 45)
        Me._cmdResponse_300.TabIndex = 33
        Me._cmdResponse_300.Tag = "Response 1"
        Me._cmdResponse_300.Text = "1"
        Me._cmdResponse_300.UseVisualStyleBackColor = True
        '
        '_lblStim_3
        '
        Me._lblStim_3.AutoSize = True
        Me._lblStim_3.BackColor = System.Drawing.SystemColors.Control
        Me._lblStim_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblStim_3.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblStim_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblStim_3.Location = New System.Drawing.Point(58, 368)
        Me._lblStim_3.Name = "_lblStim_3"
        Me._lblStim_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblStim_3.Size = New System.Drawing.Size(261, 56)
        Me._lblStim_3.TabIndex = 35
        Me._lblStim_3.Tag = "Request"
        Me._lblStim_3.Text = "Hören Sie "
        Me._lblStim_3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblVisu_300
        '
        Me._lblVisu_300.BackColor = System.Drawing.SystemColors.Control
        Me._lblVisu_300.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._lblVisu_300.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblVisu_300.Font = New System.Drawing.Font("Arial", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblVisu_300.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblVisu_300.Location = New System.Drawing.Point(68, 39)
        Me._lblVisu_300.Name = "_lblVisu_300"
        Me._lblVisu_300.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblVisu_300.Size = New System.Drawing.Size(149, 165)
        Me._lblVisu_300.TabIndex = 34
        Me._lblVisu_300.Tag = "Visu 1"
        Me._lblVisu_300.Text = "1"
        Me._lblVisu_300.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdStart
        '
        Me.cmdStart.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdStart.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStart.Location = New System.Drawing.Point(247, 369)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStart.Size = New System.Drawing.Size(250, 80)
        Me.cmdStart.TabIndex = 4
        Me.cmdStart.Text = "Start"
        Me.cmdStart.UseVisualStyleBackColor = True
        '
        'lblStart
        '
        Me.lblStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStart.BackColor = System.Drawing.SystemColors.Control
        Me.lblStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStart.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStart.Location = New System.Drawing.Point(8, 172)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStart.Size = New System.Drawing.Size(750, 108)
        Me.lblStart.TabIndex = 5
        Me.lblStart.Text = "Start"
        Me.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tmrStimScreenNone
        '
        Me.tmrStimScreenNone.Interval = 1
        '
        'picLogo
        '
        Me.picLogo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.picLogo.BackColor = System.Drawing.Color.Transparent
        Me.picLogo.Cursor = System.Windows.Forms.Cursors.Default
        Me.picLogo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picLogo.Image = CType(resources.GetObject("picLogo.Image"), System.Drawing.Image)
        Me.picLogo.Location = New System.Drawing.Point(137, 61)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picLogo.Size = New System.Drawing.Size(478, 469)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogo.TabIndex = 15
        Me.picLogo.TabStop = False
        '
        'lblDebug
        '
        Me.lblDebug.BackColor = System.Drawing.Color.Transparent
        Me.lblDebug.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDebug.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDebug.Location = New System.Drawing.Point(31, 28)
        Me.lblDebug.Name = "lblDebug"
        Me.lblDebug.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDebug.Size = New System.Drawing.Size(117, 117)
        Me.lblDebug.TabIndex = 36
        Me.lblDebug.Text = "Debug"
        '
        'lblEnd
        '
        Me.lblEnd.BackColor = System.Drawing.SystemColors.Control
        Me.lblEnd.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblEnd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblEnd.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEnd.Location = New System.Drawing.Point(3, 3)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblEnd.Size = New System.Drawing.Size(750, 628)
        Me.lblEnd.TabIndex = 10
        Me.lblEnd.Text = "Ende"
        Me.lblEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(12, 17)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(125, 35)
        Me.cmdCancel.TabIndex = 20
        Me.cmdCancel.Text = "Abbrechen"
        Me.cmdCancel.UseVisualStyleBackColor = True
        Me.cmdCancel.Visible = False
        '
        'pbProgress
        '
        Me.pbProgress.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbProgress.Location = New System.Drawing.Point(0, 55)
        Me.pbProgress.Name = "pbProgress"
        Me.pbProgress.Size = New System.Drawing.Size(764, 25)
        Me.pbProgress.TabIndex = 1
        '
        'cmdNext
        '
        Me.cmdNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdNext.AutoSize = True
        Me.cmdNext.BackColor = System.Drawing.SystemColors.Control
        Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdNext.Location = New System.Drawing.Point(626, 6)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdNext.Size = New System.Drawing.Size(125, 46)
        Me.cmdNext.TabIndex = 31
        Me.cmdNext.Text = "Weiter"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'lblProgress
        '
        Me.lblProgress.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblProgress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgress.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProgress.Location = New System.Drawing.Point(357, 29)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblProgress.Size = New System.Drawing.Size(34, 20)
        Me.lblProgress.TabIndex = 2
        Me.lblProgress.Text = "0%"
        Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFeedback
        '
        Me.lblFeedback.AutoSize = True
        Me.lblFeedback.BackColor = System.Drawing.SystemColors.Control
        Me.lblFeedback.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblFeedback.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFeedback.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFeedback.Location = New System.Drawing.Point(175, 594)
        Me.lblFeedback.Name = "lblFeedback"
        Me.lblFeedback.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFeedback.Size = New System.Drawing.Size(123, 29)
        Me.lblFeedback.TabIndex = 30
        Me.lblFeedback.Text = "Feedback"
        Me.lblFeedback.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblActive
        '
        Me.lblActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblActive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblActive.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblActive.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActive.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.lblActive.Location = New System.Drawing.Point(143, 591)
        Me.lblActive.Name = "lblActive"
        Me.lblActive.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblActive.Size = New System.Drawing.Size(26, 32)
        Me.lblActive.TabIndex = 13
        Me.lblActive.Text = "1"
        Me.lblActive.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblActive.Visible = False
        '
        'lblInactive
        '
        Me.lblInactive.BackColor = System.Drawing.SystemColors.Control
        Me.lblInactive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInactive.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblInactive.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInactive.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblInactive.Location = New System.Drawing.Point(113, 591)
        Me.lblInactive.Name = "lblInactive"
        Me.lblInactive.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblInactive.Size = New System.Drawing.Size(24, 25)
        Me.lblInactive.TabIndex = 12
        Me.lblInactive.Text = "1"
        Me.lblInactive.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblInactive.Visible = False
        '
        'tabExp
        '
        Me.tabExp.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabExp.Controls.Add(Me.tabBlank)
        Me.tabExp.Controls.Add(Me.tabStart)
        Me.tabExp.Controls.Add(Me.tabEnd)
        Me.tabExp.Controls.Add(Me.tabMode0)
        Me.tabExp.Controls.Add(Me.tabMode1)
        Me.tabExp.Controls.Add(Me.tabMode2)
        Me.tabExp.Controls.Add(Me.tabMode3)
        Me.tabExp.Controls.Add(Me.tabMode4)
        Me.tabExp.Controls.Add(Me.tabMode5)
        Me.tabExp.Controls.Add(Me.tabMode6)
        Me.tabExp.Controls.Add(Me.tabMode7)
        Me.tabExp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabExp.Location = New System.Drawing.Point(0, 0)
        Me.tabExp.Margin = New System.Windows.Forms.Padding(0)
        Me.tabExp.Name = "tabExp"
        Me.tabExp.SelectedIndex = 0
        Me.tabExp.Size = New System.Drawing.Size(764, 663)
        Me.tabExp.TabIndex = 33
        Me.tabExp.TabStop = False
        '
        'tabBlank
        '
        Me.tabBlank.Controls.Add(Me.lblDebug)
        Me.tabBlank.Controls.Add(Me.picLogo)
        Me.tabBlank.Location = New System.Drawing.Point(4, 25)
        Me.tabBlank.Name = "tabBlank"
        Me.tabBlank.Padding = New System.Windows.Forms.Padding(3)
        Me.tabBlank.Size = New System.Drawing.Size(756, 634)
        Me.tabBlank.TabIndex = 6
        Me.tabBlank.Text = "Blank"
        Me.tabBlank.UseVisualStyleBackColor = True
        '
        'tabStart
        '
        Me.tabStart.Controls.Add(Me.lblStart)
        Me.tabStart.Controls.Add(Me.cmdStart)
        Me.tabStart.Location = New System.Drawing.Point(4, 25)
        Me.tabStart.Name = "tabStart"
        Me.tabStart.Padding = New System.Windows.Forms.Padding(3)
        Me.tabStart.Size = New System.Drawing.Size(756, 634)
        Me.tabStart.TabIndex = 0
        Me.tabStart.Text = "Start"
        Me.tabStart.UseVisualStyleBackColor = True
        '
        'tabEnd
        '
        Me.tabEnd.Controls.Add(Me.lblEnd)
        Me.tabEnd.Location = New System.Drawing.Point(4, 25)
        Me.tabEnd.Name = "tabEnd"
        Me.tabEnd.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEnd.Size = New System.Drawing.Size(756, 634)
        Me.tabEnd.TabIndex = 1
        Me.tabEnd.Text = "End"
        Me.tabEnd.UseVisualStyleBackColor = True
        '
        'tabMode0
        '
        Me.tabMode0.Controls.Add(Me.pbMode0)
        Me.tabMode0.Controls.Add(Me._cmdResponse_0)
        Me.tabMode0.Controls.Add(Me._lblStim_0)
        Me.tabMode0.Controls.Add(Me._lblVisu_0)
        Me.tabMode0.Location = New System.Drawing.Point(4, 25)
        Me.tabMode0.Name = "tabMode0"
        Me.tabMode0.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMode0.Size = New System.Drawing.Size(756, 634)
        Me.tabMode0.TabIndex = 2
        Me.tabMode0.Text = "Mode 0"
        Me.tabMode0.UseVisualStyleBackColor = True
        '
        'pbMode0
        '
        Me.pbMode0.BackColor = System.Drawing.Color.Black
        Me.pbMode0.Location = New System.Drawing.Point(513, 55)
        Me.pbMode0.Name = "pbMode0"
        Me.pbMode0.Size = New System.Drawing.Size(195, 243)
        Me.pbMode0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbMode0.TabIndex = 15
        Me.pbMode0.TabStop = False
        Me.pbMode0.Visible = False
        '
        'tabMode1
        '
        Me.tabMode1.Controls.Add(Me._cmdResponse_100)
        Me.tabMode1.Controls.Add(Me._txtNum_100)
        Me.tabMode1.Controls.Add(Me._lblVisu_100)
        Me.tabMode1.Controls.Add(Me._lblStim_1)
        Me.tabMode1.Location = New System.Drawing.Point(4, 25)
        Me.tabMode1.Name = "tabMode1"
        Me.tabMode1.Size = New System.Drawing.Size(756, 634)
        Me.tabMode1.TabIndex = 3
        Me.tabMode1.Text = "Mode 1"
        Me.tabMode1.UseVisualStyleBackColor = True
        '
        'tabMode2
        '
        Me.tabMode2.Controls.Add(Me._cmdResponse_202)
        Me.tabMode2.Controls.Add(Me._cmdResponse_203)
        Me.tabMode2.Controls.Add(Me._lblStim_2)
        Me.tabMode2.Controls.Add(Me._cmdResponse_200)
        Me.tabMode2.Controls.Add(Me._cmdResponse_201)
        Me.tabMode2.Controls.Add(Me._lblVisu_200)
        Me.tabMode2.Controls.Add(Me._lblVisu_201)
        Me.tabMode2.Location = New System.Drawing.Point(4, 25)
        Me.tabMode2.Name = "tabMode2"
        Me.tabMode2.Size = New System.Drawing.Size(756, 634)
        Me.tabMode2.TabIndex = 4
        Me.tabMode2.Text = "Mode 2"
        Me.tabMode2.UseVisualStyleBackColor = True
        '
        'tabMode3
        '
        Me.tabMode3.Controls.Add(Me._lblStim_3)
        Me.tabMode3.Controls.Add(Me._cmdResponse_300)
        Me.tabMode3.Controls.Add(Me._lblVisu_300)
        Me.tabMode3.Location = New System.Drawing.Point(4, 25)
        Me.tabMode3.Name = "tabMode3"
        Me.tabMode3.Size = New System.Drawing.Size(756, 634)
        Me.tabMode3.TabIndex = 5
        Me.tabMode3.Text = "Mode 3"
        Me.tabMode3.UseVisualStyleBackColor = True
        '
        'tabMode4
        '
        Me.tabMode4.Controls.Add(Me._cmdResponse_4)
        Me.tabMode4.Controls.Add(Me._lblStim_4)
        Me.tabMode4.Controls.Add(Me._lblVisu_4)
        Me.tabMode4.Location = New System.Drawing.Point(4, 25)
        Me.tabMode4.Name = "tabMode4"
        Me.tabMode4.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMode4.Size = New System.Drawing.Size(756, 634)
        Me.tabMode4.TabIndex = 6
        Me.tabMode4.Text = "Mode 4"
        Me.tabMode4.UseVisualStyleBackColor = True
        '
        'tabMode5
        '
        Me.tabMode5.Controls.Add(Me.lblMode5Scroll)
        Me.tabMode5.Controls.Add(Me.Mode5TrackBar)
        Me.tabMode5.Controls.Add(Me._cmdResponse_5)
        Me.tabMode5.Controls.Add(Me._lblVisu_5)
        Me.tabMode5.Controls.Add(Me._lblStim_5)
        Me.tabMode5.Location = New System.Drawing.Point(4, 25)
        Me.tabMode5.Name = "tabMode5"
        Me.tabMode5.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMode5.Size = New System.Drawing.Size(756, 634)
        Me.tabMode5.TabIndex = 7
        Me.tabMode5.Text = "Mode 5"
        Me.tabMode5.UseVisualStyleBackColor = True
        '
        'lblMode5Scroll
        '
        Me.lblMode5Scroll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMode5Scroll.AutoSize = True
        Me.lblMode5Scroll.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMode5Scroll.Location = New System.Drawing.Point(6, 589)
        Me.lblMode5Scroll.Name = "lblMode5Scroll"
        Me.lblMode5Scroll.Size = New System.Drawing.Size(157, 20)
        Me.lblMode5Scroll.TabIndex = 19
        Me.lblMode5Scroll.Tag = "lblMode5Scroll Value"
        Me.lblMode5Scroll.Text = "lblMode5Scroll Value"
        Me.lblMode5Scroll.Visible = False
        '
        'Mode5TrackBar
        '
        Me.Mode5TrackBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Mode5TrackBar.Location = New System.Drawing.Point(0, 607)
        Me.Mode5TrackBar.Maximum = 100
        Me.Mode5TrackBar.Name = "Mode5TrackBar"
        Me.Mode5TrackBar.Size = New System.Drawing.Size(756, 45)
        Me.Mode5TrackBar.TabIndex = 18
        Me.Mode5TrackBar.Value = 50
        '
        '_cmdResponse_5
        '
        Me._cmdResponse_5.BackColor = System.Drawing.SystemColors.Control
        Me._cmdResponse_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdResponse_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmdResponse_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdResponse_5.Location = New System.Drawing.Point(558, 86)
        Me._cmdResponse_5.Name = "_cmdResponse_5"
        Me._cmdResponse_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdResponse_5.Size = New System.Drawing.Size(113, 45)
        Me._cmdResponse_5.TabIndex = 15
        Me._cmdResponse_5.Tag = "Response 1"
        Me._cmdResponse_5.Text = "1"
        Me._cmdResponse_5.UseVisualStyleBackColor = True
        '
        '_lblVisu_5
        '
        Me._lblVisu_5.BackColor = System.Drawing.SystemColors.Control
        Me._lblVisu_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._lblVisu_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblVisu_5.Font = New System.Drawing.Font("Arial", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblVisu_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblVisu_5.Location = New System.Drawing.Point(292, 86)
        Me._lblVisu_5.Name = "_lblVisu_5"
        Me._lblVisu_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblVisu_5.Size = New System.Drawing.Size(180, 180)
        Me._lblVisu_5.TabIndex = 16
        Me._lblVisu_5.Tag = "Visu 1"
        Me._lblVisu_5.Text = "1"
        Me._lblVisu_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblStim_5
        '
        Me._lblStim_5.AutoSize = True
        Me._lblStim_5.BackColor = System.Drawing.SystemColors.Control
        Me._lblStim_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblStim_5.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblStim_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblStim_5.Location = New System.Drawing.Point(262, 20)
        Me._lblStim_5.Name = "_lblStim_5"
        Me._lblStim_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblStim_5.Size = New System.Drawing.Size(214, 56)
        Me._lblStim_5.TabIndex = 13
        Me._lblStim_5.Tag = "Request"
        Me._lblStim_5.Text = "Request"
        Me._lblStim_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabMode6
        '
        Me.tabMode6.Controls.Add(Me.p6)
        Me.tabMode6.Controls.Add(Me._cmdResponse_6)
        Me.tabMode6.Controls.Add(Me._lblStim_6)
        Me.tabMode6.Controls.Add(Me._lblVisu_6)
        Me.tabMode6.Location = New System.Drawing.Point(4, 25)
        Me.tabMode6.Name = "tabMode6"
        Me.tabMode6.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMode6.Size = New System.Drawing.Size(756, 634)
        Me.tabMode6.TabIndex = 8
        Me.tabMode6.Text = "Mode 6"
        Me.tabMode6.UseVisualStyleBackColor = True
        '
        'p6
        '
        Me.p6.Controls.Add(Me.p6Text)
        Me.p6.Controls.Add(Me.pb6Right)
        Me.p6.Controls.Add(Me.pb6Left)
        Me.p6.Location = New System.Drawing.Point(8, 6)
        Me.p6.Name = "p6"
        Me.p6.Size = New System.Drawing.Size(183, 67)
        Me.p6.TabIndex = 26
        Me.p6.Visible = False
        '
        'p6Text
        '
        Me.p6Text.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.p6Text.BackColor = System.Drawing.SystemColors.Control
        Me.p6Text.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.p6Text.Enabled = False
        Me.p6Text.Location = New System.Drawing.Point(41, 28)
        Me.p6Text.Name = "p6Text"
        Me.p6Text.Size = New System.Drawing.Size(103, 13)
        Me.p6Text.TabIndex = 2
        Me.p6Text.Text = "+"
        Me.p6Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pb6Right
        '
        Me.pb6Right.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pb6Right.Image = Global.ExpSuite.My.Resources.Resources.connected
        Me.pb6Right.Location = New System.Drawing.Point(400, 189)
        Me.pb6Right.Name = "pb6Right"
        Me.pb6Right.Size = New System.Drawing.Size(3, 0)
        Me.pb6Right.TabIndex = 1
        Me.pb6Right.TabStop = False
        '
        'pb6Left
        '
        Me.pb6Left.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pb6Left.Image = Global.ExpSuite.My.Resources.Resources.connected
        Me.pb6Left.Location = New System.Drawing.Point(100, 189)
        Me.pb6Left.Name = "pb6Left"
        Me.pb6Left.Size = New System.Drawing.Size(3, 0)
        Me.pb6Left.TabIndex = 0
        Me.pb6Left.TabStop = False
        '
        '_cmdResponse_6
        '
        Me._cmdResponse_6.BackColor = System.Drawing.SystemColors.Control
        Me._cmdResponse_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdResponse_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmdResponse_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdResponse_6.Location = New System.Drawing.Point(315, 133)
        Me._cmdResponse_6.Name = "_cmdResponse_6"
        Me._cmdResponse_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdResponse_6.Size = New System.Drawing.Size(276, 226)
        Me._cmdResponse_6.TabIndex = 16
        Me._cmdResponse_6.Tag = "Response 1"
        Me._cmdResponse_6.Text = "< 6"
        Me._cmdResponse_6.UseVisualStyleBackColor = True
        '
        '_lblStim_6
        '
        Me._lblStim_6.AutoSize = True
        Me._lblStim_6.BackColor = System.Drawing.SystemColors.Control
        Me._lblStim_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblStim_6.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblStim_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblStim_6.Location = New System.Drawing.Point(183, 438)
        Me._lblStim_6.Name = "_lblStim_6"
        Me._lblStim_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblStim_6.Size = New System.Drawing.Size(214, 56)
        Me._lblStim_6.TabIndex = 18
        Me._lblStim_6.Tag = "Request"
        Me._lblStim_6.Text = "Request"
        Me._lblStim_6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_lblVisu_6
        '
        Me._lblVisu_6.BackColor = System.Drawing.SystemColors.Control
        Me._lblVisu_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._lblVisu_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblVisu_6.Font = New System.Drawing.Font("Arial", 99.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblVisu_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblVisu_6.Location = New System.Drawing.Point(139, 248)
        Me._lblVisu_6.Name = "_lblVisu_6"
        Me._lblVisu_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblVisu_6.Size = New System.Drawing.Size(52, 42)
        Me._lblVisu_6.TabIndex = 25
        Me._lblVisu_6.Tag = "Visu 1"
        Me._lblVisu_6.Text = "1"
        Me._lblVisu_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabMode7
        '
        Me.tabMode7.Controls.Add(Me.gbQ7b)
        Me.tabMode7.Controls.Add(Me.gbQ7c)
        Me.tabMode7.Controls.Add(Me.gbQ7d)
        Me.tabMode7.Controls.Add(Me.gbQ7a)
        Me.tabMode7.Controls.Add(Me._cmdResponse_700)
        Me.tabMode7.Controls.Add(Me._lblVisu_7)
        Me.tabMode7.Controls.Add(Me.tbResponse)
        Me.tabMode7.Controls.Add(Me._lblStim_7)
        Me.tabMode7.Controls.Add(Me.tbPlay)
        Me.tabMode7.Location = New System.Drawing.Point(4, 25)
        Me.tabMode7.Name = "tabMode7"
        Me.tabMode7.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMode7.Size = New System.Drawing.Size(756, 634)
        Me.tabMode7.TabIndex = 9
        Me.tabMode7.Text = "Mode 7"
        Me.tabMode7.UseVisualStyleBackColor = True
        '
        'gbQ7b
        '
        Me.gbQ7b.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbQ7b.Controls.Add(Me.tblQ7b)
        Me.gbQ7b.Location = New System.Drawing.Point(3, 425)
        Me.gbQ7b.Name = "gbQ7b"
        Me.gbQ7b.Size = New System.Drawing.Size(750, 69)
        Me.gbQ7b.TabIndex = 33
        Me.gbQ7b.TabStop = False
        '
        'tblQ7b
        '
        Me.tblQ7b.AutoSize = True
        Me.tblQ7b.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tblQ7b.ColumnCount = 6
        Me.tblQ7b.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblQ7b.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tblQ7b.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tblQ7b.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tblQ7b.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tblQ7b.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tblQ7b.Controls.Add(Me.rb7b5, 5, 0)
        Me.tblQ7b.Controls.Add(Me.lblQ7b, 0, 0)
        Me.tblQ7b.Controls.Add(Me.rb7b2, 2, 0)
        Me.tblQ7b.Controls.Add(Me.rb7b1, 1, 0)
        Me.tblQ7b.Controls.Add(Me.rb7b4, 4, 0)
        Me.tblQ7b.Controls.Add(Me.rb7b3, 3, 0)
        Me.tblQ7b.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblQ7b.Location = New System.Drawing.Point(3, 16)
        Me.tblQ7b.Name = "tblQ7b"
        Me.tblQ7b.RowCount = 1
        Me.tblQ7b.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblQ7b.Size = New System.Drawing.Size(744, 50)
        Me.tblQ7b.TabIndex = 31
        '
        'rb7b5
        '
        Me.rb7b5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rb7b5.AutoSize = True
        Me.rb7b5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rb7b5.Location = New System.Drawing.Point(671, 3)
        Me.rb7b5.Name = "rb7b5"
        Me.rb7b5.Size = New System.Drawing.Size(70, 44)
        Me.rb7b5.TabIndex = 34
        Me.rb7b5.Tag = "5"
        Me.rb7b5.Text = "rb7b5"
        Me.rb7b5.UseVisualStyleBackColor = True
        '
        'lblQ7b
        '
        Me.lblQ7b.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQ7b.AutoSize = True
        Me.lblQ7b.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblQ7b.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!)
        Me.lblQ7b.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblQ7b.Location = New System.Drawing.Point(3, 0)
        Me.lblQ7b.Name = "lblQ7b"
        Me.lblQ7b.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblQ7b.Size = New System.Drawing.Size(366, 50)
        Me.lblQ7b.TabIndex = 30
        Me.lblQ7b.Tag = ""
        Me.lblQ7b.Text = "lblQ7b"
        Me.lblQ7b.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rb7b2
        '
        Me.rb7b2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rb7b2.AutoSize = True
        Me.rb7b2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rb7b2.Location = New System.Drawing.Point(449, 3)
        Me.rb7b2.Name = "rb7b2"
        Me.rb7b2.Size = New System.Drawing.Size(68, 44)
        Me.rb7b2.TabIndex = 3
        Me.rb7b2.Tag = "2"
        Me.rb7b2.Text = "rb7b2"
        Me.rb7b2.UseVisualStyleBackColor = True
        '
        'rb7b1
        '
        Me.rb7b1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rb7b1.AutoSize = True
        Me.rb7b1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rb7b1.Location = New System.Drawing.Point(375, 3)
        Me.rb7b1.Name = "rb7b1"
        Me.rb7b1.Size = New System.Drawing.Size(68, 44)
        Me.rb7b1.TabIndex = 2
        Me.rb7b1.Tag = "1"
        Me.rb7b1.Text = "rb7b1"
        Me.rb7b1.UseVisualStyleBackColor = True
        '
        'rb7b4
        '
        Me.rb7b4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rb7b4.AutoSize = True
        Me.rb7b4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rb7b4.Location = New System.Drawing.Point(597, 3)
        Me.rb7b4.Name = "rb7b4"
        Me.rb7b4.Size = New System.Drawing.Size(68, 44)
        Me.rb7b4.TabIndex = 30
        Me.rb7b4.Tag = "4"
        Me.rb7b4.Text = "rb7b4"
        Me.rb7b4.UseVisualStyleBackColor = True
        '
        'rb7b3
        '
        Me.rb7b3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rb7b3.AutoSize = True
        Me.rb7b3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rb7b3.Location = New System.Drawing.Point(523, 3)
        Me.rb7b3.Name = "rb7b3"
        Me.rb7b3.Size = New System.Drawing.Size(68, 44)
        Me.rb7b3.TabIndex = 30
        Me.rb7b3.Tag = "3"
        Me.rb7b3.Text = "rb7b3"
        Me.rb7b3.UseVisualStyleBackColor = True
        '
        'gbQ7c
        '
        Me.gbQ7c.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbQ7c.Controls.Add(Me.tblQ7c)
        Me.gbQ7c.Location = New System.Drawing.Point(3, 495)
        Me.gbQ7c.Name = "gbQ7c"
        Me.gbQ7c.Size = New System.Drawing.Size(750, 69)
        Me.gbQ7c.TabIndex = 32
        Me.gbQ7c.TabStop = False
        '
        'tblQ7c
        '
        Me.tblQ7c.AutoSize = True
        Me.tblQ7c.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tblQ7c.ColumnCount = 6
        Me.tblQ7c.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblQ7c.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tblQ7c.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tblQ7c.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tblQ7c.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tblQ7c.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tblQ7c.Controls.Add(Me.rb7c5, 5, 0)
        Me.tblQ7c.Controls.Add(Me.lblQ7c, 0, 0)
        Me.tblQ7c.Controls.Add(Me.rb7c2, 2, 0)
        Me.tblQ7c.Controls.Add(Me.rb7c1, 1, 0)
        Me.tblQ7c.Controls.Add(Me.rb7c4, 4, 0)
        Me.tblQ7c.Controls.Add(Me.rb7c3, 3, 0)
        Me.tblQ7c.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblQ7c.Location = New System.Drawing.Point(3, 16)
        Me.tblQ7c.Name = "tblQ7c"
        Me.tblQ7c.RowCount = 1
        Me.tblQ7c.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblQ7c.Size = New System.Drawing.Size(744, 50)
        Me.tblQ7c.TabIndex = 31
        '
        'rb7c5
        '
        Me.rb7c5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rb7c5.AutoSize = True
        Me.rb7c5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rb7c5.Location = New System.Drawing.Point(671, 3)
        Me.rb7c5.Name = "rb7c5"
        Me.rb7c5.Size = New System.Drawing.Size(70, 44)
        Me.rb7c5.TabIndex = 34
        Me.rb7c5.Tag = "5"
        Me.rb7c5.Text = "rb7c5"
        Me.rb7c5.UseVisualStyleBackColor = True
        '
        'lblQ7c
        '
        Me.lblQ7c.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQ7c.AutoSize = True
        Me.lblQ7c.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblQ7c.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!)
        Me.lblQ7c.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblQ7c.Location = New System.Drawing.Point(3, 0)
        Me.lblQ7c.Name = "lblQ7c"
        Me.lblQ7c.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblQ7c.Size = New System.Drawing.Size(366, 50)
        Me.lblQ7c.TabIndex = 30
        Me.lblQ7c.Tag = ""
        Me.lblQ7c.Text = "lblQ7c"
        Me.lblQ7c.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rb7c2
        '
        Me.rb7c2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rb7c2.AutoSize = True
        Me.rb7c2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rb7c2.Location = New System.Drawing.Point(449, 3)
        Me.rb7c2.Name = "rb7c2"
        Me.rb7c2.Size = New System.Drawing.Size(68, 44)
        Me.rb7c2.TabIndex = 3
        Me.rb7c2.Tag = "2"
        Me.rb7c2.Text = "rb7c2"
        Me.rb7c2.UseVisualStyleBackColor = True
        '
        'rb7c1
        '
        Me.rb7c1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rb7c1.AutoSize = True
        Me.rb7c1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rb7c1.Location = New System.Drawing.Point(375, 3)
        Me.rb7c1.Name = "rb7c1"
        Me.rb7c1.Size = New System.Drawing.Size(68, 44)
        Me.rb7c1.TabIndex = 2
        Me.rb7c1.Tag = "1"
        Me.rb7c1.Text = "rb7c1"
        Me.rb7c1.UseVisualStyleBackColor = True
        '
        'rb7c4
        '
        Me.rb7c4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rb7c4.AutoSize = True
        Me.rb7c4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rb7c4.Location = New System.Drawing.Point(597, 3)
        Me.rb7c4.Name = "rb7c4"
        Me.rb7c4.Size = New System.Drawing.Size(68, 44)
        Me.rb7c4.TabIndex = 30
        Me.rb7c4.Tag = "4"
        Me.rb7c4.Text = "rb7c4"
        Me.rb7c4.UseVisualStyleBackColor = True
        '
        'rb7c3
        '
        Me.rb7c3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rb7c3.AutoSize = True
        Me.rb7c3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rb7c3.Location = New System.Drawing.Point(523, 3)
        Me.rb7c3.Name = "rb7c3"
        Me.rb7c3.Size = New System.Drawing.Size(68, 44)
        Me.rb7c3.TabIndex = 30
        Me.rb7c3.Tag = "3"
        Me.rb7c3.Text = "rb7c3"
        Me.rb7c3.UseVisualStyleBackColor = True
        '
        'gbQ7d
        '
        Me.gbQ7d.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbQ7d.Controls.Add(Me.tblQ7d)
        Me.gbQ7d.Location = New System.Drawing.Point(3, 565)
        Me.gbQ7d.Name = "gbQ7d"
        Me.gbQ7d.Size = New System.Drawing.Size(750, 69)
        Me.gbQ7d.TabIndex = 31
        Me.gbQ7d.TabStop = False
        '
        'tblQ7d
        '
        Me.tblQ7d.AutoSize = True
        Me.tblQ7d.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tblQ7d.ColumnCount = 6
        Me.tblQ7d.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblQ7d.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tblQ7d.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tblQ7d.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tblQ7d.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tblQ7d.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tblQ7d.Controls.Add(Me.rb7d5, 5, 0)
        Me.tblQ7d.Controls.Add(Me.rb7d2, 2, 0)
        Me.tblQ7d.Controls.Add(Me.rb7d1, 1, 0)
        Me.tblQ7d.Controls.Add(Me.rb7d4, 4, 0)
        Me.tblQ7d.Controls.Add(Me.rb7d3, 3, 0)
        Me.tblQ7d.Controls.Add(Me.lblQ7d, 0, 0)
        Me.tblQ7d.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblQ7d.Location = New System.Drawing.Point(3, 16)
        Me.tblQ7d.Name = "tblQ7d"
        Me.tblQ7d.RowCount = 1
        Me.tblQ7d.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblQ7d.Size = New System.Drawing.Size(744, 50)
        Me.tblQ7d.TabIndex = 31
        '
        'rb7d5
        '
        Me.rb7d5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rb7d5.AutoSize = True
        Me.rb7d5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rb7d5.Location = New System.Drawing.Point(671, 3)
        Me.rb7d5.Name = "rb7d5"
        Me.rb7d5.Size = New System.Drawing.Size(70, 44)
        Me.rb7d5.TabIndex = 34
        Me.rb7d5.Tag = "5"
        Me.rb7d5.Text = "rb7d5"
        Me.rb7d5.UseVisualStyleBackColor = True
        '
        'rb7d2
        '
        Me.rb7d2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rb7d2.AutoSize = True
        Me.rb7d2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rb7d2.Location = New System.Drawing.Point(449, 3)
        Me.rb7d2.Name = "rb7d2"
        Me.rb7d2.Size = New System.Drawing.Size(68, 44)
        Me.rb7d2.TabIndex = 3
        Me.rb7d2.Tag = "2"
        Me.rb7d2.Text = "rb7d2"
        Me.rb7d2.UseVisualStyleBackColor = True
        '
        'rb7d1
        '
        Me.rb7d1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rb7d1.AutoSize = True
        Me.rb7d1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rb7d1.Location = New System.Drawing.Point(375, 3)
        Me.rb7d1.Name = "rb7d1"
        Me.rb7d1.Size = New System.Drawing.Size(68, 44)
        Me.rb7d1.TabIndex = 2
        Me.rb7d1.Tag = "1"
        Me.rb7d1.Text = "rb7d1"
        Me.rb7d1.UseVisualStyleBackColor = True
        '
        'rb7d4
        '
        Me.rb7d4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rb7d4.AutoSize = True
        Me.rb7d4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rb7d4.Location = New System.Drawing.Point(597, 3)
        Me.rb7d4.Name = "rb7d4"
        Me.rb7d4.Size = New System.Drawing.Size(68, 44)
        Me.rb7d4.TabIndex = 30
        Me.rb7d4.Tag = "4"
        Me.rb7d4.Text = "rb7d4"
        Me.rb7d4.UseVisualStyleBackColor = True
        '
        'rb7d3
        '
        Me.rb7d3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rb7d3.AutoSize = True
        Me.rb7d3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rb7d3.Location = New System.Drawing.Point(523, 3)
        Me.rb7d3.Name = "rb7d3"
        Me.rb7d3.Size = New System.Drawing.Size(68, 44)
        Me.rb7d3.TabIndex = 30
        Me.rb7d3.Tag = "3"
        Me.rb7d3.Text = "rb7d3"
        Me.rb7d3.UseVisualStyleBackColor = True
        '
        'lblQ7d
        '
        Me.lblQ7d.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQ7d.AutoSize = True
        Me.lblQ7d.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblQ7d.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!)
        Me.lblQ7d.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblQ7d.Location = New System.Drawing.Point(3, 0)
        Me.lblQ7d.Name = "lblQ7d"
        Me.lblQ7d.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblQ7d.Size = New System.Drawing.Size(366, 50)
        Me.lblQ7d.TabIndex = 30
        Me.lblQ7d.Tag = ""
        Me.lblQ7d.Text = "lblQ7d"
        Me.lblQ7d.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbQ7a
        '
        Me.gbQ7a.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbQ7a.Controls.Add(Me.tblQ7a)
        Me.gbQ7a.Location = New System.Drawing.Point(3, 355)
        Me.gbQ7a.Name = "gbQ7a"
        Me.gbQ7a.Size = New System.Drawing.Size(750, 69)
        Me.gbQ7a.TabIndex = 30
        Me.gbQ7a.TabStop = False
        '
        'tblQ7a
        '
        Me.tblQ7a.AutoSize = True
        Me.tblQ7a.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tblQ7a.ColumnCount = 6
        Me.tblQ7a.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblQ7a.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tblQ7a.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tblQ7a.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tblQ7a.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tblQ7a.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tblQ7a.Controls.Add(Me.rb7a5, 5, 0)
        Me.tblQ7a.Controls.Add(Me.lblQ7a, 0, 0)
        Me.tblQ7a.Controls.Add(Me.rb7a2, 2, 0)
        Me.tblQ7a.Controls.Add(Me.rb7a1, 1, 0)
        Me.tblQ7a.Controls.Add(Me.rb7a4, 4, 0)
        Me.tblQ7a.Controls.Add(Me.rb7a3, 3, 0)
        Me.tblQ7a.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblQ7a.Location = New System.Drawing.Point(3, 16)
        Me.tblQ7a.Name = "tblQ7a"
        Me.tblQ7a.RowCount = 1
        Me.tblQ7a.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblQ7a.Size = New System.Drawing.Size(744, 50)
        Me.tblQ7a.TabIndex = 31
        '
        'rb7a5
        '
        Me.rb7a5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rb7a5.AutoSize = True
        Me.rb7a5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rb7a5.Location = New System.Drawing.Point(671, 3)
        Me.rb7a5.Name = "rb7a5"
        Me.rb7a5.Size = New System.Drawing.Size(70, 44)
        Me.rb7a5.TabIndex = 34
        Me.rb7a5.Tag = "5"
        Me.rb7a5.Text = "rb7a5"
        Me.rb7a5.UseVisualStyleBackColor = True
        '
        'lblQ7a
        '
        Me.lblQ7a.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQ7a.AutoSize = True
        Me.lblQ7a.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblQ7a.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!)
        Me.lblQ7a.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblQ7a.Location = New System.Drawing.Point(3, 0)
        Me.lblQ7a.Name = "lblQ7a"
        Me.lblQ7a.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblQ7a.Size = New System.Drawing.Size(366, 50)
        Me.lblQ7a.TabIndex = 30
        Me.lblQ7a.Tag = ""
        Me.lblQ7a.Text = "lblQ7a"
        Me.lblQ7a.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rb7a2
        '
        Me.rb7a2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rb7a2.AutoSize = True
        Me.rb7a2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rb7a2.Location = New System.Drawing.Point(449, 3)
        Me.rb7a2.Name = "rb7a2"
        Me.rb7a2.Size = New System.Drawing.Size(68, 44)
        Me.rb7a2.TabIndex = 3
        Me.rb7a2.Tag = "2"
        Me.rb7a2.Text = "rb7a2"
        Me.rb7a2.UseVisualStyleBackColor = True
        '
        'rb7a1
        '
        Me.rb7a1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rb7a1.AutoSize = True
        Me.rb7a1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rb7a1.Location = New System.Drawing.Point(375, 3)
        Me.rb7a1.Name = "rb7a1"
        Me.rb7a1.Size = New System.Drawing.Size(68, 44)
        Me.rb7a1.TabIndex = 2
        Me.rb7a1.Tag = "1"
        Me.rb7a1.Text = "rb7a1"
        Me.rb7a1.UseVisualStyleBackColor = True
        '
        'rb7a4
        '
        Me.rb7a4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rb7a4.AutoSize = True
        Me.rb7a4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rb7a4.Location = New System.Drawing.Point(597, 3)
        Me.rb7a4.Name = "rb7a4"
        Me.rb7a4.Size = New System.Drawing.Size(68, 44)
        Me.rb7a4.TabIndex = 30
        Me.rb7a4.Tag = "4"
        Me.rb7a4.Text = "rb7a4"
        Me.rb7a4.UseVisualStyleBackColor = True
        '
        'rb7a3
        '
        Me.rb7a3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rb7a3.AutoSize = True
        Me.rb7a3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rb7a3.Location = New System.Drawing.Point(523, 3)
        Me.rb7a3.Name = "rb7a3"
        Me.rb7a3.Size = New System.Drawing.Size(68, 44)
        Me.rb7a3.TabIndex = 30
        Me.rb7a3.Tag = "3"
        Me.rb7a3.Text = "rb7a3"
        Me.rb7a3.UseVisualStyleBackColor = True
        '
        '_cmdResponse_700
        '
        Me._cmdResponse_700.BackColor = System.Drawing.SystemColors.Control
        Me._cmdResponse_700.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdResponse_700.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._cmdResponse_700.ForeColor = System.Drawing.SystemColors.ControlText
        Me._cmdResponse_700.Location = New System.Drawing.Point(231, 258)
        Me._cmdResponse_700.Name = "_cmdResponse_700"
        Me._cmdResponse_700.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdResponse_700.Size = New System.Drawing.Size(113, 45)
        Me._cmdResponse_700.TabIndex = 17
        Me._cmdResponse_700.Tag = "Response 1"
        Me._cmdResponse_700.Text = "1"
        Me._cmdResponse_700.UseVisualStyleBackColor = True
        '
        '_lblVisu_7
        '
        Me._lblVisu_7.BackColor = System.Drawing.SystemColors.Control
        Me._lblVisu_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._lblVisu_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblVisu_7.Font = New System.Drawing.Font("Arial", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblVisu_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblVisu_7.Location = New System.Drawing.Point(14, 4)
        Me._lblVisu_7.Name = "_lblVisu_7"
        Me._lblVisu_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblVisu_7.Size = New System.Drawing.Size(76, 64)
        Me._lblVisu_7.TabIndex = 16
        Me._lblVisu_7.Tag = "Visu 1"
        Me._lblVisu_7.Text = "1"
        Me._lblVisu_7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me._lblVisu_7.Visible = False
        '
        'tbResponse
        '
        Me.tbResponse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbResponse.LargeChange = 1
        Me.tbResponse.Location = New System.Drawing.Point(8, 190)
        Me.tbResponse.Margin = New System.Windows.Forms.Padding(0)
        Me.tbResponse.Maximum = 1000
        Me.tbResponse.Name = "tbResponse"
        Me.tbResponse.Size = New System.Drawing.Size(739, 45)
        Me.tbResponse.TabIndex = 15
        Me.tbResponse.Tag = ""
        Me.tbResponse.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        Me.tbResponse.Value = 500
        '
        '_lblStim_7
        '
        Me._lblStim_7.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._lblStim_7.AutoSize = True
        Me._lblStim_7.BackColor = System.Drawing.SystemColors.Control
        Me._lblStim_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblStim_7.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblStim_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblStim_7.Location = New System.Drawing.Point(8, 46)
        Me._lblStim_7.Name = "_lblStim_7"
        Me._lblStim_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblStim_7.Size = New System.Drawing.Size(214, 56)
        Me._lblStim_7.TabIndex = 14
        Me._lblStim_7.Tag = "Request"
        Me._lblStim_7.Text = "Request"
        Me._lblStim_7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tbPlay
        '
        Me.tbPlay.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPlay.Location = New System.Drawing.Point(8, 152)
        Me.tbPlay.Margin = New System.Windows.Forms.Padding(0)
        Me.tbPlay.Maximum = 1000
        Me.tbPlay.Name = "tbPlay"
        Me.tbPlay.Size = New System.Drawing.Size(739, 45)
        Me.tbPlay.TabIndex = 3
        '
        'fraProgress
        '
        Me.fraProgress.Controls.Add(Me.lblProgressText)
        Me.fraProgress.Controls.Add(Me.pbProgress)
        Me.fraProgress.Controls.Add(Me.cmdCancel)
        Me.fraProgress.Controls.Add(Me.lblProgress)
        Me.fraProgress.Controls.Add(Me.cmdNext)
        Me.fraProgress.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.fraProgress.Location = New System.Drawing.Point(0, 663)
        Me.fraProgress.Name = "fraProgress"
        Me.fraProgress.Size = New System.Drawing.Size(764, 80)
        Me.fraProgress.TabIndex = 37
        '
        'lblProgressText
        '
        Me.lblProgressText.AutoSize = True
        Me.lblProgressText.Location = New System.Drawing.Point(0, 0)
        Me.lblProgressText.Name = "lblProgressText"
        Me.lblProgressText.Size = New System.Drawing.Size(39, 13)
        Me.lblProgressText.TabIndex = 32
        Me.lblProgressText.Text = "Label1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tabExp)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(764, 663)
        Me.Panel1.TabIndex = 38
        '
        'frmExp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(764, 743)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.fraProgress)
        Me.Controls.Add(Me.lblFeedback)
        Me.Controls.Add(Me.lblActive)
        Me.Controls.Add(Me.lblInactive)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(158, 273)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(640, 480)
        Me.Name = "frmExp"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabExp.ResumeLayout(False)
        Me.tabBlank.ResumeLayout(False)
        Me.tabStart.ResumeLayout(False)
        Me.tabEnd.ResumeLayout(False)
        Me.tabMode0.ResumeLayout(False)
        Me.tabMode0.PerformLayout()
        CType(Me.pbMode0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMode1.ResumeLayout(False)
        Me.tabMode1.PerformLayout()
        Me.tabMode2.ResumeLayout(False)
        Me.tabMode3.ResumeLayout(False)
        Me.tabMode3.PerformLayout()
        Me.tabMode4.ResumeLayout(False)
        Me.tabMode4.PerformLayout()
        Me.tabMode5.ResumeLayout(False)
        Me.tabMode5.PerformLayout()
        CType(Me.Mode5TrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMode6.ResumeLayout(False)
        Me.tabMode6.PerformLayout()
        Me.p6.ResumeLayout(False)
        Me.p6.PerformLayout()
        CType(Me.pb6Right, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb6Left, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMode7.ResumeLayout(False)
        Me.tabMode7.PerformLayout()
        Me.gbQ7b.ResumeLayout(False)
        Me.gbQ7b.PerformLayout()
        Me.tblQ7b.ResumeLayout(False)
        Me.tblQ7b.PerformLayout()
        Me.gbQ7c.ResumeLayout(False)
        Me.gbQ7c.PerformLayout()
        Me.tblQ7c.ResumeLayout(False)
        Me.tblQ7c.PerformLayout()
        Me.gbQ7d.ResumeLayout(False)
        Me.gbQ7d.PerformLayout()
        Me.tblQ7d.ResumeLayout(False)
        Me.tblQ7d.PerformLayout()
        Me.gbQ7a.ResumeLayout(False)
        Me.gbQ7a.PerformLayout()
        Me.tblQ7a.ResumeLayout(False)
        Me.tblQ7a.PerformLayout()
        CType(Me.tbResponse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPlay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraProgress.ResumeLayout(False)
        Me.fraProgress.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabExp As System.Windows.Forms.TabControl
    Friend WithEvents tabStart As System.Windows.Forms.TabPage
    Friend WithEvents tabEnd As System.Windows.Forms.TabPage
    Friend WithEvents tabMode0 As System.Windows.Forms.TabPage
    Friend WithEvents tabMode1 As System.Windows.Forms.TabPage
    Friend WithEvents tabMode2 As System.Windows.Forms.TabPage
    Friend WithEvents tabMode3 As System.Windows.Forms.TabPage
    Friend WithEvents tabMode4 As System.Windows.Forms.TabPage
    Friend WithEvents tabMode5 As System.Windows.Forms.TabPage
    Friend WithEvents tabMode6 As System.Windows.Forms.TabPage
    Friend WithEvents tabBlank As System.Windows.Forms.TabPage
    Friend WithEvents fraProgress As System.Windows.Forms.Panel
    Friend WithEvents lblProgressText As System.Windows.Forms.Label
    Public WithEvents _lblStim_5 As System.Windows.Forms.Label
    Public WithEvents _cmdResponse_5 As System.Windows.Forms.Button
    Public WithEvents _lblVisu_5 As System.Windows.Forms.Label
    Friend WithEvents Mode5TrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents lblMode5Scroll As System.Windows.Forms.Label
    Public WithEvents _cmdResponse_6 As System.Windows.Forms.Button
    Public WithEvents _lblStim_6 As System.Windows.Forms.Label
    Public WithEvents _lblVisu_6 As System.Windows.Forms.Label
    Friend WithEvents pb6Left As System.Windows.Forms.PictureBox
    Friend WithEvents pb6Right As System.Windows.Forms.PictureBox
    Friend WithEvents p6 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents p6Text As System.Windows.Forms.TextBox
    Friend WithEvents tabMode7 As System.Windows.Forms.TabPage
    Friend WithEvents tbPlay As System.Windows.Forms.TrackBar
    Friend WithEvents rb7a1 As System.Windows.Forms.RadioButton
    Friend WithEvents tbResponse As System.Windows.Forms.TrackBar
    Public WithEvents _lblStim_7 As System.Windows.Forms.Label
    Public WithEvents _cmdResponse_700 As System.Windows.Forms.Button
    Friend WithEvents rb7a4 As System.Windows.Forms.RadioButton
    Friend WithEvents rb7a3 As System.Windows.Forms.RadioButton
    Friend WithEvents rb7a2 As System.Windows.Forms.RadioButton
    Public WithEvents lblQ7a As System.Windows.Forms.Label
    Friend WithEvents tblQ7a As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gbQ7b As System.Windows.Forms.GroupBox
    Friend WithEvents tblQ7b As System.Windows.Forms.TableLayoutPanel
    Public WithEvents lblQ7b As System.Windows.Forms.Label
    Friend WithEvents rb7b2 As System.Windows.Forms.RadioButton
    Friend WithEvents rb7b1 As System.Windows.Forms.RadioButton
    Friend WithEvents rb7b4 As System.Windows.Forms.RadioButton
    Friend WithEvents rb7b3 As System.Windows.Forms.RadioButton
    Friend WithEvents gbQ7c As System.Windows.Forms.GroupBox
    Friend WithEvents tblQ7c As System.Windows.Forms.TableLayoutPanel
    Public WithEvents lblQ7c As System.Windows.Forms.Label
    Friend WithEvents rb7c2 As System.Windows.Forms.RadioButton
    Friend WithEvents rb7c1 As System.Windows.Forms.RadioButton
    Friend WithEvents rb7c4 As System.Windows.Forms.RadioButton
    Friend WithEvents rb7c3 As System.Windows.Forms.RadioButton
    Friend WithEvents gbQ7d As System.Windows.Forms.GroupBox
    Friend WithEvents tblQ7d As System.Windows.Forms.TableLayoutPanel
    Public WithEvents lblQ7d As System.Windows.Forms.Label
    Friend WithEvents rb7d2 As System.Windows.Forms.RadioButton
    Friend WithEvents rb7d1 As System.Windows.Forms.RadioButton
    Friend WithEvents rb7d4 As System.Windows.Forms.RadioButton
    Friend WithEvents rb7d3 As System.Windows.Forms.RadioButton
    Friend WithEvents rb7b5 As System.Windows.Forms.RadioButton
    Friend WithEvents rb7c5 As System.Windows.Forms.RadioButton
    Friend WithEvents rb7d5 As System.Windows.Forms.RadioButton
    Friend WithEvents rb7a5 As System.Windows.Forms.RadioButton
    Public WithEvents gbQ7a As System.Windows.Forms.GroupBox
    Public WithEvents _lblVisu_7 As System.Windows.Forms.Label
    Friend WithEvents pbMode0 As System.Windows.Forms.PictureBox
    'Friend WithEvents AxWindowsMediaPlayerMode0 As AxWMPLib.AxWindowsMediaPlayer
#End Region
End Class