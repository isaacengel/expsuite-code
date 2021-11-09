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
' form for tracking hardware (Flock-of-bird tracker)
''' <summary>
''' FrameWork Module. Implementation of the dialog to set Tracker ranges.
''' </summary>
''' <remarks></remarks>
Friend Class frmSettingsTrackRange
    Inherits System.Windows.Forms.Form



    Private IsInitializing As Boolean
    Private mlS As Integer
    Private mszDim As String
    Private mlDim As Integer
    Private msngMin, msngMax As Double

    Private Sub chkMax_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkMax.CheckStateChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            TextBoxState(txtMax, CBool(chkMax.CheckState))
        End If
    End Sub

    Private Sub chkMin_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkMin.CheckStateChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            TextBoxState(txtMin, CBool(chkMin.CheckState))
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        frmSettings.TopMost = True
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        If Not IsNumeric((txtMin.Text)) Then MsgBox("Minimum must be numeric") : Exit Sub
        If Not IsNumeric((txtMax.Text)) Then MsgBox("Maximum must be numeric") : Exit Sub
        msngMin = Val(txtMin.Text)
        msngMax = Val(txtMax.Text)
        gtsTrackerMin(mlS).lStatus = (gtsTrackerMin(mlS).lStatus And CInt(2 ^ 6 - 1 - 2 ^ mlDim)) Or (chkMin.CheckState * CInt(2 ^ mlDim))
        gtsTrackerMax(mlS).lStatus = (gtsTrackerMax(mlS).lStatus And CInt(2 ^ 6 - 1 - 2 ^ mlDim)) Or (chkMax.CheckState * CInt(2 ^ mlDim))
        Select Case mszDim
            Case "X"
                gtsTrackerMin(mlS).sngX = msngMin
                gtsTrackerMax(mlS).sngX = msngMax
            Case "Y"
                gtsTrackerMin(mlS).sngY = msngMin
                gtsTrackerMax(mlS).sngY = msngMax
            Case "Z"
                gtsTrackerMin(mlS).sngZ = msngMin
                gtsTrackerMax(mlS).sngZ = msngMax
            Case "A"
                gtsTrackerMin(mlS).sngA = msngMin
                gtsTrackerMax(mlS).sngA = msngMax
            Case "E"
                gtsTrackerMin(mlS).sngE = msngMin
                gtsTrackerMax(mlS).sngE = msngMax
            Case "R"
                gtsTrackerMin(mlS).sngR = msngMin
                gtsTrackerMax(mlS).sngR = msngMax
        End Select

        frmSettings.TopMost = True
        Me.Close()
    End Sub

    Private Sub frmSettingsTrackRange_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Me.Icon = frmMain.Icon

        Tracker.GetRangeData(mlS, mszDim)
        Select Case mszDim
            Case "X"
                mlDim = 0
                msngMin = gtsTrackerMin(mlS).sngX
                msngMax = gtsTrackerMax(mlS).sngX
            Case "Y"
                mlDim = 1
                msngMin = gtsTrackerMin(mlS).sngY
                msngMax = gtsTrackerMax(mlS).sngY
            Case "Z"
                mlDim = 2
                msngMin = gtsTrackerMin(mlS).sngZ
                msngMax = gtsTrackerMax(mlS).sngZ
            Case "A"
                mlDim = 3
                msngMin = gtsTrackerMin(mlS).sngA
                msngMax = gtsTrackerMax(mlS).sngA
            Case "E"
                mlDim = 4
                msngMin = gtsTrackerMin(mlS).sngE
                msngMax = gtsTrackerMax(mlS).sngE
            Case "R"
                mlDim = 5
                msngMin = gtsTrackerMin(mlS).sngR
                msngMax = gtsTrackerMax(mlS).sngR
            Case Else
                MsgBox("Wrong dimension", MsgBoxStyle.Critical, "Track Range")
                Me.Close()
        End Select
        Me.Text = "Track Range of Sensor " & TStr(mlS) & ": " & mszDim
        txtMin.Text = TStr(msngMin)
        txtMax.Text = TStr(msngMax)
        chkMin.CheckState = CType(-1 * CInt((gtsTrackerMin(mlS).lStatus And CInt(2 ^ mlDim)) <> 0), Windows.Forms.CheckState)
        chkMax.CheckState = CType(-1 * CInt((gtsTrackerMax(mlS).lStatus And CInt(2 ^ mlDim)) <> 0), Windows.Forms.CheckState)

        frmSettings.TopMost = False
        Me.SetBounds(frmSettings.Left, frmSettings.Top, 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
    End Sub
End Class