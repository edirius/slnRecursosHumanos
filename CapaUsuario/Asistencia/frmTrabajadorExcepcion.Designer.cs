namespace CapaUsuario.Asistencia
{
    partial class frmTrabajadorExcepcion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrabajadorExcepcion));
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Todos");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Activos", 2, 2);
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Inactivos", 2, 2);
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Sin Periodo Laboral", 2, 2);
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Situacion Laboral", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Todos", 1, 1);
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Regimen CAS", 2, 2);
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("DL. 276", 2, 2);
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("DL. 728", 2, 2);
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("DL. 30057");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Racionamiento");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Regimen Laboral", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24});
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("FILTRO DE TRABAJADORES", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode18,
            treeNode25});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAsignarHorario = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarHorario = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNuevaSalidaTrabajador = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAsistenciaMes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAsignarNumeroReloj = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSalidas = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeFiltro = new System.Windows.Forms.TreeView();
            this.chkMarcarTodos = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBuscarXMeta = new System.Windows.Forms.Button();
            this.cboMeta = new System.Windows.Forms.ComboBox();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.id_trabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoPaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suspensionrenta4ta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechafin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtreloj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreHorario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImprimir2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTrabajadores)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAsignarHorario,
            this.btnEliminarHorario,
            this.toolStripSeparator1,
            this.btnNuevaSalidaTrabajador,
            this.toolStripSeparator2,
            this.btnAsistenciaMes,
            this.toolStripSeparator4,
            this.btnAsignarNumeroReloj,
            this.toolStripSeparator3,
            this.btnSalidas,
            this.btnImprimir,
            this.btnImprimir2,
            this.toolStripSeparator5,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1176, 28);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAsignarHorario
            // 
            this.btnAsignarHorario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarHorario.Image = global::CapaUsuario.Properties.Resources.sched_tasks;
            this.btnAsignarHorario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAsignarHorario.Name = "btnAsignarHorario";
            this.btnAsignarHorario.Size = new System.Drawing.Size(140, 25);
            this.btnAsignarHorario.Text = "Asignar Horario";
            this.btnAsignarHorario.Click += new System.EventHandler(this.btnAsignarHorario_Click);
            // 
            // btnEliminarHorario
            // 
            this.btnEliminarHorario.Image = global::CapaUsuario.Properties.Resources.user_cardx;
            this.btnEliminarHorario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarHorario.Name = "btnEliminarHorario";
            this.btnEliminarHorario.Size = new System.Drawing.Size(113, 25);
            this.btnEliminarHorario.Text = "Eliminar Horario";
            this.btnEliminarHorario.Click += new System.EventHandler(this.btnEliminarHorario_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // btnNuevaSalidaTrabajador
            // 
            this.btnNuevaSalidaTrabajador.Image = global::CapaUsuario.Properties.Resources.add_to_folder;
            this.btnNuevaSalidaTrabajador.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevaSalidaTrabajador.Name = "btnNuevaSalidaTrabajador";
            this.btnNuevaSalidaTrabajador.Size = new System.Drawing.Size(162, 25);
            this.btnNuevaSalidaTrabajador.Text = "Ingresar Salida Trabajador";
            this.btnNuevaSalidaTrabajador.Click += new System.EventHandler(this.btnNuevaSalidaTrabajador_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // btnAsistenciaMes
            // 
            this.btnAsistenciaMes.Image = global::CapaUsuario.Properties.Resources.chart;
            this.btnAsistenciaMes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAsistenciaMes.Name = "btnAsistenciaMes";
            this.btnAsistenciaMes.Size = new System.Drawing.Size(124, 25);
            this.btnAsistenciaMes.Text = "Asistencia del Mes";
            this.btnAsistenciaMes.Click += new System.EventHandler(this.btnAsistenciaMes_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // btnAsignarNumeroReloj
            // 
            this.btnAsignarNumeroReloj.Image = global::CapaUsuario.Properties.Resources._112;
            this.btnAsignarNumeroReloj.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAsignarNumeroReloj.Name = "btnAsignarNumeroReloj";
            this.btnAsignarNumeroReloj.Size = new System.Drawing.Size(143, 25);
            this.btnAsignarNumeroReloj.Text = "Asignar Numero Reloj";
            this.btnAsignarNumeroReloj.Click += new System.EventHandler(this.btnAsignarNumeroReloj_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // btnSalidas
            // 
            this.btnSalidas.Image = ((System.Drawing.Image)(resources.GetObject("btnSalidas.Image")));
            this.btnSalidas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalidas.Name = "btnSalidas";
            this.btnSalidas.Size = new System.Drawing.Size(90, 25);
            this.btnSalidas.Text = "Lista Salidas";
            this.btnSalidas.Click += new System.EventHandler(this.btnSalidas_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(73, 25);
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 28);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::CapaUsuario.Properties.Resources.WinXPSetV4_Icon_17;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(49, 25);
            this.btnSalir.Text = "Salir";
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
            this.splitContainer1.Panel2.Controls.Add(this.chkMarcarTodos);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.btnBuscarXMeta);
            this.splitContainer1.Panel2.Controls.Add(this.cboMeta);
            this.splitContainer1.Panel2.Controls.Add(this.cboAño);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
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
            this.splitContainer1.Size = new System.Drawing.Size(1176, 551);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 4;
            // 
            // treeFiltro
            // 
            this.treeFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFiltro.Location = new System.Drawing.Point(0, 0);
            this.treeFiltro.Name = "treeFiltro";
            treeNode14.BackColor = System.Drawing.Color.Teal;
            treeNode14.Name = "Node3";
            treeNode14.SelectedImageIndex = 0;
            treeNode14.Text = "Todos";
            treeNode15.ImageIndex = 2;
            treeNode15.Name = "Node4";
            treeNode15.SelectedImageIndex = 2;
            treeNode15.Text = "Activos";
            treeNode16.ImageIndex = 2;
            treeNode16.Name = "Node5";
            treeNode16.SelectedImageIndex = 2;
            treeNode16.Text = "Inactivos";
            treeNode17.ImageIndex = 2;
            treeNode17.Name = "Node6";
            treeNode17.SelectedImageIndex = 2;
            treeNode17.Text = "Sin Periodo Laboral";
            treeNode18.Checked = true;
            treeNode18.ImageIndex = 2;
            treeNode18.Name = "Node1";
            treeNode18.SelectedImageIndex = 2;
            treeNode18.Text = "Situacion Laboral";
            treeNode19.BackColor = System.Drawing.Color.Teal;
            treeNode19.ImageIndex = 1;
            treeNode19.Name = "Node0";
            treeNode19.SelectedImageIndex = 1;
            treeNode19.Text = "Todos";
            treeNode20.ImageIndex = 2;
            treeNode20.Name = "Node9";
            treeNode20.SelectedImageIndex = 2;
            treeNode20.Text = "Regimen CAS";
            treeNode21.ImageIndex = 2;
            treeNode21.Name = "Node10";
            treeNode21.SelectedImageIndex = 2;
            treeNode21.Text = "DL. 276";
            treeNode22.ImageIndex = 2;
            treeNode22.Name = "Node11";
            treeNode22.SelectedImageIndex = 2;
            treeNode22.Text = "DL. 728";
            treeNode23.ImageIndex = 2;
            treeNode23.Name = "Node0";
            treeNode23.Text = "DL. 30057";
            treeNode24.ImageIndex = 2;
            treeNode24.Name = "Node1";
            treeNode24.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            treeNode24.Text = "Racionamiento";
            treeNode25.Checked = true;
            treeNode25.ImageIndex = 2;
            treeNode25.Name = "Node8";
            treeNode25.SelectedImageIndex = 2;
            treeNode25.Text = "Regimen Laboral";
            treeNode26.Checked = true;
            treeNode26.ImageIndex = 2;
            treeNode26.Name = "Node0";
            treeNode26.SelectedImageIndex = 2;
            treeNode26.Text = "FILTRO DE TRABAJADORES";
            treeNode26.ToolTipText = "Seleccione abajo para filtrar la lista de trabajadores.";
            this.treeFiltro.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode26});
            this.treeFiltro.Size = new System.Drawing.Size(228, 551);
            this.treeFiltro.TabIndex = 0;
            this.treeFiltro.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeFiltro_NodeMouseClick);
            // 
            // chkMarcarTodos
            // 
            this.chkMarcarTodos.AutoSize = true;
            this.chkMarcarTodos.Location = new System.Drawing.Point(22, 180);
            this.chkMarcarTodos.Name = "chkMarcarTodos";
            this.chkMarcarTodos.Size = new System.Drawing.Size(92, 17);
            this.chkMarcarTodos.TabIndex = 40;
            this.chkMarcarTodos.Text = "Marcar Todos";
            this.chkMarcarTodos.UseVisualStyleBackColor = true;
            this.chkMarcarTodos.CheckedChanged += new System.EventHandler(this.chkMarcarTodos_CheckedChanged);
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
            this.btnBuscarXMeta.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBuscarXMeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarXMeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarXMeta.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnBuscarXMeta.Location = new System.Drawing.Point(676, 133);
            this.btnBuscarXMeta.Name = "btnBuscarXMeta";
            this.btnBuscarXMeta.Size = new System.Drawing.Size(164, 23);
            this.btnBuscarXMeta.TabIndex = 38;
            this.btnBuscarXMeta.Text = "Buscar por Meta";
            this.btnBuscarXMeta.UseVisualStyleBackColor = false;
            // 
            // cboMeta
            // 
            this.cboMeta.FormattingEnabled = true;
            this.cboMeta.Location = new System.Drawing.Point(248, 135);
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
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(205, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Meta :";
            // 
            // btnDetalleTareo
            // 
            this.btnDetalleTareo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDetalleTareo.BackColor = System.Drawing.Color.MintCream;
            this.btnDetalleTareo.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnDetalleTareo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDetalleTareo.ImageIndex = 1;
            this.btnDetalleTareo.Location = new System.Drawing.Point(591, 569);
            this.btnDetalleTareo.Name = "btnDetalleTareo";
            this.btnDetalleTareo.Size = new System.Drawing.Size(114, 53);
            this.btnDetalleTareo.TabIndex = 30;
            this.btnDetalleTareo.Text = "&Detalle Tareo";
            this.btnDetalleTareo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDetalleTareo.UseVisualStyleBackColor = false;
            // 
            // btnBuscarAMaterno
            // 
            this.btnBuscarAMaterno.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBuscarAMaterno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarAMaterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarAMaterno.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnBuscarAMaterno.Location = new System.Drawing.Point(348, 101);
            this.btnBuscarAMaterno.Name = "btnBuscarAMaterno";
            this.btnBuscarAMaterno.Size = new System.Drawing.Size(187, 23);
            this.btnBuscarAMaterno.TabIndex = 28;
            this.btnBuscarAMaterno.Text = "Buscar por Apellido Materno";
            this.btnBuscarAMaterno.UseVisualStyleBackColor = false;
            this.btnBuscarAMaterno.Click += new System.EventHandler(this.btnBuscarAMaterno_Click);
            // 
            // btnBuscarAPaterno
            // 
            this.btnBuscarAPaterno.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBuscarAPaterno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarAPaterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarAPaterno.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnBuscarAPaterno.Location = new System.Drawing.Point(348, 70);
            this.btnBuscarAPaterno.Name = "btnBuscarAPaterno";
            this.btnBuscarAPaterno.Size = new System.Drawing.Size(187, 23);
            this.btnBuscarAPaterno.TabIndex = 27;
            this.btnBuscarAPaterno.Text = "Buscar por Apellido Paterno";
            this.btnBuscarAPaterno.UseVisualStyleBackColor = false;
            this.btnBuscarAPaterno.Click += new System.EventHandler(this.btnBuscarAPaterno_Click);
            // 
            // btnBuscarNombre
            // 
            this.btnBuscarNombre.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBuscarNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarNombre.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnBuscarNombre.Location = new System.Drawing.Point(348, 43);
            this.btnBuscarNombre.Name = "btnBuscarNombre";
            this.btnBuscarNombre.Size = new System.Drawing.Size(187, 23);
            this.btnBuscarNombre.TabIndex = 26;
            this.btnBuscarNombre.Text = "Buscar por Nombres";
            this.btnBuscarNombre.UseVisualStyleBackColor = false;
            this.btnBuscarNombre.Click += new System.EventHandler(this.btnBuscarNombre_Click);
            // 
            // txtBuscarApellidoMaterno
            // 
            this.txtBuscarApellidoMaterno.Location = new System.Drawing.Point(113, 105);
            this.txtBuscarApellidoMaterno.MaxLength = 49;
            this.txtBuscarApellidoMaterno.Name = "txtBuscarApellidoMaterno";
            this.txtBuscarApellidoMaterno.Size = new System.Drawing.Size(216, 20);
            this.txtBuscarApellidoMaterno.TabIndex = 25;
            // 
            // txtBuscarApellidoPaterno
            // 
            this.txtBuscarApellidoPaterno.Location = new System.Drawing.Point(113, 74);
            this.txtBuscarApellidoPaterno.MaxLength = 49;
            this.txtBuscarApellidoPaterno.Name = "txtBuscarApellidoPaterno";
            this.txtBuscarApellidoPaterno.Size = new System.Drawing.Size(216, 20);
            this.txtBuscarApellidoPaterno.TabIndex = 24;
            // 
            // txtBuscarNombre
            // 
            this.txtBuscarNombre.Location = new System.Drawing.Point(113, 43);
            this.txtBuscarNombre.MaxLength = 49;
            this.txtBuscarNombre.Name = "txtBuscarNombre";
            this.txtBuscarNombre.Size = new System.Drawing.Size(216, 20);
            this.txtBuscarNombre.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Apellido  Materno :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Apellido Paterno :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Nombres";
            // 
            // btnBuscarDNI
            // 
            this.btnBuscarDNI.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBuscarDNI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarDNI.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnBuscarDNI.Location = new System.Drawing.Point(236, 8);
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
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "DNI:";
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(113, 12);
            this.txtDNI.MaxLength = 8;
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(100, 20);
            this.txtDNI.TabIndex = 17;
            // 
            // dtgListaTrabajadores
            // 
            this.dtgListaTrabajadores.AllowUserToAddRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtgListaTrabajadores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgListaTrabajadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaTrabajadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_trabajador,
            this.dni,
            this.nombres,
            this.apellidoPaterno,
            this.apellidoMaterno,
            this.sexo,
            this.suspensionrenta4ta,
            this.fechafin,
            this.fechaInicio,
            this.descripcion,
            this.colIdtreloj,
            this.colNombreHorario});
            this.dtgListaTrabajadores.Location = new System.Drawing.Point(7, 212);
            this.dtgListaTrabajadores.MultiSelect = false;
            this.dtgListaTrabajadores.Name = "dtgListaTrabajadores";
            this.dtgListaTrabajadores.RowHeadersVisible = false;
            this.dtgListaTrabajadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaTrabajadores.Size = new System.Drawing.Size(924, 271);
            this.dtgListaTrabajadores.TabIndex = 13;
            this.dtgListaTrabajadores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaTrabajadores_CellClick);
            this.dtgListaTrabajadores.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgListaTrabajadores_CellFormatting);
            this.dtgListaTrabajadores.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgListaTrabajadores_CurrentCellDirtyStateChanged);
            // 
            // id_trabajador
            // 
            this.id_trabajador.DataPropertyName = "id_trabajador";
            this.id_trabajador.HeaderText = "Codigo";
            this.id_trabajador.Name = "id_trabajador";
            this.id_trabajador.Width = 50;
            // 
            // dni
            // 
            this.dni.DataPropertyName = "dni";
            this.dni.HeaderText = "DNI";
            this.dni.Name = "dni";
            this.dni.Width = 70;
            // 
            // nombres
            // 
            this.nombres.DataPropertyName = "nombres";
            this.nombres.HeaderText = "Nombres";
            this.nombres.Name = "nombres";
            this.nombres.Width = 180;
            // 
            // apellidoPaterno
            // 
            this.apellidoPaterno.DataPropertyName = "apellidoPaterno";
            this.apellidoPaterno.HeaderText = "Apellido Paterno";
            this.apellidoPaterno.Name = "apellidoPaterno";
            this.apellidoPaterno.Width = 120;
            // 
            // apellidoMaterno
            // 
            this.apellidoMaterno.DataPropertyName = "apellidoMaterno";
            this.apellidoMaterno.HeaderText = "Apellido Materno";
            this.apellidoMaterno.Name = "apellidoMaterno";
            this.apellidoMaterno.Width = 120;
            // 
            // sexo
            // 
            this.sexo.DataPropertyName = "sexo";
            this.sexo.HeaderText = "Sexo";
            this.sexo.Name = "sexo";
            this.sexo.Width = 50;
            // 
            // suspensionrenta4ta
            // 
            this.suspensionrenta4ta.DataPropertyName = "suspencionrenta4ta";
            this.suspensionrenta4ta.HeaderText = "Renta4ta";
            this.suspensionrenta4ta.Name = "suspensionrenta4ta";
            this.suspensionrenta4ta.Visible = false;
            // 
            // fechafin
            // 
            this.fechafin.DataPropertyName = "fechafin";
            this.fechafin.HeaderText = "fechafin";
            this.fechafin.Name = "fechafin";
            this.fechafin.Visible = false;
            // 
            // fechaInicio
            // 
            this.fechaInicio.DataPropertyName = "fechainicio";
            this.fechaInicio.HeaderText = "fechaInicio";
            this.fechaInicio.Name = "fechaInicio";
            this.fechaInicio.Visible = false;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Cargo";
            this.descripcion.Name = "descripcion";
            // 
            // colIdtreloj
            // 
            this.colIdtreloj.DataPropertyName = "idtreloj";
            dataGridViewCellStyle5.NullValue = "No Asignado";
            this.colIdtreloj.DefaultCellStyle = dataGridViewCellStyle5;
            this.colIdtreloj.HeaderText = "Codigo Reloj";
            this.colIdtreloj.Name = "colIdtreloj";
            this.colIdtreloj.Width = 90;
            // 
            // colNombreHorario
            // 
            this.colNombreHorario.DataPropertyName = "nombrehorario";
            dataGridViewCellStyle6.NullValue = "Sin Horario";
            this.colNombreHorario.DefaultCellStyle = dataGridViewCellStyle6;
            this.colNombreHorario.HeaderText = "Nombre Horario";
            this.colNombreHorario.Name = "colNombreHorario";
            this.colNombreHorario.Width = 120;
            // 
            // btnImprimir2
            // 
            this.btnImprimir2.Image = global::CapaUsuario.Properties.Resources._17;
            this.btnImprimir2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir2.Name = "btnImprimir2";
            this.btnImprimir2.Size = new System.Drawing.Size(129, 25);
            this.btnImprimir2.Text = "Imprimir Asistencia";
            this.btnImprimir2.Click += new System.EventHandler(this.btnImprimir2_Click);
            // 
            // frmTrabajadorExcepcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 579);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTrabajadorExcepcion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excepciones de Trabajador";
            this.Load += new System.EventHandler(this.frmTrabajadorExcepcion_Load);
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

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAsignarHorario;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnNuevaSalidaTrabajador;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnAsistenciaMes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeFiltro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBuscarXMeta;
        private System.Windows.Forms.ComboBox cboMeta;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDetalleTareo;
        private System.Windows.Forms.Button btnBuscarAMaterno;
        private System.Windows.Forms.Button btnBuscarAPaterno;
        private System.Windows.Forms.Button btnBuscarNombre;
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
        private System.Windows.Forms.ToolStripButton btnAsignarNumeroReloj;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnSalidas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_trabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoPaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoMaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn suspensionrenta4ta;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechafin;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtreloj;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreHorario;
        private System.Windows.Forms.CheckBox chkMarcarTodos;
        private System.Windows.Forms.ToolStripButton btnEliminarHorario;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.ToolStripButton btnImprimir2;
    }
}