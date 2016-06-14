namespace CapaUsuario.Navegador
{
    partial class frmNavegador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNavegador));
            this.toolBarra = new System.Windows.Forms.ToolStrip();
            this.btnAtras = new System.Windows.Forms.ToolStripButton();
            this.btnAdelante = new System.Windows.Forms.ToolStripButton();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnParar = new System.Windows.Forms.ToolStripButton();
            this.btnPrincipal = new System.Windows.Forms.ToolStripButton();
            this.txtDireccion = new System.Windows.Forms.ToolStripTextBox();
            this.btnIra = new System.Windows.Forms.ToolStripButton();
            this.webPrincipal = new System.Windows.Forms.WebBrowser();
            this.toolBarra.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBarra
            // 
            this.toolBarra.AutoSize = false;
            this.toolBarra.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAtras,
            this.btnAdelante,
            this.btnActualizar,
            this.btnParar,
            this.btnPrincipal,
            this.txtDireccion,
            this.btnIra});
            this.toolBarra.Location = new System.Drawing.Point(0, 0);
            this.toolBarra.Name = "toolBarra";
            this.toolBarra.Size = new System.Drawing.Size(573, 39);
            this.toolBarra.TabIndex = 0;
            this.toolBarra.Text = "Navegador";
            // 
            // btnAtras
            // 
            this.btnAtras.AutoSize = false;
            this.btnAtras.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAtras.Image = ((System.Drawing.Image)(resources.GetObject("btnAtras.Image")));
            this.btnAtras.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(33, 46);
            this.btnAtras.Text = "toolStripButton1";
            this.btnAtras.ToolTipText = "Atras";
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnAdelante
            // 
            this.btnAdelante.AutoSize = false;
            this.btnAdelante.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdelante.Image = ((System.Drawing.Image)(resources.GetObject("btnAdelante.Image")));
            this.btnAdelante.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdelante.Name = "btnAdelante";
            this.btnAdelante.Size = new System.Drawing.Size(33, 46);
            this.btnAdelante.Text = "toolStripButton1";
            this.btnAdelante.ToolTipText = "Adelante";
            this.btnAdelante.Click += new System.EventHandler(this.btnAdelante_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.AutoSize = false;
            this.btnActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnActualizar.Image = global::CapaUsuario.Properties.Resources.refresh;
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(33, 46);
            this.btnActualizar.Text = "toolStripButton1";
            this.btnActualizar.ToolTipText = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnParar
            // 
            this.btnParar.AutoSize = false;
            this.btnParar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnParar.Image = global::CapaUsuario.Properties.Resources.close;
            this.btnParar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnParar.Name = "btnParar";
            this.btnParar.Size = new System.Drawing.Size(33, 46);
            this.btnParar.Text = "toolStripButton1";
            this.btnParar.ToolTipText = "Parar";
            this.btnParar.Click += new System.EventHandler(this.btnParar_Click);
            // 
            // btnPrincipal
            // 
            this.btnPrincipal.AutoSize = false;
            this.btnPrincipal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrincipal.Image = global::CapaUsuario.Properties.Resources.home;
            this.btnPrincipal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrincipal.Name = "btnPrincipal";
            this.btnPrincipal.Size = new System.Drawing.Size(33, 46);
            this.btnPrincipal.Text = "toolStripButton1";
            this.btnPrincipal.ToolTipText = "Inicio";
            this.btnPrincipal.Click += new System.EventHandler(this.btnPrincipal_Click);
            // 
            // txtDireccion
            // 
            this.txtDireccion.AutoSize = false;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(200, 39);
            // 
            // btnIra
            // 
            this.btnIra.AutoSize = false;
            this.btnIra.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnIra.Image = global::CapaUsuario.Properties.Resources.download;
            this.btnIra.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIra.Name = "btnIra";
            this.btnIra.Size = new System.Drawing.Size(33, 46);
            this.btnIra.Text = "toolStripButton1";
            this.btnIra.ToolTipText = "Navegar";
            this.btnIra.Click += new System.EventHandler(this.btnIra_Click);
            // 
            // webPrincipal
            // 
            this.webPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webPrincipal.Location = new System.Drawing.Point(0, 39);
            this.webPrincipal.MinimumSize = new System.Drawing.Size(20, 20);
            this.webPrincipal.Name = "webPrincipal";
            this.webPrincipal.Size = new System.Drawing.Size(573, 255);
            this.webPrincipal.TabIndex = 1;
            // 
            // frmNavegador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 294);
            this.Controls.Add(this.webPrincipal);
            this.Controls.Add(this.toolBarra);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNavegador";
            this.Text = "Navegador Web";
            this.Load += new System.EventHandler(this.frmNavegador_Load);
            this.toolBarra.ResumeLayout(false);
            this.toolBarra.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolBarra;
        private System.Windows.Forms.ToolStripButton btnAtras;
        private System.Windows.Forms.ToolStripButton btnAdelante;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripButton btnParar;
        private System.Windows.Forms.ToolStripButton btnPrincipal;
        private System.Windows.Forms.ToolStripTextBox txtDireccion;
        private System.Windows.Forms.ToolStripButton btnIra;
        private System.Windows.Forms.WebBrowser webPrincipal;
    }
}