namespace CapaUsuario.Asistencia
{
    partial class frmListaTiposSalida
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
            this.btnEliminarTipoSalida = new System.Windows.Forms.Button();
            this.btnModificarTipoSalida = new System.Windows.Forms.Button();
            this.btnNuevoTipoSalida = new System.Windows.Forms.Button();
            this.dtgTipoSalidas = new System.Windows.Forms.DataGridView();
            this.colIdtTipoSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipoSalidas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEliminarTipoSalida
            // 
            this.btnEliminarTipoSalida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarTipoSalida.BackColor = System.Drawing.Color.MintCream;
            this.btnEliminarTipoSalida.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarTipoSalida.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEliminarTipoSalida.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnEliminarTipoSalida.Location = new System.Drawing.Point(315, 177);
            this.btnEliminarTipoSalida.Name = "btnEliminarTipoSalida";
            this.btnEliminarTipoSalida.Size = new System.Drawing.Size(79, 65);
            this.btnEliminarTipoSalida.TabIndex = 85;
            this.btnEliminarTipoSalida.Text = "&Eliminar Tipo Salida";
            this.btnEliminarTipoSalida.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminarTipoSalida.UseVisualStyleBackColor = false;
            this.btnEliminarTipoSalida.Click += new System.EventHandler(this.btnEliminarTipoSalida_Click);
            // 
            // btnModificarTipoSalida
            // 
            this.btnModificarTipoSalida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificarTipoSalida.BackColor = System.Drawing.Color.MintCream;
            this.btnModificarTipoSalida.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificarTipoSalida.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnModificarTipoSalida.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnModificarTipoSalida.Location = new System.Drawing.Point(225, 177);
            this.btnModificarTipoSalida.Name = "btnModificarTipoSalida";
            this.btnModificarTipoSalida.Size = new System.Drawing.Size(79, 65);
            this.btnModificarTipoSalida.TabIndex = 84;
            this.btnModificarTipoSalida.Text = "&Modificar Tipo Salida";
            this.btnModificarTipoSalida.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModificarTipoSalida.UseVisualStyleBackColor = false;
            this.btnModificarTipoSalida.Click += new System.EventHandler(this.btnModificarTipoSalida_Click);
            // 
            // btnNuevoTipoSalida
            // 
            this.btnNuevoTipoSalida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoTipoSalida.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevoTipoSalida.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevoTipoSalida.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevoTipoSalida.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnNuevoTipoSalida.Location = new System.Drawing.Point(144, 177);
            this.btnNuevoTipoSalida.Name = "btnNuevoTipoSalida";
            this.btnNuevoTipoSalida.Size = new System.Drawing.Size(75, 65);
            this.btnNuevoTipoSalida.TabIndex = 83;
            this.btnNuevoTipoSalida.Text = "&Nuevo Tipo Salida";
            this.btnNuevoTipoSalida.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevoTipoSalida.UseVisualStyleBackColor = false;
            this.btnNuevoTipoSalida.Click += new System.EventHandler(this.btnNuevoTipoSalida_Click);
            // 
            // dtgTipoSalidas
            // 
            this.dtgTipoSalidas.AllowUserToAddRows = false;
            this.dtgTipoSalidas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dtgTipoSalidas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgTipoSalidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTipoSalidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdtTipoSalida,
            this.colDescripcion});
            this.dtgTipoSalidas.Location = new System.Drawing.Point(12, 12);
            this.dtgTipoSalidas.MultiSelect = false;
            this.dtgTipoSalidas.Name = "dtgTipoSalidas";
            this.dtgTipoSalidas.ReadOnly = true;
            this.dtgTipoSalidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTipoSalidas.Size = new System.Drawing.Size(380, 150);
            this.dtgTipoSalidas.TabIndex = 82;
            // 
            // colIdtTipoSalida
            // 
            this.colIdtTipoSalida.DataPropertyName = "codigo";
            this.colIdtTipoSalida.HeaderText = "ID";
            this.colIdtTipoSalida.Name = "colIdtTipoSalida";
            this.colIdtTipoSalida.ReadOnly = true;
            this.colIdtTipoSalida.Width = 50;
            // 
            // colDescripcion
            // 
            this.colDescripcion.DataPropertyName = "Descripcion";
            this.colDescripcion.HeaderText = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 250;
            // 
            // frmListaTiposSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 254);
            this.Controls.Add(this.btnEliminarTipoSalida);
            this.Controls.Add(this.btnModificarTipoSalida);
            this.Controls.Add(this.btnNuevoTipoSalida);
            this.Controls.Add(this.dtgTipoSalidas);
            this.Name = "frmListaTiposSalida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipos de Salida";
            this.Load += new System.EventHandler(this.frmListaTiposSalida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipoSalidas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEliminarTipoSalida;
        private System.Windows.Forms.Button btnModificarTipoSalida;
        private System.Windows.Forms.Button btnNuevoTipoSalida;
        private System.Windows.Forms.DataGridView dtgTipoSalidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtTipoSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
    }
}