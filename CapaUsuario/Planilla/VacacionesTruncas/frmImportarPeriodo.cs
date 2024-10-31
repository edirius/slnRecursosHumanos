using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Planilla.VacacionesTruncas
{
    public partial class frmImportarPeriodo : Form
    {
        public frmImportarPeriodo()
        {
            InitializeComponent();
        }

        cTrabajadorBuscado oTrabajadorBuscado = new cTrabajadorBuscado();

        private void btnAgregarTrabajador_Click(object sender, EventArgs e)
        {
            frmBuscarTrabajador fBuscarTrabajador = new frmBuscarTrabajador();
            if (fBuscarTrabajador.ShowDialog() == DialogResult.OK)
            {
                oTrabajadorBuscado = fBuscarTrabajador.oTrabajadorBuscado;
                lblTrabajador.Text = "DNI: " + oTrabajadorBuscado.DNI + " " + oTrabajadorBuscado.NOMBRES + " " + oTrabajadorBuscado.APELLIDOPATERNO + " " + oTrabajadorBuscado.APELLIDOMATERNO;
            }
            else
            {
                MessageBox.Show("Se canceló la informacion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
