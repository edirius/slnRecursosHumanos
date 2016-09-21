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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgListaDistritos = new System.Windows.Forms.DataGridView();
            this.toolDistrito = new System.Windows.Forms.ToolTip(this.components);
            this.idtdistrito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoUbigeo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoProvincia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaDistritos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListaDistritos
            // 
            this.dtgListaDistritos.AllowUserToAddRows = false;
            this.dtgListaDistritos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtgListaDistritos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaDistritos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaDistritos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtdistrito,
            this.codigoUbigeo,
            this.descripcion,
            this.codigoProvincia});
            this.dtgListaDistritos.Location = new System.Drawing.Point(12, 12);
            this.dtgListaDistritos.MultiSelect = false;
            this.dtgListaDistritos.Name = "dtgListaDistritos";
            this.dtgListaDistritos.ReadOnly = true;
            this.dtgListaDistritos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaDistritos.Size = new System.Drawing.Size(507, 307);
            this.dtgListaDistritos.TabIndex = 0;
            this.dtgListaDistritos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaDistritos_CellContentClick);
            this.dtgListaDistritos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgListaDistritos_KeyDown);
            this.dtgListaDistritos.MouseEnter += new System.EventHandler(this.dtgListaDistritos_MouseEnter);
            // 
            // idtdistrito
            // 
            this.idtdistrito.DataPropertyName = "idtdistrito";
            this.idtdistrito.HeaderText = "Codigo";
            this.idtdistrito.Name = "idtdistrito";
            this.idtdistrito.ReadOnly = true;
            this.idtdistrito.Width = 50;
            // 
            // codigoUbigeo
            // 
            this.codigoUbigeo.DataPropertyName = "codigoubigeo";
            this.codigoUbigeo.HeaderText = "Ubigeo";
            this.codigoUbigeo.Name = "codigoUbigeo";
            this.codigoUbigeo.ReadOnly = true;
            this.codigoUbigeo.Width = 80;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 300;
            // 
            // codigoProvincia
            // 
            this.codigoProvincia.DataPropertyName = "codigoProvincia";
            this.codigoProvincia.HeaderText = "CodigoProvincia";
            this.codigoProvincia.Name = "codigoProvincia";
            this.codigoProvincia.ReadOnly = true;
            this.codigoProvincia.Visible = false;
            // 
            // frmListaDistritos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 331);
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
        private System.Windows.Forms.ToolTip toolDistrito;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtdistrito;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoUbigeo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoProvincia;
    }
}