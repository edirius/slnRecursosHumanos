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
    public partial class frmMantenimientoSubGenerica : Form
    {

        public cSubgenerica oSubgenerica;
        public frmMantenimientoSubGenerica()
        {
            InitializeComponent();
        }

        private void frmMantenimientoSubGenerica_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            lblGenerica.Text = oSubgenerica.Generica.Codigo + ".";
            if (oSubgenerica.Codigo != "")
            {
                txtCodigo.Text = oSubgenerica.Codigo.Substring(oSubgenerica.Codigo.LastIndexOf(".")+1,1);
            }
           else
            {
                txtCodigo.Text = oSubgenerica.Codigo;
            }
            txtNombre.Text = oSubgenerica.Nombre;
            txtDescripcion.Text = oSubgenerica.Descripcion;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                oSubgenerica.Codigo = lblGenerica.Text + txtCodigo.Text;
                oSubgenerica.Nombre = txtNombre.Text;
                oSubgenerica.Descripcion = txtDescripcion.Text;
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
