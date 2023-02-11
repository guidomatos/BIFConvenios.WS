Imports Resource

<ServiceContract()>
Public Interface IWsEnvioAutomatico
    <OperationContract()>
    Function ValidarFinProcesoBatch(codigo_proceso As String) As Boolean
    <OperationContract()>
    Function ObtenerListaProcesosDisponiblesByFecha(pintDia As Integer) As DataTable
    <OperationContract()>
    Function ObtenerListaProcesosDisponibles(pstrFiltro As String) As DataTable
    <OperationContract()>
    Function ProcesarEnvioNominasByCliente(pintCodigoProcesoAutomatico As Integer, pstrCodigoIBS As String, pstrTipoDocumento As String, pstrNumeroDocumento As String, pstrMesPeriodo As String, pstrAnioPeriodo As String, pstrFechaProcesoAS400 As String, pstrUsuario As String, ByRef pintEstado As Integer) As String
    <OperationContract()>
    Function ProcesarTodosClientes(penuTipoEnvio As Integer, pstrUsuario As String) As String
    <OperationContract()>
    Function RegistrarLogEventoSistema(pstrHilo As String, penuNivel As Integer, pstrAccion As String, pstrMensaje As String, pstrExcepcion As String, pstrUsuario As String) As Integer
    <OperationContract()>
    Function RegistrarLogEnvio(pintCodigoProcesoAutomatico As Integer, pintCodigoCliente As Integer, pintCodigoIBS As Integer, penuTipoEnvio As Integer, pstrCodigoProceso As String, pintAnioPeriodo As Integer, pintMesPeriodo As Integer, pstrMensaje As String, penuEstado As enumLogEnvioCorreo, pstrUsuario As String) As Integer
    <OperationContract()>
    Function RegistrarLogProcesosAutomaticos(pintTotal As Integer, pintProcesados As Integer, pintError As Integer, pstrMensaje As String, pintEstado As Integer, pstrUsuario As String) As Integer
    <OperationContract()>
    Function ActualizarLogProcesosAutomaticos(pintCodigoProcesoAutomatico As Integer, pintTotal As Integer, pintProcesados As Integer, pintError As Integer, pstrMensaje As String, pintEstado As Integer, pstrUsuario As String) As Integer
End Interface
