namespace CapaUsuario.Trabajador
{
    partial class frmListaContratos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgContratos = new System.Windows.Forms.DataGridView();
            this.idtContrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colnumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtsunattipotrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colfechainicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colidMeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtMeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colidTrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Meses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgContratos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgContratos);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(442, 140);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lista de Contratos";
            // 
            // dtgContratos
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dtgContratos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgContratos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgContratos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtContrato,
            this.colnumero,
            this.idtsunattipotrabajador,
            this.colfechainicio,
            this.colFechaFinal,
            this.colidMeta,
            this.idtMeta,
            this.colidTrabajador,
            this.Meses});
            this.dtgContratos.Location = new System.Drawing.Point(21, 19);
            this.dtgContratos.Name = "dtgContratos";
            this.dtgContratos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgContratos.Size = new System.Drawing.Size(367, 106);
            this.dtgContratos.TabIndex = 0;
            // 
            // idtContrato
            // 
            this.idtContrato.DataPropertyName = "idtContrato";
            this.idtContrato.HeaderText = "idtContrato";
            this.idtContrato.Name = "idtContrato";
            this.idtContrato.Visible = false;
            // 
            // colnumero
            // 
            this.colnumero.DataPropertyName = "numero";
            this.colnumero.HeaderText = "N°";
            this.colnumero.Name = "colnumero";
            this.colnumero.Width = 50;
            // 
            // idtsunattipotrabajador
            // 
            this.idtsunattipotrabajador.DataPropertyName = "idtsunattipotrabajador";
            this.idtsunattipotrabajador.HeaderText = "idtsunattipotrabajador";
            this.idtsunattipotrabajador.Name = "idtsunattipotrabajador";
            this.idtsunattipotrabajador.Visible = false;
            // 
            // colfechainicio
            // 
            this.colfechainicio.DataPropertyName = "fechainicio";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.colfechainicio.DefaultCellStyle = dataGridViewCellStyle2;
            this.colfechainicio.HeaderText = "Fecha Inicio";
            this.colfechainicio.Name = "colfechainicio";
            // 
            // colFechaFinal
            // 
            this.colFechaFinal.DataPropertyName = "fechafinal";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.colFechaFinal.DefaultCellStyle = dataGridViewCellStyle3;
            this.colFechaFinal.HeaderText = "Fecha Fin";
            this.colFechaFinal.Name = "colFechaFinal";
            // 
            // colidMeta
            // 
            this.colidMeta.DataPropertyName = "idmeta";
            this.colidMeta.HeaderText = "idMeta";
            this.colidMeta.Name = "colidMeta";
            this.colidMeta.Visible = false;
            // 
            // idtMeta
            // 
            this.idtMeta.DataPropertyName = "idtmeta";
            this.idtMeta.HeaderText = "idtMeta";
            this.idtMeta.Name = "idtMeta";
            this.idtMeta.Visible = false;
            // 
            // colidTrabajador
            // 
            this.colidTrabajador.DataPropertyName = "idttrabajador";
            this.colidTrabajador.HeaderText = "colidTrabajador";
            this.colidTrabajador.Name = "colidTrabajador";
            this.colidTrabajador.Visible = false;
            // 
            // Meses
            // 
            this.Meses.DataPropertyName = "MESES";
            this.Meses.HeaderText = "Meses";
            this.Meses.Name = "Meses";
            this.Meses.Width = 50;
            // 
            // frmListaContratos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 175);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmListaContratos";
            this.Text = "Lista de Contratos";
            this.Load += new System.EventHandler(this.frmListaContratos_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgContratos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgContratos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtContrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn colnumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtsunattipotrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colfechainicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colidMeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtMeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colidTrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Meses;
    }
}