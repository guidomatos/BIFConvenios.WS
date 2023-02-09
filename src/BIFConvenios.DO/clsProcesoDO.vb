Imports ADODB
Imports BIFConvenios.BE
Imports DAL
Imports Microsoft.VisualBasic.CompilerServices
Imports Resource
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Reflection
Public Class clsProcesoDO
    <DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
    End Sub
    ' Methods
    Public Function ValidarFinProcesoBatch(codigo_proceso As String) As Boolean
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Dim str As String
        Try
            dasql.CommandProperties(command, "[dbo].[ValidarFinProcesoBatch]")
            dasql.AddParameter(command, "@codigo_proceso", codigo_proceso, SqlDbType.VarChar)
            str = dasql.ExecuteReader(command).Rows(0)(0).ToString
            dasql.ConnectionClose()
            dasql = Nothing
        Catch exception1 As HandledException
            Dim ex As HandledException = exception1
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            dasql = Nothing
            Throw ex
        Catch exception3 As Exception
            Dim ex As Exception = exception3
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            Throw ex
        End Try
        Return str.Equals("1")
    End Function

    Public Function ActualizaFlagCargaAutomatica(pstrTipo As String, pintFlag As Integer) As Integer
        Dim num As Integer
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[ActualizaFlagCargaAutomatica]")
            dasql.AddParameter(command, "@tipo", pstrTipo, SqlDbType.VarChar)
            dasql.AddParameter(command, "@flag", pintFlag, SqlDbType.Int)
            dasql.ExecuteNonQuery(command)
            dasql.ConnectionClose()
            dasql = Nothing
            num = 1
        Catch exception1 As HandledException
            Dim ex As HandledException = exception1
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            dasql = Nothing
            Throw ex
        Catch exception3 As Exception
            Dim ex As Exception = exception3
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            Throw ex
        End Try
        Return num
    End Function

    Public Function AdicionarProceso(pobjProceso As clsProceso) As String
        Dim str As String
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[AddProceso]")
            dasql.AddParameter(command, "@Codigo_Cliente", pobjProceso.CodigoCliente, SqlDbType.Int)
            dasql.AddParameter(command, "@Anio_periodo", pobjProceso.AnioPeriodo, SqlDbType.VarChar)
            dasql.AddParameter(command, "@Mes_Periodo", pobjProceso.MesPeriodo, SqlDbType.VarChar)
            dasql.AddParameter(command, "@Fecha_ProcesoAS400", pobjProceso.FechaProcesoAS400, SqlDbType.VarChar)
            dasql.AddParameter(command, "@usuario", pobjProceso.Usuario, SqlDbType.VarChar)
            Dim table As New DataTable
            str = dasql.ExecuteReader(command).Rows(0)("PID").ToString
            dasql.ConnectionClose()
            dasql = Nothing
        Catch exception1 As HandledException
            Dim ex As HandledException = exception1
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            dasql = Nothing
            Throw ex
        Catch exception3 As Exception
            Dim ex As Exception = exception3
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            Throw ex
        End Try
        Return str
    End Function

    Public Function ArchivoDescuentosEnProceso() As Boolean
        Dim flag As Boolean
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[ArchivoDescuentosEnProceso]")
            Dim table As New DataTable
            dasql.ConnectionClose()
            dasql = Nothing
            flag = Convert.ToBoolean(dasql.ExecuteReader(command).Rows(0)("BOOL").ToString)
        Catch exception1 As HandledException
            Dim ex As HandledException = exception1
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            dasql = Nothing
            Throw ex
        Catch exception3 As Exception
            Dim ex As Exception = exception3
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            Throw ex
        End Try
        Return flag
    End Function

    Public Function ConsultaFlagCargaAutomatica() As Boolean
        Dim flag As Boolean
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[ConsultaFlagCargaAutomatica]")
            Dim table As New DataTable
            dasql.ConnectionClose()
            dasql = Nothing
            flag = Convert.ToBoolean(dasql.ExecuteReader(command).Rows(0)("flag").ToString)
        Catch exception1 As HandledException
            Dim ex As HandledException = exception1
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            dasql = Nothing
            Throw ex
        Catch exception3 As Exception
            Dim ex As Exception = exception3
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            Throw ex
        End Try
        Return flag
    End Function

    Public Function ExportaRegistroResultadoProcesoPorFiltros(pstrCodigoProceso As String, pstrDocTrabajador As String, pstrNomTrabajador As String, pdecNumPagare As Decimal, pstrEstadoTrabajador As String, pstrZonaUse As String) As DataTable
        Dim table As DataTable
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[ExportRegistrosResultadoProcesoByFiltros]")
            dasql.AddParameter(command, "@codigo_proceso", pstrCodigoProceso, SqlDbType.UniqueIdentifier)
            dasql.AddParameter(command, "@Documento", pstrDocTrabajador, SqlDbType.VarChar)
            dasql.AddParameter(command, "@DLNE", pstrNomTrabajador, SqlDbType.VarChar)
            dasql.AddParameter(command, "@DLNP", pdecNumPagare, SqlDbType.Decimal)
            dasql.AddParameter(command, "@EstadoTrabajador", pstrEstadoTrabajador, SqlDbType.VarChar)
            dasql.AddParameter(command, "@ZonaUse", pstrZonaUse, SqlDbType.VarChar)
            Dim table2 As New DataTable
            table2 = dasql.ExecuteReader(command)
            If (table2.Rows.Count = 0) Then
                Throw New HandledException(-400, clsConstantsGeneric.NoRecords, clsConstantsGeneric.NoRecordsFull)
            End If
            dasql.ConnectionClose()
            dasql = Nothing
            table = table2
        Catch exception1 As SqlException
            Dim ex As SqlException = exception1
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            dasql = Nothing
            Throw ex
        Catch exception3 As HandledException
            Dim ex As HandledException = exception3
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            Throw ex
        End Try
        Return table
    End Function

    Public Function ExportarRegistrosResultadoProceso(pstrCodigoProceso As String, pstrDocTrabajador As String, pstrNomTrabajador As String, pdecPagare As Decimal, pstrEstadoTrabajador As String, pintZonaUse As Integer) As DataTable
        Dim table As DataTable
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[ExportRegistrosResultadoProceso]")
            dasql.AddParameter(command, "@codigo_proceso", pstrCodigoProceso, SqlDbType.VarChar)
            dasql.AddParameter(command, "@Documento", pstrDocTrabajador, SqlDbType.VarChar)
            dasql.AddParameter(command, "@DLNE", pstrNomTrabajador, SqlDbType.VarChar)
            dasql.AddParameter(command, "@DLNP", pdecPagare, SqlDbType.Decimal)
            dasql.AddParameter(command, "@EstadoTrabajador", pstrEstadoTrabajador, SqlDbType.VarChar)
            dasql.AddParameter(command, "@ZonaUse", pintZonaUse, SqlDbType.Int)
            Dim table2 As New DataTable
            table2 = dasql.ExecuteReader(command)
            If (table2.Rows.Count = 0) Then
                Throw New HandledException(-400, clsConstantsGeneric.NoRecords, clsConstantsGeneric.NoRecordsFull)
            End If
            dasql.ConnectionClose()
            dasql = Nothing
            table = table2
        Catch exception1 As SqlException
            Dim ex As SqlException = exception1
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            dasql = Nothing
            Throw ex
        Catch exception3 As HandledException
            Dim ex As HandledException = exception3
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            Throw ex
        End Try
        Return table
    End Function

    Public Function FinalProcesoCargaDescuentos(pstrCodigoProceso As String) As Boolean
        Dim flag As Boolean
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[FinalProcesoCargaDescuentos]")
            dasql.AddParameter(command, "@Codigo_proceso", pstrCodigoProceso, SqlDbType.VarChar)
            Dim table As New DataTable
            dasql.ConnectionClose()
            dasql = Nothing
            flag = Convert.ToBoolean(dasql.ExecuteReader(command).Rows(0)("BOOL").ToString)
        Catch exception1 As HandledException
            Dim ex As HandledException = exception1
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            dasql = Nothing
            Throw ex
        Catch exception3 As Exception
            Dim ex As Exception = exception3
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            Throw ex
        End Try
        Return flag
    End Function

    Public Function GetResumenProcesoDescuentos(pstrCodigoProceso As String) As DataTable
        Dim table As DataTable
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[GetResumenProcesoDescuentos]")
            dasql.AddParameter(command, "@codigo_proceso", pstrCodigoProceso, SqlDbType.VarChar)
            Dim table2 As New DataTable
            table2 = dasql.ExecuteReader(command)
            If (table2.Rows.Count = 0) Then
                Throw New HandledException(-400, clsConstantsGeneric.NoRecords, clsConstantsGeneric.NoRecordsFull)
            End If
            dasql.ConnectionClose()
            dasql = Nothing
            table = table2
        Catch exception1 As HandledException
            Dim ex As HandledException = exception1
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            dasql = Nothing
            Throw ex
        Catch exception3 As Exception
            Dim ex As Exception = exception3
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            Throw ex
        End Try
        Return table
    End Function

    Public Function IniciarDescuentoEmpresa(pstrCodigoProceso As String, pstrUsuario As String) As Integer
        Dim num As Integer
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[IniciaProcesoCargaDescuentos]")
            dasql.AddParameter(command, "@Codigo_proceso", pstrCodigoProceso, SqlDbType.VarChar)
            dasql.AddParameter(command, "@usuario", pstrUsuario, SqlDbType.VarChar)
            dasql.ExecuteNonQuery(command)
            dasql.ConnectionClose()
            dasql = Nothing
            num = 1
        Catch exception1 As HandledException
            Dim ex As HandledException = exception1
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            dasql = Nothing
            Throw ex
        Catch exception3 As Exception
            Dim ex As Exception = exception3
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            Throw ex
        End Try
        Return num
    End Function

    Public Function ObtenerDatosPagosIBSOnline(pstrCodigoProceso As String) As DataTable
        Dim table As DataTable
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[getDatosPagosIBSOnline]")
            dasql.AddParameter(command, "@codigo_proceso", pstrCodigoProceso, SqlDbType.VarChar)
            Dim table2 As New DataTable
            dasql.ConnectionClose()
            dasql = Nothing
            table = dasql.ExecuteReader(command)
        Catch exception1 As HandledException
            Dim ex As HandledException = exception1
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            dasql = Nothing
            Throw ex
        Catch exception3 As Exception
            Dim ex As Exception = exception3
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            Throw ex
        End Try
        Return table
    End Function

    Public Function ObtenerInformacionProcesoIBSByFecha(pintDia As Integer) As DataTable
        Dim table2 As DataTable
        Dim connectionString As String = New DASQL().ConnectionAS400
        Dim connection As Connection = New ConnectionClass
        Dim adapter As New OleDbDataAdapter
        Dim dataSet As New DataSet

        Try
            connection.CursorLocation = CursorLocationEnum.adUseClient
            connection.Open(connectionString, "", "", -1)
            Dim aDODBRecordSet As Recordset = New RecordsetClass
            aDODBRecordSet = connection.Execute((((((((((("SELECT DISTINCT " & " CST.CUSNA1, CAST(CST.CUSTID as CHARACTER(2)) AS CUSTID, CAST (CST.CUSIDN AS CHARACTER (12)) AS CUSIDN, e.DLCCC AS DLECC, MAX(CST.CUSCUN) AS CUSCUN, CAST ( 2000 + c.DLVCA  AS CHARACTER ( 4 ) )  AS DLEAP,  " & " CAST(c.DLVCM AS CHARACTER(2)) AS DLEMP, e.dldpg AS DLDPG, CAST(YEAR(CURRENT DATE) ") & " AS CHARACTER(4)) CONCAT CASE LENGTH(TRIM(CAST(MONTH(CURRENT DATE) AS CHARACTER(2)))) " & " WHEN 1 THEN '0' CONCAT TRIM(CAST(MONTH(CURRENT DATE) AS CHARACTER(2))) ") & " WHEN 2 THEN SUBSTRING('00' CONCAT CAST(MONTH(CURRENT DATE) AS CHARACTER(2)), 3, 2) " & " END CONCAT CASE LENGTH(TRIM(CAST(DAY(CURRENT DATE) AS CHARACTER(2)))) WHEN 1 THEN '0' CONCAT TRIM(CAST(DAY(CURRENT DATE) ") & " AS CHARACTER(2))) WHEN 2 THEN SUBSTRING('00' CONCAT CAST(DAY(CURRENT DATE) AS CHARACTER(2)), 3, 2) END AS DLEFP " & " FROM         DLCRE e INNER JOIN ") & " DLCCR r ON e.DLACC = r.DLACC INNER JOIN " & " DLCCR c ON e.DLACC = c.DLACC AND c.DLSTS = '' INNER JOIN ") & " DLCNV CNV ON (E.DLCCC = CNV.CNVCUN AND E.DLAÑO = CNV.AÑCONV AND E.DLAGC = CNV.AGCONV AND E.DLCOC = CNV.COCONV) INNER JOIN " & " CUMST CST ON (CNV.CNVCUN = CST.CUSCUN) ") & " INNER JOIN DLEMP D ON ( D.DLECUN = E.DLCCC AND D.DLEAEN = c.DLVCA AND D.DLEMEN = c.DLVCM )" & " WHERE     (trim(r.DLSTS) = '') ") & " AND e.DLDPG = " & pintDia.ToString) & " GROUP BY CST.CUSNA1, CST.CUSTID, CST.CUSIDN, e.DLCCC, e.DLAÑO, e.DLAGC, e.DLCOC, e.DLCCY, e.DLACC, e.DLCEM, e.DLNCL, e.DLAPP, e.DLAPM, ") & " e.DLPRN, e.DLSGN, e.DLCCR, e.DLPLA, e.DLCUS, c.DLNCT, c.DLVCA, c.DLVCM, c.DLVCD, e.DLSTS, e.DLDPG " & " ORDER BY 1, DLEMP"), Missing.Value, -1)
            aDODBRecordSet.ActiveConnection = Nothing
            connection.Close()
            connection = Nothing
            adapter.Fill(dataSet, aDODBRecordSet, "dtResult")
            Dim table As DataTable = dataSet.Tables(0)
            If (table.Rows.Count = 0) Then
                Throw New HandledException(-400, clsConstantsGeneric.NoRecords, clsConstantsGeneric.NoRecordsFull)
            End If
            table2 = table
        Catch exception1 As HandledException
            Dim ex As HandledException = exception1
            ProjectData.SetProjectError(ex)
            connection.Close()
            Throw ex
        End Try
        Return table2
    End Function

    Public Function ObtenerInformacionProcesosIBS(pstrFiltro As String) As DataTable
        Dim table2 As DataTable
        Dim connectionString As String = New DASQL().ConnectionAS400
        Dim connection As Connection = New ConnectionClass
        Dim adapter As New OleDbDataAdapter
        Dim dataSet As New DataSet

        Try
            connection.CursorLocation = CursorLocationEnum.adUseClient
            connection.Open(connectionString, "", "", -1)
            Dim str2 As String = ((((((("SELECT DISTINCT " & " CST.CUSNA1, CAST(CST.CUSTID as CHARACTER(2)) AS CUSTID, CAST (CST.CUSIDN AS CHARACTER (12)) AS CUSIDN, e.DLCCC AS DLECC, " & ChrW(9) & "CAST ( 2000 + c.DLVCA  AS CHARACTER ( 4 ) )  AS DLEAP, MAX(CST.CUSCUN) AS CUSCUN, " & " CAST(c.DLVCM AS CHARACTER(2)) AS DLEMP, CAST(YEAR(CURRENT DATE) ") & " AS CHARACTER(4)) CONCAT CASE LENGTH(TRIM(CAST(MONTH(CURRENT DATE) AS CHARACTER(2)))) " & " WHEN 1 THEN '0' CONCAT TRIM(CAST(MONTH(CURRENT DATE) AS CHARACTER(2))) ") & " WHEN 2 THEN SUBSTRING('00' CONCAT CAST(MONTH(CURRENT DATE) AS CHARACTER(2)), 3, 2) " & " END CONCAT CASE LENGTH(TRIM(CAST(DAY(CURRENT DATE) AS CHARACTER(2)))) WHEN 1 THEN '0' CONCAT TRIM(CAST(DAY(CURRENT DATE) ") & " AS CHARACTER(2))) WHEN 2 THEN SUBSTRING('00' CONCAT CAST(DAY(CURRENT DATE) AS CHARACTER(2)), 3, 2) END AS DLEFP " & " FROM         DLCRE e INNER JOIN ") & " DLCCR r ON e.DLACC = r.DLACC INNER JOIN " & " DLCCR c ON e.DLACC = c.DLACC AND c.DLSTS = '' INNER JOIN ") & " DLCNV CNV ON (E.DLCCC = CNV.CNVCUN AND E.DLAÑO = CNV.AÑCONV AND E.DLAGC = CNV.AGCONV AND E.DLCOC = CNV.COCONV) INNER JOIN " & " CUMST CST ON (CNV.CNVCUN = CST.CUSCUN) ") & " INNER JOIN DLEMP D ON ( D.DLECUN = E.DLCCC AND D.DLEAEN = c.DLVCA AND D.DLEMEN = c.DLVCM )" & " WHERE     (trim(r.DLSTS) = '') ")
            If (Trim(pstrFiltro) <> "") Then
                str2 = (str2 & " AND CST.CUSNA1 LIKE '" & Strings.Trim(pstrFiltro) & "%' ")
            End If
            str2 = str2 & " GROUP BY CST.CUSNA1, CST.CUSTID, CST.CUSIDN, e.DLCCC, e.DLAÑO, e.DLAGC, e.DLCOC, e.DLCCY, e.DLACC, e.DLCEM, e.DLNCL, e.DLAPP, e.DLAPM, " & " e.DLPRN, e.DLSGN, e.DLCCR, e.DLPLA, e.DLCUS, c.DLNCT, c.DLVCA, c.DLVCM, c.DLVCD, e.DLSTS " & " ORDER BY 1, DLEMP"
            Dim aDODBRecordSet As Recordset = New RecordsetClass
            aDODBRecordSet = connection.Execute(str2, Missing.Value, -1)
            aDODBRecordSet.ActiveConnection = Nothing
            connection.Close()
            connection = Nothing
            adapter.Fill(dataSet, aDODBRecordSet, "dtResult")
            Dim table As DataTable = dataSet.Tables(0)
            If (table.Rows.Count = 0) Then
                Throw New HandledException(-400, clsConstantsGeneric.NoRecords, clsConstantsGeneric.NoRecordsFull)
            End If
            table2 = table
        Catch exception1 As HandledException
            Dim ex As HandledException = exception1
            ProjectData.SetProjectError(ex)
            connection.Close()
            Throw ex
        End Try
        Return table2
    End Function

    Public Function ObtenerListaClienteUltimoProceso() As DataTable
        Dim table As DataTable
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[GetListaClienteUltimoProceso]")
            Dim table2 As New DataTable
            'dasql.ConnectionClose()
            'dasql = Nothing
            table = dasql.ExecuteReader(command)
        Catch exception1 As SqlException
            Dim ex As SqlException = exception1
            ProjectData.SetProjectError(ex)
            'dasql.ConnectionClose()
            'dasql = Nothing
            Throw ex
        Catch exception3 As HandledException
            Dim ex As HandledException = exception3
            ProjectData.SetProjectError(ex)
            'dasql.ConnectionClose()
            'dasql = Nothing
            Throw ex
        Finally
            If dasql IsNot Nothing Then
                dasql.ConnectionClose()
            End If
        End Try
        Return table
    End Function

    Public Function ObtenerListaProcesosByCodigoIBS(pstrCodigoIBS As String) As DataTable
        Dim table2 As DataTable
        Dim connectionString As String = New DASQL().ConnectionAS400
        Dim connection As Connection = New ConnectionClass
        Dim adapter As New OleDbDataAdapter
        Dim dataSet As New DataSet

        Try
            connection.CursorLocation = CursorLocationEnum.adUseClient
            connection.Open(connectionString, "", "", -1)
            Dim aDODBRecordSet As Recordset = New RecordsetClass
            aDODBRecordSet = connection.Execute((((((((((("SELECT DISTINCT " & " CST.CUSNA1, CAST(CST.CUSTID as CHARACTER(2)) AS CUSTID, CAST (CST.CUSIDN AS CHARACTER (12)) AS CUSIDN, e.DLCCC AS DLECC, " & ChrW(9) & "CAST ( 2000 + c.DLVCA  AS CHARACTER ( 4 ) )  AS DLEAP, MAX(CST.CUSCUN) AS CUSCUN, " & " CAST(c.DLVCM AS CHARACTER(2)) AS DLEMP, CAST(YEAR(CURRENT DATE) ") & " AS CHARACTER(4)) CONCAT CASE LENGTH(TRIM(CAST(MONTH(CURRENT DATE) AS CHARACTER(2)))) " & " WHEN 1 THEN '0' CONCAT TRIM(CAST(MONTH(CURRENT DATE) AS CHARACTER(2))) ") & " WHEN 2 THEN SUBSTRING('00' CONCAT CAST(MONTH(CURRENT DATE) AS CHARACTER(2)), 3, 2) " & " END CONCAT CASE LENGTH(TRIM(CAST(DAY(CURRENT DATE) AS CHARACTER(2)))) WHEN 1 THEN '0' CONCAT TRIM(CAST(DAY(CURRENT DATE) ") & " AS CHARACTER(2))) WHEN 2 THEN SUBSTRING('00' CONCAT CAST(DAY(CURRENT DATE) AS CHARACTER(2)), 3, 2) END AS DLEFP " & " FROM         DLCRE e INNER JOIN ") & " DLCCR r ON e.DLACC = r.DLACC INNER JOIN " & " DLCCR c ON e.DLACC = c.DLACC AND c.DLSTS = '' INNER JOIN ") & " DLCNV CNV ON (E.DLCCC = CNV.CNVCUN AND E.DLAÑO = CNV.AÑCONV AND E.DLAGC = CNV.AGCONV AND E.DLCOC = CNV.COCONV) INNER JOIN " & " CUMST CST ON (CNV.CNVCUN = CST.CUSCUN) ") & " INNER JOIN DLEMP D ON ( D.DLECUN = E.DLCCC AND D.DLEAEN = c.DLVCA AND D.DLEMEN = c.DLVCM )" & " WHERE     (trim(r.DLSTS) = '') ") & " AND CST.CUSCUN = " & Strings.Trim(pstrCodigoIBS)) & " GROUP BY CST.CUSNA1, CST.CUSTID, CST.CUSIDN, e.DLCCC, e.DLAÑO, e.DLAGC, e.DLCOC, e.DLCCY, e.DLACC, e.DLCEM, e.DLNCL, e.DLAPP, e.DLAPM, ") & " e.DLPRN, e.DLSGN, e.DLCCR, e.DLPLA, e.DLCUS, c.DLNCT, c.DLVCA, c.DLVCM, c.DLVCD, e.DLSTS " & " ORDER BY 1, DLEMP"), Missing.Value, -1)
            aDODBRecordSet.ActiveConnection = Nothing
            connection.Close()
            connection = Nothing
            adapter.Fill(dataSet, aDODBRecordSet, "dtResult")
            Dim table As DataTable = dataSet.Tables(0)
            If (table.Rows.Count = 0) Then
                Throw New HandledException(-400, clsConstantsGeneric.NoRecords, clsConstantsGeneric.NoRecordsFull)
            End If
            table2 = table
        Catch exception1 As HandledException
            Dim ex As HandledException = exception1
            ProjectData.SetProjectError(ex)
            connection.Close()
            Throw ex
        End Try
        Return table2
    End Function

    Public Function ObtenerListaProcesosDescuentoCompletadoByCodigoProceso(pstrAnioPeriodo As String, pstrMesPeriodo As String, pstrCodigoProceso As String) As DataTable
        Dim table As DataTable
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[GetProcesosDescuentoCompletadoByProceso]")
            dasql.AddParameter(command, "@Anio_periodo", pstrAnioPeriodo, SqlDbType.VarChar)
            dasql.AddParameter(command, "@Mes_Periodo", pstrMesPeriodo, SqlDbType.VarChar)
            dasql.AddParameter(command, "@Codigo_proceso", pstrCodigoProceso, SqlDbType.VarChar)
            Dim table2 As New DataTable
            table2 = dasql.ExecuteReader(command)
            If (table2.Rows.Count = 0) Then
                Throw New HandledException(-400, clsConstantsGeneric.NoRecords, clsConstantsGeneric.NoRecordsFull)
            End If
            dasql.ConnectionClose()
            dasql = Nothing
            table = table2
        Catch exception1 As SqlException
            Dim ex As SqlException = exception1
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            dasql = Nothing
            Throw ex
        Catch exception3 As HandledException
            Dim ex As HandledException = exception3
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            Throw ex
        End Try
        Return table
    End Function

    Public Function ObtenerListaProcesosEsperaArchivoDescuento(pstrAnioPeriodo As String, pstrMesPeriodo As String) As DataTable
        Dim table As DataTable
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[GetProcesosEsperaArchivoDescuento]")
            dasql.AddParameter(command, "@Anio_periodo", pstrAnioPeriodo, SqlDbType.VarChar)
            dasql.AddParameter(command, "@Mes_Periodo", pstrMesPeriodo, SqlDbType.VarChar)
            Dim table2 As New DataTable
            table2 = dasql.ExecuteReader(command)
            If (table2.Rows.Count = 0) Then
                Throw New HandledException(-400, clsConstantsGeneric.NoRecords, clsConstantsGeneric.NoRecordsFull)
            End If
            dasql.ConnectionClose()
            dasql = Nothing
            table = table2
        Catch exception1 As SqlException
            Dim ex As SqlException = exception1
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            dasql = Nothing
            Throw ex
        Catch exception3 As HandledException
            Dim ex As HandledException = exception3
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            Throw ex
        End Try
        Return table
    End Function

    Public Function ObtenerListaProcesosEsperaArchivoDescuentoByCliente(pstrAnioPeriodo As String, pstrMesPeriodo As String, pintCodigoCliente As Integer) As DataTable
        Dim table As DataTable
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[GetProcesosEsperaArchivoDescuentoByCliente]")
            dasql.AddParameter(command, "@vAnioPeriodo", pstrAnioPeriodo, SqlDbType.VarChar)
            dasql.AddParameter(command, "@vMesPeriodo", pstrMesPeriodo, SqlDbType.VarChar)
            dasql.AddParameter(command, "@vCodigoCliente", pintCodigoCliente, SqlDbType.Int)
            Dim table2 As New DataTable
            table2 = dasql.ExecuteReader(command)
            If (table2.Rows.Count = 0) Then
                Throw New HandledException(-400, clsConstantsGeneric.NoRecords, clsConstantsGeneric.NoRecordsFull)
            End If
            dasql.ConnectionClose()
            dasql = Nothing
            table = table2
        Catch exception1 As SqlException
            Dim ex As SqlException = exception1
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            dasql = Nothing
            Throw ex
        Catch exception3 As HandledException
            Dim ex As HandledException = exception3
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            Throw ex
        End Try
        Return table
    End Function

    Public Function ObtenerListaProcesosEsperaArchivoDescuentoByNombreCliente(pstrAnioPeriodo As String, pstrMesPeriodo As String, pstrNombreCliente As String) As DataTable
        Dim table As DataTable
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[GetProcesosEsperaArchivoDescuentoByNombreCliente]")
            dasql.AddParameter(command, "@vAnioPeriodo", pstrAnioPeriodo, SqlDbType.VarChar)
            dasql.AddParameter(command, "@vMesPeriodo", pstrMesPeriodo, SqlDbType.VarChar)
            dasql.AddParameter(command, "@vNombreCliente", pstrNombreCliente, SqlDbType.VarChar)
            Dim table2 As New DataTable
            table2 = dasql.ExecuteReader(command)
            If (table2.Rows.Count = 0) Then
                Throw New HandledException(-400, clsConstantsGeneric.NoRecords, clsConstantsGeneric.NoRecordsFull)
            End If
            dasql.ConnectionClose()
            dasql = Nothing
            table = table2
        Catch exception1 As SqlException
            Dim ex As SqlException = exception1
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            dasql = Nothing
            Throw ex
        Catch exception3 As HandledException
            Dim ex As HandledException = exception3
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            Throw ex
        End Try
        Return table
    End Function

    Public Function ObtenerProcesosRealizadosActual() As DataTable
        Dim table As DataTable
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[GetProcesosRealizados]")
            Dim table2 As New DataTable
            table2 = dasql.ExecuteReader(command)
            If (table2.Rows.Count = 0) Then
                Throw New HandledException(-400, clsConstantsGeneric.NoRecords, clsConstantsGeneric.NoRecordsFull)
            End If
            dasql.ConnectionClose()
            dasql = Nothing
            table = table2
        Catch exception1 As SqlException
            Dim ex As SqlException = exception1
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            dasql = Nothing
            Throw ex
        Catch exception3 As HandledException
            Dim ex As HandledException = exception3
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            Throw ex
        End Try
        Return table
    End Function

    Public Function ObtenerRegistrosResultadoProcesoDescuentosPagoAutomatico(pintCodigoProcesoAutomatico As Integer) As DataTable
        Dim table As DataTable
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[GetRegistrosResultadoProcesoDescuentosPagoAutomatico]")
            dasql.AddParameter(command, "@@iProcesoAutomaticoId", pintCodigoProcesoAutomatico, SqlDbType.Int)
            Dim table2 As New DataTable
            table2 = dasql.ExecuteReader(command)
            If (table2.Rows.Count = 0) Then
                Throw New HandledException(-400, clsConstantsGeneric.NoRecords, clsConstantsGeneric.NoRecordsFull)
            End If
            dasql.ConnectionClose()
            dasql = Nothing
            table = table2
        Catch exception1 As HandledException
            Dim ex As HandledException = exception1
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            dasql = Nothing
            Throw ex
        Catch exception3 As Exception
            Dim ex As Exception = exception3
            ProjectData.SetProjectError(ex)
            dasql.ConnectionClose()
            Throw ex
        End Try
        Return table
    End Function

    Public Function ObtenerResumenPagosIBS(codEmpresa As String, fechaInicial As String, fechaFinal As String, lote As String) As DataTable
        Dim table2 As DataTable
        Dim connectionString As String = New DASQL().ConnectionAS400
        Dim connection As Connection = New ConnectionClass
        Dim adapter As New OleDbDataAdapter
        Dim dataSet As New DataSet

        Try
            connection.CursorLocation = CursorLocationEnum.adUseClient
            connection.Open(connectionString, "", "", -1)
            Dim strArray As String() = New String() {"SELECT  DLEMC, DLCTC, DLCNP, SUM((CASE WHEN DLCCP <> '", lote, "' THEN DLCIC ELSE 0 END) * (CASE WHEN DLCTY = 'R' THEN - 1 ELSE 1 END)) AS IMPORTE, COUNT(1) AS PAGOS,  SUM(CASE WHEN DLCPP = 'B' THEN DLCIC * (CASE WHEN DLCTY = 'R' THEN - 1 ELSE 1 END) ELSE 0 END) AS PAGOVENTANILLA,  SUM(CASE WHEN DLCPP = 'I' THEN DLCIC * (CASE WHEN DLCTY = 'R' THEN - 1 ELSE 1 END) ELSE 0 END) AS PAGOINTERNET,  SUM(CASE WHEN DLCPP = 'A' THEN(CASE WHEN DLCCP <> '", lote, "' THEN DLCIC ELSE 0 END) * (CASE WHEN DLCTY = 'R' THEN - 1 ELSE 1 END) ELSE 0 END) AS PAGOIBS,  SUM(CASE WHEN DLCPP = 'A' THEN(CASE WHEN DLCCP = '", lote, "' THEN DLCIC ELSE 0 END) * (CASE WHEN DLCTY = 'R' THEN - 1 ELSE 1 END) ELSE 0 END) AS PAGOIBSPROCESOCOBRANZA  FROM DLCPG WHERE     (DLEMC = '", codEmpresa, "')  AND CAST(2000 + DLCAP AS CHARACTER(4)) CONCAT CASE WHEN LENGTH(TRIM(CAST(DLCMp AS CHARACTER(2)))) = 1 THEN            '0' CONCAT TRIM(CAST(DLCMP AS CHARACTER(2))) ELSE TRIM(CAST(DLCMP AS CHARACTER(2)))  END CONCAT CASE WHEN LENGTH(TRIM(CAST(DLCdp AS CHARACTER(2)))) = 1 THEN '0' CONCAT TRIM(CAST(DLCdp AS CHARACTER(2)))  ELSE TRIM(CAST(DLCdp AS CHARACTER(2))) END BETWEEN '"}
            strArray(9) = fechaInicial
            strArray(10) = "' AND '"
            strArray(11) = fechaFinal
            strArray(12) = "'  GROUP BY DLEMC, DLCTC, DLCNP  ORDER BY dlcnp "
            Dim aDODBRecordSet As Recordset = CType(New RecordsetClass, Recordset)
            aDODBRecordSet = connection.Execute(String.Concat(strArray), Missing.Value, -1)
            aDODBRecordSet.ActiveConnection = Nothing
            connection.Close()
            connection = Nothing
            adapter.Fill(dataSet, aDODBRecordSet, "ResumenDLCPG")
            Dim table As DataTable = dataSet.Tables(0)
            If (table.Rows.Count = 0) Then
                Throw New HandledException(-400, clsConstantsGeneric.NoRecords, clsConstantsGeneric.NoRecordsFull)
            End If
            table2 = table
        Catch exception1 As HandledException
            Dim ex As HandledException = exception1
            ProjectData.SetProjectError(ex)
            connection.Close()
            Throw ex
        End Try
        Return table2
    End Function

    Public Function ObtenerResumenProcesoIBS(codEmpresa As String, fechaInicial As String, fechaFinal As String) As DataTable
        Dim table2 As DataTable
        Dim connectionString As String = New DASQL().ConnectionAS400
        Dim connection As Connection = New ConnectionClass
        Dim adapter As New OleDbDataAdapter
        Dim dataSet As New DataSet

        Try
            connection.CursorLocation = CursorLocationEnum.adUseClient
            connection.Open(connectionString, "", "", -1)
            Dim strArray As String() = New String() {"SELECT DISTINCT A.ACMCUN, t.TTRACC, t.TTRACR, SUM(t.TTRAMT) AS TTRAMTS, DLS.DEASTS  FROM TTRAN t INNER JOIN  DEALS DLS ON t.TTRACC = DLS.DEAACC INNER JOIN  ACMST A ON A.ACMACC = DLS.DEARAC  WHERE CAST(2000 + t.TTRBDY AS CHARACTER(4)) CONCAT CASE WHEN LENGTH(TRIM(CAST(t.TTRBDM AS CHARACTER(2))))  = 1 THEN '0' CONCAT TRIM(CAST(t.TTRBDM AS CHARACTER(2))) ELSE TRIM(CAST(t.TTRBDM AS CHARACTER(2)))  END CONCAT CASE WHEN LENGTH(TRIM(CAST(t.TTRBDD AS CHARACTER(2)))) = 1 THEN '0' CONCAT TRIM(CAST(t.TTRBDD AS CHARACTER(2)))  ELSE TRIM(CAST(t.TTRBDD AS CHARACTER(2))) END BETWEEN '", fechaInicial, "' AND '", fechaFinal, "' AND (DLS.DEATYP = 'CONV')  AND A.ACMCUN = ", codEmpresa, " GROUP BY A.ACMCUN, t.TTRACC, t.TTRACR, DLS.DEASTS UNION SELECT DISTINCT A.ACMCUN, t.TRAACR, 0, SUM(t.TRAAMT) AS TTRAMTS, DLS.DEASTS  FROM TRANS t INNER JOIN  DEALS DLS ON t.TRAACR = DLS.DEAACC INNER JOIN  ACMST A ON A.ACMACC = DLS.DEARAC  WHERE CAST(2000 + t.TRABDY AS CHARACTER(4)) CONCAT CASE WHEN LENGTH(TRIM(CAST(t.TRABDM AS CHARACTER(2))))  = 1 THEN '0' CONCAT TRIM(CAST(t.TRABDM AS CHARACTER(2))) ELSE TRIM(CAST(t.TRABDM AS CHARACTER(2)))  END CONCAT CASE WHEN LENGTH(TRIM(CAST(t.TRABDD AS CHARACTER(2)))) = 1 THEN '0' CONCAT TRIM(CAST(t.TRABDD AS CHARACTER(2)))  ELSE TRIM(CAST(t.TRABDD AS CHARACTER(2))) END BETWEEN '", fechaInicial, "' AND '"}
            strArray(9) = fechaFinal
            strArray(10) = "' AND (DLS.DEATYP = 'CONV')  AND A.ACMCUN = "
            strArray(11) = codEmpresa
            strArray(12) = " AND TRACDE = '3Y' and TRANAR LIKE 'PAGO CUOTA%' GROUP BY A.ACMCUN, t.TRAACR, 0, DLS.DEASTS"
            Dim aDODBRecordSet As Recordset = New RecordsetClass
            aDODBRecordSet = connection.Execute(String.Concat(strArray), Missing.Value, -1)
            aDODBRecordSet.ActiveConnection = Nothing
            connection.Close()
            connection = Nothing
            adapter.Fill(dataSet, aDODBRecordSet, "ResumenTD")
            Dim table As DataTable = dataSet.Tables(0)
            If (table.Rows.Count = 0) Then
                Throw New HandledException(-400, clsConstantsGeneric.NoRecords, clsConstantsGeneric.NoRecordsFull)
            End If
            table2 = table
        Catch exception1 As HandledException
            Dim ex As HandledException = exception1
            ProjectData.SetProjectError(ex)
            connection.Close()
            Throw ex
        End Try
        Return table2
    End Function

    Public Function ObtieneRegistroResultadoProcesoPorFiltros(pstrCodigoProceso As String, pstrDocTrabajador As String, pstrNomTrabajador As String, pdecNumPagare As Decimal, pstrEstadoTrabajador As String, pstrZonaUse As String) As DataTable
        Dim dataTable As DataTable
        Dim oCon As New DASQL()
        Dim oCommand As New SqlCommand()
        Try
            oCon.CommandProperties(oCommand, "[dbo].[GetRegistrosResultadoProcesoByFiltros]")
            oCon.AddParameter(oCommand, "@codigo_proceso", pstrCodigoProceso, SqlDbType.UniqueIdentifier)
            oCon.AddParameter(oCommand, "@Documento", pstrDocTrabajador, SqlDbType.VarChar)
            oCon.AddParameter(oCommand, "@DLNE", pstrNomTrabajador, SqlDbType.VarChar)
            oCon.AddParameter(oCommand, "@DLNP", pdecNumPagare, SqlDbType.Decimal)
            oCon.AddParameter(oCommand, "@EstadoTrabajador", pstrEstadoTrabajador, SqlDbType.VarChar)
            oCon.AddParameter(oCommand, "@ZonaUse", pstrZonaUse, SqlDbType.VarChar)
            Dim _dt As DataTable = New DataTable()
            _dt = oCon.ExecuteReader(oCommand)
            If (_dt.Rows.Count = 0) Then
                Throw New HandledException(-400, clsConstantsGeneric.NoRecords, clsConstantsGeneric.NoRecordsFull)
            End If
            oCon.ConnectionClose()
            oCon = Nothing
            dataTable = _dt
        Catch sqlException As SqlException
            ProjectData.SetProjectError(sqlException)
            Dim ex1 As SqlException = sqlException
            oCon.ConnectionClose()
            oCon = Nothing
            Throw ex1
        Catch handledException As HandledException
            ProjectData.SetProjectError(handledException)
            Dim ex As HandledException = handledException
            oCon.ConnectionClose()
            Throw ex
        End Try
        Return dataTable
    End Function
End Class
