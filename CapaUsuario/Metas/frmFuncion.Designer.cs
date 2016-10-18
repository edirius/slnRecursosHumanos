namespace CapaUsuario.Metas
{
    partial class frmFuncion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFuncion));
            this.dtgFuncion = new System.Windows.Forms.DataGridView();
            this.idtfuncion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.funcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.año = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnNuevoDivision = new System.Windows.Forms.Button();
            this.btnEliminarDivision = new System.Windows.Forms.Button();
            this.btnModificarDivision = new System.Windows.Forms.Button();
            this.dtgDivisionFuncional = new System.Windows.Forms.DataGridView();
            this.idtdivisionfuncional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.divisionfuncional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFuncion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnNuevoGrupo = new System.Windows.Forms.Button();
            this.btnEliminarGrupo = new System.Windows.Forms.Button();
            this.btnModificarGrupo = new System.Windows.Forms.Button();
            this.dtgGrupoFuncional = new System.Windows.Forms.DataGridView();
            this.idtGrupoFuncional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupoFuncional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDivisionFuncional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFuncion)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDivisionFuncional)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupoFuncional)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgFuncion
            // 
            this.dtgFuncion.AllowUserToAddRows = false;
            this.dtgFuncion.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dtgFuncion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgFuncion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFuncion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtfuncion,
            this.funcion,
            this.nombre,
            this.año});
            this.dtgFuncion.Location = new System.Drawing.Point(12, 15);
            this.dtgFuncion.MultiSelect = false;
            this.dtgFuncion.Name = "dtgFuncion";
            this.dtgFuncion.ReadOnly = true;
            this.dtgFuncion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgFuncion.Size = new System.Drawing.Size(551, 224);
            this.dtgFuncion.TabIndex = 0;
            this.dtgFuncion.SelectionChanged += new System.EventHandler(this.dtgFuncion_SelectionChanged);
            // 
            // idtfuncion
            // 
            this.idtfuncion.DataPropertyName = "idtfuncion";
            this.idtfuncion.HeaderText = "idtfuncion";
            this.idtfuncion.Name = "idtfuncion";
            this.idtfuncion.ReadOnly = true;
            this.idtfuncion.Visible = false;
            // 
            // funcion
            // 
            this.funcion.DataPropertyName = "funcion";
            this.funcion.HeaderText = "Codigo";
            this.funcion.Name = "funcion";
            this.funcion.ReadOnly = true;
            this.funcion.Width = 50;
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
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.MintCream;
            this.btnEliminar.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEliminar.Location = new System.Drawing.Point(462, 275);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 47);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.MintCream;
            this.btnModificar.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnModificar.Location = new System.Drawing.Point(240, 275);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(100, 47);
            this.btnModificar.TabIndex = 11;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevo.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevo.Location = new System.Drawing.Point(18, 275);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 47);
            this.btnNuevo.TabIndex = 10;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(594, 375);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnNuevo);
            this.tabPage1.Controls.Add(this.dtgFuncion);
            this.tabPage1.Controls.Add(this.btnEliminar);
            this.tabPage1.Controls.Add(this.btnModificar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(586, 349);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Funcion";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnNuevoDivision);
            this.tabPage2.Controls.Add(this.btnEliminarDivision);
            this.tabPage2.Controls.Add(this.btnModificarDivision);
            this.tabPage2.Controls.Add(this.dtgDivisionFuncional);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(586, 349);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Division Funcional";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnNuevoDivision
            // 
            this.btnNuevoDivision.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevoDivision.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoDivision.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevoDivision.Location = new System.Drawing.Point(8, 285);
            this.btnNuevoDivision.Name = "btnNuevoDivision";
            this.btnNuevoDivision.Size = new System.Drawing.Size(100, 47);
            this.btnNuevoDivision.TabIndex = 13;
            this.btnNuevoDivision.Text = "Nuevo";
            this.btnNuevoDivision.UseVisualStyleBackColor = false;
            this.btnNuevoDivision.Click += new System.EventHandler(this.btnNuevoDivision_Click);
            // 
            // btnEliminarDivision
            // 
            this.btnEliminarDivision.BackColor = System.Drawing.Color.MintCream;
            this.btnEliminarDivision.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarDivision.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEliminarDivision.Location = new System.Drawing.Point(452, 285);
            this.btnEliminarDivision.Name = "btnEliminarDivision";
            this.btnEliminarDivision.Size = new System.Drawing.Size(100, 47);
            this.btnEliminarDivision.TabIndex = 15;
            this.btnEliminarDivision.Text = "Eliminar";
            this.btnEliminarDivision.UseVisualStyleBackColor = false;
            this.btnEliminarDivision.Click += new System.EventHandler(this.btnEliminarDivision_Click);
            // 
            // btnModificarDivision
            // 
            this.btnModificarDivision.BackColor = System.Drawing.Color.MintCream;
            this.btnModificarDivision.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarDivision.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnModificarDivision.Location = new System.Drawing.Point(230, 285);
            this.btnModificarDivision.Name = "btnModificarDivision";
            this.btnModificarDivision.Size = new System.Drawing.Size(100, 47);
            this.btnModificarDivision.TabIndex = 14;
            this.btnModificarDivision.Text = "Modificar";
            this.btnModificarDivision.UseVisualStyleBackColor = false;
            this.btnModificarDivision.Click += new System.EventHandler(this.btnModificarDivision_Click);
            // 
            // dtgDivisionFuncional
            // 
            this.dtgDivisionFuncional.AllowUserToAddRows = false;
            this.dtgDivisionFuncional.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            this.dtgDivisionFuncional.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgDivisionFuncional.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDivisionFuncional.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtdivisionfuncional,
            this.divisionfuncional,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.idFuncion});
            this.dtgDivisionFuncional.Location = new System.Drawing.Point(6, 6);
            this.dtgDivisionFuncional.MultiSelect = false;
            this.dtgDivisionFuncional.Name = "dtgDivisionFuncional";
            this.dtgDivisionFuncional.ReadOnly = true;
            this.dtgDivisionFuncional.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDivisionFuncional.Size = new System.Drawing.Size(565, 252);
            this.dtgDivisionFuncional.TabIndex = 3;
            this.dtgDivisionFuncional.SelectionChanged += new System.EventHandler(this.dtgDivisionFuncional_SelectionChanged);
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "nombre";
            this.dataGridViewTextBoxColumn1.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 400;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "año";
            this.dataGridViewTextBoxColumn2.HeaderText = "Año";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // idFuncion
            // 
            this.idFuncion.DataPropertyName = "idfuncion";
            this.idFuncion.HeaderText = "idFuncion";
            this.idFuncion.Name = "idFuncion";
            this.idFuncion.ReadOnly = true;
            this.idFuncion.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnNuevoGrupo);
            this.tabPage3.Controls.Add(this.btnEliminarGrupo);
            this.tabPage3.Controls.Add(this.btnModificarGrupo);
            this.tabPage3.Controls.Add(this.dtgGrupoFuncional);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(586, 349);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Grupo Funcional";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnNuevoGrupo
            // 
            this.btnNuevoGrupo.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevoGrupo.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoGrupo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevoGrupo.Location = new System.Drawing.Point(6, 272);
            this.btnNuevoGrupo.Name = "btnNuevoGrupo";
            this.btnNuevoGrupo.Size = new System.Drawing.Size(100, 47);
            this.btnNuevoGrupo.TabIndex = 16;
            this.btnNuevoGrupo.Text = "Nuevo";
            this.btnNuevoGrupo.UseVisualStyleBackColor = false;
            this.btnNuevoGrupo.Click += new System.EventHandler(this.btnNuevoGrupo_Click);
            // 
            // btnEliminarGrupo
            // 
            this.btnEliminarGrupo.BackColor = System.Drawing.Color.MintCream;
            this.btnEliminarGrupo.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarGrupo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEliminarGrupo.Location = new System.Drawing.Point(450, 272);
            this.btnEliminarGrupo.Name = "btnEliminarGrupo";
            this.btnEliminarGrupo.Size = new System.Drawing.Size(100, 47);
            this.btnEliminarGrupo.TabIndex = 18;
            this.btnEliminarGrupo.Text = "Eliminar";
            this.btnEliminarGrupo.UseVisualStyleBackColor = false;
            this.btnEliminarGrupo.Click += new System.EventHandler(this.btnEliminarGrupo_Click);
            // 
            // btnModificarGrupo
            // 
            this.btnModificarGrupo.BackColor = System.Drawing.Color.MintCream;
            this.btnModificarGrupo.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarGrupo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnModificarGrupo.Location = new System.Drawing.Point(228, 272);
            this.btnModificarGrupo.Name = "btnModificarGrupo";
            this.btnModificarGrupo.Size = new System.Drawing.Size(100, 47);
            this.btnModificarGrupo.TabIndex = 17;
            this.btnModificarGrupo.Text = "Modificar";
            this.btnModificarGrupo.UseVisualStyleBackColor = false;
            this.btnModificarGrupo.Click += new System.EventHandler(this.btnModificarGrupo_Click);
            // 
            // dtgGrupoFuncional
            // 
            this.dtgGrupoFuncional.AllowUserToAddRows = false;
            this.dtgGrupoFuncional.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightBlue;
            this.dtgGrupoFuncional.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgGrupoFuncional.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGrupoFuncional.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtGrupoFuncional,
            this.grupoFuncional,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.idDivisionFuncional});
            this.dtgGrupoFuncional.Location = new System.Drawing.Point(6, 6);
            this.dtgGrupoFuncional.Name = "dtgGrupoFuncional";
            this.dtgGrupoFuncional.ReadOnly = true;
            this.dtgGrupoFuncional.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGrupoFuncional.Size = new System.Drawing.Size(563, 233);
            this.dtgGrupoFuncional.TabIndex = 5;
            this.dtgGrupoFuncional.SelectionChanged += new System.EventHandler(this.dtgGrupoFuncional_SelectionChanged);
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
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "nombre";
            this.dataGridViewTextBoxColumn3.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 400;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "año";
            this.dataGridViewTextBoxColumn4.HeaderText = "Año";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 50;
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
            // frmFuncion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 398);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFuncion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Funcion";
            this.Load += new System.EventHandler(this.frmFuncion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgFuncion)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDivisionFuncional)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupoFuncional)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgFuncion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtfuncion;
        private System.Windows.Forms.DataGridViewTextBoxColumn funcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn año;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnNuevoDivision;
        private System.Windows.Forms.Button btnEliminarDivision;
        private System.Windows.Forms.Button btnModificarDivision;
        private System.Windows.Forms.DataGridView dtgDivisionFuncional;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtdivisionfuncional;
        private System.Windows.Forms.DataGridViewTextBoxColumn divisionfuncional;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFuncion;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnNuevoGrupo;
        private System.Windows.Forms.Button btnEliminarGrupo;
        private System.Windows.Forms.Button btnModificarGrupo;
        private System.Windows.Forms.DataGridView dtgGrupoFuncional;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtGrupoFuncional;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupoFuncional;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDivisionFuncional;
    }
}