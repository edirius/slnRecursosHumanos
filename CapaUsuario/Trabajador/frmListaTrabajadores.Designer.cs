namespace CapaUsuario.Trabajador
{
    partial class frmListaTrabajadores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaTrabajadores));
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Todos");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Activos");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Inactivos");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Sin Periodo Laboral");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Situacion Laboral", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Todos");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Regimen CAS");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("DL. 276");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("DL. 728");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Regimen Laboral", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20});
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("FILTRO DE TRABAJADORES", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode21});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNuevoTrabajador = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnModificarTrabajador = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEliminarTrabajador = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImprimirLista = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeFiltro = new System.Windows.Forms.TreeView();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBuscarXMeta = new System.Windows.Forms.Button();
            this.cboMeta = new System.Windows.Forms.ComboBox();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboFiltroTrabajadores = new System.Windows.Forms.ComboBox();
            this.btnDatosLaborales = new System.Windows.Forms.Button();
            this.btnDetalleTareo = new System.Windows.Forms.Button();
            this.btnBuscarAMaterno = new System.Windows.Forms.Button();
            this.btnBuscarAPaterno = new System.Windows.Forms.Button();
            this.btnBuscarNombre = new System.Windows.Forms.Button();
            this.txtBuscarApellidoMaterno = new System.Windows.Forms.TextBox();
            this.txtBuscarApellidoPaterno = new System.Windows.Forms.TextBox();
            this.txtBuscarNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscarDNI = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.dtgListaTrabajadores = new System.Windows.Forms.DataGridView();
            this.idTrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoPaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTrabajadores)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 578);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1043, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoTrabajador,
            this.toolStripSeparator1,
            this.btnModificarTrabajador,
            this.toolStripSeparator2,
            this.btnEliminarTrabajador,
            this.toolStripSeparator3,
            this.btnImprimirLista,
            this.toolStripSeparator4,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1043, 28);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNuevoTrabajador
            // 
            this.btnNuevoTrabajador.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoTrabajador.Image = global::CapaUsuario.Properties.Resources.add1;
            this.btnNuevoTrabajador.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevoTrabajador.Name = "btnNuevoTrabajador";
            this.btnNuevoTrabajador.Size = new System.Drawing.Size(154, 25);
            this.btnNuevoTrabajador.Text = "Nuevo Trabajador";
            this.btnNuevoTrabajador.Click += new System.EventHandler(this.btnNuevoTrabajador_Click_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // btnModificarTrabajador
            // 
            this.btnModificarTrabajador.Image = global::CapaUsuario.Properties.Resources.add_to_folder;
            this.btnModificarTrabajador.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModificarTrabajador.Name = "btnModificarTrabajador";
            this.btnModificarTrabajador.Size = new System.Drawing.Size(137, 25);
            this.btnModificarTrabajador.Text = "Modificar Trabajador";
            this.btnModificarTrabajador.Click += new System.EventHandler(this.btnModificarTrabajador_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // btnEliminarTrabajador
            // 
            this.btnEliminarTrabajador.Image = global::CapaUsuario.Properties.Resources.delete_page;
            this.btnEliminarTrabajador.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarTrabajador.Name = "btnEliminarTrabajador";
            this.btnEliminarTrabajador.Size = new System.Drawing.Size(129, 25);
            this.btnEliminarTrabajador.Text = "Eliminar Trabajador";
            this.btnEliminarTrabajador.Click += new System.EventHandler(this.btnEliminarTrabajador_Click_1);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // btnImprimirLista
            // 
            this.btnImprimirLista.Image = global::CapaUsuario.Properties.Resources.chart;
            this.btnImprimirLista.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimirLista.Name = "btnImprimirLista";
            this.btnImprimirLista.Size = new System.Drawing.Size(100, 25);
            this.btnImprimirLista.Text = "Imprimir Lista";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(49, 25);
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeFiltro);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.btnBuscarXMeta);
            this.splitContainer1.Panel2.Controls.Add(this.cboMeta);
            this.splitContainer1.Panel2.Controls.Add(this.cboAño);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.cboFiltroTrabajadores);
            this.splitContainer1.Panel2.Controls.Add(this.btnDatosLaborales);
            this.splitContainer1.Panel2.Controls.Add(this.btnDetalleTareo);
            this.splitContainer1.Panel2.Controls.Add(this.btnBuscarAMaterno);
            this.splitContainer1.Panel2.Controls.Add(this.btnBuscarAPaterno);
            this.splitContainer1.Panel2.Controls.Add(this.btnBuscarNombre);
            this.splitContainer1.Panel2.Controls.Add(this.txtBuscarApellidoMaterno);
            this.splitContainer1.Panel2.Controls.Add(this.txtBuscarApellidoPaterno);
            this.splitContainer1.Panel2.Controls.Add(this.txtBuscarNombre);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.btnBuscarDNI);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txtDNI);
            this.splitContainer1.Panel2.Controls.Add(this.dtgListaTrabajadores);
            this.splitContainer1.Size = new System.Drawing.Size(1043, 550);
            this.splitContainer1.SplitterDistance = 205;
            this.splitContainer1.TabIndex = 3;
            // 
            // treeFiltro
            // 
            this.treeFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFiltro.Location = new System.Drawing.Point(0, 0);
            this.treeFiltro.Name = "treeFiltro";
            treeNode12.Name = "Node3";
            treeNode12.Text = "Todos";
            treeNode13.Name = "Node4";
            treeNode13.Text = "Activos";
            treeNode14.Name = "Node5";
            treeNode14.Text = "Inactivos";
            treeNode15.Name = "Node6";
            treeNode15.Text = "Sin Periodo Laboral";
            treeNode16.Checked = true;
            treeNode16.Name = "Node1";
            treeNode16.Text = "Situacion Laboral";
            treeNode17.Name = "Node0";
            treeNode17.Text = "Todos";
            treeNode18.Name = "Node9";
            treeNode18.Text = "Regimen CAS";
            treeNode19.Name = "Node10";
            treeNode19.Text = "DL. 276";
            treeNode20.Name = "Node11";
            treeNode20.Text = "DL. 728";
            treeNode21.Checked = true;
            treeNode21.Name = "Node8";
            treeNode21.Text = "Regimen Laboral";
            treeNode22.Checked = true;
            treeNode22.Name = "Node0";
            treeNode22.Text = "FILTRO DE TRABAJADORES";
            this.treeFiltro.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode22});
            this.treeFiltro.Size = new System.Drawing.Size(205, 550);
            this.treeFiltro.TabIndex = 0;
            this.treeFiltro.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeFiltro_NodeMouseClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Año de la Meta:";
            // 
            // btnBuscarXMeta
            // 
            this.btnBuscarXMeta.Location = new System.Drawing.Point(557, 167);
            this.btnBuscarXMeta.Name = "btnBuscarXMeta";
            this.btnBuscarXMeta.Size = new System.Drawing.Size(164, 23);
            this.btnBuscarXMeta.TabIndex = 38;
            this.btnBuscarXMeta.Text = "Buscar por Meta";
            this.btnBuscarXMeta.UseVisualStyleBackColor = true;
            this.btnBuscarXMeta.Click += new System.EventHandler(this.btnBuscarXMeta_Click);
            // 
            // cboMeta
            // 
            this.cboMeta.FormattingEnabled = true;
            this.cboMeta.Location = new System.Drawing.Point(113, 169);
            this.cboMeta.Name = "cboMeta";
            this.cboMeta.Size = new System.Drawing.Size(422, 21);
            this.cboMeta.TabIndex = 37;
            // 
            // cboAño
            // 
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(113, 136);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(65, 21);
            this.cboAño.TabIndex = 36;
            this.cboAño.SelectedIndexChanged += new System.EventHandler(this.cboAño_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Meta :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(456, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Situacion Laboral :";
            // 
            // cboFiltroTrabajadores
            // 
            this.cboFiltroTrabajadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltroTrabajadores.FormattingEnabled = true;
            this.cboFiltroTrabajadores.Items.AddRange(new object[] {
            "Todos",
            "Activos",
            "Inactivos",
            "Sin Periodo Laboral"});
            this.cboFiltroTrabajadores.Location = new System.Drawing.Point(557, 12);
            this.cboFiltroTrabajadores.Name = "cboFiltroTrabajadores";
            this.cboFiltroTrabajadores.Size = new System.Drawing.Size(148, 21);
            this.cboFiltroTrabajadores.TabIndex = 33;
            this.cboFiltroTrabajadores.SelectedIndexChanged += new System.EventHandler(this.cboFiltroTrabajadores_SelectedIndexChanged);
            // 
            // btnDatosLaborales
            // 
            this.btnDatosLaborales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDatosLaborales.BackColor = System.Drawing.Color.MintCream;
            this.btnDatosLaborales.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnDatosLaborales.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDatosLaborales.ImageIndex = 1;
            this.btnDatosLaborales.Location = new System.Drawing.Point(591, 489);
            this.btnDatosLaborales.Name = "btnDatosLaborales";
            this.btnDatosLaborales.Size = new System.Drawing.Size(114, 53);
            this.btnDatosLaborales.TabIndex = 32;
            this.btnDatosLaborales.Text = "&Datos Laborales";
            this.btnDatosLaborales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDatosLaborales.UseVisualStyleBackColor = false;
            this.btnDatosLaborales.Click += new System.EventHandler(this.btnDatosLaborales_Click);
            // 
            // btnDetalleTareo
            // 
            this.btnDetalleTareo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDetalleTareo.BackColor = System.Drawing.Color.MintCream;
            this.btnDetalleTareo.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnDetalleTareo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDetalleTareo.ImageIndex = 1;
            this.btnDetalleTareo.Location = new System.Drawing.Point(591, 568);
            this.btnDetalleTareo.Name = "btnDetalleTareo";
            this.btnDetalleTareo.Size = new System.Drawing.Size(114, 53);
            this.btnDetalleTareo.TabIndex = 30;
            this.btnDetalleTareo.Text = "&Detalle Tareo";
            this.btnDetalleTareo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDetalleTareo.UseVisualStyleBackColor = false;
            // 
            // btnBuscarAMaterno
            // 
            this.btnBuscarAMaterno.Location = new System.Drawing.Point(348, 101);
            this.btnBuscarAMaterno.Name = "btnBuscarAMaterno";
            this.btnBuscarAMaterno.Size = new System.Drawing.Size(164, 23);
            this.btnBuscarAMaterno.TabIndex = 28;
            this.btnBuscarAMaterno.Text = "Buscar por Apellido Materno";
            this.btnBuscarAMaterno.UseVisualStyleBackColor = true;
            this.btnBuscarAMaterno.Click += new System.EventHandler(this.btnBuscarAMaterno_Click);
            // 
            // btnBuscarAPaterno
            // 
            this.btnBuscarAPaterno.Location = new System.Drawing.Point(348, 70);
            this.btnBuscarAPaterno.Name = "btnBuscarAPaterno";
            this.btnBuscarAPaterno.Size = new System.Drawing.Size(164, 23);
            this.btnBuscarAPaterno.TabIndex = 27;
            this.btnBuscarAPaterno.Text = "Buscar por Apellido Paterno";
            this.btnBuscarAPaterno.UseVisualStyleBackColor = true;
            this.btnBuscarAPaterno.Click += new System.EventHandler(this.btnBuscarAPaterno_Click);
            // 
            // btnBuscarNombre
            // 
            this.btnBuscarNombre.Location = new System.Drawing.Point(348, 43);
            this.btnBuscarNombre.Name = "btnBuscarNombre";
            this.btnBuscarNombre.Size = new System.Drawing.Size(164, 23);
            this.btnBuscarNombre.TabIndex = 26;
            this.btnBuscarNombre.Text = "Buscar por Nombres";
            this.btnBuscarNombre.UseVisualStyleBackColor = true;
            this.btnBuscarNombre.Click += new System.EventHandler(this.btnBuscarNombre_Click);
            // 
            // txtBuscarApellidoMaterno
            // 
            this.txtBuscarApellidoMaterno.Location = new System.Drawing.Point(113, 105);
            this.txtBuscarApellidoMaterno.Name = "txtBuscarApellidoMaterno";
            this.txtBuscarApellidoMaterno.Size = new System.Drawing.Size(216, 20);
            this.txtBuscarApellidoMaterno.TabIndex = 25;
            // 
            // txtBuscarApellidoPaterno
            // 
            this.txtBuscarApellidoPaterno.Location = new System.Drawing.Point(113, 74);
            this.txtBuscarApellidoPaterno.Name = "txtBuscarApellidoPaterno";
            this.txtBuscarApellidoPaterno.Size = new System.Drawing.Size(216, 20);
            this.txtBuscarApellidoPaterno.TabIndex = 24;
            // 
            // txtBuscarNombre
            // 
            this.txtBuscarNombre.Location = new System.Drawing.Point(113, 43);
            this.txtBuscarNombre.Name = "txtBuscarNombre";
            this.txtBuscarNombre.Size = new System.Drawing.Size(216, 20);
            this.txtBuscarNombre.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Apellido  Materno :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Apellido Paterno :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Nombres";
            // 
            // btnBuscarDNI
            // 
            this.btnBuscarDNI.Location = new System.Drawing.Point(236, 8);
            this.btnBuscarDNI.Name = "btnBuscarDNI";
            this.btnBuscarDNI.Size = new System.Drawing.Size(104, 23);
            this.btnBuscarDNI.TabIndex = 19;
            this.btnBuscarDNI.Text = "Buscar por DNI";
            this.btnBuscarDNI.UseVisualStyleBackColor = true;
            this.btnBuscarDNI.Click += new System.EventHandler(this.btnBuscarDNI_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "DNI:";
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(113, 12);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(100, 20);
            this.txtDNI.TabIndex = 17;
            // 
            // dtgListaTrabajadores
            // 
            this.dtgListaTrabajadores.AllowUserToAddRows = false;
            this.dtgListaTrabajadores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtgListaTrabajadores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgListaTrabajadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaTrabajadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTrabajador,
            this.dni,
            this.nombres,
            this.apellidoPaterno,
            this.apellidoMaterno,
            this.sexo});
            this.dtgListaTrabajadores.Location = new System.Drawing.Point(15, 212);
            this.dtgListaTrabajadores.MultiSelect = false;
            this.dtgListaTrabajadores.Name = "dtgListaTrabajadores";
            this.dtgListaTrabajadores.ReadOnly = true;
            this.dtgListaTrabajadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaTrabajadores.Size = new System.Drawing.Size(690, 271);
            this.dtgListaTrabajadores.TabIndex = 13;
            this.dtgListaTrabajadores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaTrabajadores_CellClick);
            this.dtgListaTrabajadores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaTrabajadores_CellContentClick);
            // 
            // idTrabajador
            // 
            this.idTrabajador.DataPropertyName = "id_trabajador";
            this.idTrabajador.HeaderText = "Codigo";
            this.idTrabajador.Name = "idTrabajador";
            this.idTrabajador.ReadOnly = true;
            this.idTrabajador.Width = 50;
            // 
            // dni
            // 
            this.dni.DataPropertyName = "dni";
            this.dni.HeaderText = "DNI";
            this.dni.Name = "dni";
            this.dni.ReadOnly = true;
            this.dni.Width = 70;
            // 
            // nombres
            // 
            this.nombres.DataPropertyName = "nombres";
            this.nombres.HeaderText = "Nombres";
            this.nombres.Name = "nombres";
            this.nombres.ReadOnly = true;
            this.nombres.Width = 150;
            // 
            // apellidoPaterno
            // 
            this.apellidoPaterno.DataPropertyName = "apellidoPaterno";
            this.apellidoPaterno.HeaderText = "Apellido Paterno";
            this.apellidoPaterno.Name = "apellidoPaterno";
            this.apellidoPaterno.ReadOnly = true;
            this.apellidoPaterno.Width = 150;
            // 
            // apellidoMaterno
            // 
            this.apellidoMaterno.DataPropertyName = "apellidoMaterno";
            this.apellidoMaterno.HeaderText = "Apellido Materno";
            this.apellidoMaterno.Name = "apellidoMaterno";
            this.apellidoMaterno.ReadOnly = true;
            this.apellidoMaterno.Width = 150;
            // 
            // sexo
            // 
            this.sexo.DataPropertyName = "sexo";
            this.sexo.HeaderText = "Sexo";
            this.sexo.Name = "sexo";
            this.sexo.ReadOnly = true;
            this.sexo.Width = 50;
            // 
            // frmListaTrabajadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 600);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListaTrabajadores";
            this.Text = "Lista de Trabajadores";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListaTrabajadores_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTrabajadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeFiltro;
        private System.Windows.Forms.TextBox txtBuscarApellidoMaterno;
        private System.Windows.Forms.TextBox txtBuscarApellidoPaterno;
        private System.Windows.Forms.TextBox txtBuscarNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscarDNI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.DataGridView dtgListaTrabajadores;
        private System.Windows.Forms.ToolStripButton btnNuevoTrabajador;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnModificarTrabajador;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnEliminarTrabajador;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnImprimirLista;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.Button btnBuscarAMaterno;
        private System.Windows.Forms.Button btnBuscarAPaterno;
        private System.Windows.Forms.Button btnBuscarNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoPaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoMaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexo;
        private System.Windows.Forms.Button btnDetalleTareo;
        private System.Windows.Forms.Button btnDatosLaborales;
        private System.Windows.Forms.ComboBox cboFiltroTrabajadores;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.ComboBox cboMeta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBuscarXMeta;
    }
}