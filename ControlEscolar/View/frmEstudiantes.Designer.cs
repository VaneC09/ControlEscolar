namespace ControlEscolar.View
{
    partial class frmEstudiantes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstudiantes));
            lblControlEstudiantes = new Label();
            scEstudiantes = new SplitContainer();
            grbAltaOEdicion = new GroupBox();
            lblDatosObligatorios = new Label();
            btnGuardar = new Button();
            dtpFechaBaja = new DateTimePicker();
            lblFechaBaja = new Label();
            cmbEstatus = new ComboBox();
            lblEstatus = new Label();
            dtpFechaAlta = new DateTimePicker();
            lblFechaAlta = new Label();
            pictureBox1 = new PictureBox();
            txtNoControl = new TextBox();
            lblNoControl = new Label();
            lblSemestre = new Label();
            upSemestre = new NumericUpDown();
            lblFechaNac = new Label();
            dtpFechaDeNacimiento = new DateTimePicker();
            txtCURP = new TextBox();
            lblCURP = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            txtCorreo = new TextBox();
            lblCorreo = new Label();
            txtNombre = new TextBox();
            lblnombre = new Label();
            dgvEstudiantes = new DataGridView();
            cmsEstudiantes = new ContextMenuStrip(components);
            editarEstudiante = new ToolStripMenuItem();
            grbFiltros = new GroupBox();
            chkSoloActivos = new CheckBox();
            dtpFechaFin = new DateTimePicker();
            lblFechaFin = new Label();
            lblTotalRegistros = new Label();
            btnActualizar = new Button();
            txtBusqueda = new TextBox();
            dtpFechaInicio = new DateTimePicker();
            lblFechaInicio = new Label();
            cmbTipoFecha = new ComboBox();
            lblBusquedaTexto = new Label();
            lblTipoFecha = new Label();
            grbHerramientas = new GroupBox();
            btnExportarExcel = new Button();
            lblRuta = new Label();
            btnCargaMasiva = new Button();
            btnMostrarCaptura = new Button();
            Info = new ToolTip(components);
            ofdArchivo = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)scEstudiantes).BeginInit();
            scEstudiantes.Panel1.SuspendLayout();
            scEstudiantes.Panel2.SuspendLayout();
            scEstudiantes.SuspendLayout();
            grbAltaOEdicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)upSemestre).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEstudiantes).BeginInit();
            cmsEstudiantes.SuspendLayout();
            grbFiltros.SuspendLayout();
            grbHerramientas.SuspendLayout();
            SuspendLayout();
            // 
            // lblControlEstudiantes
            // 
            lblControlEstudiantes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblControlEstudiantes.BackColor = Color.DarkOrchid;
            lblControlEstudiantes.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblControlEstudiantes.ForeColor = SystemColors.ButtonHighlight;
            lblControlEstudiantes.Location = new Point(1, 46);
            lblControlEstudiantes.Name = "lblControlEstudiantes";
            lblControlEstudiantes.Size = new Size(928, 28);
            lblControlEstudiantes.TabIndex = 0;
            lblControlEstudiantes.Text = "Control de estudiantes";
            lblControlEstudiantes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // scEstudiantes
            // 
            scEstudiantes.Location = new Point(20, 104);
            scEstudiantes.Margin = new Padding(3, 2, 3, 2);
            scEstudiantes.Name = "scEstudiantes";
            // 
            // scEstudiantes.Panel1
            // 
            scEstudiantes.Panel1.Controls.Add(grbAltaOEdicion);
            // 
            // scEstudiantes.Panel2
            // 
            scEstudiantes.Panel2.Controls.Add(dgvEstudiantes);
            scEstudiantes.Panel2.Controls.Add(grbFiltros);
            scEstudiantes.Panel2.Controls.Add(grbHerramientas);
            scEstudiantes.Size = new Size(893, 510);
            scEstudiantes.SplitterDistance = 332;
            scEstudiantes.TabIndex = 1;
            // 
            // grbAltaOEdicion
            // 
            grbAltaOEdicion.BackColor = Color.FromArgb(255, 192, 255);
            grbAltaOEdicion.Controls.Add(lblDatosObligatorios);
            grbAltaOEdicion.Controls.Add(btnGuardar);
            grbAltaOEdicion.Controls.Add(dtpFechaBaja);
            grbAltaOEdicion.Controls.Add(lblFechaBaja);
            grbAltaOEdicion.Controls.Add(cmbEstatus);
            grbAltaOEdicion.Controls.Add(lblEstatus);
            grbAltaOEdicion.Controls.Add(dtpFechaAlta);
            grbAltaOEdicion.Controls.Add(lblFechaAlta);
            grbAltaOEdicion.Controls.Add(pictureBox1);
            grbAltaOEdicion.Controls.Add(txtNoControl);
            grbAltaOEdicion.Controls.Add(lblNoControl);
            grbAltaOEdicion.Controls.Add(lblSemestre);
            grbAltaOEdicion.Controls.Add(upSemestre);
            grbAltaOEdicion.Controls.Add(lblFechaNac);
            grbAltaOEdicion.Controls.Add(dtpFechaDeNacimiento);
            grbAltaOEdicion.Controls.Add(txtCURP);
            grbAltaOEdicion.Controls.Add(lblCURP);
            grbAltaOEdicion.Controls.Add(txtTelefono);
            grbAltaOEdicion.Controls.Add(lblTelefono);
            grbAltaOEdicion.Controls.Add(txtCorreo);
            grbAltaOEdicion.Controls.Add(lblCorreo);
            grbAltaOEdicion.Controls.Add(txtNombre);
            grbAltaOEdicion.Controls.Add(lblnombre);
            grbAltaOEdicion.Location = new Point(14, 16);
            grbAltaOEdicion.Margin = new Padding(3, 2, 3, 2);
            grbAltaOEdicion.Name = "grbAltaOEdicion";
            grbAltaOEdicion.Padding = new Padding(3, 2, 3, 2);
            grbAltaOEdicion.Size = new Size(306, 475);
            grbAltaOEdicion.TabIndex = 0;
            grbAltaOEdicion.TabStop = false;
            grbAltaOEdicion.Text = "Alta o edición";
            // 
            // lblDatosObligatorios
            // 
            lblDatosObligatorios.AutoSize = true;
            lblDatosObligatorios.Location = new Point(18, 448);
            lblDatosObligatorios.Name = "lblDatosObligatorios";
            lblDatosObligatorios.Size = new Size(111, 15);
            lblDatosObligatorios.TabIndex = 23;
            lblDatosObligatorios.Text = "* Datos obligatorios";
            // 
            // btnGuardar
            // 
            btnGuardar.Image = (Image)resources.GetObject("btnGuardar.Image");
            btnGuardar.ImageAlign = ContentAlignment.MiddleRight;
            btnGuardar.Location = new Point(183, 442);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(96, 28);
            btnGuardar.TabIndex = 22;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextAlign = ContentAlignment.MiddleLeft;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // dtpFechaBaja
            // 
            dtpFechaBaja.Format = DateTimePickerFormat.Short;
            dtpFechaBaja.Location = new Point(23, 402);
            dtpFechaBaja.Margin = new Padding(3, 2, 3, 2);
            dtpFechaBaja.Name = "dtpFechaBaja";
            dtpFechaBaja.Size = new Size(219, 23);
            dtpFechaBaja.TabIndex = 21;
            // 
            // lblFechaBaja
            // 
            lblFechaBaja.AutoSize = true;
            lblFechaBaja.Location = new Point(19, 383);
            lblFechaBaja.Name = "lblFechaBaja";
            lblFechaBaja.Size = new Size(63, 15);
            lblFechaBaja.TabIndex = 20;
            lblFechaBaja.Text = "Fecha baja";
            // 
            // cmbEstatus
            // 
            cmbEstatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstatus.FormattingEnabled = true;
            cmbEstatus.Location = new Point(23, 350);
            cmbEstatus.Margin = new Padding(3, 2, 3, 2);
            cmbEstatus.Name = "cmbEstatus";
            cmbEstatus.Size = new Size(190, 23);
            cmbEstatus.TabIndex = 19;
            // 
            // lblEstatus
            // 
            lblEstatus.AutoSize = true;
            lblEstatus.Location = new Point(22, 332);
            lblEstatus.Name = "lblEstatus";
            lblEstatus.Size = new Size(52, 15);
            lblEstatus.TabIndex = 18;
            lblEstatus.Text = "Estatus *";
            // 
            // dtpFechaAlta
            // 
            dtpFechaAlta.Format = DateTimePickerFormat.Short;
            dtpFechaAlta.Location = new Point(23, 310);
            dtpFechaAlta.Margin = new Padding(3, 2, 3, 2);
            dtpFechaAlta.Name = "dtpFechaAlta";
            dtpFechaAlta.Size = new Size(219, 23);
            dtpFechaAlta.TabIndex = 17;
            // 
            // lblFechaAlta
            // 
            lblFechaAlta.AutoSize = true;
            lblFechaAlta.Location = new Point(23, 292);
            lblFechaAlta.Name = "lblFechaAlta";
            lblFechaAlta.Size = new Size(70, 15);
            lblFechaAlta.TabIndex = 16;
            lblFechaAlta.Text = "Fecha Alta *";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(167, 270);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(20, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            Info.SetToolTip(pictureBox1, "T/M-Año de ingreso-Número de alumno");
            // 
            // txtNoControl
            // 
            txtNoControl.Location = new Point(23, 270);
            txtNoControl.Margin = new Padding(3, 2, 3, 2);
            txtNoControl.MaxLength = 20;
            txtNoControl.Name = "txtNoControl";
            txtNoControl.Size = new Size(140, 23);
            txtNoControl.TabIndex = 14;
            // 
            // lblNoControl
            // 
            lblNoControl.AutoSize = true;
            lblNoControl.Location = new Point(18, 253);
            lblNoControl.Name = "lblNoControl";
            lblNoControl.Size = new Size(85, 15);
            lblNoControl.TabIndex = 13;
            lblNoControl.Text = "No. de Control";
            // 
            // lblSemestre
            // 
            lblSemestre.AutoSize = true;
            lblSemestre.Location = new Point(172, 200);
            lblSemestre.Name = "lblSemestre";
            lblSemestre.Size = new Size(63, 15);
            lblSemestre.TabIndex = 12;
            lblSemestre.Text = "Semestre *";
            // 
            // upSemestre
            // 
            upSemestre.Location = new Point(172, 224);
            upSemestre.Margin = new Padding(3, 2, 3, 2);
            upSemestre.Maximum = new decimal(new int[] { 13, 0, 0, 0 });
            upSemestre.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            upSemestre.Name = "upSemestre";
            upSemestre.Size = new Size(131, 23);
            upSemestre.TabIndex = 10;
            upSemestre.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblFechaNac
            // 
            lblFechaNac.AutoSize = true;
            lblFechaNac.Location = new Point(19, 200);
            lblFechaNac.Name = "lblFechaNac";
            lblFechaNac.Size = new Size(127, 15);
            lblFechaNac.TabIndex = 9;
            lblFechaNac.Text = "Fecha de Nacimiento *";
            // 
            // dtpFechaDeNacimiento
            // 
            dtpFechaDeNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaDeNacimiento.Location = new Point(19, 224);
            dtpFechaDeNacimiento.Margin = new Padding(3, 2, 3, 2);
            dtpFechaDeNacimiento.Name = "dtpFechaDeNacimiento";
            dtpFechaDeNacimiento.Size = new Size(96, 23);
            dtpFechaDeNacimiento.TabIndex = 8;
            // 
            // txtCURP
            // 
            txtCURP.Location = new Point(23, 170);
            txtCURP.Margin = new Padding(3, 2, 3, 2);
            txtCURP.MaxLength = 18;
            txtCURP.Name = "txtCURP";
            txtCURP.Size = new Size(242, 23);
            txtCURP.TabIndex = 7;
            // 
            // lblCURP
            // 
            lblCURP.AutoSize = true;
            lblCURP.Location = new Point(23, 153);
            lblCURP.Name = "lblCURP";
            lblCURP.Size = new Size(45, 15);
            lblCURP.TabIndex = 6;
            lblCURP.Text = "CURP *";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(23, 130);
            txtTelefono.Margin = new Padding(3, 2, 3, 2);
            txtTelefono.MaxLength = 15;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(110, 23);
            txtTelefono.TabIndex = 5;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(23, 113);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(61, 15);
            lblTelefono.TabIndex = 4;
            lblTelefono.Text = "Telefono *";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(23, 86);
            txtCorreo.Margin = new Padding(3, 2, 3, 2);
            txtCorreo.MaxLength = 100;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(237, 23);
            txtCorreo.TabIndex = 3;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(23, 68);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(51, 15);
            lblCorreo.TabIndex = 2;
            lblCorreo.Text = "Correo *";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(23, 43);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.MaxLength = 255;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(242, 23);
            txtNombre.TabIndex = 1;
            // 
            // lblnombre
            // 
            lblnombre.AutoSize = true;
            lblnombre.Location = new Point(23, 28);
            lblnombre.Name = "lblnombre";
            lblnombre.Size = new Size(115, 15);
            lblnombre.TabIndex = 0;
            lblnombre.Text = "Nombre Completo *";
            // 
            // dgvEstudiantes
            // 
            dgvEstudiantes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEstudiantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEstudiantes.ContextMenuStrip = cmsEstudiantes;
            dgvEstudiantes.Location = new Point(10, 232);
            dgvEstudiantes.Name = "dgvEstudiantes";
            dgvEstudiantes.Size = new Size(528, 286);
            dgvEstudiantes.TabIndex = 2;
            // 
            // cmsEstudiantes
            // 
            cmsEstudiantes.Items.AddRange(new ToolStripItem[] { editarEstudiante });
            cmsEstudiantes.Name = "contextMenuStrip2";
            cmsEstudiantes.Size = new Size(163, 26);
            // 
            // editarEstudiante
            // 
            editarEstudiante.Name = "editarEstudiante";
            editarEstudiante.Size = new Size(162, 22);
            editarEstudiante.Text = "Editar Estudiante";
            editarEstudiante.Click += editarEstudiante_Click;
            // 
            // grbFiltros
            // 
            grbFiltros.BackColor = Color.FromArgb(255, 192, 255);
            grbFiltros.Controls.Add(chkSoloActivos);
            grbFiltros.Controls.Add(dtpFechaFin);
            grbFiltros.Controls.Add(lblFechaFin);
            grbFiltros.Controls.Add(lblTotalRegistros);
            grbFiltros.Controls.Add(btnActualizar);
            grbFiltros.Controls.Add(txtBusqueda);
            grbFiltros.Controls.Add(dtpFechaInicio);
            grbFiltros.Controls.Add(lblFechaInicio);
            grbFiltros.Controls.Add(cmbTipoFecha);
            grbFiltros.Controls.Add(lblBusquedaTexto);
            grbFiltros.Controls.Add(lblTipoFecha);
            grbFiltros.Location = new Point(10, 88);
            grbFiltros.Margin = new Padding(3, 2, 3, 2);
            grbFiltros.Name = "grbFiltros";
            grbFiltros.Padding = new Padding(3, 2, 3, 2);
            grbFiltros.Size = new Size(528, 139);
            grbFiltros.TabIndex = 1;
            grbFiltros.TabStop = false;
            grbFiltros.Text = "Filtros";
            // 
            // chkSoloActivos
            // 
            chkSoloActivos.AutoSize = true;
            chkSoloActivos.Location = new Point(404, 69);
            chkSoloActivos.Name = "chkSoloActivos";
            chkSoloActivos.Size = new Size(91, 19);
            chkSoloActivos.TabIndex = 10;
            chkSoloActivos.Text = "Solo Activos";
            chkSoloActivos.UseVisualStyleBackColor = true;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(367, 41);
            dtpFechaFin.Margin = new Padding(3, 2, 3, 2);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(142, 23);
            dtpFechaFin.TabIndex = 9;
            // 
            // lblFechaFin
            // 
            lblFechaFin.AutoSize = true;
            lblFechaFin.Location = new Point(288, 41);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(60, 15);
            lblFechaFin.TabIndex = 8;
            lblFechaFin.Text = "Fecha Fin:";
            // 
            // lblTotalRegistros
            // 
            lblTotalRegistros.AutoSize = true;
            lblTotalRegistros.Location = new Point(11, 109);
            lblTotalRegistros.Name = "lblTotalRegistros";
            lblTotalRegistros.Size = new Size(87, 15);
            lblTotalRegistros.TabIndex = 7;
            lblTotalRegistros.Text = "Total Registros:";
            // 
            // btnActualizar
            // 
            btnActualizar.Image = Properties.Resources._984748_arrows_refresh_reload_update_icon;
            btnActualizar.ImageAlign = ContentAlignment.MiddleRight;
            btnActualizar.Location = new Point(395, 102);
            btnActualizar.Margin = new Padding(3, 2, 3, 2);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(114, 22);
            btnActualizar.TabIndex = 6;
            btnActualizar.Text = "Actualizar";
            btnActualizar.TextAlign = ContentAlignment.MiddleLeft;
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(119, 63);
            txtBusqueda.Margin = new Padding(3, 2, 3, 2);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(229, 23);
            txtBusqueda.TabIndex = 5;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(367, 12);
            dtpFechaInicio.Margin = new Padding(3, 2, 3, 2);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(142, 23);
            dtpFechaInicio.TabIndex = 4;
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Location = new Point(288, 14);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(73, 15);
            lblFechaInicio.TabIndex = 3;
            lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // cmbTipoFecha
            // 
            cmbTipoFecha.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoFecha.FormattingEnabled = true;
            cmbTipoFecha.Location = new Point(86, 14);
            cmbTipoFecha.Margin = new Padding(3, 2, 3, 2);
            cmbTipoFecha.Name = "cmbTipoFecha";
            cmbTipoFecha.Size = new Size(133, 23);
            cmbTipoFecha.TabIndex = 2;
            // 
            // lblBusquedaTexto
            // 
            lblBusquedaTexto.AutoSize = true;
            lblBusquedaTexto.Location = new Point(6, 66);
            lblBusquedaTexto.Name = "lblBusquedaTexto";
            lblBusquedaTexto.Size = new Size(112, 15);
            lblBusquedaTexto.TabIndex = 1;
            lblBusquedaTexto.Text = "Busqueda por texto:";
            // 
            // lblTipoFecha
            // 
            lblTipoFecha.AutoSize = true;
            lblTipoFecha.Location = new Point(11, 17);
            lblTipoFecha.Name = "lblTipoFecha";
            lblTipoFecha.Size = new Size(66, 15);
            lblTipoFecha.TabIndex = 0;
            lblTipoFecha.Text = "Tipo fecha:";
            // 
            // grbHerramientas
            // 
            grbHerramientas.BackColor = Color.FromArgb(255, 192, 255);
            grbHerramientas.Controls.Add(btnExportarExcel);
            grbHerramientas.Controls.Add(lblRuta);
            grbHerramientas.Controls.Add(btnCargaMasiva);
            grbHerramientas.Controls.Add(btnMostrarCaptura);
            grbHerramientas.Location = new Point(10, 16);
            grbHerramientas.Margin = new Padding(3, 2, 3, 2);
            grbHerramientas.Name = "grbHerramientas";
            grbHerramientas.Padding = new Padding(3, 2, 3, 2);
            grbHerramientas.Size = new Size(528, 56);
            grbHerramientas.TabIndex = 0;
            grbHerramientas.TabStop = false;
            grbHerramientas.Text = "Herramientas";
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.Location = new Point(395, 20);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(127, 23);
            btnExportarExcel.TabIndex = 24;
            btnExportarExcel.Text = "Exportar a Excel";
            btnExportarExcel.UseVisualStyleBackColor = true;
            btnExportarExcel.Click += btnExportarExcel_Click;
            // 
            // lblRuta
            // 
            lblRuta.AutoSize = true;
            lblRuta.Location = new Point(246, 29);
            lblRuta.Name = "lblRuta";
            lblRuta.Size = new Size(152, 15);
            lblRuta.TabIndex = 2;
            lblRuta.Text = "Ruta de archivos a importar";
            // 
            // btnCargaMasiva
            // 
            btnCargaMasiva.Location = new Point(137, 20);
            btnCargaMasiva.Margin = new Padding(3, 2, 3, 2);
            btnCargaMasiva.Name = "btnCargaMasiva";
            btnCargaMasiva.Size = new Size(99, 28);
            btnCargaMasiva.TabIndex = 1;
            btnCargaMasiva.Text = "Carga masiva";
            btnCargaMasiva.UseVisualStyleBackColor = true;
            btnCargaMasiva.Click += btnCargaMasiva_Click;
            // 
            // btnMostrarCaptura
            // 
            btnMostrarCaptura.Location = new Point(11, 24);
            btnMostrarCaptura.Margin = new Padding(3, 2, 3, 2);
            btnMostrarCaptura.Name = "btnMostrarCaptura";
            btnMostrarCaptura.Size = new Size(120, 22);
            btnMostrarCaptura.TabIndex = 0;
            btnMostrarCaptura.Text = "Mostrar captura";
            btnMostrarCaptura.UseVisualStyleBackColor = true;
            btnMostrarCaptura.Click += btnMostrarCaptura_Click;
            // 
            // ofdArchivo
            // 
            ofdArchivo.FileName = "Carga masiva de estudiantes";
            // 
            // frmEstudiantes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.planetas_interconectados_3840x2160_xtrafondos_com;
            ClientSize = new Size(925, 670);
            Controls.Add(scEstudiantes);
            Controls.Add(lblControlEstudiantes);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmEstudiantes";
            Text = "frmEstudiantes";
            Load += frmEstudiantes_Load;
            scEstudiantes.Panel1.ResumeLayout(false);
            scEstudiantes.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scEstudiantes).EndInit();
            scEstudiantes.ResumeLayout(false);
            grbAltaOEdicion.ResumeLayout(false);
            grbAltaOEdicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)upSemestre).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEstudiantes).EndInit();
            cmsEstudiantes.ResumeLayout(false);
            grbFiltros.ResumeLayout(false);
            grbFiltros.PerformLayout();
            grbHerramientas.ResumeLayout(false);
            grbHerramientas.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblControlEstudiantes;
        private SplitContainer scEstudiantes;
        private GroupBox grbAltaOEdicion;
        private Label lblCorreo;
        private TextBox txtNombre;
        private Label lblnombre;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private TextBox txtCorreo;
        private TextBox txtCURP;
        private Label lblCURP;
        private DateTimePicker dtpFechaDeNacimiento;
        private Label lblFechaNac;
        private Label lblSemestre;
        private NumericUpDown upSemestre;
        private TextBox txtNoControl;
        private Label lblNoControl;
        private PictureBox pictureBox1;
        private ToolTip Info;
        private Label lblFechaAlta;
        private DateTimePicker dtpFechaAlta;
        private ComboBox cmbEstatus;
        private Label lblEstatus;
        private DateTimePicker dtpFechaBaja;
        private Label lblFechaBaja;
        private Label lblDatosObligatorios;
        private Button btnGuardar;
        private GroupBox grbFiltros;
        private GroupBox grbHerramientas;
        private Label lblRuta;
        private Button btnCargaMasiva;
        private Button btnMostrarCaptura;
        private Label lblTipoFecha;
        private Label lblBusquedaTexto;
        private TextBox txtBusqueda;
        private DateTimePicker dtpFechaInicio;
        private Label lblFechaInicio;
        private ComboBox cmbTipoFecha;
        private Button btnActualizar;
        private OpenFileDialog ofdArchivo;
        private DataGridView dgvEstudiantes;
        private Label lblTotalRegistros;
        private DateTimePicker dtpFechaFin;
        private Label lblFechaFin;
        private ContextMenuStrip cmsEstudiantes;
        private ToolStripMenuItem editarEstudiante;
        private CheckBox chkSoloActivos;
        private Button btnExportarExcel;
    }
}