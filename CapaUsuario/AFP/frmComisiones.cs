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
namespace CapaUsuario.AFP
{
    public partial class frmComisiones : Form
    {
        public cComisionesAFP miComisionAFP;

        public frmComisiones()
        {
            InitializeComponent();
        }

        private void frmComisiones_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            lblAFP.Text = "AFP :" + miComisionAFP.Afp.Nombre;           
            dtpMesComision.Value = miComisionAFP.Mes;
            numAporteO.Value = miComisionAFP.AporteObligatorio;
            numComisionF.Value = miComisionAFP.ComisionFlujo;
            numComisionM.Value = miComisionAFP.ComisionMixta;
            numComisionP.Value = miComisionAFP.PrimaSeguros;
            numRemuneracion.Value = miComisionAFP.RemuneracionAsegurable; 
        }

   

        private void btnNavegador_Click_1(object sender, EventArgs e)
        {
            this.Size = new Size(1200, 364);
            webSBS.Navigate("http://www.sbs.gob.pe/usuarios/categoria/comisiones-y-primas-de-seguro-del-spp/277/c-277");
            this.StartPosition = FormStartPosition.CenterScreen;
            //Navegador.frmNavegador miNavegador = new Navegador.frmNavegador();
            //miNavegador.Direccion = "http://www.sbs.gob.pe/usuarios/categoria/comisiones-y-primas-de-seguro-del-spp/277/c-277";
            //miNavegador.MdiParent = this.MdiParent;
            //miNavegador.Show();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            miComisionAFP.Mes = dtpMesComision.Value;
            miComisionAFP.AporteObligatorio = Convert.ToDecimal(numAporteO.Value);
            miComisionAFP.ComisionFlujo = Convert.ToDecimal(numComisionF.Value);
            miComisionAFP.ComisionMixta = Convert.ToDecimal(numComisionM.Value);
            miComisionAFP.PrimaSeguros = Convert.ToDecimal(numComisionP.Value);
            miComisionAFP.RemuneracionAsegurable = Convert.ToDecimal(numRemuneracion.Value);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
