namespace CapaUsuario.Trabajador
{
    partial class frmNuevoPeriodo
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
            this.dtpInicioPeriodo = new System.Windows.Forms.DateTimePicker();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbFinPeriodo = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFinPeriodo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMotivoFinPeriodo = new System.Windows.Forms.ComboBox();
            this.chkFinPeriodo = new System.Windows.Forms.CheckBox();
            this.gbFinPeriodo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inicio:";
            // 
            // dtpInicioPeriodo
            // 
            this.dtpInicioPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicioPeriodo.Location = new System.Drawing.Point(94, 15);
            this.dtpInicioPeriodo.Name = "dtpInicioPeriodo";
            this.dtpInicioPeriodo.Size = new System.Drawing.Size(96, 20);
            this.dtpInicioPeriodo.TabIndex = 1;
            this.dtpInicioPeriodo.ValueChanged += new System.EventHandler(this.dtpInicioPeriodo_ValueChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(36, 240);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(239, 240);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // gbFinPeriodo
            // 
            this.gbFinPeriodo.Controls.Add(this.label2);
            this.gbFinPeriodo.Controls.Add(this.dtpFinPeriodo);
            this.gbFinPeriodo.Controls.Add(this.label3);
            this.gbFinPeriodo.Controls.Add(this.cboMotivoFinPeriodo);
            this.gbFinPeriodo.Enabled = false;
            this.gbFinPeriodo.Location = new System.Drawing.Point(16, 65);
            this.gbFinPeriodo.Name = "gbFinPeriodo";
            this.gbFinPeriodo.Size = new System.Drawing.Size(318, 158);
            this.gbFinPeriodo.TabIndex = 8;
            this.gbFinPeriodo.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fin :";
            // 
            // dtpFinPeriodo
            // 
            this.dtpFinPeriodo.CustomFormat = " ";
            this.dtpFinPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFinPeriodo.Location = new System.Drawing.Point(98, 28);
            this.dtpFinPeriodo.Name = "dtpFinPeriodo";
            this.dtpFinPeriodo.Size = new System.Drawing.Size(96, 20);
            this.dtpFinPeriodo.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Motivo Fin:";
            // 
            // cboMotivoFinPeriodo
            // 
            this.cboMotivoFinPeriodo.FormattingEnabled = true;
            this.cboMotivoFinPeriodo.Location = new System.Drawing.Point(98, 75);
            this.cboMotivoFinPeriodo.Name = "cboMotivoFinPeriodo";
            this.cboMotivoFinPeriodo.Size = new System.Drawing.Size(200, 21);
            this.cboMotivoFinPeriodo.TabIndex = 9;
            // 
            // chkFinPeriodo
            // 
            this.chkFinPeriodo.AutoSize = true;
            this.chkFinPeriodo.Location = new System.Drawing.Point(22, 55);
            this.chkFinPeriodo.Name = "chkFinPeriodo";
            this.chkFinPeriodo.Size = new System.Drawing.Size(79, 17);
            this.chkFinPeriodo.TabIndex = 9;
            this.chkFinPeriodo.Text = "Fin Periodo";
            this.chkFinPeriodo.UseVisualStyleBackColor = true;
            this.chkFinPeriodo.CheckedChanged += new System.EventHandler(this.chkFinPeriodo_CheckedChanged);
            // 
            // frmNuevoPeriodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 287);
            this.Controls.Add(this.chkFinPeriodo);
            this.Controls.Add(this.gbFinPeriodo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtpInicioPeriodo);
            this.Controls.Add(this.label1);
            this.Name = "frmNuevoPeriodo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Periodo";
            this.Load += new System.EventHandler(this.frmNuevoPeriodo_Load);
            this.gbFinPeriodo.ResumeLayout(false);
            this.gbFinPeriodo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpInicioPeriodo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox gbFinPeriodo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFinPeriodo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMotivoFinPeriodo;
        private System.Windows.Forms.CheckBox chkFinPeriodo;
    }
}