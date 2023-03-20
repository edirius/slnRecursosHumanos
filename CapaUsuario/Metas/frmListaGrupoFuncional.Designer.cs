namespace CapaUsuario.Metas
{
    partial class frmListaGrupoFuncional
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaGrupoFuncional));
            this.dtgGrupoFuncional = new System.Windows.Forms.DataGridView();
            this.idtGrupoFuncional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupoFuncional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.año = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDivisionFuncional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboDivisionFuncional = new System.Windows.Forms.ComboBox();
            this.cboFuncion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupoFuncional)).BeginInit();
            this.SuspendLayout();
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
            this.dtgGrupoFuncional.Location = new System.Drawing.Point(12, 95);
            this.dtgGrupoFuncional.Name = "dtgGrupoFuncional";
            this.dtgGrupoFuncional.ReadOnly = true;
            this.dtgGrupoFuncional.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGrupoFuncional.Size = new System.Drawing.Size(550, 150);
            this.dtgGrupoFuncional.TabIndex = 9;
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
            // cboDivisionFuncional
            // 
            this.cboDivisionFuncional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDivisionFuncional.FormattingEnabled = true;
            this.cboDivisionFuncional.Location = new System.Drawing.Point(119, 52);
            this.cboDivisionFuncional.Name = "cboDivisionFuncional";
            this.cboDivisionFuncional.Size = new System.Drawing.Size(356, 21);
            this.cboDivisionFuncional.TabIndex = 8;
            this.cboDivisionFuncional.SelectedIndexChanged += new System.EventHandler(this.cboDivisionFuncional_SelectedIndexChanged);
            // 
            // cboFuncion
            // 
            this.cboFuncion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFuncion.FormattingEnabled = true;
            this.cboFuncion.Location = new System.Drawing.Point(119, 13);
            this.cboFuncion.Name = "cboFuncion";
            this.cboFuncion.Size = new System.Drawing.Size(356, 21);
            this.cboFuncion.TabIndex = 7;
            this.cboFuncion.SelectedIndexChanged += new System.EventHandler(this.cboFuncion_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Division Funcional :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Funcion :";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.MintCream;
            this.btnAceptar.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAceptar.Location = new System.Drawing.Point(87, 265);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(105, 52);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.MintCream;
            this.btnCancelar.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelar.Location = new System.Drawing.Point(370, 265);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(105, 52);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmListaGrupoFuncional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 329);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtgGrupoFuncional);
            this.Controls.Add(this.cboDivisionFuncional);
            this.Controls.Add(this.cboFuncion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListaGrupoFuncional";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Grupos Funcionales";
            this.Load += new System.EventHandler(this.frmListaGrupoFuncional_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupoFuncional)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgGrupoFuncional;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtGrupoFuncional;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupoFuncional;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn año;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDivisionFuncional;
        private System.Windows.Forms.ComboBox cboDivisionFuncional;
        private System.Windows.Forms.ComboBox cboFuncion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}