Option Strict On
Option Explicit On
#Region "ExpSuite License"
'ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
'Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Michael Mihocic and Piotr Majdak
'Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
'You may not use this work except in compliance with the Licence. 
'You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
'Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
'See the Licence for the specific language governing  permissions and limitations under the Licence. 
#End Region
Module Config
	
    ' number of audio channels
    Public Const PLAYER_MAXCHANNELS As Short = 200

    ''' <summary>
    ''' Define item list extension (before ExpSuite FW v1.0 default was: "itl.csv").
    ''' </summary>
    ''' <remarks>The leading dot '.' is not necessary.</remarks>
    Public Const ItemListExtension As String = "itl.csv"
	
	' number of experiment types
	Public Const ExpTypeNumber As Short = 4
	
    ' put your experiment specific data here

	' application related data
	Public grectfrmIR As RECT
    Public grectfrmPlothM As RECT
    Public grectfrmPlotTOA As RECT
	
	Public gszScript As String
	
	' constants
	Public glMLSOrder As Integer
	Public glPlayLength As Integer
	Public glFreqSpan As Integer
	Public glNotchOrder As Integer
    Public gsTHDTheta As Double
	Public glFreqStart As Integer
	Public glFreqEnd As Integer
	Public glMLSRepetition As Integer
    Public gsRecTrail As Double
    Public glTrackerInRange As Integer
    'Global glLPT As Long
    Public gsIRBeg, gsIRLen, gsIREnd As Double
	Public gszPreemphasis As String
	Public glBlockSize As Integer
	
	' variables
    Public gElevation() As String ' is ChannelID in all other exp. types
    Public gAzimuth() As String
    Public gRecStream() As String
    Public gAmp() As String
    Public gFreq() As String
    Public gISD() As String
	' description of columns, separate items with semicolons
    Public FLGTEXT As String

End Module