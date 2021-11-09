<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmItemListPostfix
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
	Public WithEvents txtPreFileName As System.Windows.Forms.TextBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents chkNewVersion As System.Windows.Forms.CheckBox
	Public WithEvents txtPostFix As System.Windows.Forms.TextBox
	Public WithEvents _optPostFix_4 As System.Windows.Forms.RadioButton
	Public WithEvents _optPostFix_3 As System.Windows.Forms.RadioButton
	Public WithEvents _optPostFix_2 As System.Windows.Forms.RadioButton
	Public WithEvents _optPostFix_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optPostFix_0 As System.Windows.Forms.RadioButton
	Public WithEvents lblPreDots As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents _Line1_1 As System.Windows.Forms.Label
	Public WithEvents _Line1_0 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents optPostFix As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtPreFileName = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.chkNewVersion = New System.Windows.Forms.CheckBox()
        Me.txtPostFix = New System.Windows.Forms.TextBox()
        Me._optPostFix_4 = New System.Windows.Forms.RadioButton()
        Me._optPostFix_3 = New System.Windows.Forms.RadioButton()
        Me._optPostFix_2 = New System.Windows.Forms.RadioButton()
        Me._optPostFix_1 = New System.Windows.Forms.RadioButton()
        Me._optPostFix_0 = New System.Windows.Forms.RadioButton()
        Me.lblPreDots = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me._Line1_1 = New System.Windows.Forms.Label()
        Me._Line1_0 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.optPostFix = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(Me.components)
        CType(Me.optPostFix, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPreFileName
        '
        Me.txtPreFileName.AcceptsReturn = True
        Me.txtPreFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPreFileName.BackColor = System.Drawing.SystemColors.Window
        Me.txtPreFileName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPreFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPreFileName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPreFileName.Location = New System.Drawing.Point(36, 252)
        Me.txtPreFileName.MaxLength = 0
        Me.txtPreFileName.Name = "txtPreFileName"
        Me.txtPreFileName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPreFileName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtPreFileName.Size = New System.Drawing.Size(269, 20)
        Me.txtPreFileName.TabIndex = 12
        Me.txtPreFileName.Text = "Text1"
        Me.txtPreFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPreFileName.WordWrap = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(20, 296)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Tag = "Cancel"
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOK
        '
        Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(252, 296)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(73, 25)
        Me.cmdOK.TabIndex = 8
        Me.cmdOK.Tag = "OK"
        Me.cmdOK.Text = "&Next"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'chkNewVersion
        '
        Me.chkNewVersion.BackColor = System.Drawing.SystemColors.Control
        Me.chkNewVersion.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkNewVersion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkNewVersion.Location = New System.Drawing.Point(20, 176)
        Me.chkNewVersion.Name = "chkNewVersion"
        Me.chkNewVersion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkNewVersion.Size = New System.Drawing.Size(246, 19)
        Me.chkNewVersion.TabIndex = 7
        Me.chkNewVersion.Text = "Add latest version number"
        Me.chkNewVersion.UseVisualStyleBackColor = False
        '
        'txtPostFix
        '
        Me.txtPostFix.AcceptsReturn = True
        Me.txtPostFix.BackColor = System.Drawing.SystemColors.Window
        Me.txtPostFix.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPostFix.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPostFix.Location = New System.Drawing.Point(155, 134)
        Me.txtPostFix.MaxLength = 0
        Me.txtPostFix.Name = "txtPostFix"
        Me.txtPostFix.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPostFix.Size = New System.Drawing.Size(69, 20)
        Me.txtPostFix.TabIndex = 6
        '
        '_optPostFix_4
        '
        Me._optPostFix_4.BackColor = System.Drawing.SystemColors.Control
        Me._optPostFix_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._optPostFix_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optPostFix.SetIndex(Me._optPostFix_4, CType(4, Short))
        Me._optPostFix_4.Location = New System.Drawing.Point(60, 135)
        Me._optPostFix_4.Name = "_optPostFix_4"
        Me._optPostFix_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optPostFix_4.Size = New System.Drawing.Size(86, 16)
        Me._optPostFix_4.TabIndex = 5
        Me._optPostFix_4.TabStop = True
        Me._optPostFix_4.Text = "user postfix:"
        Me._optPostFix_4.UseVisualStyleBackColor = False
        '
        '_optPostFix_3
        '
        Me._optPostFix_3.BackColor = System.Drawing.SystemColors.Control
        Me._optPostFix_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._optPostFix_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optPostFix.SetIndex(Me._optPostFix_3, CType(3, Short))
        Me._optPostFix_3.Location = New System.Drawing.Point(60, 111)
        Me._optPostFix_3.Name = "_optPostFix_3"
        Me._optPostFix_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optPostFix_3.Size = New System.Drawing.Size(221, 24)
        Me._optPostFix_3.TabIndex = 4
        Me._optPostFix_3.TabStop = True
        Me._optPostFix_3.Text = "containing response data ( _response )"
        Me._optPostFix_3.UseVisualStyleBackColor = False
        '
        '_optPostFix_2
        '
        Me._optPostFix_2.BackColor = System.Drawing.SystemColors.Control
        Me._optPostFix_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._optPostFix_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optPostFix.SetIndex(Me._optPostFix_2, CType(2, Short))
        Me._optPostFix_2.Location = New System.Drawing.Point(60, 91)
        Me._optPostFix_2.Name = "_optPostFix_2"
        Me._optPostFix_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optPostFix_2.Size = New System.Drawing.Size(173, 21)
        Me._optPostFix_2.TabIndex = 3
        Me._optPostFix_2.TabStop = True
        Me._optPostFix_2.Text = "begin of experiment ( _begin )"
        Me._optPostFix_2.UseVisualStyleBackColor = False
        '
        '_optPostFix_1
        '
        Me._optPostFix_1.BackColor = System.Drawing.SystemColors.Control
        Me._optPostFix_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._optPostFix_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optPostFix.SetIndex(Me._optPostFix_1, CType(1, Short))
        Me._optPostFix_1.Location = New System.Drawing.Point(60, 71)
        Me._optPostFix_1.Name = "_optPostFix_1"
        Me._optPostFix_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optPostFix_1.Size = New System.Drawing.Size(153, 21)
        Me._optPostFix_1.TabIndex = 2
        Me._optPostFix_1.TabStop = True
        Me._optPostFix_1.Text = "created list ( _fresh )"
        Me._optPostFix_1.UseVisualStyleBackColor = False
        '
        '_optPostFix_0
        '
        Me._optPostFix_0.BackColor = System.Drawing.SystemColors.Control
        Me._optPostFix_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._optPostFix_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optPostFix.SetIndex(Me._optPostFix_0, CType(0, Short))
        Me._optPostFix_0.Location = New System.Drawing.Point(60, 51)
        Me._optPostFix_0.Name = "_optPostFix_0"
        Me._optPostFix_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optPostFix_0.Size = New System.Drawing.Size(153, 21)
        Me._optPostFix_0.TabIndex = 0
        Me._optPostFix_0.TabStop = True
        Me._optPostFix_0.Text = "nothing"
        Me._optPostFix_0.UseVisualStyleBackColor = False
        '
        'lblPreDots
        '
        Me.lblPreDots.BackColor = System.Drawing.SystemColors.Control
        Me.lblPreDots.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPreDots.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreDots.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPreDots.Location = New System.Drawing.Point(17, 255)
        Me.lblPreDots.Name = "lblPreDots"
        Me.lblPreDots.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPreDots.Size = New System.Drawing.Size(21, 16)
        Me.lblPreDots.TabIndex = 14
        Me.lblPreDots.Text = "..."
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(143, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(12, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "( _"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(20, 224)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(239, 15)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Preliminary File Name:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(227, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = ")"
        '
        '_Line1_1
        '
        Me._Line1_1.BackColor = System.Drawing.SystemColors.Window
        Me._Line1_1.Location = New System.Drawing.Point(8, 213)
        Me._Line1_1.Name = "_Line1_1"
        Me._Line1_1.Size = New System.Drawing.Size(328, 1)
        Me._Line1_1.TabIndex = 15
        '
        '_Line1_0
        '
        Me._Line1_0.BackColor = System.Drawing.SystemColors.WindowText
        Me._Line1_0.Location = New System.Drawing.Point(8, 212)
        Me._Line1_0.Name = "_Line1_0"
        Me._Line1_0.Size = New System.Drawing.Size(328, 1)
        Me._Line1_0.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(17, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(168, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Mark the item list as:"
        '
        'optPostFix
        '
        '
        'frmItemListPostfix
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(344, 341)
        Me.Controls.Add(Me.txtPreFileName)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.chkNewVersion)
        Me.Controls.Add(Me.txtPostFix)
        Me.Controls.Add(Me._optPostFix_4)
        Me.Controls.Add(Me._optPostFix_3)
        Me.Controls.Add(Me._optPostFix_2)
        Me.Controls.Add(Me._optPostFix_1)
        Me.Controls.Add(Me._optPostFix_0)
        Me.Controls.Add(Me.lblPreDots)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me._Line1_1)
        Me.Controls.Add(Me._Line1_0)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(352, 365)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(352, 365)
        Me.Name = "frmItemListPostfix"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Save Item List as..."
        CType(Me.optPostFix, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class