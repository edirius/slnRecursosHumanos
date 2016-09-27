namespace CapaUsuario.AFP
{
    partial class frmListaAFPs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaAFPs));
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.dtgListaAFPs = new System.Windows.Forms.DataGridView();
            this.codigoAfp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreAfp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigosunat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaAFPs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevo.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevo.Location = new System.Drawing.Point(19, 211);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(80, 53);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.MintCream;
            this.btnEliminar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEliminar.Location = new System.Drawing.Point(265, 211);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(86, 53);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.MintCream;
            this.btnModificar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnModificar.Location = new System.Drawing.Point(139, 211);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(86, 53);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // dtgListaAFPs
            // 
            this.dtgListaAFPs.AllowUserToAddRows = false;
            this.dtgListaAFPs.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dtgListaAFPs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaAFPs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaAFPs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoAfp,
            this.NombreAfp,
            this.codigosunat,
            this.tipo});
            this.dtgListaAFPs.Location = new System.Drawing.Point(18, 12);
            this.dtgListaAFPs.MultiSelect = false;
            this.dtgListaAFPs.Name = "dtgListaAFPs";
            this.dtgListaAFPs.ReadOnly = true;
            this.dtgListaAFPs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaAFPs.Size = new System.Drawing.Size(333, 186);
            this.dtgListaAFPs.TabIndex = 4;
            // 
            // codigoAfp
            // 
            this.codigoAfp.DataPropertyName = "idtAFP";
            this.codigoAfp.HeaderText = "Codigo";
            this.codigoAfp.Name = "codigoAfp";
            this.codigoAfp.ReadOnly = true;
            this.codigoAfp.Width = 50;
            // 
            // NombreAfp
            // 
            this.NombreAfp.DataPropertyName = "Nombre";
            this.NombreAfp.HeaderText = "AFP";
            this.NombreAfp.Name = "NombreAfp";
            this.NombreAfp.ReadOnly = true;
            this.NombreAfp.Width = 200;
            // 
            // codigosunat
            // 
            this.codigosunat.DataPropertyName = "codigosunat";
            this.codigosunat.HeaderText = "codigosunat";
            this.codigosunat.Name = "codigosunat";
            this.codigosunat.ReadOnly = true;
            this.codigosunat.Visible = false;
            // 
            // tipo
            // 
            this.tipo.DataPropertyName = "tipo";
            this.tipo.HeaderText = "tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Visible = false;
            // 
            // frmListaAFPs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 282);
            this.Controls.Add(this.dtgListaAFPs);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnNuevo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListaAFPs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista AFPs y ONP";
            this.Load += new System.EventHandler(this.frmListaAFPs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaAFPs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.DataGridView dtgListaAFPs;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoAfp;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreAfp;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigosunat;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
    }
}