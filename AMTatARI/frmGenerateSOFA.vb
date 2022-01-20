Option Strict On
Option Explicit On

Public Class frmGenerateSOFA
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sofaname As String = TextBoxSofaname.Text
        Dim settingsFile As String = "settings.AMTatARI"
        Dim itemListFile As String = "itemlist.itl.csv"
        Dim referenceFile As String = TextBoxRef.Text
        Dim doPlots As Integer = CInt(CheckBoxShowPlots.Checked)
        Dim saveRaw As Integer = CInt(CheckBoxRaw.Checked)
        Dim saveEQ As Integer = CInt(CheckBoxEQ.Checked)
        Dim saveEQmp As Integer = CInt(CheckBoxEQmp.Checked)
        Dim saveITD As Integer = CInt(CheckBoxITD.Checked)
        Dim save3DTI As Integer = CInt(CheckBox3DTI.Checked)
        Dim finalCheck As Integer = CInt(CheckBoxFinalCheck.Checked)
        ' INISettings.WriteFile(STIM.WorkDir & "\" & settingsFile)
        ' ItemList.Save(STIM.WorkDir & "\" & itemListFile)
        Button1.Enabled = False
        Dim targetFs As String = "["
        If CheckBox44kHz.Checked Then
            targetFs = targetFs & "44100 "
        End If
        If CheckBox48kHz.Checked Then
            targetFs = targetFs & "48000 "
        End If
        If CheckBox96kHz.Checked Then
            targetFs = targetFs & "96000 "
        End If
        targetFs = targetFs & "]"
        Result.GenerateSOFA(sofaname, settingsFile, itemListFile, referenceFile, doPlots, saveRaw, saveEQ, saveEQmp, saveITD, save3DTI, targetFs, finalCheck, 0.0002, 15, "[200 1500]") ' TODO: set the last three parameters via settings
        Button1.Enabled = True
        Me.Close()
    End Sub

    Private Sub ButtonBrowseRef_Click(sender As Object, e As EventArgs) Handles ButtonBrowseRef.Click
        Dim dlgOpen As New OpenFileDialog With {
            .Title = "Load Reference .mat file",
            .InitialDirectory = gszCurrentDir,
            .FileName = "",
            .CheckFileExists = True,
            .CheckPathExists = True,
            .Filter = "matlab files (*.mat)|*.mat",
            .FilterIndex = 1,
            .SupportMultiDottedExtensions = True
        }
        If dlgOpen.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim szFile As String = dlgOpen.FileName
            gszCurrentDir = Mid(dlgOpen.FileName, 1, Len(dlgOpen.FileName) - Len((New System.IO.FileInfo(dlgOpen.FileName)).Name) - 1)
            TextBoxRef.Text = szFile
        End If
    End Sub

    Private Sub WhenOpening() Handles Me.Load
        Dim str() As String = STIM.WorkDir.Split("\"c)
        TextBoxSofaname.Text = str(UBound(str))
    End Sub


End Class