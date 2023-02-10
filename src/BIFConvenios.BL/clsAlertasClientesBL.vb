Imports BIFConvenios.BE
Imports BIFConvenios.DO
Imports Microsoft.VisualBasic.CompilerServices
Imports Resource
Imports System
Imports System.Data
Public Class clsAlertasClientesBL

    Protected objEventoSistemaBL As New BIFConvenios.BL.clsEventoSistemaBL
    Private objEventoSistema As clsEventoSistema

    <DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        Me.objEventoSistemaBL = New clsEventoSistemaBL()
    End Sub
    ' Methods
    Public Function ChangeStatus(ByVal pobjAlertasClientes As clsAlertasClientes) As Integer
        Dim num As Integer
        Try
            num = Singleton(Of clsAlertasClientesDO).Create.ChangeStatus(pobjAlertasClientes)
        Catch exception1 As HandledException
            Dim ex As HandledException = exception1
            ProjectData.SetProjectError(ex)
            Throw ex
        Catch exception3 As Exception
            Dim ex As Exception = exception3
            ProjectData.SetProjectError(ex)
            Throw ex
        End Try
        Return num
    End Function

    Public Function Insert(ByVal pobjAlertasClientes As clsAlertasClientes) As Integer
        Dim num As Integer
        Try
            num = Singleton(Of clsAlertasClientesDO).Create.Insert(pobjAlertasClientes)
        Catch exception1 As HandledException
            Dim ex As HandledException = exception1
            ProjectData.SetProjectError(ex)
            Throw ex
        Catch exception3 As Exception
            Dim ex As Exception = exception3
            ProjectData.SetProjectError(ex)
            Throw ex
        End Try
        Return num
    End Function

    Public Function ObtenerAlertasClientesEnviar(ByVal pintCodigoCliente As Integer, ByVal pdecSaldoContable As Decimal, ByVal pintAnioPeriodo As Integer, ByVal pintMesPeriodo As Integer) As DataTable
        Dim table As DataTable
        Try
            Dim arrayMensajeInicio() As String = {"Inicio del Metodo - Parametros: pintCodigoCliente=", pintCodigoCliente, ", pdecSaldoContable=", pdecSaldoContable, ", pintAnioPeriodo=", pintAnioPeriodo, ", pintMesPeriodo=", pintMesPeriodo}
            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ObtenerAlertasClientesEnviar", String.Concat(arrayMensajeInicio), "", "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

            table = Singleton(Of clsAlertasClientesDO).Create.ObtenerAlertasClientesEnviar(pintCodigoCliente, pdecSaldoContable, pintAnioPeriodo, pintMesPeriodo)

            Dim arrayMensajeFin() As String = {"Fin del Metodo - Parametros: pintCodigoCliente=", pintCodigoCliente, ", pdecSaldoContable=", pdecSaldoContable, ", pintAnioPeriodo=", pintAnioPeriodo, ", pintMesPeriodo=", pintMesPeriodo}
            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ObtenerAlertasClientesEnviar", String.Concat(arrayMensajeFin), "", "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

        Catch ex1 As HandledException
            Dim ex As HandledException = ex1
            ProjectData.SetProjectError(ex)

            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Errores.ToString(), "ObtenerAlertasClientesEnviar", ex1.Message, ex1.StackTrace, "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

            Throw ex
        Catch ex3 As Exception
            Dim ex As Exception = ex3
            ProjectData.SetProjectError(ex)

            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Errores.ToString(), "ObtenerAlertasClientesEnviar", ex3.Message, ex3.StackTrace, "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

            Throw ex
        End Try
        Return table
    End Function

    Public Function ObtenerCuotasVencidasAlertasEnviar(ByVal pintCodigoIBS As Integer) As DataTable
        Dim table As DataTable
        Try
            Dim arrayMensajeInicio() As String = {"Inicio del Metodo - Parametros: pintCodigoIBS=", pintCodigoIBS}
            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ObtenerCuotasVencidasAlertasEnviar", String.Concat(arrayMensajeInicio), "", "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

            table = Singleton(Of clsAlertasClientesDO).Create.ObtenerCuotasVencidasAlertasEnviar(pintCodigoIBS)

            Dim arrayMensajeFin() As String = {"Fin del Metodo - Parametros: pintCodigoIBS=", pintCodigoIBS}
            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ObtenerCuotasVencidasAlertasEnviar", String.Concat(arrayMensajeFin), "", "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)
        Catch ex1 As HandledException
            Dim ex As HandledException = ex1
            ProjectData.SetProjectError(ex)
            Throw ex
        Catch ex3 As Exception
            Dim ex As Exception = ex3
            ProjectData.SetProjectError(ex)
            Throw ex
        End Try
        Return table
    End Function

    Public Function ObtieneAlertasClientesPorCriterio(ByVal pobjAlertasClientes As clsAlertasClientes) As DataTable
        Dim table As DataTable
        Try
            table = Singleton(Of clsAlertasClientesDO).Create.ObtieneAlertasClientesPorCriterio(pobjAlertasClientes)
        Catch exception1 As HandledException
            Dim ex As HandledException = exception1
            ProjectData.SetProjectError(ex)
            Throw ex
        Catch exception3 As Exception
            Dim ex As Exception = exception3
            ProjectData.SetProjectError(ex)
            Throw ex
        End Try
        Return table
    End Function

    Public Function Update(ByVal pobjAlertasClientes As clsAlertasClientes) As Integer
        Dim num As Integer
        Try
            num = Singleton(Of clsAlertasClientesDO).Create.Update(pobjAlertasClientes)
        Catch exception1 As HandledException
            Dim ex As HandledException = exception1
            ProjectData.SetProjectError(ex)
            Throw ex
        Catch exception3 As Exception
            Dim ex As Exception = exception3
            ProjectData.SetProjectError(ex)
            Throw ex
        End Try
        Return num
    End Function

End Class
