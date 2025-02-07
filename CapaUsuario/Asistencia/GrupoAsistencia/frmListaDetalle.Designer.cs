namespace CapaUsuario.Asistencia.GrupoAsistencia
{
    partial class frmListaDetalle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblNombre = new System.Windows.Forms.Label();
            this.dtgDetallesGrupo = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminarTrabajador = new System.Windows.Forms.Button();
            this.btnAgregarTrabajador = new System.Windows.Forms.Button();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidoPaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidoMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colidttrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetallesGrupo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblNombre.Location = new System.Drawing.Point(13, 13);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(113, 16);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre Grupo:";
            // 
            // dtgDetallesGrupo
            // 
            this.dtgDetallesGrupo.AllowUserToAddRows = false;
            this.dtgDetallesGrupo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SkyBlue;
            this.dtgDetallesGrupo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgDetallesGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetallesGrupo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colDNI,
            this.colNombres,
            this.colApellidoPaterno,
            this.colApellidoMaterno,
            this.colidttrabajador,
            this.colGrupo});
            this.dtgDetallesGrupo.Location = new System.Drawing.Point(12, 48);
            this.dtgDetallesGrupo.Name = "dtgDetallesGrupo";
            this.dtgDetallesGrupo.ReadOnly = true;
            this.dtgDetallesGrupo.Size = new System.Drawing.Size(553, 150);
            this.dtgDetallesGrupo.TabIndex = 1;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.MintCream;
            this.btnSalir.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSalir.Image = global::CapaUsuario.Properties.Resources.exit_32x32;
            this.btnSalir.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnSalir.Location = new System.Drawing.Point(487, 213);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(79, 65);
            this.btnSalir.TabIndex = 89;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // btnEliminarTrabajador
            // 
            this.btnEliminarTrabajador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarTrabajador.BackColor = System.Drawing.Color.MintCream;
            this.btnEliminarTrabajador.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarTrabajador.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEliminarTrabajador.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnEliminarTrabajador.Location = new System.Drawing.Point(346, 213);
            this.btnEliminarTrabajador.Name = "btnEliminarTrabajador";
            this.btnEliminarTrabajador.Size = new System.Drawing.Size(95, 65);
            this.btnEliminarTrabajador.TabIndex = 88;
            this.btnEliminarTrabajador.Text = "&Eliminar Trabajador";
            this.btnEliminarTrabajador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminarTrabajador.UseVisualStyleBackColor = false;
            this.btnEliminarTrabajador.Click += new System.EventHandler(this.btnEliminarTrabajador_Click);
            // 
            // btnAgregarTrabajador
            // 
            this.btnAgregarTrabajador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarTrabajador.BackColor = System.Drawing.Color.MintCream;
            this.btnAgregarTrabajador.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarTrabajador.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAgregarTrabajador.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnAgregarTrabajador.Location = new System.Drawing.Point(257, 213);
            this.btnAgregarTrabajador.Name = "btnAgregarTrabajador";
            this.btnAgregarTrabajador.Size = new System.Drawing.Size(83, 65);
            this.btnAgregarTrabajador.TabIndex = 87;
            this.btnAgregarTrabajador.Text = "&Agregar Trabajador";
            this.btnAgregarTrabajador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgregarTrabajador.UseVisualStyleBackColor = false;
            this.btnAgregarTrabajador.Click += new System.EventHandler(this.btnAgregarTrabajador_Click);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "idtdetallegrupoasistencia";
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 50;
            // 
            // colDNI
            // 
            this.colDNI.DataPropertyName = "dni";
            this.colDNI.HeaderText = "DNI";
            this.colDNI.Name = "colDNI";
            this.colDNI.ReadOnly = true;
            this.colDNI.Width = 75;
            // 
            // colNombres
            // 
            this.colNombres.DataPropertyName = "nombres";
            this.colNombres.HeaderText = "Nombres";
            this.colNombres.Name = "colNombres";
            this.colNombres.ReadOnly = true;
            this.colNombres.Width = 120;
            // 
            // colApellidoPaterno
            // 
            this.colApellidoPaterno.DataPropertyName = "apellidopaterno";
            this.colApellidoPaterno.HeaderText = "Apellido Paterno";
            this.colApellidoPaterno.Name = "colApellidoPaterno";
            this.colApellidoPaterno.ReadOnly = true;
            this.colApellidoPaterno.Width = 120;
            // 
            // colApellidoMaterno
            // 
            this.colApellidoMaterno.DataPropertyName = "apellidomaterno";
            this.colApellidoMaterno.HeaderText = "Apellido Materno";
            this.colApellidoMaterno.Name = "colApellidoMaterno";
            this.colApellidoMaterno.ReadOnly = true;
            this.colApellidoMaterno.Width = 120;
            // 
            // colidttrabajador
            // 
            this.colidttrabajador.DataPropertyName = "idttrabajador";
            this.colidttrabajador.HeaderText = "idttrabajador";
            this.colidttrabajador.Name = "colidttrabajador";
            this.colidttrabajador.ReadOnly = true;
            this.colidttrabajador.Visible = false;
            // 
            // colGrupo
            // 
            this.colGrupo.DataPropertyName = "grupoasistencia";
            this.colGrupo.HeaderText = "Grupo";
            this.colGrupo.Name = "colGrupo";
            this.colGrupo.ReadOnly = true;
            this.colGrupo.Visible = false;
            // 
            // frmListaDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 290);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminarTrabajador);
            this.Controls.Add(this.btnAgregarTrabajador);
            this.Controls.Add(this.dtgDetallesGrupo);
            this.Controls.Add(this.lblNombre);
            this.Name = "frmListaDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de Trabajadores por Grupo";
            this.Load += new System.EventHandler(this.frmListaDetalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetallesGrupo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.DataGridView dtgDetallesGrupo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEliminarTrabajador;
        private System.Windows.Forms.Button btnAgregarTrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidoPaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidoMaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colidttrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrupo;
    }
}