﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.CheckBoxEQmp = New System.Windows.Forms.CheckBox()
        Me.CheckBoxFinalCheck = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(268, 393)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 46)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Generate"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckBoxRaw
        '
        Me.CheckBoxRaw.AutoSize = True
        Me.CheckBoxRaw.Checked = True
        Me.CheckBoxRaw.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxRaw.Location = New System.Drawing.Point(15, 27)
        Me.CheckBoxRaw.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBoxRaw.Name = "CheckBoxRaw"
        Me.CheckBoxRaw.Size = New System.Drawing.Size(149, 21)
        Me.CheckBoxRaw.TabIndex = 1
        Me.CheckBoxRaw.Text = "Raw HRTF (SOFA)"
        Me.CheckBoxRaw.UseVisualStyleBackColor = True
        '
        'CheckBoxEQ
        '
        Me.CheckBoxEQ.AutoSize = True
        Me.CheckBoxEQ.Checked = True
        Me.CheckBoxEQ.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxEQ.Location = New System.Drawing.Point(15, 55)
        Me.CheckBoxEQ.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBoxEQ.Name = "CheckBoxEQ"
        Me.CheckBoxEQ.Size = New System.Drawing.Size(357, 21)
        Me.CheckBoxEQ.TabIndex = 2
        Me.CheckBoxEQ.Text = "HRTF equalised by reference measurement (SOFA)"
        Me.CheckBoxEQ.UseVisualStyleBackColor = True
        '
        'CheckBoxITD
        '
        Me.CheckBoxITD.AutoSize = True
        Me.CheckBoxITD.Checked = True
        Me.CheckBoxITD.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxITD.Location = New System.Drawing.Point(15, 148)
        Me.CheckBoxITD.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBoxITD.Name = "CheckBoxITD"
        Me.CheckBoxITD.Size = New System.Drawing.Size(163, 21)
        Me.CheckBoxITD.TabIndex = 4
        Me.CheckBoxITD.Text = "Time-aligned (SOFA)"
        Me.CheckBoxITD.UseVisualStyleBackColor = True
        '
        'CheckBox3DTI
        '
        Me.CheckBox3DTI.AutoSize = True
        Me.CheckBox3DTI.Location = New System.Drawing.Point(15, 176)
        Me.CheckBox3DTI.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBox3DTI.Name = "CheckBox3DTI"
        Me.CheckBox3DTI.Size = New System.Drawing.Size(202, 21)
        Me.CheckBox3DTI.TabIndex = 5
        Me.CheckBox3DTI.Text = "Time-aligned (.3DTI-HRTF)"
        Me.CheckBox3DTI.UseVisualStyleBackColor = True
        '
        'TextBoxSofaname
        '
        Me.TextBoxSofaname.Location = New System.Drawing.Point(75, 15)
        Me.TextBoxSofaname.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBoxSofaname.Name = "TextBoxSofaname"
        Me.TextBoxSofaname.Size = New System.Drawing.Size(212, 22)
        Me.TextBoxSofaname.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Name:"
        '
        'TextBoxRef
        '
        Me.TextBoxRef.Location = New System.Drawing.Point(151, 116)
        Me.TextBoxRef.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBoxRef.Name = "TextBoxRef"
        Me.TextBoxRef.Size = New System.Drawing.Size(436, 22)
        Me.TextBoxRef.TabIndex = 8
        Me.TextBoxRef.Text = "C:\Users\Admin\Documents\AMTatARI files\reference_eq.mat"
        '
        'ButtonBrowseRef
        '
        Me.ButtonBrowseRef.Location = New System.Drawing.Point(597, 113)
        Me.ButtonBrowseRef.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonBrowseRef.Name = "ButtonBrowseRef"
        Me.ButtonBrowseRef.Size = New System.Drawing.Size(41, 28)
        Me.ButtonBrowseRef.TabIndex = 9
        Me.ButtonBrowseRef.Text = "..."
        Me.ButtonBrowseRef.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 119)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Reference file:"
        '
        'CheckBoxShowPlots
        '
        Me.CheckBoxShowPlots.AutoSize = True
        Me.CheckBoxShowPlots.Location = New System.Drawing.Point(277, 309)
        Me.CheckBoxShowPlots.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBoxShowPlots.Name = "CheckBoxShowPlots"
        Me.CheckBoxShowPlots.Size = New System.Drawing.Size(98, 21)
        Me.CheckBoxShowPlots.TabIndex = 11
        Me.CheckBoxShowPlots.Text = "Show plots"
        Me.CheckBoxShowPlots.UseVisualStyleBackColor = True
        '
        'CheckBox44kHz
        '
        Me.CheckBox44kHz.AutoSize = True
        Me.CheckBox44kHz.Checked = True
        Me.CheckBox44kHz.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox44kHz.Location = New System.Drawing.Point(15, 28)
        Me.CheckBox44kHz.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBox44kHz.Name = "CheckBox44kHz"
        Me.CheckBox44kHz.Size = New System.Drawing.Size(91, 21)
        Me.CheckBox44kHz.TabIndex = 12
        Me.CheckBox44kHz.Text = "44100 Hz"
        Me.CheckBox44kHz.UseVisualStyleBackColor = True
        '
        'CheckBox48kHz
        '
        Me.CheckBox48kHz.AutoSize = True
        Me.CheckBox48kHz.Location = New System.Drawing.Point(15, 57)
        Me.CheckBox48kHz.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBox48kHz.Name = "CheckBox48kHz"
        Me.CheckBox48kHz.Size = New System.Drawing.Size(91, 21)
        Me.CheckBox48kHz.TabIndex = 13
        Me.CheckBox48kHz.Text = "48000 Hz"
        Me.CheckBox48kHz.UseVisualStyleBackColor = True
        '
        'CheckBox96kHz
        '
        Me.CheckBox96kHz.AutoSize = True
        Me.CheckBox96kHz.Location = New System.Drawing.Point(15, 85)
        Me.CheckBox96kHz.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBox96kHz.Name = "CheckBox96kHz"
        Me.CheckBox96kHz.Size = New System.Drawing.Size(91, 21)
        Me.CheckBox96kHz.TabIndex = 14
        Me.CheckBox96kHz.Text = "96000 Hz"
        Me.CheckBox96kHz.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox44kHz)
        Me.GroupBox1.Controls.Add(Me.CheckBox96kHz)
        Me.GroupBox1.Controls.Add(Me.CheckBox48kHz)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 281)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(233, 123)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sampling frequencies to export"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckBoxEQmp)
        Me.GroupBox2.Controls.Add(Me.CheckBoxRaw)
        Me.GroupBox2.Controls.Add(Me.CheckBoxEQ)
        Me.GroupBox2.Controls.Add(Me.CheckBoxITD)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.CheckBox3DTI)
        Me.GroupBox2.Controls.Add(Me.ButtonBrowseRef)
        Me.GroupBox2.Controls.Add(Me.TextBoxRef)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 62)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(661, 210)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Formats to export"
        '
        'CheckBoxEQmp
        '
        Me.CheckBoxEQmp.AutoSize = True
        Me.CheckBoxEQmp.Checked = True
        Me.CheckBoxEQmp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxEQmp.Location = New System.Drawing.Point(15, 84)
        Me.CheckBoxEQmp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBoxEQmp.Name = "CheckBoxEQmp"
        Me.CheckBoxEQmp.Size = New System.Drawing.Size(470, 21)
        Me.CheckBoxEQmp.TabIndex = 11
        Me.CheckBoxEQmp.Text = "HRTF equalised (minimum-phase) by reference measurement (SOFA)"
        Me.CheckBoxEQmp.UseVisualStyleBackColor = True
        '
        'CheckBoxFinalCheck
        '
        Me.CheckBoxFinalCheck.AutoSize = True
        Me.CheckBoxFinalCheck.Location = New System.Drawing.Point(277, 338)
        Me.CheckBoxFinalCheck.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBoxFinalCheck.Name = "CheckBoxFinalCheck"
        Me.CheckBoxFinalCheck.Size = New System.Drawing.Size(164, 21)
        Me.CheckBoxFinalCheck.TabIndex = 17
        Me.CheckBoxFinalCheck.Text = "Run quick final check"
        Me.CheckBoxFinalCheck.UseVisualStyleBackColor = True
        '
        'frmGenerateSOFA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 465)
        Me.Controls.Add(Me.CheckBoxFinalCheck)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CheckBoxShowPlots)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxSofaname)
        Me.Controls.Add(Me.Button1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
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
    Friend WithEvents CheckBoxEQmp As CheckBox
    Friend WithEvents CheckBoxFinalCheck As CheckBox
End Class
