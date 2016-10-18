namespace CapaUsuario.Metas
{
    partial class frmProgramaPresupuestal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProgramaPresupuestal));
            this.dtgProgramaPresupuestal = new System.Windows.Forms.DataGridView();
            this.programaPresupuestal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colidtProgramaPresupuestal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.año = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtgProductoProyecto = new System.Windows.Forms.DataGridView();
            this.colidtproductoproyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colproductoproyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colaño = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProgramaPresupuestal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnModificarProducto = new System.Windows.Forms.Button();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.btnNuevoProducto = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dtgActividadObra = new System.Windows.Forms.DataGridView();
            this.idtactividadobra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actividadobra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProductoProyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnModificarActividad = new System.Windows.Forms.Button();
            this.btnEliminarActividad = new System.Windows.Forms.Button();
            this.btnNuevoActividad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProgramaPresupuestal)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProductoProyecto)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActividadObra)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgProgramaPresupuestal
            // 
            this.dtgProgramaPresupuestal.AllowUserToAddRows = false;
            this.dtgProgramaPresupuestal.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightBlue;
            this.dtgProgramaPresupuestal.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgProgramaPresupuestal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProgramaPresupuestal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.programaPresupuestal,
            this.colidtProgramaPresupuestal,
            this.nombre,
            this.año});
            this.dtgProgramaPresupuestal.Location = new System.Drawing.Point(25, 18);
            this.dtgProgramaPresupuestal.MultiSelect = false;
            this.dtgProgramaPresupuestal.Name = "dtgProgramaPresupuestal";
            this.dtgProgramaPresupuestal.ReadOnly = true;
            this.dtgProgramaPresupuestal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProgramaPresupuestal.Size = new System.Drawing.Size(558, 220);
            this.dtgProgramaPresupuestal.TabIndex = 0;
            this.dtgProgramaPresupuestal.SelectionChanged += new System.EventHandler(this.dtgProgramaPresupuestal_SelectionChanged);
            // 
            // programaPresupuestal
            // 
            this.programaPresupuestal.DataPropertyName = "programaPresupuestal";
            this.programaPresupuestal.HeaderText = "Codigo";
            this.programaPresupuestal.Name = "programaPresupuestal";
            this.programaPresupuestal.ReadOnly = true;
            this.programaPresupuestal.Width = 50;
            // 
            // colidtProgramaPresupuestal
            // 
            this.colidtProgramaPresupuestal.DataPropertyName = "idtProgramaPresupuestal";
            this.colidtProgramaPresupuestal.HeaderText = "idtProgramaPresupuestal";
            this.colidtProgramaPresupuestal.Name = "colidtProgramaPresupuestal";
            this.colidtProgramaPresupuestal.ReadOnly = true;
            this.colidtProgramaPresupuestal.Visible = false;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 400;
            // 
            // año
            // 
            this.año.DataPropertyName = "año";
            this.año.HeaderText = "Año";
            this.año.Name = "año";
            this.año.ReadOnly = true;
            this.año.Width = 50;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevo.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevo.Location = new System.Drawing.Point(57, 270);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 57);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.MintCream;
            this.btnModificar.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnModificar.Location = new System.Drawing.Point(274, 270);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 57);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.MintCream;
            this.btnEliminar.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEliminar.Location = new System.Drawing.Point(481, 270);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(87, 57);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(644, 388);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnModificar);
            this.tabPage1.Controls.Add(this.dtgProgramaPresupuestal);
            this.tabPage1.Controls.Add(this.btnEliminar);
            this.tabPage1.Controls.Add(this.btnNuevo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(636, 362);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Programas Presupuestales";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnModificarProducto);
            this.tabPage2.Controls.Add(this.btnEliminarProducto);
            this.tabPage2.Controls.Add(this.btnNuevoProducto);
            this.tabPage2.Controls.Add(this.dtgProductoProyecto);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(636, 362);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Producto/Proyecto";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtgProductoProyecto
            // 
            this.dtgProductoProyecto.AllowUserToAddRows = false;
            this.dtgProductoProyecto.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightBlue;
            this.dtgProductoProyecto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgProductoProyecto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProductoProyecto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colidtproductoproyecto,
            this.colproductoproyecto,
            this.dataGridViewTextBoxColumn1,
            this.colaño,
            this.idProgramaPresupuestal});
            this.dtgProductoProyecto.Location = new System.Drawing.Point(17, 20);
            this.dtgProductoProyecto.MultiSelect = false;
            this.dtgProductoProyecto.Name = "dtgProductoProyecto";
            this.dtgProductoProyecto.ReadOnly = true;
            this.dtgProductoProyecto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProductoProyecto.Size = new System.Drawing.Size(584, 204);
            this.dtgProductoProyecto.TabIndex = 3;
            this.dtgProductoProyecto.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgProductoProyecto_CellContentClick);
            this.dtgProductoProyecto.SelectionChanged += new System.EventHandler(this.dtgProductoProyecto_SelectionChanged);
            // 
            // colidtproductoproyecto
            // 
            this.colidtproductoproyecto.DataPropertyName = "idtProductoproyecto";
            this.colidtproductoproyecto.HeaderText = "idtProductoProyecto";
            this.colidtproductoproyecto.Name = "colidtproductoproyecto";
            this.colidtproductoproyecto.ReadOnly = true;
            this.colidtproductoproyecto.Visible = false;
            // 
            // colproductoproyecto
            // 
            this.colproductoproyecto.DataPropertyName = "productoproyecto";
            this.colproductoproyecto.HeaderText = "Codigo";
            this.colproductoproyecto.Name = "colproductoproyecto";
            this.colproductoproyecto.ReadOnly = true;
            this.colproductoproyecto.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "nombre";
            this.dataGridViewTextBoxColumn1.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 400;
            // 
            // colaño
            // 
            this.colaño.DataPropertyName = "año";
            this.colaño.HeaderText = "año";
            this.colaño.Name = "colaño";
            this.colaño.ReadOnly = true;
            this.colaño.Width = 50;
            // 
            // idProgramaPresupuestal
            // 
            this.idProgramaPresupuestal.DataPropertyName = "idprogramapresupuestal";
            this.idProgramaPresupuestal.HeaderText = "idProgramaPresupuestal";
            this.idProgramaPresupuestal.Name = "idProgramaPresupuestal";
            this.idProgramaPresupuestal.ReadOnly = true;
            this.idProgramaPresupuestal.Visible = false;
            // 
            // btnModificarProducto
            // 
            this.btnModificarProducto.BackColor = System.Drawing.Color.MintCream;
            this.btnModificarProducto.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarProducto.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnModificarProducto.Location = new System.Drawing.Point(267, 265);
            this.btnModificarProducto.Name = "btnModificarProducto";
            this.btnModificarProducto.Size = new System.Drawing.Size(90, 57);
            this.btnModificarProducto.TabIndex = 5;
            this.btnModificarProducto.Text = "Modificar";
            this.btnModificarProducto.UseVisualStyleBackColor = false;
            this.btnModificarProducto.Click += new System.EventHandler(this.btnModificarProducto_Click);
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.BackColor = System.Drawing.Color.MintCream;
            this.btnEliminarProducto.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarProducto.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEliminarProducto.Location = new System.Drawing.Point(479, 265);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(90, 57);
            this.btnEliminarProducto.TabIndex = 6;
            this.btnEliminarProducto.Text = "Eliminar";
            this.btnEliminarProducto.UseVisualStyleBackColor = false;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);
            // 
            // btnNuevoProducto
            // 
            this.btnNuevoProducto.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevoProducto.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoProducto.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevoProducto.Location = new System.Drawing.Point(55, 265);
            this.btnNuevoProducto.Name = "btnNuevoProducto";
            this.btnNuevoProducto.Size = new System.Drawing.Size(90, 57);
            this.btnNuevoProducto.TabIndex = 4;
            this.btnNuevoProducto.Text = "Nuevo";
            this.btnNuevoProducto.UseVisualStyleBackColor = false;
            this.btnNuevoProducto.Click += new System.EventHandler(this.btnNuevoProducto_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnModificarActividad);
            this.tabPage3.Controls.Add(this.btnEliminarActividad);
            this.tabPage3.Controls.Add(this.btnNuevoActividad);
            this.tabPage3.Controls.Add(this.dtgActividadObra);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(636, 362);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Actividad/Obra";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dtgActividadObra
            // 
            this.dtgActividadObra.AllowUserToAddRows = false;
            this.dtgActividadObra.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightBlue;
            this.dtgActividadObra.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgActividadObra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgActividadObra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtactividadobra,
            this.actividadobra,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.idProductoProyecto});
            this.dtgActividadObra.Location = new System.Drawing.Point(19, 22);
            this.dtgActividadObra.MultiSelect = false;
            this.dtgActividadObra.Name = "dtgActividadObra";
            this.dtgActividadObra.ReadOnly = true;
            this.dtgActividadObra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgActividadObra.Size = new System.Drawing.Size(555, 210);
            this.dtgActividadObra.TabIndex = 7;
            // 
            // idtactividadobra
            // 
            this.idtactividadobra.DataPropertyName = "idtactividadobra";
            this.idtactividadobra.HeaderText = "idtActividadObra";
            this.idtactividadobra.Name = "idtactividadobra";
            this.idtactividadobra.ReadOnly = true;
            this.idtactividadobra.Visible = false;
            // 
            // actividadobra
            // 
            this.actividadobra.DataPropertyName = "actividadobra";
            this.actividadobra.HeaderText = "Codigo";
            this.actividadobra.Name = "actividadobra";
            this.actividadobra.ReadOnly = true;
            this.actividadobra.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "nombre";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 400;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "año";
            this.dataGridViewTextBoxColumn3.HeaderText = "Año";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // idProductoProyecto
            // 
            this.idProductoProyecto.DataPropertyName = "idproductoproyecto";
            this.idProductoProyecto.HeaderText = "idProductoProyecto";
            this.idProductoProyecto.Name = "idProductoProyecto";
            this.idProductoProyecto.ReadOnly = true;
            this.idProductoProyecto.Visible = false;
            // 
            // btnModificarActividad
            // 
            this.btnModificarActividad.BackColor = System.Drawing.Color.MintCream;
            this.btnModificarActividad.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarActividad.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnModificarActividad.Location = new System.Drawing.Point(262, 258);
            this.btnModificarActividad.Name = "btnModificarActividad";
            this.btnModificarActividad.Size = new System.Drawing.Size(90, 57);
            this.btnModificarActividad.TabIndex = 9;
            this.btnModificarActividad.Text = "Modificar";
            this.btnModificarActividad.UseVisualStyleBackColor = false;
            this.btnModificarActividad.Click += new System.EventHandler(this.btnModificarActividad_Click);
            // 
            // btnEliminarActividad
            // 
            this.btnEliminarActividad.BackColor = System.Drawing.Color.MintCream;
            this.btnEliminarActividad.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarActividad.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEliminarActividad.Location = new System.Drawing.Point(474, 258);
            this.btnEliminarActividad.Name = "btnEliminarActividad";
            this.btnEliminarActividad.Size = new System.Drawing.Size(90, 57);
            this.btnEliminarActividad.TabIndex = 10;
            this.btnEliminarActividad.Text = "Eliminar";
            this.btnEliminarActividad.UseVisualStyleBackColor = false;
            this.btnEliminarActividad.Click += new System.EventHandler(this.btnEliminarActividad_Click);
            // 
            // btnNuevoActividad
            // 
            this.btnNuevoActividad.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevoActividad.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoActividad.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevoActividad.Location = new System.Drawing.Point(50, 258);
            this.btnNuevoActividad.Name = "btnNuevoActividad";
            this.btnNuevoActividad.Size = new System.Drawing.Size(90, 57);
            this.btnNuevoActividad.TabIndex = 8;
            this.btnNuevoActividad.Text = "Nuevo";
            this.btnNuevoActividad.UseVisualStyleBackColor = false;
            this.btnNuevoActividad.Click += new System.EventHandler(this.btnNuevoActividad_Click);
            // 
            // frmProgramaPresupuestal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 412);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProgramaPresupuestal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Programas Presupuestales";
            this.Load += new System.EventHandler(this.frmProgramaPresupuestal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProgramaPresupuestal)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProductoProyecto)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgActividadObra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgProgramaPresupuestal;
        private System.Windows.Forms.DataGridViewTextBoxColumn programaPresupuestal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colidtProgramaPresupuestal;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn año;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dtgProductoProyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colidtproductoproyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colproductoproyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colaño;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProgramaPresupuestal;
        private System.Windows.Forms.Button btnModificarProducto;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.Button btnNuevoProducto;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnModificarActividad;
        private System.Windows.Forms.Button btnEliminarActividad;
        private System.Windows.Forms.Button btnNuevoActividad;
        private System.Windows.Forms.DataGridView dtgActividadObra;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtactividadobra;
        private System.Windows.Forms.DataGridViewTextBoxColumn actividadobra;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProductoProyecto;
    }
}