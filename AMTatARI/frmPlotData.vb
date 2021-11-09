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
Friend Class frmPlotData
    Inherits System.Windows.Forms.Form
    Private IsInitializing As Boolean
    ''
    ' FrameWork Module. Implementation of the Show Stimulus dialog.


    Sub ShowParameterSets()
        Dim lX As Integer
        lstParameters.Items.Clear()
        If gphmParameters Is Nothing Then Exit Sub
        For lX = 0 To gphmParameters.Count() - 1
            If gphmParameters.Item(lX).Valid Then
                lstParameters.Items.Add(gphmParameters.Item(lX).Title)
            End If
        Next

    End Sub

    Sub SaveParameterSets(ByRef szFile As String, Optional szFolder As String = Nothing)
        Dim szArr(,) As String
        Dim szErr As String
        Dim lX, lY As Integer
        Dim csvX As New CSVParser

        lY = 0
        For lX = 0 To gphmParameters.Count() - 1
            If gphmParameters.Item(lX).Valid Then lY = lY + 1
        Next
        ReDim szArr(lY, 7)
        szArr(0, 0) = "Title"
        szArr(0, 1) = "Flags"
        szArr(0, 2) = "Parameter"
        szArr(0, 3) = "RecChannel"
        szArr(0, 4) = "Filter"
        szArr(0, 5) = "Axes"
        szArr(0, 6) = "Optional"
        szArr(0, 7) = "Flat"

        lY = 0
        For lX = 0 To gphmParameters.Count() - 1
            With gphmParameters.Item(lX)
                If .Valid Then
                    lY += 1
                    szArr(lY, 0) = .Title
                    szArr(lY, 1) = TStr(.Flags)
                    szArr(lY, 2) = TStr(.Parameter)
                    szArr(lY, 3) = .RecChannel
                    szArr(lY, 4) = .Filter
                    szArr(lY, 5) = .Axes
                    szArr(lY, 6) = .OptionalParameters
                    szArr(lY, 7) = TStr(CInt(.Flat))
                End If
            End With
        Next

        If szFolder=Nothing Then
            szErr = csvX.WriteArr((Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & _
                               "\ExpSuite\" & My.Application.Info.Title & "\" & szFile), szArr)
        Else ' export to work dir
            szErr = csvX.WriteArr((szFolder & "\" & szFile), szArr)
            If szErr = "" Then MsgBox("Parameter set list successfully exported to:" & vbCrLf & vbCrLf & szFolder & "\" & szFile,MsgBoxStyle.Information,"Export Parameter Set List")
        End If

        If Len(szErr) > 0 Then
            MsgBox(szErr, MsgBoxStyle.Critical, "Save Parameter Set List")
        End If

    End Sub

    Sub LoadParameterSets(ByRef szFile As String, Optional bForce As Boolean = False)
        Dim csvX As New CSVParser
        Dim szErr As String
        Dim szArr(,) As String = Nothing
        Dim lX As Integer

        gphmParameters = New Generic.List(Of PlothMParameterSet)

        UpdateMatlabFlags()

        ' File location: The directory that serves as a common repository for application-specific data that is used by all users.
        szFile = (Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\ExpSuite\" & My.Application.Info.Title & "\" & szFile)

        ' Parameter file existing?
        If bForce or Dir(szFile) = "" Then ' not existing
            Dim szDefaultFile As String = AppResourcesDirectory & "\parametersetlist.def" ' Default file
            If Dir(szDefaultFile) <> "" Then FileCopy(szDefaultFile, szFile) ' copy default file
        End If

        szErr = csvX.ReadArr(szFile, szArr)
        If Len(szErr) > 0 Then GoTo SubError
        If UBound(szArr, 2) < 6 Then
            szErr = "Invalid number of columns in the file (at least 6 columns are required)."
            GoTo SubError
        End If
        Dim gphmX As PlothMParameterSet
        For lX = 1 To UBound(szArr, 1)
            gphmX = New PlothMParameterSet
            gphmX.Title = szArr(lX, 0)
            gphmX.Flags = CInt(Val(szArr(lX, 1)))
            gphmX.Parameter = CInt(Val(szArr(lX, 2)))
            gphmX.RecChannel = szArr(lX, 3)
            'update to structured meta data:
            gphmX.Filter = Replace(Replace(szArr(lX, 4), "posLIN", "meta.pos"), "itemidxLIN", "meta.itemidx")
            gphmX.Axes = szArr(lX, 5)
            gphmX.OptionalParameters = szArr(lX, 6)
            If UBound(szArr, 2) > 6 Then gphmX.Flat=CBool(Val(szArr(lX, 7))) ' shading flat option already included?
            gphmX.Valid = True
            gphmParameters.Add(gphmX)
        Next

        Exit Sub
SubError:
        MsgBox(szErr, MsgBoxStyle.Critical, "Load Parameter Set List")

    End Sub

    Private Sub cmbMode_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbMode.SelectedIndexChanged
        If Me.IsInitializing Then
            Exit Sub
        Else
            If ((gphmCurrent.Flags \ 256) And 7) <> cmbMode.SelectedIndex Then
                gphmCurrent.Flags = cmbShowStimDomain.SelectedIndex + cmbShowStimX.SelectedIndex * 2 + cmbShowStimY.SelectedIndex * 16 + CInt(optMatrixMode.Checked) * -128 + cmbMode.SelectedIndex * 256
                gphmCurrent.GetParameters("")
                gphmCurrent.SetControls()
            End If
            UpdateMatlabFlags()
        End If
        Select Case cmbMode.SelectedIndex
            Case 0,2,4 'color plot, mesh, surface
                If me.optMatrixMode.Checked = True Then 'matrix mode?
                    ckbFlat.Enabled=True
                Else
                    ckbFlat.Enabled=False
                End If
                
            Case Else
                ckbFlat.Enabled=False
        End Select
    End Sub

    Private Sub cmbShowStimDomain_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbShowStimDomain.SelectedIndexChanged
        If Me.IsInitializing Then
            Exit Sub
        Else
            If (gphmCurrent.Flags And 1) <> cmbShowStimDomain.SelectedIndex Then
                gphmCurrent.Flags = cmbShowStimDomain.SelectedIndex + cmbShowStimX.SelectedIndex * 2 + cmbShowStimY.SelectedIndex * 16 + CInt(optMatrixMode.Checked) * -128 + cmbMode.SelectedIndex * 256
                gphmCurrent.GetParameters("")
                gphmCurrent.SetControls()
            End If
            UpdateMatlabFlags()
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdDeleteParameters_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDeleteParameters.Click

        If lstParameters.SelectedIndex < 0 Then Return
        gphmParameters.RemoveAt(lstParameters.SelectedIndex)
        SaveParameterSets("parametersetlist.csv")
        ShowParameterSets()

    End Sub

    Private Sub cmdFilter00_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFilter00.Click
        txtFilter.Text = "find(meta.pos(:,1)==0 & meta.pos(:,2)==0)"
    End Sub

    Private Sub cmdFilter0and45_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFilter0and45.Click
        txtFilter.Text = "find(meta.pos(:,2)==0 & (meta.pos(:,1)==40 | meta.pos(:,1)==45))"
    End Sub

    Private Sub cmdFilterAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFilterAll.Click
        txtFilter.Text = ":"
    End Sub

    Private Sub cmdFilterHorizontal_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFilterHorizontal.Click
        txtFilter.Text = "find(meta.pos(:,2)==0)"
    End Sub

    Private Sub cmdFilterItem1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFilterItem1.Click
        txtFilter.Text = "find(meta.itemidx==1)"
    End Sub

    Private Sub cmdFilterMedian_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFilterMedian.Click
        txtFilter.Text = "find(meta.pos(:,1)==0)"
    End Sub

    Private Sub cmdLoadParameters_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoadParameters.Click

        If lstParameters.SelectedIndex < 0 Then Exit Sub
        gphmCurrent.Axes = gphmParameters.Item(lstParameters.SelectedIndex).Axes
        gphmCurrent.Flags = gphmParameters.Item(lstParameters.SelectedIndex).Flags
        gphmCurrent.OptionalParameters = gphmParameters.Item(lstParameters.SelectedIndex).OptionalParameters
        gphmCurrent.Parameter = gphmParameters.Item(lstParameters.SelectedIndex).Parameter
        gphmCurrent.RecChannel = gphmParameters.Item(lstParameters.SelectedIndex).RecChannel
        gphmCurrent.Filter = gphmParameters.Item(lstParameters.SelectedIndex).Filter
        gphmCurrent.Flat = gphmParameters.Item(lstParameters.SelectedIndex).Flat
        gphmCurrent.Title = gphmParameters.Item(lstParameters.SelectedIndex).Title

        gphmCurrent.SetControls()

    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Dim szErr As String
        Dim szX As String = ""
        Dim szRecStream As String = ""

        With gphmCurrent
            szErr = gphmCurrent.GetParameters(szRecStream)
            If Len(szErr) > 0 Then GoTo SubError

            gblnCancel = False

            Select Case .Parameter
                Case 0 ' item #
                    szX = "FW_ShowStimulus(shiftdim(Obj.Data.IR(" & .Filter & "," & .RecChannel & ",:),2),stimPar,'" & gszSettingTitle & ": " & szRecStream & "'," & TStr(.Flags) & ",[" & .Axes & "],'item # ',meta.itemidx(" & .Filter & "),[" & .OptionalParameters & "]);"
                Case 1 ' azimuth
                    szX = "FW_ShowStimulus(shiftdim(Obj.Data.IR(" & .Filter & "," & .RecChannel & ",:),2),stimPar,'" & gszSettingTitle & ": " & szRecStream & "'," & TStr(.Flags) & ",[" & .Axes & "],'azimuth in °',meta.pos(" & .Filter & ",1),[" & .OptionalParameters & "]);"
                Case 2 ' elevation / channel ID
                    Select Case glExpType
                        Case 0, 1, 2
                            szX = "FW_ShowStimulus(shiftdim(Obj.Data.IR(" & .Filter & "," & .RecChannel & ",:),2),stimPar,'" & gszSettingTitle & ": " & szRecStream & "'," & TStr(.Flags) & ",[" & .Axes & "],'channel ID',meta.pos(" & .Filter & ",2),[" & .OptionalParameters & "]);"
                        Case 3
                            szX = "FW_ShowStimulus(shiftdim(Obj.Data.IR(" & .Filter & "," & .RecChannel & ",:),2),stimPar,'" & gszSettingTitle & ": " & szRecStream & "'," & TStr(.Flags) & ",[" & .Axes & "],'elevation in °',meta.pos(" & .Filter & ",2),[" & .OptionalParameters & "]);"
                    End Select                    
                Case 3 ' index
                    szX = "FW_ShowStimulus(shiftdim(Obj.Data.IR(" & .Filter & "," & .RecChannel & ",:),2),stimPar,'" & gszSettingTitle & ": " & szRecStream & "'," & TStr(.Flags) & ",[" & .Axes & "],'SOFA object index'," & .Filter & ",[" & .OptionalParameters & "]);"
                Case 4 ' continuous elevation
                    szX = "FW_ShowStimulus(shiftdim(Obj.Data.IR(" & .Filter & "," & .RecChannel & ",:),2),stimPar,'" & gszSettingTitle & ": " & szRecStream & "'," & TStr(.Flags) & ",[" & .Axes & "],'elevation in °',meta.pos(" & .Filter & ",5),[" & .OptionalParameters & "]);"
                Case 5 ' Lateral Angle
                    szX = "FW_ShowStimulus(shiftdim(Obj.Data.IR(" & .Filter & "," & .RecChannel & ",:),2),stimPar,'" & gszSettingTitle & ": " & szRecStream & "'," & TStr(.Flags) & ",[" & .Axes & "],'lateral angle in °',meta.pos(" & .Filter & ",6),[" & .OptionalParameters & "]);"
                Case 6 ' Polar Angle
                    szX = "FW_ShowStimulus(shiftdim(Obj.Data.IR(" & .Filter & "," & .RecChannel & ",:),2),stimPar,'" & gszSettingTitle & ": " & szRecStream & "'," & TStr(.Flags) & ",[" & .Axes & "],'polar angle in °',meta.pos(" & .Filter & ",7),[" & .OptionalParameters & "]);"
            End Select

            If ckbFlat.Checked And ckbFlat.Enabled Then szX = szX & "shading flat;"

            szErr = frmPostProcessing.MatlabCmd(szX)
            If Len(szErr) <> 0 Then GoTo SubError
           
            Exit Sub

SubError:
            MsgBox(szErr, MsgBoxStyle.Critical, "Plot Matrix SOFA object: Error")
            Exit Sub
        End With
    End Sub

    Private Sub cmdSaveParameters_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSaveParameters.Click
        Dim szX As String = ""
        Dim szErr As String

        szErr = gphmCurrent.GetParameters(szX)
        If Len(szErr) > 0 Then
            MsgBox(szErr, MsgBoxStyle.Critical, "Save Parameters")
            Exit Sub
        End If
        szX = InputBox("Input the title of this parameter set:", "Save parameters")
        If Len(szX) = 0 Then Exit Sub
        Dim phmX As New PlothMParameterSet
        phmX.Valid = True
        phmX.Axes = gphmCurrent.Axes
        phmX.Flags = gphmCurrent.Flags
        phmX.OptionalParameters = gphmCurrent.OptionalParameters
        phmX.Parameter = gphmCurrent.Parameter
        phmX.RecChannel = gphmCurrent.RecChannel
        phmX.Filter = gphmCurrent.Filter
        phmX.Flat = gphmCurrent.Flat
        phmX.Title = szX
        'phmX.
        gphmParameters.Add(phmX)
        SaveParameterSets("parametersetlist.csv")
        ShowParameterSets()
    End Sub

    Private Sub frmPlothM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'Private Sub frmExp_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = System.Windows.Forms.Keys.Escape Then Me.Close()
    End Sub

    Private Sub frmPlothM_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        gphmCurrent.SetControls()
        LoadParameterSets("parametersetlist.csv")
        ShowParameterSets()

        If grectfrmPlothM.Left <> 0 And grectfrmPlothM.Top <> 0 Then
            Me.Left = CInt(Val(VB6.TwipsToPixelsX(grectfrmPlothM.Left)))
            Me.Top = CInt(Val(VB6.TwipsToPixelsY(grectfrmPlothM.Top)))
        Else
            Me.Left = frmMain.Left
            Me.Top = frmMain.Top
        End If

    End Sub

    Private Sub frmPlothM_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        SaveParameterSets("parametersetlist.csv")
        grectfrmPlothM.Left = CInt(Val(VB6.PixelsToTwipsX(Me.Left)))
        grectfrmPlothM.Top = CInt(Val(VB6.PixelsToTwipsY(Me.Top)))
        eventArgs.Cancel = Cancel
    End Sub

    Private Sub lstParameters_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstParameters.DoubleClick
        If lstParameters.SelectedIndex < 0 Then Exit Sub
        gphmCurrent.Axes = gphmParameters.Item(lstParameters.SelectedIndex).Axes
        gphmCurrent.Flags = gphmParameters.Item(lstParameters.SelectedIndex).Flags
        gphmCurrent.OptionalParameters = gphmParameters.Item(lstParameters.SelectedIndex).OptionalParameters
        gphmCurrent.Parameter = gphmParameters.Item(lstParameters.SelectedIndex).Parameter
        gphmCurrent.RecChannel = gphmParameters.Item(lstParameters.SelectedIndex).RecChannel
        gphmCurrent.Filter = gphmParameters.Item(lstParameters.SelectedIndex).Filter
        gphmCurrent.Flat = gphmParameters.Item(lstParameters.SelectedIndex).Flat
        gphmCurrent.Title = gphmParameters.Item(lstParameters.SelectedIndex).Title
        gphmCurrent.SetControls()
    End Sub

    Private Sub optMatrixMode_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optMatrixMode.CheckedChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            If DirectCast(eventSender, RadioButton).Checked Then
                If (gphmCurrent.Flags And 128) = 0 Then
                    gphmCurrent.Flags = cmbShowStimDomain.SelectedIndex + cmbShowStimX.SelectedIndex * 2 + cmbShowStimY.SelectedIndex * 16 + CInt(optMatrixMode.Checked) * -128 + cmbMode.SelectedIndex * 256
                    gphmCurrent.GetParameters("")
                    gphmCurrent.SetControls()
                End If
                UpdateMatlabFlags()
            End If
        End If
    End Sub

    Private Sub optVectorMode_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optVectorMode.CheckedChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            If DirectCast(eventSender, RadioButton).Checked Then
                If (gphmCurrent.Flags And 128) = 128 Then
                    gphmCurrent.Flags = cmbShowStimDomain.SelectedIndex + cmbShowStimX.SelectedIndex * 2 + cmbShowStimY.SelectedIndex * 16 + CInt(optMatrixMode.Checked) * -128 + cmbMode.SelectedIndex * 256
                    gphmCurrent.GetParameters("")
                    gphmCurrent.SetControls()
                End If
                UpdateMatlabFlags()
            End If
        End If
    End Sub

    Private Sub UpdateMatlabFlags()
        lblMatlabFlags.Text = "Matlab Flags: " & TStr(cmbShowStimDomain.SelectedIndex + cmbShowStimX.SelectedIndex * 2 + cmbShowStimY.SelectedIndex * 16 + CInt(optMatrixMode.Checked) * -128 + cmbMode.SelectedIndex * 256)
        'gphmCurrent.Flags = CInt(optMatrixMode.Checked) * -128 + cmbMode.SelectedIndex * 256

        lblPlotAs.Text = TStr(CShort(CInt(optMatrixMode.Checked) * -128) + cmbMode.SelectedIndex * 256)
        lblDomain.Text = TStr(cmbShowStimDomain.SelectedIndex)
        lblScaleX.Text = TStr(cmbShowStimX.SelectedIndex * 2)
        lblScaleY.Text = TStr(cmbShowStimY.SelectedIndex * 16)
    End Sub

    Private Sub cmbShowStimX_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbShowStimX.SelectedIndexChanged
        UpdateMatlabFlags()
    End Sub

    Private Sub cmbShowStimY_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbShowStimY.SelectedIndexChanged
        UpdateMatlabFlags()
    End Sub

    Private Sub cmdResetParameterSets_Click(sender As Object, e As EventArgs) Handles cmdResetParameterSets.Click
        If MsgBox("Do you really want to reset parameter set list do default? All your saved parameter sets will be lost!" & vbCrLf & vbCrLf & _
                  "(This might make sense if new parameteter sets have been added to default list, since your installation of ATMatARI.)", _
                  MsgBoxStyle.Question Or MsgBoxStyle.YesNo,"Reset Parameter Set List") = vbYes Then

            LoadParameterSets("parametersetlist.csv",True)
            ShowParameterSets()

        End If
    End Sub

    Private Sub cmdExportParameterSets_Click(sender As Object, e As EventArgs) Handles cmdExportParameterSets.Click
        SaveParameterSets("~parametersetlist.csv",WorkDir)
    End Sub
End Class