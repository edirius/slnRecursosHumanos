namespace CapaUsuario.ClasificadorMeta
{
    partial class frmMantenimientoClasificador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoClasificador));
            this.label1 = new System.Windows.Forms.Label();
            this.txtClasificador = new System.Windows.Forms.TextBox();
            this.btnNuevoClasificador = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.btnSeleccionarConcepto = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clasificador: ";
            // 
            // txtClasificador
            // 
            this.txtClasificador.Location = new System.Drawing.Point(94, 34);
            this.txtClasificador.Name = "txtClasificador";
            this.txtClasificador.ReadOnly = true;
            this.txtClasificador.Size = new System.Drawing.Size(287, 20);
            this.txtClasificador.TabIndex = 1;
            // 
            // btnNuevoClasificador
            // 
            this.btnNuevoClasificador.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevoClasificador.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoClasificador.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevoClasificador.Location = new System.Drawing.Point(429, 24);
            this.btnNuevoClasificador.Name = "btnNuevoClasificador";
            this.btnNuevoClasificador.Size = new System.Drawing.Size(100, 47);
            this.btnNuevoClasificador.TabIndex = 15;
            this.btnNuevoClasificador.Text = "Seleccionar Clasificador";
            this.btnNuevoClasificador.UseVisualStyleBackColor = false;
            this.btnNuevoClasificador.Click += new System.EventHandler(this.btnNuevoClasificador_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Concepto:";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(94, 113);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.ReadOnly = true;
            this.txtConcepto.Size = new System.Drawing.Size(287, 20);
            this.txtConcepto.TabIndex = 17;
            // 
            // btnSeleccionarConcepto
            // 
            this.btnSeleccionarConcepto.BackColor = System.Drawing.Color.MintCream;
            this.btnSeleccionarConcepto.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarConcepto.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSeleccionarConcepto.Location = new System.Drawing.Point(429, 90);
            this.btnSeleccionarConcepto.Name = "btnSeleccionarConcepto";
            this.btnSeleccionarConcepto.Size = new System.Drawing.Size(100, 47);
            this.btnSeleccionarConcepto.TabIndex = 18;
            this.btnSeleccionarConcepto.Text = "Seleccionar Concepto";
            this.btnSeleccionarConcepto.UseVisualStyleBackColor = false;
            this.btnSeleccionarConcepto.Click += new System.EventHandler(this.btnSeleccionarConcepto_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.MintCream;
            this.btnAceptar.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAceptar.Location = new System.Drawing.Point(32, 194);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 47);
            this.btnAceptar.TabIndex = 19;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MintCream;
            this.button2.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button2.Location = new System.Drawing.Point(301, 194);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 47);
            this.button2.TabIndex = 20;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmMantenimientoClasificador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 284);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSeleccionarConcepto);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNuevoClasificador);
            this.Controls.Add(this.txtClasificador);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMantenimientoClasificador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Clasificador";
            this.Load += new System.EventHandler(this.frmMantenimientoClasificador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClasificador;
        private System.Windows.Forms.Button btnNuevoClasificador;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Button btnSeleccionarConcepto;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button button2;
    }
}