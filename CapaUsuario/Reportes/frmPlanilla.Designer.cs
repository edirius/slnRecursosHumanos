namespace CapaUsuario.Reportes
{
    partial class frmPlanilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanilla));
            this.btnImprimir = new System.Windows.Forms.Button();
            this.dgvAFP = new System.Windows.Forms.DataGridView();
            this.dgvPrueba = new System.Windows.Forms.DataGridView();
            this.dgvPlanilla = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroMeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdtRegimenLaboral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plantilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRedondear = new System.Windows.Forms.DataGridView();
            this.dgvEEFF = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAltoColumna = new System.Windows.Forms.CheckBox();
            this.txtAltoColumnas = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkGerenciaAdministracion = new System.Windows.Forms.CheckBox();
            this.chkSupervision = new System.Windows.Forms.CheckBox();
            this.chkSubGerenciaObras = new System.Windows.Forms.CheckBox();
            this.chkFirmaPresupuesto = new System.Windows.Forms.CheckBox();
            this.chkFirmaResidencia = new System.Windows.Forms.CheckBox();
            this.chkFirmaTesoreria = new System.Windows.Forms.CheckBox();
            this.chkFirmaContabilidad = new System.Windows.Forms.CheckBox();
            this.chkFirmaGerencia = new System.Windows.Forms.CheckBox();
            this.chkFirmaRecursos = new System.Windows.Forms.CheckBox();
            this.chkFirmaElaborado = new System.Windows.Forms.CheckBox();
            this.chkJornalRacionamiento = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAFP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrueba)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRedondear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEEFF)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.BackColor = System.Drawing.Color.MintCream;
            this.btnImprimir.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnImprimir.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnImprimir.Location = new System.Drawing.Point(11, 469);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 65);
            this.btnImprimir.TabIndex = 87;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // dgvAFP
            // 
            this.dgvAFP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAFP.Location = new System.Drawing.Point(366, 460);
            this.dgvAFP.Name = "dgvAFP";
            this.dgvAFP.Size = new System.Drawing.Size(157, 65);
            this.dgvAFP.TabIndex = 92;
            this.dgvAFP.Visible = false;
            // 
            // dgvPrueba
            // 
            this.dgvPrueba.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrueba.Location = new System.Drawing.Point(204, 460);
            this.dgvPrueba.Name = "dgvPrueba";
            this.dgvPrueba.Size = new System.Drawing.Size(157, 65);
            this.dgvPrueba.TabIndex = 93;
            this.dgvPrueba.Visible = false;
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
            this.Column1,
            this.Column2,
            this.txtDescripcion,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.NumeroMeta,
            this.Column8,
            this.Column9,
            this.IdtRegimenLaboral,
            this.Plantilla});
            this.dgvPlanilla.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvPlanilla.Location = new System.Drawing.Point(12, 74);
            this.dgvPlanilla.MultiSelect = false;
            this.dgvPlanilla.Name = "dgvPlanilla";
            this.dgvPlanilla.ReadOnly = true;
            this.dgvPlanilla.RowHeadersVisible = false;
            this.dgvPlanilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlanilla.Size = new System.Drawing.Size(923, 371);
            this.dgvPlanilla.TabIndex = 94;
            this.dgvPlanilla.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlanilla_CellClick_1);
            this.dgvPlanilla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlanilla_CellContentClick_1);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "IdtPlanilla";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            this.Column1.Width = 20;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Numero";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 50;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.HeaderText = "Descripción";
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Mes";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 75;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Año";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 40;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Fecha";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            this.Column5.Width = 40;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "IdtMeta";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            this.Column6.Width = 20;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Meta";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 200;
            // 
            // NumeroMeta
            // 
            this.NumeroMeta.HeaderText = "Numero Meta";
            this.NumeroMeta.Name = "NumeroMeta";
            this.NumeroMeta.ReadOnly = true;
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
            // 
            // dgvRedondear
            // 
            this.dgvRedondear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRedondear.Location = new System.Drawing.Point(529, 460);
            this.dgvRedondear.Name = "dgvRedondear";
            this.dgvRedondear.Size = new System.Drawing.Size(157, 65);
            this.dgvRedondear.TabIndex = 95;
            this.dgvRedondear.Visible = false;
            // 
            // dgvEEFF
            // 
            this.dgvEEFF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEEFF.Location = new System.Drawing.Point(692, 460);
            this.dgvEEFF.Name = "dgvEEFF";
            this.dgvEEFF.Size = new System.Drawing.Size(157, 65);
            this.dgvEEFF.TabIndex = 96;
            this.dgvEEFF.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.cboAño);
            this.groupBox1.Controls.Add(this.cboMes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 55);
            this.groupBox1.TabIndex = 101;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar por:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(380, 22);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(228, 22);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(121, 21);
            this.cboAño.TabIndex = 3;
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(42, 22);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(121, 21);
            this.cboMes.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Año:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mes:";
            // 
            // chkAltoColumna
            // 
            this.chkAltoColumna.AutoSize = true;
            this.chkAltoColumna.Location = new System.Drawing.Point(105, 461);
            this.chkAltoColumna.Name = "chkAltoColumna";
            this.chkAltoColumna.Size = new System.Drawing.Size(115, 17);
            this.chkAltoColumna.TabIndex = 102;
            this.chkAltoColumna.Text = "Fijar Alto Columnas";
            this.chkAltoColumna.UseVisualStyleBackColor = true;
            this.chkAltoColumna.CheckedChanged += new System.EventHandler(this.chkAltoColumna_CheckedChanged);
            // 
            // txtAltoColumnas
            // 
            this.txtAltoColumnas.Location = new System.Drawing.Point(105, 485);
            this.txtAltoColumnas.Name = "txtAltoColumnas";
            this.txtAltoColumnas.Size = new System.Drawing.Size(100, 20);
            this.txtAltoColumnas.TabIndex = 103;
            this.txtAltoColumnas.Visible = false;
            this.txtAltoColumnas.TextChanged += new System.EventHandler(this.txtAltoColumnas_TextChanged);
            this.txtAltoColumnas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAltoColumnas_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkGerenciaAdministracion);
            this.groupBox2.Controls.Add(this.chkSupervision);
            this.groupBox2.Controls.Add(this.chkSubGerenciaObras);
            this.groupBox2.Controls.Add(this.chkFirmaPresupuesto);
            this.groupBox2.Controls.Add(this.chkFirmaResidencia);
            this.groupBox2.Controls.Add(this.chkFirmaTesoreria);
            this.groupBox2.Controls.Add(this.chkFirmaContabilidad);
            this.groupBox2.Controls.Add(this.chkFirmaGerencia);
            this.groupBox2.Controls.Add(this.chkFirmaRecursos);
            this.groupBox2.Controls.Add(this.chkFirmaElaborado);
            this.groupBox2.Location = new System.Drawing.Point(328, 451);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(607, 100);
            this.groupBox2.TabIndex = 104;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Firmas";
            // 
            // chkGerenciaAdministracion
            // 
            this.chkGerenciaAdministracion.AutoSize = true;
            this.chkGerenciaAdministracion.Location = new System.Drawing.Point(494, 18);
            this.chkGerenciaAdministracion.Name = "chkGerenciaAdministracion";
            this.chkGerenciaAdministracion.Size = new System.Drawing.Size(114, 17);
            this.chkGerenciaAdministracion.TabIndex = 2;
            this.chkGerenciaAdministracion.Text = "JEFE DE OFICINA";
            this.chkGerenciaAdministracion.UseVisualStyleBackColor = true;
            // 
            // chkSupervision
            // 
            this.chkSupervision.AutoSize = true;
            this.chkSupervision.Location = new System.Drawing.Point(345, 66);
            this.chkSupervision.Name = "chkSupervision";
            this.chkSupervision.Size = new System.Drawing.Size(187, 17);
            this.chkSupervision.TabIndex = 8;
            this.chkSupervision.Text = "SUPERVISION Y/O INSPECTOR";
            this.chkSupervision.UseVisualStyleBackColor = true;
            // 
            // chkSubGerenciaObras
            // 
            this.chkSubGerenciaObras.AutoSize = true;
            this.chkSubGerenciaObras.Location = new System.Drawing.Point(345, 43);
            this.chkSubGerenciaObras.Name = "chkSubGerenciaObras";
            this.chkSubGerenciaObras.Size = new System.Drawing.Size(106, 17);
            this.chkSubGerenciaObras.TabIndex = 7;
            this.chkSubGerenciaObras.Text = "SUB GERENCIA";
            this.chkSubGerenciaObras.UseVisualStyleBackColor = true;
            // 
            // chkFirmaPresupuesto
            // 
            this.chkFirmaPresupuesto.AutoSize = true;
            this.chkFirmaPresupuesto.Location = new System.Drawing.Point(345, 18);
            this.chkFirmaPresupuesto.Name = "chkFirmaPresupuesto";
            this.chkFirmaPresupuesto.Size = new System.Drawing.Size(107, 17);
            this.chkFirmaPresupuesto.TabIndex = 6;
            this.chkFirmaPresupuesto.Text = "PRESUPUESTO";
            this.chkFirmaPresupuesto.UseVisualStyleBackColor = true;
            // 
            // chkFirmaResidencia
            // 
            this.chkFirmaResidencia.AutoSize = true;
            this.chkFirmaResidencia.Location = new System.Drawing.Point(164, 66);
            this.chkFirmaResidencia.Name = "chkFirmaResidencia";
            this.chkFirmaResidencia.Size = new System.Drawing.Size(171, 17);
            this.chkFirmaResidencia.TabIndex = 5;
            this.chkFirmaResidencia.Text = "RESIDENCIA DE PROYECTO";
            this.chkFirmaResidencia.UseVisualStyleBackColor = true;
            // 
            // chkFirmaTesoreria
            // 
            this.chkFirmaTesoreria.AutoSize = true;
            this.chkFirmaTesoreria.Checked = true;
            this.chkFirmaTesoreria.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFirmaTesoreria.Location = new System.Drawing.Point(18, 66);
            this.chkFirmaTesoreria.Name = "chkFirmaTesoreria";
            this.chkFirmaTesoreria.Size = new System.Drawing.Size(88, 17);
            this.chkFirmaTesoreria.TabIndex = 4;
            this.chkFirmaTesoreria.Text = "TESORERIA";
            this.chkFirmaTesoreria.UseVisualStyleBackColor = true;
            // 
            // chkFirmaContabilidad
            // 
            this.chkFirmaContabilidad.AutoSize = true;
            this.chkFirmaContabilidad.Checked = true;
            this.chkFirmaContabilidad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFirmaContabilidad.Location = new System.Drawing.Point(164, 43);
            this.chkFirmaContabilidad.Name = "chkFirmaContabilidad";
            this.chkFirmaContabilidad.Size = new System.Drawing.Size(105, 17);
            this.chkFirmaContabilidad.TabIndex = 3;
            this.chkFirmaContabilidad.Text = "CONTABILIDAD";
            this.chkFirmaContabilidad.UseVisualStyleBackColor = true;
            // 
            // chkFirmaGerencia
            // 
            this.chkFirmaGerencia.AutoSize = true;
            this.chkFirmaGerencia.Checked = true;
            this.chkFirmaGerencia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFirmaGerencia.Location = new System.Drawing.Point(18, 43);
            this.chkFirmaGerencia.Name = "chkFirmaGerencia";
            this.chkFirmaGerencia.Size = new System.Drawing.Size(142, 17);
            this.chkFirmaGerencia.TabIndex = 2;
            this.chkFirmaGerencia.Text = "GERENCIA MUNICIPAL";
            this.chkFirmaGerencia.UseVisualStyleBackColor = true;
            // 
            // chkFirmaRecursos
            // 
            this.chkFirmaRecursos.AutoSize = true;
            this.chkFirmaRecursos.Checked = true;
            this.chkFirmaRecursos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFirmaRecursos.Location = new System.Drawing.Point(164, 18);
            this.chkFirmaRecursos.Name = "chkFirmaRecursos";
            this.chkFirmaRecursos.Size = new System.Drawing.Size(144, 17);
            this.chkFirmaRecursos.TabIndex = 1;
            this.chkFirmaRecursos.Text = "RECURSOS HUMANOS";
            this.chkFirmaRecursos.UseVisualStyleBackColor = true;
            // 
            // chkFirmaElaborado
            // 
            this.chkFirmaElaborado.AutoSize = true;
            this.chkFirmaElaborado.Checked = true;
            this.chkFirmaElaborado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFirmaElaborado.Location = new System.Drawing.Point(18, 20);
            this.chkFirmaElaborado.Name = "chkFirmaElaborado";
            this.chkFirmaElaborado.Size = new System.Drawing.Size(129, 17);
            this.chkFirmaElaborado.TabIndex = 0;
            this.chkFirmaElaborado.Text = "ELABORADOR POR:";
            this.chkFirmaElaborado.UseVisualStyleBackColor = true;
            // 
            // chkJornalRacionamiento
            // 
            this.chkJornalRacionamiento.AutoSize = true;
            this.chkJornalRacionamiento.Location = new System.Drawing.Point(776, 13);
            this.chkJornalRacionamiento.Name = "chkJornalRacionamiento";
            this.chkJornalRacionamiento.Size = new System.Drawing.Size(159, 17);
            this.chkJornalRacionamiento.TabIndex = 105;
            this.chkJornalRacionamiento.Text = "Incluir Jornal Racionamiento";
            this.chkJornalRacionamiento.UseVisualStyleBackColor = true;
            // 
            // frmPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 546);
            this.Controls.Add(this.chkJornalRacionamiento);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtAltoColumnas);
            this.Controls.Add(this.chkAltoColumna);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvEEFF);
            this.Controls.Add(this.dgvRedondear);
            this.Controls.Add(this.dgvPlanilla);
            this.Controls.Add(this.dgvAFP);
            this.Controls.Add(this.dgvPrueba);
            this.Controls.Add(this.btnImprimir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPlanilla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Planilla";
            this.Load += new System.EventHandler(this.frmPlanilla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAFP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrueba)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRedondear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEEFF)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.DataGridView dgvAFP;
        private System.Windows.Forms.DataGridView dgvPrueba;
        private System.Windows.Forms.DataGridView dgvPlanilla;
        private System.Windows.Forms.DataGridView dgvRedondear;
        private System.Windows.Forms.DataGridView dgvEEFF;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroMeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdtRegimenLaboral;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plantilla;
        private System.Windows.Forms.CheckBox chkAltoColumna;
        private System.Windows.Forms.TextBox txtAltoColumnas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkFirmaElaborado;
        private System.Windows.Forms.CheckBox chkFirmaContabilidad;
        private System.Windows.Forms.CheckBox chkFirmaGerencia;
        private System.Windows.Forms.CheckBox chkFirmaRecursos;
        private System.Windows.Forms.CheckBox chkFirmaResidencia;
        private System.Windows.Forms.CheckBox chkFirmaTesoreria;
        private System.Windows.Forms.CheckBox chkFirmaPresupuesto;
        private System.Windows.Forms.CheckBox chkSupervision;
        private System.Windows.Forms.CheckBox chkSubGerenciaObras;
        private System.Windows.Forms.CheckBox chkGerenciaAdministracion;
        private System.Windows.Forms.CheckBox chkJornalRacionamiento;
    }
}