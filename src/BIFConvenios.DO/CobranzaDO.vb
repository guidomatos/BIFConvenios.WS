Imports ADODB
Imports BIFUtils
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Configuration
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Reflection
Public Class CobranzaDO
    'cUtils = New BIFUtils.Utils()
    Private ReadOnly cUtils As New WS.Utils
    Private ReadOnly conexionIBS As String
    Private ReadOnly conexionConvenios As String
    ' Methods
    Public Sub New()
        MyBase.New()
        Dim lobj As New BE.conexion
        'conexionIBS = lobj.CadenaConexionIBS
        conexionIBS = WS.Utils.CadenaConexion("AS400-ConnectionString-Convenios")
        conexionConvenios = WS.Utils.CadenaConexion("ConnectionString")
    End Sub

    Public Function ActivarPagoIBSOnline(strTipoOperacion As String, strCodigoClienteIBS As String, strFecha As String) As Integer
        Dim num As Integer
        Dim connection As Connection = New ConnectionClass
        Dim recordset As Recordset = New RecordsetClass
        Dim adapter As New OleDbDataAdapter
        'Dim set As New DataSet
        Dim str3 As String = ConfigurationManager.AppSettings("ProgramaPagoOnline")
        Try
            connection.CursorLocation = CursorLocationEnum.adUseClient
            connection.Open(conexionIBS, "", "", -1)
            connection.Execute(str3.Replace("TipoOperacion", strTipoOperacion).Replace("CodigoClienteIBS", strCodigoClienteIBS).Replace("Fecha", strFecha), Missing.Value, -1).ActiveConnection = Nothing
            connection.Close()
            connection = Nothing
        Catch exception1 As Exception
            Dim ex As Exception = exception1
            ProjectData.SetProjectError(ex)
            Throw ex
        End Try
        Return num
    End Function

    Public Sub ActualizaCobranza(pCodigo_proceso As String, pDLNP As String, pEstado As String)
        Dim lconn As New SqlConnection(conexionConvenios)
        Dim lcmd As New SqlCommand()
        lconn.Open()
        lcmd.CommandType = CommandType.Text
        Dim strArrays() As String = {"UPDATE clientecuota SET Estado = '", pEstado, "' where Codigo_proceso ='", pCodigo_proceso, "' and DLNP = '", pDLNP, "'"}
        Dim strsql As Object = String.Concat(strArrays)
        lcmd = New SqlCommand(Conversions.ToString(strsql), lconn)
        lcmd.ExecuteNonQuery()
        lconn.Close()
    End Sub

    Private Sub AgregarParametro(ByRef cmd As SqlCommand, nombreParam As String, direccionParam As ParameterDirection, tipoParam As DbType, valorParam As Object)
        Dim parameter As IDbDataParameter = cmd.CreateParameter
        parameter.ParameterName = nombreParam
        parameter.DbType = tipoParam
        parameter.Direction = direccionParam
        parameter.Value = valorParam
        cmd.Parameters.Add(parameter)
    End Sub

    Public Sub AnulaCobranza(pCodigo_proceso As String, pUsuario As String)
        Dim connection As New SqlConnection(conexionConvenios)
        Dim strArray As String() = New String() {"EXEC AnulaProcesoArchivoDescuentos '", pCodigo_proceso, "','", pUsuario, "'"}
        Dim command As New SqlCommand(String.Concat(strArray), connection) With {
            .CommandType = CommandType.Text
        }
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub

    Public Sub ArchivoDescuentosInserta(pCodigo_proceso As String, ldr As DataRow)
        Dim connection As New SqlConnection(conexionConvenios)
        Dim cmd As New SqlCommand("INSERT INTO ArchivoDescuentos (CodigoBanco, Moneda, NumeroPagare, CodigoModular, NombreTrabajador, CodigoReferencia, Anio, Mes, Cuota, SituacionLaboral, MontoDescuento, Estado, Codigo_proceso) VALUES (@CodigoBanco, @Moneda, @NumeroPagare, @CodigoModular, @NombreTrabajador, @CodigoReferencia, @Anio, @Mes, @Cuota, @SituacionLaboral, @MontoDescuento, @Estado, @Codigo_proceso) ", connection) With {
            .CommandType = CommandType.Text
        }
        AgregarParametro(cmd, "@CodigoBanco", ParameterDirection.Input, DbType.String, ldr("CodigoBanco").ToString)
        AgregarParametro(cmd, "@Moneda", ParameterDirection.Input, DbType.String, ldr("Moneda").ToString)
        AgregarParametro(cmd, "@NumeroPagare", ParameterDirection.Input, DbType.String, ldr("NumeroPagare").ToString)
        AgregarParametro(cmd, "@CodigoModular", ParameterDirection.Input, DbType.String, ldr("CodigoModular").ToString)
        AgregarParametro(cmd, "@NombreTrabajador", ParameterDirection.Input, DbType.String, ldr("NombreTrabajador").ToString)
        AgregarParametro(cmd, "@CodigoReferencia", ParameterDirection.Input, DbType.String, ldr("CodigoReferencia").ToString)
        AgregarParametro(cmd, "@Anio", ParameterDirection.Input, DbType.String, ldr("Anio").ToString)
        AgregarParametro(cmd, "@Mes", ParameterDirection.Input, DbType.String, ldr("Mes").ToString)
        AgregarParametro(cmd, "@Cuota", ParameterDirection.Input, DbType.String, ldr("Cuota").ToString)
        AgregarParametro(cmd, "@SituacionLaboral", ParameterDirection.Input, DbType.String, ldr("SituacionLaboral").ToString)
        AgregarParametro(cmd, "@MontoDescuento", ParameterDirection.Input, DbType.String, IIf((ldr("MontoDescuento").ToString.Trim = ""), 0, ldr("MontoDescuento").ToString))
        AgregarParametro(cmd, "@Estado", ParameterDirection.Input, DbType.String, "")
        AgregarParametro(cmd, "@Codigo_proceso", ParameterDirection.Input, DbType.String, pCodigo_proceso)
        connection.Open()
        cmd.ExecuteNonQuery()
        connection.Close()
    End Sub

    Public Sub EliminaCobranzaEnIBS(pCobranza As DataRow)
        Dim connection As New OleDbConnection(conexionIBS)
        Dim command As New OleDbCommand(Conversions.ToString("DELETE FROM DLREC WHERE DLRAG = ? AND DLRAN = ? AND DLRAP = ? AND DLRCC = ? AND DLRCM = ? AND DLRCO = ? AND DLRCR = ? AND DLRER = ? AND DLRFP = ? AND DLRIC = ? AND DLRID = ? AND DLRMO = ? AND DLRMP = ? AND DLRNE = ? AND DLRNP = ? AND DLRST = ?"), connection) With {
            .CommandType = CommandType.Text
        }
        command.Parameters.AddWithValue("DLRAG", pCobranza("DLAG"))
        command.Parameters.AddWithValue("DLRAN", pCobranza("DLAN"))
        command.Parameters.AddWithValue("DLRAP", pCobranza("DLAP"))
        command.Parameters.AddWithValue("DLRCC", pCobranza("DLCC"))
        command.Parameters.AddWithValue("DLRCM", pCobranza("DLCM"))
        command.Parameters.AddWithValue("DLRCO", pCobranza("DLCO"))
        command.Parameters.AddWithValue("DLRCR", pCobranza("DLCR"))
        command.Parameters.AddWithValue("DLRER", pCobranza("DLER"))
        command.Parameters.AddWithValue("DLRFP", pCobranza("DLFP"))
        command.Parameters.AddWithValue("DLRIC", pCobranza("DLIC"))
        command.Parameters.AddWithValue("DLRID", pCobranza("DLID"))
        command.Parameters.AddWithValue("DLRMO", pCobranza("DLMO"))
        command.Parameters.AddWithValue("DLRMP", pCobranza("DLMP"))
        command.Parameters.AddWithValue("DLRNE", pCobranza("DLNE"))
        command.Parameters.AddWithValue("DLRNP", pCobranza("DLNP"))
        command.Parameters.AddWithValue("DLRST", pCobranza("DLST"))
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub

    Public Sub EliminaCobranzaMasivaEnIBS(pCodigo_ClienteIBS As String, pAnio As String, pMes As String, pFecha_ProcesoAS400 As String)
        Dim connection As Connection = New ConnectionClass With {
            .CursorLocation = CursorLocationEnum.adUseClient
        }
        connection.Open(conexionIBS, "", "", -1)
        connection.Execute(String.Concat(New String() {"delete from DLREC where DLRCC =", pCodigo_ClienteIBS, " AND DLRAP = ", pAnio, " AND DLRMP = ", pMes, " AND DLRFP = ", pFecha_ProcesoAS400}), Missing.Value, -1)
        connection.Close()
    End Sub

    Public Sub ImportaDescuentosClientePrepara(pCodigo_proceso As String, pFechaFormateada As String)
        Dim connection As New SqlConnection(conexionConvenios)
        Dim strArray As String() = New String() {"EXEC ProcesaDatosArchivos '", pCodigo_proceso, "','", pFechaFormateada, "'"}
        Dim command As New SqlCommand(String.Concat(strArray), connection) With {
            .CommandType = CommandType.Text
        }
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub

    Public Sub ImportaDescuentosClienteProcesa(pCodigo_proceso As String, pUsuario As String)
        Dim connection As New SqlConnection(conexionConvenios)
        Dim strArray As String() = New String() {"EXEC ProcesaArchivoDescuentoDefault '", pCodigo_proceso, "','", pUsuario, "'"}
        Dim command As New SqlCommand(String.Concat(strArray), connection) With {
            .CommandType = CommandType.Text
        }
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub

    Public Sub InsertaCobranzaEnIBS(pCobranza As DataRow)
        Dim connection As New OleDbConnection(conexionIBS)
        Dim command As New OleDbCommand(Conversions.ToString("INSERT INTO DLREC (DLRAG, DLRAN, DLRAP, DLRCC, DLRCM, DLRCO, DLRCR, DLRER, DLRFP, DLRIC, DLRID, DLRMO, DLRMP, DLRNE, DLRNP, DLRST,DLENL) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?)"), connection) With {
            .CommandType = CommandType.Text
        }
        command.Parameters.AddWithValue("DLRAG", pCobranza("DLAG"))
        command.Parameters.AddWithValue("DLRAN", pCobranza("DLAN"))
        command.Parameters.AddWithValue("DLRAP", pCobranza("DLAP"))
        command.Parameters.AddWithValue("DLRCC", pCobranza("DLCC"))
        command.Parameters.AddWithValue("DLRCM", pCobranza("DLCM"))
        command.Parameters.AddWithValue("DLRCO", pCobranza("DLCO"))
        command.Parameters.AddWithValue("DLRCR", pCobranza("DLCR"))
        command.Parameters.AddWithValue("DLRER", pCobranza("DLER"))
        command.Parameters.AddWithValue("DLRFP", pCobranza("DLFP"))
        command.Parameters.AddWithValue("DLRIC", pCobranza("DLIC"))
        command.Parameters.AddWithValue("DLRID", pCobranza("DLID"))
        command.Parameters.AddWithValue("DLRMO", pCobranza("DLMO"))
        command.Parameters.AddWithValue("DLRMP", pCobranza("DLMP"))
        command.Parameters.AddWithValue("DLRNE", pCobranza("DLNE"))
        command.Parameters.AddWithValue("DLRNP", pCobranza("DLNP"))
        command.Parameters.AddWithValue("DLRST", pCobranza("DLST"))
        command.Parameters.AddWithValue("DLENL", pCobranza("DLENL"))
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub

    Public Sub InsertaNominaEntradaSalida(Codigo_proceso As String, cantidad_clientes As Integer, monto_total_soles As Double, monto_total_dolares As Double, tipo_nomina As String, tipo_formato As String, tipo_proceso As String, pUsuario As String)
        Dim connection As New SqlConnection(conexionConvenios)
        Dim strArray As String() = New String() {"EXEC InsertaNominaEntradaSalida '", Codigo_proceso, "','", Conversions.ToString(cantidad_clientes), "','", Conversions.ToString(monto_total_soles), "','", Conversions.ToString(monto_total_dolares), "','"}
        strArray(9) = tipo_nomina
        strArray(10) = "','"
        strArray(11) = tipo_formato
        strArray(12) = "','"
        strArray(13) = tipo_proceso
        strArray(14) = "','"
        strArray(15) = pUsuario
        strArray(&H10) = "'"
        Dim command As New SqlCommand(String.Concat(strArray), connection) With {
            .CommandType = CommandType.Text
        }
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub

    Public Function ObtieneCobranzas(pCodigo_proceso As String) As DataTable
        Dim lds As New DataSet()
        Dim lda As New SqlDataAdapter(String.Concat("EXEC EnvioDescuentos_AS400 '", pCodigo_proceso, "'"), conexionConvenios)
        lda.Fill(lds)
        Return lds.Tables(0)
    End Function

    Public Sub TemporalArchivoTextoInserta(pCodigo_proceso As String, pUsuario As String, pNroLinea As Integer, pData As String, pFechaFormateada As String)
        Dim connection As New SqlConnection(conexionConvenios)
        Dim cmd As New SqlCommand With {
            .Connection = connection,
            .CommandType = CommandType.StoredProcedure,
            .CommandText = "addInformacionArchivoTexto"
        }
        AgregarParametro(cmd, "@Codigo_proceso", ParameterDirection.Input, DbType.String, pCodigo_proceso)
        AgregarParametro(cmd, "@UserId", ParameterDirection.Input, DbType.String, pUsuario)
        AgregarParametro(cmd, "@orden", ParameterDirection.Input, DbType.Int32, pNroLinea)
        AgregarParametro(cmd, "@lineainformacion", ParameterDirection.Input, DbType.String, pData)
        AgregarParametro(cmd, "@dateCode", ParameterDirection.Input, DbType.String, pFechaFormateada)
        connection.Open()
        cmd.ExecuteNonQuery()
        connection.Close()
    End Sub
End Class
