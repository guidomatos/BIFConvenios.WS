Imports BIFConvenios.BL

' NOTE: You can use the "Rename" command on the context menu to change the class name "WSBIFConvenios" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select WSBIFConvenios.svc or WSBIFConvenios.svc.vb at the Solution Explorer and start debugging.
<ServiceBehavior()>
Public Class WSBIFConvenios
    Implements IWSBIFConvenios

    Public Function AnulaEnvioCobranzaIBS(pCodigo_proceso As String, pUsuario As String) As Integer Implements IWSBIFConvenios.AnulaEnvioCobranzaIBS
        Dim iCobranza As New CobranzaBL
        Return iCobranza.AnulaEnvioCobranzaIBS(pCodigo_proceso, pUsuario)
    End Function


    Public Function EnviaInformacionIBS(pCodigo_proceso As String, pUsuario As String) As Integer Implements IWSBIFConvenios.EnviaInformacionIBS
        Dim iCobranza As New CobranzaBL
        Return iCobranza.EnvioCobranzaIBS(pCodigo_proceso, pUsuario)
    End Function


    Public Function GeneraCronogramaFuturo(pCodigo_proceso As String, pTipoFormatoArchivo As String, pSituacionTrabajador As String, pUsuario As String) As Integer Implements IWSBIFConvenios.GeneraCronogramaFuturo
        Dim iCuota As New CuotaBL
        Return iCuota.GeneraCronogramaFuturo(pCodigo_proceso, pTipoFormatoArchivo, pSituacionTrabajador, pUsuario)
    End Function


    Public Function ImportaDescuentoEmpresa(pCodigo_proceso As String, pNombreArchivo As String, pUsuario As String) As String Implements IWSBIFConvenios.ImportaDescuentoEmpresa
        Dim iCobranza As New CobranzaBL
        Return iCobranza.ImportaDescuentosEmpresa(pCodigo_proceso, pNombreArchivo, pUsuario)
    End Function


    Public Function ImportaDescuentosEmpresa(pCodigo_proceso As String, pNombreArchivo As String, pTipoFormatoArchivo As String, pUsuario As String) As Integer Implements IWSBIFConvenios.ImportaDescuentosEmpresa
        Dim iCobranza As New CobranzaBL
        Return iCobranza.ImportaDescuentosEmpresa(pCodigo_proceso, pNombreArchivo, pTipoFormatoArchivo, pUsuario)
    End Function


    Public Function ConsultaPagaresDeIBS(pCodigo_ClienteIBS As String, pAnio As String, pMes As String, pFecha_ProcesoAS400 As String, pCodigo_Cliente As String, pUsuario As String) As DataTable Implements IWSBIFConvenios.ConsultaPagaresDeIBS
        Dim iCuota As New CuotaBL
        Return iCuota.ConsultarPagaresDeIBS(pCodigo_ClienteIBS, pAnio, pMes, pFecha_ProcesoAS400, pCodigo_Cliente, pUsuario)
    End Function


    Public Function ImportaPagaresDeIBS(pCodigo_ClienteIBS As String, pAnio As String, pMes As String, pFecha_ProcesoAS400 As String, pCodigo_Cliente As String, pUsuario As String) As String Implements IWSBIFConvenios.ImportaPagaresDeIBS
        'Dim iCuota As New CuotaBL
        'Return iCuota.ImportaPagaresDeIBS(pCodigo_ClienteIBS, pAnio, pMes, pFecha_ProcesoAS400, pCodigo_Cliente, pUsuario)
        Dim Cuota As New clsCuotaBL
        Return Cuota.ImportaPagareDeIBS(pCodigo_ClienteIBS, pAnio, pMes, pFecha_ProcesoAS400, pCodigo_Cliente, pUsuario)
    End Function


    Public Function ProcesaBloqueo(pNumeroLote As String, pUsuario As String) As Integer Implements IWSBIFConvenios.ProcesaBloqueo
        Dim iBloqueo As New BloqueoBL
        Return iBloqueo.ProcesoBloqueo(pNumeroLote, pUsuario)
    End Function


    Public Function ProcesaProrroga(pNumeroLote As String, pUsuario As String) As Integer Implements IWSBIFConvenios.ProcesaProrroga
        Dim iProrroga As New ProrrogaBL
        Return iProrroga.ProcesoProrroga(pNumeroLote, pUsuario)
    End Function


    Public Function ConsultarMotivoIBS(pCodigo_proceso As String, pCodigo_Cliente As String, pAnio As String, pMes As String) As DataSet Implements IWSBIFConvenios.ConsultarMotivoIBS
        Dim iCuota As New CuotaBL
        Return iCuota.ObtenerMotivosDeIBS(pCodigo_proceso, pCodigo_Cliente, pAnio, pMes)
    End Function


    Public Function ObtenerCabeceraCasillero(pCodigo_Cliente As String, pAnio As String, pMes As String) As DataSet Implements IWSBIFConvenios.ObtenerCabeceraCasillero
        Dim iCuota As New CuotaBL
        Return iCuota.ObtenerCabeceraCasillero(pCodigo_Cliente, pAnio, pMes)
    End Function


    Public Function ObtenerDetalleCasillero(pCodigo_Cliente As String, pAnio As String, pMes As String) As DataSet Implements IWSBIFConvenios.ObtenerDetalleCasillero
        Dim iCuota As New CuotaBL
        Return iCuota.ObtenerDetalleCasillero(pCodigo_Cliente, pAnio, pMes)
    End Function

End Class
