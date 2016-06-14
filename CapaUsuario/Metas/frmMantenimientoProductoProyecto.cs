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
    public partial class frmMantenimientoProductoProyecto : Form
    {
        public cProductoProyecto miProductoProyecto;
        
        public frmMantenimientoProductoProyecto()
        {
            InitializeComponent();
        }

        private void frmMantenimientoProductoProyecto_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            txtCodigo.Text = Convert.ToString(miProductoProyecto.ProductoProyecto);
            txtNombre.Text = miProductoProyecto.Nombre;
            numAño.Value = miProductoProyecto.Año;
            lblProgramaPresupuestal.Text = miProductoProyecto.ProgramaPresupuestal.Nombre;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            miProductoProyecto.ProductoProyecto = txtCodigo.Text;
            miProductoProyecto.Nombre = txtNombre.Text;
            miProductoProyecto.Año = Convert.ToInt16(numAño.Value);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
