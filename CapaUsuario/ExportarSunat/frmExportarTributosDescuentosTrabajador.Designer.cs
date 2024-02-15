namespace CapaUsuario.ExportarSunat
{
    partial class frmExportarTributosDescuentosTrabajador
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodForm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRuc = new System.Windows.Forms.TextBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.cbAños = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bntListarTodo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkDescuentos = new System.Windows.Forms.CheckBox();
            this.chkSCTR = new System.Windows.Forms.CheckBox();
            this.pbSunat = new System.Windows.Forms.PictureBox();
            this.CheckJornada = new System.Windows.Forms.CheckBox();
            this.dgvListaPlanillas = new System.Windows.Forms.DataGridView();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAño = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcionPlantilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcionPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkDuplicados = new System.Windows.Forms.CheckBox();
            this.btnMarcarTodo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSunat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPlanillas)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(602, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "CodFormulario:";
            // 
            // txtCodForm
            // 
            this.txtCodForm.Location = new System.Drawing.Point(685, 12);
            this.txtCodForm.Name = "txtCodForm";
            this.txtCodForm.Size = new System.Drawing.Size(83, 20);
            this.txtCodForm.TabIndex = 4;
            this.txtCodForm.Text = "0601";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(796, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "RUC de la Empresa:";
            // 
            // txtRuc
            // 
            this.txtRuc.Location = new System.Drawing.Point(905, 12);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(83, 20);
            this.txtRuc.TabIndex = 10;
            this.txtRuc.Text = "20177432360";
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.MintCream;
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnExportar.Location = new System.Drawing.Point(875, 13);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(107, 54);
            this.btnExportar.TabIndex = 24;
            this.btnExportar.Text = "&Exportar datos";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
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
            this.cbMes.Location = new System.Drawing.Point(276, 30);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(121, 21);
            this.cbMes.TabIndex = 29;
            this.cbMes.SelectedIndexChanged += new System.EventHandler(this.cbMes_SelectedIndexChanged);
            // 
            // cbAños
            // 
            this.cbAños.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAños.FormattingEnabled = true;
            this.cbAños.Location = new System.Drawing.Point(465, 30);
            this.cbAños.Name = "cbAños";
            this.cbAños.Size = new System.Drawing.Size(74, 21);
            this.cbAños.TabIndex = 30;
            this.cbAños.SelectedIndexChanged += new System.EventHandler(this.cbAños_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Mes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(430, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Año:";
            // 
            // bntListarTodo
            // 
            this.bntListarTodo.BackColor = System.Drawing.Color.MintCream;
            this.bntListarTodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntListarTodo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.bntListarTodo.Location = new System.Drawing.Point(577, 13);
            this.bntListarTodo.Name = "bntListarTodo";
            this.bntListarTodo.Size = new System.Drawing.Size(179, 54);
            this.bntListarTodo.TabIndex = 33;
            this.bntListarTodo.Text = "&Listar todas las planillas\r\n por año";
            this.bntListarTodo.UseVisualStyleBackColor = false;
            this.bntListarTodo.Click += new System.EventHandler(this.bntListarTodo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMarcarTodo);
            this.groupBox1.Controls.Add(this.chkDuplicados);
            this.groupBox1.Controls.Add(this.chkDescuentos);
            this.groupBox1.Controls.Add(this.chkSCTR);
            this.groupBox1.Controls.Add(this.pbSunat);
            this.groupBox1.Controls.Add(this.CheckJornada);
            this.groupBox1.Controls.Add(this.bntListarTodo);
            this.groupBox1.Controls.Add(this.btnExportar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbMes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbAños);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1291, 93);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar trabajadores por fecha:";
            // 
            // chkDescuentos
            // 
            this.chkDescuentos.AutoSize = true;
            this.chkDescuentos.Location = new System.Drawing.Point(1159, 69);
            this.chkDescuentos.Name = "chkDescuentos";
            this.chkDescuentos.Size = new System.Drawing.Size(114, 17);
            this.chkDescuentos.TabIndex = 37;
            this.chkDescuentos.Text = "Incluir Descuentos";
            this.chkDescuentos.UseVisualStyleBackColor = true;
            // 
            // chkSCTR
            // 
            this.chkSCTR.AutoSize = true;
            this.chkSCTR.Location = new System.Drawing.Point(1042, 69);
            this.chkSCTR.Name = "chkSCTR";
            this.chkSCTR.Size = new System.Drawing.Size(108, 17);
            this.chkSCTR.TabIndex = 36;
            this.chkSCTR.Text = "SCTR-ESSALUD";
            this.chkSCTR.UseVisualStyleBackColor = true;
            // 
            // pbSunat
            // 
            this.pbSunat.Image = global::CapaUsuario.Properties.Resources.logoamplio;
            this.pbSunat.Location = new System.Drawing.Point(16, 19);
            this.pbSunat.Name = "pbSunat";
            this.pbSunat.Size = new System.Drawing.Size(184, 54);
            this.pbSunat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSunat.TabIndex = 35;
            this.pbSunat.TabStop = false;
            // 
            // CheckJornada
            // 
            this.CheckJornada.AutoSize = true;
            this.CheckJornada.Location = new System.Drawing.Point(787, 70);
            this.CheckJornada.Name = "CheckJornada";
            this.CheckJornada.Size = new System.Drawing.Size(235, 17);
            this.CheckJornada.TabIndex = 34;
            this.CheckJornada.Text = "Generar datos Jornada laboral del trabajador";
            this.CheckJornada.UseVisualStyleBackColor = true;
            this.CheckJornada.CheckedChanged += new System.EventHandler(this.CheckJornada_CheckedChanged);
            // 
            // dgvListaPlanillas
            // 
            this.dgvListaPlanillas.AllowUserToAddRows = false;
            this.dgvListaPlanillas.AllowUserToDeleteRows = false;
            this.dgvListaPlanillas.AllowUserToResizeColumns = false;
            this.dgvListaPlanillas.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvListaPlanillas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListaPlanillas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaPlanillas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk,
            this.colNro,
            this.colMes,
            this.colAño,
            this.colDescripcionPlantilla,
            this.colMeta,
            this.colDescripcionPlanilla,
            this.colIdtPlanilla});
            this.dgvListaPlanillas.Location = new System.Drawing.Point(12, 101);
            this.dgvListaPlanillas.Name = "dgvListaPlanillas";
            this.dgvListaPlanillas.RowHeadersVisible = false;
            this.dgvListaPlanillas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaPlanillas.Size = new System.Drawing.Size(1292, 368);
            this.dgvListaPlanillas.TabIndex = 45;
            // 
            // chk
            // 
            this.chk.HeaderText = "S";
            this.chk.Name = "chk";
            this.chk.Width = 50;
            // 
            // colNro
            // 
            this.colNro.DataPropertyName = "Nro";
            this.colNro.HeaderText = "Nro";
            this.colNro.Name = "colNro";
            this.colNro.Width = 50;
            // 
            // colMes
            // 
            this.colMes.DataPropertyName = "Mes";
            this.colMes.HeaderText = "Mes";
            this.colMes.Name = "colMes";
            // 
            // colAño
            // 
            this.colAño.DataPropertyName = "Año";
            this.colAño.HeaderText = "Año";
            this.colAño.Name = "colAño";
            this.colAño.Width = 80;
            // 
            // colDescripcionPlantilla
            // 
            this.colDescripcionPlantilla.DataPropertyName = "DescripcionPlantilla";
            this.colDescripcionPlantilla.HeaderText = "DescripcionPlantilla";
            this.colDescripcionPlantilla.Name = "colDescripcionPlantilla";
            this.colDescripcionPlantilla.Width = 200;
            // 
            // colMeta
            // 
            this.colMeta.DataPropertyName = "Meta";
            this.colMeta.HeaderText = "Meta";
            this.colMeta.Name = "colMeta";
            this.colMeta.Width = 350;
            // 
            // colDescripcionPlanilla
            // 
            this.colDescripcionPlanilla.DataPropertyName = "DescripcionPlanilla";
            this.colDescripcionPlanilla.HeaderText = "DescripcionPlanilla";
            this.colDescripcionPlanilla.Name = "colDescripcionPlanilla";
            this.colDescripcionPlanilla.Width = 350;
            // 
            // colIdtPlanilla
            // 
            this.colIdtPlanilla.DataPropertyName = "idtPlanilla";
            this.colIdtPlanilla.HeaderText = "idtPlanilla";
            this.colIdtPlanilla.Name = "colIdtPlanilla";
            this.colIdtPlanilla.Visible = false;
            // 
            // chkDuplicados
            // 
            this.chkDuplicados.AutoSize = true;
            this.chkDuplicados.Location = new System.Drawing.Point(1158, 19);
            this.chkDuplicados.Name = "chkDuplicados";
            this.chkDuplicados.Size = new System.Drawing.Size(133, 17);
            this.chkDuplicados.TabIndex = 38;
            this.chkDuplicados.Text = "Comprobar Duplicados";
            this.chkDuplicados.UseVisualStyleBackColor = true;
            // 
            // btnMarcarTodo
            // 
            this.btnMarcarTodo.BackColor = System.Drawing.Color.MintCream;
            this.btnMarcarTodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarcarTodo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnMarcarTodo.Location = new System.Drawing.Point(3, 71);
            this.btnMarcarTodo.Name = "btnMarcarTodo";
            this.btnMarcarTodo.Size = new System.Drawing.Size(107, 24);
            this.btnMarcarTodo.TabIndex = 39;
            this.btnMarcarTodo.Text = "&Marcar Todo";
            this.btnMarcarTodo.UseVisualStyleBackColor = false;
            this.btnMarcarTodo.Click += new System.EventHandler(this.btnMarcarTodo_Click);
            // 
            // frmExportarTributosDescuentosTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 489);
            this.Controls.Add(this.dgvListaPlanillas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRuc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodForm);
            this.Name = "frmExportarTributosDescuentosTrabajador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar archivos de importación de tributos y descuentos del trabajador(PDT-PLAME" +
    ")";
            this.Load += new System.EventHandler(this.frmExportarTributosDescuentosTrabajador_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSunat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPlanillas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodForm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRuc;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.ComboBox cbAños;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bntListarTodo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CheckJornada;
        private System.Windows.Forms.PictureBox pbSunat;
        private System.Windows.Forms.CheckBox chkSCTR;
        private System.Windows.Forms.DataGridView dgvListaPlanillas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAño;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcionPlantilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcionPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtPlanilla;
        private System.Windows.Forms.CheckBox chkDescuentos;
        private System.Windows.Forms.CheckBox chkDuplicados;
        private System.Windows.Forms.Button btnMarcarTodo;
    }
}