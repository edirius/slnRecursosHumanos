namespace CapaUsuario.ImportadorExcel
{
    partial class frmImportadorExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportadorExcel));
            this.label1 = new System.Windows.Forms.Label();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.dlgAbrirExcel = new System.Windows.Forms.OpenFileDialog();
            this.btnEscogerExcel = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.dtgLista = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLista)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ruta Archivo:";
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(158, 49);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(391, 20);
            this.txtRuta.TabIndex = 1;
            // 
            // dlgAbrirExcel
            // 
            this.dlgAbrirExcel.FileName = "openFileDialog1";
            // 
            // btnEscogerExcel
            // 
            this.btnEscogerExcel.Location = new System.Drawing.Point(556, 49);
            this.btnEscogerExcel.Name = "btnEscogerExcel";
            this.btnEscogerExcel.Size = new System.Drawing.Size(31, 23);
            this.btnEscogerExcel.TabIndex = 2;
            this.btnEscogerExcel.Text = "...";
            this.btnEscogerExcel.UseVisualStyleBackColor = true;
            this.btnEscogerExcel.Click += new System.EventHandler(this.btnEscogerExcel_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(82, 377);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(75, 23);
            this.btnImportar.TabIndex = 4;
            this.btnImportar.Text = "IMPORTAR";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // dtgLista
            // 
            this.dtgLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLista.Location = new System.Drawing.Point(82, 86);
            this.dtgLista.Name = "dtgLista";
            this.dtgLista.Size = new System.Drawing.Size(549, 235);
            this.dtgLista.TabIndex = 5;
            // 
            // frmImportadorExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 414);
            this.Controls.Add(this.dtgLista);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.btnEscogerExcel);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmImportadorExcel";
            this.Text = "Llenar Datos Excel";
            this.Load += new System.EventHandler(this.frmImportadorExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.OpenFileDialog dlgAbrirExcel;
        private System.Windows.Forms.Button btnEscogerExcel;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.DataGridView dtgLista;
    }
}