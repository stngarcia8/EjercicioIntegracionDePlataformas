using System;

namespace Facturas.Dominio.Importacion
{ 
    [Serializable]
    public class DatosFacturacion
    {
        // Atributos.
        private string razonSocial;
        private string rut;
        private string direccion;
        private string giro;
        private string contacto;
        private string ciudad;
        private int cantidadDetalle;

        // Constructor.
        public DatosFacturacion()
        {
            razonSocial = string.Empty;
            rut = string.Empty;
            direccion = string.Empty;
            giro = string.Empty;
            contacto = string.Empty;
            ciudad = string.Empty;
            cantidadDetalle = 0;
        }

        // Propiedades.
        public string RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }

        public string Rut
        {
            get { return rut; }
            set { rut = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Giro
        {
            get { return giro; }
            set { giro = value; }
        }

        public string Contacto
        {
            get { return contacto; }
            set { contacto = value; }
        }

        public string Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        public int CantidadDetalle
        {
            get { return cantidadDetalle; }
            set { cantidadDetalle = value; }
        }
    }
}