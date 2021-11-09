Option Strict Off
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
' results form, used to present results as tables
''' <summary>
''' FrameWork Module. Implementation of the Result form.
''' </summary>
''' <remarks>This form can be multiply created and used to show results in form of a grid or table.
''' The functionality such as sorting, copy to clipboard, ploting and saving is provided.</remarks>
Friend Class frmResult
    Inherits System.Windows.Forms.Form

    Private ReadOnly IsInitializing As Boolean
    Private mlPlotY, mlPlotX, mlPlotZ As Integer
    Public ResultList As clsItemList
    Private mszPostFix As String
    'Public ResultsDirectory As String

    Private Sub DisableButtons()
        Dim ctrX As System.Windows.Forms.Control
        For Each ctrX In Me.Controls
            If TypeOf ctrX Is System.Windows.Forms.Button Then ctrX.Enabled = False
            If TypeOf ctrX Is System.Windows.Forms.ComboBox Then ctrX.Enabled = False
        Next ctrX
    End Sub

    Private Sub EnableButtons()
        Dim ctrX As System.Windows.Forms.Control
        For Each ctrX In Me.Controls
            If TypeOf ctrX Is System.Windows.Forms.Button Then ctrX.Enabled = True
            If TypeOf ctrX Is System.Windows.Forms.ComboBox Then ctrX.Enabled = True
        Next ctrX

    End Sub

    Private Sub InitAxes()
        cmbSetAxis.Items.Clear()
        cmbSetAxis.Items.Add("X axis")
        cmbSetAxis.Items.Add("Y axis")
        cmbSetAxis.Items.Add("Parameter")
        cmbSetAxis.SelectedIndex = 0
        mlPlotX = -1 : mlPlotY = -1 : mlPlotZ = -1
    End Sub

    Private Sub cmdAppend_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAppend.Click
        Dim szFile As String
        Dim szErr As String

        DisableButtons()

        ' get file name
        Dim dlgOpen As New OpenFileDialog With {  _
            .FileName = "",  _
            .Title = "Append a Result List to existing results",  _
            .InitialDirectory = ResultList.Directory, _
            .Filter = "Result List (*.rsl.csv)|*.rsl.csv|Result List - CSV File (*.csv)|*.csv|All Files (*.*)|*.*",  _
            .DefaultExt = "*.rsl.csv",  _
            .FilterIndex = 1,  _
            .SupportMultiDottedExtensions = True  _
        }
        If dlgOpen.ShowDialog() = Windows.Forms.DialogResult.OK Then
            szFile = dlgOpen.FileName

            ' load list to a temporary datagridview
            szErr = ResultList.Append(szFile, pbStatus)
            If Len(szErr) <> 0 Then MsgBox(szErr, MsgBoxStyle.Critical, "Append Result List")
        End If
        ItemList.SetOptimalColWidth()
        EnableButtons()

    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoad.Click
        Dim szFile As String
        Dim szErr As String

        DisableButtons()
        ' get file name
        Dim dlgOpen As New OpenFileDialog With {  _
            .FileName = "",  _
            .Title = "Load a Result List",  _
            .InitialDirectory = ResultList.Directory, _
            .Filter = "Result List (*.rsl.csv)|*.rsl.csv|Result List - CSV File (*.csv)|*.csv|All Files (*.*)|*.*",  _
            .FilterIndex = 1,  _
            .DefaultExt = "*.rsl.csv",  _
            .SupportMultiDottedExtensions = True  _
        }
        If dlgOpen.ShowDialog() = Windows.Forms.DialogResult.OK Then
            szFile = dlgOpen.FileName
            szErr = ResultList.Load(szFile, pbStatus)
            If Len(szErr) = 0 Then
                ResultList.SetOptimalColWidth()
                InitAxes()
                InitSort()
            Else
                MsgBox(szErr, MsgBoxStyle.Critical, "Load Result List")
            End If
        End If
        EnableButtons()

    End Sub

    Private Sub cmdPlotResults_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPlotResults.Click
        Dim lX As Integer
        Dim szX As String
        Dim szErr As String

        If mlPlotX < 1 Or mlPlotY < 1 Then
            MsgBox("Set X and Y axis before ploting", MsgBoxStyle.Information)
            Exit Sub
        End If

        If Not gblnUseMATLAB Or Not gblnOutputStable Then MsgBox("MATLAB not available") : Exit Sub

        With ResultList
            ' send xvec to matlab
            szX = "xvec=[" & .Item(0, mlPlotX)
            For lX = 1 To .ItemCount - 1
                szX = szX & "," & .Item(lX, mlPlotX)
            Next
            szErr = STIM.Matlab(szX & "];")
            If Len(szErr) > 0 Then GoTo SubError
            ' send yvec to matlab
            szX = "yvec=[" & .Item(0, mlPlotY)
            For lX = 1 To .ItemCount - 1
                szX = szX & "," & .Item(lX, mlPlotY)
            Next
            szErr = STIM.Matlab(szX & "];")
            If Len(szErr) > 0 Then GoTo SubError
            ' send zvec to matlab
            If mlPlotZ > 0 Then
                szX = "zvec={'" + .Item(0, mlPlotZ)
                For lX = 1 To .ItemCount - 1
                    szX = szX + "','" + .Item(lX, mlPlotZ)
                Next
                szX += "'};"
            Else
                szX = "zvec=[];"
            End If
            szErr = STIM.Matlab(szX)
            If Len(szErr) > 0 Then GoTo SubError
            ' plot results
            szX = ""
            If mlPlotZ > 0 Then szX = .ColCaption(mlPlotZ) ' .Item(0, mlPlotZ) 
            szErr = STIM.Matlab("FW_PlotResults(xvec,yvec,zvec,'" & My.Application.Info.AssemblyName & " - " & Me.Text & "','" & .ColCaption(mlPlotX) & "','" & .ColCaption(mlPlotY) & "','" & szX & "');")
            If Len(szErr) > 0 Then GoTo SubError
        End With
        Return
SubError:
        MsgBox(szErr, MsgBoxStyle.Critical, "Plot Results")
    End Sub

    Private Sub cmdRefreshIndex_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRefreshIndex.Click
        DisableButtons()
        ResultList.RenumberIndex()
        EnableButtons()
    End Sub

    Private Sub cmdSaveAs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSaveAs.Click
        Dim szFile As String
        Dim szErr As String

        DisableButtons()
        ' get file name
        Dim dlgSave As New SaveFileDialog
        If gblnUseFileNaming Then
            If InStrRev(gszSettingTitle, "." & My.Application.Info.AssemblyName) > 0 Then
                szFile = Mid(gszSettingTitle, 1, InStrRev(gszSettingTitle, "." & My.Application.Info.AssemblyName) - 1)
            ElseIf InStrRev(gszSettingTitle, ".esf") > 0 Then 'old file naming
                szFile = Mid(gszSettingTitle, 1, InStrRev(gszSettingTitle, ".esf") - 1)
            Else
                szFile = gszSettingTitle
            End If
            If Len(PostFix) > 0 Then szFile = szFile & "_" & PostFix
            GetNextFileVersion(szFile, ".rsl.csv")
            dlgSave.FileName = szFile
        Else
            dlgSave.FileName = ""
        End If
        dlgSave.SupportMultiDottedExtensions = True
        dlgSave.Title = "Save Result List As..."
        dlgSave.Filter = "Result List (*.rsl.csv)|*.rsl.csv|Result List - CSV File (*.csv)|*.csv|All Files (*.*)|*.*"
        dlgSave.FilterIndex = 1
        dlgSave.DefaultExt = "*.rsl.csv"
        dlgSave.OverwritePrompt = True
        dlgSave.InitialDirectory = ResultList.Directory
        If dlgSave.ShowDialog() = Windows.Forms.DialogResult.OK Then
            szFile = dlgSave.FileName
            ' save result list
            Dim csvX As New CSVParser
            szErr = csvX.WriteDGV(szFile, dgvResult)
            If Len(szErr) <> 0 Then
                MsgBox(szErr, MsgBoxStyle.Critical, "Save Result List")
            End If
        End If
        EnableButtons()

    End Sub

    Private Sub cmdSetAxis_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSetAxis.Click

        With ResultList
            If .SelectedColumnFirst < 0 Then Return
            Select Case cmbSetAxis.SelectedIndex
                Case 0 ' set X
                    mlPlotX = .SelectedColumnFirst
                    cmbSetAxis.Items(0) = "X axis: " & .ColCaption(.SelectedColumnFirst)
                Case 1 ' set y
                    mlPlotY = .SelectedColumnFirst
                    cmbSetAxis.Items(1) = "Y axis: " & .ColCaption(.SelectedColumnFirst)
                Case 2 ' set z
                    mlPlotZ = .SelectedColumnFirst
                    cmbSetAxis.Items(2) = "Parameter: " & .ColCaption(.SelectedColumnFirst)
            End Select
        End With

    End Sub

    Private Sub cmdSetOptimalWidth_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSetOptimalWidth.Click
        ResultList.SetOptimalColWidth()
    End Sub

    Private Sub InitSort()
        ' Fill combo box to choose sort column

        cmbSortCol.Items.Clear()

        With dgvResult
            For lX As Integer = 0 To .ColumnCount - 1
                cmbSortCol.Items.Add("Sort by: " & .Columns(lX).HeaderText)
            Next
        End With

        cmbSortCol.SelectedIndex = 0

    End Sub

    Private Sub cmdSort_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSort.Click
        'click on sort button calls SortColumn function

        DisableButtons()
        Dim SortCol As Integer = cmbSortCol.SelectedIndex

        Dim szErr As String = SortColumn(SortCol)
        If szErr <> Nothing Then MsgBox(szErr, MsgBoxStyle.Information, "Sort by " & dgvResult.Columns(SortCol).HeaderText)

        EnableButtons()
        cmdSort.Select()
    End Sub
    ''' <summary>
    ''' Sort results table by column index.
    ''' </summary>
    ''' <param name="SortCol">Numeric index of column to be sorted</param>
    ''' <param name="bReverseOrder">Optional, boolen, sort in reverse order</param>
    ''' <returns>Optional string if error appeared or if column contained non-numeric values (string) and is sorted by string order.</returns>
    ''' <remarks>Return value can be ignored, or displayed in a message box.</remarks>
    Public Function SortColumn(SortCol As Integer, Optional bReverseOrder As Boolean = False) As String

        With dgvResult
            Dim bText As Boolean

            If SortCol < 0 Or SortCol > (.ColumnCount - 1) Then Return "Invalid column!"

            'sort by value
            For lX As Integer = 0 To .RowCount - 2
                For lY As Integer = lX + 1 To .RowCount - 1
                    'check if comparison by string or by numerics
                    If Not IsNumeric(.Item(SortCol, lX).Value) Then bText = True : Exit For

                    If bReverseOrder = False Then
                        If Val(.Item(SortCol, lY).Value) < Val(.Item(SortCol, lX).Value) Then
                            'Replace
                            .Rows.InsertCopy(lY, lX)
                            CopyDataGridRow(.Rows(lY + 1), .Rows(lX))
                            .Rows.RemoveAt(lY + 1)
                        End If
                    Else
                        If Val(.Item(SortCol, lY).Value) > Val(.Item(SortCol, lX).Value) Then
                            'Replace
                            .Rows.InsertCopy(lY, lX)
                            CopyDataGridRow(.Rows(lY + 1), .Rows(lX))
                            .Rows.RemoveAt(lY + 1)
                        End If
                    End If

                Next
                If bText Then Exit For
            Next
            If bText Then
                If bReverseOrder = False Then
                    .Sort(.Columns(SortCol), System.ComponentModel.ListSortDirection.Ascending)
                Else
                    .Sort(.Columns(SortCol), System.ComponentModel.ListSortDirection.Descending)
                End If

                Return "Column " & .Columns(SortCol).HeaderText & " contains non-numeric values!" & vbCrLf & "It is sorted by string order!"
            End If
        End With

        Return Nothing
    End Function

    Private Sub cmdWriteToLog_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdWriteToLog.Click
        Dim lX, lY As Integer
        Dim szArr() As String
        Dim szX As String

        szX = InputBox("Input a title for the result list" & vbCrLf & "(or leave it empty to cancel):", "Log Result List", "Log Result List")
        If Len(szX) = 0 Then MsgBox("Log Result List canceled") : Return

        DisableButtons()
        ' log header
        STIM.Log("**********", "Result List", System.DateTime.Now.ToString("HH:mm:ss"), szX)
        ReDim szArr(ResultList.ColCount - 1)
        ' log headers
        For lY = 0 To ResultList.ColCount - 1
            szArr(lY) = ResultList.ColCaption(lY)
        Next
        STIM.Log(szArr)
        ' log all items in the item list
        For lX = 0 To ResultList.ItemCount - 1
            For lY = 0 To ResultList.ColCount - 1
                szArr(lY) = ResultList.Item(lX, lY)
            Next
            STIM.Log(szArr)
            pbStatus.Value = CInt(Math.Round(lX / ResultList.ItemCount * 100))
        Next
        STIM.Log("")
        STIM.Log("")
        EnableButtons()
    End Sub

    Private Sub frmResult_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' save size & position
        grectResults.Width = Me.Width
        grectResults.Height = Me.Height
        grectResults.Left = Me.Left
        grectResults.Top = Me.Top
        grectResults.WindowState = Me.WindowState
    End Sub

    Private Sub frmResult_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ' load results form and set size & position, initialize comboboxes
        Me.Icon = frmMain.Icon



        If grectResults.Width > 0 Then 'already form closed before? (obsolete?)

            If grectResults.WindowState = FormWindowState.Minimized Then
                'was minimized -> default coordinates

                'Me.Top = frmMain.Top
                'Me.Left = frmMain.Left

            Else
                Me.Width = grectResults.Width
                Me.Height = grectResults.Height

                'bring to primary screen
                ' check left
                If grectResults.Left + 0.25 * Me.Width > Screen.PrimaryScreen.Bounds.Width Then
                    grectResults.Left = Screen.PrimaryScreen.Bounds.Width - Me.Width \ 4
                End If
                If grectResults.Left + 0.75 * Me.Width < 0 Then
                    grectResults.Left = -3 * Me.Width \ 4
                End If
                ' check top
                If grectResults.Top + 0.25 * Me.Height > Screen.PrimaryScreen.Bounds.Height Then
                    grectResults.Top = Screen.PrimaryScreen.Bounds.Height - Me.Height \ 4
                End If
                If grectResults.Top < 0 Then
                    grectResults.Top = 0
                End If
                Me.SetBounds(grectResults.Left, grectResults.Top, 0, 0, BoundsSpecified.X Or BoundsSpecified.Y)

                'restore maximized state
                If grectResults.WindowState = FormWindowState.Maximized Then Me.WindowState = FormWindowState.Maximized 'do not load form minimized
            End If
          
        Else 'first result form
           
        End If

        InitAxes()
        InitSort()
    End Sub

    Public Sub Init()
        ResultList = New clsItemList(dgvResult)
    End Sub

    Private Sub frmResult_Paint(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        If LCase(dgvResult.Columns(0).HeaderText) = "index" Then cmdRefreshIndex.Enabled = True
        cmdWriteToLog.Enabled = gblnOutputStable
    End Sub

    Private Sub frmResult_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        If Me.IsInitializing = True Then Return
    End Sub



    ''' <summary>
    ''' Set the postfix of the result file.
    ''' </summary>
    ''' <value></value>
    ''' <returns>Postfix</returns>
    ''' <remarks>Clicking on "Save As..." use can save the content of the result list to a CSV file.
    ''' Postfix defines the postfix of this file, it will be saved in format: name_postfix.rsl.csv
    ''' User is allowed to change the postfix in a window.</remarks>
    Public Property PostFix() As String
        Get
            Return mszPostFix
        End Get
        Set(ByVal Value As String)
            mszPostFix = Value
        End Set
    End Property

    Private Sub cmdPrintLandscape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintLandscape.Click

        Dim dlg As New PrintPreviewDialog()
        PrintDocument1.DefaultPageSettings.Landscape = True
        dlg.Document = PrintDocument1
        dlg.ShowDialog()

    End Sub

    Private oStringFormat As StringFormat
    Private oStringFormatComboBox As StringFormat
    Private oButton As Button
    Private oCheckbox As CheckBox
    Private oComboBox As ComboBox

    Private nTotalWidth As Int16
    Private nRowPos As Int16
    Private NewPage As Boolean
    Private nPageNo As Int16

    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint 
        oStringFormat = New StringFormat With { _
            .Alignment = StringAlignment.Near, _
            .LineAlignment = StringAlignment.Center, _
            .Trimming = StringTrimming.EllipsisCharacter _
        }

        oStringFormatComboBox = New StringFormat With { _
            .LineAlignment = StringAlignment.Center, _
            .FormatFlags = StringFormatFlags.NoWrap, _
            .Trimming = StringTrimming.EllipsisCharacter _
        }

        oButton = New Button
        oCheckbox = New CheckBox
        oComboBox = New ComboBox

        nTotalWidth = 0
        For Each oColumn As DataGridViewColumn In dgvResult.Columns

            nTotalWidth += oColumn.Width

        Next
        nPageNo = 1
        NewPage = True
        nRowPos = 0

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Static oColumnLefts As New ArrayList
        Static oColumnWidths As New ArrayList
        Static oColumnTypes As New ArrayList
        Static nHeight As Int16

        Dim nWidth, i, nRowsPerPage As Int16
        Dim nTop As Int16 = e.MarginBounds.Top
        Dim nLeft As Int16 = e.MarginBounds.Left

        If nPageNo = 1 Then
            For Each oColumn As DataGridViewColumn In dgvResult.Columns
                nWidth = CType(Math.Floor(oColumn.Width / nTotalWidth * nTotalWidth * (e.MarginBounds.Width / nTotalWidth)), Int16)
                nHeight = e.Graphics.MeasureString(oColumn.HeaderText, oColumn.InheritedStyle.Font, nWidth).Height + 11
                oColumnLefts.Add(nLeft)
                oColumnWidths.Add(nWidth)
                oColumnTypes.Add(oColumn.GetType)
                nLeft += nWidth
            Next
        End If

        Do While nRowPos < dgvResult.Rows.Count
            Dim oRow As DataGridViewRow = dgvResult.Rows(nRowPos)
            If nTop + nHeight >= e.MarginBounds.Height + e.MarginBounds.Top Then
                DrawFooter(e, nRowsPerPage)
                NewPage = True
                nPageNo += 1
                e.HasMorePages = True
                Return
            Else
                If NewPage Then
                    ' Draw Header
                    e.Graphics.DrawString(gszSettingFileName, _
                                New Font(dgvResult.Font, FontStyle.Bold), _
                                Brushes.Black, e.MarginBounds.Left, _
                                e.MarginBounds.Top - e.Graphics.MeasureString(gszSettingTitle, _
                                                New Font(dgvResult.Font, FontStyle.Bold), _
                                e.MarginBounds.Width).Height - 26)
                    e.Graphics.DrawString(Me.Text, _
                                New Font(dgvResult.Font, FontStyle.Bold), _
                                Brushes.Black, e.MarginBounds.Left, _
                                e.MarginBounds.Top - e.Graphics.MeasureString(gszSettingTitle, _
                                                New Font(dgvResult.Font, FontStyle.Bold), _
                                e.MarginBounds.Width).Height - 13)
                    ' Draw Columns
                    nTop = e.MarginBounds.Top
                    i = 0
                    For Each oColumn As DataGridViewColumn In dgvResult.Columns
                        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight))
                        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight))
                        e.Graphics.DrawString(oColumn.HeaderText, oColumn.InheritedStyle.Font, New SolidBrush(oColumn.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i), nTop, oColumnWidths(i), nHeight), oStringFormat)
                        i += 1
                    Next
                    NewPage = False
                End If

                nTop += nHeight
                i = 0
                For Each oCell As DataGridViewCell In oRow.Cells
                    Dim sValue As String
                    If oCell.Value IsNot Nothing Then
                        sValue = oCell.Value.ToString
                    Else
                        sValue = ""
                    End If
                    If oColumnTypes(i) Is GetType(DataGridViewTextBoxColumn) OrElse oColumnTypes(i) Is GetType(DataGridViewLinkColumn) Then
                        e.Graphics.DrawString(sValue, oCell.InheritedStyle.Font, New SolidBrush(oCell.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i), nTop, oColumnWidths(i), nHeight), oStringFormat)
                    ElseIf oColumnTypes(i) Is GetType(DataGridViewButtonColumn) Then
                        oButton.Text = oCell.Value.ToString
                        oButton.Size = New Size(oColumnWidths(i), nHeight)
                        Dim oBitmap As New Bitmap(oButton.Width, oButton.Height)
                        oButton.DrawToBitmap(oBitmap, New Rectangle(0, 0, oBitmap.Width, oBitmap.Height))
                        e.Graphics.DrawImage(oBitmap, New Point(oColumnLefts(i), nTop))
                    ElseIf oColumnTypes(i) Is GetType(DataGridViewCheckBoxColumn) Then
                        oCheckbox.Size = New Size(14, 14)
                        oCheckbox.Checked = CType(oCell.Value, Boolean)
                        Dim oBitmap As New Bitmap(oColumnWidths(i), nHeight)
                        Dim oTempGraphics As Graphics = Graphics.FromImage(oBitmap)
                        oTempGraphics.FillRectangle(Brushes.White, New Rectangle(0, 0, oBitmap.Width, oBitmap.Height))
                        oCheckbox.DrawToBitmap(oBitmap, New Rectangle(CType((oBitmap.Width - oCheckbox.Width) / 2, Int32), CType((oBitmap.Height - oCheckbox.Height) / 2, Int32), oCheckbox.Width, oCheckbox.Height))
                        e.Graphics.DrawImage(oBitmap, New Point(oColumnLefts(i), nTop))
                    ElseIf oColumnTypes(i) Is GetType(DataGridViewComboBoxColumn) Then
                        oComboBox.Size = New Size(oColumnWidths(i), nHeight)
                        Dim oBitmap As New Bitmap(oComboBox.Width, oComboBox.Height)
                        oComboBox.DrawToBitmap(oBitmap, New Rectangle(0, 0, oBitmap.Width, oBitmap.Height))
                        e.Graphics.DrawImage(oBitmap, New Point(oColumnLefts(i), nTop))
                        e.Graphics.DrawString(oCell.Value.ToString, oCell.InheritedStyle.Font, New SolidBrush(oCell.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i) + 1, nTop, oColumnWidths(i) - 16, nHeight), oStringFormatComboBox)
                    ElseIf oColumnTypes(i) Is GetType(DataGridViewImageColumn) Then
                        Dim oCellSize As Rectangle = New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight)
                        Dim oImageSize As Size = CType(oCell.Value, Image).Size
                        e.Graphics.DrawImage(oCell.Value, New Rectangle(oColumnLefts(i) + CType(((oCellSize.Width - oImageSize.Width) / 2), Int32), nTop + CType(((oCellSize.Height - oImageSize.Height) / 2), Int32), CType(oCell.Value, Image).Width, CType(oCell.Value, Image).Height))
                    End If
                    e.Graphics.DrawRectangle(Pens.Black, New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight))
                    i += 1
                Next
            End If

            nRowPos += 1
            nRowsPerPage += 1

        Loop

        DrawFooter(e, nRowsPerPage)
        e.HasMorePages = False

    End Sub

    Private Sub DrawFooter(ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal RowsPerPage As Int32)

        Dim sPageNo As String = nPageNo.ToString + " of " + Math.Ceiling(dgvResult.Rows.Count / RowsPerPage).ToString
        e.Graphics.DrawString(gszItemListTitle, dgvResult.Font, Brushes.Black, _
                            e.MarginBounds.Left + (e.MarginBounds.Width - _
                                e.Graphics.MeasureString(gszItemListTitle, dgvResult.Font, e.MarginBounds.Width).Width), _
                            e.MarginBounds.Top + e.MarginBounds.Height + 7)
        e.Graphics.DrawString(Now.ToLongDateString + " " + Now.ToShortTimeString, dgvResult.Font, _
                              Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top + e.MarginBounds.Height + 7)
        e.Graphics.DrawString(sPageNo, dgvResult.Font, Brushes.Black, _
                            e.MarginBounds.Left + (e.MarginBounds.Width - _
                                e.Graphics.MeasureString(sPageNo, dgvResult.Font, e.MarginBounds.Width).Width) / 2, _
                            e.MarginBounds.Top + e.MarginBounds.Height + 31)

    End Sub

    Private Sub cmdPrintPortrait_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintPortrait.Click
        Dim dlg As New PrintPreviewDialog()
        PrintDocument1.DefaultPageSettings.Landscape = False
        dlg.Document = PrintDocument1
        dlg.ShowDialog()
    End Sub

    ''' <summary>
    ''' Set optimal column width for DataGridView cells.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetOptimalColWidth()
        ResultList.SetOptimalColWidth()
    End Sub


    Private Sub cmbSortCol_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbSortCol.SelectedIndexChanged
        'set tooltip of sort button
        ToolTip1.SetToolTip(cmdSort, cmbSortCol.SelectedItem.ToString)
    End Sub
End Class


