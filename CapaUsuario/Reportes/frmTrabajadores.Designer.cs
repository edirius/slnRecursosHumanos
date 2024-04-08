namespace CapaUsuario.Reportes
{
    partial class frmTrabajadores
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrabajadores));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.dgvListaTrabajadores = new System.Windows.Forms.DataGridView();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.chkAutoAjustarColumnas = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaTrabajadores)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Mes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Año";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Items.AddRange(new object[] {
            "ENERO",
            "FEBRERO",
            "MARZO",
            "ABRIL",
            "MAYO",
            "JUNIO",
            "JULIO",
            "AGOSTO",
            "SETIEMBRE",
            "OCTUBRE",
            "NOVIEMBRE",
            "DICIEMBRE"});
            this.cboMes.Location = new System.Drawing.Point(218, 12);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(121, 21);
            this.cboMes.TabIndex = 36;
            this.cboMes.SelectedIndexChanged += new System.EventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(39, 12);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(140, 21);
            this.cboAño.TabIndex = 35;
            this.cboAño.SelectedIndexChanged += new System.EventHandler(this.cboAño_SelectedIndexChanged);
            // 
            // dgvListaTrabajadores
            // 
            this.dgvListaTrabajadores.AllowUserToAddRows = false;
            this.dgvListaTrabajadores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dgvListaTrabajadores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaTrabajadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaTrabajadores.Location = new System.Drawing.Point(12, 67);
            this.dgvListaTrabajadores.Name = "dgvListaTrabajadores";
            this.dgvListaTrabajadores.ReadOnly = true;
            this.dgvListaTrabajadores.Size = new System.Drawing.Size(988, 267);
            this.dgvListaTrabajadores.TabIndex = 39;
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.BackColor = System.Drawing.Color.MintCream;
            this.btnExportarExcel.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportarExcel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnExportarExcel.Image = global::CapaUsuario.Properties.Resources.excel_001;
            this.btnExportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarExcel.Location = new System.Drawing.Point(775, 344);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(110, 53);
            this.btnExportarExcel.TabIndex = 42;
            this.btnExportarExcel.Text = "E&xportar Excel";
            this.btnExportarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnExportarExcel, "Exporta a un archivo Excel");
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
            this.btnSalir.Location = new System.Drawing.Point(905, 344);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(93, 53);
            this.btnSalir.TabIndex = 41;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.BackColor = System.Drawing.Color.MintCream;
            this.btnImprimir.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnImprimir.Image = global::CapaUsuario.Properties.Resources.pdf32x32;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(659, 344);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(110, 53);
            this.btnImprimir.TabIndex = 40;
            this.btnImprimir.Text = "&Exportar PDF";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnImprimir, "Exporta a un archivo PDF");
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // chkAutoAjustarColumnas
            // 
            this.chkAutoAjustarColumnas.AutoSize = true;
            this.chkAutoAjustarColumnas.Location = new System.Drawing.Point(10, 362);
            this.chkAutoAjustarColumnas.Name = "chkAutoAjustarColumnas";
            this.chkAutoAjustarColumnas.Size = new System.Drawing.Size(128, 17);
            this.chkAutoAjustarColumnas.TabIndex = 43;
            this.chkAutoAjustarColumnas.Text = "Autoajustar Columnas";
            this.chkAutoAjustarColumnas.UseVisualStyleBackColor = true;
            // 
            // frmTrabajadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 407);
            this.Controls.Add(this.chkAutoAjustarColumnas);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.dgvListaTrabajadores);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboMes);
            this.Controls.Add(this.cboAño);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTrabajadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Trabajadores";
            this.Load += new System.EventHandler(this.frmTrabajadores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaTrabajadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.DataGridView dgvListaTrabajadores;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.CheckBox chkAutoAjustarColumnas;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}