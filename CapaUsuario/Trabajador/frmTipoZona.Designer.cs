namespace CapaUsuario.Trabajador
{
    partial class frmTipoZona
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
            this.dtgListaTipoZonas = new System.Windows.Forms.DataGridView();
            this.idttipozona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigosunat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTipoZonas)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListaTipoZonas
            // 
            this.dtgListaTipoZonas.AllowUserToAddRows = false;
            this.dtgListaTipoZonas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtgListaTipoZonas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaTipoZonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaTipoZonas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idttipozona,
            this.codigosunat,
            this.descripcion});
            this.dtgListaTipoZonas.Location = new System.Drawing.Point(12, 12);
            this.dtgListaTipoZonas.MultiSelect = false;
            this.dtgListaTipoZonas.Name = "dtgListaTipoZonas";
            this.dtgListaTipoZonas.ReadOnly = true;
            this.dtgListaTipoZonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaTipoZonas.Size = new System.Drawing.Size(471, 214);
            this.dtgListaTipoZonas.TabIndex = 0;
            this.dtgListaTipoZonas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaTipoZonas_CellContentClick);
            this.dtgListaTipoZonas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgListaTipoZonas_KeyDown);
            // 
            // idttipozona
            // 
            this.idttipozona.DataPropertyName = "idttipozona";
            this.idttipozona.HeaderText = "Codigo";
            this.idttipozona.Name = "idttipozona";
            this.idttipozona.ReadOnly = true;
            this.idttipozona.Width = 50;
            // 
            // codigosunat
            // 
            this.codigosunat.DataPropertyName = "codigosunat";
            this.codigosunat.HeaderText = "Codigo Sunat";
            this.codigosunat.Name = "codigosunat";
            this.codigosunat.ReadOnly = true;
            this.codigosunat.Width = 50;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 300;
            // 
            // frmTipoZona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 239);
            this.Controls.Add(this.dtgListaTipoZonas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTipoZona";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elija el tipo de zona";
            this.Load += new System.EventHandler(this.frmTipoZona_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTipoZonas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgListaTipoZonas;
        private System.Windows.Forms.DataGridViewTextBoxColumn idttipozona;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigosunat;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
    }
}