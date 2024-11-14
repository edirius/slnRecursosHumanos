using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios.Planillas;

namespace CapaUsuario.Planilla.VacacionesTruncas
{
    public partial class frmMantenimientoDetalleVac : Form
    {
        public frmMantenimientoDetalleVac()
        {
            InitializeComponent();
        }

        public cPlanilla oPlanilla;
        private void frmMantenimientoDetalleVac_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            frmImportarPeriodo fImportarPeriodo = new frmImportarPeriodo();
            if (fImportarPeriodo.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void CargarDatos()
        {
            //Si la planilla tiene datos

            if (oPlanilla.ListaDetallePlanilla.Count > 0)
            {
                CargarConceptosPlanilla();
            }
            else
            {
                CargarConceptosPlantilla();
            }
        }

        private void CargarConceptosPlanilla()
        {
            foreach (cDetallePlanillaIngresos item in oPlanilla.ListaDetallePlanilla[0].ListaIngresos)
            {
                DataGridViewColumn col = new DataGridViewColumn();
                col.Name = "I" + item.IdtDetallePlanillaIngresos.ToString();
                col.HeaderText = item.MaestroIngresos.Abreviacion;
                col.ToolTipText = item.MaestroIngresos.Descripcion;
                dgvDetallePlanilla.Columns.Add(col);
            }

            DataGridViewColumn colTotalIngresos = new DataGridViewColumn();
            colTotalIngresos.Name = "colTotalIngresos";
            colTotalIngresos.HeaderText = "Total Ingresos";
            colTotalIngresos.ToolTipText = "Total Ingresos";
            dgvDetallePlanilla.Columns.Add(colTotalIngresos);
        }

        private void CargarConceptosPlantilla()
        {
            foreach (var item in oPlanilla.Plantilla)
            {

            }
        }
    }
}
