Imports BIFConvenios.BE
Imports BIFConvenios.DO
Imports Microsoft.VisualBasic.CompilerServices
Imports Resource

Public Class clsCoordinadorClienteBL
    <DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
    End Sub
    ' Methods
    Public Function ChangeStatus(pobjCoordinadorCliente As clsCoordinadorCliente) As Integer
        Dim num As Integer
        Try
            num = Singleton(Of clsCoordinadorClienteDO).Create.ChangeStatus(pobjCoordinadorCliente)
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

    Public Function Insert(pobjCoordinadorCliente As clsCoordinadorCliente) As Integer
        Dim num As Integer
        Try
            num = Singleton(Of clsCoordinadorClienteDO).Create.Insert(pobjCoordinadorCliente)
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

    Public Function ObtieneCoordinadorPorCriterio(pintCodCoordinador As Integer, pintCodCliente As Integer, pintEstado As Integer) As DataTable
        Dim table As DataTable
        Try
            table = Singleton(Of clsCoordinadorClienteDO).Create.ObtieneCoordinadorPorCriterio(pintCodCoordinador, pintCodCliente, pintEstado)
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

    Public Function Update(pobjCoordinadorCliente As clsCoordinadorCliente) As Integer
        Dim num As Integer
        Try
            num = Singleton(Of clsCoordinadorClienteDO).Create.Update(pobjCoordinadorCliente)
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
    'Descripcion: se agrego metodod para el cambio de estado del coordinador - debera copiarse para el pase
    Public Function ChangeStatusCoordinador(pobjCoordinadorCliente As clsCoordinadorCliente) As Integer
        Dim num As Integer
        Try
            num = Singleton(Of clsCoordinadorClienteDO).Create().ChangeStatusCoordinador(pobjCoordinadorCliente)
        Catch handledException As HandledException
            ProjectData.SetProjectError(handledException)
            Throw handledException
        Catch exception As Exception
            ProjectData.SetProjectError(exception)
            Throw exception
        End Try
        Return num
    End Function
    'Descripcion: se agrego metodo insertar coordinadores por cliente - debera copiarse para el pase
    Public Function InsertCoordinador(pobjCoordinadorCliente As clsCoordinadorCliente) As Integer
        Dim num As Integer
        Try
            num = Singleton(Of clsCoordinadorClienteDO).Create().InsertCoordinadorPersona(pobjCoordinadorCliente)
        Catch handledException As HandledException
            ProjectData.SetProjectError(handledException)
            Throw handledException
        Catch exception As Exception
            ProjectData.SetProjectError(exception)
            Throw exception
        End Try
        Return num
    End Function
    'Descripcion: se agrego metodo para obtener coordinadores por cliente - debera copiarse para el pase
    Public Function ObtieneCoordinadorClientePorCriterio(pintCodCoordinador As Integer, pintCodCliente As Integer, pintEstado As Integer) As DataTable
        Dim dataTable As DataTable
        Try
            dataTable = Singleton(Of clsCoordinadorClienteDO).Create().ObtieneCoordinadorClientePorCriterio(pintCodCoordinador, pintCodCliente, pintEstado)
        Catch handledException As HandledException
            ProjectData.SetProjectError(handledException)
            Throw handledException
        Catch exception As Exception
            ProjectData.SetProjectError(exception)
            Throw exception
        End Try
        Return dataTable
    End Function
    'Descripcion: se agrego metodo actualizar coordinadores por cliente - debera copiarse para el pase
    Public Function UpdateCoordinador(pobjCoordinadorCliente As clsCoordinadorCliente) As Integer
        Dim num As Integer
        Try
            num = Singleton(Of clsCoordinadorClienteDO).Create().UpdateCoordinadorPersona(pobjCoordinadorCliente)
        Catch handledException As HandledException
            ProjectData.SetProjectError(handledException)
            Throw handledException
        Catch exception As Exception
            ProjectData.SetProjectError(exception)
            Throw exception
        End Try
        Return num
    End Function

End Class
