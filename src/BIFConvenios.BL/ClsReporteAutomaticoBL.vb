Imports BIFConvenios.BE
Imports BIFConvenios.DO
Imports Microsoft.VisualBasic.CompilerServices
Imports Resource
Imports System
Imports System.Data

Public Class ClsReporteAutomaticoBL
    Protected objEventoSistemaBL As New BIFConvenios.BL.clsEventoSistemaBL
    Private objEventoSistema As clsEventoSistema

    <DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        Me.objEventoSistemaBL = New clsEventoSistemaBL()
    End Sub
    ' Methods
    Public Function ReporteNominaAutomaticaCabecera(ByVal idFuncionario As Integer) As DataTable
        Dim table As DataTable
        Try
            Dim arrayMensajeInicio() As String = {"Inicio del Metodo - Parametros: idFuncionario=", idFuncionario}
            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ReporteNominaAutomaticaCabecera", String.Concat(arrayMensajeInicio), "", "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

            table = Singleton(Of ClsReporteAutomaticoDO).Create.ReporteNominaAutomaticaCabecera(idFuncionario)

            Dim arrayMensajeFin() As String = {"Fin del Metodo - Parametros: idFuncionario=", idFuncionario}
            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ReporteNominaAutomaticaCabecera", String.Concat(arrayMensajeInicio), "", "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

        Catch exception1 As Exception
            Dim ex As Exception = exception1
            ProjectData.SetProjectError(ex)
            Throw ex
        End Try
        Return table
    End Function

    Public Function ReporteNominaAutomaticaCabeceraObservada(ByVal idFuncionario As Integer) As DataTable
        Dim table As DataTable
        Try
            table = Singleton(Of ClsReporteAutomaticoDO).Create.ReporteNominaAutomaticaCabeceraObservada(idFuncionario)
        Catch exception1 As Exception
            Dim ex As Exception = exception1
            ProjectData.SetProjectError(ex)
            Throw ex
        End Try
        Return table
    End Function

    Public Function ReporteNominaAutomaticaDetalle(ByVal idFuncionario As Integer) As DataTable
        Dim table As DataTable
        Try

            Dim arrayMensajeInicio() As String = {"Inicio del Metodo - Parametros: idFuncionario=", idFuncionario}
            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ReporteNominaAutomaticaDetalle", String.Concat(arrayMensajeInicio), "", "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

            table = Singleton(Of ClsReporteAutomaticoDO).Create.ReporteNominaAutomaticaDetalle(idFuncionario)

            Dim arrayMensajeFin() As String = {"Fin del Metodo - Parametros: idFuncionario=", idFuncionario}
            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ReporteNominaAutomaticaDetalle", String.Concat(arrayMensajeFin), "", "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

        Catch exception1 As Exception
            Dim ex As Exception = exception1
            ProjectData.SetProjectError(ex)
            Throw ex
        End Try
        Return table
    End Function

    Public Function ReporteNominaAutomaticaDetalleObservada(ByVal idFuncionario As Integer) As DataTable
        Dim table As DataTable
        Try
            table = Singleton(Of ClsReporteAutomaticoDO).Create.ReporteNominaAutomaticaDetalleObservada(idFuncionario)
        Catch exception1 As Exception
            Dim ex As Exception = exception1
            ProjectData.SetProjectError(ex)
            Throw ex
        End Try
        Return table
    End Function

    Public Function ReportePagoAutomaticoCabecera1(ByVal idFuncionario As Integer) As DataTable
        Dim table As DataTable
        Try
            table = Singleton(Of ClsReporteAutomaticoDO).Create.ReportePagoAutomaticoCabecera1(idFuncionario)
        Catch exception1 As Exception
            Dim ex As Exception = exception1
            ProjectData.SetProjectError(ex)
            Throw ex
        End Try
        Return table
    End Function

    Public Function ReportePagoAutomaticoCabecera2(ByVal idFuncionario As Integer) As DataTable
        Dim table As DataTable
        Try
            table = Singleton(Of ClsReporteAutomaticoDO).Create.ReportePagoAutomaticoCabecera2(idFuncionario)
        Catch exception1 As Exception
            Dim ex As Exception = exception1
            ProjectData.SetProjectError(ex)
            Throw ex
        End Try
        Return table
    End Function

    Public Function ReportePagoAutomaticoDetalle(ByVal idFuncionario As Integer) As DataTable
        Dim table As DataTable
        Try
            table = Singleton(Of ClsReporteAutomaticoDO).Create.ReportePagoAutomaticoDetalle(idFuncionario)
        Catch exception1 As Exception
            Dim ex As Exception = exception1
            ProjectData.SetProjectError(ex)
            Throw ex
        End Try
        Return table
    End Function

    Public Function ValidaExistenciaFuncionario(ByVal idFuncionario As Integer, ByVal intTipoEnvioCorreo As Integer) As DataTable
        Dim table As DataTable
        Try

            Dim arrayMensajeInicio() As String = {"Inicio del Metodo - Parametros: idFuncionario=", idFuncionario, ", intTipoEnvioCorreo=", intTipoEnvioCorreo}
            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ValidaExistenciaFuncionario", String.Concat(arrayMensajeInicio), "", "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

            table = Singleton(Of ClsReporteAutomaticoDO).Create.ValidaExistenciaFuncionario(idFuncionario, intTipoEnvioCorreo)

            Dim arrayMensajeFin() As String = {"Inicio del Metodo - Parametros: idFuncionario=", idFuncionario, ", intTipoEnvioCorreo=", intTipoEnvioCorreo}
            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ValidaExistenciaFuncionario", String.Concat(arrayMensajeFin), "", "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

        Catch exception1 As Exception
            Dim ex As Exception = exception1
            ProjectData.SetProjectError(ex)
            Throw ex
        End Try
        Return table
    End Function
End Class
