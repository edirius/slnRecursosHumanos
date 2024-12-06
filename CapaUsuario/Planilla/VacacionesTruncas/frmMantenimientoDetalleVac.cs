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

        public CapaDeNegocios.PlanillaNueva.cnPlanilla oPlanilla;
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

            if (oPlanilla.ListaDetalle.Count > 0)
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
            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaIngresos item in oPlanilla.ListaDetalle[0].ListaDetalleIngresos)
            {
                DataGridViewColumn col = new DataGridViewColumn();
                col.Name = "I" + item.Codigo.ToString();
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
            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlantilla item in oPlanilla.Plantilla.DetallesPantilla)
            {
                if (item.TipoPlantilla == CapaDeNegocios.PlanillaNueva.enumTipoPlantilla.Ingreso)
                {
                    DataGridViewColumn col = new DataGridViewColumn();
                    col.Name = "I" + item.Orden.ToString();
                    col.HeaderText = item.MaestroIngresos.Abreviacion;
                    col.ToolTipText = item.MaestroIngresos.Descripcion;
                    dgvDetallePlanilla.Columns.Add(col);
                }
            }
            DataGridViewColumn colTotalIngresos = new DataGridViewColumn();
            colTotalIngresos.Name = "colTotalIngresos";
            colTotalIngresos.HeaderText = "Total Ingresos";
            colTotalIngresos.ToolTipText = "Total Ingresos";
            dgvDetallePlanilla.Columns.Add(colTotalIngresos);
        }
    }
}
