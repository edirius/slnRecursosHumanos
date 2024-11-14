namespace CapaUsuario.Planilla.VacacionesTruncas
{
    partial class frmImportarPeriodo
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
            this.btnAgregarTrabajador = new System.Windows.Forms.Button();
            this.lblTrabajador = new System.Windows.Forms.Label();
            this.dtgListaPeriodos = new System.Windows.Forms.DataGridView();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIdttrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdRegimenTrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegimenLaboral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coLSueldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaPeriodos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregarTrabajador
            // 
            this.btnAgregarTrabajador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarTrabajador.BackColor = System.Drawing.Color.MintCream;
            this.btnAgregarTrabajador.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarTrabajador.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAgregarTrabajador.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnAgregarTrabajador.Location = new System.Drawing.Point(26, 11);
            this.btnAgregarTrabajador.Name = "btnAgregarTrabajador";
            this.btnAgregarTrabajador.Size = new System.Drawing.Size(83, 65);
            this.btnAgregarTrabajador.TabIndex = 122;
            this.btnAgregarTrabajador.Text = "&Buscar Trabajador";
            this.btnAgregarTrabajador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgregarTrabajador.UseVisualStyleBackColor = false;
            this.btnAgregarTrabajador.Click += new System.EventHandler(this.btnAgregarTrabajador_Click);
            // 
            // lblTrabajador
            // 
            this.lblTrabajador.AutoSize = true;
            this.lblTrabajador.Location = new System.Drawing.Point(129, 63);
            this.lblTrabajador.Name = "lblTrabajador";
            this.lblTrabajador.Size = new System.Drawing.Size(58, 13);
            this.lblTrabajador.TabIndex = 123;
            this.lblTrabajador.Text = "Trabajador";
            // 
            // dtgListaPeriodos
            // 
            this.dtgListaPeriodos.AllowUserToAddRows = false;
            this.dtgListaPeriodos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.dtgListaPeriodos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaPeriodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaPeriodos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colIdttrabajador,
            this.colIdRegimenTrabajador,
            this.colRegimenLaboral,
            this.colFechaInicio,
            this.colFechaFin,
            this.coLSueldo});
            this.dtgListaPeriodos.Location = new System.Drawing.Point(26, 105);
            this.dtgListaPeriodos.MultiSelect = false;
            this.dtgListaPeriodos.Name = "dtgListaPeriodos";
            this.dtgListaPeriodos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaPeriodos.Size = new System.Drawing.Size(566, 195);
            this.dtgListaPeriodos.TabIndex = 124;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeleccionar.BackColor = System.Drawing.Color.MintCream;
            this.btnSeleccionar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnSeleccionar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSeleccionar.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnSeleccionar.Location = new System.Drawing.Point(373, 306);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(96, 65);
            this.btnSeleccionar.TabIndex = 125;
            this.btnSeleccionar.Text = "S&eleccionar";
            this.btnSeleccionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.MintCream;
            this.btnSalir.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSalir.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnSalir.Location = new System.Drawing.Point(496, 306);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(96, 65);
            this.btnSalir.TabIndex = 126;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // colCheck
            // 
            this.colCheck.DataPropertyName = "check";
            this.colCheck.HeaderText = "Check";
            this.colCheck.Name = "colCheck";
            this.colCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCheck.Width = 50;
            // 
            // colIdttrabajador
            // 
            this.colIdttrabajador.DataPropertyName = "idttrabajador";
            this.colIdttrabajador.HeaderText = "idtTrabajador";
            this.colIdttrabajador.Name = "colIdttrabajador";
            this.colIdttrabajador.Visible = false;
            // 
            // colIdRegimenTrabajador
            // 
            this.colIdRegimenTrabajador.DataPropertyName = "idtperiodo";
            this.colIdRegimenTrabajador.HeaderText = "idRegimenTrabajador";
            this.colIdRegimenTrabajador.Name = "colIdRegimenTrabajador";
            this.colIdRegimenTrabajador.Visible = false;
            // 
            // colRegimenLaboral
            // 
            this.colRegimenLaboral.DataPropertyName = "regimen";
            this.colRegimenLaboral.HeaderText = "Regimen Laboral";
            this.colRegimenLaboral.Name = "colRegimenLaboral";
            this.colRegimenLaboral.Width = 150;
            // 
            // colFechaInicio
            // 
            this.colFechaInicio.DataPropertyName = "fechainicio";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.colFechaInicio.DefaultCellStyle = dataGridViewCellStyle2;
            this.colFechaInicio.HeaderText = "Fecha Inicio";
            this.colFechaInicio.Name = "colFechaInicio";
            // 
            // colFechaFin
            // 
            this.colFechaFin.DataPropertyName = "fechafin";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.colFechaFin.DefaultCellStyle = dataGridViewCellStyle3;
            this.colFechaFin.HeaderText = "Fecha Fin";
            this.colFechaFin.Name = "colFechaFin";
            // 
            // coLSueldo
            // 
            this.coLSueldo.DataPropertyName = "sueldo";
            this.coLSueldo.HeaderText = "Sueldo";
            this.coLSueldo.Name = "coLSueldo";
            // 
            // frmImportarPeriodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 383);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.dtgListaPeriodos);
            this.Controls.Add(this.lblTrabajador);
            this.Controls.Add(this.btnAgregarTrabajador);
            this.Name = "frmImportarPeriodo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Periodo";
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaPeriodos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarTrabajador;
        private System.Windows.Forms.Label lblTrabajador;
        private System.Windows.Forms.DataGridView dtgListaPeriodos;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdttrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdRegimenTrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegimenLaboral;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn coLSueldo;
    }
}