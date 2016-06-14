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
    public partial class frmMantenimientoGrupoFuncional : Form
    {
        public cGrupoFuncional miGrupoFuncional;

        public frmMantenimientoGrupoFuncional()
        {
            InitializeComponent();
        }

        private void frmMantenimientoGrupoFuncional_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            txtCodigo.Text = miGrupoFuncional.GrupoFuncional;
            txtNombre.Text = miGrupoFuncional.Nombre;
            numAño.Value = miGrupoFuncional.Año;
            lblFuncion.Text = miGrupoFuncional.DivisionFuncional.Funcion.Nombre;
            lblDivisionFuncional.Text = miGrupoFuncional.DivisionFuncional.Nombre;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            miGrupoFuncional.GrupoFuncional = txtCodigo.Text;
            miGrupoFuncional.Nombre = txtNombre.Text;
            miGrupoFuncional.Año = Convert.ToInt16(numAño.Value);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
