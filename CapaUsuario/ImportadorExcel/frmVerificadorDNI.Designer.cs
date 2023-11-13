namespace CapaUsuario.ImportadorExcel
{
    partial class frmVerificadorDNI
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
            this.dtgVerificadorDNI = new System.Windows.Forms.DataGridView();
            this.btnVerificarDNI = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVerificadorDNI)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgVerificadorDNI
            // 
            this.dtgVerificadorDNI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgVerificadorDNI.Location = new System.Drawing.Point(12, 101);
            this.dtgVerificadorDNI.Name = "dtgVerificadorDNI";
            this.dtgVerificadorDNI.Size = new System.Drawing.Size(618, 185);
            this.dtgVerificadorDNI.TabIndex = 0;
            // 
            // btnVerificarDNI
            // 
            this.btnVerificarDNI.Location = new System.Drawing.Point(501, 42);
            this.btnVerificarDNI.Name = "btnVerificarDNI";
            this.btnVerificarDNI.Size = new System.Drawing.Size(75, 23);
            this.btnVerificarDNI.TabIndex = 1;
            this.btnVerificarDNI.Text = "VerificarDNI";
            this.btnVerificarDNI.UseVisualStyleBackColor = true;
            this.btnVerificarDNI.Click += new System.EventHandler(this.btnVerificarDNI_Click);
            // 
            // frmVerificadorDNI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 339);
            this.Controls.Add(this.btnVerificarDNI);
            this.Controls.Add(this.dtgVerificadorDNI);
            this.Name = "frmVerificadorDNI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verificador DNI";
            this.Load += new System.EventHandler(this.frmVerificadorDNI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgVerificadorDNI)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgVerificadorDNI;
        private System.Windows.Forms.Button btnVerificarDNI;
    }
}