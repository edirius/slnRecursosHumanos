namespace CapaUsuario.Trabajador
{
    partial class frmProvincia
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
            this.dtgListaProvincias = new System.Windows.Forms.DataGridView();
            this.idttprovincia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtdepartamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoUbigeo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaProvincias)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListaProvincias
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtgListaProvincias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaProvincias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaProvincias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idttprovincia,
            this.idtdepartamento,
            this.codigoUbigeo,
            this.descripcion});
            this.dtgListaProvincias.Location = new System.Drawing.Point(12, 12);
            this.dtgListaProvincias.MultiSelect = false;
            this.dtgListaProvincias.Name = "dtgListaProvincias";
            this.dtgListaProvincias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaProvincias.Size = new System.Drawing.Size(480, 237);
            this.dtgListaProvincias.TabIndex = 0;
            this.dtgListaProvincias.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgListaProvincias_KeyDown);
            // 
            // idttprovincia
            // 
            this.idttprovincia.DataPropertyName = "idtprovincia";
            this.idttprovincia.HeaderText = "Codigo";
            this.idttprovincia.Name = "idttprovincia";
            this.idttprovincia.Width = 50;
            // 
            // idtdepartamento
            // 
            this.idtdepartamento.DataPropertyName = "idtdepartamento";
            this.idtdepartamento.HeaderText = "Codigo Departamento";
            this.idtdepartamento.Name = "idtdepartamento";
            this.idtdepartamento.Visible = false;
            // 
            // codigoUbigeo
            // 
            this.codigoUbigeo.DataPropertyName = "codigoubigeo";
            this.codigoUbigeo.HeaderText = "Ubigeo";
            this.codigoUbigeo.Name = "codigoUbigeo";
            this.codigoUbigeo.Width = 50;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.Width = 300;
            // 
            // frmProvincia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 260);
            this.Controls.Add(this.dtgListaProvincias);
            this.Name = "frmProvincia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Provincias";
            this.Load += new System.EventHandler(this.frmProvincia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaProvincias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgListaProvincias;
        private System.Windows.Forms.DataGridViewTextBoxColumn idttprovincia;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtdepartamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoUbigeo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
    }
}