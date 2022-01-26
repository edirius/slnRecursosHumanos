namespace CapaUsuario.CargaInicial
{
    partial class frmCargaInicial
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
            this.btnCargar = new System.Windows.Forms.Button();
            this.dtgDatosExcel = new System.Windows.Forms.DataGridView();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnDatosFijos = new System.Windows.Forms.Button();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidoPaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidoMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatosExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.MintCream;
            this.btnCargar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCargar.Location = new System.Drawing.Point(38, 28);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(154, 53);
            this.btnCargar.TabIndex = 49;
            this.btnCargar.Text = "&Cargar Reportes PDT Excel";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // dtgDatosExcel
            // 
            this.dtgDatosExcel.AllowUserToAddRows = false;
            this.dtgDatosExcel.AllowUserToDeleteRows = false;
            this.dtgDatosExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatosExcel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colNombres,
            this.colApellidoPaterno,
            this.colApellidoMaterno});
            this.dtgDatosExcel.Location = new System.Drawing.Point(38, 96);
            this.dtgDatosExcel.Name = "dtgDatosExcel";
            this.dtgDatosExcel.ReadOnly = true;
            this.dtgDatosExcel.Size = new System.Drawing.Size(770, 263);
            this.dtgDatosExcel.TabIndex = 50;
            this.dtgDatosExcel.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgDatosExcel_CellFormatting);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.MintCream;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSalvar.Location = new System.Drawing.Point(654, 379);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(154, 53);
            this.btnSalvar.TabIndex = 51;
            this.btnSalvar.Text = "&Salvar Datos";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnDatosFijos
            // 
            this.btnDatosFijos.BackColor = System.Drawing.Color.MintCream;
            this.btnDatosFijos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDatosFijos.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatosFijos.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDatosFijos.Location = new System.Drawing.Point(654, 28);
            this.btnDatosFijos.Name = "btnDatosFijos";
            this.btnDatosFijos.Size = new System.Drawing.Size(154, 53);
            this.btnDatosFijos.TabIndex = 52;
            this.btnDatosFijos.Text = "&Datos Fijos";
            this.btnDatosFijos.UseVisualStyleBackColor = false;
            this.btnDatosFijos.Click += new System.EventHandler(this.btnDatosFijos_Click);
            // 
            // colCodigo
            // 
            this.colCodigo.DataPropertyName = "MiTrabajador.IdTrabajador";
            this.colCodigo.HeaderText = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            // 
            // colNombres
            // 
            this.colNombres.DataPropertyName = "MiTrabajador.Nombres";
            this.colNombres.HeaderText = "Nombres";
            this.colNombres.Name = "colNombres";
            this.colNombres.ReadOnly = true;
            // 
            // colApellidoPaterno
            // 
            this.colApellidoPaterno.DataPropertyName = "MiTrabajador.ApellidoPaterno";
            this.colApellidoPaterno.HeaderText = "Apellido Paterno";
            this.colApellidoPaterno.Name = "colApellidoPaterno";
            this.colApellidoPaterno.ReadOnly = true;
            // 
            // colApellidoMaterno
            // 
            this.colApellidoMaterno.DataPropertyName = "MiTrabajador.ApellidoMaterno";
            this.colApellidoMaterno.HeaderText = "Apellido Materno";
            this.colApellidoMaterno.Name = "colApellidoMaterno";
            this.colApellidoMaterno.ReadOnly = true;
            // 
            // frmCargaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 441);
            this.Controls.Add(this.btnDatosFijos);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.dtgDatosExcel);
            this.Controls.Add(this.btnCargar);
            this.Name = "frmCargaInicial";
            this.Text = "Carga Inicial";
            this.Load += new System.EventHandler(this.frmCargaInicial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatosExcel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.DataGridView dtgDatosExcel;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnDatosFijos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidoPaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidoMaterno;
    }
}