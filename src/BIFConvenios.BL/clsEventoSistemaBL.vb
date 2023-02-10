Imports BIFConvenios.BE
Imports BIFConvenios.DO
Imports Microsoft.VisualBasic.CompilerServices
Imports Resource

Public Class clsEventoSistemaBL
    <DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
    End Sub
    ' Methods
    Public Function DevolverObjeto(pstrHilo As String, pstrNivel As String, pstrAccion As String, pstrMensaje As String, pstrExcepcion As String, pstrUsuario As String) As clsEventoSistema
        Dim sistema2 As New clsEventoSistema With {
            .Hilo = pstrHilo,
            .Nivel = pstrNivel,
            .Accion = pstrAccion,
            .Mensaje = pstrMensaje,
            .Excepcion = pstrExcepcion,
            .Usuario = pstrUsuario
        }
        Return sistema2
    End Function

    Public Function Insertar(pobjEventoSistema As clsEventoSistema) As Integer
        Dim num As Integer
        Try
            num = Singleton(Of clsEventoSistemaDO).Create.Insertar(pobjEventoSistema)
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
