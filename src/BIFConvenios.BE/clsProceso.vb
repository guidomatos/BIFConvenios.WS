Imports Microsoft.VisualBasic.CompilerServices

Public Class clsProceso
    ' Fields
    Private _CodigoProceso As String
    Private _Estado As String
    Private _AnioPeriodo As String
    Private _MesPeriodo As String
    Private _FechaProcesoAS400 As String
    Private _CodigoCliente As Integer
    Private _FechaCargaAS400 As DateTime
    Private _FechaGeneracionCF As DateTime
    Private _FechaDescargaArchivo As DateTime
    Private _FechaEnvioEmail As DateTime
    Private _TmpStatusGen As String
    Private _FechaProcesoAD As DateTime
    Private _FechaEnvioAS400 As DateTime
    Private _FechaCorteSeguimiento As DateTime
    Private _Usuario As String
    Private _FechaPostConciliacion As DateTime

    ' Properties
    Public Property CodigoProceso() As String
        Get
            Return _CodigoProceso
        End Get
        Set(value As String)
            _CodigoProceso = value
        End Set
    End Property

    Public Property Estado() As String
        Get
            Return _Estado
        End Get
        Set(value As String)
            _Estado = value
        End Set
    End Property

    Public Property AnioPeriodo() As String
        Get
            Return _AnioPeriodo
        End Get
        Set(value As String)
            _AnioPeriodo = value
        End Set
    End Property

    Public Property MesPeriodo() As String
        Get
            Return _MesPeriodo
        End Get
        Set(value As String)
            _MesPeriodo = value
        End Set
    End Property

    Public Property FechaProcesoAS400() As String
        Get
            Return _FechaProcesoAS400
        End Get
        Set(value As String)
            _FechaProcesoAS400 = value
        End Set
    End Property

    Public Property CodigoCliente() As Integer
        Get
            Return _CodigoCliente
        End Get
        Set(value As Integer)
            _CodigoCliente = value
        End Set
    End Property

    Public Property FechaCargaAS400() As DateTime
        Get
            Return _FechaCargaAS400
        End Get
        Set(value As DateTime)
            _FechaCargaAS400 = value
        End Set
    End Property

    Public Property FechaGeneracionCF() As DateTime
        Get
            Return _FechaGeneracionCF
        End Get
        Set(value As DateTime)
            _FechaGeneracionCF = value
        End Set
    End Property

    Public Property FechaDescargaArchivo() As DateTime
        Get
            Return _FechaDescargaArchivo
        End Get
        Set(value As DateTime)
            _FechaDescargaArchivo = value
        End Set
    End Property

    Public Property FechaEnvioEmail() As DateTime
        Get
            Return _FechaEnvioEmail
        End Get
        Set(value As DateTime)
            _FechaEnvioEmail = value
        End Set
    End Property

    Public Property TmpStatusGen() As String
        Get
            Return _TmpStatusGen
        End Get
        Set(value As String)
            _TmpStatusGen = value
        End Set
    End Property

    Public Property FechaProcesoAD() As DateTime
        Get
            Return _FechaProcesoAD
        End Get
        Set(value As DateTime)
            _FechaProcesoAD = value
        End Set
    End Property

    Public Property FechaEnvioAS400() As DateTime
        Get
            Return _FechaEnvioAS400
        End Get
        Set(value As DateTime)
            _FechaEnvioAS400 = value
        End Set
    End Property

    Public Property FechaCorteSeguimiento() As DateTime
        Get
            Return _FechaCorteSeguimiento
        End Get
        Set(value As DateTime)
            _FechaCorteSeguimiento = value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(value As String)
            _Usuario = value
        End Set
    End Property

    Public Property FechaPostConciliacion() As DateTime
        Get
            Return _FechaPostConciliacion
        End Get
        Set(value As DateTime)
            _FechaPostConciliacion = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(dr As DataRow)
        If Not IsDBNull(dr) Then
            _CodigoProceso = Conversions.ToString(IIf(dr.Table.Columns.Contains("Codigo_proceso"), dr.Table.Columns("Codigo_proceso").ToString, ""))
            _Estado = Conversions.ToString(IIf(dr.Table.Columns.Contains("Estado"), dr.Table.Columns("Estado").ToString, ""))
            _AnioPeriodo = Conversions.ToString(IIf(dr.Table.Columns.Contains("Anio_periodo"), dr.Table.Columns("Anio_periodo").ToString, ""))
            _MesPeriodo = Conversions.ToString(IIf(dr.Table.Columns.Contains("Mes_Periodo"), dr.Table.Columns("Mes_Periodo").ToString, ""))
            _FechaProcesoAS400 = Conversions.ToString(IIf(dr.Table.Columns.Contains("Fecha_ProcesoAS400"), dr.Table.Columns("Fecha_ProcesoAS400").ToString, ""))
            _CodigoCliente = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("Codigo_Cliente"), Convert.ToInt32(dr.Table.Columns("Codigo_Cliente").ToString), 0))
            _FechaCargaAS400 = Conversions.ToDate(IIf(dr.Table.Columns.Contains("Fecha_CargaAS400"), Convert.ToDateTime(dr.Table.Columns("Fecha_CargaAS400").ToString), Convert.ToDateTime("")))
            _FechaGeneracionCF = Conversions.ToDate(IIf(dr.Table.Columns.Contains("Fecha_GeneracionCF"), Convert.ToDateTime(dr.Table.Columns("Fecha_GeneracionCF").ToString), Convert.ToDateTime("")))
            _FechaDescargaArchivo = Conversions.ToDate(IIf(dr.Table.Columns.Contains("Fecha_DescargaArchivo"), Convert.ToDateTime(dr.Table.Columns("Fecha_DescargaArchivo").ToString), Convert.ToDateTime("")))
            _FechaEnvioEmail = Conversions.ToDate(IIf(dr.Table.Columns.Contains("Fecha_EnvioEmail"), Convert.ToDateTime(dr.Table.Columns("Fecha_EnvioEmail").ToString), Convert.ToDateTime("")))
            _TmpStatusGen = Conversions.ToString(IIf(dr.Table.Columns.Contains("TmpStatusGen"), dr.Table.Columns("TmpStatusGen").ToString, ""))
            _FechaProcesoAD = Conversions.ToDate(IIf(dr.Table.Columns.Contains("Fecha_ProcesoAD"), Convert.ToDateTime(dr.Table.Columns("Fecha_ProcesoAD").ToString), Convert.ToDateTime("")))
            _FechaEnvioAS400 = Conversions.ToDate(IIf(dr.Table.Columns.Contains("Fecha_EnvioAS400"), Convert.ToDateTime(dr.Table.Columns("Fecha_EnvioAS400").ToString), Convert.ToDateTime("")))
            _FechaCorteSeguimiento = Conversions.ToDate(IIf(dr.Table.Columns.Contains("Fecha_CorteSeguimiento"), Convert.ToDateTime("Fecha_CorteSeguimiento").ToString, Convert.ToDateTime("")))
            _Usuario = Conversions.ToString(IIf(dr.Table.Columns.Contains("UsuarioCreacion"), dr.Table.Columns("UsuarioCreacion").ToString, ""))
            _FechaPostConciliacion = Conversions.ToDate(IIf(dr.Table.Columns.Contains("Fecha_PostConciliacion"), Convert.ToDateTime(dr.Table.Columns("Fecha_PostConciliacion").ToString), Convert.ToDateTime("")))
        End If
    End Sub
End Class
