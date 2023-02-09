using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class clsGestionDatos
    {
        #region Singleton

        private static volatile clsGestionDatos ogestor = new clsGestionDatos();

        /// <summary>
        /// Obtiene una Unica Instancia de la clase.
        /// </summary>
        public static clsGestionDatos Instancia
        {
            get { return ogestor; }
        }

        /// <summary>
        /// Obtiene una Unica Instancia de la clase.
        /// </summary>
        public static clsGestionDatos ObtenerInstancia()
        {
            return ogestor;
        }

        public static clsGestionDatos ObtenerInstancia(string claveConexion)
        {
            ogestor = new clsGestionDatos(claveConexion);

            return ogestor;
        }

        #endregion

        #region Campos

        private string _claveCadenaConexion = "CadenaConexion";
        private SqlConnection _oConexion;
        private SqlTransaction _oTransaccion;

        private string _cadenaConexion = BIFUtils.WS.Utils.CadenaConexion("Conexion"); // Constants.NombreConexion;
        private Hashtable _comandoSQL = new Hashtable();

        #endregion

        #region Constructor

        /// <summary>
        /// Retorna una instancia de la clase.
        /// En el archivo de configuración debe haber una entrada con nombre "CadenaConexion"
        /// que guarda la cadena de conexión.
        /// </summary>
        public clsGestionDatos()
        {
            EstablecerCadenaConexion(_claveCadenaConexion);
        }

        /// <summary>
        /// Retorna una instancia de la clase.
        /// Se envía como parámetro el nombre de la clave que en el Archivo de Configuración
        /// guarda la cadena de conexión.
        /// </summary>
        /// <param name="claveConexion"></param>
        public clsGestionDatos(string claveConexion)
        {
            EstablecerCadenaConexion(claveConexion);
        }

        #endregion

        private void EstablecerCadenaConexion(string claveConexion)
        {
            _cadenaConexion = ConfigurationManager.ConnectionStrings[claveConexion].ToString();
        }

        public void AbrirConexion()
        {
            AbrirConexion(EstablecerConexion());
        }

        public void AbrirConexion(SqlConnection oConnection)
        {
            if (oConnection.State == ConnectionState.Closed)
                oConnection.Open();
        }

        public void IniciarTransaccion()
        {
            if (_oConexion == null)
                throw new Exception("No existe conexión Aperturada para Iniciar Transacción.");

            _oTransaccion = _oConexion.BeginTransaction();
        }

        public void ConfirmarTransaccion()
        {
            _oTransaccion.Commit();
        }

        public SqlTransaction ObtenerTransaccion()
        {
            return _oTransaccion;
        }

        public void CancelarTransaccion()
        {
            if (_oTransaccion != null && _oTransaccion.Connection != null)
                _oTransaccion.Rollback();
        }

        public void CerrarConexion()
        {
            CerrarConexion(EstablecerConexion());
        }

        public void CerrarConexion(SqlConnection oConnection)
        {
            if (oConnection.State == ConnectionState.Open)
                oConnection.Close();
        }

        public void Ejecutar(string entidad, Hashtable parametro)
        {
            using (SqlCommand com = EstablecerComando(entidad, parametro))
            {
                bool conexionActiva = com.Connection.State == ConnectionState.Open;
                if (!conexionActiva)
                    com.Connection.Open();

                if (_oTransaccion != null)
                    com.Transaction = _oTransaccion;

                com.ExecuteNonQuery();

                if (!conexionActiva)
                    com.Connection.Close();
            }
        }

        public void Ejecutar(SqlConnection oconexion, string entidad, Hashtable parametro)
        {
            using (SqlCommand com = EstablecerComando(oconexion, entidad, parametro))
            {
                bool conexionActiva = com.Connection.State == ConnectionState.Open;
                if (!conexionActiva)
                    com.Connection.Open();

                if (_oTransaccion != null)
                    com.Transaction = _oTransaccion;

                com.ExecuteNonQuery();

                if (!conexionActiva)
                    com.Connection.Close();
            }
        }

        public void Ejecutar(string comandoSQL, SqlConnection conexion)
        {
            using (SqlCommand com = new SqlCommand())
            {
                com.CommandText = comandoSQL;
                com.CommandType = CommandType.Text;
                com.Connection = conexion;

                bool conexionActiva = com.Connection.State == ConnectionState.Open;
                if (!conexionActiva)
                    com.Connection.Open();

                if (_oTransaccion != null)
                    com.Transaction = _oTransaccion;

                com.ExecuteNonQuery();

                if (!conexionActiva)
                    com.Connection.Close();
            }
        }

        public void Ejecutar(string comandoSQL)
        {
            using (SqlCommand com = new SqlCommand())
            {
                com.CommandText = comandoSQL;
                com.CommandType = CommandType.Text;
                com.Connection = EstablecerConexion();

                bool conexionActiva = com.Connection.State == ConnectionState.Open;
                if (!conexionActiva)
                    com.Connection.Open();

                if (_oTransaccion != null)
                    com.Transaction = _oTransaccion;

                com.ExecuteNonQuery();

                if (!conexionActiva)
                    com.Connection.Close();
            }
        }

        public object EjecutarEscalar(string entidad, Hashtable parametro)
        {
            object resultado = null;

            using (SqlCommand com = EstablecerComando(entidad, parametro))
            {
                bool conexionActiva = com.Connection.State == ConnectionState.Open;

                if (!conexionActiva)
                    com.Connection.Open();

                if (_oTransaccion != null)
                    com.Transaction = _oTransaccion;

                resultado = com.ExecuteScalar();

                if (!conexionActiva)
                    com.Connection.Close();
            }

            return resultado;
        }

        public object EjecutarEscalar(SqlConnection oconexion, string entidad, Hashtable parametro)
        {
            object resultado = null;

            using (SqlCommand com = EstablecerComando(oconexion, entidad, parametro))
            {
                bool conexionActiva = com.Connection.State == ConnectionState.Open;

                if (!conexionActiva)
                    com.Connection.Open();

                if (_oTransaccion != null)
                    com.Transaction = _oTransaccion;

                resultado = com.ExecuteScalar();

                if (!conexionActiva)
                    com.Connection.Close();
            }

            return resultado;
        }

        public DataRow ObtenerDataRow(string entidad, Hashtable parametro)
        {
            DataTable dt = ObtenerDataTable(entidad, parametro);

            return dt != null && dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public DataTable ObtenerDataTable(string entidad, Hashtable parametro)
        {
            DataTable oDataTable = new DataTable();
            using (SqlCommand com = EstablecerComando(entidad, parametro))
            {
                bool conexionActiva = com.Connection.State == ConnectionState.Open;
                if (!conexionActiva)
                    com.Connection.Open();

                if (_oTransaccion != null)
                    com.Transaction = _oTransaccion;

                oDataTable.Load(com.ExecuteReader());

                if (!conexionActiva)
                    com.Connection.Close();
            }

            return oDataTable;
        }

        public SqlDataReader ObtenerDataReader(string entidad)
        {
            return ObtenerDataReader(EstablecerConexion(), entidad, new Hashtable());
        }

        public SqlDataReader ObtenerDataReader(string entidad, Hashtable parametros)
        {
            return ObtenerDataReader(EstablecerConexion(), entidad, parametros);
        }

        public SqlDataReader ObtenerDataReader(SqlConnection oConnection, string entidad, Hashtable parametros)
        {
            if (oConnection == null)
                throw new Exception("Objeto Conexion no existe.");

            if (oConnection.State == ConnectionState.Closed)
                throw new Exception("No existe conexión activa disponible.");

            SqlCommand com = EstablecerComando(oConnection, entidad, parametros);

            return com.ExecuteReader();
        }

        #region Establecer Comando en caché

        private SqlCommand EstablecerComando(string comando, Hashtable parametro)
        {
            string cadenaComandoSQL = comando.Trim();

            if (!_comandoSQL.Contains(cadenaComandoSQL))
            {
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = EstablecerConexion();
                    com.CommandText = cadenaComandoSQL;
                    com.CommandType = CommandType.StoredProcedure;

                    _comandoSQL[cadenaComandoSQL] = com;
                }
            }

            ((SqlCommand)_comandoSQL[cadenaComandoSQL]).Parameters.Clear();

            foreach (DictionaryEntry param in parametro)
            {
                ((SqlCommand)_comandoSQL[cadenaComandoSQL]).Parameters.AddWithValue(param.Key.ToString().ToLower(), param.Value);
            }

            return ((SqlCommand)_comandoSQL[cadenaComandoSQL]);
        }

        private SqlCommand EstablecerComando(SqlConnection oConexion, string comando, Hashtable parametro)
        {
            string cadenaComandoSQL = comando.Trim();

            if (!_comandoSQL.Contains(cadenaComandoSQL))
            {
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = oConexion;
                    com.CommandText = cadenaComandoSQL;
                    com.CommandType = CommandType.StoredProcedure;

                    _comandoSQL[cadenaComandoSQL] = com;
                }
            }
            else
            {
                ((SqlCommand)_comandoSQL[cadenaComandoSQL]).Connection = oConexion;
            }

            ((SqlCommand)_comandoSQL[cadenaComandoSQL]).Parameters.Clear();

            foreach (DictionaryEntry param in parametro)
            {
                ((SqlCommand)_comandoSQL[cadenaComandoSQL])
                    .Parameters.AddWithValue(param.Key.ToString().ToLower(), param.Value);
            }

            return ((SqlCommand)_comandoSQL[cadenaComandoSQL]);
        }

        private SqlConnection EstablecerConexion()
        {
            if (_oConexion == null)
                _oConexion = new SqlConnection(_cadenaConexion);

            return _oConexion;
        }

        #endregion

        #region Manejar Conexion

        /// <summary>
        /// Devuelve una conexion SQL.
        /// </summary>
        /// <returns></returns>
        public SqlConnection ObtenerConexion()
        {
            return ObtenerConexion(_cadenaConexion);
        }

        public SqlConnection ObtenerConexion(string cadenaConexion)
        {
            SqlConnection sqlCon = null;

            if (!string.IsNullOrEmpty(cadenaConexion))
                sqlCon = new SqlConnection(cadenaConexion);

            return sqlCon;
        }

        public SqlConnection ObtenerConexionActiva()
        {
            if (_oConexion == null || _oConexion.State == ConnectionState.Closed)
                throw new Exception("No existe conexión activa.");

            return _oConexion;
        }

        #endregion

        /// <summary>
        /// Enumerador para los Estados de la Conexión.
        /// </summary>
        public enum EstadoConexion
        {
            Abierto, Cerrado, Conectando, Ejecutando, Interrumpido, Indefinido,
        }

        /// <summary>
        /// Devuelve el estado actual de la conexión.
        /// </summary>
        public EstadoConexion EstadoConexionActual
        {
            get
            {
                EstadoConexion estado;
                switch (_oConexion.State)
                {
                    case ConnectionState.Broken:
                        estado = EstadoConexion.Interrumpido;
                        break;
                    case ConnectionState.Closed:
                        estado = EstadoConexion.Cerrado;
                        break;
                    case ConnectionState.Connecting:
                        estado = EstadoConexion.Conectando;
                        break;
                    case ConnectionState.Executing:
                        estado = EstadoConexion.Ejecutando;
                        break;
                    case ConnectionState.Fetching:
                        estado = EstadoConexion.Conectando;
                        break;
                    case ConnectionState.Open:
                        estado = EstadoConexion.Abierto;
                        break;
                    default:
                        estado = EstadoConexion.Indefinido;
                        break;
                }

                return estado;
            }
        }
    }
}
