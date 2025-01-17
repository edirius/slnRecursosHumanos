namespace CapaUsuario.Reloj
{
    partial class frmListaRelojes
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
            this.dtgListaRelojes = new System.Windows.Forms.DataGridView();
            this.btnEliminarReloj = new System.Windows.Forms.Button();
            this.btnModificarReloj = new System.Windows.Forms.Button();
            this.btnNuevoReloj = new System.Windows.Forms.Button();
            this.colIdtreloj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPuerto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaRelojes)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListaRelojes
            // 
            this.dtgListaRelojes.AllowUserToAddRows = false;
            this.dtgListaRelojes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dtgListaRelojes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaRelojes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaRelojes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdtreloj,
            this.colDescripcion,
            this.colIp,
            this.colPuerto,
            this.colActivo});
            this.dtgListaRelojes.Location = new System.Drawing.Point(12, 26);
            this.dtgListaRelojes.MultiSelect = false;
            this.dtgListaRelojes.Name = "dtgListaRelojes";
            this.dtgListaRelojes.ReadOnly = true;
            this.dtgListaRelojes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaRelojes.Size = new System.Drawing.Size(548, 160);
            this.dtgListaRelojes.TabIndex = 0;
            // 
            // btnEliminarReloj
            // 
            this.btnEliminarReloj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarReloj.BackColor = System.Drawing.Color.MintCream;
            this.btnEliminarReloj.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarReloj.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEliminarReloj.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnEliminarReloj.Location = new System.Drawing.Point(481, 204);
            this.btnEliminarReloj.Name = "btnEliminarReloj";
            this.btnEliminarReloj.Size = new System.Drawing.Size(79, 65);
            this.btnEliminarReloj.TabIndex = 86;
            this.btnEliminarReloj.Text = "&Eliminar Reloj";
            this.btnEliminarReloj.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminarReloj.UseVisualStyleBackColor = false;
            // 
            // btnModificarReloj
            // 
            this.btnModificarReloj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificarReloj.BackColor = System.Drawing.Color.MintCream;
            this.btnModificarReloj.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificarReloj.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnModificarReloj.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnModificarReloj.Location = new System.Drawing.Point(391, 204);
            this.btnModificarReloj.Name = "btnModificarReloj";
            this.btnModificarReloj.Size = new System.Drawing.Size(79, 65);
            this.btnModificarReloj.TabIndex = 85;
            this.btnModificarReloj.Text = "&Modificar Reloj";
            this.btnModificarReloj.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModificarReloj.UseVisualStyleBackColor = false;
            this.btnModificarReloj.Click += new System.EventHandler(this.btnModificarReloj_Click);
            // 
            // btnNuevoReloj
            // 
            this.btnNuevoReloj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoReloj.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevoReloj.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevoReloj.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevoReloj.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnNuevoReloj.Location = new System.Drawing.Point(310, 204);
            this.btnNuevoReloj.Name = "btnNuevoReloj";
            this.btnNuevoReloj.Size = new System.Drawing.Size(75, 65);
            this.btnNuevoReloj.TabIndex = 84;
            this.btnNuevoReloj.Text = "&Nuevo Reloj";
            this.btnNuevoReloj.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevoReloj.UseVisualStyleBackColor = false;
            this.btnNuevoReloj.Click += new System.EventHandler(this.btnNuevoReloj_Click);
            // 
            // colIdtreloj
            // 
            this.colIdtreloj.DataPropertyName = "idtreloj";
            this.colIdtreloj.HeaderText = "Codigo";
            this.colIdtreloj.Name = "colIdtreloj";
            this.colIdtreloj.ReadOnly = true;
            this.colIdtreloj.Width = 50;
            // 
            // colDescripcion
            // 
            this.colDescripcion.DataPropertyName = "descripcion";
            this.colDescripcion.HeaderText = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 200;
            // 
            // colIp
            // 
            this.colIp.DataPropertyName = "ip";
            this.colIp.HeaderText = "IP";
            this.colIp.Name = "colIp";
            this.colIp.ReadOnly = true;
            // 
            // colPuerto
            // 
            this.colPuerto.DataPropertyName = "puerto";
            this.colPuerto.HeaderText = "Puerto";
            this.colPuerto.Name = "colPuerto";
            this.colPuerto.ReadOnly = true;
            // 
            // colActivo
            // 
            this.colActivo.DataPropertyName = "activo";
            this.colActivo.HeaderText = "Activo";
            this.colActivo.Name = "colActivo";
            this.colActivo.ReadOnly = true;
            this.colActivo.Width = 50;
            // 
            // frmListaRelojes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 281);
            this.Controls.Add(this.btnEliminarReloj);
            this.Controls.Add(this.btnModificarReloj);
            this.Controls.Add(this.btnNuevoReloj);
            this.Controls.Add(this.dtgListaRelojes);
            this.Name = "frmListaRelojes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Relojes";
            this.Load += new System.EventHandler(this.frmListaRelojes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaRelojes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgListaRelojes;
        private System.Windows.Forms.Button btnEliminarReloj;
        private System.Windows.Forms.Button btnModificarReloj;
        private System.Windows.Forms.Button btnNuevoReloj;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtreloj;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPuerto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colActivo;
    }
}