Imports Microsoft.VisualBasic.CompilerServices

Public Class clsAlertasClientes
    Private _iAlertaClienteId As Integer
    Private _iAlertaId As Integer
    Private _iClienteId As Integer
    Private _iDiasAntes As Integer
    Private _iDiasDespues As Integer
    Private _iAdjunto As Integer
    Private _iEstado As Integer
    Private _vUsuarioCreacion As String
    Private _dFechaCreacion As DateTime
    Private _vUsuarioModificacion As String
    Private _dFechaModificacion As DateTime
    Public Property dFechaCreacion() As DateTime
        Get
            Return _dFechaCreacion
        End Get
        Set(value As DateTime)
            _dFechaCreacion = value
        End Set
    End Property

    Public Property dFechaModificacion() As DateTime
        Get
            Return _dFechaModificacion
        End Get
        Set(value As DateTime)
            _dFechaModificacion = value
        End Set
    End Property

    Public Property iAdjunto() As Integer
        Get
            Return _iAdjunto
        End Get
        Set(value As Integer)
            _iAdjunto = value
        End Set
    End Property

    Public Property iAlertaClienteId() As Integer
        Get
            Return _iAlertaClienteId
        End Get
        Set(value As Integer)
            _iAlertaClienteId = value
        End Set
    End Property

    Public Property iAlertaId() As Integer
        Get
            Return _iAlertaId
        End Get
        Set(value As Integer)
            _iAlertaId = value
        End Set
    End Property

    Public Property iClienteId() As Integer
        Get
            Return _iClienteId
        End Get
        Set(value As Integer)
            _iClienteId = value
        End Set
    End Property

    Public Property iDiasAntes() As Integer
        Get
            Return _iDiasAntes
        End Get
        Set(value As Integer)
            _iDiasAntes = value
        End Set
    End Property

    Public Property iDiasDespues() As Integer
        Get
            Return _iDiasDespues
        End Get
        Set(value As Integer)
            _iDiasDespues = value
        End Set
    End Property

    Public Property iEstado() As Integer
        Get
            Return _iEstado
        End Get
        Set(value As Integer)
            _iEstado = value
        End Set
    End Property

    Public Property vUsuarioCreacion() As String
        Get
            Return _vUsuarioCreacion
        End Get
        Set(value As String)
            _vUsuarioCreacion = value
        End Set
    End Property

    Public Property vUsuarioModificacion() As String
        Get
            Return _vUsuarioModificacion
        End Get
        Set(value As String)
            _vUsuarioModificacion = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(dr As DataRow)
        MyBase.New()
        If (Not IsDBNull(dr)) Then
            _iAlertaClienteId = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iAlertaClienteId"), Convert.ToInt32(dr.Table.Columns("iAlertaClienteId").ToString()), 0))
            _iAlertaId = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iAlertaId"), Convert.ToInt32(dr.Table.Columns("iAlertaId").ToString()), 0))
            _iClienteId = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iClienteId"), Convert.ToInt32(dr.Table.Columns("iClienteId").ToString()), 0))
            _iDiasAntes = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iDiasAntes"), Convert.ToInt32(dr.Table.Columns("iDiasAntes").ToString()), 0))
            _iDiasDespues = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iDiasDespues"), Convert.ToInt32(dr.Table.Columns("iDiasDespues").ToString()), 0))
            _iAdjunto = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iAdjunto"), Convert.ToInt32(dr.Table.Columns("iAdjunto").ToString()), 0))
            _iEstado = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iEstado"), Convert.ToInt32(dr.Table.Columns("iEstado").ToString()), 0))
            _vUsuarioCreacion = Conversions.ToString(IIf(dr.Table.Columns.Contains("vUsuarioCreacion"), dr.Table.Columns("vUsuarioCreacion").ToString(), ""))
            _dFechaCreacion = Conversions.ToDate(IIf(dr.Table.Columns.Contains("dFechaCreacion"), Convert.ToDateTime(dr.Table.Columns("dFechaCreacion").ToString()), Convert.ToDateTime("")))
            _vUsuarioModificacion = Conversions.ToString(IIf(dr.Table.Columns.Contains("vUsuarioModificacion"), dr.Table.Columns.Contains("vUsuarioModificacion").ToString, ""))
            _dFechaModificacion = Conversions.ToDate(IIf(dr.Table.Columns.Contains("dFechaModificacion"), Convert.ToDateTime(dr.Table.Columns("dFechaModificacion").ToString), Convert.ToDateTime("")))

            'Dim flag As Boolean = dr.Table.Columns.Contains("vUsuarioModificacion")
            'Dim flag1 As Boolean = dr.Table.Columns.Contains("vUsuarioModificacion")
            '_vUsuarioModificacion = Conversions.ToString(IIf(flag, flag1.ToString(), ""))
            '_dFechaModificacion = Conversions.ToDate(IIf(dr.Table.Columns.Contains("dFechaModificacion"), Convert.ToDateTime(dr.Table.Columns("dFechaModificacion").ToString()), Convert.ToDateTime("")))
        End If
    End Sub
End Class
