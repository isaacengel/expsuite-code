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
Module Result


    Public gIRFlags As IRFlags

    Public Sub GenerateSOFA(sofaname As String, referenceFile As String, doPlots As Integer, saveRaw As Integer, saveEQ As Integer, saveEQmp As Integer, saveITD As Integer, save3DTI As Integer, targetFs As String, finalCheck As Integer, itdThresh As Double, magThresh As Double, freqRange As String)
        If Not gblnOutputStable Then
            MsgBox("Connection to MATLAB required.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Dim StartTime As DateTime = System.DateTime.Now 'calculation time
        STIM.Matlab("AA_SOFAstart;")
        STIM.Matlab("this_dir = cd; amt_start('silent'); cd(this_dir);")
        Dim szErr As String = STIM.Matlab("AA_GenerateSOFA('" & sofaname & "','" & STIM.WorkDir & "','settings.AMTatARI','itemlist.itl.csv','" & referenceFile & "'," & doPlots & "," & saveRaw & "," & saveEQ & "," & saveEQmp & "," & saveITD & "," & save3DTI & "," & targetFs & ");")
        If Len(szErr) > 0 Then
            MsgBox(szErr, MsgBoxStyle.Critical, "Generate SOFA files")
            frmMain.SetStatus("Error(s) generating SOFA files")
        Else
            MsgBox("Successfully saved SOFA files!", MsgBoxStyle.Information, "Generate SOFA files")
        End If
        If finalCheck <> 0 Then
            szErr = STIM.Matlab("AA_QuickCompareHRTF('Lorenzo_20211216_First_Raw_96kHz.sofa','" & sofaname & "_Raw_96kHz.sofa'," & itdThresh & "," & magThresh & "," & freqRange & ");")
            If Len(szErr) > 0 Then
                MsgBox(szErr, MsgBoxStyle.Critical, "Final SOFA check")
                frmMain.SetStatus("Error(s) checking SOFA file")
            Else
                MsgBox("SOFA final check successful!", MsgBoxStyle.Information, "Final SOFA check")
            End If
        End If
        frmMain.SetStatus("Processing time: " & DateDiff(DateInterval.Second, StartTime, System.DateTime.Now).ToString & "s")
    End Sub

    Public Sub QuickPlotIR()
        If Not gblnOutputStable Then
            MsgBox("Connection to MATLAB required.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Dim StartTime As DateTime = System.DateTime.Now 'calculation time
        STIM.Matlab("AA_SOFAstart;")
        STIM.Matlab("this_dir = cd; amt_start('silent'); cd(this_dir);")
        Dim str() As String = STIM.WorkDir.Split("\"c)
        Dim szErr As String = STIM.Matlab("AA_QuickPlotIR('" & str(UBound(str)) & "','" & STIM.WorkDir & "');")
        If Len(szErr) > 0 Then
            MsgBox(szErr, MsgBoxStyle.Critical, "Showing plots")
            frmMain.SetStatus("Error(s) showing plots")
        Else
            MsgBox("Successfully showed plots!", MsgBoxStyle.Information, "Showing plots")
        End If
        frmMain.SetStatus("Processing time: " & DateDiff(DateInterval.Second, StartTime, System.DateTime.Now).ToString & "s")

    End Sub

    Public Sub InitialCheck()
        If Not gblnOutputStable Then
            MsgBox("Connection to MATLAB required.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Dim StartTime As DateTime = System.DateTime.Now 'calculation time
        STIM.Matlab("AA_SOFAstart;")
        STIM.Matlab("this_dir = cd; amt_start('silent'); cd(this_dir);")
        ' Dim target_gain As Double = Val(gconstExp(11).varValue)
        ' Dim lr_dif As Double = Val(gconstExp(12).varValue)
        Dim str() As String = STIM.WorkDir.Split("\"c)
        Dim szErr As String = STIM.Matlab("AA_InitialCheck('" & STIM.WorkDir & "');")
        If Len(szErr) > 0 Then
            MsgBox(szErr, MsgBoxStyle.Critical, "Initial check")
            frmMain.SetStatus("Error in the initial check. Check microphones/speakers.")
        Else
            MsgBox("Initial check successful!", MsgBoxStyle.Information, "Initial check")
        End If
        frmMain.SetStatus("Processing time: " & DateDiff(DateInterval.Second, StartTime, System.DateTime.Now).ToString & "s")

    End Sub

    Public Sub CopyScriptToGenerateSOFA()
        If Not gblnOutputStable Then
            MsgBox("Connection to MATLAB required.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        STIM.Matlab("str = which('run_this_to_generate_sofa');")
        STIM.Matlab("copyfile(str,'.');")

    End Sub

    Public Sub Execute(ByRef lIndex As Integer)
		Dim szX As String
        'Dim lRowBeg, lRowEnd As Integer
		
		'If ItemList.ItemCount > 0 Then
  '          lRowBeg = ItemList.SelectedItemFirst + 1 'compatible to VB6
  '          lRowEnd = ItemList.SelectedItemLast + 1
  '      End If
  
		If lIndex > -1 Then
			' select calculation command
			Select Case glExpType
				Case 2 ' Cosine Gen.
					Select Case lIndex
						Case 0 ' Plot selected
							'ShowStimulus(lRowBeg, lRowEnd)
                            ShowStimulus()
						Case 1 ' Show/calculate THD
							'CalcTHD(lRowBeg, lRowEnd)
                            CalcTHD()
						Case 2 ' Sho/Calculate SINAD
							CalcSINAD()
                            'CalcSINAD(lRowBeg, lRowEnd)
					End Select
				Case 0 ' MLS
					Select Case lIndex
                        Case 0 ' Plot selected
                            'ShowStimulus(lRowBeg, lRowEnd)
                            ShowStimulus()
                        Case 1 ' IR menu
                            If Not gblnOutputStable Then
                                MsgBox("Connection to MATLAB required.", MsgBoxStyle.Critical)
                                Exit Sub
                            End If
                            gblnCancel = False
                            frmIR.ShowDialog()
                            If gblnCancel Then Exit Sub
                            ToolboxIR.ProcessIRForm()
                            'ToolboxIR.ProcessIRForm(lRowBeg, lRowEnd)
                        Case 2 ' Post processing menu
                            If Not gblnOutputStable Then
                                MsgBox("Connection to MATLAB required.", MsgBoxStyle.Critical)
                                Exit Sub
                            End If
                            gblnCancel = False
                            frmPostProcessing.ShowDialog()
                    End Select
				Case 1, 3 ' Sweep, hrtf
					Select Case lIndex
                        Case 0 ' Plot selected
                            'ShowStimulus(lRowBeg, lRowEnd)
                            ShowStimulus()
						Case 1 ' IR Menu
							If Not gblnOutputStable Then
								MsgBox("Connection to MATLAB required.", MsgBoxStyle.Critical)
								Exit Sub
							End If
                            STIM.Matlab("stimPar.WorkDir = '" & STIM.WorkDir & "';")
                            STIM.Matlab("stimPar.ID = '" & STIM.ID & "';")
                            gblnCancel = False
                            frmIR.ShowDialog()
                            If gblnCancel Then Exit Sub
                            Dim StartTime As DateTime = System.DateTime.Now 'calculation time
                            'ToolboxIR.ProcessIRForm(lRowBeg, lRowEnd)
                            ToolboxIR.ProcessIRForm()
                            frmMain.SetStatus("Processing time: " & DateDiff(DateInterval.Second, StartTime, System.DateTime.Now).ToString & "s")
                            'SweeptoIR lRowBeg, lRowEnd
                        Case 2 ' Postprocessing menu
                            If Not gblnOutputStable Then
                                MsgBox("Connection to MATLAB required.", MsgBoxStyle.Critical)
                                Exit Sub
                            End If
                            STIM.Matlab("stimPar.WorkDir = '" & STIM.WorkDir & "';")
                            STIM.Matlab("stimPar.ID = '" & STIM.ID & "';")

                            'Start SOFA
                            szX = "AA_SOFAstart"
                            szX = frmPostProcessing.MatlabCmd(szX)
                            'If InStr(LCase(szErr), "undefined function or variable 'sofastart'") > 0 Then
                            'szErr = "SOFAstart cannot be found! Please download the SOFA package from:" & vbCrLf & "https://sourceforge.net/projects/sofacoustics/" & _
                            '    vbCrLf & "and extract the files to your \MATLAB\SOFA subfolder." & vbCrLf & vbCrLf & vbCrLf & szErr : GoTo SubError
                            'ElseIf InStr(LCase(szErr), "error") > 0 Then
                            '    szErr = "Matlab cannot proceed:" & vbCrLf & szErr : GoTo SubError
                            'End If
                            If InStr(LCase(szX), "error") <> 0 Then MsgBox("SOFAstart cannot be found! Please download the SOFA package from:" & vbCrLf & "https://sourceforge.net/projects/sofacoustics/" & _
                                vbCrLf & "and extract the files to your \MATLAB\SOFA subfolder." & vbCrLf & vbCrLf & vbCrLf & szX, MsgBoxStyle.Critical, "Load SOFA: Error when starting SOFA")

                            gblnCancel = False
                            frmPostProcessing.ShowDialog()
                        Case 3 ' delete stimulation files
                            If MsgBox("expsweep* and invexpsweep* files will be deleted. Proceed?", MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Delete Stimulation Files") = MsgBoxResult.No Then Exit Sub
                            szX = DeleteFile("expsweep*")
                            szX = szX & vbCrLf & DeleteFile("invexpsweep*")
                            If Len(szX) > 2 Then
                                MsgBox(szX, MsgBoxStyle.Critical, "Delete Stimulation Files")
                            End If
                        Case 4 ' Calculate MESM parameters
                            If gblnOutputStable = False Then
                                MsgBox("Not connected to MATLAB.", MsgBoxStyle.Critical, "Connection Error")
                            Else
                                If MsgBox("Use the modern form?" & vbCrLf &  "(single form; multiple eta values; find lowest total time)",MsgBoxStyle.YesNo Or MsgBoxStyle.Question,"Calculate MESM parameters") = MsgBoxResult.Yes Then
                                    frmMESM.ShowDialog
                                Else
                                    CalculateMESM
                                end if

                            End If

                    End Select
            End Select
        End If ' other commands, not turntable

        gblnShowStimulus = False
    End Sub


    Private Sub CalculateMESM()
        Dim lFEnd, lN, lL1, lEta, lK, lL2, lFStart, lTmin As Integer
        Dim dblTnew(0, 0) As Double
        Dim dblTtot(0, 0) As Double
        Dim dblISD(,) As Double
        Dim lTtot As Integer
        Dim lRow, lCol As Integer
        Dim szT, szX As String
        Dim szErr As String
        Dim lX As Integer

        szT = "Calculate MESM parameters"

        ' input boxes
        szX = InputBox("eta (number of interleaved stimulations): ", szT, "3")
        If Len(szX) = 0 Then Exit Sub
        If IsNumeric(szX) Then lEta = CInt(Val(szX))

        szX = InputBox("K (max. number of harmonics): ", szT, "0")
        If Len(szX) = 0 Then Exit Sub
        If IsNumeric(szX) Then lK = CInt(Val(szX))

        szX = InputBox("L1 (length of the linear Impulse Response): ", szT, "0")
        If Len(szX) = 0 Then Exit Sub
        If IsNumeric(szX) Then lL1 = CInt(Val(szX))

        szX = InputBox("L2 (length of second order Harmonic Impulse Response): ", szT, "0")
        If Len(szX) = 0 Then Exit Sub
        If IsNumeric(szX) Then lL2 = CInt(Val(szX))

        szX = InputBox("N (number of systems = number of channel IDs): ", szT, CStr(GetUbound(gElevation) + 1))
        If Len(szX) = 0 Then Exit Sub
        If IsNumeric(szX) Then lN = CInt(Val(szX))

        szX = InputBox("f(start): ", szT, CStr(glFreqStart))
        If Len(szX) = 0 Then Exit Sub
        If IsNumeric(szX) Then lFStart = CInt(Val(szX))

        szX = InputBox("f(end): ", szT, CStr(glFreqEnd))
        If Len(szX) = 0 Then Exit Sub
        If IsNumeric(szX) Then lFEnd = CInt(Val(szX))

        szX = InputBox("Tmin (min. stimulation duration): ", szT, CStr(glPlayLength))
        If Len(szX) = 0 Then Exit Sub
        If IsNumeric(szX) Then lTmin = CInt(Val(szX))

        ' MESM calculation in MATLAB
        szErr = STIM.Matlab("[Tnewcorr,Ttot,ti,ISD]=AA_MESM(" & TStr(lEta) & "," & TStr(lK) & "," & TStr(lL1) & "," & TStr(lL2) & "," & TStr(lN) & "," & TStr(lFStart) & "," & TStr(lFEnd) & "," & TStr(lTmin) & ");")
        If Len(szErr) > 0 Then GoTo SubError

        ' get parameters
        ' Ttot (old & new)
        lTtot = lN * (lTmin + lL1) ' old
        szErr = STIM.MatlabGetRealMatrix2("Ttot", dblTtot) ' new
        If Len(szErr) > 0 Then GoTo SubError
        ' Tnew = PlayLength
        szErr = STIM.MatlabGetRealMatrix2("Tnewcorr", dblTnew)
        If Len(szErr) > 0 Then GoTo SubError

        ' Message Box: Accept new parameters?
        If (MsgBox("Unoptimized Parameters: " & vbCrLf & vbCrLf & vbTab & "Ttot = " & TStr(lTtot) & vbCrLf & vbTab & "Tmin = " & TStr(lTmin) & vbCrLf & vbCrLf & "MESM Parameters: " & vbCrLf & vbCrLf & vbTab & "Ttot = " & TStr(dblTtot(0, 0)) & vbCrLf & vbTab & "Tmin = " & TStr(dblTnew(0, 0)) & vbCrLf & vbCrLf & "Do you want to continue with calculated MESM parameters?", MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1, "MESM")) = MsgBoxResult.No Then
            frmMain.SetStatus("MESM parameters not changed")
            Exit Sub
        End If

        gconstExp(1).varValue = TStr(dblTnew(0, 0))

        'ISD
        szErr = STIM.MatlabGetMatrixSize("ISD", lRow, lCol)
        If Len(szErr) > 0 Then GoTo SubError
        ReDim dblISD(lRow - 1, lCol - 1)
        szErr = STIM.MatlabGetRealMatrix2("ISD", dblISD)
        If Len(szErr) > 0 Then GoTo SubError
        ReDim gvarExp(5).varValue((dblISD).Length - 1)
        For lX = 0 To dblISD.Length - 1
            gvarExp(5).varValue(lX) = TStr(dblISD(lX, 0))
        Next

        'Transfer new variables to Settings
        EventsSettings.OnSet()

        frmMain.SetStatus("MESM parameters successfully calculated")
        Exit Sub

SubError:
        MsgBox(szErr, MsgBoxStyle.Critical, szT)
        frmMain.SetStatus("Error(s) calculating MESM parameters")

    End Sub

    Private Sub ShowStimulus()
    'Private Sub ShowStimulus(ByRef lRowBeg As Integer, ByRef lRowEnd As Integer)
        Dim szPrefix, szX, szY, szName, szErr As String
        'Dim lRow As Integer

        If Not gblnOutputStable Then
            MsgBox("Connection to MATLAB required.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        frmShowStimulus.ShowDialog()
        If Not gblnShowStimulus Then Exit Sub

        With ItemList

            frmMain.SetProgressbar(0)

            Dim Arr() As Integer = Nothing
            szErr = GetRangeArray(Arr, False) 
            If szErr <> "" Then GoTo SubError

            For lArrRow As Integer = 0 To Arr.Length - 1
                szPrefix = Create.CreateRecPrefix(Arr(lArrRow))
                szName = Dir(STIM.WorkDir & "\" & szPrefix & "_*.wav")
                While Len(szName) <> 0
                    ' load file to matlab
                    szX = "rec=audioread('" & STIM.WorkDir & "\" & szName & "');"
                    szY = STIM.Matlab(szX)
                    If Len(szY) <> 0 Then
                        MsgBox("Error loading recorded file." & vbCrLf & "Command line: " & szX & vbCrLf & "Error: " & szY)
                        GoTo SubError
                    End If

                    szX = "stimPar.GenMode=1;stimPar.SamplingRate=" & TStr(glSamplingRate) & ";"
                    szY = STIM.Matlab(szX)
                    If Len(szY) <> 0 Then
                        MsgBox("Error setting parameter." & vbCrLf & "Command line: " & szX & vbCrLf & "Error: " & szY)
                        GoTo SubError
                    End If

                    ' show stimulus
                    If glExpType = 3 Then
                        szX = "FW_ShowStimulus(rec,stimPar,['" & Replace(szName, "_", "\_") & "' 10 'elevation: " + .Item(Arr(lArrRow), "ELEVATION") + "']," + TStr(glShowStimulusFlags) + ");"
                    Else
                        szX = "FW_ShowStimulus(rec,stimPar,['" & Replace(szName, "_", "\_") & "' 10 'channel ID: " + .Item(Arr(lArrRow), "CHANNEL ID") + "']," + TStr(glShowStimulusFlags) + ");"
                    End If
                    szY = STIM.Matlab(szX)
                    If Len(szY) <> 0 Then
                        MsgBox("Error loading recorded file:" & vbCrLf & "Command line: " & szX & vbCrLf & "Error: " & szY)
                        GoTo SubError
                    End If
                    szName = Dir()
                End While
            Next
            
            Exit Sub
SubError:
            MsgBox("Error when showing stimulus:" & vbCrLf & szerr,MsgBoxStyle.Critical,"Show Stimulus")
        End With

    End Sub

    Private Function DeleteFile(ByRef szFile As String) As String
        Dim szErr As String

        If Not STIM.CheckStimulationFile(szFile) Then
            szErr = "Error deleting file " & STIM.WorkDir & "\" & szFile & ": File not found"
            GoTo SubError
        Else
            '' new
            Dim myFile As String
            'Dim mydir As String = "C:\"
            On Error GoTo FSOError
            For Each myFile In System.IO.Directory.GetFiles(STIM.WorkDir, szFile)
                System.IO.File.Delete(myFile)
                On Error GoTo 0
            Next

            ' '' old
            '' delete file
            'szFile = STIM.WorkDir & "\" & szFile
            'On Error GoTo FSOError
            'System.IO.File.Delete(szFile)
            'On Error GoTo 0
            ' '' old end
        End If

        frmMain.SetStatus("Deleted: " & szFile)
        Return ""

SubError:
        Return szErr

FSOError:
        Return "Error deleting file " & szFile & ": " & Err.Description
    End Function
End Module