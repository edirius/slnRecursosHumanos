namespace CapaUsuario.Reportes
{
    partial class frmBoletaPagoxTrabajador
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgBoletasPago = new System.Windows.Forms.DataGridView();
            this.IDPLANILLA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Año = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Planilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plantilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalIngresos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiasLaborados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtdetallePlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAEmpleador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalATrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalNetoACobrar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtMeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtFuenteFinanciamiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtRegimenLaboral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalDescuentos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detallePlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtTrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Meta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.btnImprimirBoleta = new System.Windows.Forms.Button();
            this.btnBoletaXAnio = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdnDosBoletas = new System.Windows.Forms.RadioButton();
            this.rdnBoletaDuplicada = new System.Windows.Forms.RadioButton();
            this.rdnUnaBoleta = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.numTamañoLetra = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBoletasPago)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTamañoLetra)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboAño);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtDNI);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(900, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 94;
            this.label2.Text = "Año:";
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(257, 22);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(140, 21);
            this.cboAño.TabIndex = 93;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.MintCream;
            this.btnBuscar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnBuscar.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnBuscar.Location = new System.Drawing.Point(424, 18);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(89, 30);
            this.btnBuscar.TabIndex = 92;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(106, 23);
            this.txtDNI.MaxLength = 8;
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(100, 20);
            this.txtDNI.TabIndex = 1;
            this.txtDNI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar por DNI:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgBoletasPago);
            this.groupBox2.Location = new System.Drawing.Point(9, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(900, 288);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dtgBoletasPago
            // 
            this.dtgBoletasPago.AllowUserToAddRows = false;
            this.dtgBoletasPago.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Lavender;
            this.dtgBoletasPago.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgBoletasPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBoletasPago.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDPLANILLA,
            this.Mes,
            this.Año,
            this.Cargo,
            this.Numero,
            this.Planilla,
            this.Plantilla,
            this.TotalIngresos,
            this.DiasLaborados,
            this.idtdetallePlanilla,
            this.TotalAEmpleador,
            this.TotalATrabajador,
            this.TotalNetoACobrar,
            this.idtMeta,
            this.idtFuenteFinanciamiento,
            this.idtRegimenLaboral,
            this.TotalDescuentos,
            this.fechaInicio,
            this.fecha,
            this.Observaciones,
            this.oPlanilla,
            this.detallePlanilla,
            this.idtTrabajador,
            this.Meta,
            this.Trabajador});
            this.dtgBoletasPago.Location = new System.Drawing.Point(6, 19);
            this.dtgBoletasPago.Name = "dtgBoletasPago";
            this.dtgBoletasPago.ReadOnly = true;
            this.dtgBoletasPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBoletasPago.Size = new System.Drawing.Size(888, 257);
            this.dtgBoletasPago.TabIndex = 0;
            // 
            // IDPLANILLA
            // 
            this.IDPLANILLA.DataPropertyName = "idtPlanilla";
            this.IDPLANILLA.HeaderText = "IDPLANILLA";
            this.IDPLANILLA.Name = "IDPLANILLA";
            this.IDPLANILLA.ReadOnly = true;
            this.IDPLANILLA.Visible = false;
            // 
            // Mes
            // 
            this.Mes.DataPropertyName = "Mes";
            this.Mes.HeaderText = "Mes";
            this.Mes.Name = "Mes";
            this.Mes.ReadOnly = true;
            this.Mes.Width = 90;
            // 
            // Año
            // 
            this.Año.DataPropertyName = "Año";
            this.Año.HeaderText = "Año";
            this.Año.Name = "Año";
            this.Año.ReadOnly = true;
            this.Año.Width = 50;
            // 
            // Cargo
            // 
            this.Cargo.DataPropertyName = "Cargo";
            this.Cargo.HeaderText = "Cargo";
            this.Cargo.Name = "Cargo";
            this.Cargo.ReadOnly = true;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            this.Numero.HeaderText = "Nro Planilla";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 40;
            // 
            // Planilla
            // 
            this.Planilla.DataPropertyName = "Descripcion";
            this.Planilla.HeaderText = "Planilla";
            this.Planilla.Name = "Planilla";
            this.Planilla.ReadOnly = true;
            this.Planilla.Width = 200;
            // 
            // Plantilla
            // 
            this.Plantilla.DataPropertyName = "Plantilla";
            this.Plantilla.HeaderText = "Plantilla";
            this.Plantilla.Name = "Plantilla";
            this.Plantilla.ReadOnly = true;
            // 
            // TotalIngresos
            // 
            this.TotalIngresos.DataPropertyName = "TotalIngresos";
            this.TotalIngresos.HeaderText = "Total Ingresos";
            this.TotalIngresos.Name = "TotalIngresos";
            this.TotalIngresos.ReadOnly = true;
            this.TotalIngresos.Width = 80;
            // 
            // DiasLaborados
            // 
            this.DiasLaborados.DataPropertyName = "DiasLaborados";
            this.DiasLaborados.HeaderText = "Dias Laborados";
            this.DiasLaborados.Name = "DiasLaborados";
            this.DiasLaborados.ReadOnly = true;
            this.DiasLaborados.Width = 50;
            // 
            // idtdetallePlanilla
            // 
            this.idtdetallePlanilla.DataPropertyName = "idtDetallePlanilla";
            this.idtdetallePlanilla.HeaderText = "idtDetallePlanilla";
            this.idtdetallePlanilla.Name = "idtdetallePlanilla";
            this.idtdetallePlanilla.ReadOnly = true;
            this.idtdetallePlanilla.Visible = false;
            // 
            // TotalAEmpleador
            // 
            this.TotalAEmpleador.DataPropertyName = "TotalAEmpleador";
            this.TotalAEmpleador.HeaderText = "TotalAEmpleador";
            this.TotalAEmpleador.Name = "TotalAEmpleador";
            this.TotalAEmpleador.ReadOnly = true;
            this.TotalAEmpleador.Visible = false;
            // 
            // TotalATrabajador
            // 
            this.TotalATrabajador.DataPropertyName = "TotalATrabajador";
            this.TotalATrabajador.HeaderText = "TotalATRabajador";
            this.TotalATrabajador.Name = "TotalATrabajador";
            this.TotalATrabajador.ReadOnly = true;
            this.TotalATrabajador.Visible = false;
            // 
            // TotalNetoACobrar
            // 
            this.TotalNetoACobrar.DataPropertyName = "NetoACobrar";
            this.TotalNetoACobrar.HeaderText = "TotalNetoACobrar";
            this.TotalNetoACobrar.Name = "TotalNetoACobrar";
            this.TotalNetoACobrar.ReadOnly = true;
            this.TotalNetoACobrar.Visible = false;
            // 
            // idtMeta
            // 
            this.idtMeta.DataPropertyName = "idtMeta";
            this.idtMeta.HeaderText = "idtMeta";
            this.idtMeta.Name = "idtMeta";
            this.idtMeta.ReadOnly = true;
            this.idtMeta.Visible = false;
            // 
            // idtFuenteFinanciamiento
            // 
            this.idtFuenteFinanciamiento.DataPropertyName = "idtFuenteFinanciamiento";
            this.idtFuenteFinanciamiento.HeaderText = "idtFuenteFinanciamiento";
            this.idtFuenteFinanciamiento.Name = "idtFuenteFinanciamiento";
            this.idtFuenteFinanciamiento.ReadOnly = true;
            this.idtFuenteFinanciamiento.Visible = false;
            // 
            // idtRegimenLaboral
            // 
            this.idtRegimenLaboral.DataPropertyName = "idtRegimenLaboral";
            this.idtRegimenLaboral.HeaderText = "idtRegimenLaboral";
            this.idtRegimenLaboral.Name = "idtRegimenLaboral";
            this.idtRegimenLaboral.ReadOnly = true;
            this.idtRegimenLaboral.Visible = false;
            // 
            // TotalDescuentos
            // 
            this.TotalDescuentos.DataPropertyName = "TotalDescuentos";
            this.TotalDescuentos.HeaderText = "TotalDescuentos";
            this.TotalDescuentos.Name = "TotalDescuentos";
            this.TotalDescuentos.ReadOnly = true;
            this.TotalDescuentos.Visible = false;
            // 
            // fechaInicio
            // 
            this.fechaInicio.DataPropertyName = "FechaInicio";
            this.fechaInicio.HeaderText = "fechaInicio";
            this.fechaInicio.Name = "fechaInicio";
            this.fechaInicio.ReadOnly = true;
            this.fechaInicio.Visible = false;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "Fecha";
            this.fecha.HeaderText = "fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Visible = false;
            // 
            // Observaciones
            // 
            this.Observaciones.DataPropertyName = "Observaciones";
            this.Observaciones.HeaderText = "Observaciones";
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.ReadOnly = true;
            this.Observaciones.Visible = false;
            // 
            // oPlanilla
            // 
            this.oPlanilla.DataPropertyName = "Planilla";
            this.oPlanilla.HeaderText = "Planilla";
            this.oPlanilla.Name = "oPlanilla";
            this.oPlanilla.ReadOnly = true;
            this.oPlanilla.Visible = false;
            // 
            // detallePlanilla
            // 
            this.detallePlanilla.DataPropertyName = "DetallePlanilla";
            this.detallePlanilla.HeaderText = "detallePlanilla";
            this.detallePlanilla.Name = "detallePlanilla";
            this.detallePlanilla.ReadOnly = true;
            this.detallePlanilla.Visible = false;
            // 
            // idtTrabajador
            // 
            this.idtTrabajador.DataPropertyName = "IdtTrabajador";
            this.idtTrabajador.HeaderText = "idtTrabajador";
            this.idtTrabajador.Name = "idtTrabajador";
            this.idtTrabajador.ReadOnly = true;
            this.idtTrabajador.Visible = false;
            // 
            // Meta
            // 
            this.Meta.DataPropertyName = "Meta";
            this.Meta.HeaderText = "Meta";
            this.Meta.Name = "Meta";
            this.Meta.ReadOnly = true;
            this.Meta.Visible = false;
            // 
            // Trabajador
            // 
            this.Trabajador.DataPropertyName = "Trabajador";
            this.Trabajador.HeaderText = "Trabajador";
            this.Trabajador.Name = "Trabajador";
            this.Trabajador.ReadOnly = true;
            this.Trabajador.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.MintCream;
            this.button1.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.ImageKey = "NetByte Design Studio - 0849.png";
            this.button1.Location = new System.Drawing.Point(820, 361);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 57);
            this.button1.TabIndex = 93;
            this.button1.Text = "&Salir";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnImprimirBoleta
            // 
            this.btnImprimirBoleta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimirBoleta.BackColor = System.Drawing.Color.MintCream;
            this.btnImprimirBoleta.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnImprimirBoleta.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnImprimirBoleta.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnImprimirBoleta.Location = new System.Drawing.Point(9, 361);
            this.btnImprimirBoleta.Name = "btnImprimirBoleta";
            this.btnImprimirBoleta.Size = new System.Drawing.Size(89, 57);
            this.btnImprimirBoleta.TabIndex = 94;
            this.btnImprimirBoleta.Text = "&Imprimir Boleta 3er Formato";
            this.btnImprimirBoleta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImprimirBoleta.UseVisualStyleBackColor = false;
            this.btnImprimirBoleta.Click += new System.EventHandler(this.btnImprimirBoleta_Click);
            // 
            // btnBoletaXAnio
            // 
            this.btnBoletaXAnio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBoletaXAnio.BackColor = System.Drawing.Color.MintCream;
            this.btnBoletaXAnio.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnBoletaXAnio.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnBoletaXAnio.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnBoletaXAnio.Location = new System.Drawing.Point(126, 361);
            this.btnBoletaXAnio.Name = "btnBoletaXAnio";
            this.btnBoletaXAnio.Size = new System.Drawing.Size(89, 57);
            this.btnBoletaXAnio.TabIndex = 95;
            this.btnBoletaXAnio.Text = "&Imprimir Boletas x Año";
            this.btnBoletaXAnio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBoletaXAnio.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdnDosBoletas);
            this.groupBox3.Controls.Add(this.rdnBoletaDuplicada);
            this.groupBox3.Controls.Add(this.rdnUnaBoleta);
            this.groupBox3.Location = new System.Drawing.Point(237, 362);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(415, 60);
            this.groupBox3.TabIndex = 96;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Opciones";
            // 
            // rdnDosBoletas
            // 
            this.rdnDosBoletas.AutoSize = true;
            this.rdnDosBoletas.Location = new System.Drawing.Point(237, 20);
            this.rdnDosBoletas.Name = "rdnDosBoletas";
            this.rdnDosBoletas.Size = new System.Drawing.Size(113, 17);
            this.rdnDosBoletas.TabIndex = 2;
            this.rdnDosBoletas.Text = "2 Boletas x Pagina";
            this.rdnDosBoletas.UseVisualStyleBackColor = true;
            // 
            // rdnBoletaDuplicada
            // 
            this.rdnBoletaDuplicada.AutoSize = true;
            this.rdnBoletaDuplicada.Location = new System.Drawing.Point(125, 20);
            this.rdnBoletaDuplicada.Name = "rdnBoletaDuplicada";
            this.rdnBoletaDuplicada.Size = new System.Drawing.Size(106, 17);
            this.rdnBoletaDuplicada.TabIndex = 1;
            this.rdnBoletaDuplicada.Text = "Boleta Duplicada";
            this.rdnBoletaDuplicada.UseVisualStyleBackColor = true;
            // 
            // rdnUnaBoleta
            // 
            this.rdnUnaBoleta.AutoSize = true;
            this.rdnUnaBoleta.Checked = true;
            this.rdnUnaBoleta.Location = new System.Drawing.Point(18, 20);
            this.rdnUnaBoleta.Name = "rdnUnaBoleta";
            this.rdnUnaBoleta.Size = new System.Drawing.Size(108, 17);
            this.rdnUnaBoleta.TabIndex = 0;
            this.rdnUnaBoleta.TabStop = true;
            this.rdnUnaBoleta.Text = "1 Boleta x Pagina";
            this.rdnUnaBoleta.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(658, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 97;
            this.label3.Text = "Tamaño Letra:";
            // 
            // numTamañoLetra
            // 
            this.numTamañoLetra.Location = new System.Drawing.Point(740, 398);
            this.numTamañoLetra.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numTamañoLetra.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numTamañoLetra.Name = "numTamañoLetra";
            this.numTamañoLetra.Size = new System.Drawing.Size(46, 20);
            this.numTamañoLetra.TabIndex = 98;
            this.numTamañoLetra.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // frmBoletaPagoxTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 434);
            this.Controls.Add(this.numTamañoLetra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnBoletaXAnio);
            this.Controls.Add(this.btnImprimirBoleta);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBoletaPagoxTrabajador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Boleta de pago por trabajador";
            this.Load += new System.EventHandler(this.frmBoletaPagoxTrabajador_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBoletasPago)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTamañoLetra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgBoletasPago;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.Button btnImprimirBoleta;
        private System.Windows.Forms.Button btnBoletaXAnio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdnDosBoletas;
        private System.Windows.Forms.RadioButton rdnBoletaDuplicada;
        private System.Windows.Forms.RadioButton rdnUnaBoleta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPLANILLA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Año;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Planilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plantilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalIngresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiasLaborados;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtdetallePlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAEmpleador;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalATrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalNetoACobrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtMeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtFuenteFinanciamiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtRegimenLaboral;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalDescuentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn oPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn detallePlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtTrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Meta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trabajador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numTamañoLetra;
    }
}