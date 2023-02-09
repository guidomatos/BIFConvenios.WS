Imports Microsoft.VisualBasic.CompilerServices

Public Class clsCliente
    ' Fields
    Private _CodigoCliente As Integer
    Private _NombreCliente As String
    Private _TipoArchivoEnviar As String
    Private _FormatoArchivo As String
    Private _TipoFormatoArchivo As String
    Private _CodigoReferencia As String
    Private _TipoDocumento As String
    Private _NumeroDocumento As String
    Private _CorreoElectronico As String
    Private _FormatoArchivoImportacion As String
    Private _Telefono1 As String
    Private _Telefono2 As String
    Private _Telefono3 As String
    Private _Telefono4 As String
    Private _DiaEnvioPlanilla As String
    Private _DiaCierrePlanilla As String
    Private _MesesAnticipacionEnvioListado As String
    Private _DiaCorte As String
    Private _IdFuncionario As Integer
    Private _CodigoIBS As Integer
    Private _CodigoInstitucion As String
    Private _CodigoInstitucionCAS As String
    Private _IndEnvioAutomaticoListado As String
    Private _BloquearCredito As Integer
    Private _Estado As Integer
    Private _CodigoOficina As Integer
    Private _NombreOficina As String
    Private _CodigoGestor As Integer
    Private _NombreGestor As String
    Private _UsuarioCreacion As String
    Private _FechaCreacion As DateTime
    Private _UsuarioModificacion As String
    Private _FechaModificacion As DateTime



    ' Properties
    Public Property CodigoCliente() As Integer
        Get
            Return _CodigoCliente
        End Get
        Set(value As Integer)
            _CodigoCliente = value
        End Set
    End Property

    Public Property NombreCliente() As String
        Get
            Return _NombreCliente
        End Get
        Set(value As String)
            _NombreCliente = value
        End Set
    End Property

    Public Property TipoArchivoEnviar() As String
        Get
            Return _TipoArchivoEnviar
        End Get
        Set(value As String)
            _TipoArchivoEnviar = value
        End Set
    End Property

    Public Property FormatoArchivo() As String
        Get
            Return _FormatoArchivo
        End Get
        Set(value As String)
            _FormatoArchivo = value
        End Set
    End Property

    Public Property TipoFormatoArchivo() As String
        Get
            Return _TipoFormatoArchivo
        End Get
        Set(value As String)
            _TipoFormatoArchivo = value
        End Set
    End Property

    Public Property CodigoReferencia() As String
        Get
            Return _CodigoReferencia
        End Get
        Set(value As String)
            _CodigoReferencia = value
        End Set
    End Property

    Public Property TipoDocumento() As String
        Get
            Return _TipoDocumento
        End Get
        Set(value As String)
            _TipoDocumento = value
        End Set
    End Property

    Public Property NumeroDocumento() As String
        Get
            Return _NumeroDocumento
        End Get
        Set(value As String)
            _NumeroDocumento = value
        End Set
    End Property

    Public Property CorreoElectronico() As String
        Get
            Return _CorreoElectronico
        End Get
        Set(value As String)
            _CorreoElectronico = value
        End Set
    End Property

    Public Property FormatoArchivoImportacion() As String
        Get
            Return _FormatoArchivoImportacion
        End Get
        Set(value As String)
            _FormatoArchivoImportacion = value
        End Set
    End Property

    Public Property Telefono1() As String
        Get
            Return _Telefono1
        End Get
        Set(value As String)
            _Telefono1 = value
        End Set
    End Property

    Public Property Telefono2() As String
        Get
            Return _Telefono2
        End Get
        Set(value As String)
            _Telefono2 = value
        End Set
    End Property

    Public Property Telefono3() As String
        Get
            Return _Telefono3
        End Get
        Set(value As String)
            _Telefono3 = value
        End Set
    End Property

    Public Property Telefono4() As String
        Get
            Return _Telefono4
        End Get
        Set(value As String)
            _Telefono4 = value
        End Set
    End Property

    Public Property DiaEnvioPlanilla() As String
        Get
            Return _DiaEnvioPlanilla
        End Get
        Set(value As String)
            _DiaEnvioPlanilla = value
        End Set
    End Property

    Public Property DiaCierrePlanilla() As String
        Get
            Return _DiaCierrePlanilla
        End Get
        Set(value As String)
            _DiaCierrePlanilla = value
        End Set
    End Property

    Public Property MesesAnticipacionEnvioListado() As String
        Get
            Return _MesesAnticipacionEnvioListado
        End Get
        Set(value As String)
            _MesesAnticipacionEnvioListado = value
        End Set
    End Property

    Public Property DiaCorte() As String
        Get
            Return _DiaCorte
        End Get
        Set(value As String)
            _DiaCorte = value
        End Set
    End Property

    Public Property IdFuncionario() As Integer
        Get
            Return _IdFuncionario
        End Get
        Set(value As Integer)
            _IdFuncionario = value
        End Set
    End Property

    Public Property CodigoIBS() As Integer
        Get
            Return _CodigoIBS
        End Get
        Set(value As Integer)
            _CodigoIBS = value
        End Set
    End Property

    Public Property CodigoInstitucion() As String
        Get
            Return _CodigoInstitucion
        End Get
        Set(value As String)
            _CodigoInstitucion = value
        End Set
    End Property

    Public Property CodigoInstitucionCAS() As String
        Get
            Return _CodigoInstitucionCAS
        End Get
        Set(value As String)
            _CodigoInstitucionCAS = value
        End Set
    End Property

    Public Property IndEnvioAutomaticoListado() As String
        Get
            Return _IndEnvioAutomaticoListado
        End Get
        Set(value As String)
            _IndEnvioAutomaticoListado = value
        End Set
    End Property

    Public Property BloquearCredito() As Integer
        Get
            Return _BloquearCredito
        End Get
        Set(value As Integer)
            _BloquearCredito = value
        End Set
    End Property

    Public Property Estado() As Integer
        Get
            Return _Estado
        End Get
        Set(value As Integer)
            _Estado = value
        End Set
    End Property

    Public Property CodigoOficina() As Integer
        Get
            Return _CodigoOficina
        End Get
        Set(value As Integer)
            _CodigoOficina = value
        End Set
    End Property

    Public Property NombreOficina() As String
        Get
            Return _NombreOficina
        End Get
        Set(value As String)
            _NombreOficina = value
        End Set
    End Property

    Public Property CodigoGestor() As Integer
        Get
            Return _CodigoGestor
        End Get
        Set(value As Integer)
            _CodigoGestor = value
        End Set
    End Property

    Public Property NombreGestor() As String
        Get
            Return _NombreGestor
        End Get
        Set(value As String)
            _NombreGestor = value
        End Set
    End Property

    Public Property UsuarioCreacion() As String
        Get
            Return _UsuarioCreacion
        End Get
        Set(value As String)
            _UsuarioCreacion = value
        End Set
    End Property

    Public ReadOnly Property FechaCreacion() As DateTime
        Get
            Return _FechaCreacion
        End Get
    End Property

    Public Property UsuarioModificacion() As String
        Get
            Return _UsuarioModificacion
        End Get
        Set(value As String)
            _UsuarioModificacion = value
        End Set
    End Property

    Public ReadOnly Property FechaModificacion() As DateTime
        Get
            Return _FechaModificacion
        End Get
    End Property


    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(dr As DataRow)
        If Not IsDBNull(dr) Then
            _CodigoCliente = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("Codigo_Cliente"), Convert.ToInt32(dr.Table.Columns("Codigo_Cliente").ToString), 0))
            _NombreCliente = Conversions.ToString(IIf(dr.Table.Columns.Contains("Nombre_Cliente"), dr.Table.Columns("Nombre_Cliente").ToString, ""))
            _TipoArchivoEnviar = Conversions.ToString(IIf(dr.Table.Columns.Contains("TipoArchivoEnviar"), dr.Table.Columns("TipoArchivoEnviar").ToString, ""))
            _FormatoArchivo = Conversions.ToString(IIf(dr.Table.Columns.Contains("FormatoArchivo"), dr.Table.Columns("FormatoArchivo").ToString, ""))
            _TipoFormatoArchivo = Conversions.ToString(IIf(dr.Table.Columns.Contains("TipoFormatoArchivo"), dr.Table.Columns("TipoFormatoArchivo").ToString, ""))
            _CodigoReferencia = Conversions.ToString(IIf(dr.Table.Columns.Contains("Codigo_Referencia"), dr.Table.Columns("Codigo_Referencia").ToString, ""))
            _TipoDocumento = Conversions.ToString(IIf(dr.Table.Columns.Contains("TipoDocumento"), dr.Table.Columns("TipoDocumento").ToString, ""))
            _NumeroDocumento = Conversions.ToString(IIf(dr.Table.Columns.Contains("NumeroDocumento"), dr.Table.Columns("NumeroDocumento").ToString, ""))
            _CorreoElectronico = Conversions.ToString(IIf(dr.Table.Columns.Contains("CorreoElectronico"), dr.Table.Columns("CorreoElectronico").ToString, ""))
            _FormatoArchivoImportacion = Conversions.ToString(IIf(dr.Table.Columns.Contains("FormatoArchivoImportacion"), dr.Table.Columns("FormatoArchivoImportacion").ToString, ""))
            _Telefono1 = Conversions.ToString(IIf(dr.Table.Columns.Contains("telefono_1"), dr.Table.Columns("Telefono_1").ToString, ""))
            _Telefono2 = Conversions.ToString(IIf(dr.Table.Columns.Contains("telefono_2"), dr.Table.Columns("Telefono2").ToString, ""))
            _Telefono3 = Conversions.ToString(IIf(dr.Table.Columns.Contains("telefono_3"), dr.Table.Columns("Telefono_3").ToString, ""))
            _Telefono4 = Conversions.ToString(IIf(dr.Table.Columns.Contains("telefono_4"), dr.Table.Columns("Telefono_4").ToString, ""))
            _DiaEnvioPlanilla = Conversions.ToString(IIf(dr.Table.Columns.Contains("dia_envio_planilla"), dr.Table.Columns("dia_envio_planilla").ToString, ""))
            _DiaCierrePlanilla = Conversions.ToString(IIf(dr.Table.Columns.Contains("dia_cierre_planilla"), dr.Table.Columns.Contains("dia_cierre_planilla").ToString, ""))
            _MesesAnticipacionEnvioListado = Conversions.ToString(IIf(dr.Table.Columns.Contains("meses_anticipacion_envio_listado"), dr.Table.Columns("meses_anticipacion_envio_listado").ToString, ""))
            _DiaCorte = Conversions.ToString(IIf(dr.Table.Columns.Contains("dia_corte"), dr.Table.Columns("dia_corte").ToString, ""))
            _IdFuncionario = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("id_funcionario"), Convert.ToInt32(dr.Table.Columns("id_funcionario").ToString), 0))
            _CodigoIBS = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("codigo_IBS"), Convert.ToInt32(dr.Table.Columns("codigo_IBS").ToString), 0))
            _CodigoInstitucion = Conversions.ToString(IIf(dr.Table.Columns.Contains("codigo_institucion"), dr.Table.Columns("codigo_institucion").ToString, ""))
            _CodigoInstitucionCAS = Conversions.ToString(IIf(dr.Table.Columns.Contains("codigo_institucion_cas"), dr.Table.Columns("codigo_institucion_cas").ToString, ""))
            _IndEnvioAutomaticoListado = Conversions.ToString(IIf(dr.Table.Columns.Contains("ind_envio_automatico_listado"), dr.Table.Columns("ind_envio_automatico_listado").ToString, ""))
            _Estado = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("Estado"), Convert.ToInt32(dr.Table.Columns("Estado").ToString), 0))
            _UsuarioCreacion = Conversions.ToString(IIf(dr.Table.Columns.Contains("usuario_creacion"), dr.Table.Columns("usuario_creacion").ToString, ""))
            _FechaCreacion = Conversions.ToDate(IIf(dr.Table.Columns.Contains("fecha_creacion"), Convert.ToDateTime(dr.Table.Columns("fecha_creacion").ToString), Convert.ToDateTime("")))
            _UsuarioModificacion = Conversions.ToString(IIf(dr.Table.Columns.Contains("usuario_modificacion"), dr.Table.Columns("usuario_modificacion").ToString, ""))
            _FechaModificacion = Conversions.ToDate(IIf(dr.Table.Columns.Contains("fecha_modificacion"), Convert.ToDateTime(dr.Table.Columns("fecha_modificacion").ToString), Convert.ToDateTime("")))
        End If
    End Sub
End Class

