using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Sunat
{
    public partial class frmMaestroIngresos : Form
    {
        int sidtmaestroingresos = 0;
        int iAccion;

        public frmMaestroIngresos()
        {
            InitializeComponent();
        }

        private void frmMaestroIngresos_Load(object sender, EventArgs e)
        {

        }

        private void btnFormula_Click(object sender, EventArgs e)
        {
            CapaUsuario.Sunat.frmFormula fFormula= new CapaUsuario.Sunat.frmFormula();
            fFormula.RecibirDatos(txtFormula.Text);
            if (fFormula.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFormula.Text = fFormula.Formula();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool bOk = false;
            CapaDeNegocios.Sunat.cMaestroIngresos miMaestroIngresos = new CapaDeNegocios.Sunat.cMaestroIngresos();
            miMaestroIngresos.IdtMaestroIngresos = sidtmaestroingresos;
            miMaestroIngresos.Codigo = txtCodigo.Text;
            miMaestroIngresos.Descripcion = txtDescripcion.Text;
            miMaestroIngresos.Essalud_trabajador = chkEssalud_trabajador.Checked;
            miMaestroIngresos.Essalud_cbssp = chkEssalud_cbssp.Checked;
            miMaestroIngresos.Essalud_agrario = chkEssalud_agrario.Checked;
            miMaestroIngresos.Essalud_sctr = chkEssalud_sctr.Checked;
            miMaestroIngresos.Impuesto_extraord = chkImpuesto_extraord.Checked;
            miMaestroIngresos.Derechos_sociales = chkDerechos_sociales.Checked;
            miMaestroIngresos.Senati = chkSenati.Checked;
            miMaestroIngresos.Snp = chkSnp.Checked;
            miMaestroIngresos.Spp = chkSpp.Checked;
            miMaestroIngresos.Renta_5ta = chkRenta_5ta.Checked;
            miMaestroIngresos.Essalud_pensionista = chkEssalud_pensionista.Checked;
            miMaestroIngresos.Contrib_solidaria = chkContrib_solidaria.Checked;
            miMaestroIngresos.Calculo = txtFormula.Text;
            miMaestroIngresos.Tipo = txtTipo.Text;

            if (iAccion == 1)
            {
                miMaestroIngresos.CrearMaestroIngresos(miMaestroIngresos);
                bOk = true;
            }
            if (iAccion == 2)
            {
                miMaestroIngresos.ModificarMaestroIngresos(miMaestroIngresos);
                bOk = true;
            }
            if (bOk == true)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("No se puede registrar estos datos", "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public void RecibirDatos(int pidtmaestroingresos, string pcodigo, string pdescripcion, bool pessalud_trabajador, bool pessalud_cbssp, bool pessalud_agrario, bool pessalud_sctr, bool pimpuesto_extraord, bool pderechos_sociales, bool psenati, bool psnp, bool pspp, bool prenta_5ta, bool pessalud_pensionista, bool pcontrib_solidaria, string pcalculo, string ptipo, int piAccion)
        {
            sidtmaestroingresos = pidtmaestroingresos;
            txtCodigo.Text = pcodigo;
            txtDescripcion.Text = pdescripcion;
            chkEssalud_trabajador.Checked = pessalud_trabajador;
            chkEssalud_cbssp.Checked = pessalud_cbssp;
            chkEssalud_agrario.Checked = pessalud_agrario;
            chkEssalud_sctr.Checked = pessalud_sctr;
            chkImpuesto_extraord.Checked = pimpuesto_extraord;
            chkDerechos_sociales.Checked = pderechos_sociales;
            chkSenati.Checked = psenati;
            chkSnp.Checked = psnp;
            chkSpp.Checked = pspp;
            chkRenta_5ta.Checked = prenta_5ta;
            chkEssalud_pensionista.Checked = pessalud_pensionista;
            chkContrib_solidaria.Checked = pcontrib_solidaria;
            txtFormula.Text = pcalculo;
            txtTipo.Text = ptipo;
            iAccion = piAccion;
        }
    }
}
