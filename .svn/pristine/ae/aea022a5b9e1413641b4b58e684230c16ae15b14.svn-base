Option Strict On
Option Explicit On
Imports System.ComponentModel
#Region "ExpSuite License"
'ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
'Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
'Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
'You may not use this work except in compliance with the Licence. 
'You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
'Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
'See the Licence for the specific language governing  permissions and limitations under the Licence. 
#End Region


Public Class frmMESM
    Private letaMax As Integer    
    Private            letaMin As Integer  
    Private      lK As Integer     
    Private        ll1 As Integer 
    Private        ll2 As Integer 
    Private        ln As Integer 
    Private        lfMin As Integer 
    Private        lfMax As Integer 
    Private        lTmin As Integer 

    Private Sub btnCalcMesm_Click(sender As Object, e As EventArgs) Handles btnCalcMesm.Click
        dim szErr As String= Nothing
        Dim dblTnew(0, 0) As Double
        Dim dblTtot(0, 0) As Double

        ' CHECKS
        If etaMax.Value < etaMin.Value Then
            szErr="Eta max must not be smaller than eta min." : GoTo SubError
        End If

        ' PREPARE DGV
        dgvMesm.Rows.Clear()
        dgvMesm.Visible=False
     
        dgvMesm.ColumnCount = 3
        dgvMesm.Columns(0).Name = "eta"
        dgvMesm.Columns(1).Name = "T tot [ms]"
        dgvMesm.Columns(2).Name = "T min [ms]"

        dgvMesm.Columns(0).ValueType = GetType(Integer) 'for sorting
        dgvMesm.Columns(1).ValueType = GetType(Integer)
        dgvMesm.Columns(2).ValueType = GetType(Integer)

        'dgvMesm.Columns(0).SortMode=NumericUpDown

        lblUnoptimized.Text="Unoptimized T tot: " & (String.Format("{0:0,0}", Val( N.Value * (Tmin.Value + L1.Value)))) & " ms"

        For eta As Integer = CInt( etaMin.Value) To cint(etamax.Value)


        ' MESM calculation in MATLAB
            szErr = STIM.Matlab("[Tnewcorr,Ttot,ti,ISD]=AA_MESM(" & TStr(eta) & "," & TStr(k.Value) & "," & TStr(L1.Value) & "," & TStr(L2.Value) & "," & TStr(N.Value) & "," & TStr(fMin.Value) & "," & TStr(fMax.Value) & "," & TStr(Tmin.Value) & ");")      
            
            If Len(szErr) > 0 Then GoTo SubError

            szErr = STIM.MatlabGetRealMatrix2("Ttot", dblTtot) ' new
            If Len(szErr) > 0 Then GoTo SubError
            ' Tnew = PlayLength
            szErr = STIM.MatlabGetRealMatrix2("Tnewcorr", dblTnew)
            If Len(szErr) > 0 Then GoTo SubError
            dgvMesm.Rows.Add(eta, Math.Round(dblTtot(0, 0)),Math.Round(dblTnew(0, 0)))

        Next
        
        dgvMesm.Sort(dgvMesm.Columns(1), ListSortDirection.Ascending)
        dgvMesm.Visible=True

        Exit Sub

SubError:
        MsgBox(szErr, MsgBoxStyle.Critical, "Calculate MESM parameters")


    End Sub

    Private Sub frmMESM_Load(sender As Object, e As EventArgs) Handles Me.Load
        If letaMax = Nothing then
            'default
            etaMin.Value=4
            etaMax.Value=8
            K.Value= 2
            l1.Value= 38
            l2.Value= 3
            n.Value= 91
            fMin.Value= 20
            fMax.Value= 20000
            Tmin.Value= 1500
        Else
            'restore
            etaMin.Value=letaMin
            etaMax.Value=letaMax
            k.Value=lk
            l1.Value= ll1
            l2.Value= ll2
            n.Value= ln
            fMin.Value= lfMin
            fMax.Value= lfMax
            Tmin.Value= lTmin
        End If

        lblUnoptimized.Text=""
        dgvMesm.AlternatingRowsDefaultCellStyle=frmMain.dgvItemList.AlternatingRowsDefaultCellStyle
        btnCalcMesm.Select
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close
    End Sub

 

    Private Sub frmMESM_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'store
        letaMin=CInt(etaMin.Value)
        letaMax=CInt(etaMax.Value)
        lK=CInt(K.Value)
        lk=CInt(k.Value)
        ll1=CInt(l1.Value)
        ll2=CInt(l2.Value)
        ln=CInt(n.Value)
        lfMin=CInt(fMin.Value)
        lfMax=CInt( fMax.Value)
        lTmin=CInt(Tmin.Value)
    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        Dim szErr As String
        Dim dblTnew(0, 0) As Double
        Dim dblTtot(0, 0) As Double
        Dim dblISD(,) As Double
        Dim lTtot As Integer
        Dim lRow, lCol As Integer
        Dim lX As Integer

        Dim lNewEta As Integer=cint(dgvMesm.Item(0,dgvMesm.CurrentRow.Index).Value)

        ' MESM calculation in MATLAB
        szErr = STIM.Matlab("[Tnewcorr,Ttot,ti,ISD]=AA_MESM(" & TStr(lNewEta) & "," & TStr(k.Value) & "," & TStr(L1.Value) & "," & TStr(L2.Value) & "," & TStr(N.Value) & "," & TStr(fMin.Value) & "," & TStr(fMax.Value) & "," & TStr(Tmin.Value) & ");")      
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
        If (MsgBox("Selected eta value: " & tstr(lNewEta)  & vbCrLf  & vbCrLf & "Unoptimized Parameters: " & vbCrLf & vbCrLf & vbTab & "Ttot = " & TStr(lTtot) & vbCrLf & vbTab & "Tmin = " & TStr(lTmin) & vbCrLf & vbCrLf & "MESM Parameters: " & vbCrLf & vbCrLf & vbTab & "Ttot = " & TStr(dblTtot(0, 0)) & vbCrLf & vbTab & "Tmin = " & TStr(dblTnew(0, 0)) & vbCrLf & vbCrLf & "Do you want to continue with calculated MESM parameters?", MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1, "MESM")) = MsgBoxResult.No Then
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
        MsgBox(szErr, MsgBoxStyle.Critical, "Calculate MESM parameters")
        frmMain.SetStatus("Error(s) calculating MESM parameters")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        dgvMesm.Rows.Clear()
    End Sub
End Class