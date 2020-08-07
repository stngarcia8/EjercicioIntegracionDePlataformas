using Facturas.Dominio.Importacion;
using System.Data;

namespace Facturas.Datos.DAO
{
    public class DAOCliente : Dao
    {
        // Constructor.
        private DAOCliente() : base() { }

        // Constructor del objeto.
        public static DAOCliente crearDAO()
        {
            return new DAOCliente();
        }

        // Grabar un cliente.
        public int agregar(Venta miVenta)
        {
            int registrosAfectados = 0;

            try
            {
                var myQuery = DefinirObjetoConsultaAccion("spRegistrarCliente");
                myQuery.AgregarParametro(":pRutCliente", miVenta.RutCliente, DbType.String);
                myQuery.AgregarParametro(":pNombreCliente", miVenta.NombreCliente, DbType.String);
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