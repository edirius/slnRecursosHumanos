namespace CapaUsuario.Reportes
{
    partial class frmDeclaracionJurada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeclaracionJurada));
            this.dgvDeclaracionJurada = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.dgvCabeza = new System.Windows.Forms.DataGridView();
            this.dgvCuerpo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeclaracionJurada)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCabeza)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuerpo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDeclaracionJurada
            // 
            this.dgvDeclaracionJurada.AllowUserToAddRows = false;
            this.dgvDeclaracionJurada.AllowUserToDeleteRows = false;
            this.dgvDeclaracionJurada.AllowUserToResizeColumns = false;
            this.dgvDeclaracionJurada.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dgvDeclaracionJurada.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDeclaracionJurada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDeclaracionJurada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeclaracionJurada.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvDeclaracionJurada.Location = new System.Drawing.Point(12, 73);
            this.dgvDeclaracionJurada.MultiSelect = false;
            this.dgvDeclaracionJurada.Name = "dgvDeclaracionJurada";
            this.dgvDeclaracionJurada.ReadOnly = true;
            this.dgvDeclaracionJurada.RowHeadersVisible = false;
            this.dgvDeclaracionJurada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeclaracionJurada.Size = new System.Drawing.Size(811, 408);
            this.dgvDeclaracionJurada.TabIndex = 99;
            this.dgvDeclaracionJurada.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeclaracionJurada_CellClick);
            this.dgvDeclaracionJurada.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeclaracionJurada_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.cboAño);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 55);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar por:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(221, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(72, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cboAño
            // 
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(69, 19);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(146, 21);
            this.cboAño.TabIndex = 3;
            this.cboAño.SelectedValueChanged += new System.EventHandler(this.cboAño_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Año:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.BackColor = System.Drawing.Color.MintCream;
            this.btnImprimir.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnImprimir.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnImprimir.Location = new System.Drawing.Point(12, 497);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 65);
            this.btnImprimir.TabIndex = 101;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // dgvCabeza
            // 
            this.dgvCabeza.AllowUserToAddRows = false;
            this.dgvCabeza.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dgvCabeza.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCabeza.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCabeza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCabeza.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvCabeza.Location = new System.Drawing.Point(128, 519);
            this.dgvCabeza.MultiSelect = false;
            this.dgvCabeza.Name = "dgvCabeza";
            this.dgvCabeza.ReadOnly = true;
            this.dgvCabeza.RowHeadersVisible = false;
            this.dgvCabeza.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCabeza.Size = new System.Drawing.Size(72, 24);
            this.dgvCabeza.TabIndex = 102;
            this.dgvCabeza.Visible = false;
            // 
            // dgvCuerpo
            // 
            this.dgvCuerpo.AllowUserToAddRows = false;
            this.dgvCuerpo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dgvCuerpo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCuerpo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCuerpo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuerpo.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvCuerpo.Location = new System.Drawing.Point(206, 519);
            this.dgvCuerpo.MultiSelect = false;
            this.dgvCuerpo.Name = "dgvCuerpo";
            this.dgvCuerpo.ReadOnly = true;
            this.dgvCuerpo.RowHeadersVisible = false;
            this.dgvCuerpo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCuerpo.Size = new System.Drawing.Size(72, 24);
            this.dgvCuerpo.TabIndex = 103;
            this.dgvCuerpo.Visible = false;
            // 
            // frmDeclaracionJurada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 608);
            this.Controls.Add(this.dgvCuerpo);
            this.Controls.Add(this.dgvCabeza);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvDeclaracionJurada);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDeclaracionJurada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Declaracion Jurada a Contraloria";
            this.Load += new System.EventHandler(this.frmDeclaracionJurada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeclaracionJurada)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCabeza)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuerpo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDeclaracionJurada;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.DataGridView dgvCabeza;
        private System.Windows.Forms.DataGridView dgvCuerpo;
    }
}