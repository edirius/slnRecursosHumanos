using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios.Obras;

namespace CapaUsuario.Metas
{
    public partial class frmMantenimientoFuncion : Form
    {
        public cFuncion oFuncion;
        public frmMantenimientoFuncion()
        {
            InitializeComponent();
        }

        private void frmMantenimientoFuncion_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            txtCodigo.Text = oFuncion.Funcion;
            txtNombre.Text = oFuncion.Nombre;
            numAño.Value = oFuncion.Año;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            oFuncion.Funcion  = txtCodigo.Text;
            oFuncion.Nombre = txtNombre.Text;
            oFuncion.Año = Convert.ToInt16(numAño.Value);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
