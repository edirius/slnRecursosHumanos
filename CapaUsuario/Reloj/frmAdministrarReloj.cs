using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios;

namespace CapaUsuario.Reloj
{
    public partial class frmAdministrarReloj : Form
    {
        public CapaDeNegocios.Reloj.cServidorReloj oServidorReloj;

        public frmAdministrarReloj()
        {
            InitializeComponent();
        }

        private void frmAdministrarReloj_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            
        }

        private void btnConectarReloj_Click(object sender, EventArgs e)
        {
            try
            {
                oServidorReloj.Reloj.IP = txtIP.Text;
                oServidorReloj.Reloj.NumeroMaquina = Convert.ToInt16(txtNumeroMaquina.Text);
                oServidorReloj.Reloj.Puerto = Convert.ToInt16(txtPuerto.Text);

                if (oServidorReloj.ConectarRelojXIP(ref oServidorReloj.Reloj) == 1)
                {
                    MessageBox.Show("El reloj esta conectado.", "Conectar Reloj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    oServidorReloj.sta_GetDeviceInfo(oServidorReloj.Reloj);
                    txtDeviceName.Text = oServidorReloj.Reloj.SDeviceName;
                    txtFirmwareVer.Text = oServidorReloj.Reloj.SFirmver;
                    txtSerialNumber.Text = oServidorReloj.Reloj.SSN;
                    txtPlatForm.Text = oServidorReloj.Reloj.SPlatform;
                    txtMac.Text = oServidorReloj.Reloj.SMac;
                    txtManufacturer.Text = oServidorReloj.Reloj.SProducter;
                    txtFaceAlg.Text = oServidorReloj.Reloj.IFaceAlg.ToString();
                    txtFPAlg.Text = oServidorReloj.Reloj.IFPAlg.ToString();
                    txtManufactureTime.Text = oServidorReloj.Reloj.SProductTime;

                }
                else
                {
                    MessageBox.Show("No se puede conectar.", "Conectar Reloj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 

            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al conectar reloj: " + ex.Message);
            }
        }

        private void btnGetDataInfo_Click(object sender, EventArgs e)
        {
            try
            {
                oServidorReloj.sta_GetCapacityInfo(oServidorReloj.Reloj);

                txtUserCnt.Text = oServidorReloj.Reloj.UserCount.ToString();
                txtAttLogCnt.Text = oServidorReloj.Reloj.RecordCnt.ToString();
                txtFaceCnt.Text = oServidorReloj.Reloj.FaceCnt.ToString();
                txtAdminCnt.Text = oServidorReloj.Reloj.AdminCnt.ToString();
                txtFPCnt.Text = oServidorReloj.Reloj.FpCnt.ToString();
                txtPWDCnt.Text = oServidorReloj.Reloj.PwdCnt.ToString();
                txtOpLogCnt.Text = oServidorReloj.Reloj.OplogCnt.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la capacidad del reloj: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
