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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAsistenciaTrabajador = new System.Windows.Forms.DataGridView();
            this.txtTrabajador = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSincronizarReloj = new System.Windows.Forms.Button();
            this.miMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tTardanzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistenciaTrabajador)).BeginInit();
            this.miMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAsistenciaTrabajador
            // 
            this.dgvAsistenciaTrabajador.AllowUserToAddRows = false;
            this.dgvAsistenciaTrabajador.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dgvAsistenciaTrabajador.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAsistenciaTrabajador.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAsistenciaTrabajador.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAsistenciaTrabajador.ColumnHeadersHeight = 35;
            this.dgvAsistenciaTrabajador.Location = new System.Drawing.Point(12, 57);
            this.dgvAsistenciaTrabajador.Name = "dgvAsistenciaTrabajador";
            this.dgvAsistenciaTrabajador.ReadOnly = true;
            this.dgvAsistenciaTrabajador.RowHeadersVisible = false;
            this.dgvAsistenciaTrabajador.RowHeadersWidth = 25;
            this.dgvAsistenciaTrabajador.Size = new System.Drawing.Size(993, 158);
            this.dgvAsistenciaTrabajador.TabIndex = 9;
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
            this.btnSincronizarReloj.Location = new System.Drawing.Point(15, 255);
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
            this.toolStripMenuItem1.Text = "L = Laborados";
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
            // 
            // frmJornadaLaboral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 300);
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
    }
}