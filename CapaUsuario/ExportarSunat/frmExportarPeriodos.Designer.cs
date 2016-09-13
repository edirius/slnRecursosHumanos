namespace CapaUsuario.ExportarSunat
{
    partial class frmExportarPeriodos
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
            this.btnExportar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvExportarPeriodos = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.DtHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.DtDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportarPeriodos)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(740, 14);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(160, 49);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "&Exportar Datos (.PER)";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvExportarPeriodos);
            this.groupBox1.Location = new System.Drawing.Point(9, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1241, 495);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // dgvExportarPeriodos
            // 
            this.dgvExportarPeriodos.AllowUserToAddRows = false;
            this.dgvExportarPeriodos.AllowUserToResizeColumns = false;
            this.dgvExportarPeriodos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvExportarPeriodos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExportarPeriodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExportarPeriodos.Location = new System.Drawing.Point(6, 14);
            this.dgvExportarPeriodos.Name = "dgvExportarPeriodos";
            this.dgvExportarPeriodos.ReadOnly = true;
            this.dgvExportarPeriodos.RowHeadersVisible = false;
            this.dgvExportarPeriodos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExportarPeriodos.Size = new System.Drawing.Size(1229, 475);
            this.dgvExportarPeriodos.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.DtHasta);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.DtDesde);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.btnExportar);
            this.groupBox5.Location = new System.Drawing.Point(9, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1241, 70);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Buscar trabajadores por Fecha:";
            // 
            // DtHasta
            // 
            this.DtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtHasta.Location = new System.Drawing.Point(602, 30);
            this.DtHasta.Name = "DtHasta";
            this.DtHasta.Size = new System.Drawing.Size(109, 20);
            this.DtHasta.TabIndex = 40;
            this.DtHasta.ValueChanged += new System.EventHandler(this.DtHasta_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(561, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Hasta:";
            // 
            // DtDesde
            // 
            this.DtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtDesde.Location = new System.Drawing.Point(416, 30);
            this.DtDesde.Name = "DtDesde";
            this.DtDesde.Size = new System.Drawing.Size(109, 20);
            this.DtDesde.TabIndex = 39;
            this.DtDesde.Value = new System.DateTime(2014, 9, 7, 12, 37, 0, 0);
            this.DtDesde.ValueChanged += new System.EventHandler(this.DtDesde_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(370, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Desde:";
            // 
            // frmExportarPeriodos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 579);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmExportarPeriodos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmExportarPeriodos";
            this.Load += new System.EventHandler(this.frmExportarPeriodos_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportarPeriodos)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DateTimePicker DtHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvExportarPeriodos;
    }
}