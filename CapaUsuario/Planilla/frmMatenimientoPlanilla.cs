using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Planilla
{
    public partial class frmMatenimientoPlanilla : Form
    {
        public frmMatenimientoPlanilla()
        {
            InitializeComponent();
        }

        private void frmMatenimientoPlanilla_Load(object sender, EventArgs e)
        {
            CargarTipoTrabajador();
        }

        private void btnTipoTrabajador_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDetallePlanilla_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void cboTipoTrabajador_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvPlanilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPlanilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CargarTipoTrabajador()
        {
            CapaDeNegocios.cTipoTrabajador miTipoTrabajador = new CapaDeNegocios.cTipoTrabajador();
            cboTipoTrabajador.DataSource = miTipoTrabajador.ListarTiposDeTrabajadores();
            cboTipoTrabajador.DisplayMember = "descripcion";
            cboTipoTrabajador.ValueMember = "idtsunattipotrabajador";
        }

        private void CargarDatos()
        {
            CapaDeNegocios.Planillas.cPlanilla miPlanilla = new CapaDeNegocios.Planillas.cPlanilla();
            //dgvPlanilla.DataSource = miPlanilla.Codigo;
        }
    }
}
