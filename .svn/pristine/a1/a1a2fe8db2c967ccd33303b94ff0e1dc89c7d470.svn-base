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
''' FrameWork - Open Sound Control (OSC) support
''' </summary>
''' <remarks>OSC module provides an access to the OSC protocol (written by Matt Wright)
'''
''' <br>Author: Piotr Majdak piotr@majdak.com</br></remarks>
Module OSC
	
    Public Function PreparePacket(ByVal szAddr As String, Optional ByVal varArgs() As Object = Nothing) As Byte()

        ' encode address
        Dim bytBuf() As Byte = System.Text.ASCIIEncoding.ASCII.GetBytes(szAddr)
        CorrectPacketSize(bytBuf)

        If varArgs.Length > 0 Then
            ' encodes types 
            Dim szTypes As String = ","
            For Each varX As Object In varArgs
                Select Case TypeName(varX)
                    Case "Byte", "Integer", "Long", "Short"
                        szTypes = szTypes & "i"
                    Case "Single", "Double"
                        szTypes = szTypes & "f"
                    Case "String"
                        szTypes = szTypes & "s"
                End Select
            Next varX
            Dim bytTypes As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(szTypes)
            ReDim Preserve bytBuf(bytBuf.Length - 1 + bytTypes.Length)
            Array.ConstrainedCopy(bytTypes, 0, bytBuf, bytBuf.Length - bytTypes.Length, bytTypes.Length)
            CorrectPacketSize(bytBuf)
            ' encode parameters
            For Each varX As Object In varArgs
                Select Case TypeName(varX)
                    Case "Byte", "Integer", "Long", "Short"
                        Dim bytInt() As Byte = BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(CInt(varX)))
                        ReDim Preserve bytBuf(bytBuf.Length - 1 + 4)
                        Array.ConstrainedCopy(bytInt, 0, bytBuf, bytBuf.Length - 4, bytInt.Length)
                    Case "Single", "Double"
                        Dim bytFloat() As Byte = BitConverter.GetBytes(CSng(varX))
                        bytFloat = BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(BitConverter.ToInt32(bytFloat, 0)))
                        ReDim Preserve bytBuf(bytBuf.Length - 1 + 4)
                        Array.ConstrainedCopy(bytFloat, 0, bytBuf, bytBuf.Length - 4, bytFloat.Length)
                    Case "String"
                        Dim bytStr As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(CStr(varX))
                        ReDim Preserve bytBuf(bytBuf.Length - 1 + bytStr.Length)
                        Array.ConstrainedCopy(bytStr, 0, bytBuf, bytBuf.Length - bytStr.Length, bytStr.Length)
                        CorrectPacketSize(bytBuf)
                End Select
            Next varX
        End If
        ' return packet
        Return bytBuf
    End Function

    Private Sub CorrectPacketSize(ByRef bytX As Byte())
        Dim lRest As Integer = bytX.Length Mod 4
        ReDim Preserve bytX(3 - lRest + bytX.Length)
        For lX As Integer = 0 To (3 - lRest)
            bytX(bytX.Length - lX - 1) = 0
        Next
    End Sub

   ''' <summary>
    ''' Parse the OSC buffer and retrieve response consisting of COMMAND and ARGUMENTS.
    ''' </summary>
    ''' <param name="bytData">Buffer</param>
    ''' <param name="szCmd">Command</param>
    ''' <param name="varArgs">Array with parameters</param>
    ''' <returns>Error message, empty if no error ocured.</returns>
    ''' <remarks><c>Format: </c>COMMAND \0 ,tags \0 arg1 arg2 arg3 ...
    ''' <br>Tags:</br>
    '''  <li>i: integer, will be a Long</li>
    '''  <li>f: float, will be a single</li>
    '''  <li>s: string</li>
    '''<br></br>
    ''' <example>
    ''' Example for 3 integers: COMMAND \0 ,iii \0 I1 I2 I3
    ''' </example>
    ''' <example>
    ''' Example for 2 integers and string: COMMAND \0 ,iis I1 I2 STRING</example>
    ''' <br>All \0 are 32 filled up to a word (4 bytes)</br></remarks>
    Public Function ParseBuffer(ByVal bytData() As Byte, ByRef szCmd As String, ByRef varArgs() As Object) As String
        Dim szTemp As String
        Dim lArgNr, lY, lPtr, lNr, lX As Integer
        Dim lArgType() As Integer
        Dim sngX As Single
        Dim ltotal As Integer

        ltotal = UBound(bytData)
        If ltotal < 1 Then
            szCmd = ""
            Erase varArgs
            Return ""
        End If
        ' get the header
        lPtr = 0
        While (bytData(lPtr) <> 0) And lPtr < ltotal
            szCmd = szCmd & Chr(bytData(lPtr))
            lPtr = lPtr + 1
        End While
        lPtr = CInt(Int(lPtr / 4) + 1) * 4 ' skip to next long
        If lPtr < ltotal Then
            ' we have more data than command only
            Do
                If Chr(bytData(lPtr)) <> "," Then Exit Do ' no further arguments
                lPtr = lPtr + 1
                If bytData(lPtr) = 0 Then Exit Do ' no further arguments
                lNr = 0
                Do
                    ReDim Preserve lArgType(lNr)
                    lArgType(lNr) = bytData(lPtr)
                    lNr = lNr + 1
                    lPtr = lPtr + 1
                Loop Until bytData(lPtr) = 0
                lPtr = CInt(Int(lPtr / 4) + 1) * 4 ' skip to next long
                For lX = 0 To UBound(lArgType)
                    Select Case Chr(lArgType(lX))
                        Case "s"c
                            szTemp = ""
                            While bytData(lPtr) <> 0
                                szTemp = szTemp & Chr(bytData(lPtr))
                                lPtr = lPtr + 1
                                If lPtr = ltotal Then
                                    ReDim Preserve varArgs(lArgNr)
                                    varArgs(lArgNr) = szTemp
                                    Exit For
                                End If
                            End While
                            'lPtr = (Int((lPtr + 1) / 4) + 1) * 4 ' skip to next long
                            lPtr = CInt(Int(lPtr / 4) + 1) * 4
                            ReDim Preserve varArgs(lArgNr)
                            varArgs(lArgNr) = szTemp
                            lArgNr = lArgNr + 1
                        Case "i"c
                            lY = Bytes2Long(bytData(lPtr), bytData(lPtr + 1), bytData(lPtr + 2), bytData(lPtr + 3))
                            lPtr = lPtr + 4
                            ReDim Preserve varArgs(lArgNr)
                            varArgs(lArgNr) = lY
                            lArgNr = lArgNr + 1
                        Case "f"c
                            sngX = Bytes2Float(bytData(lPtr), bytData(lPtr + 1), bytData(lPtr + 2), bytData(lPtr + 3))
                            lPtr = lPtr + 4
                            ReDim Preserve varArgs(lArgNr)
                            varArgs(lArgNr) = sngX
                            lArgNr = lArgNr + 1
                    End Select
                Next
            Loop Until lPtr >= ltotal
        End If
        Return ""

SubError:
        ParseBuffer = "Invalid stream"
    End Function

    Private Function Bytes2Float(ByVal b0 As Byte, ByVal b1 As Byte, ByVal b2 As Byte, ByVal b3 As Byte) As Single
        Dim bytArr(0 To 3) As Byte

        bytArr(0) = b3
        bytArr(1) = b2
        bytArr(2) = b1
        bytArr(3) = b0

        Bytes2Float = BitConverter.ToSingle(bytArr, 0)

    End Function

    Private Function Bytes2Long(ByVal b0 As Byte, ByVal b1 As Byte, ByVal b2 As Byte, ByVal b3 As Byte) As Integer
        Dim bytArr(0 To 3) As Byte

        bytArr(0) = b3
        bytArr(1) = b2
        bytArr(2) = b1
        bytArr(3) = b0

        Bytes2Long = BitConverter.ToInt32(bytArr, 0)

    End Function

   ''' <summary>
    ''' Separate a command string in a OSC message to root and the rest.
    ''' </summary>
    ''' <param name="szCmd">Command. The root szRoot will be separated and the rest of the command will be returned in szCmd.</param>
    ''' <param name="szRoot">Root of command szCmd.</param>
    ''' <remarks><example>Example:
    '''  <br>szCmd="ROOT/CMD1/CMD2"</br>
    '''  <br>SeparateCommand(szCmd,szRoot)</br>
    '''  <br>szCmd="CMD1/CMD2"</br>
    '''  <br>szRoot="ROOT"</br>
    '''  <br>SeparateCommand(szCmd,szRoot)</br>
    '''  <br>szCmd="CMD2"</br>
    '''  <br>szRoot="CMD1"</br>
    '''  <br>SeparateCommand(szCmd,szRoot)</br>
    '''  <br>szCmd="CMD1"</br>
    '''  <br>szRoot=""</br></example></remarks>
    Public Sub SeparateCommand(ByRef szCmd As String, ByRef szRoot As String)
        Dim lX As Integer

        lX = InStr(1, szCmd, "/")
        If lX > 0 Then
            szRoot = Mid(szCmd, 1, lX - 1) : szCmd = Mid(szCmd, lX + 1)
        Else
            szRoot = Mid(szCmd, 1) : szCmd = ""
        End If

    End Sub
End Module