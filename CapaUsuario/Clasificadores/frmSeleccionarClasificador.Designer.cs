namespace CapaUsuario.Clasificadores
{
    partial class frmSeleccionarClasificador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeleccionarClasificador));
            this.cboGenerica = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboSubGenerica = new System.Windows.Forms.ComboBox();
            this.cboSubGenerica2 = new System.Windows.Forms.ComboBox();
            this.cboEspecifica = new System.Windows.Forms.ComboBox();
            this.cboEspecifica2 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboGenerica
            // 
            this.cboGenerica.FormattingEnabled = true;
            this.cboGenerica.Location = new System.Drawing.Point(123, 38);
            this.cboGenerica.Name = "cboGenerica";
            this.cboGenerica.Size = new System.Drawing.Size(354, 21);
            this.cboGenerica.TabIndex = 0;
            this.cboGenerica.SelectedIndexChanged += new System.EventHandler(this.cboGenerica_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Generica:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SubGenerica:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "SubGenerica 2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Especifica:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Especifica 2:";
            // 
            // cboSubGenerica
            // 
            this.cboSubGenerica.FormattingEnabled = true;
            this.cboSubGenerica.Location = new System.Drawing.Point(123, 65);
            this.cboSubGenerica.Name = "cboSubGenerica";
            this.cboSubGenerica.Size = new System.Drawing.Size(354, 21);
            this.cboSubGenerica.TabIndex = 6;
            this.cboSubGenerica.SelectedIndexChanged += new System.EventHandler(this.cboSubGenerica_SelectedIndexChanged);
            // 
            // cboSubGenerica2
            // 
            this.cboSubGenerica2.FormattingEnabled = true;
            this.cboSubGenerica2.Location = new System.Drawing.Point(123, 93);
            this.cboSubGenerica2.Name = "cboSubGenerica2";
            this.cboSubGenerica2.Size = new System.Drawing.Size(354, 21);
            this.cboSubGenerica2.TabIndex = 7;
            this.cboSubGenerica2.SelectedIndexChanged += new System.EventHandler(this.cboSubGenerica2_SelectedIndexChanged);
            // 
            // cboEspecifica
            // 
            this.cboEspecifica.FormattingEnabled = true;
            this.cboEspecifica.Location = new System.Drawing.Point(123, 128);
            this.cboEspecifica.Name = "cboEspecifica";
            this.cboEspecifica.Size = new System.Drawing.Size(354, 21);
            this.cboEspecifica.TabIndex = 8;
            this.cboEspecifica.SelectedIndexChanged += new System.EventHandler(this.cboEspecifica_SelectedIndexChanged);
            // 
            // cboEspecifica2
            // 
            this.cboEspecifica2.FormattingEnabled = true;
            this.cboEspecifica2.Location = new System.Drawing.Point(123, 164);
            this.cboEspecifica2.Name = "cboEspecifica2";
            this.cboEspecifica2.Size = new System.Drawing.Size(354, 21);
            this.cboEspecifica2.TabIndex = 9;
            this.cboEspecifica2.SelectedIndexChanged += new System.EventHandler(this.cboEspecifica2_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MintCream;
            this.button2.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button2.Location = new System.Drawing.Point(325, 220);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 47);
            this.button2.TabIndex = 22;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.MintCream;
            this.btnAceptar.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAceptar.Location = new System.Drawing.Point(56, 220);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 47);
            this.btnAceptar.TabIndex = 21;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmSeleccionarClasificador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 299);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cboEspecifica2);
            this.Controls.Add(this.cboEspecifica);
            this.Controls.Add(this.cboSubGenerica2);
            this.Controls.Add(this.cboSubGenerica);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboGenerica);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSeleccionarClasificador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecciona un clasificador";
            this.Load += new System.EventHandler(this.frmSeleccionarClasificador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboGenerica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboSubGenerica;
        private System.Windows.Forms.ComboBox cboSubGenerica2;
        private System.Windows.Forms.ComboBox cboEspecifica;
        private System.Windows.Forms.ComboBox cboEspecifica2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAceptar;
    }
}