using Facturas.Dominio.Importacion;
using System.Data;

namespace Facturas.Datos.DAO
{
    public class DAODatosFacturacion : Dao
    {
        // Constructor.
        private DAODatosFacturacion() : base() { }

        // Constructor del objeto.
        public static DAODatosFacturacion crearDAO()
        {
            return new DAODatosFacturacion();
        }

        // Grabar los datos de facturacion.
        public int agregar(DatosFacturacion misDatos, string miIdVenta)
        {
            int registrosAfectados = 0;

            try
            {
                var myQuery = DefinirObjetoConsultaAccion("spRegistrarDatosFactura");
                myQuery.AgregarParametro(":pRut", misDatos.Rut, DbType.String);
                myQuery.AgregarParametro(":pRazonSocial", misDatos.RazonSocial, DbType.String);
                myQuery.AgregarParametro(":pDireccion", misDatos.Direccion, DbType.String);
                myQuery.AgregarParametro(":pGiro", misDatos.Giro, DbType.String);
                myQuery.AgregarParametro(":pContacto", misDatos.Contacto, DbType.String);
                myQuery.AgregarParametro(":pCiudad", misDatos.Ciudad, DbType.String);
                myQuery.AgregarParametro(":pIdVenta",miIdVenta , DbType.String);
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