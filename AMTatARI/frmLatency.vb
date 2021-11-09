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
Friend Class frmLatency
	Inherits System.Windows.Forms.Form
	Dim mlRec As Integer
    Dim msngLat() As Double
    Dim mblnLat() As Boolean


    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Dim lX As Integer
        Dim szErr As String

        If mblnLat.Length <= 0 Then szErr = "No channels defined." : GoTo SubError
        For lX = 0 To UBound(mblnLat)
            If optConst.Checked Then
                ' set to constant value
                If Len(txtConst.Text) = 0 Or Not IsNumeric((txtConst.Text)) Then szErr = "Set latency to a valid numeric value." : GoTo SubError
                gfreqParL(lX).lPhDur = CInt(Val((txtConst.Text)) * 1000)
            Else
                ' set to the list
                If CBool(mblnLat(lX)) Then
                    If Len(txtOffset.Text) <> 0 Then
                        If Not IsNumeric((txtOffset.Text)) Then szErr = "Set offset to a valid numeric value." : GoTo SubError
                        gfreqParL(lX).lPhDur = CInt(Val((msngLat(lX) + Val((txtOffset.Text))) * 1000))
                    Else
                        gfreqParL(lX).lPhDur = CInt(Val(msngLat(lX) * 1000))
                    End If
                End If
            End If
        Next
        gblnSettingsChanged = True
        Me.Close()
        Exit Sub


SubError:
        MsgBox(szErr, MsgBoxStyle.Critical, "Copy Latency")
        Exit Sub
    End Sub

    Private Sub frmLatency_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim szX As String
        Dim szErr As String
        Dim lRows, lX, lCh As Integer
        Dim dblLat(,) As Double
        Dim dblPos(,) As Double
        Dim sngX As Double

        ' get number of channels
        If GetUbound(gfreqParL) < 0 Then szErr = "No signals defined in settings." : GoTo SubError
        ReDim msngLat(UBound(gfreqParL))
        ReDim mblnLat(UBound(gfreqParL))

        ' get record stream
        szX = InputBox("Input the index of the record stream: ", "Show Latency", "1")
        mlRec = CInt(Val(szX) - 1)
        If Len(szX) = 0 Or mlRec < 0 Then tmrUnload.Enabled = True : Exit Sub
        If mlRec > GetUbound(gRecStream) Then szErr = "Record stream not found." : GoTo SubError


        ' get size of latLIN{}
        szX = STIM.MatlabGetMatrixSize("latLIN", lRows, lX)
        If Len(szX) > 0 Then szErr = "Get Size of latLIN: " & szX : GoTo SubError
        If lRows < 1 And lX < 1 Then
            szErr = "Latency matrix latLIN is empty." : GoTo SubError
        End If

        ' get latLIN;
        ReDim dblLat(lRows - 1, lX - 1)
        szX = STIM.MatlabGetRealMatrix2("latLIN", dblLat)
        If Len(szX) <> 0 Then szErr = "Get latLIN Matrix: " & szX : GoTo SubError

        ' get size of posLIN{}
        szX = STIM.MatlabGetMatrixSize("posLIN", lRows, lX)
        If Len(szX) > 0 Then szErr = "Get Size of posLIN: " & szX : GoTo SubError
        If lRows < 1 And lX < 1 Then
            szErr = "Position matrix posLIN is empty." : GoTo SubError
        End If

        ' get posLIN;
        ReDim dblPos(lRows - 1, lX - 1)
        szX = STIM.MatlabGetRealMatrix2("posLIN", dblPos)
        If Len(szX) <> 0 Then szErr = "Get posLIN Matrix: " & szX : GoTo SubError

        ' parse all channels
        szErr = ""
        For lX = 0 To UBound(dblLat, 1)
            lCh = GetChannelFromElevation(Val(dblPos(lX, 1)))
            If lCh < 1 Then
                szErr = szErr & "Row #" & TStr(lX) & ": Elevation '" & TStr(dblPos(lX, 2)) & "' not specified." & vbCrLf
            ElseIf lCh <> dblPos(lX, 2) Then
                szErr = szErr & "Row #" & TStr(lX) & ": Different channels for elevation " & TStr(dblPos(lX, 1)) & " in posLIN (#" & TStr(dblPos(lX, 2)) & ") and settings (#" & TStr(lCh) & ")." & vbCrLf
            Else
                msngLat(lCh - 1) = (dblLat(lX, mlRec) / glSamplingRate * 1000) + (gfreqParL(lCh - 1).lPhDur / 1000)
                mblnLat(lCh - 1) = True
            End If
        Next
        If Len(szErr) > 0 Then GoTo SubError

NoLatency:
        lstLin.Items.Clear()
        sngX = 10000000000.0#
        For lX = 0 To GetUbound(msngLat)
            If CBool(mblnLat(lX)) Then
                lstLin.Items.Add("#" & TStr(lX + 1) & ": " & TStr(System.Math.Round(msngLat(lX), 3)) & " ms")
                If msngLat(lX) < sngX Then sngX = msngLat(lX)
            Else
                lstLin.Items.Add("#" & TStr(lX + 1) & ": not found")
            End If
        Next
        If sngX <> 10000000000.0# Then txtConst.Text = TStr(System.Math.Round(sngX, 3))
        txtOffset.Text = TStr((-1) * gsIRBeg) 'Default Offset = Constants: "Begin Offset of IR"
        optLin.Checked = True
        Me.Left = frmMain.Left + 150
        Me.Top = frmMain.Top + 50
        Exit Sub

SubError:
        MsgBox(szErr, MsgBoxStyle.Critical, "Copy Latency")
        'tmrUnload.Enabled = True
        GoTo NoLatency
        Exit Sub
    End Sub
	
	Private Sub tmrUnload_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrUnload.Tick
		Me.Close()
	End Sub
End Class