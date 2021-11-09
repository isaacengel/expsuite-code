<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmLatency
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
	Public WithEvents tmrUnload As System.Windows.Forms.Timer
	Public WithEvents txtOffset As System.Windows.Forms.TextBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents lstLin As System.Windows.Forms.ListBox
	Public WithEvents optLin As System.Windows.Forms.RadioButton
	Public WithEvents txtConst As System.Windows.Forms.TextBox
	Public WithEvents optConst As System.Windows.Forms.RadioButton
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLatency))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tmrUnload = New System.Windows.Forms.Timer(Me.components)
        Me.txtOffset = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.lstLin = New System.Windows.Forms.ListBox()
        Me.optLin = New System.Windows.Forms.RadioButton()
        Me.txtConst = New System.Windows.Forms.TextBox()
        Me.optConst = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tmrUnload
        '
        Me.tmrUnload.Interval = 10
        '
        'txtOffset
        '
        Me.txtOffset.AcceptsReturn = True
        Me.txtOffset.BackColor = System.Drawing.SystemColors.Window
        Me.txtOffset.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOffset.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOffset.Location = New System.Drawing.Point(148, 290)
        Me.txtOffset.MaxLength = 0
        Me.txtOffset.Name = "txtOffset"
        Me.txtOffset.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOffset.Size = New System.Drawing.Size(53, 20)
        Me.txtOffset.TabIndex = 7
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(128, 328)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Tag = "Cancel"
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(40, 328)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(73, 25)
        Me.cmdOK.TabIndex = 5
        Me.cmdOK.Tag = "OK"
        Me.cmdOK.Text = "Set"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'lstLin
        '
        Me.lstLin.BackColor = System.Drawing.SystemColors.Window
        Me.lstLin.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstLin.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstLin.Location = New System.Drawing.Point(48, 80)
        Me.lstLin.Name = "lstLin"
        Me.lstLin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstLin.Size = New System.Drawing.Size(153, 199)
        Me.lstLin.TabIndex = 3
        '
        'optLin
        '
        Me.optLin.BackColor = System.Drawing.SystemColors.Control
        Me.optLin.Cursor = System.Windows.Forms.Cursors.Default
        Me.optLin.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optLin.Location = New System.Drawing.Point(23, 51)
        Me.optLin.Name = "optLin"
        Me.optLin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optLin.Size = New System.Drawing.Size(157, 20)
        Me.optLin.TabIndex = 2
        Me.optLin.TabStop = True
        Me.optLin.Text = "copy values from hLIN:"
        Me.optLin.UseVisualStyleBackColor = False
        '
        'txtConst
        '
        Me.txtConst.AcceptsReturn = True
        Me.txtConst.BackColor = System.Drawing.SystemColors.Window
        Me.txtConst.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtConst.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtConst.Location = New System.Drawing.Point(148, 24)
        Me.txtConst.MaxLength = 0
        Me.txtConst.Name = "txtConst"
        Me.txtConst.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtConst.Size = New System.Drawing.Size(53, 20)
        Me.txtConst.TabIndex = 1
        '
        'optConst
        '
        Me.optConst.BackColor = System.Drawing.SystemColors.Control
        Me.optConst.Cursor = System.Windows.Forms.Cursors.Default
        Me.optConst.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optConst.Location = New System.Drawing.Point(23, 24)
        Me.optConst.Name = "optConst"
        Me.optConst.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optConst.Size = New System.Drawing.Size(129, 20)
        Me.optConst.TabIndex = 0
        Me.optConst.TabStop = True
        Me.optConst.Text = "set to constant value:"
        Me.optConst.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(212, 293)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "ms"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(61, 293)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "add offset:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(212, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "ms"
        '
        'frmLatency
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(244, 369)
        Me.Controls.Add(Me.txtOffset)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lstLin)
        Me.Controls.Add(Me.optLin)
        Me.Controls.Add(Me.txtConst)
        Me.Controls.Add(Me.optConst)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLatency"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.Text = "Copy latency to signal settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class