using System.Collections.Generic;
using Facturas.Dominio.Importacion;

namespace Facturas.Negocio.Importacion
{
    public interface IImportador
    {
        string ArchivoVenta { get; set; }
        DatosFacturacion DatosFacturacionImportado { get; set; }
        List<DetalleVenta> DetalleVentaImportado { get; set; }
        Venta VentaImportada { get; set; }
        List<Venta> VentasImportadas { get; set; }

        void CargarDirectorio(string miDirectorio, string miDirectorioProcesadas, string miFormatoArchivo);
        void CargarVenta();
        void GrabarVentas(string miDirectorio, string miFormatoArchivo, VentaDTO miVentaDTO);
    }
}