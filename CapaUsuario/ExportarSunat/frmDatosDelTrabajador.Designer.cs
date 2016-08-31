namespace CapaUsuario.ExportarSunat
{
    partial class frmDatosDelTrabajador
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
            this.btnExportar = new System.Windows.Forms.Button();
            this.dgvListarDatosTrabajadores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarDatosTrabajadores)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(998, 389);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 23);
            this.btnExportar.TabIndex = 32;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // dgvListarDatosTrabajadores
            // 
            this.dgvListarDatosTrabajadores.AllowUserToAddRows = false;
            this.dgvListarDatosTrabajadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListarDatosTrabajadores.Location = new System.Drawing.Point(14, 36);
            this.dgvListarDatosTrabajadores.Name = "dgvListarDatosTrabajadores";
            this.dgvListarDatosTrabajadores.RowHeadersVisible = false;
            this.dgvListarDatosTrabajadores.Size = new System.Drawing.Size(1058, 334);
            this.dgvListarDatosTrabajadores.TabIndex = 31;
            // 
            // frmDatosDelTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 435);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgvListarDatosTrabajadores);
            this.Name = "frmDatosDelTrabajador";
            this.Text = "frmDatosDelTrabajador";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarDatosTrabajadores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DataGridView dgvListarDatosTrabajadores;
    }
}