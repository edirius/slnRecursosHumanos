namespace CapaUsuario.Trabajador
{
    partial class frmListaDatosFijos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaDatosFijos));
            this.lblNombreTrabajador = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.dtgListaDatosFijos = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.idt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colidtMaestro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idttrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaDatosFijos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombreTrabajador
            // 
            this.lblNombreTrabajador.BackColor = System.Drawing.Color.LightBlue;
            this.lblNombreTrabajador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNombreTrabajador.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNombreTrabajador.Location = new System.Drawing.Point(0, 0);
            this.lblNombreTrabajador.Name = "lblNombreTrabajador";
            this.lblNombreTrabajador.Size = new System.Drawing.Size(705, 30);
            this.lblNombreTrabajador.TabIndex = 1;
            this.lblNombreTrabajador.Text = "label1";
            this.lblNombreTrabajador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.MintCream;
            this.btnIngresar.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnIngresar.Location = new System.Drawing.Point(69, 249);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(97, 48);
            this.btnIngresar.TabIndex = 9;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // dtgListaDatosFijos
            // 
            this.dtgListaDatosFijos.AllowUserToAddRows = false;
            this.dtgListaDatosFijos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dtgListaDatosFijos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaDatosFijos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaDatosFijos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idt,
            this.colidtMaestro,
            this.idttrabajador,
            this.TipoConcepto,
            this.colCodigo,
            this.colDescripcion,
            this.colMonto});
            this.dtgListaDatosFijos.Location = new System.Drawing.Point(12, 43);
            this.dtgListaDatosFijos.MultiSelect = false;
            this.dtgListaDatosFijos.Name = "dtgListaDatosFijos";
            this.dtgListaDatosFijos.ReadOnly = true;
            this.dtgListaDatosFijos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaDatosFijos.Size = new System.Drawing.Size(625, 170);
            this.dtgListaDatosFijos.TabIndex = 10;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.MintCream;
            this.btnCancelar.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelar.Location = new System.Drawing.Point(540, 249);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 48);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.MintCream;
            this.btnEliminar.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEliminar.Location = new System.Drawing.Point(314, 249);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(97, 48);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // idt
            // 
            this.idt.DataPropertyName = "idtdatosfijosxtrabajador";
            this.idt.HeaderText = "idtcargo";
            this.idt.Name = "idt";
            this.idt.ReadOnly = true;
            this.idt.Visible = false;
            this.idt.Width = 400;
            // 
            // colidtMaestro
            // 
            this.colidtMaestro.DataPropertyName = "idtmaestro";
            this.colidtMaestro.HeaderText = "id Maestro";
            this.colidtMaestro.Name = "colidtMaestro";
            this.colidtMaestro.ReadOnly = true;
            this.colidtMaestro.Visible = false;
            // 
            // idttrabajador
            // 
            this.idttrabajador.DataPropertyName = "idttrabajador";
            this.idttrabajador.HeaderText = "idt trabajador";
            this.idttrabajador.Name = "idttrabajador";
            this.idttrabajador.ReadOnly = true;
            this.idttrabajador.Visible = false;
            // 
            // TipoConcepto
            // 
            this.TipoConcepto.DataPropertyName = "tipoConcepto";
            this.TipoConcepto.HeaderText = "Tipo Concepto";
            this.TipoConcepto.Name = "TipoConcepto";
            this.TipoConcepto.ReadOnly = true;
            this.TipoConcepto.Width = 150;
            // 
            // colCodigo
            // 
            this.colCodigo.DataPropertyName = "codigo";
            this.colCodigo.HeaderText = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Width = 70;
            // 
            // colDescripcion
            // 
            this.colDescripcion.DataPropertyName = "descripcion";
            this.colDescripcion.HeaderText = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 300;
            // 
            // colMonto
            // 
            this.colMonto.DataPropertyName = "Monto";
            this.colMonto.HeaderText = "Monto";
            this.colMonto.Name = "colMonto";
            this.colMonto.ReadOnly = true;
            this.colMonto.Width = 50;
            // 
            // frmListaDatosFijos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 329);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dtgListaDatosFijos);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.lblNombreTrabajador);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListaDatosFijos";
            this.Text = "Lista de datos fijos x trabajador";
            this.Load += new System.EventHandler(this.frmListaDatosFijos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaDatosFijos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNombreTrabajador;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.DataGridView dtgListaDatosFijos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colidtMaestro;
        private System.Windows.Forms.DataGridViewTextBoxColumn idttrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonto;
    }
}