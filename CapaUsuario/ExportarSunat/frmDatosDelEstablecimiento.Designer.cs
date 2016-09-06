namespace CapaUsuario.ExportarSunat
{
    partial class frmDatosDelEstablecimiento
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
            this.dgvDatosEstablecimiento = new System.Windows.Forms.DataGridView();
            this.btnExportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosEstablecimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatosEstablecimiento
            // 
            this.dgvDatosEstablecimiento.AllowUserToAddRows = false;
            this.dgvDatosEstablecimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosEstablecimiento.Location = new System.Drawing.Point(12, 69);
            this.dgvDatosEstablecimiento.Name = "dgvDatosEstablecimiento";
            this.dgvDatosEstablecimiento.RowHeadersVisible = false;
            this.dgvDatosEstablecimiento.Size = new System.Drawing.Size(695, 312);
            this.dgvDatosEstablecimiento.TabIndex = 0;
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(632, 387);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 23);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // frmDatosDelEstablecimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 417);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgvDatosEstablecimiento);
            this.Name = "frmDatosDelEstablecimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDatosDelEstablecimiento";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosEstablecimiento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatosEstablecimiento;
        private System.Windows.Forms.Button btnExportar;
    }
}