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
           
            txtNOmbreAFP.Text  = miAFP.Nombre;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            miAFP.Nombre = txtNOmbreAFP.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void frmAFP_Load(object sender, EventArgs e)
        {
            txtNOmbreAFP.Text = miAFP.Nombre;
        }
    }
}
