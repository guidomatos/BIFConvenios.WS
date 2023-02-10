Imports BIFConvenios.BE
Imports BIFConvenios.DO
Imports Microsoft.VisualBasic.CompilerServices
Imports Resource
Imports System
Imports System.Data

Public Class clsProcesoBL

    Protected objEventoSistemaBL As New BIFConvenios.BL.clsEventoSistemaBL
    Private objEventoSistema As clsEventoSistema

    <DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        Me.objEventoSistemaBL = New clsEventoSistemaBL()
    End Sub
    ' Methods
    Public Function ValidarFinProcesoBatch(ByVal codigo_proceso As String) As Boolean
        Dim bol As Boolean
        Try
            bol = Singleton(Of clsProcesoDO).Create.ValidarFinProcesoBatch(codigo_proceso)
        Catch exception1 As HandledException
            Dim ex As HandledException = exception1
            ProjectData.SetProjectError(ex)
            Throw ex
        Catch exception3 As Exception
            Dim ex As Exception = exception3
            ProjectData.SetProjectError(ex)
            Throw ex
        End Try
        Return bol
    End Function

    Public Function ActualizaFlagCargaAutomatica(ByVal pstrTipo As String, ByVal pintFlag As Integer) As Integer
        Dim num As Integer
        Try
            num = Singleton(Of clsProcesoDO).Create.ActualizaFlagCargaAutomatica(pstrTipo, pintFlag)
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

    Public Function AdicionarProceso(ByVal pobjProceso As clsProceso) As String
        Dim str As String
        Try
            str = Singleton(Of clsProcesoDO).Create.AdicionarProceso(pobjProceso)
        Catch exception1 As HandledException
            Dim ex As HandledException = exception1
            ProjectData.SetProjectError(ex)
            Throw ex
        Catch exception3 As Exception
            Dim ex As Exception = exception3
            ProjectData.SetProjectError(ex)
            Throw ex
        End Try
        Return str
    End Function

    Public Function DevolverObjeto(ByVal pstrCodigoCliente As String, ByVal pstrAnio As String, ByVal pstrMes As String, ByVal pstrFechaProcesoAS400 As String, ByVal pstrUsuario As String) As clsProceso
        Dim proceso2 As New clsProceso
        proceso2.CodigoCliente = Conversions.ToInteger(pstrCodigoCliente)
        proceso2.AnioPeriodo = pstrAnio
        proceso2.MesPeriodo = pstrMes
        proceso2.FechaProcesoAS400 = pstrFechaProcesoAS400
        proceso2.Usuario = pstrUsuario
        Return proceso2
    End Function

    Public Function ExportaRegistroResultadoProcesoPorFiltros(ByVal pstrCodigoProceso As String, ByVal pstrDocTrabajador As String, ByVal pstrNomTrabajador As String, ByVal pdecNumPagare As Decimal, ByVal pstrEstadoTrabajador As String, ByVal pstrZonaUse As String) As DataTable
        Dim table As DataTable
        Try
            table = Singleton(Of clsProcesoDO).Create.ExportaRegistroResultadoProcesoPorFiltros(pstrCodigoProceso, pstrDocTrabajador, pstrNomTrabajador, pdecNumPagare, pstrEstadoTrabajador, pstrZonaUse)
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

    Public Function ExportarRegistrosResultadoProceso(ByVal pstrCodigoProceso As String, ByVal pstrDocTrabajador As String, ByVal pstrNomTrabajador As String, ByVal pdecPagare As Decimal, ByVal pstrEstadoTrabajador As String, ByVal pintZonaUse As Integer) As DataTable
        Dim table As DataTable
        Try
            Dim arrayMensajeInicio() As String = {"Inicio del Metodo - Parametros: pstrCodigoProceso=", pstrCodigoProceso, ", pstrDocTrabajador=", pstrDocTrabajador, ", pstrNomTrabajador=", pstrNomTrabajador, ", pdecPagare=", pdecPagare, ", pstrEstadoTrabajador=", pstrEstadoTrabajador, ", pintZonaUse=", pintZonaUse}
            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ExportarRegistrosResultadoProceso", String.Concat(arrayMensajeInicio), "", "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

            table = Singleton(Of clsProcesoDO).Create.ExportarRegistrosResultadoProceso(pstrCodigoProceso, pstrDocTrabajador, pstrNomTrabajador, pdecPagare, pstrEstadoTrabajador, pintZonaUse)

            Dim arrayMensajeFin() As String = {"Fin del Metodo - Parametros: pstrCodigoProceso=", pstrCodigoProceso, ", pstrDocTrabajador=", pstrDocTrabajador, ", pstrNomTrabajador=", pstrNomTrabajador, ", pdecPagare=", pdecPagare, ", pstrEstadoTrabajador=", pstrEstadoTrabajador, ", pintZonaUse=", pintZonaUse}
            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ExportarRegistrosResultadoProceso", String.Concat(arrayMensajeFin), "", "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

        Catch ex1 As HandledException
            Dim ex As HandledException = ex1
            ProjectData.SetProjectError(ex)

            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Errores.ToString(), "ExportarRegistrosResultadoProceso", ex1.Message, ex1.StackTrace, "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

            Throw ex
        Catch ex3 As Exception
            Dim ex As Exception = ex3
            ProjectData.SetProjectError(ex)

            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Errores.ToString(), "ExportarRegistrosResultadoProceso", ex3.Message, ex3.StackTrace, "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

            Throw ex
        End Try
        Return table
    End Function

    Public Function ObtenerDatosPagosIBSOnline(ByVal pstrCodigoProceso As String) As DataTable
        Dim table As DataTable
        Try
            table = Singleton(Of clsProcesoDO).Create.ObtenerDatosPagosIBSOnline(pstrCodigoProceso)
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

    Public Function ObtenerInformacionProcesoIBSByFecha(ByVal pintDia As Integer) As DataTable
        Dim table As DataTable
        Try
            table = Singleton(Of clsProcesoDO).Create.ObtenerInformacionProcesoIBSByFecha(pintDia)
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

    Public Function ObtenerInformacionProcesosIBS(ByVal pstrFiltro As String) As DataTable
        Dim table As DataTable
        Try

            Dim arrayMensajeInicio() As String = {"Inicio del Metodo - Parametros: pstrFiltro=", pstrFiltro}
            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ObtenerInformacionProcesosIBS", String.Concat(arrayMensajeInicio), "", "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

            table = Singleton(Of clsProcesoDO).Create.ObtenerInformacionProcesosIBS(pstrFiltro)

            Dim arrayMensajeFin() As String = {"Fin del Metodo - Parametros: pstrFiltro=", pstrFiltro}
            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ObtenerInformacionProcesosIBS", String.Concat(arrayMensajeFin), "", "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

        Catch ex1 As HandledException
            Dim ex As HandledException = ex1
            ProjectData.SetProjectError(ex)

            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Errores.ToString(), "ObtenerInformacionProcesosIBS", ex1.Message, ex1.StackTrace, "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

            Throw ex
        Catch ex3 As Exception
            Dim ex As Exception = ex3
            ProjectData.SetProjectError(ex)

            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Errores.ToString(), "ObtenerInformacionProcesosIBS", ex3.Message, ex3.StackTrace, "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

            Throw ex
        End Try
        Return table
    End Function

    Public Function ObtenerListaClienteUltimoProceso() As DataTable
        Dim table As DataTable
        Try
            Dim arrayMensajeInicio() As String = {"Inicio del Metodo - Parametros: Ninguno"}
            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ObtenerListaClienteUltimoProceso", String.Concat(arrayMensajeInicio), "", "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

            table = Singleton(Of clsProcesoDO).Create.ObtenerListaClienteUltimoProceso

            Dim arrayMensajeFin() As String = {"Fin del Metodo - Parametros: Ninguno"}
            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ObtenerListaClienteUltimoProceso", String.Concat(arrayMensajeFin), "", "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

        Catch ex1 As HandledException
            Dim ex As HandledException = ex1
            ProjectData.SetProjectError(ex)

            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Errores.ToString(), "ObtenerListaClienteUltimoProceso", ex1.Message, ex1.StackTrace, "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

            Throw ex
        Catch ex3 As Exception
            Dim ex As Exception = ex3
            ProjectData.SetProjectError(ex)

            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Errores.ToString(), "ObtenerListaClienteUltimoProceso", ex3.Message, ex3.StackTrace, "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

            Throw ex
        End Try
        Return table
    End Function

    Public Function ObtenerListaProcesosByCodigoIBS(ByVal pstrCodigoIBS As String) As DataTable
        Dim table As DataTable
        Try
            table = Singleton(Of clsProcesoDO).Create.ObtenerListaProcesosByCodigoIBS(pstrCodigoIBS)
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

    Public Function ObtenerListaProcesosEsperaArchivoDescuento(ByVal pstrAnioPeriodo As String, ByVal pstrMesPeriodo As String) As DataTable
        Dim table As DataTable
        Try
            table = Singleton(Of clsProcesoDO).Create.ObtenerListaProcesosEsperaArchivoDescuento(pstrAnioPeriodo, pstrMesPeriodo)
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

    Public Function ObtenerListaProcesosEsperaArchivoDescuentoByNombreCliente(ByVal pstrAnioPeriodo As String, ByVal pstrMesPeriodo As String, ByVal pstrNombreCliente As String) As DataTable
        Dim table As DataTable
        Try
            table = Singleton(Of clsProcesoDO).Create.ObtenerListaProcesosEsperaArchivoDescuentoByNombreCliente(pstrAnioPeriodo, pstrMesPeriodo, pstrNombreCliente)
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

    Public Function ObtenerProcesosRealizadosActual() As DataTable
        Dim table As DataTable
        Try

            Dim arrayMensajeInicio() As String = {"Inicio del Metodo - Parametros: Ninguno"}
            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ObtenerProcesosRealizadosActual", String.Concat(arrayMensajeInicio), "", "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

            table = Singleton(Of clsProcesoDO).Create.ObtenerProcesosRealizadosActual

            Dim arrayMensajeFin() As String = {"Fin del Metodo - Parametros: Ninguno"}
            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ObtenerProcesosRealizadosActual", String.Concat(arrayMensajeFin), "", "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

        Catch ex1 As HandledException
            Dim ex As HandledException = ex1
            ProjectData.SetProjectError(ex)

            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Errores.ToString(), "ObtenerProcesosRealizadosActual", ex1.Message, ex1.StackTrace, "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

            Throw ex
        Catch ex3 As Exception
            Dim ex As Exception = ex3
            ProjectData.SetProjectError(ex)

            Me.objEventoSistema = Me.objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Errores.ToString(), "ObtenerProcesosRealizadosActual", ex3.Message, ex3.StackTrace, "OperadorDES")
            Me.objEventoSistemaBL.Insertar(Me.objEventoSistema)

            Throw ex
        End Try
        Return table
    End Function

    Public Function ObtenerRegistrosResultadoProcesoDescuentosPagoAutomatico(ByVal pintCodigoProcesoAutomatico As Integer) As DataTable
        Dim table As DataTable
        Try
            table = Singleton(Of clsProcesoDO).Create.ObtenerRegistrosResultadoProcesoDescuentosPagoAutomatico(pintCodigoProcesoAutomatico)
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

    Public Function ObtenerResumenPagosIBS(ByVal codEmpresa As String, ByVal fechaInicial As String, ByVal fechaFinal As String, ByVal lote As String) As DataTable
        Dim table As DataTable
        Try
            table = Singleton(Of clsProcesoDO).Create.ObtenerResumenPagosIBS(codEmpresa, fechaInicial, fechaFinal, lote)
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

    Public Function ObtenerResumenProcesoIBS(ByVal codEmpresa As String, ByVal fechaInicial As String, ByVal fechaFinal As String) As DataTable
        Dim table As DataTable
        Try
            table = Singleton(Of clsProcesoDO).Create.ObtenerResumenProcesoIBS(codEmpresa, fechaInicial, fechaFinal)
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

    Public Function ObtieneRegistroResultadoProcesoPorFiltros(ByVal pstrCodigoProceso As String, ByVal pstrDocTrabajador As String, ByVal pstrNomTrabajador As String, ByVal pdecNumPagare As Decimal, ByVal pstrEstadoTrabajador As String, ByVal pstrZonaUse As String) As DataTable
        Dim table As DataTable
        Try
            table = Singleton(Of clsProcesoDO).Create.ObtieneRegistroResultadoProcesoPorFiltros(pstrCodigoProceso, pstrDocTrabajador, pstrNomTrabajador, pdecNumPagare, pstrEstadoTrabajador, pstrZonaUse)
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
End Class
