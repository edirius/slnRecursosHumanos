namespace CapaUsuario.Tareo
{
    partial class frmMantenimientoDetalleTareo
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
            this.dgvDetalleTareo = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtMeta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAprobacion = new System.Windows.Forms.Button();
            this.txtDesdeHasta = new System.Windows.Forms.TextBox();
            this.txtResidente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImportar = new System.Windows.Forms.Button();
            this.btnNuevoTrabajador = new System.Windows.Forms.Button();
            this.btnBajaTrabajador = new System.Windows.Forms.Button();
            this.btnNuevoTrabajadorRacionamiento = new System.Windows.Forms.Button();
            this.btnModificarTrabajador = new System.Windows.Forms.Button();
            this.btnInsertarNuevaFila = new System.Windows.Forms.Button();
            this.btnEliminarFila = new System.Windows.Forms.Button();
            this.btnNuevoTrabajadorTecnico = new System.Windows.Forms.Button();
            this.txtIdTDetalleTareo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnProceso = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtNro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIdTTrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtApellidosNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboCategoria = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSistemaPensiones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkMarca = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleTareo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetalleTareo
            // 
            this.dgvDetalleTareo.AllowUserToAddRows = false;
            this.dgvDetalleTareo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dgvDetalleTareo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalleTareo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleTareo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetalleTareo.ColumnHeadersHeight = 35;
            this.dgvDetalleTareo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtIdTDetalleTareo,
            this.txtAccion,
            this.btnProceso,
            this.txtNro,
            this.txtIdTTrabajador,
            this.txtApellidosNombres,
            this.txtDNI,
            this.Column2,
            this.Column3,
            this.cboCategoria,
            this.Column4,
            this.colFechaFin,
            this.txtSistemaPensiones,
            this.chkMarca});
            this.dgvDetalleTareo.Location = new System.Drawing.Point(12, 90);
            this.dgvDetalleTareo.Name = "dgvDetalleTareo";
            this.dgvDetalleTareo.RowHeadersVisible = false;
            this.dgvDetalleTareo.RowHeadersWidth = 25;
            this.dgvDetalleTareo.Size = new System.Drawing.Size(1081, 307);
            this.dgvDetalleTareo.TabIndex = 8;
            this.dgvDetalleTareo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleTareo_CellClick);
            this.dgvDetalleTareo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleTareo_CellContentClick);
            this.dgvDetalleTareo.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleTareo_CellEndEdit);
            this.dgvDetalleTareo.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDetalleTareo_EditingControlShowing);
            this.dgvDetalleTareo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvDetalleTareo_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.MintCream;
            this.btnCancelar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelar.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnCancelar.Location = new System.Drawing.Point(1019, 403);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(74, 65);
            this.btnCancelar.TabIndex = 72;
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
            this.btnAceptar.Location = new System.Drawing.Point(938, 403);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 65);
            this.btnAceptar.TabIndex = 71;
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
            this.txtMeta.Location = new System.Drawing.Point(93, 12);
            this.txtMeta.Name = "txtMeta";
            this.txtMeta.Size = new System.Drawing.Size(1000, 20);
            this.txtMeta.TabIndex = 68;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(273, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 67;
            this.label6.Text = "Desde / Hasta :";
            // 
            // txtNumero
            // 
            this.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(93, 38);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(174, 20);
            this.txtNumero.TabIndex = 63;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(50, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 62;
            this.label8.Text = "Meta :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(37, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 61;
            this.label10.Text = "Numero :";
            // 
            // btnAprobacion
            // 
            this.btnAprobacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAprobacion.BackColor = System.Drawing.Color.MintCream;
            this.btnAprobacion.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnAprobacion.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAprobacion.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnAprobacion.Location = new System.Drawing.Point(11, 403);
            this.btnAprobacion.Name = "btnAprobacion";
            this.btnAprobacion.Size = new System.Drawing.Size(153, 65);
            this.btnAprobacion.TabIndex = 73;
            this.btnAprobacion.Text = "&Poner en Aprobacion";
            this.btnAprobacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAprobacion.UseVisualStyleBackColor = false;
            this.btnAprobacion.Visible = false;
            this.btnAprobacion.Click += new System.EventHandler(this.btnAprobacion_Click);
            // 
            // txtDesdeHasta
            // 
            this.txtDesdeHasta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesdeHasta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesdeHasta.Enabled = false;
            this.txtDesdeHasta.Location = new System.Drawing.Point(362, 38);
            this.txtDesdeHasta.Name = "txtDesdeHasta";
            this.txtDesdeHasta.Size = new System.Drawing.Size(487, 20);
            this.txtDesdeHasta.TabIndex = 74;
            // 
            // txtResidente
            // 
            this.txtResidente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResidente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtResidente.Enabled = false;
            this.txtResidente.Location = new System.Drawing.Point(93, 64);
            this.txtResidente.Name = "txtResidente";
            this.txtResidente.Size = new System.Drawing.Size(756, 20);
            this.txtResidente.TabIndex = 76;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 75;
            this.label1.Text = "Responsable :";
            // 
            // btnImportar
            // 
            this.btnImportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportar.BackColor = System.Drawing.Color.MintCream;
            this.btnImportar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnImportar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnImportar.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnImportar.Location = new System.Drawing.Point(855, 38);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(238, 46);
            this.btnImportar.TabIndex = 77;
            this.btnImportar.Text = "&Importar Trabajadores del Tareo Anterior";
            this.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btnNuevoTrabajador
            // 
            this.btnNuevoTrabajador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoTrabajador.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevoTrabajador.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevoTrabajador.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevoTrabajador.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnNuevoTrabajador.Location = new System.Drawing.Point(849, 403);
            this.btnNuevoTrabajador.Name = "btnNuevoTrabajador";
            this.btnNuevoTrabajador.Size = new System.Drawing.Size(83, 65);
            this.btnNuevoTrabajador.TabIndex = 78;
            this.btnNuevoTrabajador.Text = "&Nuevo Trabajador";
            this.btnNuevoTrabajador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevoTrabajador.UseVisualStyleBackColor = false;
            this.btnNuevoTrabajador.Visible = false;
            this.btnNuevoTrabajador.Click += new System.EventHandler(this.btnNuevoTrabajador_Click);
            // 
            // btnBajaTrabajador
            // 
            this.btnBajaTrabajador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBajaTrabajador.BackColor = System.Drawing.Color.MintCream;
            this.btnBajaTrabajador.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnBajaTrabajador.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnBajaTrabajador.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnBajaTrabajador.Location = new System.Drawing.Point(760, 403);
            this.btnBajaTrabajador.Name = "btnBajaTrabajador";
            this.btnBajaTrabajador.Size = new System.Drawing.Size(83, 65);
            this.btnBajaTrabajador.TabIndex = 79;
            this.btnBajaTrabajador.Text = "&Dar Baja a Trabajador";
            this.btnBajaTrabajador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBajaTrabajador.UseVisualStyleBackColor = false;
            this.btnBajaTrabajador.Click += new System.EventHandler(this.btnBajaTrabajador_Click);
            // 
            // btnNuevoTrabajadorRacionamiento
            // 
            this.btnNuevoTrabajadorRacionamiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoTrabajadorRacionamiento.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevoTrabajadorRacionamiento.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevoTrabajadorRacionamiento.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevoTrabajadorRacionamiento.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnNuevoTrabajadorRacionamiento.Location = new System.Drawing.Point(849, 403);
            this.btnNuevoTrabajadorRacionamiento.Name = "btnNuevoTrabajadorRacionamiento";
            this.btnNuevoTrabajadorRacionamiento.Size = new System.Drawing.Size(83, 65);
            this.btnNuevoTrabajadorRacionamiento.TabIndex = 80;
            this.btnNuevoTrabajadorRacionamiento.Text = "Nuevo Trabajador Racionamiento";
            this.btnNuevoTrabajadorRacionamiento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevoTrabajadorRacionamiento.UseVisualStyleBackColor = false;
            this.btnNuevoTrabajadorRacionamiento.Visible = false;
            this.btnNuevoTrabajadorRacionamiento.Click += new System.EventHandler(this.btnNuevoTrabajadorRacionamiento_Click);
            // 
            // btnModificarTrabajador
            // 
            this.btnModificarTrabajador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificarTrabajador.BackColor = System.Drawing.Color.MintCream;
            this.btnModificarTrabajador.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificarTrabajador.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnModificarTrabajador.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnModificarTrabajador.Location = new System.Drawing.Point(671, 403);
            this.btnModificarTrabajador.Name = "btnModificarTrabajador";
            this.btnModificarTrabajador.Size = new System.Drawing.Size(83, 65);
            this.btnModificarTrabajador.TabIndex = 81;
            this.btnModificarTrabajador.Text = "&Modificar Trabajador";
            this.btnModificarTrabajador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModificarTrabajador.UseVisualStyleBackColor = false;
            this.btnModificarTrabajador.Click += new System.EventHandler(this.btnModificarTrabajador_Click);
            // 
            // btnInsertarNuevaFila
            // 
            this.btnInsertarNuevaFila.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsertarNuevaFila.BackColor = System.Drawing.Color.MintCream;
            this.btnInsertarNuevaFila.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnInsertarNuevaFila.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnInsertarNuevaFila.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnInsertarNuevaFila.Location = new System.Drawing.Point(389, 403);
            this.btnInsertarNuevaFila.Name = "btnInsertarNuevaFila";
            this.btnInsertarNuevaFila.Size = new System.Drawing.Size(83, 65);
            this.btnInsertarNuevaFila.TabIndex = 82;
            this.btnInsertarNuevaFila.Text = "Insertar Nueva Fila";
            this.btnInsertarNuevaFila.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnInsertarNuevaFila.UseVisualStyleBackColor = false;
            this.btnInsertarNuevaFila.Click += new System.EventHandler(this.btnInsertarNuevaFila_Click);
            // 
            // btnEliminarFila
            // 
            this.btnEliminarFila.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarFila.BackColor = System.Drawing.Color.MintCream;
            this.btnEliminarFila.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarFila.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnEliminarFila.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnEliminarFila.Location = new System.Drawing.Point(488, 403);
            this.btnEliminarFila.Name = "btnEliminarFila";
            this.btnEliminarFila.Size = new System.Drawing.Size(83, 65);
            this.btnEliminarFila.TabIndex = 83;
            this.btnEliminarFila.Text = "Eliminar Fila";
            this.btnEliminarFila.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminarFila.UseVisualStyleBackColor = false;
            this.btnEliminarFila.Click += new System.EventHandler(this.btnEliminarFila_Click);
            // 
            // btnNuevoTrabajadorTecnico
            // 
            this.btnNuevoTrabajadorTecnico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoTrabajadorTecnico.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevoTrabajadorTecnico.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevoTrabajadorTecnico.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevoTrabajadorTecnico.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnNuevoTrabajadorTecnico.Location = new System.Drawing.Point(849, 403);
            this.btnNuevoTrabajadorTecnico.Name = "btnNuevoTrabajadorTecnico";
            this.btnNuevoTrabajadorTecnico.Size = new System.Drawing.Size(83, 65);
            this.btnNuevoTrabajadorTecnico.TabIndex = 84;
            this.btnNuevoTrabajadorTecnico.Text = "Nuevo Trabajador Tecnico";
            this.btnNuevoTrabajadorTecnico.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevoTrabajadorTecnico.UseVisualStyleBackColor = false;
            this.btnNuevoTrabajadorTecnico.Click += new System.EventHandler(this.btnNuevoTrabajadorTecnico_Click);
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
            this.txtApellidosNombres.Width = 275;
            // 
            // txtDNI
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.txtDNI.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtDNI.HeaderText = "DNI";
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtDNI.Width = 75;
            // 
            // Column2
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column2.HeaderText = "Sexo";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 30;
            // 
            // Column3
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column3.HeaderText = "CATEGORIA";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 170;
            // 
            // cboCategoria
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cboCategoria.DefaultCellStyle = dataGridViewCellStyle6;
            this.cboCategoria.HeaderText = "CATEGORIA";
            this.cboCategoria.Items.AddRange(new object[] {
            "MAESTRO DE OBRA",
            "OPERARIO",
            "OFICIAL",
            "PEON",
            "ALMACENERO",
            "GUARDIAN"});
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Width = 170;
            // 
            // Column4
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column4.HeaderText = "Fecha Inicio";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 75;
            // 
            // colFechaFin
            // 
            this.colFechaFin.HeaderText = "Fecha Fin";
            this.colFechaFin.Name = "colFechaFin";
            this.colFechaFin.ReadOnly = true;
            this.colFechaFin.Width = 75;
            // 
            // txtSistemaPensiones
            // 
            this.txtSistemaPensiones.HeaderText = "SIS PENSIONES";
            this.txtSistemaPensiones.Name = "txtSistemaPensiones";
            this.txtSistemaPensiones.ReadOnly = true;
            this.txtSistemaPensiones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // chkMarca
            // 
            this.chkMarca.HeaderText = "Marcar Todo";
            this.chkMarca.Name = "chkMarca";
            this.chkMarca.Width = 45;
            // 
            // frmMantenimientoDetalleTareo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 480);
            this.Controls.Add(this.btnNuevoTrabajadorTecnico);
            this.Controls.Add(this.btnEliminarFila);
            this.Controls.Add(this.btnInsertarNuevaFila);
            this.Controls.Add(this.btnModificarTrabajador);
            this.Controls.Add(this.btnNuevoTrabajadorRacionamiento);
            this.Controls.Add(this.btnBajaTrabajador);
            this.Controls.Add(this.btnNuevoTrabajador);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.txtResidente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDesdeHasta);
            this.Controls.Add(this.btnAprobacion);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtMeta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgvDetalleTareo);
            this.Name = "frmMantenimientoDetalleTareo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle Tareo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMantenimientoDetalleTareo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleTareo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDetalleTareo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtMeta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAprobacion;
        private System.Windows.Forms.TextBox txtDesdeHasta;
        private System.Windows.Forms.TextBox txtResidente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Button btnNuevoTrabajador;
        private System.Windows.Forms.Button btnBajaTrabajador;
        private System.Windows.Forms.Button btnNuevoTrabajadorRacionamiento;
        private System.Windows.Forms.Button btnModificarTrabajador;
        private System.Windows.Forms.Button btnInsertarNuevaFila;
        private System.Windows.Forms.Button btnEliminarFila;
        private System.Windows.Forms.Button btnNuevoTrabajadorTecnico;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtIdTDetalleTareo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAccion;
        private System.Windows.Forms.DataGridViewButtonColumn btnProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtNro;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtIdTTrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtApellidosNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewComboBoxColumn cboCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSistemaPensiones;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkMarca;
    }
}