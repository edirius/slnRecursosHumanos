namespace CapaUsuario.Metas
{
    partial class frmMantenimientoActividadObra
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
            this.lblProgramaPresupuestal = new System.Windows.Forms.Label();
            this.lblProductoProyecto = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numAño = new System.Windows.Forms.NumericUpDown();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAño)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProgramaPresupuestal
            // 
            this.lblProgramaPresupuestal.BackColor = System.Drawing.Color.LightBlue;
            this.lblProgramaPresupuestal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProgramaPresupuestal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProgramaPresupuestal.Location = new System.Drawing.Point(0, 0);
            this.lblProgramaPresupuestal.Name = "lblProgramaPresupuestal";
            this.lblProgramaPresupuestal.Size = new System.Drawing.Size(421, 30);
            this.lblProgramaPresupuestal.TabIndex = 0;
            this.lblProgramaPresupuestal.Text = "label1";
            this.lblProgramaPresupuestal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProductoProyecto
            // 
            this.lblProductoProyecto.BackColor = System.Drawing.Color.LightBlue;
            this.lblProductoProyecto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProductoProyecto.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProductoProyecto.Location = new System.Drawing.Point(0, 30);
            this.lblProductoProyecto.Name = "lblProductoProyecto";
            this.lblProductoProyecto.Size = new System.Drawing.Size(421, 30);
            this.lblProductoProyecto.TabIndex = 1;
            this.lblProductoProyecto.Text = "label1";
            this.lblProductoProyecto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Codigo:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(86, 69);
            this.txtCodigo.MaxLength = 8;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(68, 20);
            this.txtCodigo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(86, 111);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(323, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Año:";
            // 
            // numAño
            // 
            this.numAño.Location = new System.Drawing.Point(86, 151);
            this.numAño.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.numAño.Name = "numAño";
            this.numAño.Size = new System.Drawing.Size(68, 20);
            this.numAño.TabIndex = 7;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(293, 200);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 30);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(19, 200);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(97, 30);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmMantenimientoActividadObra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 260);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.numAño);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblProductoProyecto);
            this.Controls.Add(this.lblProgramaPresupuestal);
            this.Name = "frmMantenimientoActividadObra";
            this.Text = "frmMantenimientoActividadObra";
            this.Load += new System.EventHandler(this.frmMantenimientoActividadObra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAño)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProgramaPresupuestal;
        private System.Windows.Forms.Label lblProductoProyecto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numAño;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
    }
}