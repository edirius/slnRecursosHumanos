namespace CapaUsuario.Asistencia
{
    partial class frmMantenimientoDiaFestivo
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtNombreDiaFestivo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDiaFestivo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.MintCream;
            this.btnCancelar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelar.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnCancelar.Location = new System.Drawing.Point(208, 108);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 65);
            this.btnCancelar.TabIndex = 91;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.BackColor = System.Drawing.Color.MintCream;
            this.btnAceptar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAceptar.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnAceptar.Location = new System.Drawing.Point(127, 108);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 65);
            this.btnAceptar.TabIndex = 90;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtNombreDiaFestivo
            // 
            this.txtNombreDiaFestivo.Location = new System.Drawing.Point(104, 23);
            this.txtNombreDiaFestivo.Name = "txtNombreDiaFestivo";
            this.txtNombreDiaFestivo.Size = new System.Drawing.Size(178, 20);
            this.txtNombreDiaFestivo.TabIndex = 87;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 86;
            this.label4.Text = "Nombre :";
            // 
            // dtpDiaFestivo
            // 
            this.dtpDiaFestivo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDiaFestivo.Location = new System.Drawing.Point(104, 57);
            this.dtpDiaFestivo.Name = "dtpDiaFestivo";
            this.dtpDiaFestivo.Size = new System.Drawing.Size(108, 20);
            this.dtpDiaFestivo.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 81;
            this.label1.Text = "Dia :";
            // 
            // frmMantenimientoDiaFestivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 185);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtNombreDiaFestivo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpDiaFestivo);
            this.Controls.Add(this.label1);
            this.Name = "frmMantenimientoDiaFestivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Dia Festivo";
            this.Load += new System.EventHandler(this.frmMantenimientoDiaFestivo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtNombreDiaFestivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDiaFestivo;
        private System.Windows.Forms.Label label1;
    }
}