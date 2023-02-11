<ServiceContract()>
Public Interface IWSBIFConvenios
    <OperationContract()>
    Function AnulaEnvioCobranzaIBS(pCodigo_proceso As String, pUsuario As String) As Integer

    <OperationContract()>
    Function EnviaInformacionIBS(pCodigo_proceso As String, pUsuario As String) As Integer

    <OperationContract()>
    Function GeneraCronogramaFuturo(pCodigo_proceso As String, pTipoFormatoArchivo As String, pSituacionTrabajador As String, pUsuario As String) As Integer

    <OperationContract()>
    Function ImportaDescuentoEmpresa(pCodigo_proceso As String, pNombreArchivo As String, pUsuario As String) As String

    <OperationContract()>
    Function ImportaDescuentosEmpresa(pCodigo_proceso As String, pNombreArchivo As String, pTipoFormatoArchivo As String, pUsuario As String) As Integer

    <OperationContract()>
    Function ConsultaPagaresDeIBS(pCodigo_ClienteIBS As String, pAnio As String, pMes As String, pFecha_ProcesoAS400 As String, pCodigo_Cliente As String, pUsuario As String) As DataTable

    <OperationContract()>
    Function ImportaPagaresDeIBS(pCodigo_ClienteIBS As String, pAnio As String, pMes As String, pFecha_ProcesoAS400 As String, pCodigo_Cliente As String, pUsuario As String) As String

    <OperationContract()>
    Function ProcesaBloqueo(pNumeroLote As String, pUsuario As String) As Integer

    <OperationContract()>
    Function ProcesaProrroga(pNumeroLote As String, pUsuario As String) As Integer

    <OperationContract()>
    Function ConsultarMotivoIBS(pCodigo_proceso As String, pCodigo_Cliente As String, pAnio As String, pMes As String) As DataSet

    <OperationContract()>
    Function ObtenerCabeceraCasillero(pCodigo_Cliente As String, pAnio As String, pMes As String) As DataSet

    <OperationContract()>
    Function ObtenerDetalleCasillero(pCodigo_Cliente As String, pAnio As String, pMes As String) As DataSet

End Interface
