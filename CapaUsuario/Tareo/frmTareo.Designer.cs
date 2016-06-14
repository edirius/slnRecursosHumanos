namespace CapaUsuario.Tareo
{
    partial class frmTareo
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
            this.dtgTareos = new System.Windows.Forms.DataGridView();
            this.idttareo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idResidente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblResidente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboListaMetas = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTareos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgTareos
            // 
            this.dtgTareos.AllowUserToAddRows = false;
            this.dtgTareos.AllowUserToDeleteRows = false;
            this.dtgTareos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTareos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idttareo,
            this.nombre,
            this.mes,
            this.idMeta,
            this.fechaInicio,
            this.fechaFin,
            this.idResidente,
            this.tipo});
            this.dtgTareos.Location = new System.Drawing.Point(12, 145);
            this.dtgTareos.Name = "dtgTareos";
            this.dtgTareos.ReadOnly = true;
            this.dtgTareos.Size = new System.Drawing.Size(928, 241);
            this.dtgTareos.TabIndex = 0;
            // 
            // idttareo
            // 
            this.idttareo.DataPropertyName = "idttareo";
            this.idttareo.HeaderText = "idttareo";
            this.idttareo.Name = "idttareo";
            this.idttareo.ReadOnly = true;
            this.idttareo.Visible = false;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Meta";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 500;
            // 
            // mes
            // 
            this.mes.DataPropertyName = "mes";
            this.mes.HeaderText = "Mes";
            this.mes.Name = "mes";
            this.mes.ReadOnly = true;
            // 
            // idMeta
            // 
            this.idMeta.DataPropertyName = "idMeta";
            this.idMeta.HeaderText = "idMeta";
            this.idMeta.Name = "idMeta";
            this.idMeta.ReadOnly = true;
            this.idMeta.Visible = false;
            // 
            // fechaInicio
            // 
            this.fechaInicio.DataPropertyName = "fechaInicio";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.fechaInicio.DefaultCellStyle = dataGridViewCellStyle1;
            this.fechaInicio.HeaderText = "Fecha de Inicio";
            this.fechaInicio.Name = "fechaInicio";
            this.fechaInicio.ReadOnly = true;
            // 
            // fechaFin
            // 
            this.fechaFin.DataPropertyName = "fechaFin";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.fechaFin.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaFin.HeaderText = "Fecha de Fin";
            this.fechaFin.Name = "fechaFin";
            this.fechaFin.ReadOnly = true;
            // 
            // idResidente
            // 
            this.idResidente.DataPropertyName = "idResidente";
            this.idResidente.HeaderText = "idResidente";
            this.idResidente.Name = "idResidente";
            this.idResidente.ReadOnly = true;
            this.idResidente.Visible = false;
            // 
            // tipo
            // 
            this.tipo.DataPropertyName = "tipo";
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(952, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista de Tareos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(64, 409);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(144, 37);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Text = "Nuevo Tareo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(339, 408);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(144, 37);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar Tareo";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(614, 407);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(144, 37);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar Tareo";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // lblResidente
            // 
            this.lblResidente.BackColor = System.Drawing.Color.LightBlue;
            this.lblResidente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResidente.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResidente.Location = new System.Drawing.Point(0, 30);
            this.lblResidente.Name = "lblResidente";
            this.lblResidente.Size = new System.Drawing.Size(952, 30);
            this.lblResidente.TabIndex = 5;
            this.lblResidente.Text = "Residente de Obra";
            this.lblResidente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Meta:";
            // 
            // cboListaMetas
            // 
            this.cboListaMetas.FormattingEnabled = true;
            this.cboListaMetas.Location = new System.Drawing.Point(88, 72);
            this.cboListaMetas.Name = "cboListaMetas";
            this.cboListaMetas.Size = new System.Drawing.Size(714, 21);
            this.cboListaMetas.TabIndex = 7;
            this.cboListaMetas.SelectedIndexChanged += new System.EventHandler(this.cboListaMetas_SelectedIndexChanged);
            // 
            // frmTareo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 462);
            this.Controls.Add(this.cboListaMetas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblResidente);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgTareos);
            this.Name = "frmTareo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tareo";
            this.Load += new System.EventHandler(this.frmTareo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTareos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgTareos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblResidente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboListaMetas;
        private System.Windows.Forms.DataGridViewTextBoxColumn idttareo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn mes;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn idResidente;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
    }
}