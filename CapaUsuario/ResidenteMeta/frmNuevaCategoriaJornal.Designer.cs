﻿namespace CapaUsuario.ResidenteMeta
{
    partial class frmNuevaCategoriaJornal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaCategoriaJornal));
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboOpcion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMensual = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreCategoria = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.BackColor = System.Drawing.Color.MintCream;
            this.btnAceptar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAceptar.ImageIndex = 1;
            this.btnAceptar.Location = new System.Drawing.Point(152, 194);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(92, 53);
            this.btnAceptar.TabIndex = 90;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.MintCream;
            this.btnCancelar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelar.ImageIndex = 1;
            this.btnCancelar.Location = new System.Drawing.Point(301, 194);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(92, 53);
            this.btnCancelar.TabIndex = 91;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboOpcion);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtMensual);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtMonto);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNombreCategoria);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 169);
            this.panel1.TabIndex = 96;
            // 
            // cboOpcion
            // 
            this.cboOpcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOpcion.FormattingEnabled = true;
            this.cboOpcion.Items.AddRange(new object[] {
            "Jornal",
            "Mensual"});
            this.cboOpcion.Location = new System.Drawing.Point(103, 115);
            this.cboOpcion.Name = "cboOpcion";
            this.cboOpcion.Size = new System.Drawing.Size(121, 21);
            this.cboOpcion.TabIndex = 103;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 102;
            this.label4.Text = "Opcion :";
            // 
            // txtMensual
            // 
            this.txtMensual.Location = new System.Drawing.Point(103, 80);
            this.txtMensual.MaxLength = 11;
            this.txtMensual.Name = "txtMensual";
            this.txtMensual.Size = new System.Drawing.Size(100, 20);
            this.txtMensual.TabIndex = 101;
            this.txtMensual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMensual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMensual_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 100;
            this.label3.Text = "Monto Mensual :";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(103, 45);
            this.txtMonto.MaxLength = 11;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 99;
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 98;
            this.label2.Text = "Monto Jornal :";
            // 
            // txtNombreCategoria
            // 
            this.txtNombreCategoria.Location = new System.Drawing.Point(103, 13);
            this.txtNombreCategoria.MaxLength = 45;
            this.txtNombreCategoria.Name = "txtNombreCategoria";
            this.txtNombreCategoria.Size = new System.Drawing.Size(268, 20);
            this.txtNombreCategoria.TabIndex = 97;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 96;
            this.label1.Text = "Nueva Categoria :";
            // 
            // frmNuevaCategoriaJornal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 259);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNuevaCategoriaJornal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva/Modificar Categoria Jornal";
            this.Load += new System.EventHandler(this.frmNuevaCategoriaJornal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboOpcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMensual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreCategoria;
        private System.Windows.Forms.Label label1;
    }
}