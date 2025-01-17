namespace CapaUsuario.Reloj
{
    partial class frmAsistenciaReloj
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsistenciaReloj));
            this.dtgListaPicados = new System.Windows.Forms.DataGridView();
            this.btnDescargarAsistencia = new System.Windows.Forms.Button();
            this.btnGuardarAsistencia = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpInicioFecha = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpFinFecha = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaPicados)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListaPicados
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dtgListaPicados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaPicados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaPicados.Location = new System.Drawing.Point(203, 12);
            this.dtgListaPicados.MultiSelect = false;
            this.dtgListaPicados.Name = "dtgListaPicados";
            this.dtgListaPicados.ReadOnly = true;
            this.dtgListaPicados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaPicados.Size = new System.Drawing.Size(599, 342);
            this.dtgListaPicados.TabIndex = 0;
            // 
            // btnDescargarAsistencia
            // 
            this.btnDescargarAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDescargarAsistencia.BackColor = System.Drawing.Color.MintCream;
            this.btnDescargarAsistencia.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnDescargarAsistencia.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDescargarAsistencia.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnDescargarAsistencia.Location = new System.Drawing.Point(103, 88);
            this.btnDescargarAsistencia.Name = "btnDescargarAsistencia";
            this.btnDescargarAsistencia.Size = new System.Drawing.Size(94, 65);
            this.btnDescargarAsistencia.TabIndex = 101;
            this.btnDescargarAsistencia.Text = "Descargar Asistencia";
            this.btnDescargarAsistencia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDescargarAsistencia.UseVisualStyleBackColor = false;
            this.btnDescargarAsistencia.Click += new System.EventHandler(this.btnDescargarAsistencia_Click);
            // 
            // btnGuardarAsistencia
            // 
            this.btnGuardarAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardarAsistencia.BackColor = System.Drawing.Color.MintCream;
            this.btnGuardarAsistencia.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardarAsistencia.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnGuardarAsistencia.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnGuardarAsistencia.Location = new System.Drawing.Point(103, 171);
            this.btnGuardarAsistencia.Name = "btnGuardarAsistencia";
            this.btnGuardarAsistencia.Size = new System.Drawing.Size(94, 65);
            this.btnGuardarAsistencia.TabIndex = 102;
            this.btnGuardarAsistencia.Text = "Guardar Asistencia";
            this.btnGuardarAsistencia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuardarAsistencia.UseVisualStyleBackColor = false;
            this.btnGuardarAsistencia.Click += new System.EventHandler(this.btnGuardarAsistencia_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 340);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 103;
            this.label1.Text = "Datos Guardados: 0";
            // 
            // dtpInicioFecha
            // 
            this.dtpInicioFecha.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpInicioFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicioFecha.Location = new System.Drawing.Point(46, 12);
            this.dtpInicioFecha.Name = "dtpInicioFecha";
            this.dtpInicioFecha.Size = new System.Drawing.Size(151, 20);
            this.dtpInicioFecha.TabIndex = 107;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(27, 13);
            this.label15.TabIndex = 105;
            this.label15.Text = "De :";
            // 
            // dtpFinFecha
            // 
            this.dtpFinFecha.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpFinFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFinFecha.Location = new System.Drawing.Point(46, 42);
            this.dtpFinFecha.Name = "dtpFinFecha";
            this.dtpFinFecha.Size = new System.Drawing.Size(151, 20);
            this.dtpFinFecha.TabIndex = 108;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 46);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(20, 13);
            this.label16.TabIndex = 106;
            this.label16.Text = "A :";
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.BackColor = System.Drawing.Color.MintCream;
            this.btnExportarExcel.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportarExcel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnExportarExcel.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnExportarExcel.Location = new System.Drawing.Point(103, 262);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(94, 65);
            this.btnExportarExcel.TabIndex = 109;
            this.btnExportarExcel.Text = "&Exportar a Excel";
            this.btnExportarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // frmAsistenciaReloj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 365);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.dtpInicioFecha);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dtpFinFecha);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGuardarAsistencia);
            this.Controls.Add(this.btnDescargarAsistencia);
            this.Controls.Add(this.dtgListaPicados);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAsistenciaReloj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asistencia Reloj";
            this.Load += new System.EventHandler(this.frmAsistenciaReloj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaPicados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgListaPicados;
        private System.Windows.Forms.Button btnDescargarAsistencia;
        private System.Windows.Forms.Button btnGuardarAsistencia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpInicioFecha;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpFinFecha;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnExportarExcel;
    }
}