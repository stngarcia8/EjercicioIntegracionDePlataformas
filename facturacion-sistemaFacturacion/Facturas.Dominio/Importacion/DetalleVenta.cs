using System;

namespace Facturas.Dominio.Importacion
{
    [Serializable]
    public class DetalleVenta
            {
        // Atributos.
        private string idEjemplar;
        private string nombreEjemplar;
        private int precioUnitario;
        private int cantidad;
        private int precioTotal;

        // Constructor.
        public DetalleVenta()
        {
            idEjemplar = string.Empty;
            nombreEjemplar = string.Empty;
            precioUnitario = 0;
            cantidad = 0;
            precioTotal = 0;
        }

        // Propiedades.
        public string IdEjemplar
        {
            get { return idEjemplar; }
            set { idEjemplar = value; }
        }

        public string NombreEjemplar
        {
            get { return nombreEjemplar; }
            set { nombreEjemplar = value; }
        }

        public int PrecioUnitario
        {
            get { return precioUnitario; }
            set { precioUnitario = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public int PrecioTotal
        {
            get { return precioTotal; }
            set { precioTotal = value; }
        }
    }
}