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
                CargarDatosPlanilla();
            }
            else
            {
                CargarConceptosPlantilla();
            }
        }

        #region ParteCargarDatos
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

            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaAportacionesTrabajador item in oPlanilla.ListaDetalle[0].ListaDetalleAportacionesTrabajador)
            {
                DataGridViewColumn col = new DataGridViewColumn();
                col.Name = "T" + item.MaestroAportacionTrabajador.IdtMaestroAportacionesTrabajador.ToString();
                col.HeaderText = item.MaestroAportacionTrabajador.Abreviacion;
                col.ToolTipText = item.MaestroAportacionTrabajador.Descripcion;
                dgvDetallePlanilla.Columns.Add(col);
            }

            DataGridViewColumn colTotalAFP = new DataGridViewColumn();
            colTotalAFP.Name = "colTotalAFP";
            colTotalAFP.HeaderText = "Total AFP";
            colTotalAFP.ToolTipText = "Total AFP";
            dgvDetallePlanilla.Columns.Add(colTotalAFP);

            DataGridViewColumn colTotalAportacionT = new DataGridViewColumn();
            colTotalAportacionT.Name = "colTotalAportacionT";
            colTotalAportacionT.HeaderText = "Total Aportacion Tra";
            colTotalAportacionT.ToolTipText = "Total Aportacion Trabajador";
            dgvDetallePlanilla.Columns.Add(colTotalAportacionT);

            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaEgresos item in oPlanilla.ListaDetalle[0].ListaDetalleEgresos)
            {
                DataGridViewColumn col = new DataGridViewColumn();
                col.Name = "D" + item.MaestroDescuentos.IdtMaestroDescuentos.ToString();
                col.HeaderText = item.MaestroDescuentos.Abreviacion;
                col.ToolTipText = item.MaestroDescuentos.Descripcion;
                dgvDetallePlanilla.Columns.Add(col);
            }
            DataGridViewColumn colTotalDescuentos = new DataGridViewColumn();
            colTotalDescuentos.Name = "colTotalDescuentos";
            colTotalDescuentos.HeaderText = "Total Descuentos";
            colTotalDescuentos.ToolTipText = "Total Descuentos";
            dgvDetallePlanilla.Columns.Add(colTotalDescuentos);

            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaAportacionesEmpleador item in oPlanilla.ListaDetalle[0].ListaDetalleAportacionesEmpleador)
            {
                DataGridViewColumn col = new DataGridViewColumn();
                col.Name = "E" + item.MaestroAportacionesEmpleador.IdtMaestroAportacionesEmpleador.ToString();
                col.HeaderText = item.MaestroAportacionesEmpleador.Abreviacion;
                col.ToolTipText = item.MaestroAportacionesEmpleador.Descripcion;
                dgvDetallePlanilla.Columns.Add(col);
            }
            DataGridViewColumn colTotalAportacionE = new DataGridViewColumn();
            colTotalAportacionE.Name = "colTotalAportacionE";
            colTotalAportacionE.HeaderText = "Total Aportes Empl.";
            colTotalAportacionE.ToolTipText = "Total Aportacion Empleador";
            dgvDetallePlanilla.Columns.Add(colTotalAportacionE);

            DataGridViewColumn colNetoAPagar = new DataGridViewColumn();
            colNetoAPagar.Name = "colNetoAPagar";
            colNetoAPagar.HeaderText = "Neto a Pagar";
            colNetoAPagar.ToolTipText = "Neto a Pagar";
            dgvDetallePlanilla.Columns.Add(colNetoAPagar);

            DataGridViewColumn colObservaciones = new DataGridViewColumn();
            colObservaciones.Name = "colObservaciones";
            colObservaciones.HeaderText = "Observaciones";
            colObservaciones.ToolTipText = "Observaciones";
            dgvDetallePlanilla.Columns.Add(colObservaciones);
        }

        private void CargarConceptosPlantilla()
        {
            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlantilla item in oPlanilla.Plantilla.DetallesPantilla)
            {
                if (item.TipoPlantilla == CapaDeNegocios.PlanillaNueva.enumTipoPlantilla.Ingreso)
                {
                    DataGridViewColumn col = new DataGridViewColumn();
                    col.Name = "I" + item.MaestroIngresos.IdtMaestroIngresos.ToString();
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

            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlantilla item in oPlanilla.Plantilla.DetallesPantilla)
            {
                if (item.TipoPlantilla == CapaDeNegocios.PlanillaNueva.enumTipoPlantilla.AporteTrabajador)
                {
                    DataGridViewColumn col = new DataGridViewColumn();
                    col.Name = "T" + item.MaestroAportacionTrabajador.IdtMaestroAportacionesTrabajador.ToString();
                    col.HeaderText = item.MaestroAportacionTrabajador.Abreviacion;
                    col.ToolTipText = item.MaestroAportacionTrabajador.Descripcion;
                    dgvDetallePlanilla.Columns.Add(col);
                }
            }
            DataGridViewColumn colTotalAFP = new DataGridViewColumn();
            colTotalAFP.Name = "colTotalAFP";
            colTotalAFP.HeaderText = "Total AFP";
            colTotalAFP.ToolTipText = "Total AFP";
            dgvDetallePlanilla.Columns.Add(colTotalAFP);

            DataGridViewColumn colTotalAportacionT = new DataGridViewColumn();
            colTotalAportacionT.Name = "colTotalAportacionT";
            colTotalAportacionT.HeaderText = "Total Aportacion Tra";
            colTotalAportacionT.ToolTipText = "Total Aportacion Trabajador";
            dgvDetallePlanilla.Columns.Add(colTotalAportacionT);

            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlantilla item in oPlanilla.Plantilla.DetallesPantilla)
            {
                if (item.TipoPlantilla == CapaDeNegocios.PlanillaNueva.enumTipoPlantilla.Descuento)
                {
                    DataGridViewColumn col = new DataGridViewColumn();
                    col.Name = "D" + item.MaestroDescuentos.IdtMaestroDescuentos.ToString();
                    col.HeaderText = item.MaestroDescuentos.Abreviacion;
                    col.ToolTipText = item.MaestroDescuentos.Descripcion;
                    dgvDetallePlanilla.Columns.Add(col);
                }
            }
            DataGridViewColumn colTotalDescuentos = new DataGridViewColumn();
            colTotalDescuentos.Name = "colTotalDescuentos";
            colTotalDescuentos.HeaderText = "Total Descuentos";
            colTotalDescuentos.ToolTipText = "Total Descuentos";
            dgvDetallePlanilla.Columns.Add(colTotalDescuentos);

            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlantilla item in oPlanilla.Plantilla.DetallesPantilla)
            {
                if (item.TipoPlantilla == CapaDeNegocios.PlanillaNueva.enumTipoPlantilla.AporteEmpleador)
                {
                    DataGridViewColumn col = new DataGridViewColumn();
                    col.Name = "E" + item.MaestroAportacionesEmpleador.IdtMaestroAportacionesEmpleador.ToString();
                    col.HeaderText = item.MaestroAportacionesEmpleador.Abreviacion;
                    col.ToolTipText = item.MaestroAportacionesEmpleador.Descripcion;
                    dgvDetallePlanilla.Columns.Add(col);
                }
            }
            DataGridViewColumn colTotalAportacionE = new DataGridViewColumn();
            colTotalAportacionE.Name = "colTotalAportacionE";
            colTotalAportacionE.HeaderText = "Total Aportes Empl.";
            colTotalAportacionE.ToolTipText = "Total Aportacion Empleador";
            dgvDetallePlanilla.Columns.Add(colTotalAportacionE);

            DataGridViewColumn colNetoAPagar = new DataGridViewColumn();
            colNetoAPagar.Name = "colNetoAPagar";
            colNetoAPagar.HeaderText = "Neto a Pagar";
            colNetoAPagar.ToolTipText = "Neto a Pagar";
            dgvDetallePlanilla.Columns.Add(colNetoAPagar);

            DataGridViewColumn colObservaciones = new DataGridViewColumn();
            colObservaciones.Name = "colObservaciones";
            colObservaciones.HeaderText = "Observaciones";
            colObservaciones.ToolTipText = "Observaciones";
            dgvDetallePlanilla.Columns.Add(colObservaciones);
        }
        #endregion

        private void CargarDatosPlanilla()
        {

        }
    }
}
