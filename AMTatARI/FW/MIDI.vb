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
''' FrameWork - Handling of MIDI devices.
''' </summary>
''' <remarks></remarks>
Module MIDI

   ''' <summary>
    ''' Send a command to MIDI Out.
    ''' </summary>
    ''' <param name="lCh">Channel number.</param>
    ''' <param name="lCtrl">Controller number</param>
    ''' <param name="lVal">Value</param>
    ''' <remarks>FrameWork is connected to MIDI via YAMI, the devices are set in Options/Audio.
    ''' Use MIDI.Out to send a message to your MIDI device. Any response of the device (via MIDI In)
    ''' will be forwarded to Events.OnOutputResponse</remarks>
    Public Sub Out(ByVal lCh As Integer, ByVal lCtrl As Integer, ByVal lVal As Integer)
        'Output.Send("/MIDI", lCh, lCtrl, lVal)
        'frmMain.SetStatus "MIDI/Out: " + TStr(lCtrl) + ":" + TStr(lVal)
    End Sub

    Public Function HandleResponse(ByVal szCmd As String, ByVal varArgs() As Object) As String
        ' update viwo parameters
        If Not gblnMIDIIgnore Then
            If gblnViWoLoaded Then
                'ViWo.ChangeParameterByMIDI(CInt(Val(varArgs(1))), CInt(Val(varArgs(2))))
            End If
        End If
        HandleResponse = ""
    End Function

    Public Sub IgnoreInput(ByVal lTime As Integer)
        'gblnMIDIIgnore = True
        '      If lTime = 0 Then
        'frmMain.tmrMIDI.Enabled = False
        '      Else
        '          frmMain.tmrMIDI.Interval = lTime
        '          frmMain.tmrMIDI.Enabled = True
        '      End If
    End Sub
End Module