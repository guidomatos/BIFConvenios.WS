Imports Microsoft.VisualBasic.CompilerServices

<DataContract()>
Public Class clsCoordinadorCliente
    ' Fields
    Private _CodigoCliente As Integer
    Private _CodigoCoordinador As Integer
    Private _NombreCoordinador As String
    Private _EmailCoordinador As String
    Private _Telefono As String
    Private _Anexo As String
    Private _Celular As String
    Private _Cargo As String
    Private _TipoPlanilla As String
    Private _EstadoCoordinador As Integer
    Private _UsuarioCreacion As String
    Private _FechaCreacion As DateTime
    Private _UsuarioModificacion As String
    Private _FechaModificacion As DateTime
    Private _Estado As Boolean

    ' Properties
    <DataMember()>
    Public Property CodigoCliente() As Integer
        Get
            Return _CodigoCliente
        End Get
        Set(value As Integer)
            _CodigoCliente = value
        End Set
    End Property

    <DataMember()>
    Public Property CodigoCoordinador() As Integer
        Get
            Return _CodigoCoordinador
        End Get
        Set(value As Integer)
            _CodigoCoordinador = value
        End Set
    End Property

    <DataMember()>
    Public Property NombreCoordinador() As String
        Get
            Return _NombreCoordinador
        End Get
        Set(value As String)
            _NombreCoordinador = value
        End Set
    End Property

    <DataMember()>
    Public Property EmailCoordinador() As String
        Get
            Return _EmailCoordinador
        End Get
        Set(value As String)
            _EmailCoordinador = value
        End Set
    End Property

    <DataMember()>
    Public Property Telefono() As String
        Get
            Return _Telefono
        End Get
        Set(value As String)
            _Telefono = value
        End Set
    End Property

    <DataMember()>
    Public Property Anexo() As String
        Get
            Return _Anexo
        End Get
        Set(value As String)
            _Anexo = value
        End Set
    End Property

    <DataMember()>
    Public Property Celular() As String
        Get
            Return _Celular
        End Get
        Set(value As String)
            _Celular = value
        End Set
    End Property

    <DataMember()>
    Public Property Cargo() As String
        Get
            Return _Cargo
        End Get
        Set(value As String)
            _Cargo = value
        End Set
    End Property

    <DataMember()>
    Public Property TipoPlanilla() As String
        Get
            Return _TipoPlanilla
        End Get
        Set(value As String)
            _TipoPlanilla = value
        End Set
    End Property

    <DataMember()>
    Public Property EstadoCoordinador() As Integer
        Get
            Return _EstadoCoordinador
        End Get
        Set(value As Integer)
            _EstadoCoordinador = value
        End Set
    End Property

    <DataMember()>
    Public Property UsuarioCreacion() As String
        Get
            Return _UsuarioCreacion
        End Get
        Set(value As String)
            _UsuarioCreacion = value
        End Set
    End Property

    <DataMember()>
    Public Property FechaCreacion() As DateTime
        Get
            Return _FechaCreacion
        End Get
        Set(value As DateTime)
            _FechaCreacion = value
        End Set
    End Property

    <DataMember()>
    Public Property UsuarioModificacion() As String
        Get
            Return _UsuarioModificacion
        End Get
        Set(value As String)
            _UsuarioModificacion = value
        End Set
    End Property

    <DataMember()>
    Public Property FechaModificacion() As DateTime
        Get
            Return _FechaModificacion
        End Get
        Set(value As DateTime)
            _FechaModificacion = value
        End Set
    End Property

    <DataMember()>
    Public Property Estado() As Boolean
        Get
            Return _Estado
        End Get
        Set(value As Boolean)
            _Estado = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(dr As DataRow)
        If Not IsDBNull(dr) Then
            _CodigoCliente = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("codigo_cliente"), Convert.ToInt32(dr.Table.Columns("codigo_cliente").ToString), 0))
            _CodigoCoordinador = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("id_coordinador"), Convert.ToInt32(dr.Table.Columns("id_coordinador").ToString), 0))
            _NombreCoordinador = Conversions.ToString(IIf(dr.Table.Columns.Contains("nombre_coordinador"), dr.Table.Columns("nombre_coordinador").ToString, ""))
            _EmailCoordinador = Conversions.ToString(IIf(dr.Table.Columns.Contains("email_coordinador"), dr.Table.Columns("email_coordinador").ToString, ""))
            _Telefono = Conversions.ToString(IIf(dr.Table.Columns.Contains("Telefono"), dr.Table.Columns("Telefono").ToString, ""))
            _Anexo = Conversions.ToString(IIf(dr.Table.Columns.Contains("Anexo"), dr.Table.Columns("Anexo").ToString, ""))
            _Celular = Conversions.ToString(IIf(dr.Table.Columns.Contains("Celular"), dr.Table.Columns("Celular").ToString, ""))
            _Cargo = Conversions.ToString(IIf(dr.Table.Columns.Contains("Cargo"), dr.Table.Columns("Cargo").ToString, ""))
            _TipoPlanilla = Conversions.ToString(IIf(dr.Table.Columns.Contains("TipoPlanilla"), dr.Table.Columns("TipoPlanilla").ToString, ""))
            _EstadoCoordinador = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("estado_usuario"), dr.Table.Columns("estado_usuario").ToString, ""))
            _UsuarioCreacion = Conversions.ToString(IIf(dr.Table.Columns.Contains("usuario_creacion"), dr.Table.Columns("usuario_creacion").ToString, ""))
            _FechaCreacion = Conversions.ToDate(IIf(dr.Table.Columns.Contains("fecha_creacion"), dr.Table.Columns("fecha_creacion").ToString, Convert.ToDateTime("")))
            _UsuarioModificacion = Conversions.ToString(IIf(dr.Table.Columns.Contains("usuario_modificacion"), dr.Table.Columns("fecha_modificacion").ToString, ""))
            _FechaModificacion = Conversions.ToDate(IIf(dr.Table.Columns.Contains("fecha_modificacion"), dr.Table.Columns("fecha_modificacion").ToString, ""))
            _Estado = Conversions.ToBoolean(IIf(dr.Table.Columns.Contains("estado_usuario"), dr.Table.Columns("estado_usuario").ToString(), False))
        End If
    End Sub
End Class
