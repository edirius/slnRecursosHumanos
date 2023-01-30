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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Todos");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Activos", 2, 2);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Inactivos", 2, 2);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Sin Periodo Laboral", 2, 2);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Situacion Laboral", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Todos", 1, 1);
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Regimen CAS", 2, 2);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("DL. 276", 2, 2);
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("DL. 728", 2, 2);
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("DL. 30057");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Racionamiento");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Regimen Laboral", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("FILTRO DE TRABAJADORES", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode12});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaTrabajadores));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusTrabajadores = new System.Windows.Forms.StatusStrip();
            this.lblNumeroTrabajadores = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNuevoTrabajador = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnModificarTrabajador = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEliminarTrabajador = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImprimirLista = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDatosFijosxTrabajador = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImprimirListaReloj = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeFiltro = new System.Windows.Forms.TreeView();
            this.imageLista = new System.Windows.Forms.ImageList(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnCambiarMeta = new System.Windows.Forms.Button();
            this.btnReporteContratos = new System.Windows.Forms.Button();
            this.btnContratos = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBuscarXMeta = new System.Windows.Forms.Button();
            this.cboMeta = new System.Windows.Forms.ComboBox();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.menuAuxiliar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuCopiarDNI = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopiarNombreCompleto = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopiarNombre = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopiarPaterno = new System.Windows.Forms.ToolStripMenuItem();
            this.menuApellidoMaterno = new System.Windows.Forms.ToolStripMenuItem();
            this.statusTrabajadores.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTrabajadores)).BeginInit();
            this.menuAuxiliar.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // statusTrabajadores
            // 
            this.statusTrabajadores.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblNumeroTrabajadores});
            this.statusTrabajadores.Location = new System.Drawing.Point(0, 569);
            this.statusTrabajadores.Name = "statusTrabajadores";
            this.statusTrabajadores.Size = new System.Drawing.Size(1092, 22);
            this.statusTrabajadores.TabIndex = 1;
            this.statusTrabajadores.Text = "statusStrip1";
            // 
            // lblNumeroTrabajadores
            // 
            this.lblNumeroTrabajadores.Name = "lblNumeroTrabajadores";
            this.lblNumeroTrabajadores.Size = new System.Drawing.Size(100, 17);
            this.lblNumeroTrabajadores.Text = "Nro Trabajadores:";
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
            this.btnDatosFijosxTrabajador,
            this.toolStripSeparator5,
            this.btnImprimirListaReloj,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1092, 28);
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
            this.btnImprimirLista.Click += new System.EventHandler(this.btnImprimirLista_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // btnDatosFijosxTrabajador
            // 
            this.btnDatosFijosxTrabajador.Image = global::CapaUsuario.Properties.Resources._98;
            this.btnDatosFijosxTrabajador.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDatosFijosxTrabajador.Name = "btnDatosFijosxTrabajador";
            this.btnDatosFijosxTrabajador.Size = new System.Drawing.Size(84, 25);
            this.btnDatosFijosxTrabajador.Text = "Datos Fijos";
            this.btnDatosFijosxTrabajador.Click += new System.EventHandler(this.btnDatosFijosxTrabajador_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 28);
            // 
            // btnImprimirListaReloj
            // 
            this.btnImprimirListaReloj.Image = global::CapaUsuario.Properties.Resources.chart;
            this.btnImprimirListaReloj.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimirListaReloj.Name = "btnImprimirListaReloj";
            this.btnImprimirListaReloj.Size = new System.Drawing.Size(129, 25);
            this.btnImprimirListaReloj.Text = "Imprimir Lista Reloj";
            this.btnImprimirListaReloj.Click += new System.EventHandler(this.btnImprimirListaReloj_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::CapaUsuario.Properties.Resources.WinXPSetV4_Icon_17;
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
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.dtpFecha);
            this.splitContainer1.Panel2.Controls.Add(this.btnCambiarMeta);
            this.splitContainer1.Panel2.Controls.Add(this.btnReporteContratos);
            this.splitContainer1.Panel2.Controls.Add(this.btnContratos);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.btnBuscarXMeta);
            this.splitContainer1.Panel2.Controls.Add(this.cboMeta);
            this.splitContainer1.Panel2.Controls.Add(this.cboAño);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
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
            this.splitContainer1.Size = new System.Drawing.Size(1092, 541);
            this.splitContainer1.SplitterDistance = 214;
            this.splitContainer1.TabIndex = 3;
            // 
            // treeFiltro
            // 
            this.treeFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFiltro.ImageIndex = 0;
            this.treeFiltro.ImageList = this.imageLista;
            this.treeFiltro.Location = new System.Drawing.Point(0, 0);
            this.treeFiltro.Name = "treeFiltro";
            treeNode1.BackColor = System.Drawing.Color.Teal;
            treeNode1.Name = "Node3";
            treeNode1.SelectedImageIndex = 0;
            treeNode1.Text = "Todos";
            treeNode2.ImageIndex = 2;
            treeNode2.Name = "Node4";
            treeNode2.SelectedImageIndex = 2;
            treeNode2.Text = "Activos";
            treeNode3.ImageIndex = 2;
            treeNode3.Name = "Node5";
            treeNode3.SelectedImageIndex = 2;
            treeNode3.Text = "Inactivos";
            treeNode4.ImageIndex = 2;
            treeNode4.Name = "Node6";
            treeNode4.SelectedImageIndex = 2;
            treeNode4.Text = "Sin Periodo Laboral";
            treeNode5.Checked = true;
            treeNode5.ImageIndex = 2;
            treeNode5.Name = "Node1";
            treeNode5.SelectedImageIndex = 2;
            treeNode5.Text = "Situacion Laboral";
            treeNode6.BackColor = System.Drawing.Color.Teal;
            treeNode6.ImageIndex = 1;
            treeNode6.Name = "Node0";
            treeNode6.SelectedImageIndex = 1;
            treeNode6.Text = "Todos";
            treeNode7.ImageIndex = 2;
            treeNode7.Name = "Node9";
            treeNode7.SelectedImageIndex = 2;
            treeNode7.Text = "Regimen CAS";
            treeNode8.ImageIndex = 2;
            treeNode8.Name = "Node10";
            treeNode8.SelectedImageIndex = 2;
            treeNode8.Text = "DL. 276";
            treeNode9.ImageIndex = 2;
            treeNode9.Name = "Node11";
            treeNode9.SelectedImageIndex = 2;
            treeNode9.Text = "DL. 728";
            treeNode10.ImageIndex = 2;
            treeNode10.Name = "Node0";
            treeNode10.Text = "DL. 30057";
            treeNode11.ImageIndex = 2;
            treeNode11.Name = "Node1";
            treeNode11.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            treeNode11.Text = "Racionamiento";
            treeNode12.Checked = true;
            treeNode12.ImageIndex = 2;
            treeNode12.Name = "Node8";
            treeNode12.SelectedImageIndex = 2;
            treeNode12.Text = "Regimen Laboral";
            treeNode13.Checked = true;
            treeNode13.ImageIndex = 2;
            treeNode13.Name = "Node0";
            treeNode13.SelectedImageIndex = 2;
            treeNode13.Text = "FILTRO DE TRABAJADORES";
            treeNode13.ToolTipText = "Seleccione abajo para filtrar la lista de trabajadores.";
            this.treeFiltro.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode13});
            this.treeFiltro.SelectedImageIndex = 0;
            this.treeFiltro.Size = new System.Drawing.Size(214, 541);
            this.treeFiltro.TabIndex = 0;
            this.treeFiltro.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFiltro_AfterSelect);
            this.treeFiltro.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeFiltro_NodeMouseClick);
            this.treeFiltro.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeFiltro_MouseClick);
            // 
            // imageLista
            // 
            this.imageLista.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageLista.ImageStream")));
            this.imageLista.TransparentColor = System.Drawing.Color.Transparent;
            this.imageLista.Images.SetKeyName(0, "161.ICO");
            this.imageLista.Images.SetKeyName(1, "WinXPSetV4 Icon 23.ico");
            this.imageLista.Images.SetKeyName(2, "123.ICO");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(545, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(591, 7);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 43;
            // 
            // btnCambiarMeta
            // 
            this.btnCambiarMeta.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCambiarMeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarMeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarMeta.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCambiarMeta.Location = new System.Drawing.Point(295, 138);
            this.btnCambiarMeta.Name = "btnCambiarMeta";
            this.btnCambiarMeta.Size = new System.Drawing.Size(217, 23);
            this.btnCambiarMeta.TabIndex = 42;
            this.btnCambiarMeta.Text = "Cambiar la meta del ultimo Periodo";
            this.btnCambiarMeta.UseVisualStyleBackColor = false;
            this.btnCambiarMeta.Click += new System.EventHandler(this.btnCambiarMeta_Click);
            // 
            // btnReporteContratos
            // 
            this.btnReporteContratos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReporteContratos.BackColor = System.Drawing.Color.MintCream;
            this.btnReporteContratos.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnReporteContratos.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnReporteContratos.ImageIndex = 1;
            this.btnReporteContratos.Location = new System.Drawing.Point(493, 485);
            this.btnReporteContratos.Name = "btnReporteContratos";
            this.btnReporteContratos.Size = new System.Drawing.Size(114, 53);
            this.btnReporteContratos.TabIndex = 41;
            this.btnReporteContratos.Text = "&Reporte Contratos";
            this.btnReporteContratos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReporteContratos.UseVisualStyleBackColor = false;
            this.btnReporteContratos.Click += new System.EventHandler(this.btnReporteContratos_Click);
            // 
            // btnContratos
            // 
            this.btnContratos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnContratos.BackColor = System.Drawing.Color.MintCream;
            this.btnContratos.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnContratos.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnContratos.ImageIndex = 1;
            this.btnContratos.Location = new System.Drawing.Point(613, 485);
            this.btnContratos.Name = "btnContratos";
            this.btnContratos.Size = new System.Drawing.Size(114, 53);
            this.btnContratos.TabIndex = 40;
            this.btnContratos.Text = "&Contratos";
            this.btnContratos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnContratos.UseVisualStyleBackColor = false;
            this.btnContratos.Click += new System.EventHandler(this.btnContratos_Click);
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
            this.btnBuscarXMeta.Location = new System.Drawing.Point(557, 167);
            this.btnBuscarXMeta.Name = "btnBuscarXMeta";
            this.btnBuscarXMeta.Size = new System.Drawing.Size(164, 23);
            this.btnBuscarXMeta.TabIndex = 38;
            this.btnBuscarXMeta.Text = "Buscar por Meta";
            this.btnBuscarXMeta.UseVisualStyleBackColor = false;
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
            // btnDatosLaborales
            // 
            this.btnDatosLaborales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDatosLaborales.BackColor = System.Drawing.Color.MintCream;
            this.btnDatosLaborales.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnDatosLaborales.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDatosLaborales.ImageIndex = 1;
            this.btnDatosLaborales.Location = new System.Drawing.Point(733, 485);
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
            this.btnDetalleTareo.Location = new System.Drawing.Point(591, 559);
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
            this.btnBuscarAMaterno.Size = new System.Drawing.Size(164, 23);
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
            this.btnBuscarAPaterno.Size = new System.Drawing.Size(164, 23);
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
            this.btnBuscarNombre.Size = new System.Drawing.Size(164, 23);
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
            this.txtBuscarApellidoMaterno.Enter += new System.EventHandler(this.txtBuscarApellidoMaterno_Enter);
            this.txtBuscarApellidoMaterno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarApellidoMaterno_KeyDown);
            // 
            // txtBuscarApellidoPaterno
            // 
            this.txtBuscarApellidoPaterno.Location = new System.Drawing.Point(113, 74);
            this.txtBuscarApellidoPaterno.MaxLength = 49;
            this.txtBuscarApellidoPaterno.Name = "txtBuscarApellidoPaterno";
            this.txtBuscarApellidoPaterno.Size = new System.Drawing.Size(216, 20);
            this.txtBuscarApellidoPaterno.TabIndex = 24;
            this.txtBuscarApellidoPaterno.Enter += new System.EventHandler(this.txtBuscarApellidoPaterno_Enter);
            this.txtBuscarApellidoPaterno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarApellidoPaterno_KeyDown);
            // 
            // txtBuscarNombre
            // 
            this.txtBuscarNombre.Location = new System.Drawing.Point(113, 43);
            this.txtBuscarNombre.MaxLength = 49;
            this.txtBuscarNombre.Name = "txtBuscarNombre";
            this.txtBuscarNombre.Size = new System.Drawing.Size(216, 20);
            this.txtBuscarNombre.TabIndex = 23;
            this.txtBuscarNombre.Enter += new System.EventHandler(this.txtBuscarNombre_Enter);
            this.txtBuscarNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarNombre_KeyDown);
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
            this.label1.Location = new System.Drawing.Point(16, 19);
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
            this.txtDNI.Enter += new System.EventHandler(this.txtDNI_Enter);
            this.txtDNI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDNI_KeyDown);
            this.txtDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDNI_KeyPress);
            // 
            // dtgListaTrabajadores
            // 
            this.dtgListaTrabajadores.AllowUserToAddRows = false;
            this.dtgListaTrabajadores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtgListaTrabajadores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            this.descripcion});
            this.dtgListaTrabajadores.ContextMenuStrip = this.menuAuxiliar;
            this.dtgListaTrabajadores.Location = new System.Drawing.Point(15, 212);
            this.dtgListaTrabajadores.MultiSelect = false;
            this.dtgListaTrabajadores.Name = "dtgListaTrabajadores";
            this.dtgListaTrabajadores.ReadOnly = true;
            this.dtgListaTrabajadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaTrabajadores.Size = new System.Drawing.Size(834, 271);
            this.dtgListaTrabajadores.TabIndex = 13;
            this.dtgListaTrabajadores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaTrabajadores_CellClick);
            this.dtgListaTrabajadores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaTrabajadores_CellContentClick);
            // 
            // id_trabajador
            // 
            this.id_trabajador.DataPropertyName = "id_trabajador";
            this.id_trabajador.HeaderText = "Codigo";
            this.id_trabajador.Name = "id_trabajador";
            this.id_trabajador.ReadOnly = true;
            this.id_trabajador.Width = 50;
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
            this.nombres.Width = 180;
            // 
            // apellidoPaterno
            // 
            this.apellidoPaterno.DataPropertyName = "apellidoPaterno";
            this.apellidoPaterno.HeaderText = "Apellido Paterno";
            this.apellidoPaterno.Name = "apellidoPaterno";
            this.apellidoPaterno.ReadOnly = true;
            this.apellidoPaterno.Width = 180;
            // 
            // apellidoMaterno
            // 
            this.apellidoMaterno.DataPropertyName = "apellidoMaterno";
            this.apellidoMaterno.HeaderText = "Apellido Materno";
            this.apellidoMaterno.Name = "apellidoMaterno";
            this.apellidoMaterno.ReadOnly = true;
            this.apellidoMaterno.Width = 180;
            // 
            // sexo
            // 
            this.sexo.DataPropertyName = "sexo";
            this.sexo.HeaderText = "Sexo";
            this.sexo.Name = "sexo";
            this.sexo.ReadOnly = true;
            this.sexo.Width = 50;
            // 
            // suspensionrenta4ta
            // 
            this.suspensionrenta4ta.DataPropertyName = "suspencionrenta4ta";
            this.suspensionrenta4ta.HeaderText = "Renta4ta";
            this.suspensionrenta4ta.Name = "suspensionrenta4ta";
            this.suspensionrenta4ta.ReadOnly = true;
            this.suspensionrenta4ta.Visible = false;
            // 
            // fechafin
            // 
            this.fechafin.DataPropertyName = "fechafin";
            this.fechafin.HeaderText = "fechafin";
            this.fechafin.Name = "fechafin";
            this.fechafin.ReadOnly = true;
            this.fechafin.Visible = false;
            // 
            // fechaInicio
            // 
            this.fechaInicio.DataPropertyName = "fechainicio";
            this.fechaInicio.HeaderText = "fechaInicio";
            this.fechaInicio.Name = "fechaInicio";
            this.fechaInicio.ReadOnly = true;
            this.fechaInicio.Visible = false;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Cargo";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Visible = false;
            // 
            // menuAuxiliar
            // 
            this.menuAuxiliar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCopiarDNI,
            this.menuCopiarNombreCompleto,
            this.menuCopiarNombre,
            this.menuCopiarPaterno,
            this.menuApellidoMaterno});
            this.menuAuxiliar.Name = "menuAuxiliar";
            this.menuAuxiliar.Size = new System.Drawing.Size(213, 114);
            // 
            // menuCopiarDNI
            // 
            this.menuCopiarDNI.Name = "menuCopiarDNI";
            this.menuCopiarDNI.Size = new System.Drawing.Size(212, 22);
            this.menuCopiarDNI.Text = "CopiarDNI";
            this.menuCopiarDNI.Click += new System.EventHandler(this.menuCopiarDNI_Click);
            // 
            // menuCopiarNombreCompleto
            // 
            this.menuCopiarNombreCompleto.Name = "menuCopiarNombreCompleto";
            this.menuCopiarNombreCompleto.Size = new System.Drawing.Size(212, 22);
            this.menuCopiarNombreCompleto.Text = "Copiar Nombre Completo";
            this.menuCopiarNombreCompleto.Click += new System.EventHandler(this.menuCopiarNombreCompleto_Click);
            // 
            // menuCopiarNombre
            // 
            this.menuCopiarNombre.Name = "menuCopiarNombre";
            this.menuCopiarNombre.Size = new System.Drawing.Size(212, 22);
            this.menuCopiarNombre.Text = "Copiar Nombre";
            this.menuCopiarNombre.Click += new System.EventHandler(this.menuCopiarNombre_Click);
            // 
            // menuCopiarPaterno
            // 
            this.menuCopiarPaterno.Name = "menuCopiarPaterno";
            this.menuCopiarPaterno.Size = new System.Drawing.Size(212, 22);
            this.menuCopiarPaterno.Text = "Copiar Apellido Paterno";
            this.menuCopiarPaterno.Click += new System.EventHandler(this.menuCopiarPaterno_Click);
            // 
            // menuApellidoMaterno
            // 
            this.menuApellidoMaterno.Name = "menuApellidoMaterno";
            this.menuApellidoMaterno.Size = new System.Drawing.Size(212, 22);
            this.menuApellidoMaterno.Text = "Copiar Apellido Materno";
            this.menuApellidoMaterno.Click += new System.EventHandler(this.menuApellidoMaterno_Click);
            // 
            // frmListaTrabajadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 591);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusTrabajadores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListaTrabajadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Trabajadores";
            this.Load += new System.EventHandler(this.frmListaTrabajadores_Load);
            this.statusTrabajadores.ResumeLayout(false);
            this.statusTrabajadores.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTrabajadores)).EndInit();
            this.menuAuxiliar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.StatusStrip statusTrabajadores;
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
        private System.Windows.Forms.Button btnDetalleTareo;
        private System.Windows.Forms.Button btnDatosLaborales;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.ComboBox cboMeta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBuscarXMeta;
        private System.Windows.Forms.ContextMenuStrip menuAuxiliar;
        private System.Windows.Forms.ToolStripMenuItem menuCopiarDNI;
        private System.Windows.Forms.ToolStripMenuItem menuCopiarNombreCompleto;
        private System.Windows.Forms.ToolStripMenuItem menuCopiarNombre;
        private System.Windows.Forms.ToolStripMenuItem menuCopiarPaterno;
        private System.Windows.Forms.ToolStripMenuItem menuApellidoMaterno;
        private System.Windows.Forms.ImageList imageLista;
        private System.Windows.Forms.ToolStripStatusLabel lblNumeroTrabajadores;
        private System.Windows.Forms.Button btnContratos;
        private System.Windows.Forms.Button btnReporteContratos;
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
        private System.Windows.Forms.ToolStripButton btnDatosFijosxTrabajador;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Button btnCambiarMeta;
        private System.Windows.Forms.ToolStripButton btnImprimirListaReloj;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFecha;
    }
}