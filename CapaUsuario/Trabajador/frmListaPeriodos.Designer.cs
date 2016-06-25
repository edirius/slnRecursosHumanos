namespace CapaUsuario.Trabajador
{
    partial class frmListaPeriodos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaPeriodos));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEliminarPeriodo = new System.Windows.Forms.Button();
            this.btnModificarPeriodo = new System.Windows.Forms.Button();
            this.btnNuevoPeriodo = new System.Windows.Forms.Button();
            this.dtgPeriodos = new System.Windows.Forms.DataGridView();
            this.codigoPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtMotivoFinPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoSunat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MotivoFinPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtmotivofinperiodo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPeriodos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEliminarPeriodo);
            this.groupBox1.Controls.Add(this.btnModificarPeriodo);
            this.groupBox1.Controls.Add(this.btnNuevoPeriodo);
            this.groupBox1.Controls.Add(this.dtgPeriodos);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 146);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Periodo";
            // 
            // btnEliminarPeriodo
            // 
            this.btnEliminarPeriodo.Location = new System.Drawing.Point(472, 91);
            this.btnEliminarPeriodo.Name = "btnEliminarPeriodo";
            this.btnEliminarPeriodo.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarPeriodo.TabIndex = 3;
            this.btnEliminarPeriodo.Text = "Eliminar";
            this.btnEliminarPeriodo.UseVisualStyleBackColor = true;
            this.btnEliminarPeriodo.Click += new System.EventHandler(this.btnEliminarPeriodo_Click);
            // 
            // btnModificarPeriodo
            // 
            this.btnModificarPeriodo.Location = new System.Drawing.Point(472, 50);
            this.btnModificarPeriodo.Name = "btnModificarPeriodo";
            this.btnModificarPeriodo.Size = new System.Drawing.Size(75, 23);
            this.btnModificarPeriodo.TabIndex = 2;
            this.btnModificarPeriodo.Text = "Modificar";
            this.btnModificarPeriodo.UseVisualStyleBackColor = true;
            this.btnModificarPeriodo.Click += new System.EventHandler(this.btnModificarPeriodo_Click);
            // 
            // btnNuevoPeriodo
            // 
            this.btnNuevoPeriodo.Location = new System.Drawing.Point(472, 10);
            this.btnNuevoPeriodo.Name = "btnNuevoPeriodo";
            this.btnNuevoPeriodo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoPeriodo.TabIndex = 1;
            this.btnNuevoPeriodo.Text = "Nuevo";
            this.btnNuevoPeriodo.UseVisualStyleBackColor = true;
            this.btnNuevoPeriodo.Click += new System.EventHandler(this.btnNuevoPeriodo_Click);
            // 
            // dtgPeriodos
            // 
            this.dtgPeriodos.AllowUserToAddRows = false;
            this.dtgPeriodos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dtgPeriodos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgPeriodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPeriodos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoPeriodo,
            this.idTrabajador,
            this.fechaInicio,
            this.idtMotivoFinPeriodo,
            this.codigoSunat,
            this.fechaFin,
            this.MotivoFinPeriodo,
            this.idtmotivofinperiodo2});
            this.dtgPeriodos.Location = new System.Drawing.Point(21, 19);
            this.dtgPeriodos.Name = "dtgPeriodos";
            this.dtgPeriodos.ReadOnly = true;
            this.dtgPeriodos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPeriodos.Size = new System.Drawing.Size(434, 106);
            this.dtgPeriodos.TabIndex = 0;
            // 
            // codigoPeriodo
            // 
            this.codigoPeriodo.DataPropertyName = "idtPeriodo";
            this.codigoPeriodo.HeaderText = "Codigo";
            this.codigoPeriodo.Name = "codigoPeriodo";
            this.codigoPeriodo.ReadOnly = true;
            this.codigoPeriodo.Visible = false;
            this.codigoPeriodo.Width = 50;
            // 
            // idTrabajador
            // 
            this.idTrabajador.DataPropertyName = "idtTrabajador";
            this.idTrabajador.HeaderText = "idtTrabajador";
            this.idTrabajador.Name = "idTrabajador";
            this.idTrabajador.ReadOnly = true;
            this.idTrabajador.Visible = false;
            // 
            // fechaInicio
            // 
            this.fechaInicio.DataPropertyName = "fechaInicio";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.fechaInicio.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaInicio.HeaderText = "Fecha Inicio";
            this.fechaInicio.Name = "fechaInicio";
            this.fechaInicio.ReadOnly = true;
            this.fechaInicio.Width = 80;
            // 
            // idtMotivoFinPeriodo
            // 
            this.idtMotivoFinPeriodo.DataPropertyName = "idtMotivoFinPeriodo1";
            this.idtMotivoFinPeriodo.HeaderText = "idtMotivoFinPeriodo";
            this.idtMotivoFinPeriodo.Name = "idtMotivoFinPeriodo";
            this.idtMotivoFinPeriodo.ReadOnly = true;
            this.idtMotivoFinPeriodo.Visible = false;
            // 
            // codigoSunat
            // 
            this.codigoSunat.DataPropertyName = "codigosunat";
            this.codigoSunat.HeaderText = "codigoSunat";
            this.codigoSunat.Name = "codigoSunat";
            this.codigoSunat.ReadOnly = true;
            this.codigoSunat.Visible = false;
            // 
            // fechaFin
            // 
            this.fechaFin.DataPropertyName = "Fechafin";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.fechaFin.DefaultCellStyle = dataGridViewCellStyle3;
            this.fechaFin.HeaderText = "Fecha Fin";
            this.fechaFin.Name = "fechaFin";
            this.fechaFin.ReadOnly = true;
            this.fechaFin.Width = 80;
            // 
            // MotivoFinPeriodo
            // 
            this.MotivoFinPeriodo.DataPropertyName = "descripcion";
            this.MotivoFinPeriodo.HeaderText = "Motivo Fin Periodo";
            this.MotivoFinPeriodo.Name = "MotivoFinPeriodo";
            this.MotivoFinPeriodo.ReadOnly = true;
            this.MotivoFinPeriodo.Width = 200;
            // 
            // idtmotivofinperiodo2
            // 
            this.idtmotivofinperiodo2.DataPropertyName = "idtmotivofinperiodo";
            this.idtmotivofinperiodo2.HeaderText = "idtmotivofinperiodo";
            this.idtmotivofinperiodo2.Name = "idtmotivofinperiodo2";
            this.idtmotivofinperiodo2.ReadOnly = true;
            this.idtmotivofinperiodo2.Visible = false;
            // 
            // frmListaPeriodos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 173);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListaPeriodos";
            this.Text = "Lista de Periodos";
            this.Load += new System.EventHandler(this.frmListaPeriodos_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPeriodos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEliminarPeriodo;
        private System.Windows.Forms.Button btnModificarPeriodo;
        private System.Windows.Forms.Button btnNuevoPeriodo;
        private System.Windows.Forms.DataGridView dtgPeriodos;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtMotivoFinPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoSunat;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn MotivoFinPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtmotivofinperiodo2;
    }
}