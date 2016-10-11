namespace CapaDeUsuarioTramite.Oficina
{
    partial class frmOficinaTrabajador
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
            this.cbTrabajadores = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTrabajadores = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.cbOficinas = new System.Windows.Forms.ComboBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrabajadores)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbTrabajadores
            // 
            this.cbTrabajadores.FormattingEnabled = true;
            this.cbTrabajadores.Location = new System.Drawing.Point(212, 34);
            this.cbTrabajadores.Name = "cbTrabajadores";
            this.cbTrabajadores.Size = new System.Drawing.Size(390, 21);
            this.cbTrabajadores.TabIndex = 67;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 65;
            this.label3.Text = "Nombre del trabajador:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "Oficina:";
            // 
            // dgvTrabajadores
            // 
            this.dgvTrabajadores.AllowUserToAddRows = false;
            this.dgvTrabajadores.AllowUserToResizeColumns = false;
            this.dgvTrabajadores.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvTrabajadores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTrabajadores.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvTrabajadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrabajadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvTrabajadores.GridColor = System.Drawing.Color.White;
            this.dgvTrabajadores.Location = new System.Drawing.Point(27, 117);
            this.dgvTrabajadores.Name = "dgvTrabajadores";
            this.dgvTrabajadores.RowHeadersVisible = false;
            this.dgvTrabajadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrabajadores.Size = new System.Drawing.Size(722, 297);
            this.dgvTrabajadores.TabIndex = 63;
            this.dgvTrabajadores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrabajadores_CellClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSalir, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEliminar, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnModificar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnInsertar, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(87, 433);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(612, 48);
            this.tableLayoutPanel1.TabIndex = 62;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(491, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 42);
            this.button1.TabIndex = 47;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(369, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(116, 42);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Limpiar";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(247, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(116, 42);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(125, 3);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(116, 42);
            this.btnModificar.TabIndex = 9;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(3, 3);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(116, 42);
            this.btnInsertar.TabIndex = 8;
            this.btnInsertar.Text = "Guardar";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // cbOficinas
            // 
            this.cbOficinas.FormattingEnabled = true;
            this.cbOficinas.Location = new System.Drawing.Point(212, 69);
            this.cbOficinas.Name = "cbOficinas";
            this.cbOficinas.Size = new System.Drawing.Size(225, 21);
            this.cbOficinas.TabIndex = 68;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id_oficina_trabajador";
            this.Column1.HeaderText = "Codigo";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Nombres";
            this.Column2.HeaderText = "Nombre del Trabajador";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 300;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Oficina";
            this.Column3.HeaderText = "Oficina";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 300;
            // 
            // frmOficinaTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 511);
            this.Controls.Add(this.cbOficinas);
            this.Controls.Add(this.cbTrabajadores);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvTrabajadores);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmOficinaTrabajador";
            this.Text = "frmOficinaTrabajador";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrabajadores)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTrabajadores;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTrabajadores;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.ComboBox cbOficinas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}