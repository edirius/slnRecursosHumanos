namespace CapaUsuario.Planilla
{
    partial class frmImpuestoAlaRentaDe5taCategoria
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
            this.label14 = new System.Windows.Forms.Label();
            this.txtIRM = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btncalcular = new System.Windows.Forms.Button();
            this.txtRetencionesAnteriores = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemAnteriores = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.txtGrati = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIngresos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUIT = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbAños = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(344, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(28, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "UIT:";
            // 
            // txtIRM
            // 
            this.txtIRM.Location = new System.Drawing.Point(202, 276);
            this.txtIRM.Name = "txtIRM";
            this.txtIRM.Size = new System.Drawing.Size(77, 20);
            this.txtIRM.TabIndex = 39;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(40, 279);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(148, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "Impuesto a la Renta Mensual:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btncalcular);
            this.groupBox2.Controls.Add(this.txtRetencionesAnteriores);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtRemAnteriores);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cbMes);
            this.groupBox2.Controls.Add(this.txtIRM);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtGrati);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtIngresos);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(26, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 321);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Calculo del Impuesto";
            // 
            // btncalcular
            // 
            this.btncalcular.Location = new System.Drawing.Point(156, 202);
            this.btncalcular.Name = "btncalcular";
            this.btncalcular.Size = new System.Drawing.Size(144, 38);
            this.btncalcular.TabIndex = 46;
            this.btncalcular.Text = "Calcular";
            this.btncalcular.UseVisualStyleBackColor = true;
            this.btncalcular.Click += new System.EventHandler(this.btncalcular_Click);
            // 
            // txtRetencionesAnteriores
            // 
            this.txtRetencionesAnteriores.Location = new System.Drawing.Point(202, 158);
            this.txtRetencionesAnteriores.Name = "txtRetencionesAnteriores";
            this.txtRetencionesAnteriores.Size = new System.Drawing.Size(77, 20);
            this.txtRetencionesAnteriores.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "Retenciones de Meses Anteriores:";
            // 
            // txtRemAnteriores
            // 
            this.txtRemAnteriores.Location = new System.Drawing.Point(200, 89);
            this.txtRemAnteriores.Name = "txtRemAnteriores";
            this.txtRemAnteriores.Size = new System.Drawing.Size(100, 20);
            this.txtRemAnteriores.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Remuneración de Meses Anteriores:";
            // 
            // cbMes
            // 
            this.cbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbMes.Location = new System.Drawing.Point(202, 122);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(121, 21);
            this.cbMes.TabIndex = 24;
            // 
            // txtGrati
            // 
            this.txtGrati.Location = new System.Drawing.Point(202, 61);
            this.txtGrati.Name = "txtGrati";
            this.txtGrati.Size = new System.Drawing.Size(100, 20);
            this.txtGrati.TabIndex = 6;
            this.txtGrati.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGrati_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Gratificaciones:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mes:";
            // 
            // txtIngresos
            // 
            this.txtIngresos.Location = new System.Drawing.Point(202, 35);
            this.txtIngresos.Name = "txtIngresos";
            this.txtIngresos.Size = new System.Drawing.Size(100, 20);
            this.txtIngresos.TabIndex = 1;
            this.txtIngresos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIngresos_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Remuneración Mensual:";
            // 
            // cbUIT
            // 
            this.cbUIT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cbUIT.FormattingEnabled = true;
            this.cbUIT.Location = new System.Drawing.Point(379, 13);
            this.cbUIT.Name = "cbUIT";
            this.cbUIT.Size = new System.Drawing.Size(91, 21);
            this.cbUIT.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(198, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 44;
            this.label8.Text = "Año:";
            // 
            // cbAños
            // 
            this.cbAños.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAños.FormattingEnabled = true;
            this.cbAños.Location = new System.Drawing.Point(234, 13);
            this.cbAños.Name = "cbAños";
            this.cbAños.Size = new System.Drawing.Size(88, 21);
            this.cbAños.TabIndex = 45;
            this.cbAños.SelectedIndexChanged += new System.EventHandler(this.cbAños_SelectedIndexChanged);
            // 
            // frmImpuestoAlaRentaDe5taCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 377);
            this.Controls.Add(this.cbAños);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbUIT);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmImpuestoAlaRentaDe5taCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmImpuestoAlaRentaDe5taCategoria";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtIRM;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.TextBox txtGrati;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIngresos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbUIT;
        private System.Windows.Forms.TextBox txtRetencionesAnteriores;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRemAnteriores;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbAños;
        private System.Windows.Forms.Button btncalcular;
    }
}