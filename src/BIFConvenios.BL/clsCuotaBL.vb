Imports BIFConvenios.BE
Imports BIFConvenios.DO
Imports Microsoft.VisualBasic.CompilerServices
Imports Resource
Imports System.Transactions

Public Class clsCuotaBL
    Private objEventoSistema As clsEventoSistema
    Private objProceso As clsProceso
    Private ReadOnly objCuotaDO As clsCuotaDO
    Private ReadOnly objCuotaDO2 As CuotaDO
    Private ReadOnly objProcesoBL As clsProcesoBL
    Private ReadOnly objEventoSistemaBL As clsEventoSistemaBL

    Public Sub New()
        MyBase.New()
        objCuotaDO = New clsCuotaDO()
        objCuotaDO2 = New CuotaDO()
        objProcesoBL = New clsProcesoBL()
        objEventoSistemaBL = New clsEventoSistemaBL()
    End Sub
    ' Methods
    Public Function ImportaPagareDeIBS(pstrCodigoClienteIBS As String, pstrAnio As String, pstrMes As String, pstrFechaProcesoAS400 As String, pstrCodigoCliente As String, pstrUsuario As String) As String
        Dim str As String
        Dim enumerator As IEnumerator = Nothing
        Dim enumerator1 As IEnumerator = Nothing
        Dim strCodigoProceso As String = ""

        Try
            Dim _clsEventoSistemaBL As clsEventoSistemaBL = objEventoSistemaBL
            Dim strArrays() As String = {"Inicio del Metodo - Parametros: pstrCodigoClienteIBS=", pstrCodigoClienteIBS, ", pstrAnio=", pstrAnio, ", pstrMes=", pstrMes, ", pstrCodigoCliente=", pstrCodigoCliente}
            objEventoSistema = _clsEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ImportaPagareDeIBS", String.Concat(strArrays), "", pstrUsuario)
            objEventoSistemaBL.Insertar(objEventoSistema)
            Dim dtPagareIBS As New DataTable()
            'dtPagareIBS = objCuotaDO.ObtenerPagareDeIBS(pstrCodigoClienteIBS, pstrAnio, pstrMes)
            'dtDeudaIBS = objCuotaDO.ObtenerDeudaDeIBS(pstrCodigoClienteIBS, pstrAnio, pstrMes)
            'Add 2022-06-03 Usar misma funcion que web
            dtPagareIBS = objCuotaDO2.ObtenerPagaresDeIBS("", pstrCodigoClienteIBS, pstrAnio, pstrMes).Tables(0)
            Dim dtDeudaIBS As New DataTable()
            dtDeudaIBS = objCuotaDO2.ObtenerDeudaDeIBS("", pstrCodigoClienteIBS, pstrAnio, pstrMes).Tables(0)
            'end Add

            Using oScope As New TransactionScope(TransactionScopeOption.RequiresNew, TimeSpan.FromMinutes(20))
                Try
                    objProceso = objProcesoBL.DevolverObjeto(pstrCodigoCliente, pstrAnio, pstrMes, pstrFechaProcesoAS400, pstrUsuario)
                    strCodigoProceso = objProcesoBL.AdicionarProceso(objProceso)
                    If (Operators.CompareString(strCodigoProceso, "-1", False) <> 0) Then
                        Try
                            enumerator = dtPagareIBS.Rows.GetEnumerator()
                            While enumerator.MoveNext()
                                Dim current As DataRow = DirectCast(enumerator.Current, DataRow)
                                current(0) = strCodigoProceso
                                objCuotaDO.InsertaDLENV(current)
                            End While
                        Finally
                            If (TypeOf enumerator Is IDisposable) Then
                                TryCast(enumerator, IDisposable).Dispose()
                            End If
                        End Try
                        Try
                            enumerator1 = dtDeudaIBS.Rows.GetEnumerator()
                            While enumerator1.MoveNext()
                                Dim dr As DataRow = DirectCast(enumerator1.Current, DataRow)
                                dr(0) = strCodigoProceso
                                objCuotaDO.InsertarHistoricoDLCCR(dr)
                            End While
                        Finally
                            If (TypeOf enumerator1 Is IDisposable) Then
                                TryCast(enumerator1, IDisposable).Dispose()
                            End If
                        End Try
                        objCuotaDO.FinalizaImportacionPagares(strCodigoProceso, pstrUsuario)
                        objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ImportaPagareDeIBS", String.Concat("Finalizó Importación de Pagares: pCodigo_proceso=", strCodigoProceso), "", pstrUsuario)
                        objEventoSistemaBL.Insertar(objEventoSistema)
                        oScope.Complete()
                    Else
                        oScope.Dispose()
                        str = strCodigoProceso
                        Return str
                    End If
                Catch transactionException1 As TransactionException
                    ProjectData.SetProjectError(transactionException1)
                    Dim transactionException As TransactionException = transactionException1
                    oScope.Dispose()
                    objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", Conversions.ToString(3), "ImportaPagareDeIBS", transactionException.Message, transactionException.StackTrace, pstrUsuario)
                    objEventoSistemaBL.Insertar(objEventoSistema)
                    Throw transactionException
                Catch handledException As HandledException
                    ProjectData.SetProjectError(handledException)
                    Dim ex2 As HandledException = handledException
                    oScope.Dispose()
                    objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", Conversions.ToString(3), "ImportaPagareDeIBS", ex2.ErrorMessageFull, ex2.StackTrace, pstrUsuario)
                    objEventoSistemaBL.Insertar(objEventoSistema)
                    Throw ex2
                Catch exception As Exception
                    ProjectData.SetProjectError(exception)
                    Dim ex3 As Exception = exception
                    oScope.Dispose()
                    objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", Conversions.ToString(3), "ImportaPagareDeIBS", ex3.Message, ex3.StackTrace, pstrUsuario)
                    objEventoSistemaBL.Insertar(objEventoSistema)
                    Throw ex3
                End Try
            End Using
            Dim _clsEventoSistemaBL1 As clsEventoSistemaBL = objEventoSistemaBL
            strArrays = New String() {"Fin del Metodo - Parametros: pstrCodigoClienteIBS=", pstrCodigoClienteIBS, ", pstrAnio=", pstrAnio, ", pstrMes=", pstrMes, ", pstrCodigoCliente=", pstrCodigoCliente}
            objEventoSistema = _clsEventoSistemaBL1.DevolverObjeto("BifConvenios", enumEstadoLog.Info.ToString(), "ImportaPagareDeIBS", String.Concat(strArrays), "", pstrUsuario)
            objEventoSistemaBL.Insertar(objEventoSistema)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim ex1 As Exception = exception1
            objEventoSistema = objEventoSistemaBL.DevolverObjeto("BifConvenios", Conversions.ToString(3), "ImportaPagareDeIBS", ex1.Message, ex1.StackTrace, pstrUsuario)
            objEventoSistemaBL.Insertar(objEventoSistema)
            Throw ex1
        End Try
        str = strCodigoProceso
        Return str
    End Function
End Class
