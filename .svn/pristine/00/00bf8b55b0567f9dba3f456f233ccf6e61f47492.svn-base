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
''' <summary>
''' FrameWork - CSV files support.
''' </summary>
''' <remarks></remarks>
Friend Class CSVParser
   


    Private mszSeparator As String 'local copy
    Private mszQuota As String 'local copy

   

   ''' <summary>
    ''' Set content quota character.
    ''' Content will be quoted wiht this character if it contains a separator charachter.
    ''' </summary>
    ''' <value></value>
    ''' <returns>Quota character</returns>
    ''' <remarks></remarks>
    Public Property Quota() As String
        Get
            Quota = mszQuota
        End Get
        Set(ByVal Value As String)
            mszQuota = Value
        End Set
    End Property

   

   ''' <summary>
    ''' Get the separator between the values.
    ''' </summary>
    ''' <value></value>
    ''' <returns>Separator character</returns>
    ''' <remarks></remarks>
    Public Property Separator() As String
        Get
            Separator = mszSeparator
        End Get
        Set(ByVal Value As String)
            mszSeparator = Value
        End Set
    End Property


   ''' <summary>
    ''' Unquote a single cell - remove quotas
    ''' </summary>
    ''' <param name="szCell">Content of a single cell.</param>
    ''' <returns>Unquoted value.</returns>
    ''' <remarks></remarks>
    Public Function UnquoteCell(ByVal szCell As String) As String

        Select Case Len(szCell)
            Case 0
                Return ""
            Case 1
                Return szCell
            Case Else
                If Mid(szCell, 1, 1) = mszQuota And Mid(szCell, Len(szCell), 1) = mszQuota Then
                    ' cell quoted - remove
                    Return Mid(szCell, 2, Len(szCell) - 2)
                Else
                    ' cell unquoted - don't change
                    Return szCell
                End If
        End Select

    End Function
   ''' <summary>
    ''' Parse content of a string to a 2D-string array.
    ''' </summary>
    ''' <param name="szSource">Row in CSV format.</param>
    ''' <param name="szArr">Array with values retrieved from szSource.</param>
    ''' <param name="pbStatus">Progressbar to show the progress of parsing. Optional.</param>
    ''' <returns>Error message, empty if no error ocured.</returns>
    ''' <remarks>A string of a CSV file will be parsed and all found values well be copied to szArr().<br>
    ''' Rules (if " is Quota and , is Separator):    </br>
    ''' <li> " : mszQuota </li>
    '''<li> , : Separator </li>
    '''<li> row : cell,cell,cell </li>
    '''<li> not quoted cells: </li>
    '''<li>   ab,cd -> two cells: ab and cd </li>
    '''<li>   ab"cd -> ab"cd </li>
    '''<li>   ab""cd -> ab""cd </li>
    '''<li>   ab" -> ab" </li>
    '''<li>   ab"" -> ab"" </li>
    '''<li> quoted cells: </li>
    '''<li>   "ab" -> ab </li>
    '''<li>   "ab,cd" -> ab,cd </li>
    '''<li>   "ab"cd -> ab and ignore cd </li>
    '''<li>   "ab"de" -> ab and ignore cd </li>
    '''<li>   ""abcd -> empty cell and ignore abcd </li>
    '''<li>   "ab""cd" -> ab"cd </li>
    '''<li>   "ab"",cd" -> ab"cd </li>
    '''<li>   """abcd" -> "abcd </li>
    '''<li> last quoted cell in a row: </li>
    '''<li>   "abEOL -> ab </li>
    '''<li>   "ab"EOL -> ab </li>
    '''<li>   "ab""EOL -> ab" </li>
    '''<li>   "ab"""EOL -> ab" </li>
    '''<li>   "ab""cdEOL -> ab"cd </li>
    '''<li> Empty row -> one empty cell </li>
    ''' </remarks>
    Public Function ParseString(ByVal szSource As String, ByRef szArr(,) As String, Optional ByVal pbStatus As System.Windows.Forms.ProgressBar = Nothing) As String
        Dim szRow As String
        Dim lX, lY As Integer
        Dim lCols, lRows As Integer
        Dim lRowBeg, lRowEnd As Integer

        On Error GoTo SystemErr

        ' check if empty
        If Len(szSource) = 0 Then
            ParseString = "String is empty."
            GoTo SubErr
        End If

        ' count # of rows
        If InStr(1, szSource, vbCr) = 0 Then
            lRows = 1
            szSource = szSource & vbCr
        Else
            lRows = 0
            lRowBeg = 1
            Do
                lRowEnd = InStr(lRowBeg, szSource, vbCr)
                If lRowEnd > 0 Then
                    lRows = lRows + 1
                    lRowBeg = lRowEnd + 2
                End If
            Loop Until lRowEnd = 0
        End If

        Dim szCell As String
        Dim lBeg, lEnd As Integer
        Dim blnQuota, blnFirstChar As Boolean
        Dim lCol, lRow As Integer

        lRow = 0
        lRowBeg = 1
        Do  ' for each row
            lRowEnd = InStr(lRowBeg, szSource, vbCr)
            If lRowEnd = 0 Then
                szRow = Mid(szSource, lRowBeg, Len(szSource))
                lRowBeg = Len(szSource) + 1
            Else
                szRow = Mid(szSource, lRowBeg, lRowEnd)
                lRowBeg = lRowEnd + 2
                If lRowBeg > Len(szSource) Then lRowEnd = 0
            End If
            If Len(szRow) > 0 Then
                ' parse the row
                lCol = 1
                lBeg = 1
                blnQuota = False
                For lEnd = 1 To Len(szRow)
                    Select Case Mid(szRow, lEnd, 1)

                        Case mszSeparator
                            If Not blnQuota Then
                                ' not quoted -> new cell found as is
                                If lCol > lCols Then ReDim Preserve szArr(lRows - 1, lCol - 1) : lCols = lCol
                                If lEnd > lBeg Then
                                    szCell = Mid(szRow, lBeg, lEnd - lBeg) ' cell is ok
                                Else
                                    szCell = "" ' cell is empty
                                End If
                                szArr(lRow, lCol - 1) = szCell
                                lCol = lCol + 1
                                lBeg = lEnd + 1
                            Else
                                ' quoted -> ignore separator and go on
                            End If

                        Case vbCr ' EOL
                            If blnQuota Then
                                ' quoted -> remove quotes
                                szCell = Mid(szRow, lBeg + 1, lEnd - lBeg - 1) ' without first quota
                                If Right(szCell, 1) = mszQuota Then szCell = Mid(szCell, 1, Len(szCell) - 1) ' last char was a quota -> remove
                                szCell = Replace(szCell, mszQuota & mszQuota, mszQuota) ' replace double quotas
                            Else
                                ' not quoted -> get the cell as is
                                If lEnd > lBeg Then
                                    szCell = Mid(szRow, lBeg, lEnd - lBeg) ' cell is ok
                                Else
                                    Exit For ' cell is empty -> don't insert!
                                End If
                            End If
                            ' save the cell
                            If lCol > lCols Then ReDim Preserve szArr(lRows - 1, lCol - 1) : lCols = lCol
                            szArr(lRow, lCol - 1) = szCell
                            lCol = lCol + 1
                            lBeg = lEnd + 1

                        Case mszQuota
                            If lBeg = lEnd Then
                                blnQuota = True ' first char in the cell, so we are quoted now!
                            ElseIf blnQuota Then
                                ' we were quoted and we've found next quota now
                                If Mid(szRow, lEnd + 1, 1) = vbCr Then
                                    ' quota is the last char, ignore it, parsing will be stopped automatically
                                ElseIf Mid(szRow, lEnd + 1, 1) = mszQuota Then
                                    lEnd = lEnd + 1 ' double quota found -> ignore and keep parsing
                                Else
                                    ' single quota found -> save the cell
                                    If lCol > lCols Then ReDim Preserve szArr(lRows - 1, lCol - 1) : lCols = lCol
                                    szCell = Mid(szRow, lBeg + 1, lEnd - lBeg - 1) ' without first quota
                                    szArr(lRow, lCol - 1) = Replace(szCell, mszQuota & mszQuota, mszQuota) ' replace double quotas
                                    lCol = lCol + 1
                                    ' set begin to the next separator or EOL
                                    lBeg = InStr(lEnd + 1, szRow, mszSeparator)
                                    If lBeg = 0 Then Exit For ' separator not found -> next row
                                    lBeg = lBeg + 1
                                    lEnd = lBeg - 1
                                    blnQuota = False ' we're leaving quoting now...
                                End If
                            Else
                                ' we've found quota somewhere in the middle but we are not quoted -> ignore
                            End If
                    End Select
                Next
                ' next row
                lRow = lRow + 1
                If Not (pbStatus Is Nothing) Then pbStatus.Value = CInt(100 * lRow / lRows)
            End If
        Loop Until lRowEnd = 0

        ' close the file
        On Error GoTo 0
        ParseString = ""
        Exit Function

SystemErr:
        ParseString = "System Error: " & Err.Description
        On Error GoTo 0
        Exit Function

SubErr:
        On Error GoTo 0
        Exit Function

    End Function


   ''' <summary>
    ''' Read content of a CSV file to a 2D-string array.
    ''' </summary>
    ''' <param name="szFile">File name of the CSV file.</param>
    ''' <param name="szArr">Array with the content. szArr() will be resized to the correct size.</param>
    ''' <param name="pbStatus">Progress bar to show the progrees of parsing.</param>
    ''' <returns>Error message:
    '''<li>Empty: no error ocured. </li>
    '''<li>File not found: szFile is empty or the file specified by szFile couldn't be found. </li>
    '''<li>File is empty: File could be opened but is empty </li>
    '''<li>System Error + Error description: A system error occured. See VB Help for the explanation of the error message. </li></returns>
    ''' <remarks>ReadArr loads file with the file name szFile, parses the content and copies the data to szArr().<br>
    ''' Rules (if " is Quota and , is Separator):</br>    
    '''<li> " : mszQuota </li>
    '''<li> , : Separator </li>
    '''<li> row : cell,cell,cell </li>
    '''<li> not quoted cells: </li>
    '''<li>   ab,cd -> two cells: ab and cd </li>
    '''<li>   ab"cd -> ab"cd </li>
    '''<li>   ab""cd -> ab""cd </li>
    '''<li>   ab" -> ab" </li>
    '''<li>   ab"" -> ab"" </li>
    '''<li> quoted cells: </li>
    '''<li>   "ab" -> ab </li>
    '''<li>   "ab,cd" -> ab,cd </li>
    '''<li>   "ab"cd -> ab and ignore cd </li>
    '''<li>   "ab"de" -> ab and ignore cd </li>
    '''<li>   ""abcd -> empty cell and ignore abcd </li>
    '''<li>   "ab""cd" -> ab"cd </li>
    '''<li>   "ab"",cd" -> ab"cd </li>
    '''<li>   """abcd" -> "abcd </li>
    '''<li> last quoted cell in a row: </li>
    '''<li>   "abEOL -> ab </li>
    '''<li>   "ab"EOL -> ab </li>
    '''<li>   "ab""EOL -> ab" </li>
    '''<li>   "ab"""EOL -> ab" </li>
    '''<li>   "ab""cdEOL -> ab"cd </li>
    '''<li> Empty row -> one empty cell </li>
    ''' </remarks>
    Public Function ReadArr(ByVal szFile As String, ByRef szArr(,) As String, Optional ByVal pbStatus As System.Windows.Forms.ProgressBar = Nothing) As String
        Dim szRow As String
        Dim lFNr As Integer
        Dim lCols, lRows As Integer

        On Error GoTo SystemErr
        ' append extension
        ' later...

        ' seek for the file
        If Dir(szFile) = "" Or Len(szFile) = 0 Then Return "File not found." & vbCrLf & szFile

        ' open file
        lFNr = FreeFile()
        FileOpen(lFNr, szFile, OpenMode.Binary)

        ' read file, count # of rows
        lRows = 0
        Do  ' Read new line
            szRow = ReadRow(lFNr)
            ' count # of rows
            If Not EOF(lFNr) Or Len(szRow) <> 0 Then
                lRows = lRows + 1
            End If
        Loop Until EOF(lFNr)

        ' resize array to the # of rows
        If lRows = 0 Then FileClose(lFNr) : Return "File is empty." & vbCrLf & szFile
        lCols = 1
        ReDim szArr(lRows - 1, lCols - 1)
        ' read from beginning
        Seek(lFNr, 1)

        Dim szCell As String
        Dim lBeg, lEnd As Integer
        Dim blnQuota, blnFirstChar As Boolean
        Dim lCol, lRow As Integer

        lRow = 0
        Do  ' for each row
            szRow = ReadRow(lFNr) ' read new row, EOL included
            If Not EOF(lFNr) Or Len(szRow) <> 0 Then ' parse empty rows too
                ' parse the row
                lCol = 1
                lBeg = 1
                blnQuota = False
                For lEnd = 1 To Len(szRow)
                    Select Case Mid(szRow, lEnd, 1)

                        Case mszSeparator
                            If Not blnQuota Then
                                ' not quoted -> new cell found as is
                                If lCol > lCols Then ReDim Preserve szArr(lRows - 1, lCol - 1) : lCols = lCol
                                If lEnd > lBeg Then
                                    szCell = Mid(szRow, lBeg, lEnd - lBeg) ' cell is ok
                                Else
                                    szCell = "" ' cell is empty
                                End If
                                szArr(lRow, lCol - 1) = szCell
                                lCol = lCol + 1
                                lBeg = lEnd + 1
                            Else
                                ' quoted -> ignore separator and go on
                            End If

                        Case vbCr ' EOL
                            If blnQuota Then
                                ' quoted -> remove quotes
                                szCell = Mid(szRow, lBeg + 1, lEnd - lBeg - 1) ' without first quota
                                If Right(szCell, 1) = mszQuota Then szCell = Mid(szCell, 1, Len(szCell) - 1) ' last char was a quota -> remove
                                szCell = Replace(szCell, mszQuota & mszQuota, mszQuota) ' replace double quotas
                            Else
                                ' not quoted -> get the cell as is
                                If lEnd > lBeg Then
                                    szCell = Mid(szRow, lBeg, lEnd - lBeg) ' cell is ok
                                Else
                                    Exit For ' cell is empty -> don't insert!
                                End If
                            End If
                            ' save the cell
                            If lCol > lCols Then ReDim Preserve szArr(lRows - 1, lCol - 1) : lCols = lCol
                            szArr(lRow, lCol - 1) = szCell
                            lCol = lCol + 1
                            lBeg = lEnd + 1

                        Case mszQuota
                            If lBeg = lEnd Then
                                blnQuota = True ' first char in the cell, so we are quoted now!
                            ElseIf blnQuota Then
                                ' we were quoted and we've found next quota now
                                If Mid(szRow, lEnd + 1, 1) = vbCr Then
                                    ' quota is the last char, ignore it, parsing will be stopped automatically
                                ElseIf Mid(szRow, lEnd + 1, 1) = mszQuota Then
                                    lEnd = lEnd + 1 ' double quota found -> ignore and keep parsing
                                Else
                                    ' single quota found -> save the cell
                                    If lCol > lCols Then ReDim Preserve szArr(lRows - 1, lCol - 1) : lCols = lCol
                                    szCell = Mid(szRow, lBeg + 1, lEnd - lBeg - 1) ' without first quota
                                    szArr(lRow, lCol - 1) = Replace(szCell, mszQuota & mszQuota, mszQuota) ' replace double quotas
                                    lCol = lCol + 1
                                    ' set begin to the next separator or EOL
                                    lBeg = InStr(lEnd + 1, szRow, mszSeparator)
                                    If lBeg = 0 Then Exit For ' separator not found -> next row
                                    lBeg = lBeg + 1
                                    lEnd = lBeg - 1
                                    blnQuota = False ' we're leaving quoting now...
                                End If
                            Else
                                ' we've found quota somewhere in the middle but we are not quoted -> ignore
                            End If
                    End Select
                Next
                ' next row
                lRow = lRow + 1
                If Not (pbStatus Is Nothing) Then pbStatus.Value = CInt(100 * lRow / lRows)
            End If
        Loop Until EOF(lFNr)

        ' close the file
        FileClose(lFNr)
        On Error GoTo 0
        ReadArr = ""
        Exit Function

SystemErr:
        FileClose(lFNr)
        ReadArr = "System Error: " & Err.Description
        On Error GoTo 0
        Exit Function

SubErr:
        FileClose(lFNr)
        On Error GoTo 0
        Exit Function

    End Function


   ''' <summary>
    ''' Read content of a CSV file to a DataGridView object.
    ''' </summary>
    ''' <param name="szFile">File name of the CSV file.</param>
    ''' <param name="dgvDest">Datagridview object as destination for the data.</param>
    ''' <param name="pbStatus">Progress bar to show the progress of parsing.</param>
    ''' <returns>Error message, empty if no error ocured.</returns>
    ''' <remarks>Rules (if " is Quota and , is Separator):
    '''<li> " : mszQuota </li>
    '''<li> , : Separator </li>
    '''<li> row : cell,cell,cell </li>
    '''<li> not quoted cells: </li>
    '''<li>   ab,cd -> two cells: ab and cd </li>
    '''<li>   ab"cd -> ab"cd </li>
    '''<li>   ab""cd -> ab""cd </li>
    '''<li>   ab" -> ab" </li>
    '''<li>   ab"" -> ab"" </li>
    '''<li> quoted cells: </li>
    '''<li>   "ab" -> ab </li>
    '''<li>   "ab,cd" -> ab,cd </li>
    '''<li>   "ab"cd -> ab and ignore cd </li>
    '''<li>   "ab"de" -> ab and ignore cd </li>
    '''<li>   ""abcd -> empty cell and ignore abcd </li>
    '''<li>   "ab""cd" -> ab"cd </li>
    '''<li>   "ab"",cd" -> ab"cd </li>
    '''<li>   """abcd" -> "abcd </li>
    '''<li> last quoted cell in a row: </li>
    '''<li>   "abEOL -> ab </li>
    '''<li>   "ab"EOL -> ab </li>
    '''<li>   "ab""EOL -> ab" </li>
    '''<li>   "ab"""EOL -> ab" </li>
    '''<li>   "ab""cdEOL -> ab"cd </li>
    '''<li> Empty row -> one empty cell </li></remarks>
    Public Function ReadDGV(ByVal szFile As String, ByRef dgvDest As DataGridView, Optional ByVal pbStatus As System.Windows.Forms.ProgressBar = Nothing) As String
        Dim szRow As String
        Dim lFNr As Integer
        Dim lCols, lRows As Integer

        On Error GoTo SystemErr
        ' append extension
        ' later...

        ' seek for the file
        If Dir(szFile) = "" Then Return "File not found." & vbCrLf & szFile

        ' open file
        lFNr = FreeFile()
        FileOpen(lFNr, szFile, OpenMode.Binary, OpenAccess.Read)

        ' read file, count # of rows
        lRows = 0
        Do  ' Read new line
            szRow = ReadRow(lFNr)
            ' count # of rows
            If Not EOF(lFNr) Or Len(szRow) <> 0 Then
                lRows = lRows + 1
            End If
        Loop Until EOF(lFNr)
        Seek(lFNr, 1)

        If lRows = 0 Then FileClose(lFNr) : Return "File is empty." & vbCrLf & szFile

        ' read column headers
        szRow = ReadRow(lFNr) ' read new row, EOL included
        If Not EOF(lFNr) Or Len(szRow) <> 0 Then ' parse empty rows too
            Dim szArr(,) As String = Nothing
            ParseString(szRow, szArr)
            dgvDest.ColumnCount = szArr.Length
            For lCol As Integer = 0 To szArr.Length - 1
                dgvDest.Columns(lCol).HeaderText = szArr(0, lCol)
            Next
        End If
        If lRows = 1 Then FileClose(lFNr) : Return ""

        ' read the content
        Dim lRow As Integer = 0
        dgvDest.RowCount = lRows - 1
        Do  ' for each row
            szRow = ReadRow(lFNr) ' read new row, EOL included
            If Not EOF(lFNr) Or Len(szRow) <> 0 Then ' parse empty rows too
                Dim szArr(,) As String = Nothing
                ParseString(szRow, szArr)
                If Not IsNothing(szArr) Then
                    If szArr.Length > dgvDest.ColumnCount Then dgvDest.ColumnCount = szArr.Length
                    For lCol As Integer = 0 To szArr.Length - 1
                        dgvDest(lCol, lRow).Value = szArr(0, lCol)
                    Next
                End If
                lRow = lRow + 1
                If Not (pbStatus Is Nothing) Then pbStatus.Value = CInt(100 * lRow / lRows)
            End If
        Loop Until EOF(lFNr)

        ' close the file
        FileClose(lFNr)
        On Error GoTo 0
        Return ""

SystemErr:
        FileClose(lFNr)
        On Error GoTo 0
        Return "System Error: " & Err.Description

    End Function


   ''' <summary>
    ''' Write content of a 2D-string array to a CSV file.
    ''' </summary>
    ''' <param name="szFile">File Name of the new CSV file.</param>
    ''' <param name="szArr">Array with the data.</param>
    ''' <param name="pbStatus">Progress bar to show the progress of parsing.</param>
    ''' <returns>Error message, empty if no error ocured.</returns>
    ''' <remarks>Rules (if " is Quota and , is Separator):
    '''<li> row : cell,cell,cell </li>
    '''<li> cell: </li>
    '''<li>   abcdef -> abcdef </li>
    '''<li>   abc,def -> "abc,def" </li>
    '''<li>   "abcdef -> """abcdef" </li>
    '''<li>   abc",def -> "abc"",def" </li>
    '''<li>   ab,cd,"ef -> "ab,cd""ef" </li></remarks>
    Public Function WriteArr(ByVal szFile As String, ByVal szArr(,) As String, Optional ByVal pbStatus As System.Windows.Forms.ProgressBar = Nothing) As String
        Dim szCell As String
        Dim lFNr, lRows As Integer
        On Error GoTo SystemErr
        ' append extension
        ' later...

        ' delete old file
        If Dir(szFile) <> "" Then Kill(szFile)

        ' open file
        lFNr = FreeFile()
        FileOpen(lFNr, szFile, OpenMode.Binary)

        ' save
        Dim lCol, lRow As Integer
        Dim szX As String
        lRows = UBound(szArr, 1)
        For lRow = 0 To lRows
            szX = ""
            For lCol = 0 To UBound(szArr, 2)
                szCell = szArr(lRow, lCol)
                ' CSV rule: double all Quota
                szCell = Replace(szCell, mszQuota, mszQuota & mszQuota)
                ' CSV rule: quote if Quota or separator found
                If InStr(1, szCell, mszSeparator) > 0 Or InStr(1, szCell, mszQuota) > 0 Then
                    szCell = mszQuota + szCell + mszQuota
                End If
                ' CSV rule: add separator between cells
                szX = szX + szCell + mszSeparator
            Next
            ' remove last separator and write a row
            WriteRow(lFNr, Left(szX, Len(szX) - Len(mszSeparator)))
            If Not (pbStatus Is Nothing) Then pbStatus.Value = CInt(100 * lRow / lRows)
        Next

        ' close file
        FileClose(lFNr)
        WriteArr = ""
        On Error GoTo 0
        Exit Function

SystemErr:
        FileClose(lFNr)
        WriteArr = "System Error: " & Err.Description
        On Error GoTo 0
        Exit Function

    End Function

   ''' <summary>
    ''' Write content of a DataGridView to a CSV file.
    ''' </summary>
    ''' <param name="szFile">File Name of the new CSV file.</param>
    ''' <param name="dgvSource">DataGridView object containing data.</param>
    ''' <param name="pbStatus">Progress bar to show the progress of parsing.</param>
    ''' <returns>Error message, empty if no error ocured.</returns>
    ''' <remarks>Rules (if " is Quota and , is Separator):
    '''<li> row : cell,cell,cell </li>
    '''<li> cell: </li>
    '''<li>   abcdef -> abcdef </li>
    '''<li>   abc,def -> "abc,def" </li>
    '''<li>   "abcdef -> """abcdef" </li>
    '''<li>   abc",def -> "abc"",def" </li>
    '''<li>   ab,cd,"ef -> "ab,cd""ef" </li> </remarks>
    Public Function WriteDGV(ByVal szFile As String, ByVal dgvSource As DataGridView, Optional ByVal pbStatus As System.Windows.Forms.ProgressBar = Nothing) As String
        Dim szCell As String
        Dim lFNr As Integer

        Try
            ' delete old file
            If Dir(szFile) <> "" Then Kill(szFile)

            ' open file
            lFNr = FreeFile()
            FileOpen(lFNr, szFile, OpenMode.Binary)

            ' save
            Dim lCol, lRow As Integer
            Dim szX As String = ""
            ' save headers
            For lCol = 0 To dgvSource.ColumnCount - 1
                szCell = QuoteCell(dgvSource.Columns(lCol).HeaderText)
                szX = szX + szCell + mszSeparator
            Next
            WriteRow(lFNr, Left(szX, Len(szX) - Len(mszSeparator)))
            ' save the list
            For lRow = 0 To dgvSource.RowCount - 1
                szX = ""
                For lCol = 0 To dgvSource.ColumnCount - 1
                    If IsNothing(dgvSource.Item(lCol, lRow).Value) Then
                        szCell = QuoteCell("")
                    Else
                        szCell = QuoteCell(dgvSource.Item(lCol, lRow).Value.ToString)
                    End If
                    szX = szX + szCell + mszSeparator
                Next
                ' remove last separator and write a row
                WriteRow(lFNr, Left(szX, Len(szX) - Len(mszSeparator)))
                If Not (pbStatus Is Nothing) Then pbStatus.Value = CInt(100 * lRow / (dgvSource.RowCount))
            Next

        Catch
            If Err.Number = 75 Then
                FileClose(lFNr)
                Return "System Error: " & Err.Description & vbCrLf & "Possible reason: Read-only flags set."
            Else
                FileClose(lFNr)
                Return "System Error: " & Err.Description
            End If
        End Try

        FileClose(lFNr)
        Return ""
    End Function

   ''' <summary>
    ''' Quote a single cell according to the CSV rules.
    ''' </summary>
    ''' <param name="szCell">Content of a single cell.</param>
    ''' <returns>Quoted value.</returns>
    ''' <remarks></remarks>
    Public Function QuoteCell(ByVal szCell As String) As String

        ' CSV rule: return empty if empty (do not quote nothing!)
        If Len(szCell) = 0 Then Return ""
        ' CSV rule: double all Quota
        Dim szRes As String = Replace(szCell, mszQuota, mszQuota & mszQuota)
        ' CSV rule: quote if Quota or separator found
        If InStr(1, szRes, mszSeparator) > 0 Or InStr(1, szRes, mszQuota) > 0 Then
            szRes = mszQuota & szRes & mszQuota
        End If
        Return szRes

    End Function

    Private Function ReadRow(ByVal lFNr As Integer) As String
        Dim bX As Byte
        Dim szX As String = ""

        Do
            FileGet(lFNr, bX)
            If bX <> Asc(vbLf) And bX <> 0 Then
                szX = szX & Chr(bX) ' append all chars but CR and LF
            End If
        Loop Until (bX = Asc(vbCr)) Or EOF(lFNr)
        If EOF(lFNr) And Len(szX) <> 0 Then szX = szX & vbCr
        ReadRow = szX

    End Function

    Private Sub WriteRow(ByVal lFNr As Integer, ByVal szRow As String)
        Dim lX As Integer

        For lX = 1 To Len(szRow)
            FilePut(lFNr, CByte(Asc(Mid(szRow, lX, 1))))
        Next
        FilePut(lFNr, CByte(13))
        FilePut(lFNr, CByte(10))

    End Sub

    ''' <summary>
    ''' New instance of CSVParser
    ''' </summary>
    Public Sub New()
        MyBase.New()
        mszSeparator = Chr(INIOptions.glCSVDelimiter)
        mszQuota = Chr(INIOptions.glCSVQuota)
    End Sub
End Class