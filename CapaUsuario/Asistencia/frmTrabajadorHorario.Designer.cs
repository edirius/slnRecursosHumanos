namespace CapaUsuario.Asistencia
{
    partial class frmTrabajadorHorario
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
            this.lblNombredelTrabajador = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboListaHorarios = new System.Windows.Forms.ComboBox();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAsignarHorario = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNombredelTrabajador
            // 
            this.lblNombredelTrabajador.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblNombredelTrabajador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNombredelTrabajador.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNombredelTrabajador.Location = new System.Drawing.Point(0, 0);
            this.lblNombredelTrabajador.Name = "lblNombredelTrabajador";
            this.lblNombredelTrabajador.Size = new System.Drawing.Size(350, 23);
            this.lblNombredelTrabajador.TabIndex = 1;
            this.lblNombredelTrabajador.Text = "Lista Cargos";
            this.lblNombredelTrabajador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lista Horarios:";
            // 
            // cboListaHorarios
            // 
            this.cboListaHorarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListaHorarios.FormattingEnabled = true;
            this.cboListaHorarios.Location = new System.Drawing.Point(93, 57);
            this.cboListaHorarios.Name = "cboListaHorarios";
            this.cboListaHorarios.Size = new System.Drawing.Size(242, 21);
            this.cboListaHorarios.TabIndex = 3;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(93, 102);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaInicio.TabIndex = 4;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(93, 146);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFin.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fecha Inicio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Fecha Fin:";
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.MintCream;
            this.btnSalir.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSalir.Image = global::CapaUsuario.Properties.Resources.exit_32x32;
            this.btnSalir.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnSalir.Location = new System.Drawing.Point(256, 203);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(79, 65);
            this.btnSalir.TabIndex = 76;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAsignarHorario
            // 
            this.btnAsignarHorario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignarHorario.BackColor = System.Drawing.Color.MintCream;
            this.btnAsignarHorario.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnAsignarHorario.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAsignarHorario.Image = global::CapaUsuario.Properties.Resources.user_calendar_0;
            this.btnAsignarHorario.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnAsignarHorario.Location = new System.Drawing.Point(153, 203);
            this.btnAsignarHorario.Name = "btnAsignarHorario";
            this.btnAsignarHorario.Size = new System.Drawing.Size(97, 65);
            this.btnAsignarHorario.TabIndex = 75;
            this.btnAsignarHorario.Text = "&Asignar Horario";
            this.btnAsignarHorario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAsignarHorario.UseVisualStyleBackColor = false;
            this.btnAsignarHorario.Click += new System.EventHandler(this.btnAsignarHorario_Click);
            // 
            // frmTrabajadorHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 280);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAsignarHorario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.cboListaHorarios);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNombredelTrabajador);
            this.Name = "frmTrabajadorHorario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignar Horario al trabajador";
            this.Load += new System.EventHandler(this.frmTrabajadorHorario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombredelTrabajador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboListaHorarios;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAsignarHorario;
    }
}