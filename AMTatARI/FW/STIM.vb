Option Strict Off
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
Imports System.IO
'Imports System.Runtime.InteropServices
''' <summary>
''' Stimulus creation, connection to MATLAB and logging of data.
''' </summary>
''' <remarks><h3>Important Properties of STIM</h3>
'''
'''
'''<li>GenerationMode*: 0: genElectricalRIB; 1: genAcoustical; 2: genElectricalNIC; 3: genElectricalRIB2</li>
'''<li>LoggingMode*: 0:  don '''t log to disk (not recommended); 15: log everything to disk</li>
'''<li>DestinationDir*: root directory for disk access, work dir will be created here</li>
'''<li>WorkDir: working directory, all files are created here</li>
'''<li>ID*: name of experiment, work directory will begin with ID</li>
'''<li>Description: description of experiment, may contain blanks and special characters. Description will be encoded (UUE) and logged</li>
'''<li>FirstName: first name of subject</li>
'''<li>LastName: last name of subject</li>
'''<li>Caption: caption of the STIM-list in the parent application</li>
'''<li>MATLABServer*: name of the MATLAB-Server. Leave empty for local server. A nonlocal server can'''t use graphical functions as plot and figure.</li>
'''<li>ShowStimulusFlags: Flags which are passed to ShowStimulus.</li>
'''<li>SourceDir*: Fitting files are copied from this directory</li>
'''<li>UseMatlab*: Set false if you don'''t want to connect to the Matlab server. All Matlab functionality will be disabled.</li>
'''<li>CreateWorkDir*: set false if you don'''t want to create a new work directory. Caution: a new log file with a time stamp will be created, but the stimlog.csv will be overwritten!</li>
'''<br>*: required before Init()</br>
'''
'''<h3>Created directory structure</h3>
'''
'''  <br>Root</br>
'''  <br>|</br>
'''  <br>- source directory [SourceDir]</br>
'''    <br>|</br>
'''    <br>- fitting files</br>
'''  <br>...</br>
'''  <br>- destination directory [DestinationDir]</br>
'''    <br>|</br>
'''    <br>- working directory [work] (ID_YYYYMMDD_HHmmss)</br>
'''  <br>|</br>
'''      <br>- current fitting file left [fittL] (.fitt)</br>
'''      <br>- current fitting file right [fittR] (.fitt)</br>
'''      <br>- generated stimulation files (stimXXXX.EXT)</br>
'''      <br>- generated parameter file (stimXXXX.csv)</br>
'''      <br>- generated logfile [logfile] (ID_YYYYMMDD_HHmmss.csv)</br>
'''
'''<br>Auto naming of files:</br>
'''<li>YYYYMMDD: Year, month, day</li>
'''<li>HHmmss: hour, minute, second</li>
'''<li>XXXX: serial number, 4 digits</li>
'''<li>EXT: ".stim" in electricalRIB and ".wav" in acoustical mode</li></remarks>
Module STIM




    ''' <summary>
    ''' Parameters of a stimulus.
    ''' </summary>
    ''' <remarks>Additional parameters available in MATLAB/stimPar. Some them are set on connect, the other may be changed on request.</remarks>
    Public Structure STIMULUSPARAMETER
        ''' <summary>
        ''' Electrode, index to a specific frequency channel in freqPar() beginning from 1. Corresponds to the chosen channel in Settings/Signal.
        ''' </summary>
        ''' <remarks></remarks>
        Dim lElectrode As Integer
        ''' <summary>
        ''' Array with parameters of electrodes/acoustical channels. Corresponds to all defined channel in Settings/Signal.
        ''' </summary>
        ''' <remarks></remarks>
        Dim freqPar() As clsFREQUENCY
        ''' <summary>
        ''' Pulse Number.
        ''' </summary>
        ''' <remarks></remarks>
        Dim lPulseNr As Integer
        ''' <summary>
        ''' Pulse Period [samples]
        ''' </summary>
        ''' <remarks></remarks>
        Dim lPulsePeriod As Integer
        ''' <summary>
        ''' Temporal offset to shift a stimulus in time [samples]
        ''' </summary>
        ''' <remarks></remarks>
        Dim lOffset As Integer
        ''' <summary>
        ''' Time base [us] of all temporal parameter, reciprocal to lSamplingRate
        ''' </summary>
        ''' <remarks></remarks>
        Dim sTimeBase As Double
        ''' <summary>
        ''' Sampling rate of stimulus [Hz], reciprocal to sTimeBase
        ''' </summary>
        ''' <remarks></remarks>
        Dim lSamplingRate As Integer
        ''' <summary>
        ''' Resolution (quantization) of audio stimuli [bit]
        ''' </summary>
        ''' <remarks></remarks>
        Dim lResolution As Integer
        ''' <summary>
        ''' Stimulus length, not used yet in STIM.
        ''' </summary>
        ''' <remarks></remarks>
        Dim lLength As Integer
        ''' <summary>
        ''' Number of electrodes or frequency channels (array size of freqPar())
        ''' </summary>
        ''' <remarks></remarks>
        Dim lChNr As Integer
        ''' <summary>
        ''' File name of current fitting file
        ''' </summary>
        ''' <remarks></remarks>
        Dim szFittFile As String
        ''' <summary>
        ''' File name of current stimulation file
        ''' </summary>
        ''' <remarks></remarks>
        Dim szStimFile As String
        ''' <summary>
        ''' Electrical mode: type of implant (-1: none, 0: C40C, 1: C40P)
        ''' </summary>
        ''' <remarks></remarks>
        Dim iImpType As Implant.IMPLANTTYPE
        ''' <summary>
        ''' Electrical mode: description of implant
        ''' </summary>
        ''' <remarks></remarks>
        Dim szImpType As String
        ''' <summary>
        ''' Acoustical mode: Fade in [samples] of signal.
        ''' </summary>
        ''' <remarks></remarks>
        Dim lFadeIn As Integer
        ''' <summary>
        ''' Acoustical mode: Fade out [samples] of signal.
        ''' </summary>
        ''' <remarks></remarks>
        Dim lFadeOut As Integer
        ''' <summary>
        ''' Electrical mode: Fade in [samples] of signal.
        ''' </summary>
        ''' <remarks></remarks>
        Dim Range0 As Double
        Dim Range1 As Double
        Dim Range2 As Double
        Dim Range3 As Double

    End Structure

    ''' <summary>
    ''' Mode of creating stimuli.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum GENMODE
        ''' <summary>
        ''' Electrical mode using RIB (MED-EL). In MATLAB genElectricalRIB = 0
        ''' </summary>
        ''' <remarks></remarks>
        genElectricalRIB = 0
        ''' <summary>
        ''' Acoustical mode with Pd. In MATLAB genAcoustical = 1
        ''' </summary>
        ''' <remarks></remarks>
        genAcoustical = 1
        ''' <summary>
        ''' Electrical mode using NIC (Cochlear).
        ''' </summary>
        ''' <remarks></remarks>
        genElectricalNIC = 2
        ''' <summary>
        ''' Electrical mode using RIB2 (MED-EL).
        ''' </summary>
        ''' <remarks></remarks>
        genElectricalRIB2 = 3
        ''' <summary>
        ''' Electrical mode using RIB2 (MED-EL). Presentation is via Pd (vocoder).
        ''' </summary>
        ''' <remarks></remarks>
        genVocoder = 4
        ''' <summary>
        ''' Acoustical mode with Unity.
        ''' </summary>
        ''' <remarks></remarks>
        genAcousticalUnity = 5
    End Enum

    ''' <summary>
    ''' Level of data logging.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum LOGMODE
        ''' <summary>
        ''' No logging at all.
        ''' </summary>
        ''' <remarks></remarks>
        logNoLogging = 0
        ''' <summary>
        ''' Log to the stimlog.csv on Init, NewStimulus, MatlabStimulus, Assemble and Matlab.
        ''' </summary>
        ''' <remarks></remarks>
        logStimulusToFile = 1
        ''' <summary>
        ''' Log to the log list on Init, NewStimulus, MatlabStimulus and Assemble.
        ''' </summary>
        ''' <remarks></remarks>
        logStimulusToList = 2
        ''' <summary>
        ''' Log general information to the log list on Init, RegisterChannel and BackupLogFile.
        ''' </summary>
        ''' <remarks></remarks>
        logLogToList = 4
        ''' <summary>
        ''' Log general information to the logfile (ID_DATE_TIME.csv) on Init and RegisterChannel
        ''' </summary>
        ''' <remarks></remarks>
        logLogToFile = 8
        ''' <summary>
        ''' Summary of all logging modes.
        ''' </summary>
        ''' <remarks></remarks>
        logEverything = 15
    End Enum

    ' Constants from STIMPublic
    Public Const LOGEXTENSION As String = ".csv"
    Public Const STIMLOGFILE As String = "stimlog"
    Public Const STIMFILEPREFIX As String = "stim"

    ' property data
    Private mszSourceDir As String
    Private mszDestinationDir As String
    Private mszWorkDir As String
    Private mgenMode As GENMODE
    Private mlogMode As LOGMODE
    Private mszID As String
    Private mszDescription As String
    Private mszFirstName As String
    Private mszLastName As String
    Private mlStimCnt As Integer
    Private mblnShowStimulus As Boolean
    Private mszShowStimulusFlags As String
    Private mszMATLABServer As String
    Private mblnUseMATLAB As Boolean
    Private mblnCreateWorkDir As Boolean
    Private mszMATLABPath As String

    ' private data
    Private mszLogFile As String
    Private mobjMatlab As Object
    Private mstPar As STIMULUSPARAMETER
    Private mlChMin As Integer
    Private mszTempDir As String
    Private mszStimLogFile As String
    Private mszQuota As String
    Private mszSeparator As String



    ''' <summary>
    ''' Create/Change stimulus using MATLAB functions.
    ''' </summary>
    ''' <param name="szFunc">Name of the MATLAB function you want to call (case sensitive!)</param>
    ''' <param name="clsX"></param>
    ''' <param name="varPar">Comma-delimited list of variant values with parameters of called MATLAB function. Numeric, string or empty data types will be accepted. Strings without valid MATLAB quoting ('...') will be quoted. Any value containing the data type 'Empty' will be converted to an empty vector ([]).</param>
    ''' <returns>Zero-length if MATLAB function was executed without any errors. Contains the error message if any error occured.</returns>
    ''' <remarks>On MatlabStimulus the function szFunc will be executed in MATLAB.
    ''' <br>Passed parameters are: </br>
    '''<li>stimVec: Stimulus vector. Empty vector on the first call after NewStimulus, result of previous calls. Appending of stimulus parts can achieved calling successively .MatlabStimulus.</li>
    '''<li>stimPar: Stimulation parameters. Contains the structure STIMULUSPARAMETER, which is valid after .NewStimulus</li>
    '''<li>all parameters in varPar()</li>
    '''The MATLAB function must have the following header: [newstimVec, newstimPar] = szFunc(stimVec,stimPar,varPar...)</remarks>
    Public Function MatlabStimulus(ByVal szFunc As String, _
                                ByVal clsX() As ExpSuite.clsSTIMULUS, _
                                ByVal ParamArray varPar() As Object) As String
        Dim lY, lErr, lX, lParNr As Integer
        Dim szLogH, szCmd, szLogVal As String
        Dim szErr As String = ""
        Dim stEl() As clsSTIMULUS

        If Not mblnUseMATLAB Then Return "Matlab not in use."
        If IsNothing(clsX) Then Return "MatlabStimulus: the parameter clsSTIMULUS is empty"
        On Error Resume Next

        szCmd = "[stimVec,stimPar]=" & szFunc & "(stimVec,stimPar"
        szLogH = "MatlabStimulus"
        szLogVal = szFunc
        StimToList("MatlabStimulus: " & szFunc)

        lX = clsX.Length - 1
        ReDim stEl(lX)
        szLogH = szLogH & ",STIMULUS Array"
        szLogVal = szLogVal & "," & TStr(lX)
        szCmd = szCmd & ",["
        StimToList("Parameter #" & TStr(lParNr) & " is a STIMULUS array with " & TStr(lX) & " elements.")
        For lY = 0 To lX
            stEl(lY) = New clsSTIMULUS
            stEl(lY) = clsX(lY)
            Dim szX As String = TStr((stEl(lY).lElectrode)) & " " & _
                    TStr((stEl(lY).sAmp)) & " " & _
                    TStr((stEl(lY).lRange)) & " " & _
                    TStr((stEl(lY).lPhDur)) & " " & _
                    TStr((stEl(lY).lPulsePeriod)) & " " & _
                    TStr((stEl(lY).lModifier))
            StimToList("Element #" & TStr(lY) & ":" & szX)
            szCmd = szCmd & szX & ";"
        Next
        szCmd = szCmd & "]"

        ' parse parameter array
        lParNr = 0
        If UBound(varPar) >= 0 Then
            For Each varX As Object In varPar
                lParNr = lParNr + 1
                Select Case TypeName(varX)

                    Case "String()" 'array
                        For lZ As Integer = 0 To (varX.Length - 1)
                            If lZ > 0 Then lParNr = lParNr + 1
                            If IsNumeric(varX(lZ)) Then 'numeric
                                szLogH = szLogH & ",Float"
                                szLogVal = szLogVal & "," & varX(lZ)
                                szCmd = szCmd & "," & varX(lZ)
                                StimToList("Parameter #" & TStr(lParNr) & ":" & varX(lZ))
                            Else 'string
                                szLogH = szLogH & ",String"
                                Dim szX As String = CType(varX(lZ), String)
                                If Left(szX, 1) <> "'" Then ' not matlab quoted string
                                    If Left(szX, 1) <> "[" Then ' not a matrix
                                        szX = Replace(szX, "'", "''") ' encode all "'"
                                        szX = "'" + szX + "'" ' quota the string
                                    End If
                                End If
                                szLogVal = szLogVal & "," & Quota(szX)
                                szCmd = szCmd & "," & szX
                                StimToList("Parameter #" & TStr(lParNr) & ":" & szX)
                            End If
                        Next


                    Case "Byte", "Integer", "Long", "Short", "Decimal", "SByte", "UInteger", "ULong", "UShort"
                        szLogH = szLogH & ",Int"
                        szLogVal = szLogVal & "," & TStr(CLng(varX))
                        szCmd = szCmd & "," & TStr(CLng(varX))
                        StimToList("Parameter #" & TStr(lParNr) & ":" & TStr(CLng(varX)))
                    Case "Single", "Double"
                        szLogH = szLogH & ",Float"
                        szLogVal = szLogVal & "," & TStr(CDbl(varX))
                        szCmd = szCmd & "," & TStr(CDbl(varX))
                        StimToList("Parameter #" & TStr(lParNr) & ":" & TStr(CDbl(varX)))
                    Case "String"
                        szLogH = szLogH & ",String"
                        Dim szX As String = CType(varX, String)
                        If Left(szX, 1) <> "'" Then ' not matlab quoted string
                            If Left(szX, 1) <> "[" Then ' not a matrix
                                szX = Replace(szX, "'", "''") ' encode all "'"
                                szX = "'" + szX + "'" ' quota the string
                            End If
                        End If
                        szLogVal = szLogVal & "," & Quota(szX)
                        szCmd = szCmd & "," & szX
                        StimToList("Parameter #" & TStr(lParNr) & ":" & szX)
                    Case "Empty"
                        szLogH = szLogH & ",Empty"
                        szLogVal = szLogVal & ",[]"
                        szCmd = szCmd & ",[]"
                        StimToList("Parameter #" & TStr(lParNr) & " is empty")
                    Case "clsSTIMULUS"
                        ' TO DO: das geht hier wahrscheinlich nicht...
                        szLogH = szLogH & ",STIMULUS"
                        Dim stimX As clsSTIMULUS = CType(varX, clsSTIMULUS)
                        Dim szX As String = TStr(stimX.lElectrode) & " " & _
                                TStr(stimX.sAmp) & " " & _
                                TStr(stimX.lRange) & " " & _
                                TStr(stimX.lPhDur) & " " & _
                                TStr(stimX.lPulsePeriod) & " " & _
                                TStr(stimX.lModifier)
                        szLogVal = szLogVal & "," & szX
                        StimToList("Parameter #" & TStr(lParNr) & ":" & szX)
                        szCmd = szCmd & ",[" & szX & "]"
                    Case "DBNull"
                        StimToList("Parameter #" & TStr(lParNr) & "will be ignored")
                    Case Else
                        szLogH = szLogH & "," & TypeName(varX)
                        szErr = "Unknown data type in parameter stream"
                        StimToList("Parameter #" & TStr(lParNr) & " is unknown: " & TypeName(varX))
                End Select
            Next varX
        End If
        szCmd = szCmd & ");"
        ' log
        If (mlogMode And LOGMODE.logStimulusToFile) <> 0 Then
            Dim filLog As StreamWriter = File.AppendText(mszStimLogFile)
            filLog.WriteLine(szLogH)
            filLog.WriteLine(szLogVal)
            filLog.Close()
        End If
        ' check errors
        If Len(szErr) <> 0 Then Return szErr
        ' execute matlab command
        If mobjMatlab Is Nothing Then Err.Raise(vbObjectError + 2, "MatlabStimulus", "MATLAB not started")
        szErr = mobjMatlab.Execute(szCmd)
        If Len(szErr) <> 0 Then
            Return "MatlabStimulus, Function: " & szFunc & vbCrLf & szErr
        Else
            StimToList("Executing successful.")
            Return ""
        End If

    End Function


    ''' <summary>
    ''' Get the duration of a wav file, without MATLAB.
    ''' </summary>
    ''' <param name="FileName">Name of the wav file to analyze</param>
    ''' <param name="samplerate">Samplerate of the wav file to analyze</param>
    ''' <param name="bitspersample">Bits per sample of the wav file to analyze</param>
    ''' <param name="channels">Channels of the wav file to analyze</param>
    ''' <param name="Filesize">File size (bytes) of the wav file to analyze</param>
    ''' <returns>Duration of wav file in ms (rounded).</returns>
    ''' <remarks>MATLAB is not required.</remarks>
    Public Function GetWavDuration(ByVal FileName As String, Optional ByRef samplerate As Integer = 0, Optional ByRef bitspersample As Integer = 0, Optional ByRef channels As Integer = 0, Optional ByRef Filesize As Integer = 0) As Long

        Dim rifftag(4), WAVtag(4), FMTtag(4) As Char
        '        Dim reader As Object = New BinaryReader(File.Open(FileName, FileMode.Open))
        Dim reader As Object = New BinaryReader(File.OpenRead(FileName))
        'Retry:
        'Try
        'reader = New BinaryReader(File.OpenRead(FileName))
        'Catch
        '    GoTo Retry
        'End Try

        rifftag = reader.ReadChars(4)
        Filesize = reader.ReadInt32
        WAVtag = reader.ReadChars(4)
        FMTtag = reader.ReadChars(4)
        Dim FMTsize As Long = reader.ReadInt32
        Dim compresstype As Integer = reader.ReadInt16
        channels = reader.ReadInt16
        samplerate = reader.ReadInt32
        Dim bytespersec As Long = reader.ReadInt32
        Dim bytespersample As Integer = reader.ReadInt16
        bitspersample = reader.ReadInt16

        Dim wavlength As Double = (Filesize / bytespersec) * 1000 ' return in milliseconds

        reader.Close()

        Return Math.Round(wavlength)

    End Function

    ''' <summary>
    ''' Create/Change stimulus using MATLAB functions.
    ''' </summary>
    ''' <param name="szFunc">Name of the MATLAB function you want to call (case sensitive!)</param>
    ''' <param name="varPar">Comma-delimited list of variant values with parameters of called MATLAB function. Numeric, string or empty data types will be accepted. Strings without valid MATLAB quoting ('...') will be quoted. Any value containing the data type 'Empty' will be converted to an empty vector ([]).</param>
    ''' <returns>Zero-length if MATLAB function was executed without any errors. Contains the error message if any error occured.</returns>
    ''' <remarks>On MatlabStimulus the function szFunc will be executed in MATLAB.
    ''' <br>Passed parameters are: </br>
    '''<li>stimVec: Stimulus vector. Empty vector on the first call after NewStimulus, result of previous calls. Appending of stimulus parts can achieved calling successively .MatlabStimulus.</li>
    '''<li>stimPar: Stimulation parameters. Contains the structure STIMULUSPARAMETER, which is valid after .NewStimulus</li>
    '''<li>all parameters in varPar()</li>
    '''The MATLAB function must have the following header: [newstimVec, newstimPar] = szFunc(stimVec,stimPar,varPar...)</remarks>
    Public Function MatlabStimulus(ByVal szFunc As String, _
                                  ByVal ParamArray varPar() As Object) As String
        Dim lY, lErr, lX, lParNr As Integer
        Dim szLogH, szCmd, szLogVal As String
        Dim szErr As String = ""
        Dim stEl() As clsSTIMULUS

        If Not mblnUseMATLAB Then Return "Matlab not in use."
        On Error Resume Next

        szCmd = "[stimVec,stimPar]=" & szFunc & "(stimVec,stimPar"
        szLogH = "MatlabStimulus"
        szLogVal = szFunc
        StimToList("MatlabStimulus: " & szFunc)
        ' parse parameter array
        lParNr = 0
        If UBound(varPar) >= 0 Then
            For Each varX As Object In varPar
                lParNr = lParNr + 1
                Select Case TypeName(varX)
                    Case "String()" 'array
                        For lZ As Integer = 0 To (varX.Length - 1)
                            If lZ > 0 Then lParNr = lParNr + 1
                            If IsNumeric(varX(lZ)) Then 'numeric
                                szLogH = szLogH & ",Float"
                                szLogVal = szLogVal & "," & varX(lZ)
                                szCmd = szCmd & "," & varX(lZ)
                                StimToList("Parameter #" & TStr(lParNr) & ":" & varX(lZ))
                            Else 'string
                                szLogH = szLogH & ",String"
                                Dim szX As String = CType(varX(lZ), String)
                                If Left(szX, 1) <> "'" Then ' not matlab quoted string
                                    If Left(szX, 1) <> "[" Then ' not a matrix
                                        szX = Replace(szX, "'", "''") ' encode all "'"
                                        szX = "'" + szX + "'" ' quota the string
                                    End If
                                End If
                                szLogVal = szLogVal & "," & Quota(szX)
                                szCmd = szCmd & "," & szX
                                StimToList("Parameter #" & TStr(lParNr) & ":" & szX)
                            End If
                        Next
                    Case "Byte", "Integer", "Long", "Short", "Decimal", "SByte", "UInteger", "ULong", "UShort"
                        szLogH = szLogH & ",Int"
                        szLogVal = szLogVal & "," & TStr(CLng(varX))
                        szCmd = szCmd & "," & TStr(CLng(varX))
                        StimToList("Parameter #" & TStr(lParNr) & ":" & TStr(CLng(varX)))
                    Case "Single", "Double"
                        szLogH = szLogH & ",Float"
                        szLogVal = szLogVal & "," & TStr(CDbl(varX))
                        szCmd = szCmd & "," & TStr(CDbl(varX))
                        StimToList("Parameter #" & TStr(lParNr) & ":" & TStr(CDbl(varX)))
                    Case "String"
                        szLogH = szLogH & ",String"
                        Dim szX As String = CType(varX, String)
                        If Left(szX, 1) <> "'" Then ' not matlab quoted string
                            If Left(szX, 1) <> "[" Then ' not a matrix
                                szX = Replace(szX, "'", "''") ' encode all "'"
                                szX = "'" + szX + "'" ' quota the string
                            End If
                        End If
                        szLogVal = szLogVal & "," & Quota(szX)
                        szCmd = szCmd & "," & szX
                        StimToList("Parameter #" & TStr(lParNr) & ":" & szX)
                    Case "Empty", "Nothing"
                        szLogH = szLogH & ",Empty"
                        szLogVal = szLogVal & ",[]"
                        szCmd = szCmd & ",[]"
                        StimToList("Parameter #" & TStr(lParNr) & " is empty")
                    Case "clsSTIMULUS"
                        ' TO DO: das geht hier wahrscheinlich nicht...
                        szLogH = szLogH & ",STIMULUS"
                        Dim stimX As clsSTIMULUS = CType(varX, clsSTIMULUS)
                        Dim szX As String = TStr(stimX.lElectrode) & " " & _
                                TStr(stimX.sAmp) & " " & _
                                TStr(stimX.lRange) & " " & _
                                TStr(stimX.lPhDur) & " " & _
                                TStr(stimX.lPulsePeriod) & " " & _
                                TStr(stimX.lModifier)
                        szLogVal = szLogVal & "," & szX
                        StimToList("Parameter #" & TStr(lParNr) & ":" & szX)
                        szCmd = szCmd & ",[" & szX & "]"
                    Case "DBNull"
                        StimToList("Parameter #" & TStr(lParNr) & "will be ignored")
                    Case Else
                        szLogH = szLogH & "," & TypeName(varX)
                        szErr = "Unknown data type in parameter stream"
                        StimToList("Parameter #" & TStr(lParNr) & " is unknown: " & TypeName(varX))
                End Select
            Next varX
        End If
        szCmd = szCmd & ");"
        ' log
        If (mlogMode And LOGMODE.logStimulusToFile) <> 0 Then
            Dim filLog As StreamWriter = File.AppendText(mszStimLogFile)
            filLog.WriteLine(szLogH)
            filLog.WriteLine(szLogVal)
            filLog.Close()
        End If
        ' check errors
        If Len(szErr) <> 0 Then MatlabStimulus = szErr : Exit Function
        ' execute matlab command
        If mobjMatlab Is Nothing Then Err.Raise(vbObjectError + 2, "MatlabStimulus", "MATLAB not started")
        szErr = mobjMatlab.Execute(szCmd)
        If Len(szErr) <> 0 Then
            MatlabStimulus = "MatlabStimulus, Function: " & szFunc & vbCrLf & szErr
        Else
            MatlabStimulus = ""
            StimToList("Executing successful.")
        End If

    End Function

    ''' <summary>
    ''' Check for stimulation file.
    ''' </summary>
    ''' <param name="szFile">File name of the stimulation file, without any path. Extension will be added if not found.</param>
    ''' <returns>TRUE if the stimulation file can be found.</returns>
    ''' <remarks></remarks>
    Public Function CheckStimulationFile(ByRef szFile As String) As Boolean
        Dim szTemp, szFitt As String
        Dim iX As Integer
        Dim szArray As String()

        szFile = AppendExtension(szFile)
        CheckStimulationFile = Len(Dir(mszWorkDir & "\" & szFile)) > 0
        Select Case mgenMode
            Case GENMODE.genElectricalRIB2
                ' check consistency between fitting file loaded within stm file and fitting file set in experimental settings
                If CheckStimulationFile Then
                    On Error GoTo Error_FileNotOpen
                    Dim file As System.IO.StreamReader = _
                            My.Computer.FileSystem.OpenTextFileReader(mszWorkDir & "\" & szFile, System.Text.Encoding.GetEncoding(1252))

                    szTemp = file.ReadLine
                    If Not IsNothing(szTemp) Then
                        iX = InStr(1, szTemp, "Map File ")
                        If iX = 0 Then                  ' no map file information found, invalid stm-file
                            Return False
                        End If
                        szFitt = Mid(szTemp, iX + 9)    ' file name of fitting file, inluding full path and limiting " "
                        szFitt = szFitt.Replace("""", "")
                        szArray = szFitt.Split("\")
                        If (szArray(szArray.Length - 1) <> gszFittFileLeft) And (szArray(szArray.Length - 1) <> gszFittFileRight) Then
                            MsgBox("Fitting file(s) loaded within the stimulation file(s) not consistent with fitting file(s) set in the experimental settings!", MsgBoxStyle.Critical, "Check Stimulation File")
                            Return False
                        End If
                        file.Close()
                        Return CheckStimulationFile
                    Else : Return False
                    End If
                Else
                    Return CheckStimulationFile
                End If

            Case Else
                Return CheckStimulationFile
        End Select

Error_FileNotOpen:
        Return False

    End Function


    ' ------------------------------------------------------
    ' Methods
    ' ------------------------------------------------------

    ''' <summary>
    ''' Initialization of STIM.
    ''' </summary>
    ''' <param name="lSamplingRate">Sampling Rate of the audio signal.</param>
    ''' <param name="lResolution">Resolution of the audio signal.</param>
    ''' <returns>Zero-length if no error occured.</returns>
    ''' <remarks><b>Init is called on connect from framework. Don't call it again.</b>
    '''Activities:
    '''<li>Create a MATLAB object</li>
    '''<li>create the directory structure</li>
    '''<li>logging of some parameters, depending on the LoggingMode property.</li>
    '''
    '''
    '''Set before calling:
    '''<li> SourceDir to the directory of fitting files</li>
    '''<li>DestinationDir: to the directory where STIM will write</li>
    '''<li>ID: to the ID of your experiment</li>
    '''<li>GenerationMode: to the mode you want to create all stimuli</li>
    '''<li>LoggingMode: to the level of logging (only logEverything support now)</li>
    '''<li>Description: to the description of your experiment, this string will be logged</li>
    '''<li>UseMatlab: If UseMATLAB property is TRUE, MATLAB object will be created.</li>
    '''<li>CreateWorkDir: If TRUE, working directory will be creating according to the directory structure.</li>
    '''
    '''Usage:
    '''<li>Call it just once. If you want to call it repetitive you must execute Finish() inbetween, STIM will stuck otherwise.</li>
    '''<li>Init allows two optional parameters: Sampling rate and Resolution. If given, stimPar is created in Matlab immediatly after the start of Matlab</li></remarks>
    Public Function Init(Optional ByVal lSamplingRate As Integer = 0, Optional ByVal lResolution As Integer = 0) As String
        Dim szErr As String

        ' clear old objects
        mobjMatlab = Nothing

        ' create source directory
        If mszSourceDir = "" Then mszSourceDir = My.Application.Info.DirectoryPath
        LogToList("SourceDir: " & mszSourceDir)
        ' create log extension
        If Len(mszDestinationDir) = 0 Then
            mszWorkDir = mszSourceDir
        Else
            If LCase(mszDestinationDir) = "%temp%" Then
                mszWorkDir = Mid(mszTempDir, 1, Len(mszTempDir) - 1)
            Else
                mszWorkDir = mszDestinationDir
            End If
        End If

        ' create working directory
        Dim vTime As Date = System.DateTime.Now
        Dim szWordName As String = mszID & "_" & vTime.ToString("yyyyMMdd_HHmmss")
        If mblnCreateWorkDir Then
            mszWorkDir = mszWorkDir & IO.Path.DirectorySeparatorChar & szWordName
            Try
                Directory.CreateDirectory(mszWorkDir)
            Catch X As System.IO.DirectoryNotFoundException
                Return "Work directory could not be found." & vbCrLf & vbCrLf & X.ToString
            Catch X As Exception
                Return "Couldn't create the work directory " & mszWorkDir & "." & vbCrLf & vbCrLf & X.ToString
            End Try
            '  Else
            '    mszWorkDir = mszSourceDir
        End If
        LogToList("Work dir: " & mszWorkDir)
        ' create log file
        If (mlogMode And LOGMODE.logLogToFile) <> 0 Then
            mszLogFile = mszWorkDir & IO.Path.DirectorySeparatorChar & szWordName & LOGEXTENSION
            Dim filLog As StreamWriter
            Try
                Console.WriteLine(mszLogFile)
                If Not System.IO.Directory.Exists(mszWorkDir) Then
                    If MsgBox("Work Directory " & mszWorkDir & " is not existing. Do you want to create the folder?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Work Dir not existing") = MsgBoxResult.No Then Return "Work directory could not be found." & vbCrLf & vbCrLf & mszWorkDir
                    Directory.CreateDirectory(mszWorkDir)
                End If
                filLog = File.CreateText(mszLogFile)

            Catch X As System.IO.DirectoryNotFoundException
                Return "Work directory could not be found." & vbCrLf & vbCrLf & X.ToString
            Catch X As Exception
                Return "Couldn't create log file in the work directory " & mszWorkDir & "." & vbCrLf & vbCrLf & X.ToString
            End Try
            filLog.WriteLine("**********,Init")
            filLog.WriteLine("Start date," & vTime.ToString("dd.MM.yyyy"))
            filLog.WriteLine("Start time," & vTime.ToString("HH:mm:ss"))
            filLog.WriteLine("Computer name," & My.Computer.Name.ToString)
            filLog.WriteLine("Source directory," & Quota(mszSourceDir))
            filLog.WriteLine("Work directory," & Quota(mszWorkDir))
            filLog.WriteLine("Experiment ID," & Quota(mszID))
            filLog.WriteLine("Stimulation mode," & TStr(mgenMode))
            filLog.WriteLine("Logging mode," & TStr(mlogMode))
            filLog.WriteLine("Description," & Quota(CSVEncode(mszDescription)))
            filLog.WriteLine()
            filLog.WriteLine()
            filLog.Close()
        End If
        ' create a MATLAB object
        If mgenMode = GENMODE.genElectricalNIC Then mblnUseMATLAB = True ' auto activate MATLAB for NIC
        If mblnUseMATLAB Then
            LogToList("Creating MATLAB object: please wait...")
            szErr = ""
            Try
                mobjMatlab = CreateObject("Matlab.Application", mszMATLABServer)
            Catch X As System.IO.FileNotFoundException
                Return "MATLAB Object could not be found." & vbCrLf & vbCrLf & X.ToString
            Catch X As Exception
                Return "MATLAB-Server \\" & mszMATLABServer & " is not available." & vbCrLf & vbCrLf & X.ToString
            End Try
            If Len(szErr) <> 0 Then Return szErr
            If mobjMatlab Is Nothing Then Return "Matlab not connected"
            LogToList("Matlab started")
            szErr = mobjMatlab.Execute("cd '" & mszWorkDir & "'")
            If Len(szErr) <> 0 Then Return szErr
            ' clear search paths
            szErr = mobjMatlab.execute("matlabpath(pathdef);")
            If InStr(szErr, "???") > 0 Then Return szErr
            Dim szMatlab As String
            ' add application path to the search path
            If Mid(mszMATLABPath, 1, 2) = "\\" Or InStr(1, mszMATLABPath, ":") > 0 Then
                szMatlab = mszMATLABPath ' absolute path?
            Else
                'relative path - MATLAB folder in the project directory?
                Dim szX As String = ""
                If Mid(mszMATLABPath, 1, 1) <> IO.Path.DirectorySeparatorChar Then szX = IO.Path.DirectorySeparatorChar
                szMatlab = My.Application.Info.DirectoryPath & szX & mszMATLABPath
                Dim szDebug As String
                szDebug = "\bin"    ' MATLAB folder in \bin?
                If Strings.Right(My.Application.Info.DirectoryPath, Len(szDebug)) = szDebug Then _
                    szMatlab = Strings.Left(My.Application.Info.DirectoryPath, _
                                Len(My.Application.Info.DirectoryPath) - Len(szDebug)) & szX & mszMATLABPath
                szDebug = "\obj\Release" ' MATLAB folder in \obj\Release?
                If Strings.Right(My.Application.Info.DirectoryPath, Len(szDebug)) = szDebug Then _
                    szMatlab = Strings.Left(My.Application.Info.DirectoryPath, _
                                Len(My.Application.Info.DirectoryPath) - Len(szDebug)) & szX & mszMATLABPath
                szDebug = "\obj\Debug" ' MATLAB folder in \obj\Debug?
                If Strings.Right(My.Application.Info.DirectoryPath, Len(szDebug)) = szDebug Then _
                    szMatlab = Strings.Left(My.Application.Info.DirectoryPath, _
                                Len(My.Application.Info.DirectoryPath) - Len(szDebug)) & szX & mszMATLABPath
            End If
            LogToList("Adding path to MATLAB: " & szMatlab)
            szErr = mobjMatlab.Execute("addpath('" & szMatlab & "');")
            If Len(szErr) > 0 Then Return szErr
            mszMATLABPath = szMatlab
        End If
        ' create stimulus log file
        If (mlogMode And LOGMODE.logStimulusToFile) <> 0 Then
            mszStimLogFile = mszWorkDir & IO.Path.DirectorySeparatorChar & STIMLOGFILE & LOGEXTENSION
            Dim filLog As StreamWriter
            Try
                filLog = File.CreateText(mszStimLogFile)
            Catch X As Exception
                Return X.ToString
            End Try
            filLog.WriteLine("**********, Stimulation Logfile")
            filLog.WriteLine("Start date," & vTime.ToString("dd.MM.yyyy"))
            filLog.WriteLine("Start time," & vTime.ToString("HH:mm:ss"))
            filLog.WriteLine("Work directory," & Quota(mszWorkDir))
            filLog.WriteLine()
            filLog.WriteLine()
            filLog.Close()
        End If

        Dim szPath As String = "", szFullPath As String
        Select Case mgenMode
            Case GENMODE.genAcoustical, GENMODE.genVocoder, GENMODE.genAcousticalUnity
                LogToList("Mode: Acoustical")
            Case GENMODE.genElectricalRIB
                LogToList("Mode: Electrical RIB") ' Add RIB path
                szPath = gszRIBPath
            Case GENMODE.genElectricalNIC
                LogToList("Mode: Electrical NIC") ' Add NIC path
                szPath = gszNICPath
            Case GENMODE.genElectricalRIB2
                LogToList("Mode: Electrical RIB2") ' Add RIB2 path
                szPath = gszRIB2Path
        End Select

        If Len(szPath) <> 0 Then

            ' add application path to the search path
            If Mid(szPath, 1, 2) = "\\" Or InStr(1, szPath, ":") > 0 Then
                szFullPath = szPath ' absolute path?
            Else
                'relative path - MATLAB folder in the project directory?
                Dim szX As String = ""
                If Mid(szPath, 1, 1) <> IO.Path.DirectorySeparatorChar Then szX = IO.Path.DirectorySeparatorChar
                szFullPath = My.Application.Info.DirectoryPath & szX & szPath
                Dim szDebug As String
                szDebug = "\bin"    ' MATLAB folder in \bin?
                If Strings.Left(szPath, 3) <> "..\" Then
                    If Strings.Right(My.Application.Info.DirectoryPath, Len(szDebug)) = szDebug Then _
                        szFullPath = Strings.Left(My.Application.Info.DirectoryPath, _
                                    Len(My.Application.Info.DirectoryPath) - Len(szDebug)) & szX & szPath
                    szDebug = "\obj\Release" ' MATLAB folder in \obj\Release?
                    If Strings.Right(My.Application.Info.DirectoryPath, Len(szDebug)) = szDebug Then _
                        szFullPath = Strings.Left(My.Application.Info.DirectoryPath, _
                                    Len(My.Application.Info.DirectoryPath) - Len(szDebug)) & szX & szPath
                    szDebug = "\obj\Debug" ' MATLAB folder in \obj\Debug?
                    If Strings.Right(My.Application.Info.DirectoryPath, Len(szDebug)) = szDebug Then _
                        szFullPath = Strings.Left(My.Application.Info.DirectoryPath, _
                                    Len(My.Application.Info.DirectoryPath) - Len(szDebug)) & szX & szPath
                End If
            End If

            LogToList("Adding " & szPath & " path to MATLAB: " & szFullPath)
            szErr = mobjMatlab.Execute("addpath('" & szFullPath & "');")
            If Len(szErr) > 0 Then Return szErr
        End If

        LogToList("Logging Mode: " & TStr(mlogMode))
        ' init data
        mlStimCnt = -1
        mlChMin = 10000
        ' create simple stimPar structure
        'If mgenMode <> GENMODE.genAcoustical Then lSamplingRate = -1 : lResolution = -1
        'If mblnUseMATLAB And lSamplingRate <> 0 And lResolution <> 0 Then
        szErr = ResetStimPar(lSamplingRate, lResolution)
        If Len(szErr) <> 0 Then Return szErr
        'End If

        Return ""

    End Function

    ''' <summary>
    ''' Reset stimPar (e.g. when loading a new mat file afterwards).
    ''' </summary>
    ''' <param name="lSamplingRate">Sampling Rate of the audio signal.</param>
    ''' <param name="lResolution">Resolution of the audio signal.</param>
    ''' <returns>Zero-length if no error occured.</returns>
    Public Function ResetStimPar(ByVal lSamplingRate As Integer, ByVal lResolution As Integer) As String

        Select Case mgenMode
            Case GENMODE.genAcoustical, GENMODE.genAcousticalUnity, GENMODE.genVocoder
                ' acoustic
            Case Else
                ' electric
                lSamplingRate = -1 : lResolution = -1
        End Select

        If mblnUseMATLAB And lSamplingRate <> 0 And lResolution <> 0 Then '0 = undefined (do not change), -1 = electric (update), else: acoustic & defined (update)

            Dim szCmd As String = "stimPar=struct('SamplingRate'," & TStr(lSamplingRate) & _
                   ",'Resolution'," & TStr(lResolution) & _
                   ",'GenMode'," & TStr(mgenMode) & ");" & _
                   "stimPar.Application=struct('Name','" & My.Application.Info.Title & _
                    "','Version','" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & _
                    "','FWVersion','" & TStr(FW_MAJOR) & "." & TStr(FW_MINOR) & "." & TStr(FW_REVISION) & "');"

            Dim szErr As String = mobjMatlab.Execute(szCmd)
            If Len(szErr) <> 0 Then Return szErr

        End If

        Return ""
    End Function
    ''' <summary>
    ''' Registers a channel (left, right or multichannel).
    ''' </summary>
    ''' <param name="st">Stimulus parameters.</param>
    ''' <returns>Empty for no errors, error string otherwise. Additional changes in st:
    '''<li>.sTimeBase calculated using .lSamplingRate (only in acoustical mode)</li>
    '''<li>.sTimeBase, .szFirstName, .szLastName read from the fitting file (only in electricalRIB mode)</li>
    '''<li>.lSamplingRate calculated using .sTimeBase (only in electricalRIB mode)</li>
    '''<li>.szImpType and .iImpType determined from fitting file (only in electricalRIB mode)</li>
    ''' </returns>
    ''' <remarks>
    ''' Register a channel (=ear, side: left=0, right=1, multichannel. Not acoustical (frequency) channel!).
    '''<br>Usage: </br>
    '''<li>Call it after Init() for each channel you have.</li>
    ''' <br><br><b>RegisterChannel is called by framework on connect. Don'''t call it again.</b></br></br>
    ''' <br>st.lChNr must be valid on calling RegisterChannel:</br>
    ''' <li>In acoustical mode, set st.lSamplingRate [Hz] and st.lResolution [bit]. Then, the .sTimeBase [us] will be calculated from .lSamplingRate.</li>
    ''' <li>In electricalRIB mode, set .szFittFile to the name of a valid fitting file.  From this file some fields of st will be set (e.g. first and last name and time base).</li>
    ''' <br>The field .lResolution will be ignored in this mode.</br>
    '''
    '''<br>Set before calling RegisterChannel:</br>
    '''<li>.lChNr to a valid audio channel.</li>
    '''<li>.lSamplingRate (only in acoustical mode)</li>
    '''<li>all items of freqPar()</li>
    '''<li>.szFittFile to a valid fitting file (only in electricalRIB mode)</li>
    '''<li>default values for electrode, pulsenr, pulseperiod, offset</li>
    '''
    '''<br><br>Activities: </br></br>
    '''<li>Logging</li>
    '''<li>Determining the number of audio channels for auto naming mechanism</li>
    '''<li>Copy fitting file to the working directory</li>
    '''<li>Update of STIMULUSPARAMETER</li></remarks>
    Public Function RegisterChannel(ByRef st As STIMULUSPARAMETER) As String
        Dim szErr As String
        Dim freqX As clsFREQUENCY 'classreference
        freqX = New clsFREQUENCY 'create instance - memory will be assigned
        Dim szX As String
        Dim lLen As Integer

        On Error Resume Next
        ' get the name of the channel
        Select Case st.lChNr
            Case 0
                szX = "0, Left"
            Case 1
                szX = "1, Right"
            Case Else
                szX = TStr(st.lChNr) & ", - Ch"
        End Select
        LogToList("Register Channel " & szX)

        ' open log file
        Dim filLog As StreamWriter = Nothing
        If (mlogMode And LOGMODE.logLogToFile) <> 0 Then
            filLog = File.AppendText(mszLogFile)
            filLog.WriteLine("**********, Register channel")
            filLog.WriteLine("Channel," & szX)
        End If
        Select Case mgenMode
            Case GENMODE.genAcoustical ' acoustical mode
                mszFirstName = "Acoustic"
                mszLastName = "Acoustic"
                st.iImpType = Implant.IMPLANTTYPE.imptInvalid
                st.szImpType = "Acoustic"
                If st.lSamplingRate = 0 Then
                    szErr = "Set sampling rate to a valid number"
                    GoTo SubError
                End If
                st.sTimeBase = 1000000 / CSng(st.lSamplingRate)
                If (mlogMode And LOGMODE.logLogToFile) <> 0 Then
                    If Not IsNothing(st.freqPar) Then
                        filLog.WriteLine("Amp,Range,PhDur,SPLOffset,CenterFreq,Bandwidth,THR,MCL")
                        For lX As Integer = 0 To st.freqPar.Length - 1
                            With st.freqPar(lX)
                                szX = TStr(.sAmp) & "," & TStr(.lRange) & "," & TStr(.lPhDur) & "," & TStr(.sSPLOffset) & "," & TStr(.sCenterFreq) & "," & TStr(.sBandwidth) & TStr(.sTHR) & "," & TStr(.sMCL)
                            End With
                            filLog.WriteLine(szX)
                        Next
                    End If
                    filLog.WriteLine(szX)
                    filLog.WriteLine("Electrode," & TStr(st.lElectrode))
                    filLog.WriteLine("PulseNr," & TStr(st.lPulseNr))
                    filLog.WriteLine("PulsePeriod," & TStr(st.lPulsePeriod))
                    filLog.WriteLine("Offset," & TStr(st.lOffset))
                    filLog.WriteLine("Fade In," & TStr(st.lFadeIn))
                    filLog.WriteLine("Fade Out," & TStr(st.lFadeOut))
                    filLog.WriteLine("SamplingRate," & TStr(st.lSamplingRate))
                    filLog.WriteLine("TimeBase," & TStr(st.sTimeBase))
                    filLog.WriteLine()
                    filLog.WriteLine()
                    filLog.Close()
                End If
            Case GENMODE.genElectricalRIB
                ' fitting file required
                LogToList("Fitting file: " & st.szFittFile)
                If Len(st.szFittFile) = 0 Then _
                    szErr = "Fitting file name is required" : GoTo SubError
                ' seek for the fitting file
                Dim szFittingFileDirectory As String = GetFittingPath(st.szFittFile)
                If szFittingFileDirectory = "" Then szErr = "Fitting File not found!" : GoTo SubError

                'remove possible "\" at ending
                If Right(szFittingFileDirectory, 1) = "\" Then szFittingFileDirectory = Strings.Left(szFittingFileDirectory, Len(szFittingFileDirectory) - Len("\"))

                ' copy fitting file to the work directory
                If Dir(mszWorkDir & IO.Path.DirectorySeparatorChar & st.szFittFile) = "" Then _
                                    File.Copy(szFittingFileDirectory & "\" & st.szFittFile, _
                                              mszWorkDir & IO.Path.DirectorySeparatorChar & st.szFittFile) ' read fitting file
                ' read fitting file
                Dim F4FT As New Implant(Implant.IMPLANTTYPE.imptInvalid)


                szErr = F4FT.OpenFile(mszWorkDir & IO.Path.DirectorySeparatorChar & st.szFittFile)
                If szErr <> "" Then GoTo SubError
                If F4FT.DeviceTypeRequired <> GENMODE.genElectricalRIB Then szErr = "Invalid implant type" : GoTo suberror
                mszFirstName = F4FT.FirstName
                mszLastName = F4FT.LastName
                st.iImpType = F4FT.ImpType
                st.szImpType = F4FT.ImpTypeString
                st.sTimeBase = F4FT.TimeBase

                F4FT = Nothing
                If st.sTimeBase = 0 Then szErr = "Set time base to a non-zero value." : GoTo suberror
                st.lSamplingRate = CInt(Math.Round(1000000 / st.sTimeBase))
                LogToList("First name: " & mszFirstName)
                LogToList("Last name: " & mszLastName)
                LogToList("Implant type: " & st.szImpType)
                If (mlogMode And LOGMODE.logLogToFile) <> 0 Then
                    filLog.WriteLine("Fitting File," & st.szFittFile)
                    filLog.WriteLine("First Name," & Quota(mszFirstName))
                    filLog.WriteLine("Last Name," & Quota(mszLastName))
                    filLog.WriteLine("Implant type," & Quota(st.szImpType))
                    If Not IsNothing(st.freqPar) Then
                        filLog.WriteLine("Amp,Range,PhDur,SPLOffset,CenterFreq,Bandwidth,THR,MCL")
                        For lX As Integer = 0 To st.freqPar.Length - 1
                            With st.freqPar(lX)
                                szX = TStr(.sAmp) & "," & TStr(.lRange) & "," & _
                                      TStr(.lPhDur) & "," & TStr(.sSPLOffset) & "," & _
                                      TStr(.sCenterFreq) & "," & TStr(.sBandwidth) & "," & _
                                      TStr(.sTHR) & "," & TStr(.sMCL)
                            End With
                            filLog.WriteLine(szX)
                        Next
                    End If
                    filLog.WriteLine("Electrode," & TStr(st.lElectrode))
                    filLog.WriteLine("PulseNr," & TStr(st.lPulseNr))
                    filLog.WriteLine("PulsePeriod," & TStr(st.lPulsePeriod))
                    filLog.WriteLine("Offset," & TStr(st.lOffset))
                    filLog.WriteLine("TimeBase," & TStr(st.sTimeBase))
                    filLog.WriteLine()
                    filLog.WriteLine()
                    filLog.Close()
                End If

            Case GENMODE.genVocoder ' adapted Version of GENMODE.RIB, calls freqPar additionally
                ' fitting file required
                LogToList("Fitting file: " & st.szFittFile)
                If Len(st.szFittFile) = 0 Then _
                    szErr = "Fitting file name is required" : GoTo SubError
                ' seek for the fitting file
                Dim szFittingFileDirectory As String = GetFittingPath(st.szFittFile)
                If szFittingFileDirectory = "" Then szErr = "Fitting File not found!" : GoTo SubError

                'remove possible "\" at ending
                If Right(szFittingFileDirectory, 1) = "\" Then szFittingFileDirectory = Strings.Left(szFittingFileDirectory, Len(szFittingFileDirectory) - Len("\"))

                ' copy fitting file to the work directory
                If Dir(mszWorkDir & IO.Path.DirectorySeparatorChar & st.szFittFile) = "" Then _
                                    File.Copy(szFittingFileDirectory & "\" & st.szFittFile, _
                                              mszWorkDir & IO.Path.DirectorySeparatorChar & st.szFittFile) ' read fitting file
                ' read fitting file
                Dim F4FT As New Implant(Implant.IMPLANTTYPE.imptInvalid)
                szErr = F4FT.OpenFile(mszWorkDir & IO.Path.DirectorySeparatorChar & st.szFittFile)
                If szErr <> "" Then GoTo SubError
                If F4FT.DeviceTypeRequired <> GENMODE.genElectricalRIB2 Then szErr = "Invalid implant type" : GoTo suberror
                mszFirstName = F4FT.FirstName
                mszLastName = F4FT.LastName
                ' fill in the stimulus structure
                st.iImpType = F4FT.ImpType
                st.szImpType = F4FT.ImpTypeString
                st.sTimeBase = F4FT.TimeBase
                st.lPulsePeriod = F4FT.PulsePeriod

                'Select Case st.lChNr
                '   Case 0
                'st.freqPar = gfreqParL
                '   Case 1
                'st.freqPar = gfreqParR
                'End Select


                F4FT = Nothing
                If st.sTimeBase = 0 Then szErr = "Set time base to a non-zero value." : GoTo suberror
                st.lSamplingRate = CInt(Math.Round(1000000 / st.sTimeBase))

                ' log the data
                LogToList("First name: " & mszFirstName)
                LogToList("Last name: " & mszLastName)
                LogToList("Implant type: " & st.szImpType)
                If (mlogMode And LOGMODE.logLogToFile) <> 0 Then
                    filLog.WriteLine("Fitting File," & st.szFittFile)
                    filLog.WriteLine("First Name," & Quota(mszFirstName))
                    filLog.WriteLine("Last Name," & Quota(mszLastName))
                    filLog.WriteLine("Implant type," & Quota(st.szImpType))
                    If Not IsNothing(st.freqPar) Then
                        filLog.WriteLine("Amp,Range,PhDur,SPLOffset,CenterFreq,Bandwidth,THR,MCL")

                        'gfreqParL = gfreqParR


                        For lX As Integer = 0 To st.freqPar.Length - 1
                            With st.freqPar(lX)
                                szX = TStr(.sAmp) & "," & TStr(.lRange) & "," & _
                                      TStr(.lPhDur) & "," & TStr(.sSPLOffset) & "," & _
                                      TStr(.sCenterFreq) & "," & TStr(.sBandwidth) & "," & _
                                      TStr(.sTHR) & "," & TStr(.sMCL)
                            End With
                            filLog.WriteLine(szX)
                        Next
                    End If
                    filLog.WriteLine("Electrode," & TStr(st.lElectrode))
                    filLog.WriteLine("PulseNr," & TStr(st.lPulseNr))
                    filLog.WriteLine("PulsePeriod," & TStr(st.lPulsePeriod))
                    filLog.WriteLine("Offset," & TStr(st.lOffset))
                    filLog.WriteLine("TimeBase," & TStr(st.sTimeBase))
                    filLog.WriteLine()
                    filLog.WriteLine()
                    filLog.Close()
                End If


            Case GENMODE.genElectricalRIB2 ', GENMODE.genVocoder ' electrical mode - RIB2
                ' fitting file required
                LogToList("Fitting file: " & st.szFittFile)
                If Len(st.szFittFile) = 0 Then _
                    szErr = "Fitting file name is required" : GoTo SubError
                ' seek for the fitting file
                Dim szFittingFileDirectory As String = GetFittingPath(st.szFittFile)
                If szFittingFileDirectory = "" Then szErr = "Fitting File not found!" : GoTo SubError

                'remove possible "\" at ending
                If Right(szFittingFileDirectory, 1) = "\" Then szFittingFileDirectory = Strings.Left(szFittingFileDirectory, Len(szFittingFileDirectory) - Len("\"))

                ' copy fitting file to the work directory
                If Dir(mszWorkDir & IO.Path.DirectorySeparatorChar & st.szFittFile) = "" Then _
                                    File.Copy(szFittingFileDirectory & "\" & st.szFittFile, _
                                              mszWorkDir & IO.Path.DirectorySeparatorChar & st.szFittFile) ' read fitting file

                ' read fitting file
                Dim F4FT As New Implant(Implant.IMPLANTTYPE.imptInvalid)
                szErr = F4FT.OpenFile(mszWorkDir & IO.Path.DirectorySeparatorChar & st.szFittFile)
                If szErr <> "" Then GoTo SubError
                If F4FT.DeviceTypeRequired <> GENMODE.genElectricalRIB2 Then szErr = "Invalid implant type" : GoTo suberror
                mszFirstName = F4FT.FirstName
                mszLastName = F4FT.LastName
                ' fill in the stimulus structure
                st.iImpType = F4FT.ImpType
                st.szImpType = F4FT.ImpTypeString
                st.sTimeBase = F4FT.TimeBase
                st.lPulsePeriod = F4FT.PulsePeriod
                F4FT = Nothing
                If st.sTimeBase = 0 Then szErr = "Set time base to a non-zero value." : GoTo suberror
                st.lSamplingRate = CInt(Math.Round(1000000 / st.sTimeBase))

                ' log the data
                LogToList("First name: " & mszFirstName)
                LogToList("Last name: " & mszLastName)
                LogToList("Implant type: " & st.szImpType)
                If (mlogMode And LOGMODE.logLogToFile) <> 0 Then
                    filLog.WriteLine("Fitting File," & st.szFittFile)
                    filLog.WriteLine("First Name," & Quota(mszFirstName))
                    filLog.WriteLine("Last Name," & Quota(mszLastName))
                    filLog.WriteLine("Implant type," & Quota(st.szImpType))
                    If Not IsNothing(st.freqPar) Then
                        filLog.WriteLine("Amp,Range,PhDur,SPLOffset,CenterFreq,Bandwidth,THR,MCL")
                        For lX As Integer = 0 To st.freqPar.Length - 1
                            With st.freqPar(lX)
                                szX = TStr(.sAmp) & "," & TStr(.lRange) & "," & _
                                      TStr(.lPhDur) & "," & TStr(.sSPLOffset) & "," & _
                                      TStr(.sCenterFreq) & "," & TStr(.sBandwidth) & "," & _
                                      TStr(.sTHR) & "," & TStr(.sMCL)
                            End With
                            filLog.WriteLine(szX)
                        Next
                    End If
                    filLog.WriteLine("Electrode," & TStr(st.lElectrode))
                    filLog.WriteLine("PulseNr," & TStr(st.lPulseNr))
                    filLog.WriteLine("PulsePeriod," & TStr(st.lPulsePeriod))
                    filLog.WriteLine("Offset," & TStr(st.lOffset))
                    filLog.WriteLine("TimeBase," & TStr(st.sTimeBase))
                    filLog.WriteLine()
                    filLog.WriteLine()
                    filLog.Close()
                End If

            Case GENMODE.genElectricalNIC ' electrical mode - NIC
                ' fitting file required
                LogToList("Fitting file: " & st.szFittFile)
                If Len(st.szFittFile) = 0 Then szErr = "Fitting file name is required" : GoTo suberror

                ' seek for the fitting file
                Dim szFittingFileDirectory As String = GetFittingPath(st.szFittFile)
                If szFittingFileDirectory = "" Then szErr = "Fitting File not found!" : GoTo SubError

                'remove possible "\" at ending
                If Right(szFittingFileDirectory, 1) = "\" Then szFittingFileDirectory = Strings.Left(szFittingFileDirectory, Len(szFittingFileDirectory) - Len("\"))

                ' copy fitting file to the work directory
                If Dir(mszWorkDir & IO.Path.DirectorySeparatorChar & st.szFittFile) = "" Then _
                                    File.Copy(szFittingFileDirectory & "\" & st.szFittFile, _
                                              mszWorkDir & IO.Path.DirectorySeparatorChar & st.szFittFile) ' read fitting file
                ' read fitting file
                Dim F4FT As New Implant(Implant.IMPLANTTYPE.imptInvalid)
                szErr = F4FT.OpenFile(mszWorkDir & IO.Path.DirectorySeparatorChar & st.szFittFile)
                If szErr <> "" Then GoTo SubError
                If F4FT.DeviceTypeRequired <> GENMODE.genElectricalNIC Then szErr = "Invalid implant type" : GoTo suberror
                mszFirstName = F4FT.FirstName
                mszLastName = F4FT.LastName
                ' load .mat template to MATLAB
                Dim szFitt As String = "fitting{" & TStr(st.lChNr + 1) & "}"
                szErr = mobjMatlab.execute(szFitt & "=load('NIC_" & F4FT.ImpTypeString & ".mat');")
                If Len(szErr) > 0 Then GoTo suberror
                ' fill in the stimulus structure
                st.iImpType = F4FT.ImpType
                st.szImpType = F4FT.ImpTypeString
                st.sTimeBase = F4FT.TimeBase
                If st.sTimeBase = 0 Then szErr = "Set time base to a non-zero value." : GoTo suberror
                st.lSamplingRate = CInt(Math.Round(1000000 / st.sTimeBase, 0))
                st.lPulsePeriod = F4FT.PulsePeriod
                ReDim st.freqPar(F4FT.ChannelsCount - 1)
                For lX As Integer = 0 To F4FT.ChannelsCount - 1
                    st.freqPar(lX) = New clsFREQUENCY
                    st.freqPar(lX).lRange = F4FT.Channel(lX).lRange
                    st.freqPar(lX).lPhDur = F4FT.Channel(lX).lPhDur
                    st.freqPar(lX).sTHR = F4FT.Channel(lX).lTHR
                    st.freqPar(lX).sMCL = F4FT.Channel(lX).lMCL
                Next
                ' overwrite the generic map with current fitting data
                Dim szRange As String = szFitt & ".map.power_gains=["
                Dim lPhDurMax As Integer = 0
                Dim szTHR As String = szFitt & ".map.threshold_levels=["
                Dim szMCL As String = szFitt & ".map.comfort_levels=["
                Dim szEl As String = szFitt & ".map.electrodes=["
                For lX As Integer = F4FT.ChannelsCount - 1 To 0 Step -1
                    szRange = szRange & TStr(F4FT.Channel(lX).lRange) & " "
                    If F4FT.Channel(lX).lPhDur > lPhDurMax Then lPhDurMax = F4FT.Channel(lX).lPhDur
                    szTHR = szTHR & TStr(F4FT.Channel(lX).lTHR) & " "
                    szMCL = szMCL & TStr(F4FT.Channel(lX).lMCL) & " "
                    szEl = szEl & TStr(lX) & " "
                Next
                'szErr = mobjMatlab.Execute(szRange & "];") : If Len(szErr) <> 0 Then GoTo SubError
                szErr = mobjMatlab.Execute(szFitt & ".map.phase_width=" & TStr(lPhDurMax) & ";") : If Len(szErr) <> 0 Then GoTo SubError
                szErr = mobjMatlab.Execute(szTHR & "]';") : If Len(szErr) <> 0 Then GoTo SubError
                szErr = mobjMatlab.Execute(szMCL & "]';") : If Len(szErr) <> 0 Then GoTo SubError
                szErr = mobjMatlab.Execute(szEl & "]';") : If Len(szErr) <> 0 Then GoTo SubError
                If Len(F4FT.ChannelOrder) > 0 Then _
                    szErr = mobjMatlab.Execute(szFitt & ".map.channel_order=[" & F4FT.ChannelOrder & "]';") : If Len(szErr) <> 0 Then GoTo SubError
                szErr = mobjMatlab.execute(szFitt & ".map.period=" & TStr(F4FT.PulsePeriod * F4FT.TimeBase) & ";") : If Len(szErr) <> 0 Then GoTo SubError
                ' log the data
                LogToList("First name: " & mszFirstName)
                LogToList("Last name: " & mszLastName)
                LogToList("Implant type: " & st.szImpType)
                If (mlogMode And LOGMODE.logLogToFile) <> 0 Then
                    filLog.WriteLine("Fitting File," & st.szFittFile)
                    filLog.WriteLine("First Name," & Quota(mszFirstName))
                    filLog.WriteLine("Last Name," & Quota(mszLastName))
                    filLog.WriteLine("Implant type," & Quota(st.szImpType))
                    If Not IsNothing(st.freqPar) Then
                        filLog.WriteLine("Amp,Range,PhDur,SPLOffset,CenterFreq,Bandwidth,THR,MCL")
                        For lX As Integer = 0 To st.freqPar.Length - 1
                            With st.freqPar(lX)
                                szX = TStr(.sAmp) & "," & TStr(.lRange) & "," & _
                                        TStr(.lPhDur) & "," & TStr(.sSPLOffset) & "," & _
                                        TStr(.sCenterFreq) & "," & TStr(.sBandwidth) & "," & _
                                        TStr(.sTHR) & "," & TStr(.sMCL)
                            End With
                            filLog.WriteLine(szX)
                        Next
                    End If
                    filLog.WriteLine("Electrode," & TStr(st.lElectrode))
                    filLog.WriteLine("PulseNr," & TStr(st.lPulseNr))
                    filLog.WriteLine("PulsePeriod," & TStr(st.lPulsePeriod))
                    filLog.WriteLine("Offset," & TStr(st.lOffset))
                    filLog.WriteLine("TimeBase," & TStr(st.sTimeBase))
                    filLog.WriteLine()
                    filLog.WriteLine()
                    filLog.Close()
                End If
                ' call NIC_Register to add stuff to fitting(ear)
                szErr = mobjMatlab.execute(szFitt & "=NIC_Register(" & szFitt & "," & TStr(st.lChNr + 1) & ");")
                If Len(szErr) > 0 Then GoTo suberror
                ' save the whole fitting() matrix to .mat fitting
                szErr = mobjMatlab.execute("save('" & _
                                    mszWorkDir & IO.Path.DirectorySeparatorChar & _
                                    IO.Path.GetFileNameWithoutExtension(st.szFittFile) & ".mat','fitting');")
                If Len(szErr) > 0 Then GoTo SubError

            Case GENMODE.genAcousticalUnity ' acoustical mode
                mszFirstName = "Acoustic"
                mszLastName = "Acoustic"
                st.iImpType = Implant.IMPLANTTYPE.imptInvalid
                st.szImpType = "Acoustic"
                If st.lSamplingRate = 0 Then
                    szErr = "Set sampling rate to a valid number"
                    GoTo SubError
                End If
                st.sTimeBase = 1000000 / CSng(st.lSamplingRate)
                If (mlogMode And LOGMODE.logLogToFile) <> 0 Then
                    If Not IsNothing(st.freqPar) Then
                        filLog.WriteLine("Amp,Range,PhDur,SPLOffset,CenterFreq,Bandwidth,THR,MCL")
                        For lX As Integer = 0 To st.freqPar.Length - 1
                            With st.freqPar(lX)
                                szX = TStr(.sAmp) & "," & TStr(.lRange) & "," & TStr(.lPhDur) & "," & TStr(.sSPLOffset) & "," & TStr(.sCenterFreq) & "," & TStr(.sBandwidth) & TStr(.sTHR) & "," & TStr(.sMCL)
                            End With
                            filLog.WriteLine(szX)
                        Next
                    End If
                    filLog.WriteLine(szX)
                    filLog.WriteLine("Electrode," & TStr(st.lElectrode))
                    filLog.WriteLine("PulseNr," & TStr(st.lPulseNr))
                    filLog.WriteLine("PulsePeriod," & TStr(st.lPulsePeriod))
                    filLog.WriteLine("Offset," & TStr(st.lOffset))
                    filLog.WriteLine("Fade In," & TStr(st.lFadeIn))
                    filLog.WriteLine("Fade Out," & TStr(st.lFadeOut))
                    filLog.WriteLine("SamplingRate," & TStr(st.lSamplingRate))
                    filLog.WriteLine("TimeBase," & TStr(st.sTimeBase))
                    filLog.WriteLine()
                    filLog.WriteLine()
                    filLog.Close()
                End If
        End Select

        If (mlogMode And LOGMODE.logLogToFile) <> 0 Then filLog.Close()

        ' save the first channel number
        If st.lChNr < mlChMin Then mlChMin = st.lChNr

        Return "" ' no errors

SubError:
        If (mlogMode And LOGMODE.logLogToFile) <> 0 Then filLog.Close()
        Return "RegisterChannel: " & szErr

    End Function

    Private Function GetFittingPath(ByVal szFittingFileName As String) As String

        Dim szFittingFileDirectory As String = ""
        Dim szX As String
        Dim szFitPath As String = ""

        Select Case mgenMode
            Case GENMODE.genElectricalRIB
                szFitPath = gszRIBPath
            Case GENMODE.genElectricalNIC
                szFitPath = gszNICPath
            Case GENMODE.genElectricalRIB2, GENMODE.genVocoder
                szFitPath = gszRIB2Path
        End Select

        'check all folders:

        'absolute path?
        If Mid(szFitPath, 1, 2) = "\\" Or InStr(1, szFitPath, ":") > 0 Then
            szFittingFileDirectory = szFitPath
            If Dir(szFittingFileDirectory & IO.Path.DirectorySeparatorChar & szFittingFileName) <> "" Then
                Return szFittingFileDirectory
            End If
        Else 'NOT absolute path
            'Fitting File In [application] \ [RIB/RIB2/NIC] folder?
            If Mid(szFitPath, 1, 1) = "\" Then szX = "" Else szX = "\"
            szFittingFileDirectory = My.Application.Info.DirectoryPath & szX & szFitPath ' relative path
            If Dir(szFittingFileDirectory & IO.Path.DirectorySeparatorChar & szFittingFileName) <> "" Then
                Return szFittingFileDirectory
            End If

            'Fitting File In [application]-[bin/obj*] \ [RIB/RIB2/NIC] folder?
            If Strings.Right(My.Application.Info.DirectoryPath, Len("\bin")) = "\bin" Then szFittingFileDirectory = Strings.Left(My.Application.Info.DirectoryPath, Len(My.Application.Info.DirectoryPath) - Len("\bin"))
            If Strings.Right(My.Application.Info.DirectoryPath, Len("\obj\Debug")) = "\obj\Debug" Then szFittingFileDirectory = Strings.Left(My.Application.Info.DirectoryPath, Len(My.Application.Info.DirectoryPath) - Len("\obj\Debug"))
            If Strings.Right(My.Application.Info.DirectoryPath, Len("\obj\Release")) = "\obj\Release" Then szFittingFileDirectory = Strings.Left(My.Application.Info.DirectoryPath, Len(My.Application.Info.DirectoryPath) - Len("\obj\Release"))
            szFittingFileDirectory = szFittingFileDirectory & "\" & szFitPath

            If Dir(szFittingFileDirectory & IO.Path.DirectorySeparatorChar & szFittingFileName) <> "" Then
                Return szFittingFileDirectory
            End If
        End If

        'Fitting File In [application] \ [Matlab] Folder? (old)
        If Dir(mszSourceDir & IO.Path.DirectorySeparatorChar & szFittingFileName) <> "" Then
            Return mszSourceDir
        End If

        'nothing found...
        Return ""

    End Function


    ''' <summary>
    ''' Append correct extension to the stimulation file name.
    ''' </summary>
    ''' <param name="szFileName">Original File Name without extension.</param>
    ''' <returns>File name with extension.</returns>
    ''' <remarks>Appends the correct extension to the stimulation file name:
    '''<li>.wav in acoustical mode</li>
    '''<li>.stim in electrical RIB mode</li></remarks>
    Public Function AppendExtension(ByVal szFileName As String) As String
        Dim szExt As String = ""
        Dim szFile As String

        ' get extension for the stimulation file
        Select Case mgenMode
            Case GENMODE.genAcoustical, GENMODE.genVocoder, GENMODE.genAcousticalUnity
                szExt = STIMFILEEXT_ACOUSTIC
            Case GENMODE.genElectricalRIB
                szExt = STIMFILEEXT_RIB
            Case GENMODE.genElectricalNIC
                szExt = STIMFILEEXT_NIC
            Case GENMODE.genElectricalRIB2
                szExt = STIMFILEEXT_RIB2
        End Select

        szFile = szFileName
        If Right(RTrim(szFile), Len(szExt)) <> szExt Then
            szFile = szFile & szExt
        End If
        Return RTrim(szFile)

    End Function

    ''' <summary>
    ''' Start a new stimulus. The stimulus array/vector will be cleared.
    ''' </summary>
    ''' <param name="stNew">Use the variable set by RegisterChannel(). Clear .szStimFile to get an automatic generated file name in format stimXXXX_YY.ext (XXXX:stimulus index, YY:channel, ext: valid extension)</param>
    ''' <returns>Zero-length string if no errors occured.</returns>
    ''' <remarks></remarks>
    Public Function NewStimulus(ByRef stNew As STIMULUSPARAMETER) As String
        Dim filTmp As Object
        Dim szExt, szCmd As String
        Dim lX, lLen As Integer
        Dim szErr As String
        Dim varX As Object

        On Error Resume Next

        Dim szRange, szAmp, szPhDur As String
        Dim szCF, szSPL, szBW As String
        Dim szTHR, szMCL As String
        With stNew
            ' generate stimulation file name or append extension if needed
            If Len(.szStimFile) = 0 Then
                ' increase stimulus number if the new stimulus is the first channel
                If .lChNr = mlChMin Then mlStimCnt = mlStimCnt + 1
                .szStimFile = STIMFILEPREFIX & mlStimCnt.ToString("0000") & "_" & .lChNr.ToString("00")
            End If
            .szStimFile = AppendExtension(.szStimFile)

            ' log to stimulus file
            If (mlogMode And LOGMODE.logStimulusToFile) <> 0 Then
                Dim filLog As StreamWriter = File.AppendText(mszStimLogFile)
                If GetUbound(mstPar.freqPar) >= .lElectrode - 1 And .lElectrode <> 0 Then
                    filLog.WriteLine("New,Channel,Amp,Range,El,PhDur,PulseNr,PulsePer,Offset")
                    filLog.WriteLine(System.DateTime.Now.ToString("HH:mm:ss") & "," & TStr(.lChNr) & "," & TStr(.freqPar(.lElectrode - 1).sAmp) & "," & TStr(.freqPar(.lElectrode - 1).lRange) & "," & TStr(.lElectrode) & "," & TStr(.freqPar(.lElectrode - 1).lPhDur) & "," & TStr(.lPulseNr) & "," & TStr(.lPulsePeriod) & "," & TStr(.lOffset))
                Else
                    filLog.WriteLine("New,Channel,Amp,Range,El,PhDur,PulseNr,PulsePer,Offset,Fade In,Fade Out")
                    filLog.WriteLine(System.DateTime.Now.ToString("HH:mm:ss") & "," & TStr(.lChNr) & ",-,-," & TStr(.lElectrode) & ",-," & TStr(.lPulseNr) & "," & TStr(.lPulsePeriod) & "," & TStr(.lOffset) & "," & TStr(.lFadeIn) & "," & TStr(.lFadeOut))
                End If
                filLog.Close()
            End If
            ' log to list
            LogToList("NewStimulus, filename:" & .szStimFile)
            StimToList("Channel: " & TStr(.lChNr))
            StimToList("Electrode: " & TStr(.lElectrode))
            If GetUbound(mstPar.freqPar) >= .lElectrode - 1 And .lElectrode <> 0 Then
                StimToList("Amp: " & TStr(.freqPar(.lElectrode - 1).sAmp))
                StimToList("Range: " & TStr(.freqPar(.lElectrode - 1).lRange))
                StimToList("PhDur: " & TStr(.freqPar(.lElectrode - 1).lPhDur))
            End If
            StimToList("PulseNr: " & TStr(.lPulseNr))
            StimToList("PulsePeriod: " & TStr(.lPulsePeriod))
            StimToList("Offset: " & TStr(.lOffset))

            ' init data
            If mblnUseMATLAB Then
                If mobjMatlab Is Nothing Then Err.Raise(vbObjectError + 2, "NewStimulus", "MATLAB not started")
                szCmd = "stimPar=struct('Channel', " & TStr(.lChNr) & _
                                        ",'Electrode'," & TStr(.lElectrode) & _
                                        ",'PulseNr'," & TStr(.lPulseNr) & _
                                        ",'PulsePeriod'," & TStr(.lPulsePeriod) & _
                                        ",'Offset'," & TStr(.lOffset) & _
                                        ",'TimeBase'," & TStr(.sTimeBase) & _
                                        ",'SamplingRate'," & TStr(.lSamplingRate) & _
                                        ",'Resolution'," & TStr(.lResolution) & _
                                        ",'FadeIn'," & TStr(.lFadeIn) & _
                                        ",'FadeOut'," & TStr(.lFadeOut) & _
                                        ",'Length',0" & _
                                        ",'FittFileName','" & .szFittFile & "'" & _
                                        ",'StimFileName','" & .szStimFile & "'" & _
                                        ",'GenMode'," & TStr(mgenMode) & _
                                        ",'Device','" & .szImpType & "');" & _
                                        "stimPar.Application=struct('Name','" & My.Application.Info.Title & _
                                        "','Version','" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & _
                                        "','FWVersion','" & TStr(FW_MAJOR) & "." & TStr(FW_MINOR) & "." & TStr(FW_REVISION) & "');"
                szErr = mobjMatlab.Execute(szCmd)
                If Len(szErr) <> 0 Then GoTo SubError
                lLen = GetUbound(.freqPar)
                Dim lPhDurMax As Integer = 0
                If lLen > -1 Then
                    szAmp = "stimPar.freqPar.Amp=["
                    szRange = "stimPar.freqPar.Range=["
                    szPhDur = "stimPar.freqPar.PhDur=["
                    szSPL = "stimPar.freqPar.SPLOffset=["
                    szCF = "stimPar.freqPar.CenterFreq=["
                    szBW = "stimPar.freqPar.Bandwidth=["
                    szTHR = "stimPar.freqPar.THR=["
                    szMCL = "stimPar.freqPar.MCL=["
                    For lX = 0 To lLen
                        szAmp = szAmp & TStr(.freqPar(lX).sAmp) & " "
                        szRange = szRange & TStr(.freqPar(lX).lRange) & " "
                        szPhDur = szPhDur & TStr(Math.Round(.freqPar(lX).lPhDur / .sTimeBase)) & " "
                        If .freqPar(lX).lPhDur > lPhDurMax Then lPhDurMax = .freqPar(lX).lPhDur
                        szSPL = szSPL & TStr(.freqPar(lX).sSPLOffset) & " "
                        szCF = szCF & TStr(.freqPar(lX).sCenterFreq) & " "
                        szBW = szBW & TStr(.freqPar(lX).sBandwidth) & " "
                        szTHR = szTHR & TStr(.freqPar(lX).sTHR) & " "
                        szMCL = szMCL & TStr(.freqPar(lX).sMCL) & " "
                    Next
                    szErr = mobjMatlab.Execute(szAmp & "];") : If Len(szErr) <> 0 Then GoTo SubError
                    szErr = mobjMatlab.Execute(szRange & "];") : If Len(szErr) <> 0 Then GoTo SubError
                    szErr = mobjMatlab.Execute(szPhDur & "];") : If Len(szErr) <> 0 Then GoTo SubError
                    szErr = mobjMatlab.Execute(szSPL & "];") : If Len(szErr) <> 0 Then GoTo SubError
                    szErr = mobjMatlab.Execute(szCF & "];") : If Len(szErr) <> 0 Then GoTo SubError
                    szErr = mobjMatlab.Execute(szBW & "];") : If Len(szErr) <> 0 Then GoTo SubError
                    szErr = mobjMatlab.Execute(szTHR & "];") : If Len(szErr) <> 0 Then GoTo SubError
                    szErr = mobjMatlab.Execute(szMCL & "];") : If Len(szErr) <> 0 Then GoTo SubError
                End If
                Select Case mgenMode
                    Case GENMODE.genAcoustical, GENMODE.genElectricalRIB, GENMODE.genElectricalRIB2, GENMODE.genVocoder, GENMODE.genAcousticalUnity
                        szErr = mobjMatlab.Execute("stimVec=[];")
                    Case GENMODE.genElectricalNIC

                        szErr = mobjMatlab.Execute("stimVec=struct('electrodes',[]," & _
                                                "'current_levels',[],'phase_gaps',8,'modes',103," & _
                                                "'phase_widths'," & TStr(lPhDurMax) & "," & _
                                                "'periods'," & TStr(.lPulsePeriod) & ");")
                End Select
                If Len(szErr) <> 0 Then GoTo SubError
            End If ' usematlab?

        End With
        mstPar = stNew
        NewStimulus = ""
        Exit Function

SubError:
        NewStimulus = "NewStimulus: " & szErr
        mstPar = stNew
        Exit Function

    End Function

    ''' <summary>
    ''' Create a new data stimulus.
    ''' </summary>
    ''' <param name="szData">Data (string) that will be stored in file szFnData.<example>"File Azi90 Ele30"</example></param>
    ''' <param name="szFnData">Data file name with absolute path, containing modulated data string.<example>"C:\Temp\File Azi90 Ele30.wav"</example></param>
    ''' <param name="Nsamp">Optional: number of samples per symbol in modulation; default=128<example>128</example></param>
    ''' <param name="QAMsize">Optional: alphabet size of QAM, must be an integer power of two; default=64<example>64</example></param>
    ''' <returns>Empty string if no errors occured; otherwise: string containing error message.</returns>
    ''' <remarks></remarks>
    Function NewDataStimulus(szData As String, szFnData As String, Optional Nsamp As Integer = 128, Optional QAMsize As Integer = 64) As String
        Dim szErr As String

        gstLeft.szStimFile = szFnData
        szErr = STIM.NewStimulus(gstLeft)
        If Len(szErr) <> 0 Then GoTo SubError

        szErr = STIM.MatlabStimulus("FW_DataChannel", szData, 128, 64) ' Matlab Part
        'If Len(szErr) <> 0 Then GoTo SubError
        If InStr(LCase(szErr), "error") > 0 Then GoTo SubError Else Debug.Print(szErr) : szErr = Nothing

        szErr = STIM.AssembleStimulus(gblnShowStimulus) ' Assemble (write file)
        If Len(szErr) <> 0 Then GoTo SubError
        STIM.CloseStimulus() ' Close

        Return ""
SubError:
        Return szErr

    End Function

    ''' <summary>
    ''' Close a stimulus.
    ''' </summary>
    ''' <returns>Zero-length string if no errors occured.</returns>
    ''' <remarks>After creating stimulus with AssembleStimulus call this function before creating a new one.</remarks>
    Public Function CloseStimulus() As String
        Dim szErr As String = ""

        LogToList("Close Stimulus")
        ' init data
        mstPar.iImpType = Implant.IMPLANTTYPE.imptInvalid
        mstPar.lChNr = -1
        mstPar.sTimeBase = 0
        mstPar.szFittFile = ""
        mstPar.szImpType = ""
        mstPar.szStimFile = ""

        If mblnUseMATLAB Then
            If mobjMatlab Is Nothing Then Err.Raise(vbObjectError + 2, "CloseStimulus", "MATLAB not started")
            CloseStimulus = mobjMatlab.Execute("clear stimVec;")
        End If
        CloseStimulus = szErr

    End Function

    ''' <summary>
    ''' Show the stimulation vector.
    ''' </summary>
    ''' <returns>Zero-length if no errors occured.</returns>
    ''' <remarks>The vector stimVec will be plotted (acoustical) or shown (electrical).
    ''' ShowStimulusFlags defines the options how the stimulus will be shown.</remarks>
    Public Function ShowStimulus() As String
        Dim szErr As String
        Dim lShowStimulusFlags As String

        If mblnUseMATLAB Then

            If mobjMatlab Is Nothing Then Err.Raise(vbObjectError + 2, "ShowStimulus", "MATLAB not started")
            If mszShowStimulusFlags Is Nothing Then
                lShowStimulusFlags = "0,[]"
            Else
                lShowStimulusFlags = mszShowStimulusFlags
            End If
            szErr = mobjMatlab.Execute("FW_ShowStimulus(stimVec,stimPar,'" & Replace(mstPar.szStimFile, "_", "\_") & "'," & lShowStimulusFlags & ");")
            If Len(szErr) > 0 Then
                If InStr(szErr, "???") > 0 Then Return "ShowStimulus: " & szErr
            End If
        End If
        Return ""

    End Function

    ''' <summary>
    ''' Assemble a stimulation file.
    ''' </summary>
    ''' <param name="blnShow">Set to true if you want to show the stimulus before assembling. FRAMEWORK: This flag can be received from mblnShowStimulus</param>
    ''' <returns>If no error occured the return value is "". In any error case the error message will be set to the return string.</returns>
    ''' <remarks>In electrical RIB mode the MATLAB function assemble() is used.<br>
    ''' In acoustical mode the MATLAB vector will be written as a WAV file.</br></remarks>
    Public Function AssembleStimulus(Optional ByVal blnShow As Boolean = False) As String
        Dim lIdx, lEnd As Integer
        Dim szCmd As String
        Dim szErr As String = ""
        Dim lX As Integer
        Dim filTmp As Object
        Dim szX As String

        If Not mblnUseMATLAB Or (mobjMatlab Is Nothing) Then Return "Matlab not in use."

        On Error Resume Next
        If blnShow Then szErr = ShowStimulus() : If Len(szErr) > 0 Then Return szErr

        Select Case mgenMode
            Case GENMODE.genAcoustical, GENMODE.genAcousticalUnity ' acoustical
                szCmd = "audiowrite( '" & mszWorkDir & IO.Path.DirectorySeparatorChar & mstPar.szStimFile & _
                        "',stimVec,stimPar.SamplingRate, 'BitsPerSample',stimPar.Resolution);"
                szErr = mobjMatlab.Execute(szCmd)

            Case GENMODE.genVocoder ' electrical/Vocoder
                'Read vocoder type
                If voc = "" Then
                    If VocType(1) = 1 Then voc = "Noise"
                    If VocType(2) = 1 Then voc = "GET"
                    If VocType(1) = 0 And VocType(2) = 0 Then Error ("You have to choose a Vocoder Type")
                End If

                If srateAcoustic = 0 Then srateAcoustic = glSamplingRate

                szCmd = "FW_ElectricVocoder(stimVec,stimPar,[" & F4FL.RANGE(0) & "," & F4FL.RANGE(1) & "," & F4FL.RANGE(2) & "," & F4FL.RANGE(3) & "] ,[" & F4FL.PHDUR_MIN & "," & F4FL.PHDUR_MAX & "],'" & voc & "'," & srateAcoustic & ",[" & divFactor & "],'" & _
                        mszWorkDir & IO.Path.DirectorySeparatorChar & mstPar.szStimFile & "');"
                szErr = mobjMatlab.Execute(szCmd)

                voc = ""

            Case GENMODE.genElectricalRIB
                szCmd = "RIB_Assemble(stimVec,'" & _
                        mszWorkDir & IO.Path.DirectorySeparatorChar & mstPar.szFittFile & "','" & _
                        mszWorkDir & IO.Path.DirectorySeparatorChar & mstPar.szStimFile & "',[],[0,100]);"
                szErr = mobjMatlab.Execute(szCmd)

            Case GENMODE.genElectricalNIC
                szCmd = "output=NIC_Assemble(stimVec,fitting{" & TStr(mstPar.lChNr + 1) & "},stimPar,'" & _
                        mszWorkDir & IO.Path.DirectorySeparatorChar & mstPar.szStimFile & "');"
                szErr = mobjMatlab.Execute(szCmd)
            Case GENMODE.genElectricalRIB2
                szCmd = "RIB2_Assemble(stimVec,'" & _
                        mszWorkDir & IO.Path.DirectorySeparatorChar & mstPar.szFittFile & "','" & _
                        mszWorkDir & IO.Path.DirectorySeparatorChar & mstPar.szStimFile & "');"
                szErr = mobjMatlab.Execute(szCmd)
        End Select
        ' error check
        If InStr(szErr, "???") > 0 Then
            AssembleStimulus = szErr
            LogToList("Assemble: Errors/Warnings received...")
        Else
            AssembleStimulus = "" ' no errors
            LogToList("Assemble: File: " & mstPar.szStimFile)
        End If
        ' log to stimulus log file
        If (mlogMode And LOGMODE.logStimulusToFile) <> 0 Then
            Dim filLog As StreamWriter = File.AppendText(mszStimLogFile)
            filLog.WriteLine("Assemble, Fitting file, Stimulus file, Result")
            filLog.WriteLine("-," & Quota(mstPar.szFittFile) & "," & Quota(mstPar.szStimFile) & "," & Quota(szErr))
            filLog.WriteLine()
            filLog.Close()
        End If

    End Function

    ''' <summary>
    ''' Backup log file.
    ''' </summary>
    ''' <param name="szFile">File name.</param>
    ''' <returns>Error text if an error occures.</returns>
    ''' <remarks></remarks>
    Public Function BackupLogFile(ByVal szFile As String) As String
        Dim szErr As String
        On Error Resume Next

        If (mlogMode And LOGMODE.logLogToFile) = 0 Then
            szErr = "There is no logging file for this logging mode."
            GoTo SubError
        Else
            If Len(Dir(mszLogFile)) = 0 Then
                szErr = "Log file couldn't be found."
                GoTo SubError
            Else
                If Len(Dir(szFile)) <> 0 Then
                    Kill((szFile))
                End If
                File.Copy(mszLogFile, szFile)
            End If
        End If

        On Error GoTo 0
        Return ""
SubError:
        On Error GoTo 0
        Return szErr

    End Function

    ''' <summary>
    ''' Execute a MATLAB command.
    ''' </summary>
    ''' <param name="szCmd">Command sent to MATLAB.</param>
    ''' <returns>Response string from MATLAB. Contains "" if no errors occured.</returns>
    ''' <remarks></remarks>
    Public Function Matlab(ByVal szCmd As String) As String

        If Not mblnUseMATLAB Then Matlab = "Matlab not in use." : Exit Function

        LogToList("Matlab: " & szCmd)
        Dim szErr As String
        If szCmd <> "" Then
            If mobjMatlab Is Nothing Then
                Matlab = "??? Error: Matlab not started"
                LogToList("MATLAB: not started")
            Else
                If (mlogMode And LOGMODE.logStimulusToFile) <> 0 Then
                    Dim filLog As StreamWriter = File.AppendText(mszStimLogFile)
                    filLog.WriteLine(Quota("Matlab") & mszSeparator & Quota(szCmd))
                    filLog.Close()
                End If
                Try
                    szErr = mobjMatlab.Execute(szCmd)
                Catch
                    Matlab = "Matlab command could not be executed:" & vbCrLf & vbCrLf & szCmd : Exit Function
                End Try
                LogToList("MATLAB: executed")
                Matlab = szErr
            End If
        Else
            Matlab = ""
        End If

    End Function

    ''' <summary>
    ''' Get real values from a 2D-Matrix from Matlab.
    ''' </summary>
    ''' <param name="szName">Matrix/Variable name.</param>
    ''' <param name="dblReal">Array to which the matrix will be copied. The proper size must be set before calling MatlabGetRealMatrix2 (see MatlabGetMatrixSize)</param>
    ''' <returns>Zero-length if no error ocured. Error message otherwise.</returns>
    ''' <remarks>This function gets the 2D-matrix szName from Matlab, disgards the imaginery values and copies the real values to dblReal().</remarks>
    Public Function MatlabGetRealMatrix2(ByVal szName As String, ByRef dblReal(,) As Double) As String
        Dim dblImag(,) As Double
        Dim szErr As String = ""

        If Not mblnUseMATLAB Then MatlabGetRealMatrix2 = "Matlab not in use." : Exit Function

        LogToList("MATLAB: Get real matrix")
        If szName <> "" Then
            If mobjMatlab Is Nothing Then
                MatlabGetRealMatrix2 = "??? Error: Matlab not started"
                LogToList("MATLAB: not started")
            Else
                On Error GoTo SubError
                ReDim dblImag(UBound(dblReal, 1), UBound(dblReal, 2))
                szErr = mobjMatlab.GetFullMatrix(szName, "base", dblReal, dblImag)
                On Error GoTo 0
                LogToList("MATLAB: executed")
                MatlabGetRealMatrix2 = szErr
            End If
        End If
        MatlabGetRealMatrix2 = szErr
        Exit Function

SubError:
        MatlabGetRealMatrix2 = Err.Description
        Exit Function
    End Function

    ''' <summary>
    ''' Get the size of a matrix.
    ''' </summary>
    ''' <param name="szName">Name of the Vector/Matrix or, general, Variable.</param>
    ''' <param name="lRow">Number of Rows as result.</param>
    ''' <param name="lCol">Number of Columns as result.</param>
    ''' <returns>Error message or empty if no error ocured.</returns>
    ''' <remarks>This function retrieves the size of a variable in Matlab.</remarks>
    Public Function MatlabGetMatrixSize(ByVal szName As String, ByRef lRow As Integer, ByRef lCol As Integer) As String
        Dim lSize(0) As Integer
        Dim szErr As String
        Dim szArr() As String
        Dim lX, lY As Integer

        If Not mblnUseMATLAB Then Return "Matlab not in use."

        LogToList("MATLAB: Get matrix size")
        If szName <> "" Then
            If mobjMatlab Is Nothing Then
                LogToList("MATLAB: not started")
                Return "??? Error: Matlab not started"
            Else
                On Error GoTo SubError
                szErr = mobjMatlab.Execute("disp(size(" & szName & ")');")
                If InStr(1, szErr, "?") > 0 Then Return szErr
                szArr = Split(szErr, Chr(10))
                lY = 0
                For lX = 0 To UBound(szArr)
                    If Len(szArr(lX)) > 0 Then
                        ReDim Preserve lSize(lY)
                        lSize(lY) = CInt(Val(szArr(lX)))
                        lY = lY + 1
                    End If
                Next
                lRow = lSize(0)
                lCol = lSize(1)
                On Error GoTo 0
                LogToList("MATLAB: executed")
                Return ""
            End If
        End If
        Return ""

SubError:
        Return Err.Description

    End Function



    ''' <summary>
    ''' Finish work with STIM.
    ''' </summary>
    ''' <returns>If no error occured the return value is "".</returns>
    ''' <remarks>Using STIM after Finish() requires Init().<br>
    '''<b>this function will be called on disconnect by Framework. Don't call it again!</b></br></remarks>
    Public Function Finish() As String

        LogToList("Finish")
        mobjMatlab = Nothing
        Finish = ""
    End Function

    ''' <summary>
    ''' Log items to the log file.
    ''' </summary>
    ''' <param name="szY"></param>
    ''' <param name="szItems">Each string will be quoted (if necessary) and written to the log file.</param>
    ''' <remarks></remarks>
    Public Sub Log(ByVal szY As String, ByVal ParamArray szItems() As String)
        Dim lX As Integer

        If (mlogMode And LOGMODE.logLogToFile) = 0 Then Exit Sub
        ' create log file
        On Error Resume Next
        Dim filLog As StreamWriter = File.AppendText(mszLogFile)
        ' create string
        szY = szY & ","
        For Each szX As String In szItems
            szY = szY & Quota(szX) & ","
        Next szX
        filLog.WriteLine(Left(szY, Len(szY) - 1))
        filLog.Close()
        On Error GoTo 0
    End Sub

    ''' <summary>
    ''' Log items to the log file.
    ''' </summary>
    ''' <param name="szItems">Each string will be quoted (if necessary) and written to the log file.</param>
    ''' <remarks></remarks>
    Public Sub Log(ByVal szItems() As String)
        Dim lX As Integer
        Dim szY As String = ""

        If (mlogMode And LOGMODE.logLogToFile) = 0 Then Exit Sub
        ' create log file
        On Error Resume Next
        Dim filLog As StreamWriter = File.AppendText(mszLogFile)
        ' create string
        For Each szX As String In szItems
            szY = szY & Quota(szX) & ","
        Next szX
        filLog.WriteLine(Left(szY, Len(szY) - 1))
        filLog.Close()
        On Error GoTo 0
    End Sub


    ''' <summary>
    ''' Backup item list in work directory.
    ''' </summary>
    ''' <param name="szFile">Target file name (optional), default: work directory.</param>
    ''' <remarks></remarks>
    Public Sub BackupItemList(Optional szFile As String = "")

        If szFile = "" Then
            szFile = STIM.WorkDir & "\~" & gszSettingTitle & "_backup." & gszItemListExtension
        End If

        If Len(Dir(szFile)) > 0 Then 'existing?
            Try
                Kill(szFile) 'delete file
            Catch
                frmMain.SetStatus("Item List Backup could not be created: " & szFile) : Exit Sub
            End Try
            If Len(Dir(szFile)) > 0 Then frmMain.SetStatus("Item List Backup could not be created: " & szFile) : Exit Sub
        End If

        Dim szErr As String = ItemList.Save(szFile)

    End Sub

    ' Create() and Destroy() are needed instead of the user control functions initialize(),
    ' ReadProperties() and Terminate(); an equivalence for WriteProperties() is not necessary
    ' Call STIM1.Create() when frmMain is loaded and Destroy() when it is unloaded

    Public Sub Create()

        ' init properties
        'gszCaption = ""
        mszSourceDir = ""
        mszDestinationDir = ""
        mszID = "test"
        mszDescription = "description of experiment"
        mszFirstName = ""
        mszLastName = ""
        mszWorkDir = ""
        mlogMode = LOGMODE.logEverything
        mblnUseMATLAB = True
        mblnCreateWorkDir = True
        mszQuota = Chr(34)
        mszSeparator = ","
        mszMATLABServer = ""
        mgenMode = GENMODE.genElectricalRIB

        ' init data
        mszTempDir = System.IO.Path.GetTempPath()
        LogToList("TempDir: " & mszTempDir)

    End Sub
    Public Sub Destroy()

        mobjMatlab = Nothing

    End Sub

    ' ------------------------------------------------------
    ' Properties
    ' ------------------------------------------------------

    'Public Property Get Caption() As String
    'Caption = gszCaption
    'End Property

    'Public Property Let Caption(ByVal szNewValue As String)
    'gszCaption = szNewValue
    'If Len(gszCaption) = 0 Then
    'lblTitle.Visible = False
    'Else
    'lblTitle.Visible = True
    'lblTitle.Caption = gszCaption
    'End If
    'UserControl_Resize
    'End Property




    ''' <summary>
    ''' Source Directory of fitting files (Settings/Fitting Left)
    ''' </summary>
    ''' <value></value>
    ''' <returns>Source Directory of fitting files (Settings/Fitting Left)</returns>
    ''' <remarks></remarks>
    Public Property SourceDir() As String
        Get
            SourceDir = mszSourceDir
        End Get
        Set(ByVal Value As String)
            mszSourceDir = Value
        End Set
    End Property



    ''' <summary>
    ''' Root Directory (Settings/General/Output directory)
    ''' </summary>
    ''' <value></value>
    ''' <returns>Root Directory (Settings/General/Output directory)</returns>
    ''' <remarks></remarks>
    Public Property DestinationDir() As String
        Get
            DestinationDir = mszDestinationDir
        End Get
        Set(ByVal Value As String)
            mszDestinationDir = Value
        End Set
    End Property

    ''' <summary>
    ''' Get the Work Directory.
    ''' </summary>
    ''' <value></value>
    ''' <returns>Work Directory.</returns>
    ''' <remarks>WorkDirectory is the active directory, where all files will be saved/read.
    ''' In electrical mode, fitting files will be copied to this directory.<br>
    ''' WorkDirectory is valid after Init(), or Connect in FrameWork.</br>
    ''' <br>If the property CreateWorkDir is FALSE, WorkDir is the DestinationDir.</br>
    ''' Otherwise, a new directory will be created in DestinationDir with the syntax:
    '''<b>ID_YYYYMMDD_HHmmss</b>, where:
    '''<li>ID: property ID</li>
    '''<li>YYYYMMDD: Year , Month, Day</li>
    '''<li>HHmmss: hour, minute, second</li></remarks>
    Public ReadOnly Property WorkDir() As String
        Get
            WorkDir = mszWorkDir
        End Get
    End Property

    'Public Property Let WorkDir(ByVal szNewValue As String)
    '  If Ambient.UserMode Then
    '    Err.Raise 383
    '  Else
    '    Err.Raise 382
    '  End If
    'End Property



    ''' <summary>
    ''' Get the mode of generation of stimuli.
    ''' </summary>
    ''' <value></value>
    ''' <returns>Generation mode, <see cref="GENMODE"/>.</returns>
    ''' <remarks></remarks>
    Public Property GenerationMode() As GENMODE
        Get
            GenerationMode = mgenMode
        End Get
        Set(ByVal Value As GENMODE)
            mgenMode = Value
        End Set
    End Property


    Public Property LoggingMode() As LOGMODE
        Get
            LoggingMode = mlogMode
        End Get
        Set(ByVal Value As LOGMODE)
            mlogMode = Value
        End Set
    End Property

    ''' <summary>
    ''' Get the experiment ID.
    ''' </summary>
    ''' <value></value>
    ''' <returns>Experiment ID (Settings/Description)</returns>
    ''' <remarks></remarks>
    Public Property ID() As String
        Get
            ID = mszID
        End Get
        Set(ByVal Value As String)
            mszID = Value
        End Set
    End Property


    Public Property Description() As String
        Get
            Description = mszDescription
        End Get
        Set(ByVal Value As String)
            mszDescription = Value
        End Set
    End Property


    Public Property FirstName() As String
        Get
            FirstName = mszFirstName
        End Get
        Set(ByVal Value As String)
            mszFirstName = Value
        End Set
    End Property


    Public Property LastName() As String
        Get
            LastName = mszLastName
        End Get
        Set(ByVal Value As String)
            mszLastName = Value
        End Set
    End Property


    Public Property ShowStimulusFlags() As String
        Get
            Return mszShowStimulusFlags
        End Get
        Set(ByVal Value As String)
            mszShowStimulusFlags = Value
        End Set
    End Property


    ''' <summary>
    ''' Set the computer name providing the Matlab object.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MATLABServer() As String
        Get
            MATLABServer = mszMATLABServer
        End Get
        Set(ByVal Value As String)
            mszMATLABServer = Value
        End Set
    End Property

    ''' <summary>
    ''' Set the path to the MATLAB scripts.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MATLABPath() As String
        Get
            Return mszMATLABPath
        End Get
        Set(ByVal Value As String)
            mszMATLABPath = Value
        End Set
    End Property

    ''' <summary>
    ''' Use Matlab on Init() (FrameWork: on connect)?
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UseMatlab() As Boolean
        Get
            UseMatlab = mblnUseMATLAB
        End Get
        Set(ByVal Value As Boolean)
            mblnUseMATLAB = CBool(Value)
        End Set
    End Property


    ''' <summary>
    ''' Create Work directory on Init() (FrameWork: on connect)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CreateWorkDir() As Boolean
        Get
            CreateWorkDir = mblnCreateWorkDir
        End Get
        Set(ByVal Value As Boolean)
            mblnCreateWorkDir = CBool(Value)
        End Set
    End Property


    ' ------------------------------------------------------
    ' private functions
    ' ------------------------------------------------------

    Private Sub LogToList(ByVal szItem As String)

        If (mlogMode And LOGMODE.logLogToList) <> 0 Then
            frmMain.lstLog.Items.Add(szItem)
            If frmMain.lstLog.Items.Count > 1000 Then frmMain.lstLog.Items.RemoveAt(0)
            frmMain.lstLog.SelectedIndex = frmMain.lstLog.Items.Count - 1
        End If

    End Sub

    Private Sub StimToList(ByVal szItem As String)

        If (mlogMode And LOGMODE.logStimulusToList) <> 0 Then
            frmMain.lstLog.Items.Add(szItem)
            If frmMain.lstLog.Items.Count > 1000 Then frmMain.lstLog.Items.RemoveAt(0)
            frmMain.lstLog.SelectedIndex = frmMain.lstLog.Items.Count - 1
        End If

    End Sub

    Private Function Quota(ByVal szCell As String) As String
        Dim szRes As String
        ' CSV rule: double all Quota
        szRes = Replace(szCell, mszQuota, mszQuota & mszQuota)
        ' CSV rule: quote if Quota or separator found
        If InStr(1, szRes, mszSeparator) > 0 Or InStr(1, szRes, mszQuota) > 0 Then
            szRes = mszQuota & szRes & mszQuota
        End If
        Quota = szRes

    End Function

    Private Function CSVEncode(ByVal szText As String) As String
        Dim szBuf As String
        szBuf = Replace(szText, "%", "%25")
        szBuf = Replace(szBuf, vbCr, "%0D")
        szBuf = Replace(szBuf, vbLf, "%0A")
        szBuf = Replace(szBuf, Chr(34), "%22")
        szBuf = Replace(szBuf, ",", "%2C")
        Return szBuf
    End Function

End Module