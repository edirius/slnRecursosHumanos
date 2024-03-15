namespace CapaUsuario.ExportarSunat
{
    partial class frmDarDeAlta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDarDeAlta));
            this.cbAños = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgListaTrabajadores = new System.Windows.Forms.DataGridView();
            this.chkSRCT = new System.Windows.Forms.CheckBox();
            this.checkEDU = new System.Windows.Forms.CheckBox();
            this.checkEST = new System.Windows.Forms.CheckBox();
            this.checkIDE = new System.Windows.Forms.CheckBox();
            this.checkPER = new System.Windows.Forms.CheckBox();
            this.checkTRA = new System.Windows.Forms.CheckBox();
            this.checkSelectAll = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTrabajadores)).BeginInit();
            this.SuspendLayout();
            // 
            // cbAños
            // 
            this.cbAños.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAños.FormattingEnabled = true;
            this.cbAños.Location = new System.Drawing.Point(204, 12);
            this.cbAños.Name = "cbAños";
            this.cbAños.Size = new System.Drawing.Size(74, 21);
            this.cbAños.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Mes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 15);
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
            "SETIEMBRE",
            "OCTUBRE",
            "NOVIEMBRE",
            "DICIEMBRE"});
            this.cbMes.Location = new System.Drawing.Point(39, 12);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(121, 21);
            this.cbMes.TabIndex = 37;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgListaTrabajadores);
            this.groupBox1.Location = new System.Drawing.Point(8, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(807, 348);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Trabajadores";
            // 
            // dtgListaTrabajadores
            // 
            this.dtgListaTrabajadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaTrabajadores.Location = new System.Drawing.Point(6, 19);
            this.dtgListaTrabajadores.Name = "dtgListaTrabajadores";
            this.dtgListaTrabajadores.Size = new System.Drawing.Size(781, 299);
            this.dtgListaTrabajadores.TabIndex = 0;
            // 
            // chkSRCT
            // 
            this.chkSRCT.AutoSize = true;
            this.chkSRCT.Location = new System.Drawing.Point(367, 52);
            this.chkSRCT.Name = "chkSRCT";
            this.chkSRCT.Size = new System.Drawing.Size(55, 17);
            this.chkSRCT.TabIndex = 51;
            this.chkSRCT.Text = "SRCT";
            this.chkSRCT.UseVisualStyleBackColor = true;
            // 
            // checkEDU
            // 
            this.checkEDU.AutoSize = true;
            this.checkEDU.Location = new System.Drawing.Point(301, 52);
            this.checkEDU.Name = "checkEDU";
            this.checkEDU.Size = new System.Drawing.Size(49, 17);
            this.checkEDU.TabIndex = 49;
            this.checkEDU.Text = "EDU";
            this.checkEDU.UseVisualStyleBackColor = true;
            // 
            // checkEST
            // 
            this.checkEST.AutoSize = true;
            this.checkEST.Location = new System.Drawing.Point(231, 52);
            this.checkEST.Name = "checkEST";
            this.checkEST.Size = new System.Drawing.Size(47, 17);
            this.checkEST.TabIndex = 48;
            this.checkEST.Text = "EST";
            this.checkEST.UseVisualStyleBackColor = true;
            // 
            // checkIDE
            // 
            this.checkIDE.AutoSize = true;
            this.checkIDE.Location = new System.Drawing.Point(18, 52);
            this.checkIDE.Name = "checkIDE";
            this.checkIDE.Size = new System.Drawing.Size(44, 17);
            this.checkIDE.TabIndex = 45;
            this.checkIDE.Text = "IDE";
            this.checkIDE.UseVisualStyleBackColor = true;
            // 
            // checkPER
            // 
            this.checkPER.AutoSize = true;
            this.checkPER.Location = new System.Drawing.Point(153, 52);
            this.checkPER.Name = "checkPER";
            this.checkPER.Size = new System.Drawing.Size(48, 17);
            this.checkPER.TabIndex = 47;
            this.checkPER.Text = "PER";
            this.checkPER.UseVisualStyleBackColor = true;
            // 
            // checkTRA
            // 
            this.checkTRA.AutoSize = true;
            this.checkTRA.Location = new System.Drawing.Point(81, 52);
            this.checkTRA.Name = "checkTRA";
            this.checkTRA.Size = new System.Drawing.Size(48, 17);
            this.checkTRA.TabIndex = 46;
            this.checkTRA.Text = "TRA";
            this.checkTRA.UseVisualStyleBackColor = true;
            // 
            // checkSelectAll
            // 
            this.checkSelectAll.AutoSize = true;
            this.checkSelectAll.Location = new System.Drawing.Point(510, 52);
            this.checkSelectAll.Name = "checkSelectAll";
            this.checkSelectAll.Size = new System.Drawing.Size(188, 17);
            this.checkSelectAll.TabIndex = 50;
            this.checkSelectAll.Text = "Seleccionar todos los trabajadores";
            this.checkSelectAll.UseVisualStyleBackColor = true;
            // 
            // frmDarDeAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 422);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDarDeAlta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dar de Alta Tregistro x Planilla";
            this.Load += new System.EventHandler(this.frmDarDeAlta_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTrabajadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbAños;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgListaTrabajadores;
        private System.Windows.Forms.CheckBox chkSRCT;
        private System.Windows.Forms.CheckBox checkEDU;
        private System.Windows.Forms.CheckBox checkEST;
        private System.Windows.Forms.CheckBox checkIDE;
        private System.Windows.Forms.CheckBox checkPER;
        private System.Windows.Forms.CheckBox checkTRA;
        private System.Windows.Forms.CheckBox checkSelectAll;
    }
}