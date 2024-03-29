﻿namespace CapaUsuario.Planilla
{
    partial class frmDetallePagosTrabajador
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgBoletasPago = new System.Windows.Forms.DataGridView();
            this.IDPLANILLA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Año = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Planilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plantilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalIngresos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiasLaborados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtdetallePlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAEmpleador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalATrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalNetoACobrar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtMeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtFuenteFinanciamiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtRegimenLaboral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalDescuentos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detallePlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtTrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Meta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTrabajador = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBoletasPago)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.MintCream;
            this.button1.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.ImageKey = "NetByte Design Studio - 0849.png";
            this.button1.Location = new System.Drawing.Point(832, 366);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 41);
            this.button1.TabIndex = 101;
            this.button1.Text = "&Salir";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgBoletasPago);
            this.groupBox2.Location = new System.Drawing.Point(9, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(900, 288);
            this.groupBox2.TabIndex = 100;
            this.groupBox2.TabStop = false;
            // 
            // dtgBoletasPago
            // 
            this.dtgBoletasPago.AllowUserToAddRows = false;
            this.dtgBoletasPago.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Lavender;
            this.dtgBoletasPago.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgBoletasPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBoletasPago.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDPLANILLA,
            this.Mes,
            this.Año,
            this.Cargo,
            this.Numero,
            this.Planilla,
            this.Plantilla,
            this.TotalIngresos,
            this.DiasLaborados,
            this.idtdetallePlanilla,
            this.TotalAEmpleador,
            this.TotalATrabajador,
            this.TotalNetoACobrar,
            this.idtMeta,
            this.idtFuenteFinanciamiento,
            this.idtRegimenLaboral,
            this.TotalDescuentos,
            this.fechaInicio,
            this.fecha,
            this.Observaciones,
            this.oPlanilla,
            this.detallePlanilla,
            this.idtTrabajador,
            this.Meta,
            this.Trabajador});
            this.dtgBoletasPago.Location = new System.Drawing.Point(6, 19);
            this.dtgBoletasPago.Name = "dtgBoletasPago";
            this.dtgBoletasPago.ReadOnly = true;
            this.dtgBoletasPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBoletasPago.Size = new System.Drawing.Size(888, 257);
            this.dtgBoletasPago.TabIndex = 0;
            // 
            // IDPLANILLA
            // 
            this.IDPLANILLA.DataPropertyName = "idtPlanilla";
            this.IDPLANILLA.HeaderText = "IDPLANILLA";
            this.IDPLANILLA.Name = "IDPLANILLA";
            this.IDPLANILLA.ReadOnly = true;
            this.IDPLANILLA.Visible = false;
            // 
            // Mes
            // 
            this.Mes.DataPropertyName = "Mes";
            this.Mes.HeaderText = "Mes";
            this.Mes.Name = "Mes";
            this.Mes.ReadOnly = true;
            this.Mes.Width = 90;
            // 
            // Año
            // 
            this.Año.DataPropertyName = "Año";
            this.Año.HeaderText = "Año";
            this.Año.Name = "Año";
            this.Año.ReadOnly = true;
            this.Año.Width = 50;
            // 
            // Cargo
            // 
            this.Cargo.DataPropertyName = "Cargo";
            this.Cargo.HeaderText = "Cargo";
            this.Cargo.Name = "Cargo";
            this.Cargo.ReadOnly = true;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            this.Numero.HeaderText = "Nro Planilla";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 40;
            // 
            // Planilla
            // 
            this.Planilla.DataPropertyName = "Descripcion";
            this.Planilla.HeaderText = "Planilla";
            this.Planilla.Name = "Planilla";
            this.Planilla.ReadOnly = true;
            this.Planilla.Width = 200;
            // 
            // Plantilla
            // 
            this.Plantilla.DataPropertyName = "Plantilla";
            this.Plantilla.HeaderText = "Plantilla";
            this.Plantilla.Name = "Plantilla";
            this.Plantilla.ReadOnly = true;
            // 
            // TotalIngresos
            // 
            this.TotalIngresos.DataPropertyName = "TotalIngresos";
            this.TotalIngresos.HeaderText = "Total Ingresos";
            this.TotalIngresos.Name = "TotalIngresos";
            this.TotalIngresos.ReadOnly = true;
            this.TotalIngresos.Width = 80;
            // 
            // DiasLaborados
            // 
            this.DiasLaborados.DataPropertyName = "DiasLaborados";
            this.DiasLaborados.HeaderText = "Dias Laborados";
            this.DiasLaborados.Name = "DiasLaborados";
            this.DiasLaborados.ReadOnly = true;
            this.DiasLaborados.Width = 50;
            // 
            // idtdetallePlanilla
            // 
            this.idtdetallePlanilla.DataPropertyName = "idtDetallePlanilla";
            this.idtdetallePlanilla.HeaderText = "idtDetallePlanilla";
            this.idtdetallePlanilla.Name = "idtdetallePlanilla";
            this.idtdetallePlanilla.ReadOnly = true;
            this.idtdetallePlanilla.Visible = false;
            // 
            // TotalAEmpleador
            // 
            this.TotalAEmpleador.DataPropertyName = "TotalAEmpleador";
            this.TotalAEmpleador.HeaderText = "TotalAEmpleador";
            this.TotalAEmpleador.Name = "TotalAEmpleador";
            this.TotalAEmpleador.ReadOnly = true;
            this.TotalAEmpleador.Visible = false;
            // 
            // TotalATrabajador
            // 
            this.TotalATrabajador.DataPropertyName = "TotalATrabajador";
            this.TotalATrabajador.HeaderText = "TotalATRabajador";
            this.TotalATrabajador.Name = "TotalATrabajador";
            this.TotalATrabajador.ReadOnly = true;
            this.TotalATrabajador.Visible = false;
            // 
            // TotalNetoACobrar
            // 
            this.TotalNetoACobrar.DataPropertyName = "NetoACobrar";
            this.TotalNetoACobrar.HeaderText = "TotalNetoACobrar";
            this.TotalNetoACobrar.Name = "TotalNetoACobrar";
            this.TotalNetoACobrar.ReadOnly = true;
            this.TotalNetoACobrar.Visible = false;
            // 
            // idtMeta
            // 
            this.idtMeta.DataPropertyName = "idtMeta";
            this.idtMeta.HeaderText = "idtMeta";
            this.idtMeta.Name = "idtMeta";
            this.idtMeta.ReadOnly = true;
            this.idtMeta.Visible = false;
            // 
            // idtFuenteFinanciamiento
            // 
            this.idtFuenteFinanciamiento.DataPropertyName = "idtFuenteFinanciamiento";
            this.idtFuenteFinanciamiento.HeaderText = "idtFuenteFinanciamiento";
            this.idtFuenteFinanciamiento.Name = "idtFuenteFinanciamiento";
            this.idtFuenteFinanciamiento.ReadOnly = true;
            this.idtFuenteFinanciamiento.Visible = false;
            // 
            // idtRegimenLaboral
            // 
            this.idtRegimenLaboral.DataPropertyName = "idtRegimenLaboral";
            this.idtRegimenLaboral.HeaderText = "idtRegimenLaboral";
            this.idtRegimenLaboral.Name = "idtRegimenLaboral";
            this.idtRegimenLaboral.ReadOnly = true;
            this.idtRegimenLaboral.Visible = false;
            // 
            // TotalDescuentos
            // 
            this.TotalDescuentos.DataPropertyName = "TotalDescuentos";
            this.TotalDescuentos.HeaderText = "TotalDescuentos";
            this.TotalDescuentos.Name = "TotalDescuentos";
            this.TotalDescuentos.ReadOnly = true;
            this.TotalDescuentos.Visible = false;
            // 
            // fechaInicio
            // 
            this.fechaInicio.DataPropertyName = "FechaInicio";
            this.fechaInicio.HeaderText = "fechaInicio";
            this.fechaInicio.Name = "fechaInicio";
            this.fechaInicio.ReadOnly = true;
            this.fechaInicio.Visible = false;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "Fecha";
            this.fecha.HeaderText = "fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Visible = false;
            // 
            // Observaciones
            // 
            this.Observaciones.DataPropertyName = "Observaciones";
            this.Observaciones.HeaderText = "Observaciones";
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.ReadOnly = true;
            this.Observaciones.Visible = false;
            // 
            // oPlanilla
            // 
            this.oPlanilla.DataPropertyName = "Planilla";
            this.oPlanilla.HeaderText = "Planilla";
            this.oPlanilla.Name = "oPlanilla";
            this.oPlanilla.ReadOnly = true;
            this.oPlanilla.Visible = false;
            // 
            // detallePlanilla
            // 
            this.detallePlanilla.DataPropertyName = "DetallePlanilla";
            this.detallePlanilla.HeaderText = "detallePlanilla";
            this.detallePlanilla.Name = "detallePlanilla";
            this.detallePlanilla.ReadOnly = true;
            this.detallePlanilla.Visible = false;
            // 
            // idtTrabajador
            // 
            this.idtTrabajador.DataPropertyName = "IdtTrabajador";
            this.idtTrabajador.HeaderText = "idtTrabajador";
            this.idtTrabajador.Name = "idtTrabajador";
            this.idtTrabajador.ReadOnly = true;
            this.idtTrabajador.Visible = false;
            // 
            // Meta
            // 
            this.Meta.DataPropertyName = "Meta";
            this.Meta.HeaderText = "Meta";
            this.Meta.Name = "Meta";
            this.Meta.ReadOnly = true;
            this.Meta.Visible = false;
            // 
            // Trabajador
            // 
            this.Trabajador.DataPropertyName = "Trabajador";
            this.Trabajador.HeaderText = "Trabajador";
            this.Trabajador.Name = "Trabajador";
            this.Trabajador.ReadOnly = true;
            this.Trabajador.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTrabajador);
            this.groupBox1.Location = new System.Drawing.Point(9, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(900, 59);
            this.groupBox1.TabIndex = 99;
            this.groupBox1.TabStop = false;
            // 
            // lblTrabajador
            // 
            this.lblTrabajador.AutoSize = true;
            this.lblTrabajador.Location = new System.Drawing.Point(6, 26);
            this.lblTrabajador.Name = "lblTrabajador";
            this.lblTrabajador.Size = new System.Drawing.Size(29, 13);
            this.lblTrabajador.TabIndex = 94;
            this.lblTrabajador.Text = "Año:";
            // 
            // frmDetallePagosTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 408);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDetallePagosTrabajador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle Pagos Trabajador";
            this.Load += new System.EventHandler(this.frmDetallePagosTrabajador_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBoletasPago)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgBoletasPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPLANILLA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Año;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Planilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plantilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalIngresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiasLaborados;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtdetallePlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAEmpleador;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalATrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalNetoACobrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtMeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtFuenteFinanciamiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtRegimenLaboral;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalDescuentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn oPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn detallePlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtTrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Meta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trabajador;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTrabajador;
    }
}