namespace CapaUsuario.ExportarSunat
{
    partial class frmCompararDatosAFP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompararDatosAFP));
            this.dtgDatosPlanilla = new System.Windows.Forms.DataGridView();
            this.mnuAFP = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAFPError = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCUSSPError = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuComisionError = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDNIError = new System.Windows.Forms.ToolStripMenuItem();
            this.dtgDatosExcel = new System.Windows.Forms.DataGridView();
            this.btnCargar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.mnuAFP2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCopiarCUSPP = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatosPlanilla)).BeginInit();
            this.mnuAFP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatosExcel)).BeginInit();
            this.mnuAFP2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgDatosPlanilla
            // 
            this.dtgDatosPlanilla.AllowUserToAddRows = false;
            this.dtgDatosPlanilla.AllowUserToDeleteRows = false;
            this.dtgDatosPlanilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatosPlanilla.ContextMenuStrip = this.mnuAFP;
            this.dtgDatosPlanilla.Location = new System.Drawing.Point(12, 170);
            this.dtgDatosPlanilla.Name = "dtgDatosPlanilla";
            this.dtgDatosPlanilla.ReadOnly = true;
            this.dtgDatosPlanilla.Size = new System.Drawing.Size(587, 263);
            this.dtgDatosPlanilla.TabIndex = 0;
            this.dtgDatosPlanilla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDatosPlanilla_CellContentClick);
            this.dtgDatosPlanilla.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgDatosPlanilla_CellFormatting);
            this.dtgDatosPlanilla.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtgDatosPlanilla_RowsAdded);
            this.dtgDatosPlanilla.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dtgDatosPlanilla_Scroll);
            // 
            // mnuAFP
            // 
            this.mnuAFP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAFPError,
            this.mnuCUSSPError,
            this.mnuComisionError,
            this.mnuDNIError});
            this.mnuAFP.Name = "mnuAFP";
            this.mnuAFP.Size = new System.Drawing.Size(68, 92);
            // 
            // mnuAFPError
            // 
            this.mnuAFPError.Name = "mnuAFPError";
            this.mnuAFPError.Size = new System.Drawing.Size(67, 22);
            // 
            // mnuCUSSPError
            // 
            this.mnuCUSSPError.Name = "mnuCUSSPError";
            this.mnuCUSSPError.Size = new System.Drawing.Size(67, 22);
            // 
            // mnuComisionError
            // 
            this.mnuComisionError.Name = "mnuComisionError";
            this.mnuComisionError.Size = new System.Drawing.Size(67, 22);
            // 
            // mnuDNIError
            // 
            this.mnuDNIError.Name = "mnuDNIError";
            this.mnuDNIError.Size = new System.Drawing.Size(67, 22);
            // 
            // dtgDatosExcel
            // 
            this.dtgDatosExcel.AllowUserToAddRows = false;
            this.dtgDatosExcel.AllowUserToDeleteRows = false;
            this.dtgDatosExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatosExcel.ContextMenuStrip = this.mnuAFP2;
            this.dtgDatosExcel.Location = new System.Drawing.Point(634, 170);
            this.dtgDatosExcel.MultiSelect = false;
            this.dtgDatosExcel.Name = "dtgDatosExcel";
            this.dtgDatosExcel.ReadOnly = true;
            this.dtgDatosExcel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDatosExcel.Size = new System.Drawing.Size(574, 263);
            this.dtgDatosExcel.TabIndex = 1;
            this.dtgDatosExcel.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgDatosExcel_CellFormatting);
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.MintCream;
            this.btnCargar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCargar.Location = new System.Drawing.Point(492, 12);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(154, 53);
            this.btnCargar.TabIndex = 48;
            this.btnCargar.Text = "&Cargar Resultados Excel";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Image = global::CapaUsuario.Properties.Resources.Habitat;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(737, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 25);
            this.label4.TabIndex = 52;
            this.label4.Text = "HABITAT";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Image = global::CapaUsuario.Properties.Resources.profuturo;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(558, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 25);
            this.label3.TabIndex = 51;
            this.label3.Text = "PROFUTURO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Image = global::CapaUsuario.Properties.Resources.prima;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(410, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 25);
            this.label2.TabIndex = 50;
            this.label2.Text = "PRIMA";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Image = global::CapaUsuario.Properties.Resources.integra;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(242, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.TabIndex = 49;
            this.label1.Text = "INTEGRA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(12, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(587, 23);
            this.label5.TabIndex = 53;
            this.label5.Text = "Datos de la Planilla";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(634, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(574, 23);
            this.label6.TabIndex = 54;
            this.label6.Text = "Datos de AFP.NET";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.MintCream;
            this.btnActualizar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnActualizar.Location = new System.Drawing.Point(930, 61);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(92, 42);
            this.btnActualizar.TabIndex = 55;
            this.btnActualizar.Text = "&Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // mnuAFP2
            // 
            this.mnuAFP2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopiarCUSPP});
            this.mnuAFP2.Name = "mnuAFP2";
            this.mnuAFP2.Size = new System.Drawing.Size(149, 26);
            // 
            // mnuCopiarCUSPP
            // 
            this.mnuCopiarCUSPP.Name = "mnuCopiarCUSPP";
            this.mnuCopiarCUSPP.Size = new System.Drawing.Size(148, 22);
            this.mnuCopiarCUSPP.Text = "Copiar CUSPP";
            this.mnuCopiarCUSPP.Click += new System.EventHandler(this.mnuCopiarCUSPP_Click);
            // 
            // frmCompararDatosAFP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 455);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.dtgDatosExcel);
            this.Controls.Add(this.dtgDatosPlanilla);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCompararDatosAFP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comparar Datos de AFP";
            this.Load += new System.EventHandler(this.frmCompararDatosAFP_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmCompararDatosAFP_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatosPlanilla)).EndInit();
            this.mnuAFP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatosExcel)).EndInit();
            this.mnuAFP2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgDatosPlanilla;
        private System.Windows.Forms.DataGridView dtgDatosExcel;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ContextMenuStrip mnuAFP;
        private System.Windows.Forms.ToolStripMenuItem mnuAFPError;
        private System.Windows.Forms.ToolStripMenuItem mnuCUSSPError;
        private System.Windows.Forms.ToolStripMenuItem mnuComisionError;
        private System.Windows.Forms.ToolStripMenuItem mnuDNIError;
        private System.Windows.Forms.ContextMenuStrip mnuAFP2;
        private System.Windows.Forms.ToolStripMenuItem mnuCopiarCUSPP;
    }
}