namespace CapaUsuario.Trabajador
{
    partial class frmNuevoDatoFijo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevoDatoFijo));
            this.dtgListaConceptos = new System.Windows.Forms.DataGridView();
            this.idtCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipoConcepto = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaConceptos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListaConceptos
            // 
            this.dtgListaConceptos.AllowUserToAddRows = false;
            this.dtgListaConceptos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.dtgListaConceptos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaConceptos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtCargo,
            this.Descripcion});
            this.dtgListaConceptos.Location = new System.Drawing.Point(34, 62);
            this.dtgListaConceptos.MultiSelect = false;
            this.dtgListaConceptos.Name = "dtgListaConceptos";
            this.dtgListaConceptos.ReadOnly = true;
            this.dtgListaConceptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaConceptos.Size = new System.Drawing.Size(477, 170);
            this.dtgListaConceptos.TabIndex = 2;
            // 
            // idtCargo
            // 
            this.idtCargo.DataPropertyName = "idtCargo";
            this.idtCargo.HeaderText = "idtcargo";
            this.idtCargo.Name = "idtCargo";
            this.idtCargo.ReadOnly = true;
            this.idtCargo.Visible = false;
            this.idtCargo.Width = 400;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 400;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tipo Concepto:";
            // 
            // cboTipoConcepto
            // 
            this.cboTipoConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoConcepto.FormattingEnabled = true;
            this.cboTipoConcepto.Items.AddRange(new object[] {
            "INGRESOS",
            "DESCUENTOS",
            "Aportacion Trabajador",
            "Aportacion Empleador"});
            this.cboTipoConcepto.Location = new System.Drawing.Point(118, 18);
            this.cboTipoConcepto.Name = "cboTipoConcepto";
            this.cboTipoConcepto.Size = new System.Drawing.Size(256, 21);
            this.cboTipoConcepto.TabIndex = 4;
            this.cboTipoConcepto.SelectedIndexChanged += new System.EventHandler(this.cboTipoConcepto_SelectedIndexChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.MintCream;
            this.btnAceptar.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAceptar.Location = new System.Drawing.Point(37, 310);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(97, 48);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.MintCream;
            this.btnCancelar.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelar.Location = new System.Drawing.Point(414, 310);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 48);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(365, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Monto:";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(411, 251);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 13;
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // frmNuevoDatoFijo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 370);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cboTipoConcepto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgListaConceptos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNuevoDatoFijo";
            this.Text = "Nuevo Dato Fijo";
            this.Load += new System.EventHandler(this.frmNuevoDatoFijo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaConceptos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgListaConceptos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipoConcepto;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMonto;
    }
}