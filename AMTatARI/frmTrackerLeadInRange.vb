Option Strict On
Option Explicit On
#Region "ExpSuite License"
'ExpSuite - software framework for applications to perform experiments (related but not limited to psychoacoustics).
'Copyright (C) 2003-2021 Acoustics Research Institute - Austrian Academy of Sciences; Piotr Majdak and Michael Mihocic
'Licensed under the EUPL, Version 1.2 or – as soon they will be approved by the European Commission - subsequent versions of the EUPL (the "Licence")
'You may not use this work except in compliance with the Licence. 
'You may obtain a copy of the Licence at: https://joinup.ec.europa.eu/software/page/eupl
'Unless required by applicable law or agreed to in writing, software distributed under the Licence is distributed on an "AS IS" basis, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
'See the Licence for the specific language governing  permissions and limitations under the Licence. 
#End Region
Friend Class frmTrackerLeadInRange
	Inherits System.Windows.Forms.Form
	
    Dim msFreq, msAmp, msAzimuth As Double
    Const msFreqMax As Short = 3000
    Dim mlState, mlProcedure As Integer
    Dim mcurTic, mcurToc As Long
    Dim mszErr As String

    Public Function ShowForm(ByRef sAmp As Double, ByRef sFreq As Double, ByRef sAzimuth As Double) As String

        ' sensor left the range - lead in the correct position range again

        ' close settings form to prevent simultanous requests to the tracke module
        'If gblnSettingsForm Then
        '    frmSettings.tmrTracker.Enabled = False
        '    gblnSettingsForm = False
        '    frmSettings.Close()
        'End If

        ' save private data
        msAmp = sAmp
        msFreq = sFreq
        msAzimuth = sAzimuth

        ' show the form
        gblnCancel = True
        Me.ShowDialog()
        ShowForm = mszErr

        ' in range - let's try again
        Output.Send("/DAC/SetAddStream/0", "set", "silence")
        Output.Send("/Synth/SetSignal/0", "nope")
        Output.Send("/Synth/SetPar1/0", sFreq)
        Output.Send("/DAC/SetVol/0", 0)
        Output.Send("/Synth/SetVol/0", 0)
        Output.Send("/DAC/SetAddStream/1", "set", "silence")
        Output.Send("/Synth/SetSignal/1", "nope")
        Output.Send("/Synth/SetPar1/1", sFreq)
        Output.Send("/DAC/SetVol/1", 0)
        Output.Send("/Synth/SetVol/1", 0)

    End Function

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        gblnCancel = True
        Me.Close()
    End Sub

    Private Sub frmTrackerLeadInRange_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Me.Icon = frmMain.Icon

        ' update controls
        ItemList.Item((ItemList.ItemIndex), "STATUS") = "Tracker!"

        ' init channels
        Output.Send("/DAC/SetAddStream/0", "set", "syn0")
        Output.Send("/Synth/SetSignal/0", "cosine")
        Output.Send("/Synth/SetPar1/0", msFreq)
        Output.Send("/DAC/SetVol/0", msAmp)
        Output.Send("/Synth/SetVol/0", msAmp)
        Output.Send("/DAC/SetAddStream/1", "set", "syn1")
        Output.Send("/Synth/SetSignal/1", "cosine")
        Output.Send("/Synth/SetPar1/1", msFreq + msFreqMax)
        Output.Send("/DAC/SetVol/1", msAmp)
        Output.Send("/Synth/SetVol/1", msAmp)

        ' init data
        mlProcedure = 0
        mlState = 0
        If glTrackerSettingsInterval > 0 Then
            tmrTracker.Interval = glTrackerSettingsInterval
            tmrTracker.Enabled = True
        Else
            tmrTracker.Enabled = False
        End If
        QueryPerformanceCounter(mcurTic)

    End Sub

    Private Sub tmrTracker_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrTracker.Tick
        Dim lIn, lMin, lX, lMax, lY As Integer
        Dim tsData As TrackerSensor
        Dim sRadius As Double
        Dim curToc As Long

        mszErr = Tracker.GetCurrentValues(tmrTracker.Interval \ 2, 0, tsData)
        If Len(mszErr) <> 0 Then gblnCancel = False : Me.Close() : Return

        lblTrackerX(0).Text = TStr(System.Math.Round(tsData.sngX, 1))
        lblTrackerY(0).Text = TStr(System.Math.Round(tsData.sngY, 1))
        lblTrackerZ(0).Text = TStr(System.Math.Round(tsData.sngZ, 1))
        lblTrackerA(0).Text = TStr(System.Math.Round(tsData.sngA, 1))
        lblTrackerE(0).Text = TStr(System.Math.Round(tsData.sngE, 1))
        lblTrackerR(0).Text = TStr(System.Math.Round(tsData.sngR, 1))

        lMin = Tracker.CheckTrackedMinValue(0, gtsTrackerMin(0).lStatus)
        lMax = Tracker.CheckTrackedMaxValue(0, gtsTrackerMax(0).lStatus)
        lIn = Tracker.CheckTrackedInRange(0, gtsTrackerMax(0).lStatus)

        Tracker.ResetMinMaxValues(0)

        For lX = 0 To 5
            If (gtsTrackerMin(0).lStatus And CInt(2 ^ lX)) <> 0 Then
                If (lMin And CInt(2 ^ lX)) <> 0 Then
                    shpMin(CShort(lX)).BackColor = System.Drawing.ColorTranslator.FromOle(&HFF)
                    shpMax(CShort(lX)).BackColor = Me.BackColor
                End If
            End If
            If (gtsTrackerMax(0).lStatus And CInt(2 ^ lX)) <> 0 Then
                If (lMax And CInt(2 ^ lX)) <> 0 Then
                    shpMax(CShort(lX)).BackColor = System.Drawing.ColorTranslator.FromOle(&HFF)
                    shpMin(CShort(lX)).BackColor = Me.BackColor
                End If
            End If
            If (lIn And CInt(2 ^ lX)) <> 0 Then
                shpMin(CShort(lX)).BackColor = System.Drawing.ColorTranslator.FromOle(&HFF00)
                shpMax(CShort(lX)).BackColor = System.Drawing.ColorTranslator.FromOle(&HFF00)
            End If
        Next

        Select Case mlProcedure
            Case 0 ' position
                sRadius = (tsData.sngX) ^ 2 + (tsData.sngY) ^ 2 + (tsData.sngZ) ^ 2
                If sRadius > msFreqMax Then sRadius = msFreqMax

                lX = lMin And &H7S
                lX = lX Or (lMax And &H7S)
                lY = lIn And lX
                If lX = lY Then
                    If mlState <> 1 Then
                        mlState = 1 ' in range
                        Output.Send("/Synth/SetPar1/0", msFreq / 3 * 2)
                        Output.Send("/Synth/SetPar1/1", msFreq / 3 * 2)
                        QueryPerformanceCounter(mcurTic)
                        lblStatus.Text = "Position: waiting"
                    End If
                Else
                    QueryPerformanceCounter(mcurTic)
                    If mlState <> 2 Then mlState = 2 ' out of range again
                End If

                If mlState <> 1 Then
                    Output.Send("/Synth/SetPar1/0", msFreq)
                    Output.Send("/Synth/SetPar1/1", msFreq + sRadius)
                    lblStatus.Text = "Position: establishing"
                End If

                QueryPerformanceCounter(curToc)
                pbInRange.Value = CInt(((curToc - mcurTic) \ (glTrackerInRange * gcurHPFrequency \ 1000) * 100) Mod 100) ' glTrackerInRange=interval in which tracker must be in range e.g. 500ms

                If curToc > (mcurTic + CDec(glTrackerInRange) * gcurHPFrequency / 1000) Then
                    ' Position OK, next procedure
                    lblStatus.Text = "Position: OK" & vbCrLf & "Orientation: establishing"
                    mlProcedure = 1
                    mlState = 0
                    msFreq = msFreq / 3 * 2
                    Output.Send("/Synth/SetPar1/0", msFreq)
                End If

            Case 1 ' orientation
                sRadius = (((tsData.sngA - msAzimuth + 180) Mod 360) - 180) ^ 2 + (((tsData.sngE + 180) Mod 360) - 180) ^ 2 + (((tsData.sngR + 180) Mod 360) - 180) ^ 2
                If sRadius > msFreqMax Then sRadius = msFreqMax

                lX = lMin And &H38S
                lX = lX Or (lMax And &H38S)
                lY = lIn And lX
                If lX = lY Then
                    If mlState <> 1 Then
                        mlState = 1 ' in range
                        Output.Send("/Synth/SetPar1/0", msFreq / 3 * 2)
                        Output.Send("/Synth/SetPar1/1", msFreq / 3 * 2)
                        lblStatus.Text = "Position: OK" & vbCrLf & "Orientation: waiting"
                        QueryPerformanceCounter(mcurTic)
                    End If
                Else
                    QueryPerformanceCounter(mcurTic)
                    If mlState <> 2 Then mlState = 2 ' out of range again
                End If

                If mlState <> 1 Then
                    Output.Send("/Synth/SetPar1/0", msFreq)
                    Output.Send("/Synth/SetPar1/1", msFreq + sRadius)
                    lblStatus.Text = "Position: OK" & vbCrLf & "Orientation: establishing"
                End If

                QueryPerformanceCounter(curToc)
                pbInRange.Value = CInt(((curToc - mcurTic) \ (glTrackerInRange * gcurHPFrequency \ 1000) * 100) Mod 100)
                If curToc > (mcurTic + CDec(glTrackerInRange) * gcurHPFrequency / 1000) Then
                    ' position ok, orientation ok
                    lblStatus.Text = "Position: OK" & vbCrLf & "Orientation: OK"
                    mszErr = ""
                    gblnCancel = False
                    Me.Close()
                End If
        End Select
        Return

    End Sub
End Class