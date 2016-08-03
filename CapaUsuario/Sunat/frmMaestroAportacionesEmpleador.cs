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
    public partial class frmMaestroAportacionesEmpleador : Form
    {
        int sidtmaestroaportacionesempleador = 0;
        int iAccion;

        public frmMaestroAportacionesEmpleador()
        {
            InitializeComponent();
        }

        private void frmMaestroAportacionesEmpleador_Load(object sender, EventArgs e)
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
            CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador miMaestroAportacionesEmpleador = new CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador();
            miMaestroAportacionesEmpleador.IdtMaestroAportacionesEmpleador = sidtmaestroaportacionesempleador;
            miMaestroAportacionesEmpleador.Codigo = txtCodigo.Text;
            miMaestroAportacionesEmpleador.Descripcion = txtDescripcion.Text;
            miMaestroAportacionesEmpleador.Calculo = txtFormula.Text;

            if (iAccion == 1)
            {
                miMaestroAportacionesEmpleador.CrearMaestroAportacionesEmpleador(miMaestroAportacionesEmpleador);
                bOk = true;
            }
            if (iAccion == 2)
            {
                miMaestroAportacionesEmpleador.ModificarMaestroAportacionesEmpleador(miMaestroAportacionesEmpleador);
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

        public void RecibirDatos(int pidtmaestroaportacionesempleador, string pcodigo, string pdescripcion, string pcalculo, int piAccion)
        {
            sidtmaestroaportacionesempleador = pidtmaestroaportacionesempleador;
            txtCodigo.Text = pcodigo;
            txtDescripcion.Text = pdescripcion;
            txtFormula.Text = pcalculo;
            iAccion = piAccion;
        }
    }
}
