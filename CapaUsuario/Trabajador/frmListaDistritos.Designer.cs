namespace CapaUsuario.Trabajador
{
    partial class frmListaDistritos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgListaDistritos = new System.Windows.Forms.DataGridView();
            this.idtdistrito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoUbigeo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaDistritos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListaDistritos
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtgListaDistritos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgListaDistritos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaDistritos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtdistrito,
            this.codigoUbigeo,
            this.descripcion});
            this.dtgListaDistritos.Location = new System.Drawing.Point(12, 12);
            this.dtgListaDistritos.MultiSelect = false;
            this.dtgListaDistritos.Name = "dtgListaDistritos";
            this.dtgListaDistritos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaDistritos.Size = new System.Drawing.Size(507, 253);
            this.dtgListaDistritos.TabIndex = 0;
            this.dtgListaDistritos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgListaDistritos_KeyDown);
            // 
            // idtdistrito
            // 
            this.idtdistrito.DataPropertyName = "idtdistrito";
            this.idtdistrito.HeaderText = "Codigo";
            this.idtdistrito.Name = "idtdistrito";
            this.idtdistrito.Width = 50;
            // 
            // codigoUbigeo
            // 
            this.codigoUbigeo.DataPropertyName = "codigoubigeo";
            this.codigoUbigeo.HeaderText = "Ubigeo";
            this.codigoUbigeo.Name = "codigoUbigeo";
            this.codigoUbigeo.Width = 80;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.Width = 300;
            // 
            // frmListaDistritos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 276);
            this.Controls.Add(this.dtgListaDistritos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListaDistritos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elija un Distrito";
            this.Load += new System.EventHandler(this.frmListaDistritos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaDistritos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgListaDistritos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtdistrito;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoUbigeo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
    }
}