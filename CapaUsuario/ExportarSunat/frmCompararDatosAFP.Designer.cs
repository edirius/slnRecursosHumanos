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
            this.dtgDatosPlanilla = new System.Windows.Forms.DataGridView();
            this.dtgDatosExcel = new System.Windows.Forms.DataGridView();
            this.btnCargar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatosPlanilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatosExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgDatosPlanilla
            // 
            this.dtgDatosPlanilla.AllowUserToAddRows = false;
            this.dtgDatosPlanilla.AllowUserToDeleteRows = false;
            this.dtgDatosPlanilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatosPlanilla.Location = new System.Drawing.Point(12, 128);
            this.dtgDatosPlanilla.Name = "dtgDatosPlanilla";
            this.dtgDatosPlanilla.ReadOnly = true;
            this.dtgDatosPlanilla.Size = new System.Drawing.Size(448, 263);
            this.dtgDatosPlanilla.TabIndex = 0;
            this.dtgDatosPlanilla.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgDatosPlanilla_CellFormatting);
            this.dtgDatosPlanilla.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtgDatosPlanilla_RowsAdded);
            // 
            // dtgDatosExcel
            // 
            this.dtgDatosExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatosExcel.Location = new System.Drawing.Point(492, 128);
            this.dtgDatosExcel.Name = "dtgDatosExcel";
            this.dtgDatosExcel.Size = new System.Drawing.Size(448, 263);
            this.dtgDatosExcel.TabIndex = 1;
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
            this.label4.Location = new System.Drawing.Point(552, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 25);
            this.label4.TabIndex = 52;
            this.label4.Text = "HABITAT";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Image = global::CapaUsuario.Properties.Resources.profuturo;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(399, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 25);
            this.label3.TabIndex = 51;
            this.label3.Text = "PROFUTURO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Image = global::CapaUsuario.Properties.Resources.prima;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(261, 90);
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
            this.label1.Location = new System.Drawing.Point(55, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.TabIndex = 49;
            this.label1.Text = "INTEGRA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmCompararDatosAFP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 405);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.dtgDatosExcel);
            this.Controls.Add(this.dtgDatosPlanilla);
            this.Name = "frmCompararDatosAFP";
            this.Text = "Comparar Datos de AFP";
            this.Load += new System.EventHandler(this.frmCompararDatosAFP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatosPlanilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatosExcel)).EndInit();
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
    }
}