namespace CapaUsuario.Trabajador
{
    partial class frmDepartamento
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
            this.dtgListaDepartamento = new System.Windows.Forms.DataGridView();
            this.idtdepartamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoUbigeo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolDepartamento = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaDepartamento)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListaDepartamento
            // 
            this.dtgListaDepartamento.AllowUserToAddRows = false;
            this.dtgListaDepartamento.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtgListaDepartamento.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaDepartamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaDepartamento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtdepartamento,
            this.codigoUbigeo,
            this.descripcion});
            this.dtgListaDepartamento.Location = new System.Drawing.Point(12, 12);
            this.dtgListaDepartamento.MultiSelect = false;
            this.dtgListaDepartamento.Name = "dtgListaDepartamento";
            this.dtgListaDepartamento.ReadOnly = true;
            this.dtgListaDepartamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaDepartamento.Size = new System.Drawing.Size(467, 229);
            this.dtgListaDepartamento.TabIndex = 0;
            this.dtgListaDepartamento.Enter += new System.EventHandler(this.dtgListaDepartamento_Enter);
            this.dtgListaDepartamento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgListaDepartamento_KeyDown);
            this.dtgListaDepartamento.MouseEnter += new System.EventHandler(this.dtgListaDepartamento_MouseEnter);
            // 
            // idtdepartamento
            // 
            this.idtdepartamento.DataPropertyName = "idtdepartamento";
            this.idtdepartamento.HeaderText = "Codigo";
            this.idtdepartamento.Name = "idtdepartamento";
            this.idtdepartamento.ReadOnly = true;
            this.idtdepartamento.Width = 50;
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
            // frmDepartamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 254);
            this.Controls.Add(this.dtgListaDepartamento);
            this.Name = "frmDepartamento";
            this.Text = "Lista de Departamentos";
            this.Load += new System.EventHandler(this.frmDepartamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaDepartamento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgListaDepartamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtdepartamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoUbigeo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.ToolTip toolDepartamento;
    }
}