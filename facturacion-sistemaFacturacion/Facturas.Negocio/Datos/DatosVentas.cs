using Facturas.Dominio.Importacion;
using Facturas.Datos.DAO;
using System.Collections.Generic;

namespace Facturas.Negocio.Datos
{
    public class DatosVentas
    {
        // Constructor.
        private DatosVentas() { }

        // Creador del objeto.
        public static DatosVentas abrirDatosVenta()
        {
            return new DatosVentas();
        }

        // Grabar los datos de la venta.
        public int grabar(Venta miVenta, IList<DetalleVenta> misDetalles, DatosFacturacion misDatos)
        {
            int registrosAfectados = 0;
            try
            {
                // Grabando cliente.
                var miDaoCliente = DAOCliente.crearDAO();
                registrosAfectados = miDaoCliente.agregar(miVenta);
                // grabando usuario.
                var miDaoUsuario = DAOUsuario.crearDAO();
                registrosAfectados = miDaoUsuario.agregar(miVenta);
                // Grabar el ejemplar.
                var miDaoEjemplar = DAOEjemplar.crearDAO();
                registrosAfectados = miDaoEjemplar.agregar(misDetalles);
                // Grabando venta.
                var miDaoVenta = DAOVenta.crearDAO();
                registrosAfectados = miDaoVenta.agregar(miVenta, misDetalles);
                // Grabando los datos de facturacion si corresponde el tipo de documento.
                if (miVenta.IdTipoDocumento == 2)
                {
                    var miDaoDatosFactura = DAODatosFacturacion.crearDAO();
                    registrosAfectados = miDaoDatosFactura.agregar(misDatos, miVenta.IdVenta);
                }
            }
            catch
            {
                throw;
            }
            return registrosAfectados;
        }
    }
}