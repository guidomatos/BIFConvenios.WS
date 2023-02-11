Imports Microsoft.VisualBasic.CompilerServices

<DataContract()>
Public Class clsReponsableOficina
    ' Fields
    Private _iResponsableId As Integer
    Private _iOficinaId As Integer
    Private _vOficina As String
    Private _vNombreResponsable As String
    Private _vCorreoResponsable As String
    Private _iEstado As Integer
    Private _vUsuarioCreacion As String
    Private _dFechaCreacion As DateTime
    Private _vUsuarioModificacion As String
    Private _dFechaModificacion As DateTime

    ' Properties
    <DataMember()>
    Public Property iResponsableId() As Integer
        Get
            Return _iResponsableId
        End Get
        Set(value As Integer)
            _iResponsableId = value
        End Set
    End Property

    <DataMember()>
    Public Property iOficinaId() As Integer
        Get
            Return _iOficinaId
        End Get
        Set(value As Integer)
            _iOficinaId = value
        End Set
    End Property

    <DataMember()>
    Public Property vOficina() As String
        Get
            Return _vOficina
        End Get
        Set(value As String)
            _vOficina = value
        End Set
    End Property

    <DataMember()>
    Public Property vNombreResponsable() As String
        Get
            Return _vNombreResponsable
        End Get
        Set(value As String)
            _vNombreResponsable = value
        End Set
    End Property

    <DataMember()>
    Public Property vCorreoResponsable() As String
        Get
            Return _vCorreoResponsable
        End Get
        Set(value As String)
            _vCorreoResponsable = value
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
            _iResponsableId = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iResponsableId"), Convert.ToInt32(dr.Table.Columns("iResponsableId").ToString), 0))
            _iOficinaId = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iOficinaId"), Convert.ToInt32(dr.Table.Columns("iOficinaId").ToString), 0))
            _vOficina = Conversions.ToString(IIf(dr.Table.Columns.Contains("vOficina"), dr.Table.Columns("vOficina").ToString, ""))
            _vNombreResponsable = Conversions.ToString(IIf(dr.Table.Columns.Contains("vNombreResponsable"), dr.Table.Columns("vNombreResponsable").ToString, ""))
            _vCorreoResponsable = Conversions.ToString(IIf(dr.Table.Columns.Contains("vCorreoResponsable"), dr.Table.Columns("vCorreoResponsable").ToString, ""))
            _iEstado = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iEstado"), Convert.ToInt32(dr.Table.Columns("iEstado").ToString), 0))
            _vUsuarioCreacion = Conversions.ToString(IIf(dr.Table.Columns.Contains("vUsuarioCreacion"), dr.Table.Columns("vUsuarioCreacion").ToString, ""))
            _dFechaCreacion = Conversions.ToDate(IIf(dr.Table.Columns.Contains("dFechaCreacion"), Convert.ToDateTime(dr.Table.Columns("dFechaCreacion").ToString), Convert.ToDateTime("")))
            _vUsuarioModificacion = Conversions.ToString(IIf(dr.Table.Columns.Contains("vUsuarioModificacion"), dr.Table.Columns.Contains("vUsuarioModificacion").ToString, ""))
            _dFechaModificacion = Conversions.ToDate(IIf(dr.Table.Columns.Contains("dFechaModificacion"), Convert.ToDateTime(dr.Table.Columns("dFechaModificacion").ToString), Convert.ToDateTime("")))
        End If
    End Sub

End Class
