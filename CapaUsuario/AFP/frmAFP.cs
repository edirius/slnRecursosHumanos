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
    public partial class frmAFP : Form
    {
        public cAFP miAFP;

        public frmAFP()
        {
            InitializeComponent();
            //Iniciar();
        }

        private void Iniciar()
        {
            txtNOmbreAFP.Text = miAFP.Nombre;
            txtCodigoSunat.Text = miAFP.Codigosunat;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            miAFP.Nombre = txtNOmbreAFP.Text;
            miAFP.Codigosunat = txtCodigoSunat.Text;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void frmAFP_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void txtNOmbreAFP_TextChanged(object sender, EventArgs e)
        {
            lblContador.Text = txtNOmbreAFP.TextLength + "/44";
        }
    }
}
