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
    public partial class frmCambiarString : Form
    {
        public string StringSeleccionado;

        public frmCambiarString()
        {
            InitializeComponent();
        }

        private void frmCambiarString_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            txtString.Text = StringSeleccionado;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            StringSeleccionado = txtString.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
