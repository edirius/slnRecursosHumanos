namespace CapaUsuario.Planilla
{
    partial class frmMantenimientoDetallePlanilla
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoDetallePlanilla));
            this.btnImportar = new System.Windows.Forms.Button();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtMeta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvDetallePlanilla = new System.Windows.Forms.DataGridView();
            this.txtIdTDetallePlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnProceso = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtNro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIdTTrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtApellidosNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIdTCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSistemaPensiones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecFunc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remuneracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiasLaborados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalRemuneracio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRegimenLaboral = new System.Windows.Forms.TextBox();
            this.txtFuenteFinanciamiento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAgregarTrabajador = new System.Windows.Forms.Button();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnAprobacion = new System.Windows.Forms.Button();
            this.btnRenta5ta = new System.Windows.Forms.Button();
            this.chkQuinta = new System.Windows.Forms.CheckBox();
            this.btnAsistenciaReloj = new System.Windows.Forms.Button();
            this.btnImprimirReporteAsistencia = new System.Windows.Forms.Button();
            this.dlgGuardarReportePDF = new System.Windows.Forms.SaveFileDialog();
            this.chkAguinaldo = new System.Windows.Forms.CheckBox();
            this.chkAFP = new System.Windows.Forms.CheckBox();
            this.btnVerDetalleTrabajador = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePlanilla)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImportar
            // 
            this.btnImportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportar.BackColor = System.Drawing.Color.MintCream;
            this.btnImportar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnImportar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnImportar.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnImportar.Location = new System.Drawing.Point(880, 38);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(238, 46);
            this.btnImportar.TabIndex = 91;
            this.btnImportar.Text = "&Importar Tareo";
            this.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // txtFecha
            // 
            this.txtFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFecha.Enabled = false;
            this.txtFecha.Location = new System.Drawing.Point(617, 12);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(146, 20);
            this.txtFecha.TabIndex = 88;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.MintCream;
            this.btnCancelar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelar.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnCancelar.Location = new System.Drawing.Point(1044, 391);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(74, 65);
            this.btnCancelar.TabIndex = 86;
            this.btnCancelar.Text = "&Salir";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.BackColor = System.Drawing.Color.MintCream;
            this.btnAceptar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAceptar.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnAceptar.Location = new System.Drawing.Point(963, 391);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 65);
            this.btnAceptar.TabIndex = 85;
            this.btnAceptar.Text = "&Guardar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtMeta
            // 
            this.txtMeta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMeta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMeta.Enabled = false;
            this.txtMeta.Location = new System.Drawing.Point(135, 38);
            this.txtMeta.Name = "txtMeta";
            this.txtMeta.Size = new System.Drawing.Size(739, 20);
            this.txtMeta.TabIndex = 84;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(568, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 83;
            this.label6.Text = "Fecha :";
            // 
            // txtNumero
            // 
            this.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(416, 12);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(146, 20);
            this.txtNumero.TabIndex = 82;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 81;
            this.label8.Text = "Regimen Laboral :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(360, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 80;
            this.label10.Text = "Numero :";
            // 
            // dgvDetallePlanilla
            // 
            this.dgvDetallePlanilla.AllowUserToAddRows = false;
            this.dgvDetallePlanilla.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dgvDetallePlanilla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetallePlanilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetallePlanilla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetallePlanilla.ColumnHeadersHeight = 45;
            this.dgvDetallePlanilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtIdTDetallePlanilla,
            this.txtAccion,
            this.btnProceso,
            this.txtNro,
            this.txtIdTTrabajador,
            this.txtApellidosNombres,
            this.txtIdTCargo,
            this.txtSistemaPensiones,
            this.txtDNI,
            this.SecFunc,
            this.FechaInicio,
            this.Remuneracion,
            this.DiasLaborados,
            this.TotalRemuneracio});
            this.dgvDetallePlanilla.Location = new System.Drawing.Point(12, 90);
            this.dgvDetallePlanilla.Name = "dgvDetallePlanilla";
            this.dgvDetallePlanilla.RowHeadersVisible = false;
            this.dgvDetallePlanilla.RowHeadersWidth = 25;
            this.dgvDetallePlanilla.Size = new System.Drawing.Size(1106, 295);
            this.dgvDetallePlanilla.TabIndex = 79;
            this.dgvDetallePlanilla.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetallePlanilla_CellClick);
            this.dgvDetallePlanilla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetallePlanilla_CellContentClick);
            this.dgvDetallePlanilla.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetallePlanilla_CellEndEdit);
            // 
            // txtIdTDetallePlanilla
            // 
            this.txtIdTDetallePlanilla.HeaderText = "IdTDetallePlanilla";
            this.txtIdTDetallePlanilla.Name = "txtIdTDetallePlanilla";
            this.txtIdTDetallePlanilla.ReadOnly = true;
            this.txtIdTDetallePlanilla.Visible = false;
            this.txtIdTDetallePlanilla.Width = 30;
            // 
            // txtAccion
            // 
            this.txtAccion.HeaderText = "Accion";
            this.txtAccion.Name = "txtAccion";
            this.txtAccion.Visible = false;
            this.txtAccion.Width = 30;
            // 
            // btnProceso
            // 
            this.btnProceso.HeaderText = "";
            this.btnProceso.Name = "btnProceso";
            this.btnProceso.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnProceso.Width = 30;
            // 
            // txtNro
            // 
            this.txtNro.HeaderText = "NRO";
            this.txtNro.Name = "txtNro";
            this.txtNro.ReadOnly = true;
            this.txtNro.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtNro.Width = 30;
            // 
            // txtIdTTrabajador
            // 
            this.txtIdTTrabajador.HeaderText = "IdTTrabajador";
            this.txtIdTTrabajador.Name = "txtIdTTrabajador";
            this.txtIdTTrabajador.ReadOnly = true;
            this.txtIdTTrabajador.Visible = false;
            this.txtIdTTrabajador.Width = 50;
            // 
            // txtApellidosNombres
            // 
            this.txtApellidosNombres.HeaderText = "APELLIDOS Y NOMBRES";
            this.txtApellidosNombres.Name = "txtApellidosNombres";
            this.txtApellidosNombres.ReadOnly = true;
            this.txtApellidosNombres.Width = 200;
            // 
            // txtIdTCargo
            // 
            this.txtIdTCargo.HeaderText = "IdTCargo";
            this.txtIdTCargo.Name = "txtIdTCargo";
            this.txtIdTCargo.ReadOnly = true;
            this.txtIdTCargo.Visible = false;
            this.txtIdTCargo.Width = 30;
            // 
            // txtSistemaPensiones
            // 
            this.txtSistemaPensiones.HeaderText = "CARGO";
            this.txtSistemaPensiones.Name = "txtSistemaPensiones";
            this.txtSistemaPensiones.ReadOnly = true;
            this.txtSistemaPensiones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txtSistemaPensiones.Width = 150;
            // 
            // txtDNI
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.txtDNI.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtDNI.HeaderText = "DNI";
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.ReadOnly = true;
            this.txtDNI.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtDNI.Width = 60;
            // 
            // SecFunc
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SecFunc.DefaultCellStyle = dataGridViewCellStyle4;
            this.SecFunc.HeaderText = "SEC. FUNC.";
            this.SecFunc.Name = "SecFunc";
            this.SecFunc.ReadOnly = true;
            this.SecFunc.Width = 30;
            // 
            // FechaInicio
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FechaInicio.DefaultCellStyle = dataGridViewCellStyle5;
            this.FechaInicio.HeaderText = "FEC. INICIO";
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.ReadOnly = true;
            this.FechaInicio.Width = 75;
            // 
            // Remuneracion
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.NullValue = null;
            this.Remuneracion.DefaultCellStyle = dataGridViewCellStyle6;
            this.Remuneracion.HeaderText = "REMUNER. CONTRATO";
            this.Remuneracion.Name = "Remuneracion";
            this.Remuneracion.ReadOnly = true;
            this.Remuneracion.Width = 50;
            // 
            // DiasLaborados
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DiasLaborados.DefaultCellStyle = dataGridViewCellStyle7;
            this.DiasLaborados.HeaderText = "DIAS LABOR.";
            this.DiasLaborados.Name = "DiasLaborados";
            this.DiasLaborados.Width = 40;
            // 
            // TotalRemuneracio
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TotalRemuneracio.DefaultCellStyle = dataGridViewCellStyle8;
            this.TotalRemuneracio.HeaderText = "REMUNER.";
            this.TotalRemuneracio.Name = "TotalRemuneracio";
            this.TotalRemuneracio.ReadOnly = true;
            this.TotalRemuneracio.Width = 50;
            // 
            // txtRegimenLaboral
            // 
            this.txtRegimenLaboral.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRegimenLaboral.Enabled = false;
            this.txtRegimenLaboral.Location = new System.Drawing.Point(135, 12);
            this.txtRegimenLaboral.Name = "txtRegimenLaboral";
            this.txtRegimenLaboral.Size = new System.Drawing.Size(219, 20);
            this.txtRegimenLaboral.TabIndex = 92;
            // 
            // txtFuenteFinanciamiento
            // 
            this.txtFuenteFinanciamiento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFuenteFinanciamiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFuenteFinanciamiento.Enabled = false;
            this.txtFuenteFinanciamiento.Location = new System.Drawing.Point(135, 64);
            this.txtFuenteFinanciamiento.Name = "txtFuenteFinanciamiento";
            this.txtFuenteFinanciamiento.Size = new System.Drawing.Size(739, 20);
            this.txtFuenteFinanciamiento.TabIndex = 93;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 94;
            this.label1.Text = "Meta :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "Fuente Financiamiento :";
            // 
            // btnAgregarTrabajador
            // 
            this.btnAgregarTrabajador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarTrabajador.BackColor = System.Drawing.Color.MintCream;
            this.btnAgregarTrabajador.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarTrabajador.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAgregarTrabajador.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnAgregarTrabajador.Location = new System.Drawing.Point(785, 391);
            this.btnAgregarTrabajador.Name = "btnAgregarTrabajador";
            this.btnAgregarTrabajador.Size = new System.Drawing.Size(83, 65);
            this.btnAgregarTrabajador.TabIndex = 96;
            this.btnAgregarTrabajador.Text = "&Agregar Trabajador";
            this.btnAgregarTrabajador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgregarTrabajador.UseVisualStyleBackColor = false;
            this.btnAgregarTrabajador.Click += new System.EventHandler(this.btnAgregarTrabajador_Click);
            // 
            // btnCalcular
            // 
            this.btnCalcular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalcular.BackColor = System.Drawing.Color.MintCream;
            this.btnCalcular.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnCalcular.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCalcular.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnCalcular.Location = new System.Drawing.Point(874, 391);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(83, 65);
            this.btnCalcular.TabIndex = 97;
            this.btnCalcular.Text = "&Calcular Planilla";
            this.btnCalcular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCalcular.UseVisualStyleBackColor = false;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnAprobacion
            // 
            this.btnAprobacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAprobacion.BackColor = System.Drawing.Color.MintCream;
            this.btnAprobacion.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnAprobacion.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAprobacion.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnAprobacion.Location = new System.Drawing.Point(12, 391);
            this.btnAprobacion.Name = "btnAprobacion";
            this.btnAprobacion.Size = new System.Drawing.Size(153, 65);
            this.btnAprobacion.TabIndex = 98;
            this.btnAprobacion.Text = "&Poner en Aprobacion";
            this.btnAprobacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAprobacion.UseVisualStyleBackColor = false;
            this.btnAprobacion.Click += new System.EventHandler(this.btnAprobacion_Click);
            // 
            // btnRenta5ta
            // 
            this.btnRenta5ta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRenta5ta.BackColor = System.Drawing.Color.MintCream;
            this.btnRenta5ta.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnRenta5ta.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnRenta5ta.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnRenta5ta.Location = new System.Drawing.Point(685, 391);
            this.btnRenta5ta.Name = "btnRenta5ta";
            this.btnRenta5ta.Size = new System.Drawing.Size(94, 65);
            this.btnRenta5ta.TabIndex = 99;
            this.btnRenta5ta.Text = "&Renta 5ta Proyectado";
            this.btnRenta5ta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRenta5ta.UseVisualStyleBackColor = false;
            this.btnRenta5ta.Click += new System.EventHandler(this.btnRenta5ta_Click);
            // 
            // chkQuinta
            // 
            this.chkQuinta.AutoSize = true;
            this.chkQuinta.Location = new System.Drawing.Point(837, 12);
            this.chkQuinta.Name = "chkQuinta";
            this.chkQuinta.Size = new System.Drawing.Size(59, 17);
            this.chkQuinta.TabIndex = 100;
            this.chkQuinta.Text = "5ta cat";
            this.chkQuinta.UseVisualStyleBackColor = true;
            // 
            // btnAsistenciaReloj
            // 
            this.btnAsistenciaReloj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsistenciaReloj.BackColor = System.Drawing.Color.MintCream;
            this.btnAsistenciaReloj.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnAsistenciaReloj.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnAsistenciaReloj.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnAsistenciaReloj.Location = new System.Drawing.Point(436, 391);
            this.btnAsistenciaReloj.Name = "btnAsistenciaReloj";
            this.btnAsistenciaReloj.Size = new System.Drawing.Size(94, 65);
            this.btnAsistenciaReloj.TabIndex = 101;
            this.btnAsistenciaReloj.Text = "&Jornada Laboral";
            this.btnAsistenciaReloj.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAsistenciaReloj.UseVisualStyleBackColor = false;
            this.btnAsistenciaReloj.Click += new System.EventHandler(this.btnAsistenciaReloj_Click);
            // 
            // btnImprimirReporteAsistencia
            // 
            this.btnImprimirReporteAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimirReporteAsistencia.BackColor = System.Drawing.Color.MintCream;
            this.btnImprimirReporteAsistencia.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnImprimirReporteAsistencia.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnImprimirReporteAsistencia.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnImprimirReporteAsistencia.Location = new System.Drawing.Point(536, 391);
            this.btnImprimirReporteAsistencia.Name = "btnImprimirReporteAsistencia";
            this.btnImprimirReporteAsistencia.Size = new System.Drawing.Size(94, 65);
            this.btnImprimirReporteAsistencia.TabIndex = 102;
            this.btnImprimirReporteAsistencia.Text = "&Imprimir Reporte Asistencia";
            this.btnImprimirReporteAsistencia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImprimirReporteAsistencia.UseVisualStyleBackColor = false;
            this.btnImprimirReporteAsistencia.Click += new System.EventHandler(this.btnImprimirReporteAsistencia_Click);
            // 
            // dlgGuardarReportePDF
            // 
            this.dlgGuardarReportePDF.Filter = "\"pdf archivo (*.pdf)|*.pdf";
            // 
            // chkAguinaldo
            // 
            this.chkAguinaldo.AutoSize = true;
            this.chkAguinaldo.Location = new System.Drawing.Point(769, 11);
            this.chkAguinaldo.Name = "chkAguinaldo";
            this.chkAguinaldo.Size = new System.Drawing.Size(61, 17);
            this.chkAguinaldo.TabIndex = 103;
            this.chkAguinaldo.Text = "Aguinal";
            this.chkAguinaldo.UseVisualStyleBackColor = true;
            // 
            // chkAFP
            // 
            this.chkAFP.AutoSize = true;
            this.chkAFP.Location = new System.Drawing.Point(902, 11);
            this.chkAFP.Name = "chkAFP";
            this.chkAFP.Size = new System.Drawing.Size(46, 17);
            this.chkAFP.TabIndex = 104;
            this.chkAFP.Text = "AFP";
            this.chkAFP.UseVisualStyleBackColor = true;
            // 
            // btnVerDetalleTrabajador
            // 
            this.btnVerDetalleTrabajador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerDetalleTrabajador.BackColor = System.Drawing.Color.MintCream;
            this.btnVerDetalleTrabajador.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnVerDetalleTrabajador.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnVerDetalleTrabajador.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnVerDetalleTrabajador.Location = new System.Drawing.Point(954, 2);
            this.btnVerDetalleTrabajador.Name = "btnVerDetalleTrabajador";
            this.btnVerDetalleTrabajador.Size = new System.Drawing.Size(164, 34);
            this.btnVerDetalleTrabajador.TabIndex = 105;
            this.btnVerDetalleTrabajador.Text = "&Ver Detalle Trabajador";
            this.btnVerDetalleTrabajador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVerDetalleTrabajador.UseVisualStyleBackColor = false;
            this.btnVerDetalleTrabajador.Click += new System.EventHandler(this.btnVerDetalleTrabajador_Click);
            // 
            // frmMantenimientoDetallePlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 468);
            this.Controls.Add(this.btnVerDetalleTrabajador);
            this.Controls.Add(this.chkAFP);
            this.Controls.Add(this.chkAguinaldo);
            this.Controls.Add(this.btnImprimirReporteAsistencia);
            this.Controls.Add(this.btnAsistenciaReloj);
            this.Controls.Add(this.chkQuinta);
            this.Controls.Add(this.btnRenta5ta);
            this.Controls.Add(this.btnAprobacion);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.btnAgregarTrabajador);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFuenteFinanciamiento);
            this.Controls.Add(this.txtRegimenLaboral);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtMeta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgvDetallePlanilla);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMantenimientoDetallePlanilla";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Detalle Planilla";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMantenimientoDetallePlanilla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePlanilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtMeta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvDetallePlanilla;
        private System.Windows.Forms.TextBox txtRegimenLaboral;
        private System.Windows.Forms.TextBox txtFuenteFinanciamiento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAgregarTrabajador;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnAprobacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtIdTDetallePlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAccion;
        private System.Windows.Forms.DataGridViewButtonColumn btnProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtNro;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtIdTTrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtApellidosNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtIdTCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSistemaPensiones;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecFunc;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remuneracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiasLaborados;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalRemuneracio;
        private System.Windows.Forms.Button btnRenta5ta;
        private System.Windows.Forms.CheckBox chkQuinta;
        private System.Windows.Forms.Button btnAsistenciaReloj;
        private System.Windows.Forms.Button btnImprimirReporteAsistencia;
        private System.Windows.Forms.SaveFileDialog dlgGuardarReportePDF;
        private System.Windows.Forms.CheckBox chkAguinaldo;
        private System.Windows.Forms.CheckBox chkAFP;
        private System.Windows.Forms.Button btnVerDetalleTrabajador;
    }
}