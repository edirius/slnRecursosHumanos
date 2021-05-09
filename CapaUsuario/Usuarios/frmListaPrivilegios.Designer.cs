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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaPrivilegios));
            this.dtgPrivilegios = new System.Windows.Forms.DataGridView();
            this.idtPrivilegio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuAFP = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MenuUsuario = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MenuTrabajadores = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MenuTareos = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.menuMeta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.menuPlanillas = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.menuSunatTablasParametricas = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.menuExportarDatos = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.menuReportes = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPrivilegios)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgPrivilegios
            // 
            this.dtgPrivilegios.AllowUserToAddRows = false;
            this.dtgPrivilegios.AllowUserToDeleteRows = false;
            this.dtgPrivilegios.AllowUserToResizeColumns = false;
            this.dtgPrivilegios.AllowUserToResizeRows = false;
            this.dtgPrivilegios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPrivilegios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtPrivilegio,
            this.Nombre,
            this.MenuAFP,
            this.MenuUsuario,
            this.MenuTrabajadores,
            this.MenuTareos,
            this.menuMeta,
            this.menuPlanillas,
            this.menuSunatTablasParametricas,
            this.menuExportarDatos,
            this.menuReportes});
            this.dtgPrivilegios.Location = new System.Drawing.Point(12, 12);
            this.dtgPrivilegios.Name = "dtgPrivilegios";
            this.dtgPrivilegios.ReadOnly = true;
            this.dtgPrivilegios.RowHeadersVisible = false;
            this.dtgPrivilegios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPrivilegios.Size = new System.Drawing.Size(901, 209);
            this.dtgPrivilegios.TabIndex = 0;
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
            this.MenuAFP.Width = 70;
            // 
            // MenuUsuario
            // 
            this.MenuUsuario.DataPropertyName = "MenuUsuario";
            this.MenuUsuario.HeaderText = "Menu Usuario";
            this.MenuUsuario.Name = "MenuUsuario";
            this.MenuUsuario.ReadOnly = true;
            this.MenuUsuario.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MenuUsuario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MenuUsuario.Width = 70;
            // 
            // MenuTrabajadores
            // 
            this.MenuTrabajadores.DataPropertyName = "MenuTrabajadores";
            this.MenuTrabajadores.HeaderText = "Menu Trabajadores";
            this.MenuTrabajadores.Name = "MenuTrabajadores";
            this.MenuTrabajadores.ReadOnly = true;
            this.MenuTrabajadores.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MenuTrabajadores.Width = 70;
            // 
            // MenuTareos
            // 
            this.MenuTareos.DataPropertyName = "MenuTareos";
            this.MenuTareos.HeaderText = "Menu Tareos";
            this.MenuTareos.Name = "MenuTareos";
            this.MenuTareos.ReadOnly = true;
            this.MenuTareos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MenuTareos.Width = 70;
            // 
            // menuMeta
            // 
            this.menuMeta.DataPropertyName = "MenuMeta";
            this.menuMeta.HeaderText = "Menu Meta";
            this.menuMeta.Name = "menuMeta";
            this.menuMeta.ReadOnly = true;
            this.menuMeta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.menuMeta.Width = 70;
            // 
            // menuPlanillas
            // 
            this.menuPlanillas.DataPropertyName = "MenuPlanillas";
            this.menuPlanillas.HeaderText = "Menu Planillas";
            this.menuPlanillas.Name = "menuPlanillas";
            this.menuPlanillas.ReadOnly = true;
            this.menuPlanillas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.menuPlanillas.Width = 70;
            // 
            // menuSunatTablasParametricas
            // 
            this.menuSunatTablasParametricas.DataPropertyName = "MenuSunatTablasParametricas";
            this.menuSunatTablasParametricas.HeaderText = "Menu Tablas Parametricas";
            this.menuSunatTablasParametricas.Name = "menuSunatTablasParametricas";
            this.menuSunatTablasParametricas.ReadOnly = true;
            this.menuSunatTablasParametricas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.menuSunatTablasParametricas.Width = 70;
            // 
            // menuExportarDatos
            // 
            this.menuExportarDatos.DataPropertyName = "MenuExportarDatosSunat";
            this.menuExportarDatos.HeaderText = "Menu Exportar Datos";
            this.menuExportarDatos.Name = "menuExportarDatos";
            this.menuExportarDatos.ReadOnly = true;
            this.menuExportarDatos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.menuExportarDatos.Width = 70;
            // 
            // menuReportes
            // 
            this.menuReportes.DataPropertyName = "MenuReportes";
            this.menuReportes.HeaderText = "Menu Reportes";
            this.menuReportes.Name = "menuReportes";
            this.menuReportes.ReadOnly = true;
            this.menuReportes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.menuReportes.Width = 70;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(4, 4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(147, 40);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(318, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(142, 40);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(158, 4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(152, 40);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "&Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.47368F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.69828F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.11207F));
            this.tableLayoutPanel1.Controls.Add(this.btnNuevo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEliminar, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnModificar, 1, 0);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(241, 233);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(464, 48);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // frmListaPrivilegios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 294);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dtgPrivilegios);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListaPrivilegios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Privilegios";
            this.Load += new System.EventHandler(this.frmListaPrivilegios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPrivilegios)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn MenuTrabajadores;
        private System.Windows.Forms.DataGridViewCheckBoxColumn MenuTareos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn menuMeta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn menuPlanillas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn menuSunatTablasParametricas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn menuExportarDatos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn menuReportes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}