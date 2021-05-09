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
    public partial class frmMantenimientoEspecifica2 : Form
    {
        public cEspecifica2 oEspecifica2;

        public frmMantenimientoEspecifica2()
        {
            InitializeComponent();
        }

        private void frmMantenimientoEspecifica2_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        public void Iniciar()
        {
            lblGenerica.Text = oEspecifica2.Especifica.Codigo + ".";

            if (oEspecifica2.Codigo != "")
            {
                txtCodigo.Text = oEspecifica2.Codigo.Substring(oEspecifica2.Codigo.LastIndexOf(".")+1, oEspecifica2.Codigo.Length - (oEspecifica2.Codigo.LastIndexOf(".")+1));
            }
            else
            {
                txtCodigo.Text = oEspecifica2.Codigo;
            }
            txtNombre.Text = oEspecifica2.Nombre;
            txtDescripcion.Text = oEspecifica2.Descripcion;
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                oEspecifica2.Codigo = lblGenerica.Text + txtCodigo.Text;
                oEspecifica2.Nombre = txtNombre.Text;
                oEspecifica2.Descripcion = txtDescripcion.Text;
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
