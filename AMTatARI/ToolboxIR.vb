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
Module ToolboxIR

    Public Structure IRFlags
        Dim CalcResults As Boolean
        Dim CalcLinear As Boolean
        Dim SaveLinearToMAT As Boolean
        Dim SaveLinearToWAV As Boolean
        Dim SaveIR As Boolean
        Dim KeepVar As Boolean
        Dim PlotIR As Boolean
        Dim ShowLatency As Boolean
        Dim KeepTemp As Boolean
        'Dim GaborMult As Boolean
        Dim CreateMatrix As Boolean
        Dim PlotMatrix As Boolean
        'Dim SaveWorkspace As Boolean
        Dim CopyLatency As Boolean
        Dim FirstCheck As Boolean
        Dim SaveM As Boolean
        Dim SaveSOFA As Boolean
        Dim ProcessItemRange As Boolean
    End Structure

    Public Structure PlothMParameters
        Dim Title As String
        Dim Valid As Boolean
        Dim Flags As Integer
        Dim Parameter As Integer
        Dim RecChannel As String
        Dim Filter As String
        Dim Axes As String
        Dim OptionalParameters As String
    End Structure

    Public gphmParameters As Generic.List(Of PlothMParameterSet)
    Public gphmCurrent As New PlothMParameterSet
    Public gPlotToaCurrentParameters As Integer


    public Function GetRangeArray(byref lArr() as Integer, Optional bUseRangeCheckbox As Boolean = True) As String
        'Dim lArr() As Integer 'output
        'Dim szErr As String

        If ItemList.ItemCount<1 Then Return "Not Items in item list."

        ' get array with indices which items to process in impulse response toolbox
        If bUseRangeCheckbox AndAlso gIRFlags.ProcessItemRange Then ' define range
            ' checks
            If val(frmIR.txtItemRangeMin.Text) < 1 Then Return "Range below zero Not allowed."
            If val(frmIR.txtItemRangeMin.Text) > val(frmIR.txtItemRangeMax.Text) Then Return "Range upper limit must be higher than lower limit."

            ' calculation
            dim lRowBeg As Integer = CInt(Val(frmIR.txtItemRangeMin.Text))-1
            dim lRowEnd As Integer = CInt(Val(frmIR.txtItemRangeMax.Text))-1

            ReDim lArr (lRowEnd-lRowBeg)
            Dim lArrayIndex As Integer = 0

            For lX As Integer = lRowBeg To lRowEnd 
                lArr(lArrayIndex) = lX
                lArrayIndex+=1
            next
             
        Else ' selected items only

            If ItemList.SelectedItems.Count=0 Then Return "Not Items selected."
            lArr = ItemList.SelectedItems  
        End If

        'no error:
        Return ""

    End Function

    Public Sub ProcessIRForm()
        Dim szX As String

        ' Calculate results
        If gIRFlags.CalcResults Then
            Select Case glExpType
                Case 0 ' MLS
                    MLStoIR()
                    'MLStoIR(lRowBeg, lRowEnd)
                Case 1, 3 ' Sweep, hrtf
                    SweeptoIR(False)
                    'SweeptoIR(gIRFlags.GaborMult)
                    'SweeptoIR(lRowBeg, lRowEnd, gIRFlags.GaborMult)
            End Select
        End If

        ' Show latency for selected items
        If gIRFlags.ShowLatency Then
            ShowLatency()
            'ShowLatency(lRowBeg, lRowEnd)
        End If

        ' Plot IRs for selected items
        If gIRFlags.PlotIR Then
            'PlotIR(lRowBeg, lRowEnd)
            PlotIR()
        End If

        ' Save selected items
        If gIRFlags.SaveIR Then
            SaveIR()
            'SaveIR(lRowBeg, lRowEnd)
        End If

        ' clear temporary data in MATLAB
        If Not gIRFlags.KeepTemp Then
            szX = STIM.Matlab("clear *X stimVec")
            If Len(szX) > 0 Then
                MsgBox(szX, MsgBoxStyle.Critical, "Error")
            Else
                frmMain.SetStatus("Temporary variables (*X stimVec) cleared.")
            End If
        End If

        ' create linear IR matrix
        If gIRFlags.CalcLinear Then
            CalcLinear()
            'CalcLinear(lRowBeg, lRowEnd)
        End If

        ' save IR linear to MAT
        If gIRFlags.SaveLinearToMAT Then
            frmMain.SetStatus("Saving linear to .MAT ...")
            'szX = "version('-release');"
            'szX = STIM.Matlab(szX)
            'If Val(szX) < 14 Then
                szX = "save('" & STIM.WorkDir & "\" & STIM.ID & "_LIN.mat', 'hLIN', 'idxLIN', 'IRnrLIN', 'itemnrLIN','latLIN', 'posLIN','ampLIN','stimPar');"
            'Else
            '    szX = "save('" & STIM.WorkDir & "\" & STIM.ID & "_LIN.mat', 'hLIN', 'idxLIN', 'IRnrLIN', 'itemnrLIN','latLIN', 'posLIN','ampLIN','stimPar','-V6');"
            'End If
            szX = STIM.Matlab(szX)
            If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Save IR linear to MAT: Error") : Exit Sub
            frmMain.SetStatus("Linear data (*LIN) saved to " & STIM.WorkDir & "\" & STIM.ID & "_LIN.mat")
        End If

        ' save IR matrix to WAV
        If gIRFlags.SaveLinearToWAV Then
            'SaveLinearToWAV(lRowBeg, lRowEnd)
            SaveLinearToWAV()
        End If

        ' copy latency
        If gIRFlags.CopyLatency Then
            frmLatency.ShowDialog()
        End If

        ' clear results in MATLAB
        If gIRFlags.CalcLinear and not gIRFlags.KeepVar Then
            szX = STIM.Matlab("clear *X *C stimVec")
            If Len(szX) > 0 Then
                MsgBox(szX, MsgBoxStyle.Critical, "Error")
            else
                frmMain.SetStatus("All old and temporary data, except stimPar, cleared.")
            End If
        End If

        ' reshaped from hLIN to SOFA object
        If gIRFlags.CreateMatrix Then
            If gRecStream IsNot Nothing then
                szX = STIM.Matlab("gRecStream=" & TStr(UBound(gRecStream)) & ";")
                If Len(szX) > 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Error")
            end if

            'Add some SOFA object parameters
            szX = STIM.Matlab("AA_hM;")
            If Len(szX) > 0 Then
                MsgBox(szX, MsgBoxStyle.Critical, "Error")
            Else
                frmMain.SetStatus("SOFA object created")
            End If

            szX = STIM.Matlab("clear hLIN idxLIN")
            If Len(szX) > 0 Then
                MsgBox(szX, MsgBoxStyle.Critical, "Error")
            Else
                frmMain.SetStatus("cleared hLIN and idxLIN")
            End If

        End If

        If gIRFlags.FirstCheck Then
            '    Debug.Print "First Check"
            '    frmMain.SetStatus "First Check of SOFA object in progress..."
            '    DoEvents
            If FirstCheck() <> "" Then Exit Sub
        End If

        If gIRFlags.SaveSOFA Then
            frmMain.SetStatus("Saving SOFA")
            frmPostProcessing.SOFAsave()
        End If

        If gIRFlags.SaveM Then
            frmMain.SetStatus("Saving SOFA object and structured meta data")
            SaveM()
        End If

    End Sub

    '    Public Sub ProcessIRFormOLD(ByRef lRowBeg As Integer, ByRef lRowEnd As Integer)
    '    Dim szX As String

    '    If gIRFlags.ProcessItemRange Then
    '        lRowBeg = CInt(Val(frmIR.txtItemRangeMin.Text))
    '        lRowEnd = CInt(Val(frmIR.txtItemRangeMax.Text))
    '    End If

    '    ' Calculate results
    '    If gIRFlags.CalcResults Then
    '        Select Case glExpType
    '            Case 0 ' MLS
    '                'MLStoIR(lRowBeg, lRowEnd)
    '                MLStoIR()
    '            Case 1, 3 ' Sweep, hrtf
    '                SweeptoIR(gIRFlags.GaborMult)
    '                'SweeptoIR(lRowBeg, lRowEnd, gIRFlags.GaborMult)
    '        End Select
    '    End If

    '    ' Show latency for selected items
    '    If gIRFlags.ShowLatency Then
    '        ShowLatency(lRowBeg, lRowEnd)
    '    End If

    '    ' Plot IRs for selected items
    '    If gIRFlags.PlotIR Then
    '        PlotIR(lRowBeg, lRowEnd)
    '    End If

    '    ' Save selected items
    '    If gIRFlags.SaveIR Then
    '        SaveIR(lRowBeg, lRowEnd)
    '    End If

    '    ' clear temporary data in MATLAB
    '    If gIRFlags.ClearTemp Then
    '        szX = STIM.Matlab("clear *X stimVec")
    '        If Len(szX) > 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Error")
    '        frmMain.SetStatus("Temporary variables (*X stimVec) cleared.")
    '    End If

    '    ' create linear IR matrix
    '    If gIRFlags.CalcLinear Then
    '        CalcLinear(lRowBeg, lRowEnd)
    '    End If

    '    ' save IR linear to MAT
    '    If gIRFlags.SaveLinearToMAT Then
    '        frmMain.SetStatus("Saving linear to .MAT ...")
    '        szX = "version('-release');"
    '        szX = STIM.Matlab(szX)
    '        If Val(szX) < 14 Then
    '            szX = "save('" & STIM.WorkDir & "\" & STIM.ID & "_LIN.mat', 'hLIN', 'idxLIN', 'IRnrLIN', 'itemnrLIN','latLIN', 'posLIN','ampLIN','stimPar');"
    '        Else
    '            szX = "save('" & STIM.WorkDir & "\" & STIM.ID & "_LIN.mat', 'hLIN', 'idxLIN', 'IRnrLIN', 'itemnrLIN','latLIN', 'posLIN','ampLIN','stimPar','-V6');"
    '        End If
    '        szX = STIM.Matlab(szX)
    '        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Save IR linear to MAT: Error") : Exit Sub
    '        frmMain.SetStatus("Linear data (*LIN) saved to " & STIM.WorkDir & "\" & STIM.ID & "_LIN.mat")
    '    End If

    '    ' save IR matrix to WAV
    '    If gIRFlags.SaveLinearToWAV Then
    '        SaveLinearToWAV(lRowBeg, lRowEnd)
    '    End If

    '    ' copy latency
    '    If gIRFlags.CopyLatency Then
    '        frmLatency.ShowDialog()
    '    End If

    '    ' clear results in MATLAB
    '    If gIRFlags.ClearVar Then
    '        szX = STIM.Matlab("clear *X *C stimVec")
    '        If Len(szX) > 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Error")
    '        frmMain.SetStatus("All data, but stimPar, cleared.")
    '    End If

    '    ' reshaped from hLIN to h-M
    '    If gIRFlags.CreateMatrix Then

    '        szX = STIM.Matlab("gRecStream=" & TStr(UBound(gRecStream)) & ";")
    '        If Len(szX) > 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Error")

    '        'Add some h-M SOFA parameters
    '        szX = STIM.Matlab("AA_h-M;")
    '        If Len(szX) > 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Error")
    '        frmMain.SetStatus("SOFA object created")

    '        szX = STIM.Matlab("clear hLIN idxLIN")
    '        If Len(szX) > 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Error")
    '        frmMain.SetStatus("cleared hLIN and idxLIN")

    '    End If

    '    If gIRFlags.FirstCheck Then
    '        '    Debug.Print "First Check"
    '        '    frmMain.SetStatus "First Check of h-M in progress..."
    '        '    DoEvents
    '        If FirstCheck() <> "" Then Exit Sub
    '    End If

    '    If gIRFlags.SaveSOFA Then
    '        frmMain.SetStatus("Saving SOFA")
    '        frmPostProcessing.SOFAsave()
    '    End If

    '    If gIRFlags.SaveM Then
    '        frmMain.SetStatus("Saving h-M and structured meta data")
    '        SaveM()
    '    End If

    'End Sub

    Private Function FirstCheck() As String
        Dim szX As String
        Dim szErr As String = ""
        Dim lCols, lRows, lX As Integer
        Dim szLevel As String
        Dim dblFirstCheck(,) As Double
        'Dim szLeft As String, szRight As String, lTO As Long
        'Dim inpX As New frmInputBox

        frmMain.SetStatus("First Check of structured meta data in progress...")

        '  inpX.add "Set Level for First Check", vfNumeric, -25, "dB", -1000, 0
        '  If Not inpX.ShowForm("First Check of h-M") Then Set inpX = Nothing: szErr = "Setting Level for First Check of h-M cancelled": GoTo SubError
        szLevel = frmIR.txtFirstCheck.Text.ToString
        'szLevel = InputBox("Set Level for First Check of h-M." & vbCrLf & vbCrLf & "All measurements below this value will be detected and can be repeated:", "First Check of h-M", CStr(-25))
        'If Len(szLevel) = 0 Then szErr = "Cancelled: No value entered for First check of h-M!" : GoTo SubError
        If IsNumeric(szLevel) = False Then szErr = "Level Value must be numeric!" : GoTo SubError
        STIM.Matlab("clear fc_*;")
        '  szX = STIM.Matlab("fc_idx=find(20*log10(squeeze(sum(abs(h-M(:,:,1)),1)))<" & inpX.GetValue(0) & ");")
        'szX = STIM.Matlab("fc_idx=find(20*log10(squeeze(sum(abs(h-M(:,:,1)),1)))<" & szLevel & ");")
        'If Len(szX) <> 0 Then szErr = "First Check of h-M: " & szX : GoTo SubError
        szX = STIM.Matlab("fc_idx=find(20*log10(squeeze(sum(abs(Obj.Data.IR(:," & tstr(frmIR.numFirstCheckChannel.Value) & ",:)),3)))<" & szLevel & ");")
        If Len(szX) <> 0 Then szErr = "First Check of SOFA object: " & szX : GoTo SubError

        szX = STIM.Matlab("fc_jj=1;for fc_ii=1:length(fc_idx); if fc_ii==1; fc_idx2(fc_jj)=meta.itemidx(fc_idx(fc_ii)); fc_jj=fc_jj+1; elseif fc_ii>1; if meta.itemidx(fc_idx(fc_ii)) ~= meta.itemidx(fc_idx(fc_ii-1)); fc_idx2(fc_jj)=meta.itemidx(fc_idx(fc_ii));  fc_jj=fc_jj+1; end ; end;end;")
        If Len(szX) <> 0 Then szErr = "First Check of SOFA object: " & szX : GoTo SubError
        szX = STIM.Matlab("if exist('fc_idx2');fc_idx=fc_idx2;end;")
        If Len(szX) > 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Error") : GoTo SubError

        szX = STIM.MatlabGetMatrixSize("fc_idx", lRows, lCols)
        Debug.Print(szX)
        If Len(szX) <> 0 Then szErr = "First Check of SOFA object: " & szX : GoTo SubError
        If lRows < 1 Or lCols < 1 Then
            frmMain.SetStatus("First Check of SOFA object finished successfully: No errors found.")
            GoTo SubEnd
        End If

        ReDim dblFirstCheck(lRows - 1, lCols - 1)
        szX = STIM.MatlabGetRealMatrix2("fc_idx", dblFirstCheck)
        If Len(szX) <> 0 Then szErr = "First Check of SOFA object: " & szX : GoTo SubError
        szX = STIM.Matlab("clear fc_*;")
        If Len(szX) <> 0 Then szErr = "First Check of SOFA object: " & szX : GoTo SubError
        frmMain.SetStatus("First Check of SOFA object finished: " & TStr(lCols) & " bad measurement(s) found!")
        'szErr = "The following " & TStr(lCols) & " measurement(s) are probably not stimulated properly (level                                                      is below " & szLevel & " dB)" & vbCrLf & "and should be repeated!" & vbCrLf & vbCrLf & "Index" & vbTab & "Azimuth"
        'szErr = "The following " & TStr(lCols) & " measurement(s) are probably not stimulated properly (level for channel " & TStr(frmIR.numFirstCheckChannel.Value) & _
        '    " is below " & szLevel & " dB) and should be repeated if this channel is supposed to have a higher level!" & vbCrLf & vbCrLf & "Index" & vbTab & "Azimuth"
        szErr = "The level of the following " & TStr(lCols) & " measurement(s) is below " & szLevel & " dB in record channel " & TStr(frmIR.numFirstCheckChannel.Value) & ":" & vbCrLf & vbCrLf & "Index" & vbTab & "Azimuth"
        For lX = 0 To UBound(dblFirstCheck, 2)
            szErr = szErr & vbCrLf & dblFirstCheck(0, lX) & vbTab & ItemList.Item(CInt(dblFirstCheck(0, lX)) - 1, 1)
        Next

        If Len(szX) <> 0 Then szErr = "First Check of SOFA object: " & szX : GoTo SubError

        MsgBox(szErr, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "First Check of SOFA object")
        'szErr = ""
        Return "One or more measurement levels too low!"

SubError:
        frmMain.SetStatus("First Check of SOFA object: Error!")
        MsgBox(szErr, MsgBoxStyle.Critical, "First Check of SOFA object")
        Return "Error"

SubEnd:
        Return ""
    End Function

    Private Sub SaveM()
        Dim szX, szY As String
        Dim lX As Integer
        Dim lY As Integer = 0
        Dim szListItems() As String = Nothing

        'szX = "version('-release');"
        'szVer = STIM.Matlab(szX)

        szX = Dir(STIM.WorkDir & "\" & STIM.ID & "_M_*.mat")
        If Len(szX) > 0 Then
            szY = "Files with following postfixes could be found until now:" & vbCrLf
        Else
            szY = "No files available until now."
        End If
        'While Len(szX) > 0
        '    lX = Len(STIM.ID & "_M_")
        '    szY = szY & vbTab & Mid(szX, lX + 1, Len(szX) - lX - Len(".mat")) & vbCrLf
        '    szX = Dir()
        'End While

        'szY = InputBox("Input the postfix of the file: (File name will be: ID_postfix.mat)" & vbCrLf & szY, "Save *M as .MAT", "test")
        'If Len(szY) = 0 Then Exit Sub

        While Len(szX) > 0
            lX = Len(STIM.ID & "_M_")
            szY = szY & vbTab & Mid(szX, lX + 1, Len(szX) - lX - Len(".mat")) & vbCrLf
            ReDim Preserve szListItems(lY)
            szListItems(lY) = Mid(szX, lX + 1, Len(szX) - lX - Len(".mat"))

            szX = Dir()
            lY += 1

        End While
        frmListbox.txtName.Text = "" 'clear text box of form:
        szY = frmListbox.Init("Input the postfix of the file (File Name will be: ID_postfix.mat)" & vbCrLf & vbCrLf & "Files with following postfixes are available:", "Save *M to .MAT", szListItems)
        'If Len(szY) = 0 Then MsgBox("*M NOT saved to .MAT!", MsgBoxStyle.Exclamation, "Save *M to .MAT") : Exit Sub
        If Len(szY) = 0 Then
            If frmListbox.DialogResult = Windows.Forms.DialogResult.OK Then MsgBox("*M NOT saved to .MAT!", MsgBoxStyle.Exclamation, "Save *M to .MAT")
            Exit Sub
        End If

        STIM.Matlab("stimPar.WorkDir = '" & STIM.WorkDir & "';")
        STIM.Matlab("stimPar.ID = '" & STIM.ID & "';")

        frmMain.SetStatus("Saving data to " & szY & ".mat file...")
        ''don't save WorkDir in stimPar
        'szX = "TempWorkDir=stimPar.WorkDir;" 'temp folder name
        'szX = STIM.Matlab(szX)
        'If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Save *M to MAT: Error when setting WorkDir!") : Exit Sub

        'szX = "stimPar.WorkDir='';" 'clear original folder name
        'szX = STIM.Matlab(szX)
        'If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Save *M to MAT: Error when setting WorkDir!" & vbCrLf & "Current WorkDir may be wrong!") : Exit Sub
        'If Val(szVer) < 14 Then
            szX = "AA_SaveMat([TempWorkDir '\' stimPar.ID '_M_" & szY & ".mat'],Obj,stimPar,meta,'');"
        'Else
        '    szX = "AA_SaveMat([TempWorkDir '\' stimPar.ID '_M_" & szY & ".mat'],Obj,stimPar,meta,'-V6');"
        'End If
        szX = STIM.Matlab(szX)
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Save SOFA object to MAT: Error") : Exit Sub
        'szX = "stimPar.WorkDir=TempWorkDir;" 'restore original folder name
        'szX = STIM.Matlab(szX)
        'If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Save *M to MAT: Error when resetting WorkDir!" & vbCrLf & "Current WorkDir may be wrong!") : Exit Sub
        frmMain.SetStatus("SOFA object and structured meta data saved to " & STIM.WorkDir & "\" & STIM.ID & "_M_" & szY & ".mat")

    End Sub


    Sub SaveLinearToWAV()
    'Sub SaveLinearToWAV(ByRef lRowBeg As Integer, ByRef lRowEnd As Integer)
    'indices not used anyway....

        Dim szX, szErr, szY As String

        gblnCancel = False

        frmMain.SetProgressbar(0)
        szErr = ""

        ' set parameters
        ' ....
        ' set .ID
        szX = "stimPar.ID='" & STIM.ID & "';"
        szY = STIM.Matlab(szX)
        If Len(szY) <> 0 Then szErr = szErr & szX & vbCrLf & szY : GoTo SubError
        ' set .StimFileName
        szX = "stimPar.StimFileName='" & STIM.WorkDir & "\" & STIM.ID & "_ALL';"
        szY = STIM.Matlab(szX)
        If Len(szY) <> 0 Then szErr = szErr & szX & vbCrLf & szY : GoTo SubError
        ' start SaveLinearToWAV
        frmMain.SetStatus("Saving linear data...")
        szX = "AA_SaveLinearToWAV;"
        szY = STIM.Matlab(szX)
        If Len(szY) <> 0 Then szErr = szErr & szX & vbCrLf & szY : GoTo SubError

        frmMain.SetStatus("Linear data (*LIN) saved to " & STIM.WorkDir & "\" & STIM.ID & "_ALL_*...")

        Exit Sub

SubError:
        MsgBox(szErr, MsgBoxStyle.Critical, "Save IR: Error")

        Exit Sub
    End Sub


    Sub CalcLinear()
    'Sub CalcLinear(ByRef lRowBeg As Integer, ByRef lRowEnd As Integer)
        Dim lY, lX As Integer
        Dim szX, szErr, szY As String
        Dim dblArr(,) As Double

        ' get size of hC{}
        szX = STIM.MatlabGetMatrixSize("hC", lY, lX)
        If Len(szX) > 0 Then
            szErr = "Get Size of hC: " & szX
            GoTo SubError
        End If
        
        ''checks
        'If lX < lRowBeg Then
        '    szErr = "IR matrix not defined for items beginning from " & TStr(lRowBeg)
        '    GoTo SubError
        'End If
        'If lX < lRowEnd Then lRowEnd = lX

        gblnCancel = False

        frmMain.SetProgressbar(0)
        szErr = ""

        
        'For lRow = lRowBeg To lRowEnd
        'Dim Arr() As Integer = GetRangeArray 'treat selected items only
        Dim Arr() As Integer = Nothing
        szErr = GetRangeArray(Arr) 
        If szErr <> "" Then GoTo SubError

        ' set ibegQ
        szX = "ibegQ=" & TStr(Arr(0)+1) & ";"
        szY = STIM.Matlab(szX)
        If Len(szY) <> 0 Then szErr = szErr & szX & vbCrLf & szY : GoTo SubError
        ' set iendQ
        szX = "iendQ=" & TStr(Arr(Arr.Length-1)+1) & ";"
        szY = STIM.Matlab(szX)
        If Len(szY) <> 0 Then szErr = szErr & szX & vbCrLf & szY : GoTo SubError
        ' start CalcLinearMatrix
        szX = "AA_CalcLinearMatrix;"
        szY = STIM.Matlab(szX)
        If Len(szY) <> 0 Then szErr = szErr & szX & vbCrLf & szY : GoTo SubError
        frmMain.SetStatus("Linear data (*LIN) created in workspace")

        If glExpType = 3 Then
            szX = "posLIN=AA_CalcPositions(posLIN," & gconstExp(10).varValue & ");"
            szY = STIM.Matlab(szX)
            If Len(szY) <> 0 Then szErr = szErr & szX & vbCrLf & szY : GoTo SubError
            frmMain.SetStatus("Azimuth angles decoded (turntable -> HRTF)")
        End If

        ' get size of itemnrLIN
        szX = STIM.MatlabGetMatrixSize("itemnrLIN", lY, lX)
        If Len(szX) > 0 Then szErr = "Get Size of itemnrLIN: " & szX : GoTo SubError
        If lY < 1 And lX < 1 Then szErr = "itemnrLIN is empty." : GoTo SubError
        ReDim dblArr(lY - 1, lX - 1)
        szX = STIM.MatlabGetRealMatrix2("itemnrLIN", dblArr)
        If Len(szX) > 0 Then szErr = "Get itemnrLIN: " & szX : GoTo SubError
        For lArrRow As Integer = 0 To Arr.Length - 1
        'For lRow = lRowBeg To lRowEnd
            ItemList.Item(Arr(lArrRow), "STATUS") = "Error"
        Next
        For lDRow As Integer = 0 To UBound(dblArr, 1)
            lY = CInt(Val(dblArr(lDRow, 0)))
            ItemList.Item(lY - 1, "STATUS") = "Linear"
        Next

        Exit Sub

SubError:
        MsgBox(szErr, MsgBoxStyle.Critical, "Calc linear: Error")

        Exit Sub
    End Sub

    'Sub PlotIR(ByRef lRowBeg As Integer, ByRef lRowEnd As Integer)
    Sub PlotIR()
        Dim lY, lX, lRec As Integer
        Dim szErr As String = ""
        Dim szX, szY As String

        szX = InputBox("Input the index of the record stream (*=all): ", "Plot IR", "1")
        If Len(szX) = 0 Then Exit Sub
        If szX = "*" Then
            lRec = -1
        Else
            lRec = CInt(Val(szX) - 1)
            If lRec > GetUbound(gRecStream) Or lRec < 0 Then szErr = "Record stream not found." : GoTo SubError
        End If

        ' get size of latC{}
        szX = STIM.MatlabGetMatrixSize("hC", lY, lX)
        If Len(szX) > 0 Then
            szErr = "Get Size of hC: " & szX
            GoTo SubError
        End If


        'Dim Arr() As Integer = GetRangeArray 'treat selected items only
        Dim Arr() As Integer = Nothing
        szErr = GetRangeArray(Arr) 
        If szErr <> "" Then GoTo SubError

        
        ''checks
        'If lX < lRowBeg Then
        '    szErr = "IR matrix not defined for items beginning from " & TStr(lRowBeg)
        '    GoTo SubError
        'End If
        'If lX < lRowEnd Then lRowEnd = lX

        gblnCancel = False

        frmMain.SetProgressbar(0)

        'For lRow = lRowBeg To lRowEnd
        For lArrRow As Integer = 0 To Arr.Length - 1

            ' hX = hC{lRow};
            szX = "hX=hC{" & TStr(Arr(lArrRow)+1) & "};"
            szY = STIM.Matlab(szX)
            If Len(szY) <> 0 Then szErr = szErr & "Item #" & TStr(Arr(lArrRow)+1) & ": hX=hC{item}: " & szY : GoTo SubError
            ' lY, lX = SIZE(hX)
            szY = STIM.MatlabGetMatrixSize("hX", lY, lX)
            If Len(szY) > 0 Then szErr = szErr & "Item #" & TStr(Arr(lArrRow)+1) & ": Get Size of hX: " & szY : GoTo SubError
            If lY < 1 And lX < 1 Then
                szErr = szErr & "Item #" & TStr(Arr(lArrRow)+1) & ": Latency matrix is empty." & vbCrLf
                GoTo NextItem
            End If
            ' plot IR
            If glExpType = 3 Then szY = "ELEVATION" Else szY = "CHANNEL ID"
            If lRec = -1 Then
                szX = "FW_ShowStimulus(hX,stimPar,'Index: " & TStr(Arr(lArrRow)) & "; elevation: [" + ItemList.Item(Arr(lArrRow) - 1, szY) + "]'," + TStr(glShowStimulusFlags) + ");"
            Else
                szX = "FW_ShowStimulus(hX(:," & TStr(lRec + 1) & "),stimPar,'Index: " & TStr(Arr(lArrRow)) & "; record stream: " + gRecStream(lRec) + "; " + "; elevation: [" + ItemList.Item(Arr(lArrRow) - 1, szY) + "]'," + TStr(glShowStimulusFlags) + ");"
            End If
            szY = STIM.Matlab(szX)
            If Len(szY) <> 0 Then szErr = szErr & "Item #" & TStr(Arr(lArrRow)+1) & ": ShowStimulus: " & szY : GoTo SubError
            ItemList.Item(Arr(lArrRow), "STATUS") = "IR plotted"
NextItem:
            System.Windows.Forms.Application.DoEvents()
            frmMain.SetProgressbar((lArrRow + 1) / (Arr.Length) * 100)

            If gblnCancel Then GoTo SubError
        Next
        If Len(szErr) <> 0 Then
            MsgBox(szErr, MsgBoxStyle.Information, "Plot IR: Warnings:")
        End If

        Exit Sub

SubError:
        MsgBox(szErr, MsgBoxStyle.Critical, "Plot IR: Error")

    End Sub


    Sub SaveIR()
    'Sub SaveIR(ByRef lRowBeg As Integer, ByRef lRowEnd As Integer)
        Dim lY, lX As Integer
        Dim szPrefix, szX, szErr, szY As String

        ' get size of hC{}
        szX = STIM.MatlabGetMatrixSize("hC", lY, lX)
        If Len(szX) > 0 Then
            szErr = "Get Size of hC: " & szX
            GoTo SubError
        End If

        '' checks
        'If lX < lRowBeg Then
        '    szErr = "IR matrix not defined for items beginning from " & TStr(lRowBeg)
        '    GoTo SubError
        'End If
        'If lX < lRowEnd Then lRowEnd = lX

        gblnCancel = False

        frmMain.SetProgressbar(0)
        szErr = ""

        'For lRow = lRowBeg To lRowEnd
        'Dim Arr() As Integer = GetRangeArray 'treat selected items only
        Dim Arr() As Integer = Nothing
        szErr = GetRangeArray(Arr) 
        If szErr <> "" Then GoTo SubError

        For lArrRow As Integer = 0 To Arr.Length - 1
        'For lRow = lRowBeg To lRowEnd
            ItemList.Item(Arr(lArrRow), "STATUS") = "Error"
            szX = "hLIN=hC{" & TStr(Arr(lArrRow) + 1) & "};"
            szY = STIM.Matlab(szX)
            If Len(szY) <> 0 Then szErr = szErr & "Item #" & TStr(Arr(lArrRow)) & ": hLIN=hC{item}: " & szY : GoTo SubError
            szY = STIM.MatlabGetMatrixSize("hLIN", lY, lX)
            If Len(szY) > 0 Then szErr = szErr & "Item #" & TStr(Arr(lArrRow)) & ": Get Size of hLIN: " & szY : GoTo SubError
            If lY < 1 And lX < 1 Then
                szErr = szErr & "Item #" & TStr(Arr(lArrRow)) & ": IR matrix is empty. Item not saved." & vbCrLf
                GoTo NextItem
            End If
            ' idxLIN = idxC{lRow};
            szX = "idxLIN=idxC{" & TStr(Arr(lArrRow) + 1) & "};"
            szY = STIM.Matlab(szX)
            If Len(szY) <> 0 Then szErr = szErr & "Item #" & TStr(Arr(lArrRow)) & ": idxLIN=idxC{item}: " & szY : GoTo SubError
            ' latLIN = latC{lRow};
            szX = "latLIN=latC{" & TStr(Arr(lArrRow) + 1) & "};"
            szY = STIM.Matlab(szX)
            If Len(szY) <> 0 Then szErr = szErr & "Item #" & TStr(Arr(lArrRow)) & ": latLIN=latC{item}: " & szY : GoTo SubError
            ' ampLIN = ampC{lRow};
            szX = "ampLIN=ampC{" & TStr(Arr(lArrRow) + 1) & "};"
            szY = STIM.Matlab(szX)
            If Len(szY) <> 0 Then szErr = szErr & "Item #" & TStr(Arr(lArrRow)) & ": ampLIN=ampC{item}: " & szY : GoTo SubError
            ' posLIN = posC{lRow};
            szX = "posLIN=posC{" & TStr(Arr(lArrRow) + 1) & "};"
            szY = STIM.Matlab(szX)
            If Len(szY) <> 0 Then szErr = szErr & "Item #" & TStr(Arr(lArrRow)) & ": posLIN=posC{item}: " & szY : GoTo SubError
            ' itemLIN = lRow;
            szX = "itemLIN=" & TStr(Arr(lArrRow) + 1) & ";"
            szY = STIM.Matlab(szX)
            If Len(szY) <> 0 Then szErr = szErr & "Item #" & TStr(Arr(lArrRow)) & ": itemLIN=item: " & szY : GoTo SubError
            ' Save(Prefix_item.mat, 'hLIN', 'latLIN', 'idxLIN', 'itemLIN','posLIN','ampLIN','-V6');
            szPrefix = STIM.WorkDir & "\" & Create.CreateRecPrefix(Arr(lArrRow))
            'szX = "version('-release');"
            'szX = STIM.Matlab(szX)
            'If Val(szX) < 14 Then
                szX = "save('" & szPrefix & ".mat', 'hLIN', 'latLIN', 'idxLIN', 'itemLIN','posLIN','ampLIN');"
            'Else
            '    szX = "save('" & szPrefix & ".mat', 'hLIN', 'latLIN', 'idxLIN', 'itemLIN','posLIN','ampLIN','-V6');"
            'End If
            szY = STIM.Matlab(szX)
            If Len(szY) <> 0 Then szErr = szErr & "Item #" & TStr(Arr(lArrRow)) & ": " & szX & ": " & szY : GoTo SubError
            ItemList.Item(Arr(lArrRow), "STATUS") = "Save OK"
            frmMain.SetStatus("Item #" & TStr(Arr(lArrRow) + 1) & ": data saved.")
NextItem:
            'frmMain.SetProgressbar(Arr(lArrRow) / (Arr.Length - 1) * 100)
            frmMain.SetProgressbar((lArrRow + 1) / (Arr.Length) * 100)
            System.Windows.Forms.Application.DoEvents()
            If gblnCancel Then GoTo SubError
        Next
        If Len(szErr) <> 0 Then
            MsgBox(szErr, MsgBoxStyle.Information, "Save IR: Warnings:")
        End If

        Exit Sub

SubError:
        MsgBox(szErr, MsgBoxStyle.Critical, "Save IR: Error")

        Exit Sub
    End Sub

    Public Sub CalcTHD()
    'Public Sub CalcTHD(ByRef lRowBeg As Integer, ByRef lRowEnd As Integer)
        
        Dim lNr As Integer
        Dim szY, szX, szName, szPrefix As String
        Dim sAmp, sFreq As Double
        Dim szErr As String
        Dim lCh, lAzimuth As Integer
        Dim gsTHDTheta As Double
        Dim blnShow As Boolean
        Dim frmX As New frmResult
        frmX.Init()
        Dim lColMax As Integer

        If MsgBox("Plot results?" & vbCrLf & "If you choose 'No', calculation only will be performed.", MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then blnShow = True


        gblnCancel = False

        'Dim Arr() as Integer = GetRangeArray
        Dim Arr() As Integer = Nothing
        szErr = GetRangeArray(Arr) 
        If szErr <> "" Then GoTo SubError

        frmX.Init()

        'frmX.ResultList.Cols = 1
        frmX.ResultList.AddCol("")
        frmX.ResultList.ItemCount = 2 + Arr.Length - 1 ' - lRowBeg
        frmX.ResultList.Item(0, 0) = "Index"
        lColMax = 1

        For lArrRow As Integer = 0 To Arr.Length - 1
            ' get parameters
            With ItemList
                If Not IsNumeric(.Item(Arr(lArrRow) - 1, "CHANNEL ID")) Then
                    szErr = "Channel ID must be a valid numeric."
                    MsgBox(szErr, MsgBoxStyle.Critical, "CalcTHD")
                    GoTo SubError
                End If
                lCh = GetChannelFromElevation(Val(.Item(Arr(lArrRow) - 1, "CHANNEL ID")))
                If lCh < 1 Then
                    szErr = "Channel ID '" + .Item(Arr(lArrRow) - 1, "CHANNEL ID") + "' not specified."
                    MsgBox(szErr, MsgBoxStyle.Critical, "CalcTHD")
                    GoTo SubError
                End If
                sAmp = Val(.Item(Arr(lArrRow) - 1, "AMP"))
                sFreq = Val(.Item(Arr(lArrRow) - 1, "FREQ"))
                lAzimuth = CInt(Val(.Item(Arr(lArrRow) - 1, "AZIMUTH")))
                szPrefix = Create.CreateRecPrefix(Arr(lArrRow))
                szName = Dir(STIM.WorkDir & "\" & szPrefix & "_*.wav")
            End With
            frmX.ResultList.Item(lArrRow + 1, 0) = TStr(Arr(lArrRow))
            lNr = 0
            While Len(szName) <> 0

                ' load file to matlab
                szX = "rec=audioread('" & STIM.WorkDir & "\" & szName & "');"
                szY = STIM.Matlab(szX)
                If Len(szY) <> 0 Then
                    MsgBox("Error loading recorded file." & vbCrLf & "Command line: " & szX & vbCrLf & "Error: " & szY)
                    GoTo SubError
                End If
                ' calc THD
                If blnShow Then szX = ",'" & Replace(szName, "_", "\_") & "'" Else szX = ""

                szX = "[THD,res,Ethd,Esig,Esum]=AA_CalcTHD(rec," & TStr(sFreq) & "," & TStr(glFreqSpan) & "," & TStr(glSamplingRate) & "," & TStr(gsTHDTheta) & szX & ");"
                szY = STIM.Matlab(szX)
                If Len(szY) <> 0 Then
                    MsgBox("Error calculating THD:" & vbCrLf & "Command line: " & szX & vbCrLf & "Error: " & szY)
                    GoTo SubError
                End If

                With frmX.ResultList
                    ' build columns
                    If (lNr + 1) * 4 + 1 > lColMax Then
                        lColMax = (lNr + 1) * 4 + 1
                        szX = Mid(szName, Len(szPrefix) + 1)
                        szX = Left(szX, Len(szX) - 4)
                        .AddCol(szX)
                        .AddCol(szX)
                        .AddCol(szX)
                        .AddCol(szX)
                        .Item(0, 4 * lNr + 1) = "THD [%]"
                        .Item(0, 4 * lNr + 2) = "Ethd [dB]"
                        .Item(0, 4 * lNr + 3) = "Esig [dB]"
                        .Item(0, 4 * lNr + 4) = "Esum [dB]"
                    End If
                    ' get THD
                    szX = "disp(THD)"
                    szY = STIM.Matlab(szX)
                    szY = Trim(szY)
                    szY = Mid(szY, 1, InStr(1, szY, vbLf) - 1)
                    .Item(Arr(lArrRow) + 1, 4 * lNr + 1) = Replace(szY, ",", ".")
                    ' get Ethd
                    szX = "disp(Ethd)"
                    szY = STIM.Matlab(szX)
                    szY = Trim(szY)
                    szY = Mid(szY, 1, InStr(1, szY, vbLf) - 1)
                    .Item(Arr(lArrRow) + 1, 4 * lNr + 2) = Replace(szY, ",", ".")
                    ' get Esig
                    szX = "disp(Esig)"
                    szY = STIM.Matlab(szX)
                    szY = Trim(szY)
                    szY = Mid(szY, 1, InStr(1, szY, vbLf) - 1)
                    .Item(Arr(lArrRow) + 1, 4 * lNr + 3) = Replace(szY, ",", ".")
                    ' get Esum
                    szX = "disp(Esum)"
                    szY = STIM.Matlab(szX)
                    szY = Trim(szY)
                    szY = Mid(szY, 1, InStr(1, szY, vbLf) - 1)
                    .Item(Arr(lArrRow) + 1, 4 * lNr + 4) = Replace(szY, ",", ".")
                End With
                szName = Dir()
                lNr += 1
            End While

            System.Windows.Forms.Application.DoEvents()
            'frmMain.SetProgressbar(lArrRow / (Arr.Length - 1) * 100)
            frmMain.SetProgressbar((lArrRow + 1) / (Arr.Length) * 100)
            If gblnCancel Then GoTo SubError

        Next

        frmX.Show()
        frmX.Text = "THD Summary"
        frmX.PostFix = "THD"

SubError:

        Exit Sub

    End Sub

    Public Sub CalcSINAD()
    'Public Sub CalcSINAD(ByRef lRowBeg As Integer, ByRef lRowEnd As Integer)
        'FIX!!!!!
        Dim lNr As Integer
        Dim szY, szX, szName, szPrefix As String
        Dim sAmp, sFreq As Double
        Dim szErr As String
        Dim lCh, lAzimuth As Integer
        Dim blnShow As Boolean
        Dim frmX As New frmResult
        Dim lColMax As Integer

        If MsgBox("Plot results?" & vbCrLf & "If you choose 'No', calculation only will be performed.", MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then blnShow = True

        gblnCancel = False
        'Dim Arr() as Integer = GetRangeArray
        Dim Arr() As Integer = Nothing
        szErr = GetRangeArray(Arr) 
        If szErr <> "" Then GoTo SubError

        frmX.Init()
        frmX.ResultList.AddCol("")
        frmX.ResultList.ItemCount = 2 + Arr.Length -1
        frmX.ResultList.Item(0, 0) = "Index"

        lColMax = 1

        For lArrRow As Integer = 0 To Arr.Length - 1
        'FOr lRow = (lRowBeg) To (lRowEnd)
            ' get parameters
            With ItemList
                If Not IsNumeric(.Item(Arr(lArrRow) - 1, "CHANNEL ID")) Then
                    szErr = "Channel ID must be a valid numeric."
                    MsgBox(szErr, MsgBoxStyle.Critical, "CalcSINAD")
                    GoTo SubError
                End If
                lCh = GetChannelFromElevation(Val(.Item(Arr(lArrRow) - 1, "CHANNEL ID")))
                If lCh < 1 Then
                    szErr = "Channel ID '" + .Item(Arr(lArrRow) - 1, "CHANNEL ID") + "' not specified."
                    MsgBox(szErr, MsgBoxStyle.Critical, "Calc SINAD")
                    GoTo SubError
                End If
                sAmp = Val(.Item(Arr(lArrRow) - 1, "AMP"))
                sFreq = Val(.Item(Arr(lArrRow) - 1, "FREQ"))
                lAzimuth = CInt(Val(.Item(Arr(lArrRow) - 1, "AZIMUTH")))
                szPrefix = Create.CreateRecPrefix(Arr(lArrRow))
                szName = Dir(STIM.WorkDir & "\" & szPrefix & "_*.wav")
            End With
            frmX.ResultList.Item(lArrRow + 1, 0) = TStr(lArrRow)
            lNr = 0
            While Len(szName) <> 0

                ' load file to matlab
                szX = "rec=audioread('" & STIM.WorkDir & "\" & szName & "');"
                szY = STIM.Matlab(szX)
                If Len(szY) <> 0 Then
                    MsgBox("Error loading recorded file." & vbCrLf & "Command line: " & szX & vbCrLf & "Error: " & szY)
                    GoTo SubError
                End If
                ' calc THD
                If blnShow Then szX = ",'" & Replace(szName, "_", "\_") & "'" Else szX = ""

                szX = "[SINAD,THDN,Fsig,Ethdn,Esum]=AA_CalcSINAD(rec," & TStr(sFreq) & "," & TStr(glFreqSpan) & "," & TStr(glNotchOrder) & "," & TStr(glSamplingRate) & szX & ");"
                szY = STIM.Matlab(szX)
                If Len(szY) <> 0 Then
                    MsgBox("Error calculating THD:" & vbCrLf & "Command line: " & szX & vbCrLf & "Error: " & szY)
                    GoTo SubError
                End If

                With frmX.ResultList
                    ' build columns
                    If (lNr + 1) * 4 + 1 > lColMax + 1 Then
                        lColMax = (lNr + 1) * 4
                        '.Cols = lColMax
                        szX = Mid(szName, Len(szPrefix) + 1)
                        szX = Left(szX, Len(szX) - 4)
                        .AddCol(szX)
                        .AddCol(szX)
                        .AddCol(szX)
                        .AddCol(szX)
                        .Item(0, 4 * lNr + 1) = "SINAD [dB]"
                        .Item(0, 4 * lNr + 2) = "THDN [%]"
                        .Item(0, 4 * lNr + 3) = "Ethdn [dB]"
                        .Item(0, 4 * lNr + 4) = "Esum [dB]"
                    End If
                    ' get THD
                    szX = "disp(SINAD)"
                    szY = STIM.Matlab(szX)
                    szY = Trim(szY)
                    szY = Mid(szY, 1, InStr(1, szY, vbLf) - 1)
                    .Item(lArrRow + 1, 4 * lNr + 1) = Replace(szY, ",", ".")
                    ' get Ethd
                    szX = "disp(THDN)"
                    szY = STIM.Matlab(szX)
                    szY = Trim(szY)
                    szY = Mid(szY, 1, InStr(1, szY, vbLf) - 1)
                    .Item(lArrRow + 1, 4 * lNr + 2) = Replace(szY, ",", ".")
                    ' get Esig
                    szX = "disp(Ethdn)"
                    szY = STIM.Matlab(szX)
                    szY = Trim(szY)
                    szY = Mid(szY, 1, InStr(1, szY, vbLf) - 1)
                    .Item(lArrRow + 1, 4 * lNr + 3) = Replace(szY, ",", ".")
                    ' get Esum
                    szX = "disp(Esum)"
                    szY = STIM.Matlab(szX)
                    szY = Trim(szY)
                    szY = Mid(szY, 1, InStr(1, szY, vbLf) - 1)
                    .Item(lArrRow + 1, 4 * lNr + 4) = Replace(szY, ",", ".")
                End With
                szName = Dir()
                lNr += 1
            End While

            System.Windows.Forms.Application.DoEvents()
            'frmMain.SetProgressbar(lArrRow / (Arr.Length - 1) * 100)
            frmMain.SetProgressbar((lArrRow + 1) / (Arr.Length) * 100)
            If gblnCancel Then GoTo SubError

        Next

        frmX.Show()
        frmX.Text = "SINAD summary"
        frmX.PostFix = "SINAD"

SubError:

        Exit Sub

    End Sub

    Sub ShowLatency()
        Dim frmX As New frmResult
        Dim lY, lX, lRec As Integer
        Dim szErr As String = ""
        Dim szX, szY As String
        Dim dblArr(,) As Double

        frmX.Init()
        szX = InputBox("Input the index of the record stream: ", "Show Latency", "1")
        If Len(szX) = 0 Then Exit Sub
        lRec = CInt(Val(szX) - 1)
        If lRec > GetUbound(gRecStream) Then szErr = "Record stream not found." : GoTo SubError

        ' get size of latC{}
        szX = STIM.MatlabGetMatrixSize("latC", lY, lX)
        If Len(szX) > 0 Then
            szErr = "Get Size of latC: " & szX
            GoTo SubError
        End If

        'For lRow = lRowBeg To lRowEnd
        'Dim Arr() As Integer = GetRangeArray 'treat selected items only
        Dim Arr() As Integer = Nothing
        szErr = GetRangeArray(Arr) 
        If szErr <> "" Then GoTo SubError
        


        'Next
        If lX < Arr(0) Then
            szErr = "Latency matrix not defined for items beginning from " & TStr(Arr(0))
            GoTo SubError
        End If
        'If lX + 1 < lRowEnd Then lRowEnd = lX + 1

        gblnCancel = False

        frmMain.SetProgressbar(0)

        frmX.ResultList.AddCol("Index")
        frmX.ResultList.AddCol("Latency in ms")
        'frmX.ResultList.ItemCount = 1
        'frmX.ResultList.Cols = 2

        For lArrRow As Integer = 0 To Arr.Length - 1
        'For lRow = lRowBeg To lRowEnd
            ' latX = latC{lRow};
            szX = "latX=latC{" & TStr(Arr(lArrRow)) & "};"
            szY = STIM.Matlab(szX)
            If Len(szY) <> 0 Then szErr = szErr & "Item #" & TStr(Arr(lArrRow)) & "latX=latC{item}: " & szY : GoTo SubError
            ' lY, lX = SIZE(latX)
            szY = STIM.MatlabGetMatrixSize("latX", lY, lX)
            If Len(szY) > 0 Then szErr = szErr & "Item #" & TStr(Arr(lArrRow)) & ": Get Size of latX: " & szY : GoTo SubError
            frmX.ResultList.ItemCount += 1
            frmX.ResultList.Item(lArrRow - 0, 0) = TStr(Arr(lArrRow))
            If lY < 1 And lX < 1 Then
                szErr = szErr & "Item #" & TStr(Arr(lArrRow)) & ": Latency matrix is empty." & vbCrLf
                GoTo NextItem
            End If
            If frmX.ResultList.ColCount < lY + 1 Then
                For lZ As Integer = frmX.ResultList.ColCount To lY
                    frmX.ResultList.AddCol("")
                Next
            End If
            ' Y = LAT;
            ReDim dblArr(lY - 1, lX - 1)
            szY = STIM.MatlabGetRealMatrix2("latX", dblArr)
            If Len(szY) <> 0 Then szErr = szErr & "Item #" & TStr(Arr(lArrRow)) & ": Get Matrix: " & szY : GoTo SubError
            If lRec > UBound(dblArr, 2) Then szErr = szErr & "Item #" & TStr(Arr(lArrRow)) & ": Stream not available: " & vbCrLf : GoTo NextItem
            For lY = 0 To UBound(dblArr, 1)
                If lY + 2 > frmX.ResultList.ColCount Then
                    'frmX.ResultList.AddCol("")
                    Debug.Print(TStr(frmX.ResultList.ColCount))
                End If
                'If lY + 1 < frmX.ResultList.ColCount Then
                frmX.ResultList.Item(larrRow - 0, lY + 1) = TStr(Math.Round(dblArr(lY, lRec) / glSamplingRate * 1000, 3))
                'frmX.ResultList.Item(lRow - lRowBeg, lY + 1) = TStr(lRow - lRowBeg) & " // " & TStr(lY + 1)

                'End If
            Next
NextItem:
            'frmMain.SetProgressbar(lArrRow / (Arr.Length - 1) * 100)
            frmMain.SetProgressbar((lArrRow + 1) / (Arr.Length) * 100)
            ItemList.Item(Arr(lArrRow) - 1, "STATUS") = "Latency calculated"
            frmMain.SetStatus("Item #" & TStr(Arr(lArrRow)) & ": Latency calculated.")
            System.Windows.Forms.Application.DoEvents()
            If gblnCancel Then GoTo SubError
        Next
        If Len(szErr) <> 0 Then
            MsgBox(szErr, MsgBoxStyle.Information, "Show latency: Warnings:")
        End If

        ' show latency form
        If gIRFlags.ShowLatency Then
            frmX.Show()
            frmX.ResultList.SetOptimalColWidth()
            frmX.Text = "Latency in ms, record stream: " + gRecStream(lRec)
            frmX.PostFix = "latency"
        End If


        Exit Sub

SubError:
        MsgBox(szErr, MsgBoxStyle.Critical, "Show Latency: Error")

        Exit Sub

    End Sub

    Public Sub MLStoIR(Optional bUseRangeCheckbox As Boolean = True)
        'Public Sub MLStoIR(ByRef lRowBeg As Integer, ByRef lRowEnd As Integer)
        Dim frmX As New frmResult
        Dim lNr As Integer
        Dim szY, szX, szMLS, szPrefix As String
        Dim szName As String
        Dim lCh As Integer
        Dim szErr As String
        Dim szElevation, szAzimuth, szAmp As String

        gblnCancel = False

        ' create file name of MLS
        szMLS = CreateStimFileName()
        If Not STIM.CheckStimulationFile(szMLS) Then szErr = "Stimulation file not found:" & szMLS : GoTo SubError
        ' load MLS to matlab
        szX = "mlsX=audioread('" & STIM.WorkDir & "\" & szMLS & "');"
        szY = STIM.Matlab(szX)
        If Len(szY) <> 0 Then szErr = "Error loading MLS:" & szX & vbCrLf & "Error: " & szY : GoTo SubError
        szErr = ""


        'For lRow = lRowBeg To lRowEnd
        'Dim Arr() as Integer = GetRangeArray
        Dim Arr() As Integer = Nothing
        szErr = GetRangeArray(Arr, bUseRangeCheckbox) 
        If szErr <> "" Then GoTo SubError

        For lArrRow As Integer = 0 To Arr.Length - 1
            ' get parameters
            With ItemList
                .Item(Arr(lArrRow) - 1, "STATUS") = "Error"
                szAmp = .Item(Arr(lArrRow) - 1, "AMP")
                szElevation = .Item(Arr(lArrRow) - 1, "CHANNEL ID")
                If Not IsNumeric(.Item(Arr(lArrRow) - 1, "CHANNEL ID")) Then
                    szErr = szErr & "Item #" & TStr(Arr(lArrRow)) & ": Channel ID must be a valid numeric." & vbCrLf
                    GoTo NextItem
                End If
                lCh = GetChannelFromElevation(Val(.Item(Arr(lArrRow) - 1, "CHANNEL ID")))
                If lCh < 1 Then
                    szErr = szErr & "Item #" & TStr(Arr(lArrRow)) & ": Channel ID " + .Item(Arr(lArrRow) - 1, "CHANNEL ID") + " not specified." + vbCrLf
                    GoTo NextItem
                End If
                If Len(ItemList.Item(Arr(lArrRow) - 1, "AZIMUTH")) = 0 Then
                    szAzimuth = "NaN"
                Else
                    szAzimuth = TStr(Val(ItemList.Item(Arr(lArrRow) - 1, "AZIMUTH")))
                End If
                szPrefix = Create.CreateRecPrefix(Arr(lArrRow))
                szName = Dir(STIM.WorkDir & "\" & szPrefix & "_*.wav")
            End With
            lNr = 0
            szX = "{"
            While Len(szName) <> 0
                If lNr > 0 Then szX &= " "
                szX = szX & "'" & STIM.WorkDir & "\" & szName & "'"
                szName = Dir()
                lNr += 1
            End While
            If lNr = 0 Then
                szErr = szErr & "Recorded files not found." & vbCrLf & STIM.WorkDir & "\" & szPrefix & "_*.wav" & vbCrLf
                GoTo NextItem
            End If
            szX &= "}"
            ' get data

            ' calc IR
            szX = "[hC{" & TStr(Arr(lArrRow)) & "},idxC{" & TStr(Arr(lArrRow)) & "},latC{" & TStr(Arr(lArrRow)) & "},posC{" & TStr(Arr(lArrRow)) & "},ampC{" & TStr(Arr(lArrRow)) & "}]=AA_CalcMLSToIR(mlsX," & szX & "," & TStr(glMLSOrder) & "," & TStr(glMLSRepetition) & ",[" & szAzimuth & "],[" & szElevation & "]," & TStr(lCh) & ",[" & szAmp & "]);"
            szY = STIM.Matlab(szX)
            If Len(szY) <> 0 Then
                szErr = "Error calculation IR from MLS." & szX & vbCrLf & "Error: " & szY
                GoTo SubError
            End If
            ItemList.Item(Arr(lArrRow) - 1, "STATUS") = "IR calculated"
            frmMain.SetStatus("Item #" & TStr(Arr(lArrRow)) & ": IR calculated.")
            If lArrRow = 0 Then ItemList.SetOptimalColWidth()
NextItem:
            'frmMain.SetProgressbar(lArrRow / (Arr.Length - 1) * 100)
            frmMain.SetProgressbar((lArrRow + 1) / (Arr.Length) * 100)
            System.Windows.Forms.Application.DoEvents()
            If gblnCancel Then GoTo SubError
        Next
        If Len(szErr) <> 0 Then
            MsgBox(szErr, MsgBoxStyle.Information, "Warnings:")
        End If
        if Arr.Length > 1 Then frmMain.SetStatus("All selected linear IRs calculated.")
        Exit Sub

SubError:
        MsgBox(szErr, MsgBoxStyle.Critical, "MLS: Calc IR")
        Exit Sub

    End Sub


    Public Sub SweeptoIR(ByRef blnGM As Boolean)
    'Public Sub SweeptoIR(ByRef lRowBeg As Integer, ByRef lRowEnd As Integer, ByRef blnGM As Boolean)
        Dim lArrRow, lX, lNr As Integer
        Dim szY, szX, szSweep, szRec, szPrefix As String
        Dim szName As String
        Dim lCh() As Integer
        Dim szErr As String
        Dim szArr() As String
        Dim szISD, szLat As String
        Dim sX As Double

        'lRowBeg += 1 : lRowEnd += 1 'compatible to VB6
        'For lRow = lRowBeg To lRowEnd
        
        If ItemList.SelectedItems.Count = 0 Then
            MsgBox("No items selected.")
            Exit Sub
        End If
        
        'If lRowBeg < 1 And lRowEnd < 1 Then
        '    MsgBox("No items selected.")
        '    Exit Sub
        'End If

        'Dim Arr() as Integer = GetRangeArray MIHO
        Dim Arr() As Integer = Nothing
        szErr = GetRangeArray(Arr) 
        If szErr <> "" Then GoTo SubError

        gblnCancel = False

        ' create file name of Sweep
        szSweep = "expsweep"
        If Not STIM.CheckStimulationFile(szSweep) Then
            szErr = "Stimulation file not found:" & vbCrLf & szSweep
            GoTo SubError
        End If
        ' load Sweep to matlab
        szX = "sweepX=audioread('" & STIM.WorkDir & "\" & szSweep & "');"
        szY = STIM.Matlab(szX)
        If Len(szY) <> 0 Then
            szErr = "Error loading Sweep file:" & vbCrLf & "Command line: " & szX & vbCrLf & "Error: " & szY
            GoTo SubError
        End If
        frmMain.SetStatus("Sweep loaded.")
        ' create file name of inverse sweep
        szSweep = "inv" & szSweep
        If Not STIM.CheckStimulationFile(szSweep) Then
            szErr = "Stimulation file not found:" & vbCrLf & szSweep
            GoTo SubError
        End If
        ' load inverse sweep to matlab
        szX = "invsweepX=audioread('" & STIM.WorkDir & "\" & szSweep & "');"
        szY = STIM.Matlab(szX)
        If Len(szY) <> 0 Then
            szErr = "Error loading Sweep file:" & vbCrLf & "Command line: " & szX & vbCrLf & "Error: " & szY
            GoTo SubError
        End If
        ' normalise inverse sweep to an ideal IR
        szX = "invsweepX=AA_NormaliseInvSweep(sweepX,invsweepX);"
        szY = STIM.Matlab(szX)
        If Len(szY) <> 0 Then
            szErr = "Error normalising inverse sweep:" & vbCrLf & "Command line: " & szX & vbCrLf & "Error: " & szY
            GoTo SubError
        End If
        frmMain.SetStatus("Inverse Sweep loaded and normalised.")
        ' prepare ISD string
        If GetUbound(gISD) < 0 Then
            szErr = "No ISD specified."
            GoTo SubError
        End If
        sX = Val(gISD(0))
        szISD = TStr(System.Math.Round(sX * glSamplingRate / 1000))
        If UBound(gISD) > 0 Then
            For lX = 1 To GetUbound(gISD)
                sX += Val(gISD(lX))
                szISD = szISD & ";" & TStr(System.Math.Round(sX * glSamplingRate / 1000))
            Next
        End If
        szErr = ""
        frmMain.SetProgressbar(0)
        'Dim StartTime As DateTime = System.DateTime.Now

        'For lRow = lRowBeg To lRowEnd


        For lArrRow  = 0 To Arr.Length - 1
        'For lRow = lRowBeg To lRowEnd
            ItemList.Item(Arr(lArrRow) , "STATUS") = "Error"
            ' get elevations (=systems)
            With ItemList
                If glExpType = 3 Then szY = "Elevation" Else szY = "Channel ID"
                If InStr(1, .Item(Arr(lArrRow) , szY), " ") > 0 Then
                    szArr = Split(Trim(.Item(Arr(lArrRow), szY)), " ") 'szArr = array with elevations in string format ["-45","-30"...]
                Else
                    szArr = Split(.Item(Arr(lArrRow) , szY), ";")
                End If
                If GetUbound(szArr) < 0 Then szErr = szY & " not specified" : GoTo SubError
                ReDim lCh(GetUbound(szArr))
                For lX = 0 To GetUbound(szArr) ' lCh = int array with channels corresponding to the elevations in szArr [1,2,3...]
                    If Not IsNumeric(szArr(lX)) Then
                        szErr = szErr & "Item #" & TStr(Arr(lArrRow)) & ": " & szY & " must be a valid numeric." & vbCrLf
                        GoTo NextItem
                    End If
                    lCh(lX) = GetChannelFromElevation(Val(szArr(lX)))
                    If lCh(lX) < 1 Then
                        szErr = szErr & "Item #" & TStr(Arr(lArrRow)) & ": " & szY & " " & szArr(lX) & " not specified." & vbCrLf
                        GoTo NextItem
                    End If
                Next
                If GetUbound(lCh) > GetUbound(gISD) Then
                    szErr = szErr & "Item #" & TStr(Arr(lArrRow)) & ": More " & szY & "s than ISDs specified." & vbCrLf
                    GoTo NextItem
                End If
                szPrefix = Create.CreateRecPrefix(Arr(lArrRow)) 'Arr = int array with selected items with 0 index [3,4,5...]
                szName = Dir(STIM.WorkDir & "\" & szPrefix & "_*.wav") ' filenames "AMTatARI_0004_*.wav"
            End With
            ' prepare latency and position strings
            szLat = ""
            szX = "posC{" & TStr(Arr(lArrRow) +1 ) & "}=["
            If Len(ItemList.Item(Arr(lArrRow) , "AZIMUTH")) = 0 Then
                szY = "NaN"
            Else
                szY = TStr(Val(ItemList.Item(Arr(lArrRow), "AZIMUTH"))) ' get Azimuth from item list index
            End If
            For lX = 0 To UBound(lCh)
                ' latency matrix: item x rec-stream
                szLat = szLat & TStr(System.Math.Round(CDbl(gfreqParL(lCh(lX) - 1).lPhDur) * glSamplingRate / 1000000)) & ";" 'lPhDur=latency (113000) 
                ' position matrix: item x [azimuth elevation channel]
                szX = szX & szY & " " & TStr((gfreqParL(lCh(lX) - 1).sAmp)) & " " & TStr(lCh(lX)) & ";" 'sAmp=elevation (-45), szX = [az el ch] = [0 -45 1]
            Next
            szX &= "];" ' szX has all the elevations for a single Azimuth. Elevation and Channel (2nd and 3rd elements) are redundant to each other
            ' set position
            szY = STIM.Matlab(szX)
            If Len(szY) <> 0 Then szErr = szX & vbCrLf & "Error: " & szY : GoTo SubError
            szX = "{" ' szX here holds the *_adc0.wav and *_adc1.wav files
            ' get file names
            lNr = 0
            While Len(szName) <> 0
                If lNr > 0 Then szX &= " "
                szX = szX & "'" & STIM.WorkDir & "\" & szName & "'"
                szName = Dir()
                lNr += 1
            End While
            If lNr = 0 Then
                szErr = szErr & "Item #" & TStr(Arr(lArrRow)+1) & ": Recorded files not found: " & STIM.WorkDir & "\" & szPrefix & "_*.wav" & vbCrLf
                GoTo NextItem
            End If
            szX &= "}"
            szRec = szPrefix
            ' calc IRs
            If blnGM Then
                szX = "[hC{" & TStr(Arr(lArrRow)+1) & "},idxC{" & TStr(Arr(lArrRow)+1) & "},latC{" & TStr(Arr(lArrRow)+1) & "},htotalX]=AA_CalcSweepToIR(" & szX & ",sweepX,invsweepX,[" & szISD & "]," & TStr(glSamplingRate) & "," & TStr(UBound(lCh) + 1) & ",[" & szLat & "]," & TStr(System.Math.Round(gsIRLen * glSamplingRate / 1000)) & ",[" & TStr(System.Math.Round(gsIRBeg * glSamplingRate / 1000)) & ";" & TStr(System.Math.Round(gsIREnd * glSamplingRate / 1000)) & "]," & TStr(CInt(blnGM)) & ");"
            Else
                szX = "[hC{" & TStr(Arr(lArrRow) + 1) & "},idxC{" & TStr(Arr(lArrRow) + 1) & "},latC{" & TStr(Arr(lArrRow) + 1) & "},htotalX]=AA_CalcSweepToIR(" & szX & ",sweepX,invsweepX,[" & szISD & "]," & TStr(glSamplingRate) & "," & TStr(UBound(lCh) + 1) & ",[" & szLat & "]," & TStr(System.Math.Round(gsIRLen * glSamplingRate / 1000)) & ",[" & TStr(System.Math.Round(gsIRBeg * glSamplingRate / 1000)) & ";" & TStr(System.Math.Round(gsIREnd * glSamplingRate / 1000)) & "]);" ' gsIRBeg and gsIREnd are 2.5ms when I debugged this
            End If
            szY = STIM.Matlab(szX)
            If Len(szY) <> 0 Then szErr = szX & vbCrLf & "Error: " & szY : GoTo SubError
            ' set amplitude
            szX = "ampC{" & TStr(Arr(lArrRow)+1) & "}=" & TStr(Val(ItemList.Item(Arr(lArrRow), "AMP"))) & ";"
            szY = STIM.Matlab(szX)
            If Len(szY) <> 0 Then szErr = szY : GoTo SubError

            ' set azimuth
            szX = "aziC{" & TStr(Arr(lArrRow)+1) & "}=" & TStr(Val(ItemList.Item(Arr(lArrRow), "AZIMUTH"))) & ";"
            szY = STIM.Matlab(szX)
            If Len(szY) <> 0 Then szErr = szY : GoTo SubError
            ' set frequency
            szX = "freqC{" & TStr(Arr(lArrRow)+1) & "}=" & TStr(Val(ItemList.Item(Arr(lArrRow), "FREQ"))) & ";"
            szY = STIM.Matlab(szX)
            If Len(szY) <> 0 Then szErr = szY : GoTo SubError
            ' set description
            szX = "descC{" & TStr(Arr(lArrRow)+1) & "}='" & ItemList.Item(Arr(lArrRow), "DESCRIPTION") & "';"
            szY = STIM.Matlab(szX)
            If Len(szY) <> 0 Then szErr = szY : GoTo SubError

            ' set item number for debugging
            szX = "itemX=" & TStr(Arr(lArrRow)+1) & ";"
            szY = STIM.Matlab(szX)
            If Len(szY) <> 0 Then szErr = szY : GoTo SubError

            ItemList.Item(Arr(lArrRow), "STATUS") = "IR calculated"
            frmMain.SetStatus("Item #" & TStr(Arr(lArrRow)+1) & ": IR calculated.")
            If lArrRow = 0 Then ItemList.SetOptimalColWidth()

NextItem:
            frmMain.SetProgressbar((lArrRow + 1) / (Arr.Length) * 100)
            System.Windows.Forms.Application.DoEvents()
            If gblnCancel Then GoTo SubError
        Next
        If Len(szErr) <> 0 Then
            MsgBox(szErr, MsgBoxStyle.Information, "Calculate IR from Sweep: Warnings:")
        End If
        if Arr.Length > 1 Then frmMain.SetStatus("All selected linear IRs calculated.")
        Return

SubError:
        If Arr is Nothing then

        elseif Arr(lArrRow) > 0 Then
            MsgBox("Item #" & TStr(lArrRow) & ":" & vbCrLf & szErr, MsgBoxStyle.Critical, "Calculate IR from Sweep: Error: ")
        Else
            MsgBox(szErr, MsgBoxStyle.Critical, "Calculate IR from Sweep: Error: ")
        End If

        Exit Sub

    End Sub
End Module