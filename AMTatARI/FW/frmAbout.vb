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
Imports VB = Microsoft.VisualBasic
' about form, contains license, version numbers, project homepages, contact adresses
''' <summary>
''' FrameWork Module. Implementation of the About form.
''' </summary>
''' <remarks></remarks>
Friend Class frmAbout
    Inherits System.Windows.Forms.Form


    Private Sub frmAbout_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmMain.Icon
        'picIcon.Image = frmMain.Icon.ToBitmap
        picIcon.Image = New Icon(frmMain.Icon, 48, 48).ToBitmap()

        Me.Text = "About " & My.Application.Info.Title
        lblTitle.Text = My.Application.Info.Title
        lblDescr.Text = My.Application.Info.Description
        Dim szFWVersion As String = TStr(FW_MAJOR) & "." & TStr(FW_MINOR) & "." & TStr(FW_REVISION)
        Dim szX As String = ""
        Dim szY As String = ""
        If My.Application.Info.Version.Revision <> 0 Then szY = "." & My.Application.Info.Version.Revision

        If Len(FW_BRANCH) > 0 Then szX = vbTab & "Framework Branch: " & FW_BRANCH
        lblVersionX.Text = "Version " & _
                My.Application.Info.Version.Major & "." & _
                My.Application.Info.Version.Minor & "." & _
                My.Application.Info.Version.Build & szY & vbCrLf & szX
        lblCopyright.Text = My.Application.Info.Copyright
        lblCompany.Text = My.Application.Info.CompanyName
        lblExpSuite.Text = "ExpSuite FW " & szFWVersion
    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Me.Close()
    End Sub

    Private Sub lblLicense_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblLicense.LinkClicked
        System.Diagnostics.Process.Start("http://joinup.ec.europa.eu/software/page/eupl")
    End Sub

    Private Sub lblCitation_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblCitation.LinkClicked
        System.Diagnostics.Process.Start("http://tinyurl.com/expsuite")
    End Sub

    Private Sub lblAuthors_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblAuthorPiotr.LinkClicked
        System.Diagnostics.Process.Start("mailto:piotr@majdak.com")
    End Sub

    Private Sub lblARI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblARI.LinkClicked
        System.Diagnostics.Process.Start("https://www.oeaw.ac.at/isf/")
    End Sub

    Private Sub lblAAS_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblAAS.LinkClicked
        System.Diagnostics.Process.Start("http://www.oeaw.ac.at")
    End Sub

    Private Sub lblBugFeatureReport_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblBugFeatureReport.LinkClicked
        System.Diagnostics.Process.Start("http://sourceforge.net/projects/expsuite")
    End Sub

    Private Sub lblAuthorMiho_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblAuthorMiho.LinkClicked
        System.Diagnostics.Process.Start("mailto:michael.mihocic@oeaw.ac.at")
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        System.Diagnostics.Process.Start("https://www.oeaw.ac.at/isf/")
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        System.Diagnostics.Process.Start("http://www.oeaw.ac.at")
    End Sub
End Class