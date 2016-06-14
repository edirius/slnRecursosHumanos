using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Navegador
{
    public partial class frmNavegador : Form
    {

        public string Direccion { get; set; }
        public frmNavegador()
        {
            InitializeComponent();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            webPrincipal.GoBack();
        }

        private void btnAdelante_Click(object sender, EventArgs e)
        {
            webPrincipal.GoForward();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            webPrincipal.Refresh();
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            webPrincipal.Stop();
        }

        private void btnPrincipal_Click(object sender, EventArgs e)
        {
            webPrincipal.GoHome();
        }

        private void btnIra_Click(object sender, EventArgs e)
        {
            webPrincipal.Navigate(txtDireccion.Text);
        }

        private void frmNavegador_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            webPrincipal.Navigate(Direccion);
            txtDireccion.Text = Direccion;
        }
    }
}
