Option Strict On
Option Explicit On
#Region "ExpSuite License"
'ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
'Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
'Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
'You may not use this work except in compliance with the Licence. 
'You may obtain a copy of the Licence at: http://joinup.ec.europa.eu/software/page/eupl
'Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
'See the Licence for the specific language governing  permissions and limitations under the Licence. 
#End Region
' when saving item lists the form helps to find a fitting postfix like "fresh list" or "response list"
''' <summary>
''' FrameWork Module. Implementation of the Postfix of Item Lists dialog.
''' </summary>
''' <remarks></remarks>
Friend Class frmItemListPostfix
    Inherits System.Windows.Forms.Form


    Private IsInitializing As Boolean
    Private mszFile As String

    Private Sub CreateFileName()
        Dim lX As Integer

        If InStrRev(LCase(gszSettingTitle), "." & LCase(My.Application.Info.AssemblyName)) > 0 Then
            mszFile = Mid(gszSettingTitle, 1, InStrRev(LCase(gszSettingTitle), "." & LCase(My.Application.Info.AssemblyName)) - 1)
        ElseIf InStrRev(LCase(gszSettingTitle), ".esf") > 0 Then
            mszFile = Mid(gszSettingTitle, 1, InStrRev(LCase(gszSettingTitle), ".esf") - 1)
        Else
            mszFile = gszSettingTitle
        End If

        For lX = 0 To 4
            If optPostFix(CShort(lX)).Checked = True Then Exit For
        Next
        Select Case lX
            Case FWintern.ItemListPostfixIndex.piNothing
            Case FWintern.ItemListPostfixIndex.piFresh
                mszFile = mszFile & "_fresh"
            Case FWintern.ItemListPostfixIndex.piBegin
                mszFile = mszFile & "_begin"
            Case FWintern.ItemListPostfixIndex.piResponse
                mszFile = mszFile & "_response"
            Case 4 ' User
                mszFile = mszFile & "_" & txtPostFix.Text
        End Select
        ChangeDir(gszCurrentDir)
        If chkNewVersion.CheckState = CheckState.Checked Then GetNextFileVersion(mszFile, "." & gszItemListExtension)
        txtPreFileName.Text = mszFile
        txtPreFileName.SelectionStart = 0
        txtPreFileName.SelectionLength = Len(mszFile)
        Dim g As Graphics = txtPreFileName.CreateGraphics
        Dim StringSize As New SizeF
        StringSize = g.MeasureString(mszFile, txtPostFix.Font)
        lblPreDots.Visible = StringSize.Width > txtPreFileName.Width

    End Sub

    Public Function CreateFileNameWrapper() As String
        chkNewVersion.CheckState = CType(-1 * CShort((glFileNamingFlags And 1) <> 0), Windows.Forms.CheckState)
        optPostFix(CShort(FWintern.piItemListPostfixIndex)).Checked = True 'not visible, but to get correct postfix
        CreateFileName()
        Return mszFile
    End Function


    Private Sub chkNewVersion_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkNewVersion.CheckStateChanged
        If Me.IsInitializing = True Then Return
        CreateFileName()
    End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        gszItemListPostFix = txtPostFix.Text
        glFileNamingFlags = (glFileNamingFlags And &HFFFFFFFE) Or chkNewVersion.CheckState
        gszFileName = mszFile
        gblnCancel = False
        Me.Close()
    End Sub

    Private Sub frmItemListPostfix_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Me.Icon = frmMain.Icon
        Me.Top = frmMain.Top + CInt(frmMain.Height / 10)
        Me.Left = frmMain.Left + CInt(frmMain.Width / 10)
        gblnCancel = True
        Select Case FWintern.piItemListPostfixIndex
            Case FWintern.ItemListPostfixIndex.piNothing, FWintern.ItemListPostfixIndex.piFresh, FWintern.ItemListPostfixIndex.piBegin, FWintern.ItemListPostfixIndex.piResponse
                optPostFix(CShort(FWintern.piItemListPostfixIndex)).Checked = True
            Case FWintern.ItemListPostfixIndex.piUser
                optPostFix(CShort(FWintern.piItemListPostfixIndex)).Checked = True
                TextBoxState(txtPostFix, True)
        End Select
        txtPostFix.Text = gszItemListPostFix
        chkNewVersion.CheckState = CType(-1 * CShort((glFileNamingFlags And 1) <> 0), Windows.Forms.CheckState)
        txtPreFileName.ReadOnly = True
        CreateFileName()

    End Sub

    Private Sub optPostFix_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optPostFix.CheckedChanged
        If Me.IsInitializing = True Then Return
        If DirectCast(eventSender, RadioButton).Checked Then
            Dim Index As Short = optPostFix.GetIndex(DirectCast(eventSender, RadioButton))
            CreateFileName()
        End If
    End Sub

    Private Sub txtPostFix_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPostFix.TextChanged
        If Me.IsInitializing = True Then Return
        CreateFileName()
    End Sub

    Private Sub txtPreFileName_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPreFileName.Click
        lblPreDots.Visible = False
    End Sub

    Private Sub txtPreFileName_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtPreFileName.KeyDown
        lblPreDots.Visible = False
    End Sub

    Private Sub txtPreFileName_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPreFileName.Leave
        txtPreFileName.SelectionStart = 0
        txtPreFileName.SelectionLength = Len(mszFile)
        Dim g As Graphics = txtPreFileName.CreateGraphics
        Dim StringSize As New SizeF
        StringSize = g.MeasureString(mszFile, txtPostFix.Font)
        lblPreDots.Visible = StringSize.Width > txtPreFileName.Width
    End Sub
End Class