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

namespace CapaUsuario.Reloj
{
    public partial class frmMantenimientoReloj : Form
    {
        public frmMantenimientoReloj()
        {
            InitializeComponent();
        }

        public CapaDeNegocios.Reloj.cMaquinaReloj oMaquinaReloj;

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                oMaquinaReloj.Descripcion = txtDescripcion.Text;
                oMaquinaReloj.Ip = txtIP.Text;
                oMaquinaReloj.Puerto = txtPuerto.Text;
                oMaquinaReloj.Activo = chkActivo.Checked;
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMantenimientoReloj_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            txtDescripcion.Text = oMaquinaReloj.Descripcion;
            txtIP.Text = oMaquinaReloj.Ip;
            txtPuerto.Text = oMaquinaReloj.Puerto;
            chkActivo.Checked = oMaquinaReloj.Activo;
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            lblContador.Text = txtDescripcion.Text.Length + "/45";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
