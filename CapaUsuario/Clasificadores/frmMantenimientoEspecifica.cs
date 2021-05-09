using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios.Clasificadores;

namespace CapaUsuario.Clasificadores
{
    public partial class frmMantenimientoEspecifica : Form
    {
        public cEspecifica oEspecifica;

        public frmMantenimientoEspecifica()
        {
            InitializeComponent();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)|| char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void frmMantenimientoEspecifica_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        public void Iniciar()
        {
            lblGenerica.Text = oEspecifica.Subgenerica2.Codigo + ".";

            if (oEspecifica.Codigo != "")
            {
                txtCodigo.Text = oEspecifica.Codigo.Substring(oEspecifica.Codigo.LastIndexOf(".")+1, 1);
            }
            else
            {
                txtCodigo.Text = oEspecifica.Codigo;
            }
            txtDescripcion.Text = oEspecifica.Descripcion;
            txtNombre.Text = oEspecifica.Nombre;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                oEspecifica.Codigo = lblGenerica.Text + txtCodigo.Text;
                oEspecifica.Nombre = txtNombre.Text;
                oEspecifica.Descripcion = txtDescripcion.Text;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
