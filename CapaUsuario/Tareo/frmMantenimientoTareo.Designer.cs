namespace CapaUsuario.Tareo
{
    partial class frmMantenimientoTareo
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnMeta = new System.Windows.Forms.Button();
            this.cboMeta = new System.Windows.Forms.ComboBox();
            this.dgvTareo = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnDetalleTareo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTareo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnMeta);
            this.groupBox2.Controls.Add(this.cboMeta);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(559, 48);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Meta";
            // 
            // btnMeta
            // 
            this.btnMeta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnMeta.Location = new System.Drawing.Point(489, 19);
            this.btnMeta.Name = "btnMeta";
            this.btnMeta.Size = new System.Drawing.Size(64, 23);
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
            this.cboMeta.Location = new System.Drawing.Point(6, 19);
            this.cboMeta.Name = "cboMeta";
            this.cboMeta.Size = new System.Drawing.Size(477, 21);
            this.cboMeta.TabIndex = 0;
            this.cboMeta.SelectedIndexChanged += new System.EventHandler(this.cboMeta_SelectedIndexChanged);
            // 
            // dgvTareo
            // 
            this.dgvTareo.AllowUserToAddRows = false;
            this.dgvTareo.AllowUserToDeleteRows = false;
            this.dgvTareo.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dgvTareo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTareo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTareo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTareo.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvTareo.Location = new System.Drawing.Point(12, 66);
            this.dgvTareo.MultiSelect = false;
            this.dgvTareo.Name = "dgvTareo";
            this.dgvTareo.ReadOnly = true;
            this.dgvTareo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTareo.Size = new System.Drawing.Size(559, 310);
            this.dgvTareo.TabIndex = 1;
            this.dgvTareo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCronogramaTareo_CellClick);
            this.dgvTareo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCronogramaTareo_CellContentClick);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.MintCream;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSalir.ImageKey = "ssss.png";
            this.btnSalir.Location = new System.Drawing.Point(488, 382);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(83, 53);
            this.btnSalir.TabIndex = 19;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.MintCream;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEliminar.ImageKey = "118.png";
            this.btnEliminar.Location = new System.Drawing.Point(399, 382);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(83, 53);
            this.btnEliminar.TabIndex = 18;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.BackColor = System.Drawing.Color.MintCream;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnModificar.ImageKey = "13.png";
            this.btnModificar.Location = new System.Drawing.Point(310, 382);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(83, 53);
            this.btnModificar.TabIndex = 17;
            this.btnModificar.Text = "&Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevo.ImageIndex = 1;
            this.btnNuevo.Location = new System.Drawing.Point(221, 382);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(83, 53);
            this.btnNuevo.TabIndex = 16;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnDetalleTareo
            // 
            this.btnDetalleTareo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDetalleTareo.BackColor = System.Drawing.Color.MintCream;
            this.btnDetalleTareo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnDetalleTareo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDetalleTareo.ImageIndex = 1;
            this.btnDetalleTareo.Location = new System.Drawing.Point(12, 382);
            this.btnDetalleTareo.Name = "btnDetalleTareo";
            this.btnDetalleTareo.Size = new System.Drawing.Size(114, 53);
            this.btnDetalleTareo.TabIndex = 20;
            this.btnDetalleTareo.Text = "&Detalle Tareo";
            this.btnDetalleTareo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDetalleTareo.UseVisualStyleBackColor = false;
            this.btnDetalleTareo.Click += new System.EventHandler(this.btnDetalleTareo_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.MintCream;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.ImageIndex = 1;
            this.button1.Location = new System.Drawing.Point(132, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 53);
            this.button1.TabIndex = 21;
            this.button1.Text = "&Imprimir";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMantenimientoTareo
            // 
            this.ClientSize = new System.Drawing.Size(583, 447);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDetalleTareo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dgvTareo);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmMantenimientoTareo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimineto de Tareos";
            this.Load += new System.EventHandler(this.frmMantenimientoCronogramaTareo_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTareo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnMeta;
        private System.Windows.Forms.ComboBox cboMeta;
        private System.Windows.Forms.DataGridView dgvTareo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnDetalleTareo;
        private System.Windows.Forms.Button button1;
    }
}