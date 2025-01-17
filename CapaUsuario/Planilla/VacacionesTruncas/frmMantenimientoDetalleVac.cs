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
        private int contador = 0;

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
            DataGridViewCellStyle cellNumero =  new DataGridViewCellStyle();
            cellNumero.Alignment = DataGridViewContentAlignment.MiddleRight;
            cellNumero.Format = "0.00";

            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaIngresos item in oPlanilla.ListaDetalle[0].ListaDetalleIngresos)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Name = "I" + item.MaestroIngresos.IdtMaestroIngresos.ToString();
                col.HeaderText = item.MaestroIngresos.Abreviacion;
                col.ToolTipText = item.MaestroIngresos.Descripcion;
                col.DefaultCellStyle = cellNumero;
                col.Width = 50;
                dgvDetallePlanilla.Columns.Add(col);
            }

            DataGridViewTextBoxColumn colTotalIngresos = new DataGridViewTextBoxColumn();
            colTotalIngresos.Name = "colTotalIngresos";
            colTotalIngresos.HeaderText = "Total Ingresos";
            colTotalIngresos.ToolTipText = "Total Ingresos";
            colTotalIngresos.Width = 65;
            colTotalIngresos.DefaultCellStyle = cellNumero;
            dgvDetallePlanilla.Columns.Add(colTotalIngresos);

            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaAportacionesTrabajador item in oPlanilla.ListaDetalle[0].ListaDetalleAportacionesTrabajador)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Name = "T" + item.MaestroAportacionTrabajador.IdtMaestroAportacionesTrabajador.ToString();
                col.HeaderText = item.MaestroAportacionTrabajador.Abreviacion;
                col.ToolTipText = item.MaestroAportacionTrabajador.Descripcion;
                col.DefaultCellStyle = cellNumero;
                col.Width = 50;
                dgvDetallePlanilla.Columns.Add(col);
            }

            DataGridViewTextBoxColumn colTotalAFP = new DataGridViewTextBoxColumn();
            colTotalAFP.Name = "colTotalAFP";
            colTotalAFP.HeaderText = "Total AFP";
            colTotalAFP.ToolTipText = "Total AFP";
            colTotalAFP.DefaultCellStyle = cellNumero;
            colTotalAFP.Width = 65;
            dgvDetallePlanilla.Columns.Add(colTotalAFP);

            DataGridViewTextBoxColumn colTotalAportacionT = new DataGridViewTextBoxColumn();
            colTotalAportacionT.Name = "colTotalAportacionT";
            colTotalAportacionT.HeaderText = "Total Aportacion Tra";
            colTotalAportacionT.ToolTipText = "Total Aportacion Trabajador";
            colTotalAportacionT.DefaultCellStyle = cellNumero;
            colTotalAportacionT.Width = 65;
            dgvDetallePlanilla.Columns.Add(colTotalAportacionT);

            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaEgresos item in oPlanilla.ListaDetalle[0].ListaDetalleEgresos)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Name = "D" + item.MaestroDescuentos.IdtMaestroDescuentos.ToString();
                col.HeaderText = item.MaestroDescuentos.Abreviacion;
                col.ToolTipText = item.MaestroDescuentos.Descripcion;
                col.DefaultCellStyle = cellNumero;
                col.Width = 50;
                dgvDetallePlanilla.Columns.Add(col);
            }
            DataGridViewTextBoxColumn colTotalDescuentos = new DataGridViewTextBoxColumn();
            colTotalDescuentos.Name = "colTotalDescuentos";
            colTotalDescuentos.HeaderText = "Total Descuentos";
            colTotalDescuentos.ToolTipText = "Total Descuentos";
            colTotalDescuentos.DefaultCellStyle = cellNumero;
            colTotalDescuentos.Width = 65;
            dgvDetallePlanilla.Columns.Add(colTotalDescuentos);

            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaAportacionesEmpleador item in oPlanilla.ListaDetalle[0].ListaDetalleAportacionesEmpleador)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Name = "E" + item.MaestroAportacionesEmpleador.IdtMaestroAportacionesEmpleador.ToString();
                col.HeaderText = item.MaestroAportacionesEmpleador.Abreviacion;
                col.ToolTipText = item.MaestroAportacionesEmpleador.Descripcion;
                col.DefaultCellStyle = cellNumero;
                col.Width = 50;
                dgvDetallePlanilla.Columns.Add(col);
            }
            DataGridViewTextBoxColumn colTotalAportacionE = new DataGridViewTextBoxColumn();
            colTotalAportacionE.Name = "colTotalAportacionE";
            colTotalAportacionE.HeaderText = "Total Aportes Empl.";
            colTotalAportacionE.ToolTipText = "Total Aportacion Empleador";
            colTotalAportacionE.DefaultCellStyle = cellNumero;
            colTotalAportacionE.Width = 65;
            dgvDetallePlanilla.Columns.Add(colTotalAportacionE);

            DataGridViewTextBoxColumn colNetoAPagar = new DataGridViewTextBoxColumn();
            colNetoAPagar.Name = "colNetoAPagar";
            colNetoAPagar.HeaderText = "Neto a Pagar";
            colNetoAPagar.ToolTipText = "Neto a Pagar";
            colNetoAPagar.DefaultCellStyle = cellNumero;
            colNetoAPagar.Width = 65;
            dgvDetallePlanilla.Columns.Add(colNetoAPagar);

            DataGridViewTextBoxColumn colObservaciones = new DataGridViewTextBoxColumn();
            colObservaciones.Name = "colObservaciones";
            colObservaciones.HeaderText = "Observaciones";
            colObservaciones.ToolTipText = "Observaciones";
            dgvDetallePlanilla.Columns.Add(colObservaciones);
        }

        private void CargarConceptosPlantilla()
        {
            DataGridViewCellStyle cellNumero = new DataGridViewCellStyle();
            cellNumero.Alignment = DataGridViewContentAlignment.MiddleRight;
            cellNumero.Format = "0.00";

            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlantilla item in oPlanilla.Plantilla.DetallesPantilla)
            {
                if (item.TipoPlantilla == CapaDeNegocios.PlanillaNueva.enumTipoPlantilla.Ingreso)
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.Name = "I" + item.MaestroIngresos.IdtMaestroIngresos.ToString();
                    col.HeaderText = item.MaestroIngresos.Abreviacion;
                    col.ToolTipText = item.MaestroIngresos.Descripcion;
                    col.DefaultCellStyle = cellNumero;
                    col.Width = 50;
                    dgvDetallePlanilla.Columns.Add(col);
                }
            }
            DataGridViewTextBoxColumn colTotalIngresos = new DataGridViewTextBoxColumn();
            colTotalIngresos.Name = "colTotalIngresos";
            colTotalIngresos.HeaderText = "Total Ingresos";
            colTotalIngresos.ToolTipText = "Total Ingresos";
            colTotalIngresos.Width = 65;
            colTotalIngresos.DefaultCellStyle = cellNumero;
            dgvDetallePlanilla.Columns.Add(colTotalIngresos);

            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlantilla item in oPlanilla.Plantilla.DetallesPantilla)
            {
                if (item.TipoPlantilla == CapaDeNegocios.PlanillaNueva.enumTipoPlantilla.AporteTrabajador)
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.Name = "T" + item.MaestroAportacionTrabajador.IdtMaestroAportacionesTrabajador.ToString();
                    col.HeaderText = item.MaestroAportacionTrabajador.Abreviacion;
                    col.ToolTipText = item.MaestroAportacionTrabajador.Descripcion;
                    col.DefaultCellStyle = cellNumero;
                    col.Width = 50;
                    dgvDetallePlanilla.Columns.Add(col);
                }
            }
            DataGridViewTextBoxColumn colTotalAFP = new DataGridViewTextBoxColumn();
            colTotalAFP.Name = "colTotalAFP";
            colTotalAFP.HeaderText = "Total AFP";
            colTotalAFP.ToolTipText = "Total AFP";
            colTotalAFP.DefaultCellStyle = cellNumero;
            colTotalAFP.Width = 65;
            dgvDetallePlanilla.Columns.Add(colTotalAFP);

            DataGridViewTextBoxColumn colTotalAportacionT = new DataGridViewTextBoxColumn();
            colTotalAportacionT.Name = "colTotalAportacionT";
            colTotalAportacionT.HeaderText = "Total Aportacion Tra";
            colTotalAportacionT.ToolTipText = "Total Aportacion Trabajador";
            colTotalAportacionT.DefaultCellStyle = cellNumero;
            colTotalAportacionT.Width = 65;
            dgvDetallePlanilla.Columns.Add(colTotalAportacionT);

            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlantilla item in oPlanilla.Plantilla.DetallesPantilla)
            {
                if (item.TipoPlantilla == CapaDeNegocios.PlanillaNueva.enumTipoPlantilla.Descuento)
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.Name = "D" + item.MaestroDescuentos.IdtMaestroDescuentos.ToString();
                    col.HeaderText = item.MaestroDescuentos.Abreviacion;
                    col.ToolTipText = item.MaestroDescuentos.Descripcion;
                    col.DefaultCellStyle = cellNumero;
                    col.Width = 50;
                    dgvDetallePlanilla.Columns.Add(col);
                }
            }
            DataGridViewTextBoxColumn colTotalDescuentos = new DataGridViewTextBoxColumn();
            colTotalDescuentos.Name = "colTotalDescuentos";
            colTotalDescuentos.HeaderText = "Total Descuentos";
            colTotalDescuentos.ToolTipText = "Total Descuentos";
            colTotalDescuentos.DefaultCellStyle = cellNumero;
            colTotalDescuentos.Width = 65;
            dgvDetallePlanilla.Columns.Add(colTotalDescuentos);

            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlantilla item in oPlanilla.Plantilla.DetallesPantilla)
            {
                if (item.TipoPlantilla == CapaDeNegocios.PlanillaNueva.enumTipoPlantilla.AporteEmpleador)
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.Name = "E" + item.MaestroAportacionesEmpleador.IdtMaestroAportacionesEmpleador.ToString();
                    col.HeaderText = item.MaestroAportacionesEmpleador.Abreviacion;
                    col.ToolTipText = item.MaestroAportacionesEmpleador.Descripcion;
                    col.DefaultCellStyle = cellNumero;
                    col.Width = 50;
                    dgvDetallePlanilla.Columns.Add(col);
                }
            }
            DataGridViewTextBoxColumn colTotalAportacionE = new DataGridViewTextBoxColumn();
            colTotalAportacionE.Name = "colTotalAportacionE";
            colTotalAportacionE.HeaderText = "Total Aportes Empl.";
            colTotalAportacionE.ToolTipText = "Total Aportacion Empleador";
            colTotalAportacionE.DefaultCellStyle = cellNumero;
            colTotalAportacionE.Width = 65;
            dgvDetallePlanilla.Columns.Add(colTotalAportacionE);

            DataGridViewTextBoxColumn colNetoAPagar = new DataGridViewTextBoxColumn();
            colNetoAPagar.Name = "colNetoAPagar";
            colNetoAPagar.HeaderText = "Neto a Pagar";
            colNetoAPagar.ToolTipText = "Neto a Pagar";
            colNetoAPagar.DefaultCellStyle = cellNumero;
            colNetoAPagar.Width = 65;
            dgvDetallePlanilla.Columns.Add(colNetoAPagar);

            DataGridViewTextBoxColumn colObservaciones = new DataGridViewTextBoxColumn();
            colObservaciones.Name = "colObservaciones";
            colObservaciones.HeaderText = "Observaciones";
            colObservaciones.ToolTipText = "Observaciones";
            dgvDetallePlanilla.Columns.Add(colObservaciones);
        }
        #endregion

        private void CargarDatosPlanilla()
        {

            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanilla item in oPlanilla.ListaDetalle)
            {
                dgvDetallePlanilla.Rows.Add();
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["txtIdTDetallePlanilla"].Value = item.codigo;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["txtNro"].Value = item.numero;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["txtIdTTrabajador"].Value = item.miTrabajador.IdTrabajador;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["txtApellidosNombres"].Value = item.miTrabajador.ApellidoPaterno + " " + item.miTrabajador.ApellidoMaterno + ", " + item.miTrabajador.Nombres;
                //dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["txtIdTCargo"].Value = ;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["colCargo"].Value = item.cargo;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["txtDNI"].Value = item.miTrabajador.Dni;
                //dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["SecFunc"].Value =  
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["FechaInicio"].Value = item.fechaInicio.ToShortDateString();
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["FECHAINICIOMETA"].Value = item.fechaInicioMeta.ToShortDateString();
                if (item.fechaFin.Year == 1)
                {
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["fechafin"].Value = "";
                }
                else
                {
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["fechafin"].Value = item.fechaFin.ToShortDateString();
                }
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["DIASMES"].Value = item.diasMes;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["DIASSUSPENDIDOS"].Value = item.diasSuspendidos;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["DiasLaborados"].Value = item.diasLaborados;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["colAFP"].Value = item.regimenPensionario.Afp.Nombre;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["colComision"].Value = item.regimenPensionario.TipoComision;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["colCUSPP"].Value = item.regimenPensionario.CUSPP;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["SUELDOPACTADO"].Value = item.sueldoPactado;
                //dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["Remuneracion"].Value = item.re .sueldoPactado;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["TotalRemuneracio"].Value = item.sueldoDiasLaborados;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["SUELDOFALTASTAR"].Value = item.sueldoDespuesFaltas;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["colTotalAFP"].Value = item.totalDescuentoAFP;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["colNetoAPagar"].Value = item.netoACobrar;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["colTotalAportacionE"].Value = item.totalAportacionesEmpleador;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["colObservaciones"].Value = item.observacion;



                foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaIngresos item2 in item.ListaDetalleIngresos)
                {
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[ "I" + item2.MaestroIngresos.IdtMaestroIngresos].Value = item2.Monto;
                }
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["colTotalIngresos"].Value = item.totalIngreso;

                foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaAportacionesTrabajador item3 in item.ListaDetalleAportacionesTrabajador)
                {
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["T" + item3.MaestroAportacionTrabajador.IdtMaestroAportacionesTrabajador].Value = item3.Monto;
                }
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["colTotalAportacionT"].Value = item.totalAportacionesTrabajador;

                foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaEgresos item4 in item.ListaDetalleEgresos)
                {
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["D" + item4.MaestroDescuentos.IdtMaestroDescuentos].Value = item4.Monto;
                }
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["colTotalDescuentos"].Value = item.totalDescuentos;
                foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaAportacionesEmpleador item5 in item.ListaDetalleAportacionesEmpleador)
                {
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["E" + item5.MaestroAportacionesEmpleador.IdtMaestroAportacionesEmpleador].Value = item5.Monto;
                }
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["colTotalAportacionE"].Value = item.totalAportacionesEmpleador;

                //dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["].Value = item.totalAportacionesTrabajador;
            }
        }

        private void btnAgregarTrabajador_Click(object sender, EventArgs e)
        {
            switch (oPlanilla.TipoPlanilla)
            {
                case CapaDeNegocios.PlanillaNueva.enumTipoPlanilla.NORMAL:
                    AgregarTrabajadorNormal();
                    break;
                case CapaDeNegocios.PlanillaNueva.enumTipoPlanilla.RACIONAMIENTO:
                    break;
                case CapaDeNegocios.PlanillaNueva.enumTipoPlanilla.VACACIONES_TRUNCAS:
                    AgregarTrabajadorVacacionesTruncas();
                    break;
                case CapaDeNegocios.PlanillaNueva.enumTipoPlanilla.CTS:
                    break;
                default:
                    break;
            }
        }

        private void AgregarTrabajadorNormal()
        {
            try
            {
                CapaUsuario.Planilla.frmSeleccionTrabajadorPlanilla fSeleccionTrabajadorPlanilla = new frmSeleccionTrabajadorPlanilla();
                fSeleccionTrabajadorPlanilla.RecibirDatos(oPlanilla.Mes, oPlanilla.Año, oPlanilla.Meta.Codigo, oPlanilla.RegimenLaboral.IdTRegimenLaboral);
                if (fSeleccionTrabajadorPlanilla.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //sselecciontrabajadores = fSeleccionTrabajadorPlanilla.strabajadores;
                    //sfilasselecciontrabajadores = fSeleccionTrabajadorPlanilla.sfilasselecciontrabajadores;

                    //int z = 0;
                    //for (int i = 0; i < sfilasselecciontrabajadores; i++)
                    //{
                    //    z = 0;
                    //    foreach (DataGridViewRow rowDgvDetallePlanilla in dgvDetallePlanilla.Rows)
                    //    {
                    //        if (Convert.ToString(rowDgvDetallePlanilla.Cells[4].Value) == sselecciontrabajadores[i, 0].ToString())
                    //        {
                    //            z = 1;
                    //        }
                    //    }
                    //    if (z == 0)
                    //    {
                    //        CargarTrabajador(Convert.ToInt32(sselecciontrabajadores[i, 0].ToString()), splantilla);
                    //        TotalRemuneracion(dgvDetallePlanilla.Rows.Count - 1);
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("El trabajador ya se encuentra en la planilla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el trabajador normal: " + ex.Message);
            }
        }

        private void AgregarTrabajadorVacacionesTruncas()
        {
            try
            {
                frmTraerTrabajadorVac fTraerTrabajadorVac = new frmTraerTrabajadorVac();
                if (fTraerTrabajadorVac.ShowDialog() == DialogResult.OK)
                {
                    CargarTrabajador(fTraerTrabajadorVac.TrabajadorSeleccionado.IdTrabajador, oPlanilla.Plantilla.Descripcion);
                    //TotalRemuneracion(dgvDetallePlanilla.Rows.Count - 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el trabajador vacaciones: " + ex.Message);
            }
        }

        private void CargarTrabajador(int pidtrabajador, string tipoPlanilla)
        {
            try
            {
                bool TienAFP = false;
                string Nombre = "";
                string DNI = "";
                string FechaInicio = "";
                string MontoPago = "";
                int IdtCargo = 0;
                string Cargo = "";

                CapaDeNegocios.Planillas.cPlanilla PlanillaEncontrada = new CapaDeNegocios.Planillas.cPlanilla();
                CapaDeNegocios.cTrabajador miTrabajador = new CapaDeNegocios.cTrabajador();

                miTrabajador.IdTrabajador = pidtrabajador;
                miTrabajador = miTrabajador.traerTrabajador(miTrabajador.IdTrabajador);

                PlanillaEncontrada = PlanillaEncontrada.TraerPLanillaConTrabajadorDuplicado(miTrabajador, PlanillaEncontrada.Mes, Convert.ToInt16(PlanillaEncontrada.Año), PlanillaEncontrada.IdtPlanilla);

                if (PlanillaEncontrada != null && oPlanilla.TipoPlanilla != CapaDeNegocios.PlanillaNueva.enumTipoPlanilla.VACACIONES_TRUNCAS)
                {
                    MessageBox.Show("Se encontro al trabajador: " + miTrabajador.Nombres + " " + miTrabajador.ApellidoPaterno + " " + miTrabajador.ApellidoMaterno + " Cargo: " + PlanillaEncontrada.ListaDetallePlanilla[0].Cargo +
                        " en la planilla Nro: " + PlanillaEncontrada.Numero + " - " + PlanillaEncontrada.Descripcion, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (oPlanilla.TipoPlanilla == CapaDeNegocios.PlanillaNueva.enumTipoPlanilla.VACACIONES_TRUNCAS)
                {
                    CargarTrabajadorVacacionesTruncas(miTrabajador);
                    
                }
                else
                {
                    //foreach (DataRow rowTrabajador in oDataTrabajador.Select("id_trabajador = '" + pidtrabajador + "'"))
                    //{
                    //    Nombre = rowTrabajador[2].ToString() + " " + rowTrabajador[3].ToString() + " " + rowTrabajador[4].ToString();
                    //    DNI = rowTrabajador[1].ToString();

                    //    List<CapaDeNegocios.DatosLaborales.cPeriodoTrabajador> AuxiliarPeriodoTrabajador = miPeriodoTrabajador.traerPeriodosMesTrabajador(pidtrabajador, new DateTime(Convert.ToInt16(saño), Convert.ToInt16(Mes(smes)), 1));
                    //    List<CapaDeNegocios.DatosLaborales.cRegimenTrabajador> ListaRegimenTrabajador = new List<CapaDeNegocios.DatosLaborales.cRegimenTrabajador>();
                    //    List<CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador> ListaPeriodoAFP = new List<CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador>();

                    //    CapaDeNegocios.DatosLaborales.cPeriodoTrabajador PeriodoElegido = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
                    //    CapaDeNegocios.DatosLaborales.cRegimenTrabajador RegimenElegido = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
                    //    CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador AFPElegido = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();

                    //    if (AuxiliarPeriodoTrabajador.Count == 0)
                    //    {
                    //        throw new cReglaNegociosException("No hay periodos para el trabajador: " + Nombre + " y el mes " + smes + "/" + saño);
                    //    }

                    //    if (AuxiliarPeriodoTrabajador.Count > 0)
                    //    {
                    //        foreach (CapaDeNegocios.DatosLaborales.cPeriodoTrabajador item in AuxiliarPeriodoTrabajador)
                    //        {

                    //            CapaDeNegocios.DatosLaborales.cRegimenTrabajador auxiliarRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();

                    //            ListaRegimenTrabajador = auxiliarRegimenTrabajador.TraerRegimenTrabajadorMes(item.IdtPeriodoTrabajador, new DateTime(Convert.ToInt16(saño), Convert.ToInt16(Mes(smes)), 1));
                    //            ListaPeriodoAFP = AFPElegido.TraerRegimenPensionarioxMes(item.IdtPeriodoTrabajador, new DateTime(Convert.ToInt16(saño), Convert.ToInt16(Mes(smes)), 1));

                    //            ListaRegimenTrabajador = auxiliarRegimenTrabajador.TraerRegimenTrabajadorMes(item.IdtPeriodoTrabajador, new DateTime(Convert.ToInt16(saño), Convert.ToInt16(Mes(smes)), 1));

                    //            foreach (CapaDeNegocios.DatosLaborales.cRegimenTrabajador item2 in ListaRegimenTrabajador)
                    //            {
                    //                if (item2.IdtMeta == sidtmeta)
                    //                {
                    //                    PeriodoElegido = item;
                    //                    RegimenElegido = item2;
                    //                    FechaInicio = PeriodoElegido.FechaInicio;
                    //                    MontoPago = RegimenElegido.MontoPago.ToString();
                    //                    foreach (DataRow rowCargo in oDataCargo.Select("idtcargo = '" + RegimenElegido.IdtCargo.ToString() + "'"))
                    //                    {
                    //                        IdtCargo = Convert.ToInt32(rowCargo[0].ToString());
                    //                        Cargo = rowCargo[1].ToString();
                    //                    }
                    //                }
                    //            }

                    //            //error cuando no encuentra un periodo = a la meta
                    //            if (PeriodoElegido.IdtPeriodoTrabajador == 0)
                    //            {
                    //                PeriodoElegido = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
                    //                PeriodoElegido = item;
                    //                foreach (CapaDeNegocios.DatosLaborales.cRegimenTrabajador item2 in ListaRegimenTrabajador)
                    //                {
                    //                    RegimenElegido = item2;
                    //                    FechaInicio = PeriodoElegido.FechaInicio;
                    //                    MontoPago = RegimenElegido.MontoPago.ToString();
                    //                    foreach (DataRow rowCargo in oDataCargo.Select("idtcargo = '" + RegimenElegido.IdtCargo.ToString() + "'"))
                    //                    {
                    //                        IdtCargo = Convert.ToInt32(rowCargo[0].ToString());
                    //                        Cargo = rowCargo[1].ToString();
                    //                    }
                    //                }

                    //            }

                    //        }
                    //    }


                    //    FechaInicio = PeriodoElegido.FechaInicio;



                    //    if (tipoPlanilla == "RACIONAMIENTO")
                    //    {
                    //        contador += 1;
                    //        dgvDetallePlanilla.Rows.Add("0", "I", "", contador, pidtrabajador, Nombre, IdtCargo, Cargo, DNI, snumerometa, FechaInicio);
                    //        dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["Remuneracion"].Value = MontoPago;
                    //        dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["FECHAFIN"].Value = PeriodoElegido.FechaFin;
                    //        dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["FECHAINICIOMETA"].Value = RegimenElegido.FechaInicio;
                    //    }
                    //    else
                    //    {
                    //        if (ListaPeriodoAFP.Count > 0)
                    //        {
                    //            TienAFP = true;
                    //            AFPElegido = ListaPeriodoAFP[ListaPeriodoAFP.Count - 1];
                    //            foreach (DataRow rowAFP in oDataAFP.Select("idtafp = '" + AFPElegido.IdtAFP.ToString() + "'"))
                    //            {
                    //                AFP = rowAFP[1].ToString();
                    //            }

                    //            contador += 1;
                    //            dgvDetallePlanilla.Rows.Add("0", "I", "", contador, pidtrabajador, Nombre, IdtCargo, Cargo, DNI, snumerometa, FechaInicio);
                    //            dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["Remuneracion"].Value = MontoPago;
                    //            dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["FECHAFIN"].Value = PeriodoElegido.FechaFin;
                    //            dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["FECHAINICIOMETA"].Value = RegimenElegido.FechaInicio;
                    //        }
                    //        else
                    //        {
                    //            TienAFP = false;
                    //            MessageBox.Show("El trabajador " + DNI + " : " + Nombre + " no tiene datos de AFP. No se podra agregar al trabajador. Corrija su periodo en Mantenimiento de Trabajadores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        }

                    //    }
                    //}
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el metodo cargarTrabajador: " + ex.Message);
            }
        }

        private void CargarTrabajadorVacacionesTruncas(CapaDeNegocios.cTrabajador TrabajadorVacaciones)
        {
            try
            {
                CapaDeNegocios.DatosLaborales.cPeriodoTrabajador AuxiliarPeriodoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
                AuxiliarPeriodoTrabajador = AuxiliarPeriodoTrabajador.traerUltimoPeriodoTrabajador(TrabajadorVacaciones.IdTrabajador);
                CapaDeNegocios.DatosLaborales.cRegimenTrabajador ListaRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
                CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador ListaPeriodoAFP = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();


                CapaDeNegocios.DatosLaborales.cPeriodoTrabajador PeriodoElegido = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
                CapaDeNegocios.DatosLaborales.cRegimenTrabajador RegimenElegido = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
                CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador AFPElegido = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();
                ListaRegimenTrabajador = ListaRegimenTrabajador.TraerUltimoRegimenTrabajadorInclusoTerminado(AuxiliarPeriodoTrabajador.IdtPeriodoTrabajador);
                ListaPeriodoAFP = AFPElegido.TraerUltimoRegimenPensionario(AuxiliarPeriodoTrabajador.IdtPeriodoTrabajador);

                PeriodoElegido = AuxiliarPeriodoTrabajador;
                RegimenElegido = ListaRegimenTrabajador;
                RegimenElegido.Cargo = RegimenElegido.Cargo.TraerCargoPorXcodigo(RegimenElegido.IdtCargo);

                contador += 1;
                dgvDetallePlanilla.Rows.Add();

                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["txtIdTDetallePlanilla"].Value = "0";
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["txtAccion"].Value = "I";
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["txtApellidosNombres"].Value = TrabajadorVacaciones.ApellidoPaterno + " " + TrabajadorVacaciones.ApellidoMaterno + ", " + TrabajadorVacaciones.Nombres;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["txtDNI"].Value = TrabajadorVacaciones.Dni;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["colCargo"].Value = RegimenElegido.Cargo.Descripcion; 
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["Remuneracion"].Value = RegimenElegido.MontoPago.ToString();
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["FechaInicio"].Value = PeriodoElegido.FechaInicio;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["fechafin"].Value = PeriodoElegido.FechaFin;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["FECHAINICIOMETA"].Value = RegimenElegido.FechaInicio;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al traer el trabajador de vacaciones:" + ex.Message);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
