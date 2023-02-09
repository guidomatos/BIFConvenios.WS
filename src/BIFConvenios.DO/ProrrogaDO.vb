Imports BIFUtils
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Configuration
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class ProrrogaDO
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

    Public Function ActualizaClienteCuotaProrroga(pNumeroLote As String, pDLNP As String, pESTADO As Boolean, EDFLAGP As String) As Integer
        Dim connection As New SqlConnection(conexionConvenios)
        Dim strArray As String() = New String() {"EXEC UpdateClienteCuotaProrroga ", pNumeroLote, ",", pDLNP, ",", Conversions.ToString(pESTADO), ",'", EDFLAGP, "'"}
        Dim command As New SqlCommand(Conversions.ToString(String.Concat(strArray)), connection) With {
            .CommandType = CommandType.Text
        }
        connection.Open()
        Dim num2 As Integer = Conversions.ToInteger(command.ExecuteScalar)
        connection.Close()
        Return num2
    End Function

    Public Function ActualizaInformacionProrrogasCuotas(pNumeroLote As String) As Integer
        Dim connection As New SqlConnection(conexionConvenios)
        Dim command As New SqlCommand(Conversions.ToString(("EXEC ActualizaInformacionProrrogasCuotas " & pNumeroLote & "")), connection) With {
            .CommandType = CommandType.Text
        }
        connection.Open()
        Dim num2 As Integer = Conversions.ToInteger(command.ExecuteScalar)
        connection.Close()
        Return num2
    End Function

    Public Function ActualizaLoteProrroga(pNumeroLote As String, pRespuesta As String) As Integer
        Dim connection As New SqlConnection(conexionConvenios)
        Dim strArray As String() = New String() {"EXEC UpdateLoteProrroga ", pNumeroLote, ",'", pRespuesta, "'"}
        Dim command As New SqlCommand(Conversions.ToString(String.Concat(strArray)), connection) With {
            .CommandType = CommandType.Text
        }
        connection.Open()
        Dim num2 As Integer = Conversions.ToInteger(command.ExecuteScalar)
        connection.Close()
        Return num2
    End Function

    Public Function ObtieneInformacionProrrogaDeIBS(pNumeroLote As String) As DataSet
        Dim lds As New DataSet()
        Dim lstrsql As String = String.Concat("SELECT EDLNPGR, CASE WHEN trim(edflagp) = '' OR trim(edflagp) = '3' THEN '' ELSE 'P' END AS WFLG1, EDFLAGP  FROM EDL6378W w  WHERE edllote = ", pNumeroLote)
        Dim num As Integer = (New OleDbDataAdapter(lstrsql, conexionIBS)).Fill(lds)
        Return lds
    End Function

    Public Function ProcesaProrrogaEnIBS(pNumeroLote As String) As String
        Return TCPClient.SendReceive(ConfigurationManager.AppSettings("ipJavaApp").Trim, ConfigurationManager.AppSettings("portJavaApp").Trim, ("Prorroga:" & pNumeroLote))
    End Function
End Class
