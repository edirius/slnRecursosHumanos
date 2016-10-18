namespace CapaUsuario.Metas
{
    partial class frmGrupoFuncional
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboFuncion = new System.Windows.Forms.ComboBox();
            this.cboDivisionFuncional = new System.Windows.Forms.ComboBox();
            this.dtgGrupoFuncional = new System.Windows.Forms.DataGridView();
            this.idtGrupoFuncional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupoFuncional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.año = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDivisionFuncional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupoFuncional)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Funcion :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Division Funcional :";
            // 
            // cboFuncion
            // 
            this.cboFuncion.FormattingEnabled = true;
            this.cboFuncion.Location = new System.Drawing.Point(124, 12);
            this.cboFuncion.Name = "cboFuncion";
            this.cboFuncion.Size = new System.Drawing.Size(356, 21);
            this.cboFuncion.TabIndex = 2;
            this.cboFuncion.SelectedIndexChanged += new System.EventHandler(this.cboFuncion_SelectedIndexChanged);
            // 
            // cboDivisionFuncional
            // 
            this.cboDivisionFuncional.FormattingEnabled = true;
            this.cboDivisionFuncional.Location = new System.Drawing.Point(124, 51);
            this.cboDivisionFuncional.Name = "cboDivisionFuncional";
            this.cboDivisionFuncional.Size = new System.Drawing.Size(356, 21);
            this.cboDivisionFuncional.TabIndex = 3;
            this.cboDivisionFuncional.SelectedIndexChanged += new System.EventHandler(this.cboDivisionFuncional_SelectedIndexChanged);
            // 
            // dtgGrupoFuncional
            // 
            this.dtgGrupoFuncional.AllowUserToAddRows = false;
            this.dtgGrupoFuncional.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dtgGrupoFuncional.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgGrupoFuncional.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGrupoFuncional.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtGrupoFuncional,
            this.grupoFuncional,
            this.nombre,
            this.año,
            this.idDivisionFuncional});
            this.dtgGrupoFuncional.Location = new System.Drawing.Point(17, 94);
            this.dtgGrupoFuncional.Name = "dtgGrupoFuncional";
            this.dtgGrupoFuncional.ReadOnly = true;
            this.dtgGrupoFuncional.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGrupoFuncional.Size = new System.Drawing.Size(550, 150);
            this.dtgGrupoFuncional.TabIndex = 4;
            this.dtgGrupoFuncional.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgGrupoFuncional_CellContentClick);
            // 
            // idtGrupoFuncional
            // 
            this.idtGrupoFuncional.DataPropertyName = "idtGrupoFuncional";
            this.idtGrupoFuncional.HeaderText = "idtGrupoFuncional";
            this.idtGrupoFuncional.Name = "idtGrupoFuncional";
            this.idtGrupoFuncional.ReadOnly = true;
            this.idtGrupoFuncional.Visible = false;
            // 
            // grupoFuncional
            // 
            this.grupoFuncional.DataPropertyName = "grupoFuncional";
            this.grupoFuncional.HeaderText = "Codigo";
            this.grupoFuncional.Name = "grupoFuncional";
            this.grupoFuncional.ReadOnly = true;
            this.grupoFuncional.Width = 50;
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
            // idDivisionFuncional
            // 
            this.idDivisionFuncional.DataPropertyName = "idDivisionFuncional";
            this.idDivisionFuncional.HeaderText = "idDivisionFuncional";
            this.idDivisionFuncional.Name = "idDivisionFuncional";
            this.idDivisionFuncional.ReadOnly = true;
            this.idDivisionFuncional.Visible = false;
            this.idDivisionFuncional.Width = 50;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(480, 275);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(87, 36);
            this.btnEliminar.TabIndex = 18;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(244, 276);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 35);
            this.btnModificar.TabIndex = 17;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(20, 277);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 34);
            this.btnNuevo.TabIndex = 16;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // frmGrupoFuncional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 336);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dtgGrupoFuncional);
            this.Controls.Add(this.cboDivisionFuncional);
            this.Controls.Add(this.cboFuncion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmGrupoFuncional";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grupo Funcional";
            this.Load += new System.EventHandler(this.frmGrupoFuncional_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupoFuncional)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboFuncion;
        private System.Windows.Forms.ComboBox cboDivisionFuncional;
        private System.Windows.Forms.DataGridView dtgGrupoFuncional;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtGrupoFuncional;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupoFuncional;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn año;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDivisionFuncional;
    }
}