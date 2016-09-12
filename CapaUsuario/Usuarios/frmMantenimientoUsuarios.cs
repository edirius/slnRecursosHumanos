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


namespace CapaUsuario.Usuarios
{
    public partial class frmMantenimientoUsuarios : Form
    {
        public CapaDeNegocios.Usuario.cUsuario miUsuario;

       

        public frmMantenimientoUsuarios()
        {
            InitializeComponent();
        }

        private void frmMantenimientoUsuarios_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            lblNombre.Text = miUsuario.Trabajador.Nombres + " " + miUsuario.Trabajador.ApellidoPaterno + " " + miUsuario.Trabajador.ApellidoMaterno;
            txtUsuario.Text = miUsuario.Nombre;
            cboCategoria.DisplayMember = "nombre";
            cboCategoria.ValueMember = "idtPrivilegios";
            cboCategoria.DataSource = miUsuario.Privilegio.ListaPrivilegios();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            frmListaPrivilegios fListaPrivilegios = new frmListaPrivilegios();
            if (fListaPrivilegios.ShowDialog () == DialogResult.OK )
            {

                
            }
            cboCategoria.DataSource = miUsuario.Privilegio.ListaPrivilegios();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtPassword2.Text )
            {
                miUsuario.Nombre = txtUsuario.Text;
                miUsuario.Password = txtPassword.Text;
                miUsuario.Privilegio.Codigo = Convert.ToInt16(cboCategoria.SelectedValue);
                this.DialogResult = DialogResult.OK;
            }
           
            else
            {
                MessageBox.Show("El password no coincide:");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
