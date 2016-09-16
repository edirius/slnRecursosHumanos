namespace CapaUsuario.Trabajador
{
    partial class frmRegimenTrabajador
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
            this.gbPeriodoCOntrato = new System.Windows.Forms.GroupBox();
            this.nupMontoPago = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCondicionLaboral = new System.Windows.Forms.ComboBox();
            this.chkServidorConfianza = new System.Windows.Forms.CheckBox();
            this.txtRUC = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.cboPeriodicidad = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.cboTipoPago = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboOcupacion = new System.Windows.Forms.ComboBox();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label25 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.cboCargo = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.cboMeta = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboRegimenLaboral = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTipoContrato = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCategoriaOcupacional = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTipoTrabajador = new System.Windows.Forms.ComboBox();
            this.gbPeriodoCOntrato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupMontoPago)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPeriodoCOntrato
            // 
            this.gbPeriodoCOntrato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPeriodoCOntrato.Controls.Add(this.nupMontoPago);
            this.gbPeriodoCOntrato.Controls.Add(this.label1);
            this.gbPeriodoCOntrato.Controls.Add(this.cboCondicionLaboral);
            this.gbPeriodoCOntrato.Controls.Add(this.chkServidorConfianza);
            this.gbPeriodoCOntrato.Controls.Add(this.txtRUC);
            this.gbPeriodoCOntrato.Controls.Add(this.label40);
            this.gbPeriodoCOntrato.Controls.Add(this.label39);
            this.gbPeriodoCOntrato.Controls.Add(this.label38);
            this.gbPeriodoCOntrato.Controls.Add(this.cboPeriodicidad);
            this.gbPeriodoCOntrato.Controls.Add(this.label37);
            this.gbPeriodoCOntrato.Controls.Add(this.cboTipoPago);
            this.gbPeriodoCOntrato.Controls.Add(this.label29);
            this.gbPeriodoCOntrato.Controls.Add(this.txtNumero);
            this.gbPeriodoCOntrato.Location = new System.Drawing.Point(12, 64);
            this.gbPeriodoCOntrato.Name = "gbPeriodoCOntrato";
            this.gbPeriodoCOntrato.Size = new System.Drawing.Size(500, 152);
            this.gbPeriodoCOntrato.TabIndex = 26;
            this.gbPeriodoCOntrato.TabStop = false;
            this.gbPeriodoCOntrato.Text = "Condiciones";
            // 
            // nupMontoPago
            // 
            this.nupMontoPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nupMontoPago.DecimalPlaces = 2;
            this.nupMontoPago.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nupMontoPago.Location = new System.Drawing.Point(332, 99);
            this.nupMontoPago.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nupMontoPago.Name = "nupMontoPago";
            this.nupMontoPago.Size = new System.Drawing.Size(162, 20);
            this.nupMontoPago.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Condicion Laboral :";
            // 
            // cboCondicionLaboral
            // 
            this.cboCondicionLaboral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCondicionLaboral.FormattingEnabled = true;
            this.cboCondicionLaboral.Items.AddRange(new object[] {
            "CONTRATADO",
            "NOMBRADO"});
            this.cboCondicionLaboral.Location = new System.Drawing.Point(118, 19);
            this.cboCondicionLaboral.Name = "cboCondicionLaboral";
            this.cboCondicionLaboral.Size = new System.Drawing.Size(159, 21);
            this.cboCondicionLaboral.TabIndex = 1;
            // 
            // chkServidorConfianza
            // 
            this.chkServidorConfianza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkServidorConfianza.AutoSize = true;
            this.chkServidorConfianza.Location = new System.Drawing.Point(364, 21);
            this.chkServidorConfianza.Name = "chkServidorConfianza";
            this.chkServidorConfianza.Size = new System.Drawing.Size(130, 17);
            this.chkServidorConfianza.TabIndex = 3;
            this.chkServidorConfianza.Text = "Servidor de Confianza";
            this.chkServidorConfianza.UseVisualStyleBackColor = true;
            // 
            // txtRUC
            // 
            this.txtRUC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRUC.Location = new System.Drawing.Point(118, 126);
            this.txtRUC.MaxLength = 11;
            this.txtRUC.Name = "txtRUC";
            this.txtRUC.Size = new System.Drawing.Size(376, 20);
            this.txtRUC.TabIndex = 6;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(76, 129);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(36, 13);
            this.label40.TabIndex = 20;
            this.label40.Text = "RUC :";
            // 
            // label39
            // 
            this.label39.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(283, 102);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(43, 13);
            this.label39.TabIndex = 18;
            this.label39.Text = "Monto :";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(41, 75);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(71, 13);
            this.label38.TabIndex = 17;
            this.label38.Text = "Periodicidad :";
            // 
            // cboPeriodicidad
            // 
            this.cboPeriodicidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPeriodicidad.FormattingEnabled = true;
            this.cboPeriodicidad.Items.AddRange(new object[] {
            "QUINCENAL",
            "MENSUAL",
            "TRIMESTRAL",
            "SEMESTRAL",
            "ANUAL"});
            this.cboPeriodicidad.Location = new System.Drawing.Point(118, 72);
            this.cboPeriodicidad.Name = "cboPeriodicidad";
            this.cboPeriodicidad.Size = new System.Drawing.Size(159, 21);
            this.cboPeriodicidad.TabIndex = 3;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(50, 102);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(62, 13);
            this.label37.TabIndex = 80;
            this.label37.Text = "Tipo Pago :";
            // 
            // cboTipoPago
            // 
            this.cboTipoPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipoPago.FormattingEnabled = true;
            this.cboTipoPago.Items.AddRange(new object[] {
            "EFECTIVO",
            "CHEQUE",
            "DEPOSITO"});
            this.cboTipoPago.Location = new System.Drawing.Point(118, 99);
            this.cboTipoPago.Name = "cboTipoPago";
            this.cboTipoPago.Size = new System.Drawing.Size(159, 21);
            this.cboTipoPago.TabIndex = 4;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(4, 49);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(108, 13);
            this.label29.TabIndex = 13;
            this.label29.Text = "Numero Documento :";
            // 
            // txtNumero
            // 
            this.txtNumero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumero.Location = new System.Drawing.Point(118, 46);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(159, 20);
            this.txtNumero.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 81;
            this.label5.Text = "Ocupación :";
            // 
            // cboOcupacion
            // 
            this.cboOcupacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOcupacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOcupacion.FormattingEnabled = true;
            this.cboOcupacion.Location = new System.Drawing.Point(107, 128);
            this.cboOcupacion.Name = "cboOcupacion";
            this.cboOcupacion.Size = new System.Drawing.Size(387, 21);
            this.cboOcupacion.TabIndex = 13;
            this.cboOcupacion.SelectedIndexChanged += new System.EventHandler(this.cboOcupacion_SelectedIndexChanged);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(332, 46);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(162, 20);
            this.dtpFechaFin.TabIndex = 10;
            this.dtpFechaFin.ValueChanged += new System.EventHandler(this.dtpFechaFin_ValueChanged);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(107, 46);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(159, 20);
            this.dtpFechaInicio.TabIndex = 9;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(63, 52);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(38, 13);
            this.label25.TabIndex = 65;
            this.label25.Text = "Inicio :";
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(299, 52);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(27, 13);
            this.label27.TabIndex = 5;
            this.label27.Text = "Fin :";
            // 
            // cboCargo
            // 
            this.cboCargo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCargo.FormattingEnabled = true;
            this.cboCargo.Location = new System.Drawing.Point(107, 155);
            this.cboCargo.Name = "cboCargo";
            this.cboCargo.Size = new System.Drawing.Size(387, 21);
            this.cboCargo.TabIndex = 14;
            this.cboCargo.SelectedIndexChanged += new System.EventHandler(this.cboCargo_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(60, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 50;
            this.label11.Text = "Cargo :";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(64, 185);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(37, 13);
            this.label28.TabIndex = 11;
            this.label28.Text = "Meta :";
            // 
            // cboMeta
            // 
            this.cboMeta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMeta.FormattingEnabled = true;
            this.cboMeta.Location = new System.Drawing.Point(107, 182);
            this.cboMeta.Name = "cboMeta";
            this.cboMeta.Size = new System.Drawing.Size(387, 21);
            this.cboMeta.TabIndex = 15;
            this.cboMeta.SelectedIndexChanged += new System.EventHandler(this.cboMeta_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cboRegimenLaboral);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 46);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Regimen Laboral";
            // 
            // cboRegimenLaboral
            // 
            this.cboRegimenLaboral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRegimenLaboral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegimenLaboral.FormattingEnabled = true;
            this.cboRegimenLaboral.Location = new System.Drawing.Point(6, 19);
            this.cboRegimenLaboral.Name = "cboRegimenLaboral";
            this.cboRegimenLaboral.Size = new System.Drawing.Size(488, 21);
            this.cboRegimenLaboral.TabIndex = 0;
            this.cboRegimenLaboral.SelectedIndexChanged += new System.EventHandler(this.cboRegimenLaboral_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Tipo Contrato:";
            // 
            // cboTipoContrato
            // 
            this.cboTipoContrato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipoContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoContrato.FormattingEnabled = true;
            this.cboTipoContrato.Location = new System.Drawing.Point(107, 72);
            this.cboTipoContrato.Name = "cboTipoContrato";
            this.cboTipoContrato.Size = new System.Drawing.Size(387, 21);
            this.cboTipoContrato.TabIndex = 11;
            this.cboTipoContrato.SelectedIndexChanged += new System.EventHandler(this.cboTipoContrato_SelectedIndexChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.MintCream;
            this.btnCancelar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelar.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnCancelar.Location = new System.Drawing.Point(437, 437);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 65);
            this.btnCancelar.TabIndex = 61;
            this.btnCancelar.Text = "&Cancelar";
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
            this.btnAceptar.Location = new System.Drawing.Point(356, 437);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 65);
            this.btnAceptar.TabIndex = 60;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cboCategoriaOcupacional);
            this.groupBox2.Controls.Add(this.cboOcupacion);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cboTipoTrabajador);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboMeta);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cboTipoContrato);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.dtpFechaFin);
            this.groupBox2.Controls.Add(this.cboCargo);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.dtpFechaInicio);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Location = new System.Drawing.Point(12, 222);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(500, 209);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalles";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 69;
            this.label4.Text = "Cat. Ocupacional :";
            // 
            // cboCategoriaOcupacional
            // 
            this.cboCategoriaOcupacional.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCategoriaOcupacional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoriaOcupacional.FormattingEnabled = true;
            this.cboCategoriaOcupacional.Location = new System.Drawing.Point(107, 101);
            this.cboCategoriaOcupacional.Name = "cboCategoriaOcupacional";
            this.cboCategoriaOcupacional.Size = new System.Drawing.Size(387, 21);
            this.cboCategoriaOcupacional.TabIndex = 12;
            this.cboCategoriaOcupacional.SelectedIndexChanged += new System.EventHandler(this.cboCategoriaOcupacional_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "Tipo Trabajdor :";
            // 
            // cboTipoTrabajador
            // 
            this.cboTipoTrabajador.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipoTrabajador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoTrabajador.FormattingEnabled = true;
            this.cboTipoTrabajador.Location = new System.Drawing.Point(107, 19);
            this.cboTipoTrabajador.Name = "cboTipoTrabajador";
            this.cboTipoTrabajador.Size = new System.Drawing.Size(387, 21);
            this.cboTipoTrabajador.TabIndex = 8;
            this.cboTipoTrabajador.SelectedIndexChanged += new System.EventHandler(this.cboTipoTrabajador_SelectedIndexChanged);
            // 
            // frmRegimenTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 514);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbPeriodoCOntrato);
            this.Name = "frmRegimenTrabajador";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Regimen Trabajador";
            this.Load += new System.EventHandler(this.frmRegimenTrabajador_Load);
            this.gbPeriodoCOntrato.ResumeLayout(false);
            this.gbPeriodoCOntrato.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupMontoPago)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPeriodoCOntrato;
        private System.Windows.Forms.TextBox txtRUC;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.ComboBox cboPeriodicidad;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox cboTipoPago;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.ComboBox cboCargo;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cboMeta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboRegimenLaboral;
        private System.Windows.Forms.CheckBox chkServidorConfianza;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCondicionLaboral;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboTipoContrato;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nupMontoPago;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCategoriaOcupacional;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTipoTrabajador;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboOcupacion;
    }
}