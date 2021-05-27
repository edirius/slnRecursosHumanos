namespace CapaUsuario.Reloj
{
    partial class frmAdministrarReloj
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
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumeroMaquina = new System.Windows.Forms.TextBox();
            this.btnRenta5ta = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInformacionreloj = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(52, 16);
            this.txtIP.MaxLength = 12;
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 20);
            this.txtIP.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Puerto: ";
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(231, 16);
            this.txtPuerto.MaxLength = 5;
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(100, 20);
            this.txtPuerto.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(375, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nro. Maquina :";
            // 
            // txtNumeroMaquina
            // 
            this.txtNumeroMaquina.Location = new System.Drawing.Point(458, 16);
            this.txtNumeroMaquina.Name = "txtNumeroMaquina";
            this.txtNumeroMaquina.Size = new System.Drawing.Size(51, 20);
            this.txtNumeroMaquina.TabIndex = 5;
            // 
            // btnRenta5ta
            // 
            this.btnRenta5ta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRenta5ta.BackColor = System.Drawing.Color.MintCream;
            this.btnRenta5ta.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnRenta5ta.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnRenta5ta.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnRenta5ta.Location = new System.Drawing.Point(32, 125);
            this.btnRenta5ta.Name = "btnRenta5ta";
            this.btnRenta5ta.Size = new System.Drawing.Size(94, 65);
            this.btnRenta5ta.TabIndex = 100;
            this.btnRenta5ta.Text = "Conectar";
            this.btnRenta5ta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRenta5ta.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 101;
            this.label4.Text = "Informacion Reloj: ";
            // 
            // lblInformacionreloj
            // 
            this.lblInformacionreloj.AutoSize = true;
            this.lblInformacionreloj.Location = new System.Drawing.Point(130, 71);
            this.lblInformacionreloj.Name = "lblInformacionreloj";
            this.lblInformacionreloj.Size = new System.Drawing.Size(0, 13);
            this.lblInformacionreloj.TabIndex = 102;
            // 
            // frmAdministrarReloj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 236);
            this.Controls.Add(this.lblInformacionreloj);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRenta5ta);
            this.Controls.Add(this.txtNumeroMaquina);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPuerto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIP);
            this.Name = "frmAdministrarReloj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar Reloj";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumeroMaquina;
        private System.Windows.Forms.Button btnRenta5ta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInformacionreloj;
    }
}