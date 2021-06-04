namespace CapaUsuario.Asistencia
{
    partial class frmListaDiasFestivos
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
            this.dtgListaDiasFestivos = new System.Windows.Forms.DataGridView();
            this.btnEliminarDiaFestivo = new System.Windows.Forms.Button();
            this.btnModificarDiaFestivo = new System.Windows.Forms.Button();
            this.btnNuevoDiaFestivo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboAño = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaDiasFestivos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListaDiasFestivos
            // 
            this.dtgListaDiasFestivos.AllowUserToAddRows = false;
            this.dtgListaDiasFestivos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.dtgListaDiasFestivos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaDiasFestivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaDiasFestivos.Location = new System.Drawing.Point(12, 49);
            this.dtgListaDiasFestivos.MultiSelect = false;
            this.dtgListaDiasFestivos.Name = "dtgListaDiasFestivos";
            this.dtgListaDiasFestivos.ReadOnly = true;
            this.dtgListaDiasFestivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaDiasFestivos.Size = new System.Drawing.Size(419, 188);
            this.dtgListaDiasFestivos.TabIndex = 0;
            // 
            // btnEliminarDiaFestivo
            // 
            this.btnEliminarDiaFestivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarDiaFestivo.BackColor = System.Drawing.Color.MintCream;
            this.btnEliminarDiaFestivo.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarDiaFestivo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEliminarDiaFestivo.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnEliminarDiaFestivo.Location = new System.Drawing.Point(352, 243);
            this.btnEliminarDiaFestivo.Name = "btnEliminarDiaFestivo";
            this.btnEliminarDiaFestivo.Size = new System.Drawing.Size(79, 65);
            this.btnEliminarDiaFestivo.TabIndex = 78;
            this.btnEliminarDiaFestivo.Text = "&Eliminar Dia Festivo";
            this.btnEliminarDiaFestivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminarDiaFestivo.UseVisualStyleBackColor = false;
            this.btnEliminarDiaFestivo.Click += new System.EventHandler(this.btnEliminarDiaFestivo_Click);
            // 
            // btnModificarDiaFestivo
            // 
            this.btnModificarDiaFestivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificarDiaFestivo.BackColor = System.Drawing.Color.MintCream;
            this.btnModificarDiaFestivo.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificarDiaFestivo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnModificarDiaFestivo.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnModificarDiaFestivo.Location = new System.Drawing.Point(262, 243);
            this.btnModificarDiaFestivo.Name = "btnModificarDiaFestivo";
            this.btnModificarDiaFestivo.Size = new System.Drawing.Size(79, 65);
            this.btnModificarDiaFestivo.TabIndex = 77;
            this.btnModificarDiaFestivo.Text = "&Modificar Dia Festivo";
            this.btnModificarDiaFestivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModificarDiaFestivo.UseVisualStyleBackColor = false;
            this.btnModificarDiaFestivo.Click += new System.EventHandler(this.btnModificarDiaFestivo_Click);
            // 
            // btnNuevoDiaFestivo
            // 
            this.btnNuevoDiaFestivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoDiaFestivo.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevoDiaFestivo.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevoDiaFestivo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevoDiaFestivo.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnNuevoDiaFestivo.Location = new System.Drawing.Point(181, 243);
            this.btnNuevoDiaFestivo.Name = "btnNuevoDiaFestivo";
            this.btnNuevoDiaFestivo.Size = new System.Drawing.Size(75, 65);
            this.btnNuevoDiaFestivo.TabIndex = 76;
            this.btnNuevoDiaFestivo.Text = "&Nuevo Dia Festivo";
            this.btnNuevoDiaFestivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevoDiaFestivo.UseVisualStyleBackColor = false;
            this.btnNuevoDiaFestivo.Click += new System.EventHandler(this.btnNuevoDiaFestivo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 79;
            this.label1.Text = "Año: ";
            // 
            // cboAño
            // 
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(61, 10);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(91, 21);
            this.cboAño.TabIndex = 80;
            this.cboAño.SelectedIndexChanged += new System.EventHandler(this.cboAño_SelectedIndexChanged);
            // 
            // frmListaDiasFestivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 320);
            this.Controls.Add(this.cboAño);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminarDiaFestivo);
            this.Controls.Add(this.btnModificarDiaFestivo);
            this.Controls.Add(this.btnNuevoDiaFestivo);
            this.Controls.Add(this.dtgListaDiasFestivos);
            this.Name = "frmListaDiasFestivos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Dias Festivos";
            this.Load += new System.EventHandler(this.frmListaDiasFestivos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaDiasFestivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgListaDiasFestivos;
        private System.Windows.Forms.Button btnEliminarDiaFestivo;
        private System.Windows.Forms.Button btnModificarDiaFestivo;
        private System.Windows.Forms.Button btnNuevoDiaFestivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAño;
    }
}