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
    public partial class frmMantenimientoDivisionFuncional : Form
    {
        public cDivisionFuncional miDivisionFuncional;

        public frmMantenimientoDivisionFuncional()
        {
            InitializeComponent();
        }

        private void frmMantenimientoDivisionFuncional_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            txtCodigo.Text = miDivisionFuncional.CodigoFuncional;
            txtNombre.Text = miDivisionFuncional.Nombre;
            numAño7.Value = miDivisionFuncional.Año;
            lblFuncion.Text = miDivisionFuncional.Funcion.Nombre;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            miDivisionFuncional.CodigoFuncional = txtCodigo.Text;
            miDivisionFuncional.Nombre = txtNombre.Text;
            miDivisionFuncional.Año = Convert.ToInt16(numAño7.Value);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
