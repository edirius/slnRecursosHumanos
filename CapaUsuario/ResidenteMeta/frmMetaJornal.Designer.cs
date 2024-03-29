﻿namespace CapaUsuario.ResidenteMeta
{
    partial class frmMetaJornal
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dgvMetaJornal = new System.Windows.Forms.DataGridView();
            this.txtAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIdTMetaJornal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtJornal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mensual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOpcion = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnMeta = new System.Windows.Forms.Button();
            this.cboMeta = new System.Windows.Forms.ComboBox();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.btnAgregarCategoria = new System.Windows.Forms.Button();
            this.btnModificarCategoria = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetaJornal)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.MintCream;
            this.btnSalir.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSalir.ImageKey = "ssss.png";
            this.btnSalir.Location = new System.Drawing.Point(623, 387);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(83, 53);
            this.btnSalir.TabIndex = 30;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevo.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevo.ImageIndex = 1;
            this.btnNuevo.Location = new System.Drawing.Point(534, 387);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(83, 53);
            this.btnNuevo.TabIndex = 28;
            this.btnNuevo.Text = "&Guardar";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dgvMetaJornal
            // 
            this.dgvMetaJornal.AllowUserToAddRows = false;
            this.dgvMetaJornal.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dgvMetaJornal.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMetaJornal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMetaJornal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMetaJornal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtAccion,
            this.txtIdTMetaJornal,
            this.txtCategoria,
            this.txtJornal,
            this.mensual,
            this.colOpcion});
            this.dgvMetaJornal.Location = new System.Drawing.Point(12, 52);
            this.dgvMetaJornal.MultiSelect = false;
            this.dgvMetaJornal.Name = "dgvMetaJornal";
            this.dgvMetaJornal.RowHeadersVisible = false;
            this.dgvMetaJornal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMetaJornal.Size = new System.Drawing.Size(694, 329);
            this.dgvMetaJornal.TabIndex = 27;
            // 
            // txtAccion
            // 
            this.txtAccion.HeaderText = "Accion";
            this.txtAccion.Name = "txtAccion";
            this.txtAccion.ReadOnly = true;
            this.txtAccion.Visible = false;
            this.txtAccion.Width = 20;
            // 
            // txtIdTMetaJornal
            // 
            this.txtIdTMetaJornal.HeaderText = "IdTMetaJornal";
            this.txtIdTMetaJornal.Name = "txtIdTMetaJornal";
            this.txtIdTMetaJornal.ReadOnly = true;
            this.txtIdTMetaJornal.Visible = false;
            this.txtIdTMetaJornal.Width = 20;
            // 
            // txtCategoria
            // 
            this.txtCategoria.HeaderText = "CATEGORIA";
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.ReadOnly = true;
            this.txtCategoria.Width = 350;
            // 
            // txtJornal
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.txtJornal.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtJornal.HeaderText = "JORNAL";
            this.txtJornal.Name = "txtJornal";
            // 
            // mensual
            // 
            this.mensual.DataPropertyName = "mensual";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.mensual.DefaultCellStyle = dataGridViewCellStyle3;
            this.mensual.HeaderText = "MENSUAL";
            this.mensual.Name = "mensual";
            // 
            // colOpcion
            // 
            this.colOpcion.HeaderText = "OPCION";
            this.colOpcion.Items.AddRange(new object[] {
            "Jornal",
            "Mensual"});
            this.colOpcion.Name = "colOpcion";
            this.colOpcion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // btnMeta
            // 
            this.btnMeta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMeta.Font = new System.Drawing.Font("Wide Latin", 9.75F);
            this.btnMeta.Location = new System.Drawing.Point(669, 25);
            this.btnMeta.Name = "btnMeta";
            this.btnMeta.Size = new System.Drawing.Size(37, 23);
            this.btnMeta.TabIndex = 1;
            this.btnMeta.Text = "...";
            this.btnMeta.UseVisualStyleBackColor = true;
            this.btnMeta.Click += new System.EventHandler(this.btnMeta_Click);
            // 
            // cboMeta
            // 
            this.cboMeta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMeta.FormattingEnabled = true;
            this.cboMeta.Location = new System.Drawing.Point(112, 25);
            this.cboMeta.Name = "cboMeta";
            this.cboMeta.Size = new System.Drawing.Size(551, 21);
            this.cboMeta.TabIndex = 0;
            this.cboMeta.SelectedIndexChanged += new System.EventHandler(this.cboMeta_SelectedIndexChanged);
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(12, 25);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(94, 21);
            this.cboAño.TabIndex = 87;
            this.cboAño.SelectedIndexChanged += new System.EventHandler(this.cboAño_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 87;
            this.label1.Text = "Año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 88;
            this.label2.Text = "Meta";
            // 
            // btnCategorias
            // 
            this.btnCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCategorias.BackColor = System.Drawing.Color.MintCream;
            this.btnCategorias.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnCategorias.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCategorias.ImageIndex = 1;
            this.btnCategorias.Location = new System.Drawing.Point(436, 387);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(92, 53);
            this.btnCategorias.TabIndex = 89;
            this.btnCategorias.Text = "&Cargar Categorias";
            this.btnCategorias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCategorias.UseVisualStyleBackColor = false;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // btnAgregarCategoria
            // 
            this.btnAgregarCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarCategoria.BackColor = System.Drawing.Color.MintCream;
            this.btnAgregarCategoria.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarCategoria.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAgregarCategoria.ImageIndex = 1;
            this.btnAgregarCategoria.Location = new System.Drawing.Point(186, 387);
            this.btnAgregarCategoria.Name = "btnAgregarCategoria";
            this.btnAgregarCategoria.Size = new System.Drawing.Size(92, 53);
            this.btnAgregarCategoria.TabIndex = 90;
            this.btnAgregarCategoria.Text = "Agregar Categoria";
            this.btnAgregarCategoria.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgregarCategoria.UseVisualStyleBackColor = false;
            this.btnAgregarCategoria.Click += new System.EventHandler(this.btnAgregarCategoria_Click);
            // 
            // btnModificarCategoria
            // 
            this.btnModificarCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificarCategoria.BackColor = System.Drawing.Color.MintCream;
            this.btnModificarCategoria.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificarCategoria.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnModificarCategoria.ImageIndex = 1;
            this.btnModificarCategoria.Location = new System.Drawing.Point(284, 387);
            this.btnModificarCategoria.Name = "btnModificarCategoria";
            this.btnModificarCategoria.Size = new System.Drawing.Size(92, 53);
            this.btnModificarCategoria.TabIndex = 91;
            this.btnModificarCategoria.Text = "Modificar Categoria";
            this.btnModificarCategoria.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModificarCategoria.UseVisualStyleBackColor = false;
            this.btnModificarCategoria.Click += new System.EventHandler(this.btnModificarCategoria_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.BackColor = System.Drawing.Color.MintCream;
            this.btnExportarExcel.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportarExcel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnExportarExcel.ImageIndex = 1;
            this.btnExportarExcel.Location = new System.Drawing.Point(12, 387);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(92, 53);
            this.btnExportarExcel.TabIndex = 92;
            this.btnExportarExcel.Text = "&Exportar Excel";
            this.btnExportarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // frmMetaJornal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 452);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.btnModificarCategoria);
            this.Controls.Add(this.btnAgregarCategoria);
            this.Controls.Add(this.btnCategorias);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMeta);
            this.Controls.Add(this.cboAño);
            this.Controls.Add(this.cboMeta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dgvMetaJornal);
            this.Name = "frmMetaJornal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meta Jornal";
            this.Load += new System.EventHandler(this.frmMetaJornal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetaJornal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvMetaJornal;
        private System.Windows.Forms.Button btnMeta;
        private System.Windows.Forms.ComboBox cboMeta;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.Button btnAgregarCategoria;
        private System.Windows.Forms.Button btnModificarCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtIdTMetaJornal;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtJornal;
        private System.Windows.Forms.DataGridViewTextBoxColumn mensual;
        private System.Windows.Forms.DataGridViewComboBoxColumn colOpcion;
        private System.Windows.Forms.Button btnExportarExcel;
    }
}