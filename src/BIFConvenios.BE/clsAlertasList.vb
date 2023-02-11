<DataContract()>
Public Class clsAlertasList
    ' Fields
    Private _objElements As List(Of clsAlertas)

    ' Properties
    <DataMember()>
    Public Property Elements() As List(Of clsAlertas)
        Get
            Return _objElements
        End Get
        Set(value As List(Of clsAlertas))
            _objElements = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        _objElements = New List(Of clsAlertas)()
    End Sub

    Public Sub New(Entidad As DataTable)
        MyBase.New()
        Dim enumerator As IEnumerator = Nothing
        _objElements = New List(Of clsAlertas)()
        If (Not (IsDBNull(Entidad) Or Entidad.Rows.Count = 0)) Then
            Try
                enumerator = Entidad.Rows.GetEnumerator()
                While enumerator.MoveNext()
                    Dim _drw As DataRow = DirectCast(enumerator.Current, DataRow)
                    Elements.Add(New clsAlertas(_drw))
                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    TryCast(enumerator, IDisposable).Dispose()
                End If
            End Try
        End If
    End Sub
End Class
