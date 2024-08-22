namespace CapaUsuario.ExportarSunat.Tregistro
{
    partial class frmVerCodificacion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgJor = new System.Windows.Forms.DataGridView();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumeroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidoPaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellidoMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNacionalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefonoLarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoVia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreVia1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumeroVia1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartamento1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInterior1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManzana1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLote1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKilometro1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBloque1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEtapa1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoZona1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreZona1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReferencia1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUbigeo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgTra = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtgPer = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgJor)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTra)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPer)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgJor);
            this.groupBox1.Location = new System.Drawing.Point(28, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(771, 214);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Identificacion - .jor";
            // 
            // dtgJor
            // 
            this.dtgJor.AllowUserToAddRows = false;
            this.dtgJor.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.dtgJor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgJor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgJor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumero,
            this.colTipoDocumento,
            this.colNumeroDocumento,
            this.colNombres,
            this.colApellidoPaterno,
            this.colApellidoMaterno,
            this.colFechaNacimiento,
            this.colSexo,
            this.colNacionalidad,
            this.colTelefonoLarga,
            this.colTelefono,
            this.colCorreo,
            this.colTipoVia,
            this.colNombreVia1,
            this.colNumeroVia1,
            this.colDepartamento1,
            this.colInterior1,
            this.colManzana1,
            this.colLote1,
            this.colKilometro1,
            this.colBloque1,
            this.colEtapa1,
            this.colTipoZona1,
            this.colNombreZona1,
            this.colReferencia1,
            this.colUbigeo1});
            this.dtgJor.Location = new System.Drawing.Point(21, 19);
            this.dtgJor.Name = "dtgJor";
            this.dtgJor.ReadOnly = true;
            this.dtgJor.Size = new System.Drawing.Size(719, 174);
            this.dtgJor.TabIndex = 0;
            // 
            // colNumero
            // 
            this.colNumero.DataPropertyName = "Numero";
            this.colNumero.HeaderText = "Nº";
            this.colNumero.Name = "colNumero";
            this.colNumero.ReadOnly = true;
            this.colNumero.Width = 30;
            // 
            // colTipoDocumento
            // 
            this.colTipoDocumento.DataPropertyName = "TipoDocumento";
            this.colTipoDocumento.HeaderText = "Tipo Documento";
            this.colTipoDocumento.Name = "colTipoDocumento";
            this.colTipoDocumento.ReadOnly = true;
            // 
            // colNumeroDocumento
            // 
            this.colNumeroDocumento.DataPropertyName = "NumeroDocumento";
            this.colNumeroDocumento.HeaderText = "Numero Documento";
            this.colNumeroDocumento.Name = "colNumeroDocumento";
            this.colNumeroDocumento.ReadOnly = true;
            // 
            // colNombres
            // 
            this.colNombres.DataPropertyName = "Nombres";
            this.colNombres.HeaderText = "Nombres";
            this.colNombres.Name = "colNombres";
            this.colNombres.ReadOnly = true;
            // 
            // colApellidoPaterno
            // 
            this.colApellidoPaterno.DataPropertyName = "ApellidoPaterno";
            this.colApellidoPaterno.HeaderText = "Apellido Paterno";
            this.colApellidoPaterno.Name = "colApellidoPaterno";
            this.colApellidoPaterno.ReadOnly = true;
            // 
            // colApellidoMaterno
            // 
            this.colApellidoMaterno.DataPropertyName = "ApellidoMaterno";
            this.colApellidoMaterno.HeaderText = "Apellido Materno";
            this.colApellidoMaterno.Name = "colApellidoMaterno";
            this.colApellidoMaterno.ReadOnly = true;
            // 
            // colFechaNacimiento
            // 
            this.colFechaNacimiento.DataPropertyName = "FechaNacimiento";
            this.colFechaNacimiento.HeaderText = "Fecha Nacimiento";
            this.colFechaNacimiento.Name = "colFechaNacimiento";
            this.colFechaNacimiento.ReadOnly = true;
            // 
            // colSexo
            // 
            this.colSexo.DataPropertyName = "Sexo";
            this.colSexo.HeaderText = "Sexo";
            this.colSexo.Name = "colSexo";
            this.colSexo.ReadOnly = true;
            // 
            // colNacionalidad
            // 
            this.colNacionalidad.DataPropertyName = "Nacionalidad";
            this.colNacionalidad.HeaderText = "Nacionalidad";
            this.colNacionalidad.Name = "colNacionalidad";
            this.colNacionalidad.ReadOnly = true;
            // 
            // colTelefonoLarga
            // 
            this.colTelefonoLarga.DataPropertyName = "TelefonoCodigoLargaDistancia";
            this.colTelefonoLarga.HeaderText = "Tel. Larg Dist.";
            this.colTelefonoLarga.Name = "colTelefonoLarga";
            this.colTelefonoLarga.ReadOnly = true;
            this.colTelefonoLarga.ToolTipText = "Codigo Telefono Larga Distancia";
            // 
            // colTelefono
            // 
            this.colTelefono.DataPropertyName = "Telefono";
            this.colTelefono.HeaderText = "Telefono";
            this.colTelefono.Name = "colTelefono";
            this.colTelefono.ReadOnly = true;
            // 
            // colCorreo
            // 
            this.colCorreo.DataPropertyName = "CorreoElectronico";
            this.colCorreo.HeaderText = "Correo Electronico";
            this.colCorreo.Name = "colCorreo";
            this.colCorreo.ReadOnly = true;
            // 
            // colTipoVia
            // 
            this.colTipoVia.DataPropertyName = "Direccion01_TipoVia";
            this.colTipoVia.HeaderText = "Tipo Via Dir. 1";
            this.colTipoVia.Name = "colTipoVia";
            this.colTipoVia.ReadOnly = true;
            // 
            // colNombreVia1
            // 
            this.colNombreVia1.DataPropertyName = "Direccion01_NombreVia";
            this.colNombreVia1.HeaderText = "Nombre Via Dir 1";
            this.colNombreVia1.Name = "colNombreVia1";
            this.colNombreVia1.ReadOnly = true;
            // 
            // colNumeroVia1
            // 
            this.colNumeroVia1.DataPropertyName = "Direccion01_NumeroVia";
            this.colNumeroVia1.HeaderText = "Numero Via Dir 1";
            this.colNumeroVia1.Name = "colNumeroVia1";
            this.colNumeroVia1.ReadOnly = true;
            // 
            // colDepartamento1
            // 
            this.colDepartamento1.DataPropertyName = "Direccion01_Departamento";
            this.colDepartamento1.HeaderText = "Departamento Dir 1";
            this.colDepartamento1.Name = "colDepartamento1";
            this.colDepartamento1.ReadOnly = true;
            // 
            // colInterior1
            // 
            this.colInterior1.DataPropertyName = "Direccion01_Interior";
            this.colInterior1.HeaderText = "Interior Dir. 1";
            this.colInterior1.Name = "colInterior1";
            this.colInterior1.ReadOnly = true;
            // 
            // colManzana1
            // 
            this.colManzana1.DataPropertyName = "Direccion01_Manzana";
            this.colManzana1.HeaderText = "Manzana Dir 1";
            this.colManzana1.Name = "colManzana1";
            this.colManzana1.ReadOnly = true;
            // 
            // colLote1
            // 
            this.colLote1.DataPropertyName = "Direccion01_Lote";
            this.colLote1.HeaderText = "Lote DIr 1";
            this.colLote1.Name = "colLote1";
            this.colLote1.ReadOnly = true;
            // 
            // colKilometro1
            // 
            this.colKilometro1.DataPropertyName = "Direccion01_Kilometro";
            this.colKilometro1.HeaderText = "Kilometro Dir 1";
            this.colKilometro1.Name = "colKilometro1";
            this.colKilometro1.ReadOnly = true;
            // 
            // colBloque1
            // 
            this.colBloque1.DataPropertyName = "Direccion01_Bloque";
            this.colBloque1.HeaderText = "Bloque Dir 1";
            this.colBloque1.Name = "colBloque1";
            this.colBloque1.ReadOnly = true;
            // 
            // colEtapa1
            // 
            this.colEtapa1.DataPropertyName = "Direccion01_Etapa";
            this.colEtapa1.HeaderText = "Etapa Dir 1";
            this.colEtapa1.Name = "colEtapa1";
            this.colEtapa1.ReadOnly = true;
            // 
            // colTipoZona1
            // 
            this.colTipoZona1.DataPropertyName = "Direccion01_Tipozona";
            this.colTipoZona1.HeaderText = "Tipo Zona Dir 1";
            this.colTipoZona1.Name = "colTipoZona1";
            this.colTipoZona1.ReadOnly = true;
            // 
            // colNombreZona1
            // 
            this.colNombreZona1.DataPropertyName = "Direccion01_Nombrezona";
            this.colNombreZona1.HeaderText = "Nombre Zona Dir 1";
            this.colNombreZona1.Name = "colNombreZona1";
            this.colNombreZona1.ReadOnly = true;
            // 
            // colReferencia1
            // 
            this.colReferencia1.DataPropertyName = "Direccion01_Referencia";
            this.colReferencia1.HeaderText = "Referencia Dir 1";
            this.colReferencia1.Name = "colReferencia1";
            this.colReferencia1.ReadOnly = true;
            // 
            // colUbigeo1
            // 
            this.colUbigeo1.DataPropertyName = "Direccion01_Ubigeo";
            this.colUbigeo1.HeaderText = "Ubigeo";
            this.colUbigeo1.Name = "colUbigeo1";
            this.colUbigeo1.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgTra);
            this.groupBox2.Location = new System.Drawing.Point(28, 245);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(771, 185);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de Identificacion - tra";
            // 
            // dtgTra
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            this.dtgTra.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTra.Location = new System.Drawing.Point(21, 22);
            this.dtgTra.Name = "dtgTra";
            this.dtgTra.Size = new System.Drawing.Size(719, 150);
            this.dtgTra.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtgPer);
            this.groupBox3.Location = new System.Drawing.Point(28, 442);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(771, 183);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos de Periodo - per";
            // 
            // dtgPer
            // 
            this.dtgPer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPer.Location = new System.Drawing.Point(21, 19);
            this.dtgPer.Name = "dtgPer";
            this.dtgPer.Size = new System.Drawing.Size(719, 150);
            this.dtgPer.TabIndex = 0;
            // 
            // frmVerCodificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 637);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmVerCodificacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver Codificacion";
            this.Load += new System.EventHandler(this.frmVerCodificacion_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgJor)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTra)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgJor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidoPaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellidoMaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaNacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNacionalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefonoLarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoVia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreVia1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroVia1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartamento1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInterior1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManzana1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLote1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKilometro1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBloque1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEtapa1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoZona1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreZona1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReferencia1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUbigeo1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgTra;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dtgPer;
    }
}