namespace Facturas.Presentacion
{
    partial class Ventana
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ventana));
            this.DgridLista = new System.Windows.Forms.DataGridView();
            this.ventaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CboxTipo = new System.Windows.Forms.ComboBox();
            this.LblTipo = new System.Windows.Forms.Label();
            this.BtnGrabarFactura = new System.Windows.Forms.Button();
            this.miImageList = new System.Windows.Forms.ImageList(this.components);
            this.BtnGrabarBoleta = new System.Windows.Forms.Button();
            this.miFileSystemWatcher = new System.IO.FileSystemWatcher();
            this.BtnCrearEjemplo = new System.Windows.Forms.Button();
            this.TboxIdVenta = new System.Windows.Forms.TextBox();
            this.LblIdVenta = new System.Windows.Forms.Label();
            this.DTPickerFechaVenta = new System.Windows.Forms.DateTimePicker();
            this.LblFechaVenta = new System.Windows.Forms.Label();
            this.LblNombreUsuario = new System.Windows.Forms.Label();
            this.TboxNombreUsuario = new System.Windows.Forms.TextBox();
            this.TboxNombreCliente = new System.Windows.Forms.TextBox();
            this.TboxRutCliente = new System.Windows.Forms.TextBox();
            this.LblNombreCliente = new System.Windows.Forms.Label();
            this.LblRutCliente = new System.Windows.Forms.Label();
            this.GroupBoxVenta = new System.Windows.Forms.GroupBox();
            this.LblFormaPago = new System.Windows.Forms.Label();
            this.TboxFormaPago = new System.Windows.Forms.TextBox();
            this.TboxSucursal = new System.Windows.Forms.TextBox();
            this.LblSurcursal = new System.Windows.Forms.Label();
            this.GroupBoxFactura = new System.Windows.Forms.GroupBox();
            this.LblContacto = new System.Windows.Forms.Label();
            this.TboxContacto = new System.Windows.Forms.TextBox();
            this.LblCiudad = new System.Windows.Forms.Label();
            this.TboxCuidad = new System.Windows.Forms.TextBox();
            this.TboxDireccion = new System.Windows.Forms.TextBox();
            this.LblDireccion = new System.Windows.Forms.Label();
            this.TboxGiro = new System.Windows.Forms.TextBox();
            this.LblGiro = new System.Windows.Forms.Label();
            this.TboxRutFactura = new System.Windows.Forms.TextBox();
            this.LblRutFactura = new System.Windows.Forms.Label();
            this.TboxRazonSocial = new System.Windows.Forms.TextBox();
            this.LblRazonSocial = new System.Windows.Forms.Label();
            this.GroupBoxDetalle = new System.Windows.Forms.GroupBox();
            this.LblPrecioUnitario = new System.Windows.Forms.Label();
            this.TboxPrecioUnitario = new System.Windows.Forms.TextBox();
            this.LblPrecioTotal = new System.Windows.Forms.Label();
            this.TboxPrecioTotal = new System.Windows.Forms.TextBox();
            this.NumCantidad = new System.Windows.Forms.NumericUpDown();
            this.LblCantidad = new System.Windows.Forms.Label();
            this.LblElementoDetalle = new System.Windows.Forms.Label();
            this.CboxDetalle = new System.Windows.Forms.ComboBox();
            this.miPrintDialog = new System.Windows.Forms.PrintDialog();
            this.miPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.sincronizaMensajesTimer = new System.Windows.Forms.Timer(this.components);
            this.BtnRefrescar = new System.Windows.Forms.Button();
            this.TipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaVentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rutClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgridLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.miFileSystemWatcher)).BeginInit();
            this.GroupBoxVenta.SuspendLayout();
            this.GroupBoxFactura.SuspendLayout();
            this.GroupBoxDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // DgridLista
            // 
            this.DgridLista.AccessibleDescription = "Tabla de resultados de la busqueda";
            this.DgridLista.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.DgridLista.AllowUserToAddRows = false;
            this.DgridLista.AllowUserToDeleteRows = false;
            this.DgridLista.AllowUserToResizeColumns = false;
            this.DgridLista.AllowUserToResizeRows = false;
            this.DgridLista.AutoGenerateColumns = false;
            this.DgridLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgridLista.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DgridLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgridLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TipoDocumento,
            this.fechaVentaDataGridViewTextBoxColumn,
            this.rutClienteDataGridViewTextBoxColumn,
            this.nombreClienteDataGridViewTextBoxColumn});
            this.DgridLista.DataSource = this.ventaBindingSource;
            this.DgridLista.Location = new System.Drawing.Point(24, 78);
            this.DgridLista.MultiSelect = false;
            this.DgridLista.Name = "DgridLista";
            this.DgridLista.ReadOnly = true;
            this.DgridLista.RowTemplate.Height = 24;
            this.DgridLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgridLista.ShowCellErrors = false;
            this.DgridLista.ShowEditingIcon = false;
            this.DgridLista.ShowRowErrors = false;
            this.DgridLista.Size = new System.Drawing.Size(576, 312);
            this.DgridLista.StandardTab = true;
            this.DgridLista.TabIndex = 4;
            this.DgridLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgridLista_CellDoubleClick);
            // 
            // ventaBindingSource
            // 
            this.ventaBindingSource.DataSource = typeof(Facturas.Dominio.Importacion.Venta);
            this.ventaBindingSource.Sort = "";
            // 
            // CboxTipo
            // 
            this.CboxTipo.AccessibleDescription = "Listado de seleccion del filtro a utilizar";
            this.CboxTipo.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.CboxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboxTipo.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboxTipo.FormattingEnabled = true;
            this.CboxTipo.IntegralHeight = false;
            this.CboxTipo.ItemHeight = 21;
            this.CboxTipo.Location = new System.Drawing.Point(24, 42);
            this.CboxTipo.Name = "CboxTipo";
            this.CboxTipo.Size = new System.Drawing.Size(168, 29);
            this.CboxTipo.TabIndex = 1;
            this.CboxTipo.SelectedIndexChanged += new System.EventHandler(this.CboxTipo_SelectedIndexChanged);
            // 
            // LblTipo
            // 
            this.LblTipo.AutoSize = true;
            this.LblTipo.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTipo.Location = new System.Drawing.Point(24, 12);
            this.LblTipo.Name = "LblTipo";
            this.LblTipo.Size = new System.Drawing.Size(176, 21);
            this.LblTipo.TabIndex = 0;
            this.LblTipo.Text = "Tipo de Documento";
            // 
            // BtnGrabarFactura
            // 
            this.BtnGrabarFactura.AutoSize = true;
            this.BtnGrabarFactura.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnGrabarFactura.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGrabarFactura.ImageKey = "Grabar.png";
            this.BtnGrabarFactura.ImageList = this.miImageList;
            this.BtnGrabarFactura.Location = new System.Drawing.Point(330, 174);
            this.BtnGrabarFactura.Name = "BtnGrabarFactura";
            this.BtnGrabarFactura.Size = new System.Drawing.Size(193, 33);
            this.BtnGrabarFactura.TabIndex = 47;
            this.BtnGrabarFactura.Text = "Grabar Factura";
            this.BtnGrabarFactura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnGrabarFactura.UseVisualStyleBackColor = true;
            this.BtnGrabarFactura.Click += new System.EventHandler(this.BtnGrabarVenta_Click);
            // 
            // miImageList
            // 
            this.miImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("miImageList.ImageStream")));
            this.miImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.miImageList.Images.SetKeyName(0, "Actualizar.png");
            this.miImageList.Images.SetKeyName(1, "Grabar.png");
            // 
            // BtnGrabarBoleta
            // 
            this.BtnGrabarBoleta.AutoSize = true;
            this.BtnGrabarBoleta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnGrabarBoleta.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGrabarBoleta.ImageKey = "Grabar.png";
            this.BtnGrabarBoleta.ImageList = this.miImageList;
            this.BtnGrabarBoleta.Location = new System.Drawing.Point(342, 174);
            this.BtnGrabarBoleta.Name = "BtnGrabarBoleta";
            this.BtnGrabarBoleta.Size = new System.Drawing.Size(180, 33);
            this.BtnGrabarBoleta.TabIndex = 22;
            this.BtnGrabarBoleta.Text = "Grabar Boleta";
            this.BtnGrabarBoleta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnGrabarBoleta.UseVisualStyleBackColor = true;
            this.BtnGrabarBoleta.Click += new System.EventHandler(this.BtnGrabarVenta_Click);
            // 
            // miFileSystemWatcher
            // 
            this.miFileSystemWatcher.EnableRaisingEvents = true;
            this.miFileSystemWatcher.SynchronizingObject = this;
            this.miFileSystemWatcher.Created += new System.IO.FileSystemEventHandler(this.FileSystemWatcher_Changed);
            this.miFileSystemWatcher.Deleted += new System.IO.FileSystemEventHandler(this.FileSystemWatcher_Changed);
            this.miFileSystemWatcher.Renamed += new System.IO.RenamedEventHandler(this.FileSystemWatcher_Renamed);
            // 
            // BtnCrearEjemplo
            // 
            this.BtnCrearEjemplo.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrearEjemplo.Location = new System.Drawing.Point(198, 42);
            this.BtnCrearEjemplo.Name = "BtnCrearEjemplo";
            this.BtnCrearEjemplo.Size = new System.Drawing.Size(192, 30);
            this.BtnCrearEjemplo.TabIndex = 3;
            this.BtnCrearEjemplo.Text = "Crear Ejemplo";
            this.BtnCrearEjemplo.UseVisualStyleBackColor = true;
            this.BtnCrearEjemplo.Click += new System.EventHandler(this.BtnCrearEjemplo_Click);
            // 
            // TboxIdVenta
            // 
            this.TboxIdVenta.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TboxIdVenta.Location = new System.Drawing.Point(180, 30);
            this.TboxIdVenta.MaxLength = 36;
            this.TboxIdVenta.Name = "TboxIdVenta";
            this.TboxIdVenta.ReadOnly = true;
            this.TboxIdVenta.Size = new System.Drawing.Size(348, 28);
            this.TboxIdVenta.TabIndex = 7;
            // 
            // LblIdVenta
            // 
            this.LblIdVenta.AutoSize = true;
            this.LblIdVenta.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblIdVenta.Location = new System.Drawing.Point(12, 36);
            this.LblIdVenta.Name = "LblIdVenta";
            this.LblIdVenta.Size = new System.Drawing.Size(104, 21);
            this.LblIdVenta.TabIndex = 6;
            this.LblIdVenta.Text = "Folio Venta";
            // 
            // DTPickerFechaVenta
            // 
            this.DTPickerFechaVenta.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            this.DTPickerFechaVenta.Enabled = false;
            this.DTPickerFechaVenta.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPickerFechaVenta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPickerFechaVenta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DTPickerFechaVenta.Location = new System.Drawing.Point(180, 60);
            this.DTPickerFechaVenta.Name = "DTPickerFechaVenta";
            this.DTPickerFechaVenta.Size = new System.Drawing.Size(348, 28);
            this.DTPickerFechaVenta.TabIndex = 9;
            // 
            // LblFechaVenta
            // 
            this.LblFechaVenta.AutoSize = true;
            this.LblFechaVenta.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFechaVenta.Location = new System.Drawing.Point(12, 66);
            this.LblFechaVenta.Name = "LblFechaVenta";
            this.LblFechaVenta.Size = new System.Drawing.Size(120, 21);
            this.LblFechaVenta.TabIndex = 8;
            this.LblFechaVenta.Text = "Fecha Venta";
            // 
            // LblNombreUsuario
            // 
            this.LblNombreUsuario.AutoSize = true;
            this.LblNombreUsuario.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombreUsuario.Location = new System.Drawing.Point(12, 96);
            this.LblNombreUsuario.Name = "LblNombreUsuario";
            this.LblNombreUsuario.Size = new System.Drawing.Size(167, 21);
            this.LblNombreUsuario.TabIndex = 12;
            this.LblNombreUsuario.Text = "Nombre Vendedor";
            // 
            // TboxNombreUsuario
            // 
            this.TboxNombreUsuario.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TboxNombreUsuario.Location = new System.Drawing.Point(180, 90);
            this.TboxNombreUsuario.MaxLength = 100;
            this.TboxNombreUsuario.Name = "TboxNombreUsuario";
            this.TboxNombreUsuario.ReadOnly = true;
            this.TboxNombreUsuario.Size = new System.Drawing.Size(348, 28);
            this.TboxNombreUsuario.TabIndex = 13;
            // 
            // TboxNombreCliente
            // 
            this.TboxNombreCliente.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TboxNombreCliente.Location = new System.Drawing.Point(180, 150);
            this.TboxNombreCliente.MaxLength = 100;
            this.TboxNombreCliente.Name = "TboxNombreCliente";
            this.TboxNombreCliente.ReadOnly = true;
            this.TboxNombreCliente.Size = new System.Drawing.Size(348, 28);
            this.TboxNombreCliente.TabIndex = 17;
            // 
            // TboxRutCliente
            // 
            this.TboxRutCliente.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TboxRutCliente.Location = new System.Drawing.Point(180, 120);
            this.TboxRutCliente.MaxLength = 100;
            this.TboxRutCliente.Name = "TboxRutCliente";
            this.TboxRutCliente.ReadOnly = true;
            this.TboxRutCliente.Size = new System.Drawing.Size(348, 28);
            this.TboxRutCliente.TabIndex = 15;
            // 
            // LblNombreCliente
            // 
            this.LblNombreCliente.AutoSize = true;
            this.LblNombreCliente.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombreCliente.Location = new System.Drawing.Point(12, 156);
            this.LblNombreCliente.Name = "LblNombreCliente";
            this.LblNombreCliente.Size = new System.Drawing.Size(141, 21);
            this.LblNombreCliente.TabIndex = 16;
            this.LblNombreCliente.Text = "Nombre Cliente";
            // 
            // LblRutCliente
            // 
            this.LblRutCliente.AutoSize = true;
            this.LblRutCliente.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRutCliente.Location = new System.Drawing.Point(12, 126);
            this.LblRutCliente.Name = "LblRutCliente";
            this.LblRutCliente.Size = new System.Drawing.Size(104, 21);
            this.LblRutCliente.TabIndex = 14;
            this.LblRutCliente.Text = "RUT Cliente";
            // 
            // GroupBoxVenta
            // 
            this.GroupBoxVenta.Controls.Add(this.LblFormaPago);
            this.GroupBoxVenta.Controls.Add(this.TboxFormaPago);
            this.GroupBoxVenta.Controls.Add(this.TboxSucursal);
            this.GroupBoxVenta.Controls.Add(this.LblSurcursal);
            this.GroupBoxVenta.Controls.Add(this.TboxIdVenta);
            this.GroupBoxVenta.Controls.Add(this.TboxNombreCliente);
            this.GroupBoxVenta.Controls.Add(this.LblIdVenta);
            this.GroupBoxVenta.Controls.Add(this.LblNombreCliente);
            this.GroupBoxVenta.Controls.Add(this.TboxRutCliente);
            this.GroupBoxVenta.Controls.Add(this.DTPickerFechaVenta);
            this.GroupBoxVenta.Controls.Add(this.LblFechaVenta);
            this.GroupBoxVenta.Controls.Add(this.LblRutCliente);
            this.GroupBoxVenta.Controls.Add(this.LblNombreUsuario);
            this.GroupBoxVenta.Controls.Add(this.TboxNombreUsuario);
            this.GroupBoxVenta.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxVenta.Location = new System.Drawing.Point(612, 78);
            this.GroupBoxVenta.Name = "GroupBoxVenta";
            this.GroupBoxVenta.Size = new System.Drawing.Size(540, 312);
            this.GroupBoxVenta.TabIndex = 5;
            this.GroupBoxVenta.TabStop = false;
            this.GroupBoxVenta.Text = "Datos Venta";
            // 
            // LblFormaPago
            // 
            this.LblFormaPago.AutoSize = true;
            this.LblFormaPago.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFormaPago.Location = new System.Drawing.Point(12, 216);
            this.LblFormaPago.Name = "LblFormaPago";
            this.LblFormaPago.Size = new System.Drawing.Size(138, 21);
            this.LblFormaPago.TabIndex = 20;
            this.LblFormaPago.Text = "Forma de Pago";
            // 
            // TboxFormaPago
            // 
            this.TboxFormaPago.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TboxFormaPago.Location = new System.Drawing.Point(180, 210);
            this.TboxFormaPago.MaxLength = 36;
            this.TboxFormaPago.Name = "TboxFormaPago";
            this.TboxFormaPago.ReadOnly = true;
            this.TboxFormaPago.Size = new System.Drawing.Size(348, 28);
            this.TboxFormaPago.TabIndex = 21;
            // 
            // TboxSucursal
            // 
            this.TboxSucursal.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TboxSucursal.Location = new System.Drawing.Point(180, 180);
            this.TboxSucursal.MaxLength = 36;
            this.TboxSucursal.Name = "TboxSucursal";
            this.TboxSucursal.ReadOnly = true;
            this.TboxSucursal.Size = new System.Drawing.Size(348, 28);
            this.TboxSucursal.TabIndex = 19;
            // 
            // LblSurcursal
            // 
            this.LblSurcursal.AutoSize = true;
            this.LblSurcursal.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSurcursal.Location = new System.Drawing.Point(12, 186);
            this.LblSurcursal.Name = "LblSurcursal";
            this.LblSurcursal.Size = new System.Drawing.Size(148, 21);
            this.LblSurcursal.TabIndex = 18;
            this.LblSurcursal.Text = "Nombre Sucursal";
            // 
            // GroupBoxFactura
            // 
            this.GroupBoxFactura.Controls.Add(this.LblContacto);
            this.GroupBoxFactura.Controls.Add(this.TboxContacto);
            this.GroupBoxFactura.Controls.Add(this.LblCiudad);
            this.GroupBoxFactura.Controls.Add(this.TboxCuidad);
            this.GroupBoxFactura.Controls.Add(this.TboxDireccion);
            this.GroupBoxFactura.Controls.Add(this.LblDireccion);
            this.GroupBoxFactura.Controls.Add(this.TboxGiro);
            this.GroupBoxFactura.Controls.Add(this.LblGiro);
            this.GroupBoxFactura.Controls.Add(this.TboxRutFactura);
            this.GroupBoxFactura.Controls.Add(this.LblRutFactura);
            this.GroupBoxFactura.Controls.Add(this.TboxRazonSocial);
            this.GroupBoxFactura.Controls.Add(this.LblRazonSocial);
            this.GroupBoxFactura.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxFactura.Location = new System.Drawing.Point(24, 402);
            this.GroupBoxFactura.Name = "GroupBoxFactura";
            this.GroupBoxFactura.Size = new System.Drawing.Size(576, 222);
            this.GroupBoxFactura.TabIndex = 23;
            this.GroupBoxFactura.TabStop = false;
            this.GroupBoxFactura.Text = "Datos Factura";
            // 
            // LblContacto
            // 
            this.LblContacto.AutoSize = true;
            this.LblContacto.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblContacto.Location = new System.Drawing.Point(12, 186);
            this.LblContacto.Name = "LblContacto";
            this.LblContacto.Size = new System.Drawing.Size(93, 21);
            this.LblContacto.TabIndex = 28;
            this.LblContacto.Text = "Contacto";
            // 
            // TboxContacto
            // 
            this.TboxContacto.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TboxContacto.Location = new System.Drawing.Point(150, 180);
            this.TboxContacto.MaxLength = 100;
            this.TboxContacto.Name = "TboxContacto";
            this.TboxContacto.Size = new System.Drawing.Size(414, 28);
            this.TboxContacto.TabIndex = 29;
            // 
            // LblCiudad
            // 
            this.LblCiudad.AutoSize = true;
            this.LblCiudad.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCiudad.Location = new System.Drawing.Point(12, 126);
            this.LblCiudad.Name = "LblCiudad";
            this.LblCiudad.Size = new System.Drawing.Size(73, 21);
            this.LblCiudad.TabIndex = 32;
            this.LblCiudad.Text = "Ciudad";
            // 
            // TboxCuidad
            // 
            this.TboxCuidad.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TboxCuidad.Location = new System.Drawing.Point(150, 120);
            this.TboxCuidad.MaxLength = 100;
            this.TboxCuidad.Name = "TboxCuidad";
            this.TboxCuidad.Size = new System.Drawing.Size(414, 28);
            this.TboxCuidad.TabIndex = 33;
            // 
            // TboxDireccion
            // 
            this.TboxDireccion.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TboxDireccion.Location = new System.Drawing.Point(150, 150);
            this.TboxDireccion.MaxLength = 100;
            this.TboxDireccion.Name = "TboxDireccion";
            this.TboxDireccion.Size = new System.Drawing.Size(414, 28);
            this.TboxDireccion.TabIndex = 35;
            // 
            // LblDireccion
            // 
            this.LblDireccion.AutoSize = true;
            this.LblDireccion.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDireccion.Location = new System.Drawing.Point(12, 156);
            this.LblDireccion.Name = "LblDireccion";
            this.LblDireccion.Size = new System.Drawing.Size(88, 21);
            this.LblDireccion.TabIndex = 34;
            this.LblDireccion.Text = "Dirección";
            // 
            // TboxGiro
            // 
            this.TboxGiro.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TboxGiro.Location = new System.Drawing.Point(150, 90);
            this.TboxGiro.MaxLength = 100;
            this.TboxGiro.Name = "TboxGiro";
            this.TboxGiro.Size = new System.Drawing.Size(414, 28);
            this.TboxGiro.TabIndex = 31;
            // 
            // LblGiro
            // 
            this.LblGiro.AutoSize = true;
            this.LblGiro.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGiro.Location = new System.Drawing.Point(12, 96);
            this.LblGiro.Name = "LblGiro";
            this.LblGiro.Size = new System.Drawing.Size(134, 21);
            this.LblGiro.TabIndex = 30;
            this.LblGiro.Text = "Giro Comercial";
            // 
            // TboxRutFactura
            // 
            this.TboxRutFactura.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TboxRutFactura.Location = new System.Drawing.Point(150, 30);
            this.TboxRutFactura.MaxLength = 100;
            this.TboxRutFactura.Name = "TboxRutFactura";
            this.TboxRutFactura.Size = new System.Drawing.Size(414, 28);
            this.TboxRutFactura.TabIndex = 25;
            // 
            // LblRutFactura
            // 
            this.LblRutFactura.AutoSize = true;
            this.LblRutFactura.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRutFactura.Location = new System.Drawing.Point(12, 36);
            this.LblRutFactura.Name = "LblRutFactura";
            this.LblRutFactura.Size = new System.Drawing.Size(110, 21);
            this.LblRutFactura.TabIndex = 24;
            this.LblRutFactura.Text = "RUT Factura";
            // 
            // TboxRazonSocial
            // 
            this.TboxRazonSocial.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TboxRazonSocial.Location = new System.Drawing.Point(150, 60);
            this.TboxRazonSocial.MaxLength = 100;
            this.TboxRazonSocial.Name = "TboxRazonSocial";
            this.TboxRazonSocial.Size = new System.Drawing.Size(414, 28);
            this.TboxRazonSocial.TabIndex = 27;
            // 
            // LblRazonSocial
            // 
            this.LblRazonSocial.AutoSize = true;
            this.LblRazonSocial.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRazonSocial.Location = new System.Drawing.Point(12, 66);
            this.LblRazonSocial.Name = "LblRazonSocial";
            this.LblRazonSocial.Size = new System.Drawing.Size(113, 21);
            this.LblRazonSocial.TabIndex = 26;
            this.LblRazonSocial.Text = "Razón Social";
            // 
            // GroupBoxDetalle
            // 
            this.GroupBoxDetalle.Controls.Add(this.LblPrecioUnitario);
            this.GroupBoxDetalle.Controls.Add(this.TboxPrecioUnitario);
            this.GroupBoxDetalle.Controls.Add(this.BtnGrabarBoleta);
            this.GroupBoxDetalle.Controls.Add(this.LblPrecioTotal);
            this.GroupBoxDetalle.Controls.Add(this.TboxPrecioTotal);
            this.GroupBoxDetalle.Controls.Add(this.NumCantidad);
            this.GroupBoxDetalle.Controls.Add(this.LblCantidad);
            this.GroupBoxDetalle.Controls.Add(this.BtnGrabarFactura);
            this.GroupBoxDetalle.Controls.Add(this.LblElementoDetalle);
            this.GroupBoxDetalle.Controls.Add(this.CboxDetalle);
            this.GroupBoxDetalle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxDetalle.Location = new System.Drawing.Point(612, 402);
            this.GroupBoxDetalle.Name = "GroupBoxDetalle";
            this.GroupBoxDetalle.Size = new System.Drawing.Size(540, 222);
            this.GroupBoxDetalle.TabIndex = 36;
            this.GroupBoxDetalle.TabStop = false;
            this.GroupBoxDetalle.Text = "Detalle Venta";
            // 
            // LblPrecioUnitario
            // 
            this.LblPrecioUnitario.AutoSize = true;
            this.LblPrecioUnitario.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPrecioUnitario.Location = new System.Drawing.Point(12, 66);
            this.LblPrecioUnitario.Name = "LblPrecioUnitario";
            this.LblPrecioUnitario.Size = new System.Drawing.Size(129, 21);
            this.LblPrecioUnitario.TabIndex = 41;
            this.LblPrecioUnitario.Text = "Precio Unitario";
            // 
            // TboxPrecioUnitario
            // 
            this.TboxPrecioUnitario.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TboxPrecioUnitario.Location = new System.Drawing.Point(198, 60);
            this.TboxPrecioUnitario.MaxLength = 100;
            this.TboxPrecioUnitario.Name = "TboxPrecioUnitario";
            this.TboxPrecioUnitario.Size = new System.Drawing.Size(324, 28);
            this.TboxPrecioUnitario.TabIndex = 42;
            // 
            // LblPrecioTotal
            // 
            this.LblPrecioTotal.AutoSize = true;
            this.LblPrecioTotal.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPrecioTotal.Location = new System.Drawing.Point(12, 126);
            this.LblPrecioTotal.Name = "LblPrecioTotal";
            this.LblPrecioTotal.Size = new System.Drawing.Size(107, 21);
            this.LblPrecioTotal.TabIndex = 45;
            this.LblPrecioTotal.Text = "Precio Total";
            // 
            // TboxPrecioTotal
            // 
            this.TboxPrecioTotal.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TboxPrecioTotal.Location = new System.Drawing.Point(198, 120);
            this.TboxPrecioTotal.MaxLength = 100;
            this.TboxPrecioTotal.Name = "TboxPrecioTotal";
            this.TboxPrecioTotal.Size = new System.Drawing.Size(324, 28);
            this.TboxPrecioTotal.TabIndex = 46;
            // 
            // NumCantidad
            // 
            this.NumCantidad.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumCantidad.Location = new System.Drawing.Point(198, 90);
            this.NumCantidad.Name = "NumCantidad";
            this.NumCantidad.Size = new System.Drawing.Size(324, 28);
            this.NumCantidad.TabIndex = 44;
            // 
            // LblCantidad
            // 
            this.LblCantidad.AutoSize = true;
            this.LblCantidad.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCantidad.Location = new System.Drawing.Point(12, 96);
            this.LblCantidad.Name = "LblCantidad";
            this.LblCantidad.Size = new System.Drawing.Size(92, 21);
            this.LblCantidad.TabIndex = 43;
            this.LblCantidad.Text = "Cantidad";
            // 
            // LblElementoDetalle
            // 
            this.LblElementoDetalle.AutoSize = true;
            this.LblElementoDetalle.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblElementoDetalle.Location = new System.Drawing.Point(12, 36);
            this.LblElementoDetalle.Name = "LblElementoDetalle";
            this.LblElementoDetalle.Size = new System.Drawing.Size(183, 21);
            this.LblElementoDetalle.TabIndex = 37;
            this.LblElementoDetalle.Text = "Elemento del Detalle";
            // 
            // CboxDetalle
            // 
            this.CboxDetalle.AccessibleDescription = "Listado de seleccion del filtro a utilizar";
            this.CboxDetalle.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.CboxDetalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboxDetalle.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboxDetalle.FormattingEnabled = true;
            this.CboxDetalle.IntegralHeight = false;
            this.CboxDetalle.ItemHeight = 21;
            this.CboxDetalle.Location = new System.Drawing.Point(198, 30);
            this.CboxDetalle.Name = "CboxDetalle";
            this.CboxDetalle.Size = new System.Drawing.Size(324, 29);
            this.CboxDetalle.TabIndex = 38;
            this.CboxDetalle.SelectedIndexChanged += new System.EventHandler(this.CboxDetalle_SelectedIndexChanged);
            // 
            // miPrintDialog
            // 
            this.miPrintDialog.UseEXDialog = true;
            // 
            // sincronizaMensajesTimer
            // 
            this.sincronizaMensajesTimer.Enabled = true;
            this.sincronizaMensajesTimer.Interval = 60000;
            this.sincronizaMensajesTimer.Tick += new System.EventHandler(this.sincronizaMensajesTimer_Tick);
            // 
            // BtnRefrescar
            // 
            this.BtnRefrescar.AutoSize = true;
            this.BtnRefrescar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnRefrescar.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRefrescar.ImageKey = "Actualizar.png";
            this.BtnRefrescar.ImageList = this.miImageList;
            this.BtnRefrescar.Location = new System.Drawing.Point(576, 48);
            this.BtnRefrescar.Name = "BtnRefrescar";
            this.BtnRefrescar.Size = new System.Drawing.Size(26, 26);
            this.BtnRefrescar.TabIndex = 2;
            this.BtnRefrescar.UseVisualStyleBackColor = true;
            this.BtnRefrescar.Click += new System.EventHandler(this.BtnRefrescar_Click);
            // 
            // TipoDocumento
            // 
            this.TipoDocumento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TipoDocumento.DataPropertyName = "TipoDocumento";
            this.TipoDocumento.HeaderText = "Tipo Documento";
            this.TipoDocumento.Name = "TipoDocumento";
            this.TipoDocumento.ReadOnly = true;
            this.TipoDocumento.Width = 138;
            // 
            // fechaVentaDataGridViewTextBoxColumn
            // 
            this.fechaVentaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fechaVentaDataGridViewTextBoxColumn.DataPropertyName = "FechaVenta";
            this.fechaVentaDataGridViewTextBoxColumn.HeaderText = "Fecha Venta";
            this.fechaVentaDataGridViewTextBoxColumn.Name = "fechaVentaDataGridViewTextBoxColumn";
            this.fechaVentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaVentaDataGridViewTextBoxColumn.Width = 118;
            // 
            // rutClienteDataGridViewTextBoxColumn
            // 
            this.rutClienteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rutClienteDataGridViewTextBoxColumn.DataPropertyName = "RutCliente";
            this.rutClienteDataGridViewTextBoxColumn.HeaderText = "Rut Cliente";
            this.rutClienteDataGridViewTextBoxColumn.Name = "rutClienteDataGridViewTextBoxColumn";
            this.rutClienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.rutClienteDataGridViewTextBoxColumn.Width = 105;
            // 
            // nombreClienteDataGridViewTextBoxColumn
            // 
            this.nombreClienteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreClienteDataGridViewTextBoxColumn.DataPropertyName = "NombreCliente";
            this.nombreClienteDataGridViewTextBoxColumn.HeaderText = "Nombre Cliente";
            this.nombreClienteDataGridViewTextBoxColumn.Name = "nombreClienteDataGridViewTextBoxColumn";
            this.nombreClienteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Ventana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(20, 20);
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1172, 648);
            this.Controls.Add(this.BtnRefrescar);
            this.Controls.Add(this.GroupBoxDetalle);
            this.Controls.Add(this.GroupBoxFactura);
            this.Controls.Add(this.GroupBoxVenta);
            this.Controls.Add(this.BtnCrearEjemplo);
            this.Controls.Add(this.LblTipo);
            this.Controls.Add(this.CboxTipo);
            this.Controls.Add(this.DgridLista);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Ventana";
            this.Padding = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Facturas";
            ((System.ComponentModel.ISupportInitialize)(this.DgridLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.miFileSystemWatcher)).EndInit();
            this.GroupBoxVenta.ResumeLayout(false);
            this.GroupBoxVenta.PerformLayout();
            this.GroupBoxFactura.ResumeLayout(false);
            this.GroupBoxFactura.PerformLayout();
            this.GroupBoxDetalle.ResumeLayout(false);
            this.GroupBoxDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView DgridLista;
        private System.Windows.Forms.ComboBox CboxTipo;
        private System.Windows.Forms.Label LblTipo;
        private System.Windows.Forms.Button BtnGrabarFactura;
        private System.Windows.Forms.Button BtnGrabarBoleta;
        private System.Windows.Forms.Button BtnCrearEjemplo;
        private System.IO.FileSystemWatcher miFileSystemWatcher;
        private System.Windows.Forms.BindingSource ventaBindingSource;
        private System.Windows.Forms.Label LblIdVenta;
        private System.Windows.Forms.TextBox TboxIdVenta;
        private System.Windows.Forms.DateTimePicker DTPickerFechaVenta;
        private System.Windows.Forms.Label LblFechaVenta;
        private System.Windows.Forms.TextBox TboxNombreUsuario;
        private System.Windows.Forms.Label LblNombreUsuario;
        private System.Windows.Forms.TextBox TboxNombreCliente;
        private System.Windows.Forms.TextBox TboxRutCliente;
        private System.Windows.Forms.Label LblNombreCliente;
        private System.Windows.Forms.Label LblRutCliente;
        private System.Windows.Forms.GroupBox GroupBoxVenta;
        private System.Windows.Forms.GroupBox GroupBoxFactura;
        private System.Windows.Forms.TextBox TboxRazonSocial;
        private System.Windows.Forms.Label LblRazonSocial;
        private System.Windows.Forms.Label LblRutFactura;
        private System.Windows.Forms.TextBox TboxRutFactura;
        private System.Windows.Forms.TextBox TboxGiro;
        private System.Windows.Forms.Label LblGiro;
        private System.Windows.Forms.Label LblDireccion;
        private System.Windows.Forms.TextBox TboxDireccion;
        private System.Windows.Forms.Label LblCiudad;
        private System.Windows.Forms.TextBox TboxCuidad;
        private System.Windows.Forms.Label LblContacto;
        private System.Windows.Forms.TextBox TboxContacto;
        private System.Windows.Forms.GroupBox GroupBoxDetalle;
        private System.Windows.Forms.Label LblElementoDetalle;
        private System.Windows.Forms.ComboBox CboxDetalle;
        private System.Windows.Forms.NumericUpDown NumCantidad;
        private System.Windows.Forms.Label LblCantidad;
        private System.Windows.Forms.Label LblPrecioTotal;
        private System.Windows.Forms.TextBox TboxPrecioTotal;
        private System.Windows.Forms.PrintDialog miPrintDialog;
        private System.Drawing.Printing.PrintDocument miPrintDocument;
        private System.Windows.Forms.Timer sincronizaMensajesTimer;
        private System.Windows.Forms.TextBox TboxSucursal;
        private System.Windows.Forms.Label LblSurcursal;
        private System.Windows.Forms.Label LblFormaPago;
        private System.Windows.Forms.TextBox TboxFormaPago;
        private System.Windows.Forms.Button BtnRefrescar;
        private System.Windows.Forms.Label LblPrecioUnitario;
        private System.Windows.Forms.TextBox TboxPrecioUnitario;
        private System.Windows.Forms.ImageList miImageList;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaVentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rutClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreClienteDataGridViewTextBoxColumn;
    }
}

