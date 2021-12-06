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
    public partial class frmMantenimientoSubGenerica2 : Form
    {
        public cSubgenerica2 oSubgenerica2;

        public frmMantenimientoSubGenerica2()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                oSubgenerica2.Codigo = lblGenerica.Text + txtCodigo.Text;
                oSubgenerica2.Nombre = txtNombre.Text;
                oSubgenerica2.Descripcion = txtDescripcion.Text;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Iniciar()
        {
            lblGenerica.Text = oSubgenerica2.Subgenerica.Codigo + ".";
            if (oSubgenerica2.Codigo != "")
            {
                txtCodigo.Text = oSubgenerica2.Codigo.Substring(oSubgenerica2.Codigo.LastIndexOf(".")+1, 1);
            }
            else
            {
                txtCodigo.Text = oSubgenerica2.Codigo;
            }
            
            txtNombre.Text = oSubgenerica2.Nombre;
            txtDescripcion.Text = oSubgenerica2.Descripcion;
        }

        private void frmMantenimientoSubGenerica2_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
