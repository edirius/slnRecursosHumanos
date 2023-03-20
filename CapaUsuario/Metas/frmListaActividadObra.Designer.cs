namespace CapaUsuario.Metas
{
    partial class frmListaActividadObra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaActividadObra));
            this.dtgActividadObra = new System.Windows.Forms.DataGridView();
            this.idtactividadobra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actividadobra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Año = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProductoProyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboProductoProyecto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboProgramaPresupuestal = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActividadObra)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgActividadObra
            // 
            this.dtgActividadObra.AllowUserToAddRows = false;
            this.dtgActividadObra.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dtgActividadObra.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgActividadObra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgActividadObra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtactividadobra,
            this.actividadobra,
            this.nombre,
            this.Año,
            this.idProductoProyecto});
            this.dtgActividadObra.Location = new System.Drawing.Point(13, 93);
            this.dtgActividadObra.MultiSelect = false;
            this.dtgActividadObra.Name = "dtgActividadObra";
            this.dtgActividadObra.ReadOnly = true;
            this.dtgActividadObra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgActividadObra.Size = new System.Drawing.Size(555, 143);
            this.dtgActividadObra.TabIndex = 11;
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
            // cboProductoProyecto
            // 
            this.cboProductoProyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductoProyecto.FormattingEnabled = true;
            this.cboProductoProyecto.Location = new System.Drawing.Point(166, 44);
            this.cboProductoProyecto.Name = "cboProductoProyecto";
            this.cboProductoProyecto.Size = new System.Drawing.Size(298, 21);
            this.cboProductoProyecto.TabIndex = 10;
            this.cboProductoProyecto.SelectedIndexChanged += new System.EventHandler(this.cboProductoProyecto_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Producto Proyecto:";
            // 
            // cboProgramaPresupuestal
            // 
            this.cboProgramaPresupuestal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProgramaPresupuestal.FormattingEnabled = true;
            this.cboProgramaPresupuestal.Location = new System.Drawing.Point(166, 10);
            this.cboProgramaPresupuestal.Name = "cboProgramaPresupuestal";
            this.cboProgramaPresupuestal.Size = new System.Drawing.Size(298, 21);
            this.cboProgramaPresupuestal.TabIndex = 8;
            this.cboProgramaPresupuestal.SelectedIndexChanged += new System.EventHandler(this.cboProgramaPresupuestal_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Programa Presupuestal";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.MintCream;
            this.btnAceptar.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAceptar.Location = new System.Drawing.Point(88, 257);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(112, 53);
            this.btnAceptar.TabIndex = 12;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.MintCream;
            this.btnCancelar.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelar.Location = new System.Drawing.Point(401, 256);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(112, 53);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmListaActividadObra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 332);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtgActividadObra);
            this.Controls.Add(this.cboProductoProyecto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboProgramaPresupuestal);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListaActividadObra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Actividad / Obra";
            this.Load += new System.EventHandler(this.frmListaActividadObra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgActividadObra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgActividadObra;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtactividadobra;
        private System.Windows.Forms.DataGridViewTextBoxColumn actividadobra;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Año;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProductoProyecto;
        private System.Windows.Forms.ComboBox cboProductoProyecto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboProgramaPresupuestal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}