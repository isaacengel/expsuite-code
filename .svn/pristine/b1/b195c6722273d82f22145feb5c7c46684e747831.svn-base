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
Public Class frmCalcTOA
    Inherits System.Windows.Forms.Form
    Private IsInitializing As Boolean
    'Private mvarFlags As Integer 'local copy
    Private mvarOptionalParameters As String 'local copy
    'Private mvarParameter As Integer 'local copy
    Private mvarRecChannel As String 'local copy
    'Private mvarTitle As String 'local copy
    Private mvarFilter As String 'local copy



    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub frmCalcTOA_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = EventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = EventArgs.CloseReason
        grectfrmPlotTOA.Left = CInt(Val(VB6.PixelsToTwipsX(Me.Left)))
        grectfrmPlotTOA.Top = CInt(Val(VB6.PixelsToTwipsY(Me.Top)))
        EventArgs.Cancel = Cancel
    End Sub

    Private Sub frmCalcTOA_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetControls()

        If grectfrmPlotTOA.Left <> 0 And grectfrmPlotTOA.Top <> 0 Then
            Me.Left = CInt(Val(VB6.TwipsToPixelsX(grectfrmPlotTOA.Left)))
            Me.Top = CInt(Val(VB6.TwipsToPixelsY(grectfrmPlotTOA.Top)))
        Else
            Me.Left = frmMain.Left
            Me.Top = frmMain.Top
        End If
        'cmdCalculate.Enabled = True
        'cmdCancel.Enabled = True
        'cmbMethod.Enabled = True
        'txtParameter.Enabled = True
        'chkPlotToa.Enabled = True

    End Sub

    Private Sub SetControls()
        ' Build controls
        ' build mode combo
        ' matrix mode
        If cmbMethod.Items.Count = 0 Then
            cmbMethod.Items.Add("Threshold-Detection")
            cmbMethod.Items.Add("Centroid of squared IR")
            cmbMethod.Items.Add("Mean Groupdelay")
            cmbMethod.Items.Add("Minimal-Phase Cross-Correlation")
            cmbMethod.Items.Add("Filtered Minimal-Phase Cross-Correlation")
            cmbMethod.SelectedIndex = 3
        End If
        'cmbMethod.Items.Clear()
        'cmbMethod.Items.Add("Threshold-Detection")
        'cmbMethod.Items.Add("Centroid of squared IR")
        'cmbMethod.Items.Add("Mean Groupdelay")
        'cmbMethod.Items.Add("Minimal-Phase Cross-Correlation")
        'cmbMethod.Items.Add("Filtered Minimal-Phase Cross-Correlation")

        ' Plot mode
        'If ((mvarFlags \ 256) And 7) < cmbMode.Items.Count Then
        '    cmbMode.SelectedIndex = (mvarFlags \ 256) And 7
        'Else
        '    cmbMode.SelectedIndex = cmbMode.Items.Count - 1
        'End If

        'If (gPlotToaCurrentParameters And 1) = 1 Then
        'Else
        'End If
        'If (gPlotToaCurrentParameters And 2) = 2 Then
        'cmbMethod.SelectedIndex = 3
        'Else
        'cmbMethod.SelectedIndex = 0
        'End If

        'txtParameter.Text = mvarOptionalParameters

        'If CBool(mvarFlags And 128) Then
        '    optGeodeticMode.Checked = True
        'Else
        '    optHorizontalPolarMode.Checked = True
        'End If

        'txtRecChannel.Text = mvarRecChannel
        'txtFilter.Text = mvarFilter
        'UpdateMatlabFlags()
    End Sub

    Private Sub cmdCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalculate.Click
        Dim szX As String

        Me.Enabled = False
        'cmdCalculate.Enabled = False
        'cmdCancel.Enabled = False
        'cmbMethod.Enabled = False
        'txtParameter.Enabled = False
        'chkPlotToa.Enabled = False

        'Dim szTargetAmp As String
        'Dim lFreqStart, lFreqEnd As Integer
        'Dim szT As String

        'szT = "Augmentation"
        'Me.Close()
        'Application.DoEvents()
        'szX = InputBox("Low frequency? [Hz]: ", szT, "300")
        'If Len(szX) = 0 Then SetReady() : Exit Sub
        'If IsNumeric(szX) Then lFreqStart = CInt(Val(szX))
        'szX = InputBox("High frequency? [Hz]: ", szT, "18000")
        'If Len(szX) = 0 Then SetReady() : Exit Sub
        'If IsNumeric(szX) Then lFreqEnd = CInt(Val(szX))

        'szX = InputBox("Augment lower frequencies to this amplitude? [dB]: ", szT, "-30")
        'If Len(szX) = 0 Then SetReady() : Exit Sub
        'szTargetAmp = szX

        'SetStatus("Augmenting...")
        szX = "[meta]=AA_CalcTOA(shiftdim(Obj.Data.IR,2),meta,stimPar," & cmbMethod.SelectedIndex + 1 & "," & chkPlotToa.CheckState & ");"
        szX = frmPostProcessing.MatlabCmd(szX)

        Me.Enabled = True
        Me.Close()

        If Len(szX) <> 0 Then
            'SetStatus("Error when calculating Time-Of-Arrival")
            MsgBox("Error when calculating Time-Of-Arrival:" & vbCrLf & vbCrLf & szX, 0, "Calculate Time-Of-Arrival")
            frmPostProcessing.SetStatus("Calculate Time-Of-Arrival... Error!")
            GoTo SubEnd
        End If

        frmPostProcessing.SetStatus("Calculate Time-Of-Arrival... finished successfully!")

SubEnd:
    End Sub

End Class