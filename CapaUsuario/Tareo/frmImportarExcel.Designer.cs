namespace CapaUsuario.Tareo
{
    partial class frmImportarExcel
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtComienzoFila = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFinFila = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtColumnaNombres = new System.Windows.Forms.TextBox();
            this.txtColumnaDNI = new System.Windows.Forms.TextBox();
            this.txtColumnaDias = new System.Windows.Forms.TextBox();
            this.txtColumnaCategoria = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgDatos = new System.Windows.Forms.DataGridView();
            this.colDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidopaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidomaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImportarExcel = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHojaExcel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboTipoOrden = new System.Windows.Forms.ComboBox();
            this.btnValidar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(21, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fin Fila Datos:";
            // 
            // txtComienzoFila
            // 
            this.txtComienzoFila.Location = new System.Drawing.Point(153, 23);
            this.txtComienzoFila.Name = "txtComienzoFila";
            this.txtComienzoFila.Size = new System.Drawing.Size(100, 20);
            this.txtComienzoFila.TabIndex = 1;
            this.txtComienzoFila.Text = "11";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(21, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Comienzo Fila Datos:";
            // 
            // txtFinFila
            // 
            this.txtFinFila.Location = new System.Drawing.Point(153, 64);
            this.txtFinFila.Name = "txtFinFila";
            this.txtFinFila.Size = new System.Drawing.Size(100, 20);
            this.txtFinFila.TabIndex = 3;
            this.txtFinFila.Text = "12";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(338, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Columna Nombres:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(338, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Columna DNI:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(338, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Columna Dias:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Location = new System.Drawing.Point(338, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Columna Categoria:";
            // 
            // txtColumnaNombres
            // 
            this.txtColumnaNombres.Location = new System.Drawing.Point(486, 27);
            this.txtColumnaNombres.Name = "txtColumnaNombres";
            this.txtColumnaNombres.Size = new System.Drawing.Size(100, 20);
            this.txtColumnaNombres.TabIndex = 8;
            this.txtColumnaNombres.Text = "B";
            // 
            // txtColumnaDNI
            // 
            this.txtColumnaDNI.Location = new System.Drawing.Point(486, 64);
            this.txtColumnaDNI.Name = "txtColumnaDNI";
            this.txtColumnaDNI.Size = new System.Drawing.Size(100, 20);
            this.txtColumnaDNI.TabIndex = 9;
            this.txtColumnaDNI.Text = "E";
            // 
            // txtColumnaDias
            // 
            this.txtColumnaDias.Location = new System.Drawing.Point(486, 106);
            this.txtColumnaDias.Name = "txtColumnaDias";
            this.txtColumnaDias.Size = new System.Drawing.Size(100, 20);
            this.txtColumnaDias.TabIndex = 10;
            this.txtColumnaDias.Text = "AO";
            // 
            // txtColumnaCategoria
            // 
            this.txtColumnaCategoria.Location = new System.Drawing.Point(486, 148);
            this.txtColumnaCategoria.Name = "txtColumnaCategoria";
            this.txtColumnaCategoria.Size = new System.Drawing.Size(100, 20);
            this.txtColumnaCategoria.TabIndex = 11;
            this.txtColumnaCategoria.Text = "H";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgDatos);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox1.Location = new System.Drawing.Point(24, 203);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(863, 230);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // dtgDatos
            // 
            this.dtgDatos.AllowUserToAddRows = false;
            this.dtgDatos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Honeydew;
            this.dtgDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDNI,
            this.colNombres,
            this.colApellidopaterno,
            this.colApellidomaterno,
            this.colCargo,
            this.colDias});
            this.dtgDatos.Location = new System.Drawing.Point(6, 19);
            this.dtgDatos.Name = "dtgDatos";
            this.dtgDatos.ReadOnly = true;
            this.dtgDatos.Size = new System.Drawing.Size(832, 194);
            this.dtgDatos.TabIndex = 0;
            // 
            // colDNI
            // 
            this.colDNI.DataPropertyName = "DNI";
            this.colDNI.HeaderText = "DNI";
            this.colDNI.Name = "colDNI";
            this.colDNI.ReadOnly = true;
            // 
            // colNombres
            // 
            this.colNombres.DataPropertyName = "Nombres";
            this.colNombres.HeaderText = "Nombres";
            this.colNombres.Name = "colNombres";
            this.colNombres.ReadOnly = true;
            this.colNombres.Width = 150;
            // 
            // colApellidopaterno
            // 
            this.colApellidopaterno.DataPropertyName = "Apellidopaterno";
            this.colApellidopaterno.HeaderText = "Apellido Paterno";
            this.colApellidopaterno.Name = "colApellidopaterno";
            this.colApellidopaterno.ReadOnly = true;
            this.colApellidopaterno.Width = 150;
            // 
            // colApellidomaterno
            // 
            this.colApellidomaterno.DataPropertyName = "Apellidomaterno";
            this.colApellidomaterno.HeaderText = "Apellido Materno";
            this.colApellidomaterno.Name = "colApellidomaterno";
            this.colApellidomaterno.ReadOnly = true;
            this.colApellidomaterno.Width = 150;
            // 
            // colCargo
            // 
            this.colCargo.DataPropertyName = "Cargo";
            this.colCargo.HeaderText = "Cargo";
            this.colCargo.Name = "colCargo";
            this.colCargo.ReadOnly = true;
            this.colCargo.Width = 150;
            // 
            // colDias
            // 
            this.colDias.DataPropertyName = "Dias";
            this.colDias.HeaderText = "Dias";
            this.colDias.Name = "colDias";
            this.colDias.ReadOnly = true;
            this.colDias.Width = 50;
            // 
            // btnImportarExcel
            // 
            this.btnImportarExcel.BackColor = System.Drawing.Color.Azure;
            this.btnImportarExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportarExcel.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnImportarExcel.Location = new System.Drawing.Point(687, 24);
            this.btnImportarExcel.Name = "btnImportarExcel";
            this.btnImportarExcel.Size = new System.Drawing.Size(116, 37);
            this.btnImportarExcel.TabIndex = 13;
            this.btnImportarExcel.Text = "Importar Excel";
            this.btnImportarExcel.UseVisualStyleBackColor = false;
            this.btnImportarExcel.Click += new System.EventHandler(this.btnImportarExcel_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.BackColor = System.Drawing.Color.Azure;
            this.btnImportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportar.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnImportar.Location = new System.Drawing.Point(687, 113);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(116, 37);
            this.btnImportar.TabIndex = 14;
            this.btnImportar.Text = "Importar a la BD";
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Location = new System.Drawing.Point(21, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Nombre Hoja:";
            // 
            // txtHojaExcel
            // 
            this.txtHojaExcel.Location = new System.Drawing.Point(153, 106);
            this.txtHojaExcel.Name = "txtHojaExcel";
            this.txtHojaExcel.Size = new System.Drawing.Size(100, 20);
            this.txtHojaExcel.TabIndex = 16;
            this.txtHojaExcel.Text = "Tareo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkBlue;
            this.label8.Location = new System.Drawing.Point(26, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Tipo Orden:";
            // 
            // cboTipoOrden
            // 
            this.cboTipoOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoOrden.FormattingEnabled = true;
            this.cboTipoOrden.Location = new System.Drawing.Point(153, 155);
            this.cboTipoOrden.Name = "cboTipoOrden";
            this.cboTipoOrden.Size = new System.Drawing.Size(121, 21);
            this.cboTipoOrden.TabIndex = 18;
            // 
            // btnValidar
            // 
            this.btnValidar.BackColor = System.Drawing.Color.Azure;
            this.btnValidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidar.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnValidar.Location = new System.Drawing.Point(687, 70);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(116, 37);
            this.btnValidar.TabIndex = 19;
            this.btnValidar.Text = "Validar Datos";
            this.btnValidar.UseVisualStyleBackColor = false;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // frmImportarExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(896, 452);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.cboTipoOrden);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtHojaExcel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.btnImportarExcel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtColumnaCategoria);
            this.Controls.Add(this.txtColumnaDias);
            this.Controls.Add(this.txtColumnaDNI);
            this.Controls.Add(this.txtColumnaNombres);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFinFila);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtComienzoFila);
            this.Controls.Add(this.label1);
            this.Name = "frmImportarExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importador Excel";
            this.Load += new System.EventHandler(this.frmImportarExcel_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComienzoFila;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFinFila;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtColumnaNombres;
        private System.Windows.Forms.TextBox txtColumnaDNI;
        private System.Windows.Forms.TextBox txtColumnaDias;
        private System.Windows.Forms.TextBox txtColumnaCategoria;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgDatos;
        private System.Windows.Forms.Button btnImportarExcel;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHojaExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidopaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidomaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDias;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboTipoOrden;
        private System.Windows.Forms.Button btnValidar;
    }
}