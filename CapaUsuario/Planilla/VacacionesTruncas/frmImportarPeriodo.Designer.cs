namespace CapaUsuario.Planilla.VacacionesTruncas
{
    partial class frmImportarPeriodo
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
            this.btnAgregarTrabajador = new System.Windows.Forms.Button();
            this.lblTrabajador = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAgregarTrabajador
            // 
            this.btnAgregarTrabajador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarTrabajador.BackColor = System.Drawing.Color.MintCream;
            this.btnAgregarTrabajador.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarTrabajador.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAgregarTrabajador.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnAgregarTrabajador.Location = new System.Drawing.Point(26, 12);
            this.btnAgregarTrabajador.Name = "btnAgregarTrabajador";
            this.btnAgregarTrabajador.Size = new System.Drawing.Size(83, 65);
            this.btnAgregarTrabajador.TabIndex = 122;
            this.btnAgregarTrabajador.Text = "&Buscar Trabajador";
            this.btnAgregarTrabajador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgregarTrabajador.UseVisualStyleBackColor = false;
            this.btnAgregarTrabajador.Click += new System.EventHandler(this.btnAgregarTrabajador_Click);
            // 
            // lblTrabajador
            // 
            this.lblTrabajador.AutoSize = true;
            this.lblTrabajador.Location = new System.Drawing.Point(129, 63);
            this.lblTrabajador.Name = "lblTrabajador";
            this.lblTrabajador.Size = new System.Drawing.Size(58, 13);
            this.lblTrabajador.TabIndex = 123;
            this.lblTrabajador.Text = "Trabajador";
            // 
            // frmImportarPeriodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 414);
            this.Controls.Add(this.lblTrabajador);
            this.Controls.Add(this.btnAgregarTrabajador);
            this.Name = "frmImportarPeriodo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Periodo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarTrabajador;
        private System.Windows.Forms.Label lblTrabajador;
    }
}