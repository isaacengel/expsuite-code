<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMESM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMESM))
        Me.etaMin = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.etaMax = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.K = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.L1 = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.L2 = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.N = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.fMax = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.fMin = New System.Windows.Forms.NumericUpDown()
        Me.btnCalcMesm = New System.Windows.Forms.Button()
        Me.dgvMesm = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Tmin = New System.Windows.Forms.NumericUpDown()
        Me.lblUnoptimized = New System.Windows.Forms.Label()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.etaMin,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.etaMax,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.K,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.L1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.L2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.N,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.fMax,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.fMin,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.dgvMesm,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Tmin,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'etaMin
        '
        Me.etaMin.Location = New System.Drawing.Point(248, 24)
        Me.etaMin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.etaMin.Name = "etaMin"
        Me.etaMin.Size = New System.Drawing.Size(55, 20)
        Me.etaMin.TabIndex = 0
        Me.etaMin.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(190, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "eta (number of interleaved stimulations)"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(219, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "min"
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(314, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "max"
        '
        'etaMax
        '
        Me.etaMax.Location = New System.Drawing.Point(343, 24)
        Me.etaMax.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.etaMax.Name = "etaMax"
        Me.etaMax.Size = New System.Drawing.Size(55, 20)
        Me.etaMax.TabIndex = 1
        Me.etaMax.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Location = New System.Drawing.Point(12, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(146, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "K (max. number of harmonics)"
        '
        'K
        '
        Me.K.Location = New System.Drawing.Point(343, 54)
        Me.K.Name = "K"
        Me.K.Size = New System.Drawing.Size(55, 20)
        Me.K.TabIndex = 2
        Me.K.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Location = New System.Drawing.Point(12, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(227, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "L1 (length of the linear Impulse Response) [ms]"
        '
        'L1
        '
        Me.L1.Location = New System.Drawing.Point(343, 84)
        Me.L1.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.L1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(55, 20)
        Me.L1.TabIndex = 3
        Me.L1.Value = New Decimal(New Integer() {38, 0, 0, 0})
        '
        'Label8
        '
        Me.Label8.AutoSize = true
        Me.Label8.Location = New System.Drawing.Point(13, 117)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(294, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "L2 (length of second order Harmonic Impulse Response) [ms]"
        '
        'L2
        '
        Me.L2.Location = New System.Drawing.Point(343, 114)
        Me.L2.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(55, 20)
        Me.L2.TabIndex = 4
        Me.L2.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = true
        Me.Label9.Location = New System.Drawing.Point(12, 146)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(230, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "N (number of systems = number of channel IDs)"
        '
        'N
        '
        Me.N.Location = New System.Drawing.Point(343, 144)
        Me.N.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.N.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.N.Name = "N"
        Me.N.Size = New System.Drawing.Size(55, 20)
        Me.N.TabIndex = 5
        Me.N.Value = New Decimal(New Integer() {91, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = true
        Me.Label10.Location = New System.Drawing.Point(314, 176)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(25, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "end"
        '
        'fMax
        '
        Me.fMax.Location = New System.Drawing.Point(343, 174)
        Me.fMax.Maximum = New Decimal(New Integer() {40000, 0, 0, 0})
        Me.fMax.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.fMax.Name = "fMax"
        Me.fMax.Size = New System.Drawing.Size(55, 20)
        Me.fMax.TabIndex = 7
        Me.fMax.Value = New Decimal(New Integer() {20000, 0, 0, 0})
        '
        'Label11
        '
        Me.Label11.AutoSize = true
        Me.Label11.Location = New System.Drawing.Point(219, 176)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(27, 13)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "start"
        '
        'Label12
        '
        Me.Label12.AutoSize = true
        Me.Label12.Location = New System.Drawing.Point(12, 176)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 13)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "f [Hz]"
        '
        'fMin
        '
        Me.fMin.Location = New System.Drawing.Point(248, 174)
        Me.fMin.Maximum = New Decimal(New Integer() {40000, 0, 0, 0})
        Me.fMin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.fMin.Name = "fMin"
        Me.fMin.Size = New System.Drawing.Size(55, 20)
        Me.fMin.TabIndex = 6
        Me.fMin.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'btnCalcMesm
        '
        Me.btnCalcMesm.Location = New System.Drawing.Point(15, 233)
        Me.btnCalcMesm.Name = "btnCalcMesm"
        Me.btnCalcMesm.Size = New System.Drawing.Size(95, 23)
        Me.btnCalcMesm.TabIndex = 10
        Me.btnCalcMesm.Text = "Calculate"
        Me.btnCalcMesm.UseVisualStyleBackColor = true
        '
        'dgvMesm
        '
        Me.dgvMesm.AllowUserToAddRows = false
        Me.dgvMesm.AllowUserToDeleteRows = false
        Me.dgvMesm.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.dgvMesm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvMesm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMesm.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvMesm.Location = New System.Drawing.Point(12, 271)
        Me.dgvMesm.MultiSelect = false
        Me.dgvMesm.Name = "dgvMesm"
        Me.dgvMesm.ReadOnly = true
        Me.dgvMesm.Size = New System.Drawing.Size(386, 145)
        Me.dgvMesm.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Location = New System.Drawing.Point(12, 206)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "T min [ms]"
        '
        'Tmin
        '
        Me.Tmin.Location = New System.Drawing.Point(343, 204)
        Me.Tmin.Maximum = New Decimal(New Integer() {60000, 0, 0, 0})
        Me.Tmin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Tmin.Name = "Tmin"
        Me.Tmin.Size = New System.Drawing.Size(55, 20)
        Me.Tmin.TabIndex = 8
        Me.Tmin.Value = New Decimal(New Integer() {1500, 0, 0, 0})
        '
        'lblUnoptimized
        '
        Me.lblUnoptimized.AutoSize = true
        Me.lblUnoptimized.Location = New System.Drawing.Point(116, 238)
        Me.lblUnoptimized.Name = "lblUnoptimized"
        Me.lblUnoptimized.Size = New System.Drawing.Size(75, 13)
        Me.lblUnoptimized.TabIndex = 24
        Me.lblUnoptimized.Text = "lblUnoptimized"
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnApply.Location = New System.Drawing.Point(15, 426)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(95, 23)
        Me.btnApply.TabIndex = 12
        Me.btnApply.Text = "Apply to Settings"
        Me.btnApply.UseVisualStyleBackColor = true
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(303, 426)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(95, 23)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = true
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(303, 233)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 23)
        Me.Button1.TabIndex = 25
        Me.Button1.Text = "Clear Table"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'frmMESM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 461)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.lblUnoptimized)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Tmin)
        Me.Controls.Add(Me.dgvMesm)
        Me.Controls.Add(Me.btnCalcMesm)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.fMax)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.fMin)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.N)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.L2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.L1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.K)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.etaMax)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.etaMin)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(430, 480)
        Me.Name = "frmMESM"
        Me.Text = "Calculate MESM parameters for multiple eta values"
        CType(Me.etaMin,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.etaMax,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.K,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.L1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.L2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.N,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.fMax,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.fMin,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dgvMesm,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Tmin,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents etaMin As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents etaMax As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents K As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents L1 As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents L2 As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents N As NumericUpDown
    Friend WithEvents Label10 As Label
    Friend WithEvents fMax As NumericUpDown
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents fMin As NumericUpDown
    Friend WithEvents btnCalcMesm As Button
    Friend WithEvents dgvMesm As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents Tmin As NumericUpDown
    Friend WithEvents lblUnoptimized As Label
    Friend WithEvents btnApply As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents Button1 As Button
End Class
