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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvIngresos = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodForm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRuc = new System.Windows.Forms.TextBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.dgvListaPlanillas = new System.Windows.Forms.DataGridView();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.cbAños = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bntListarTodo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbSunat = new System.Windows.Forms.PictureBox();
            this.CheckJornada = new System.Windows.Forms.CheckBox();
            this.dgvDescuentos = new System.Windows.Forms.DataGridView();
            this.dgvAportaciones = new System.Windows.Forms.DataGridView();
            this.dgvJornadaLaboral = new System.Windows.Forms.DataGridView();
            this.chkSCTR = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPlanillas)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSunat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescuentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAportaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJornadaLaboral)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIngresos
            // 
            this.dgvIngresos.AllowUserToAddRows = false;
            this.dgvIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngresos.Location = new System.Drawing.Point(12, 297);
            this.dgvIngresos.Name = "dgvIngresos";
            this.dgvIngresos.RowHeadersVisible = false;
            this.dgvIngresos.Size = new System.Drawing.Size(312, 172);
            this.dgvIngresos.TabIndex = 0;
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
            // dgvListaPlanillas
            // 
            this.dgvListaPlanillas.AllowUserToAddRows = false;
            this.dgvListaPlanillas.AllowUserToResizeColumns = false;
            this.dgvListaPlanillas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvListaPlanillas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaPlanillas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaPlanillas.Location = new System.Drawing.Point(11, 101);
            this.dgvListaPlanillas.Name = "dgvListaPlanillas";
            this.dgvListaPlanillas.ReadOnly = true;
            this.dgvListaPlanillas.RowHeadersVisible = false;
            this.dgvListaPlanillas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaPlanillas.Size = new System.Drawing.Size(1292, 368);
            this.dgvListaPlanillas.TabIndex = 28;
            this.dgvListaPlanillas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaPlanillas_CellClick);
            this.dgvListaPlanillas.SelectionChanged += new System.EventHandler(this.dgvListaPlanillas_SelectionChanged);
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
            this.CheckJornada.Location = new System.Drawing.Point(821, 69);
            this.CheckJornada.Name = "CheckJornada";
            this.CheckJornada.Size = new System.Drawing.Size(235, 17);
            this.CheckJornada.TabIndex = 34;
            this.CheckJornada.Text = "Generar datos Jornada laboral del trabajador";
            this.CheckJornada.UseVisualStyleBackColor = true;
            this.CheckJornada.CheckedChanged += new System.EventHandler(this.CheckJornada_CheckedChanged);
            // 
            // dgvDescuentos
            // 
            this.dgvDescuentos.AllowUserToAddRows = false;
            this.dgvDescuentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDescuentos.Location = new System.Drawing.Point(368, 297);
            this.dgvDescuentos.Name = "dgvDescuentos";
            this.dgvDescuentos.RowHeadersVisible = false;
            this.dgvDescuentos.Size = new System.Drawing.Size(302, 172);
            this.dgvDescuentos.TabIndex = 42;
            // 
            // dgvAportaciones
            // 
            this.dgvAportaciones.AllowUserToAddRows = false;
            this.dgvAportaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAportaciones.Location = new System.Drawing.Point(717, 297);
            this.dgvAportaciones.Name = "dgvAportaciones";
            this.dgvAportaciones.RowHeadersVisible = false;
            this.dgvAportaciones.Size = new System.Drawing.Size(274, 172);
            this.dgvAportaciones.TabIndex = 43;
            // 
            // dgvJornadaLaboral
            // 
            this.dgvJornadaLaboral.AllowUserToAddRows = false;
            this.dgvJornadaLaboral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJornadaLaboral.Location = new System.Drawing.Point(1029, 297);
            this.dgvJornadaLaboral.Name = "dgvJornadaLaboral";
            this.dgvJornadaLaboral.RowHeadersVisible = false;
            this.dgvJornadaLaboral.Size = new System.Drawing.Size(274, 172);
            this.dgvJornadaLaboral.TabIndex = 44;
            // 
            // chkSCTR
            // 
            this.chkSCTR.AutoSize = true;
            this.chkSCTR.Location = new System.Drawing.Point(1072, 69);
            this.chkSCTR.Name = "chkSCTR";
            this.chkSCTR.Size = new System.Drawing.Size(55, 17);
            this.chkSCTR.TabIndex = 36;
            this.chkSCTR.Text = "SCTR";
            this.chkSCTR.UseVisualStyleBackColor = true;
            // 
            // frmExportarTributosDescuentosTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 489);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvListaPlanillas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRuc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodForm);
            this.Controls.Add(this.dgvIngresos);
            this.Controls.Add(this.dgvDescuentos);
            this.Controls.Add(this.dgvAportaciones);
            this.Controls.Add(this.dgvJornadaLaboral);
            this.Name = "frmExportarTributosDescuentosTrabajador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar archivos de importación de tributos y descuentos del trabajador(PDT-PLAME" +
    ")";
            this.Load += new System.EventHandler(this.frmExportarTributosDescuentosTrabajador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPlanillas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSunat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescuentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAportaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJornadaLaboral)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIngresos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodForm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRuc;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DataGridView dgvListaPlanillas;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.ComboBox cbAños;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bntListarTodo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDescuentos;
        private System.Windows.Forms.DataGridView dgvAportaciones;
        private System.Windows.Forms.CheckBox CheckJornada;
        private System.Windows.Forms.DataGridView dgvJornadaLaboral;
        private System.Windows.Forms.PictureBox pbSunat;
        private System.Windows.Forms.CheckBox chkSCTR;
    }
}