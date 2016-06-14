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
    public partial class frmMantenimientoProgramaPresupuestal : Form
    {
        public cProgramaPresupuestal miProgramaPresupuestal;

        public frmMantenimientoProgramaPresupuestal()
        {
            InitializeComponent();
        }

        private void frmMantenimientoProgramaPresupuestal_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            txtCodigo.Text = miProgramaPresupuestal.ProgramaPresupuestal;
            txtNombre.Text = miProgramaPresupuestal.Nombre;
            numAño.Value = Convert.ToDecimal( miProgramaPresupuestal.Año); 
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            miProgramaPresupuestal.Nombre = txtNombre.Text;
            miProgramaPresupuestal.ProgramaPresupuestal = txtCodigo.Text;
            miProgramaPresupuestal.Año = Convert.ToInt16(numAño.Value);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
