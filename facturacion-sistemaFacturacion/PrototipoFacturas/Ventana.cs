using Facturas.Dominio.Importacion;
using Facturas.Negocio.Archivos;
using Facturas.Negocio.Datos;
using Facturas.Negocio.Importacion;
using Facturas.Negocio.Mensajes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Facturas.Presentacion
{
    public partial class Ventana : Form
    {
        private string miDirectorio = Environment.CurrentDirectory + "/Facturas/";
        private string miDirectorioProcesadas = Environment.CurrentDirectory + "/Facturas/Procesadas/";
        private string miFormatoArchivo = ".xml";
        private string miTipoVenta = "Todos";
        private IImportador miImportador;
        private DetalleVenta miDetalle;
        private List<Venta> miListaVentas = new List<Venta>();
        private object[] Tipos = {
            "Todos",
            "Boleta",
            "Factura"
        };

        public Ventana()
        {
            InitializeComponent();

            miImportador = Importador.crear();

            CboxTipo.Items.AddRange(Tipos);
            CboxTipo.SelectedIndex = 0;

            CambiarBotonRefrescar(false);
            ActualizarDatos();

            miFileSystemWatcher.Path = miDirectorio;
            miFileSystemWatcher.Filter = "*"+miFormatoArchivo;

            BtnCrearEjemplo.Visible = false;
        }

        private void ActualizarLista()
        {
            if (DgridLista.Rows.Count > 0)
            {
                DgridLista.Rows.Clear();
            }

            miListaVentas.ForEach(delegate (Venta miVenta)
            {
                var miVentaTipo = miVenta.TipoDocumento;

                if (miTipoVenta.Equals("Todos") | miVentaTipo.Equals(miTipoVenta))
                {
                    ventaBindingSource.Add(miVenta);
                }
            });

            DgridLista.ClearSelection();
        }

        private void CambiarBotonRefrescar(bool Estado)
        {
            BtnRefrescar.Enabled = Estado;
        }

        private void ObtenerListaMensajes()
        {
            CambiarBotonRefrescar(false);

            ObtieneMensajes misMensajes = ObtieneMensajes.leer();

            if (misMensajes.VentasMessage != null)
            {
                foreach (VentaDTO miVentaDTO in misMensajes.VentasMessage)
                {
                    miImportador.GrabarVentas(miDirectorio, miFormatoArchivo, miVentaDTO);
                }
            }
        }

        private void ActualizarDatos()
        {
            miImportador.CargarDirectorio(miDirectorio, miDirectorioProcesadas, miFormatoArchivo);
            miListaVentas = miImportador.VentasImportadas;

            ActualizarLista();
            CambiarBotonRefrescar(true);
        }

        private void ActualizarInfo(bool Limpiar)
        {
            var miVenta = Limpiar ? new Venta() : miImportador.VentaImportada;
            var miFactura = Limpiar ? new DatosFacturacion() : miImportador.DatosFacturacionImportado;
            var miDetalleVenta = Limpiar ? new List<DetalleVenta>() : miImportador.DetalleVentaImportado;

            TboxIdVenta.Text = miVenta.IdVenta;
            DTPickerFechaVenta.Value = DateTime.Parse(miVenta.FechaVenta);
            TboxNombreUsuario.Text = miVenta.NombreUsuario;
            TboxRutCliente.Text = miVenta.RutCliente;
            TboxNombreCliente.Text = miVenta.NombreCliente;
            TboxSucursal.Text = miVenta.NombreSucursal;
            TboxFormaPago.Text = miVenta.FormaPago;

            TboxRutFactura.Text = miFactura.Rut;
            TboxRazonSocial.Text = miFactura.RazonSocial;
            TboxContacto.Text = miFactura.Contacto;
            TboxGiro.Text = miFactura.Giro;
            TboxCuidad.Text = miFactura.Ciudad;
            TboxDireccion.Text = miFactura.Direccion;

            CboxDetalle.Items.Clear();
            CboxDetalle.Items.Add("Seleccione...");

            miDetalleVenta.ForEach(delegate (DetalleVenta miDetalle)
            {
                CboxDetalle.Items.Add(miDetalle.NombreEjemplar);
            });

            CboxDetalle.SelectedIndex = 0;
        }

        private void HabilitarControles(bool Bool)
        {
            TboxNombreUsuario.ReadOnly = Bool;
            TboxRutCliente.ReadOnly = Bool;
            TboxNombreCliente.ReadOnly = Bool;
            TboxSucursal.ReadOnly = Bool;
            TboxFormaPago.ReadOnly = Bool;

            GroupBoxFactura.Visible = !Bool;

            TboxPrecioUnitario.ReadOnly = Bool;
            NumCantidad.ReadOnly = Bool;
            TboxPrecioTotal.ReadOnly = Bool;

            BtnGrabarBoleta.Visible = Bool;

            BtnGrabarFactura.Visible = !Bool;
        }

        #region Eventos
        private void sincronizaMensajesTimer_Tick(object sender, EventArgs e)
        {
            ObtenerListaMensajes();
            ActualizarDatos();
        }

        private void CboxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Object = sender as ComboBox;

            miTipoVenta = Object.Text;

            ActualizarLista();
            ActualizarInfo(true);
            HabilitarControles(!miTipoVenta.Equals("Factura"));
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            sincronizaMensajesTimer.Stop();
            ObtenerListaMensajes();
            ActualizarDatos();
            sincronizaMensajesTimer.Start();
        }

        private void BtnCrearEjemplo_Click(object sender, EventArgs e)
        {
            GeneraMensaje miMensaje = GeneraMensaje.crear();
            miMensaje.generarMensaje();
        }

        private void DgridLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgridLista.SelectedRows.Count == 0) {
                HabilitarControles(true);
                return;
            }

            var miVentaSeleccionada = DgridLista.SelectedRows[0].DataBoundItem as Venta;
            var miFechaVenta = miVentaSeleccionada.FechaVenta.Replace("/", "-").Replace(":", "-");
            var miCodigoVenta = miVentaSeleccionada.IdVenta;
            var esNoModificable = miVentaSeleccionada.TipoDocumento != "Factura";

            miImportador.ArchivoVenta = miDirectorio + miFechaVenta + miCodigoVenta + miFormatoArchivo;
            miImportador.CargarVenta();

            ActualizarInfo(false);
            HabilitarControles(esNoModificable);
        }

        private void CboxDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Selection = (sender as ComboBox).SelectedIndex;

            miDetalle = Selection == 0 ? new DetalleVenta() : miImportador.DetalleVentaImportado[Selection - 1];

            TboxPrecioUnitario.Text = miDetalle.PrecioUnitario.ToString();
            NumCantidad.Value = miDetalle.Cantidad;
            TboxPrecioTotal.Text = miDetalle.PrecioTotal.ToString();
        }

        private void BtnGrabarVenta_Click(object sender, EventArgs e)
        {
            if (DgridLista.SelectedRows.Count == 0) { return; }

            try
            {
                var misDatos = DatosVentas.abrirDatosVenta();
                misDatos.grabar(miImportador.VentaImportada, miImportador.DetalleVentaImportado, miImportador.DatosFacturacionImportado);
                var miVenta = miImportador.VentaImportada;
                var miNombreArchivo = miVenta.FechaVenta.Replace("/", "-").Replace(":", "-") + miVenta.IdVenta;
                var misArchivos = Archivos.Crear();
                misArchivos.MoverArchivo(miNombreArchivo, miFormatoArchivo, miDirectorio, miDirectorioProcesadas);
                MessageBox.Show("La venta ha sido registrada exitosamente.", "Venta Registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ActualizarInfo(true);
        }
        #endregion

        #region File System Watcher
        private void FileSystemWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            CambiarBotonRefrescar(false);
            ActualizarDatos();
        }

        private void FileSystemWatcher_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            CambiarBotonRefrescar(false);
            ActualizarDatos();
        }
        #endregion
    }
}