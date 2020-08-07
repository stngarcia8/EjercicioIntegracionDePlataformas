using System.Data;

namespace Facturas.Datos.DAO
{
    public class DAOVentaDetalle:Dao
    {
        // Constructor.
        private DAOVentaDetalle() : base() { }

        // Creador del objeto.
        public static DAOVentaDetalle crearDao()
        {
            return new DAOVentaDetalle();
        }

        // Agregar el detalle de venta.
        public void agregarDetalle(int cantidad, int precioTotal, string idVenta, string idEjemplar)
        {
            try
            {
                var myQuery = DefinirObjetoConsultaAccion("spRegistrarDetalleVenta");
                myQuery.AgregarParametro(":pCantidad", cantidad, DbType.Int32);
                myQuery.AgregarParametro(":pPrecioTotal", precioTotal, DbType.Int32);
                myQuery.AgregarParametro(":pIdVenta", idVenta, DbType.String);
                myQuery.AgregarParametro(":pIdEjemplar", idEjemplar, DbType.String);
                myQuery.EjecutarConsulta();
            }
            catch
            {
                throw;
            } 
        }
    }
}