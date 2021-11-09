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

''' <summary><c>clsFREQUENCY</c>
'''   Parameters of an Electrode or Acoustical channel.
'''   See Settings/Signal. The parameters of gfreqParL() and gfreqParR() as saved based on the clsFREQUENCY class.
''' </summary>
Friend Class clsFREQUENCY

    Private sAmpvar As Double
    Private lRangevar As Integer
    Private lPhDurvar As Integer
    Private sSPLOffsetvar As Double
    Private sCenterFreqvar As Double
    Private sBandwidthvar As Double
    Private sTHRvar As Double
    Private sMCLvar As Double

    'Property Gets and Property Lets get and set the properties of an object:

    ''' <summary><c>sAmp()</c>
    '''   Get / Set Amplitude
    ''' </summary>
    Friend Property sAmp() As Double
        Get
            sAmp = sAmpvar
        End Get
        Set(ByVal Value As Double)
            sAmpvar = Value
        End Set
    End Property

    ''' <summary><c>lRange()</c>
    '''   Get / Set Range
    ''' </summary>
    Friend Property lRange() As Integer
        Get
            lRange = lRangevar
        End Get
        Set(ByVal Value As Integer)
            lRangevar = Value
        End Set
    End Property

    ''' <summary><c>lPhDur()</c>
    '''   Get / Set Phase Duration [samples]
    ''' </summary>
    Friend Property lPhDur() As Integer
        Get
            lPhDur = lPhDurvar
        End Get
        Set(ByVal Value As Integer)
            lPhDurvar = Value
        End Set
    End Property

    ''' <summary><c>sSPLOffset()</c>
    '''   Get / Set SPL offset.
    '''   Acoustical mode only: SPL Offset as additional attenuation of signal. Must be implemented by yourself.
    ''' </summary>
    Friend Property sSPLOffset() As Double
        Get
            sSPLOffset = sSPLOffsetvar
        End Get
        Set(ByVal Value As Double)
            sSPLOffsetvar = Value
        End Set
    End Property

    ''' <summary><c>sCenterFreq()</c>
    '''   Get / Set Center frequency.
    '''   Acoustical mode only: Center Frequency of the channel [Hz]
    ''' </summary>
    Friend Property sCenterFreq() As Double
        Get
            sCenterFreq = sCenterFreqvar
        End Get
        Set(ByVal Value As Double)
            sCenterFreqvar = Value
        End Set
    End Property

    ''' <summary><c>sBandwidth()</c>
    '''   Get / Set Bandwidth.
    '''   Acoustical mode only: Bandwidth of the channel [Hz]
    ''' </summary>
    Friend Property sBandwidth() As Double
        Get
            sBandwidth = sBandwidthvar
        End Get
        Set(ByVal Value As Double)
            sBandwidthvar = Value
        End Set
    End Property

    ''' <summary><c>sTHR()</c>
    '''   Get / Set Threshold.
    '''   Electrical mode: the lowest allowed amplitude. Acoustical mode: the lowest recommended amplitude.
    '''  </summary>
    ''' <see cref="clsFREQUENCY.sMCL">sMCL</see>
    Friend Property sTHR() As Double
        Get
            sTHR = sTHRvar
        End Get
        Set(ByVal Value As Double)
            sTHRvar = Value
        End Set
    End Property

    ''' <summary><c>sMCL()</c>
    '''   Get / Set Most Comfortable Level.
    '''   Electrical mode: the highest allowed amplitude. Acoustical mode: the highest recommended amplitude.
    ''' </summary>
    ''' <see cref="clsFREQUENCY.sTHR">sTHR</see>
    Friend Property sMCL() As Double
        Get
            sMCL = sMCLvar
        End Get
        Set(ByVal Value As Double)
            sMCLvar = Value
        End Set
    End Property


    ''' <summary><c>Copy()</c>
    '''   Copies the properties of one object of clsFREQUENCY to another.
    '''   Acoustical mode only: Bandwidth of the channel [Hz]
    ''' </summary>
    ''' <returns>A copy of input object</returns>
    ''' <example>Set freqA = freqB.Copy</example>
    Friend Function Copy() As clsFREQUENCY
        Copy = New clsFREQUENCY

        Copy.sAmp = sAmpvar
        Copy.lRange = lRangevar
        Copy.lPhDur = lPhDurvar
        Copy.sSPLOffset = sSPLOffsetvar
        Copy.sCenterFreq = sCenterFreqvar
        Copy.sBandwidth = sBandwidthvar
        Copy.sTHR = sTHRvar
        Copy.sMCL = sMCLvar

    End Function
End Class