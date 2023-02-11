<DataContract()>
Public Class ClsAcceso
    ' Fields
    Private _idUsuario As String

    ' Properties
    <DataMember()>
    Public Property idUsuario() As String
        Get
            Return _idUsuario
        End Get
        Set(value As String)
            _idUsuario = value
        End Set
    End Property

    <DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
    End Sub
End Class
