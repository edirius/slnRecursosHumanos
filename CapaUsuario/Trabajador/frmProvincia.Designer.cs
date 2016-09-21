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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProvincia));
            this.dtgListaProvincias = new System.Windows.Forms.DataGridView();
            this.toolProvincia = new System.Windows.Forms.ToolTip(this.components);
            this.idttprovincia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoUbigeo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtdepartamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaProvincias)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListaProvincias
            // 
            this.dtgListaProvincias.AllowUserToAddRows = false;
            this.dtgListaProvincias.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtgListaProvincias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaProvincias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaProvincias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idttprovincia,
            this.codigoUbigeo,
            this.descripcion,
            this.idtdepartamento});
            this.dtgListaProvincias.Location = new System.Drawing.Point(12, 12);
            this.dtgListaProvincias.MultiSelect = false;
            this.dtgListaProvincias.Name = "dtgListaProvincias";
            this.dtgListaProvincias.ReadOnly = true;
            this.dtgListaProvincias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaProvincias.Size = new System.Drawing.Size(480, 293);
            this.dtgListaProvincias.TabIndex = 0;
            this.dtgListaProvincias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaProvincias_CellContentClick);
            this.dtgListaProvincias.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgListaProvincias_KeyDown);
            this.dtgListaProvincias.MouseEnter += new System.EventHandler(this.dtgListaProvincias_MouseEnter);
            // 
            // idttprovincia
            // 
            this.idttprovincia.DataPropertyName = "idtprovincia";
            this.idttprovincia.HeaderText = "Codigo";
            this.idttprovincia.Name = "idttprovincia";
            this.idttprovincia.ReadOnly = true;
            this.idttprovincia.Width = 50;
            // 
            // codigoUbigeo
            // 
            this.codigoUbigeo.DataPropertyName = "codigoubigeo";
            this.codigoUbigeo.HeaderText = "Ubigeo";
            this.codigoUbigeo.Name = "codigoUbigeo";
            this.codigoUbigeo.ReadOnly = true;
            this.codigoUbigeo.Width = 50;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 300;
            // 
            // idtdepartamento
            // 
            this.idtdepartamento.DataPropertyName = "codigoDepartamento";
            this.idtdepartamento.HeaderText = "Codigo Departamento";
            this.idtdepartamento.Name = "idtdepartamento";
            this.idtdepartamento.ReadOnly = true;
            this.idtdepartamento.Visible = false;
            // 
            // frmProvincia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 317);
            this.Controls.Add(this.dtgListaProvincias);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProvincia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Provincias";
            this.Load += new System.EventHandler(this.frmProvincia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaProvincias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgListaProvincias;
        private System.Windows.Forms.ToolTip toolProvincia;
        private System.Windows.Forms.DataGridViewTextBoxColumn idttprovincia;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoUbigeo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtdepartamento;
    }
}