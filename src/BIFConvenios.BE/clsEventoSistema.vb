Imports Microsoft.VisualBasic.CompilerServices

<DataContract()>
Public Class clsEventoSistema
    ' Fields
    Private _idEventoSistema As Integer
    Private _Fecha As DateTime
    Private _Hilo As String
    Private _Nivel As String
    Private _Accion As String
    Private _Mensaje As String
    Private _Excepcion As String
    Private _Usuario As String

    ' Properties
    <DataMember()>
    Public Property IdEventoSistema() As Integer
        Get
            Return _idEventoSistema
        End Get
        Set(value As Integer)
            _idEventoSistema = value
        End Set
    End Property

    <DataMember()>
    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(value As DateTime)
            _Fecha = value
        End Set
    End Property

    <DataMember()>
    Public Property Hilo() As String
        Get
            Return _Hilo
        End Get
        Set(value As String)
            _Hilo = value
        End Set
    End Property

    <DataMember()>
    Public Property Nivel() As String
        Get
            Return _Nivel
        End Get
        Set(value As String)
            _Nivel = value
        End Set
    End Property

    <DataMember()>
    Public Property Accion() As String
        Get
            Return _Accion
        End Get
        Set(value As String)
            _Accion = value
        End Set
    End Property

    <DataMember()>
    Public Property Mensaje() As String
        Get
            Return _Mensaje
        End Get
        Set(value As String)
            _Mensaje = value
        End Set
    End Property

    <DataMember()>
    Public Property Excepcion() As String
        Get
            Return _Excepcion
        End Get
        Set(value As String)
            _Excepcion = value
        End Set
    End Property

    <DataMember()>
    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(value As String)
            _Usuario = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(dr As DataRow)
        If Not IsDBNull(dr) Then
            _idEventoSistema = Conversions.ToInteger(IIf(dr.Table.Columns.Contains("Ident_EventoSistema"), Convert.ToInt32(dr.Table.Columns("Ident_EventoSistema").ToString), 0))
            _Fecha = Conversions.ToDate(IIf(dr.Table.Columns.Contains("Fecha"), Convert.ToDateTime(dr.Table.Columns("Fecha").ToString), Convert.ToDateTime("")))
            _Hilo = Conversions.ToString(IIf(dr.Table.Columns.Contains("Hilo"), dr.Table.Columns("Hilo").ToString, ""))
            _Nivel = Conversions.ToString(IIf(dr.Table.Columns.Contains("Nivel"), dr.Table.Columns("Nivel").ToString, ""))
            _Accion = Conversions.ToString(IIf(dr.Table.Columns.Contains("Accion"), dr.Table.Columns("Accion").ToString, ""))
            _Mensaje = Conversions.ToString(IIf(dr.Table.Columns.Contains("Mensaje"), dr.Table.Columns("Mensaje").ToString, ""))
            _Excepcion = Conversions.ToString(IIf(dr.Table.Columns.Contains("Excepcion"), dr.Table.Columns("Excepcion").ToString, ""))
            _Usuario = Conversions.ToString(IIf(dr.Table.Columns.Contains("Usuario"), dr.Table.Columns("Usuario").ToString, ""))
        End If
    End Sub
End Class
