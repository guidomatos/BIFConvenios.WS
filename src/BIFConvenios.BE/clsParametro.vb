Public Class clsParametro

    Private _iGrupoId As Integer
    Private _iParametroId As Integer
    Private _sDescripcion As String
    Private _sValor As String
    Private _iOrden As Integer
    Private _iVisible As Integer
    Private _iEstado As Integer

    ' Properties
    Public Property GrupoId() As Integer
        Get
            Return _iGrupoId
        End Get
        Set(value As Integer)
            _iGrupoId = value
        End Set
    End Property

    Public Property ParametroId() As Integer
        Get
            Return _iParametroId
        End Get
        Set(value As Integer)
            _iParametroId = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _sDescripcion
        End Get
        Set(value As String)
            _sDescripcion = value
        End Set
    End Property

    Public Property Valor() As String
        Get
            Return _sValor
        End Get
        Set(value As String)
            _sValor = value
        End Set
    End Property

    Public Property Orden() As Integer
        Get
            Return _iOrden
        End Get
        Set(value As Integer)
            _iOrden = value
        End Set
    End Property

    Public Property Visible() As Integer
        Get
            Return _iVisible
        End Get
        Set(value As Integer)
            _iVisible = value
        End Set
    End Property

    Public Property TotalRegistros() As Integer
        Get
            Return _iEstado
        End Get
        Set(value As Integer)
            _iEstado = value
        End Set
    End Property

End Class
