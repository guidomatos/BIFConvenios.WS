Imports BIFConvenios.DO

Public Class clsAccesoBL
    <DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
    End Sub
    ' Fields
    Private ReadOnly AccDO As New clsAccesoDO
    ' Methods
    Public Function GetBuscarPerfilUsuario(pstridUsuario As String) As String
        Return AccDO.GetBuscarPerfilUsuario(pstridUsuario)
    End Function
End Class