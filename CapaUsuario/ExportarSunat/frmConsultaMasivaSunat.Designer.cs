namespace CapaUsuario.ExportarSunat
{
    partial class frmConsultaMasivaSunat
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
            this.dgvConsultaMasivaAFP = new System.Windows.Forms.DataGridView();
            this.cbAños = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvListarTrabajadores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaMasivaAFP)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarTrabajadores)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConsultaMasivaAFP
            // 
            this.dgvConsultaMasivaAFP.AllowUserToAddRows = false;
            this.dgvConsultaMasivaAFP.AllowUserToResizeColumns = false;
            this.dgvConsultaMasivaAFP.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvConsultaMasivaAFP.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConsultaMasivaAFP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultaMasivaAFP.GridColor = System.Drawing.Color.White;
            this.dgvConsultaMasivaAFP.Location = new System.Drawing.Point(2, 409);
            this.dgvConsultaMasivaAFP.Name = "dgvConsultaMasivaAFP";
            this.dgvConsultaMasivaAFP.RowHeadersVisible = false;
            this.dgvConsultaMasivaAFP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsultaMasivaAFP.Size = new System.Drawing.Size(680, 55);
            this.dgvConsultaMasivaAFP.TabIndex = 38;
            // 
            // cbAños
            // 
            this.cbAños.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAños.FormattingEnabled = true;
            this.cbAños.Location = new System.Drawing.Point(347, 35);
            this.cbAños.Name = "cbAños";
            this.cbAños.Size = new System.Drawing.Size(74, 21);
            this.cbAños.TabIndex = 40;
            this.cbAños.SelectedIndexChanged += new System.EventHandler(this.cbAños_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Mes:";
            // 
            // btnExportar
            // 
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.Location = new System.Drawing.Point(495, 19);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(106, 50);
            this.btnExportar.TabIndex = 43;
            this.btnExportar.Text = "&Exportar a Excel";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 42;
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
            "SEPTIEMBRE",
            "OCTUBRE",
            "NOVIEMBRE",
            "DICIEMBRE"});
            this.cbMes.Location = new System.Drawing.Point(182, 35);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(121, 21);
            this.cbMes.TabIndex = 39;
            this.cbMes.SelectedIndexChanged += new System.EventHandler(this.cbMes_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExportar);
            this.groupBox1.Controls.Add(this.cbMes);
            this.groupBox1.Controls.Add(this.cbAños);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(683, 85);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dgvListarTrabajadores
            // 
            this.dgvListarTrabajadores.AllowUserToAddRows = false;
            this.dgvListarTrabajadores.AllowUserToResizeColumns = false;
            this.dgvListarTrabajadores.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvListarTrabajadores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListarTrabajadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListarTrabajadores.GridColor = System.Drawing.Color.White;
            this.dgvListarTrabajadores.Location = new System.Drawing.Point(2, 93);
            this.dgvListarTrabajadores.Name = "dgvListarTrabajadores";
            this.dgvListarTrabajadores.RowHeadersVisible = false;
            this.dgvListarTrabajadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListarTrabajadores.Size = new System.Drawing.Size(680, 371);
            this.dgvListarTrabajadores.TabIndex = 45;
            // 
            // frmConsultaMasivaSunat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 476);
            this.Controls.Add(this.dgvListarTrabajadores);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvConsultaMasivaAFP);
            this.Name = "frmConsultaMasivaSunat";
            this.Text = "frmConsultaMasivaSunat";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaMasivaAFP)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarTrabajadores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConsultaMasivaAFP;
        private System.Windows.Forms.ComboBox cbAños;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvListarTrabajadores;
    }
}