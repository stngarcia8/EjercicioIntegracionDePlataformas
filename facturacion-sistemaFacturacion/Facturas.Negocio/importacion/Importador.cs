using Facturas.Dominio.Importacion;
using System.Collections.Generic;

namespace Facturas.Negocio.Importacion
{
    public class Importador : IImportador
    {
        // Variables de la clase.
        Lector.Importacion miImportador;

        // Propiedades.
        public List<Venta> VentasImportadas { get; set; }
        public Venta VentaImportada { get; set; }
        public DatosFacturacion DatosFacturacionImportado { get; set; }
        public List<DetalleVenta> DetalleVentaImportado { get; set; }
        public string ArchivoVenta { get; set; }

        // Constructor.
        private Importador() {
            miImportador = new Lector.Importacion();
        }

        // Constructor del objeto.
        public static Importador crear()
        {
            return new Importador();
        }

        private void SincronizarDatos()
        {
            ArchivoVenta = miImportador.ArchivoVenta;
            VentasImportadas = miImportador.VentasImportadas;
            VentaImportada = miImportador.VentaImportada;
            DatosFacturacionImportado = miImportador.DatosFacturacionImportado;
            DetalleVentaImportado = miImportador.DetalleVentaImportado;
        }

        // Metodo para grabar la venta.
        public void GrabarVentas(string miDirectorio, string miFormatoArchivo, VentaDTO miVentaDTO)
        {
            miImportador.GrabarVentas(miDirectorio, miFormatoArchivo, miVentaDTO);

            SincronizarDatos();
        }

        //  Cargar el directorio de los archivos xml.
        public void CargarDirectorio(string miDirectorio, string miDirectorioProcesadas, string miFormatoArchivo)
        {
            miImportador.CargarDirectorio(miDirectorio, miDirectorioProcesadas, miFormatoArchivo);

            SincronizarDatos();
        }

        // Metodo para cargar cargar venta.
        public void CargarVenta()
        {
            miImportador.ArchivoVenta = ArchivoVenta;
            miImportador.CargarVenta();

            SincronizarDatos();
        }
    }
}