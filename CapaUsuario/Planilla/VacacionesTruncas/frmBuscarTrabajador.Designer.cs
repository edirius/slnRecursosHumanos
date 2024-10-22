namespace CapaUsuario.Planilla.VacacionesTruncas
{
    partial class frmBuscarTrabajador
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
            this.cboTipoBusqueda = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.dtgResultadosBusqueda = new System.Windows.Forms.DataGridView();
            this.colDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidoPaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidoMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGenero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResultadosBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTipoBusqueda
            // 
            this.cboTipoBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoBusqueda.FormattingEnabled = true;
            this.cboTipoBusqueda.Items.AddRange(new object[] {
            "DNI",
            "NOMBRES",
            "CARGO"});
            this.cboTipoBusqueda.Location = new System.Drawing.Point(88, 15);
            this.cboTipoBusqueda.Name = "cboTipoBusqueda";
            this.cboTipoBusqueda.Size = new System.Drawing.Size(162, 21);
            this.cboTipoBusqueda.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Buscar por:";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(268, 16);
            this.txtBusqueda.MaxLength = 10;
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(129, 20);
            this.txtBusqueda.TabIndex = 2;
            // 
            // dtgResultadosBusqueda
            // 
            this.dtgResultadosBusqueda.AllowUserToAddRows = false;
            this.dtgResultadosBusqueda.AllowUserToDeleteRows = false;
            this.dtgResultadosBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgResultadosBusqueda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDNI,
            this.colNombres,
            this.colApellidoPaterno,
            this.colApellidoMaterno,
            this.colFechaNacimiento,
            this.colGenero,
            this.colCargo});
            this.dtgResultadosBusqueda.Location = new System.Drawing.Point(24, 61);
            this.dtgResultadosBusqueda.Name = "dtgResultadosBusqueda";
            this.dtgResultadosBusqueda.ReadOnly = true;
            this.dtgResultadosBusqueda.Size = new System.Drawing.Size(711, 150);
            this.dtgResultadosBusqueda.TabIndex = 3;
            // 
            // colDNI
            // 
            this.colDNI.HeaderText = "DNI";
            this.colDNI.Name = "colDNI";
            this.colDNI.ReadOnly = true;
            this.colDNI.Width = 75;
            // 
            // colNombres
            // 
            this.colNombres.HeaderText = "Nombres";
            this.colNombres.Name = "colNombres";
            this.colNombres.ReadOnly = true;
            this.colNombres.Width = 120;
            // 
            // colApellidoPaterno
            // 
            this.colApellidoPaterno.HeaderText = "Apellido Paterno";
            this.colApellidoPaterno.Name = "colApellidoPaterno";
            this.colApellidoPaterno.ReadOnly = true;
            this.colApellidoPaterno.Width = 120;
            // 
            // colApellidoMaterno
            // 
            this.colApellidoMaterno.HeaderText = "Apellido Materno";
            this.colApellidoMaterno.Name = "colApellidoMaterno";
            this.colApellidoMaterno.ReadOnly = true;
            this.colApellidoMaterno.Width = 120;
            // 
            // colFechaNacimiento
            // 
            this.colFechaNacimiento.HeaderText = "FechaNacimiento";
            this.colFechaNacimiento.Name = "colFechaNacimiento";
            this.colFechaNacimiento.ReadOnly = true;
            this.colFechaNacimiento.Width = 75;
            // 
            // colGenero
            // 
            this.colGenero.HeaderText = "Genero";
            this.colGenero.Name = "colGenero";
            this.colGenero.ReadOnly = true;
            this.colGenero.Width = 50;
            // 
            // colCargo
            // 
            this.colCargo.HeaderText = "Cargo";
            this.colCargo.Name = "colCargo";
            this.colCargo.ReadOnly = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.MintCream;
            this.btnBuscar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnBuscar.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnBuscar.Location = new System.Drawing.Point(417, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(71, 47);
            this.btnBuscar.TabIndex = 123;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmBuscarTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 252);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtgResultadosBusqueda);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTipoBusqueda);
            this.Name = "frmBuscarTrabajador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda de trabajador";
            this.Load += new System.EventHandler(this.frmBuscarTrabajador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgResultadosBusqueda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTipoBusqueda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.DataGridView dtgResultadosBusqueda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidoPaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidoMaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaNacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGenero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCargo;
        private System.Windows.Forms.Button btnBuscar;
    }
}