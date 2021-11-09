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
Imports System.Runtime.InteropServices
Imports System.Text

Module RIB2

#Region "Properties"
    ' internal data
    Private mTimer As System.Threading.Timer
    Private mblnTimeOut As Boolean
    Private mblnConnected As Boolean

    ' data for properties
    Private mszRIB2Device As String
    Private mlImpLeft As Integer
    Private mlImpRight As Integer
    Private mblnSimulation As Boolean
    Private mszFittLeft As String
    Private mszFittRight As String
    Private mszRoot As String

    ' stm file names currently loaded
    Private mszStmFileLeft As String
    Private mszStmFileRight As String

    Public Property RIB2Device() As String
        Get
            Return mszRIB2Device
        End Get
        Set(ByVal Value As String)
            mszRIB2Device = Value
        End Set
    End Property

    Public Property ImpLeft() As Integer
        Get
            Return mlImpLeft
        End Get
        Set(ByVal Value As Integer)
            mlImpLeft = Value
        End Set
    End Property

    Public Property ImpRight() As Integer
        Get
            Return mlImpRight
        End Get
        Set(ByVal Value As Integer)
            mlImpRight = Value
        End Set
    End Property

    Public Property Simulation() As Boolean
        Get
            Return mblnSimulation
        End Get
        Set(ByVal Value As Boolean)
            mblnSimulation = Value
        End Set
    End Property

    Public Property FittLeft() As String
        Get
            Return mszFittLeft
        End Get
        Set(ByVal Value As String)
            mszFittLeft = Value
        End Set
    End Property

    Public Property FittRight() As String
        Get
            Return mszFittRight
        End Get
        Set(ByVal Value As String)
            mszFittRight = Value
        End Set
    End Property

    Public Property RootDirectory() As String
        Get
            Return mszRoot
        End Get
        Set(ByVal Value As String)
            mszRoot = Value
        End Set
    End Property

#End Region

#Region "P/Invoke function wrappers to use functions of RIB2.dll"


#Region "Setup functions"

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srGetVersion@8")> _
    Sub GetVersion(ByRef verMajorPtr As UInt32, ByRef verMinorPtr As UInt32)
    End Sub

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srGetVersionX@16")> _
    Sub GetVersionX(ByRef verMajorPtr As UInt32, ByRef verMinorPtr As UInt32, _
                    ByRef verLowerPtr As UInt32, ByRef verLowestPtr As UInt32)
    End Sub

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srSetDeviceName@4")> _
    Function SetDeviceName(ByVal device As String) As Integer
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srGetDeviceProperties@8")> _
    Function GetDeviceProperties(ByVal nameBuffer As StringBuilder, ByRef NIcodePtr As UInt32) As Boolean
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srDetectInterfaceBox@4")> _
    Function DetectInterfaceBox(ByRef boxPtr As Integer) As Integer
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srConfigureBuffer@8")> _
    Function ConfigureBuffer(ByVal length_ms As UInt32, ByVal nBuffers As UInt32) As Integer
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srGetBufferConfig@8")> _
    Sub GetBufferConfig(ByRef length_msPtr As UInt32, ByRef nBuffersPtr As UInt32)
    End Sub

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srSetOffOnInterval@4")> _
    Function SetOffOnInterval(ByVal time_ms As UInt32) As Boolean
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srGetOffOnInterval@0")> _
    Function GetOffOnInterval() As UInt32
    End Function

#End Region

#Region "Pulse list loading/unloading functions"

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srLoadStimulationSequence@8")> _
    Function LoadStimulationSequence(ByVal pathPtr As String, ByVal maxErr As UInt32) As UInt32
    End Function

    '<DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srLoadStimulationSequenceEcb@16")> _
    'Function LoadStimulationSequenceEcb(ByVal pathPtr As String, PrintStringFun erroutFun, _    'Problem to define PrintStringFun function
    '                                    ByVal addLF As Boolean, ByVal maxErr As UInt32) As UInt32
    'End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srEnterMapfileName@8")> _
    Sub EnterMapfileName(ByVal index As UInt32, ByVal path As String)
    End Sub

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srGetMapfileName@4")> _
    Function GetMapfileName(ByVal index As UInt32) As String
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srClearMapfileList@0")> _
    Sub ClearMapfileList()
    End Sub

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srStimulationSequenceIsInUse@4")> _
    Function StimulationSequenceIsInUse(ByVal seqHandle As UInt32) As Boolean
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srDiscardStimulationSequence@4")> _
    Function DiscardStimulationSequence(ByVal seqHandle As UInt32) As Integer
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srDiscardAll@0")> _
    Function DiscardAll() As UInt32
    End Function

#End Region

#Region "Pulse list loading error functions"

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srLoadErrorCount@0")> _
    Function LoadErrorCount() As UInt32
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srGetLoadError@0")> _
    Function GetLoadError() As String
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srClearLoadErrors@0")> _
    Sub ClearLoadErrors()
    End Sub

#End Region

#Region "Data stream output information functions"

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srStimulationSequenceInfo@28")> _
    Function StimulationSequenceInfo(ByVal seqHandle As UInt32, _
                                     ByRef crtlyRunningLeftPtr As Boolean, ByRef crrtlyRunningRightPtr As Boolean, _
                                     ByRef isLeftBgPtr As Boolean, ByRef isRightBgPtr As Boolean, _
                                     ByRef LeftFgCountPtr As Integer, ByRef RightFgCountPtr As Integer) As Boolean
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srImplantInfo@12")> _
    Function ImplantInfo(ByVal seqHandle As UInt32, _
                         ByRef implantTypePtr As UInt32, ByRef legacyPulsesPtr As Boolean) As Boolean
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srCurrentImplant@20")> _
    Function CurrentImplant(ByVal right As Boolean, ByRef namePtr As String, ByRef impIDPtr As UInt32, _
                            ByRef nElecsPtr As UInt32, ByRef legacyPulsesPtr As Boolean) As UInt32
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srPlaysFg@4")> _
    Function PlaysFg(ByVal right As Boolean) As Boolean
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srPlaysBg@4")> _
    Function PlaysBg(ByVal right As Boolean) As Boolean
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srWaitsForSync@4")> _
    Function WaitsForSync(ByVal right As Boolean) As Boolean
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srOutputIsRunning@0")> _
    Function OutputIsRunning() As Boolean
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_PowerIsOn@4")> _
    Function PowerIsOn(ByVal right As Boolean) As Boolean
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_TriggerActive@4")> _
    Function TriggerActive(ByVal right As Boolean) As Boolean
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_GetChargePerTimeLimits@8")> _
    Function GetChargePerTimeLimits(ByVal right As Boolean, ByRef dest_uAPtr As UInt32) As Boolean
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_GetChargePerTime@8")> _
    Function GetChargePerTime(ByVal right As Boolean, ByRef dest_uAPtr As UInt32) As Boolean
    End Function

#End Region

#Region "Data stream output control functions"

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srSetBgStimulation@12")> _
    Function SetBgStimulation(ByVal seqHandle As UInt32, ByVal left As Boolean, ByVal right As Boolean) As Integer
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srAddFgStimulation@12")> _
    Function AddFgStimulation(ByVal seqHandle As UInt32, ByVal left As Boolean, ByVal right As Boolean) As Integer
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srAddAutoDiscardFgStimulation@8")> _
    Function AddAutoDiscardFgStimulation(ByVal seqHandle As UInt32, ByVal right As Boolean) As Integer
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srClearFgStimulations@8")> _
    Function ClearFgStimulations(ByVal left As Boolean, ByVal right As Boolean) As Integer
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srSwitchStimulation@16")> _
    Sub SwitchStimulation(ByVal leftFg As Integer, ByVal rightFg As Integer, _
                            ByVal leftBg As Integer, ByVal rightBg As Integer)
    End Sub

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srSwitchPower@8")> _
    Sub SwitchPower(ByVal left As Integer, ByVal right As Integer)
    End Sub

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srSwitchTrigger@8")> _
    Sub SwitchTrigger(ByVal left As Integer, ByVal right As Integer)
    End Sub

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srStopStimulation@0")> _
    Function StopStimulation() As Boolean
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srReleaseSync@0")> _
    Function ReleaseSync() As Boolean
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srWaitUntilBoosted@4")> _
    Function WaitUntilBoosted(ByVal timeout_ms As UInt32) As Boolean
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srWaitUntilStopped@4")> _
    Function WaitUntilStopped(ByVal timeout_ms As UInt32) As Boolean
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srWaitUntilNoFg@12")> _
    Function WaitUntilNoFg(ByVal left As Boolean, ByVal right As Boolean, ByVal timeout_ms As UInt32) As Boolean
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srSetChargeLimits@4")> _
    Function SetChargeLimits(ByRef limits_nCPtr As Double) As Integer
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srSetChargeLimitsEx@12")> _
    Function SetChargeLimitsEx(ByVal left As Boolean, ByVal right As Boolean, ByRef limits_nCPtr As Double) As Integer
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srResetChargeLimits@0")> _
    Function ResetChargeLimits() As Integer
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srResetChargeLimitsEx@8")> _
    Function ResetChargeLimitsEx(ByVal left As Boolean, ByVal right As Boolean) As Integer
    End Function

#End Region

#Region "Data stream output error functions"

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srErrorCount@0")> _
    Function ErrorCount() As UInt32
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srGetError@0")> _
    Function GetError() As String
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srClearErrors@0")> _
    Sub ClearErrors()
    End Sub

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srHadUnderrun@0")> _
    Function HadUnderrun() As Boolean
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srErrorCountWithoutUnderrun@0")> _
    Function ErrorCountWithoutUnderrun() As UInt32
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srGetErrorWithoutUnderrun@0")> _
    Function GetErrorWithoutUnderrun() As String
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srChargeLimitExceeded@0")> _
    Function ChargeLimitExceeded() As Boolean
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srChargeLimitExceededEx@4")> _
    Function ChargeLimitExceededEx(ByVal right As Boolean) As Boolean
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srResetChargeLimitIndicator@0")> _
    Sub ResetChargeLimitIndicator()
    End Sub

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srResetChargeLimitIndicatorEx@8")> _
    Sub ResetChargeLimitIndicatorEx(ByVal left As Boolean, ByVal right As Boolean)
    End Sub

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srChargePerTimeLimitExceededEx@4")> _
    Function ChargePerTimeLimitExceeded(ByVal right As Boolean) As Boolean
    End Function

    <DllImport("RIB2.dll", CallingConvention:=CallingConvention.StdCall, EntryPoint:="_srResetChargePerTimeLimitIndicator@8")> _
    Sub ResetChargePerTimeLimitIndicator(ByVal left As Boolean, ByVal right As Boolean)
    End Sub

#End Region

#End Region

#Region "Constants"
    'Parameter to turn fg and bg stimulation on/off
    Public Const NOCHANGE As Integer = 0
    Public Const TURNOFF As Integer = 1
    Public Const TURNON As Integer = 2
#End Region

    Public Function Connect() As String
        Dim iErr, iBox As Integer
        Dim szErr As String = ""
        Dim leftFg As Integer
        Dim rightFg As Integer

        If mblnSimulation Then Return ""

        ' Set device name for the National Instruments IO-card
        Try
            iErr = RIB2.SetDeviceName(mszRIB2Device)
        Catch
            Return "RIB2.dll is not found. Program has reached an unstable state, please restart!"
        End Try

        If CBool(iErr) Then
            ' iErr <> 0
            Select Case iErr
                'Case 0 'Right NI IO-card.
                Case 1
                    szErr = "IO-device exists, but is not the right type."
                Case 2
                    szErr = "Device " & mszRIB2Device & " does not exist."
                Case 3
                    szErr = "Insufficient memory."
                Case 5
                    szErr = "Output currently running - cannot change device name while output is running."
                Case 6
                    szErr = "The NI device is listed in the NI system, but is currently not present"
                Case 7
                    szErr = "Hardware driver DLL is not found."
                Case 255
                    If RIB2.ErrorCount() > 0 Then
                        While RIB2.ErrorCount() > 0
                            szErr = szErr & RIB2.GetError() & vbCrLf
                        End While
                    Else
                        szErr = "srError"
                    End If
                Case Else
                    szErr = "Unknown error while setting the device name for the NI IO-card."
            End Select
            Return szErr
        End If

        ' Check if RIB2s are connected
        iErr = DetectInterfaceBox(iBox)
        If CBool(iErr) Then
            ' iErr <> 0
            ' checks IO device (again)
            Select Case iErr
                Case 1
                    szErr = "IO-device exists, but is not the right type."
                Case 2
                    szErr = "The NI device does not exist."
                Case 3
                    szErr = "Insufficient memory."
                Case 5
                    szErr = "Output currently running - cannot change buffer configuration while output is running."
                Case 7
                    szErr = "Hardware driver DLL not found."
                Case 255
                    If RIB2.ErrorCount() > 0 Then
                        While RIB2.ErrorCount() > 0
                            szErr = szErr & RIB2.GetError() & vbCrLf
                        End While
                    Else
                        szErr = "srError"
                    End If
                Case Else
                    szErr = "Unknown error while checking NI IO-card."
            End Select
            Return szErr
        Else
            ' iErr = 0 -> right NI IO card
            ' checks RIB2 interface box
            Select Case iBox
                Case 0
                    szErr = "Right NI IO card, but no RIB2 is connected."
                    Return szErr
                Case 2
                    'The correct RIB2 interface box is connected.
                Case 1
                    szErr = "Right NI IO card, but an early version of RIB2 is connected and should not be used."
                    Return szErr
                Case 3
                    szErr = "Right NI IO card, but future version of RIB2 is connected which is currently not supported."
                    Return szErr
                Case Else
                    szErr = "Right NI IO card, but unknown error while checking the RIB2 interface box occured."
                    Return szErr
            End Select
        End If

        ' Start stimulation
        If mlImpLeft > 0 Then
            leftFg = TURNON
        Else
            leftFg = TURNOFF
        End If
        If mlImpRight > 0 Then
            rightFg = TURNON
        Else
            rightFg = TURNOFF
        End If

        RIB2.SwitchStimulation(leftFg, rightFg, TURNOFF, TURNOFF)       ' background stimulation always off!
        If RIB2.ErrorCount() > 0 Then
            While RIB2.ErrorCount() > 0
                ' MessageBox.Show(RIB2.GetError, "Error generating stimulation output", MessageBoxButtons.OK, MessageBoxIcon.Error)
                szErr = szErr & RIB2.GetError() & vbCrLf
            End While
            Return szErr
        End If

        ' RIB2 successfully connected
        mblnConnected = True

        Return ""

    End Function

    Public Function LoadStimulationFile(ByVal szStim1 As String, Optional ByVal szStim2 As String = "") As String
        Dim szStim As String
        Dim szDir As String
        Dim szErr As String = ""

        If mblnSimulation Then Return ""

        If mszRoot <> "" Then
            szDir = mszRoot & "\"
        Else
            szDir = ""
        End If

        LoadStimulationFile = ""

        ' left ear
        If mlImpLeft > 0 Then
            mszStmFileLeft = szDir & szStim1
        End If

        ' right ear
        If mlImpRight > 0 Then
            If mlImpLeft > 0 Then szStim = szStim2 Else szStim = szStim1
            mszStmFileRight = szDir & szStim
        End If

    End Function

    Public Function Disconnect() As String
        Dim blnErr As Boolean
        Dim uiErr As UInt32

        If mblnSimulation Then Return ""

        blnErr = RIB2.StopStimulation()
        If blnErr Then
            Return "Timout occured while turning RIB channels off."
        End If

        uiErr = RIB2.DiscardAll()
        If CBool(uiErr) Then
            Return (uiErr.ToString & " sequence(s) could not be discarded (still in use).")
        End If

        ' RIB2 successfully disconnected
        mblnConnected = False

        Return ""

    End Function

    Public Function StartStimulation() As String
        Dim szErr As String = ""
        Dim iErr As Integer
        Dim seqHandleL As UInt32
        Dim seqHandleR As UInt32

        If mblnSimulation Then Return ""

        ' left ear
        If mlImpLeft > 0 Then

            ' load stimulation sequence
            seqHandleL = RIB2.LoadStimulationSequence(mszStmFileLeft, 0)      ' 0 is the maximum number of errors to be sent to the error message queue
            If seqHandleL = 0 Then
                ' an error occured
                While RIB2.LoadErrorCount() > 0
                    szErr = szErr & RIB2.GetLoadError() & vbCrLf
                End While
                Return szErr
            Else
                ' queue stimulation sequence to left ear
                iErr = RIB2.AddFgStimulation(seqHandleL, True, False)
                If CBool(iErr) Then
                    ' iErr <> 0, an error occured
                    Select Case iErr
                        Case 3
                            szErr = "Could not allocate memory."
                        Case 4
                            szErr = "The sequence handle (left ear) is invalid."
                        Case 255
                            If RIB2.ErrorCount() > 0 Then
                                While RIB2.ErrorCount() > 0
                                    szErr = szErr & RIB2.GetError() & vbCrLf
                                End While
                            Else
                                szErr = "srError"
                            End If
                        Case Else
                            szErr = "Unknown error while queuing left stimulation sequence."
                    End Select
                    Return szErr
                Else
                    ' iErr = 0, no error
                    ' left sequence has been queued
                End If
            End If
        End If

        ' right ear
        If mlImpRight > 0 Then

            ' load stimulation sequence
            seqHandleR = RIB2.LoadStimulationSequence(mszStmFileRight, 0)      ' 0 is the maximum number of errors to be sent to the error message queue
            If seqHandleR = 0 Then
                ' an error occured
                While RIB2.LoadErrorCount() > 0
                    szErr = szErr & RIB2.GetLoadError() & vbCrLf
                End While
                Return szErr
            Else
                ' queue stimulation sequence to left ear
                iErr = RIB2.AddFgStimulation(seqHandleR, False, True)
                If CBool(iErr) Then
                    ' iErr <> 0, an error occured
                    Select Case iErr
                        Case 3
                            szErr = "Could not allocate memory."
                        Case 4
                            szErr = "The sequence handle (right ear) is invalid."
                        Case 255
                            If RIB2.ErrorCount() > 0 Then
                                While RIB2.ErrorCount() > 0
                                    szErr = szErr & RIB2.GetError() & vbCrLf
                                End While
                            Else
                                szErr = "srError"
                            End If
                        Case Else
                            szErr = "Unknown error while queuing right stimulation sequence."
                    End Select
                    Return szErr
                Else
                    ' iErr = 0, no error
                    ' right sequence has been queued
                End If
            End If
        End If


        Return ""
    End Function

    Public Function WaitForReady(ByVal lTimeOut As Integer) As String
        Dim blnErr As Boolean
        Dim szErr As String = ""

        If mblnSimulation Then
            ' simulate wait for ready -> wait 1/2 of lTimeout
            TimerStart(lTimeOut \ 2)
            Do
                Windows.Forms.Application.DoEvents()
            Loop Until mblnTimeOut
            TimerStop()
        Else
            'blnErr = RIB2.WaitUntilStopped(CUInt(lTimeOut))
            blnErr = RIB2.WaitUntilNoFg(True, True, CUInt(lTimeOut))

            If blnErr Then
                Return "Timeout has occured. Sequences are still queued or being played."
                'Return "Timeout has occured, output is still running."
            End If
        End If

        Return ""
    End Function

    Private Sub TimerElapsed(ByVal stateInfo As Object)
        TimerStop()
        mblnTimeOut = True
    End Sub

    Private Sub TimerStart(ByVal lTimeOut As Integer)
        TimerStop()
        Dim TimerDelegate As System.Threading.TimerCallback = AddressOf RIB2.TimerElapsed
        mTimer = New System.Threading.Timer(TimerDelegate, Nothing, lTimeOut, System.Threading.Timeout.Infinite)
    End Sub

    Private Sub TimerStop()
        mblnTimeOut = False
        If Not IsNothing(mTimer) Then
            mTimer.Dispose()
            mTimer = Nothing
        End If
    End Sub

#Region "Events"

    Public Sub Initialize()
        mszRoot = "test\"
        mszRIB2Device = "Dev1"
        mlImpLeft = 1
        mlImpRight = 2
        mblnSimulation = False
        mblnConnected = False
        mszFittLeft = ""
        mszFittRight = ""
    End Sub

    Public Sub Terminate()
        Dim szErr As String

        If Not mblnConnected Then Return

        szErr = RIB2.Disconnect()
    End Sub

#End Region

End Module
