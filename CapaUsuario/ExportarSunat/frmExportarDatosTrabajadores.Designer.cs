namespace CapaUsuario.ExportarSunat
{
    partial class frmExportarDatosTrabajadores
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
            this.dgvListarTrabajadores = new System.Windows.Forms.DataGridView();
            this.btnExportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarTrabajadores)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListarTrabajadores
            // 
            this.dgvListarTrabajadores.AllowUserToAddRows = false;
            this.dgvListarTrabajadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListarTrabajadores.Location = new System.Drawing.Point(12, 27);
            this.dgvListarTrabajadores.Name = "dgvListarTrabajadores";
            this.dgvListarTrabajadores.RowHeadersVisible = false;
            this.dgvListarTrabajadores.Size = new System.Drawing.Size(1058, 335);
            this.dgvListarTrabajadores.TabIndex = 29;
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(995, 376);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 23);
            this.btnExportar.TabIndex = 30;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // frmExportarDatosTrabajadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 411);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgvListarTrabajadores);
            this.Name = "frmExportarDatosTrabajadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmExportarDatosTrabajadores";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarTrabajadores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListarTrabajadores;
        private System.Windows.Forms.Button btnExportar;
    }
}