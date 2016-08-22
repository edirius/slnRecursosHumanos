namespace CapaUsuario.TablasParametricas
{
    partial class frmTributosyDescuentosTrabajador
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
            this.dgvExportar = new System.Windows.Forms.DataGridView();
            this.txtIdPlanilla = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvExportar
            // 
            this.dgvExportar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExportar.Location = new System.Drawing.Point(31, 100);
            this.dgvExportar.Name = "dgvExportar";
            this.dgvExportar.Size = new System.Drawing.Size(547, 269);
            this.dgvExportar.TabIndex = 0;
            // 
            // txtIdPlanilla
            // 
            this.txtIdPlanilla.Location = new System.Drawing.Point(31, 52);
            this.txtIdPlanilla.Name = "txtIdPlanilla";
            this.txtIdPlanilla.Size = new System.Drawing.Size(100, 20);
            this.txtIdPlanilla.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(179, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cboTipo
            // 
            this.cboTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "INGRESOS (0100)",
            "INGRESOS : ASIGNACIONES (0200)",
            "INGRESOS : BONIFICACIONES (0300)",
            "INGRESOS : GRATIFICACIONES/AGUINALDOS (0400)",
            "INGRESOS : INDEMNIZACIONES (0500)",
            "CONCEPTOS VARIOS (0900)",
            "OTROS CONCEPTOS (1000)",
            "RÉGIMEN LABORAL PÚBLICO (2000)"});
            this.cboTipo.Location = new System.Drawing.Point(31, 12);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(455, 21);
            this.cboTipo.TabIndex = 3;
            // 
            // frmTributosyDescuentosTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 465);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtIdPlanilla);
            this.Controls.Add(this.dgvExportar);
            this.Name = "frmTributosyDescuentosTrabajador";
            this.Text = "frmTributosyDescuentosTrabajador";
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvExportar;
        private System.Windows.Forms.TextBox txtIdPlanilla;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboTipo;
    }
}