using Facturas.Dominio.Importacion;
using System.Collections.Generic;
using System.Data;

namespace Facturas.Datos.DAO
{
    public class DAOEjemplar: Dao
    {
        // Constructor.
        private DAOEjemplar() : base() { }

        // Constructor del objeto.
        public static DAOEjemplar crearDAO()
        {
            return new DAOEjemplar();
        }

        // Grabar un ejemplar.
        public int agregar(IList<DetalleVenta> misDetalles)
        {
            int registrosAfectados = 0;

            try
            {
                foreach(DetalleVenta miDetalle in misDetalles)
                {
                    var myQuery = DefinirObjetoConsultaAccion("spRegistrarEjemplar");
                    myQuery.AgregarParametro(":pIdEjemplar", miDetalle.IdEjemplar, DbType.String);
                    myQuery.AgregarParametro(":pNombreEjemplar", miDetalle.NombreEjemplar, DbType.String);
                    myQuery.AgregarParametro(":pPrecioEjemplar", miDetalle.PrecioUnitario, DbType.Int32);
                    registrosAfectados = myQuery.EjecutarConsulta();
                }
                return registrosAfectados;
            }
            catch
            {
                throw;
            }
        }
    }
}