Imports BIFConvenios.BE
Imports BIFConvenios.DO
Imports Microsoft.VisualBasic.CompilerServices
Imports Resource

Public Class ClsReporteAutomaticoBL
    Protected objEventoSistemaBL As New clsEventoSistemaBL
    Private objEventoSistema As clsEventoSistema

    <DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        objEventoSistemaBL = New clsEventoSistemaBL()
    End Sub
    ' Methods
    Public Function ReporteNominaAutomaticaCabecera(idFuncionario As Integer) As DataTable
        Dim table As DataTable
        Try
            Dim arrayMensajeInicio() As String = {"Inicio del Metodo - Parametros: idFuncionario=", idFuncionario}
            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ReporteNominaAutomaticaCabecera", String.Concat(arrayMensajeInicio), "", "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

            table = Singleton(Of ClsReporteAutomaticoDO).Create.ReporteNominaAutomaticaCabecera(idFuncionario)

            Dim arrayMensajeFin() As String = {"Fin del Metodo - Parametros: idFuncionario=", idFuncionario}
            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ReporteNominaAutomaticaCabecera", String.Concat(arrayMensajeInicio), "", "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

        Catch exception1 As Exception
            Dim ex As Exception = exception1
            ProjectData.SetProjectError(ex)
            Throw ex
        End Try
        Return table
    End Function

    Public Function ReporteNominaAutomaticaCabeceraObservada(idFuncionario As Integer) As DataTable
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

    Public Function ReporteNominaAutomaticaDetalle(idFuncionario As Integer) As DataTable
        Dim table As DataTable
        Try

            Dim arrayMensajeInicio() As String = {"Inicio del Metodo - Parametros: idFuncionario=", idFuncionario}
            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ReporteNominaAutomaticaDetalle", String.Concat(arrayMensajeInicio), "", "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

            table = Singleton(Of ClsReporteAutomaticoDO).Create.ReporteNominaAutomaticaDetalle(idFuncionario)

            Dim arrayMensajeFin() As String = {"Fin del Metodo - Parametros: idFuncionario=", idFuncionario}
            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ReporteNominaAutomaticaDetalle", String.Concat(arrayMensajeFin), "", "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

        Catch exception1 As Exception
            Dim ex As Exception = exception1
            ProjectData.SetProjectError(ex)
            Throw ex
        End Try
        Return table
    End Function

    Public Function ReporteNominaAutomaticaDetalleObservada(idFuncionario As Integer) As DataTable
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

    Public Function ReportePagoAutomaticoCabecera1(idFuncionario As Integer) As DataTable
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

    Public Function ReportePagoAutomaticoCabecera2(idFuncionario As Integer) As DataTable
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

    Public Function ReportePagoAutomaticoDetalle(idFuncionario As Integer) As DataTable
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

    Public Function ValidaExistenciaFuncionario(idFuncionario As Integer, intTipoEnvioCorreo As Integer) As DataTable
        Dim table As DataTable
        Try

            Dim arrayMensajeInicio() As String = {"Inicio del Metodo - Parametros: idFuncionario=", idFuncionario, ", intTipoEnvioCorreo=", intTipoEnvioCorreo}
            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ValidaExistenciaFuncionario", String.Concat(arrayMensajeInicio), "", "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

            table = Singleton(Of ClsReporteAutomaticoDO).Create.ValidaExistenciaFuncionario(idFuncionario, intTipoEnvioCorreo)

            Dim arrayMensajeFin() As String = {"Inicio del Metodo - Parametros: idFuncionario=", idFuncionario, ", intTipoEnvioCorreo=", intTipoEnvioCorreo}
            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ValidaExistenciaFuncionario", String.Concat(arrayMensajeFin), "", "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

        Catch exception1 As Exception
            Dim ex As Exception = exception1
            ProjectData.SetProjectError(ex)
            Throw ex
        End Try
        Return table
    End Function
End Class
