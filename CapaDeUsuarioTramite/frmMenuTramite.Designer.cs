﻿namespace CapaDeUsuarioTramite
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
            this.operaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operaciónToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.localSedeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oficinasToolStripMenuItem,
            this.operaciónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(783, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // oficinasToolStripMenuItem
            // 
            this.oficinasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mantenimientoOficinasToolStripMenuItem});
            this.oficinasToolStripMenuItem.Name = "oficinasToolStripMenuItem";
            this.oficinasToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.oficinasToolStripMenuItem.Text = "Oficinas";
            // 
            // mantenimientoOficinasToolStripMenuItem
            // 
            this.mantenimientoOficinasToolStripMenuItem.Name = "mantenimientoOficinasToolStripMenuItem";
            this.mantenimientoOficinasToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.mantenimientoOficinasToolStripMenuItem.Text = "Mantenimiento Oficinas";
            this.mantenimientoOficinasToolStripMenuItem.Click += new System.EventHandler(this.mantenimientoOficinasToolStripMenuItem_Click);
            // 
            // operaciónToolStripMenuItem
            // 
            this.operaciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operaciónToolStripMenuItem1,
            this.localSedeToolStripMenuItem});
            this.operaciónToolStripMenuItem.Name = "operaciónToolStripMenuItem";
            this.operaciónToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.operaciónToolStripMenuItem.Text = "Tramite";
            this.operaciónToolStripMenuItem.Click += new System.EventHandler(this.operaciónToolStripMenuItem_Click);
            // 
            // operaciónToolStripMenuItem1
            // 
            this.operaciónToolStripMenuItem1.Name = "operaciónToolStripMenuItem1";
            this.operaciónToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.operaciónToolStripMenuItem1.Text = "Operación";
            this.operaciónToolStripMenuItem1.Click += new System.EventHandler(this.operaciónToolStripMenuItem1_Click);
            // 
            // localSedeToolStripMenuItem
            // 
            this.localSedeToolStripMenuItem.Name = "localSedeToolStripMenuItem";
            this.localSedeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.localSedeToolStripMenuItem.Text = "Local Sede";
            this.localSedeToolStripMenuItem.Click += new System.EventHandler(this.localSedeToolStripMenuItem_Click);
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
        private System.Windows.Forms.ToolStripMenuItem operaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operaciónToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem localSedeToolStripMenuItem;
    }
}