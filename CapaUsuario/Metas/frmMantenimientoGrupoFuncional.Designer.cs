namespace CapaUsuario.Metas
{
    partial class frmMantenimientoGrupoFuncional
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoGrupoFuncional));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.numAño = new System.Windows.Forms.NumericUpDown();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblFuncion = new System.Windows.Forms.Label();
            this.lblDivisionFuncional = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numAño)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Año:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(75, 81);
            this.txtCodigo.MaxLength = 8;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(80, 20);
            this.txtCodigo.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(75, 126);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(397, 20);
            this.txtNombre.TabIndex = 4;
            // 
            // numAño
            // 
            this.numAño.Location = new System.Drawing.Point(75, 168);
            this.numAño.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.numAño.Name = "numAño";
            this.numAño.Size = new System.Drawing.Size(58, 20);
            this.numAño.TabIndex = 5;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.MintCream;
            this.btnCancelar.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelar.Location = new System.Drawing.Point(337, 209);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 55);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.MintCream;
            this.btnAceptar.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAceptar.Location = new System.Drawing.Point(63, 209);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(97, 55);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblFuncion
            // 
            this.lblFuncion.BackColor = System.Drawing.Color.LightBlue;
            this.lblFuncion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFuncion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFuncion.Location = new System.Drawing.Point(0, 0);
            this.lblFuncion.Name = "lblFuncion";
            this.lblFuncion.Size = new System.Drawing.Size(523, 29);
            this.lblFuncion.TabIndex = 12;
            this.lblFuncion.Text = "label4";
            this.lblFuncion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDivisionFuncional
            // 
            this.lblDivisionFuncional.BackColor = System.Drawing.Color.LightBlue;
            this.lblDivisionFuncional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDivisionFuncional.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDivisionFuncional.Location = new System.Drawing.Point(0, 29);
            this.lblDivisionFuncional.Name = "lblDivisionFuncional";
            this.lblDivisionFuncional.Size = new System.Drawing.Size(523, 29);
            this.lblDivisionFuncional.TabIndex = 13;
            this.lblDivisionFuncional.Text = "label4";
            this.lblDivisionFuncional.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMantenimientoGrupoFuncional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 289);
            this.Controls.Add(this.lblDivisionFuncional);
            this.Controls.Add(this.lblFuncion);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.numAño);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMantenimientoGrupoFuncional";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Grupo Funcional";
            this.Load += new System.EventHandler(this.frmMantenimientoGrupoFuncional_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAño)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.NumericUpDown numAño;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblFuncion;
        private System.Windows.Forms.Label lblDivisionFuncional;
    }
}