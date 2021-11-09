Option Strict On
Option Explicit On
#Region "ExpSuite License"
'ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
'Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
'Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
'You may not use this work except in compliance with the Licence. 
'You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
'Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
'See the Licence for the specific language governing  permissions and limitations under the Licence. 
#End Region
Friend Class frmPlotTOA
    Inherits System.Windows.Forms.Form
    Private IsInitializing As Boolean
    'Private mvarFlags As Integer 'local copy
    Private mvarOptionalParameters As String 'local copy
    'Private mvarParameter As Integer 'local copy
    Private mvarRecChannel As String = ":" 'local copy
    'Private mvarTitle As String 'local copy
    Private mvarFilter As String 'local copy


    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub frmPlotTOA_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = EventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        gPlotToaCurrentParameters = -CInt(optHorizontalPolarMode.Checked) + CInt(cmbMode.SelectedIndex * 2)
        grectfrmPlotTOA.Left = CInt(Val(VB6.PixelsToTwipsX(Me.Left)))
        grectfrmPlotTOA.Top = CInt(Val(VB6.PixelsToTwipsY(Me.Top)))
        EventArgs.Cancel = Cancel
    End Sub

    Private Sub frmPlotTOA_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetControls()

        If grectfrmPlotTOA.Left <> 0 And grectfrmPlotTOA.Top <> 0 Then
            Me.Left = CInt(Val(VB6.TwipsToPixelsX(grectfrmPlotTOA.Left)))
            Me.Top = CInt(Val(VB6.TwipsToPixelsY(grectfrmPlotTOA.Top)))
        Else
            Me.Left = frmMain.Left
            Me.Top = frmMain.Top
        End If

        If cmbMode.SelectedIndex = 0 Then
            optGeodeticMode.Checked = True
            optHorizontalPolarMode.Enabled = False
        Else
            optHorizontalPolarMode.Enabled = True
        End If
        UpdateMatlabFlags()

    End Sub

    Private Sub SetControls()
        ' Build controls
        ' build mode combo
        ' matrix mode
        cmbMode.Items.Clear()
        cmbMode.Items.Add("Plot (2D)")
        cmbMode.Items.Add("Surf (3D)")

        Me.Enabled = True
        ' Plot mode
        'If ((mvarFlags \ 256) And 7) < cmbMode.Items.Count Then
        '    cmbMode.SelectedIndex = (mvarFlags \ 256) And 7
        'Else
        '    cmbMode.SelectedIndex = cmbMode.Items.Count - 1
        'End If

        If (gPlotToaCurrentParameters And 1) = 1 Then
            optHorizontalPolarMode.Checked = True
        Else
            optGeodeticMode.Checked = True
        End If
        If (gPlotToaCurrentParameters And 2) = 2 Then
            cmbMode.SelectedIndex = 1
        Else
            cmbMode.SelectedIndex = 0
        End If

        'txtParameter.Text = mvarOptionalParameters

        'If CBool(mvarFlags And 128) Then
        '    optGeodeticMode.Checked = True
        'Else
        '    optHorizontalPolarMode.Checked = True
        'End If
        If mvarRecChannel <> "" Then
            txtRecChannel.Text = mvarRecChannel
        Else
            txtRecChannel.Text = ":"
        End If
        txtFilter.Text = mvarFilter
        UpdateMatlabFlags()

    End Sub

    Private Sub UpdateMatlabFlags()

        lblPlotMode.Text = TStr(CShort(-CInt(optHorizontalPolarMode.Checked)))
        lblPlotAs.Text = TStr(CShort(CInt(cmbMode.SelectedIndex)) * 2)

        lblMatlabFlags.Text = "Matlab Flags: " & TStr(CShort(-CInt(optHorizontalPolarMode.Checked) + CInt(cmbMode.SelectedIndex * 2)))


    End Sub

    Private Sub cmbMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMode.SelectedIndexChanged
        If Me.IsInitializing Then
            Exit Sub
        Else
            If cmbMode.SelectedIndex = 0 Then
                optGeodeticMode.Checked = True
                optHorizontalPolarMode.Enabled = False
            Else
                optHorizontalPolarMode.Enabled = True
            End If

            UpdateMatlabFlags()
        End If

    End Sub

    Private Sub optGeodeticMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optGeodeticMode.CheckedChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            UpdateMatlabFlags()
        End If
    End Sub

    Private Sub optHorizontalPolarMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optHorizontalPolarMode.CheckedChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            UpdateMatlabFlags()
        End If
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim szErr, szX As String
        Dim szOptionalParameters As String = ""
        'Dim szRecStream As String = ""

        Dim szMatlabFlags As String = TStr(CShort(-CInt(optHorizontalPolarMode.Checked) + CInt(cmbMode.SelectedIndex * 2)))

        Me.Enabled = False

        szX = "AA_PlotTOA(stimPar, meta, meta.toa(:," & txtRecChannel.Text & "), " & szMatlabFlags & ");"

        szErr = STIM.Matlab(szX)
        If Len(szErr) <> 0 Then GoTo SubError

SubEnd:
        frmPostProcessing.SetStatus("Time-Of-Arrival plotted")
        Me.Enabled = True

        Exit Sub

SubError:
        MsgBox(szErr, MsgBoxStyle.Critical, "Plot Data Matrix: Error")
        GoTo SubEnd

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        gblnCancel = True
        Me.Close()
    End Sub

    Private Sub cmdFilterAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilterAll.Click
        txtFilter.Text = ":"
    End Sub

    Private Sub cmdFilterHorizontal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilterHorizontal.Click
        txtFilter.Text = "find(meta.pos(:,2)==0)"
    End Sub

    Private Sub cmdFilterMedian_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilterMedian.Click
        txtFilter.Text = "find(meta.pos(:,1)==0)"
    End Sub

    Private Sub cmdFilter00_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter00.Click
        txtFilter.Text = "find(meta.pos(:,1)==0 & meta.pos(:,2)==0)"
    End Sub

    Private Sub cmdFilter0and45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter0and45.Click
        txtFilter.Text = "find(meta.pos(:,2)==0 & (meta.pos(:,1)==40 | meta.pos(:,1)==45))"
    End Sub

    Private Sub cmdFilterItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilterItem1.Click
        txtFilter.Text = "find(meta.itemidx==1)"
    End Sub
End Class