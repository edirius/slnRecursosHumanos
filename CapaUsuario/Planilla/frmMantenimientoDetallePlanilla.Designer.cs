namespace CapaUsuario.Planilla
{
    partial class frmMantenimientoDetallePlanilla
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnImportar = new System.Windows.Forms.Button();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtMeta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvDetallePlanilla = new System.Windows.Forms.DataGridView();
            this.txtIdTDetalleTareo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnProceso = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtNro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIdTTrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtApellidosNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSistemaPensiones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remuneracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiasLaborados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalRemuneracio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecFunc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRegimenLaboral = new System.Windows.Forms.TextBox();
            this.txtFuenteFinanciamiento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAgregarTrabajador = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePlanilla)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImportar
            // 
            this.btnImportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportar.BackColor = System.Drawing.Color.MintCream;
            this.btnImportar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnImportar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnImportar.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnImportar.Location = new System.Drawing.Point(769, 38);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(238, 46);
            this.btnImportar.TabIndex = 91;
            this.btnImportar.Text = "&Listar Trabajadores";
            this.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Visible = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // txtFecha
            // 
            this.txtFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFecha.Enabled = false;
            this.txtFecha.Location = new System.Drawing.Point(617, 12);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(146, 20);
            this.txtFecha.TabIndex = 88;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.MintCream;
            this.btnCancelar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelar.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnCancelar.Location = new System.Drawing.Point(933, 403);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(74, 65);
            this.btnCancelar.TabIndex = 86;
            this.btnCancelar.Text = "&Salir";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.BackColor = System.Drawing.Color.MintCream;
            this.btnAceptar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAceptar.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnAceptar.Location = new System.Drawing.Point(852, 403);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 65);
            this.btnAceptar.TabIndex = 85;
            this.btnAceptar.Text = "&Guardar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtMeta
            // 
            this.txtMeta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMeta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMeta.Enabled = false;
            this.txtMeta.Location = new System.Drawing.Point(135, 38);
            this.txtMeta.Name = "txtMeta";
            this.txtMeta.Size = new System.Drawing.Size(628, 20);
            this.txtMeta.TabIndex = 84;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(568, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 83;
            this.label6.Text = "Fecha :";
            // 
            // txtNumero
            // 
            this.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(416, 12);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(146, 20);
            this.txtNumero.TabIndex = 82;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 81;
            this.label8.Text = "Regimen Laboral :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(360, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 80;
            this.label10.Text = "Numero :";
            // 
            // dgvDetallePlanilla
            // 
            this.dgvDetallePlanilla.AllowUserToAddRows = false;
            this.dgvDetallePlanilla.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dgvDetallePlanilla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetallePlanilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetallePlanilla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetallePlanilla.ColumnHeadersHeight = 35;
            this.dgvDetallePlanilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtIdTDetalleTareo,
            this.txtAccion,
            this.btnProceso,
            this.txtNro,
            this.txtIdTTrabajador,
            this.txtApellidosNombres,
            this.txtSistemaPensiones,
            this.txtDNI,
            this.Remuneracion,
            this.FechaInicio,
            this.DiasLaborados,
            this.TotalRemuneracio,
            this.SecFunc});
            this.dgvDetallePlanilla.Location = new System.Drawing.Point(12, 90);
            this.dgvDetallePlanilla.Name = "dgvDetallePlanilla";
            this.dgvDetallePlanilla.RowHeadersVisible = false;
            this.dgvDetallePlanilla.RowHeadersWidth = 25;
            this.dgvDetallePlanilla.Size = new System.Drawing.Size(1011, 307);
            this.dgvDetallePlanilla.TabIndex = 79;
            this.dgvDetallePlanilla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetallePlanilla_CellContentClick);
            this.dgvDetallePlanilla.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetallePlanilla_CellEndEdit);
            // 
            // txtIdTDetalleTareo
            // 
            this.txtIdTDetalleTareo.HeaderText = "ID";
            this.txtIdTDetalleTareo.Name = "txtIdTDetalleTareo";
            this.txtIdTDetalleTareo.ReadOnly = true;
            this.txtIdTDetalleTareo.Visible = false;
            this.txtIdTDetalleTareo.Width = 30;
            // 
            // txtAccion
            // 
            this.txtAccion.HeaderText = "Accion";
            this.txtAccion.Name = "txtAccion";
            this.txtAccion.Visible = false;
            this.txtAccion.Width = 30;
            // 
            // btnProceso
            // 
            this.btnProceso.HeaderText = "";
            this.btnProceso.Name = "btnProceso";
            this.btnProceso.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnProceso.Width = 30;
            // 
            // txtNro
            // 
            this.txtNro.HeaderText = "NRO";
            this.txtNro.Name = "txtNro";
            this.txtNro.ReadOnly = true;
            this.txtNro.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtNro.Width = 30;
            // 
            // txtIdTTrabajador
            // 
            this.txtIdTTrabajador.HeaderText = "IdTTrabajador";
            this.txtIdTTrabajador.Name = "txtIdTTrabajador";
            this.txtIdTTrabajador.ReadOnly = true;
            this.txtIdTTrabajador.Visible = false;
            this.txtIdTTrabajador.Width = 50;
            // 
            // txtApellidosNombres
            // 
            this.txtApellidosNombres.HeaderText = "APELLIDOS Y NOMBRES";
            this.txtApellidosNombres.Name = "txtApellidosNombres";
            this.txtApellidosNombres.ReadOnly = true;
            this.txtApellidosNombres.Width = 200;
            // 
            // txtSistemaPensiones
            // 
            this.txtSistemaPensiones.HeaderText = "CARGO";
            this.txtSistemaPensiones.Name = "txtSistemaPensiones";
            this.txtSistemaPensiones.ReadOnly = true;
            this.txtSistemaPensiones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txtSistemaPensiones.Width = 150;
            // 
            // txtDNI
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.txtDNI.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtDNI.HeaderText = "DNI";
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.ReadOnly = true;
            this.txtDNI.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtDNI.Width = 60;
            // 
            // Remuneracion
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.NullValue = null;
            this.Remuneracion.DefaultCellStyle = dataGridViewCellStyle4;
            this.Remuneracion.HeaderText = "REMUNER.";
            this.Remuneracion.Name = "Remuneracion";
            this.Remuneracion.ReadOnly = true;
            this.Remuneracion.Width = 50;
            // 
            // FechaInicio
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FechaInicio.DefaultCellStyle = dataGridViewCellStyle5;
            this.FechaInicio.HeaderText = "FEC. INICIO";
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.ReadOnly = true;
            this.FechaInicio.Width = 70;
            // 
            // DiasLaborados
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DiasLaborados.DefaultCellStyle = dataGridViewCellStyle6;
            this.DiasLaborados.HeaderText = "DIAS LABOR.";
            this.DiasLaborados.Name = "DiasLaborados";
            this.DiasLaborados.ReadOnly = true;
            this.DiasLaborados.Width = 40;
            // 
            // TotalRemuneracio
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TotalRemuneracio.DefaultCellStyle = dataGridViewCellStyle7;
            this.TotalRemuneracio.HeaderText = "TOTAL REMUNER.";
            this.TotalRemuneracio.Name = "TotalRemuneracio";
            this.TotalRemuneracio.ReadOnly = true;
            this.TotalRemuneracio.Width = 50;
            // 
            // SecFunc
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SecFunc.DefaultCellStyle = dataGridViewCellStyle8;
            this.SecFunc.HeaderText = "SEC. FUNC.";
            this.SecFunc.Name = "SecFunc";
            this.SecFunc.ReadOnly = true;
            this.SecFunc.Width = 30;
            // 
            // txtRegimenLaboral
            // 
            this.txtRegimenLaboral.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRegimenLaboral.Enabled = false;
            this.txtRegimenLaboral.Location = new System.Drawing.Point(135, 12);
            this.txtRegimenLaboral.Name = "txtRegimenLaboral";
            this.txtRegimenLaboral.Size = new System.Drawing.Size(219, 20);
            this.txtRegimenLaboral.TabIndex = 92;
            // 
            // txtFuenteFinanciamiento
            // 
            this.txtFuenteFinanciamiento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFuenteFinanciamiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFuenteFinanciamiento.Enabled = false;
            this.txtFuenteFinanciamiento.Location = new System.Drawing.Point(135, 64);
            this.txtFuenteFinanciamiento.Name = "txtFuenteFinanciamiento";
            this.txtFuenteFinanciamiento.Size = new System.Drawing.Size(628, 20);
            this.txtFuenteFinanciamiento.TabIndex = 93;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 94;
            this.label1.Text = "Meta :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "Fuente Financiamiento :";
            // 
            // btnAgregarTrabajador
            // 
            this.btnAgregarTrabajador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarTrabajador.BackColor = System.Drawing.Color.MintCream;
            this.btnAgregarTrabajador.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarTrabajador.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAgregarTrabajador.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnAgregarTrabajador.Location = new System.Drawing.Point(763, 403);
            this.btnAgregarTrabajador.Name = "btnAgregarTrabajador";
            this.btnAgregarTrabajador.Size = new System.Drawing.Size(83, 65);
            this.btnAgregarTrabajador.TabIndex = 96;
            this.btnAgregarTrabajador.Text = "&Agregar Trabajador";
            this.btnAgregarTrabajador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgregarTrabajador.UseVisualStyleBackColor = false;
            this.btnAgregarTrabajador.Click += new System.EventHandler(this.btnAgregarTrabajador_Click);
            // 
            // frmMantenimientoDetallePlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 480);
            this.Controls.Add(this.btnAgregarTrabajador);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFuenteFinanciamiento);
            this.Controls.Add(this.txtRegimenLaboral);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtMeta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgvDetallePlanilla);
            this.Name = "frmMantenimientoDetallePlanilla";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Detalle Planilla";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMantenimientoDetallePlanilla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePlanilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtMeta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvDetallePlanilla;
        private System.Windows.Forms.TextBox txtRegimenLaboral;
        private System.Windows.Forms.TextBox txtFuenteFinanciamiento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAgregarTrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtIdTDetalleTareo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAccion;
        private System.Windows.Forms.DataGridViewButtonColumn btnProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtNro;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtIdTTrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtApellidosNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSistemaPensiones;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remuneracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiasLaborados;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalRemuneracio;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecFunc;
    }
}