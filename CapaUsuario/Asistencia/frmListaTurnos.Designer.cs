namespace CapaUsuario.Asistencia
{
    partial class frmListaTurnos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaTurnos));
            this.btnEliminarTurnoXDia = new System.Windows.Forms.Button();
            this.btnModificarTurnoXDia = new System.Windows.Forms.Button();
            this.btnNuevoTurno = new System.Windows.Forms.Button();
            this.dtgListaTurno = new System.Windows.Forms.DataGridView();
            this.colCodigoTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInicioTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFinTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToleranciaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTurno)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEliminarTurnoXDia
            // 
            this.btnEliminarTurnoXDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarTurnoXDia.BackColor = System.Drawing.Color.MintCream;
            this.btnEliminarTurnoXDia.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarTurnoXDia.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEliminarTurnoXDia.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnEliminarTurnoXDia.Location = new System.Drawing.Point(520, 176);
            this.btnEliminarTurnoXDia.Name = "btnEliminarTurnoXDia";
            this.btnEliminarTurnoXDia.Size = new System.Drawing.Size(79, 65);
            this.btnEliminarTurnoXDia.TabIndex = 83;
            this.btnEliminarTurnoXDia.Text = "&Eliminar Turno";
            this.btnEliminarTurnoXDia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminarTurnoXDia.UseVisualStyleBackColor = false;
            // 
            // btnModificarTurnoXDia
            // 
            this.btnModificarTurnoXDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificarTurnoXDia.BackColor = System.Drawing.Color.MintCream;
            this.btnModificarTurnoXDia.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificarTurnoXDia.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnModificarTurnoXDia.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnModificarTurnoXDia.Location = new System.Drawing.Point(430, 176);
            this.btnModificarTurnoXDia.Name = "btnModificarTurnoXDia";
            this.btnModificarTurnoXDia.Size = new System.Drawing.Size(79, 65);
            this.btnModificarTurnoXDia.TabIndex = 82;
            this.btnModificarTurnoXDia.Text = "&Modificar Turno";
            this.btnModificarTurnoXDia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModificarTurnoXDia.UseVisualStyleBackColor = false;
            this.btnModificarTurnoXDia.Click += new System.EventHandler(this.btnModificarTurnoXDia_Click);
            // 
            // btnNuevoTurno
            // 
            this.btnNuevoTurno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoTurno.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevoTurno.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevoTurno.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevoTurno.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnNuevoTurno.Location = new System.Drawing.Point(349, 176);
            this.btnNuevoTurno.Name = "btnNuevoTurno";
            this.btnNuevoTurno.Size = new System.Drawing.Size(75, 65);
            this.btnNuevoTurno.TabIndex = 81;
            this.btnNuevoTurno.Text = "&Nuevo Turno";
            this.btnNuevoTurno.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevoTurno.UseVisualStyleBackColor = false;
            this.btnNuevoTurno.Click += new System.EventHandler(this.btnNuevoTurno_Click);
            // 
            // dtgListaTurno
            // 
            this.dtgListaTurno.AllowUserToAddRows = false;
            this.dtgListaTurno.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.dtgListaTurno.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaTurno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaTurno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoTurno,
            this.colNombreTurno,
            this.colInicioTurno,
            this.colFinTurno,
            this.colToleranciaInicio});
            this.dtgListaTurno.Location = new System.Drawing.Point(12, 21);
            this.dtgListaTurno.MultiSelect = false;
            this.dtgListaTurno.Name = "dtgListaTurno";
            this.dtgListaTurno.ReadOnly = true;
            this.dtgListaTurno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaTurno.Size = new System.Drawing.Size(587, 149);
            this.dtgListaTurno.TabIndex = 80;
            // 
            // colCodigoTurno
            // 
            this.colCodigoTurno.DataPropertyName = "CodigoTurno";
            this.colCodigoTurno.HeaderText = "Codigo";
            this.colCodigoTurno.Name = "colCodigoTurno";
            this.colCodigoTurno.ReadOnly = true;
            this.colCodigoTurno.Width = 50;
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
            // frmListaTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 264);
            this.Controls.Add(this.btnEliminarTurnoXDia);
            this.Controls.Add(this.btnModificarTurnoXDia);
            this.Controls.Add(this.btnNuevoTurno);
            this.Controls.Add(this.dtgListaTurno);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListaTurnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Turnos";
            this.Load += new System.EventHandler(this.frmListaTurnos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTurno)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEliminarTurnoXDia;
        private System.Windows.Forms.Button btnModificarTurnoXDia;
        private System.Windows.Forms.Button btnNuevoTurno;
        private System.Windows.Forms.DataGridView dtgListaTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInicioTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFinTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToleranciaInicio;
    }
}