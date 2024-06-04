namespace CapaUsuario.Asistencia
{
    partial class frmListaSalidas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaSalidas));
            this.dtgListaSalidas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpMes = new System.Windows.Forms.DateTimePicker();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificarSalida = new System.Windows.Forms.Button();
            this.btnEliminarSalida = new System.Windows.Forms.Button();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInicioSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFinSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComentario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAprobado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaSalidas)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListaSalidas
            // 
            this.dtgListaSalidas.AllowUserToAddRows = false;
            this.dtgListaSalidas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dtgListaSalidas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaSalidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaSalidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colTipo,
            this.colInicioSalida,
            this.colFinSalida,
            this.colComentario,
            this.colTrabajador,
            this.colAprobado});
            this.dtgListaSalidas.Location = new System.Drawing.Point(34, 67);
            this.dtgListaSalidas.MultiSelect = false;
            this.dtgListaSalidas.Name = "dtgListaSalidas";
            this.dtgListaSalidas.ReadOnly = true;
            this.dtgListaSalidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaSalidas.Size = new System.Drawing.Size(709, 173);
            this.dtgListaSalidas.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mes:";
            // 
            // dtpMes
            // 
            this.dtpMes.CustomFormat = "MMMM / yyyy";
            this.dtpMes.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMes.Location = new System.Drawing.Point(77, 25);
            this.dtpMes.Name = "dtpMes";
            this.dtpMes.Size = new System.Drawing.Size(131, 20);
            this.dtpMes.TabIndex = 2;
            this.dtpMes.ValueChanged += new System.EventHandler(this.dtpMes_ValueChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAgregar.Location = new System.Drawing.Point(34, 254);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(84, 42);
            this.btnAgregar.TabIndex = 27;
            this.btnAgregar.Text = "Agregar Salida";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificarSalida
            // 
            this.btnModificarSalida.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnModificarSalida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarSalida.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnModificarSalida.Location = new System.Drawing.Point(163, 254);
            this.btnModificarSalida.Name = "btnModificarSalida";
            this.btnModificarSalida.Size = new System.Drawing.Size(84, 42);
            this.btnModificarSalida.TabIndex = 28;
            this.btnModificarSalida.Text = "Modificar Salida";
            this.btnModificarSalida.UseVisualStyleBackColor = false;
            this.btnModificarSalida.Click += new System.EventHandler(this.btnModificarSalida_Click);
            // 
            // btnEliminarSalida
            // 
            this.btnEliminarSalida.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEliminarSalida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarSalida.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEliminarSalida.Location = new System.Drawing.Point(291, 254);
            this.btnEliminarSalida.Name = "btnEliminarSalida";
            this.btnEliminarSalida.Size = new System.Drawing.Size(84, 42);
            this.btnEliminarSalida.TabIndex = 29;
            this.btnEliminarSalida.Text = "Eliminar Salida";
            this.btnEliminarSalida.UseVisualStyleBackColor = false;
            this.btnEliminarSalida.Click += new System.EventHandler(this.btnEliminarSalida_Click);
            // 
            // colCodigo
            // 
            this.colCodigo.DataPropertyName = "CodigoExcepcion";
            this.colCodigo.HeaderText = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Width = 50;
            // 
            // colTipo
            // 
            this.colTipo.DataPropertyName = "Tipo";
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;
            // 
            // colInicioSalida
            // 
            this.colInicioSalida.DataPropertyName = "InicioExcepcion";
            this.colInicioSalida.HeaderText = "Inicio Salida";
            this.colInicioSalida.Name = "colInicioSalida";
            this.colInicioSalida.ReadOnly = true;
            // 
            // colFinSalida
            // 
            this.colFinSalida.DataPropertyName = "FinExcepcion";
            this.colFinSalida.HeaderText = "Fin Salida";
            this.colFinSalida.Name = "colFinSalida";
            this.colFinSalida.ReadOnly = true;
            // 
            // colComentario
            // 
            this.colComentario.DataPropertyName = "Comentario";
            this.colComentario.HeaderText = "Comentario";
            this.colComentario.Name = "colComentario";
            this.colComentario.ReadOnly = true;
            this.colComentario.Width = 200;
            // 
            // colTrabajador
            // 
            this.colTrabajador.DataPropertyName = "Trabajador";
            this.colTrabajador.HeaderText = "Trabajador";
            this.colTrabajador.Name = "colTrabajador";
            this.colTrabajador.ReadOnly = true;
            this.colTrabajador.Visible = false;
            // 
            // colAprobado
            // 
            this.colAprobado.DataPropertyName = "aprobado";
            this.colAprobado.HeaderText = "Aprobado";
            this.colAprobado.Name = "colAprobado";
            this.colAprobado.ReadOnly = true;
            // 
            // frmListaSalidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 324);
            this.Controls.Add(this.btnEliminarSalida);
            this.Controls.Add(this.btnModificarSalida);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dtpMes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgListaSalidas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListaSalidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de salidas";
            this.Load += new System.EventHandler(this.frmListaSalidas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaSalidas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgListaSalidas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpMes;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificarSalida;
        private System.Windows.Forms.Button btnEliminarSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInicioSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFinSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComentario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrabajador;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAprobado;
    }
}