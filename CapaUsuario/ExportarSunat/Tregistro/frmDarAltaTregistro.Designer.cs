namespace CapaUsuario.ExportarSunat.Tregistro
{
    partial class frmDarAltaTregistro
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
            this.chkSRCT = new System.Windows.Forms.CheckBox();
            this.checkEDU = new System.Windows.Forms.CheckBox();
            this.checkEST = new System.Windows.Forms.CheckBox();
            this.checkIDE = new System.Windows.Forms.CheckBox();
            this.checkPER = new System.Windows.Forms.CheckBox();
            this.checkTRA = new System.Windows.Forms.CheckBox();
            this.checkSelectAll = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgListaTrabajadores = new System.Windows.Forms.DataGridView();
            this.cbAños = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.btnVerCodificacion = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.colMarcado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdTrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidoPaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidoMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTieneSCRT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colTipoSCRTSalud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeriodoTrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDatosPersonales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTrabajadores)).BeginInit();
            this.SuspendLayout();
            // 
            // chkSRCT
            // 
            this.chkSRCT.AutoSize = true;
            this.chkSRCT.Location = new System.Drawing.Point(374, 52);
            this.chkSRCT.Name = "chkSRCT";
            this.chkSRCT.Size = new System.Drawing.Size(55, 17);
            this.chkSRCT.TabIndex = 63;
            this.chkSRCT.Text = "SRCT";
            this.chkSRCT.UseVisualStyleBackColor = true;
            // 
            // checkEDU
            // 
            this.checkEDU.AutoSize = true;
            this.checkEDU.Location = new System.Drawing.Point(308, 52);
            this.checkEDU.Name = "checkEDU";
            this.checkEDU.Size = new System.Drawing.Size(49, 17);
            this.checkEDU.TabIndex = 61;
            this.checkEDU.Text = "EDU";
            this.checkEDU.UseVisualStyleBackColor = true;
            // 
            // checkEST
            // 
            this.checkEST.AutoSize = true;
            this.checkEST.Location = new System.Drawing.Point(238, 52);
            this.checkEST.Name = "checkEST";
            this.checkEST.Size = new System.Drawing.Size(47, 17);
            this.checkEST.TabIndex = 60;
            this.checkEST.Text = "EST";
            this.checkEST.UseVisualStyleBackColor = true;
            // 
            // checkIDE
            // 
            this.checkIDE.AutoSize = true;
            this.checkIDE.Location = new System.Drawing.Point(25, 52);
            this.checkIDE.Name = "checkIDE";
            this.checkIDE.Size = new System.Drawing.Size(44, 17);
            this.checkIDE.TabIndex = 57;
            this.checkIDE.Text = "IDE";
            this.checkIDE.UseVisualStyleBackColor = true;
            // 
            // checkPER
            // 
            this.checkPER.AutoSize = true;
            this.checkPER.Location = new System.Drawing.Point(160, 52);
            this.checkPER.Name = "checkPER";
            this.checkPER.Size = new System.Drawing.Size(48, 17);
            this.checkPER.TabIndex = 59;
            this.checkPER.Text = "PER";
            this.checkPER.UseVisualStyleBackColor = true;
            // 
            // checkTRA
            // 
            this.checkTRA.AutoSize = true;
            this.checkTRA.Location = new System.Drawing.Point(88, 52);
            this.checkTRA.Name = "checkTRA";
            this.checkTRA.Size = new System.Drawing.Size(48, 17);
            this.checkTRA.TabIndex = 58;
            this.checkTRA.Text = "TRA";
            this.checkTRA.UseVisualStyleBackColor = true;
            // 
            // checkSelectAll
            // 
            this.checkSelectAll.AutoSize = true;
            this.checkSelectAll.Location = new System.Drawing.Point(447, 52);
            this.checkSelectAll.Name = "checkSelectAll";
            this.checkSelectAll.Size = new System.Drawing.Size(188, 17);
            this.checkSelectAll.TabIndex = 62;
            this.checkSelectAll.Text = "Seleccionar todos los trabajadores";
            this.checkSelectAll.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgListaTrabajadores);
            this.groupBox1.Location = new System.Drawing.Point(15, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(919, 348);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Trabajadores";
            // 
            // dtgListaTrabajadores
            // 
            this.dtgListaTrabajadores.AllowUserToAddRows = false;
            this.dtgListaTrabajadores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dtgListaTrabajadores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaTrabajadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaTrabajadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMarcado,
            this.colNumero,
            this.colIdTrabajador,
            this.colFechaInicio,
            this.colFechaNacimiento,
            this.colDni,
            this.colNombres,
            this.colApellidoPaterno,
            this.colApellidoMaterno,
            this.colPlanilla,
            this.colTieneSCRT,
            this.colTipoSCRTSalud,
            this.colPeriodoTrabajador,
            this.colDatosPersonales});
            this.dtgListaTrabajadores.Location = new System.Drawing.Point(6, 19);
            this.dtgListaTrabajadores.Name = "dtgListaTrabajadores";
            this.dtgListaTrabajadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaTrabajadores.Size = new System.Drawing.Size(887, 299);
            this.dtgListaTrabajadores.TabIndex = 0;
            // 
            // cbAños
            // 
            this.cbAños.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAños.FormattingEnabled = true;
            this.cbAños.Location = new System.Drawing.Point(211, 12);
            this.cbAños.Name = "cbAños";
            this.cbAños.Size = new System.Drawing.Size(74, 21);
            this.cbAños.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Mes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Año:";
            // 
            // cbMes
            // 
            this.cbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Items.AddRange(new object[] {
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
            this.cbMes.Location = new System.Drawing.Point(46, 12);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(121, 21);
            this.cbMes.TabIndex = 52;
            this.cbMes.SelectedIndexChanged += new System.EventHandler(this.cbMes_SelectedIndexChanged);
            // 
            // btnVerCodificacion
            // 
            this.btnVerCodificacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerCodificacion.BackColor = System.Drawing.Color.MintCream;
            this.btnVerCodificacion.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnVerCodificacion.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnVerCodificacion.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnVerCodificacion.Location = new System.Drawing.Point(856, 12);
            this.btnVerCodificacion.Name = "btnVerCodificacion";
            this.btnVerCodificacion.Size = new System.Drawing.Size(100, 50);
            this.btnVerCodificacion.TabIndex = 65;
            this.btnVerCodificacion.Text = "&Ver Codificacion";
            this.btnVerCodificacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVerCodificacion.UseVisualStyleBackColor = false;
            this.btnVerCodificacion.Click += new System.EventHandler(this.btnVerCodificacion_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.MintCream;
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnExportar.Location = new System.Drawing.Point(711, 12);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(106, 50);
            this.btnExportar.TabIndex = 64;
            this.btnExportar.Text = "&Exportar Datos";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // colMarcado
            // 
            this.colMarcado.DataPropertyName = "Marcado";
            this.colMarcado.HeaderText = "Check";
            this.colMarcado.Name = "colMarcado";
            this.colMarcado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMarcado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colMarcado.Width = 70;
            // 
            // colNumero
            // 
            this.colNumero.DataPropertyName = "Numero";
            this.colNumero.HeaderText = "Numero";
            this.colNumero.Name = "colNumero";
            this.colNumero.Width = 50;
            // 
            // colIdTrabajador
            // 
            this.colIdTrabajador.DataPropertyName = "id_trabajador";
            this.colIdTrabajador.HeaderText = "IdTrabajador";
            this.colIdTrabajador.Name = "colIdTrabajador";
            this.colIdTrabajador.Visible = false;
            // 
            // colFechaInicio
            // 
            this.colFechaInicio.DataPropertyName = "FechaInicio";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.colFechaInicio.DefaultCellStyle = dataGridViewCellStyle2;
            this.colFechaInicio.HeaderText = "Fecha Inicio";
            this.colFechaInicio.Name = "colFechaInicio";
            this.colFechaInicio.Width = 80;
            // 
            // colFechaNacimiento
            // 
            this.colFechaNacimiento.DataPropertyName = "FechaNacimiento";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.colFechaNacimiento.DefaultCellStyle = dataGridViewCellStyle3;
            this.colFechaNacimiento.HeaderText = "Fecha Nacimiento";
            this.colFechaNacimiento.Name = "colFechaNacimiento";
            this.colFechaNacimiento.Width = 80;
            // 
            // colDni
            // 
            this.colDni.DataPropertyName = "dni";
            this.colDni.HeaderText = "DNI";
            this.colDni.Name = "colDni";
            this.colDni.Width = 80;
            // 
            // colNombres
            // 
            this.colNombres.DataPropertyName = "nombres";
            this.colNombres.HeaderText = "Nombres";
            this.colNombres.Name = "colNombres";
            this.colNombres.Width = 120;
            // 
            // colApellidoPaterno
            // 
            this.colApellidoPaterno.DataPropertyName = "apellidoPaterno";
            this.colApellidoPaterno.HeaderText = "Apellido Paterno";
            this.colApellidoPaterno.Name = "colApellidoPaterno";
            this.colApellidoPaterno.Width = 120;
            // 
            // colApellidoMaterno
            // 
            this.colApellidoMaterno.DataPropertyName = "ApellidoMaterno";
            this.colApellidoMaterno.HeaderText = "Apellido Materno";
            this.colApellidoMaterno.Name = "colApellidoMaterno";
            this.colApellidoMaterno.Width = 120;
            // 
            // colPlanilla
            // 
            this.colPlanilla.DataPropertyName = "Planilla";
            this.colPlanilla.HeaderText = "Planilla";
            this.colPlanilla.Name = "colPlanilla";
            this.colPlanilla.Width = 250;
            // 
            // colTieneSCRT
            // 
            this.colTieneSCRT.DataPropertyName = "TieneSCRT";
            this.colTieneSCRT.HeaderText = "TieneSCRT";
            this.colTieneSCRT.Name = "colTieneSCRT";
            this.colTieneSCRT.ReadOnly = true;
            // 
            // colTipoSCRTSalud
            // 
            this.colTipoSCRTSalud.DataPropertyName = "TipoSCRTSalud";
            this.colTipoSCRTSalud.HeaderText = "Tipo SCRT Salud";
            this.colTipoSCRTSalud.Name = "colTipoSCRTSalud";
            this.colTipoSCRTSalud.Visible = false;
            // 
            // colPeriodoTrabajador
            // 
            this.colPeriodoTrabajador.DataPropertyName = "PeriodoTrabajador";
            this.colPeriodoTrabajador.HeaderText = "Periodo Trabajador";
            this.colPeriodoTrabajador.Name = "colPeriodoTrabajador";
            this.colPeriodoTrabajador.Visible = false;
            // 
            // colDatosPersonales
            // 
            this.colDatosPersonales.DataPropertyName = "DatosPersonales";
            this.colDatosPersonales.HeaderText = "Datos Personales";
            this.colDatosPersonales.Name = "colDatosPersonales";
            this.colDatosPersonales.Visible = false;
            // 
            // frmDarAltaTregistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 502);
            this.Controls.Add(this.btnVerCodificacion);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.chkSRCT);
            this.Controls.Add(this.checkEDU);
            this.Controls.Add(this.checkEST);
            this.Controls.Add(this.checkIDE);
            this.Controls.Add(this.checkPER);
            this.Controls.Add(this.checkTRA);
            this.Controls.Add(this.checkSelectAll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbAños);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbMes);
            this.Name = "frmDarAltaTregistro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dar de Alta Tregistro";
            this.Load += new System.EventHandler(this.frmDarAltaTregistro_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTrabajadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSRCT;
        private System.Windows.Forms.CheckBox checkEDU;
        private System.Windows.Forms.CheckBox checkEST;
        private System.Windows.Forms.CheckBox checkIDE;
        private System.Windows.Forms.CheckBox checkPER;
        private System.Windows.Forms.CheckBox checkTRA;
        private System.Windows.Forms.CheckBox checkSelectAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgListaTrabajadores;
        private System.Windows.Forms.ComboBox cbAños;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.Button btnVerCodificacion;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMarcado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdTrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaNacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDni;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidoPaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidoMaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlanilla;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colTieneSCRT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoSCRTSalud;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriodoTrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDatosPersonales;
    }
}