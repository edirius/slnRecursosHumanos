namespace CapaUsuario.Reloj
{
    partial class frmBajarDatosReloj
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBajarDatosReloj));
            this.dtgListaRelojes = new System.Windows.Forms.DataGridView();
            this.colSeleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIdtreloj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPuerto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgListaPicados = new System.Windows.Forms.DataGridView();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardarAsistencia = new System.Windows.Forms.Button();
            this.btnDescargarAsistencia = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaRelojes)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaPicados)).BeginInit();
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
            this.colSeleccion,
            this.colIdtreloj,
            this.colDescripcion,
            this.colIp,
            this.colPuerto});
            this.dtgListaRelojes.Location = new System.Drawing.Point(12, 12);
            this.dtgListaRelojes.MultiSelect = false;
            this.dtgListaRelojes.Name = "dtgListaRelojes";
            this.dtgListaRelojes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaRelojes.Size = new System.Drawing.Size(653, 160);
            this.dtgListaRelojes.TabIndex = 111;
            // 
            // colSeleccion
            // 
            this.colSeleccion.DataPropertyName = "seleccion";
            this.colSeleccion.HeaderText = "Seleccion";
            this.colSeleccion.Name = "colSeleccion";
            this.colSeleccion.Width = 50;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgListaPicados);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(651, 302);
            this.groupBox1.TabIndex = 112;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asistencia";
            // 
            // dtgListaPicados
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            this.dtgListaPicados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgListaPicados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaPicados.Location = new System.Drawing.Point(9, 51);
            this.dtgListaPicados.MultiSelect = false;
            this.dtgListaPicados.Name = "dtgListaPicados";
            this.dtgListaPicados.ReadOnly = true;
            this.dtgListaPicados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaPicados.Size = new System.Drawing.Size(635, 240);
            this.dtgListaPicados.TabIndex = 2;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(39, 18);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dia:";
            // 
            // btnGuardarAsistencia
            // 
            this.btnGuardarAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardarAsistencia.BackColor = System.Drawing.Color.MintCream;
            this.btnGuardarAsistencia.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardarAsistencia.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnGuardarAsistencia.Image = global::CapaUsuario.Properties.Resources.schedule__002;
            this.btnGuardarAsistencia.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnGuardarAsistencia.Location = new System.Drawing.Point(402, 511);
            this.btnGuardarAsistencia.Name = "btnGuardarAsistencia";
            this.btnGuardarAsistencia.Size = new System.Drawing.Size(120, 53);
            this.btnGuardarAsistencia.TabIndex = 116;
            this.btnGuardarAsistencia.Text = "Guardar Asistencia";
            this.btnGuardarAsistencia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardarAsistencia.UseVisualStyleBackColor = false;
            this.btnGuardarAsistencia.Click += new System.EventHandler(this.btnGuardarAsistencia_Click);
            // 
            // btnDescargarAsistencia
            // 
            this.btnDescargarAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDescargarAsistencia.BackColor = System.Drawing.Color.MintCream;
            this.btnDescargarAsistencia.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnDescargarAsistencia.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDescargarAsistencia.Image = global::CapaUsuario.Properties.Resources.sched_tasks;
            this.btnDescargarAsistencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDescargarAsistencia.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnDescargarAsistencia.Location = new System.Drawing.Point(277, 511);
            this.btnDescargarAsistencia.Name = "btnDescargarAsistencia";
            this.btnDescargarAsistencia.Size = new System.Drawing.Size(119, 53);
            this.btnDescargarAsistencia.TabIndex = 115;
            this.btnDescargarAsistencia.Text = "Descargar Asistencia";
            this.btnDescargarAsistencia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDescargarAsistencia.UseVisualStyleBackColor = false;
            this.btnDescargarAsistencia.Click += new System.EventHandler(this.btnDescargarAsistencia_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.MintCream;
            this.btnSalir.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSalir.Image = global::CapaUsuario.Properties.Resources.exit_32x32;
            this.btnSalir.Location = new System.Drawing.Point(559, 511);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(93, 53);
            this.btnSalir.TabIndex = 117;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 511);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 118;
            this.label2.Text = "Datos Guardados: 0";
            // 
            // frmBajarDatosReloj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 588);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGuardarAsistencia);
            this.Controls.Add(this.btnDescargarAsistencia);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtgListaRelojes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBajarDatosReloj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bajar Datos del Reloj";
            this.Load += new System.EventHandler(this.frmBajarDatosReloj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaRelojes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaPicados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgListaRelojes;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSeleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtreloj;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPuerto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgListaPicados;
        private System.Windows.Forms.Button btnGuardarAsistencia;
        private System.Windows.Forms.Button btnDescargarAsistencia;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label2;
    }
}