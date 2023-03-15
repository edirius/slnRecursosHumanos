namespace CapaUsuario.Trabajador
{
    partial class frmListaRenta5taAnteriores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgListaRenta5ta = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIngresos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRetencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colidtTrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.lblNombreTrabajador = new System.Windows.Forms.Label();
            this.cboAnio = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaRenta5ta)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboAnio);
            this.groupBox1.Controls.Add(this.lblNombreTrabajador);
            this.groupBox1.Controls.Add(this.dtgListaRenta5ta);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(641, 257);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dtgListaRenta5ta
            // 
            this.dtgListaRenta5ta.AllowUserToAddRows = false;
            this.dtgListaRenta5ta.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dtgListaRenta5ta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgListaRenta5ta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaRenta5ta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colFecha,
            this.colIngresos,
            this.colRetencion,
            this.colidtTrabajador});
            this.dtgListaRenta5ta.Location = new System.Drawing.Point(4, 101);
            this.dtgListaRenta5ta.MultiSelect = false;
            this.dtgListaRenta5ta.Name = "dtgListaRenta5ta";
            this.dtgListaRenta5ta.ReadOnly = true;
            this.dtgListaRenta5ta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaRenta5ta.Size = new System.Drawing.Size(631, 150);
            this.dtgListaRenta5ta.TabIndex = 0;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "idtrenta5taanteriores";
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colFecha
            // 
            this.colFecha.DataPropertyName = "fecha";
            dataGridViewCellStyle4.Format = "MM/yyyy";
            dataGridViewCellStyle4.NullValue = null;
            this.colFecha.DefaultCellStyle = dataGridViewCellStyle4;
            this.colFecha.HeaderText = "Mes";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 200;
            // 
            // colIngresos
            // 
            this.colIngresos.DataPropertyName = "ingresos";
            this.colIngresos.HeaderText = "Ingresos";
            this.colIngresos.Name = "colIngresos";
            this.colIngresos.ReadOnly = true;
            // 
            // colRetencion
            // 
            this.colRetencion.DataPropertyName = "retencion";
            this.colRetencion.HeaderText = "Retencion";
            this.colRetencion.Name = "colRetencion";
            this.colRetencion.ReadOnly = true;
            // 
            // colidtTrabajador
            // 
            this.colidtTrabajador.DataPropertyName = "idttrabajador";
            this.colidtTrabajador.HeaderText = "idTrabajador";
            this.colidtTrabajador.Name = "colidtTrabajador";
            this.colidtTrabajador.ReadOnly = true;
            this.colidtTrabajador.Visible = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.MintCream;
            this.btnEliminar.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEliminar.Location = new System.Drawing.Point(260, 275);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(97, 48);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.MintCream;
            this.btnCancelar.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelar.Location = new System.Drawing.Point(556, 275);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 48);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "&Salir";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.MintCream;
            this.btnIngresar.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnIngresar.Location = new System.Drawing.Point(15, 275);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(97, 48);
            this.btnIngresar.TabIndex = 13;
            this.btnIngresar.Text = "&Nuevo";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.MintCream;
            this.btnModificar.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnModificar.Location = new System.Drawing.Point(139, 275);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(97, 48);
            this.btnModificar.TabIndex = 16;
            this.btnModificar.Text = "&Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // lblNombreTrabajador
            // 
            this.lblNombreTrabajador.BackColor = System.Drawing.Color.LightBlue;
            this.lblNombreTrabajador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNombreTrabajador.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNombreTrabajador.Location = new System.Drawing.Point(3, 16);
            this.lblNombreTrabajador.Name = "lblNombreTrabajador";
            this.lblNombreTrabajador.Size = new System.Drawing.Size(635, 30);
            this.lblNombreTrabajador.TabIndex = 2;
            this.lblNombreTrabajador.Text = "label1";
            this.lblNombreTrabajador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboAnio
            // 
            this.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnio.FormattingEnabled = true;
            this.cboAnio.Location = new System.Drawing.Point(45, 62);
            this.cboAnio.Name = "cboAnio";
            this.cboAnio.Size = new System.Drawing.Size(121, 21);
            this.cboAnio.TabIndex = 3;
            this.cboAnio.SelectedIndexChanged += new System.EventHandler(this.cboAnio_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Año :";
            // 
            // frmListaRenta5taAnteriores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 343);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmListaRenta5taAnteriores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Renta 5ta Anterior";
            this.Load += new System.EventHandler(this.frmListaRenta5taAnteriores_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaRenta5ta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgListaRenta5ta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIngresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRetencion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colidtTrabajador;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAnio;
        private System.Windows.Forms.Label lblNombreTrabajador;
    }
}