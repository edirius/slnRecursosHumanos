namespace CapaUsuario.ExportarSunat
{
    partial class frmExportarDatosDeEstudiosConcluidos
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
            this.dgvDatosEstudios = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.DtDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosEstudios)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(323, 14);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(112, 50);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "&Exportar Datos (.EDU)";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // dgvDatosEstudios
            // 
            this.dgvDatosEstudios.AllowUserToAddRows = false;
            this.dgvDatosEstudios.AllowUserToResizeColumns = false;
            this.dgvDatosEstudios.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvDatosEstudios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatosEstudios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDatosEstudios.Location = new System.Drawing.Point(12, 90);
            this.dgvDatosEstudios.Name = "dgvDatosEstudios";
            this.dgvDatosEstudios.ReadOnly = true;
            this.dgvDatosEstudios.RowHeadersVisible = false;
            this.dgvDatosEstudios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatosEstudios.Size = new System.Drawing.Size(441, 344);
            this.dgvDatosEstudios.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtHasta);
            this.groupBox1.Controls.Add(this.btnExportar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DtDesde);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 75);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar trabajadores por fecha:";
            // 
            // DtHasta
            // 
            this.DtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtHasta.Location = new System.Drawing.Point(208, 29);
            this.DtHasta.Name = "DtHasta";
            this.DtHasta.Size = new System.Drawing.Size(109, 20);
            this.DtHasta.TabIndex = 36;
            this.DtHasta.ValueChanged += new System.EventHandler(this.DtHasta_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Hasta:";
            // 
            // DtDesde
            // 
            this.DtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtDesde.Location = new System.Drawing.Point(49, 29);
            this.DtDesde.Name = "DtDesde";
            this.DtDesde.Size = new System.Drawing.Size(109, 20);
            this.DtDesde.TabIndex = 35;
            this.DtDesde.Value = new System.DateTime(2014, 9, 7, 12, 37, 0, 0);
            this.DtDesde.ValueChanged += new System.EventHandler(this.DtDesde_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Desde:";
            // 
            // frmExportarDatosDeEstudiosConcluidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 448);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvDatosEstudios);
            this.Name = "frmExportarDatosDeEstudiosConcluidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmExportarDatosDeEstudiosConcluidos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosEstudios)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DataGridView dgvDatosEstudios;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DtHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtDesde;
        private System.Windows.Forms.Label label1;
    }
}