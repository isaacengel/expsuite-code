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
Module EventsSettings
	Private mlExpType As Integer
	
    Dim varTempConst(10, 3) As String ' (X,Y) X: Const number, Y: exp number
	
	' USER FUNCTIONS
	' --------------
    Public Sub OnLoad()

        With frmSettings
            '.optStimCreation(0).Visible = False ' disable "create: electrical"
            '.optStimOutput(0).Visible = False ' disable "output: electrical"
            .tabFittingLeft.Enabled = False ' disable "fitting file left"
            .tabFittingRight.Enabled = False ' disable "fitting file right"
            .tabExperimentScreen.Enabled = False ' disable "experiment screen"
            .lblSignal.Text = "Play channel:"
            .fraAcousticL.Text = "Channel:"
            .fraAcousticR.Text = "not used"
            Select Case glExpType
                Case 0, 1, 2
                    .lblAmp.Text = "Channel ID:"
                Case 3
                    .lblAmp.Text = "Elevation [°]:"
            End Select
            '.lblAmp.Caption = "Add. Amplitude [dB FS]:"
            .lblPhDur.Text = "System Latency [us]:"
            .lblCenterFreq.Text = "not used"
            .lblBandwidth.Text = "not used"
            .lblTHR.Text = "not used"
            .lblMCL.Text = "not used"

            .lblPreStimBreak.Text = "Azimuth setup delay:"
            .ToolTip1.SetToolTip(.lblPreStimBreak, "Wait after stopping turntable, just before setting up YAMI.")
            .lblPreStimVisuOffset.Text = "Pre-record setup time:"
            .ToolTip1.SetToolTip(.lblPreStimVisuOffset, "Wait after configuring YAMI, just before start to play signals.")
            .lblInterStimBreak.Text = "Record trail:"
            .ToolTip1.SetToolTip(.lblInterStimBreak, "Extend the record, just before sending save command.")
            .lblPostStimVisuOffset.Text = "Post-record setup time:"
            .ToolTip1.SetToolTip(.lblPostStimVisuOffset, "Wait at least this period while and after saving, just before continuing with the next item.")
            TextBoxState(.txtOffsetL, False)
            TextBoxState(.txtOffsetR, False)
            'TextBoxState(.txtItemBlock, False)
        End With

    End Sub
	
    Public Sub OnSet()
        Dim szX As String
        Dim lX As Integer
        Dim sngX As Double

        ' copy framework variables to my data
        gElevation = CopyArray(gvarExp(0).varValue)
        gAzimuth = CopyArray(gvarExp(1).varValue)
        gRecStream = CopyArray(gvarExp(2).varValue)
        gAmp = CopyArray(gvarExp(3).varValue)
        gFreq = CopyArray(gvarExp(4).varValue)
        gISD = CopyArray(gvarExp(5).varValue)

        ' copy framework constants to my data
        glTrackerInRange = CInt(Val(gconstExp(0).varValue))
        glPlayLength = CInt(Val(gconstExp(1).varValue))
        Select Case glExpType
            Case 0 ' MLS
                glMLSOrder = CInt(Val(gconstExp(2).varValue))
                glMLSRepetition = CInt(Val(gconstExp(3).varValue))
                If mlExpType <> glExpType Then ItemList.ColCaption(2) = "Channel ID"
            Case 1 ' ExpSweep
                glFreqStart = CInt(Val(gconstExp(2).varValue))
                glFreqEnd = CInt(Val(gconstExp(3).varValue))
                gsIRLen = Val(gconstExp(4).varValue)
                gsIRBeg = Val(gconstExp(5).varValue)
                gsIREnd = Val(gconstExp(6).varValue)
                gszPreemphasis = gconstExp(7).varValue
                glBlockSize = CInt(Val(gconstExp(8).varValue))
                If mlExpType <> glExpType Then ItemList.ColCaption(2) = "Channel ID"
            Case 2 ' Cosine
                glFreqSpan = CInt(Val(gconstExp(2).varValue))
                gsTHDTheta = Val(gconstExp(3).varValue)
                glNotchOrder = CInt(Val(gconstExp(4).varValue))
                If mlExpType <> glExpType Then ItemList.ColCaption(2) = "Channel ID"
            Case 3 ' HRTF
                glFreqStart = CInt(Val(gconstExp(2).varValue))
                glFreqEnd = CInt(Val(gconstExp(3).varValue))
                gsIRLen = Val(gconstExp(4).varValue)
                gsIRBeg = Val(gconstExp(5).varValue)
                gsIREnd = Val(gconstExp(6).varValue)
                gszPreemphasis = gconstExp(7).varValue
                glBlockSize = CInt(Val(gconstExp(8).varValue))
                If mlExpType <> glExpType Then ItemList.ColCaption(2) = "Elevation"
        End Select

        ' set ISD to integer in ms and blocksize samples
        If glExpType = 1 Or glExpType = 3 Then
            szX = ""
            For lX = 0 To GetUbound(gISD)
                sngX = System.Math.Round(Val(gISD(lX)) * glSamplingRate / glBlockSize * 1000) / 1000 * glBlockSize / glSamplingRate
                If System.Math.Abs(sngX - Val(gISD(lX))) > 0.001 Then
                    szX = szX & "ISD #" & TStr(lX) & ": Value " & (gISD(lX)) & " was set to " & TStr(sngX) & vbCrLf
                    gISD(lX) = TStr(sngX)
                    gvarExp(5).varValue(lX) = TStr(sngX)
                End If
            Next
            If Len(szX) > 0 Then
                MsgBox(szX, MsgBoxStyle.Critical, "ISD must be integer in Blocksize samples.")
            End If
        End If



        If mlExpType <> glExpType Then ItemList.Clear()
        mlExpType = glExpType

        ' set another constants
        gsRecTrail = glInterStimBreak

        szX = ""
        ' set execute list
        Select Case glExpType
            Case 0 ' MLS
                szX = "Plot Records;Impulse Response Toolbox;Post Processing Toolbox"
            Case 1, 3 ' Sweep, HRTF
                szX = "Plot Records;Impulse Response Toolbox;Post Processing Toolbox;Delete Stimulation Files;Calculate MESM parameters"
            Case 2 ' Cosine Gen
                szX = "Plot Records;Total Harmonic Distortion;SINAD (=THD+N)"
        End Select
        frmMain.SetResultList(szX)

    End Sub

    Public Sub OnChange(ByVal lExpType As Integer)
        Dim sX As Double
        With frmSettings

            Select Case lExpType
                Case 0 ' MLS
                    ' Used Consants:
                    ' 0: unused
                    ' 1: Stimulus length, disabled
                    ' 2: MLS Order
                    ' 3: MLS Repetition
                    ' calc length of the signal
                    sX = Val(.txtSamplingRate.Text)
                    If sX = 0 Then
                        .txtConstValue(0).Text = ""
                    ElseIf Val(.txtConstValue(2).Text) < 30 Then
                        .txtConstValue(1).Text = VB6.Format((2 ^ Val(.txtConstValue(2).Text)) * Val(.txtConstValue(3).Text) / sX * 1000, "0")
                    End If
                Case 1, 3 ' Sweep, HRTF
                    ' Used Constants
                    ' 0: unused
                    ' 1: Stimulus length
                    ' 2: Start Freq
                    ' 3: End Freq
                    ' 4: IR length
                    ' 5: IR begin offset
                    ' 6: IR End offset
                Case 2 ' Cosine
                    ' Used Constants
                    ' 0: unused
                    ' 1: Stimulus length
                    ' 2: Freq. Span
                    ' 3: THD: theta
                    ' 4: SINAD: Notch filter order
            End Select
        End With
    End Sub
	
    Public Sub OnExpTypeChange(ByVal lOld As Integer, ByVal lNew As Integer)
        Dim lX As Integer
        Dim varTemp() As String

        ReDim varTemp(UBound(gconstExp))
        If lOld > -1 Then
            ' save new .varValues
            frmSettings.GetConstantValues(varTemp)
            For lX = 0 To UBound(varTemp)
                varTempConst(lX, lOld) = varTemp(lX)
            Next
        End If

        Select Case lNew
            Case 0 ' MLS
                If lOld > -1 Then frmSettings.lblAmp.Text = "Channel ID:"
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
                    .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfMin Or FWintern.VariableFlags.vfMax
                    .dMin = 0
                    .dMax = 357.5
                    .szDefault = ""
                    .szUnit = "degrees"
                End With
                With gvarExp(5)
                    .Flags = FWintern.VariableFlags.vfDisabled
                End With
                With gconstExp(1)
                    .szName = "Stimulus Length"
                    .szDescription = "Shows the length of stimulus."
                    .szUnit = "ms"
                    .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfMin Or FWintern.VariableFlags.vfDisabled
                    .dMin = 1
                    .varDefault = "1"
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
                For lX = 4 To UBound(gconstExp)
                    With gconstExp(lX)
                        .szName = "not used"
                        .szDescription = ""
                        .szUnit = ""
                        .Flags = FWintern.VariableFlags.vfHidden
                        .varDefault = "0"
                    End With
                Next

            Case 1 ' Sweep
                If lOld > -1 Then frmSettings.lblAmp.Text = "Channel ID:"
                With gvarExp(0)
                    .szName = "Channel ID"
                    .szDescription = "List of channels used in the measurement. Each ID must match a channel ID specified in the Signal tab."
                    .szUnit = ""
                    .Flags = FWintern.VariableFlags.vfNumeric
                    .dMin = 1
                    .szDefault = "1;2;3;4;5;6;7;8"
                End With
                With gvarExp(1)
                    .szName = "Azimuth"
                    .szDescription = "Sets the azimuth angle of the turntable. Leave blank if you don't want to use turntable"
                    .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfMin Or FWintern.VariableFlags.vfMax
                    .dMin = 0
                    .dMax = 357.5
                    .szDefault = ""
                    .szUnit = "degrees"
                End With
                With gvarExp(5)
                    .szName = "ISD"
                    .szDescription = "Sets the Inter Sweep Distance for each measured channel. Used in ExpSweep/HRTF modes only." & vbCrLf & "For the first channel ISD will be ignored and set internal to 0ms!"
                    .szUnit = "ms"
                    .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfMin
                    .dMin = 0
                    .szDefault = "0;150;605;150;605"
                End With
                With gconstExp(1)
                    .szName = "Stimulus Length"
                    .szDescription = "Sets the length of stimulus."
                    .szUnit = "ms"
                    .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfMin
                    .dMin = 1
                    .varDefault = "1500"
                End With
                With gconstExp(2)
                    .szName = "Start Frequency"
                    .szDescription = "Sets the start frequency of the sweep."
                    .szUnit = "Hz"
                    .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfMin
                    .dMin = 1
                    .varDefault = "50"
                End With
                With gconstExp(3)
                    .szName = "End Frequency"
                    .szDescription = "Sets the end frequency of the sweep."
                    .szUnit = "Hz"
                    .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfMin
                    .dMin = 1
                    .varDefault = "18000"
                End With
                With gconstExp(4)
                    .szName = "Length of IRs"
                    .szDescription = "Sets the length of each IR. The total length of IR will be: begin offset + length + end offset."
                    .szUnit = "ms"
                    .Flags = FWintern.VariableFlags.vfNumeric
                    .varDefault = "100"
                End With
                With gconstExp(5)
                    .szName = "Begin offset of IR"
                    .szDescription = "Sets the additional offset to the begin of the IR in ms. The length of IR will be: begin offset + length + end offset."
                    .szUnit = "ms"
                    .Flags = FWintern.VariableFlags.vfNumeric
                    .varDefault = "2.5"
                End With
                With gconstExp(6)
                    .szName = "End Offset of IR"
                    .szDescription = "Sets the additional offset to the end of the IR in ms. The length of IR will be: begin offset + length + end offset."
                    .szUnit = "ms"
                    .Flags = FWintern.VariableFlags.vfNumeric
                    .varDefault = "2.5"
                End With
                With gconstExp(7)
                    .szName = "Preemphasis filter"
                    .szDescription = "Sets the filename of preemphasis filters."
                    .szUnit = "*.mat"
                    .Flags = FWintern.VariableFlags.vfFileName
                    .varDefault = ""
                End With
                With gconstExp(8)
                    .szName = "Blocksize of pd/YAMI"
                    .szDescription = "The Blocksize parameter of pd/YAMI must be known for the calculation of ISD values."
                    .szUnit = "samples"
                    .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfInteger Or FWintern.VariableFlags.vfMin
                    .dMin = 1
                    .varDefault = "64"
                End With
                With gconstExp(9)
                    .szName = "Select next item after 'Stimulate Selected'"
                    .szDescription = "After pressing the 'Stimulate Selected' button the next item in the item list is selected." & vbCrLf & "0: false" & vbCrLf & "1: true"
                    .szUnit = "0/1"
                    .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfInteger Or FWintern.VariableFlags.vfMin Or VariableFlags.vfMax
                    .dMin = 0
                    .dMax = 1
                    .varDefault = "0"
                End With
                For lX = 10 To UBound(gconstExp)
                    With gconstExp(lX)
                        .szName = "not used"
                        .szDescription = ""
                        .szUnit = ""
                        .Flags = FWintern.VariableFlags.vfHidden
                        .varDefault = "0"
                    End With
                Next

            Case 2 ' Cosine
                If lOld > -1 Then frmSettings.lblAmp.Text = "Channel ID:"
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
                    .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfMin Or FWintern.VariableFlags.vfMax
                    .dMin = 0
                    .dMax = 357.5
                    .szDefault = ""
                    .szUnit = "degrees"
                End With
                With gvarExp(5)
                    .Flags = FWintern.VariableFlags.vfDisabled
                End With
                With gconstExp(1)
                    .szName = "Stimulus Length"
                    .szDescription = "Sets the length of stimulus."
                    .szUnit = "ms"
                    .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfMin
                    .dMin = 1
                    .varDefault = "1000"
                End With
                With gconstExp(2)
                    .szName = "Frequency Span"
                    .szDescription = "Sets the frequency span in seeking for peak(s) for calculation of THD and SINAD."
                    .szUnit = "Hz"
                    .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfInteger Or FWintern.VariableFlags.vfMin
                    .dMin = 1
                    .varDefault = "10"
                End With
                With gconstExp(3)
                    .szName = "THD: Theta"
                    .szDescription = "Only peaks above the product of noise amplitude and Theta are taken into account in THD calculation."
                    .szUnit = ""
                    .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfMin
                    .dMin = 0
                    .varDefault = "1.2"
                End With
                With gconstExp(4)
                    .szName = "SINAD: Notch Filter Order"
                    .szDescription = "Sets the order of the FIR notch filter for calculation of SINAD."
                    .szUnit = ""
                    .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfInteger Or FWintern.VariableFlags.vfMin
                    .dMin = 10
                    .varDefault = "500"
                End With
                For lX = 5 To UBound(gconstExp)
                    With gconstExp(lX)
                        .szName = "not used"
                        .szDescription = ""
                        .szUnit = ""
                        .Flags = FWintern.VariableFlags.vfHidden
                        .varDefault = "0"
                    End With
                Next

            Case 3 ' HRTF
                If lOld > -1 Then frmSettings.lblAmp.Text = "Elevation [°]:"
                'With gvarExp(2)
                '    .szUnit = "adc0;adc1;adc2;adc3;syn0;syn1;play0;play1;sum6"
                'End With
                With gvarExp(0)
                    .szName = "Elevation"
                    .szDescription = "List of elevations used in the measurement. Each elevation must match a channel specified in the Signal tab."
                    .szUnit = ""
                    .Flags = FWintern.VariableFlags.vfNumeric
                    .dMin = 1
                    .szDefault = "-30;-25;-20;-15;-10;-5;0;5;10;15;20;25;30;35;40;45;50;60;70;80"
                End With
                With gvarExp(1)
                    .szName = "Azimuth group"
                    .szDescription = "Sets the azimuth angle group of the HRTF. Syntax: begin resolution end, example: 0 2.5 45"
                    .Flags = 0
                    .szDefault = ""
                    .szUnit = "degrees"
                End With
                With gvarExp(5)
                    .szName = "ISD"
                    .szDescription = "Sets the Inter Sweep Distance for each measured channel. Used in ExpSweep/HRTF modes only." & vbCrLf & "For the first channel ISD will be ignored and set internal to 0ms!"
                    .szUnit = "ms"
                    .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfMin
                    .dMin = 0
                    .szDefault = "0;150;605;150;605"
                End With
                With gconstExp(1)
                    .szName = "Stimulus Length"
                    .szDescription = "Sets the length of stimulus."
                    .szUnit = "ms"
                    .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfMin
                    .dMin = 1
                    .varDefault = "1500"
                End With
                With gconstExp(2)
                    .szName = "Start Frequency"
                    .szDescription = "Sets the start frequency of the sweep."
                    .szUnit = "Hz"
                    .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfMin
                    .dMin = 1
                    .varDefault = "50"
                End With
                With gconstExp(3)
                    .szName = "End Frequency"
                    .szDescription = "Sets the end frequency of the sweep."
                    .szUnit = "Hz"
                    .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfMin
                    .dMin = 1
                    .varDefault = "18000"
                End With
                With gconstExp(4)
                    .szName = "Length of IRs"
                    .szDescription = "Sets the length of each IR. The total length of IR will be: begin offset + length + end offset."
                    .szUnit = "ms"
                    .Flags = FWintern.VariableFlags.vfNumeric
                    .varDefault = "100"
                End With
                With gconstExp(5)
                    .szName = "Begin offset of IR"
                    .szDescription = "Sets the additional offset to the begin of the IR in ms. The length of IR will be: begin offset + length + end offset."
                    .szUnit = "ms"
                    .Flags = FWintern.VariableFlags.vfNumeric
                    .varDefault = "2.5"
                End With
                With gconstExp(6)
                    .szName = "End Offset of IR"
                    .szDescription = "Sets the additional offset to the end of the IR in ms. The length of IR will be: begin offset + length + end offset."
                    .szUnit = "ms"
                    .Flags = FWintern.VariableFlags.vfNumeric
                    .varDefault = "2.5"
                End With
                With gconstExp(7)
                    .szName = "Preemphasis filter"
                    .szDescription = "Sets the filename of preemphasis filters."
                    .szUnit = "*.mat"
                    .Flags = FWintern.VariableFlags.vfFileName
                    .varDefault = ""
                End With
                With gconstExp(8)
                    .szName = "Blocksize of pd/YAMI"
                    .szDescription = "The Blocksize parameter of pd/YAMI must be known for the calculation of ISD values."
                    .szUnit = "samples"
                    .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfInteger Or FWintern.VariableFlags.vfMin
                    .dMin = 1
                    .varDefault = "64"
                End With
                With gconstExp(9)
                    .szName = "Select next item after 'Stimulate Selected'"
                    .szDescription = "After pressing the 'Stimulate Selected' button the next item in the item list is selected." & vbCrLf & "0: false" & vbCrLf & "1: true"
                    .szUnit = "0/1"
                    .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfInteger Or FWintern.VariableFlags.vfMin Or VariableFlags.vfMax
                    .dMin = 0
                    .dMax = 1
                    .varDefault = "0"
                End With
                With gconstExp(10)
                    .szName = "IR calculation: Flip azimuths at *5° elevation positions"
                    .szDescription = "When performing the calculation of the impulse responses, flip azimuth values by 180° if elevation is in *5° positions. Examples:" & _
                        vbCrLf &  "azi 0, ele 0" & vbTab &  "-> no change" & vbCrLf & "azi 0, ele 5" & vbTab &  "-> changed to azi 180, ele 5" & _
                        vbCrLf &  "azi 0, ele 10" & vbTab &  "-> no change" & vbCrLf & "azi 0, ele 15" & vbTab &  "-> changed to azi 180, ele 15" & _
                        vbCrLf &  "..."
                    .szUnit = "0/1"
                    .Flags = FWintern.VariableFlags.vfNumeric Or FWintern.VariableFlags.vfInteger Or FWintern.VariableFlags.vfMin Or VariableFlags.vfMax
                    .dMin = 0
                    .dMax = 1
                    .varDefault = "1"
                End With
                For lX = 11 To UBound(gconstExp)
                    With gconstExp(lX)
                        .szName = "not used"
                        .szDescription = ""
                        .szUnit = ""
                        .Flags = FWintern.VariableFlags.vfHidden
                        .varDefault = "0"
                    End With
                Next
        End Select

        ' restore old values
        If lOld > -1 And lNew > -1 Then
            For lX = 0 To UBound(varTemp)
                If IsNothing(varTempConst(lX, lNew)) Then
                    gconstExp(lX).varValue = gconstExp(lX).varDefault
                Else
                    gconstExp(lX).varValue = varTempConst(lX, lNew)
                End If
            Next
        End If

    End Sub
End Module