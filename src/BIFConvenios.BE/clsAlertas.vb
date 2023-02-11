Imports Microsoft.VisualBasic.CompilerServices
<DataContract()>
Public Class clsAlertas
    ' Fields
    Private _iAlertaID As Integer
    Private _iTipoAlerta As Integer
    Private _vTipoAlerta As String
    Private _vNombreAlerta As String
    Private _vDescripcionAlerta As String
    Private _vAsuntoMensaje As String
    Private _vCuerpoMensaje As String
    Private _iEstadoAlerta As Integer
    Private _vUsuarioCreacion As String
    Private _dFechaCreacion As DateTime
    Private _vUsuarioModificacion As String
    Private _dFechaModificacion As DateTime

    ' Properties
    <DataMember()>
    Public Property iAlertaId() As Integer
        Get
            Return _iAlertaID
        End Get
        Set(value As Integer)
            _iAlertaID = value
        End Set
    End Property

    <DataMember()>
    Public Property iTipoAlerta() As Integer
        Get
            Return _iTipoAlerta
        End Get
        Set(value As Integer)
            _iTipoAlerta = value
        End Set
    End Property

    <DataMember()>
    Public Property vTipoAlerta() As String
        Get
            Return _vTipoAlerta
        End Get
        Set(value As String)
            _vTipoAlerta = value
        End Set
    End Property

    <DataMember()>
    Public Property vNombreAlerta() As String
        Get
            Return _vNombreAlerta
        End Get
        Set(value As String)
            _vNombreAlerta = value
        End Set
    End Property

    <DataMember()>
    Public Property vDescripcionAlerta() As String
        Get
            Return _vDescripcionAlerta
        End Get
        Set(value As String)
            _vDescripcionAlerta = value
        End Set
    End Property

    <DataMember()>
    Public Property vAsuntoMensaje() As String
        Get
            Return _vAsuntoMensaje
        End Get
        Set(value As String)
            _vAsuntoMensaje = value
        End Set
    End Property

    <DataMember()>
    Public Property vCuerpoMensaje() As String
        Get
            Return _vCuerpoMensaje
        End Get
        Set(value As String)
            _vCuerpoMensaje = value
        End Set
    End Property

    <DataMember()>
    Public Property iEstadoAlerta() As Integer
        Get
            Return _iEstadoAlerta
        End Get
        Set(value As Integer)
            _iEstadoAlerta = value
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
    Public Property dFechaCreacion() As DateTime
        Get
            Return _dFechaCreacion
        End Get
        Set(value As DateTime)
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
    Public Property dFechaModificacion() As DateTime
        Get
            Return _dFechaModificacion
        End Get
        Set(value As DateTime)
            _dFechaModificacion = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(dr As DataRow)
        If Not IsDBNull(dr) Then
            _iAlertaID = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iAlertaId"), Convert.ToInt32(dr.Table.Columns("iAlertaId").ToString), 0))
            _iTipoAlerta = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iTipoAlerta"), Convert.ToInt32(dr.Table.Columns("iTipoAlerta").ToString), 0))
            _vTipoAlerta = Conversions.ToString(IIf(dr.Table.Columns.Contains("vTipoAlerta"), dr.Table.Columns("vTipoAlerta").ToString, ""))
            _vNombreAlerta = Conversions.ToString(IIf(dr.Table.Columns.Contains("vNombreAlerta"), dr.Table.Columns("vNombreAlerta").ToString, ""))
            _vDescripcionAlerta = Conversions.ToString(IIf(dr.Table.Columns.Contains("vDescripcionAlerta"), dr.Table.Columns("vDescripcionAlerta").ToString, ""))
            _vAsuntoMensaje = Conversions.ToString(IIf(dr.Table.Columns.Contains("vAsuntoMensaje"), dr.Table.Columns("vAsuntoMensaje").ToString, ""))
            _vCuerpoMensaje = Conversions.ToString(IIf(dr.Table.Columns.Contains("vCuerpoMensaje"), dr.Table.Columns("vCuerpoMensaje").ToString, ""))
            _iEstadoAlerta = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iEstadoAlerta"), Convert.ToInt32(dr.Table.Columns("iEstadoAlerta").ToString), 0))
            _vUsuarioCreacion = Conversions.ToString(IIf(dr.Table.Columns.Contains("vUsuarioCreacion"), dr.Table.Columns("vUsuarioCreacion").ToString, ""))
            _dFechaCreacion = Conversions.ToDate(IIf(dr.Table.Columns.Contains("dFechaCreacion"), Convert.ToDateTime(dr.Table.Columns("dFechaCreacion")), Convert.ToDateTime("")))
            _vUsuarioModificacion = Conversions.ToString(IIf(dr.Table.Columns.Contains("vUsuarioModificacion"), dr.Table.Columns("vUsuarioModificacion").ToString, ""))
            _dFechaModificacion = Conversions.ToDate(IIf(dr.Table.Columns.Contains("dFechaModificacion"), Convert.ToDateTime(dr.Table.Columns("dFechaModificacion").ToString), Convert.ToDateTime("")))
        End If
    End Sub
End Class
