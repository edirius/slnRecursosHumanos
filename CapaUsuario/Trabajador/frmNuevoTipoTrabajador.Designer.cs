namespace CapaUsuario.Trabajador
{
    partial class frmNuevoTipoTrabajador
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
            this.chkFinPeriodo = new System.Windows.Forms.CheckBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.dtpInicioPeriodo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTipoTrabajador = new System.Windows.Forms.ComboBox();
            this.dtpFinPeriodo = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // chkFinPeriodo
            // 
            this.chkFinPeriodo.AutoSize = true;
            this.chkFinPeriodo.Location = new System.Drawing.Point(28, 110);
            this.chkFinPeriodo.Name = "chkFinPeriodo";
            this.chkFinPeriodo.Size = new System.Drawing.Size(73, 17);
            this.chkFinPeriodo.TabIndex = 15;
            this.chkFinPeriodo.Text = "Fecha Fin";
            this.chkFinPeriodo.UseVisualStyleBackColor = true;
            this.chkFinPeriodo.CheckedChanged += new System.EventHandler(this.chkFinPeriodo_CheckedChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(259, 168);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(26, 168);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 12;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dtpInicioPeriodo
            // 
            this.dtpInicioPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicioPeriodo.Location = new System.Drawing.Point(120, 69);
            this.dtpInicioPeriodo.Name = "dtpInicioPeriodo";
            this.dtpInicioPeriodo.Size = new System.Drawing.Size(96, 20);
            this.dtpInicioPeriodo.TabIndex = 11;
            this.dtpInicioPeriodo.ValueChanged += new System.EventHandler(this.dtpInicioPeriodo_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Inicio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Tipo Trabajador :";
            // 
            // cboTipoTrabajador
            // 
            this.cboTipoTrabajador.FormattingEnabled = true;
            this.cboTipoTrabajador.Location = new System.Drawing.Point(120, 30);
            this.cboTipoTrabajador.Name = "cboTipoTrabajador";
            this.cboTipoTrabajador.Size = new System.Drawing.Size(257, 21);
            this.cboTipoTrabajador.TabIndex = 17;
            // 
            // dtpFinPeriodo
            // 
            this.dtpFinPeriodo.CustomFormat = " ";
            this.dtpFinPeriodo.Enabled = false;
            this.dtpFinPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFinPeriodo.Location = new System.Drawing.Point(120, 105);
            this.dtpFinPeriodo.Name = "dtpFinPeriodo";
            this.dtpFinPeriodo.Size = new System.Drawing.Size(96, 20);
            this.dtpFinPeriodo.TabIndex = 19;
            // 
            // frmNuevoTipoTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 211);
            this.Controls.Add(this.dtpFinPeriodo);
            this.Controls.Add(this.cboTipoTrabajador);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkFinPeriodo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtpInicioPeriodo);
            this.Controls.Add(this.label1);
            this.Name = "frmNuevoTipoTrabajador";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Tipo Trabajador";
            this.Load += new System.EventHandler(this.frmNuevoTipoTrabajador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkFinPeriodo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DateTimePicker dtpInicioPeriodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTipoTrabajador;
        private System.Windows.Forms.DateTimePicker dtpFinPeriodo;
    }
}