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
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleAsistencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaSalidas)).BeginInit();
            this.SuspendLayout();
            // 
            // CalendarioAsistencia
            // 
            this.CalendarioAsistencia.BoldedDates = new System.DateTime[] {
        new System.DateTime(2021, 5, 24, 0, 0, 0, 0)};
            this.CalendarioAsistencia.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.CalendarioAsistencia.Location = new System.Drawing.Point(33, 113);
            this.CalendarioAsistencia.MonthlyBoldedDates = new System.DateTime[] {
        new System.DateTime(2021, 5, 10, 0, 0, 0, 0),
        new System.DateTime(2021, 5, 21, 0, 0, 0, 0)};
            this.CalendarioAsistencia.Name = "CalendarioAsistencia";
            this.CalendarioAsistencia.TabIndex = 0;
            this.CalendarioAsistencia.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.CalendarioAsistencia_DateSelected);
            // 
            // lblNombredelTrabajador
            // 
            this.lblNombredelTrabajador.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblNombredelTrabajador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNombredelTrabajador.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNombredelTrabajador.Location = new System.Drawing.Point(0, 0);
            this.lblNombredelTrabajador.Name = "lblNombredelTrabajador";
            this.lblNombredelTrabajador.Size = new System.Drawing.Size(886, 23);
            this.lblNombredelTrabajador.TabIndex = 78;
            this.lblNombredelTrabajador.Text = "Lista Cargos";
            this.lblNombredelTrabajador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboMes
            // 
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(160, 71);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(121, 21);
            this.cboMes.TabIndex = 79;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "Periodo: ";
            // 
            // cboAño
            // 
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(45, 71);
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
            this.dtgDetalleAsistencia.Size = new System.Drawing.Size(222, 150);
            this.dtgDetalleAsistencia.TabIndex = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 314);
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
            this.lblTotaltardanzas.Size = new System.Drawing.Size(35, 13);
            this.lblTotaltardanzas.TabIndex = 85;
            this.lblTotaltardanzas.Text = "label4";
            // 
            // lblTotalFaltas
            // 
            this.lblTotalFaltas.AutoSize = true;
            this.lblTotalFaltas.Location = new System.Drawing.Point(186, 352);
            this.lblTotalFaltas.Name = "lblTotalFaltas";
            this.lblTotalFaltas.Size = new System.Drawing.Size(35, 13);
            this.lblTotalFaltas.TabIndex = 86;
            this.lblTotalFaltas.Text = "label4";
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
            this.label5.Location = new System.Drawing.Point(621, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 88;
            this.label5.Text = "Lista de Salidas";
            // 
            // dtgListaSalidas
            // 
            this.dtgListaSalidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaSalidas.Location = new System.Drawing.Point(624, 113);
            this.dtgListaSalidas.Name = "dtgListaSalidas";
            this.dtgListaSalidas.Size = new System.Drawing.Size(240, 150);
            this.dtgListaSalidas.TabIndex = 89;
            // 
            // frmAsistenciaMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 450);
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
    }
}