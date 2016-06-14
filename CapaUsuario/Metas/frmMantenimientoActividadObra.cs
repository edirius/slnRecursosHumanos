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
    public partial class frmMantenimientoActividadObra : Form
    {
        public cActividadObra oActividadObra = new cActividadObra();

        public frmMantenimientoActividadObra()
        {
            InitializeComponent();
        }

        private void frmMantenimientoActividadObra_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            txtCodigo.Text = oActividadObra.ActividadObra;
            txtNombre.Text = oActividadObra.Nombre;
            numAño.Value = oActividadObra.Año;
            lblProgramaPresupuestal.Text  = oActividadObra.ProductoProyecto.ProgramaPresupuestal.Nombre;
            lblProductoProyecto.Text  = oActividadObra.ProductoProyecto.Nombre;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            oActividadObra.ActividadObra = txtCodigo.Text;
            oActividadObra.Nombre = txtNombre.Text;
            oActividadObra.Año = Convert.ToInt16(numAño.Value);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
