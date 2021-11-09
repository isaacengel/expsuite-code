<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSettingsTrackRange
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
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents txtMax As System.Windows.Forms.TextBox
	Public WithEvents chkMax As System.Windows.Forms.CheckBox
	Public WithEvents txtMin As System.Windows.Forms.TextBox
	Public WithEvents chkMin As System.Windows.Forms.CheckBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.txtMax = New System.Windows.Forms.TextBox()
        Me.chkMax = New System.Windows.Forms.CheckBox()
        Me.txtMin = New System.Windows.Forms.TextBox()
        Me.chkMin = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(112, 92)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(77, 25)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = false
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(20, 92)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(77, 25)
        Me.cmdOK.TabIndex = 4
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = false
        '
        'txtMax
        '
        Me.txtMax.AcceptsReturn = true
        Me.txtMax.BackColor = System.Drawing.SystemColors.Window
        Me.txtMax.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMax.Enabled = false
        Me.txtMax.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMax.Location = New System.Drawing.Point(128, 56)
        Me.txtMax.MaxLength = 0
        Me.txtMax.Name = "txtMax"
        Me.txtMax.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMax.Size = New System.Drawing.Size(53, 20)
        Me.txtMax.TabIndex = 3
        '
        'chkMax
        '
        Me.chkMax.BackColor = System.Drawing.SystemColors.Control
        Me.chkMax.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkMax.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkMax.Location = New System.Drawing.Point(24, 56)
        Me.chkMax.Name = "chkMax"
        Me.chkMax.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkMax.Size = New System.Drawing.Size(133, 21)
        Me.chkMax.TabIndex = 2
        Me.chkMax.Text = "Set Maximum to:"
        Me.chkMax.UseVisualStyleBackColor = false
        '
        'txtMin
        '
        Me.txtMin.AcceptsReturn = true
        Me.txtMin.BackColor = System.Drawing.SystemColors.Window
        Me.txtMin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMin.Enabled = false
        Me.txtMin.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMin.Location = New System.Drawing.Point(128, 28)
        Me.txtMin.MaxLength = 0
        Me.txtMin.Name = "txtMin"
        Me.txtMin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMin.Size = New System.Drawing.Size(53, 20)
        Me.txtMin.TabIndex = 1
        '
        'chkMin
        '
        Me.chkMin.BackColor = System.Drawing.SystemColors.Control
        Me.chkMin.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkMin.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkMin.Location = New System.Drawing.Point(24, 28)
        Me.chkMin.Name = "chkMin"
        Me.chkMin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkMin.Size = New System.Drawing.Size(133, 21)
        Me.chkMin.TabIndex = 0
        Me.chkMin.Text = "Set Minimum to:"
        Me.chkMin.UseVisualStyleBackColor = false
        '
        'frmSettingsTrackRange
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(213, 138)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.txtMax)
        Me.Controls.Add(Me.chkMax)
        Me.Controls.Add(Me.txtMin)
        Me.Controls.Add(Me.chkMin)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmSettingsTrackRange"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = false
        Me.Text = "Track Range of Sensor"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
#End Region 
End Class