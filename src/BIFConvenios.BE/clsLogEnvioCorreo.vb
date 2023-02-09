Imports Microsoft.VisualBasic.CompilerServices

Public Class clsLogEnvioCorreo
    ' Fields
    Private _iEnvioCorreoId As Integer
    Private _iProcesoAutomaticoId As Integer
    Private _iTipoEnvioCorreoId As Integer
    Private _vTipoEnvioCorreoId As String
    Private _iCodigoCliente As Integer
    Private _iCodigoIBS As Integer
    Private _vCodigoProceso As String
    Private _iAnioPeriodo As Integer
    Private _iMesPeriodo As Integer
    Private _vMensajeProceso As String
    Private _iEstado As Integer
    Private _vEstado As String
    Private _vUsuarioCreacion As String
    Private _dFechaCreacion As String
    Private _vUsuarioModificacion As String
    Private _dFechaModificacion As String

    ' Properties
    Public Property iEnvioCorreoId() As Integer
        Get
            Return _iEnvioCorreoId
        End Get
        Set(value As Integer)
            _iEnvioCorreoId = value
        End Set
    End Property

    Public Property iProcesoAutomaticoId() As Integer
        Get
            Return _iProcesoAutomaticoId
        End Get
        Set(value As Integer)
            _iProcesoAutomaticoId = value
        End Set
    End Property

    Public Property iTipoEnvioCorreoId() As Integer
        Get
            Return _iTipoEnvioCorreoId
        End Get
        Set(value As Integer)
            _iTipoEnvioCorreoId = value
        End Set
    End Property

    Public Property vTipoEnvioCorreoId() As String
        Get
            Return _vTipoEnvioCorreoId
        End Get
        Set(value As String)
            _vTipoEnvioCorreoId = value
        End Set
    End Property

    Public Property iCodigoCliente() As Integer
        Get
            Return _iCodigoCliente
        End Get
        Set(value As Integer)
            _iCodigoCliente = value
        End Set
    End Property

    Public Property iCodigoIBS() As Integer
        Get
            Return _iCodigoIBS
        End Get
        Set(value As Integer)
            _iCodigoIBS = value
        End Set
    End Property

    Public Property vCodigoProceso() As String
        Get
            Return _vCodigoProceso
        End Get
        Set(value As String)
            _vCodigoProceso = value
        End Set
    End Property

    Public Property iAnioPeriodo() As Integer
        Get
            Return _iAnioPeriodo
        End Get
        Set(value As Integer)
            _iAnioPeriodo = value
        End Set
    End Property

    Public Property iMesPeriodo() As Integer
        Get
            Return _iMesPeriodo
        End Get
        Set(value As Integer)
            _iMesPeriodo = value
        End Set
    End Property

    Public Property vMensajeProceso() As String
        Get
            Return _vMensajeProceso
        End Get
        Set(value As String)
            _vMensajeProceso = value
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

    Public Property vEstado() As String
        Get
            Return _vEstado
        End Get
        Set(value As String)
            _vEstado = value
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

    Public Property dFechaCreacion() As String
        Get
            Return _dFechaCreacion
        End Get
        Set(value As String)
            _dFechaCreacion = value
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
            _iEnvioCorreoId = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iEnvioCorreoId"), Convert.ToInt32(dr.Table.Columns("iEnvioCorreoId").ToString), 0))
            _iProcesoAutomaticoId = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iProcesoAutomaticoId"), Convert.ToInt32(dr.Table.Columns("iProcesoAutomaticoId").ToString), 0))
            _iTipoEnvioCorreoId = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iTipoEnvioCorreoId"), Convert.ToInt32(dr.Table.Columns("iTipoEnvioCorreoId").ToString), 0))
            _vTipoEnvioCorreoId = Conversions.ToString(IIf(dr.Table.Columns.Contains("vTipoEnvioCorreoId"), dr.Table.Columns("vTipoEnvioCorreoId"), ""))
            _iCodigoCliente = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iCodigoCliente"), Convert.ToInt32(dr.Table.Columns("iCodigoCliente").ToString), 0))
            _iCodigoIBS = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iCodigoIBS"), Convert.ToInt32(dr.Table.Columns("iCodigoIBS").ToString), 0))
            _vCodigoProceso = Conversions.ToString(IIf(dr.Table.Columns.Contains("vCodigoProceso"), dr.Table.Columns("vCodigoProceso").ToString, ""))
            _iAnioPeriodo = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iAnioPeriodo"), Convert.ToInt32(dr.Table.Columns("iAnioPeriodo").ToString), 0))
            _iMesPeriodo = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iMesPeriodo"), Convert.ToInt32(dr.Table.Columns("iMesPeriodo").ToString), 0))
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
