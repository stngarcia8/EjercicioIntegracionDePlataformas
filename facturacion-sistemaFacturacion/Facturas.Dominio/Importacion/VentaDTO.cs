using System;
using System.Collections.Generic;

namespace Facturas.Dominio.Importacion
{
    [Serializable]
    public class VentaDTO
    {
        // Propiedades.
        public Venta VentaInfo { get; set; }
        public List<DetalleVenta> DetalleVentaInfo { get; set; }
        public DatosFacturacion DatosFacturacionInfo { get; set; }
   }
}