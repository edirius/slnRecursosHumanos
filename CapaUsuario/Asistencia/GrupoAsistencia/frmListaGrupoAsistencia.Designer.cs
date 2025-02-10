namespace CapaUsuario.Asistencia.GrupoAsistencia
{
    partial class frmListaGrupoAsistencia
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
            this.dtgListaGrupos = new System.Windows.Forms.DataGridView();
            this.btnEliminarGrupo = new System.Windows.Forms.Button();
            this.btnModificarGrupo = new System.Windows.Forms.Button();
            this.btnNuevoGrupo = new System.Windows.Forms.Button();
            this.btnVerDetalles = new System.Windows.Forms.Button();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHabilitado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaGrupos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListaGrupos
            // 
            this.dtgListaGrupos.AllowUserToAddRows = false;
            this.dtgListaGrupos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dtgListaGrupos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaGrupos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colDescripcion,
            this.colHabilitado});
            this.dtgListaGrupos.Location = new System.Drawing.Point(21, 21);
            this.dtgListaGrupos.MultiSelect = false;
            this.dtgListaGrupos.Name = "dtgListaGrupos";
            this.dtgListaGrupos.ReadOnly = true;
            this.dtgListaGrupos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaGrupos.Size = new System.Drawing.Size(535, 182);
            this.dtgListaGrupos.TabIndex = 0;
            // 
            // btnEliminarGrupo
            // 
            this.btnEliminarGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarGrupo.BackColor = System.Drawing.Color.MintCream;
            this.btnEliminarGrupo.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarGrupo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEliminarGrupo.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnEliminarGrupo.Location = new System.Drawing.Point(192, 227);
            this.btnEliminarGrupo.Name = "btnEliminarGrupo";
            this.btnEliminarGrupo.Size = new System.Drawing.Size(79, 65);
            this.btnEliminarGrupo.TabIndex = 86;
            this.btnEliminarGrupo.Text = "&Eliminar Grupo";
            this.btnEliminarGrupo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminarGrupo.UseVisualStyleBackColor = false;
            this.btnEliminarGrupo.Click += new System.EventHandler(this.btnEliminarGrupo_Click);
            // 
            // btnModificarGrupo
            // 
            this.btnModificarGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificarGrupo.BackColor = System.Drawing.Color.MintCream;
            this.btnModificarGrupo.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificarGrupo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnModificarGrupo.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnModificarGrupo.Location = new System.Drawing.Point(102, 227);
            this.btnModificarGrupo.Name = "btnModificarGrupo";
            this.btnModificarGrupo.Size = new System.Drawing.Size(79, 65);
            this.btnModificarGrupo.TabIndex = 85;
            this.btnModificarGrupo.Text = "&Modificar Grupo";
            this.btnModificarGrupo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModificarGrupo.UseVisualStyleBackColor = false;
            this.btnModificarGrupo.Click += new System.EventHandler(this.btnModificarGrupo_Click);
            // 
            // btnNuevoGrupo
            // 
            this.btnNuevoGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoGrupo.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevoGrupo.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevoGrupo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevoGrupo.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnNuevoGrupo.Location = new System.Drawing.Point(21, 227);
            this.btnNuevoGrupo.Name = "btnNuevoGrupo";
            this.btnNuevoGrupo.Size = new System.Drawing.Size(75, 65);
            this.btnNuevoGrupo.TabIndex = 84;
            this.btnNuevoGrupo.Text = "&Nuevo Grupo";
            this.btnNuevoGrupo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevoGrupo.UseVisualStyleBackColor = false;
            this.btnNuevoGrupo.Click += new System.EventHandler(this.btnNuevoGrupo_Click);
            // 
            // btnVerDetalles
            // 
            this.btnVerDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerDetalles.BackColor = System.Drawing.Color.MintCream;
            this.btnVerDetalles.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnVerDetalles.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnVerDetalles.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnVerDetalles.Location = new System.Drawing.Point(376, 227);
            this.btnVerDetalles.Name = "btnVerDetalles";
            this.btnVerDetalles.Size = new System.Drawing.Size(95, 65);
            this.btnVerDetalles.TabIndex = 91;
            this.btnVerDetalles.Text = "&Ver Detalles";
            this.btnVerDetalles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVerDetalles.UseVisualStyleBackColor = false;
            this.btnVerDetalles.Click += new System.EventHandler(this.btnVerDetalles_Click);
            // 
            // colID
            // 
            this.colID.DataPropertyName = "idtgrupoasistencia";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 50;
            // 
            // colDescripcion
            // 
            this.colDescripcion.DataPropertyName = "descripcion";
            this.colDescripcion.HeaderText = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 300;
            // 
            // colHabilitado
            // 
            this.colHabilitado.DataPropertyName = "habilitado";
            this.colHabilitado.HeaderText = "Habilitado";
            this.colHabilitado.Name = "colHabilitado";
            this.colHabilitado.ReadOnly = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.MintCream;
            this.btnSalir.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSalir.Image = global::CapaUsuario.Properties.Resources.exit_32x32;
            this.btnSalir.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnSalir.Location = new System.Drawing.Point(477, 227);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(79, 65);
            this.btnSalir.TabIndex = 92;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // frmListaGrupoAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 304);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnVerDetalles);
            this.Controls.Add(this.btnEliminarGrupo);
            this.Controls.Add(this.btnModificarGrupo);
            this.Controls.Add(this.btnNuevoGrupo);
            this.Controls.Add(this.dtgListaGrupos);
            this.Name = "frmListaGrupoAsistencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Grupo Asistencia";
            this.Load += new System.EventHandler(this.frmListaGrupoAsistencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaGrupos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgListaGrupos;
        private System.Windows.Forms.Button btnEliminarGrupo;
        private System.Windows.Forms.Button btnModificarGrupo;
        private System.Windows.Forms.Button btnNuevoGrupo;
        private System.Windows.Forms.Button btnVerDetalles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colHabilitado;
        private System.Windows.Forms.Button btnSalir;
    }
}