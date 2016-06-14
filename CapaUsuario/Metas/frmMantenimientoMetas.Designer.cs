namespace CapaUsuario.Metas
{
    partial class frmMantenimientoMetas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgListaMetas = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.idtMeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.año = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idGrupoFuncional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idActividadObra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaMetas)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListaMetas
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightBlue;
            this.dtgListaMetas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgListaMetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaMetas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtMeta,
            this.numero,
            this.nombre,
            this.año,
            this.idGrupoFuncional,
            this.idActividadObra});
            this.dtgListaMetas.Location = new System.Drawing.Point(12, 33);
            this.dtgListaMetas.MultiSelect = false;
            this.dtgListaMetas.Name = "dtgListaMetas";
            this.dtgListaMetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaMetas.Size = new System.Drawing.Size(677, 173);
            this.dtgListaMetas.TabIndex = 0;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(524, 235);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(87, 36);
            this.btnEliminar.TabIndex = 21;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(288, 236);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 35);
            this.btnModificar.TabIndex = 20;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(64, 237);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 34);
            this.btnNuevo.TabIndex = 19;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // idtMeta
            // 
            this.idtMeta.DataPropertyName = "idtMeta";
            this.idtMeta.HeaderText = "idtMeta";
            this.idtMeta.Name = "idtMeta";
            this.idtMeta.Visible = false;
            // 
            // numero
            // 
            this.numero.DataPropertyName = "numero";
            this.numero.HeaderText = "Codigo";
            this.numero.Name = "numero";
            this.numero.Width = 50;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.Width = 500;
            // 
            // año
            // 
            this.año.DataPropertyName = "Año";
            this.año.HeaderText = "Año";
            this.año.Name = "año";
            this.año.Width = 50;
            // 
            // idGrupoFuncional
            // 
            this.idGrupoFuncional.DataPropertyName = "idGrupoFuncional";
            this.idGrupoFuncional.HeaderText = "idGrupoFuncional";
            this.idGrupoFuncional.Name = "idGrupoFuncional";
            this.idGrupoFuncional.Visible = false;
            // 
            // idActividadObra
            // 
            this.idActividadObra.DataPropertyName = "idActividadObra";
            this.idActividadObra.HeaderText = "idActividadObra";
            this.idActividadObra.Name = "idActividadObra";
            this.idActividadObra.Visible = false;
            // 
            // frmMantenimientoMetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 283);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dtgListaMetas);
            this.Name = "frmMantenimientoMetas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de metas";
            this.Load += new System.EventHandler(this.frmMantenimientoMetas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaMetas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgListaMetas;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtMeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn año;
        private System.Windows.Forms.DataGridViewTextBoxColumn idGrupoFuncional;
        private System.Windows.Forms.DataGridViewTextBoxColumn idActividadObra;
    }
}