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
' multiline input box template, application programmer can use that box for any inputs being done by an experimentator
''' <summary>
''' FrameWork Module - Programmable Multiline Input Box Form.
''' </summary>
''' <remarks></remarks>
Friend Class frmInputMultiline
    Inherits System.Windows.Forms.Form

   

    Private IsInitializing As Boolean
    Private mszData As String
    Private mszTitle As String
    Private mblnCancel As Boolean
    Private mlLeft, mlTop As Integer

   

   

    Public Property Text_Renamed() As String
        Get
            Text_Renamed = mszData
        End Get
        Set(ByVal Value As String)
            mszData = Value
        End Set
    End Property

   ''' <summary>
    ''' Set the title of the multiline text.
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property Title() As String
        Set(ByVal Value As String)
            mszTitle = Value
        End Set
    End Property

   ''' <summary>
    ''' Set the left position of the input form.
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property SetLeft() As Integer
        Set(ByVal Value As Integer)
            mlLeft = Value
        End Set
    End Property

   ''' <summary>
    ''' Set the top position of the input form.
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property SetTop() As Integer
        Set(ByVal Value As Integer)
            mlTop = Value
        End Set
    End Property

   ''' <summary>
    ''' Show the input box form.
    ''' </summary>
    ''' <param name="Caption">Caption of the form.</param>
    ''' <returns>TRUE if the data are valid, FALSE if cancel or close was clicked. The data are not valid in the latter case.</returns>
    ''' <remarks>Call ShowForm to show the form.</remarks>
    Public Function ShowForm(ByVal Caption As String) As Boolean
        Dim lX As Integer

        Me.Text = Caption
        lblTitle.Text = mszTitle
        txtText.Text = mszData

        lX = lblTitle.Top + lblTitle.Height + 8
        txtText.Top = lX
        lX = txtText.Top + txtText.Height + 16
        cmdOK.Top = lX
        cmdCancel.Top = lX
        Me.Height = lX + cmdOK.Height + 40

        If mlLeft <> 0 Or mlTop <> 0 Then
            Me.Left = mlLeft
            Me.Top = mlTop
        End If

        mblnCancel = True
        Me.ShowDialog()
        ShowForm = Not mblnCancel

    End Function

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        mblnCancel = True
        Me.Hide()
    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        ' save data
        mszData = txtText.Text

        mblnCancel = False
        Me.Hide()

    End Sub

    Private Sub frmInputMultiline_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        mszTitle = "Edit the text:"
        Me.Icon = frmMain.Icon
    End Sub

    Private Sub frmInputMultiline_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        mblnCancel = True
    End Sub

    Private Sub frmInputMultiline_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        If Me.IsInitializing = True Then
            Exit Sub
        Else

            cmdCancel.Left = Me.Width - cmdCancel.Width - 19
            cmdOK.Left = cmdCancel.Left - cmdOK.Width - 19
            txtText.Width = Me.Width - txtText.Left - 19

            cmdCancel.Top = Me.Height - cmdCancel.Height - 38
            cmdOK.Top = cmdCancel.Top
            txtText.Height = System.Math.Abs(cmdCancel.Top - txtText.Top - 8)

        End If
    End Sub

    Private Sub txtText_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtText.KeyDown
        If ((eventArgs.KeyData And Keys.Control) = Keys.Control) And eventArgs.KeyCode = System.Windows.Forms.Keys.A Then
            txtText.SelectionStart = 0
            txtText.SelectionLength = Len(txtText.Text)
        End If
    End Sub
End Class