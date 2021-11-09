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
' control turntable
''' <summary>
''' FrameWork Module. Implementation of the Turntable dialog.
''' </summary>
''' <remarks></remarks>
Friend Class frmTurntable
    Inherits System.Windows.Forms.Form

    ' Outline ST2:
    '  Step: Pin 15, S3-Input, LPT1: 379H/Bit 3
    '  Zero: Pin 12, S5-Input, LPT1: 379H/Bit 5
    '  CW:  Pin 5, D3-Output, LPT1: 378H/Bit 3
    '  CCW: Pin 7, D5-Output, LPT1: 378H/Bit 5

    Private mlStepCCW As Integer
    Private mStartTime As System.DateTime

    Public Sub ShowAngle(ByVal sngX As Double)

        If sngX < 0 Then
            If Me.Visible = True Then
                lblCurrentAzi.Text = "N/A"
                lblTrueAzi.Text = "N/A"
            End If
            frmMain.lblTTShow.Text = "Turntable:"
        Else
            Select Case glTTMode
                Case 1
                    'input is angle that is used by the subject, including all offsets but we ignore the input for Four Audio because we can determine the angle anytime anyway...
                    If Me.Visible = True Then
                        lblCurrentAzi.Text = TStr(Math.Round(gsngTTAngle, 1)) & "°"
                        lblTrueAzi.Text = TStr(Math.Round(gsngTTActualAngle, 1)) & "°"
                    End If
                    frmMain.lblTTShow.Text = TStr(Math.Round(gsngTTAngle, 1)) & "°" & "    Turntable:"
                Case 2
                    If Me.Visible = True Then
                        lblCurrentAzi.Text = TStr((360 + sngX - gsngTTOffset) Mod 360) & "°"
                        lblTrueAzi.Text = TStr(sngX) & "°"
                    End If
                    frmMain.lblTTShow.Text = TStr((360 + sngX - gsngTTOffset) Mod 360) & "°" & "    Turntable:"
                Case 3
                    If Me.Visible = True Then
                        lblCurrentAzi.Text = TStr(Math.Round((360 + gsngTTAngle) Mod 360, 1)) & "°"
                        lblTrueAzi.Text = TStr(Math.Round((360 + gsngTTActualAngle) Mod 360, 1)) & "°"
                    End If
                    frmMain.lblTTShow.Text = TStr(Math.Round((360 + gsngTTAngle) Mod 360, 1)) & "°" & "    Turntable:"
            End Select

        End If

    End Sub

    Private Sub UIBusy()
        For Each cmdX As Control In Me.Controls
            If TypeOf (cmdX) Is Button Then
                If cmdX.Name = "cmdCancel" Then
                    cmdX.Enabled = True
                Else
                    cmdX.Enabled = False
                End If
            End If
        Next
        TextBoxState(txtReqPos, False)
        TextBoxState(txtReqSpeed, False)
    End Sub

    Private Sub UIReady()

        For Each cmdX As Control In Me.Controls
            If TypeOf (cmdX) Is Button Then
                Select Case cmdX.Name
                        'Case "cmdCancel"
                        '    cmdX.Enabled = False
                    Case "cmdMove", "_cmdMoveValue_0", "_cmdMoveValue_1", "_cmdMoveValue_2", "_cmdMoveValue_3"
                        cmdX.Enabled = gblnTTInitialized
                    Case "cmdResetCW", "cmdResetCCW"
                        If glTTMode = 1 Then cmdX.Enabled = gblnTTInitialized
                    Case Else
                        cmdX.Enabled = True
                End Select
            End If
        Next
        TextBoxState(txtReqPos, True)
        TextBoxState(txtReqSpeed, True)

    End Sub


    Private Sub cmdCCW_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdCCW.MouseDown
        TTGoCCW()
        gsngTTAngle = -1
        gblnTTInitialized = False
        sbStatusLabel.Text = "Turntable must be initialized"
        ShowAngle(-1)
    End Sub

    Private Sub cmdCCW_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdCCW.MouseUp
        TTStop()
        UIReady()
    End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click

        gblnCancel = True

        Select Case glTTMode
            Case 1 'four audio
                'MsgBox("not supported yet...", MsgBoxStyle.Information, "Stop Turntable")
                Turntable.EmergencyStop()
            Case 2 'outline
                ' get rid of current angle
                gsngTTAngle = -1
                gblnTTInitialized = False
                sbStatusLabel.Text = "Turntable must be initialized"
                ShowAngle(-1)

                gblnTTHideUI = False
            Case 3
                Turntable.EmergencyStop()
                ' get rid of current angle
                gsngTTAngle = -1
                gblnTTInitialized = False
                sbStatusLabel.Text = "Turntable must be initialized"
                ShowAngle(-1)
                'MsgBox("Turntable stopped! Current azimuth is probably inaccurate. Consider recalibrating it.", MsgBoxStyle.Critical, "Stop Turntable")
        End Select




    End Sub

    Private Sub cmdCW_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdCW.MouseDown
        TTGoCW()
        gsngTTAngle = -1
        gblnTTInitialized = False
        sbStatusLabel.Text = "Turntable must be initialized"
        ShowAngle(-1)
    End Sub

    Private Sub cmdCW_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles cmdCW.MouseUp
        TTStop()
        UIReady()
    End Sub

    Private Sub cmdMoveValue_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMoveValue.Click
        Dim Index As Short = cmdMoveValue.GetIndex(DirectCast(eventSender, Button))
        Dim szErr As String
        Dim sngX As Double
        Dim lDir As Integer = -1
        dim bAllowFullRotations As Boolean = False

        Select Case Index
            Case 0 ' 0°
                sngX = 0
            Case 1 ' 180°
                sngX = 180
            Case 2 ' 270°
                sngX = 270
            Case 3 ' 90°
                sngX = 90
            Case 5 ' -10°
                Select Case glTTMode
                    Case 1 'Four Audio
                        sngX = (gsngTTAngle + 350) Mod 360
                    Case 2 'Outline
                        If GetAngle() = Nothing Then 'not initialized -> we pretend to be at zero and move -10°
                            gsngTTAngle = 0
                            sngX = 350
                        ElseIf GetAngle() >= 0 Then
                            sngX = (GetAngle() + 350) Mod 360
                        Else
                            sngX = 350 'only Outline
                        End If
                    Case 3 'Imperial
                        If GetAngle() = Nothing Then gsngTTAngle = 0 'not initialized -> we pretend to be at zero
                        sngX = (gsngTTAngle + 10) Mod 360 ' we measure angles anticlockwise
                End Select

            Case 4 ' +10°
                Select Case glTTMode
                    Case 1 'Four Audio
                        sngX = (gsngTTAngle + 10) Mod 360
                    Case 2 'Outline
                        If GetAngle() = Nothing Then 'not initialized -> we pretend to be at zero and move 10°
                            gsngTTAngle = 0
                            sngX = 10
                        ElseIf GetAngle() >= 0 Then
                            sngX = (GetAngle() + 10) Mod 360
                        Else
                            sngX = 10 'only Outline
                        End If
                    Case 3
                        If GetAngle() = Nothing Then gsngTTAngle = 0 'not initialized -> we pretend to be at zero
                        sngX = (gsngTTAngle + 350) Mod 360 ' we measure angles anticlockwise
                End Select
            Case 6 ' move CCW
                If glTTMode = 2 Or glTTMode = 3 Then MsgBox("Not implemented yet!") : Exit Sub

                sngX = Val(txtReqPos.Text) 'numeric to perform checks

                If (sngX >= -360 And sngX <= 360) = False Then MsgBox("Valid values: -360° to 360°", _
                                                    MsgBoxStyle.Critical, "Set angle") : Return

                sngX = (sngX + 360) Mod 360 ' negative -> positive values
                'gsngTTReqAngle = sngX ' required angle
                'txtReqPos.Text = TStr(gsngTTReqAngle) ' display updated value

                lDir = 1 ' direction
            Case 7 ' move CW
                If glTTMode = 2 Or glTTMode = 3 Then MsgBox("Not implemented yet!") : Exit Sub

                sngX = Val(txtReqPos.Text) 'numeric to perform checks

                If (sngX >= -360 And sngX <= 360) = False Then MsgBox("Valid values: -360° to 360°", _
                                                    MsgBoxStyle.Critical, "Set angle") : Return

                sngX = (sngX + 360) Mod 360 ' negative -> positive values

                lDir = 0

            Case 8 ' -360° (CCW)
                If glTTMode = 2 Or glTTMode = 3 Then MsgBox("Not implemented yet!") : Exit Sub

                sngX = (gsngTTAngle - 360)
                lDir = 1 ' direction
                bAllowFullRotations=True
            Case 9 ' +360° (CW)
                If glTTMode = 2 Or glTTMode = 3 Then MsgBox("Not implemented yet!") : Exit Sub

                sngX = (gsngTTAngle + 360)
                lDir = 0 ' direction
                bAllowFullRotations = True

            Case 10 ' -1°
                Select Case glTTMode
                    Case 3 'Imperial
                        If GetAngle() = Nothing Then gsngTTAngle = 0 'not initialized -> we pretend to be at zero
                        sngX = (gsngTTAngle + 359) Mod 360 ' we measure angles anticlockwise
                End Select

            Case 11 ' +1°
                Select Case glTTMode
                    Case 3
                        If GetAngle() = Nothing Then gsngTTAngle = 0 'not initialized -> we pretend to be at zero
                        sngX = (gsngTTAngle + 1) Mod 360 ' we measure angles anticlockwise
                End Select

            Case 12 ' +90°
                Select Case glTTMode
                    Case 3 'Imperial
                        If GetAngle() = Nothing Then gsngTTAngle = 0 'not initialized -> we pretend to be at zero
                        sngX = (gsngTTAngle + 90) Mod 360 ' we measure angles anticlockwise
                End Select

            Case 13 ' -90°
                Select Case glTTMode
                    Case 3
                        If GetAngle() = Nothing Then gsngTTAngle = 0 'not initialized -> we pretend to be at zero
                        sngX = (gsngTTAngle + 270) Mod 360 ' we measure angles anticlockwise
                End Select

        End Select

        Select Case glTTMode
            Case 1 ' Four Audio
                gsngTTReqAngle = Math.Round(sngX, 1)
                txtReqPos.Text = TStr(gsngTTReqAngle)
            Case 2
                gsngTTReqAngle = Math.Round(((sngX + gsngTTOffset) Mod 360) / gsngTTResolution) * gsngTTResolution
                txtReqPos.Text = TStr((360 + gsngTTReqAngle - gsngTTOffset) Mod 360)
            Case 3
                gsngTTReqAngle = Math.Round(sngX, 1)
                txtReqPos.Text = TStr(gsngTTReqAngle)
        End Select
        Application.DoEvents() 'update display

        szErr = MoveToAngle(lDir, bAllowFullRotations)
        If gblnCancel Then Return
        If Len(szErr) > 0 Then
            MsgBox(szErr, MsgBoxStyle.Critical, "Move")
        End If

    End Sub

    Private Sub cmdResetCCW_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdResetCCW.Click

        Dim MovingStart As System.DateTime = System.DateTime.Now
        cmdResetCCW.BackColor = System.Drawing.Color.Red
        sbStatusLabel.Text = "Resetting turntable counterclockwise."

        UIBusy()
        pbTime.Value = 0
        Select Case glTTMode
            Case 1 ' Four Audio
                If GetAngle() = 0 Then GoTo SkipRotation
                sbStatusLabel.Text = "Resetting turntable counterclockwise..."
                Turntable.MoveToAngle(0, 1, True)
                cmdResetCCW.BackColor = System.Drawing.SystemColors.Control
            Case 2 ' Outline
                Dim szErr As String = Reset(0)
                cmdResetCCW.BackColor = System.Drawing.SystemColors.Control
                If gblnCancel Then Return
                If Len(szErr) > 0 Then UIReady() : MsgBox(szErr, MsgBoxStyle.Critical, "Reset turntable") : Return
                If gsngTTOffset <> 0 Then
                    szErr = MoveToOffset(gsngTTOffset) ' move to offset angle
                    If Len(szErr) > 0 Then MsgBox(szErr, MsgBoxStyle.Critical, "Move to offset")
                End If
            Case 3
                ' TO DO
                MsgBox("not supported yet...", MsgBoxStyle.Information, "Reset Turntable")
        End Select
        pbTime.Value = 0
        sbStatusLabel.Text = "Turntable is ready. Movement time: " & DateDiff(DateInterval.Second, MovingStart, System.DateTime.Now).ToString & " sec."
SkipRotation:
        UIReady()

    End Sub

    Private Sub cmdResetCW_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdResetCW.Click

        Dim MovingStart As System.DateTime = System.DateTime.Now
        cmdResetCW.BackColor = System.Drawing.Color.Red
        'sbStatusLabel.Text = "Resetting turntable clockwise."

        UIBusy()
        pbTime.Value = 0
        Select Case glTTMode
            Case 1 ' Four Audio
                If GetAngle() = 0 Then GoTo SkipRotation
                sbStatusLabel.Text = "Resetting turntable clockwise..."
                Turntable.MoveToAngle(360, 0, True)
                cmdResetCW.BackColor = System.Drawing.SystemColors.Control
            Case 2 ' Outline
                Dim szErr As String = Reset(1)
                cmdResetCW.BackColor = System.Drawing.SystemColors.Control
                If gblnCancel Then Return
                If Len(szErr) > 0 Then UIReady() : MsgBox(szErr, MsgBoxStyle.Critical, "Reset turntable") : sbStatusLabel.Text = szErr : Return
                If gsngTTOffset <> 0 Then
                    szErr = MoveToOffset(gsngTTOffset) ' move to offset angle
                    If Len(szErr) > 0 Then UIReady() : MsgBox(szErr, MsgBoxStyle.Critical, "Move to offset") : sbStatusLabel.Text = szErr : Return
                End If
            Case 3
                ' TO DO
                MsgBox("not supported yet...", MsgBoxStyle.Information, "Reset Turntable")
        End Select
        pbTime.Value = 0
        sbStatusLabel.Text = "Turntable is ready. Movement time: " & DateDiff(DateInterval.Second, MovingStart, System.DateTime.Now).ToString & " sec."
SkipRotation:
        UIReady()

    End Sub


    Private Sub cmdMove_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMove.Click
        Dim szErr As String
        Dim sngX As Double

        If Not IsNumeric((txtReqPos.Text)) Then MsgBox("Input a valid numeric value from 0° to 360°", _
                            MsgBoxStyle.Critical, "Set angle") : Return
        sngX = Val(txtReqPos.Text)

        Select Case glTTMode
            Case 1 ' Four Audio
                If (sngX >= -360 And sngX <= 360) = False Then MsgBox("Valid values: -360° to 360°", _
                                                    MsgBoxStyle.Critical, "Set angle") : Return
                gsngTTReqAngle = Math.Round((sngX + 360) Mod 360, 1)
                txtReqPos.Text = TStr(gsngTTReqAngle)
            Case 2
                If (sngX >= 0 And sngX <= 360) = False Then MsgBox("Valid values: 0° to 360°", _
                                                    MsgBoxStyle.Critical, "Set angle") : Return
                gsngTTReqAngle = Math.Round(((sngX + gsngTTOffset) Mod 360) / gsngTTResolution) * gsngTTResolution
                txtReqPos.Text = TStr((360 + gsngTTReqAngle - gsngTTOffset) Mod 360)
            Case 3 ' Imperial
                If (sngX >= 0 And sngX <= 360) = False Then MsgBox("Valid values: 0° to 360°",
                                                    MsgBoxStyle.Critical, "Set angle") : Return
                gsngTTReqAngle = Math.Round(sngX)
                txtReqPos.Text = TStr(gsngTTReqAngle)
        End Select

        szErr = MoveToAngle()
        If gblnCancel Then Return
        If Len(szErr) > 0 Then MsgBox(szErr, MsgBoxStyle.Critical, "Set Angle") : Return

    End Sub

    Private Sub cmdSetForced_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSetForced.Click

        If Not IsNumeric(txtReqPos.Text) Then MsgBox("Input a valid numeric value from 0° to 360°", _
                                MsgBoxStyle.Critical, "Set angle") : Return
        Dim sngX As Double = Val(txtReqPos.Text)
        If sngX >= 0 And sngX <= 360 Then
            Select Case glTTMode
                Case 1 'Four Audio

                    If MsgBox("Do you want to set the current position to " & txtReqPos.Text & "°?" & vbCrLf & vbCrLf &  "The offset will be saved in the application's options file!", MsgBoxStyle.YesNo Or MsgBoxStyle.Question,"Set current position") = MsgBoxResult.No Then GoTo Skipped

                    Turntable.SetPositionToZero()

                    'set offset
                    gsngTT4AOffset = -1 * Val(txtReqPos.Text)
                    
                    GetAngle()
                    
                    'save options
                    INIOptions.WriteFile(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\ExpSuite\" & My.Application.Info.Title & "\" & My.Application.Info.Title & ".ini")

                    sbStatusLabel.Text = "Position set to " & txtReqPos.Text & "° and offset saved to options file."

                Case 2 'Outline
                    gsngTTAngle = Math.Round(((sngX + gsngTTOffset) Mod 360) / gsngTTResolution) * gsngTTResolution
                    txtReqPos.Text = TStr((gsngTTAngle + 360 - gsngTTOffset) Mod 360)
                    gblnTTInitialized = True
                    sbStatusLabel.Text = "Position set to " & txtReqPos.Text & "°"

                Case 3 'Imperial
                    gsngTTAngle = sngX
                    txtReqPos.Text = TStr(gsngTTAngle)
                    gblnTTInitialized = True
                    sbStatusLabel.Text = "Position set to " & txtReqPos.Text & "°"

            End Select

Skipped:
            ShowAngle(gsngTTAngle)
        Else
            MsgBox("Valid values: 0° to 360°", MsgBoxStyle.Critical, "Set angle")
        End If

        UIReady()
    End Sub


    Private Sub frmTurntable_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim szErr As String = ""

        Me.Icon = frmMain.Icon

        pbTime.Value = 0

        Select Case glTTMode
            Case 1
                Me.Text = "Turntable Four Audio ANT on USB Port"
                shpStep.Visible = False
                lblStepMark.Visible = False
                lblZeroMark.Text = "Zero Position:"
                cmdCW.Visible = False
                cmdCCW.Visible = False
                _cmdMoveValue_6.Visible = True 'move ccw
                _cmdMoveValue_7.Visible = True ' move cw
                _cmdMoveValue_8.Visible = True ' move 360° ccw
                _cmdMoveValue_9.Visible = True ' move 360° cw
                cmdPullBrake.Visible = True
                cmdGet.Visible = True
                Me.Visible = True
                Me.SetBounds(frmMain.Left, frmMain.Top, 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)

                If Not gblnTTInitialized Then Turntable.Init()

                ' move if req. angle differs from current position
                If gblnTTInitialized Then
                    gsngTTAngle = GetAngle()

                    'ShowAngle(lPosition)
                    If gsngTTReqAngle >= 0 Then

                        If gsngTTAngle <> gsngTTReqAngle Then
                            txtReqPos.Text = TStr((360 + gsngTTReqAngle) Mod 360)
                            szErr = MoveToAngle()
                        End If
                    End If
                End If
                'tmrRefresh.Enabled = False

            Case 2
                Me.Text = "Turntable Outline ST2 on LPT" & TStr(glTTLPT)
                shpStep.Visible = True
                lblStepMark.Visible = True
                lblZeroMark.Text = "Zero Mark:"
                cmdCW.Visible = True
                cmdCCW.Visible = True
                _cmdMoveValue_6.Visible = False 'move ccw
                _cmdMoveValue_7.Visible = False ' move cw
                _cmdMoveValue_8.Visible = False ' move 360° ccw
                _cmdMoveValue_9.Visible = False ' move 360° cw
                cmdPullBrake.Visible = False
                cmdGet.Visible = False
                txtReqSpeed.Enabled = False
                Me.Visible = True
                Me.SetBounds(frmMain.Left, frmMain.Top, 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
                ' reset if not initialized
                If Not gblnTTInitialized Then
                    szErr = Reset(0)
                    If Len(szErr) <> 0 Then gblnTTInitialized = False
                    If gblnCancel Then GoTo SubCancel
                    If gsngTTOffset <> 0 Then
                        szErr = MoveToOffset(gsngTTOffset) ' move to offset angle
                        If Len(szErr) > 0 Then gblnTTInitialized = False
                    End If
                End If
                ' move if req. angle differs from current position
                If gblnTTInitialized And gsngTTReqAngle >= 0 Then
                    ' turntable is ready
                    ShowAngle(gsngTTAngle)
                    If gsngTTAngle <> gsngTTReqAngle Then
                        txtReqPos.Text = TStr((360 + gsngTTReqAngle - gsngTTOffset) Mod 360)
                        szErr = MoveToAngle()
                    End If
                End If
                'tmrRefresh.Enabled = True

            Case 3 ' Imperial
                Me.Text = "Imperial College Custom Turntable (via OSC)"
                shpStep.Visible = False
                lblStepMark.Visible = False
                lblZeroMark.Text = "Zero Position:"
                cmdCW.Visible = False
                cmdCCW.Visible = False
                _cmdMoveValue_6.Visible = False 'move ccw
                _cmdMoveValue_7.Visible = False ' move cw
                _cmdMoveValue_8.Visible = False ' move 360° ccw
                _cmdMoveValue_9.Visible = False ' move 360° cw
                cmdPullBrake.Visible = False
                cmdGet.Visible = False
                cmdResetCW.Visible = False
                cmdResetCCW.Visible = False
                lblTrueAzi.Visible = False
                Me.Visible = True
                Me.SetBounds(frmMain.Left, frmMain.Top, 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
                ' reset if not initialized
                If Not gblnTTInitialized Then
                    szErr = Reset(0)
                    If Len(szErr) <> 0 Then gblnTTInitialized = False
                    If gblnCancel Then GoTo SubCancel
                End If
                ' move if req. angle differs from current position
                If gblnTTInitialized And gsngTTReqAngle >= 0 Then
                    'turntable is ready
                    ShowAngle(gsngTTAngle)
                    If gsngTTAngle <> gsngTTReqAngle Then
                        txtReqPos.Text = TStr((360 + gsngTTReqAngle - gsngTTOffset) Mod 360)
                        szErr = MoveToAngle()
                    End If
                End If
                txtReqSpeed.Text = TStr(ttSpeed)
                'tmrRefresh.Enabled = True

        End Select

        tmrRefresh.Enabled = True

        If gblnTTInitialized Then
            sbStatusLabel.Text = "Turntable is ready..."
            If gsngTTAngle >= 0 Then ShowAngle(gsngTTAngle)
        Else
SubCancel:
            ShowAngle(-1)
            sbStatusLabel.Text = "Turntable is not initialized!"
        End If

        gszTTError = szErr

        If gblnTTHideUI Then tmrUnload.Enabled = True

        UIReady()

    End Sub

    Private Sub frmTurntable_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        tmrRefresh.Enabled = False
        eventArgs.Cancel = Cancel
    End Sub

    Private Sub tmrRefresh_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrRefresh.Tick
        If glTTMode = 0 Then tmrRefresh.Enabled = False : Exit Sub

        If glTTMode = 2 Then 'Outline
            If TTIsStep() Then
                shpStep.BackColor = Color.LawnGreen
            Else
                shpStep.BackColor = Color.Transparent
            End If
        End If

        If TTIsReset() Then
            shpZero.BackColor = Color.LawnGreen
            cmdResetCW.Enabled = False
            cmdResetCCW.Enabled = False
        Else
            shpZero.BackColor = Color.Transparent
            'cmdResetCW.Enabled = True
            'cmdResetCCW.Enabled = True
        End If
    End Sub

    Private Function [Reset](ByVal lDir As Integer) As String
        Dim szErr As String

        Dim curToc, curTic, curTO As Long
        Dim curX, curY As Long

        ShowAngle(-1)
        pbTime.Value = 0
        sbStatusLabel.Text = "Resetting turntable...."
        UIBusy()

        gblnTimeOut = False
        gblnCancel = False

        If glTTMode = 3 Then
            GoTo SubCancel
        End If

        QueryPerformanceCounter(curTic)
        curTO = 2000 * gcurHPFrequency \ 1000

        Dim lX As Integer
        ' reset mark active?
        If Not TTIsReset() Then
            If lDir = 0 Then TTGoCCW() Else TTGoCW() ' start moving
            ' until reset mark will be activated
            While (Not TTIsReset()) And (Not gblnTimeOut) And (Not gblnCancel)
                Windows.Forms.Application.DoEvents()
                If TTIsStep() Then
                    QueryPerformanceCounter(curTic)
                End If
                QueryPerformanceCounter(curToc)
                If curToc > (curTic + curTO) Then
                    gblnTimeOut = True
                Else
                    pbTime.Value = CInt(100 * (curToc - curTic) / curTO)
                End If
            End While
            TTStop()
        End If
        ' wait to stop
        QueryPerformanceCounter(curX)
        curX = curX + 100 * gcurHPFrequency \ 1000 ' wait 50 ms
        Do
            QueryPerformanceCounter(curY)
        Loop Until curY > curX

        If gblnCancel Then GoTo SubCancel 'cancel -> leave function with stopped TT

        ' move CCW until the rising edge of the reset and step mark
        mlStepCCW = 0
        If Not (TTIsStep() And TTIsReset()) Then
            lX = 0
            QueryPerformanceCounter(curTic)
            Do
                QueryPerformanceCounter(curX)
                curX = curX + 20 * gcurHPFrequency \ 1000 ' wait 50 ms
                Do
                    QueryPerformanceCounter(curY)
                Loop Until curY > curX
                TTGoCCW()
                QueryPerformanceCounter(curX)
                curX = curX + 20 * gcurHPFrequency \ 1000 ' wait 50 ms
                Do
                    QueryPerformanceCounter(curY)
                Loop Until curY > curX
                TTStop()
                lX = lX + 1
                QueryPerformanceCounter(curToc)
                If curToc > (curTic + curTO) Then gblnTimeOut = True
            Loop Until (TTIsStep() And TTIsReset()) Or gblnTimeOut Or gblnCancel
            TTStop()
            mlStepCCW = lX
        End If

        If gblnTimeOut Then
            szErr = "Turntable timed out and is probably not working."
            gsngTTAngle = -1
            gblnTTInitialized = False
            GoTo SubError
        End If
        If gblnCancel Then
            szErr = "Initialization cancelled by user."
            gsngTTAngle = -1
            gblnTTInitialized = False
            GoTo SubError
        Else
            sbStatusLabel.Text = "Turntable is ready."
            gsngTTAngle = 0
            ShowAngle(0)
            gblnTTInitialized = True
        End If

        'SubCancel:
        pbTime.Value = 0

        UIReady()
        Return ""

SubCancel:
        pbTime.Value = 0
        gsngTTAngle = -1
        gblnTTInitialized = False
        UIReady()
        Return ""
SubError:
        sbStatusLabel.Text = szErr
        pbTime.Value = 0
        UIReady()
        Return szErr

    End Function


    Private Function MoveToAngle(Optional lDir As Integer = -1, Optional bAllowFullRotations As Boolean = False) As String

        Dim szErr As String = Nothing
        Dim curToc, curTic, curTO As Long
        Dim curX, curY As Long
        Dim blnTimeOut As Boolean
        Dim arTTStep(100) As Short

        If gsngTTAngle = gsngTTReqAngle Then Return ""
        If glTTMode < 1 Then Return ""


        pbTime.Value = 0
        If GetAngle() = Not Nothing Then sbStatusLabel.Text = "Moving to " & TStr(gsngTTReqAngle) & "°..."
        UIBusy()
        blnTimeOut = False
        gblnCancel = False

        Dim MovingStart As System.DateTime = System.DateTime.Now

        Select Case glTTMode
            Case 1 'four audio ant
                'initialized? should be...
                If Not gblnTTInitialized Then szErr = Turntable.Init()
                If szErr <> Nothing Then GoTo SubError

                'move
                Turntable.MoveToAngle(gsngTTReqAngle, lDir, True, bAllowFullRotations)

            Case 2 'outline st2
                If Not gblnTTInitialized Then gsngTTAngle = (360 + gsngTTOffset) Mod 360 'pretend to be at 0°
                ' nothing to do?

                ' set angle to 0° (+ offset)? -> just reset
                ' PM 4.12.2019: No reset when moving to an angle
                'If gsngTTReqAngle = 0 Then
                'If gsngTTAngle > 180 Then szErr = Reset(1) Else szErr = Reset(0)
                'Return szErr
                'End If

                ' we have to move...


                ' how many step ticks to move?
                Dim sngX As Double = gsngTTReqAngle - gsngTTAngle
                If (sngX > 0 And sngX < 180) Or (sngX < -180) Then lDir = 1 Else lDir = -1

                curTO = 2000 * gcurHPFrequency \ 1000
                If Not TTIsStep() Then Windows.Forms.Application.DoEvents()

                If lDir > 0 Then TTGoCW() Else TTGoCCW() ' move
                QueryPerformanceCounter(curX)
                curX = curX + 250 * gcurHPFrequency \ 1000 ' wait 250 ms
                Do
                    Windows.Forms.Application.DoEvents()
                    QueryPerformanceCounter(curY)
                Loop Until curY > curX
                TTStop()

                Do
                    ' move through the ticks
                    If lDir > 0 Then TTGoCW() Else TTGoCCW()
                    ' move to inactive step
                    QueryPerformanceCounter(curTic)
                    While (TTIsStep()) And (Not blnTimeOut)
                        Windows.Forms.Application.DoEvents()
                        QueryPerformanceCounter(curToc)
                        If (curToc > (curTic + curTO)) Then
                            blnTimeOut = True
                        Else
                            pbTime.Value = CInt(100 * (curToc - curTic) / curTO)
                        End If
                    End While
                    curX = (curToc - curTic) * 1000 \ gcurHPFrequency
                    If blnTimeOut Then GoTo SubTimeOut
                    ' update angle (if known)
                    'If gsngTTAngle >= 0 Then
                    If gblnTTInitialized Then
                        gsngTTAngle = (360 + gsngTTAngle + gsngTTResolution * lDir) Mod 360
                        ShowAngle(gsngTTAngle)
                    Else
                        gsngTTAngle = (360 + Math.Max(gsngTTAngle, 0) + gsngTTResolution * lDir) Mod 360
                        ShowAngle(-1)
                    End If

                    ' move to active step
                    If ((lDir < 0) And (gsngTTAngle <> gsngTTReqAngle)) Or lDir > 0 Then
                        QueryPerformanceCounter(curTic)
                        While (Not TTIsStep()) And (Not blnTimeOut)
                            Windows.Forms.Application.DoEvents()
                            QueryPerformanceCounter(curToc)
                            If curToc > (curTic + curTO) Then
                                blnTimeOut = True
                            Else
                                pbTime.Value = CInt(100 * (curToc - curTic) / curTO)
                            End If
                        End While
                        If blnTimeOut Then GoTo SubTimeOut
                    End If
                Loop Until (gsngTTAngle = gsngTTReqAngle) Or (gblnCancel)

                ' stop and wait to get the turntable stable
                TTStop()
                QueryPerformanceCounter(curX)
                curX = curX + 100 * gcurHPFrequency \ 1000
                Do
                    QueryPerformanceCounter(curY)
                Loop Until curY > curX

            Case 3 'Imperial
                If Not gblnTTInitialized Then gsngTTAngle = 0 'pretend to be at 0°

                Turntable.MoveToAngle(gsngTTReqAngle, lDir, True, bAllowFullRotations)

                ' how much to move?
                'Dim sngX As Double = (360 + gsngTTReqAngle - gsngTTAngle) Mod 360
                'If sngX < 180 Then
                'lDir = 1 ' counter clockwise
                'Else
                'lDir = 0 ' clockwise
                'End If

                'move
                'Turntable.MoveToAngle(sngX, lDir, True, bAllowFullRotations) ' for Imperial TT we provide the delta angle rather than the target angle

        End Select

        If gblnCancel Then
            sbStatusLabel.Text = "Moving canceled by user."
        Else
            sbStatusLabel.Text = "Turntable is ready. Movement time: " & DateDiff(DateInterval.Second, MovingStart, System.DateTime.Now).ToString & " sec."
        End If

        pbTime.Value = 0
        UIReady()
        Return ""

SubTimeOut:
        TTStop()
        szErr = "Turntable timed out and is probably not working."
        gsngTTAngle = -1
        gblnTTInitialized = False
        sbStatusLabel.Text = szErr
        pbTime.Value = 0
        UIReady()
        Return szErr

SubError:
        TTStop()
        sbStatusLabel.Text = szErr
        pbTime.Value = 0
        UIReady()
        Return szErr

    End Function


    Private Function MoveToOffset(ByVal sngReqAngle As Double) As String
        ' move to the angle after reset:
        ' - don't check for the current angle
        ' - don't take offset into account
        ' - don't reset
        Dim szErr As String = ""
        Dim curToc, curTic, curTO As Long
        Dim lDir As Integer
        Dim curX, curY As Long

        ' nothing to do
        If gsngTTAngle = sngReqAngle Then MoveToOffset = szErr : Exit Function

        ' we have to move...
        pbTime.Value = 0
        sbStatusLabel.Text = "Moving to offset: " & TStr(sngReqAngle) & "°..."
        UIBusy()
        gblnTimeOut = False
        gblnCancel = False

        ' how many step ticks to move?
        Dim sngX As Double = sngReqAngle - gsngTTAngle
        If (sngX > 0 And sngX < 180) Or (sngX < -180) Then
            lDir = 1
        Else
            lDir = -1
        End If

        curTO = 2000 * gcurHPFrequency \ 1000
        QueryPerformanceCounter(curTic)
        curX = curTic
        ' move through the ticks
        Do
            If lDir > 0 Then TTGoCW() Else TTGoCCW()
            ' step inactive
            While (TTIsStep()) And (Not gblnTimeOut)
                Windows.Forms.Application.DoEvents()
                If TTIsStep() Then
                    QueryPerformanceCounter(curTic)
                Else
                    QueryPerformanceCounter(curX)
                End If
                QueryPerformanceCounter(curToc)
                If (curToc > (curTic + curTO)) Or (curToc > (curX + curTO)) Then
                    gblnTimeOut = True ' time out on: IsStep too long active or IsStep too long inactive
                Else
                    pbTime.Value = CInt(100 * (curToc - curTic) \ curTO)
                End If
            End While
            gsngTTAngle = gsngTTAngle + gsngTTResolution * lDir
            If gsngTTAngle >= 360 Then gsngTTAngle = gsngTTAngle - 360
            If gsngTTAngle < 0 Then gsngTTAngle = gsngTTAngle + 360
            ShowAngle(gsngTTAngle)
            If ((lDir < 0) And (gsngTTAngle <> sngReqAngle)) Or lDir > 0 Then
                ' step active
                While (Not TTIsStep()) And (Not gblnTimeOut)
                    Windows.Forms.Application.DoEvents()
                    If TTIsStep() Then
                        QueryPerformanceCounter(curTic)
                    End If
                    QueryPerformanceCounter(curToc)
                    If curToc > (curTic + curTO) Then
                        gblnTimeOut = True
                    Else
                        pbTime.Value = CInt(100 * (curToc - curTic) \ curTO)
                    End If
                End While
            End If
            If gblnTimeOut Or gblnCancel Then Exit Do
        Loop Until (gsngTTAngle = sngReqAngle) Or (gblnCancel)
        TTStop()
        ' move exact to the right phase
        If (Not gblnTimeOut) Then
            If lDir > 0 Then TTGoCW() Else TTGoCCW()
            ' move to falling edge of step
            While (TTIsStep()) And (Not gblnTimeOut)
                Windows.Forms.Application.DoEvents()
                If TTIsStep() Then
                    QueryPerformanceCounter(curTic)
                End If
                QueryPerformanceCounter(curToc)
                If curToc > (curTic + curTO) Then
                    gblnTimeOut = True
                Else
                    pbTime.Value = CInt(100 * (curToc - curTic) \ curTO)
                End If
            End While
            TTStop()
            ' wait 100ms
            QueryPerformanceCounter(curX)
            curX = curX + 100 * gcurHPFrequency \ 1000
            Do
                QueryPerformanceCounter(curY)
            Loop Until curY > curX
            ' move CCW to the rising edge of step in 20ms steps
            QueryPerformanceCounter(curTic)
            If Not TTIsStep() Then
                Do
                    TTGoCCW()
                    QueryPerformanceCounter(curX)
                    curX = curX + 20 * gcurHPFrequency \ 1000 ' wait 50 ms
                    Do
                        QueryPerformanceCounter(curY)
                    Loop Until curY > curX
                    TTStop()
                    QueryPerformanceCounter(curX)
                    curX = curX + 20 * gcurHPFrequency \ 1000 ' wait 50 ms
                    Do
                        QueryPerformanceCounter(curY)
                    Loop Until curY > curX
                    QueryPerformanceCounter(curToc)
                    If curToc > (curTic + curTO) Then gblnTimeOut = True
                Loop Until (TTIsStep()) Or gblnTimeOut
            End If
        End If

        If gblnTimeOut Then
            szErr = "Turntable timed out and is probably not working."
            gsngTTAngle = -1
            gblnTTInitialized = False
            GoTo SubError
        End If
        If gblnCancel Then
            gblnTTInitialized = False
            gsngTTAngle = -1
            szErr = "Moving canceled by user."
            GoTo SubError
        Else
            gsngTTAngle = gsngTTOffset
            sbStatusLabel.Text = "Turntable is ready."
        End If

        MoveToOffset = ""
        pbTime.Value = 0
        UIReady()
        Exit Function

SubError:
        MoveToOffset = szErr
        sbStatusLabel.Text = szErr
        pbTime.Value = 0
        UIReady()
        Exit Function

    End Function

    Private Function TTIsReset() As Boolean
        Select Case glTTMode
            Case 1 'Four Audio
                If gsngTTAngle = 0 Then TTIsReset = True
            Case 2 'Outline
                Dim bX As Byte
                On Error Resume Next
                bX = PortIn(glTTAddr)
                If bX <> 0 Then Debug.Print("TTIsReset: " & System.DateTime.Now.Hour.ToString & ":" & System.DateTime.Now.Minute.ToString & ":" & System.DateTime.Now.Second.ToString & " - " & bX.ToString)

                TTIsReset = (bX And 32) = 0
                On Error GoTo 0
            Case 3
                If gsngTTAngle = 0 Then TTIsReset = True
        End Select

    End Function

    Private Sub TTGoCCW()
        On Error Resume Next
        PortOut(glTTAddr, 32)
        cmdCCW.BackColor = System.Drawing.Color.Red
        On Error GoTo 0
    End Sub

    Private Sub TTGoCW()
        On Error Resume Next
        PortOut(glTTAddr, 8)
        cmdCW.BackColor = System.Drawing.Color.Red
        On Error GoTo 0
    End Sub

    Private Sub TTStop()
        On Error Resume Next
        PortOut(glTTAddr, 0)
        cmdCCW.BackColor = System.Drawing.SystemColors.Control
        cmdCW.BackColor = System.Drawing.SystemColors.Control
        On Error GoTo 0
    End Sub

    Private Function TTIsStep() As Boolean
        Dim bX As Byte
        Dim curTic As Long
        Static curToc As Long

        On Error Resume Next
        bX = PortIn(glTTAddr)
        If bX <> 0 Then Debug.Print("TTIsStep: " & System.DateTime.Now.Hour.ToString & ":" & System.DateTime.Now.Minute.ToString & ":" & System.DateTime.Now.Second.ToString & " - " & bX.ToString)

        TTIsStep = (bX And 8) = 0
        QueryPerformanceCounter(curTic)
        curToc = curTic
        On Error GoTo 0
    End Function

    Private Sub tmrUnload_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrUnload.Tick
        Me.Close()
    End Sub

    Private Sub txtReqPos_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtReqPos.Enter
        VB6.SetDefault(cmdMove, True)
    End Sub

    Private Sub txtReqPos_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtReqPos.Leave
        VB6.SetDefault(cmdCancel, True)
    End Sub


    Private Sub cmdPullBrake_Click(sender As Object, e As EventArgs) Handles cmdPullBrake.Click
        Turntable.PullBrake()
        sbStatusLabel.Text = "Turntable brake pulled."
    End Sub

    Private Sub cmdGet_Click(sender As Object, e As EventArgs) Handles cmdGet.Click
        Dim lPosition As Double = Turntable.GetAngle()

        ShowAngle((360 + lPosition) Mod 360)
    End Sub

    Private Sub tmrBreak_Tick(sender As Object, e As EventArgs) Handles tmrBrake.Tick

        'don't pull brake in some cases
        If glTT4aBrakeTimer < 0 Then Exit Sub 'timer disabled
        If gblnExperiment Then tmrBrake.Enabled = False : Exit Sub 'in experiment?
        If glTTMode <> 1 Then tmrBrake.Enabled = False : Exit Sub 'four audio?
        If gblnTTInitialized = False Then tmrBrake.Enabled = False : Exit Sub 'initialized?

        If System.DateTime.Now.Subtract(mStartTime).TotalSeconds > glTT4aBrakeTimer Then
            'pull brake
            Turntable.PullBrake()
            sbStatusLabel.Text = "Turntable brake pulled after: " & TStr(Math.Round(System.DateTime.Now.Subtract(mStartTime).TotalSeconds)) & " second(s)."
            'Debug.Print("Turntable brake pulled after: " & TStr(System.DateTime.Now.Subtract(mStartTime).TotalSeconds) & " seconds")

            tmrBrake.Stop()
        End If

    End Sub


    Public Sub StartTT4ATimer()

        ' stop old timers
        tmrBrake.Stop()
        ' check if timer useful
        If glTT4aBrakeTimer < 0 Then Exit Sub 'timer disabled
        If glTTMode <> 1 Then Exit Sub 'four audio?
        If gblnTTInitialized = False Then Exit Sub 'initialized?

        'don't pull brake during experiment
        If gblnExperiment Then tmrBrake.Enabled = False : Exit Sub

        Debug.Print("Start timer for turntable brake")

        mStartTime = System.DateTime.Now
        tmrBrake.Start()

    End Sub

    Public Sub StopTT4ATimer()

        'If glTT4aBrakeTimer < 0 Then Exit Sub 'disabled ... disabling timer does not harm anyway

        Debug.Print("Stop timer for turntable brake")
        tmrBrake.Stop()

    End Sub

    Private Sub tmrDelayed_Tick(sender As Object, e As EventArgs) Handles tmrDelayed.Tick
        tmrDelayed.Stop() 'Stop (delayed) timer

        Debug.Print("Delayed timer triggered.")
        frmMain.SetStatus("Delayed timer triggered.") 'remove later
       Turntable. DelayedMovementCommand

    End Sub

    Private Sub cmdSetSpeed_Click(sender As Object, e As EventArgs) Handles cmdSetSpeed.Click
        If Not IsNumeric(txtReqSpeed.Text) Then MsgBox("Input a valid numeric value between 0.5°/s and 4°/s",
                                MsgBoxStyle.Critical, "Set speed") : Return
        Dim sngX As Double = Val(txtReqSpeed.Text)
        If sngX >= 0.5 And sngX <= 4 Then
            Select Case glTTMode

                Case 3 'Imperial
                    ttSpeed = sngX
                    txtReqSpeed.Text = TStr(ttSpeed)
                    sbStatusLabel.Text = "Speed set to " & txtReqSpeed.Text & "°/s"

                    If sngX > 1 Then
                        MsgBox("Speeds higher than 1°/s might lead to inaccurate movements. They are fine to set the initial position of the turntable but be careful when using them during the actual measurements.", MsgBoxStyle.Information, "Set angle")
                    End If

            End Select

        Else
            MsgBox("Valid values: 0.5°/s to 4°/s", MsgBoxStyle.Critical, "Set speed")
            txtReqSpeed.Text = TStr(ttSpeed)
        End If

        UIReady()
    End Sub

End Class