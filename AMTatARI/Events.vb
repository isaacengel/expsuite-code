Option Strict On
Option Explicit On
#Region "ExpSuite License"
'ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
'Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Michael Mihocic and Piotr Majdak
'Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
'You may not use this work except in compliance with the Licence. 
'You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
'Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
'See the Licence for the specific language governing  permissions and limitations under the Licence. 
#End Region
Module Events

    Sub OnLoad()
        Dim lX As Integer

        ' Type 0
        gszExpTypeNames(0) = "Maximum Length Sequence (MLS)"
        glExpAFC(0) = 0
        glExpIFC(0) = 0
        glExpMode(0) = 0
        gszExpResponseNames(0) = "Button 1;Button 2" ' splitted with semicolon
        gszExpRequestText(0) = ""

        ' Type 1
        gszExpTypeNames(1) = "Multiple Exponential Sweeps"
        glExpAFC(1) = 0
        glExpIFC(1) = 0
        glExpMode(1) = 0
        gszExpResponseNames(1) = "Button 1" ' splitted with semicolon
        gszExpRequestText(1) = ""

        ' Type 2
        gszExpTypeNames(2) = "Cosine Oscillation"
        glExpAFC(2) = 0
        glExpIFC(2) = 0
        glExpMode(2) = 0
        gszExpResponseNames(2) = "Button 1" ' splitted with semicolon
        gszExpRequestText(2) = ""

        ' Type 3
        gszExpTypeNames(3) = "HRTF-Measurement"
        glExpAFC(3) = 0
        glExpIFC(3) = 0
        glExpMode(3) = 0
        gszExpResponseNames(3) = "Button 1" ' splitted with semicolon
        gszExpRequestText(3) = ""

        ' ITEM LIST
        ' description of columns, separate items with semicolons
        'FLGTEXT = "Index;Azimuth;Channel ID;Freq;Amp;Status;Description"
        ItemList.Reset()
        ItemList.AddCol("Index", clsItemList.ItemListFlags.ifIndex)
        ItemList.AddCol("Azimuth", clsItemList.ItemListFlags.ifNumeric Or clsItemList.ItemListFlags.ifMin Or clsItemList.ItemListFlags.ifMax, "deg", 0,357.5)
        ItemList.AddCol("Channel ID", clsItemList.ItemListFlags.ifString)
        ItemList.AddCol("Freq", clsItemList.ItemListFlags.ifNumeric Or clsItemList.ItemListFlags.ifMin, "Hz", 0)
        ItemList.AddCol("Amp", clsItemList.ItemListFlags.ifNumeric, "dBFS")
        ItemList.AddCol("Status", clsItemList.ItemListFlags.ifString)
        ItemList.AddCol("Description", clsItemList.ItemListFlags.ifString)

        ' Result Menu
        frmMain.SetResultList("Plot Records;Impulse Response Toolbox;Post Processing Toolbox")

        ' define constants
        ReDim gconstExp(13) ' NOTE: gconstExp size defined here
        With gconstExp(0)
            .szName = "Tracker: In Range Period"
            .szDescription = "Sets the minimal period, in which the tracker sensor must remain in range."
            .szUnit = "ms"
            .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfMin Or FWintern.VariableFlags.vfMax
            .varDefault = "500"
            .dMin = 0
            .dMax = 10000
        End With
        With gconstExp(1)
            .szName = "Stimulus Length"
            .szDescription = "Sets the length of stimulus."
            .szUnit = "ms"
            .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfMin Or FWintern.VariableFlags.vfDisabled
            .dMin = 1
            .varDefault = "2"
        End With
        With gconstExp(2)
            .szName = "MLS Order"
            .szDescription = "Sets the order of the MLS."
            .szUnit = ""
            .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfMin Or FWintern.VariableFlags.vfInteger Or FWintern.VariableFlags.vfMax
            .dMin = 10
            .dMax = 18
            .varDefault = "14"
        End With
        With gconstExp(3)
            .szName = "MLS Repetition"
            .szDescription = "Sets the number of repetitions of the MLS."
            .szUnit = ""
            .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfMin Or FWintern.VariableFlags.vfInteger Or FWintern.VariableFlags.vfMax
            .dMin = 1
            .dMax = 10
            .varDefault = "3"
        End With
        For lX = 4 To 10
            With gconstExp(lX)
                .szName = "not used"
                .szDescription = ""
                .szUnit = ""
                .Flags = FWintern.VariableFlags.vfHidden
                .varDefault = "0"
            End With
        Next



        ' Define Variables
        ReDim gvarExp(5)
        With gvarExp(0)
            .szName = "Channel ID"
            .szDescription = "List of channels used in the measurement. Each ID must match a channel ID specified in the Signal tab."
            .szUnit = ""
            .Flags = FWintern.VariableFlags.vfNumeric
            .dMin = 1
            .szDefault = "1;2"
        End With

        With gvarExp(1)
            .szName = "Azimuth"
            .szDescription = "Sets the azimuth angle of the turntable. Leave blank if you don't want to use turntable"
            .Flags = VariableFlags.vfNumeric Or VariableFlags.vfMin Or VariableFlags.vfMax
            .dMin = 0
            .dMax = 357.5
            .szDefault = ""
            .szUnit = "deg"
        End With

        With gvarExp(2)
            .szName = "Record stream"
            .szDescription = "Sets the stream to record:" & vbCrLf & "adcX: data from ADC, channel X" & vbCrLf & "synX: data from synthesizer unit X" & vbCrLf & "playX: data from WAV file, unit X" & vbCrLf & "silence: zero stream (no data)"
            .szUnit = "adc0;adc1;adc2;adc3;adc4;adc5;adc6;adc7;adc8;adc9;adc10;adc11;adc12;adc13;adc14;adc15;syn0;syn1;play0;play1;silence"
            .szUnit = "adc0;adc1;adc2;adc3;adc4;adc5;adc6;adc7;adc8;adc9;adc10;adc11;adc12;adc13;adc14;adc15;syn0;syn1;play0;play1;sum6;silence"
            .Flags = FWintern.VariableFlags.vfEnumeration
            .szDefault = "adc0;adc1"
        End With

        With gvarExp(3)
            .szName = "Amplitude"
            .szDescription = "Sets the global signal amplitude, additional to the channel amplitudes set in Signal tab:" & vbCrLf & "0: full scale" & vbCrLf & "-100: no signal"
            .szUnit = "dBFS"
            .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfMin
            .dMin = -100
            '.dMax = 10
            .szDefault = "-18"
        End With
        With gvarExp(4)
            .szName = "Frequency"
            .szDescription = "Sets the frequency of sinus tone in 'Cosine' mode and the frequency of the warning tone in case of tracker out of range."
            .szUnit = "Hz"
            .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfMin
            .dMin = 0
            .szDefault = "1000"
        End With
        With gvarExp(5)
            .szName = "ISD"
            .szDescription = "Sets the Inter Sweep Distance for each measured channel. Used in ExpSweep/HRTF modes only." & vbCrLf & "For the first channel ISD will be ignored and set internal to 0ms!"
            .szUnit = "ms"
            .Flags = FWintern.VariableFlags.vfDisabled
            .dMin = 0
            .szDefault = "0;150;605;150;605"
        End With

        frmSettings.SetOnSetCallback(AddressOf EventsSettings.OnSet)
        frmSettings.SetOnLoadCallback(AddressOf EventsSettings.OnLoad)
        frmSettings.SetOnChangeCallback(AddressOf EventsSettings.OnChange)
        frmSettings.SetOnExpTypeCallback(AddressOf EventsSettings.OnExpTypeChange)

        With frmMain
            .cmdCreateAllStimuli.Visible = False
            '.cmdItemStimulateAll.Visible = False
        End With

    End Sub

    Sub OnExpShow(ByRef lType As Integer, ByRef rectPos As RECT, Optional ByRef lFlags As frmExp.EXPFLAGS = 0)

        Return

    End Sub

    Function GetChannelFromElevation(ByRef sngE As Double) As Integer
        Dim lX As Integer

        For lX = 0 To GetUbound(gfreqParL)
            If gfreqParL(lX).sAmp = sngE Then
                GetChannelFromElevation = lX + 1 ' channel from 1 to max.
                Exit Function
            End If
        Next
        GetChannelFromElevation = -1 ' channel not found

    End Function

    Function OnCreateItemList() As Integer
        Dim szErr As String = ""
        Dim lErr As Integer ' error handling
        Dim lX, lNr As Integer
        Dim lVal1, lVal2 As Integer
        Dim lVal3, lVal4 As Integer
        Dim blnAzimuth As Boolean
        Dim szX As String
        Dim szArr() As String
        Dim dblArr(,) As Double
        Dim szEnd, szBeg, szRes As String

        With ItemList

            Select Case glExpType
                Case 0, 1, 2
                    If GetUbound(gElevation) = -1 Then
                        szErr = "No Channel IDs defined."
                        GoTo SubError
                    End If
                    If GetUbound(gAmp) = -1 Then
                        szErr = "No amplitudes defined."
                        GoTo SubError
                    End If
                    If GetUbound(gFreq) = -1 Then
                        szErr = "No frequencies defined."
                        GoTo SubError
                    End If

                    If GetUbound(gfreqParL) < 0 Then
                        szErr = "No signals in the Signal Tab specified."
                        GoTo SubError
                    End If
                    For lX = 0 To GetUbound(gElevation)
                        If Not IsNumeric(gElevation(lX)) Then
                            szErr = szErr & "Channel ID must be a valid numeric." & vbCrLf
                        Else
                            lNr = GetChannelFromElevation(Val(gElevation(lX)))
                            If lNr = -1 Then szErr = szErr & "Channel ID specified as '" & (gElevation(lX)) & "' not found in the Signal Tab." & vbCrLf
                        End If
                    Next
                    If Len(szErr) > 0 Then GoTo SubError

                    .Clear()
                    lX = (GetUbound(gAzimuth) + 1)
                    blnAzimuth = (lX > 0)
                    If lX = 0 Then lX = 1
                    Select Case glExpType
                        Case 0
                            .ItemCount = (UBound(gAmp) + 1) * (UBound(gElevation) + 1) * lX
                        Case 1
                            .ItemCount = (UBound(gAmp) + 1) * lX
                        Case 2
                            .ItemCount = (UBound(gAmp) + 1) * (UBound(gElevation) + 1) * lX * (UBound(gFreq) + 1)
                    End Select
                    ' fill with items
                    lX = 0
                    If blnAzimuth Then lNr = GetUbound(gAzimuth) Else lNr = 0
                    For lVal1 = 0 To lNr
                        For lVal3 = 0 To UBound(gAmp)
                            szX = ""
                            For lVal2 = 0 To UBound(gElevation)
                                Select Case glExpType
                                    Case 0 ' MLS
                                        .Item(lX, "INDEX") = TStr(lX + 1)
                                        If blnAzimuth Then .Item(lX, "AZIMUTH") = (gAzimuth(lVal1))
                                        .Item(lX, "CHANNEL ID") = (gElevation(lVal2))
                                        .Item(lX, "AMP") = (gAmp(lVal3))
                                        .Item(lX, "FREQ") = (gFreq(0))
                                        lX = lX + 1
                                    Case 2 ' Cosine Gen.
                                        For lVal4 = 0 To UBound(gFreq)
                                            .Item(lX, "INDEX") = TStr(lX + 1)
                                            If blnAzimuth Then .Item(lX, "AZIMUTH") = (gAzimuth(lVal1))
                                            .Item(lX, "CHANNEL ID") = (gElevation(lVal2))
                                            .Item(lX, "AMP") = (gAmp(lVal3))
                                            .Item(lX, "FREQ") = (gFreq(lVal4))
                                            lX = lX + 1
                                        Next
                                    Case 1 ' Sweep
                                        szX = szX & " " & (gElevation(lVal2))
                                        .Item(lX, "FREQ") = (gFreq(0))
                                End Select
                            Next

                            If glExpType = 1 Then ' only for Sweep
                                .Item(lX, "INDEX") = TStr(lX + 1)
                                If blnAzimuth Then .Item(lX, "AZIMUTH") = (gAzimuth(lVal1))
                                .Item(lX, "CHANNEL ID") = Right(szX, Len(szX) - 1) ' discard first char (;)
                                .Item(lX, "AMP") = (gAmp(lVal3))
                                lX += 1
                            End If

                        Next
                    Next

                Case 3 ' ********* HRTF-Measurement
                    If GetUbound(gAzimuth) = -1 Then szErr = "No azimuths defined." : GoTo SubError
                    If GetUbound(gElevation) = -1 Then szErr = "No elevations defined." : GoTo SubError
                    If GetUbound(gRecStream) = -1 Then szErr = "No record streams defined." : GoTo SubError
                    If GetUbound(gAmp) = -1 Then szErr = "No amplitudes defined." : GoTo SubError
                    If GetUbound(gFreq) = -1 Then szErr = "No frequencies defined." : GoTo SubError
                    If GetUbound(gfreqParL) < 0 Then szErr = "No elevations in the Signal Tab specified." : GoTo SubError
                    For lX = 0 To GetUbound(gElevation)
                        If Not IsNumeric(gElevation(lX)) Then
                            szErr = szErr & "Elevation must be a valid numeric." & vbCrLf
                        Else
                            lNr = GetChannelFromElevation(Val(gElevation(lX)))
                            If lNr = -1 Then szErr = szErr & "Elevation specified as '" & (gElevation(lX)) & "' not found." & vbCrLf
                        End If
                    Next
                    If Len(szErr) > 0 Then GoTo SubError
                    If Not gblnOutputStable Then szErr = "Not connected to MATLAB." : GoTo SubError

                    ' calc the azi x ele matrix
                    szBeg = ""
                    szEnd = ""
                    szRes = ""
                    For lX = 0 To GetUbound(gAzimuth)
                        szArr = Split(Trim(gAzimuth(lX)), " ")
                        If GetUbound(szArr) <> 2 Then szErr = "Invalid azimuth group, input syntax: beg res end" : GoTo SubError
                        szBeg = szBeg & szArr(0) & " "
                        szRes = szRes & szArr(1) & " "
                        szEnd = szEnd & szArr(2) & " "
                    Next
                    szX = "[" & szBeg & "],[" & szRes & "],[" & szEnd & "],["
                    For lX = 0 To GetUbound(gElevation)
                        szX = szX & (gElevation(lX)) & " "
                    Next
                    szErr = STIM.Matlab("mp=AA_CreateHRTFItemList(" & szX & "]);")
                    If Len(szErr) > 0 Then GoTo SubError
                    ' get size of mp
                    szErr = STIM.MatlabGetMatrixSize("mp", lVal1, lVal2)
                    If Len(szErr) > 0 Then GoTo SubError
                    If lVal1 < 1 And lVal2 < 1 Then szErr = "mp is empty." : GoTo SubError
                    ReDim dblArr(lVal1 - 1, lVal2 - 1)
                    szErr = STIM.MatlabGetRealMatrix2("mp", dblArr)
                    If Len(szErr) > 0 Then GoTo SubError

                    ItemList.Clear()
                    ItemList.ItemCount = lVal1
                    lNr = 0
                    ' fill with items
                    For lX = 0 To lVal1 - 1
                        .Item(lX, "AZIMUTH") = TStr(dblArr(lX, 0))
                        .Item(lX, "FREQ") = (gFreq(0))
                        .Item(lX, "AMP") = (gAmp(0))
                        .Item(lX, "INDEX") = TStr(lX + 1)
                        szX = ""
                        lNr = lNr + CInt(Math.Round(dblArr(lX, 1)))
                        For lVal3 = 0 To CInt(Math.Round(dblArr(lX, 1) - 1))
                            szX = szX & TStr(dblArr(lX, lVal3 + 2)) & " "
                        Next
                        .Item(lX, "ELEVATION") = Trim(szX)
                    Next
                    ItemList.SetOptimalColWidth()
                    MsgBox("Number of turntable positions (azimuths): " & TStr(lVal1) & vbCrLf & "Total number of spatial positions: " & TStr(lNr), MsgBoxStyle.Information, "Item List created")

            End Select
            Return 0


SubError:
            If Len(szErr) = 0 Then szErr = TStr(lErr)
            MsgBox(szErr, MsgBoxStyle.Critical, "Create Item List")
            If lErr = 0 Then lErr = 1
            Return lErr
        End With

    End Function

    Function CheckIndices() As String
        Dim szErr As String = ""
        With ItemList
            If .ItemCount < 2 Then Return ""
            For lX As Integer = 0 To .ItemCount - 2
                'item to compare
                For lY As Integer = lX + 1 To .ItemCount - 1
                    'item to be compared
                    If .Item(lX, "INDEX") = .Item(lY, "INDEX") Then
                        szErr = szErr & vbCrLf & "  - Rows numbers: " & TStr(lX + 1) & " and " & TStr(lY + 1) & "   (Index = '" & .Item(lX, "INDEX") & "')"
                    End If

                Next
            Next
        End With
        Return szErr 'contains emty string, or duplicate indices

    End Function

    Function OnStimulateSelected(ByRef lRow As Integer, ByRef lTO As Integer, ByRef szLeft As String, ByRef szRight As String) As String
        Dim lY, lX As Integer
        Dim szX As String
        Dim sAmp, sX, sFreq As Double
        Dim szErr As String = ""
        Dim lCh() As Integer
        Dim szAzimuth As String
        Dim curTimer As Long
        Dim szArr() As String
        Dim DX As Double
        Dim sDel As Double
        Dim tsTrackerMin(1) As TrackerSensor
        Dim tsTrackerMax(1) As TrackerSensor

        ' Check for duplicate indices
        szErr = CheckIndices()
        If szErr <> "" Then
            If MsgBox("Warning: The following indices appear multiple times in the item list and these recordings can be overwritten!" & _
                      vbCrLf & szErr & vbCrLf & vbCrLf & "Do you want to continue anyway?", _
                      MsgBoxStyle.OkCancel Or MsgBoxStyle.Critical, "Duplicate indices found") = MsgBoxResult.Cancel Then gblnCancel = True : Return ""
        End If

        With ItemList
            .ItemIndex = lRow
SubStart:
            'Windows.Forms.Application.DoEvents()
            ' get parameters
            Select Case glExpType
                Case 1 ' Sweep
                    If Len(.Item(lRow, "CHANNEL ID")) = 0 Then szErr = "No Channel ID." : GoTo SubError
                    szArr = Split(.Item(lRow, "Channel ID"), " ")
                    If GetUbound(szArr) < 0 Then szErr = "Channel ID not specified" : GoTo SubError
                    ReDim lCh(GetUbound(szArr))
                    szErr = ""
                    For lX = 0 To GetUbound(szArr)
                        If Not IsNumeric(szArr(lX)) Then
                            szErr = szErr & "Channel ID " & szArr(lX) & " must be a valid numeric." & vbCrLf
                        Else
                            lCh(lX) = GetChannelFromElevation(Val(szArr(lX)))
                            If lCh(lX) < 1 Then
                                szErr = szErr & "Channel ID '" & szArr(lX) & "' is not specified." & vbCrLf
                            ElseIf lCh(lX) > glPlayerChannels Then
                                szErr = szErr & "Channel #" & TStr(lCh(lX)) & " not supported. Device is set in Options to " & TStr(glPlayerChannels) & " channels only." & vbCrLf
                            End If
                            For lY = 0 To lX - 1
                                If lCh(lY) = lCh(lX) Then
                                    szErr = szErr & "Multiple entries for channel ID '" & szArr(lX) & "' found." & vbCrLf
                                    Exit For
                                End If
                            Next
                        End If
                    Next
                    If Len(szErr) > 0 Then GoTo SubError
                    If GetUbound(lCh) > GetUbound(gISD) Then
                        szErr = "More channels than ISDs specified."
                        GoTo SubError
                    End If
                Case 3 ' hrtf
                    If Len(.Item(lRow, "ELEVATION")) = 0 Then szErr = "No elevation." : GoTo SubError
                    If (Len(.Item(lRow, "Freq")) = 0) Or (Not IsNumeric(.Item(lRow, "Freq"))) Then
                        sFreq = 0
                    Else
                        sFreq = Val(.Item(lRow, "FREQ"))
                    End If
                    szArr = Split(Trim(.Item(lRow, "ELEVATION")), " ")
                    If GetUbound(szArr) < 0 Then szErr = "Elevation not specified" : GoTo SubError
                    ReDim lCh(GetUbound(szArr))
                    szErr = ""
                    For lX = 0 To GetUbound(szArr)
                        If gblnCancel Then Return ""
                        If Not IsNumeric(szArr(lX)) Then
                            szErr = szErr & "Elevation " & szArr(lX) & " must be a valid numeric." & vbCrLf
                        Else
                            lCh(lX) = GetChannelFromElevation(Val(szArr(lX)))
                            If lCh(lX) < 1 Then
                                szErr = szErr & "Elevation '" & szArr(lX) & "' not specified." & vbCrLf
                            ElseIf lCh(lX) > glPlayerChannels Then
                                szErr = szErr & "Channel #" & TStr(lCh(lX)) & " not supported. Device is set in Options to " & TStr(glPlayerChannels) & " channels only." & vbCrLf
                            End If
                            For lY = 0 To lX - 1
                                If lCh(lY) = lCh(lX) Then
                                    szErr = szErr & "Multiple entries for elevation '" & szArr(lX) & "' found." & vbCrLf
                                    Exit For
                                End If
                            Next
                        End If
                    Next
                    If Len(szErr) > 0 Then GoTo SubError
                    If GetUbound(lCh) > GetUbound(gISD) Then
                        szErr = "More elevations than ISDs specified."
                        GoTo SubError
                    End If
                Case Else
                    ' MLS, Cosine Gen.
                    If Len(.Item(lRow, "CHANNEL ID")) = 0 Then szErr = "No Channel ID." : GoTo SubError
                    If (Len(.Item(lRow, "FREQ")) = 0) Or (Not IsNumeric(.Item(lRow, "FREQ"))) Then
                        szErr = "Frequency not found."
                        GoTo SubError
                    Else
                        sFreq = Val(.Item(lRow, "FREQ"))
                    End If
                    ReDim lCh(0)
                    If Not IsNumeric(.Item(lRow, "CHANNEL ID")) Then szErr = "Channel ID must be a valid numeric." : GoTo SubError
                    lCh(0) = GetChannelFromElevation(Val(.Item(lRow, "CHANNEL ID")))
                    If lCh(0) < 1 Then
                        szErr = "Channel ID " + .Item(lRow, "CHANNEL ID") + " not specified."
                    ElseIf lCh(lX) > glPlayerChannels Then
                        szErr = szErr & "Channel #" & TStr(lCh(lX)) & " not supported. Device is set in Options to " & TStr(glPlayerChannels) & " channels only." & vbCrLf
                    End If
                    If Len(szErr) > 0 Then GoTo SubError
            End Select
            szAzimuth = .Item(lRow, "AZIMUTH")
            If Len(.Item(lRow, "AMP")) > 0 And IsNumeric(.Item(lRow, "AMP")) Then
                sAmp = Val(.Item(lRow, "AMP"))
            Else
                szErr = "Invalid Amplitude."
                GoTo SubError
            End If
            szRight = Create.CreateRecPrefix(lRow)

            ' check if tracker is working (only when azimuth is numeric, i.e. not in headphone measurements)
            If IsNumeric(szAzimuth) And Not Tracker.IsTracking() Then
                Dim Msg, Title As Object
                Msg = "No tracker data has been received yet. The tracker won't be used in the measurements. Do you want to continue?"
                Dim Style As MsgBoxStyle = CType(vbYesNo + vbCritical + vbDefaultButton2, MsgBoxStyle)
                Title = "No tracker data"
                Dim Response As MsgBoxResult = MsgBox(Msg, Style, Title)
                If Response = vbYes Then    ' User chose Yes.

                Else    ' User chose No.
                    Return ""
                End If
            End If

            ' check if turntable is initialised (only when azimuth is numeric, i.e. not in headphone measurements)
            'If IsNumeric(szAzimuth) And Not gblnTTInitialized Then
            'Dim Msg, Title As Object
            'Msg = "Turntable was not initialized. If you continue, it will be assumed that it is at 0 degrees (not recommended). Do you want to continue?"
            'Dim Style As MsgBoxStyle = CType(vbYesNo + vbCritical + vbDefaultButton2, MsgBoxStyle)
            'Title = "Turntable not initialized"
            'Dim Response As MsgBoxResult = MsgBox(Msg, Style, Title)
            'If Response = vbYes Then    ' User chose Yes.
            '
            ' Else    ' User chose No.
            'eturn ""
            'End If
            'End If

            ' check if turntable speed is > 1 (only when azimuth is numeric, i.e. not in headphone measurements)
            If IsNumeric(szAzimuth) And ttSpeed > 1 Then

                ' NEW VERSION: JUST SET ttSpeed to 1
                ttSpeed = 1

                ' OLD VERSION BELOW, WITH THE DIALOG BOX
                'Dim Msg, Title As Object
                'Msg = "Turntable speed is faster than 1 degree per second, which will likely produce inaccuracies. Do you want to set it to 1 degree per second (recommended)?"
                'Dim Style As MsgBoxStyle = CType(vbYesNo + vbCritical + vbDefaultButton2, MsgBoxStyle)
                'Title = "Turntable speed too high"
                'Dim Response As MsgBoxResult = MsgBox(Msg, Style, Title)
                'If Response = vbYes Then    ' User chose Yes.
                'ttSpeed = 1
                'End If

            End If

            ' rotate turntable
            If Len(szAzimuth) > 0 Then
                If Not IsNumeric(szAzimuth) Then szErr = "Azimuth must be a valid numeric." : GoTo SubError
                sX = Turntable.GetAngle
                szErr = Turntable.MoveToAngle(Val(szAzimuth))
                If Len(szErr) > 0 Then GoTo SubError
                If gblnCancel Then GoTo SubError
                WaitHP(curTimer)
                'frmMain.SetOutputStatus(0, 3)
                If WaitHP(curTimer, glPreStimBreak) Then GoTo SubError
            End If

            ' Tracker: start tracking sensor 0
            If gblnTrackerUse And glTrackerCOM > 0 Then
                tsTrackerMin(0) = gtsTrackerMin(0)
                tsTrackerMax(0) = gtsTrackerMax(0)
                tsTrackerMin(0).sngA = tsTrackerMin(0).sngA + Val(szAzimuth)
                tsTrackerMax(0).sngA = tsTrackerMax(0).sngA + Val(szAzimuth)
                Tracker.TrackMinMaxValues(0, tsTrackerMin(0), tsTrackerMax(0))
            End If

            WaitHP(curTimer)

            Select Case glExpType
                Case 0 ' MLS
                    ' mute DAC
                    Output.Send("/DAC/SetVol/*", 0)
                    ' files already created?
                    szLeft = Create.CreateStimFileName()
                    If Not STIM.CheckStimulationFile(szLeft) Then
                        szErr = Create.CreateStimulus(szLeft)
                        If Len(szErr) <> 0 Then GoTo SubError
                    End If

                    ' Calculate Time Out
                    lTO = CInt((2 ^ glMLSOrder) * glMLSRepetition / glSamplingRate * 1000 + gsRecTrail)

                    ' setup audio channels
                    Output.Send("/ADC/SetAttn/*", 100)
                    Output.Send("/DAC/SetStream/*", "set", "silence")
                    glOutputRecord = 0
                    If GetUbound(gRecStream) > -1 Then
                        For lX = 0 To UBound(gRecStream)
                            Output.Send("/Rec/SetStream/" & TStr(lX), "set", LCase(gRecStream(lX)))
                            glOutputRecord = glOutputRecord Or CInt(2 ^ lX)
                        Next
                    End If
                    Output.Send("/DAC/SetStream/" & TStr(lCh(0) - 1), "set", "play0")
                    Output.Send("/Rec/SetDur/*", CSng(lTO))
                    ' load stimulus
                    szErr = Output.LoadStimulationFile(szLeft)
                    If Len(szErr) <> 0 Then GoTo SubError
                    ' unmute DAC
                    Output.Send("/DAC/SetVol/" & TStr(lCh(0) - 1), sAmp - gfreqParL(lCh(0) - 1).sSPLOffset + 100)

                Case 1, 3 ' Sweep or HRTF
                    ' mute DAC
                    Output.Send("/DAC/SetVol/*", 0)
                    ' files already created?
                    glOutputPlay.SetAll(False)
                    lTO = glPlayLength + CInt(Math.Round(gsRecTrail))
                    ' calculate all excitation signals and preemphasis if needed!
                    If Not STIM.CheckStimulationFile("invexpsweep") Then
                        szLeft = ""
                        szErr = Create.CreateStimulus(szLeft)
                        If Len(szErr) <> 0 Then GoTo SubError
                    End If
                    For lX = 0 To UBound(lCh)
                        If gblnCancel Then Return ""
                        If Len(gszPreemphasis) = 0 Then
                            ' no preemphasis
                            szLeft = "expsweep"
                        Else
                            ' use preemphasis for each channel
                            szLeft = "expsweep" & "_CH" & TStr(lCh(lX))
                            szX = szLeft
                            If Not STIM.CheckStimulationFile(szX) Then
                                szErr = Create.CreateStimulus(szX)
                                If Len(szErr) <> 0 Then GoTo SubError
                            End If
                        End If
                        ' load stimulation file
                        szErr = Output.PrepareStimulationFile(szLeft)
                        If Len(szErr) <> 0 Then GoTo SubError
                        Output.Send("/Play/OpenWAV/" & TStr(lX), "open", szLeft, 0, 44, 1, glResolution \ 8, "l")
                        lTO += CInt(Val(gISD(lX)))
                        'glOutputPlay = glOutputPlay Or CInt(2 ^ lX)
                        glOutputPlay(lX) = True
                    Next

                    ' setup audio channels
                    Output.Send("/ADC/SetAttn/*", 100)
                    Output.Send("/DAC/SetStream/*", "set", "silence")
                    glOutputRecord = 0
                    If GetUbound(gRecStream) > -1 Then
                        For lX = 0 To UBound(gRecStream)
                            Output.Send("/Rec/SetStream/" & TStr(lX), "set", LCase(gRecStream(lX)))
                            Output.Send("/Rec/SetDur/" & TStr(lX), CSng(lTO))
                            glOutputRecord = glOutputRecord Or CInt(2 ^ lX)
                        Next
                    End If
                    For lX = 0 To UBound(lCh)
                        Output.Send("/DAC/SetStream/" & TStr(lCh(lX) - 1), "set", "play" & TStr(lX))
                    Next
                    ' set play delays
                    sDel = 0
                    For lX = 0 To UBound(lCh)
                        sDel += Val(gISD(lX))
                        Output.Send("/Play/SetDelay/" & TStr(lX), CSng(sDel + 0.005))
                    Next
                    ' unmute DAC
                    For lX = 0 To UBound(lCh)
                        Output.Send("/DAC/SetVol/" & TStr(lCh(lX) - 1), sAmp - gfreqParL(lCh(lX) - 1).sSPLOffset + 100)
                    Next

                Case 2 ' Cosine
                    If sFreq < 10 Then
                        szErr = "Frequency must be at least 10 Hz."
                        GoTo SubError
                    End If
                    lTO = glPlayLength + CInt(Math.Round(gsRecTrail))
                    ' mute DACs and Synth0
                    Output.Send("/DAC/SetVol/*", 0) ' mute DACs
                    Output.Send("/Synth/SetVol/0", 0) ' mute Synth0
                    ' setup audio channels
                    'Output.Send("/Rec/SetDur/*", CSng(lTO))
                    Output.Send("/ADC/SetAttn/*", 100)
                    Output.Send("/DAC/SetStream/*", "set", "silence")
                    Output.Send("/DAC/SetAddStream/*", "set", "silence")
                    If sFreq > 0 Then
                        Output.Send("/DAC/SetAddStream/" & TStr(lCh(0) - 1), "set", "syn0")
                        Output.Send("/Synth/SetSignal/0", "cosine")
                        Output.Send("/Synth/SetPar1/0", sFreq)
                    End If
                    glOutputRecord = 0
                    If GetUbound(gRecStream) > -1 Then
                        For lX = 0 To UBound(gRecStream)
                            Output.Send("/Rec/SetStream/" & TStr(lX), "set", LCase(gRecStream(lX)))
                            glOutputRecord = glOutputRecord Or CInt(2 ^ lX)
                        Next
                    End If
                    ' unmute Synth0
                    Output.Send("/Synth/SetVol/0", sAmp - gfreqParL(lCh(0) - 1).sSPLOffset + 100)

            End Select

            ' wait prestimvisu break (to allow pd to set all parameters)
            'frmMain.SetOutputStatus(0, 3)
            If WaitHP(curTimer, glPreStimVisu + 500) Then szErr = "Timeout 1" : GoTo SubError ' Added some delay for after the warning tracker tones
            ' start recording
            frmMain.SetStatus("Starting stimulation")
            Select Case glExpType
                Case 0, 2 'MLS, Cosine Gen.
                    szErr = Output.Start("/Rec/StartSynced/*")
                Case 1, 3 ' Sweep
                    szErr = Output.Start("/Play/StartAll/0")
            End Select
            If Len(szErr) <> 0 Then GoTo SubError
            'If gblnCancel Then Return ""
            ' wait for ready
            frmMain.SetStatus("Stimulation in process - Please wait...")

            ''  PRE-ROTATION TRIAL #2
            Dim lDelay As Integer=lTO - 1000 'one second less than expected signal duration
            PreRotate2(lRow, lDelay)

            szErr = Output.WaitForReady(3 * lTO, lTO) ' this process takes some time
            If Len(szErr) <> 0 Then GoTo SubError
            'If gblnCancel Then Return ""
            WaitHP(curTimer)
            ' mute outputs
            Select Case glExpType
                Case 0, 1, 3 ' MLS and ExpSweep
                    Output.Send("/DAC/SetVol/*", 0)
                    ' Output.Send("/Play/SetDelay/*", 0) 'set delay to 0 to perform the following stop command immediatly
                    Output.Send("/Play/StartSynced/*", "stop") 'stop all pending delayed synced playbacks
                    Output.Send("/Play/Stop/*") 'stop all current playbacks
                Case 2 ' Cosine
                    Output.Send("/Synth/SetVol/0", 0)
            End Select

            If gblnCancel Then Return ""
            ' save responses
            frmMain.SetStatus("Saving Recorded WAVs...")
            If GetUbound(gRecStream) > -1 Then
                For lX = 0 To UBound(gRecStream)
                    If gblnDoNotConnectToDevice Then
                        gblnOutputResponded = True 'Do not connect to output device
                    Else
                        gblnOutputResponded = False
                        If My.Computer.FileSystem.FileExists(STIM.WorkDir & "\" & szRight & "_" + gRecStream(lX) + ".wav") Then _
                            BackupRecordedFile(STIM.WorkDir & "\", szRight & "_" + gRecStream(lX) + ".wav")
                        Output.Send("/Rec/SaveWAV/" & TStr(lX), STIM.WorkDir & "\" & szRight & "_" + gRecStream(lX) + ".wav")
                        DX = 0
                        Do
                            Sleep(50)
                            System.Windows.Forms.Application.DoEvents()
                            If gblnCancel Then GoTo SubError
                            DX += 1
                        Loop Until gblnOutputResponded Or gblnCancel
                        If gblnCancel Then GoTo SubError
                    End If
                Next
            End If
            If gblnCancel Then Return ""
            ' wait post stim visu break
            'frmMain.SetOutputStatus(0, 3)
            If gblnCancel Then Return ""
            If WaitSleepHP(curTimer, glPostStimVisu) Then GoTo SubError

            ' check tracker ranges
            If gblnTrackerUse And (glTrackerCOM > 0) And (sFreq > 0) Then
                lX = Tracker.CheckTrackedMinValue(0, gtsTrackerMin(0).lStatus)
                lX = lX Or Tracker.CheckTrackedMaxValue(0, gtsTrackerMax(0).lStatus)
                If (lX > 0) Then
                    ' First, play verbal cue for the direction that is most incorrect
                    Dim tsData As TrackerSensor
                    szErr = Tracker.GetCurrentValues(-1, 0, tsData) ' only tested for OptiTrack
                    If Val(gconstExp(13).varValue) = 1 And tsData.visible = True Then ' only continue if marker is visible
                        Dim X As Double = tsData.sngX
                        Dim Y As Double = tsData.sngY
                        Dim Z As Double = tsData.sngZ
                        Dim Yaw As Double = tsData.sngA - Val(szAzimuth)
                        Dim Pitch As Double = tsData.sngE
                        Dim Roll As Double = tsData.sngR
                        Dim wavPath As String = "C:/Users/Admin/Documents/Code/expsuite-code/AMTatARI/Resources/Application/" ' TODO: input path as parameter?
                        ' Only report one of the angles/axes, in order from least to most common
                        If (lX And 4) > 0 Then ' Z
                            If Z > 0 Then
                                wavPath = wavPath & "moveDown.wav"
                            Else
                                wavPath = wavPath & "moveUp.wav"
                            End If
                        ElseIf (lX And 1) > 0 Then ' X
                            If X > 0 Then
                                wavPath = wavPath & "moveBack.wav"
                            Else
                                wavPath = wavPath & "moveForward.wav"
                            End If
                        ElseIf (lX And 2) > 0 Then ' Y
                            If Y > 0 Then
                                wavPath = wavPath & "moveRight.wav"
                            Else
                                wavPath = wavPath & "moveLeft.wav"
                            End If
                        ElseIf (lX And 32) > 0 Then ' Roll
                            If Roll > 0 Then
                                wavPath = wavPath & "tiltRight.wav"
                            Else
                                wavPath = wavPath & "tiltLeft.wav"
                            End If
                        ElseIf (lX And 8) > 0 Then ' Yaw
                            If Yaw > 0 Then
                                wavPath = wavPath & "lookRight.wav"
                            Else
                                wavPath = wavPath & "lookLeft.wav"
                            End If
                        ElseIf (lX And 16) > 0 Then ' Pitch
                            If Pitch > 0 Then
                                wavPath = wavPath & "lookDown.wav"
                            Else
                                wavPath = wavPath & "lookUp.wav"
                            End If
                        Else
                            ' we should never end up here
                        End If
                        Output.Send("/Play/OpenWAV/0", "open", wavPath, 0, 44, 1, glResolution \ 8, "l")
                        Output.Send("/DAC/SetStream/3", "set", "play0")
                        Output.Send("/Play/SetDelay/0", 0.005)
                        Output.Send("/DAC/SetVol/3", 80)
                        Output.Send("/Play/StartAll/0")
                        Sleep(1000)
                        Output.Send("/DAC/SetVol*", 0)
                        Output.Send("/Play/StartSynced/*", "stop")
                        Output.Send("/Play/Stop/*")
                    End If
                    ' Then, change the Min/Max range for the euler angles to 1 degree
                    Dim tsTrackerMin_tmp As TrackerSensor = tsTrackerMin(0)
                    Dim tsTrackerMax_tmp As TrackerSensor = tsTrackerMax(0)
                    tsTrackerMin(0).sngA = -1 + Val(szAzimuth)
                    tsTrackerMax(0).sngA = 1 + Val(szAzimuth)
                    tsTrackerMin(0).sngE = -1
                    tsTrackerMax(0).sngE = 1
                    tsTrackerMin(0).sngR = -1
                    tsTrackerMax(0).sngR = 1
                    Tracker.TrackMinMaxValues(0, tsTrackerMin(0), tsTrackerMax(0))
                    ' Next, play the tones
                    szErr = frmTrackerLeadInRange.ShowForm(sAmp - gfreqParL(lCh(0) - 1).sSPLOffset + 100 - 20, sFreq, Val(szAzimuth)) ' added -20 to make it quieter
                    If Len(szErr) > 0 Then GoTo SubError
                    If gblnCancel Then szErr = "Canceled by user" : GoTo SubError
                    ' Then, change the Min/Max range to the original value
                    tsTrackerMin(0) = tsTrackerMin_tmp
                    tsTrackerMax(0) = tsTrackerMax_tmp
                    Tracker.TrackMinMaxValues(0, tsTrackerMin(0), tsTrackerMax(0))
                    ' Finally, play a ''well done'' sound and repeat measurement
                    Output.Send("/Play/OpenWAV/0", "open", "C:/Users/Admin/Documents/Code/expsuite-code/AMTatARI/Resources/Application/coin.wav", 0, 44, 1, glResolution \ 8, "l") ' TODO: input path as parameter?
                    Output.Send("/DAC/SetStream/3", "set", "play0")
                    Output.Send("/Play/SetDelay/0", 0.005)
                    Output.Send("/DAC/SetVol/3", 80)
                    Output.Send("/Play/StartAll/0")
                    Sleep(1200)
                    Output.Send("/DAC/SetVol*", 0)
                    Output.Send("/Play/StartSynced/*", "stop")
                    Output.Send("/Play/Stop/*")
                    GoTo SubStart
                End If
            End If

            '' "PRE-ROTATION TRIAL 1" ' (saved a couple of seconds but did not make the cabbage fat)
            ''  PRE-ROTATION #1
            'If gblnExperiment = True AndAlso glTTMode = 1 Andalso gblnAllowPreRotation AndAlso lRow+1 < .ItemCount Then

            '    szAzimuth = .Item(lRow+1, "AZIMUTH") 'next azimuth

            '    ' rotate turntable
            '    If Len(szAzimuth) > 0 Andalso IsNumeric(szAzimuth) Then
            '        sX = Turntable.GetAngle
            '        If gblnCancel Then GoTo SubError
            '        frmMain.SetStatus("Pre-rotating to next item...")
            '        szErr = Turntable.MoveToAngle(Val(szAzimuth),-1,False,False,True) 'don't wait until position has been reached
            '        If Len(szErr) > 0 Then GoTo SubError
            '    End If

            '    If gblnCancel Then GoTo SubError

            'End If

            .Item(lRow, "STATUS") = "Recorded"
            .SetOptimalColWidth
           If gblnExperiment = False then if WaitHP(curTimer, glPostStimVisu) Then GoTo SubError 'if not in experiment wait...

           Select glExpType
                Case 1, 3
                    If gblnExperiment = False And gconstExp(9).varValue = "1" Then 'jump to next item (if not in experiment)
                        .ItemIndex = Math.Min(.ItemIndex + 1, .ItemCount - 1)
                    End If
            End Select

            'SubEnd:
            If gblnTrackerUse And glTrackerCOM > 0 Then
                DontTrackMinMaxValues(0)
            End If
            Return ""
SubError:
            Turntable.EmergencyStop()
            Return "Error in Stimulate Selected Item: " & vbCrLf & szErr
        End With

    End Function

    Private Sub PreRotate2(lRow As Integer, lDelay As Integer)

        If gblnExperiment = True AndAlso glTTMode = 1 Andalso gblnAllowPreRotation AndAlso lRow + 1 < itemlist.ItemCount Then

            dim szAzimuth As String = itemlist.Item(lRow + 1, "AZIMUTH") 'next azimuth

            ' rotate turntable
            If Len(szAzimuth) > 0 Andalso IsNumeric(szAzimuth) Then
                dim sX As Double = Turntable.GetAngle
                If gblnCancel Then GoTo SubError
                frmMain.SetStatus("Pre-rotating to next item...")
                
                '        ' set the timer
                'frmTurntable.tmrDelayed.Interval = 3000 'ms
                'frmTurntable.tmrDelayed.Start()


                'move with delay
                dim szErr As String = Turntable.MoveToAngle(Val(szAzimuth), -1, False, False, True, lDelay) 'don't wait until position has been reached

                If Len(szErr) > 0 Then GoTo SubError
            End If

            If gblnCancel Then GoTo SubError

        End If

SubError:

    End Sub

    Private Sub BackupRecordedFile(szFolder As String, szFn As String)
        Dim bScanFn As Boolean = False
        Dim lX As Integer = 0

        Do While bScanFn = False
            lX += 1
            If Not My.Computer.FileSystem.FileExists(szFolder & "~" & TStr(lX) & szFn) Then
                My.Computer.FileSystem.RenameFile(szFolder & szFn, "~" & TStr(lX) & szFn)
                bScanFn = True
            End If
        Loop
    End Sub

    Sub OnCreateAllStimuli()
    End Sub

    Sub OnStimulateAll()

        '' Check for duplicate indices
        'Dim szErr As String = CheckIndices()
        'If szErr <> "" Then
        '    If MsgBox("Warning: The following indices appear multiple times in the item list and these recordings can be overwritten!" & _
        '              vbCrLf & szErr & vbCrLf & vbCrLf & "Do you want to continue anyway?", _
        '              MsgBoxStyle.OkCancel Or MsgBoxStyle.Critical, "Duplicate indices found") = MsgBoxResult.Cancel Then Exit Sub
        'End If

        For lX As Integer = 0 To ItemList.ItemCount - 1
            OnStimulateSelected(lX, 0, "", "")
            If gblnCancel Then Exit For
        Next
    End Sub

    Function OnStartExperiment(ByRef lRow As Integer) As String
        Dim szErr As String
        Dim szLeft As String = ""
        Dim szX As String = ""
        Dim szRight As String = ""
        Dim lTO As Integer

        ' PROLOG
        '-------

        '' Check for duplicate indices
        'szErr = CheckIndices()
        'If szErr <> "" Then
        '    If MsgBox("Warning: The following indices appear multiple times in the item list and these recordings can be overwritten!" & _
        '              vbCrLf & szErr & vbCrLf & vbCrLf & "Do you want to continue anyway?", _
        '              MsgBoxStyle.OkCancel Or MsgBoxStyle.Critical, "Duplicate indices found") = MsgBoxResult.Cancel Then Return ""
        'End If

        With ItemList 
            Do  'Loop Until .NextItem
                ' item status
                .ItemStatus(.ItemIndex) = clsItemList.Status.Processing
                Windows.Forms.Application.DoEvents() 'Cancel button pressed?
                If gblnCancel Then szErr = "Canceled by user" : GoTo SubError
                ' stimulate!
                szErr = OnStimulateSelected(.ItemIndex, lTO, szLeft, szRight)
                Windows.Forms.Application.DoEvents() 'Cancel button pressed?
                If gblnCancel Then GoTo SubCancel
                If Len(szErr) <> 0 Then 'error occured?
                    .ItemStatus(.ItemIndex) = clsItemList.Status.FinishedError
                    If InStr(1, szErr, "Tracker") < 1 Then GoTo SubError
                    ' tracker left the range - repeat the item
                Else
                    .ItemStatus(.ItemIndex) = clsItemList.Status.FinishedOK
                    ' everything OK - stimulate next item
                End If
            Loop Until .NextItem

            ' EPILOG
            '-------
            frmMain.SetStatus("Experiment finished.")

            ' play the end-of-experiment sound
            Output.Send("/Play/OpenWAV/0", "open", Replace(AppResourcesDirectory & "\relax.wav", "\", "/"), _
                        0, 44, 1, 16 \ 8, "l")
            Output.Send("/DAC/SetStream/0", "set", "play0")
            Output.Send("/Play/SetDelay/0", CSng(0.005))
            Output.Send("/DAC/SetVol/0", Val(ItemList.Item((ItemList.ItemIndex), "AMP")) - gfreqParL(0).sSPLOffset + 100)
            szErr = Output.Start("/Play/Start/0")

SubEnd:
            Return ""

            ' exception handling
SubCancel:
            Return "Experiment canceled."

SubError:
            Return "Experiment Error: " & szErr
        End With
    End Function

    Sub OnSnapshot()
    End Sub

    Public Sub OnConnect()
        gblnConnectLeft = True
        gblnConnectRight = True
    End Sub

    Public Sub OnDisconnect()
        'Dim szX As String
        'Dim lX As Integer

        'lX = 0
        'szX = Dir(STIM.WorkDir & "\*" & STIMFILEEXT_ACOUSTIC)
        'While Len(szX) <> 0
        '    If (GetAttr(STIM.WorkDir & "\" & szX) And FileAttribute.ReadOnly) <> FileAttribute.ReadOnly Then
        '        lX = lX + 1
        '    End If
        '    szX = Dir()
        'End While
        'If lX > 0 Then
        '    lX = MsgBox(TStr(lX) & " *" & STIMFILEEXT_ACOUSTIC & " files in the working directory are not marked as read only." & vbCrLf & vbCrLf & "Do you want mark them as read only?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1, "Mark files as read only")
        '    If lX = MsgBoxResult.Yes Then
        '        szX = Dir(STIM.WorkDir & "\*" & STIMFILEEXT_ACOUSTIC)
        '        While Len(szX) <> 0
        '            If (GetAttr(STIM.WorkDir & "\" & szX) And FileAttribute.ReadOnly) <> FileAttribute.ReadOnly Then
        '                SetAttr(STIM.WorkDir & "\" & szX, (GetAttr(STIM.WorkDir & "\" & szX) Or FileAttribute.ReadOnly))
        '            End If
        '            szX = Dir()
        '        End While
        '    End If
        'End If

    End Sub

    Public Sub OnOutputResponse(ByRef szCmd As String, ByRef varArgs() As Object)
        'Debug.Print szCmd
        ' OSC.SeparateCommand szCmd, szFunc
    End Sub
End Module