namespace CapaUsuario.ExportarSunat
{
    partial class frmIngresosTributosDescuentos
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
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.dgvDescripcion = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescripcion)).BeginInit();
            this.SuspendLayout();
            // 
            // cbTipo
            // 
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "INGRESOS (0100)",
            "INGRESOS : ASIGNACIONES (0200)",
            "INGRESOS : BONIFICACIONES (0300)",
            "INGRESOS : GRATIFICACIONES/AGUINALDOS (0400)",
            "INGRESOS : INDEMNIZACIONES (0500)",
            "CONCEPTOS VARIOS (0900)",
            "OTROS CONCEPTOS (1000)",
            "RÉGIMEN LABORAL PÚBLICO (2000)"});
            this.cbTipo.Location = new System.Drawing.Point(12, 12);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(345, 21);
            this.cbTipo.TabIndex = 0;
            this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.cbTipo_SelectedIndexChanged);
            // 
            // dgvDescripcion
            // 
            this.dgvDescripcion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDescripcion.Location = new System.Drawing.Point(11, 41);
            this.dgvDescripcion.Name = "dgvDescripcion";
            this.dgvDescripcion.Size = new System.Drawing.Size(345, 293);
            this.dgvDescripcion.TabIndex = 1;
            // 
            // frmIngresosTributosDescuentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 347);
            this.Controls.Add(this.dgvDescripcion);
            this.Controls.Add(this.cbTipo);
            this.Name = "frmIngresosTributosDescuentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmIngresosTributosDescuentos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescripcion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.DataGridView dgvDescripcion;
    }
}