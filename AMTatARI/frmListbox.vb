#Region "ExpSuite License"
'ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
'Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
'Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
'You may not use this work except in compliance with the Licence. 
'You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
'Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
'See the Licence for the specific language governing  permissions and limitations under the Licence. 
#End Region

Public Class frmListbox

    Public Function Init(ByVal szHeader As String, ByVal szTitle As String, ByVal szListItems() As String, Optional szStringName As String = "") As String
        'fill form
        Dim bClearTextBox As Boolean = True

        Me.Text = szTitle
        Label1.Text = szHeader
        ListBox1.Items.Clear()
        Me.Height = 260
        If Not (szListItems Is Nothing) Then
            For lX As Integer = 0 To szListItems.Length - 1
                ListBox1.Items.Add(szListItems(lX))
                If txtName.Text = szListItems(lX).ToString Then bClearTextBox = False
            Next
            'change size depending on number of items in list
            If szListItems.Length > 5 Then Me.Height = Math.Min(400, szListItems.Length * 12 + 210)
        End If
        'LastString = TextBox1.Text
        If szStringName <> "" Then
            txtName.Text = szStringName
        ElseIf bClearTextBox Then
            txtName.Text = ""
        End If

        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Return txtName.Text
        Else
            Return ""
        End If

    End Function
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        'cancel
        Me.Close()
    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        'ok on double clicked
        If ListBox1.SelectedIndex <> -1 Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        'select item
        If ListBox1.SelectedIndex = -1 Then Exit Sub
        txtName.Text = ListBox1.SelectedItem.ToString
    End Sub

    Private Sub frmListbox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Left = frmMain.Left + 150
        Me.Top = frmMain.Top + 50
        txtName.Select()
        If txtName.Text <> "" Then txtName.Focus() : txtName.SelectAll()
    End Sub
End Class