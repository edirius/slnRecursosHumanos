namespace CapaUsuario.Reloj
{
    partial class frmAdministrarReloj
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministrarReloj));
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumeroMaquina = new System.Windows.Forms.TextBox();
            this.btnConectarReloj = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInformacionreloj = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnGetSystemInfo = new System.Windows.Forms.Button();
            this.txtFaceAlg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPlatForm = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMac = new System.Windows.Forms.TextBox();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtFPAlg = new System.Windows.Forms.TextBox();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtFirmwareVer = new System.Windows.Forms.TextBox();
            this.txtManufactureTime = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnGetDataInfo = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFaceCnt = new System.Windows.Forms.TextBox();
            this.txtAdminCnt = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtUserCnt = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtPWDCnt = new System.Windows.Forms.TextBox();
            this.txtOpLogCnt = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.txtAttLogCnt = new System.Windows.Forms.TextBox();
            this.txtFPCnt = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(52, 16);
            this.txtIP.MaxLength = 20;
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 20);
            this.txtIP.TabIndex = 0;
            this.txtIP.Text = "192.168.100.201";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Puerto: ";
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(231, 16);
            this.txtPuerto.MaxLength = 5;
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(100, 20);
            this.txtPuerto.TabIndex = 3;
            this.txtPuerto.Text = "4370";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(375, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nro. Maquina :";
            // 
            // txtNumeroMaquina
            // 
            this.txtNumeroMaquina.Location = new System.Drawing.Point(458, 16);
            this.txtNumeroMaquina.Name = "txtNumeroMaquina";
            this.txtNumeroMaquina.Size = new System.Drawing.Size(51, 20);
            this.txtNumeroMaquina.TabIndex = 5;
            this.txtNumeroMaquina.Text = "0";
            // 
            // btnConectarReloj
            // 
            this.btnConectarReloj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConectarReloj.BackColor = System.Drawing.Color.MintCream;
            this.btnConectarReloj.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnConectarReloj.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnConectarReloj.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnConectarReloj.Location = new System.Drawing.Point(776, 16);
            this.btnConectarReloj.Name = "btnConectarReloj";
            this.btnConectarReloj.Size = new System.Drawing.Size(94, 65);
            this.btnConectarReloj.TabIndex = 100;
            this.btnConectarReloj.Text = "Conectar Reloj";
            this.btnConectarReloj.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConectarReloj.UseVisualStyleBackColor = false;
            this.btnConectarReloj.Click += new System.EventHandler(this.btnConectarReloj_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 101;
            this.label4.Text = "Informacion Reloj: ";
            // 
            // lblInformacionreloj
            // 
            this.lblInformacionreloj.AutoSize = true;
            this.lblInformacionreloj.Location = new System.Drawing.Point(130, 71);
            this.lblInformacionreloj.Name = "lblInformacionreloj";
            this.lblInformacionreloj.Size = new System.Drawing.Size(0, 13);
            this.lblInformacionreloj.TabIndex = 102;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 131);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(910, 198);
            this.tabControl1.TabIndex = 103;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnGetSystemInfo);
            this.tabPage1.Controls.Add(this.txtFaceAlg);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtPlatForm);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtMac);
            this.tabPage1.Controls.Add(this.txtDeviceName);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtSerialNumber);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.txtFPAlg);
            this.tabPage1.Controls.Add(this.txtManufacturer);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.txtFirmwareVer);
            this.tabPage1.Controls.Add(this.txtManufactureTime);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(902, 172);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Informacion Reloj";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnGetSystemInfo
            // 
            this.btnGetSystemInfo.Location = new System.Drawing.Point(721, 133);
            this.btnGetSystemInfo.Name = "btnGetSystemInfo";
            this.btnGetSystemInfo.Size = new System.Drawing.Size(151, 23);
            this.btnGetSystemInfo.TabIndex = 18;
            this.btnGetSystemInfo.Text = "Obtener Informacion Reloj";
            this.btnGetSystemInfo.UseVisualStyleBackColor = true;
            // 
            // txtFaceAlg
            // 
            this.txtFaceAlg.Location = new System.Drawing.Point(721, 58);
            this.txtFaceAlg.Name = "txtFaceAlg";
            this.txtFaceAlg.Size = new System.Drawing.Size(151, 20);
            this.txtFaceAlg.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(621, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Face Algoritmo";
            // 
            // txtPlatForm
            // 
            this.txtPlatForm.Location = new System.Drawing.Point(401, 20);
            this.txtPlatForm.Name = "txtPlatForm";
            this.txtPlatForm.Size = new System.Drawing.Size(151, 20);
            this.txtPlatForm.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Nombre Dispositivo";
            // 
            // txtMac
            // 
            this.txtMac.Location = new System.Drawing.Point(401, 55);
            this.txtMac.Name = "txtMac";
            this.txtMac.Size = new System.Drawing.Size(151, 20);
            this.txtMac.TabIndex = 15;
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Location = new System.Drawing.Point(115, 20);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.Size = new System.Drawing.Size(153, 20);
            this.txtDeviceName.TabIndex = 1;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(352, 61);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(30, 13);
            this.label21.TabIndex = 14;
            this.label21.Text = "MAC";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(331, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Plat Form";
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Location = new System.Drawing.Point(115, 96);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(153, 20);
            this.txtSerialNumber.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(621, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "FP Algoritmo";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(28, 99);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(73, 13);
            this.label20.TabIndex = 12;
            this.label20.Text = "Numero Serial";
            // 
            // txtFPAlg
            // 
            this.txtFPAlg.Location = new System.Drawing.Point(721, 20);
            this.txtFPAlg.Name = "txtFPAlg";
            this.txtFPAlg.Size = new System.Drawing.Size(151, 20);
            this.txtFPAlg.TabIndex = 5;
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Location = new System.Drawing.Point(401, 96);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(151, 20);
            this.txtManufacturer.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = " Version Firmware";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(325, 99);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 13);
            this.label19.TabIndex = 10;
            this.label19.Text = "Fabricante";
            // 
            // txtFirmwareVer
            // 
            this.txtFirmwareVer.Location = new System.Drawing.Point(115, 58);
            this.txtFirmwareVer.Name = "txtFirmwareVer";
            this.txtFirmwareVer.Size = new System.Drawing.Size(153, 20);
            this.txtFirmwareVer.TabIndex = 7;
            // 
            // txtManufactureTime
            // 
            this.txtManufactureTime.Location = new System.Drawing.Point(721, 96);
            this.txtManufactureTime.Name = "txtManufactureTime";
            this.txtManufactureTime.Size = new System.Drawing.Size(151, 20);
            this.txtManufactureTime.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(605, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Fecha Fabricacion";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnGetDataInfo);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.txtFaceCnt);
            this.tabPage2.Controls.Add(this.txtAdminCnt);
            this.tabPage2.Controls.Add(this.label24);
            this.tabPage2.Controls.Add(this.txtUserCnt);
            this.tabPage2.Controls.Add(this.label25);
            this.tabPage2.Controls.Add(this.label26);
            this.tabPage2.Controls.Add(this.txtPWDCnt);
            this.tabPage2.Controls.Add(this.txtOpLogCnt);
            this.tabPage2.Controls.Add(this.label27);
            this.tabPage2.Controls.Add(this.label28);
            this.tabPage2.Controls.Add(this.txtAttLogCnt);
            this.tabPage2.Controls.Add(this.txtFPCnt);
            this.tabPage2.Controls.Add(this.label29);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(902, 172);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Capacidad Reloj";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnGetDataInfo
            // 
            this.btnGetDataInfo.Location = new System.Drawing.Point(623, 131);
            this.btnGetDataInfo.Name = "btnGetDataInfo";
            this.btnGetDataInfo.Size = new System.Drawing.Size(176, 23);
            this.btnGetDataInfo.TabIndex = 26;
            this.btnGetDataInfo.Text = "Obtener capacidad dispositivo";
            this.btnGetDataInfo.UseVisualStyleBackColor = true;
            this.btnGetDataInfo.Click += new System.EventHandler(this.btnGetDataInfo_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(46, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Nro. Face";
            // 
            // txtFaceCnt
            // 
            this.txtFaceCnt.Location = new System.Drawing.Point(137, 108);
            this.txtFaceCnt.Name = "txtFaceCnt";
            this.txtFaceCnt.Size = new System.Drawing.Size(123, 20);
            this.txtFaceCnt.TabIndex = 24;
            // 
            // txtAdminCnt
            // 
            this.txtAdminCnt.Location = new System.Drawing.Point(405, 31);
            this.txtAdminCnt.Name = "txtAdminCnt";
            this.txtAdminCnt.Size = new System.Drawing.Size(121, 20);
            this.txtAdminCnt.TabIndex = 15;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(48, 31);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(71, 13);
            this.label24.TabIndex = 12;
            this.label24.Text = "Nro. Usuarios";
            // 
            // txtUserCnt
            // 
            this.txtUserCnt.Location = new System.Drawing.Point(137, 31);
            this.txtUserCnt.Name = "txtUserCnt";
            this.txtUserCnt.Size = new System.Drawing.Size(123, 20);
            this.txtUserCnt.TabIndex = 13;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(323, 34);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(59, 13);
            this.label25.TabIndex = 14;
            this.label25.Text = "Nro. Admin";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(594, 31);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(51, 13);
            this.label26.TabIndex = 16;
            this.label26.Text = "Nro. Pwd";
            // 
            // txtPWDCnt
            // 
            this.txtPWDCnt.Location = new System.Drawing.Point(678, 28);
            this.txtPWDCnt.Name = "txtPWDCnt";
            this.txtPWDCnt.Size = new System.Drawing.Size(121, 20);
            this.txtPWDCnt.TabIndex = 17;
            // 
            // txtOpLogCnt
            // 
            this.txtOpLogCnt.Location = new System.Drawing.Point(678, 68);
            this.txtOpLogCnt.Name = "txtOpLogCnt";
            this.txtOpLogCnt.Size = new System.Drawing.Size(121, 20);
            this.txtOpLogCnt.TabIndex = 23;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(39, 73);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(69, 13);
            this.label27.TabIndex = 18;
            this.label27.Text = "AttLog Count";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(587, 72);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(58, 13);
            this.label28.TabIndex = 22;
            this.label28.Text = "Nro. Oplog";
            // 
            // txtAttLogCnt
            // 
            this.txtAttLogCnt.Location = new System.Drawing.Point(137, 70);
            this.txtAttLogCnt.Name = "txtAttLogCnt";
            this.txtAttLogCnt.Size = new System.Drawing.Size(123, 20);
            this.txtAttLogCnt.TabIndex = 19;
            // 
            // txtFPCnt
            // 
            this.txtFPCnt.Location = new System.Drawing.Point(405, 69);
            this.txtFPCnt.Name = "txtFPCnt";
            this.txtFPCnt.Size = new System.Drawing.Size(121, 20);
            this.txtFPCnt.TabIndex = 21;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(317, 73);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(65, 13);
            this.label29.TabIndex = 20;
            this.label29.Text = "Nro. Huellas";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.MintCream;
            this.btnGuardar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnGuardar.ImageKey = "NetByte Design Studio - 0849.png";
            this.btnGuardar.Location = new System.Drawing.Point(776, 87);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(94, 65);
            this.btnGuardar.TabIndex = 104;
            this.btnGuardar.Text = "Guardar Reloj";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmAdministrarReloj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 336);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblInformacionreloj);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnConectarReloj);
            this.Controls.Add(this.txtNumeroMaquina);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPuerto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministrarReloj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar Reloj";
            this.Load += new System.EventHandler(this.frmAdministrarReloj_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumeroMaquina;
        private System.Windows.Forms.Button btnConectarReloj;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInformacionreloj;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnGetSystemInfo;
        private System.Windows.Forms.TextBox txtFaceAlg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPlatForm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMac;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtFPAlg;
        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtFirmwareVer;
        private System.Windows.Forms.TextBox txtManufactureTime;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnGetDataInfo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFaceCnt;
        private System.Windows.Forms.TextBox txtAdminCnt;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtUserCnt;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtPWDCnt;
        private System.Windows.Forms.TextBox txtOpLogCnt;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtAttLogCnt;
        private System.Windows.Forms.TextBox txtFPCnt;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btnGuardar;
    }
}