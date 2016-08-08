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
    public partial class frmMaestroDescuentos : Form
    {
        int sidtmaestrodescuentos = 0;
        int iAccion;

        public frmMaestroDescuentos()
        {
            InitializeComponent();
        }

        private void frmMaestroDescuentos_Load(object sender, EventArgs e)
        {

        }

        private void btnFormula_Click(object sender, EventArgs e)
        {
            CapaUsuario.Sunat.frmFormula fFormula = new CapaUsuario.Sunat.frmFormula();
            fFormula.RecibirDatos(txtFormula.Text);
            if (fFormula.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFormula.Text = fFormula.Formula();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool bOk = false;
            CapaDeNegocios.Sunat.cMaestroDescuentos miMaestroDescuentos = new CapaDeNegocios.Sunat.cMaestroDescuentos();
            miMaestroDescuentos.IdtMaestroDescuentos = sidtmaestrodescuentos;
            miMaestroDescuentos.Codigo = txtCodigo.Text;
            miMaestroDescuentos.Descripcion = txtDescripcion.Text;
            miMaestroDescuentos.Calculo = txtFormula.Text;
            miMaestroDescuentos.Abreviacion = txtAbreviacion.Text;

            if (iAccion == 1)
            {
                miMaestroDescuentos.CrearMaestroDescuentos(miMaestroDescuentos);
                bOk = true;
            }
            if (iAccion == 2)
            {
                miMaestroDescuentos.ModificarMaestroDescuentos(miMaestroDescuentos);
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

        public void RecibirDatos(int pidtmaestrodescuentos, string pcodigo, string pdescripcion, string pcalculo,string pAbreviacion, int piAccion)
        {
            sidtmaestrodescuentos = pidtmaestrodescuentos;
            txtCodigo.Text = pcodigo;
            txtDescripcion.Text = pdescripcion;
            txtFormula.Text = pcalculo;
            txtAbreviacion.Text = pAbreviacion;
            iAccion = piAccion;
        }
    }
}
