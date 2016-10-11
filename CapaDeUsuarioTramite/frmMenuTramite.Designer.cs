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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.oficinasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoOficinasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requisitosOficinasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoRequisitosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoDocumentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeDocumentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoOfincaTrabajadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oficinasToolStripMenuItem,
            this.requisitosOficinasToolStripMenuItem,
            this.documentoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(783, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // oficinasToolStripMenuItem
            // 
            this.oficinasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mantenimientoOficinasToolStripMenuItem,
            this.mantenimientoOfincaTrabajadorToolStripMenuItem});
            this.oficinasToolStripMenuItem.Name = "oficinasToolStripMenuItem";
            this.oficinasToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.oficinasToolStripMenuItem.Text = "Oficinas";
            // 
            // mantenimientoOficinasToolStripMenuItem
            // 
            this.mantenimientoOficinasToolStripMenuItem.Name = "mantenimientoOficinasToolStripMenuItem";
            this.mantenimientoOficinasToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.mantenimientoOficinasToolStripMenuItem.Text = "Mantenimiento Oficinas";
            this.mantenimientoOficinasToolStripMenuItem.Click += new System.EventHandler(this.mantenimientoOficinasToolStripMenuItem_Click);
            // 
            // requisitosOficinasToolStripMenuItem
            // 
            this.requisitosOficinasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mantenimientoRequisitosToolStripMenuItem});
            this.requisitosOficinasToolStripMenuItem.Name = "requisitosOficinasToolStripMenuItem";
            this.requisitosOficinasToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.requisitosOficinasToolStripMenuItem.Text = "Requisitos-Oficinas";
            // 
            // mantenimientoRequisitosToolStripMenuItem
            // 
            this.mantenimientoRequisitosToolStripMenuItem.Name = "mantenimientoRequisitosToolStripMenuItem";
            this.mantenimientoRequisitosToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.mantenimientoRequisitosToolStripMenuItem.Text = "MantenimientoRequisitos";
            this.mantenimientoRequisitosToolStripMenuItem.Click += new System.EventHandler(this.mantenimientoRequisitosToolStripMenuItem_Click);
            // 
            // documentoToolStripMenuItem
            // 
            this.documentoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mantenimientoDocumentoToolStripMenuItem,
            this.tipoDeDocumentoToolStripMenuItem});
            this.documentoToolStripMenuItem.Name = "documentoToolStripMenuItem";
            this.documentoToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.documentoToolStripMenuItem.Text = "Documento";
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
            // 
            // mantenimientoOfincaTrabajadorToolStripMenuItem
            // 
            this.mantenimientoOfincaTrabajadorToolStripMenuItem.Name = "mantenimientoOfincaTrabajadorToolStripMenuItem";
            this.mantenimientoOfincaTrabajadorToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.mantenimientoOfincaTrabajadorToolStripMenuItem.Text = "Mantenimiento Oficina-Trabajador";
            this.mantenimientoOfincaTrabajadorToolStripMenuItem.Click += new System.EventHandler(this.mantenimientoOfincaTrabajadorToolStripMenuItem_Click);
            // 
            // frmMenuTramite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 454);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMenuTramite";
            this.Text = "Sistema de Tramite Documentario de la Municipalidad de CCATCCA  V1.1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMenuTramite_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem oficinasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoOficinasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requisitosOficinasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoRequisitosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoDocumentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeDocumentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoOfincaTrabajadorToolStripMenuItem;
    }
}