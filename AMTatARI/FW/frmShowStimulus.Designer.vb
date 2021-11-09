<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmShowStimulus
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
	Public WithEvents txtParameter As System.Windows.Forms.TextBox
	Public WithEvents txtAxes As System.Windows.Forms.TextBox
	Public WithEvents cmbShowStimY As System.Windows.Forms.ComboBox
	Public WithEvents cmbShowStimX As System.Windows.Forms.ComboBox
	Public WithEvents cmbShowStimDomain As System.Windows.Forms.ComboBox
	Public WithEvents lblAxes As System.Windows.Forms.Label
	Public WithEvents Label14 As System.Windows.Forms.Label
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents cmbMode As System.Windows.Forms.ComboBox
	Public WithEvents optVectorMode As System.Windows.Forms.RadioButton
	Public WithEvents optMatrixMode As System.Windows.Forms.RadioButton
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents lblParameter As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtAxes = New System.Windows.Forms.TextBox
        Me.lblAxes = New System.Windows.Forms.Label
        Me.txtParameter = New System.Windows.Forms.TextBox
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.lblScaleX = New System.Windows.Forms.Label
        Me.lblScaleY = New System.Windows.Forms.Label
        Me.lblDomain = New System.Windows.Forms.Label
        Me.cmbShowStimY = New System.Windows.Forms.ComboBox
        Me.cmbShowStimX = New System.Windows.Forms.ComboBox
        Me.cmbShowStimDomain = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.lblPlotAs = New System.Windows.Forms.Label
        Me.cmbMode = New System.Windows.Forms.ComboBox
        Me.optVectorMode = New System.Windows.Forms.RadioButton
        Me.optMatrixMode = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.lblParameter = New System.Windows.Forms.Label
        Me.lblMatlabFlags = New System.Windows.Forms.Label
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtAxes
        '
        Me.txtAxes.AcceptsReturn = True
        Me.txtAxes.BackColor = System.Drawing.SystemColors.Window
        Me.txtAxes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAxes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAxes.Location = New System.Drawing.Point(128, 112)
        Me.txtAxes.MaxLength = 0
        Me.txtAxes.Name = "txtAxes"
        Me.txtAxes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAxes.Size = New System.Drawing.Size(149, 20)
        Me.txtAxes.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.txtAxes, "Xmin Xmax Ymin Ymax")
        '
        'lblAxes
        '
        Me.lblAxes.BackColor = System.Drawing.SystemColors.Control
        Me.lblAxes.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAxes.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAxes.Location = New System.Drawing.Point(15, 115)
        Me.lblAxes.Name = "lblAxes"
        Me.lblAxes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAxes.Size = New System.Drawing.Size(118, 17)
        Me.lblAxes.TabIndex = 15
        Me.lblAxes.Text = "Scale axes (optional):"
        Me.ToolTip1.SetToolTip(Me.lblAxes, "Xmin Xmax Ymin Ymax")
        '
        'txtParameter
        '
        Me.txtParameter.AcceptsReturn = True
        Me.txtParameter.BackColor = System.Drawing.SystemColors.Window
        Me.txtParameter.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtParameter.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtParameter.Location = New System.Drawing.Point(140, 264)
        Me.txtParameter.MaxLength = 0
        Me.txtParameter.Name = "txtParameter"
        Me.txtParameter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtParameter.Size = New System.Drawing.Size(149, 20)
        Me.txtParameter.TabIndex = 17
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.lblScaleX)
        Me.Frame2.Controls.Add(Me.lblScaleY)
        Me.Frame2.Controls.Add(Me.lblDomain)
        Me.Frame2.Controls.Add(Me.txtAxes)
        Me.Frame2.Controls.Add(Me.cmbShowStimY)
        Me.Frame2.Controls.Add(Me.cmbShowStimX)
        Me.Frame2.Controls.Add(Me.cmbShowStimDomain)
        Me.Frame2.Controls.Add(Me.lblAxes)
        Me.Frame2.Controls.Add(Me.Label14)
        Me.Frame2.Controls.Add(Me.Label13)
        Me.Frame2.Controls.Add(Me.Label9)
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(12, 112)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(330, 145)
        Me.Frame2.TabIndex = 7
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Scaling:"
        '
        'lblScaleX
        '
        Me.lblScaleX.AutoSize = True
        Me.lblScaleX.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblScaleX.Location = New System.Drawing.Point(283, 59)
        Me.lblScaleX.Name = "lblScaleX"
        Me.lblScaleX.Size = New System.Drawing.Size(51, 13)
        Me.lblScaleX.TabIndex = 22
        Me.lblScaleX.Text = "lblScaleX"
        Me.lblScaleX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblScaleY
        '
        Me.lblScaleY.AutoSize = True
        Me.lblScaleY.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblScaleY.Location = New System.Drawing.Point(283, 87)
        Me.lblScaleY.Name = "lblScaleY"
        Me.lblScaleY.Size = New System.Drawing.Size(51, 13)
        Me.lblScaleY.TabIndex = 21
        Me.lblScaleY.Text = "lblScaleY"
        Me.lblScaleY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDomain
        '
        Me.lblDomain.AutoSize = True
        Me.lblDomain.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblDomain.Location = New System.Drawing.Point(283, 31)
        Me.lblDomain.Name = "lblDomain"
        Me.lblDomain.Size = New System.Drawing.Size(53, 13)
        Me.lblDomain.TabIndex = 20
        Me.lblDomain.Text = "lblDomain"
        Me.lblDomain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbShowStimY
        '
        Me.cmbShowStimY.BackColor = System.Drawing.SystemColors.Window
        Me.cmbShowStimY.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbShowStimY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbShowStimY.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbShowStimY.Location = New System.Drawing.Point(128, 84)
        Me.cmbShowStimY.Name = "cmbShowStimY"
        Me.cmbShowStimY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbShowStimY.Size = New System.Drawing.Size(149, 21)
        Me.cmbShowStimY.TabIndex = 10
        '
        'cmbShowStimX
        '
        Me.cmbShowStimX.BackColor = System.Drawing.SystemColors.Window
        Me.cmbShowStimX.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbShowStimX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbShowStimX.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbShowStimX.Location = New System.Drawing.Point(128, 56)
        Me.cmbShowStimX.Name = "cmbShowStimX"
        Me.cmbShowStimX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbShowStimX.Size = New System.Drawing.Size(149, 21)
        Me.cmbShowStimX.TabIndex = 9
        '
        'cmbShowStimDomain
        '
        Me.cmbShowStimDomain.BackColor = System.Drawing.SystemColors.Window
        Me.cmbShowStimDomain.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbShowStimDomain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbShowStimDomain.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbShowStimDomain.Location = New System.Drawing.Point(128, 28)
        Me.cmbShowStimDomain.Name = "cmbShowStimDomain"
        Me.cmbShowStimDomain.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbShowStimDomain.Size = New System.Drawing.Size(149, 21)
        Me.cmbShowStimDomain.TabIndex = 8
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(47, 87)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(73, 13)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Scale data to:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(40, 59)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(80, 13)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Scale X axis to:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(11, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(108, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Set Domain of X axis:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.lblPlotAs)
        Me.Frame1.Controls.Add(Me.cmbMode)
        Me.Frame1.Controls.Add(Me.optVectorMode)
        Me.Frame1.Controls.Add(Me.optMatrixMode)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(12, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(330, 97)
        Me.Frame1.TabIndex = 2
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Plot Mode:"
        '
        'lblPlotAs
        '
        Me.lblPlotAs.AutoSize = True
        Me.lblPlotAs.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblPlotAs.Location = New System.Drawing.Point(283, 63)
        Me.lblPlotAs.Name = "lblPlotAs"
        Me.lblPlotAs.Size = New System.Drawing.Size(47, 13)
        Me.lblPlotAs.TabIndex = 19
        Me.lblPlotAs.Text = "lblPlotAs"
        Me.lblPlotAs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbMode
        '
        Me.cmbMode.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMode.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbMode.Location = New System.Drawing.Point(108, 60)
        Me.cmbMode.Name = "cmbMode"
        Me.cmbMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbMode.Size = New System.Drawing.Size(149, 21)
        Me.cmbMode.TabIndex = 5
        '
        'optVectorMode
        '
        Me.optVectorMode.BackColor = System.Drawing.SystemColors.Control
        Me.optVectorMode.Cursor = System.Windows.Forms.Cursors.Default
        Me.optVectorMode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optVectorMode.Location = New System.Drawing.Point(24, 20)
        Me.optVectorMode.Name = "optVectorMode"
        Me.optVectorMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optVectorMode.Size = New System.Drawing.Size(197, 17)
        Me.optVectorMode.TabIndex = 4
        Me.optVectorMode.TabStop = True
        Me.optVectorMode.Text = "Vector mode (2D plots)"
        Me.optVectorMode.UseVisualStyleBackColor = False
        '
        'optMatrixMode
        '
        Me.optMatrixMode.BackColor = System.Drawing.SystemColors.Control
        Me.optMatrixMode.Cursor = System.Windows.Forms.Cursors.Default
        Me.optMatrixMode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optMatrixMode.Location = New System.Drawing.Point(24, 36)
        Me.optMatrixMode.Name = "optMatrixMode"
        Me.optMatrixMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optMatrixMode.Size = New System.Drawing.Size(161, 21)
        Me.optMatrixMode.TabIndex = 3
        Me.optMatrixMode.TabStop = True
        Me.optMatrixMode.Text = "Matrix mode (3D plots)"
        Me.optMatrixMode.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(64, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Plot as:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(216, 301)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Tag = "Cancel"
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(135, 301)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(73, 25)
        Me.cmdOK.TabIndex = 0
        Me.cmdOK.Tag = "OK"
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'lblParameter
        '
        Me.lblParameter.BackColor = System.Drawing.SystemColors.Control
        Me.lblParameter.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblParameter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblParameter.Location = New System.Drawing.Point(11, 268)
        Me.lblParameter.Name = "lblParameter"
        Me.lblParameter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblParameter.Size = New System.Drawing.Size(120, 16)
        Me.lblParameter.TabIndex = 16
        Me.lblParameter.Text = "Optional Parameter(s):"
        Me.lblParameter.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMatlabFlags
        '
        Me.lblMatlabFlags.AutoSize = True
        Me.lblMatlabFlags.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblMatlabFlags.Location = New System.Drawing.Point(23, 307)
        Me.lblMatlabFlags.Name = "lblMatlabFlags"
        Me.lblMatlabFlags.Size = New System.Drawing.Size(74, 13)
        Me.lblMatlabFlags.TabIndex = 18
        Me.lblMatlabFlags.Text = "lblMatlabFlags"
        '
        'frmShowStimulus
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(355, 346)
        Me.Controls.Add(Me.lblMatlabFlags)
        Me.Controls.Add(Me.txtParameter)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lblParameter)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmShowStimulus"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.Text = "Show Stimulus"
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMatlabFlags As System.Windows.Forms.Label
    Friend WithEvents lblScaleX As System.Windows.Forms.Label
    Friend WithEvents lblScaleY As System.Windows.Forms.Label
    Friend WithEvents lblDomain As System.Windows.Forms.Label
    Friend WithEvents lblPlotAs As System.Windows.Forms.Label
#End Region 
End Class