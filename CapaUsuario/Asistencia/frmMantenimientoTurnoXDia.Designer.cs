namespace CapaUsuario.Asistencia
{
    partial class frmMantenimientoTurnoXDia
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoTurnoXDia));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreTurnoXDia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cboListaTurnos = new System.Windows.Forms.ComboBox();
            this.dtgListaTurnos = new System.Windows.Forms.DataGridView();
            this.colCodigoTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInicioTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFinTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToleranciaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre :";
            // 
            // txtNombreTurnoXDia
            // 
            this.txtNombreTurnoXDia.Location = new System.Drawing.Point(95, 23);
            this.txtNombreTurnoXDia.Name = "txtNombreTurnoXDia";
            this.txtNombreTurnoXDia.Size = new System.Drawing.Size(275, 20);
            this.txtNombreTurnoXDia.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lista Turnos :";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(339, 101);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(339, 145);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 23);
            this.btnQuitar.TabIndex = 5;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.MintCream;
            this.btnCancelar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelar.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnCancelar.Location = new System.Drawing.Point(485, 263);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 65);
            this.btnCancelar.TabIndex = 78;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.BackColor = System.Drawing.Color.MintCream;
            this.btnAceptar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAceptar.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnAceptar.Location = new System.Drawing.Point(404, 263);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 65);
            this.btnAceptar.TabIndex = 77;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cboListaTurnos
            // 
            this.cboListaTurnos.FormattingEnabled = true;
            this.cboListaTurnos.Location = new System.Drawing.Point(420, 101);
            this.cboListaTurnos.Name = "cboListaTurnos";
            this.cboListaTurnos.Size = new System.Drawing.Size(121, 21);
            this.cboListaTurnos.TabIndex = 79;
            // 
            // dtgListaTurnos
            // 
            this.dtgListaTurnos.AllowUserToAddRows = false;
            this.dtgListaTurnos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.dtgListaTurnos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaTurnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoTurno,
            this.colNombreTurno,
            this.colInicioTurno,
            this.colFinTurno,
            this.colToleranciaInicio});
            this.dtgListaTurnos.Location = new System.Drawing.Point(29, 101);
            this.dtgListaTurnos.MultiSelect = false;
            this.dtgListaTurnos.Name = "dtgListaTurnos";
            this.dtgListaTurnos.ReadOnly = true;
            this.dtgListaTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaTurnos.Size = new System.Drawing.Size(290, 149);
            this.dtgListaTurnos.TabIndex = 81;
            // 
            // colCodigoTurno
            // 
            this.colCodigoTurno.DataPropertyName = "CodigoTurno";
            this.colCodigoTurno.HeaderText = "Codigo";
            this.colCodigoTurno.Name = "colCodigoTurno";
            this.colCodigoTurno.ReadOnly = true;
            this.colCodigoTurno.Width = 40;
            // 
            // colNombreTurno
            // 
            this.colNombreTurno.DataPropertyName = "NombreTurno";
            this.colNombreTurno.HeaderText = "Nombre";
            this.colNombreTurno.Name = "colNombreTurno";
            this.colNombreTurno.ReadOnly = true;
            this.colNombreTurno.Width = 250;
            // 
            // colInicioTurno
            // 
            this.colInicioTurno.DataPropertyName = "InicioTurno";
            dataGridViewCellStyle2.Format = "T";
            dataGridViewCellStyle2.NullValue = null;
            this.colInicioTurno.DefaultCellStyle = dataGridViewCellStyle2;
            this.colInicioTurno.HeaderText = "Inicio Turno";
            this.colInicioTurno.Name = "colInicioTurno";
            this.colInicioTurno.ReadOnly = true;
            // 
            // colFinTurno
            // 
            this.colFinTurno.DataPropertyName = "FinTurno";
            dataGridViewCellStyle3.Format = "T";
            dataGridViewCellStyle3.NullValue = null;
            this.colFinTurno.DefaultCellStyle = dataGridViewCellStyle3;
            this.colFinTurno.HeaderText = "Fin Turno";
            this.colFinTurno.Name = "colFinTurno";
            this.colFinTurno.ReadOnly = true;
            // 
            // colToleranciaInicio
            // 
            this.colToleranciaInicio.DataPropertyName = "ToleranciaInicio";
            dataGridViewCellStyle4.Format = "T";
            dataGridViewCellStyle4.NullValue = null;
            this.colToleranciaInicio.DefaultCellStyle = dataGridViewCellStyle4;
            this.colToleranciaInicio.HeaderText = "Tolerancia";
            this.colToleranciaInicio.Name = "colToleranciaInicio";
            this.colToleranciaInicio.ReadOnly = true;
            this.colToleranciaInicio.Visible = false;
            // 
            // frmMantenimientoTurnoXDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 354);
            this.Controls.Add(this.dtgListaTurnos);
            this.Controls.Add(this.cboListaTurnos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombreTurnoXDia);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMantenimientoTurnoXDia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Turno X Dia";
            this.Load += new System.EventHandler(this.frmMantenimientoTurnoXDia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTurnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreTurnoXDia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cboListaTurnos;
        private System.Windows.Forms.DataGridView dtgListaTurnos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInicioTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFinTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToleranciaInicio;
    }
}