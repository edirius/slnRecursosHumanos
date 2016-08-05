using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Planilla
{
    public partial class frmPlanilla : Form
    {
        int iAccion;
        int sidtplanilla;
        int sidtmeta;
        int sidtfuentefinanciamiento;
        int sidtregimenlaboral;
        string smeta;
        string sfuentefinanciamiento;
        string saño;

        public frmPlanilla()
        {
            InitializeComponent();
        }

        private void frmPlanilla_Load(object sender, EventArgs e)
        {
            CargarAños();
            CargarMeta();
            CargarFuenteFinanciamiento();
            cboMeta_SelectedIndexChanged(sender, e);
            cboFuenteFinanciamiento_SelectedIndexChanged(sender, e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool bOk = false;
            CapaDeNegocios.Planillas.cPlanilla miPlanilla = new CapaDeNegocios.Planillas.cPlanilla();
            miPlanilla.IdtPlanilla = sidtplanilla;
            miPlanilla.Numero = txtNumero.Text;
            miPlanilla.Mes = cboMes.Text;
            miPlanilla.Año = cboAño.Text;
            miPlanilla.Fecha = dtpFecha.Value;
            miPlanilla.IdtMeta = sidtmeta;
            miPlanilla.IdtFuenteFinanciamiento = sidtfuentefinanciamiento;
            miPlanilla.IdtRegimenLaboral = sidtregimenlaboral;

            if (iAccion == 1)
            {
                miPlanilla.CrearPlanilla(miPlanilla);
                bOk = true;
            }
            if (iAccion == 2)
            {
                miPlanilla.ModificarPlanilla(miPlanilla);
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

        private void cboMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMeta.Text != "System.Data.DataRowView" && cboMeta.ValueMember != "")
            {
                sidtmeta = Convert.ToInt32(cboMeta.SelectedValue);
            }
        }

        private void cboFuenteFinanciamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFuenteFinanciamiento.Text != "System.Data.DataRowView" && cboFuenteFinanciamiento.ValueMember != "")
            {
                sidtfuentefinanciamiento = Convert.ToInt32(cboFuenteFinanciamiento.SelectedValue);
            }
        }

        public void RecibirDatos(int pidtplanilla, string pnumero, string pmes, string paño, DateTime pfecha, int pidtmeta, string pmeta, int pidtfuentefinanciamiento, string pfuentefinanciamiento, int pidtregimenlaboral, int pAccion)
        {
            sidtplanilla = pidtplanilla;
            txtNumero.Text = pnumero;
            cboMes.Text = pmes;
            saño = paño;
            dtpFecha.Value = pfecha;
            sidtmeta = pidtmeta;
            smeta = pmeta;
            sidtfuentefinanciamiento = pidtfuentefinanciamiento;
            sfuentefinanciamiento = pfuentefinanciamiento;
            sidtregimenlaboral = pidtregimenlaboral;
            iAccion = pAccion;
        }

        private void CargarAños()
        {
            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                cboAño.Items.Add(i);
            }
            if (saño == "") { cboAño.SelectedIndex = -1; }
            else { cboAño.Text = saño; }
        }

        private void CargarMeta()
        {
            CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miMeta = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
            cboMeta.DataSource = miMeta.ListarMetas();
            cboMeta.DisplayMember = "nombre";
            cboMeta.ValueMember = "idtmeta";
            if (smeta == "") { cboMeta.SelectedIndex = -1; }
            else { cboMeta.Text = smeta; }
        }

        private void CargarFuenteFinanciamiento()
        {
            CapaDeNegocios.cFuenteFinanciamiento miFuenteFinanciamiento = new CapaDeNegocios.cFuenteFinanciamiento();
            cboFuenteFinanciamiento.DataSource = miFuenteFinanciamiento.ListarFuenteFinanciamiento();
            cboFuenteFinanciamiento.DisplayMember = "descripcion";
            cboFuenteFinanciamiento.ValueMember = "idtfuentefinanciamiento";
            if (sfuentefinanciamiento == "") { cboFuenteFinanciamiento.SelectedIndex = -1; }
            else { cboFuenteFinanciamiento.Text = smeta; }
        }
    }
}
