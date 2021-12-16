namespace CapaUsuario.ClasificadorMeta
{
    partial class frmClasificadorMeta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClasificadorMeta));
            this.label1 = new System.Windows.Forms.Label();
            this.cboMeta = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPlantilla = new System.Windows.Forms.ComboBox();
            this.dtgClasificadorMeta = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plantilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Especifica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminarClasificador = new System.Windows.Forms.Button();
            this.btnModificarClasificador = new System.Windows.Forms.Button();
            this.btnNuevoClasificador = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboAño = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgClasificadorMeta)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Meta:";
            // 
            // cboMeta
            // 
            this.cboMeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMeta.FormattingEnabled = true;
            this.cboMeta.Location = new System.Drawing.Point(91, 41);
            this.cboMeta.Name = "cboMeta";
            this.cboMeta.Size = new System.Drawing.Size(333, 21);
            this.cboMeta.TabIndex = 1;
            this.cboMeta.SelectedIndexChanged += new System.EventHandler(this.cboMeta_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Plantilla:";
            // 
            // cboPlantilla
            // 
            this.cboPlantilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlantilla.FormattingEnabled = true;
            this.cboPlantilla.Location = new System.Drawing.Point(91, 79);
            this.cboPlantilla.Name = "cboPlantilla";
            this.cboPlantilla.Size = new System.Drawing.Size(333, 21);
            this.cboPlantilla.TabIndex = 3;
            this.cboPlantilla.SelectedIndexChanged += new System.EventHandler(this.cboPlantilla_SelectedIndexChanged);
            // 
            // dtgClasificadorMeta
            // 
            this.dtgClasificadorMeta.AllowUserToAddRows = false;
            this.dtgClasificadorMeta.AllowUserToDeleteRows = false;
            this.dtgClasificadorMeta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgClasificadorMeta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Plantilla,
            this.Especifica,
            this.Column4,
            this.Column5});
            this.dtgClasificadorMeta.Location = new System.Drawing.Point(43, 145);
            this.dtgClasificadorMeta.Name = "dtgClasificadorMeta";
            this.dtgClasificadorMeta.ReadOnly = true;
            this.dtgClasificadorMeta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgClasificadorMeta.Size = new System.Drawing.Size(471, 170);
            this.dtgClasificadorMeta.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "idttdatosmetaclasificador";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Plantilla
            // 
            this.Plantilla.DataPropertyName = "Plantilla";
            this.Plantilla.HeaderText = "Plantilla";
            this.Plantilla.Name = "Plantilla";
            this.Plantilla.ReadOnly = true;
            this.Plantilla.Width = 200;
            // 
            // Especifica
            // 
            this.Especifica.DataPropertyName = "Especifica";
            this.Especifica.HeaderText = "Codigo Especifica";
            this.Especifica.Name = "Especifica";
            this.Especifica.ReadOnly = true;
            this.Especifica.Visible = false;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Descripcion";
            this.Column4.HeaderText = "Especifica";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Concepto";
            this.Column5.HeaderText = "Concepto";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // btnEliminarClasificador
            // 
            this.btnEliminarClasificador.BackColor = System.Drawing.Color.MintCream;
            this.btnEliminarClasificador.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarClasificador.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEliminarClasificador.Location = new System.Drawing.Point(414, 332);
            this.btnEliminarClasificador.Name = "btnEliminarClasificador";
            this.btnEliminarClasificador.Size = new System.Drawing.Size(100, 47);
            this.btnEliminarClasificador.TabIndex = 16;
            this.btnEliminarClasificador.Text = "Eliminar Clasificador";
            this.btnEliminarClasificador.UseVisualStyleBackColor = false;
            this.btnEliminarClasificador.Click += new System.EventHandler(this.btnEliminarClasificador_Click);
            // 
            // btnModificarClasificador
            // 
            this.btnModificarClasificador.BackColor = System.Drawing.Color.MintCream;
            this.btnModificarClasificador.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarClasificador.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnModificarClasificador.Location = new System.Drawing.Point(229, 332);
            this.btnModificarClasificador.Name = "btnModificarClasificador";
            this.btnModificarClasificador.Size = new System.Drawing.Size(100, 47);
            this.btnModificarClasificador.TabIndex = 15;
            this.btnModificarClasificador.Text = "Modificar Clasificador";
            this.btnModificarClasificador.UseVisualStyleBackColor = false;
            this.btnModificarClasificador.Click += new System.EventHandler(this.btnModificarClasificador_Click);
            // 
            // btnNuevoClasificador
            // 
            this.btnNuevoClasificador.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevoClasificador.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoClasificador.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevoClasificador.Location = new System.Drawing.Point(43, 332);
            this.btnNuevoClasificador.Name = "btnNuevoClasificador";
            this.btnNuevoClasificador.Size = new System.Drawing.Size(100, 47);
            this.btnNuevoClasificador.TabIndex = 14;
            this.btnNuevoClasificador.Text = "Nuevo Clasificador";
            this.btnNuevoClasificador.UseVisualStyleBackColor = false;
            this.btnNuevoClasificador.Click += new System.EventHandler(this.btnNuevoClasificador_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 88;
            this.label3.Text = "Año :";
            // 
            // cboAño
            // 
            this.cboAño.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(91, 7);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(144, 21);
            this.cboAño.TabIndex = 87;
            this.cboAño.SelectedIndexChanged += new System.EventHandler(this.cboAño_SelectedIndexChanged);
            // 
            // frmClasificadorMeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 404);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboAño);
            this.Controls.Add(this.btnEliminarClasificador);
            this.Controls.Add(this.btnModificarClasificador);
            this.Controls.Add(this.btnNuevoClasificador);
            this.Controls.Add(this.dtgClasificadorMeta);
            this.Controls.Add(this.cboPlantilla);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboMeta);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmClasificadorMeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clasificador por meta y planilla";
            this.Load += new System.EventHandler(this.frmClasificadorMeta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgClasificadorMeta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMeta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboPlantilla;
        private System.Windows.Forms.DataGridView dtgClasificadorMeta;
        private System.Windows.Forms.Button btnEliminarClasificador;
        private System.Windows.Forms.Button btnModificarClasificador;
        private System.Windows.Forms.Button btnNuevoClasificador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plantilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Especifica;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}