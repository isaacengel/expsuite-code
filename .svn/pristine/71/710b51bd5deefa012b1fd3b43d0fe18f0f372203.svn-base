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
''' <summary>
''' FrameWork - Handling of output devices.
''' </summary>
''' <remarks></remarks>
Module Output
	
	''
	' FrameWork - Handling of output devices
    Public stopWatch As New Stopwatch()
	Public Enum PLAYERFLAGS
		pfASIO = 1
		pfNoADC = 2
		pfnogui = 4
		pfKillondisconnect = 8
		pfFreezeOnStimulation = 16
	End Enum
	

	Public Const STIMFILEEXT_RIB As String = ".stim"
    Public Const STIMFILEEXT_NIC As String = ".stim"
    Public Const STIMFILEEXT_RIB2 As String = ".stm"
    Public Const STIMFILEEXT_ACOUSTIC As String = ".wav"

    Private wskSend As Net.Sockets.UdpClient
    Private wskReceive As Net.Sockets.UdpClient
    Private mblnPlayerConnected As Boolean
    Private mszFnTrigger As String = Nothing

    ' ------------------------------------------------------------------
    ' RIB - Connection
    ' ------------------------------------------------------------------

    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)

    Public Function Connect(Optional ByVal blnForcePlayer As Boolean = False) As String
        Select Case STIM.GenerationMode
            Case STIM.GENMODE.genElectricalRIB
                Dim szErr As String = RIBOn()
                If Len(szErr) <> 0 Then Return szErr
                If blnForcePlayer Then
                    szErr = PlayerOn()
                    If Len(szErr) > 0 Then Return szErr
                    mblnPlayerConnected = True
                End If
                gblnOutputStable = CBool(Len(szErr) = 0)
            Case STIM.GENMODE.genAcoustical, STIM.GENMODE.genVocoder
                RIB.RootDirectory = STIM.WorkDir
                If gblnDoNotConnectToDevice = False Then
                    Dim szErr As String = PlayerOn()
                    If Len(szErr) > 0 Then Return szErr
                    mblnPlayerConnected = True
                    gblnOutputStable = CBool(Len(szErr) = 0)
                Else
                    gblnOutputStable = True
                End If
            Case STIM.GENMODE.genAcousticalUnity
                RIB.RootDirectory = STIM.WorkDir
                If gblnDoNotConnectToDevice = False Then
                    Dim szErr As String = UnityOn()
                    If Len(szErr) > 0 Then Return szErr
                    mblnPlayerConnected = True
                    gblnOutputStable = True
                Else
                    gblnOutputStable = True
                End If
            Case STIM.GENMODE.genElectricalNIC
                If STIM.UseMatlab = False Then
                    gblnOutputStable = False
                    Return "Matlab required for NIC"
                Else
                    Dim szErr As String = STIM.Matlab("fitting=NIC_Init(fitting);")
                    If Len(szErr) <> 0 Then Return szErr
                    If blnForcePlayer Then
                        szErr = PlayerOn()
                        If Len(szErr) > 0 Then Return szErr
                        mblnPlayerConnected = True
                    End If
                    gblnOutputStable = CBool(Len(szErr) = 0)
                End If
            Case STIM.GENMODE.genElectricalRIB2
                Dim szErr As String = RIB2On()
                If Len(szErr) <> 0 Then Return szErr
                If blnForcePlayer Then
                    szErr = PlayerOn()
                    If Len(szErr) > 0 Then Return szErr
                    mblnPlayerConnected = True
                End If
                gblnOutputStable = CBool(Len(szErr) = 0)
            Case Else
                gblnOutputStable = False
                Return "Unknown output device"
        End Select
        Return ""

    End Function

    Public Function Disconnect() As String
        Select Case STIM.GenerationMode
            Case STIM.GENMODE.genElectricalRIB
                Dim szErr As String = RIBOff()
                If Len(szErr) <> 0 Then Return szErr
                If mblnPlayerConnected Then szErr = PlayerOff()
                mblnPlayerConnected = False
                gblnOutputStable = False
                Return szErr
            Case STIM.GENMODE.genElectricalNIC
                Dim szErr As String = STIM.Matlab("NIC_Close(fitting);")
                If Len(szErr) <> 0 Then Return szErr
                If mblnPlayerConnected Then szErr = PlayerOff()
                mblnPlayerConnected = False
                gblnOutputStable = False
                Return szErr
            Case STIM.GENMODE.genElectricalRIB2
                Dim szErr As String = RIB2Off()
                If Len(szErr) <> 0 Then Return szErr
                If mblnPlayerConnected Then szErr = PlayerOff()
                mblnPlayerConnected = False
                gblnOutputStable = False
                Return szErr
            Case STIM.GENMODE.genAcoustical, GENMODE.genVocoder
                If gblnDoNotConnectToDevice = False Then
                    Dim szErr As String = PlayerOff()
                    mblnPlayerConnected = False
                    gblnOutputStable = False
                    Return szErr
                Else
                    gblnOutputStable = False
                End If
            Case STIM.GENMODE.genAcousticalUnity
                ' to be added (Valerian please :-))
                ' ... -> ok ok, Miho did it finally... I hope that's also fine Piotr? ;-)
                If gblnDoNotConnectToDevice = False Then
                    Dim szErr As String = UnityOff()
                    mblnPlayerConnected = False
                    gblnOutputStable = False
                    Return szErr
                Else
                    gblnOutputStable = False
                End If
        End Select

        Return ""
    End Function
    Public Function RIBOn() As String
        Dim szErr As String
        ' init RIB
        'frmMain.sbStatusBar.Items.Item(STB_STATUS).Text = "Init RIB - Please wait..."
        frmMain.SetStatus("Init RIB - Please wait...")
        RIB.RIBServer = gszRIBServer
        RIB.RootDirectory = STIM.WorkDir
        RIB.Simulation = gblnRIBSimulation Or gblnDoNotConnectToDevice
        RIB.COMLeft = glCOMLeft
        RIB.FittLeft = gstLeft.szFittFile 'gszFittFileLeft
        RIB.COMRight = glCOMRight
        RIB.FittRight = gstRight.szFittFile 'gszFittFileRight
        szErr = RIB.Connect
        If Len(szErr) <> 0 Then Return szErr
        ' update form
        Dim szX As String
        If RIB.Simulation Then szX = "[" & gstLeft.szImpType & "]" Else szX = gstLeft.szImpType
        frmMain.sbStatusBar.Items.Item(STB_LEFT).Text = szX
        If RIB.Simulation Then szX = "[" & gstRight.szImpType & "]" Else szX = gstRight.szImpType
        frmMain.sbStatusBar.Items.Item(STB_RIGHT).Text = szX
        Return ""

    End Function

    Public Function RIB2On() As String
        Dim szErr As String
        ' init RIB2
        frmMain.SetStatus("Init RIB2 - Please wait...")
        RIB2.RIB2Device = gszRIB2DeviceName
        RIB2.RootDirectory = STIM.WorkDir
        RIB2.Simulation = gblnRIB2Simulation Or gblnDoNotConnectToDevice
        RIB2.ImpLeft = glImpLeft
        RIB2.FittLeft = gstLeft.szFittFile 'gszFittFileLeft
        RIB2.ImpRight = glImpRight
        RIB2.FittRight = gstRight.szFittFile 'gszFittFileRight

        szErr = RIB2.Connect
        If Len(szErr) <> 0 Then Return szErr

        ' update form
        Dim szX As String
        If RIB2.Simulation Then szX = "[" & gstLeft.szImpType & "]" Else szX = gstLeft.szImpType
        frmMain.sbStatusBar.Items.Item(STB_LEFT).Text = szX
        If RIB2.Simulation Then szX = "[" & gstRight.szImpType & "]" Else szX = gstRight.szImpType
        frmMain.sbStatusBar.Items.Item(STB_RIGHT).Text = szX
        Return ""

    End Function

    Public Function RIBOff() As String
        Dim szErr As String

        ' finish rib
        frmMain.SetStatus("Closing RIB")
        szErr = RIB.Disconnect
        If Len(szErr) <> 0 Then Return szErr

        ' set global data
        F4FL.ClearParameters()
        F4FR.ClearParameters()

        ' set labels
        frmMain.sbStatusBar.Items.Item(STB_LEFT).Text = ""
        frmMain.sbStatusBar.Items.Item(STB_RIGHT).Text = ""

        Return ""

    End Function

    Public Function RIB2Off() As String
        Dim szErr As String = ""

        ' finish RIB2
        frmMain.SetStatus("Closing RIB2")
        szErr = RIB2.Disconnect
        If Len(szErr) <> 0 Then Return szErr

        ' set global data
        F4FL.ClearParameters()
        F4FR.ClearParameters()

        ' set labels
        frmMain.sbStatusBar.Items.Item(STB_LEFT).Text = ""
        frmMain.sbStatusBar.Items.Item(STB_RIGHT).Text = ""

        Return ""

    End Function
    ' ------------------------------------------------------------------
    ' AUDIO, OSC
    ' ------------------------------------------------------------------


    ''' <summary>
    ''' Send an OSC command to YAMI.
    ''' </summary>
    ''' <param name="szAddr">OSC address in format "/root/tree1/obj2/method3"</param>
    ''' <param name="varArgs">Parameters in an array.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Send(ByVal szAddr As String, ByVal ParamArray varArgs() As Object) As String
        If gblnDoNotConnectToDevice = False Then

            'If gbPlayerOSC And varArgs.Length = 0 Then varArgs = New Object() {0} 'comply with OSC standard

            Dim bytBuf() As Byte = OSC.PreparePacket(szAddr, varArgs)
            Try
                wskSend.Send(bytBuf, bytBuf.Length)
            Catch x As Exception
                Return x.ToString
            End Try
        End If
        Return ""

    End Function

    Private Sub wskResponse_DataArrival(ByVal ar As IAsyncResult)
        Dim szTemp, szCmd, szErr As String
        Dim bytData() As Byte
        Dim lX As Integer
        Dim varArgs(0) As Object
        Dim szCmdBackup As String
        szCmd = ""
        szTemp = ""

        If IsNothing(wskReceive) Then Return

        'Console.WriteLine("\Enter")

        If IsNothing(DirectCast(ar.AsyncState, Net.Sockets.UdpClient).Client) Then Console.WriteLine("/Nothing -> Leave") : Return

        Dim RemoteIpEndPoint As New Net.IPEndPoint(Net.IPAddress.Any, 0)
        Try
            If IsNothing(DirectCast(ar.AsyncState, Net.Sockets.UdpClient).Client) Then Return
            bytData = DirectCast(ar.AsyncState, Net.Sockets.UdpClient).EndReceive(ar, RemoteIpEndPoint)
        Catch
            Console.WriteLine("/Error -> Leave")
            Return
        End Try

        szErr = OSC.ParseBuffer(bytData, szCmd, varArgs)
        If Len(szErr) > 0 Then GoTo SubError

        If Mid(szCmd, 1, 1) <> "/" Then
            szErr = "OSC: Response without command" : GoTo SubError
        Else
            szCmd = Mid(szCmd, 2)
            szCmdBackup = szCmd
            OSC.SeparateCommand(szCmd, szTemp)
            Select Case szTemp
                ' ---------- CONTROL
                Case "Echo"
                    If InStr(varArgs(0).ToString, "/Play/") > 0 Then
                        stopWatch.Stop()
                    End If
                    'Debug.Print(szTemp & ": " & varArgs(0).ToString)

                Case "Control"
                    Select Case szCmd
                        Case "Version"
                            Console.WriteLine("Player (YAMI/Unity) version: " + varArgs(0).ToString)
                            gszYamiVersion = varArgs(0).ToString
                        Case "SampleRate"
                            If IsNumeric(varArgs(0)) Then
                                glPlayerSampleRate = CInt(Val(varArgs(0)))
                            Else
                                szErr = "SampleRate is not numeric" : GoTo SubError
                            End If
                        Case "CPULoad"
                            'frmMain.SetStatus("CPU Load is " & Str(varArgs(0)) & "%")
                    End Select
                    ' ---------- PLAY
                Case "Play"
                    OSC.SeparateCommand(szCmd, szTemp)
                    If szTemp = "Stop" Then ' a channel stopped playing
                        If IsNumeric(szCmd) Then
                            lX = CInt(Val(szCmd))
                            'glOutputPlay = CInt(CBool(glOutputPlay) And (Not CBool(2 ^ lX)))
                            If lX < glOutputPlay.Count Then 'ignore channel indices higher than used (pd returns stop commands for all channels)
                                glOutputPlay(lX) = False
                            End If
                        Else
                            szErr = "Play/Stop: Channel not numeric" : GoTo SubError
                        End If
                    End If
                    ' ---------- RECORD
                Case "Rec"
                    OSC.SeparateCommand(szCmd, szTemp)
                    Select Case szTemp
                        Case "Stop" ' a channel stopped recording
                            If IsNumeric(szCmd) Then
                                lX = CInt(Val(szCmd))
                                glOutputRecord = CInt(CBool(glOutputRecord) And (Not CBool(2 ^ lX)))
                            End If
                        Case "SaveWAV" ' save wav performed!
                            gblnOutputResponded = True
                    End Select
                    ' ---------- TRACKER
                Case "Tracker"
                    Tracker.HandleResponse(szCmd, varArgs)
                    ' ---------- MIDI
                Case "MIDI"
                    MIDI.HandleResponse(szCmd, varArgs)

                    ' ---------- Unknown command - do nothing
                Case Else

            End Select
            ExpSuite.Events.OnOutputResponse(szCmdBackup, varArgs) ' provide the respone to Events.OnOutputResponse
        End If
SubError:
        If Not IsNothing(wskReceive) Then
            If Not IsNothing(wskReceive.Client) Then
                wskReceive.BeginReceive(New AsyncCallback(AddressOf Output.wskResponse_DataArrival), wskReceive)
                'Console.WriteLine("/Leave-> New")
                Return
            End If
        End If
        Console.WriteLine("/Leave, Closed")
        Return
    End Sub

    Public Function UnityOn() As String
        Dim varArgs() As Object
        Dim szAddr As String
        'Dim dErr As Double
        Dim lX As Integer

        ' connect to UDP
        frmMain.SetStatus("Connecting to Unity Audio...")
        If Not IsNothing(wskSend) Then wskSend = Nothing
        If Not IsNothing(wskReceive) Then wskReceive = Nothing
        Try
            wskSend = New Net.Sockets.UdpClient()
            wskSend.Connect(gszUnityNetAddr, glUnityNetPort)
        Catch x As Exception
            Return "Output: Can't connect to the Unity Audio host " & gszUnityNetAddr & ", port " & TStr(glUnityNetPort) & "." & vbCrLf _
                & "Check your system - restart Unity?." & vbCrLf & vbCrLf _
                & x.ToString
        End Try
        Try
            wskReceive = New Net.Sockets.UdpClient(glUnityLocalNetPort)
        Catch x As Exception
            wskSend.Client.Shutdown(Net.Sockets.SocketShutdown.Both)
            wskSend.Close()
            wskSend = Nothing
            Return "Can't bind the local port " & TStr(glUnityLocalNetPort) & " for the responses from Unity." & vbCrLf _
                & "Check your system - there is another process using this port." & vbCrLf & vbCrLf _
                & x.ToString
        End Try
        ' establish connection
        wskReceive.BeginReceive(New AsyncCallback(AddressOf Output.wskResponse_DataArrival), wskReceive)

        ' establish connection
        For lX = 0 To 30 ' try 15 seconds long
            ' establish response channel
            ReDim varArgs(1)
            szAddr = "/Control/Response"
            varArgs(0) = "disconnect"
            Output.Send(szAddr, varArgs(0))
            ReDim varArgs(3)
            varArgs(0) = "connect"
            varArgs(1) = gszLocalNetAddr
            varArgs(2) = CInt(glUnityLocalNetPort)
            Output.Send(szAddr, varArgs(0), varArgs(1), varArgs(2))
            ' get version of player to check the connection
            Output.Send("/Control/Version")
            glPlayerSampleRate = -1
            Output.Send("/Control/SampleRate") ' response will be saved in wskResponse_DataArrival
            Proc.TimerStart(500)
            gblnCancel = False
            Do
                Windows.Forms.Application.DoEvents()
            Loop Until gblnTimeOut Or glPlayerSampleRate <> -1 Or gblnCancel
            Proc.TimerStop()
            If glPlayerSampleRate <> -1 Or gblnCancel Then Exit For
            frmMain.SetProgressbar(CInt(lX / 30 * 100))
        Next
        If glPlayerSampleRate = -1 Then
            'gblnOutputStable = False
            frmMain.SetStatus("Connection failed.")
            wskSend.Client.Shutdown(Net.Sockets.SocketShutdown.Both)
            wskSend.Close()
            wskSend = Nothing
            wskReceive.Close()
            wskReceive = Nothing
            Return "Connection to Unity Audio couldn't be established."
        End If
        frmMain.SetProgressbar(0)

        If gszYamiVersion <> Nothing Then
            frmMain.SetStatus("Unity Player Version: " & gszYamiVersion)
            STIM.Log("Unity Player Version," & gszYamiVersion)
        End If

        frmMain.SetStatus("Sampling Rate of Unity is " & TStr(glPlayerSampleRate) & " Hz")
        If glPlayerSampleRate <> glSamplingRate Then
            If MsgBox("The sampling rate of device differs from the audio sampling rate set in settings." & vbCrLf & "Settings: " & TStr(glSamplingRate) & " Hz" & vbCrLf & "YAMI: " & TStr(glPlayerSampleRate) & " Hz" & vbCrLf & vbCrLf & "This leak in consistency leads to pitch changes in audio signals." & vbCrLf & "Do you want to continue?", CType(MsgBoxStyle.Critical + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Microsoft.VisualBasic.MsgBoxStyle), "Connect to YAMI") = MsgBoxResult.No Then
                frmMain.SetStatus("User abort.")
                'gblnOutputStable = False
                wskSend.Client.Shutdown(Net.Sockets.SocketShutdown.Both)
                wskSend.Close()
                wskSend = Nothing
                wskReceive.Close()
                wskReceive = Nothing
                Return "Invalid sampling rate. Connection refused."
            End If
        End If
        
        Return ""

    End Function

    Public Function UnityOff() As String
        Dim varArgs() As Object
        Dim szAddr As String
        'Dim lX As Integer

        If gblnOutputStable Then
            frmMain.SetStatus("Disconnecting Unity - Please wait...")
            '' send PANIC
            'Output.Send("/Play/Stop/*")
            'Output.Send("/DAC/SetVol/*", CSng(0))
            'Output.Send("/DAC/SetAddStream/*", "set", "silence")
            '' tracker
            'If (gblnTrackerUse And glTrackerCOM > 0) And glTrackerMode = 1 Then
            '    Output.Send("/Tracker/SendData/0/Connection", "disconnect")
            '    Output.Send("/Tracker/SendData/1/Connection", "disconnect")
            'End If
            ' send disconnect
            ReDim varArgs(0)
            szAddr = "/Control/Response"
            varArgs(0) = "disconnect"
            Output.Send(szAddr, varArgs(0))
        End If
        ' disconnect connections
        If Not IsNothing(wskSend) Then
            If Not IsNothing(wskSend.Client) Then wskSend.Client.Shutdown(Net.Sockets.SocketShutdown.Both)
            wskSend.Close()
            wskSend = Nothing
        End If
        If Not IsNothing(wskReceive) Then
            If Not IsNothing(wskReceive.Client) Then wskReceive.Client.Shutdown(Net.Sockets.SocketShutdown.Both)
            Console.WriteLine("playeroff: shutdown done")
            wskReceive.Close()
            Console.WriteLine("playeroff: closed")
            'wskReceive = Nothing
        End If
        '' close pd
        'If CBool(LCase(gszPlayerNetAddr) = "localhost") And CBool(INIOptions.glPlayerFlags And PLAYERFLAGS.pfKillondisconnect) Then
        '    lX = Proc.CloseApplication("pd")
        '    Select Case lX
        '        Case -1
        '            frmMain.SetStatus("Error closing pd")
        '        Case 0
        '            frmMain.SetStatus("pd not found")
        '        Case 1
        '            frmMain.SetStatus("pd closed")
        '        Case 2
        '            frmMain.SetStatus("pd killed")
        '    End Select
        '    Proc.TimerStart(500)
        '    Do
        '        Windows.Forms.Application.DoEvents()
        '    Loop Until gblnTimeOut
        '    Proc.TimerStop()
        '    While FindProcess("pd.exe") Or FindProcess("pd.com")
        '        frmMain.SetStatus("Another pd process found:")
        '        lX = Proc.CloseApplication("pd")
        '        Select Case lX
        '            Case -1
        '                frmMain.SetStatus("Error closing pd")
        '            Case 0
        '                frmMain.SetStatus("pd not found")
        '            Case 1
        '                frmMain.SetStatus("pd closed")
        '            Case 2
        '                frmMain.SetStatus("pd killed")
        '        End Select
        '        Proc.TimerStart(500)
        '        Do
        '            Windows.Forms.Application.DoEvents()
        '        Loop Until gblnTimeOut
        '        Proc.TimerStop()
        '    End While
        'End If ' localhost?
        ''gblnOutputStable = False
        Return ""

    End Function

    Public Function PlayerOn() As String
        Dim varArgs() As Object
        Dim szAddr As String
        Dim dErr As Double
        Dim lX As Integer

        If LCase(gszPlayerNetAddr) = "localhost" Then
            ' pdPLAYER running?
            If Not FindProcess("pd.exe") And Not FindProcess("pd.com") Then
                ' set sampling
                frmMain.SetStatus("Starting pd...")
                szAddr = gszPlayerFileName
                szAddr = szAddr & " " & TStr(glSamplingRate)
                If CBool(gbAudioName) Then
                    szAddr = szAddr & " -1"
                Else
                    szAddr = szAddr & " " & TStr(glPlayerAudioDevice)
                End If

                szAddr = szAddr & " " & TStr(glPlayerChannels)
                szAddr = szAddr & " " & TStr(glPlayerMIDIOutDevice)
                szAddr = szAddr & " " & TStr(glPlayerMIDIInDevice)
                If CBool(INIOptions.glPlayerFlags And PLAYERFLAGS.pfASIO) Then szAddr = szAddr & " -asio" ' %6

                If CBool(gbAudioName) Then  'audio device NAME
                    szAddr = szAddr & " -audioaddoutdev """ & gszDACName & """" 'audio device name
                    If CBool(INIOptions.glPlayerFlags And PLAYERFLAGS.pfNoADC) Then ' no adc
                        szAddr = szAddr & " -noadc"
                    ElseIf gszADCName <> "" Then
                        szAddr = szAddr & " -audioaddindev """ & gszADCName & """" 'audio device name
                    End If

                Else                        'audio device INDEX
                    'szAddr = szAddr & " -audiooutdev " & TStr(glPlayerAudioDevice)
                    If CBool(INIOptions.glPlayerFlags And PLAYERFLAGS.pfNoADC) Then
                        szAddr = szAddr & " -noadc" ' %7
                    ElseIf glPlayerADCAudioDevice <> glPlayerAudioDevice Then
                        szAddr = szAddr & " -audioindev " & TStr(glPlayerADCAudioDevice) ' ADC device
                    End If

                End If

                If CBool(INIOptions.glPlayerFlags And PLAYERFLAGS.pfnogui) Then szAddr = szAddr & " -nogui" ' %8
                Console.WriteLine(szAddr)
                Try
                    dErr = Shell(szAddr)
                Catch
                End Try
                If dErr = 0 Then
                    frmMain.SetStatus("pd batch file not started.")
                    Return "Couldn't start the batch file." & vbCrLf & szAddr
                End If
                For lX = 0 To 2
                    TimerStart(300)
                    Do
                        Windows.Forms.Application.DoEvents()
                    Loop Until gblnTimeOut
                    TimerStop()
                    If FindProcess("pd.exe") Or FindProcess("pd.com") Then Exit For
                Next
                If lX = 3 Then
                    frmMain.SetStatus("pd not started.")
                    Return "Batch file started, but pd process couldn't be found." & vbCrLf & gszPlayerFileName
                End If
            Else
                frmMain.SetStatus("pd has been started already.")
            End If
            End If ' localhost?
        ' connect to UDP
        frmMain.SetStatus("Connecting to pd...")
        If Not IsNothing(wskSend) Then wskSend = Nothing
        If Not IsNothing(wskReceive) Then wskReceive = Nothing
        Try
            wskSend = New Net.Sockets.UdpClient()
            wskSend.Connect(gszPlayerNetAddr, glPlayerNetPort)
        Catch x As Exception
            Return "Output: Can't connect to the pd/YAMI host " & gszPlayerNetAddr & ", port " & TStr(glPlayerNetPort) & "." & vbCrLf _
                & "Check your system - restart pd?." & vbCrLf & vbCrLf _
                & x.ToString
        End Try
        Try
            wskReceive = New Net.Sockets.UdpClient(glLocalNetPort)
        Catch x As Exception
            wskSend.Client.Shutdown(Net.Sockets.SocketShutdown.Both)
            wskSend.Close()
            wskSend = Nothing
            Return "Can't bind the local port " & TStr(glLocalNetPort) & " for the responses from pd." & vbCrLf _
                & "Check your system - there is another process using this port." & vbCrLf & vbCrLf _
                & x.ToString
        End Try
        ' establish connection
        wskReceive.BeginReceive(New AsyncCallback(AddressOf Output.wskResponse_DataArrival), wskReceive)
        gszYamiVersion = Nothing
        ' establish connection
        For lX = 0 To 30 ' try 15 seconds long
            ' establish response channel
            ReDim varArgs(1)
            szAddr = "/Control/Response"
            varArgs(0) = "disconnect"
            Output.Send(szAddr, varArgs(0))
            ReDim varArgs(3)
            varArgs(0) = "connect"
            varArgs(1) = gszLocalNetAddr
            varArgs(2) = CInt(glLocalNetPort)
            Output.Send(szAddr, varArgs(0), varArgs(1), varArgs(2))
            ' get version of player to check the connection
            Output.Send("/Control/Version")
            glPlayerSampleRate = -1
            Output.Send("/Control/SampleRate") ' response will be saved in wskResponse_DataArrival
            Proc.TimerStart(500)
            gblnCancel = False
            Do
                Windows.Forms.Application.DoEvents()
            Loop Until gblnTimeOut Or glPlayerSampleRate <> -1 Or gblnCancel
            Proc.TimerStop()
            If glPlayerSampleRate <> -1 Or gblnCancel Then Exit For
            frmMain.SetProgressbar(CInt(lX / 30 * 100))
        Next
        If glPlayerSampleRate = -1 Then
            'gblnOutputStable = False
            frmMain.SetStatus("Connection failed.")
            wskSend.Client.Shutdown(Net.Sockets.SocketShutdown.Both)
            wskSend.Close()
            wskSend = Nothing
            wskReceive.Close()
            wskReceive = Nothing
            Return "Connection to YAMI couldn't be established."
        End If
        frmMain.SetProgressbar(0)

        If gszYamiVersion <> Nothing Then
            frmMain.SetStatus("YAMI Version: " & gszYamiVersion)
            STIM.Log("YAMI Version," & gszYamiVersion)
        End If


        frmMain.SetStatus("Sampling Rate of pd is " & TStr(glPlayerSampleRate) & " Hz")
        If glPlayerSampleRate <> glSamplingRate Then
            If MsgBox("The sampling rate of device differs from the audio sampling rate set in settings." & vbCrLf & "Settings: " & TStr(glSamplingRate) & " Hz" & vbCrLf & "YAMI: " & TStr(glPlayerSampleRate) & " Hz" & vbCrLf & vbCrLf & "This leak in consistency leads to pitch changes in audio signals." & vbCrLf & "Do you want to continue?", CType(MsgBoxStyle.Critical + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Microsoft.VisualBasic.MsgBoxStyle), "Connect to YAMI") = MsgBoxResult.No Then
                frmMain.SetStatus("User abort.")
                'gblnOutputStable = False
                wskSend.Client.Shutdown(Net.Sockets.SocketShutdown.Both)
                wskSend.Close()
                wskSend = Nothing
                wskReceive.Close()
                wskReceive = Nothing
                Return "Invalid sampling rate. Connection refused."
            End If
        End If
        ' set streams
        Output.Send("/DAC/SetStream/" & TStr(glPlayerHPLeft - 1), "set", "play0")
        Output.Send("/DAC/SetStream/" & TStr(glPlayerHPRight - 1), "set", "play1")
        Output.Send("/Play/SetFade", 0)     'the application's developer is responsible to use a different value in pd (send in Events: OnConnect or Stimulate) or MATLAB (stPar.lFadeIn)
        Output.Send("/Play/SetFadeOut", 0)  'the application's developer is responsible to use a different value in pd (send in Events: OnConnect or Stimulate) or MATLAB (stPar.lFadeOut)

        Output.Send("/DAC/SetVol/*", 0)
        ' connect synthesizer units to DAC's
        For lX = 0 To glPlayerChannels - 1
            Select Case glAudioDACAddStream(lX)
                Case 0
                    Output.Send("/DAC/SetAddStream/" & TStr(lX), "set", "silence")
                Case 1
                    Output.Send("/DAC/SetAddStream/" & TStr(lX), "set", "syn0")
                Case 2
                    Output.Send("/DAC/SetAddStream/" & TStr(lX), "set", "syn1")
            End Select
            glOutputPlay(lX) = False
        Next
        ' set synthesizer unit parameters
        frmMain.SetStatus("Setting synthesizer...")
        For lX = 0 To 1
            With gAudioSynth(lX)
                Output.Send("/Synth/SetLowCut/" & TStr(lX), CSng(.LowCut))
                Output.Send("/Synth/SetHighCut/" & TStr(lX), CSng(.HighCut))
                Output.Send("/Synth/SetVol/" & TStr(lX), CSng(.Vol + 100))
                Output.Send("/Synth/SetPar1/" & TStr(lX), CSng(.Par1))
                Select Case .Signal
                    Case 0
                        Output.Send("/Synth/SetSignal/" & TStr(lX), "nope")
                    Case 1
                        Output.Send("/Synth/SetSignal/" & TStr(lX), "pink")
                    Case 2
                        Output.Send("/Synth/SetSignal/" & TStr(lX), "white")
                    Case 3
                        Output.Send("/Synth/SetSignal/" & TStr(lX), "cosine")
                    Case 4
                        Output.Send("/Synth/SetSignal/" & TStr(lX), "lp4white")
                    Case 5
                        Output.Send("/Synth/SetSignal/" & TStr(lX), "lp16white")
                End Select
            End With
        Next

        'gblnOutputStable = True
        Return ""

    End Function

    Public Function PlayerOff() As String
        Dim varArgs() As Object
        Dim szAddr As String
        Dim lX As Integer

        If gblnOutputStable Then
            frmMain.SetStatus("Disconnecting YAMI - Please wait...")
            ' send PANIC
            Output.Send("/Play/Stop/*")
            Output.Send("/DAC/SetVol/*", CSng(0))
            Output.Send("/DAC/SetAddStream/*", "set", "silence")
            ' tracker
            If (gblnTrackerUse And glTrackerCOM > 0) And glTrackerMode = 1 Then
                Output.Send("/Tracker/SendData/0/Connection", "disconnect")
                Output.Send("/Tracker/SendData/1/Connection", "disconnect")
            End If
            ' send disconnect
            ReDim varArgs(0)
            szAddr = "/Control/Response"
            varArgs(0) = "disconnect"
            Output.Send(szAddr, varArgs(0))
        End If
        ' disconnect connections
        If Not IsNothing(wskSend) Then
            If Not IsNothing(wskSend.Client) Then wskSend.Client.Shutdown(Net.Sockets.SocketShutdown.Both)
            wskSend.Close()
            wskSend = Nothing
        End If
        If Not IsNothing(wskReceive) Then
            If Not IsNothing(wskReceive.Client) Then wskReceive.Client.Shutdown(Net.Sockets.SocketShutdown.Both)
            Console.WriteLine("playeroff: shutdown done")
            wskReceive.Close()
            Console.WriteLine("playeroff: closed")
            'wskReceive = Nothing
        End If
        ' close pd
        If CBool(LCase(gszPlayerNetAddr) = "localhost") And CBool(INIOptions.glPlayerFlags And PLAYERFLAGS.pfKillondisconnect) Then
            lX = Proc.CloseApplication("pd")
            Select Case lX
                Case -1
                    frmMain.SetStatus("Error closing pd")
                Case 0
                    frmMain.SetStatus("pd not found")
                Case 1
                    frmMain.SetStatus("pd closed")
                Case 2
                    frmMain.SetStatus("pd killed")
            End Select
            Proc.TimerStart(500)
            Do
                Windows.Forms.Application.DoEvents()
            Loop Until gblnTimeOut
            Proc.TimerStop()
            While FindProcess("pd.exe") Or FindProcess("pd.com")
                frmMain.SetStatus("Another pd process found:")
                lX = Proc.CloseApplication("pd")
                Select Case lX
                    Case -1
                        frmMain.SetStatus("Error closing pd")
                    Case 0
                        frmMain.SetStatus("pd not found")
                    Case 1
                        frmMain.SetStatus("pd closed")
                    Case 2
                        frmMain.SetStatus("pd killed")
                End Select
                Proc.TimerStart(500)
                Do
                    Windows.Forms.Application.DoEvents()
                Loop Until gblnTimeOut
                Proc.TimerStop()
            End While
        End If ' localhost?
        'gblnOutputStable = False
        Return ""

    End Function

    ''' <summary>
    ''' Load Stimulation Files to YAMI or RIBs
    ''' </summary>
    ''' <param name="szLeft">File name of the left stimulus. The File name can contain an absolute path beginning with "\\" or a drive. The work directory will be used in other cases. If no extension is given, it will be appended depending on stimulation mode.</param>
    ''' <param name="szRight">File name of an optional right stimulus. The File name can contain an absolute path beginning with "\\" or a drive. The work directory will be used in other cases. If no extension is given, it will be appended depending on stimulation mode.</param>
    ''' <param name="lChLeft">Audio channel through which the stimulus szLeft will be played. If ommited or set to zero, the left channel for headphones presentation (Options/Audio) will be used.</param>
    ''' <param name="lChRight">Audio channel through which the stimulus szRight will be played. If ommited or set to zero, the right channel for headphones presentation (Options/Audio) will be used.</param>
    ''' <returns>Error message or empty if no error ocured.</returns>
    ''' <remarks>Using lChLeft and/or lChRight the left/right stimulus will assigned to the given DAC channel.
    ''' This assignment will be not removed, causing playing via multiple channels on repeated calls using different lChLeft or lChRight.
    ''' To avoid this problem, reset existing assignments from all channels available using for example code like this:
    '''<code lang="VB">
    '''Dim lX as Long
    '''For lX = 0 To glPlayerChannels - 1
    '''  Output.Send "/DAC/SetStream/" + TStr(lX), "set", "silence"
    '''Next
    '''</code></remarks>
    Public Function LoadStimulationFile(ByVal szLeft As String, Optional ByVal szRight As String = "", _
                Optional ByVal lChLeft As Integer = 0, Optional ByVal lChRight As Integer = 0) As String
        Dim varArgs(1) As Object
        Dim szErr As String
        Dim szL, szR As String

        szL = szLeft
        szR = szRight
        Select Case STIM.GenerationMode
            Case STIM.GENMODE.genElectricalRIB
                If Right(szL, Len(STIMFILEEXT_RIB)) <> STIMFILEEXT_RIB Then szL = szL & STIMFILEEXT_RIB
                If Len(szR) = 0 Then
                    szErr = RIB.LoadStimulationFile(szL)
                Else
                    If Right(szR, Len(STIMFILEEXT_RIB)) <> STIMFILEEXT_RIB Then szR = szR & STIMFILEEXT_RIB
                    szErr = RIB.LoadStimulationFile(szL, szR)
                End If
                If Len(szErr) <> 0 Then Return szErr Else Return ""

            Case STIM.GENMODE.genElectricalRIB2
                If Right(szL, Len(STIMFILEEXT_RIB2)) <> STIMFILEEXT_RIB2 Then szL = szL & STIMFILEEXT_RIB2 ' add stimfile-extension if missing (left ear)
                If Len(szR) = 0 Then
                    szErr = RIB2.LoadStimulationFile(szL)
                Else
                    If Right(szR, Len(STIMFILEEXT_RIB2)) <> STIMFILEEXT_RIB2 Then szR = szR & STIMFILEEXT_RIB2
                    szErr = RIB2.LoadStimulationFile(szL, szR)
                End If
                If Len(szErr) <> 0 Then Return szErr Else Return ""

            Case STIM.GENMODE.genElectricalNIC
                szErr = STIM.Matlab("clear output;")
                If Len(szErr) > 0 Then Return szErr
                If Right(szL, Len(STIMFILEEXT_NIC)) <> STIMFILEEXT_NIC Then szL = szL & STIMFILEEXT_NIC
                szErr = STIM.Matlab("output{1}=load('" & szL & "','-mat');")
                If Len(szErr) > 0 Then Return szErr
                If Len(szR) > 0 Then
                    If Right(szR, Len(STIMFILEEXT_NIC)) <> STIMFILEEXT_NIC Then szR = szR & STIMFILEEXT_NIC
                    szErr = STIM.Matlab("output{2}=load('" & szR & "','-mat');")
                    If Len(szErr) > 0 Then Return szErr
                End If
                szErr = STIM.Matlab("NIC_Stimulate(fitting, output);")
                If Len(szErr) > 0 Then Return szErr

                If Len(szErr) <> 0 Then Return szErr Else Return ""
            Case STIM.GENMODE.genAcoustical, GENMODE.genVocoder, GENMODE.genAcousticalUnity
                If Right(szL, Len(STIMFILEEXT_ACOUSTIC)) <> STIMFILEEXT_ACOUSTIC Then szL = szL & STIMFILEEXT_ACOUSTIC
                If Mid(szL, 1, 2) <> "\\" And InStr(1, szL, ":") = 0 Then szL = RIB.RootDirectory & "\" & szL
                If Dir(szL) = "" Then
                    Return "Stimulation file not found:" & vbCrLf & szL
                End If
                If InStr(LCase(szL), "ä") > 0 Or InStr(LCase(szL), "ü") > 0 Or InStr(LCase(szL), "ö") > 0 Or InStr(szL, "ß") > 0 Then
                    Return "Stimulation file contains special characters (ä, ö, ü, ß) that are not supported by pd:" & vbCrLf & szL
                End If
                varArgs(0) = "open"
                varArgs(1) = szL
                varArgs(1) = Replace(varArgs(1).ToString, "\", "/")
                If STIM.GenerationMode = GENMODE.genAcousticalUnity Then
                    If lChLeft = 0 Then lChLeft = 1
                Else
                    If lChLeft = 0 Then lChLeft = glPlayerHPLeft
                End If

                Output.Send("/DAC/SetStream/" & TStr(lChLeft - 1), "set", "play0")
                Output.Send("/Play/OpenWAV/0", varArgs(0), varArgs(1))
                'glOutputPlay = 1 ' channel 0 will play
                glOutputPlay(0) = True ' channel 0 will play
                If Len(szR) <> 0 Then
                    If Right(szR, Len(STIMFILEEXT_ACOUSTIC)) <> STIMFILEEXT_ACOUSTIC Then szR = szR & STIMFILEEXT_ACOUSTIC
                    If Mid(szR, 1, 2) <> "\\" And InStr(1, szR, ":") = 0 Then szR = RIB.RootDirectory & "\" & szR
                    If Dir(szR) = "" Then
                        Return "Stimulation file not found:" & vbCrLf & szR
                    End If
                    If InStr(LCase(szR), "ä") > 0 Or InStr(LCase(szR), "ü") > 0 Or InStr(LCase(szR), "ö") > 0 Or InStr(szR, "ß") > 0 Then
                        Return "Stimulation file contains special characters (ä, ö, ü, ß) that are not supported by pd:" & vbCrLf & szR
                    End If
                    varArgs(0) = "open"
                    varArgs(1) = szR
                    varArgs(1) = Replace(varArgs(1).ToString, "\", "/")
                    If lChRight = 0 Then lChRight = glPlayerHPRight
                    Output.Send("/DAC/SetStream/" & TStr(lChRight - 1), "set", "play1")
                    Output.Send("/Play/OpenWAV/1", varArgs(0), varArgs(1))
                    'glOutputPlay = glOutputPlay Or 2 ' channel 1 will play too
                    glOutputPlay(1) = True ' channel 1 will play too
                End If
                Dir("") ' release directory locked by previous Dir() - VB bug!
                Return ""
            Case Else
                Return ""
        End Select

    End Function
    ''' <summary>
    ''' Load Data Stimulation Files to YAMI
    ''' </summary>
    ''' <param name="szFnData">File name of the data stimulus. The File name can contain an absolute path beginning with "\\" or a drive. The work directory will be used in other cases. If no extension is given, it will be appended depending on stimulation mode.</param>
    ''' <returns>Error message or empty if no error ocured.</returns>
    Function LoadDataStimulus(szFnData As String) As String
        Dim varArgs(1) As Object
        Dim szFnDataFull As String = szFnData

        If Right(szFnDataFull, Len(STIMFILEEXT_ACOUSTIC)) <> STIMFILEEXT_ACOUSTIC Then szFnDataFull = szFnDataFull & STIMFILEEXT_ACOUSTIC
        If Mid(szFnDataFull, 1, 2) <> "\\" And InStr(1, szFnDataFull, ":") = 0 Then szFnDataFull = RIB.RootDirectory & "\" & szFnDataFull
        If Dir(szFnDataFull) = "" Then
            Return "Stimulation file not found:" & vbCrLf & szFnDataFull
        End If
        If InStr(LCase(szFnDataFull), "ä") > 0 Or InStr(LCase(szFnDataFull), "ü") > 0 Or InStr(LCase(szFnDataFull), "ö") > 0 Or InStr(szFnDataFull, "ß") > 0 Then
            Return "Stimulation file contains special characters (ä, ö, ü, ß) that are not supported by pd:" & vbCrLf & szFnDataFull
        End If
        varArgs(0) = "open"
        varArgs(1) = szFnDataFull
        varArgs(1) = Replace(varArgs(1).ToString, "\", "/")

        Output.Send("/DAC/SetVol/" & TStr(glDataChannel - 1), 100)
        Output.Send("/DAC/SetStream/" & TStr(glDataChannel - 1), "set", "play" & TStr(glDataChannel - 1))
        Output.Send("/Play/OpenWAV/" & TStr(glDataChannel - 1), varArgs(0), varArgs(1))
        'glOutputPlay = 1 ' channel 0 will play
        glOutputPlay(glDataChannel - 1) = True ' data channel will play

        Return ""
    End Function

    ''' <summary>
    ''' Load Trigger Stimulation File to YAMI
    ''' </summary>
    ''' <returns>Error message or empty if no error ocured.</returns>
    Function LoadTriggerStimulus() As String

        Dim varArgs(1) As Object
        Dim szFnTriggerFull As String = mszFnTrigger

        If Right(szFnTriggerFull, Len(STIMFILEEXT_ACOUSTIC)) <> STIMFILEEXT_ACOUSTIC Then szFnTriggerFull = szFnTriggerFull & STIMFILEEXT_ACOUSTIC
        If Mid(szFnTriggerFull, 1, 2) <> "\\" And InStr(1, szFnTriggerFull, ":") = 0 Then szFnTriggerFull = RIB.RootDirectory & "\" & szFnTriggerFull
        If Dir(szFnTriggerFull) = "" Then
            Return "Stimulation file not found:" & vbCrLf & szFnTriggerFull
        End If
        If InStr(LCase(szFnTriggerFull), "ä") > 0 Or InStr(LCase(szFnTriggerFull), "ü") > 0 Or InStr(LCase(szFnTriggerFull), "ö") > 0 Or InStr(szFnTriggerFull, "ß") > 0 Then
            Return "Stimulation file contains special characters (ä, ö, ü, ß) that are not supported by pd:" & vbCrLf & szFnTriggerFull
        End If
        varArgs(0) = "open"
        varArgs(1) = szFnTriggerFull
        varArgs(1) = Replace(varArgs(1).ToString, "\", "/")

        Output.Send("/DAC/SetVol/" & TStr(glTriggerChannel - 1), 100)
        Output.Send("/DAC/SetStream/" & TStr(glTriggerChannel - 1), "set", "play" & TStr(glTriggerChannel - 1))
        Output.Send("/Play/OpenWAV/" & TStr(glTriggerChannel - 1), varArgs(0), varArgs(1))
        'glOutputPlay = 1 ' channel 0 will play
        glOutputPlay(glTriggerChannel - 1) = True ' trigger channel will play

        Return ""
    End Function

    ''' <summary>
    ''' Create Trigger Stimulation File
    ''' </summary>
    ''' <returns>Error message or empty if no error ocured.</returns>
    Function CreateTriggerSignal() As String
        Dim szErr As String = Nothing

        mszFnTrigger = STIM.AppendExtension(glExpType & "_trigger")
        'If STIM.CheckStimulationFile(szFnData) Then 'data channel file existing?
        '    frmMain.SetStatus("Existing (Item " & TStr(lRow + 1) & " Data): " & szFnData)
        'Else 'create
        'szerr = NewTriggerStimulus(mszFnTrigger)

        gstLeft.szStimFile = mszFnTrigger
        szErr = STIM.NewStimulus(gstLeft)
        If Len(szErr) <> 0 Then GoTo SubError

        szErr = STIM.MatlabStimulus("FW_Trigger") ' Matlab Part
        'If Len(szErr) <> 0 Then GoTo SubError
        If InStr(LCase(szErr), "error") > 0 Then GoTo SubError Else Debug.Print(szErr) : szErr = Nothing

        szErr = STIM.AssembleStimulus(gblnShowStimulus) ' Assemble (write file)
        If Len(szErr) <> 0 Then GoTo SubError
        STIM.CloseStimulus() ' Close

        If InStr(LCase(szErr), "error") > 0 Then GoTo SubError Else Debug.Print(szErr) : szErr = Nothing
        frmMain.SetStatus("Created trigger file: " & mszFnTrigger)
        'End If

SubEnd:
        Return Nothing
SubError:
        Return szerr

    End Function


    ''' <summary>
    ''' Prepare Stimulation Files for YAMI or RIBs.
    ''' </summary>
    ''' <param name="szFile">File Name.</param>
    ''' <returns>New File Name.</returns>
    ''' <remarks>Creates full file name including directory and checks for existency
    ''' returns the new file name in szFile.</remarks>
    Public Function PrepareStimulationFile(ByRef szFile As String) As String
        Dim szX As String

        szX = szFile
        Select Case STIM.GenerationMode
            Case STIM.GENMODE.genElectricalRIB
                If Right(szX, Len(STIMFILEEXT_RIB)) <> STIMFILEEXT_RIB Then szX = szX & STIMFILEEXT_RIB
            Case STIM.GENMODE.genElectricalRIB2
                If Right(szX, Len(STIMFILEEXT_RIB2)) <> STIMFILEEXT_RIB2 Then szX = szX & STIMFILEEXT_RIB2
            Case STIM.GENMODE.genAcoustical, STIM.GENMODE.genVocoder, STIM.GENMODE.genAcousticalUnity
                If Right(szX, Len(STIMFILEEXT_ACOUSTIC)) <> STIMFILEEXT_ACOUSTIC Then szX = szX & STIMFILEEXT_ACOUSTIC
                szX = RIB.RootDirectory & "\" & szX
                If Dir(szX) = "" Then Return "Stimulation file not found:" & vbCrLf & szX
                Dir("") ' release directory locked by previous Dir() - VB bug!
                szX = Replace(szX, "\", "/")
        End Select
        szFile = szX
        Return ""

    End Function

    ''' <summary>
    ''' Start Stimulation.
    ''' </summary>
    ''' <returns>Error message or empty if no error ocured.</returns>
    ''' <remarks></remarks>
    Public Function StartStimulation() As String
        Dim szErr As String = Nothing
        If glTriggerChannel > 0 And gblnUseTriggerChannel = True Then szErr = LoadTriggerStimulus()
        If szErr <> Nothing Then Return szErr

        Select Case STIM.GenerationMode
            Case STIM.GENMODE.genElectricalRIB
                frmMain.sbStatusBar.Items.Item(STB_LEFT).BackColor = Color.Red
                frmMain.sbStatusBar.Items.Item(STB_RIGHT).BackColor = Color.Red
                szErr = RIB.StartStimulation
                If Len(szErr) <> 0 Then Return szErr Else Return ""
            Case STIM.GENMODE.genElectricalRIB2
                frmMain.sbStatusBar.Items.Item(STB_LEFT).BackColor = Color.Red
                frmMain.sbStatusBar.Items.Item(STB_RIGHT).BackColor = Color.Red
                szErr = RIB2.StartStimulation
                If Len(szErr) <> 0 Then Return szErr Else Return ""
            Case STIM.GENMODE.genAcoustical, GENMODE.genVocoder, GENMODE.genAcousticalUnity
                Return Start("/Play/Start/*")
            Case Else
                Return ""
        End Select
    End Function

    ''' <summary>
    ''' Start stimulation with any command.
    ''' </summary>
    ''' <param name="szCmd">OSC Command to YAMI.</param>
    ''' <returns>Nothing will be returned at the moment.</returns>
    ''' <remarks></remarks>
    Public Function Start(ByVal szCmd As String) As String

        'If STIM.GenerationMode = STIM.GENMODE.genElectricalRIB Then Start = "Not for electrical stimulation - use StartStimulation() instead" : Exit Function
        If (STIM.GenerationMode <> STIM.GENMODE.genAcoustical And _
            STIM.GenerationMode <> STIM.GENMODE.genVocoder And _
            STIM.GenerationMode <> STIM.GENMODE.genAcousticalUnity) Then Start = "Not for electrical stimulation - use StartStimulation() instead" : Exit Function
        frmMain.sbStatusBar.Items.Item(STB_LEFT).BackColor = Color.Red
        frmMain.sbStatusBar.Items.Item(STB_RIGHT).BackColor = Color.Red
        Output.Send(szCmd)
        Return ""

    End Function

    ''' <summary>
    ''' Get Stimulus Duration in ms.
    ''' </summary>
    ''' <param name="szFile">File name.</param>
    ''' <param name="lSR">Sampling rate.</param>
    ''' <returns>Duration in ms. -1 if an error ocured.</returns>
    ''' <remarks></remarks>
    Public Function GetStimulusDuration(ByVal szFile As String, Optional ByRef lSR As Integer = Nothing) As Integer
        Dim dur(0, 0) As Double
        Dim szErr As String

        If Not gblnUseMATLAB Or Not gblnOutputStable Then szErr = "MATLAB not available" : GoTo SubError

        ' find out file length to get Time Out
        szErr = STIM.Matlab("[stimulusDuration,stimulusSamplingRate] = FW_GetStimulusDuration('" & szFile & "');")
        If Len(szErr) <> 0 Then GoTo SubError
        szErr = STIM.MatlabGetRealMatrix2("stimulusDuration", dur)
        lSR = CInt(STIM.Matlab("disp(stimulusSamplingRate);"))
        If Len(szErr) <> 0 Then GoTo SubError
        Return CInt(dur(0, 0))
SubError:
        MsgBox(szErr, MsgBoxStyle.Critical, "GetStimulusDuration")
        Return -1
    End Function

    ''' <summary>
    ''' Wait until the output device gets ready.
    ''' </summary>
    ''' <param name="lTimeOut">Time Out in ms.</param>
    ''' <param name="lSleepInt">If given, the application thread will be halted for the duration of lSleepInt (in ms) to save CPU load.</param>
    ''' <returns>Empty if no error ocured</returns>
    ''' <remarks></remarks>
    Public Function WaitForReady(ByVal lTimeOut As Integer, Optional ByVal lSleepInt As Integer = 0) As String
        Dim szErr As String
        Dim curToc, curTic As Long
        Dim lTO As Integer
        WaitForReady = ""
        lTO = lTimeOut
        If lTO < 30 Then lTO = 30
        Select Case STIM.GenerationMode
            Case STIM.GENMODE.genElectricalRIB
                szErr = RIB.WaitForReady(lTO)
                frmMain.sbStatusBar.Items.Item(STB_LEFT).BackColor = Drawing.SystemColors.Control
                frmMain.sbStatusBar.Items.Item(STB_RIGHT).BackColor = Drawing.SystemColors.Control
                Return szErr
            Case STIM.GENMODE.genElectricalNIC
                Return ""
            Case STIM.GENMODE.genElectricalRIB2
                szErr = RIB2.WaitForReady(lTO)
                frmMain.sbStatusBar.Items.Item(STB_LEFT).BackColor = Drawing.SystemColors.Control
                frmMain.sbStatusBar.Items.Item(STB_RIGHT).BackColor = Drawing.SystemColors.Control
                Return szErr
            Case STIM.GENMODE.genAcoustical, GENMODE.genVocoder, GENMODE.genAcousticalUnity
                If gblnDoNotConnectToDevice Then Return ""
                gblnTimeOut = False
                QueryPerformanceCounter(curTic)
                curTic = curTic + CLng(lTO) * gcurHPFrequency \ 1000
                Windows.Forms.Application.DoEvents()
                If (lSleepInt > 100) And ((INIOptions.glPlayerFlags And PLAYERFLAGS.pfFreezeOnStimulation) <> 0) Then Sleep(lSleepInt)
                Do
                    Windows.Forms.Application.DoEvents()
                    QueryPerformanceCounter(curToc)
                Loop Until ((AllStoppedPlaying(glOutputPlay) = True) And (glOutputRecord = 0)) Or (curToc > curTic) Or gblnCancel
                'Loop Until ((glOutputPlay = 0) And (glOutputRecord = 0)) Or (curToc > curTic) Or gblnCancel

                If gblnCancel Then
                    'WaitForReady = "Canceled"
                ElseIf AllStoppedPlaying(glOutputPlay) = False Or glOutputRecord <> 0 Then
                    'ElseIf glOutputPlay <> 0 Or glOutputRecord <> 0 Then
                    ' not all channels were stopped -> time out
                    If MsgBox("Time Out occured after " & TStr(lTO) & "ms." & vbCrLf & "Do you want to ignore it and continue experiment?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), "Time Out") = MsgBoxResult.No Then
                        Return "Time Out"
                    End If
                    gblnTimeOut = False
                End If
                frmMain.sbStatusBar.Items.Item(STB_LEFT).Image = Nothing
                frmMain.sbStatusBar.Items.Item(STB_RIGHT).Image = Nothing
        End Select

    End Function

    Private Function AllStoppedPlaying(ba As BitArray) As Boolean
        For lX As Integer = 0 To ba.Length - 1
            If ba(lX) = True Then Return False ' at least one channel is still playing (according to pd)
        Next
        Return True ' no channels playing
    End Function
End Module