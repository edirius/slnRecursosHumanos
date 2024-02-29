namespace CapaUsuario.Usuarios
{
    partial class frmCategoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategoria));
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.checkMenuAFP = new System.Windows.Forms.CheckBox();
            this.checkUsuarios = new System.Windows.Forms.CheckBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CheckMeta = new System.Windows.Forms.CheckBox();
            this.CheckTareos = new System.Windows.Forms.CheckBox();
            this.CheckTrabadores = new System.Windows.Forms.CheckBox();
            this.CheckPlanillas = new System.Windows.Forms.CheckBox();
            this.CheckTablas = new System.Windows.Forms.CheckBox();
            this.CheckExportar = new System.Windows.Forms.CheckBox();
            this.CheckReportes = new System.Windows.Forms.CheckBox();
            this.chkMenuBoletas = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Categoria:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Location = new System.Drawing.Point(70, 21);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(286, 20);
            this.txtDescripcion.TabIndex = 1;
            // 
            // checkMenuAFP
            // 
            this.checkMenuAFP.AutoSize = true;
            this.checkMenuAFP.Location = new System.Drawing.Point(4, 29);
            this.checkMenuAFP.Name = "checkMenuAFP";
            this.checkMenuAFP.Size = new System.Drawing.Size(76, 17);
            this.checkMenuAFP.TabIndex = 1;
            this.checkMenuAFP.Text = "Menu AFP";
            this.checkMenuAFP.UseVisualStyleBackColor = true;
            // 
            // checkUsuarios
            // 
            this.checkUsuarios.AutoSize = true;
            this.checkUsuarios.Location = new System.Drawing.Point(4, 4);
            this.checkUsuarios.Name = "checkUsuarios";
            this.checkUsuarios.Size = new System.Drawing.Size(97, 17);
            this.checkUsuarios.TabIndex = 0;
            this.checkUsuarios.Text = "Menu Usuarios";
            this.checkUsuarios.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(4, 129);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(166, 35);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(177, 129);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(167, 35);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chkMenuBoletas, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.CheckMeta, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.CheckTareos, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.CheckTrabadores, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkUsuarios, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkMenuAFP, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.CheckPlanillas, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.CheckTablas, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.CheckExportar, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.CheckReportes, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 53);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(348, 168);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // CheckMeta
            // 
            this.CheckMeta.AutoSize = true;
            this.CheckMeta.Location = new System.Drawing.Point(4, 104);
            this.CheckMeta.Name = "CheckMeta";
            this.CheckMeta.Size = new System.Drawing.Size(80, 17);
            this.CheckMeta.TabIndex = 8;
            this.CheckMeta.Text = "Menu Meta";
            this.CheckMeta.UseVisualStyleBackColor = true;
            // 
            // CheckTareos
            // 
            this.CheckTareos.AutoSize = true;
            this.CheckTareos.Location = new System.Drawing.Point(4, 79);
            this.CheckTareos.Name = "CheckTareos";
            this.CheckTareos.Size = new System.Drawing.Size(89, 17);
            this.CheckTareos.TabIndex = 3;
            this.CheckTareos.Text = "Menu Tareos";
            this.CheckTareos.UseVisualStyleBackColor = true;
            // 
            // CheckTrabadores
            // 
            this.CheckTrabadores.AutoSize = true;
            this.CheckTrabadores.Location = new System.Drawing.Point(4, 54);
            this.CheckTrabadores.Name = "CheckTrabadores";
            this.CheckTrabadores.Size = new System.Drawing.Size(118, 17);
            this.CheckTrabadores.TabIndex = 2;
            this.CheckTrabadores.Text = "Menu Trabajadores";
            this.CheckTrabadores.UseVisualStyleBackColor = true;
            // 
            // CheckPlanillas
            // 
            this.CheckPlanillas.AutoSize = true;
            this.CheckPlanillas.Location = new System.Drawing.Point(177, 4);
            this.CheckPlanillas.Name = "CheckPlanillas";
            this.CheckPlanillas.Size = new System.Drawing.Size(94, 17);
            this.CheckPlanillas.TabIndex = 4;
            this.CheckPlanillas.Text = "Menu Planillas";
            this.CheckPlanillas.UseVisualStyleBackColor = true;
            // 
            // CheckTablas
            // 
            this.CheckTablas.AutoSize = true;
            this.CheckTablas.Location = new System.Drawing.Point(177, 29);
            this.CheckTablas.Name = "CheckTablas";
            this.CheckTablas.Size = new System.Drawing.Size(152, 17);
            this.CheckTablas.TabIndex = 5;
            this.CheckTablas.Text = "Menu Tablas Parametricas";
            this.CheckTablas.UseVisualStyleBackColor = true;
            // 
            // CheckExportar
            // 
            this.CheckExportar.AutoSize = true;
            this.CheckExportar.Location = new System.Drawing.Point(177, 54);
            this.CheckExportar.Name = "CheckExportar";
            this.CheckExportar.Size = new System.Drawing.Size(126, 17);
            this.CheckExportar.TabIndex = 6;
            this.CheckExportar.Text = "Menu Exportar Datos";
            this.CheckExportar.UseVisualStyleBackColor = true;
            // 
            // CheckReportes
            // 
            this.CheckReportes.AutoSize = true;
            this.CheckReportes.Location = new System.Drawing.Point(177, 79);
            this.CheckReportes.Name = "CheckReportes";
            this.CheckReportes.Size = new System.Drawing.Size(99, 17);
            this.CheckReportes.TabIndex = 7;
            this.CheckReportes.Text = "Menu Reportes";
            this.CheckReportes.UseVisualStyleBackColor = true;
            // 
            // chkMenuBoletas
            // 
            this.chkMenuBoletas.AutoSize = true;
            this.chkMenuBoletas.Location = new System.Drawing.Point(177, 104);
            this.chkMenuBoletas.Name = "chkMenuBoletas";
            this.chkMenuBoletas.Size = new System.Drawing.Size(91, 17);
            this.chkMenuBoletas.TabIndex = 8;
            this.chkMenuBoletas.Text = "Menu Boletas";
            this.chkMenuBoletas.UseVisualStyleBackColor = true;
            // 
            // frmCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 233);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Privilegios de Usuario";
            this.Load += new System.EventHandler(this.frmCategoria_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.CheckBox checkUsuarios;
        private System.Windows.Forms.CheckBox checkMenuAFP;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox CheckTrabadores;
        private System.Windows.Forms.CheckBox CheckTareos;
        private System.Windows.Forms.CheckBox CheckPlanillas;
        private System.Windows.Forms.CheckBox CheckTablas;
        private System.Windows.Forms.CheckBox CheckExportar;
        private System.Windows.Forms.CheckBox CheckReportes;
        private System.Windows.Forms.CheckBox CheckMeta;
        private System.Windows.Forms.CheckBox chkMenuBoletas;
    }
}