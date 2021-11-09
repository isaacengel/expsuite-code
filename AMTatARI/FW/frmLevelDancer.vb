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
' used for electrical (CI listeners) binaural stimulation to balance the loudness
Friend Class frmLevelDancer
    Inherits System.Windows.Forms.Form
    Dim mblnPreventControl As Boolean
    Dim mblnShowStimulus As Boolean = False ' do not show as default

    Dim sldL As System.Collections.Generic.List(Of TrackBar)
    Dim sldR As System.Collections.Generic.List(Of TrackBar)
    Dim txtPhDurL As System.Collections.Generic.List(Of TextBox)
    Dim txtPhDurR As System.Collections.Generic.List(Of TextBox)
    Dim lblPhDurL As System.Collections.Generic.List(Of Label)
    Dim lblPhDurR As System.Collections.Generic.List(Of Label)

    Private mlStimLength As Integer
    Private mlInterauralBreak As Integer
    Private mblnDelayed As Boolean
    Private mblnLeftFirst As Boolean
    Private mblnChanged As Boolean
    Private mlElectrodeIndex As Short
    Private mlSliderIndex As Integer
    Private mszSettingTitle As String
    Private mbPlaying As Boolean


    ' results
    Private mlLevelL() As Integer
    Private mlLevelR() As Integer

    ' ------------------------------------------------------------------
    ' STIMULATION PART
    ' ------------------------------------------------------------------

    Private Sub ClearParameters()
        ' set user settings to default
        mlStimLength = 500
        txtPulsePeriodL.Text = TStr(Math.Round(F4FL.PulsePeriod * F4FL.TimeBase, 1))
        txtPulsePeriodR.Text = TStr(Math.Round(F4FR.PulsePeriod * F4FR.TimeBase, 1))
        mlInterauralBreak = 125
        mblnDelayed = False
        mblnLeftFirst = True
        mszSettingTitle = gszSettingFileName
        If Not IsNothing(mlLevelL) Then
            For lX As Integer = 0 To mlLevelL.Length - 1
                mlLevelL(lX) = CInt(gfreqParL(lX).sTHR)
            Next
        End If
        If Not IsNothing(mlLevelR) Then
            For lX As Integer = 0 To mlLevelR.Length - 1
                mlLevelR(lX) = CInt(gfreqParR(lX).sTHR)
            Next
        End If
    End Sub

    Private Sub CopyParametersToApplication()
        If mlStimLength <> CInt(Math.Round(Val(txtDuration.Text))) Then
            mlStimLength = CInt(Math.Round(Val(txtDuration.Text)))
        End If
        glLDStimLength = mlStimLength
        glInterStimBreak = mlInterauralBreak
        gblnLDDelayed = mblnDelayed
        gblnLDLeftFirst = mblnLeftFirst
        gsLDPulsePeriodL = Val(txtPulsePeriodL.Text)
        gsLDPulsePeriodR = Val(txtPulsePeriodR.Text)

        If IsNothing(mlLevelL) Then
            Erase gfreqParL
        Else
            ReDim Preserve gfreqParL(mlLevelL.Length - 1)
            For lX As Integer = 0 To gfreqParL.Length - 1
                gfreqParL(lX).sAmp = mlLevelL(lX)
                gfreqParL(lX).lPhDur = CInt(Val(txtPhDurL(lX).Text))
            Next
        End If
        If IsNothing(mlLevelR) Then
            Erase gfreqParR
        Else
            ReDim Preserve gfreqParR(mlLevelR.Length - 1)
            For lX As Integer = 0 To gfreqParR.Length - 1
                gfreqParR(lX).sAmp = mlLevelR(lX)
                gfreqParR(lX).lPhDur = CInt(Val(txtPhDurR(lX).Text))
            Next
        End If

        glAppendPulseTrainIndex = cmbAppendPulseTrain.SelectedIndex
        gszAppendPulseTrain = txtAppendPulseTrain.Text

    End Sub

    Private Sub CopyParametersFromApplication()
        mlStimLength = glLDStimLength
        mlInterauralBreak = glInterStimBreak
        mblnDelayed = gblnLDDelayed
        mblnLeftFirst = gblnLDLeftFirst
        mszSettingTitle = gszSettingFileName

        If IsNothing(gfreqParL) Then
            Erase mlLevelL
        Else
            ReDim mlLevelL(gfreqParL.Length - 1)
            For lX As Integer = 0 To gfreqParL.Length - 1
                mlLevelL(lX) = CInt(gfreqParL(lX).sAmp)
            Next
        End If
        If IsNothing(gfreqParR) Then
            Erase mlLevelR
        Else
            ReDim mlLevelR(gfreqParR.Length - 1)
            For lX As Integer = 0 To gfreqParR.Length - 1
                mlLevelR(lX) = CInt(gfreqParR(lX).sAmp)
            Next
        End If
    End Sub


    Private Function AppendStimulus(ByVal stPar() As clsSTIMULUS, ByVal lNr As Integer, _
                            ByVal lStimLen As Integer, ByVal lPulsePer As Integer) As String
        Dim lPNr As Integer
        Dim sOffset As Single
        Dim szErr As String = ""
        '  set:
        '      .lElectrode
        '      .lPhDur
        '      .lRange
        '      .sAmp
        '  no offset is used -> distinguish between RIB and RIB2 (RIB2 needs minimum offset of mindist [tu])
        '
        Select Case INISettings.gStimOutput            
            Case GENMODE.genElectricalRIB, GENMODE.genElectricalNIC
                sOffset = 0
            Case GENMODE.genElectricalRIB2, GENMODE.genVocoder
                sOffset = 33
        End Select

        lPNr = lStimLen \ lPulsePer

        Select Case cmbAppendPulseTrain.SelectedIndex
            Case 0 'Default (FrameWork)
                If lNr = 1 Then
                    ' single electrode
                    With stPar(0)
                        szErr = STIM.MatlabStimulus("FW_AppendPulseTrain", .sAmp, .lRange, .lElectrode, .lPhDur, lPNr, lPulsePer, sOffset)
                    End With
                Else
                    ' multiple electrodes,  electrode order: ascending
                    szErr = STIM.MatlabStimulus("FW_AppendCISPulseTrain", stPar, lPNr, lPulsePer, sOffset, 0)
                End If

            Case 1 'Application specific file

                Dim varPar() As Object = Nothing
                If txtAppendPulseTrain.Text <> "" Then varPar = Split(txtAppendPulseTrain.Text, ",")

                If lNr = 1 Then
                    ' single electrode
                    With stPar(0)
                        szErr = STIM.MatlabStimulus(gszAPP_TITLE & "_AppendPulseTrain", .sAmp, .lRange, .lElectrode, .lPhDur, lPNr, lPulsePer, sOffset, varPar)
                    End With
                Else
                    ' multiple electrodes,  electrode order: ascending
                    szErr = STIM.MatlabStimulus(gszAPP_TITLE & "_AppendCISPulseTrain", stPar, lPNr, lPulsePer, sOffset, 0, varPar)
                End If

        End Select


        Return szErr
    End Function

    Private Sub Stimulate()
        Dim stPar() As clsSTIMULUS = Nothing
        Dim lNr As Integer
        Dim lSum As Integer
        Dim szErr As String

        ' disable controls
        SetUIBusy()
        ' assemble stimulus for the left ear
        sbStatusBar.Items.Item(0).Text = "Stimulus for the left ear"
        sbStatusBar.Items.Item(1).BackColor = Color.Yellow

        ' get all parameters
        lSum = 0
        If Not IsNumeric(txtPulsePeriodL.Text) Or Len(txtPulsePeriodL.Text) = 0 Then
            szErr = "Pulse period for the left ear not valid." : GoTo suberror
        End If
        If Not IsNumeric(txtPulsePeriodR.Text) Or Len(txtPulsePeriodR.Text) = 0 Then
            szErr = "Pulse period for the right ear not valid." : GoTo suberror
        End If
        Dim lPPL As Integer = CInt(Val(txtPulsePeriodL.Text) / F4FL.TimeBase)
        Dim lPPR As Integer = CInt(Val(txtPulsePeriodR.Text) / F4FR.TimeBase)
        lNr = 0
        For lX As Integer = 0 To sldL.Count - 1
            If chkGroupL(CShort(lX)).CheckState = CheckState.Checked Then
                ReDim Preserve stPar(lNr)
                stPar(lNr) = New clsSTIMULUS
                With stPar(lNr)
                    .sAmp = mlLevelL(lX)
                    .lRange = F4FL.Channel(lX).lRange
                    .lElectrode = lX + 1
                    Dim lPD As Integer = CInt(Val(lblPhDurL(lX).Text))
                    If lPD < F4FL.PHDUR_MIN Then szErr = "Phase duration must be at least " & F4FL.PHDUR_MIN & " tu." : GoTo SubError
                    If lPD > F4FL.Channel(lX).lPhDur Then szErr = "Phase duration exceeds the maximum duration from the fitting file (" & TStr(F4FL.Channel(lX).lPhDur) & ")." : GoTo SubError
                    .lPhDur = lPD
                    lSum = lSum + .lPhDur
                End With
                lNr = lNr + 1
            End If
        Next
        ' check the stimulus length
        If lNr > 0 Then
            lSum = 2 * lSum + lNr ' pulse duration of all pulses = minimal pulse period
            If lSum > lPPL Then
                If MsgBox("The number of electrodes doesn't fit in the pulse period." & vbCrLf & _
                          "The stimulus will be longer than the given stimulus length." & vbCrLf & vbCrLf & _
                          "Do you want to continue?", _
                          MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, _
                          "Left channel") = MsgBoxResult.No Then
                    sbStatusBar.Items.Item(0).Text = "Stimulation canceled"
                    GoTo SubEnd
                End If
            End If
        End If
        ' create stimulus
        gstLeft.szStimFile = ""
        szErr = STIM.NewStimulus(gstLeft)
        If Len(szErr) <> 0 Then GoTo SubError
        If (Not mblnDelayed Or mblnLeftFirst) And (lNr > 0) Then
            szErr = AppendStimulus(stPar, lNr, _
                    CInt(Math.Round(mlStimLength * 1000 / gstLeft.sTimeBase)), _
                    lPPL)
        Else
            szErr = STIM.MatlabStimulus("FW_AppendBreak", mlStimLength * 1000 / gstLeft.sTimeBase)
        End If
        If Len(szErr) <> 0 Then GoTo SubError
        If mblnDelayed Then
            szErr = STIM.MatlabStimulus("FW_AppendBreak", mlInterauralBreak * 1000 / gstLeft.sTimeBase)
            If Len(szErr) <> 0 Then GoTo SubError
            If Not mblnLeftFirst And (lNr > 0) Then
                szErr = AppendStimulus(stPar, lNr, _
                        CInt(Math.Round(mlStimLength * 1000 / gstLeft.sTimeBase)), _
                        lPPL)
            Else
                szErr = STIM.MatlabStimulus("FW_AppendBreak", mlStimLength * 1000 / gstLeft.sTimeBase)
            End If
            If Len(szErr) <> 0 Then GoTo SubError
        End If
        szErr = STIM.AssembleStimulus(mblnShowStimulus)
        If Len(szErr) <> 0 Then GoTo SubError

        ' assemble stimulus for the right ear
        sbStatusBar.Items.Item(0).Text = "Stimulus for the right ear"
        sbStatusBar.Items.Item(2).BackColor = Color.Yellow
        ' get all parameters
        lSum = 0
        lNr = 0
        For lX As Integer = 0 To sldR.Count - 1
            If chkGroupR(CShort(lX)).CheckState = CheckState.Checked Then
                ReDim Preserve stPar(lNr)
                stPar(lNr) = New clsSTIMULUS
                With stPar(lNr)
                    .sAmp = mlLevelR(lX)
                    .lRange = F4FR.Channel(lX).lRange
                    .lElectrode = lX + 1
                    '.lPhDur = F4FR.Channel(lX).lPhDur
                    Dim lPD As Integer = CInt(Val(lblPhDurR(lX).Text))
                    If lPD < F4FR.PHDUR_MIN Then szErr = "Phase duration must be at least " & F4FR.PHDUR_MIN & " tu." : GoTo SubError
                    If lPD > F4FR.Channel(lX).lPhDur Then szErr = "Phase duration exceeds the maximum duration from the fitting file (" & TStr(F4FR.Channel(lX).lPhDur) & ")." : GoTo SubError
                    .lPhDur = lPD
                    lSum = lSum + .lPhDur
                End With
                lNr = lNr + 1
            End If
        Next
        ' check the stimulus length
        If lNr > 0 Then
            lSum = 2 * lSum + lNr ' pulse duration of all pulses = minimal pulse period
            If lSum > lPPR Then
                If MsgBox("The number of electrodes doesn't fit in the pulse period." & vbCrLf & "The stimulus will be longer than the given stimulus length." & vbCrLf & vbCrLf & "Do you want to continue?", _
                        MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, "Right channel") = MsgBoxResult.No Then
                    sbStatusBar.Items.Item(0).Text = "Stimulation canceled"
                    GoTo SubEnd
                End If
            End If
        End If
        ' create stimulus
        gstRight.szStimFile = ""
        szErr = STIM.NewStimulus(gstRight)
        If Len(szErr) <> 0 Then GoTo SubError
        If (Not mblnDelayed Or Not mblnLeftFirst) And (lNr > 0) Then
            szErr = AppendStimulus(stPar, lNr, _
                    CInt(Math.Round(mlStimLength * 1000 / gstRight.sTimeBase)), _
                    lPPR)
        Else
            szErr = STIM.MatlabStimulus("FW_AppendBreak", mlStimLength * 1000 / gstRight.sTimeBase)
        End If
        If Len(szErr) <> 0 Then GoTo SubError
        If mblnDelayed Then
            szErr = STIM.MatlabStimulus("FW_AppendBreak", mlInterauralBreak * 1000 / gstRight.sTimeBase)
            If Len(szErr) <> 0 Then GoTo SubError
            If mblnLeftFirst And (lNr > 0) Then
                szErr = AppendStimulus(stPar, lNr, _
                        CInt(Math.Round(mlStimLength * 1000 / gstRight.sTimeBase)), _
                        lPPR)
            Else
                szErr = STIM.MatlabStimulus("FW_AppendBreak", mlStimLength * 1000 / gstRight.sTimeBase)
            End If
            If Len(szErr) <> 0 Then GoTo SubError
        End If
        szErr = STIM.AssembleStimulus(mblnShowStimulus)
        If Len(szErr) <> 0 Then GoTo SubError

        ' load stimulation files
        sbStatusBar.Items.Item(0).Text = "Loading stimuli"
        szErr = Output.LoadStimulationFile((gstLeft.szStimFile), gstRight.szStimFile)
        If Len(szErr) <> 0 Then GoTo SubError
        ' start stimulation
        If gblnCancel Then
            sbStatusBar.Items.Item(0).Text = "Stimulation canceled"
            GoTo SubEnd
        End If
        sbStatusBar.Items.Item(0).Text = "Starting stimulation"
        If mlElectrodeIndex = -1 Then
            For lX As Short = 0 To CShort(chkGroupL.Count - 1)
                If chkGroupL(lX).CheckState = CheckState.Checked Then lblChL(lX).BackColor = Color.Red
            Next
            For lX As Short = 0 To CShort(chkGroupR.Count - 1)
                If chkGroupR(lX).CheckState = CheckState.Checked Then lblChR(lX).BackColor = Color.Red
            Next
        Else
            lblChL(mlElectrodeIndex).BackColor = Color.Red
            lblChR(mlElectrodeIndex).BackColor = Color.Red
        End If
        sbStatusBar.Items.Item(1).BackColor = Color.Red
        sbStatusBar.Items.Item(2).BackColor = Color.Red
        szErr = Output.StartStimulation
        If Len(szErr) <> 0 Then GoTo SubError
        ' wait for ready
        sbStatusBar.Items.Item(0).Text = "Stimulation in process - Please wait..."
        Dim lTO As Integer
        If mblnDelayed Then
            lTO = mlStimLength * 2 + mlInterauralBreak
        Else
            lTO = mlStimLength
        End If

        szErr = Output.WaitForReady(Math.Max(300, 2 * lTO + 100))  ' wait at least 300 ms, or longer for longer signal durations
        If Len(szErr) <> 0 Then GoTo SubError
        ' ready!
        sbStatusBar.Items.Item(0).Text = "Stimulation finished successfully"
SubEnd:
        SetUIReady()
        Return

SubError:
        MsgBox(szErr, MsgBoxStyle.Critical, "Stimulate")
        SetUIReady()
        Return

    End Sub

    ' ------------------------------------------------------------------
    ' USER INTERFACE - GENERAL
    ' ------------------------------------------------------------------

    Private Sub SetUIBusy()
        Dim lX As Integer
        ' menus
        mnuParameters.Enabled = False
        mnuView.Enabled = False
        ' controls
        chkDelayed.Enabled = False
        optLeftFirst.Enabled = False
        optRightFirst.Enabled = False
        ' conditional
        cmdGroupStimulate.Enabled = False
        For lX = 0 To chkGroupL.Count - 1
            chkGroupL(CShort(lX)).Enabled = False
        Next
        For lX = 0 To chkGroupR.Count - 1
            chkGroupR(CShort(lX)).Enabled = False
        Next
        Windows.Forms.Application.DoEvents()
    End Sub

    Private Sub SetUIReady()
        Dim lX As Integer
        ' menus
        mnuParameters.Enabled = True
        mnuView.Enabled = True
        ' controls
        chkDelayed.Enabled = True
        optLeftFirst.Enabled = mblnDelayed
        optRightFirst.Enabled = mblnDelayed
        For lX = 0 To lblChL.Count - 1
            lblChL(CShort(lX)).BackColor = System.Drawing.SystemColors.Control
        Next
        For lX = 0 To lblChR.Count - 1
            lblChR(CShort(lX)).BackColor = System.Drawing.SystemColors.Control
        Next
        sbStatusBar.Items.Item(1).BackColor = System.Drawing.SystemColors.Control
        sbStatusBar.Items.Item(2).BackColor = System.Drawing.SystemColors.Control

        ' stimulation is on
        ' buttons
        cmdGroupStimulate.Enabled = True
        For lX = 0 To sldL.Count - 1
            If F4FL.Channel(lX).lMCL > F4FL.Channel(lX).lTHR Then
                sldL(lX).Enabled = True
                chkGroupL(CShort(lX)).Enabled = True
            End If
        Next
        For lX = 0 To sldR.Count - 1
            If F4FR.Channel(lX).lMCL > F4FR.Channel(lX).lTHR Then
                sldR(lX).Enabled = True
                chkGroupR(CShort(lX)).Enabled = True
            End If
        Next
        ' menus
        mnuParametersLoad.Enabled = True
        mnuParametersReload.Enabled = True
        mnuParametersImport.Enabled = True
        mnuParametersExport.Enabled = True
        mnuParametersExportAmpElPairs.Enabled = True
        ' frames
        panelData.Visible = True
        Windows.Forms.Application.DoEvents()
    End Sub

    Private Sub SetChangedTitle()

        'If Not mblnChanged Then
        Me.Text = "Level Dancer " & My.Application.Info.Title & " [ " & mszSettingTitle & " * ]"
        mblnChanged = True
        ' enable menus

    End Sub

    Private Sub SetNewTitle()

        If mszSettingTitle = "" Then Exit Sub
        Me.Text = "Level Dancer " & My.Application.Info.Title & " [ " & mszSettingTitle & " ]"
        mblnChanged = False

    End Sub

    Private Sub SetNoTitle()

        Me.Text = "Level Dancer " & My.Application.Info.Title
        mblnChanged = False

    End Sub

    Private Sub ShowForm()
        mblnPreventControl = True
        ' general
        chkDelayed.CheckState = CType(-CInt(mblnDelayed), CheckState)
        If mblnLeftFirst Then optLeftFirst.Checked = True Else optRightFirst.Checked = True
        chkDelayed_CheckStateChanged(chkDelayed, New System.EventArgs())
        If Len(txtPulsePeriodL.Text) = 0 Or Not IsNumeric(txtPulsePeriodL.Text) Then
            lblPulseRateL.Text = "n.v."
        Else
            lblPulseRateL.Text = TStr(Math.Round(1000000.0 / Val(txtPulsePeriodL.Text), 1))
        End If
        If Len(txtPulsePeriodR.Text) = 0 Or Not IsNumeric(txtPulsePeriodR.Text) Then
            lblPulseRateR.Text = "n.v."
        Else
            lblPulseRateR.Text = TStr(Math.Round(1000000.0 / Val(txtPulsePeriodR.Text), 1))
        End If
        txtDuration.Text = TStr(mlStimLength)
        mblnPreventControl = False
        ' left
        For lX As Short = 0 To CShort(mlLevelL.Length - 1)
            With F4FL.Channel(lX)
                If mlLevelL(lX) < .lTHR Then mlLevelL(lX) = .lTHR
                If mlLevelL(lX) > .lMCL Then mlLevelL(lX) = .lMCL
                If lblLevelLabel.Text = "Level (cu)" Then
                    lblLevelL(lX).Text = TStr(F4FL.Channel(lX).lRange) & ":" & TStr(mlLevelL(lX))
                    lblMCLL(lX).Text = TStr(.lRange) & ":" & TStr(.lMCL)
                    lblTHRL(lX).Text = TStr(.lRange) & ":" & TStr(.lTHR)
                Else
                    lblLevelL(lX).Text = F4FL.CalcCurrentAsString(mlLevelL(lX), F4FL.Channel(lX).lRange)
                    lblMCLL(lX).Text = F4FL.CalcCurrentAsString(.lMCL, .lRange)
                    lblTHRL(lX).Text = F4FL.CalcCurrentAsString(.lTHR, .lRange)
                End If
                lblDrL(lX).Text = CU2DR(lX, 0) & "%"
                sldL(lX).Value = mlLevelL(lX)
            End With
        Next
        ' right
        For lX As Short = 0 To CShort(mlLevelR.Length - 1)
            With F4FR.Channel(lX)
                If mlLevelR(lX) < .lTHR Then mlLevelR(lX) = .lTHR
                If mlLevelR(lX) > .lMCL Then mlLevelR(lX) = .lMCL
                If lblLevelLabel.Text = "Level (cu)" Then
                    lblLevelR(lX).Text = TStr(F4FR.Channel(lX).lRange) & ":" & TStr(mlLevelR(lX))
                    lblMCLR(lX).Text = TStr(.lRange) & ":" & TStr(.lMCL)
                    lblTHRR(lX).Text = TStr(.lRange) & ":" & TStr(.lTHR)
                Else
                    lblLevelR(lX).Text = F4FR.CalcCurrentAsString(mlLevelR(lX), F4FR.Channel(lX).lRange)
                    lblMCLR(lX).Text = F4FR.CalcCurrentAsString(.lMCL, .lRange)
                    lblTHRR(lX).Text = F4FR.CalcCurrentAsString(.lTHR, .lRange)
                End If
                lblDrR(lX).Text = CU2DR(lX, 1) & "%"
                sldR(lX).Value = mlLevelR(lX)
            End With
        Next

        mblnPreventControl = False

        SetNewTitle()

    End Sub

    Private Function CU2DR(lX As Integer, ear As Integer) As String

        If ear = 0 Then
            If F4FL.Channel(lX).lMCL <= F4FL.Channel(lX).lTHR Then Return "0"
            Return TStr(Math.Round(100 * (mlLevelL(lX) - F4FL.Channel(lX).lTHR) / (F4FL.Channel(lX).lMCL - F4FL.Channel(lX).lTHR), 1))
        ElseIf ear = 1 Then
            If F4FR.Channel(lX).lMCL <= F4FR.Channel(lX).lTHR Then Return "0"
            Return TStr(Math.Round(100 * (mlLevelR(lX) - F4FR.Channel(lX).lTHR) / (F4FR.Channel(lX).lMCL - F4FR.Channel(lX).lTHR), 1))
        Else
            Return ""
        End If

    End Function

    Private Sub BuildForm()
        Dim lMax As Integer
        mblnPreventControl = True
        ' Load new controls
        lMax = mlLevelL.Length
        If mlLevelR.Length > lMax Then lMax = mlLevelR.Length
        ' general
        For lX As Short = 1 To CShort(lMax - 1)
            lblCh.Load(lX)
            lblCh(lX).Left = lblCh(0).Left + lblCh(0).Width * lX
            lblCh(lX).Text = Str(lX + 1)
            lblCh(lX).Padding = lblCh(0).Padding
            lblCh(lX).Font = lblCh(0).Font
            lblCh(lX).Visible = True
            lblCh(lX).BringToFront()
            lblChL.Load(lX)
            lblChL(lX).Left = lblChL(0).Left + lblCh(0).Width * lX
            lblChL(lX).Visible = True
            lblChL(lX).BringToFront()
            lblChR.Load(lX)
            lblChR(lX).Left = lblChR(0).Left + lblCh(0).Width * lX
            lblChR(lX).Visible = True
            lblChR(lX).BringToFront()
        Next
        ' left
        sldL = New System.Collections.Generic.List(Of TrackBar)
        sldL.Insert(0, _sldL_0)
        lblPhDurL = New System.Collections.Generic.List(Of Label)
        lblPhDurL.Insert(0, Me._lblPhDurL_0)
        txtPhDurL = New System.Collections.Generic.List(Of TextBox)
        txtPhDurL.Insert(0, Me._txtPhDurL_0)
        sbStatusBar.Items.Item(1).Text = gstLeft.szImpType
        For lX As Short = 1 To CShort(mlLevelL.Length - 1)
            chkGroupL.Load(lX)
            chkGroupL(lX).Left = chkGroupL(0).Left + lblCh(0).Width * lX
            chkGroupL(lX).Visible = True
            chkGroupL(lX).BringToFront()
            Dim sldX As New TrackBar
            AddHandler sldX.ValueChanged, AddressOf Me.sldL_Change
            AddHandler sldX.KeyDown, AddressOf Me.sldL_KeyDownEvent
            AddHandler sldX.Leave, AddressOf Me.sldL_Leave
            AddHandler sldX.Scroll, AddressOf Me.sldL_Scroll
            AddHandler sldX.KeyPress, AddressOf Me.sldL_KeyPressEvent
            AddHandler sldX.Enter, AddressOf Me.sldL_Enter
            sldX.Left = sldL(0).Left + lblCh(0).Width * lX
            sldX.Top = sldL(0).Top
            sldX.Orientation = Orientation.Vertical
            sldX.AutoSize = False
            sldX.Size = sldL(0).Size
            sldX.TickFrequency = sldL(0).TickFrequency
            sldX.BackColor = _sldL_0.BackColor
            sldX.Visible = True
            sldL.Insert(lX, sldX)
            Me.Controls.Add(sldX)
            sldX.BringToFront()
            lblMCLL.Load(lX)
            lblMCLL(lX).Left = lblMCLL(0).Left + lblCh(0).Width * lX
            lblMCLL(lX).Visible = True
            lblMCLL(lX).BringToFront()
            lblTHRL.Load(lX)
            lblTHRL(lX).Left = lblTHRL(0).Left + lblCh(0).Width * lX
            lblTHRL(lX).Visible = True
            lblTHRL(lX).BringToFront()
            lblLevelL.Load(lX)
            lblLevelL(lX).Left = lblLevelL(0).Left + lblCh(0).Width * lX
            lblLevelL(lX).Visible = True
            lblLevelL(lX).BringToFront()
            lblDrL.Load(lX)
            lblDrL(lX).Left = lblDrL(0).Left + lblCh(0).Width * lX
            lblDrL(lX).Visible = True
            lblDrL(lX).BringToFront()
            lblDynamicL.Load(lX)
            lblDynamicL(lX).Left = lblDynamicL(0).Left + lblCh(0).Width * lX
            lblDynamicL(lX).Visible = True
            lblDynamicL(lX).BringToFront()
            Dim txtX As New TextBox
            AddHandler txtX.Validating, AddressOf Me.txtPhDurL_Validating
            txtX.Left = txtPhDurL(0).Left + lblCh(0).Width * lX
            txtX.Top = txtPhDurL(0).Top
            txtX.Size = txtPhDurL(0).Size
            txtX.Visible = True
            txtPhDurL.Insert(lX, txtX)
            Me.Controls.Add(txtX)
            txtX.BringToFront()
            Dim labX As New Label
            labX.Left = lblPhDurL(0).Left + lblCh(0).Width * lX
            labX.Top = lblPhDurL(0).Top
            labX.AutoSize = False
            labX.Size = lblPhDurL(0).Size
            txtX.Visible = True
            lblPhDurL.Insert(lX, labX)
            Me.Controls.Add(labX)
            labX.BringToFront()
        Next
        ' right
        sldR = New System.Collections.Generic.List(Of TrackBar)
        sldR.Insert(0, _sldR_0)
        lblPhDurR = New System.Collections.Generic.List(Of Label)
        txtPhDurR = New System.Collections.Generic.List(Of TextBox)
        lblPhDurR.Insert(0, Me._lblPhDurR_0)
        txtPhDurR.Insert(0, Me._txtPhDurR_0)
        sbStatusBar.Items.Item(2).Text = gstRight.szImpType
        For lX As Short = 1 To CShort(mlLevelR.Length - 1)
            chkGroupR.Load(lX)
            chkGroupR(lX).Left = chkGroupR(0).Left + lblCh(0).Width * lX
            chkGroupR(lX).Visible = True
            chkGroupR(lX).BringToFront()
            Dim sldX As New TrackBar
            AddHandler sldX.ValueChanged, AddressOf Me.sldR_Change
            AddHandler sldX.KeyDown, AddressOf Me.sldR_KeyDownEvent
            AddHandler sldX.Leave, AddressOf Me.sldR_Leave
            AddHandler sldX.Scroll, AddressOf Me.sldR_Scroll
            AddHandler sldX.KeyPress, AddressOf Me.sldR_KeyPressEvent
            AddHandler sldX.Enter, AddressOf Me.sldR_Enter
            sldX.Left = sldR(0).Left + lblCh(0).Width * lX
            sldX.Top = sldR(0).Top
            sldX.Orientation = Orientation.Vertical
            sldX.AutoSize = False
            sldX.Size = sldR(0).Size
            sldX.TickFrequency = sldR(0).TickFrequency
            sldX.BackColor = _sldR_0.BackColor
            sldX.TickStyle = TickStyle.TopLeft
            sldX.Visible = True
            sldR.Insert(lX, sldX)
            Me.Controls.Add(sldX)
            sldX.BringToFront()
            lblMCLR.Load(lX)
            lblMCLR(lX).Left = lblMCLR(0).Left + lblCh(0).Width * lX
            lblMCLR(lX).Visible = True
            lblMCLR(lX).BringToFront()
            lblTHRR.Load(lX)
            lblTHRR(lX).Left = lblTHRR(0).Left + lblCh(0).Width * lX
            lblTHRR(lX).Visible = True
            lblTHRR(lX).BringToFront()
            lblLevelR.Load(lX)
            lblLevelR(lX).Left = lblLevelR(0).Left + lblCh(0).Width * lX
            lblLevelR(lX).Visible = True
            lblLevelR(lX).BringToFront()
            lblDrR.Load(lX)
            lblDrR(lX).Left = lblDrR(0).Left + lblCh(0).Width * lX
            lblDrR(lX).Visible = True
            lblDrR(lX).BringToFront()
            lblDynamicR.Load(lX)
            lblDynamicR(lX).Left = lblDynamicR(0).Left + lblCh(0).Width * lX
            lblDynamicR(lX).Visible = True
            lblDynamicR(lX).BringToFront()
            Dim txtX As New TextBox
            AddHandler txtX.Validating, AddressOf Me.txtPhDurR_Validating
            txtX.Left = txtPhDurR(0).Left + lblCh(0).Width * lX
            txtX.Top = txtPhDurR(0).Top
            txtX.Size = txtPhDurR(0).Size
            txtX.Visible = True
            txtPhDurR.Insert(lX, txtX)
            Me.Controls.Add(txtX)
            txtX.BringToFront()
            Dim labX As New Label
            labX.Left = lblPhDurR(0).Left + lblCh(0).Width * lX
            labX.Top = lblPhDurR(0).Top
            labX.AutoSize = False
            labX.Size = lblPhDurR(0).Size
            txtX.Visible = True
            lblPhDurR.Insert(lX, labX)
            Me.Controls.Add(labX)
            labX.BringToFront()
        Next
        For lX As Short = 0 To CShort(lineGrid.Count - 1)
            lineGrid(lX).Left = lblCh(0).Left \ 3
            lineGrid(lX).Width = lblCh(CShort(lMax - 1)).Left + lblCh(0).Width - lineGrid(lX).Left + 8 '(lMax + 1) * lblCh(0).Width
            lineGrid(lX).BringToFront()
        Next
        ' Set controls
        ' left
        For lX As Short = 0 To CShort(mlLevelL.Length - 1)
            With F4FL.Channel(lX)
                If mlLevelL(lX) < .lTHR Then mlLevelL(lX) = .lTHR
                If mlLevelL(lX) > .lMCL Then mlLevelL(lX) = .lMCL
                If .lTHR < .lMCL Then
                    sldL(lX).Enabled = True
                    sldL(lX).Maximum = .lMCL
                    sldL(lX).Minimum = .lTHR
                    sldL(lX).Value = mlLevelL(lX)
                    chkGroupL(lX).Enabled = True
                    lblDynamicL(lX).Text = TStr(Math.Round(20 * Log10(.lMCL - .lTHR), 1))
                Else
                    sldL(lX).Enabled = False
                    sldL(lX).Minimum = .lTHR
                    sldL(lX).Maximum = .lTHR + 1
                    sldL(lX).Value = .lTHR
                    chkGroupL(lX).CheckState = System.Windows.Forms.CheckState.Unchecked
                    chkGroupL(lX).Enabled = False
                    lblDynamicL(lX).Text = "---"
                End If
                lblMCLL(lX).Text = TStr(.lRange) & ":" & TStr(.lMCL)
                lblTHRL(lX).Text = TStr(.lRange) & ":" & TStr(.lTHR)
            End With
            txtPhDurL(lX).Text = TStr(gfreqParL(lX).lPhDur)
            lblPhDurL(lX).Text = TStr(Math.Round(gfreqParL(lX).lPhDur / F4FL.TimeBase))
        Next
        lblNameL.Text = F4FL.FirstName & " " & F4FL.LastName
        txtPulsePeriodL.Text = TStr(gsLDPulsePeriodL)

        ' right
        For lX As Short = 0 To CShort(mlLevelR.Length - 1)
            With F4FR.Channel(lX)
                If mlLevelR(lX) < .lTHR Then mlLevelR(lX) = .lTHR
                If mlLevelR(lX) > .lMCL Then mlLevelR(lX) = .lMCL
                If .lTHR < .lMCL Then
                    sldR(lX).Enabled = True
                    sldR(lX).Maximum = .lMCL
                    sldR(lX).Minimum = .lTHR
                    sldR(lX).Value = mlLevelR(lX)
                    chkGroupR(lX).Enabled = True
                    lblDynamicR(lX).Text = TStr(Math.Round(20 * Log10(.lMCL - .lTHR), 1))
                Else
                    sldR(lX).Enabled = False
                    sldR(lX).Minimum = .lTHR
                    sldR(lX).Maximum = .lTHR + 1
                    sldR(lX).Value = .lTHR
                    chkGroupR(lX).CheckState = System.Windows.Forms.CheckState.Unchecked
                    chkGroupR(lX).Enabled = False
                    lblDynamicR(lX).Text = "---"
                End If
                lblMCLR(lX).Text = TStr(.lRange) & ":" & TStr(.lMCL)
                lblTHRR(lX).Text = TStr(.lRange) & ":" & TStr(.lTHR)
            End With
            txtPhDurR(lX).Text = TStr(gfreqParR(lX).lPhDur)
            lblPhDurR(lX).Text = TStr(Math.Round(gfreqParR(lX).lPhDur / F4FR.TimeBase))
        Next
        If F4FL.FirstName <> F4FR.FirstName Or F4FL.LastName <> F4FR.LastName Then
            MsgBox("Subject name: left ear not equal right ear." & vbCrLf & _
                    "  Left ear: " & F4FL.FirstName & " " & F4FL.LastName & vbCrLf & _
                    "Right ear: " & F4FR.FirstName & " " & F4FR.LastName, _
                    MsgBoxStyle.Exclamation)
            lblNameL.Text = F4FL.FirstName & " " & F4FL.LastName & " / " & F4FR.FirstName & " " & F4FR.LastName
        End If
        txtPulsePeriodR.Text = TStr(gsLDPulsePeriodR)
        mblnPreventControl = False
        cmbAppendPulseTrain.Items.Add("FrameWork (Default)")
        cmbAppendPulseTrain.Items.Add("Application")
        cmbAppendPulseTrain.SelectedIndex = glAppendPulseTrainIndex
        txtAppendPulseTrain.Text = gszAppendPulseTrain

        If gbShowDR Then
            rDR.Checked = True
        Else
            rCU.Checked = True
        End If

    End Sub

    ' ------------------------------------------------------------------
    ' EVENTS - Controls
    ' ------------------------------------------------------------------

    Private Sub chkDelayed_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkDelayed.CheckStateChanged
        If mblnDelayed Then
            optLeftFirst.Enabled = True
            optRightFirst.Enabled = True
        Else
            optLeftFirst.Enabled = False
            optRightFirst.Enabled = False
        End If
        If mblnPreventControl Then Return
        mblnDelayed = CBool(chkDelayed.CheckState)
        SetChangedTitle()
        SetUIReady()
    End Sub

    Private Sub cmdGroup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGroup.Click
        Dim Index As Short = cmdGroup.GetIndex(DirectCast(eventSender, Button))
        Dim lX As Short
        Select Case Index
            Case 0 ' all left
                For lX = 0 To CShort(chkGroupL.Count - 1)
                    If chkGroupL(lX).Enabled Then chkGroupL(lX).CheckState = System.Windows.Forms.CheckState.Checked
                Next
            Case 1 ' all right
                For lX = 0 To CShort(chkGroupR.Count - 1)
                    If chkGroupR(lX).Enabled Then chkGroupR(lX).CheckState = System.Windows.Forms.CheckState.Checked
                Next
            Case 2 ' none left
                For lX = 0 To CShort(chkGroupL.Count - 1)
                    If chkGroupL(lX).Enabled Then chkGroupL(lX).CheckState = System.Windows.Forms.CheckState.Unchecked
                Next
            Case 3 ' none right
                For lX = 0 To CShort(chkGroupR.Count - 1)
                    If chkGroupR(lX).Enabled Then chkGroupR(lX).CheckState = System.Windows.Forms.CheckState.Unchecked
                Next
        End Select
    End Sub

    Private Sub cmdGroupStimulate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGroupStimulate.Click
        If mbPlaying = False Then
            mbPlaying = True

            ' check grouping of electrodes
            Dim lNr As Integer = 0
            For lX As Short = 0 To CShort(sldL.Count - 1)
                If chkGroupL(lX).CheckState = CheckState.Checked Then lNr = lNr + 1
            Next
            If lNr = 0 Then
                ' left electrodes not set
                For lX As Short = 0 To CShort(sldR.Count - 1)
                    If chkGroupR(lX).CheckState = CheckState.Checked Then lNr = lNr + 1
                Next
                If lNr = 0 Then
                    ' no electrode set
                    MsgBox("Set at least one electrode (left or right) to stimulate." & vbCrLf & "Stimulation aborted.", MsgBoxStyle.Critical, "Stimulate Electrode Group")
                    GoTo SubEnd
                End If
            End If

            ' Stimulate group
            gblnCancel = False
            mlElectrodeIndex = -1
            Stimulate()
SubEnd:
            If (mlSliderIndex And &H10000) <> 0 Then
                sldR(mlSliderIndex And &HFFS).Focus()
            Else
                sldL(mlSliderIndex).Focus()
            End If
            mbPlaying = False
        End If
        Windows.Forms.Application.DoEvents()

    End Sub

    Private Sub frmLevelDancer_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If eventArgs.KeyCode = System.Windows.Forms.Keys.Escape Then gblnCancel = True
    End Sub

    Private Sub frmLevelDancer_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If txtAppendPulseTrain.Focused = True Then Exit Sub

        Select Case Asc(eventArgs.KeyChar)
            Case Asc("l")
                If TypeOf (Me.ActiveControl) Is TrackBar Then Return
                Dim lX As Integer = 0
                Do Until lX = sldL.Count Or (sldL(lX).Enabled And sldL(lX).Visible)
                    lX += lX
                Loop
                If lX < sldL.Count Then sldL(lX).Focus()
            Case Asc("r")
                If TypeOf (Me.ActiveControl) Is TrackBar Then Return
                Dim lX As Integer = 0
                Do Until lX = sldR.Count Or (sldR(lX).Enabled And sldR(lX).Visible)
                    lX = lX + 1
                Loop
                If lX < sldR.Count Then sldR(lX).Focus()
            Case Asc("d")
                If panelData.Visible Then chkDelayed.Checked = Not chkDelayed.Checked
            Case Asc("f")
                If chkDelayed.CheckState = CheckState.Checked Then
                    If optLeftFirst.Checked And panelData.Visible Then optRightFirst.Checked = True Else optLeftFirst.Checked = True
                End If
        End Select
    End Sub

    Private Sub frmLevelDancer_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        ' set global settings
        ' check left
        If grectLevelDancer.Left + 0.25 * Me.Width > Screen.PrimaryScreen.Bounds.Width Then
            grectLevelDancer.Left = Screen.PrimaryScreen.Bounds.Width - Me.Width \ 4
        End If
        If grectLevelDancer.Left + 0.75 * Me.Width < 0 Then
            grectLevelDancer.Left = -3 * Me.Width \ 4
        End If
        ' check top
        If grectLevelDancer.Top + 0.25 * Me.Height > Screen.PrimaryScreen.Bounds.Height Then
            grectLevelDancer.Top = Screen.PrimaryScreen.Bounds.Height - Me.Height \ 4
        End If
        If grectLevelDancer.Top < 0 Then
            grectLevelDancer.Top = 0
        End If
        Me.SetBounds(grectLevelDancer.Left, grectLevelDancer.Top, 0, 0, _
                    BoundsSpecified.X Or BoundsSpecified.Y)

        ' set user settings to default
        CopyParametersFromApplication()

        ' show forms
        BuildForm()
        ShowForm()
        SetUIReady()

    End Sub

    Private Sub frmLevelDancer_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ' save options
        grectLevelDancer.Left = Me.Left
        grectLevelDancer.Top = Me.Top
    End Sub


    Private Sub frmLevelDancer_FormClosing(ByVal eventSender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' make sure
        If mblnChanged Then
            Dim lR As MsgBoxResult = MsgBox("Pass changes to the application?", _
                MsgBoxStyle.YesNoCancel Or MsgBoxStyle.DefaultButton3 Or MsgBoxStyle.Exclamation, "Exit Level Dancer")
            If lR = MsgBoxResult.Cancel Then e.Cancel = True : Return
            If lR = MsgBoxResult.No Then e.Cancel = False : Return
            If lR = MsgBoxResult.Yes Then
                Me.CopyParametersToApplication()
                e.Cancel = False
            End If
        End If
    End Sub


    Public Sub mnuExportAmp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuParametersExport.Click
        Dim lX, lNr As Integer
        Dim szArr(,) As String
        Dim szX, szFile As String

        ' count enabled memories
        szX = InputBox("Input the name of the table to export:", "Export Amplitudes", "Standard")
        If Len(szX) = 0 Then Return
        ReDim szArr(UBound(mlLevelL) + UBound(mlLevelR) + 2, 3)
        szArr(0, 0) = "Table"
        szArr(0, 1) = "Electrode"
        szArr(0, 2) = "Channel"
        szArr(0, 3) = "Amplitude"
        lNr = 1
        For lX = 0 To UBound(mlLevelL)
            szArr(lNr, 0) = szX
            szArr(lNr, 1) = CStr(lX + 1)
            szArr(lNr, 2) = "0"
            szArr(lNr, 3) = CStr(mlLevelL(lX))
            lNr = lNr + 1
        Next
        For lX = 0 To UBound(mlLevelR)
            szArr(lNr, 0) = szX
            szArr(lNr, 1) = CStr(lX + 1)
            szArr(lNr, 2) = "1"
            szArr(lNr, 3) = CStr(mlLevelR(lX))
            lNr = lNr + 1
        Next

        Dim dlgSave As New SaveFileDialog
        dlgSave.Title = "Export Amplitudes"
        If InStrRev(mszSettingTitle, ".esf") > 0 Then 'old
            szX = Mid(mszSettingTitle, 1, InStrRev(mszSettingTitle, ".esf") - 1)
        ElseIf InStrRev(mszSettingTitle, "." & My.Application.Info.AssemblyName) > 0 Then 'new
            szX = Mid(mszSettingTitle, 1, InStrRev(mszSettingTitle, "." & My.Application.Info.AssemblyName) - 1)
        Else
            szX = mszSettingTitle
        End If
        dlgSave.FileName = szX & ".signal"
        dlgSave.InitialDirectory = gszCurrentDir
        dlgSave.OverwritePrompt = True
        dlgSave.Filter = "Signal Files (*.signal)|*.signal|All Files (*.*)|*.*"
        dlgSave.FilterIndex = 0
        If dlgSave.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
        szFile = dlgSave.FileName
        gszCurrentDir = Mid(szFile, 1, Len(szFile) - Len((New System.IO.DirectoryInfo(szFile)).Name))
        Dim csvX As New CSVParser
        szX = csvX.WriteArr(szFile, szArr)
        If Len(szX) > 0 Then
            MsgBox("Error creating file " & szFile & vbCrLf & szX)
        End If

    End Sub

    Public Sub mnuExportAmpElPairs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuParametersExportAmpElPairs.Click
        Dim lNr, lX, lY As Integer
        Dim szArr(,) As String
        Dim szX, szFile As String

        For lX = 0 To UBound(mlLevelL)
            If chkGroupL(CShort(lX)).CheckState = CheckState.Checked Then lNr = lNr + 1
        Next
        For lX = 0 To UBound(mlLevelR)
            If chkGroupR(CShort(lX)).CheckState = CheckState.Checked Then lY = lY + 1
        Next
        If lNr = 0 Then MsgBox("No left electrodes selected") : Return
        If lY = 0 Then MsgBox("No right electrodes selected") : Return

        lNr = lNr * lY ' number of combinations
        ' first row
        ReDim szArr(lNr, 3)
        szArr(0, 0) = "El L"
        szArr(0, 1) = "El R"
        szArr(0, 2) = "Amp L"
        szArr(0, 3) = "Amp R"

        lNr = 1
        For lX = 0 To UBound(mlLevelL)
            For lY = 0 To UBound(mlLevelR)
                If chkGroupL(CShort(lX)).CheckState = CheckState.Checked And _
                    chkGroupR(CShort(lY)).CheckState = CheckState.Checked Then
                    szArr(lNr, 0) = Str(lX + 1)
                    szArr(lNr, 1) = Str(lY + 1)
                    szArr(lNr, 2) = Str(mlLevelL(lX))
                    szArr(lNr, 3) = Str(mlLevelR(lY))
                    lNr = lNr + 1
                End If
            Next
        Next

        Dim dlgSave As New SaveFileDialog
        dlgSave.Title = "Export Binaural Amp-El-Pairs"
        If InStrRev(mszSettingTitle, ".esf") > 0 Then 'old
            szX = Mid(mszSettingTitle, 1, InStrRev(mszSettingTitle, ".esf") - 1)
        ElseIf InStrRev(mszSettingTitle, "." & My.Application.Info.AssemblyName) > 0 Then 'new
            szX = Mid(mszSettingTitle, 1, InStrRev(mszSettingTitle, "." & My.Application.Info.AssemblyName) - 1)
        Else
            szX = mszSettingTitle
        End If

        dlgSave.FileName = szX & "_ampel.csv"
        dlgSave.InitialDirectory = gszCurrentDir
        dlgSave.OverwritePrompt = True
        dlgSave.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
        dlgSave.FilterIndex = 0
        If dlgSave.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
        szFile = dlgSave.FileName
        gszCurrentDir = Mid(dlgSave.FileName, 1, Len(dlgSave.FileName) - Len((New System.IO.DirectoryInfo(dlgSave.FileName)).Name))
        Dim csvX As New CSVParser
        szX = csvX.WriteArr(szFile, szArr)
        If Len(szX) > 0 Then
            MsgBox("Error creating file " & szFile & vbCrLf & szX)
        End If

    End Sub

    Public Sub mnuHelpShortcuts_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuHelpShortcuts.Click
        MsgBox("Shortcuts used in menus:" & vbCrLf & _
        "LEFT" & vbTab & "Set focus to the left slider (wrap around on first one)" & vbCrLf & _
        "RIGHT" & vbTab & "Set focus to the right slider (wrap around on the last one)" & vbCrLf & _
        "UP" & vbTab & "Increase amplitude of the active electrode" & vbCrLf & _
        "DOWN" & vbTab & "Decrease amplitude of the active electrode" & vbCrLf & _
        "PAGE UP" & vbTab & "Increase the amplitude by 5 current units/percent" & vbCrLf & _
        "PAGE DN" & vbTab & "Decrease the amplitude by 5 current units/percent" & vbCrLf & _
        "CTRL+LEFT/RIGHT" & vbTab & "Increase all active left/right amplitudes and" & vbCrLf & vbTab & "decrease the other side by 1 current unit/percent" & vbCrLf & _
        "SHIFT+LEFT/RIGHT" & vbTab & "Increase all active left/right amplitudes and" & vbCrLf & vbTab & "decrease the other side by 5 current units/percent" & vbCrLf & _
        "L" & vbTab & "(Left) Set focus to the left channel" & vbCrLf & _
        "R" & vbTab & "(Right) Set focus to the right channel" & vbCrLf & _
        "G" & vbTab & "(Group) Toggle the groupping check box" & vbCrLf & _
        "SPACE, RETURN or" & vbCrLf & _
        "S" & vbTab & "(Stimulate) Stimulate grouped electrodes" & vbCrLf & _
        "ESC" & vbTab & "(Escape) Cancel the stimulation" & vbCrLf & _
        "D" & vbTab & "(Delayed) Toggle the delayed check box" & vbCrLf & _
        "F" & vbTab & "(First) Toggle the first channel in delayed mode")

    End Sub

    Public Sub mnuImportAmp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuParametersImport.Click
        Dim lY, lX, lAmp As Integer
        Dim szErr As String
        Dim szArr(,) As String = Nothing
        Dim blnErr As Boolean
        Dim lColCh, lColEl, lColAmp As Integer
        Dim szTable As String

        ' read signal file as csv
        Dim dlgOpen As New OpenFileDialog
        dlgOpen.InitialDirectory = gszCurrentDir
        dlgOpen.FileName = ""
        dlgOpen.Title = "Import a signal file with amplitude values..."
        dlgOpen.CheckFileExists = True
        dlgOpen.CheckPathExists = True
        dlgOpen.CheckPathExists = True
        dlgOpen.Filter = "Signal Files (*.signal)|*.signal|All Files (*.*)|*.*"
        dlgOpen.FilterIndex = 0
        If dlgOpen.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
        Dim csvX As New CSVParser
        szErr = csvX.ReadArr(dlgOpen.FileName, szArr)
        gszCurrentDir = Mid(dlgOpen.FileName, 1, Len(dlgOpen.FileName) - Len((New System.IO.DirectoryInfo(dlgOpen.FileName)).Name))
        If Len(szErr) <> 0 Then
            MsgBox("Error reading signal file:" & vbCrLf & szErr)
            Return
        End If
        If szArr.Length <= 0 Then
            MsgBox("File is empty.")
            Return
        End If
        ' parse columns
        lColEl = -1
        lColAmp = -1
        lColCh = -1
        szTable = ""
        For lX = 0 To UBound(szArr, 2)
            If LCase(szArr(0, lX)) = "electrode" Then lColEl = lX
            If LCase(szArr(0, lX)) = "amplitude" Then lColAmp = lX
            If LCase(szArr(0, lX)) = "channel" Then lColCh = lX
            If LCase(szArr(0, lX)) = "table" Then szTable = szArr(1, lX)
        Next
        szErr = ""
        If lColEl = -1 Then szErr = szErr & "Column 'Electrode' not found" & vbCrLf
        If lColAmp = -1 Then szErr = szErr & "Column 'Amplitude' not found" & vbCrLf
        If lColCh = -1 Then szErr = szErr & "Column 'Channel' not found" & vbCrLf
        If Len(szTable) = 0 Then szErr = szErr & "Column 'Table' not found" & vbCrLf
        If Len(szErr) > 0 Then
            MsgBox(szErr)
            Exit Sub
        End If

        ' read rows
        blnErr = False
        szErr = "Used table: " & szTable & vbCrLf
        For lX = 1 To UBound(szArr, 1)
            If szArr(lX, 0) = szTable Then ' use only first table
                Select Case Val(szArr(lX, lColCh))
                    Case 0 ' left channel
                        If F4FL.ImpType = Implant.IMPLANTTYPE.imptInvalid Then
                            blnErr = True
                            szErr = szErr & "Left: fitting file not set." & vbCrLf
                        Else
                            lY = CInt(Val(szArr(lX, lColEl)))
                            If (lY > 0) And (lY <= F4FL.ChannelsCount) Then
                                With F4FL.Channel(lY - 1)
                                    lAmp = CInt(Val(szArr(lX, lColAmp)))
                                    If lAmp > .lMCL Then
                                        szErr = szErr & "Left, #" & CStr(lY) & ": Amplitude (=" & CStr(lAmp) & ") reduced to MCL (=" & CStr(.lMCL) & ")" & vbCrLf
                                        blnErr = True
                                        lAmp = .lMCL
                                    ElseIf lAmp < .lTHR Then
                                        szErr = szErr & "Left, #" & CStr(lY) & ": Amplitude (=" & CStr(lAmp) & ") increased to THR (=" & CStr(.lTHR) & ")" & vbCrLf
                                        blnErr = True
                                        lAmp = .lTHR
                                    Else
                                        szErr = szErr & "Left, #" & CStr(lY) & ": Amplitude =" & CStr(lAmp) & vbCrLf
                                    End If
                                    mlLevelL(lY - 1) = lAmp
                                    sldL(lY - 1).Value = mlLevelL(lY - 1)
                                    sldL_Change(sldL.Item(CShort(lY - 1)), New System.EventArgs())
                                End With
                            Else
                                szErr = szErr & "Left, #" & CStr(lY) & ": electrode not valid" & vbCrLf
                                blnErr = True
                            End If ' electrode valid?
                        End If
                    Case 1 ' right channel
                        If F4FR.ImpType = Implant.IMPLANTTYPE.imptInvalid Then
                            blnErr = True
                            szErr = szErr & "Right: fitting file not set." & vbCrLf
                        Else
                            lY = CInt(Val(szArr(lX, lColEl)))
                            If (lY > 0) And (lY <= F4FR.ChannelsCount) Then
                                With F4FR.Channel(lY - 1)
                                    lAmp = CInt(Val(szArr(lX, lColAmp)))
                                    If lAmp > .lMCL Then
                                        szErr = szErr & "Right, #" & CStr(lY) & ": Amplitude (=" & CStr(lAmp) & ") reduced to MCL (=" & CStr(.lMCL) & ")" & vbCrLf
                                        blnErr = True
                                        lAmp = .lMCL
                                    ElseIf lAmp < .lTHR Then
                                        szErr = szErr & "Right, #" & CStr(lY) & ": Amplitude (=" & CStr(lAmp) & ") increased to THR (=" & CStr(.lTHR) & ")" & vbCrLf
                                        blnErr = True
                                        lAmp = .lTHR
                                    Else
                                        szErr = szErr & "Right, #" & CStr(lY) & ": Amplitude =" & CStr(lAmp) & vbCrLf
                                    End If
                                    mlLevelR(lY - 1) = lAmp
                                    sldR(lY - 1).Value = mlLevelR(lY - 1)
                                    sldR_Change(sldR.Item(CShort(lY - 1)), New System.EventArgs())
                                End With
                            Else
                                szErr = szErr & "Right, #" & CStr(lY) & ": electrode not valid" & vbCrLf
                                blnErr = True
                            End If ' electrode valid?
                        End If
                End Select ' select channel
            End If ' only first table
        Next  ' for each row

        If blnErr Then
            MsgBox(szErr, MsgBoxStyle.Critical, "Error importing amplitudes")
        Else
            MsgBox(szErr, MsgBoxStyle.Information, "Status report")
        End If
        Me.SetChangedTitle()
        Exit Sub

        '----------------
Error_CancelClick:
        Exit Sub


    End Sub


    Public Sub mnuViewStimulus_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuViewStimulus.Click
        mblnShowStimulus = Not mblnShowStimulus
        If mblnShowStimulus Then mnuViewStimulus.Checked = True Else mnuViewStimulus.Checked = False
    End Sub

    Private Sub optLeftFirst_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optLeftFirst.CheckedChanged
        If mblnPreventControl Then Return
        If DirectCast(eventSender, RadioButton).Checked Then
            mblnLeftFirst = True
        End If
        SetChangedTitle()
        SetUIReady()
    End Sub

    Private Sub optRightFirst_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optRightFirst.CheckedChanged
        If mblnPreventControl Then Return
        If DirectCast(eventSender, RadioButton).Checked Then
            mblnLeftFirst = False
        End If
        SetChangedTitle()
        SetUIReady()
    End Sub

    Private Sub sldL_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _sldL_0.Enter
        'DirectCast(sender, TrackBar).BackColor = Drawing.SystemColors.ControlLightLight
        DirectCast(sender, TrackBar).BackColor = Drawing.Color.LightBlue
    End Sub

    Public Sub sldL_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _sldL_0.ValueChanged
        Dim Index As Integer = sldL.IndexOf(DirectCast(eventSender, TrackBar))
        Dim lX As Integer

        ' restore previous value if prevent control
        If mblnPreventControl Then
            mblnPreventControl = False
            lX = mlLevelL(Index)
            If lX <> sldL(Index).Value Then
                sldL(Index).Value = lX ' restore value -> _Change event occures
                Exit Sub
            End If
        End If

        ' check if Level changed
        lX = sldL(Index).Value
        If lX <> mlLevelL(Index) Then
            ' save new level
            mlLevelL(Index) = lX
            SetChangedTitle()
        End If
        ' update display
        If lblLevelLabel.Text = "Level (cu)" Then
            lblLevelL(CShort(Index)).Text = TStr(F4FL.Channel(Index).lRange) & ":" & TStr(mlLevelL(Index))
        Else
            lblLevelL(CShort(Index)).Text = F4FL.CalcCurrentAsString(mlLevelL(Index), F4FL.Channel(Index).lRange)
        End If

        lblDrL(CShort(Index)).Text = CU2DR(CShort(Index), 0) & "%"
    End Sub

    Private Sub sldL_KeyDownEvent(ByVal eventSender As System.Object, ByVal eventArgs As Windows.Forms.KeyEventArgs) Handles _sldL_0.KeyDown
        Dim Index As Integer = sldL.IndexOf(DirectCast(eventSender, TrackBar))
        'Dim lX As Integer

        Select Case eventArgs.KeyCode

            Case System.Windows.Forms.Keys.Right
                If My.Computer.Keyboard.CtrlKeyDown Then
                    ShiftLevels(1, 0)
                ElseIf My.Computer.Keyboard.ShiftKeyDown Then
                    ShiftLevels(0, 1)
                Else
                    mblnPreventControl = True
                    sldL_KeyPressEvent(sldL.Item(Index), New Windows.Forms.KeyPressEventArgs("n"c))
                End If
            Case System.Windows.Forms.Keys.Left
                If My.Computer.Keyboard.CtrlKeyDown Then
                    ShiftLevels(-1, 0)
                ElseIf My.Computer.Keyboard.ShiftKeyDown Then
                    ShiftLevels(0, -1)
                Else
                    mblnPreventControl = True
                    sldL_KeyPressEvent(sldL.Item(Index), New Windows.Forms.KeyPressEventArgs("p"c))
                End If


        End Select
    End Sub

    Private Sub ShiftLevels(lSmallChanges As Integer, lLargeChanges As Integer)
        'shift all active slider levels from left to right (positive input) or right to left (negative input)
        'step size = SmallChange * lValue (input)

        Dim lX As Integer
        For lX = 0 To chkGroupL.Count - 1
            If chkGroupL(CShort(lX)).Checked Then

                sldL(CShort(lX)).Value = Math.Min(Math.Max(sldL(CShort(lX)).Value - sldL(CShort(lX)).SmallChange * lSmallChanges - sldL(CShort(lX)).LargeChange * lLargeChanges, sldL(CShort(lX)).Minimum), sldL(CShort(lX)).Maximum)
            End If

        Next
        For lX = 0 To chkGroupR.Count - 1
            If chkGroupR(CShort(lX)).Checked Then
                sldR(CShort(lX)).Value = Math.Min(Math.Max(sldR(CShort(lX)).Value + sldR(CShort(lX)).SmallChange * lSmallChanges + sldR(CShort(lX)).LargeChange * lLargeChanges, sldR(CShort(lX)).Minimum), sldR(CShort(lX)).Maximum)
            End If
        Next
        mblnPreventControl = True

    End Sub

    Private Sub sldL_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _sldL_0.Leave
        mlSliderIndex = sldL.IndexOf(DirectCast(eventSender, TrackBar))
        DirectCast(eventSender, TrackBar).BackColor = Drawing.SystemColors.Control
    End Sub

    Private Sub sldL_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _sldL_0.Scroll
        Dim Index As Integer = sldL.IndexOf(DirectCast(eventSender, TrackBar))
        sldL_Change(sldL.Item(Index), New System.EventArgs())
    End Sub

    Private Sub sldL_KeyPressEvent(ByVal eventSender As System.Object, ByVal eventArgs As Windows.Forms.KeyPressEventArgs) Handles _sldL_0.KeyPress
        Dim Index As Integer = sldL.IndexOf(DirectCast(eventSender, TrackBar))
        Dim lX, lMax As Integer
        Select Case eventArgs.KeyChar
            Case ChrW(13), " "c, "s"c
                If cmdGroupStimulate.Visible Then
                    mlSliderIndex = Index
                    cmdGroupStimulate_Click(cmdGroupStimulate, New System.EventArgs())
                End If
            Case "r"c
                ' change to right slider
                If sldR(Index).Visible And sldR(Index).Enabled Then sldR(Index).Focus()
            Case "n"c
                lX = Index
                If lX >= sldR.Count And lX > sldL.Count Then lX = 0
                If lX < sldR.Count Then
                    If sldR(lX).Enabled And sldR(lX).Visible Then sldR(lX).Focus() : Exit Sub
                End If
                lX = lX + 1
                If lX >= sldR.Count And lX > sldL.Count Then lX = 0
                Do Until lX = Index
                    If lX < sldL.Count Then
                        If sldL(lX).Enabled And sldL(lX).Visible Then sldL(lX).Focus() : Exit Sub
                    End If
                    If lX < sldR.Count Then
                        If sldR(lX).Enabled And sldR(lX).Visible Then sldR(lX).Focus() : Exit Sub
                    End If
                    lX = lX + 1
                    If lX >= sldR.Count And lX > sldL.Count Then lX = 0
                Loop
            Case "p"c
                If sldR.Count > sldL.Count Then lMax = sldR.Count - 1 Else lMax = sldL.Count - 1
                lX = Index - 1
                If lX < 0 Then lX = lMax
                Do Until lX = Index
                    If lX < sldR.Count Then
                        If sldR(lX).Enabled And sldR(lX).Visible Then sldR(lX).Focus() : Exit Sub
                    End If
                    If lX < sldL.Count Then
                        If sldL(lX).Enabled And sldL(lX).Visible Then sldL(lX).Focus() : Exit Sub
                    End If
                    lX = lX - 1
                    If lX < 0 Then lX = lMax
                Loop
                If sldR(lX).Enabled And sldR(lX).Visible Then
                    sldR(lX).Focus()
                    Exit Sub
                End If
            Case "g"c
                chkGroupL(CShort(Index)).CheckState = CType(1 - chkGroupL(CShort(Index)).CheckState, CheckState)
        End Select
    End Sub

    Private Sub sldR_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _sldR_0.Enter
        DirectCast(sender, TrackBar).BackColor = Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
    End Sub

    Private Sub sldR_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _sldR_0.ValueChanged
        Dim Index As Integer = sldR.IndexOf(DirectCast(eventSender, TrackBar))
        Dim lX As Integer

        ' restore previous value if prevent control
        If mblnPreventControl Then
            mblnPreventControl = False
            lX = mlLevelR(Index)
            If lX <> sldR(Index).Value Then
                sldR(Index).Value = lX ' restore value -> _Change event occures
                Exit Sub
            End If
        End If

        ' check if Level changed
        lX = sldR(Index).Value
        If lX <> mlLevelR(Index) Then
            ' save new level
            mlLevelR(Index) = lX
            SetChangedTitle()
        End If
        ' update display
        If lblLevelLabel.Text = "Level (cu)" Then
            lblLevelR(CShort(Index)).Text = TStr(F4FR.Channel(Index).lRange) & ":" & TStr(mlLevelR(Index))
        Else
            lblLevelR(CShort(Index)).Text = F4FR.CalcCurrentAsString(mlLevelR(Index), F4FR.Channel(Index).lRange)
        End If
        lblDrR(CShort(Index)).Text = CU2DR(CShort(Index), 1) & "%"
    End Sub

    Private Sub sldR_KeyDownEvent(ByVal eventSender As System.Object, ByVal eventArgs As Windows.Forms.KeyEventArgs) Handles _sldR_0.KeyDown
        Dim Index As Integer = sldR.IndexOf(DirectCast(eventSender, TrackBar))
        'Dim lX As Integer

        Select Case eventArgs.KeyCode
            Case System.Windows.Forms.Keys.Right
                If My.Computer.Keyboard.CtrlKeyDown Then
                    ShiftLevels(1, 0)
                ElseIf My.Computer.Keyboard.ShiftKeyDown Then
                    ShiftLevels(0, 1)
                Else
                    mblnPreventControl = True
                    sldR_KeyPressEvent(sldR.Item(Index), New Windows.Forms.KeyPressEventArgs("n"c))
                End If
            Case System.Windows.Forms.Keys.Left
                If My.Computer.Keyboard.CtrlKeyDown Then
                    ShiftLevels(-1, 0)
                ElseIf My.Computer.Keyboard.ShiftKeyDown Then
                    ShiftLevels(0, -1)
                Else
                    mblnPreventControl = True
                    sldR_KeyPressEvent(sldR.Item(Index), New Windows.Forms.KeyPressEventArgs("p"c))
                End If
        End Select
    End Sub

    Private Sub sldR_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _sldR_0.Leave
        mlSliderIndex = sldR.IndexOf(DirectCast(eventSender, TrackBar)) + &H10000
        DirectCast(eventSender, TrackBar).BackColor = Drawing.SystemColors.Control
    End Sub

    Private Sub sldR_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _sldR_0.Scroll
        Dim Index As Integer = sldR.IndexOf(DirectCast(eventSender, TrackBar))
        sldR_Change(sldR.Item(Index), New System.EventArgs())
    End Sub

    Private Sub sldR_KeyPressEvent(ByVal eventSender As System.Object, ByVal eventArgs As Windows.Forms.KeyPressEventArgs) Handles _sldR_0.KeyPress
        Dim Index As Integer = sldR.IndexOf(DirectCast(eventSender, TrackBar))
        Dim lX, lMax As Integer
        Select Case eventArgs.KeyChar
     
            Case ChrW(13), " "c, "s"c
                If cmdGroupStimulate.Visible Then
                    mlSliderIndex = Index + &H10000
                    cmdGroupStimulate_Click(cmdGroupStimulate, New System.EventArgs())
                End If
            Case "l"c
                ' change to slider left
                If sldL(Index).Visible And sldL(Index).Enabled Then sldL(Index).Focus()
            Case "n"c
                lX = Index + 1
                If lX >= sldR.Count And lX > sldL.Count Then lX = 0
                Do Until lX = Index
                    If lX < sldL.Count Then
                        If sldL(lX).Enabled And sldL(lX).Visible Then sldL(lX).Focus() : Exit Sub
                    End If
                    If lX < sldR.Count Then
                        If sldR(lX).Enabled And sldR(lX).Visible Then sldR(lX).Focus() : Exit Sub
                    End If
                    lX = lX + 1
                    If lX >= sldR.Count And lX > sldL.Count Then lX = 0
                Loop
            Case "p"c
                If sldR.Count > sldL.Count Then lMax = sldR.Count - 1 Else lMax = sldL.Count - 1
                lX = Index
                If lX < sldL.Count Then
                    If sldL(lX).Enabled And sldL(lX).Visible Then sldL(lX).Focus() : Exit Sub
                End If
                lX = Index - 1
                If lX < 0 Then lX = lMax
                Do Until lX = Index
                    If lX < sldR.Count Then
                        If sldR(lX).Enabled And sldR(lX).Visible Then sldR(lX).Focus() : Exit Sub
                    End If
                    If lX < sldL.Count Then
                        If sldL(lX).Enabled And sldL(lX).Visible Then sldL(lX).Focus() : Exit Sub
                    End If
                    lX = lX - 1
                    If lX < 0 Then lX = lMax
                Loop
            Case "g"c
                chkGroupR(CShort(Index)).CheckState = CType(1 - (chkGroupR(CShort(Index)).CheckState), CheckState)
                'Case Key.C AndAlso (Keyboard.Modifiers And ModifierKeys.Control) = ModifierKeys.Control

        End Select
      
    End Sub

    ' ------------------------------------------------------------------
    ' EVENTS - Menus
    ' ------------------------------------------------------------------

    Public Sub mnuExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub

    Public Sub mnuFileNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuParametersReload.Click
        If mblnChanged Then
            If MsgBox("Some parameters were changed. If you proceed, all changes will be discarded." & vbCrLf & "Continue anyway?", _
                    MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Exclamation, "New setting") = MsgBoxResult.No Then Exit Sub
        End If
        ' Reset parameters
        CopyParametersFromApplication()
        For lX As Integer = 0 To txtPhDurL.Count - 1
            txtPhDurL(lX).Text = TStr(Math.Round(gfreqParL(lX).lPhDur, 1))
            lblPhDurL(lX).Text = TStr(gfreqParL(lX).lPhDur / F4FL.TimeBase)
            txtPhDurR(lX).Text = TStr(Math.Round(gfreqParR(lX).lPhDur, 1))
            lblPhDurR(lX).Text = TStr(gfreqParR(lX).lPhDur / F4FR.TimeBase)
        Next
        ShowForm()
        SetUIReady()
    End Sub

    Public Sub mnuFileLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuParametersLoad.Click
        Dim szFile As String
        Dim szErr As String
        Dim szKey As String
        Dim iErr As Short

        If mblnChanged Then
            If MsgBox("Some settings were changed. If you load new settings, all changes will be discarded." & vbCrLf & "Continue anyway?", _
                MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Exclamation, "Load settings") = MsgBoxResult.No Then Exit Sub
        End If

        Dim dlgOpen As New OpenFileDialog
        ChDir(gszCurrentDir)
        dlgOpen.Title = "Load settings"
        dlgOpen.CheckFileExists = True
        dlgOpen.CheckPathExists = True
        dlgOpen.CheckPathExists = True
        dlgOpen.Filter = "BLB-Manu File (*.BLBManu)|*.BLBManu|Experimental Setting File (*.esf)|*.esf|All Files (*.*)|*.*"
        dlgOpen.FilterIndex = 0
        If dlgOpen.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
        On Error GoTo 0
        szFile = dlgOpen.FileName
        gszCurrentDir = Mid(dlgOpen.FileName, 1, Len(dlgOpen.FileName) - Len((New System.IO.DirectoryInfo(dlgOpen.FileName)).Name))
        ' check the type of file
        szKey = "experiment type"
        szErr = INISettings.FindParameter(szFile, szKey)
        If szErr <> "" Then GoTo Error_Load
        If szKey <> "BLBmanu" Then
            If MsgBox("This file is not a parameter file for the good old Binaural Loudness Balancing." & vbCrLf & "If you continue loading all parameters from this file will overwrite current parameters." & vbCrLf & "All other parameters will remain." & vbCrLf & vbCrLf & "Do you want to continue with loading?", _
                MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then GoTo Error_CancelClick
        End If
        ' read and parse new file
        ClearParameters()
        szErr = ""

        ReadFile(szFile)
        If szErr <> "" Then GoTo Error_Load
        ' display new parameters
        ShowForm()
        mszSettingTitle = szFile
        Me.SetChangedTitle()
        SetUIReady()
        Return

Error_Load:
        MsgBox("Can't load file:" & vbCrLf & szErr, MsgBoxStyle.Critical, "Load file")
Error_CancelClick:
EndSub:
        SetUIReady()

    End Sub

    Private Function ReadFile(ByVal szFileName As String) As String
        Dim szTemp As String
        ' Ini-Datei vorhanden ???
        If Dir(szFileName) = "" Then
            Return "Settings file " & szFileName & vbCrLf & " couldn't be found. A new file was created." & vbCrLf & "All parameters are set to default values, check them for proper working."
        End If

        Dim file As System.IO.StreamReader = _
                My.Computer.FileSystem.OpenTextFileReader(szFileName)
        Do
            szTemp = file.ReadLine
            If Not IsNothing(szTemp) Then
                Dim lX As Integer = InStr(szTemp, "=")
                If lX <> 0 Then
                    ' = gefunden
                    Dim szName As String = Strings.Left(szTemp, lX - 1)
                    Dim szValue As String = Mid(szTemp, lX + 1)
                    szName = LCase(szTemp)
                    szName = RTrim(szTemp)
                    szValue = LTrim(szValue)
                    Select Case szName ' the name is a lower case string!
                        Case "stimulus length"
                            mlStimLength = CInt(Val(szValue))
                        Case "stimulus pulse period left"
                            txtPulsePeriodL.Text = szValue
                        Case "stimulus pulse period right"
                            txtPulsePeriodR.Text = szValue
                        Case "interaural break"
                            mlInterauralBreak = CInt(Val(szValue))
                        Case "stimulate delayed"
                            mblnDelayed = CBool(szValue)
                        Case "stimulate left first"
                            mblnLeftFirst = CBool(szValue)
                        Case "level left list"
                            ReDim Preserve mlLevelL(GetUbound(mlLevelL) + 1)
                            mlLevelL(GetUbound(mlLevelL)) = CInt(Val(szValue))
                        Case "level right list"
                            ReDim Preserve mlLevelR(GetUbound(mlLevelR) + 1)
                            mlLevelR(GetUbound(mlLevelR)) = CInt(Val(szValue))
                        Case Else
                            ' unknown parameter found - do something...
                    End Select
                End If
            End If
        Loop Until IsNothing(szTemp)
        Return ""

ReadFile_Error:
        Return "Error " & Err.Description & vbCrLf & "while reading settings file: " & vbCrLf & szFileName
    End Function

    'Private Sub txtDuration_TextChanged(sender As Object, e As System.EventArgs) Handles txtDuration.TextChanged
    '    SetChangedTitle()
    'End Sub

    Private Sub txtDuration_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDuration.Validating
        If Not IsNumeric(txtDuration.Text) Then
            MsgBox("Must be numeric positive.")
            e.Cancel = True
            Return
        End If
        Dim lX As Integer = CInt(Math.Round(Val(txtDuration.Text)))
        If lX < 1 Then
            MsgBox("Must be a positive number.")
            e.Cancel = True
            Return
        End If
        If Val(txtDuration.Text) <> CInt(Math.Round(Val(txtDuration.Text))) Then
            txtDuration.Text = TStr(CInt(Math.Round(Val(txtDuration.Text))))
        End If
        If mlStimLength <> CInt(Math.Round(Val(txtDuration.Text))) Then
            mlStimLength = CInt(Math.Round(Val(txtDuration.Text)))
            SetChangedTitle()
        End If
        e.Cancel = False
    End Sub

    Private Sub txtPulsePeriodL_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPulsePeriodL.TextChanged
        SetChangedTitle()
    End Sub

    Private Sub txtPulsePeriodL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPulsePeriodL.Validating
        If Not IsNumeric(txtPulsePeriodL.Text) Then
            MsgBox("Must be numeric positive.")
            e.Cancel = True
            Return
        End If
        Dim sX As Double = Math.Round(Val(txtPulsePeriodL.Text), 1)
        If sX < 1 Then
            MsgBox("Must be a positive number.")
            e.Cancel = True
            Return
        End If
        lblPulseRateL.Text = TStr(Math.Round(1000000.0 / sX, 1))
        e.Cancel = False
        'gsLDPulsePeriodL = Val(lblPulseRateL.Text)
        SetChangedTitle()
    End Sub

    Private Sub txtPulsePeriodR_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPulsePeriodR.TextChanged
        SetChangedTitle()
    End Sub

    Private Sub txtPulsePeriodR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPulsePeriodR.Validating
        If Not IsNumeric(txtPulsePeriodR.Text) Then
            MsgBox("Must be numeric positive.")
            e.Cancel = True
            Return
        End If
        Dim sX As Double = Math.Round(Val(txtPulsePeriodR.Text), 1)
        If sX < 1 Then
            MsgBox("Must be a positive number.")
            e.Cancel = True
            Return
        End If
        lblPulseRateR.Text = TStr(Math.Round(1000000.0 / sX, 1))
        e.Cancel = False
        'gsLDPulsePeriodR = Val(lblPulseRateR.Text)
        SetChangedTitle()
    End Sub

    Private Sub mnuFileResetToTHR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuParametersResetToTHR.Click
        If mblnChanged Then
            If MsgBox("Some parameters were changed. If you proceed, all changes will be discarded." & vbCrLf & "Continue anyway?", _
                    MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Exclamation, _
                    "Reset parameters to default values") = MsgBoxResult.No Then Exit Sub
        End If
        ClearParameters()
        ShowForm()
        SetUIReady()
    End Sub

    Private Sub lblLevelLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLevelLabel.DoubleClick
        If lblLevelLabel.Text = "Level (cu)" Then
            lblLevelLabel.Text = "Level (µA)"
            lblMCLLabel.Text = "MCL (µA)"
            lblTHRLabel.Text = "THR (µA)"
        Else
            lblLevelLabel.Text = "Level (cu)"
            lblMCLLabel.Text = "MCL (cu)"
            lblTHRLabel.Text = "THR (cu)"
        End If
        ShowForm()
    End Sub

    Private Sub txtPhDurL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _txtPhDurL_0.Validating
        Dim szX As String = DirectCast(sender, TextBox).Text
        Dim lIdx As Integer = txtPhDurL.IndexOf(DirectCast(sender, TextBox))
        If Not IsNumeric(szX) Then
            MsgBox("Must be numeric positive.")
            e.Cancel = True
            Return
        End If
        Dim lX As Integer = CInt(Math.Round(Val(szX) / F4FL.TimeBase, 1))
        If lX < F4FL.PHDUR_MIN Then
            MsgBox("Must be at least " & TStr(F4FL.PHDUR_MIN * F4FL.TimeBase) & " µs.")
            e.Cancel = True
            Return
        End If
        If lX > F4FL.Channel(lIdx).lPhDur Then
            MsgBox("Must not exceed the maximum value from the fitting file (" & TStr(F4FL.Channel(lIdx).lPhDur * F4FL.TimeBase) & " µs).")
            e.Cancel = True
            Return
        End If
        txtPhDurL(lIdx).Text = TStr(Math.Round(lX * F4FL.TimeBase, 1))
        lblPhDurL(lIdx).Text = TStr(lX)
        SetChangedTitle()
        e.Cancel = False
    End Sub

    Private Sub txtPhDurR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _txtPhDurR_0.Validating
        Dim szX As String = DirectCast(sender, TextBox).Text
        Dim lIdx As Integer = txtPhDurR.IndexOf(DirectCast(sender, TextBox))
        If Not IsNumeric(szX) Then
            MsgBox("Must be numeric positive.")
            e.Cancel = True
            Return
        End If
        Dim lX As Integer = CInt(Math.Round(Val(szX) / F4FR.TimeBase, 1))
        If lX < F4FR.PHDUR_MIN Then
            MsgBox("Must be at least " & TStr(F4FR.PHDUR_MIN * F4FR.TimeBase) & " µs.")
            e.Cancel = True
            Return
        End If
        If lX > F4FR.Channel(lIdx).lPhDur Then
            MsgBox("Must not exceed the maximum value from the fitting file (" & TStr(F4FR.Channel(lIdx).lPhDur * F4FR.TimeBase) & " µs).")
            e.Cancel = True
            Return
        End If
        txtPhDurR(lIdx).Text = TStr(Math.Round(lX * F4FR.TimeBase, 1))
        lblPhDurR(lIdx).Text = TStr(lX)
        SetChangedTitle()
        e.Cancel = False
    End Sub

    Private Sub mnuParametersResetPhDur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuParametersResetPhDur.Click
        If mblnChanged Then
            If MsgBox("Some parameters were changed. If you proceed, all changes will be discarded." & vbCrLf & "Continue anyway?", _
                    MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Exclamation, _
                    "Reset parameters to default values") = MsgBoxResult.No Then Exit Sub
        End If

        For lX As Integer = 0 To txtPhDurL.Count - 1
            txtPhDurL(lX).Text = TStr(Math.Round(F4FL.Channel(lX).lPhDur * F4FL.TimeBase, 1))
            lblPhDurL(lX).Text = TStr(F4FL.Channel(lX).lPhDur)
            txtPhDurR(lX).Text = TStr(Math.Round(F4FR.Channel(lX).lPhDur * F4FR.TimeBase, 1))
            lblPhDurR(lX).Text = TStr(F4FR.Channel(lX).lPhDur)
        Next

        ShowForm()
        SetUIReady()
    End Sub

    Private Sub txtDuration_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDuration.TextChanged
        SetChangedTitle()
    End Sub

    Private Sub cmbAppendPulseTrain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAppendPulseTrain.SelectedIndexChanged
        SetChangedTitle()
        If cmbAppendPulseTrain.SelectedIndex = 0 Then
            txtAppendPulseTrain.Enabled = False
            ToolTip1.SetToolTip(cmbAppendPulseTrain, "'FW_AppendPulseTrain.m' or 'FW_AppendCISPulseTrain.m'are used!")
            ToolTip1.SetToolTip(txtAppendPulseTrain, "not available for 'FW_AppendPulseTrain.m' or 'FW_AppendCISPulseTrain.m'")
            ToolTip1.SetToolTip(Label9, "not available for 'FW_AppendPulseTrain.m' or 'FW_AppendCISPulseTrain.m'")
        Else
            txtAppendPulseTrain.Enabled = True
            ToolTip1.SetToolTip(cmbAppendPulseTrain, "Files" & vbCrLf & "'" & gszAPP_TITLE & "_AppendPulseTrain.m' (one electrode selected) and" & vbCrLf & _
                                "'" & gszAPP_TITLE & "_AppendCISPulseTrain.m' (multiple electrodes selected)" & vbCrLf & "must be available in MATLAB directory!")
            ToolTip1.SetToolTip(txtAppendPulseTrain, "Additional parameters can be strings (no quotes) or numeric values, seperated by commas, and must be supported by the MATLAB functions:" & vbCrLf & _
                                "'" & gszAPP_TITLE & "_AppendPulseTrain.m' / '" & gszAPP_TITLE & "_AppendCISPulseTrain.m'" & vbCrLf & _
                                "Example: 1,2,3,el1,el2")
            ToolTip1.SetToolTip(Label9, "Additional parameters can be strings (no quotes) or numeric values, seperated by commas, and must be supported by the MATLAB functions:" & vbCrLf & _
                    "'" & gszAPP_TITLE & "_AppendPulseTrain.m' / '" & gszAPP_TITLE & "_AppendCISPulseTrain.m'" & vbCrLf & _
                    "Example: 1,2,3,el1,el2")
        End If
    End Sub

    Private Sub txtAppendPulseTrain_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAppendPulseTrain.TextChanged
        SetChangedTitle()
    End Sub

    Private Sub rDR_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rDR.CheckedChanged

        Dim tempstep As Integer
        If rDR.Checked Then

            rCU.Checked = False

            'lblDrL.Font = New System.Drawing.Font("Arial", 12, FontStyle.Bold)
            lblLevelLabelDR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            lblLevelLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

            ' left
            For lX As Short = 0 To CShort(mlLevelL.Length - 1)
                lblDrL(lX).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                lblLevelL(lX).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                If F4FL.Channel(lX).lMCL > F4FL.Channel(lX).lTHR Then
                    tempstep = CInt(Math.Round((F4FL.Channel(lX).lMCL - F4FL.Channel(lX).lTHR) / 100))
                    If tempstep = 0 Then tempstep = 1
                    sldL(lX).SmallChange = tempstep

                    tempstep = CInt(Math.Round((F4FL.Channel(lX).lMCL - F4FL.Channel(lX).lTHR) / 20))
                    If tempstep = 0 Then tempstep = 1
                    sldL(lX).LargeChange = tempstep
                End If
            Next
            ' right
            For lX As Short = 0 To CShort(mlLevelR.Length - 1)
                lblDrR(lX).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                lblLevelR(lX).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                If F4FR.Channel(lX).lMCL > F4FR.Channel(lX).lTHR Then
                    tempstep = CInt(Math.Ceiling((F4FR.Channel(lX).lMCL - F4FR.Channel(lX).lTHR) / 100))
                    If tempstep = 0 Then tempstep = 1
                    sldR(lX).SmallChange = tempstep

                    tempstep = CInt(Math.Ceiling((F4FR.Channel(lX).lMCL - F4FR.Channel(lX).lTHR) / 20))
                    If tempstep = 0 Then tempstep = 1
                    sldR(lX).LargeChange = tempstep
                End If
            Next

            gbShowDR = True
            SetUIReady()
        End If
    End Sub

    Private Sub rCU_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rCU.CheckedChanged


        If rCU.Checked Then
            rDR.Checked = False

            lblLevelLabelDR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            lblLevelLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

            ' left
            For lX As Short = 0 To CShort(mlLevelL.Length - 1)
                lblDrL(lX).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                lblLevelL(lX).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                sldL(lX).SmallChange = 1 'default
                sldL(lX).LargeChange = 5 'default
            Next
            ' right
            For lX As Short = 0 To CShort(mlLevelR.Length - 1)
                lblDrR(lX).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                lblLevelR(lX).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                sldR(lX).SmallChange = 1 'default
                sldR(lX).LargeChange = 5 'default
            Next

            gbShowDR = False
            SetUIReady()
        End If



    End Sub

  
End Class