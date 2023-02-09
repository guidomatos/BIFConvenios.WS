Imports BIFUtils
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class ClienteDO
    ' Fields
    Private ReadOnly cUtils As New WS.Utils
    Private ReadOnly conexionIBS As String
    Private ReadOnly conexionConvenios As String

    Public Sub New()
        MyBase.New()
        cUtils = New WS.Utils()
        conexionIBS = WS.Utils.CadenaConexion("AS400-ConnectionString-Convenios")
        conexionConvenios = WS.Utils.CadenaConexion("ConnectionString")
    End Sub
    Public Function ExisteCodigoIBS(codibs As Integer) As Boolean
        Dim flag As Boolean
        Dim connection As New SqlConnection(conexionConvenios)
        connection.Open()
        Dim objA As New SqlCommand("EXEC VALIDA_NO_EXISTA", connection)
        Try
            objA.CommandType = CommandType.StoredProcedure
            objA.Parameters.Add("@codibs", SqlDbType.Int).Value = codibs
            Return Conversions.ToBoolean(objA.ExecuteScalar)
        Finally
            If objA IsNot Nothing Then
                objA.Dispose()
            End If
        End Try
        connection.Close()
        Return flag
    End Function

    Public Function ObtenerCodigoClienteIBS(pTipoDocumento As String, pNumeroDocumento As String) As String
        Dim connection As New OleDbConnection(conexionIBS)
        'New OleDbCommand.CommandType = CommandType.Text
        Dim strArray As String() = New String() {"SELECT CUSCUN FROM CUMST WHERE CUSTID  ='", pTipoDocumento.Trim, "' AND CUSIDN = '", pNumeroDocumento.Trim, "'"}
        Dim obj2 As Object = String.Concat(strArray)
        connection.Open()
        Dim str As String = Conversions.ToString(New OleDbCommand(Conversions.ToString(obj2), connection).ExecuteScalar)
        connection.Close()
        Return str
    End Function
End Class
