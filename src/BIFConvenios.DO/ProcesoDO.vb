Imports BIFUtils
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Data.SqlClient
Public Class ProcesoDO
    ' Fields
    Private ReadOnly cUtils As New WS.Utils
    Private ReadOnly conexionIBS As String
    Private conexionConvenios As String

    Public Sub New()
        MyBase.New()
        'cUtils = New WS.Utils()
        Dim lobj As New BE.conexion
        conexionIBS = lobj.CadenaConexionIBS
        conexionConvenios = WS.Utils.CadenaConexion("ConnectionString")
    End Sub
    Public Sub ActualizaGeneracionArchivo(pCodigo_proceso As String, pUsuario As String)
        Dim connection As New SqlConnection(conexionConvenios)
        Dim strArray As String() = New String() {"EXEC GetFinalGeneracionArchivo '", pCodigo_proceso, "','", pUsuario, "'"}
        Dim command As New SqlCommand(Conversions.ToString(String.Concat(strArray)), connection) With {
            .CommandType = CommandType.Text
        }
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub

    Public Function AdicionaProceso(pCodigo_Cliente As Integer, pAnio As String, pMes As String, pFecha_ProcesoAS400 As String, pUsuario As String) As String
        Dim connection As New SqlConnection(conexionConvenios)
        Dim cmd As New SqlCommand With {
            .Connection = connection,
            .CommandType = CommandType.StoredProcedure,
            .CommandText = "AddProceso"
        }
        AgregarParametro(cmd, "@Codigo_Cliente", ParameterDirection.Input, DbType.Int32, pCodigo_Cliente)
        AgregarParametro(cmd, "@Anio_periodo", ParameterDirection.Input, DbType.String, pAnio)
        AgregarParametro(cmd, "@Mes_Periodo", ParameterDirection.Input, DbType.String, pMes)
        AgregarParametro(cmd, "@Fecha_ProcesoAS400", ParameterDirection.Input, DbType.String, pFecha_ProcesoAS400)
        AgregarParametro(cmd, "@usuario", ParameterDirection.Input, DbType.String, pUsuario)
        connection.Open()
        Dim str2 As String = Conversions.ToString(cmd.ExecuteScalar)
        connection.Close()
        Return str2
    End Function

    Private Sub AgregarParametro(ByRef cmd As SqlCommand, nombreParam As String, direccionParam As ParameterDirection, tipoParam As DbType, valorParam As Object)
        Dim parameter As IDbDataParameter = cmd.CreateParameter
        parameter.ParameterName = nombreParam
        parameter.DbType = tipoParam
        parameter.Direction = direccionParam
        parameter.Value = valorParam
        cmd.Parameters.Add(parameter)
    End Sub

    Public Sub FinalizaEnvioCobranza(pCodigo_proceso As String)
        Dim connection As New SqlConnection(conexionConvenios)
        Dim command As New SqlCommand(Conversions.ToString(("EXEC FinalizadoEnvioInformacionAS400 '" & pCodigo_proceso & "',''")), connection) With {
            .CommandType = CommandType.Text
        }
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub

    Public Sub FinalizaGeneracionArchivo(pCodigo_proceso As String, pUsuario As String)
        Dim connection As New SqlConnection(conexionConvenios)
        Dim strArray As String() = New String() {"EXEC UpdEstadoGeneracionExito '", pCodigo_proceso, "','", pUsuario, "'"}
        Dim command As New SqlCommand(Conversions.ToString(String.Concat(strArray)), connection) With {
            .CommandType = CommandType.Text
        }
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub

    Public Sub InicioDescuentoEmpresa(pCodigo_proceso As String, pUsuario As String)
        Dim connection As New SqlConnection(conexionConvenios)
        Dim strArray As String() = New String() {"EXEC IniciaProcesoCargaDescuentos '", pCodigo_proceso, "','", pUsuario, "'"}
        Dim command As New SqlCommand(Conversions.ToString(String.Concat(strArray)), connection) With {
            .CommandType = CommandType.Text
        }
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub

    Public Sub InicioEnvioCobranza(pCodigo_proceso As String, pUsuario As String)
        Dim connection As New SqlConnection(conexionConvenios)
        Dim strArray As String() = New String() {"EXEC InicioEnvioInformacionAS400 '", pCodigo_proceso, "','", pUsuario, "'"}
        Dim command As New SqlCommand(Conversions.ToString(String.Concat(strArray)), connection) With {
            .CommandType = CommandType.Text
        }
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub

    Public Function ObtieneNombreArchivoProceso(pCodigo_proceso As String, lFormatoArchivo As String) As String
        Dim connection As New SqlConnection(conexionConvenios)
        'Dim command As New SqlCommand(Conversions.ToString(("EXEC GetNombreArchivoProceso '" & pCodigo_proceso & "'")), connection)
        Dim command As New SqlCommand(Conversions.ToString(("EXEC GetNombreArchivoProceso '" & pCodigo_proceso & "','" & lFormatoArchivo & "'")), connection) With {
            .CommandType = CommandType.Text
        }
        connection.Open()
        Dim str As String = Conversions.ToString(command.ExecuteScalar)
        connection.Close()
        Return str
    End Function

    Public Function ObtieneProcesoCliente(pCodigo_proceso As String) As DataTable
        Dim ldtResultado As New DataTable

        ldtResultado.Columns.Add("Nombre_Cliente")
        ldtResultado.Columns.Add("Anio_periodo")
        ldtResultado.Columns.Add("Mes_Periodo")
        ldtResultado.Columns.Add("Fecha_ProcesoAS400")
        ldtResultado.Columns.Add("TipoDocumento")
        ldtResultado.Columns.Add("NumeroDocumento")

        Dim lconn As New SqlConnection(conexionConvenios)
        Dim lcmd As SqlCommand
        Dim lstrsql = "EXEC GetInfoProcesoCliente '" & pCodigo_proceso & "'"
        'Dim lResult As String

        lcmd = New SqlCommand(lstrsql, lconn) With {
            .CommandType = CommandType.Text
        }
        lconn.Open()
        Dim reader As SqlDataReader = lcmd.ExecuteReader()

        Dim ldr As DataRow
        While reader.Read()
            ldr = ldtResultado.NewRow()
            ldr("Nombre_Cliente") = reader(0).ToString()
            ldr("Anio_periodo") = reader(1).ToString()
            ldr("Mes_Periodo") = reader(2).ToString()
            ldr("Fecha_ProcesoAS400") = reader(3).ToString()
            ldr("TipoDocumento") = reader(4).ToString()
            ldr("NumeroDocumento") = reader(5).ToString()
            If ldr IsNot Nothing Then
                ldtResultado.Rows.Add(ldr)
            End If
        End While
        lconn.Close()
        Return ldtResultado

        'Dim lds As DataSet = New DataSet()
        'Dim lda As SqlDataAdapter = New SqlDataAdapter(String.Concat("EXEC GetInfoProcesoCliente '", pCodigo_proceso, "'"), conexionConvenios)
        'lda.Fill(lds)
    End Function
End Class
