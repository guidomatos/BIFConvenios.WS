Imports Microsoft.VisualBasic.CompilerServices

<DataContract()>
Public Class clsProcesosAutomaticos
    ' Fields
    Private _iProcesoAutomaticoId As Integer
    Private _iTotalRegistros As Integer
    Private _iProcesados As Integer
    Private _iErroneos As Integer
    Private _vMensajeProceso As String
    Private _iEstado As Integer
    Private _vEstado As String
    Private _vUsuarioCreacion As String
    Private _dFechaCreacion As String
    Private _vUsuarioModificacion As String
    Private _dFechaModificacion As String

    ' Properties
    <DataMember()>
    Public Property iProcesoAutomaticoId() As Integer
        Get
            Return _iProcesoAutomaticoId
        End Get
        Set(value As Integer)
            _iProcesoAutomaticoId = value
        End Set
    End Property

    <DataMember()>
    Public Property iTotalRegistros() As Integer
        Get
            Return _iTotalRegistros
        End Get
        Set(value As Integer)
            _iTotalRegistros = value
        End Set
    End Property

    <DataMember()>
    Public Property iProcesados() As Integer
        Get
            Return _iProcesados
        End Get
        Set(value As Integer)
            _iProcesados = value
        End Set
    End Property

    <DataMember()>
    Public Property iErroneos() As Integer
        Get
            Return _iErroneos
        End Get
        Set(value As Integer)
            _iErroneos = value
        End Set
    End Property

    <DataMember()>
    Public Property vMensajeProceso() As String
        Get
            Return _vMensajeProceso
        End Get
        Set(value As String)
            _vMensajeProceso = value
        End Set
    End Property

    <DataMember()>
    Public Property iEstado() As Integer
        Get
            Return _iEstado
        End Get
        Set(value As Integer)
            _iEstado = value
        End Set
    End Property

    <DataMember()>
    Public Property vEstado() As String
        Get
            Return _vEstado
        End Get
        Set(value As String)
            _vEstado = value
        End Set
    End Property

    <DataMember()>
    Public Property vUsuarioCreacion() As String
        Get
            Return _vUsuarioCreacion
        End Get
        Set(value As String)
            _vUsuarioCreacion = value
        End Set
    End Property

    <DataMember()>
    Public Property dFechaCreacion() As String
        Get
            Return _dFechaCreacion
        End Get
        Set(value As String)
            _dFechaCreacion = value
        End Set
    End Property

    <DataMember()>
    Public Property vUsuarioModificacion() As String
        Get
            Return _vUsuarioModificacion
        End Get
        Set(value As String)
            _vUsuarioModificacion = value
        End Set
    End Property

    <DataMember()>
    Public Property dFechaModificacion() As String
        Get
            Return _dFechaModificacion
        End Get
        Set(value As String)
            _dFechaModificacion = value
        End Set
    End Property
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(dr As DataRow)
        If Not IsDBNull(dr) Then
            _iProcesoAutomaticoId = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iProcesoAutomaticoId"), Convert.ToInt32(dr.Table.Columns("iProcesoAutomaticoId").ToString), 0))
            _iTotalRegistros = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iTotalRegistros"), Convert.ToInt32(dr.Table.Columns("iTotalRegistros").ToString), 0))
            _iProcesados = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iProcesados"), Convert.ToInt32(dr.Table.Columns("iProcesados").ToString), 0))
            _iErroneos = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iErroneos"), Convert.ToInt32(dr.Table.Columns("iErroneos").ToString), 0))
            _vMensajeProceso = Conversions.ToString(IIf(dr.Table.Columns.Contains("vMensajeProceso"), dr.Table.Columns("vMensajeProceso").ToString, ""))
            _iEstado = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iEstado"), Convert.ToInt32(dr.Table.Columns("iEstado").ToString), 0))
            _vEstado = Conversions.ToString(IIf(dr.Table.Columns.Contains("vEstado"), dr.Table.Columns("vEstado"), ""))
            _vUsuarioCreacion = Conversions.ToString(IIf(dr.Table.Columns.Contains("vUsuarioCreacion"), dr.Table.Columns("vUsuarioCreacion").ToString, ""))
            _dFechaCreacion = Conversions.ToString(IIf(dr.Table.Columns.Contains("dFechaCreacion"), dr.Table.Columns("dFechaCreacion").ToString, ""))
            _vUsuarioModificacion = Conversions.ToString(IIf(dr.Table.Columns.Contains("vUsuarioModificacion"), dr.Table.Columns("vUsuarioModificacion").ToString, ""))
            _dFechaModificacion = Conversions.ToString(IIf(dr.Table.Columns.Contains("dFechaModificacion"), dr.Table.Columns("dFechaModificacion").ToString, ""))
        End If
    End Sub
End Class
