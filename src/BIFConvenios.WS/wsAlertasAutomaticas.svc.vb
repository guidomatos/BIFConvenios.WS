Imports BIFConvenios.BE
Imports BIFConvenios.BL
Imports Resource

' NOTE: You can use the "Rename" command on the context menu to change the class name "wsAlertasAutomaticas" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select wsAlertasAutomaticas.svc or wsAlertasAutomaticas.svc.vb at the Solution Explorer and start debugging.

<ServiceBehavior()>
Public Class wsAlertasAutomaticas
    Implements IWsAlertasAutomaticas

    Protected objAlertasClienteBL As New clsAlertasClientesBL
    Protected objClienteBL As New clsClienteBL
    Protected objProcesoAutomaticoBL As New clsProcesosAutomaticosBL()
    Protected objLogEnvioCorreoBL As New clsLogEnvioCorreosBL
    Protected objEventoSistemaBL As New clsEventoSistemaBL
    Protected objProcesosBL As New clsProcesoBL
    Protected objSystemParametersBL As New clsSystemParametersBL()
    Protected _dtParametrosEnvioMail As New DataTable()
    Protected objAlertasClientes As New clsAlertasClientes
    Protected objClientes As New clsCliente
    Protected objProcesoAutomatico As New clsProcesosAutomaticos
    Protected objLogEnvioCorreo As New clsLogEnvioCorreo
    Protected objEventoSistema As New clsEventoSistema

#Region "Log"


    Public Function RegistrarLogEventoSistema(pstrHilo As String, penuNivel As Integer, pstrAccion As String, pstrMensaje As String, pstrExcepcion As String, pstrUsuario As String) As Integer Implements IWsAlertasAutomaticas.RegistrarLogEventoSistema

        Try
            objEventoSistema.Hilo = pstrHilo
            objEventoSistema.Nivel = penuNivel.ToString()
            objEventoSistema.Accion = pstrAccion
            objEventoSistema.Mensaje = pstrMensaje
            objEventoSistema.Excepcion = pstrExcepcion
            objEventoSistema.Usuario = pstrUsuario

            objEventoSistema.IdEventoSistema = objEventoSistemaBL.Insertar(objEventoSistema)

            Return 1
        Catch ex As Exception
            Return 0
        End Try
    End Function


    Public Function RegistrarLogEnvio(pintCodigoProcesoAutomatico As Integer, pintCodigoCliente As Integer, pintCodigoIBS As Integer, penuTipoEnvio As Integer, pstrCodigoProceso As String, pintAnioPeriodo As Integer, pintMesPeriodo As Integer, pstrMensaje As String, penuEstado As enumLogEnvioCorreo, pstrUsuario As String) As Integer Implements IWsAlertasAutomaticas.RegistrarLogEnvio

        Try
            objLogEnvioCorreo.iProcesoAutomaticoId = pintCodigoProcesoAutomatico
            objLogEnvioCorreo.iCodigoCliente = pintCodigoCliente
            objLogEnvioCorreo.iCodigoIBS = pintCodigoIBS
            objLogEnvioCorreo.iTipoEnvioCorreoId = penuTipoEnvio
            objLogEnvioCorreo.vCodigoProceso = pstrCodigoProceso
            objLogEnvioCorreo.iAnioPeriodo = pintAnioPeriodo
            objLogEnvioCorreo.iMesPeriodo = pintMesPeriodo
            objLogEnvioCorreo.vMensajeProceso = pstrMensaje
            objLogEnvioCorreo.iEstado = penuEstado
            objLogEnvioCorreo.vUsuarioCreacion = pstrUsuario

            objLogEnvioCorreoBL.Insert(objLogEnvioCorreo)

            Return 1
        Catch ex As Exception
            Return 0
        End Try

    End Function


    Public Function RegistrarLogProcesosAutomaticos(pintTotal As Integer, pintProcesados As Integer, pintError As Integer, pstrMensaje As String, pintEstado As Integer, pstrUsuario As String) As Integer Implements IWsAlertasAutomaticas.RegistrarLogProcesosAutomaticos
        Try
            objProcesoAutomatico.iTotalRegistros = pintTotal
            objProcesoAutomatico.iProcesados = pintProcesados
            objProcesoAutomatico.iErroneos = pintError
            objProcesoAutomatico.vMensajeProceso = pstrMensaje
            objProcesoAutomatico.iEstado = pintEstado
            objProcesoAutomatico.vUsuarioCreacion = pstrUsuario

            Return objProcesoAutomaticoBL.Insert(objProcesoAutomatico)
        Catch ex As Exception
            Return 0
        End Try

    End Function


    Public Function ActualizarLogProcesosAutomaticos(pintCodigoProcesoAutomatico As Integer, pintTotal As Integer, pintProcesados As Integer, pintError As Integer, pstrMensaje As String, pintEstado As Integer, pstrUsuario As String) As Integer Implements IWsAlertasAutomaticas.ActualizarLogProcesosAutomaticos
        Try
            objProcesoAutomatico.iProcesoAutomaticoId = pintCodigoProcesoAutomatico
            objProcesoAutomatico.iTotalRegistros = pintTotal
            objProcesoAutomatico.iProcesados = pintProcesados
            objProcesoAutomatico.iErroneos = pintError
            objProcesoAutomatico.vMensajeProceso = pstrMensaje
            objProcesoAutomatico.iEstado = pintEstado
            objProcesoAutomatico.vUsuarioModificacion = pstrUsuario

            objProcesoAutomaticoBL.Update(objProcesoAutomatico)

            Return 1
        Catch ex As Exception
            Return 0
        End Try
    End Function

#End Region

#Region "Metodos Auxiliares"

    Public Function ConvertirBody(pstrBody As String) As String Implements IWsAlertasAutomaticas.ConvertirBody
        Dim strHtmlBody As New StringBuilder()
        Dim strBody As New StringBuilder()

        Dim filas() As String = Split(pstrBody.ToString(), "&E")

        For i As Integer = LBound(filas) To UBound(filas)
            With strBody
                If filas(i) = "" Then
                    .Append("<p style='margin-top:0; margin-bottom:0;'>&nbsp;</p>")
                Else
                    Dim strCadena As String = String.Empty
                    Dim strCaux As String = String.Empty

                    strCaux = filas(i).Trim()

                    If strCaux.Length > 200 Then
                        strCaux.Insert(200, "<br />")
                    End If

                    For x As Integer = 0 To (strCaux.Length - 1)
                        If strCaux.Chars(x) = " " Then
                            strCadena &= "&nbsp;"
                        Else
                            strCadena &= strCaux.Chars(x)
                        End If
                    Next

                    .Append("<p style='margin-top;0; margin-bottom:0;'>" & strCadena & "</p>")

                End If
            End With
        Next

        With strHtmlBody
            .Append("<html>")
            .Append("<head> ")
            .Append("<meta name='ProgId' content='FrontPage.Editor.Document'>")
            .Append("<meta http-equiv='Content-Type' content='text/html; charset=windows-1252'>")
            .Append("<title>Correo Electrónico Autogenerado </title>")
            .Append("</head>")
            .Append("<body>")
            .Append(strBody.ToString())
            .Append("</body>")
            .Append("</html>")

        End With

        Return strHtmlBody.ToString()
    End Function

    Private Function ReemplazarMetadata(pstrCadena As String, pdr As DataRow) As String
        Dim strResult As String = pstrCadena
        strResult = strResult.Replace("[Nombre_Empresa]", pdr("vNombreEmpresa").ToString())
        strResult = strResult.Replace("[Fecha_Pago]", pdr("iFechaPago").ToString())
        strResult = strResult.Replace("[Cuenta_Abono]", pdr("iCuentaAbono").ToString())
        strResult = strResult.Replace("[Nombre_Funcionario_Convenios]", pdr("vNombreFuncionario").ToString())
        strResult = strResult.Replace("[Email_Funcionario_Convenios]", pdr("vEmailFuncionario").ToString())
        strResult = strResult.Replace("[Anexo_Funcionario_Convenios]", pdr("vAnexoFuncionario").ToString())
        strResult = strResult.Replace("[Mes]", clsPeriodo.NombreMes(Convert.ToInt32(pdr("iMesCuota").ToString())))
        strResult = strResult.Replace("[Anio]", pdr("iAñoCuota").ToString())
        strResult = strResult.Replace("[FECHA]", pdr("iFechaPago").ToString() + "/" + pdr("iMesCuota").ToString() + "/" + pdr("iAñoCuota").ToString())
        strResult = strResult.Replace("&R1", "<strong>")
        strResult = strResult.Replace("&R2", "</strong>")

        Return strResult
    End Function

    Private Function EnviarCorreoAlerta(pintCodigoIBS As Integer, pintAnioPeriodo As Integer, pintMesPeriodo As Integer, pstrCorreoDE As String, pstrCorreosPara As String, pstrCorreosCopia As String, pstrAsunto As String, pstrCuerpo As String, pstrAdjunto As String) As String
        Dim arrayMensajeInicio() As String = {"Inicio del Metodo - Parametros: pintCodigoIBS=", pintCodigoIBS, ", pintAnioPeriodo=", pintAnioPeriodo, ", pintMesPeriodo=", pintMesPeriodo, ", pstrCorreoDE=", pstrCorreoDE, ", pstrCorreosPara=", pstrCorreosPara, ", pstrCorreosCopia=", pstrCorreosCopia, ", pstrAsunto=", pstrAsunto, ", pstrCuerpo=", pstrCuerpo, ", pstrAdjunto=", pstrAdjunto}
        objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "EnviarCorreoAlerta", String.Concat(arrayMensajeInicio), "", "OperadorDES")
        objEventoSistemaBL.Insertar(objEventoSistema)

        _dtParametrosEnvioMail = objSystemParametersBL.Seleccionar(ConfigurationManager.AppSettings(clsTiposSystemParameters.ParametroEnvioMail.ToString()))

        'Dim strPath As String = ConfigurationManager.AppSettings("ArchivosConvenio").ToString()
        Dim strPath As String = _dtParametrosEnvioMail.Rows(Convert.ToInt32(enumParametroEnvioMail.RutaDescargaNominas))("vValor").ToString().Trim()
        Dim intExport As Integer
        Dim strNameFile As String = String.Empty
        Dim strPathFile As String = String.Empty
        Dim strMensajeFile As String = String.Empty
        Dim strMensaje As String = ""

        If pstrAdjunto = 1 Then
            Try
                Dim _dtCuotas As New DataTable()
                _dtCuotas = objAlertasClienteBL.ObtenerCuotasVencidasAlertasEnviar(pintCodigoIBS)
                intExport = clsFiles.ExportToExcel(_dtCuotas, "xls", strPath, "", pintAnioPeriodo, pintMesPeriodo, "Alerta", strNameFile, strPathFile, strMensajeFile)
            Catch ex As Exception
                objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Errores.ToString(), "ObtenerCuotasVencidasAlertasEnviar", ex.Message, ex.StackTrace, "OperadorDES")
                objEventoSistemaBL.Insertar(objEventoSistema)
                Throw ex
            End Try
        End If

        'Si no este TEST hacemos el envio regular
        Dim strTestOnly As String = _dtParametrosEnvioMail.Rows(Convert.ToInt32(enumParametroEnvioMail.ModoPrueba))("vValor").ToString().Trim()

        Dim strCorreoElectronicosPara As String
        If strTestOnly = "0" Then
            strCorreoElectronicosPara = pstrCorreosPara
        Else    ' en otro caso enviamos el correo a una direccion de prueba
            'strCorreoElectronicosPara = ConfigurationManager.AppSettings("mailTest").ToString()
            strCorreoElectronicosPara = _dtParametrosEnvioMail.Rows(Convert.ToInt32(enumParametroEnvioMail.ListaMailTest))("vValor").ToString().Trim()
        End If

        Dim strCorreoElectronicoDE As String = pstrCorreoDE
        Dim strCorreoElectronicosBCC As String = pstrCorreosCopia

        Dim strCorreoElectronicoAsunto As String = pstrAsunto
        Dim strCorreoElectronicoCuerpo As String = pstrCuerpo

        Dim ar As New ArrayList()

        For Each str As Object In strCorreoElectronicosPara.Split(";")
            ar.Add(New MailSource(str))
        Next

        Try

            Dim arrayMensajeInicioSendNotification() As String = {"Inicio del Metodo"}
            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "SendNotification", String.Concat(arrayMensajeInicioSendNotification), "", "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)


            Dim objUtils As New clsUtils
            If intExport = 0 And pstrAdjunto = 1 Then
                Dim strFullName As String = strPathFile + "\\" + strNameFile
                objUtils.SendNotification(strCorreoElectronicoDE, strCorreoElectronicosPara, strCorreoElectronicosBCC, strCorreoElectronicoAsunto, strCorreoElectronicoCuerpo, strFullName, True, "")
            Else
                objUtils.SendNotification(strCorreoElectronicoDE, strCorreoElectronicosPara, strCorreoElectronicosBCC, strCorreoElectronicoAsunto, strCorreoElectronicoCuerpo, "", True, "")
            End If

            Dim arrayMensajeFinSendNotification() As String = {"Fin del Metodo"}
            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "SendNotification", String.Concat(arrayMensajeFinSendNotification), "", "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

        Catch ex As Exception

            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Errores.ToString(), "SendNotification", ex.Message, ex.StackTrace, "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

        End Try

        Dim arrayMensajeFin() As String = {"Fin del Metodo - Parametros: pintCodigoIBS=", pintCodigoIBS, ", pintAnioPeriodo=", pintAnioPeriodo, ", pintMesPeriodo=", pintMesPeriodo, ", pstrCorreoDE=", pstrCorreoDE, ", pstrCorreosPara=", pstrCorreosPara, ", pstrCorreosCopia=", pstrCorreosCopia, ", pstrAsunto=", pstrAsunto, ", pstrCuerpo=", pstrCuerpo, ", pstrAdjunto=", pstrAdjunto}
        objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "EnviarCorreoAlerta", String.Concat(arrayMensajeInicio), "", "OperadorDES")
        objEventoSistemaBL.Insertar(objEventoSistema)

        Return strMensaje
    End Function

    Private Function FormarCorreoCopias(pintCodIBS As Integer) As String
        Dim strCorreo As String = ""

        Try

            Dim arrayMensajeInicio() As String = {"Inicio del Metodo - Parametros: pintCodIBS=", pintCodIBS}
            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "FormarCorreoCopias", String.Concat(arrayMensajeInicio), "", "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

            Dim _dt As DataTable = objClienteBL.ObtenerGestorConvenioPorCodigoIBSDesdeAS400(pintCodIBS)

            Dim arrayMensajeFin() As String = {"Fin del Metodo - Parametros: pintCodIBS=", pintCodIBS}
            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "FormarCorreoCopias", String.Concat(arrayMensajeInicio), "", "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

            strCorreo = _dt.Rows(0)("GSTCOR").ToString()

            Return strCorreo
        Catch ex As Exception

            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Errores.ToString(), "FormarCorreoCopias", ex.Message, ex.StackTrace, "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

            Return strCorreo
        End Try
    End Function

#End Region


    Public Function ObtenerListClienteUltimoProceso() As DataTable Implements IWsAlertasAutomaticas.ObtenerListClienteUltimoProceso
        Dim dt As DataTable

        Try

            Dim arrayMensajeInicio() As String = {"Inicio del Metodo - Parametros: Ninguno"}
            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ObtenerListClienteUltimoProceso", String.Concat(arrayMensajeInicio), "", "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

            dt = objProcesosBL.ObtenerListaClienteUltimoProceso()

            Dim arrayMensajeFin() As String = {"Fin del Metodo - Parametros: Ninguno"}
            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ObtenerListClienteUltimoProceso", String.Concat(arrayMensajeFin), "", "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

        Catch ex As Exception

            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Errores.ToString(), "ObtenerListClienteUltimoProceso", ex.Message, ex.StackTrace, "OperadorDES")
            objEventoSistemaBL.Insertar(objEventoSistema)

            Return Nothing
        End Try
        Return dt
    End Function


    Public Function ProcesarAlerta(pintCodigoProcesoAutomatico As Integer, pstrCodigoCliente As String, pintAnioPeriodo As Integer, pintMesPeriodo As Integer, pstrUsuario As String, ByRef pintEstado As Integer) As String Implements IWsAlertasAutomaticas.ProcesarAlerta
        Dim strMensaje As String = ""

        Dim arrayMensajeInicio() As String = {"Inicio del Metodo - Parametros: pintCodigoProcesoAutomatico=", pintCodigoProcesoAutomatico, ", pstrCodigoCliente=", pstrCodigoCliente, ", pintAnioPeriodo=", pintAnioPeriodo, ", pintMesPeriodo=", pintMesPeriodo, ", pstrUsuario=", pstrUsuario, ", pintEstado=", pintEstado}
        objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ProcesarAlerta", String.Concat(arrayMensajeInicio), "", "OperadorDES")
        objEventoSistemaBL.Insertar(objEventoSistema)

        If String.IsNullOrEmpty(pstrCodigoCliente) Then
            strMensaje = clsMensajesGeneric.ParametroVacio.Replace("&1", "Codigo del Cliente")

            pintEstado = 0

        ElseIf Not IsNumeric(pstrCodigoCliente) Then
            strMensaje = clsMensajesGeneric.CampoNoNumerico.Replace("&1", "Codigo del Cliente")

            pintEstado = 0

        End If

        If (strMensaje = "") Then
            Try
                objClientes.CodigoCliente = Convert.ToInt32(pstrCodigoCliente)

                Dim _dtCliente As DataTable = objClienteBL.ObtenerClientePorCodigo(objClientes.CodigoCliente)

                Dim intCodIBS As Integer = Convert.ToInt32(_dtCliente.Rows(0)("Codigo_IBS").ToString())
                Dim decSaldoContable As Decimal

                Dim _dtInfoClienteIBS As New DataTable()

                Try
                    _dtInfoClienteIBS = objClienteBL.ObtenerSaldoContablePorCodigoIBS(intCodIBS.ToString())

                    decSaldoContable = Convert.ToDecimal(-1) * Convert.ToDecimal(_dtInfoClienteIBS.Rows(0)("ACMMGB").ToString())

                    objAlertasClientes.iAlertaClienteId = 0
                    objAlertasClientes.iAlertaId = 0
                    objAlertasClientes.iClienteId = Convert.ToInt32(pstrCodigoCliente)
                    objAlertasClientes.iEstado = 1

                    Dim intTipoAlerta As Integer = 0
                    Dim strAsunto As String = ""
                    Dim strCuerpo As String = ""
                    Dim strCorreoCopia As String = ""

                    Dim _dtAlertasClientes As New DataTable()

                    Try
                        _dtAlertasClientes = objAlertasClienteBL.ObtenerAlertasClientesEnviar(objAlertasClientes.iClienteId, decSaldoContable, pintAnioPeriodo, pintMesPeriodo)

                        If (_dtAlertasClientes.Rows(0)("vCorreosEnviar").ToString().Length > 0) Then
                            intTipoAlerta = Convert.ToInt32(_dtAlertasClientes.Rows(0)("iTipoAlerta").ToString())
                            strCorreoCopia = FormarCorreoCopias(intCodIBS)
                            strCorreoCopia = IIf(Len(strCorreoCopia) > 0, strCorreoCopia + "," + _dtAlertasClientes.Rows(0)("vEmailFuncionario").ToString(), _dtAlertasClientes.Rows(0)("vEmailFuncionario").ToString())
                            strAsunto = _dtAlertasClientes.Rows(0)("vAlerta").ToString() + " - " + ReemplazarMetadata(_dtAlertasClientes.Rows(0)("vAsuntoMensaje").ToString(), _dtAlertasClientes.Rows(0))
                            strCuerpo = ReemplazarMetadata(_dtAlertasClientes.Rows(0)("vCuerpoMensaje").ToString(), _dtAlertasClientes.Rows(0))
                            strCuerpo = ConvertirBody(strCuerpo)

                            Try
                                strMensaje = EnviarCorreoAlerta(intCodIBS, pintAnioPeriodo, pintMesPeriodo, _dtAlertasClientes.Rows(0)("vEmailFuncionario").ToString(), _dtAlertasClientes.Rows(0)("vCorreosEnviar").ToString(), strCorreoCopia, strAsunto, strCuerpo, _dtAlertasClientes.Rows(0)("vAdjunto").ToString())

                                If (strMensaje = "") Then
                                    RegistrarLogEnvio(pintCodigoProcesoAutomatico, pstrCodigoCliente, intCodIBS, intTipoAlerta, "", pintAnioPeriodo, pintMesPeriodo, strMensaje, enumLogEnvioCorreo.Enviado, pstrUsuario)

                                    pintEstado = 1
                                Else
                                    RegistrarLogEnvio(pintCodigoProcesoAutomatico, pstrCodigoCliente, intCodIBS, intTipoAlerta, "", pintAnioPeriodo, pintMesPeriodo, strMensaje, enumLogEnvioCorreo.Error, pstrUsuario)

                                    pintEstado = 0
                                End If

                            Catch ex1 As Exception
                                strMensaje = clsMensajesGeneric.ExcepcionControlada.Replace("&1", "EnviarCorreoAlerta").Replace("&2", enumGeneric.NoRecords.ToString()).Replace("&3", ex1.ToString())
                                RegistrarLogEnvio(pintCodigoProcesoAutomatico, pstrCodigoCliente, intCodIBS, intTipoAlerta, "", pintAnioPeriodo, pintMesPeriodo, strMensaje, enumLogEnvioCorreo.Error, pstrUsuario)

                                pintEstado = 0
                            End Try
                        Else
                            strMensaje = clsMensajesGeneric.MensajeNoRegistraCorreos.Replace("&1", _dtCliente.Rows(0)("Nombre_Cliente").ToString()).Replace("&2", pstrCodigoCliente)
                            RegistrarLogEnvio(pintCodigoProcesoAutomatico, pstrCodigoCliente, intCodIBS, intTipoAlerta, "", pintAnioPeriodo, pintMesPeriodo, strMensaje, enumLogEnvioCorreo.Cancelado, pstrUsuario)

                            pintEstado = 1
                        End If

                    Catch ex1 As HandledException
                        If ex1.ErrorTypeId = -400 Then
                            strMensaje = clsMensajesGeneric.MensajeNoAlertasEnviar.Replace("&1", _dtCliente.Rows(0)("Nombre_Cliente").ToString()).Replace("&2", pstrCodigoCliente)
                            RegistrarLogEnvio(pintCodigoProcesoAutomatico, pstrCodigoCliente, intCodIBS, intTipoAlerta, "", pintAnioPeriodo, pintMesPeriodo, strMensaje, enumLogEnvioCorreo.Error, pstrUsuario)

                            pintEstado = 0
                        Else
                            strMensaje = clsMensajesGeneric.ExcepcionControlada.Replace("&1", "ObtenerAlertasClientesEnviar").Replace("&2", enumGeneric.ErrorMessage.ToString()).Replace("&3", ex1.ErrorMessageFull)
                            RegistrarLogEnvio(pintCodigoProcesoAutomatico, pstrCodigoCliente, intCodIBS, intTipoAlerta, "", pintAnioPeriodo, pintMesPeriodo, strMensaje, enumLogEnvioCorreo.Error, pstrUsuario)

                            pintEstado = 0
                        End If
                    End Try

                Catch ex1 As Exception
                    strMensaje = clsMensajesGeneric.ProcesoNoEncontrado.Replace("&1", _dtCliente.Rows(0)("Nombre_Cliente").ToString()).Replace("&2", pstrCodigoCliente)
                    RegistrarLogEnvio(pintCodigoProcesoAutomatico, pstrCodigoCliente, intCodIBS, 0, "", pintAnioPeriodo, pintMesPeriodo, strMensaje, enumLogEnvioCorreo.Error, pstrUsuario)

                    pintEstado = 0
                End Try

            Catch ex1 As HandledException
                strMensaje = clsMensajesGeneric.ExcepcionControlada.Replace("&1", "ObtenerClientePorCodigo").Replace("&2", ex1.ErrorTypeId.ToString()).Replace("&3", ex1.ErrorMessageFull)
                RegistrarLogEnvio(pintCodigoProcesoAutomatico, pstrCodigoCliente, 0, 0, "", 0, 0, strMensaje, enumLogEnvioCorreo.Error, pstrUsuario)

                pintEstado = 0
            End Try

        End If

        Dim arrayMensajeFin() As String = {"Fin del Metodo - Parametros: pintCodigoProcesoAutomatico=", pintCodigoProcesoAutomatico, ", pstrCodigoCliente=", pstrCodigoCliente, ", pintAnioPeriodo=", pintAnioPeriodo, ", pintMesPeriodo=", pintMesPeriodo, ", pstrUsuario=", pstrUsuario, ", pintEstado=", pintEstado}
        objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ProcesarAlerta", String.Concat(arrayMensajeFin), "", "OperadorDES")
        objEventoSistemaBL.Insertar(objEventoSistema)

        Return strMensaje

    End Function

End Class
