<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlotTOA
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlotTOA))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblPlotAs = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.txtRecChannel = New System.Windows.Forms.TextBox()
        Me.lblPlotMode = New System.Windows.Forms.Label()
        Me.cmbMode = New System.Windows.Forms.ComboBox()
        Me.optGeodeticMode = New System.Windows.Forms.RadioButton()
        Me.optHorizontalPolarMode = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.cmdFilterHorizontal = New System.Windows.Forms.Button()
        Me.Frame3 = New System.Windows.Forms.GroupBox()
        Me.cmdFilter0and45 = New System.Windows.Forms.Button()
        Me.cmdFilter00 = New System.Windows.Forms.Button()
        Me.cmdFilterItem1 = New System.Windows.Forms.Button()
        Me.cmdFilterAll = New System.Windows.Forms.Button()
        Me.cmdFilterMedian = New System.Windows.Forms.Button()
        Me.lblMatlabFlags = New System.Windows.Forms.Label()
        Me.Frame1.SuspendLayout()
        Me.Frame3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblPlotAs
        '
        Me.lblPlotAs.AutoSize = True
        Me.lblPlotAs.BackColor = System.Drawing.SystemColors.Control
        Me.lblPlotAs.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPlotAs.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblPlotAs.Location = New System.Drawing.Point(303, 25)
        Me.lblPlotAs.Name = "lblPlotAs"
        Me.lblPlotAs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPlotAs.Size = New System.Drawing.Size(47, 13)
        Me.lblPlotAs.TabIndex = 28
        Me.lblPlotAs.Text = "lblPlotAs"
        Me.lblPlotAs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(15, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(127, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Record channels:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(15, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(127, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Data Filter:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.txtRecChannel)
        Me.Frame1.Controls.Add(Me.Label4)
        Me.Frame1.Controls.Add(Me.lblPlotMode)
        Me.Frame1.Controls.Add(Me.lblPlotAs)
        Me.Frame1.Controls.Add(Me.cmbMode)
        Me.Frame1.Controls.Add(Me.optGeodeticMode)
        Me.Frame1.Controls.Add(Me.optHorizontalPolarMode)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(12, 4)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(370, 127)
        Me.Frame1.TabIndex = 30
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Plot Mode:"
        '
        'txtRecChannel
        '
        Me.txtRecChannel.AcceptsReturn = True
        Me.txtRecChannel.BackColor = System.Drawing.SystemColors.Window
        Me.txtRecChannel.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRecChannel.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRecChannel.Location = New System.Drawing.Point(148, 93)
        Me.txtRecChannel.MaxLength = 0
        Me.txtRecChannel.Name = "txtRecChannel"
        Me.txtRecChannel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRecChannel.Size = New System.Drawing.Size(49, 20)
        Me.txtRecChannel.TabIndex = 25
        Me.txtRecChannel.Text = "1"
        '
        'lblPlotMode
        '
        Me.lblPlotMode.AutoSize = True
        Me.lblPlotMode.BackColor = System.Drawing.SystemColors.Control
        Me.lblPlotMode.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPlotMode.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblPlotMode.Location = New System.Drawing.Point(303, 57)
        Me.lblPlotMode.Name = "lblPlotMode"
        Me.lblPlotMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPlotMode.Size = New System.Drawing.Size(62, 13)
        Me.lblPlotMode.TabIndex = 29
        Me.lblPlotMode.Text = "lblPlotMode"
        Me.lblPlotMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbMode
        '
        Me.cmbMode.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMode.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbMode.Location = New System.Drawing.Point(148, 20)
        Me.cmbMode.Name = "cmbMode"
        Me.cmbMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbMode.Size = New System.Drawing.Size(149, 21)
        Me.cmbMode.TabIndex = 5
        '
        'optGeodeticMode
        '
        Me.optGeodeticMode.BackColor = System.Drawing.SystemColors.Control
        Me.optGeodeticMode.Cursor = System.Windows.Forms.Cursors.Default
        Me.optGeodeticMode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optGeodeticMode.Location = New System.Drawing.Point(24, 45)
        Me.optGeodeticMode.Name = "optGeodeticMode"
        Me.optGeodeticMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optGeodeticMode.Size = New System.Drawing.Size(300, 17)
        Me.optGeodeticMode.TabIndex = 4
        Me.optGeodeticMode.TabStop = True
        Me.optGeodeticMode.Text = "Geodetic Mode (Azi, Ele)"
        Me.optGeodeticMode.UseVisualStyleBackColor = False
        '
        'optHorizontalPolarMode
        '
        Me.optHorizontalPolarMode.BackColor = System.Drawing.SystemColors.Control
        Me.optHorizontalPolarMode.Cursor = System.Windows.Forms.Cursors.Default
        Me.optHorizontalPolarMode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optHorizontalPolarMode.Location = New System.Drawing.Point(24, 61)
        Me.optHorizontalPolarMode.Name = "optHorizontalPolarMode"
        Me.optHorizontalPolarMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optHorizontalPolarMode.Size = New System.Drawing.Size(284, 21)
        Me.optHorizontalPolarMode.TabIndex = 3
        Me.optHorizontalPolarMode.TabStop = True
        Me.optHorizontalPolarMode.Text = "Horizontal Polar Mode (Lat, Pol)"
        Me.optHorizontalPolarMode.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(15, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(127, 13)
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
        Me.cmdCancel.Location = New System.Drawing.Point(201, 165)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(105, 21)
        Me.cmdCancel.TabIndex = 29
        Me.cmdCancel.Tag = "Cancel"
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(87, 143)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(105, 43)
        Me.cmdOK.TabIndex = 28
        Me.cmdOK.Tag = "OK"
        Me.cmdOK.Text = "Plot TOA"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'txtFilter
        '
        Me.txtFilter.AcceptsReturn = True
        Me.txtFilter.BackColor = System.Drawing.SystemColors.Control
        Me.txtFilter.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFilter.Enabled = False
        Me.txtFilter.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFilter.Location = New System.Drawing.Point(148, 48)
        Me.txtFilter.MaxLength = 0
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFilter.Size = New System.Drawing.Size(215, 20)
        Me.txtFilter.TabIndex = 17
        Me.txtFilter.Text = ":"
        '
        'cmdFilterHorizontal
        '
        Me.cmdFilterHorizontal.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFilterHorizontal.Enabled = False
        Me.cmdFilterHorizontal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFilterHorizontal.Location = New System.Drawing.Point(148, 74)
        Me.cmdFilterHorizontal.Name = "cmdFilterHorizontal"
        Me.cmdFilterHorizontal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFilterHorizontal.Size = New System.Drawing.Size(85, 22)
        Me.cmdFilterHorizontal.TabIndex = 18
        Me.cmdFilterHorizontal.Text = "Horizontal"
        Me.cmdFilterHorizontal.UseVisualStyleBackColor = False
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me.cmdFilter0and45)
        Me.Frame3.Controls.Add(Me.cmdFilter00)
        Me.Frame3.Controls.Add(Me.cmdFilterItem1)
        Me.Frame3.Controls.Add(Me.cmdFilterAll)
        Me.Frame3.Controls.Add(Me.cmdFilterMedian)
        Me.Frame3.Controls.Add(Me.txtFilter)
        Me.Frame3.Controls.Add(Me.Label3)
        Me.Frame3.Controls.Add(Me.cmdFilterHorizontal)
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(318, 165)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(75, 35)
        Me.Frame3.TabIndex = 32
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Select data:"
        Me.Frame3.Visible = False
        '
        'cmdFilter0and45
        '
        Me.cmdFilter0and45.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFilter0and45.Enabled = False
        Me.cmdFilter0and45.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFilter0and45.Location = New System.Drawing.Point(148, 99)
        Me.cmdFilter0and45.Name = "cmdFilter0and45"
        Me.cmdFilter0and45.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFilter0and45.Size = New System.Drawing.Size(85, 22)
        Me.cmdFilter0and45.TabIndex = 35
        Me.cmdFilter0and45.Text = "IR([40 45], 0)"
        Me.cmdFilter0and45.UseVisualStyleBackColor = False
        '
        'cmdFilter00
        '
        Me.cmdFilter00.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFilter00.Enabled = False
        Me.cmdFilter00.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFilter00.Location = New System.Drawing.Point(55, 99)
        Me.cmdFilter00.Name = "cmdFilter00"
        Me.cmdFilter00.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFilter00.Size = New System.Drawing.Size(85, 22)
        Me.cmdFilter00.TabIndex = 34
        Me.cmdFilter00.Text = "IR(0,0)"
        Me.cmdFilter00.UseVisualStyleBackColor = False
        '
        'cmdFilterItem1
        '
        Me.cmdFilterItem1.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFilterItem1.Enabled = False
        Me.cmdFilterItem1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFilterItem1.Location = New System.Drawing.Point(241, 99)
        Me.cmdFilterItem1.Name = "cmdFilterItem1"
        Me.cmdFilterItem1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFilterItem1.Size = New System.Drawing.Size(85, 22)
        Me.cmdFilterItem1.TabIndex = 33
        Me.cmdFilterItem1.Text = "Item #1"
        Me.cmdFilterItem1.UseVisualStyleBackColor = False
        '
        'cmdFilterAll
        '
        Me.cmdFilterAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFilterAll.Enabled = False
        Me.cmdFilterAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFilterAll.Location = New System.Drawing.Point(55, 74)
        Me.cmdFilterAll.Name = "cmdFilterAll"
        Me.cmdFilterAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFilterAll.Size = New System.Drawing.Size(85, 22)
        Me.cmdFilterAll.TabIndex = 32
        Me.cmdFilterAll.Text = "All"
        Me.cmdFilterAll.UseVisualStyleBackColor = False
        '
        'cmdFilterMedian
        '
        Me.cmdFilterMedian.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFilterMedian.Enabled = False
        Me.cmdFilterMedian.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFilterMedian.Location = New System.Drawing.Point(241, 74)
        Me.cmdFilterMedian.Name = "cmdFilterMedian"
        Me.cmdFilterMedian.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFilterMedian.Size = New System.Drawing.Size(85, 22)
        Me.cmdFilterMedian.TabIndex = 19
        Me.cmdFilterMedian.Text = "Median"
        Me.cmdFilterMedian.UseVisualStyleBackColor = False
        '
        'lblMatlabFlags
        '
        Me.lblMatlabFlags.BackColor = System.Drawing.SystemColors.Control
        Me.lblMatlabFlags.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMatlabFlags.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblMatlabFlags.Location = New System.Drawing.Point(198, 147)
        Me.lblMatlabFlags.Name = "lblMatlabFlags"
        Me.lblMatlabFlags.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMatlabFlags.Size = New System.Drawing.Size(121, 13)
        Me.lblMatlabFlags.TabIndex = 33
        Me.lblMatlabFlags.Text = "Matlab Flags:"
        Me.lblMatlabFlags.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmPlotTOA
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(394, 198)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lblMatlabFlags)
        Me.Controls.Add(Me.Frame3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPlotTOA"
        Me.ShowInTaskbar = False
        Me.Text = "Plot Time-Of-Arrival"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.Frame3.ResumeLayout(False)
        Me.Frame3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents lblPlotAs As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents cmbMode As System.Windows.Forms.ComboBox
    Public WithEvents optGeodeticMode As System.Windows.Forms.RadioButton
    Public WithEvents optHorizontalPolarMode As System.Windows.Forms.RadioButton
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents cmdOK As System.Windows.Forms.Button
    Public WithEvents txtFilter As System.Windows.Forms.TextBox
    Public WithEvents cmdFilterHorizontal As System.Windows.Forms.Button
    Public WithEvents Frame3 As System.Windows.Forms.GroupBox
    Public WithEvents cmdFilter0and45 As System.Windows.Forms.Button
    Public WithEvents cmdFilter00 As System.Windows.Forms.Button
    Public WithEvents cmdFilterItem1 As System.Windows.Forms.Button
    Public WithEvents cmdFilterAll As System.Windows.Forms.Button
    Public WithEvents txtRecChannel As System.Windows.Forms.TextBox
    Public WithEvents cmdFilterMedian As System.Windows.Forms.Button
    Public WithEvents lblMatlabFlags As System.Windows.Forms.Label
    Public WithEvents lblPlotMode As System.Windows.Forms.Label
End Class
