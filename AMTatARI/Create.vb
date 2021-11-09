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
Module Create
	
    Private Function AppendStimulus(ByRef stPar As clsSTIMULUS, ByRef lPulseNr As Integer, ByRef lOffset As Integer) As String

        With stPar
            Return STIM.MatlabStimulus("AppendPulseTrain", .sAmp, .lRange, .lElectrode, .lPhDur, lPulseNr, .lPulsePeriod, lOffset)
        End With

    End Function

    Public Function CreateRecPrefix(ByRef lRow As Integer) As String
        Dim szPrefix As String
        
        If IsNumeric(ItemList.Item(lRow, "INDEX")) Then
            szPrefix = STIM.ID & "_" & VB6.Format(ItemList.Item(lRow, "INDEX"), "0000") 'now the index is the actual index from the index column
        Else
            szPrefix = STIM.ID & "_" & ItemList.Item(lRow, "INDEX") '... or text
        End If
        Return szPrefix

    End Function

    Public Function CreateStimFileName() As String

        CreateStimFileName = "mls" & TStr(glMLSOrder) & "_" & TStr(glMLSRepetition)

    End Function

    Public Function CreateStimulus(ByRef szStimName As String, Optional ByRef lCh As Integer = -1) As String
        Dim stPar As New clsSTIMULUS
        Dim szErr As String
        Dim lOffset, lPulseNr As Integer
        Dim szDir As String

        Dim dblScale(0, 0) As Double
        With stPar
            On Error GoTo StimError
            ' create new stimulus
            frmMain.SetStatus("Create stimulus")
            ' get all parameter for the stimulus
            szDir = gszSourceDir
            'frmMain.SetOutputStatus(0, 1)
            ' append stimulus part
            Select Case glExpType
                Case 0 ' MLS
                    gstLeft.szStimFile = szStimName
                    gstLeft.freqPar = gfreqParL
                    szErr = STIM.NewStimulus(gstLeft)
                    If Len(szErr) <> 0 Then GoTo SubError
                    szErr = STIM.Matlab("stimVec=repmat(audioread('" & AppResourcesDirectory & "\mls" & TStr(glMLSOrder) & ".wav')," & TStr(glMLSRepetition) & ",1);")
                    If Len(szErr) <> 0 Then GoTo SubError
                    ' assemble
                    szErr = STIM.AssembleStimulus(gblnShowStimulus)
                    If Len(szErr) <> 0 Then GoTo SubError
                    szStimName = gstLeft.szStimFile
                Case 1, 3 ' LogSweep, HRTF
                    If Not STIM.CheckStimulationFile("expsweep") Then
                        gstLeft.szStimFile = "expsweep"
                        gstLeft.freqPar = gfreqParL
                        szErr = STIM.NewStimulus(gstLeft)
                        If Len(szErr) <> 0 Then GoTo SubError
                        frmMain.SetStatus("Create sweep")
                        szErr = STIM.Matlab("[stimVec,invsweepX]=AA_AppendExpSweep(stimVec,stimPar," & TStr(glFreqStart) & "," & TStr(glFreqEnd) & "," & TStr(glPlayLength * glSamplingRate / 1000) & ");")
                        If Len(szErr) <> 0 Then GoTo SubError
                        szErr = STIM.AssembleStimulus(gblnShowStimulus)
                        If Len(szErr) <> 0 Then GoTo SubError
                    End If
                    If Len(gszPreemphasis) > 0 Then
                        ' preemphasize the sweep with the correct filter
                        frmMain.SetStatus("Create preemphasized signals for all channels")
                        szErr = STIM.Matlab("scale=AA_Preemphasize(stimPar,'" & gszPreemphasis & "','" & STIM.WorkDir & "\expsweep');") ' calculate and save all preemphasized signals
                        If Len(szErr) <> 0 Then GoTo SubError
                        szErr = STIM.MatlabGetRealMatrix2("scale", dblScale)
                        If Len(szErr) <> 0 Then GoTo SubError
                        If dblScale(0, 0) > 1 Then MsgBox("The results of preemphasis were scaled by " & TStr(20 * Proc.Log10(CSng(dblScale(0, 0)))) & "dB to avoid clipping.", MsgBoxStyle.Information, "Calculate Preemphasized Signals")
                    End If
                    szDir = gstLeft.szStimFile
                    ' create inverse sweep file
                    If Not STIM.CheckStimulationFile("invexpsweep") Then
                        frmMain.SetStatus("Create inverse sweep")
                        gstLeft.szStimFile = "invexpsweep"
                        gstLeft.freqPar = gfreqParL
                        szErr = STIM.NewStimulus(gstLeft)
                        If Len(szErr) <> 0 Then GoTo SubError
                        szErr = STIM.Matlab("stimVec=invsweepX;")
                        If Len(szErr) <> 0 Then GoTo SubError
                        ' assemble
                        szErr = STIM.AssembleStimulus(gblnShowStimulus)
                        If Len(szErr) <> 0 Then GoTo SubError
                    End If
                    szStimName = szDir
            End Select


            CreateStimulus = "" ' no errors
            GoTo SubEnd

StimError:
            CreateStimulus = "CreateStimulus: " & Err.Description
            GoTo SubEnd

SubError:
            CreateStimulus = "CreateStimulus: " & szErr

SubEnd:
            'frmMain.SetOutputStatus(0, 0)
            On Error GoTo 0
        End With

    End Function


    Public Function Preemphasis(ByRef szFN As String) As String
        Dim szX, szY As String

        szX = "load('" & szFN & "');"
        szY = STIM.Matlab(szX)
        If Len(szY) <> 0 Then
            Return "Error loading preemphasis." & vbCrLf & "Command line: " & szX & vbCrLf & "Error: " & szY
        End If
        Return ""

    End Function
End Module