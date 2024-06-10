namespace CapaUsuario.ResidenteMeta
{
    partial class frmMantenimientoResidenteMeta
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnDesasignar = new System.Windows.Forms.Button();
            this.chkMostrarTodasLasMetas = new System.Windows.Forms.CheckBox();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.btnSalir2 = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgResidenteMeta = new System.Windows.Forms.DataGridView();
            this.colidtresidentemeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMitrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMimeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cboAños = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dgvResidenteMeta = new System.Windows.Forms.DataGridView();
            this.IdTResidenteMeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdTMeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Año = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Meta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTrabajador = new System.Windows.Forms.TextBox();
            this.btnResidente = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResidenteMeta)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResidenteMeta)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(722, 501);
            this.tabControl1.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnDesasignar);
            this.tabPage1.Controls.Add(this.chkMostrarTodasLasMetas);
            this.tabPage1.Controls.Add(this.btnAsignar);
            this.tabPage1.Controls.Add(this.btnSalir2);
            this.tabPage1.Controls.Add(this.btnExportarExcel);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cboAños);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(714, 475);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Metas Asignadas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnDesasignar
            // 
            this.btnDesasignar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesasignar.BackColor = System.Drawing.Color.MintCream;
            this.btnDesasignar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnDesasignar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDesasignar.Image = global::CapaUsuario.Properties.Resources.user_cardx;
            this.btnDesasignar.Location = new System.Drawing.Point(472, 409);
            this.btnDesasignar.Name = "btnDesasignar";
            this.btnDesasignar.Size = new System.Drawing.Size(120, 53);
            this.btnDesasignar.TabIndex = 45;
            this.btnDesasignar.Text = "&Desasignar";
            this.btnDesasignar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDesasignar.UseVisualStyleBackColor = false;
            this.btnDesasignar.Click += new System.EventHandler(this.btnDesasignar_Click);
            // 
            // chkMostrarTodasLasMetas
            // 
            this.chkMostrarTodasLasMetas.AutoSize = true;
            this.chkMostrarTodasLasMetas.Checked = true;
            this.chkMostrarTodasLasMetas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMostrarTodasLasMetas.Location = new System.Drawing.Point(474, 22);
            this.chkMostrarTodasLasMetas.Name = "chkMostrarTodasLasMetas";
            this.chkMostrarTodasLasMetas.Size = new System.Drawing.Size(137, 17);
            this.chkMostrarTodasLasMetas.TabIndex = 44;
            this.chkMostrarTodasLasMetas.Text = "Mostrar todas las metas";
            this.chkMostrarTodasLasMetas.UseVisualStyleBackColor = true;
            this.chkMostrarTodasLasMetas.CheckedChanged += new System.EventHandler(this.chkMostrarTodasLasMetas_CheckedChanged);
            // 
            // btnAsignar
            // 
            this.btnAsignar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignar.BackColor = System.Drawing.Color.MintCream;
            this.btnAsignar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnAsignar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAsignar.Image = global::CapaUsuario.Properties.Resources.user_card1;
            this.btnAsignar.Location = new System.Drawing.Point(342, 409);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(124, 53);
            this.btnAsignar.TabIndex = 43;
            this.btnAsignar.Text = "&Asignar";
            this.btnAsignar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAsignar.UseVisualStyleBackColor = false;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnSalir2
            // 
            this.btnSalir2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir2.BackColor = System.Drawing.Color.MintCream;
            this.btnSalir2.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalir2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSalir2.Image = global::CapaUsuario.Properties.Resources.exit_32x32;
            this.btnSalir2.Location = new System.Drawing.Point(615, 409);
            this.btnSalir2.Name = "btnSalir2";
            this.btnSalir2.Size = new System.Drawing.Size(93, 53);
            this.btnSalir2.TabIndex = 42;
            this.btnSalir2.Text = "&Salir";
            this.btnSalir2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir2.UseVisualStyleBackColor = false;
            this.btnSalir2.Click += new System.EventHandler(this.btnSalir2_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.BackColor = System.Drawing.Color.MintCream;
            this.btnExportarExcel.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportarExcel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnExportarExcel.Image = global::CapaUsuario.Properties.Resources.excel_001;
            this.btnExportarExcel.Location = new System.Drawing.Point(228, 409);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(108, 53);
            this.btnExportarExcel.TabIndex = 27;
            this.btnExportarExcel.Text = "&Exportar";
            this.btnExportarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgResidenteMeta);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(6, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(702, 362);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Metas Asignadas";
            // 
            // dtgResidenteMeta
            // 
            this.dtgResidenteMeta.AllowUserToAddRows = false;
            this.dtgResidenteMeta.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtgResidenteMeta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgResidenteMeta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgResidenteMeta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colidtresidentemeta,
            this.colMitrabajador,
            this.colMimeta,
            this.colMeta,
            this.colTrabajador});
            this.dtgResidenteMeta.Location = new System.Drawing.Point(21, 19);
            this.dtgResidenteMeta.Name = "dtgResidenteMeta";
            this.dtgResidenteMeta.ReadOnly = true;
            this.dtgResidenteMeta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgResidenteMeta.Size = new System.Drawing.Size(669, 330);
            this.dtgResidenteMeta.TabIndex = 3;
            this.dtgResidenteMeta.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgResidenteMeta_CellFormatting);
            // 
            // colidtresidentemeta
            // 
            this.colidtresidentemeta.DataPropertyName = "idtresidentemeta";
            this.colidtresidentemeta.HeaderText = "idtresidentemeta";
            this.colidtresidentemeta.Name = "colidtresidentemeta";
            this.colidtresidentemeta.ReadOnly = true;
            this.colidtresidentemeta.Visible = false;
            // 
            // colMitrabajador
            // 
            this.colMitrabajador.DataPropertyName = "mitrabajador";
            this.colMitrabajador.HeaderText = "miTrabajador";
            this.colMitrabajador.Name = "colMitrabajador";
            this.colMitrabajador.ReadOnly = true;
            this.colMitrabajador.Visible = false;
            // 
            // colMimeta
            // 
            this.colMimeta.DataPropertyName = "mimeta";
            this.colMimeta.HeaderText = "miMeta";
            this.colMimeta.Name = "colMimeta";
            this.colMimeta.ReadOnly = true;
            this.colMimeta.Visible = false;
            // 
            // colMeta
            // 
            this.colMeta.DataPropertyName = "meta";
            this.colMeta.HeaderText = "Meta";
            this.colMeta.Name = "colMeta";
            this.colMeta.ReadOnly = true;
            this.colMeta.Width = 300;
            // 
            // colTrabajador
            // 
            this.colTrabajador.DataPropertyName = "Trabajador";
            this.colTrabajador.HeaderText = "Asignado a:";
            this.colTrabajador.Name = "colTrabajador";
            this.colTrabajador.ReadOnly = true;
            this.colTrabajador.Width = 300;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Años:";
            // 
            // cboAños
            // 
            this.cboAños.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAños.FormattingEnabled = true;
            this.cboAños.Location = new System.Drawing.Point(52, 14);
            this.cboAños.Name = "cboAños";
            this.cboAños.Size = new System.Drawing.Size(121, 21);
            this.cboAños.TabIndex = 0;
            this.cboAños.SelectedIndexChanged += new System.EventHandler(this.cboAños_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSalir);
            this.tabPage2.Controls.Add(this.btnEliminar);
            this.tabPage2.Controls.Add(this.btnNuevo);
            this.tabPage2.Controls.Add(this.dgvResidenteMeta);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(714, 475);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Asignar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.MintCream;
            this.btnSalir.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSalir.ImageKey = "ssss.png";
            this.btnSalir.Location = new System.Drawing.Point(618, 403);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(83, 53);
            this.btnSalir.TabIndex = 28;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.MintCream;
            this.btnEliminar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEliminar.ImageKey = "118.png";
            this.btnEliminar.Location = new System.Drawing.Point(523, 403);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(89, 53);
            this.btnEliminar.TabIndex = 27;
            this.btnEliminar.Text = "&Desasignar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevo.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevo.ImageIndex = 1;
            this.btnNuevo.Location = new System.Drawing.Point(434, 403);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(83, 53);
            this.btnNuevo.TabIndex = 26;
            this.btnNuevo.Text = "&Asignar";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dgvResidenteMeta
            // 
            this.dgvResidenteMeta.AllowUserToAddRows = false;
            this.dgvResidenteMeta.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dgvResidenteMeta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResidenteMeta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResidenteMeta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResidenteMeta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResidenteMeta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdTResidenteMeta,
            this.IdTMeta,
            this.Año,
            this.Meta});
            this.dgvResidenteMeta.Location = new System.Drawing.Point(12, 50);
            this.dgvResidenteMeta.MultiSelect = false;
            this.dgvResidenteMeta.Name = "dgvResidenteMeta";
            this.dgvResidenteMeta.ReadOnly = true;
            this.dgvResidenteMeta.RowHeadersVisible = false;
            this.dgvResidenteMeta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResidenteMeta.Size = new System.Drawing.Size(696, 336);
            this.dgvResidenteMeta.TabIndex = 22;
            this.dgvResidenteMeta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResidenteMeta_CellClick);
            this.dgvResidenteMeta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResidenteMeta_CellContentClick);
            // 
            // IdTResidenteMeta
            // 
            this.IdTResidenteMeta.HeaderText = "IdResidenteMeta";
            this.IdTResidenteMeta.Name = "IdTResidenteMeta";
            this.IdTResidenteMeta.ReadOnly = true;
            this.IdTResidenteMeta.Visible = false;
            // 
            // IdTMeta
            // 
            this.IdTMeta.HeaderText = "IdMeta";
            this.IdTMeta.Name = "IdTMeta";
            this.IdTMeta.ReadOnly = true;
            this.IdTMeta.Visible = false;
            // 
            // Año
            // 
            this.Año.FillWeight = 50.76142F;
            this.Año.HeaderText = "Año";
            this.Año.Name = "Año";
            this.Año.ReadOnly = true;
            // 
            // Meta
            // 
            this.Meta.FillWeight = 149.2386F;
            this.Meta.HeaderText = "Meta";
            this.Meta.Name = "Meta";
            this.Meta.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtTrabajador);
            this.groupBox2.Controls.Add(this.btnResidente);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(702, 48);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Residente";
            // 
            // txtTrabajador
            // 
            this.txtTrabajador.Enabled = false;
            this.txtTrabajador.Location = new System.Drawing.Point(6, 19);
            this.txtTrabajador.Name = "txtTrabajador";
            this.txtTrabajador.Size = new System.Drawing.Size(486, 20);
            this.txtTrabajador.TabIndex = 2;
            // 
            // btnResidente
            // 
            this.btnResidente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResidente.Font = new System.Drawing.Font("Adobe Gothic Std B", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResidente.Location = new System.Drawing.Point(632, 16);
            this.btnResidente.Name = "btnResidente";
            this.btnResidente.Size = new System.Drawing.Size(64, 23);
            this.btnResidente.TabIndex = 1;
            this.btnResidente.Text = "Buscar";
            this.btnResidente.UseVisualStyleBackColor = true;
            this.btnResidente.Click += new System.EventHandler(this.btnResidente_Click);
            // 
            // frmMantenimientoResidenteMeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 527);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmMantenimientoResidenteMeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Residente Meta";
            this.Load += new System.EventHandler(this.frmMantenimientoResidenteMeta_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgResidenteMeta)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResidenteMeta)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAños;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvResidenteMeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTResidenteMeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTMeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Año;
        private System.Windows.Forms.DataGridViewTextBoxColumn Meta;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTrabajador;
        private System.Windows.Forms.Button btnResidente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgResidenteMeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colidtresidentemeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMitrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMimeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrabajador;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Button btnSalir2;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.CheckBox chkMostrarTodasLasMetas;
        private System.Windows.Forms.Button btnDesasignar;
    }
}