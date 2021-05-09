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

namespace CapaUsuario.Clasificadores
{
    public partial class frmNuevoGenerica : Form
    {

        public CapaDeNegocios.Clasificadores.cGenerica oGenerica;
        public frmNuevoGenerica()
        {
            InitializeComponent();
        }

        private void frmNuevoGenerica_Load(object sender, EventArgs e)
        {
            Iniciar();
        }


        private void Iniciar()
        {
            lblGenerica.Text = "2.";
            if (oGenerica.Codigo != "")
            {
                txtCodigo.Text = oGenerica.Codigo.Substring(oGenerica.Codigo.IndexOf(".")+1, 1);
            }
            else
            {
                txtCodigo.Text = oGenerica.Codigo;
            }
            txtNombre.Text = oGenerica.Nombre;
            txtDescripcion.Text = oGenerica.Descripcion;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtCodigo.Text == "")
                {
                    MessageBox.Show("Debe escribir un codigo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    oGenerica.Codigo = lblGenerica.Text + txtCodigo.Text;
                    oGenerica.Nombre = txtNombre.Text;
                    oGenerica.Descripcion = txtDescripcion.Text;
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar los datos de la generica: " + ex.Message);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
