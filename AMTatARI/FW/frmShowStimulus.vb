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
' plot stimuli before they are assembled
''' <summary>
''' FrameWork Module. Implementation of the Show Stimulus dialog.
''' </summary>
''' <remarks></remarks>
Friend Class frmShowStimulus
    Inherits System.Windows.Forms.Form
    Private mlFlags As Integer
    Private IsInitializing As Boolean



    Private Sub SetControls(ByVal lF As Integer)

        mlFlags = lF
        ' Build controls

        ' build mode combo
        If CBool(lF And 128) Then
            ' matrix mode
            cmbMode.Items.Clear()
            cmbMode.Items.Add("Color Plot")
            cmbMode.Items.Add("Waterfall")
            cmbMode.Items.Add("Mesh")
            cmbMode.Items.Add("Stretched 2D Plot")
            cmbMode.Items.Add("Surface")
        Else
            ' vector mode
            cmbMode.Items.Clear()
            cmbMode.Items.Add("2D Plot")
            cmbMode.Items.Add("Specgram")
            cmbMode.Items.Add("Spectrogram")
        End If

        ' build domain, stimX and stimY
        cmbShowStimDomain.Items.Clear()
        cmbShowStimDomain.Items.Add("Time domain")
        cmbShowStimDomain.Items.Add("Frequency domain")
        cmbShowStimY.Items.Clear()
        cmbShowStimY.Items.Add("linear")
        cmbShowStimY.Items.Add("absolute")
        cmbShowStimY.Items.Add("log in dB(RMS)")
        cmbShowStimY.Items.Add("linear difference")
        cmbShowStimY.Items.Add("absolute difference")
        cmbShowStimY.Items.Add("abs. difference in dB(RMS)")
        cmbShowStimY.Items.Add("log in dB(RMS), normalized")
        If ( CBool(lF And 256) or CBool(lF And 512)) And Not CBool(lF And 128) Then
            ' specgram/spectrogram mode
            cmbShowStimX.Items.Clear()
            cmbShowStimX.Items.Add("window length: 64 samples")
            cmbShowStimX.Items.Add("window length: 128 samples")
            cmbShowStimX.Items.Add("window length: 256 samples")
            cmbShowStimX.Items.Add("window length: 512 samples")
            cmbShowStimX.Items.Add("window length: 1024 samples")
            cmbShowStimX.Items.Add("window length: 2048 samples")
            cmbShowStimX.Items.Add("window length: 4096 samples")
        Else
            If (lF And 1) = 0 Then
                ' time domain
                cmbShowStimX.Items.Clear()
                cmbShowStimX.Items.Add("samples")
                cmbShowStimX.Items.Add("time in s")
                cmbShowStimX.Items.Add("time in ms")
                cmbShowStimX.Items.Add("time in us")
            Else
                cmbShowStimX.Items.Clear()
                cmbShowStimX.Items.Add("linear, in bins")
                cmbShowStimX.Items.Add("linear, in Hz")
                cmbShowStimX.Items.Add("linear, in kHz")
                cmbShowStimX.Items.Add("not used")
                cmbShowStimX.Items.Add("log, in bins")
                cmbShowStimX.Items.Add("log, in Hz")
                cmbShowStimX.Items.Add("log, in kHz")
                cmbShowStimX.Items.Add("ERB scaled, in kHz")
            End If
        End If

        ' Set controls
        ' Scale X
        If ((lF \ 2) And 7) < cmbShowStimX.Items.Count Then
            cmbShowStimX.SelectedIndex = (lF \ 2) And 7
        Else
            cmbShowStimX.SelectedIndex = cmbShowStimX.Items.Count - 1
        End If
        ' Domain and scale Y
        If ( CBool(lF And 256) or  CBool(lF And 512)) And Not CBool(lF And 128) Then
            lF = lF And &HFFFFFFCE
            mlFlags = lF
            cmbShowStimDomain.SelectedIndex = 0
            cmbShowStimDomain.Enabled = False
            cmbShowStimY.SelectedIndex = 2
            cmbShowStimY.Enabled = False
        Else
            cmbShowStimDomain.Enabled = True
            cmbShowStimDomain.SelectedIndex = lF And 1
            cmbShowStimY.Enabled = True
            cmbShowStimY.SelectedIndex = (lF \ 16) And 7
        End If
        ' Plot mode
        If ((lF \ 256) And 7) < cmbMode.Items.Count Then
            cmbMode.SelectedIndex = (lF \ 256) And 7
        Else
            cmbMode.SelectedIndex = cmbMode.Items.Count - 1
        End If

    End Sub
    Private Sub cmbMode_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbMode.SelectedIndexChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            If ((mlFlags \ 256) And 7) <> cmbMode.SelectedIndex Then
                SetControls(cmbShowStimDomain.SelectedIndex + cmbShowStimX.SelectedIndex * 2 + cmbShowStimY.SelectedIndex * 16 + CInt(optMatrixMode.Checked) * -128 + cmbMode.SelectedIndex * 256)
                UpdateMatlabFlags()
            End If
        End If
    End Sub

    Private Sub cmbShowStimDomain_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbShowStimDomain.SelectedIndexChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            If (mlFlags And 1) <> cmbShowStimDomain.SelectedIndex Then
                SetControls(cmbShowStimDomain.SelectedIndex + cmbShowStimX.SelectedIndex * 2 + cmbShowStimY.SelectedIndex * 16 + CInt(optMatrixMode.Checked) * -128 + cmbMode.SelectedIndex * 256)
                UpdateMatlabFlags()
            End If
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        glShowStimulusFlags = CShort(CShort(CShort(CShort(cmbShowStimDomain.SelectedIndex And 1) + cmbShowStimX.SelectedIndex * 2) + cmbShowStimY.SelectedIndex * 16) + CInt(optMatrixMode.Checked) * -128) + cmbMode.SelectedIndex * 256

        If Len(gszShowStimulusParameter) > 0 Then
            STIM.ShowStimulusFlags = TStr(glShowStimulusFlags) & ",[" & gszShowStimulusAxes & "]," & gszShowStimulusParameter
        Else
            STIM.ShowStimulusFlags = TStr(glShowStimulusFlags) & ",[" & gszShowStimulusAxes & "]"
        End If
        gszShowStimulusParameter = txtParameter.Text
        gszShowStimulusAxes = txtAxes.Text
        gblnShowStimulus = True
        Me.Close()
    End Sub

    Private Sub frmShowStimulus_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Me.Icon = frmMain.Icon

        SetControls(glShowStimulusFlags)
        txtParameter.Text = gszShowStimulusParameter
        txtAxes.Text = gszShowStimulusAxes

        If CBool(glShowStimulusFlags And 128) Then
            optMatrixMode.Checked = True
        Else
            optVectorMode.Checked = True
        End If
        UpdateMatlabFlags()
        gblnShowStimulus = False
    End Sub

    Private Sub optMatrixMode_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optMatrixMode.CheckedChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            If DirectCast(eventSender, RadioButton).Checked Then
                If (mlFlags And 128) = 0 Then
                    SetControls(cmbShowStimDomain.SelectedIndex + cmbShowStimX.SelectedIndex * 2 + cmbShowStimY.SelectedIndex * 16 + CInt(optMatrixMode.Checked) * -128 + cmbMode.SelectedIndex * 256)
                    UpdateMatlabFlags()
                End If
            End If
        End If
    End Sub

    Private Sub optVectorMode_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optVectorMode.CheckedChanged
        If Me.IsInitializing = True Then
            Exit Sub
        Else
            If DirectCast(eventSender, RadioButton).Checked Then
                If (mlFlags And 128) = 128 Then
                    SetControls(cmbShowStimDomain.SelectedIndex + cmbShowStimX.SelectedIndex * 2 + cmbShowStimY.SelectedIndex * 16 + CInt(optMatrixMode.Checked) * -128 + cmbMode.SelectedIndex * 256)
                    UpdateMatlabFlags()
                End If
            End If
        End If
    End Sub

    Private Sub UpdateMatlabFlags()
        lblMatlabFlags.Text = "Matlab Flags: " & TStr(CShort(CShort(CShort(CShort(cmbShowStimDomain.SelectedIndex And 1) + cmbShowStimX.SelectedIndex * 2) + cmbShowStimY.SelectedIndex * 16) + CInt(optMatrixMode.Checked) * -128) + cmbMode.SelectedIndex * 256)
        lblPlotAs.Text = TStr(CShort(CInt(optMatrixMode.Checked) * -128) + cmbMode.SelectedIndex * 256)
        lblDomain.Text = TStr(CShort(cmbShowStimDomain.SelectedIndex And 1))
        lblScaleX.Text = TStr(CShort(cmbShowStimX.SelectedIndex * 2))
        lblScaleY.Text = TStr(CShort(cmbShowStimY.SelectedIndex * 16))
    End Sub

    Private Sub cmbShowStimX_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbShowStimX.SelectedIndexChanged
        UpdateMatlabFlags()
    End Sub

    Private Sub cmbShowStimY_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbShowStimY.SelectedIndexChanged
        UpdateMatlabFlags()
    End Sub
End Class