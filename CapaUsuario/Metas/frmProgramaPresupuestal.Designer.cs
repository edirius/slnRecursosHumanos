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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgProgramaPresupuestal = new System.Windows.Forms.DataGridView();
            this.programaPresupuestal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colidtProgramaPresupuestal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.año = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProgramaPresupuestal)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgProgramaPresupuestal
            // 
            this.dtgProgramaPresupuestal.AllowUserToAddRows = false;
            this.dtgProgramaPresupuestal.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            this.dtgProgramaPresupuestal.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgProgramaPresupuestal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProgramaPresupuestal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.programaPresupuestal,
            this.colidtProgramaPresupuestal,
            this.nombre,
            this.año});
            this.dtgProgramaPresupuestal.Location = new System.Drawing.Point(12, 26);
            this.dtgProgramaPresupuestal.MultiSelect = false;
            this.dtgProgramaPresupuestal.Name = "dtgProgramaPresupuestal";
            this.dtgProgramaPresupuestal.ReadOnly = true;
            this.dtgProgramaPresupuestal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProgramaPresupuestal.Size = new System.Drawing.Size(558, 150);
            this.dtgProgramaPresupuestal.TabIndex = 0;
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
            this.btnNuevo.Location = new System.Drawing.Point(13, 206);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 34);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(237, 205);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 35);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(473, 204);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(87, 36);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmProgramaPresupuestal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 273);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dtgProgramaPresupuestal);
            this.Name = "frmProgramaPresupuestal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Programas Presupuestales";
            this.Load += new System.EventHandler(this.frmProgramaPresupuestal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProgramaPresupuestal)).EndInit();
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
    }
}