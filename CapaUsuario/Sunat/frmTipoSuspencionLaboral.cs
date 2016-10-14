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
    public partial class frmTipoSuspencionLaboral : Form
    {
        int sidtmaestrodescuentos = 0;
        int iAccion;

        public frmTipoSuspencionLaboral()
        {
            InitializeComponent();
        }

        private void frmMaestroDescuentos_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                bool bOk = false;
                CapaDeNegocios.Sunat.cTipoSuspencionLaboral miTipoSuspencionLaboral = new CapaDeNegocios.Sunat.cTipoSuspencionLaboral();
                miTipoSuspencionLaboral.IdtTipoSuspencionLaboral = sidtmaestrodescuentos;
                miTipoSuspencionLaboral.Codigo = txtCodigo.Text;
                miTipoSuspencionLaboral.Descripcion = txtDescripcion.Text;
                miTipoSuspencionLaboral.Abreviacion = txtAbreviacion.Text;
                miTipoSuspencionLaboral.Subsidiado = chkSubsidiado.Checked;

                if (iAccion == 1)
                {
                    miTipoSuspencionLaboral.CrearTipoSuspencionLaboral(miTipoSuspencionLaboral);
                    bOk = true;
                }
                if (iAccion == 2)
                {
                    miTipoSuspencionLaboral.ModificarTipoSuspencionLaboral(miTipoSuspencionLaboral);
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
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public void RecibirDatos(int pidtmaestrodescuentos, string pcodigo, string pdescripcion, string pAbreviacion, bool psubsidiado, int piAccion)
        {
            sidtmaestrodescuentos = pidtmaestrodescuentos;
            txtCodigo.Text = pcodigo;
            txtDescripcion.Text = pdescripcion;
            txtAbreviacion.Text = pAbreviacion;
            chkSubsidiado.Checked = psubsidiado;
            iAccion = piAccion;
        }
    }
}
