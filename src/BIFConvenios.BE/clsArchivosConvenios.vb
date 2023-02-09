Imports Microsoft.VisualBasic.CompilerServices

Public Class clsArchivosConvenios
    ' Fields
    Private _iArchivoConvenioId As Integer
    Private _vCodProceso As String
    Private _vNombreArchivo As String
    Private _vRutaCreacion As String
    Private _vRutaModificacion As String
    Private _vRutaHistorico As String
    Private _iEstado As Integer
    Private _vUsuarioCreacion As String
    Private _dFechaCreacion As DateTime
    Private _vUsuarioModificacion As String
    Private _dFechaModificacion As DateTime

    ' Properties
    Public Property iArchivoConvenioId() As Integer
        Get
            Return _iArchivoConvenioId
        End Get
        Set(value As Integer)
            _iArchivoConvenioId = value
        End Set
    End Property

    Public Property vCodProceso() As String
        Get
            Return _vCodProceso
        End Get
        Set(value As String)
            _vCodProceso = value
        End Set
    End Property

    Public Property vNombreArchivo() As String
        Get
            Return _vNombreArchivo
        End Get
        Set(value As String)
            _vNombreArchivo = value
        End Set
    End Property

    Public Property vRutaCreacion() As String
        Get
            Return _vRutaCreacion
        End Get
        Set(value As String)
            _vRutaCreacion = value
        End Set
    End Property

    Public Property vRutaModificacion() As String
        Get
            Return _vRutaModificacion
        End Get
        Set(value As String)
            _vRutaModificacion = value
        End Set
    End Property

    Public Property vRutaHistorico() As String
        Get
            Return _vRutaHistorico
        End Get
        Set(value As String)
            _vRutaHistorico = value
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

    Public Property dFechaCreacion() As DateTime
        Get
            Return _dFechaCreacion
        End Get
        Set(value As DateTime)
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
            iArchivoConvenioId = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iArchivoConvenioId"), Convert.ToInt32(dr.Table.Columns("iArchivoConvenioId").ToString), 0))
            vCodProceso = Conversions.ToString(IIf(dr.Table.Columns.Contains("vCodProceso"), dr.Table.Columns("iCodConvenio").ToString, ""))
            vNombreArchivo = Conversions.ToString(IIf(dr.Table.Columns.Contains("vNombreArchivo"), dr.Table.Columns("vNombreArchivo").ToString, ""))
            vRutaCreacion = Conversions.ToString(IIf(dr.Table.Columns.Contains("vRutaCreacion"), dr.Table.Columns("vRutaCreacion").ToString, ""))
            vRutaModificacion = Conversions.ToString(IIf(dr.Table.Columns.Contains("vRutaModificacion"), dr.Table.Columns("vRutaModificacion").ToString, ""))
            vRutaHistorico = Conversions.ToString(IIf(dr.Table.Columns.Contains("vRutaHistorico"), dr.Table.Columns("vRutaHistorico").ToString, ""))
            iEstado = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("iEstado"), Convert.ToInt32(dr.Table.Columns("iEstado").ToString), 0))
            vUsuarioCreacion = Conversions.ToString(IIf(dr.Table.Columns.Contains("vUsuarioCreacion"), dr.Table.Columns("vUsuarioCreacion").ToString, ""))
            dFechaCreacion = Conversions.ToDate(IIf(dr.Table.Columns.Contains("dFechaCreacion"), Convert.ToDateTime(dr.Table.Columns("dFechaCreacion").ToString), Convert.ToDateTime("")))
            vUsuarioModificacion = Conversions.ToString(IIf(dr.Table.Columns.Contains("vUsuarioModificacion"), dr.Table.Columns("vUsuarioModificacion").ToString, ""))
            dFechaModificacion = Conversions.ToDate(IIf(dr.Table.Columns.Contains("dFechaModificacion"), Convert.ToDateTime(dr.Table.Columns("dFechaModificacion").ToString), Convert.ToDateTime("")))
        End If
    End Sub
End Class
