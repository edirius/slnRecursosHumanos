namespace CapaUsuario.Trabajador
{
    partial class frmNacionalidad
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
            this.dtgNacionalidad = new System.Windows.Forms.DataGridView();
            this.idtNacionalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoSunat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNacionalidad)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgNacionalidad
            // 
            this.dtgNacionalidad.AllowUserToAddRows = false;
            this.dtgNacionalidad.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dtgNacionalidad.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgNacionalidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgNacionalidad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtNacionalidad,
            this.codigoSunat,
            this.descripcion});
            this.dtgNacionalidad.Location = new System.Drawing.Point(12, 12);
            this.dtgNacionalidad.MultiSelect = false;
            this.dtgNacionalidad.Name = "dtgNacionalidad";
            this.dtgNacionalidad.ReadOnly = true;
            this.dtgNacionalidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgNacionalidad.Size = new System.Drawing.Size(370, 263);
            this.dtgNacionalidad.TabIndex = 0;
            this.dtgNacionalidad.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgNacionalidad_CellContentClick);
            this.dtgNacionalidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgNacionalidad_KeyDown);
            // 
            // idtNacionalidad
            // 
            this.idtNacionalidad.DataPropertyName = "idtNacionalidad";
            this.idtNacionalidad.HeaderText = "codigo";
            this.idtNacionalidad.Name = "idtNacionalidad";
            this.idtNacionalidad.ReadOnly = true;
            this.idtNacionalidad.Width = 50;
            // 
            // codigoSunat
            // 
            this.codigoSunat.DataPropertyName = "codigoSunat";
            this.codigoSunat.HeaderText = "Codigo Sunat";
            this.codigoSunat.Name = "codigoSunat";
            this.codigoSunat.ReadOnly = true;
            this.codigoSunat.Width = 50;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 200;
            // 
            // frmNacionalidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 287);
            this.Controls.Add(this.dtgNacionalidad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNacionalidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elija la Nacionalidad";
            this.Load += new System.EventHandler(this.frmNacionalidad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgNacionalidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgNacionalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtNacionalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoSunat;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
    }
}