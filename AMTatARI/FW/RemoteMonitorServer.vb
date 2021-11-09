Option Strict On
Option Explicit On
Option Infer On
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
Imports System.Text
Imports System.Threading

Module RemoteMonitorServer

    Private Class StateObject
        ' Client  socket.
        Public workSocket As Socket = Nothing
        ' Size of receive buffer.
        Public Const BufferSize As Integer = 127
        ' Receive buffer.
        Public buffer(BufferSize) As Byte
        ' Received data string.
        Public sb As New StringBuilder
    End Class 'StateObject

    ' Save objects for invokes
    Public gform As Form
    Public glistBox As ListBox
    Public gtssl1 As ToolStripStatusLabel
    Public gtssl2 As ToolStripStatusLabel
    Public gtssl3 As ToolStripStatusLabel
    Public gtssl4 As ToolStripStatusLabel
    Public glabel As Label
    Public gdgv As DataGridView
    Public gtsmi1 As ToolStripMenuItem
    Public gtsmi2 As ToolStripMenuItem
    Public gtsmi3 As ToolStripMenuItem
    Public glabel2 As Label

    Public gblnKickClients As Boolean = False

    ' Load Settings?
    Public gblnLoadSettings As Boolean = False

    ' Listening Port des Servers.
    Private Const mlListenport As Integer = 10002

    ' Counts the number of clientrequests.
    Public glClientCount As Integer = 0

    ' My ipAdress.
    Public gszMyIpAddress As String

    ' Address and Port of client.
    Private mszClientAddress As String
    Private mlClientPort As Integer
    Private mlClientNumber As Integer

    ' Thread signal.
    Public allDone As New ManualResetEvent(False)
    Public disconnectresetevent As New ManualResetEvent(False)

    ' Create a TCP/IP socket.
    Dim listener As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

    ' The server waits for connections and then uses asychronous operations to accept the connection.
    ' He can receive requests for connection, settings, itemlist and disconnection. After a connectionrequest
    ' the server starts a sender socket in RemoteMonitorServerSend for connecting to the client.

    ''' <summary>
    ''' Starts listening on port 10002.
    ''' </summary>
    ''' <remarks>Init binds a listener to local host IP-Address and port 10002 and starts listening.</remarks>
    Public Sub Init(ByVal form As Form, ByVal listbox As ListBox, ByVal label As Label, ByVal tssl1 As ToolStripStatusLabel, ByVal tssl2 As ToolStripStatusLabel, ByVal tssl3 As ToolStripStatusLabel, ByVal tssl4 As ToolStripStatusLabel, ByRef dgv As DataGridView, ByVal tsmi1 As ToolStripMenuItem, ByVal tsmi2 As ToolStripMenuItem, ByVal tsmi3 As ToolStripMenuItem, ByVal label2 As Label)
        gform = form
        glistBox = listbox
        glabel = label
        gtssl1 = tssl1
        gtssl2 = tssl2
        gtssl3 = tssl3
        gtssl4 = tssl4
        gdgv = dgv
        gtsmi1 = tsmi1
        gtsmi2 = tsmi2
        gtsmi3 = tsmi3
        glabel2 = label2

        frmMain.CheckForIllegalCrossThreadCalls = False

        ' Establish the local endpoint for the socket.
        Dim ipHostInfo As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
        Dim ipAddress As IPAddress = Nothing
        For i As Integer = 0 To ipHostInfo.AddressList.Length - 1
            If Proc.IsValidIPv4Address(ipHostInfo.AddressList(i).ToString) Then
                ipAddress = ipHostInfo.AddressList(i)
                Exit For
            End If
        Next
        gszMyIpAddress = ipAddress.ToString
        Dim localEndPoint As New IPEndPoint(ipAddress, mlListenport)
        Dim portUnavailable As Boolean = False

        Try
            ' Bind the socket to the local endpoint and listen for incoming connections.
            listener.Bind(localEndPoint)
        Catch e As Exception
            Proc.SetStatus(glistBox, gtssl1, "Port 10002 already used")
            portUnavailable = True
        End Try

        If Not portUnavailable Then
            listener.Listen(2)

            ' Waiting asyncronously for a connectionrequest
            If Not gblnRemoteServerDisconnected Then
                listener.BeginAccept(New AsyncCallback(AddressOf AcceptCallback), listener)
            End If
        End If
        'End If

    End Sub 'Init

    Private Sub RestartAccept()
        listener.BeginAccept(New AsyncCallback(AddressOf AcceptCallback), listener)
    End Sub 'Restart Accept

    Private Sub AcceptCallback(ByVal ar As IAsyncResult)
        If gblnRemoteMonitorServerEnabled And Not gblnRemoteServerDisconnected Then
            ' Get the socket that handles the client request.
            Dim listener As Socket = CType(ar.AsyncState, Socket)
            ' End the operation.
            'If Not gblnRemoteServerDisconnected Then

            Dim handler As Socket = listener.EndAccept(ar)
            ' Create the state object for the async receive.
            Dim state As New StateObject
            state.workSocket = handler
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReadCallback), state)
            'End If
        End If
    End Sub 'AcceptCallback

    Private Sub ReadCallback(ByVal ar As IAsyncResult)
        If Not gblnRemoteBlockIncommingMessages Then
            Dim content As String = String.Empty

            ' Retrieve the state object and the handler socket
            ' from the asynchronous state object.
            Dim state As StateObject = CType(ar.AsyncState, StateObject)
            Dim handler As Socket = state.workSocket

            ' Read data from the client socket. 
            Dim bytesRead As Integer = handler.EndReceive(ar)

            If bytesRead > 0 Then
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead))

                content = state.sb.ToString()
                Dim contentarray() As String = content.Split()
                mszClientAddress = contentarray(0)
                mlClientPort = Convert.ToInt32(contentarray(1))

                Select Case Convert.ToInt32(contentarray(2))
                    Case Is = 0 'Client wants to connect
                        glClientCount += 1
                        mlClientNumber = SearchSenderArray()
                        If mlClientNumber = 0 Then 'just one client
                            If glClientCount > glMaxClients Then
                                handler.Send(Encoding.ASCII.GetBytes(0.ToString))
                                glClientCount -= 1
                                RestartAccept()
                            Else
                                'Send Application title & version number
                                Send(handler, glClientCount.ToString & "," & gszAPP_TITLE & "," & gszAPP_VERSION)
                            End If
                        Else
                            'Send Application title & version number
                            Send(handler, mlClientNumber.ToString & "," & gszAPP_TITLE & "," & gszAPP_VERSION)
                        End If
                    Case 1 To glMaxClients 'Client wants to load the settings
                        If Not gblnSettingsLoaded1 Then
                            handler.Send(BitConverter.GetBytes(0))
                            'gblnClientsSetting(Convert.ToInt32(contentarray(2))) = True
                            RestartAccept()
                        Else
                            gblnLoadSettings = True
                            handler.Send(BitConverter.GetBytes(1))
                            'gblnClientsSetting(Convert.ToInt32(contentarray(2))) = True
                            gform.Invoke(New frmMain.ServeDataDelegate(AddressOf frmMain.ServeData), FWintern.ServeDataEnum.SendSettings1, 0, 0, "", Convert.ToInt32(contentarray(2)))
                            RestartAccept()
                        End If
                    Case 3 * glMaxClients + 1 To 4 * glMaxClients 'Update Settings
                        If gblnClientsSetting(Convert.ToInt32(contentarray(2)) - 3 * glMaxClients) Then
                            gblnClientsSetting(Convert.ToInt32(contentarray(2)) - 3 * glMaxClients) = False
                            handler.Send(BitConverter.GetBytes(0))
                            RestartAccept()
                        Else
                            gblnClientsSetting(Convert.ToInt32(contentarray(2)) - 3 * glMaxClients) = True
                            handler.Send(BitConverter.GetBytes(1))
                            RestartAccept()
                        End If
                    Case glMaxClients + 1 To 2 * glMaxClients 'Client wants to load the Itemlist and Itemstatus
                        If ItemList.ItemCount > 0 Then gform.Invoke(New frmMain.ServeDataDelegate(AddressOf frmMain.ServeData), FWintern.ServeDataEnum.ItemlistColCountListStatus1, 0, 0, "", Convert.ToInt32(contentarray(2)) - glMaxClients)
                        If ItemList.ItemCount > 0 Then gform.Invoke(New frmMain.ServeDataDelegate(AddressOf frmMain.ServeData), FWintern.ServeDataEnum.ListStatus, 0, 0, "", Convert.ToInt32(contentarray(2)) - glMaxClients)
                        RestartAccept()
                    Case 2 * glMaxClients + 1 To 3 * glMaxClients 'Client wants to disconnect
                        clients(Convert.ToInt32(contentarray(2)) - 2 * glMaxClients) = False
                        gblnClientsSetting(Convert.ToInt32(contentarray(2)) - 2 * glMaxClients) = False
                        RemoteMonitorServerSend.Disconnect(Convert.ToInt32(contentarray(2)) - 2 * glMaxClients)
                        For i As Integer = 1 To glClientCount
                            If clients(i) Then
                                gblnRemoteServerConnected = True
                                Exit For
                            Else
                                gblnRemoteServerConnected = False
                                Proc.NetworkStatus(gform, gtssl2, 2)
                            End If
                        Next
                        If Not gblnRemoteServerConnected Then
                            disconnectresetevent.Set()
                            Proc.SetStatus(glistBox, gtssl1, "No clients connected!")
                            Proc.MnuRemoteMonitorEnabled(gform, gtsmi2, False)
                            Proc.MnuRemoteMonitorEnabled(gform, gtsmi3, True)
                        End If
                        RestartAccept()
                End Select
            End If
        Else
            RestartAccept()
        End If
    End Sub 'ReadCallback

    Private Sub Send(ByVal handler As Socket, ByVal data As String)
        ' Convert the string data to byte data using ASCII encoding.
        Dim byteData As Byte() = Encoding.ASCII.GetBytes(data)

        ' Begin sending the data to the remote device.
        handler.BeginSend(byteData, 0, byteData.Length, 0, New AsyncCallback(AddressOf SendCallback), handler)
    End Sub 'Send

    Private Sub SendCallback(ByVal ar As IAsyncResult)
        ' Retrieve the socket from the state object.
        Dim handler As Socket = CType(ar.AsyncState, Socket)

        ' Complete sending the data to the remote device.
        Dim bytesSent As Integer = handler.EndSend(ar)
        handler.Disconnect(False)
        handler.Shutdown(SocketShutdown.Both)
        handler.Close()
        RestartAccept()
        RemoteMonitorServerSend.ConnectToClient(mszClientAddress, mlClientPort, mlClientNumber)
    End Sub 'SendCallback

    ''' <summary>
    ''' Disconnects from all clients and closes listener socket.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Disconnect()
        If gblnRemoteServerConnected Then
            RemoteMonitorServerSend.Disconnect()
        End If
        If Not gblnKickClients Then listener.Close()
        If gblnRemoteServerConnected Then
            disconnectresetevent.WaitOne()
            glClientCount = 0
        End If
        gblnRemoteServerDisconnected = Not gblnKickClients
        Proc.NetworkStatus(gform, gtssl2, 2)
        If gblnKickClients Then RestartAccept()
    End Sub 'Disconnect

    Private Function SearchSenderArray() As Integer
        'Searches for free socket between 0 and clientcount
        For i As Integer = 1 To glClientCount - 1
            If sender(i) Is Nothing And glClientCount - 1 <= glMaxClients Then
                glClientCount -= 1
                Return i
            End If
        Next
        Return 0
    End Function 'SearchSenderArray
End Module
