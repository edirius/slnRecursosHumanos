namespace CapaUsuario.Reportes
{
    partial class frmPlanilla
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
            this.crvPlanilla = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvPlanilla
            // 
            this.crvPlanilla.ActiveViewIndex = -1;
            this.crvPlanilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPlanilla.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvPlanilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvPlanilla.Location = new System.Drawing.Point(0, 0);
            this.crvPlanilla.Name = "crvPlanilla";
            this.crvPlanilla.Size = new System.Drawing.Size(994, 542);
            this.crvPlanilla.TabIndex = 0;
            this.crvPlanilla.Load += new System.EventHandler(this.crvPlanilla_Load);
            // 
            // frmPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 542);
            this.Controls.Add(this.crvPlanilla);
            this.IsMdiContainer = true;
            this.Name = "frmPlanilla";
            this.Text = "Planilla";
            this.Load += new System.EventHandler(this.frmPlanilla_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPlanilla;
    }
}