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
Friend Class PlothMParameterSet
	
	'local variable(s) to hold property value(s)
	Private mvarValid As Boolean 'local copy
	Private mvarAxes As String 'local copy
	Private mvarFlags As Integer 'local copy
	Private mvarOptionalParameters As String 'local copy
	Private mvarParameter As Integer 'local copy
	Private mvarRecChannel As String 'local copy
	Private mvarTitle As String 'local copy
	Private mvarFilter As String 'local copy
	Private mvarFlat As Boolean
	
	Public Function GetParameters(ByRef szRecStream As String) As String
        Dim szErr As String = ""
		Dim lRec As Integer
		
		With frmPlotData
			mvarFlags = CShort(CShort(CShort(CShort(.cmbShowStimDomain.SelectedIndex And 1) + .cmbShowStimX.SelectedIndex * 2) + .cmbShowStimY.SelectedIndex * 16) + CInt(.optMatrixMode.Checked) * -128) + .cmbMode.SelectedIndex * 256
			
			mvarOptionalParameters = .txtParameter.Text
			mvarAxes = .txtAxes.Text
			If Len(.txtFilter.Text) = 0 Then szErr = "Invalid filter rule." : GoTo SubError
			mvarFilter = .txtFilter.Text
			mvarParameter = .cmbParAxis.SelectedIndex
			
			If .txtRecChannel.Text = ":" Then
				szRecStream = "All"
            ElseIf IsNumeric((.txtRecChannel.Text)) Then
                lRec = CInt(Val(.txtRecChannel.Text) - 1)
                If lRec > GetUbound(gRecStream) Or lRec < 0 Then szErr = "Record channel not found in Settings/Variables." : GoTo SubError
                szRecStream = gRecStream(lRec)
			Else
				szRecStream = .txtRecChannel.Text
			End If
			mvarRecChannel = .txtRecChannel.Text
			
			mvarFlat = .ckbFlat.Checked And .ckbFlat.Enabled

SubError: 
			GetParameters = szErr
			Exit Function
		End With
	End Function
	
	Public Sub SetControls()
		
		' Build controls
		With frmPlotData
			' build mode combo
            If CBool(mvarFlags And 128) Then
                ' matrix mode
                .cmbMode.Items.Clear()
                .cmbMode.Items.Add("Color Plot") ' flat?
                .cmbMode.Items.Add("Waterfall")
                .cmbMode.Items.Add("Mesh") ' flat?
                .cmbMode.Items.Add("Stretched 2D Plot")
                .cmbMode.Items.Add("Surface") ' flat?
            Else
                ' vector mode
                .cmbMode.Items.Clear()
                .cmbMode.Items.Add("2D Plot")
                .cmbMode.Items.Add("Specgram")
				.cmbMode.Items.Add("Spectrogram")
            End If
			
			' build domain, stimX and stimY
			.cmbShowStimDomain.Items.Clear()
			.cmbShowStimDomain.Items.Add("Time domain")
			.cmbShowStimDomain.Items.Add("Frequency domain")
			.cmbShowStimY.Items.Clear()
			.cmbShowStimY.Items.Add("linear")
			.cmbShowStimY.Items.Add("absolute")
			.cmbShowStimY.Items.Add("log in dB(RMS)")
			.cmbShowStimY.Items.Add("linear difference")
			.cmbShowStimY.Items.Add("absolute difference")
			.cmbShowStimY.Items.Add("abs. difference in dB(RMS)")
			.cmbShowStimY.Items.Add("log in dB(RMS), normalized")
			If (CBool(mvarFlags And 256) or CBool(mvarFlags And 512)) And Not CBool(mvarFlags And 128) Then
				' specgram/spectrogram mode
				.cmbShowStimX.Items.Clear()
				.cmbShowStimX.Items.Add("window length: 64 samples")
				.cmbShowStimX.Items.Add("window length: 128 samples")
				.cmbShowStimX.Items.Add("window length: 256 samples")
				.cmbShowStimX.Items.Add("window length: 512 samples")
				.cmbShowStimX.Items.Add("window length: 1024 samples")
				.cmbShowStimX.Items.Add("window length: 2048 samples")
				.cmbShowStimX.Items.Add("window length: 4096 samples")
			Else
				If (mvarFlags And 1) = 0 Then
					' time domain
					.cmbShowStimX.Items.Clear()
					.cmbShowStimX.Items.Add("samples")
					.cmbShowStimX.Items.Add("time in s")
					.cmbShowStimX.Items.Add("time in ms")
					.cmbShowStimX.Items.Add("time in us")
				Else
					.cmbShowStimX.Items.Clear()
					.cmbShowStimX.Items.Add("linear, in bins")
					.cmbShowStimX.Items.Add("linear, in Hz")
					.cmbShowStimX.Items.Add("linear, in kHz")
					.cmbShowStimX.Items.Add("not used")
					.cmbShowStimX.Items.Add("log, in bins")
					.cmbShowStimX.Items.Add("log, in Hz")
					.cmbShowStimX.Items.Add("log, in kHz")
					.cmbShowStimX.Items.Add("ERB scaled, in kHz")
				End If
			End If
			
			' Set controls
			' Scale X
			If ((mvarFlags \ 2) And 7) < .cmbShowStimX.Items.Count Then
				.cmbShowStimX.SelectedIndex = (mvarFlags \ 2) And 7
			Else
				.cmbShowStimX.SelectedIndex = .cmbShowStimX.Items.Count - 1
			End If
			' Domain and scale Y
            If (CBool(mvarFlags And 256) or CBool(mvarFlags And 512)) And Not CBool(mvarFlags And 128) Then
                mvarFlags = mvarFlags And &HFFFFFFCE
                .cmbShowStimDomain.SelectedIndex = 0
                .cmbShowStimDomain.Enabled = False
                .cmbShowStimY.SelectedIndex = 2
                .cmbShowStimY.Enabled = False
            Else
                .cmbShowStimDomain.Enabled = True
                .cmbShowStimDomain.SelectedIndex = mvarFlags And 1
                .cmbShowStimY.Enabled = True
                .cmbShowStimY.SelectedIndex = (mvarFlags \ 16) And 7
            End If
			' Plot mode
			If ((mvarFlags \ 256) And 7) < .cmbMode.Items.Count Then
				.cmbMode.SelectedIndex = (mvarFlags \ 256) And 7
			Else
				.cmbMode.SelectedIndex = .cmbMode.Items.Count - 1
			End If
			
			' Set Domain of the Y axis:
			.cmbParAxis.Items.Clear()
			.cmbParAxis.Items.Add("Item #")
			.cmbParAxis.Items.Add("Azimuth")
			Select Case glExpType
				Case 0, 1, 2 ' MLS, Sweep, Cosine
					.cmbParAxis.Items.Add("Channel ID")
				Case 3 ' HRTF
					.cmbParAxis.Items.Add("Elevation")
			End Select
			.cmbParAxis.Items.Add("Index")
            .cmbParAxis.Items.Add("Cont. Elevation")
            .cmbParAxis.Items.Add("Lateral Angle")
            .cmbParAxis.Items.Add("Polar Angle")
			.cmbParAxis.SelectedIndex = mvarParameter
			
			.txtParameter.Text = mvarOptionalParameters
			.txtAxes.Text = mvarAxes
			
            If CBool(mvarFlags And 128) Then
                .optMatrixMode.Checked = True
				Select Case frmPlotData.cmbMode.SelectedIndex
					Case 0,2,4 'color plot, mesh, surface
						frmPlotData.ckbFlat.Enabled=True                
					Case Else
						frmPlotData.ckbFlat.Enabled=False
				End Select
            Else
                .optVectorMode.Checked = True
                .ckbFlat.Enabled = False
            End If
			
			.txtRecChannel.Text = mvarRecChannel
			.txtFilter.Text = mvarFilter
			
			.ckbFlat.Checked = mvarFlat

		End With
		
	End Sub
	
	
	
	Public Property Title() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.Title
			Title = mvarTitle
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.Title = 5
			mvarTitle = Value
		End Set
	End Property
	
	
	
	
	
	Public Property RecChannel() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.RecChannel
			RecChannel = mvarRecChannel
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.RecChannel = 5
			mvarRecChannel = Value
		End Set
	End Property
	
	
	
	
	
	Public Property Parameter() As Integer
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.Parameter
			Parameter = mvarParameter
		End Get
		Set(ByVal Value As Integer)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.Parameter = 5
			mvarParameter = Value
		End Set
	End Property
	
	
	
    'UPGRADE_NOTE: Filter was upgraded to Filter. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Public Property Filter() As String
        Get
            'used when retrieving value of a property, on the right side of an assignment.
            'Syntax: Debug.Print X.Parameter
            Filter = mvarFilter
        End Get
        Set(ByVal Value As String)
            'used when assigning a value to the property, on the left side of an assignment.
            'Syntax: X.Parameter = 5
            mvarFilter = Value
        End Set
    End Property
	
	
	
	Public Property OptionalParameters() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.OptionalParameters
			OptionalParameters = mvarOptionalParameters
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.OptionalParameters = 5
			mvarOptionalParameters = Value
		End Set
	End Property
	

	Public Property Flags() As Integer
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.Flags
			Flags = mvarFlags
		End Get
		Set(ByVal Value As Integer)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.Flags = 5
			mvarFlags = Value
		End Set
	End Property
	
	
	
	
	
	Public Property Axes() As String
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.Axes
			Axes = mvarAxes
		End Get
		Set(ByVal Value As String)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.Axes = 5
			mvarAxes = Value
		End Set
	End Property
	
	
	
	
	
	Public Property Valid() As Boolean
		Get
			'used when retrieving value of a property, on the right side of an assignment.
			'Syntax: Debug.Print X.Valid
			Valid = mvarValid
		End Get
		Set(ByVal Value As Boolean)
			'used when assigning a value to the property, on the left side of an assignment.
			'Syntax: X.Valid = 5
			mvarValid = Value
		End Set
	End Property
	

	Public Property Flat() As Boolean
		'shading flat?
		Get
			Flat = mvarFlat
		End Get
		Set(ByVal Value As Boolean)
			mvarFlat = Value
		End Set
	End Property


	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		mvarAxes = ""
		mvarFilter = ":"
		mvarFlags = 0
		mvarOptionalParameters = ""
		mvarParameter = 1
		mvarRecChannel = "1"
		mvarValid = True
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
End Class