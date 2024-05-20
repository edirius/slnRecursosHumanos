namespace CapaUsuario.Reportes
{
    partial class frmOpcionExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpcionExcel));
            this.btnTipo2 = new System.Windows.Forms.Button();
            this.btnTipo1 = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTipo2
            // 
            this.btnTipo2.BackgroundImage = global::CapaUsuario.Properties.Resources.exportacionexcel02;
            this.btnTipo2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTipo2.Location = new System.Drawing.Point(203, 33);
            this.btnTipo2.Name = "btnTipo2";
            this.btnTipo2.Size = new System.Drawing.Size(140, 155);
            this.btnTipo2.TabIndex = 1;
            this.btnTipo2.UseVisualStyleBackColor = true;
            this.btnTipo2.Click += new System.EventHandler(this.btnTipo2_Click);
            // 
            // btnTipo1
            // 
            this.btnTipo1.BackgroundImage = global::CapaUsuario.Properties.Resources.exportacionexcel01;
            this.btnTipo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTipo1.Location = new System.Drawing.Point(39, 33);
            this.btnTipo1.Name = "btnTipo1";
            this.btnTipo1.Size = new System.Drawing.Size(140, 155);
            this.btnTipo1.TabIndex = 0;
            this.btnTipo1.UseVisualStyleBackColor = true;
            this.btnTipo1.Click += new System.EventHandler(this.btnTipo1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.MintCream;
            this.btnCancelar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCancelar.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnCancelar.Location = new System.Drawing.Point(526, 258);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 56);
            this.btnCancelar.TabIndex = 88;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmOpcionExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 326);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnTipo2);
            this.Controls.Add(this.btnTipo1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOpcionExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opciones Exportacion";
            this.Load += new System.EventHandler(this.frmOpcionExcel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTipo1;
        private System.Windows.Forms.Button btnTipo2;
        private System.Windows.Forms.Button btnCancelar;
    }
}