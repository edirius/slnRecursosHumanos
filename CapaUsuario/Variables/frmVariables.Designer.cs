namespace CapaUsuario.Variables
{
    partial class frmVariables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVariables));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.nudSueldoMinimo = new System.Windows.Forms.NumericUpDown();
            this.nudUIT = new System.Windows.Forms.NumericUpDown();
            this.nudDieta = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudSueldoMinimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUIT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDieta)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.MintCream;
            this.btnCancelar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelar.ImageKey = "NetByte Design Studio - 0957.png";
            this.btnCancelar.Location = new System.Drawing.Point(178, 119);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 65);
            this.btnCancelar.TabIndex = 78;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.BackColor = System.Drawing.Color.MintCream;
            this.btnAceptar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAceptar.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnAceptar.Location = new System.Drawing.Point(97, 119);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 65);
            this.btnAceptar.TabIndex = 77;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "UIT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sueldo Minimo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Año";
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(94, 12);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(159, 21);
            this.cboAño.TabIndex = 81;
            this.cboAño.SelectedIndexChanged += new System.EventHandler(this.cboAño_SelectedIndexChanged);
            // 
            // nudSueldoMinimo
            // 
            this.nudSueldoMinimo.DecimalPlaces = 2;
            this.nudSueldoMinimo.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudSueldoMinimo.Location = new System.Drawing.Point(94, 39);
            this.nudSueldoMinimo.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudSueldoMinimo.Name = "nudSueldoMinimo";
            this.nudSueldoMinimo.Size = new System.Drawing.Size(159, 20);
            this.nudSueldoMinimo.TabIndex = 82;
            // 
            // nudUIT
            // 
            this.nudUIT.DecimalPlaces = 2;
            this.nudUIT.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudUIT.Location = new System.Drawing.Point(94, 65);
            this.nudUIT.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudUIT.Name = "nudUIT";
            this.nudUIT.Size = new System.Drawing.Size(159, 20);
            this.nudUIT.TabIndex = 83;
            // 
            // nudDieta
            // 
            this.nudDieta.DecimalPlaces = 2;
            this.nudDieta.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudDieta.Location = new System.Drawing.Point(94, 91);
            this.nudDieta.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudDieta.Name = "nudDieta";
            this.nudDieta.Size = new System.Drawing.Size(159, 20);
            this.nudDieta.TabIndex = 85;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 84;
            this.label4.Text = "Dieta";
            // 
            // frmVariables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 196);
            this.Controls.Add(this.nudDieta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudUIT);
            this.Controls.Add(this.nudSueldoMinimo);
            this.Controls.Add(this.cboAño);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVariables";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Variables";
            this.Load += new System.EventHandler(this.frmVariables_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSueldoMinimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUIT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDieta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.NumericUpDown nudSueldoMinimo;
        private System.Windows.Forms.NumericUpDown nudUIT;
        private System.Windows.Forms.NumericUpDown nudDieta;
        private System.Windows.Forms.Label label4;
    }
}