using Facturas.Lector.Secciones;
using Facturas.Dominio.Importacion;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;
using Facturas.Lector.Helper;

namespace Facturas.Lector
{
    public class Importacion
    {
        private string archivoVenta;
        private Venta miVenta;
        private DatosFacturacion misDatosFacturacion;
        private List<DetalleVenta> miDetalleVenta;
        private List<Venta> miListaVentas = new List<Venta>();

        public string ArchivoVenta
        {
            get { return archivoVenta; }
            set { archivoVenta = value; }
        }

        public Venta VentaImportada {
            get { return miVenta; }
            set { miVenta = value; }
        }

        public DatosFacturacion DatosFacturacionImportado {
            get { return misDatosFacturacion; }
            set { misDatosFacturacion = value; }
        }

        public List<DetalleVenta> DetalleVentaImportado
        {
            get { return miDetalleVenta; }
            set { miDetalleVenta = value; }
        }

        public List<Venta> VentasImportadas
        {
            get { return miListaVentas; }
            set { miListaVentas = value; }
        }

        public void GrabarVentas(string directorio, string formato, VentaDTO nuevaVenta)
        {
            var miVentaInfo = nuevaVenta.VentaInfo;
            var miFacturaInfo = nuevaVenta.DatosFacturacionInfo;
            var miDetalleInfo = nuevaVenta.DetalleVentaInfo;
            var nombreArchivo = miVentaInfo.FechaVenta.Replace("/", "-").Replace(":", "-") + miVentaInfo.IdVenta;

            archivoVenta = directorio + nombreArchivo + formato;

            if (!File.Exists(archivoVenta))
            {
                XDocument documentoXML = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
                XElement nodoRaiz = new XElement("Ventabook");
                XElement nodoDetalle = new XElement("DetalleVenta");
                documentoXML.Add(nodoRaiz);
                var seccion = new AgregarSeccion();
                
                seccion.AgregarElemento(nodoRaiz, "Venta", miVentaInfo);
                seccion.AgregarElemento(nodoRaiz, "DatosFacturacion", miFacturaInfo);

                var i = 0;
                miDetalleInfo.ForEach(delegate (DetalleVenta miDetalle) {
                    i++;
                    seccion.AgregarElemento(nodoRaiz, "DetalleVenta" + i, miDetalle);
                });

                seccion = null;
                documentoXML.Save(archivoVenta);
                documentoXML = null;
            }
        }

        public void CargarDirectorio(string nombreDirectorio, string nombreDirectorioProcesadas, string formatoArchivo)
        {
            miListaVentas.Clear();

            var miHelper = Directorio.Crear();
            miHelper.CrearDirectorio(nombreDirectorioProcesadas);

            if (miHelper.CrearDirectorio(nombreDirectorio))
            {
                foreach (string archivo in Directory.EnumerateFiles(nombreDirectorio, "*" + formatoArchivo))
                {
                    archivoVenta = archivo;

                    CargarVenta();

                    miListaVentas.Add(miVenta);
                }
            }

            archivoVenta = null;
        }

        public void CargarVenta()
        {
            XDocument documentoXML = XDocument.Load(archivoVenta);
            var seccion = new ObtenerSeccion();
            miVenta = seccion.LeerSeccion<Venta>(documentoXML, "Venta");
            misDatosFacturacion = seccion.LeerSeccion<DatosFacturacion>(documentoXML, "DatosFacturacion");
            miDetalleVenta = new List<DetalleVenta>();

            for (int i = 1; i <= misDatosFacturacion.CantidadDetalle; i++)
            {
                var miDetalle = seccion.LeerSeccion<DetalleVenta>(documentoXML, "DetalleVenta" + i);
                miDetalleVenta.Add(miDetalle);
            }

            seccion = null;
            documentoXML = null;
        }
    }
}