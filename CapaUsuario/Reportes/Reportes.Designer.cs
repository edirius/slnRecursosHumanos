namespace CapaUsuario.Reportes
{
    partial class Reportes
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bdpersonal = new CapaUsuario.bdpersonal();
            this.bdpersonalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bdpersonalBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.spTareoObrasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spTareoObrasTableAdapter = new CapaUsuario.bdpersonalTableAdapters.spTareoObrasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bdpersonal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdpersonalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdpersonalBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTareoObrasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "TareoObras";
            reportDataSource1.Value = this.spTareoObrasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaUsuario.Reportes.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(655, 491);
            this.reportViewer1.TabIndex = 0;
            // 
            // bdpersonal
            // 
            this.bdpersonal.DataSetName = "bdpersonal";
            this.bdpersonal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdpersonalBindingSource
            // 
            this.bdpersonalBindingSource.DataSource = this.bdpersonal;
            this.bdpersonalBindingSource.Position = 0;
            // 
            // bdpersonalBindingSource1
            // 
            this.bdpersonalBindingSource1.DataSource = this.bdpersonal;
            this.bdpersonalBindingSource1.Position = 0;
            // 
            // spTareoObrasBindingSource
            // 
            this.spTareoObrasBindingSource.DataMember = "spTareoObras";
            this.spTareoObrasBindingSource.DataSource = this.bdpersonalBindingSource;
            // 
            // spTareoObrasTableAdapter
            // 
            this.spTareoObrasTableAdapter.ClearBeforeFill = true;
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 490);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Reportes";
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.Reportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bdpersonal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdpersonalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdpersonalBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTareoObrasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource bdpersonalBindingSource;
        private bdpersonal bdpersonal;
        private System.Windows.Forms.BindingSource bdpersonalBindingSource1;
        private System.Windows.Forms.BindingSource spTareoObrasBindingSource;
        private bdpersonalTableAdapters.spTareoObrasTableAdapter spTareoObrasTableAdapter;
    }
}