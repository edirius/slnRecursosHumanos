using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Variables
{
    public partial class frmVariables : Form
    {
        int iAccion = 0;
        int sidtvariables = 0;
        string saño = "";

        public frmVariables()
        {
            InitializeComponent();
        }

        private void frmVariables_Load(object sender, EventArgs e)
        {
            CargarAños();
        }

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool bOk = false;
            CapaDeNegocios.cVariables miVariables = new CapaDeNegocios.cVariables();
            miVariables.IdtVariables = sidtvariables;
            miVariables.Año = cboAño.Text; ;
            miVariables.SueldoMinimo = Convert.ToInt32(nudSueldoMinimo.Value);
            miVariables.UIT = Convert.ToInt32(nudUIT.Value);
            miVariables.Dieta = Convert.ToInt32(nudDieta.Value);

            if (iAccion == 1)
            {
                miVariables.CrearVariables(miVariables);
                bOk = true;
            }
            if (iAccion == 2)
            {
                miVariables.ModificarVariables(miVariables);
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

        public void RecibirDatos(int pidtvariables, string paño, decimal psueldominimo, decimal puit, decimal pdieta, int pAccion)
        {
            sidtvariables = pidtvariables;
            saño = paño;
            nudSueldoMinimo.Value = psueldominimo;
            nudUIT.Value = puit;
            nudDieta.Value = pdieta;
            iAccion = pAccion;
        }

        private void CargarAños()
        {
            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                cboAño.Items.Add(i);
            }
            cboAño.Text = saño;
        }
    }
}
