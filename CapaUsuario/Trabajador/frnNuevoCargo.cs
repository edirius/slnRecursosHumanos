using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios.Contrato;

namespace CapaUsuario.Trabajador
{
    public partial class frnNuevoCargo : Form
    {
        public frnNuevoCargo()
        {
            InitializeComponent();
        }

        public cCargo miCargo;

        private void frnNuevoCargo_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            txtCargo.Text = miCargo.Descripcion;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            miCargo.Descripcion = txtCargo.Text;
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtCargo_TextChanged(object sender, EventArgs e)
        {
            lblContador.Text = txtCargo.Text.Length.ToString() + "/99";
        }
    }
}
