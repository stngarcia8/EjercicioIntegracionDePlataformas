using Facturas.Dominio.Importacion;
using System;
using System.Collections.Generic;
using System.Data;

namespace Facturas.Datos.DAO
{
    public class DAOVenta:Dao
    {
        // Constructor.
        private DAOVenta() : base() { }

        // Constructor del objeto.
        public static DAOVenta crearDAO()
        {
            return new DAOVenta();
        }

        // Grabar una venta.
        public int agregar(Venta miVenta, IList<DetalleVenta> misDetalles)
        {
            int registrosAfectados = 0;

            try
            {
                var myQuery = DefinirObjetoConsultaAccion("spRegistrarVenta");
                myQuery.AgregarParametro(":pIdVenta", miVenta.IdVenta, DbType.String);
                myQuery.AgregarParametro(":pFechaVenta", DateTime.Parse(miVenta.FechaVenta), DbType.Date);
                myQuery.AgregarParametro(":pRutUsuario", miVenta.RutUsuario, DbType.String);
                myQuery.AgregarParametro(":pRutCliente", miVenta.RutCliente, DbType.String);
                myQuery.AgregarParametro(":pFormaPago",miVenta.IdFormaPago, DbType.Int32);
                myQuery.AgregarParametro(":pIdTipoDocumento", miVenta.IdTipoDocumento, DbType.Int32);
                registrosAfectados= myQuery.EjecutarConsulta();
                // Agregando el detalle.
                var miDaoDetalle = DAOVentaDetalle.crearDao();
                foreach(DetalleVenta miDetalle in misDetalles)
                {
                    miDaoDetalle.agregarDetalle(miDetalle.Cantidad, miDetalle.PrecioTotal, miVenta.IdVenta, miDetalle.IdEjemplar);
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