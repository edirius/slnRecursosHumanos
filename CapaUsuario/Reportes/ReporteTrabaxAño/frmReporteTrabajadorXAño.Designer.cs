namespace CapaUsuario.Reportes.ReporteTrabaxAño
{
    partial class frmReporteTrabajadorXAño
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
            this.dtgListaTrabajadores = new System.Windows.Forms.DataGridView();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidoPaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidoMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFebrero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarzo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAbril = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMayo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJunio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJulio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAgosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSetiembre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOctubre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNoviembre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiciembre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTrabajadores)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListaTrabajadores
            // 
            this.dtgListaTrabajadores.AllowUserToAddRows = false;
            this.dtgListaTrabajadores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.dtgListaTrabajadores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgListaTrabajadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaTrabajadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumero,
            this.colDNI,
            this.colNombres,
            this.colApellidoPaterno,
            this.colApellidoMaterno,
            this.colEnero,
            this.colFebrero,
            this.colMarzo,
            this.colAbril,
            this.colMayo,
            this.colJunio,
            this.colJulio,
            this.colAgosto,
            this.colSetiembre,
            this.colOctubre,
            this.colNoviembre,
            this.colDiciembre});
            this.dtgListaTrabajadores.Location = new System.Drawing.Point(12, 83);
            this.dtgListaTrabajadores.Name = "dtgListaTrabajadores";
            this.dtgListaTrabajadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaTrabajadores.Size = new System.Drawing.Size(1062, 254);
            this.dtgListaTrabajadores.TabIndex = 0;
            // 
            // colNumero
            // 
            this.colNumero.HeaderText = "Nº";
            this.colNumero.Name = "colNumero";
            this.colNumero.Width = 40;
            // 
            // colDNI
            // 
            this.colDNI.HeaderText = "DNI";
            this.colDNI.Name = "colDNI";
            this.colDNI.Width = 80;
            // 
            // colNombres
            // 
            this.colNombres.HeaderText = "Nombres";
            this.colNombres.Name = "colNombres";
            // 
            // colApellidoPaterno
            // 
            this.colApellidoPaterno.HeaderText = "Apellido Paterno";
            this.colApellidoPaterno.Name = "colApellidoPaterno";
            // 
            // colApellidoMaterno
            // 
            this.colApellidoMaterno.HeaderText = "Apellido Materno";
            this.colApellidoMaterno.Name = "colApellidoMaterno";
            // 
            // colEnero
            // 
            this.colEnero.HeaderText = "Enero";
            this.colEnero.Name = "colEnero";
            // 
            // colFebrero
            // 
            this.colFebrero.HeaderText = "Febrero";
            this.colFebrero.Name = "colFebrero";
            // 
            // colMarzo
            // 
            this.colMarzo.HeaderText = "Marzo";
            this.colMarzo.Name = "colMarzo";
            // 
            // colAbril
            // 
            this.colAbril.HeaderText = "Abril";
            this.colAbril.Name = "colAbril";
            // 
            // colMayo
            // 
            this.colMayo.HeaderText = "Mayo";
            this.colMayo.Name = "colMayo";
            // 
            // colJunio
            // 
            this.colJunio.HeaderText = "Junio";
            this.colJunio.Name = "colJunio";
            // 
            // colJulio
            // 
            this.colJulio.HeaderText = "Julio";
            this.colJulio.Name = "colJulio";
            // 
            // colAgosto
            // 
            this.colAgosto.HeaderText = "Agosto";
            this.colAgosto.Name = "colAgosto";
            // 
            // colSetiembre
            // 
            this.colSetiembre.HeaderText = "Setiembre";
            this.colSetiembre.Name = "colSetiembre";
            // 
            // colOctubre
            // 
            this.colOctubre.HeaderText = "Octubre";
            this.colOctubre.Name = "colOctubre";
            // 
            // colNoviembre
            // 
            this.colNoviembre.HeaderText = "Noviembre";
            this.colNoviembre.Name = "colNoviembre";
            // 
            // colDiciembre
            // 
            this.colDiciembre.HeaderText = "Diciembre";
            this.colDiciembre.Name = "colDiciembre";
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(44, 24);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(140, 21);
            this.cboAño.TabIndex = 32;
            this.cboAño.SelectedIndexChanged += new System.EventHandler(this.cboAño_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Año";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.MintCream;
            this.btnBuscar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnBuscar.ImageIndex = 1;
            this.btnBuscar.Location = new System.Drawing.Point(202, 20);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(74, 28);
            this.btnBuscar.TabIndex = 110;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.BackColor = System.Drawing.Color.MintCream;
            this.btnExportarExcel.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportarExcel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnExportarExcel.Image = global::CapaUsuario.Properties.Resources.excel_001;
            this.btnExportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarExcel.Location = new System.Drawing.Point(849, 355);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(110, 53);
            this.btnExportarExcel.TabIndex = 111;
            this.btnExportarExcel.Text = "E&xportar Excel";
            this.btnExportarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.MintCream;
            this.btnSalir.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSalir.Image = global::CapaUsuario.Properties.Resources.exit_32x32;
            this.btnSalir.Location = new System.Drawing.Point(981, 355);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(93, 53);
            this.btnSalir.TabIndex = 112;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmReporteTrabajadorXAño
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 431);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboAño);
            this.Controls.Add(this.dtgListaTrabajadores);
            this.Name = "frmReporteTrabajadorXAño";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Trabajadores x Año";
            this.Load += new System.EventHandler(this.frmReporteTrabajadorXAño_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTrabajadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgListaTrabajadores;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidoPaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidoMaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEnero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFebrero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarzo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAbril;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMayo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJunio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJulio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAgosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSetiembre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOctubre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoviembre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiciembre;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Button btnSalir;
    }
}