Imports BIFConvenios.BE
Imports BIFConvenios.DO
Imports Microsoft.VisualBasic.CompilerServices
Imports Resource

Public Class clsProcesoBL

    Protected objEventoSistemaBL As New clsEventoSistemaBL
    Private objEventoSistema As clsEventoSistema

    <DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        objEventoSistemaBL = New clsEventoSistemaBL()
    End Sub
    ' Methods
    Public Function ValidarFinProcesoBatch(codigo_proceso As String) As Boolean
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

    Public Function ActualizaFlagCargaAutomatica(pstrTipo As String, pintFlag As Integer) As Integer
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

    Public Function AdicionarProceso(pobjProceso As clsProceso) As String
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

    Public Function DevolverObjeto(pstrCodigoCliente As String, pstrAnio As String, pstrMes As String, pstrFechaProcesoAS400 As String, pstrUsuario As String) As clsProceso
        Dim proceso2 As New clsProceso With {
            .CodigoCliente = Conversions.ToInteger(pstrCodigoCliente),
            .AnioPeriodo = pstrAnio,
            .MesPeriodo = pstrMes,
            .FechaProcesoAS400 = pstrFechaProcesoAS400,
            .Usuario = pstrUsuario
        }
        Return proceso2
    End Function

    Public Function ExportaRegistroResultadoProcesoPorFiltros(pstrCodigoProceso As String, pstrDocTrabajador As String, pstrNomTrabajador As String, pdecNumPagare As Decimal, pstrEstadoTrabajador As String, pstrZonaUse As String) As DataTable
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

    Public Function ExportarRegistrosResultadoProceso(pstrCodigoProceso As String, pstrDocTrabajador As String, pstrNomTrabajador As String, pdecPagare As Decimal, pstrEstadoTrabajador As String, pintZonaUse As Integer) As DataTable
        Dim table As DataTable
        Try
            Dim arrayMensajeInicio() As String = {"Inicio del Metodo - Parametros: pstrCodigoProceso=", pstrCodigoProceso, ", pstrDocTrabajador=", pstrDocTrabajador, ", pstrNomTrabajador=", pstrNomTrabajador, ", pdecPagare=", pdecPagare, ", pstrEstadoTrabajador=", pstrEstadoTrabajador, ", pintZonaUse=", pintZonaUse}
            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ExportarRegistrosResultadoProceso", String.Concat(arrayMensajeInicio), "", "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

            table = Singleton(Of clsProcesoDO).Create.ExportarRegistrosResultadoProceso(pstrCodigoProceso, pstrDocTrabajador, pstrNomTrabajador, pdecPagare, pstrEstadoTrabajador, pintZonaUse)

            Dim arrayMensajeFin() As String = {"Fin del Metodo - Parametros: pstrCodigoProceso=", pstrCodigoProceso, ", pstrDocTrabajador=", pstrDocTrabajador, ", pstrNomTrabajador=", pstrNomTrabajador, ", pdecPagare=", pdecPagare, ", pstrEstadoTrabajador=", pstrEstadoTrabajador, ", pintZonaUse=", pintZonaUse}
            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ExportarRegistrosResultadoProceso", String.Concat(arrayMensajeFin), "", "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

        Catch ex1 As HandledException
            Dim ex As HandledException = ex1
            ProjectData.SetProjectError(ex)

            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Errores.ToString(), "ExportarRegistrosResultadoProceso", ex1.Message, ex1.StackTrace, "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

            Throw ex
        Catch ex3 As Exception
            Dim ex As Exception = ex3
            ProjectData.SetProjectError(ex)

            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Errores.ToString(), "ExportarRegistrosResultadoProceso", ex3.Message, ex3.StackTrace, "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

            Throw ex
        End Try
        Return table
    End Function

    Public Function ObtenerDatosPagosIBSOnline(pstrCodigoProceso As String) As DataTable
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

    Public Function ObtenerInformacionProcesoIBSByFecha(pintDia As Integer) As DataTable
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

    Public Function ObtenerInformacionProcesosIBS(pstrFiltro As String) As DataTable
        Dim table As DataTable
        Try

            Dim arrayMensajeInicio() As String = {"Inicio del Metodo - Parametros: pstrFiltro=", pstrFiltro}
            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ObtenerInformacionProcesosIBS", String.Concat(arrayMensajeInicio), "", "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

            table = Singleton(Of clsProcesoDO).Create.ObtenerInformacionProcesosIBS(pstrFiltro)

            Dim arrayMensajeFin() As String = {"Fin del Metodo - Parametros: pstrFiltro=", pstrFiltro}
            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ObtenerInformacionProcesosIBS", String.Concat(arrayMensajeFin), "", "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

        Catch ex1 As HandledException
            Dim ex As HandledException = ex1
            ProjectData.SetProjectError(ex)

            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Errores.ToString(), "ObtenerInformacionProcesosIBS", ex1.Message, ex1.StackTrace, "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

            Throw ex
        Catch ex3 As Exception
            Dim ex As Exception = ex3
            ProjectData.SetProjectError(ex)

            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Errores.ToString(), "ObtenerInformacionProcesosIBS", ex3.Message, ex3.StackTrace, "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

            Throw ex
        End Try
        Return table
    End Function

    Public Function ObtenerListaClienteUltimoProceso() As DataTable
        Dim table As DataTable
        Try
            Dim arrayMensajeInicio() As String = {"Inicio del Metodo - Parametros: Ninguno"}
            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ObtenerListaClienteUltimoProceso", String.Concat(arrayMensajeInicio), "", "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

            table = Singleton(Of clsProcesoDO).Create.ObtenerListaClienteUltimoProceso

            Dim arrayMensajeFin() As String = {"Fin del Metodo - Parametros: Ninguno"}
            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ObtenerListaClienteUltimoProceso", String.Concat(arrayMensajeFin), "", "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

        Catch ex1 As HandledException
            Dim ex As HandledException = ex1
            ProjectData.SetProjectError(ex)

            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Errores.ToString(), "ObtenerListaClienteUltimoProceso", ex1.Message, ex1.StackTrace, "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

            Throw ex
        Catch ex3 As Exception
            Dim ex As Exception = ex3
            ProjectData.SetProjectError(ex)

            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Errores.ToString(), "ObtenerListaClienteUltimoProceso", ex3.Message, ex3.StackTrace, "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

            Throw ex
        End Try
        Return table
    End Function

    Public Function ObtenerListaProcesosByCodigoIBS(pstrCodigoIBS As String) As DataTable
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

    Public Function ObtenerListaProcesosEsperaArchivoDescuento(pstrAnioPeriodo As String, pstrMesPeriodo As String) As DataTable
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

    Public Function ObtenerListaProcesosEsperaArchivoDescuentoByNombreCliente(pstrAnioPeriodo As String, pstrMesPeriodo As String, pstrNombreCliente As String) As DataTable
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
            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ObtenerProcesosRealizadosActual", String.Concat(arrayMensajeInicio), "", "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

            table = Singleton(Of clsProcesoDO).Create.ObtenerProcesosRealizadosActual

            Dim arrayMensajeFin() As String = {"Fin del Metodo - Parametros: Ninguno"}
            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ObtenerProcesosRealizadosActual", String.Concat(arrayMensajeFin), "", "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

        Catch ex1 As HandledException
            Dim ex As HandledException = ex1
            ProjectData.SetProjectError(ex)

            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Errores.ToString(), "ObtenerProcesosRealizadosActual", ex1.Message, ex1.StackTrace, "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

            Throw ex
        Catch ex3 As Exception
            Dim ex As Exception = ex3
            ProjectData.SetProjectError(ex)

            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Errores.ToString(), "ObtenerProcesosRealizadosActual", ex3.Message, ex3.StackTrace, "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

            Throw ex
        End Try
        Return table
    End Function

    Public Function ObtenerRegistrosResultadoProcesoDescuentosPagoAutomatico(pintCodigoProcesoAutomatico As Integer) As DataTable
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

    Public Function ObtenerResumenPagosIBS(codEmpresa As String, fechaInicial As String, fechaFinal As String, lote As String) As DataTable
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

    Public Function ObtenerResumenProcesoIBS(codEmpresa As String, fechaInicial As String, fechaFinal As String) As DataTable
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

    Public Function ObtieneRegistroResultadoProcesoPorFiltros(pstrCodigoProceso As String, pstrDocTrabajador As String, pstrNomTrabajador As String, pdecNumPagare As Decimal, pstrEstadoTrabajador As String, pstrZonaUse As String) As DataTable
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
