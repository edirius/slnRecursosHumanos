namespace CapaUsuario.Asistencia
{
    partial class frmDetalleAsistencia
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtTrabajador = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.miMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tTardanzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistenciaTrabajador)).BeginInit();
            this.miMenu.SuspendLayout();
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
            this.dgvAsistenciaTrabajador.Location = new System.Drawing.Point(12, 51);
            this.dgvAsistenciaTrabajador.Name = "dgvAsistenciaTrabajador";
            this.dgvAsistenciaTrabajador.ReadOnly = true;
            this.dgvAsistenciaTrabajador.RowHeadersVisible = false;
            this.dgvAsistenciaTrabajador.RowHeadersWidth = 25;
            this.dgvAsistenciaTrabajador.Size = new System.Drawing.Size(793, 114);
            this.dgvAsistenciaTrabajador.TabIndex = 8;
            this.dgvAsistenciaTrabajador.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAsistenciaTrabajador_CellContentClick);
            this.dgvAsistenciaTrabajador.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAsistenciaTrabajador_CellMouseClick);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.MintCream;
            this.btnCancelar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelar.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnCancelar.Location = new System.Drawing.Point(731, 171);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(74, 65);
            this.btnCancelar.TabIndex = 72;
            this.btnCancelar.Text = "&Salir";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.BackColor = System.Drawing.Color.MintCream;
            this.btnAceptar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAceptar.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnAceptar.Location = new System.Drawing.Point(650, 171);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 65);
            this.btnAceptar.TabIndex = 71;
            this.btnAceptar.Text = "&Guardar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtTrabajador
            // 
            this.txtTrabajador.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTrabajador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTrabajador.Enabled = false;
            this.txtTrabajador.Location = new System.Drawing.Point(251, 25);
            this.txtTrabajador.Name = "txtTrabajador";
            this.txtTrabajador.Size = new System.Drawing.Size(554, 20);
            this.txtTrabajador.TabIndex = 68;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(248, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 62;
            this.label8.Text = "Trabajador";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 74;
            this.label1.Text = "Mes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = "Año";
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(12, 24);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(91, 21);
            this.cboAño.TabIndex = 76;
            this.cboAño.SelectedIndexChanged += new System.EventHandler(this.cboAño_SelectedIndexChanged);
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Items.AddRange(new object[] {
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
            this.cboMes.Location = new System.Drawing.Point(109, 24);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(136, 21);
            this.cboMes.TabIndex = 77;
            this.cboMes.SelectedIndexChanged += new System.EventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(235, 22);
            this.toolStripMenuItem1.Text = "L = Laborados";
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
            this.miMenu.Opening += new System.ComponentModel.CancelEventHandler(this.miMenu_Opening);
            this.miMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.miMenu_ItemClicked);
            // 
            // tTardanzaToolStripMenuItem
            // 
            this.tTardanzaToolStripMenuItem.Name = "tTardanzaToolStripMenuItem";
            this.tTardanzaToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.tTardanzaToolStripMenuItem.Text = "T = Tardanza";
            // 
            // frmDetalleAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 248);
            this.Controls.Add(this.cboMes);
            this.Controls.Add(this.cboAño);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtTrabajador);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvAsistenciaTrabajador);
            this.Name = "frmDetalleAsistencia";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle Asistencia";
            this.Load += new System.EventHandler(this.frmMantenimientoDetalleTareo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistenciaTrabajador)).EndInit();
            this.miMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvAsistenciaTrabajador;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtTrabajador;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ContextMenuStrip miMenu;
        private System.Windows.Forms.ToolStripMenuItem tTardanzaToolStripMenuItem;
    }
}