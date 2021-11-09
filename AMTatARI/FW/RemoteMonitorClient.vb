'Option Strict On
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
Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Text

Module RemoteMonitorClient

    Private Class StateObject
        ' Client socket.
        Public workSocket As Socket = Nothing
        ' Size of receive buffer.
        Public Const BufferSize As Integer = 2048
        ' Receive buffer.
        Public buffer(BufferSize) As Byte
        ' Received data string.
        Public sb As New StringBuilder
    End Class 'StateObject

    ' Variables for receiving settings
    Public gszSettings(200) As String
    Public glSettingslength As Integer
    Public gszSettingstype As String
    Public gszSettingsfilename As String

    ' Variables for receiving itemlistdata
    Private mszList As String = ""
    Private mbList(0) As Byte
    Private ReadOnly mblnListReceive As Boolean = False
    Public gListReceiveDone As New ManualResetEvent(False)

    Private buffer As Integer = bufferSmall

    ' Save Server Address
    'Public gszHostConnected As String = ""
    Private gRemoteEP As IPEndPoint

    ' The port number for the remote device
    Private Const mlConnectionPort As Integer = 10002

    ' Clientnumber in Servers Clientlist for identification
    Private mlClientNumber As Integer

    ' ManualResetEvent instances signal completion
    Public gSettingsDone As New ManualResetEvent(False)

    ' Create TCP/IP Socket
    Private ReadOnly listener As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP)
    Private mlListenPort As Integer = 10004

    ' Socket to receive data
    Private handler As Socket

    Private state As New StateObject

    ' The client starts to connect to a specified server, sends his IP-Address and Port and receives a clientnumber for later identification.
    ' He starts a listener socket and waits for the connectionrequest from the server. Then the client waits asynchronously for incomming data
    ' with a handler socket.

    ''' <summary>
    ''' Connects to a server application.
    ''' </summary>
    ''' <param name="szHost">Servername or IP-Address</param>
    ''' <returns>True: Successfully connected <br> False: Connection failed.</br></returns>
    ''' <remarks>ConnectTo tries to connect to a specified server application.</remarks>
    Public Function ConnectTo(ByVal szHost As String, ByVal form As Form, ByVal listbox As ListBox, ByVal label As Label, ByVal tssl1 As ToolStripStatusLabel, ByVal tssl2 As ToolStripStatusLabel, ByVal tssl3 As ToolStripStatusLabel, ByVal tssl4 As ToolStripStatusLabel, ByRef dgv As DataGridView, ByVal tsmi1 As ToolStripMenuItem, ByVal tsmi2 As ToolStripMenuItem, ByVal tsmi3 As ToolStripMenuItem, ByVal label2 As Label) As Boolean
        gform = Form
        glistBox = ListBox
        glabel = Label
        gtssl1 = tssl1
        gtssl2 = tssl2
        gtssl3 = tssl3
        gtssl4 = tssl4
        gdgv = dgv
        gtsmi1 = tsmi1
        gtsmi2 = tsmi2
        gtsmi3 = tsmi3
        glabel2 = label2
        ' Establish the remote endpoint for the socket.
        Dim ipHostInfo As IPHostEntry
        Try
            ipHostInfo = Dns.GetHostEntry(szHost)
        Catch
            Proc.SetStatus(glistBox, gtssl1, "Connection Error")
            MsgBox("Connection Error! Remote Server not responding.", MsgBoxStyle.Critical, "Remote Monitor")
            Return False
        End Try
        Dim ipAddress As IPAddress = ipHostInfo.AddressList(0)

        'If ipAddress.ToString = gszMyIpAddress Then
        '    Proc.SetStatus(glistBox, gtssl1, "Connection to localhost is not allowed!")
        '    Return False
        'End If

        Dim remoteEP As New IPEndPoint(ipAddress, mlConnectionPort)

        ' Create a TCP/IP socket.
        Dim client As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

        ' Connect to the remote endpoint.
        Try
            client.Connect(remoteEP)
            gRemoteEP = remoteEP
            gszRemoteMonitorServerAdress = szHost
        Catch
            Proc.SetStatus(glistBox, gtssl1, "Connection Error")
            MsgBox("Connection Error! Remote Server not responding.", MsgBoxStyle.Critical, "Remote Monitor")
            Return False
        End Try

        If Not gblnRemoteClientListen Then
            mlListenPort = RemoteMonitorClient.ListenStart(mlListenPort)
        End If

        ' Send keyword to the remote device.
        client.Send(Encoding.ASCII.GetBytes(gszMyIpAddress & " " & mlListenPort.ToString & " " & 0.ToString)) ' & " " & 0.ToString))

        Dim bytes(50) As Byte
        ' Receive the response from the remote device.
        client.Receive(bytes)
        client.ReceiveTimeout = 10000
        Try
            client.Receive(bytes)
        Catch
            Proc.SetStatus(glistBox, gtssl1, "Server is busy! Connection failed.")
            Return False
        End Try
        Console.WriteLine(Encoding.ASCII.GetString(bytes))
        Dim stringarray() As String = Encoding.ASCII.GetString(bytes).Split(","c)
        mlClientNumber = Convert.ToInt32(stringarray(0))

        ' Release the socket.
        client.Shutdown(SocketShutdown.Both)
        client.Close()

        'Check application
        If Not gszAPP_TITLE = stringarray(1) Then
            Proc.SetStatus(glistBox, gtssl1, "Wrong Application! Server uses: " & stringarray(1))
            MsgBox("Wrong Application! Server uses: " & stringarray(1), MsgBoxStyle.Critical, "Remote Monitor")
            Return False
        End If

        'Check version number
        If Not Convert.ToInt16(stringarray(2)) = My.Application.Info.Version.Major Or Not Convert.ToInt16(stringarray(3)) = My.Application.Info.Version.Minor Or Not Convert.ToInt16(stringarray(4)) = My.Application.Info.Version.Build Or Not Convert.ToInt16(stringarray(5)) = My.Application.Info.Version.Revision Then
            If (MsgBox("Different Application-Version of " & stringarray(1) & vbCrLf & vbCrLf & _
                       "Server Version: " & stringarray(2) & "." & stringarray(3) & "." & stringarray(4) & "." & TStr(CInt(stringarray(5))) & _
                       vbCrLf & "Your Version: " & TStr(My.Application.Info.Version.Major) & "." & TStr(My.Application.Info.Version.Minor) & "." & TStr(My.Application.Info.Version.Build) & "." & TStr(My.Application.Info.Version.Revision) _
                       & vbCrLf & vbCrLf & "Do you want to connect anyway?", _
                       MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Remote Monitor")) = MsgBoxResult.No Then Return False
            'Else
            '    If  Then
            '        MsgBox("Wrong Application-Version! Server uses: " & stringarray(2) & "." & stringarray(3) & "." & stringarray(4) & "." & stringarray(5) & "!", MsgBoxStyle.Exclamation)
            '    Else
            '        If  Then
            '            MsgBox("Wrong Application-Version! Server uses: " & stringarray(2) & "." & stringarray(3) & "." & stringarray(4) & "." & stringarray(5) & "!", MsgBoxStyle.Exclamation)
            '        Else
            '            If  Then
            '                MsgBox("Wrong Application-Version! Server uses: " & stringarray(2) & "." & stringarray(3) & "." & stringarray(4) & "." & stringarray(5) & "!", MsgBoxStyle.Exclamation)
            '            End If
            '        End If
            '    End If
        End If

        If mlClientNumber = 0 Then
            Proc.SetStatus(glistBox, gtssl1, "Too much clients connected!")
            Return False
        End If

        ' Deactivate server-listener
        RemoteMonitorServer.Disconnect()

        frmMain.CheckForIllegalCrossThreadCalls = False

        ' Waiting for serverrequest
        ListenAccept()
        Return True
    End Function 'ConnectTo

    ''' <summary>
    ''' Disconnects from server application.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Disconnect()
        gblnRemoteClientConnected = False
        gblnSettingsLoaded = False

        ' Create a TCP/IP socket.
        Dim client As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

        ' Connect to the remote endpoint.
        client.Connect(gremoteEP)

        ' Send keyword to the remote device.
        client.Send(Encoding.ASCII.GetBytes(gszMyIpAddress & " " & 0.ToString & " " & (mlClientNumber + 2 * glMaxClients).ToString))

        ' Release the socket.
        client.Shutdown(SocketShutdown.Both)
        client.Close()

        'listener.Close()
        handler.Disconnect(False)
        handler.Shutdown(SocketShutdown.Both)
        handler.Close()

        Proc.SetStatus(glistBox, gtssl1, "Disconnected")
        Proc.MnuRemoteMonitorEnabled(gform, gtsmi3, True)
        Proc.NetworkStatus(gform, gtssl2, 2)
    End Sub 'Disconnect

    Private Sub Disconnected()
        gblnRemoteClientConnected = False
        gblnSettingsLoaded = False

        'listener.Close()
        handler.Disconnect(False)
        handler.Shutdown(SocketShutdown.Both)
        handler.Close()

        frmMain.mnuRemoteMonitorDisconnect.Enabled = False
        frmMain.mnuRemoteMonitorGetSettings.Enabled = False
        frmMain.mnuRemoteMonitorGetItemlist.Enabled = False
        frmMain.mnuRemoteMonitorUpdateSettings.Enabled = False
        frmMain.mnuRemoteMonitorUpdateSettings.Checked = True
        gblnRemoteMonitorUpdateSettings = True
        Proc.MnuRemoteMonitorEnabled(gform, gtsmi3, True)

        Proc.SetStatus(glistBox, gtssl1, "Disconnected")
        Proc.NetworkStatus(gform, gtssl2, 2)
    End Sub

    ''' <summary>
    ''' Sends a message to server to get settings.
    ''' </summary>
    ''' <returns>True: Settings loaded <br> False: No settings loaded on server application.</br></returns>
    ''' <remarks></remarks>
    Public Function SettingsRequest() As Boolean
        ' Create a TCP/IP socket.
        Dim client As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

        ' Connect to the remote endpoint.
        client.Connect(gremoteEP)

        ' Send keyword to the remote device.
        client.Send(Encoding.ASCII.GetBytes(gszMyIpAddress & " " & 0.ToString & " " & mlClientNumber.ToString))

        ' Receive Response
        Dim bytes(3) As Byte
        client.ReceiveTimeout = 10000
        Try
            client.Receive(bytes)
        Catch
            Proc.SetStatus(glistBox, gtssl1, "Server is busy! Connection failed.")
            Return False
        End Try

        ' Release the socket.
        client.Shutdown(SocketShutdown.Both)
        client.Close()

        If BitConverter.ToInt32(bytes, 0) = 0 Then Return False
        If BitConverter.ToInt32(bytes, 0) = 1 Then Return True
        Return Nothing
    End Function 'SettingsRequest

    ''' <summary>
    ''' Get settings update from remote server
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateSettings() As Boolean
        ' Create a TCP/IP socket.
        Dim client As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

        ' Connect to the remote endpoint.
        client.Connect(gRemoteEP)

        ' Send keyword to the remote device.
        client.Send(Encoding.ASCII.GetBytes(gszMyIpAddress & " " & 0.ToString & " " & (mlClientNumber + 3 * glMaxClients).ToString))

        ' Receive Response
        Dim bytes(3) As Byte
        client.ReceiveTimeout = 10000
        Try
            client.Receive(bytes)
        Catch
            Proc.SetStatus(glistBox, gtssl1, "Server is busy! Connection failed.")
            Return Nothing
        End Try

        ' Release the socket.
        client.Shutdown(SocketShutdown.Both)
        client.Close()

        If BitConverter.ToInt32(bytes, 0) = 0 Then Return False
        If BitConverter.ToInt32(bytes, 0) = 1 Then Return True
        Return Nothing
    End Function 'SettingsRequest

    ''' <summary>
    ''' Sends a message to server to get itemlist.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ItemListRequest()
        ' Create a TCP/IP socket.
        Dim client As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

        ' Connect to the remote endpoint.
        client.Connect(gremoteEP)

        ' Send keyword to the remote device.
        client.Send(Encoding.ASCII.GetBytes(gszMyIpAddress & " " & 0.ToString & " " & (mlClientNumber + glMaxClients).ToString))

        ' Release the socket.
        client.Shutdown(SocketShutdown.Both)
        client.Close()
    End Sub 'ItemListRequest

    Private Function ListenStart(ByVal port As Integer) As Integer
        Dim ipHostInfo As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
        Dim ipAddress As IPAddress = Nothing
        For i As Integer = 0 To ipHostInfo.AddressList.Length - 1
            If Proc.IsValidIPv4Address(ipHostInfo.AddressList(i).ToString) Then
                ipAddress = ipHostInfo.AddressList(i)
                Exit For
            End If
        Next
        Dim foundfreeport As Boolean = False

        ' Search for free port
        Do Until foundfreeport
            Dim localEP As New IPEndPoint(ipAddress, port)
            Try
                listener.Bind(localEP)
                foundfreeport = True
            Catch e As Exception
                port += 1
            End Try
        Loop

        listener.Listen(1)
        gblnRemoteClientListen = True

        Return port
    End Function 'ListenStart

    Private Sub ListenAccept()
        ' Accept the request from the server
        If Not gblnRemoteClientConnected Then
            handler = listener.Accept()
            handler.ReceiveTimeout = 20000
            gblnRemoteClientConnected = True
            Proc.SetStatus(glistBox, gtssl1, "Connected with Server on " & gszRemoteMonitorServerAdress & " Port " & mlListenPort)
            Proc.SetStatus(glistBox, gtssl1, "My Client Nr.: " & mlClientNumber.ToString)
            Proc.MnuRemoteMonitorEnabled(gform, gtsmi3, False)
            Proc.NetworkStatus(gform, gtssl2, 0)
        End If
        state = New StateObject

        ' Waiting asynchrounusly for incomming data
        If gblnRemoteClientConnected Then handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveData), state)
    End Sub 'ListenAccept

    Private Sub ReceiveData(ByVal ar As IAsyncResult)
        If Not gblnRemoteClientConnected Then Exit Sub

        Dim loadNewSettings As Boolean = False

        Dim ok() As Byte = Encoding.ASCII.GetBytes("ok")
        Try
            handler.Send(ok)
        Catch
            Disconnected()
            Exit Sub
        End Try

        Dim bytes(buffer) As Byte
        handler.Receive(bytes)

        Dim mode As Integer = Convert.ToInt32(BitConverter.ToUInt16(bytes, 0))
        Dim index As Integer = Convert.ToInt32(BitConverter.ToUInt16(bytes, 2))
        Dim col As Integer = Convert.ToInt32(BitConverter.ToUInt16(bytes, 4))
        Dim length As Integer = Convert.ToInt32(BitConverter.ToUInt16(bytes, 6))
        Dim value As String = Encoding.ASCII.GetString(bytes, 8, length)

        Select Case mode
            Case FWintern.ModeEnum.DecodeSettings '-------------------------    Load settings
                gszSettingstype = value
                glSettingslength = index
                Dim x As Integer = 0
                For i As Integer = 0 To glSettingslength - 1
                    Dim y As Integer = Array.FindIndex(mbList, x, AddressOf FindNull)
                    Dim v As String = Encoding.ASCII.GetString(mbList, x, y - x)
                    gszSettings(i) = v
                    Console.WriteLine(gszSettings(i))
                    x += v.Length + 1
                Next
                ReDim mbList(0)
                gListReceiveDone.Set()
                gListReceiveDone.Reset()
                gSettingsDone.Set()
                gSettingsDone.Reset()
                gszGotSettings = "*"
            Case FWintern.ModeEnum.LoadSettings '---------------------------    Load new settings
                gform.Invoke(New frmMain.mnuRemoteMonitorGetSettings_RemoteCallback(AddressOf frmMain.mnuRemoteMonitorGetSettings_Remote))
                gszGotSettings = ""
                'If gblnRemoteMonitorUpdateSettings Then
                '    gform.Invoke(New frmMain.mnuRemoteMonitorGetSettings_RemoteCallback(AddressOf frmMain.mnuRemoteMonitorGetSettings_Remote))
                'Else
                '    Disconnect()
                '    If MsgBox("Settings were changed." & vbCrLf & "Load new settings?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1) = MsgBoxResult.Yes Then
                '        gblnAcceptSettings = True
                '        gform.Invoke(New frmMain.mnuRemoteMonitor_RemoteCallback(AddressOf frmMain.mnuRemoteMonitor_Remote))
                '        gblnAcceptSettings = False
                '        loadNewSettings = True
                '    Else
                '        If MsgBox("Using a wrong setting could make an error." & vbCrLf & "Are you sure?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1) = MsgBoxResult.Yes Then
                '            gform.Invoke(New frmMain.mnuRemoteMonitor_RemoteCallback(AddressOf frmMain.mnuRemoteMonitor_Remote))
                '            loadNewSettings = True
                '        End If
                '    End If
                'End If
            Case FWintern.ModeEnum.ChangeCell '-----------------------------    Change cell
                If Not index > ItemList.ItemCount Then
                    ItemList.Item(index, col) = value
                    Proc.SetSize(gdgv)
                End If
            Case FWintern.ModeEnum.Renumber '-------------------------------    Renumber
                frmMain.RemoteItemRenumber()
            Case FWintern.ModeEnum.ChangeItemStatus '-----------------------    Change status
                If Not index > ItemList.ItemCount - 1 Then
                    Console.WriteLine("IS " & index & " -> " & col)
                    Select Case col
                        Case 0
                            ItemList.ItemStatus(index) = clsItemList.Status.Fresh
                        Case 1
                            ItemList.ItemStatus(index) = clsItemList.Status.Processing
                        Case 2
                            ItemList.ItemStatus(index) = clsItemList.Status.FinishedOK
                        Case 3
                            ItemList.ItemStatus(index) = clsItemList.Status.FinishedError
                        Case 3
                            ItemList.ItemStatus(index) = clsItemList.Status.Ignored
                    End Select
                End If
            Case FWintern.ModeEnum.DecodeListStatus '-----------------------    Decode Liststatus
                For i As Integer = 0 To ItemList.ItemCount - 1
                    Select Case Convert.ToInt32(Mid(mszList, i + 1, 1))
                        Case 0
                            ItemList.ItemStatus(i) = clsItemList.Status.Fresh
                        Case 1
                            ItemList.ItemStatus(i) = clsItemList.Status.Processing
                        Case 2
                            ItemList.ItemStatus(i) = clsItemList.Status.FinishedOK
                        Case 3
                            ItemList.ItemStatus(i) = clsItemList.Status.FinishedError
                        Case 4
                            ItemList.ItemStatus(i) = clsItemList.Status.Ignored
                    End Select
                    'Windows.Forms.Application.DoEvents()
                Next
                mszList = ""
            Case FWintern.ModeEnum.DecodeNextItem '-------------------------    Decode NextItem
                Dim x As Integer = 0
                For j As Integer = 0 To ItemList.ColCount - 1
                    Dim y As Integer = Array.FindIndex(mbList, x, AddressOf FindNull)
                    Dim v As String = Encoding.ASCII.GetString(mbList, x, y - x)
                    ItemList.Item(index, j) = v
                    x += v.Length + 1
                Next
                Select Case col
                    Case 0
                        ItemList.ItemStatus(index) = clsItemList.Status.Fresh
                    Case 1
                        ItemList.ItemStatus(index) = clsItemList.Status.Processing
                    Case 2
                        ItemList.ItemStatus(index) = clsItemList.Status.FinishedOK
                    Case 3
                        ItemList.ItemStatus(index) = clsItemList.Status.FinishedError
                    Case 4
                        ItemList.ItemStatus(index) = clsItemList.Status.Ignored
                End Select
                Proc.SetSize(gdgv)
                Dim time() As String = value.Split(","c)
                Proc.TimeStatus(gform, gtssl3, time(0))
                Proc.TimeStatus(gform, gtssl4, time(1))
                If gblnRemoteMonitorFollowCurrentItem Then Proc.SelectItem(gdgv, index)
                ReDim mbList(0)
                gListReceiveDone.Set()
                gListReceiveDone.Reset()
            Case FWintern.ModeEnum.DecodeItemList '-------------------------    Decode Itemlist
                Dim x As Integer = 0

                For i As Integer = 0 To ItemList.ItemCount - 1
                    For j As Integer = 0 To Convert.ToInt32(Convert.ToInt32(value) / ItemList.ItemCount) - 1
                        Dim y As Integer = Array.FindIndex(mbList, x, AddressOf FindNull)
                        Dim v As String = Encoding.ASCII.GetString(mbList, x, y - x)
                        ItemList.Item(i, j) = v
                        x += v.Length + 1
                    Next
                Next
                ReDim mbList(0)
                Proc.SetSize(gdgv)
                gListReceiveDone.Set()
                gListReceiveDone.Reset()
            Case FWintern.ModeEnum.DecodeColumnHeaders '-------------------------    Decode ColumnHeaders
                ItemList.Reset()
                Dim x As Integer = 0
                For j As Integer = 1 To col
                    Dim y As Integer = Array.FindIndex(mbList, x, AddressOf FindNull)
                    Dim v As String = Encoding.ASCII.GetString(mbList, x, y - x)
                    Dim w() As String = v.Split(","c)
                    ItemList.AddCol(w(0), CType(w(1), clsItemList.ItemListFlags), w(2), Convert.ToDouble(w(3)), Convert.ToDouble(w(4)))
                    x += v.Length + 1
                Next
                ReDim mbList(0)
            Case FWintern.ModeEnum.DecodeListandHeaders '-------------------------    Decode Itemlist and ColumnHeaders
                ItemList.Reset()
                Dim x As Integer = 0
                For j As Integer = 1 To col
                    Dim y As Integer = Array.FindIndex(mbList, x, AddressOf FindNull)
                    Dim v As String = Encoding.ASCII.GetString(mbList, x, y - x)
                    Dim w() As String = v.Split(","c)
                    ItemList.AddCol(w(0), CType(w(1), clsItemList.ItemListFlags), w(2), Convert.ToDouble(w(3)), Convert.ToDouble(w(4)))
                    x += v.Length + 1
                Next
                Dim done As Boolean = gform.Invoke(New frmMain.RemoteItemCountDelegate(AddressOf frmMain.RemoteItemCount), index)
                For i As Integer = 0 To ItemList.ItemCount - 1
                    For j As Integer = 0 To Convert.ToInt32(Convert.ToInt32(value) / ItemList.ItemCount) - 1
                        Dim y As Integer = Array.FindIndex(mbList, x, AddressOf FindNull)
                        Dim v As String = Encoding.ASCII.GetString(mbList, x, y - x)
                        ItemList.Item(i, j) = v
                        x += v.Length + 1
                    Next
                Next
                For i As Integer = 0 To ItemList.ItemCount - 1
                    Dim y As Integer = Array.FindIndex(mbList, x, AddressOf FindNull)
                    Dim v As String = Encoding.ASCII.GetString(mbList, x, y - x)
                    x += v.Length + 1
                    Select Case Convert.ToInt32(v)
                        Case 0
                            ItemList.ItemStatus(i) = clsItemList.Status.Fresh
                        Case 1
                            ItemList.ItemStatus(i) = clsItemList.Status.Processing
                        Case 2
                            ItemList.ItemStatus(i) = clsItemList.Status.FinishedOK
                        Case 3
                            ItemList.ItemStatus(i) = clsItemList.Status.FinishedError
                        Case 4
                            ItemList.ItemStatus(i) = clsItemList.Status.Ignored
                    End Select
                Next
                ReDim mbList(0)
                Proc.SetSize(gdgv)
                gListReceiveDone.Set()
                gListReceiveDone.Reset()
            Case 50 '-------------------------------------------------------    Change buffersize
                buffer = bufferSmall
                handler.Send(ok)
            Case 51 '-------------------------------------------------------    Change buffersize
                buffer = bufferMedium
                handler.Send(ok)
            Case 52 '-------------------------------------------------------    Change buffersize
                buffer = bufferLarge
                handler.Send(ok)
            Case FWintern.ModeEnum.CreateRows '-----------------------------    Create empty ItemList
                gform.Invoke(New frmMain.RemoteItemCountDelegate(AddressOf frmMain.RemoteItemCount), index)
                handler.Send(ok)
                If Not index = 0 Then
                    Proc.LabelText(glabel, index.ToString)
                Else
                    Proc.LabelText(glabel, "Empty")
                End If
            Case FWintern.ModeEnum.ChangeToBlockingMode '-------------------    Start ReceiveDatas
                handler.Send(ok)
                If Not index = 1 Then Proc.NetworkStatus(gform, gtssl2, 1)
                ReceiveDataSync()
            Case 666 '------------------------------------------------------    Still connected?
                handler.Send(ok)
            Case FWintern.ModeEnum.StartExperiment '------------------------    Experiment started
                Proc.SetStatus(glistBox, gtssl1, "Experiment: Start")
                'Case FWintern.ModeEnum.BeepEveryItem '--------------------------    Beeps
                '    If (glFlagBeepExp And 2) <> 0 Then BeepOnEveryItem()
            Case FWintern.ModeEnum.BeepThirdLast '--------------------------    Beeps
                'If glFlagBeepExp > 0 Then BeepOnThird()
                'If gblnPlayWaveExp = True Then PlayWaveOnThirdLastItem()
            Case FWintern.ModeEnum.BeepSecondLast '-------------------------    Beeps
                'If glFlagBeepExp > 0 Then BeepOnSecond()
                If gblnPlayWaveExp = True Then PlayWaveOnSecondLastItem()
            Case FWintern.ModeEnum.BeepLastItem '---------------------------    Beeps
                'If glFlagBeepExp > 0 Then BeepOnLast()
                If gblnPlayWaveExp = True Then PlayWaveOnLastItem()
            Case FWintern.ModeEnum.BeepEndOfExperiment '--------------------    Beeps
                'If glFlagBeepExp > 0 Then BeepOnEnd()
                Proc.SetStatus(glistBox, gtssl1, "Experiment: End")
                If gblnPlayWaveExp = True Then PlayWaveOnEnd() 'Play wave file
            Case FWintern.ModeEnum.BeepError '------------------------------    Beeps
                'If glFlagBeepExp > 0 Then BeepOnError()
                If gblnPlayWaveExp = True Then PlayWaveOnError() 'Play wave file
            Case FWintern.ModeEnum.BeepBreak '------------------------------    Beeps
                'If glFlagBeepExp > 0 Then BeepOnBreak()
                If gblnPlayWaveExp = True Then PlayWaveOnBreak() 'Play wave file
            Case FWintern.ModeEnum.BeepBlockEnd '---------------------------    Beeps
                'If glFlagBeepExp > 0 Then BeepOnBlockEnd()
            Case FWintern.ModeEnum.Disconnect '-----------------------------    Disconnect
                handler.Send(ok)
                Disconnect()
        End Select
        If gblnRemoteClientConnected Then ListenAccept()

    End Sub 'ReceiveData

    Private Sub ReceiveDataSync()
        If Not gblnRemoteClientConnected Then Exit Sub

        Dim Receive As Boolean = True
        Dim ok() As Byte = Encoding.ASCII.GetBytes("ok")

        While Receive
            Dim bytes(buffer) As Byte
            Try
                handler.Receive(bytes)
            Catch
                Disconnected()
                Exit Sub
            End Try

            Dim mode As Integer = Convert.ToInt32(BitConverter.ToUInt16(bytes, 0))
            Dim index As Integer = Convert.ToInt32(BitConverter.ToUInt16(bytes, 2))
            Dim col As Integer = Convert.ToInt32(BitConverter.ToUInt16(bytes, 4))
            Dim length As Integer = Convert.ToInt32(BitConverter.ToUInt16(bytes, 6))
            Dim value As String = Encoding.ASCII.GetString(bytes, 8, length)

            Select Case mode
                Case FWintern.ModeEnum.SettingsFilename '-----------------------    Settingsfilename
                    glSettingslength = index
                    gszSettingsfilename = value
                Case FWintern.ModeEnum.SendStrings '----------------------------    SendStrings
                    mszlist &= value
                Case FWintern.ModeEnum.SendBytes '------------------------------    SendBytes
                    If mblnListReceive Then gListReceiveDone.WaitOne()
                    Dim x() As Byte
                    If mblist.Length < 2 Then
                        ReDim mblist(length - 1)
                    Else
                        x = mblist
                        ReDim mblist(mblist.Length + length - 1)
                        For i As Integer = 0 To x.Length - 1
                            mblist(i) = x(i)
                        Next
                    End If
                    For i As Integer = 0 To length - 1
                        mblist(mblist.Length - length + i) = bytes(8 + i)
                    Next
                Case 50 '-------------------------------------------------------    Change buffersize
                    buffer = bufferSmall
                    handler.Send(ok)
                Case 51 '-------------------------------------------------------    Change buffersize
                    buffer = bufferMedium
                    handler.Send(ok)
                Case 52 '-------------------------------------------------------    Change buffersize
                    buffer = bufferLarge
                    handler.Send(ok)
                Case FWintern.ModeEnum.CreateRows '-----------------------------    Create empty ItemList
                    gform.Invoke(New frmMain.RemoteItemCountDelegate(AddressOf frmMain.RemoteItemCount), index)
                    handler.Send(ok)
                    If Not index = 0 Then
                        Proc.LabelText(glabel, index.ToString)
                    Else
                        Proc.LabelText(glabel, "Empty")
                    End If
                Case FWintern.ModeEnum.ChangeToBlockingMode '-------------------    End ReceiveDatas (101)
                    handler.Send(ok)
                    Receive = False
                    If Not index = 1 Then Proc.NetworkStatus(gform, gtssl2, 0)
                Case 666 '------------------------------------------------------    Still Connected?
                    handler.Send(ok)
            End Select
        End While
    End Sub 'ReceiveDatas

    Private Function FindNull(ByVal b As Byte) As Boolean
        If b = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Module