Imports Resource

<ServiceContract()>
Public Interface IWsAlertasAutomaticas
    <OperationContract()>
    Function RegistrarLogEventoSistema(pstrHilo As String, penuNivel As Integer, pstrAccion As String, pstrMensaje As String, pstrExcepcion As String, pstrUsuario As String) As Integer
    <OperationContract()>
    Function RegistrarLogEnvio(pintCodigoProcesoAutomatico As Integer, pintCodigoCliente As Integer, pintCodigoIBS As Integer, penuTipoEnvio As Integer, pstrCodigoProceso As String, pintAnioPeriodo As Integer, pintMesPeriodo As Integer, pstrMensaje As String, penuEstado As enumLogEnvioCorreo, pstrUsuario As String) As Integer
    <OperationContract()>
    Function RegistrarLogProcesosAutomaticos(pintTotal As Integer, pintProcesados As Integer, pintError As Integer, pstrMensaje As String, pintEstado As Integer, pstrUsuario As String) As Integer
    <OperationContract()>
    Function ActualizarLogProcesosAutomaticos(pintCodigoProcesoAutomatico As Integer, pintTotal As Integer, pintProcesados As Integer, pintError As Integer, pstrMensaje As String, pintEstado As Integer, pstrUsuario As String) As Integer
    <OperationContract()>
    Function ConvertirBody(pstrBody As String) As String
    <OperationContract()>
    Function ObtenerListClienteUltimoProceso() As DataTable
    <OperationContract()>
    Function ProcesarAlerta(pintCodigoProcesoAutomatico As Integer, pstrCodigoCliente As String, pintAnioPeriodo As Integer, pintMesPeriodo As Integer, pstrUsuario As String, ByRef pintEstado As Integer) As String
End Interface
