namespace CapaUsuario.Trabajador
{
    partial class frmTipoVia
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgListaTipoVia = new System.Windows.Forms.DataGridView();
            this.idttipovia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoSunat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTipoVia)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListaTipoVia
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.dtgListaTipoVia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaTipoVia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaTipoVia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idttipovia,
            this.codigoSunat,
            this.descripcion});
            this.dtgListaTipoVia.Location = new System.Drawing.Point(12, 12);
            this.dtgListaTipoVia.MultiSelect = false;
            this.dtgListaTipoVia.Name = "dtgListaTipoVia";
            this.dtgListaTipoVia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaTipoVia.Size = new System.Drawing.Size(496, 241);
            this.dtgListaTipoVia.TabIndex = 0;
            this.dtgListaTipoVia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgListaTipoVia_KeyDown);
            // 
            // idttipovia
            // 
            this.idttipovia.DataPropertyName = "idttipovia";
            this.idttipovia.HeaderText = "Codigo";
            this.idttipovia.Name = "idttipovia";
            this.idttipovia.Width = 50;
            // 
            // codigoSunat
            // 
            this.codigoSunat.DataPropertyName = "codigosunat";
            this.codigoSunat.HeaderText = "Codigo Sunat";
            this.codigoSunat.Name = "codigoSunat";
            this.codigoSunat.Width = 50;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.Width = 300;
            // 
            // frmTipoVia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 264);
            this.Controls.Add(this.dtgListaTipoVia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTipoVia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elija Tipo de Via";
            this.Load += new System.EventHandler(this.frmTipoVia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTipoVia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgListaTipoVia;
        private System.Windows.Forms.DataGridViewTextBoxColumn idttipovia;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoSunat;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
    }
}