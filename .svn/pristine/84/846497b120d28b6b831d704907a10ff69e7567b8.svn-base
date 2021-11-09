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


    Public Class Implant

        Public Enum IMPLANTTYPE
            imptInvalid = 0
            imptC40C = 1
            imptC40P = 2        ' C40P RIB1
            imptC40P_RIB2 = 3   ' C40P RIB2
            imptPulsar = 4
            imptCIC3 = 5
        End Enum

        Public Class CHANNELPARAMETER
            Friend lMCL As Integer
            Friend lTHR As Integer
            Friend lRange As Integer
            Friend lPhDur As Integer
            Friend blnChUsed As Boolean
            Friend lCL As Integer
        End Class

        Public Enum EARTYPE
            LEFT = 0
            RIGHT = 1
        End Enum

        Private Const C40C_TIMEBASE As Double = 2.5
        Private Const C40C_DESCR As String = "C40C"
        Private Const C40C_CHNR As Short = 8
        Private Const C40C_RANGE_MAX As Short = 3
        Private Const C40C_RANGE0 As Double = 3.31
        Private Const C40C_RANGE1 As Double = 5.53
        Private Const C40C_RANGE2 As Double = 9.06
        Private Const C40C_RANGE3 As Double = 15.59
        Private Const C40C_PHDUR As Short = 16
        Private Const C40C_MINDIST As Short = 34
        Private Const C40C_MINDIST_MIN As Short = 33
        Private Const C40C_MINDIST_MAX As Short = 1023
        Private Const C40C_PHDUR_MIN As Short = 16
        Private Const C40C_PHDUR_MAX As Short = 255
        Private Const C40C_PPER_DEF As Short = 396
        Private Const C40C_AMP_MIN As Short = 0
        Private Const C40C_AMP_MAX As Short = 127

        Private Const C40P_TIMEBASE As Double = 2.5 / 3 * 2
        Private Const C40P_DESCR As String = "C40+"
        Private Const C40P_CHNR As Short = 12
        Private Const C40P_RANGE_MAX As Short = 3
        Private Const C40P_RANGE0 As Double = 2.37
        Private Const C40P_RANGE1 As Double = 4.24
        Private Const C40P_RANGE2 As Double = 7.71
        Private Const C40P_RANGE3 As Double = 13.57
        Private Const C40P_PHDUR As Short = 16
        Private Const C40P_MINDIST As Short = 51 ' C40P_MINDIST = C40C_MINDIST * C40P_TIMEBASE / C40C_TIMEBASE
        Private Const C40P_MINDIST_MIN As Short = 33
        Private Const C40P_MINDIST_MAX As Short = 1023
        Private Const C40P_PHDUR_MIN As Short = 16
        Private Const C40P_PHDUR_MAX As Short = 255
        Private Const C40P_PPER_DEF As Short = 396
        Private Const C40P_AMP_MIN As Short = 0
        Private Const C40P_AMP_MAX As Short = 127

        Private Const C40P_RIB2_TIMEBASE As Double = 1 / 0.6
        Private Const C40P_RIB2_DESCR As String = "C40P"
        Private Const C40P_RIB2_CHNR As Short = 12
        Private Const C40P_RIB2_RANGE_MAX As Short = 3
        Private Const C40P_RIB2_RANGE0 As Double = 2.37
        Private Const C40P_RIB2_RANGE1 As Double = 4.24
        Private Const C40P_RIB2_RANGE2 As Double = 7.71
        Private Const C40P_RIB2_RANGE3 As Double = 13.57
        Private Const C40P_RIB2_PHDUR As Short = 16 ' initial values for phdur
        Private Const C40P_RIB2_MINDIST As Short = 51 ' initial values for mindist
        Private Const C40P_RIB2_MINDIST_MIN As Short = 33 ' tu = 55 us
        Private Const C40P_RIB2_MINDIST_MAX As Short = Short.MaxValue ' theoretically mindist_max is 895 s which cannot be realised as Short, but it is anyway unrealistic to set mindist to 895 s
        Private Const C40P_RIB2_PHDUR_MIN As Short = 16
        Private Const C40P_RIB2_PHDUR_MAX As Short = 255
        Private Const C40P_RIB2_PPER_DEF As Short = 396 ' need to be checked, only copied from C40P
        Private Const C40P_RIB2_AMP_MIN As Short = 0
        Private Const C40P_RIB2_AMP_MAX As Short = 127

        Private Const PULSAR_TIMEBASE As Double = 1 / 0.6
        Private Const PULSAR_DESCR As String = "Pulsar"
        Private Const PULSAR_CHNR As Short = 12
        Private Const PULSAR_RANGE_MAX As Short = 3
        Private Const PULSAR_RANGE0 As Double = 1.18
        Private Const PULSAR_RANGE1 As Double = 2.36
        Private Const PULSAR_RANGE2 As Double = 4.72
        Private Const PULSAR_RANGE3 As Double = 9.45
        Private Const PULSAR_PHDUR As Short = 16
        Private Const PULSAR_MINDIST As Short = 51
        ' min/max values for legacy datastream:
        Private Const PULSAR_MINDIST_MIN As Short = 33 ' 2* phdur_min + 3 tu (= 5us)
        Private Const PULSAR_MINDIST_MAX As Short = Short.MaxValue ' theoretically mindist_max is 895 s which cannot be realised as Short, but it is anyway unrealistic to set mindist to 895 s
        Private Const PULSAR_PHDUR_MIN As Short = 15 ' sure that this is 15 and not 16 as everywhere else?
        Private Const PULSAR_PHDUR_MAX As Short = 254 ' together with PULSAR_PHDUR_MIN and compared to the same constants for C40P_RIB2, 
                                                      ' it looks more like an offset "thingy" of 1 rather than an actual technical difference (documentation?)
        Private Const PULSAR_PPER_DEF As Short = 396 'need to be checked, only copied from C40P
        Private Const PULSAR_AMP_MIN As Short = 0
        Private Const PULSAR_AMP_MAX As Short = 127

        Private Const CIC3_TIMEBASE As Double = 0.2      ' is 1/map.implant.rf_freq * 1e6 (µs)
        Private Const CIC3_DESCR As String = "CIC3"      ' from map.implant.IC
        Private Const CIC3_CHNR As Short = 22            ' 
        Private Const CIC3_RANGE_MAX As Short = 0        ' one range only ???
        Private Const CIC3_RANGE0 As Double = 6.82352941 ' from map.implant. (CURRENT_uA_MAX-CURRENT_uA_MIN)/(CURRENT_LEVEL_MAX+1)
        Private Const CIC3_PHDUR As Short = 125          ' from map.implant.default_phase_width/TIMEBASE (tu)
        Private Const CIC3_PHDUR_MIN As Short = 123      ' from map.implant.PHASE_WIDTH_BASE_CYCLES (tu)
        Private Const CIC3_PHDUR_MAX As Short = 378      ' from map.implant.maximum_phase_width/TIMEBASE (tu)
        Private Const CIC3_MINDIST As Short = 833        ' from map.period/TIMEBASE (tu)
        Private Const CIC3_MINDIST_MIN As Short = 347    ' from map.implant.MIN_PERIOD_us/TIMEBASE (tu)
        Private Const CIC3_MINDIST_MAX As Short = 16383  ' from map.implant.MAX_PERIOD_us/TIMEBASE (tu)
        Private Const CIC3_PPER_DEF As Short = 833       ' from map.period/TIMEBASE (µs)
        Private Const CIC3_AMP_MIN As Short = 0          ' ???
        Private Const CIC3_AMP_MAX As Short = 255        ' from map.implant.CURRENT_LEVEL_MAX

        Public MINDIST_MIN As Integer
        Public MINDIST_MAX As Integer
        Public PHDUR_MIN As Integer
        Public PHDUR_MAX As Integer
        Public PPER_DEF As Integer
        Public AMP_MIN As Integer
        Public AMP_MAX As Integer
        Public RANGE(3) As Double
        Friend DeviceTypeRequired As STIM.GENMODE
        Public Prefix As String = ""

        Private mblnTableMode As Boolean

        Private chpChannel() As CHANNELPARAMETER
        Private msRangeMul() As Single
        Private mImpType As IMPLANTTYPE
        Private mszImpType As String
        Private mszLastName As String
        Private mszFirstName As String
        Private mEar As Implant.EARTYPE
        Private mlMinDist As Integer
        Private mlMinDistTemp As Double = 0
        Private mlChannelsCount As Integer
        Private mlPulsePeriod As Integer
        Private mlPulsePeriodTemp As Double = 0
        Private msTimeBase As Double                ' KE (04.04.2013): changed from Single to Double data type to save timebase value properly
        Private mszMapLaw As String
        Private mszChannelOrder As String
        Private mlDuration As Integer
        Private mszDataStream As String
        Private msGapDur As Double
    

        Public Property Channel(ByVal Index As Integer) As CHANNELPARAMETER
            Get
                If Index >= mlChannelsCount Then Return Nothing
                Return chpChannel(Index)
            End Get
            Set(ByVal value As CHANNELPARAMETER)

            End Set
        End Property
        Public ReadOnly Property RangeMultiplier(ByVal Index As Integer) As Single
            Get
                If Index >= mlChannelsCount Then Return Single.NaN
                Return msRangeMul(Index)
            End Get
        End Property
        Public ReadOnly Property RangeCount() As Integer
            Get
                Return msRangeMul.Length
            End Get
        End Property
        Public ReadOnly Property TimeBase() As Double
            Get
                Return msTimeBase
            End Get
        End Property
        Public Property PulsePeriod() As Integer
            Get
                Return mlPulsePeriod
            End Get
            Set(ByVal value As Integer)
                mlPulsePeriod = value
            End Set
        End Property
        Public Property Duration() As Integer
            Get
                Return mlDuration
            End Get
            Set(ByVal value As Integer)
                mlDuration = value
            End Set
        End Property
        Public ReadOnly Property ChannelsCount() As Integer
            Get
                Return mlChannelsCount
            End Get
        End Property
        Public Property MinDist() As Integer
            Get
                Return mlMinDist
            End Get
            Set(ByVal value As Integer)
                mlMinDist = value
            End Set
        End Property
        Public Property Ear() As Implant.EARTYPE
            Get
                Return mEar
            End Get
            Set(ByVal value As Implant.EARTYPE)
                mEar = value
            End Set
        End Property
        Public Property FirstName() As String
            Get
                Return mszFirstName
            End Get
            Set(ByVal value As String)
                mszFirstName = value
            End Set
        End Property
        Public Property LastName() As String
            Get
                Return mszLastName
            End Get
            Set(ByVal value As String)
                mszLastName = value
            End Set
        End Property
        Public Property MapLaw() As String
            Get
                Return mszMapLaw
            End Get
            Set(ByVal value As String)
                mszMapLaw = value
            End Set
        End Property
        Public Property DataStreamType() As String
            Get
                Return mszDataStream
            End Get
            Set(ByVal value As String)
                mszDataStream = value
            End Set
        End Property
        Public Property GapDuration() As Double
            Get
                Return msGapDur
            End Get
            Set(ByVal value As Double)
                msGapDur = value
            End Set
        End Property
        Public Property ChannelOrder() As String
            Get
                Return mszChannelOrder
            End Get
            Set(ByVal value As String)
                mszChannelOrder = value
            End Set
        End Property
        Public ReadOnly Property ImpTypeString() As String
            Get
                Return mszImpType
            End Get
        End Property
        Public Property ImpType() As IMPLANTTYPE
            Get
                Return mImpType
            End Get
            Set(ByVal value As IMPLANTTYPE)
                Select Case value
                    Case IMPLANTTYPE.imptInvalid
                        mImpType = IMPLANTTYPE.imptInvalid
                        mszImpType = ""
                        mszLastName = ""
                        mszFirstName = ""
                        'mEar = EARTYPE.LEFT
                        'commented by miho
                        mlMinDist = 0
                        mlChannelsCount = 0
                        mlPulsePeriod = 0
                        msTimeBase = 0
                        ReDim msRangeMul(0)
                        msRangeMul(0) = 0
                        ReDim chpChannel(0)
                        chpChannel(0) = New CHANNELPARAMETER
                        chpChannel(0).lMCL = 0
                        chpChannel(0).lTHR = 0
                        chpChannel(0).lRange = 0
                        chpChannel(0).lPhDur = 0
                        chpChannel(0).blnChUsed = False
                        mszMapLaw = ""
                        mszChannelOrder = ""
                        RANGE(0) = 0
                        RANGE(1) = 0
                        RANGE(2) = 0
                        RANGE(3) = 0
                        ' Case IMPLANTTYPE.imptC40Plus
                        ' RANGE(0) = C40CPlus_RANGE0
                        ' RANGE(1) = C40CPlus_RANGE1
                        ' RANGE(2) = C40CPlus_RANGE2
                        ' RANGE(3) = C40CPlus_RANGE3


                    Case IMPLANTTYPE.imptC40C
                        mImpType = IMPLANTTYPE.imptC40C
                        ReDim chpChannel(C40C_CHNR - 1)
                        mlChannelsCount = C40C_CHNR
                        mszImpType = C40C_DESCR
                        msTimeBase = C40C_TIMEBASE
                        mlMinDist = C40C_MINDIST
                        'mEar = EARTYPE.LEFT
                        'commented by miho
                        mlPulsePeriod = C40C_PPER_DEF
                        mszChannelOrder = ""
                        mszMapLaw = "%log; 500"
                        ReDim msRangeMul(C40C_RANGE_MAX)
                        msRangeMul(0) = C40C_RANGE0
                        msRangeMul(1) = C40C_RANGE1
                        msRangeMul(2) = C40C_RANGE2
                        msRangeMul(3) = C40C_RANGE3
                        mszChannelOrder = ""
                        For lX As Integer = 0 To mlChannelsCount - 1
                            chpChannel(lX) = New CHANNELPARAMETER
                            chpChannel(lX).lMCL = C40C_AMP_MAX
                            chpChannel(lX).lTHR = C40C_AMP_MIN
                            chpChannel(lX).lRange = C40C_RANGE_MAX
                            chpChannel(lX).lPhDur = C40C_PHDUR
                            chpChannel(lX).blnChUsed = True
                            mszChannelOrder = mszChannelOrder & TStr(lX + 1) & " "
                        Next
                        mszChannelOrder = Trim(mszChannelOrder)
                        MINDIST_MIN = C40C_MINDIST_MIN
                        MINDIST_MAX = C40C_MINDIST_MAX
                        PHDUR_MIN = C40C_PHDUR_MIN
                        PHDUR_MAX = C40C_PHDUR_MAX
                        PPER_DEF = C40C_PPER_DEF
                        AMP_MIN = C40C_AMP_MIN
                        AMP_MAX = C40C_AMP_MAX
                        DeviceTypeRequired = GENMODE.genElectricalRIB
                        RANGE(0) = C40C_RANGE0
                        RANGE(1) = C40C_RANGE1
                        RANGE(2) = C40C_RANGE2
                        RANGE(3) = C40C_RANGE3

                    Case IMPLANTTYPE.imptC40P
                        mImpType = IMPLANTTYPE.imptC40P
                        ReDim chpChannel(C40P_CHNR)
                        mlChannelsCount = C40P_CHNR
                        mszImpType = C40P_DESCR
                        msTimeBase = C40P_TIMEBASE
                        mlMinDist = C40P_MINDIST
                        'mEar = EARTYPE.LEFT
                        'commented by miho
                        mlPulsePeriod = C40P_PPER_DEF
                        mszMapLaw = "%log; 500"
                        ReDim msRangeMul(C40P_RANGE_MAX)
                        msRangeMul(0) = C40P_RANGE0
                        msRangeMul(1) = C40P_RANGE1
                        msRangeMul(2) = C40P_RANGE2
                        msRangeMul(3) = C40P_RANGE3
                        RANGE(0) = C40P_RANGE0
                        RANGE(1) = C40P_RANGE1
                        RANGE(2) = C40P_RANGE2
                        RANGE(3) = C40P_RANGE3
                        mszChannelOrder = ""
                        For lX As Integer = 0 To mlChannelsCount - 1
                            chpChannel(lX) = New CHANNELPARAMETER
                            chpChannel(lX).lMCL = C40P_AMP_MAX
                            chpChannel(lX).lTHR = C40P_AMP_MIN
                            chpChannel(lX).lRange = C40P_RANGE_MAX
                            chpChannel(lX).lPhDur = C40P_PHDUR
                            chpChannel(lX).blnChUsed = True
                            mszChannelOrder = mszChannelOrder & TStr(lX + 1) & " "
                        Next
                        mszChannelOrder = Trim(mszChannelOrder)
                        MINDIST_MIN = C40P_MINDIST_MIN
                        MINDIST_MAX = C40P_MINDIST_MAX
                        PHDUR_MIN = C40P_PHDUR_MIN
                        PHDUR_MAX = C40P_PHDUR_MAX
                        PPER_DEF = C40P_PPER_DEF
                        AMP_MIN = C40P_AMP_MIN
                        AMP_MAX = C40P_AMP_MAX
                        DeviceTypeRequired = GENMODE.genElectricalRIB
                    Case IMPLANTTYPE.imptC40P_RIB2
                        If mImpType = IMPLANTTYPE.imptC40P Then
                            ' Convert C40P (RIB1) to a C40P_RIB2
                            mImpType = IMPLANTTYPE.imptC40P_RIB2
                            MINDIST_MAX = C40P_RIB2_MINDIST_MAX
                            mszImpType = C40P_RIB2_DESCR
                            mszDataStream = "Legacy"
                            msGapDur = 0
                            RANGE(0) = C40P_RIB2_RANGE0
                            RANGE(1) = C40P_RIB2_RANGE1
                            RANGE(2) = C40P_RIB2_RANGE2
                            RANGE(3) = C40P_RIB2_RANGE3
                            DeviceTypeRequired = GENMODE.genElectricalRIB2
                        Else
                            mImpType = IMPLANTTYPE.imptC40P_RIB2
                            ReDim chpChannel(C40P_RIB2_CHNR)
                            mlChannelsCount = C40P_RIB2_CHNR
                            mszImpType = C40P_RIB2_DESCR
                            msTimeBase = C40P_RIB2_TIMEBASE
                            mlMinDist = C40P_RIB2_MINDIST
                            'mEar = EARTYPE.LEFT
                            'commented by miho
                            mlPulsePeriod = C40P_RIB2_PPER_DEF
                            mszMapLaw = "Zero"
                            ReDim msRangeMul(C40P_RIB2_RANGE_MAX)
                            msRangeMul(0) = C40P_RIB2_RANGE0
                            msRangeMul(1) = C40P_RIB2_RANGE1
                            msRangeMul(2) = C40P_RIB2_RANGE2
                            msRangeMul(3) = C40P_RIB2_RANGE3
                            RANGE(0) = C40P_RIB2_RANGE0
                            RANGE(1) = C40P_RIB2_RANGE1
                            RANGE(2) = C40P_RIB2_RANGE2
                            RANGE(3) = C40P_RIB2_RANGE3
                            mszChannelOrder = ""
                            For lX As Integer = 0 To mlChannelsCount - 1
                                chpChannel(lX) = New CHANNELPARAMETER
                                chpChannel(lX).lMCL = C40P_RIB2_AMP_MAX
                                chpChannel(lX).lTHR = C40P_RIB2_AMP_MIN
                                chpChannel(lX).lRange = C40P_RIB2_RANGE_MAX
                                chpChannel(lX).lPhDur = C40P_RIB2_PHDUR
                                chpChannel(lX).blnChUsed = True
                                mszChannelOrder = mszChannelOrder & TStr(lX + 1) & " "
                            Next
                            mszChannelOrder = Trim(mszChannelOrder)
                            MINDIST_MIN = C40P_RIB2_MINDIST_MIN
                            MINDIST_MAX = C40P_RIB2_MINDIST_MAX
                            PHDUR_MIN = C40P_RIB2_PHDUR_MIN
                            PHDUR_MAX = C40P_RIB2_PHDUR_MAX
                            PPER_DEF = C40P_RIB2_PPER_DEF
                            AMP_MIN = C40P_RIB2_AMP_MIN
                            AMP_MAX = C40P_RIB2_AMP_MAX
                            mszDataStream = "Legacy"
                            msGapDur = 0
                            DeviceTypeRequired = GENMODE.genElectricalRIB2
                        End If
                    Case IMPLANTTYPE.imptPulsar
                        mImpType = IMPLANTTYPE.imptPulsar
                        ReDim chpChannel(PULSAR_CHNR)
                        mlChannelsCount = PULSAR_CHNR
                        mszImpType = PULSAR_DESCR
                        msTimeBase = PULSAR_TIMEBASE
                        mlMinDist = PULSAR_MINDIST
                        'mEar = EARTYPE.LEFT
                        'commented by miho
                        mlPulsePeriod = PULSAR_PPER_DEF
                        mszMapLaw = "Zero"
                        ReDim msRangeMul(PULSAR_RANGE_MAX)
                        msRangeMul(0) = PULSAR_RANGE0
                        msRangeMul(1) = PULSAR_RANGE1
                        msRangeMul(2) = PULSAR_RANGE2
                        msRangeMul(3) = PULSAR_RANGE3
                        RANGE(0) = PULSAR_RANGE0
                        RANGE(1) = PULSAR_RANGE1
                        RANGE(2) = PULSAR_RANGE2
                        RANGE(3) = PULSAR_RANGE3
                        mszChannelOrder = ""
                        For lX As Integer = 0 To mlChannelsCount - 1
                            chpChannel(lX) = New CHANNELPARAMETER
                            chpChannel(lX).lMCL = PULSAR_AMP_MAX
                            chpChannel(lX).lTHR = PULSAR_AMP_MIN
                            chpChannel(lX).lRange = PULSAR_RANGE_MAX
                            chpChannel(lX).lPhDur = PULSAR_PHDUR
                            chpChannel(lX).blnChUsed = True
                            mszChannelOrder = mszChannelOrder & TStr(lX + 1) & " "
                        Next
                        mszChannelOrder = Trim(mszChannelOrder)
                        MINDIST_MIN = PULSAR_MINDIST_MIN
                        MINDIST_MAX = PULSAR_MINDIST_MAX
                        PHDUR_MIN = PULSAR_PHDUR_MIN
                        PHDUR_MAX = PULSAR_PHDUR_MAX
                        PPER_DEF = PULSAR_PPER_DEF
                        AMP_MIN = PULSAR_AMP_MIN
                        AMP_MAX = PULSAR_AMP_MAX
                        mszDataStream = "Legacy"
                        msGapDur = 2.1
                        DeviceTypeRequired = GENMODE.genElectricalRIB2
                    Case IMPLANTTYPE.imptCIC3
                        mImpType = IMPLANTTYPE.imptCIC3
                        ReDim chpChannel(CIC3_CHNR)
                        mlChannelsCount = CIC3_CHNR
                        mszImpType = CIC3_DESCR
                        msTimeBase = CIC3_TIMEBASE
                        mlMinDist = CIC3_MINDIST
                        mEar = EARTYPE.LEFT
                        mlPulsePeriod = CIC3_PPER_DEF
                        mszMapLaw = "%log; 750"
                        ReDim msRangeMul(CIC3_RANGE_MAX)
                        msRangeMul(0) = CIC3_RANGE0
                        mszChannelOrder = ""
                        For lX As Integer = 0 To mlChannelsCount - 1
                            chpChannel(lX) = New CHANNELPARAMETER
                            chpChannel(lX).lMCL = CIC3_AMP_MAX
                            chpChannel(lX).lTHR = CIC3_AMP_MIN
                            chpChannel(lX).lRange = CIC3_RANGE_MAX
                            chpChannel(lX).lPhDur = CIC3_PHDUR
                            chpChannel(lX).blnChUsed = True
                            mszChannelOrder = mszChannelOrder & TStr(lX + 1) & " "
                        Next
                        mszChannelOrder = Trim(mszChannelOrder)
                        MINDIST_MIN = CIC3_MINDIST_MIN
                        MINDIST_MAX = CIC3_MINDIST_MAX
                        PHDUR_MIN = CIC3_PHDUR_MIN
                        PHDUR_MAX = CIC3_PHDUR_MAX
                        PPER_DEF = CIC3_PPER_DEF
                        AMP_MIN = CIC3_AMP_MIN
                        AMP_MAX = CIC3_AMP_MAX
                        RANGE(0) = CIC3_RANGE0
                        ' RANGE(1) = CIC3_RANGE1
                     '   RANGE(2) = CIC3_RANGE2
                        '   RANGE(3) = CIC3_RANGE3

                        DeviceTypeRequired = GENMODE.genElectricalNIC
                End Select
            End Set
        End Property

        Sub New(Optional ByVal mImpType As Implant.IMPLANTTYPE = IMPLANTTYPE.imptInvalid)
            ImpType = mImpType
            If Len(Prefix) = 0 Then Prefix = gszExpID
        End Sub

        Sub ClearParameters(Optional ByVal iImpType As Implant.IMPLANTTYPE = IMPLANTTYPE.imptInvalid)
            ImpType = iImpType
        End Sub

        Function CalcCurrent(ByVal lAmp As Integer, ByVal lRange As Integer) As Double
            Select Case Me.ImpType
                Case IMPLANTTYPE.imptInvalid
                    Return Double.NaN
                Case IMPLANTTYPE.imptC40C
                    Return (lAmp + 1) * msRangeMul(lRange)
                Case IMPLANTTYPE.imptC40P, IMPLANTTYPE.imptC40P_RIB2
                    Return (lAmp + 1) * msRangeMul(lRange)
                Case IMPLANTTYPE.imptPulsar
                    Return (lAmp) * msRangeMul(lRange)
                Case IMPLANTTYPE.imptCIC3
                    Return (lAmp) * msRangeMul(lRange) + 10     ' amp * mul + 10 µA ???
            End Select
            Return Nothing
        End Function

        Function CalcCurrentAsString(ByVal lAmp As Integer, ByVal lRange As Integer) As String
            Dim dX As Double = CalcCurrent(lAmp, lRange)
            If Double.IsNaN(dX) Then Return "---"
            If dX >= 1000 Then Return TStr(Math.Round(dX, 0))
            If dX >= 100 Then Return TStr(Math.Round(dX, 1))
            Return TStr(Math.Round(dX, 2))
        End Function

        Function CalcAmplitude(ByVal sCurrent As Double, ByVal lRange As Integer) As Integer
            Select Case Me.ImpType
                Case IMPLANTTYPE.imptInvalid
                    Return 0
                Case IMPLANTTYPE.imptC40C, IMPLANTTYPE.imptC40P, IMPLANTTYPE.imptC40P_RIB2
                    Return CInt(Math.Round(sCurrent / msRangeMul(lRange) - 1))
                Case IMPLANTTYPE.imptPulsar
                    Return CInt(Math.Round(sCurrent / msRangeMul(lRange)))
                Case IMPLANTTYPE.imptCIC3
                    Return CInt(Math.Round((sCurrent - 10) / msRangeMul(lRange)))
            End Select
            Return Nothing
        End Function

        Function SaveFileFitt(ByVal szFile As String) As String
            Dim szX As String
            Dim iX As Integer

            ' open file
            On Error GoTo Error_FileNotOpen
            If Dir(szFile) <> "" Then Kill(szFile)
            FileOpen(1, szFile, OpenMode.Binary)

            ' save lines - report part
            On Error GoTo Error_WritingFile
            WriteLine((""))
            WriteLine((""))
            WriteLine((""))
            WriteLine((""))
            Select Case mImpType
                Case IMPLANTTYPE.imptC40C, IMPLANTTYPE.imptC40P
                    WriteLine("Mapping data of CIS PRO+")
                Case IMPLANTTYPE.imptCIC3
                    WriteLine("Mapping data of Nucleus")
            End Select
            WriteLine(("Program No:       0"))
            WriteLine(("Report date:      " & VB6.Format(Today, "mmm/dd/yyyy") & ", " & VB6.Format(TimeOfDay, "Hh:Nn")))
            WriteLine((""))
            WriteLine(("Patient:          " & Mid(mszLastName & Space(21), 1, 21) & Mid(mszFirstName & Space(10), 1, 10)))
            WriteLine(("Birth date:       Jan/01/1970"))
            WriteLine((""))
            Select Case mImpType
                Case IMPLANTTYPE.imptC40C
                    WriteLine(("Impl/proc type:   " & Mid(mszImpType & Space(8), 1, 8) & "CP40+"))
                Case IMPLANTTYPE.imptC40P
                    WriteLine(("Impl/proc type:   " & Mid(mszImpType & Space(8), 1, 8) & "CP40+"))
                Case IMPLANTTYPE.imptCIC3
                    WriteLine(("Impl/proc type:   " & Mid(mszImpType & Space(8), 1, 8) & "CIC3"))
            End Select
            Select Case mEar
                Case EARTYPE.LEFT
                    szX = "LEFT"
                Case EARTYPE.RIGHT
                    szX = "RIGHT"
                Case Else
                    szX = ""
            End Select
            WriteLine(("Implanted ear:    " & szX))
            WriteLine((""))
            WriteLine(("Examination date: Oct/28/1999"))
            WriteLine((""))
            WriteLine((" THR burst dur: 50 ms"))
            WriteLine((" MCL burst dur: 50 ms"))
            'WriteLine(("  Gap duration: 300 ms"))
            WriteLine("  Gap duration: " & TStr(mlDuration) & " ms")
            WriteLine((" Sweep gap dur: 500 ms"))
            WriteLine(("Min pulse dist: " & Replace(VB6.Format(mlMinDist * msTimeBase, "##0.0"), ",", ".") & " us"))
            WriteLine((" PRate/channel: " & Replace(VB6.Format(1000000 / (mlPulsePeriod * msTimeBase), "####.0"), ",", ".") & " pps"))
            WriteLine((""))
            WriteLine(("      Strategy: CIS"))
            WriteLine(("       Map Law: " & mszMapLaw))
            WriteLine(("   Volume mode: RTI; 0.0% - 100.0%"))
            szX = ""
            For iX = 1 To mlChannelsCount
                szX = szX & VB6.Format(iX, " #")
            Next
            If Len(mszChannelOrder) = 0 Then
                WriteLine((" Channel order:" & szX))
            Else
                WriteLine((" Channel order: " & mszChannelOrder))
            End If
            WriteLine((""))
            WriteLine(("   Band assign:" & szX))
            WriteLine((" ADC reference: 0.574"))
            WriteLine((" BP filter set: logarithmic"))
            WriteLine(("LPF cutoff frq: 400 Hz"))
            WriteLine(("     LPF order: 2"))
            WriteLine(("  Coil voltage: 7"))
            WriteLine((""))
            WriteLine(("Status indicators: 1 1 1 1 1 1 "))
            WriteLine(("   Battery low: red LED blinking + beep"))
            WriteLine(("Signal present: green LED flickering with input signal"))
            WriteLine((""))
            WriteLine((""))
            ' save line - table part
            szX = "  Chan "
            For iX = 0 To mlChannelsCount - 1
                szX = szX & Right(VB6.Format(iX + 1, "      0 "), 6)
            Next
            WriteLine((szX))
            szX = "------"
            For iX = 0 To mlChannelsCount - 1
                szX = szX & "------"
            Next
            WriteLine((szX))
            szX = "MCL/cu "
            For iX = 0 To mlChannelsCount - 1
                szX = szX & Right(VB6.Format((chpChannel(iX).lMCL + 1) * msRangeMul(chpChannel(iX).lRange), "     0 "), 6)
            Next
            WriteLine((szX))
            szX = "THR/cu "
            For iX = 0 To mlChannelsCount - 1
                szX = szX & Right(VB6.Format((chpChannel(iX).lTHR + 1) * msRangeMul(chpChannel(iX).lRange), "     0 "), 6)
            Next
            WriteLine((szX))
            szX = "Dyn/dB "
            For iX = 0 To mlChannelsCount - 1
                szX = szX & Replace(Right(VB6.Format(12.3, "     0.0 "), 6), ",", ".")
            Next
            WriteLine((szX))
            szX = "PD /us "
            For iX = 0 To mlChannelsCount - 1
                szX = szX & Replace(Right(VB6.Format(chpChannel(iX).lPhDur * msTimeBase, "     0.0 "), 6), ",", ".")
            Next
            WriteLine((szX))
            szX = "Status "
            For iX = 0 To mlChannelsCount - 1
                szX = szX & "   on "
            Next
            WriteLine((szX))
            WriteLine("")
            szX = "MCL[bit] "
            For iX = 0 To mlChannelsCount - 1
                szX = szX & Right(VB6.Format(chpChannel(iX).lMCL, "    0 "), 6)
            Next
            WriteLine((szX))
            szX = "THR[bit] "
            For iX = 0 To mlChannelsCount - 1
                szX = szX & Right(VB6.Format(chpChannel(iX).lTHR, "    0 "), 6)
            Next
            WriteLine((szX))
            szX = "CurRange "
            For iX = 0 To mlChannelsCount - 1
                szX = szX & Right(VB6.Format(chpChannel(iX).lRange, "    0 "), 6)
            Next
            WriteLine((szX))
            szX = " PulsDur "
            For iX = 0 To mlChannelsCount - 1
                szX = szX & Right(VB6.Format(chpChannel(iX).lPhDur, "    0 "), 6)
            Next
            WriteLine((szX))
            szX = "  Status "
            For iX = 0 To mlChannelsCount - 1
                szX = szX & "   on "
            Next
            WriteLine((szX))
            szX = "       a "
            For iX = 0 To mlChannelsCount - 1
                szX = szX & "40448 "
            Next
            WriteLine((szX))
            szX = "       k "
            For iX = 0 To mlChannelsCount - 1
                szX = szX & " 4096 "
            Next
            WriteLine((szX))
            WriteLine((""))
            ' save line - comments
            WriteLine("Comments:" & Prefix)
            Select Case mImpType
                Case IMPLANTTYPE.imptC40C, IMPLANTTYPE.imptC40P
                    WriteLine((""))
                    WriteLine((Chr(&HAES)))
                    WriteLine((""))
                    WriteLastLine(("MED-EL C40/C40+ Fitting Software  Version 4.01"))
            End Select
            ' close and exit
            FileClose(1)
            Return ""

            '-----------------
    Error_FileNotOpen:
            Return Err.Description

    Error_WritingFile:
            FileClose(1)
            Return Err.Description

        End Function

        Function SaveFileAmpmap(ByVal szFile As String) As String
            Dim szX As String
            Dim mszRangesAll As String
            Dim iX As Integer
            Dim lPhDurTemp, lPulsePeriodTemp As Double
            Dim iElecNum As Integer
            Dim lPostgain As Double
            Dim nfi As System.Globalization.NumberFormatInfo = New System.Globalization.CultureInfo("en-US", False).NumberFormat    'number format to use '.' as decimal separator (instead of the German ',')

            ' open file
            On Error GoTo Error_FileNotOpen
            If Dir(szFile) <> "" Then Kill(szFile)
            FileOpen(1, szFile, OpenMode.Binary)

            ' save lines - report part
            On Error GoTo Error_WritingFile
            WriteLine(("# Fitting File  : " & szFile))
            'WriteLine(("# Patient       : " & mszFirstName & " " & mszLastName))
            WriteLine(("# First Name    : " & mszFirstName))
            WriteLine(("# Last Name     : " & mszLastName))
            Select Case mEar
                Case EARTYPE.LEFT
                    szX = "LEFT"
                Case EARTYPE.RIGHT
                    szX = "RIGHT"
                Case Else
                    szX = ""
            End Select
            WriteLine(("# Implanted ear : " & szX))
            WriteLine(("# Duration F4F  : " & mlDuration.ToString("#00.00", nfi) & " ms"))
            lPulsePeriodTemp = Math.Round(mlPulsePeriod * msTimeBase, 2)
            WriteLine(("# Pulse period  : " & lPulsePeriodTemp.ToString("#00.00", nfi) & " us"))
            lPhDurTemp = Math.Round(mlMinDist * msTimeBase, 2)
            WriteLine(("# Minimum pulse distance : " & lPhDurTemp.ToString("#00.00", nfi) & " us"))
            WriteLine(("# Fitting creation time & date: " & VB6.Format(Today, "mmm/dd/yyyy") & ", " & VB6.Format(TimeOfDay, "Hh:Nn")))


            ' start MAP sequence
            WriteLine("")
            WriteLine("MAP")
            WriteLine(("Implanttype " & mszImpType))

            ' compose default command
            mszRangesAll = "#Ranges "       ' # to use ranges only for F4F and disable ranges within the default command when loaded in the stm file
            For iX = 0 To mlChannelsCount - 1
                mszRangesAll = mszRangesAll & chpChannel(iX).lRange.ToString("0") & " "
            Next
            mszRangesAll = Trim(mszRangesAll)

            Select Case mszDataStream
                Case "Legacy"
                    Dim mszPhasesAll As String

                    ' align together phase durations of all electrodes
                    lPhDurTemp = Math.Round(PHDUR_MIN * msTimeBase, 2)      ' minimum phase duration for disabled channels
                    mszPhasesAll = " Phases " & lPhDurTemp.ToString("#00.00", nfi) & " "
                    For iX = 0 To mlChannelsCount - 1           ' phase duration for each electrode
                        lPhDurTemp = Math.Round(chpChannel(iX).lPhDur * msTimeBase, 2) ' calculate phase duration from tu in us
                        mszPhasesAll = mszPhasesAll & lPhDurTemp.ToString("#00.00", nfi) & " "
                    Next

                    ' write default legacy command
                    WriteLine(("Default " & mszDataStream & mszPhasesAll & mszRangesAll))
                Case "Pulsar"
                    ' TEMPORARY SOLUTION
                    ' takes phase duration of electrode 1 as default phase duration with no extensions for the other electrodes!
                    lPhDurTemp = Math.Round(chpChannel(0).lPhDur * msTimeBase, 2)
                    ' write default pulsar command
                    WriteLine(("Default " & mszDataStream & " Phase " & lPhDurTemp.ToString("#00.00", nfi) & " Gap " & msGapDur.ToString("#0.#", nfi) & " Parallel " & mszRangesAll))
            End Select
            '

            szX = "Translate "
            For iX = 0 To mlChannelsCount - 1
                'If chpChannel(iX).blnChUsed And frmFitt4Fun.lblDynamic(CShort(iX)).Text <> "disabled" Then
                If chpChannel(iX).blnChUsed And chpChannel(iX).lTHR <> chpChannel(iX).lMCL Then
                    szX = szX & TStr(iX + 1) & " "
                Else
                    szX = szX & "X "        ' indicate unused channels with an 'X'
                End If
            Next
            WriteLine(szX.Trim)
            WriteLine("Pregain 1.0")
            lPostgain = Math.Round(1 / 127, 6)     ' set postgain to 1/127 to use amplitudes, THR and MCL between 0 and 127
            WriteLine(("Postgain " & lPostgain.ToString("0.000000", nfi)))

            For iX = 0 To mlChannelsCount - 1
                If chpChannel(iX).blnChUsed And chpChannel(iX).lTHR <> chpChannel(iX).lMCL Then    ' only set electrode mapping when electrode is enabled
                    Dim szCL As String = ""
                    'Debug.Print("# " & frmFitt4Fun.lblMCL(CShort(iX)).Text)
                    'If myFitt.Channel(Index).lCL <> 0 Then szCL = " # CL " & frmFitt4Fun.lblMem(CShort(iX)).Text
                    If chpChannel(iX).lCL <> 0 Then szCL = " # CL " & TStr(chpChannel(iX).lCL)
                    iElecNum = iX + 1
                    WriteLine("Electrode " & iElecNum.ToString("#0") & " " & chpChannel(iX).lTHR.ToString("##0", nfi) & " " & chpChannel(iX).lTHR.ToString("##0", nfi) & " " & chpChannel(iX).lMCL.ToString("##0", nfi) & " " & chpChannel(iX).lMCL.ToString("##0", nfi) & " " & mszMapLaw & szCL)
                End If
            Next

            WriteLine("ENDMAP")
            ' close and exit
            FileClose(1)
            Return ""

            '-----------------
    Error_FileNotOpen:
            Return Err.Description

    Error_WritingFile:
            FileClose(1)
            Return Err.Description

        End Function


        Private Sub WriteLine(ByVal szLine As String)
            Dim lX As Integer

            For lX = 1 To Len(szLine)
                FilePut(1, CByte(Asc(Mid(szLine, lX, 1))))
            Next
            FilePut(1, CByte(13))
            FilePut(1, CByte(10))
        End Sub

        Private Sub WriteLastLine(ByVal szLine As String)
            Dim lX As Integer

            For lX = 1 To Len(szLine)
                FilePut(1, CByte(Asc(Mid(szLine, lX, 1))))
            Next
            FilePut(1, CByte(12))
        End Sub


        Function OpenFile(ByVal szFile As String) As String
            Dim szTemp As String
            Dim bX As Byte
            Dim iLine As Integer

            ' set implant type to invalid           ' KE (03.04.2013): in frmFitt4Fun.OpenFittFile()implant type has already been set (here OpenFile() is called twice)
            ' mImpType = IMPLANTTYPE.imptInvalid                     ' other occasions of OpenFile() adapted to set implanttype invalid before calling the function

            ' open file
            If FileIO.FileSystem.FileExists(szFile) = False Then Return "File " & szFile & " not found"
            If Dir(szFile) = "" Then Return "File " & szFile & " not found"
            mblnTableMode = False

            On Error GoTo Error_FileNotOpen
            Dim file As System.IO.StreamReader = _
                    My.Computer.FileSystem.OpenTextFileReader(szFile, System.Text.Encoding.GetEncoding(1252))

            ' check format of fitting file
            Dim blnFileFormat As Boolean = False

            ' if blnFileFormat is set, an .ampmap file was found, otherwise a .fitt file (default)
            If CBool(InStr(1, szFile, ".fitt", CompareMethod.Text)) Then
                blnFileFormat = False
            ElseIf CBool(InStr(1, szFile, ".ampmap", CompareMethod.Text)) Then
                blnFileFormat = True
            End If

            Do
                szTemp = file.ReadLine

                If Not IsNothing(szTemp) Then
                    If blnFileFormat Then
                        ParseLineAmpmap(szTemp)     ' .ampmap file
                    Else
                        ParseLineFitt(szTemp)       ' .fitt file
                    End If
                End If
            Loop Until IsNothing(szTemp)
            Return ""

            'Select Case mImpType
            '    Case IMPLANTTYPE.imptInvalid
            '        Return "File is not a valid fitting file"
            '    Case IMPLANTTYPE.imptC40C, IMPLANTTYPE.imptC40P
            '        DeviceTypeRequired = GENMODE.genElectricalRIB
            '        Return ""
            '    Case IMPLANTTYPE.imptC40P_RIB2, IMPLANTTYPE.imptPulsar
            '        DeviceTypeRequired = GENMODE.genElectricalRIB2
            '        Return ""
            '    Case IMPLANTTYPE.imptCIC3
            '        DeviceTypeRequired = GENMODE.genElectricalNIC
            '        Return ""
            'End Select

            'Return ""
            '----------------------------------------------

    Error_FileNotOpen:
            Return Err.Description


        End Function

        Private Function ParseLineFitt(ByVal szLine As String) As String
            Dim iX, iY As Integer
            Dim szPar, szVal As String
            Dim sX As Double

            If Not mblnTableMode Then
                ' Parameter mode, syntax: "parameter name: parameter value"
                iX = InStr(1, szLine, "----") 'check for mode change
                If iX <> 0 Then
                    mblnTableMode = True
                    Return "" ' set to table mode and exit
                End If
                iX = InStr(1, szLine, ":")
                If iX = 0 Then Return "" ' skip empty lines
                szPar = Left(szLine, iX - 1) ' split to parameter and value strings
                szPar = UCase(szPar) ' set to upper case
                szPar = Replace(szPar, " ", "") ' remove all blanks
                szVal = Mid(szLine, iX + 1)
                szVal = LTrim(szVal)
                Select Case szPar
                    Case "PATIENT"
                        On Error GoTo 0
                        mszLastName = RTrim(Mid(szVal, 1, 20))
                        mszFirstName = RTrim(Mid(szVal, 22))
                        'MsgBox "lName:" + mszLastName + vbCrLf + "Fname:" + mszFirstName
                    Case "BIRTHDATE"
                        '
                    Case "IMPL/PROCTYPE"
                        szVal = Mid(szVal, 1, 8) ' only first 8 chars
                        szVal = Trim(UCase(szVal)) ' remove all blanks
                        Select Case szVal
                            Case C40C_DESCR
                                ImpType = IMPLANTTYPE.imptC40C
                                'mszImpType = C40C_DESCR
                                'mImpType = IMPLANTTYPE.imptC40C
                                'mlChannelsCount = C40C_CHNR
                                'msTimeBase = C40C_TIMEBASE
                                'ReDim msRangeMul(C40C_RANGE_MAX)
                                'msRangeMul(0) = C40C_RANGE0
                                'msRangeMul(1) = C40C_RANGE1
                                'msRangeMul(2) = C40C_RANGE2
                                'msRangeMul(3) = C40C_RANGE3
                                'DeviceTypeRequired = GENMODE.genElectricalRIB
                            Case C40P_DESCR
                                ImpType = IMPLANTTYPE.imptC40P
                                'mszImpType = C40P_DESCR
                                'mImpType = IMPLANTTYPE.imptC40P
                                'mlChannelsCount = C40P_CHNR
                                'msTimeBase = C40P_TIMEBASE
                                'ReDim msRangeMul(C40P_RANGE_MAX)
                                'msRangeMul(0) = C40P_RANGE0
                                'msRangeMul(1) = C40P_RANGE1
                                'msRangeMul(2) = C40P_RANGE2
                                'msRangeMul(3) = C40P_RANGE3
                                'DeviceTypeRequired = GENMODE.genElectricalRIB

                                'Case C40P_RIB2_DESCR
                                '    ImpType = IMPLANTTYPE.imptC40P_RIB2
                                'Case UCase(PULSAR_DESCR)
                                '    ImpType = IMPLANTTYPE.imptPulsar

                            Case CIC3_DESCR
                                ImpType = IMPLANTTYPE.imptCIC3
                                'mszImpType = CIC3_DESCR
                                'mImpType = IMPLANTTYPE.imptCIC3
                                'mlChannelsCount = CIC3_CHNR
                                'msTimeBase = CIC3_TIMEBASE
                                'ReDim msRangeMul(CIC3_RANGE_MAX)
                                'msRangeMul(0) = CIC3_RANGE0
                                'DeviceTypeRequired = GENMODE.genElectricalNIC
                            Case Else
                                Return "Unknown implant type: " & szVal
                        End Select
                        'ReDim chpChannel(mlChannelsCount - 1)
                        'For lX As Integer = 0 To mlChannelsCount - 1
                        '    chpChannel(lX) = New CHANNELPARAMETER
                        'Next
                    Case "IMPLANTEDEAR"
                        szVal = Trim(UCase(szVal))
                        Select Case szVal
                            Case "LEFT"
                                mEar = EARTYPE.LEFT
                            Case "RIGHT"
                                mEar = EARTYPE.RIGHT
                            Case Else
                                Return "Unknown implanted ear: " & szVal
                        End Select
                    Case "MINPULSEDIST"
                        sX = Val(szVal)
                        mlMinDist = CInt(Math.Round(sX / msTimeBase))
                    Case "PRATE/CHANNEL"
                        sX = Val(szVal)
                        mlPulsePeriod = CInt(Math.Round(1000000 / sX / msTimeBase))
                    Case "MAPLAW"
                        mszMapLaw = szVal
                    Case "CHANNELORDER"
                        mszChannelOrder = szVal
                    Case "GAPDURATION"
                        mlDuration = CInt(Val(szVal))
                    Case "COMMENTS"
                        Prefix = szVal
                End Select
            Else
                ' Table mode: read all values per channel
                ' syntax: PARAMETER val1 val2 ... valN
                '         N... mlChannelsCount (number of channels)
                iX = InStr(1, szLine, " ")
                If iX = 0 Then Return "" ' skip empty lines
                szLine = UCase(szLine) ' set to upper case
                szPar = Left(szLine, 8) ' split to parameter and value strings
                szPar = Trim(szPar)
                szVal = Mid(szLine, 9)
                szVal = LTrim(szVal)
                Select Case szPar
                    Case "MCL[BIT]"
                        For iX = 0 To mlChannelsCount - 1
                            iY = InStr(1, szVal, " ")
                            If iY <> 0 Then
                                chpChannel(iX).lMCL = CInt(Val(Mid(szVal, 1, iY)))
                                szVal = LTrim(Mid(szVal, iY))
                            Else
                                chpChannel(iX).lMCL = CInt(Val(szVal))
                            End If
                        Next
                    Case "THR[BIT]"
                        For iX = 0 To mlChannelsCount - 1
                            iY = InStr(1, szVal, " ")
                            If iY <> 0 Then
                                chpChannel(iX).lTHR = CInt(Val(Mid(szVal, 1, iY)))
                                szVal = LTrim(Mid(szVal, iY))
                            Else
                                chpChannel(iX).lTHR = CInt(Val(szVal))
                            End If
                        Next
                    Case "CURRANGE"
                        For iX = 0 To mlChannelsCount - 1
                            iY = InStr(1, szVal, " ")
                            If iY <> 0 Then
                                chpChannel(iX).lRange = CInt(Val(Mid(szVal, 1, iY)))
                                szVal = LTrim(Mid(szVal, iY))
                            Else
                                chpChannel(iX).lRange = CInt(Val(szVal))
                            End If
                        Next
                    Case "PULSDUR"
                        For iX = 0 To mlChannelsCount - 1
                            iY = InStr(1, szVal, " ")
                            If iY <> 0 Then
                                chpChannel(iX).lPhDur = CInt(Val(Mid(szVal, 1, iY)))
                                szVal = LTrim(Mid(szVal, iY))
                            Else
                                chpChannel(iX).lPhDur = CInt(Val(szVal))
                            End If
                        Next
                End Select
            End If

            Return ""
        End Function

        Private Function ParseLineAmpmap(ByVal szLine As String) As String
            Dim iX, iY As Integer
            Dim szPar, szVal, szX, szY As String
            'Dim sX As Double
            Dim szArray As String()

            If Not mblnTableMode Then
                ' Parameter mode (comment section), syntax: "# parameter name: parameter value"
                iX = InStr(1, szLine, ":") ' check for mode change (indicated by the first empty line)
                If iX = 0 Then
                    mblnTableMode = True
                    Return "" ' skip empty line, set to table mode and exit
                End If


                szPar = Left(szLine, iX - 1) ' split to parameter and value strings
                szPar = UCase(szPar) ' set to upper case
                szPar = Replace(szPar, " ", "") ' remove all blanks
                szPar = szPar.Trim(CChar("#"))
                szVal = Mid(szLine, iX + 1)
                szVal = LTrim(szVal)
                Select Case szPar
                    Case "FITTINGFILE"
                        '
                    Case "PATIENT" 'should not be used anymore
                        iY = InStr(1, szVal, " ")
                        If iY > 0 Then
                            mszFirstName = Left(szVal, iY - 1)
                            mszLastName = Trim(Mid(szVal, iY + 1))
                        End If
                    Case "FIRSTNAME"
                        mszFirstName = szVal
                    Case "LASTNAME"
                        mszLastName = szVal
                    Case "IMPLANTEDEAR"
                        szVal = Trim(UCase(szVal))
                        Select Case szVal
                            Case "LEFT"
                                mEar = EARTYPE.LEFT
                            Case "RIGHT"
                                mEar = EARTYPE.RIGHT
                            Case Else
                                Return "Unknown implanted ear: " & szVal
                        End Select
                    Case "DURATIONF4F"
                        mlDuration = CInt(Val(szVal))
                    Case "PULSEPERIOD"
                        mlPulsePeriodTemp=Val(szVal)
                        'sX = Val(szVal)
                        'If msTimeBase > 0 Then
                        '    Try
                        '        mlPulsePeriod = CInt(Math.Round(sX / msTimeBase))
                        '    Catch ex As Exception When msTimeBase = 0
                        '    End Try
                        'End If
                    Case "MINIMUMPULSEDISTANCE"
                        mlMinDistTemp= Val(szVal)
                        'sX = Val(szVal)
                        'If msTimeBase > 0 Then
                        '    Try
                        '        mlMinDist = CInt(Math.Round(sX / msTimeBase))
                        '    Catch ex As Exception When msTimeBase = 0
                        '    End Try
                        'End If
                    Case "FITTINGCREATIONTIME&DATE"
                        '
                End Select
            Else
                ' Table mode: read all values within MAP section
                iX = InStr(1, szLine, " ")
                If iX = 0 Then Return "" ' skip empty lines and lines with no blank (i.e., MAP and ENDMAP)
                szPar = Left(szLine, iX - 1) ' split to parameter and value strings
                szPar = UCase(szPar) ' set to upper case
                szVal = Mid(szLine, iX + 1)
                szVal = LTrim(szVal)
                Select Case szPar
                    Case "IMPLANTTYPE"
                        If ImpType = IMPLANTTYPE.imptInvalid Then
                            ' set implant type
                            ' important when opening a fitting file within F4F: 
                            ' only when file is read out the first time to determine the implant type which is then initialised afterwards
                            ' do not reset the second time when implant type has already been set to not overwrite <mEar> and <mlDuration>
                            szVal = Trim(UCase(szVal)) ' remove all blanks
                            Select Case szVal
                                Case C40C_DESCR
                                    ImpType = IMPLANTTYPE.imptC40C
                                    MsgBox("You are loading a fitting file for a C40C implant. RIB2 does not support this implant type.")
                                Case C40P_DESCR, C40P_RIB2_DESCR
                                    ImpType = IMPLANTTYPE.imptC40P_RIB2
                                    'Fitting file is read twice, so variables need not to be set -> lines commented
                                    'mlChannelsCount = C40P_RIB2_CHNR    ' mlChannelsCount is needed for extracting pulse durations and current ranges
                                    'AMP_MAX = C40P_RIB2_AMP_MAX         ' AMP_MAX is needed for setting THR and MCL
                                Case UCase(PULSAR_DESCR)
                                    ImpType = IMPLANTTYPE.imptPulsar
                                Case CIC3_DESCR
                                    ImpType = IMPLANTTYPE.imptCIC3
                                    MsgBox("You are loading a fitting file for a Nucleus CIC3 implant. RIB2 does not support this implant type.")
                                Case Else
                                    Return "Unknown implant type: " & szVal
                            End Select

                            If mlPulsePeriodTemp > 0 Then
                                'set pulse period
                                Try
                                mlPulsePeriod = CInt(Math.Round(mlPulsePeriodTemp / msTimeBase))
                            Catch ex As Exception When msTimeBase = 0
                            End Try
                            end if
                        
                            If mlMinDistTemp > 0 Then
                                Try
                                mlMinDist = CInt(Math.Round(mlMinDistTemp / msTimeBase))
                            Catch ex As Exception When msTimeBase = 0
                                End Try
                            End If

                        End If
                    Case "DEFAULT"
                        ' distinguish between data stream types
                        iX = InStr(1, szVal, " ")
                        szX = Left(szVal, iX - 1)
                        szX = UCase(szX)
                        szVal = Mid(szVal, iX + 1)
                        szVal = LTrim(szVal)
                        Select Case szX
                            Case "LEGACY"
                                ' syntax - Legacy data stream:
                                ' Default Legacy Phases <unmapped dur> <dur 1> ... <last dur> Ranges <range 1> ... <last range> 
                                ' (where Phases and Ranges are optional)
                                iX = InStr(1, szVal, "#Ranges")     ' # so that the ranges are only used for F4F and disable ranges within the default command when loaded in the stm file
                                If CBool(iX) Then
                                    szY = Trim(Mid(szVal, iX + 7))
                                    szArray = szY.Split(CChar(" "))
                                    For iY = 0 To mlChannelsCount - 1
                                        chpChannel(iY).lRange = CInt(szArray(iY))
                                    Next
                                    szVal = RTrim(Left(szVal, iX - 1))
                                End If

                                iX = InStr(1, szVal, "Phases")
                                If CBool(iX) Then
                                    szVal = Trim(Mid(szVal, iX + 7))
                                    szArray = szVal.Split(CChar(" "))
                                    For iY = 0 To mlChannelsCount - 1
                                        chpChannel(iY).lPhDur = CInt(Math.Round(Val(szArray(iY + 1)) / msTimeBase)) ' iY + 1 to ignore <unmapped dur>"
                                    Next
                                End If

                                mszDataStream = "Legacy"
                                msGapDur = 2.1
                            Case "PULSAR"
                                ' syntax - Pulsar data stream:
                                ' Default Pulsar Phase <phase dur> Gap <gap dur> Parallel Ranges <range 1> ... <last range>
                                ' ADAPTED TO THE TEMPORARY SOLUTION OF FUNCTION <SaveFileAmpmap>
                                iX = InStr(1, szVal, "Ranges")
                                szY = Trim(Mid(szVal, iX + 7))
                                szArray = szY.Split(CChar(" "))
                                For iY = 0 To mlChannelsCount - 1
                                    chpChannel(iY).lRange = CInt(szArray(iY))
                                Next

                                szVal = RTrim(Left(szVal, iX - 1))
                                szArray = szVal.Split(CChar(" "))
                                For iY = 0 To mlChannelsCount - 1
                                    chpChannel(iY).lPhDur = CInt(Math.Round(Val(szArray(1)) / msTimeBase))
                                Next
                                mszDataStream = "Pulsar"
                                msGapDur = CDbl(Val(szArray(3)))
                        End Select
                    Case "TRANSLATE"
                        szVal = Trim(szVal)
                        szArray = szVal.Split(CChar(" "))

                        For iX = 0 To UBound(szArray)
                            If IsNumeric(szArray(iX)) Then
                                chpChannel(CInt(Val(szArray(iX))) - 1).blnChUsed = True
                            ElseIf szArray(iX) = "X" Then
                                chpChannel(iX).blnChUsed = False    ' implies that values for all channels are given in ascending order
                                chpChannel(iX).lTHR = 0
                                chpChannel(iX).lMCL = 0
                            End If
                        Next
                    Case "PREGAIN"
                        '
                    Case "POSTGAIN"
                        '
                    Case "ELECTRODE"
                        ' syntax: 'ELECTRODE szVal' with szVal = '<elec> <THR> <THR> <MCL> <MCL> [Zero | Low] [<c>]' (maplaw is optional!)
                        szArray = szVal.Split(CChar(" "))
                        iX = CInt(szArray(0)) - 1
                        If szArray.Length < 5 Then
                            MsgBox("Not enough parameters provided within mapping command for electrode " & iX.ToString & "!")
                            Return "<Electrode> mapping command incomplete."
                        End If

                        If iX <= mlChannelsCount - 1 Then
                            chpChannel(iX).lTHR = CInt(Val(szArray(2)))
                            chpChannel(iX).lMCL = CInt(Val(szArray(4)))
                            If szArray.Length > 5 Then
                                mszMapLaw = szArray(5)
                                If szArray.Length > 6 AndAlso szArray(6) <> "#" Then mszMapLaw = mszMapLaw & " " & szArray(6) ' if [<c>]
                            Else
                                mszMapLaw = ""
                            End If
                        End If
                End Select

            End If

            Return ""
        End Function

    End Class
