'Imports System.Runtime.InteropServices
'Imports System.Threading
Option Strict On
Option Explicit On
Imports System.Runtime.InteropServices
Imports System.Threading
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
''' FrameWork - Turntable support.
''' </summary>
''' <remarks></remarks>
''' 


Module Turntable

    Public glTTAddr As Short

    Public gsngTTAngle As Double ' Turntable angle to work with, includes position and mod offsets - the only important value for the user!
    Public gsngTTActualAngle As Double ' Actual turntable angle, value given by the turntable. This value depends on where the turntable was turned on.
    Public gsngTT4AModOffset As Double ' offset created with modulo operations (a multiple of 360)
    'Public gsngTT4AOffset As Double        defined and stored in options !    (Four Audio)
    'Public gsngTTOffset As Double        defined and stored in options !   (Outline)

    Public gsngTTReqAngle As Double ' requested angle (for rotations)
    Public gblnTTInitialized As Boolean ' turntable resetted?
    Public gszTTError As String
    Public gblnTTHideUI As Boolean
    Private mlDir As Integer
    Private mlStep As Double

    ' Four Audio
    Public glTTStatus As Integer = 1 ' undefined

    ' Imperial College turntable
    Private ttSend As Net.Sockets.UdpClient
    Private ttAddress As String = "192.168.0.255"
    Private ttPort As Integer = 6000
    Public ttSpeed As Double = 1
    Private ttMoving As Boolean = False

    <DllImport("ELFANT-V0.9.7.dll", CallingConvention:=CallingConvention.StdCall)> _
    Private Function initLibrary(ByRef lpNControls As Integer) As Integer
    End Function

    <DllImport("ELFANT-V0.9.7.dll", CallingConvention:=CallingConvention.StdCall)> _
    Private Function moveControlByStepInDirectionNonBlocking(id As Integer, lStep As Single, eDir As Integer) As Integer
    End Function

    <DllImport("ELFANT-V0.9.7.dll", CallingConvention:=CallingConvention.StdCall)> _
    Private Function getControlPosition(id As Integer, ByRef pos As Double) As Integer
    End Function

    <DllImport("ELFANT-V0.9.7.dll", CallingConvention:=CallingConvention.StdCall)> _
    Private Function isControlMoving(id As Integer, ByRef lpIsMoving As Integer) As Integer
    End Function

    <DllImport("ELFANT-V0.9.7.dll", CallingConvention:=CallingConvention.StdCall)> _
    Private Function pullBrakeAtControl(id As Integer) As Integer
    End Function

    <DllImport("ELFANT-V0.9.7.dll", CallingConvention:=CallingConvention.StdCall)> _
    Private Function setControlPositionToZero(id As Integer) As Long
    End Function

    <DllImport("ELFANT-V0.9.7.dll", CallingConvention:=CallingConvention.StdCall)> _
    Private Function emergencyStop(id As Integer) As Integer
    End Function


    'Public Declare Sub PortOut Lib "io.dll" (ByVal Port As Short, ByVal Data As Byte)
    'Public Declare Function PortIn Lib "io.dll" (ByVal Port As Short) As Byte
    'Private Declare Function IsInpOutDriverOpen_x64 Lib "io.dll" () As Integer
    <DllImport("InpOut32.dll", CharSet:=CharSet.Auto, EntryPoint:="Inp32")> _
    Function Inp32(ByVal PortAddress As Short) As Byte
    End Function

    <DllImport("InpOut32.dll", CharSet:=CharSet.Auto, EntryPoint:="Out32")> _
    Sub Out32(ByVal PortAddress As Short, ByVal Data As Short)
    End Sub

    <DllImport("InpOut32.dll", CharSet:=CharSet.Auto, EntryPoint:="IsInpOutDriverOpen")> _
    Function IsInpOutDriverOpen() As UInt32
    End Function


    '<DllImport("InpOutx64.dll", CharSet:=CharSet.Auto, EntryPoint:="Inp32")> _
    'Function Inp32_x64(ByVal PortAddress As Short) As Short
    'End Function

    '<DllImport("InpOutx64.dll", CharSet:=CharSet.Auto, EntryPoint:="Out32")> _
    'Sub Out32_x64(ByVal PortAddress As Short, ByVal Data As Short)
    'End Sub

    '<DllImport("InpOutx64.dll", CharSet:=CharSet.Auto, EntryPoint:="IsInpOutDriverOpen")> _
    'Function IsInpOutDriverOpen_x64() As UInt32
    'End Function

    ''' <summary>
    ''' Send a message to LTP port.
    ''' </summary>
    ''' <param name="Port">Port number.</param>
    ''' <param name="Data">Message.</param>
    ''' <remarks></remarks>
    Public Function PortOut(ByVal Port As Short, ByVal Data As Short) As String
        Try
            Out32(Port, Data)
        Catch
            Return "Unable to send a command to the turntable"
        End Try
        Return ""

    End Function

    ''' <summary>
    ''' Get current LTP port status.
    ''' </summary>
    ''' <param name="Port">Port number.</param>
    ''' <returns>Response of LTP Port.</returns>
    ''' <remarks></remarks>
    Public Function PortIn(ByVal Port As Short) As Byte

        Return Inp32(CShort(Port + 1))

    End Function

    Public Function PullBrake(Optional lID As Integer = 1) As String

        Dim szErr As String = Nothing

        If glTTMode <> 1 Then Return "Turntable mode not supported."
        If gblnTTInitialized = False Then Return "Turntable not initialized."

        Dim lOutput As Integer = pullBrakeAtControl(lID)
        If lOutput <> 0 Then szErr = "Turntable error code: " & TStr(lOutput)

        Return szErr

    End Function
    Public Function Init(Optional bForce As Boolean = False, Optional lID As Integer = 1) As String

        Dim lTTMode As Integer = glTTMode
        If bForce = True Then lTTMode = 1 ' force only Four Audio ANT

        Select Case lTTMode
            Case 0 ' no turntable
                Return "no turntable available"
            Case 1 ' Four Audio ANT
                Dim szErr As String

                If glTTStatus <> 0 Or bForce = True Then
                    frmMain.SetStatus("Initialize turntable... Please wait!")
                    Try
                        glTTStatus = initLibrary(lID)
                    Catch
                        szErr = "Init Library: Error, Four Audio turntable library cannot be initialized. Maybe library files are not available." : GoTo SubError
                    End Try
                End If

                Select Case glTTStatus
                    Case 0
                        'no error
                        'Return "Init Library: Completed successfully."
                        gblnTTInitialized = True
                    Case -1
                        szErr = "Init Library: Error, no controls found." : GoTo SubError
                    Case -2
                        szErr = "Init Library: Error, control ID invalid." : GoTo SubError
                    Case -3
                        szErr = "Init Library: Error, communication error." : GoTo SubError
                    Case -4
                        szErr = "Init Library: Error, control init failed." : GoTo SubError
                End Select
                Return ""
SubError:
                frmMain.SetStatus(szErr)
                Return szErr

            Case 2 ' Outline ST2
                Dim nResult As UInt32

                Try
                    nResult = IsInpOutDriverOpen()
                Catch
                    Return "Unable to open IO driver (turntable)"
                End Try

                If nResult = 0 Then
                    Return "Unable to open IO driver (turntable)"
                End If

                Select Case glTTLPT
                    Case 0 ' deactivated
                        glTTAddr = -1
                        gblnTTInitialized = False
                        Return ""
                    Case 1 ' LPT1
                        glTTAddr = &H378S
                    Case 2 ' LPT2
                        glTTAddr = &H278S
                    Case Else
                        glTTAddr = -1
                        gblnTTInitialized = False
                        Return "Invalid LPT number."
                End Select

                Dim szErr As String = PortOut(glTTAddr, 0)
                If szErr <> "" Then Return szErr

                gblnTTInitialized = False
                Return ""

            Case 3 ' Custom turntable Imperial College (work in progress)

                ' connect to UDP
                frmMain.SetStatus("Connecting to Turntable at 192.168.0.255:6000...")
                If Not IsNothing(ttSend) Then ttSend = Nothing
                Try
                    ttSend = New Net.Sockets.UdpClient()
                    ttSend.Connect(ttAddress, ttPort)
                Catch x As Exception
                    Return "Output: Can't connect to the turntable " & ttAddress & ", port " & TStr(ttPort) & "." & vbCrLf
                End Try

                'Dim bytBuf() As Byte = OSC.PreparePacket(szAddr, varArgs)
                'Try
                '    wskSend.Send(bytBuf, bytBuf.Length)
                'Catch x As Exception
                'Return x.ToString
                'End Try

                Return ""

            Case Else
                Return "Turntable mode not supported"
        End Select

    End Function

    Public Function Show() As String
        Dim szErr As String

        Select Case glTTMode
            Case 1 'Four Audio ANT
                szErr = Turntable.Init
                If Len(szErr) > 0 Then Return szErr

                frmMain.SetStatus("Turntable Four Audio ANT activated")

            Case 2 'Outline ST2
                If glTTLPT < 1 Then Return ""
                If glTTAddr < 1 Then
                    'Return "Turntable not initialized or deactivated."
                    szErr = Turntable.Init
                    If Len(szErr) > 0 Then Return szErr
                    frmMain.SetStatus("Turntable Outline ST2 activated")
                End If

            Case 3 ' Imperial College custom tt
                szErr = Turntable.Init
                If Len(szErr) > 0 Then Return szErr
                frmMain.SetStatus("Imperial College Custom Turntable activated")

        End Select

        gsngTTReqAngle = -1
        gblnTTHideUI = False
        gszTTError = ""
        frmTurntable.ShowDialog()
        frmTurntable.Dispose()
        Return ""

    End Function

    Public Function EmergencyStop() As Integer

        ' returns...
        '   0: successful
        '  -1: dll library not available
        '  other values: error

        Dim lOutput As Integer = -1

        Select Case glTTMode

            Case 1
                Try
                    lOutput = emergencyStop(1)
                Catch

                End Try

            Case 3
                ' prepare packet
                Dim bytBuf() As Byte = OSC.PreparePacket("/Stop", {CInt(1)})
                ' send packet
                Try
                    ttSend.Send(bytBuf, bytBuf.Length)
                Catch

                End Try
                ttMoving = False
                gsngTTAngle = -1
                gblnTTInitialized = False
                Return 0

        End Select

        Return lOutput

    End Function

    Public Function SetPositionToZero(Optional lID As Integer = 1) As Long

        Dim lOutput As Long = setControlPositionToZero(lID)
        Return lOutput

    End Function

    ''' <summary>
    ''' Get current turntable position in degrees azimuth, including offsets if bActualAngle = False (default).
    ''' </summary>
    ''' <returns>Degrees azimuth</returns>
    ''' <remarks></remarks>
    Public Function GetAngle(Optional bActualAngle As Boolean = False, Optional ByRef szErr As String = Nothing,Optional lID As Integer=1) As Double

        'GetAngle = -1

        Select Case glTTMode
            Case 1

                Dim lOutput As Double = getControlPosition(lID, gsngTTActualAngle) 'actual turntable angle, given by god and the hardware manufacturer
                If lOutput <> 0 Then szErr = "Turntable error code: " & TStr(lOutput) : Return -1

                ' range adaptions
                gsngTTAngle = ((gsngTTActualAngle - gsngTT4AOffset + (CInt(Math.Ceiling(Math.Abs(gsngTTActualAngle) / 360)) + 1) * 360) Mod 360)

                gsngTT4AModOffset = gsngTTActualAngle - gsngTTAngle - gsngTT4AOffset    ' ((gsngTTAngle - gsngTT4AOffset + 360) Mod 360) - gsngTTAngle


                If bActualAngle Then
                    Return gsngTTActualAngle
                Else
                    'gsngTT4AModOffset = ((gsngTTAngle - gsngTT4AOffset + 360) Mod 360) - gsngTTAngle 'for later uses
                    Return gsngTTAngle
                End If
                'Return gsngTTAngle

            Case 2

                If glTTLPT < 1 Then Return Nothing
                If glTTAddr < 1 Then Return Nothing
                If Not gblnTTInitialized Then Return Nothing
                szErr = ""

                If bActualAngle Then
                    Return gsngTTAngle
                Else
                    Return (gsngTTAngle - gsngTTOffset + 360) Mod 360
                End If

            Case 3
                If Not gblnTTInitialized Then Return Nothing
                szErr = ""

                If bActualAngle Then
                    Return gsngTTAngle
                Else
                    Return (gsngTTAngle + 360) Mod 360
                End If

            Case Else
                Return -1
        End Select

        'Return GetAngle



    End Function


    Public Function isTurntableMoving(Optional lID As Integer = 1) As Integer
        Dim lMoving As Integer
        isControlMoving(lID, lMoving)
        Return lMoving

    End Function

    ''' <summary>
    ''' Move turntable to angle...
    ''' </summary>
    ''' <param name="sngAngle">Angle in degrees azimuth.</param>
    ''' <param name="lDir">Optional: Direction (only for Four Audio Turntable).</param><example>-1: shortest way (default), 0: clockwise, 1: counterclockwise</example>
    ''' <param name="bEnableBrakeTimer">Optional: Direction (only for Four Audio Turntable).</param><example>False: Do NOT enable timer for break function after movement (default), True: Do enable timer for break function after movement</example>
    ''' <param name="bAllowFullRotations">Optional: Allow full rotations (+/- 360 degrees) (only for Four Audio Turntable).</param><example>False: rotations below +/-360° only (default), True: full rotations possible (+/-360°)</example>
    ''' <param name="bDontWait">Optional: If set to true, turntable rotation is started but the code continues without waiting if target angle has been reached. Source code can proceed inbetween.</param>
    ''' <param name="lDelay">Optional: If value is not zero wait lDelay ms before send the rotation command.</param>
    ''' <returns>Error text if an error occures.</returns>
    Public Function MoveToAngle(ByRef sngAngle As Double, Optional lDir As Integer = -1, Optional bEnableBrakeTimer As Boolean = False, Optional bAllowFullRotations As Boolean = False, Optional bDontWait As Boolean = False, Optional lDelay As Integer = 0) As String
        'angle is the value used by the application user, range 0-359°, used eg. for hrtf measurement (not the true angle of the hardware)

        If gblnTTUse = False Then Return ""

        Select Case glTTMode
            Case 1 'Four Audio

                Dim lStart As Double = GetAngle() ' starting position
                Dim lActualStart As Double = GetAngle(True) ' starting position
                Dim lStep As Double = 0  ' how far to move? step size

                frmTurntable.StopTT4ATimer() 'stop turntable timer (for brake)
                'frmTurntable.tmrDelayed.Interval = lDelay 'delay next command to start rotation (default: 0)

                If lDir = -1 Then ' determine optimal direction

                    lStep = Math.Abs(Math.Round(sngAngle - lStart, 1)) 'step size 

                    If (sngAngle - lStart) < 0 Then 'direction
                        lDir = 1 'CCW
                    Else
                        lDir = 0 'CW
                    End If

                    If lStep > 180 Then
                        lStep = 360 - lStep ' other (shorter) direction?
                        lDir = 1 - lDir
                    End If

                ElseIf lDir = 0 Then ' forced CW direction
                    If sngAngle = 0 Then sngAngle = 360 'fix rotation

                    If bAllowFullRotations = True Then
                        lStep = Math.Abs(Math.Round(sngAngle - lStart, 1))
                    Else
                        lStep = Math.Abs(Math.Round((sngAngle - lStart) Mod 360, 1))
                        'lStep = Math.Abs(Math.Round((sngAngle - lStart - 360) Mod 360, 1))
                    end if

                    ' lDir is given by input
                ElseIf lDir = 1 Then ' forced CCW direction
                    
                    If bAllowFullRotations = True Then
                        lStep = Math.Round((lStart - sngAngle), 1)
                    Else
                        lStep = Math.Round((lStart - sngAngle + 360) Mod 360, 1)
                    end if

                    ' lDir is given by input
                End If

                If lStep = 0 Then Return "" 'no movement necessary

                ' move
                If lDelay = 0 Then
                    'direct movement
                    moveControlByStepInDirectionNonBlocking(1, CSng(lStep), lDir) 'direct movement command
                Else
                    'delayed movement
                    mlDir=lDir
                    mlStep=lStep
                    frmTurntable.tmrDelayed.Interval=lDelay
                    frmTurntable.tmrDelayed.Start
                    'DelayedMovementCommand(lStep, lDir, lDelay)
                End If             

                If frmTurntable.pbTime.Visible = True Then frmTurntable.pbTime.Value = 0
                If bDontWait Then Return "" ' don't wait until target angle has been reached

                Dim lMoving As Integer = -1

                'txtLog.AppendText("  wait while moving...")
                Do While lMoving <> 0
                    lMoving = isTurntableMoving()
                    GetAngle()
                    frmTurntable.ShowAngle((360 + gsngTTAngle) Mod 360)
                    If frmTurntable.Visible = True Then
                        'progress bar
                        frmTurntable.pbTime.Value = CInt(100 * (Math.Abs(gsngTTActualAngle - lActualStart)) / Math.Abs(lStep))
                    End If

                    Application.DoEvents()
                    Sleep(100)
                Loop

                GetAngle(, gszTTError)
                frmTurntable.ShowAngle((360 + gsngTTAngle) Mod 360)

                'start timer for automatic brake
                If bEnableBrakeTimer Then frmTurntable.StartTT4ATimer()

                Return gszTTError

            Case 2 'Outline
                ' turntable not defined
                If glTTLPT < 1 Then Return ""

                If glTTAddr < 1 Then
                    gszTTError = "Turntable not initialized or deactivated."
                    Return gszTTError
                End If

                If sngAngle < 0 Or sngAngle > 360 Then
                    gszTTError = "Not allowed value. Set angle to 0°...360°."
                    Return gszTTError
                End If
                sngAngle = Math.Round(((sngAngle + gsngTTOffset) Mod 360) / gsngTTResolution) * gsngTTResolution
                ' do we need to move?
                If gblnTTInitialized And glTTAddr > 0 And (sngAngle = gsngTTAngle) Then Return ""
                ' yes, we do
                gsngTTReqAngle = sngAngle
                gblnTTHideUI = True
                'frmTurntable.Hide()
                frmTurntable.ShowDialog()
                frmTurntable.Dispose()

                gszTTError = ""
                Return gszTTError

            Case 3 ' Imperial Custom

                ' find how much to move
                Dim lStart As Double = GetAngle() ' starting position
                Dim lActualStart As Double = GetAngle(True) ' starting position
                Dim lStep As Double = 0  ' how far to move? step size

                If lDir = -1 Then ' determine optimal direction

                    lStep = Math.Abs(Math.Round(sngAngle - lStart, 1)) 'step size 

                    If (sngAngle - lStart) < 0 Then 'direction
                        lDir = 0 'CW
                    Else
                        lDir = 1 'CCW
                    End If

                    If lStep > 180 Then
                        lStep = 360 - lStep ' other (shorter) direction?
                        lDir = 1 - lDir
                    End If

                ElseIf lDir = 0 Then ' forced CW direction
                    If sngAngle = 0 Then sngAngle = 360 'fix rotation

                    If bAllowFullRotations = True Then
                        lStep = Math.Abs(Math.Round(sngAngle - lStart, 1))
                    Else
                        lStep = Math.Abs(Math.Round((sngAngle - lStart) Mod 360, 1))
                        'lStep = Math.Abs(Math.Round((sngAngle - lStart - 360) Mod 360, 1))
                    End If

                    ' lDir is given by input
                ElseIf lDir = 1 Then ' forced CCW direction

                    If bAllowFullRotations = True Then
                        lStep = Math.Round((lStart - sngAngle), 1)
                    Else
                        lStep = Math.Round((lStart - sngAngle + 360) Mod 360, 1)
                    End If

                    ' lDir is given by input
                End If

                'move
                If lStep = 0 Then Return "" 'no movement necessary

                ' set speed
                Dim ttPeriod As Double = Math.Round(400 / ttSpeed)

                ' prepare packet for speed
                Dim bytBuf1() As Byte = OSC.PreparePacket("/Speed", {CInt(ttPeriod)})

                ' send packet speed
                Try
                    ttSend.Send(bytBuf1, bytBuf1.Length)
                Catch x As Exception
                    Return x.ToString
                End Try

                ' prepare packet for rotation
                Dim bytBuf2() As Byte
                If lDir = 1 Then
                    bytBuf2 = OSC.PreparePacket("/Anticlockwise", {CInt(lStep)})
                Else
                    bytBuf2 = OSC.PreparePacket("/Clockwise", {CInt(lStep)})
                End If

                ' send packet rotation
                Try
                    ttSend.Send(bytBuf2, bytBuf2.Length)
                Catch x As Exception
                    Return x.ToString
                End Try

                'Dim ttSpeed As Double = 400 / (ttPeriod * 1000) ' degrees/ms, empirically calculated
                Dim waitTime As Double = lStep / ttSpeed

                ttMoving = True

                ' wait that time
                Dim tStart, tCurrent, tEnd As Long
                QueryPerformanceCounter(tStart)
                tEnd = tStart + CLng(waitTime * gcurHPFrequency)
                Do While ttMoving = True And tCurrent < tEnd
                    QueryPerformanceCounter(tCurrent)
                    Dim elapsedTime As Double = (tCurrent - tStart) / gcurHPFrequency
                    If lDir = 0 Then ' clockwise
                        gsngTTAngle = (lStart - elapsedTime * ttSpeed + 360) Mod 360
                        gsngTTActualAngle = gsngTTAngle
                    Else ' anticlockwise
                        gsngTTAngle = (lStart + elapsedTime * ttSpeed + 360) Mod 360
                        gsngTTActualAngle = gsngTTAngle
                    End If
                    frmTurntable.ShowAngle((360 + gsngTTAngle) Mod 360)
                    If frmTurntable.Visible = True Then
                        'progress bar
                        frmTurntable.pbTime.Value = Math.Min(100, CInt(100 * elapsedTime / waitTime))
                    End If
                    Application.DoEvents()
                    Sleep(10)
                Loop

                If ttMoving = False Then ' canceled by user
                    Return ""
                End If

                ttMoving = False

                gsngTTAngle = sngAngle
                gsngTTActualAngle = sngAngle
                frmTurntable.ShowAngle((360 + gsngTTAngle) Mod 360)

                gszTTError = ""
                Return gszTTError

            Case Else
                Return ""
        End Select

    End Function

    Public Sub DelayedMovementCommand()

        'frmTurntable.tmrDelayed.Start
        moveControlByStepInDirectionNonBlocking(1, CSng(mlStep), mlDir)

    End Sub

    Public Function IsInitialized() As Boolean
        Return gblnTTInitialized
    End Function

End Module