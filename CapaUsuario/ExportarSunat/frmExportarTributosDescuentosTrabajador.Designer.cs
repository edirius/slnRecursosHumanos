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
            this.dgvDescuentos = new System.Windows.Forms.DataGridView();
            this.dgvAportaciones = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPlanillas)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescuentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAportaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIngresos
            // 
            this.dgvIngresos.AllowUserToAddRows = false;
            this.dgvIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngresos.Location = new System.Drawing.Point(12, 297);
            this.dgvIngresos.Name = "dgvIngresos";
            this.dgvIngresos.RowHeadersVisible = false;
            this.dgvIngresos.Size = new System.Drawing.Size(384, 172);
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
            this.txtRuc.Text = "20226560824";
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(804, 19);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(107, 40);
            this.btnExportar.TabIndex = 24;
            this.btnExportar.Text = "&Exportar Datos";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // dgvListaPlanillas
            // 
            this.dgvListaPlanillas.AllowUserToAddRows = false;
            this.dgvListaPlanillas.AllowUserToResizeColumns = false;
            this.dgvListaPlanillas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaPlanillas.Location = new System.Drawing.Point(11, 93);
            this.dgvListaPlanillas.Name = "dgvListaPlanillas";
            this.dgvListaPlanillas.RowHeadersVisible = false;
            this.dgvListaPlanillas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaPlanillas.Size = new System.Drawing.Size(1226, 376);
            this.dgvListaPlanillas.TabIndex = 28;
            this.dgvListaPlanillas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaPlanillas_CellClick);
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
            this.cbMes.Location = new System.Drawing.Point(316, 30);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(121, 21);
            this.cbMes.TabIndex = 29;
            this.cbMes.SelectedIndexChanged += new System.EventHandler(this.cbMes_SelectedIndexChanged);
            // 
            // cbAños
            // 
            this.cbAños.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAños.FormattingEnabled = true;
            this.cbAños.Location = new System.Drawing.Point(505, 30);
            this.cbAños.Name = "cbAños";
            this.cbAños.Size = new System.Drawing.Size(74, 21);
            this.cbAños.TabIndex = 30;
            this.cbAños.SelectedIndexChanged += new System.EventHandler(this.cbAños_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Mes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(470, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Año:";
            // 
            // bntListarTodo
            // 
            this.bntListarTodo.Location = new System.Drawing.Point(619, 19);
            this.bntListarTodo.Name = "bntListarTodo";
            this.bntListarTodo.Size = new System.Drawing.Size(154, 40);
            this.bntListarTodo.TabIndex = 33;
            this.bntListarTodo.Text = "&Listar todas las\r\n planillas por año";
            this.bntListarTodo.UseVisualStyleBackColor = true;
            this.bntListarTodo.Click += new System.EventHandler(this.bntListarTodo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bntListarTodo);
            this.groupBox1.Controls.Add(this.btnExportar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbMes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbAños);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1225, 75);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar trabajadores por fecha:";
            // 
            // dgvDescuentos
            // 
            this.dgvDescuentos.AllowUserToAddRows = false;
            this.dgvDescuentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDescuentos.Location = new System.Drawing.Point(427, 297);
            this.dgvDescuentos.Name = "dgvDescuentos";
            this.dgvDescuentos.RowHeadersVisible = false;
            this.dgvDescuentos.Size = new System.Drawing.Size(385, 172);
            this.dgvDescuentos.TabIndex = 42;
            // 
            // dgvAportaciones
            // 
            this.dgvAportaciones.AllowUserToAddRows = false;
            this.dgvAportaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAportaciones.Location = new System.Drawing.Point(852, 297);
            this.dgvAportaciones.Name = "dgvAportaciones";
            this.dgvAportaciones.RowHeadersVisible = false;
            this.dgvAportaciones.Size = new System.Drawing.Size(385, 172);
            this.dgvAportaciones.TabIndex = 43;
            // 
            // frmExportarTributosDescuentosTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 489);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvListaPlanillas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRuc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodForm);
            this.Controls.Add(this.dgvIngresos);
            this.Controls.Add(this.dgvDescuentos);
            this.Controls.Add(this.dgvAportaciones);
            this.Name = "frmExportarTributosDescuentosTrabajador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmExportarTributosDescuentosTrabajador";
            this.Load += new System.EventHandler(this.frmExportarTributosDescuentosTrabajador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPlanillas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescuentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAportaciones)).EndInit();
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
    }
}