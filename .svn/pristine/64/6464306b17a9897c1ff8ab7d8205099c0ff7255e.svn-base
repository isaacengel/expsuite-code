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
''' 
''' </summary>
''' <remarks></remarks>
Module ViWo

    Public Const VIWO_NOWORLD As String = "<no world (default)>"

    Public gszViWoResponse As String
	Public gszViWoWorlds() As String
    Public gblnViWoLoaded As Boolean
    Public gviwoparPreview() As ViWoParameter
    Public gviwoparParameters() As ViWoParameter
    Public Version As String

    Private mlParametersCount As Integer
    Private mlPreviewCount As Integer
    Private mblnConnected As Boolean

    Private wskSend As Net.Sockets.UdpClient
    Private wskReceive As Net.Sockets.UdpClient

    Friend Class ViWoParameter
        Private szName As String
        Private szCommand As String
        Private szType As String
        Private szValue As String
        Private szDefault As String
        Private szPar1 As String
        Private szPar2 As String
        Private blnDirty As Boolean
        Private szMIDI As String

        Public Property Name() As String
            Get
                Return szName
            End Get
            Set(ByVal Value As String)
                szName = Value
            End Set
        End Property
        Public Property Command() As String
            Get
                Return szCommand
            End Get
            Set(ByVal Value As String)
                szCommand = Value
            End Set
        End Property
        Public Property Type() As String
            Get
                Return szType
            End Get
            Set(ByVal Value As String)
                szType = Value
            End Set
        End Property
        Public Property Value() As String
            Get
                Return szValue
            End Get
            Set(ByVal Value1 As String)
                szValue = Value1
            End Set
        End Property
        Public Property [Default]() As String
            Get
                Return szDefault
            End Get
            Set(ByVal Value As String)
                szDefault = Value
            End Set
        End Property
        Public Property Par1() As String
            Get
                Return szPar1
            End Get
            Set(ByVal Value As String)
                szPar1 = Value
            End Set
        End Property
        Public Property Par2() As String
            Get
                Return szPar2
            End Get
            Set(ByVal Value As String)
                szPar2 = Value
            End Set
        End Property
        Public Property Dirty() As Boolean
            Get
                Return blnDirty
            End Get
            Set(ByVal Value As Boolean)
                blnDirty = Value
            End Set
        End Property
        Public Property MIDI() As String
            Get
                Return szMIDI
            End Get
            Set(ByVal Value As String)
                szMIDI = Value
            End Set
        End Property
        Public Sub New()
            Dirty = True
        End Sub

       ''' <summary>
        ''' Copy the content of a source parameter to destination
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Copy() As ViWoParameter
            Copy = New ViWoParameter
            Copy.Command = szCommand
            Copy.Default = szDefault
            Copy.Dirty = blnDirty
            Copy.Name = szName
            Copy.Par1 = szPar1
            Copy.Par2 = szPar2
            Copy.Type = szType
            Copy.Value = szValue
            Copy.MIDI = szMIDI
            Return Copy
        End Function
    End Class

   ''' <summary>
    ''' Send all real and preview parameters to MIDI.
    ''' </summary>
    ''' <returns>Nothing at the moment.</returns>
    ''' <remarks>Send parameters if a world is loaded.
    ''' If a real parameter exist, its value will be used. If preview parameter exists only, the default value
    ''' will be sent.</remarks>
    Public Function SendAllParametersToMIDI() As String
        Dim lX, lIdx As Integer
        Dim szErr As String = ""

        If Not gblnViWoLoaded Then SendAllParametersToMIDI = szErr : Exit Function

        For lX = 0 To mlPreviewCount
            lIdx = GetParameterIndex(gviwoparPreview(lX).Name)
            If lIdx > -1 Then
                ' parameter found
                gviwoparParameters(lIdx).MIDI = gviwoparPreview(lX).MIDI ' update midi data
                ViWo.SendParameterToMIDI(gviwoparParameters(lIdx)) ' send parameter
            Else
                ' send default value from preview
                ViWo.SendParameterToMIDI(gviwoparPreview(lX))
            End If
        Next

        SendAllParametersToMIDI = szErr

    End Function

   ''' <summary>
    ''' Send a parameter to MIDI
    ''' </summary>
    ''' <param name="viwoPar">ViWo parameter.</param>
    ''' <remarks></remarks>
    Public Sub SendParameterToMIDI(ByVal viwoPar As ViWoParameter)
        Dim lY, lX, lZ As Integer
        Dim szArr() As String
        Dim szArr2() As String
        Dim iX(2) As Short
        Dim dMin, dMax As Double

        MIDI.IgnoreInput(1000) ' changing MIDI, controller returns changed data. Ignore them for a second

        On Error Resume Next

        Select Case LCase(viwoPar.Type)
            Case "int", "float"
                dMin = Val(viwoPar.Par1)
                dMax = Val(viwoPar.Par2)
                MIDI.Out(1, CInt(Val(viwoPar.MIDI)), CInt((Val(viwoPar.Value) - dMin) / (dMax - dMin) * 127))
            Case "color"
                szArr2 = Split(viwoPar.MIDI, " ")
                lX = CInt(Val(viwoPar.Value))
                iX(0) = CShort(lX Mod 256) : lX = lX \ 256
                iX(1) = CShort(lX Mod 256) : lX = lX \ 256
                iX(2) = CShort(lX Mod 256)
                For lX = 0 To GetUbound(szArr2)
                    lY = CInt(Val(szArr2(lX)))
                    If lY > 0 Then MIDI.Out(1, lY, CInt(iX(lX) / 255 * 127))
                Next
            Case "position"
                dMin = Val(viwoPar.Par1)
                dMax = Val(viwoPar.Par2)
                szArr2 = Split(viwoPar.MIDI, " ")
                szArr = Split(viwoPar.Value, " ")
                For lX = 0 To GetUbound(szArr2)
                    lY = CInt(Val(szArr2(lX)))
                    If lY > 0 Then MIDI.Out(1, lY, CInt((Val(szArr(lX)) - dMin) / (dMax - dMin) * 127))
                Next
            Case "4param"
                dMin = Val(viwoPar.Par1)
                dMax = Val(viwoPar.Par2)
                szArr2 = Split(viwoPar.MIDI, " ")
                szArr = Split(viwoPar.Value, " ")
                For lX = 0 To GetUbound(szArr2)
                    lY = CInt(Val(szArr2(lX)))
                    If lY > 0 Then MIDI.Out(1, lY, CInt((Val(szArr(lX)) - dMin) / (dMax - dMin) * 127))
                Next

        End Select

        On Error GoTo 0

    End Sub

   ''' <summary>
    ''' Change a parameter by MIDI data.
    ''' </summary>
    ''' <param name="lCtrl">MIDI controller</param>
    ''' <param name="lVal">MIDI value</param>
    ''' <remarks>The old value of a parameter will be modified according to the assign MIDI controller.
    ''' If the real parameter does not exist, it will be copied from the preview parameter.
    ''' The new parameter will be sent to ViWo immediatly. If the settings form is open, the temporary parameters
    ''' change only and the Settings form will be updated - so you can track the changes of a parameter in real time
    ''' in ViWo and Settings.</remarks>
    Public Sub ChangeParameterByMIDI(ByVal lCtrl As Integer, ByVal lVal As Integer)
        Dim lSubIdx, lX, lIdx, lIdxNew As Integer
        Dim szVal As String = ""
        Dim dMin, dMax As Double
        Dim i2, i1, i3 As Short
        Dim szArr() As String
        Dim szArr2() As String

        'Debug.Print "Change Parameter By MIDI"
        'Exit Function

        For lIdx = 0 To mlPreviewCount
            szArr = Split(gviwoparPreview(lIdx).MIDI, " ")
            For lSubIdx = 0 To GetUbound(szArr)
                If CInt(Val(szArr(lSubIdx))) = lCtrl Then
                    ' Active Controller found - process
                    With gviwoparPreview(lIdx)
                        ' search for parameter and get the old value
                        If gblnSettingsForm Then
                            'szVal = frmSettings.GetTempViWoParameter(lIdx) ' Settings form open - get temporary parameter value
                        Else
                            ' Settings form not visible - get real parameter value
                            lIdxNew = GetParameterIndex(gviwoparPreview(lIdx).Name)
                            If lIdxNew = -1 Then
                                szVal = gviwoparPreview(lIdx).Value
                            Else
                                szVal = gviwoparParameters(lIdxNew).Value
                            End If
                        End If

                        ' calculate new value
                        Select Case LCase(.Type)
                            Case "int", "float"
                                dMin = Val(.Par1)
                                dMax = Val(.Par2)
                                szVal = TStr(Math.Round(lVal / 127 * (dMax - dMin) + dMin, 3))
                            Case "color"
                                If Val(.Par1) = 0 Then
                                    ' RGB color room
                                    lX = CInt(Val(szVal))
                                    i1 = CShort(lX Mod 256) : lX = lX \ 256
                                    i2 = CShort(lX Mod 256) : lX = lX \ 256
                                    i3 = CShort(lX Mod 256)
                                    If lSubIdx = 0 Then lX = RGB(lVal * 255 \ 127, i2, i3)
                                    If lSubIdx = 1 Then lX = RGB(i1, lVal * 255 \ 127, i3)
                                    If lSubIdx = 2 Then lX = RGB(i1, i2, lVal * 255 \ 127)
                                    szVal = TStr(lX)
                                Else
                                    '              RGBColorToHSV Val(szVal), i1, i2, i3
                                    '              szVal = TStr(HSVtoRGBColor(i1, i2, i3))
                                End If
                            Case "position"
                                dMin = Val(.Par1)
                                dMax = Val(.Par2)
                                szArr2 = Split(szVal, " ")
                                szVal = TStr(Math.Round(lVal / 127 * (dMax - dMin) + dMin, 3))
                                If lSubIdx = 0 Then szVal = szVal & " " & szArr2(1) & " " & szArr2(2)
                                If lSubIdx = 1 Then szVal = szArr2(0) & " " & szVal & " " & szArr2(2)
                                If lSubIdx = 2 Then szVal = szArr2(0) & " " & szArr2(1) & " " & szVal
                            Case "4param"
                                dMin = Val(.Par1)
                                dMax = Val(.Par2)
                                szArr2 = Split(szVal, " ")
                                szVal = TStr(Math.Round(lVal / 127 * (dMax - dMin) + dMin, 3))
                                If lSubIdx = 0 Then szVal = szVal & " " & szArr2(1) & " " & szArr2(2)
                                If lSubIdx = 1 Then szVal = szArr2(0) & " " & szVal & " " & szArr2(2)
                                If lSubIdx = 2 Then szVal = szArr2(0) & " " & szArr2(1) & " " & szVal
                                If lSubIdx = 3 Then szVal = szArr2(0) & " " & szArr2(1) & " " & szArr2(3) & " " & szVal
                        End Select

                        ' save new value
                        If gblnSettingsForm Then
                            'frmSettings.SetTempViWoParameter(lIdx, szVal) ' Settings form open - change temporary parameters only
                        Else
                            ' Settings form not visible - change real parameter immediatly
                            If lIdxNew = -1 Then
                                AddParameter(gviwoparPreview(lIdx))
                                gviwoparParameters(mlParametersCount).Value = szVal
                                SendParameter(gviwoparParameters(mlParametersCount))
                            Else
                                gviwoparParameters(lIdxNew).Value = szVal
                                SendParameter(gviwoparParameters(lIdxNew))
                            End If
                        End If

                    End With
                End If ' active controller?
            Next  ' subindex
        Next

    End Sub

   ''' <summary>
    ''' Get the index of a preview parameter given by name.
    ''' </summary>
    ''' <param name="szName">Name of the preview parameter.</param>
    ''' <returns>Index of the preview parameter. -1 if the parameter could not be found</returns>
    ''' <remarks></remarks>
    Public Function GetPreviewParameterIndex(ByVal szName As String) As Integer
        Dim lX As Integer
        Dim szX As String

        szX = LCase(szName)
        For lX = 0 To mlPreviewCount
            If LCase(gviwoparPreview(lX).Name) = szX Then Return lX
        Next
        Return -1

    End Function

   ''' <summary>
    ''' Get the index of a parameter given by name.
    ''' </summary>
    ''' <param name="szName">Name of the parameter.</param>
    ''' <returns>Index of the parameter. -1 if the parameter could not be found</returns>
    ''' <remarks>GetParameterIndex searches for a parameter with the name szName. If there is no parameter
    ''' with this name, the search will be continued in the preview parameters array. If a corresponding
    ''' preview parameter can be found, it will be copied to the parameters array and its index will be returned.
    ''' If there is no real parameter nor preview parameter with such a name, -1 will be returned</remarks>
    Public Function GetParameterIndex(ByVal szName As String) As Integer
        Dim lX As Integer
        Dim szX As String

        szX = LCase(szName)
        ' search in parameters
        For lX = 0 To mlParametersCount
            If LCase(gviwoparParameters(lX).Name) = szX Then Return lX
        Next
        ' search in preview parameters
        For lX = 0 To mlPreviewCount
            If LCase(gviwoparPreview(lX).Name) = szX Then
                ' found - copy to parameter
                AddParameter(gviwoparPreview(lX))
                Return mlParametersCount
            End If
        Next
        ' not found - return error
        Return -1

    End Function

   ''' <summary>
    ''' Get the OSC command of a preview parameter given by its name.
    ''' </summary>
    ''' <param name="szName">Name of the preview parameter.</param>
    ''' <returns>String with the OSC command of the preview parameter. Empty if the parameter could not be found.</returns>
    ''' <remarks></remarks>
    Public Function GetPreviewParameterCommand(ByVal szName As String) As String
        Dim lX As Integer
        Dim szX As String

        szX = LCase(szName)
        For lX = 0 To mlPreviewCount
            If LCase(gviwoparPreview(lX).Name) = szX Then Return gviwoparPreview(lX).Command
        Next
        Return ""

    End Function

   ''' <summary>
    ''' Get the OSC command of a parameter given by its name.
    ''' </summary>
    ''' <param name="szName">Name of the parameter</param>
    ''' <returns>String with the OSC command of the  parameter. Empty if the parameter could not be found.</returns>
    ''' <remarks></remarks>
    Public Function GetParameterCommand(ByVal szName As String) As String
        Dim lX As Integer

        lX = GetParameterIndex(szName)
        If lX > -1 Then
            Return gviwoparParameters(lX).Command
        Else
            Return ""
        End If

    End Function

   ''' <summary>
    ''' Clear all parameters.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearParameters()
        Erase gviwoparParameters
        mlParametersCount = -1
    End Sub

   ''' <summary>
    ''' Get the count of parameters.
    ''' </summary>
    ''' <returns>Count of parameters. 0 if no parameters available.</returns>
    ''' <remarks></remarks>
    Public Function GetParametersCount() As Integer
        Return mlParametersCount + 1
    End Function

   ''' <summary>
    ''' Send all parameters to ViWo.
    ''' </summary>
    ''' <returns>String containing error report of not supported parameters.</returns>
    ''' <remarks>All (real!) parameters will be sent to ViWo. If a parameters is not supported by the loaded world
    ''' (corresponding preview parameter can not be found) an error will be returned.<br>
    ''' If no world has been loaded, this function terminates immediatly.</br></remarks>
    Public Function SendAllParameters() As String
        Dim lX, lIdx As Integer
        Dim szErr As String = ""

        If Not gblnViWoLoaded Then Return szErr
        If gszViWoWorld = VIWO_NOWORLD Or Len(gszViWoWorld) = 0 Then Return szErr

        For lX = 0 To mlParametersCount
            lIdx = GetPreviewParameterIndex(gviwoparParameters(lX).Name)
            If lIdx <> -1 Then
                ViWo.SendParameter(gviwoparParameters(lX))
            Else
                szErr = szErr & "Parameter '" & gviwoparParameters(lX).Name & "' not available in this world." & vbCrLf
            End If
        Next

        Return szErr

    End Function

   ''' <summary>
    ''' Send a parameter to ViWo
    ''' </summary>
    ''' <param name="viwoPar"></param>
    ''' <remarks>The parameter viwoPar will be parsed, converted to ViWo's parameter range and send to ViWo
    '''<li>int, float: the value will be converted to a number and sent</li>
    '''<li>color: the colors parts R, G, and B will be converted from 0..255 to 0..1 range</li>
    '''<li>position: the value must be a string in form "X Y Z". It will be splitted and 3 values will be sent</li>
    '''<li>string: the value will be sent as is</li></remarks>
    Public Sub SendParameter(ByVal viwoPar As ViWoParameter)
        Dim lX As Integer
        Dim szArr() As String

        If Not gblnViWoLoaded Then Return
        If gszViWoWorld = VIWO_NOWORLD Then Return

        Select Case LCase(viwoPar.Type)
            Case "int", "float"
                Send(viwoPar.Command, Val(viwoPar.Value))
            Case "color"
                lX = CInt(Val(viwoPar.Value))
                Send(viwoPar.Command, (lX Mod 256) / 255, ((lX \ 256) Mod 256) / 255, ((lX \ 65536) Mod 256) / 255)
            Case "position"
                szArr = Split(viwoPar.Value, " ")
                Send(viwoPar.Command, Val(szArr(0)), Val(szArr(1)), Val(szArr(2)))
            Case "4param"
                szArr = Split(viwoPar.Value, " ")
                Send(viwoPar.Command, Val(szArr(0)), Val(szArr(1)), Val(szArr(2)), Val(szArr(3)))
            Case "string"
                Send(viwoPar.Command, viwoPar.Value)
        End Select
    End Sub

   ''' <summary>
    ''' Add a new parameter to the parameters array.
    ''' </summary>
    ''' <param name="viwoparNew">ViWo parameter</param>
    ''' <remarks>Used on load or change of settings</remarks>
    Public Sub AddParameter(ByVal viwoparNew As ViWoParameter)

        mlParametersCount = mlParametersCount + 1
        ReDim Preserve gviwoparParameters(mlParametersCount)
        gviwoparParameters(mlParametersCount) = New ViWoParameter
        gviwoparParameters(mlParametersCount) = viwoparNew.Copy

    End Sub

   ''' <summary>
    ''' Add a preview parameter to the preview parameters array.
    ''' </summary>
    ''' <param name="varArgs">Variant array containing: index (not used), OSC command, type, MIDI, Default, additional parameter 1 and 2, and the name</param>
    ''' <returns>Nothing yet.</returns>
    ''' <remarks>A new preview parameter will be added. This function is called by the callback from ViWo.
    ''' Additioanally, the default value will be decoded to FW standards and saved in .Value.
    ''' If a corresponding real parameter exists, its MIDI data will be updated to the new data of
    ''' the preview parameter. This is necessary in case of existing settings and real
    ''' parameters and changing MIDI controller.</remarks>
    Public Function AddPreviewParameter(ByVal varArgs() As Object) As String
        Dim lX As Integer
        Dim szArr() As String
        Dim d2, d1, d3, d4 As Double
        Dim csvX As New CSVParser

        csvX.Quota = """" : csvX.Separator = ","
        If Mid(csvX.UnquoteCell(varArgs(1).ToString), 1, 1) <> "/" Then Return ""
        If Not (TypeOf varArgs(1) Is String) Then Return ""
        If Not (TypeOf varArgs(2) Is String) Then Return ""
        If Not ((TypeOf varArgs(3) Is String) Or (TypeOf varArgs(3) Is Integer)) Then Return ""
        If Not (TypeOf varArgs(7) Is String) Then Return ""

        ' add preview parameter
        mlPreviewCount = mlPreviewCount + 1
        ReDim Preserve gviwoparPreview(mlPreviewCount)
        gviwoparPreview(mlPreviewCount) = New ViWoParameter
        With gviwoparPreview(mlPreviewCount)
            ' copy data
            .Command = csvX.UnquoteCell(DirectCast(varArgs(1), String)) ' string
            .Type = csvX.UnquoteCell(DirectCast(varArgs(2), String))    ' string
            If TypeOf varArgs(3) Is Integer Then
                .MIDI = csvX.UnquoteCell(TStr(DirectCast(varArgs(3), Integer)))    ' integer
            Else
                .MIDI = csvX.UnquoteCell(Replace(DirectCast(varArgs(3), String), "_", " ")) ' string
            End If
            .Name = csvX.UnquoteCell(Replace(DirectCast(varArgs(7), String), "_", " ")) ' string
            .Dirty = False

            ' set value to default
            Select Case LCase(.Type)
                Case "float", "int"
                    .Default = TStr(Val(varArgs(4))) ' double or integer
                    .Par1 = TStr(Val(varArgs(5))) ' double or integer
                    .Par2 = TStr(Val(varArgs(6))) ' double or integer
                    .Value = .Default
                'Case "int"
                '    .Default = TStr(CDbl(varArgs(4))) ' integer
                '    .Par1 = TStr(CDbl(varArgs(5))) ' integer
                '    .Par2 = TStr(CDbl(varArgs(6))) ' integer
                '    .Value = .Default
                Case "color" ' par1, 2, 3 = R, G, B
                    .Default = csvX.UnquoteCell(Replace(DirectCast(varArgs(4), String), "_", " ")) ' string R_G_B
                    .Par1 = "" ' not used
                    .Par2 = "" ' not used
                    szArr = Split(.Default, " ")
                    If GetUbound(szArr) >= 0 Then d1 = Val(szArr(0))
                    If GetUbound(szArr) >= 1 Then d2 = Val(szArr(1))
                    If GetUbound(szArr) >= 2 Then d3 = Val(szArr(2))
                    .Value = TStr(d1 * 255 + d2 * 255 * 256 + d3 * 255 * 65536)
                Case "position"
                    .Default = csvX.UnquoteCell(Replace(DirectCast(varArgs(4), String), "_", " "))   ' string X_Y_Z
                    .Par1 = TStr(CDbl(varArgs(5))) ' double or integer
                    .Par2 = TStr(CDbl(varArgs(6))) ' double or integer
                    szArr = Split(.Default, " ")
                    If GetUbound(szArr) >= 0 Then d1 = Val(szArr(0))
                    If GetUbound(szArr) >= 1 Then d2 = Val(szArr(1))
                    If GetUbound(szArr) >= 2 Then d3 = Val(szArr(2))
                    .Value = TStr(d1) & " " & TStr(d2) & " " & TStr(d3)
                Case "4param"
                    .Default = csvX.UnquoteCell(Replace(DirectCast(varArgs(4), String), "_", " "))   ' string A_B_C_D
                    .Par1 = TStr(CDbl(varArgs(5))) ' double or integer
                    .Par2 = TStr(CDbl(varArgs(6))) ' double or integer
                    szArr = Split(.Default, " ")
                    If GetUbound(szArr) >= 0 Then d1 = Val(szArr(0))
                    If GetUbound(szArr) >= 1 Then d2 = Val(szArr(1))
                    If GetUbound(szArr) >= 2 Then d3 = Val(szArr(2))
                    If GetUbound(szArr) >= 3 Then d4 = Val(szArr(3))
                    .Value = TStr(d1) & " " & TStr(d2) & " " & TStr(d3) & " " & TStr(d4)
                Case "string"
                    .Default = csvX.UnquoteCell(Replace(DirectCast(varArgs(4), String), "_", " "))
                    .Value = Replace(.Default, "_", " ")
            End Select

            ' update MIDI data of real parameters
            lX = GetParameterIndex(.Name)
            If lX > -1 Then gviwoparParameters(lX).MIDI = .MIDI

        End With
        Return ""
    End Function

   ''' <summary>
    ''' Get the count of preview parameters.
    ''' </summary>
    ''' <returns>Count of preview parameters. 0 if no parameters available</returns>
    ''' <remarks></remarks>
    Public Function GetPreviewParametersCount() As Integer
        Return mlPreviewCount + 1
    End Function

   

   ''' <summary>
    ''' Initiate loading of preview parameters from ViWo.
    ''' </summary>
    ''' <param name="szWorld"></param>
    ''' <param name="pbStatus"></param>
    ''' <returns></returns>
    ''' <remarks>The parameters will be added using AddPreviewParameter.</remarks>
    Public Function LoadPreviewParameters(ByVal szWorld As String, _
                Optional ByVal pbStatus As ProgressBar = Nothing) As String

        If szWorld = VIWO_NOWORLD Then
            ' dummy world - copy real to dummy preview parameters
            If mlParametersCount > -1 Then
                ReDim gviwoparPreview(mlParametersCount)
                mlPreviewCount = mlParametersCount
                For lX As Integer = 0 To mlPreviewCount
                    gviwoparPreview(lX) = New ViWoParameter
                    gviwoparPreview(lX) = gviwoparParameters(lX).Copy()
                Next
            Else
                Erase gviwoparPreview
                mlPreviewCount = -1
            End If
        Else
            ' get the preview from ViWo
            Erase gviwoparPreview
            mlPreviewCount = -1
            gszViWoResponse = ""
            Send("/Control/GetWorldParameters", szWorld)
            For lX As Integer = 0 To 50 'max 5 seconds
                Proc.TimerStart(100)
                gblnCancel = False
                Do
                    Windows.Forms.Application.DoEvents()
                Loop Until gblnTimeOut Or (Len(gszViWoResponse) > 0) Or gblnCancel
                If Not IsNothing(pbStatus) Then pbStatus.Value = (lX * 2)
                If Len(gszViWoResponse) > 0 Or gblnCancel Then Exit For
                Proc.TimerStop()
            Next
            Proc.TimerStop()
            If Len(gszViWoResponse) = 0 Then Return "Timeout"
        End If

        If Not IsNothing(pbStatus) Then pbStatus.Value = 0
        Return ""

    End Function

   ''' <summary>
    ''' Load a world in ViWo.
    ''' </summary>
    ''' <param name="szWorld">Name of the world</param>
    ''' <param name="pbStatus"></param>
    ''' <returns>Error message or empty if no error ocured.</returns>
    ''' <remarks>WorldLoad initiates loading of a world in ViWo and waits for a response from the world.
    ''' If no response can be received within 30 seconds an error will be returned.</remarks>
    Public Function WorldLoad(ByVal szWorld As String, Optional ByVal pbStatus As ProgressBar = Nothing) As String

        If Len(gszViWoWorld) = 0 Or (gszViWoWorld = VIWO_NOWORLD) Then
            ' no world to be loaded
            'frmMain.SetStatus("ViWo: No world selected...")
            gblnViWoLoaded = True
            Return ""
        End If

        gszViWoResponse = ""
        ViWo.Send("/Control/GetLoaded")
        For lX As Integer = 0 To 10 ' try one second
            Proc.TimerStart(100)
            gblnCancel = False
            Do
                Windows.Forms.Application.DoEvents()
            Loop Until gblnTimeOut Or Len(gszViWoResponse) > 0 Or gblnCancel
            Proc.TimerStop()
            If (Len(gszViWoResponse) > 0) Or gblnCancel Then Exit For
        Next

        If gszViWoResponse = gszViWoWorld Then
            gblnViWoLoaded = True
            Return ""
        End If

        gszViWoResponse = ""
        ViWo.Send("/Control/Load", szWorld)

        ' load
        For lX As Integer = 0 To 50
            Proc.TimerStart(100)
            gblnCancel = False
            Do
                Windows.Forms.Application.DoEvents()
            Loop Until gblnTimeOut Or Len(gszViWoResponse) > 0 Or gblnCancel
            Proc.TimerStop()
            If (Len(gszViWoResponse) > 0) Or gblnCancel Then Exit For
            If Not IsNothing(pbStatus) Then pbStatus.Value = CInt(lX / 50 * 100)
        Next

        If Len(gszViWoResponse) = 0 Then
            ViWo.Send("/Control/Unload")
            gblnViWoLoaded = False
            Return "World not loaded within 30 seconds."
        End If

        gblnViWoLoaded = True
        If Not IsNothing(pbStatus) Then pbStatus.Value = 0
        Return ""

    End Function

   ''' <summary>
    ''' Unload a world in ViWo.
    ''' </summary>
    ''' <returns>Nothing yet.</returns>
    ''' <remarks></remarks>
    Public Function WorldUnload() As String
        ViWo.Send("/Control/Unload")
        gblnViWoLoaded = False
        'frmMain.SetStatus("Viwo: World unloaded.")
        WorldUnload = ""
    End Function

   ''' <summary>
    ''' Init this module at the application's start.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Init()
        mlParametersCount = -1
        mlPreviewCount = -1
        ReDim gszViWoWorlds(0)
        gszViWoWorlds(0) = VIWO_NOWORLD

    End Sub

    Private Sub wskReceive_DataArrival(ByVal ar As IAsyncResult)
        Dim szErr, szX As String
        Dim szCmd As String = ""
        Dim szTemp As String = ""
        Dim bytData(0) As Byte
        Dim lX As Integer
        Dim varArgs(0) As Object
        Dim szCmdBackup As String

        If IsNothing(wskReceive) Then Return

        If IsNothing(DirectCast(ar.AsyncState, Net.Sockets.UdpClient).Client) Then Return

        Dim RemoteIpEndPoint As New Net.IPEndPoint(Net.IPAddress.Any, 0)
        Try
            If IsNothing(DirectCast(ar.AsyncState, Net.Sockets.UdpClient).Client) Then Return
            'bytData = wskReceive.EndReceive(ar, RemoteIpEndPoint)
            bytData = DirectCast(ar.AsyncState, Net.Sockets.UdpClient).EndReceive(ar, RemoteIpEndPoint)
        Catch
        End Try

        szErr = OSC.ParseBuffer(bytData, szCmd, varArgs)
        If Len(szErr) > 0 Then Return 'frmMain.SetStatus(szErr) : Return
        If Mid(szCmd, 1, 1) <> "/" Then Return 'frmMain.SetStatus("ViWo: Response without a command") : Return

        szCmd = Mid(szCmd, 2)
        szCmdBackup = szCmd
        OSC.SeparateCommand(szCmd, szTemp)
        Select Case szTemp
            ' ---------- CONTROL
            Case "Control"
                Select Case szCmd
                    Case "Version"
                        If TypeOf (varArgs(0)) Is String Then
                            SyncLock gszViWoResponse
                                gszViWoResponse = DirectCast(varArgs(0), String)
                            End SyncLock
                            Version = DirectCast(varArgs(0), String)

                        End If
                    Case "CPULoad"
                        'frmMain.SetStatus("Viwo/CPU Load: " + varArgs(0).ToString & "%")
                        SyncLock gszViWoResponse
                            gszViWoResponse = varArgs(0).ToString
                        End SyncLock
                    Case "Load/Loaded"
                        'frmMain.SetStatus("Viwo: World " + varArgs(0).ToString + " loaded.")
                        SyncLock gszViWoResponse
                            gszViWoResponse = varArgs(0).ToString
                        End SyncLock
                    Case "GetList"
                        SyncLock gszViWoResponse
                            gszViWoResponse = varArgs(0).ToString
                            SyncLock gszViWoWorlds
                                ReDim Preserve gszViWoWorlds(GetUbound(gszViWoWorlds) + 1)
                                gszViWoWorlds(gszViWoWorlds.Length - 1) = varArgs(0).ToString
                            End SyncLock
                        End SyncLock
                    Case "GetWorldParameters"
                        szX = ""
                        If varArgs.Length <> 8 Then
                            'frmMain.SetStatus("ViWo/GetWorldParameters: wrong number of arguments.")
                        Else
                            ViWo.AddPreviewParameter(varArgs)
                            'frmMain.SetProgressbar(ViWo.GetPreviewParametersCount)
                        End If
                    Case "GetWorldParameters/End"
                        SyncLock gszViWoResponse
                            gszViWoResponse = "End"
                        End SyncLock
                        'frmMain.SetProgressbar(0)
                    Case "GetLoaded"
                        SyncLock gszViWoResponse
                            gszViWoResponse = varArgs(0).ToString
                        End SyncLock
                End Select
            Case "Response"
                szX = szTemp & " "
                For lX = 0 To varArgs.Length - 1
                    Dim varX As Object = varArgs(lX)
                    'Console.WriteLine(varX.GetType.FullName)
                    Select Case varX.GetType.FullName
                        Case "System.Single", "System.Double"
                            szX = szX & TStr(CType(varArgs(lX), Double)) & " "
                        Case Else
                            szX = szX & varArgs(lX).ToString & " "
                    End Select
                Next
                SyncLock gszViWoResponse
                    gszViWoResponse = szX
                End SyncLock
            Case "MIDI"
                'MIDI.HandleResponse szCmd, varArgs()
                ' ---------- Unknown command - do nothing
            Case "Tracker"
                Tracker.HandleResponse(szCmd, varArgs)
            Case Else
                Console.WriteLine(szCmd & ": " & szTemp)
        End Select

        If Not IsNothing(wskReceive) Then
            If Not IsNothing(wskReceive.Client) Then
                wskReceive.BeginReceive(New AsyncCallback(AddressOf ViWo.wskReceive_DataArrival), wskReceive)
            End If
        End If

    End Sub

    ''' <summary>
    ''' Returns true if Viwo connected.
    ''' </summary>
    ''' <returns>True if Viwo connected.</returns>
    Public ReadOnly Property Connected() As Boolean
        Get
            Return mblnConnected
        End Get
    End Property

   ''' <summary>
    ''' Establish a connection to ViWo.
    ''' </summary>
    ''' <param name="pbStatus"></param>
    ''' <returns></returns>
    ''' <remarks><b>Warning: </b>This is not the "Connect" as used by framework. This function establishes the connection
    ''' to ViWo and is called at the begin of the application.</remarks>
    Public Function Connect(Optional ByVal pbStatus As ProgressBar = Nothing) As String
        Dim szX As String
        If mblnConnected Then Return "Disconnect first"
        If Not IsNothing(wskSend) Then wskSend = Nothing
        If Not IsNothing(wskReceive) Then wskReceive = Nothing
        If Len(gszViWoAddress) = 0 Then Return ""

        ' connect to UDP
        Try
            wskSend = New Net.Sockets.UdpClient()
            wskSend.Connect(gszViWoAddress, glViWoPort)
        Catch x As Exception
            Return "ViWo: Can't connect to the remote ViWo host " & gszViWoAddress & ", port " & TStr(glViWoPort) & "." & vbCrLf _
                & "Check your system - is the ViWo host running?." & vbCrLf & vbCrLf _
                & x.ToString
        End Try
        Try
            wskReceive = New Net.Sockets.UdpClient(10005)
        Catch x As Exception
            wskSend.Close()
            wskSend = Nothing
            Return "Can't connect to the local port 10005 for the responses from ViWo." & vbCrLf _
                & "Check your system - there is another program using the connection." & vbCrLf & vbCrLf _
                & x.ToString
        End Try
        ' establish connection
        wskReceive.BeginReceive(New AsyncCallback(AddressOf ViWo.wskReceive_DataArrival), wskReceive)
        szX = ""
        For lX As Integer = 0 To 10 ' try several times
            ' establish response channel
            szX = ViWo.Send("/Control/Response", "disconnect")
            If Len(szX) > 0 Then Exit For
            szX = ViWo.Send("/Control/Response", "connect", gszLocalNetAddr, CInt(10005))
            If Len(szX) > 0 Then Exit For
            ' get version of ViWo to check the connection
            gszViWoResponse = ""
            szX = ViWo.Send("/Control/Version") ' response will be saved in wskResponse_DataArrival
            If Len(szX) > 0 Then Exit For
            Proc.TimerStart(1000)
            gblnCancel = False
            Do
                Windows.Forms.Application.DoEvents()
            Loop Until gblnTimeOut Or (Len(gszViWoResponse) > 0) Or gblnCancel
            Proc.TimerStop()
            If (Len(gszViWoResponse) > 0) Or gblnCancel Then Exit For
            If Not IsNothing(pbStatus) Then pbStatus.Value = CInt(lX * 10)
        Next
        If Len(gszViWoResponse) = 0 Or Len(szX) > 0 Then
            wskSend.Client.Shutdown(Net.Sockets.SocketShutdown.Both)
            wskSend.Close()
            wskSend = Nothing
            wskReceive.Client.Shutdown(Net.Sockets.SocketShutdown.Both)
            wskReceive.Close()
            'wskReceive = Nothing
            Return "Connection to ViWo couldn't be established."
        End If
        mblnConnected = True
        If Not IsNothing(pbStatus) Then pbStatus.Value = 0

        ' get world list
        szX = ViWo.Send("/Control/GetList")
        If Len(szX) > 0 Then Return szX
        For lX As Integer = 0 To 1000 'max of 1000 worlds
            Proc.TimerStart(200)    ' max 200ms for each world to show up
            gblnCancel = False
            Do
                Windows.Forms.Application.DoEvents()
            Loop Until gblnTimeOut Or (Len(gszViWoResponse) > 0) Or gblnCancel
            If Not IsNothing(pbStatus) Then pbStatus.Value = (ViWo.gszViWoWorlds.Length Mod 10) * 10
            If gblnTimeOut Or gblnCancel Then Exit For
            Proc.TimerStop()
        Next
        Proc.TimerStop()
        If Not IsNothing(pbStatus) Then pbStatus.Value = 0
        Return ""

    End Function

   ''' <summary>
    ''' Disconnect from ViWo.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Disconnect()
        If mblnConnected Then
            mblnConnected = False
            ViWo.Send("/Control/Unload")
            gblnViWoLoaded = False
            ReDim gszViWoWorlds(0)
            gszViWoWorlds(0) = VIWO_NOWORLD
            wskSend.Client.Shutdown(Net.Sockets.SocketShutdown.Both)
            wskSend.Close()
            wskSend = Nothing
            wskReceive.Client.Shutdown(Net.Sockets.SocketShutdown.Both)
            wskReceive.Close()
            'wskReceive = Nothing
        End If
    End Sub


   ''' <summary>
    ''' Send an OSC command to ViWo.
    ''' </summary>
    ''' <param name="szAddr">OSC address in format "/root/tree1/obj2/method3"</param>
    ''' <param name="varArgs">Parameters in an array.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Send(ByVal szAddr As String, ByVal ParamArray varArgs() As Object) As String

        gszViWoResponse = ""
        'If gbViWoOSC And varArgs.Length = 0 Then varArgs = New Object() {0} 'comply with OSC standard
        Dim bytBuf() As Byte = OSC.PreparePacket(szAddr, varArgs)
        If IsNothing(wskSend) Then Return ""
        Try
            wskSend.Send(bytBuf, bytBuf.Length)
        Catch x As Exception
            Return x.ToString
        End Try
        Return ""

    End Function

    ' ------------------------------------------------------------
    '   RGB and HSV functions
    ' ------------------------------------------------------------

    'Public Sub RGBColorToHSV(ByVal Color As Integer,  rH As Short,  rS As Short,  rV As Short)

    '	Dim nR As Short
    '	Dim nG As Short
    '	Dim nB As Short

    '	OleTranslateColor(Color, 0, Color)
    '	nR = Color Mod 256
    '	Color = Color \ 256
    '	nG = Color Mod 256
    '	Color = Color \ 256
    '	nB = Color Mod 256
    '	RGBtoHSV(nR, nG, nB, rH, rS, rV)
    'End Sub

    'Public Sub RGBtoHSV(ByVal r As Short, ByVal G As Short, ByVal B As Short,  rH As Short,  rS As Short,  rV As Short)
    '       Dim nRR As Double
    '       Dim nGG As Double
    '       Dim nBB As Double
    '	Dim nMax As Double
    '	Dim nMin As Double
    '	Dim nH As Double
    '	Dim nS As Double
    '	Dim nV As Double
    '	Dim nDelta As Double
    '	Dim nRGBs(2) As Double

    '	nRR = r / 255
    '	nGG = G / 255
    '	nBB = B / 255
    '	nRGBs(0) = nRR
    '	nRGBs(1) = nGG
    '	nRGBs(2) = nBB
    '	nMax = zMax(nRGBs)
    '	nMin = zMin(nRGBs)
    '	nV = nMax
    '	If nMax <> 0 Then
    '		nS = (nMax - nMin) / nMax
    '	End If
    '	If nS = 0 Then
    '		nH = -1
    '	Else
    '		nDelta = nMax - nMin
    '		Select Case nMax
    '			Case nRR
    '				nH = (nGG - nBB) / nDelta
    '			Case nGG
    '				nH = 2 + ((nBB - nRR) / nDelta)
    '			Case Else
    '				nH = 4 + ((nRR - nGG) / nDelta)
    '		End Select
    '		nH = nH * 60
    '		If nH < 0 Then
    '			nH = nH + 360
    '		End If
    '	End If
    '	rH = nH
    '	rS = nS * 100
    '	rV = nV * 100
    'End Sub

    'Public Function HSVtoRGBColor(ByVal H As Short, ByVal S As Short, ByVal V As Short) As Integer

    '	Dim nR As Short
    '	Dim nG As Short
    '	Dim nB As Short

    '	HSVtoRGB(H, S, V, nR, nG, nB)
    '	HSVtoRGBColor = RGB(nR, nG, nB)
    'End Function

    'Public Sub HSVtoRGB(ByVal H As Short, ByVal S As Short, ByVal V As Short,  rR As Short,  rG As Short,  rB As Short)
    '	Dim nH As Double
    '	Dim nS As Double
    '	Dim nV As Double
    '       Dim nI As Short
    '	Dim nF As Double
    '	Dim nP As Double
    '	Dim nQ As Double
    '	Dim nT As Double

    '	nS = S / 100
    '	nV = V / 100
    '	If nS = 0 Then
    '		rR = nV * 255
    '		rG = nV * 255
    '		rB = nV * 255
    '		Exit Sub
    '	End If
    '	H = H Mod 360
    '	nH = H / 60
    '	nI = Int(nH)
    '	nF = nH - nI
    '	nP = nV * (1 - nS)
    '	nQ = nV * (1 - nS * nF)
    '	nT = nV * (1 - nS * (1 - nF))
    '	Select Case nI
    '		Case 0
    '			rR = nV * 255
    '			rG = nT * 255
    '			rB = nP * 255
    '		Case 1
    '			rR = nQ * 255
    '			rG = nV * 255
    '			rB = nP * 255
    '		Case 2
    '			rR = nP * 255
    '			rG = nV * 255
    '			rB = nT * 255
    '		Case 3
    '			rR = nP * 255
    '			rG = nQ * 255
    '			rB = nV * 255
    '		Case 4
    '			rR = nT * 255
    '			rG = nP * 255
    '			rB = nV * 255
    '		Case Else
    '			rR = nV * 255
    '			rG = nP * 255
    '			rB = nQ * 255
    '	End Select
    'End Sub

    'Private Function zMax( Values() As Double) As Double
    '	Dim nMax As Double
    '	Dim i As Short

    '	For i = 0 To 2
    '		If Values(i) > nMax Then
    '			nMax = Values(i)
    '		End If
    '	Next  'i
    '	zMax = nMax
    'End Function

    'Private Function zMin( Values() As Double) As Double
    '	Dim nMin As Double
    '	Dim i As Short

    '	nMin = Values(0)
    '	For i = 1 To 2
    '		If Values(i) < nMin Then
    '			nMin = Values(i)
    '		End If
    '	Next  'i
    '	zMin = nMin
    'End Function
End Module