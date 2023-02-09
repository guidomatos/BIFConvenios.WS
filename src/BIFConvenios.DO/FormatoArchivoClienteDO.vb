Imports BIFUtils
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Data.SqlClient
Public Class FormatoArchivoClienteDO
    ' Fields
    Private ReadOnly cUtils As New WS.Utils
    Private ReadOnly conexionIBS As String
    Private conexionConvenios As String

    Public Sub New()
        MyBase.New()
        cUtils = New WS.Utils()
        conexionIBS = WS.Utils.CadenaConexion("AS400-ConnectionString-Convenios")
        conexionConvenios = WS.Utils.CadenaConexion("ConnectionString")
    End Sub
    Public Function ObtieneNombreFormatoArchivo(pCodigo_proceso As String) As String
        Dim connection As New SqlConnection(conexionConvenios)
        Dim command As New SqlCommand(("EXEC GetNombreFormatoArchivo '" & pCodigo_proceso & "'"), connection)
        connection.Open()
        Dim str As String = Conversions.ToString(command.ExecuteScalar)
        connection.Close()
        Return str
    End Function
End Class
