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
' fitt4fun form (electrical stimulation), is used to create fitting files for CI (cochlear implant) listeners
Friend Class frmFitt4Fun
    Inherits System.Windows.Forms.Form

    Public Enum Fitt4FunMode
        NewFittingFile = 0
        EditFittingFile = 1
        ReturnMask = 255
        FittingCancelled = 256
        FittingUpdated = 257
        Fitting
    End Enum

    Private Const mszID As String = "F4F"

    Private sldTHR As New Generic.List(Of TrackBar)
    Private sldMCL As New Generic.List(Of TrackBar)
    Public myFitt As New Implant

    Private mblnStimulation As Boolean
    Private mlMeWidth As Integer
    Private mblnShowStimulus As Boolean
    Private mblnInitControls As Boolean
    Private mblnFittingChanged As Boolean
    Private mbPlaying As Boolean

    Private mszFittDefaultLeft As String
    Private mszFittDefaultRight As String
    Private msMaxEnergy As Double
    Private mszFileName As String
    Private mszAmpFileName As String
    Private mlMinDistCorrect As Integer = 0
    Private mlPulsePeriod As Integer = 660 ' in us, not tu!
    'Private mlStimLength As Integer = 1
    Private mlElectrodeIndex As Integer = 0
    Private mMode As Fitt4FunMode
    Private mGenMode As ExpSuite.GENMODE
    Private mlEar As Implant.EARTYPE = Implant.EARTYPE.LEFT
    Private mfreqPar() As clsFREQUENCY
    Public Amplitude() As Double
    Public FileName As String

    Public Property Mode() As Fitt4FunMode
        Get
            Return mMode
        End Get
        Set(ByVal value As Fitt4FunMode)
            mMode = value
        End Set
    End Property
    Public Property GenMode() As GENMODE
        Get
            Return mGenMode
        End Get
        Set(ByVal value As GENMODE)
            mGenMode = value
        End Set
    End Property
    Public Property Ear() As Implant.EARTYPE
        Get
            Return mlEar
        End Get
        Set(ByVal value As Implant.EARTYPE)
            mlEar = value
        End Set
    End Property

    Private Sub SetUIBusy()
        tbToolBar.Enabled = False
        mnuFile.Enabled = False
        mnuStim.Enabled = False
        mnuHelp.Enabled = False
        If IsNothing(myFitt) Then Return
        For lX As Short = 0 To CShort(myFitt.ChannelsCount - 1)
            cmdTHR(lX).Enabled = False
            cmdMCL(lX).Enabled = False
            cmbRange(lX).Enabled = False
            txtPhDurTU(lX).Enabled = False
            txtPhDur(lX).Enabled = False
            chkboxChUsed(lX).Enabled = False
        Next
        Windows.Forms.Application.DoEvents()
    End Sub

    Public Sub SetUIReady()
        tbToolBar.Enabled = True
        mnuFile.Enabled = True
        mnuStim.Enabled = True
        mnuHelp.Enabled = True
        mnuFileSaveAs.Enabled = myFitt.ImpType <> Implant.IMPLANTTYPE.imptInvalid
        tbToolBar_SaveAs.Enabled = myFitt.ImpType <> Implant.IMPLANTTYPE.imptInvalid
        mnuFileClose.Enabled = myFitt.ImpType <> Implant.IMPLANTTYPE.imptInvalid
        If IsNothing(myFitt) Then mnuAmplitudes.Enabled = False : Return
        mnuAmplitudes.Enabled = myFitt.ImpType <> Implant.IMPLANTTYPE.imptInvalid
        mnuAmpReload.Enabled = Not IsNothing(Amplitude)
        Dim blnX As Boolean = False
        For Each lblX As Label In lblMem
            If lblX.Text <> "---" Then blnX = True : Exit For
        Next
        mnuAmpExport.Enabled = blnX

        Select Case myFitt.ImpType
            Case Implant.IMPLANTTYPE.imptInvalid
            Case Implant.IMPLANTTYPE.imptC40C
                Me.mnuFileNewC40C.Enabled = True
                Me.mnuFileNewC40P.Enabled = Not mblnStimulation
                Me.mnuFileNewPulsar.Enabled = False
                Me.tbToolStripMenu_NewC40C.Enabled = True
                Me.tbToolStripMenu_NewC40P.Enabled = Not mblnStimulation
                Me.tbToolStripMenu_NewPulsar.Enabled = False
                Me.mnuFileNewCIC3.Enabled = False
                Me.tbToolStripMenu_NewCIC3.Enabled = False
            Case Implant.IMPLANTTYPE.imptC40P
                Me.mnuFileNewC40P.Enabled = True
                Me.tbToolStripMenu_NewC40P.Enabled = True
                Me.mnuFileNewCIC3.Enabled = False
                Me.tbToolStripMenu_NewCIC3.Enabled = False
                Me.mnuFileNewC40C.Enabled = Not mblnStimulation
                Me.mnuFileNewPulsar.Enabled = False
                Me.tbToolStripMenu_NewC40C.Enabled = Not mblnStimulation
                Me.tbToolStripMenu_NewPulsar.Enabled = False
            Case Implant.IMPLANTTYPE.imptC40P_RIB2
                Me.mnuFileNewC40P.Enabled = True
                Me.tbToolStripMenu_NewC40P.Enabled = True
                Me.mnuFileNewCIC3.Enabled = False
                Me.tbToolStripMenu_NewCIC3.Enabled = False
                Me.mnuFileNewC40C.Enabled = False
                Me.mnuFileNewPulsar.Enabled = Not mblnStimulation
                Me.tbToolStripMenu_NewC40C.Enabled = False
                Me.tbToolStripMenu_NewPulsar.Enabled = Not mblnStimulation
            Case Implant.IMPLANTTYPE.imptPulsar
                Me.mnuFileNewC40C.Enabled = False
                Me.mnuFileNewC40P.Enabled = Not mblnStimulation
                Me.mnuFileNewPulsar.Enabled = True
                Me.tbToolStripMenu_NewC40C.Enabled = False
                Me.tbToolStripMenu_NewC40P.Enabled = Not mblnStimulation
                Me.tbToolStripMenu_NewPulsar.Enabled = True
                Me.mnuFileNewCIC3.Enabled = False
                Me.tbToolStripMenu_NewCIC3.Enabled = False
            Case Implant.IMPLANTTYPE.imptCIC3
                Me.mnuFileNewCIC3.Enabled = True
                Me.tbToolStripMenu_NewCIC3.Enabled = True
                Me.mnuFileNewC40C.Enabled = False
                Me.mnuFileNewC40P.Enabled = False
                Me.mnuFileNewPulsar.Enabled = False
                Me.tbToolStripMenu_NewC40C.Enabled = False
                Me.tbToolStripMenu_NewC40P.Enabled = False
                Me.tbToolStripMenu_NewPulsar.Enabled = False
        End Select

        For lX As Short = 0 To CShort(myFitt.ChannelsCount - 1)
            cmdTHR(lX).Enabled = mblnStimulation And chkboxChUsed(lX).Checked
            cmdMCL(lX).Enabled = mblnStimulation And chkboxChUsed(lX).Checked
            'sldTHR(lX).Enabled = chkboxChUsed(lX).Checked
            'sldMCL(lX).Enabled = chkboxChUsed(lX).Checked
            cmbRange(lX).Enabled = True
            txtPhDurTU(lX).Enabled = True
            txtPhDur(lX).Enabled = True
            chkboxChUsed(lX).Enabled = True
        Next

        If gblnOutputStable Then ' Connect button
            tbToolBar_Connect.Image = CType(My.Resources.connected, System.Drawing.Image)
        Else
            tbToolBar_Connect.Image = CType(My.Resources.disconnected, System.Drawing.Image)
        End If

        If mblnStimulation Then
            Me.tbToolBar_Connect.CheckState = CheckState.Checked
            Me.mnuStimulation.Checked = True
        Else
            Me.tbToolBar_Connect.CheckState = CheckState.Unchecked
            Me.mnuStimulation.Checked = False
        End If
        Windows.Forms.Application.DoEvents()

    End Sub

    Private Sub Stimulate(ByVal lAmp As Integer, ByVal lRange As Integer, ByVal lEl As Integer, ByVal lPhDur As Integer)
        Dim stPar As New STIM.STIMULUSPARAMETER
        Dim szX As String = ""
        Dim szY As String = ""
        Dim szErr As String
        Dim lVarMinDist As Integer
        Dim sOffset As Single

        ' disable controls
        SetUIBusy()

        ' assemble stimulus for the left ear if necessary
        If Len(mszFittDefaultLeft) <> 0 Then
            If myFitt.Ear = Implant.EARTYPE.LEFT Then
                ' left ear is active
                sbStatusBar.Items.Item(0).Text = "Stimulus for the left ear"
                sbStatusBar.Items.Item(1).BackColor = Color.Yellow
                With gstLeft
                    .lPulsePeriod = mlPulsePeriod

                    ' control if pulse period > min. distance and increase it to the length of min. distance in case it is not
                    ' offset: distinguish between RIB and RIB2 (RIB2 needs minimum offset of mindist [tu])
                    '
                    ' The constraint here is the minimum POSSIBLE distance, on the clinically relevant minimum distance (ML, 21/07/2020)

                    Select Case Me.GenMode
                        Case GENMODE.genElectricalRIB, GENMODE.genElectricalRIB2, GENMODE.genElectricalNIC
                            'If myFitt.ImpType = Implant.IMPLANTTYPE.imptC40P_RIB2 Then
                            '    lVarMinDist = Math.Max(2 * lPhDur, CInt(Math.Round(55 / .sTimeBase)))
                            'Else
                            lVarMinDist = Math.Max(myFitt.MINDIST_MIN, 2 * lPhDur)
                            'End If                    
                    End Select

                    Select Case Me.GenMode
                        Case GENMODE.genElectricalRIB, GENMODE.genElectricalNIC
                            sOffset = 0
                        Case GENMODE.genElectricalRIB2, STIM.GENMODE.genVocoder
                            sOffset = 33
                    End Select

                    If .lPulsePeriod < lVarMinDist Then
                        MsgBox("The pulse period will be temporary increased to " & CStr(lVarMinDist * .sTimeBase) & " us" & vbCrLf & "because it was too small for the used phase duration." & vbCrLf & "The stimulus duration will remain as set in options.", MsgBoxStyle.Information, "Stimulate")
                        .lPulsePeriod = lVarMinDist
                    End If

                    .lPulseNr = CInt(Math.Round((myFitt.Duration * 1000) / (.sTimeBase * .lPulsePeriod)))
                    .szStimFile = ""
                    .szFittFile = mszFittDefaultLeft
                    STIM.Log("LEFT", TStr(lAmp), TStr(lRange), TStr(lEl), TStr(lPhDur), _
                                TStr(.lPulseNr), TStr(.lPulsePeriod))
                End With
                szErr = STIM.NewStimulus(gstLeft)
                If Len(szErr) <> 0 Then GoTo SubError
                szErr = STIM.MatlabStimulus("FW_AppendPulseTrain", lAmp, lRange, lEl, lPhDur, Nothing, Nothing, sOffset)
                If Len(szErr) <> 0 Then GoTo SubError
                szErr = STIM.AssembleStimulus(mblnShowStimulus)
                If Len(szErr) <> 0 Then GoTo SubError
            Else
                ' left ear is inactive
                With gstLeft
                    .szStimFile = ""
                    .szFittFile = mszFittDefaultLeft
                End With
                szErr = STIM.NewStimulus(gstLeft)
                If Len(szErr) <> 0 Then GoTo SubError
                szErr = STIM.MatlabStimulus("FW_AppendBreak", CInt(myFitt.Duration * 1000 / gstLeft.sTimeBase))
                If Len(szErr) <> 0 Then GoTo SubError
                STIM.Log("LEFT", "Break", TStr(myFitt.Duration * 1000 / gstLeft.sTimeBase))
                szErr = STIM.AssembleStimulus(mblnShowStimulus)
                If Len(szErr) <> 0 Then GoTo SubError
            End If
        End If

        ' assemble stimulus for the right ear if necessary
        If Len(mszFittDefaultRight) <> 0 Then
            If myFitt.Ear = Implant.EARTYPE.RIGHT Then
                ' right ear is active
                sbStatusBar.Items.Item(0).Text = "Stimulus for the right ear"
                sbStatusBar.Items.Item(2).BackColor = Color.Yellow
                With gstRight
                    .lPulsePeriod = mlPulsePeriod

                    ' control if pulse period > min. distance and increase it to the length of min. distance in case it is not
                    ' offset: distinguish between RIB and RIB2 (RIB2 needs minimum offset of mindist [tu])
                    '
                    ' The constraint here is the minimum POSSIBLE distance, on the clinically relevant minimum distance (ML, 21/07/2020)

                    Select Case Me.GenMode
                        Case GENMODE.genElectricalRIB, GENMODE.genElectricalRIB2, GENMODE.genElectricalNIC
                            'If myFitt.ImpType = Implant.IMPLANTTYPE.imptC40P_RIB2 Then
                            '    lVarMinDist = Math.Max(2 * lPhDur, CInt(Math.Round(55 / .sTimeBase)))
                            'Else
                            lVarMinDist = Math.Max(myFitt.MINDIST_MIN, 2 * lPhDur)
                            'End If                    
                    End Select

                    Select Case Me.GenMode
                        Case GENMODE.genElectricalRIB, GENMODE.genElectricalNIC
                            sOffset = 0
                        Case GENMODE.genElectricalRIB2, STIM.GENMODE.genVocoder
                            sOffset = 33
                    End Select

                    If .lPulsePeriod < lVarMinDist Then
                        MsgBox("The pulse period will be temporary increased to " & CStr(lVarMinDist * .sTimeBase) & " us" & vbCrLf & "because it was too small for the used phase duration." & vbCrLf & "The stimulus duration will remain as set in options.", MsgBoxStyle.Information, "Stimulate")
                        .lPulsePeriod = lVarMinDist
                    End If

                    .lPulseNr = CInt(Math.Round((myFitt.Duration * 1000) / (.sTimeBase * .lPulsePeriod)))
                    .szStimFile = ""
                    .szFittFile = mszFittDefaultRight
                    STIM.Log("RIGHT", TStr(lAmp), TStr(lRange), TStr(lEl), TStr(lPhDur), _
                                TStr(.lPulseNr), TStr(.lPulsePeriod))
                End With
                szErr = STIM.NewStimulus(gstRight)
                If Len(szErr) <> 0 Then GoTo SubError
                szErr = STIM.MatlabStimulus("FW_AppendPulseTrain", lAmp, lRange, lEl, lPhDur, Nothing, Nothing, sOffset)
                If Len(szErr) <> 0 Then GoTo SubError
                szErr = STIM.AssembleStimulus(mblnShowStimulus)
                If Len(szErr) <> 0 Then GoTo SubError
            Else
                ' right ear is inactive
                With gstRight
                    .szStimFile = ""
                    .szFittFile = mszFittDefaultRight
                End With
                szErr = STIM.NewStimulus(gstRight)
                If Len(szErr) <> 0 Then GoTo SubError
                szErr = STIM.MatlabStimulus("FW_AppendBreak", CInt(myFitt.Duration * 1000 / gstRight.sTimeBase))
                If Len(szErr) <> 0 Then GoTo SubError
                STIM.Log("RIGHT", "Break", TStr(myFitt.Duration * 1000 / gstRight.sTimeBase))
                szErr = STIM.AssembleStimulus(mblnShowStimulus)
                If Len(szErr) <> 0 Then GoTo SubError
            End If
        End If

        ' load stimulation files
        sbStatusBar.Items.Item(0).Text = "Loading stimuli"
        If Len(mszFittDefaultLeft) <> 0 Then szX = gstLeft.szStimFile
        If Len(mszFittDefaultRight) <> 0 Then
            If Len(mszFittDefaultLeft) <> 0 Then szY = gstRight.szStimFile Else szX = gstRight.szStimFile
        End If
        szErr = Output.LoadStimulationFile(szX, szY)
        If Len(szErr) <> 0 Then GoTo SubError

        ' start stimulation
        If gblnCancel Then
            sbStatusBar.Items.Item(0).Text = "Stimulation canceled"
            GoTo SubEnd
        End If
        sbStatusBar.Items.Item(0).Text = "Starting stimulation"
        If myFitt.Ear = Implant.EARTYPE.LEFT Then
            If Len(mszFittDefaultLeft) <> 0 Then sbStatusBar.Items.Item(1).BackColor = Color.Red
        ElseIf myFitt.Ear = Implant.EARTYPE.RIGHT Then
            If Len(mszFittDefaultRight) <> 0 Then sbStatusBar.Items.Item(2).BackColor = Color.Red
        End If
        If (mlElectrodeIndex And &H10000) > 0 Then
            cmdMCL(CShort(mlElectrodeIndex Mod &H10000)).Image = Nothing
            cmdMCL(CShort(mlElectrodeIndex Mod &H10000)).BackColor = System.Drawing.Color.Red
        Else
            cmdTHR(CShort(mlElectrodeIndex Mod &H10000)).Image = Nothing
            cmdTHR(CShort(mlElectrodeIndex Mod &H10000)).BackColor = System.Drawing.Color.Red
        End If
        szErr = Output.StartStimulation
        If Len(szErr) <> 0 Then GoTo SubError
        ' wait for ready
        sbStatusBar.Items.Item(0).Text = "Stimulation in process. Please wait..."

        'If myFitt.Duration * 2 < 100 Then lX = 100 Else lX = myFitt.Duration * 2
        'szErr = Output.WaitForReady(lX)

        szErr = Output.WaitForReady(Math.Max(300, 2 * myFitt.Duration + 100))  ' wait at least 300 ms, or longer for longer signal durations

        If Len(szErr) <> 0 Then GoTo SubError
        ' Ready
        If Len(mszFittDefaultLeft) <> 0 Then sbStatusBar.Items.Item(1).BackColor = Drawing.SystemColors.Control
        If Len(mszFittDefaultRight) <> 0 Then sbStatusBar.Items.Item(2).BackColor = Drawing.SystemColors.Control
        If (mlElectrodeIndex And &H10000) > 0 Then
            cmdMCL(CShort(mlElectrodeIndex Mod &H10000)).Image = cmdTHR(0).Image
            cmdMCL(CShort(mlElectrodeIndex Mod &H10000)).BackColor = System.Drawing.SystemColors.Control
        Else
            cmdTHR(CShort(mlElectrodeIndex Mod &H10000)).Image = cmdMCL(0).Image
            cmdTHR(CShort(mlElectrodeIndex Mod &H10000)).BackColor = System.Drawing.SystemColors.Control
        End If
        sbStatusBar.Items.Item(0).Text = "Stimulation finished"
SubEnd:
        SetUIReady()
        sbStatusBar.Items.Item(1).BackColor = Drawing.SystemColors.Control
        sbStatusBar.Items.Item(2).BackColor = Drawing.SystemColors.Control
        Return

SubError:
        MsgBox(szErr, MsgBoxStyle.Critical, "Stimulate")
        GoTo SubEnd

    End Sub

    Private Sub StimulationOn()
        Dim lX, lY As Integer
        Dim stPar As New STIM.STIMULUSPARAMETER
        Dim szErr As String

        If myFitt.ImpType = Implant.IMPLANTTYPE.imptInvalid Then
            MsgBox("First define implant type")
            Return
        End If
        SetUIBusy()

        ' init STIM1
        sbStatusBar.Items.Item(0).Text = "Init STIM. Please wait..."
        STIM.SourceDir = My.Application.Info.DirectoryPath
        If gblnDestinationDir Then STIM.DestinationDir = gszDestinationDir Else STIM.DestinationDir = "%temp%"
        STIM.ID = mszID
        STIM.GenerationMode = mGenMode
        If gblnSilentMode Then STIM.LoggingMode = 0 Else STIM.LoggingMode = DirectCast(glLogMode, STIM.LOGMODE)
        STIM.Description = "Fitt4Fun module"
        STIM.ShowStimulusFlags = TStr(glShowStimulusFlags)
        STIM.CreateWorkDir = gblnNewWorkDir
        STIM.UseMatlab = gblnUseMATLAB
        STIM.MATLABServer = gszMATLABServer
        STIM.MATLABPath = gszMATLABPath
        STIM.LoggingMode = CType(glLogMode, ExpSuite.LOGMODE)
        szErr = STIM.Init
        If Len(szErr) <> 0 Then GoTo SubError
        STIM.SourceDir = STIM.MATLABPath        ' use Matlab path as source for the godfather fitting files
        ' register channels
        If Len(mszFittDefaultLeft) <> 0 Then
            stPar.szFittFile = mszFittDefaultLeft
            stPar.lChNr = 0
            szErr = STIM.RegisterChannel(stPar)
            If Len(szErr) <> 0 Then GoTo SubError
            gstLeft = stPar
            glImpLeft = 1       ' left implant is used
        End If
        If Len(mszFittDefaultRight) <> 0 Then
            stPar.szFittFile = mszFittDefaultRight
            stPar.lChNr = 1
            szErr = STIM.RegisterChannel(stPar)
            If Len(szErr) <> 0 Then GoTo SubError
            gstRight = stPar
            glImpRight = 2      ' right implant is used
        End If
        ' init output device
        sbStatusBar.Items.Item(0).Text = "Init Output. Please wait..."
        szErr = Output.Connect
        If Len(szErr) <> 0 Then GoTo SubError

        ' set global flags
        mblnStimulation = True
        ' enable controls
        tbToolBar_Connect.Checked = True
        mnuStimulation.Checked = True
        If myFitt.ChannelsCount = 0 Then lY = 0 Else lY = myFitt.ChannelsCount - 1
        For lX = 0 To lY
            cmdTHR(CShort(lX)).Enabled = chkboxChUsed(CShort(lX)).Checked
            cmdMCL(CShort(lX)).Enabled = chkboxChUsed(CShort(lX)).Checked
            'sldTHR(CShort(lX)).Enabled = chkboxChUsed(CShort(lX)).Checked
            'sldMCL(CShort(lX)).Enabled = chkboxChUsed(CShort(lX)).Checked
        Next
        sbStatusBar.Items.Item(0).Text = "Stimulation is ON"
        If Len(mszFittDefaultLeft) = 0 Then
            sbStatusBar.Items.Item(1).Text = "OFF"
        Else
            sbStatusBar.Items.Item(1).Text = gstLeft.szImpType
        End If
        If Len(mszFittDefaultRight) = 0 Then
            sbStatusBar.Items.Item(2).Text = "OFF"
        Else
            sbStatusBar.Items.Item(2).Text = gstRight.szImpType
        End If
        If gblnRIBSimulation Or gblnRIB2Simulation Or gblnDoNotConnectToDevice Then sbStatusBar.Items.Item(1).Text = "[" & sbStatusBar.Items.Item(1).Text & "]"
        If gblnRIBSimulation Or gblnRIB2Simulation Or gblnDoNotConnectToDevice Then sbStatusBar.Items.Item(2).Text = "[" & sbStatusBar.Items.Item(2).Text & "]"
StimEnd:
        SetUIReady()
        Return

StimCancel:
        tbToolBar_Connect.Checked = False
        SetUIReady()
        Return

SubError:
        MsgBox(szErr, MsgBoxStyle.Critical, "Connect")
        SetUIReady()
        Return

    End Sub

    Private Sub StimulationOff()
        Dim szErr As String


        SetUIBusy()

        ' close output
        sbStatusBar.Items.Item(0).Text = "Closing Output. Please wait..."
        If gblnAutoBackupItemList Then BackupFittFile()
        szErr = Output.Disconnect
        If Len(szErr) <> 0 Then GoTo SubError
        ' finish stim
        sbStatusBar.Items.Item(0).Text = "Closing STIM. Please wait..."
        szErr = STIM.Finish
        If Len(szErr) <> 0 Then GoTo SubError

        ' set global flag
        mblnStimulation = False
        ' disable controls
        tbToolBar_Connect.CheckState = CheckState.Checked
        mnuStimulation.Checked = False
        For lX As Short = 0 To CShort(myFitt.ChannelsCount - 1)
            cmdTHR(lX).Enabled = False
            cmdMCL(lX).Enabled = False
        Next
        sbStatusBar.Items.Item(0).Text = "Stimulation is OFF"
        sbStatusBar.Items.Item(1).Text = ""
        sbStatusBar.Items.Item(2).Text = ""
        SetUIReady()
        Return

SubError:
        MsgBox(szErr, MsgBoxStyle.Critical, "Stimulation Off")
        tbToolBar_Connect.CheckState = CheckState.Unchecked
        SetUIReady()
        Return

    End Sub

    Private Sub SetMaxEnergy(ByVal lX As Short)
        Dim sX As Double
        sX = myFitt.CalcCurrent(myFitt.Channel(lX).lMCL, myFitt.Channel(lX).lRange) * myFitt.Channel(lX).lPhDur * myFitt.TimeBase / 1000
        lblMaxEnergy(lX).Text = TStr(Math.Round(sX, 1)) & " nAs"
        If sX > msMaxEnergy Then
            lblMaxEnergy(lX).Font = New Font(lblMaxEnergy(lX).Font, FontStyle.Bold)
            lblMaxEnergy(lX).ForeColor = Drawing.Color.Red
        Else
            lblMaxEnergy(lX).Font = New Font(lblMaxEnergy(lX).Font, FontStyle.Regular)
            lblMaxEnergy(lX).ForeColor = Drawing.SystemColors.ControlText
        End If
    End Sub

    Private Sub SetDynamic(ByVal lX As Short)
        If sldTHR(lX).Value >= sldMCL(lX).Value Then
            lblDynamic(lX).Text = "disabled"
        Else
            lblDynamic(lX).Text = TStr(Math.Round(20 * Log10(sldMCL(lX).Value - sldTHR(lX).Value + 1), 1)) & " dB"
        End If
    End Sub

    Private Sub SetChangedTitle()

        Me.Text = "Fitt4Fun" & " [ " & mszFileName & " * ]"
        mblnFittingChanged = True
        ' enable menus
        mnuFileSaveAs.Enabled = True
        tbToolBar_SaveAs.Enabled = True
        mnuFileClose.Enabled = True

    End Sub


    Private Function CheckParameters() As Boolean
        Dim sX As Double
        Dim szX As String
        Dim bolX As Boolean

        CheckParameters = True
        ' check max. energy
        For lX As Short = 0 To CShort(myFitt.ChannelsCount - 1)
            If chkboxChUsed(lX).Checked And lblDynamic(lX).Text <> "disabled" Then
                sX = myFitt.CalcCurrent(myFitt.Channel(lX).lMCL, myFitt.Channel(lX).lRange) * myFitt.Channel(lX).lPhDur * myFitt.TimeBase / 1000
                If sX > msMaxEnergy Then
                    If MsgBox("Max. energy in electrode" & Str(lX + 1) & _
                                " exceeds the upper bound" & vbCrLf & "Continue anyway?", _
                                MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, _
                                "Checking parameters") = MsgBoxResult.No Then Exit Function
                End If
            End If
        Next

        ' check first name -> only chars and numbers allowed
        If Len(myFitt.FirstName) > 10 Then
            If MsgBox("The length of the first name exceeds the maximum of 10 characters." & vbCrLf & _
                        "Trim to the right length and continue?", _
                        MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, _
                        "Checking parameters") = MsgBoxResult.No Then Exit Function
        End If
        myFitt.FirstName = Mid(myFitt.FirstName, 1, 10)
        txtFName.Text = myFitt.FirstName
        bolX = False
        For lX2 As Integer = 1 To Len(myFitt.FirstName)
            szX = Mid(myFitt.FirstName, lX2, 1)
            Select Case szX
                Case " ", "-", "1" To "9", "A" To "Z", "a" To "z", "ä", "Ä", "ö", "Ö", "ü", "Ü"
                    ' OK
                Case Else
                    bolX = True
            End Select
        Next
        If bolX Then
            If MsgBox("First name contains some non-letter characters." & _
                        "The fitting file may be invalid." & vbCrLf & "Continue anyway?", _
                        MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, _
                        "Checking parameters") = MsgBoxResult.No Then Exit Function
        End If

        ' check last name -> only chars and numbers allowed
        If Len(myFitt.LastName) > 20 Then
            If MsgBox("The length of the last name exceeds the maximum of 20 characters." & vbCrLf _
                        & "Trim to the right length and continue?", _
                        MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, _
                        "Checking parameters") = MsgBoxResult.No Then Exit Function
        End If
        myFitt.LastName = Mid(myFitt.LastName, 1, 20)
        txtLName.Text = myFitt.LastName
        bolX = False
        For lX As Integer = 1 To Len(myFitt.LastName)
            szX = Mid(myFitt.LastName, lX, 1)
            Select Case szX
                Case " ", "-", "1" To "9", "A" To "Z", "a" To "z", "ä", "Ä", "ö", "Ö", "ü", "Ü"
                    ' OK
                Case Else
                    bolX = True
            End Select
        Next
        If bolX Then
            If MsgBox("Last name contains some non-letter characters." & _
                        "The fitting file may be invalid." & vbCrLf & "Continue anyway?", _
                        MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, _
                        "Checking parameters") = MsgBoxResult.No Then Exit Function
        End If

        CheckParameters = False

    End Function

    Private Sub ClearParameters(ByVal iImpType As Implant.IMPLANTTYPE)

        myFitt = Nothing
        myFitt = New Implant(iImpType)
        myFitt.Ear = mlEar
        mlMinDistCorrect = myFitt.MinDist
        mszFileName = ""
        Select Case iImpType
            Case Implant.IMPLANTTYPE.imptInvalid
                mszFittDefaultLeft = ""
                mszFittDefaultRight = ""
            Case Implant.IMPLANTTYPE.imptC40C
                mszFittDefaultLeft = "RIB_c40c.fitt"
                mszFittDefaultRight = "RIB_c40c.fitt"
            Case Implant.IMPLANTTYPE.imptC40P
                mszFittDefaultLeft = "RIB_c40p.fitt"
                mszFittDefaultRight = "RIB_c40p.fitt"
            Case Implant.IMPLANTTYPE.imptC40P_RIB2
                mszFittDefaultLeft = "RIB2_c40p.ampmap"
                mszFittDefaultRight = "RIB2_c40p.ampmap"
            Case Implant.IMPLANTTYPE.imptPulsar
                mszFittDefaultLeft = "RIB2_pulsar.ampmap"
                mszFittDefaultRight = "RIB2_pulsar.ampmap"
            Case Implant.IMPLANTTYPE.imptCIC3
                mszFittDefaultLeft = "NIC_CIC3.fitt"
                mszFittDefaultRight = "NIC_CIC3.fitt"
        End Select

    End Sub

    Private Sub UpdateForm()
        ' set control values
        mblnInitControls = True
        lblImpType.Text = "Implant Type: " & myFitt.ImpTypeString
        txtFName.Text = myFitt.FirstName
        txtLName.Text = myFitt.LastName
        If myFitt.Ear = Implant.EARTYPE.LEFT Then lblEar.Text = "Ear: Left" Else lblEar.Text = "Ear: Right"
        txtMinDist.Text = VB.Right("   " & Str(mlMinDistCorrect), 3)
        mlPulsePeriod = myFitt.PulsePeriod
        txtPulseRate.Text = TStr(Math.Round(1000000 / (mlPulsePeriod * myFitt.TimeBase), 1))
        txtPulsePeriod.Text = TStr(Math.Round(mlPulsePeriod * myFitt.TimeBase, 1))
        lblPPer.Text = "µs = " & TStr(mlPulsePeriod) & " tu"
        lblTimeBase.Text = "Timebase: 1 tu = " & TStr(Math.Round(myFitt.TimeBase, 2)) & " µs"
        txtMapLaw.Text = myFitt.MapLaw
        txtChannelOrder.Text = myFitt.ChannelOrder

        ' set comboboxes to define datastream type and gap duration 
        ' according to <myFitt.DataStreamType> and <myFitt.GapDuration>
        If Me.GenMode = STIM.GENMODE.genElectricalRIB2 Or Me.GenMode = STIM.GENMODE.genVocoder Then
            Select Case myFitt.ImpType
                Case Implant.IMPLANTTYPE.imptC40P_RIB2
                    ' C40P implants can only handle legacy datastreams
                    cbxDataStream.SelectedIndex = 0     ' index = 0 equals to "Legacy"
                    cbxGapDur.Items.Clear()
                    cbxGapDur.Items.Add("0")            ' gap duration for C40P is 0us
                    cbxGapDur.SelectedIndex = 0
                Case Implant.IMPLANTTYPE.imptPulsar
                    ' otherwise enable legacy / pulsar datastream
                    Select Case myFitt.DataStreamType
                        Case "Legacy"
                            cbxDataStream.SelectedIndex = 0
                            cbxGapDur.Items.Clear()
                            cbxGapDur.Items.Add("2.1")
                            cbxGapDur.SelectedIndex = 0
                        Case "Pulsar"
                            cbxDataStream.SelectedIndex = 1
                            cbxGapDur.Items.Clear()
                            cbxGapDur.Items.AddRange(New Object() {"2.1", "10", "20", "30"})
                            If cbxGapDur.FindStringExact(CStr(myFitt.GapDuration)) <> -1 Then
                                cbxGapDur.SelectedIndex = cbxGapDur.FindStringExact(CStr(myFitt.GapDuration))
                            Else
                                MsgBox("Gap duration given in the file is not valid! Gap duration is set to nearest value able to be generated by the implant.")
                                If myFitt.GapDuration <= 9.97 Then
                                    cbxGapDur.SelectedIndex = 0
                                ElseIf myFitt.GapDuration >= 9.98 And myFitt.GapDuration <= 19.97 Then
                                    cbxGapDur.SelectedIndex = 1
                                ElseIf myFitt.GapDuration >= 19.98 And myFitt.GapDuration <= 29.97 Then
                                    cbxGapDur.SelectedIndex = 2
                                ElseIf myFitt.GapDuration >= 29.98 Then
                                    cbxGapDur.SelectedIndex = 3
                                Else
                                    cbxGapDur.SelectedIndex = 0
                                End If
                                myFitt.GapDuration = CDbl(Val(cbxGapDur.Text))
                            End If

                        Case Else
                            'Set default data stream <Legacy> if no datastreamtype is defined (e.g. when a new Pulsar implant is created)
                            'MsgBox("Unknown data stream command! Default data stream <Legacy> was set.")
                            cbxDataStream.SelectedIndex = 0
                            cbxGapDur.Items.Clear()
                            cbxGapDur.Items.Add("2.1")          ' gap duration for Pulsar implants is 2.1us for legacy data stream
                            cbxGapDur.SelectedIndex = 0
                    End Select
            End Select
        End If
        txtDuration.Text = TStr(myFitt.Duration)
        txtPrefix.Text = myFitt.Prefix
        For lX As Integer = 0 To myFitt.ChannelsCount - 1
            sldMCL(lX).Value = myFitt.Channel(lX).lMCL
            sldTHR(lX).Value = myFitt.Channel(lX).lTHR
            cmbRange(CShort(lX)).SelectedIndex = myFitt.Channel(lX).lRange
            txtPhDurTU(CShort(lX)).Text = Trim(Str(myFitt.Channel(lX).lPhDur))
            If sldTHR(lX).Value >= sldMCL(lX).Value And myFitt.Channel(lX).blnChUsed <> False Then myFitt.Channel(lX).blnChUsed = False ' if blnChUsed variable is not set correctly (e.g. when loading an old fitting file and a channel is not used)
            chkboxChUsed(CShort(lX)).Checked = myFitt.Channel(lX).blnChUsed
        Next
        mblnInitControls = False
        ' update labels
        lblMinDist.Text = "tu = " & Str(Math.Round(mlMinDistCorrect * myFitt.TimeBase, 1)) & " µs"
        For lX As Short = 0 To CShort(myFitt.ChannelsCount - 1)
            lblMCL(lX).Text = TStr(myFitt.Channel(lX).lMCL) & " cu" & vbCrLf & _
                                myFitt.CalcCurrentAsString(myFitt.Channel(lX).lMCL, myFitt.Channel(lX).lRange) & " µA"
            lblTHR(lX).Text = TStr(myFitt.Channel(lX).lTHR) & " cu" & vbCrLf & _
                                myFitt.CalcCurrentAsString(myFitt.Channel(lX).lTHR, myFitt.Channel(lX).lRange) & " µA"
            lblPhDur(lX).Text = "tu" & vbCrLf & vbCrLf & " µs"
            txtPhDur(lX).Text = LTrim(Str(Math.Round(Val(txtPhDurTU(lX).Text) * myFitt.TimeBase, 1)))
            SetDynamic(lX)
            SetMaxEnergy(lX)
        Next
        Me.Text = "Fitt4Fun" & " [ " & mszFileName & " ]"
        mnuFileClose.Enabled = True

    End Sub

    Private Sub BuildForm()

        mblnInitControls = True

        ' Unload all controls
        If lblCh.Count > 1 Then
            For lX As Short = 1 To CShort(lblCh.Count - 1)
                lblCh.Unload(lX)
                cmdMCL.Unload(lX)
                cmdTHR.Unload(lX)
                lblTHR.Unload(lX)
                lblMCL.Unload(lX)
                txtPhDur.Unload(lX)
                txtPhDurTU.Unload(lX)
                lblPhDur.Unload(lX)
                cmbRange.Unload(lX)
                lblMaxEnergy.Unload(lX)
                lblDynamic.Unload(lX)
                lblMem.Unload(lX)
                cmdMemSMCL.Unload(lX)
                cmdMemRMCL.Unload(lX)
                chkboxChUsed.Unload(lX)
                Me.Controls.Remove(sldTHR(lX))
                Me.Controls.Remove(sldMCL(lX))
            Next
        End If
        sldTHR.Clear()
        sldMCL.Clear()
        Select Case Me.GenMode
            Case STIM.GENMODE.genElectricalRIB
                Me.mnuFileNewCIC3.Enabled = False
                Me.tbToolStripMenu_NewCIC3.Enabled = False
                Me.mnuFileNewC40C.Enabled = True
                Me.mnuFileNewC40P.Enabled = True
                Me.tbToolStripMenu_NewC40C.Enabled = True
                Me.tbToolStripMenu_NewC40P.Enabled = True
                Me.mnuFileNewPulsar.Enabled = False
                Me.tbToolStripMenu_NewPulsar.Enabled = False
            Case STIM.GENMODE.genElectricalNIC
                Me.mnuFileNewCIC3.Enabled = True
                Me.tbToolStripMenu_NewCIC3.Enabled = True
                Me.mnuFileNewC40C.Enabled = False
                Me.mnuFileNewC40P.Enabled = False
                Me.tbToolStripMenu_NewC40C.Enabled = False
                Me.tbToolStripMenu_NewC40P.Enabled = False
                Me.mnuFileNewPulsar.Enabled = False
                Me.tbToolStripMenu_NewPulsar.Enabled = False
            Case STIM.GENMODE.genElectricalRIB2, STIM.GENMODE.genVocoder
                Me.mnuFileNewCIC3.Enabled = False
                Me.tbToolStripMenu_NewCIC3.Enabled = False
                Me.mnuFileNewC40C.Enabled = False
                Me.mnuFileNewC40P.Enabled = True
                Me.tbToolStripMenu_NewC40C.Enabled = False
                Me.tbToolStripMenu_NewC40P.Enabled = True
                Me.mnuFileNewPulsar.Enabled = True
                Me.tbToolStripMenu_NewPulsar.Enabled = True
        End Select
        cbxGapDur.Items.Clear()

        ' If no valid implant type -> Disable controls and exit
        If myFitt.ImpType = Implant.IMPLANTTYPE.imptInvalid Then
            ' Disable all controls
            Me.Width = mlMeWidth
            pictVisible.Left = 0
            pictVisible.Top = tbToolBar.Top + tbToolBar.Height
            pictVisible.Width = Me.Width
            pictVisible.Height = sbStatusBar.Top - pictVisible.Top - 10
            pictVisible.Visible = True
            _sldTHR_0.Enabled = False
            _sldMCL_0.Enabled = False
            txtFName.Enabled = False
            txtLName.Enabled = False
            txtMinDist.Enabled = False
            txtPhDur(0).Enabled = False
            txtPhDurTU(0).Enabled = False
            chkboxChUsed(0).Enabled = False
            panelData.Visible = False
            panelDataRIB2.Visible = False
            lblImpType.Text = ""
            lblEar.Text = ""
            lblTimeBase.Text = ""
            Me.Text = "Fitt4Fun"
            For lX As Short = 0 To CShort(lineGrid.Count - 1)
                lineGrid(lX).Visible = False
            Next
            mnuFileSaveAs.Enabled = False
            tbToolBar_SaveAs.Enabled = False
            mnuFileClose.Enabled = False
            mblnInitControls = False
            Return
        End If

        ' Valid implant type - Build all controls

        ' Channel 0
        sldTHR = New System.Collections.Generic.List(Of TrackBar)
        sldTHR.Insert(0, _sldTHR_0)
        sldTHR(0).Enabled = True
        sldMCL = New System.Collections.Generic.List(Of TrackBar)
        sldMCL.Insert(0, _sldMCL_0)
        sldMCL(0).Enabled = True
        txtPhDur(0).Enabled = True
        txtPhDurTU(0).Enabled = True
        chkboxChUsed(0).Enabled = True
        ' Channel controls
        For lX As Short = 1 To CShort(myFitt.ChannelsCount - 1)
            lblCh.Load(lX)
            lblCh(lX).Left = lblCh(0).Left + lblCh(0).Width * lX
            lblCh(lX).Text = Str(lX + 1)
            lblCh(lX).Visible = True
            lblCh(lX).BringToFront()
            cmdMCL.Load(lX)
            cmdMCL(lX).Left = cmdMCL(0).Left + lblCh(0).Width * lX
            cmdMCL(lX).Visible = True
            cmdMCL(lX).BringToFront()
            lblMCL.Load(lX)
            lblMCL(lX).Left = lblMCL(0).Left + lblCh(0).Width * lX
            lblMCL(lX).Visible = True
            lblMCL(lX).BringToFront()
            cmdTHR.Load(lX)
            cmdTHR(lX).Left = cmdTHR(0).Left + lblCh(0).Width * lX
            cmdTHR(lX).Visible = True
            cmdTHR(lX).BringToFront()
            lblTHR.Load(lX)
            lblTHR(lX).Left = lblTHR(0).Left + lblCh(0).Width * lX
            lblTHR(lX).Visible = True
            lblTHR(lX).BringToFront()
            lblPhDur.Load(lX)
            lblPhDur(lX).Left = lblPhDur(0).Left + lblCh(0).Width * lX
            lblPhDur(lX).Visible = True
            lblPhDur(lX).Text = "tu" & vbCrLf & vbCrLf & " µs"
            lblPhDur(lX).BringToFront()
            cmbRange.Load(lX)
            cmbRange(lX).Left = cmbRange(0).Left + lblCh(0).Width * lX
            cmbRange(lX).Visible = True
            cmbRange(lX).BringToFront()
            txtPhDur.Load(lX)
            txtPhDur(lX).Left = txtPhDur(0).Left + lblCh(0).Width * lX
            txtPhDur(lX).Visible = True
            txtPhDur(lX).BringToFront()
            txtPhDurTU.Load(lX)
            txtPhDurTU(lX).Left = txtPhDurTU(0).Left + lblCh(0).Width * lX
            txtPhDurTU(lX).Visible = True
            txtPhDurTU(lX).BringToFront()
            chkboxChUsed.Load(lX)
            chkboxChUsed(lX).Left = chkboxChUsed(0).Left + lblCh(0).Width * lX
            chkboxChUsed(lX).Visible = True
            chkboxChUsed(lX).BringToFront()
            ' THR slider
            Dim sldX As New TrackBar
            AddHandler sldX.ValueChanged, AddressOf Me.sldTHR_Change
            AddHandler sldX.Leave, AddressOf Me.sldTHR_Leave
            AddHandler sldX.Scroll, AddressOf Me.sldTHR_Scroll
            AddHandler sldX.KeyDown, AddressOf Me.sldTHR_KeyDownEvent
            AddHandler sldX.KeyPress, AddressOf Me.sldTHR_KeyPressEvent
            AddHandler sldX.Enter, AddressOf Me.sldTHR_Enter
            sldX.Left = sldTHR(0).Left + lblCh(0).Width * lX
            sldX.Top = sldTHR(0).Top
            sldX.Orientation = Orientation.Vertical
            sldX.AutoSize = False
            sldX.Size = sldTHR(0).Size
            sldX.TickFrequency = sldTHR(0).TickFrequency
            sldX.Visible = True
            sldTHR.Insert(lX, sldX)
            Me.Controls.Add(sldX)
            sldX.BringToFront()
            ' MCL slider
            sldX = New TrackBar
            AddHandler sldX.ValueChanged, AddressOf Me.sldMCL_Change
            AddHandler sldX.Leave, AddressOf Me.sldMCL_Leave
            AddHandler sldX.Scroll, AddressOf Me.sldMCL_Scroll
            AddHandler sldX.KeyDown, AddressOf Me.sldMCL_KeyDownEvent
            AddHandler sldX.KeyPress, AddressOf Me.sldMCL_KeyPressEvent
            AddHandler sldX.Enter, AddressOf Me.sldMCL_Enter
            sldX.Left = sldMCL(0).Left + lblCh(0).Width * lX
            sldX.Top = sldMCL(0).Top
            sldX.Orientation = Orientation.Vertical
            sldX.AutoSize = False
            sldX.Size = sldMCL(0).Size
            sldX.TickFrequency = sldMCL(0).TickFrequency
            sldX.TickStyle = TickStyle.TopLeft
            sldX.Visible = True
            sldMCL.Insert(lX, sldX)
            Me.Controls.Add(sldX)
            sldX.BringToFront()
            sldMCL(lX).Visible = True
            ' Labels
            lblMaxEnergy.Load(lX)
            lblMaxEnergy(lX).Left = lblMaxEnergy(0).Left + lblCh(0).Width * lX
            lblMaxEnergy(lX).Visible = True
            lblMaxEnergy(lX).BringToFront()
            lblDynamic.Load(lX)
            lblDynamic(lX).Left = lblDynamic(0).Left + lblCh(0).Width * lX
            lblDynamic(lX).Visible = True
            lblDynamic(lX).BringToFront()
            lblMem.Load(lX)
            lblMem(lX).Left = lblMem(0).Left + lblCh(0).Width * lX
            lblMem(lX).Visible = True
            lblMem(lX).BringToFront()
            cmdMemSMCL.Load(lX)
            cmdMemSMCL(lX).Left = cmdMemSMCL(0).Left + lblCh(0).Width * lX
            cmdMemSMCL(lX).Visible = True
            cmdMemSMCL(lX).BringToFront()
            cmdMemRMCL.Load(lX)
            cmdMemRMCL(lX).Left = cmdMemRMCL(0).Left + lblCh(0).Width * lX
            cmdMemRMCL(lX).Visible = True
            cmdMemRMCL(lX).BringToFront()
        Next
        ' Rest of General
        txtFName.Enabled = True
        txtLName.Enabled = True
        txtMinDist.Enabled = True
        panelData.Visible = True

        If Me.GenMode = STIM.GENMODE.genElectricalRIB2 Then

            txtMapLaw.Enabled = False               ' default maplaw is "" / "Zero"
            txtChannelOrder.Enabled = False         ' not used for RIB2

            ' only Legacy datastreams enabled
            ' if Pulsar datastreams want to be enabled, replace the following lines with the commented part below!
            cbxDataStream.SelectedIndex = 0     ' index = 0 equals to "Legacy"
            cbxDataStream.Enabled = False       ' disable because "Pulsar" (index 1) is not valid
            cbxGapDur.Enabled = False           ' disable because gap duration is not adaptable for Legacy datastream

            '    ' if RIB2 are used, set comboboxes to define datastream type and gap duration visible (comboboxes are set in UpdateForm())
            '    Select Case myFitt.ImpType
            '        Case Implant.IMPLANTTYPE.imptC40P_RIB2
            '            ' C40P implants can only handle legacy datastreams
            '            cbxDataStream.SelectedIndex = 0     ' index = 0 equals to "Legacy"
            '            cbxDataStream.Enabled = False       ' disable because "Pulsar" (index 1) is not valid for C40P implants
            '            cbxGapDur.Enabled = False           ' disable because gap duration is not adaptable for C40P implants
            '        Case Implant.IMPLANTTYPE.imptPulsar
            '            ' otherwise enable legacy / pulsar datastream
            '            cbxDataStream.Enabled = True
            '            cbxGapDur.Enabled = True
            '    End Select

            panelDataRIB2.Visible = True
        Else : panelDataRIB2.Visible = False
        End If

        Me.Width = myFitt.ChannelsCount * lblCh(0).Width + 2 * lblCh(0).Left
        For lX As Short = 0 To CShort(lineGrid.Count - 1)
            lineGrid(lX).Visible = True
            lineGrid(lX).Left = lblCh(0).Left \ 3
            lineGrid(lX).Width = Me.Width - 2 * lblCh(0).Left \ 3
            lineGrid(lX).BringToFront()
        Next
        pictVisible.Visible = False

        ' Set controls
        lblImpType.Text = "Implant Type: " & myFitt.ImpTypeString
        For lX As Short = 0 To CShort(myFitt.ChannelsCount - 1)
            sldMCL(lX).Maximum = myFitt.Channel(lX).lMCL
            sldTHR(lX).Maximum = myFitt.Channel(lX).lMCL
            sldMCL(lX).Minimum = myFitt.Channel(lX).lTHR
            sldTHR(lX).Minimum = myFitt.Channel(lX).lTHR
            cmbRange(lX).Items.Clear()
            For lY As Integer = 0 To myFitt.RangeCount - 1
                cmbRange(lX).Items.Add(TStr(lY))
            Next
            lblMem(lX).Text = "---"
            cmdMemRMCL(lX).Enabled = False
        Next
        Me.Text = "Fitt4Fun"
        mnuFileSaveAs.Enabled = True
        tbToolBar_SaveAs.Enabled = True
        mnuFileClose.Enabled = True
        mblnInitControls = False

    End Sub

    'Private Sub cmbEar_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    'If mblnInitControls Then Return
    'If myFitt.Ear = cmbEar.SelectedIndex Then Exit Sub
    'Dim iType As Fitt4RIB.IMPLANTTYPE
    'If cmbEar.SelectedIndex = Fitt4RIB.EARLEFT Then iType = gstLeft.iImpType Else iType = gstRight.iImpType

    'myFitt.Ear = cmbEar.SelectedIndex
    'AutoNaming()

    'End Sub

    'Private Sub cmbImpType_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    'Dim iType, iNew As Long
    'If myFitt.ImpType = (cmbImpType.SelectedIndex + 1) Then Exit Sub
    'iNew = (cmbImpType.SelectedIndex + 1)
    'If myFitt.Ear = Fitt4RIB.EARLEFT Then iType = gstLeft.iImpType Else iType = gstRight.iImpType

    'If mblnStimulation Then
    '    If iNew <> iType Then
    '        If MsgBox("Stimulation is on!" & vbCrLf & "The RIB for the current ear is set to different implant type" & vbCrLf & "Do you want to continue?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
    '            cmbImpType.SelectedIndex = myFitt.ImpType - 1
    '            Exit Sub
    '        End If
    '    End If
    'End If

    'If mblnChanged Then
    '    If MsgBox("Changing the implant can reset some parameters!" & vbCrLf & "Continue anyway?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Exclamation, "Change implant") = MsgBoxResult.No Then Exit Sub
    'End If

    'Select Case iNew
    '    Case Fitt4RIB.IMPLANTTYPE.imptInvalid
    '        myFitt.ImpType = Fitt4RIB.IMPLANTTYPE.imptInvalid
    '    Case Fitt4RIB.IMPLANTTYPE.imptC40C
    '        myFitt.ImpType = Fitt4RIB.IMPLANTTYPE.imptC40C
    '    Case Fitt4RIB.IMPLANTTYPE.imptC40P
    '        myFitt.ImpType = Fitt4RIB.IMPLANTTYPE.imptC40P
    '    Case Else
    '        MsgBox("Implant type unknown", MsgBoxStyle.Critical, "ChangeParameters")
    '        Return
    'End Select
    'mblnChanged = True
    'SetChangedTitle()
    'BuildForm()
    'UpdateForm()

    'End Sub


    Private Sub cmbRange_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbRange.SelectedIndexChanged
        If mblnInitControls Then Return
        Dim Index As Short = cmbRange.GetIndex(DirectCast(eventSender, ComboBox))
        Dim lRange As Integer = cmbRange(Index).SelectedIndex

        If myFitt.Channel(Index).lRange <> lRange Then
            ' THR
            Dim sX As Double = myFitt.CalcCurrent(sldTHR(Index).Value, myFitt.Channel(Index).lRange)
            Dim lX As Integer = myFitt.CalcAmplitude(sX, lRange)
            If lX > myFitt.AMP_MAX Then lX = myFitt.AMP_MAX
            If lX < myFitt.AMP_MIN Then lX = myFitt.AMP_MIN
            myFitt.Channel(Index).lTHR = lX
            sldTHR(Index).Value = lX
            ' MCL
            sX = myFitt.CalcCurrent(sldMCL(Index).Value, myFitt.Channel(Index).lRange)
            lX = myFitt.CalcAmplitude(sX, lRange)
            If lX > myFitt.AMP_MAX Then lX = myFitt.AMP_MAX
            If lX < myFitt.AMP_MIN Then lX = myFitt.AMP_MIN
            myFitt.Channel(Index).lMCL = lX
            sldMCL(Index).Value = lX
            ' save new value
            myFitt.Channel(Index).lRange = cmbRange(Index).SelectedIndex
            ' update labels
            lblTHR(Index).Text = TStr(sldTHR(Index).Value) & " cu" & vbCrLf & _
                    myFitt.CalcCurrentAsString(sldTHR(Index).Value, myFitt.Channel(Index).lRange) & " µA"
            lblMCL(Index).Text = TStr(sldMCL(Index).Value) & " cu" & vbCrLf & _
                    myFitt.CalcCurrentAsString(sldMCL(Index).Value, myFitt.Channel(Index).lRange) & " µA"
        End If
        SetMaxEnergy((Index))
        SetDynamic(Index)
        SetChangedTitle()

        ' set focus to the slider
        If (mlElectrodeIndex And &H10000) > 0 Then
            If sldMCL(Index).Enabled And sldMCL(Index).Visible Then sldMCL(Index).Focus()
        Else
            If sldTHR(Index).Enabled And sldTHR(Index).Visible Then sldTHR(Index).Focus()
        End If
    End Sub

    Private Sub cmdMCL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMCL.Click

        If mbPlaying = False Then
            '
            ' ML (2020-11-17): THe MinDist is a parameter given in samples (proportional to MICROseconds), Duration is given in MILLIseconds. The If condition is adjusted. The RIB2 should be able to play arbitrarily short pulse sequences.
            '
            ' OLD CODE:
            ' If CInt(myFitt.Duration) < CInt(myFitt.MinDist) Then MsgBox("Signal duration (" & myFitt.Duration & " ms) is too short!" & vbCrLf & "Min. duration: " & myFitt.MinDist & " ms", MsgBoxStyle.Exclamation, "Stimulate") : Exit Sub
            '
            If CInt(1e3 * myFitt.Duration) < CInt(myFitt.MinDist * myFitt.TimeBase) Then MsgBox("Signal duration (" & TStr(myFitt.Duration) & " ms) is too short!" & vbCrLf & "Min. duration: " & TStr(CInt(myFitt.MinDist * myFitt.TimeBase)) & " ms", MsgBoxStyle.Exclamation, "Stimulate") : Exit Sub
            mbPlaying = True
            Dim Index As Short = cmdMCL.GetIndex(DirectCast(eventSender, Button))
            gblnCancel = False
            mlElectrodeIndex = Index + &H10000
            sldMCL(Index).Focus()
            Stimulate(myFitt.Channel(Index).lMCL, myFitt.Channel(Index).lRange, Index + 1, myFitt.Channel(Index).lPhDur)
            mbPlaying = False
            If gblnAutoBackupItemList Then BackupFittFile()
        End If

    End Sub

    Private Sub cmdMemRMCL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMemRMCL.Click
        Dim Index As Short = cmdMemRMCL.GetIndex(DirectCast(eventSender, Button))
        myFitt.Channel(Index).lMCL = CInt(Val(lblMem(Index).Text))
        sldMCL(Index).Value = myFitt.Channel(Index).lMCL
        sldMCL_Change(sldMCL.Item(Index), New System.EventArgs())
        Windows.Forms.Application.DoEvents()
    End Sub

    Private Sub cmdMemSMCL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMemSMCL.Click
        Dim Index As Short = cmdMemSMCL.GetIndex(DirectCast(eventSender, Button))
        lblMem(Index).Text = CStr(myFitt.Channel(Index).lMCL)
        myFitt.Channel(Index).lCL = myFitt.Channel(Index).lMCL
        cmdMemRMCL(Index).Enabled = True
        mnuAmpExport.Enabled = True
    End Sub

    Private Sub cmdTHR_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdTHR.Click
        If mbPlaying = False Then
            '
            ' ML (2020-11-17): THe MinDist is a parameter given in samples (proportional to MICROseconds), Duration is given in MILLIseconds. The If condition is adjusted. The RIB2 should be able to play arbitrarily short pulse sequences.
            '
            ' OLD CODE:
            ' If CInt(myFitt.Duration) < CInt(myFitt.MinDist) Then MsgBox("Signal duration (" & myFitt.Duration & " ms) is too short!" & vbCrLf & "Min. duration: " & myFitt.MinDist & " ms", MsgBoxStyle.Exclamation, "Stimulate") : Exit Sub
            '            
            If CInt(1e3 * myFitt.Duration) < CInt(myFitt.MinDist * myFitt.TimeBase) Then MsgBox("Signal duration (" & myFitt.Duration & " ms) is too short!" & vbCrLf & "Min. duration: " & myFitt.MinDist & " ms", MsgBoxStyle.Exclamation, "Stimulate") : Exit Sub
            mbPlaying = True
            Dim Index As Short = cmdTHR.GetIndex(DirectCast(eventSender, Button))
            gblnCancel = False
            mlElectrodeIndex = Index
            sldTHR(Index).Focus()
            Stimulate(myFitt.Channel(Index).lTHR, myFitt.Channel(Index).lRange, Index + 1, myFitt.Channel(Index).lPhDur)
            mbPlaying = False
            If gblnAutoBackupItemList Then BackupFittFile()
        End If
    End Sub

    Private Sub frmFitt4Fun_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If eventArgs.KeyCode = System.Windows.Forms.Keys.Escape Then gblnCancel = True
    End Sub

    'Private Sub frmFitt4Fun_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
    'Dim KeyAscii As Integer = Asc(eventArgs.KeyChar)
    'UPGRADE_ISSUE: Control Name could not be resolved because it was within the generic namespace ActiveControl. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
    'Select Case VB6.GetActiveControl().Name
    'Select Case ActiveControl.Name
    '    Case "sldMCL", "sldTHR", "txtFName", "txtLName", "txtPrefix"
    '        GoTo EventExitSub 'control handles keypress
    '    Case Else
    '        Select Case KeyAscii
    '            Case Asc("t")
    '                sldTHR(0).Focus()
    '            Case Asc("m")
    '                sldMCL(0).Focus()
    '        End Select
    'End Select
    'EventExitSub:
    'eventArgs.KeyChar = Chr(KeyAscii)
    'If KeyAscii = 0 Then
    '    eventArgs.Handled = True
    'End If
    'End Sub

    Private Sub frmFitt4Fun_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        ' set default, fitting parameters
        msMaxEnergy = 70
        ' set default, options
        mszFileName = FileName

        ' check left
        If grectFitt4Fun.Left + 0.25 * Me.Width > Screen.PrimaryScreen.Bounds.Width Then
            grectFitt4Fun.Left = Screen.PrimaryScreen.Bounds.Width - Me.Width \ 4
        End If
        If grectFitt4Fun.Left + 0.75 * Me.Width < 0 Then
            grectFitt4Fun.Left = -3 * Me.Width \ 4
        End If
        ' check top
        If grectFitt4Fun.Top + 0.25 * Me.Height > Screen.PrimaryScreen.Bounds.Height Then
            grectFitt4Fun.Top = Screen.PrimaryScreen.Bounds.Height - Me.Height \ 4
        End If
        If grectFitt4Fun.Top < 0 Then
            grectFitt4Fun.Top = 0
        End If
        Me.SetBounds(grectFitt4Fun.Left, grectFitt4Fun.Top, 0, 0, BoundsSpecified.X Or BoundsSpecified.Y)
        mlMeWidth = Me.Width

        ' set controls
        Select Case Me.Mode
            Case Fitt4FunMode.NewFittingFile
                ClearParameters((Implant.IMPLANTTYPE.imptInvalid))
                BuildForm()
                UpdateForm()
                mblnFittingChanged = False
            Case Fitt4FunMode.EditFittingFile
                ClearParameters((Implant.IMPLANTTYPE.imptInvalid))
                BuildForm()
                UpdateForm()
                mblnFittingChanged = False
                Me.OpenFittFile(Me.FileName)
        End Select
        Me.Mode = Fitt4FunMode.FittingCancelled ' assume cancelling, will be changed on save
        SetUIReady()

    End Sub

    Private Sub frmFitt4Fun_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If mblnStimulation Then
            MsgBox("Diconnect before exit.", MsgBoxStyle.Critical, "Exit Fitt4Fun")
            e.Cancel = True
            Return
        End If

        If mblnFittingChanged Then
            If MsgBox("Current fitting was changed. If you exit now, the changes will not be saved to the file." & vbCrLf _
                & "Continue anyway?", MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Exclamation, _
                "Exit Fitt4Fun") = MsgBoxResult.No Then
                e.Cancel = True ' do not exit
                Return
            Else
                e.Cancel = False ' exit and lose changes
            End If
        Else
            e.Cancel = False ' exit with no changes
        End If

        ' check for saved levels and warn about losing if not exported
        Dim blnChanged As Boolean = False
        For lX As Short = 0 To CShort(myFitt.ChannelsCount - 1)
            If lblMem(lX).Text <> "---" Then blnChanged = True : Exit For
        Next
        If FileName <> mszFileName Then blnChanged = True
        If blnChanged Then
            Dim resX As MsgBoxResult = MsgBox("Parameters which can not be saved to the fitting file have been changed." & _
                    vbCrLf & vbCrLf & _
                    "Do you want me to pass these parameters to the application?", MsgBoxStyle.YesNoCancel, "Exit Fitt4Fun")
            If resX = MsgBoxResult.Cancel Then e.Cancel = True : Return
            If resX = MsgBoxResult.Yes Then
                ReDim Amplitude(lblMem.Count - 1)
                For lX As Short = 0 To CShort(lblMem.Count - 1)
                    If lblMem(lX).Text = "---" Then
                        Amplitude(lX) = Double.NaN
                    Else
                        Amplitude(lX) = Val(lblMem(lX).Text)
                    End If
                Next
                FileName = mszFileName
                Me.Mode = Fitt4FunMode.FittingUpdated
                e.Cancel = False
            Else
                Erase Amplitude    ' do not pass the amplitudes to the setting (Updated or Cancelled)
                e.Cancel = False
            End If
        End If

    End Sub

    Private Sub frmFitt4Fun_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        ' save options
        grectFitt4Fun.Left = Me.Left
        grectFitt4Fun.Top = Me.Top

    End Sub

    Public Sub mnuFileClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileClose.Click
        ClearParameters((Implant.IMPLANTTYPE.imptInvalid))
        BuildForm()
    End Sub

    Public Sub mnuFileExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileExit.Click
        Me.Close()
    End Sub

    Public Sub mnuFileOpen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileOpen.Click
        If mblnFittingChanged Then
            If MsgBox("Current fitting was changed. If you open a new one, all changes will be discarded." & _
                    vbCrLf & "Continue anyway?", _
                    MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Exclamation, _
                    "Open fitting file") = MsgBoxResult.No Then Return
        End If

        Dim dlgOpen As New OpenFileDialog
        dlgOpen.Title = "Open Fitting File"
        If Len(mszFileName) > 0 Then dlgOpen.InitialDirectory = IO.Path.GetDirectoryName(mszFileName)
        dlgOpen.CheckFileExists = True
        dlgOpen.CheckPathExists = True
        dlgOpen.CheckPathExists = True
        dlgOpen.Filter = "RIB Fitting Files (*.fitt)|*.fitt|RIB2 Fitting Files (*.ampmap)|*.ampmap|All Files (*.*)|*.*"
        Select Case Me.GenMode
            Case STIM.GENMODE.genElectricalRIB, STIM.GENMODE.genElectricalNIC
                dlgOpen.FilterIndex = 1
            Case STIM.GENMODE.genElectricalRIB2, STIM.GENMODE.genVocoder
                dlgOpen.FilterIndex = 2
        End Select
        If dlgOpen.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
        Me.OpenFittFile(dlgOpen.FileName)
        SetUIReady()
    End Sub

    Private Sub OpenFittFile(ByVal szFileName As String)
        Dim szErr, szX As String
        Dim szArray As String()
        Dim lVarMinDist As Integer ' "platzhalter" variable to set correct minimum distance according to the different generation modes /implant types
        Dim lX, lMax As Integer
        ' save old implant type
        Dim itypeOld As Implant.IMPLANTTYPE = myFitt.ImpType
        ' get implant type
        Dim fittX As New Implant(Implant.IMPLANTTYPE.imptInvalid)
        szErr = fittX.OpenFile(szFileName)
        If Len(szErr) > 0 Then _
                    MsgBox("Can't open file:" & vbCrLf & szErr, _
                            MsgBoxStyle.Critical, "Open file") : Return
        ' check the device type
        Select Case Me.GenMode
            Case STIM.GENMODE.genElectricalRIB, STIM.GENMODE.genElectricalNIC
                If fittX.DeviceTypeRequired <> Me.GenMode Then _
                   MsgBox("Fitting file is not valid for this output device.") : Return
            Case STIM.GENMODE.genElectricalRIB2, STIM.GENMODE.genVocoder
                Select Case fittX.ImpType
                    Case Implant.IMPLANTTYPE.imptCIC3
                        MsgBox("Fitting file is not valid for this output device.") : Return
                    Case Implant.IMPLANTTYPE.imptC40C
                        MsgBox("Fitting file is not valid for this output device. Implant type C40C is not supported with RIB2.") : Return
                    Case Implant.IMPLANTTYPE.imptC40P
                        MsgBox("You are loading a fitting file in .fitt format! Before using it with RIB2, it has to be saved in .ampmap file format!")
                    Case Implant.IMPLANTTYPE.imptC40P_RIB2, Implant.IMPLANTTYPE.imptPulsar
                        ' correct implant and device type, no error message
                End Select
        End Select

        ' check if different type
        If mblnStimulation Then
            If fittX.ImpType <> itypeOld Then MsgBox("Implant type must be the same when connected.") : Return
            If fittX.Ear <> mlEar Then MsgBox("Ear must be the same as connected.") : Return
        Else
            If fittX.Ear <> mlEar Then MsgBox("Ear does not match and will be corrected.", MsgBoxStyle.Information)
        End If
        ' set to the new type and read the file
        ClearParameters(fittX.ImpType)
        BuildForm()
        myFitt = New Implant 'added by miho 07.2020
        szErr = myFitt.OpenFile(szFileName)

        'Dim myFitt2 As New Implant
        'szErr = myFitt2.OpenFile(szFileName)

        If Len(szErr) > 0 Then
            MsgBox("Can't open file:" & vbCrLf & szErr, MsgBoxStyle.Critical, "Open file")
            ClearParameters(Implant.IMPLANTTYPE.imptInvalid)
            BuildForm()
            Return
        End If
        myFitt.Ear = mlEar
        mszFileName = szFileName

        ' If an old (RIB1) C40P opened with RIB2 -> convert to C40P_RIB2
        If (Me.GenMode = STIM.GENMODE.genElectricalRIB2 Or Me.GenMode = STIM.GENMODE.genVocoder) And myFitt.ImpType = Implant.IMPLANTTYPE.imptC40P Then
            myFitt.ImpType = Implant.IMPLANTTYPE.imptC40P_RIB2
        End If

        ' copy and check parameters from the file name
        szArray = mszFileName.Split(CChar("_"))
        For lX = 0 To UBound(szArray)
            szX = "IPI"
            If CBool(InStr(szArray(lX), szX)) Then
                szX = szArray(lX).Trim(szX.ToCharArray())
                If IsNumeric(szX) Then
                    ' IPI is stored within the file, compare with IPI from filename
                    If CInt(Val(szX) / myFitt.TimeBase) <> myFitt.PulsePeriod Then MsgBox( _
                        "Warning: The pulse period given in the filename does not correspond with the real pulse period saved in the fitting file!", _
                        MsgBoxStyle.Exclamation)
                End If

            End If

            szX = "DUR"
            If CBool(InStr(szArray(lX), szX)) Then
                szX = szArray(lX).Trim(szX.ToCharArray())
                If IsNumeric(szX) Then
                    If CInt(Val(szX)) <> myFitt.Duration Then MsgBox( _
                       "Warning: The duration given in the filename does not correspond with the real duration saved in the fitting file!", _
                       MsgBoxStyle.Exclamation)
                End If
            End If

        Next

        ' check mindist
        lMax = 0

        For lX = 0 To myFitt.ChannelsCount - 1 'bug fixes, skip disabled electrodes when calculating min. distance
            If myFitt.Channel(lX).blnChUsed = True And myFitt.Channel(lX).lPhDur > lMax Then lMax = myFitt.Channel(lX).lPhDur
            'If   myFitt.Channel(lX).lTHR <> myFitt.Channel(lX).lMCL And myFitt.Channel(lX).lPhDur > lMax Then lMax = myFitt.Channel(lX).lPhDur
            '    If myFitt.Channel(lX).lPhDur > lMax Then lMax = myFitt.Channel(lX).lPhDur
        Next

        'Select Case Me.GenMode
        '    Case STIM.GENMODE.genElectricalRIB, STIM.GENMODE.genElectricalNIC
        '        lVarMinDist = 2 * lMax + 1
        '    Case STIM.GENMODE.genElectricalRIB2, STIM.GENMODE.genVocoder   ' these restrictions count only for legacy datastreams (use a distance of 0 to be safe with pulsar datastreams - TEMPORARY SOLUTION)
        '        Select Case myFitt.ImpType
        '            Case Implant.IMPLANTTYPE.imptC40P_RIB2, Implant.IMPLANTTYPE.imptC40P
        '                lVarMinDist = Math.Max(2 * lMax, CInt(Math.Round(55 / myFitt.TimeBase)))
        '            Case Implant.IMPLANTTYPE.imptPulsar
        '                lVarMinDist = (2 * lMax) + CInt(Math.Round(5 / myFitt.TimeBase))
        '        End Select
        'End Select

        Select Case Me.Genmode
            Case GENMODE.genElectricalRIB Or GENMODE.genElectricalRIB2 Or GENMODE.genElectricalNIC
                lVarMinDist = Math.Max(myFitt.MINDIST_MIN, 2 * lMax)
        End Select

        'If lVarMinDist <> myFitt.MinDist Then
            ' min dist is not correct
            'lX = MsgBox("Min. distance in the fitting file is not the correct minimal distance." & vbCrLf _
            '            & "Fitting file: " & Str(myFitt.MinDist) & _
            '            " tu = " & Str(Math.Round(myFitt.MinDist * myFitt.TimeBase, 1)) & " µs" & vbCrLf _
            '            & "Correct value: " & Str(lVarMinDist) & _
            '            " tu = " & Str(Math.Round((lVarMinDist) * myFitt.TimeBase, 1)) & " µs" & _
            '            vbCrLf & vbCrLf & "Do you want to correct it?", _
            '            MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Reading fitting file")
            '    If lX = MsgBoxResult.Yes Then
            '        mlMinDistCorrect = lVarMinDist ' should be corrected
            '        UpdateForm()
            '        SetChangedTitle()   ' fitting changed now
            '    Else
            '        mlMinDistCorrect = myFitt.MinDist   ' no, use the fitting values
            '        UpdateForm()
            '    End If
            'Else
            '    mlMinDistCorrect = myFitt.MinDist   ' min dist is correct - do not change
            '    UpdateForm()
            'End If

        If lVarMinDist <> myFitt.MINDIST_MIN Then ' The question here is what is the CORRECT minimal distance. I think it's tough to use the clinical standard (myFitt.MinDist)
                                                  ' and would go for the minimum possible distance instead (myFitt.MinDist_Min) (ML, 21/07/2020)
            ' min dist is not correct
            '
            ' Now, there is one type of CRITICAL minimum distance (the one which is lower than MinDist_Min, which could only occur if the fitting file is changed outside ExpSuite) 
            ' and one which might require an info box (the one where it is higher than the possible minimum) <-- change the MsgBox? (ML, 21/07/2020)
            lX = MsgBox("Min. distance in the fitting file is not the correct minimal distance." & vbCrLf _
                        & "Fitting file: " & Str(myFitt.MINDIST_MIN) & _
                        " tu = " & Str(Math.Round(myFitt.MINDIST_MIN * myFitt.TimeBase, 1)) & " µs" & vbCrLf _
                        & "Correct value: " & Str(lVarMinDist) & _
                        " tu = " & Str(Math.Round((lVarMinDist) * myFitt.TimeBase, 1)) & " µs" & _
                        vbCrLf & vbCrLf & "Do you want to correct it?", _
                        MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Reading fitting file")
            If lX = MsgBoxResult.Yes Then
                mlMinDistCorrect = lVarMinDist ' should be corrected
                UpdateForm()
                SetChangedTitle()   ' fitting changed now
            Else
                mlMinDistCorrect = myFitt.MINDIST_MIN   ' no, use the fitting values
                UpdateForm()
            End If
        Else
            mlMinDistCorrect = myFitt.MINDIST_MIN   ' min dist is correct - do not change
            UpdateForm()
        End If
    End Sub
    Public Sub mnuFileSaveAs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileSaveAs.Click
        Dim szFile As String
        Dim szErr As String = ""
        Dim lX, lMax As Integer
        Dim lVarMinDist As Integer ' "platzhalter" variable to set correct minimum distance according to the different generation modes /implant types

        txtPrefix.Focus() 'update values
        If CheckParameters() Then Return

        ' check mindist:
        lMax = 0
        For lX = 0 To myFitt.ChannelsCount - 1
            If lblDynamic(CShort(lX)).Text <> "disabled" And chkboxChUsed(CShort(lX)).Checked And myFitt.Channel(lX).lPhDur > lMax Then lMax = myFitt.Channel(lX).lPhDur
        Next

        ' ML, 23/07/2020: MINDIST_MIN is 33 samples (tu) for all implant types, regardless of RIB or RIB2. These samples might correspond to difference time intervals
        ' due to device-specific sampling rates, but this should not be the constraint here, should it?
        ' 
        ' RIB
        ' - minimal distance = two times phase duration + 1

        ' RIB2 - Legacy data streams:
        ' - C40P_RIB2: minimal distance is two times the phase duration of the previous pulse, with an absolute minimum of 55us
        ' - Pulsar: min. distance = 2* phase duration of the previous pulse plus 5us

        'Select Case Me.GenMode
        '    Case STIM.GENMODE.genElectricalRIB, STIM.GENMODE.genElectricalNIC
        '        lVarMinDist = 2 * lMax + 1
        '    Case STIM.GENMODE.genElectricalRIB2, STIM.GENMODE.genVocoder    ' these restrictions count only for legacy datastreams (use a distance of 0 to be safe with pulsar datastreams - TEMPORARY SOLUTION)
        '        Select Case myFitt.ImpType
        '            Case Implant.IMPLANTTYPE.imptC40P_RIB2
        '                lVarMinDist = Math.Max(2 * lMax, CInt(Math.Round(55 / myFitt.TimeBase)))
        '            Case Implant.IMPLANTTYPE.imptPulsar
        '                lVarMinDist = (2 * lMax) + CInt(Math.Round(5 / myFitt.TimeBase))
        '        End Select
        'End Select

        ' ML, 23/07/2020: Either ensure the minimal technically possible distance or the one required to fit one biphasic pulse (no post-pulse gap)
        Select Case Me.Genmode
            Case GENMODE.genElectricalRIB Or GENMODE.genElectricalRIB2 Or GENMODE.genElectricalNIC
                lVarMinDist = Math.Max(myFitt.MINDIST_MIN, 2 * lMax)
        End Select

        If lVarMinDist <> mlMinDistCorrect Then
            ' min dist is not correct
            lX = MsgBox("Min. distance is not the correct minimal distance." & vbCrLf _
                        & "Your value: " & Str(mlMinDistCorrect) & _
                        " tu =" & Str(Math.Round(mlMinDistCorrect * myFitt.TimeBase, 1)) & " µs" & vbCrLf _
                        & "Correct value: " & Str(lVarMinDist) & _
                        " tu =" & Str(Math.Round((lVarMinDist) * myFitt.TimeBase, 1)) & " µs" & _
                        vbCrLf & vbCrLf & _
                        "Do you want to correct it?", _
                        MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Reading fitting file")
            If lX = MsgBoxResult.Yes Then
                txtMinDist.Text = TStr(lVarMinDist)
                txtMinDist_TextChanged(txtMinDist, New System.EventArgs())
            End If
        End If

        ' check map law
        If Me.GenMode = STIM.GENMODE.genElectricalRIB2 Or Me.GenMode = STIM.GENMODE.genVocoder Then
            If myFitt.MapLaw = "%log; 500" Then
                ' Adapt map law notation of .fitt files to .ampmap format
                txtMapLaw.Text = "Low 500.0"
                'txtMapLaw_TextChanged(txtMapLaw, New System.EventArgs())
            End If

            If myFitt.MapLaw <> "" And myFitt.MapLaw <> "Zero" And myFitt.MapLaw <> "Z" And myFitt.MapLaw <> "ZERO" And myFitt.MapLaw <> "zero" Then
                lX = MsgBox("Given map law is not recommended." & vbCrLf _
                & "Fitting file: " & myFitt.MapLaw & vbCrLf _
                & "Recommended value: " & "Zero" & vbCrLf & vbCrLf & "Do you want to correct it?", _
                MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Saving fitting file")
                If lX = MsgBoxResult.Yes Then
                    txtMapLaw.Text = "Zero"
                    'txtMapLaw_TextChanged(txtMapLaw, New System.EventArgs())
                End If
            End If
        End If

        ' check the file name
        Dim szEar As String = "R"
        If myFitt.Ear = Implant.EARTYPE.LEFT Then szEar = "L"
        Dim szY As String = Replace(myFitt.Prefix, " ", "_") & "_" & _
                                UCase(Mid(LTrim(myFitt.FirstName), 1, 1)) & _
                                Replace(myFitt.LastName, " ", "") & _
                                "_IPI" & TStr(Math.Round(mlPulsePeriod * myFitt.TimeBase, 1)) & _
                                "_DUR" & TStr(myFitt.Duration) & _
                                "_" & szEar
        If Len(mszFileName) = 0 Then
            mszFileName = szY
        ElseIf szY <> IO.Path.GetFileNameWithoutExtension(mszFileName) Then
            If MsgBox("             The current file name is: " & IO.Path.GetFileNameWithoutExtension(mszFileName) & vbCrLf & vbCrLf & _
                      "The correct file name should be: " & szY & vbCrLf & vbCrLf & _
                        "Do you want me to correct it for you?", _
                        MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Save Fitting File") = MsgBoxResult.Yes Then
                mszFileName = szY '& ".ampmap"
            End If
        End If

        Dim dlgSave As New SaveFileDialog
        'dlgSave.FileName = mszFileName
        dlgSave.FileName = IO.Path.GetFileName(mszFileName) ' NameWithoutExtension
        If Len(Me.FileName) > 0 Then dlgSave.InitialDirectory = IO.Path.GetDirectoryName(Me.FileName)
        dlgSave.Title = "Save"
        Select Case Me.GenMode
            Case STIM.GENMODE.genElectricalRIB
                dlgSave.Filter = "RIB Fitting Files (*.fitt)|*.fitt"
            Case STIM.GENMODE.genElectricalRIB2, STIM.GENMODE.genVocoder
                dlgSave.Filter = "RIB2 Fitting Files (*.ampmap)|*.ampmap"
            Case STIM.GENMODE.genElectricalNIC
                dlgSave.Filter = "NIC Fitting Files (*.fitt)|*.fitt"        ' update to NIC fitting file extension!
        End Select
        dlgSave.FilterIndex = 0
        dlgSave.OverwritePrompt = True
        If dlgSave.ShowDialog() <> Windows.Forms.DialogResult.OK Then SetChangedTitle() : Return
        szFile = dlgSave.FileName
        Select Case Me.GenMode
            Case STIM.GENMODE.genElectricalRIB, STIM.GENMODE.genElectricalNIC           ' update to NIC fitting file extension!
                If LCase(Strings.Right(szFile, 5)) <> ".fitt" Then szFile = szFile & ".fitt"
                myFitt.MinDist = mlMinDistCorrect
                ' save parameters in .fitt format
                szErr = myFitt.SaveFileFitt(szFile)
            Case STIM.GENMODE.genElectricalRIB2, STIM.GENMODE.genVocoder
                If LCase(Strings.Right(szFile, 7)) <> ".ampmap" Then szFile = szFile & ".ampmap"
                myFitt.MinDist = mlMinDistCorrect
                ' save parameters in .ampmap format
                szErr = myFitt.SaveFileAmpmap(szFile)
        End Select

        If szErr <> "" Then
            MsgBox("Can't save file:" & vbCrLf & szErr, MsgBoxStyle.Critical, "Save file")
            SetChangedTitle()
            Return
        End If

        mszFileName = szFile
        Me.Text = "Fitt4Fun" & " [ " & mszFileName & " ]"
        mblnFittingChanged = False
        Me.Mode = Fitt4FunMode.FittingUpdated
        SetUIReady()

    End Sub

    Private Sub BackupFittFile(Optional szFile As String = "")

        Select Case Me.GenMode
            Case STIM.GENMODE.genElectricalRIB, STIM.GENMODE.genElectricalNIC           ' update to NIC fitting file extension!
                If szFile = "" Then
                    szFile = STIM.WorkDir & "\~" & gszSettingTitle & ".fitt"
                End If
                'If LCase(Strings.Right(szFile, 5)) <> ".fitt" Then szFile = szFile & ".fitt"
                myFitt.MinDist = mlMinDistCorrect
                ' save parameters in .fitt format
                If Len(Dir(szFile)) > 0 Then 'existing?
                    Try
                        Kill(szFile) 'delete file
                    Catch
                        frmMain.SetStatus("Fitting File Backup could not be created: " & szFile) : Exit Sub
                    End Try
                    If Len(Dir(szFile)) > 0 Then frmMain.SetStatus("Fitting File Backup could not be created: " & szFile) : Exit Sub
                End If
                myFitt.SaveFileFitt(szFile)

            Case STIM.GENMODE.genElectricalRIB2, STIM.GENMODE.genVocoder
                'If LCase(Strings.Right(szFile, 7)) <> ".ampmap" Then szFile = szFile & ".ampmap"
                If szFile = "" Then
                    szFile = STIM.WorkDir & "\~" & gszSettingTitle & ".ampmap"
                End If
                myFitt.MinDist = mlMinDistCorrect
                ' save parameters in .ampmap format
                If Len(Dir(szFile)) > 0 Then 'existing?
                    Try
                        Kill(szFile) 'delete file
                    Catch
                        frmMain.SetStatus("Fitting File Backup could not be created: " & szFile) : Exit Sub
                    End Try
                    If Len(Dir(szFile)) > 0 Then frmMain.SetStatus("Fitting File Backup could not be created: " & szFile) : Exit Sub
                End If
                myFitt.SaveFileAmpmap(szFile)

        End Select

    End Sub

    Public Sub mnuShortcuts_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuShortcuts.Click
        MsgBox("Shortcuts used in menus:" & vbCrLf & "F5" & vbTab & "Start/stop stimulation mode" & vbCrLf & "F9" & vbTab & "Show/hide the stimulation log list" & vbCrLf & "CTRL+N" & vbTab & "New fitting file (C40C)" & vbCrLf & "CTRL+O" & vbTab & "Load a fitting file" & vbCrLf & "CTRL+S" & vbTab & "Save fitting file (ask for the name before saving)" & vbCrLf & "CTRL+W" & vbTab & "Close current fitting file (without saving)" & vbCrLf & "M" & vbTab & "(Mcl) Set focus to the MCL slider" & vbCrLf & "T" & vbTab & "(Thr) Set focus to the THR slider" & vbCrLf & "N" & vbTab & "(Next) Go to the next active electrode" & vbCrLf & "P" & vbTab & "(Previous) Go to the previous active electrode" & vbCrLf & "S" & vbTab & "(Set to memory) Set the current value of MCL to memory" & vbCrLf & "R" & vbTab & "(Recall from memory) Recall the MCL value from memory" & vbCrLf & vbCrLf & vbCrLf & "Shortcuts used in stimulation mode:" & vbCrLf & "SPACE," & vbCrLf & "RETURN" & vbTab & "Stimulate the active electrode (MCL or THR)" & vbCrLf & "ESC" & vbTab & "(Escape) Cancel the stimulation", , "Shortcuts - Fitt4Fun")

    End Sub

    Public Sub mnuShowStimulus_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuShowStimulus.Click
        mnuShowStimulus.Checked = Not mnuShowStimulus.Checked
        mblnShowStimulus = mnuShowStimulus.Checked
    End Sub

    Public Sub mnuStimulation_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuStimulation.Click

        If mnuStimulation.Checked Then
            ' switch stimulation off
            StimulationOff()
        Else
            ' switch stimulation on
            StimulationOn()
        End If

    End Sub

    Private Sub sldMCL_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _sldMCL_0.Enter
        DirectCast(sender, TrackBar).BackColor = Drawing.SystemColors.ControlLightLight
    End Sub

    Private Sub sldMCL_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _sldMCL_0.ValueChanged
        If mblnInitControls Then Return
        Dim Index As Short = CShort(sldMCL.IndexOf(DirectCast(eventSender, TrackBar)))
        If Not sldMCL(Index).Focused AndAlso Not chkboxChUsed(Index).Focused Then sldMCL(Index).Value = myFitt.Channel(Index).lMCL : Return

        If sldMCL(Index).Value <= sldTHR(Index).Value Then sldMCL(Index).Value = sldTHR(Index).Value
        myFitt.Channel(Index).lMCL = sldMCL(Index).Value
        lblMCL(Index).Text = TStr(myFitt.Channel(Index).lMCL) & " cu" & vbCrLf & _
                             myFitt.CalcCurrentAsString(myFitt.Channel(Index).lMCL, myFitt.Channel(Index).lRange) & " µA"
        SetMaxEnergy((Index))
        SetDynamic(Index)
        'If sldTHR(Index).Value >= sldMCL(Index).Value Then
        '    chkboxChUsed(Index).Checked = False
        'myFitt.Channel(Index).blnChUsed = chkboxChUsed(Index).Checked
        'Else
        'chkboxChUsed(Index).Checked = True
        'myFitt.Channel(Index).blnChUsed = chkboxChUsed(Index).Checked
        'End If
        SetChangedTitle()
    End Sub

    Private Sub sldMCL_KeyDownEvent(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles _sldMCL_0.KeyDown
        If mblnInitControls Then Return
        Dim Index As Short = CShort(sldMCL.IndexOf(DirectCast(eventSender, TrackBar)))
        Select Case eventArgs.KeyCode
            Case System.Windows.Forms.Keys.Right
                sldMCL_KeyPressEvent(sldMCL.Item(Index), New KeyPressEventArgs("n"c))
            Case System.Windows.Forms.Keys.Left
                sldMCL_KeyPressEvent(sldMCL.Item(Index), New KeyPressEventArgs("p"c))
            Case System.Windows.Forms.Keys.R
                If cmdMemRMCL(Index).Enabled Then cmdMemRMCL_Click(cmdMemRMCL.Item(Index), New System.EventArgs())
            Case System.Windows.Forms.Keys.S
                cmdMemSMCL_Click(cmdMemSMCL.Item(Index), New System.EventArgs())
        End Select
    End Sub

    Private Sub sldMCL_KeyPressEvent(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles _sldMCL_0.KeyPress
        If mblnInitControls Then Return
        Dim Index As Short = CShort(sldMCL.IndexOf(DirectCast(eventSender, TrackBar)))
        Select Case eventArgs.KeyChar
            Case ChrW(13), " "c
                If chkboxChUsed(Index).Checked Then
                    ' stimulate
                    If cmdMCL(Index).Enabled Then
                        cmdMCL_Click(cmdMCL.Item(Index), New System.EventArgs())
                    End If
                End If
            Case "t"c
                ' change to THR slider
                sldTHR(Index).Focus()
            Case "n"c
                If Index + 1 < myFitt.ChannelsCount Then
                    sldTHR(Index + 1).Focus()
                Else
                    sldTHR(0).Focus()
                End If
            Case "p"c
                sldTHR(Index).Focus()
        End Select
    End Sub

    Private Sub sldMCL_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _sldMCL_0.Leave
        If mblnInitControls Then Return
        Dim Index As Short = CShort(sldMCL.IndexOf(DirectCast(eventSender, TrackBar)))
        mlElectrodeIndex = mlElectrodeIndex Or &H10000
        DirectCast(eventSender, TrackBar).BackColor = Drawing.SystemColors.Control
    End Sub

    Private Sub sldMCL_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _sldMCL_0.Scroll
        If mblnInitControls Then Return
        Dim Index As Short = CShort(sldMCL.IndexOf(DirectCast(eventSender, TrackBar)))
        sldMCL_Change(sldMCL.Item(Index), New System.EventArgs())
    End Sub

    Private Sub sldTHR_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _sldTHR_0.Enter
        DirectCast(sender, TrackBar).BackColor = Drawing.SystemColors.ControlLightLight
    End Sub

    Private Sub sldTHR_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _sldTHR_0.ValueChanged
        If mblnInitControls Then Return
        Dim Index As Short = CShort(sldTHR.IndexOf(DirectCast(eventSender, TrackBar)))
        If Not sldTHR(Index).Focused Then sldTHR(Index).Value = myFitt.Channel(Index).lTHR : Return

        If sldMCL(Index).Value <= sldTHR(Index).Value Then
            myFitt.Channel(Index).lMCL = sldTHR(Index).Value
            sldMCL(Index).Value = sldTHR(Index).Value
            lblMCL(Index).Text = TStr(myFitt.Channel(Index).lMCL) & " cu" & vbCrLf & _
                                 myFitt.CalcCurrentAsString(myFitt.Channel(Index).lMCL, myFitt.Channel(Index).lRange) & " µA"
        End If
        myFitt.Channel(Index).lTHR = sldTHR(Index).Value
        lblTHR(Index).Text = TStr(myFitt.Channel(Index).lTHR) & " cu" & vbCrLf & _
                             myFitt.CalcCurrentAsString(myFitt.Channel(Index).lTHR, myFitt.Channel(Index).lRange) & " µA"
        SetDynamic(Index)
        SetMaxEnergy(Index)
        'If sldTHR(Index).Value >= sldMCL(Index).Value Then
        'chkboxChUsed(Index).Checked = False
        'myFitt.Channel(Index).blnChUsed = chkboxChUsed(Index).Checked
        'Else
        'chkboxChUsed(Index).Checked = True
        'myFitt.Channel(Index).blnChUsed = chkboxChUsed(Index).Checked
        'End If
        SetChangedTitle()
    End Sub

    Private Sub sldTHR_KeyDownEvent(ByVal eventSender As System.Object, ByVal eventArgs As KeyEventArgs) Handles _sldTHR_0.KeyDown
        If mblnInitControls Then Return
        Dim Index As Short = CShort(sldTHR.IndexOf(DirectCast(eventSender, TrackBar)))
        Select Case eventArgs.KeyCode
            Case System.Windows.Forms.Keys.Right
                sldTHR_KeyPressEvent(sldTHR.Item(Index), New KeyPressEventArgs("n"c))
            Case System.Windows.Forms.Keys.Left
                sldTHR_KeyPressEvent(sldTHR.Item(Index), New KeyPressEventArgs("p"c))
        End Select
    End Sub

    Private Sub sldTHR_KeyPressEvent(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles _sldTHR_0.KeyPress
        If mblnInitControls Then Return
        Dim Index As Short = CShort(sldTHR.IndexOf(DirectCast(eventSender, TrackBar)))
        Select Case eventArgs.KeyChar
            Case ChrW(13), " "c
                If chkboxChUsed(Index).Checked Then
                    ' stimulate
                    If cmdTHR(Index).Enabled Then
                        cmdTHR_Click(cmdTHR.Item(Index), New System.EventArgs())
                    End If
                End If
            Case "m"c
                sldMCL(Index).Focus()
            Case "n"c
                sldMCL(Index).Focus()
            Case "p"c
                If Index > 0 Then
                    sldMCL(Index - 1).Focus()
                Else
                    sldMCL(myFitt.ChannelsCount - 1).Focus()
                End If
        End Select
    End Sub

    Private Sub sldTHR_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _sldTHR_0.Leave
        If mblnInitControls Then Return
        Dim Index As Short = CShort(sldTHR.IndexOf(DirectCast(eventSender, TrackBar)))
        mlElectrodeIndex = mlElectrodeIndex And &HFFFF
        DirectCast(eventSender, TrackBar).BackColor = Drawing.SystemColors.Control
    End Sub

    Private Sub sldTHR_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _sldTHR_0.Scroll
        If mblnInitControls Then Return
        Dim Index As Short = CShort(sldTHR.IndexOf(DirectCast(eventSender, TrackBar)))
        sldTHR_Change(sldTHR.Item(Index), New System.EventArgs())
    End Sub

    Private Sub txtChannelOrder_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtChannelOrder.TextChanged
        If mblnInitControls Then Return
        myFitt.ChannelOrder = txtChannelOrder.Text
        SetChangedTitle()
    End Sub

    Private Sub txtFName_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFName.TextChanged
        If mblnInitControls Then Return
        myFitt.FirstName = txtFName.Text
    End Sub

    Private Sub txtLName_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtLName.TextChanged
        If mblnInitControls Then Return
        myFitt.LastName = txtLName.Text
    End Sub

    Private Sub txtMapLaw_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMapLaw.TextChanged
        If mblnInitControls Then Return
        myFitt.MapLaw = txtMapLaw.Text
        SetChangedTitle()
    End Sub

    Private Sub txtMinDist_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMinDist.TextChanged
        If mblnInitControls Then Return
        mlMinDistCorrect = CInt(Val(txtMinDist.Text))
        lblMinDist.Text = "tu = " & Str(Math.Round(mlMinDistCorrect * myFitt.TimeBase, 1)) & " µs"
        SetChangedTitle()
    End Sub

    Private Sub txtMinDist_MaskInputRejected(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtMinDist.MaskInputRejected
        MsgBox("Numeric values only, please.", MsgBoxStyle.Critical, "Min distance")
    End Sub

    Private Sub txtPhDur_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtPhDur.Validating
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim Index As Short = CShort(txtPhDur.GetIndex(DirectCast(eventSender, TextBox)))
        Dim lX As Integer
        If IsNumeric(txtPhDur(Index).Text) Then
            lX = CInt(Math.Round(Val(txtPhDur(Index).Text) / myFitt.TimeBase))
            If lX < 16 Then MsgBox("Phase duration smaller than 16 may not work...", MsgBoxStyle.Information, "Warning")
            If lX > 255 Then MsgBox("Phase duration greater than 255 may not work...", MsgBoxStyle.Information, "Warning")
            txtPhDurTU(Index).Text = CStr(lX)
            myFitt.Channel(Index).lPhDur = lX
            SetMaxEnergy((Index))
            SetChangedTitle()
        Else
            MsgBox("Numeric values only!")
            Cancel = True
        End If
        eventArgs.Cancel = Cancel
    End Sub

    Private Sub txtPhDurTU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPhDurTU.TextChanged
        If mblnInitControls Then Return
        Dim Index As Short = CShort(txtPhDurTU.GetIndex(DirectCast(eventSender, MaskedTextBox)))
        lblPhDur(Index).Text = "tu" & vbCrLf & vbCrLf & " µs"
        txtPhDur(Index).Text = LTrim(Str(Math.Round(Val(txtPhDurTU(Index).Text) * myFitt.TimeBase, 1)))
    End Sub

    Private Sub txtPhDurTU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPhDurTU.Leave
        If mblnInitControls Then Return
        Dim Index As Short = CShort(txtPhDurTU.GetIndex(DirectCast(eventSender, MaskedTextBox)))
        Dim lX As Integer
        lX = CInt(Val(txtPhDurTU(Index).Text))
        If lX < myFitt.PHDUR_MIN Then MsgBox("Phase duration smaller than " & TStr(myFitt.PHDUR_MIN) & " does not work...", MsgBoxStyle.Information, "Warning")
        If lX > myFitt.PHDUR_MAX Then MsgBox("Phase duration greater than " & TStr(myFitt.PHDUR_MAX) & " does not work...", MsgBoxStyle.Information, "Warning")
        myFitt.Channel(Index).lPhDur = lX
        txtPhDur(Index).Text = LTrim(Str(Math.Round(lX * myFitt.TimeBase, 1)))
        SetMaxEnergy((Index))
        SetChangedTitle()
    End Sub

    Private Sub txtPhDurTU_MaskInputRejected(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtPhDurTU.MaskInputRejected
        If mblnInitControls Then Return
        Dim Index As Short = CShort(txtPhDurTU.GetIndex(DirectCast(eventSender, MaskedTextBox)))
        MsgBox("Numeric values only, please", MsgBoxStyle.Critical, "Phase duration")
    End Sub

    Private Sub txtPulseRate_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtPulseRate.Validating
        If mblnInitControls Then Return
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim sX As Single
        If IsNumeric((txtPulseRate.Text)) Then
            sX = CInt(Val((txtPulseRate.Text)))
            If sX = 0 Then
                MsgBox("The value must not be zero.")
                Cancel = True
                GoTo EventExitSub
            End If
            mlPulsePeriod = CInt(Math.Round(1000000 / sX / myFitt.TimeBase))
            myFitt.PulsePeriod = mlPulsePeriod
            mblnInitControls = True
            txtPulseRate.Text = TStr(Math.Round(1000000 / (mlPulsePeriod * myFitt.TimeBase), 1))
            txtPulsePeriod.Text = TStr(Math.Round(mlPulsePeriod * myFitt.TimeBase, 1))
            mblnInitControls = False
            lblPPer.Text = "µs = " & TStr(mlPulsePeriod) & " tu"
            SetChangedTitle()
        Else
            MsgBox("Numeric values only, please.")
            Cancel = True
        End If
EventExitSub:
        eventArgs.Cancel = Cancel
    End Sub

    Private Sub mnuFileNewC40C_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewC40C.Click
        If mblnFittingChanged Then
            If MsgBox("Current fitting was changed. If you create a new fitting, all changes will be discarded." & _
                        vbCrLf & "Continue anyway?", _
                        MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Exclamation, _
                        "New fitting") = MsgBoxResult.No Then Exit Sub
        End If
        ClearParameters(Implant.IMPLANTTYPE.imptC40C)
        BuildForm()
        UpdateForm()
        SetUIReady()
    End Sub

    Private Sub mnuFileNewC40P_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewC40P.Click
        If mblnFittingChanged Then
            If MsgBox("Current fitting was changed. If you create a new fitting, all changes will be discarded." & _
                        vbCrLf & "Continue anyway?", _
                        MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Exclamation, _
                        "New fitting") = MsgBoxResult.No Then Exit Sub
        End If
        If Me.GenMode = STIM.GENMODE.genElectricalRIB Then
            ClearParameters(Implant.IMPLANTTYPE.imptC40P)
        ElseIf Me.GenMode = STIM.GENMODE.genElectricalRIB2 Or Me.GenMode = STIM.GENMODE.genVocoder Then
            ClearParameters(Implant.IMPLANTTYPE.imptC40P_RIB2)
        End If
        BuildForm()
        For lX As Integer = 0 To 11
            cmbRange(CShort(lX)).SelectedIndex = 1
            myFitt.Channel(lX).lTHR = 0 'reduce THR
            myFitt.Channel(lX).lMCL = 30 'reduce MCL
        Next
        UpdateForm()
        SetUIReady()
    End Sub

    Private Sub mnuFileNewPulsar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewPulsar.Click
        If mblnFittingChanged Then
            If MsgBox("Current fitting was changed. If you create a new fitting, all changes will be discarded." & _
                        vbCrLf & "Continue anyway?", _
                        MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Exclamation, _
                        "New fitting") = MsgBoxResult.No Then Exit Sub
        End If
        ClearParameters(Implant.IMPLANTTYPE.imptPulsar)
        BuildForm()
        For lX As Integer = 0 To 11
            cmbRange(CShort(lX)).SelectedIndex = 1
            myFitt.Channel(lX).lTHR = 0 'reduce THR
            myFitt.Channel(lX).lMCL = 30 'reduce MCL
        Next
        UpdateForm()
        SetUIReady()
    End Sub

    Private Sub mnuFileNewCIC3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewCIC3.Click
        If mblnFittingChanged Then
            If MsgBox("Current fitting was changed. If you create a new fitting, all changes will be discarded." & _
                        vbCrLf & "Continue anyway?", _
                        MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Exclamation, _
                        "New fitting") = MsgBoxResult.No Then Exit Sub
        End If
        ClearParameters(Implant.IMPLANTTYPE.imptCIC3)
        BuildForm()
        UpdateForm()
        SetUIReady()
    End Sub

    Private Sub tbToolBar_Open_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbToolBar_Open.Click
        mnuFileOpen_Click(mnuFileOpen, New System.EventArgs())
    End Sub

    Private Sub tbToolBar_SaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbToolBar_SaveAs.Click
        mnuFileSaveAs_Click(mnuFileSaveAs, New System.EventArgs())
    End Sub

    Private Sub tbToolBar_Connect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbToolBar_Connect.Click
        If tbToolBar_Connect.CheckState = CheckState.Checked Then
            StimulationOn()
            mbPlaying = False
        Else
            StimulationOff()
        End If
    End Sub

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
        If myFitt.Duration <> CInt(Math.Round(Val(txtDuration.Text))) Then
            myFitt.Duration = CInt(Math.Round(Val(txtDuration.Text)))
            SetChangedTitle()
        End If
        e.Cancel = False
    End Sub

    Private Sub txtPulsePeriod_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPulsePeriod.Validating
        If mblnInitControls Then Return
        If Not IsNumeric(txtPulsePeriod.Text) Then
            MsgBox("Must be numeric positive.")
            e.Cancel = True
            Return
        End If
        Dim lX As Integer = CInt(Math.Round(Val(txtPulsePeriod.Text)))
        If lX < 1 Then
            MsgBox("Must be a positive number.")
            e.Cancel = True
            Return
        End If
        mlPulsePeriod = CInt(Math.Round(Val(txtPulsePeriod.Text) / myFitt.TimeBase))
        myFitt.PulsePeriod = mlPulsePeriod
        mblnInitControls = True
        txtPulseRate.Text = TStr(Math.Round(1000000 / (mlPulsePeriod * myFitt.TimeBase), 1))
        txtPulsePeriod.Text = TStr(Math.Round(mlPulsePeriod * myFitt.TimeBase, 1))
        mblnInitControls = False
        lblPPer.Text = "µs = " & TStr(mlPulsePeriod) & " tu"
        SetChangedTitle()
        e.Cancel = False
    End Sub

    Private Sub mnuAmpReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAmpReset.Click
        For lX As Short = 0 To CShort(lblMem.Count - 1)
            lblMem(lX).Text = "---"
            Me.cmdMemRMCL(lX).Enabled = False
        Next
        mnuAmpExport.Enabled = False
    End Sub

    Private Sub mnuAmpReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAmpReload.Click
        If IsNothing(Amplitude) Then Return
        For lX As Short = 0 To CShort(Amplitude.Length - 1)
            If lX < lblMem.Count Then
                lblMem(lX).Text = TStr(Math.Round(Amplitude(lX)))
                Me.cmdMemRMCL(lX).Enabled = True
            End If
        Next
        mnuAmpExport.Enabled = True
    End Sub

    Private Sub mnuAmpExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAmpExport.Click
        Dim lX, lNr As Integer
        Dim szArr(,) As String
        Dim szX, szFile As String

        ' count enabled memories
        lNr = 0
        For lX = 0 To myFitt.ChannelsCount - 1
            If lblMem(CShort(lX)).Text <> "---" Then lNr = lNr + 1
        Next
        If lNr = 0 Then MsgBox("No amplitudes in memory.") : Return

        szX = InputBox("Input the name of the table to export:", "Export Amplitudes from Memory", "Standard")
        If Len(szX) = 0 Then Return

        ReDim szArr(lNr, 3)
        szArr(0, 0) = "Table"
        szArr(0, 1) = "Electrode"
        szArr(0, 2) = "Channel"
        szArr(0, 3) = "Amplitude"
        lNr = 1
        For lX = 0 To myFitt.ChannelsCount - 1
            If lblMem(CShort(lX)).Text <> "---" Then
                szArr(lNr, 0) = szX
                szArr(lNr, 1) = CStr(lX + 1)
                szArr(lNr, 2) = CStr(myFitt.Ear)
                szArr(lNr, 3) = lblMem(CShort(lX)).Text
                lNr = lNr + 1
            End If
        Next

        Dim dlgSave As New SaveFileDialog
        dlgSave.Title = "Export Amplitudes from Memory"
        'dlgSave.FileName = IO.Path.GetFileName(mszFileName) ' NameWithoutExtension
        lX = InStr(1, mszFileName, ".fitt")
        Dim lZ As Integer = InStr(1, mszFileName, ".ampmap")
        If lX > 0 Then
            dlgSave.FileName = IO.Path.GetFileName(Mid(mszFileName, 1, lX - 1) & ".signal")
        ElseIf lZ > 0 Then
            dlgSave.FileName = IO.Path.GetFileName(Mid(mszFileName, 1, lZ - 1) & ".signal")
        Else
            dlgSave.FileName = IO.Path.GetFileName(mszFileName & ".signal")
        End If

        If Len(Me.FileName) > 0 Then dlgSave.InitialDirectory = IO.Path.GetDirectoryName(Me.FileName)
        dlgSave.CheckPathExists = True
        dlgSave.Filter = "Signal Files (*.signal)|*.signal|All Files (*.*)|*.*"
        dlgSave.FilterIndex = 0
        If dlgSave.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
        szFile = dlgSave.FileName
        Dim csvX As New CSVParser
        szX = csvX.WriteArr(szFile, szArr)
        If Len(szX) > 0 Then
            MsgBox("Error creating file " & szFile & vbCrLf & szX)
        End If
    End Sub

    Private Sub lblMem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMem.DoubleClick
        Dim Index As Short = lblMem.GetIndex(DirectCast(sender, Label))
        lblMem(Index).Text = "---"
        cmdMemRMCL(Index).Enabled = False
    End Sub

    Private Sub txtPrefix_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrefix.TextChanged
        If mblnInitControls Then Return
        myFitt.Prefix = txtPrefix.Text
    End Sub

    Private Sub txtPulsePeriod_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPulsePeriod.TextChanged

    End Sub

    Private Sub tbToolStripMenu_NewC40C_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbToolStripMenu_NewC40C.Click
        Me.mnuFileNewC40C_Click(mnuFileNewC40C, New System.EventArgs())
    End Sub

    Private Sub tbToolStripMenu_NewC40P_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbToolStripMenu_NewC40P.Click
        Me.mnuFileNewC40P_Click(mnuFileNewC40P, New System.EventArgs())
    End Sub

    Private Sub tbToolStripMenu_NewPulsar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbToolStripMenu_NewPulsar.Click
        Me.mnuFileNewPulsar_Click(mnuFileNewPulsar, New System.EventArgs())
    End Sub

    Private Sub tbToolStripMenu_NewCIC3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbToolStripMenu_NewCIC3.Click
        Me.mnuFileNewCIC3_Click(mnuFileNewCIC3, New System.EventArgs())
    End Sub

    Private Sub cbxDataStream_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxDataStream.SelectedIndexChanged
        If mblnInitControls Then Return
        If cbxDataStream.SelectedIndex = 0 Then
            cbxGapDur.Items.Clear()
            Select Case myFitt.ImpType
                Case Implant.IMPLANTTYPE.imptC40P_RIB2
                    cbxGapDur.Items.Add("0")
                    cbxGapDur.SelectedIndex = 0
                Case Implant.IMPLANTTYPE.imptPulsar
                    cbxGapDur.Items.Add("2.1")
                    cbxGapDur.SelectedIndex = 0
            End Select
        ElseIf cbxDataStream.SelectedIndex = 1 Then
            cbxGapDur.Items.Clear()
            cbxGapDur.Items.AddRange(New Object() {"2.1", "10", "20", "30"})
            cbxGapDur.SelectedIndex = 0
        End If
        myFitt.DataStreamType = cbxDataStream.SelectedItem.ToString
        myFitt.GapDuration = CDbl(Val(cbxGapDur.Text))
        SetChangedTitle()
    End Sub
    Private Sub chkboxChUsed_CheckedChanged(ByVal eventSender As System.Object, ByVal e As System.EventArgs) Handles chkboxChUsed.CheckedChanged
        If mblnInitControls Then Return
        Dim Index As Short = chkboxChUsed.GetIndex(DirectCast(eventSender, CheckBox))
        myFitt.Channel(Index).blnChUsed = chkboxChUsed(Index).Checked

        If Not chkboxChUsed(Index).Checked Then
            sldMCL(Index).Value = sldTHR(Index).Value
            myFitt.Channel(Index).lMCL = sldMCL(Index).Value
            lblMCL(Index).Text = TStr(myFitt.Channel(Index).lMCL) & " cu" & vbCrLf & _
                                 myFitt.CalcCurrentAsString(myFitt.Channel(Index).lMCL, myFitt.Channel(Index).lRange) & " µA"
            SetMaxEnergy((Index))
            SetDynamic(Index)
        End If

        'sldMCL(Index).Enabled = chkboxChUsed(Index).Checked
        'sldTHR(Index).Enabled = chkboxChUsed(Index).Checked
        cmdMCL(Index).Enabled = chkboxChUsed(Index).Checked And mblnStimulation
        cmdTHR(Index).Enabled = chkboxChUsed(Index).Checked And mblnStimulation
        SetChangedTitle()
    End Sub

    Private Sub cbxGapDur_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxGapDur.SelectedIndexChanged
        If mblnInitControls Then Return
        myFitt.GapDuration = CDbl(Val(cbxGapDur.Text))
        SetChangedTitle()
    End Sub

    Private Sub ImportFromFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ImportFromFileToolStripMenuItem.Click
        Dim lX As Integer
        Dim szErr As String
        Dim szArr(0, 0) As String
        Dim blnErr As Boolean
        Dim csvX As New CSVParser
        Dim bEarChecked As Boolean = False

        ' read signal file as csv
        Dim dlgOpen As New OpenFileDialog

        If Len(mszAmpFileName) = 0 Then mszAmpFileName = mszFileName

        If Len(mszAmpFileName) = 0 Then
            dlgOpen.InitialDirectory = gszCurrentDir
        Else
            dlgOpen.InitialDirectory = IO.Path.GetDirectoryName(mszAmpFileName)
        End If

        dlgOpen.Title = "Import an ampmap file with amplitude values..."
        dlgOpen.FileName = ""
        dlgOpen.CheckFileExists = True
        dlgOpen.CheckPathExists = True
        'dlgOpen.Filter = "RIB Fitting Files (*.fitt)|*.fitt|RIB2 Fitting Files (*.ampmap)|*.ampmap|All Files (*.*)|*.*"
        dlgOpen.Filter = "Ampmap Files (*.ampmap)|*.ampmap|Signal Files (*.signal)|*.signal|All Files (*.*)|*.*"
        dlgOpen.FilterIndex = 1
        If dlgOpen.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
        mszAmpFileName = dlgOpen.FileName
        szErr = csvX.ReadArr(dlgOpen.FileName, szArr)
        If Len(szErr) <> 0 Then MsgBox("Error reading signal file:" & vbCrLf & szErr) : Return
        If IsNothing(szArr) Then MsgBox("File is empty.") : Return

        ' read rows
        blnErr = False
        Dim ear As Integer = -1
        Debug.Print(" +++ IMPORT +++ ")

        If IO.Path.GetExtension(dlgOpen.FileName) = ".signal" Then 'signal file
            For lX = 0 To UBound(szArr)
                If UBound(szArr, 2) >= 3 AndAlso Val(szArr(lX, 1)) > 0 Then 'electrode number
                    If szArr(lX, 2) = "0" Or szArr(lX, 2) = "1" Then
                        ear = CInt(Val(szArr(lX, 2)))

                        If myFitt.Ear <> ear Then
                            szErr = "Ear is not matching!" & vbCrLf & _
                                 "  Current fitting file: "
                            'current fitting
                            If myFitt.Ear = 0 Then
                                szErr = szErr & "Left"
                            ElseIf myFitt.Ear = 1 Then
                                szErr = szErr & "Right"
                            Else
                                szErr = szErr & "Unspecified"
                            End If

                            'amplitudes
                            szErr = szErr & vbCrLf & "  Amplitude fitting file: "
                            If ear = 0 Then
                                szErr = szErr & "Left"
                            ElseIf ear = 1 Then
                                szErr = szErr & "Right"
                            Else
                                szErr = szErr & "Unspecified"
                            End If
                            blnErr = True

                            GoTo SubError
                        End If

                        Dim El As Integer = CInt(Val(szArr(lX, 1)))

                        Dim CL As Integer = CInt(Val(szArr(lX, 3)))
                        Debug.Print("Ear" & ear & "-EL" & El & "-CL" & CL & "-")

                        If ear = 0 Then
                            lblMem(CShort(El - 1)).Text = TStr(CL)
                            Me.cmdMemRMCL(CShort(El - 1)).Enabled = True
                            szErr = szErr & "Left, #" & TStr(El) & ": Amplitude =" & TStr(CL) & vbCrLf
                            mnuAmpExport.Enabled = True

                        ElseIf ear = 1 Then
                            lblMem(CShort(El - 1)).Text = TStr(CL)
                            Me.cmdMemRMCL(CShort(El - 1)).Enabled = True
                            szErr = szErr & "Right, #" & TStr(El) & ": Amplitude =" & TStr(CL) & vbCrLf
                            mnuAmpExport.Enabled = True
                        End If


                    End If
                End If
            Next
        Else 'ampmap (or any other) file

            For lX = 0 To UBound(szArr)

                If Strings.Left(szArr(lX, 0), Len("# Implanted ear : LEFT")) = "# Implanted ear : LEFT" Then
                    ear = 0
                ElseIf Strings.Left(szArr(lX, 0), Len("# Implanted ear : RIGHT")) = "# Implanted ear : RIGHT" Then
                    ear = 1
                End If

                If Strings.Left(szArr(lX, 0), Len("Electrode ")) = "Electrode " Then

                    If bEarChecked = False Then
                        If myFitt.Ear <> ear Then
                            szErr = "Ear is not matching!" & vbCrLf & _
                                 "  Current fitting file: "
                            'current fitting
                            If myFitt.Ear = 0 Then
                                szErr = szErr & "Left"
                            ElseIf myFitt.Ear = 1 Then
                                szErr = szErr & "Right"
                            Else
                                szErr = szErr & "Unspecified"
                            End If

                            'amplitudes
                            szErr = szErr & vbCrLf & "  Amplitude fitting file: "
                            If ear = 0 Then
                                szErr = szErr & "Left"
                            ElseIf ear = 1 Then
                                szErr = szErr & "Right"
                            Else
                                szErr = szErr & "Unspecified"
                            End If
                            blnErr = True

                            GoTo SubError
                        End If
                        bEarChecked = True
                    End If

                    If InStr(szArr(lX, 0), " # CL ") > 0 Then

                        Dim El As Integer = CInt(Val(Replace(Strings.Mid(szArr(lX, 0), Len("Electrode ") + 1, 2), " ", "")))

                        Dim CL As Integer = CInt(Val(Strings.Right(szArr(lX, 0), Len(szArr(lX, 0)) - InStr(szArr(lX, 0), " # CL ") - Len(" # CL ") + 1)))
                        Debug.Print("Ear" & ear & "-EL" & El & "-CL" & CL & "-")

                        If ear = 0 Then

                            lblMem(CShort(El - 1)).Text = TStr(CL)
                            Me.cmdMemRMCL(CShort(El - 1)).Enabled = True
                            szErr = szErr & "Left, #" & TStr(El) & ": Amplitude =" & TStr(CL) & vbCrLf
                            mnuAmpExport.Enabled = True

                        ElseIf ear = 1 Then

                            lblMem(CShort(El - 1)).Text = TStr(CL)
                            Me.cmdMemRMCL(CShort(El - 1)).Enabled = True
                            szErr = szErr & "Right, #" & TStr(El) & ": Amplitude =" & TStr(CL) & vbCrLf
                            mnuAmpExport.Enabled = True
                        End If
                    End If

                End If
            Next  ' for each row
        End If

SubError:
        If blnErr Then
            MsgBox(szErr, MsgBoxStyle.Critical, "Error importing amplitudes")
        Else
            If szErr = "" Then szErr = "No amplitudes imported!"
            MsgBox(szErr, MsgBoxStyle.Information, "Status report")
        End If

    End Sub

End Class