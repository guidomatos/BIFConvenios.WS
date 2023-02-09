Public Class clsProcesosAutomaticosList
    ' Fields
    Private _objElements As List(Of clsProcesosAutomaticos)

    ' Properties
    Public Property Elements() As List(Of clsProcesosAutomaticos)
        Get
            Return _objElements
        End Get
        Set(value As List(Of clsProcesosAutomaticos))
            _objElements = value
        End Set
    End Property
    Public Sub New()
        MyBase.New()
        _objElements = New List(Of clsProcesosAutomaticos)()
    End Sub
    Public Sub New(Entidad As DataTable)
        _objElements = New List(Of clsProcesosAutomaticos)
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
                    Elements.Add(New clsProcesosAutomaticos(current))
                Loop
            Finally
                If TryCast(enumerator, IDisposable) IsNot Nothing Then
                    TryCast(enumerator, IDisposable).Dispose()
                End If
            End Try
        End If
    End Sub
End Class
