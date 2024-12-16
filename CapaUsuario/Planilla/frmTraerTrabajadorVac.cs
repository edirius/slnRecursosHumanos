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

namespace CapaUsuario.Planilla
{
    public partial class frmTraerTrabajadorVac : Form
    {
        private cTrabajador miListaTrabajadores = new cTrabajador();
        private string filtroRegimeLaboral = "Todos";
        private string filtroSituacionLaboral = "Todos";

        public cTrabajador TrabajadorSeleccionado = new cTrabajador();

        public frmTraerTrabajadorVac()
        {
            InitializeComponent();
        }

        private void frmTraerTrabajadorVac_Load(object sender, EventArgs e)
        {
            Iniciar();
            
        }

        private void Iniciar()
        {
            dtgListaTrabajadores.DataSource = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, "", "", "", "", filtroRegimeLaboral, "Todos");
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgListaTrabajadores.SelectedRows.Count > 0)
                {
                    TrabajadorSeleccionado.IdTrabajador = Convert.ToInt32(dtgListaTrabajadores.SelectedRows[0].Cells["id_trabajador"].Value);
                    TrabajadorSeleccionado.traerTrabajador(TrabajadorSeleccionado.IdTrabajador);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un trabajador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar los trabajadores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
