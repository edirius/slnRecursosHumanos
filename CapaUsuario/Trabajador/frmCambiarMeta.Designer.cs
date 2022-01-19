namespace CapaUsuario.Trabajador
{
    partial class frmCambiarMeta
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboMeta = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblNombredelTrabajador = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.cboAño);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cboMeta);
            this.groupBox3.Location = new System.Drawing.Point(9, 41);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(518, 56);
            this.groupBox3.TabIndex = 63;
            this.groupBox3.TabStop = false;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(98, 13);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(37, 13);
            this.label28.TabIndex = 11;
            this.label28.Text = "Meta :";
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(6, 29);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(89, 21);
            this.cboAño.TabIndex = 82;
            this.cboAño.SelectedIndexChanged += new System.EventHandler(this.cboAño_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 83;
            this.label6.Text = "Año :";
            // 
            // cboMeta
            // 
            this.cboMeta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMeta.FormattingEnabled = true;
            this.cboMeta.Location = new System.Drawing.Point(101, 29);
            this.cboMeta.Name = "cboMeta";
            this.cboMeta.Size = new System.Drawing.Size(411, 21);
            this.cboMeta.TabIndex = 15;
            this.cboMeta.SelectedIndexChanged += new System.EventHandler(this.cboMeta_SelectedIndexChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAceptar.Location = new System.Drawing.Point(268, 119);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(104, 33);
            this.btnAceptar.TabIndex = 64;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelar.Location = new System.Drawing.Point(417, 119);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 33);
            this.btnCancelar.TabIndex = 65;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblNombredelTrabajador
            // 
            this.lblNombredelTrabajador.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblNombredelTrabajador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNombredelTrabajador.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNombredelTrabajador.Location = new System.Drawing.Point(0, 0);
            this.lblNombredelTrabajador.Name = "lblNombredelTrabajador";
            this.lblNombredelTrabajador.Size = new System.Drawing.Size(559, 23);
            this.lblNombredelTrabajador.TabIndex = 78;
            this.lblNombredelTrabajador.Text = "Lista Cargos";
            this.lblNombredelTrabajador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmCambiarMeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 168);
            this.Controls.Add(this.lblNombredelTrabajador);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox3);
            this.Name = "frmCambiarMeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar Meta";
            this.Load += new System.EventHandler(this.frmCambiarMeta_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboMeta;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblNombredelTrabajador;
    }
}