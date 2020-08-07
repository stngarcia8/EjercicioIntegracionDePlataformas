using Facturas.Dominio.Importacion;
using Facturas.Lector.Mensajes;
using System;
using System.Collections.Generic;

namespace Facturas.Negocio.Mensajes
{
    public class GeneraMensaje
    {
        // Constructor.
        private GeneraMensaje() { }

        // Creador del objeto.
        public static GeneraMensaje crear()
        {
            return new GeneraMensaje();
        }

        // Generar los mensajes para el servidor.
        public void generarMensaje()
        {
            VentaDTO miVenta = new VentaDTO();
            List<DetalleVenta> miDetalle = generarDetalleVenta();
            miVenta.VentaInfo = generarVenta();
            miVenta.DetalleVentaInfo = miDetalle;
            miVenta.DatosFacturacionInfo = generarDatosFacturacion();
            miVenta.DatosFacturacionInfo.CantidadDetalle = miDetalle.Count;
            MessageOut myMsg = MessageOut.create();
            myMsg.setMensaje(miVenta);
        }

        // Generando datos de venta.
        private Venta generarVenta()
        {
            string id = Guid.NewGuid().ToString();
            Venta miVenta = new Venta();
            miVenta.IdVenta = id;
            miVenta.FechaVenta = DateTime.Now.ToString("G");
            miVenta.NombreCliente = "Nacho" + id;
            miVenta.NombreUsuario = "Usuario" + id;
            miVenta.RutCliente = "12345678-9";
            miVenta.RutUsuario = "12456789-3";
            miVenta.TipoDocumento = "Factura";
            miVenta.IdTipoDocumento = 1;
            miVenta.NombreSucursal = "Parinacota Norte";
            miVenta.FormaPago = "Efectivo";
            miVenta.IdFormaPago = 1;
            return miVenta;
        }

        private DatosFacturacion generarDatosFacturacion()
        {
            DatosFacturacion misDatosFacturacion = new DatosFacturacion();
            misDatosFacturacion.Ciudad = "Talca City";
            misDatosFacturacion.Contacto = "www.librosbasurita.cl";
            misDatosFacturacion.Giro = "Basurita y Cia";
            misDatosFacturacion.Direccion = "Avenida La Ballenita 401";
            misDatosFacturacion.RazonSocial = "Reventa de Libros";
            misDatosFacturacion.Rut = "97981236-9";

            return misDatosFacturacion;
        }

        private List<DetalleVenta> generarDetalleVenta()
        {
            List<DetalleVenta> miListaDetalle = new List<DetalleVenta>();
            var miDetalle1 = new DetalleVenta();
            var miDetalle2 = new DetalleVenta();

            miDetalle1.IdEjemplar = Guid.NewGuid().ToString();
            miDetalle1.NombreEjemplar = "El Librete";
            miDetalle1.PrecioUnitario = 9000;
            miDetalle1.Cantidad = 5;
            miDetalle1.PrecioTotal = 45000;
            miListaDetalle.Add(miDetalle1);

            miDetalle2.IdEjemplar = Guid.NewGuid().ToString();
            miDetalle2.NombreEjemplar = "El Librote";
            miDetalle2.PrecioUnitario = 6000;
            miDetalle2.Cantidad = 2;
            miDetalle2.PrecioTotal = 12000;
            miListaDetalle.Add(miDetalle2);

            return miListaDetalle;
        }
    }
}