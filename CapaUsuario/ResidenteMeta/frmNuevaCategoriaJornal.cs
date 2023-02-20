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


namespace CapaUsuario.ResidenteMeta
{
    
    public partial class frmNuevaCategoriaJornal : Form
    {
        public CapaDeNegocios.Obras.cMetaJornal oMetaJornal;

        public frmNuevaCategoriaJornal()
        {
            InitializeComponent();
        }

        private void frmNuevaCategoriaJornal_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            txtNombreCategoria.Text = oMetaJornal.Categoria;
            txtMonto.Text = oMetaJornal.Jornal.ToString();
            txtMensual.Text = oMetaJornal.Mensual.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreCategoria.Text.Trim() == "" || txtMonto.Text.Trim() == "" || txtMensual.Text.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar un nombre/ monto y monto mensual de la categoria.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    oMetaJornal.Categoria = txtNombreCategoria.Text;
                    oMetaJornal.Jornal = Convert.ToDouble(txtMonto.Text);
                    oMetaJornal.Mensual = Convert.ToDouble(txtMensual.Text);
                    if (cboOpcion.Text == "Jornal")
                    {
                        oMetaJornal.Opcion = false;
                    }
                    else
                    {
                        oMetaJornal.Opcion = true;
                    }

                    DialogResult = DialogResult.OK;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en crear/ modificar la categoria: " + ex.Message);
            }
        }

        

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( char.IsNumber(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
