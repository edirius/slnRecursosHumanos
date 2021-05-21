namespace CapaUsuario.Asistencia
{
    partial class frmMantenimientoTurno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoTurno));
            this.label1 = new System.Windows.Forms.Label();
            this.dtpInicioTurno = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFinTurno = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombreTurno = new System.Windows.Forms.TextBox();
            this.numTolerancia = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numTolerancia)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inicio Turno :";
            // 
            // dtpInicioTurno
            // 
            this.dtpInicioTurno.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpInicioTurno.Location = new System.Drawing.Point(107, 57);
            this.dtpInicioTurno.Name = "dtpInicioTurno";
            this.dtpInicioTurno.Size = new System.Drawing.Size(108, 20);
            this.dtpInicioTurno.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fin Turno :";
            // 
            // dtpFinTurno
            // 
            this.dtpFinTurno.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpFinTurno.Location = new System.Drawing.Point(107, 129);
            this.dtpFinTurno.Name = "dtpFinTurno";
            this.dtpFinTurno.Size = new System.Drawing.Size(108, 20);
            this.dtpFinTurno.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tolerancia :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nombre :";
            // 
            // txtNombreTurno
            // 
            this.txtNombreTurno.Location = new System.Drawing.Point(107, 23);
            this.txtNombreTurno.Name = "txtNombreTurno";
            this.txtNombreTurno.Size = new System.Drawing.Size(178, 20);
            this.txtNombreTurno.TabIndex = 6;
            // 
            // numTolerancia
            // 
            this.numTolerancia.Location = new System.Drawing.Point(107, 93);
            this.numTolerancia.Name = "numTolerancia";
            this.numTolerancia.Size = new System.Drawing.Size(47, 20);
            this.numTolerancia.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Minutos";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.MintCream;
            this.btnCancelar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelar.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnCancelar.Location = new System.Drawing.Point(247, 184);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 65);
            this.btnCancelar.TabIndex = 80;
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
            this.btnAceptar.Location = new System.Drawing.Point(166, 184);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 65);
            this.btnAceptar.TabIndex = 79;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmMantenimientoTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 261);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numTolerancia);
            this.Controls.Add(this.txtNombreTurno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpFinTurno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpInicioTurno);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMantenimientoTurno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Turno";
            this.Load += new System.EventHandler(this.frmMantenimientoTurno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numTolerancia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpInicioTurno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFinTurno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombreTurno;
        private System.Windows.Forms.NumericUpDown numTolerancia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
    }
}