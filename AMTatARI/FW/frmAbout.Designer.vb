<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmAbout
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
    Public WithEvents picIcon As System.Windows.Forms.PictureBox
	Public WithEvents cmdOK As System.Windows.Forms.Button
    Public WithEvents lblVersionX As System.Windows.Forms.Label
	Public WithEvents lblTitle As System.Windows.Forms.Label
	Public WithEvents _Line1_1 As System.Windows.Forms.Label
    Public WithEvents lblDescr As System.Windows.Forms.Label
    Public WithEvents lblExpSuite As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.lblVersionX = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me._Line1_1 = New System.Windows.Forms.Label()
        Me.lblDescr = New System.Windows.Forms.Label()
        Me.lblExpSuite = New System.Windows.Forms.Label()
        Me.lblLicense = New System.Windows.Forms.LinkLabel()
        Me.lblCitation = New System.Windows.Forms.LinkLabel()
        Me.lblAuthorPiotr = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblARI = New System.Windows.Forms.LinkLabel()
        Me.lblAAS = New System.Windows.Forms.LinkLabel()
        Me.lblCompany = New System.Windows.Forms.Label()
        Me.lblCopyright = New System.Windows.Forms.Label()
        Me.lblBugFeatureReport = New System.Windows.Forms.LinkLabel()
        Me.lblAuthorMiho = New System.Windows.Forms.LinkLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picIcon
        '
        Me.picIcon.Cursor = System.Windows.Forms.Cursors.Default
        Me.picIcon.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picIcon.Image = CType(resources.GetObject("picIcon.Image"), System.Drawing.Image)
        Me.picIcon.Location = New System.Drawing.Point(19, 16)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picIcon.Size = New System.Drawing.Size(48, 48)
        Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picIcon.TabIndex = 2
        Me.picIcon.TabStop = False
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(417, 295)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(104, 27)
        Me.cmdOK.TabIndex = 0
        Me.cmdOK.Tag = "OK"
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'lblVersionX
        '
        Me.lblVersionX.BackColor = System.Drawing.SystemColors.Control
        Me.lblVersionX.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblVersionX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblVersionX.Location = New System.Drawing.Point(83, 90)
        Me.lblVersionX.Name = "lblVersionX"
        Me.lblVersionX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVersionX.Size = New System.Drawing.Size(260, 41)
        Me.lblVersionX.TabIndex = 6
        Me.lblVersionX.Tag = "Version"
        Me.lblVersionX.Text = "Version"
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.SystemColors.Control
        Me.lblTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(81, 24)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitle.Size = New System.Drawing.Size(362, 32)
        Me.lblTitle.TabIndex = 5
        Me.lblTitle.Tag = "Application Title"
        Me.lblTitle.Text = "Application Title"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_Line1_1
        '
        Me._Line1_1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me._Line1_1.Location = New System.Drawing.Point(3, 179)
        Me._Line1_1.Name = "_Line1_1"
        Me._Line1_1.Size = New System.Drawing.Size(527, 1)
        Me._Line1_1.TabIndex = 7
        '
        'lblDescr
        '
        Me.lblDescr.BackColor = System.Drawing.SystemColors.Control
        Me.lblDescr.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDescr.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDescr.Location = New System.Drawing.Point(83, 75)
        Me.lblDescr.Name = "lblDescr"
        Me.lblDescr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDescr.Size = New System.Drawing.Size(362, 15)
        Me.lblDescr.TabIndex = 4
        Me.lblDescr.Tag = "Version"
        Me.lblDescr.Text = "Description"
        '
        'lblExpSuite
        '
        Me.lblExpSuite.AutoSize = True
        Me.lblExpSuite.BackColor = System.Drawing.SystemColors.Control
        Me.lblExpSuite.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblExpSuite.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExpSuite.ForeColor = System.Drawing.Color.Black
        Me.lblExpSuite.Location = New System.Drawing.Point(70, 201)
        Me.lblExpSuite.Name = "lblExpSuite"
        Me.lblExpSuite.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblExpSuite.Size = New System.Drawing.Size(113, 13)
        Me.lblExpSuite.TabIndex = 3
        Me.lblExpSuite.Tag = ""
        Me.lblExpSuite.Text = "ExpSuite FW 0.0.0"
        '
        'lblLicense
        '
        Me.lblLicense.AutoSize = True
        Me.lblLicense.LinkArea = New System.Windows.Forms.LinkArea(36, 4)
        Me.lblLicense.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lblLicense.Location = New System.Drawing.Point(17, 261)
        Me.lblLicense.Name = "lblLicense"
        Me.lblLicense.Size = New System.Drawing.Size(214, 17)
        Me.lblLicense.TabIndex = 10
        Me.lblLicense.TabStop = True
        Me.lblLicense.Text = "This software is licensed under the EUPL."
        Me.lblLicense.UseCompatibleTextRendering = True
        '
        'lblCitation
        '
        Me.lblCitation.AutoSize = True
        Me.lblCitation.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lblCitation.Location = New System.Drawing.Point(228, 261)
        Me.lblCitation.Name = "lblCitation"
        Me.lblCitation.Size = New System.Drawing.Size(81, 17)
        Me.lblCitation.TabIndex = 11
        Me.lblCitation.TabStop = True
        Me.lblCitation.Text = "How to cite us?"
        Me.lblCitation.UseCompatibleTextRendering = True
        '
        'lblAuthorPiotr
        '
        Me.lblAuthorPiotr.AutoSize = True
        Me.lblAuthorPiotr.LinkArea = New System.Windows.Forms.LinkArea(3, 12)
        Me.lblAuthorPiotr.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lblAuthorPiotr.Location = New System.Drawing.Point(17, 221)
        Me.lblAuthorPiotr.Name = "lblAuthorPiotr"
        Me.lblAuthorPiotr.Size = New System.Drawing.Size(107, 17)
        Me.lblAuthorPiotr.TabIndex = 13
        Me.lblAuthorPiotr.TabStop = True
        Me.lblAuthorPiotr.Text = "by Piotr Majdak and "
        Me.ToolTip1.SetToolTip(Me.lblAuthorPiotr, "piotr@majdak.com")
        Me.lblAuthorPiotr.UseCompatibleTextRendering = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 201)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "based on"
        '
        'lblARI
        '
        Me.lblARI.AutoSize = True
        Me.lblARI.LinkArea = New System.Windows.Forms.LinkArea(0, 28)
        Me.lblARI.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lblARI.Location = New System.Drawing.Point(31, 236)
        Me.lblARI.Name = "lblARI"
        Me.lblARI.Size = New System.Drawing.Size(154, 17)
        Me.lblARI.TabIndex = 15
        Me.lblARI.TabStop = True
        Me.lblARI.Text = "Acoustics Research Institute -"
        Me.ToolTip1.SetToolTip(Me.lblARI, "https://www.oeaw.ac.at/isf/")
        Me.lblARI.UseCompatibleTextRendering = True
        '
        'lblAAS
        '
        Me.lblAAS.AutoSize = True
        Me.lblAAS.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lblAAS.Location = New System.Drawing.Point(183, 236)
        Me.lblAAS.Name = "lblAAS"
        Me.lblAAS.Size = New System.Drawing.Size(158, 17)
        Me.lblAAS.TabIndex = 16
        Me.lblAAS.TabStop = True
        Me.lblAAS.Text = "Austrian Academy of Sciences"
        Me.ToolTip1.SetToolTip(Me.lblAAS, "http://www.oeaw.ac.at")
        Me.lblAAS.UseCompatibleTextRendering = True
        '
        'lblCompany
        '
        Me.lblCompany.AutoSize = True
        Me.lblCompany.Location = New System.Drawing.Point(83, 130)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(51, 13)
        Me.lblCompany.TabIndex = 17
        Me.lblCompany.Text = "Company"
        '
        'lblCopyright
        '
        Me.lblCopyright.AutoSize = True
        Me.lblCopyright.Location = New System.Drawing.Point(83, 145)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(66, 13)
        Me.lblCopyright.TabIndex = 18
        Me.lblCopyright.Text = "(c) Copyright"
        '
        'lblBugFeatureReport
        '
        Me.lblBugFeatureReport.LinkArea = New System.Windows.Forms.LinkArea(50, 40)
        Me.lblBugFeatureReport.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lblBugFeatureReport.Location = New System.Drawing.Point(17, 286)
        Me.lblBugFeatureReport.Name = "lblBugFeatureReport"
        Me.lblBugFeatureReport.Size = New System.Drawing.Size(292, 35)
        Me.lblBugFeatureReport.TabIndex = 20
        Me.lblBugFeatureReport.TabStop = True
        Me.lblBugFeatureReport.Text = "Found a bug? Request a feature? Please report at: http://sourceforge.net/projects" & _
    "/expsuite"
        Me.lblBugFeatureReport.UseCompatibleTextRendering = True
        '
        'lblAuthorMiho
        '
        Me.lblAuthorMiho.AutoSize = True
        Me.lblAuthorMiho.LinkArea = New System.Windows.Forms.LinkArea(0, 15)
        Me.lblAuthorMiho.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lblAuthorMiho.Location = New System.Drawing.Point(118, 221)
        Me.lblAuthorMiho.Name = "lblAuthorMiho"
        Me.lblAuthorMiho.Size = New System.Drawing.Size(85, 17)
        Me.lblAuthorMiho.TabIndex = 21
        Me.lblAuthorMiho.TabStop = True
        Me.lblAuthorMiho.Text = "Michael Mihocic"
        Me.ToolTip1.SetToolTip(Me.lblAuthorMiho, "michael.mihocic@oeaw.ac.at")
        Me.lblAuthorMiho.UseCompatibleTextRendering = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(336, 184)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PictureBox1.Size = New System.Drawing.Size(85, 80)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 22
        Me.PictureBox1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox1, "Double-click to open website of Acoustics Research Institute")
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(422, 181)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PictureBox2.Size = New System.Drawing.Size(110, 86)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 23
        Me.PictureBox2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox2, "Double-click to open website of Austrian Academy of Sciences")
        '
        'frmAbout
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdOK
        Me.ClientSize = New System.Drawing.Size(533, 334)
        Me.Controls.Add(Me.lblARI)
        Me.Controls.Add(Me.lblAAS)
        Me.Controls.Add(Me.lblAuthorMiho)
        Me.Controls.Add(Me.lblCopyright)
        Me.Controls.Add(Me.lblCompany)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblAuthorPiotr)
        Me.Controls.Add(Me.lblCitation)
        Me.Controls.Add(Me.lblLicense)
        Me.Controls.Add(Me.picIcon)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lblVersionX)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me._Line1_1)
        Me.Controls.Add(Me.lblDescr)
        Me.Controls.Add(Me.lblExpSuite)
        Me.Controls.Add(Me.lblBugFeatureReport)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(309, 220)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Tag = "About this Application"
        Me.Text = "About this Application"
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblLicense As System.Windows.Forms.LinkLabel
    Friend WithEvents lblCitation As System.Windows.Forms.LinkLabel
    Friend WithEvents lblAuthorPiotr As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblARI As System.Windows.Forms.LinkLabel
    Friend WithEvents lblAAS As System.Windows.Forms.LinkLabel
    Friend WithEvents lblCompany As System.Windows.Forms.Label
    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    Friend WithEvents lblBugFeatureReport As System.Windows.Forms.LinkLabel
    Friend WithEvents lblAuthorMiho As System.Windows.Forms.LinkLabel
    Public WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Public WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
#End Region
End Class