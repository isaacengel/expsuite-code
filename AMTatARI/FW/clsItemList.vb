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
''' Flags to restrict the content of items.
''' </summary>
''' <remarks>Select the type of content (string, numeric, directory of file name) and then use a proper restriction.
'''  <list type="table">
'''  <item><description><c>ifString</c> Content is a string. See String flags for further restrictions.</description></item> 
'''  <item><description><c>ifNumeric</c> Content is numeric. See Numeric flags for further restrictions.</description></item> 
'''  <item><description><c>ifDirectory</c> Content is a directory.</description></item> 
'''  <item><description><c>ifFileName</c> Content is a file name. See Filename flags for further restrictions. Use the Unit parameter to set the file name mask (e.g. *.txt)</description></item> 
'''  <item><description><c>ifElectrodeL</c> Content is a left electrode from Settings/Signal. See Electrode flags for further restrictions.</description></item> 
'''  <item><description><c>ifElectrodeR</c> Content is a right electrode from Settings/Signal. See Electrode flags for further restrictions.</description></item> 
'''  <item><description><c>ifFlagTypeMask</c> Mask of the flag type. Use "MyFlags AND ifFlagTypeMask" to retrieve the type of the flag.</description></item> 
'''  </list>
''' 
''' <b>Numeric Flags:</b>
''' <list type="table">
''' <item><description><c>ifInteger</c> Restrict to integer.</description></item> 
''' <item><description><c>ifNonZero</c> Must not be zero.</description></item> 
''' <item><description><c>ifMinTimeDelay</c>  Must be positive integer.</description></item> 
''' <item><description><c>ifMin</c> Sets a restriction to a minimum value. Use the Min parameter to set the range.</description></item> 
''' <item><description><c>ifMax</c> Sets a restriction to a maximum value. Use the Min parameter to set the range.</description></item> 
''' <item><description><c>ifVectorized</c> Content can be a vector of numeric values, separated by blank or semicolon (not both!).</description></item> 
''' </list>
''' 
''' <b>Electrode Flags:</b>
''' <list type="table">
''' <item><description><c>ifMin</c> Content is numeric. See Numeric flags for further restrictions.</description></item> 
''' <item><description><c>ifMax</c> Content is numeric. See Numeric flags for further restrictions.</description></item> 
''' <item><description><c>ifVectorized</c> Content can be a vector of electrodes, separated by blank or semicolon (not both!).</description></item> 
''' <item><description><c>ifNoTHRCheck</c> Do not check the AMP field to be higher then the THR field (from Settings/Signal)</description></item> 
''' <item><description><c>ifNoMCLCheck</c> Do not check the AMP field to be lower then the MCL field (from Settings/Signal)</description></item> 
''' </list>
''' 
''' <b>String Flags:</b>
''' <list type="table">
''' <item><description><c>ifNonEmpty</c> Content must not be empty.</description></item> 
''' <item><description><c>ifEnumeration</c> Content must be a chosen one from the list given in Unit string. Use the Unit parameter to set the list of atoms selected by ;</description></item> 
''' <item><description><c>ifCaseSensitive</c> Content is case sensitive.</description></item> 
''' <item><description><c>ifUpperCase</c> Content will be converted to upper case.</description></item> 
''' <item><description><c>ifLowerCase</c> Content will be converted to lower case.</description></item> 
''' </list>
''' 
''' <b>File Name Flages:</b>
''' <list type="table">
''' <item><description><c>ifAbsolute</c> Absolute file name including path name.</description></item> 
''' <item><description><c>ifRelativeDataDir1</c> File name, relative to the data directory #1 (index = 0)</description></item> 
''' <item><description><c>ifRelativeDataDir2</c> File name, relative to the data directory #2 (index = 1)</description></item> 
''' <item><description><c>ifRelativeDataDir3</c> File name, relative to the data directory #3 (index = 2)</description></item> 
''' <item><description><c>ifRelativeDataDir4</c> File name, relative to the data directory #4 (index = 3)</description></item> 
''' <item><description><c>ifRelativeDataDir5</c> File name, relative to the data directory #5 (index = 4)</description></item> 
''' <item><description><c>ifRelativeDataDir6</c> File name, relative to the data directory #6 (index = 5)</description></item> 
''' <item><description><c>ifRelativeDataDir7</c> File name, relative to the data directory #7 (index = 6)</description></item> 
''' </list>
''' 
''' <b>System Flags:</b>
''' <list type="table">
''' <item><description><c>ifIndex</c> Column is an index column. Used for renumbering of index functionality.</description></item> 
''' <item><description><c>ifDisabled</c> Column will be disabled. Not implemented yet!</description></item> 
''' </list>
''' </remarks>
Friend Class clsItemList

    Public Enum ItemListFlags
        ' flag types
        ifString = 0
        ifNumeric = 3
        ifDirectory = 2
        ifFileName = 1
        ifElectrodeL = 4
        ifElectrodeR = 5
        ifIndex = 6
        ifFlagTypeMask = &HF
        ' numeric only
        ifInteger = &H10
        ifNonZero = &H20
        ifMinTimeDelay = &H100
        ifMin = &H200
        ifMax = &H400
        ifVectorized = &H1000
        ' electrode only
        ifNoTHRCheck = &H10
        ifNoMCLCheck = &H20
        '  ifMin = &H200&
        '  ifMax = &H400&
        '  ifVectorized = &H1000&
        ' non-numeric only
        ifNonEmpty = &H10
        ifEnumeration = &H20
        ifCaseSensitive = &H40
        ifUpperCase = &H80
        ifLowerCase = &H100
        ' filename only
        ifAbsolute = &H0
        ifRelativeDataDir1 = &H10
        ifRelativeDataDir2 = &H20
        ifRelativeDataDir3 = &H30
        ifRelativeDataDir4 = &H40
        ifRelativeDataDir5 = &H50
        ifRelativeDataDir6 = &H60
        ifRelativeDataDir7 = &H70
        ' system flags
        ifDisabled = &H8000
    End Enum

    Public Enum Status
        ' Status for items
        Fresh = 0 'not started yet
        Processing = 1 'item started (at least one subject response) but not finished
        FinishedOK = 2 'finished
        FinishedError = 3 'error (eg amplitude out of range, ... depending on experiment)
        Ignored = 4 'ignored during experiment
    End Enum

    Private micData() As ItemColumn
    Private mlIndexCol As Integer = -1
    Private mlRow As Integer
    Private mszDirectory As String
    Public mdgvList As DataGridView

    Private Structure ItemColumn ' properties of a column
        Dim szCaption As String
        Dim szUnit As String
        Dim Flags As ItemListFlags
        Dim dMin As Double
        Dim dMax As Double
    End Structure

    ' Column - Functions
    ' ------------------

    ''' <summary>
    ''' Get the number of columns in the item list. 
    ''' </summary>
    ''' <see cref="Reset"/>
    ''' <see cref="AddCol"/>
    ''' <value></value>
    ''' <returns>Number of columns in the item list.</returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property ColCount() As Integer
        Get
            Return GetUboundCol(micData) + 1
        End Get
    End Property

    ''' <summary>
    ''' Renumber index in item list.
    ''' </summary>
    ''' <remarks>Obsolete function: For backwards compatibility only</remarks>
    Public Sub RenumberIndex()

        If mlIndexCol = -1 Then Return
        For lX As Integer = 0 To mdgvList.RowCount - 1
            mdgvList.Item(mlIndexCol, lX).Value = TStr(lX + 1)
        Next

    End Sub

    ''' <summary>
    ''' Get the index of a column described by caption.
    ''' This property is useful with experiment depending item lists, where the position of a column may move and the caption still remains.
    ''' </summary>
    ''' <param name="Col">Caption of a column</param>
    ''' <value></value>
    ''' <returns>Column index</returns>
    ''' <remarks>ColIndex returns the index of a column, which was found for the given caption Col.</remarks>
    Friend ReadOnly Property ColIndex(ByVal Col As String) As Integer
        Get
            Dim szCol As String
            Dim lCol As Integer
            szCol = LCase(Col)
            For lCol = 0 To GetUboundCol(micData)
                If LCase(micData(lCol).szCaption) = szCol Then Exit For
            Next
            If lCol > GetUboundCol(micData) Then lCol = -1
            ColIndex = lCol
        End Get
    End Property

    ''' <summary>
    ''' Col[Flag, Min, Max, Unit, Caption] sets/gets the Flags, minimum value, maximum value, the unit or the caption of a column.
    ''' </summary>
    ''' <param name="lCol">Column index.</param>
    ''' <value></value>
    ''' <returns>Flag restricting the content.</returns>
    ''' <remarks></remarks>
    Friend Property ColFlag(ByVal lCol As Integer) As ItemListFlags
        Get
            If lCol > GetUboundCol(micData) Then Err.Raise(vbObjectError, "Itemlist: ColFlag", "Column out of bounds")
            If lCol < 0 Then Err.Raise(vbObjectError, "Itemlist: ColFlag", "Column < 0")
            ColFlag = micData(lCol).Flags
        End Get
        Set(ByVal Value As ItemListFlags)
            If lCol > GetUboundCol(micData) Then Err.Raise(vbObjectError, "Itemlist: ColFlag", "Column out of bounds")
            If lCol < 0 Then Err.Raise(vbObjectError, "Itemlist: ColFlag", "Column < 0")
            micData(lCol).Flags = Value
        End Set
    End Property

    ''' <summary>
    ''' Col[Flag, Min, Max, Unit, Caption] sets/gets the Flags, minimum value, maximum value, the unit or the caption of a column.
    ''' </summary>
    ''' <param name="lCol">Column index.</param>
    ''' <value></value>
    ''' <returns>Minimum allowed value.</returns>
    ''' <remarks></remarks>
    Friend Property ColMin(ByVal lCol As Integer) As Double
        Get
            If lCol > GetUboundCol(micData) Then Err.Raise(vbObjectError, "Itemlist: ColMin", "Column out of bounds")
            If lCol < 0 Then Err.Raise(vbObjectError, "Itemlist: ColFlag", "Column < 0")
            ColMin = micData(lCol).dMin
        End Get
        Set(ByVal Value As Double)
            If lCol > GetUboundCol(micData) Then Err.Raise(vbObjectError, "Itemlist: ColMin", "Column out of bounds")
            If lCol < 0 Then Err.Raise(vbObjectError, "Itemlist: ColFlag", "Column < 0")
            micData(lCol).dMin = Value
        End Set
    End Property

    ''' <summary>
    ''' Col[Flag, Min, Max, Unit, Caption] sets/gets the Flags, minimum value, maximum value, the unit or the caption of a column.
    ''' </summary>
    ''' <param name="lCol">Column index.</param>
    ''' <value></value>
    ''' <returns>Maximum allowed value.</returns>
    ''' <remarks></remarks>
    Friend Property ColMax(ByVal lCol As Integer) As Double
        Get
            If lCol > GetUboundCol(micData) Then Err.Raise(vbObjectError, "Itemlist: ColMax", "Column out of bounds")
            If lCol < 0 Then Err.Raise(vbObjectError, "Itemlist: ColFlag", "Column < 0")
            ColMax = micData(lCol).dMax
        End Get
        Set(ByVal Value As Double)
            If lCol > GetUboundCol(micData) Then Err.Raise(vbObjectError, "Itemlist: ColMax", "Column out of bounds")
            If lCol < 0 Then Err.Raise(vbObjectError, "Itemlist: ColFlag", "Column < 0")
            micData(lCol).dMax = Value
        End Set
    End Property

    ''' <summary>
    ''' Col[Flag, Min, Max, Unit, Caption] sets/gets the Flags, minimum value, maximum value, the unit or the caption of a column.
    ''' </summary>
    ''' <param name="lCol">Column index.</param>
    ''' <value></value>
    ''' <returns>Unit or string with enumerated atoms separated by ";" if flag is ifEnumeration.</returns>
    ''' <remarks></remarks>
    Friend Property ColUnit(ByVal lCol As Integer) As String
        Get
            If lCol > GetUboundCol(micData) Then Err.Raise(vbObjectError, "Itemlist: ColUnit", "Column out of bounds")
            If lCol < 0 Then Err.Raise(vbObjectError, "Itemlist: ColFlag", "Column < 0")
            ColUnit = micData(lCol).szUnit
        End Get
        Set(ByVal Value As String)
            If lCol > GetUboundCol(micData) Then Err.Raise(vbObjectError, "Itemlist: ColUnit", "Column out of bounds")
            If lCol < 0 Then Err.Raise(vbObjectError, "Itemlist: ColFlag", "Column < 0")
            micData(lCol).szUnit = Value
        End Set
    End Property

    ''' <summary>
    ''' Col[Flag, Min, Max, Unit, Caption] sets/gets the Flags, minimum value, maximum value, the unit or the caption of a column.
    ''' </summary>
    ''' <param name="lCol">Column index.</param>
    ''' <value></value>
    ''' <returns>Caption of the column.</returns>
    ''' <remarks></remarks>
    Friend Property ColCaption(ByVal lCol As Integer) As String
        Get
            If lCol > GetUboundCol(micData) Then Err.Raise(vbObjectError, "Itemlist: ColCaption", "Column out of bounds")
            If lCol < 0 Then Err.Raise(vbObjectError, "Itemlist: ColFlag", "Column < 0")
            ColCaption = micData(lCol).szCaption
        End Get
        Set(ByVal Value As String)
            If lCol > GetUboundCol(micData) Then Err.Raise(vbObjectError, "Itemlist: ColCaption", "Column (=" & TStr(lCol) & ") out of bounds (=" & TStr(GetUboundCol(micData)) & ")")
            If lCol < 0 Then Err.Raise(vbObjectError, "Itemlist: ColFlag", "Column < 0")
            mdgvList.Columns(lCol).HeaderText = Value
            micData(lCol).szCaption = Value
            If (mlIndexCol = -1) And (LCase(Value) = "index") Then mlIndexCol = lCol
        End Set
    End Property

    ''' <summary>
    ''' Get the index of the column defined as the Index-column.
    ''' </summary>
    ''' <value></value>
    ''' <returns>Column index.</returns>
    ''' <remarks>This column will be stamped with .ItemStamp</remarks>
    ''' <see cref="ItemStamp"/>
    Friend ReadOnly Property GetIndexCol() As Integer
        Get
            Return mlIndexCol
        End Get
    End Property

    ''' <summary>
    ''' Get the index of the last column, within all selected cells.
    ''' </summary>
    ''' <value></value>
    ''' <returns>Column index.</returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property SelectedColumnLast() As Integer
        Get
            If mdgvList.SelectedCells.Count = 0 Then Return -1
            Dim lCol As Integer = 0
            For Each cell As DataGridViewCell In mdgvList.SelectedCells
                If cell.ColumnIndex > lCol Then lCol = cell.ColumnIndex
            Next
            Return lCol
        End Get
    End Property

    ''' <summary>
    ''' Get the index of the first column, within all selected cells.
    ''' </summary>
    ''' <value></value>
    ''' <returns>Column index.</returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property SelectedColumnFirst() As Integer
        Get
            If mdgvList.SelectedCells.Count = 0 Then Return -1
            Dim lCol As Integer = mdgvList.ColumnCount
            For Each cell As DataGridViewCell In mdgvList.SelectedCells
                If cell.ColumnIndex < lCol Then lCol = cell.ColumnIndex
            Next
            Return lCol
        End Get
    End Property

    Friend ReadOnly Property SelectedItemLast() As Integer
        Get
            If mdgvList.SelectedCells.Count = 0 Then Return -1
            Dim lRow As Integer = 0
            For Each cell As DataGridViewCell In mdgvList.SelectedCells
                If cell.RowIndex > lRow Then lRow = cell.RowIndex
            Next
            Return lRow
        End Get
    End Property

    ''' <summary>
    ''' Get the index of the first item (lowest index), within all selected cells.
    ''' </summary>
    ''' <value></value>
    ''' <returns>Column index.</returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property SelectedItemFirst() As Integer
        Get
            If mdgvList.SelectedCells.Count = 0 Then Return -1
            Dim lRow As Integer = mdgvList.RowCount
            For Each cell As DataGridViewCell In mdgvList.SelectedCells
                If cell.RowIndex < lRow Then lRow = cell.RowIndex
            Next
            Return lRow
        End Get
    End Property


    ' Item - Functions
    ' -----------------

    ''' <summary>
    ''' Set the index of selected item.
    ''' </summary>
    ''' <value></value>
    ''' <returns>Item index</returns>
    ''' <remarks>ItemIndex starts with 0 and its maximum value is ItemCount-1. ItemIndex returns -1 if no item has been selected.</remarks>
    Friend Property ItemIndex() As Integer
        Get
            If mdgvList.RowCount < 1 Then Console.WriteLine("ItemList.ItemIndex: Item list is empty.") : Return -1
            With mdgvList
                If gblnExperiment Then
                    Return mlRow
                Else
                    Return .CurrentCellAddress.Y
                End If
            End With
        End Get
        Set(ByVal Value As Integer)
            If Value >= mdgvList.RowCount Then Console.WriteLine("ItemList.ItemIndex: Item index exceeds ItemCount.") : Return
            If Value < 0 Then Console.WriteLine("ItemList.ItemIndex: Item index must not be negative.") : Return
            mlRow = Value
            With mdgvList
                .CurrentCell = .Rows(Value).Cells(0)
                .Rows(Value).Selected = True
                If gblnExperiment Then
                    Dim lX As Integer = .DisplayedRowCount(True)
                    If Value > (10 * lX \ 16) Then
                        .FirstDisplayedScrollingRowIndex = Value - (10 * lX \ 16)
                        Console.WriteLine(TStr(.FirstDisplayedScrollingRowIndex))
                    Else
                        .FirstDisplayedScrollingRowIndex = 0   ' full item list shown
                        ' Console.WriteLine("null")
                    End If
                End If
            End With
            Windows.Forms.Application.DoEvents() 'show scroll
        End Set
    End Property


    ''' <summary>
    ''' Get the number of items in the item list.
    ''' </summary>
    ''' <value></value>
    ''' <returns>Number of items in the item list. Returns 0 for disabled item list.</returns>
    ''' <remarks>ItemCount returns the number of items in the item list. Add at least one column before setting item count, otherwise one extra column will be created!</remarks>
    Friend Property ItemCount() As Integer
        Get
            Return mdgvList.RowCount
        End Get
        Set(ByVal Value As Integer)
            If Value < 0 Then Console.WriteLine("ItemList.ItemCount: item count < 0 not allowed") : Return
            If Value = 0 Then
                'ItemList.Clear()    ' bug; cleared item list (even if result list should have been reset)

                'fix:
                Dim lOld As Integer = mdgvList.RowCount
                mdgvList.RowCount = 0

                mdgvList.Enabled = False
                SetOptimalColWidth()
            Else
                Dim lOld As Integer = mdgvList.RowCount
                mdgvList.RowCount = Value
                mdgvList.Enabled = True
            End If

        End Set
    End Property

    ''' <summary>
    ''' Get/Set the content of item at given column. 
    ''' </summary>
    ''' <param name="lItem">Index of the item, beginning with 0.</param>
    ''' <param name="lCol">Column selector. Integer for selection by index.</param>
    ''' <value></value>
    ''' <returns>Content of the item. Double variant if the column is a numeric scalar or electrode scalar. String variant otherwise.</returns>
    ''' <remarks>Item returns the content of an item at given column. The column can be selected by its index. The content won't be checked for validity - use CheckItem before setting items with unknown content. If the item column is set to be numeric scalar or electrode scalar, the variant returned by Item is of data type double. Otherwise Item returns a string variant.</remarks>
    Friend Property Item(ByVal lItem As Integer, ByVal lCol As Integer) As String
        Get
            Windows.Forms.Application.DoEvents()

            If lCol > GetUboundCol(micData) Then Console.WriteLine("Itemlist.Item: Column out of bounds") : Return ""
            If lCol < 0 Then Console.WriteLine("Itemlist.Item: Column < 0") : Return ""
            If lItem >= mdgvList.RowCount Then Console.WriteLine("Itemlist.Item: Item out of bounds") : Return ""
            Return CType(mdgvList.Item(lCol, lItem).Value, String)
        End Get

        Set(ByVal Value As String)
            If lCol > GetUboundCol(micData) Then Console.WriteLine("Itemlist.Item: Column out of bounds") : Return
            If lCol < 0 Then Console.WriteLine("Itemlist.Item: Column < 0") : Return
            If lItem >= mdgvList.RowCount Then Console.WriteLine("Itemlist.Item: Item out of bounds") : Return
            mdgvList.Item(lCol, lItem).Value = Value
            'If gblnRemoteServerConnected And gblnExperiment And Not Value Is Nothing Then frmMain.ServeData("Next Item", lItem, lCol, Value, 0)
        End Set
    End Property

    ''' <summary>
    ''' Get/Set the content of item at given column. 
    ''' </summary>
    ''' <param name="lItem">Index of the item, beginning with 0.</param>
    ''' <param name="Col">Column selector. String for selection by name.</param>
    ''' <value></value>
    ''' <returns>Content of the item. Double variant if the column is a numeric scalar or electrode scalar. String variant otherwise.</returns>
    ''' <remarks>Item returns the content of an item at given column. The column can be selected by its caption. The content won't be checked for validity - use CheckItem before setting items with unknown content. If the item column is set to be numeric scalar or electrode scalar, the variant returned by Item is of data type double. Otherwise Item returns a string variant.</remarks>
    Friend Property Item(ByVal lItem As Integer, ByVal Col As String) As String
        Get
            Dim lCol As Integer
            Dim Flags As ItemListFlags

            Dim szCol As String
            szCol = LCase(Col)
            For lCol = 0 To GetUboundCol(micData)
                If LCase(micData(lCol).szCaption) = szCol Then Exit For
            Next
            If lCol > GetUboundCol(micData) Then Console.WriteLine("Itemlist.Item: Column described by " & szCol & " couldn't be found.") : Return ""
            If lItem >= mdgvList.RowCount Then Console.WriteLine("Itemlist.Item: Item out of bounds") : Return ""
            Flags = micData(lCol).Flags
            If IsNothing(mdgvList.Item(lCol, lItem).Value) Then Return ""
            Item = mdgvList.Item(lCol, lItem).Value.ToString
        End Get
        Set(ByVal Value As String)
            Dim lCol As Integer
            Dim szCol As String
            szCol = LCase(Col)
            For lCol = 0 To GetUboundCol(micData)
                If LCase(micData(lCol).szCaption) = szCol Then Exit For
            Next
            If lCol > GetUboundCol(micData) Then Console.WriteLine("Itemlist.Item: Column described by " & szCol & " couldn't be found.") : Return
            If lItem >= mdgvList.RowCount Then Console.WriteLine("Itemlist.Item: Item out of bounds") : Return
            mdgvList.Item(lCol, lItem).Value = Value
            'If gblnRemoteServerConnected And gblnExperiment And Not Value Is Nothing Then frmMain.ServeData("Next Item", lItem, lCol, Value)
        End Set
    End Property

    ''' <summary>
    ''' Add content to cell at given row and column. By default the new value will be appended to the existing item. Set 'AddBeforeCellContent' true to append existing cell content to new value.
    ''' </summary>
    ''' <param name="lItem">Index of the item, beginning with 0.</param>
    ''' <param name="Col">Column selector. String for selection by name.</param>
    ''' <param name="AddBeforeCellContent">Append existing content to new content (default: false).</param>
    ''' <remarks>The column can be selected by its caption. The content won't be checked for validity.</remarks>
    Friend WriteOnly Property AppendToItem(ByVal lItem As Integer, ByVal Col As String, Optional ByVal AddBeforeCellContent As Boolean = False, Optional szSeparator As String = " ") As String
        Set(ByVal Value As String)
            Dim lCol As Integer
            Dim szCol As String
            szCol = LCase(Col)
            For lCol = 0 To GetUboundCol(micData)
                If LCase(micData(lCol).szCaption) = szCol Then Exit For
            Next
            If lCol > GetUboundCol(micData) Then Console.WriteLine("Itemlist.Item: Column described by " & szCol & " couldn't be found.") : Return
            If lItem >= mdgvList.RowCount Then Console.WriteLine("Itemlist.Item: Item out of bounds") : Return

            If mdgvList.Item(lCol, lItem).Value Is Nothing Or mdgvList.Item(lCol, lItem).Value Is "" Then
                mdgvList.Item(lCol, lItem).Value = Value
            ElseIf AddBeforeCellContent Then
                mdgvList.Item(lCol, lItem).Value = Value & szSeparator & mdgvList.Item(lCol, lItem).Value.ToString
            Else
                mdgvList.Item(lCol, lItem).Value = mdgvList.Item(lCol, lItem).Value.ToString & szSeparator & Value
            End If

        End Set
    End Property

    ''' <summary>
    ''' Add content to cell at given row and column. By default the new value will be appended to the existing item. Set 'AddBeforeCellContent' true to append existing cell content to new value.
    ''' </summary>
    ''' <param name="lItem">Index of the item, beginning with 0.</param>
    ''' <param name="lCol">Column selector. Integer for selection by index.</param>
    ''' <param name="AddBeforeCellContent">Append existing content to new content (default: false).</param>
    ''' <remarks>The column can be selected by its caption. The content won't be checked for validity.</remarks>
    Friend WriteOnly Property AppendToItem(ByVal lItem As Integer, ByVal lCol As Integer, Optional ByVal AddBeforeCellContent As Boolean = False) As String
        Set(ByVal Value As String)
            If lCol > GetUboundCol(micData) Then Console.WriteLine("Itemlist.Item: Column out of bounds") : Return
            If lCol < 0 Then Console.WriteLine("Itemlist.Item: Column < 0") : Return
            If lItem >= mdgvList.RowCount Then Console.WriteLine("Itemlist.Item: Item out of bounds") : Return

            If mdgvList.Item(lCol, lItem).Value Is Nothing Or mdgvList.Item(lCol, lItem).Value Is "" Then
                mdgvList.Item(lCol, lItem).Value = Value
            ElseIf AddBeforeCellContent Then
                mdgvList.Item(lCol, lItem).Value = Value & " " & mdgvList.Item(lCol, lItem).Value.ToString
            Else
                mdgvList.Item(lCol, lItem).Value = mdgvList.Item(lCol, lItem).Value.ToString & " " & Value
            End If

        End Set
    End Property

    ''' <summary>
    ''' TextMatrix sets/gets the content of the item list table.
    ''' </summary>
    ''' <param name="lRow"></param>
    ''' <param name="lCol"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks><b>Don't use it.</b>
    ''' TextMatrix is very similar to Item, the only difference is the row index: it refers to the row in the item list table including the first row with captions.
    ''' It was implemented to provide a kind of compatibility to the TextMatrix method of the FFF object, which is used for the implementation of the item list.
    ''' The column can be refered by its index only (no indexing by caption here).
    '''</remarks>
    Friend Property TextMatrix(ByVal lRow As Integer, ByVal lCol As Integer) As String
        Get
            With mdgvList
                If lCol >= .ColumnCount Then Err.Raise(vbObjectError, "Itemlist: TextMatrix", "Column out of bounds")
                If lRow > .RowCount Then Err.Raise(vbObjectError, "Itemlist: TextMatrix", "Row out of bounds")
                If lRow = 0 Then
                    Return Me.ColCaption(lCol)
                Else
                    Return Me.Item(lRow - 1, lCol)
                End If
            End With
            Return ""
        End Get
        Set(ByVal Value As String)
            With mdgvList
                If lCol >= .ColumnCount Then Err.Raise(vbObjectError, "Itemlist: TextMatrix", "Column out of bounds")
                If lRow > .RowCount Then Err.Raise(vbObjectError, "Itemlist: TextMatrix", "Row out of bounds")
                If lRow = 0 Then
                    Me.ColCaption(lCol) = Value
                Else
                    Me.Item(lRow - 1, lCol) = Value
                End If
            End With
            Return
        End Set
    End Property

    ''' <summary>
    ''' Add a column to the item list.
    ''' </summary>
    ''' <param name="szCaption">Caption. String with the caption (case doesn't matter) or Long with the index of the column.</param>
    ''' <param name="Flag">Flag restricting the content of all items in this column.</param>
    ''' <param name="szUnit">Unit or string with enumerated atoms separated by ";" if Flag is ifEnumeration.</param>
    ''' <param name="dMin">Minimum allowed value if Flag is ifMin.</param>
    ''' <param name="dMax">Maximum allowed value if Flag is ifMax.</param>
    ''' <remarks>A new column will be added to the end (most right) of the item list. The columns will be identyfied by its Caption or the index. Flag can be set to restrict the content of the column.
    ''' See <see cref="ItemListFlags"/> for possible values. Set to ifString if not used (=column entries are string without any restrictions)
    ''' Unit, Min or Max parameters may be set, which are associated with given Flag.
    ''' The index column is column 0 by default, this can be changed assigning flag ifIndex to a column.
    ''' </remarks>
    Friend Sub AddCol(ByVal szCaption As String, _
                    Optional ByVal Flag As ItemListFlags = ItemListFlags.ifString, _
                    Optional ByVal szUnit As String = "", _
                    Optional ByVal dMin As Double = 0, Optional ByVal dMax As Double = 0)
        Dim lX As Integer
        lX = GetUboundCol(micData) + 1
        If (Flag And ItemListFlags.ifFlagTypeMask) > ItemListFlags.ifIndex Then Err.Raise(vbObjectError, "Itemlist, Add column", szCaption & ": wrong column type.")
        ReDim Preserve micData(lX)
        micData(lX).Flags = Flag
        micData(lX).szCaption = szCaption
        micData(lX).szUnit = szUnit
        micData(lX).dMin = dMin
        micData(lX).dMax = dMax
        If (Flag = ItemListFlags.ifIndex) Or (LCase(szCaption) = "index") Then
            mlIndexCol = lX
            Flag = ItemListFlags.ifIndex
        End If

        With mdgvList  ' Private mdgvList As DataGridView
            Dim colX As New DataGridViewTextBoxColumn With { _
                .HeaderText = szCaption, _
                .SortMode = DataGridViewColumnSortMode.Programmatic _
            }
            .Columns.Add(colX)

            If Flag = ItemListFlags.ifIndex Then
                Dim csX As DataGridViewCellStyle = mdgvList.DefaultCellStyle.Clone
                colX.ValueType = GetType(Integer)
                'csX.SelectionBackColor = Color.Transparent
                'csX.SelectionForeColor = Color.Blue

                colX.DefaultCellStyle = csX
                colX.Frozen = True
                colX.DividerWidth = 1 'thick border
                colX.CellTemplate.Style.Font = New Font(csX.Font, FontStyle.Bold) ' das geht aber nur bei create, nicht bei load und append
                'mdgvList.Columns(mlIndexCol).CellTemplate.Style.Font = New Font(Control.DefaultFont, FontStyle.Bold)
            Else
                colX.ValueType = GetType(String)
            End If

            'If Not gblnRemoteClientConnected Then SetOptimalColWidth() ' removed to improve performance??
        End With
    End Sub

    ''' <summary>
    ''' Stamp the current item as "processed without errors". 
    ''' </summary>
    ''' <param name="szStamp">Stamp for the first column with this string. If omited, szStamp=" *"</param>
    ''' <remarks>This function is for backwards compatibility only. It has been used to show which item is currently being processed.
    ''' Now use <see cref="clsItemList.ItemStatus"/>
    ''' to set the status of the item like fresh, processing or processed.
    ''' The item list will be scrolled to ensure the stamped item to be visible for the user.
    ''' Current implementation inserts the szStamp after the content of the first column.</remarks>
    Friend Sub ItemStamp(Optional ByVal szStamp As String = "*")
        If szStamp = "*" Then Me.ItemStatus(Me.ItemIndex) = Status.Processing : Return
        If Len(szStamp) = 0 Then Me.ItemStatus(Me.ItemIndex) = Status.Fresh : Return
        If szStamp = "*ignored" Then Me.ItemStatus(Me.ItemIndex) = Status.Ignored : Return
        Me.ItemStatus(Me.ItemIndex, szStamp) = Status.FinishedError : Return
    End Sub

    ''' <summary>
    ''' Notify Framework about processing of next item in experiment.
    ''' </summary>
    ''' <param name="sProgress">Optional value of the progress bar in percent [0...100]. The progress bars (in experiment and main screens) will be set only if the progress bar is not synced to the break.</param>
    ''' <returns>TRUE if the last item of the experiment hase been processed. FALSE if there are any items left.</returns>
    ''' <remarks>NextItem increases the item index and provides all functionality which depends on increasing item as breaks, beeps, logging. Call NextItem to set the next item to stimulate.
    ''' NextItem returns TRUE if the end of experiment was reached and FALSE otherwise.
    ''' NextItem will process following tasks:
    ''' <li>Handle beeps</li>
    ''' <li>Update labels</li>
    ''' <li>Induce a break, if necessary. In this case NextItem will terminate after the break is done (or Cancel ocurs).</li>
    ''' </remarks>
    Friend Function NextItem(Optional ByVal sProgress As Single = -1) As Boolean
        Return frmMain.NextItem(0, sProgress)
    End Function

    ''' <summary>
    ''' Notify Framework about processing of next item in experiment.
    ''' </summary>
    ''' <param name="lNrInterleaved">Number of interleaved items in experiment.</param>
    ''' <param name="sProgress">Optional value of the progress bar in percent [0...100]. The progress bars (in experiment and main screens) will be set only if the progress bar is not synced to the break.</param>
    ''' <returns>TRUE if the last item of the experiment hase been processed. FALSE if there are any items left.</returns>
    ''' <remarks>NextItem returns the next item index within the interleaved range and provides all functionality which depends on increasing item as breaks, beeps, logging.
    ''' NextItem returns TRUE if the end of experiment was reached and FALSE otherwise.
    ''' NextItem will process following tasks:
    ''' <li>Handle beeps</li>
    ''' <li>Update labels</li>
    ''' <li>Induce a break, if necessary. In this case NextItem will terminate after the break is done (or Cancel ocurs).</li>
    ''' </remarks>
    Friend Function NextItem(ByVal lNrInterleaved As Integer, Optional ByVal sProgress As Single = -1) As Boolean
        Return frmMain.NextItem(lNrInterleaved, sProgress)
    End Function


    ' General - Functions
    ' -------------------

    ''' <summary>
    ''' Load an item list from a CSV file.
    ''' </summary>
    ''' <param name="szFile">File name of the Item list.</param>
    ''' <param name="pbStatus">Progress bar status.</param>
    ''' <returns>Error message. Empty if no errors.</returns>
    ''' <remarks>The number of columns and the captions will be compared between the loaded and defined item list and warnings will be displayed in case of mismatch.</remarks>
    Friend Function Load(ByVal szFile As String, Optional ByVal pbStatus As ProgressBar = Nothing) As String
        Dim szErr As String

        Dim csvX As New CSVParser
        Dim dgvTemp As New DataGridView

        szErr = csvX.ReadDGV(szFile, dgvTemp, pbStatus)

        If Len(szErr) <> 0 Then Return "List not loaded." & vbCrLf & "Error: " & szErr
        If dgvTemp Is Nothing Then Return "List is empty."
        ' check the number of columns
        If dgvTemp.ColumnCount <> GetUboundCol(micData) + 1 Then _
                Return "Wrong number of columns: " & TStr(dgvTemp.ColumnCount) & _
                        vbCrLf & "This item list is invalid."

        ' check the columns header
        szErr = ""
        For Each colX As DataGridViewColumn In dgvTemp.Columns
            If colX.HeaderText <> (micData(colX.Index).szCaption) Then _
                szErr = szErr & "Column " & TStr(colX.Index) & _
                                ": Required: " & micData(colX.Index).szCaption & _
                                "; Loaded: " & colX.HeaderText & vbCrLf

        Next
        If Len(szErr) <> 0 Then
            If MsgBox("Following column header don't match: " & vbCrLf _
                    & szErr & vbCrLf & vbCrLf & _
                    "The item list is invalid and will yield limited functionality." & vbCrLf & vbCrLf _
                    & "Proceed anyway?", _
                    MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Return ""
        End If

        ' Copy to the real list
        CopyDataGridView(dgvTemp, mdgvList)

        'System.Windows.Forms.Application.DoEvents()
        ' Disable automatic row resizing
        mdgvList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None

        ' decode status
        If mlIndexCol > -1 Then
            For lX As Integer = 0 To mdgvList.RowCount - 1
                Dim szX As String = CType(mdgvList.Item(mlIndexCol, lX).Value, String)
                Dim lIdx As Integer = InStr(szX, "*")
                If lIdx > 0 Then
                    ' status found -> decode and set
                    Select Case Trim(Mid(szX, lIdx))
                        Case "*"
                            Me.ItemStatus(lX) = Status.FinishedOK
                            mdgvList.Item(mlIndexCol, lX).Value = Trim(Strings.Left(szX, lIdx - 1))
                        Case "*processing"
                            Me.ItemStatus(lX) = Status.Processing
                            mdgvList.Item(mlIndexCol, lX).Value = Trim(Strings.Left(szX, lIdx - 1))
                        Case "*error"
                            Me.ItemStatus(lX) = Status.FinishedError
                            mdgvList.Item(mlIndexCol, lX).Value = Trim(Strings.Left(szX, lIdx - 1))
                        Case "*ignored"
                            Me.ItemStatus(lX) = Status.Ignored
                            mdgvList.Item(mlIndexCol, lX).Value = Trim(Strings.Left(szX, lIdx - 1))
                    End Select
                Else
                    ' no status -> set to fresh
                    Me.ItemStatus(lX) = Status.Fresh
                    mdgvList.Item(mlIndexCol, lX).Value = Trim(szX)
                End If
                'frmMain.SetProgressbar(lX / (mdgvList.RowCount - 1))
                mdgvList.Item(mlIndexCol, lX).Style.Font = New Font(Control.DefaultFont, FontStyle.Bold) ' Index: bold
            Next
        End If

        If Not IsNothing(pbStatus) Then pbStatus.Value = 0

        'mdgvList.AutoResizeColumns()
        'SetOptimalColWidth()
        mdgvList.Enabled = True
        mdgvList.CurrentCell = mdgvList.Rows(0).Cells(0)
        Return ""

    End Function

    ''' <summary>
    ''' Save an item list to a CSV file.
    ''' </summary>
    ''' <param name="szFile">File name of the Item list.</param>
    ''' <param name="pbStatus">Progress bar status.</param>
    ''' <returns>Error message. Empty if no errors.</returns>
    ''' <remarks>Error message will be displayed in case of write errors.</remarks>
    Friend Function Save(ByVal szFile As String, Optional ByVal pbStatus As ProgressBar = Nothing) As String

        Dim dgvTemp As New DataGridView
        CopyDataGridView(mdgvList, dgvTemp)

        ' encode status
        If mlIndexCol > -1 Then
            For lX As Integer = 0 To mdgvList.RowCount - 1
                Dim szX As String = CType(mdgvList.Item(mlIndexCol, lX).Value, String)
                Dim stX As Status = ItemStatus(lX)
                Select Case stX
                    Case Status.Fresh
                        dgvTemp.Item(mlIndexCol, lX).Value = Replace(szX, "*", "")
                    Case Status.FinishedOK
                        dgvTemp.Item(mlIndexCol, lX).Value = szX & " *"
                    Case Status.Processing
                        dgvTemp.Item(mlIndexCol, lX).Value = szX & " *processing"
                    Case Status.FinishedError
                        dgvTemp.Item(mlIndexCol, lX).Value = szX & " *error"
                    Case Status.Ignored
                        dgvTemp.Item(mlIndexCol, lX).Value = szX & " *ignored"
                End Select
            Next
        End If

        ' save the list
        Dim csvX As New CSVParser
        Dim szErr As String = csvX.WriteDGV(szFile, dgvTemp, pbStatus)
        If Len(szErr) = 0 AndAlso Not IsNothing(pbStatus) Then pbStatus.Value = 0
        Return szErr

    End Function


    ''' <summary>
    ''' Append a CSV file to the existing item list.
    ''' </summary>
    ''' <param name="szFile">File name.</param>
    ''' <param name="pbStatus">Progress bar status</param>
    ''' <returns>Error message. Empty if no errors.</returns>
    ''' <remarks>The number of columns and the captions will be compared between the loaded and defined item list and warnings will be displayed in case of mismatch.</remarks>
    Friend Function Append(ByVal szFile As String, Optional ByVal pbStatus As ProgressBar = Nothing) As String

        Dim csvX As New CSVParser
        Dim dgvTemp As New DataGridView
        Dim szErr As String = csvX.ReadDGV(szFile, dgvTemp, pbStatus)

        If Len(szErr) <> 0 Then Return "Error loading the file." & vbCrLf & "Error: " & szErr
        If dgvTemp Is Nothing Then Return "List is empty."

        ' check the number of columns
        If dgvTemp.ColumnCount <> GetUboundCol(micData) + 1 Then _
            Return "Wrong number of columns: " & TStr(dgvTemp.ColumnCount) & vbCrLf & _
                    "Appending cancelled."
        ' check the columns header
        szErr = ""
        For Each colX As DataGridViewColumn In dgvTemp.Columns
            If colX.HeaderText <> (micData(colX.Index).szCaption) Then
                szErr = szErr & "Column " & TStr(colX.Index) & _
                                ": Required: " & micData(colX.Index).szCaption & _
                                "; Loaded: " & colX.HeaderText & vbCrLf
            End If
        Next
        If Len(szErr) <> 0 Then
            If MsgBox("Following column header don't match: " & vbCrLf _
                    & szErr & vbCrLf & vbCrLf & _
                    "The item list is invalid and will yield limited functionality." & vbCrLf & vbCrLf _
                    & "Proceed anyway?", _
                    MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Return ""
        End If

        Dim lLast As Integer = mdgvList.RowCount
        ' Copy to the real list
        CopyDataGridView(dgvTemp, mdgvList, 0, dgvTemp.RowCount - 1, mdgvList.RowCount)

        'System.Windows.Forms.Application.DoEvents()
        ' Disable automatic row resizing
        mdgvList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None

        ' decode status
        If mlIndexCol > -1 Then
            For lX As Integer = lLast To mdgvList.RowCount - 1
                Dim szX As String = CType(mdgvList.Item(mlIndexCol, lX).Value, String)
                Dim lIdx As Integer = InStr(szX, "*")
                If lIdx > 0 Then
                    ' status found -> decode and set
                    Select Case Trim(Mid(szX, lIdx))
                        Case "*"
                            Me.ItemStatus(lX) = Status.FinishedOK
                            mdgvList.Item(mlIndexCol, lX).Value = Trim(Strings.Left(szX, lIdx - 1))
                        Case "*processing"
                            Me.ItemStatus(lX) = Status.Processing
                            mdgvList.Item(mlIndexCol, lX).Value = Trim(Strings.Left(szX, lIdx - 1))
                        Case "*error"
                            Me.ItemStatus(lX) = Status.FinishedError
                            mdgvList.Item(mlIndexCol, lX).Value = Trim(Strings.Left(szX, lIdx - 1))
                        Case "*ignored"
                            Me.ItemStatus(lX) = Status.Ignored
                            mdgvList.Item(mlIndexCol, lX).Value = Trim(Strings.Left(szX, lIdx - 1))
                    End Select
                Else
                    ' no status -> set to fresh
                    Me.ItemStatus(lX) = Status.Fresh
                    mdgvList.Item(mlIndexCol, lX).Value = Trim(szX)
                End If
                mdgvList.Item(mlIndexCol, lX).Style.Font = New Font(Control.DefaultFont, FontStyle.Bold) ' Index: bold
            Next
            'For lY As Integer = 0 To ItemList.ItemCount - 1
            'mdgvList.Item(mlIndexCol, lY).Style.Font = New Font(Control.DefaultFont, FontStyle.Bold) ' Index: bold
            'Next
        End If

        If Not IsNothing(pbStatus) Then pbStatus.Value = 0
        mdgvList.Enabled = True
        'mdgvList.AutoResizeColumns()
        'mdgvList.CurrentCell = mdgvList.Rows(mdgvList.RowCount - 1).Cells(0)
        'mdgvList.Rows(mdgvList.RowCount - 1).Selected = True
        'SetOptimalColWidth()
        'mdgvList.CurrentCell = mdgvList.Rows(0).Cells(0)
        Return ""
    End Function


    ''' <summary>
    ''' Shuffle items.
    ''' </summary>
    ''' <param name="lBeg">Shuffle from item index... (range).</param>
    ''' <param name="lEnd">Shuffle to item index... (end of range).</param>
    ''' <returns></returns>
    ''' <remarks>Shuffle all items from lBeg to lEnd.</remarks>
    Friend Function ShuffleItems(ByVal lBeg As Integer, ByVal lEnd As Integer) As String
        If lEnd = lBeg Then Return ""
        If lBeg > lEnd Then Dim lZ As Integer = lBeg : lBeg = lEnd : lEnd = lZ
        If lBeg < 0 Then Return "Itemlist.ShuffleItems: Negative Begin not allowed"
        If lEnd >= Me.ItemCount Then Return "Itemlist.ShuffleItems: End exceeds the item count"
        Dim lArr(lEnd - lBeg) As Integer
        For lX As Integer = lBeg To lEnd
            lArr(lX - lBeg) = lX
        Next
        Me.ShuffleItems(lArr)
        Return ""
    End Function
    ''' <summary>
    ''' Shuffle items.
    ''' </summary>
    ''' <param name="lIdx">Array with indicies of items to shuffle.</param>
    ''' <remarks>Items with the indecies given in the array lIdx.</remarks>
    Friend Sub ShuffleItems(ByVal lIdx() As Integer)

        If lIdx Is Nothing Then Console.WriteLine("Itemlist.ShuffleItems: Array empty.") : Return
        If lIdx.Length = 1 Then Return ' nothing to shuffle

        With mdgvList

            Dim ColMode As DataGridViewAutoSizeColumnMode = DirectCast(.AutoSizeColumnsMode, DataGridViewAutoSizeColumnMode)
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            Dim RowMode As DataGridViewAutoSizeRowMode = DirectCast(.AutoSizeRowsMode, DataGridViewAutoSizeRowMode)
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None

            ' generate an array with random numbers
            Dim lItemNr As Integer = lIdx.Length
            Dim sRnd(lItemNr - 1) As Single
            For lX As Integer = 0 To lItemNr - 1
                sRnd(lX) = Rnd()
            Next
            ' sort the item list (quick sort)
            For lX As Integer = 0 To lItemNr - 2 ' discard last item
                Dim sMin As Single = 1.0
                Dim lMin As Integer = lX
                For lY As Integer = lX To lItemNr - 1 ' find index of minimum value
                    If sRnd(lY) < sMin Then sMin = sRnd(lY) : lMin = lY
                Next
                Dim lA As Integer = lIdx(lX)
                Dim lB As Integer = lIdx(lMin)
                If lA > lB Then lA = lIdx(lMin) : lB = lIdx(lX)
                If lA <> lB Then
                    .Rows.InsertCopy(lA, lB + 1)
                    Proc.CopyDataGridRow(.Rows(lA), .Rows(lB + 1))
                    .Rows.RemoveAt(lA)
                    If lB - 1 > lA Then
                        .Rows.InsertCopy(lB - 1, lA)
                        Proc.CopyDataGridRow(.Rows(lB), .Rows(lA))
                        .Rows.RemoveAt(lB)
                    End If
                End If
                sRnd(lMin) = sRnd(lX)
                sRnd(lX) = sMin
            Next

            .AutoSizeColumnsMode = DirectCast(ColMode, DataGridViewAutoSizeColumnsMode)
            .AutoSizeRowsMode = DirectCast(RowMode, DataGridViewAutoSizeRowsMode)

            'select the same rows as before
            For lX As Integer = 0 To lIdx.Length - 1
                '.CurrentCell = .Rows(lIdx(lX)).Cells(0)
                .Rows(lIdx(lX)).Selected = True
            Next

        End With

    End Sub


    ''' <summary>
    ''' Clears a defined item list.
    ''' </summary>
    ''' <remarks>All items in the item list will be removed, all columns set to their default.
    ''' The definitions of columns remain unchanged. Reset must have been called before executing Clear.</remarks>
    Friend Sub Clear()

        If GetUboundCol(micData) = -1 Then Return

        mdgvList.RowCount = 0
        mdgvList.Enabled = False

        SetOptimalColWidth()
    End Sub

    ''' <summary>
    ''' Selected items.
    ''' </summary>
    ''' <returns>Number of selected items.</returns>
    Friend ReadOnly Property SelectedItems() As Integer()
        Get
            If mdgvList.SelectedCells.Count < 1 Then Return Nothing
            For Each cell As DataGridViewCell In mdgvList.SelectedCells
                mdgvList.Rows(cell.RowIndex).Selected = True
            Next
            Dim lIdx() As Integer
            ReDim lIdx(mdgvList.SelectedRows.Count - 1)
            Dim lX As Integer = 0
            For Each rowX As DataGridViewRow In mdgvList.SelectedRows
                lIdx(lX) = rowX.Index
                lX += 1
            Next
            Array.Sort(lIdx)
            Return lIdx
        End Get
    End Property

    ''' <summary>
    ''' Reset item list to a new, not defined one.
    ''' </summary>
    ''' <remarks>The item list will be initialized to an undefined one. All column definitions, all items will be removed. No item list will available after Reset, thus call AddCol immediatly after Reset.</remarks>
    Friend Sub Reset()

        Erase micData
        With mdgvList
            .ColumnCount = 0
            .RowCount = 0
            .Enabled = False
        End With
        mlIndexCol = -1
    End Sub

    ''' <summary>
    ''' Sort Itemlist.
    ''' </summary>
    ''' <param name="Col">Column to sort.</param>
    ''' <param name="Mode">Sort direction: ascending or descending.</param>
    Friend Sub Sort(ByVal Col As DataGridViewColumn, ByVal Mode As System.ComponentModel.ListSortDirection)
        mdgvList.Sort(Col, Mode)
    End Sub

    ''' <summary>
    ''' Sets the optimal column width for displaying the item list.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub SetOptimalColWidth()
        'Dim SetOptimalColWidthTemp As DataGridViewAutoSizeRowsMode = frmMain.dgvItemList.AutoSizeRowsMode ' Copy current status
        Dim start_time As DateTime = Now
        If gblnDisableSetOptimalColWidth = False Then ' Global variable
            Dim lX, lMaxWidth, lWidestWidth As Integer
            Dim bResized As Boolean = False
             
            Console.WriteLine("###  RESIZE  ###")

            Console.WriteLine("#1 Resizing Rows:    " & Now.Subtract(start_time).TotalSeconds.ToString("0.000") & " s")
            start_time = Now

            With mdgvList ' Private mdgvList As DataGridView

                Console.WriteLine("#1a Resizing Rows:    " & Now.Subtract(start_time).TotalSeconds.ToString("0.000") & " s")
                start_time = Now
                
                '.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None ' First disable automatic row resizing
                'Windows.Forms.Application.DoEvents()
                .AutoResizeColumns()

                Console.WriteLine("#1b Resizing Rows:    " & Now.Subtract(start_time).TotalSeconds.ToString("0.000") & " s")
                start_time = Now

                '.AutoResizeColumns() ' then resize columns
                'Windows.Forms.Application.DoEvents()
                Console.WriteLine("#2 Resizing Rows:    " & Now.Subtract(start_time).TotalSeconds.ToString("0.000") & " s")
                start_time = Now

                Dim sTotalwidth As Single = 0 ' maybe resizing not necessary!? Calculate sum of all col's widths
                For lX = 0 To .ColumnCount - 1
                    sTotalwidth += .Columns(lX).Width
                    lWidestWidth = Math.Max(lWidestWidth,.Columns(lX).Width)
                Next
                Console.WriteLine("#3 Resizing Rows:    " & Now.Subtract(start_time).TotalSeconds.ToString("0.000") & " s")
                start_time = Now

                If sTotalwidth + 40 > .Width Then ' resizing necessary?
                    If lWidestWidth > CInt(.Width / 2) then ' one column has more than half the total width
                        lMaxWidth = CInt(.Width - sTotalwidth + lWidestWidth - 30) '  CInt(.Width / 2)
                    Else
                        lMaxWidth = CInt(.Width / 3) ' colums too wide??? max width = total visible width / 3
                    End If
                    
                    For lX = 0 To .ColumnCount - 1
                        If .Columns(lX).Width > lMaxWidth Then ' If width > max width then...
                            .Columns(lX).Width = lMaxWidth ' ...reduce width to max width
                            'Windows.Forms.Application.DoEvents()
                            Console.WriteLine("Col " & TStr(lX) & " -> width reduced")
                            bResized = True
                        End If
                    Next
                End If
                Console.WriteLine("#4 Resizing Rows:    " & Now.Subtract(start_time).TotalSeconds.ToString("0.000") & " s")
                start_time = Now
                
                '.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells ' enable automatic row resizing
                Console.WriteLine("#5 Resizing Rows:    " & Now.Subtract(start_time).TotalSeconds.ToString("0.000") & " s")
                start_time = Now

                'Windows.Forms.Application.DoEvents()
                If bResized And gblnExperiment Then ItemList.ItemIndex = ItemList.ItemIndex 'scroll to current position
                Console.WriteLine("#6 Resizing Rows:    " & Now.Subtract(start_time).TotalSeconds.ToString("0.000") & " s")
                start_time = Now
                'Windows.Forms.Application.DoEvents()
            End With
        End If
        
        Console.WriteLine("#9 Resizing Rows:    " & Now.Subtract(start_time).TotalSeconds.ToString("0.000") & " s")
        'frmMain.dgvItemList.AutoSizeRowsMode = SetOptimalColWidthTemp ' Set global variable back to old status
        'Windows.Forms.Application.DoEvents()
    End Sub

    ''' <summary>
    ''' Check the content of an item for a valid value according to defined flags of the column.
    ''' </summary>
    ''' <param name="Col">Column selector. String for selection by caption or Long for selection by index.</param>
    ''' <param name="szX">Value which will be checked against the restrictions. If the value should be a numeric one, it will be converted to double and back to string.</param>
    ''' <returns>Error message. Empty if szX suits the restrictions.</returns>
    ''' <remarks>By using CheckItem, the content of an item can be checked before writing to the item list.
    ''' CheckItem checks szX according to rules set by flags for given column Col and results in a string containing an error message. If the content szX is correct, CheckItem results in an empty string.</remarks>
    Friend Function CheckItem(ByVal Col As Integer, ByRef szX As String) As String
        Dim lCol, lX As Integer
        Dim Flags As ItemListFlags
        Dim lY As Integer
        Dim szName, szErr As String
        Dim szChar As String = ""
        Dim szArr() As String
        Dim szT, szNew As String

        lCol = Col
        If lCol > GetUboundCol(micData) Then Err.Raise(vbObjectError, "Itemlist: CheckItem", "Column out of bounds")

        Flags = micData(lCol).Flags
        szName = micData(lCol).szCaption
        szErr = ""

        Select Case (Flags And ItemListFlags.ifFlagTypeMask)
            Case ItemListFlags.ifNumeric
                If CBool(Flags And ItemListFlags.ifVectorized) Then
                    If InStr(1, szX, " ") > 0 Then szChar = " "
                    If InStr(1, szX, ";") > 0 Then szChar = ";"
                    If Len(szChar) > 0 Then
                        ' vector found
                        szArr = Split(szX, szChar)
                        szNew = ""
                        For lX = 0 To GetUbound(szArr)
                            szT = szArr(lX)
                            If Len(szT) > 0 Then
                                szErr &= CheckNumeric(szT, lCol)
                                If Len(szErr) = 0 Then szNew = szNew + szChar + szT
                            End If
                        Next
                        If Len(szNew) > 0 Then szX = Mid(szNew, 2)
                    Else
                        ' scalar found
                        szErr = CheckNumeric(szX, lCol)
                    End If
                Else
                    szErr = CheckNumeric(szX, lCol)
                End If

            Case ItemListFlags.ifElectrodeL, ItemListFlags.ifElectrodeR
                If CBool(Flags And ItemListFlags.ifVectorized) Then
                    If InStr(1, szX, " ") > 0 Then szChar = " "
                    If InStr(1, szX, ";") > 0 Then szChar = ";"
                    If Len(szChar) > 0 Then
                        ' vector found
                        szArr = Split(szX, szChar)
                        szNew = ""
                        For lX = 0 To GetUbound(szArr)
                            szT = szArr(lX)
                            If Len(szT) > 0 Then
                                szErr &= CheckElectrode(szT, lCol)
                                If Len(szErr) = 0 Then szNew = szNew + szChar + szT
                            End If
                        Next
                        If Len(szNew) > 0 Then szX = Mid(szNew, 2)
                    Else
                        ' scalar found
                        szErr = CheckElectrode(szX, lCol)
                        If Len(szErr) = 0 Then szX = TStr(Val(szX))
                    End If
                Else
                    szErr = CheckElectrode(szX, lCol)
                    If Len(szErr) = 0 Then szX = TStr(Val(szX))
                End If


            Case ItemListFlags.ifFileName ' file name
            Case ItemListFlags.ifDirectory ' directory
            Case ItemListFlags.ifString ' string
                If (Flags And ItemListFlags.ifNonEmpty) > 0 And Len(szX) = 0 Then szErr = szErr & "Empty values not allowed" & vbCrLf
                If CBool(Flags And ItemListFlags.ifEnumeration) Then
                    If CBool(Flags And ItemListFlags.ifCaseSensitive) Then
                        szArr = Split(micData(lCol).szUnit, ";")
                        For lY = 0 To UBound(szArr)
                            If szX = szArr(lY) Then Exit For
                        Next
                        If lY > UBound(szArr) Then szErr = szErr & "Allowed values (case sensitive!): " & micData(lCol).szUnit & vbCrLf
                    Else
                        szArr = Split(micData(lCol).szUnit, ";")
                        For lY = 0 To UBound(szArr)
                            If LCase(szX) = LCase(szArr(lY)) Then Exit For
                        Next
                        If lY > UBound(szArr) Then szErr = szErr & "Allowed values: " & micData(lCol).szUnit & vbCrLf
                    End If
                End If
                If CBool(Flags And ItemListFlags.ifUpperCase) Then szX = UCase(szX)
                If CBool(Flags And ItemListFlags.ifLowerCase) Then szX = LCase(szX)
        End Select

        Return szErr

    End Function

    ''' <summary>
    ''' Check if value (szX) is a valid data type for column Col.
    ''' </summary>
    ''' <param name="Col">Column name as string.</param>
    ''' <param name="szX">Value to check.</param>
    ''' <returns>Error message if data is not valid.</returns>
    Friend Function CheckItem(ByVal Col As String, ByVal szX As String) As String
        Dim lCol As Integer
        Dim szCol As String

        szCol = LCase(CStr(Col))
        For lCol = 0 To GetUboundCol(micData)
            If LCase(micData(lCol).szCaption) = szCol Then Exit For
        Next
        If lCol > GetUboundCol(micData) Then Err.Raise(vbObjectError, "Itemlist: CheckItem", "Column described by " & szCol & " couldn't be found.")

        Return CheckItem(lCol, szX)

    End Function

    ''' <summary>
    '''  Get/Set the item status.
    ''' </summary>
    ''' <param name="lRow">Index of the item.</param>
    ''' <param name="szStamp"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ItemStatus(ByVal lRow As Integer, Optional ByVal szStamp As String = "") As Status
        Get 'GET item status
            If IsNothing(mdgvList) Then Err.Raise(vbObjectError, "Itemlist: ItemStatus", "Datagridview not defined")
            If lRow > mdgvList.RowCount Then Err.Raise(vbObjectError, "Itemlist: ItemStatus", "Row out of bounds")
            If mlIndexCol = -1 Then Return Status.Fresh
            Select Case Me.mdgvList.Item(mlIndexCol, lRow).Style.BackColor
                Case Color.Empty
                    Return Status.Fresh
                Case Color.Yellow
                    Return Status.Processing
                Case Color.Green
                    Return Status.FinishedOK
                Case Color.Red
                    Return Status.FinishedError
                Case Color.DarkGray
                    Return Status.Ignored
            End Select
            Return Nothing
        End Get

        Set(ByVal Value As Status)
            If IsNothing(mdgvList) Then Err.Raise(vbObjectError, "Itemlist: ItemStatus", "Datagridview not defined")
            If lRow > mdgvList.RowCount Then Err.Raise(vbObjectError, "Itemlist: ItemStatus", "Row out of bounds")

            'Console.WriteLine("STATUS ITEM " & lRow & " -> " & Value)
            Select Case Value 'set new index flag

                Case Status.Fresh
                    If mlIndexCol = -1 Then Return
                    Me.mdgvList.Item(mlIndexCol, lRow).Style.BackColor = Color.Empty
                    Me.mdgvList.Item(mlIndexCol, lRow).ErrorText = ""
                Case Status.Processing
                    If mlIndexCol = -1 Then Return
                    Me.mdgvList.Item(mlIndexCol, lRow).Style.BackColor = Color.Yellow
                    Me.mdgvList.Item(mlIndexCol, lRow).ErrorText = ""
                Case Status.FinishedOK
                    If mlIndexCol = -1 Then Return
                    Me.mdgvList.Item(mlIndexCol, lRow).Style.BackColor = Color.Green
                    Me.mdgvList.Item(mlIndexCol, lRow).ErrorText = ""
                Case Status.FinishedError
                    'If gblnExperiment And glFlagBeepExp > 0 Then BeepOnError()
                    If gblnExperiment And gblnPlayWaveExp = True Then PlayWaveOnError()
                    frmMain.ServeData(FWintern.ServeDataEnum.ErrorInExperiment)
                    If mlIndexCol = -1 Then Return
                    Me.mdgvList.Item(mlIndexCol, lRow).Style.BackColor = Color.Red
                    Me.mdgvList.Item(mlIndexCol, lRow).ErrorText = szStamp
                Case Status.Ignored
                    If mlIndexCol = -1 Then Return
                    Me.mdgvList.Item(mlIndexCol, lRow).Style.BackColor = Color.DarkGray
                    Me.mdgvList.Item(mlIndexCol, lRow).ErrorText = ""
            End Select
            If gblnRemoteServerConnected And gblnExperiment Then frmMain.ServeData(FWintern.ServeDataEnum.ChangeItemStatus, lRow)
        End Set
    End Property

    Private Function CheckNumeric(ByRef szX As String, ByVal lCol As Integer) As String
        Dim Flags As ItemListFlags
        Dim szErr, szName As String
        Dim dblX As Double

        Flags = micData(lCol).Flags
        szName = micData(lCol).szCaption
        szErr = ""

        ' numeric values
        If Not IsNumeric(szX) Then Return szErr & szName & " must be numeric." & vbCrLf
        dblX = Val(szX)
        If CBool(Flags And ItemListFlags.ifInteger) Then dblX = Math.Round(dblX)
        If (Flags And ItemListFlags.ifNonZero) > 0 And (dblX = 0) Then szErr = szErr & szName & " equal 0 not allowed." & vbCrLf
        If (Flags And ItemListFlags.ifMin) > 0 And (dblX < micData(lCol).dMin) Then szErr = szErr & szName & " below " & TStr(micData(lCol).dMin) & " not allowed." & vbCrLf
        If (Flags And ItemListFlags.ifMax) > 0 And (dblX > micData(lCol).dMax) Then szErr = szErr & szName & " greater than " & TStr(micData(lCol).dMax) & " not allowed." & vbCrLf
        If CBool(Flags And ItemListFlags.ifMinTimeDelay) Then
            dblX = Math.Round(dblX)
            If dblX < 0 Then szErr = szErr & szName & " must be a positive time delay" & vbCrLf
        End If
        szX = TStr(dblX)
        Return szErr

    End Function

    Private Function CheckElectrode(ByVal varX As String, ByVal lCol As Integer) As String
        Dim Flags As ItemListFlags
        Dim szName As String
        'dim szCh As String
        Dim lY, lEl As Integer
        'Dim lCh As String

        Flags = micData(lCol).Flags
        szName = micData(lCol).szCaption

        If Not IsNumeric(varX) Then Return szName & " must be numeric." & vbCrLf

        ' determine electrode and side
        If (Flags And ItemListFlags.ifFlagTypeMask) = ItemListFlags.ifElectrodeL Then
            lY = GetUbound(gfreqParL) + 1
        ElseIf (Flags And ItemListFlags.ifFlagTypeMask) = ItemListFlags.ifElectrodeR Then
            lY = GetUbound(gfreqParR) + 1
        Else
            Err.Raise(0, "ItemList: CheckElectrode", "Flags not set to Electrode")
        End If

        ' check for valid index
        lEl = CInt(Math.Round(Val(varX)))

        ' check if defined
        If lEl > lY Or lEl < 1 Then Return szName & " #" & TStr(lEl) & " not defined in the Settings" & vbCrLf

        ' check for min/max
        If (Flags And ItemListFlags.ifMin) > 0 And (lEl < micData(lCol).dMin) Then _
                Return szName & ": values below " & TStr(micData(lCol).dMin) & " not allowed." & vbCrLf
        If (Flags And ItemListFlags.ifMax) > 0 And (lEl > micData(lCol).dMax) Then _
                Return szName & ": values greater than " & TStr(micData(lCol).dMax) & " not allowed." & vbCrLf

        Return ""
    End Function


    Private Function GetUboundCol(ByVal micX() As ItemColumn) As Integer
        If IsNothing(micX) Then Return -1
        Return micX.Length - 1
    End Function

    ''' <summary>
    ''' New instance of DataGridView.
    ''' </summary>
    ''' <param name="dgvList">DataGridView.</param>
    ''' <remarks>Used in Framework to create item list and create result list.</remarks>
    Friend Sub New(ByVal dgvList As DataGridView)
        mdgvList = dgvList
        Erase micData
        mdgvList.Rows.Clear()
        mdgvList.Columns.Clear()
        mdgvList.Enabled = False
        mlIndexCol = -1
    End Sub
    
    ''' <summary>
    ''' Set/get directory where result list is stored. This value will overwrite default folder (eg. Settings file location).
    ''' </summary>
    ''' <returns>Set/get directory.</returns>
    ''' <remarks>If value is empty the directory of last Save/Load dialogue is the initial directory.</remarks>
    ''' <example>frmX.ResultList.Directory=DataDirectory.Path(0)</example>
    Friend Property Directory() As String
        Set(ByVal szValue As String)
            mszDirectory=szValue
        End Set

        Get
            Return mszDirectory
        End Get
    End Property
End Class