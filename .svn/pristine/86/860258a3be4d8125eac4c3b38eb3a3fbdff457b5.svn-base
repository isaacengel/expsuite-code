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
Module RIB
    Const SERVERDOWN_DELAY As Short = 1000

    'Public Enum RIBERROR
    '  ribOK = 0
    '  ribNotImplemented = 1
    '  ribNotConnected = 2
    '  ribWrongParameter = 3
    '  ribRIBServerNotFound = 4
    '  ribOpenDDEFailed = 5
    '  ribTimeOut = 1000
    'End Enum

    Public Enum SRVMODE
        srvmodeDDE
        srvmodeIP
    End Enum

    Public Enum resetMode
        resetCompletly
        resetRIBInit
        resetRIBAllData
        resetRIBStimData
    End Enum

    Public Enum DDESTATUS
        ddeDisConnected
        ddeConnected
        ddeSetRib
        ddeSetFitt
    End Enum

    ' data for properties
    Private mszRIBServer As String
    Private mblnSimulation As Boolean
    Private msrvmodeServerMode As SRVMODE
    Private mszRoot As String
    Private mlBaudRate As Integer
    Private mlComLeft As Integer
    Private mlComRight As Integer
    Private mszFittLeft As String
    Private mszFittRight As String
    Private mlServerDelay As Integer
    Private mblnTerminateRIB As Boolean
    ' internal data
    Private gddeStatus As DDESTATUS
    Private mTimer As System.Threading.Timer
    Private mblnTimeOut As Boolean
    Private mDDE As DDEConnection


    ' ------------------------------------------------------
    ' Methods
    ' ------------------------------------------------------

    Public Function Disconnect() As String

        If mblnSimulation Then
            gddeStatus = DDESTATUS.ddeDisConnected
            Return ""
        End If

        If IsNothing(mDDE) Then Return ""

        If mDDE.Connected Then
            ResetConnection(resetMode.resetCompletly)
            mDDE.Disconnect()
            ' wait until RIBServer is disconnected
            TimerStart(SERVERDOWN_DELAY)
            Do
                Windows.Forms.Application.DoEvents()
            Loop Until mblnTimeOut
            TimerStop()
        End If

        ' Tear down the initialized instance.
        mDDE.Terminate()

        ' Close all instances of DDE-Server
        If mblnTerminateRIB Then Proc.CloseApplication(mszRIBServer)

        gddeStatus = DDESTATUS.ddeDisConnected
        Return "" ' no errors

    End Function

    Public Function ControlStatus() As DDESTATUS
        Return gddeStatus
    End Function

    Public Function WaitForReady(ByVal lTimeOut As Integer) As String
        Dim blnX As Boolean
        Dim szErr As String = ""

        If mblnSimulation Then
            ' simulate wait for ready -> wait 1/2 of lTimeout
            TimerStart(lTimeOut \ 2)
            Do
                Windows.Forms.Application.DoEvents()
            Loop Until mblnTimeOut
            TimerStop()
        Else
            ' start timeout timer
            TimerStart(lTimeOut)
            blnX = False
            Do
                Windows.Forms.Application.DoEvents()
                blnX = IsReady(szErr)
                If Len(szErr) > 0 Then blnX = True
            Loop Until mblnTimeOut Or blnX
            TimerStop()

            If mblnTimeOut Then
                Return "Time out error." & vbCrLf & "Device not ready after " & CStr(lTimeOut) & " ms."
            End If

            If Len(szErr) > 0 Then
                Return "Communication Error: " & szErr ' communication error
            End If

        End If 'simulation?
        Return ""

    End Function

    Public Function IsReady(ByRef szErr As String) As Boolean
        Dim lStatus As Integer
        Dim lMask As Integer

        If mblnSimulation Then
            szErr = ""
            Return True
        End If

        szErr = GetStatus(lStatus)
        If Len(szErr) <> 0 Then Return False
        If mlComLeft > 0 Or mlComRight > 0 Then lMask = &H40S
        If mlComLeft > 0 And mlComRight > 0 Then lMask = &H4040S
        If (lStatus And lMask) = 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function ResetConnection(ByVal resetMode As resetMode) As String
        Dim szCmd As String
        Dim lRet As IntPtr
        Dim lRib As Integer
        Dim ddeNew As DDESTATUS
        Dim lMode As Integer

        ' are we connected?
        If gddeStatus = DDESTATUS.ddeDisConnected Then Return "RIB not connected error."
        ' mode ?
        If msrvmodeServerMode <> SRVMODE.srvmodeDDE Then Return "Reset: Mode not implemented."

        ' ResetRIB
        If mlComLeft > 0 Then If mlComRight > 0 Then lRib = 2
        If mlComLeft > 0 Then If mlComRight <= 0 Then lRib = 0
        If mlComLeft <= 0 Then If mlComRight > 0 Then lRib = 1
        Select Case resetMode
            Case resetMode.resetCompletly
                lMode = 0
                ddeNew = DDESTATUS.ddeDisConnected
            Case resetMode.resetRIBInit
                lMode = 1
                ddeNew = DDESTATUS.ddeDisConnected
            Case resetMode.resetRIBAllData
                lMode = 2
                ddeNew = DDESTATUS.ddeConnected
            Case resetMode.resetRIBStimData
                lMode = 3
                ddeNew = DDESTATUS.ddeSetFitt
            Case Else
                Return "Unknown parameter."
        End Select

        If mblnSimulation Then gddeStatus = ddeNew : Return ""

        mDDE.CreateStringHandles("rib", "rib")
        If Not mDDE.Connected Then mDDE.Connect()
        szCmd = "resetrib " & CStr(lRib) & " " & CStr(lMode)
        lRet = mDDE.ClientTransaction(szCmd, 0, XTYP_EXECUTE, 2000)
        If lRet <> IntPtr.Zero Then
            Debug.Print("Reset: DDE Execute Success.")
            Return ""
        Else
            szCmd = mDDE.TranslateError()
            Return "Reset: DDE Error: " & szCmd
        End If
        gddeStatus = ddeNew

    End Function

    Public Function GetStatus(ByRef lStatus As Integer) As String
        Dim szCmd As String
        Dim lRet As IntPtr
        Dim lRib As Integer
        Dim lSize As Integer
        Dim szBuffer As String = ""

        GetStatus = ""

        If mblnSimulation Then
            lStatus = 0
            Return ""
        End If

        ' dde connection ?
        If gddeStatus = DDESTATUS.ddeDisConnected Then
            Return "GetStatus: Not connected to RIB."
        End If

        ' get status
        If msrvmodeServerMode = SRVMODE.srvmodeDDE Then
            If mlComLeft > 0 And mlComRight > 0 Then lRib = 2
            If mlComLeft > 0 And mlComRight <= 0 Then lRib = 0
            If mlComLeft <= 0 And mlComRight > 0 Then lRib = 1
            ' update status
            mDDE.CreateStringHandles("rib", "rib")
            szCmd = "updatestatus " & CStr(lRib)
            lRet = mDDE.ClientTransaction(szCmd, 0, XTYP_EXECUTE, 2000)
            If lRet <> IntPtr.Zero Then
                Debug.Print("UpdateStatus: DDE Execute Success.")
            Else
                Return "GetStatus: DDE Error: " & mDDE.TranslateError()
            End If

            ' get status from the left RIB
            If mlComLeft > 0 Then
                mDDE.CreateStringHandles("rib", "rib", "lstatus")
                lRet = mDDE.ClientTransaction(Nothing, CF_TEXT, XTYP_REQUEST, 2000)
                If lRet <> IntPtr.Zero Then
                    Debug.Print("GetStatus(L): DDE Request Success.")
                    lSize = mDDE.GetData(lRet, szBuffer)
                    If IsNumeric(szBuffer) Then lStatus = CInt(Val(szBuffer))
                    Debug.Print("GetStatus(L): " & CStr(lStatus))
                Else
                    Return "GetStatus: DDE Error: " & mDDE.TranslateError()
                End If
            End If

            ' get status from the right RIB
            If mlComRight > 0 Then
                mDDE.CreateStringHandles("rib", "rib", "rstatus")
                lRet = mDDE.ClientTransaction(Nothing, CF_TEXT, XTYP_REQUEST, 2000)
                If lRet <> IntPtr.Zero Then
                    Debug.Print("GetStatus(R): DDE Request Success.")
                    lSize = mDDE.GetData(lRet, szBuffer)
                    If IsNumeric(szBuffer) Then
                        Debug.Print("GetStatus(R): " & CStr(Val(szBuffer)))
                        If mlComLeft > 0 Then
                            lStatus = lStatus + CInt(Val(szBuffer)) * &H100S
                        Else
                            lStatus = CInt(Val(szBuffer))
                        End If
                    End If
                Else
                    Return "GetStatus: DDE Error: " & mDDE.TranslateError()
                End If
            End If

        Else
            ' IP Mode
            Return "GetStatus: Mode not implemented."
        End If


    End Function


    Public Function StartStimulation() As String
        Dim szCmd As String
        Dim lRet As IntPtr
        Dim lRib As Integer


        If mblnSimulation Then Return ""

        StartStimulation = ""
        ' stimulation allowed?
        If gddeStatus <> DDESTATUS.ddeSetFitt Then
            Return "StartStimulation: RIB not connected."
        End If
        ' start stimulation
        If msrvmodeServerMode = SRVMODE.srvmodeDDE Then
            If mlComLeft > 0 Then If mlComRight > 0 Then lRib = 2
            If mlComLeft > 0 Then If mlComRight <= 0 Then lRib = 0
            If mlComLeft <= 0 Then If mlComRight > 0 Then lRib = 1
            ' start stimulation using DDE
            mDDE.CreateStringHandles("rib", "rib")
            szCmd = "startstimulation " & CStr(lRib)
            lRet = mDDE.ClientTransaction(szCmd, 0, XTYP_EXECUTE, 2000)
            If lRet <> IntPtr.Zero Then
                Debug.Print("StartStim: DDE Execute Success.")
            Else
                Return "StartStimulation: DDE Error: " & mDDE.TranslateError()
            End If
        Else
            ' IP Mode
            Return "StartStimulation: Mode not implemented."
        End If

    End Function


    Public Function LoadStimulationFile(ByVal szStim1 As String, Optional ByVal szStim2 As String = "") As String
        Dim szStim As String
        Dim szDir As String
        Dim szCmd As String
        Dim lRet As IntPtr


        If mblnSimulation Then Return ""

        LoadStimulationFile = ""
        ' loading allowed?
        If gddeStatus <> DDESTATUS.ddeSetFitt Then
            Return "LoadStimulationFile: RIB not connected."
        End If

        If mszRoot <> "" Then
            szDir = mszRoot & "\"
        Else
            szDir = ""
        End If


        If msrvmodeServerMode = SRVMODE.srvmodeDDE Then
            ' load stim left in DDE mode
            If mlComLeft > 0 Then
                ' set stimulation file
                mDDE.CreateStringHandles("rib", "rib")
                szCmd = "setstimulation 0 0 " & szDir & szStim1
                lRet = mDDE.ClientTransaction(szCmd, 0, XTYP_EXECUTE, 5000)
                If (lRet <> IntPtr.Zero) Then
                    Debug.Print("SetStim(L): DDE Execute Success.")
                Else
                    Return "LoadStimulationFile(SetStim[L]): DDE Error: " & mDDE.TranslateError()
                End If
                ' load
                szCmd = "loadrib 0"
                lRet = mDDE.ClientTransaction(szCmd, 0, XTYP_EXECUTE, 10000)
                If (lRet <> IntPtr.Zero) Then
                    Debug.Print("LoadRIB(L): DDE Execute Success.")
                Else
                    Return "LoadStimulationFile(LoadRIB[L]): DDE Error: " & mDDE.TranslateError()
                End If
            End If

            ' load stim Right in DDE mode
            If mlComRight > 0 Then
                ' set stimulation file
                mDDE.CreateStringHandles("rib", "rib")
                If mlComLeft > 0 Then szStim = szStim2 Else szStim = szStim1
                szCmd = "setstimulation 1 0 " & szDir & szStim
                lRet = mDDE.ClientTransaction(szCmd, 0, XTYP_EXECUTE, 5000)
                If (lRet <> IntPtr.Zero) Then
                    Debug.Print("SetStim(R): DDE Execute Success.")
                Else
                    Return "LoadStimulationFile(SetStim[R]): DDE Error: " & mDDE.TranslateError()
                End If
                ' load
                szCmd = "loadrib 1"
                lRet = mDDE.ClientTransaction(szCmd, 0, XTYP_EXECUTE, 10000)
                If (lRet <> IntPtr.Zero) Then
                    Debug.Print("LoadRIB(R): DDE Execute Success.")
                Else
                    Return "LoadStimulationFile(LoadRIB[R]): DDE Error: " & mDDE.TranslateError()
                End If
            End If

        Else
            ' IP Mode
            Return "LoadStimulationFile: Mode not implemented."
        End If

    End Function

    Public Function Connect() As String
        Dim szDir As String
        Dim lRet As IntPtr
        Dim szCmd As String

        ' we're connected, ribs are set and fitting files are loaded. Init?
        If gddeStatus = DDESTATUS.ddeSetFitt Then Return ""

        ' check parameters
        If mlComLeft <> 0 And mlComLeft = mlComRight Then
            Return "Connect: COM port left equals COM port right error."
        End If

        mDDE = New DDEConnection

        If gddeStatus = DDESTATUS.ddeDisConnected Then
            ' we aren't connected and ribs aren't set
            If mblnSimulation = False Then
                ' Start RIBServer if necessary
                If Not Proc.FindProcess(mszRIBServer) Then
                    ' try to start from application directory
                    Dim lProcID As Integer = Proc.StartApplication(My.Application.Info.DirectoryPath & "\" & mszRIBServer)
                    If lProcID < 33 And lProcID > 0 Then
                        ' try to start from windows dir
                        szDir = GetWindowsDir()
                        lProcID = Proc.StartApplication(szDir & "\" & mszRIBServer)
                        If lProcID < 33 And lProcID > 0 Then
                            ' try to start from system directory
                            szDir = GetSystemDir()
                            lProcID = Proc.StartApplication(szDir & "\" & mszRIBServer)
                            If lProcID < 33 And lProcID > 0 Then
                                Return "Connect: RIB Server not found error."
                            End If
                        End If
                    End If
                End If
                ' wait until RIBServer is started
                TimerStart(mlServerDelay)
                Do
                    Windows.Forms.Application.DoEvents()
                    If Proc.FindProcess(mszRIBServer) Then mblnTimeOut = True
                Loop Until mblnTimeOut
                TimerStop()
                TimerStart(500)
                Do
                    Windows.Forms.Application.DoEvents()
                Loop Until mblnTimeOut
                TimerStop()
            End If 'mblnSimulation=false

            If msrvmodeServerMode = SRVMODE.srvmodeDDE Then
                If mblnSimulation Then
                    gddeStatus = DDESTATUS.ddeConnected
                Else
                    ' Init RIBs in DDE mode
                    ' Close any old  conversation if necessary
                    If mDDE.Connected Then
                        mDDE.Disconnect()
                    End If
                    ' open a new conversation
                    mDDE.CreateStringHandles("rib", "rib")
                    If Not mDDE.Connected Then
                        mDDE.Connect()
                        If mDDE.Connected Then
                            gddeStatus = DDESTATUS.ddeConnected ' now we're connected
                        Else
                            Return "Connect: Can't establish DDE connection error."
                        End If
                    End If
                End If
            Else
                Return "Connect: mode not implemented error." ' IP mode
            End If
        End If

        If gddeStatus = DDESTATUS.ddeConnected Then
            ' we're connected and we must set ribs
            If mblnSimulation Then
                gddeStatus = DDESTATUS.ddeSetRib
            Else
                If msrvmodeServerMode = SRVMODE.srvmodeDDE Then
                    ' Init Left RIB in DDE mode
                    If mlComLeft > 0 Then
                        mDDE.CreateStringHandles("rib", "rib")
                        szCmd = "setrib 0 " & CStr(mlComLeft) & " " & CStr(mlBaudRate)
                        If mDDE.Connected Then
                            ' Perform the transaction.
                            lRet = mDDE.ClientTransaction(szCmd, 0, XTYP_EXECUTE, 2000)
                            If (lRet <> IntPtr.Zero) Then
                                Debug.Print("SetRIB(L): DDE Execute Success.")
                            Else
                                gddeStatus = DDESTATUS.ddeDisConnected
                                Return "Connect: DDE Error while connecting to the left RIB:" & mDDE.TranslateError()
                            End If
                        End If
                    End If

                    ' Init Right RIB in DDE Mode
                    If mlComRight > 0 Then
                        mDDE.CreateStringHandles("rib", "rib")
                        szCmd = "setrib 1 " & CStr(mlComRight) & " " & CStr(mlBaudRate)
                        If mDDE.Connected Then
                            ' Perform the transaction.
                            lRet = mDDE.ClientTransaction(szCmd, 0, XTYP_EXECUTE, 2000)
                            If (lRet <> IntPtr.Zero) Then
                                Debug.Print("SetRIB(R): DDE Execute Success.")
                            Else
                                gddeStatus = DDESTATUS.ddeDisConnected
                                Return "Connect: DDE Error while connecting to the right RIB: " & mDDE.TranslateError()
                            End If
                        End If
                    End If
                    gddeStatus = DDESTATUS.ddeSetRib ' now the ribs are ready
                Else
                    ' IP Mode
                    Return "Connect: mode not implemented error."
                End If
            End If ' simulation?
        End If

        If gddeStatus = DDESTATUS.ddeSetRib Then
            ' ribs are set, we can load fitting files
            If mblnSimulation Then
                gddeStatus = DDESTATUS.ddeSetFitt
            Else
                If msrvmodeServerMode = SRVMODE.srvmodeDDE Then
                    If mszRoot <> "" Then
                        szDir = mszRoot & "\"
                    Else
                        szDir = ""
                    End If
                    ' set fittL in DDE mode
                    If mlComLeft > 0 Then
                        mDDE.CreateStringHandles("rib", "rib")
                        szCmd = "setfitting 0 " & szDir & mszFittLeft
                        If mDDE.Connected Then
                            ' Perform the transaction.
                            lRet = mDDE.ClientTransaction(szCmd, 0, XTYP_EXECUTE, 2000)
                            If (lRet <> IntPtr.Zero) Then
                                Debug.Print("SetFitt(L): DDE Execute Success.")
                            Else
                                Return "Connect: DDE Error while setting fitting file for the left ear" & mDDE.TranslateError()
                            End If
                        End If
                    End If

                    ' set FittRight in DDE Mode
                    If mlComRight > 0 Then
                        mDDE.CreateStringHandles("rib", "rib")
                        szCmd = "setfitting 1 " & szDir & mszFittRight
                        If mDDE.Connected Then
                            ' Perform the transaction.
                            lRet = mDDE.ClientTransaction(szCmd, 0, XTYP_EXECUTE, 2000)
                            If (lRet <> IntPtr.Zero) Then
                                Debug.Print("SetFitt(R): DDE Execute Success.")
                            Else
                                Return "Connect: DDE Error while setting fitting file for the right ear: " & mDDE.TranslateError()
                            End If
                        End If
                    End If
                    gddeStatus = DDESTATUS.ddeSetFitt ' now the ribs are ready
                    ' set me to foreground
                    'SetForegroundWindow(MyBase.Handle.ToInt32)
                Else
                    ' IP Mode
                    Return "Connect: Mode not implemented error."
                End If
            End If ' simulation?
        End If

        Return ""

    End Function


    ' ------------------------------------------------------
    ' Events
    ' ------------------------------------------------------

    Public Sub Initialize()
        gddeStatus = DDESTATUS.ddeDisConnected
        msrvmodeServerMode = SRVMODE.srvmodeDDE
        mszRoot = "test\"
        mlBaudRate = 115200
        mlComLeft = 1
        mlComRight = 2
        mblnSimulation = False
        mszRIBServer = "RIB32.exe"
        mszFittLeft = ""
        mszFittRight = ""
        mlServerDelay = 1000
        mblnTerminateRIB = True
    End Sub

    Public Sub Terminate()
        ' Make sure we don't have any open connections.
        If IsNothing(mDDE) Then Return

        If mDDE.Connected Then
            ResetConnection(resetMode.resetCompletly)
            mDDE.Disconnect()

            ' wait until RIBServer is disconnected
            TimerStart(SERVERDOWN_DELAY)
            Do
                Windows.Forms.Application.DoEvents()
            Loop Until mblnTimeOut
            TimerStop()
        End If
        ' Tear down the initialized instance.
        mDDE.Terminate()
        ' Close all instances of DDE-Server
        If mblnTerminateRIB Then Proc.CloseApplication(mszRIBServer)

    End Sub


    ' ------------------------------------------------------
    ' Properties
    ' ------------------------------------------------------

    Public Property ServerMode() As SRVMODE
        Get
            Return msrvmodeServerMode
        End Get
        Set(ByVal Value As SRVMODE)
            Select Case Value
                Case SRVMODE.srvmodeIP
                    msrvmodeServerMode = Value
                Case SRVMODE.srvmodeDDE
                    msrvmodeServerMode = Value
                Case Else
                    msrvmodeServerMode = Value
            End Select
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


    Public Property BaudRate() As Integer
        Get
            Return mlBaudRate
        End Get
        Set(ByVal Value As Integer)
            mlBaudRate = Value
        End Set
    End Property


    Public Property COMLeft() As Integer
        Get
            Return mlComLeft
        End Get
        Set(ByVal Value As Integer)
            mlComLeft = Value
        End Set
    End Property


    Public Property COMRight() As Integer
        Get
            Return mlComRight
        End Get
        Set(ByVal Value As Integer)
            mlComRight = Value
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


    Public Property RIBServer() As String
        Get
            Return mszRIBServer
        End Get
        Set(ByVal Value As String)
            mszRIBServer = Value
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


    Public Property ServerDelay() As Integer
        Get
            Return mlServerDelay
        End Get
        Set(ByVal Value As Integer)
            mlServerDelay = Value
        End Set
    End Property


    Public Property TerminateServer() As Boolean
        Get
            Return mblnTerminateRIB
        End Get
        Set(ByVal Value As Boolean)
            mblnTerminateRIB = Value
        End Set
    End Property

    Private Sub TimerElapsed(ByVal stateInfo As Object)
        TimerStop()
        mblnTimeOut = True
    End Sub

    Private Sub TimerStart(ByVal lTimeOut As Integer)
        TimerStop()
        Dim TimerDelegate As System.Threading.TimerCallback = AddressOf RIB.TimerElapsed
        mTimer = New System.Threading.Timer(TimerDelegate, Nothing, lTimeOut, System.Threading.Timeout.Infinite)
    End Sub

    Private Sub TimerStop()
        mblnTimeOut = False
        If Not IsNothing(mTimer) Then
            mTimer.Dispose()
            mTimer = Nothing
        End If
    End Sub

End Module
