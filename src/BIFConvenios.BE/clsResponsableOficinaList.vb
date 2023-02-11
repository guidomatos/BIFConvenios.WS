<DataContract()>
Public Class clsResponsableOficinaList
    ' Fields
    Private _objElements As List(Of clsReponsableOficina)

    ' Properties
    <DataMember()>
    Public Property Elements() As List(Of clsReponsableOficina)
        Get
            Return _objElements
        End Get
        Set(value As List(Of clsReponsableOficina))
            _objElements = value
        End Set
    End Property
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(Entidad As DataTable)
        Dim flag As Boolean = (IsDBNull(Entidad) Or (Entidad.Rows.Count = 0))
        If Not flag Then
            Dim enumerator As IEnumerator = Nothing
            Try
                enumerator = Entidad.Rows.GetEnumerator
                Do While True
                    flag = enumerator.MoveNext
                    If Not flag Then
                        Exit Do
                    End If
                    Dim current As DataRow = DirectCast(enumerator.Current, DataRow)
                    Elements.Add(New clsReponsableOficina(current))
                Loop
            Finally
                If TryCast(enumerator, IDisposable) IsNot Nothing Then
                    TryCast(enumerator, IDisposable).Dispose()
                End If
            End Try
        End If
    End Sub
End Class
