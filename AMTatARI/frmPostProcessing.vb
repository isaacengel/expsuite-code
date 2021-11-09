Option Strict On
Option Explicit On
#Region "ExpSuite License"
'ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
'Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
'Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
'You may not use this work except in compliance with the Licence. 
'You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
'Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
'See the Licence for the specific language governing  permissions and limitations under the Licence. 
#End Region
Imports System.IO
Friend Class frmPostProcessing
    Inherits System.Windows.Forms.Form

    Private mlLeft, mlTop As Integer
    Private mszLastString As String = ""

    Function MatlabCmd(ByRef szCmd As String) As String

        MatlabCmd = STIM.Matlab(szCmd)
        If CBool(chkScriptAdd.CheckState) Then
            gszScript = gszScript & szCmd & vbCrLf
        End If

    End Function

    Public Sub SetBusy()
        Dim ctrX As System.Windows.Forms.Control
        ' general controls
        For Each ctrX In Me.Controls
            If TypeOf ctrX Is System.Windows.Forms.Button Then ctrX.Enabled = False
            If TypeOf ctrX Is System.Windows.Forms.ToolStrip Then ctrX.Enabled = False
            If TypeOf ctrX Is System.Windows.Forms.TextBox Then TextBoxState(DirectCast(ctrX, TextBox), False)
            If TypeOf ctrX Is System.Windows.Forms.CheckBox Then ctrX.Enabled = False
            If TypeOf ctrX Is System.Windows.Forms.GroupBox Then ctrX.Enabled = False
        Next ctrX

    End Sub

    Public Sub SetReady()
        Dim ctrX As System.Windows.Forms.Control
        ' general controls
        For Each ctrX In Me.Controls
            If TypeOf ctrX Is System.Windows.Forms.Button Then ctrX.Enabled = True
            If TypeOf ctrX Is System.Windows.Forms.ToolStrip Then ctrX.Enabled = True
            If TypeOf ctrX Is System.Windows.Forms.TextBox Then TextBoxState(DirectCast(ctrX, TextBox), True)
            If TypeOf ctrX Is System.Windows.Forms.CheckBox Then ctrX.Enabled = True
            If TypeOf ctrX Is System.Windows.Forms.GroupBox Then ctrX.Enabled = True
        Next ctrX

    End Sub


    Public Sub SetStatus(ByRef szStatus As String)
        If lstStatus.Items.Count > 100 Then lstStatus.Items.RemoveAt((0))
        lstStatus.Items.Add((szStatus))
        lstStatus.SelectedIndex = lstStatus.Items.Count - 1
        ToolTip1.SetToolTip(lstStatus, szStatus)
    End Sub


    Private Sub UpdateObjectInfo()
        Dim szX As String

        STIM.Matlab("disp(exist('Obj.Data.IR'))")
        szX = STIM.Matlab("disp(isnumeric(Obj.Data.IR))")
        If Val(szX) = 0 Then
            ' SOFA object not available
            lblRecChannels.Text = "--"
            lblChannels.Text = "--"
            lblVectors.Text = "--"
            lblLength.Text = "--"

        Else
            ' get the size of SOFA object
            szX = STIM.Matlab("disp(size(Obj.Data.IR,3))")
            'lblLength.AutoSize = True
            lblLength.Text = TStr(Val(szX)) & " samples" & vbCrLf & TStr(System.Math.Round(Val(szX) * 1000 / glSamplingRate, 3)) & "ms"
            szX = STIM.Matlab("disp(size(Obj.Data.IR,1))")
            lblVectors.Text = TStr(Val(szX))
            szX = STIM.Matlab("disp(size(Obj.Data.IR,2))")
            lblRecChannels.Text = TStr(Val(szX))
            szX = STIM.Matlab("disp(size(unique(meta.pos(:,3)),1))")
            lblChannels.Text = TStr(Val(szX))
            'szX = STIM.Matlab("disp(stimPar.Version)")
            'If InStr(1, szX, "???") > 0 Then szX = "???"
        End If

    End Sub

    Private Sub cmdAugmentation_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAugmentation.Click
        Dim szX As String
        Dim szTargetAmp As String
        Dim lFreqStart, lFreqEnd As Integer
        Dim szT As String
        ' old augmentation did not work properly and was never used -> replaced by Harald Ziegelwanger's version
        SetBusy()
        szT = "Augmentation"

        szX = InputBox("Low frequency? [Hz]: ", szT, "300")
        If Len(szX) = 0 Then SetReady() : Exit Sub
        If IsNumeric(szX) Then lFreqStart = CInt(Val(szX))
        szX = InputBox("High frequency? [Hz]: ", szT, "18000")
        If Len(szX) = 0 Then SetReady() : Exit Sub
        If IsNumeric(szX) Then lFreqEnd = CInt(Val(szX))

        szX = InputBox("Augment lower frequencies to this amplitude? [dB]: ", szT, "-30")
        If Len(szX) = 0 Then SetReady() : Exit Sub
        szTargetAmp = szX

        SetStatus("Augmenting...")
        szX = "[Obj,gdm]=AA_Augment(stimPar,Obj," & TStr(lFreqStart) & "," & TStr(lFreqEnd) & ",[" & szTargetAmp & "]);"
        szX = MatlabCmd(szX)
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, szT) : SetReady() : Exit Sub
        SetStatus("SOFA object augmented successfully")

        UpdateObjectInfo()
        SetReady()
    End Sub

    Private Sub cmdAverageSpectral_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAverageSpectral.Click
        Dim szX As String
        Dim szRec1, szT, szRec2 As String

        SetBusy()
        szT = "Average Spectral"

        szX = InputBox("Item filter for record channel #1: ", szT, "find(meta.pos(:,3)==23)")
        If Len(szX) = 0 Then SetReady() : Exit Sub
        szRec1 = szX
        szX = InputBox("Item filter for record channel #2", szT, "find(meta.pos(:,3)==24)")
        If Len(szX) = 0 Then SetReady() : Exit Sub
        szRec2 = szX

        szX = "[Obj,meta]=AA_AverageSpectral(Obj,{" & szRec1 & "," & szRec2 & "},meta);"
        szX = MatlabCmd(szX)
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, szT) : SetReady() : Exit Sub
        SetStatus("Spectral average appended to the end of SOFA object")

        UpdateObjectInfo()
        SetReady()

    End Sub

    Private Sub cmdAverageCepstral_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAverageCepstral.Click
        Dim szX As String
        Dim szT As String

        SetBusy()
        szT = "Average cepstral (average cepstrum and minimum phase)"
        SetStatus(szT)
        szX = "[Obj,meta]=AA_AverageCepstral(Obj,meta);"
        szX = MatlabCmd(szX)
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, szT) : SetReady() : Exit Sub
        SetStatus("Cepstral average calculated")

        UpdateObjectInfo()
        SetReady()

    End Sub

    Private Sub cmdEqualize_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEqualize.Click
        Dim szX As String
        Dim szY As String = ""
        Dim szZ As String = "test"
        Dim sngBegin, sngTargetAmp As Double
        Dim lFreqStart, lFreqEnd As Integer
        Dim lX As Integer
        Dim szT As String
        Dim szFilt1 As String

        SetBusy()
        szT = "Equalize"

        szX = InputBox("Target amplitude? [dB FS]: ", szT, "-30")
        If Len(szX) = 0 Then SetReady() : Exit Sub
        If IsNumeric(szX) Then sngTargetAmp = Val(szX)

        szX = InputBox("Start Frequency of target? [Hz]: ", szT, TStr(glFreqStart))
        If Len(szX) = 0 Then SetReady() : Exit Sub
        If IsNumeric(szX) Then lFreqStart = CInt(Val(szX))
        szX = InputBox("End Frequency of target? [Hz]: ", szT, TStr(glFreqEnd))
        If Len(szX) = 0 Then SetReady() : Exit Sub
        If IsNumeric(szX) Then lFreqEnd = CInt(Val(szX))

        szX = InputBox("Length of the resulting impulse response? [ms]: ", szT, "100")
        If Len(szX) = 0 Then SetReady() : Exit Sub
        If IsNumeric(szX) Then sngBegin = System.Math.Round(Val(szX) / 1000 * glSamplingRate)

        szX = Dir(STIM.WorkDir & "\" & STIM.ID & "_FILT_*.mat")
        If Len(szX) = 0 Then
            MsgBox("No filters available.")
            SetReady()
            Exit Sub
        End If

        While Len(szX) > 0
            lX = Len(STIM.ID & "_FILT_")
            szY = szY & vbTab & Mid(szX, lX + 1, Len(szX) - lX - Len(".mat")) & vbCrLf
            If szZ = "test" Then szZ = Mid(szX, lX + 1, Len(szX) - lX - Len(".mat"))
            szX = Dir()
        End While

        szFilt1 = InputBox("Input the postfix of the filter" & vbCrLf & vbCrLf & "Files with following postfixes are available:" & vbCrLf & szY, szT, szZ)
        If Len(szFilt1) = 0 Then SetReady() : Exit Sub

        SetStatus("Equalizing...")
        szX = "Obj=AA_Equalize(stimPar,Obj,meta," & TStr(sngTargetAmp) & "," & TStr(lFreqStart) & "," & TStr(lFreqEnd) & "," & TStr(sngBegin) & ",[stimPar.WorkDir '\' stimPar.ID '_FILT_" & szFilt1 & "']);"
        szX = MatlabCmd(szX)
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, szT) : SetReady() : Exit Sub
        SetStatus("Equalized to SOFA object")

        UpdateObjectInfo()
        SetReady()

    End Sub

    Private Sub cmdFilter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFilter.Click
        Dim szX As String
        Dim szY As String = ""
        Dim szZ As String = "test"
        Dim sngBegin As Double
        Dim lX As Integer
        Dim szT As String
        Dim szFilt1 As String

        SetBusy()
        szT = "Filter"

        szX = InputBox("Length of the resulting impulse response? [ms]: ", szT, "0")
        If Len(szX) = 0 Then SetReady() : Exit Sub
        If IsNumeric(szX) Then sngBegin = System.Math.Round(Val(szX) / 1000 * glSamplingRate)

        szX = Dir(STIM.WorkDir & "\" & STIM.ID & "_FILT_*.mat")
        If Len(szX) = 0 Then
            MsgBox("No filters available.")
            SetReady()
            Exit Sub
        End If
        While Len(szX) > 0
            lX = Len(STIM.ID & "_FILT_")
            szY = szY & vbTab & Mid(szX, lX + 1, Len(szX) - lX - Len(".mat")) & vbCrLf
            If szZ = "test" Then szZ = Mid(szX, lX + 1, Len(szX) - lX - Len(".mat"))
            szX = Dir()
        End While

        szFilt1 = InputBox("Input the postfix of the filter" & vbCrLf & vbCrLf & "Files with following postfixes are available:" & vbCrLf & szY, szT, szZ)
        If Len(szFilt1) = 0 Then SetReady() : Exit Sub

        SetStatus("Filtering...")
        szX = "Obj=AA_Filter(stimPar,Obj,meta," & TStr(sngBegin) & ",[stimPar.WorkDir '\' stimPar.ID '_FILT_" & szFilt1 & "']);"
        szX = MatlabCmd(szX)
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, szT) : SetReady() : Exit Sub
        SetStatus("Filtered to SOFA object")

        UpdateObjectInfo()
        SetReady()

    End Sub

    Private Sub cmdLoadM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoadM.Click
        Dim szX, szText As String
        Dim szY As String = ""
        Dim szPrefix As String = ""
        Dim szListItems() As String = Nothing
        Dim lX As Integer
        Dim lY As Integer = 0

        SetBusy()
        szX = Dir(STIM.WorkDir & "\" & STIM.ID & "_M_*.mat")
        If Len(szX) = 0 Then
            If MsgBox("No .mat files are available with Prefix '" & STIM.ID & "_M_'." & vbCrLf & "Do you want to view all .mat files in folder?", MsgBoxStyle.YesNo Or MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                szX = Dir(STIM.WorkDir & "\" & "*.mat")
                While Len(szX) > 0
                    'lX = Len(STIM.ID & "_M_")
                    ReDim Preserve szListItems(lY)
                    szListItems(lY) = Strings.Left(szX, Len(szX) - Len(".mat"))
                    szX = Dir()
                    lY += 1
                End While
                szText = "Input the postfix of the file"
            Else
                GoTo SubError
            End If
        Else
            While Len(szX) > 0
                lX = Len(STIM.ID & "_M_")
                ReDim Preserve szListItems(lY)
                szListItems(lY) = Mid(szX, lX + 1, Len(szX) - lX - Len(".mat"))
                szX = Dir()
                lY += 1
            End While
            szText = "Input the postfix of the file (File Name will be: ID_postfix.mat)"
            szPrefix = STIM.ID & "_M_"
        End If

        ''szY = InputBox("Input the postfix of the file (File Name will be: ID_postfix.mat)" & vbCrLf & vbCrLf & "Files with following postfixes are available:" & vbCrLf & szY, "Load *M from .MAT", szZ)
        szY = frmListbox.Init(szText & vbCrLf & vbCrLf & "Files with following postfixes are available:", "Load *M from .MAT", szListItems)
        If Len(szY) = 0 Then GoTo SubError
        mszLastString = szY

        
        STIM.Matlab("clear Obj meta;")
        'reset stimPar
        ResetStimPar(glSamplingRate, glResolution)
        STIM.Matlab("stimPar.WorkDir = '" & STIM.WorkDir & "';")

        'load variables (incl. stimPar)
        STIM.Matlab("[Obj,stimPar,meta]=AA_LoadhM(stimPar,[stimPar.WorkDir '\" & szPrefix & szY & ".mat']);")

        'Console.WriteLine(stimPar.WorkDir '\'" & szPrefix & szY & ".mat')
        SetStatus("Loaded " & STIM.WorkDir & "\" & szPrefix & szY & ".mat")

        'update stimPar
        STIM.Matlab("stimPar.WorkDir = '" & STIM.WorkDir & "';")
        STIM.Matlab("stimPar.ID = '" & STIM.ID & "';")
        szX = "stimPar.Application=struct('Name','" & My.Application.Info.Title & _
        "','Version','" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & _
        "','FWVersion','" & TStr(FW_MAJOR) & "." & TStr(FW_MINOR) & "." & TStr(FW_REVISION) & "');"
        szX = MatlabCmd(szX)
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Load *M from .MAT: Error") : GoTo SubError

        szX = "if ~exist('Obj','var') || ~exist('meta','var') || ~exist('stimPar','var'); display 'No valid file or hM format (hM, meta, stimPar required)!'; end;"
        szX = MatlabCmd(szX)
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Load *M from .MAT: Error") : GoTo SubError

        UpdateObjectInfo()
        SetStatus("stimPar updated: WorkDir, ID, Application parameter")

SubError:
        'STIM.Matlab("clear formatversion;")
        UpdateObjectInfo()
        SetReady()
    End Sub

    'Public Function hMtoSOFA() As String
    '    Dim szX As String

    '    szX = MatlabCmd("Obj.Data.IR = shiftdim(hM,1);") ' hM is [N M R], data.IR must be [M R N]
    '    If Len(szX) > 0 Then Return szX

    '    'Add some SOFA parameters
    '    szX = MatlabCmd("AA_hM;")
    '    If Len(szX) > 0 Then Return szX

    '    szX = MatlabCmd("clear hLIN idxLIN")
    '    If Len(szX) > 0 Then Return szX

    '    szX = FixDataChannels()
    '    If Len(szX) > 0 Then Return szX

    '    'no errors
    '    Return ""
    'End Function

    Private Sub cmdMergeChannels_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMergeChannels.Click
        Dim szX, szMap As String
        Dim lChNr, lX As Integer
        Dim szArr() As String

        SetBusy()
        Dim szMsgBox As MsgBoxResult = MsgBox("YES: Merge to one record channel (e.g. preemphasis filters)" & vbCrLf & "NO: Merge to one play channel (e.g. analysis of headphones)" & vbCrLf & vbCrLf & "Your choice?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel, "How to merge?")
        If szMsgBox = MsgBoxResult.Yes Then
            ' merge to one record channel
            szX = MatlabCmd("unique(meta.pos(:,3))")
            If InStr(1, szX, "???") > 0 Then
                MsgBox(szX, MsgBoxStyle.Critical)
                SetReady()
                Exit Sub
            End If
            szArr = Split(szX, vbLf)
            szMap = ""
            For lX = 3 To UBound(szArr) - 2
                szX = InputBox(TStr(UBound(szArr) - 4) & " unique play channels found." & vbCrLf & vbCrLf & "For play channel #" & Trim(szArr(lX)) & ": " & vbCrLf & "use following record channel:" & vbCrLf & vbCrLf & "(0=ignore this Channel ID/Elevation)", "Merge to one record channel", "0")
                If Len(szX) = 0 Then SetReady() : Exit Sub
                szMap = szMap & szX & " "
            Next
            szX = "[Obj,meta]=AA_MergeChannels(Obj,meta,[" & szMap & "]);"
            szX = MatlabCmd(szX)
            If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Merge Channels") : SetReady() : Exit Sub
            SetStatus("Channels merged to new SOFA object (one record channel).")
        ElseIf szMsgBox = MsgBoxResult.No Then

            ' merge to one channel ID
            szX = MatlabCmd("disp(size(Obj.Data.IR,2))")
            If InStr(1, szX, "???") > 0 Then
                MsgBox(szX, MsgBoxStyle.Critical)
                SetReady()
                Exit Sub
            End If
            lChNr = CInt(Val(szX))
            szMap = ""
            For lX = 1 To lChNr
                szX = InputBox(TStr(lChNr) & " Record channels found. " & vbCrLf & "Copy Record channel #" & TStr(lX) & " from Channel ID/Elevation:", "Merge Channels", TStr(lX))
                If Len(szX) = 0 Then SetReady() : Exit Sub
                szMap = szMap & szX & ";"
            Next
            szX = "[Obj,meta]=AA_MergeChannels(Obj,meta,[" & szMap & "]);"
            szX = MatlabCmd(szX)
            If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Merge Channels") : SetReady() : Exit Sub
            SetStatus("Channels merged to new SOFA object (Channel ID=Inf).")
        End If

        UpdateObjectInfo()
        SetReady()
    End Sub

    Private Sub cmdMergeItems_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMergeItems.Click
        Dim szX As String
        Dim lRec1, lRec2 As Integer
        Dim szT As String

        SetBusy()
        szT = "Merge Items"
        szX = InputBox("Item with record channel 1: ", szT, "1")
        If Len(szX) = 0 Then SetReady() : Exit Sub
        If IsNumeric(szX) Then lRec1 = CInt(Val(szX))
        szX = InputBox("Item with record channel 2: ", szT, "2")
        If Len(szX) = 0 Then SetReady() : Exit Sub
        If IsNumeric(szX) Then lRec2 = CInt(Val(szX))

        szX = "[Obj,meta]=AA_MergeItems(Obj," & TStr(lRec1) & "," & TStr(lRec2) & ",meta);"
        szX = MatlabCmd(szX)
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, szT) : SetReady() : Exit Sub
        SetStatus("Items merged successfully")

        UpdateObjectInfo()
        SetReady()

    End Sub

    Private Sub cmdMinPhase_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMinPhase.Click
        Dim szX As String
        Dim szT As String = ""
        SetBusy()

        SetStatus("Calculating minimum phase signals...")
        szX = "[Obj.Data.IR]=shiftdim(AA_MinimalPhase(shiftdim(Obj.Data.IR,2)),1);"
        szX = MatlabCmd(szX)
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, szT) : SetReady() : Exit Sub

        szX = FixDataChannels()
        If Len(szX) > 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Fix Data Channels") : SetReady() : Exit Sub

        SetStatus("Minimum phase signals calculated.")
        SetReady()

    End Sub

    Private Sub cmdPlotM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPlotSofaData.Click

        SetBusy()
        frmPlotData.ShowDialog()
        If gblnShowStimulus Then PlotMatrix()
        SetReady()
    End Sub

    Sub PlotMatrix() ' moved from ToolboxIR
        Dim lRec As Integer
        Dim szErr, szX As String
        Dim szFilter As String
        Dim lElevation As Integer
        Dim szCh, szRecStream As String

        szX = InputBox("Input the index of the record stream: (:=all)", "Plot IR", "1")
        If Len(szX) = 0 Then Exit Sub
        If szX = ":" Then
            szCh = ":"
            szRecStream = "All record streams: "
        Else
            lRec = CInt(Val(szX) - 1)
            If lRec > GetUbound(gRecStream) Or lRec < 0 Then szErr = "Record stream not found." : GoTo SubError
            szCh = TStr(lRec + 1)
            szRecStream = "Record stream: " + gRecStream(lRec)
        End If
        szFilter = InputBox("Input an index filter rule (e.g.: find(meta.pos(:,1)==10) for all azimuth=10° or : for all positions):", "Plot Matrix SOFA object", "find(meta.pos(:,1)==10)")
        If Len(szFilter) = 0 Then Exit Sub

        lElevation = MsgBox("Do you want to label the Y-axis as elevation? (No: label as azimuth)", MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, "Label Y-axis")

        gblnCancel = False

        frmMain.SetProgressbar(0)
        'szErr = ""

        If lElevation = MsgBoxResult.Yes Then
            szX = "FW_ShowStimulus(hM(:," & szFilter & "," & szCh & "),stimPar,'" & szRecStream & "'," & TStr(glShowStimulusFlags) & ",[" & gszShowStimulusAxes & "],'elevation in °',meta.pos(" & szFilter & ",2),[" & gszShowStimulusParameter & "]);"
        Else
            szX = "FW_ShowStimulus(hM(:," & szFilter & "," & szCh & "),stimPar,'" & szRecStream & "'," & TStr(glShowStimulusFlags) & ",[" & gszShowStimulusAxes & "],'azimuth in °',meta.pos(" & szFilter & ",1),[" & gszShowStimulusParameter & "]);"
        End If

        szErr = STIM.Matlab(szX)
        If Len(szErr) <> 0 Then GoTo SubError
        frmMain.SetStatus("SOFA object plotted...")
NextItem:
        If Len(szErr) <> 0 Then
            MsgBox(szErr, MsgBoxStyle.Information, "Plot SOFA object: Warnings:")
        End If


        Exit Sub

SubError:
        MsgBox(szErr, MsgBoxStyle.Critical, "Plot Matrix SOFA object: Error")

        Exit Sub
    End Sub

    Private Sub cmdReshapeToLIN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdReshapeToLIN.Click
        Dim szX, szT As String
        SetBusy()
        szT = "Reshaping to hLIN"
        SetStatus("Reshaping SOFA object to hLIN and idxLIN...")
        szX = "hLIN=reshape(shiftdim(Obj.Data.IR,2), [], 2);"
        szX = MatlabCmd(szX)
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, szT) : SetReady() : Exit Sub
        szX = "idxLIN=[(0:size(Obj.Data.IR,1)-1)'*size(Obj.Data.IR,3)+1 (1:size(Obj.Data.IR,1))'*size(Obj.Data.IR,3)];"
        szX = MatlabCmd(szX)
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, szT) : SetReady() : Exit Sub
        'szX = "clear h-M"
        'szX = MatlabCmd(szX)
        'If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, szT) : SetReady() : Exit Sub
        'SetStatus("Reshaping sucessful. h-M cleared.")
        SetStatus("Reshaping sucessful.")
        UpdateObjectInfo()
        SetReady()

    End Sub

    Private Sub cmdSaveEMP_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSaveEMP.Click
        Dim szX, szY As String
        Dim sngBegin, sngTargetAmp As Double
        Dim lFreqStart, lFreqEnd As Integer
        Dim lCh As Integer
        Dim szT As String
        SetBusy()
        szT = "Calc and save emphasis filter"
        szX = InputBox("Which Channel? ", szT, "1")
        If Len(szX) = 0 Then SetReady() : Exit Sub
        If IsNumeric(szX) Then lCh = CInt(Val(szX))

        szX = InputBox("Target amplitude? [dB FS]: ", szT, "-6")
        If Len(szX) = 0 Then SetReady() : Exit Sub
        If IsNumeric(szX) Then sngTargetAmp = Val(szX)

        szX = InputBox("Start Frequency of target? [Hz]: ", szT, TStr(glFreqStart))
        If Len(szX) = 0 Then SetReady() : Exit Sub
        If IsNumeric(szX) Then lFreqStart = CInt(Val(szX))
        szX = InputBox("End Frequency of target? [Hz]: ", szT, TStr(glFreqEnd))
        If Len(szX) = 0 Then SetReady() : Exit Sub
        If IsNumeric(szX) Then lFreqEnd = CInt(Val(szX))

        szX = InputBox("Length of the resulting filter? [ms]: ", szT, "0")
        If Len(szX) = 0 Then SetReady() : Exit Sub
        If IsNumeric(szX) Then sngBegin = System.Math.Round(Val(szX) / 1000 * glSamplingRate)

        szY = InputBox("postfix of the result filter?: ", szT, "")
        If Len(szY) = 0 Then SetReady() : Exit Sub

        SetStatus("Calculating and saving emphasis filter to " & szY & "...")
        szX = "pos=AA_CalcSaveEMP(stimPar,shiftdim(Obj.Data.IR,2),meta," & TStr(lCh) & "," & TStr(sngTargetAmp) & "," & TStr(lFreqStart) & "," & TStr(lFreqEnd) & "," & TStr(sngBegin) & ",[stimPar.WorkDir '\' stimPar.ID '_EMP_" & szY & "']);"
        szX = MatlabCmd(szX)
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, szT) : SetReady() : Exit Sub
        SetStatus("Emphasis filters saved to " & STIM.ID & "_EMP_" & szY & ".mat")
        SetReady()

    End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        gblnCancel = True
        Me.Close()
    End Sub

    Private Sub cmdSaveFILT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSaveFILT.Click
        Dim szX, szY As String
        Dim lX As Integer
        Dim szT As String
        SetBusy()
        szT = "Calculate and save as FILTER"

        szX = Dir(STIM.WorkDir & "\" & STIM.ID & "_FILT_*.mat")
        If Len(szX) > 0 Then
            szY = "Filters with following postfixes could be found until now:" & vbCrLf
        Else
            szY = "No filters available until now."
        End If
        While Len(szX) > 0
            lX = Len(STIM.ID & "_FILT_")
            szY = szY & vbTab & Mid(szX, lX + 1, Len(szX) - lX - Len(".mat")) & vbCrLf
            szX = Dir()
        End While

        szY = InputBox("Input the postfix of the file: (File name will be: ID_FILT_postfix.mat)" & vbCrLf & szY, "Save *M as a filter file", "test")
        If Len(szY) = 0 Then SetReady() : Exit Sub

        SetStatus("Calculating and saving filter to " & szY & "...")
        szX = "AA_CalcSaveFILT(shiftdim(Obj.Data.IR,2),meta,[stimPar.WorkDir '\' stimPar.ID " & "'_FILT_" & szY & "']);"
        szX = MatlabCmd(szX)
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, szT) : SetReady() : Exit Sub
        SetStatus("Filter saved to " & STIM.ID & "_FILT_" & szY & ".mat")
        SetReady()
    End Sub

    Private Sub cmdSaveM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSaveM.Click
        Dim szVer, szX, szY As String
        Dim lX As Integer
        Dim lY As Integer = 0
        Dim szListItems() As String = Nothing

        SetBusy()
        szX = "version('-release');"
        szVer = STIM.Matlab(szX)

        szX = Dir(STIM.WorkDir & "\" & STIM.ID & "_M_*.mat")
        If Len(szX) > 0 Then
            szY = "Files with following postfixes could be found until now:" & vbCrLf
        Else
            szY = "No files available until now."
        End If
        While Len(szX) > 0
            lX = Len(STIM.ID & "_M_")
            'szY = szY & vbTab & Mid(szX, lX + 1, Len(szX) - lX - Len(".mat")) & vbCrLf
            ReDim Preserve szListItems(lY)
            szListItems(lY) = Mid(szX, lX + 1, Len(szX) - lX - Len(".mat"))

            szX = Dir()
            lY += 1

        End While
        frmListbox.txtName.Text = "" 'clear text box of form:
        szY = frmListbox.Init("Input the postfix of the file (File Name will be: ID_postfix.mat)" & vbCrLf & vbCrLf & szY, "Save *M to .MAT", szListItems, mszLastString)
        If Len(szY) = 0 Then
            If frmListbox.DialogResult = Windows.Forms.DialogResult.OK Then MsgBox("*M NOT saved to .MAT!", MsgBoxStyle.Exclamation, "Save *M to .MAT")
            SetReady()
            Exit Sub
        End If
        'If Len(szY) = 0 Then MsgBox("*M NOT saved to .MAT!", MsgBoxStyle.Exclamation, "Save *M to .MAT") : SetReady() : Exit Sub

        STIM.Matlab("stimPar.WorkDir = '" & STIM.WorkDir & "';")
        STIM.Matlab("stimPar.ID = '" & STIM.ID & "';")

        SetStatus("Saving data to " & szY & ".mat file...")

        'don't save WorkDir in stimPar
        szX = "TempWorkDir=stimPar.WorkDir;" 'temp folder name
        szX = MatlabCmd(szX)
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Save *M to MAT: Error when setting WorkDir!") : SetReady() : Exit Sub

        szX = "stimPar.WorkDir='';" 'clear original folder name
        szX = MatlabCmd(szX)
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Save *M to MAT: Error when setting WorkDir!" & vbCrLf & "Current WorkDir may be wrong!") : SetReady() : Exit Sub

        'calculate hM
        szX = "hM=shiftdim(Obj.Data.IR,2);"
        szX = MatlabCmd(szX)
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Save *M to MAT: Error when calculating hM") : SetReady() : Exit Sub

        If Val(szVer) < 14 Then
            szX = "save([TempWorkDir '\' stimPar.ID '_M_" & szY & ".mat'],'hM','meta','stimPar');"
        Else
            szX = "save([TempWorkDir '\' stimPar.ID '_M_" & szY & ".mat'],'hM','meta','stimPar','-V6');"
        End If
        szX = MatlabCmd(szX)
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Save *M to MAT: Error") : SetReady() : Exit Sub

        szX = "stimPar.WorkDir=TempWorkDir;" 'restore original folder name
        szX = MatlabCmd(szX)
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Save *M to MAT: Error when resetting WorkDir!" & vbCrLf & "Current WorkDir may be wrong!") : SetReady() : Exit Sub

        szX = "clear hM;" 'clear old format
        szX = MatlabCmd(szX)

        SetStatus("hM and meta data saved to " & STIM.WorkDir & "\" & STIM.ID & "_M_" & szY & ".mat")
        SetReady()
        Exit Sub

    End Sub

    Private Sub cmdScriptEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdScriptEdit.Click
        Dim szX As String
        Dim szY As String = ""
        'Dim szZ As String = "test"
        Dim lX As Integer
        Dim szListItems() As String = Nothing
        Dim lY As Integer = 0

        SetBusy()
        szX = Dir(STIM.WorkDir & "\" & STIM.ID & "_*.m")
        If Len(szX) = 0 Then
            MsgBox("No files are available.")
            SetReady()
            Exit Sub
        End If
        'While Len(szX) > 0
        '    lX = Len(STIM.ID & "_")
        '    szY = szY & vbTab & Mid(szX, lX + 1, Len(szX) - lX - Len(".m")) & vbCrLf
        '    If szZ = "test" Then szZ = Mid(szX, lX + 1, Len(szX) - lX - Len(".m"))
        '    szX = Dir()
        'End While

        'szY = InputBox("Input the postfix of the file (File Name will be: ID_postfix.m)" & vbCrLf & vbCrLf & "Files with following postfixes are available:" & vbCrLf & szY, "Load a script from .M file", szZ)
        'If Len(szY) = 0 Then SetReady() : Exit Sub


        While Len(szX) > 0
            lX = Len(STIM.ID & "_")
            szY = szY & vbTab & Mid(szX, lX + 1, Len(szX) - lX - Len(".m")) & vbCrLf
            ReDim Preserve szListItems(lY)
            szListItems(lY) = Mid(szX, lX + 1, Len(szX) - lX - Len(".m"))

            szX = Dir()
            lY += 1

        End While
        'frmListbox.TextBox1.Text = "" 'clear text box of form:
        szY = frmListbox.Init("Input the postfix of the file (File Name will be: ID_postfix.m)" & vbCrLf & vbCrLf & "Files with following postfixes are available:", "Edit a script from .M file", szListItems)
        If Len(szY) = 0 Then SetReady() : Exit Sub

        szX = STIM.Matlab("edit " & STIM.ID & "_" & szY & ".m")
        If Len(szX) > 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Error")
        SetReady()

    End Sub

    Private Sub cmdScriptRun_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdScriptRun.Click
        Dim szX As String
        Dim szY As String = ""
        'Dim szZ As String = "test"
        Dim lX As Integer
        Dim szListItems() As String = Nothing
        Dim lY As Integer = 0
        Dim StartTime As DateTime = System.DateTime.Now 'calculation time
        SetBusy()

        szX = Dir(STIM.WorkDir & "\" & STIM.ID & "_*.m")
        If Len(szX) = 0 Then
            If MsgBox("No files are available. Do you want to copy all " & STIM.ID & "_*.m script files from" & vbCrLf & _
                     STIM.MATLABPath & vbCrLf & "to your working directory?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Run .m script") = MsgBoxResult.Yes Then
                CopyScripts()
                szX = Dir(STIM.WorkDir & "\" & STIM.ID & "_*.m")
                If Len(szX) = 0 Then MsgBox("No script files are available in " & vbCrLf & STIM.WorkDir, , "Run .m script") : SetReady() : Exit Sub
            Else
                SetReady()
                Exit Sub
            End If
        End If

        While Len(szX) > 0
            lX = Len(STIM.ID & "_")
            szY = szY & vbTab & Mid(szX, lX + 1, Len(szX) - lX - Len(".m")) & vbCrLf
            ReDim Preserve szListItems(lY)
            szListItems(lY) = Mid(szX, lX + 1, Len(szX) - lX - Len(".m"))

            szX = Dir()
            lY += 1

        End While
        'frmListbox.TextBox1.Text = "" 'clear text box of form:
        szY = frmListbox.Init("Input the postfix of the file (File Name will be: ID_postfix.m)" & vbCrLf & vbCrLf & "Files with following postfixes are available:", "Run a script from .M file", szListItems)
        If Len(szY) = 0 Then SetReady() : Exit Sub

        SetStatus("Running " & STIM.ID & "_" & szY & ".m ...")

        Windows.Forms.Application.DoEvents() 'close msgbox
        szX = STIM.Matlab(STIM.ID & "_" & szY)
        Windows.Forms.Application.DoEvents()
        If Len(szX) > 0 Then
            MsgBox(szX, MsgBoxStyle.Critical, "Error")
            SetStatus("Errors running " & STIM.ID & "_" & szY & ".m")
        Else
            SetStatus("No errors.")
        End If

        SetStatus("Script running time: " & DateDiff(DateInterval.Second, StartTime, System.DateTime.Now).ToString & "s")
        SetReady()
        UpdateObjectInfo()

    End Sub

    Private Sub cmdScriptLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdScriptLoad.Click
        Dim szX As String
        Dim szY As String = ""
        'Dim szZ As String = "test"
        Dim lX As Integer
        Dim bX As Byte
        Dim szListItems() As String = Nothing
        Dim lY As Integer = 0

        SetBusy()
        szX = Dir(STIM.WorkDir & "\" & STIM.ID & "_*.m")
        If Len(szX) = 0 Then
            MsgBox("No files are available.")
            SetReady()
            Exit Sub
        End If
        'While Len(szX) > 0
        '    lX = Len(STIM.ID & "_")
        '    szY = szY & vbTab & Mid(szX, lX + 1, Len(szX) - lX - Len(".m")) & vbCrLf
        '    If szZ = "test" Then szZ = Mid(szX, lX + 1, Len(szX) - lX - Len(".m"))
        '    szX = Dir()
        'End While

        'szY = InputBox("Input the postfix of the file (File Name will be: ID_postfix.m)" & vbCrLf & vbCrLf & "Files with following postfixes are available:" & vbCrLf & szY, "Load a script from .M file", szZ)
        'If Len(szY) = 0 Then SetReady() : Exit Sub


        While Len(szX) > 0
            lX = Len(STIM.ID & "_")
            szY = szY & vbTab & Mid(szX, lX + 1, Len(szX) - lX - Len(".m")) & vbCrLf
            ReDim Preserve szListItems(lY)
            szListItems(lY) = Mid(szX, lX + 1, Len(szX) - lX - Len(".m"))

            szX = Dir()
            lY += 1

        End While
        'frmListbox.TextBox1.Text = "" 'clear text box of form:
        szY = frmListbox.Init("Input the postfix of the file (File Name will be: ID_postfix.m)" & vbCrLf & vbCrLf & "Files with following postfixes are available:", "Load a script from .M file", szListItems)
        If Len(szY) = 0 Then SetReady() : Exit Sub

        FileOpen(1, STIM.WorkDir & "\" & STIM.ID & "_" & szY & ".m", OpenMode.Binary)

        szX = ""
        Do
            FileGet(1, bX)
            szX &= Chr(bX)
        Loop Until EOF(1)
        FileClose(1)

        gszScript = szX
        SetReady()

    End Sub

    Private Sub cmdScriptSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdScriptSave.Click
        Dim szX, szY As String
        Dim lX As Integer
        Dim szListItems() As String = Nothing
        Dim lY As Integer = 0

        szX = Dir(STIM.WorkDir & "\" & STIM.ID & "_*.m")
        If Len(szX) > 0 Then
            szY = "Files with following postfixes could be found until now:" & vbCrLf
        Else
            szY = "No files available until now."
        End If
        'While Len(szX) > 0
        '    lX = Len(STIM.ID & "_")
        '    szY = szY & vbTab & Mid(szX, lX + 1, Len(szX) - lX - Len(".m")) & vbCrLf
        '    szX = Dir()
        'End While

        'szY = InputBox("Input the postfix of the file: (File name will be: ID_postfix.m)" & vbCrLf & szY, "Save script as .M", "test")
        'If Len(szY) = 0 Then SetReady() : Exit Sub

        While Len(szX) > 0
            lX = Len(STIM.ID & "_")
            szY = szY & vbTab & Mid(szX, lX + 1, Len(szX) - lX - Len(".m")) & vbCrLf
            ReDim Preserve szListItems(lY)
            szListItems(lY) = Mid(szX, lX + 1, Len(szX) - lX - Len(".m"))

            szX = Dir()
            lY += 1

        End While
        frmListbox.txtName.Text = "" 'clear text box of form:
        szY = frmListbox.Init("Input the postfix of the file (File Name will be: ID_postfix.m)" & vbCrLf & vbCrLf & "Files with following postfixes are available:", "Save script as .M file", szListItems)
        If Len(szY) = 0 Then
            If frmListbox.DialogResult = Windows.Forms.DialogResult.OK Then MsgBox("Script NOT saved to *M file!", MsgBoxStyle.Exclamation, "Save script as *M file")
            SetReady()
            Exit Sub
        End If


        FileOpen(1, STIM.WorkDir & "\" & STIM.ID & "_" & szY & ".m", OpenMode.Binary)

        For lX = 1 To Len(gszScript)
            FilePut(1, CByte(Asc(Mid(gszScript, lX, 1))))
        Next

        FileClose(1)

    End Sub

    Private Sub cmdScriptShow_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdScriptShow.Click

        frmInputMultiline.Text_Renamed = gszScript
        If frmInputMultiline.ShowForm("Matlab Script") Then
            gszScript = frmInputMultiline.Text_Renamed
        End If

    End Sub

    Private Sub cmdSmoothCepstral_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSmoothCepstral.Click
        Dim szX As String
        'Dim szY As String 
        Dim sngQuefr As Double
        Dim szT As String

        SetBusy()
        szT = "Smooth the Spectrum with a cepstral lifter"
        szX = InputBox("Low pass quefrency of the lifter [ms]: ", szT, "2")
        If Len(szX) = 0 Then SetReady() : Exit Sub
        If IsNumeric(szX) Then sngQuefr = System.Math.Round(Val(szX) / 1000 * glSamplingRate)

        SetStatus("Smoothing spectrum...")
        szX = "[Obj,cepsX]=AA_SmoothCepstral(Obj," & TStr(sngQuefr) & ");"
        szX = MatlabCmd(szX)
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, szT) : SetReady() : Exit Sub
        SetStatus("Smoothing successful")

        UpdateObjectInfo()
        SetReady()
    End Sub

    Private Sub cmdUpdateInfo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdateInfo.Click
        UpdateObjectInfo()
    End Sub

    Private Sub cmdWindow_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdWindow.Click
        Dim szX As String
        Dim sngFadeOut, sngFadeIn As Double
        Dim sngEnd, sngBegin As Double
        Dim szT As String

        SetBusy()
        szT = "Window"
        szX = InputBox("Begin of window in SOFA object (Offset)? [ms]: ", szT, "0")
        If Len(szX) = 0 Then SetReady() : Exit Sub
        If IsNumeric(szX) Then sngBegin = System.Math.Round(Val(szX) / 1000 * glSamplingRate)
        szX = InputBox("End of window in SOFA object (Offset+Length)? [ms]: ", szT, "10")
        If Len(szX) = 0 Then SetReady() : Exit Sub
        If IsNumeric(szX) Then sngEnd = System.Math.Round(Val(szX) / 1000 * glSamplingRate)
        szX = InputBox("Fade In? [ms]: ", szT, "1")
        If Len(szX) = 0 Then SetReady() : Exit Sub
        If IsNumeric(szX) Then sngFadeIn = System.Math.Round(Val(szX) / 1000 * glSamplingRate)
        szX = InputBox("Fade Out? [ms]: ", szT, "3")
        If Len(szX) = 0 Then SetReady() : Exit Sub
        If IsNumeric(szX) Then sngFadeOut = System.Math.Round(Val(szX) / 1000 * glSamplingRate)

        SetStatus("Windowing...")
        szX = "[Obj.Data.IR]=shiftdim(AA_Window(shiftdim(Obj.Data.IR,2)," & TStr(sngEnd) & "-" & TStr(sngBegin) & "," & TStr(sngFadeOut) & "," & TStr(sngFadeIn) & "," & TStr(sngBegin) & "),1);"
        szX = MatlabCmd(szX)
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, szT) : SetReady() : Exit Sub

        szX = FixDataChannels()
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, szT) : SetReady() : Exit Sub

        SetStatus("Windowing successful")

        UpdateObjectInfo()
        SetReady()
    End Sub

    Private Sub frmPostProcessing_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        If grectfrmIR.Left <> 0 And grectfrmIR.Top <> 0 Then
            Me.Left = CInt(Val(VB6.TwipsToPixelsX(grectfrmIR.Left)))
            Me.Top = CInt(Val(VB6.TwipsToPixelsY(grectfrmIR.Top)))
        Else
            Me.Left = frmMain.Left + CInt(Me.Width / 10)
            Me.Top = frmMain.Top + CInt(Me.Height / 10)
        End If

        If gblnOutputStable Then UpdateObjectInfo()
        SetReady()

    End Sub

    Private Sub frmPostProcessing_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        grectfrmIR.Left = CInt(Val(VB6.PixelsToTwipsX(Me.Left)))
        grectfrmIR.Top = CInt(Val(VB6.PixelsToTwipsY(Me.Top)))
        eventArgs.Cancel = Cancel
    End Sub

    Private Sub btnConvertARI2STx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvertARI2STx.Click
        SetBusy()
        Dim szX As String

        szX = InputBox("Please enter output file name", "Stim File Name", "STx File")

        If szX = "" Then MsgBox("Cancelled", MsgBoxStyle.Exclamation, "Stim File Name") : SetReady() : Exit Sub

        szX = MatlabCmd("stimPar.StimFileName = '" & szX & "';")
        If Len(szX) > 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Error") : SetReady() : Exit Sub

        szX = MatlabCmd("AA_ARI2STx(shiftdim(Obj.Data.IR,2),meta,stimPar);")
        If Len(szX) > 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Error") : SetReady() : Exit Sub

        SetStatus("STx files successfully created")
        SetReady()
    End Sub

    Private Sub btnConvertCIPIC2ARI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvertCIPIC2ARI.Click
        SetBusy()
        Dim szX As String
        Dim szFile As String

        Dim dlgOpen As New OpenFileDialog
        dlgOpen.Title = "Load CIPIC HRTF data file"
        dlgOpen.InitialDirectory = gszCurrentDir
        dlgOpen.FileName = "hrir_final.mat"
        dlgOpen.CheckFileExists = True
        dlgOpen.CheckPathExists = True
        dlgOpen.Filter = "MATLAB Files (*.mat)|*.mat|All Files (*.*)|*.*"
        dlgOpen.FilterIndex = 1
        dlgOpen.DefaultExt = "*.mat"
        dlgOpen.SupportMultiDottedExtensions = True
        If dlgOpen.ShowDialog() = Windows.Forms.DialogResult.OK Then
            szFile = dlgOpen.FileName
            gszCurrentDir = Mid(dlgOpen.FileName, 1, Len(dlgOpen.FileName) - Len((New System.IO.FileInfo(dlgOpen.FileName)).Name) - 1)
            Dim gszCurrentFile As String = Mid(dlgOpen.FileName, Len(dlgOpen.FileName) - Len((New System.IO.FileInfo(dlgOpen.FileName)).Name) + 1, Len(dlgOpen.FileName))

            'Run MATLAB script
            szX = MatlabCmd("[hM,meta,stimPar]=AA_CIPIC2ARI('" & szFile & "',stimPar);")
            If Len(szX) > 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Error") : SetReady() : Exit Sub
            UpdateObjectInfo()
            SetStatus("CIPIC HRTF data successfully imported from: " & gszCurrentFile)

            MsgBox("CIPIC HRTF data successfully imported from: " & gszCurrentFile & vbCrLf, _
                     MsgBoxStyle.Information, "Load from CIPIC")

        End If

        SetReady()
    End Sub

    Private Sub btnConvertARI2CIPIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvertARI2CIPIC.Click
        SetBusy()
        Dim szX As String
        'Dim szFile As String
        Dim lShowFigures As Integer = 0
        Dim msg As MsgBoxResult
        Dim szFile As String


        msg = MsgBox("Please note: The HRTF positions are not the same in the ARI and CIPIC format. For example: The polar angles in ARI format cover a range from -30 to 80 deg, the range in CIPIC is from -45 to 90 deg (and 230.625 in the back). Even though the ARI format provides a flexible grid, the HRTF positions in the CIPIC format are hard-coded. During the conversion to CIPIC, the HRTF positions are adapted to the CIPIC grid, which may result in errors. The errors for the lateral and polar angles, together with spheres showing the ARI and CIPIC positions, can be plotted for an arbitrary ARI grid." & vbCrLf & vbCrLf & _
                     "Do you want to plot figures showing the Lateral, Polar, Azimuth and Elevation error, for each position; and a sphere comparing ARI and CIPIC positions?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question, "Save as CIPI: Plot figures")
        If msg = MsgBoxResult.Cancel Then SetReady() : Exit Sub
        If msg = MsgBoxResult.Yes Then lShowFigures = 1

        'Run MATLAB script
        szX = MatlabCmd("[hrir_l,hrir_r,name]=AA_ARI2CIPIC(shiftdim(Obj.Data.IR,2),meta,stimPar," & lShowFigures & ");")
        If Len(szX) > 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Error") : SetReady() : Exit Sub
        UpdateObjectInfo()
        SetStatus("ARI HRTF data successfully converted to CIPIC")

        Dim dlgSave As New SaveFileDialog
        dlgSave.InitialDirectory = gszCurrentDir
        dlgSave.FileName = "ARI2CIPIC.mat"
        dlgSave.Title = "Save as CIPIC"
        dlgSave.Filter = "MATLAB Files (*.mat)|*.mat|All Files (*.*)|*.*"
        dlgSave.DefaultExt = "*.mat"
        dlgSave.FilterIndex = 1
        dlgSave.OverwritePrompt = True
        dlgSave.SupportMultiDottedExtensions = True
        If dlgSave.ShowDialog() = Windows.Forms.DialogResult.OK Then
            szFile = dlgSave.FileName
            gszCurrentDir = Mid(dlgSave.FileName, 1, Len(dlgSave.FileName) - Len((New System.IO.FileInfo(dlgSave.FileName)).Name) - 1)

            szX = MatlabCmd("save('" & szFile & "','hrir_l','hrir_r','name');")
            ' save as CIPIC
            If Len(szX) <> 0 Then
                MsgBox("Can't save file:" & vbCrLf & szX, MsgBoxStyle.Critical, "Save file")
                SetReady() : Exit Sub
            End If
        End If

        SetStatus("HRTF data successfully saved in CIPIC format")

        SetReady()

    End Sub

    Private Sub cmdCalcTimeOfArrival_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalcTimeOfArrival.Click

        SetBusy()
        frmCalcTOA.Enabled = True
        frmCalcTOA.ShowDialog()
        'If gblnShowStimulus Then ToolboxIR.PlotMatrix(0, 0)
        SetReady()


    End Sub

    Private Sub cmdPlotTimeOfArrival_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlotTimeOfArrival.Click

        SetBusy()
        frmPlotTOA.Enabled = True
        frmPlotTOA.ShowDialog()
        'If gblnShowStimulus Then ToolboxIR.PlotMatrix(0, 0)
        SetReady()
    End Sub

    Private Sub btnCloseFigures_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseFigures.Click
        Dim szX As String
        SetBusy()
        szX = MatlabCmd("close all;")
        If Len(szX) > 0 Then
            SetStatus("Error when closing all MATLAB Figures")
            MsgBox(szX, MsgBoxStyle.Critical, "Error")
        Else
            SetStatus("All MATLAB Figures closed")
        End If
        SetReady()
    End Sub

    Private Sub cmdSaveSofa_Click(sender As System.Object, e As System.EventArgs) Handles cmdSaveSofa.Click
        SOFAsave()

    End Sub

    Public Sub SOFAsave()
        Dim szX, szY As String
        Dim szFileName, szConvention As String
        Dim lY As Integer = 0
        'Dim lYS As Integer = 0
        Dim lX As Integer
        Dim szListItems() As String = Nothing
        Dim szConventions() As String = Nothing

        SetBusy()

        ' Filename
        szX = Dir(STIM.WorkDir & "\*.sofa")
        If Len(szX) > 0 Then
            szY = "The following .SOFA files are available:" & vbCrLf
            If mszLastString = "" Then mszLastString = "ref1 unmerged"
        Else
            szY = "No files available until now."
        End If

        While Len(szX) > 0
            lX = Len(STIM.ID & "_M_")
            ReDim Preserve szListItems(lY)
            szListItems(lY) = Mid(szX, lX + 1, Len(szX) - lX - Len(".sofa"))

            szX = Dir()
            lY += 1
        End While

        frmListbox.txtName.Text = "" 'clear text box of form:
        szFileName = frmListbox.Init("Input the file name" & vbCrLf & vbCrLf & szY, "Save *M to .SOFA", szListItems,  mszLastString)
        If Len(szFileName) = 0 Then
            If frmListbox.DialogResult = Windows.Forms.DialogResult.OK Then MsgBox("*M NOT saved to .SOFA!", MsgBoxStyle.Exclamation, "Save *M to .SOFA")
            SetReady()
            Exit Sub
        End If

        szX = Dir(STIM.MATLABPath & "\AA_SOFAsave*.m")
        If Len(szX) > 0 Then
            szY = "The following SOFA conventions are available:" & vbCrLf
        Else
            szY = "No SOFA conventions available."
        End If

        lY = 0
        While Len(szX) > 0
            'lX = 3
            ReDim Preserve szConventions(lY)
            szConventions(lY) = Mid(szX, 12, Len(szX) - 13)

            szX = Dir()
            lY += 1
        End While

        Dim szRecommendation As String = ""
        If lY = 1 Then  ' only one SOFA convention available
            szConvention = szConventions(0)
        Else
            If InStr(lcase(szFileName), "hpir") > 0 Then 'headphones
                szRecommendation = "SimpleHeadphoneIR"

            elseIf InStr(lcase(gszExpID), "las") > 0 Then ' ARI: LAS

                If InStr(lcase(szFileName), "ref") > 0 Then
                    szRecommendation = "GeneralFIRLAS"                              
                ElseIf InStr(lcase(szFileName), "raw") > 0 Then
                    szRecommendation = "SimpleFreeFieldHRIRLAS"
                ElseIf InStr(lcase(szFileName), "dtf") > 0 Then
                    szRecommendation = "SimpleFreeFieldHRIRLAS"
                ElseIf InStr(lcase(szFileName), "hrtf") > 0 Then
                    szRecommendation = "SimpleFreeFieldHRIRLAS"
                End if

            Else ' ARI: yellow booth

                If InStr(lcase(szFileName), "ref") > 0 Then
                    szRecommendation = "GeneralFIR"                              
                ElseIf InStr(lcase(szFileName), "raw") > 0 Then
                    szRecommendation = "SimpleFreeFieldHRIR"
                ElseIf InStr(lcase(szFileName), "dtf") > 0 Then
                    szRecommendation = "SimpleFreeFieldHRIR"
                ElseIf InStr(lcase(szFileName), "hrtf") > 0 Then
                    szRecommendation = "SimpleFreeFieldHRIR"
                End if

            End If
         
            szConvention = frmListbox.Init("Choose SOFA convention!" & vbCrLf & vbCrLf & szY, "SOFAsave Conventions", szConventions, szRecommendation)
            If Len(szConvention) = 0 Then
                If frmListbox.DialogResult = Windows.Forms.DialogResult.OK Then MsgBox("No convention selected!", MsgBoxStyle.Exclamation, "SOFAsave Conventions")
                SetReady()
                Exit Sub
            End If
            End If

            STIM.Matlab("stimPar.WorkDir = '" & STIM.WorkDir & "';")
            STIM.Matlab("stimPar.ID = '" & STIM.ID & "';")

            SetStatus("Saving data to " & STIM.WorkDir & "\" & STIM.ID & "_M_" & szFileName & ".sofa")

            ' Save... finally :-)
            'szX = "save([TempWorkDir '\' stimPar.ID '_M_" & szY & ".mat'],'h-M','meta','stimPar');"
            szX = "AA_SOFAsave" & szConvention & "([stimPar.WorkDir '\' stimPar.ID '_M_" & szFileName & ".sofa'], Obj, meta, stimPar);" 'Save SOFA file
            szX = MatlabCmd(szX)
            If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Save *M to SOFA: Error when saving SOFA file!") : SetReady() : Exit Sub

            SetStatus("HRTF data saved to " & STIM.WorkDir & "\" & STIM.ID & "_M_" & szFileName & ".sofa")
            SetReady()
            Exit Sub
    End Sub

    Private Sub cmdLoadSofa_Click(sender As System.Object, e As System.EventArgs) Handles cmdLoadSofa.Click
        Dim szX, szText As String
        Dim szY As String = ""
        Dim szListItems() As String = Nothing
        Dim lY As Integer = 0
        Dim lX As Integer
        Dim szPrefix As String = ""

        SetBusy()
        szX = Dir(STIM.WorkDir & "\" & STIM.ID & "_M_*.sofa")
        If Len(szX) = 0 Then
            If MsgBox("No .sofa files are available with Prefix '" & STIM.ID & "_M_'." & vbCrLf & "Do you want to view all .sofa files in folder?", MsgBoxStyle.YesNo Or MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                szX = Dir(STIM.WorkDir & "\" & "*.sofa")
                While Len(szX) > 0
                    'lX = Len(STIM.ID & "_M_")
                    ReDim Preserve szListItems(lY)
                    szListItems(lY) = Strings.Left(szX, Len(szX) - Len(".sofa"))
                    szX = Dir()
                    lY += 1
                End While
                szText = "Input the postfix of the file"
            Else
                GoTo SubError
            End If
        Else
            While Len(szX) > 0
                lX = Len(STIM.ID & "_M_")
                ReDim Preserve szListItems(lY)
                szListItems(lY) = Mid(szX, lX + 1, Len(szX) - lX - Len(".sofa"))
                szX = Dir()
                lY += 1
            End While
            szText = "Input the postfix of the file (File Name will be: ID_postfix.sofa)"
            szPrefix = STIM.ID & "_M_"
        End If

        szText = "Input the postfix of the file"

        szY = frmListbox.Init(szText & vbCrLf & vbCrLf & "The following .SOFA files are available:", "Load *M from .SOFA", szListItems)
        If Len(szY) = 0 Then GoTo SubError
        mszLastString = szY

        STIM.Matlab("clear Obj hM meta;")
        'reset stimPar
        ResetStimPar(glSamplingRate, glResolution)
        STIM.Matlab("stimPar.WorkDir = '" & STIM.WorkDir & "';")

        szX = "[Obj, meta, stimPar] = AA_SOFAload([stimPar.WorkDir '\" & szPrefix & szY & ".sofa ']);" 'load SOFA file
        szX = MatlabCmd(szX)
        If InStr(LCase(szX), "error") <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Load SOFA: Error when loading SOFA file") : GoTo SubError ' SetReady() : Exit Sub

        SetStatus("Loaded " & STIM.WorkDir & "\" & szPrefix & szY & ".sofa")

        'update stimPar
        STIM.Matlab("stimPar.WorkDir = '" & STIM.WorkDir & "';")
        STIM.Matlab("stimPar.ID = '" & STIM.ID & "';")
        szX = "stimPar.Application=struct('Name','" & My.Application.Info.Title & _
        "','Version','" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & _
        "','FWVersion','" & TStr(FW_MAJOR) & "." & TStr(FW_MINOR) & "." & TStr(FW_REVISION) & "');"
        szX = MatlabCmd(szX)
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Load *M from .SOFA: Error") : GoTo SubError

        szX = "if ~exist('Obj','var') || ~exist('meta','var') || ~exist('stimPar','var'); display 'No valid SOFA HRTF file!'; end;"
        szX = MatlabCmd(szX)
        If Len(szX) <> 0 Then MsgBox(szX, MsgBoxStyle.Critical, "Load *M from .SOFA: Error") : GoTo SubError

        'Updateh-MInfo()
        SetStatus("stimPar updated: WorkDir, ID, Application parameter")

SubError:
        UpdateObjectInfo()
        SetReady()
    End Sub

    Private Sub cmdCopyScripts_Click(sender As System.Object, e As System.EventArgs) Handles cmdCopyScripts.Click
        SetBusy()

        CopyScripts()

        SetReady()
        UpdateObjectInfo()
    End Sub

    Private Sub cmdFixDataChannels_Click(sender As Object, e As EventArgs) Handles cmdFixDataChannels.Click

        SetBusy()

        Dim szErr As String = FixDataChannels()
        If Len(szErr) > 0 Then MsgBox(szErr, MsgBoxStyle.Critical, "Error") : GoTo SubError

        SetStatus("Data channels checked and possibly fixed")

SubError:
        UpdateObjectInfo()
        SetReady()

    End Sub

    Private Function FixDataChannels(Optional szObject As String = "Obj") As String

        Dim szX As String = "if ndims(" & szObject & ".Data.IR) == 2; " & szObject & ".Data.IR = permute(" & szObject & ".Data.IR,[1 3 2]); end;"
        Return MatlabCmd(szX)

    End Function

    Private Sub btnOpenDocFolder_Click(sender As Object, e As EventArgs) Handles btnOpenDocFolder.Click
        
        Dim DocPath As String = Nothing

        If Strings.Right(My.Application.Info.DirectoryPath, Len("\bin")) = "\bin" Then
            DocPath = Strings.Left(My.Application.Info.DirectoryPath, Len(My.Application.Info.DirectoryPath) - Len("\bin"))
        ElseIf Strings.Right(My.Application.Info.DirectoryPath, Len("\obj")) = "\obj" Then
            DocPath = Strings.Left(My.Application.Info.DirectoryPath, Len(My.Application.Info.DirectoryPath) - Len("\obj"))
        Else
            DocPath = My.Application.Info.DirectoryPath ' & "\doc"
        End If

        'Dim HistoryFile As String = HistoryPath & "\history.txt"
        Process.Start(DocPath & "\doc")

    End Sub

    Private Sub cmdClearScriptHistory_Click(sender As Object, e As EventArgs) Handles cmdClearScriptHistory.Click
        If MsgBox("Do you really want to clear the current script history?",MsgBoxStyle.YesNo Or MsgBoxStyle.Question,"Clear Script History") = MsgBoxResult.Yes Then
            gszScript=Nothing
            SetStatus("Script history cleared.")
        End If
    End Sub

    Private Sub CopyScripts()

        Dim szX As String

        szX = Dir(STIM.MATLABPath & "\" & STIM.ID & "_*.m")
        If Len(szX) = 0 Then
            MsgBox("No script files are available in " & vbCrLf & STIM.MATLABPath, , "Copy .m scripts")

            SetReady()
            Exit Sub
        End If

        While Len(szX) > 0
            If File.Exists(STIM.WorkDir & "\" & szX) Then
                If MsgBox(STIM.WorkDir & "\" & szX & vbCrLf & "already exists in target folder! Do you want to overwrite it?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, _
                          "Copy script files to work directory") = MsgBoxResult.Yes Then
                    File.Copy(STIM.MATLABPath & "\" & szX, STIM.WorkDir & "\" & szX, True)
                    SetStatus("Successfully copied " & STIM.WorkDir & "\" & szX)
                End If
            Else
                File.Copy(STIM.MATLABPath & "\" & szX, STIM.WorkDir & "\" & szX)
                SetStatus("Successfully copied " & STIM.WorkDir & "\" & szX)
            End If

            szX = Dir()

        End While

    End Sub

End Class