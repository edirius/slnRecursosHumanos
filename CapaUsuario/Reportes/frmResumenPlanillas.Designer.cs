namespace CapaUsuario.Reportes
{
    partial class frmResumenPlanillas
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
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvPlanilla = new System.Windows.Forms.DataGridView();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IdtPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Año = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdtRegimenLaboral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plantilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanilla)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.BackColor = System.Drawing.Color.MintCream;
            this.btnImprimir.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnImprimir.ImageIndex = 1;
            this.btnImprimir.Location = new System.Drawing.Point(961, 471);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(83, 53);
            this.btnImprimir.TabIndex = 29;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.MintCream;
            this.btnSalir.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSalir.ImageKey = "ssss.png";
            this.btnSalir.Location = new System.Drawing.Point(1050, 471);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(83, 53);
            this.btnSalir.TabIndex = 27;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvPlanilla
            // 
            this.dgvPlanilla.AllowUserToAddRows = false;
            this.dgvPlanilla.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dgvPlanilla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPlanilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPlanilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdtPlanilla,
            this.Numero,
            this.Descripcion,
            this.Mes,
            this.Año,
            this.Fecha,
            this.Column6,
            this.Column10,
            this.Column7,
            this.Column8,
            this.Column9,
            this.IdtRegimenLaboral,
            this.Plantilla});
            this.dgvPlanilla.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvPlanilla.Location = new System.Drawing.Point(12, 39);
            this.dgvPlanilla.MultiSelect = false;
            this.dgvPlanilla.Name = "dgvPlanilla";
            this.dgvPlanilla.RowHeadersVisible = false;
            this.dgvPlanilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlanilla.Size = new System.Drawing.Size(1121, 426);
            this.dgvPlanilla.TabIndex = 23;
            this.dgvPlanilla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlanilla_CellContentClick);
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(43, 12);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(140, 21);
            this.cboAño.TabIndex = 31;
            this.cboAño.SelectedIndexChanged += new System.EventHandler(this.cboAño_SelectedIndexChanged);
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
            this.cboMes.Location = new System.Drawing.Point(222, 12);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(121, 21);
            this.cboMes.TabIndex = 32;
            this.cboMes.SelectedIndexChanged += new System.EventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Mes";
            // 
            // IdtPlanilla
            // 
            this.IdtPlanilla.HeaderText = "IdtPlanilla";
            this.IdtPlanilla.Name = "IdtPlanilla";
            this.IdtPlanilla.ReadOnly = true;
            this.IdtPlanilla.Visible = false;
            this.IdtPlanilla.Width = 20;
            // 
            // Numero
            // 
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 50;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 300;
            // 
            // Mes
            // 
            this.Mes.HeaderText = "Mes";
            this.Mes.Name = "Mes";
            this.Mes.ReadOnly = true;
            this.Mes.Visible = false;
            this.Mes.Width = 75;
            // 
            // Año
            // 
            this.Año.HeaderText = "Año";
            this.Año.Name = "Año";
            this.Año.ReadOnly = true;
            this.Año.Visible = false;
            this.Año.Width = 40;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Visible = false;
            this.Fecha.Width = 40;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "IdtMeta";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            this.Column6.Width = 20;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "NroMeta";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Visible = false;
            this.Column10.Width = 20;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Meta";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 500;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "IdtFuenteFinanciamiento";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            this.Column8.Width = 20;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Fuente Financiamiento";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 200;
            // 
            // IdtRegimenLaboral
            // 
            this.IdtRegimenLaboral.HeaderText = "IdtRegimenLaboral";
            this.IdtRegimenLaboral.Name = "IdtRegimenLaboral";
            this.IdtRegimenLaboral.ReadOnly = true;
            this.IdtRegimenLaboral.Visible = false;
            this.IdtRegimenLaboral.Width = 20;
            // 
            // Plantilla
            // 
            this.Plantilla.HeaderText = "Plantilla";
            this.Plantilla.Name = "Plantilla";
            this.Plantilla.ReadOnly = true;
            this.Plantilla.Visible = false;
            // 
            // frmResumenPlanillas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 536);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboMes);
            this.Controls.Add(this.cboAño);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvPlanilla);
            this.Name = "frmResumenPlanillas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumen Planillas";
            this.Load += new System.EventHandler(this.frmMatenimientoPlanilla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvPlanilla;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdtPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Año;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdtRegimenLaboral;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plantilla;
    }
}