Imports Microsoft.VisualBasic.CompilerServices

<DataContract()>
Public Class clsSystemParameters
    ' Fields
    Private _iGrupoId As Integer
    Private _iParametroId As Integer
    Private _vDescripcion As String
    Private _vValor As String
    Private _iOrden As Integer
    Private _iVisible As Integer
    Private _dFechaInicio As DateTime
    Private _dFechaFin As DateTime
    Private _iEstado As Integer
    Private _vUsuarioCreacion As String
    Private _dFechaCreacion As DateTime
    Private _vUsuarioModificacion As String
    Private _dFechaModificacion As DateTime

    ' Properties
    <DataMember()>
    Public Property iGrupoId() As Integer
        Get
            Return _iGrupoId
        End Get
        Set(value As Integer)
            _iGrupoId = value
        End Set
    End Property

    <DataMember()>
    Public Property iParametroId() As Integer
        Get
            Return _iParametroId
        End Get
        Set(value As Integer)
            _iParametroId = value
        End Set
    End Property

    <DataMember()>
    Public Property vDescripcion() As String
        Get
            Return _vDescripcion
        End Get
        Set(value As String)
            _vDescripcion = value
        End Set
    End Property

    <DataMember()>
    Public Property vValor() As String
        Get
            Return _vValor
        End Get
        Set(value As String)
            _vValor = value
        End Set
    End Property

    <DataMember()>
    Public Property iOrden() As Integer
        Get
            Return _iOrden
        End Get
        Set(value As Integer)
            _iOrden = value
        End Set
    End Property

    <DataMember()>
    Public Property iVisible() As Integer
        Get
            Return _iVisible
        End Get
        Set(value As Integer)
            _iVisible = value
        End Set
    End Property

    <DataMember()>
    Public Property dFechaInicio() As DateTime
        Get
            Return _dFechaInicio
        End Get
        Set(value As DateTime)
            _dFechaInicio = value
        End Set
    End Property

    <DataMember()>
    Public Property dFechaFin() As DateTime
        Get
            Return _dFechaFin
        End Get
        Set(value As DateTime)
            _dFechaFin = value
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
            _iGrupoId = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iGrupoId"), Convert.ToInt32(dr.Table.Columns("iGrupoId").ToString), 0))
            _iParametroId = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iParametroId"), Convert.ToInt32(dr.Table.Columns.Contains("iParametroId").ToString), 0))
            _vDescripcion = Conversions.ToString(IIf(dr.Table.Columns.Contains("vDescripcion"), dr.Table.Columns("vDescripcion").ToString, ""))
            _vValor = Conversions.ToString(IIf(dr.Table.Columns.Contains("vValor"), dr.Table.Columns("vValor").ToString, ""))
            _iOrden = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iOrden"), Convert.ToInt32(dr.Table.Columns("iOrden").ToString), 0))
            _iVisible = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iVisible"), Convert.ToInt32(dr.Table.Columns("iVisible").ToString), 0))
            _dFechaInicio = Conversions.ToDate(IIf(dr.Table.Columns.Contains("dFechaInicio"), Convert.ToDateTime(dr.Table.Columns("dFechaInicio").ToString), Convert.ToDateTime("")))
            _dFechaFin = Conversions.ToDate(IIf(dr.Table.Columns.Contains("dFechaFin"), Convert.ToDateTime(dr.Table.Columns("dFechaFin").ToString), Convert.ToDateTime("")))
            _iEstado = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iEstado"), Convert.ToInt32(dr.Table.Columns("iEstado").ToString), 0))
            _vUsuarioCreacion = Conversions.ToString(IIf(dr.Table.Columns.Contains("vUsuarioCreacion"), dr.Table.Columns("vUsuarioCreacion").ToString, ""))
            _dFechaCreacion = Conversions.ToDate(IIf(dr.Table.Columns.Contains("dFechaCreacion"), Convert.ToDateTime(dr.Table.Columns("dFechaCreacion").ToString), Convert.ToDateTime("")))
            _vUsuarioModificacion = Conversions.ToString(IIf(dr.Table.Columns.Contains("vUsuarioModificacion"), dr.Table.Columns("vUsuarioModificacion").ToString, ""))
            _dFechaModificacion = Conversions.ToDate(IIf(dr.Table.Columns.Contains("dFechaModificacion"), Convert.ToDateTime(dr.Table.Columns("dFechaModificacion").ToString), Convert.ToDateTime("")))
        End If
    End Sub

End Class
