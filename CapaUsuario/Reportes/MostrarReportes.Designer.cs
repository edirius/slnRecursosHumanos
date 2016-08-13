namespace CapaUsuario.Reportes
{
    partial class MostrarReportes
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.spTareoObrasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bdpersonal = new CapaUsuario.bdpersonal();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.spTareoObrasTableAdapter = new CapaUsuario.bdpersonalTableAdapters.spTareoObrasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.spTareoObrasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdpersonal)).BeginInit();
            this.SuspendLayout();
            // 
            // spTareoObrasBindingSource
            // 
            this.spTareoObrasBindingSource.DataMember = "spTareoObras";
            this.spTareoObrasBindingSource.DataSource = this.bdpersonal;
            this.spTareoObrasBindingSource.CurrentChanged += new System.EventHandler(this.spTareoObrasBindingSource_CurrentChanged);
            // 
            // bdpersonal
            // 
            this.bdpersonal.DataSetName = "bdpersonal";
            this.bdpersonal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "TareoObras";
            reportDataSource1.Value = this.spTareoObrasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaUsuario.Reportes.TareoObras.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1129, 533);
            this.reportViewer1.TabIndex = 0;
            // 
            // spTareoObrasTableAdapter
            // 
            this.spTareoObrasTableAdapter.ClearBeforeFill = true;
            // 
            // MostrarReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 533);
            this.Controls.Add(this.reportViewer1);
            this.Name = "MostrarReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MostrarReportes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MostrarReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spTareoObrasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdpersonal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private bdpersonal bdpersonal;
        private System.Windows.Forms.BindingSource spTareoObrasBindingSource;
        private bdpersonalTableAdapters.spTareoObrasTableAdapter spTareoObrasTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}