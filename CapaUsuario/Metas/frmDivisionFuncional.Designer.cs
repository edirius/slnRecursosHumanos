namespace CapaUsuario.Metas
{
    partial class frmDivisionFuncional
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
            this.cboDivisionFuncional = new System.Windows.Forms.ComboBox();
            this.dtgDivisionFuncional = new System.Windows.Forms.DataGridView();
            this.idtdivisionfuncional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.divisionfuncional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.año = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFuncion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDivisionFuncional)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Funcion:";
            // 
            // cboDivisionFuncional
            // 
            this.cboDivisionFuncional.FormattingEnabled = true;
            this.cboDivisionFuncional.Location = new System.Drawing.Point(91, 18);
            this.cboDivisionFuncional.Name = "cboDivisionFuncional";
            this.cboDivisionFuncional.Size = new System.Drawing.Size(262, 21);
            this.cboDivisionFuncional.TabIndex = 1;
            this.cboDivisionFuncional.SelectedIndexChanged += new System.EventHandler(this.cboDivisionFuncional_SelectedIndexChanged);
            // 
            // dtgDivisionFuncional
            // 
            this.dtgDivisionFuncional.AllowUserToAddRows = false;
            this.dtgDivisionFuncional.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dtgDivisionFuncional.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgDivisionFuncional.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDivisionFuncional.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtdivisionfuncional,
            this.divisionfuncional,
            this.nombre,
            this.año,
            this.idFuncion});
            this.dtgDivisionFuncional.Location = new System.Drawing.Point(13, 57);
            this.dtgDivisionFuncional.MultiSelect = false;
            this.dtgDivisionFuncional.Name = "dtgDivisionFuncional";
            this.dtgDivisionFuncional.ReadOnly = true;
            this.dtgDivisionFuncional.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDivisionFuncional.Size = new System.Drawing.Size(547, 157);
            this.dtgDivisionFuncional.TabIndex = 2;
            this.dtgDivisionFuncional.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDivisionFuncional_CellContentClick);
            // 
            // idtdivisionfuncional
            // 
            this.idtdivisionfuncional.DataPropertyName = "idtdivisionfuncional";
            this.idtdivisionfuncional.HeaderText = "idtdivisionfuncional";
            this.idtdivisionfuncional.Name = "idtdivisionfuncional";
            this.idtdivisionfuncional.ReadOnly = true;
            this.idtdivisionfuncional.Visible = false;
            // 
            // divisionfuncional
            // 
            this.divisionfuncional.DataPropertyName = "divisionfuncional";
            this.divisionfuncional.HeaderText = "Codigo";
            this.divisionfuncional.Name = "divisionfuncional";
            this.divisionfuncional.ReadOnly = true;
            this.divisionfuncional.Width = 50;
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
            // idFuncion
            // 
            this.idFuncion.DataPropertyName = "idfuncion";
            this.idFuncion.HeaderText = "idFuncion";
            this.idFuncion.Name = "idFuncion";
            this.idFuncion.ReadOnly = true;
            this.idFuncion.Visible = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(473, 233);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(87, 36);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(237, 234);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 35);
            this.btnModificar.TabIndex = 14;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(13, 235);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 34);
            this.btnNuevo.TabIndex = 13;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // frmDivisionFuncional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 290);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dtgDivisionFuncional);
            this.Controls.Add(this.cboDivisionFuncional);
            this.Controls.Add(this.label1);
            this.Name = "frmDivisionFuncional";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Division Funcional";
            this.Load += new System.EventHandler(this.frmDivisionFuncional_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDivisionFuncional)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDivisionFuncional;
        private System.Windows.Forms.DataGridView dtgDivisionFuncional;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtdivisionfuncional;
        private System.Windows.Forms.DataGridViewTextBoxColumn divisionfuncional;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn año;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFuncion;
    }
}