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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaTrabajadores));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnDatosLaborales = new System.Windows.Forms.Button();
            this.btnDetalleTareo = new System.Windows.Forms.Button();
            this.chkActivos = new System.Windows.Forms.CheckBox();
            this.btnBuscarAMaterno = new System.Windows.Forms.Button();
            this.btnBuscarAPaterno = new System.Windows.Forms.Button();
            this.btnBuscarNombre = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
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
            this.btnNuevoTrabajador = new System.Windows.Forms.ToolStripButton();
            this.btnModificarTrabajador = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarTrabajador = new System.Windows.Forms.ToolStripButton();
            this.btnImprimirLista = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 480);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(902, 22);
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
            this.toolStrip1.Size = new System.Drawing.Size(902, 28);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnDatosLaborales);
            this.splitContainer1.Panel2.Controls.Add(this.btnDetalleTareo);
            this.splitContainer1.Panel2.Controls.Add(this.chkActivos);
            this.splitContainer1.Panel2.Controls.Add(this.btnBuscarAMaterno);
            this.splitContainer1.Panel2.Controls.Add(this.btnBuscarAPaterno);
            this.splitContainer1.Panel2.Controls.Add(this.btnBuscarNombre);
            this.splitContainer1.Panel2.Controls.Add(this.textBox4);
            this.splitContainer1.Panel2.Controls.Add(this.textBox3);
            this.splitContainer1.Panel2.Controls.Add(this.textBox2);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.btnBuscarDNI);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txtDNI);
            this.splitContainer1.Panel2.Controls.Add(this.dtgListaTrabajadores);
            this.splitContainer1.Size = new System.Drawing.Size(902, 452);
            this.splitContainer1.SplitterDistance = 163;
            this.splitContainer1.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(163, 452);
            this.treeView1.TabIndex = 0;
            // 
            // btnDatosLaborales
            // 
            this.btnDatosLaborales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDatosLaborales.BackColor = System.Drawing.Color.MintCream;
            this.btnDatosLaborales.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnDatosLaborales.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDatosLaborales.ImageIndex = 1;
            this.btnDatosLaborales.Location = new System.Drawing.Point(591, 395);
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
            this.btnDetalleTareo.Location = new System.Drawing.Point(591, 470);
            this.btnDetalleTareo.Name = "btnDetalleTareo";
            this.btnDetalleTareo.Size = new System.Drawing.Size(114, 53);
            this.btnDetalleTareo.TabIndex = 30;
            this.btnDetalleTareo.Text = "&Detalle Tareo";
            this.btnDetalleTareo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDetalleTareo.UseVisualStyleBackColor = false;
            // 
            // chkActivos
            // 
            this.chkActivos.AutoSize = true;
            this.chkActivos.Checked = true;
            this.chkActivos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivos.Location = new System.Drawing.Point(539, 101);
            this.chkActivos.Name = "chkActivos";
            this.chkActivos.Size = new System.Drawing.Size(99, 17);
            this.chkActivos.TabIndex = 29;
            this.chkActivos.Text = "Mostrar Activos";
            this.chkActivos.UseVisualStyleBackColor = true;
            // 
            // btnBuscarAMaterno
            // 
            this.btnBuscarAMaterno.Location = new System.Drawing.Point(348, 101);
            this.btnBuscarAMaterno.Name = "btnBuscarAMaterno";
            this.btnBuscarAMaterno.Size = new System.Drawing.Size(164, 23);
            this.btnBuscarAMaterno.TabIndex = 28;
            this.btnBuscarAMaterno.Text = "Buscar por Apellido Materno";
            this.btnBuscarAMaterno.UseVisualStyleBackColor = true;
            // 
            // btnBuscarAPaterno
            // 
            this.btnBuscarAPaterno.Location = new System.Drawing.Point(348, 70);
            this.btnBuscarAPaterno.Name = "btnBuscarAPaterno";
            this.btnBuscarAPaterno.Size = new System.Drawing.Size(164, 23);
            this.btnBuscarAPaterno.TabIndex = 27;
            this.btnBuscarAPaterno.Text = "Buscar por Apellido Paterno";
            this.btnBuscarAPaterno.UseVisualStyleBackColor = true;
            // 
            // btnBuscarNombre
            // 
            this.btnBuscarNombre.Location = new System.Drawing.Point(348, 43);
            this.btnBuscarNombre.Name = "btnBuscarNombre";
            this.btnBuscarNombre.Size = new System.Drawing.Size(164, 23);
            this.btnBuscarNombre.TabIndex = 26;
            this.btnBuscarNombre.Text = "Buscar por Nombres";
            this.btnBuscarNombre.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(113, 105);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(216, 20);
            this.textBox4.TabIndex = 25;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(113, 74);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(216, 20);
            this.textBox3.TabIndex = 24;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(113, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(216, 20);
            this.textBox2.TabIndex = 23;
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
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtgListaTrabajadores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaTrabajadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaTrabajadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTrabajador,
            this.dni,
            this.nombres,
            this.apellidoPaterno,
            this.apellidoMaterno,
            this.sexo});
            this.dtgListaTrabajadores.Location = new System.Drawing.Point(15, 133);
            this.dtgListaTrabajadores.MultiSelect = false;
            this.dtgListaTrabajadores.Name = "dtgListaTrabajadores";
            this.dtgListaTrabajadores.ReadOnly = true;
            this.dtgListaTrabajadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaTrabajadores.Size = new System.Drawing.Size(690, 252);
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
            // btnModificarTrabajador
            // 
            this.btnModificarTrabajador.Image = global::CapaUsuario.Properties.Resources.add_to_folder;
            this.btnModificarTrabajador.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModificarTrabajador.Name = "btnModificarTrabajador";
            this.btnModificarTrabajador.Size = new System.Drawing.Size(137, 25);
            this.btnModificarTrabajador.Text = "Modificar Trabajador";
            this.btnModificarTrabajador.Click += new System.EventHandler(this.btnModificarTrabajador_Click);
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
            // btnImprimirLista
            // 
            this.btnImprimirLista.Image = global::CapaUsuario.Properties.Resources.chart;
            this.btnImprimirLista.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimirLista.Name = "btnImprimirLista";
            this.btnImprimirLista.Size = new System.Drawing.Size(100, 25);
            this.btnImprimirLista.Text = "Imprimir Lista";
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
            // frmListaTrabajadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 502);
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
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
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
        private System.Windows.Forms.CheckBox chkActivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoPaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoMaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexo;
        private System.Windows.Forms.Button btnDetalleTareo;
        private System.Windows.Forms.Button btnDatosLaborales;
    }
}