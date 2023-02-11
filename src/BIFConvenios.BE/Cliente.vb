<DataContract()>
Public Class Cliente
    ' Fields
    Private _codibs As Integer
    ' Properties
    <DataMember()>
    Public Property codibs() As Integer
        Get
            Return _codibs
        End Get
        Set(value As Integer)
            _codibs = value
        End Set
    End Property

    <DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
    End Sub
End Class
