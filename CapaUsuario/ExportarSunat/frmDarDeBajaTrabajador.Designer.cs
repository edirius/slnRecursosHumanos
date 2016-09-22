namespace CapaUsuario.ExportarSunat
{
    partial class frmDarDeBajaTrabajador
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkSeleccionar = new System.Windows.Forms.CheckBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAños = new System.Windows.Forms.ComboBox();
            this.dgvDarDeBaja = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDarDeBaja)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkSeleccionar);
            this.groupBox1.Controls.Add(this.btnExportar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbMes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbAños);
            this.groupBox1.Location = new System.Drawing.Point(6, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(890, 75);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            // 
            // checkSeleccionar
            // 
            this.checkSeleccionar.AutoSize = true;
            this.checkSeleccionar.Location = new System.Drawing.Point(502, 35);
            this.checkSeleccionar.Name = "checkSeleccionar";
            this.checkSeleccionar.Size = new System.Drawing.Size(188, 17);
            this.checkSeleccionar.TabIndex = 42;
            this.checkSeleccionar.Text = "Seleccionar todos los trabajadores";
            this.checkSeleccionar.UseVisualStyleBackColor = true;
            this.checkSeleccionar.CheckedChanged += new System.EventHandler(this.checkSeleccionar_CheckedChanged);
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(696, 24);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(88, 37);
            this.btnExportar.TabIndex = 41;
            this.btnExportar.Text = "&Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 40;
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
            this.cbMes.Location = new System.Drawing.Point(196, 31);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(121, 21);
            this.cbMes.TabIndex = 37;
            this.cbMes.SelectedIndexChanged += new System.EventHandler(this.cbMes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Mes:";
            // 
            // cbAños
            // 
            this.cbAños.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAños.FormattingEnabled = true;
            this.cbAños.Location = new System.Drawing.Point(358, 31);
            this.cbAños.Name = "cbAños";
            this.cbAños.Size = new System.Drawing.Size(74, 21);
            this.cbAños.TabIndex = 38;
            this.cbAños.SelectedIndexChanged += new System.EventHandler(this.cbAños_SelectedIndexChanged);
            // 
            // dgvDarDeBaja
            // 
            this.dgvDarDeBaja.AllowUserToAddRows = false;
            this.dgvDarDeBaja.AllowUserToResizeColumns = false;
            this.dgvDarDeBaja.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvDarDeBaja.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDarDeBaja.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvDarDeBaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDarDeBaja.GridColor = System.Drawing.Color.White;
            this.dgvDarDeBaja.Location = new System.Drawing.Point(6, 81);
            this.dgvDarDeBaja.Name = "dgvDarDeBaja";
            this.dgvDarDeBaja.RowHeadersVisible = false;
            this.dgvDarDeBaja.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDarDeBaja.Size = new System.Drawing.Size(890, 412);
            this.dgvDarDeBaja.TabIndex = 41;
            // 
            // frmDarDeBajaTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 501);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvDarDeBaja);
            this.Name = "frmDarDeBajaTrabajador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dar de baja al trabajador";
            this.Load += new System.EventHandler(this.frmDarDeBajaTrabajador_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDarDeBaja)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkSeleccionar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAños;
        private System.Windows.Forms.DataGridView dgvDarDeBaja;
    }
}