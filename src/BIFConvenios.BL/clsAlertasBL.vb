Imports BIFConvenios.BE
Imports BIFConvenios.DO
Imports Microsoft.VisualBasic.CompilerServices
Imports Resource

Public Class clsAlertasBL
    <DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
    End Sub

    ' Methods
    Public Function ChangeStatus(pobjAlertas As clsAlertas) As Integer
        Dim num As Integer
        Try
            num = Singleton(Of clsAlertasDO).Create.ChangeStatus(pobjAlertas)
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

    Public Function Insert(pobjAlertas As clsAlertas) As Integer
        Dim num As Integer
        Try
            num = Singleton(Of clsAlertasDO).Create.Insert(pobjAlertas)
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

    Public Function ObtieneAlertasPorCriterio(pobjAlertas As clsAlertas) As DataTable
        Dim table As DataTable
        Try
            table = Singleton(Of clsAlertasDO).Create.ObtieneAlertasPorCriterio(pobjAlertas)
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

    Public Function Update(pobjAlertas As clsAlertas) As Integer
        Dim num As Integer
        Try
            num = Singleton(Of clsAlertasDO).Create.Update(pobjAlertas)
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
