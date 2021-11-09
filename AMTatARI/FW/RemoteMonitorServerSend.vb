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
Imports System.Text
Imports System.Threading

Module RemoteMonitorServerSend

    Private mbStart() As Byte = Encoding.ASCII.GetBytes("1")
    Public Const glMaxClients As Integer = 5
    Public sender(glMaxClients) As Object
    Public clients(glMaxClients) As Boolean
    Public gblnClientsSetting(glMaxClients) As Boolean
    Public buffer As Integer = bufferSmall
    Private mlBufferArray(glMaxClients) As Integer
    Private mbOk(1) As Byte

    ''' <summary>
    ''' Connects to requesting client.
    ''' </summary>
    ''' <param name="szClient">Client IP-Address</param>
    ''' <param name="port">Client port</param>
    ''' <param name="clientNumber">Clientnumber for choosing right object in sender array.</param>
    ''' <remarks>ConnectToClient creates a new sender socket, stores it in a sender array<br>and tries to connect to client.</br></remarks>
    Public Sub ConnectToClient(ByVal szClient As String, ByVal port As Integer, ByVal clientNumber As Integer)
        Dim ipClient As IPHostEntry = Dns.GetHostEntry(szClient)
        Dim serverAddress As IPAddress = ipClient.AddressList(0)
        Dim EP As New IPEndPoint(serverAddress, port)

        If clientNumber = 0 Then
            Dim sender1 As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            sender1.ReceiveTimeout = 30000
            ' Save the socket in an objectarray for later use
            sender(glClientCount) = sender1

            ' Connect to client
            Try
                sender(glClientCount).Connect(EP)
                Proc.MnuRemoteMonitorEnabled(gform, gtsmi2, True)
                If Not gblnRemoteServerConnected Then
                    Proc.MnuRemoteMonitorEnabled(gform, gtsmi1, True)
                End If
                gblnRemoteServerConnected = True
                clients(glClientCount) = True
                gblnClientsSetting(glClientCount) = True
                mlBufferArray(glClientCount) = bufferSmall
                Proc.SetStatus(glistBox, gtssl1, "Connected with Client on " & szClient & " Port " & port.ToString)
                Proc.MnuRemoteMonitorEnabled(gform, gtsmi3, False)
                Proc.NetworkStatus(gform, gtssl2, 0)
            Catch e As Exception
            End Try
        Else
            Dim sender1 As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            ' Save the socket in an objectarray for later use
            sender(clientNumber) = sender1

            ' Connect to client
            Try
                sender(clientNumber).Connect(EP)
                Proc.MnuRemoteMonitorEnabled(gform, gtsmi2, True)
                If Not gblnRemoteServerConnected Then
                    Proc.MnuRemoteMonitorEnabled(gform, gtsmi1, True)
                End If
                gblnRemoteServerConnected = True
                clients(clientNumber) = True
                gblnClientsSetting(glClientCount) = True
                mlBufferArray(glClientCount) = bufferSmall
                Proc.SetStatus(glistBox, gtssl1, "Connected with Client on " & szClient & " Port " & port.ToString)
                Proc.MnuRemoteMonitorEnabled(gform, gtsmi3, False)
                Proc.NetworkStatus(gform, gtssl2, 0)
            Catch e As Exception
            End Try
        End If
    End Sub 'ConnectToClient

    ''' <summary>
    ''' Sends data to all connected clients.
    ''' </summary>
    ''' <param name="mode"></param>
    ''' <param name="index"></param>
    ''' <param name="col"></param>
    ''' <param name="value"></param>
    ''' <remarks>SendData changes buffersize, creates a bytearray and sends it to all clients. Before sending the bytearray<br>a start message and a response is nessecary, becaus of the asynchronous mode of the client.</br></remarks>
    Public Sub SendData(ByVal mode As FWintern.ModeEnum, ByVal index As Integer, ByVal col As Integer, ByVal value As String)
        StillConnected(False)

        'Dim ok(1) As Byte
        Dim bytes(buffer) As Byte
        Dim bvalue As Byte() = Encoding.ASCII.GetBytes(value)
        Dim length As Integer = bvalue.Length

        ChangeBufferSize(length, False)

        ' Write data to a bytearray
        bytes = GetByteArray(mode, index, col, value, length)

        For i As Integer = 1 To glClientCount
            If clients(i) Then
                sender(i).Send(mbStart)
                sender(i).Receive(mbOk)
                sender(i).Send(bytes)

                If mode = 101 Or mode = 100 Then 'Wait for a response
                    sender(i).Receive(mbOk)
                End If
            End If
        Next
    End Sub 'SendData

    ''' <summary>
    ''' Sends data to all connected clients.
    ''' </summary>
    ''' <param name="mode"></param>
    ''' <param name="index"></param>
    ''' <param name="col"></param>
    ''' <param name="value"></param>
    ''' <remarks>SendData changes buffersize, creates a bytearray and sends it to all clients. Client has to be in synchronous mode.</remarks>
    Public Sub SendDataSync(ByVal mode As FWintern.ModeEnum, ByVal index As Integer, ByVal col As Integer, ByVal value As String)
        StillConnected(True)

        Dim bytes(buffer) As Byte
        Dim bvalue As Byte() = Encoding.ASCII.GetBytes(value)
        Dim length As Integer = bvalue.Length

        ChangeBufferSize(length, True)

        ' Write data to a bytearray
        bytes = GetByteArray(mode, index, col, value, length)

        For i As Integer = 1 To glClientCount
            If clients(i) Then
                sender(i).Send(bytes)

                If mode = 101 Or mode = 100 Then 'Wait for a response
                    sender(i).Receive(mbOk)
                End If
            End If
        Next
    End Sub 'SendDataSync

    ''' <summary>
    ''' Sends data to all connected clients.
    ''' </summary>
    ''' <param name="mode"></param>
    ''' <param name="index"></param>
    ''' <param name="col"></param>
    ''' <param name="bvalue"></param>
    ''' <remarks></remarks>
    Public Sub SendDataSync(ByVal mode As FWintern.ModeEnum, ByVal index As Integer, ByVal col As Integer, ByVal bvalue() As Byte)
        StillConnected(True)

        Dim length As Integer = bvalue.Length
        ChangeBufferSize(length, True)
        Dim bytes(buffer) As Byte

        ' Write data to a bytearray
        bytes = GetByteArray(mode, index, col, bvalue, length)

        For i As Integer = 1 To glClientCount
            If clients(i) Then
                sender(i).Send(bytes)

                If mode = 101 Or mode = 100 Then 'Wait for a response
                    sender(i).Receive(mbOk)
                End If
            End If
        Next
    End Sub 'SendDataSync(bytes)

    ''' <summary>
    ''' Sends data to one specified client.
    ''' </summary>
    ''' <param name="mode"></param>
    ''' <param name="index"></param>
    ''' <param name="col"></param>
    ''' <param name="value"></param>
    ''' <param name="cnum">Clientnumber</param>
    ''' <remarks>SendData changes buffersize, creates a bytearray and sends it to one specified client. Before sending the bytearray<br>a start message and a response is nessecary, becaus of the asynchronous mode of the client.</br></remarks>
    Public Sub SendData(ByVal mode As FWintern.ModeEnum, ByVal index As Integer, ByVal col As Integer, ByVal value As String, ByVal cnum As Integer)
        StillConnected(False, cnum)

        Dim bytes(buffer) As Byte
        Dim bvalue As Byte() = Encoding.ASCII.GetBytes(value)
        Dim length As Integer = bvalue.Length

        ChangeBufferSize(length, False, cnum)

        ' Write data to a bytearray
        bytes = GetByteArray(mode, index, col, value, length)

        sender(cnum).send(mbStart)
        sender(cnum).Receive(mbOk)
        sender(cnum).send(bytes)

        If mode = 101 Or mode = 100 Then 'Wait for a response
            sender(cnum).Receive(mbOk)
        End If
    End Sub 'SendData to specific client

    ''' <summary>
    ''' Sends data to one specified client.
    ''' </summary>
    ''' <param name="mode"></param>
    ''' <param name="index"></param>
    ''' <param name="col"></param>
    ''' <param name="value"></param>
    ''' <param name="cnum">Clientnumber</param>
    ''' <remarks>SendData changes buffersize, creates a bytearray and sends it to one specified client. Client has to be in synchronous mode.</remarks>
    Public Sub SendDataSync(ByVal mode As FWintern.ModeEnum, ByVal index As Integer, ByVal col As Integer, ByVal value As String, ByVal cnum As Integer)
        StillConnected(True, cnum)

        Dim bytes(buffer) As Byte
        Dim bvalue As Byte() = Encoding.ASCII.GetBytes(value)
        Dim length As Integer = bvalue.Length

        ChangeBufferSize(length, True, cnum)

        ' Write data to a bytearray
        bytes = GetByteArray(mode, index, col, value, length)

        sender(cnum).send(bytes)

        If mode = 101 Or mode = 100 Then 'Wait for a response
            sender(cnum).Receive(mbOk)
        End If
    End Sub 'SendDatas(to specific client)

    ''' <summary>
    ''' Sends data to one specified client.
    ''' </summary>
    ''' <param name="mode"></param>
    ''' <param name="index"></param>
    ''' <param name="col"></param>
    ''' <param name="bvalue"></param>
    ''' <param name="cnum">Clientnumber</param>
    ''' <remarks>SendData changes buffersize, creates a bytearray and sends it to one specified client. Client has to be in synchronous mode.</remarks>
    Public Sub SendDataSync(ByVal mode As FWintern.ModeEnum, ByVal index As Integer, ByVal col As Integer, ByVal bvalue() As Byte, ByVal cnum As Integer)
        StillConnected(True, cnum)

        Dim length As Integer = bvalue.Length
        ChangeBufferSize(length, True, cnum)
        Dim bytes(buffer) As Byte

        ' Write data to a bytearray
        bytes = GetByteArray(mode, index, col, bvalue, length)

        sender(cnum).Send(bytes)

        If mode = 101 Or mode = 100 Then 'Wait for a response
            sender(cnum).Receive(mbOk)
        End If
    End Sub 'SendDataSync(bytes)

    Private Sub StillConnected()
        If Not gblnRemoteServerConnected Then Exit Sub

        For i As Integer = 1 To glClientCount
            If clients(i) Then
                Dim bytes(mlBufferArray(i)) As Byte
                Dim x As Byte() = BitConverter.GetBytes(Convert.ToInt16(666))
                bytes(0) = x(0)
                bytes(1) = x(1)
                Try
                    sender(i).send(mbStart)
                    sender(i).receive(mbOk)
                    sender(i).send(bytes)
                    sender(i).receive(mbOk)
                Catch
                    sender(i).shutdown(SocketShutdown.Both)
                    sender(i).disconnect(True)
                    sender(i) = Nothing
                    clients(i) = False
                    gblnClientsSetting(i) = False
                    mlBufferArray(i) = bufferSmall
                    Proc.SetStatus(glistBox, gtssl1, "No response from Client " & i.ToString & " .")
                    Proc.SetStatus(glistBox, gtssl1, "Client " & i.ToString & " is disconnected.")
                End Try
            End If
        Next
        For i As Integer = 1 To glClientCount
            If clients(i) Then
                gblnRemoteServerConnected = True
                Exit For
            Else
                gblnRemoteServerConnected = False
            End If
        Next
        If Not gblnRemoteServerConnected Then
            Proc.NetworkStatus(gform, gtssl2, 2)
            Proc.SetStatus(glistBox, gtssl1, "No Clients connected.")
            Proc.MnuRemoteMonitorEnabled(gform, gtsmi1, True)
        End If
    End Sub 'StillConnected(uses buffersize array)

    Private Sub StillConnected(ByVal datas As Boolean)
        If Not gblnRemoteServerConnected Then Exit Sub
        Dim bytes() As Byte
        bytes = GetByteArray(666, 0, 0, "", 0)

        For i As Integer = 1 To glClientCount
            If clients(i) Then
                Try
                    If Not datas Then
                        sender(i).send(mbStart)
                        sender(i).receive(mbOk)
                    End If
                    sender(i).send(bytes)
                    sender(i).receive(mbOk)
                Catch
                    sender(i).shutdown(SocketShutdown.Both)
                    sender(i).disconnect(True)
                    sender(i) = Nothing
                    clients(i) = False
                    gblnClientsSetting(i) = False
                    mlBufferArray(i) = bufferSmall
                    Proc.SetStatus(glistBox, gtssl1, "No response from Client " & i.ToString & " .")
                    Proc.SetStatus(glistBox, gtssl1, "Client " & i.ToString & " is disconnected.")
                End Try
            End If
        Next
        For i As Integer = 1 To glClientCount
            If clients(i) Then
                gblnRemoteServerConnected = True
                Exit For
            Else
                gblnRemoteServerConnected = False
            End If
        Next
        If Not gblnRemoteServerConnected Then
            Proc.NetworkStatus(gform, gtssl2, 2)
            Proc.SetStatus(glistBox, gtssl1, "No clients connected.")
            Proc.MnuRemoteMonitorEnabled(gform, gtsmi1, True)
        End If
    End Sub 'StillConnected(With synchronized buffersize)

    Private Sub StillConnected(ByVal datas As Boolean, ByVal cnum As Integer)
        If Not gblnRemoteServerConnected Then Exit Sub
        Dim bytes() As Byte
        bytes = GetByteArray(666, 0, 0, "", 0)

        Try
            If Not datas Then
                sender(cnum).Send(mbStart)
                sender(cnum).Receive(mbOk)
            End If
            sender(cnum).Send(bytes)
            sender(cnum).Receive(mbOk)
        Catch
            sender(cnum).shutdown(SocketShutdown.Both)
            sender(cnum).disconnect(True)
            sender(cnum) = Nothing
            clients(cnum) = False
            gblnClientsSetting(cnum) = False
            mlBufferArray(cnum) = bufferSmall
            Proc.SetStatus(glistBox, gtssl1, "No response from Client " & cnum.ToString & " .")
            Proc.SetStatus(glistBox, gtssl1, "Client " & cnum.ToString & " is disconnected.")
        End Try
        For i As Integer = 1 To glClientCount
            If clients(i) Then
                gblnRemoteServerConnected = True
                Exit For
            Else
                gblnRemoteServerConnected = False
            End If
        Next
        If Not gblnRemoteServerConnected Then
            Proc.NetworkStatus(gform, gtssl2, 2)
            Proc.SetStatus(glistBox, gtssl1, "No clients connected.")
            Proc.MnuRemoteMonitorEnabled(gform, gtsmi1, True)
        End If
    End Sub 'StillConnected(to specific client with synchronized buffersize)

    ''' <summary>
    ''' Sends a message to all connected clients to disconnect.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Disconnect()
        'For i As Integer = 1 To clientCount
        '    If clients(i) And clientssetting(i) Then
        '        sender(i).send(start)
        '        sender(i).receive(ok)
        '        sender(i).send(GetByteArray(1000, 0, 0, "1", 1))
        '        sender(i).receive(ok)
        '        Sleep(100)
        '    End If
        'Next
        For i As Integer = 1 To glClientCount
            If clients(i) Then
                StillConnected(False, i)
                If clients(i) Then
                    sender(i).receivetimeout = 3000
                    Try
                        sender(i).send(mbStart)
                        sender(i).receive(mbOk)
                        sender(i).send(GetByteArray(1000, 0, 0, "1", 1))
                        sender(i).receive(mbOk)
                        'Sleep(100)
                    Catch
                        sender(i).shutdown(SocketShutdown.Both)
                        sender(i).disconnect(True)
                        sender(i) = Nothing
                        clients(i) = False
                        gblnClientsSetting(i) = False
                        mlBufferArray(i) = bufferSmall
                        Proc.SetStatus(glistBox, gtssl1, "Client " & i.ToString & " is disconnected.")
                    End Try
                End If
            End If
        Next
        gblnRemoteServerDisconnected = True
        gblnRemoteServerConnected = False
    End Sub 'Disconnect

    ''' <summary>
    ''' Closes a specified socket in sender array and deletes the object.
    ''' </summary>
    ''' <param name="cnum">Client number</param>
    ''' <remarks></remarks>
    Public Sub Disconnect(ByVal cnum As Integer)
        sender(cnum).shutdown(SocketShutdown.Both)
        sender(cnum).disconnect(True)
        sender(cnum) = Nothing
        mlBufferArray(cnum) = bufferSmall
        Proc.SetStatus(glistBox, gtssl1, "Client " & cnum.ToString & " is disconnected")
    End Sub 'Disconnect

    Private Function GetByteArray(ByVal mode As Integer, ByVal index As Integer, ByVal col As Integer, ByVal value As String, ByVal length As Integer) As Byte()
        Dim bytes(buffer) As Byte
        Dim bmode As Byte() = BitConverter.GetBytes(Convert.ToUInt16(mode))
        Dim bindex As Byte() = BitConverter.GetBytes(Convert.ToUInt16(index))
        Dim bcol As Byte() = BitConverter.GetBytes(Convert.ToUInt16(col))
        Dim bvalue As Byte() = Encoding.ASCII.GetBytes(value)
        Dim blength As Byte() = BitConverter.GetBytes(Convert.ToUInt16(length))

        For i As Integer = 0 To 1
            bytes(i) = bmode(i)
            bytes(i + 2) = bindex(i)
            bytes(i + 4) = bcol(i)
            bytes(i + 6) = blength(i)
        Next
        For i As Integer = 0 To length - 1
            bytes(i + 8) = bvalue(i)
        Next

        Return bytes
    End Function 'GetByteArray(value as string)

    Private Function GetByteArray(ByVal mode As Integer, ByVal index As Integer, ByVal col As Integer, ByVal bvalue() As Byte, ByVal length As Integer) As Byte()
        Dim bytes(buffer) As Byte
        Dim bmode As Byte() = BitConverter.GetBytes(Convert.ToUInt16(mode))
        Dim bindex As Byte() = BitConverter.GetBytes(Convert.ToUInt16(index))
        Dim bcol As Byte() = BitConverter.GetBytes(Convert.ToUInt16(col))
        Dim blength As Byte() = BitConverter.GetBytes(Convert.ToUInt16(length))

        For i As Integer = 0 To 1
            bytes(i) = bmode(i)
            bytes(i + 2) = bindex(i)
            bytes(i + 4) = bcol(i)
            bytes(i + 6) = blength(i)
        Next
        For i As Integer = 0 To length - 1
            bytes(i + 8) = bvalue(i)
        Next

        Return bytes
    End Function 'GetByteArray(bvalue as byte)

    Private Sub ChangeBufferSize(ByVal length As Integer, ByVal datas As Boolean)
        Select Case length
            Case 0 To bufferSmall - 7
                If Not buffer = bufferSmall Then
                    Dim setbuffer(buffer) As Byte
                    setbuffer = GetByteArray(50, 0, 0, "", 0)
                    For i As Integer = 1 To glClientCount
                        If clients(i) Then
                            If Not datas Then
                                sender(i).Send(mbStart)
                                sender(i).Receive(mbOk)
                            End If
                            sender(i).Send(setbuffer)
                            sender(i).Receive(mbOk)
                            mlBufferArray(i) = bufferSmall
                        End If
                    Next
                    buffer = bufferSmall
                End If
            Case bufferSmall - 6 To bufferMedium - 7
                If Not buffer = bufferMedium Then
                    Dim setbuffer(buffer) As Byte
                    setbuffer = GetByteArray(51, 0, 0, "", 0)
                    For i As Integer = 1 To glClientCount
                        If clients(i) Then
                            If Not datas Then
                                sender(i).Send(mbStart)
                                sender(i).Receive(mbOk)
                            End If
                            sender(i).Send(setbuffer)
                            sender(i).Receive(mbOk)
                            mlBufferArray(i) = bufferMedium
                        End If
                    Next
                    buffer = bufferMedium
                End If
            Case bufferMedium - 6 To bufferLarge - 7
                If Not buffer = bufferLarge Then
                    Dim setbuffer(buffer) As Byte
                    setbuffer = GetByteArray(52, 0, 0, "", 0)
                    For i As Integer = 1 To glClientCount
                        If clients(i) Then
                            If Not datas Then
                                sender(i).Send(mbStart)
                                sender(i).Receive(mbOk)
                            End If
                            sender(i).Send(setbuffer)
                            sender(i).Receive(mbOk)
                            mlBufferArray(i) = bufferLarge
                        End If
                    Next
                    buffer = bufferLarge
                End If
        End Select
    End Sub 'ChangeBufferSize

    Private Sub ChangeBufferSize(ByVal length As Integer, ByVal datas As Boolean, ByVal cnum As Integer)
        Select Case length
            Case 0 To bufferSmall - 7
                If Not buffer = bufferSmall Then
                    Dim setbuffer(buffer) As Byte
                    setbuffer = GetByteArray(50, 0, 0, "", 0)
                    If Not datas Then
                        sender(cnum).send(mbStart)
                        sender(cnum).Receive(mbOk)
                    End If
                    sender(cnum).send(setbuffer)
                    sender(cnum).Receive(mbOk)
                    buffer = bufferSmall
                    mlBufferArray(cnum) = bufferSmall
                End If
            Case bufferSmall - 6 To bufferMedium - 7
                If Not buffer = bufferMedium Then
                    Dim setbuffer(buffer) As Byte
                    setbuffer = GetByteArray(51, 0, 0, "", 0)
                    If Not datas Then
                        sender(cnum).send(mbStart)
                        sender(cnum).Receive(mbOk)
                    End If
                    sender(cnum).send(setbuffer)
                    sender(cnum).Receive(mbOk)
                    buffer = bufferMedium
                    mlBufferArray(cnum) = bufferMedium
                End If
            Case bufferMedium - 6 To bufferLarge - 7
                If Not buffer = bufferLarge Then
                    Dim setbuffer(buffer) As Byte
                    setbuffer = GetByteArray(52, 0, 0, "", 0)
                    If Not datas Then
                        sender(cnum).send(mbStart)
                        sender(cnum).Receive(mbOk)
                    End If
                    sender(cnum).send(setbuffer)
                    sender(cnum).Receive(mbOk)
                    buffer = bufferLarge
                    mlBufferArray(cnum) = bufferLarge
                End If
        End Select
    End Sub 'ChangeBufferSize(to specific client)

    ''' <summary>
    ''' Synchronizes the buffersize with all clients.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetBufferSize()
        StillConnected()
        For i As Integer = 1 To glClientCount
            If clients(i) Then
                Dim setbuffer(mlBufferArray(i)) As Byte
                Dim x As Byte() = BitConverter.GetBytes(Convert.ToInt16(50))
                setbuffer(0) = x(0)
                setbuffer(1) = x(1)
                sender(i).Send(mbStart)
                sender(i).Receive(mbOk)
                sender(i).Send(setbuffer)
                sender(i).Receive(mbOk)
                mlBufferArray(i) = bufferSmall
            End If
        Next
        buffer = bufferSmall
    End Sub 'SetBufferSize
End Module
