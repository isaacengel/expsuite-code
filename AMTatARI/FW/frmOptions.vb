Option Strict On
Option Explicit On

Imports Microsoft.Win32
Imports System.Management


<Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Sequential, CharSet:=Runtime.InteropServices.CharSet.Auto)> _
Public Structure WAVEOUTCAPS
     Public wMid As Short
     Public wPid As Short
     Public vDriverVersion As Integer

     <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=32)> _
     Public szPname As String

     Public dwFormats As Integer
     Public wChannels As Short
     Public wReserved As Short
     Public dwSupport As Integer
End Structure

#Region "ExpSuite License"
'ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
'Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
'Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
'You may not use this work except in compliance with the Licence. 
'You may obtain a copy of the Licence at: http://joinup.ec.europa.eu/software/page/eupl
'Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
'See the Licence for the specific language governing  permissions and limitations under the Licence. 
#End Region
' options form: hardware parameters, options are depending on the (and maybe different for every) computer
''' <summary>
''' FrameWork Module. Implementation of the Options dialog.
''' </summary>
''' <remarks></remarks>
Friend Class frmOptions
    Inherits System.Windows.Forms.Form

    Private IsInitializing As Boolean


    Private Sub SetUIBusy()
        For Each ctrlX As Control In Me.Controls
            If TypeOf (ctrlX) Is Button Then ctrlX.Enabled = False
            If TypeOf (ctrlX) Is TextBox Then Proc.TextBoxState(DirectCast(ctrlX, TextBox), False)
        Next
        For Each ctrlX As Control In Me.sstOptions.SelectedTab.Controls
            If TypeOf (ctrlX) Is Button Then ctrlX.Enabled = False
            If TypeOf (ctrlX) Is TextBox Then Proc.TextBoxState(DirectCast(ctrlX, TextBox), False)
        Next

    End Sub

    Private Sub SetUIReady()
        For Each ctrlX As Control In Me.Controls
            If TypeOf (ctrlX) Is Button Then ctrlX.Enabled = True
            If TypeOf (ctrlX) Is TextBox Then Proc.TextBoxState(DirectCast(ctrlX, TextBox), True)
        Next
        For Each ctrlX As Control In Me.sstOptions.SelectedTab.Controls
            If TypeOf (ctrlX) Is Button Then ctrlX.Enabled = True
            If TypeOf (ctrlX) Is TextBox Then Proc.TextBoxState(DirectCast(ctrlX, TextBox), True)
        Next
    End Sub

    Public Sub UpdatePriority()
        Dim myProcess As System.Diagnostics.Process = System.Diagnostics.Process.GetCurrentProcess()
        Select Case glPriority
            Case 0
                myProcess.PriorityClass = System.Diagnostics.ProcessPriorityClass.Normal
                'frmMain.SetStatus("Program Priority: Normal")
            Case 1
                myProcess.PriorityClass = System.Diagnostics.ProcessPriorityClass.AboveNormal
                frmMain.SetStatus("Program Thread Priority: Above Normal")
            Case 2
                myProcess.PriorityClass = System.Diagnostics.ProcessPriorityClass.High
                frmMain.SetStatus("Program Thread Priority: High")
            Case 3
                myProcess.PriorityClass = System.Diagnostics.ProcessPriorityClass.RealTime
                frmMain.SetStatus("Program Thread Priority: REALTIME!")
        End Select
    End Sub

    Private Function SetOptions() As Boolean
        Dim szErr As String = ""

        'Update priority
        glPriority = CInt(Val(cmbPriority.SelectedIndex))
        UpdatePriority()

        ' check parameters
        '    If Val(txtYAMIPort.Text) = Val(txtLocalYAMIPort.Text) Then szErr = "Set port values to different numbers (only one channel per port allowed)."
        'If Len(txtYAMIAddr.Text) = 0 Then szErr = "Audio will fail setting no YAMI IP address."
        'If Len(txtYAMIAddr.Text) = 0 Then szErr = "Audio will fail setting no local IP address."
        If Not IsNumeric(txtUnityPort.Text) Then szErr = "Port of the Unity must be numeric."
        If Not IsNumeric(txtUnityLocalPort.Text) Then szErr = "Port of the Unity Return Channel must be numeric."
        If Not IsNumeric(txtViWoPort.Text) Then szErr = "Port of the ViWo must be numeric."
        If dgvJoypad.RowCount > 0 Then
            For lX As Integer = 0 To dgvJoypad.RowCount - 1
                For lY As Integer = 0 To dgvJoypad.ColumnCount - 2

                Next
            Next
        End If
        ' cancel if a parameter was out of bound
        If Len(szErr) > 0 Then
            MsgBox(szErr, MsgBoxStyle.Critical, "Options")
            Return True
        End If

        ' save options
        ' general
        gblnAutoBackupLogFile = CBool(chkAutoBackupLogFile.CheckState)
        gblnAutoBackupLogFileSilent = CBool(chkAutoBackupLogFileSilent.CheckState)
        gblnAutoBackupItemList = CBool(chkAutoBackupItemList.CheckState)
        gblnUseFileNaming = CBool(chkUseFileNaming.CheckState)
        If chkUseBeepExp.CheckState = CheckState.Checked Then
            glFlagBeepExp = chkUseBeepExp.CheckState + chkBeepOnItem.CheckState * 2
        Else
            glFlagBeepExp = 0
        End If
        gblnPlayWaveExp = CBool(chkPlayWaveExp.CheckState)

        glWarningSwitches = glWarningSwitches And WarningSwitches.RealTimeParameterChange
        If chkNotShuffledOnExpStart.CheckState = CheckState.Checked Then glWarningSwitches = glWarningSwitches Or WarningSwitches.wsNotShuffledOnExpStart
        If chkNotRepOnExpStart.CheckState = CheckState.Checked Then glWarningSwitches = glWarningSwitches Or WarningSwitches.wsNotRepOnExpStart
        If chkExpPerformedOnShuffle.CheckState = CheckState.Checked Then glWarningSwitches = glWarningSwitches Or WarningSwitches.wsExpPerformedOnShuffle
        If chkResponseItemListOnExpRep.CheckState = CheckState.Checked Then glWarningSwitches = glWarningSwitches Or WarningSwitches.wsResponseItemListOnExpRep
        gblnDisableSetOptimalColWidth = CBool(chkDisableSetOptimalColWidth.CheckState)
        gblnCheckForUpdates = CBool(chkCheckForUpdates.CheckState)
        gUpdateInterval = CInt(UpdateInterval.Value)
        gszOptionsFile = txtOptionsFile.Text

        ' Player Pd
        gszPlayerNetAddr = txtYAMIAddr.Text
        gszLocalNetAddr = txtLocalYAMIAddr.Text
        glPlayerNetPort = CInt(Val(txtYAMIPort.Text))
        glLocalNetPort = CInt(Val(txtLocalYAMIPort.Text))
        gszPlayerFileName = txtPlayerFileName.Text
        glPlayerFlags = 0
        If chkPlayerASIO.CheckState = CheckState.Checked Then glPlayerFlags = glPlayerFlags Or PLAYERFLAGS.pfASIO
        If chkPlayerNoADC.CheckState = CheckState.Checked Then glPlayerFlags = glPlayerFlags Or PLAYERFLAGS.pfNoADC
        If chkPlayerNoGUI.CheckState = CheckState.Checked Then glPlayerFlags = glPlayerFlags Or PLAYERFLAGS.pfnogui
        If chkPlayerKillOnDisconnect.CheckState = CheckState.Checked Then glPlayerFlags = glPlayerFlags Or PLAYERFLAGS.pfKillondisconnect
        If chkPlayerFreeze.CheckState = CheckState.Checked Then glPlayerFlags = glPlayerFlags Or PLAYERFLAGS.pfFreezeOnStimulation
        glPlayerChannels = cmbPlayerChannels.SelectedIndex + 2
        glOutputPlay = New BitArray(glPlayerChannels)
        glPlayerAudioDevice = cmbPlayerDevice.SelectedIndex
        glPlayerADCAudioDevice = cmbPlayerADCDevice.SelectedIndex
        glPlayerMIDIOutDevice = cmbPlayerMIDIOutDevice.SelectedIndex
        glPlayerMIDIInDevice = cmbPlayerMIDIInDevice.SelectedIndex
        glPlayerHPLeft = cmbPlayerHPL.SelectedIndex + 1
        glPlayerHPRight = cmbPlayerHPR.SelectedIndex + 1
        glDataChannel = cmbDataChannel.SelectedIndex
        glTriggerChannel = cmbTriggerChannel.SelectedIndex
        gszDACName = txtDACName.Text
        gszADCName = txtADCName.Text
        gbAudioName = CBool(rdbAudioName.Checked)

        If glPlayerHPLeft = glPlayerHPRight Then szErr = szErr & vbCrLf & "Warning: Options -> Audio (Pd): Headphones channel left and right are matching!"
        If glDataChannel = glPlayerHPLeft Then szErr = szErr & vbCrLf & "Warning: Options -> Audio (Pd): Data channel matches headphones channel left!"
        If glDataChannel = glPlayerHPRight Then szErr = szErr & vbCrLf & "Warning: Options -> Audio (Pd): Data channel matches headphones channel right!"
        If glTriggerChannel = glPlayerHPLeft Then szErr = szErr & vbCrLf & "Warning: Options -> Audio (Pd): Trigger channel matches headphones channel left!"
        If glTriggerChannel = glPlayerHPRight Then szErr = szErr & vbCrLf & "Warning: Options -> Audio (Pd): Trigger channel matches headphones channel right!"
        If glDataChannel > 0 And glDataChannel = glTriggerChannel Then szErr = szErr & vbCrLf & "Warning: Options -> Audio (Pd): Trigger channel matches data channel!"
        If rdbAudioName.Checked And Not chkPlayerASIO.Checked Then szErr = szErr & vbCrLf & "ASIO has to be enabled to address audio devices by name!" & vbCrLf & vbCrLf & _
            "Syntax: ""ASIO:[interface name]"" or ""MMIO:[interface name]"""

        If szErr <> "" Then MsgBox(szErr, MsgBoxStyle.Exclamation, "Set options")

        ' Player Unity
        gszUnityNetAddr = txtUnityAddr.Text
        glUnityNetPort = CInt(Val(txtUnityPort.Text))
        glUnityLocalNetPort = CInt(Val(txtUnityLocalPort.Text))

        ' STIM
        glLogMode = CInt(Val(VB6.GetItemString(cmbLogMode, cmbLogMode.SelectedIndex)))
        gblnUseMATLAB = CBool(chkUseMATLAB.CheckState)
        gszMATLABServer = txtMATLABServer.Text
        gszMATLABPath = txtMATLABPath.Text
        ' RIB
        glCOMLeft = cmbComLeft.SelectedIndex + 1
        glCOMRight = cmbComRight.SelectedIndex + 1
        gszRIBServer = txtRIBServer.Text
        gblnRIBSimulation = CBool(chkSimulation.CheckState)
        gszRIBPath = txtRIBPath.Text
        ' RIB2
        gblnRIB2Simulation = CBool(chkRIB2Simulation.CheckState)
        gszRIB2DeviceName = txtRIB2Device.Text
        gszRIB2Path = txtRIB2Path.Text
        ' NIC
        gszNICPath = txtNICPath.Text

        ' CSV Export
        glCSVDelimiter = Asc(txtCSVDelimiter.Text)
        glCSVQuota = Asc(txtCSVQuota.Text)
        txtCSVDelimiter.Text = Chr(glCSVDelimiter)
        txtCSVQuota.Text = Chr(glCSVQuota)
        gblnIncludeHeadersInClipboard = CBool(ckbIncludeHeadersInClipboard.CheckState)
        ' Tracker
        glTrackerMode = -1 * CInt(rdbTrackerYAMI.Checked) - 2 * CInt(rdbTrackerViWo.Checked)
        glTrackerCOM = cmbTRCom.SelectedIndex
        If rdbTrackerOptitrack.Checked Then
            glTrackerMode = 3
            glTrackerCOM = 1 ' some functions only work if this variable is >0
        End If
        glTrackerBaudrate = CInt(VB6.GetItemString(cmbTRBaudrate, cmbTRBaudrate.SelectedIndex))
        glTrackerSensorCount = cmbTRSensorCount.SelectedIndex + 1
        gblnTrackerSimulation = CBool(chkTRSimulation.CheckState)
        If IsNumeric(txtTRSettingsInterval.Text) Then glTrackerSettingsInterval = CInt(Val(txtTRSettingsInterval.Text))
        gblnTrackerLog = CBool(chkTRLog.CheckState)

        ' Turntable
        glTTMode = -1 * CInt(rdbTTFourAudio.Checked) - 2 * CInt(rdbTTOutline.Checked) - 3 * CInt(rdbTTImperial.Checked)
        glTTLPT = cmbTTLPT.SelectedIndex
        If IsNumeric((txtTTOffset.Text)) Then gsngTTOffset = Val((txtTTOffset.Text))
        gsngTTOffset = (360 + gsngTTOffset) Mod 360 ' values from 0 to 360° allowed
        txtTTOffset.Text = TStr(gsngTTOffset)
        If IsNumeric((txtTT4AOffset.Text)) Then gsngTT4AOffset = Val((txtTT4AOffset.Text))
        gsngTT4AOffset = (360 + gsngTT4AOffset) Mod 360 ' values from 0 to 360° allowed
        txtTT4AOffset.Text = TStr(gsngTT4AOffset)
        glTT4aBrakeTimer = CInt(numTT4ABrakeTimer.Value)
        gblnAllowPreRotation = CBool(ckbTT4AAllowPreRotation.CheckState)

        ' ViWo
        glViWoPort = CInt(Val(txtViWoPort.Text))
        gszViWoAddress = txtViWoAddress.Text
        'gbViWoOSC = CBool(chkViWoOSC.CheckState)
        chkViWoOSC.Text = "Comply with OSC standard"

        ' Joypad
        ReDim JoyPads(dgvJoypad.RowCount - 1)
        For lX As Integer = 0 To JoyPads.Length - 1
            JoyPads(lX).Description = dgvJoypad.Item(0, lX).Value.ToString
            JoyPads(lX).ButtonCount = CInt(dgvJoypad.Item(1, lX).Value)
            ReDim JoyPads(lX).ResponseCodes(dgvJoypad.ColumnCount - 3)
            For lY As Integer = 0 To JoyPads(lX).ResponseCodes.Length - 1
                If dgvJoypad.Item(lY + 2, lX).Value.GetType Is GetType(System.DBNull) Then
                    JoyPads(lX).ResponseCodes(lY) = -1
                Else
                    JoyPads(lX).ResponseCodes(lY) = CInt(dgvJoypad.Item(lY + 2, lX).Value)
                End If
            Next
        Next
        ' Remote Monitor
        gblnRemoteMonitorServerEnabled = CBool(chkEnableRemoteMonitorServer.Checked)
        gszRemoteMonitorServerAdress = txtRemoteServer.Text
        Return Nothing
    End Function




    Private Sub chkUseBeepExp_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkUseBeepExp.CheckStateChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            chkBeepOnItem.Enabled = CBool(CInt(chkUseBeepExp.CheckState))
        End If
    End Sub

    Private Sub chkUseMATLAB_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkUseMATLAB.CheckStateChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            TextBoxState(txtMATLABServer, CBool(chkUseMATLAB.CheckState))
            TextBoxState(txtMATLABPath, CBool(chkUseMATLAB.CheckState))
        End If
    End Sub

    Private Sub cmbLogMode_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            ToolTip1.SetToolTip(cmbLogMode, VB6.GetItemString(cmbLogMode, cmbLogMode.SelectedIndex))
        End If
    End Sub

    Private Sub cmdApply_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdApply.Click
        SetOptions()
    End Sub

    'Private Sub cmdBeepExp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBeepExp.Click
    '    cmdBeepExp.Enabled = False
    '    Select Case cmbBeepExp.SelectedIndex
    '        Case 0 ' every item
    '            BeepOnEveryItem()
    '        Case 1 ' third last
    '            BeepOnThird()
    '        Case 2 ' second last
    '            BeepOnSecond()
    '        Case 3 ' last item
    '            BeepOnLast()
    '        Case 4 ' end of experiment
    '            BeepOnEnd()
    '        Case 5 ' error in experiment
    '            BeepOnError()
    '        Case 6 ' break
    '            BeepOnBreak()
    '        Case 7 ' end of block
    '            BeepOnBlockEnd()
    '    End Select
    '    cmdBeepExp.Enabled = True
    'End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdMATLABPath_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMATLABPath.Click
        Dim szX, szDir As String

        ' browse for directory
        If Mid(txtMATLABPath.Text, 1, 2) = "\\" Or InStr(1, txtMATLABPath.Text, ":") > 0 Then
            szDir = txtMATLABPath.Text ' absolute path
        Else
            If Mid(txtMATLABPath.Text, 1, 1) = "\" Then szX = "" Else szX = "\"
            szDir = My.Application.Info.DirectoryPath & szX & txtMATLABPath.Text ' relative path
        End If

        Dim dlgBrowse As New FolderBrowserDialog
        'dlgBrowse.RootFolder = Environment.SpecialFolder.Desktop
        dlgBrowse.SelectedPath = szDir
        dlgBrowse.Description = "Pick the path to the MATLAB scripts"
        dlgBrowse.ShowNewFolderButton = False
        If dlgBrowse.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
        szX = dlgBrowse.SelectedPath
        If LCase(Mid(szX, 1, Len(My.Application.Info.DirectoryPath))) = LCase(My.Application.Info.DirectoryPath) Then
            If MsgBox(szX & vbCrLf & "can be represented relative to the application path: " & vbCrLf & My.Application.Info.DirectoryPath & vbCrLf & vbCrLf & "Do you want to set the MATLAB path relative to the application path?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Set MATLAB Path") = MsgBoxResult.Yes Then
                ' set relative path
                txtMATLABPath.Text = Mid(szX, Len(My.Application.Info.DirectoryPath) + 1)
                Exit Sub
            End If
        End If
        ' set absolute path
        txtMATLABPath.Text = szX

    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        If SetOptions() Then Return
        Me.Close()
    End Sub


    Private Sub cmdViWoReconnect_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdViWoReconnect.Click
        Dim szX As String

        If Not IsNumeric(Me.txtViWoPort.Text) Then MsgBox("Port number mut be numeric") : Return

        SetUIBusy()
        ViWo.Disconnect()
        If Len(txtViWoAddress.Text) > 0 Then
            Dim szAddr As String = gszViWoAddress
            Dim lPort As Integer = glViWoPort
            glViWoPort = CInt(Val(txtViWoPort.Text))
            gszViWoAddress = txtViWoAddress.Text
            szX = ViWo.Connect(pbStatus)
            If Len(szX) > 0 Then
                MsgBox("ViWo: " & szX)
                gszViWoAddress = szAddr
                glViWoPort = lPort
            Else
                MsgBox("ViWo: connected to " & gszViWoAddress & ":" & TStr(glViWoPort))
            End If
        End If
        SetUIReady()

    End Sub

    Private Sub frmOptions_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        'Dim KeyCode As Short = eventArgs.KeyCode
        'Dim Shift As Short = eventArgs.KeyData \ &H10000
        'Dim i As Short
        'i = sstOptions.SelectedIndex
        ''handle ctrl+tab to move to the next tab
        'If (Shift And 3) = 2 And KeyCode = System.Windows.Forms.Keys.Tab Then
        '    If i = sstOptions.TabPages.Count() - 1 Then
        '        'last tab so we need to wrap to tab 0
        '        sstOptions.SelectedIndex = 0
        '    Else
        '        'increment the tab
        '        sstOptions.SelectedIndex = sstOptions.SelectedIndex + 1
        '    End If
        'ElseIf (Shift And 3) = 3 And KeyCode = System.Windows.Forms.Keys.Tab Then
        '    If i = 0 Then
        '        'last tab so we need to wrap to tab 1
        '        sstOptions.SelectedIndex = sstOptions.TabPages.Count() - 1
        '    Else
        '        'increment the tab
        '        sstOptions.SelectedIndex = sstOptions.SelectedIndex - 1
        '    End If
        'End If
    End Sub


    Private Sub frmOptions_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        IsInitializing = True
        'Me.Icon = frmMain.Icon
        frmExp.Close()

        ' create controls
        chkAutoBackupLogFileSilent.Enabled=chkAutoBackupLogFile.Checked

        cmbBeepExp.Items.Add("Every item")
        cmbBeepExp.Items.Add("Third last item")
        cmbBeepExp.Items.Add("Second last item")
        cmbBeepExp.Items.Add("Last item")
        cmbBeepExp.Items.Add("End of experiment")
        cmbBeepExp.Items.Add("Error in experiment")
        cmbBeepExp.Items.Add("Break")
        cmbBeepExp.Items.Add("End of Block")
        cmbBeepExp.SelectedIndex = 0

        'cmbBeepExp.Items.Add("Every item")
        'cmbWavExp.Items.Add("Third last item")
        cmbWavExp.Items.Add("Second last item")
        cmbWavExp.Items.Add("Last item")
        cmbWavExp.Items.Add("End of experiment")
        cmbWavExp.Items.Add("Error in experiment")
        cmbWavExp.Items.Add("Break")
        'cmbBeepExp.Items.Add("End of Block")
        cmbWavExp.SelectedIndex = 0

        cmbPriority.Items.Add("Normal")
        cmbPriority.Items.Add("Above Normal")
        cmbPriority.Items.Add("High")
        cmbPriority.Items.Add("Realtime (Administrators)")
        cmbPriority.SelectedIndex = 0

        ' RIB
        cmbComLeft.Items.Add("COM 1")
        cmbComLeft.Items.Add("COM 2")
        cmbComLeft.Items.Add("COM 3")
        cmbComLeft.Items.Add("COM 4")
        cmbComRight.Items.Add("COM 1")
        cmbComRight.Items.Add("COM 2")
        cmbComRight.Items.Add("COM 3")
        cmbComRight.Items.Add("COM 4")
        ' STIM
        For lX As Integer = 0 To 15
            cmbLogMode.Items.Add(TStr(lX))
        Next
        VB6.SetItemString(cmbLogMode, 0, "0: No logging at all")
        VB6.SetItemString(cmbLogMode, 1, "1: Log to stimlog.csv on Init, NewStimulus, MatlabStimulus, Matlab and Assemble")
        VB6.SetItemString(cmbLogMode, 2, "2: Log to log list on Init, NewStimulus, MatlabStimulus, Matlab and Assemble")
        VB6.SetItemString(cmbLogMode, 4, "4: Log gen. info to log list on Init, RegisterChannel and BackupLogFile")
        VB6.SetItemString(cmbLogMode, 8, "8: Log gen. info to logfile ID_DATE_TIME.csv on Init, RegisterChannel and Log")
        VB6.SetItemString(cmbLogMode, 15, "15: Log everything")
        
        ' MATLAB
        chkUseMATLAB.CheckState = DirectCast(-CInt(gblnUseMATLAB), CheckState)
        txtMATLABServer.Text = gszMATLABServer
        txtMATLABPath.Text = gszMATLABPath
        TextBoxState(txtMATLABServer, gblnUseMATLAB)
        TextBoxState(txtMATLABPath, gblnUseMATLAB)

        ' MATLAB Path
        If Strings.Right(My.Application.Info.DirectoryPath, Len("\bin")) = "\bin" Then
            lblMATLABPath.Text = lblMATLABPath.Text & vbCrLf & vbCrLf & _
              Strings.Left(My.Application.Info.DirectoryPath, Len(My.Application.Info.DirectoryPath) - Len("\bin")) & "\" & vbCrLf & _
              My.Application.Info.DirectoryPath & "\" & vbCrLf & _
              Strings.Left(My.Application.Info.DirectoryPath, Len(My.Application.Info.DirectoryPath) - Len("\bin")) & "\obj\Release\" & vbCrLf & _
              Strings.Left(My.Application.Info.DirectoryPath, Len(My.Application.Info.DirectoryPath) - Len("\bin")) & "\obj\Debug\"
        Else
            lblMATLABPath.Text = lblMATLABPath.Text & vbCrLf & My.Application.Info.DirectoryPath & "\"
        End If
        ToolTip1.SetToolTip(lblMATLABPath, lblMATLABPath.Text)

        txtRIBPath.Text = gszRIBPath
        ' RIB Path
        If Strings.Right(My.Application.Info.DirectoryPath, Len("\bin")) = "\bin" Then
            lblRIBPath.Text = lblRIBPath.Text & vbCrLf & vbCrLf & _
              Strings.Left(My.Application.Info.DirectoryPath, Len(My.Application.Info.DirectoryPath) - Len("\bin")) & "\" & vbCrLf & _
              My.Application.Info.DirectoryPath & "\" & vbCrLf & _
              Strings.Left(My.Application.Info.DirectoryPath, Len(My.Application.Info.DirectoryPath) - Len("\bin")) & "\obj\Release\" & vbCrLf & _
              Strings.Left(My.Application.Info.DirectoryPath, Len(My.Application.Info.DirectoryPath) - Len("\bin")) & "\obj\Debug\"
        Else
            lblRIBPath.Text = lblRIBPath.Text & vbCrLf & My.Application.Info.DirectoryPath & "\"
        End If
        ToolTip1.SetToolTip(lblRIBPath, lblRIBPath.Text)


        ' RIB2
        txtRIB2Path.Text = gszRIB2Path
        ' RIB2 Path
        If Strings.Right(My.Application.Info.DirectoryPath, Len("\bin")) = "\bin" Then
            lblRIB2Path.Text = lblRIB2Path.Text & vbCrLf & vbCrLf & _
              Strings.Left(My.Application.Info.DirectoryPath, Len(My.Application.Info.DirectoryPath) - Len("\bin")) & "\" & vbCrLf & _
              My.Application.Info.DirectoryPath & "\" & vbCrLf & _
              Strings.Left(My.Application.Info.DirectoryPath, Len(My.Application.Info.DirectoryPath) - Len("\bin")) & "\obj\Release\" & vbCrLf & _
              Strings.Left(My.Application.Info.DirectoryPath, Len(My.Application.Info.DirectoryPath) - Len("\bin")) & "\obj\Debug\"
        Else
            lblRIB2Path.Text = lblRIB2Path.Text & vbCrLf & My.Application.Info.DirectoryPath & "\"
        End If
        ToolTip1.SetToolTip(lblRIB2Path, lblRIB2Path.Text)


        txtNICPath.Text = gszNICPath
        ' NIC Path
        If Strings.Right(My.Application.Info.DirectoryPath, Len("\bin")) = "\bin" Then
            lblNICPath.Text = lblNICPath.Text & vbCrLf & vbCrLf & _
              Strings.Left(My.Application.Info.DirectoryPath, Len(My.Application.Info.DirectoryPath) - Len("\bin")) & "\" & vbCrLf & _
              My.Application.Info.DirectoryPath & "\" & vbCrLf & _
              Strings.Left(My.Application.Info.DirectoryPath, Len(My.Application.Info.DirectoryPath) - Len("\bin")) & "\obj\Release\" & vbCrLf & _
              Strings.Left(My.Application.Info.DirectoryPath, Len(My.Application.Info.DirectoryPath) - Len("\bin")) & "\obj\Debug\"
        Else
            lblNICPath.Text = lblNICPath.Text & vbCrLf & My.Application.Info.DirectoryPath & "\"
        End If
        ToolTip1.SetToolTip(lblNICPath, lblNICPath.Text)


        ' set size
        If grectOptions.Width < Me.MinimumSize.Width Then grectOptions.Width = Me.Size.Width
        Me.Width = grectOptions.Width
        If grectOptions.Height < Me.MinimumSize.Height Then grectOptions.Height = Me.Size.Height
        Me.Height = grectOptions.Height
        ' move window
        If grectOptions.Left + 0.25 * Me.Width > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width Then
            grectOptions.Left = CInt(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - 0.25 * Me.Width)
        End If
        If grectOptions.Left + 0.75 * Me.Width < 0 Then
            grectOptions.Left = CInt(-0.75 * Me.Width)
        End If
        If grectOptions.Top + 0.25 * Me.Height > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height Then
            grectOptions.Top = CInt(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 0.25 * Me.Height)
        End If
        If grectOptions.Top < 0 Then
            grectOptions.Top = 0
        End If
        Me.SetBounds(grectOptions.Left, grectOptions.Top, 0, 0, _
                    Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
        ' set values
        ' general
        chkAutoBackupLogFile.CheckState = DirectCast(-CInt(gblnAutoBackupLogFile), CheckState)
        chkAutoBackupLogFileSilent.CheckState = DirectCast(-CInt(gblnAutoBackupLogFileSilent), CheckState)
        chkAutoBackupItemList.CheckState = DirectCast(-CInt(gblnAutoBackupItemList), CheckState)
        chkUseFileNaming.CheckState = DirectCast(-CInt(gblnUseFileNaming), CheckState)
        chkUseBeepExp.CheckState = DirectCast(-CInt(glFlagBeepExp > 0), CheckState)
        chkPlayWaveExp.CheckState = DirectCast(-CInt(gblnPlayWaveExp), CheckState)
        chkBeepOnItem.Enabled = glFlagBeepExp > 0
        chkBeepOnItem.CheckState = DirectCast(-CInt((glFlagBeepExp And 2) <> 0), CheckState)
        chkNotShuffledOnExpStart.CheckState = DirectCast(-CInt((glWarningSwitches And WarningSwitches.wsNotShuffledOnExpStart) <> 0), CheckState)
        chkNotRepOnExpStart.CheckState = DirectCast(-CInt((glWarningSwitches And WarningSwitches.wsNotRepOnExpStart) <> 0), CheckState)
        chkExpPerformedOnShuffle.CheckState = DirectCast(-CInt((glWarningSwitches And WarningSwitches.wsExpPerformedOnShuffle) <> 0), CheckState)
        chkResponseItemListOnExpRep.CheckState = DirectCast(-CInt((glWarningSwitches And WarningSwitches.wsResponseItemListOnExpRep) <> 0), CheckState)
        chkDisableSetOptimalColWidth.CheckState = DirectCast(-CInt(gblnDisableSetOptimalColWidth), CheckState)
        chkCheckForUpdates.CheckState = DirectCast(-CInt(gblnCheckForUpdates), CheckState)
        If gUpdateInterval < UpdateInterval.Minimum Then gUpdateInterval = CInt(UpdateInterval.Minimum)
        If gUpdateInterval > UpdateInterval.Maximum Then gUpdateInterval = CInt(UpdateInterval.Maximum)
        UpdateInterval.Value = gUpdateInterval
        UpdateInterval.Enabled = chkCheckForUpdates.Checked
        cmbPriority.SelectedIndex = glPriority
        txtOptionsFile.Text = gszOptionsFile

        ' Audio (Player)
        txtPlayerFileName.Text = gszPlayerFileName
        txtYAMIAddr.Text = gszPlayerNetAddr
        txtYAMIPort.Text = TStr(glPlayerNetPort)
        txtLocalYAMIAddr.Text = gszLocalNetAddr
        txtLocalYAMIPort.Text = TStr(glLocalNetPort)
        chkPlayerASIO.CheckState = DirectCast(-CInt(CBool(INIOptions.glPlayerFlags And Output.PLAYERFLAGS.pfASIO)), CheckState)
        chkPlayerNoADC.CheckState = DirectCast(-CInt(CBool(INIOptions.glPlayerFlags And Output.PLAYERFLAGS.pfNoADC)), CheckState)
        chkPlayerKillOnDisconnect.CheckState = DirectCast(-CInt(CBool(INIOptions.glPlayerFlags And Output.PLAYERFLAGS.pfKillondisconnect)), CheckState)
        chkPlayerNoGUI.CheckState = DirectCast(-CInt(CBool(INIOptions.glPlayerFlags And Output.PLAYERFLAGS.pfnogui)), CheckState)
        chkPlayerFreeze.CheckState = DirectCast(-CInt(CBool(INIOptions.glPlayerFlags And Output.PLAYERFLAGS.pfFreezeOnStimulation)), CheckState)
        For lX As Integer = 2 To PLAYER_MAXCHANNELS
            cmbPlayerChannels.Items.Add(TStr(lX))
        Next
        If glPlayerChannels < 2 Or glPlayerChannels > PLAYER_MAXCHANNELS Then glPlayerChannels = PLAYER_MAXCHANNELS
        cmbPlayerChannels.SelectedIndex = glPlayerChannels - 2
        For lX As Integer = 0 To 31
            cmbPlayerDevice.Items.Add(TStr(lX))
            cmbPlayerADCDevice.Items.Add(TStr(lX))
        Next
        'Fill Player Devices
        FillPlayerDevices()
        If glPlayerAudioDevice < 0 Or glPlayerAudioDevice > 31 Then glPlayerAudioDevice = 0
        If glPlayerADCAudioDevice < 0 Or glPlayerADCAudioDevice > 31 Then glPlayerADCAudioDevice = 0
        cmbPlayerDevice.SelectedIndex = glPlayerAudioDevice
        cmbPlayerADCDevice.SelectedIndex = glPlayerADCAudioDevice
        For lX As Integer = 0 To 31
            cmbPlayerMIDIOutDevice.Items.Add(TStr(lX))
        Next
        cmbPlayerMIDIOutDevice.SelectedIndex = glPlayerMIDIOutDevice
        For lX As Integer = 0 To 31
            cmbPlayerMIDIInDevice.Items.Add(TStr(lX))
        Next
        cmbPlayerMIDIInDevice.SelectedIndex = glPlayerMIDIInDevice
        txtDACName.Text = gszDACName
        txtADCName.Text = gszADCName
        rdbAudioName.Checked = CBool(gbAudioName)
        rdbAudioIndex.Checked = Not CBool(gbAudioName)

        If glPlayerHPLeft <= glPlayerChannels Then cmbPlayerHPL.SelectedIndex = glPlayerHPLeft - 1 Else cmbPlayerHPL.SelectedIndex = 0 'hp left
        If glPlayerHPRight <= glPlayerChannels Then cmbPlayerHPR.SelectedIndex = glPlayerHPRight - 1 Else cmbPlayerHPR.SelectedIndex = 1 'hp right
        If glDataChannel <= glPlayerChannels Then cmbDataChannel.SelectedIndex = glDataChannel Else cmbDataChannel.SelectedIndex = 0 'data channel (0: none)
        If glTriggerChannel <= glPlayerChannels Then cmbTriggerChannel.SelectedIndex = glTriggerChannel Else cmbTriggerChannel.SelectedIndex = 0 'trigger channel (0: none)
        'chkPlayerOSC.CheckState = DirectCast(-CInt(gbPlayerOSC), CheckState)

        ' Audio (Unity)
        txtUnityAddr.Text = gszUnityNetAddr
        txtUnityPort.Text = TStr(glUnityNetPort)
        txtUnityLocalPort.Text = TStr(glUnityLocalNetPort)
        ToolTip1.SetToolTip(lblUnityLocalPort, txtLocalYAMIAddr.Text)
        ToolTip1.SetToolTip(lblLocalViwoAddr, txtLocalYAMIAddr.Text)

        ' STIM
        For lX As Integer = 0 To cmbLogMode.Items.Count - 1
            If CInt(Val(VB6.GetItemString(cmbLogMode, lX))) = glLogMode Then cmbLogMode.SelectedIndex = lX
        Next
        If cmbLogMode.SelectedIndex = -1 Then
            MsgBox("Unsupported Logging Mode found." & vbCrLf & "Logging Mode will be set to 'log everything'", MsgBoxStyle.Information)
            cmbLogMode.SelectedIndex = cmbLogMode.Items.Count - 1
        End If
        ' RIB
        cmbComLeft.SelectedIndex = glCOMLeft - 1
        cmbComRight.SelectedIndex = glCOMRight - 1
        txtRIBServer.Text = gszRIBServer
        chkSimulation.CheckState = DirectCast(-CInt(gblnRIBSimulation), CheckState)
        ' RIB2
        txtRIB2Device.Text = gszRIB2DeviceName
        chkRIB2Simulation.CheckState = DirectCast(-CInt(gblnRIB2Simulation), CheckState)
        ' CSV Export
        txtCSVDelimiter.Text = Chr(glCSVDelimiter)
        txtCSVQuota.Text = Chr(glCSVQuota)
        ckbIncludeHeadersInClipboard.CheckState = DirectCast(-CInt(gblnIncludeHeadersInClipboard), CheckState)

        ' Tracker
        cmbTRCom.Items.Add("Not active")
        For lX As Integer = 0 To 3
            cmbTRCom.Items.Add("COM " & TStr(lX + 1))
        Next
        Select Case glTrackerMode
            Case 0
                rdbTrackerDisabled.Checked = True
                'rdbTrackerYAMI.Checked = False
                'rdbTrackerViWo.Checked = False
            Case 1
                'rdbTrackerDisabled.Checked = False
                rdbTrackerYAMI.Checked = True
                'rdbTrackerViWo.Checked = False
            Case 2
                'rdbTrackerDisabled.Checked = False
                'rdbTrackerYAMI.Checked = False
                rdbTrackerViWo.Checked = True
            Case 3
                rdbTrackerOptitrack.Checked = True
        End Select
        If glTrackerCOM < 0 Or glTrackerCOM > 4 Then glTrackerCOM = 0
        cmbTRCom.SelectedIndex = glTrackerCOM
        cmbTRBaudrate.Items.Add("9600")
        cmbTRBaudrate.Items.Add("19200")
        cmbTRBaudrate.Items.Add("57600")
        cmbTRBaudrate.Items.Add("115200")
        Dim lTIdx As Integer
        For lTIdx = 0 To cmbTRBaudrate.Items.Count - 1
            If CInt(Val(VB6.GetItemString(cmbTRBaudrate, lTIdx))) = glTrackerBaudrate Then Exit For
        Next
        If lTIdx = cmbTRBaudrate.Items.Count Then
            glTrackerBaudrate = CInt(Val(VB6.GetItemString(cmbTRBaudrate, 0))) : lTIdx = 0
        End If
        cmbTRBaudrate.SelectedIndex = lTIdx
        cmbTRSensorCount.Items.Add("1")
        cmbTRSensorCount.Items.Add("2")
        cmbTRSensorCount.SelectedIndex = glTrackerSensorCount - 1
        chkTRSimulation.CheckState = DirectCast(-CInt(gblnTrackerSimulation), CheckState)
        txtTRSettingsInterval.Text = TStr(glTrackerSettingsInterval)
        chkTRLog.CheckState = DirectCast(-CInt(gblnTrackerLog), CheckState)

        ' Turntable
        Select Case glTTMode
            Case 0
                rdbTTDisabled.Checked=True
            Case 1
                rdbTTFourAudio.Checked=True
            Case 2
                rdbTTOutline.Checked = True
            Case 3
                rdbTTImperial.Checked = True
        End Select
        cmbTTLPT.Items.Add("Not active")
        cmbTTLPT.Items.Add("LPT 1")
        cmbTTLPT.Items.Add("LPT 2")
        If glTTLPT < 0 Or glTTLPT > 2 Then glTTLPT = 0
        cmbTTLPT.SelectedIndex = glTTLPT
        txtTTOffset.Text = TStr(gsngTTOffset)
        txtTT4AOffset.Text = TStr(gsngTT4AOffset)
        numTT4ABrakeTimer.Value=glTT4aBrakeTimer
        ckbTT4AAllowPreRotation.CheckState = DirectCast(-CInt(gblnAllowPreRotation), CheckState)

        ' ViWo
        txtViWoAddress.Text = gszViWoAddress
        txtViWoPort.Text = TStr(glViWoPort)
        'chkViWoOSC.CheckState = DirectCast(-CInt(gbViWoOSC), CheckState)
        chkViWoOSC.Text = "Comply with OSC standard"

        ' Joypad
        Dim szArr(0) As String
        Dim lArr(0) As Integer
        
        '
        ' **** L O A D E R   L O C K   /  E X C E P T I O N  T H R O W N ? ? ?  *****
        '
        'IF YOU HAVE A LOADER LOCK  WARNING / EXCEPTION THROWN AT THIS POINT PLEASE FOLLOW THESE STEPS TO DISABLE THEM:
        '####   
        '####   Open Exception Settings in Visual Basic, navigate to the menu "Break When Thrown", then
        '####   first check and then uncheck the point "Managed Debugging Asistants"
        '####   
        '

        Dim szErr As String = HUI.GetDevicesList(szArr, lArr)
        If Len(szErr) <> 0 Then
            MsgBox(szErr, MsgBoxStyle.Information, "List of joypads")
        Else
            For lX As Integer = 0 To szArr.Length - 1
                lstJoypads.Items.Add(Trim(szArr(lX)) & "; " & TStr(lArr(lX)) & " buttons")
            Next
        End If
        Dim lJoyButtonMax As Integer = 0
        For lX As Integer = 0 To JoyPads.Length - 1
            If JoyPads(lX).ResponseCodes.Length > lJoyButtonMax Then _
                lJoyButtonMax = JoyPads(lX).ResponseCodes.Length
        Next
        dgvJoypad.ColumnCount = 2 + lJoyButtonMax
        dgvJoypad.Columns(0).HeaderText = "Description"
        dgvJoypad.Columns(0).ValueType = GetType(String)
        dgvJoypad.Columns(0).ReadOnly = True
        dgvJoypad.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvJoypad.Columns(1).HeaderText = "Buttons"
        dgvJoypad.Columns(1).ValueType = GetType(String)
        dgvJoypad.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        For lX As Integer = 0 To lJoyButtonMax - 1
            dgvJoypad.Columns(lX + 2).HeaderText = TStr(lX)
            dgvJoypad.Columns(lX + 2).ValueType = GetType(Integer)
            dgvJoypad.Columns(lX + 2).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        dgvJoypad.RowCount = JoyPads.Length
        For lX As Integer = 0 To JoyPads.Length - 1
            dgvJoypad.Item(0, lX).Value = JoyPads(lX).Description
            dgvJoypad.Item(1, lX).Value = JoyPads(lX).ButtonCount
            For lY As Integer = 0 To JoyPads(lX).ResponseCodes.Length - 1
                If JoyPads(lX).ResponseCodes(lY) = -1 Then
                    dgvJoypad.Item(lY + 2, lX).Value = ""
                Else
                    dgvJoypad.Item(lY + 2, lX).Value = JoyPads(lX).ResponseCodes(lY)
                End If
            Next
        Next
        AddHandler HUI.Callback, AddressOf DirectXEvent

        ' Remote Monitor
        chkEnableRemoteMonitorServer.CheckState = DirectCast(-CInt(gblnRemoteMonitorServerEnabled), CheckState)
        txtRemoteServer.Text = gszRemoteMonitorServerAdress

        'sstOptions.TabPages.Remove(sstOptions.TabPages.Item(0)) 'hide tab
        'sstOptions.TabPages.Insert(0, _sstOptions_TabPage0) 'show tab

        sstOptions.SelectedIndex = 0
        IsInitializing = False

    End Sub

    Private Sub frmOptions_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        grectOptions.Left = Me.Left
        grectOptions.Top = Me.Top
        grectOptions.Height = Me.Height
        grectOptions.Width = Me.Width
        HUI.ReleaseDevice()
        RemoveHandler HUI.Callback, AddressOf Me.DirectXEvent
        ' save parameter to file
        INIOptions.WriteFile(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\ExpSuite\" & My.Application.Info.Title & "\" & My.Application.Info.Title & ".ini")

    End Sub

    Public Sub DirectXEvent(ByVal bButtons() As Byte, ByVal lXDir As Integer, ByVal lYDir As Integer, ByVal lZDir As Integer)
        Dim szX As String = ""
        If Not IsNothing(bButtons) Then
            szX = "Real Buttons: "
            For lX As Integer = 0 To bButtons.Length - 1
                If bButtons(lX) > 0 Then szX = szX & TStr(lX) & " "
            Next
            szX = szX & vbCrLf
        End If
        szX = szX & "Emulated Buttons: "
        If lXDir < -100 Then szX = szX & " -2"
        If lXDir > 100 Then szX = szX & " -3"
        If lYDir < -100 Then szX = szX & " -4"
        If lYDir > 100 Then szX = szX & " -5"
        If lZDir < -100 Then szX = szX & " -6"
        If lZDir > 100 Then szX = szX & " -7"
        szX = szX & vbCrLf & "X: " & TStr(lXDir)
        szX = szX & vbCrLf & "Y: " & TStr(lYDir)
        szX = szX & vbCrLf & "Z: " & TStr(lZDir)
        LabelText(lblJoyInfo, szX)
    End Sub

    Private Sub cmdJoypadAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJoypadAdd.Click
        Dim szItem As String = CType(lstJoypads.SelectedItem, String)
        If IsNothing(szItem) Then Return
        If InStr(szItem, ";") < 0 Then Return
        Dim szDesc As String = Mid(szItem, 1, InStr(szItem, ";") - 1)
        Dim lButtons As Integer = CInt(Mid(szItem, InStr(szItem, ";") + 1, InStr(szItem, "buttons") - 1 - InStr(szItem, ";") - 1))
        For lX As Integer = 0 To dgvJoypad.RowCount - 1
            If dgvJoypad.Item(0, lX).Value.ToString = szDesc Then MsgBox("Joypad already in the list") : Return
        Next
        IsInitializing = True
        With dgvJoypad
            .Rows.Add()
            .Columns(0).ReadOnly = False
            .Item(0, .RowCount - 1).Value = szDesc
            .Columns(0).ReadOnly = True
            .Item(1, .RowCount - 1).Value = lButtons
            For lX As Integer = 0 To .ColumnCount - 3
                .Item(lX + 2, .RowCount - 1).Value = Nothing
            Next
        End With
        IsInitializing = False
    End Sub

    Private Sub cmdJoypadRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJoypadRemove.Click
        If IsNothing(dgvJoypad.SelectedCells) Then Return
        If dgvJoypad.CurrentCellAddress.Y = 0 Then Return
        dgvJoypad.Rows.RemoveAt(dgvJoypad.CurrentCellAddress.Y)
    End Sub

    Private Sub lstJoypads_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstJoypads.SelectedIndexChanged
        If IsInitializing Then Return
        HUI.ReleaseDevice()
        Dim szErr As String = HUI.SetDevice(Me.Handle, lstJoypads.SelectedIndex)
        If Len(szErr) > 0 Then
            MsgBox(szErr, MsgBoxStyle.Critical, "Set Device: Error")
            HUI.ReleaseDevice()
            Return
        End If

    End Sub



    Private Sub cmdRIBPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRIBPath.Click
        Dim szX, szDir As String

        ' browse for directory
        If Mid(txtRIBPath.Text, 1, 2) = "\\" Or InStr(1, txtRIBPath.Text, ":") > 0 Then
            szDir = lblRIBPath.Text ' absolute path
        Else
            If Mid(txtRIBPath.Text, 1, 1) = "\" Then szX = "" Else szX = "\"
            szDir = My.Application.Info.DirectoryPath & szX & txtRIBPath.Text ' relative path
        End If

        Dim dlgBrowse As New FolderBrowserDialog
        'dlgBrowse.RootFolder = Environment.SpecialFolder.Desktop
        dlgBrowse.SelectedPath = szDir
        dlgBrowse.Description = "Pick the path to the RIB files"
        dlgBrowse.ShowNewFolderButton = False
        If dlgBrowse.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
        szX = dlgBrowse.SelectedPath
        If LCase(Mid(szX, 1, Len(My.Application.Info.DirectoryPath))) = LCase(My.Application.Info.DirectoryPath) Then
            If MsgBox(szX & vbCrLf & "can be represented relative to the application path: " & vbCrLf & _
              My.Application.Info.DirectoryPath & vbCrLf & vbCrLf & "Do you want to set the RIB files path relative to the application path?", _
              MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Set MATLAB Path") = MsgBoxResult.Yes Then
                ' set relative path
                txtRIBPath.Text = Mid(szX, Len(My.Application.Info.DirectoryPath) + 1)
                Exit Sub
            End If
        End If
        ' set absolute path
        txtRIBPath.Text = szX
    End Sub

    Private Sub cmdNICPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNICPath.Click
        Dim szX, szDir As String

        ' browse for directory
        If Mid(txtNICPath.Text, 1, 2) = "\\" Or InStr(1, txtNICPath.Text, ":") > 0 Then
            szDir = lblNICPath.Text ' absolute path
        Else
            If Mid(txtNICPath.Text, 1, 1) = "\" Then szX = "" Else szX = "\"
            szDir = My.Application.Info.DirectoryPath & szX & txtNICPath.Text ' relative path
        End If

        Dim dlgBrowse As New FolderBrowserDialog
        'dlgBrowse.RootFolder = Environment.SpecialFolder.Desktop
        dlgBrowse.SelectedPath = szDir
        dlgBrowse.Description = "Pick the path to the NIC files"
        dlgBrowse.ShowNewFolderButton = False
        If dlgBrowse.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
        szX = dlgBrowse.SelectedPath
        If LCase(Mid(szX, 1, Len(My.Application.Info.DirectoryPath))) = LCase(My.Application.Info.DirectoryPath) Then
            If MsgBox(szX & vbCrLf & "can be represented relative to the application path: " & vbCrLf & _
              My.Application.Info.DirectoryPath & vbCrLf & vbCrLf & "Do you want to set the NIC files path relative to the application path?", _
              MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Set MATLAB Path") = MsgBoxResult.Yes Then
                ' set relative path
                txtNICPath.Text = Mid(szX, Len(My.Application.Info.DirectoryPath) + 1)
                Exit Sub
            End If
        End If
        ' set absolute path
        txtNICPath.Text = szX
    End Sub

    Private Sub cmdRIB2Path_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRIB2Path.Click
        Dim szX, szDir As String

        ' browse for directory
        If Mid(txtRIB2Path.Text, 1, 2) = "\\" Or InStr(1, txtRIB2Path.Text, ":") > 0 Then
            szDir = lblRIB2Path.Text ' absolute path
        Else
            If Mid(txtRIB2Path.Text, 1, 1) = "\" Then szX = "" Else szX = "\"
            szDir = My.Application.Info.DirectoryPath & szX & txtRIB2Path.Text ' relative path
        End If

        Dim dlgBrowse As New FolderBrowserDialog
        'dlgBrowse.RootFolder = Environment.SpecialFolder.Desktop
        dlgBrowse.SelectedPath = szDir
        dlgBrowse.Description = "Pick the path to the RIB2 files"
        dlgBrowse.ShowNewFolderButton = False
        If dlgBrowse.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
        szX = dlgBrowse.SelectedPath
        If LCase(Mid(szX, 1, Len(My.Application.Info.DirectoryPath))) = LCase(My.Application.Info.DirectoryPath) Then
            If MsgBox(szX & vbCrLf & "can be represented relative to the application path: " & vbCrLf & _
              My.Application.Info.DirectoryPath & vbCrLf & vbCrLf & "Do you want to set the RIB2 files path relative to the application path?", _
              MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Set MATLAB Path") = MsgBoxResult.Yes Then
                ' set relative path
                txtRIB2Path.Text = Mid(szX, Len(My.Application.Info.DirectoryPath) + 1)
                Exit Sub
            End If
        End If
        ' set absolute path
        txtRIB2Path.Text = szX
    End Sub

    Private Sub cmdYAMIPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdYAMIPath.Click

        ' set dialog
        Dim dlgBrowse As New OpenFileDialog
        dlgBrowse.FileName = txtPlayerFileName.Text
        If Len(dlgBrowse.FileName) > 0 Then dlgBrowse.InitialDirectory = IO.Path.GetDirectoryName(dlgBrowse.FileName)
        dlgBrowse.Title = "Set YAMI batch file"
        dlgBrowse.Filter = "Batch Files (*.bat)|*.bat|All Files (*.*)|*.*"
        'dlgBrowse.FilterIndex = 0
        If dlgBrowse.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
        txtPlayerFileName.Text = dlgBrowse.FileName

    End Sub

    Private Sub chkCheckForUpdates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCheckForUpdates.CheckedChanged
        UpdateInterval.Enabled = chkCheckForUpdates.Checked
    End Sub


    Private Sub cmdOptionsDir_Click(sender As System.Object, e As System.EventArgs) Handles cmdOptionsDir.Click
        Shell("explorer " & Chr(34) & Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\ExpSuite\" & My.Application.Info.Title, AppWinStyle.NormalFocus)
    End Sub

    Private Sub cmbWaveEndExp_Click(sender As System.Object, e As System.EventArgs) Handles cmbWaveEndExp.Click
        'PlayWaveOnEnd()
        cmbWavExp.Enabled = False
        Select Case cmbWavExp.SelectedIndex
            'Case 0 ' every item
            'playwaEveryItem()
            'Case 0 ' third last
            '    PlayWaveOnThirdLastItem()
            Case 0 ' second last
                PlayWaveOnSecondLastItem()
            Case 1 ' last item
                PlayWaveOnLastItem()
            Case 2 ' end of experiment
                PlayWaveOnEnd()
            Case 3 ' error in experiment
                PlayWaveOnError()
            Case 4 ' break
                PlayWaveOnBreak()
                'Case 7 ' end of block
                '    BeepOnBlockEnd()
        End Select
        cmbWavExp.Enabled = True
    End Sub

    Private Sub chkPlayWaveExp_Click(sender As Object, e As System.EventArgs) Handles chkPlayWaveExp.Click
        If chkPlayWaveExp.Checked = True Then
            MsgBox("A notifying wave file is played via your default sound card when entering a break or finishing the experiment." & vbCrLf & vbCrLf & _
                   "Please make sure that your default sound device DOES NOT stimulate via the headphones that are used for the experiment!!! You can use the ""Test"" button to check which device is used.", MsgBoxStyle.Exclamation, "Play wave after experiment")
        End If
    End Sub


    Private Sub chkViWoOSC_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkViWoOSC.CheckedChanged
        chkViWoOSC.Text = "Comply with OSC standard *" & vbCrLf & vbCrLf & "* Press 'OK' or 'Apply' to effect changes!"
    End Sub

    Private Sub txtLocalYAMIAddr_Leave(sender As Object, e As System.EventArgs) Handles txtLocalYAMIAddr.Leave
        ToolTip1.SetToolTip(lblUnityLocalPort, txtLocalYAMIAddr.Text)
        ToolTip1.SetToolTip(lblLocalViwoAddr, txtLocalYAMIAddr.Text)
    End Sub

    Private Sub UpdateTrackerOptions() Handles rdbTrackerDisabled.CheckedChanged, rdbTrackerYAMI.CheckedChanged, rdbTrackerViWo.CheckedChanged, rdbTrackerOptitrack.CheckedChanged
        pTrackerYAMI.Enabled = rdbTrackerYAMI.Checked
        pTrackerYAMI.Visible = rdbTrackerYAMI.Checked
        chkTRLog.Enabled = Not rdbTrackerDisabled.Checked
        cmbTRSensorCount.Enabled = Not (rdbTrackerDisabled.Checked Or rdbTrackerOptitrack.Checked)
    End Sub

    Private Sub cmbPlayerChannels_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbPlayerChannels.SelectedIndexChanged

        Dim lPlayerHPLChannel As Integer = cmbPlayerHPL.SelectedIndex
        Dim lPlayerHPRChannel As Integer = cmbPlayerHPR.SelectedIndex
        Dim lDataChannel As Integer = cmbDataChannel.SelectedIndex
        Dim lTriggerChannel As Integer = cmbTriggerChannel.SelectedIndex

        cmbPlayerHPL.Items.Clear()
        cmbPlayerHPR.Items.Clear()
        cmbDataChannel.Items.Clear()
        cmbTriggerChannel.Items.Clear()

        cmbDataChannel.Items.Add("none")
        cmbTriggerChannel.Items.Add("none")
        For lX As Integer = 1 To cmbPlayerChannels.SelectedIndex + 2
            cmbPlayerHPL.Items.Add(TStr(lX))
            cmbPlayerHPR.Items.Add(TStr(lX))
            cmbDataChannel.Items.Add(TStr(lX))
            cmbTriggerChannel.Items.Add(TStr(lX))
        Next

        If lPlayerHPLChannel <= cmbPlayerChannels.SelectedIndex + 1 Then cmbPlayerHPL.SelectedIndex = lPlayerHPLChannel Else cmbPlayerHPL.SelectedIndex = 0 'left channel 
        If lPlayerHPRChannel <= cmbPlayerChannels.SelectedIndex + 1 Then cmbPlayerHPR.SelectedIndex = lPlayerHPRChannel Else cmbPlayerHPR.SelectedIndex = 0 'right channel 
        If lDataChannel <= cmbPlayerChannels.SelectedIndex + 2 Then cmbDataChannel.SelectedIndex = lDataChannel Else cmbDataChannel.SelectedIndex = 0 'data channel (0: none)
        If lTriggerChannel <= cmbPlayerChannels.SelectedIndex + 2 Then cmbTriggerChannel.SelectedIndex = lTriggerChannel Else cmbTriggerChannel.SelectedIndex = 0 'trigger channel (0: none)

    End Sub

    Private Sub rdbAudio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdbAudioIndex.CheckedChanged, chkPlayerNoADC.CheckedChanged, rdbAudioName.CheckedChanged
        cmbPlayerADCDevice.Enabled = Not (chkPlayerNoADC.Checked) And rdbAudioIndex.Checked
        cmbPlayerDevice.Enabled = rdbAudioIndex.Checked
        txtDACName.Enabled = rdbAudioName.Checked
        txtADCName.Enabled = Not (chkPlayerNoADC.Checked) And rdbAudioName.Checked
        If rdbAudioName.Checked Then chkPlayerASIO.Checked = True 'enable ASIO
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnListDevices.Click
        Dim a As String = Nothing
        Dim idx As RegistryKey = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\asio")

        If idx IsNot Nothing Then
            Dim names As String() = idx.GetSubKeyNames

            Dim s As String = Nothing
            For Each s In names
                a = a & "ASIO:" & s & vbCrLf
            Next s
        End If

        'ShowDeviceCaps

        Dim wc As New WAVEOUTCAPS

        '  MsgBox("Number of Wave Devices: " & waveOutGetNumDevs(), , "WAVE DEVICES")
        '   a = a & vbCrLf

        For i As Integer = 0 To CInt(waveOutGetNumDevs() - 1)
            ' waveOutGetDevCaps(i, wc, Len(wc))
            waveOutGetDevCaps(i, wc, System.Runtime.InteropServices.Marshal.SizeOf(wc))
            'MsgBox("MID = " & wc.wMid & Chr(13) & "PID = " & wc.wPid & Chr(13) & "Version = " &
            'wc.vDriverVersion & Chr(13) & "Name = " & wc.szPname & Chr(13) & "Formats = " & wc.dwFormats &
            'Chr(13) & "Channels = " & wc.wChannels, , "Device ID = " & i + 1)
            a = a & "MMIO:" & wc.szPname & vbCrLf
        Next i

        If a = Nothing Then a = "No devices found!"

        MsgBox(a)
    End Sub


    'Private Declare Function waveOutGetNumDevs Lib "winmm.dll" () As Long
    Private Sub FillPlayerDevices()
        Dim idx As RegistryKey = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\ASIO")
        If idx IsNot Nothing Then
            Dim names As String() = idx.GetSubKeyNames

            Dim s As String ', a As String = ""

            'ASIO
            For Each s In names
                ' a = a & "ASIO:" & s & vbCrLf
                cmbDACName.Items.Add("ASIO:" & s)
            Next s
        End If

        'MMIO
        Dim wc As New WAVEOUTCAPS
        Dim huhu As Integer = System.Runtime.InteropServices.Marshal.SizeOf(wc)
        Dim huh2 As Integer = Len(wc)
        For i As Integer = 0 To CInt(waveOutGetNumDevs() - 1)
            waveOutGetDevCaps(i, wc, System.Runtime.InteropServices.Marshal.SizeOf(wc))
            'a = "MMIO:" & a & wc.szPname & vbCrLf
            cmbDACName.Items.Add("MMIO:" & wc.szPname)
        Next i

 '       '@Piotr: ab hier auskommentieren, das hab ich auch probiert #########################
 '       Dim Scope As New ManagementScope("\\.\ROOT\cimv2")

 '       'Get a result of WML query 
 '       Dim Query As New ObjectQuery("SELECT * FROM Win32_SoundDevice Where DeviceID=""HDAUDIO\\FUNC_01&VEN_1002&DEV_791A&SUBSYS_00791A00&REV_1000\\5&21FC82F3&0&0001""")

   
 '       	'Create object searcher
	'Dim Searcher As New ManagementObjectSearcher(Scope, Query)
	
	''Get a collection of WMI objects
	'Dim queryCollection As ManagementObjectCollection = Searcher.Get
	
	''Enumerate wmi object 
	'For Each mObject As ManagementObject In queryCollection
	'  'write out some property value
	'  Console.WriteLine("Availability : {0}", mObject("Availability"))
	'Next
 '       '@Piotr: bis hier! #########################
  


    End Sub

    '   'Get the namespace management scope
    '   Dim Scope As New ManagementScope("\\.\ROOT\cimv2")

    '   'Get a result of WML query 
    '   Dim Query As New ObjectQuery("SELECT * FROM Win32_SoundDevice Where DeviceID=""HDAUDIO\\FUNC_01&VEN_1002&DEV_791A&SUBSYS_00791A00&REV_1000\\5&21FC82F3&0&0001"")

    '       'Create object searcher
    '       Dim Searcher As New ManagementObjectSearcher(Scope, Query)

    '   'Get a collection of WMI objects
    '   Dim queryCollection As ManagementObjectCollection = Searcher.Get

    '   'Enumerate wmi object 
    '   For Each mObject As ManagementObject In queryCollection
    '  'write out some property value
    '  Console.WriteLine("Availability : {0}", mObject("Availability"))
    'Next

    Declare Auto Function waveOutGetDevCaps Lib "winmm.dll" (ByVal uDeviceID as Integer, ByRef lpCaps As WAVEOUTCAPS, ByVal uSize As Integer) As Integer
    Declare Auto Function waveOutGetNumDevs Lib "winmm.dll" () As Integer

    Private Sub chkAutoBackupLogFile_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutoBackupLogFile.CheckedChanged
        chkAutoBackupLogFileSilent.Enabled=chkAutoBackupLogFile.Checked
    End Sub




    Private Sub UpdateTTOptions() Handles rdbTTDisabled.CheckedChanged, rdbTTFourAudio.CheckedChanged, rdbTTOutline.CheckedChanged, rdbTTImperial.CheckedChanged
        'pTrackerYAMI.Enabled = rdbTrackerYAMI.Checked
        'pTrackerYAMI.Visible = rdbTrackerYAMI.Checked
        'chkTRLog.Enabled = Not rdbTrackerDisabled.Checked
        'cmbTRSensorCount.Enabled = Not rdbTrackerDisabled.Checked
        pTTOutline.Visible = rdbTTOutline.Checked
        pTTFourAudio.Visible = rdbTTFourAudio.Checked
        lblTTFourAudio.Text = ""
    End Sub

    Private Sub btnTTFourAudioInit_Click(sender As Object, e As EventArgs) Handles btnTTFourAudioInit.Click
        'Dim x As Integer
        'Dim y As Integer
        

        btnTTFourAudioInit.Enabled=False
        lblTTFourAudio.Text="Init Library..."
        Application.DoEvents

        Dim szErr As String = Turntable.Init(True)
        If szErr <> Nothing Then lblTTFourAudio.Text = "Init Library: Error, Four Audio turntable library cannot be initialized. Maybe library files are not available."

        Select Case glTTStatus
           Case 0
                lblTTFourAudio.Text="Init Library: Completed successfully."
            Case -1
                lblTTFourAudio.Text="Init Library: Error, no controls found."
            Case -2
                lblTTFourAudio.Text="Init Library: Error, control ID invalid."
            Case -3
                lblTTFourAudio.Text="Init Library: Error, communication error."
            Case -4
                lblTTFourAudio.Text="Init Library: Error, control init failed."
        End Select

        btnTTFourAudioInit.Enabled=True
    End Sub

    Private Sub btnEnableAllWarnings_Click(sender As Object, e As EventArgs) Handles btnEnableAllWarnings.Click
        chkNotRepOnExpStart.Checked=True
        chkNotShuffledOnExpStart.Checked=True
        chkExpPerformedOnShuffle.Checked=True
        chkResponseItemListOnExpRep.Checked=True
    End Sub

    Private Sub btnDisableAllWarnings_Click(sender As Object, e As EventArgs) Handles btnDisableAllWarnings.Click
        chkNotRepOnExpStart.Checked=False
        chkNotShuffledOnExpStart.Checked=False
        chkExpPerformedOnShuffle.Checked=False
        chkResponseItemListOnExpRep.Checked=False
    End Sub

    Private Sub txtCSVDelimiter_TextChanged(sender As Object, e As EventArgs) Handles txtCSVDelimiter.TextChanged
        CreateItemListPreview
    End Sub
    Private Sub CreateItemListPreview
        tbItemListPreview.Text="Preview of item list text file: " & vbcrlf & vbcrlf  & _
            "Index" & txtCSVDelimiter.Text & "Header1" & txtCSVDelimiter.Text & txtCSVQuota.Text & "Long Text Header2"  & txtCSVQuota.Text  & txtCSVDelimiter.Text & txtCSVQuota.Text & "Long Text Header3"  & txtCSVQuota.Text & vbCrLf & _
            "1" & txtCSVDelimiter.Text & "TextA" & txtCSVDelimiter.Text & txtCSVQuota.Text & "Long Text A2"  & txtCSVQuota.Text  & txtCSVDelimiter.Text & txtCSVQuota.Text & "Long Text A3"  & txtCSVQuota.Text & vbCrLf & _
            "2" & txtCSVDelimiter.Text & "TextB" & txtCSVDelimiter.Text & txtCSVQuota.Text & "Long Text B2"  & txtCSVQuota.Text  & txtCSVDelimiter.Text & txtCSVQuota.Text & "Long Text B3"  & txtCSVQuota.Text & vbCrLf & _
            "..."
    End Sub

    Private Sub txtCSVQuota_TextChanged(sender As Object, e As EventArgs) Handles txtCSVQuota.TextChanged
        CreateItemListPreview
    End Sub

    Private Sub UpdateTrackerOptions(sender As Object, e As EventArgs) Handles rdbTrackerYAMI.CheckedChanged, rdbTrackerViWo.CheckedChanged, rdbTrackerDisabled.CheckedChanged, rdbTrackerOptitrack.CheckedChanged

    End Sub

    Private Sub UpdateTTOptions(sender As Object, e As EventArgs) Handles rdbTTOutline.CheckedChanged, rdbTTFourAudio.CheckedChanged, rdbTTDisabled.CheckedChanged, rdbTTImperial.CheckedChanged

    End Sub
End Class