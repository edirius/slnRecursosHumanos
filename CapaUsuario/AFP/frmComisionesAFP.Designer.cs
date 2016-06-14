namespace CapaUsuario.AFP
{
    partial class frmComisionesAFP
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComisionesAFP));
            this.dtgComisiones = new System.Windows.Forms.DataGridView();
            this.cboListaAFP = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CodigoComision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AFP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AporteObligatorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComisionFlujo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComisionMixta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrimaSeguros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemuneracionAsegurable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgComisiones)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgComisiones
            // 
            this.dtgComisiones.AllowUserToAddRows = false;
            this.dtgComisiones.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.dtgComisiones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgComisiones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgComisiones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgComisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgComisiones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoComision,
            this.AFP,
            this.Mes,
            this.AporteObligatorio,
            this.ComisionFlujo,
            this.ComisionMixta,
            this.PrimaSeguros,
            this.RemuneracionAsegurable});
            this.dtgComisiones.Location = new System.Drawing.Point(30, 80);
            this.dtgComisiones.Name = "dtgComisiones";
            this.dtgComisiones.ReadOnly = true;
            this.dtgComisiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgComisiones.Size = new System.Drawing.Size(466, 191);
            this.dtgComisiones.TabIndex = 0;
            this.dtgComisiones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgComisiones_CellContentClick);
            // 
            // cboListaAFP
            // 
            this.cboListaAFP.FormattingEnabled = true;
            this.cboListaAFP.Location = new System.Drawing.Point(119, 40);
            this.cboListaAFP.Name = "cboListaAFP";
            this.cboListaAFP.Size = new System.Drawing.Size(237, 21);
            this.cboListaAFP.TabIndex = 1;
            this.cboListaAFP.SelectedIndexChanged += new System.EventHandler(this.cboListaAFP_SelectedIndexChanged);
            this.cboListaAFP.SelectionChangeCommitted += new System.EventHandler(this.cboListaAFP_SelectionChangeCommitted);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(30, 299);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(96, 33);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(215, 298);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(96, 33);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(400, 298);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(96, 33);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(26, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Seleccione la AFP para mostrar sus Comisiones:";
            // 
            // CodigoComision
            // 
            this.CodigoComision.DataPropertyName = "idtComisiones";
            this.CodigoComision.HeaderText = "Codigo";
            this.CodigoComision.Name = "CodigoComision";
            this.CodigoComision.ReadOnly = true;
            this.CodigoComision.ToolTipText = "Codigo autogenerado de la Comision";
            this.CodigoComision.Visible = false;
            this.CodigoComision.Width = 30;
            // 
            // AFP
            // 
            this.AFP.DataPropertyName = "idtAFP";
            this.AFP.HeaderText = "AFP";
            this.AFP.Name = "AFP";
            this.AFP.ReadOnly = true;
            this.AFP.Visible = false;
            // 
            // Mes
            // 
            this.Mes.DataPropertyName = "Mes";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle3.Format = "MM/yyyy";
            this.Mes.DefaultCellStyle = dataGridViewCellStyle3;
            this.Mes.HeaderText = "Mes";
            this.Mes.Name = "Mes";
            this.Mes.ReadOnly = true;
            this.Mes.ToolTipText = "Mes de Devengue";
            this.Mes.Width = 50;
            // 
            // AporteObligatorio
            // 
            this.AporteObligatorio.DataPropertyName = "AporteObligatorio";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.AporteObligatorio.DefaultCellStyle = dataGridViewCellStyle4;
            this.AporteObligatorio.HeaderText = "Aporte Obligatorio";
            this.AporteObligatorio.Name = "AporteObligatorio";
            this.AporteObligatorio.ReadOnly = true;
            this.AporteObligatorio.Width = 60;
            // 
            // ComisionFlujo
            // 
            this.ComisionFlujo.DataPropertyName = "ComisionFlujo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.ComisionFlujo.DefaultCellStyle = dataGridViewCellStyle5;
            this.ComisionFlujo.HeaderText = "Comision Flujo";
            this.ComisionFlujo.Name = "ComisionFlujo";
            this.ComisionFlujo.ReadOnly = true;
            this.ComisionFlujo.Width = 60;
            // 
            // ComisionMixta
            // 
            this.ComisionMixta.DataPropertyName = "ComisionMixta";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.ComisionMixta.DefaultCellStyle = dataGridViewCellStyle6;
            this.ComisionMixta.HeaderText = "Comision Mixta";
            this.ComisionMixta.Name = "ComisionMixta";
            this.ComisionMixta.ReadOnly = true;
            this.ComisionMixta.Width = 60;
            // 
            // PrimaSeguros
            // 
            this.PrimaSeguros.DataPropertyName = "PrimaSeguros";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.PrimaSeguros.DefaultCellStyle = dataGridViewCellStyle7;
            this.PrimaSeguros.HeaderText = "Prima Seguros";
            this.PrimaSeguros.Name = "PrimaSeguros";
            this.PrimaSeguros.ReadOnly = true;
            this.PrimaSeguros.Width = 60;
            // 
            // RemuneracionAsegurable
            // 
            this.RemuneracionAsegurable.DataPropertyName = "RemuneracionAsegurable";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.RemuneracionAsegurable.DefaultCellStyle = dataGridViewCellStyle8;
            this.RemuneracionAsegurable.HeaderText = "Remuneracion Asegurable";
            this.RemuneracionAsegurable.Name = "RemuneracionAsegurable";
            this.RemuneracionAsegurable.ReadOnly = true;
            // 
            // frmComisionesAFP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(512, 343);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cboListaAFP);
            this.Controls.Add(this.dtgComisiones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmComisionesAFP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comisiones AFP";
            this.Load += new System.EventHandler(this.frmComisionesAFP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgComisiones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgComisiones;
        private System.Windows.Forms.ComboBox cboListaAFP;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoComision;
        private System.Windows.Forms.DataGridViewTextBoxColumn AFP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mes;
        private System.Windows.Forms.DataGridViewTextBoxColumn AporteObligatorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComisionFlujo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComisionMixta;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrimaSeguros;
        private System.Windows.Forms.DataGridViewTextBoxColumn RemuneracionAsegurable;
    }
}