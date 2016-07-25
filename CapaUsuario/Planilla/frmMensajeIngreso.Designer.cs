namespace CapaUsuario.Planilla
{
    partial class frmMensajeIngreso
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
            this.rbtMaestroIngresos = new System.Windows.Forms.RadioButton();
            this.rbtMaestroATrabajador = new System.Windows.Forms.RadioButton();
            this.rbtMaestroAEmpleador = new System.Windows.Forms.RadioButton();
            this.rbtMaestroDescuentos = new System.Windows.Forms.RadioButton();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtMaestroIngresos
            // 
            this.rbtMaestroIngresos.AutoSize = true;
            this.rbtMaestroIngresos.Location = new System.Drawing.Point(6, 18);
            this.rbtMaestroIngresos.Name = "rbtMaestroIngresos";
            this.rbtMaestroIngresos.Size = new System.Drawing.Size(65, 17);
            this.rbtMaestroIngresos.TabIndex = 0;
            this.rbtMaestroIngresos.TabStop = true;
            this.rbtMaestroIngresos.Text = "Ingresos";
            this.rbtMaestroIngresos.UseVisualStyleBackColor = true;
            this.rbtMaestroIngresos.CheckedChanged += new System.EventHandler(this.rbtMaestroIngresos_CheckedChanged);
            // 
            // rbtMaestroATrabajador
            // 
            this.rbtMaestroATrabajador.AutoSize = true;
            this.rbtMaestroATrabajador.Location = new System.Drawing.Point(165, 18);
            this.rbtMaestroATrabajador.Name = "rbtMaestroATrabajador";
            this.rbtMaestroATrabajador.Size = new System.Drawing.Size(141, 17);
            this.rbtMaestroATrabajador.TabIndex = 1;
            this.rbtMaestroATrabajador.TabStop = true;
            this.rbtMaestroATrabajador.Text = "Aportaciones Trabajador";
            this.rbtMaestroATrabajador.UseVisualStyleBackColor = true;
            this.rbtMaestroATrabajador.CheckedChanged += new System.EventHandler(this.rbtMaestroATrabajador_CheckedChanged);
            // 
            // rbtMaestroAEmpleador
            // 
            this.rbtMaestroAEmpleador.AutoSize = true;
            this.rbtMaestroAEmpleador.Location = new System.Drawing.Point(312, 18);
            this.rbtMaestroAEmpleador.Name = "rbtMaestroAEmpleador";
            this.rbtMaestroAEmpleador.Size = new System.Drawing.Size(140, 17);
            this.rbtMaestroAEmpleador.TabIndex = 2;
            this.rbtMaestroAEmpleador.TabStop = true;
            this.rbtMaestroAEmpleador.Text = "Aportaciones Empleador";
            this.rbtMaestroAEmpleador.UseVisualStyleBackColor = true;
            this.rbtMaestroAEmpleador.CheckedChanged += new System.EventHandler(this.rbtMaestroAEmpleador_CheckedChanged);
            // 
            // rbtMaestroDescuentos
            // 
            this.rbtMaestroDescuentos.AutoSize = true;
            this.rbtMaestroDescuentos.Location = new System.Drawing.Point(77, 18);
            this.rbtMaestroDescuentos.Name = "rbtMaestroDescuentos";
            this.rbtMaestroDescuentos.Size = new System.Drawing.Size(82, 17);
            this.rbtMaestroDescuentos.TabIndex = 3;
            this.rbtMaestroDescuentos.TabStop = true;
            this.rbtMaestroDescuentos.Text = "Descuentos";
            this.rbtMaestroDescuentos.UseVisualStyleBackColor = true;
            this.rbtMaestroDescuentos.CheckedChanged += new System.EventHandler(this.rbtMaestroDescuentos_CheckedChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.MintCream;
            this.btnSalir.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSalir.ImageKey = "ssss.png";
            this.btnSalir.Location = new System.Drawing.Point(385, 59);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(83, 25);
            this.btnSalir.TabIndex = 31;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtMaestroIngresos);
            this.groupBox1.Controls.Add(this.rbtMaestroATrabajador);
            this.groupBox1.Controls.Add(this.rbtMaestroDescuentos);
            this.groupBox1.Controls.Add(this.rbtMaestroAEmpleador);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 41);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione lo que desea  Agregar";
            // 
            // frmMensajeIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 89);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMensajeIngreso";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecciones lo que desea Agregar";
            this.Load += new System.EventHandler(this.frmMensajeIngreso_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtMaestroIngresos;
        private System.Windows.Forms.RadioButton rbtMaestroATrabajador;
        private System.Windows.Forms.RadioButton rbtMaestroAEmpleador;
        private System.Windows.Forms.RadioButton rbtMaestroDescuentos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}