namespace CapaUsuario.Usuarios
{
    partial class frmEscogerMeta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboAños = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgListaMetas = new System.Windows.Forms.DataGridView();
            this.idtMeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNuevoResidente = new System.Windows.Forms.Button();
            this.btnNuevaMeta = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaMetas)).BeginInit();
            this.SuspendLayout();
            // 
            // cboAños
            // 
            this.cboAños.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAños.FormattingEnabled = true;
            this.cboAños.Location = new System.Drawing.Point(59, 12);
            this.cboAños.Name = "cboAños";
            this.cboAños.Size = new System.Drawing.Size(72, 21);
            this.cboAños.TabIndex = 28;
            this.cboAños.SelectedIndexChanged += new System.EventHandler(this.cboAños_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.MintCream;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(18, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Año :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgListaMetas);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(18, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 182);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Metas";
            // 
            // dtgListaMetas
            // 
            this.dtgListaMetas.AllowUserToAddRows = false;
            this.dtgListaMetas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            this.dtgListaMetas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgListaMetas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgListaMetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaMetas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtMeta,
            this.nombre});
            this.dtgListaMetas.Location = new System.Drawing.Point(6, 19);
            this.dtgListaMetas.MultiSelect = false;
            this.dtgListaMetas.Name = "dtgListaMetas";
            this.dtgListaMetas.RowHeadersVisible = false;
            this.dtgListaMetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaMetas.Size = new System.Drawing.Size(667, 148);
            this.dtgListaMetas.TabIndex = 1;
            // 
            // idtMeta
            // 
            this.idtMeta.DataPropertyName = "idtMeta";
            this.idtMeta.HeaderText = "idtMeta";
            this.idtMeta.Name = "idtMeta";
            this.idtMeta.Visible = false;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombreMeta";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.Width = 650;
            // 
            // btnNuevoResidente
            // 
            this.btnNuevoResidente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoResidente.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevoResidente.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevoResidente.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevoResidente.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnNuevoResidente.Location = new System.Drawing.Point(475, 240);
            this.btnNuevoResidente.Name = "btnNuevoResidente";
            this.btnNuevoResidente.Size = new System.Drawing.Size(93, 65);
            this.btnNuevoResidente.TabIndex = 61;
            this.btnNuevoResidente.Text = "&Nuevo Residente";
            this.btnNuevoResidente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevoResidente.UseVisualStyleBackColor = false;
            this.btnNuevoResidente.Click += new System.EventHandler(this.btnNuevoResidente_Click);
            // 
            // btnNuevaMeta
            // 
            this.btnNuevaMeta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevaMeta.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevaMeta.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevaMeta.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevaMeta.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnNuevaMeta.Location = new System.Drawing.Point(18, 240);
            this.btnNuevaMeta.Name = "btnNuevaMeta";
            this.btnNuevaMeta.Size = new System.Drawing.Size(93, 65);
            this.btnNuevaMeta.TabIndex = 62;
            this.btnNuevaMeta.Text = "&Nueva Meta";
            this.btnNuevaMeta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevaMeta.UseVisualStyleBackColor = false;
            this.btnNuevaMeta.Click += new System.EventHandler(this.btnNuevaMeta_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.MintCream;
            this.btnSalir.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSalir.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnSalir.Location = new System.Drawing.Point(613, 240);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(93, 65);
            this.btnSalir.TabIndex = 63;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmEscogerMeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 308);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnNuevaMeta);
            this.Controls.Add(this.btnNuevoResidente);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboAños);
            this.Controls.Add(this.label2);
            this.Name = "frmEscogerMeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Escoger Meta";
            this.Load += new System.EventHandler(this.frmEscogerMeta_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaMetas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cboAños;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgListaMetas;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtMeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.Button btnNuevoResidente;
        private System.Windows.Forms.Button btnNuevaMeta;
        private System.Windows.Forms.Button btnSalir;
    }
}