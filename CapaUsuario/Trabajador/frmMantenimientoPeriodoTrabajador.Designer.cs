﻿namespace CapaUsuario.Trabajador
{
    partial class frmMantenimientoPeriodoTrabajador
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dgvPeriodoTrabajador = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTrabajador = new System.Windows.Forms.TextBox();
            this.btnSeguridadSocial = new System.Windows.Forms.Button();
            this.btnRegimenTrabajador = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodoTrabajador)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.MintCream;
            this.btnSalir.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSalir.ImageKey = "ssss.png";
            this.btnSalir.Location = new System.Drawing.Point(437, 382);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(83, 53);
            this.btnSalir.TabIndex = 33;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.BackColor = System.Drawing.Color.MintCream;
            this.btnModificar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnModificar.ImageKey = "13.png";
            this.btnModificar.Location = new System.Drawing.Point(348, 382);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(83, 53);
            this.btnModificar.TabIndex = 31;
            this.btnModificar.Text = "&Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevo.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevo.ImageIndex = 1;
            this.btnNuevo.Location = new System.Drawing.Point(259, 382);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(83, 53);
            this.btnNuevo.TabIndex = 30;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dgvPeriodoTrabajador
            // 
            this.dgvPeriodoTrabajador.AllowUserToAddRows = false;
            this.dgvPeriodoTrabajador.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dgvPeriodoTrabajador.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPeriodoTrabajador.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPeriodoTrabajador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeriodoTrabajador.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnEliminar,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column4});
            this.dgvPeriodoTrabajador.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvPeriodoTrabajador.Location = new System.Drawing.Point(12, 66);
            this.dgvPeriodoTrabajador.MultiSelect = false;
            this.dgvPeriodoTrabajador.Name = "dgvPeriodoTrabajador";
            this.dgvPeriodoTrabajador.ReadOnly = true;
            this.dgvPeriodoTrabajador.RowHeadersVisible = false;
            this.dgvPeriodoTrabajador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPeriodoTrabajador.Size = new System.Drawing.Size(508, 310);
            this.dgvPeriodoTrabajador.TabIndex = 29;
            this.dgvPeriodoTrabajador.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeriodoTrabajador_CellClick);
            this.dgvPeriodoTrabajador.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeriodoTrabajador_CellContentClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.HeaderText = "";
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ReadOnly = true;
            this.btnEliminar.Width = 25;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "IdTPeriodoTrabajador";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            this.Column1.Width = 20;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Fecha Inicio";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Fecha Fin";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "IdTMotivoFinPeriodo";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            this.Column5.Width = 20;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Motivo Fin Periodo";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 250;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtTrabajador);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(508, 48);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trabajador";
            // 
            // txtTrabajador
            // 
            this.txtTrabajador.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTrabajador.Enabled = false;
            this.txtTrabajador.Location = new System.Drawing.Point(6, 19);
            this.txtTrabajador.Name = "txtTrabajador";
            this.txtTrabajador.Size = new System.Drawing.Size(496, 20);
            this.txtTrabajador.TabIndex = 0;
            // 
            // btnSeguridadSocial
            // 
            this.btnSeguridadSocial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeguridadSocial.BackColor = System.Drawing.Color.MintCream;
            this.btnSeguridadSocial.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnSeguridadSocial.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSeguridadSocial.ImageIndex = 1;
            this.btnSeguridadSocial.Location = new System.Drawing.Point(81, 382);
            this.btnSeguridadSocial.Name = "btnSeguridadSocial";
            this.btnSeguridadSocial.Size = new System.Drawing.Size(83, 53);
            this.btnSeguridadSocial.TabIndex = 35;
            this.btnSeguridadSocial.Text = "&Seguridad Social";
            this.btnSeguridadSocial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSeguridadSocial.UseVisualStyleBackColor = false;
            this.btnSeguridadSocial.Click += new System.EventHandler(this.btnSeguridadSocial_Click);
            // 
            // btnRegimenTrabajador
            // 
            this.btnRegimenTrabajador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegimenTrabajador.BackColor = System.Drawing.Color.MintCream;
            this.btnRegimenTrabajador.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnRegimenTrabajador.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnRegimenTrabajador.ImageIndex = 1;
            this.btnRegimenTrabajador.Location = new System.Drawing.Point(170, 382);
            this.btnRegimenTrabajador.Name = "btnRegimenTrabajador";
            this.btnRegimenTrabajador.Size = new System.Drawing.Size(83, 53);
            this.btnRegimenTrabajador.TabIndex = 34;
            this.btnRegimenTrabajador.Text = "&Regimen Laboral";
            this.btnRegimenTrabajador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRegimenTrabajador.UseVisualStyleBackColor = false;
            this.btnRegimenTrabajador.Click += new System.EventHandler(this.btnRegimenTrabajador_Click);
            // 
            // frmMantenimientoPeriodoTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 447);
            this.Controls.Add(this.btnSeguridadSocial);
            this.Controls.Add(this.btnRegimenTrabajador);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dgvPeriodoTrabajador);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmMantenimientoPeriodoTrabajador";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Periodo Trabajador";
            this.Load += new System.EventHandler(this.frmPeriodoTrabajador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodoTrabajador)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvPeriodoTrabajador;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTrabajador;
        private System.Windows.Forms.Button btnSeguridadSocial;
        private System.Windows.Forms.Button btnRegimenTrabajador;
        private System.Windows.Forms.DataGridViewButtonColumn btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}