namespace CapaUsuario.Asistencia
{
    partial class frmListaTurnosDia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaTurnosDia));
            this.btnEliminarTurnoXDia = new System.Windows.Forms.Button();
            this.btnModificarTurnoXDia = new System.Windows.Forms.Button();
            this.btnNuevoTurnoxDia = new System.Windows.Forms.Button();
            this.dtgListaTurnoXDia = new System.Windows.Forms.DataGridView();
            this.colCodigoTurnoDia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreTurnoDia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTurnoXDia)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEliminarTurnoXDia
            // 
            this.btnEliminarTurnoXDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarTurnoXDia.BackColor = System.Drawing.Color.MintCream;
            this.btnEliminarTurnoXDia.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarTurnoXDia.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEliminarTurnoXDia.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnEliminarTurnoXDia.Location = new System.Drawing.Point(520, 206);
            this.btnEliminarTurnoXDia.Name = "btnEliminarTurnoXDia";
            this.btnEliminarTurnoXDia.Size = new System.Drawing.Size(79, 65);
            this.btnEliminarTurnoXDia.TabIndex = 79;
            this.btnEliminarTurnoXDia.Text = "&Eliminar Turno x Dia";
            this.btnEliminarTurnoXDia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminarTurnoXDia.UseVisualStyleBackColor = false;
            this.btnEliminarTurnoXDia.Click += new System.EventHandler(this.btnEliminarTurnoXDia_Click);
            // 
            // btnModificarTurnoXDia
            // 
            this.btnModificarTurnoXDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificarTurnoXDia.BackColor = System.Drawing.Color.MintCream;
            this.btnModificarTurnoXDia.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificarTurnoXDia.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnModificarTurnoXDia.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnModificarTurnoXDia.Location = new System.Drawing.Point(430, 206);
            this.btnModificarTurnoXDia.Name = "btnModificarTurnoXDia";
            this.btnModificarTurnoXDia.Size = new System.Drawing.Size(79, 65);
            this.btnModificarTurnoXDia.TabIndex = 78;
            this.btnModificarTurnoXDia.Text = "&Modificar Turno x Dia";
            this.btnModificarTurnoXDia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModificarTurnoXDia.UseVisualStyleBackColor = false;
            this.btnModificarTurnoXDia.Click += new System.EventHandler(this.btnModificarTurnoXDia_Click);
            // 
            // btnNuevoTurnoxDia
            // 
            this.btnNuevoTurnoxDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoTurnoxDia.BackColor = System.Drawing.Color.MintCream;
            this.btnNuevoTurnoxDia.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevoTurnoxDia.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnNuevoTurnoxDia.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnNuevoTurnoxDia.Location = new System.Drawing.Point(349, 206);
            this.btnNuevoTurnoxDia.Name = "btnNuevoTurnoxDia";
            this.btnNuevoTurnoxDia.Size = new System.Drawing.Size(75, 65);
            this.btnNuevoTurnoxDia.TabIndex = 77;
            this.btnNuevoTurnoxDia.Text = "&Nuevo Turno x Dia";
            this.btnNuevoTurnoxDia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevoTurnoxDia.UseVisualStyleBackColor = false;
            this.btnNuevoTurnoxDia.Click += new System.EventHandler(this.btnNuevoTurnoxDia_Click);
            // 
            // dtgListaTurnoXDia
            // 
            this.dtgListaTurnoXDia.AllowUserToAddRows = false;
            this.dtgListaTurnoXDia.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.dtgListaTurnoXDia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaTurnoXDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaTurnoXDia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoTurnoDia,
            this.colNombreTurnoDia});
            this.dtgListaTurnoXDia.Location = new System.Drawing.Point(12, 33);
            this.dtgListaTurnoXDia.MultiSelect = false;
            this.dtgListaTurnoXDia.Name = "dtgListaTurnoXDia";
            this.dtgListaTurnoXDia.ReadOnly = true;
            this.dtgListaTurnoXDia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaTurnoXDia.Size = new System.Drawing.Size(587, 159);
            this.dtgListaTurnoXDia.TabIndex = 76;
            // 
            // colCodigoTurnoDia
            // 
            this.colCodigoTurnoDia.DataPropertyName = "CodigoTurnoDia";
            this.colCodigoTurnoDia.HeaderText = "Codigo";
            this.colCodigoTurnoDia.Name = "colCodigoTurnoDia";
            this.colCodigoTurnoDia.ReadOnly = true;
            this.colCodigoTurnoDia.Width = 50;
            // 
            // colNombreTurnoDia
            // 
            this.colNombreTurnoDia.DataPropertyName = "NombreTurnoDia";
            this.colNombreTurnoDia.HeaderText = "Nombre";
            this.colNombreTurnoDia.Name = "colNombreTurnoDia";
            this.colNombreTurnoDia.ReadOnly = true;
            this.colNombreTurnoDia.Width = 300;
            // 
            // frmListaTurnosDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 283);
            this.Controls.Add(this.btnEliminarTurnoXDia);
            this.Controls.Add(this.btnModificarTurnoXDia);
            this.Controls.Add(this.btnNuevoTurnoxDia);
            this.Controls.Add(this.dtgListaTurnoXDia);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListaTurnosDia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Turnos X Dia";
            this.Load += new System.EventHandler(this.frmListaTurnosDia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTurnoXDia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEliminarTurnoXDia;
        private System.Windows.Forms.Button btnModificarTurnoXDia;
        private System.Windows.Forms.Button btnNuevoTurnoxDia;
        private System.Windows.Forms.DataGridView dtgListaTurnoXDia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoTurnoDia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreTurnoDia;
    }
}