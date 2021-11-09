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
Imports Microsoft.DirectX.DirectInput
Imports System.Threading
''' <summary>
''' FrameWork - Internal use only.
''' </summary>
''' <remarks></remarks>
Module HUI

    Public Event Callback(ByVal lButtons() As Byte, ByVal lX As Integer, ByVal lY As Integer, ByVal lZ As Integer)

    Const JOYSTICKCENTERED As Integer = 32768
    Private mblnValid As Boolean = False
    Private mdevHUI As Device = Nothing
    Private mwaitReg As RegisteredWaitHandle = Nothing
    Private mwaitHnd As WaitHandle = Nothing
    Private mModeEnabled As Integer = -1

    Public Function IsModeEnabled(Optional ByRef szErr As String = "") As Integer
        'Returns:
        ' 0: Mode disabled
        ' 1: Mode enabled
        '-1: Not defined/error (szErr contains error message)

        If glExpHUIID = 0 Then Return -1 'no gamepad selected
        If mModeEnabled = -1 Then szErr = "Gamepad mode not defined (yet)!"
        Return mModeEnabled

    End Function

    Public Function GetDevicesList(ByRef szProductName() As String, ByRef lButtons() As Integer) As String

        Dim devices As DeviceList
        '
        ' **** L O A D E R   L O C K   /  E X C E P T I O N  T H R O W N ? ? ?  *****
        '
        'IF YOU HAVE A LOADER LOCK  WARNING / EXCEPTION THROWN AT THIS POINT PLEASE FOLLOW THESE STEPS TO DISABLE THEM:
        '####   
        '####   Open Exception Settings in Visual Basic, navigate to the menu "Break When Thrown", then
        '####   first check and then uncheck the point "Managed Debugging Asistants"
        '####   
        '
        devices = Manager.GetDevices(DeviceType.Joystick, EnumDevicesFlags.AllDevices)
        If IsNothing(devices) Then Return "No devices found"

        ReDim szProductName(devices.Count - 1)
        ReDim lButtons(devices.Count - 1)

        For lX As Integer = 0 To devices.Count - 1
            devices.MoveNext()
            Dim dev As DeviceInstance = CType(devices.Current, DeviceInstance)
            szProductName(lX) = Trim(dev.ProductName)
            Dim joyDev As New Device(dev.ProductGuid)
            lButtons(lX) = joyDev.Caps.NumberButtons
            joyDev = Nothing
        Next
        Return ""
    End Function

    Public Function SetDevice(ByVal lHWND As IntPtr, ByVal lIdx As Integer) As String

        On Error GoTo SubErr

        If mblnValid Then ReleaseDevice() ' release device
        mblnValid = False
        If lIdx < 0 Then Return "" ' no HUI specified, don't aquire antyhing

        Dim devices As DeviceList = Manager.GetDevices(DeviceType.Joystick, EnumDevicesFlags.AllDevices)
        If IsNothing(devices) Then Return "SetHUIDevice: No devices found"
        If devices.Count = 0 Then Return "SetHUIDevice: No devices found"
        If devices.Count < lIdx Then Return "SetHUIDevice: Index of device is out of device list"

        ' create HUI object
        Dim dev As DeviceInstance
        For lX As Integer = 0 To lIdx
            devices.MoveNext()
            dev = CType(devices.Current, DeviceInstance)
        Next
        mdevHUI = New Device(dev.ProductGuid)
        mdevHUI.SetDataFormat(DeviceDataFormat.Joystick)
        mdevHUI.SetCooperativeLevel(lHWND, CooperativeLevelFlags.Background Or CooperativeLevelFlags.NonExclusive)
        mdevHUI.Acquire()
        mdevHUI.Poll()
        mdevHUI.Unacquire()
        mwaitHnd = New AutoResetEvent(False)
        mwaitReg = ThreadPool.RegisterWaitForSingleObject(mwaitHnd, New WaitOrTimerCallback(AddressOf HUI.CallbackHandler), _
                mdevHUI, -1, False)
        mdevHUI.SetEventNotification(mwaitHnd)
        mdevHUI.Acquire()
        mblnValid = True
        Return ""

SubErr:
        mdevHUI = Nothing
        mblnValid = False
        Return "SetHUIList: " & Err.Description

    End Function

    Public Sub CallbackHandler(ByVal state As Object, ByVal timedout As Boolean)
        Dim joyState As New JoystickState

        mdevHUI.Acquire()
        mdevHUI.Poll()
        joyState = mdevHUI.CurrentJoystickState()

        ' get buttons
        Dim lKey As Integer = 0
        Dim bytArr() As Byte = joyState.GetButtons
        If Not IsNothing(bytArr) AndAlso bytArr.Length > 0 Then
        End If
        ' get analog
        'Debug.Print(System.DateTime.Now.ToString & " -- " & joyState.X.ToString & " -- " & joyState.Y.ToString & " -- " & joyState.Z.ToString)

        If (joyState.X = 32767 Or joyState.X = 255 Or joyState.X = 65274) And (joyState.Y = 32767 Or joyState.Y = 255 Or joyState.Y = 65274) Then
            'most probably...
            mModeEnabled = 0
        Else
            mModeEnabled = 1
        End If
        'Debug.Print("Mode: " & mModeEnabled.ToString)
        'If 
        Dim lX As Integer = joyState.X - JOYSTICKCENTERED
        Dim lY As Integer = joyState.Y - JOYSTICKCENTERED
        Dim lZ As Integer = joyState.Z - JOYSTICKCENTERED

        RaiseEvent Callback(bytArr, lX, lY, lZ)
        'Console.WriteLine("Joypad: " & Str(lKey))
    End Sub

    Public Sub ReleaseDevice()

        If Not mblnValid Then Return
        If IsNothing(mdevHUI) Then Return
        mdevHUI.Unacquire()
        mdevHUI.SetEventNotification(Nothing)
        mdevHUI = Nothing
        If Not IsNothing(mwaitReg) Then
            mwaitReg.Unregister(mwaitHnd)
            mwaitReg = Nothing
        End If
        If Not IsNothing(mwaitHnd) Then
            mwaitHnd = Nothing
        End If
        mblnValid = False

    End Sub

End Module