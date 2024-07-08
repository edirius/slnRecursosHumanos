using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios.Asistencia;

namespace CapaUsuario.Asistencia
{
    public partial class frmMantenimientoTipoSalida : Form
    {
        public cTipoSalida TipoSalida;

        public frmMantenimientoTipoSalida()
        {
            InitializeComponent();
        }

        private void frmMantenimientoTipoSalida_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            txtDescripcion.Text = TipoSalida.Descripcion;
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            lblContador.Text = txtDescripcion.Text.Length + "/45";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text.Length > 0)
            {
                TipoSalida.Descripcion = txtDescripcion.Text;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("La descripcion debe contener al menos un caracter");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
