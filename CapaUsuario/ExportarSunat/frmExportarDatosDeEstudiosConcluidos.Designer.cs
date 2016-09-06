namespace CapaUsuario.ExportarSunat
{
    partial class frmExportarDatosDeEstudiosConcluidos
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
            this.dgvDatosEstudios = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosEstudios)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(544, 303);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(91, 29);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // dgvDatosEstudios
            // 
            this.dgvDatosEstudios.AllowUserToAddRows = false;
            this.dgvDatosEstudios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosEstudios.Location = new System.Drawing.Point(12, 55);
            this.dgvDatosEstudios.Name = "dgvDatosEstudios";
            this.dgvDatosEstudios.RowHeadersVisible = false;
            this.dgvDatosEstudios.Size = new System.Drawing.Size(615, 242);
            this.dgvDatosEstudios.TabIndex = 2;
            // 
            // frmExportarDatosDeEstudiosConcluidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 342);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgvDatosEstudios);
            this.Name = "frmExportarDatosDeEstudiosConcluidos";
            this.Text = "frmExportarDatosDeEstudiosConcluidos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosEstudios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DataGridView dgvDatosEstudios;
    }
}