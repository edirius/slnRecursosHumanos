namespace CapaUsuario.ExportarSunat
{
    partial class frmExportarExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportarExcel));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkSeleccionar = new System.Windows.Forms.CheckBox();
            this.bntListarTodo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAños = new System.Windows.Forms.ComboBox();
            this.dgvListaPlanillas = new System.Windows.Forms.DataGridView();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbAFPNET = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPlanillas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAFPNET)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 219);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1226, 124);
            this.dataGridView.TabIndex = 5;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.MintCream;
            this.btnExport.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnExport.Location = new System.Drawing.Point(886, 20);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(138, 39);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "&Exportar AFP a Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkSeleccionar);
            this.groupBox2.Controls.Add(this.bntListarTodo);
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbMes);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbAños);
            this.groupBox2.Location = new System.Drawing.Point(9, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1292, 81);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscar trabajadores por mes:";
            // 
            // checkSeleccionar
            // 
            this.checkSeleccionar.AutoSize = true;
            this.checkSeleccionar.Location = new System.Drawing.Point(6, 62);
            this.checkSeleccionar.Name = "checkSeleccionar";
            this.checkSeleccionar.Size = new System.Drawing.Size(167, 17);
            this.checkSeleccionar.TabIndex = 47;
            this.checkSeleccionar.Text = "Seleccionar todas las planillas";
            this.checkSeleccionar.UseVisualStyleBackColor = true;
            this.checkSeleccionar.CheckedChanged += new System.EventHandler(this.checkSeleccionar_CheckedChanged);
            // 
            // bntListarTodo
            // 
            this.bntListarTodo.BackColor = System.Drawing.Color.MintCream;
            this.bntListarTodo.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntListarTodo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.bntListarTodo.Location = new System.Drawing.Point(659, 20);
            this.bntListarTodo.Name = "bntListarTodo";
            this.bntListarTodo.Size = new System.Drawing.Size(179, 39);
            this.bntListarTodo.TabIndex = 33;
            this.bntListarTodo.Text = "&Listar todas las planillas\r\n por año";
            this.bntListarTodo.UseVisualStyleBackColor = false;
            this.bntListarTodo.Click += new System.EventHandler(this.bntListarTodo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(489, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 32;
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
            this.cbMes.Location = new System.Drawing.Point(352, 34);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(121, 21);
            this.cbMes.TabIndex = 29;
            this.cbMes.SelectedIndexChanged += new System.EventHandler(this.cbMes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(316, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Mes:";
            // 
            // cbAños
            // 
            this.cbAños.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAños.FormattingEnabled = true;
            this.cbAños.Location = new System.Drawing.Point(524, 34);
            this.cbAños.Name = "cbAños";
            this.cbAños.Size = new System.Drawing.Size(74, 21);
            this.cbAños.TabIndex = 30;
            this.cbAños.SelectedIndexChanged += new System.EventHandler(this.cbAños_SelectedIndexChanged);
            // 
            // dgvListaPlanillas
            // 
            this.dgvListaPlanillas.AllowUserToAddRows = false;
            this.dgvListaPlanillas.AllowUserToResizeColumns = false;
            this.dgvListaPlanillas.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvListaPlanillas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListaPlanillas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaPlanillas.Location = new System.Drawing.Point(9, 183);
            this.dgvListaPlanillas.Name = "dgvListaPlanillas";
            this.dgvListaPlanillas.RowHeadersVisible = false;
            this.dgvListaPlanillas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaPlanillas.Size = new System.Drawing.Size(1292, 396);
            this.dgvListaPlanillas.TabIndex = 42;
            this.dgvListaPlanillas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaPlanillas_CellClick);
            this.dgvListaPlanillas.SelectionChanged += new System.EventHandler(this.dgvListaPlanillas_SelectionChanged);
            // 
            // dgv2
            // 
            this.dgv2.AllowUserToAddRows = false;
            this.dgv2.AllowUserToDeleteRows = false;
            this.dgv2.AllowUserToResizeColumns = false;
            this.dgv2.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgv2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.txt1,
            this.txt2,
            this.txt3,
            this.txt4,
            this.txt5,
            this.txt6,
            this.txt7,
            this.txt8,
            this.txt9,
            this.txt10,
            this.txt11,
            this.txt12,
            this.txt13,
            this.txt14,
            this.txt15});
            this.dgv2.Location = new System.Drawing.Point(12, 349);
            this.dgv2.Name = "dgv2";
            this.dgv2.ReadOnly = true;
            this.dgv2.RowHeadersVisible = false;
            this.dgv2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv2.Size = new System.Drawing.Size(1226, 135);
            this.dgv2.TabIndex = 43;
            // 
            // Numero
            // 
            this.Numero.HeaderText = "N°";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            // 
            // txt1
            // 
            this.txt1.HeaderText = "Column1";
            this.txt1.Name = "txt1";
            this.txt1.ReadOnly = true;
            // 
            // txt2
            // 
            this.txt2.HeaderText = "Column1";
            this.txt2.Name = "txt2";
            this.txt2.ReadOnly = true;
            // 
            // txt3
            // 
            this.txt3.HeaderText = "Column1";
            this.txt3.Name = "txt3";
            this.txt3.ReadOnly = true;
            // 
            // txt4
            // 
            this.txt4.HeaderText = "Column1";
            this.txt4.Name = "txt4";
            this.txt4.ReadOnly = true;
            // 
            // txt5
            // 
            this.txt5.HeaderText = "Column1";
            this.txt5.Name = "txt5";
            this.txt5.ReadOnly = true;
            // 
            // txt6
            // 
            this.txt6.HeaderText = "Column1";
            this.txt6.Name = "txt6";
            this.txt6.ReadOnly = true;
            // 
            // txt7
            // 
            this.txt7.HeaderText = "Column1";
            this.txt7.Name = "txt7";
            this.txt7.ReadOnly = true;
            // 
            // txt8
            // 
            this.txt8.HeaderText = "Column1";
            this.txt8.Name = "txt8";
            this.txt8.ReadOnly = true;
            // 
            // txt9
            // 
            this.txt9.HeaderText = "Column1";
            this.txt9.Name = "txt9";
            this.txt9.ReadOnly = true;
            // 
            // txt10
            // 
            this.txt10.HeaderText = "Column1";
            this.txt10.Name = "txt10";
            this.txt10.ReadOnly = true;
            // 
            // txt11
            // 
            this.txt11.HeaderText = "Column1";
            this.txt11.Name = "txt11";
            this.txt11.ReadOnly = true;
            // 
            // txt12
            // 
            this.txt12.HeaderText = "Column1";
            this.txt12.Name = "txt12";
            this.txt12.ReadOnly = true;
            // 
            // txt13
            // 
            this.txt13.HeaderText = "Column1";
            this.txt13.Name = "txt13";
            this.txt13.ReadOnly = true;
            // 
            // txt14
            // 
            this.txt14.HeaderText = "Column1";
            this.txt14.Name = "txt14";
            this.txt14.ReadOnly = true;
            // 
            // txt15
            // 
            this.txt15.HeaderText = "Column1";
            this.txt15.Name = "txt15";
            this.txt15.ReadOnly = true;
            // 
            // pbAFPNET
            // 
            this.pbAFPNET.Image = global::CapaUsuario.Properties.Resources.header;
            this.pbAFPNET.Location = new System.Drawing.Point(229, 2);
            this.pbAFPNET.Name = "pbAFPNET";
            this.pbAFPNET.Size = new System.Drawing.Size(804, 88);
            this.pbAFPNET.TabIndex = 44;
            this.pbAFPNET.TabStop = false;
            // 
            // frmExportarExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 591);
            this.Controls.Add(this.pbAFPNET);
            this.Controls.Add(this.dgvListaPlanillas);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.dgv2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExportarExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar archivo para la exportación de datos a AFPNET";
            this.Load += new System.EventHandler(this.frmExportarExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPlanillas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAFPNET)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAños;
        private System.Windows.Forms.DataGridView dgvListaPlanillas;
        private System.Windows.Forms.Button bntListarTodo;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt2;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt3;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt4;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt5;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt6;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt7;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt8;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt9;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt10;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt11;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt12;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt13;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt14;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt15;
        private System.Windows.Forms.CheckBox checkSeleccionar;
        private System.Windows.Forms.PictureBox pbAFPNET;
    }
}