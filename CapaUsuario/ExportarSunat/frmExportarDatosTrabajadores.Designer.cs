namespace CapaUsuario.ExportarSunat
{
    partial class frmExportarDatosTrabajadores
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
            this.dgvListarTrabajadores = new System.Windows.Forms.DataGridView();
            this.btnExportar = new System.Windows.Forms.Button();
            this.DtDesde = new System.Windows.Forms.DateTimePicker();
            this.DtHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarTrabajadores)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListarTrabajadores
            // 
            this.dgvListarTrabajadores.AllowUserToAddRows = false;
            this.dgvListarTrabajadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListarTrabajadores.Location = new System.Drawing.Point(13, 79);
            this.dgvListarTrabajadores.Name = "dgvListarTrabajadores";
            this.dgvListarTrabajadores.RowHeadersVisible = false;
            this.dgvListarTrabajadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListarTrabajadores.Size = new System.Drawing.Size(1225, 400);
            this.dgvListarTrabajadores.TabIndex = 29;
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(720, 19);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(126, 41);
            this.btnExportar.TabIndex = 30;
            this.btnExportar.Text = "&EXPORTAR (.IDE)";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // DtDesde
            // 
            this.DtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtDesde.Location = new System.Drawing.Point(405, 30);
            this.DtDesde.Name = "DtDesde";
            this.DtDesde.Size = new System.Drawing.Size(109, 20);
            this.DtDesde.TabIndex = 31;
            this.DtDesde.Value = new System.DateTime(2014, 9, 7, 12, 37, 0, 0);
            this.DtDesde.ValueChanged += new System.EventHandler(this.DtDesde_ValueChanged);
            // 
            // DtHasta
            // 
            this.DtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtHasta.Location = new System.Drawing.Point(591, 30);
            this.DtHasta.Name = "DtHasta";
            this.DtHasta.Size = new System.Drawing.Size(109, 20);
            this.DtHasta.TabIndex = 32;
            this.DtHasta.ValueChanged += new System.EventHandler(this.DtHasta_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(359, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(550, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Hasta:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtHasta);
            this.groupBox1.Controls.Add(this.btnExportar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DtDesde);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1223, 68);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar datos personales del trabajador:";
            // 
            // frmExportarDatosTrabajadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 490);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvListarTrabajadores);
            this.Name = "frmExportarDatosTrabajadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmExportarDatosTrabajadores";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarTrabajadores)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListarTrabajadores;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DateTimePicker DtDesde;
        private System.Windows.Forms.DateTimePicker DtHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}