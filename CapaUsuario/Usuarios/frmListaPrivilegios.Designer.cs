namespace CapaUsuario.Usuarios
{
    partial class frmListaPrivilegios
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
            this.dtgPrivilegios = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.idtPrivilegio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuAFP = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MenuUsuario = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPrivilegios)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgPrivilegios
            // 
            this.dtgPrivilegios.AllowUserToAddRows = false;
            this.dtgPrivilegios.AllowUserToDeleteRows = false;
            this.dtgPrivilegios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPrivilegios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtPrivilegio,
            this.Nombre,
            this.MenuAFP,
            this.MenuUsuario});
            this.dtgPrivilegios.Location = new System.Drawing.Point(12, 12);
            this.dtgPrivilegios.Name = "dtgPrivilegios";
            this.dtgPrivilegios.ReadOnly = true;
            this.dtgPrivilegios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPrivilegios.Size = new System.Drawing.Size(424, 188);
            this.dtgPrivilegios.TabIndex = 0;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(42, 236);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(347, 236);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(198, 236);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // idtPrivilegio
            // 
            this.idtPrivilegio.DataPropertyName = "idtPrivilegios";
            this.idtPrivilegio.HeaderText = "Codigo";
            this.idtPrivilegio.Name = "idtPrivilegio";
            this.idtPrivilegio.ReadOnly = true;
            this.idtPrivilegio.Width = 50;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 200;
            // 
            // MenuAFP
            // 
            this.MenuAFP.DataPropertyName = "MenuAFP";
            this.MenuAFP.HeaderText = "Menu AFP";
            this.MenuAFP.Name = "MenuAFP";
            this.MenuAFP.ReadOnly = true;
            this.MenuAFP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MenuAFP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MenuAFP.Width = 50;
            // 
            // MenuUsuario
            // 
            this.MenuUsuario.DataPropertyName = "MenuUsuario";
            this.MenuUsuario.HeaderText = "Menu Usuario";
            this.MenuUsuario.Name = "MenuUsuario";
            this.MenuUsuario.ReadOnly = true;
            this.MenuUsuario.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MenuUsuario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MenuUsuario.Width = 50;
            // 
            // frmListaPrivilegios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 293);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dtgPrivilegios);
            this.Name = "frmListaPrivilegios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Privilegios";
            this.Load += new System.EventHandler(this.frmListaPrivilegios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPrivilegios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgPrivilegios;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtPrivilegio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewCheckBoxColumn MenuAFP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn MenuUsuario;
    }
}