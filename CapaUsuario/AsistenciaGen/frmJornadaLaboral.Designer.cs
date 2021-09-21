namespace CapaUsuario.AsistenciaGen
{
    partial class frmJornadaLaboral
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAsistenciaTrabajador = new System.Windows.Forms.DataGridView();
            this.txtTrabajador = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSincronizarReloj = new System.Windows.Forms.Button();
            this.miMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tTardanzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupInformacion = new System.Windows.Forms.GroupBox();
            this.lblPicadoSalida = new System.Windows.Forms.Label();
            this.lblPicadoEntrada = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTipoDia = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNombreTurno = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTipoSuspension = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistenciaTrabajador)).BeginInit();
            this.miMenu.SuspendLayout();
            this.groupInformacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAsistenciaTrabajador
            // 
            this.dgvAsistenciaTrabajador.AllowUserToAddRows = false;
            this.dgvAsistenciaTrabajador.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightBlue;
            this.dgvAsistenciaTrabajador.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAsistenciaTrabajador.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAsistenciaTrabajador.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAsistenciaTrabajador.ColumnHeadersHeight = 35;
            this.dgvAsistenciaTrabajador.Location = new System.Drawing.Point(12, 57);
            this.dgvAsistenciaTrabajador.Name = "dgvAsistenciaTrabajador";
            this.dgvAsistenciaTrabajador.ReadOnly = true;
            this.dgvAsistenciaTrabajador.RowHeadersVisible = false;
            this.dgvAsistenciaTrabajador.RowHeadersWidth = 25;
            this.dgvAsistenciaTrabajador.Size = new System.Drawing.Size(993, 128);
            this.dgvAsistenciaTrabajador.TabIndex = 9;
            this.dgvAsistenciaTrabajador.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAsistenciaTrabajador_CellContentClick);
            this.dgvAsistenciaTrabajador.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAsistenciaTrabajador_CellMouseClick);
            // 
            // txtTrabajador
            // 
            this.txtTrabajador.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTrabajador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTrabajador.Enabled = false;
            this.txtTrabajador.Location = new System.Drawing.Point(15, 25);
            this.txtTrabajador.Name = "txtTrabajador";
            this.txtTrabajador.Size = new System.Drawing.Size(714, 20);
            this.txtTrabajador.TabIndex = 70;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 69;
            this.label8.Text = "Trabajador";
            // 
            // btnSincronizarReloj
            // 
            this.btnSincronizarReloj.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSincronizarReloj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSincronizarReloj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSincronizarReloj.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSincronizarReloj.Location = new System.Drawing.Point(15, 275);
            this.btnSincronizarReloj.Name = "btnSincronizarReloj";
            this.btnSincronizarReloj.Size = new System.Drawing.Size(158, 38);
            this.btnSincronizarReloj.TabIndex = 71;
            this.btnSincronizarReloj.Text = "Sincronizar con el reloj";
            this.btnSincronizarReloj.UseVisualStyleBackColor = false;
            this.btnSincronizarReloj.Click += new System.EventHandler(this.btnSincronizarReloj_Click);
            // 
            // miMenu
            // 
            this.miMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.tTardanzaToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.miMenu.Name = "contextMenuStrip1";
            this.miMenu.ShowImageMargin = false;
            this.miMenu.Size = new System.Drawing.Size(236, 92);
            this.miMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.miMenu_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(235, 22);
            this.toolStripMenuItem1.Text = "N = Normal- Laborado";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // tTardanzaToolStripMenuItem
            // 
            this.tTardanzaToolStripMenuItem.Name = "tTardanzaToolStripMenuItem";
            this.tTardanzaToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.tTardanzaToolStripMenuItem.Text = "T = Tardanza";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(235, 22);
            this.toolStripMenuItem2.Text = "S = Subsidiados";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(235, 22);
            this.toolStripMenuItem3.Text = "F = No Laborados y no Subsidiados";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // groupInformacion
            // 
            this.groupInformacion.BackColor = System.Drawing.Color.White;
            this.groupInformacion.Controls.Add(this.lblTipoSuspension);
            this.groupInformacion.Controls.Add(this.lblPicadoSalida);
            this.groupInformacion.Controls.Add(this.lblPicadoEntrada);
            this.groupInformacion.Controls.Add(this.label4);
            this.groupInformacion.Controls.Add(this.label3);
            this.groupInformacion.Controls.Add(this.lblTipoDia);
            this.groupInformacion.Controls.Add(this.label2);
            this.groupInformacion.Controls.Add(this.lblNombreTurno);
            this.groupInformacion.Controls.Add(this.label1);
            this.groupInformacion.Location = new System.Drawing.Point(258, 205);
            this.groupInformacion.Name = "groupInformacion";
            this.groupInformacion.Size = new System.Drawing.Size(541, 117);
            this.groupInformacion.TabIndex = 72;
            this.groupInformacion.TabStop = false;
            this.groupInformacion.Text = "Informacion";
            // 
            // lblPicadoSalida
            // 
            this.lblPicadoSalida.AutoSize = true;
            this.lblPicadoSalida.Location = new System.Drawing.Point(358, 66);
            this.lblPicadoSalida.Name = "lblPicadoSalida";
            this.lblPicadoSalida.Size = new System.Drawing.Size(0, 13);
            this.lblPicadoSalida.TabIndex = 7;
            // 
            // lblPicadoEntrada
            // 
            this.lblPicadoEntrada.AutoSize = true;
            this.lblPicadoEntrada.Location = new System.Drawing.Point(355, 28);
            this.lblPicadoEntrada.Name = "lblPicadoEntrada";
            this.lblPicadoEntrada.Size = new System.Drawing.Size(0, 13);
            this.lblPicadoEntrada.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(247, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Picado Salida:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Picado Entrada:";
            // 
            // lblTipoDia
            // 
            this.lblTipoDia.AutoSize = true;
            this.lblTipoDia.Location = new System.Drawing.Point(94, 66);
            this.lblTipoDia.Name = "lblTipoDia";
            this.lblTipoDia.Size = new System.Drawing.Size(0, 13);
            this.lblTipoDia.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Jornada:";
            // 
            // lblNombreTurno
            // 
            this.lblNombreTurno.AutoSize = true;
            this.lblNombreTurno.Location = new System.Drawing.Point(94, 28);
            this.lblNombreTurno.Name = "lblNombreTurno";
            this.lblNombreTurno.Size = new System.Drawing.Size(0, 13);
            this.lblNombreTurno.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Turno:";
            // 
            // lblTipoSuspension
            // 
            this.lblTipoSuspension.AutoSize = true;
            this.lblTipoSuspension.Location = new System.Drawing.Point(21, 94);
            this.lblTipoSuspension.Name = "lblTipoSuspension";
            this.lblTipoSuspension.Size = new System.Drawing.Size(35, 13);
            this.lblTipoSuspension.TabIndex = 8;
            this.lblTipoSuspension.Text = "label5";
            // 
            // frmJornadaLaboral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 334);
            this.Controls.Add(this.groupInformacion);
            this.Controls.Add(this.btnSincronizarReloj);
            this.Controls.Add(this.txtTrabajador);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvAsistenciaTrabajador);
            this.Name = "frmJornadaLaboral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jornada Laboral";
            this.Load += new System.EventHandler(this.frmJornadaLaboral_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistenciaTrabajador)).EndInit();
            this.miMenu.ResumeLayout(false);
            this.groupInformacion.ResumeLayout(false);
            this.groupInformacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAsistenciaTrabajador;
        private System.Windows.Forms.TextBox txtTrabajador;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSincronizarReloj;
        private System.Windows.Forms.ContextMenuStrip miMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tTardanzaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.GroupBox groupInformacion;
        private System.Windows.Forms.Label lblTipoDia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNombreTurno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPicadoSalida;
        private System.Windows.Forms.Label lblPicadoEntrada;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTipoSuspension;
    }
}