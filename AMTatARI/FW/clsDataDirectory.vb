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
'''   FrameWork - Data Directory support.
'''   Only one instance of clsDataDirectory is used in FrameWork: DataDirectory.
''' </summary>
''' <seealso cref="FWintern.DataDirectory"/>
Friend Class clsDataDirectory

    Private mszTitle() As String
    Private mszPath() As String

    ''' <summary>
    '''   Reset all data directories. No data directories will be defined after Reset.
    ''' </summary>
    ''' <seealso cref="AddDir"/>
    Public Sub Reset()
        Erase mszTitle
        Erase mszPath
    End Sub

    ''' <summary>
    '''   Get the number of data directories.
    ''' </summary>
    ''' <seealso cref="AddDir"/>
    ''' <seealso cref="Reset"/>
    Public ReadOnly Property Count() As Integer
        Get
            Count = GetUbound(mszTitle) + 1
        End Get
    End Property

    ''' <summary>
    '''   Get / Set the title of a data directory.
    ''' </summary>
    ''' <param name="Index">Directory index</param>
    '''  <example>
    ''' This example shows you how to GET the title of a data directory:
    ''' szString = Title(Integer)
    ''' //
    ''' This example shows you how to SET the title of a data directory:
    ''' Title(Index) = szString
    ''' </example>
    Public Property Title(ByVal Index As Integer) As String
        Get
            If Index > GetUbound(mszTitle) Then Err.Raise(vbObjectError, "Data Directory: Title", "Index out of bounds")
            Title = mszTitle(Index)
        End Get
        Set(ByVal Value As String)
            If Index > GetUbound(mszTitle) Then Err.Raise(vbObjectError, "Data Directory: Title", "Index out of bounds")
            mszTitle(Index) = Value
        End Set
    End Property


    ''' <summary>
    '''   Get / Set the data directory to a path.
    ''' </summary>
    ''' <param name="Index">Directory index</param>
    '''     
    ''' <example>
    ''' This example shows you how to GET the data directory:
    ''' szString = Path(Integer)
    ''' //
    ''' This example shows you how to SET the data directory to a path:
    ''' Path(Index) = szString
    ''' </example>
    Public Property Path(ByVal Index As Integer) As String
        Get
            If Index > GetUbound(mszTitle) Then Err.Raise(vbObjectError, "Data Directory: Directory", "Index out of bounds")
            Path = mszPath(Index)
        End Get
        Set(ByVal Value As String)
            If Index > GetUbound(mszTitle) Then Err.Raise(vbObjectError, "Data Directory: Directory", "Index out of bounds")
            mszPath(Index) = Value
        End Set
    End Property


    ''' <summary>
    '''   Add a new data directory.
    ''' </summary>
    ''' <param name="Title">Title of the data directory</param>
    ''' <param name="Path">[Optional] Default path of the data directory</param>
    Public Sub AddDir(ByVal Title As String, Optional ByVal Path As String = "")
        Dim lX As Integer
        If IsNothing(mszTitle) Then lX = 0 Else lX = mszTitle.Length
        ReDim Preserve mszTitle(lX)
        ReDim Preserve mszPath(lX)
        mszTitle(lX) = Title
        mszPath(lX) = Path
    End Sub
End Class