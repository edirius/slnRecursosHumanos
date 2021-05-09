namespace CapaUsuario.ClasificadorMeta
{
    partial class frmSeleccionarConceptos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeleccionarConceptos));
            this.dtgIngresos = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.AccionIngresos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIdTMaestroIngresos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdIngresos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdenIngresos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCodigoMaestroIngresos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDescripcionMaestroIngresos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgAportaciones = new System.Windows.Forms.DataGridView();
            this.dataGridViewButtonColumn3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.AccionEmpleador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdEmpleador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdenEmpleador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.chkTotalAportaciones = new System.Windows.Forms.CheckBox();
            this.chkTotalIngresos = new System.Windows.Forms.CheckBox();
            this.chkVacio = new System.Windows.Forms.CheckBox();
            this.chkIngresos = new System.Windows.Forms.CheckBox();
            this.chkAportaciones = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIngresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAportaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgIngresos
            // 
            this.dtgIngresos.AllowUserToAddRows = false;
            this.dtgIngresos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dtgIngresos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgIngresos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgIngresos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgIngresos.ColumnHeadersHeight = 20;
            this.dtgIngresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnEliminar,
            this.AccionIngresos,
            this.txtIdTMaestroIngresos,
            this.IdIngresos,
            this.OrdenIngresos,
            this.txtCodigoMaestroIngresos,
            this.txtDescripcionMaestroIngresos});
            this.dtgIngresos.Location = new System.Drawing.Point(32, 23);
            this.dtgIngresos.Name = "dtgIngresos";
            this.dtgIngresos.RowHeadersVisible = false;
            this.dtgIngresos.RowHeadersWidth = 25;
            this.dtgIngresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIngresos.Size = new System.Drawing.Size(379, 130);
            this.dtgIngresos.TabIndex = 10;
            this.dtgIngresos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIngresos_CellContentClick);
            this.dtgIngresos.SelectionChanged += new System.EventHandler(this.dtgIngresos_SelectionChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.HeaderText = "";
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnEliminar.Width = 30;
            // 
            // AccionIngresos
            // 
            this.AccionIngresos.HeaderText = "AccionIngresos";
            this.AccionIngresos.Name = "AccionIngresos";
            this.AccionIngresos.ReadOnly = true;
            this.AccionIngresos.Visible = false;
            this.AccionIngresos.Width = 50;
            // 
            // txtIdTMaestroIngresos
            // 
            this.txtIdTMaestroIngresos.HeaderText = "IdTPlantillaPlanilla";
            this.txtIdTMaestroIngresos.Name = "txtIdTMaestroIngresos";
            this.txtIdTMaestroIngresos.ReadOnly = true;
            this.txtIdTMaestroIngresos.Visible = false;
            this.txtIdTMaestroIngresos.Width = 50;
            // 
            // IdIngresos
            // 
            this.IdIngresos.HeaderText = "IdIngresos";
            this.IdIngresos.Name = "IdIngresos";
            this.IdIngresos.ReadOnly = true;
            this.IdIngresos.Visible = false;
            this.IdIngresos.Width = 50;
            // 
            // OrdenIngresos
            // 
            this.OrdenIngresos.HeaderText = "Nro";
            this.OrdenIngresos.Name = "OrdenIngresos";
            this.OrdenIngresos.ReadOnly = true;
            this.OrdenIngresos.Width = 25;
            // 
            // txtCodigoMaestroIngresos
            // 
            this.txtCodigoMaestroIngresos.HeaderText = "CODIGO";
            this.txtCodigoMaestroIngresos.Name = "txtCodigoMaestroIngresos";
            this.txtCodigoMaestroIngresos.ReadOnly = true;
            this.txtCodigoMaestroIngresos.Width = 50;
            // 
            // txtDescripcionMaestroIngresos
            // 
            this.txtDescripcionMaestroIngresos.HeaderText = "DESCRIPCION";
            this.txtDescripcionMaestroIngresos.Name = "txtDescripcionMaestroIngresos";
            this.txtDescripcionMaestroIngresos.ReadOnly = true;
            this.txtDescripcionMaestroIngresos.Width = 250;
            // 
            // dtgAportaciones
            // 
            this.dtgAportaciones.AllowUserToAddRows = false;
            this.dtgAportaciones.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightBlue;
            this.dtgAportaciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgAportaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgAportaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgAportaciones.ColumnHeadersHeight = 20;
            this.dtgAportaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewButtonColumn3,
            this.AccionEmpleador,
            this.dataGridViewTextBoxColumn7,
            this.IdEmpleador,
            this.OrdenEmpleador,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.dtgAportaciones.Location = new System.Drawing.Point(32, 178);
            this.dtgAportaciones.Name = "dtgAportaciones";
            this.dtgAportaciones.RowHeadersVisible = false;
            this.dtgAportaciones.RowHeadersWidth = 25;
            this.dtgAportaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAportaciones.Size = new System.Drawing.Size(379, 130);
            this.dtgAportaciones.TabIndex = 13;
            this.dtgAportaciones.SelectionChanged += new System.EventHandler(this.dtgAportaciones_SelectionChanged);
            // 
            // dataGridViewButtonColumn3
            // 
            this.dataGridViewButtonColumn3.HeaderText = "";
            this.dataGridViewButtonColumn3.Name = "dataGridViewButtonColumn3";
            this.dataGridViewButtonColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn3.Width = 30;
            // 
            // AccionEmpleador
            // 
            this.AccionEmpleador.HeaderText = "AccionEmpleador";
            this.AccionEmpleador.Name = "AccionEmpleador";
            this.AccionEmpleador.ReadOnly = true;
            this.AccionEmpleador.Visible = false;
            this.AccionEmpleador.Width = 50;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "IdTPlantillaPlanilla";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 50;
            // 
            // IdEmpleador
            // 
            this.IdEmpleador.HeaderText = "IdEmpleador";
            this.IdEmpleador.Name = "IdEmpleador";
            this.IdEmpleador.ReadOnly = true;
            this.IdEmpleador.Visible = false;
            this.IdEmpleador.Width = 50;
            // 
            // OrdenEmpleador
            // 
            this.OrdenEmpleador.HeaderText = "Nro";
            this.OrdenEmpleador.Name = "OrdenEmpleador";
            this.OrdenEmpleador.ReadOnly = true;
            this.OrdenEmpleador.Width = 25;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "CODIGO";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 50;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "DESCRIPCION";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 250;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.BackColor = System.Drawing.Color.MintCream;
            this.btnAceptar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAceptar.ImageIndex = 1;
            this.btnAceptar.Location = new System.Drawing.Point(35, 346);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(83, 53);
            this.btnAceptar.TabIndex = 36;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.MintCream;
            this.btnCancelar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelar.ImageIndex = 1;
            this.btnCancelar.Location = new System.Drawing.Point(328, 346);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 53);
            this.btnCancelar.TabIndex = 37;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // chkTotalAportaciones
            // 
            this.chkTotalAportaciones.AutoSize = true;
            this.chkTotalAportaciones.Location = new System.Drawing.Point(417, 178);
            this.chkTotalAportaciones.Name = "chkTotalAportaciones";
            this.chkTotalAportaciones.Size = new System.Drawing.Size(115, 17);
            this.chkTotalAportaciones.TabIndex = 38;
            this.chkTotalAportaciones.Text = "Total Aportaciones";
            this.chkTotalAportaciones.UseVisualStyleBackColor = true;
            this.chkTotalAportaciones.CheckedChanged += new System.EventHandler(this.chkTotalAportaciones_CheckedChanged);
            // 
            // chkTotalIngresos
            // 
            this.chkTotalIngresos.AutoSize = true;
            this.chkTotalIngresos.Location = new System.Drawing.Point(417, 23);
            this.chkTotalIngresos.Name = "chkTotalIngresos";
            this.chkTotalIngresos.Size = new System.Drawing.Size(93, 17);
            this.chkTotalIngresos.TabIndex = 39;
            this.chkTotalIngresos.Text = "Total Ingresos";
            this.chkTotalIngresos.UseVisualStyleBackColor = true;
            this.chkTotalIngresos.CheckedChanged += new System.EventHandler(this.chkTotalIngresos_CheckedChanged);
            // 
            // chkVacio
            // 
            this.chkVacio.AutoSize = true;
            this.chkVacio.Location = new System.Drawing.Point(417, 319);
            this.chkVacio.Name = "chkVacio";
            this.chkVacio.Size = new System.Drawing.Size(53, 17);
            this.chkVacio.TabIndex = 40;
            this.chkVacio.Text = "Vacio";
            this.chkVacio.UseVisualStyleBackColor = true;
            this.chkVacio.CheckedChanged += new System.EventHandler(this.chkVacio_CheckedChanged);
            // 
            // chkIngresos
            // 
            this.chkIngresos.AutoSize = true;
            this.chkIngresos.Location = new System.Drawing.Point(32, 0);
            this.chkIngresos.Name = "chkIngresos";
            this.chkIngresos.Size = new System.Drawing.Size(66, 17);
            this.chkIngresos.TabIndex = 41;
            this.chkIngresos.Text = "Ingresos";
            this.chkIngresos.UseVisualStyleBackColor = true;
            this.chkIngresos.CheckedChanged += new System.EventHandler(this.chkIngresos_CheckedChanged);
            // 
            // chkAportaciones
            // 
            this.chkAportaciones.AutoSize = true;
            this.chkAportaciones.Location = new System.Drawing.Point(35, 160);
            this.chkAportaciones.Name = "chkAportaciones";
            this.chkAportaciones.Size = new System.Drawing.Size(88, 17);
            this.chkAportaciones.TabIndex = 42;
            this.chkAportaciones.Text = "Aportaciones";
            this.chkAportaciones.UseVisualStyleBackColor = true;
            this.chkAportaciones.CheckedChanged += new System.EventHandler(this.chkAportaciones_CheckedChanged);
            // 
            // frmSeleccionarConceptos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 438);
            this.Controls.Add(this.chkAportaciones);
            this.Controls.Add(this.chkIngresos);
            this.Controls.Add(this.chkVacio);
            this.Controls.Add(this.chkTotalIngresos);
            this.Controls.Add(this.chkTotalAportaciones);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtgAportaciones);
            this.Controls.Add(this.dtgIngresos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSeleccionarConceptos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Conceptos";
            this.Load += new System.EventHandler(this.frmSeleccionarConceptos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgIngresos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAportaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dtgIngresos;
        private System.Windows.Forms.DataGridViewButtonColumn btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccionIngresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtIdTMaestroIngresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdIngresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdenIngresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCodigoMaestroIngresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDescripcionMaestroIngresos;
        private System.Windows.Forms.DataGridView dtgAportaciones;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccionEmpleador;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEmpleador;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdenEmpleador;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox chkTotalAportaciones;
        private System.Windows.Forms.CheckBox chkTotalIngresos;
        private System.Windows.Forms.CheckBox chkVacio;
        private System.Windows.Forms.CheckBox chkIngresos;
        private System.Windows.Forms.CheckBox chkAportaciones;
    }
}