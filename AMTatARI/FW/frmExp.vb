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
Imports System.Linq
' experiment form, appears when starting experiment (not obligatory; some applications do not need an experiment form),
' this is usually the form that is presented to the subject, content can be changed dynamically during experiment
''' <summary>
''' FrameWork Module. Implementation of the Experiment Screen and Subject Interaction.
''' </summary>
''' <remarks></remarks>
Friend Class frmExp
    Inherits System.Windows.Forms.Form
    ''' <summary>
    ''' Defined flags for experimental screen.
    ''' </summary>
    Public Enum EXPFLAGS
        expflStartButton = 1
        expflNextButton = 2
        expflResponseButtons = 4
        expflFeedback = 8
        expflHighlight = 16
        expflWaitForNext = 32
        expflHideProgress = 64
        expflProgressSyncToBreak = 128
        expflDelayRequest = 256
        expflClipMouseToWindow = 512
        expflWaitAfterBreak = 1024
        expflDarkMode = 2048
    End Enum

    Private Enum EXPTABINDEX
        exptabBlank = 0
        exptabStart = 1
        exptabEnd = 2
        exptabStimBase = 3
    End Enum

    Private Structure RESPONSE
        Dim lKey As Integer
        Dim lHUI As Integer
        Dim lTrigger As Integer
    End Structure
    ''' <summary>
    ''' Defined flags for trigger device (Unity tracker).
    ''' </summary>
    Private Enum TRIGGER
        'Left
        X = 1
        Y = 2
        Start = 4
        LThumbstick = 8
        LIndexTriggerL = 16
        LHandTrigger = 32
        LThumbRest = 64
        'Right
        A = 128
        B = 256
        Reserved = 512
        RThumbstick = 1024
        RIndexTriggerL = 2048
        RHandTrigger = 4096
        RThumbRest = 8192
    End Enum

    Public Enum EXPSTATE
        expUnInit = 0
        expInit = 1
        expBlank = 2
        expStart = 3
        expStim = 4
        expNext = 5
        expEnd = 6
        expHidden = 7
    End Enum

    Private Const END_TEXT As String = "Das Experiment ist beendet." & vbCrLf & "Vielen Dank!"
    Private Const START_TEXT As String = "Bitte starten Sie das Experiment."
    Private Const REQUEST_TEXT As String = "Bitte tun Sie irgendwas!"
    Private Const BREAK_TEXT As String = "Pause!"

    Private IsInitializing As Boolean
    Private rectMe As RECT
    Private rectMouse As RECT
    Private rectMouseDown As RECT
    Private blnMouseDown As Boolean
    Private blnMoved As Boolean
    Private mlResponse As Integer = -1 ' bit 0..3: response index, bit 4..15: experiment mode, bit 16: control mode
    Private mResponseTimeStamp As Date
    Private mblnAutoDisable As Boolean
    Private mblnResponse As Boolean
    Private mlExpMode As Integer
    Private mrespArr() As RESPONSE
    Private mrespNext As RESPONSE
    Private mrespStart As RESPONSE
    Public gexpState As EXPSTATE
    Private mblnNextFrameVisible As Boolean
    Private mFlags As EXPFLAGS
    Private msFeedBackFontSize As Single = 1
    Private mblnBreak As Boolean
    Private mszBreakText As String
    Private mszStartText As String
    Private mszEndText As String
    Private mlOnResponseAddr As OnResponseDelegate
    Private mlJoypadIndex As Integer
    'Private bTextEntered As Boolean
    Private CharacterEntered As Char

    Private mlIFC As Integer
    Private mlAFC As Integer

    Private butResponse As New System.Collections.Generic.List(Of Button)
    Private lblVisu As New System.Collections.Generic.List(Of Label)
    Private textNum As TextBox
    Private lblRequest As Label
    Private butTemp As Button
    Public glMouseWheelStepSize As Integer
    'Public gStartPlay7 As DateTime
    Public gcurHPFrequency7 As Long



    ''' <summary>
    ''' Set the application mode to "in experiment"
    ''' </summary>
    ''' <value></value>
    ''' <returns>True if in experiment.</returns>
    ''' <remarks></remarks>
    Public Property InExperiment() As Boolean
        Get
            Return gblnExperiment
        End Get
        Set(ByVal value As Boolean)
            gblnExperiment = value
        End Set
    End Property

    ''' <summary>
    ''' Set HUI device (index).
    ''' </summary>
    ''' <param name="lIdx">Device Index.</param>
    ''' <returns>Error message if an error occures.</returns>
    ''' <remarks></remarks>
    Public Function SetHUIDevice(ByVal lIdx As Integer) As String
        If lIdx = 0 Then Return ""
        lIdx = lIdx - 1 ' #0 is not HUI, remove
        Dim szDesc() As String = Nothing
        Dim lButtons() As Integer = Nothing
        Dim szErr As String = HUI.GetDevicesList(szDesc, lButtons)
        If Len(szErr) > 0 Then Return szErr
        If lIdx > szDesc.Length Then Return ""
        szErr = HUI.SetDevice(Me.Handle, lIdx)
        If Len(szErr) > 0 Then Return szErr
        ' search for the joypad mapping
        mlJoypadIndex = -1
        For lX As Integer = 0 To JoyPads.Length - 1
            If szDesc(lIdx) = JoyPads(lX).Description Then mlJoypadIndex = lX
        Next
        Return ""
    End Function

    ''' <summary>
    ''' Sets the callback on subject's response.
    ''' </summary>
    ''' <param name="lAddr"></param>
    ''' <remarks>OnResponse callback will be executed on:
    ''' <li>Subject pressed a HUI button</li>
    ''' <li>Subject pressed a keyboard key</li> 
    ''' <li>Subject pressed a trigger button (Unity tracker)</li> </remarks>
    Public Sub SetOnResponseCallback(ByVal lAddr As OnResponseDelegate)
        mlOnResponseAddr = lAddr
    End Sub


    ''' <summary>
    ''' Sets the caption of response buttons.
    ''' </summary>
    ''' <param name="szArgs">Required. String. The caption of response button will be set for each string in the array.</param>
    ''' <param name="szStart">Required. String. Text for the Start button.</param>
    ''' <param name="szNext">Required. String. Text for the Next button.</param>
    ''' <param name="szCancel">equired. String. Text for the Cancel button.</param>
    ''' <returns></returns>
    ''' <remarks>The number of items in szArgs() must less or equal to AFC.</remarks>
    Public Function SetResponseNames(ByVal szArgs() As String, _
                                    Optional ByVal szStart As String = Nothing, _
                                    Optional ByVal szNext As String = Nothing, _
                                    Optional ByVal szCancel As String = Nothing) As String
        Dim lX As Integer
        If gexpState = EXPSTATE.expUnInit Then Return ""
        If szArgs Is Nothing Then Return "SetResponsesNames: array with names is nothing."
        If szArgs.Length > mlAFC Then Return "SetResponseNames: too big array (size is limited to AFC)"
        For lX = 0 To szArgs.Length - 1
            butResponse(lX).Text = szArgs(lX)
        Next
        If Not IsNothing(szStart) Then Me.cmdStart.Text = szStart
        If Not IsNothing(szNext) Then Me.cmdNext.Text = szNext
        If Not IsNothing(szCancel) Then Me.cmdCancel.Text = szCancel

        Return ""
    End Function

    ''' <summary>
    ''' Array with response buttons.
    ''' </summary>
    ''' <param name="lButtons">Array of buttons.</param>
    ''' <param name="lStart">Start button.</param>
    ''' <param name="lNext">Next button.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetResponseButtons(ByRef lButtons() As Integer, ByRef lStart As Integer, ByRef lNext As Integer) As String
        If gexpState = EXPSTATE.expUnInit Then Return "SetResponseButtons: Init before setting response buttons"
        If IsNothing(mrespArr) Then Return "GetResponseButtons: Array with buttons not initialized yet."
        ReDim lButtons(mrespArr.Length - 1)
        For lX As Integer = 0 To lButtons.Length - 1
            lButtons(lX) = mrespArr(lX).lHUI
        Next
        lStart = mrespStart.lHUI
        lNext = mrespNext.lHUI
        Return ""
    End Function

    ''' <summary>
    ''' Array with response keys.
    ''' </summary>
    ''' <param name="lKeys">Array of keys.</param>
    ''' <param name="lStart">Start key.</param>
    ''' <param name="lNext">Next key.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetResponseKeys(ByRef lKeys() As Integer, ByRef lStart As Integer, ByRef lNext As Integer) As String
        If gexpState = EXPSTATE.expUnInit Then Return "SetResponseKeys: Init before setting response buttons"
        If IsNothing(mrespArr) Then Return "GetResponseKeys: Array with buttons not initialized yet."
        ReDim lKeys(mrespArr.Length - 1)
        For lX As Integer = 0 To lKeys.Length - 1
            lKeys(lX) = mrespArr(lX).lKey
        Next
        lStart = mrespStart.lKey
        lNext = mrespNext.lKey
        Return ""
    End Function

    ''' <summary>
    ''' Array with response triggers (tracker).
    ''' </summary>
    ''' <param name="lTriggers">Array of triggers.</param>
    ''' <param name="lStart">Start trigger.</param>
    ''' <param name="lNext">Next trigger.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetResponseTriggers(ByRef lTriggers() As Integer, ByRef lStart As Integer, ByRef lNext As Integer) As String
        If gexpState = EXPSTATE.expUnInit Then Return "GetResponseTriggers: Init before setting response buttons"
        If IsNothing(mrespArr) Then Return "GetResponseTriggers: Array with buttons not initialized yet."
        ReDim lTriggers(mrespArr.Length - 1)
        For lX As Integer = 0 To lTriggers.Length - 1
            lTriggers(lX) = mrespArr(lX).lTrigger
        Next
        lStart = mrespStart.lTrigger
        lNext = mrespNext.lTrigger
        Return ""
    End Function

    ''' <summary>
    ''' Sets the HUI codes for the response, start and next buttons.
    ''' </summary>
    ''' <param name="lButtons">Array with the HUI codes for the responses. The array size must match the number of alternatives given by AFC. The codes can be retrieved from Settings/Experiment Screen/Get Response.</param>
    ''' <param name="lStart">HUI code for the start button.</param>
    ''' <param name="lNext">HUI code for the next-item button.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetResponseButtons(ByVal lButtons() As Integer, ByVal lStart As Integer, ByVal lNext As Integer) As String
        Dim lX As Integer
        If gexpState = EXPSTATE.expUnInit Then Return "SetResponseButtons: Init before setting response buttons"
        If lButtons Is Nothing Then Return "SetResponseButtons: Array with buttons must have the length of AFC"
        If lButtons.Length <> mlAFC Then Return "SetResponseButtons: Array with buttons must have the length of AFC"
        For lX = 0 To lButtons.Length - 1
            mrespArr(lX).lHUI = lButtons(lX)
        Next
        mrespStart.lHUI = lStart
        mrespNext.lHUI = lNext
        Return ""
    End Function

    ''' <summary>
    ''' Set the codes for the response, start and next keys.
    ''' </summary>
    ''' <param name="lKeys">Array with the ASCII codes for the responses. The array size must match the number of alternatives given by AFC on Init.</param>
    ''' <param name="lStart">ASCII code for the start key.</param>
    ''' <param name="lNext">ASCII code for the next-item key.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetResponseKeys(ByVal lKeys() As Integer, ByVal lStart As Integer, ByVal lNext As Integer) As String
        Dim lX As Integer
        If gexpState = EXPSTATE.expUnInit Then Return "SetResponseKeys: Init before setting response keys"
        If lKeys Is Nothing Then Return "SetResponseKeys: Array with keys must have the length of AFC"
        If lKeys.Length <> mlAFC Then Return "SetResponseKeys: Array with keys must have the length of AFC"
        For lX = 0 To lKeys.Length - 1
            mrespArr(lX).lKey = lKeys(lX)
        Next
        mrespStart.lKey = lStart
        mrespNext.lKey = lNext
        Return ""
    End Function

    ''' <summary>
    ''' Sets the trigger codes for the response, start and next buttons (tracker).
    ''' </summary>
    ''' <param name="lTriggers">Array with the tracker trigger codes for the responses. The array size must match the number of alternatives given by AFC. The codes can be retrieved from Settings/Experiment Screen/Get Response.</param>
    ''' <param name="lStart">Tracker trigger code for the start.</param>
    ''' <param name="lNext">Tracker trigger code for the next-item.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetResponseTriggers(ByVal lTriggers() As Integer, ByVal lStart As Integer, ByVal lNext As Integer) As String
        Dim lX As Integer
        If gexpState = EXPSTATE.expUnInit Then Return "SetResponseTriggers: Init before setting response trigger"
        If lTriggers Is Nothing Then Return "SetResponseTriggers: Array with triggers must have the length of AFC"
        If lTriggers.Length <> mlAFC Then Return "SetResponseTriggers: Array with triggers must have the length of AFC"
        For lX = 0 To lTriggers.Length - 1
            mrespArr(lX).lTrigger = lTriggers(lX)
        Next
        mrespStart.lTrigger = lStart
        mrespNext.lTrigger = lNext
        Return ""
    End Function

    ''' <summary>
    ''' Sets the caption of interval visualisation boxes (lblVisu)
    ''' </summary>
    ''' <param name="szCaption">Captions of the interval visualisation boxes. The array size must match the number of intervals given by IFC on Init.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetVisuCaption(ByVal szCaption() As String) As String
        Dim lX As Integer
        If gexpState = EXPSTATE.expUnInit Then Return "SetVisuCaption: Init before setting visual captions"
        If szCaption Is Nothing Then Return "SetVisuCaption: Array with captions must have length of IFC"
        If szCaption.Length <> mlIFC Then Return "SetVisuCaption: Array with captions must have length of IFC"
        For lX = 0 To mlIFC - 1
            lblVisu(lX).Text = szCaption(lX)
        Next
        Return ""
    End Function
    ''' <summary>
    ''' Sets the request text in the experiment. This may be the question to the subject or something else...
    ''' </summary>
    ''' <param name="szText">Request to the subject.</param>
    ''' <param name="lForeColor">Color of the text, if Nothing or Color.Empty the standard windows color is used.</param>
    ''' <remarks></remarks>
    Public Sub SetRequestText(ByVal szText As String, ByVal lForeColor As Color)
        If gexpState = EXPSTATE.expUnInit Then Exit Sub
        If IsNothing(szText) Then
            lblRequest.Text = REQUEST_TEXT
        Else
            lblRequest.Text = szText
        End If
        If IsNothing(lForeColor) Then lblRequest.ForeColor = Drawing.SystemColors.ControlText : Return
        If lForeColor = Color.Empty Then lblRequest.ForeColor = Drawing.SystemColors.ControlText : Return
        lblRequest.ForeColor = lForeColor
    End Sub

    ''' <summary>
    ''' Sets the break text in the experiment. 
    ''' </summary>
    ''' <param name="szText">Text which is flashing during the break.</param>
    ''' <remarks></remarks>
    Public Sub SetBreakText(ByVal szText As String)
        If IsNothing(szText) Then
            mszBreakText = BREAK_TEXT
        Else
            mszBreakText = szText
        End If
    End Sub

    ''' <summary>
    ''' Sets the end-of-experimt text. 
    ''' </summary>
    ''' <param name="szText">Text appears at the enf of experiment.</param>
    ''' <remarks></remarks>
    Public Sub SetEndOfExperimentText(ByVal szText As String)
        If IsNothing(szText) Then
            mszEndText = END_TEXT
            lblEnd.Text = mszEndText
        Else
            mszEndText = szText
            lblEnd.Text = mszEndText
        End If
    End Sub

    ''' <summary>
    ''' Sets the start-of-experiment text. 
    ''' </summary>
    ''' <param name="szText">Text which appears at the start of experiment</param>
    ''' <remarks></remarks>
    Public Sub SetStartOfExperimentText(ByVal szText As String)
        If IsNothing(szText) Then
            mszStartText = START_TEXT
            lblStart.Text = mszStartText
        Else
            mszStartText = szText
            lblStart.Text = mszStartText
        End If
    End Sub
    ''' <summary>
    ''' Set the value of progress bar.
    ''' </summary>
    ''' <param name="sVal">Represents progress in percent, must be a value in [0;100]. </param>
    ''' <param name="szX">Optional string which will be used instead of the sVal.</param>
    ''' <remarks></remarks>
    Public Sub SetProgress(ByVal sVal As Double, Optional ByRef szX As String = "")
        If gexpState = EXPSTATE.expUnInit Then Exit Sub
        If mblnBreak Then Return
        If lblProgress.InvokeRequired Then Err.Raise(vbObjectError, "frmExp.SetProgress.lblProgress", "invokerequired")
        If (mFlags And EXPFLAGS.expflHideProgress) = 0 Then
            If sVal > 100 Then sVal = 100
            If sVal < 0 Then sVal = 0
            pbProgress.Value = CInt(Math.Round(sVal))
            If Len(szX) = 0 Then
                ' show numeric value
                'lblProgress.Text = TStr(Math.Round(sVal, 1)) & " %"
                lblProgress.Text = Replace(VB6.Format(sVal, "0.0"), ",", ".") & " %" ' Show as "#.# %"
            Else
                ' show string
                lblProgress.Text = szX
            End If
        Else
            lblProgress.Text = ""
        End If
    End Sub

    ''' <summary>
    ''' Initialize EXP module.
    ''' </summary>
    ''' <param name="lExpMode">ExpMode sets the mode of active experiment.</param>
    ''' <param name="lAFC">Alternative Forced Choice, sets the number of visible buttons in experiment.</param>
    ''' <param name="lIFC">Interval Forced Choice, sets the number of stimuli parts in the stimulus sequence.</param>
    ''' <param name="Flags">Flags: Bit 0: start button visible; Bit 1: response buttons visible; Bit 2: next button visible.</param>
    ''' <returns>Return_value_or_object</returns>
    ''' <remarks>
    ''' Defined experiment modes:
    '''<li> 0: pure AFC/IFC experiment. Visual items are arranged vertically. Response buttons are arranged horizontally below the items.</li>
    '''<li> 1: numeric open range combined with AFC/IFC experiment. The first button is disabled until a valid numerical value is entered in the TextBox txtNum.</li>
    '''<li> 2: 2AFC/2IFC, used for binaural loudness balancing. Static screen arrangment. Set AFC and IFC to 0 in this mode.</li>
    '''<li> 3: pure AFC/IFC experiment. Visual items are arranged horizontally. Response buttons are arranged horizontally below the items.</li>
    '''<li> 4: pure AFC/IFC experiment. Visual items and response buttons are arranged vertically. Text is on top.</li>
    '''<li> 5: AFC/IFC experiment with a slider. Visual items and response buttons are arranged vertically. The mouse wheel can be used to adjust eg. levels.</li>
    '''<li> 6: Priming experiment with 2 buttons.</li>
    '''<li> 7: rating of wave files, eg. used for InPaint.</li>
    ''' It's allowed to execute Init() repetitive.</remarks>
    Public Function Init(ByVal lExpMode As Integer, ByVal lAFC As Integer, _
                        ByVal lIFC As Integer, Optional ByVal Flags As EXPFLAGS = 0) As String
        Dim lX, lY As Integer
        Dim szErr As String
        Dim ctrlX As Control
        Dim labX As Label

        ' init data
        ' set up exp screen
        If gblnOverrideExpMode = True Then
            mlExpMode = gOExpMode
        Else
            mlExpMode = lExpMode
        End If

        mlAFC = lAFC
        mlIFC = lIFC
        mFlags = Flags
        mszEndText = END_TEXT
        mszStartText = START_TEXT
        mszBreakText = BREAK_TEXT

        ' check parameters
        Select Case mlExpMode
            Case 0, 1, 3, 4, 5, 6, 7
                If mlAFC < 1 Then szErr = "AFC > 0 required" : GoTo SubErr
            Case 2
                If mlAFC <> 4 Then szErr = "Only AFC=4 allowed when using ExpMode=2" : GoTo SubErr
                If mlIFC <> 2 Then szErr = "Only IFC=2 allowed when using ExpMode=2" : GoTo SubErr
            Case Else
                szErr = "ExpMode must be between 0 and 7"
                GoTo SubErr
        End Select

        ' arrange form
        rectMe.Left = Me.Left
        rectMe.Top = Me.Top
        rectMe.Width = Me.Width
        rectMe.Height = Me.Height
        ' arrange tabs
        tabExp.SizeMode = TabSizeMode.Fixed
        tabExp.ItemSize = New Drawing.Size(1, 1)
        tabExp.TabStop = False
        For lX = 0 To tabExp.TabCount - 1
            tabExp.TabPages(lX).Text = ""
        Next
        tabExp.SelectedIndex = EXPTABINDEX.exptabBlank
        tabExp.Visible = True

        ' set labels
        lblStart.Text = mszStartText
        lblEnd.Text = mszEndText
        tabExp.TabPages(mlExpMode + EXPTABINDEX.exptabStimBase).Controls.Add(lblFeedback)
        lblFeedback.Visible = False
        lblDebug.Text = ""

        ' unload all user controls
        Dim ctrlArr As New System.Collections.Generic.List(Of Control)
        For Each ctrlX In Me.Controls
            If TypeOf (ctrlX) Is Button Or TypeOf (ctrlX) Is Label Then
                If Not IsNothing(ctrlX.Tag) Then
                    If InStr(ctrlX.Tag.ToString, "User") > 0 Then ctrlArr.Add(ctrlX) 'note which ones should be unloaded
                End If
            End If
        Next ctrlX
        For Each ctrlX In ctrlArr
            Me.Controls.Remove(ctrlX)
        Next ctrlX

        ' create Visu-labels for IFC
        lblVisu.Clear()
        For lX = 1 To mlIFC
            lY = 0
            For Each ctrlX In tabExp.TabPages(mlExpMode + EXPTABINDEX.exptabStimBase).Controls
                If TypeOf (ctrlX) Is Label AndAlso Not IsNothing(ctrlX.Tag) AndAlso InStr(ctrlX.Tag.ToString, "Visu") > 0 Then
                    Dim szArr() As String = Split(ctrlX.Tag.ToString, " ")
                    If szArr.Length <> 2 Then szErr = ".Tag property must be 'Visu XX' where XX is the interval index beginning with 1" : GoTo SubErr
                    If CInt(Val(szArr(1))) = lX Then
                        ctrlX.Text = TStr(lX)
                        ctrlX.Visible = True ' visible?
                        lblVisu.Add(DirectCast(ctrlX, Label))
                        lY = 1
                        'Exit For
                        'Else
                        '    ctrlX.Visible = False ' visible?
                    End If
                End If
            Next ctrlX
            If lY = 0 Then
                If lX = 1 Then szErr = "Visu label for the first interval must be specified at design time." : GoTo SubErr
                labX = New Label
                labX.Tag = "UserVisu " & TStr(lX) ' tag as user
                labX.Text = TStr(lX)
                labX.Size = lblVisu(0).Size
                labX.Location = lblVisu(0).Location
                If gbDarkMode Then
                    labX.BackColor = Color.Black
                Else
                    labX.BackColor = lblVisu(0).BackColor
                End If
                labX.BorderStyle = lblVisu(0).BorderStyle
                labX.ForeColor = lblVisu(0).ForeColor
                labX.TextAlign = lblVisu(0).TextAlign
                tabExp.TabPages(mlExpMode + EXPTABINDEX.exptabStimBase).Controls.Add(labX)
                lblVisu.Add(labX)
            End If
        Next

        ' create buttons for AFC
        butResponse.Clear()
        'If Not IsNothing(butResponse) Then butResponse.Clear()
        For lX = 1 To mlAFC
            lY = 0
            For Each ctrlX In tabExp.TabPages(mlExpMode + EXPTABINDEX.exptabStimBase).Controls
                If TypeOf (ctrlX) Is Button AndAlso Not IsNothing(ctrlX.Tag) AndAlso InStr(ctrlX.Tag.ToString, "Response") > 0 Then
                    Dim szArr() As String = Split(ctrlX.Tag.ToString, " ")
                    If szArr.Length <> 2 Then szErr = ".Tag property must be 'Response XX' where XX is the response index beginning with 1" : GoTo SubErr
                    ' design-time button found
                    If CInt(Val(szArr(1))) = lX Then
                        ctrlX.Text = TStr(lX)
                        ctrlX.Visible = CBool(mFlags And EXPFLAGS.expflResponseButtons) ' visible?
                        butResponse.Add(DirectCast(ctrlX, Button))
                        AddHandler ctrlX.Click, AddressOf butResponse_Click
                        lY = 1
                        Exit For
                    End If
                End If
            Next
            If lY = 0 Then  ' create a button
                If lX = 1 Then szErr = "Response button for the response #1 must be specified at design time." : GoTo SubErr
                Dim butX As New Button
                butX.Tag = "UserResponse " & TStr(lX) ' tag as user
                butX.Text = TStr(lX)
                butX.Visible = CBool(mFlags And EXPFLAGS.expflResponseButtons)
                butX.Location = butResponse(0).Location
                butX.Size = butResponse(0).Size
                butX.Font = butResponse(0).Font
                butX.ForeColor = butResponse(0).ForeColor
                butX.Anchor = butResponse(0).Anchor
                tabExp.TabPages(mlExpMode + EXPTABINDEX.exptabStimBase).Controls.Add(butX)
                butResponse.Add(butX)
                AddHandler butX.Click, AddressOf butResponse_Click
            End If
        Next

        ' reset response value text boxes
        textNum = Nothing
        For Each ctrlX In tabExp.TabPages(mlExpMode + EXPTABINDEX.exptabStimBase).Controls
            If TypeOf (ctrlX) Is TextBox Then textNum = DirectCast(ctrlX, TextBox) : Exit For
        Next
        If Not IsNothing(textNum) Then
            textNum.Text = ""
            AddHandler textNum.TextChanged, AddressOf textNum_TextChanged
            AddHandler textNum.KeyPress, AddressOf textNum_KeyPress
            AddHandler textNum.KeyDown, AddressOf textNum_KeyDown
            AddHandler textNum.KeyUp, AddressOf textNum_KeyUp
        End If

        ' save the request label 
        For Each ctrlX In tabExp.TabPages(mlExpMode + EXPTABINDEX.exptabStimBase).Controls
            If TypeOf (ctrlX) Is Label AndAlso ctrlX.Tag.ToString = "Request" Then lblRequest = DirectCast(ctrlX, Label) : Exit For
        Next

        ' set buttons
        cmdStart.Visible = CBool(mFlags And EXPFLAGS.expflStartButton)
        cmdCancel.Visible = CBool(mFlags And EXPFLAGS.expflResponseButtons)

        ' set progress visible
        fraProgress.Visible = False
        If (mFlags And EXPFLAGS.expflHideProgress) <> 0 Then
            pbProgress.Visible = False
            lblProgress.Text = ""
            lblProgressText.Text = ""
        Else
            pbProgress.Visible = True
        End If

        If gbDarkMode Then
            ' form
            Me.BackColor = Color.Black
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            'Me.Panel1.BorderStyle = BorderStyle.None
            Me.Panel1.BackColor = Color.Black
            Me.pbProgress.BackColor = Color.Black

            'tabs
            Me.tabExp.Dock = DockStyle.None
            Me.tabBlank.BackColor = System.Drawing.SystemColors.ControlDarkDark
            Me.tabStart.BackColor = Color.Black
            Me.tabEnd.BackColor = Color.Black
            Me.tabMode0.BackColor = Color.Black
            Me.tabMode1.BackColor = Color.Black
            Me.tabMode2.BackColor = Color.Black
            Me.tabMode3.BackColor = Color.Black
            Me.tabMode4.BackColor = Color.Black
            'Me.tabMode4.BorderStyle = BorderStyle.None
            Me.tabMode5.BackColor = Color.Black
            Me.tabMode6.BackColor = Color.Black
            Me.tabMode7.BackColor = Color.Black

            'elements
            Me.lblStart.BackColor = Color.Black
            Me.lblStart.ForeColor = Color.Gray
            Me.lblEnd.BackColor = Color.Black
            Me.lblEnd.ForeColor = Color.Gray

        Else 'NO dark mode
            ' form
            Me.BackColor = System.Drawing.SystemColors.Control
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
            'Me.Panel1.BorderStyle = BorderStyle.None
            Me.Panel1.BackColor = System.Drawing.SystemColors.Control
            Me.pbProgress.BackColor = System.Drawing.SystemColors.Control

            'tabs
            Me.tabExp.Dock = DockStyle.Fill
            Me.tabBlank.BackColor = System.Drawing.SystemColors.Control
            Me.tabStart.BackColor = System.Drawing.SystemColors.Control
            Me.tabEnd.BackColor = System.Drawing.SystemColors.Control
            Me.tabMode0.BackColor = System.Drawing.SystemColors.Control
            Me.tabMode1.BackColor = System.Drawing.SystemColors.Control
            Me.tabMode2.BackColor = System.Drawing.SystemColors.Control
            Me.tabMode3.BackColor = System.Drawing.SystemColors.Control
            Me.tabMode4.BackColor = System.Drawing.SystemColors.Control
            'Me.tabMode4.BorderStyle = BorderStyle.None
            Me.tabMode5.BackColor = System.Drawing.SystemColors.Control
            Me.tabMode6.BackColor = System.Drawing.SystemColors.Control
            Me.tabMode7.BackColor = System.Drawing.SystemColors.Control

            'elements
            Me.lblStart.BackColor = System.Drawing.SystemColors.Control
            Me.lblStart.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblEnd.BackColor = System.Drawing.SystemColors.Control
            Me.lblEnd.ForeColor = System.Drawing.SystemColors.ControlText
        End If

        ' Resize all controls
        frmExp_Resize(Me, New System.EventArgs())

        ' assign default response codes
        ReDim mrespArr(mlAFC - 1)
        Select Case mlExpMode
            Case 0, 1, 3, 4, 5, 6
                For lX = 0 To mlAFC - 1
                    mrespArr(lX).lHUI = lX
                    mrespArr(lX).lKey = System.Windows.Forms.Keys.D1 + lX
                    mrespArr(lX).lTrigger = CInt(2 ^ lX)
                Next
            Case 2
                mrespArr(0).lKey = System.Windows.Forms.Keys.PageUp
                mrespArr(1).lKey = System.Windows.Forms.Keys.PageDown
                mrespArr(2).lKey = System.Windows.Forms.Keys.End
                mrespArr(3).lKey = System.Windows.Forms.Keys.N
                mrespArr(0).lHUI = 11 ' cursor up on WingMan
                mrespArr(1).lHUI = 12 ' cursor down on WingMan
                mrespArr(2).lHUI = 2 ' C on WingMan
                mrespArr(3).lHUI = 8 ' S on WingMan
                mrespArr(0).lTrigger = TRIGGER.A
                mrespArr(1).lTrigger = TRIGGER.B
                mrespArr(2).lTrigger = TRIGGER.X
                mrespArr(3).lTrigger = TRIGGER.Y
        End Select
        mrespStart.lKey = System.Windows.Forms.Keys.S
        mrespStart.lHUI = 0 ' A on WingMan
        mrespStart.lTrigger = TRIGGER.A
        mrespNext.lKey = System.Windows.Forms.Keys.Space
        mrespNext.lHUI = 2 ' C on WingMan
        mrespNext.lTrigger = TRIGGER.A
        AddHandler HUI.Callback, AddressOf DirectXEvent

        ' init the experiment state and resize the form
        gexpState = EXPSTATE.expInit
        SetBreak(False)
        AllowResizing(False)

        ' clip cursor to the experiment screen if configured
        If gblnExperiment And CBool(mFlags And EXPFLAGS.expflClipMouseToWindow) Then
            ClipCursorToWindow(Handle.ToInt32, Left, Top, Width, Height)
        End If

        Return ""

SubErr:
        Me.Hide()
        gexpState = EXPSTATE.expUnInit
        Return "Init Experiment Form: " & vbCrLf & szErr
    End Function

    ''' <summary>
    ''' Unload Experimental screen
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UnloadMe()
        If gexpState = EXPSTATE.expUnInit Then Exit Sub
        If gexpState = EXPSTATE.expHidden Then Exit Sub
        ClipCursorToWindow(0)
        Me.Hide()
        gexpState = EXPSTATE.expHidden
    End Sub

    ''' <summary>
    ''' Disable response controls.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DisableResponse()
        Dim butX As Button
        If gexpState = EXPSTATE.expUnInit Then Exit Sub
        ' Tracker in ViWo?
        If gblnViWoLoaded And glTrackerMode = 2 Then
            glTrackerTriggerResponse = -1
            ViWo.Send("/Tracker/DisableResponse")
        End If
        For Each butX In butResponse
            ButtonState(butX, False)
        Next butX
        TextBoxState(textNum, False)
        If cmdStart.Visible Then ButtonState(cmdStart, False)
        If cmdNext.Visible Then ButtonState(cmdNext, False)
        If cmdCancel.Visible Then ButtonState(cmdCancel, False)
        mblnResponse = False
    End Sub

    ''' <summary>
    ''' Enable response controls.
    ''' </summary>
    ''' <param name="blnAutoDisable">If blnAutoDisable is TRUE the experimental screen will automatically turn to disabled mode after a valid response.</param>
    ''' <remarks>In ExpMode = 1 the first button remains disable until a valid numerical value is entered.</remarks>
    Public Sub EnableResponse(Optional ByVal blnAutoDisable As Boolean = True)
        Dim butX As Button

        If gexpState = EXPSTATE.expUnInit Then Return
        mlResponse = -1
        mblnAutoDisable = blnAutoDisable
        ' Track in ViWo?
        If gblnViWoLoaded And glTrackerMode = 2 Then
            glTrackerTriggerResponse = -1
            ViWo.Send("/Tracker/EnableResponse")
        End If
        If cmdCancel.Visible Then ButtonState(cmdCancel, True)
        Select Case gexpState
            Case EXPSTATE.expNext
                If cmdNext.Visible Then ButtonState(cmdNext, True)
            Case EXPSTATE.expStart
                If cmdStart.Visible Then ButtonState(cmdStart, True)
            Case EXPSTATE.expStim
                Select Case mlExpMode
                    Case 0, 2, 3, 4, 5, 6, 7
                        For Each butX In butResponse
                            ButtonState(butX, True)
                            butX.TabStop = False
                        Next butX
                    Case 1
                        If (mFlags And EXPFLAGS.expflResponseButtons) <> 0 Then
                            Dim lX As Integer
                            ButtonState(butResponse(0), False)
                            Me.AcceptButton = butResponse(0)
                            For lX = 1 To butResponse.Count - 1
                                ButtonState(butResponse(lX), True)
                            Next
                        End If
                        textNum.Text = ""
                        'bTextEntered = False
                        TextBoxState(textNum, True)
                        If gexpState = EXPSTATE.expStim Then textNum.Focus()
                End Select
        End Select
        mblnResponse = True
        If Me.Visible Then Me.Activate()
    End Sub

    ''' <summary>
    ''' Wait for next item.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WaitForNext() As Boolean

        WaitForNext = CBool(mFlags And EXPFLAGS.expflWaitForNext)

    End Function


    ''' <summary>
    ''' Get the response code.
    ''' </summary>
    ''' <param name="lResponse">Response code</param>
    ''' <returns>True if any response was given, False otherwise.</returns>
    ''' <remarks>Following codes are available:
    '''<li> 0: First response button (usually Left or OK) </li>
    '''<li> 1: Second response button (usually Right) </li>
    '''<li> ... </li>
    '''<li> ... </li>
    '''<li> N: N-th response button (maximum number defined by AFC on Init) </li>
    '''<li> ... </li>
    '''<li> ... </li>
    '''<li> 15: Last possible response button </li>
    '''<li> 256: Button "Start" </li>
    '''<li> 257: Button "Next" </li>
    '''<li> 258: Button "Cancel" </li> </remarks>
    Public Function GetResponse(ByRef lResponse As Integer, Optional ByRef ResponseTimeStamp As Date = Nothing) As Boolean

        If gexpState = EXPSTATE.expHidden Then Return False
        ' check if we have to discard waiting for next response
        If (gexpState = EXPSTATE.expNext) And (mFlags And EXPFLAGS.expflWaitForNext) = 0 And gblnWaitAfterBreak = False Then
            mlResponse = rNEXT
        End If
        If glTrackerTriggerResponse <> -1 Then mlResponse = glTrackerTriggerResponse
        ' get response
        If mblnAutoDisable Then
            ' auto disable control is active
            If mlResponse <> -1 Then
                lResponse = mlResponse
                mblnAutoDisable = False
                mblnResponse = False
                ResponseTimeStamp = mResponseTimeStamp
                Return True
            End If
            Return False
        Else
            ' auto disable control is not active
            If mlResponse <> -1 Then
                lResponse = mlResponse
                ResponseTimeStamp = mResponseTimeStamp
                Return True
            End If
            Return False
        End If

    End Function

    ''' <summary>
    ''' Set the response to a given code.
    ''' </summary>
    ''' <param name="lX">Code</param>
    ''' <remarks>See <see cref="SetResponse"/> to see the available codes.</remarks>
    Public Sub SetResponse(ByVal lX As Integer)
        mlResponse = lX
        glTrackerTriggerResponse = lX
    End Sub

    ''' <summary>
    ''' Get the response value from the subject.
    ''' </summary>
    ''' <returns>Value. This is defined for ExpMode 1 only and it will be a numeric value.</returns>
    ''' <remarks></remarks>
    Public Function GetValue() As Double
        If gexpState = EXPSTATE.expUnInit Then Return Nothing
        Select Case mlExpMode
            Case 0, 2, 3, 4, 5
                Return 0
            Case 1
                Return Val(Replace(textNum.Text, ",", "."))
        End Select
        Return Nothing
    End Function

    ''' <summary>
    ''' Show blank experimental screen.
    ''' </summary>
    ''' <param name="blnTop">If blnTop is true the experimental screen always will remain on top of the screen.</param>
    ''' <remarks></remarks>
    Public Sub ShowBlankScreen(ByVal blnTop As Boolean)
        If gexpState = EXPSTATE.expUnInit Then Exit Sub
        ' set window on top if necessary
        Me.TopMost = blnTop
        ' show/hide controls
        DisableResponse()
        tabExp.Visible = True
        tabExp.SelectedIndex = EXPTABINDEX.exptabBlank
        cmdNext.Visible = False
        fraProgress.Visible = False
        frmExp_Resize(Me, New System.EventArgs())
        ' set state
        gexpState = EXPSTATE.expBlank

    End Sub

    ''' <summary>
    ''' Show the experimental start screen.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowStartScreen()
        ShowStartScreen(mszStartText)
    End Sub

    ''' <summary>
    ''' Show Start screen.
    ''' </summary>
    ''' <param name="szText">Show text...</param>
    ''' <remarks></remarks>
    Public Sub ShowStartScreen(ByVal szText As String)
        If gexpState = EXPSTATE.expUnInit Then Exit Sub
        lblStart.Text = szText
        tabExp.SelectedIndex = EXPTABINDEX.exptabStart
        tabExp.Visible = True
        lblProgressText.Text = "Start"
        fraProgress.Visible = True
        cmdNext.Visible = False
        gexpState = EXPSTATE.expStart
    End Sub

    ''' <summary>
    ''' Show the experimental stimulation screen and highlight current stimulation interval.
    ''' </summary>
    ''' <param name="lIdx">Index of the highlighted interval. Use the response codes (see GetResponse) to select an interval or deselect all.</param>
    ''' <param name="lTime">ShowStimScreen (0) will be executed after lTime. If you don't want to use this feature ommit lTime or set it to zero.</param>
    ''' <remarks></remarks>
    Public Sub ShowStimScreen(ByVal lIdx As Integer, Optional ByVal lTime As Integer = 0)

        If gexpState = EXPSTATE.expUnInit Then Exit Sub
        If gexpState = EXPSTATE.expEnd Then Exit Sub ' set StartScreen first
        ' set timer to unhighlight items
        If CBool(lTime And CInt(lIdx <> rSTART)) Then
            If lTime = 0 Then
                tmrStimScreenNone.Enabled = False
            Else
                tmrStimScreenNone.Interval = lTime
                tmrStimScreenNone.Enabled = True
            End If
        End If
        ' show stimulation screen and unhighlight all items
        If lIdx = rSTART Or gexpState <> EXPSTATE.expStim Then
            ' first stimulation screen after any other screen -  show the start screen and set all visualisation controls to inactive
            cmdNext.Visible = False
            lblProgressText.Text = "Stimulus"
            fraProgress.Visible = True
            tabExp.SelectedIndex = mlExpMode + EXPTABINDEX.exptabStimBase : Application.DoEvents()
            tabExp.Visible = True
            ' coming from expNext mode? don't hide the feedback if Delay Request active
            If (gexpState = EXPSTATE.expNext) Then
                If ((mFlags And EXPFLAGS.expflDelayRequest) <> EXPFLAGS.expflDelayRequest) Then
                    lblRequest.Visible = True ' feedback not delayed - show request again
                    lblFeedback.Visible = False
                    'For Each lblX As Label In lblVisu
                    '    lblX.ForeColor = lblInactive.ForeColor
                    '    lblX.BackColor = lblInactive.BackColor
                    'Next lblX
                End If
            Else
                lblRequest.Visible = True ' not coming from expNext - show request for the first time
                lblFeedback.Visible = False
                'For Each lblX As Label In lblVisu
                '    lblX.ForeColor = lblInactive.ForeColor
                '    lblX.BackColor = lblInactive.BackColor
                'Next lblX
            End If

            For Each lblX As Label In lblVisu
                lblX.ForeColor = lblInactive.ForeColor
                If gbDarkMode Then
                    lblX.BackColor = Color.Black
                    lblX.BorderStyle = BorderStyle.None
                Else
                    lblX.BackColor = lblInactive.BackColor
                    lblX.BorderStyle = BorderStyle.FixedSingle
                End If
            Next lblX
            'Application.DoEvents()
            If gbDarkMode Then
                lblFeedback.BackColor = Color.Black
            Else
                lblFeedback.BackColor = System.Drawing.SystemColors.Control
            End If
            Application.DoEvents()

            ' resize
            frmExp_Resize(Me, New System.EventArgs())

            If CBool(mFlags And EXPFLAGS.expflResponseButtons) Then
                For Each butX As Button In butResponse
                    butX.Visible = True
                Next butX
            End If
        End If

        ' we're in expStim from now...
        gexpState = EXPSTATE.expStim

        ' highlight an item
        If lIdx <> rSTART Then
            For Each labX As Label In lblVisu
                Dim szArr() As String = Split(labX.Tag.ToString, " ")
                If CInt(Val(szArr(1))) = lIdx + 1 Then
                    labX.ForeColor = lblActive.ForeColor
                    labX.BackColor = lblActive.BackColor
                Else
                    labX.ForeColor = lblInactive.ForeColor
                    labX.BackColor = lblInactive.BackColor
                End If
            Next labX
        End If
        'Application.DoEvents()
        'If glExpType = 5 Then Mode5TrackBar.Select() ' I think this is wrong...
        If glExpMode(glExpType) = 5 Then Mode5TrackBar.Select()
    End Sub

    ''' <summary>
    ''' Show the experimental screen for the next stimulus.
    ''' </summary>
    ''' <param name="szFB">Text to be displayed on the screen, f.e. as a feedback.</param>
    ''' <param name="lForeColor">The color of the text given in szFB, otherwise use SystemColors.ControlText.</param>
    ''' <remarks>Calling ShowNextScreen, all interval will be deselected and the text szFB will be displayed.
    ''' The GetResponse procedure will wait for the next button (if used in Settings).</remarks>
    Public Sub ShowNextScreen(ByVal szFB As String, ByVal lForeColor As Color)
        If gexpState = EXPSTATE.expUnInit Then Exit Sub
        If gexpState <> EXPSTATE.expNext And gexpState <> EXPSTATE.expStim Then ShowStimScreen((rSTART))
        ' set up controls
        lblProgressText.Text = "Next"
        fraProgress.Visible = True
        If CBool(mFlags And EXPFLAGS.expflFeedback) Then
            lblRequest.Visible = False
            lblFeedback.Visible = False
            lblFeedback.Text = szFB
            If lForeColor <> Color.Empty Then lblFeedback.ForeColor = lForeColor
        End If
        lblFeedback.Visible = True
        If CBool(mFlags And EXPFLAGS.expflNextButton) Then
            cmdNext.Visible = True
            cmdNext.BringToFront()
        End If
        ' resize
        frmExp_Resize(Me, New System.EventArgs())
        'Application.DoEvents()

        ' set exp state
        gexpState = EXPSTATE.expNext

    End Sub

    ''' <summary>
    ''' Highlight an interval on the experimental screen.
    ''' </summary>
    ''' <param name="lItem">Index of the interval to be highlighted. Maximum value is IFC-1</param>
    ''' <param name="lForeColor">Color of the highlighted interval, otherwise use SystemColors.ControlText</param>
    ''' <remarks></remarks>
    Public Sub ShowHighlightedItem(ByVal lItem As Integer, ByVal lForeColor As Color)
        If gexpState = EXPSTATE.expUnInit Then Exit Sub
        If gexpState <> EXPSTATE.expNext And gexpState <> EXPSTATE.expStim Then ShowStimScreen((rSTART))
        ' set exp state
        gexpState = EXPSTATE.expNext
        ' set up controls
        lblProgressText.Text = "Next"
        If CBool(mFlags And EXPFLAGS.expflHighlight) Then
            If lItem < mlIFC Then lblVisu(lItem).ForeColor = lForeColor
            lblRequest.Visible = False
        End If
        If CBool(mFlags And EXPFLAGS.expflNextButton) Then
            cmdNext.Visible = True
            cmdNext.BringToFront()
        End If
    End Sub


    ''' <summary>
    ''' Show the end-of-experiment screen.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowEndScreen()
        If gexpState = EXPSTATE.expUnInit Then Exit Sub
        ' set exp state
        gexpState = EXPSTATE.expEnd
        ' set up controls
        tmrStimScreenNone.Enabled = False
        tabExp.SelectedIndex = EXPTABINDEX.exptabEnd
        tabExp.Visible = True
        lblProgressText.Text = "The End"
        fraProgress.Visible = True
        cmdNext.Visible = False
    End Sub

    ''' <summary>
    ''' Enable/disable resizing and moving the experiment screen.
    ''' </summary>
    ''' <param name="blnEnable">TRUE: resizing/moving enabled</param>
    ''' <remarks></remarks>
    Public Sub AllowResizing(ByVal blnEnable As Boolean)
        If gexpState = EXPSTATE.expUnInit Then Exit Sub
        If blnEnable Then
            If gbDarkMode Then
                Me.BackColor = Color.Black
                tabBlank.BackColor = System.Drawing.SystemColors.ControlDarkDark
            Else
                Me.BackColor = System.Drawing.SystemColors.ControlDark
                tabBlank.BackColor = System.Drawing.SystemColors.ControlDark
            End If
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            tabExp.Dock = DockStyle.Fill
        Else
            If gbDarkMode Then
                Me.BackColor = Color.Black
                tabBlank.BackColor = System.Drawing.SystemColors.ControlDarkDark
                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

                tabExp.Dock = DockStyle.None
                tabExp.Left = -10
                tabExp.Width = Me.Width - 2 * tabExp.Left
                tabExp.Top = -10
                tabExp.Height = Me.Height - 60

            Else
                Me.BackColor = System.Drawing.SystemColors.Control
                tabBlank.BackColor = System.Drawing.SystemColors.Control
                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
                tabExp.Dock = DockStyle.Fill
            End If
        End If

    End Sub

    ''' <summary>
    ''' Get the size and position of the experimental screen.
    ''' </summary>
    ''' <param name="lLeft">Left position</param>
    ''' <param name="lWidth">Width</param>
    ''' <param name="lTop">Top position</param>
    ''' <param name="lHeight">Height</param>
    ''' <remarks></remarks>
    Sub GetSize(ByRef lLeft As Integer, ByRef lWidth As Integer, _
                ByRef lTop As Integer, ByRef lHeight As Integer)
        If gexpState = EXPSTATE.expUnInit Then Exit Sub
        lLeft = Me.Left
        lWidth = Me.Width
        lTop = Me.Top
        lHeight = Me.Height
    End Sub

    ''' <summary>
    ''' Set the size and position of the experimental screen.
    ''' </summary>
    ''' <param name="lLeft">Left position</param>
    ''' <param name="lWidth">Width</param>
    ''' <param name="lTop">Top position</param>
    ''' <param name="lHeight">Height</param>
    ''' <remarks></remarks>
    Sub SetSize(ByVal lLeft As Integer, ByVal lWidth As Integer, _
                ByVal lTop As Integer, ByVal lHeight As Integer)
        If gexpState = EXPSTATE.expUnInit Then Exit Sub
        If lWidth < Me.MinimumSize.Width Then Return
        If lHeight < Me.MinimumSize.Height Then Return
        Me.Location = New Drawing.Point(lLeft, lTop)
        Me.Size = New Drawing.Size(lWidth, lHeight)
        frmExp_Resize(Me, New System.EventArgs())
    End Sub

    ''' <summary>
    ''' Set the experimental state to "break"
    ''' </summary>
    ''' <param name="blnBreak">TRUE: break active.</param>
    ''' <remarks></remarks>
    Sub SetBreak(ByVal blnBreak As Boolean)
        'Dim lX As Integer
        mblnBreak = blnBreak
        If lblProgress.InvokeRequired Then Err.Raise(vbObjectError, "frmExp.SetBreak.lblprogress", "invokerequired")
        If mblnBreak Then
            ' ... also executed in SetProgress
            lblProgress.Text = mszBreakText
            'lblProgress.Font = New Font(lblProgress.Font.Name, 24, lblProgress.Font.Style)
            lblProgress.ForeColor = System.Drawing.Color.Red
            tmrBreak.Enabled = True
            ClipCursorToWindow(0)
        Else
            tmrBreak.Enabled = False
            'lblProgress.Font = New Font(lblProgress.Font.Name, 12, lblProgress.Font.Style)
            lblProgress.ForeColor = Drawing.SystemColors.ControlText
            lblProgress.Visible = True
            If (mFlags And EXPFLAGS.expflHideProgress) <> 0 Then
                lblProgress.Text = ""
            Else
                'lblProgress.Text = TStr(Math.Round(pbProgress.Value, 1)) & " %"
                lblProgress.Text = Replace(VB6.Format(pbProgress.Value, "0.0"), ",", ".") & " %" ' Show as "#.# %"

            End If
            If gblnExperiment And CBool(mFlags And EXPFLAGS.expflClipMouseToWindow) Then
                ClipCursorToWindow(Handle.ToInt32, Left, Top, Width, Height)
            End If
            If Me.Visible Then Me.Activate()
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        If gexpState = EXPSTATE.expUnInit Then Exit Sub
        ' experiment running?
        If gexpState = EXPSTATE.expNext Or gexpState = EXPSTATE.expStart Or gexpState = EXPSTATE.expStim Then
            If MsgBox("You're going to cancel experiment." & vbCrLf & "Do you really want to cancel?", CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo) + CInt(MsgBoxStyle.DefaultButton2), Microsoft.VisualBasic.MsgBoxStyle)) = MsgBoxResult.Yes Then
                mlResponse = rCANCEL
                mblnResponse = True
                If mblnAutoDisable Then DisableResponse()
            End If
        Else
            mlResponse = rCANCEL
            mblnResponse = True
        End If
    End Sub

    Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
        If gexpState = EXPSTATE.expUnInit Then Exit Sub
        mlResponse = rNEXT
        If mblnAutoDisable Then DisableResponse()
    End Sub

    ' all responses go here
    Private Sub butResponse_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        If gexpState = EXPSTATE.expUnInit Then Exit Sub
        mResponseTimeStamp = DateTime.Now
        mlResponse = butResponse.IndexOf(DirectCast(eventSender, Button))
        If mblnAutoDisable Then DisableResponse()
    End Sub

    Private Sub cmdStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStart.Click
        If gexpState = EXPSTATE.expUnInit Then Exit Sub
        mlResponse = rSTART
        If mblnAutoDisable Then DisableResponse()
        QueryPerformanceCounter(gcurHPTic) ' reset timer on start click
        frmMain.tmrStatus.Enabled = gblnExperiment
    End Sub

    Public Sub DirectXEvent(ByVal bButtons() As Byte, ByVal lXDir As Integer, ByVal lYDir As Integer, ByVal lZDir As Integer)

        If gexpState = EXPSTATE.expUnInit Then Return
        ' check if response allowed
        If Not mblnResponse Then Return

        ' emulate buttons
        If IsNothing(bButtons) Then Return
        If bButtons.Length = 0 Then Return
        Dim lButtons As Integer = 0
        Dim lButtonCnt As Integer = bButtons.Length
        If lButtonCnt > 30 Then lButtonCnt = 30 ' only 30 buttons supported
        If mlJoypadIndex = -1 Then
            ' unknown joypad - don't map
            For lX As Integer = 0 To lButtonCnt - 1
                If bButtons(lX) > 0 Then lButtons = lButtons Or CInt(2 ^ lX)
            Next
            If lXDir < -100 Then lButtons = lButtons Or CInt(2 ^ (9))
            If lXDir > 100 Then lButtons = lButtons Or CInt(2 ^ (9 + 1))
            If lYDir < -100 Then lButtons = lButtons Or CInt(2 ^ (9 + 2))
            If lYDir > 100 Then lButtons = lButtons Or CInt(2 ^ (9 + 3))
            If lZDir < -100 Then lButtons = lButtons Or CInt(2 ^ (9 + 4))
            If lZDir > 100 Then lButtons = lButtons Or CInt(2 ^ (9 + 5))
        Else
            ' use joypad mapping 
            For lX As Integer = 0 To lButtonCnt - 1
                If bButtons(lX) > 0 Then
                    If IsNothing(JoyPads(mlJoypadIndex).ResponseCodes) Then
                        lButtons = lButtons Or CInt(2 ^ lX) ' no codes found - don't map
                    Else    ' search for the mapped key
                        For lY As Integer = 0 To JoyPads(mlJoypadIndex).ResponseCodes.Length - 1
                            If JoyPads(mlJoypadIndex).ResponseCodes(lY) = lX Then lButtons = lButtons Or CInt(2 ^ lY)
                        Next
                    End If
                End If
            Next
            If lXDir < -100 Then
                For lY As Integer = 0 To JoyPads(mlJoypadIndex).ResponseCodes.Length - 1
                    If JoyPads(mlJoypadIndex).ResponseCodes(lY) = -2 Then lButtons = lButtons Or CInt(2 ^ lY)
                Next
            End If
            If lXDir > 100 Then
                For lY As Integer = 0 To JoyPads(mlJoypadIndex).ResponseCodes.Length - 1
                    If JoyPads(mlJoypadIndex).ResponseCodes(lY) = -3 Then lButtons = lButtons Or CInt(2 ^ lY)
                Next
            End If
            If lYDir < -100 Then
                For lY As Integer = 0 To JoyPads(mlJoypadIndex).ResponseCodes.Length - 1
                    If JoyPads(mlJoypadIndex).ResponseCodes(lY) = -4 Then lButtons = lButtons Or CInt(2 ^ lY)
                Next
            End If
            If lYDir > 100 Then
                For lY As Integer = 0 To JoyPads(mlJoypadIndex).ResponseCodes.Length - 1
                    If JoyPads(mlJoypadIndex).ResponseCodes(lY) = -5 Then lButtons = lButtons Or CInt(2 ^ lY)
                Next
            End If
            If lZDir < -100 Then
                For lY As Integer = 0 To JoyPads(mlJoypadIndex).ResponseCodes.Length - 1
                    If JoyPads(mlJoypadIndex).ResponseCodes(lY) = -6 Then lButtons = lButtons Or CInt(2 ^ lY)
                Next
            End If
            If lZDir > 100 Then
                For lY As Integer = 0 To JoyPads(mlJoypadIndex).ResponseCodes.Length - 1
                    If JoyPads(mlJoypadIndex).ResponseCodes(lY) = -7 Then lButtons = lButtons Or CInt(2 ^ lY)
                Next
            End If
        End If
        If lButtons = 0 Then Return

        mResponseTimeStamp = DateTime.Now
        Select Case gexpState
            Case EXPSTATE.expStart
                ' check only start button
                If (lButtons And CInt(2 ^ mrespStart.lHUI)) <> 0 Then
                    mlResponse = rSTART
                    If Not IsNothing(mlOnResponseAddr) Then mlOnResponseAddr(mlResponse)
                    If mblnAutoDisable Then DisableResponse()
                End If
                Exit Sub
            Case EXPSTATE.expBlank
                ' check all buttons
                For lX As Integer = 0 To 30
                    If (lButtons And CInt(2 ^ lX)) <> 0 Then
                        mlResponse = lX ' save first button
                        If mblnAutoDisable Then DisableResponse() ' disable further buttons
                        Return
                    End If
                Next
            Case EXPSTATE.expNext
                If mblnBreak Then Exit Sub ' break? -> ignore any button
                ' check only next button
                If (lButtons And CInt(2 ^ mrespNext.lHUI)) <> 0 Then
                    mlResponse = rNEXT
                    If Not IsNothing(mlOnResponseAddr) Then mlOnResponseAddr(mlResponse)
                    If mblnAutoDisable Then DisableResponse()
                End If
                Exit Sub
            Case EXPSTATE.expStim
                ' check response buttons
                For lX As Integer = 0 To UBound(mrespArr)
                    If (lButtons And CInt(2 ^ mrespArr(lX).lHUI)) <> 0 Then
                        mlResponse = lX ' get the first button
                        If Not IsNothing(mlOnResponseAddr) Then mlOnResponseAddr(mlResponse)
                        If mblnAutoDisable Then DisableResponse()
                        Exit Sub
                    End If
                Next
            Case Else
                ' nothing...
        End Select
    End Sub

    Private Sub frmExp_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        If Me.IsInitializing = True Then
            Exit Sub
        ElseIf gblnExperiment And CBool(mFlags And EXPFLAGS.expflClipMouseToWindow) Then
            ClipCursorToWindow(Handle.ToInt32, Left, Top, Width, Height)
        End If
    End Sub

    Private Sub frmExp_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim Shift As Short = CType(eventArgs.KeyData \ &H10000, Short)
        If gexpState = EXPSTATE.expUnInit Then Exit Sub
        mResponseTimeStamp = DateTime.Now
        Dim lX As Integer
        'Debug.Print(eventArgs.KeyCode.ToString)
        Select Case eventArgs.KeyCode
            Case System.Windows.Forms.Keys.Escape
                ClipCursorToWindow(0)
                ' experiment pending?
                If gblnExperiment Then
                    If MsgBox("You're going to cancel experiment." & vbCrLf & "Do you really want to cancel?", CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo) + CInt(MsgBoxStyle.DefaultButton2), Microsoft.VisualBasic.MsgBoxStyle)) = MsgBoxResult.Yes Then
                        mlResponse = rCANCEL
                        gblnCancel = True
                        mblnResponse = True
                        Exit Sub
                    End If
                Else
                    ' no experiment pending -> hide me
                    UnloadMe()
                End If
            Case System.Windows.Forms.Keys.B
                frmMain.chkExpRun.CheckState = System.Windows.Forms.CheckState.Unchecked
            Case System.Windows.Forms.Keys.Pause     ' Break-key is for continue
                frmMain.chkExpRun.CheckState = System.Windows.Forms.CheckState.Checked
            Case System.Windows.Forms.Keys.F1
                ClipCursorToWindow(0)
                ' experiment pending?
                If gblnExperiment Then
                    ' experiment pending -> cancel
                    If MsgBox("You're going to cancel experiment." & vbCrLf & "Do you really want to cancel?", CType(CInt(MsgBoxStyle.Question) + CInt(MsgBoxStyle.YesNo) + CInt(MsgBoxStyle.DefaultButton2), Microsoft.VisualBasic.MsgBoxStyle)) = MsgBoxResult.Yes Then
                        'UnloadMe()
                        mlResponse = rCANCEL
                        mblnResponse = True
                        gblnCancel = True
                        Exit Sub
                    End If
                Else
                    ' no experiment pending -> hide me
                    UnloadMe()
                End If
            Case Else ' save response
                If Not mblnResponse Then Exit Sub ' response disabled
                ' select experiment state
                Select Case gexpState
                    Case EXPSTATE.expStart
                        ' respond on start key only
                        If mrespStart.lKey = CType(eventArgs.KeyCode, Integer) Then
                            mlResponse = rSTART
                            If Not IsNothing(mlOnResponseAddr) Then mlOnResponseAddr(mlResponse)
                            If mblnAutoDisable Then DisableResponse()
                        End If
                        QueryPerformanceCounter(gcurHPTic) ' reset timer on start click
                        frmMain.tmrStatus.Enabled = gblnExperiment
                    Case EXPSTATE.expNext
                        If mblnBreak Then Exit Sub ' break? -> ignore any key
                        ' respond on next button only
                        If mrespNext.lKey = CType(eventArgs.KeyCode, Integer) Then
                            mlResponse = rNEXT
                            If Not IsNothing(mlOnResponseAddr) Then mlOnResponseAddr(mlResponse)
                            If mblnAutoDisable Then DisableResponse()
                        End If
                    Case EXPSTATE.expStim
                        ' respond on response keys
                        For lX = 0 To UBound(mrespArr)
                            If (mrespArr(lX).lKey = CType(eventArgs.KeyCode, Integer)) And butResponse(lX).Enabled Then
                                mlResponse = lX ' get the first button
                                If Not IsNothing(mlOnResponseAddr) Then mlOnResponseAddr(mlResponse)
                                If mblnAutoDisable Then DisableResponse()
                                Exit Sub
                            End If
                        Next
                    Case Else
                        ' respond on all keys
                        mlResponse = CType(eventArgs.KeyCode, Integer)
                        If mblnAutoDisable Then DisableResponse()
                End Select
        End Select
    End Sub
    Public Sub FirstInitialize()

    End Sub

    Private Sub frmExp_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown, fraProgress.MouseDown, tabBlank.MouseDown
        If CBool(eventArgs.Button And Windows.Forms.MouseButtons.Right) Then
            ' right click
            Select Case gexpState
                Case EXPSTATE.expNext
                    If Not mblnResponse Then Exit Sub ' response disabled
                    mlResponse = rNEXT
                    If mblnAutoDisable Then DisableResponse()
                    Exit Sub
                Case EXPSTATE.expStart
                    If Not mblnResponse Then Exit Sub ' response disabled
                    mlResponse = rSTART
                    If mblnAutoDisable Then DisableResponse()
                    Exit Sub
            End Select
        End If
        If CBool(eventArgs.Button And Windows.Forms.MouseButtons.Left) Then
            ' left click
            If Me.FormBorderStyle <> Windows.Forms.FormBorderStyle.Sizable Then Return
            If eventArgs.Button = Windows.Forms.MouseButtons.Left Then
                rectMouse.Left = CInt(eventArgs.X)
                rectMouse.Top = CInt(eventArgs.Y)
                blnMouseDown = True
            End If
        End If
    End Sub

    Private Sub frmExp_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove, fraProgress.MouseMove, tabBlank.MouseMove
        If Not blnMouseDown Then Exit Sub
        If blnMoved Then blnMoved = False : Exit Sub
        Dim X As Single = eventArgs.X
        Dim Y As Single = eventArgs.Y
        If CInt(X) <> rectMouse.Left Or CInt(Y) <> rectMouse.Top Then
            Me.SetBounds((Me.Left + CInt(X) - rectMouse.Left), (Me.Top + CInt(Y) - rectMouse.Top), 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
            blnMoved = True
        End If
    End Sub

    Private Sub frmExp_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp, fraProgress.MouseUp, tabBlank.MouseUp
        blnMouseDown = False
    End Sub

    Private Sub frmExp_Paint(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        If gblnExperiment And CBool(mFlags And EXPFLAGS.expflClipMouseToWindow) Then
            ClipCursorToWindow(Handle.ToInt32, Left, Top, Width, Height)
        End If
    End Sub

    Private Sub frmExp_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        ClipCursorToWindow(0)
        HUI.ReleaseDevice()
        RemoveHandler HUI.Callback, AddressOf Me.DirectXEvent
        eventArgs.Cancel = Cancel
    End Sub

    Private Sub frmExp_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.ResizeEnd
        If Me.IsInitializing = True Then Return
        Dim lY, lX, lZ As Integer
        Dim lDist As Integer
        Dim lEM As Integer

        ' let's resize all controls:
        '
        ' Legend:
        ' FH/V: flipped horizontal/vertical
        ' CH/V: centered horizontal/vertical
        ' M: maximized
        ' ST/B/L/R: sticked to top/bottom/left/right
        ' Spb: sticked to progress bar frame

        lEM = mlExpMode

        If gbDarkMode And tabExp.Dock <> DockStyle.Fill Then
            tabExp.Left = -10
            tabExp.Width = Me.Width - 2 * tabExp.Left
            tabExp.Top = -10
            tabExp.Height = Me.Height - 60
        End If

        Select Case lEM
            Case 0 ' nAFC/mIFC, visu vertical, response horizontal
                If CBool(mFlags And EXPFLAGS.expflResponseButtons) Then
                    lY = CInt(Math.Round((5 / 6 * tabExp.Height) / (4 * mlIFC + 1 + 2)))
                Else
                    lY = CInt(Math.Round((tabExp.Height) / (4 * mlIFC + 1 + 2)))
                End If
                For lX = 0 To mlIFC - 1
                    lblVisu(lX).Height = 3 * lY
                    If lX > 0 Then
                        lblVisu(lX).Top = lX * 4 * lY + lY * 3
                    Else
                        lblVisu(lX).Top = lX * 4 * lY + lY
                    End If
                    lblVisu(lX).Font = VB6.FontChangeSize(lblVisu(lX).Font, CSng(72 / 1600 * VB6.PixelsToTwipsY(lblVisu(lX).Height)))
                    lblVisu(lX).Width = lblVisu(lX).Height
                    lblVisu(lX).Left = (tabExp.Width - lblVisu(lX).Width) \ 2 'CH
                Next
                'Video Player
                'AxWindowsMediaPlayerMode0.Top = lblVisu(0).Top \ 2
                'AxWindowsMediaPlayerMode0.Height = lblVisu(lX - 1).Top + 5 * lblVisu(lX - 1).Height \ 4 - AxWindowsMediaPlayerMode0.Top
                'AxWindowsMediaPlayerMode0.Width = Math.Min(Me.Width - 100, AxWindowsMediaPlayerMode0.Height * 16 \ 9)
                'AxWindowsMediaPlayerMode0.Left = (Me.Width - AxWindowsMediaPlayerMode0.Width) \ 2
                'AxWindowsMediaPlayerMode0.uiMode = "none"

                'Picture Box
                pbMode0.Top = lblVisu(0).Top \ 2

                Dim pbMode0Height As Integer = lblVisu(lX - 1).Top + 5 * lblVisu(lX - 1).Height \ 4 - pbMode0.Top
                Dim pbMode0Width As Integer = Math.Min(Me.Width - 100, pbMode0Height * 16 \ 9)
                'pbMode0.Height = lblVisu(lX - 1).Top + 5 * lblVisu(lX - 1).Height \ 4 - pbMode0.Top
                'pbMode0.Width = Math.Min(Me.Width - 100, pbMode0.Height * 16 \ 9)
                pbMode0.MaximumSize = New Size(pbMode0Width, pbMode0Height)
                pbMode0.MinimumSize = New Size(pbMode0Width, pbMode0Height)

                pbMode0.Left = (Me.Width - pbMode0Width) \ 2

                lblRequest.Top = lblVisu(0).Top + lblVisu(0).Height + CInt(Math.Round(1.5 * CDbl(lY) - CDbl(lblRequest.Height) / 2))
                lblRequest.Font = VB6.FontChangeSize(lblRequest.Font, CSng(20 / 800 * VB6.PixelsToTwipsY(lY)))
                lblRequest.Left = (tabExp.Width - lblRequest.Width) \ 2 'CH
                lY = 5 * tabExp.Height \ 6
                butResponse(0).Width = tabExp.Width \ mlAFC \ 3
                lDist = tabExp.Width \ 2 - (mlAFC * butResponse(0).Width + (mlAFC - 1) * butResponse(0).Width \ 2) \ 2
                lZ = lDist
                For lX = 0 To mlAFC - 1
                    butResponse(lX).Top = lY
                    butResponse(lX).Height = (tabExp.Height - lY) \ 2
                    butResponse(lX).Left = lDist
                    butResponse(lX).Width = butResponse(0).Width
                    butResponse(lX).Font = VB6.FontChangeSize(butResponse(lX).Font, (CLng(Val(lblRequest.Font.Size * 6)) \ 10))
                    lDist = lDist + 3 * butResponse(0).Width \ 2
                Next

            Case 5 ' 
                lY = CInt(Math.Round((tabExp.Height) / (4 * mlIFC + 1 + 2))) 'adjust height
                For lX = 0 To mlIFC - 1 'highlighted numbers
                    lblVisu(lX).Height = CInt(2 * lY)
                    lblVisu(lX).Top = lX * 4 * lY + lY * 4
                    lblVisu(lX).Font = VB6.FontChangeSize(lblVisu(lX).Font, CSng(72 / 1600 * VB6.PixelsToTwipsY(lblVisu(lX).Height)))
                    lblVisu(lX).Width = lblVisu(lX).Height
                    lblVisu(lX).Left = (tabExp.Width - lblVisu(lX).Width) \ 2
                Next

                lblRequest.Top = lblVisu(0).Top - CInt(Math.Round(3.5 * CDbl(lY) - CDbl(lblRequest.Height) / 10))
                lblRequest.Font = VB6.FontChangeSize(lblRequest.Font, CSng(13 / 800 * VB6.PixelsToTwipsY(lY)))
                lblRequest.Left = (tabExp.Width - lblRequest.Width) \ 2 'CH
                'lY = 5 * tabExp.Height \ 6
                'lDist = tabExp.Width \ 2 - (mlAFC * butResponse(0).Width + (mlAFC - 1) * butResponse(0).Width \ 2) \ 2
                'lZ = lDist
                lY = CInt(Math.Round((tabExp.Height) / (4 * mlAFC + 1 + 2))) 'adjust height
                For lX = 0 To mlAFC - 1
                    butResponse(lX).Height = CInt(1.2 * lY)
                    butResponse(lX).Top = CInt(lX * 4 * lY + lY * 3.8)
                    butResponse(lX).Width = butResponse(lX).Height * 2
                    butResponse(lX).Left = (tabExp.Width * 2 + lblVisu(0).Width) \ 3 'buttons
                    butResponse(lX).Font = VB6.FontChangeSize(lblRequest.Font, CSng(10 / 800 * VB6.PixelsToTwipsY(lY)))
                Next

            Case 4 ' nAFC/mIFC, visu & response vertical
                lY = CInt(Math.Round((tabExp.Height) / (4 * mlIFC + 1 + 2))) 'adjust height
              
                'End If
                For lX = 0 To mlIFC - 1 'highlighted numbers
                    lblVisu(lX).Height = 3 * lY
                    lblVisu(lX).Top = lX * 4 * lY + lY * 3
                    If gbDarkMode Then ' font size
                        lblVisu(lX).Font = VB6.FontChangeSize(lblVisu(lX).Font, CSng(10 / 1600 * VB6.PixelsToTwipsY(lblVisu(lX).Height)))
                    Else
                        lblVisu(lX).Font = VB6.FontChangeSize(lblVisu(lX).Font, CSng(72 / 1600 * VB6.PixelsToTwipsY(lblVisu(lX).Height)))
                    End If
                    lblVisu(lX).Width = lblVisu(lX).Height
                    If CBool(mFlags And EXPFLAGS.expflResponseButtons) Then
                        lblVisu(lX).Left = (tabExp.Width * 2 - lblVisu(lX).Width * 5) \ 4 'labels
                    Else
                        lblVisu(lX).Left = (tabExp.Width - lblVisu(lX).Width) \ 2 'labels
                    End If
                Next
                'lY = 5 * tabExp.Height \ 6
                'lDist = tabExp.Width \ 2 - (mlAFC * butResponse(0).Width + (mlAFC - 1) * butResponse(0).Width \ 2) \ 2
                'lZ = lDist
                Dim lY2 As Integer = CInt(Math.Round((tabExp.Height) / (4 * mlAFC + 1 + 2))) 'adjust height
                For lX = 0 To mlAFC - 1
                    butResponse(lX).Top = lX * 4 * lY2 + lY2 * 3
                    butResponse(lX).Height = 3 * lY2
                    'butResponse(lX).Font = VB6.FontChangeSize(butResponse(lX).Font, CSng(30 / 800 * VB6.PixelsToTwipsY(butResponse(lX).Height)))
                    butResponse(lX).Width = 3 * lY2
                    butResponse(lX).Left = (tabExp.Width * 2 + 3 * lY2) \ 4 'buttons
                Next

                lblRequest.Top = Math.Min(butResponse(0).Top, lblVisu(0).Top) - CInt(Math.Round(2 * CDbl(Math.Min(lY, lY2)) - CDbl(lblRequest.Height) / 10))
                'lblRequest.Top = Math.Min(butResponse(0).Top, lblVisu(0).Top) - CInt(Math.Round(2 * CDbl(lY) - CDbl(lblRequest.Height) / 10))
                lblRequest.Font = VB6.FontChangeSize(lblRequest.Font, CSng(30 / 800 * VB6.PixelsToTwipsY(lY)))
                lblRequest.Left = (tabExp.Width - lblRequest.Width) \ 2 'CH

            Case 1 ' openNUM/mIFC
                lblRequest.Top = 2 * tabExp.Height \ 3
                lY = (lblRequest.Top) \ (4 * mlIFC + 1)
                For lX = 0 To mlIFC - 1
                    lblVisu(lX).Height = 3 * lY
                    lblVisu(lX).Top = lX * 4 * lY + lY
                    lblVisu(lX).Font = VB6.FontChangeSize(lblVisu(lX).Font, CSng(72 / 1600 * VB6.PixelsToTwipsY(lblVisu(lX).Height)))
                    lblVisu(lX).Width = lblVisu(lX).Height
                    lblVisu(lX).Left = (tabExp.Width - lblVisu(lX).Width) \ 2 'CH
                Next
                lblRequest.Font = VB6.FontChangeSize(lblRequest.Font, CSng(24 / 800 * VB6.PixelsToTwipsY(lY)))
                lblRequest.Left = (tabExp.Width - lblRequest.Width) \ 2 'CH
                lY = tabExp.Height - (lblRequest.Top + lblRequest.Height)
                textNum.Top = (lblRequest.Top + lblRequest.Height + (lY - butResponse(0).Height) \ 2)
                textNum.Font = VB6.FontChangeSize(textNum.Font, lblRequest.Font.SizeInPoints)
                textNum.Height = CInt(Math.Round(textNum.Font.SizeInPoints * 36))
                'textNum.Height = 44
                If CBool(mFlags And EXPFLAGS.expflResponseButtons) Then
                    lDist = butResponse(0).Width \ 3
                    textNum.Left = (tabExp.Width \ 2 - textNum.Width - lDist)
                    For lX = 0 To mlAFC - 1
                        butResponse(lX).Width = butResponse(0).Width
                        butResponse(lX).Height = textNum.Height ' CInt(textNum.Height * 1.2)
                        butResponse(lX).Left = tabExp.Width \ 2 + lX * butResponse(0).Width + (lX + 1) * lDist
                        butResponse(lX).Top = textNum.Top ' - textNum.Height \ 10  ' lblRequest.Top + lblRequest.Height + (lY - butResponse(0).Height) \ 2
                    Next
                Else
                    textNum.Left = (tabExp.Width - textNum.Width) \ 2
                End If
            Case 2 ' BLB: 4 AFC/ 2 IFC

                lY = tabExp.Width \ 2 'vertical center line

                butResponse(0).Width = lY \ 4
                butResponse(1).Width = lY \ 4
                butResponse(2).Width = lY \ 4
                butResponse(3).Width = lY \ 4

                butResponse(0).Left = lY - butResponse(0).Width \ 2 'centered
                butResponse(1).Left = lY - butResponse(1).Width \ 2 'centered
                butResponse(2).Left = (lY \ 2) - butResponse(2).Width
                butResponse(3).Left = (lY * 3) \ 2

                lblVisu(0).Width = lY \ 4
                lblVisu(1).Width = lY \ 4
                lblVisu(0).Height = lY \ 4
                lblVisu(1).Height = lY \ 4

                lblVisu(0).Left = lY - lblVisu(0).Width \ 2
                lblVisu(1).Left = lY - lblVisu(1).Width \ 2
                '     lblRequest.Left = lY - lblRequest.Width \ 2 'CH

                lblRequest.Top = (tabExp.Height - 10) \ 2 '(lblVisu(1).Top - (lblVisu(0).Top + lblVisu(0).Height)) \ 2 + (lblVisu(0).Top + lblVisu(0).Height) 'lblVisu(0).Top(tabExp.Height) \ 2 ' center 

                butResponse(0).Height = tabExp.Height \ 10
                butResponse(1).Height = tabExp.Height \ 10
                butResponse(2).Height = tabExp.Height \ 10
                butResponse(3).Height = tabExp.Height \ 10

                butResponse(0).Top = CInt(lblVisu(0).Top - 1.2 * butResponse(0).Height)
                butResponse(1).Top = CInt(lblVisu(1).Top + lblVisu(1).Height + butResponse(1).Height / 5)

                'butResponse(3).Left = (lY + butResponse(3).Width) \ 2
                ' butResponse(3).Left = lY + lX - butResponse(3).Width \ 2
            Case 3 ' nAFC/mIFC, visu and response horizontal
                If CBool(mFlags And EXPFLAGS.expflResponseButtons) Then
                    lblRequest.Top = 2 * tabExp.Height \ 3
                Else
                    lblRequest.Top = (3 * tabExp.Height \ 2 - lblRequest.Height) \ 2
                End If
                lY = lblRequest.Top \ 2
                lX = (tabExp.Width) \ (mlIFC + (mlIFC - 1) \ 4 + 1)
                If lX < lY Then lY = lX 'lY: max size of lblVisu
                lX = (tabExp.Width - mlIFC * lY - (mlIFC - 1) * lY \ 4) \ 2
                For lZ = 0 To mlIFC - 1
                    lblVisu(lZ).Width = lY
                    lblVisu(lZ).Height = lY
                    lblVisu(lZ).Left = lX + lZ * 5 * lY \ 4
                    lblVisu(lZ).Font = VB6.FontChangeSize(lblVisu(lZ).Font, CSng(72 / 1600 * VB6.PixelsToTwipsX(lblVisu(lZ).Width)))
                    lblVisu(lZ).Top = (lblRequest.Top - lY) \ 2 'CH
                Next
                lblRequest.Font = VB6.FontChangeSize(lblRequest.Font, CSng(5 / 1600 * VB6.PixelsToTwipsY(tabExp.Height)))
                lblRequest.Left = (tabExp.Width - lblRequest.Width) \ 2 'CH
                lY = tabExp.Height - (lblRequest.Top + lblRequest.Height)
                'lDist = (tabExp.Width - mlAFC * butResponse(0).Width - (mlAFC - 1) * 0.25 * butResponse(0).Width) / 2
                lDist = 0
                lZ = lDist
                For lX = 0 To mlAFC - 1
                    butResponse(lX).Top = lblRequest.Top + lblRequest.Height + (lY - butResponse(lX).Height) \ 2
                    butResponse(lX).Width = tabExp.Width \ mlAFC - 4
                    butResponse(lX).Left = lX * butResponse(0).Width - 2 + (lX * 4)
                    butResponse(lX).Height = tabExp.Height \ 8  ' lblRequest.Top + lblRequest.Height + (lY - butResponse(0).Height) \ 2
                    butResponse(lX).Font = VB6.FontChangeSize(butResponse(lX).Font, (CLng(Val(lblRequest.Font.Size * 6)) \ 10))
                Next
            Case 6

                lY = tabExp.Width \ 2 'vertical center line

                butResponse(0).Width = lY \ 2
                butResponse(1).Width = butResponse(0).Width

                'butResponse(0).Left = lY \ 4
                'butResponse(1).Left = lY + lY \ 4
                butResponse(0).Left = lY - lY \ 4
                butResponse(1).Left = butResponse(0).Left

                lZ = tabExp.Height \ 2 'horizontal center line

                butResponse(0).Height = lZ \ 2
                butResponse(1).Height = butResponse(0).Height

                'butResponse(0).Top = lZ * 2 \ 5
                'butResponse(1).Top = butResponse(0).Top
                butResponse(0).Top = lZ \ 4
                butResponse(1).Top = lZ + lZ \ 4

                For lL As Integer = 0 To lblVisu.Count - 1 'hide lblVisus
                    lblVisu(lL).Visible = False
                Next

                lblRequest.Font = VB6.FontChangeSize(lblRequest.Font, CSng(4 / 1600 * VB6.PixelsToTwipsY(tabExp.Height)))
                lblRequest.Top = CInt(lZ - CLng(lblRequest.Height) \ 2)  ' tabExp.Height * 4 \ 5 ' lZ * 3 \ 2 '(tabExp.Height - 10) \ 2 '(lblVisu(1).Top - (lblVisu(0).Top + lblVisu(0).Height)) \ 2 + (lblVisu(0).Top + lblVisu(0).Height) 'lblVisu(0).Top(tabExp.Height) \ 2 ' center 
                lblRequest.Left = lY - lblRequest.Width \ 2

                butResponse(0).Font = VB6.FontChangeSize(butResponse(0).Font, (CLng(Val(lblRequest.Font.Size * 2))))
                butResponse(1).Font = butResponse(0).Font

                p6Text.Font = VB6.FontChangeSize(p6Text.Font, CSng(1 / 80 * VB6.PixelsToTwipsY(tabExp.Height)))
                p6Text.Top = tabExp.Height * 4 \ 10

            Case 7
                ''If CBool(mFlags And EXPFLAGS.expflResponseButtons) Then
                ''    lY = CInt(Math.Round((5 / 6 * tabExp.Height) / (4 * mlIFC + 1 + 2)))
                ''Else
                Application.DoEvents()

                lY = tabExp.Width \ 2 'vertical center line
                lZ = tabExp.Height \ 2 'horizontal center line

                lDist = (tabExp.Height - lZ) \ 5
                gbQ7a.Top = lZ
                gbQ7b.Top = lZ + lDist
                gbQ7c.Top = lZ + lDist * 2
                gbQ7d.Top = lZ + lDist * 3

                butResponse(0).Height = lZ \ 5
                'butResponse(1).Height = butResponse(0).Height
                butResponse(0).Top = lZ - butResponse(0).Height - lDist \ 4
                'butResponse(1).Top = butResponse(0).Top
                butResponse(0).Width = lY \ 3
                'butResponse(1).Width = butResponse(0).Width
                butResponse(0).Left = (3 * lY \ 4) - butResponse(0).Width \ 2
                butResponse(0).Left = lY - butResponse(0).Width \ 2
                'butResponse(1).Left = (5 * lY \ 4) - butResponse(1).Width \ 2

                lblVisu(0).Visible = False
                lblVisu(0).Height = 4 * lZ \ 10
                lblVisu(0).Width = lblVisu(lX).Height
                lblVisu(0).Left = butResponse(0).Left - lblVisu(0).Width \ 2
                'lblVisu(0).Top = lY \ 40
                lblVisu(0).Font = VB6.FontChangeSize(lblVisu(lX).Font, CSng(72 / 1600 * VB6.PixelsToTwipsY(lblVisu(lX).Height)))

                butResponse(0).Font = VB6.FontChangeSize(butResponse(0).Font, CSng(CLng(VB6.PixelsToTwipsY(lZ)) \ 300))
                'butResponse(1).Font = VB6.FontChangeSize(butResponse(1).Font, CSng(CLng(VB6.PixelsToTwipsY(lZ)) \ 300))

                tbResponse.Top = butResponse(0).Top - lDist
                tbPlay.Top = tbResponse.Top - 6 * lDist \ 10

                lblRequest.Font = VB6.FontChangeSize(lblRequest.Font, CSng(CLng(VB6.PixelsToTwipsY(lZ)) \ 200))
                'lblRequest.Top = tbPlay.Top - 5 * lDist \ 4
                lblRequest.Top = lZ \ 7
                'Application.DoEvents()
                lblRequest.Left = lY - lblRequest.Width \ 2



                For Each g As GroupBox In Me.tabMode7.Controls.OfType(Of GroupBox)()
                    g.Height = lDist
                    For Each t As TableLayoutPanel In g.Controls.OfType(Of TableLayoutPanel)()
                        For Each b As RadioButton In t.Controls.OfType(Of RadioButton)()
                            b.Font = VB6.FontChangeSize(b.Font, CSng(CLng(VB6.PixelsToTwipsY(lZ)) \ 400))
                        Next
                        For Each l As Label In t.Controls.OfType(Of Label)()
                            l.Font = VB6.FontChangeSize(l.Font, CSng(CLng(VB6.PixelsToTwipsY(lZ)) \ 400))
                        Next
                    Next
                Next

                'lY = 5 * tabExp.Height \ 6
                'butResponse(0).Width = tabExp.Width \ mlAFC \ 4
                'lDist = tabExp.Width \ 2 - (mlAFC * butResponse(0).Width + (mlAFC - 1) * butResponse(0).Width \ 2) \ 2
                'lZ = lDist
                'For lX = 0 To mlAFC - 1
                '    butResponse(lX).Top = lY
                '    butResponse(lX).Height = (tabExp.Height - lY) \ 2
                '    butResponse(lX).Left = lDist
                '    butResponse(lX).Width = butResponse(0).Width
                '    butResponse(lX).Font = VB6.FontChangeSize(butResponse(lX).Font, (CLng(Val(lblRequest.Font.Size * 6)) \ 10))
                '    lDist = lDist + 3 * butResponse(0).Width \ 2
                'Next

        End Select
        ' start label
        lblStart.Font = VB6.FontChangeSize(lblStart.Font, CSng(4 / 1600 * VB6.PixelsToTwipsY(tabExp.Height)))
        ' feedback label
        lblFeedback.Font = VB6.FontChangeSize(lblFeedback.Font, lblRequest.Font.SizeInPoints * msFeedBackFontSize)
        lblFeedback.Top = lblRequest.Top
        lblFeedback.Left = lblRequest.Left + (lblRequest.Width - lblFeedback.Width) \ 2
        ' end frame
        lblEnd.Font = VB6.FontChangeSize(lblEnd.Font, CSng(4 / 1600 * VB6.PixelsToTwipsY(tabExp.Height)))
        ' save new values
        rectMe.Left = Me.Left
        rectMe.Width = Me.Width
        rectMe.Top = Me.Top
        rectMe.Height = Me.Height

        'Me.Mode5TrackBar.Left = Me.Left + 10
        Me.Mode5TrackBar.Width = 1
        'Me.Mode5TrackBar.Left = (Me.Widcth - Me.Mode5TrackBar.Width) \ 2
        'Me.Mode5TrackBar.Height = 20

        If gblnExperiment And CBool(mFlags And EXPFLAGS.expflClipMouseToWindow) Then
            If Mode5TrackBar.Visible = True Then
                ClipCursorToWindow(Handle.ToInt32, Mode5TrackBar.Left + Me.Left + 7, Mode5TrackBar.Top + (Mode5TrackBar.Height \ 3), _
                                  1, Mode5TrackBar.Height - (Mode5TrackBar.Height * 2 \ 3)) 'Clip mouse to TrackBar
                'ClipCursorToWindow(Handle.ToInt32, Mode5TrackBar.Left + (Mode5TrackBar.Width \ 20), Mode5TrackBar.Top + (Mode5TrackBar.Height \ 3), _
                '                  Mode5TrackBar.Width - (Mode5TrackBar.Width \ 10), Mode5TrackBar.Height - (Mode5TrackBar.Height * 2 \ 3)) 'Clip mouse to TrackBar
                Debug.Print("X " & Mode5TrackBar.Left.ToString & " m " & Cursor.Position.X.ToString)
                Debug.Print("Y " & Mode5TrackBar.Top.ToString & " m " & Cursor.Position.Y.ToString)
            Else
                ClipCursorToWindow(Handle.ToInt32, Left, Top, Width, Height) 'Clip mouse (lock mouse on exp screen)
            End If

        End If

    End Sub

    Private Sub tmrBreak_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrBreak.Tick
        'lblProgress.Visible = Not lblProgress.Visible And Not cmdCancel.Enabled 'display "Pause" text only when subject responded already
        lblProgress.Visible = Not lblProgress.Visible And frmMain.chkExpRun.CheckState = CheckState.Unchecked 'display "Pause" text only when experiment not running
        'lblProgress.Visible = Not lblProgress.Visible
    End Sub

    Private Sub tmrStimScreenNone_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrStimScreenNone.Tick
        tmrStimScreenNone.Enabled = False
        If gexpState <> EXPSTATE.expStim Then Exit Sub
        ' unhighlight all items
        For lX As Integer = 0 To lblVisu.Count - 1
            lblVisu(lX).ForeColor = lblInactive.ForeColor
            lblVisu(lX).BackColor = lblInactive.BackColor
        Next
    End Sub

    ' textNum goes here
    Private Sub textNum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

        If Me.IsInitializing = True Then Return
        If gexpState = EXPSTATE.expUnInit Then Return
        If InStr(1, textNum.Text, "/") > 0 Then
            textNum.Text = ""
        End If
        ' allow first button, if numeric value found
        butResponse(0).Enabled = IsNumeric(Replace(textNum.Text, ",", "."))
        'If textNum.Text <> "" Then bTextEntered = True
    End Sub

    Private Sub textNum_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs)
        'If bTextEntered Then eventArgs.Handled = True : Exit Sub
        If gexpState = EXPSTATE.expUnInit Then Return
        If eventArgs.KeyCode = Keys.Enter Or eventArgs.KeyCode = Keys.Return Then
            mlResponse = rNEXT
            mblnResponse = True
        End If
    End Sub

    Private Sub textNum_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)

        Select Case eventArgs.KeyChar
            Case "0"c, "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c, ","c, "."c
                If eventArgs.KeyChar = CharacterEntered Then
                    eventArgs.Handled = True
                Else
                    CharacterEntered = eventArgs.KeyChar
                End If
            Case Else
                CharacterEntered = Nothing
        End Select
    End Sub

    Private Sub textNum_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        'bTextEntered = False 'allow only one character
        CharacterEntered = Nothing
    End Sub


    ''' <summary>
    ''' Get/set the feedback font size.
    ''' </summary>
    ''' <value>Font size as integer.</value>
    ''' <returns>Font size as integer.</returns>
    ''' <remarks></remarks>
    Public Property FeedBackFontSize() As Single
        Get
            If gexpState = EXPSTATE.expUnInit Then FeedBackFontSize = -1 : Exit Property
            ' get factor
            Return lblFeedback.Font.SizeInPoints / lblRequest.Font.SizeInPoints
        End Get
        Set(ByVal Value As Single)
            If gexpState = EXPSTATE.expUnInit Then Exit Property
            If Value = 0 Then Exit Property
            ' set factor
            msFeedBackFontSize = Value
            ' resize
            frmExp_Resize(Me, New System.EventArgs())
        End Set
    End Property

    Private Sub Mode5TrackBar_MouseEnter(sender As Object, e As System.EventArgs) Handles Mode5TrackBar.MouseEnter
        Cursor.Hide()
    End Sub

    Private Sub Mode5TrackBar_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Mode5TrackBar.MouseWheel
        If glMouseWheelStepSize <> 0 Then 'mouse wheel scroll steps
            If e.Delta / 120 > 0 Then
                Mode5TrackBar.Value = Math.Max(Mode5TrackBar.Minimum, Math.Min(Mode5TrackBar.Value + glMouseWheelStepSize - 3, Mode5TrackBar.Maximum))
            ElseIf e.Delta / 120 < 0 Then
                Mode5TrackBar.Value = Math.Min(Mode5TrackBar.Maximum, Math.Max(Mode5TrackBar.Value - glMouseWheelStepSize + 3, Mode5TrackBar.Minimum))
            End If
        End If
    End Sub

    Private Sub TrackBar1_ValueChanged(sender As Object, e As System.EventArgs) Handles Mode5TrackBar.ValueChanged
        ' for debug purpose
        If lblMode5Scroll.Visible Then lblMode5Scroll.Text = "TrackBar value (Range: " & TStr(Mode5TrackBar.Minimum) & " - " & TStr(Mode5TrackBar.Maximum) & "): " & Mode5TrackBar.Value.ToString
    End Sub

    Private Sub tbResponse_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles tbResponse.MouseDown
        MoveTrackBarToMouseClickLocation(Cursor.Position.X)
    End Sub

    Private Sub MoveTrackBarToMouseClickLocation(mouseX As Integer)

        'jump to clicked location
        Dim dblValue As Double
        dblValue = ((mouseX - tbResponse.Left - Me.Left - 14) / (tbResponse.Right - tbResponse.Left - 14)) * (tbResponse.Maximum - tbResponse.Minimum)
        tbResponse.Value = Convert.ToInt32(Math.Min(Math.Max(dblValue, tbResponse.Minimum), tbResponse.Maximum))

    End Sub

    Private Sub Q7A_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rb7a1.CheckedChanged, rb7a2.CheckedChanged, rb7a3.CheckedChanged, rb7a4.CheckedChanged, rb7a5.CheckedChanged
        If rb7a1.Checked Or rb7a2.Checked Or rb7a3.Checked Or rb7a4.Checked Or rb7a5.Checked Then gbQ7a.BackColor = Control.DefaultBackColor
    End Sub

    Private Sub Q7B_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rb7b1.CheckedChanged, rb7b2.CheckedChanged, rb7b3.CheckedChanged, rb7b4.CheckedChanged, rb7b5.CheckedChanged
        If rb7b1.Checked Or rb7b2.Checked Or rb7b3.Checked Or rb7b4.Checked Or rb7b5.Checked Then gbQ7b.BackColor = Control.DefaultBackColor
    End Sub

    Private Sub Q7C_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rb7c1.CheckedChanged, rb7c2.CheckedChanged, rb7c3.CheckedChanged, rb7c4.CheckedChanged, rb7c5.CheckedChanged
        If rb7c1.Checked Or rb7c2.Checked Or rb7c3.Checked Or rb7c4.Checked Or rb7c5.Checked Then gbQ7c.BackColor = Control.DefaultBackColor
    End Sub

    Private Sub Q7D_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rb7d1.CheckedChanged, rb7d2.CheckedChanged, rb7d3.CheckedChanged, rb7d4.CheckedChanged, rb7d5.CheckedChanged
        If rb7d1.Checked Or rb7d2.Checked Or rb7d3.Checked Or rb7d4.Checked Or rb7d5.Checked Then gbQ7d.BackColor = Control.DefaultBackColor
    End Sub

    Private Sub Mode5TrackBar_MouseLeave(sender As Object, e As System.EventArgs) Handles Mode5TrackBar.MouseLeave
        Cursor.Show()
    End Sub

End Class