namespace CapaUsuario.Planilla.TrabajadoresSinPlanilla
{
    partial class frmTrabajadoresSinPlanilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrabajadoresSinPlanilla));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgTrabajadores = new System.Windows.Forms.DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNumeroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidoPaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidoMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeriodoTrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnuOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copiarDNIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblContadorTrabajadores = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnDarDeBaja = new System.Windows.Forms.Button();
            this.chkMarcarTodos = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTrabajadores)).BeginInit();
            this.mnuOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgTrabajadores);
            this.groupBox1.Location = new System.Drawing.Point(12, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(859, 268);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Para dar de Baja";
            // 
            // dtgTrabajadores
            // 
            this.dtgTrabajadores.AllowUserToAddRows = false;
            this.dtgTrabajadores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dtgTrabajadores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgTrabajadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTrabajadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colNumeroDocumento,
            this.colNombres,
            this.colApellidoPaterno,
            this.colApellidoMaterno,
            this.colPeriodoTrabajador});
            this.dtgTrabajadores.ContextMenuStrip = this.mnuOpciones;
            this.dtgTrabajadores.Location = new System.Drawing.Point(6, 19);
            this.dtgTrabajadores.MultiSelect = false;
            this.dtgTrabajadores.Name = "dtgTrabajadores";
            this.dtgTrabajadores.Size = new System.Drawing.Size(841, 232);
            this.dtgTrabajadores.TabIndex = 0;
            // 
            // colCheck
            // 
            this.colCheck.DataPropertyName = "Check";
            this.colCheck.HeaderText = "Check";
            this.colCheck.Name = "colCheck";
            this.colCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCheck.Width = 50;
            // 
            // colNumeroDocumento
            // 
            this.colNumeroDocumento.DataPropertyName = "NumeroDocumento";
            this.colNumeroDocumento.HeaderText = "Numero Documento";
            this.colNumeroDocumento.Name = "colNumeroDocumento";
            this.colNumeroDocumento.Width = 80;
            // 
            // colNombres
            // 
            this.colNombres.DataPropertyName = "Nombres";
            this.colNombres.HeaderText = "Nombres";
            this.colNombres.Name = "colNombres";
            this.colNombres.Width = 150;
            // 
            // colApellidoPaterno
            // 
            this.colApellidoPaterno.DataPropertyName = "ApellidoPaterno";
            this.colApellidoPaterno.HeaderText = "Apellido Paterno";
            this.colApellidoPaterno.Name = "colApellidoPaterno";
            this.colApellidoPaterno.Width = 150;
            // 
            // colApellidoMaterno
            // 
            this.colApellidoMaterno.DataPropertyName = "ApellidoMaterno";
            this.colApellidoMaterno.HeaderText = "Apellido Materno";
            this.colApellidoMaterno.Name = "colApellidoMaterno";
            this.colApellidoMaterno.Width = 150;
            // 
            // colPeriodoTrabajador
            // 
            this.colPeriodoTrabajador.DataPropertyName = "PeriodoTrabajador";
            this.colPeriodoTrabajador.HeaderText = "Periodo Trabajador";
            this.colPeriodoTrabajador.Name = "colPeriodoTrabajador";
            this.colPeriodoTrabajador.Visible = false;
            // 
            // mnuOpciones
            // 
            this.mnuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copiarDNIToolStripMenuItem});
            this.mnuOpciones.Name = "mnuOpciones";
            this.mnuOpciones.Size = new System.Drawing.Size(133, 26);
            // 
            // copiarDNIToolStripMenuItem
            // 
            this.copiarDNIToolStripMenuItem.Name = "copiarDNIToolStripMenuItem";
            this.copiarDNIToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.copiarDNIToolStripMenuItem.Text = "Copiar DNI";
            this.copiarDNIToolStripMenuItem.Click += new System.EventHandler(this.copiarDNIToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Mes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 41;
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
            this.cboMes.Location = new System.Drawing.Point(231, 22);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(121, 21);
            this.cboMes.TabIndex = 40;
            this.cboMes.SelectedIndexChanged += new System.EventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(52, 22);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(140, 21);
            this.cboAño.TabIndex = 39;
            this.cboAño.SelectedIndexChanged += new System.EventHandler(this.cboAño_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(673, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 75;
            this.label3.Text = "Fecha Fin:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Enabled = false;
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(737, 23);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(99, 20);
            this.dtpFechaFin.TabIndex = 76;
            // 
            // lblContadorTrabajadores
            // 
            this.lblContadorTrabajadores.AutoSize = true;
            this.lblContadorTrabajadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContadorTrabajadores.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblContadorTrabajadores.Location = new System.Drawing.Point(12, 332);
            this.lblContadorTrabajadores.Name = "lblContadorTrabajadores";
            this.lblContadorTrabajadores.Size = new System.Drawing.Size(129, 13);
            this.lblContadorTrabajadores.TabIndex = 77;
            this.lblContadorTrabajadores.Text = "Total Trabajadores: 0";
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.MintCream;
            this.btnSalir.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSalir.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnSalir.Location = new System.Drawing.Point(754, 327);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(117, 54);
            this.btnSalir.TabIndex = 79;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnDarDeBaja
            // 
            this.btnDarDeBaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDarDeBaja.BackColor = System.Drawing.Color.MintCream;
            this.btnDarDeBaja.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnDarDeBaja.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDarDeBaja.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnDarDeBaja.Location = new System.Drawing.Point(583, 327);
            this.btnDarDeBaja.Name = "btnDarDeBaja";
            this.btnDarDeBaja.Size = new System.Drawing.Size(147, 54);
            this.btnDarDeBaja.TabIndex = 74;
            this.btnDarDeBaja.Text = "&Dar de Baja los seleccionados";
            this.btnDarDeBaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDarDeBaja.UseVisualStyleBackColor = false;
            this.btnDarDeBaja.Click += new System.EventHandler(this.btnDarDeBaja_Click);
            // 
            // chkMarcarTodos
            // 
            this.chkMarcarTodos.AutoSize = true;
            this.chkMarcarTodos.Location = new System.Drawing.Point(496, 25);
            this.chkMarcarTodos.Name = "chkMarcarTodos";
            this.chkMarcarTodos.Size = new System.Drawing.Size(92, 17);
            this.chkMarcarTodos.TabIndex = 80;
            this.chkMarcarTodos.Text = "Marcar Todos";
            this.chkMarcarTodos.UseVisualStyleBackColor = true;
            this.chkMarcarTodos.CheckedChanged += new System.EventHandler(this.chkMarcarTodos_CheckedChanged);
            // 
            // frmTrabajadoresSinPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 393);
            this.Controls.Add(this.chkMarcarTodos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblContadorTrabajadores);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDarDeBaja);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboMes);
            this.Controls.Add(this.cboAño);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTrabajadoresSinPlanilla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TRABAJADORES SIN PLANILLA";
            this.Load += new System.EventHandler(this.frmTrabajadoresSinPlanilla_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTrabajadores)).EndInit();
            this.mnuOpciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgTrabajadores;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.Button btnDarDeBaja;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidoPaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidoMaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriodoTrabajador;
        private System.Windows.Forms.Label lblContadorTrabajadores;
        private System.Windows.Forms.ContextMenuStrip mnuOpciones;
        private System.Windows.Forms.ToolStripMenuItem copiarDNIToolStripMenuItem;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.CheckBox chkMarcarTodos;
    }
}