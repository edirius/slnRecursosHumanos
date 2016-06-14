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
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dgvResidenteMeta = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnResidente = new System.Windows.Forms.Button();
            this.cboResidente = new System.Windows.Forms.ComboBox();
            this.IdTResidenteMeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdTMeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Año = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Meta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResidenteMeta)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.MintCream;
            this.btnSalir.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSalir.ImageKey = "ssss.png";
            this.btnSalir.Location = new System.Drawing.Point(497, 382);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(83, 53);
            this.btnSalir.TabIndex = 25;
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
            this.btnEliminar.Location = new System.Drawing.Point(402, 382);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(89, 53);
            this.btnEliminar.TabIndex = 24;
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
            this.btnNuevo.Location = new System.Drawing.Point(313, 382);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(83, 53);
            this.btnNuevo.TabIndex = 22;
            this.btnNuevo.Text = "&Asignar";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dgvResidenteMeta
            // 
            this.dgvResidenteMeta.AllowUserToAddRows = false;
            this.dgvResidenteMeta.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dgvResidenteMeta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResidenteMeta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResidenteMeta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResidenteMeta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdTResidenteMeta,
            this.IdTMeta,
            this.Año,
            this.Meta});
            this.dgvResidenteMeta.Location = new System.Drawing.Point(12, 66);
            this.dgvResidenteMeta.MultiSelect = false;
            this.dgvResidenteMeta.Name = "dgvResidenteMeta";
            this.dgvResidenteMeta.ReadOnly = true;
            this.dgvResidenteMeta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResidenteMeta.Size = new System.Drawing.Size(568, 310);
            this.dgvResidenteMeta.TabIndex = 21;
            this.dgvResidenteMeta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResidenteMeta_CellClick);
            this.dgvResidenteMeta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResidenteMeta_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnResidente);
            this.groupBox2.Controls.Add(this.cboResidente);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(568, 48);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Residente";
            // 
            // btnResidente
            // 
            this.btnResidente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResidente.Font = new System.Drawing.Font("Wide Latin", 9.75F);
            this.btnResidente.Location = new System.Drawing.Point(498, 19);
            this.btnResidente.Name = "btnResidente";
            this.btnResidente.Size = new System.Drawing.Size(64, 23);
            this.btnResidente.TabIndex = 1;
            this.btnResidente.Text = "...";
            this.btnResidente.UseVisualStyleBackColor = true;
            this.btnResidente.Click += new System.EventHandler(this.btnResidente_Click);
            // 
            // cboResidente
            // 
            this.cboResidente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboResidente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboResidente.FormattingEnabled = true;
            this.cboResidente.Location = new System.Drawing.Point(6, 19);
            this.cboResidente.Name = "cboResidente";
            this.cboResidente.Size = new System.Drawing.Size(486, 21);
            this.cboResidente.TabIndex = 0;
            this.cboResidente.SelectedIndexChanged += new System.EventHandler(this.cboResidente_SelectedIndexChanged);
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
            this.Año.HeaderText = "Año";
            this.Año.Name = "Año";
            this.Año.ReadOnly = true;
            // 
            // Meta
            // 
            this.Meta.HeaderText = "Meta";
            this.Meta.Name = "Meta";
            this.Meta.ReadOnly = true;
            this.Meta.Width = 400;
            // 
            // frmMantenimientoResidenteMeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 447);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dgvResidenteMeta);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmMantenimientoResidenteMeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Residente Meta";
            this.Load += new System.EventHandler(this.frmMantenimientoResidenteMeta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResidenteMeta)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvResidenteMeta;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnResidente;
        private System.Windows.Forms.ComboBox cboResidente;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTResidenteMeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTMeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Año;
        private System.Windows.Forms.DataGridViewTextBoxColumn Meta;
    }
}