namespace CapaUsuario.ExportarSunat.Tregistro
{
    partial class frmDarAltaTregistro
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
            this.chkSRCT = new System.Windows.Forms.CheckBox();
            this.checkEDU = new System.Windows.Forms.CheckBox();
            this.checkEST = new System.Windows.Forms.CheckBox();
            this.checkIDE = new System.Windows.Forms.CheckBox();
            this.checkPER = new System.Windows.Forms.CheckBox();
            this.checkTRA = new System.Windows.Forms.CheckBox();
            this.checkSelectAll = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgListaTrabajadores = new System.Windows.Forms.DataGridView();
            this.cbAños = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.btnVerCodificacion = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTrabajadores)).BeginInit();
            this.SuspendLayout();
            // 
            // chkSRCT
            // 
            this.chkSRCT.AutoSize = true;
            this.chkSRCT.Location = new System.Drawing.Point(374, 52);
            this.chkSRCT.Name = "chkSRCT";
            this.chkSRCT.Size = new System.Drawing.Size(55, 17);
            this.chkSRCT.TabIndex = 63;
            this.chkSRCT.Text = "SRCT";
            this.chkSRCT.UseVisualStyleBackColor = true;
            // 
            // checkEDU
            // 
            this.checkEDU.AutoSize = true;
            this.checkEDU.Location = new System.Drawing.Point(308, 52);
            this.checkEDU.Name = "checkEDU";
            this.checkEDU.Size = new System.Drawing.Size(49, 17);
            this.checkEDU.TabIndex = 61;
            this.checkEDU.Text = "EDU";
            this.checkEDU.UseVisualStyleBackColor = true;
            // 
            // checkEST
            // 
            this.checkEST.AutoSize = true;
            this.checkEST.Location = new System.Drawing.Point(238, 52);
            this.checkEST.Name = "checkEST";
            this.checkEST.Size = new System.Drawing.Size(47, 17);
            this.checkEST.TabIndex = 60;
            this.checkEST.Text = "EST";
            this.checkEST.UseVisualStyleBackColor = true;
            // 
            // checkIDE
            // 
            this.checkIDE.AutoSize = true;
            this.checkIDE.Location = new System.Drawing.Point(25, 52);
            this.checkIDE.Name = "checkIDE";
            this.checkIDE.Size = new System.Drawing.Size(44, 17);
            this.checkIDE.TabIndex = 57;
            this.checkIDE.Text = "IDE";
            this.checkIDE.UseVisualStyleBackColor = true;
            // 
            // checkPER
            // 
            this.checkPER.AutoSize = true;
            this.checkPER.Location = new System.Drawing.Point(160, 52);
            this.checkPER.Name = "checkPER";
            this.checkPER.Size = new System.Drawing.Size(48, 17);
            this.checkPER.TabIndex = 59;
            this.checkPER.Text = "PER";
            this.checkPER.UseVisualStyleBackColor = true;
            // 
            // checkTRA
            // 
            this.checkTRA.AutoSize = true;
            this.checkTRA.Location = new System.Drawing.Point(88, 52);
            this.checkTRA.Name = "checkTRA";
            this.checkTRA.Size = new System.Drawing.Size(48, 17);
            this.checkTRA.TabIndex = 58;
            this.checkTRA.Text = "TRA";
            this.checkTRA.UseVisualStyleBackColor = true;
            // 
            // checkSelectAll
            // 
            this.checkSelectAll.AutoSize = true;
            this.checkSelectAll.Location = new System.Drawing.Point(447, 52);
            this.checkSelectAll.Name = "checkSelectAll";
            this.checkSelectAll.Size = new System.Drawing.Size(188, 17);
            this.checkSelectAll.TabIndex = 62;
            this.checkSelectAll.Text = "Seleccionar todos los trabajadores";
            this.checkSelectAll.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgListaTrabajadores);
            this.groupBox1.Location = new System.Drawing.Point(15, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(807, 348);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Trabajadores";
            // 
            // dtgListaTrabajadores
            // 
            this.dtgListaTrabajadores.AllowUserToAddRows = false;
            this.dtgListaTrabajadores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dtgListaTrabajadores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaTrabajadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaTrabajadores.Location = new System.Drawing.Point(6, 19);
            this.dtgListaTrabajadores.Name = "dtgListaTrabajadores";
            this.dtgListaTrabajadores.ReadOnly = true;
            this.dtgListaTrabajadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaTrabajadores.Size = new System.Drawing.Size(781, 299);
            this.dtgListaTrabajadores.TabIndex = 0;
            // 
            // cbAños
            // 
            this.cbAños.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAños.FormattingEnabled = true;
            this.cbAños.Location = new System.Drawing.Point(211, 12);
            this.cbAños.Name = "cbAños";
            this.cbAños.Size = new System.Drawing.Size(74, 21);
            this.cbAños.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Mes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 55;
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
            this.cbMes.Location = new System.Drawing.Point(46, 12);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(121, 21);
            this.cbMes.TabIndex = 52;
            this.cbMes.SelectedIndexChanged += new System.EventHandler(this.cbMes_SelectedIndexChanged);
            // 
            // btnVerCodificacion
            // 
            this.btnVerCodificacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerCodificacion.BackColor = System.Drawing.Color.MintCream;
            this.btnVerCodificacion.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnVerCodificacion.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnVerCodificacion.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnVerCodificacion.Location = new System.Drawing.Point(856, 12);
            this.btnVerCodificacion.Name = "btnVerCodificacion";
            this.btnVerCodificacion.Size = new System.Drawing.Size(100, 50);
            this.btnVerCodificacion.TabIndex = 65;
            this.btnVerCodificacion.Text = "&Ver Codificacion";
            this.btnVerCodificacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVerCodificacion.UseVisualStyleBackColor = false;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.MintCream;
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnExportar.Location = new System.Drawing.Point(711, 12);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(106, 50);
            this.btnExportar.TabIndex = 64;
            this.btnExportar.Text = "&Exportar Datos";
            this.btnExportar.UseVisualStyleBackColor = false;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(835, 279);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(121, 97);
            this.listView1.TabIndex = 66;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // frmDarAltaTregistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 502);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnVerCodificacion);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.chkSRCT);
            this.Controls.Add(this.checkEDU);
            this.Controls.Add(this.checkEST);
            this.Controls.Add(this.checkIDE);
            this.Controls.Add(this.checkPER);
            this.Controls.Add(this.checkTRA);
            this.Controls.Add(this.checkSelectAll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbAños);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbMes);
            this.Name = "frmDarAltaTregistro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dar de Alta Tregistro";
            this.Load += new System.EventHandler(this.frmDarAltaTregistro_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTrabajadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSRCT;
        private System.Windows.Forms.CheckBox checkEDU;
        private System.Windows.Forms.CheckBox checkEST;
        private System.Windows.Forms.CheckBox checkIDE;
        private System.Windows.Forms.CheckBox checkPER;
        private System.Windows.Forms.CheckBox checkTRA;
        private System.Windows.Forms.CheckBox checkSelectAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgListaTrabajadores;
        private System.Windows.Forms.ComboBox cbAños;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.Button btnVerCodificacion;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.ListView listView1;
    }
}