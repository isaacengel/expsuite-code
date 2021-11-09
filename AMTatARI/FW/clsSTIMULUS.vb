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
Friend Class clsSTIMULUS
    ''
    'Structure for a simple pulse train stimulus
    Private lElectrodevar As Integer
    Private sAmpvar As Single
    Private lRangevar As Integer
    Private lPhDurvar As Integer
    Private lPulsePeriodvar As Integer
    Private lModifiervar As Integer


    'Property Gets and Property Lets get and set the properties of an object:

    ''' <summary>
    ''' Electrode or acoustical channel.
    ''' </summary>
    ''' <value>Electrode/channel index.</value>
    ''' <returns>Electrode/channel index.</returns>
    ''' <remarks>Get/set index.</remarks>
    Friend Property lElectrode() As Integer
        Get
            lElectrode = lElectrodevar
        End Get
        Set(ByVal Value As Integer)
            lElectrodevar = Value
        End Set
    End Property

    ''' <summary>
    ''' Amplitude.
    ''' </summary>
    ''' <value>Amplitude value.</value>
    ''' <returns>Amplitude value.</returns>
    ''' <remarks>RIB: 0..127 [digits], YAMI:-100..0 [dB].</remarks>
    Friend Property sAmp() As Single
        Get
            sAmp = sAmpvar
        End Get
        Set(ByVal Value As Single)
            sAmpvar = Value
        End Set
    End Property

    ''' <summary>
    ''' Amplitude Range.
    ''' </summary>
    ''' <value>Range value.</value>
    ''' <returns>Range value.</returns>
    ''' <remarks>In electrical mode only.</remarks>
    Friend Property lRange() As Integer
        Get
            lRange = lRangevar
        End Get
        Set(ByVal Value As Integer)
            lRangevar = Value
        End Set
    End Property

    ''' <summary>
    ''' Phase Duration [samples].
    ''' </summary>
    ''' <value>Phase duration.</value>
    ''' <returns>Phase duration.</returns>
    ''' <remarks>Electrical mode: A pulse includes one positive and negative phase, duration is: 2*lPhDur+1
    ''' Acoustical mode: A pulse is lPhDur long (positive phase only).</remarks>
    Friend Property lPhDur() As Integer
        Get
            lPhDur = lPhDurvar
        End Get
        Set(ByVal Value As Integer)
            lPhDurvar = Value
        End Set
    End Property

    ''' <summary>
    ''' Pulse Period [samples].
    ''' </summary>
    ''' <value>Pulse Period.</value>
    ''' <returns>Pulse Period.</returns>
    ''' <remarks>Interpulse interval (IPI), interclick interval (ICI), 1/Pulse rate.</remarks>
    Friend Property lPulsePeriod() As Integer
        Get
            lPulsePeriod = lPulsePeriodvar
        End Get
        Set(ByVal Value As Integer)
            lPulsePeriodvar = Value
        End Set
    End Property

    ''' <summary>
    ''' Modifier in electrical mode.
    ''' </summary>
    ''' <value>Modifier value.</value>
    ''' <returns>Modifier value.</returns>
    Friend Property lModifier() As Integer
        Get
            lModifier = lModifiervar
        End Get
        Set(ByVal Value As Integer)
            lModifiervar = Value
        End Set
    End Property

    ''' <summary>
    ''' Copy stimulus class.
    ''' </summary>
    Friend Function Copy() As clsSTIMULUS
        Copy = New clsSTIMULUS

        Copy.lElectrode = lElectrodevar
        Copy.sAmp = sAmpvar
        Copy.lRange = lRangevar
        Copy.lPhDur = lPhDurvar
        Copy.lPulsePeriod = lPulsePeriodvar
        Copy.lModifier = lModifiervar

    End Function
End Class