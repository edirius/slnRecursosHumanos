﻿namespace CapaDeUsuarioTramite.Tramite
{
    partial class frmTramite
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
            this.cbSede = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvListarTramites = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaHora = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboOperacion = new System.Windows.Forms.ComboBox();
            this.cbOficina = new System.Windows.Forms.ComboBox();
            this.cbTrabajador = new System.Windows.Forms.ComboBox();
            this.cbUnidadDestino = new System.Windows.Forms.ComboBox();
            this.cboUsuarioDestino = new System.Windows.Forms.ComboBox();
            this.cbDocumento = new System.Windows.Forms.ComboBox();
            this.txtProveido = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblnormal = new System.Windows.Forms.Label();
            this.lblmaximizar = new System.Windows.Forms.Label();
            this.lbleliminar = new System.Windows.Forms.Label();
            this.lblminimizar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarTramites)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbSede
            // 
            this.cbSede.FormattingEnabled = true;
            this.cbSede.Location = new System.Drawing.Point(177, 49);
            this.cbSede.Name = "cbSede";
            this.cbSede.Size = new System.Drawing.Size(200, 21);
            this.cbSede.TabIndex = 67;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 65;
            this.label3.Text = "Sede:";
            // 
            // dgvListarTramites
            // 
            this.dgvListarTramites.AllowUserToAddRows = false;
            this.dgvListarTramites.AllowUserToResizeColumns = false;
            this.dgvListarTramites.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListarTramites.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListarTramites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListarTramites.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListarTramites.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvListarTramites.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListarTramites.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListarTramites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListarTramites.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dgvListarTramites.GridColor = System.Drawing.Color.White;
            this.dgvListarTramites.Location = new System.Drawing.Point(18, 216);
            this.dgvListarTramites.Name = "dgvListarTramites";
            this.dgvListarTramites.RowHeadersVisible = false;
            this.dgvListarTramites.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListarTramites.Size = new System.Drawing.Size(1190, 290);
            this.dgvListarTramites.TabIndex = 63;
            this.dgvListarTramites.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListarTramites_CellClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.DataPropertyName = "id_tramite";
            this.Column1.HeaderText = "Codigo";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 65;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.DataPropertyName = "sede";
            this.Column2.HeaderText = "Sede";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 57;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.DataPropertyName = "fecha_hora";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "Fecha/Hora";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 90;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.DataPropertyName = "operacion";
            this.Column4.HeaderText = "Operacion";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 81;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.DataPropertyName = "oficina";
            this.Column5.HeaderText = "Oficina";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 65;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.DataPropertyName = "usuario";
            this.Column6.HeaderText = "Usuario";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 68;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.DataPropertyName = "oficinadestino";
            this.Column7.HeaderText = "Oficina Destino";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 96;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column8.DataPropertyName = "usuariodestino";
            this.Column8.HeaderText = "Usuario Destino";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 98;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "proveido";
            this.Column9.HeaderText = "Proveido";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column10.DataPropertyName = "expediente";
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column10.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column10.HeaderText = "Expediente";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 85;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnSalir, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNuevo, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEliminar, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnModificar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnInsertar, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(231, 509);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 48);
            this.tableLayoutPanel1.TabIndex = 62;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(627, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(118, 42);
            this.btnSalir.TabIndex = 47;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(471, 3);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(116, 42);
            this.btnNuevo.TabIndex = 11;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(315, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(116, 42);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(159, 3);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(116, 42);
            this.btnModificar.TabIndex = 9;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(3, 3);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(116, 42);
            this.btnInsertar.TabIndex = 8;
            this.btnInsertar.Text = "Guardar";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "Fecha/Hora:";
            // 
            // dtpFechaHora
            // 
            this.dtpFechaHora.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHora.Location = new System.Drawing.Point(177, 103);
            this.dtpFechaHora.Name = "dtpFechaHora";
            this.dtpFechaHora.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaHora.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 70;
            this.label2.Text = "Operacion:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(653, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 71;
            this.label4.Text = "Oficina:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(635, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 72;
            this.label5.Text = "Trabajador:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(600, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 73;
            this.label6.Text = "Unidad de destino:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(613, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 74;
            this.label7.Text = "Usuario destino:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(119, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 75;
            this.label8.Text = "Proveido:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(106, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 76;
            this.label9.Text = "Documento:";
            // 
            // cboOperacion
            // 
            this.cboOperacion.FormattingEnabled = true;
            this.cboOperacion.Location = new System.Drawing.Point(177, 129);
            this.cboOperacion.Name = "cboOperacion";
            this.cboOperacion.Size = new System.Drawing.Size(200, 21);
            this.cboOperacion.TabIndex = 77;
            // 
            // cbOficina
            // 
            this.cbOficina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cbOficina.Enabled = false;
            this.cbOficina.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbOficina.FormattingEnabled = true;
            this.cbOficina.Location = new System.Drawing.Point(702, 52);
            this.cbOficina.Name = "cbOficina";
            this.cbOficina.Size = new System.Drawing.Size(292, 21);
            this.cbOficina.TabIndex = 78;
            // 
            // cbTrabajador
            // 
            this.cbTrabajador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cbTrabajador.Enabled = false;
            this.cbTrabajador.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbTrabajador.FormattingEnabled = true;
            this.cbTrabajador.Location = new System.Drawing.Point(702, 79);
            this.cbTrabajador.Name = "cbTrabajador";
            this.cbTrabajador.Size = new System.Drawing.Size(290, 21);
            this.cbTrabajador.TabIndex = 79;
            // 
            // cbUnidadDestino
            // 
            this.cbUnidadDestino.FormattingEnabled = true;
            this.cbUnidadDestino.Location = new System.Drawing.Point(702, 105);
            this.cbUnidadDestino.Name = "cbUnidadDestino";
            this.cbUnidadDestino.Size = new System.Drawing.Size(345, 21);
            this.cbUnidadDestino.TabIndex = 80;
            this.cbUnidadDestino.SelectedIndexChanged += new System.EventHandler(this.cbUnidadDestino_SelectedIndexChanged);
            // 
            // cboUsuarioDestino
            // 
            this.cboUsuarioDestino.FormattingEnabled = true;
            this.cboUsuarioDestino.Location = new System.Drawing.Point(702, 132);
            this.cboUsuarioDestino.Name = "cboUsuarioDestino";
            this.cboUsuarioDestino.Size = new System.Drawing.Size(345, 21);
            this.cboUsuarioDestino.TabIndex = 81;
            // 
            // cbDocumento
            // 
            this.cbDocumento.FormattingEnabled = true;
            this.cbDocumento.Location = new System.Drawing.Point(177, 76);
            this.cbDocumento.Name = "cbDocumento";
            this.cbDocumento.Size = new System.Drawing.Size(234, 21);
            this.cbDocumento.TabIndex = 82;
            // 
            // txtProveido
            // 
            this.txtProveido.Location = new System.Drawing.Point(177, 161);
            this.txtProveido.Multiline = true;
            this.txtProveido.Name = "txtProveido";
            this.txtProveido.Size = new System.Drawing.Size(345, 49);
            this.txtProveido.TabIndex = 83;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.lblnormal);
            this.panel1.Controls.Add(this.lblmaximizar);
            this.panel1.Controls.Add(this.lbleliminar);
            this.panel1.Controls.Add(this.lblminimizar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1232, 27);
            this.panel1.TabIndex = 84;
            // 
            // lblnormal
            // 
            this.lblnormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblnormal.AutoSize = true;
            this.lblnormal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblnormal.ForeColor = System.Drawing.Color.Black;
            this.lblnormal.Location = new System.Drawing.Point(1189, 7);
            this.lblnormal.Name = "lblnormal";
            this.lblnormal.Size = new System.Drawing.Size(19, 13);
            this.lblnormal.TabIndex = 24;
            this.lblnormal.Text = "❐";
            this.lblnormal.Visible = false;
            this.lblnormal.Click += new System.EventHandler(this.lblnormal_Click);
            // 
            // lblmaximizar
            // 
            this.lblmaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblmaximizar.AutoSize = true;
            this.lblmaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblmaximizar.ForeColor = System.Drawing.Color.Black;
            this.lblmaximizar.Location = new System.Drawing.Point(1194, 7);
            this.lblmaximizar.Name = "lblmaximizar";
            this.lblmaximizar.Size = new System.Drawing.Size(14, 13);
            this.lblmaximizar.TabIndex = 23;
            this.lblmaximizar.Text = "□";
            this.lblmaximizar.Click += new System.EventHandler(this.lblmaximizar_Click);
            // 
            // lbleliminar
            // 
            this.lbleliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbleliminar.AutoSize = true;
            this.lbleliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbleliminar.ForeColor = System.Drawing.Color.Black;
            this.lbleliminar.Location = new System.Drawing.Point(1215, 6);
            this.lbleliminar.Name = "lbleliminar";
            this.lbleliminar.Size = new System.Drawing.Size(14, 13);
            this.lbleliminar.TabIndex = 22;
            this.lbleliminar.Text = "X";
            this.lbleliminar.Click += new System.EventHandler(this.lbleliminar_Click);
            // 
            // lblminimizar
            // 
            this.lblminimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblminimizar.AutoSize = true;
            this.lblminimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblminimizar.ForeColor = System.Drawing.Color.Black;
            this.lblminimizar.Location = new System.Drawing.Point(1174, 3);
            this.lblminimizar.Name = "lblminimizar";
            this.lblminimizar.Size = new System.Drawing.Size(13, 13);
            this.lblminimizar.TabIndex = 21;
            this.lblminimizar.Text = "_";
            this.lblminimizar.Click += new System.EventHandler(this.lblminimizar_Click);
            // 
            // frmTramite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 569);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtProveido);
            this.Controls.Add(this.cbDocumento);
            this.Controls.Add(this.cboUsuarioDestino);
            this.Controls.Add(this.cbUnidadDestino);
            this.Controls.Add(this.cbTrabajador);
            this.Controls.Add(this.cbOficina);
            this.Controls.Add(this.cboOperacion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFechaHora);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSede);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvListarTramites);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTramite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTramite";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarTramites)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSede;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvListarTramites;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaHora;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboOperacion;
        private System.Windows.Forms.ComboBox cbOficina;
        private System.Windows.Forms.ComboBox cbTrabajador;
        private System.Windows.Forms.ComboBox cbUnidadDestino;
        private System.Windows.Forms.ComboBox cboUsuarioDestino;
        private System.Windows.Forms.ComboBox cbDocumento;
        private System.Windows.Forms.TextBox txtProveido;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblnormal;
        private System.Windows.Forms.Label lblmaximizar;
        private System.Windows.Forms.Label lbleliminar;
        private System.Windows.Forms.Label lblminimizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    }
}