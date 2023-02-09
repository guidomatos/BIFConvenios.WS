Imports BIFUtils
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Configuration
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class BloqueoDO
    ' Fields
    Private ReadOnly cUtils As New WS.Utils
    Private ReadOnly conexionIBS As String
    Private ReadOnly conexionConvenios As String

    Public Sub New()
        MyBase.New()
        cUtils = New WS.Utils()
        conexionIBS = WS.Utils.CadenaConexion("AS400-ConnectionString-Convenios")
        conexionConvenios = WS.Utils.CadenaConexion("ConnectionString")
    End Sub
    Public Function ActualizaClienteCuotaBloqueo(pNumeroLote As String, pDLNP As String, pESTADO As Boolean) As Integer
        Dim connection As New SqlConnection(conexionConvenios)
        Dim strArray As String() = New String() {"EXEC UpdateClienteCuota ", pNumeroLote, ",", pDLNP, ",", Conversions.ToString(pESTADO)}
        Dim command As New SqlCommand(Conversions.ToString(String.Concat(strArray)), connection) With {
            .CommandType = CommandType.Text
        }
        connection.Open()
        Dim num2 As Integer = Conversions.ToInteger(command.ExecuteScalar)
        connection.Close()
        Return num2
    End Function

    Public Function ActualizaInformacionBloqueosCuotas(pNumeroLote As String) As Integer
        Dim connection As New SqlConnection(conexionConvenios)
        Dim command As New SqlCommand(Conversions.ToString(("EXEC ActualizaInformacionBloqueosCuotas " & pNumeroLote & "")), connection) With {
            .CommandType = CommandType.Text
        }
        connection.Open()
        Dim num2 As Integer = Conversions.ToInteger(command.ExecuteScalar)
        connection.Close()
        Return num2
    End Function
    Public Function ActualizaLoteBloqueo(pNumeroLote As String, pRespuesta As String) As Integer
        Dim connection As New SqlConnection(conexionConvenios)
        Dim strArray As String() = New String() {"EXEC UpdateLoteBloqueo ", pNumeroLote, ",'", pRespuesta, "'"}
        Dim command As New SqlCommand(Conversions.ToString(String.Concat(strArray)), connection) With {
            .CommandType = CommandType.Text
        }
        connection.Open()
        Dim num2 As Integer = Conversions.ToInteger(command.ExecuteScalar)
        connection.Close()
        Return num2
    End Function
    Public Function ObtieneInformacionBloqueoDeIBS(pNumeroLote As String) As DataSet
        Dim lds As New DataSet()
        Dim lstrsql As String = String.Concat("SELECT EDLNPGR, EDLFLG1 ", " FROM edl6376w W, cltsexc ")
        lstrsql = String.Concat(lstrsql, " WHERE     (EDLLOTE = ", pNumeroLote, ") ")
        lstrsql = String.Concat(lstrsql, " AND (wnrpg = EDLNPGR) ")
        Dim num As Integer = (New OleDbDataAdapter(lstrsql, conexionIBS)).Fill(lds)
        Return lds
    End Function

    Public Function ProcesaBloqueoEnIBS(pNumeroLote As String) As String
        Return TCPClient.SendReceive(ConfigurationManager.AppSettings("ipJavaApp").Trim, ConfigurationManager.AppSettings("portJavaApp").Trim, ("Bloqueo:" & pNumeroLote))
    End Function
End Class
