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
Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Module DDELib

#Region "Constants"
    ' DDEML Return Values
    Public Const DMLERR_NO_ERROR As Integer = 0
    Public Const DMLERR_ADVACKTIMEOUT As Integer = &H4000S
    Public Const DMLERR_BUSY As Integer = &H4001S
    Public Const DMLERR_DATAACKTIMEOUT As Integer = &H4002S
    Public Const DMLERR_DLL_NOT_INITIALIZED As Integer = &H4003S
    Public Const DMLERR_DLL_USAGE As Integer = &H4004S
    Public Const DMLERR_EXECACKTIMEOUT As Integer = &H4005S
    Public Const DMLERR_INVALIDPARAMETER As Integer = &H4006S
    Public Const DMLERR_LOW_MEMORY As Integer = &H4007S
    Public Const DMLERR_MEMORY_ERROR As Integer = &H4008S
    Public Const DMLERR_NOTPROCESSED As Integer = &H4009S
    Public Const DMLERR_NO_CONV_ESTABLISHED As Integer = &H400AS
    Public Const DMLERR_POKEACKTIMEOUT As Integer = &H400BS
    Public Const DMLERR_POSTMSG_FAILED As Integer = &H400CS
    Public Const DMLERR_REENTRANCY As Integer = &H400DS
    Public Const DMLERR_SERVER_DIED As Integer = &H400ES
    Public Const DMLERR_SYS_ERROR As Integer = &H400FS
    Public Const DMLERR_UNADVACKTIMEOUT As Integer = &H4010S
    Public Const DMLERR_UNFOUND_QUEUE_ID As Integer = &H4011S

    ' DDEML Transactions
    Public Const XCLASS_BOOL As Integer = &H1000
    Public Const XCLASS_DATA As Integer = &H2000
    Public Const XCLASS_FLAGS As Integer = &H4000
    Public Const XCLASS_NOTIFICATION As Integer = &H8000
    Public Const XTYPF_NOBLOCK As Integer = &H2
    Public Const XTYP_ADVDATA As Integer = (&H10 Or XCLASS_FLAGS)
    Public Const XTYP_ADVREQ As Integer = (&H20 Or XCLASS_DATA Or XTYPF_NOBLOCK)
    Public Const XTYP_ADVSTART As Integer = (XCLASS_BOOL Or &H30)
    Public Const XTYP_ADVSTOP As Integer = (XCLASS_NOTIFICATION Or &H40)
    Public Const XTYP_CONNECT As Integer = (XCLASS_BOOL Or &H60 Or XTYPF_NOBLOCK)
    Public Const XTYP_CONNECT_CONFIRM As Integer = (XCLASS_NOTIFICATION Or &H70 Or XTYPF_NOBLOCK)
    Public Const XTYP_DISCONNECT As Integer = (XCLASS_NOTIFICATION Or &HC0 Or XTYPF_NOBLOCK)
    Public Const XTYP_ERROR As Integer = (XCLASS_NOTIFICATION Or &H0 Or XTYPF_NOBLOCK)
    Public Const XTYP_EXECUTE As Integer = (XCLASS_FLAGS Or &H50)
    Public Const XTYP_MASK As Integer = &HF0
    Public Const XTYP_MONITOR As Integer = (XCLASS_NOTIFICATION Or &HF0 Or XTYPF_NOBLOCK)
    Public Const XTYP_POKE As Integer = (XCLASS_FLAGS Or &H90)
    Public Const XTYP_REGISTER As Integer = (XCLASS_NOTIFICATION Or &HA0 Or XTYPF_NOBLOCK)
    Public Const XTYP_REQUEST As Integer = (XCLASS_DATA Or &HB0)
    Public Const XTYP_SHIFT As Integer = 4 '  shift to turn XTYP_ into an index
    Public Const XTYP_UNREGISTER As Integer = (XCLASS_NOTIFICATION Or &HD0 Or XTYPF_NOBLOCK)
    Public Const XTYP_WILDCONNECT As Integer = (XCLASS_DATA Or &HE0 Or XTYPF_NOBLOCK)
    Public Const XTYP_XACT_COMPLETE As Integer = (XCLASS_NOTIFICATION Or &H80)
    Public Const CP_WINANSI As Integer = 1004 ' Default codepage for DDE conversations.
    Public Const CP_WINUNICODE As Integer = 1200
    Public Const CF_TEXT As Integer = 1
    Public Const CBF_SKIP_ALLNOTIFICATIONS As Integer = &H3C0000
    Public Const APPCLASS_MONITOR As Integer = &H1S
    Public Const APPCMD_CLIENTONLY As Integer = &H10
    Public Const MF_CALLBACKS As Integer = &H8000000
    Public Const MF_CONV As Integer = &H40000000
    Public Const MF_ERRORS As Integer = &H10000000
    Public Const MF_HSZ_INFO As Integer = &H1000000
    Public Const MF_LINKS As Integer = &H20000000
    Public Const MF_POSTMSGS As Integer = &H4000000
    Public Const MF_SENDMSGS As Integer = &H2000000
    Public Const TIMEOUT_ASYNC As Integer = &HFFFFS
    Public Const QID_SYNC As Integer = &HFFFFS
    Public Const DDE_FACK As Integer = &H8000S
    Public Const DDE_FBUSY As Integer = &H4000S
    Public Const DDE_FNOTPROCESSED As Integer = &H0S
    Public Const EC_ENABLEALL As Integer = 0
#End Region

    Public Class DDEConnection

#Region "DDEML Type Declarations"
        <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
        Public Structure CONVCONTEXT
            Dim cb As Integer
            Dim wFlags As Integer
            Dim wCountryID As Integer
            Dim iCodePage As Integer
            Dim dwLangID As Integer
            Dim dwSecurity As Integer
            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=12)> _
            Dim qos() As Byte
        End Structure

        <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
        Public Structure CONVINFO
            Dim cb As Integer
            Dim hUser As IntPtr
            Dim hConvPartner As IntPtr
            Dim hszSvcPartner As IntPtr
            Dim hszServiceReq As IntPtr
            Dim hszTopic As IntPtr
            Dim hszItem As IntPtr
            Dim wFmt As Integer
            Dim wType As Integer
            Dim wStatus As Integer
            Dim wConvst As Integer
            Dim wLastError As Integer
            Dim hConvList As IntPtr
            Dim ConvCtxt As CONVCONTEXT
            Dim hwnd As IntPtr
            Dim hwndPartner As IntPtr
        End Structure
#End Region

        Private mlInstID As Integer = 0
        Private mhDDEConv As IntPtr = IntPtr.Zero
        Private mGCh As GCHandle = Nothing
        Private Shared mCallBack As DDECallbackDelegate

        Private mszTheService As String = ""
        Private mszTheTopic As String = ""
        Private mszTheItem As String = ""

#Region "API Declarations"
        '*************************************************************************
        ' DDEML Function Declarations
        '*************************************************************************
        Private Declare Function DdeInitialize Lib "user32" Alias "DdeInitializeA" _
            (ByRef pidInst As Integer, ByVal pfnCallback As DDECallbackDelegate, _
            ByVal afCmd As Integer, ByVal ulRes As Integer) As Integer

        Private Declare Function DdeUninitialize Lib "user32" (ByVal idInst As Integer) As Integer

        Private Declare Function DdeConnect Lib "user32" _
            (ByVal idInst As Integer, ByVal hszService As IntPtr, _
            ByVal hszTopic As IntPtr, ByRef pCC As CONVCONTEXT) As IntPtr

        Private Declare Function DdeDisconnect Lib "user32" (ByVal hConv As IntPtr) As Boolean

        Private Declare Function DdeCreateStringHandle Lib "user32" Alias "DdeCreateStringHandleA" _
            (ByVal idInst As Integer, ByVal psz As String, _
            ByVal iCodePage As Integer) As IntPtr

        Private Declare Function DdeFreeStringHandle Lib "user32" (ByVal idInst As Integer, _
            ByVal hsz As IntPtr) As Integer

        'Private Declare Function DdeClientTransaction Lib "user32" _
        '    (<MarshalAs(UnmanagedType.LPArray)> ByVal pData() As Byte, ByVal cbData As Integer, ByVal hConv As IntPtr, _
        '    ByVal hszItem As IntPtr, ByVal wFmt As Integer, ByVal wType As Integer, _
        '    ByVal dwTimeout As Integer, ByRef pdwResult As IntPtr) As IntPtr

        Private Declare Function DdeClientTransaction Lib "user32" _
            (ByVal pData() As Byte, ByVal cbData As Integer, ByVal hConv As IntPtr, _
            ByVal hszItem As IntPtr, ByVal wFmt As Integer, ByVal wType As Integer, _
            ByVal dwTimeout As Integer, ByRef pdwResult As IntPtr) As IntPtr

        Private Declare Function DdeClientTransaction Lib "user32" _
            (ByVal NullPointer As IntPtr, ByVal cbData As Integer, ByVal hConv As IntPtr, _
            ByVal hszItem As IntPtr, ByVal wFmt As Integer, ByVal wType As Integer, _
            ByVal dwTimeout As Integer, ByRef pdwResult As IntPtr) As IntPtr

        Private Declare Function DdeGetData Lib "user32" _
            (ByVal hData As IntPtr, ByVal pDst() As Byte, ByVal cbMax As Integer, ByVal cbOff As Integer) As Integer
        Private Declare Function DdeGetData Lib "user32" _
            (ByVal hData As IntPtr, ByVal NullPtr As IntPtr, ByVal cbMax As Integer, ByVal cbOff As Integer) As Integer

        Private Declare Function DdeQueryString Lib "user32" Alias "DdeQueryStringA" _
            (ByVal idInst As Integer, ByVal hsz As IntPtr, ByVal psz As String, _
            ByVal cchMax As Integer, ByVal iCodePage As Integer) As Integer

        Private Declare Function DdeFreeDataHandle Lib "user32" (ByVal hData As IntPtr) As Integer

        Private Declare Function DdeGetLastError Lib "user32" (ByVal idInst As Integer) As Integer

        Private Delegate Function DDECallbackDelegate(ByVal uType As Integer, ByVal uFmt As Integer, _
                ByVal hConv As IntPtr, ByVal hszString1 As IntPtr, ByVal hszString2 As IntPtr, _
                ByVal hData As IntPtr, ByVal dwData1 As IntPtr, ByVal dwData2 As IntPtr) As Integer
#End Region
#Region "Callback"
        Public Function DDECallback(ByVal uType As Integer, ByVal uFmt As Integer, _
                ByVal hConv As IntPtr, ByVal hszString1 As IntPtr, ByVal hszString2 As IntPtr, _
                ByVal hData As IntPtr, ByVal dwData1 As IntPtr, ByVal dwData2 As IntPtr) As Integer

            Select Case uType

                ' This is the event you'll receive when a server sends you a advisment.
                Case XTYP_ADVDATA
                    'Debug.Print("XTYP_ADVDATA")
                    Return DDE_FACK

                Case XTYP_ADVSTART
                    'Debug.Print("XTYP_ADVSTART")

                Case XTYP_ADVSTOP
                    'Debug.Print("XTYP_ADVSTOP")

                Case XTYP_CONNECT
                    'Debug.Print("XTYP_CONNECT")

                Case XTYP_CONNECT_CONFIRM
                    'Debug.Print("XTYP_CONNECT_CONFIRM")

                Case XTYP_DISCONNECT
                    'Debug.Print("XTYP_DISCONNECT")

                Case XTYP_ERROR
                    'Debug.Print("XTYP_ERROR")

                Case XTYP_EXECUTE
                    'Debug.Print("XTYP_EXECUTE")

                Case XTYP_MASK
                    'Debug.Print("XTYP_MASK")

                Case XTYP_MONITOR
                    'Debug.Print("XTYP_MONITOR")
                    Return 0

                Case XTYP_POKE
                    'Debug.Print("XTYP_POKE")

                Case XTYP_REGISTER
                    'Debug.Print("XTYP_REGISTER")

                Case XTYP_REQUEST
                    'Debug.Print("XTYP_REQUEST")

                Case XTYP_SHIFT
                    'Debug.Print("XTYP_SHIFT")

                Case XTYP_UNREGISTER
                    'Debug.Print("XTYP_UNREGISTER")

                Case XTYP_WILDCONNECT
                    'Debug.Print("XTYP_WILDCONNECT")

                Case XTYP_XACT_COMPLETE
                    'Debug.Print("XTYP_XACT_COMPLETE")

            End Select

            Return 0

        End Function

#End Region
        <SecurityPermission(SecurityAction.Demand, UnmanagedCode:=True)> _
        Public Sub New()
            mlInstID = 0
            mGCh = GCHandle.Alloc(mlInstID, GCHandleType.Pinned)
            mCallBack = AddressOf DDECallback
            'If DdeInitialize(mlInstID, mCallback, _
            '       APPCMD_CLIENTONLY Or MF_SENDMSGS Or MF_POSTMSGS, 0) <> DMLERR_NO_ERROR Then
            If DdeInitialize(mlInstID, mCallBack, _
                                APPCMD_CLIENTONLY Or MF_POSTMSGS, 0) <> DMLERR_NO_ERROR Then
                'Debug.Print("DDE Initialize Failure.")
            Else
                'Debug.Print("DDE Initialize Success.")
            End If
        End Sub

        Public Sub Terminate()
            If mlInstID <> 0 Then
                If DdeUninitialize(mlInstID) <> DMLERR_NO_ERROR Then
                    'Debug.Print("DDE Uninitialize Success.")
                Else
                    'Debug.Print("DDE Uninitialize Failure.")
                End If
                mlInstID = 0
                If Not IsNothing(mGCh) Then
                    mGCh.Free()
                End If
            End If
        End Sub

        Public Function TranslateError() As String

            Dim lRet As Integer
            Dim szErr As String

            lRet = DdeGetLastError(mlInstID)

            Select Case lRet
                Case DMLERR_NO_ERROR
                    szErr = "DMLERR_NO_ERROR"

                Case DMLERR_ADVACKTIMEOUT
                    szErr = "DMLERR_ADVACKTIMEOUT"

                Case DMLERR_BUSY
                    szErr = "DMLERR_BUSY"

                Case DMLERR_DATAACKTIMEOUT
                    szErr = "DMLERR_DATAACKTIMEOUT"

                Case DMLERR_DLL_NOT_INITIALIZED
                    szErr = "DMLERR_NOT_INITIALIZED"

                Case DMLERR_DLL_USAGE
                    szErr = "DMLERR_USAGE"

                Case DMLERR_EXECACKTIMEOUT
                    szErr = "DMLERR_EXECACKTIMEOUT"

                Case DMLERR_INVALIDPARAMETER
                    szErr = "DMLERR_INVALIDPARAMETER"

                Case DMLERR_LOW_MEMORY
                    szErr = "DMLERR_LOW_MEMORY"

                Case DMLERR_MEMORY_ERROR
                    szErr = "DMLERR_MEMORY_ERROR"

                Case DMLERR_NOTPROCESSED
                    szErr = "DMLERR_NOTPROCESSED"

                Case DMLERR_NO_CONV_ESTABLISHED
                    szErr = "DMLERR_NO_CONV_ESTABLISHED"

                Case DMLERR_POKEACKTIMEOUT
                    szErr = "DMLERR_POKEACKTIMEOUT"

                Case DMLERR_POSTMSG_FAILED
                    szErr = "DMLERR_POSTMSG_FAILED"

                Case DMLERR_REENTRANCY
                    szErr = "DMLERR_REENTRANCY"

                Case DMLERR_SERVER_DIED
                    szErr = "DMLERR_SERVER_DIED"

                Case DMLERR_SYS_ERROR
                    szErr = "DMLERR_SYS_ERROR"

                Case DMLERR_UNADVACKTIMEOUT
                    szErr = "DMLERR_UNADVACKTIMEOUT"

                Case DMLERR_UNFOUND_QUEUE_ID
                    szErr = "DMLERR_UNFOUND_QUEUE_ID"

                Case Else
                    szErr = "Unknown DDE Error"
            End Select
            Return szErr

        End Function

        Public Sub CreateStringHandles(ByVal szTheService As String, ByVal szTheTopic As String, _
                                        Optional ByVal szTheItem As String = "")
            mszTheService = szTheService
            mszTheTopic = szTheTopic
            mszTheItem = szTheItem
        End Sub


        Public Function Connect() As IntPtr

            Dim udtConvCont As New CONVCONTEXT

            ' Set up the conversation context structure.
            udtConvCont.iCodePage = CP_WINANSI
            udtConvCont.cb = Marshal.SizeOf(udtConvCont)

            ' Create string handles
            Dim hService As IntPtr = DdeCreateStringHandle(mlInstID, mszTheService, CP_WINANSI)
            Dim hTopic As IntPtr = DdeCreateStringHandle(mlInstID, mszTheTopic, CP_WINANSI)

            ' Open the connection to the service.
            mhDDEConv = DdeConnect(mlInstID, hService, hTopic, udtConvCont)

            ' Do we have a connection?
            If mhDDEConv <> IntPtr.Zero Then
                'Debug.Print("DDE Connection Success.")
            Else
                'Debug.Print("DDE Connection Failure.")
                TranslateError()
            End If

            ' Release our string handles.
            DdeFreeStringHandle(mlInstID, hService)
            DdeFreeStringHandle(mlInstID, hTopic)

            Return mhDDEConv

        End Function

        Public Function Disconnect() As String

            ' Disconnect the DDE conversation.
            If mhDDEConv <> IntPtr.Zero Then
                If Not DdeDisconnect(mhDDEConv) Then
                    mhDDEConv = IntPtr.Zero
                    Return TranslateError()
                End If
                mhDDEConv = IntPtr.Zero
            End If
            Return ""

        End Function

        Public ReadOnly Property Connected() As Boolean
            Get
                Return CBool(mhDDEConv <> IntPtr.Zero)
            End Get
        End Property

        Public Function ClientTransaction(ByVal szData As String, _
                ByVal wFmt As Integer, ByVal wType As Integer, ByVal dwTimeout As Integer) As IntPtr

            ' Create string handles
            Dim hService As IntPtr = DdeCreateStringHandle(mlInstID, mszTheService, CP_WINANSI)
            Dim hTopic As IntPtr = DdeCreateStringHandle(mlInstID, mszTheTopic, CP_WINANSI)
            Dim hItem As IntPtr = IntPtr.Zero
            If mszTheItem.Length > 0 Then
                hItem = DdeCreateStringHandle(mlInstID, mszTheItem, CP_WINANSI)
            End If

            ' invoke client transaction
            If IsNothing(szData) Or (wType = XTYP_REQUEST) Then
                ClientTransaction = DdeClientTransaction(IntPtr.Zero, 0, _
                                                            mhDDEConv, hItem, wFmt, wType, dwTimeout, IntPtr.Zero)
            Else
                Dim pData() As Byte = System.Text.ASCIIEncoding.ASCII.GetBytes(szData)
                ReDim Preserve pData(pData.Length)
                pData(pData.Length - 1) = 0
                ClientTransaction = DdeClientTransaction(pData, pData.Length, _
                                            mhDDEConv, hItem, wFmt, wType, dwTimeout, IntPtr.Zero)
            End If

            ' Release our string handles.
            DdeFreeStringHandle(mlInstID, hService)
            DdeFreeStringHandle(mlInstID, hTopic)
            If hItem <> IntPtr.Zero Then DdeFreeStringHandle(mlInstID, hItem)

        End Function

        Public Function GetData(ByVal hData As IntPtr, ByRef szBuffer As String) As Integer
            Dim size As Integer = DdeGetData(hData, IntPtr.Zero, 0, 0)
            Dim bytArr(size - 1) As Byte
            GetData = DdeGetData(hData, bytArr, size, 0)
            szBuffer = System.Text.ASCIIEncoding.ASCII.GetChars(bytArr)
            DdeFreeDataHandle(hData)
        End Function

    End Class

End Module