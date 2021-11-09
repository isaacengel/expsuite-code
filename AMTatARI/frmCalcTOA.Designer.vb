<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalcTOA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCalcTOA))
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdCalculate = New System.Windows.Forms.Button()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.chkPlotToa = New System.Windows.Forms.CheckBox()
        Me.cmbMethod = New System.Windows.Forms.ComboBox()
        Me.lblMethod = New System.Windows.Forms.Label()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(179, 123)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(105, 21)
        Me.cmdCancel.TabIndex = 35
        Me.cmdCancel.Tag = "Cancel"
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdCalculate
        '
        Me.cmdCalculate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCalculate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCalculate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCalculate.Location = New System.Drawing.Point(68, 101)
        Me.cmdCalculate.Name = "cmdCalculate"
        Me.cmdCalculate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCalculate.Size = New System.Drawing.Size(105, 43)
        Me.cmdCalculate.TabIndex = 34
        Me.cmdCalculate.Tag = "Calculate Time-Of-Arrival"
        Me.cmdCalculate.Text = "Calculate TOA"
        Me.cmdCalculate.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.chkPlotToa)
        Me.Frame1.Controls.Add(Me.cmbMethod)
        Me.Frame1.Controls.Add(Me.lblMethod)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(12, 13)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(326, 77)
        Me.Frame1.TabIndex = 37
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Calculation Mode:"
        '
        'chkPlotToa
        '
        Me.chkPlotToa.AutoSize = True
        Me.chkPlotToa.Location = New System.Drawing.Point(69, 45)
        Me.chkPlotToa.Name = "chkPlotToa"
        Me.chkPlotToa.Size = New System.Drawing.Size(116, 17)
        Me.chkPlotToa.TabIndex = 29
        Me.chkPlotToa.Text = "Plot Time-Of-Arrival"
        Me.chkPlotToa.UseVisualStyleBackColor = True
        '
        'cmbMethod
        '
        Me.cmbMethod.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMethod.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMethod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbMethod.Location = New System.Drawing.Point(69, 18)
        Me.cmbMethod.Name = "cmbMethod"
        Me.cmbMethod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbMethod.Size = New System.Drawing.Size(234, 21)
        Me.cmbMethod.TabIndex = 5
        '
        'lblMethod
        '
        Me.lblMethod.BackColor = System.Drawing.SystemColors.Control
        Me.lblMethod.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMethod.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMethod.Location = New System.Drawing.Point(6, 22)
        Me.lblMethod.Name = "lblMethod"
        Me.lblMethod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMethod.Size = New System.Drawing.Size(57, 17)
        Me.lblMethod.TabIndex = 6
        Me.lblMethod.Text = "Method:"
        Me.lblMethod.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmCalcTOA
        '
        Me.AcceptButton = Me.cmdCalculate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(349, 156)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdCalculate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCalcTOA"
        Me.ShowInTaskbar = False
        Me.Text = "Calculate Time-Of-Arrival"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents cmdCalculate As System.Windows.Forms.Button
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents cmbMethod As System.Windows.Forms.ComboBox
    Public WithEvents lblMethod As System.Windows.Forms.Label
    Friend WithEvents chkPlotToa As System.Windows.Forms.CheckBox
End Class
