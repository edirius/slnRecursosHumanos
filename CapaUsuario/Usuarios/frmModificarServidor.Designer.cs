namespace CapaUsuario.Usuarios
{
    partial class frmModificarServidor
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnGuardarServidor = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Direccion IP:";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(118, 27);
            this.txtIP.MaxLength = 17;
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(192, 20);
            this.txtIP.TabIndex = 1;
            // 
            // btnGuardarServidor
            // 
            this.btnGuardarServidor.BackColor = System.Drawing.Color.MintCream;
            this.btnGuardarServidor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarServidor.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarServidor.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnGuardarServidor.Location = new System.Drawing.Point(65, 72);
            this.btnGuardarServidor.Name = "btnGuardarServidor";
            this.btnGuardarServidor.Size = new System.Drawing.Size(141, 45);
            this.btnGuardarServidor.TabIndex = 19;
            this.btnGuardarServidor.Text = "Guardar";
            this.btnGuardarServidor.UseVisualStyleBackColor = false;
            this.btnGuardarServidor.Click += new System.EventHandler(this.btnGuardarServidor_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.MintCream;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSalir.Location = new System.Drawing.Point(212, 72);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(141, 45);
            this.btnSalir.TabIndex = 20;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmModificarServidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 139);
            this.Controls.Add(this.btnGuardarServidor);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.Name = "frmModificarServidor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Direccion Servidor";
            this.Load += new System.EventHandler(this.frmModificarServidor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnGuardarServidor;
        private System.Windows.Forms.Button btnSalir;
    }
}