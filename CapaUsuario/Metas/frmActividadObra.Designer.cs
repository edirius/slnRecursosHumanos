namespace CapaUsuario.Metas
{
    partial class frmActividadObra
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
            this.cboProgramaPresupuestal = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboProductoProyecto = new System.Windows.Forms.ComboBox();
            this.dtgActividadObra = new System.Windows.Forms.DataGridView();
            this.idtactividadobra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actividadobra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Año = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProductoProyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActividadObra)).BeginInit();
            this.SuspendLayout();
            // 
            // cboProgramaPresupuestal
            // 
            this.cboProgramaPresupuestal.FormattingEnabled = true;
            this.cboProgramaPresupuestal.Location = new System.Drawing.Point(166, 13);
            this.cboProgramaPresupuestal.Name = "cboProgramaPresupuestal";
            this.cboProgramaPresupuestal.Size = new System.Drawing.Size(298, 21);
            this.cboProgramaPresupuestal.TabIndex = 3;
            this.cboProgramaPresupuestal.SelectedIndexChanged += new System.EventHandler(this.cboProgramaPresupuestal_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Programa Presupuestal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Producto Proyecto:";
            // 
            // cboProductoProyecto
            // 
            this.cboProductoProyecto.FormattingEnabled = true;
            this.cboProductoProyecto.Location = new System.Drawing.Point(166, 47);
            this.cboProductoProyecto.Name = "cboProductoProyecto";
            this.cboProductoProyecto.Size = new System.Drawing.Size(298, 21);
            this.cboProductoProyecto.TabIndex = 5;
            this.cboProductoProyecto.SelectedIndexChanged += new System.EventHandler(this.cboProductoProyecto_SelectedIndexChanged);
            // 
            // dtgActividadObra
            // 
            this.dtgActividadObra.AllowUserToAddRows = false;
            this.dtgActividadObra.AllowUserToDeleteRows = false;
            this.dtgActividadObra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgActividadObra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtactividadobra,
            this.actividadobra,
            this.nombre,
            this.Año,
            this.idProductoProyecto});
            this.dtgActividadObra.Location = new System.Drawing.Point(13, 96);
            this.dtgActividadObra.Name = "dtgActividadObra";
            this.dtgActividadObra.ReadOnly = true;
            this.dtgActividadObra.Size = new System.Drawing.Size(555, 143);
            this.dtgActividadObra.TabIndex = 6;
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
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 400;
            // 
            // Año
            // 
            this.Año.DataPropertyName = "año";
            this.Año.HeaderText = "Año";
            this.Año.Name = "Año";
            this.Año.ReadOnly = true;
            this.Año.Width = 50;
            // 
            // idProductoProyecto
            // 
            this.idProductoProyecto.DataPropertyName = "idproductoproyecto";
            this.idProductoProyecto.HeaderText = "idProductoProyecto";
            this.idProductoProyecto.Name = "idProductoProyecto";
            this.idProductoProyecto.ReadOnly = true;
            this.idProductoProyecto.Visible = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(473, 269);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(87, 36);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(237, 270);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 35);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(13, 271);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 34);
            this.btnNuevo.TabIndex = 7;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // frmActividadObra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 320);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dtgActividadObra);
            this.Controls.Add(this.cboProductoProyecto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboProgramaPresupuestal);
            this.Controls.Add(this.label1);
            this.Name = "frmActividadObra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actividad / Obra";
            this.Load += new System.EventHandler(this.frmActividadObra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgActividadObra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboProgramaPresupuestal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboProductoProyecto;
        private System.Windows.Forms.DataGridView dtgActividadObra;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtactividadobra;
        private System.Windows.Forms.DataGridViewTextBoxColumn actividadobra;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Año;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProductoProyecto;
    }
}