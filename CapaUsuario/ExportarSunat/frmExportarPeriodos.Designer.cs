namespace CapaUsuario.ExportarSunat
{
    partial class frmExportarPeriodos
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
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.btnExportar = new System.Windows.Forms.Button();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.dgv3 = new System.Windows.Forms.DataGridView();
            this.dgv4 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv4)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(12, 33);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(661, 76);
            this.dgv1.TabIndex = 0;
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(598, 446);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 44);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "Exportar \r\nDatos";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // dgv2
            // 
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Location = new System.Drawing.Point(12, 137);
            this.dgv2.Name = "dgv2";
            this.dgv2.Size = new System.Drawing.Size(661, 76);
            this.dgv2.TabIndex = 2;
            // 
            // dgv3
            // 
            this.dgv3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv3.Location = new System.Drawing.Point(12, 253);
            this.dgv3.Name = "dgv3";
            this.dgv3.Size = new System.Drawing.Size(661, 76);
            this.dgv3.TabIndex = 3;
            // 
            // dgv4
            // 
            this.dgv4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv4.Location = new System.Drawing.Point(12, 355);
            this.dgv4.Name = "dgv4";
            this.dgv4.Size = new System.Drawing.Size(661, 76);
            this.dgv4.TabIndex = 4;
            // 
            // frmExportarPeriodos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 502);
            this.Controls.Add(this.dgv4);
            this.Controls.Add(this.dgv3);
            this.Controls.Add(this.dgv2);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgv1);
            this.Name = "frmExportarPeriodos";
            this.Text = "frmExportarPeriodos";
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.DataGridView dgv3;
        private System.Windows.Forms.DataGridView dgv4;
    }
}