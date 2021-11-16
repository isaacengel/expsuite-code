<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerateSOFA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGenerateSOFA))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBoxRaw = New System.Windows.Forms.CheckBox()
        Me.CheckBoxEQ = New System.Windows.Forms.CheckBox()
        Me.CheckBoxITD = New System.Windows.Forms.CheckBox()
        Me.CheckBox3DTI = New System.Windows.Forms.CheckBox()
        Me.TextBoxSofaname = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxRef = New System.Windows.Forms.TextBox()
        Me.ButtonBrowseRef = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CheckBoxShowPlots = New System.Windows.Forms.CheckBox()
        Me.CheckBox44kHz = New System.Windows.Forms.CheckBox()
        Me.CheckBox48kHz = New System.Windows.Forms.CheckBox()
        Me.CheckBox96kHz = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(201, 319)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 37)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Generate"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckBoxRaw
        '
        Me.CheckBoxRaw.AutoSize = True
        Me.CheckBoxRaw.Location = New System.Drawing.Point(11, 22)
        Me.CheckBoxRaw.Name = "CheckBoxRaw"
        Me.CheckBoxRaw.Size = New System.Drawing.Size(117, 17)
        Me.CheckBoxRaw.TabIndex = 1
        Me.CheckBoxRaw.Text = "Raw HRTF (SOFA)"
        Me.CheckBoxRaw.UseVisualStyleBackColor = True
        '
        'CheckBoxEQ
        '
        Me.CheckBoxEQ.AutoSize = True
        Me.CheckBoxEQ.Checked = True
        Me.CheckBoxEQ.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxEQ.Location = New System.Drawing.Point(11, 45)
        Me.CheckBoxEQ.Name = "CheckBoxEQ"
        Me.CheckBoxEQ.Size = New System.Drawing.Size(268, 17)
        Me.CheckBoxEQ.TabIndex = 2
        Me.CheckBoxEQ.Text = "HRTF equalised by reference measurement (SOFA)"
        Me.CheckBoxEQ.UseVisualStyleBackColor = True
        '
        'CheckBoxITD
        '
        Me.CheckBoxITD.AutoSize = True
        Me.CheckBoxITD.Checked = True
        Me.CheckBoxITD.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxITD.Location = New System.Drawing.Point(11, 94)
        Me.CheckBoxITD.Name = "CheckBoxITD"
        Me.CheckBoxITD.Size = New System.Drawing.Size(123, 17)
        Me.CheckBoxITD.TabIndex = 4
        Me.CheckBoxITD.Text = "Time-aligned (SOFA)"
        Me.CheckBoxITD.UseVisualStyleBackColor = True
        '
        'CheckBox3DTI
        '
        Me.CheckBox3DTI.AutoSize = True
        Me.CheckBox3DTI.Location = New System.Drawing.Point(11, 117)
        Me.CheckBox3DTI.Name = "CheckBox3DTI"
        Me.CheckBox3DTI.Size = New System.Drawing.Size(154, 17)
        Me.CheckBox3DTI.TabIndex = 5
        Me.CheckBox3DTI.Text = "Time-aligned (.3DTI-HRTF)"
        Me.CheckBox3DTI.UseVisualStyleBackColor = True
        '
        'TextBoxSofaname
        '
        Me.TextBoxSofaname.Location = New System.Drawing.Point(56, 12)
        Me.TextBoxSofaname.Name = "TextBoxSofaname"
        Me.TextBoxSofaname.Size = New System.Drawing.Size(160, 20)
        Me.TextBoxSofaname.TabIndex = 6
        Me.TextBoxSofaname.Text = "MyHRTF"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Name:"
        '
        'TextBoxRef
        '
        Me.TextBoxRef.Location = New System.Drawing.Point(115, 68)
        Me.TextBoxRef.Name = "TextBoxRef"
        Me.TextBoxRef.Size = New System.Drawing.Size(328, 20)
        Me.TextBoxRef.TabIndex = 8
        Me.TextBoxRef.Text = "C:\Users\Admin\Documents\AMTatARI files\HRTF reference.mat"
        '
        'ButtonBrowseRef
        '
        Me.ButtonBrowseRef.Location = New System.Drawing.Point(449, 66)
        Me.ButtonBrowseRef.Name = "ButtonBrowseRef"
        Me.ButtonBrowseRef.Size = New System.Drawing.Size(31, 23)
        Me.ButtonBrowseRef.TabIndex = 9
        Me.ButtonBrowseRef.Text = "..."
        Me.ButtonBrowseRef.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Reference file:"
        '
        'CheckBoxShowPlots
        '
        Me.CheckBoxShowPlots.AutoSize = True
        Me.CheckBoxShowPlots.Location = New System.Drawing.Point(23, 330)
        Me.CheckBoxShowPlots.Name = "CheckBoxShowPlots"
        Me.CheckBoxShowPlots.Size = New System.Drawing.Size(78, 17)
        Me.CheckBoxShowPlots.TabIndex = 11
        Me.CheckBoxShowPlots.Text = "Show plots"
        Me.CheckBoxShowPlots.UseVisualStyleBackColor = True
        '
        'CheckBox44kHz
        '
        Me.CheckBox44kHz.AutoSize = True
        Me.CheckBox44kHz.Checked = True
        Me.CheckBox44kHz.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox44kHz.Location = New System.Drawing.Point(15, 23)
        Me.CheckBox44kHz.Name = "CheckBox44kHz"
        Me.CheckBox44kHz.Size = New System.Drawing.Size(72, 17)
        Me.CheckBox44kHz.TabIndex = 12
        Me.CheckBox44kHz.Text = "44100 Hz"
        Me.CheckBox44kHz.UseVisualStyleBackColor = True
        '
        'CheckBox48kHz
        '
        Me.CheckBox48kHz.AutoSize = True
        Me.CheckBox48kHz.Location = New System.Drawing.Point(15, 46)
        Me.CheckBox48kHz.Name = "CheckBox48kHz"
        Me.CheckBox48kHz.Size = New System.Drawing.Size(72, 17)
        Me.CheckBox48kHz.TabIndex = 13
        Me.CheckBox48kHz.Text = "48000 Hz"
        Me.CheckBox48kHz.UseVisualStyleBackColor = True
        '
        'CheckBox96kHz
        '
        Me.CheckBox96kHz.AutoSize = True
        Me.CheckBox96kHz.Location = New System.Drawing.Point(15, 69)
        Me.CheckBox96kHz.Name = "CheckBox96kHz"
        Me.CheckBox96kHz.Size = New System.Drawing.Size(72, 17)
        Me.CheckBox96kHz.TabIndex = 14
        Me.CheckBox96kHz.Text = "96000 Hz"
        Me.CheckBox96kHz.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox44kHz)
        Me.GroupBox1.Controls.Add(Me.CheckBox96kHz)
        Me.GroupBox1.Controls.Add(Me.CheckBox48kHz)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 207)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(175, 100)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sampling frequencies to export"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckBoxRaw)
        Me.GroupBox2.Controls.Add(Me.CheckBoxEQ)
        Me.GroupBox2.Controls.Add(Me.CheckBoxITD)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.CheckBox3DTI)
        Me.GroupBox2.Controls.Add(Me.ButtonBrowseRef)
        Me.GroupBox2.Controls.Add(Me.TextBoxRef)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 55)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(496, 146)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Formats to export"
        '
        'frmGenerateSOFA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 378)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CheckBoxShowPlots)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxSofaname)
        Me.Controls.Add(Me.Button1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmGenerateSOFA"
        Me.Text = "Generate SOFA files"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents CheckBoxRaw As CheckBox
    Friend WithEvents CheckBoxEQ As CheckBox
    Friend WithEvents CheckBoxITD As CheckBox
    Friend WithEvents CheckBox3DTI As CheckBox
    Friend WithEvents TextBoxSofaname As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxRef As TextBox
    Friend WithEvents ButtonBrowseRef As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents CheckBoxShowPlots As CheckBox
    Friend WithEvents CheckBox44kHz As CheckBox
    Friend WithEvents CheckBox48kHz As CheckBox
    Friend WithEvents CheckBox96kHz As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
End Class
