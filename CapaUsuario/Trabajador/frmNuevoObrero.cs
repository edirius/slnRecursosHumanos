using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Trabajador
{
    public partial class frmNuevoObrero : Form
    {
        CapaDeNegocios.cDepartamento miDepartamento = new CapaDeNegocios.cDepartamento();
        CapaDeNegocios.cProvincia miProvincia = new CapaDeNegocios.cProvincia();
        CapaDeNegocios.cDistrito miDistrito = new CapaDeNegocios.cDistrito();
        CapaDeNegocios.cTrabajador miTrabajador = new CapaDeNegocios.cTrabajador();

        CapaDeNegocios.cTipoVia miTipoVia = new CapaDeNegocios.cTipoVia();
        CapaDeNegocios.cTipoZona miTipoZona = new CapaDeNegocios.cTipoZona();
        CapaDeNegocios.cNacionalidad miNacionalidad = new CapaDeNegocios.cNacionalidad();

        public frmNuevoObrero()
        {
            InitializeComponent();
        }

        private void frmNuevoObrero_Load(object sender, EventArgs e)
        {
            CargarDepartamento();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtDNI.Text == "" || txtNombre.Text == "" || txtApePaterno.Text == "" || txtApeMaterno.Text == "" || cboDepartamento.Text == "" || cboProvincia.Text == "" || cboDistrito.Text == "")
            {
                MessageBox.Show("Existen datos en Blanco, no se puede Guardar al nuevo Trabajador", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool bOk = false;
            miTrabajador.Nombres = txtNombre.Text;
            miTrabajador.ApellidoPaterno = txtApePaterno.Text;
            miTrabajador.ApellidoMaterno = txtApeMaterno.Text;
            if (rbtMasculino.Checked == true) { miTrabajador.Sexo = CapaDeNegocios.EnumSexo.Masculino; }
            else if (rbtFemenino.Checked == true) { miTrabajador.Sexo = CapaDeNegocios.EnumSexo.Femenino; }
            miTrabajador.Dni = txtDNI.Text;
            miTrabajador.CelularPersonal = txtCelular.Text;
            miTrabajador.Direccion = txtDireccion.Text;
            miTrabajador.MiDistrito = miDistrito;
            miTrabajador.MiDistrito.Codigo = miDistrito.Codigo;

            miTrabajador.MiTipoVia = miTipoVia;
            miTrabajador.MiTipoVia.Codigo = 1;
            miTrabajador.MiTipoZOna = miTipoZona;
            miTrabajador.MiTipoZOna.Codigo = 1;
            miTrabajador.MiNacionalidad = miNacionalidad;
            miTrabajador.MiNacionalidad.Codigo = 1;

            miTrabajador.AgregarTrabajador(miTrabajador);
            bOk = true;
            if (bOk == true)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("No se puede registrar estos datos", "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.Text != "System.Data.DataRowView" && cboDepartamento.ValueMember != "")
            {
                miDepartamento.Codigo = Convert.ToInt32(cboDepartamento.SelectedValue);
                CargarProvincia();
            }
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.Text != "System.Data.DataRowView" && cboProvincia.ValueMember != "")
            {
                miProvincia.Codigo = Convert.ToInt32(cboProvincia.SelectedValue);
                CargarDistrito();
            }
        }

        private void cboDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDistrito.Text != "System.Data.DataRowView" && cboDistrito.ValueMember != "")
            {
                miDistrito.Codigo = Convert.ToInt32(cboDistrito.SelectedValue);
            }
        }

        private void CargarDepartamento()
        {
            cboDepartamento.DataSource = miDepartamento.ListaDepartamentos();
            cboDepartamento.DisplayMember = "descripcion";
            cboDepartamento.ValueMember = "idtdepartamento";
            cboDepartamento.SelectedIndex = -1;
        }

        private void CargarProvincia()
        {
            cboProvincia.DataSource = miProvincia.ListarProvincias(miDepartamento);
            cboProvincia.DisplayMember = "descripcion";
            cboProvincia.ValueMember = "idtprovincia";
            cboProvincia.SelectedIndex = -1;
        }

        private void CargarDistrito()
        {
            cboDistrito.DataSource = miDistrito.ListarDistritos(miProvincia);
            cboDistrito.DisplayMember = "descripcion";
            cboDistrito.ValueMember = "idtdistrito";
            cboDistrito.SelectedIndex = -1;
        }
    }
}
