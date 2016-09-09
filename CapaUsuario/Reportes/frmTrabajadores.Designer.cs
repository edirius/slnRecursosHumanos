namespace CapaUsuario.Reportes
{
    partial class frmTrabajadores
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
            this.crTrabajador = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crListaTrabajador1 = new CapaUsuario.Reportes.crListaTrabajador();
            this.crReporteTrabajador1 = new CapaUsuario.Reportes.crReporteTrabajador();
            this.SuspendLayout();
            // 
            // crTrabajador
            // 
            this.crTrabajador.ActiveViewIndex = 0;
            this.crTrabajador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crTrabajador.Cursor = System.Windows.Forms.Cursors.Default;
            this.crTrabajador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crTrabajador.Location = new System.Drawing.Point(0, 0);
            this.crTrabajador.Name = "crTrabajador";
            this.crTrabajador.ReportSource = this.crReporteTrabajador1;
            this.crTrabajador.Size = new System.Drawing.Size(1217, 494);
            this.crTrabajador.TabIndex = 0;
            this.crTrabajador.Load += new System.EventHandler(this.crTrabajador_Load);
            // 
            // frmTrabajadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 494);
            this.Controls.Add(this.crTrabajador);
            this.Name = "frmTrabajadores";
            this.Text = "frmTrabajadores";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crTrabajador;
        private crListaTrabajador crListaTrabajador1;
        private crReporteTrabajador crReporteTrabajador1;
    }
}