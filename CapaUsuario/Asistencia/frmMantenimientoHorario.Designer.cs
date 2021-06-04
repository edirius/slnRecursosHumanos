namespace CapaUsuario.Asistencia
{
    partial class frmMantenimientoHorario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoHorario));
            this.dtgListaMantenimeintoHorarios = new System.Windows.Forms.DataGridView();
            this.btnModificarHorario = new System.Windows.Forms.Button();
            this.btnNuevoHorario = new System.Windows.Forms.Button();
            this.btnEliminarHorario = new System.Windows.Forms.Button();
            this.CodigoHorario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreHorario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTurnoLunes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTurnoMartes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTurnoMiercoles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTurnoJueves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTurnoViernes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTurnoSabado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTurnoDomingo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaMantenimeintoHorarios)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListaMantenimeintoHorarios
            // 
            this.dtgListaMantenimeintoHorarios.AllowUserToAddRows = false;
            this.dtgListaMantenimeintoHorarios.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.dtgListaMantenimeintoHorarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaMantenimeintoHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaMantenimeintoHorarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoHorario,
            this.colNombreHorario,
            this.colTurnoLunes,
            this.colTurnoMartes,
            this.colTurnoMiercoles,
            this.colTurnoJueves,
            this.colTurnoViernes,
            this.colTurnoSabado,
            this.colTurnoDomingo});
            this.dtgListaMantenimeintoHorarios.Location = new System.Drawing.Point(12, 52);
            this.dtgListaMantenimeintoHorarios.Name = "dtgListaMantenimeintoHorarios";
            this.dtgListaMantenimeintoHorarios.ReadOnly = true;
            this.dtgListaMantenimeintoHorarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaMantenimeintoHorarios.Size = new System.Drawing.Size(587, 149);
            this.dtgListaMantenimeintoHorarios.TabIndex = 0;
            // 
            // btnModificarHorario
            // 
            this.btnModificarHorario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificarHorario.BackColor = System.Drawing.Color.MintCream;
            this.btnModificarHorario.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificarHorario.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnModificarHorario.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnModificarHorario.Location = new System.Drawing.Point(430, 227);
            this.btnModificarHorario.Name = "btnModificarHorario";
            this.btnModificarHorario.Size = new System.Drawing.Size(79, 65);
            this.btnModificarHorario.TabIndex = 74;
            this.btnModificarHorario.Text = "&Modificar Horario";
            this.btnModificarHorario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModificarHorario.UseVisualStyleBackColor = false;
            this.btnModificarHorario.Click += new System.EventHandler(this.btnModificarHorario_Click);
            // 
            // btnNuevoHorario
            // 
            this.btnNuevoHorario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoHorario.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevoHorario.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevoHorario.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevoHorario.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnNuevoHorario.Location = new System.Drawing.Point(349, 227);
            this.btnNuevoHorario.Name = "btnNuevoHorario";
            this.btnNuevoHorario.Size = new System.Drawing.Size(75, 65);
            this.btnNuevoHorario.TabIndex = 73;
            this.btnNuevoHorario.Text = "&Nuevo Horario";
            this.btnNuevoHorario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevoHorario.UseVisualStyleBackColor = false;
            this.btnNuevoHorario.Click += new System.EventHandler(this.btnNuevoHorario_Click);
            // 
            // btnEliminarHorario
            // 
            this.btnEliminarHorario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarHorario.BackColor = System.Drawing.Color.MintCream;
            this.btnEliminarHorario.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarHorario.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEliminarHorario.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnEliminarHorario.Location = new System.Drawing.Point(520, 227);
            this.btnEliminarHorario.Name = "btnEliminarHorario";
            this.btnEliminarHorario.Size = new System.Drawing.Size(79, 65);
            this.btnEliminarHorario.TabIndex = 75;
            this.btnEliminarHorario.Text = "&Eliminar Horario";
            this.btnEliminarHorario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminarHorario.UseVisualStyleBackColor = false;
            this.btnEliminarHorario.Click += new System.EventHandler(this.btnEliminarHorario_Click);
            // 
            // CodigoHorario
            // 
            this.CodigoHorario.DataPropertyName = "CodigoHorario";
            this.CodigoHorario.HeaderText = "Codigo";
            this.CodigoHorario.Name = "CodigoHorario";
            this.CodigoHorario.ReadOnly = true;
            this.CodigoHorario.Width = 50;
            // 
            // colNombreHorario
            // 
            this.colNombreHorario.DataPropertyName = "NombreHorario";
            this.colNombreHorario.HeaderText = "Nombre";
            this.colNombreHorario.Name = "colNombreHorario";
            this.colNombreHorario.ReadOnly = true;
            this.colNombreHorario.Width = 300;
            // 
            // colTurnoLunes
            // 
            this.colTurnoLunes.DataPropertyName = "TurnoLunes";
            this.colTurnoLunes.HeaderText = "Turno Lunes";
            this.colTurnoLunes.Name = "colTurnoLunes";
            this.colTurnoLunes.ReadOnly = true;
            this.colTurnoLunes.Visible = false;
            // 
            // colTurnoMartes
            // 
            this.colTurnoMartes.DataPropertyName = "TurnoMartes";
            this.colTurnoMartes.HeaderText = "Turno Martes";
            this.colTurnoMartes.Name = "colTurnoMartes";
            this.colTurnoMartes.ReadOnly = true;
            this.colTurnoMartes.Visible = false;
            // 
            // colTurnoMiercoles
            // 
            this.colTurnoMiercoles.DataPropertyName = "TurnoMiercoles";
            this.colTurnoMiercoles.HeaderText = "Turno Miercoles";
            this.colTurnoMiercoles.Name = "colTurnoMiercoles";
            this.colTurnoMiercoles.ReadOnly = true;
            this.colTurnoMiercoles.Visible = false;
            // 
            // colTurnoJueves
            // 
            this.colTurnoJueves.DataPropertyName = "TurnoJueves";
            this.colTurnoJueves.HeaderText = "Turno Jueves";
            this.colTurnoJueves.Name = "colTurnoJueves";
            this.colTurnoJueves.ReadOnly = true;
            this.colTurnoJueves.Visible = false;
            // 
            // colTurnoViernes
            // 
            this.colTurnoViernes.DataPropertyName = "TurnoViernes";
            this.colTurnoViernes.HeaderText = "Turno Viernes";
            this.colTurnoViernes.Name = "colTurnoViernes";
            this.colTurnoViernes.ReadOnly = true;
            this.colTurnoViernes.Visible = false;
            // 
            // colTurnoSabado
            // 
            this.colTurnoSabado.DataPropertyName = "TurnoSabado";
            this.colTurnoSabado.HeaderText = "Turno Sabado";
            this.colTurnoSabado.Name = "colTurnoSabado";
            this.colTurnoSabado.ReadOnly = true;
            this.colTurnoSabado.Visible = false;
            // 
            // colTurnoDomingo
            // 
            this.colTurnoDomingo.DataPropertyName = "TurnoDomingo";
            this.colTurnoDomingo.HeaderText = "Turno Domingo";
            this.colTurnoDomingo.Name = "colTurnoDomingo";
            this.colTurnoDomingo.ReadOnly = true;
            this.colTurnoDomingo.Visible = false;
            // 
            // frmMantenimientoHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 321);
            this.Controls.Add(this.btnEliminarHorario);
            this.Controls.Add(this.btnModificarHorario);
            this.Controls.Add(this.btnNuevoHorario);
            this.Controls.Add(this.dtgListaMantenimeintoHorarios);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMantenimientoHorario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Horario";
            this.Load += new System.EventHandler(this.frmMantenimientoHorario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaMantenimeintoHorarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgListaMantenimeintoHorarios;
        private System.Windows.Forms.Button btnModificarHorario;
        private System.Windows.Forms.Button btnNuevoHorario;
        private System.Windows.Forms.Button btnEliminarHorario;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoHorario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreHorario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTurnoLunes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTurnoMartes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTurnoMiercoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTurnoJueves;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTurnoViernes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTurnoSabado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTurnoDomingo;
    }
}