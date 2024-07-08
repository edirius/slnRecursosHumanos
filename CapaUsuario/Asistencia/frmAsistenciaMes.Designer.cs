namespace CapaUsuario.Asistencia
{
    partial class frmAsistenciaMes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsistenciaMes));
            this.CalendarioAsistencia = new System.Windows.Forms.MonthCalendar();
            this.lblNombredelTrabajador = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.dtgDetalleAsistencia = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotaltardanzas = new System.Windows.Forms.Label();
            this.lblTotalFaltas = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtgListaSalidas = new System.Windows.Forms.DataGridView();
            this.chkTodoElMes = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMinutostarde = new System.Windows.Forms.Label();
            this.lblFaltaDia = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.dlgGuardarReportePDF = new System.Windows.Forms.SaveFileDialog();
            this.chkSalidasTodoElMes = new System.Windows.Forms.CheckBox();
            this.btnImprimirMes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleAsistencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaSalidas)).BeginInit();
            this.SuspendLayout();
            // 
            // CalendarioAsistencia
            // 
            this.CalendarioAsistencia.BoldedDates = new System.DateTime[] {
        new System.DateTime(2021, 5, 24, 0, 0, 0, 0)};
            this.CalendarioAsistencia.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.CalendarioAsistencia.Location = new System.Drawing.Point(17, 113);
            this.CalendarioAsistencia.Name = "CalendarioAsistencia";
            this.CalendarioAsistencia.TabIndex = 0;
            this.CalendarioAsistencia.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.CalendarioAsistencia_DateChanged);
            this.CalendarioAsistencia.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.CalendarioAsistencia_DateSelected);
            // 
            // lblNombredelTrabajador
            // 
            this.lblNombredelTrabajador.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblNombredelTrabajador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNombredelTrabajador.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNombredelTrabajador.Location = new System.Drawing.Point(0, 0);
            this.lblNombredelTrabajador.Name = "lblNombredelTrabajador";
            this.lblNombredelTrabajador.Size = new System.Drawing.Size(933, 23);
            this.lblNombredelTrabajador.TabIndex = 78;
            this.lblNombredelTrabajador.Text = "Nombres";
            this.lblNombredelTrabajador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(140, 54);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(121, 21);
            this.cboMes.TabIndex = 79;
            this.cboMes.SelectedIndexChanged += new System.EventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "PERIODO: ";
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(17, 54);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(81, 21);
            this.cboAño.TabIndex = 81;
            this.cboAño.SelectedIndexChanged += new System.EventHandler(this.cboAño_SelectedIndexChanged);
            // 
            // dtgDetalleAsistencia
            // 
            this.dtgDetalleAsistencia.AllowUserToAddRows = false;
            this.dtgDetalleAsistencia.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dtgDetalleAsistencia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgDetalleAsistencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleAsistencia.Location = new System.Drawing.Point(335, 113);
            this.dtgDetalleAsistencia.MultiSelect = false;
            this.dtgDetalleAsistencia.Name = "dtgDetalleAsistencia";
            this.dtgDetalleAsistencia.ReadOnly = true;
            this.dtgDetalleAsistencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleAsistencia.Size = new System.Drawing.Size(222, 162);
            this.dtgDetalleAsistencia.TabIndex = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "Minutos Total tardanza:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 352);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 84;
            this.label3.Text = "Total Faltas:";
            // 
            // lblTotaltardanzas
            // 
            this.lblTotaltardanzas.AutoSize = true;
            this.lblTotaltardanzas.Location = new System.Drawing.Point(183, 314);
            this.lblTotaltardanzas.Name = "lblTotaltardanzas";
            this.lblTotaltardanzas.Size = new System.Drawing.Size(13, 13);
            this.lblTotaltardanzas.TabIndex = 85;
            this.lblTotaltardanzas.Text = "0";
            // 
            // lblTotalFaltas
            // 
            this.lblTotalFaltas.AutoSize = true;
            this.lblTotalFaltas.Location = new System.Drawing.Point(186, 352);
            this.lblTotalFaltas.Name = "lblTotalFaltas";
            this.lblTotalFaltas.Size = new System.Drawing.Size(13, 13);
            this.lblTotalFaltas.TabIndex = 86;
            this.lblTotalFaltas.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(335, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 87;
            this.label4.Text = "Lista de Picados";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(596, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 88;
            this.label5.Text = "Lista de Salidas";
            // 
            // dtgListaSalidas
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender;
            this.dtgListaSalidas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgListaSalidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaSalidas.Location = new System.Drawing.Point(596, 113);
            this.dtgListaSalidas.Name = "dtgListaSalidas";
            this.dtgListaSalidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaSalidas.Size = new System.Drawing.Size(308, 162);
            this.dtgListaSalidas.TabIndex = 89;
            // 
            // chkTodoElMes
            // 
            this.chkTodoElMes.AutoSize = true;
            this.chkTodoElMes.Location = new System.Drawing.Point(338, 90);
            this.chkTodoElMes.Name = "chkTodoElMes";
            this.chkTodoElMes.Size = new System.Drawing.Size(84, 17);
            this.chkTodoElMes.TabIndex = 90;
            this.chkTodoElMes.Text = "Todo el mes";
            this.chkTodoElMes.UseVisualStyleBackColor = true;
            this.chkTodoElMes.CheckedChanged += new System.EventHandler(this.chkTodoElMes_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(338, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 91;
            this.label6.Text = "Minutos tarde;";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(338, 352);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 92;
            this.label7.Text = "Faltas:";
            // 
            // lblMinutostarde
            // 
            this.lblMinutostarde.AutoSize = true;
            this.lblMinutostarde.Location = new System.Drawing.Point(454, 311);
            this.lblMinutostarde.Name = "lblMinutostarde";
            this.lblMinutostarde.Size = new System.Drawing.Size(13, 13);
            this.lblMinutostarde.TabIndex = 93;
            this.lblMinutostarde.Text = "0";
            // 
            // lblFaltaDia
            // 
            this.lblFaltaDia.AutoSize = true;
            this.lblFaltaDia.Location = new System.Drawing.Point(457, 352);
            this.lblFaltaDia.Name = "lblFaltaDia";
            this.lblFaltaDia.Size = new System.Drawing.Size(13, 13);
            this.lblFaltaDia.TabIndex = 94;
            this.lblFaltaDia.Text = "0";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.BackColor = System.Drawing.Color.MintCream;
            this.btnImprimir.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnImprimir.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnImprimir.Location = new System.Drawing.Point(704, 300);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(92, 65);
            this.btnImprimir.TabIndex = 95;
            this.btnImprimir.Text = "&Imprimir Asistencia ";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // dlgGuardarReportePDF
            // 
            this.dlgGuardarReportePDF.Filter = "\"pdf archivo (*.pdf)|*.pdf";
            // 
            // chkSalidasTodoElMes
            // 
            this.chkSalidasTodoElMes.AutoSize = true;
            this.chkSalidasTodoElMes.Location = new System.Drawing.Point(596, 90);
            this.chkSalidasTodoElMes.Name = "chkSalidasTodoElMes";
            this.chkSalidasTodoElMes.Size = new System.Drawing.Size(84, 17);
            this.chkSalidasTodoElMes.TabIndex = 96;
            this.chkSalidasTodoElMes.Text = "Todo el mes";
            this.chkSalidasTodoElMes.UseVisualStyleBackColor = true;
            // 
            // btnImprimirMes
            // 
            this.btnImprimirMes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimirMes.BackColor = System.Drawing.Color.MintCream;
            this.btnImprimirMes.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnImprimirMes.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnImprimirMes.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnImprimirMes.Location = new System.Drawing.Point(812, 300);
            this.btnImprimirMes.Name = "btnImprimirMes";
            this.btnImprimirMes.Size = new System.Drawing.Size(92, 65);
            this.btnImprimirMes.TabIndex = 97;
            this.btnImprimirMes.Text = "&Imprimir Asistencia Mes";
            this.btnImprimirMes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImprimirMes.UseVisualStyleBackColor = false;
            this.btnImprimirMes.Click += new System.EventHandler(this.btnImprimirMes_Click);
            // 
            // frmAsistenciaMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 409);
            this.Controls.Add(this.btnImprimirMes);
            this.Controls.Add(this.chkSalidasTodoElMes);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblFaltaDia);
            this.Controls.Add(this.lblMinutostarde);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkTodoElMes);
            this.Controls.Add(this.dtgListaSalidas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotalFaltas);
            this.Controls.Add(this.lblTotaltardanzas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtgDetalleAsistencia);
            this.Controls.Add(this.cboAño);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboMes);
            this.Controls.Add(this.lblNombredelTrabajador);
            this.Controls.Add(this.CalendarioAsistencia);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAsistenciaMes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AsistenciaMes";
            this.Load += new System.EventHandler(this.AsistenciaMes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleAsistencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaSalidas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar CalendarioAsistencia;
        private System.Windows.Forms.Label lblNombredelTrabajador;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.DataGridView dtgDetalleAsistencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotaltardanzas;
        private System.Windows.Forms.Label lblTotalFaltas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtgListaSalidas;
        private System.Windows.Forms.CheckBox chkTodoElMes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMinutostarde;
        private System.Windows.Forms.Label lblFaltaDia;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.SaveFileDialog dlgGuardarReportePDF;
        private System.Windows.Forms.CheckBox chkSalidasTodoElMes;
        private System.Windows.Forms.Button btnImprimirMes;
    }
}