Imports BIFConvenios.DO
Imports BIFUtils
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Transactions

Public Class BloqueoBL
    ' Fields
    Private ReadOnly lLog As New Log

    ' Methods
    Public Function ProcesoBloqueo(pNumeroLote As String, pUsuario As String) As Integer
        Dim enumerator As IEnumerator = Nothing
        Dim lResult As Integer = 0
        Try
            lLog.GrabarLog(Log.Level.Info, "ProcesoBloqueo", String.Concat("Inicio del Metodo - Parametros:  pNumeroLote=", pNumeroLote), "", pUsuario)
            Dim lBloqueoDO As New BloqueoDO()
            Dim lResultado As String = lBloqueoDO.ProcesaBloqueoEnIBS(pNumeroLote)
            Dim lds As DataSet = lBloqueoDO.ObtieneInformacionBloqueoDeIBS(pNumeroLote)
            Using oScope As New TransactionScope(TransactionScopeOption.RequiresNew)
                lLog.GrabarLog(Log.Level.Info, "ProcesoBloqueo", String.Concat("Inicio de Tx: pNumeroLote=", pNumeroLote), "", pUsuario)
                lBloqueoDO.ActualizaLoteBloqueo(pNumeroLote, lResultado)
                If (lds.Tables.Count > 0) Then
                    Dim ldt As DataTable = lds.Tables(0)
                    Try
                        enumerator = ldt.Rows.GetEnumerator()
                        While enumerator.MoveNext()
                            Dim ldr As DataRow = DirectCast(enumerator.Current, DataRow)
                            lBloqueoDO.ActualizaClienteCuotaBloqueo(pNumeroLote, Conversions.ToString(ldr("EDLNPGR")), Conversions.ToBoolean(IIf(Operators.CompareString(lResultado.Trim(), "", False) = 0 Or Operators.CompareString(lResultado.Trim(), "error", False) = 0, False, Operators.CompareString(ldr("EDLFLG1").ToString().Trim(), "", False) = 0)))
                        End While
                    Finally
                        If (TypeOf enumerator Is IDisposable) Then
                            TryCast(enumerator, IDisposable).Dispose()
                        End If
                    End Try
                End If
                lBloqueoDO.ActualizaInformacionBloqueosCuotas(pNumeroLote)
                oScope.Complete()
            End Using
            lLog.GrabarLog(Log.Level.Info, "ProcesoBloqueo", String.Concat("Fin del Metodo - Parametros:  pNumeroLote=", pNumeroLote), "", pUsuario)
        Catch exception As Exception
            ProjectData.SetProjectError(exception)
            Dim ex As Exception = exception
            lLog.GrabarLog(Log.Level.Errores, "ProcesoBloqueo", ex.Message, ex.StackTrace, pUsuario)
            lResult = 1
            ProjectData.ClearProjectError()
        End Try
        Return lResult
    End Function
End Class
