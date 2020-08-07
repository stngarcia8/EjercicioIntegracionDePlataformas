using System;

namespace Facturas.Dominio.Importacion
{
    [Serializable]
    public class Venta
    {
        // Atributos.
        private string idVenta;
        private string fechaVenta;
        private string rutUsuario;
        private string nombreUsuario;
        private string rutCliente;
        private string nombreCliente;
        private string tipoDocumento;
        private int idTipoDocumento;
        private string nombreSucursal;
        private string formaPago;
        private int idFormaPago;

        // Constructor
        public Venta()
        {
            idVenta = string.Empty;
            fechaVenta = DateTime.Now.ToString("G");
            rutUsuario = string.Empty;
            nombreUsuario = string.Empty;
            rutCliente = string.Empty;
            nombreCliente = string.Empty;
            tipoDocumento = string.Empty;
            idTipoDocumento = 0;
            nombreSucursal = string.Empty;
            formaPago = string.Empty;
            idFormaPago = 0;
        }

        // Propiedades.
        public string IdVenta
        {
            get { return idVenta; }
            set { idVenta = value; }
        }

        public string FechaVenta
        {
            get { return fechaVenta; }
            set { fechaVenta = value; }
        }

        public string RutUsuario
        {
            get { return rutUsuario; }
            set { rutUsuario = value; }
        }

        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }

        public string RutCliente
        {
            get { return rutCliente; }
            set { rutCliente = value; }
        }

        public string NombreCliente
        {
            get { return nombreCliente; }
            set { nombreCliente = value; }
        }

        public string TipoDocumento
        {
            get { return tipoDocumento; }
            set { tipoDocumento = value; }
        }

        public string NombreSucursal
        {
            get { return nombreSucursal; }
            set { nombreSucursal = value; }
        }

        public string FormaPago
        {
            get { return formaPago; }
            set { formaPago = value; }
        }

        public int IdFormaPago
        {
            get { return idFormaPago; }
            set { idFormaPago = value; }
        }

        public int IdTipoDocumento
        {
            get { return idTipoDocumento; }
            set { idTipoDocumento = value; }
        }
    }
}