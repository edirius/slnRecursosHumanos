﻿namespace CapaUsuario.ExportarSunat
{
    partial class frmExportarTodo
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvListarTrabajadores = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAños = new System.Windows.Forms.ComboBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVerCodificacion = new System.Windows.Forms.Button();
            this.chkSRCT = new System.Windows.Forms.CheckBox();
            this.checkEDU = new System.Windows.Forms.CheckBox();
            this.checkEST = new System.Windows.Forms.CheckBox();
            this.checkIDE = new System.Windows.Forms.CheckBox();
            this.checkPER = new System.Windows.Forms.CheckBox();
            this.checkTRA = new System.Windows.Forms.CheckBox();
            this.checkSelectAll = new System.Windows.Forms.CheckBox();
            this.tipMensaje = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarTrabajadores)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListarTrabajadores
            // 
            this.dgvListarTrabajadores.AllowUserToAddRows = false;
            this.dgvListarTrabajadores.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvListarTrabajadores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListarTrabajadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListarTrabajadores.GridColor = System.Drawing.Color.White;
            this.dgvListarTrabajadores.Location = new System.Drawing.Point(7, 118);
            this.dgvListarTrabajadores.Name = "dgvListarTrabajadores";
            this.dgvListarTrabajadores.RowHeadersVisible = false;
            this.dgvListarTrabajadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListarTrabajadores.Size = new System.Drawing.Size(902, 437);
            this.dgvListarTrabajadores.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 36;
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
            this.cbMes.Location = new System.Drawing.Point(64, 35);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(121, 21);
            this.cbMes.TabIndex = 33;
            this.cbMes.SelectedIndexChanged += new System.EventHandler(this.cbMes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Mes:";
            // 
            // cbAños
            // 
            this.cbAños.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAños.FormattingEnabled = true;
            this.cbAños.Location = new System.Drawing.Point(229, 35);
            this.cbAños.Name = "cbAños";
            this.cbAños.Size = new System.Drawing.Size(74, 21);
            this.cbAños.TabIndex = 34;
            this.cbAños.SelectedIndexChanged += new System.EventHandler(this.cbAños_SelectedIndexChanged);
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.MintCream;
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnExportar.Location = new System.Drawing.Point(641, 19);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(106, 50);
            this.btnExportar.TabIndex = 37;
            this.btnExportar.Text = "&Exportar Datos";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnVerCodificacion);
            this.groupBox1.Controls.Add(this.chkSRCT);
            this.groupBox1.Controls.Add(this.checkEDU);
            this.groupBox1.Controls.Add(this.cbAños);
            this.groupBox1.Controls.Add(this.checkEST);
            this.groupBox1.Controls.Add(this.checkIDE);
            this.groupBox1.Controls.Add(this.checkPER);
            this.groupBox1.Controls.Add(this.checkTRA);
            this.groupBox1.Controls.Add(this.checkSelectAll);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnExportar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbMes);
            this.groupBox1.Location = new System.Drawing.Point(7, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(902, 113);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            // 
            // btnVerCodificacion
            // 
            this.btnVerCodificacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerCodificacion.BackColor = System.Drawing.Color.MintCream;
            this.btnVerCodificacion.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnVerCodificacion.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnVerCodificacion.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnVerCodificacion.Location = new System.Drawing.Point(786, 19);
            this.btnVerCodificacion.Name = "btnVerCodificacion";
            this.btnVerCodificacion.Size = new System.Drawing.Size(100, 50);
            this.btnVerCodificacion.TabIndex = 61;
            this.btnVerCodificacion.Text = "&Ver Codificacion";
            this.btnVerCodificacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVerCodificacion.UseVisualStyleBackColor = false;
            this.btnVerCodificacion.Click += new System.EventHandler(this.btnVerCodificacion_Click);
            // 
            // chkSRCT
            // 
            this.chkSRCT.AutoSize = true;
            this.chkSRCT.Location = new System.Drawing.Point(452, 90);
            this.chkSRCT.Name = "chkSRCT";
            this.chkSRCT.Size = new System.Drawing.Size(55, 17);
            this.chkSRCT.TabIndex = 44;
            this.chkSRCT.Text = "SRCT";
            this.chkSRCT.UseVisualStyleBackColor = true;
            // 
            // checkEDU
            // 
            this.checkEDU.AutoSize = true;
            this.checkEDU.Location = new System.Drawing.Point(382, 90);
            this.checkEDU.Name = "checkEDU";
            this.checkEDU.Size = new System.Drawing.Size(49, 17);
            this.checkEDU.TabIndex = 42;
            this.checkEDU.Text = "EDU";
            this.checkEDU.UseVisualStyleBackColor = true;
            // 
            // checkEST
            // 
            this.checkEST.AutoSize = true;
            this.checkEST.Location = new System.Drawing.Point(293, 90);
            this.checkEST.Name = "checkEST";
            this.checkEST.Size = new System.Drawing.Size(47, 17);
            this.checkEST.TabIndex = 41;
            this.checkEST.Text = "EST";
            this.checkEST.UseVisualStyleBackColor = true;
            // 
            // checkIDE
            // 
            this.checkIDE.AutoSize = true;
            this.checkIDE.Location = new System.Drawing.Point(30, 90);
            this.checkIDE.Name = "checkIDE";
            this.checkIDE.Size = new System.Drawing.Size(44, 17);
            this.checkIDE.TabIndex = 38;
            this.checkIDE.Text = "IDE";
            this.checkIDE.UseVisualStyleBackColor = true;
            // 
            // checkPER
            // 
            this.checkPER.AutoSize = true;
            this.checkPER.Location = new System.Drawing.Point(201, 90);
            this.checkPER.Name = "checkPER";
            this.checkPER.Size = new System.Drawing.Size(48, 17);
            this.checkPER.TabIndex = 40;
            this.checkPER.Text = "PER";
            this.checkPER.UseVisualStyleBackColor = true;
            // 
            // checkTRA
            // 
            this.checkTRA.AutoSize = true;
            this.checkTRA.Location = new System.Drawing.Point(113, 90);
            this.checkTRA.Name = "checkTRA";
            this.checkTRA.Size = new System.Drawing.Size(48, 17);
            this.checkTRA.TabIndex = 39;
            this.checkTRA.Text = "TRA";
            this.checkTRA.UseVisualStyleBackColor = true;
            // 
            // checkSelectAll
            // 
            this.checkSelectAll.AutoSize = true;
            this.checkSelectAll.Location = new System.Drawing.Point(522, 90);
            this.checkSelectAll.Name = "checkSelectAll";
            this.checkSelectAll.Size = new System.Drawing.Size(188, 17);
            this.checkSelectAll.TabIndex = 43;
            this.checkSelectAll.Text = "Seleccionar todos los trabajadores";
            this.checkSelectAll.UseVisualStyleBackColor = true;
            this.checkSelectAll.CheckedChanged += new System.EventHandler(this.checkSelectAll_CheckedChanged);
            // 
            // frmExportarTodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 567);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvListarTrabajadores);
            this.Name = "frmExportarTodo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dar de alta al trabajador(T-REGISTRO)";
            this.Load += new System.EventHandler(this.frmExportarTodo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarTrabajadores)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListarTrabajadores;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAños;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkEDU;
        private System.Windows.Forms.CheckBox checkEST;
        private System.Windows.Forms.CheckBox checkPER;
        private System.Windows.Forms.CheckBox checkTRA;
        private System.Windows.Forms.CheckBox checkIDE;
        private System.Windows.Forms.CheckBox checkSelectAll;
        private System.Windows.Forms.CheckBox chkSRCT;
        private System.Windows.Forms.ToolTip tipMensaje;
        private System.Windows.Forms.Button btnVerCodificacion;
    }
}