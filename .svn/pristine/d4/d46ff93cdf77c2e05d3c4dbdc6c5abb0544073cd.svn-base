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
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions

''' <summary>
''' FrameWork - General tools
''' </summary>
''' <remarks></remarks>
Module Proc

   

    Const TH32CS_SNAPHEAPLIST As Short = &H1S
    Const TH32CS_SNAPPROCESS As Short = &H2S
    Const TH32CS_SNAPTHREAD As Short = &H4S
    Const TH32CS_SNAPMODULE As Short = &H8S
    Const TH32CS_SNAPALL As Short = (TH32CS_SNAPHEAPLIST Or TH32CS_SNAPPROCESS Or TH32CS_SNAPTHREAD Or TH32CS_SNAPMODULE)
    Const TH32CS_INHERIT As Integer = &H80000000
    Const MAX_PATH As Short = 260
    Const SW_SHOWNORMAL As Short = 1
    Public Const GW_HWNDNEXT As Short = 2
    Public Const GW_HWNDPREV As Short = 3
    Public Const SW_HIDE As Short = 0
    Public Const SW_MAXIMIZE As Short = 3
    Public Const SW_MINIMIZE As Short = 6
    Public Const SW_NORMAL As Short = 1
    Public Const SW_RESTORE As Short = 9

    ' SetWindowPos
    Public Const SWP_NOACTIVATE As Short = &H10S
    Public Const SWP_NOMOVE As Short = &H2S
    Public Const SWP_NOSIZE As Short = &H1S
    Public Const SWP_SHOWWINDOW As Short = &H40S
    Public Const HWND_NOTOPMOST As Short = -2
    Public Const HWND_TOPMOST As Short = -1

    Public Const GWL_STYLE As Short = -16
    Public Const WS_DISABLED As Integer = &H8000000
    Public Const WM_CANCELMODE As Short = &H1FS
    Public Const WM_CLOSE As Short = &H10S
    ' Process constants
    Private Const SYNCHRONIZE As Integer = &H100000
    Private Const PROCESS_TERMINATE As Integer = &H1S

    ' process
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure PROCESSENTRY32
        Dim dwSize As Integer
        Dim cntUsage As Integer
        Dim th32ProcessID As Integer
        Dim th32DefaultHeapID As Integer
        Dim th32ModuleID As Integer
        Dim cntThreads As Integer
        Dim th32ParentProcessID As Integer
        Dim pcPriClassBase As Integer
        Dim dwFlags As Integer
        '<VBFixedString(MAX_PATH), MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_PATH)> Dim szExeFile() As Char
        <VBFixedString(MAX_PATH), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=(MAX_PATH + 1))> Dim szExeFile As String

    End Structure

    Private Declare Function CreateToolhelp32Snapshot Lib "kernel32" (ByVal lFlags As Integer, ByVal lProcessID As Integer) As Integer
    Private Declare Function Process32First Lib "kernel32" (ByVal hSnapShot As Integer, ByRef uProcess As PROCESSENTRY32) As Integer
    Private Declare Function Process32Next Lib "kernel32" (ByVal hSnapShot As Integer, ByRef uProcess As PROCESSENTRY32) As Integer
    Private Declare Sub CloseHandle Lib "kernel32" (ByVal hPass As Integer)
    Private Declare Function ShellExecute Lib "Shell32.dll" Alias "ShellExecuteA" (ByVal hWnd As Integer, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Integer) As Integer
    Private Declare Function GetSystemDirectory Lib "kernel32" Alias "GetSystemDirectoryA" (ByVal lpBuffer As String, ByVal nSize As Integer) As Integer
    Private Declare Function GetWindowsDirectory Lib "kernel32" Alias "GetWindowsDirectoryA" (ByVal lpBuffer As String, ByVal nSize As Integer) As Integer
    Private Declare Function GetTempPath Lib "kernel32" Alias "GetTempPathA" (ByVal nBufferLength As Integer, ByVal lpBuffer As String) As Integer
    Private Declare Function GetNextWindow Lib "user32" Alias "GetWindow" (ByVal hWnd As Integer, ByVal wFlag As Integer) As Integer
    Private Declare Function SetForegroundWindow Lib "user32" (ByVal hWnd As Integer) As Integer
    Private Declare Function GetForegroundWindow Lib "user32" () As Integer
    Private Declare Function ShowWindow Lib "user32" (ByVal hWnd As Integer, ByVal nCmdShow As Integer) As Integer
    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
    Private Declare Function SetWindowPos Lib "user32" (ByVal hWnd As Integer, ByVal hWndInsertAfter As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    Private Declare Function IsWindow Lib "user32" (ByVal hWnd As Integer) As Integer
    Private Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" (ByVal hWnd As Integer, ByVal nIndex As Integer) As Integer
    Private Declare Function PostMessage Lib "user32" Alias "PostMessageA" (ByVal hWnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    Private Declare Function TerminateProcess Lib "kernel32" (ByVal hProcess As Integer, ByVal uExitCode As Integer) As Integer
    Private Declare Function OpenProcess Lib "kernel32" (ByVal dwDesiredAccess As Integer, ByVal bInheritHandle As Integer, ByVal dwProcessID As Integer) As Integer
    Private Declare Function WaitForSingleObject Lib "kernel32" (ByVal hHandle As Integer, ByVal dwMilliseconds As Integer) As Integer
    ' high precision timer
    Public Declare Function QueryPerformanceCounter Lib "kernel32" (ByRef lpPerformanceCount As Long) As Integer
    Public Declare Function QueryPerformanceFrequency Lib "kernel32" (ByRef lpFrequency As Long) As Integer
    Public Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)

    ' beep
    Public Declare Function Beep Lib "kernel32" (ByVal lFreq As Integer, ByVal lDuration As Integer) As Integer
    ' registry
    Private Declare Function SHChangeNotify Lib "Shell32.dll" (ByVal wEventID As Integer, ByVal uFlags As Integer, ByVal dwItem1 As Integer, ByVal dwItem2 As Integer) As Integer

    Private Const SHCNE_ASSOCCHANGED As Integer = &H8000000
    Private Const SHCNF_IDLIST As Integer = &H0S

    Private Const REG_SZ As Integer = &H1S
    Private Const REG_DWORD As Integer = &H4S
    Private Const HKEY_CLASSES_ROOT As Integer = &H80000000
    Private Const HKEY_CURRENT_USER As Integer = &H80000001
    Private Const HKEY_LOCAL_MACHINE As Integer = &H80000002
    Private Const HKEY_USERS As Integer = &H80000003
    Private Const ERROR_SUCCESS As Integer = 0
    Private Const ERROR_BADDB As Integer = 1009
    Private Const ERROR_BADKEY As Integer = 1010
    Private Const ERROR_CANTOPEN As Integer = 1011
    Private Const ERROR_CANTREAD As Integer = 1012
    Private Const ERROR_CANTWRITE As Integer = 1013
    Private Const ERROR_OUTOFMEMORY As Integer = 14
    Private Const ERROR_INVALID_PARAMETER As Integer = 87
    Private Const ERROR_ACCESS_DENIED As Integer = 5
    Private Const ERROR_MORE_DATA As Integer = 234
    Private Const ERROR_NO_MORE_ITEMS As Integer = 259
    Private Const KEY_ALL_ACCESS As Integer = &HF003F
    Private Const REG_OPTION_NON_VOLATILE As Integer = 0

    ' cursor control
    Private Declare Sub ClipCursorRect Lib "user32" Alias "ClipCursor" (ByRef lpRect As RECT)
    Private Declare Sub ClipCursorClear Lib "user32" Alias "ClipCursor" (ByVal lpRect As Integer)

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Private Structure POINTAPI
        Dim X As Integer
        Dim Y As Integer
    End Structure

    ' general
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure RECT
        Dim Left As Integer
        Dim Top As Integer
        Dim Width As Integer
        Dim Height As Integer
        Dim WindowState As FormWindowState
    End Structure

    ' public data
    Public gblnTimeOut As Boolean

    ''' <summary>
    ''' Convert numeric data to String.
    ''' </summary>
    ''' <param name="X">Numeric value.</param>
    ''' <returns>String.</returns>
    ''' <remarks></remarks>
    Public Function TStr(ByVal X As Double) As String
        Return LTrim(Str(X))
    End Function

    ''' <summary>
    ''' Convert numeric data to String.
    ''' </summary>
    ''' <param name="X">Numeric value.</param>
    ''' <returns>String.</returns>
    ''' <remarks></remarks>
    Public Function TStr(ByVal X As Integer) As String
        Return LTrim(Str(X))
    End Function

   ''' <summary>
    ''' Clip the mouse cursor to an area in a window.
    ''' </summary>
    ''' <param name="hWnd">Handle of the window. Set hWnd to 0 to release the clipping area.</param>
    ''' <param name="lLeft">Left corner [pixels]</param>
    ''' <param name="lTop">Top corner [pixels]</param>
    ''' <param name="lWidth">Width of the area.</param>
    ''' <param name="lHeight">Height of the area.</param>
    ''' <remarks></remarks>
    Public Sub ClipCursorToWindow(ByVal hWnd As Integer, Optional ByVal lLeft As Integer = 0, Optional ByVal lTop As Integer = 0, Optional ByVal lWidth As Integer = 0, Optional ByVal lHeight As Integer = 0)
        Dim r As RECT
        If hWnd <> 0 Then
            r.Left = lLeft
            r.Top = lTop
            r.Width = lWidth + lLeft
            r.Height = lHeight + lTop
            ClipCursorRect(r)
        Else
            ClipCursorClear(0)
        End If
    End Sub

   ''' <summary>
    ''' Convert 4 bytes to a 32-bit float number (Single)
    ''' </summary>
    ''' <param name="b0">Byte #0</param>
    ''' <param name="b1">Byte #1</param>
    ''' <param name="b2">Byte #2</param>
    ''' <param name="b3">Byte #3</param>
    ''' <returns>Float number. The Float number must have been saved in IEEE format.</returns>
    ''' <remarks></remarks>
    Public Function Bytes2Float(ByVal b0 As Byte, ByVal b1 As Byte, ByVal b2 As Byte, ByVal b3 As Byte) As Single
        Dim bytArr(0 To 3) As Byte

        bytArr(0) = b3
        bytArr(1) = b2
        bytArr(2) = b1
        bytArr(3) = b0

        Bytes2Float = BitConverter.ToSingle(bytArr, 0)

    End Function

   ''' <summary>
    ''' Convert 4 Bytes to a 32-integer (Long)
    ''' </summary>
    ''' <param name="b0">Byte #0</param>
    ''' <param name="b1">Byte #1</param>
    ''' <param name="b2">Byte #2</param>
    ''' <param name="b3">Byte #3</param>
    ''' <returns>Long number.</returns>
    ''' <remarks></remarks>
    Public Function Bytes2Long(ByVal b0 As Byte, ByVal b1 As Byte, ByVal b2 As Byte, ByVal b3 As Byte) As Integer
        Dim bytArr(0 To 3) As Byte

        bytArr(0) = b3
        bytArr(1) = b2
        bytArr(2) = b1
        bytArr(3) = b0

        Bytes2Long = BitConverter.ToInt32(bytArr, 0)

    End Function

   ''' <summary>
    ''' Convert a 32-bit integer (Long) to 4 bytes.
    ''' </summary>
    ''' <param name="l0">Long number.</param>
    ''' <param name="b0">Byte #0 as result.</param>
    ''' <param name="b1">Byte #1 as result.</param>
    ''' <param name="b2">Byte #2 as result.</param>
    ''' <param name="b3">Byte #3 as result.</param>
    ''' <remarks></remarks>
    Public Sub Long2Bytes(ByVal l0 As Integer, ByRef b0 As Byte, ByRef b1 As Byte, ByRef b2 As Byte, ByRef b3 As Byte)
        Dim bytArr(0 To 3) As Byte

        bytArr = BitConverter.GetBytes(l0)

        b0 = bytArr(3)
        b1 = bytArr(2)
        b2 = bytArr(1)
        b3 = bytArr(0)

    End Sub

    Private Function ProcessKill(ByVal ProcessID As Integer) As Boolean
        Dim hProc As Integer
        Const fdwAccess As Integer = SYNCHRONIZE Or PROCESS_TERMINATE

        ' Need to open process with terminate rights,
        ' or just give up immediately.
        hProc = OpenProcess(fdwAccess, 0, ProcessID)
        If CBool(hProc) Then
            ' Kill it.
            If CBool(TerminateProcess(hProc, 0)) Then
                ProcessKill = True
            Else
                ProcessKill = False
            End If
            ' Clean up.
            Call CloseHandle(hProc)
        End If
        Return Nothing
    End Function

    Public Function FindProcess(ByVal szName As String) As Boolean
        Dim szX As String
        Dim lX As Integer
        Dim lHnd As Integer

        If Len(szName) = 0 Then Return False
        lHnd = CreateToolhelp32Snapshot(TH32CS_SNAPALL, 0)          'take a snapshot of all processes and threads in the system
        Dim PrEntry As New PROCESSENTRY32
        PrEntry.dwSize = Marshal.SizeOf(PrEntry)
        lX = Process32First(lHnd, PrEntry)
        Do While CBool(lX)                             'look for szName in the systemprocesses
            szX = PrEntry.szExeFile
            'If InStr(1, szX, szName, CompareMethod.Text) > 0 Then
            If StrComp(Trim(LCase(szX)), Trim(LCase(szName)), CompareMethod.Text) = 0 Then
                CloseHandle(lHnd)
                Return True
            End If
            lX = Process32Next(lHnd, PrEntry)
        Loop
        CloseHandle(lHnd)
        Return False

    End Function

    Public Function GetProcessID(ByVal szName As String) As Integer
        Dim szX As String
        Dim lX As Integer
        Dim lHnd As Integer

        If Len(szName) = 0 Then Return 0
        lHnd = CreateToolhelp32Snapshot(TH32CS_SNAPALL, 0)
        Dim PrEntry As New PROCESSENTRY32
        PrEntry.dwSize = Marshal.SizeOf(PrEntry)
        lX = Process32First(lHnd, PrEntry)
        Do While CBool(lX)
            szX = PrEntry.szExeFile
            If InStr(1, szX, szName, CompareMethod.Text) > 0 Then
                lX = PrEntry.th32ProcessID
                CloseHandle(lHnd)
                Return lX
            End If
            lX = Process32Next(lHnd, PrEntry)
        Loop
        CloseHandle(lHnd)
        Return 0

    End Function

   ''' <summary>
    ''' Start Application by the file name
    ''' </summary>
    ''' <param name="szName">File Name of the Application.</param>
    ''' <returns>???</returns>
    ''' <remarks></remarks>
    Public Function StartApplication(ByVal szName As String) As Integer
        StartApplication = ShellExecute(0, vbNullString, szName, vbNullString, CurDir(), SW_SHOWNORMAL)
    End Function


   ''' <summary>
    ''' Close application.
    ''' </summary>
    ''' <param name="sWindowName">Name of the Window without extension.</param>
    ''' <returns>
    ''' <li>-1: error ocured</li>
    ''' <li>0: process not found</li>
    ''' <li>1: window found and closed</li>
    ''' <li>2: process has been killed</li>
    ''' </returns>
    ''' <remarks></remarks>
    Public Function CloseApplication(ByVal sWindowName As String) As Integer
        ' return:
        ' -1: error occured
        '  0: process not found - app closed already
        '  1: window found and closed
        '  2: process killed
        Dim ReturnVal, X, TargetHwnd As Integer
        'find handle of the application
        TargetHwnd = FindWindow(Nothing, sWindowName)
        If TargetHwnd = 0 Then
            ' window not found -look if the process is a hidden one
            If FindProcess(sWindowName & ".exe") Then
                ' .exe process found
                TargetHwnd = GetProcessID(sWindowName & ".exe")
                ProcessKill(TargetHwnd)
                ReturnVal = 2
            ElseIf FindProcess(sWindowName & ".com") Then
                ' .com process found
                TargetHwnd = GetProcessID(sWindowName & ".com")
                ProcessKill(TargetHwnd)
                ReturnVal = 2
            ElseIf FindProcess(sWindowName) Then
                ' .com process found
                TargetHwnd = GetProcessID(sWindowName)
                ProcessKill(TargetHwnd)
                ReturnVal = 2
            Else
                ReturnVal = 0 ' process not found.
            End If
        Else
            If Not CBool(IsWindow(TargetHwnd)) Then
                ReturnVal = -1
            Else
                'close application
                If Not CBool(GetWindowLong(TargetHwnd, GWL_STYLE) And WS_DISABLED) Then
                    X = PostMessage(TargetHwnd, WM_CLOSE, 0, 0)
                    Windows.Forms.Application.DoEvents()
                    ReturnVal = 1
                End If
            End If
        End If

        CloseApplication = ReturnVal

    End Function

   ''' <summary>
    ''' Get Windows Directory.
    ''' </summary>
    ''' <returns>Path to the Windows Directory</returns>
    ''' <remarks></remarks>
    Public Function GetWindowsDir() As String
        Dim sDir As New VB6.FixedLengthString(255)
        Dim iReturn As Integer
        Dim lSize As Integer

        sDir.Value = Space(255)
        lSize = Len(sDir.Value)
        iReturn = GetWindowsDirectory(sDir.Value, lSize)

        GetWindowsDir = Left(sDir.Value, InStr(1, sDir.Value, Chr(0)) - 1)

    End Function

   ''' <summary>
    ''' Get the System Directory of Windows.
    ''' </summary>
    ''' <returns>Path to the System Directory of Windows.</returns>
    ''' <remarks></remarks>
    Public Function GetSystemDir() As String
        Dim sDir As New VB6.FixedLengthString(255)
        Dim iReturn As Integer
        Dim lSize As Integer

        sDir.Value = Space(255)
        lSize = Len(sDir.Value)
        iReturn = GetSystemDirectory(sDir.Value, lSize)


        GetSystemDir = Left(sDir.Value, InStr(1, sDir.Value, Chr(0)) - 1)

    End Function

    Private mTimer As System.Threading.Timer
    Private Sub TimerElapsed(ByVal stateInfo As Object)
        TimerStop()
        gblnTimeOut = True
    End Sub

    Public Sub TimerStart(ByVal lTimeOut As Integer)
        TimerStop()
        Dim TimerDelegate As System.Threading.TimerCallback = AddressOf Proc.TimerElapsed
        mTimer = New System.Threading.Timer(TimerDelegate, Nothing, lTimeOut, System.Threading.Timeout.Infinite)
    End Sub

    Public Sub TimerStop()
        gblnTimeOut = False
        If Not IsNothing(mTimer) Then
            mTimer.Dispose()
            mTimer = Nothing
        End If
    End Sub

   ''' <summary>
    ''' Calculate LOG based on 10
    ''' </summary>
    ''' <param name="sX">Number</param>
    ''' <returns>Log10(sX)</returns>
    ''' <remarks></remarks>
    Public Function Log10(ByVal sX As Double) As Double
        If sX = 0 Then sX = 0.000000001
        Return Math.Log(sX) / 2.30258509299405
    End Function

   ''' <summary>
    ''' Calculate LOG based on 2
    ''' </summary>
    ''' <param name="sX">Number</param>
    ''' <returns>Log2(sX)</returns>
    ''' <remarks></remarks>
    Public Function Log2(ByVal sX As Double) As Double
        If sX = 0 Then sX = 0.000000001
        Return System.Math.Log(sX) / 0.693147180559945
    End Function

   ''' <summary>
    ''' Calculate the remainder of division.
    ''' </summary>
    ''' <param name="sA">Number to divide.</param>
    ''' <param name="sB">Divisor</param>
    ''' <returns>Remainder</returns>
    ''' <remarks>Obsolete function, use MOD instead</remarks>
    Public Function SngMod(ByVal sA As Single, ByVal sB As Single) As Single
        Return sA Mod sB
    End Function


   ''' <summary>
    ''' Convert from degrees to radians.
    ''' </summary>
    ''' <param name="sAngle">Angle in degress.</param>
    ''' <returns>Angle in radians.</returns>
    ''' <remarks></remarks>
    Public Function Deg2Rad(ByVal sAngle As Double) As Double

        Deg2Rad = sAngle / 180 * 3.14159265358979

    End Function

   ''' <summary>
    ''' Convert from radians to degrees.
    ''' </summary>
    ''' <param name="sAngle">Angle in radians.</param>
    ''' <returns>Angle in degress.</returns>
    ''' <remarks></remarks>
    Public Function Rad2Deg(ByVal sAngle As Double) As Double

        Rad2Deg = sAngle * 180 / 3.14159265358979

    End Function

   ''' <summary>
    ''' Calculate the acrsine of a value.
    ''' </summary>
    ''' <param name="sValue">Value</param>
    ''' <returns>arcsine of value sValue</returns>
    ''' <remarks></remarks>
    Public Function ArcSin(ByVal sValue As Double) As Double

        If sValue >= 1 Then ArcSin = 2 * System.Math.Atan(1) : Exit Function
        If sValue <= -1 Then ArcSin = -2 * System.Math.Atan(1) : Exit Function
        ArcSin = System.Math.Atan(sValue / System.Math.Sqrt(-sValue * sValue + 1))

    End Function

   ''' <summary>
    ''' Calculate the acrcosine of a value
    ''' </summary>
    ''' <param name="sValue">Value</param>
    ''' <returns>arccosine of value sValue</returns>
    ''' <remarks></remarks>
    Public Function ArcCos(ByVal sValue As Double) As Double

        If System.Math.Abs(sValue) >= 1 Then ArcCos = 0 : Exit Function
        ArcCos = System.Math.Atan(-sValue / System.Math.Sqrt(-sValue * sValue + 1)) + 2 * System.Math.Atan(1)
    End Function


   ''' <summary>
    ''' Disable/Enable a textbox control.
    ''' </summary>
    ''' <param name="txtControl">txtControl Name of the control</param>
    ''' <param name="blnState">TRUE: Enabled <br>FALSE: Disabled.</br></param>
    ''' <remarks>The Textbox control will be locked and disabled and the background color set to windows background.</remarks>
    Public Sub TextBoxState(ByVal txtControl As System.Windows.Forms.TextBox, ByVal blnState As Boolean)
        If txtControl Is Nothing Then Return
        If blnState Then
            txtControl.ReadOnly = False
            txtControl.BackColor = System.Drawing.SystemColors.Window
            txtControl.Enabled = True
        Else
            txtControl.ReadOnly = True
            txtControl.BackColor = System.Drawing.SystemColors.Control
            txtControl.Enabled = False
        End If
    End Sub

    Delegate Sub ButtonStateCallback(ByVal butX As Button, ByVal state As Boolean)
    Public Sub ButtonState(ByVal butX As Button, ByVal state As Boolean)
        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If IsNothing(butX) Then Return
        If Not butX.Visible Then Return
        If butX.InvokeRequired Then
            Dim d As New ButtonStateCallback(AddressOf ButtonState)
            butX.Parent.Invoke(d, New Object() {butX, state})
        Else
            butX.Enabled = state
        End If
    End Sub

    Delegate Sub LabelTextCallback(ByVal lblX As Label, ByVal szX As String)
    Public Sub LabelText(ByVal lblX As Label, ByVal szX As String)
        If IsNothing(lblX) Then Return
        If lblX.InvokeRequired Then
            Dim d As New LabelTextCallback(AddressOf LabelText)
            lblX.Parent.Invoke(d, New Object() {lblX, szX})
        Else
            lblX.Text = szX
        End If
    End Sub

    Delegate Sub SetStatusCallback(ByVal lbxX As ListBox, ByVal tssl As ToolStripStatusLabel, ByVal status As String)

    ''' <summary>
    ''' Sets the status in listbox.
    ''' </summary>
    ''' <param name="lbxX"></param>
    ''' <param name="tssl"></param>
    ''' <param name="status"></param>
    ''' <remarks></remarks>
    Public Sub SetStatus(ByVal lbxX As ListBox, ByVal tssl As ToolStripStatusLabel, ByVal status As String)
        If IsNothing(status) Then Return
        If lbxX.InvokeRequired Then
            Dim d As New SetStatusCallback(AddressOf SetStatus)
            lbxX.Parent.Invoke(d, New Object() {lbxX, tssl, status})
        Else
            tssl.Text = status
            If lbxX.Items.Count > 1000 Then lbxX.Items.RemoveAt((0))
            lbxX.Items.Add((status))
            lbxX.SelectedIndex = lbxX.Items.Count - 1
            'If Not gblnRemoteServerConnected Then frmMain.SetUIReady()
        End If
    End Sub

    Delegate Sub TimeStatusCallback(ByVal form As Form, ByVal tssl As ToolStripStatusLabel, ByVal status As String)

    ''' <summary>
    ''' Changes time in frmMain.
    ''' </summary>
    ''' <param name="form"></param>
    ''' <param name="tssl"></param>
    ''' <param name="status"></param>
    ''' <remarks></remarks>
    Public Sub TimeStatus(ByVal form As Form, ByVal tssl As ToolStripStatusLabel, ByVal status As String)
        If IsNothing(status) Then Return
        If form.InvokeRequired Then
            Dim d As New TimeStatusCallback(AddressOf TimeStatus)
            form.Invoke(d, New Object() {form, tssl, status})
        Else
            tssl.Text = status
        End If
    End Sub

    Delegate Sub ConnectionTimerCallback(ByVal form As Form, ByVal timer As Timer)

    ''' <summary>
    ''' Resets connectionTimer
    ''' </summary>
    ''' <param name="form"></param>
    ''' <param name="timer"></param>
    ''' <remarks></remarks>
    Public Sub ConnectionTimer(ByVal form As Form, ByVal timer As Timer)
        If form.InvokeRequired Then
            Dim d As New ConnectionTimerCallback(AddressOf ConnectionTimer)
            form.Invoke(d, New Object() {form, timer})
        Else
            timer.Start()
        End If
    End Sub

    Delegate Sub NetworkStatusCallback(ByVal form As Form, ByVal tssl As ToolStripStatusLabel, ByVal status As Integer)

    ''' <summary>
    ''' Changes the network icon in frmMain.
    ''' </summary>
    ''' <param name="form"></param>
    ''' <param name="tssl"></param>
    ''' <param name="status">0: idle<br>1: transmit<br>2: offline</br></br></param>
    ''' <remarks></remarks>
    Public Sub NetworkStatus(ByVal form As Form, ByVal tssl As ToolStripStatusLabel, ByVal status As Integer)
        If IsNothing(status) Then Return
        If form.InvokeRequired Then
            Dim d As New NetworkStatusCallback(AddressOf NetworkStatus)
            form.Invoke(d, New Object() {form, tssl, status})
        Else
            If gblnRemoteClientConnected Then QueryPerformanceCounter(gcurHPTic)
            Select Case status
                Case 0
                    tssl.Image = CType(My.Resources.network_idle, System.Drawing.Image)
                Case 1
                    tssl.Image = CType(My.Resources.network_transmit_receive, System.Drawing.Image)
                Case 2
                    tssl.Image = CType(My.Resources.network_offline, System.Drawing.Image)
                    tssl.Text = ""
            End Select
        End If
    End Sub

    Delegate Sub SelectItemCallback(ByVal dgv As DataGridView, ByVal index As Integer)

    ''' <summary>
    ''' Selects Item in Itemlist.
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <param name="index">Current item</param>
    ''' <remarks></remarks>
    Public Sub SelectItem(ByVal dgv As DataGridView, ByVal index As Integer)
        If IsNothing(index) Then Return
        If dgv.InvokeRequired Then
            Dim d As New SelectItemCallback(AddressOf SelectItem)
            dgv.Parent.Invoke(d, New Object() {dgv, index})
        Else
            dgv.CurrentCell = frmMain.dgvItemList.Rows(index).Cells(1)
            dgv.Rows(index).Selected = True
        End If
    End Sub

    Delegate Sub SetSizeCallback(ByVal dgv As DataGridView)
    Private mblnSetSizeBusy As Boolean = False
    ''' <summary>
    ''' Sets optimal column width.
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <remarks></remarks>
    Public Sub SetSize(ByVal dgv As DataGridView)
        If dgv.InvokeRequired Then
            Dim d As New SetSizeCallback(AddressOf SetSize)
            dgv.Invoke(d, New Object() {dgv})
        Else
            If Not gblnDisableSetOptimalColWidth Then
                If mblnSetSizeBusy Then Exit Sub
                mblnSetSizeBusy = True

                'Dim sTotalheigth As Single = 0 ' maybe resizing not necessary!? Calculate sum of all col's widths
                'For lX As Integer = 0 To dgv.RowCount - 1
                '    sTotalheigth += dgv.Rows(lX).Height
                'Next

                'If sTotalheigth < dgv.Height Then
                '    dgv.AutoResizeColumns()
                'Else
                Dim lX, lMaxWidth As Integer
                Dim bResized As Boolean = False

                dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                dgv.AutoResizeColumns()

                Dim sTotalwidth As Single = 0 ' maybe resizing not necessary!? Calculate sum of all col's widths
                For lX = 0 To dgv.ColumnCount - 1
                    sTotalwidth += dgv.Columns(lX).Width
                Next

                If sTotalwidth + 40 > dgv.Width Then ' resizing necessary?
                    lMaxWidth = CInt(dgv.Width / 3) ' colums too wide??? max width = total visible width / 3
                    For lX = 0 To dgv.ColumnCount - 1
                        If dgv.Columns(lX).Width > lMaxWidth Then ' If width > max width then...
                            dgv.Columns(lX).Width = lMaxWidth ' ...reduce width to max width
                        End If
                    Next
                End If

                dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                'End If

                mblnSetSizeBusy = False
                If Not gblnRemoteServerConnected Then frmMain.SetUIReady()
        End If
        End If
    End Sub

    Delegate Sub MnuRemoteMonitorEnabledCallback(ByVal form As Form, ByVal tsmi As ToolStripMenuItem, ByVal enable As Boolean)

    ''' <summary>
    ''' Enables Button
    ''' </summary>
    ''' <param name="form"></param>
    ''' <param name="tsmi"></param>
    ''' <param name="enable"></param>
    ''' <remarks></remarks>
    Public Sub MnuRemoteMonitorEnabled(ByVal form As Form, ByVal tsmi As ToolStripMenuItem, ByVal enable As Boolean)
        If IsNothing(enable) Then Return
        If form.InvokeRequired Then
            Dim d As New MnuRemoteMonitorEnabledCallback(AddressOf MnuRemoteMonitorEnabled)
            form.Invoke(d, New Object() {form, tsmi, enable})
        Else
            tsmi.Enabled = enable
        End If
    End Sub

    Delegate Sub MnuRemoteMonitorTextCallback(ByVal form As Form, ByVal tsmi As ToolStripMenuItem, ByVal text As String)

    ''' <summary>
    ''' Changes text of a ToolStripMenuItem
    ''' </summary>
    ''' <param name="form"></param>
    ''' <param name="tsmi"></param>
    ''' <param name="text"></param>
    ''' <remarks></remarks>
    Public Sub MnuRemoteMonitorText(ByVal form As Form, ByVal tsmi As ToolStripMenuItem, ByVal text As String)
        If IsNothing(text) Then Return
        If form.InvokeRequired Then
            Dim d As New MnuRemoteMonitorTextCallback(AddressOf MnuRemoteMonitorText)
            form.Invoke(d, New Object() {form, tsmi, text})
        Else
            tsmi.Text = text
        End If
    End Sub

    Public Function IsValidIPv4Address(ByVal ipAddress As String) As Boolean
        Return Regex.ismatch(ipAddress, "\A(25[0-5]|2[0-4]\d|[0-1]?\d?\d)(\.(25[0-5]|2[0-4]\d|[0-1]?\d?\d)){3}\z")
    End Function

    ''' <summary>
    ''' Copy a datagrid to an other, including its content.
    ''' </summary>
    ''' <param name="dgvS"></param>
    ''' <param name="dgvD"></param>
    ''' <param name="lBeg"></param>
    ''' <param name="lEnd"></param>
    ''' <param name="lStart"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CopyDataGridView(ByVal dgvS As DataGridView, ByRef dgvD As DataGridView, Optional ByVal lBeg As Integer = 0, Optional ByVal lEnd As Integer = 0, Optional ByVal lStart As Integer = 0) As String
        Dim lX, lY As Integer
        If dgvS Is Nothing Or dgvD Is Nothing Then Return ""
        If dgvS.RowCount = 0 Then dgvD.Rows.Clear() : Return ""
        If lBeg = 0 And lEnd = 0 And lStart = 0 Then
            ' copy entire datagridview with headers
            Dim ColMode As DataGridViewAutoSizeColumnMode = DirectCast(dgvD.AutoSizeColumnsMode, DataGridViewAutoSizeColumnMode)
            dgvD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            Dim RowMode As DataGridViewAutoSizeRowMode = DirectCast(dgvD.AutoSizeRowsMode, DataGridViewAutoSizeRowMode)
            dgvD.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            dgvD.ColumnCount = dgvS.ColumnCount
            dgvD.RowCount = dgvS.RowCount
            For lX = 0 To dgvD.ColumnCount - 1
                dgvD.Columns(lX).HeaderText = dgvS.Columns(lX).HeaderText
                dgvD.Columns(lX).ValueType = dgvS.Columns(lX).ValueType
            Next
            For lY = 0 To dgvD.RowCount - 1
                For lX = 0 To dgvD.ColumnCount - 1
                    dgvD.Item(lX, lY) = CType(dgvS.Item(lX, lY).Clone, DataGridViewCell)
                    dgvD.Item(lX, lY).Value = dgvS.Item(lX, lY).Value
                    'Console.WriteLine(dgvS.Item(lX, lY).Value)
                    If gblnRemoteServerConnected Then
                        Dim value As String = Convert.ToString(dgvD.Item(lX, lY).Value)
                        'RemoteMonitorServerSend.SendItem(lY, lX, value)
                    End If
                Next
            Next
            dgvD.AutoSizeColumnsMode = DirectCast(ColMode, DataGridViewAutoSizeColumnsMode)
            dgvD.AutoSizeRowsMode = DirectCast(RowMode, DataGridViewAutoSizeRowsMode)
        Else
            'copy part of source (lBeg to lEnd) to the destination from lStart
            'the size of the destination will be increased if too small for the source
            If dgvD.ColumnCount < dgvS.ColumnCount Then dgvD.ColumnCount = dgvS.ColumnCount
            If lStart + lEnd - lBeg + 1 > dgvD.RowCount Then dgvD.RowCount = lStart + lEnd - lBeg + 1
            Dim ColMode As DataGridViewAutoSizeColumnMode = DirectCast(dgvD.AutoSizeColumnsMode, DataGridViewAutoSizeColumnMode)
            dgvD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            Dim RowMode As DataGridViewAutoSizeRowMode = DirectCast(dgvD.AutoSizeRowsMode, DataGridViewAutoSizeRowMode)
            dgvD.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            For lY = lBeg To lEnd
                For lX = 0 To dgvD.ColumnCount - 1
                    dgvD.Item(lX, lY - lBeg + lStart) = CType(dgvS.Item(lX, lY).Clone, DataGridViewCell)
                    dgvD.Item(lX, lY - lBeg + lStart).Value = dgvS.Item(lX, lY).Value
                    'Console.WriteLine(dgvS.Item(lX, lY).Value)
                Next
            Next
            dgvD.AutoSizeColumnsMode = DirectCast(ColMode, DataGridViewAutoSizeColumnsMode)
            dgvD.AutoSizeRowsMode = DirectCast(RowMode, DataGridViewAutoSizeRowsMode)
        End If
        Return ""
    End Function

    ''' <summary>
    ''' Copy Array.
    ''' </summary>
    ''' <param name="szSrc">Source array.</param>
    ''' <returns>Target array.</returns>
    ''' <remarks></remarks>
    Public Function CopyArray(ByVal szSrc() As String) As String()
        If IsNothing(szSrc) Then Return Nothing
        Dim szDest(szSrc.Length - 1) As String
        For lX As Integer = 0 To szSrc.Length - 1
            szDest(lX) = szSrc(lX)
        Next
        Return szDest
    End Function

    ''' <summary>
    ''' Copy Array.
    ''' </summary>
    ''' <param name="szSrc">Source array.</param>
    ''' <returns>Target array.</returns>
    ''' <remarks></remarks>
    Public Function CopyArray(ByVal szSrc() As Double) As Double()
        If IsNothing(szSrc) Then Return Nothing
        Dim szDest(szSrc.Length - 1) As Double
        For lX As Integer = 0 To szSrc.Length - 1
            szDest(lX) = szSrc(lX)
        Next
        Return szDest
    End Function

    Public Sub SwapDataGridRows(ByVal rowS As DataGridViewRow, ByVal rowD As DataGridViewRow)
        For lX As Integer = 0 To rowS.Cells.Count - 1
            rowD.Cells(lX) = CType(rowS.Cells(lX).Clone, DataGridViewCell)
            rowD.Cells(lX).Value = rowS.Cells(lX).Value
        Next
    End Sub

    Public Sub CopyDataGridRow(ByVal rowS As DataGridViewRow, ByVal rowD As DataGridViewRow)
        For lX As Integer = 0 To rowS.Cells.Count - 1
            rowD.Cells(lX) = CType(rowS.Cells(lX).Clone, DataGridViewCell)
            rowD.Cells(lX).Value = rowS.Cells(lX).Value
        Next
    End Sub

    ''' <summary>
    ''' Get the unbound of an array.
    ''' </summary>
    ''' <param name="lArray">Array</param>
    ''' <returns>Number of elements in the array, -1 if empty</returns>
    ''' <remarks>Difference to Ubound() of VB: Works for empty arrays, resulting in -1.</remarks>
    Public Function GetUbound(ByVal lArray() As String) As Integer
        If IsNothing(lArray) Then Return -1
        Return lArray.Length - 1
    End Function

    ''' <summary>
    ''' Get the unbound of an array.
    ''' </summary>
    ''' <param name="lArray">Array</param>
    ''' <returns>Number of elements in the array, -1 if empty</returns>
    ''' <remarks>Difference to Ubound() of VB: Works for empty arrays, resulting in -1.</remarks>
    Public Function GetUbound(ByVal lArray() As Integer) As Integer
        If IsNothing(lArray) Then Return -1
        Return lArray.Length - 1
    End Function

    ''' <summary>
    ''' Get the unbound of an array.
    ''' </summary>
    ''' <param name="lArray">Array</param>
    ''' <returns>Number of elements in the array, -1 if empty</returns>
    ''' <remarks>Difference to Ubound() of VB: Works for empty arrays, resulting in -1.</remarks>
    Public Function GetUbound(ByVal lArray() As Double) As Integer
        If IsNothing(lArray) Then Return -1
        Return lArray.Length - 1
    End Function

    ''' <summary>
    ''' Get the unbound of an array.
    ''' </summary>
    ''' <param name="lArray">Array</param>
    ''' <returns>Number of elements in the array, -1 if empty</returns>
    ''' <remarks>Difference to Ubound() of VB: Works for empty arrays, resulting in -1.</remarks>
    Public Function GetUbound(ByVal lArray() As clsFREQUENCY) As Integer
        If IsNothing(lArray) Then Return -1
        Return lArray.Length - 1
    End Function

    ''' <summary>
    ''' Change directory.
    ''' </summary>
    ''' <param name="szDir">Path name</param>
    ''' <returns> <li>FALSE: Directory changed</li> <li>TRUE: Couldn't change, as error ocured.</li></returns>
    ''' <remarks>Difference to ChDir: Drive will be changed if it's a local drive</remarks>
    Public Function ChangeDir(ByVal szDir As String) As Boolean
        ' change drive, don't handle UNC paths (Chdir can do that!)
        If szDir Is Nothing Then Return True
        If Len(szDir) = 0 Then Return True
        Try
            If Left(szDir, 2) <> "\\" Then ChDrive(szDir) ' no error if drive exists
            ChDir(szDir) ' no error if directory exists
        Catch
            Return True
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Get the command line parameters.
    ''' </summary>
    ''' <param name="MaxArgs">Maximum number of arguments. If not given, the number will be 11.</param>
    ''' <returns>Array containing parsed parameters. Array is empty if no parameter could be found in the command line.</returns>
    ''' <remarks>Parameters can be separated by blank or tab, if a parameter is quoted it may contain blanks or tabs. Parameters must not contain quotas.</remarks>
    Function GetCommandLine(Optional ByVal MaxArgs As Integer = 10) As String()
        Dim CmdLine As String
        Dim C As String
        Dim CmdLnLen As Integer
        Dim NumArgs As Integer
        Dim i As Integer
        Dim InArg As Boolean
        Dim Quoted As Boolean
        Dim ArgArray() As String

        'Make array of the correct size.
        ReDim ArgArray(MaxArgs)
        NumArgs = -1 : InArg = False
        'Get command line arguments.
        CmdLine = Trim(VB.Command())
        CmdLnLen = Len(CmdLine)
        'Go thru command line one character at a time.
        For i = 1 To CmdLnLen
            C = Mid(CmdLine, i, 1)
            'Test for space or tab.
            If (C <> " " And C <> vbTab) Or Quoted Then
                'Neither space nor tab or we are in quota
                'Test if not in quota and not in argument.
                If Not Quoted And Not InArg Then
                    'New argument begins.
                    'Test for too many arguments.
                    If NumArgs = MaxArgs Then Exit For
                    NumArgs = NumArgs + 1
                    InArg = True
                End If
                'Concatenate character to current argument if it is not a quota
                If C = Chr(34) Then
                    If Quoted Then
                        Quoted = False
                    Else
                        Quoted = True
                    End If
                Else
                    ArgArray(NumArgs) = ArgArray(NumArgs) & C
                End If
            Else
                InArg = False 'Found a space or tab - next argument is a new argument
            End If
        Next i
        'Resize array just enough to hold arguments.
        If NumArgs < 0 Then
            Erase ArgArray
        Else
            ReDim Preserve ArgArray(NumArgs)
        End If
        'Return Array in Function name.
        Return ArgArray
    End Function

    ''' <summary>
    ''' Calculate the arithmetic average (mean) value.
    ''' </summary>
    ''' <param name="sData">Array with data.</param>
    ''' <returns>Mean (=arithmetic average) value of sData()</returns>
    ''' <remarks></remarks>
    Public Function Mean(ByVal sData() As Double) As Double

        Dim lNr As Integer = GetUbound(sData)
        If lNr < 0 Then Return Double.NaN

        Dim dSum As Double = 0
        For lX As Integer = 0 To lNr
            dSum = sData(lX) + dSum
        Next
        Return dSum / (lNr + 1)

    End Function

    ''' <summary>
    ''' Returns median value of an array.
    ''' </summary>
    ''' <param name="lData">Data array (input).</param>
    ''' <returns>Median value.</returns>
    ''' <remarks></remarks>
    Public Function Median(ByVal lData() As Integer) As Double

        Dim lNr As Integer = GetUbound(lData)
        If lNr < 0 Then Return Double.NaN
        If lNr = 0 Then Return lData(0)
        If lNr = 1 Then Return (lData(0) + lData(1)) / 2

        Array.Sort(lData)
        If lNr Mod 2 = 0 Then
            Return lData(lNr \ 2)
        Else
            Return (lData(lNr \ 2) + lData(lNr \ 2 + 1)) / 2
        End If

    End Function

    ''' <summary>
    ''' Returns median value of an array.
    ''' </summary>
    ''' <param name="sData">Data array (input).</param>
    ''' <returns>Median value.</returns>
    ''' <remarks></remarks>
    Public Function Median(ByVal sData() As Double) As Double

        Dim lNr As Integer = GetUbound(sData)
        If lNr < 0 Then Return Double.NaN
        If lNr = 0 Then Return sData(0)
        If lNr = 1 Then Return (sData(0) + sData(1)) / 2

        Array.Sort(sData)
        If lNr Mod 2 = 0 Then
            Return sData(lNr \ 2)
        Else
            Return (sData(lNr \ 2) + sData(lNr \ 2 + 1)) / 2
        End If

    End Function
    ''' <summary>
    ''' Calculate the standard deviation of a series.
    ''' </summary>
    ''' <param name="sData">Array with data.</param>
    ''' <param name="sMean">Mean value of the series, must be calculated before.</param>
    ''' <returns>Standard deviation of the series sData()</returns>
    ''' <remarks></remarks>
    Public Function Std(ByVal sData() As Double, ByVal sMean As Double) As Double

        Dim lNr As Integer = GetUbound(sData)
        If lNr < 0 Then Return Double.NaN

        Dim dSum As Double = 0
        For lX As Integer = 0 To lNr
            dSum = ((sData(lX) - sMean) ^ 2) + dSum
        Next
        Return System.Math.Sqrt(dSum / (lNr + 1))

    End Function

    ''' <summary>
    ''' Calculate the root mean square error between two series.
    ''' </summary>
    ''' <param name="sResponse">Series 1</param>
    ''' <param name="sTarget">Series 2</param>
    ''' <returns>RMS error</returns>
    ''' <remarks></remarks>
    Public Function RMSError(ByVal sResponse() As Double, ByVal sTarget() As Double) As Double

        Dim lNr As Integer = GetUbound(sTarget)
        If lNr < 0 Then Return Double.NaN
        If lNr <> GetUbound(sResponse) Then Return Double.NaN

        Dim dSum As Double = 0
        For lX As Integer = 0 To lNr
            dSum = (sResponse(lX) - sTarget(lX)) ^ 2 + dSum
        Next
        Return Math.Sqrt(dSum / (lNr + 1))

    End Function
End Module