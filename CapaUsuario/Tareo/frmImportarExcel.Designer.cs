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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnImportarExcel = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHojaExcel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboTipoOrden = new System.Windows.Forms.ComboBox();
            this.btnValidar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtColumnaCuentaBancaria = new System.Windows.Forms.TextBox();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtApellidoPaterno = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtApellidoMaterno = new System.Windows.Forms.TextBox();
            this.colDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreValidado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidopaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidoValidado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidomaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidoMaternoValidado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechanacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstadoCivil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuentaBancaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrabajadorValidado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colTrabajadorEncontrado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnImportarHojaInformativa = new System.Windows.Forms.Button();
            this.btnFormatoHojaInformativa = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(329, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fin Fila Datos:";
            // 
            // txtComienzoFila
            // 
            this.txtComienzoFila.Location = new System.Drawing.Point(153, 96);
            this.txtComienzoFila.Name = "txtComienzoFila";
            this.txtComienzoFila.Size = new System.Drawing.Size(100, 20);
            this.txtComienzoFila.TabIndex = 1;
            this.txtComienzoFila.Text = "13";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(26, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Comienzo Fila Datos:";
            // 
            // txtFinFila
            // 
            this.txtFinFila.Location = new System.Drawing.Point(477, 100);
            this.txtFinFila.Name = "txtFinFila";
            this.txtFinFila.Size = new System.Drawing.Size(100, 20);
            this.txtFinFila.TabIndex = 3;
            this.txtFinFila.Text = "13";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(26, 59);
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
            this.label4.Location = new System.Drawing.Point(329, 63);
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
            this.label5.Location = new System.Drawing.Point(329, 152);
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
            this.label6.Location = new System.Drawing.Point(329, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Columna Categoria:";
            // 
            // txtColumnaNombres
            // 
            this.txtColumnaNombres.Location = new System.Drawing.Point(153, 56);
            this.txtColumnaNombres.Name = "txtColumnaNombres";
            this.txtColumnaNombres.Size = new System.Drawing.Size(100, 20);
            this.txtColumnaNombres.TabIndex = 8;
            this.txtColumnaNombres.Text = "E";
            // 
            // txtColumnaDNI
            // 
            this.txtColumnaDNI.Location = new System.Drawing.Point(477, 56);
            this.txtColumnaDNI.Name = "txtColumnaDNI";
            this.txtColumnaDNI.Size = new System.Drawing.Size(100, 20);
            this.txtColumnaDNI.TabIndex = 9;
            this.txtColumnaDNI.Text = "F";
            // 
            // txtColumnaDias
            // 
            this.txtColumnaDias.Location = new System.Drawing.Point(477, 145);
            this.txtColumnaDias.Name = "txtColumnaDias";
            this.txtColumnaDias.Size = new System.Drawing.Size(100, 20);
            this.txtColumnaDias.TabIndex = 10;
            this.txtColumnaDias.Text = "AS";
            // 
            // txtColumnaCategoria
            // 
            this.txtColumnaCategoria.Location = new System.Drawing.Point(477, 187);
            this.txtColumnaCategoria.Name = "txtColumnaCategoria";
            this.txtColumnaCategoria.Size = new System.Drawing.Size(100, 20);
            this.txtColumnaCategoria.TabIndex = 11;
            this.txtColumnaCategoria.Text = "K";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgDatos);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox1.Location = new System.Drawing.Point(29, 258);
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
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Honeydew;
            this.dtgDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDNI,
            this.colNombres,
            this.colNombreValidado,
            this.colApellidopaterno,
            this.colApellidoValidado,
            this.colApellidomaterno,
            this.colApellidoMaternoValidado,
            this.colCargo,
            this.colDias,
            this.colFechanacimiento,
            this.colSexo,
            this.colEstadoCivil,
            this.colCuentaBancaria,
            this.colFechaInicio,
            this.colDireccion,
            this.colObservaciones,
            this.colTrabajadorValidado,
            this.colTrabajadorEncontrado});
            this.dtgDatos.Location = new System.Drawing.Point(6, 19);
            this.dtgDatos.Name = "dtgDatos";
            this.dtgDatos.ReadOnly = true;
            this.dtgDatos.Size = new System.Drawing.Size(832, 194);
            this.dtgDatos.TabIndex = 0;
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
            this.btnImportar.Location = new System.Drawing.Point(687, 171);
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
            this.label7.Location = new System.Drawing.Point(26, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Nombre Hoja:";
            // 
            // txtHojaExcel
            // 
            this.txtHojaExcel.Location = new System.Drawing.Point(153, 145);
            this.txtHojaExcel.Name = "txtHojaExcel";
            this.txtHojaExcel.Size = new System.Drawing.Size(100, 20);
            this.txtHojaExcel.TabIndex = 16;
            this.txtHojaExcel.Text = "TAREO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkBlue;
            this.label8.Location = new System.Drawing.Point(26, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Tipo Orden:";
            // 
            // cboTipoOrden
            // 
            this.cboTipoOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoOrden.FormattingEnabled = true;
            this.cboTipoOrden.Location = new System.Drawing.Point(153, 182);
            this.cboTipoOrden.Name = "cboTipoOrden";
            this.cboTipoOrden.Size = new System.Drawing.Size(121, 21);
            this.cboTipoOrden.TabIndex = 18;
            // 
            // btnValidar
            // 
            this.btnValidar.BackColor = System.Drawing.Color.Azure;
            this.btnValidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidar.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnValidar.Location = new System.Drawing.Point(687, 128);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(116, 37);
            this.btnValidar.TabIndex = 19;
            this.btnValidar.Text = "Validar Datos";
            this.btnValidar.UseVisualStyleBackColor = false;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkBlue;
            this.label9.Location = new System.Drawing.Point(329, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Columna Cuenta B:";
            // 
            // txtColumnaCuentaBancaria
            // 
            this.txtColumnaCuentaBancaria.Location = new System.Drawing.Point(477, 223);
            this.txtColumnaCuentaBancaria.Name = "txtColumnaCuentaBancaria";
            this.txtColumnaCuentaBancaria.Size = new System.Drawing.Size(100, 20);
            this.txtColumnaCuentaBancaria.TabIndex = 21;
            this.txtColumnaCuentaBancaria.Text = "H";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(153, 216);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(116, 20);
            this.dtpFechaInicio.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkBlue;
            this.label10.Location = new System.Drawing.Point(26, 223);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Fecha Inicio:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkBlue;
            this.label11.Location = new System.Drawing.Point(26, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Apellido Paterno:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // txtApellidoPaterno
            // 
            this.txtApellidoPaterno.Location = new System.Drawing.Point(153, 12);
            this.txtApellidoPaterno.Name = "txtApellidoPaterno";
            this.txtApellidoPaterno.Size = new System.Drawing.Size(100, 20);
            this.txtApellidoPaterno.TabIndex = 25;
            this.txtApellidoPaterno.Text = "C";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DarkBlue;
            this.label12.Location = new System.Drawing.Point(329, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Apellido Materno:";
            // 
            // txtApellidoMaterno
            // 
            this.txtApellidoMaterno.Location = new System.Drawing.Point(477, 12);
            this.txtApellidoMaterno.Name = "txtApellidoMaterno";
            this.txtApellidoMaterno.Size = new System.Drawing.Size(100, 20);
            this.txtApellidoMaterno.TabIndex = 27;
            this.txtApellidoMaterno.Text = "D";
            // 
            // colDNI
            // 
            this.colDNI.DataPropertyName = "DNI";
            this.colDNI.HeaderText = "DNI";
            this.colDNI.Name = "colDNI";
            this.colDNI.ReadOnly = true;
            this.colDNI.Width = 75;
            // 
            // colNombres
            // 
            this.colNombres.DataPropertyName = "Nombres";
            this.colNombres.HeaderText = "Nombres";
            this.colNombres.Name = "colNombres";
            this.colNombres.ReadOnly = true;
            this.colNombres.Width = 150;
            // 
            // colNombreValidado
            // 
            this.colNombreValidado.DataPropertyName = "nombresValidado";
            this.colNombreValidado.HeaderText = "Nombre Validado";
            this.colNombreValidado.Name = "colNombreValidado";
            this.colNombreValidado.ReadOnly = true;
            this.colNombreValidado.Visible = false;
            this.colNombreValidado.Width = 150;
            // 
            // colApellidopaterno
            // 
            this.colApellidopaterno.DataPropertyName = "Apellidopaterno";
            this.colApellidopaterno.HeaderText = "Apellido Paterno";
            this.colApellidopaterno.Name = "colApellidopaterno";
            this.colApellidopaterno.ReadOnly = true;
            // 
            // colApellidoValidado
            // 
            this.colApellidoValidado.DataPropertyName = "apellidoPaternoValidado";
            this.colApellidoValidado.HeaderText = "Apellido Pat. Validado";
            this.colApellidoValidado.Name = "colApellidoValidado";
            this.colApellidoValidado.ReadOnly = true;
            this.colApellidoValidado.Visible = false;
            // 
            // colApellidomaterno
            // 
            this.colApellidomaterno.DataPropertyName = "Apellidomaterno";
            this.colApellidomaterno.HeaderText = "Apellido Materno";
            this.colApellidomaterno.Name = "colApellidomaterno";
            this.colApellidomaterno.ReadOnly = true;
            this.colApellidomaterno.Width = 120;
            // 
            // colApellidoMaternoValidado
            // 
            this.colApellidoMaternoValidado.DataPropertyName = "ApellidoMaternoValidado";
            this.colApellidoMaternoValidado.HeaderText = "Apellido Mat. Validado";
            this.colApellidoMaternoValidado.Name = "colApellidoMaternoValidado";
            this.colApellidoMaternoValidado.ReadOnly = true;
            this.colApellidoMaternoValidado.Visible = false;
            this.colApellidoMaternoValidado.Width = 120;
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
            // colFechanacimiento
            // 
            this.colFechanacimiento.DataPropertyName = "FechaNacimiento";
            this.colFechanacimiento.HeaderText = "Fecha Nacimiento";
            this.colFechanacimiento.Name = "colFechanacimiento";
            this.colFechanacimiento.ReadOnly = true;
            this.colFechanacimiento.Width = 75;
            // 
            // colSexo
            // 
            this.colSexo.DataPropertyName = "sexo";
            this.colSexo.HeaderText = "Sexo";
            this.colSexo.Name = "colSexo";
            this.colSexo.ReadOnly = true;
            this.colSexo.Width = 20;
            // 
            // colEstadoCivil
            // 
            this.colEstadoCivil.DataPropertyName = "estadoCivil";
            this.colEstadoCivil.HeaderText = "Estado Civil";
            this.colEstadoCivil.Name = "colEstadoCivil";
            this.colEstadoCivil.ReadOnly = true;
            this.colEstadoCivil.Width = 70;
            // 
            // colCuentaBancaria
            // 
            this.colCuentaBancaria.DataPropertyName = "cuentaBancaria";
            this.colCuentaBancaria.HeaderText = "Cuenta Bancaria";
            this.colCuentaBancaria.Name = "colCuentaBancaria";
            this.colCuentaBancaria.ReadOnly = true;
            // 
            // colFechaInicio
            // 
            this.colFechaInicio.DataPropertyName = "fechaInicio";
            this.colFechaInicio.HeaderText = "Fecha Inicio";
            this.colFechaInicio.Name = "colFechaInicio";
            this.colFechaInicio.ReadOnly = true;
            this.colFechaInicio.Width = 75;
            // 
            // colDireccion
            // 
            this.colDireccion.DataPropertyName = "Direccion";
            this.colDireccion.HeaderText = "Direccion";
            this.colDireccion.Name = "colDireccion";
            this.colDireccion.ReadOnly = true;
            // 
            // colObservaciones
            // 
            this.colObservaciones.DataPropertyName = "Observaciones";
            this.colObservaciones.HeaderText = "Observaciones";
            this.colObservaciones.Name = "colObservaciones";
            this.colObservaciones.ReadOnly = true;
            // 
            // colTrabajadorValidado
            // 
            this.colTrabajadorValidado.DataPropertyName = "trabajadorValidado";
            this.colTrabajadorValidado.HeaderText = "Validado";
            this.colTrabajadorValidado.Name = "colTrabajadorValidado";
            this.colTrabajadorValidado.ReadOnly = true;
            this.colTrabajadorValidado.Width = 50;
            // 
            // colTrabajadorEncontrado
            // 
            this.colTrabajadorEncontrado.DataPropertyName = "trabajadorEncontrado";
            this.colTrabajadorEncontrado.HeaderText = "Encontrado";
            this.colTrabajadorEncontrado.Name = "colTrabajadorEncontrado";
            this.colTrabajadorEncontrado.ReadOnly = true;
            this.colTrabajadorEncontrado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTrabajadorEncontrado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colTrabajadorEncontrado.Width = 50;
            // 
            // btnImportarHojaInformativa
            // 
            this.btnImportarHojaInformativa.BackColor = System.Drawing.Color.Azure;
            this.btnImportarHojaInformativa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportarHojaInformativa.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnImportarHojaInformativa.Location = new System.Drawing.Point(687, 67);
            this.btnImportarHojaInformativa.Name = "btnImportarHojaInformativa";
            this.btnImportarHojaInformativa.Size = new System.Drawing.Size(116, 37);
            this.btnImportarHojaInformativa.TabIndex = 28;
            this.btnImportarHojaInformativa.Text = "Importar HojaInformativa";
            this.btnImportarHojaInformativa.UseVisualStyleBackColor = false;
            this.btnImportarHojaInformativa.Click += new System.EventHandler(this.btnImportarHojaInformativa_Click);
            // 
            // btnFormatoHojaInformativa
            // 
            this.btnFormatoHojaInformativa.BackColor = System.Drawing.Color.Azure;
            this.btnFormatoHojaInformativa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormatoHojaInformativa.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnFormatoHojaInformativa.Location = new System.Drawing.Point(820, 67);
            this.btnFormatoHojaInformativa.Name = "btnFormatoHojaInformativa";
            this.btnFormatoHojaInformativa.Size = new System.Drawing.Size(93, 37);
            this.btnFormatoHojaInformativa.TabIndex = 29;
            this.btnFormatoHojaInformativa.Text = "Ver Datos";
            this.btnFormatoHojaInformativa.UseVisualStyleBackColor = false;
            this.btnFormatoHojaInformativa.Click += new System.EventHandler(this.btnFormatoHojaInformativa_Click);
            // 
            // frmImportarExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(948, 500);
            this.Controls.Add(this.btnFormatoHojaInformativa);
            this.Controls.Add(this.btnImportarHojaInformativa);
            this.Controls.Add(this.txtApellidoMaterno);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtApellidoPaterno);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.txtColumnaCuentaBancaria);
            this.Controls.Add(this.label9);
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboTipoOrden;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtColumnaCuentaBancaria;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtApellidoPaterno;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtApellidoMaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreValidado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidopaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidoValidado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidomaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidoMaternoValidado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDias;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechanacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstadoCivil;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuentaBancaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservaciones;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colTrabajadorValidado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colTrabajadorEncontrado;
        private System.Windows.Forms.Button btnImportarHojaInformativa;
        private System.Windows.Forms.Button btnFormatoHojaInformativa;
    }
}