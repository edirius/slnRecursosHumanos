namespace CapaUsuario.Contrato
{
    partial class frmContrato
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
            this.btnNumeracion = new System.Windows.Forms.Button();
            this.btnPlantillaContrato = new System.Windows.Forms.Button();
            this.cboPlantillaContrato = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboMeta = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.nupMontoPago = new System.Windows.Forms.NumericUpDown();
            this.cboCargo = new System.Windows.Forms.ComboBox();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label27 = new System.Windows.Forms.Label();
            this.txtRUC = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label39 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtNumeroContrato = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.dtpFechaRegistro = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.gbPeriodoCOntrato.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupMontoPago)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPeriodoCOntrato
            // 
            this.gbPeriodoCOntrato.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPeriodoCOntrato.Controls.Add(this.btnNumeracion);
            this.gbPeriodoCOntrato.Controls.Add(this.btnPlantillaContrato);
            this.gbPeriodoCOntrato.Controls.Add(this.cboPlantillaContrato);
            this.gbPeriodoCOntrato.Controls.Add(this.label2);
            this.gbPeriodoCOntrato.Controls.Add(this.groupBox3);
            this.gbPeriodoCOntrato.Controls.Add(this.label11);
            this.gbPeriodoCOntrato.Controls.Add(this.nupMontoPago);
            this.gbPeriodoCOntrato.Controls.Add(this.cboCargo);
            this.gbPeriodoCOntrato.Controls.Add(this.dtpFechaFin);
            this.gbPeriodoCOntrato.Controls.Add(this.label27);
            this.gbPeriodoCOntrato.Controls.Add(this.txtRUC);
            this.gbPeriodoCOntrato.Controls.Add(this.label25);
            this.gbPeriodoCOntrato.Controls.Add(this.label40);
            this.gbPeriodoCOntrato.Controls.Add(this.dtpFechaInicio);
            this.gbPeriodoCOntrato.Controls.Add(this.label39);
            this.gbPeriodoCOntrato.Controls.Add(this.label29);
            this.gbPeriodoCOntrato.Controls.Add(this.txtNumeroContrato);
            this.gbPeriodoCOntrato.Location = new System.Drawing.Point(12, 38);
            this.gbPeriodoCOntrato.Name = "gbPeriodoCOntrato";
            this.gbPeriodoCOntrato.Size = new System.Drawing.Size(502, 245);
            this.gbPeriodoCOntrato.TabIndex = 26;
            this.gbPeriodoCOntrato.TabStop = false;
            this.gbPeriodoCOntrato.Text = "Condiciones";
            // 
            // btnNumeracion
            // 
            this.btnNumeracion.Location = new System.Drawing.Point(301, 44);
            this.btnNumeracion.Name = "btnNumeracion";
            this.btnNumeracion.Size = new System.Drawing.Size(46, 23);
            this.btnNumeracion.TabIndex = 69;
            this.btnNumeracion.Text = "...";
            this.btnNumeracion.UseVisualStyleBackColor = true;
            this.btnNumeracion.Click += new System.EventHandler(this.btnNumeracion_Click);
            // 
            // btnPlantillaContrato
            // 
            this.btnPlantillaContrato.Location = new System.Drawing.Point(450, 18);
            this.btnPlantillaContrato.Name = "btnPlantillaContrato";
            this.btnPlantillaContrato.Size = new System.Drawing.Size(46, 23);
            this.btnPlantillaContrato.TabIndex = 68;
            this.btnPlantillaContrato.Text = "...";
            this.btnPlantillaContrato.UseVisualStyleBackColor = true;
            this.btnPlantillaContrato.Click += new System.EventHandler(this.btnPlantillaContrato_Click);
            // 
            // cboPlantillaContrato
            // 
            this.cboPlantillaContrato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPlantillaContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlantillaContrato.FormattingEnabled = true;
            this.cboPlantillaContrato.Location = new System.Drawing.Point(118, 19);
            this.cboPlantillaContrato.Name = "cboPlantillaContrato";
            this.cboPlantillaContrato.Size = new System.Drawing.Size(326, 21);
            this.cboPlantillaContrato.TabIndex = 66;
            this.cboPlantillaContrato.SelectedIndexChanged += new System.EventHandler(this.cboPlantillaContrato_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "Plantilla Contrato :";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.cboAño);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cboMeta);
            this.groupBox3.Location = new System.Drawing.Point(6, 177);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(490, 62);
            this.groupBox3.TabIndex = 62;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Meta";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(98, 13);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(69, 13);
            this.label28.TabIndex = 11;
            this.label28.Text = "Descripción :";
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(6, 29);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(89, 21);
            this.cboAño.TabIndex = 82;
            this.cboAño.SelectedIndexChanged += new System.EventHandler(this.cboAño_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 83;
            this.label6.Text = "Año :";
            // 
            // cboMeta
            // 
            this.cboMeta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMeta.FormattingEnabled = true;
            this.cboMeta.Location = new System.Drawing.Point(101, 29);
            this.cboMeta.Name = "cboMeta";
            this.cboMeta.Size = new System.Drawing.Size(383, 21);
            this.cboMeta.TabIndex = 15;
            this.cboMeta.SelectedIndexChanged += new System.EventHandler(this.cboMeta_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(71, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 50;
            this.label11.Text = "Cargo :";
            // 
            // nupMontoPago
            // 
            this.nupMontoPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nupMontoPago.DecimalPlaces = 2;
            this.nupMontoPago.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nupMontoPago.Location = new System.Drawing.Point(118, 98);
            this.nupMontoPago.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nupMontoPago.Name = "nupMontoPago";
            this.nupMontoPago.Size = new System.Drawing.Size(174, 20);
            this.nupMontoPago.TabIndex = 5;
            // 
            // cboCargo
            // 
            this.cboCargo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCargo.FormattingEnabled = true;
            this.cboCargo.Location = new System.Drawing.Point(118, 124);
            this.cboCargo.Name = "cboCargo";
            this.cboCargo.Size = new System.Drawing.Size(378, 21);
            this.cboCargo.TabIndex = 14;
            this.cboCargo.SelectedIndexChanged += new System.EventHandler(this.cboCargo_SelectedIndexChanged);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(331, 72);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(165, 20);
            this.dtpFechaFin.TabIndex = 10;
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(298, 72);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(27, 13);
            this.label27.TabIndex = 5;
            this.label27.Text = "Fin :";
            // 
            // txtRUC
            // 
            this.txtRUC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRUC.Location = new System.Drawing.Point(118, 151);
            this.txtRUC.MaxLength = 11;
            this.txtRUC.Name = "txtRUC";
            this.txtRUC.Size = new System.Drawing.Size(378, 20);
            this.txtRUC.TabIndex = 6;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(74, 72);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(38, 13);
            this.label25.TabIndex = 65;
            this.label25.Text = "Inicio :";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(76, 154);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(36, 13);
            this.label40.TabIndex = 20;
            this.label40.Text = "RUC :";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(118, 72);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(174, 20);
            this.dtpFechaInicio.TabIndex = 9;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(69, 100);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(43, 13);
            this.label39.TabIndex = 18;
            this.label39.Text = "Monto :";
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
            // txtNumeroContrato
            // 
            this.txtNumeroContrato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumeroContrato.Enabled = false;
            this.txtNumeroContrato.Location = new System.Drawing.Point(118, 46);
            this.txtNumeroContrato.Name = "txtNumeroContrato";
            this.txtNumeroContrato.Size = new System.Drawing.Size(174, 20);
            this.txtNumeroContrato.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.MintCream;
            this.btnCancelar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelar.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnCancelar.Location = new System.Drawing.Point(439, 289);
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
            this.btnAceptar.Location = new System.Drawing.Point(358, 289);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 65);
            this.btnAceptar.TabIndex = 60;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dtpFechaRegistro
            // 
            this.dtpFechaRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaRegistro.Location = new System.Drawing.Point(383, 12);
            this.dtpFechaRegistro.Name = "dtpFechaRegistro";
            this.dtpFechaRegistro.Size = new System.Drawing.Size(131, 20);
            this.dtpFechaRegistro.TabIndex = 66;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 69;
            this.label3.Text = "Fecha Registro :";
            // 
            // frmContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 366);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpFechaRegistro);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gbPeriodoCOntrato);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmContrato";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contratos";
            this.Load += new System.EventHandler(this.frmRegimenTrabajador_Load);
            this.gbPeriodoCOntrato.ResumeLayout(false);
            this.gbPeriodoCOntrato.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupMontoPago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPeriodoCOntrato;
        private System.Windows.Forms.TextBox txtRUC;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.ComboBox cboCargo;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtNumeroContrato;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cboMeta;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.NumericUpDown nupMontoPago;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboPlantillaContrato;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaRegistro;
        private System.Windows.Forms.Button btnPlantillaContrato;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNumeracion;
    }
}