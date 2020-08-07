using Facturas.Dominio.Importacion;
using System.Data;

namespace Facturas.Datos.DAO
{
    public class DAOUsuario: Dao
    {
        // Constructor.
        private DAOUsuario() : base() { }

        // Constructor del objeto.
        public static DAOUsuario crearDAO()
        {
            return new DAOUsuario();
        }

        // Grabar un usuario.
        public int agregar(Venta miVenta)
        {
            int registrosAfectados = 0;

            try
            {
                var myQuery = DefinirObjetoConsultaAccion("spRegistrarUsuario");
                myQuery.AgregarParametro(":pRutUsuario", miVenta.RutUsuario, DbType.String);
                myQuery.AgregarParametro(":pNombreUsuario", miVenta.NombreUsuario, DbType.String);
                myQuery.AgregarParametro(":pSucursal", miVenta.NombreSucursal, DbType.String);
                registrosAfectados = myQuery.EjecutarConsulta();
                return registrosAfectados;
            }
            catch
            {
                throw;
            }
        }
    }
}