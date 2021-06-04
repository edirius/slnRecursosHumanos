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
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaPicados)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListaPicados
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dtgListaPicados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaPicados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaPicados.Location = new System.Drawing.Point(169, 36);
            this.dtgListaPicados.Name = "dtgListaPicados";
            this.dtgListaPicados.Size = new System.Drawing.Size(459, 242);
            this.dtgListaPicados.TabIndex = 0;
            // 
            // btnDescargarAsistencia
            // 
            this.btnDescargarAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDescargarAsistencia.BackColor = System.Drawing.Color.MintCream;
            this.btnDescargarAsistencia.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnDescargarAsistencia.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDescargarAsistencia.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnDescargarAsistencia.Location = new System.Drawing.Point(27, 36);
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
            this.btnGuardarAsistencia.Location = new System.Drawing.Point(27, 139);
            this.btnGuardarAsistencia.Name = "btnGuardarAsistencia";
            this.btnGuardarAsistencia.Size = new System.Drawing.Size(94, 65);
            this.btnGuardarAsistencia.TabIndex = 102;
            this.btnGuardarAsistencia.Text = "Guardar Asistencia";
            this.btnGuardarAsistencia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuardarAsistencia.UseVisualStyleBackColor = false;
            this.btnGuardarAsistencia.Click += new System.EventHandler(this.btnGuardarAsistencia_Click);
            // 
            // frmAsistenciaReloj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 305);
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

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgListaPicados;
        private System.Windows.Forms.Button btnDescargarAsistencia;
        private System.Windows.Forms.Button btnGuardarAsistencia;
    }
}