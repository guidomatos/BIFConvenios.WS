<DataContract()>
Public Class conexion
    <DataMember()>
    Public Shared lstrCadenaConexion
    <DataMember()>
    Public Shared lstrCadenaConexionIBS

    <DataMember()>
    Public Property CadenaConexion() As String
        Get
            Return lstrCadenaConexion
        End Get
        Set(value As String)
            lstrCadenaConexion = value
        End Set
    End Property

    <DataMember()>
    Public Property CadenaConexionIBS() As String
        Get
            Return lstrCadenaConexionIBS
        End Get
        Set(value As String)
            lstrCadenaConexionIBS = value
        End Set
    End Property
End Class
