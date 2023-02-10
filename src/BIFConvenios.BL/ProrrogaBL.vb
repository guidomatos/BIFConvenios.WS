Imports BIFConvenios.DO
Imports BIFUtils
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Transactions
Public Class ProrrogaBL
    Private ReadOnly lLog As Log

    Public Sub New()
        MyBase.New()
        lLog = New Log()
    End Sub
    ' Methods
    Public Function ProcesoProrroga(pNumeroLote As String, pUsuario As String) As Integer
        Dim enumerator As IEnumerator = Nothing
        Dim lProrrogaDO As New ProrrogaDO()
        Dim lResult As Integer = 0
        Try
            lLog.GrabarLog(Log.Level.Info, "ProcesoProrroga", String.Concat("Inicio del Metodo - Parametros:  pNumeroLote=", pNumeroLote), "", pUsuario)
            Dim lResultado As String = lProrrogaDO.ProcesaProrrogaEnIBS(pNumeroLote)
            Dim lds As DataSet = lProrrogaDO.ObtieneInformacionProrrogaDeIBS(pNumeroLote)
            Using oScope As New TransactionScope(TransactionScopeOption.RequiresNew)
                lLog.GrabarLog(Log.Level.Info, "ProcesoProrroga", String.Concat("Inicio de Tx: pNumeroLote=", pNumeroLote), "", pUsuario)
                lProrrogaDO.ActualizaLoteProrroga(pNumeroLote, lResultado)
                If (lds.Tables.Count > 0) Then
                    Dim ldt As DataTable = lds.Tables(0)
                    Try
                        enumerator = ldt.Rows.GetEnumerator()
                        While enumerator.MoveNext()
                            Dim ldr As DataRow = DirectCast(enumerator.Current, DataRow)
                            lProrrogaDO.ActualizaClienteCuotaProrroga(pNumeroLote, Conversions.ToString(ldr("EDLNPGR")), Conversions.ToBoolean(IIf(Operators.CompareString(lResultado.Trim(), "", False) = 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lResultado.Trim(), "error", False) = 0, False, Operators.CompareString(ldr("WFLG1").ToString().Trim(), "", False) = 0)), ldr("EDFLAGP").ToString().Trim())
                        End While
                    Finally
                        If (TypeOf enumerator Is IDisposable) Then
                            TryCast(enumerator, IDisposable).Dispose()
                        End If
                    End Try
                End If
                lProrrogaDO.ActualizaInformacionProrrogasCuotas(pNumeroLote)
                oScope.Complete()
            End Using
            lLog.GrabarLog(Log.Level.Info, "ProcesoProrroga", String.Concat("Fin del Metodo - Parametros:  pNumeroLote=", pNumeroLote), "", pUsuario)
        Catch exception As Exception
            ProjectData.SetProjectError(exception)
            Dim ex As Exception = exception
            lLog.GrabarLog(Log.Level.Errores, "ProcesoProrroga", ex.Message, ex.StackTrace, pUsuario)
            lResult = 1
            ProjectData.ClearProjectError()
        End Try
        Return lResult
    End Function
End Class
