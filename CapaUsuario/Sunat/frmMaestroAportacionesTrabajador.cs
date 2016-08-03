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
    public partial class frmMaestroAportacionesTrabajador : Form
    {
        int sidtmaestroaportacionestrabajador = 0;
        int iAccion;

        public frmMaestroAportacionesTrabajador()
        {
            InitializeComponent();
        }

        private void frmMaestroAportacionesTrabajador_Load(object sender, EventArgs e)
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
            CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador miMaestroAportacionesTrabajador = new CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador();
            miMaestroAportacionesTrabajador.IdtMaestroAportacionesTrabajador = sidtmaestroaportacionestrabajador;
            miMaestroAportacionesTrabajador.Codigo = txtCodigo.Text;
            miMaestroAportacionesTrabajador.Descripcion = txtDescripcion.Text;
            miMaestroAportacionesTrabajador.Calculo = txtFormula.Text;

            if (iAccion == 1)
            {
                miMaestroAportacionesTrabajador.CrearMaestroAportacionesTrabajador(miMaestroAportacionesTrabajador);
                bOk = true;
            }
            if (iAccion == 2)
            {
                miMaestroAportacionesTrabajador.ModificarMaestroAportacionesTrabajador(miMaestroAportacionesTrabajador);
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

        public void RecibirDatos(int pidtmaestroaportacionestrabajador, string pcodigo, string pdescripcion, string pcalculo, int piAccion)
        {
            sidtmaestroaportacionestrabajador = pidtmaestroaportacionestrabajador;
            txtCodigo.Text = pcodigo;
            txtDescripcion.Text = pdescripcion;
            txtFormula.Text = pcalculo;
            iAccion = piAccion;
        }
    }
}
