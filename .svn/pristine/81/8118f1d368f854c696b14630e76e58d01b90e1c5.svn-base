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
' input box template, application programmer can use that box for any inputs being done by an experimentator
''' <summary>
''' FrameWork Module - Programmable Input Box Form
''' </summary>
''' <remarks></remarks>
Friend Class frmInputBox
    Inherits System.Windows.Forms.Form

   

    Private constData() As ExpConstant
    Private mblnCancel As Boolean
    Private mlLeft, mlTop As Integer

   ''' <summary>
    ''' Get the value of an item.
    ''' </summary>
    ''' <param name="Index">Index of the item.</param>
    ''' <value></value>
    ''' <returns>Value of the item with index Index.</returns>
    ''' <remarks>How to use frmInputBox: <example><code lang="VB">
    '''  Dim inpX As New frmInputBox, szX As String, lX As Long
    '''
    '''    inpX.Add "const 1", ifNumeric + ifMin, "123", "us", -10
    '''    inpX.Add "const 2", ifString, "asdas", "text"
    '''    inpX.Add "const 3", ifFileName, "C:/asdads", "*.wav"
    '''    If Not inpX.ShowForm("Caption of the input box") Then Set inpX = Nothing: Exit Sub
    '''    szX = ""
    '''    For lX = 0 To inpX.GetCount - 1
    '''      szX = szX + inpX.GetValue(lX) + vbCrLf
    '''    Next
    '''    MsgBox szX
    '''   Set inpX = Nothing
    '''</code> </example> </remarks>
    Public ReadOnly Property GetValue(ByVal Index As Integer) As String
        Get
            If Index >= constData.Length Then Err.Raise(vbObjectError, "InputBox: GetValue", "Index out of bounds.")
            Return constData(Index).varValue
        End Get
    End Property

    Public WriteOnly Property SetLeft() As Integer
        Set(ByVal Value As Integer)
            mlLeft = Value
        End Set
    End Property

    Public WriteOnly Property SetTop() As Integer
        Set(ByVal Value As Integer)
            mlTop = Value
        End Set
    End Property


   ''' <summary>
    ''' Get the count of items in the form.
    ''' </summary>
    ''' <returns>Count of items in the form. Zero if there are no valid items.</returns>
    ''' <remarks></remarks>
    Public Function GetCount() As Integer

        If IsNothing(constData) Then Return 0
        Return constData.Length

    End Function

   ''' <summary>
    ''' Show the input box form.
    ''' </summary>
    ''' <param name="Caption">Caption of the form.</param>
    ''' <returns>TRUE if the data are valid, FALSE if cancel or close was clicked. The data are not valid in the latter case.</returns>
    ''' <remarks></remarks>
    Public Function ShowForm(ByVal Caption As String) As Boolean
        Dim lX As Short
        Dim lY As Integer

        Me.Text = Caption
        If Not IsNothing(constData) Then
            For lX = 0 To CShort(constData.Length - 1)
                If lX <> 0 Then
                    lblConstName.Load(lX)
                    lblConstUnit.Load(lX)
                    txtConstValue.Load(lX)
                    cmdConstCmd.Load(lX)
                End If
                ' set positions and appearance
                With lblConstName(lX)
                    .Visible = True
                    .Top = lblConstName(0).Top + CInt(Math.Round(1.2 * CDbl(txtConstValue(0).Height * lX)))
                    .Left = lblConstName(0).Left
                End With
                With txtConstValue(lX)
                    .Visible = True
                    .Top = txtConstValue(0).Top + CInt(Math.Round(1.2 * CDbl(txtConstValue(0).Height * lX)))
                    .Left = txtConstValue(0).Left
                    .TabIndex = lX
                End With
                With cmdConstCmd(lX)
                    .Visible = True
                    .Top = cmdConstCmd(0).Top + CInt(Math.Round(1.2 * CDbl(txtConstValue(0).Height * lX)))
                    .Left = cmdConstCmd(0).Left
                End With
                With lblConstUnit(lX)
                    .Visible = True
                    .Top = lblConstName(0).Top + CInt(Math.Round(1.2 * CDbl(txtConstValue(0).Height * lX)))
                    If (constData(lX).Flags And 15) = FWintern.VariableFlags.vfFileName Then
                        .Left = cmdConstCmd(lX).Left + cmdConstCmd(lX).Width + 6
                    Else
                        .Left = txtConstValue(lX).Left + txtConstValue(lX).Width + 6
                    End If
                End With
                If (constData(lX).Flags And 15) <> FWintern.VariableFlags.vfFileName Then cmdConstCmd(lX).Visible = False

                ' set contents
                With constData(lX)
                    If Len(.szName) = 0 Then
                        lblConstName(lX).Text = .szDescription & ":"
                    Else
                        lblConstName(lX).Text = .szName & ":"
                        ToolTip1.SetToolTip(lblConstName(lX), .szDescription)
                        ToolTip1.SetToolTip(txtConstValue(lX), .szDescription)
                    End If
                    lblConstUnit(lX).Text = .szUnit
                    If IsNothing(.varValue) Then
                        txtConstValue(lX).Text = .varDefault
                    Else
                        txtConstValue(lX).Text = .varValue
                    End If
                    If (CInt(.Flags = 15) = FWintern.VariableFlags.vfFileName) And ((.Flags And &H70S) = FWintern.VariableFlags.vfAbsolute) Then
                        lY = InStrRev(txtConstValue(lX).Text, "\")
                        If lY > 0 Then lblConstUnit(lX).Text = "..." & Mid(txtConstValue(lX).Text, lY)
                    End If
                    If CBool(.Flags And FWintern.VariableFlags.vfHidden) Then
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
                    End If
                End With
            Next


            lY = txtConstValue(CShort(constData.Length - 1)).Top + txtConstValue(CShort(constData.Length - 1)).Height + 16
            cmdOK.Top = lY
            cmdCancel.Top = lY
            Me.Height = lY + cmdOK.Height + 40
        End If
        If mlLeft <> 0 Or mlTop <> 0 Then
            Me.Left = mlLeft
            Me.Top = mlTop
        Else
            Me.Left = frmMain.Left + 100
            Me.Top = frmMain.Top + 200
        End If

        mblnCancel = True
        Me.ShowDialog()
        ShowForm = Not mblnCancel

    End Function

   ''' <summary>
    ''' Check a value against its restrictions.
    ''' </summary>
    ''' <param name="szX">Parameter_Description</param>
    ''' <param name="szName">Parameter_Description</param>
    ''' <param name="Flags">Parameter_Description</param>
    ''' <param name="szUnit">Parameter_Description</param>
    ''' <param name="dMin">Parameter_Description</param>
    ''' <param name="dMax">Parameter_Description</param>
    ''' <returns>Error message.</returns>
    ''' <remarks></remarks>
    Private Function CheckValue(ByVal szX As String, ByVal szName As String, _
                                ByVal Flags As FWintern.VariableFlags, ByVal szUnit As String, _
                                ByVal dMin As Double, ByVal dMax As Double) As String
        Dim lY, lZ As Integer
        Dim szErr As String
        Dim szChar As String = ""
        Dim szArr() As String
        Dim szT, szNew As String

        szErr = ""

        Select Case (Flags And 15)
            Case FWintern.VariableFlags.vfNumeric ' numeric values
                If CBool(Flags And FWintern.VariableFlags.vfVectorized) Then
                    If InStr(1, szX, " ") > 0 Then szChar = " "
                    If InStr(1, szX, ";") > 0 Then szChar = ";"
                    If Len(szChar) > 0 Then
                        ' vector found
                        szArr = Split(szX, szChar)
                        szNew = ""
                        For lZ = 0 To GetUbound(szArr)
                            szT = szArr(lZ)
                            If Len(szT) > 0 Then
                                szErr &= CheckNumeric(szT, szName, Flags, dMin, dMax)
                                If Len(szErr) = 0 Then szNew = szNew + szChar + szT
                            End If
                        Next
                        If Len(szNew) > 0 Then szX = Mid(szNew, 2)
                    Else
                        ' scalar found
                        szErr = CheckNumeric(szX, szName, Flags, dMin, dMax)
                    End If
                Else ' not vectorized
                    szErr = CheckNumeric(szX, szName, Flags, dMin, dMax)
                End If ' vectorized?
            Case FWintern.VariableFlags.vfFileName ' file name
            Case FWintern.VariableFlags.vfDirectory ' directory
            Case FWintern.VariableFlags.vfString ' string
                If (Flags And FWintern.VariableFlags.vfNonEmpty) > 0 And Len(szX) = 0 Then szErr = szErr & szName & " must not be empty." & vbCrLf
                If CBool(Flags And FWintern.VariableFlags.vfEnumeration) Then
                    If CBool(Flags And FWintern.VariableFlags.vfCaseSensitive) Then
                        szArr = Split(szUnit, ";")
                        For lY = 0 To UBound(szArr)
                            If szX = szArr(lY) Then Exit For
                        Next
                        If lY > UBound(szArr) Then szErr = szErr & "Allowed values (case sensitive!): " & szUnit & vbCrLf
                    Else
                        szArr = Split(szUnit, ";")
                        For lY = 0 To UBound(szArr)
                            If LCase(szX) = LCase(szArr(lY)) Then Exit For
                        Next
                        If lY > UBound(szArr) Then szErr = szErr & "Allowed values: " & szUnit & vbCrLf
                    End If
                End If
                If CBool(Flags And FWintern.VariableFlags.vfUpperCase) Then szX = UCase(szX)
                If CBool(Flags And FWintern.VariableFlags.vfLowerCase) Then szX = LCase(szX)
        End Select

        Return szErr

    End Function

    Private Function CheckNumeric(ByVal szX As String, ByVal szName As String, _
                                    ByVal Flags As FWintern.VariableFlags, _
                                    ByVal dMin As Double, ByVal dMax As Double) As String
        Dim szErr As String = ""

        If Not IsNumeric(szX) Then Return szName & " must be numeric." & vbCrLf

        Dim X As Double = Val(szX)
        If CBool(Flags And FWintern.VariableFlags.vfInteger) Then X = Math.Round(X)
        If (Flags And FWintern.VariableFlags.vfNonZero) > 0 And (X = 0) Then szErr = szErr & szName & ": equal 0 not allowed." & vbCrLf
        If (Flags And FWintern.VariableFlags.vfMin) > 0 And (X < dMin) Then szErr = szErr & szName & ": below " & TStr(dMin) & " not allowed." & vbCrLf
        If (Flags And FWintern.VariableFlags.vfMax) > 0 And (X > dMax) Then szErr = szErr & szName & ": values greater than " & TStr(dMax) & " not allowed." & vbCrLf
        If CBool(Flags And FWintern.VariableFlags.vfMinTimeDelay) Then
            X = Math.Round(X)
            If X < 0 Then szErr = szErr & szName & " must be a positive time delay" & vbCrLf
        End If

        Return szErr

    End Function


   ''' <summary>
    ''' Add an input item to the form
    ''' <br>Add input items before showing the form via ShowForm.</br>
    ''' </summary>
    ''' <param name="Title">Title of the item.</param>
    ''' <param name="Flags">Flags for the item, see VariableFlags for the possible values. ElectrodeR/L are not supported.</param>
    ''' <param name="Defaul">Default value (String) showed at the begin in the input box.</param>
    ''' <param name="Units">Units of the item, it will be shown at the right of the input box.</param>
    ''' <param name="Min">Minimum value for numerical values.</param>
    ''' <param name="Max">Maximum value for numerical values.</param>
    ''' <remarks></remarks>
    Public Sub Add(ByVal Title As String, ByVal Flags As FWintern.VariableFlags, _
                    ByVal Defaul As String, ByVal Units As String, _
                    Optional ByVal Min As Double = 0, Optional ByVal Max As Double = 0)

        If (Flags And FWintern.VariableFlags.vfFlagTypeMask) = FWintern.VariableFlags.vfElectrodeR Then _
            Err.Raise(vbObjectError, "InputBox: Add", "Flag ElectrodeR not supported.")
        If (Flags And FWintern.VariableFlags.vfFlagTypeMask) = FWintern.VariableFlags.vfElectrodeL Then _
            Err.Raise(vbObjectError, "InputBox: Add", "Flag ElectrodeL not supported.")

        If IsNothing(constData) Then ReDim constData(0) Else ReDim Preserve constData(constData.Length)
        With constData(constData.Length - 1)
            .szName = Title
            .Flags = Flags
            .varDefault = Defaul
            .szUnit = Units
            .dMin = Min
            .dMax = Max
        End With
    End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        mblnCancel = True
        Me.Hide()
    End Sub

    Private Sub cmdConstCmd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdConstCmd.Click
        Dim Index As Short = cmdConstCmd.GetIndex(DirectCast(eventSender, Button))
        Dim szDir As String = ""
        Dim lX As Integer

        If (constData(Index).Flags And 15) = FWintern.VariableFlags.vfFileName Then
            If (constData(Index).Flags And &H70S) = FWintern.VariableFlags.vfAbsolute Then
                ' get file name
                lX = InStrRev(txtConstValue(Index).Text, "\")
                If lX > 0 Then
                    szDir = Mid(txtConstValue(Index).Text, 1, lX)
                    ChangeDir(szDir)
                    '      Else
                    '        szDir = gszCurrentDir
                End If
            Else
                szDir = DataDirectory.Path(CShort((CInt(constData(Index).Flags) \ 16) And 7) - 1)
                ChangeDir(szDir)
            End If

            Dim dlgOpen As New OpenFileDialog With { _
                .InitialDirectory = szDir, _
                .FileName = "", _
                .Title = "Browse for a file...", _
                .CheckFileExists = True, _
                .CheckPathExists = True _
            }
            If Len(constData(Index).szUnit) > 0 Then
                dlgOpen.Filter = "Specific Files (" & constData(Index).szUnit & ")|" & constData(Index).szUnit & "|All Files (*.*)|*.*"
            Else
                dlgOpen.Filter = "All Files (*.*)|*.*"
            End If
            dlgOpen.FilterIndex = 1
            If dlgOpen.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
            If (constData(Index).Flags And &H70S) = FWintern.VariableFlags.vfAbsolute Then
                txtConstValue(Index).Text = dlgOpen.FileName
                lblConstUnit(Index).Text = "...\" & (New System.IO.FileInfo(dlgOpen.FileName)).Name
            Else
                txtConstValue(Index).Text = (New System.IO.FileInfo(dlgOpen.FileName)).Name
                lblConstUnit(Index).Text = ""
            End If
        End If

    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Dim szErr As String = ""
        Dim lIdx As Short

        ' check data
        If Not IsNothing(constData) Then
            For lIdx = 0 To CShort(constData.Length - 1)
                With constData(lIdx)
                    szErr &= CheckConstant(txtConstValue(lIdx).Text, constData(lIdx), gfreqParL, gfreqParR)
                End With
            Next
        End If

        If Len(szErr) > 0 Then
            MsgBox(szErr, MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End If

        ' save data
        If Not IsNothing(constData) Then
            For lIdx = 0 To CShort(constData.Length - 1)
                With constData(lIdx)
                    If ((.Flags And 15) = FWintern.VariableFlags.vfNumeric) And ((.Flags And FWintern.VariableFlags.vfVectorized) = 0) Then
                        .varValue = txtConstValue(lIdx).Text
                    Else
                        .varValue = txtConstValue(lIdx).Text
                    End If
                End With
            Next
        End If

        mblnCancel = False
        Me.Hide()

    End Sub

    Private Sub frmInputBox_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmMain.Icon
    End Sub

    Private Sub frmInputBox_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        'mblnCancel = True
        eventArgs.Cancel = Cancel
    End Sub
End Class