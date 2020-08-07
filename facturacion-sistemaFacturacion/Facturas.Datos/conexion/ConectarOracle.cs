using System;
using Oracle.ManagedDataAccess.Client;

namespace Facturas.Datos.Conexion
{
    public class ConectarOracle : IConectarOracle, IDisposable
    {
        // Miembros.
        private bool disposed = false;
        private OracleConnection conexion;
        private OracleTransaction transaccion;
        private readonly string cadenaDeConexion;

        // Constructor.
        private ConectarOracle()
        {
            cadenaDeConexion = generarCadenaDeConexion();
        }

        // Metodo de creacion del objeto.
        public static ConectarOracle crearConexion()
        {
            return new ConectarOracle();
        }

        // Genera la cadena de conexion a la base de datos.
        private string generarCadenaDeConexion()
        {
            return string.Format("Data Source={0};User Id={1};Password={2};", "localhost", "factura_usr", "factura_pwd");
        }

        //  Metodo que retorna el objeto de conección.
        public OracleConnection ObtenerConexion()
        {
            if (conexion == null)
            {
                InicializarObjetos();
            }
            return conexion;
        }

        //  Metodo que retorna el objeto de transaccion.
        public OracleTransaction ObtenerTransaccion()
        {
            if (transaccion == null)
            {
                InicializarObjetos();
            }
            return transaccion;
        }

        //  Metodo que inicializa los objetos de conección.
        private void InicializarObjetos()
        {
            try
            {
                conexion = new OracleConnection(cadenaDeConexion);
                conexion.Open();
                transaccion = conexion.BeginTransaction();
            }
            catch
            {
                throw;
            }
        }

        // Metodo para hacer commit a la bdd.
        public void Commit()
        {
            if (transaccion != null) transaccion.Commit();
        }

        // Metodo para hacer rollback a la bdd.
        public void RollBack()
        {
            if (transaccion != null) transaccion.Rollback();
        }

        // Metodo que crea objetos de consulta de seleccion (SELECT)
        public IConsultaSeleccion CrearConsultaSeleccion(string sql)
        {
            try
            {
                var comando = ObtenerConexion().CreateCommand();
                comando.CommandText = sql;
                comando.Transaction = transaccion;
                return ConsultaSeleccion.CrearConsulta(comando);
            }
            catch
            {
                throw;
            }
        }

        // Metodo que crea objetos de consulta de accion (INSERT, UPDATE, DELETE)
        public IConsultaAccion CrearConsultaAccion(string nombreProcedimientoAlmacenado)
        {
            try
            {
                var comando = ObtenerConexion().CreateCommand();
                comando.CommandText = nombreProcedimientoAlmacenado;
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Transaction = transaccion;
                return ConsultaAccion.CrearConsulta(comando);
            }
            catch
            {
                throw;
            }
        }

        // Metodo para cerrar los objetos de la bdd.
        public void cerrarConexion()
        {
            if (transaccion != null)
            {
                transaccion.Dispose();
                transaccion = null;
            }
            if (conexion != null)
            {
                conexion.Dispose();
                conexion = null;
            }
        }

        // Destructor.
        #region "Destructor."

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                if (transaccion != null)
                {
                    transaccion.Dispose();
                    transaccion = null;
                }
                if (conexion != null)
                {
                    conexion.Dispose();
                    conexion = null;
                }
            }
            disposed = true;
        }

        #endregion
    }
}