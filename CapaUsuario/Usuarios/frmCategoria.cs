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
using CapaDeNegocios.Usuario;

namespace CapaUsuario.Usuarios
{
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        public cPrivilegio miPrivilegio;


        private void frmCategoria_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            txtDescripcion.Text = miPrivilegio.Descripcion;
            checkMenuAFP.Checked = miPrivilegio.MenuAFP;
            checkUsuarios.Checked = miPrivilegio.MenuUsuario; 
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            miPrivilegio.Descripcion = txtDescripcion.Text;
            miPrivilegio.MenuAFP = checkMenuAFP.Checked;
            miPrivilegio.MenuUsuario = checkUsuarios.Checked;
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
