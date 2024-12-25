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
            cboRegimenLaborales.DataSource = Enum.GetValues(typeof(Planilla.VacacionesTruncas.enumRegimenesLaborales));
            cboSituacion.DataSource = Enum.GetValues(typeof(Planilla.VacacionesTruncas.enumSituacionLaboral));

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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Planilla.VacacionesTruncas.enumRegimenesLaborales RegimenElegido = new VacacionesTruncas.enumRegimenesLaborales();

            RegimenElegido = (VacacionesTruncas.enumRegimenesLaborales)cboRegimenLaborales.SelectedItem;
            

            switch (RegimenElegido)
            {
                case VacacionesTruncas.enumRegimenesLaborales.TODOS:
                    filtroRegimeLaboral = "Todos";
                    break;
                case VacacionesTruncas.enumRegimenesLaborales.CAS:
                    filtroRegimeLaboral = "CAS";
                    break;
                case VacacionesTruncas.enumRegimenesLaborales.DL276:
                    filtroRegimeLaboral = "276";
                    break;
                case VacacionesTruncas.enumRegimenesLaborales.DL728:
                    filtroRegimeLaboral = "728";
                    break;
                case VacacionesTruncas.enumRegimenesLaborales.RACIONAMIENTO:
                    filtroRegimeLaboral = "racionamiento";
                    break;
                case VacacionesTruncas.enumRegimenesLaborales.DL30057:
                    filtroRegimeLaboral = "30057";
                    break;
                default:
                    filtroRegimeLaboral = "";
                    break;
            }

            Planilla.VacacionesTruncas.enumSituacionLaboral SituacionLaboral = new VacacionesTruncas.enumSituacionLaboral();

            SituacionLaboral = (Planilla.VacacionesTruncas.enumSituacionLaboral)cboSituacion.SelectedItem;

            switch (SituacionLaboral)
            {
                case VacacionesTruncas.enumSituacionLaboral.TODOS:
                    filtroSituacionLaboral = "Todos";
                    break;
                case VacacionesTruncas.enumSituacionLaboral.ACTIVOS:
                    filtroSituacionLaboral = "Activos";
                    break;
                case VacacionesTruncas.enumSituacionLaboral.INACTIVOS:
                    filtroSituacionLaboral = "Inactivos";
                    break;
                case VacacionesTruncas.enumSituacionLaboral.SinSituacionLaboral:
                    filtroSituacionLaboral = "Sin Periodo Laboral";
                    break;
                default:
                    break;
            }
            dtgListaTrabajadores.DataSource = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, "", "", "", "", filtroRegimeLaboral, "Todos");
        }
    }
}
