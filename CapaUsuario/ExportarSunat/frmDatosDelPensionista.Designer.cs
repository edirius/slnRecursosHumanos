namespace CapaUsuario.ExportarSunat
{
    partial class frmDatosDelPensionista
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtHasta = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DtDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvListarPensionistas = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarPensionistas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtHasta);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DtDesde);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(953, 70);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar pensionistas por fecha:";
            // 
            // DtHasta
            // 
            this.DtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtHasta.Location = new System.Drawing.Point(451, 34);
            this.DtHasta.Name = "DtHasta";
            this.DtHasta.Size = new System.Drawing.Size(109, 20);
            this.DtHasta.TabIndex = 36;
            this.DtHasta.ValueChanged += new System.EventHandler(this.DtHasta_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(571, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 43);
            this.button1.TabIndex = 1;
            this.button1.Text = "&EXPORTAR (.PEN)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(410, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Hasta:";
            // 
            // DtDesde
            // 
            this.DtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtDesde.Location = new System.Drawing.Point(288, 34);
            this.DtDesde.Name = "DtDesde";
            this.DtDesde.Size = new System.Drawing.Size(109, 20);
            this.DtDesde.TabIndex = 35;
            this.DtDesde.Value = new System.DateTime(2014, 9, 7, 12, 37, 0, 0);
            this.DtDesde.ValueChanged += new System.EventHandler(this.DtDesde_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Desde:";
            // 
            // dgvListarPensionistas
            // 
            this.dgvListarPensionistas.AllowUserToAddRows = false;
            this.dgvListarPensionistas.AllowUserToDeleteRows = false;
            this.dgvListarPensionistas.AllowUserToResizeColumns = false;
            this.dgvListarPensionistas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvListarPensionistas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListarPensionistas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListarPensionistas.Location = new System.Drawing.Point(5, 80);
            this.dgvListarPensionistas.Name = "dgvListarPensionistas";
            this.dgvListarPensionistas.ReadOnly = true;
            this.dgvListarPensionistas.RowHeadersVisible = false;
            this.dgvListarPensionistas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListarPensionistas.Size = new System.Drawing.Size(953, 423);
            this.dgvListarPensionistas.TabIndex = 40;
            // 
            // frmDatosDelPensionista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 508);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvListarPensionistas);
            this.Name = "frmDatosDelPensionista";
            this.Text = "frmDatosDelPensionista";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarPensionistas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DtHasta;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvListarPensionistas;
    }
}