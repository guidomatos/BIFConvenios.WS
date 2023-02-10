Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.ApplicationServices

Public Class Log

    Dim strWSCadenaConexion As String = WS.Utils.CadenaConexion("ConnectionString")
    Public Enum Level
        Debug = 0
        Info = 1
        Warn = 2
        Errores = 3
        Fatal = 4
    End Enum

    Public Sub GrabarLog(pNivel As Level, pAccion As String, pMensaje As String, pExcepcion As String, pUsuario As String)
        'Dim conexionConvenios As String = ConfigurationManager.ConnectionStrings("BIFConveniosSQL").ConnectionString
        Dim cUtils As New WS.Utils
        'Dim conexionConvenios As String = cUtils.DescifrarCadenaConexion(ConfigurationManager.AppSettings("ConnectionString").ToString())
        Dim lconn As New SqlConnection(strWSCadenaConexion)
        Dim lcmd As SqlCommand
        Dim lUser As New User

        Try

            If pUsuario.Trim = "" Then
                pUsuario = lUser.Name
            End If

            Dim lstrsql As String = "INSERT INTO EventoSistema (Fecha,Hilo,Nivel,Accion,Mensaje,Excepcion, Usuario)" _
                                    & " VALUES ( GETDATE(), @Hilo, @Nivel, @Accion, @Mensaje, @Excepcion, @Usuario)"

            lcmd = New SqlCommand(lstrsql, lconn) With {
                .CommandType = CommandType.Text
            }

            AgregarParametro(lcmd, "@Hilo", ParameterDirection.Input, DbType.String, "BIFConvenios")
            AgregarParametro(lcmd, "@Nivel", ParameterDirection.Input, DbType.String, pNivel.ToString)
            AgregarParametro(lcmd, "@Accion", ParameterDirection.Input, DbType.String, pAccion)
            AgregarParametro(lcmd, "@Mensaje", ParameterDirection.Input, DbType.String, Left(pMensaje, 8000))
            AgregarParametro(lcmd, "@Excepcion", ParameterDirection.Input, DbType.String, Left(pExcepcion, 4000))
            AgregarParametro(lcmd, "@Usuario", ParameterDirection.Input, DbType.String, pUsuario)

            lconn.Open()
            lcmd.ExecuteNonQuery()
        Catch ex As Exception
            'No se pudo grabar
        Finally
            If (lconn.State = ConnectionState.Open) Then
                lconn.Close()
            End If
            lconn.Dispose()
        End Try

    End Sub

    Private Sub AgregarParametro(ByRef cmd As SqlCommand, nombreParam As String, direccionParam As ParameterDirection, tipoParam As DbType, valorParam As Object)
        Dim param As IDbDataParameter = cmd.CreateParameter()
        param.ParameterName = nombreParam
        param.DbType = tipoParam
        param.Direction = direccionParam
        param.Value = valorParam

        cmd.Parameters.Add(param)
    End Sub

End Class