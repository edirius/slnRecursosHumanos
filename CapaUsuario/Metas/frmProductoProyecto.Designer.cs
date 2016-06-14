namespace CapaUsuario.Metas
{
    partial class frmProductoProyecto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cboProgramaPresupuestal = new System.Windows.Forms.ComboBox();
            this.dtgProductoProyecto = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.colidtproductoproyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colproductoproyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colaño = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProgramaPresupuestal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProductoProyecto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Programa Presupuestal";
            // 
            // cboProgramaPresupuestal
            // 
            this.cboProgramaPresupuestal.FormattingEnabled = true;
            this.cboProgramaPresupuestal.Location = new System.Drawing.Point(163, 13);
            this.cboProgramaPresupuestal.Name = "cboProgramaPresupuestal";
            this.cboProgramaPresupuestal.Size = new System.Drawing.Size(230, 21);
            this.cboProgramaPresupuestal.TabIndex = 1;
            this.cboProgramaPresupuestal.SelectedIndexChanged += new System.EventHandler(this.cboProgramaPresupuestal_SelectedIndexChanged);
            // 
            // dtgProductoProyecto
            // 
            this.dtgProductoProyecto.AllowUserToAddRows = false;
            this.dtgProductoProyecto.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            this.dtgProductoProyecto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgProductoProyecto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProductoProyecto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colidtproductoproyecto,
            this.colproductoproyecto,
            this.nombre,
            this.colaño,
            this.idProgramaPresupuestal});
            this.dtgProductoProyecto.Location = new System.Drawing.Point(13, 54);
            this.dtgProductoProyecto.MultiSelect = false;
            this.dtgProductoProyecto.Name = "dtgProductoProyecto";
            this.dtgProductoProyecto.ReadOnly = true;
            this.dtgProductoProyecto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProductoProyecto.Size = new System.Drawing.Size(547, 179);
            this.dtgProductoProyecto.TabIndex = 2;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(473, 259);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(87, 36);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(237, 260);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 35);
            this.btnModificar.TabIndex = 5;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(13, 261);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 34);
            this.btnNuevo.TabIndex = 4;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
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
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 400;
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
            // frmProductoProyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 336);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dtgProductoProyecto);
            this.Controls.Add(this.cboProgramaPresupuestal);
            this.Controls.Add(this.label1);
            this.Name = "frmProductoProyecto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Producto Proyecto";
            this.Load += new System.EventHandler(this.frmProductoProyecto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProductoProyecto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboProgramaPresupuestal;
        private System.Windows.Forms.DataGridView dtgProductoProyecto;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colidtproductoproyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colproductoproyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colaño;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProgramaPresupuestal;
    }
}