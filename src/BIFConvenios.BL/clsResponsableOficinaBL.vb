Imports BIFConvenios.BE
Imports BIFConvenios.DO
Imports Microsoft.VisualBasic.CompilerServices
Imports Resource

Public Class clsResponsableOficinaBL
    <DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
    End Sub
    ' Methods
    Public Function ChangeStatus(pobjResponsableOficina As clsReponsableOficina) As Integer
        Dim num As Integer
        Try
            num = Singleton(Of clsResponsableOficinaDO).Create.ChangeStatus(pobjResponsableOficina)
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

    Public Function Insert(pobjResponsableOficina As clsReponsableOficina) As Integer
        Dim num As Integer
        Try
            num = Singleton(Of clsResponsableOficinaDO).Create.Insert(pobjResponsableOficina)
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

    Public Function ObtenerListaOficinasDesdeAS400() As DataTable
        Dim table As DataTable
        Try
            table = Singleton(Of clsResponsableOficinaDO).Create.ObtenerListaOficinasDesdeAS400
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

    Public Function ObtenerOficinaDesdeAS400PorCriterio(pintTipo As Integer, pstrValor As String) As DataTable
        Dim table As DataTable
        Try
            table = Singleton(Of clsResponsableOficinaDO).Create.ObtenerOficinaDesdeAS400PorCriterio(pintTipo, pstrValor)
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

    Public Function ObtenerResponsableOficinaPorCriterio(pobjResponsableOficina As clsReponsableOficina) As DataTable
        Dim table As DataTable
        Try
            table = Singleton(Of clsResponsableOficinaDO).Create.ObtenerResponsableOficinaPorCriterio(pobjResponsableOficina)
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

    Public Function Update(pobjResponsableOficina As clsReponsableOficina) As Integer
        Dim num As Integer
        Try
            num = Singleton(Of clsResponsableOficinaDO).Create.Update(pobjResponsableOficina)
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
