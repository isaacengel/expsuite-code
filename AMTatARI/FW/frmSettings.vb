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
' settings form, settings can be different for every experiment, independent of the used hardware
''' <summary>
''' FrameWork Module. Implementation of the Settings dialog.
''' </summary>
''' <remarks></remarks>
Friend Class frmSettings
    Inherits System.Windows.Forms.Form

    ''
    ' FrameWork Module. Implementation of the Settings dialog.
    Private ReadOnly IsInitializing As Boolean
    Private sldAudioDitherAmp As System.Collections.Generic.List(Of TrackBar)

    Private mblnPreventControl As Boolean
    Private mfreqParL() As clsFREQUENCY
    Private mfreqParR() As clsFREQUENCY

    Private mlElectrodeL, mlElectrodeR As Integer
    Private ReadOnly mlAudioDACAddStream(PLAYER_MAXCHANNELS - 1) As Integer
    Private mlExpType As Integer
    Private mlExpTypeShowed As Integer = -1

    Private mStimOutput As GENMODE
    Private mblnOutputStable As Boolean
    Private miConstValueIndex As Short
    Private mlTrackerTimerIndex As Integer
    Private mblnTrackerSaveData As Boolean
    Private mlTrackerFNr As Integer
    Private mtsTrackerValues() As TrackerSensor
    Private mtsTrackerOffset() As TrackerSensor
    Private mszDataDir() As String
    Private mviwoparTemp() As ViWoParameter
    Private mszSignalImportDir As String = ""
    Private Index As Short

    Private Function GetUboundViWoTemp() As Integer
        If IsNothing(mviwoparTemp) Then Return -1
        Return mviwoparTemp.Length - 1
    End Function

    Private Sub RealTimeChange()
        If mblnPreventControl Then Return
        lblRealTime.Visible = True
        lblRealTime.ForeColor = Drawing.Color.Red
		
		If (INIOptions.glWarningSwitches And FWintern.WarningSwitches.RealTimeParameterChange) = 0 Then
            If MsgBoxOnTop("You changed the value of a real-time parameter." & vbCrLf & vbCrLf & "Why do I bother you with this information?" & vbCrLf & vbCrLf & "Changes of these parameters will be sent to the proper device immediatly." & vbCrLf & "Later, if you cancel the Settings window, these changes will be ignored." & vbCrLf & "The old parameters of the device will be NOT restored !!!!" & vbCrLf & vbCrLf & "This happens to all real-time parameters and is indicated by" & vbCrLf & "a red text line at the bottom of the Settings window." & vbCrLf & vbCrLf & "Do you want to read this explanation again changing another real-time parameter?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1 Or MsgBoxStyle.MsgBoxSetForeground, "Read carefully!") = MsgBoxResult.No Then
                INIOptions.glWarningSwitches = INIOptions.glWarningSwitches Or FWintern.WarningSwitches.RealTimeParameterChange
            End If
		End If
		
		tmrRealTime.Enabled = True
	End Sub
	
    ''' <summary>
    ''' Show a message box on the top of all windows.
    ''' </summary>
    ''' <param name="szPrompt">Prompt</param>
    ''' <param name="lButtons">Buttons options</param>
    ''' <param name="szTitle">Title</param>
    ''' <returns>Button clicked</returns>
    ''' <remarks>MsgBoxOnTop is equivalent to MsgBox with the difference, that it will show the message box on the top of all windows.
    ''' See the description of MsgBox for details on parameters.</remarks>
    Private Function MsgBoxOnTop(ByVal szPrompt As String, _
                    Optional ByVal lButtons As MsgBoxStyle = 0, Optional ByVal szTitle As String = "") As Integer
        If Len(szTitle) = 0 Then szTitle = My.Application.Info.Title
        MsgBoxOnTop = MsgBox(szPrompt, lButtons, szTitle)
    End Function

    ''' <summary>
    ''' Sets the callback on change of the output device.
    ''' </summary>
    ''' <param name="lAddr">Address of the callback function</param>
    ''' <remarks></remarks>
    Public Sub SetOnOutputDeviceChangeCallback(ByVal lAddr As OnOutputDeviceChangeDelegate)
        glOnOutputDeviceChangeAddr = lAddr
    End Sub

    ''' <summary>
    ''' Sets the callback on Set of new Settings.
    ''' </summary>
    ''' <param name="lAddr">Address of the callback function.</param>
    ''' <remarks>OnSet callback will be executed on:
    ''' <li>Loading settings from file, just after OnExpTypeChanged</li>
    ''' <li>click on OK in the Settings form</li>
    ''' <li>clear Settings to default, just after OnExpTypeChanged</li></remarks>
    Public Sub SetOnSetCallback(ByVal lAddr As OnSetDelegate)
        glOnSettingsSetAddr = lAddr
    End Sub

    ''' <summary>
    ''' Sets the callback on change of Settings.
    ''' </summary>
    ''' <param name="lAddr"></param>
    ''' <remarks>OnChange callback will be executed on change of a value in Settings dialog.
    ''' A click on OK is not required to execute OnChange - e.g. a text box loses its focus and
    ''' OnChange will be executed immediatly.
    '''
    ''' The delegate is     OnChangeDelegate(ByVal ExpType As Integer)
    ''' where ExpType is the current experiment type
    ''' </remarks>
    Public Sub SetOnChangeCallback(ByVal lAddr As OnChangeDelegate)
        glOnSettingsChangeAddr = lAddr
    End Sub

    ''' <summary>
    ''' Sets the callback on loading Settings in the dialog.
    ''' </summary>
    ''' <param name="lAddr">Address of the callback function.</param>
    ''' <remarks>OnLoad callback will be executed on loading of the Settings dialog.
    ''' This gives a possibility to adapt the Settings dialog, before it have been shown.</remarks>
    Public Sub SetOnLoadCallback(ByVal lAddr As OnLoadDelegate)
        glOnSettingsLoadAddr = lAddr
    End Sub

    ''' <summary>
    ''' Sets the callback on change of the experiment type in the Settings dialog.
    ''' </summary>
    ''' <param name="lAddr">Address of the callback function</param>
    ''' <remarks>OnExpType callback will be executed on a change of experiment type. The delegate is OnExpTypeChangeDelegate(ByVal lOld As Integer, ByVal lNew As Integer) where:
    ''' <li>lOld: old experiment type</li>
    ''' <li>lNew: new experiment type</li>
    '''<br>
    ''' The experiment type changes on:
    ''' <li>loading setting from file, old exp. type is set to -1 in this case</li>
    ''' <li>changing the experiment type in the Settings dialog</li>
    ''' <li>clearing the settings, old exp. type is set to -1 in this case</li> </br> </remarks>
    Public Sub SetOnExpTypeCallback(ByVal lAddr As OnExpTypeChangeDelegate)
        glOnSettingsExpTypeChangeAddr = lAddr
        'frmExp.Dispose()
    End Sub

    ''' <summary>
    ''' Copies the values of all Constants to an array.
    ''' </summary>
    ''' <param name="varArr"> Array to be resized and filled.</param>
    ''' <remarks></remarks>
    Public Sub GetConstantValues(ByRef varArr() As String)
        ReDim Preserve varArr(UBound(gconstExp))
        For lX As Short = 0 To CShort(UBound(gconstExp))
            varArr(lX) = txtConstValue(lX).Text
        Next
    End Sub

    Private Function CheckMinTimeDelay(ByVal sVal As Single, ByVal szDescr As String) As String
        Dim sX As Double
        'Dim szErr As String

        If mStimOutput = STIM.GENMODE.genAcoustical Or mStimOutput = STIM.GENMODE.genAcousticalUnity Then
            If Len(txtSamplingRate.Text) = 0 Or Not IsNumeric((txtSamplingRate.Text)) Then
                Return szDescr & ": Set sampling rate to a valid numeric value, at least 1Hz"
            Else
                sX = 1000000 / Val((txtSamplingRate.Text))
            End If
            If sVal < sX And sVal <> 0 Then
                Return szDescr & ": Set value to a value greater than " & TStr(Int(sX + 1)) & "us." & vbCrLf
            End If
        End If
        Return ""

    End Function

    Private Sub ShowVariablesIndex(ByVal lIdx As Integer)

        Dim shX As Short = CShort(lIdx)
        If lstVariables(shX).Items.Count > 0 Then
            If lstVariables(shX).SelectedIndex > -1 Then
                lblVarValues.Text = "Values: (" & TStr(lstVariables(shX).SelectedIndex + 1) & "/" & TStr(lstVariables(shX).Items.Count) & ")"
            Else
                lblVarValues.Text = "Values: (-/" & TStr(lstVariables(shX).Items.Count) & ")"
            End If
        Else
            lblVarValues.Text = "Values:"
        End If
        'ToolTip1.SetToolTip(lstVariables(lIdx), VB6.GetItemString(lstVariables(lIdx), lstVariables(lIdx).SelectedIndex))

    End Sub

    ' adapt local signal parameter (mfreqParX) to the fitting file information (F4FX.)
    Private Function AdaptSignalToFitt(ByVal lEar As Implant.EARTYPE) As String
        Dim lX, lY As Integer
        'Dim sX As Single
        Dim szErr As String = "" ' gedacht als Rückmeldung falls die Parameter adaptiert werden müssen - noch zu implementieren

        Select Case lEar
            Case Implant.EARTYPE.LEFT
                If F4FL.ImpType = Implant.IMPLANTTYPE.imptInvalid Then
                    Erase mfreqParL
                    mlElectrodeL = -1
                Else
                    ' adapt values
                    lY = GetUbound(mfreqParL)
                    ReDim Preserve mfreqParL(F4FL.ChannelsCount - 1)
                    For lX = 0 To F4FL.ChannelsCount - 1
                        If lX > lY Then mfreqParL(lX) = New clsFREQUENCY
                        With F4FL.Channel(lX)
                            mfreqParL(lX).lRange = .lRange ' copy
                            mfreqParL(lX).sMCL = .lMCL ' copy
                            mfreqParL(lX).sTHR = .lTHR ' copy
                            mfreqParL(lX).lPhDur = CInt(.lPhDur * F4FL.TimeBase) 'copy
                            With mfreqParL(lX)
                                If .sAmp > .sMCL Then .sAmp = .sMCL ' adapt
                                If .sAmp < .sTHR Then .sAmp = .sTHR
                                'sX = .lPhDur

                                '' adapt to 16 >= PhDur >= F4F.PhDur or to F4F.PhDur for new electrodes
                                'If .lPhDur = 0 Then
                                '    'mfreqParL(lX).lPhDur = CInt(Math.Round(.lPhDur * F4FL.TimeBase))
                                '    .lPhDur = CInt(F4FL.Channel(lX).lPhDur * F4FL.TimeBase)
                                'Else
                                If .lPhDur > CInt(F4FL.Channel(lX).lPhDur * F4FL.TimeBase) Then 'check for min/max values
                                    'mfreqParL(lX).lPhDur = CInt(Math.Round(.lPhDur * F4FL.TimeBase))
                                    .lPhDur = CInt(F4FL.Channel(lX).lPhDur * F4FL.TimeBase)
                                ElseIf .lPhDur < CInt(Math.Round(F4FL.PHDUR_MIN * F4FL.TimeBase)) Then
                                    .lPhDur = CInt(Math.Round(F4FL.PHDUR_MIN * F4FL.TimeBase))
                                End If
                            End With

                        End With
                    Next
                    If mlElectrodeL > F4FL.ChannelsCount Then mlElectrodeL = F4FL.ChannelsCount
                End If

            Case Implant.EARTYPE.RIGHT
                If F4FR.ImpType = Implant.IMPLANTTYPE.imptInvalid Then
                    Erase mfreqParR
                    mlElectrodeR = -1
                Else
                    ' adapt values
                    lY = GetUbound(mfreqParR)
                    ReDim Preserve mfreqParR(F4FR.ChannelsCount - 1)
                    For lX = 0 To F4FR.ChannelsCount - 1
                        If lX > lY Then mfreqParR(lX) = New clsFREQUENCY
                        With F4FR.Channel(lX)
                            mfreqParR(lX).lRange = .lRange ' copy
                            mfreqParR(lX).sMCL = .lMCL ' copy
                            mfreqParR(lX).sTHR = .lTHR ' copy
                            'If mfreqParR(lX).lPhDur < CInt(F4FR.Channel(lX).lPhDur * F4FR.TimeBase) Then
                            mfreqParR(lX).lPhDur = CInt(.lPhDur * F4FR.TimeBase) 'copy
                            '.lPhDur = CInt(F4FR.Channel(lX).lPhDur * F4FR.TimeBase)
                            'End If
                            With mfreqParR(lX)

                                If .sAmp > .sMCL Then .sAmp = .sMCL ' adapt
                                If .sAmp < .sTHR Then .sAmp = .sTHR
                                'sX = .lPhDur

                                ' adapt to 16 >= PhDur >= F4F.PhDur or to F4F.PhDur for new electrodes


                                'If .lPhDur = 0 Then
                                '    'mfreqParR(lX).lPhDur = CInt(Math.Round(.lPhDur * F4FR.TimeBase))
                                '    .lPhDur = CInt(F4FR.Channel(lX).lPhDur * F4FR.TimeBase)
                                'ElseIf .lPhDur > CInt(F4FR.Channel(lX).lPhDur * F4FR.TimeBase) Then

                                ''If .lPhDur = 0 Then
                                ''mfreqParR(lX).lPhDur = CInt(Math.Round(.lPhDur * F4FR.TimeBase))
                                '.lPhDur = CInt(F4FR.Channel(lX).lPhDur * F4FR.TimeBase)

                                If .lPhDur > CInt(F4FR.Channel(lX).lPhDur * F4FR.TimeBase) Then 'check for min/max value
                                    .lPhDur = CInt(F4FR.Channel(lX).lPhDur * F4FR.TimeBase)
                                ElseIf mfreqParR(lX).lPhDur < CInt(Math.Round(F4FR.PHDUR_MIN * F4FR.TimeBase)) Then
                                    .lPhDur = CInt(Math.Round(F4FR.PHDUR_MIN * F4FR.TimeBase))
                                End If
                            End With
                        End With
                    Next
                    If mlElectrodeR > F4FR.ChannelsCount Then mlElectrodeR = F4FR.ChannelsCount
                End If

        End Select
        Return szErr
    End Function

    ' load the fitting file information to variable(s) F4FX.
    Private Sub SetFittData(ByVal szFile As String, ByVal Ear As Implant.EARTYPE)
        Dim szX As String = ""
        Dim lX As Integer
        Dim shX As Short = CShort(Ear)

        ' load fitting as temporary (to get implant type)
        Dim F4FT As New Implant(Implant.IMPLANTTYPE.imptInvalid)
        If Len(szFile) <> 0 Then szX = F4FT.OpenFile(szFile)
        lX = Len(szX)
        If Len(szX) <> 0 Then
            MsgBoxOnTop("Error reading fitting file:" & vbCrLf & szX, MsgBoxStyle.Critical)
        End If
        If F4FT.ImpType = Implant.IMPLANTTYPE.imptInvalid Then
            ' fitting file is invalid or not accessible -> set controls
            F4FT = Nothing
            txtFName(shX).Text = "not available"
            txtLName(shX).Text = "not available"
            cmdFittResetPhDur(shX).Enabled = False
            txtMinDist(shX).Text = "---"
            lblMinDist(shX).Text = "---"
            lblPPer(shX).Text = "---"
            lblCycPer(shX).Text = "---"
            lstChInfo(shX).Items.Clear()
            If Ear = Implant.EARTYPE.LEFT Then glImpLeft = 0
            If Ear = Implant.EARTYPE.RIGHT Then glImpRight = 0
            'If lIdx = 0 Then fraLeft.Enabled = False Else fraRight.Enabled = False
        Else
            ' check the device type
            Select Case mStimOutput
                Case STIM.GENMODE.genElectricalRIB, STIM.GENMODE.genElectricalNIC
                    If F4FT.DeviceTypeRequired <> mStimOutput Then _
                           MsgBox("Fitting file is not valid for this output device.") : Return
                Case STIM.GENMODE.genElectricalRIB2
                    Select Case F4FT.ImpType
                        Case Implant.IMPLANTTYPE.imptCIC3
                            MsgBox("Fitting file is not valid for this output device.") : Return
                        Case Implant.IMPLANTTYPE.imptC40C
                            MsgBox("Fitting file is not valid for this output device. Implant type C40C is not supported with RIB2.") : Return
                        Case Implant.IMPLANTTYPE.imptC40P
                            MsgBox("You are loading a fitting file in .fitt format! Before using it with RIB2, it has to be saved in .ampmap file format!")
                        Case Implant.IMPLANTTYPE.imptC40P_RIB2, Implant.IMPLANTTYPE.imptPulsar
                            ' right implant and device type, no error message
                    End Select
                Case STIM.GENMODE.genVocoder
                    If F4FT.DeviceTypeRequired <> STIM.GENMODE.genElectricalRIB2 Then _
                           MsgBox("Fitting file is not valid for this output device.") : Return
            End Select

            ' fitting file is valid
            ' load fitting as left or right
            ' before, clear possible old F4FL/F4FR
            If Not gblnOutputStable Then
                If Ear = Implant.EARTYPE.LEFT Then
                    F4FL.ClearParameters(F4FT.ImpType)
                    F4FL.OpenFile(szFile)
                    F4FT = F4FL     ' to set controls correctly
                    glImpLeft = 1
                End If
                If Ear = Implant.EARTYPE.RIGHT Then
                    F4FR.ClearParameters(F4FT.ImpType)
                    F4FR.OpenFile(szFile)
                    F4FT = F4FR     ' to set controls correctly
                    glImpRight = 2
                End If
            End If
            ' set controls
            txtFName(shX).Text = F4FT.FirstName
            txtLName(shX).Text = F4FT.LastName
            txtMinDist(shX).Text = VB.Right("   " & TStr((F4FT.MinDist)), 3)
            lblMinDist(shX).Text = "tu = " & TStr(Math.Round(F4FT.MinDist * F4FT.TimeBase, 1)) & " µs"
            lblPPer(shX).Text = TStr(Math.Round(F4FT.PulsePeriod)) & " tu = " & TStr(Math.Round(F4FT.PulsePeriod * F4FT.TimeBase, 1)) & " µs = " & TStr(Math.Round(1000000 / (F4FT.PulsePeriod * F4FT.TimeBase), 1)) & " pps"
            lblCycPer(shX).Text = "1 tu = " & TStr(Math.Round(F4FT.TimeBase, 2)) & " µs"
            lstChInfo(shX).Items.Clear()
            For lX = 0 To F4FT.ChannelsCount - 1
                lstChInfo(shX).Items.Add(TStr(lX + 1) & ": PhDur=" & TStr(F4FT.Channel(lX).lPhDur) & "tu; THR=" & TStr(F4FT.Channel(lX).lTHR) & "; MCL=" & TStr(F4FT.Channel(lX).lMCL) & "; Range=" & TStr(F4FT.Channel(lX).lRange))
            Next
            cmdFittResetPhDur(shX).Enabled = True
            F4FT = Nothing
        End If

    End Sub

    ''' <summary>
    ''' Update the Signal tab with mfreqParX, X=[L, R] depending on lCh.
    ''' </summary>
    ''' <param name="lCh"></param>
    ''' <remarks></remarks>
    Private Sub UpdateSignalTab(ByVal lCh As Implant.EARTYPE)
        Dim lX As Integer

        Select Case mStimOutput
            Case STIM.GENMODE.genAcoustical, GENMODE.genAcousticalUnity
                fraElectricalL.Visible = False
                fraElectricalR.Visible = False
                cmdElAddL.Visible = True
                cmdElAddR.Visible = True
                cmdElDelL.Visible = True
                cmdElDelR.Visible = True
                Select Case lCh
                    Case Implant.EARTYPE.LEFT ' left ear/path
                        If GetUbound(mfreqParL) > -1 Then
                            fraAcousticL.Visible = True
                            fraSignalL.Visible = True
                            If cmbElL.Items.Count <> UBound(mfreqParL) + 1 Then
                                cmbElL.Items.Clear()
                                For lX = 0 To UBound(mfreqParL)
                                    cmbElL.Items.Add(TStr(lX + 1))
                                Next
                            End If
                            If mlElectrodeL > UBound(mfreqParL) + 1 Then mlElectrodeL = UBound(mfreqParL) + 1
                            If mlElectrodeL < 1 Then mlElectrodeL = 1
                            cmbElL.Enabled = True
                            cmbElL.SelectedIndex = mlElectrodeL - 1
                            cmbElL_SelectedIndexChanged(cmbElL, New System.EventArgs())
                            cmdElDelL.Enabled = True
                        Else
                            fraAcousticL.Visible = False
                            fraSignalL.Visible = False
                            cmbElL.Items.Clear()
                            mlElectrodeL = -1
                            cmbElL.Enabled = False
                            cmdElDelL.Enabled = False
                        End If
                    Case Implant.EARTYPE.RIGHT ' right ear/path
                        If GetUbound(mfreqParR) > -1 Then
                            fraAcousticR.Visible = True
                            fraSignalR.Visible = True
                            If cmbElR.Items.Count <> UBound(mfreqParR) + 1 Then
                                cmbElR.Items.Clear()
                                For lX = 0 To UBound(mfreqParR)
                                    cmbElR.Items.Add(TStr(lX + 1))
                                Next
                            End If
                            If mlElectrodeR > UBound(mfreqParR) + 1 Then mlElectrodeR = UBound(mfreqParR) + 1
                            If mlElectrodeR < 1 Then mlElectrodeR = 1
                            cmbElR.Enabled = True
                            cmbElR.SelectedIndex = mlElectrodeR - 1
                            cmbElR_SelectedIndexChanged(cmbElR, New System.EventArgs())
                            cmdElDelR.Enabled = True
                        Else
                            fraAcousticR.Visible = False
                            fraSignalR.Visible = False
                            cmbElR.Items.Clear()
                            mlElectrodeR = -1
                            cmbElR.Enabled = False
                            cmdElDelR.Enabled = False
                        End If
                End Select 'left/right channel
                tabFittingLeft.Enabled = False : tabFittingLeft.Font = New Font(tabFittingLeft.Font.FontFamily, tabFittingLeft.Font.Size, FontStyle.Italic)
                tabFittingRight.Enabled = False : tabFittingRight.Font = New Font(tabFittingRight.Font.FontFamily, tabFittingRight.Font.Size, FontStyle.Italic)
                tabAudio.Enabled = True : tabAudio.Font = New Font(tabAudio.Font.FontFamily, tabAudio.Font.Size)
                Me._fraAudioDither_0.Visible = True
                Me._fraAudioDither_1.Visible = True
                Me._lblAudio_3.Visible = True
                Me._lblAudio_2.Visible = True
                Me._lblAudio_1.Visible = True
                Me._lblAudio_0.Visible = True
                Me.fraAudioDACMulti.Visible = False
                Me.fraAudioDACLeft.Visible = True
                Me.fraAudioDACRight.Visible = True
                Me.fraVocBox.Visible = False


            Case STIM.GENMODE.genElectricalRIB, GENMODE.genElectricalNIC, GENMODE.genElectricalRIB2

                fraAcousticL.Visible = False
                fraAcousticR.Visible = False
                cmdElAddL.Visible = False
                cmdElAddR.Visible = False
                cmdElDelL.Visible = False
                cmdElDelR.Visible = False
                Select Case lCh
                    Case Implant.EARTYPE.LEFT ' left channel
                        If F4FL.ImpType = Implant.IMPLANTTYPE.imptInvalid Or GetUbound(mfreqParL) = -1 Then
                            cmbElL.Enabled = False
                            cmbElL.SelectedIndex = -1
                            fraElectricalL.Visible = False
                            fraSignalL.Visible = False
                        Else
                            fraElectricalL.Visible = True
                            fraSignalL.Visible = True
                            If cmbElL.Items.Count <> UBound(mfreqParL) + 1 Then
                                cmbElL.Items.Clear()
                                For lX = 0 To UBound(mfreqParL)
                                    cmbElL.Items.Add(TStr(lX + 1))
                                Next
                            End If
                            cmbElL.Enabled = True
                            If mlElectrodeL > UBound(mfreqParL) + 1 Then mlElectrodeL = UBound(mfreqParL) + 1
                            If mlElectrodeL < 1 Then mlElectrodeL = 1
                            cmbElL.Enabled = True
                            cmbElL.SelectedIndex = mlElectrodeL - 1
                            cmbElL_SelectedIndexChanged(cmbElL, New System.EventArgs())
                        End If
                    Case Implant.EARTYPE.RIGHT ' right channel
                        If F4FR.ImpType = Implant.IMPLANTTYPE.imptInvalid Or GetUbound(mfreqParR) = -1 Then
                            cmbElR.Enabled = False
                            cmbElR.SelectedIndex = -1
                            fraElectricalR.Visible = False
                            fraSignalR.Visible = False
                        Else
                            fraElectricalR.Visible = True
                            fraSignalR.Visible = True
                            If cmbElR.Items.Count <> UBound(mfreqParR) + 1 Then
                                cmbElR.Items.Clear()
                                For lX = 0 To UBound(mfreqParR)
                                    cmbElR.Items.Add(TStr(lX + 1))
                                Next
                            End If
                            cmbElR.Enabled = True
                            If mlElectrodeR > UBound(mfreqParR) + 1 Then mlElectrodeR = UBound(mfreqParR) + 1
                            If mlElectrodeR < 1 Then mlElectrodeR = 1
                            cmbElR.Enabled = True
                            cmbElR.SelectedIndex = mlElectrodeR - 1
                            cmbElR_SelectedIndexChanged(cmbElR, New System.EventArgs())
                        End If
                End Select 'left/right channel
                tabFittingLeft.Enabled = True : tabFittingLeft.Font = New Font(tabFittingLeft.Font.FontFamily, tabFittingLeft.Font.Size)
                tabFittingRight.Enabled = True : tabFittingRight.Font = New Font(tabFittingRight.Font.FontFamily, tabFittingRight.Font.Size)
                tabAudio.Enabled = False : tabAudio.Font = New Font(tabAudio.Font.FontFamily, tabAudio.Font.Size, FontStyle.Italic)


            Case GENMODE.genVocoder

                fraAcousticL.Visible = False
                fraAcousticR.Visible = False
                cmdElAddL.Visible = False
                cmdElAddR.Visible = False
                cmdElDelL.Visible = False
                cmdElDelR.Visible = False
                Select Case lCh
                    Case Implant.EARTYPE.LEFT ' left channel
                        If F4FL.ImpType = Implant.IMPLANTTYPE.imptInvalid Or GetUbound(mfreqParL) = -1 Then
                            cmbElL.Enabled = False
                            cmbElL.SelectedIndex = -1
                            fraElectricalL.Visible = False
                            fraSignalL.Visible = False
                        Else
                            fraElectricalL.Visible = True
                            fraSignalL.Visible = True
                            If cmbElL.Items.Count <> UBound(mfreqParL) + 1 Then
                                cmbElL.Items.Clear()
                                For lX = 0 To UBound(mfreqParL)
                                    cmbElL.Items.Add(TStr(lX + 1))
                                Next
                            End If
                            cmbElL.Enabled = True
                            If mlElectrodeL > UBound(mfreqParL) + 1 Then mlElectrodeL = UBound(mfreqParL) + 1
                            If mlElectrodeL < 1 Then mlElectrodeL = 1
                            cmbElL.Enabled = True
                            cmbElL.SelectedIndex = mlElectrodeL - 1
                            cmbElL_SelectedIndexChanged(cmbElL, New System.EventArgs())
                        End If
                    Case Implant.EARTYPE.RIGHT ' right channel
                        If F4FR.ImpType = Implant.IMPLANTTYPE.imptInvalid Or GetUbound(mfreqParR) = -1 Then
                            cmbElR.Enabled = False
                            cmbElR.SelectedIndex = -1
                            fraElectricalR.Visible = False
                            fraSignalR.Visible = False
                        Else
                            fraElectricalR.Visible = True
                            fraSignalR.Visible = True
                            If cmbElR.Items.Count <> UBound(mfreqParR) + 1 Then
                                cmbElR.Items.Clear()
                                For lX = 0 To UBound(mfreqParR)
                                    cmbElR.Items.Add(TStr(lX + 1))
                                Next
                            End If
                            cmbElR.Enabled = True
                            If mlElectrodeR > UBound(mfreqParR) + 1 Then mlElectrodeR = UBound(mfreqParR) + 1
                            If mlElectrodeR < 1 Then mlElectrodeR = 1
                            cmbElR.Enabled = True
                            cmbElR.SelectedIndex = mlElectrodeR - 1
                            cmbElR_SelectedIndexChanged(cmbElR, New System.EventArgs())
                        End If
                End Select 'left/right channel
                tabFittingLeft.Enabled = True : tabFittingLeft.Font = New Font(tabFittingLeft.Font.FontFamily, tabFittingLeft.Font.Size)
                tabFittingRight.Enabled = True : tabFittingRight.Font = New Font(tabFittingRight.Font.FontFamily, tabFittingRight.Font.Size)
                tabAudio.Enabled = True : tabAudio.Font = New Font(tabAudio.Font.FontFamily, tabAudio.Font.Size, FontStyle.Italic)
                Me._fraAudioDither_0.Visible = False
                Me._fraAudioDither_1.Visible = False
                Me._lblAudio_3.Visible = True
                Me._lblAudio_2.Visible = True
                Me._lblAudio_1.Visible = True
                Me._lblAudio_0.Visible = True
                Me.fraAudioDACMulti.Visible = False
                Me.fraAudioDACLeft.Visible = False
                Me.fraAudioDACRight.Visible = False
                Me.fraVocBox.Visible = True




        End Select

    End Sub

    ''' <summary>
    ''' Update Variables in the Settings dialog.
    ''' </summary>
    ''' <remarks>UpdateVariables can be used when the variables changes and need to be updated in the Settings dialog.
    ''' UpdateVariables will be executed on the change of experiment type, right after the OnExpTypeChanged callback
    ''' and UpdateConstant</remarks>
    Public Sub UpdateVariables()
        Dim lX As Integer
        Dim varUnit As String

        For lX = 0 To cmbVariables.Items.Count - 1
            If gvarExp(lX).szUnit Is Nothing Then
                varUnit = ""
            Else
                varUnit = " [" & gvarExp(lX).szUnit & "]"
            End If
            VB6.SetItemString(cmbVariables, lX, gvarExp(lX).szName & varUnit)
        Next
        cmbVariables_SelectedIndexChanged(cmbVariables, New System.EventArgs())

    End Sub

    ''' <summary>
    ''' Update Constants in the Settings dialog.
    ''' </summary>
    ''' <remarks>UpdateConstants can be used when the constants changes and need to be updated in the Settings dialog.
    ''' UpdateConstant will be executed on the change of experiment type, right after the OnExpTypeChanged callback</remarks>
    Public Sub UpdateConstants()
        'Dim lY As Integer

        If GetUboundConstants() <> -1 Then
            For lX As Short = 0 To CShort(UBound(gconstExp))
                With gconstExp(lX)
                    ' set contents
                    If Len(.szName) = 0 Then
                        lblConstName(lX).Text = .szDescription & ":"
                    Else
                        lblConstName(lX).Text = .szName & ":"
                        ToolTip1.SetToolTip(lblConstName(lX), .szDescription)
                        ToolTip1.SetToolTip(txtConstValue(lX), .szDescription)
                        ToolTip1.SetToolTip(lblConstUnit(lX), .szUnit)
                    End If
                    lblConstUnit(lX).Text = .szUnit
                    If IsNothing(.varValue) Then
                        txtConstValue(lX).Text = .varDefault
                    Else
                        txtConstValue(lX).Text = .varValue
                    End If
                    'If ((.Flags And 15) = FWintern.VariableFlags.vfFileName) And ((.Flags And &H70S) = FWintern.VariableFlags.vfAbsolute) Then
                    '    lY = InStrRev(txtConstValue(lX).Text, "\")
                    '    If lY > 0 Then lblConstUnit(lX).Text = "..." & Mid(txtConstValue(lX).Text, lY)
                    '    ToolTip1.SetToolTip(lblConstUnit(lX), txtConstValue(lX).Text)
                    'End If
                    If (.Flags And FWintern.VariableFlags.vfHidden) <> 0 Then
                        lblConstName(lX).Visible = False
                        txtConstValue(lX).Visible = False
                        lblConstUnit(lX).Visible = False
                        TextBoxState(txtConstValue(lX), False)
                        cmdConstCmd(lX).Visible = False
                    Else
                        lblConstName(lX).Visible = True
                        txtConstValue(lX).Visible = True
                        lblConstUnit(lX).Visible = True
                        TextBoxState(txtConstValue(lX), Not CBool(.Flags And FWintern.VariableFlags.vfDisabled))
                        cmdConstCmd(lX).Visible = ((.Flags And 15) = FWintern.VariableFlags.vfFileName)
                        cmdConstCmd(lX).Enabled = Not CBool(.Flags And FWintern.VariableFlags.vfDisabled) ' ((gconstExp(lX).Flags And 15) = Not FWintern.VariableFlags.vfDisabled)
                    End If
                End With
            Next
            OrganizeConstantsTab()
        End If

    End Sub

    Private Sub ShowForm()

        mblnPreventControl = True

        ' general
        mStimOutput = INISettings.gStimOutput
        For lX As Integer = 0 To 5
            Me.optDeviceType(CShort(lX)).Checked = CBool(lX = CType(mStimOutput, Integer))
        Next
        Select Case mStimOutput
            Case GENMODE.genAcoustical, GENMODE.genAcousticalUnity
                lblSignal.Text = "Acoust. channel:"
            Case GENMODE.genElectricalRIB, GENMODE.genElectricalNIC, GENMODE.genElectricalRIB2, GENMODE.genVocoder
                lblSignal.Text = "Electrode:"
        End Select
        chkTempDir.CheckState = DirectCast(-CInt(Not gblnDestinationDir), CheckState)
        cmdDestinationDir.Enabled = gblnDestinationDir Or gblnOutputStable
        txtDestinationDir.Text = gszDestinationDir
        TextBoxState(txtDestinationDir, gblnDestinationDir And Not gblnOutputStable)
        chkNewWorkDir.CheckState = DirectCast(-CInt(gblnNewWorkDir), CheckState)
        chkSilentMode.CheckState = DirectCast(-CInt(gblnSilentMode), CheckState)
        chkDoNotConnectToDevice.CheckState = DirectCast(-CInt(gblnDoNotConnectToDevice), CheckState)
        cmbDataDir.Enabled = DataDirectory.Count > 0
        fraDataDir.Visible = DataDirectory.Count > 0
        cmdDataDir.Enabled = cmbDataDir.Enabled And Not gblnOutputStable
        TextBoxState(txtDataDir, cmbDataDir.Enabled And Not gblnOutputStable)
        If cmbDataDir.Enabled Then
            ReDim mszDataDir(DataDirectory.Count - 1)
            For lX As Integer = 0 To DataDirectory.Count - 1
                cmbDataDir.Items.Add(DataDirectory.Title(lX))
                mszDataDir(lX) = DataDirectory.Path(lX)
            Next
            cmbDataDir.SelectedIndex = 0
        Else
            Erase mszDataDir
        End If

        ' turntable
        chkTTUse.CheckState = DirectCast(-CInt(gblnTTUse), CheckState)
        fraTurntable.Enabled = glTTMode = 1 Or (glTTMode = 2 And glTTLPT > 0) Or glTTMode = 3
        fraTurntable.Visible = fraTurntable.Enabled Or chkTTUse.Checked

        ' fitting left
        TextBoxState(txtSourceDir, Not gblnOutputStable)
        txtSourceDir.Text = gszSourceDir

        cmdSourceDir.Enabled = Not gblnOutputStable
        If Len(gszFittFileLeft) <> 0 Then
            SetFittData(txtSourceDir.Text & "\" & gszFittFileLeft, Implant.EARTYPE.LEFT)
        Else
            SetFittData("", Implant.EARTYPE.LEFT)
        End If
        txtFittFile(0).Text = gszFittFileLeft
        cmdFittBrowse(0).Enabled = Not gblnOutputStable
        Me.cmdFittEdit_0.Enabled = Not gblnOutputStable

        ' fitting right
        If Len(gszFittFileRight) <> 0 Then
            SetFittData(txtSourceDir.Text & "\" & gszFittFileRight, Implant.EARTYPE.RIGHT)
        Else
            SetFittData("", Implant.EARTYPE.RIGHT)
        End If
        txtFittFile(1).Text = gszFittFileRight
        cmdFittBrowse(1).Enabled = Not gblnOutputStable
        Me.cmdFittEdit_1.Enabled = Not gblnOutputStable

        ' description
        txtDescription.Text = gszDescription
        txtID.Text = gszExpID

        ' experiment screen
        txtExpHeight.Text = TStr(grectExp.Height)
        txtExpLeft.Text = TStr(grectExp.Left)
        txtExpTop.Text = TStr(grectExp.Top)
        txtExpWidth.Text = TStr(grectExp.Width)
        chkAlwaysOnTop.CheckState = DirectCast(-CInt(gblnExpOnTop), CheckState)
        chkOverrideExpMode.CheckState = DirectCast(-CInt(gblnOverrideExpMode), CheckState)
        OexpMode.Enabled = chkOverrideExpMode.Checked
        OexpMode.Value = gOExpMode
        cmbHUI.Items.Add("No Human Interface support")
        cmbHUI.SelectedIndex = 0
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
            MsgBoxOnTop(szErr, MsgBoxStyle.Information, "List of HUI devices")
            cmbHUI.Enabled = False
        Else
            For lX As Integer = 0 To szArr.Length - 1
                cmbHUI.Items.Add(Trim(szArr(lX)) & "; " & TStr(lArr(lX)) & " buttons")
            Next
            For lY As Integer = szArr.Length To 3
                cmbHUI.Items.Add("Dummy Human Interface " & TStr(lY + 1))
            Next
            If glExpHUIID < cmbHUI.Items.Count Then cmbHUI.SelectedIndex = glExpHUIID
        End If
        lstExpFlags.Items.Add("Show Start Button")
        lstExpFlags.Items.Add("Show Next Button")
        lstExpFlags.Items.Add("Show Reponse Buttons")
        lstExpFlags.Items.Add("Show Feedback")
        lstExpFlags.Items.Add("Use Response Highlight")
        lstExpFlags.Items.Add("Wait For Next")
        lstExpFlags.Items.Add("Hide Progress Bar")
        lstExpFlags.Items.Add("Sync Progress Bar to Break")
        lstExpFlags.Items.Add("Delay Feedback 'til Next Item")
        lstExpFlags.Items.Add("Lock mouse in the screen")
        lstExpFlags.Items.Add("Wait After Break")
        lstExpFlags.Items.Add("Dark Mode")
        For lX As Integer = 0 To 11
            If (INISettings.glExpFlags And CInt(2 ^ lX)) <> 0 Then lstExpFlags.SetItemChecked(lX, True)
        Next
        lstExpFlags.SelectedIndex = -1

        ' signal
        Dim lLen As Integer
        ' create temp data - left
        lLen = GetUbound(gfreqParL)
        If lLen > -1 Then
            ReDim mfreqParL(lLen)
            For lX As Integer = 0 To lLen
                mfreqParL(lX) = gfreqParL(lX).Copy
            Next
            mlElectrodeL = glElectrodeL
        Else
            Erase mfreqParL
            mlElectrodeL = -1
        End If
        Select Case mStimOutput
            Case STIM.GENMODE.genAcoustical, GENMODE.genAcousticalUnity
                'do nothing
            Case Else
                AdaptSignalToFitt(Implant.EARTYPE.LEFT)
        End Select

        ' create temp data - right
        lLen = GetUbound(gfreqParR)
        If lLen > -1 Then
            ReDim mfreqParR(lLen)
            For lX As Integer = 0 To lLen
                mfreqParR(lX) = gfreqParR(lX).Copy
            Next
            mlElectrodeR = glElectrodeR
        Else
            Erase mfreqParR
            mlElectrodeR = -1
        End If

        Select Case mStimOutput
            Case STIM.GENMODE.genAcoustical, GENMODE.genAcousticalUnity
                'do nothing
            Case Else
                AdaptSignalToFitt(Implant.EARTYPE.RIGHT)
        End Select

        ' create and enable controls
        cmbRangeL.Items.Clear()
        cmbRangeR.Items.Clear()
        For lX As Integer = 0 To 3
            cmbRangeL.Items.Add(TStr(lX))
            cmbRangeR.Items.Add(TStr(lX))
        Next
        fraAcousticL.Top = fraElectricalL.Top
        fraAcousticR.Top = fraElectricalR.Top
        fraAcousticL.Left = fraElectricalL.Left
        fraAcousticR.Left = fraElectricalR.Left
        UpdateSignalTab(Implant.EARTYPE.LEFT)
        UpdateSignalTab(Implant.EARTYPE.RIGHT)

        ' audio
        txtSamplingRate.Text = CStr(glSamplingRate)
        srateAcoustic = CInt(txtSamplingRate.Text)
        txtResolution.Text = CStr(glResolution)
        txtFadeIn.Text = CStr(gsFadeIn)
        txtFadeOut.Text = CStr(gsFadeOut)
        ckbUseDataChannel.CheckState = DirectCast(-CInt(gblnUseDataChannel), CheckState)
        ckbUseTriggerChannel.CheckState = DirectCast(-CInt(gblnUseTriggerChannel), CheckState)
        facScalelbl.Text = CStr(divFactor)
        cmbAudioDither(0).Items.Clear()
        cmbAudioDither(0).Items.Add("not used")
        cmbAudioDither(0).Items.Add("pink noise")
        cmbAudioDither(0).Items.Add("white noise")
        cmbAudioDither(0).Items.Add("cosine")
        cmbAudioDither(0).Items.Add("LP4 white noise")
        cmbAudioDither(0).Items.Add("LP16 white noise")

        cmbAudioDither(1).Items.Clear()
        cmbAudioDither(1).Items.Add("not used")
        cmbAudioDither(1).Items.Add("pink noise")
        cmbAudioDither(1).Items.Add("white noise")
        cmbAudioDither(1).Items.Add("cosine")
        cmbAudioDither(1).Items.Add("LP4 white noise")
        cmbAudioDither(1).Items.Add("LP16 white noise")
        mblnPreventControl = True
        For shX As Short = 0 To 1
            With gAudioSynth(shX)
                cmbAudioDither(shX).SelectedIndex = .Signal
                cmbAudioDither_SelectedIndexChanged(cmbAudioDither.Item(shX), New System.EventArgs())
                sldAudioDitherAmp.Item(shX).Value = CInt(.Vol * 10 + 1000)
                sldAudioDitherAmp_Change(sldAudioDitherAmp.Item(shX), New System.EventArgs())
                txtAudioDitherLC(shX).Text = TStr(.LowCut)
                txtAudioDitherHC(shX).Text = TStr(.HighCut)
                txtAudioDitherPar1(shX).Text = TStr(.Par1)
            End With
        Next
        Select Case glPlayerChannels
            Case 0, 1
                Err.Raise(CInt("Invalid number of audio channels."))
            Case 2
                fraAudioDACMulti.Visible = False
                fraAudioDACLeft.Visible = True
                fraAudioDACRight.Visible = True
                optAudioDitherLeft(CShort(glAudioDACAddStream(0))).Checked = True
                mlAudioDACAddStream(0) = glAudioDACAddStream(0)
                optAudioDitherRight(CShort(glAudioDACAddStream(1))).Checked = True
                mlAudioDACAddStream(1) = glAudioDACAddStream(1)
            Case Else
                fraAudioDACLeft.Visible = False
                fraAudioDACRight.Visible = False
                fraAudioDACMulti.Visible = True
                For lX As Integer = 0 To glPlayerChannels - 1
                    mlAudioDACAddStream(lX) = glAudioDACAddStream(lX)
                    If glAudioDACAddStream(lX) > 0 Then
                        cmbAudioSynthCh.Items.Add(TStr(lX + 1) & " Synth " & Chr(64 + glAudioDACAddStream(lX)))
                    Else
                        cmbAudioSynthCh.Items.Add(TStr(lX + 1))
                    End If
                Next
                cmbAudioSynthCh.SelectedIndex = 0
                optAudioSynthDAC(CShort(mlAudioDACAddStream(0))).Checked = True
        End Select
        'mblnPreventControl = False

        ' procedure constants
        cmbExpType.Items.Clear()
        For lX As Integer = 0 To UBound(gszExpTypeNames)
            cmbExpType.Items.Add(gszExpTypeNames(lX))
        Next
        txtInterStimBreak.Text = TStr(glInterStimBreak)
        If glExpType < cmbExpType.Items.Count Then cmbExpType.SelectedIndex = glExpType
        mlExpType = glExpType
        txtOffsetL.Text = TStr(glOffsetL)
        txtOffsetR.Text = TStr(glOffsetR)
        txtRepetition.Text = TStr(glRepetition)
        txtPreStimBreak.Text = TStr(glPreStimBreak)
        txtPreStimVisu.Text = TStr(glPreStimVisu)
        txtPostStimVisu.Text = TStr(glPostStimVisu)
        cmbBreak.Items.Add("minutes")
        cmbBreak.Items.Add("items")
        cmbBreak.Items.Add("percent")
        txtBreak.Text = TStr(glBreakInterval)
        chkBreak.CheckState = DirectCast(-CInt((glBreakFlags And 1) <> 0), CheckState)
        cmbBreak.SelectedIndex = glBreakFlags \ 2
        'txtExperimentStartItem.Text = TStr(glExperimentStartItem)
        'txtExperimentEndItem.Text = TStr(glExperimentEndItem)
        If glExperimentStartItem <> -1 And glExperimentEndItem <> -1 Then
            txtExperimentItemRange.Text = "Experiment Item Range: Items " & TStr(glExperimentStartItem + 1) & "-" & TStr(glExperimentEndItem + 1)
        ElseIf ItemList.ItemCount = 0 Then
            txtExperimentItemRange.Text = "Experiment Item Range: All Items"
        Else
            txtExperimentItemRange.Text = "Experiment Item Range: All Items (Items 1-" & TStr(ItemList.ItemCount) & ")"
        End If

        ' experiment constants
        If GetUboundConstants() <> -1 Then
            For lX As Integer = 0 To UBound(gconstExp)
                With gconstExp(lX)
                    If lX <> 0 Then
                        lblConstName.Load(CShort(lX))
                        lblConstUnit.Load(CShort(lX))
                        txtConstValue.Load(CShort(lX))
                        cmdConstCmd.Load(CShort(lX))
                    End If
                    ' set positions and appearance
                    With lblConstName(CShort(lX))
                        .Visible = True
                        .Top = lblConstName(0).Top + CInt(1.2 * txtConstValue(0).Height * lX)
                        .Left = lblConstName(0).Left
                    End With
                    With txtConstValue(CShort(lX))
                        .Visible = True
                        .Top = txtConstValue(0).Top + CInt(1.2 * txtConstValue(0).Height * lX)
                        .Left = txtConstValue(0).Left
                    End With
                    With cmdConstCmd(CShort(lX))
                        .Visible = True
                        .Top = cmdConstCmd(0).Top + CInt(1.2 * txtConstValue(0).Height * lX)
                        .Left = cmdConstCmd(0).Left
                    End With
                    With lblConstUnit(CShort(lX))
                        .Visible = True
                        .Top = lblConstName(0).Top + CShort(1.2 * txtConstValue(0).Height * lX)
                        '.Left = will be set in tabSettings_Click
                        If (gconstExp(lX).Flags And 15) = FWintern.VariableFlags.vfFileName Then
                            lblConstUnit(CShort(lX)).Left = cmdConstCmd(CShort(lX)).Left + cmdConstCmd(CShort(lX)).Width + 6
                        Else
                            lblConstUnit(CShort(lX)).Left = txtConstValue(CShort(lX)).Left + txtConstValue(CShort(lX)).Width + 6
                        End If

                    End With
                    If (.Flags And 15) <> FWintern.VariableFlags.vfFileName Then cmdConstCmd(CShort(lX)).Visible = False

                End With
            Next
            UpdateConstants()
        Else ' no constants defined - hide constants tab
            tabConstants.Enabled = False : tabConstants.Font = New Font(tabConstants.Font.FontFamily, tabConstants.Font.Size, FontStyle.Italic)
        End If

        ' experiment variables
        If GetUboundVariables() <> -1 Then
            For lX As Integer = 0 To UBound(gvarExp)
                With gvarExp(lX)
                    If Len(.szName) = 0 Then .szName = .szDescription
                    If Len(.szUnit) <> 0 Then
                        cmbVariables.Items.Add(.szName & " [" & .szUnit & "]")
                    Else
                        cmbVariables.Items.Add(.szName)
                    End If
                    If lX <> 0 Then lstVariables.Load(CShort(lX))
                    With lstVariables(CShort(lX))
                        .Visible = True
                        .Top = lstVariables(0).Top
                        .Left = lstVariables(0).Left
                    End With
                    ArrayToList(.varValue, lstVariables(CShort(lX)))
                End With
            Next
            If cmbVariables.Items.Count > 0 Then cmbVariables.SelectedIndex = 0
        Else
            tabVariables.Enabled = False : tabVariables.Font = New Font(tabVariables.Font.FontFamily, tabVariables.Font.Size, FontStyle.Italic)
        End If

        ' tracker
        chkTrackerUse.CheckState = DirectCast(-CInt(gblnTrackerUse), CheckState)
        Select Case glTrackerSensorCount
            Case 1
                cmbTrackerRepRate.Items.Add("412")
                cmbTrackerRepRate.Items.Add("206")
                cmbTrackerRepRate.Items.Add("51.5")
                cmbTrackerRepRate.Items.Add("12.9")
            Case 2
                cmbTrackerRepRate.Items.Add("206")
                cmbTrackerRepRate.Items.Add("103")
                cmbTrackerRepRate.Items.Add("25.8")
                cmbTrackerRepRate.Items.Add("6.4")
            Case Else
                MsgBoxOnTop("Sensor Count not supported.") : Exit Sub
        End Select
        If glTrackerRepRate > 4 Or glTrackerRepRate < 1 Then glTrackerRepRate = 1
        cmbTrackerRepRate.SelectedIndex = glTrackerRepRate - 1
        cmbTrackerPosScaling.Items.Add("36")
        cmbTrackerPosScaling.Items.Add("72")
        Dim lTrackerScalingIdx As Integer
        For lTrackerScalingIdx = 0 To cmbTrackerPosScaling.Items.Count - 1
            If Val(VB6.GetItemString(cmbTrackerPosScaling, lTrackerScalingIdx)) = gsngTrackerPosScaling Then Exit For
        Next
        If lTrackerScalingIdx = cmbTrackerPosScaling.Items.Count Then
            lTrackerScalingIdx = 0
            MsgBoxOnTop("Tracker Position Scaling: unknown value (" & TStr(gsngTrackerPosScaling) & ")")
            cmbTrackerPosScaling.SelectedIndex = lTrackerScalingIdx - 1
        Else
            cmbTrackerPosScaling.SelectedIndex = lTrackerScalingIdx
        End If
        ReDim mtsTrackerValues(glTrackerSensorCount - 1)
        ReDim mtsTrackerOffset(glTrackerSensorCount - 1)
        For shX As Short = 0 To CShort(glTrackerSensorCount - 1)
            '   fraTrackerSensor(shX).Visible = True 'And gblnTrackerUse
            fraTrackerSensor(shX).Enabled = (glTrackerMode > 0) ' gblnTrackerUse 'true !!!!!!!!!!
            cmdTrackerSetValues(shX).Enabled = gblnTrackerUse
            cmdTrackerSetOffset(shX).Enabled = gblnTrackerUse
            mtsTrackerValues(shX) = gtsTrackerValues(shX)
            mtsTrackerOffset(shX) = gtsTrackerOffset(shX)
        Next
        For shX As Short = 0 To 1
            ' bold values? (min / max active)
            lblTrackerX(shX).Font = VB6.FontChangeBold(lblTrackerX(shX).Font, (((gtsTrackerMin(shX).lStatus And 1) <> 0) Or ((gtsTrackerMax(shX).lStatus And 1) <> 0)))
            lblTrackerY(shX).Font = VB6.FontChangeBold(lblTrackerY(shX).Font, (((gtsTrackerMin(shX).lStatus And 2) <> 0) Or ((gtsTrackerMax(shX).lStatus And 2) <> 0)))
            lblTrackerZ(shX).Font = VB6.FontChangeBold(lblTrackerZ(shX).Font, ((gtsTrackerMin(shX).lStatus And 4) <> 0) Or ((gtsTrackerMax(shX).lStatus And 4) <> 0))
            lblTrackerA(shX).Font = VB6.FontChangeBold(lblTrackerA(shX).Font, ((gtsTrackerMin(shX).lStatus And 8) <> 0) Or ((gtsTrackerMax(shX).lStatus And 8) <> 0))
            lblTrackerE(shX).Font = VB6.FontChangeBold(lblTrackerE(shX).Font, ((gtsTrackerMin(shX).lStatus And 16) <> 0) Or ((gtsTrackerMax(shX).lStatus And 16) <> 0))
            lblTrackerR(shX).Font = VB6.FontChangeBold(lblTrackerR(shX).Font, ((gtsTrackerMin(shX).lStatus And 32) <> 0) Or ((gtsTrackerMax(shX).lStatus And 32) <> 0))

            ' show min/max values? or empty string?
            Dim szRangeTempMin As String = "" : Dim szRangeTempMax As String = ""
            If (gtsTrackerMin(shX).lStatus And 1) <> 0 Then szRangeTempMin = gtsTrackerMin(shX).sngX & "<"
            If (gtsTrackerMax(shX).lStatus And 1) <> 0 Then szRangeTempMax = "<" & gtsTrackerMax(shX).sngX
            If (szRangeTempMin <> "" Or szRangeTempMax <> "") Then lblTrackerXRange(shX).Text = szRangeTempMin & "X" & szRangeTempMax Else lblTrackerXRange(shX).Text = ""
            ToolTip1.SetToolTip(lblTrackerXRange(shX), lblTrackerXRange(shX).Text)

            szRangeTempMin = "" : szRangeTempMax = ""
            If (gtsTrackerMin(shX).lStatus And 2) <> 0 Then szRangeTempMin = gtsTrackerMin(shX).sngY & "<"
            If (gtsTrackerMax(shX).lStatus And 2) <> 0 Then szRangeTempMax = "<" & gtsTrackerMax(shX).sngY
            If (szRangeTempMin <> "" Or szRangeTempMax <> "") Then lblTrackerYRange(shX).Text = szRangeTempMin & "Y" & szRangeTempMax Else lblTrackerYRange(shX).Text = ""
            ToolTip1.SetToolTip(lblTrackerYRange(shX), lblTrackerYRange(shX).Text)

            szRangeTempMin = "" : szRangeTempMax = ""
            If (gtsTrackerMin(shX).lStatus And 4) <> 0 Then szRangeTempMin = gtsTrackerMin(shX).sngZ & "<"
            If (gtsTrackerMax(shX).lStatus And 4) <> 0 Then szRangeTempMax = "<" & gtsTrackerMax(shX).sngZ
            If (szRangeTempMin <> "" Or szRangeTempMax <> "") Then lblTrackerZRange(shX).Text = szRangeTempMin & "Z" & szRangeTempMax Else lblTrackerZRange(shX).Text = ""
            ToolTip1.SetToolTip(lblTrackerZRange(shX), lblTrackerZRange(shX).Text)

            szRangeTempMin = "" : szRangeTempMax = ""
            If (gtsTrackerMin(shX).lStatus And 8) <> 0 Then szRangeTempMin = gtsTrackerMin(shX).sngA & "<"
            If (gtsTrackerMax(shX).lStatus And 8) <> 0 Then szRangeTempMax = "<" & gtsTrackerMax(shX).sngA
            If (szRangeTempMin <> "" Or szRangeTempMax <> "") Then lblTrackerARange(shX).Text = szRangeTempMin & "A" & szRangeTempMax Else lblTrackerARange(shX).Text = ""
            ToolTip1.SetToolTip(lblTrackerARange(shX), lblTrackerARange(shX).Text)

            szRangeTempMin = "" : szRangeTempMax = ""
            If (gtsTrackerMin(shX).lStatus And 16) <> 0 Then szRangeTempMin = gtsTrackerMin(shX).sngE & "<"
            If (gtsTrackerMax(shX).lStatus And 16) <> 0 Then szRangeTempMax = "<" & gtsTrackerMax(shX).sngE
            If (szRangeTempMin <> "" Or szRangeTempMax <> "") Then lblTrackerERange(shX).Text = szRangeTempMin & "E" & szRangeTempMax Else lblTrackerERange(shX).Text = ""
            ToolTip1.SetToolTip(lblTrackerERange(shX), lblTrackerERange(shX).Text)

            szRangeTempMin = "" : szRangeTempMax = ""
            If (gtsTrackerMin(shX).lStatus And 32) <> 0 Then szRangeTempMin = gtsTrackerMin(shX).sngR & "<"
            If (gtsTrackerMax(shX).lStatus And 32) <> 0 Then szRangeTempMax = "<" & gtsTrackerMax(shX).sngR
            If (szRangeTempMin <> "" Or szRangeTempMax <> "") Then lblTrackerRRange(shX).Text = szRangeTempMin & "R" & szRangeTempMax Else lblTrackerRRange(shX).Text = ""
            ToolTip1.SetToolTip(lblTrackerZRange(shX), lblTrackerZRange(shX).Text)


            ''If ((gtsTrackerMin(shX).lStatus And 2) <> 0 Or (gtsTrackerMax(shX).lStatus And 2) <> 0) Then lblTrackerYRange(shX).Text = "(" & gtsTrackerMin(shX).sngY & " / " & gtsTrackerMax(shX).sngY & ")" Else lblTrackerYRange(shX).Text = ""
            'If ((gtsTrackerMin(shX).lStatus And 4) <> 0 Or (gtsTrackerMax(shX).lStatus And 4) <> 0) Then
            '    lblTrackerZRange(shX).Text = "(" & gtsTrackerMin(shX).sngZ & " / " & gtsTrackerMax(shX).sngZ & ")"
            'Else
            '    lblTrackerZRange(shX).Text = ""
            'End If
            'If ((gtsTrackerMin(shX).lStatus And 8) <> 0 Or (gtsTrackerMax(shX).lStatus And 8) <> 0) Then lblTrackerARange(shX).Text = "(" & gtsTrackerMin(shX).sngA & " / " & gtsTrackerMax(shX).sngA & ")" Else lblTrackerARange(shX).Text = ""
            'If ((gtsTrackerMin(shX).lStatus And 16) <> 0 Or (gtsTrackerMax(shX).lStatus And 16) <> 0) Then lblTrackerERange(shX).Text = "(" & gtsTrackerMin(shX).sngE & " / " & gtsTrackerMax(shX).sngE & ")" Else lblTrackerERange(shX).Text = ""
            'If ((gtsTrackerMin(shX).lStatus And 32) <> 0 Or (gtsTrackerMax(shX).lStatus And 32) <> 0) Then lblTrackerRRange(shX).Text = "(" & gtsTrackerMin(shX).sngR & " / " & gtsTrackerMax(shX).sngR & ")" Else lblTrackerRRange(shX).Text = ""
        Next

        'ViWo
        tabVirtualWorld.Enabled = CBool(Len(gszViWoAddress) <> 0)

        Dim dViWoAvgHead As Double = Math.Round((2 ^ Math.Round(Log2(gsngViWoAvgHead / 1000 * glSamplingRate))) _
                                                    * 1000 / glSamplingRate)
        If Math.Round(gsngViWoAvgHead, 1) <> Math.Round(dViWoAvgHead, 1) Then
            If tabVirtualWorld.Enabled Then szErr = "The average time of the head sensor data must be 2^n (n in N) in samples." & vbCrLf & "Old value:" & vbTab & vbTab & TStr(Math.Round(gsngViWoAvgHead, 1)) & " ms." & vbCrLf & "Corrected value:" & vbTab & TStr(dViWoAvgHead) & " ms." & vbCrLf & vbCrLf
            gsngViWoAvgHead = dViWoAvgHead
        End If
        txtViWoAvgHead.Text = TStr(gsngViWoAvgHead)

        Dim dViWoAvgPointer As Double = Math.Round(2 ^ Math.Round(Log2(gsngViWoAvgPointer / 1000 * glSamplingRate)) _
                                                    * 1000 / glSamplingRate)
        If Math.Round(gsngViWoAvgPointer, 1) <> Math.Round(dViWoAvgPointer, 1) Then
            If tabVirtualWorld.Enabled Then szErr = szErr & "The average time of the Pointer sensor data must be 2^n (n in N) in samples." & vbCrLf & "Old value:" & vbTab & vbTab & TStr(Math.Round(gsngViWoAvgPointer, 1)) & " ms." & vbCrLf & "Corrected value:" & vbTab & TStr(dViWoAvgPointer) & " ms."
            gsngViWoAvgPointer = dViWoAvgPointer
        End If
        txtViWoAvgPointer.Text = TStr(gsngViWoAvgPointer)
        'End If
        If Len(szErr) <> 0 Then MsgBoxOnTop(szErr, MsgBoxStyle.Information, "ViWo Average Time Sensors") : szErr = Nothing


        'Update parameters
        If ViWo.GetParametersCount = 0 Then
            Erase mviwoparTemp ' no parameters
        Else
            ReDim mviwoparTemp(ViWo.GetParametersCount - 1) ' copy parameters to temp
            For lX As Integer = 0 To UBound(mviwoparTemp)
                mviwoparTemp(lX) = New ViWoParameter
                mviwoparTemp(lX) = gviwoparParameters(lX).Copy()
            Next
        End If
        If ViWo.Connected Then
            tabSettings.SelectedTab = Me.tabVirtualWorld
            Dim lY As Integer = -1 ' update list with worlds
            For lX As Integer = 0 To UBound(gszViWoWorlds)
                lstViWoWorlds.Items.Add(gszViWoWorlds(lX))
                If gszViWoWorlds(lX) = gszViWoWorld Then lY = lX
            Next
            If lY > -1 Then
                lstViWoWorlds.SelectedIndex = lY
            ElseIf Len(gszViWoWorld) > 0 Then
                MsgBoxOnTop("Selected world (" & gszViWoWorld & ") is not available")
                lstViWoWorlds.SelectedIndex = 0
            Else
                lstViWoWorlds.SelectedIndex = 0
            End If
            lstViWoWorlds.Enabled = True
        Else ' no connection
            lstViWoWorlds.Items.Add(gszViWoWorlds(0))
            If Len(gszViWoWorld) > 0 And gszViWoWorld <> VIWO_NOWORLD Then
                lstViWoWorlds.Items.Add(gszViWoWorld)
                lstViWoWorlds.SelectedIndex = 1
            Else
                lstViWoWorlds.SelectedIndex = 0
            End If
            lstViWoWorlds.Enabled = False
        End If

        mblnPreventControl = False
        txtPhDurL_TextChanged(txtPhDurL, New System.EventArgs())
        txtPhDurR_TextChanged(txtPhDurR, New System.EventArgs())
        tabSettings.SelectedTab = tabGeneral

        'Vocoder Settings
        If VocType(1) = 1 Then
            Me.GetVoc.Checked = False
            Me.NoiseVoc.Checked = True
        End If

        If VocType(2) = 1 Then
            Me.GetVoc.Checked = True
            Me.NoiseVoc.Checked = False
        End If

        If divFactor > 0 Then
            facScalelbl.Text = CStr(divFactor)
        End If

    End Sub

    Private Function SetSettings() As Boolean
        Dim szErr As String = ""

        ' check parameters
        SetSettings = False
        ' general
        If Len(txtDestinationDir.Text) > 0 Then
            Do While InStr(Len(txtDestinationDir.Text), txtDestinationDir.Text, "\") > 1
                txtDestinationDir.Text = VB.Left(txtDestinationDir.Text, Len(txtDestinationDir.Text) - 1)
            Loop
        End If
        If (mStimOutput = GENMODE.genAcoustical Or mStimOutput = GENMODE.genVocoder Or mStimOutput = GENMODE.genAcousticalUnity) And chkDoNotConnectToDevice.Checked = False Then
            szErr = CheckDestinationDir(txtDestinationDir.Text)
            If szErr <> "" Then MsgBox(szErr, MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "Special Characters in Output Directory") : szErr = ""
        End If

        ' turntable
        gblnTTUse = CBool(chkTTUse.CheckState)



        ' fitting left
        If (mStimOutput = STIM.GENMODE.genElectricalRIB Or mStimOutput = STIM.GENMODE.genElectricalRIB2 Or mStimOutput = STIM.GENMODE.genVocoder) And F4FL.ImpType <> Implant.IMPLANTTYPE.imptInvalid Then
            ' el creation and valid fitting -> check amp/thr/range/mcl/phdur
            If GetUbound(mfreqParL) + 1 <> F4FL.ChannelsCount Then
                szErr = szErr & "Left channel: number of electrodes doesn't match the fitting file." & vbCrLf
            Else
                For lX As Integer = 0 To GetUbound(mfreqParL)
                    With F4FL.Channel(lX)
                        If mfreqParL(lX).lRange <> .lRange Then szErr = szErr & "Left electrode #" & TStr(lX + 1) & ": Range doesn't match fitting file." & vbCrLf
                        If mfreqParL(lX).sTHR <> .lTHR Then szErr = szErr & "Left electrode #" & TStr(lX + 1) & ": THR doesn't match fitting file." & vbCrLf
                        If mfreqParL(lX).sMCL <> .lMCL Then szErr = szErr & "Left electrode #" & TStr(lX + 1) & ": MCL doesn't match fitting file." & vbCrLf
                        Dim dX As Double = mfreqParL(lX).sAmp
                        If dX < .lTHR Or dX > .lMCL Then szErr = szErr & "Left electrode #" & TStr(lX + 1) & ": Amplitude is out of bounds." & vbCrLf
                        If Math.Round(mfreqParL(lX).lPhDur / F4FL.TimeBase) > .lPhDur Then szErr = szErr & "Left electrode #" & TStr(lX + 1) & ": Phase Duration exceeds value in fitting file." & vbCrLf
                    End With
                Next
            End If
            If Len(szErr) <> 0 Then
                SetSettings = True
                MsgBoxOnTop(szErr)
                Exit Function
            End If
            glImpLeft = 1       ' valid fitting, left implant is used
        End If

        ' fitting right
        If (mStimOutput = STIM.GENMODE.genElectricalRIB Or mStimOutput = STIM.GENMODE.genElectricalRIB2 Or mStimOutput = STIM.GENMODE.genVocoder) And F4FR.ImpType <> Implant.IMPLANTTYPE.imptInvalid Then
            ' el creation and valid fitting -> check amp/thr/range/mcl/phdur
            If GetUbound(mfreqParR) + 1 <> F4FR.ChannelsCount Then
                szErr = "Right channel: number of electrodes doesn't match the fitting file."
            Else
                For lX As Integer = 0 To GetUbound(mfreqParR)
                    With F4FR.Channel(lX)
                        If mfreqParR(lX).lRange <> .lRange Then szErr = szErr & "Right electrode #" & TStr(lX + 1) & ": Range doesn't match fitting file." & vbCrLf
                        If mfreqParR(lX).sTHR <> .lTHR Then szErr = szErr & "Right electrode #" & TStr(lX + 1) & ": THR doesn't match fitting file." & vbCrLf
                        If mfreqParR(lX).sMCL <> .lMCL Then szErr = szErr & "Right electrode #" & TStr(lX + 1) & ": MCL doesn't match fitting file." & vbCrLf
                        Dim dX As Double = mfreqParR(lX).sAmp
                        If dX < .lTHR Or dX > .lMCL Then szErr = szErr & "Right electrode #" & TStr(lX + 1) & ": Amplitude is out of bounds." & vbCrLf
                        If Math.Round(mfreqParR(lX).lPhDur / F4FR.TimeBase) > .lPhDur Then szErr = szErr & "Right electrode #" & TStr(lX + 1) & ": Phase Duration exceeds value in fitting file." & vbCrLf
                    End With
                Next
            End If
            If Len(szErr) <> 0 Then
                SetSettings = True
                MsgBoxOnTop(szErr)
                Exit Function
            End If
            glImpRight = 2       ' valid fitting, right implant is used
        End If

        ' description
        If Len(txtID.Text) = 0 Then
            szErr = szErr & "You must enter an experiment ID" & vbCrLf
        End If

        ' experiment screen
        gblnExpOnTop = CBool(chkAlwaysOnTop.CheckState)
        gblnOverrideExpMode = CBool(chkOverrideExpMode.CheckState)
        gOExpMode = CInt(OexpMode.Value)
        ' signal
        Select Case mStimOutput
            Case GENMODE.genAcoustical, GENMODE.genAcousticalUnity
                For lX As Integer = 0 To GetUbound(mfreqParL)
                    If Math.Round(mfreqParL(lX).lPhDur / 1000000 * Val((txtSamplingRate.Text))) < 1 Then
                        szErr = szErr & lblSignal.Text & " Left #" & TStr(lX + 1) & ": " & lblPhDur.Text & " too small" & vbCrLf
                    End If
                Next
                For lX As Integer = 0 To GetUbound(mfreqParR)
                    If Math.Round(mfreqParR(lX).lPhDur / 1000000 * Val((txtSamplingRate.Text))) < 1 Then
                        szErr = szErr & lblSignal.Text & " Right #" & TStr(lX + 1) & ": " & lblPhDur.Text & " too small" & vbCrLf
                    End If
                Next
        End Select

        ' audio
        For shX As Short = 0 To 1
            If Not IsNumeric(txtAudioDitherLC(shX).Text) Then szErr = szErr & "Audio, Synth " & Chr(65 + shX) & ": Low Cut is not numeric" & vbCrLf
            If Not IsNumeric(txtAudioDitherHC(shX).Text) Then szErr = szErr & "Audio, Synth " & Chr(65 + shX) & ": High Cut is not numeric" & vbCrLf
            If Not IsNumeric(txtAudioDitherPar1(shX).Text) Then szErr = szErr & "Audio, Synth " & Chr(65 + shX) & ": Par1 is not numeric" & vbCrLf
        Next

        ' procedure constants
        If Len(txtInterStimBreak.Text) = 0 Or Not IsNumeric((txtInterStimBreak.Text)) Then
            szErr = szErr & "Set the length of the interstimulus break to a positive value" & vbCrLf
        ElseIf Val((txtInterStimBreak.Text)) < 0 Then
            szErr = szErr & "Set the length of the interstimulus break to a positive value" & vbCrLf
        End If
        If Len(txtRepetition.Text) = 0 Or Not IsNumeric((txtRepetition.Text)) Then
            szErr = szErr & "Set the number of repetitions to at least 1" & vbCrLf
        ElseIf Val((txtRepetition.Text)) < 1 Then
            szErr = szErr & "Set the number of repetitions to at least 1" & vbCrLf
        End If
        If F4FL.ImpType <> Implant.IMPLANTTYPE.imptInvalid Then ' check only if fitting is valid
            Select Case mStimOutput
                Case STIM.GENMODE.genElectricalRIB
                    If Len(txtOffsetL.Text) = 0 Or Not IsNumeric((txtOffsetL.Text)) Then
                        szErr = szErr & "Set the left offset to 0 or at least " & TStr(Int(F4FL.TimeBase * F4FL.MINDIST_MIN + 1)) & "us" & vbCrLf
                    ElseIf Val((txtOffsetL.Text)) < F4FL.TimeBase * F4FL.MINDIST_MIN And Val((txtOffsetL.Text)) <> 0 Then
                        szErr = szErr & "Set the left offset to 0 or at least " & TStr(Int(F4FL.TimeBase * F4FL.MINDIST_MIN + 1)) & "us" & vbCrLf
                    End If
                Case STIM.GENMODE.genElectricalRIB2, GENMODE.genVocoder
                    If Len(txtOffsetL.Text) = 0 Or Not IsNumeric((txtOffsetL.Text)) Then
                        szErr = szErr & "Set the left offset at least " & TStr(Int(F4FL.TimeBase * F4FL.MINDIST_MIN)) & "us" & vbCrLf
                    ElseIf Val((txtOffsetL.Text)) < F4FL.TimeBase * F4FL.MINDIST_MIN Then
                        szErr = szErr & "Set the left offset at least " & TStr(Int(F4FL.TimeBase * F4FL.MINDIST_MIN)) & "us" & vbCrLf
                    End If
            End Select
        End If
        If F4FR.ImpType <> Implant.IMPLANTTYPE.imptInvalid Then ' check only if fitting is valid
            Select Case mStimOutput
                Case STIM.GENMODE.genElectricalRIB
                    If Len(txtOffsetR.Text) = 0 Or Not IsNumeric((txtOffsetR.Text)) Then
                        szErr = szErr & "Set the right offset to 0 or at least " & TStr(Int(F4FR.TimeBase * F4FR.MINDIST_MIN + 1)) & "us" & vbCrLf
                    ElseIf Val((txtOffsetR.Text)) < F4FR.TimeBase * F4FR.MINDIST_MIN And Val((txtOffsetR.Text)) <> 0 Then
                        szErr = szErr & "Set the right offset to 0 or at least " & TStr(Int(F4FR.TimeBase * F4FR.MINDIST_MIN + 1)) & "us" & vbCrLf
                    End If
                Case STIM.GENMODE.genElectricalRIB2, GENMODE.genVocoder
                    If Len(txtOffsetR.Text) = 0 Or Not IsNumeric((txtOffsetR.Text)) Then
                        szErr = szErr & "Set the right offset at least " & TStr(Int(F4FR.TimeBase * F4FR.MINDIST_MIN)) & "us" & vbCrLf
                    ElseIf Val((txtOffsetR.Text)) < F4FR.TimeBase * F4FR.MINDIST_MIN Then
                        szErr = szErr & "Set the right offset at least " & TStr(Int(F4FR.TimeBase * F4FR.MINDIST_MIN)) & "us" & vbCrLf
                    End If
            End Select
        End If
        If Len(txtPreStimBreak.Text) = 0 Or Not IsNumeric((txtPreStimBreak.Text)) Then
            szErr = szErr & "Pre-stimulus break must be zero or positive." & vbCrLf
        ElseIf Val((txtPreStimBreak.Text)) < 0 Then
            szErr = szErr & "Pre-stimulus break must be zero or positive." & vbCrLf
        End If
        If Len(txtPreStimVisu.Text) = 0 Or Not IsNumeric((txtPreStimVisu.Text)) Then
            szErr = szErr & "Pre-stimulus visual offset must be zero or positive." & vbCrLf
        ElseIf Val((txtPreStimVisu.Text)) < 0 Then
            szErr = szErr & "Pre-stimulus visual offset must be zero or positive." & vbCrLf
        End If
        If Len(txtPostStimVisu.Text) = 0 Or Not IsNumeric((txtPostStimVisu.Text)) Then
            szErr = szErr & "Post-stimulus visual offset must be zero or positive." & vbCrLf
        ElseIf Val((txtPostStimVisu.Text)) < 0 Then
            szErr = szErr & "Post-stimulus visual offset must be zero or positive." & vbCrLf
        End If
        If Len(txtBreak.Text) = 0 Or Not IsNumeric((txtBreak.Text)) Then
            szErr = szErr & "Break Interval must be greater than 0." & vbCrLf
        ElseIf Val((txtBreak.Text)) < 1 Then
            szErr = szErr & "Break Interval must be greater than 0." & vbCrLf
        End If

        ' constants
        If GetUboundConstants() <> -1 Then
            For shX As Short = 0 To CShort(Math.Min(UBound(gconstExp), txtConstValue.UBound))
                With gconstExp(shX)
                    szErr &= CheckConstant(txtConstValue(shX).Text, gconstExp(shX), mfreqParL, mfreqParR)
                End With
            Next
        End If

        ' variables list
        If GetUboundVariables() <> -1 Then
            For shX As Short = 0 To CShort(Math.Min(UBound(gvarExp), lstVariables.UBound))
                For lX As Integer = 0 To lstVariables(shX).Items.Count - 1
                    szErr &= CheckVariable(VB6.GetItemString(lstVariables(shX), lX), gvarExp(shX), mfreqParL, mfreqParR)
                Next
                With gvarExp(shX)
                    ' linked variables
                    If (.Flags And (FWintern.VariableFlags.vfLinked * 15)) <> 0 Then
                        Dim lX As Integer = ((.Flags And (FWintern.VariableFlags.vfLinked * 15)) \ FWintern.VariableFlags.vfLinked) - 1
                        If lX <= UBound(gvarExp) And lX <> shX Then
                            If lstVariables(CShort(lX)).Items.Count <> lstVariables(shX).Items.Count Then
                                szErr = szErr & .szName & " list must contain the same number of items as " & gvarExp(lX).szName & " list." & vbCrLf
                            End If
                        End If
                    End If
                End With
            Next
        End If

        ' ViWo
        If IsNumeric((txtViWoAvgHead.Text)) Then
            Dim lX As Integer = CInt(Val(txtSamplingRate.Text))
            Dim dX As Double = Val((txtViWoAvgHead.Text))
            dX = 2 ^ Math.Round(Log2(dX / 1000 * lX))
            If txtViWoAvgHead.Text <> TStr(Math.Round(dX * 1000 / lX)) Then
                If tabVirtualWorld.Enabled Then szErr = szErr & "The average time of the head sensor data must be 2^n (n in N) in samples." & vbCrLf & "   New value was set to " & TStr(Math.Round(dX * 1000 / lX)) & " ms." & vbCrLf
                txtViWoAvgHead.Text = TStr(Math.Round(dX * 1000 / lX))
            End If
        Else
            szErr = szErr & "Head Sensor: Average time must be numeric." & vbCrLf
        End If

        If IsNumeric((txtViWoAvgPointer.Text)) Then
            Dim lX As Integer = CInt(Val(txtSamplingRate.Text))
            Dim dX As Double = Val((txtViWoAvgPointer.Text))
            dX = 2 ^ Math.Round(Log2(dX / 1000 * lX))
            If txtViWoAvgPointer.Text <> TStr(Math.Round(dX * 1000 / lX)) Then
                If tabVirtualWorld.Enabled Then szErr = szErr & "The average time of the pointer sensor data must be 2^n (n in N) in samples." & vbCrLf & "   New value was set to " & TStr(Math.Round(dX * 1000 / lX)) & " ms." & vbCrLf
                txtViWoAvgPointer.Text = TStr(Math.Round(dX * 1000 / lX))
            End If
        Else
            szErr = szErr & "Pointer Sensor: Average time must be numeric." & vbCrLf
        End If


        ' cancel if a parameter was out of bound
        If Len(szErr) <> 0 Then
            MsgBoxOnTop(szErr, MsgBoxStyle.Critical, "Invalid Settings")
            SetSettings = True
            Exit Function
        End If

        SetSettings = False

        ' ----------------------------------------------------
        ' save all values
        ' ----------------------------------------------------
        ' general
        INISettings.gStimOutput = mStimOutput
        gszDestinationDir = txtDestinationDir.Text

        If chkTempDir.CheckState = CheckState.Checked Then
            gblnDestinationDir = False
        Else
            gblnDestinationDir = True
        End If
        gblnNewWorkDir = CBool(chkNewWorkDir.CheckState)
        gblnSilentMode = CBool(chkSilentMode.CheckState)
        gblnDoNotConnectToDevice = CBool(chkDoNotConnectToDevice.CheckState)
        For lX As Integer = 0 To DataDirectory.Count - 1
            DataDirectory.Path(lX) = mszDataDir(lX)
        Next
        ' fitting left
        gszSourceDir = txtSourceDir.Text
        gszFittFileLeft = txtFittFile(0).Text
        If (mStimOutput = STIM.GENMODE.genElectricalRIB Or mStimOutput = STIM.GENMODE.genElectricalRIB2 Or mStimOutput = STIM.GENMODE.genVocoder) And F4FL.ImpType = Implant.IMPLANTTYPE.imptInvalid Then
            ' electrical stimulation and invalid fitting -> erase signals of this channel
            Erase mfreqParL
            Erase gfreqParL
            glElectrodeL = -1
            mlElectrodeL = -1
            UpdateSignalTab(0)
        End If

        ' fitting right
        gszFittFileRight = txtFittFile(1).Text
        If (mStimOutput = STIM.GENMODE.genElectricalRIB Or mStimOutput = STIM.GENMODE.genElectricalRIB2 Or mStimOutput = STIM.GENMODE.genVocoder) And F4FR.ImpType = Implant.IMPLANTTYPE.imptInvalid Then
            ' electrical stimulation and invalid fitting -> erase signals of this channel
            Erase mfreqParR
            Erase gfreqParR
            glElectrodeR = -1
            mlElectrodeR = -1
            UpdateSignalTab(Implant.EARTYPE.RIGHT)
        End If

        ' description
        gszDescription = txtDescription.Text
        gszExpID = txtID.Text
        ' experiment screen
        grectExp.Height = CInt(Val(txtExpHeight.Text))
        grectExp.Width = CInt(Val(txtExpWidth.Text))
        grectExp.Left = CInt(Val(txtExpLeft.Text))
        grectExp.Top = CInt(Val(txtExpTop.Text))
        glExpHUIID = cmbHUI.SelectedIndex
        INISettings.glExpFlags = 0
        For lX As Integer = 0 To lstExpFlags.Items.Count - 1
            If lstExpFlags.GetItemChecked(lX) Then INISettings.glExpFlags = INISettings.glExpFlags Or DirectCast(CInt(2 ^ lX), frmExp.EXPFLAGS)
        Next
        ' signal
        If GetUbound(mfreqParL) > -1 Then
            glElectrodeL = mlElectrodeL
            ReDim gfreqParL(GetUbound(mfreqParL))
            For lX As Integer = 0 To GetUbound(mfreqParL)
                gfreqParL(lX) = mfreqParL(lX).Copy
            Next
        Else
            Erase gfreqParL
            glElectrodeL = 0
        End If
        If GetUbound(mfreqParR) > -1 Then
            glElectrodeR = mlElectrodeR
            ReDim gfreqParR(GetUbound(mfreqParR))
            For lX As Integer = 0 To GetUbound(mfreqParR)
                gfreqParR(lX) = mfreqParR(lX).Copy
            Next
        Else
            Erase gfreqParR
            glElectrodeR = 0
        End If

        ' audio
        divFactor = CDbl(facScalelbl.Text)
        glSamplingRate = CInt(Val((txtSamplingRate.Text)))
        glResolution = CInt(Val((txtResolution.Text)))
        gsFadeIn = Val((txtFadeIn.Text))
        gsFadeOut = Val((txtFadeOut.Text))
        gblnUseDataChannel = CBool(ckbUseDataChannel.CheckState)
        gblnUseTriggerChannel = CBool(ckbUseTriggerChannel.CheckState)
        For shX As Short = 0 To 1
            With gAudioSynth(shX)
                .Signal = cmbAudioDither(shX).SelectedIndex
                .Vol = (sldAudioDitherAmp.Item(shX).Value - 1000) / 10
                .LowCut = Val(txtAudioDitherLC(shX).Text)
                .HighCut = Val(txtAudioDitherHC(shX).Text)
                .Par1 = Val(txtAudioDitherPar1(shX).Text)
            End With
        Next
        If glPlayerChannels = 2 Then
            For shX As Short = 0 To 2
                If optAudioDitherLeft(shX).Checked Then glAudioDACAddStream(0) = shX
                If optAudioDitherRight(shX).Checked Then glAudioDACAddStream(1) = shX
            Next
        Else
            For lX As Integer = 0 To glPlayerChannels - 1
                glAudioDACAddStream(lX) = mlAudioDACAddStream(lX)
            Next
        End If

        ' procedure constants
        glInterStimBreak = CInt(Val((txtInterStimBreak.Text)))
        glRepetition = CInt(Val((txtRepetition.Text)))
        glOffsetL = CInt(Val((txtOffsetL.Text)))
        glOffsetR = CInt(Val((txtOffsetR.Text)))
        glExpType = cmbExpType.SelectedIndex
        glPreStimBreak = CInt(Val((txtPreStimBreak.Text)))
        glPreStimVisu = CInt(Val((txtPreStimVisu.Text)))
        glPostStimVisu = CInt(Val((txtPostStimVisu.Text)))
        glBreakInterval = CInt(Val((txtBreak.Text)))
        glBreakFlags = chkBreak.CheckState + cmbBreak.SelectedIndex * 2
        'glExperimentStartItem = CInt(txtExperimentStartItem.Text)
        'glExperimentEndItem = CInt(txtExperimentEndItem.Text)

        ' constants
        If GetUboundConstants() <> -1 Then
            For shX As Short = 0 To CShort(UBound(gconstExp))
                With gconstExp(shX)
                    If ((.Flags And 15) = FWintern.VariableFlags.vfNumeric) And ((.Flags And FWintern.VariableFlags.vfVectorized) = 0) Then
                        .varValue = txtConstValue(shX).Text
                    Else
                        .varValue = txtConstValue(shX).Text
                    End If
                End With
            Next
        End If

        ' variables
        If Not IsNumeric(gvarExp) Then
            For shX As Short = 0 To CShort(UBound(gvarExp))
                With gvarExp(shX)
                    If lstVariables(shX).Items.Count = 0 Then
                        Erase .varValue
                    Else
                        ReDim .varValue(lstVariables(shX).Items.Count - 1)
                        For lY As Integer = 0 To lstVariables(shX).Items.Count - 1
                            If ((.Flags And 15) = FWintern.VariableFlags.vfNumeric) And ((.Flags And FWintern.VariableFlags.vfVectorized) = 0) Then
                                .varValue(lY) = VB6.GetItemString(lstVariables(shX), lY)
                            Else
                                .varValue(lY) = VB6.GetItemString(lstVariables(shX), lY)
                            End If
                        Next
                    End If
                End With
            Next
        End If

        ' tracker
        gblnTrackerUse = CBool(chkTrackerUse.CheckState)
        glTrackerRepRate = cmbTrackerRepRate.SelectedIndex + 1
        gsngTrackerPosScaling = Val(VB6.GetItemString(cmbTrackerPosScaling, cmbTrackerPosScaling.SelectedIndex))
        For lX As Integer = 0 To glTrackerSensorCount - 1
            gtsTrackerValues(lX) = mtsTrackerValues(lX)
            gtsTrackerOffset(lX) = mtsTrackerOffset(lX)
        Next


        ' ViWo
        gsngViWoAvgHead = Val((txtViWoAvgHead.Text))
        gsngViWoAvgPointer = Val((txtViWoAvgPointer.Text))
        If lstViWoWorlds.SelectedIndex = 0 Then
            gszViWoWorld = ""
        Else
            gszViWoWorld = VB6.GetItemString(lstViWoWorlds, lstViWoWorlds.SelectedIndex)
        End If
        ViWo.ClearParameters()
        If Not IsNothing(mviwoparTemp) Then
            For lX As Integer = 0 To mviwoparTemp.Length - 1
                If mviwoparTemp(lX).Dirty Then ViWo.AddParameter(mviwoparTemp(lX))
            Next
        End If
        ' notify main form, that some parameter were changed
        lblRealTime.Visible = False
        If Not IsNothing(glOnSettingsSetAddr) Then glOnSettingsSetAddr()
        gblnSettingsChanged = True
        If gszExpRequestText(glExpType) <> "" Then frmMain.SetStatus("Subject's Request Text: " & gszExpRequestText(glExpType))

    End Function

    Public Function CheckDestinationDir(Optional szDir As String = "") As String
        'check if output directory/destination directory contains special characters
        If szDir = "" Then szDir = gszDestinationDir
        If CBool(Strings.InStr(Strings.LCase(szDir), "ö")) Or CBool(Strings.InStr(Strings.LCase(szDir), "ä")) Or CBool(Strings.InStr(Strings.LCase(szDir), "ü")) Or CBool(Strings.InStr(Strings.LCase(szDir), "ß")) Then _
                Return "Output Directory" & vbCrLf & vbCrLf & szDir & vbCrLf & vbCrLf & "contains special characters (ö, ä, ü, ß). This might cause problems when using pd for stimulation!"

        'alles in Butter
        Return ""

    End Function

    Private Sub chkBreak_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkBreak.CheckStateChanged
        If Me.IsInitializing = True Then Return
        TextBoxState(txtBreak, CBool(chkBreak.CheckState))
        cmbBreak.Enabled = CBool(chkBreak.CheckState)
    End Sub

    Private Sub chkTempDir_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkTempDir.CheckStateChanged
        If Me.IsInitializing = True Then Return
        TextBoxState(txtDestinationDir, Not CBool(chkTempDir.CheckState))
        cmdDestinationDir.Enabled = Not CBool(chkTempDir.CheckState)
    End Sub

    Private Sub chkTrackerSaveData_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkTrackerSaveData.CheckStateChanged
        If Me.IsInitializing = True Then Return
        If chkTrackerSaveData.CheckState = CheckState.Unchecked Then
            ' disable saving
            If mblnTrackerSaveData Then
                FileClose(mlTrackerFNr)
            End If
            chkTrackerSaveData.Text = "Save data to a file"
            mblnTrackerSaveData = False
        Else
            ' enable saving
            'Me.TopMost = False
            Dim szX As String = InputBox("File name?", , "D:\temp\tracker.csv")
            'Me.TopMost = True
            If Len(szX) = 0 Then chkTrackerSaveData.CheckState = CheckState.Unchecked : Return
            mlTrackerFNr = FreeFile()
            On Error GoTo SubError
            FileOpen(mlTrackerFNr, szX, OpenMode.Append)
            'Debug.Print #mlTrackerFNr, "-------- Begin:", Date
            'Debug.Print #mlTrackerFNr, "Time, Sensor, X, Y, Z, A, E, R, Turntable"
            On Error GoTo 0
            mblnTrackerSaveData = True
            chkTrackerSaveData.Text = "Save data to " & szX
        End If
        Return

SubError:
        MsgBoxOnTop("Error opening file:" & Err.Description)
        chkTrackerSaveData.CheckState = CheckState.Unchecked
    End Sub

    Private Sub chkTrackerUse_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkTrackerUse.CheckStateChanged
        If Me.IsInitializing = True Then Return
        For lX As Short = 0 To CShort(glTrackerSensorCount - 1)
            cmdTrackerSetValues(lX).Enabled = CBool(chkTrackerUse.CheckState)
            cmdTrackerSetOffset(lX).Enabled = CBool(chkTrackerUse.CheckState)
        Next
    End Sub

    Private Sub chkViWoSendData_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkViWoSendData.CheckStateChanged
        If Me.IsInitializing = True Then Return

        If chkViWoSendData.CheckState = CheckState.Checked Then
            ' program tracker to send data to viwo
            Dim sngInt1 As Double = Val((txtViWoAvgHead.Text))
            sngInt1 = 2 ^ Math.Round(Log2(sngInt1 / 1000 * glSamplingRate))
            Output.Send("/Tracker/SendData/0/Interval", sngInt1)
            Output.Send("/Tracker/SendData/0/Connection", "connect", gszViWoAddress, glViWoPort)
            TextBoxState(txtViWoAvgHead, False)
            If glTrackerSensorCount > 1 Then
                Dim sngInt2 As Double = Val((txtViWoAvgPointer.Text))
                sngInt2 = 2 ^ Math.Round(Log2(sngInt2 / 1000 * glSamplingRate))
                Output.Send("/Tracker/SendData/1/Interval", sngInt2)
                Output.Send("/Tracker/SendData/1/Connection", "connect", gszViWoAddress, glViWoPort)
                TextBoxState(txtViWoAvgPointer, False)
            End If
        Else
            ' program tracker to stop sending data to viwo
            Output.Send("/Tracker/SendData/0/Connection", "disconnect")
            TextBoxState(txtViWoAvgHead, True)
            If glTrackerSensorCount > 1 Then
                Output.Send("/Tracker/SendData/1/Connection", "disconnect")
                TextBoxState(txtViWoAvgPointer, True)
            End If
        End If
    End Sub

    Private Sub cmbAudioDither_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbAudioDither.SelectedIndexChanged
        If Me.IsInitializing = True Then Return
        Dim Index As Short = cmbAudioDither.GetIndex(DirectCast(eventSender, ComboBox))
        Dim lX As Integer

        lX = cmbAudioDither(Index).SelectedIndex
        sldAudioDitherAmp(Index).Enabled = CBool(lX > 0)
        TextBoxState(txtAudioDitherLC(Index), CBool(lX > 0))
        TextBoxState(txtAudioDitherHC(Index), CBool(lX > 0))
        Select Case lX
            Case 0
                TextBoxState(txtAudioDitherPar1(Index), False)
                lblAudio(CShort(4 + 3 * Index)).Text = ""
            Case 1
                TextBoxState(txtAudioDitherPar1(Index), False)
                lblAudio(CShort(4 + 3 * Index)).Text = ""
            Case 2
                TextBoxState(txtAudioDitherPar1(Index), False)
                lblAudio(CShort(4 + 3 * Index)).Text = ""
            Case 3
                TextBoxState(txtAudioDitherPar1(Index), True)
                lblAudio(CShort(4 + 3 * Index)).Text = "Freq. [Hz]"
            Case 4, 5
                TextBoxState(txtAudioDitherPar1(Index), True)
                lblAudio(CShort(4 + 3 * Index)).Text = "Cut off freq. [Hz]"
        End Select
        If mblnPreventControl Then Return
        If Not mblnOutputStable Then Return

        RealTimeChange()
        Select Case lX
            Case 0
                Output.Send("/Synth/SetSignal/" & TStr(Index), "nope")
                Exit Sub
            Case 1
                Output.Send("/Synth/SetSignal/" & TStr(Index), "pink")
            Case 2
                Output.Send("/Synth/SetSignal/" & TStr(Index), "white")
            Case 3
                Output.Send("/Synth/SetSignal/" & TStr(Index), "cosine")
            Case 4
                Output.Send("/Synth/SetSignal/" & TStr(Index), "lp4white")
            Case 5
                Output.Send("/Synth/SetSignal/" & TStr(Index), "lp16white")
        End Select
        Dim wsX As FWintern.WarningSwitches = INIOptions.glWarningSwitches
        INIOptions.glWarningSwitches = INIOptions.glWarningSwitches Or FWintern.WarningSwitches.RealTimeParameterChange
        txtAudioDitherPar1_TextChanged(txtAudioDitherPar1.Item(Index), New System.EventArgs())
        txtAudioDitherLC_TextChanged(txtAudioDitherLC.Item(Index), New System.EventArgs())
        txtAudioDitherHC_TextChanged(txtAudioDitherHC.Item(Index), New System.EventArgs())
        sldAudioDitherAmp_Change(sldAudioDitherAmp.Item(Index), New System.EventArgs())
        INIOptions.glWarningSwitches = wsX
    End Sub

    Private Sub cmbAudioSynthCh_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbAudioSynthCh.KeyDown
        If e.KeyCode = Keys.A Then
            _optAudioSynthDAC_1.Checked = True
        ElseIf e.KeyCode = Keys.B Or e.KeyCode = Keys.S Then
            _optAudioSynthDAC_2.Checked = True
        ElseIf e.KeyCode = Keys.D Then
            _optAudioSynthDAC_0.Checked = True
        End If
    End Sub

    Private Sub cmbAudioSynthCh_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbAudioSynthCh.SelectedIndexChanged
        If Me.IsInitializing = True Then Return
        If mblnPreventControl Then Return
        Dim lX As Integer = cmbAudioSynthCh.SelectedIndex
        If lX < 0 Then Return
        mblnPreventControl = True
        optAudioSynthDAC(CShort(mlAudioDACAddStream(lX))).Checked = True
        mblnPreventControl = False
    End Sub

    Private Sub cmbDataDir_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbDataDir.SelectedIndexChanged
        If Me.IsInitializing = True Then Return
        txtDataDir.Text = mszDataDir(cmbDataDir.SelectedIndex)
    End Sub

    Private Sub cmbElL_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbElL.SelectedIndexChanged
        If Me.IsInitializing = True Then Return
        Dim lX, lY As Integer

        If Not cmbElL.Enabled Then Exit Sub
        lX = cmbElL.SelectedIndex
        mlElectrodeL = lX + 1
        If lX = -1 Then Exit Sub
        With mfreqParL(lX)
            Select Case mStimOutput
                Case STIM.GENMODE.genAcoustical, GENMODE.genAcousticalUnity
                    txtSPLOffsetL.Text = TStr(.sSPLOffset)
                    txtAmpL.Text = TStr(.sAmp)
                    txtCenterFreqL.Text = TStr(.sCenterFreq)
                    txtBandwidthL.Text = TStr(.sBandwidth)
                    txtTHRL.Text = TStr(.sTHR)
                    txtMCLL.Text = TStr(.sMCL)
                    txtPhDurL.Text = TStr(.lPhDur)
                Case STIM.GENMODE.genElectricalRIB, STIM.GENMODE.genElectricalNIC, STIM.GENMODE.genElectricalRIB2, STIM.GENMODE.genVocoder
                    lblMCLL.Text = TStr(F4FL.Channel(lX).lRange) & ":" & TStr(F4FL.Channel(lX).lMCL) & vbCrLf & _
                                       F4FL.CalcCurrentAsString(F4FL.Channel(lX).lMCL, F4FL.Channel(lX).lRange)
                    lblTHRL.Text = TStr(F4FL.Channel(lX).lRange) & ":" & TStr(F4FL.Channel(lX).lTHR) & vbCrLf & _
                                       F4FL.CalcCurrentAsString(F4FL.Channel(lX).lTHR, F4FL.Channel(lX).lRange)
                    txtPhDurL.Text = TStr(.lPhDur)
                    cmbRangeL.SelectedIndex = .lRange
                    ' slider size
                    sldL.Maximum = 32000 'very high value to provide max>min anytime
                    sldL.Minimum = CInt(Math.Round(.sTHR))
                    lY = CInt(Math.Round(.sMCL))
                    If lY > F4FL.AMP_MAX Then lY = F4FL.AMP_MAX
                    If lY <= sldL.Minimum Then
                        sldL.Enabled = False
                        lY = sldL.Minimum + 1
                    Else
                        sldL.Enabled = True
                    End If
                    sldL.Maximum = lY
                    ' current amplitude value
                    If sldL.Enabled Then
                        lY = CInt(Math.Round(.sAmp))
                        If lY > sldL.Maximum Then lY = sldL.Maximum
                        If lY < sldL.Minimum Then lY = sldL.Minimum
                    Else
                        lY = sldL.Minimum
                    End If
                    sldL.Value = lY
                    sldL_Change(sldL, New System.EventArgs())
                    lblDynamicL.Text = TStr(Math.Round(20 * System.Math.Log10(sldL.Maximum - sldL.Minimum), 1)) & " dB"
            End Select
        End With
    End Sub

    Private Sub cmbElR_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbElR.SelectedIndexChanged
        If Me.IsInitializing = True Then Return
        If Not cmbElR.Enabled Then Return

        Dim lX As Integer = cmbElR.SelectedIndex
        mlElectrodeR = lX + 1
        If lX = -1 Then Return

        With mfreqParR(lX)
            Select Case mStimOutput
                Case STIM.GENMODE.genAcoustical, GENMODE.genAcousticalUnity
                    txtSPLOffsetR.Text = TStr(.sSPLOffset)
                    txtAmpR.Text = TStr(.sAmp)
                    txtCenterFreqR.Text = TStr(.sCenterFreq)
                    txtBandwidthR.Text = TStr(.sBandwidth)
                    txtTHRR.Text = TStr(.sTHR)
                    txtMCLR.Text = TStr(.sMCL)
                    txtPhDurR.Text = TStr(.lPhDur)
                Case STIM.GENMODE.genElectricalRIB, STIM.GENMODE.genElectricalNIC, STIM.GENMODE.genElectricalRIB2, GENMODE.genVocoder
                    lblMCLR.Text = TStr(F4FR.Channel(lX).lRange) & ":" & TStr(F4FR.Channel(lX).lMCL) & vbCrLf & F4FR.CalcCurrentAsString(F4FR.Channel(lX).lMCL, F4FR.Channel(lX).lRange)
                    lblTHRR.Text = TStr(F4FR.Channel(lX).lRange) & ":" & TStr(F4FR.Channel(lX).lTHR) & vbCrLf & F4FR.CalcCurrentAsString(F4FR.Channel(lX).lTHR, F4FR.Channel(lX).lRange)
                    txtPhDurR.Text = TStr(.lPhDur)
                    cmbRangeR.SelectedIndex = .lRange
                    ' slider size
                    sldR.Maximum = 32000 'very high value to provide max>min anytime
                    sldR.Minimum = CInt(Math.Round(.sTHR))
                    Dim lY As Integer = CInt(Math.Round(.sMCL))
                    If lY > F4FR.AMP_MAX Then lY = F4FR.AMP_MAX
                    If lY <= sldR.Minimum Then
                        sldR.Enabled = False
                        lY = sldR.Minimum + 1
                    Else
                        sldR.Enabled = True
                    End If
                    sldR.Maximum = lY
                    ' current amplitude value
                    If sldR.Enabled Then
                        lY = CInt(Math.Round(.sAmp))
                        If lY > sldR.Maximum Then lY = sldR.Maximum
                        If lY < sldR.Minimum Then lY = sldR.Minimum
                    Else
                        lY = sldR.Minimum
                    End If
                    sldR.Value = lY
                    sldR_Change(sldR, New System.EventArgs())
                    lblDynamicR.Text = TStr(Math.Round(20 * System.Math.Log10(sldR.Maximum - sldR.Minimum), 1)) & " dB"
            End Select
        End With
    End Sub

    Private Sub cmbExpType_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbExpType.SelectedIndexChanged
        If Me.IsInitializing = True Then Return
        If mblnPreventControl Then Return
        If Not IsNothing(glOnSettingsExpTypeChangeAddr) Then glOnSettingsExpTypeChangeAddr(mlExpType, (cmbExpType.SelectedIndex))
        mlExpType = cmbExpType.SelectedIndex
        UpdateConstants()
        UpdateVariables()
    End Sub

    Private Sub cmbVariables_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbVariables.SelectedIndexChanged
        If Me.IsInitializing = True Then Return
        Dim lIdx, lX, lY As Integer
        Dim Flags As FWintern.VariableFlags
        Dim szDescr As String

        lIdx = cmbVariables.SelectedIndex
        If lIdx < 0 Then Return
        If lIdx > 0 And cmbVariables.Items.Count > 3 Then cmbVariables.TopIndex = lIdx - 1
        For lX = 0 To lstVariables.Count - 1
            lstVariables(CShort(lX)).Visible = (lX = lIdx)
            lstVariables(CShort(lX)).Left = lstVariables(0).Left
        Next
        ' default button
        cmdVariablesDefault.Enabled = CBool(Len(gvarExp(cmbVariables.SelectedIndex).szDefault) <> 0)

        ' check input
        Flags = gvarExp(lIdx).Flags
        szDescr = ""

        Select Case (Flags And FWintern.VariableFlags.vfFlagTypeMask)
            Case FWintern.VariableFlags.vfNumeric
                cmdVariablesBrowse.Visible = False
                cmdVariablesDir.Visible = False
                szDescr = szDescr & "- Must be numeric" & vbCrLf
                If (Flags And FWintern.VariableFlags.vfVectorized) <> 0 Then szDescr = szDescr & "- Can be a vector, separate by blank or ;" & vbCrLf
                If (Flags And FWintern.VariableFlags.vfInteger) <> 0 Then szDescr = szDescr & "- Must be integer" & vbCrLf
                If (Flags And FWintern.VariableFlags.vfNonZero) <> 0 Then szDescr = szDescr & "- Must be non-zero" & vbCrLf
                If (Flags And FWintern.VariableFlags.vfMin) <> 0 Then szDescr = szDescr & "- Must not be below " & TStr(gvarExp(lIdx).dMin) & vbCrLf
                If (Flags And FWintern.VariableFlags.vfMax) <> 0 Then szDescr = szDescr & "- Must not exceed " & TStr(gvarExp(lIdx).dMax) & vbCrLf
                If (Flags And FWintern.VariableFlags.vfMinTimeDelay) <> 0 Then szDescr = szDescr & "- Must be greater than or equal the smallest time delay. Check performed only in acoustical stim." & vbCrLf
                If (Flags And FWintern.VariableFlags.vfOffsetDependent) <> 0 Then szDescr = szDescr & "- May be limited by offset" & vbCrLf

            Case FWintern.VariableFlags.vfElectrodeL
                szDescr = szDescr & "- Must be left " & lblSignal.Text & vbCrLf
            Case FWintern.VariableFlags.vfElectrodeR
                szDescr = szDescr & "- Must be right " & lblSignal.Text & vbCrLf

            Case FWintern.VariableFlags.vfFileName ' file name
                cmdVariablesBrowse.Visible = True
                cmdVariablesDir.Visible = False
                If (Flags And &H70S) = FWintern.VariableFlags.vfAbsolute Then
                    szDescr = "- Must be a file name" & vbCrLf
                Else
                    szDescr = "- Must be a file name relative to the data directory "
                    lX = CShort((Flags \ &H10) And 7) - 1
                    If lX > GetUbound(mszDataDir) Then
                        szDescr = szDescr & "#" & TStr(lX + 1) & " which is not defined" & vbCrLf
                    Else
                        szDescr = szDescr & mszDataDir(lX) & vbCrLf
                    End If
                End If
                If Len(gvarExp(lIdx).szUnit) > 0 Then szDescr = szDescr & "- Recommended types: " & gvarExp(lIdx).szUnit & vbCrLf
            Case FWintern.VariableFlags.vfDirectory
                cmdVariablesBrowse.Visible = False
                cmdVariablesDir.Visible = True
                szDescr = "- Must be a directory without \ at the end" & vbCrLf
            Case FWintern.VariableFlags.vfString ' string
                cmdVariablesBrowse.Visible = False
                cmdVariablesDir.Visible = False
                szDescr = szDescr & " - Alphanumeric values allowed" & vbCrLf
                If (Flags And FWintern.VariableFlags.vfNonEmpty) <> 0 Then szDescr = szDescr & " - Must not be empty" & vbCrLf
                If (Flags And FWintern.VariableFlags.vfUpperCase) <> 0 Then szDescr = szDescr & "- Will be UPPER CASE" & vbCrLf
                If (Flags And FWintern.VariableFlags.vfLowerCase) <> 0 Then szDescr = szDescr & "- Will be lower case" & vbCrLf
                If (Flags And FWintern.VariableFlags.vfEnumeration) <> 0 Then
                    If (Flags And FWintern.VariableFlags.vfCaseSensitive) <> 0 Then
                        szDescr &= "- Must be a case sensitive"
                    Else
                        szDescr &= "- Must be a non-case sensitive"
                    End If

                    szDescr = szDescr & " item from the list:" & vbCrLf & "  " & gvarExp(lIdx).szUnit & vbCrLf
                End If
        End Select
        ' linked?
        If (Flags And (FWintern.VariableFlags.vfLinked * 15)) <> 0 Then
            lX = ((Flags And (FWintern.VariableFlags.vfLinked * 15)) \ FWintern.VariableFlags.vfLinked) - 1
            If lX <= UBound(gvarExp) And lX <> lIdx Then
                szDescr = szDescr & "- Linked with " & gvarExp(lX).szName & ":" & vbCrLf
                If lstVariables(CShort(lX)).Items.Count = 0 Then
                    szDescr = szDescr & "   (no values found)" & vbCrLf
                Else
                    For lY = 0 To lstVariables(CShort(lX)).Items.Count - 1
                        szDescr = szDescr & "   #" & TStr(lY + 1) & ": " & VB6.GetItemString(lstVariables(CShort(lX)), lY) & vbCrLf
                    Next
                End If
            End If
        End If
        txtVariablesFlags.Text = szDescr
        ' description
        If Len(gvarExp(lIdx).szDescription) = 0 Then
            txtVariablesDescr.Text = "Sets the " & gvarExp(lIdx).szName & vbCrLf & vbCrLf & "(Variable #" & TStr(lIdx) & ")"
        Else
            txtVariablesDescr.Text = gvarExp(lIdx).szDescription & vbCrLf & vbCrLf & "(Variable #" & TStr(lIdx) & ")"
        End If
        ShowVariablesIndex(lIdx)
        ' variable disabled?
        TextBoxState(txtVariables, Not ((Flags And FWintern.VariableFlags.vfDisabled) = FWintern.VariableFlags.vfDisabled))
        cmdVariablesAdd.Enabled = Not ((Flags And FWintern.VariableFlags.vfDisabled) = FWintern.VariableFlags.vfDisabled)

        If (Flags And FWintern.VariableFlags.vfDisabled) = FWintern.VariableFlags.vfDisabled Then
            txtVariablesFlags.Text = "Variable is disabled."
            cmdVariablesDefault.Enabled = False
        End If


        If Not mblnPreventControl Then If Not IsNothing(glOnSettingsChangeAddr) Then glOnSettingsChangeAddr(mlExpType)

    End Sub

    Private Sub cmdApply_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdApply.Click

        SaveSettings(2)

        ' Now in SaveSettings() (ML, 21/07/2020)
        '
        'SetSettings()
        'If gblnSettingsLoaded1 Then
        '    frmMain.ServeData(FWintern.ServeDataEnum.SendSettings, 0, 0, "")
        '    For i As Integer = 1 To glClientCount
        '        If gblnClientsSetting(i) Then
        '            frmMain.ServeData(FWintern.ServeDataEnum.ChangeSettings1, 0, 0, "", i)
        '        End If
        '    Next
        '    frmMain.ServeData(FWintern.ServeDataEnum.ItemlistColCountListStatus, 0, 0, "")
        'End If
    End Sub

    Private Sub cmdAudioSynthDis_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAudioSynthDis.Click
        Dim lX As Integer

        For lX = 0 To glPlayerChannels - 1
            mlAudioDACAddStream(lX) = 0
            VB6.SetItemString(cmbAudioSynthCh, lX, TStr(lX + 1))
        Next
        If Not gblnOutputStable Then Return
        RealTimeChange()
        Output.Send("/DAC/SetAddStream/*", "set", "silence")
        mblnPreventControl = True
        optAudioSynthDAC(0).Checked = True
        mblnPreventControl = False
        cmbAudioSynthCh.SelectedIndex = 0
    End Sub

    Private Sub cmdBrowseFitt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFittBrowse.Click
        Dim Index As Short = cmdFittBrowse.GetIndex(DirectCast(eventSender, Button))
        Dim szFile, szX As String

        If ChangeDir(txtSourceDir.Text) Then
            MsgBoxOnTop("Can't change to the directory." & vbCrLf & "Check the setting of source directory.", MsgBoxStyle.Critical)
            Return
        End If

        Dim dlgOpen As New OpenFileDialog
        With dlgOpen
            .InitialDirectory = txtSourceDir.Text
            .Title = "Open a fitting file in current directory"
            .FileName = txtFittFile(Index).Text
            .CheckFileExists = True
            .CheckPathExists = True
            .Filter = "RIB Fitting Files (*.fitt)|*.fitt|RIB2 Fitting Files (*.ampmap)|*.ampmap|All Files (*.*)|*.*"
        End With

        Select Case mStimOutput
            Case STIM.GENMODE.genElectricalRIB, STIM.GENMODE.genElectricalNIC
                dlgOpen.FilterIndex = 1
            Case STIM.GENMODE.genElectricalRIB2, STIM.GENMODE.genVocoder
                dlgOpen.FilterIndex = 2
        End Select
        If dlgOpen.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
        ' read and parse new file
        szFile = (New System.IO.FileInfo(dlgOpen.FileName)).Name
        szX = Mid(dlgOpen.FileName, 1, Len(dlgOpen.FileName) - Len(szFile) - 1)
        If szX <> txtSourceDir.Text Then
            MsgBoxOnTop("The directory changed." & vbCrLf & "All fittings file must be located in the source directory." & vbCrLf & "Please change the source directory first," & vbCrLf & "if you want to use fitting files in another directory", MsgBoxStyle.Critical)
            Return
        End If
        txtFittFile(Index).Text = szFile
        SetFittData(txtSourceDir.Text & "\" & szFile, CType(Index, Implant.EARTYPE))
        AdaptSignalToFitt(CType(Index, Implant.EARTYPE))
        UpdateSignalTab(CType(Index, Implant.EARTYPE))
        Return

    End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click

        SaveSettings(3)

        ' Now in SaveSettings() (without actually saving any settings in this case) (ML, 21/07/2020)
        '
        'tmrTracker.Enabled = False
        'tmrTracker.Stop()
        'gblnSettingsForm = False

        '' Reset Real-Time set settings
        '' nothing here yet...

        'Me.Close()
    End Sub


    Private Sub cmdConstCmd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdConstCmd.Click
        Dim Index As Short = cmdConstCmd.GetIndex(DirectCast(eventSender, Button))
        Dim szDir As String
        Dim lX As Integer

        If (gconstExp(Index).Flags And 15) = FWintern.VariableFlags.vfFileName Then
            If (gconstExp(Index).Flags And &H70S) = FWintern.VariableFlags.vfAbsolute Then
                ' get absolute file name
                lX = InStrRev(txtConstValue(Index).Text, "\")
                If lX > 0 Then
                    szDir = Mid(txtConstValue(Index).Text, 1, lX)
                    ChangeDir(szDir)
                Else
                    szDir = gszCurrentDir
                End If
            Else
                ' file name relative to data dir
                lX = CShort((gconstExp(Index).Flags \ &H10) And 7) - 1
                If lX > GetUbound(mszDataDir) Then
                    MsgBoxOnTop("Data directory #" & TStr(lX + 1) & " is not defined.")
                    Return
                End If
                szDir = mszDataDir(lX)
                ChangeDir(szDir)
            End If

            Dim dlgOpen As New OpenFileDialog
            With dlgOpen
                .InitialDirectory = szDir
                .FileName = ""
                .Title = "Browse for a file..."
                .CheckFileExists = True
                .CheckPathExists = True
                .SupportMultiDottedExtensions = True

                If Len(gconstExp(Index).szUnit) > 0 Then
                    dlgOpen.Filter = "Specific Files (" & gconstExp(Index).szUnit & ")|" & gconstExp(Index).szUnit & "|All Files (*.*)|*.*"
                Else
                    dlgOpen.Filter = "All Files (*.*)|*.*"
                End If
                dlgOpen.FilterIndex = 1
                If dlgOpen.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
                If (gconstExp(Index).Flags And &H70S) = FWintern.VariableFlags.vfAbsolute Then
                    txtConstValue(Index).Text = dlgOpen.FileName
                    'lblConstUnit(Index).Text = "...\" & (New System.IO.FileInfo(dlgOpen.FileName)).Name
                Else
                    If Len(szDir) > Len(dlgOpen.FileName) Then lX = 1 Else lX = 0
                    If LCase(Mid(dlgOpen.FileName, 1, Len(szDir))) <> LCase(szDir) Then lX = 1
                    If lX > 0 Then
                        MsgBoxOnTop("You are not supposed to go up in the directory tree here." & vbCrLf & "If you want to do that, change the data directory #" & TStr((gconstExp(Index).Flags \ &H10) And 7))
                        Return
                    End If
                    txtConstValue(Index).Text = Mid(dlgOpen.FileName, Len(szDir) + 2)
                    'lblConstUnit(Index).Text = "...\" & (New System.IO.FileInfo(dlgOpen.FileName)).Name
                End If
            End With
        End If

    End Sub

    Private Sub cmdDataDir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDataDir.Click

        'dlgBrowse.RootFolder = Environment.SpecialFolder.Desktop
        Dim dlgBrowse As New FolderBrowserDialog
        With dlgBrowse
            .SelectedPath = txtDataDir.Text
            .Description = "Pick the Archive Directory with existing data"
            .ShowNewFolderButton = False

            If .ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
            txtDataDir.Text = .SelectedPath
        End With
    End Sub

    Private Sub cmdDestinationDir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDestinationDir.Click
        Dim szDir As String
        If txtDestinationDir.Text = "%temp%" Or txtDestinationDir.Text = "" Or chkTempDir.CheckState = CheckState.Checked Then
            szDir = My.Application.Info.DirectoryPath
        Else
            szDir = txtDestinationDir.Text
        End If

        Dim dlgBrowse As New FolderBrowserDialog
        With dlgBrowse
            .SelectedPath = szDir
            .Description = "Pick the Destination Directory"
            .ShowNewFolderButton = True

            If .ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
            txtDestinationDir.Text = .SelectedPath
        End With
    End Sub



    Private Sub cmdDestinationFromSetting_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDestinationFromSetting.Click
        If txtDestinationDir.Text.Length > 0 Then My.Computer.Clipboard.SetText((txtDestinationDir.Text))
        txtDestinationDir.Text = gszCurrentDir
        chkTempDir.CheckState = CheckState.Unchecked
    End Sub

    Private Sub cmdElAddL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdElAddL.Click
        Dim lX As Integer

        lX = GetUbound(mfreqParL) + 1
        ReDim Preserve mfreqParL(lX)
        mfreqParL(lX) = New clsFREQUENCY
        With mfreqParL(lX)
            If gfreqDef(0).lPhDur > 0 Then
                .lPhDur = gfreqDef(0).lPhDur
                .lRange = gfreqDef(0).lRange
                .sAmp = gfreqDef(0).sAmp
                .sBandwidth = gfreqDef(0).sBandwidth
                .sCenterFreq = gfreqDef(0).sCenterFreq
                .sMCL = gfreqDef(0).sMCL
                .sSPLOffset = gfreqDef(0).sSPLOffset
                .sTHR = gfreqDef(0).sTHR
            Else
                If Val((txtSamplingRate.Text)) <> 0 Then .lPhDur = CInt(1000000 / Val((txtSamplingRate.Text)))
                .lRange = 0
                .sAmp = -10
                .sBandwidth = 0
                .sCenterFreq = 0
                .sMCL = 0
                .sSPLOffset = 0
                .sTHR = -100
            End If
        End With
        mlElectrodeL = lX + 1
        UpdateSignalTab(0)

    End Sub

    Private Sub cmdElAddR_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdElAddR.Click
        Dim lX As Integer

        lX = GetUbound(mfreqParR) + 1
        ReDim Preserve mfreqParR(lX)
        mfreqParR(lX) = New clsFREQUENCY
        With mfreqParR(lX)
            If gfreqDef(1).lPhDur > 0 Then
                .lPhDur = gfreqDef(1).lPhDur
                .lRange = gfreqDef(1).lRange
                .sAmp = gfreqDef(1).sAmp
                .sBandwidth = gfreqDef(1).sBandwidth
                .sCenterFreq = gfreqDef(1).sCenterFreq
                .sMCL = gfreqDef(1).sMCL
                .sSPLOffset = gfreqDef(1).sSPLOffset
                .sTHR = gfreqDef(1).sTHR
            Else
                If Val((txtSamplingRate.Text)) <> 0 Then .lPhDur = CInt(1000000 / Val((txtSamplingRate.Text)))
                .lRange = 0
                .sAmp = -10
                .sBandwidth = 0
                .sCenterFreq = 0
                .sMCL = 0
                .sSPLOffset = 0
                .sTHR = -100
            End If
        End With
        mlElectrodeR = lX + 1
        UpdateSignalTab(Implant.EARTYPE.RIGHT)

    End Sub

    Private Sub cmdElDelL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdElDelL.Click
        Dim lX As Integer

        lX = GetUbound(mfreqParL)
        If lX = 0 Then
            Erase mfreqParL
        Else
            ReDim Preserve mfreqParL(lX - 1)
        End If
        UpdateSignalTab(0)

    End Sub

    Private Sub cmdElDelR_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdElDelR.Click
        Dim lX As Integer

        lX = GetUbound(mfreqParR)
        If lX = 0 Then
            Erase mfreqParR
        Else
            ReDim Preserve mfreqParR(lX - 1)
        End If
        UpdateSignalTab(Implant.EARTYPE.RIGHT)

    End Sub

    Private Sub cmdExpBlankScreen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExpBlankScreen.Click
        frmExp.ShowBlankScreen(CBool(chkAlwaysOnTop.CheckState))
        'Me.TopMost = True
    End Sub

    Private Sub cmdExpEnableResponse_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExpEnableResponse.Click
        frmExp.EnableResponse(False)
    End Sub

    Private Sub cmdExpDisableResponse_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExpDisableResponse.Click
        frmExp.DisableResponse()
    End Sub

    Private Sub cmdExpEndScreen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExpEndScreen.Click
        frmExp.ShowEndScreen()
    End Sub

    Private Sub cmdExpGetResponse_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExpGetResponse.Click
        Dim lX As Integer
        If frmExp.GetResponse(lX) Then
            txtExpResponse.Text = TStr(lX)
        Else
            txtExpResponse.Text = "---"
        End If
    End Sub

    Private Sub cmdExpGetSize_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExpGetSize.Click
        Dim lT, lH, lW, lL As Integer
        frmExp.GetSize(lL, lW, lT, lH)
        txtExpHeight.Text = TStr(lH)
        txtExpWidth.Text = TStr(lW)
        txtExpTop.Text = TStr(lT)
        txtExpLeft.Text = TStr(lL)
    End Sub

    Private Sub cmdExpGetValue_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExpGetValue.Click
        txtExpValue.Text = TStr(frmExp.GetValue)
    End Sub

    Private Sub cmdExpHide_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExpHide.Click
        cmdExpResize.Text = "Arrange"
        tmrExpResize.Enabled = False
        cmdExpBlankScreen.Enabled = False
        cmdExpStartScreen.Enabled = False
        cmdExpStimScreen.Enabled = False
        cmdExpNextScreen.Enabled = False
        cmdExpEndScreen.Enabled = False
        cmdExpHide.Enabled = False
        cmdExpResize.Text = "Arrange"
        cmdExpResize.Enabled = False
        cmdExpGetSize.Enabled = False
        cmdExpSetSize.Enabled = False
        cmdExpEnableResponse.Enabled = False
        cmdExpDisableResponse.Enabled = False
        cmdExpGetResponse.Enabled = False
        cmdExpGetValue.Enabled = False
        tmrExpResize.Enabled = False
        frmExp.UnloadMe()
    End Sub

    Private Sub cmdExpNextScreen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExpNextScreen.Click
        Dim szX As String
        Dim blnTopMost As Boolean = frmExp.TopMost
        Me.TopMost = False
        If blnTopMost Then frmExp.TopMost = False
        szX = InputBox("Text der Feedback angeben:", "Stimulus Screen", "Richtig")
        'Me.TopMost = True
        frmExp.TopMost = blnTopMost
        If szX = "" Then Exit Sub
        frmExp.ShowNextScreen(szX, System.Drawing.ColorTranslator.FromOle(CInt(Rnd() * &H1000000)))
    End Sub

    Private Sub cmdExpResize_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExpResize.Click
        If InStr(1, cmdExpResize.Text, "stop", CompareMethod.Text) <> 0 Then
            frmExp.AllowResizing(False)
            cmdExpResize.Text = "Arrange"
            tmrExpResize.Enabled = False
        Else
            frmExp.AllowResizing(True)
            cmdExpResize.Text = "Stop"
            tmrExpResize.Enabled = True
        End If
    End Sub

    Private Sub cmdExpSetSize_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExpSetSize.Click
        Dim lT, lH, lW, lL As Integer
        lH = CInt(Val((txtExpHeight.Text)))
        lW = CInt(Val((txtExpWidth.Text)))
        lT = CInt(Val((txtExpTop.Text)))
        lL = CInt(Val((txtExpLeft.Text)))
        frmExp.SetSize(lL, lW, lT, lH)
    End Sub

    Private Sub cmdExpShow_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExpShow.Click
        Dim rectX As RECT
        With rectX
            .Height = CInt(Val((txtExpHeight.Text)))
            .Width = CInt(Val((txtExpWidth.Text)))
            .Top = CInt(Val((txtExpTop.Text)))
            .Left = CInt(Val((txtExpLeft.Text)))
        End With

        Dim lFlags As Integer = 0
        For lBit As Integer = 0 To lstExpFlags.Items.Count - 1
            If lstExpFlags.GetItemChecked(lBit) Then lFlags = lFlags Or CInt(2 ^ lBit)
        Next

        Dim Flags As frmExp.EXPFLAGS = CType(lFlags, frmExp.EXPFLAGS)
        frmExp.Dispose() 'reset form
        'gOExpMode = CInt(OexpMode.Value)
        ExpSuite.Events.OnExpShow(cmbExpType.SelectedIndex, rectX, Flags)

        If cmbHUI.SelectedIndex > 0 Then
            frmExp.SetHUIDevice(cmbHUI.SelectedIndex)
        End If
        frmExp.ShowBlankScreen(False)

        cmdExpBlankScreen.Enabled = True
        cmdExpStartScreen.Enabled = True
        cmdExpStimScreen.Enabled = True
        cmdExpNextScreen.Enabled = True
        cmdExpEndScreen.Enabled = True
        cmdExpHide.Enabled = True
        cmdExpResize.Text = "Arrange"
        cmdExpResize.Enabled = True
        cmdExpGetSize.Enabled = True
        cmdExpSetSize.Enabled = True
        cmdExpEnableResponse.Enabled = True
        cmdExpDisableResponse.Enabled = True
        cmdExpGetResponse.Enabled = True
        cmdExpGetValue.Enabled = True
        tmrExpResize.Enabled = True

        tmrExpResize.Enabled = False

        mlExpTypeShowed = cmbExpType.SelectedIndex

    End Sub

    Private Sub cmdExpStartScreen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExpStartScreen.Click
        frmExp.ShowStartScreen()
    End Sub

    Private Sub cmdExpStimScreen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExpStimScreen.Click
        Dim szX As String
        Dim blnTopMost As Boolean = frmExp.TopMost
        Me.TopMost = False
        If blnTopMost Then frmExp.TopMost = False
        szX = InputBox("Input the interval index (256=No highlight, 0=Interval #1, 1=Interval #2, 2=Interval #3):", "Stimulus Screen", CStr(256))
        'Me.TopMost = True
        frmExp.TopMost = blnTopMost
        If szX = "" Then Exit Sub
        frmExp.SetRequestText(gszExpRequestText(cmbExpType.SelectedIndex), SystemColors.ControlText)
        frmExp.ShowStimScreen(CInt(Val(szX)))         'Val not necessary, only 0,1,2,256 sensible
    End Sub

    Private Sub cmdFittClear_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFittClear.Click
        Dim Index As Short = cmdFittClear.GetIndex(DirectCast(eventSender, Button))
        If Len(txtFittFile(Index).Text) = 0 Then Return

        If MsgBoxOnTop("Are you sure to release the fitting file?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then Exit Sub
        txtFittFile(Index).Text = ""
        Select Case Index
            Case 0 ' left
                F4FL.ClearParameters()
                If mStimOutput = STIM.GENMODE.genElectricalRIB Or mStimOutput = STIM.GENMODE.genElectricalRIB2 Or mStimOutput = STIM.GENMODE.genVocoder Then
                    Erase mfreqParL
                    mlElectrodeL = -1
                End If
            Case 1 ' right
                F4FR.ClearParameters()
                If mStimOutput = STIM.GENMODE.genElectricalRIB Or mStimOutput = STIM.GENMODE.genElectricalRIB2 Or mStimOutput = STIM.GENMODE.genVocoder Then
                    Erase mfreqParR
                    mlElectrodeR = -1
                End If
        End Select

        SetFittData("", CType(Index, Implant.EARTYPE))
        UpdateSignalTab(CType(Index, Implant.EARTYPE))

    End Sub

    Private Sub cmdFittReload_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFittReload.Click
        Dim Index As Short = cmdFittReload.GetIndex(DirectCast(eventSender, Button))
        Dim szFile As String

        If ChangeDir(txtSourceDir.Text) Then
            MsgBoxOnTop("Can't set the Fitting Files directory:" & vbCrLf & txtSourceDir.Text & vbCrLf & vbCrLf & "Maybe the folder or the Fitting Files are not existing.", MsgBoxStyle.Critical)
            Return
        End If

        ' read and parse new file
        szFile = txtFittFile(Index).Text
        If Len(szFile) = 0 Then Return
        ' display new parameters
        SetFittData(txtSourceDir.Text & IO.Path.DirectorySeparatorChar & szFile, CType(Index, Implant.EARTYPE))
        AdaptSignalToFitt(CType(Index, Implant.EARTYPE))
        UpdateSignalTab(CType(Index, Implant.EARTYPE))

    End Sub

    Private Sub cmdFittResetPhDur_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFittResetPhDur.Click
        Dim Index As Short = cmdFittResetPhDur.GetIndex(DirectCast(eventSender, Button))
        Dim lX As Integer

        If Index = 0 Then
            For lX = 0 To GetUbound(mfreqParL)
                mfreqParL(lX).lPhDur = CInt(F4FL.Channel(lX).lPhDur * F4FL.TimeBase)
            Next
            UpdateSignalTab(Implant.EARTYPE.LEFT)
        Else
            For lX = 0 To GetUbound(mfreqParR)
                mfreqParR(lX).lPhDur = CInt(F4FR.Channel(lX).lPhDur * F4FR.TimeBase)
            Next
            UpdateSignalTab(Implant.EARTYPE.RIGHT)
        End If

    End Sub

    Public Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click

        SaveSettings(1)

        ' Code below is OUTSOURCED to SaveSettings():
        ' 
        'If SetSettings() Then
        '    Return
        'End If
        'If gblnSettingsLoaded1 Then
        '    frmMain.ServeData(FWintern.ServeDataEnum.SendSettings, 0, 0, "")
        '    For i As Integer = 1 To glClientCount
        '        If gblnClientsSetting(i) Then
        '            frmMain.ServeData(FWintern.ServeDataEnum.ChangeSettings1, 0, 0, "", i)
        '        End If
        '    Next
        '    frmMain.ServeData(FWintern.ServeDataEnum.ItemlistColCountListStatus, 0, 0, "")
        'End If
        'tmrTracker.Enabled = False
        'tmrTracker.Stop()
        'gblnSettingsForm = False
        'Me.Close()
    End Sub

    Private Sub cmdSignalImport_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSignalImport.Click
        Dim lX, lY As Integer
        Dim szErr As String
        Dim szArr(0, 0) As String
        Dim blnErr As Boolean
        Dim csvX As New CSVParser
        Dim lColCh, lColEl, lColAmp As Integer
        Dim szTable As String

        Select Case mStimOutput
            Case GENMODE.genElectricalRIB, GENMODE.genElectricalNIC, GENMODE.genElectricalRIB2, GENMODE.genVocoder  '  electric
                If F4FL.ImpType = Implant.IMPLANTTYPE.imptInvalid And F4FR.ImpType = Implant.IMPLANTTYPE.imptInvalid Then
                    MsgBoxOnTop("Load fitting files first...")
                    Exit Sub
                End If
                ' read signal file as csv
                Dim dlgOpen As New OpenFileDialog
                If Len(mszSignalImportDir) = 0 Then dlgOpen.InitialDirectory = gszCurrentDir _
                        Else dlgOpen.InitialDirectory = mszSignalImportDir
                dlgOpen.Title = "Import a signal/ampmap file with amplitude values..."
                dlgOpen.FileName = ""
                dlgOpen.CheckFileExists = True
                dlgOpen.CheckPathExists = True
                dlgOpen.Filter = "Signal/Ampmap Files (*.signal;*.ampmap)|*.signal;*.ampmap|Signal Files (*.signal)|*.signal|Ampmap Files (*.ampmap)|*.ampmap|All Files (*.*)|*.*"
                dlgOpen.FilterIndex = 1
                If dlgOpen.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
                mszSignalImportDir = IO.Path.GetDirectoryName(dlgOpen.FileName)
                szErr = csvX.ReadArr(dlgOpen.FileName, szArr)
                If Len(szErr) <> 0 Then MsgBoxOnTop("Error reading signal file:" & vbCrLf & szErr) : Return
                If IsNothing(szArr) Then MsgBoxOnTop("File is empty.") : Return

                If Strings.Right(dlgOpen.FileName, Len(".ampmap")) = ".ampmap" Then 'RIB2 fitting file
                    ' read rows
                    blnErr = False
                    Dim ear As Integer = -1
                    Debug.Print(" +++ IMPORT +++ ")

                    'szErr = "Used table: " & szTable & vbCrLf
                    For lX = 0 To UBound(szArr)
                        'If szArr(lX, 0) = szTable Then ' use only first table
                        'Select Case Val(szArr(lX, lColCh))
                        '    Case 0 ' left ear
                        'If F4FL.ImpType = Implant.IMPLANTTYPE.imptInvalid Then
                        '    blnErr = True
                        '    szErr = szErr & "Left: fitting file not set." & vbCrLf
                        'Else
                        If Strings.Left(szArr(lX, 0), Len("# Implanted ear : LEFT")) = "# Implanted ear : LEFT" Then
                            ear = 0
                        ElseIf Strings.Left(szArr(lX, 0), Len("# Implanted ear : RIGHT")) = "# Implanted ear : RIGHT" Then
                            ear = 1
                        End If

                        If Strings.Left(szArr(lX, 0), Len("Electrode ")) = "Electrode " Then
                            If InStr(szArr(lX, 0), " # CL ") > 0 Then

                                Dim El As Integer = CInt(Val(Replace(Strings.Mid(szArr(lX, 0), Len("Electrode ") + 1, 2), " ", "")))

                                Dim CL As Integer = CInt(Val(Strings.Right(szArr(lX, 0), Len(szArr(lX, 0)) - InStr(szArr(lX, 0), " # CL ") - Len(" # CL ") + 1)))
                                Debug.Print("Ear" & ear & "-EL" & El & "-CL" & CL & "-")

                                If ear = 0 Then
                                    With mfreqParL(El - 1)
                                        .sAmp = CL
                                        If .sAmp > .sMCL Then
                                            szErr = szErr & "Left, #" & TStr(El) & ": Amplitude (=" & TStr(.sAmp) & ") reduced to MCL (=" & TStr(.sMCL) & ")" & vbCrLf
                                            blnErr = True
                                            .sAmp = .sMCL
                                        ElseIf .sAmp < .sTHR Then
                                            szErr = szErr & "Left, #" & TStr(El) & ": Amplitude (=" & TStr(.sAmp) & ") increased to THR (=" & TStr(.sTHR) & ")" & vbCrLf
                                            blnErr = True
                                            .sAmp = .sTHR
                                        Else
                                            szErr = szErr & "Left, #" & TStr(El) & ": Amplitude =" & TStr(.sAmp) & vbCrLf
                                        End If
                                    End With
                                ElseIf ear = 1 Then
                                    With mfreqParR(El - 1)
                                        .sAmp = CL
                                        If .sAmp > .sMCL Then
                                            szErr = szErr & "Right, #" & TStr(El) & ": Amplitude (=" & TStr(.sAmp) & ") reduced to MCL (=" & TStr(.sMCL) & ")" & vbCrLf
                                            blnErr = True
                                            .sAmp = .sMCL
                                        ElseIf .sAmp < .sTHR Then
                                            szErr = szErr & "Right, #" & TStr(El) & ": Amplitude (=" & TStr(.sAmp) & ") increased to THR (=" & TStr(.sTHR) & ")" & vbCrLf
                                            blnErr = True
                                            .sAmp = .sTHR
                                        Else
                                            szErr = szErr & "Right, #" & TStr(El) & ": Amplitude =" & TStr(.sAmp) & vbCrLf
                                        End If
                                    End With
                                End If
                            End If

                        End If
                    Next  ' for each row

                    If ear = -1 Then
                        blnErr = True
                        szErr = szErr & "Left or right ear not specified in fitting file." & vbCrLf
                    End If

                Else 'signal file (default)
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
                    If Len(szErr) > 0 Then MsgBoxOnTop(szErr) : Return

                    ' read rows
                    blnErr = False
                    szErr = "Used table: " & szTable & vbCrLf
                    For lX = 1 To UBound(szArr, 1)
                        If szArr(lX, 0) = szTable Then ' use only first table
                            Select Case Val(szArr(lX, lColCh))
                                Case 0 ' left ear
                                    If F4FL.ImpType = Implant.IMPLANTTYPE.imptInvalid Then
                                        blnErr = True
                                        szErr = szErr & "Left: fitting file not set." & vbCrLf
                                    Else
                                        lY = CInt(Val(szArr(lX, lColEl)))
                                        If (lY > 0) And (lY - 1 <= GetUbound(mfreqParL)) Then
                                            With mfreqParL(lY - 1)
                                                .sAmp = Val(szArr(lX, lColAmp))
                                                If .sAmp > .sMCL Then
                                                    szErr = szErr & "Left, #" & TStr(lY) & ": Amplitude (=" & TStr(.sAmp) & ") reduced to MCL (=" & TStr(.sMCL) & ")" & vbCrLf
                                                    blnErr = True
                                                    .sAmp = .sMCL
                                                ElseIf .sAmp < .sTHR Then
                                                    szErr = szErr & "Left, #" & TStr(lY) & ": Amplitude (=" & TStr(.sAmp) & ") increased to THR (=" & TStr(.sTHR) & ")" & vbCrLf
                                                    blnErr = True
                                                    .sAmp = .sTHR
                                                Else
                                                    szErr = szErr & "Left, #" & TStr(lY) & ": Amplitude =" & TStr(.sAmp) & vbCrLf
                                                End If
                                            End With
                                        Else
                                            szErr = szErr & "Left, #" & TStr(lY) & ": electrode not valid" & vbCrLf
                                            blnErr = True
                                        End If ' electrode valid?
                                    End If
                                Case 1 ' right ear
                                    If F4FR.ImpType = Implant.IMPLANTTYPE.imptInvalid Then
                                        blnErr = True
                                        szErr = szErr & "Right: fitting file not set." & vbCrLf
                                    Else
                                        lY = CInt(Val(szArr(lX, lColEl)))
                                        If (lY > 0) And (lY - 1 <= GetUbound(mfreqParR)) Then
                                            With mfreqParR(lY - 1)
                                                .sAmp = Val(szArr(lX, lColAmp))
                                                If .sAmp > .sMCL Then
                                                    szErr = szErr & "Right, #" & TStr(lY) & ": Amplitude (=" & TStr(.sAmp) & ") reduced to MCL (=" & TStr(.sMCL) & ")" & vbCrLf
                                                    blnErr = True
                                                    .sAmp = .sMCL
                                                ElseIf .sAmp < .sTHR Then
                                                    szErr = szErr & "Right, #" & TStr(lY) & ": Amplitude (=" & TStr(.sAmp) & ") increased to THR (=" & TStr(.sTHR) & ")" & vbCrLf
                                                    blnErr = True
                                                    .sAmp = .sTHR
                                                Else
                                                    szErr = szErr & "Right, #" & TStr(lY) & ": Amplitude =" & TStr(.sAmp) & vbCrLf
                                                End If
                                            End With
                                        Else
                                            szErr = szErr & "Right, #" & TStr(lY) & ": electrode not valid" & vbCrLf
                                            blnErr = True
                                        End If ' electrode valid?
                                    End If
                            End Select ' select channel
                        End If ' only first table
                    Next  ' for each row

                End If

                If blnErr Then
                    MsgBoxOnTop(szErr, MsgBoxStyle.Critical, "Error importing amplitudes")
                Else
                    If szErr = "" Then szErr = "No amplitudes imported!"
                    MsgBoxOnTop(szErr, MsgBoxStyle.Information, "Status report")
                End If

            Case GENMODE.genAcoustical, GENMODE.genAcousticalUnity ' acoustic
                MsgBoxOnTop("not implemented yet.")

        End Select

        UpdateSignalTab(Implant.EARTYPE.LEFT)
        UpdateSignalTab(Implant.EARTYPE.RIGHT)

    End Sub

    Private Sub cmdTrackerSetOffset_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdTrackerSetOffset.Click
        Dim Index As Short = cmdTrackerSetOffset.GetIndex(DirectCast(eventSender, Button))
        Dim inpX As New frmInputBox

        inpX.Add("X", FWintern.VariableFlags.vfNumeric, TStr(mtsTrackerOffset(Index).sngX), "cm")
        inpX.Add("Y", FWintern.VariableFlags.vfNumeric, TStr(mtsTrackerOffset(Index).sngY), "cm")
        inpX.Add("Z", FWintern.VariableFlags.vfNumeric, TStr(mtsTrackerOffset(Index).sngZ), "cm")
        inpX.Add("Azimuth", FWintern.VariableFlags.vfNumeric, TStr(mtsTrackerOffset(Index).sngA), "°")
        inpX.Add("Elevation", FWintern.VariableFlags.vfNumeric, TStr(mtsTrackerOffset(Index).sngE), "°")
        inpX.Add("Roll", FWintern.VariableFlags.vfNumeric, TStr(mtsTrackerOffset(Index).sngR), "°")
        inpX.SetLeft = Me.Left + 100
        inpX.SetTop = Me.Top + 200
        Me.TopMost = False
        If Not inpX.ShowForm("Set the offset values of sensor " & TStr(Index) & " to:") Then
            inpX.Dispose() : Return
        End If
        'Me.TopMost = True
        mtsTrackerOffset(Index).sngX = Val(inpX.GetValue(0))
        mtsTrackerOffset(Index).sngY = Val(inpX.GetValue(1))
        mtsTrackerOffset(Index).sngZ = Val(inpX.GetValue(2))
        mtsTrackerOffset(Index).sngA = Val(inpX.GetValue(3))
        mtsTrackerOffset(Index).sngE = Val(inpX.GetValue(4))
        mtsTrackerOffset(Index).sngR = Val(inpX.GetValue(5))
        inpX.Dispose()

        If Not gblnOutputStable Then Return

        RealTimeChange()
        With mtsTrackerOffset(Index)
            Tracker.SetOffset(CInt(Index), .sngX, .sngY, .sngZ, .sngA, .sngE, .sngR)
        End With

    End Sub

    Private Sub cmdTrackerSetValues_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdTrackerSetValues.Click
        Dim Index As Short = cmdTrackerSetValues.GetIndex(DirectCast(eventSender, Button))
        Dim inpX As New frmInputBox

        inpX.Add("X", FWintern.VariableFlags.vfNumeric, TStr(mtsTrackerValues(Index).sngX), "cm")
        inpX.Add("Y", FWintern.VariableFlags.vfNumeric, TStr(mtsTrackerValues(Index).sngY), "cm")
        inpX.Add("Z", FWintern.VariableFlags.vfNumeric, TStr(mtsTrackerValues(Index).sngZ), "cm")
        inpX.Add("Azimuth", FWintern.VariableFlags.vfNumeric, TStr(mtsTrackerValues(Index).sngA), "°")
        inpX.Add("Elevation", FWintern.VariableFlags.vfNumeric, TStr(mtsTrackerValues(Index).sngE), "°")
        inpX.Add("Roll", FWintern.VariableFlags.vfNumeric, TStr(mtsTrackerValues(Index).sngR), "°")
        inpX.SetLeft = Me.Left + 100
        inpX.SetTop = Me.Top + 200
        Me.TopMost = False
        If Not inpX.ShowForm("Set the current values of sensor " & TStr(Index) & " to:") Then
            'UPGRADE_NOTE: Object inpX may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            inpX = Nothing : Exit Sub
        End If
        'Me.TopMost = True
        mtsTrackerValues(Index).sngX = Val(inpX.GetValue(0))
        mtsTrackerValues(Index).sngY = Val(inpX.GetValue(1))
        mtsTrackerValues(Index).sngZ = Val(inpX.GetValue(2))
        mtsTrackerValues(Index).sngA = Val(inpX.GetValue(3))
        mtsTrackerValues(Index).sngE = Val(inpX.GetValue(4))
        mtsTrackerValues(Index).sngR = Val(inpX.GetValue(5))
        inpX = Nothing

        If Not gblnOutputStable Then Exit Sub

        RealTimeChange()
        With mtsTrackerValues(Index)
            Tracker.SetCurrentValues(CInt(Index), .sngX, .sngY, .sngZ, .sngA, .sngE, .sngR)
        End With

    End Sub


    Private Sub cmdVariablesAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVariablesAdd.Click
        Dim lX As Integer
        Dim varX As String
        Dim szErr As String
        ' get data
        lX = cmbVariables.SelectedIndex
        varX = txtVariables.Text
        szErr = CheckVariable(varX, gvarExp(lX), mfreqParL, mfreqParR)
        If Len(szErr) <> 0 Then
            MsgBoxOnTop(szErr, MsgBoxStyle.Critical, "Invalid Input")
            Return
        End If
        ' save input
        lstVariables(CShort(lX)).Items.Add(varX)
        txtVariables.SelectionStart = 0
        txtVariables.SelectionLength = Len(txtVariables.Text)
        txtVariables.Focus()

        ShowVariablesIndex(lX)

        If Not IsNothing(glOnSettingsChangeAddr) Then glOnSettingsChangeAddr(mlExpType)

    End Sub

    Private Sub cmdVariablesBrowse_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVariablesBrowse.Click
        Dim szDir As String = ""
        'Dim szX As String

        Dim dlgOpen As New OpenFileDialog
        If ((gvarExp(cmbVariables.SelectedIndex).Flags And &H70S) = FWintern.VariableFlags.vfAbsolute) Then
            dlgOpen.Title = "Browse for a file name..."
            Dim lX As Integer = InStrRev(txtVariables.Text, "\")
            If lX > 0 Then
                dlgOpen.InitialDirectory = Mid(txtVariables.Text, 1, lX)
                ChangeDir(Mid(txtVariables.Text, 1, lX))
            Else
                szDir = gszCurrentDir
            End If
        Else
            Dim lX As Integer = ((gvarExp(cmbVariables.SelectedIndex).Flags \ &H10) And 7) - 1
            If lX > GetUbound(mszDataDir) Then MsgBoxOnTop("Data directory #" & TStr(lX + 1) & " is not defined.") : Return

            'remove possible "\" at ending
            If mszDataDir(lX)(mszDataDir(lX).Length - 1) = "\" Then
                szDir = Strings.Left(mszDataDir(lX), Len(mszDataDir(lX)) - Len("\"))
            Else
                szDir = mszDataDir(lX)
            End If

            dlgOpen.Title = "Browse for a file name in this directory only..."
        End If
        dlgOpen.InitialDirectory = szDir
        dlgOpen.FileName = ""
        dlgOpen.CheckFileExists = True
        dlgOpen.CheckPathExists = True
        dlgOpen.Multiselect = True
        Dim szExt As String = gvarExp(cmbVariables.SelectedIndex).szUnit
        If Len(szExt) > 0 Then
            Dim szExtAll() As String
            If InStr(szExt, "|") > 0 Then 'multiple options
                szExtAll = Split(szExt, "|")
                Dim szFilter As String = Nothing
                For lX As Integer = 0 To UBound(szExtAll)
                    If lX > 0 Then szFilter &= "|"
                    szFilter = szFilter & Strings.Replace(Strings.Replace(Strings.Replace(Strings.Replace(szExtAll(lX), "*.wav", "Audio"), "*.mp4", "mp4-Video"), "*.avi", "avi-Video"), "*.wmv", "wmv-Video") & "|" & szExtAll(lX)
                Next
                dlgOpen.Filter = szFilter & "|All Files (*.*)|*.*"
            Else
                dlgOpen.Filter = "Specific Files (" & szExt & ")|" & szExt & "|All Files (*.*)|*.*"
            End If

        Else
            dlgOpen.Filter = "All Files (*.*)|*.*"
        End If
        dlgOpen.FilterIndex = 1
        If dlgOpen.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return

        Dim szArr() As String = dlgOpen.FileNames
        If szArr.Length = 1 Then
            ' single selection
            Dim szX As String = dlgOpen.FileName
            If ((gvarExp(cmbVariables.SelectedIndex).Flags And &H70S) = FWintern.VariableFlags.vfAbsolute) Then
                lstVariables(CShort(cmbVariables.SelectedIndex)).Items.Add(szX)
            Else
                Dim lX As Integer
                If Len(szDir) > Len(szX) Then lX = 1 Else lX = 0
                If LCase(Mid(szX, 1, Len(szDir))) <> LCase(szDir) Then lX = 1
                If lX > 0 Then MsgBoxOnTop("You are not supposed to go up in the directory tree here." & vbCrLf & "If you want to do that, change the data directory #" & TStr((gvarExp(cmbVariables.SelectedIndex).Flags \ &H10) And 7)) : Return
                lstVariables(CShort(cmbVariables.SelectedIndex)).Items.Add(Mid(szX, Len(szDir) + 2))
            End If
        Else
            ' multiple selection
            If ((gvarExp(cmbVariables.SelectedIndex).Flags And &H70S) = FWintern.VariableFlags.vfAbsolute) Then
                ' absolute path
                For lIdx As Integer = 0 To szArr.Length - 1
                    lstVariables(CShort(cmbVariables.SelectedIndex)).Items.Add(szArr(lIdx))
                Next
            Else
                ' relative path
                If (New System.IO.FileInfo(szArr(0)).DirectoryName) <> szDir Then MsgBoxOnTop("You are not supposed to go up in the directory tree here." & vbCrLf & "If you want to do that, change the data directory #" & TStr((gvarExp(cmbVariables.SelectedIndex).Flags \ &H10) And 7)) : Return
                For lIdx As Integer = 0 To szArr.Length - 1
                    lstVariables(CShort(cmbVariables.SelectedIndex)).Items.Add(New System.IO.FileInfo(szArr(lIdx)).Name)
                Next
            End If
        End If

    End Sub

    Private Sub cmdVariablesClear_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVariablesClear.Click
        lstVariables(CShort(cmbVariables.SelectedIndex)).Items.Clear()

        ShowVariablesIndex(cmbVariables.SelectedIndex)
        lstVariables(CShort(cmbVariables.SelectedIndex)).Focus()

    End Sub

    Private Sub cmdVariablesDefault_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVariablesDefault.Click
        'If cmdVariablesAdd.Enabled Then
        FillVariableWithDefault(cmbVariables.SelectedIndex)
        ShowVariablesIndex(cmbVariables.SelectedIndex)
        'End If
    End Sub





    Private Sub cmdVariablesDir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVariablesDir.Click
        'dlgBrowse.RootFolder = Environment.SpecialFolder.Desktop
        Dim dlgBrowse As New FolderBrowserDialog With { _
            .SelectedPath = txtVariables.Text, _
            .Description = "Pick a Directory", _
            .ShowNewFolderButton = True _
        }
        If dlgBrowse.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
        lstVariables(CShort(cmbVariables.SelectedIndex)).Items.Add(dlgBrowse.SelectedPath)
    End Sub

    Private Sub cmdVariablesDown_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVariablesDown.Click
        Dim lX As Integer
        Dim varX As String

        Dim shIdx As Short = CShort(cmbVariables.SelectedIndex)
        lX = lstVariables(shIdx).SelectedIndex
        If lX < 0 Then Exit Sub
        If lX + 1 = lstVariables(shIdx).Items.Count Then Exit Sub
        varX = VB6.GetItemString(lstVariables(shIdx), lX)
        lstVariables(shIdx).Items.RemoveAt(lX)
        lstVariables(shIdx).Items.Insert(lX + 1, varX)
        lstVariables(shIdx).SelectedIndex = lX + 1
    End Sub

    Private Sub cmdVariablesPaste_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVariablesPaste.Click
        Dim szArr() As String
        Dim szErr, szX As String
        Dim lX, lIdx As Integer
        If My.Computer.Clipboard.ContainsText() Then
            szArr = Split(My.Computer.Clipboard.GetText(), vbCrLf)
            szErr = ""
            lIdx = cmbVariables.SelectedIndex
            ' check data
            For lX = 0 To GetUbound(szArr)
                If Len(szArr(lX)) > 0 Then
                    szX = CheckVariable(szArr(lX), gvarExp(lIdx), mfreqParL, mfreqParR)
                    If Len(szX) > 0 Then
                        szErr = szErr & "Invalid value in line #" & TStr(lX + 1) & ":" & szX & vbCrLf & vbCrLf
                    End If
                End If
            Next
            If Len(szErr) > 0 Then
                MsgBoxOnTop(szErr, MsgBoxStyle.Critical, "Paste Variables")
            Else
                ' copy to list
                For lX = 0 To GetUbound(szArr)
                    If Len(szArr(lX)) > 0 Then lstVariables(CShort(lIdx)).Items.Add(szArr(lX))
                Next
            End If
        End If

    End Sub

    Private Sub cmdVariablesRemove_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVariablesRemove.Click
        Dim lX As Integer
        lX = lstVariables(CShort(cmbVariables.SelectedIndex)).SelectedIndex

        If lX <> -1 Then
            lstVariables(CShort(cmbVariables.SelectedIndex)).Items.RemoveAt((lX))
            If lX >= lstVariables(CShort(cmbVariables.SelectedIndex)).Items.Count Then lX -= 1
            If lX > -1 Then lstVariables(CShort(cmbVariables.SelectedIndex)).SelectedIndex = lX
            lstVariables(CShort(cmbVariables.SelectedIndex)).Focus()
            ShowVariablesIndex(cmbVariables.SelectedIndex)
        End If

    End Sub

    Private Sub cmdSourceDir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSourceDir.Click
        Dim szX As String = ""
        Dim lX As Integer

        If ChangeDir(txtSourceDir.Text) Then txtSourceDir.Text = My.Application.Info.DirectoryPath
        Dim dlgBrowse As New FolderBrowserDialog
        With dlgBrowse
            .SelectedPath = txtSourceDir.Text
            .Description = "Pick the Source Directory"
            .ShowNewFolderButton = False

            If .ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
            If Len(.SelectedPath) <> 0 And txtSourceDir.Text <> .SelectedPath Then
                txtSourceDir.Text = .SelectedPath

                Select Case mStimOutput
                    Case GENMODE.genElectricalRIB
                        szX = Dir(txtSourceDir.Text & "\*.fitt")
                    Case GENMODE.genElectricalRIB2, GENMODE.genVocoder
                        szX = Dir(txtSourceDir.Text & "\*.ampmap")
                        If Len(szX) = 0 Then szX = Dir(txtSourceDir.Text & "\*.fitt")
                End Select

                If Len(szX) = 0 Then
                    MsgBoxOnTop("No fitting files found in the source directory" & vbCrLf & "Please copy some fitting files into the new source directory" & vbCrLf & "to be sure they can be loaded.", MsgBoxStyle.Critical)
                Else
                    Do While szX <> ""
                        lX += 1
                        szX = Dir()
                    Loop
                    MsgBoxOnTop(TStr(lX) & " fitting files found in the source directory." & vbCrLf & "Please check/set the filenames of the fitting files" & vbCrLf & "to be sure they can be loaded!", MsgBoxStyle.Information)
                End If
                SetFittData("", Implant.EARTYPE.LEFT)
                txtFittFile(0).Text = ""
                SetFittData("", Implant.EARTYPE.RIGHT)
                txtFittFile(1).Text = ""
            End If
        End With
    End Sub

    Private Sub cmdVariablesUp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVariablesUp.Click
        Dim shIdx As Short = CShort(cmbVariables.SelectedIndex)
        Dim lX As Integer = lstVariables(shIdx).SelectedIndex
        If lX < 1 Then Return
        Dim varX As String = VB6.GetItemString(lstVariables(shIdx), lX)
        lstVariables(shIdx).Items.RemoveAt(lX)
        lstVariables(shIdx).Items.Insert(lX - 1, varX)
        lstVariables(shIdx).SelectedIndex = lX - 1

    End Sub

    Private Sub cmdViWoColor_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdViWoColor.Click
        Dim dlgColor As New ColorDialog
        With dlgColor
            .Color = shpViWoColor.BackColor
            If .ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
            shpViWoColor.BackColor = .Color
        End With

        Dim lX, lY As Integer
        Dim szX As String

        Dim lIdx As Integer = lstViWoParameters.SelectedIndex
        mblnPreventControl = True
        lstViWoParameters.Items(lIdx) = lstViWoParameters.Items(lIdx).ToString & " *"
        mblnPreventControl = False
        'VB6.SetItemString(lstViWoParameters, lX, gviwoparPreview(lX).Name & " *")

        szX = LCase(gviwoparPreview(lIdx).Name)
        lY = GetUboundViWoTemp()
        For lX = 0 To lY
            If szX = LCase(mviwoparTemp(lX).Name) Then Exit For
        Next

        If lX <= lY Then
            ' parameter found
            mviwoparTemp(lX) = gviwoparPreview(lIdx).Copy
            mviwoparTemp(lX).Value = TStr(System.Drawing.ColorTranslator.ToOle(shpViWoColor.BackColor))
            mviwoparTemp(lX).Dirty = True
        Else
            ReDim Preserve mviwoparTemp(lY + 1)
            mviwoparTemp(lY + 1) = New ViWoParameter
            mviwoparTemp(lY + 1) = gviwoparPreview(lIdx).Copy
            mviwoparTemp(lY + 1).Dirty = True
            mviwoparTemp(lY + 1).Value = TStr(System.Drawing.ColorTranslator.ToOle(shpViWoColor.BackColor))
        End If

    End Sub

    Private Sub cmdViWoSendParameters_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdViWoSendParameters.Click
        Dim Index As Short = cmdViWoSendParameters.GetIndex(DirectCast(eventSender, Button))
        Dim lX, lY As Integer

        Select Case Index
            Case 0 ' send to viwo
                ViWoSend()
            Case 1 ' send to MIDI
                For lX = 0 To GetUboundViWoTemp()
                    For lY = 0 To ViWo.GetPreviewParametersCount - 1
                        If gviwoparPreview(lY).Name = mviwoparTemp(lX).Name Then Exit For
                    Next
                    If lY < ViWo.GetPreviewParametersCount Then
                        ViWo.SendParameterToMIDI(mviwoparTemp(lX))
                    End If
                Next
                RealTimeChange()
        End Select

    End Sub

    Private Sub frmSettings_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        ' deactivate controls
        If gblnExperiment Then
            For Each ctrlX As Control In Me.Controls
                If TypeOf ctrlX Is Button Then
                    ctrlX.Enabled = False
                End If
            Next ctrlX
            cmdCancel.Enabled = True
        End If
        mblnOutputStable = gblnOutputStable
        ' general
        optDeviceType(0).Enabled = Not gblnOutputStable
        optDeviceType(1).Enabled = Not gblnOutputStable
        optDeviceType(2).Enabled = Not gblnOutputStable
        optDeviceType(3).Enabled = Not gblnOutputStable
        optDeviceType(4).Enabled = Not gblnOutputStable
        optDeviceType(5).Enabled = Not gblnOutputStable
        chkDoNotConnectToDevice.Enabled = Not gblnOutputStable
        chkTempDir.Enabled = Not gblnOutputStable
        chkNewWorkDir.Enabled = Not gblnOutputStable
        chkSilentMode.Enabled = Not gblnOutputStable
        cmdDestinationDir.Enabled = chkTempDir.Enabled And Not gblnOutputStable
        cmdDestinationFromSetting.Enabled = chkTempDir.Enabled And Not gblnOutputStable
        TextBoxState(txtDestinationDir, (chkTempDir.CheckState = CheckState.Unchecked) And Not gblnOutputStable)
        cmdDataDir.Enabled = cmbDataDir.Enabled And Not gblnOutputStable
        TextBoxState(txtDataDir, cmbDataDir.Enabled And Not gblnOutputStable)
        chkTTUse.Enabled = glTTMode = 1 Or (glTTMode = 2 And glTTLPT > 0) Or glTTMode = 3 ' CBool(glTTLPT) 'And Not gblnOutputStable

        ' fitting file
        cmdSourceDir.Enabled = Not gblnOutputStable
        cmdFittBrowse(0).Enabled = Not gblnOutputStable
        cmdFittClear(0).Enabled = Not gblnOutputStable
        cmdFittBrowse(1).Enabled = Not gblnOutputStable
        cmdFittClear(1).Enabled = Not gblnOutputStable

        ' description tab
        txtID.Enabled = Not gblnOutputStable

        ' audio
        TextBoxState(txtSamplingRate, Not gblnOutputStable)
        ' tracker
        chkTrackerUse.Enabled = Not gblnOutputStable
        cmbTrackerRepRate.Enabled = Not gblnOutputStable
        cmbTrackerPosScaling.Enabled = Not gblnOutputStable
        For shX As Short = 0 To CShort(glTrackerSensorCount - 1)
            fraTrackerSensor(shX).Enabled = (glTrackerMode > 0) '!!!!!
        Next
        chkViWoSendData.Enabled = gblnOutputStable And gblnTrackerUse
        ' ViWo
        lstViWoWorlds.Enabled = Not gblnViWoLoaded And ViWo.Connected
        '  cmdViWoSendParameters.Enabled = Not gblnViWoLoaded
        '  TextBoxState txtViWoInteger, Not gblnViWoLoaded
        '  TextBoxState txtViWoPosition(0), Not gblnViWoLoaded
        '  TextBoxState txtViWoPosition(1), Not gblnViWoLoaded
        '  TextBoxState txtViWoPosition(2), Not gblnViWoLoaded
        '  cmdViWoColor.Enabled = Not gblnViWoLoaded
    End Sub

    Private Sub FillVariableWithDefault(lZ As Integer)
        Dim lX As Integer
        Dim szArr() As String

        'If My.Computer.Keyboard.ShiftKeyDown Then
        If lZ = -1 Then 'all
            For lY As Integer = 0 To cmbVariables.Items.Count - 1
                If (gvarExp(lY).Flags And FWintern.VariableFlags.vfDisabled) <> FWintern.VariableFlags.vfDisabled AndAlso gvarExp(lY).szDefault <> Nothing Then
                    'If gvarExp(lY).szDefault <> Nothing Then
                    szArr = Split(gvarExp(lY).szDefault, ";")
                    lstVariables(CShort(lY)).Items.Clear()
                    If GetUbound(szArr) <> -1 Then
                        For lX = 0 To UBound(szArr)
                            lstVariables(CShort(lY)).Items.Add(szArr(lX))
                        Next
                    End If
                    'End If
                End If
            Next
            Console.WriteLine("All variables set to default")
        Else
            If cmdVariablesDefault.Enabled Then
                szArr = Split(gvarExp(lZ).szDefault, ";")
                lstVariables(CShort(lZ)).Items.Clear()
                If GetUbound(szArr) <> -1 Then
                    For lX = 0 To UBound(szArr)
                        lstVariables(CShort(lZ)).Items.Add(szArr(lX))
                    Next
                    Console.WriteLine("Variable " & TStr(lZ) & " set to default")
                End If
            End If

        End If

    End Sub

    Private Sub frmSettings_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        lblKeyCode.Text = eventArgs.KeyCode.ToString

        If tabSettings.SelectedTab.Text = "Variables" Then
            Select Case eventArgs.KeyCode
                Case Keys.PageDown ' next variable
                    If cmbVariables.SelectedIndex + 1 <> cmbVariables.Items.Count Then cmbVariables.SelectedIndex = cmbVariables.SelectedIndex + 1
                Case Keys.PageUp ' prev. variable
                    If cmbVariables.SelectedIndex > 0 Then cmbVariables.SelectedIndex = cmbVariables.SelectedIndex - 1
                Case (Keys.D)
                    If My.Computer.Keyboard.CtrlKeyDown Then
                        If My.Computer.Keyboard.ShiftKeyDown Then
                            FillVariableWithDefault(-1) 'all variables
                        Else
                            FillVariableWithDefault(cmbVariables.SelectedIndex) 'selected variable
                        End If
                        ShowVariablesIndex(cmbVariables.SelectedIndex)
                    End If
            End Select

        End If
        Select Case eventArgs.KeyCode
            Case Keys.S
                If eventArgs.Control Then SaveSettings(1) ' calls SaveSettings as if the "OK" button were pressed
        End Select
    End Sub

    ' Here the routines for all three Settings buttons "OK", "Cancel", and "Apply" are now managed together here
    Private Sub SaveSettings(ByVal close As Integer)

        If close = 1 Or close = 2 Then ' "OK" or "Apply" button pressed - don't save when cancelled
            If SetSettings() Then ' also sets the public constants for fitting file names and directory
                Exit Sub
            End If
        End If

        If gblnSettingsLoaded1 Then
            frmMain.ServeData(FWintern.ServeDataEnum.SendSettings, 0, 0, "")
            For i As Integer = 1 To glClientCount
                If gblnClientsSetting(i) Then
                    frmMain.ServeData(FWintern.ServeDataEnum.ChangeSettings1, 0, 0, "", i)
                End If
            Next
            frmMain.ServeData(FWintern.ServeDataEnum.ItemlistColCountListStatus, 0, 0, "")
        End If

        If close = 1 Or close = 3 Then ' "OK" or "Cancel" button pressed
            tmrTracker.Enabled = False
            tmrTracker.Stop()
            gblnSettingsForm = False
            Me.Close() ' - triggers frmSettings_FormClosed() - there, F4FL and F4FR are set for public use in the application (outside the Settings)
            ' - SetSettings() updates fitting file names and directory if "OK" was pressed and before frmSettings_FormClosed() is executed
        End If

    End Sub

    Private Sub frmSettings_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        'Me.Icon = frmMain.Icon

        ' set size
        If grectSettings.Width < Me.MinimumSize.Width Then grectSettings.Width = Me.Size.Width
        Me.Width = grectSettings.Width
        If grectSettings.Height < Me.MinimumSize.Height Then grectSettings.Height = Me.Size.Height
        Me.Height = grectSettings.Height
        ' move window
        If grectSettings.Left + 0.25 * Me.Width > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width Then
            grectSettings.Left = CInt(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - 0.25 * Me.Width)
        End If
        If grectSettings.Left + 0.75 * Me.Width < 0 Then
            grectSettings.Left = CInt(-0.75 * Me.Width)
        End If
        If grectSettings.Top + 0.25 * Me.Height > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height Then
            grectSettings.Top = CInt(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 0.25 * Me.Height)
        End If
        If grectSettings.Top < 0 Then
            grectSettings.Top = 0
        End If

        Me.SetBounds(grectSettings.Left, grectSettings.Top, 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
        ' create control collections
        sldAudioDitherAmp = New System.Collections.Generic.List(Of TrackBar)
        sldAudioDitherAmp.Add(sldAudioDitherAmp_0)
        sldAudioDitherAmp.Add(sldAudioDitherAmp_1)
        ' show form
        mblnOutputStable = gblnOutputStable

        ShowForm()
        Me.Show()
        tabSettings.SelectedTab = tabGeneral
        mblnTrackerSaveData = False
        ' callback user event
        If Not IsNothing(glOnSettingsLoadAddr) Then glOnSettingsLoadAddr()
        'Me.TopMost = True
        gblnSettingsForm = True

    End Sub

    ' Handles final adjustments after the Settings form has been clear, i.e., executing callback functions and setting F4FL and F4FR.
    ' Triggered by Me.Close() in SaveSettings()
    Private Sub frmSettings_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim szErr As String

        If mlExpType <> glExpType Then If Not IsNothing(glOnSettingsExpTypeChangeAddr) Then glOnSettingsExpTypeChangeAddr(mlExpType, glExpType)

        ' changed, see FWhistory (ML 21/07/2020)
        '
        ' If mStimOutput <> mStimOutput Then If Not IsNothing(glOnOutputDeviceChangeAddr) Then glOnOutputDeviceChangeAddr(mStimOutput, gStimOutput)
        If mStimOutput <> gStimOutput Then If Not IsNothing(glOnOutputDeviceChangeAddr) Then glOnOutputDeviceChangeAddr(mStimOutput, gStimOutput)

        ' Dim szSender As Short = cmdMoveValue.GetIndex(DirectCast(eventSender, Button))
        'Dim btn As Button = DirectCast(eventSender, Button)

        Select Case gStimOutput

            Case GENMODE.genElectricalRIB2, GENMODE.genElectricalRIB, GENMODE.genElectricalNIC 'electric

                'If Not gblnOutputStable Then
                '    F4FL.ClearParameters()
                '    F4FR.ClearParameters()
                'End If

                ' ------
                ' Write F4FL and F4FR for public use outside the Settings:
                ' 
                ' - If "OK" (or "Apply") was pressed, SetSettings() updated gszSourceDir, gszFittFileLeft, gszFittFileRight. Hence, new parameters are loaded to F4FL and F4FR
                ' - If "Cancel" was pressed, the old parameters are loaded
                ' - If "Apply" was pressed before "Cancel", the parameters updated when having pressed "Apply" are loaded

                ' left
                F4FL.ClearParameters()
                Dim szX As String = F4FL.OpenFile(gszSourceDir & "\" & gszFittFileLeft)
                If Len(szX) <> 0 Then
                    F4FL.ClearParameters()
                    szErr = "Error reading fitting file:" & vbCrLf & szX
                    If gszFittFileLeft <> "" Then MsgBoxOnTop(szErr)
                End If
                ' right
                F4FR.ClearParameters()
                szX = F4FR.OpenFile(gszSourceDir & "\" & gszFittFileRight)
                If Len(szX) <> 0 Then
                    F4FR.ClearParameters()
                    szErr = "Error reading fitting file:" & vbCrLf & szX
                    If gszFittFileRight <> "" Then MsgBoxOnTop(szErr)
                End If

        End Select

        If Not gblnExperiment Then cmdExpHide_Click(cmdExpHide, New System.EventArgs())
        grectSettings.Left = Me.Left
        grectSettings.Top = Me.Top
        grectSettings.Height = Me.Height
        grectSettings.Width = Me.Width
        gblnSettingsForm = False
        tmrRealTime.Enabled = False
        tmrRealTime.Stop()
        If mblnTrackerSaveData Then FileClose(mlTrackerFNr)

        szErr = ViWo.SendAllParameters
        If Len(szErr) > 0 Then MsgBoxOnTop(szErr)
        szErr = ViWo.SendAllParametersToMIDI
        If Len(szErr) > 0 Then MsgBoxOnTop(szErr)

        'frmMain.SetUIReady()

    End Sub

    Private Sub lblTrackerA_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lblTrackerA.Click, lblTrackerARange.Click
        
        Dim Index As Short
        'Try 'regular label?
        If InStr(lCase(CType(eventSender, Label).Name),"_range") > 0 Then 'range label?
             Index = lblTrackerARange.GetIndex(DirectCast(eventSender, Label))
        Else 'position label
             Index = lblTrackerA.GetIndex(DirectCast(eventSender, Label))
        End If
            
        Tracker.SetRangeData(CInt(Index), "A")
        frmSettingsTrackRange.ShowDialog()
        For lX As Short = 0 To 1
            lblTrackerA(lX).Font = VB6.FontChangeBold(lblTrackerA(lX).Font, ((gtsTrackerMin(lX).lStatus And 8) <> 0) Or ((gtsTrackerMax(lX).lStatus And 8) <> 0))
            'If ((gtsTrackerMin(lX).lStatus And 8) <> 0 Or (gtsTrackerMax(lX).lStatus And 8) <> 0) Then lblTrackerARange(lX).Text = "(" & gtsTrackerMin(lX).sngA & " / " & gtsTrackerMax(lX).sngA & ")" Else lblTrackerARange(lX).Text = ""
            Dim szRangeTempMin As String = "" : Dim szRangeTempMax As String = ""
            If (gtsTrackerMin(lX).lStatus And 8) <> 0 Then szRangeTempMin = gtsTrackerMin(lX).sngA & "<"
            If (gtsTrackerMax(lX).lStatus And 8) <> 0 Then szRangeTempMax = "<" & gtsTrackerMax(lX).sngA
            If (szRangeTempMin <> "" Or szRangeTempMax <> "") Then lblTrackerARange(lX).Text = szRangeTempMin & "A" & szRangeTempMax Else lblTrackerARange(lX).Text = ""
            ToolTip1.SetToolTip(lblTrackerARange(lX), lblTrackerARange(lX).Text)
        Next
    End Sub

    Private Sub lblTrackerE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lblTrackerE.Click, lblTrackerERange.Click

        Dim Index As Short
        'Try 'regular label?
        If InStr(lCase(CType(eventSender, Label).Name),"_range") > 0 Then 'range label?
             Index = lblTrackerERange.GetIndex(DirectCast(eventSender, Label))
        Else 'position label
             Index = lblTrackerE.GetIndex(DirectCast(eventSender, Label))
        End If

        Tracker.SetRangeData(Index, "E")
        frmSettingsTrackRange.ShowDialog()
        For lX As Short = 0 To 1
            lblTrackerE(lX).Font = VB6.FontChangeBold(lblTrackerE(lX).Font, ((gtsTrackerMin(lX).lStatus And 16) <> 0) Or ((gtsTrackerMax(lX).lStatus And 16) <> 0))
            Dim szRangeTempMin As String = "" : Dim szRangeTempMax As String = ""
            If (gtsTrackerMin(lX).lStatus And 16) <> 0 Then szRangeTempMin = gtsTrackerMin(lX).sngE & "<"
            If (gtsTrackerMax(lX).lStatus And 16) <> 0 Then szRangeTempMax = "<" & gtsTrackerMax(lX).sngE
            If (szRangeTempMin <> "" Or szRangeTempMax <> "") Then lblTrackerERange(lX).Text = szRangeTempMin & "E" & szRangeTempMax Else lblTrackerERange(lX).Text = ""
            ToolTip1.SetToolTip(lblTrackerERange(lX), lblTrackerERange(lX).Text)
        Next
    End Sub

    Private Sub lblTrackerR_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lblTrackerR.Click, lblTrackerRRange.Click

        Dim Index As Short
        'Try 'regular label?
        If InStr(lCase(CType(eventSender, Label).Name),"_range") > 0 Then 'range label?
             Index = lblTrackerRRange.GetIndex(DirectCast(eventSender, Label))
        Else 'position label
             Index = lblTrackerR.GetIndex(DirectCast(eventSender, Label))
        End If

        Tracker.SetRangeData(Index, "R")
        frmSettingsTrackRange.ShowDialog()
        For lX As Short = 0 To 1
            lblTrackerR(lX).Font = VB6.FontChangeBold(lblTrackerR(lX).Font, ((gtsTrackerMin(lX).lStatus And 32) <> 0) Or ((gtsTrackerMax(lX).lStatus And 32) <> 0))
            Dim szRangeTempMin As String = "" : Dim szRangeTempMax As String = ""
            If (gtsTrackerMin(lX).lStatus And 32) <> 0 Then szRangeTempMin = gtsTrackerMin(lX).sngR & "<"
            If (gtsTrackerMax(lX).lStatus And 32) <> 0 Then szRangeTempMax = "<" & gtsTrackerMax(lX).sngR
            If (szRangeTempMin <> "" Or szRangeTempMax <> "") Then lblTrackerRRange(lX).Text = szRangeTempMin & "R" & szRangeTempMax Else lblTrackerRRange(lX).Text = ""
            ToolTip1.SetToolTip(lblTrackerRRange(lX), lblTrackerRRange(lX).Text)
        Next
    End Sub

    Private Sub lblTrackerX_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lblTrackerX.Click, lblTrackerXRange.Click

        Dim Index As Short
        'Try 'regular label?
        If InStr(lCase(CType(eventSender, Label).Name),"_range") > 0 Then 'range label?
             Index = lblTrackerXRange.GetIndex(DirectCast(eventSender, Label))
        Else 'position label
             Index = lblTrackerX.GetIndex(DirectCast(eventSender, Label))
        End If

        Tracker.SetRangeData(Index, "X")
        frmSettingsTrackRange.ShowDialog()
        For lX As Short = 0 To 1
            lblTrackerX(lX).Font = VB6.FontChangeBold(lblTrackerX(lX).Font, (((gtsTrackerMin(lX).lStatus And 1) <> 0) Or ((gtsTrackerMax(lX).lStatus And 1) <> 0)))
            Dim szRangeTempMin As String = "" : Dim szRangeTempMax As String = ""
            If (gtsTrackerMin(lX).lStatus And 1) <> 0 Then szRangeTempMin = gtsTrackerMin(lX).sngX & "<"
            If (gtsTrackerMax(lX).lStatus And 1) <> 0 Then szRangeTempMax = "<" & gtsTrackerMax(lX).sngX
            If (szRangeTempMin <> "" Or szRangeTempMax <> "") Then lblTrackerXRange(lX).Text = szRangeTempMin & "X" & szRangeTempMax Else lblTrackerXRange(lX).Text = ""
            ToolTip1.SetToolTip(lblTrackerXRange(lX), lblTrackerXRange(lX).Text)
        Next
    End Sub

    Private Sub lblTrackerY_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lblTrackerY.Click, lblTrackerYRange.Click

        Dim Index As Short
        'Try 'regular label?
        If InStr(lCase(CType(eventSender, Label).Name),"_range") > 0 Then 'range label?
             Index = lblTrackerYRange.GetIndex(DirectCast(eventSender, Label))
        Else 'position label
             Index = lblTrackerY.GetIndex(DirectCast(eventSender, Label))
        End If

        Tracker.SetRangeData(Index, "Y")
        frmSettingsTrackRange.ShowDialog()
        For lX As Short = 0 To 1
            lblTrackerY(lX).Font = VB6.FontChangeBold(lblTrackerY(lX).Font, (((gtsTrackerMin(lX).lStatus And 2) <> 0) Or ((gtsTrackerMax(lX).lStatus And 2) <> 0)))
            Dim szRangeTempMin As String = "" : Dim szRangeTempMax As String = ""
            If (gtsTrackerMin(lX).lStatus And 2) <> 0 Then szRangeTempMin = gtsTrackerMin(lX).sngY & "<"
            If (gtsTrackerMax(lX).lStatus And 2) <> 0 Then szRangeTempMax = "<" & gtsTrackerMax(lX).sngY
            If (szRangeTempMin <> "" Or szRangeTempMax <> "") Then lblTrackerYRange(lX).Text = szRangeTempMin & "Y" & szRangeTempMax Else lblTrackerYRange(lX).Text = ""
            ToolTip1.SetToolTip(lblTrackerYRange(lX), lblTrackerYRange(lX).Text)
        Next
    End Sub

    Private Sub lblTrackerZ_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lblTrackerZ.Click, lblTrackerZRange.Click

        Dim Index As Short
        'Try 'regular label?
        If InStr(lCase(CType(eventSender, Label).Name),"_range") > 0 Then 'range label?
             Index = lblTrackerZRange.GetIndex(DirectCast(eventSender, Label))
        Else 'position label
             Index = lblTrackerZ.GetIndex(DirectCast(eventSender, Label))
        End If

        Tracker.SetRangeData(Index, "Z")
        frmSettingsTrackRange.ShowDialog()
        For lX As Short = 0 To 1
            lblTrackerZ(lX).Font = VB6.FontChangeBold(lblTrackerZ(lX).Font, ((gtsTrackerMin(lX).lStatus And 4) <> 0) Or ((gtsTrackerMax(lX).lStatus And 4) <> 0))
            Dim szRangeTempMin As String = "" : Dim szRangeTempMax As String = ""
            If (gtsTrackerMin(lX).lStatus And 4) <> 0 Then szRangeTempMin = gtsTrackerMin(lX).sngZ & "<"
            If (gtsTrackerMax(lX).lStatus And 4) <> 0 Then szRangeTempMax = "<" & gtsTrackerMax(lX).sngZ
            If (szRangeTempMin <> "" Or szRangeTempMax <> "") Then lblTrackerZRange(lX).Text = szRangeTempMin & "Z" & szRangeTempMax Else lblTrackerZRange(lX).Text = ""
            ToolTip1.SetToolTip(lblTrackerZRange(lX), lblTrackerZRange(lX).Text)
        Next
    End Sub

    Private Sub lstVariables_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstVariables.KeyDown
        If e.KeyCode = Keys.Delete Then 'delete value
            Dim lX As Integer
            lX = lstVariables(CShort(cmbVariables.SelectedIndex)).SelectedIndex
            If lX <> -1 Then 'empty list?
                lstVariables(CShort(cmbVariables.SelectedIndex)).Items.RemoveAt(lX)
                If lX >= lstVariables(CShort(cmbVariables.SelectedIndex)).Items.Count Then lX -= 1
                If lX > -1 Then lstVariables(CShort(cmbVariables.SelectedIndex)).SelectedIndex = lX
                lstVariables(CShort(cmbVariables.SelectedIndex)).Focus()
            End If
            ShowVariablesIndex(cmbVariables.SelectedIndex)
            'ElseIf e.KeyCode = Keys.D Then 'duplicate value
            '    Dim lX As Integer
            '    Dim varX As String
            '    Dim szErr As String
            '    ' get data
            '    lX = cmbVariables.SelectedIndex
            '    varX = lstVariables(CShort(cmbVariables.SelectedIndex)).Text
            '    szErr = CheckVariable(varX, gvarExp(lX), mfreqParL, mfreqParR)
            '    If Len(szErr) <> 0 Then
            '        MsgBoxOnTop(szErr, MsgBoxStyle.Critical, "Invalid Input")
            '        Return
            '    End If
            '    ' insert copy
            '    lstVariables(CShort(lX)).Items.Insert(lstVariables(CShort(cmbVariables.SelectedIndex)).SelectedIndex + 1, varX)

            '    ShowVariablesIndex(lX)
            '    If Not IsNothing(glOnSettingsChangeAddr) Then glOnSettingsChangeAddr(mlExpType)

        End If
    End Sub

    Private Sub lstVariables_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstVariables.SelectedIndexChanged
        If Me.IsInitializing = True Then Return
        Dim Index As Short = lstVariables.GetIndex(DirectCast(eventSender, ListBox))
        Dim lX As Integer = Index
        ShowVariablesIndex(lX)
    End Sub

    Private Sub lstVariables_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstVariables.DoubleClick
        Dim Index As Short = lstVariables.GetIndex(DirectCast(eventSender, ListBox))
        Dim lIdx As Integer = cmbVariables.SelectedIndex
        Dim lX As Integer = lstVariables(CShort(lIdx)).SelectedIndex
        If lX < 0 Then Return
        txtVariables.Text = VB6.GetItemString(lstVariables(CShort(lIdx)), lX)

    End Sub

    Private Sub lstViWoParameters_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstViWoParameters.SelectedIndexChanged
        If Me.IsInitializing = True Then Return
        If mblnPreventControl Then Return

        Dim lIdx As Integer
        Dim lX, lY As Integer
        Dim szX As String
        Dim szArr() As String
        Dim viwoparX As New ViWoParameter

        lIdx = lstViWoParameters.SelectedIndex
        If lIdx < 0 Then Return
        szX = LCase(gviwoparPreview(lIdx).Name)
        lY = GetUboundViWoTemp()
        For lX = 0 To lY
            If szX = LCase(mviwoparTemp(lX).Name) Then Exit For
        Next

        If lX <= lY Then
            viwoparX = mviwoparTemp(lX).Copy ' parameter found
        Else
            viwoparX = gviwoparPreview(lIdx).Copy ' parameter not found, copy from preview
        End If

        For shX As Short = 0 To CShort(fraViWoParameter.Count - 1)
            fraViWoParameter(shX).Visible = False
        Next
        If Val(viwoparX.MIDI) <> 0 Then szX = "MIDI-Controller: " & viwoparX.MIDI Else szX = "No MIDI"
        Select Case LCase(viwoparX.Type)
            Case "int", "float", "string"
                fraViWoParameter(0).Visible = True
                fraViWoParameter(0).Text = szX
                txtViWoInteger.Text = viwoparX.Value
            Case "color"
                fraViWoParameter(1).Visible = True
                fraViWoParameter(1).Text = szX
                shpViWoColor.BackColor = System.Drawing.ColorTranslator.FromOle(CInt(Val(viwoparX.Value)))
            Case "position"
                fraViWoParameter(2).Visible = True
                fraViWoParameter(2).Text = szX
                szArr = Split(viwoparX.Value, " ")
                If GetUbound(szArr) >= 0 Then txtViWoPosition(0).Text = szArr(0) Else txtViWoPosition(0).Text = "0"
                If GetUbound(szArr) >= 1 Then txtViWoPosition(1).Text = szArr(1) Else txtViWoPosition(1).Text = "0"
                If GetUbound(szArr) >= 2 Then txtViWoPosition(2).Text = szArr(2) Else txtViWoPosition(2).Text = "0"
            Case "4param"
                fraViWoParameter(3).Visible = True
                fraViWoParameter(3).Text = szX
                szArr = Split(viwoparX.Value, " ")
                If GetUbound(szArr) >= 0 Then txtViWoPar(0).Text = szArr(0) Else txtViWoPar(0).Text = "0"
                If GetUbound(szArr) >= 1 Then txtViWoPar(1).Text = szArr(1) Else txtViWoPar(1).Text = "0"
                If GetUbound(szArr) >= 2 Then txtViWoPar(2).Text = szArr(2) Else txtViWoPar(2).Text = "0"
                If GetUbound(szArr) >= 3 Then txtViWoPar(3).Text = szArr(3) Else txtViWoPar(3).Text = "0"
        End Select

    End Sub

    Private Sub lstViWoWorlds_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstViWoWorlds.SelectedIndexChanged
        If Me.IsInitializing = True Then Return

        Dim lX, lY As Integer
        Dim szX, szType As String

        Console.WriteLine("selected")

        lstViWoParameters.Items.Clear()
        For lX = 0 To GetUboundViWoTemp()
            mviwoparTemp(lX).Dirty = False
        Next

        If ViWo.Connected Then
            ViWo.LoadPreviewParameters(VB6.GetItemString(lstViWoWorlds, lstViWoWorlds.SelectedIndex), pbProgress)
        Else
            ViWo.LoadPreviewParameters(VB6.GetItemString(lstViWoWorlds, 0), pbProgress) ' load dummy world parameters
        End If
        For lX = 0 To ViWo.GetPreviewParametersCount - 1
            szX = LCase(gviwoparPreview(lX).Name)
            szType = LCase(gviwoparPreview(lX).Type)
            If GetUboundViWoTemp() > -1 Then
                For lY = 0 To UBound(mviwoparTemp)
                    If LCase(mviwoparTemp(lY).Name) = szX And LCase(mviwoparTemp(lY).Type) = szType Then Exit For
                Next
                If lY <= UBound(mviwoparTemp) Then
                    ' corresponding parameter found in settings
                    szX = mviwoparTemp(lY).Value
                    mviwoparTemp(lY) = gviwoparPreview(lX).Copy
                    mviwoparTemp(lY).Value = szX
                    mviwoparTemp(lY).Dirty = True
                    lstViWoParameters.Items.Add(gviwoparPreview(lX).Name & " *")
                Else
                    lstViWoParameters.Items.Add(gviwoparPreview(lX).Name)
                End If
            Else
                lstViWoParameters.Items.Add(gviwoparPreview(lX).Name)
            End If
        Next
        For shX As Short = 0 To CShort(fraViWoParameter.Count - 1)
            fraViWoParameter(shX).Visible = False
            fraViWoParameter(shX).Left = fraViWoParameter(0).Left
            fraViWoParameter(shX).Top = fraViWoParameter(0).Top
        Next
    End Sub

    Private Sub optAudioDitherLeft_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optAudioDitherLeft.CheckedChanged
        If Me.IsInitializing = True Then Return
        If mblnPreventControl Then Return
        If Not mblnOutputStable Then Return
        Dim Index As Short = optAudioDitherLeft.GetIndex(DirectCast(eventSender, RadioButton))
        If optAudioDitherLeft(Index).Checked Then
            RealTimeChange()
            Select Case Index
                Case 0
                    Output.Send("/DAC/SetAddStream/" & TStr(glPlayerHPLeft - 1), "set", "silence")
                Case 1
                    Output.Send("/DAC/SetAddStream/" & TStr(glPlayerHPLeft - 1), "set", "syn0")
                Case 2
                    Output.Send("/DAC/SetAddStream/" & TStr(glPlayerHPLeft - 1), "set", "syn1")
            End Select
        End If
    End Sub

    Private Sub optAudioDitherRight_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optAudioDitherRight.CheckedChanged
        If Me.IsInitializing = True Then Return
        If mblnPreventControl Then Return
        If Not mblnOutputStable Then Return
        Dim Index As Short = optAudioDitherRight.GetIndex(DirectCast(eventSender, RadioButton))
        If optAudioDitherRight(Index).Checked Then
            RealTimeChange()
            Select Case Index
                Case 0
                    Output.Send("/DAC/SetAddStream/" & TStr(glPlayerHPRight - 1), "set", "silence")
                Case 1
                    Output.Send("/DAC/SetAddStream/" & TStr(glPlayerHPRight - 1), "set", "syn0")
                Case 2
                    Output.Send("/DAC/SetAddStream/" & TStr(glPlayerHPRight - 1), "set", "syn1")
            End Select
        End If
    End Sub

    Private Sub optAudioSynthDAC_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optAudioSynthDAC.CheckedChanged
        If Me.IsInitializing = True Then Return
        If mblnPreventControl Then Return

        Dim Index As Short = optAudioSynthDAC.GetIndex(DirectCast(eventSender, RadioButton))
        Console.WriteLine(TStr(Index) & ": " & optAudioSynthDAC(Index).Checked)
        If Not optAudioSynthDAC(Index).Checked Then Return
        Dim lX As Integer = cmbAudioSynthCh.SelectedIndex
        mblnPreventControl = True
        Select Case Index
            Case 0
                VB6.SetItemString(cmbAudioSynthCh, lX, TStr(lX + 1))
            Case 1
                VB6.SetItemString(cmbAudioSynthCh, lX, TStr(lX + 1) & " Synth A")
            Case 2
                VB6.SetItemString(cmbAudioSynthCh, lX, TStr(lX + 1) & " Synth B")
        End Select
        mblnPreventControl = False
        mlAudioDACAddStream(lX) = Index


        If gblnOutputStable Then
            RealTimeChange()
            Select Case Index
                Case 0
                    Output.Send("/DAC/SetAddStream/" & TStr(lX), "set", "silence")
                Case 1
                    Output.Send("/DAC/SetAddStream/" & TStr(lX), "set", "syn0")
                Case 2
                    Output.Send("/DAC/SetAddStream/" & TStr(lX), "set", "syn1")
            End Select
        End If
    End Sub

    Private Sub optDeviceType_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optDeviceType.CheckedChanged
        If Me.IsInitializing = True Then Return
        If mblnPreventControl Then Return
        Dim Index As Short = optDeviceType.GetIndex(DirectCast(eventSender, RadioButton))
        Dim mStimOutputBackup As GENMODE

        If optDeviceType(Index).Checked = False Then Return

        ' leave if change is between Unity <-> pd
        If (CType(mStimOutput, Integer) = 1 And Index = 5) Or (CType(mStimOutput, Integer) = 5 And Index = 1) Then
            mStimOutputBackup = mStimOutput
            mStimOutput = CType(Index, GENMODE)
            GoTo SkipSignalReset
        End If

        If Not IsNothing(mfreqParL) Or Not IsNothing(mfreqParR) Then
            If MsgBox("Change device type and delete the signal parameters?", _
                        MsgBoxStyle.Question Or MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then
                ' cancel - revert the click
                mblnPreventControl = True
                For lX As Integer = 0 To 5
                    Me.optDeviceType(CShort(lX)).Checked = CBool(lX = CType(mStimOutput, Integer))
                Next
                mblnPreventControl = False
                Return
            End If
        End If
        ' ok - delete signals
        F4FL.ImpType = Implant.IMPLANTTYPE.imptInvalid
        F4FR.ImpType = Implant.IMPLANTTYPE.imptInvalid
        AdaptSignalToFitt(Implant.EARTYPE.LEFT)
        AdaptSignalToFitt(Implant.EARTYPE.RIGHT)
        mStimOutputBackup = mStimOutput
        mStimOutput = CType(Index, GENMODE)
        Select Case mStimOutput
            Case GENMODE.genAcoustical, GENMODE.genAcousticalUnity
                lblSignal.Text = "Acoust. channel:"
            Case GENMODE.genElectricalRIB, GENMODE.genElectricalNIC
                lblSignal.Text = "Electrode:"
            Case GENMODE.genElectricalRIB2, GENMODE.genVocoder
                lblSignal.Text = "Electrode:"
                If Val(txtOffsetL.Text) < 55 Or Not IsNumeric(txtOffsetL.Text) Then txtOffsetL.Text = "55"
                If Val(txtOffsetR.Text) < 55 Or Not IsNumeric(txtOffsetR.Text) Then txtOffsetR.Text = "55"
        End Select
        UpdateSignalTab(Implant.EARTYPE.LEFT)
        UpdateSignalTab(Implant.EARTYPE.RIGHT)
        SetFittData("", Implant.EARTYPE.LEFT)
        txtFittFile(CShort(Implant.EARTYPE.LEFT)).Text = ""
        SetFittData("", Implant.EARTYPE.RIGHT)
        txtFittFile(CShort(Implant.EARTYPE.RIGHT)).Text = ""

SkipSignalReset:
        If Not IsNothing(glOnOutputDeviceChangeAddr) Then glOnOutputDeviceChangeAddr(mStimOutputBackup, mStimOutput)
        If Not IsNothing(glOnSettingsChangeAddr) Then glOnSettingsChangeAddr(mlExpType)
        UpdateConstants()
        UpdateVariables()
    End Sub

    Private Sub sldAudioDitherAmp_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) _
                Handles sldAudioDitherAmp_0.ValueChanged, sldAudioDitherAmp_0.Scroll, _
                        sldAudioDitherAmp_1.ValueChanged, sldAudioDitherAmp_1.Scroll 
        Dim Index As Short = CShort(sldAudioDitherAmp.IndexOf(DirectCast(eventSender, TrackBar)))
        Dim lX As Integer = sldAudioDitherAmp.Item(Index).Value
        If lX = 0 Then
            lblAudioDitherAmp(Index).Text = "-inf"
        Else
            lblAudioDitherAmp(Index).Text = TStr(Math.Round((lX - 1000) / 10, 1))
        End If
        If Not mblnOutputStable Then Return
        If mblnPreventControl Then Return
        ' send amp to player
        RealTimeChange()
        Output.Send("/Synth/SetVol/" & TStr(Index), CSng(lX) / 10)

    End Sub

    Private Sub sldL_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sldL.ValueChanged, sldL.Scroll

        If mlElectrodeL < 1 Then Exit Sub
        With mfreqParL(mlElectrodeL - 1)
            .sAmp = sldL.Value
            lblLevelL.Text = TStr(.lRange) & ":" & TStr(.sAmp) & " cu" & vbCrLf & _
                             F4FL.CalcCurrentAsString(CInt(.sAmp), .lRange) & " uA"
        End With
    End Sub

    Private Sub sldR_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sldR.ValueChanged, sldR.Scroll

        If mlElectrodeR < 1 Then Exit Sub
        With mfreqParR(mlElectrodeR - 1)
            .sAmp = sldR.Value
            lblLevelR.Text = TStr(.lRange) & ":" & TStr(.sAmp) & " cu" & vbCrLf & _
                             F4FR.CalcCurrentAsString(CInt(.sAmp), .lRange) & " uA"
        End With
    End Sub

    Private Sub OrganizeConstantsTab()
        If GetUboundConstants() <> -1 Then

            Dim lMaxLblWidth As Integer = 0 'for positioning and size of elements in constants tab
            For lX As Short = 0 To CShort(UBound(gconstExp))
                lMaxLblWidth = Math.Max(lMaxLblWidth, Len(lblConstName(lX).Text))
                'Debug.Print(lblConstName(lX).Text & Len(lblConstName(lX).Text))
            Next

            lMaxLblWidth = Math.Min(lMaxLblWidth, 56)
            Dim lChange As Integer = txtConstValue(0).Left - 230 - lMaxLblWidth * 2 'width is dynamic, we want to find out if a change of width will happen

            For lX As Short = 0 To CShort(UBound(gconstExp))
                If lMaxLblWidth > 35 Then 'long labels -> adapt widths of labels and text boxes?
                    'positions and sizes
                    lblConstName(lX).Left = 19 ' lblConstName(0).Left
                    lblConstName(lX).Width = 205 + lMaxLblWidth * 2  ' lblConstName(lX).Width + 100

                    txtConstValue(lX).Left = 230 + lMaxLblWidth * 2 ' txtConstValue(0).Left + 100
                    txtConstValue(lX).Width = txtConstValue(lX).Width + lChange
                Else
                    lblConstName(lX).Left = lblConstName(0).Left
                    txtConstValue(lX).Left = txtConstValue(0).Left
                End If


                If (gconstExp(lX).Flags And 15) = FWintern.VariableFlags.vfNumeric And (gconstExp(lX).Flags And FWintern.VariableFlags.vfVectorized) = 0 Then

                    txtConstValue(lX).TextAlign = HorizontalAlignment.Right
                Else
                    txtConstValue(lX).TextAlign = HorizontalAlignment.Left
                End If

                If (gconstExp(lX).Flags And 15) = FWintern.VariableFlags.vfFileName Then
                    cmdConstCmd(lX).Left = txtConstValue(lX).Left + txtConstValue(lX).Width + 4
                    lblConstUnit(lX).Left = cmdConstCmd(lX).Left + cmdConstCmd(lX).Width + 3
                Else
                    lblConstUnit(lX).Left = txtConstValue(lX).Left + txtConstValue(lX).Width + 4
                End If
            Next
        End If
    End Sub
    Private Sub tabSettings_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tabSettings.MouseClick
        tmrTracker.Enabled = False
        Select Case tabSettings.SelectedTab.Name
            Case "tabConstants" ' constants
                OrganizeConstantsTab()
            Case "tabVariables" ' variables
                If cmbVariables.SelectedIndex > -1 Then
                    If Len(gvarExp(cmbVariables.SelectedIndex).szDescription) = 0 Then
                        txtVariablesDescr.Text = "Sets the " & gvarExp(cmbVariables.SelectedIndex).szName & vbCrLf & vbCrLf & "(Variable #" & TStr(cmbVariables.SelectedIndex) & ")"
                    Else
                        txtVariablesDescr.Text = gvarExp(cmbVariables.SelectedIndex).szDescription & vbCrLf & vbCrLf & "(Variable #" & TStr(cmbVariables.SelectedIndex) & ")"
                    End If
                End If

            Case "tabTracker" ' tracker
                If gblnTrackerUse And gblnOutputStable Then
                    If glTrackerSettingsInterval = 0 Then
                        tmrTracker.Enabled = False
                    Else
                        tmrTracker.Interval = glTrackerSettingsInterval
                        tmrTracker.Enabled = True
                    End If
                End If
        End Select
    End Sub

    Private Sub tmrExpResize_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrExpResize.Tick
        cmdExpGetSize_Click(cmdExpGetSize, New System.EventArgs())
        frmExp.SetProgress(Second(TimeOfDay))
    End Sub

    Private Sub tmrRealTime_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrRealTime.Tick
        tmrRealTime.Enabled = False
        lblRealTime.ForeColor = System.Drawing.SystemColors.GrayText
    End Sub

    Private Sub tmrTracker_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrTracker.Tick
        Dim tsData As TrackerSensor
        Dim szErr As String
        Console.WriteLine("Tracker: enter")
        Dim lX As Short = CShort(mlTrackerTimerIndex)
        szErr = Tracker.GetCurrentValues(tmrTracker.Interval \ 2, lX, tsData)
        If Len(szErr) <> 0 Then GoTo SubError
        lblTrackerTimeOut.Visible = False
        lblTrackerX(lX).Text = TStr(Math.Round(tsData.sngX, 1))
        lblTrackerY(lX).Text = TStr(Math.Round(tsData.sngY, 1))
        lblTrackerZ(lX).Text = TStr(Math.Round(tsData.sngZ, 1))
        lblTrackerA(lX).Text = TStr(Math.Round(tsData.sngA, 1))
        lblTrackerE(lX).Text = TStr(Math.Round(tsData.sngE, 1))
        lblTrackerR(lX).Text = TStr(Math.Round(tsData.sngR, 1))
        mlTrackerTimerIndex = (lX + 1) Mod glTrackerSensorCount
        If mblnTrackerSaveData Then
            'Debug.Print #mlTrackerFNr, Str$(Time) + "," + TStr(lX) + "," + lblTrackerX(lX) + "," + _
            ''lblTrackerY(lX) + "," + lblTrackerZ(lX) + "," + _
            ''lblTrackerA(lX) + "," + lblTrackerE(lX) + "," + _
            ''lblTrackerR(lX) + "," + TStr(Turntable.GetAngle)
        End If
        Console.WriteLine("Tracker: left")
        Return
SubError:
        Console.WriteLine("Tracker: error")
        lblTrackerTimeOut.Visible = True

    End Sub

    Private Sub txtAudioDitherHC_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtAudioDitherHC.TextChanged
        If Me.IsInitializing = True Then Return
        If Not mblnOutputStable Then Return
        If mblnPreventControl Then Return
        Dim Index As Short = txtAudioDitherHC.GetIndex(DirectCast(eventSender, TextBox))
        If Len(txtAudioDitherHC(Index).Text) = 0 Then Exit Sub
        If Not IsNumeric(txtAudioDitherHC(Index).Text) Then Exit Sub
        RealTimeChange()
        Output.Send("/Synth/SetHighCut/" & TStr(Index), CSng(Val(txtAudioDitherHC(Index).Text)))
    End Sub

    Private Sub txtAudioDitherLC_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtAudioDitherLC.TextChanged
        If Me.IsInitializing = True Then Return
        If Not mblnOutputStable Then Return
        If mblnPreventControl Then Return
        Dim Index As Short = txtAudioDitherLC.GetIndex(DirectCast(eventSender, TextBox))
        If Len(txtAudioDitherLC(Index).Text) = 0 Then Return
        If Not IsNumeric(txtAudioDitherLC(Index).Text) Then Return
        RealTimeChange()
        Output.Send("/Synth/SetLowCut/" & TStr(Index), CSng(Val(txtAudioDitherLC(Index).Text)))
    End Sub

    Private Sub txtAudioDitherPar1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtAudioDitherPar1.TextChanged
        If Me.IsInitializing = True Then Return
        If Not mblnOutputStable Then Return
        If mblnPreventControl Then Return
        Dim Index As Short = txtAudioDitherPar1.GetIndex(DirectCast(eventSender, TextBox))
        If Len(txtAudioDitherPar1(Index).Text) = 0 Then Return
        If Not IsNumeric(txtAudioDitherPar1(Index).Text) Then Return
        RealTimeChange()
        Output.Send("/Synth/SetPar1/" & TStr(Index), CSng(Val(txtAudioDitherPar1(Index).Text)))
    End Sub

    Private Sub txtConstValue_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtConstValue.Enter
        Index = txtConstValue.GetIndex(DirectCast(eventSender, TextBox))
        miConstValueIndex = Index
    End Sub

    Private Sub txtConstValue_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtConstValue.Leave
        'Dim Index As Short = txtConstValue.GetIndex(eventSender)
        'Dim szErr As String
        If Index <> miConstValueIndex Then Exit Sub ' lost focus without got focus !?
        ' get data
        'szErr = CheckConstant(txtConstValue(Index).Text, gconstExp(Index))
        '' display error msg
        'If Len(szErr) <> 0 Then
        '    ' error found
        '    MsgBoxOnTop(szErr, MsgBoxStyle.Critical, gconstExp(Index).szName)
        '    Exit Sub
        'End If

        If Not IsNothing(glOnSettingsChangeAddr) Then glOnSettingsChangeAddr(mlExpType)

    End Sub

    Private Sub txtDataDir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDataDir.KeyDown
        If ((e.KeyData And Keys.Control) <> 0) And (e.KeyCode = Keys.A) Then
            txtDataDir.SelectionStart = 0
            txtDataDir.SelectionLength = Len(txtDataDir.Text)
        End If
    End Sub

    Private Sub txtDataDir_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtDataDir.TextChanged
        If Me.IsInitializing = True Then Return
        'Debug.Print(TStr(txtDataDir.Text.Length))
        'remove possible "\" at ending
        If txtDataDir.Text.Length > 0 AndAlso txtDataDir.Text(txtDataDir.Text.Length - 1) = "\" Then
            mszDataDir(cmbDataDir.SelectedIndex) = Strings.Left(txtDataDir.Text, Len(txtDataDir.Text) - Len("\"))
        Else
            mszDataDir(cmbDataDir.SelectedIndex) = txtDataDir.Text
        End If

    End Sub

    Private Sub txtDescription_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtDescription.Enter
        VB6.SetDefault(cmdOK, False)
    End Sub

    Private Sub txtDescription_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtDescription.Leave
        VB6.SetDefault(cmdOK, True)
    End Sub

    Private Sub txtDescription_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtDescription.KeyDown
        If ((eventArgs.KeyData And Keys.Control) <> 0) And (eventArgs.KeyCode = Keys.A) Then
            txtDescription.SelectionStart = 0
            txtDescription.SelectionLength = Len(txtDescription.Text)
        End If
    End Sub

    Private Sub txtFadeIn_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFadeIn.Leave
        Dim lX As Integer
        lX = CheckValidText(txtFadeIn, 0)
    End Sub

    Private Sub txtFadeOut_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFadeOut.Leave
        Dim lX As Integer
        lX = CheckValidText(txtFadeOut, 0)
    End Sub

    Private Sub txtPhDurL_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPhDurL.TextChanged
        If Me.IsInitializing = True Then Return
        Dim sX, sSR As Double
        Dim lX As Integer
        Try
            sX = Val(txtPhDurL.Text)
        Catch ex As System.OverflowException
            lblPhDurL.Text = "OV" & vbCrLf & "Err"
            Return
        End Try
        If mStimOutput = STIM.GENMODE.genAcoustical Or mStimOutput = STIM.GENMODE.genAcousticalUnity Then
            sSR = Val((txtSamplingRate.Text))
            If sSR > 0 Then
                Try
                    lX = CInt(Math.Round(sX * (sSR / 1000000)))
                Catch ex As System.OverflowException
                    lblPhDurL.Text = "OV" & vbCrLf & "Err"
                    Return
                End Try
                If lX < 1 Then
                    lblPhDurL.Text = TStr(lX) & vbCrLf & "Err"
                Else
                    lblPhDurL.Text = TStr(lX) & vbCrLf & TStr(Math.Round(1000000 * CSng(lX / sSR), 1))
                End If
            Else
                lblPhDurL.Text = "-" & vbCrLf & "-"
            End If
        Else
            If F4FL.ImpType <> Implant.IMPLANTTYPE.imptInvalid Then ' check only if fitting is valid
                sSR = 1000000 / F4FL.TimeBase
                If sSR > 0 Then
                    lX = CInt(Math.Round(sX * (sSR / 1000000)))
                    If lX < 16 Then
                        lblPhDurL.Text = TStr(lX) & vbCrLf & "Err"
                    Else
                        lblPhDurL.Text = TStr(lX) & vbCrLf & TStr(Math.Round(1000000 * CSng(lX / sSR), 1))
                    End If
                Else
                    lblPhDurL.Text = "-" & vbCrLf & "-"
                End If
            Else
                lblPhDurL.Text = "-" & vbCrLf & "-"
            End If
        End If
    End Sub

    Private Sub txtPhDurR_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPhDurR.TextChanged
        If Me.IsInitializing = True Then Return
        Dim sX, sSR As Double
        Dim lX As Integer
        If Not IsNumeric(txtPhDurR.Text) Then
            lblPhDurR.Text = "OV" & vbCrLf & "Err"
            Return
        End If
        Try
            sX = Val(txtPhDurR.Text)
        Catch ex As System.OverflowException
            lblPhDurR.Text = "OV" & vbCrLf & "Err"
            Return
        End Try

        If mStimOutput = STIM.GENMODE.genAcoustical Or mStimOutput = GENMODE.genAcousticalUnity Then
            sSR = Val((txtSamplingRate.Text))
            If sSR > 0 Then
                Try
                    lX = CInt(Math.Round(sX / 1000000 * sSR))
                Catch ex As System.OverflowException
                    lblPhDurR.Text = "OV" & vbCrLf & "Err"
                    Return
                End Try
                If lX < 1 Then
                    lblPhDurR.Text = TStr(lX) & vbCrLf & "Err"
                Else
                    lblPhDurR.Text = TStr(lX) & vbCrLf & TStr(Math.Round(1000000 * CSng(lX / sSR), 1))
                End If
            Else
                lblPhDurR.Text = "-" & vbCrLf & "-"
            End If
        Else
            If F4FR.ImpType <> Implant.IMPLANTTYPE.imptInvalid Then ' check only if fitting is valid
                sSR = 1000000 / F4FR.TimeBase
                If sSR > 0 Then
                    lX = CInt(Math.Round(sX * (sSR / 1000000)))
                    If lX < 16 Then
                        lblPhDurR.Text = TStr(lX) & vbCrLf & "Err"
                    Else
                        lblPhDurR.Text = TStr(lX) & vbCrLf & TStr(Math.Round(1000000 * CSng(lX / sSR), 1))
                    End If
                Else
                    lblPhDurR.Text = "-" & vbCrLf & "-"
                End If
            Else
                lblPhDurR.Text = "-" & vbCrLf & "-"
            End If
        End If
    End Sub

    Private Function CheckValidText(ByVal ctrText As System.Windows.Forms.TextBox, ByVal dblVal As Double) As Double
        If Len(ctrText.Text) = 0 Or Not IsNumeric(ctrText.Text) Then
            MsgBoxOnTop("Insert a valid numeric value.")
            ctrText.Text = TStr(dblVal)
            Return dblVal
        Else
            Return Val((ctrText.Text))
        End If
    End Function

    Private Function CheckValidText(ByVal ctrText As System.Windows.Forms.TextBox, ByVal lVal As Integer) As Integer
        If Len(ctrText.Text) = 0 Or Not IsNumeric(ctrText.Text) Then
            MsgBoxOnTop("Insert a valid integer value.")
            ctrText.Text = TStr(lVal)
            Return lVal
        Else
            Return CInt(Math.Round(Val(ctrText.Text)))
        End If
    End Function

    Private Sub txtResolution_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtResolution.Leave
        Dim lX As Integer
        lX = CheckValidText(txtResolution, 16)
    End Sub

    Private Sub txtSamplingRate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSamplingRate.Leave
        Dim lX As Integer
        lX = CheckValidText(txtSamplingRate, 48000)
        srateAcoustic = CInt(txtSamplingRate.Text)
    End Sub

    ' LEFT signal tab: lostfocus and keyup

    Private Sub txtPhDurL_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPhDurL.Leave
        If mlElectrodeL < 1 Then Exit Sub
        mfreqParL(mlElectrodeL - 1).lPhDur = CheckValidText(txtPhDurL, mfreqParL(mlElectrodeL - 1).lPhDur)
    End Sub

    Private Sub txtPhDurL_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtPhDurL.KeyUp
        Select Case eventArgs.KeyCode
            Case Keys.PageDown ' next channel
                If cmbElL.SelectedIndex + 1 <> cmbElL.Items.Count Then txtPhDurL_Leave(txtPhDurL, New System.EventArgs()) : cmbElL.SelectedIndex = cmbElL.SelectedIndex + 1
            Case Keys.PageUp ' prev. channel
                If cmbElL.SelectedIndex > 0 Then txtPhDurL_Leave(txtPhDurL, New System.EventArgs()) : cmbElL.SelectedIndex = cmbElL.SelectedIndex - 1
        End Select
    End Sub

    Private Sub txtSPLOffsetL_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSPLOffsetL.Leave
        If mlElectrodeL < 1 Then Exit Sub
        mfreqParL(mlElectrodeL - 1).sSPLOffset = CheckValidText(txtSPLOffsetL, mfreqParL(mlElectrodeL - 1).sSPLOffset)
    End Sub

    Private Sub txtSPLOffsetL_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtSPLOffsetL.KeyUp
        Select Case eventArgs.KeyCode
            Case Keys.PageDown ' next channel
                If cmbElL.SelectedIndex + 1 <> cmbElL.Items.Count Then txtSPLOffsetL_Leave(txtSPLOffsetL, New System.EventArgs()) : cmbElL.SelectedIndex = cmbElL.SelectedIndex + 1
            Case Keys.PageUp ' prev. channel
                If cmbElL.SelectedIndex > 0 Then txtSPLOffsetL_Leave(txtSPLOffsetL, New System.EventArgs()) : cmbElL.SelectedIndex = cmbElL.SelectedIndex - 1
        End Select
    End Sub

    Private Sub txtAmpL_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtAmpL.Leave
        If mlElectrodeL < 1 Then Exit Sub
        mfreqParL(mlElectrodeL - 1).sAmp = CheckValidText(txtAmpL, mfreqParL(mlElectrodeL - 1).sAmp)
    End Sub

    Private Sub txtAmpL_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtAmpL.KeyUp
        Select Case eventArgs.KeyCode
            Case Keys.PageDown ' next channel
                If cmbElL.SelectedIndex + 1 <> cmbElL.Items.Count Then txtAmpL_Leave(txtAmpL, New System.EventArgs()) : cmbElL.SelectedIndex = cmbElL.SelectedIndex + 1
            Case Keys.PageUp ' prev. channel
                If cmbElL.SelectedIndex > 0 Then txtAmpL_Leave(txtAmpL, New System.EventArgs()) : cmbElL.SelectedIndex = cmbElL.SelectedIndex - 1
        End Select
    End Sub

    Private Sub txtCenterFreqL_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCenterFreqL.Leave
        If mlElectrodeL < 1 Then Exit Sub
        mfreqParL(mlElectrodeL - 1).sCenterFreq = CheckValidText(txtCenterFreqL, mfreqParL(mlElectrodeL - 1).sCenterFreq)
    End Sub

    Private Sub txtCenterFreqL_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtCenterFreqL.KeyUp
        Select Case eventArgs.KeyCode
            Case Keys.PageDown ' next channel
                If cmbElL.SelectedIndex + 1 <> cmbElL.Items.Count Then txtCenterFreqL_Leave(txtCenterFreqL, New System.EventArgs()) : cmbElL.SelectedIndex = cmbElL.SelectedIndex + 1
            Case Keys.PageUp ' prev. channel
                If cmbElL.SelectedIndex > 0 Then txtCenterFreqL_Leave(txtCenterFreqL, New System.EventArgs()) : cmbElL.SelectedIndex = cmbElL.SelectedIndex - 1
        End Select
    End Sub

    Private Sub txtBandwidthL_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBandwidthL.Leave
        If mlElectrodeL < 1 Then Exit Sub
        mfreqParL(mlElectrodeL - 1).sBandwidth = CheckValidText(txtBandwidthL, mfreqParL(mlElectrodeL - 1).sBandwidth)
    End Sub

    Private Sub txtBandwidthL_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtBandwidthL.KeyUp
        Select Case eventArgs.KeyCode
            Case Keys.PageDown ' next channel
                If cmbElL.SelectedIndex + 1 <> cmbElL.Items.Count Then txtBandwidthL_Leave(txtBandwidthL, New System.EventArgs()) : cmbElL.SelectedIndex = cmbElL.SelectedIndex + 1
            Case Keys.PageUp ' prev. channel
                If cmbElL.SelectedIndex > 0 Then txtBandwidthL_Leave(txtBandwidthL, New System.EventArgs()) : cmbElL.SelectedIndex = cmbElL.SelectedIndex - 1
        End Select
    End Sub

    Private Sub txtTHRL_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTHRL.Leave
        If mlElectrodeL < 1 Then Exit Sub
        mfreqParL(mlElectrodeL - 1).sTHR = CheckValidText(txtTHRL, mfreqParL(mlElectrodeL - 1).sTHR)
    End Sub

    Private Sub txtTHRL_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtTHRL.KeyUp
        Select Case eventArgs.KeyCode
            Case Keys.PageDown ' next channel
                If cmbElL.SelectedIndex + 1 <> cmbElL.Items.Count Then txtTHRL_Leave(txtTHRL, New System.EventArgs()) : cmbElL.SelectedIndex = cmbElL.SelectedIndex + 1
            Case Keys.Up ' prev. channel
                If cmbElL.SelectedIndex > 0 Then txtTHRL_Leave(txtTHRL, New System.EventArgs()) : cmbElL.SelectedIndex = cmbElL.SelectedIndex - 1
        End Select
    End Sub

    Private Sub txtMCLL_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMCLL.Leave
        If mlElectrodeL < 1 Then Exit Sub
        mfreqParL(mlElectrodeL - 1).sMCL = CheckValidText(txtMCLL, mfreqParL(mlElectrodeL - 1).sMCL)
    End Sub

    Private Sub txtMCLL_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtMCLL.KeyUp
        Select Case eventArgs.KeyCode
            Case Keys.PageDown ' next channel
                If cmbElL.SelectedIndex + 1 <> cmbElL.Items.Count Then txtMCLL_Leave(txtMCLL, New System.EventArgs()) : cmbElL.SelectedIndex = cmbElL.SelectedIndex + 1
            Case Keys.PageUp ' prev. channel
                If cmbElL.SelectedIndex > 0 Then txtMCLL_Leave(txtMCLL, New System.EventArgs()) : cmbElL.SelectedIndex = cmbElL.SelectedIndex - 1
        End Select
    End Sub

    ' RIGHT signal tab: lostfocus and keyup

    Private Sub txtPhDurR_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPhDurR.Leave
        If mlElectrodeR < 1 Then Exit Sub
        mfreqParR(mlElectrodeR - 1).lPhDur = CheckValidText(txtPhDurR, mfreqParR(mlElectrodeR - 1).lPhDur)
    End Sub

    Private Sub txtPhDurR_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtPhDurR.KeyUp
        Select Case eventArgs.KeyCode
            Case Keys.PageDown ' next channel
                If cmbElR.SelectedIndex + 1 <> cmbElR.Items.Count Then txtPhDurR_Leave(txtPhDurR, New System.EventArgs()) : cmbElR.SelectedIndex = cmbElR.SelectedIndex + 1
            Case Keys.PageUp ' prev. channel
                If cmbElR.SelectedIndex > 0 Then txtPhDurR_Leave(txtPhDurR, New System.EventArgs()) : cmbElR.SelectedIndex = cmbElR.SelectedIndex - 1
        End Select
    End Sub

    Private Sub txtSPLOffsetR_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSPLOffsetR.Leave
        If mlElectrodeR < 1 Then Exit Sub
        mfreqParR(mlElectrodeR - 1).sSPLOffset = CheckValidText(txtSPLOffsetR, mfreqParR(mlElectrodeR - 1).sSPLOffset)
    End Sub

    Private Sub txtSPLOffsetR_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtSPLOffsetR.KeyUp
        Select Case eventArgs.KeyCode
            Case Keys.PageDown ' next channel
                If cmbElR.SelectedIndex + 1 <> cmbElR.Items.Count Then txtSPLOffsetR_Leave(txtSPLOffsetR, New System.EventArgs()) : cmbElR.SelectedIndex = cmbElR.SelectedIndex + 1
            Case Keys.PageUp ' prev. channel
                If cmbElR.SelectedIndex > 0 Then txtSPLOffsetR_Leave(txtSPLOffsetR, New System.EventArgs()) : cmbElR.SelectedIndex = cmbElR.SelectedIndex - 1
        End Select
    End Sub

    Private Sub txtAmpR_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtAmpR.Leave
        If mlElectrodeR < 1 Then Exit Sub
        mfreqParR(mlElectrodeR - 1).sAmp = CheckValidText(txtAmpR, mfreqParR(mlElectrodeR - 1).sAmp)
    End Sub

    Private Sub txtAmpR_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtAmpR.KeyUp
        Select Case eventArgs.KeyCode
            Case Keys.PageDown ' next channel
                If cmbElR.SelectedIndex + 1 <> cmbElR.Items.Count Then txtAmpR_Leave(txtAmpR, New System.EventArgs()) : cmbElR.SelectedIndex = cmbElR.SelectedIndex + 1
            Case Keys.PageUp ' prev. channel
                If cmbElR.SelectedIndex > 0 Then txtAmpR_Leave(txtAmpR, New System.EventArgs()) : cmbElR.SelectedIndex = cmbElR.SelectedIndex - 1
        End Select
    End Sub

    Private Sub txtCenterFreqR_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCenterFreqR.Leave
        If mlElectrodeR < 1 Then Exit Sub
        mfreqParR(mlElectrodeR - 1).sCenterFreq = CheckValidText(txtCenterFreqR, mfreqParR(mlElectrodeR - 1).sCenterFreq)
    End Sub

    Private Sub txtCenterFreqR_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtCenterFreqR.KeyUp
        Select Case eventArgs.KeyCode
            Case Keys.PageDown ' next channel
                If cmbElR.SelectedIndex + 1 <> cmbElR.Items.Count Then txtCenterFreqR_Leave(txtCenterFreqR, New System.EventArgs()) : cmbElR.SelectedIndex = cmbElR.SelectedIndex + 1
            Case Keys.PageUp ' prev. channel
                If cmbElR.SelectedIndex > 0 Then txtCenterFreqR_Leave(txtCenterFreqR, New System.EventArgs()) : cmbElR.SelectedIndex = cmbElR.SelectedIndex - 1
        End Select
    End Sub

    Private Sub txtBandwidthR_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBandwidthR.Leave
        If mlElectrodeR < 1 Then Exit Sub
        mfreqParR(mlElectrodeR - 1).sBandwidth = CheckValidText(txtBandwidthR, mfreqParR(mlElectrodeR - 1).sBandwidth)
    End Sub

    Private Sub txtBandwidthR_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtBandwidthR.KeyUp
        Select Case eventArgs.KeyCode
            Case Keys.PageDown ' next channel
                If cmbElR.SelectedIndex + 1 <> cmbElR.Items.Count Then txtBandwidthR_Leave(txtBandwidthR, New System.EventArgs()) : cmbElR.SelectedIndex = cmbElR.SelectedIndex + 1
            Case Keys.PageUp ' prev. channel
                If cmbElR.SelectedIndex > 0 Then txtBandwidthR_Leave(txtBandwidthR, New System.EventArgs()) : cmbElR.SelectedIndex = cmbElR.SelectedIndex - 1
        End Select
    End Sub

    Private Sub txtTHRR_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTHRR.Leave
        If mlElectrodeR < 1 Then Exit Sub
        mfreqParR(mlElectrodeR - 1).sTHR = CheckValidText(txtTHRR, mfreqParR(mlElectrodeR - 1).sTHR)
    End Sub

    Private Sub txtTHRR_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtTHRR.KeyUp
        Select Case eventArgs.KeyCode
            Case Keys.PageDown ' next channel
                If cmbElR.SelectedIndex + 1 <> cmbElR.Items.Count Then txtTHRR_Leave(txtTHRR, New System.EventArgs()) : cmbElR.SelectedIndex = cmbElR.SelectedIndex + 1
            Case Keys.PageUp ' prev. channel
                If cmbElR.SelectedIndex > 0 Then txtTHRR_Leave(txtTHRR, New System.EventArgs()) : cmbElR.SelectedIndex = cmbElR.SelectedIndex - 1
        End Select
    End Sub

    Private Sub txtMCLR_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMCLR.Leave
        If mlElectrodeR < 1 Then Exit Sub
        mfreqParR(mlElectrodeR - 1).sMCL = CheckValidText(txtMCLR, mfreqParR(mlElectrodeR - 1).sMCL)
    End Sub

    Private Sub txtMCLR_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtMCLR.KeyUp
        Select Case eventArgs.KeyCode
            Case Keys.PageDown ' next channel
                If cmbElR.SelectedIndex + 1 <> cmbElR.Items.Count Then txtMCLR_Leave(txtMCLR, New System.EventArgs()) : cmbElR.SelectedIndex = cmbElR.SelectedIndex + 1
            Case Keys.PageUp ' prev. channel
                If cmbElR.SelectedIndex > 0 Then txtMCLR_Leave(txtMCLR, New System.EventArgs()) : cmbElR.SelectedIndex = cmbElR.SelectedIndex - 1
        End Select
    End Sub


    '----------------------------------------------------------------
    ' Private Functions
    '----------------------------------------------------------------

    Private Sub ArrayToList(ByVal varArr() As String, ByVal lstDest As System.Windows.Forms.ListBox)
        Dim lX As Integer
        lstDest.Items.Clear()
        lstDest.Visible = True
        If Not IsNothing(varArr) Then
            For lX = 0 To varArr.Length - 1
                lstDest.Items.Add(varArr(lX))
            Next
        End If

    End Sub

    Private Sub txtVariables_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVariables.KeyDown
        If ((e.KeyData And Keys.Control) <> 0) And (e.KeyCode = Keys.A) Then
            txtVariables.SelectionStart = 0
            txtVariables.SelectionLength = Len(txtVariables.Text)
        End If
    End Sub

    Private Sub txtVariables_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtVariables.TextChanged
        If Me.IsInitializing = True Then Return
        ToolTip1.SetToolTip(txtVariables, txtVariables.Text)
    End Sub

    Private Sub txtVariables_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtVariables.Enter
        VB6.SetDefault(cmdVariablesAdd, True)
    End Sub

    'Private Sub txtVariables_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtVariables.KeyUp 
    'Select Case eventArgs.KeyCode
    '    Case Keys.PageDown ' next variable
    '        If cmbVariables.SelectedIndex + 1 <> cmbVariables.Items.Count Then cmbVariables.SelectedIndex = cmbVariables.SelectedIndex + 1
    '    Case Keys.PageUp ' prev. variable
    '        If cmbVariables.SelectedIndex > 0 Then cmbVariables.SelectedIndex = cmbVariables.SelectedIndex - 1
    'End Select
    'End Sub

    Private Sub txtVariables_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtVariables.Leave
        VB6.SetDefault(cmdVariablesAdd, False)
        VB6.SetDefault(cmdOK, True)
    End Sub

    Private Sub txtViWoAvgHead_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtViWoAvgHead.Leave
        If Not IsNumeric((txtViWoAvgHead.Text)) Then MsgBoxOnTop("Head Sensor: Average time must be numeric.") : Exit Sub
        Dim sngInt As Double = Val((txtViWoAvgHead.Text))
        sngInt = 2 ^ Math.Round(Log2(sngInt / 1000 * glSamplingRate))
        If txtViWoAvgHead.Text <> TStr(Math.Round(sngInt * 1000 / glSamplingRate)) Then
            MsgBoxOnTop("The average time of the head sensor data must be 2^n (n in N) in samples." & vbCrLf & "New value was set to: " & TStr(Math.Round(sngInt * 1000 / glSamplingRate)) & " ms.")
            txtViWoAvgHead.Text = TStr(Math.Round(sngInt * 1000 / glSamplingRate))
        End If
    End Sub

    Private Sub txtViWoAvgPointer_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtViWoAvgPointer.Leave
        If Not IsNumeric((txtViWoAvgPointer.Text)) Then MsgBoxOnTop("Pointer Sensor: Average time must be numeric.") : Exit Sub
        Dim sngInt As Double = Val((txtViWoAvgPointer.Text))
        sngInt = 2 ^ Math.Round(Log2(sngInt / 1000 * glSamplingRate))
        If txtViWoAvgPointer.Text <> TStr(Math.Round(sngInt * 1000 / glSamplingRate)) Then
            MsgBoxOnTop("The average time of the pointer sensor data must be 2^n (n in N) in samples." & vbCrLf & "New value was set to: " & TStr(Math.Round(sngInt * 1000 / glSamplingRate)) & " ms.")
            txtViWoAvgPointer.Text = TStr(Math.Round(sngInt * 1000 / glSamplingRate))
        End If
    End Sub

    Private Sub txtViWoInteger_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtViWoInteger.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim lX, lY As Integer
            Dim szX As String

            lX = lstViWoParameters.SelectedIndex
            mblnPreventControl = True
            VB6.SetItemString(lstViWoParameters, lX, gviwoparPreview(lX).Name & " *")
            mblnPreventControl = False

            szX = LCase(gviwoparPreview(lX).Name)
            lY = GetUboundViWoTemp()
            For lX = 0 To lY
                If szX = LCase(mviwoparTemp(lX).Name) Then Exit For
            Next
            If lX <= lY Then
                ' parameter found
                mviwoparTemp(lX) = gviwoparPreview(lstViWoParameters.SelectedIndex).Copy
                mviwoparTemp(lX).Value = txtViWoInteger.Text
                mviwoparTemp(lX).Dirty = True
            Else
                ReDim Preserve mviwoparTemp(lY + 1)
                mviwoparTemp(lY + 1) = New ViWoParameter
                mviwoparTemp(lY + 1) = gviwoparPreview(lstViWoParameters.SelectedIndex).Copy
                mviwoparTemp(lY + 1).Dirty = True
                mviwoparTemp(lY + 1).Value = txtViWoInteger.Text
            End If
            ViWoSend()
        End If
    End Sub

    Private Sub txtViWoInteger_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtViWoInteger.Validating
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim lX, lY As Integer
        Dim szX As String

        lX = lstViWoParameters.SelectedIndex
        mblnPreventControl = True
        VB6.SetItemString(lstViWoParameters, lX, gviwoparPreview(lX).Name & " *")
        mblnPreventControl = False

        szX = LCase(gviwoparPreview(lX).Name)
        lY = GetUboundViWoTemp()
        For lX = 0 To lY
            If szX = LCase(mviwoparTemp(lX).Name) Then Exit For
        Next
        If lX <= lY Then
            ' parameter found
            mviwoparTemp(lX) = gviwoparPreview(lstViWoParameters.SelectedIndex).Copy
            mviwoparTemp(lX).Value = txtViWoInteger.Text
            mviwoparTemp(lX).Dirty = True
        Else
            ReDim Preserve mviwoparTemp(lY + 1)
            mviwoparTemp(lY + 1) = New ViWoParameter
            mviwoparTemp(lY + 1) = gviwoparPreview(lstViWoParameters.SelectedIndex).Copy
            mviwoparTemp(lY + 1).Dirty = True
            mviwoparTemp(lY + 1).Value = txtViWoInteger.Text
        End If

        eventArgs.Cancel = Cancel
    End Sub

    Private Sub txtViWoPosition_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtViWoPosition.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim lX, lY As Integer
            Dim szX, szVal As String

            szVal = txtViWoPosition(0).Text & " " & txtViWoPosition(1).Text & " " & txtViWoPosition(2).Text

            lX = lstViWoParameters.SelectedIndex
            mblnPreventControl = True
            VB6.SetItemString(lstViWoParameters, lX, gviwoparPreview(lX).Name & " *")
            mblnPreventControl = False

            szX = LCase(gviwoparPreview(lstViWoParameters.SelectedIndex).Name)
            lY = GetUboundViWoTemp()
            For lX = 0 To lY
                If szX = LCase(mviwoparTemp(lX).Name) Then Exit For
            Next
            If lX <= lY Then
                ' parameter found
                mviwoparTemp(lX) = gviwoparPreview(lstViWoParameters.SelectedIndex).Copy
                mviwoparTemp(lX).Value = szVal
                mviwoparTemp(lX).Dirty = True
            Else
                ReDim Preserve mviwoparTemp(lY + 1)
                mviwoparTemp(lY + 1) = New ViWoParameter
                mviwoparTemp(lY + 1) = gviwoparPreview(lstViWoParameters.SelectedIndex).Copy
                mviwoparTemp(lY + 1).Dirty = True
                mviwoparTemp(lY + 1).Value = szVal
            End If

            ViWoSend()
        End If
    End Sub

    Private Sub txtViWoPosition_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtViWoPosition.Validating
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim Index As Short = txtViWoPosition.GetIndex(DirectCast(eventSender, TextBox))
        Dim lX, lY As Integer
        Dim szX, szVal As String

        szVal = txtViWoPosition(0).Text & " " & txtViWoPosition(1).Text & " " & txtViWoPosition(2).Text

        lX = lstViWoParameters.SelectedIndex
        mblnPreventControl = True
        VB6.SetItemString(lstViWoParameters, lX, gviwoparPreview(lX).Name & " *")
        mblnPreventControl = False

        szX = LCase(gviwoparPreview(lstViWoParameters.SelectedIndex).Name)
        lY = GetUboundViWoTemp()
        For lX = 0 To lY
            If szX = LCase(mviwoparTemp(lX).Name) Then Exit For
        Next
        If lX <= lY Then
            ' parameter found
            mviwoparTemp(lX) = gviwoparPreview(lstViWoParameters.SelectedIndex).Copy
            mviwoparTemp(lX).Value = szVal
            mviwoparTemp(lX).Dirty = True
        Else
            ReDim Preserve mviwoparTemp(lY + 1)
            mviwoparTemp(lY + 1) = New ViWoParameter
            mviwoparTemp(lY + 1) = gviwoparPreview(lstViWoParameters.SelectedIndex).Copy
            mviwoparTemp(lY + 1).Dirty = True
            mviwoparTemp(lY + 1).Value = szVal
        End If

        eventArgs.Cancel = Cancel
    End Sub

    ''' <summary>
    ''' Get value of a parameter.
    ''' </summary>
    ''' <param name="lIdx">Index to a preview parameter.</param>
    ''' <returns>Value of this parameter.</returns>
    ''' <remarks>lIdx is the index to a preview parameter. If a corresponding temporary parameter
    ''' can be found, its value will be returned. Otherwise, the value of the preview parameter, which is
    ''' the default value will be returned.</remarks>
    Private Function GetTempViWoParameter(ByVal lIdx As Integer) As String
        Dim lX, lY As Integer
        Dim szX As String

        szX = LCase(gviwoparPreview(lIdx).Name)
        lY = GetUboundViWoTemp()
        For lX = 0 To lY
            If szX = LCase(mviwoparTemp(lX).Name) Then Exit For
        Next
        If lX <= lY Then
            ' parameter found
            szX = mviwoparTemp(lX).Value
        Else
            szX = gviwoparPreview(lIdx).Value
        End If

        Return szX

    End Function

    ''' <summary>
    ''' Set a temporary parameter value.
    ''' </summary>
    ''' <param name="lIdx">Index to a preview parameter</param>
    ''' <param name="szVal">New value</param>
    ''' <remarks>lIdx is the index to a preview parameter. If a corresponding temporary parameter exists,
    ''' its value will be set to szVal and it will be marked as dirty.
    ''' Otherwise, a new temporary parameter will be created based on the preview parameter. Its new
    ''' value will be szVal, too. The parameter list in the window will be updated to show that a new
    ''' parameter is available now.</remarks>
    Private Sub SetTempViWoParameter(ByVal lIdx As Integer, ByVal szVal As String)
        Dim lX, lY As Integer
        Dim szX As String
        Dim szArr() As String

        szX = LCase(gviwoparPreview(lIdx).Name)
        lY = GetUboundViWoTemp()
        For lX = 0 To lY
            If szX = LCase(mviwoparTemp(lX).Name) Then Exit For
        Next
        If lX <= lY Then
            ' parameter found
            mviwoparTemp(lX).Value = szVal
            mviwoparTemp(lX).Dirty = True
            lY = lX
        Else
            ' not found - copy from preview
            ReDim Preserve mviwoparTemp(lY + 1)
            mviwoparTemp(lY + 1) = New ViWoParameter
            mviwoparTemp(lY + 1) = gviwoparPreview(lIdx).Copy
            mviwoparTemp(lY + 1).Dirty = True
            mviwoparTemp(lY + 1).Value = szVal
            lY += 1
        End If

        VB6.SetItemString(lstViWoParameters, lIdx, gviwoparPreview(lIdx).Name & " *")
        If lstViWoParameters.SelectedIndex = lIdx Then
            Select Case LCase(mviwoparTemp(lY).Type)
                Case "int", "float", "string"
                    txtViWoInteger.Text = szVal
                Case "color"
                    shpViWoColor.BackColor = System.Drawing.ColorTranslator.FromOle(CInt(Val(szVal)))
                Case "position"
                    szArr = Split(szVal, " ")
                    If GetUbound(szArr) >= 0 Then txtViWoPosition(0).Text = szArr(0) Else txtViWoPosition(0).Text = "0"
                    If GetUbound(szArr) >= 1 Then txtViWoPosition(1).Text = szArr(1) Else txtViWoPosition(1).Text = "0"
                    If GetUbound(szArr) >= 2 Then txtViWoPosition(2).Text = szArr(2) Else txtViWoPosition(2).Text = "0"
                Case "4param"
                    szArr = Split(szVal, " ")
                    If GetUbound(szArr) >= 0 Then txtViWoPar(0).Text = szArr(0) Else txtViWoPar(0).Text = "0"
                    If GetUbound(szArr) >= 1 Then txtViWoPar(1).Text = szArr(1) Else txtViWoPar(1).Text = "0"
                    If GetUbound(szArr) >= 2 Then txtViWoPar(2).Text = szArr(2) Else txtViWoPar(2).Text = "0"
                    If GetUbound(szArr) >= 3 Then txtViWoPar(3).Text = szArr(3) Else txtViWoPar(3).Text = "0"
                    'If GetUbound(szArr) >= 0 Then _txtViWoPar_1.Text = szArr(0) Else _txtViWoPar_1.Text = "0"
                    'If GetUbound(szArr) >= 1 Then _txtViWoPar_2.Text = szArr(1) Else _txtViWoPar_2.Text = "0"
                    'If GetUbound(szArr) >= 2 Then _txtViWoPar_3.Text = szArr(2) Else _txtViWoPar_3.Text = "0"
                    'If GetUbound(szArr) >= 3 Then _txtViWoPar_4.Text = szArr(3) Else _txtViWoPar_4.Text = "0"
            End Select
        Else
            lstViWoParameters.SelectedIndex = lIdx
        End If

        If gblnViWoLoaded Then
            RealTimeChange()
            ViWo.SendParameter(mviwoparTemp(lY))
        End If

    End Sub

    Private Sub cmdFittEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFittEdit_0.Click, cmdFittEdit_1.Click
        Dim Index As Short
        Select Case DirectCast(sender, Button).Name
            Case "cmdFittEdit_0"
                Index = 0
            Case "cmdFittEdit_1"
                Index = 1
        End Select

        Dim frmX As New frmFitt4Fun With { _
            .FileName = Me.txtSourceDir.Text & IO.Path.DirectorySeparatorChar & Me.txtFittFile(Index).Text, _
            .Ear = CType(Index, Implant.EARTYPE), _
            .GenMode = Me.mStimOutput _
        }
        If Len(Me.txtFittFile(Index).Text) = 0 Then
            ' new fitting file
            frmX.Amplitude = Nothing
            frmX.Mode = frmFitt4Fun.Fitt4FunMode.NewFittingFile
            frmX.ShowDialog()
            If frmX.Mode = frmFitt4Fun.Fitt4FunMode.FittingUpdated Then
                Me.txtFittFile(Index).Text = IO.Path.GetFileName(frmX.FileName)
                Me.cmdFittReload_Click(cmdFittReload(Index), New EventArgs)
            End If
        Else ' edit fitting file
            ' copy parameters
            If Index = 0 Then
                If Not IsNothing(mfreqParL) Then
                    ReDim frmX.Amplitude(mfreqParL.Length - 1)
                    For lX As Integer = 0 To mfreqParL.Length - 1
                        frmX.Amplitude(lX) = mfreqParL(lX).sAmp
                    Next
                End If
            Else
                If Not IsNothing(mfreqParR) Then
                    ReDim frmX.Amplitude(mfreqParR.Length - 1)
                    For lX As Integer = 0 To mfreqParR.Length - 1
                        frmX.Amplitude(lX) = mfreqParR(lX).sAmp
                    Next
                End If
            End If
            ' edit
            frmX.Mode = frmFitt4Fun.Fitt4FunMode.EditFittingFile
            frmX.ShowDialog()
            Select Case frmX.Mode
                Case frmFitt4Fun.Fitt4FunMode.FittingCancelled

                Case frmFitt4Fun.Fitt4FunMode.FittingUpdated
                    ' update fitting file
                    If frmX.FileName <> "" Then
                        If IO.Path.GetDirectoryName(frmX.FileName) <> Me.txtSourceDir.Text Then
                            MsgBox("The source directory changed. Check the access to the fitting files", MsgBoxStyle.Exclamation)
                        End If
                        Me.txtSourceDir.Text = IO.Path.GetDirectoryName(frmX.FileName)
                        Me.txtFittFile(Index).Text = IO.Path.GetFileName(frmX.FileName)
                        Me.cmdFittReload_Click(cmdFittReload(Index), New EventArgs)
                    Else
                        MsgBox("No parameters passed to application!", MsgBoxStyle.Exclamation)
                    End If
            End Select
            ' update amplitudes in Settings/Signal
            If Not IsNothing(frmX.Amplitude) Then
                For lX As Integer = 0 To frmX.Amplitude.Length - 1
                    If Not Double.IsNaN(frmX.Amplitude(lX)) Then
                        If Index = 0 AndAlso Not IsNothing(mfreqParL) AndAlso mfreqParL.Length > lX Then
                            mfreqParL(lX).sAmp = frmX.Amplitude(lX)
                            If frmX.Amplitude(lX) > mfreqParL(lX).sMCL Then mfreqParL(lX).sAmp = mfreqParL(lX).sMCL
                            If frmX.Amplitude(lX) < mfreqParL(lX).sTHR Then mfreqParL(lX).sAmp = mfreqParL(lX).sTHR
                        ElseIf Not IsNothing(mfreqParR) AndAlso mfreqParR.Length > lX Then
                            mfreqParR(lX).sAmp = frmX.Amplitude(lX)
                            If frmX.Amplitude(lX) > mfreqParR(lX).sMCL Then mfreqParR(lX).sAmp = mfreqParR(lX).sMCL
                            If frmX.Amplitude(lX) < mfreqParR(lX).sTHR Then mfreqParR(lX).sAmp = mfreqParR(lX).sTHR
                        End If
                    End If
                Next
                Me.UpdateSignalTab(CType(Index, Implant.EARTYPE))
            End If
        End If
        frmX.Dispose()
    End Sub

    Private Sub cmdExpShowResponseCodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExpShowResponseCodes.Click
        If mlExpTypeShowed < 0 Then Return

        Dim lB() As Integer = Nothing
        Dim lN, lS As Integer
        Dim szErr As String = frmExp.GetResponseButtons(lB, lS, lN)
        If Len(szErr) > 0 Then MsgBox(szErr) : Return
        Dim frmX As New frmResult
        frmX.Init()
        frmX.ResultList.AddCol("Response Code")
        frmX.ResultList.AddCol("Joypad Button")
        frmX.ResultList.ItemCount = lB.Length + 2
        frmX.ResultList.Item(0, 0) = "Start"
        frmX.ResultList.Item(1, 0) = "Next"
        frmX.ResultList.Item(0, 1) = TStr(lS)
        frmX.ResultList.Item(1, 1) = TStr(lN)
        For lX As Integer = 0 To lB.Length - 1
            frmX.ResultList.Item(lX + 2, 0) = TStr(lX)
            frmX.ResultList.Item(lX + 2, 1) = TStr(lB(lX))
        Next
        szErr = frmExp.GetResponseKeys(lB, lS, lN)
        If Len(szErr) > 0 Then
            MsgBox(szErr)
        Else
            frmX.ResultList.AddCol("Keyboard KeyCode")
            frmX.ResultList.AddCol("Keyboard String")
            frmX.ResultList.Item(0, 2) = TStr(lS)
            frmX.ResultList.Item(1, 2) = TStr(lN)
            Dim kc As KeysConverter = New KeysConverter()
            frmX.ResultList.ItemCount = lB.Length + 2
            frmX.ResultList.Item(0, 3) = kc.ConvertToInvariantString(lS)
            frmX.ResultList.Item(1, 3) = kc.ConvertToInvariantString(lN)
            For lX As Integer = 0 To lB.Length - 1
                frmX.ResultList.Item(lX + 2, 2) = TStr(lB(lX))
                frmX.ResultList.Item(lX + 2, 3) = kc.ConvertToInvariantString(lB(lX))
            Next

        End If
        frmX.Text = "Response Codes for Experiment Type: " & cmbExpType.Items(mlExpTypeShowed).ToString
        frmX.Show()
    End Sub


    Private Sub cmdAudioSynthAllA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAudioSynthAllA.Click
        Dim lX As Integer

        For lX = 0 To glPlayerChannels - 1
            mlAudioDACAddStream(lX) = 1
            VB6.SetItemString(cmbAudioSynthCh, lX, TStr(lX + 1) & " Synth A")
        Next
        mblnPreventControl = True
        optAudioSynthDAC(1).Checked = True
        mblnPreventControl = False
        cmbAudioSynthCh.SelectedIndex = 0

        If Not gblnOutputStable Then Return
        RealTimeChange()
        Output.Send("/DAC/SetAddStream/*", "set", "syn0")
    End Sub

    Private Sub cmdAudioSynthAllB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAudioSynthAllB.Click
        Dim lX As Integer

        For lX = 0 To glPlayerChannels - 1
            mlAudioDACAddStream(lX) = 1
            VB6.SetItemString(cmbAudioSynthCh, lX, TStr(lX + 1) & " Synth B")
        Next

        mblnPreventControl = True
        optAudioSynthDAC(2).Checked = True
        mblnPreventControl = False
        cmbAudioSynthCh.SelectedIndex = 0

        If Not gblnOutputStable Then Return
        RealTimeChange()
        Output.Send("/DAC/SetAddStream/*", "set", "syn1")
    End Sub

    Private Sub txtID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtID.KeyDown
        If ((e.KeyData And Keys.Control) <> 0) And (e.KeyCode = Keys.A) Then
            txtID.SelectionStart = 0
            txtID.SelectionLength = Len(txtID.Text)
        End If
    End Sub

    Private Sub txtDestinationDir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDestinationDir.KeyDown
        If ((e.KeyData And Keys.Control) <> 0) And (e.KeyCode = Keys.A) Then
            txtDestinationDir.SelectionStart = 0
            txtDestinationDir.SelectionLength = Len(txtDestinationDir.Text)
        End If
    End Sub

    Private Sub txtSourceDir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSourceDir.KeyDown
        If ((e.KeyData And Keys.Control) <> 0) And (e.KeyCode = Keys.A) Then
            txtSourceDir.SelectionStart = 0
            txtSourceDir.SelectionLength = Len(txtSourceDir.Text)
        End If
    End Sub

    Private Sub cmbDuplicate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDuplicate.Click
        Dim lX As Integer
        Dim varX As String
        Dim szErr As String

        lX = cmbVariables.SelectedIndex
        If lstVariables(CShort(lX)).SelectedIndex = -1 Then ShowVariablesIndex(lX) : Exit Sub 'no item selected -> exit
        ' get data
        varX = lstVariables(CShort(cmbVariables.SelectedIndex)).Text
        szErr = CheckVariable(varX, gvarExp(lX), mfreqParL, mfreqParR)
        If Len(szErr) <> 0 Then
            MsgBoxOnTop(szErr, MsgBoxStyle.Critical, "Invalid Input")
            Return
        End If
        ' insert copy
        lstVariables(CShort(lX)).Items.Insert(lstVariables(CShort(cmbVariables.SelectedIndex)).SelectedIndex + 1, varX)

        ShowVariablesIndex(lX)
        If Not IsNothing(glOnSettingsChangeAddr) Then glOnSettingsChangeAddr(mlExpType)
    End Sub

    Private Sub lblRealTime_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblRealTime.DoubleClick
        If mblnPreventControl Then Return
        lblRealTime.Visible = True
        lblRealTime.ForeColor = Drawing.Color.Red

        MsgBoxOnTop("You changed the value of a real-time parameter." & vbCrLf & vbCrLf & "Why do I bother you with this information?" & vbCrLf & vbCrLf & "Changes of these parameters will be sent to the proper device immediatly." & vbCrLf & "Later, if you cancel the Settings window, these changes will be ignored." & vbCrLf & "The old parameters of the device will be NOT restored !!!!" & vbCrLf & vbCrLf & "This happens to all real-time parameters and is indicated by" & vbCrLf & "a red text line at the bottom of the Settings window.", MsgBoxStyle.Information Or MsgBoxStyle.MsgBoxSetForeground, "Read carefully!")

        tmrRealTime.Enabled = True
    End Sub

    Private Sub txtSourceDir_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSourceDir.TextChanged
        txtSourceDirCopy.Text = txtSourceDir.Text
        With ToolTip1
            .SetToolTip(txtSourceDir, txtSourceDir.Text)
            .SetToolTip(txtSourceDirCopy, txtSourceDirCopy.Text)
        End With
    End Sub

    Private Sub _txtFittFile_0_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _txtFittFile_0.TextChanged
        ToolTip1.SetToolTip(_txtFittFile_0, _txtFittFile_0.Text)
    End Sub

    Private Sub _txtFittFile_1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _txtFittFile_1.TextChanged
        ToolTip1.SetToolTip(_txtFittFile_1, _txtFittFile_1.Text)
    End Sub

    Private Sub cmdExpSetDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExpSetDefault.Click
        Dim lT, lH, lW, lL As Integer

        txtExpHeight.Text = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height.ToString
        txtExpWidth.Text = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width.ToString
        txtExpTop.Text = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Top.ToString
        txtExpLeft.Text = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Left.ToString

        lH = CInt(Val((txtExpHeight.Text)))
        lW = CInt(Val((txtExpWidth.Text)))
        lT = CInt(Val((txtExpTop.Text)))
        lL = CInt(Val((txtExpLeft.Text)))
        frmExp.SetSize(lL, lW, lT, lH)

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles cmdExpSetSmall.Click
        Dim lT, lH, lW, lL As Integer

        With System.Windows.Forms.Screen.PrimaryScreen.Bounds
            If txtExpHeight.Text = "480" And txtExpWidth.Text = "640" And txtExpTop.Text = .Top.ToString Then
                If txtExpLeft.Text = .Left.ToString Then
                    txtExpLeft.Text = TStr(.Left + 2 * .Width - 640)
                ElseIf txtExpLeft.Text = TStr(.Left + 2 * .Width - 640) Then
                    txtExpLeft.Text = TStr(.Left + .Width)
                ElseIf txtExpLeft.Text = TStr(.Left + .Width) Then
                    txtExpLeft.Text = TStr(.Left + .Width - 640)
                Else
                    txtExpLeft.Text = .Left.ToString
                End If

            Else
                txtExpHeight.Text = "480"
                txtExpWidth.Text = "640"
                txtExpTop.Text = .Top.ToString
                txtExpLeft.Text = .Left.ToString
            End If
        End With

        lH = CInt(Val((txtExpHeight.Text)))
        lW = CInt(Val((txtExpWidth.Text)))
        lT = CInt(Val((txtExpTop.Text)))
        lL = CInt(Val((txtExpLeft.Text)))
        frmExp.SetSize(lL, lW, lT, lH)

    End Sub

    Private Sub cmdAnalysisSetting_Click(sender As System.Object, e As System.EventArgs) Handles cmdAnalysisSetting.Click
        If txtDestinationDir.Text.Length > 0 Then My.Computer.Clipboard.SetText(txtDestinationDir.Text)
        txtDestinationDir.Text = gszCurrentDir
        chkTempDir.CheckState = CheckState.Unchecked
        chkNewWorkDir.CheckState = CheckState.Unchecked
        chkSilentMode.CheckState = CheckState.Checked
        chkTTUse.CheckState = CheckState.Unchecked
        chkDoNotConnectToDevice.CheckState = CheckState.Checked
        chkTrackerUse.CheckState = CheckState.Unchecked

        If InStr(LCase(gszSettingTitle), "analysis") = 0 Then ' append "Analysis" to settings file name
            If InStr(gszSettingTitle, "." & My.Application.Info.AssemblyName) > 0 Then 'with application extension
                gszSettingTitle = Replace(gszSettingTitle, "." & My.Application.Info.AssemblyName, " Analysis." & My.Application.Info.AssemblyName)
            Else 'without application extension
                gszSettingTitle &= " Analysis"
            End If
        End If


    End Sub

    Private Sub txtViWoPar_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtViWoPar.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim lX, lY As Integer
            Dim szX, szVal As String

            szVal = txtViWoPar(0).Text & " " & txtViWoPar(1).Text & " " & txtViWoPar(2).Text & " " & txtViWoPar(3).Text

            lX = lstViWoParameters.SelectedIndex
            mblnPreventControl = True
            VB6.SetItemString(lstViWoParameters, lX, gviwoparPreview(lX).Name & " *")
            mblnPreventControl = False

            szX = LCase(gviwoparPreview(lstViWoParameters.SelectedIndex).Name)
            lY = GetUboundViWoTemp()
            For lX = 0 To lY
                If szX = LCase(mviwoparTemp(lX).Name) Then Exit For
            Next
            If lX <= lY Then
                ' parameter found
                mviwoparTemp(lX) = gviwoparPreview(lstViWoParameters.SelectedIndex).Copy
                mviwoparTemp(lX).Value = szVal
                mviwoparTemp(lX).Dirty = True
            Else
                ReDim Preserve mviwoparTemp(lY + 1)
                mviwoparTemp(lY + 1) = New ViWoParameter
                mviwoparTemp(lY + 1) = gviwoparPreview(lstViWoParameters.SelectedIndex).Copy
                mviwoparTemp(lY + 1).Dirty = True
                mviwoparTemp(lY + 1).Value = szVal
            End If
            ViWoSend()
        End If
    End Sub

    Private Sub txtViWoPar_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtViWoPar.Validating
        'Private Sub txtViWoPar_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtViWoPar.Validating
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim Index As Short = txtViWoPar.GetIndex(DirectCast(eventSender, TextBox))
        Dim lX, lY As Integer
        Dim szX, szVal As String

        szVal = txtViWoPar(0).Text & " " & txtViWoPar(1).Text & " " & txtViWoPar(2).Text & " " & txtViWoPar(3).Text

        lX = lstViWoParameters.SelectedIndex
        mblnPreventControl = True
        VB6.SetItemString(lstViWoParameters, lX, gviwoparPreview(lX).Name & " *")
        mblnPreventControl = False

        szX = LCase(gviwoparPreview(lstViWoParameters.SelectedIndex).Name)
        lY = GetUboundViWoTemp()
        For lX = 0 To lY
            If szX = LCase(mviwoparTemp(lX).Name) Then Exit For
        Next
        If lX <= lY Then
            ' parameter found
            mviwoparTemp(lX) = gviwoparPreview(lstViWoParameters.SelectedIndex).Copy
            mviwoparTemp(lX).Value = szVal
            mviwoparTemp(lX).Dirty = True
        Else
            ReDim Preserve mviwoparTemp(lY + 1)
            mviwoparTemp(lY + 1) = New ViWoParameter
            mviwoparTemp(lY + 1) = gviwoparPreview(lstViWoParameters.SelectedIndex).Copy
            mviwoparTemp(lY + 1).Dirty = True
            mviwoparTemp(lY + 1).Value = szVal
        End If

        eventArgs.Cancel = Cancel
    End Sub

    Private Sub ViWoSend()
        If _cmdViWoSendParameters_0.Enabled = True Then
            Dim lX, lY As Integer
            For lX = 0 To GetUboundViWoTemp()
                For lY = 0 To ViWo.GetPreviewParametersCount - 1
                    If gviwoparPreview(lY).Name = mviwoparTemp(lX).Name Then Exit For
                Next
                If lY < ViWo.GetPreviewParametersCount Then
                    ViWo.SendParameter(mviwoparTemp(lX))
                End If
            Next
            RealTimeChange()

        End If
    End Sub

    Private Sub tabChannels_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabChannels.Enter
        If mStimOutput = GENMODE.genElectricalRIB Or mStimOutput = GENMODE.genElectricalRIB2 Or mStimOutput = GENMODE.genElectricalRIB2 Or mStimOutput = STIM.GENMODE.genVocoder Then
            'update signal tab
            Me.cmdFittReload_Click(cmdFittReload(0), New EventArgs)
            Me.cmdFittReload_Click(cmdFittReload(1), New EventArgs)
        End If
    End Sub

    Private Sub chkOverrideExpMode_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOverrideExpMode.CheckedChanged
        OexpMode.Enabled = chkOverrideExpMode.Checked
        If chkOverrideExpMode.Checked Then
            OexpMode.Font = New Font(OexpMode.Font.FontFamily, OexpMode.Font.Size, FontStyle.Bold)
        Else
            OexpMode.Font = New Font(OexpMode.Font.FontFamily, OexpMode.Font.Size, FontStyle.Regular)
        End If
    End Sub


    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles GetVoc.CheckedChanged
        If GetVoc.Checked = True Then
            Me.GetVoc.Checked = True
            GetVoc.Checked = True
            VocType(2) = 1
        ElseIf GetVoc.Checked = False Then
            Me.GetVoc.Checked = False
            GetVoc.Checked = False
            VocType(2) = 0
        End If

    End Sub

    Private Sub NoiseVoc_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles NoiseVoc.CheckedChanged
        If NoiseVoc.Checked = True Then
            Me.NoiseVoc.Checked = True
            NoiseVoc.Checked = True
            VocType(1) = 1
        ElseIf NoiseVoc.Checked = False Then
            Me.NoiseVoc.Checked = False
            NoiseVoc.Checked = False
            VocType(1) = 0
        End If
    End Sub

    Private Sub divFactor_TextChanged(sender As System.Object, e As System.EventArgs)
        divFactor = CDbl(facScalelbl.Text)
    End Sub

End Class
