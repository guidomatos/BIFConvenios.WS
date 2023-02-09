Imports DAL
Imports Microsoft.VisualBasic.CompilerServices
Imports Resource
Imports System.Data.SqlClient
Public Class ClsReporteAutomaticoDO
    <DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
    End Sub
    ' Methods
    Public Function ReporteNominaAutomaticaCabecera(idFuncionario As Integer) As DataTable
        Dim table As DataTable
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[ReporteNominaAutomaticaCabecera]")
            dasql.AddParameter(command, "@idFuncionario", idFuncionario, SqlDbType.Int)
            Dim table2 As New DataTable

            table = dasql.ExecuteReader(command)
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
            dasql = Nothing
            Throw ex
        Finally
            dasql.ConnectionClose()
        End Try
        Return table
    End Function

    Public Function ReporteNominaAutomaticaCabeceraObservada(idFuncionario As Integer) As DataTable
        Dim table As DataTable
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[ReporteNominaAutomaticaCabeceraObservada]")
            dasql.AddParameter(command, "@idFuncionario", idFuncionario, SqlDbType.Int)
            Dim table2 As New DataTable
            dasql.ConnectionClose()
            dasql = Nothing
            table = dasql.ExecuteReader(command)
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

    Public Function ReporteNominaAutomaticaDetalle(idFuncionario As Integer) As DataTable
        Dim table As DataTable
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[ReporteNominaAutomaticaDetalle]")
            dasql.AddParameter(command, "@idFuncionario", idFuncionario, SqlDbType.Int)
            Dim table2 As New DataTable
            table = dasql.ExecuteReader(command)
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
            dasql = Nothing
            Throw ex
        Finally
            dasql.ConnectionClose()
        End Try
        Return table
    End Function

    Public Function ReporteNominaAutomaticaDetalleObservada(idFuncionario As Integer) As DataTable
        Dim table As DataTable
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[ReporteNominaAutomaticaDetalleObservada]")
            dasql.AddParameter(command, "@idFuncionario", idFuncionario, SqlDbType.Int)
            Dim table2 As New DataTable
            dasql.ConnectionClose()
            dasql = Nothing
            table = dasql.ExecuteReader(command)
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

    Public Function ReportePagoAutomaticoCabecera1(idFuncionario As Integer) As DataTable
        Dim table As DataTable
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[ReportesPagoAutomaticoCabecera1]")
            dasql.AddParameter(command, "@idFuncionario", idFuncionario, SqlDbType.Int)
            Dim table2 As New DataTable
            dasql.ConnectionClose()
            dasql = Nothing
            table = dasql.ExecuteReader(command)
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

    Public Function ReportePagoAutomaticoCabecera2(idFuncionario As Integer) As DataTable
        Dim table As DataTable
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[ReportesPagoAutomaticoCabecera2]")
            dasql.AddParameter(command, "@idFuncionario", idFuncionario, SqlDbType.Int)
            Dim table2 As New DataTable
            dasql.ConnectionClose()
            dasql = Nothing
            table = dasql.ExecuteReader(command)
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

    Public Function ReportePagoAutomaticoDetalle(idFuncionario As Integer) As DataTable
        Dim table As DataTable
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "[dbo].[ReportesPagoAutomaticoDetalle]")
            dasql.AddParameter(command, "@idFuncionario", idFuncionario, SqlDbType.Int)
            Dim table2 As New DataTable
            dasql.ConnectionClose()
            dasql = Nothing
            table = dasql.ExecuteReader(command)
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

    Public Function ValidaExistenciaFuncionario(idFuncionario As Integer, intTipoEnvioCorreo As Integer) As DataTable
        Dim table As DataTable
        Dim dasql As New DASQL
        Dim command As New SqlCommand
        Try
            dasql.CommandProperties(command, "ValidaExistenciaFuncionario")
            dasql.AddParameter(command, "@idFuncionario", idFuncionario, SqlDbType.Int)

            'dasql.AddParameter(command, "@iTipoEnvioCorreo", intTipoEnvioCorreo, SqlDbType.Int)

            Dim table2 As New DataTable
            table = dasql.ExecuteReader(command)
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
            dasql = Nothing
            Throw ex
        Finally
            dasql.ConnectionClose()
        End Try
        Return table
    End Function
End Class
