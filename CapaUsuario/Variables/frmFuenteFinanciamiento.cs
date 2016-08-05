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
    public partial class frmFuenteFinanciamiento : Form
    {
        int iAccion = 0;
        int sidtfuentefinanciamiento = 0;

        public frmFuenteFinanciamiento()
        {
            InitializeComponent();
        }

        private void frmFuenteFinanciamiento_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool bOk = false;
            CapaDeNegocios.cFuenteFinanciamiento miFuenteFinanciamiento = new CapaDeNegocios.cFuenteFinanciamiento();
            miFuenteFinanciamiento.IdTFuenteFinanciamiento = sidtfuentefinanciamiento;
            miFuenteFinanciamiento.Codigo = txtCodigo.Text;
            miFuenteFinanciamiento.Descripcion = txtDescripcion.Text;

            if (iAccion == 1)
            {
                miFuenteFinanciamiento.CrearFuenteFinanciamiento(miFuenteFinanciamiento);
                bOk = true;
            }
            if (iAccion == 2)
            {
                miFuenteFinanciamiento.ModificarFuenteFinanciamiento(miFuenteFinanciamiento);
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

        public void RecibirDatos(int pidtfuentefinanciamiento, string pcodigo, string pdescripcion, int pAccion)
        {
            sidtfuentefinanciamiento = pidtfuentefinanciamiento;
            txtCodigo.Text = pcodigo;
            txtDescripcion.Text = pdescripcion;
            iAccion = pAccion;
        }
    }
}
