namespace CapaUsuario.Asistencia
{
    partial class frmAsistenciaTrabajadores
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
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Todos");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Activos", 2, 2);
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Inactivos", 2, 2);
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Sin Periodo Laboral", 2, 2);
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Situacion Laboral", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26});
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Todos", 1, 1);
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Regimen CAS", 2, 2);
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("DL. 276", 2, 2);
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("DL. 728", 2, 2);
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Regimen Laboral", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode28,
            treeNode29,
            treeNode30,
            treeNode31});
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("FILTRO DE TRABAJADORES", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode27,
            treeNode32});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeFiltro = new System.Windows.Forms.TreeView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAsistencia = new System.Windows.Forms.Button();
            this.btnBuscarDNI = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.dtgListaTrabajadores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTrabajadores)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeFiltro);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer1.Panel2.Controls.Add(this.btnAsistencia);
            this.splitContainer1.Panel2.Controls.Add(this.btnBuscarDNI);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txtDNI);
            this.splitContainer1.Panel2.Controls.Add(this.dtgListaTrabajadores);
            this.splitContainer1.Size = new System.Drawing.Size(930, 507);
            this.splitContainer1.SplitterDistance = 182;
            this.splitContainer1.TabIndex = 3;
            // 
            // treeFiltro
            // 
            this.treeFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFiltro.Location = new System.Drawing.Point(0, 0);
            this.treeFiltro.Name = "treeFiltro";
            treeNode23.BackColor = System.Drawing.Color.Teal;
            treeNode23.Name = "Node3";
            treeNode23.SelectedImageIndex = 0;
            treeNode23.Text = "Todos";
            treeNode24.ImageIndex = 2;
            treeNode24.Name = "Node4";
            treeNode24.SelectedImageIndex = 2;
            treeNode24.Text = "Activos";
            treeNode25.ImageIndex = 2;
            treeNode25.Name = "Node5";
            treeNode25.SelectedImageIndex = 2;
            treeNode25.Text = "Inactivos";
            treeNode26.ImageIndex = 2;
            treeNode26.Name = "Node6";
            treeNode26.SelectedImageIndex = 2;
            treeNode26.Text = "Sin Periodo Laboral";
            treeNode27.Checked = true;
            treeNode27.ImageIndex = 2;
            treeNode27.Name = "Node1";
            treeNode27.SelectedImageIndex = 2;
            treeNode27.Text = "Situacion Laboral";
            treeNode28.BackColor = System.Drawing.Color.Teal;
            treeNode28.ImageIndex = 1;
            treeNode28.Name = "Node0";
            treeNode28.SelectedImageIndex = 1;
            treeNode28.Text = "Todos";
            treeNode29.ImageIndex = 2;
            treeNode29.Name = "Node9";
            treeNode29.SelectedImageIndex = 2;
            treeNode29.Text = "Regimen CAS";
            treeNode30.ImageIndex = 2;
            treeNode30.Name = "Node10";
            treeNode30.SelectedImageIndex = 2;
            treeNode30.Text = "DL. 276";
            treeNode31.ImageIndex = 2;
            treeNode31.Name = "Node11";
            treeNode31.SelectedImageIndex = 2;
            treeNode31.Text = "DL. 728";
            treeNode32.Checked = true;
            treeNode32.ImageIndex = 2;
            treeNode32.Name = "Node8";
            treeNode32.SelectedImageIndex = 2;
            treeNode32.Text = "Regimen Laboral";
            treeNode33.Checked = true;
            treeNode33.ImageIndex = 2;
            treeNode33.Name = "Node0";
            treeNode33.SelectedImageIndex = 2;
            treeNode33.Text = "FILTRO DE TRABAJADORES";
            treeNode33.ToolTipText = "Seleccione abajo para filtrar la lista de trabajadores.";
            this.treeFiltro.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode33});
            this.treeFiltro.Size = new System.Drawing.Size(182, 507);
            this.treeFiltro.TabIndex = 0;
            this.treeFiltro.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFiltro_AfterSelect);
            this.treeFiltro.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeFiltro_NodeMouseClick);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.MintCream;
            this.btnCancelar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelar.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnCancelar.Location = new System.Drawing.Point(658, 430);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(74, 65);
            this.btnCancelar.TabIndex = 74;
            this.btnCancelar.Text = "&Salir";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAsistencia
            // 
            this.btnAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsistencia.BackColor = System.Drawing.Color.MintCream;
            this.btnAsistencia.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnAsistencia.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAsistencia.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnAsistencia.Location = new System.Drawing.Point(564, 430);
            this.btnAsistencia.Name = "btnAsistencia";
            this.btnAsistencia.Size = new System.Drawing.Size(88, 65);
            this.btnAsistencia.TabIndex = 73;
            this.btnAsistencia.Text = "&Asistencia";
            this.btnAsistencia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAsistencia.UseVisualStyleBackColor = false;
            this.btnAsistencia.Click += new System.EventHandler(this.btnAsistencia_Click);
            // 
            // btnBuscarDNI
            // 
            this.btnBuscarDNI.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBuscarDNI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarDNI.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnBuscarDNI.Location = new System.Drawing.Point(144, 10);
            this.btnBuscarDNI.Name = "btnBuscarDNI";
            this.btnBuscarDNI.Size = new System.Drawing.Size(104, 23);
            this.btnBuscarDNI.TabIndex = 19;
            this.btnBuscarDNI.Text = "Buscar por DNI";
            this.btnBuscarDNI.UseVisualStyleBackColor = false;
            this.btnBuscarDNI.Click += new System.EventHandler(this.btnBuscarDNI_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "DNI:";
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(38, 12);
            this.txtDNI.MaxLength = 8;
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(100, 20);
            this.txtDNI.TabIndex = 17;
            this.txtDNI.TextChanged += new System.EventHandler(this.txtDNI_TextChanged);
            this.txtDNI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDNI_KeyDown);
            // 
            // dtgListaTrabajadores
            // 
            this.dtgListaTrabajadores.AllowUserToAddRows = false;
            this.dtgListaTrabajadores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtgListaTrabajadores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgListaTrabajadores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgListaTrabajadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaTrabajadores.Location = new System.Drawing.Point(3, 38);
            this.dtgListaTrabajadores.MultiSelect = false;
            this.dtgListaTrabajadores.Name = "dtgListaTrabajadores";
            this.dtgListaTrabajadores.ReadOnly = true;
            this.dtgListaTrabajadores.RowHeadersVisible = false;
            this.dtgListaTrabajadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaTrabajadores.Size = new System.Drawing.Size(738, 386);
            this.dtgListaTrabajadores.TabIndex = 13;
            this.dtgListaTrabajadores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaTrabajadores_CellClick);
            this.dtgListaTrabajadores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaTrabajadores_CellContentClick);
            // 
            // frmAsistenciaTrabajadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 507);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAsistenciaTrabajadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asistencia de Trabajadores";
            this.Load += new System.EventHandler(this.frmListaTrabajadores_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTrabajadores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnBuscarDNI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.DataGridView dtgListaTrabajadores;
        private System.Windows.Forms.TreeView treeFiltro;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAsistencia;
    }
}