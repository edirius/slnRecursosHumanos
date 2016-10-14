namespace CapaDeUsuarioTramite
{
    partial class frmMenuTramite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuTramite));
            this.MenuBarra = new System.Windows.Forms.MenuStrip();
            this.oficinasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoOficinasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoOfincaTrabajadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoRequisitosOficinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoLocalesSedesDeLaMunicipalidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoDocumentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeDocumentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tramiteDocumentarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarTramiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BarraEstado = new System.Windows.Forms.StatusStrip();
            this.StripLabelUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripLabelCargo = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripLabelOficina = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dgvListar = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MenuBarra.SuspendLayout();
            this.BarraEstado.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuBarra
            // 
            this.MenuBarra.BackColor = System.Drawing.Color.White;
            this.MenuBarra.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oficinasToolStripMenuItem,
            this.documentoToolStripMenuItem,
            this.tramiteDocumentarioToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.MenuBarra.Location = new System.Drawing.Point(0, 0);
            this.MenuBarra.Name = "MenuBarra";
            this.MenuBarra.Size = new System.Drawing.Size(783, 24);
            this.MenuBarra.TabIndex = 0;
            this.MenuBarra.Text = "menuStrip1";
            // 
            // oficinasToolStripMenuItem
            // 
            this.oficinasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mantenimientoOficinasToolStripMenuItem,
            this.mantenimientoOfincaTrabajadorToolStripMenuItem,
            this.mantenimientoRequisitosOficinaToolStripMenuItem,
            this.mantenimientoLocalesSedesDeLaMunicipalidadToolStripMenuItem});
            this.oficinasToolStripMenuItem.Name = "oficinasToolStripMenuItem";
            this.oficinasToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.oficinasToolStripMenuItem.Text = "Oficinas";
            // 
            // mantenimientoOficinasToolStripMenuItem
            // 
            this.mantenimientoOficinasToolStripMenuItem.Name = "mantenimientoOficinasToolStripMenuItem";
            this.mantenimientoOficinasToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.mantenimientoOficinasToolStripMenuItem.Text = "Mantenimiento Oficinas";
            this.mantenimientoOficinasToolStripMenuItem.Click += new System.EventHandler(this.mantenimientoOficinasToolStripMenuItem_Click);
            // 
            // mantenimientoOfincaTrabajadorToolStripMenuItem
            // 
            this.mantenimientoOfincaTrabajadorToolStripMenuItem.Name = "mantenimientoOfincaTrabajadorToolStripMenuItem";
            this.mantenimientoOfincaTrabajadorToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.mantenimientoOfincaTrabajadorToolStripMenuItem.Text = "Mantenimiento Oficina-Trabajador";
            this.mantenimientoOfincaTrabajadorToolStripMenuItem.Click += new System.EventHandler(this.mantenimientoOfincaTrabajadorToolStripMenuItem_Click);
            // 
            // mantenimientoRequisitosOficinaToolStripMenuItem
            // 
            this.mantenimientoRequisitosOficinaToolStripMenuItem.Name = "mantenimientoRequisitosOficinaToolStripMenuItem";
            this.mantenimientoRequisitosOficinaToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.mantenimientoRequisitosOficinaToolStripMenuItem.Text = "Mantenimiento Requisitos - Oficina";
            this.mantenimientoRequisitosOficinaToolStripMenuItem.Click += new System.EventHandler(this.mantenimientoRequisitosOficinaToolStripMenuItem_Click);
            // 
            // mantenimientoLocalesSedesDeLaMunicipalidadToolStripMenuItem
            // 
            this.mantenimientoLocalesSedesDeLaMunicipalidadToolStripMenuItem.Name = "mantenimientoLocalesSedesDeLaMunicipalidadToolStripMenuItem";
            this.mantenimientoLocalesSedesDeLaMunicipalidadToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.mantenimientoLocalesSedesDeLaMunicipalidadToolStripMenuItem.Text = "Mantenimiento Local-Sedes de la Municipalidad";
            this.mantenimientoLocalesSedesDeLaMunicipalidadToolStripMenuItem.Click += new System.EventHandler(this.mantenimientoLocalesSedesDeLaMunicipalidadToolStripMenuItem_Click);
            // 
            // documentoToolStripMenuItem
            // 
            this.documentoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mantenimientoDocumentoToolStripMenuItem,
            this.tipoDeDocumentoToolStripMenuItem,
            this.operacionesToolStripMenuItem});
            this.documentoToolStripMenuItem.Name = "documentoToolStripMenuItem";
            this.documentoToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.documentoToolStripMenuItem.Text = "Documentos";
            // 
            // mantenimientoDocumentoToolStripMenuItem
            // 
            this.mantenimientoDocumentoToolStripMenuItem.Name = "mantenimientoDocumentoToolStripMenuItem";
            this.mantenimientoDocumentoToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.mantenimientoDocumentoToolStripMenuItem.Text = "Mantenimiento Documento";
            this.mantenimientoDocumentoToolStripMenuItem.Click += new System.EventHandler(this.mantenimientoDocumentoToolStripMenuItem_Click);
            // 
            // tipoDeDocumentoToolStripMenuItem
            // 
            this.tipoDeDocumentoToolStripMenuItem.Name = "tipoDeDocumentoToolStripMenuItem";
            this.tipoDeDocumentoToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.tipoDeDocumentoToolStripMenuItem.Text = "Mantenimiento Tipo de Documento";
            this.tipoDeDocumentoToolStripMenuItem.Click += new System.EventHandler(this.tipoDeDocumentoToolStripMenuItem_Click);
            // 
            // operacionesToolStripMenuItem
            // 
            this.operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            this.operacionesToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.operacionesToolStripMenuItem.Text = "Operaciones";
            this.operacionesToolStripMenuItem.Click += new System.EventHandler(this.operacionesToolStripMenuItem_Click);
            // 
            // tramiteDocumentarioToolStripMenuItem
            // 
            this.tramiteDocumentarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarTramiteToolStripMenuItem});
            this.tramiteDocumentarioToolStripMenuItem.Name = "tramiteDocumentarioToolStripMenuItem";
            this.tramiteDocumentarioToolStripMenuItem.Size = new System.Drawing.Size(196, 20);
            this.tramiteDocumentarioToolStripMenuItem.Text = "Proceso de tramite documentario";
            // 
            // registrarTramiteToolStripMenuItem
            // 
            this.registrarTramiteToolStripMenuItem.Name = "registrarTramiteToolStripMenuItem";
            this.registrarTramiteToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.registrarTramiteToolStripMenuItem.Text = "Registrar tramite documentario";
            this.registrarTramiteToolStripMenuItem.Click += new System.EventHandler(this.registrarTramiteToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // BarraEstado
            // 
            this.BarraEstado.AllowItemReorder = true;
            this.BarraEstado.BackColor = System.Drawing.Color.White;
            this.BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripLabelUsuario,
            this.StripLabelCargo,
            this.StripLabelOficina,
            this.toolStripUsuario});
            this.BarraEstado.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.BarraEstado.Location = new System.Drawing.Point(0, 434);
            this.BarraEstado.Name = "BarraEstado";
            this.BarraEstado.Size = new System.Drawing.Size(783, 20);
            this.BarraEstado.TabIndex = 2;
            this.BarraEstado.Text = "statusStrip1";
            // 
            // StripLabelUsuario
            // 
            this.StripLabelUsuario.Name = "StripLabelUsuario";
            this.StripLabelUsuario.Size = new System.Drawing.Size(64, 15);
            this.StripLabelUsuario.Text = "Trabajador";
            // 
            // StripLabelCargo
            // 
            this.StripLabelCargo.Name = "StripLabelCargo";
            this.StripLabelCargo.Size = new System.Drawing.Size(39, 15);
            this.StripLabelCargo.Text = "Cargo";
            // 
            // StripLabelOficina
            // 
            this.StripLabelOficina.Name = "StripLabelOficina";
            this.StripLabelOficina.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StripLabelOficina.Size = new System.Drawing.Size(45, 15);
            this.StripLabelOficina.Text = "Oficina";
            // 
            // toolStripUsuario
            // 
            this.toolStripUsuario.Name = "toolStripUsuario";
            this.toolStripUsuario.Size = new System.Drawing.Size(47, 15);
            this.toolStripUsuario.Text = "Usuario";
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.White;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(783, 25);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "ToolStrip";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // dgvListar
            // 
            this.dgvListar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListar.Location = new System.Drawing.Point(12, 184);
            this.dgvListar.Name = "dgvListar";
            this.dgvListar.Size = new System.Drawing.Size(46, 48);
            this.dgvListar.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(89, 385);
            this.panel1.TabIndex = 9;
            // 
            // frmMenuTramite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(783, 454);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvListar);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.BarraEstado);
            this.Controls.Add(this.MenuBarra);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MenuBarra;
            this.Name = "frmMenuTramite";
            this.Text = "Sistema de Tramite Documentario de la Municipalidad de CCATCCA  V1.1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMenuTramite_FormClosing);
            this.Load += new System.EventHandler(this.frmMenuTramite_Load);
            this.MenuBarra.ResumeLayout(false);
            this.MenuBarra.PerformLayout();
            this.BarraEstado.ResumeLayout(false);
            this.BarraEstado.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuBarra;
        private System.Windows.Forms.ToolStripMenuItem oficinasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoOficinasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoDocumentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeDocumentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoOfincaTrabajadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tramiteDocumentarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarTramiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoRequisitosOficinaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoLocalesSedesDeLaMunicipalidadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operacionesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip BarraEstado;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        public System.Windows.Forms.ToolStripStatusLabel StripLabelUsuario;
        public System.Windows.Forms.ToolStripStatusLabel StripLabelCargo;
        public System.Windows.Forms.ToolStripStatusLabel StripLabelOficina;
        public System.Windows.Forms.DataGridView dgvListar;
        public System.Windows.Forms.ToolStripStatusLabel toolStripUsuario;
        private System.Windows.Forms.Panel panel1;
    }
}