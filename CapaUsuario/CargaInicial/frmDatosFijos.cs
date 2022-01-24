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


namespace CapaUsuario.CargaInicial
{
    public partial class frmDatosFijos : Form
    {
        public cNacionalidad miNacionalidad;
        public cDistrito miDistrito;
        public cTipoVia miTipoVia;
        public cTipoZona miTipoZona;

        private cDepartamento miDepartamento = new cDepartamento();
        private cProvincia miProvincia = new cProvincia();
       


        public frmDatosFijos()
        {
            InitializeComponent();
        }

        private void btnNacionalidad_Click(object sender, EventArgs e)
        {
            Trabajador.frmNacionalidad fNacionalidad = new Trabajador.frmNacionalidad();
            if (fNacionalidad.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                miNacionalidad = fNacionalidad.miNacionalidad;
                txtNacionalidad.Text = miNacionalidad.Descripcion;
            }
        }

        private void btnApartamento_Click(object sender, EventArgs e)
        {
            Trabajador.frmDepartamento fDepartamento = new Trabajador.frmDepartamento();
            if (fDepartamento.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                miDepartamento = fDepartamento.miDepartamento;
                txtDepartamento.Text = miDepartamento.Descripcion;
            }
        }

        private void btnProvincia_Click(object sender, EventArgs e)
        {
            if (txtDepartamento.Text.Length > 0)
            {
                Trabajador.frmProvincia fProvincia = new Trabajador.frmProvincia();
                fProvincia.miProvincia = new cProvincia();
                fProvincia.miProvincia.MiDepartamento = miDepartamento;
                if (fProvincia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miProvincia = fProvincia.miProvincia;
                    txtProvincia.Text = miProvincia.Descripcion;
                }
            }
            else
            {
                MessageBox.Show("Seleccione primero el departamento");
            }
        }

        private void btnDistrito_Click(object sender, EventArgs e)
        {
            if (txtProvincia.Text.Length > 0)
            {
                Trabajador.frmListaDistritos fListaDistritos = new Trabajador.frmListaDistritos();
                fListaDistritos.miDistrito = new cDistrito();
                fListaDistritos.miDistrito.MiProvincia = miProvincia;
                if (fListaDistritos.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miDistrito = fListaDistritos.miDistrito;
                    txtDistrito.Text = miDistrito.Descripcion;
                }
            }
        }

        private void btnTipoVia_Click(object sender, EventArgs e)
        {
            Trabajador.frmTipoVia fTipoVia = new Trabajador.frmTipoVia();
            if (fTipoVia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                miTipoVia = fTipoVia.miTipoVia;
                txtTipoVia.Text = miTipoVia.Descripcion;
            }
        }

        private void btnTipoZona_Click(object sender, EventArgs e)
        {
            Trabajador.frmTipoZona fTipoZona = new Trabajador.frmTipoZona();
            if (fTipoZona.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                miTipoZona = fTipoZona.miTipoZona;
                txtTipoZona.Text = miTipoZona.Descripcion;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
