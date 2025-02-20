﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using info.lundin.math;
using CapaDeNegocios;
using System.Configuration;
using CapaUsuario.Properties;
using CapaDeNegocios.Obras;

namespace CapaUsuario.Planilla
{
    public partial class frmMantenimientoDetallePlanilla : Form
    {
        int con_ingresos = 0, con_trabajador = 0, con_descuento = 0, con_empleador = 0;
        int inicioIngresos = 25, inicioAportacionesTra = 27, inicioDescuentos = 28, inicioAportacionesEmple = 30, inicioNetoACobrar = 31;
        int contador = 0;
        int sidtplanilla;
        int sidtregimenlaboral;
        int sidtmeta;
        string snumerometa = "";
        string smes = "";
        string saño = "";
        string splantilla = "";
        public string[,] sselecciontrabajadores;
        string[,] smingresos;
        string[,] sma_trabajador;
        string[,] smdescuentos;
        string[,] sma_empleador;
        int sfilasselecciontrabajadores;
        decimal sUIT = 0;
        decimal sRemuneracionBasica = 0;
        int sidttrabajador = 0;
        double sRemuneracion_5ta = 0;
        string[] sIngresosDesc_5ta;
        double[,] sIngresos_5ta;
        
        string AFP = "";
        string Cuspp = "";
        string TipoComision = "";
        decimal PrimaSeguros = 0;
        decimal AporteObligatorio = 0;
        decimal RemuneracionAsegurable = 0;
        decimal ComisionFlujo = 0;
        decimal ComisionMixta = 0;

        bool ssuspencionrenta4ta;
        bool sessaludvida;
        bool sscrt;
        bool sscrtp;

        bool esTareo= false;
        bool esMetaJornal = false;

        DataTable oDataDetallePlanilla = new DataTable();
        DataTable oDataTrabajador = new DataTable();
        DataTable oDataPeriodoTrabajador = new DataTable();
        DataTable oDataRegimenTrabajador = new DataTable();
        DataTable oDataRegimenPensionarioTrabajador = new DataTable();
        DataTable oDataRegimenSaludTrabajador = new DataTable();
        DataTable oDataCargo = new DataTable();
        DataTable oDataAFP = new DataTable();
        DataTable oDataComisionAFP = new DataTable();
        DataTable oDataPlantillaPlanilla = new DataTable();

        public CapaDeNegocios.Planillas.cPlanilla oPlanilla;

        CapaDeNegocios.Trabajadores.cDatosFijo oDatoFijo = new CapaDeNegocios.Trabajadores.cDatosFijo(0);
        CapaDeNegocios.Planillas.cDetallePlanilla miDetallePlanilla = new CapaDeNegocios.Planillas.cDetallePlanilla();
        CapaDeNegocios.Planillas.cDetallePlanillaIngresos miDetallePlanillaIngresos = new CapaDeNegocios.Planillas.cDetallePlanillaIngresos();
        CapaDeNegocios.Planillas.cDetallePlanillaATrabajador miDetallePlanillaATrabajador = new CapaDeNegocios.Planillas.cDetallePlanillaATrabajador();
        CapaDeNegocios.Planillas.cDetallePlanillaAEmpleador miDetallePlanillaAEmpleador = new CapaDeNegocios.Planillas.cDetallePlanillaAEmpleador();
        CapaDeNegocios.Planillas.cDetallePlanillaDescuentos miDetallePlanillaDescuentos = new CapaDeNegocios.Planillas.cDetallePlanillaDescuentos();
        CapaDeNegocios.cTrabajador miTrabajador = new CapaDeNegocios.cTrabajador();
        CapaDeNegocios.DatosLaborales.cPeriodoTrabajador miPeriodoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
        CapaDeNegocios.DatosLaborales.cRegimenTrabajador miRegimenTrabajor = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
        CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador miRegimenPensionarioTrabajor = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();
        CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador miRegimenSaludTrajador = new CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador();
        CapaDeNegocios.Contrato.cCargo miCargo = new CapaDeNegocios.Contrato.cCargo();
        CapaDeNegocios.Asistencia.cAsistenciaTrabajador oAsistenciaTrabajador = new CapaDeNegocios.Asistencia.cAsistenciaTrabajador();
        CapaDeNegocios.cListaAFP miAFP = new CapaDeNegocios.cListaAFP(); 
        CapaDeNegocios.cComisionesAFP miComisionAFP = new CapaDeNegocios.cComisionesAFP();

        public CapaDeNegocios.Asistencia.cTrabajadorReloj miTrabajadorReloj;

        private CapaDeNegocios.AsistenciaGeneral.cCatalogoJornadaLaboral miCatalogo = new CapaDeNegocios.AsistenciaGeneral.cCatalogoJornadaLaboral();
        private CapaDeNegocios.Asistencia.cCatalogoAsistencia miCatalogoAsistencia = new CapaDeNegocios.Asistencia.cCatalogoAsistencia();
        private CapaDeNegocios.Asistencia.cHorario oHorario = new CapaDeNegocios.Asistencia.cHorario();
        private CapaDeNegocios.Asistencia.cAsistenciaMes AsistenciaMes = new CapaDeNegocios.Asistencia.cAsistenciaMes();

        private CapaDeNegocios.Tareos.cPlantillaTareo oPlantillaTareo = new CapaDeNegocios.Tareos.cPlantillaTareo();

        public frmMantenimientoDetallePlanilla()
        {
            InitializeComponent();
        }

        private void frmMantenimientoDetallePlanilla_Load(object sender, EventArgs e)
        {
            DibujarDataGrid();
            MostrarColumnas();
            oDataTrabajador = miTrabajador.ObtenerListaTrabajadores("Todos");
            oDataPeriodoTrabajador = miPeriodoTrabajador.ListarPeriodoTrabajador(0);
            oDataRegimenTrabajador = miRegimenTrabajor.ListarRegimenTrabajador(0);
            oDataRegimenPensionarioTrabajador = miRegimenPensionarioTrabajor.ListarRegimenPensionarioTrabajador(0);
            oDataRegimenSaludTrabajador = miRegimenSaludTrajador.ListarRegimenSaludTrabajador(0);
            oDataCargo = miCargo.ListaCargos();
            oDataAFP = miAFP.ObtenerListaAFP();
            Variables();
            CargarDatos();
        }

        private void btnAprobacion_Click(object sender, EventArgs e)
        {

        }
        
        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                CapaUsuario.Tareo.frmImportarTareo fImportarTareo = new CapaUsuario.Tareo.frmImportarTareo();
                cMetaJornal miMetaJornal = new cMetaJornal();
                fImportarTareo.RecibirDatos(0, splantilla, sidtmeta);
                if (fImportarTareo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                   
                    dgvDetallePlanilla.Rows.Clear();
                    DataTable oDataTareo = new DataTable();
                    DataTable oDataDetalleTareo = new DataTable();

                    CapaDeNegocios.Tareos.cTareo miTareo = new CapaDeNegocios.Tareos.cTareo();
                    CapaDeNegocios.Tareos.cDetalleTareo miDetalleTareo = new CapaDeNegocios.Tareos.cDetalleTareo();

                    oDataTareo = miTareo.ListarTareo(sidtmeta);

                    oPlantillaTareo = oPlantillaTareo.TraerPlantillaTareoXNombre(fImportarTareo.sdescripcion);
                   
                    //oDataDetalleTareo = miDetalleTareo.ListarDetalleTareo(Convert.ToInt32(oDataTareo.Compute("MAX(idttareo)", "descripcion = '" + splantilla + "'")));
                    oDataDetalleTareo = miDetalleTareo.ListarDetalleTareo(fImportarTareo.sidttareoimportar);
                    //foreach (DataRow rowdetalletareo in oDataDetalleTareo.Select("idttareo = '" + Convert.ToInt32(oDataTareo.Compute("MAX(idttareo)", "descripcion = '" + splantilla + "'")) + "'"))
                    foreach (DataRow rowdetalletareo in oDataDetalleTareo.Select("idttareo = '" + fImportarTareo.sidttareoimportar + "'"))
                    {
                        
                        if (esTareo && esMetaJornal)
                        {
                            if (rowdetalletareo[1].ToString() == "")
                            {
                                MessageBox.Show("No se selecciono la categoria en el tareo. Verifique el tareo que todos los trabajadores tengan categoria seleccionada ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            miMetaJornal = MetaJornal(rowdetalletareo[1].ToString(), sidtmeta);
                            if (miMetaJornal.Opcion == false)
                            {
                                if (miMetaJornal.Jornal == 0)
                                {
                                    MessageBox.Show("La Remuneración de los Obreros diaria para la siguiente categoria: '" + rowdetalletareo[1].ToString() + "', no existe o es 0.00, debe crearlo en MetaJornal. o verifique que todos los obreros del tareo tengan categoria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else
                            {
                                if (miMetaJornal.Mensual == 0)
                                {
                                    MessageBox.Show("La Remuneración de los Obreros Mensual para la siguiente categoria: '"  + rowdetalletareo[1].ToString() + "', no existe o es 0.00, debe crearlo en MetaJornal. o verifique que todos los obreros del tareo tengan categoria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                        CargarTrabajador(Convert.ToInt32(rowdetalletareo[4].ToString()), splantilla);
                        if (dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[4].Value.ToString() == rowdetalletareo[4].ToString())
                        {
                            dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["colCargo"].Value = rowdetalletareo[1].ToString();
                            //dias laborados col 12
                            dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["DiasLaborados"].Value = rowdetalletareo[3].ToString();
                            dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["DIASMES"].Value = rowdetalletareo[3].ToString();
                            
                            if (esTareo && esMetaJornal)
                            {
                                //monto jornal o mensual col 11
                                if (miMetaJornal.Opcion == false)
                                {
                                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["Remuneracion"].Value = String.Format("{0:0.00}", miMetaJornal.Jornal);
                                }
                                else
                                {
                                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["Remuneracion"].Value = String.Format("{0:0.00}", miMetaJornal.Mensual);
                                }
                                
                            }
                        }
                        TotalRemuneracion(dgvDetallePlanilla.Rows.Count - 1);
                    }
                    btnImportar.Enabled = false;
                }
            }
            catch(Exception EX)
            {
                MessageBox.Show(EX.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        } 

        private void btnRenta5ta_Click(object sender, EventArgs e)
        {
            try
            {
                if (sidttrabajador != 0)
                {
                    CapaUsuario.Planilla.frmRenta5taProyectado fRenta5taProyectado = new frmRenta5taProyectado();
                    fRenta5taProyectado.RecibirDatos(sidtplanilla, sidttrabajador, smes, saño, sRemuneracion_5ta, sIngresosDesc_5ta, sIngresos_5ta, sUIT);
                    fRenta5taProyectado.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No selecciono a un trabajador, seleccione uno.", "Gestion del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }

        private void btnAgregarTrabajador_Click(object sender, EventArgs e)
        {
            try
            {
                if (oPlanilla.TipoPlanilla == CapaDeNegocios.Planillas.enumTipoPlanilla.VACACIONES_TRUNCAS)
                {
                    frmTraerTrabajadorVac fTraerTrabajadorVac = new frmTraerTrabajadorVac();
                    if (fTraerTrabajadorVac.ShowDialog() == DialogResult.OK)
                    {
                        CargarTrabajador(fTraerTrabajadorVac.TrabajadorSeleccionado.IdTrabajador, splantilla);
                        TotalRemuneracion(dgvDetallePlanilla.Rows.Count - 1);
                    }
                }
                else
                {
                    CapaUsuario.Planilla.frmSeleccionTrabajadorPlanilla fSeleccionTrabajadorPlanilla = new frmSeleccionTrabajadorPlanilla();
                    fSeleccionTrabajadorPlanilla.RecibirDatos(smes, saño, sidtmeta, sidtregimenlaboral);
                    if (fSeleccionTrabajadorPlanilla.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        sselecciontrabajadores = fSeleccionTrabajadorPlanilla.strabajadores;
                        sfilasselecciontrabajadores = fSeleccionTrabajadorPlanilla.sfilasselecciontrabajadores;

                        int z = 0;
                        for (int i = 0; i < sfilasselecciontrabajadores; i++)
                        {
                            z = 0;
                            foreach (DataGridViewRow rowDgvDetallePlanilla in dgvDetallePlanilla.Rows)
                            {
                                if (Convert.ToString(rowDgvDetallePlanilla.Cells[4].Value) == sselecciontrabajadores[i, 0].ToString())
                                {
                                    z = 1;
                                }
                            }
                            if (z == 0)
                            {
                                CargarTrabajador(Convert.ToInt32(sselecciontrabajadores[i, 0].ToString()), splantilla);
                                TotalRemuneracion(dgvDetallePlanilla.Rows.Count - 1);
                            }
                            else
                            {
                                MessageBox.Show("El trabajador ya se encuentra en la planilla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (dgvDetallePlanilla.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos que se puedan calcular.", "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
                return;
            }
            foreach (DataGridViewRow row in dgvDetallePlanilla.Rows)
            {
                DatosAFP(row.Index);
                CalcularIngresos(row.Index);
                CalcularA_Trabajador(row.Index);
                CalcularDescuentos(row.Index);
                CalcularA_Empleador(row.Index);
                CalcularTotalDescuentos(row.Index);
                CalcularNetoaCobrar(row.Index);
            }
            Cursor = Cursors.Default;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToInt32(saño)<=2023)
                {
                    MessageBox.Show("No se puede modificar planillas de años anteriores al actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bool bOk = false;
                foreach (DataGridViewRow row in dgvDetallePlanilla.Rows)
                {
                    miDetallePlanilla.IdtDetallePlanilla = Convert.ToInt32(row.Cells[0].Value);
                    miDetallePlanilla.Cargo = Convert.ToString(row.Cells["colCargo"].Value);
                    miDetallePlanilla.FechaInicio = Convert.ToDateTime(row.Cells["FechaInicio"].Value);
                    miDetallePlanilla.DiasLaborados = Convert.ToInt32(row.Cells["DiasLaborados"].Value);
                    //Numero celdas 24 porque son 23 celdas precargadas
                    miDetallePlanilla.TotalIngresos = Convert.ToDecimal(row.Cells[inicioIngresos + con_ingresos].Value);
                    //Numero celdas 25 porque se añaden 1 celda remuneracion afecta
                    miDetallePlanilla.TotalATrabajador = Convert.ToDecimal(row.Cells[inicioAportacionesTra + con_ingresos + con_trabajador].Value);
                    //NUmero 27 porque se añade Total Desceuntos + Total Aportaciones
                    miDetallePlanilla.TotalDescuentos = Convert.ToDecimal(row.Cells[inicioDescuentos + con_ingresos + con_trabajador + con_descuento].Value);
                    //NUmero 28 porque se añade Total Desceuntos + Total Aportaciones
                    miDetallePlanilla.TotalAEmpleador = Convert.ToDecimal(row.Cells[inicioAportacionesEmple + con_ingresos + con_trabajador + con_descuento + con_empleador].Value);
                    miDetallePlanilla.NetoaCobrar = Convert.ToDecimal(row.Cells[inicioNetoACobrar + con_ingresos + con_trabajador + con_descuento + con_empleador].Value);
                    miDetallePlanilla.IdtTrabajador = Convert.ToInt32(row.Cells[4].Value);
                    miDetallePlanilla.IdtPlanilla = sidtplanilla;

                    miDetallePlanilla.Sueldopactado = Convert.ToDecimal(row.Cells["SUELDOPACTADO"].Value);
                    miDetallePlanilla.Sueldoafecto = Convert.ToDecimal(row.Cells["SUELDOAFECTO"].Value);
                    miDetallePlanilla.Jornal = Convert.ToBoolean(row.Cells["JORNAL"].Value);
                    miDetallePlanilla.SueldoDespuesTardanzas = Convert.ToDecimal(row.Cells["SUELDOFALTASTAR"].Value);
                    miDetallePlanilla.SueldoMes = Convert.ToDecimal(row.Cells["TotalRemuneracio"].Value);
                    miDetallePlanilla.DiasMes = Convert.ToInt32(row.Cells["DIASMES"].Value);
                    miDetallePlanilla.DiasSuspendidos = Convert.ToInt32(row.Cells["DIASSUSPENDIDOS"].Value);
                    if (row.Cells["fechafin"].Value.ToString() != "")
                    {
                        miDetallePlanilla.FechaFin = Convert.ToDateTime(row.Cells["fechafin"].Value);
                    }
                    
                    miDetallePlanilla.FechaInicioMeta = Convert.ToDateTime(row.Cells["FECHAINICIOMETA"].Value);

                    miDetallePlanilla.SPensiones = Convert.ToInt32(row.Cells["CODAFP"].Value);
                    if (row.Cells["OBSERVACIONES"].Value == null)
                    {
                        miDetallePlanilla.Observacion = "";
                    }
                    
                    else
                    {
                        miDetallePlanilla.Observacion = row.Cells["OBSERVACIONES"].Value.ToString();
                    }
                    if (Convert.ToString(row.Cells[1].Value) == "I")
                    {
                        miDetallePlanilla.CrearDetallePlanilla(miDetallePlanilla);
                        oDataDetallePlanilla = miDetallePlanilla.ListarDetallePlanilla(sidtplanilla);
                        miDetallePlanilla.IdtDetallePlanilla = Convert.ToInt32(oDataDetallePlanilla.Compute("MAX(idtdetalleplanilla)", ""));
                        row.Cells[0].Value = miDetallePlanilla.IdtDetallePlanilla.ToString();
                        row.Cells[1].Value = "M";
                        bOk = true;
                    }
                    if (Convert.ToString(row.Cells[1].Value) == "M")
                    {
                        miDetallePlanilla.ModificarDetallePlanilla(miDetallePlanilla);
                        bOk = true;
                    }
                    miDetallePlanillaIngresos.EliminarDetallePlanillaIngresos(Convert.ToInt32(row.Cells[0].Value));
                    miDetallePlanillaATrabajador.EliminarDetallePlanillaATrabajador(Convert.ToInt32(row.Cells[0].Value));
                    miDetallePlanillaDescuentos.EliminarDetallePlanillaDescuentos(Convert.ToInt32(row.Cells[0].Value));
                    miDetallePlanillaAEmpleador.EliminarDetallePlanillaAEmpleador(Convert.ToInt32(row.Cells[0].Value));
                    if (con_ingresos > 0)
                    {
                        for (int i = 0; i < con_ingresos; i++)
                        {
                            string z = dgvDetallePlanilla.Columns[inicioIngresos + i].Name.ToString();
                            int x = dgvDetallePlanilla.Columns[inicioIngresos + i].Name.Length;
                            int y = Convert.ToInt32(dgvDetallePlanilla.Columns[inicioIngresos + i].Name.Substring(1, x - 1));
                            miDetallePlanillaIngresos.IdtDetallePlanillaIngresos = 0;
                            miDetallePlanillaIngresos.Monto = Convert.ToDecimal(row.Cells[inicioIngresos + i].Value);
                            miDetallePlanillaIngresos.IdtMaestroIngresos = y;
                            miDetallePlanillaIngresos.IdtDetallePlanilla = Convert.ToInt32(row.Cells[0].Value);
                            miDetallePlanillaIngresos.CrearDetallePlanillaIngresos(miDetallePlanillaIngresos);
                        }
                    }
                    if (con_trabajador > 0)
                    {
                        for (int i = 0; i < con_trabajador; i++)
                        {
                            string z = dgvDetallePlanilla.Columns[inicioAportacionesTra + con_ingresos + i].Name.ToString();
                            int x = dgvDetallePlanilla.Columns[inicioAportacionesTra + con_ingresos + i].Name.Length;
                            int y = Convert.ToInt32(dgvDetallePlanilla.Columns[inicioAportacionesTra + con_ingresos + i].Name.Substring(1, x - 1));
                            miDetallePlanillaATrabajador.IdtDetallePlanillaATrabajador = 0;
                            miDetallePlanillaATrabajador.Monto = Convert.ToDecimal(row.Cells[inicioAportacionesTra + con_ingresos + i].Value);
                            miDetallePlanillaATrabajador.IdtMaestroATrabajador = y;
                            miDetallePlanillaATrabajador.IdtDetallePlanilla = Convert.ToInt32(row.Cells[0].Value);
                            miDetallePlanillaATrabajador.CrearDetallePlanillaATrabajador(miDetallePlanillaATrabajador);
                        }
                    }
                    if (con_descuento > 0)
                    {
                        for (int i = 0; i < con_descuento; i++)
                        {
                            string z = dgvDetallePlanilla.Columns[inicioDescuentos + con_ingresos + con_trabajador + i].Name.ToString();
                            int x = dgvDetallePlanilla.Columns[inicioDescuentos + con_ingresos + con_trabajador + i].Name.Length;
                            int y = Convert.ToInt32(dgvDetallePlanilla.Columns[inicioDescuentos + con_ingresos + con_trabajador + i].Name.Substring(1, x - 1));
                            miDetallePlanillaDescuentos.IdtDetallePlanillaDescuentos = 0;
                            miDetallePlanillaDescuentos.Monto = Convert.ToDecimal(row.Cells[inicioDescuentos + con_ingresos + con_trabajador + i].Value);
                            miDetallePlanillaDescuentos.IdtMaestroDescuentos = y;
                            miDetallePlanillaDescuentos.IdtDetallePlanilla = Convert.ToInt32(row.Cells[0].Value);
                            miDetallePlanillaDescuentos.CrearDetallePlanillaDescuentos(miDetallePlanillaDescuentos);
                        }
                    }
                    if (con_empleador > 0)
                    {
                        for (int i = 0; i < con_empleador; i++)
                        {
                            string z = dgvDetallePlanilla.Columns[inicioAportacionesEmple + con_ingresos + con_trabajador + con_descuento + i].Name.ToString();
                            int x = dgvDetallePlanilla.Columns[inicioAportacionesEmple + con_ingresos + con_trabajador + con_descuento + i].Name.Length;
                            int y = Convert.ToInt32(dgvDetallePlanilla.Columns[inicioAportacionesEmple + con_ingresos + con_trabajador + con_descuento + i].Name.Substring(1, x - 1));
                            miDetallePlanillaAEmpleador.IdtDetallePlanillaAEmpleador = 0;
                            miDetallePlanillaAEmpleador.Monto = Convert.ToDecimal(row.Cells[inicioAportacionesEmple + con_ingresos + con_trabajador + con_descuento + i].Value);
                            miDetallePlanillaAEmpleador.IdtMaestroAEmpleador = y;
                            miDetallePlanillaAEmpleador.IdtDetallePlanilla = Convert.ToInt32(row.Cells[0].Value);
                            miDetallePlanillaAEmpleador.CrearDetallePlanillaAEmpleador(miDetallePlanillaAEmpleador);
                        }
                    }
                }
                if (bOk == false)
                {
                    MessageBox.Show("No existen datos que se puedan registrar", "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CargarDatos();
                }

                MessageBox.Show("Datos Guardados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception EX)
            {
                MessageBox.Show("Error al guardar los datos: " + EX.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dgvDetallePlanilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetallePlanilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                sidttrabajador = Convert.ToInt32(dgvDetallePlanilla.Rows[e.RowIndex].Cells[4].Value);
                Ingresos_5ta(e.RowIndex);
                if (dgvDetallePlanilla.Rows[e.RowIndex].Cells[2].Selected == true)
                {
                    if (dgvDetallePlanilla.Rows[e.RowIndex].Cells[0].Value == null)
                    {
                        dgvDetallePlanilla.Rows.RemoveAt(e.RowIndex);
                        return;
                    }
                    if (Convert.ToString(dgvDetallePlanilla.Rows[e.RowIndex].Cells[0].Value) == "")
                    {
                        MessageBox.Show("No existen datos que se puedan Eliminar", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (MessageBox.Show("Está seguro que desea eliminar al Trabajador de la Planilla", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                    miDetallePlanillaIngresos.EliminarDetallePlanillaIngresos(Convert.ToInt32(dgvDetallePlanilla.Rows[e.RowIndex].Cells[0].Value));
                    miDetallePlanillaATrabajador.EliminarDetallePlanillaATrabajador(Convert.ToInt32(dgvDetallePlanilla.Rows[e.RowIndex].Cells[0].Value));
                    miDetallePlanillaDescuentos.EliminarDetallePlanillaDescuentos(Convert.ToInt32(dgvDetallePlanilla.Rows[e.RowIndex].Cells[0].Value));
                    miDetallePlanillaAEmpleador.EliminarDetallePlanillaAEmpleador(Convert.ToInt32(dgvDetallePlanilla.Rows[e.RowIndex].Cells[0].Value));
                    miDetallePlanilla.EliminarDetallePlanilla(Convert.ToInt32(dgvDetallePlanilla.Rows[e.RowIndex].Cells[0].Value));
                    CargarDatos();
                }
            }
        }

        private void dgvDetallePlanilla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string x = dgvDetallePlanilla.Columns[e.ColumnIndex].Name.Substring(0, 1);
            string y = dgvDetallePlanilla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            decimal z = 0;

            decimal number2 = 0;
            if (dgvDetallePlanilla.Columns[e.ColumnIndex].Name == "OBSERVACIONES")
            {
                return;
            }
            if (decimal.TryParse(y, out number2) != true)
            {
                dgvDetallePlanilla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = String.Format("{0:0.00}", 0);
                return;
            }
            if (dgvDetallePlanilla.Rows[e.RowIndex].Cells["DiasLaborados"].Selected != true)
            {
                dgvDetallePlanilla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = String.Format("{0:0.00}", Convert.ToDecimal(y));
            }
            
            DatosAFP(e.RowIndex);
            CalcularIngresos(e.RowIndex);
            CalcularA_Trabajador(e.RowIndex);
            CalcularDescuentos(e.RowIndex);
            CalcularA_Empleador(e.RowIndex);
            CalcularTotalDescuentos(e.RowIndex);
            CalcularNetoaCobrar(e.RowIndex);
            CalcularTotalDescuentos(e.RowIndex);
            CalcularNetoaCobrar(e.RowIndex);
        }

        public void RecibirDatos(int pidtplanilla, string pnumero, string pmes, string paño, int pidtmeta, string pnumerometa, string pmeta, int pidtfuentefinanciamiento, string pfuentefinanciamiento, int pidtregimenlaboral, string pregimenlaboral, string pplantilla)
        {
            sidtplanilla = pidtplanilla;
            txtNumero.Text = pnumero;
            smes = pmes;
            saño = paño;
            txtFecha.Text = pmes + " - " + paño;
            sidtmeta = pidtmeta;
            txtMeta.Text = pmeta;
            snumerometa = pnumerometa;
            //sidtfuentefinanciamiento = pidtfuentefinanciamiento;
            txtFuenteFinanciamiento.Text = pfuentefinanciamiento;
            sidtregimenlaboral = pidtregimenlaboral;
            txtRegimenLaboral.Text = pregimenlaboral;
            splantilla = pplantilla;
           
        }

        private void CargarDatos()
        {
            try
            {
                contador = 0;
                dgvDetallePlanilla.Rows.Clear();
                cMetaJornal miMetaJornal = new cMetaJornal();

                oDataDetallePlanilla = miDetallePlanilla.ListarDetallePlanilla(sidtplanilla);
                foreach (DataRow row in oDataDetallePlanilla.Rows)
                {
                    CargarTrabajador(Convert.ToInt32(row[09].ToString()), splantilla);
                    if (esTareo && esMetaJornal)
                    {
                        //false = jornal true = mensual

                        miMetaJornal = MetaJornal(row[01].ToString(), sidtmeta);
                        if (miMetaJornal.Opcion == false)
                        {
                            dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["remuneracion"].Value = String.Format("{0:0.00}", miMetaJornal.Jornal);
                            //dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["SUELDOPACTADO"].Value = String.Format("{ 0:0.00}", miMetaJornal.Jornal);
                        }
                        else
                        {
                            dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["remuneracion"].Value = String.Format("{0:0.00}", miMetaJornal.Mensual);
                            //dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["SUELDOPACTADO"].Value = String.Format("{ 0:0.00}", miMetaJornal.Jornal);
                        }
                    }
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells[0].Value = row[0].ToString();//IdtDetallePlanilla
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells[1].Value = "M";
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells["colCargo"].Value = row[1].ToString();//Cargo
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells["FechaInicio"].Value = Convert.ToDateTime(row[2]).ToShortDateString();//Fecha Inicio
                    if (oPlanilla.TipoPlanilla == CapaDeNegocios.Planillas.enumTipoPlanilla.VACACIONES_TRUNCAS)
                    {
                        dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells["FechaFin"].Value = Convert.ToDateTime(row[19]).ToShortDateString();//Fecha Inicio
                    }
                    
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells[inicioIngresos + con_ingresos].Value = row[4].ToString();
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells[inicioAportacionesTra + con_ingresos + con_trabajador].Value = row[5].ToString();
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells[inicioDescuentos + con_ingresos + con_trabajador + con_descuento].Value = row[6].ToString();
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells[inicioAportacionesEmple + con_ingresos + con_trabajador + con_descuento + con_empleador].Value = row[7].ToString();
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells[inicioNetoACobrar + con_ingresos + con_trabajador + con_descuento + con_empleador].Value = row[8].ToString();
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells["SUELDOPACTADO"].Value = row[11].ToString();
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells["SUELDOAFECTO"].Value = row[12].ToString();
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells["OBSERVACIONES"].Value = row[13].ToString();
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells["JORNAL"].Value = row[15].ToString();
                    CargarIngresos(Convert.ToInt32(row[0].ToString()), dgvDetallePlanilla.RowCount - 1);
                    CargarATrabajador(Convert.ToInt32(row[0].ToString()), dgvDetallePlanilla.RowCount - 1);
                    CargarDescuentos(Convert.ToInt32(row[0].ToString()), dgvDetallePlanilla.RowCount - 1);
                    CargarAEmpleador(Convert.ToInt32(row[0].ToString()), dgvDetallePlanilla.RowCount - 1);
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells["DiasLaborados"].Value = row[3].ToString();//Dias Laborados
                    //codigo compatibilidad para versiones anteriores
                    if (Convert.ToInt16(row[20].ToString()) == 0)
                    {
                        dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells["DIASMES"].Value = row[3].ToString();//Dias Mes
                    }
                    else
                    {
                        dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells["DIASMES"].Value = row[20].ToString();//Dias Mes
                    }

                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells["DIASSUSPENDIDOS"].Value = row[16].ToString();//Dias suspendidos

                    if (row[18] == null)
                    {
                        dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells["SUELDOFALTASTAR"].Value = row[18].ToString();//Dias suspendidos
                    }
                    else
                    {
                        dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells["SUELDOFALTASTAR"].Value = row[18].ToString();//Dias suspendidos
                    }

                    if (Convert.ToDecimal(row[21]) == 0)
                    {
                        
                    }
                    else
                    {
                        dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells["TotalRemuneracio"].Value = row[21].ToString();//sueldo mes
                    }

                    TotalRemuneracion(dgvDetallePlanilla.Rows.Count - 1);
                    DatosAFP(dgvDetallePlanilla.RowCount - 1);
                    CalcularTotalDescuentos(dgvDetallePlanilla.RowCount - 1);
                    btnImportar.Enabled = false;
                    btnCalcular.Text = "Volver a Calcular";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en cargarDatos: " + ex.Message);
            }
        }

        /// <summary>
        /// Procedimiento para cargar los datos de un trabajador por su id al datagrid dgvDetallePlanilla
        /// </summary>
        /// <param name="pidtrabajador"></param>
        /// <param name="tipoPlanilla"></param>
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

                PlanillaEncontrada = PlanillaEncontrada.TraerPlanilla(sidtplanilla);

                miTrabajador.IdTrabajador = pidtrabajador;
                miTrabajador = miTrabajador.traerTrabajador(miTrabajador.IdTrabajador);

                PlanillaEncontrada = PlanillaEncontrada.TraerPLanillaConTrabajadorDuplicado(miTrabajador, PlanillaEncontrada.Mes, Convert.ToInt16(PlanillaEncontrada.Año), PlanillaEncontrada.IdtPlanilla);

                if (PlanillaEncontrada != null)
                {
                    MessageBox.Show("Se encontro al trabajador: " + miTrabajador.Nombres + " " + miTrabajador.ApellidoPaterno + " " + miTrabajador.ApellidoMaterno + " Cargo: " + PlanillaEncontrada.ListaDetallePlanilla[0].Cargo +
                        " en la planilla Nro: " + PlanillaEncontrada.Numero + " - " + PlanillaEncontrada.Descripcion, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (oPlanilla.TipoPlanilla == CapaDeNegocios.Planillas.enumTipoPlanilla.VACACIONES_TRUNCAS)
                {
                    foreach (DataRow rowTrabajador in oDataTrabajador.Select("id_trabajador = '" + pidtrabajador + "'"))
                    {
                        Nombre = rowTrabajador[2].ToString() + " " + rowTrabajador[3].ToString() + " " + rowTrabajador[4].ToString();
                        DNI = rowTrabajador[1].ToString();

                        CapaDeNegocios.DatosLaborales.cPeriodoTrabajador AuxiliarPeriodoTrabajador = miPeriodoTrabajador.traerUltimoPeriodoTrabajador(pidtrabajador);
                        CapaDeNegocios.DatosLaborales.cRegimenTrabajador ListaRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
                        CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador ListaPeriodoAFP = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();
                        

                        CapaDeNegocios.DatosLaborales.cPeriodoTrabajador PeriodoElegido = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
                        CapaDeNegocios.DatosLaborales.cRegimenTrabajador RegimenElegido = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
                        CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador AFPElegido = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();
                        ListaRegimenTrabajador = ListaRegimenTrabajador.TraerUltimoRegimenTrabajadorInclusoTerminado(AuxiliarPeriodoTrabajador.IdtPeriodoTrabajador);
                        ListaPeriodoAFP = AFPElegido.TraerUltimoRegimenPensionario(AuxiliarPeriodoTrabajador.IdtPeriodoTrabajador);

                        PeriodoElegido = AuxiliarPeriodoTrabajador;
                        RegimenElegido = ListaRegimenTrabajador;
                        FechaInicio = PeriodoElegido.FechaInicio;
                        
                        MontoPago = RegimenElegido.MontoPago.ToString();
                        foreach (DataRow rowCargo in oDataCargo.Select("idtcargo = '" + RegimenElegido.IdtCargo.ToString() + "'"))
                        {
                            IdtCargo = Convert.ToInt32(rowCargo[0].ToString());
                            Cargo = rowCargo[1].ToString();
                        }
                        contador += 1;
                        dgvDetallePlanilla.Rows.Add("0", "I", "", contador, pidtrabajador, Nombre, IdtCargo, Cargo, DNI, snumerometa, FechaInicio);
                        dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["Remuneracion"].Value = MontoPago;
                        dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["fechafin"].Value = PeriodoElegido.FechaFin;
                        dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["FECHAINICIOMETA"].Value = RegimenElegido.FechaInicio;


                    }
                }
                else
                {
                    foreach (DataRow rowTrabajador in oDataTrabajador.Select("id_trabajador = '" + pidtrabajador + "'"))
                    {
                        Nombre = rowTrabajador[2].ToString() + " " + rowTrabajador[3].ToString() + " " + rowTrabajador[4].ToString();
                        DNI = rowTrabajador[1].ToString();

                        List<CapaDeNegocios.DatosLaborales.cPeriodoTrabajador> AuxiliarPeriodoTrabajador = miPeriodoTrabajador.traerPeriodosMesTrabajador(pidtrabajador, new DateTime(Convert.ToInt16(saño), Convert.ToInt16(Mes(smes)), 1));
                        List<CapaDeNegocios.DatosLaborales.cRegimenTrabajador> ListaRegimenTrabajador = new List<CapaDeNegocios.DatosLaborales.cRegimenTrabajador>();
                        List<CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador> ListaPeriodoAFP = new List<CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador>();

                        CapaDeNegocios.DatosLaborales.cPeriodoTrabajador PeriodoElegido = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
                        CapaDeNegocios.DatosLaborales.cRegimenTrabajador RegimenElegido = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
                        CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador AFPElegido = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();

                        if (AuxiliarPeriodoTrabajador.Count == 0)
                        {
                            throw new cReglaNegociosException("No hay periodos para el trabajador: " + Nombre + " y el mes " + smes + "/" + saño);
                        }

                        if (AuxiliarPeriodoTrabajador.Count > 0)
                        {
                            foreach (CapaDeNegocios.DatosLaborales.cPeriodoTrabajador item in AuxiliarPeriodoTrabajador)
                            {

                                CapaDeNegocios.DatosLaborales.cRegimenTrabajador auxiliarRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();

                                ListaRegimenTrabajador = auxiliarRegimenTrabajador.TraerRegimenTrabajadorMes(item.IdtPeriodoTrabajador, new DateTime(Convert.ToInt16(saño), Convert.ToInt16(Mes(smes)), 1));
                                ListaPeriodoAFP = AFPElegido.TraerRegimenPensionarioxMes(item.IdtPeriodoTrabajador, new DateTime(Convert.ToInt16(saño), Convert.ToInt16(Mes(smes)), 1));

                                ListaRegimenTrabajador = auxiliarRegimenTrabajador.TraerRegimenTrabajadorMes(item.IdtPeriodoTrabajador, new DateTime(Convert.ToInt16(saño), Convert.ToInt16(Mes(smes)), 1));

                                foreach (CapaDeNegocios.DatosLaborales.cRegimenTrabajador item2 in ListaRegimenTrabajador)
                                {
                                    if (item2.IdtMeta == sidtmeta)
                                    {
                                        PeriodoElegido = item;
                                        RegimenElegido = item2;
                                        FechaInicio = PeriodoElegido.FechaInicio;
                                        MontoPago = RegimenElegido.MontoPago.ToString();
                                        foreach (DataRow rowCargo in oDataCargo.Select("idtcargo = '" + RegimenElegido.IdtCargo.ToString() + "'"))
                                        {
                                            IdtCargo = Convert.ToInt32(rowCargo[0].ToString());
                                            Cargo = rowCargo[1].ToString();
                                        }
                                    }
                                }

                                //error cuando no encuentra un periodo = a la meta
                                if (PeriodoElegido.IdtPeriodoTrabajador == 0)
                                {
                                    PeriodoElegido = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
                                    PeriodoElegido = item;
                                    foreach (CapaDeNegocios.DatosLaborales.cRegimenTrabajador item2 in ListaRegimenTrabajador)
                                    {
                                        RegimenElegido = item2;
                                        FechaInicio = PeriodoElegido.FechaInicio;
                                        MontoPago = RegimenElegido.MontoPago.ToString();
                                        foreach (DataRow rowCargo in oDataCargo.Select("idtcargo = '" + RegimenElegido.IdtCargo.ToString() + "'"))
                                        {
                                            IdtCargo = Convert.ToInt32(rowCargo[0].ToString());
                                            Cargo = rowCargo[1].ToString();
                                        }
                                    }

                                }

                            }
                        }


                        FechaInicio = PeriodoElegido.FechaInicio;



                        if (tipoPlanilla == "RACIONAMIENTO")
                        {
                            contador += 1;
                            dgvDetallePlanilla.Rows.Add("0", "I", "", contador, pidtrabajador, Nombre, IdtCargo, Cargo, DNI, snumerometa, FechaInicio);
                            dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["Remuneracion"].Value = MontoPago;
                            dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["FECHAFIN"].Value = PeriodoElegido.FechaFin;
                            dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["FECHAINICIOMETA"].Value = RegimenElegido.FechaInicio;
                        }
                        else
                        {
                            if (ListaPeriodoAFP.Count > 0)
                            {
                                TienAFP = true;
                                AFPElegido = ListaPeriodoAFP[ListaPeriodoAFP.Count - 1];
                                foreach (DataRow rowAFP in oDataAFP.Select("idtafp = '" + AFPElegido.IdtAFP.ToString() + "'"))
                                {
                                    AFP = rowAFP[1].ToString();
                                }

                                contador += 1;
                                dgvDetallePlanilla.Rows.Add("0", "I", "", contador, pidtrabajador, Nombre, IdtCargo, Cargo, DNI, snumerometa, FechaInicio);
                                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["Remuneracion"].Value = MontoPago;
                                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["FECHAFIN"].Value = PeriodoElegido.FechaFin;
                                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells["FECHAINICIOMETA"].Value = RegimenElegido.FechaInicio;
                            }
                            else
                            {
                                TienAFP = false;
                                MessageBox.Show("El trabajador " + DNI + " : " + Nombre + " no tiene datos de AFP. No se podra agregar al trabajador. Corrija su periodo en Mantenimiento de Trabajadores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException(" Error en el metodo cargarTrabajador: " + ex.Message);
            }
        }

        private void SuspencionRenta4ta(int pidtrabajador)
        {
            foreach (DataRow rowTrabajador in oDataTrabajador.Select("id_trabajador = '" + pidtrabajador + "'"))
            {
                ssuspencionrenta4ta = Convert.ToBoolean(rowTrabajador[6]);
            }
        }

        private void BuscarEssaludVida(int pidtrabajador)
        {
            foreach (DataRow rowTrabajador in oDataTrabajador.Select("id_trabajador = '" + pidtrabajador + "'"))
            {
                sessaludvida = Convert.ToBoolean(rowTrabajador[7]);
            }
        }

        private bool verificar65anio(string dnitrabajador)
        {
            bool valor = false;
            DateTime fechaFinMes = new DateTime(Convert.ToInt16(saño), Convert.ToInt16(Mes(smes)), 1);
            foreach (DataRow rowTrabajador in miTrabajador.ListaTrabajadoresX().Select("DNI = '" + dnitrabajador + "'"))
            {
                DateTime fechaNacimiento = Convert.ToDateTime(rowTrabajador[5]);
                
                int añosEdad = Convert.ToInt16( Math.Truncate(Convert.ToDouble( ((fechaFinMes - fechaNacimiento).Days) / 365)));
                
                if (añosEdad >= 65)
                {
                    valor = true;
                }
                else
                {
                    valor = false;
                }
            }
            return valor;
        }

        private void BuscarSCRT(int pidtrabajador)
        {
            foreach (DataRow rowTrabajador in oDataTrabajador.Select("id_trabajador = '" + pidtrabajador + "'"))
            {
                sscrt = Convert.ToBoolean(rowTrabajador[8]);
            }
        }

        private void BuscarSCRTPension(int pidtrabajador)
        {
            foreach (DataRow rowTrabajador in oDataTrabajador.Select("id_trabajador = '" + pidtrabajador + "'"))
            {
                if (rowTrabajador[9] is DBNull || rowTrabajador[9].ToString() =="")
                {
                    sscrtp = false;
                }
                else
                {
                    if (rowTrabajador[9].ToString().Substring(0, 1) == "1")
                    {
                        sscrtp = true;
                    }
                    else
                    {
                        sscrtp = false;
                    }
                }

            }
        }

        private void DatosAFP(int fila)
        {
            int codafp = 0;
            foreach (DataRow rowPeriodoTrabajador in oDataPeriodoTrabajador.Select("idttrabajador = '" + dgvDetallePlanilla.Rows[fila].Cells[4].Value.ToString() + "'"))
            {
                foreach (DataRow rowRegimenPensionarioTrabajador in oDataRegimenPensionarioTrabajador.Select("idtperiodotrabajador = '" + Convert.ToInt32(rowPeriodoTrabajador[0].ToString()) + "'"))
                {
                    Cuspp = rowRegimenPensionarioTrabajador[3].ToString();
                    TipoComision = rowRegimenPensionarioTrabajador[4].ToString();
                    foreach (DataRow rowAFP in oDataAFP.Select("idtafp = '" + Convert.ToInt32(rowRegimenPensionarioTrabajador[5].ToString()) + "'"))
                    {
                        codafp = Convert.ToInt16(rowAFP[0]);
                        AFP = rowAFP[1].ToString();
                    }
                    oDataComisionAFP = miComisionAFP.ListarComisionAFP(Convert.ToInt32(rowRegimenPensionarioTrabajador[5].ToString()));
                    int DiasMes = DateTime.DaysInMonth(Convert.ToInt32(saño), Convert.ToInt32(Mes(smes)));

                    bool encontradoAFP = false;
                    // 5 es onp y 6 es vacio y 7 es null
                    if (Convert.ToInt16(rowRegimenPensionarioTrabajador[5]) >= 5)
                    {
                        encontradoAFP = true;
                    }

                    for (int i = 0; i < oDataComisionAFP.Rows.Count - 1; i++)
                    {
                        DateTime diaAFP = Convert.ToDateTime(oDataComisionAFP.Rows[i]["mes"]);

                        
                        if (diaAFP.Month == Convert.ToInt16(Mes(smes)) && diaAFP.Year == Convert.ToInt16(saño) )
                        {
                            encontradoAFP = true;
                        }
                    }
                    if (encontradoAFP == false)
                    {
                        MessageBox.Show("No se encontro los datos de comisiones para la AFP " + AFP + " del mes " + smes + "/" + saño + ". El calculo sera 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    foreach (DataRow rowComisionAFP in oDataComisionAFP.Select("mes >= '01/" + Mes(smes) + "/" + saño + "' AND mes <= '" + DiasMes + "/" + Mes(smes) + "/" + saño + "'"))
                    {
                        PrimaSeguros = Convert.ToDecimal(rowComisionAFP[3].ToString());
                        AporteObligatorio = Convert.ToDecimal(rowComisionAFP[4].ToString());
                        RemuneracionAsegurable = Convert.ToDecimal(rowComisionAFP[5].ToString());
                        ComisionFlujo = Convert.ToDecimal(rowComisionAFP[6].ToString());
                        ComisionMixta = Convert.ToDecimal(rowComisionAFP[7].ToString());
                    }
                }
            }

            if (AFP == "")
            {
                dgvDetallePlanilla.Rows[fila].Cells["colAFP"].Value = "--";
            }
            else {
                dgvDetallePlanilla.Rows[fila].Cells["colAFP"].Value = AFP;
                dgvDetallePlanilla.Rows[fila].Cells["CODAFP"].Value = codafp;
            }
            if (TipoComision == "") { dgvDetallePlanilla.Rows[fila].Cells["colComision"].Value = "--"; }
            else { dgvDetallePlanilla.Rows[fila].Cells["colComision"].Value = TipoComision; }
            if (Cuspp == "") { dgvDetallePlanilla.Rows[fila].Cells["colCUSPP"].Value = "--"; }
            else { dgvDetallePlanilla.Rows[fila].Cells["colCUSPP"].Value = Cuspp; }
        }

        CapaDeNegocios.Obras.cMetaJornal MetaJornal(string categoria, int meta)
        {
            DataTable oDataMejaJornal = new DataTable();
            CapaDeNegocios.Obras.cMetaJornal miMetaJornal = new CapaDeNegocios.Obras.cMetaJornal();
            oDataMejaJornal = miMetaJornal.ListarMetaJornal(sidtmeta);

            foreach (DataRow rowmetajornal in oDataMejaJornal.Select("categoria = '" + categoria + "' AND idtmeta='" + meta + "'"))
            {
                miMetaJornal = miMetaJornal.TraerMetaJornal(Convert.ToInt16(rowmetajornal[0].ToString()));
            }
            return miMetaJornal;
        }

        private void CargarIngresos(int pidtdetalleplanilla, int fila)
        {
            int celda_inicio = inicioIngresos;
            DataTable oDataIngresos = new DataTable();
            oDataIngresos = miDetallePlanillaIngresos.ListarDetallePlanillaIngresos(pidtdetalleplanilla);
            foreach (DataRow rowingresos in oDataIngresos.Rows)
            {
                for (int i = 0; i < con_ingresos; i++)
                {
                    int y = dgvDetallePlanilla.Columns[celda_inicio + i].Name.Length - 1;
                    string x = dgvDetallePlanilla.Columns[celda_inicio + i].Name.Substring(1, y);
                    string z = rowingresos[2].ToString();
                    if (x == z)
                    {
                        dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + i].Value = Convert.ToDecimal(rowingresos[1].ToString());
                    }
                }
            }
        }

        private void CargarATrabajador(int pidtdetalleplanilla, int fila)
        {
            int celda_inicio = inicioAportacionesTra;
            DataTable oDataATrabajador = new DataTable();
            oDataATrabajador = miDetallePlanillaATrabajador.ListarDetallePlanillaATrabajador(pidtdetalleplanilla);
            foreach (DataRow rowatrabajador in oDataATrabajador.Rows)
            {
                for (int i = 0; i < con_trabajador; i++)
                {
                    int y = dgvDetallePlanilla.Columns[celda_inicio + con_ingresos + i].Name.Length - 1;
                    string x = dgvDetallePlanilla.Columns[celda_inicio + con_ingresos + i].Name.Substring(1, y);
                    string z = rowatrabajador[2].ToString();
                    if (x == z)
                    {
                        dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + i].Value = Convert.ToDecimal(rowatrabajador[1].ToString());
                    }
                }
            }
        }

        private void CargarDescuentos(int pidtdetalleplanilla, int fila)
        {
            int celda_inicio = inicioDescuentos;
            DataTable oDataDescuentos = new DataTable();
            oDataDescuentos = miDetallePlanillaDescuentos.ListarDetallePlanillaDescuentos(pidtdetalleplanilla);
            foreach (DataRow rowdescuentos in oDataDescuentos.Rows)
            {
                for (int i = 0; i < con_descuento; i++)
                {
                    int y = dgvDetallePlanilla.Columns[celda_inicio + con_ingresos + con_trabajador + i].Name.Length - 1;
                    string x = dgvDetallePlanilla.Columns[celda_inicio + con_ingresos + con_trabajador + i].Name.Substring(1, y);
                    string z = rowdescuentos[2].ToString();
                    if (x == z)
                    {
                        dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + i].Value = Convert.ToDecimal(rowdescuentos[1].ToString());
                    }
                }
            }
        }

        private void CargarAEmpleador(int pidtdetalleplanilla, int fila)
        {
            int celda_inicio = inicioAportacionesEmple;
            DataTable oDataAEmpleador = new DataTable();
            oDataAEmpleador = miDetallePlanillaAEmpleador.ListarDetallePlanillaAEmpleador(pidtdetalleplanilla);
            foreach (DataRow rowaempleador in oDataAEmpleador.Rows)
            {
                for (int i = 0; i < con_empleador; i++)
                {
                    int y = dgvDetallePlanilla.Columns[celda_inicio + con_ingresos + con_trabajador + con_descuento + i].Name.Length - 1;
                    string x = dgvDetallePlanilla.Columns[celda_inicio + con_ingresos + con_trabajador + con_descuento + i].Name.Substring(1, y);
                    string z = rowaempleador[2].ToString();
                    if (x == z)
                    {
                        dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + con_descuento + i].Value = Convert.ToDecimal(rowaempleador[1].ToString());
                    }
                }
            }
        }

        private void TotalRemuneracion(int fila)
        {
            decimal PagoTotal = 0;
            decimal PagoDespuesFaltas = 0;
            int DiasLaborados = 0;
            int AñoInicio = Convert.ToDateTime(dgvDetallePlanilla.Rows[fila].Cells["FechaInicio"].Value).Year;
            int MesInicio = Convert.ToDateTime(dgvDetallePlanilla.Rows[fila].Cells["FechaInicio"].Value).Month;
            int DiaInicio = Convert.ToDateTime(dgvDetallePlanilla.Rows[fila].Cells["FechaInicio"].Value).Day;
            int DiasMes = DateTime.DaysInMonth(Convert.ToInt32(saño), Convert.ToInt32(Mes(smes)));
            int DiasMes2 = 0;
            int sMes = Convert.ToInt32(Mes(smes));


            string fechafin = "";
            if (dgvDetallePlanilla.Rows[fila].Cells["FECHAFIN"].Value != null)
            {
                fechafin = dgvDetallePlanilla.Rows[fila].Cells["FECHAFIN"].Value.ToString();
            }

            int AñoFin = 0;
            int MesFin = 0;
            int DiaFin = 0;

            

            int DiasNoLaborados=0;
            //dias suspendidos por falta que no entra al descuento de planilla
            int diasSuspendidos = oAsistenciaTrabajador.ListarAsistenciaTrabajadorxMes(Convert.ToInt16(dgvDetallePlanilla.Rows[fila].Cells[4].Value), new DateTime(Convert.ToInt32(saño), Convert.ToInt32(Mes(smes)), 1)).Rows.Count;
            int diasfalta = oAsistenciaTrabajador.ListarAsistenciaTrabajadorxMesxFalta(Convert.ToInt16(dgvDetallePlanilla.Rows[fila].Cells[4].Value), new DateTime(Convert.ToInt32(saño), Convert.ToInt32(Mes(smes)), 1)).Rows.Count;
            dgvDetallePlanilla.Rows[fila].Cells["DIASSUSPENDIDOS"].Value = diasSuspendidos + diasfalta;
           

            decimal PagoDia = Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells["remuneracion"].Value) / 30;

            Boolean PagoMensual = true;
            
            if (esMetaJornal)
            {
                cMetaJornal miMetaJornal = new cMetaJornal();
                miMetaJornal = MetaJornal(dgvDetallePlanilla.Rows[fila].Cells["colCargo"].Value.ToString(), sidtmeta);
                PagoMensual = miMetaJornal.Opcion;

                
                DiasMes2 = Convert.ToInt32(dgvDetallePlanilla.Rows[fila].Cells["DIASMES"].Value);
                if (DiasMes2 == 0)
                {
                    DiasMes2 = Convert.ToInt32(dgvDetallePlanilla.Rows[fila].Cells["DiasLaborados"].Value);
                }
                DiasLaborados = DiasMes2;
                DiasNoLaborados = DiasMes - DiasLaborados;
                //if (oPlanilla.TipoImpresionTardanzaFalta == CapaDeNegocios.Planillas.enumTipoImpresionTardanzaFalta.AfectaAlSueldo)
                //{
                //    diasSuspendidos = diasSuspendidos + diasfalta;
                //}

                if (PagoMensual == false)
                {
                    PagoDia = Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells["remuneracion"].Value);
                    PagoTotal = Math.Round(Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells["remuneracion"].Value) * (DiasLaborados - diasSuspendidos), 2);
                    if (oPlanilla.TipoImpresionTardanzaFalta == CapaDeNegocios.Planillas.enumTipoImpresionTardanzaFalta.AfectaAlSueldo)
                    {
                        dgvDetallePlanilla.Rows[fila].Cells["FALTAS"].Value = Math.Round(PagoDia * diasfalta, 2);
                        PagoDespuesFaltas = Math.Round(Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells["remuneracion"].Value) * (DiasLaborados - diasSuspendidos - diasfalta), 2);
                    }
                    else
                    {
                        PagoDespuesFaltas = PagoTotal;
                    }

                    PagoDia = Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells["remuneracion"].Value);
                    dgvDetallePlanilla.Rows[fila].Cells["JORNAL"].Value = 1;
                }
                else
                {
                    PagoTotal = CalcularRemuneracionMensual(DiasLaborados, DiasNoLaborados, Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells["remuneracion"].Value), diasSuspendidos, oPlanilla.Tipocalculomensual, 0);
                    if (oPlanilla.TipoImpresionTardanzaFalta == CapaDeNegocios.Planillas.enumTipoImpresionTardanzaFalta.AfectaAlSueldo)
                    {
                        dgvDetallePlanilla.Rows[fila].Cells["FALTAS"].Value = Math.Round(PagoDia * diasfalta, 2);
                        PagoDespuesFaltas = CalcularRemuneracionMensual(DiasLaborados, DiasNoLaborados, Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells["remuneracion"].Value), diasSuspendidos, oPlanilla.Tipocalculomensual, diasfalta);
                    }
                    else
                    {
                        PagoDespuesFaltas = PagoTotal;
                    }
                    PagoDia = Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells["remuneracion"].Value) / 30;
                    dgvDetallePlanilla.Rows[fila].Cells["JORNAL"].Value = 0;
                }
            }
            else
            {
                dgvDetallePlanilla.Rows[fila].Cells["JORNAL"].Value = 0;

                //Significa que el empleado empezo este mes
                if (Convert.ToInt32(saño) == AñoInicio &&  sMes == MesInicio)
                {
                    DiasLaborados = 1 + DateTime.DaysInMonth(AñoInicio, MesInicio) - DiaInicio;

                    DiasNoLaborados = (DiasMes - DiasLaborados);
                }
                else
                {
                    DiasLaborados = DiasMes;
                    DiasNoLaborados = (DiasMes - DiasLaborados);
                }

                if (fechafin != "")
                {
                    AñoFin = Convert.ToDateTime(dgvDetallePlanilla.Rows[fila].Cells["FECHAFIN"].Value).Year;
                    MesFin = Convert.ToDateTime(dgvDetallePlanilla.Rows[fila].Cells["FECHAFIN"].Value).Month;
                    DiaFin = Convert.ToDateTime(dgvDetallePlanilla.Rows[fila].Cells["FECHAFIN"].Value).Day;

                    // SGNIFICA QU EIENE FECHA FIN EN EL MISMO MES
                    if (Convert.ToInt32(saño) == AñoFin && sMes == MesFin)
                    {
                        DiasLaborados = DiasLaborados - (DiasMes - DiaFin);
                        DiasNoLaborados = DiasNoLaborados + (DiasMes - DiaFin);
                    }
                }
                DiasMes2 = DiasLaborados;

                //SE HACE ESTA CONDICIONAL  porque los dias del tareo prima sobre la fecha de inicio ejemplo, la fecha de inicio puede ser 12 de febrero, pero los dias marcados son 20 
                if (esTareo)
                {
                    DiasMes2 = Convert.ToInt32(dgvDetallePlanilla.Rows[fila].Cells["DIASMES"].Value);
                    if (DiasMes2 == 0)
                    {
                        DiasMes2 = Convert.ToInt32(dgvDetallePlanilla.Rows[fila].Cells["DiasLaborados"].Value);
                    }
                    DiasLaborados = DiasMes2;
                    DiasNoLaborados = DiasMes - DiasMes2;
                }

                PagoTotal = CalcularRemuneracionMensual(DiasLaborados, DiasNoLaborados, Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells["remuneracion"].Value), diasSuspendidos, oPlanilla.Tipocalculomensual, 0);
                if (oPlanilla.TipoImpresionTardanzaFalta == CapaDeNegocios.Planillas.enumTipoImpresionTardanzaFalta.AfectaAlSueldo)
                {
                    PagoDespuesFaltas = CalcularRemuneracionMensual(DiasLaborados, DiasNoLaborados, Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells["remuneracion"].Value), diasSuspendidos, oPlanilla.Tipocalculomensual, diasfalta);
                    dgvDetallePlanilla.Rows[fila].Cells["FALTAS"].Value = Math.Round(PagoDia * diasfalta, 2);
                }
                else
                {
                    PagoDespuesFaltas = PagoTotal;
                }
                PagoDia = Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells["remuneracion"].Value) / 30;
            }

            //VEMOS SI SE DESCUENTA LAS TARDANZAS
            int totalMinutos = 0;
            if (Convert.ToBoolean(oDataPlantillaPlanilla.Rows[0][7]) == true)
            {
                miTrabajador.IdTrabajador = Convert.ToInt16(dgvDetallePlanilla.Rows[fila].Cells[4].Value);

                CapaDeNegocios.Asistencia.cAsistenciaTrabajador miAsistenciaTrabajador = new CapaDeNegocios.Asistencia.cAsistenciaTrabajador();
                DateTime mesActual = new DateTime(DateTime.Now.Year, Convert.ToInt32(Mes(smes)), 1);
                if (miAsistenciaTrabajador.ListarAsistenciaTrabajadorMesxTrabajador(miTrabajador.IdTrabajador, mesActual).Rows.Count == 0)
                {
                    totalMinutos = 0;
                    if (oPlanilla.TipoImpresionTardanzaFalta== CapaDeNegocios.Planillas.enumTipoImpresionTardanzaFalta.AfectaAlSueldo)
                    {
                        dgvDetallePlanilla.Rows[fila].Cells["TARDANZAS"].Value = 0;
                    }
                    
                }
                else
                {
                    totalMinutos = Convert.ToInt16(miAsistenciaTrabajador.ListarAsistenciaTrabajadorMesxTrabajador(miTrabajador.IdTrabajador, mesActual).Rows[0][3].ToString());
                    
                    if (oPlanilla.TipoImpresionTardanzaFalta == CapaDeNegocios.Planillas.enumTipoImpresionTardanzaFalta.AfectaAlSueldo)
                    {
                        dgvDetallePlanilla.Rows[fila].Cells["TARDANZAS"].Value = Math.Round(PagoDia / 60 / 8 * totalMinutos,2);
                        PagoDespuesFaltas = PagoDespuesFaltas - PagoDia / 60 / 8 * totalMinutos;
                    }
                    else
                    {
                        PagoDespuesFaltas = PagoTotal;
                    }
                }
            }
            dgvDetallePlanilla.Rows[fila].Cells["TotalRemuneracio"].Value = String.Format("{0:0.00}", PagoTotal);
            dgvDetallePlanilla.Rows[fila].Cells["SUELDOFALTASTAR"].Value = String.Format("{0:0.00}", PagoDespuesFaltas);
            dgvDetallePlanilla.Rows[fila].Cells["SUELDOPACTADO"].Value = Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells["remuneracion"].Value);
            dgvDetallePlanilla.Rows[fila].Cells["DIASMES"].Value = DiasMes2;
            dgvDetallePlanilla.Rows[fila].Cells["DiasLaborados"].Value = DiasMes2 - diasSuspendidos - diasfalta;
            if (oPlanilla.TipoPlanilla == CapaDeNegocios.Planillas.enumTipoPlanilla.VACACIONES_TRUNCAS)
            {
                dgvDetallePlanilla.Rows[fila].Cells["DiasLaborados"].Value = 0;
            }
        }


        private decimal CalcularRemuneracionMensual(int diasLaborados, int diasNoLaborados, decimal Monto, int diassuspendidos, CapaDeNegocios.Planillas.enumTipoCalculoMensual CalculoMensual, int diasfalta)
        {
            decimal Remuneracion = 0;
            if ((diasNoLaborados+ diasfalta + diassuspendidos) == 0 )
            {
                return Monto;
            }
            else
            {
                //significa que tiene descuentos
                
                switch (CalculoMensual)
                {
                    case CapaDeNegocios.Planillas.enumTipoCalculoMensual.DividirEntre30:
                        if (diasLaborados == 31)
                        {
                            return Monto - Math.Round((Monto / 30) * (diassuspendidos + diasfalta), 2);
                        }
                        else
                        {

                            //Remuneracion = Math.Round(Math.Round(Monto / 30, 2) * diasLaborados, 2);
                            Remuneracion = Math.Round((Monto / 30) * diasLaborados, 2) -Math.Round((Monto / 30) * (diassuspendidos + diasfalta), 2);
                        }

                        break;
                    case CapaDeNegocios.Planillas.enumTipoCalculoMensual.DiasLaborados:
                        if (diasLaborados >= diasNoLaborados)
                        {
                            Remuneracion = Math.Round(Monto - ((Monto/30) * diasNoLaborados), 2) - Math.Round((Monto / 30) * (diassuspendidos + diasfalta), 2);
                        }
                        else
                        {
                            Remuneracion = Math.Round((Monto / 30) * diasLaborados, 2) - Math.Round((Monto / 30) * (diassuspendidos + diasfalta), 2);
                        }
                        break;
                    default:
                        break;
                }
                

                
                
                //Parallel el futuro
                //if (diasLaborados > diasNoLaborados)
                //{
                //    Remuneracion = Math.Round(Monto - (Math.Round(Monto / 30, 2) * diasNoLaborados),2); 
                //}
                //else
                //{
                //    Remuneracion = Math.Round(Math.Round(Monto / 30, 2) * diasLaborados,2);
                //}

                return Remuneracion;
            }
            
        }
        private void Ingresos_5ta(int fila)
        {
            int celda_inicio_ingresos = 24;
            int nrocolumnas_ingresos = 0;
            int nrocolumnas_asignadas = 0;
            for (int i = 0; i < con_ingresos; i++)
            {
                if (smingresos[i, 17].ToString() == "0")
                {
                    if (smingresos[i, 1].ToString() != "0121" && smingresos[i, 1].ToString() != "0122" && smingresos[i, 1].ToString() != "2039")
                    {
                        nrocolumnas_ingresos += 1;
                    }
                }
            }

            sIngresosDesc_5ta = new string[nrocolumnas_ingresos];
            sIngresos_5ta = new double[nrocolumnas_ingresos, 2];

            for (int i = 0; i < con_ingresos; i++)
            {
                if (smingresos[i, 17].ToString() == "0")
                {
                    if (smingresos[i, 1].ToString() == "0121" || smingresos[i, 1].ToString() == "0122" || smingresos[i, 1].ToString() == "2039")
                    {
                        sRemuneracion_5ta = Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio_ingresos + i].Value);
                    }
                    else
                    {
                        sIngresosDesc_5ta[nrocolumnas_asignadas] = smingresos[i, 2].ToString();
                        sIngresos_5ta[nrocolumnas_asignadas, 0] = Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio_ingresos + i].Value);
                        sIngresos_5ta[nrocolumnas_asignadas, 1] = 0;
                        nrocolumnas_asignadas += 1;
                    }
                }
            }
        }

        private void CalcularIngresos(int fila)
        {
            int inicio_ingresos = inicioIngresos;
            decimal total_ingresos = 0;

            for (int i = 0; i < con_ingresos; i++)
            {
                if (smingresos[i, 3].ToString() != "" && !chkAguinaldo.Checked && !chkAFP.Checked)//Verficamos que no tenga Formula
                {
                    dgvDetallePlanilla.Rows[fila].Cells[inicio_ingresos + i].ReadOnly = true;
                    decimal number2 = 0;
                    if (decimal.TryParse(smingresos[i, 3].ToString(), out number2) == true)//Verificamos si la formula es un Numero
                    {
                        //verificamos que tiene algun dato fijo
                        int codigoTrabajador = Convert.ToInt32(dgvDetallePlanilla.Rows[fila].Cells[4].Value.ToString());
                        if (oDatoFijo.TieneDatoFijo( codigoTrabajador, Convert.ToInt16(smingresos[i,0].ToString()), "INGRESOS"))
                        {
                            dgvDetallePlanilla.Rows[fila].Cells[inicio_ingresos + i].Value = String.Format("{0:0.00}", oDatoFijo.TraerDatoFijo(Convert.ToInt16(dgvDetallePlanilla.Rows[fila].Cells[4].Value.ToString()), Convert.ToInt16( smingresos[i, 0].ToString()), "INGRESOS"));
                        }
                        else
                        {
                            dgvDetallePlanilla.Rows[fila].Cells[inicio_ingresos + i].Value = String.Format("{0:0.00}", number2);
                        }

                       
                        if (smingresos[i, 17].ToString() == "0") //Verificamos que la columna no sea Informativa.
                        {
                            total_ingresos += decimal.Round(Convert.ToDecimal(smingresos[i, 3].ToString()), 2);
                        }
                    }
                    else // tiene formula
                    {
                        double result = CalcularFormula(fila, Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["SUELDOFALTASTAR"].Value), smingresos[i, 3].ToString(), dgvDetallePlanilla.Rows[fila].Cells["FechaInicio"].Value.ToString(), Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["TotalRemuneracio"].Value), Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["SUELDOAFECTO"].Value)); 

                        // correccion error escolaridad
                        if (smingresos[i, 1].ToString() == "2009")
                        {
                            if (result == 399.99)
                            {
                                result = 400;
                            }
                        }

                        //verificamos que tiene algun dato fijo
                        if (oDatoFijo.TieneDatoFijo(Convert.ToInt16(dgvDetallePlanilla.Rows[fila].Cells[4].Value.ToString()), Convert.ToInt16(smingresos[i, 0].ToString()), "INGRESOS"))
                        {
                            dgvDetallePlanilla.Rows[fila].Cells[inicio_ingresos + i].Value = String.Format("{0:0.00}", oDatoFijo.TraerDatoFijo(Convert.ToInt16(dgvDetallePlanilla.Rows[fila].Cells[4].Value.ToString()), Convert.ToInt16(smingresos[i, 0].ToString()), "INGRESOS"));
                        }
                        else
                        {
                            
                            dgvDetallePlanilla.Rows[fila].Cells[inicio_ingresos + i].Value = String.Format("{0:0.00}", result);
                        }
                           

                        if (smingresos[i, 17].ToString() == "0")//Verificamos que la columna no sea Informativa.
                        {
                            total_ingresos += Math.Round(Convert.ToDecimal(result), 2, MidpointRounding.AwayFromZero);
                            //total_ingresos += decimal.Round(Convert.ToDecimal(result), 2);
                        }
                    }
                }
                else
                {
                    if (dgvDetallePlanilla.Rows[fila].Cells[inicio_ingresos + i].Value == null)//Verificamos si hay datos en Datagridview
                    {
                        dgvDetallePlanilla.Rows[fila].Cells[inicio_ingresos + i].Value = String.Format("{0:0.00}", 0);
                    }
                    else
                    {
                        if (smingresos[i, 17].ToString() == "0")//Verificamos que la columna no sea Informativa.
                        {
                            total_ingresos += decimal.Round(Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells[inicio_ingresos + i].Value), 2);
                        }
                    }
                }
            }
            dgvDetallePlanilla.Rows[fila].Cells[inicio_ingresos + con_ingresos].Value = String.Format("{0:0.00}", total_ingresos);
        }

        private void CalcularA_Trabajador(int fila)
        {
            int celda_inicio = inicioAportacionesTra;
            decimal total_atrabajador = 0;

            for (int i = 0; i < con_trabajador; i++)
            {
                if (sma_trabajador[i, 3].ToString() != "" || sma_trabajador[i, 1].ToString() == "0605" || sma_trabajador[i, 1].ToString() == "0804")
                {
                    if (!(sma_trabajador[i, 1].ToString() == "0605") && !(chkAFP.Checked && (sma_trabajador[i, 1].ToString() == "0601" || sma_trabajador[i, 1].ToString() == "0606" || sma_trabajador[i, 1].ToString() == "0608")))
                    {
                        dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + i].ReadOnly = true;
                    }
                    
                    decimal number2 = 0;
                    if (decimal.TryParse(sma_trabajador[i, 3].ToString(), out number2) == true)
                    {
                        dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + i].Value = String.Format("{0:0.00}", number2);
                        total_atrabajador += decimal.Round(Convert.ToDecimal(sma_trabajador[i, 3].ToString()), 2);
                    }
                    else
                    {
                        
                        decimal result = IngresosAfectos(fila, sma_trabajador[i, 1].ToString(), sma_trabajador[i, 3].ToString());
                        if (result == 0 && (sma_trabajador[i, 1].ToString() =="0605" || (chkAFP.Checked && (sma_trabajador[i, 1].ToString() == "0601" || sma_trabajador[i, 1].ToString() == "0606" || sma_trabajador[i, 1].ToString() == "0608"))))
                        {
                            dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + i].Value = dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + i].Value;

                            if (!(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + i].Value == null))
                            {
                                if (decimal.TryParse(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + i].Value.ToString(), out result))
                                {
                                    total_atrabajador += decimal.Round(Convert.ToDecimal(result), 2);
                                }

                            }

                        }
                        else
                        {
                            dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + i].Value = String.Format("{0:0.00}", result);
                            total_atrabajador += decimal.Round(Convert.ToDecimal(result), 2);
                        }
                        
                       //ojo con esto no se para que sirve
                        if (dgvDetallePlanilla.Columns[celda_inicio + con_ingresos + i].HeaderText !="ESSALUDV" && dgvDetallePlanilla.Columns[celda_inicio + con_ingresos + i].HeaderText != "RENTA 4TA CAT" && dgvDetallePlanilla.Columns[celda_inicio + con_ingresos + i].HeaderText != "RENTA 5TA CAT")
                        {
                            if (AFP == "SNP" && dgvDetallePlanilla.Columns[celda_inicio + con_ingresos + i].Name != "T9" && dgvDetallePlanilla.Columns[celda_inicio + con_ingresos + i].Name != "T12")
                            {
                                dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + i].Value = String.Format("{0:0.00}", 0);
                            }
                            else if (AFP != "SNP" && dgvDetallePlanilla.Columns[celda_inicio + con_ingresos + i].Name == "T9")
                            {
                                dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + i].Value = String.Format("{0:0.00}", 0);
                            }
                        }
                        
                    }
                }
                else
                {
                    if (dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + i].Value == null)//Verificamos si hay datos en Datagridview
                    {
                        dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + i].Value = String.Format("{0:0.00}", 0);
                    }
                    else
                    {
                        total_atrabajador += decimal.Round(Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + i].Value), 2);
                    }
                }
            }
            dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador].Value = String.Format("{0:0.00}", total_atrabajador);
        }

        private void CalcularDescuentos(int fila)
        {
            int celda_inicio = inicioDescuentos;
            decimal total_descuentos = 0;

            for (int i = 0; i < con_descuento; i++)
            {
                if (smdescuentos[i, 3].ToString() != "" || smdescuentos[i, 1].ToString() == "0605" || smdescuentos[i, 1].ToString() == "0804")
                {
                    if (smdescuentos[i, 1].ToString() != "0605")
                    {
                        dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + i].ReadOnly = true;
                    }
                   
                    decimal number2 = 0;
                    if (decimal.TryParse(smdescuentos[i, 3].ToString(), out number2) == true)
                    {
                        dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + i].Value = String.Format("{0:0.00}", number2);
                        total_descuentos += decimal.Round(Convert.ToDecimal(smdescuentos[i, 3].ToString()), 2);
                    }
                    else
                    {
                        decimal result = IngresosAfectos(fila, smdescuentos[i, 1].ToString(), smdescuentos[i, 3].ToString());
                        dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + i].Value = String.Format("{0:0.00}", result);
                        total_descuentos += decimal.Round(Convert.ToDecimal(result), 2);
                    }
                }
                else
                {
                    //INASISTENCIAS
                    if (smdescuentos[i, 1].ToString() == "0705")
                    {
                        if (oPlanilla.TipoImpresionTardanzaFalta == CapaDeNegocios.Planillas.enumTipoImpresionTardanzaFalta.AfectaAlSueldo)
                        {
                            dgvDetallePlanilla.Columns[celda_inicio + con_ingresos + con_trabajador + i].Visible = false;
                        }

                        cMetaJornal miMetaJornal = new cMetaJornal();

                        miMetaJornal = MetaJornal(dgvDetallePlanilla.Rows[fila].Cells[7].Value.ToString(), sidtmeta);
                        decimal PagoDia;
                        PagoDia = Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells["remuneracion"].Value) / 30;

                        if (esTareo && esMetaJornal)
                        {
                            //opcion false es diario
                            if (miMetaJornal.Opcion == false)
                            {
                                PagoDia = Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells["remuneracion"].Value);
                            }
                            else
                            {
                                PagoDia = Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells["remuneracion"].Value) / 30;
                            }
                        }

                            
                         
                        int diasfalta = oAsistenciaTrabajador.ListarAsistenciaTrabajadorxMesxFalta(Convert.ToInt16(dgvDetallePlanilla.Rows[fila].Cells[4].Value), new DateTime(Convert.ToInt32(saño), Convert.ToInt32(Mes(smes)), 1)).Rows.Count;

                        if (splantilla == "PERSONAL OBRERO" || splantilla == "RACIONAMIENTO")
                        {

                        }
                        else
                        {
                            miTrabajador.IdTrabajador = Convert.ToInt16(dgvDetallePlanilla.Rows[fila].Cells[4].Value);
                            oHorario = miCatalogoAsistencia.TraerHorarioTrabajador(miTrabajador);
                            if (oHorario != null)
                            {
                                AsistenciaMes = miCatalogoAsistencia.LLenarAsistencia(miTrabajador, Convert.ToInt32(Mes(smes)), Convert.ToInt32(saño), oHorario);
                                DataTable NUEVA = new DataTable();
                                NUEVA = oAsistenciaTrabajador.ListarAsistenciaTrabajorEntreFechasXFalta(miTrabajador.IdTrabajador, AsistenciaMes.InicioMes, AsistenciaMes.FinMes);
                                diasfalta = NUEVA.Rows.Count;
                            }
                            else
                            {
                                MessageBox.Show("El trabajador no tiene horario, las faltas se tomaran desde el inicio del mes: " + dgvDetallePlanilla.Rows[fila].Cells[5].Value + " " + miTrabajador.Nombres + " " + miTrabajador.ApellidoPaterno + " " + miTrabajador.ApellidoMaterno);
                            }
                            
                        }

                        
                        if (diasfalta > 0)
                        {
                            dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + i].Value = String.Format("{0:0.00}", PagoDia * diasfalta);
                            if (oPlanilla.TipoImpresionTardanzaFalta == CapaDeNegocios.Planillas.enumTipoImpresionTardanzaFalta.AfectaAlSueldo)
                            {
                                dgvDetallePlanilla.Rows[fila].Cells["FALTAS"].Value = String.Format("{0:0.00}", PagoDia * diasfalta);
                                dgvDetallePlanilla.Columns[celda_inicio + con_ingresos + con_trabajador + i].Visible = false;
                            }
                        }
                        else
                        {
                            dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + i].Value = String.Format("{0:0.00}", 0);
                        }
                    }

                    //TARDANZAS
                    if (smdescuentos[i, 1].ToString() == "0704")
                    {
                        if (oPlanilla.TipoImpresionTardanzaFalta == CapaDeNegocios.Planillas.enumTipoImpresionTardanzaFalta.AfectaAlSueldo)
                        {
                            dgvDetallePlanilla.Columns[celda_inicio + con_ingresos + con_trabajador + i].Visible = false;
                        }

                        cMetaJornal miMetaJornal = new cMetaJornal();

                        miMetaJornal = MetaJornal(dgvDetallePlanilla.Rows[fila].Cells["colCargo"].Value.ToString(), sidtmeta);
                        decimal PagoDia;
                        PagoDia = Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells["remuneracion"].Value) / 30;

                        if (esTareo && esMetaJornal)
                        {
                            if (miMetaJornal.Opcion == false)
                            {
                                PagoDia = Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells["remuneracion"].Value);
                            }
                            else
                            {
                                PagoDia = Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells["remuneracion"].Value) / 30;
                            }
                        }

                      
                        decimal totalMinutos = 0;

                        if (splantilla == "PERSONAL OBRERO" || splantilla == "RACIONAMIENTO")
                        {

                        }
                        else
                        {
                            miTrabajador.IdTrabajador = Convert.ToInt16(dgvDetallePlanilla.Rows[fila].Cells[4].Value);

                            CapaDeNegocios.Asistencia.cAsistenciaTrabajador miAsistenciaTrabajador = new CapaDeNegocios.Asistencia.cAsistenciaTrabajador();
                            DateTime mesActual = new DateTime(DateTime.Now.Year, Convert.ToInt32(Mes(smes)), 1);
                            if (miAsistenciaTrabajador.ListarAsistenciaTrabajadorMesxTrabajador(miTrabajador.IdTrabajador, mesActual).Rows.Count == 0)
                            {
                                totalMinutos = 0;
                            }
                            else
                            {
                                totalMinutos = Convert.ToInt16(miAsistenciaTrabajador.ListarAsistenciaTrabajadorMesxTrabajador(miTrabajador.IdTrabajador, mesActual).Rows[0][3].ToString());
                            }

                            //oHorario = miCatalogoAsistencia.TraerHorarioTrabajador(miTrabajador);
                            //if (oHorario != null)
                            //{
                            //    AsistenciaMes = miCatalogoAsistencia.LLenarAsistencia(miTrabajador, Convert.ToInt32(Mes(smes)), Convert.ToInt32(saño), oHorario);
                            //    DataTable NUEVA = new DataTable();
                            //    NUEVA = oAsistenciaTrabajador.ListarAsistenciaTrabajorEntreFechasXTardanza(miTrabajador.IdTrabajador, AsistenciaMes.InicioMes, AsistenciaMes.FinMes);
                            //    diasfalta = NUEVA.Rows.Count;
                            //    diasfalta = Math.Truncate(diasfalta / 3);
                            //}
                            //else
                            //{
                            //    MessageBox.Show("El trabajador no tiene horario, las faltas se tomaran desde el inicio del mes: " + dgvDetallePlanilla.Rows[fila].Cells[5].Value + " " + miTrabajador.Nombres + " " + miTrabajador.ApellidoPaterno + " " + miTrabajador.ApellidoMaterno);
                            //}

                        }


                        //if (diasfalta > 0)
                        //{
                        //    dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + i].Value = String.Format("{0:0.00}", PagoDia * diasfalta);
                        //}
                        //else
                        //{
                        //    dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + i].Value = String.Format("{0:0.00}", 0);
                        //}

                        if (totalMinutos > 0)
                        {
                            dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + i].Value = String.Format("{0:0.00}", PagoDia/8/60 * totalMinutos);
                            if (oPlanilla.TipoImpresionTardanzaFalta == CapaDeNegocios.Planillas.enumTipoImpresionTardanzaFalta.AfectaAlSueldo)
                            {
                                dgvDetallePlanilla.Rows[fila].Cells["TARDANZAS"].Value = String.Format("{0:0.00}", PagoDia / 8 / 60 * totalMinutos);
                                dgvDetallePlanilla.Columns[celda_inicio + con_ingresos + con_trabajador + i].Visible = false;
                            }
                            
                        }
                        else
                        {
                            dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + i].Value = String.Format("{0:0.00}", 0);
                        }
                    }

                    if (dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + i].Value == null)//Verificamos si hay datos en Datagridview
                    {
                        dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + i].Value = String.Format("{0:0.00}", 0);
                    }
                    else
                    {
                        //if (smdescuentos[i, 1].ToString() == "0705")
                        //{
                        //    decimal PagoDia = Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells[11].Value) / 30;
                        //    int diasfalta = oAsistenciaTrabajador.ListarAsistenciaTrabajadorxMesxFalta(Convert.ToInt16(dgvDetallePlanilla.Rows[fila].Cells[4].Value), new DateTime(Convert.ToInt32(saño), Convert.ToInt32(Mes(smes)), 1)).Rows.Count;
                        //    if (diasfalta > 0)
                        //    {
                        //        dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + i].Value = String.Format("{0:0.00}", PagoDia);
                        //    }
                        //}

                        //VERIFICAMOS si esta afecto al neto
                        if (Convert.ToBoolean(Convert.ToInt16(smdescuentos[i, 6].ToString())) == true)
                        {
                            total_descuentos += decimal.Round(Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + i].Value), 2);
                            
                        }

                        
                    }
                }

              
            }
            dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + con_descuento].Value = String.Format("{0:0.00}", total_descuentos);
        }

        private void CalcularA_Empleador(int fila)
        {
            int celda_inicio = inicioAportacionesEmple;
            decimal total_aempleador = 0;

            for (int i = 0; i < con_empleador; i++)
            {
                if (sma_empleador[i, 3].ToString() != "" || sma_empleador[i, 1].ToString() == "0605" || sma_empleador[i, 1].ToString() == "0804")
                {
                    CapaDeNegocios.Planillas.cPlanilla PlanillaEncontrada = new CapaDeNegocios.Planillas.cPlanilla();

                    PlanillaEncontrada = PlanillaEncontrada.TraerPlanilla(sidtplanilla);

                    miTrabajador.IdTrabajador = Convert.ToInt16(dgvDetallePlanilla.Rows[fila].Cells[4].Value);
                    miTrabajador =  miTrabajador.traerTrabajador(miTrabajador.IdTrabajador);

                    PlanillaEncontrada = PlanillaEncontrada.TraerPLanillaConTrabajadorDuplicadoConCargasSociales(miTrabajador, PlanillaEncontrada.Mes, Convert.ToInt16(PlanillaEncontrada.Año), PlanillaEncontrada.IdtPlanilla);

                    if (PlanillaEncontrada != null || oPlanilla.TipoPlanilla == CapaDeNegocios.Planillas.enumTipoPlanilla.VACACIONES_TRUNCAS)
                    {
                        dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + con_descuento + i].ReadOnly = false;
                    } 

                    else
                    {
                        dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + con_descuento + i].ReadOnly = true;
                    }

                    if (PlanillaEncontrada != null)
                    {
                        MessageBox.Show("Se encontro al trabajador: " + miTrabajador.Dni + ": " + miTrabajador.Nombres + " " + miTrabajador.ApellidoPaterno + " " + miTrabajador.ApellidoMaterno + " Cargo: " + PlanillaEncontrada.ListaDetallePlanilla[0].Cargo +
                            " en la planilla Nro: " + PlanillaEncontrada.Numero + " " + PlanillaEncontrada.Descripcion + ": Tendra que calcular su essalud manualmente ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        
                    }
                    decimal number2 = 0;
                    if (decimal.TryParse(sma_empleador[i, 3].ToString(), out number2) == true)
                    {
                        dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + con_descuento + i].Value = String.Format("{0:0.00}", number2);
                        total_aempleador += decimal.Round(Convert.ToDecimal(sma_empleador[i, 3].ToString()), 2);
                    }
                    else
                    {
                        if ((PlanillaEncontrada == null && oPlanilla.TipoPlanilla != CapaDeNegocios.Planillas.enumTipoPlanilla.VACACIONES_TRUNCAS) || sma_empleador[i, 1].ToString() != "0804")
                        {
                            decimal result = IngresosAfectos(fila, sma_empleador[i, 1].ToString(), sma_empleador[i, 3].ToString());
                            dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + con_descuento + i].Value = String.Format("{0:0.00}", result);
                            total_aempleador += decimal.Round(Convert.ToDecimal(result), 2);
                        }
                        else
                        {
                            //Si es la primera vez que entra calculara el aporte normal
                            if (dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + con_descuento + i].Value == null)
                            {
                                decimal result = IngresosAfectos(fila, sma_empleador[i, 1].ToString(), sma_empleador[i, 3].ToString());
                                dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + con_descuento + i].Value = String.Format("{0:0.00}", result);
                                
                            }
                            dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + con_descuento + i].Style.BackColor = Color.LightGreen;
                            total_aempleador += decimal.Round(Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + con_descuento + i].Value), 2);
                        }

                    }
                }
                else
                {
                    if (dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + con_descuento + i].Value == null)//Verificamos si hay datos en Datagridview
                    {
                        dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + con_descuento + i].Value = String.Format("{0:0.00}", 0);
                    }
                    else
                    {
                        total_aempleador += decimal.Round(Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + con_descuento + i].Value), 2);
                    }
                }
            }
            dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + con_descuento + con_empleador].Value = String.Format("{0:0.00}", total_aempleador);
        }

        decimal IngresosAfectos(int fila, string codigo, string formula)
        {
            int celda_inicio_ingresos = inicioIngresos;
            int celda_inicio_descuentos = inicioDescuentos;
            double remuneracion_afecta = 0;
            double suma_ingresos = 0;
            double result = 0;
            double remuneracion_5ta = 0;
            double remuneracionBasica = 0;
            double otrosingresos_5ta = 0;

            //Calculamos la remuneracion afecta
            if (codigo == "0804" || codigo == "0806" || codigo == "0808" || codigo == "0802" || codigo == "0807" || codigo == "0607" || codigo == "0608" || codigo == "0601" || codigo == "0606" || codigo == "0605" || codigo == "0610" || codigo == "0603" || codigo == "9998" || codigo == "9999" || codigo == "0618")
            {
                for (int i = 0; i < con_ingresos; i++)
                {
                    //int y = dgvDetallePlanilla.Columns[celda_inicio + i].Name.Length - 1;
                    //string x = dgvDetallePlanilla.Columns[celda_inicio + i].Name.Substring(1, y);
                    //string z = rowingresos[2].ToString();
                    //if (x == z)
                    //{
                    //    dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + i].Value = Convert.ToDecimal(rowingresos[1].ToString());
                    //}
                    //columna informativa
                    if (smingresos[i, 17].ToString() == "0")
                    {
                        if (codigo == "0804" && smingresos[i, 4].ToString() == "1")
                        {
                            remuneracion_afecta += Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio_ingresos + i].Value);
                        }
                        if (codigo == "0806" && smingresos[i, 7].ToString() == "1")
                        {
                            remuneracion_afecta += Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio_ingresos + i].Value);
                        }
                        if (codigo == "0808" && smingresos[i, 8].ToString() == "1")
                        {
                            remuneracion_afecta += Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio_ingresos + i].Value);
                        }
                        if (codigo == "0802" && smingresos[i, 9].ToString() == "1")
                        {
                            remuneracion_afecta += Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio_ingresos + i].Value);
                        }
                        if (codigo == "0807" && smingresos[i, 10].ToString() == "1")
                        {
                            remuneracion_afecta += Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio_ingresos + i].Value);
                        }
                        if (codigo == "0607" && smingresos[i, 11].ToString() == "1" && AFP == "SNP")
                        {
                            remuneracion_afecta += Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio_ingresos + i].Value);
                        }
                        if (codigo == "0618" && smingresos[i, 13].ToString() == "1")
                        {
                            remuneracion_afecta += Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio_ingresos + i].Value);
                        }
                        if ((codigo == "0608" || codigo == "0601" || codigo == "0606" || codigo == "9998" || codigo == "9999") && smingresos[i, 12].ToString() == "1" && AFP != "SNP")
                        {
                            remuneracion_afecta += Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio_ingresos + i].Value);
                        }
                        if (codigo == "0605" && smingresos[i, 13].ToString() == "1")
                        {
                            if (smingresos[i, 1].ToString() == "0121" || smingresos[i, 1].ToString() == "0122" || smingresos[i, 1].ToString() == "2039")
                            {
                                if (esMetaJornal)
                                {
                                    cMetaJornal miMetaJornal = new cMetaJornal();
                                    miMetaJornal = MetaJornal(dgvDetallePlanilla.Rows[fila].Cells[7].Value.ToString(), sidtmeta);
                                    if (miMetaJornal.Opcion == false)
                                    {
                                        remuneracion_5ta = miMetaJornal.Jornal * 30;
                                        remuneracionBasica = miMetaJornal.Jornal * 30;
                                    }
                                    else
                                    {
                                        remuneracion_5ta = miMetaJornal.Mensual;
                                        remuneracionBasica = miMetaJornal.Mensual;
                                    }
                                }
                                else
                                {
                                    remuneracion_5ta = Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["remuneracion"].Value);
                                    remuneracionBasica = Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["remuneracion"].Value);

                                    //remuneracion_5ta = Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio_ingresos + i].Value);
                                    //remuneracionBasica = Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio_ingresos + i].Value);
                                }
                                
                            }
                            else
                            {
                                
                                
                                if (smingresos[i, 1].ToString() == "0114")
                                {
                                    if (esMetaJornal)
                                    {
                                        cMetaJornal miMetaJornal = new cMetaJornal();
                                        miMetaJornal = MetaJornal(dgvDetallePlanilla.Rows[fila].Cells[7].Value.ToString(), sidtmeta);
                                        if (miMetaJornal.Opcion == false)
                                        {
                                            remuneracion_5ta += remuneracionBasica / 12;
                                        }
                                        else
                                        {
                                            remuneracion_5ta += remuneracionBasica / 12;
                                        }
                                    }
                                    else
                                    {
                                        remuneracion_5ta +=  remuneracionBasica/12;
                                        //remuneracion_5ta += Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio_ingresos + i].Value);
                                    }

                                }
                                else
                                {
                                    otrosingresos_5ta += Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio_ingresos + i].Value);
                                }
                            }
                            remuneracion_afecta += Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio_ingresos + i].Value);
                        }
                        if (codigo == "0610" && smingresos[i, 14].ToString() == "1")
                        {
                            remuneracion_afecta += Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio_ingresos + i].Value);
                        }
                        if (codigo == "0603" && smingresos[i, 15].ToString() == "1")
                        {
                            remuneracion_afecta += Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio_ingresos + i].Value);
                        }
                        suma_ingresos += Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio_ingresos + i].Value);
                    }
                }
            }
            else
            {
                remuneracion_afecta = Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["TotalRemuneracio"].Value);
            }


            //Restamos las faltas y tardanzas a la remuneracion afecta
            if (remuneracion_afecta != 0)
            {
                for (int i = 0; i < con_descuento; i++)
                {
                    string xxx = smdescuentos[i, 1].ToString();
                    if (smdescuentos[i,5].ToString() == "1")
                    {
                        if (smdescuentos[i, 1].ToString() == "0704" || smdescuentos[i, 1].ToString() == "0705")
                        {
                            remuneracion_afecta -= Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio_descuentos + con_ingresos + con_trabajador + i].Value);
                        }
                    }
                    
                }
            }

           

            //Calculo de la Formula
            if (codigo != "0605" && codigo != "0804")
            {
                if ((codigo == "0606") || (codigo == "0601") || (codigo== "0608"))
                {
                    if (chkAFP.Checked)
                    {
                       
                    }
                    else
                    {
                        result = CalcularFormula(fila, remuneracion_afecta, formula, dgvDetallePlanilla.Rows[fila].Cells[10].Value.ToString(),Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["TotalRemuneracio"].Value), Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["SUELDOAFECTO"].Value));
                    }
                }
                else
                {
                    result = CalcularFormula(fila, remuneracion_afecta, formula, dgvDetallePlanilla.Rows[fila].Cells[10].Value.ToString(), Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["TotalRemuneracio"].Value), Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["SUELDOAFECTO"].Value));
                }
                
            }

            if (codigo =="0606")
            {
                if (verificar65anio (dgvDetallePlanilla.Rows[fila].Cells[8].Value.ToString()))
                {
                    result = 0;
                }
            }
            //essaludvida
            if (codigo == "0604")
            {
                BuscarEssaludVida(Convert.ToInt32(dgvDetallePlanilla.Rows[fila].Cells[4].Value));
                if (sessaludvida == true)
                {
                    result = 5.00;
                }
                else
                {
                    result = 0;
                }
            }


            //renta 4ta Categoria
            if (codigo == "0618")
            {
                SuspencionRenta4ta(Convert.ToInt32(dgvDetallePlanilla.Rows[fila].Cells[4].Value));
                if (ssuspencionrenta4ta == false)
                {
                    result = CalcularFormula(fila, remuneracion_afecta, formula, dgvDetallePlanilla.Rows[fila].Cells["FechaInicio"].Value.ToString(), Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["TotalRemuneracio"].Value), Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["SUELDOAFECTO"].Value));
                }
                else
                {
                    result = 0;
                }
            }
            //renta de 5ta Categoria A_Trabajador
            if (codigo == "0605")
            {
                decimal renta5ta = CalculoRenta5ta(fila, remuneracion_5ta, otrosingresos_5ta, remuneracionBasica);
                //result = decimal.Round(Convert.ToDecimal(renta5ta), 2);
                if (renta5ta < 0)
                {
                    renta5ta = 0;
                }
                if (chkQuinta.Checked)
                {
                    result = 0;
                }
                else
                {
                    result = Convert.ToDouble(renta5ta);
                }
                
            }

            //seguro complementario de riesgo

            if (codigo == "0806" || codigo == "0810")
            {
                BuscarSCRT(Convert.ToInt32(dgvDetallePlanilla.Rows[fila].Cells[4].Value));
                if (sscrt == true)
                {
                    if (cDatosGeneralesEmpresa.RUC == "20200737211")
                    {
                        if (remuneracion_afecta < Convert.ToDouble(sRemuneracionBasica))
                        {

                            result = CalcularFormula(fila, Convert.ToDouble(sRemuneracionBasica), "s*0.0070*1.18", dgvDetallePlanilla.Rows[fila].Cells[10].Value.ToString(), Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["TotalRemuneracio"].Value), Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["SUELDOAFECTO"].Value));
                            


                        }
                        else
                        {
                            result = CalcularFormula(fila, remuneracion_afecta, formula, dgvDetallePlanilla.Rows[fila].Cells[10].Value.ToString(), Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["TotalRemuneracio"].Value), Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["SUELDOAFECTO"].Value));
                        }
                    }
                    else
                    {
                        result = CalcularFormula(fila, remuneracion_afecta, formula, dgvDetallePlanilla.Rows[fila].Cells[10].Value.ToString(), Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["TotalRemuneracio"].Value), Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["SUELDOAFECTO"].Value));
                    }
                    
                }
                else
                {
                    result = 0;
                }
            }

            if (codigo == "0805")
            {
                BuscarSCRTPension(Convert.ToInt32(dgvDetallePlanilla.Rows[fila].Cells[4].Value));
                if(sscrtp == true)
                {
                    if (cDatosGeneralesEmpresa.RUC == "20200737211")
                    {
                        if (remuneracion_afecta < Convert.ToDouble(sRemuneracionBasica))
                        {
                            result = CalcularFormula(fila, Convert.ToDouble(sRemuneracionBasica), "s * 0.0068 * 1.18", dgvDetallePlanilla.Rows[fila].Cells[10].Value.ToString(), Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["TotalRemuneracio"].Value), Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["SUELDOAFECTO"].Value));
                        }
                        else
                        {
                            result = CalcularFormula(fila, remuneracion_afecta, formula, dgvDetallePlanilla.Rows[fila].Cells[10].Value.ToString(), Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["TotalRemuneracio"].Value), Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["SUELDOAFECTO"].Value));
                        }
                    }
                    else
                    {
                        result = CalcularFormula(fila, remuneracion_afecta, formula, dgvDetallePlanilla.Rows[fila].Cells[10].Value.ToString(), Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["TotalRemuneracio"].Value), Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells["TotalRemuneracio"].Value));
                    }
                    
                }
                else
                {
                    result = 0;
                }
            }
            //Essalud
            if (codigo == "0804")
            {
                decimal essalud = CalculoESSALUD(fila, Convert.ToDecimal(remuneracion_afecta));
                //result = decimal.Round(Convert.ToDecimal(essalud), 2);
                result = Convert.ToDouble(essalud);

                //Guardamos la remuneracion afecta en la grilla
                dgvDetallePlanilla.Rows[fila].Cells["SUELDOAFECTO"].Value = remuneracion_afecta;
            }

            //escolaridad
            if (codigo == "2009")
            {
                if (result == 399.99)
                {
                    result = 400;
                }
            }

            
            decimal result99 = Convert.ToDecimal(result);

            //return Math.Round(result, 2, MidpointRounding.AwayFromZero);
            return Math.Round(result99, 2, MidpointRounding.AwayFromZero);

            
        }

        private void CalcularTotalDescuentos(int fila)
        {
            decimal D = 0;
            D = Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells["SUMA_A_TRABAJADOR"].Value) + Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells["SUMA_DESCUENTOS"].Value);
            dgvDetallePlanilla.Rows[fila].Cells["TOTAL_DESCUENTOS"].Value = String.Format("{0:0.00}", D);
        }

        private void CalcularNetoaCobrar(int fila)
        {
            decimal T = 0;
            T = Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells["SUMA_INGRESOS"].Value) - Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells["TOTAL_DESCUENTOS"].Value);
            dgvDetallePlanilla.Rows[fila].Cells["NETOACOBRAR"].Value = String.Format("{0:0.00}", T);
        }

        private decimal CalculoRenta5ta(int fila, double remuneracion_5ta, double otrosingresos_5ta, double remuneracionBasica)
        {
            decimal sRenta5ta = 0;
            int sNroMes = 0;
            decimal sRemuneracion = 0;
            decimal sOtrosIngresos = 0;
            decimal sRemuMesAnt = 0;
            decimal sRetMesAnteriores = 0;
            decimal sRemuneracionBasica = 0;

            int idttrabajador = Convert.ToInt32(dgvDetallePlanilla.Rows[fila].Cells[4].Value);
            cTrabajador miTrabajadorRentaQuinta = new cTrabajador();
            miTrabajadorRentaQuinta =  miTrabajadorRentaQuinta.traerTrabajador(idttrabajador);

            CapaDeNegocios.DatosLaborales.cPeriodoTrabajador oPeriodoTrabajadorRentaQuinta = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
            oPeriodoTrabajadorRentaQuinta = oPeriodoTrabajadorRentaQuinta.traerUltimoPeriodoTrabajador(miTrabajadorRentaQuinta.IdTrabajador);

            List<CapaDeNegocios.DatosLaborales.cRegimenTrabajador> ListaRegimenTrabajador = new List<CapaDeNegocios.DatosLaborales.cRegimenTrabajador>();

            CapaDeNegocios.DatosLaborales.cRegimenTrabajador oRegimenTrabajadorRentaQuinta = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
            ListaRegimenTrabajador = oRegimenTrabajadorRentaQuinta.TraerRegimenTrabajadorMes(oPeriodoTrabajadorRentaQuinta.IdtPeriodoTrabajador, new DateTime(Convert.ToInt16(saño), Convert.ToInt16(Mes(smes)), 1));

            foreach(CapaDeNegocios.DatosLaborales.cRegimenTrabajador item in ListaRegimenTrabajador)
            {
                if (item.IdtMeta == sidtmeta)
                {
                    oRegimenTrabajadorRentaQuinta = item;
                }
            }
            


            CapaDeNegocios.Planillas.cIngresos5taCategoria miIngresos5taCategoria = new CapaDeNegocios.Planillas.cIngresos5taCategoria();
            DataTable oDataIngresos5taCategoria = new DataTable();
            oDataIngresos5taCategoria = miIngresos5taCategoria.Ingresos5taCategoria(sidtplanilla, smes, saño, Convert.ToInt32(dgvDetallePlanilla.Rows[fila].Cells[4].Value));
            foreach (DataRow rowingresos in oDataIngresos5taCategoria.Rows)
            {
                if (rowingresos[0].ToString() == "Ingresos")
                {
                    if (rowingresos[3].ToString() == "0121" || rowingresos[3].ToString() == "0122" || rowingresos[3].ToString() == "2039" || rowingresos[3].ToString() == "0114"  || rowingresos[3].ToString() == "0406" || rowingresos[3].ToString() == "0312" || rowingresos[3].ToString() == "2041")
                    {
                        sRemuMesAnt += Convert.ToDecimal(rowingresos[2]);//suma de las remuneraciones totales
                    }
                    else
                    {
                        if (rowingresos[4].ToString()== "1")
                        {
                            sOtrosIngresos += Convert.ToDecimal(rowingresos[2]);
                        }
                        
                    }
                }
                else
                {
                    sRetMesAnteriores += Convert.ToDecimal(rowingresos[2]);//suma de las retenciones de 5tacategoria totales

                    //Codigo para probar
                    if (smes == "ENERO" || smes == "FEBRERO" || smes == "MARZO")
                    {
                        
                    }
                }
            }
            sNroMes = Convert.ToInt32(Mes(smes));
            sRemuneracion = Convert.ToDecimal(remuneracion_5ta);
            sRemuneracionBasica = Convert.ToDecimal(remuneracionBasica);

            if (oRegimenTrabajadorRentaQuinta.IdtRegimenLaboral == 3 || oRegimenTrabajadorRentaQuinta.IdtRegimenLaboral == 4) // codigo 3 y 4 corresponde a regimen laboral 728 y 4 30057 servir
            {
                //sOtrosIngresos += Convert.ToDecimal(otrosingresos_5ta) + Convert.ToDecimal(10600);//suma de todos los ingresos incuido las gratificaciones
                sOtrosIngresos += Convert.ToDecimal(otrosingresos_5ta) + Convert.ToDecimal(sRemuneracionBasica * 2);//suma de todos los ingresos incuido las gratificaciones
            }
            else
            {
                sOtrosIngresos += Convert.ToDecimal(otrosingresos_5ta) + Convert.ToDecimal(600);//suma de todos los ingresos incuido los aguinaldos
            }

            decimal sRetencionesOtroLugar = 0;
            decimal sIngresosOtroLugar = 0;

            CapaDeNegocios.RentaQuinta.cRenta5taAnteriores oRentaOtroLugar = new CapaDeNegocios.RentaQuinta.cRenta5taAnteriores();
            DataTable auxiliarRentasOtrosLugares = oRentaOtroLugar.ListarRenta5taAnteriores( miTrabajador.traerTrabajador(idttrabajador), Convert.ToInt16(saño));

            for (int i = 0; i < auxiliarRentasOtrosLugares.Rows.Count; i++)
            {
                sRetencionesOtroLugar += Convert.ToDecimal(auxiliarRentasOtrosLugares.Rows[i][3].ToString());
                sIngresosOtroLugar += Convert.ToDecimal(auxiliarRentasOtrosLugares.Rows[i][2].ToString());
            }

            CapaDeNegocios.Planillas.cCalculo5taCategoria miCalculo5ta = new CapaDeNegocios.Planillas.cCalculo5taCategoria();
            sRenta5ta = miCalculo5ta.CalculoRentaMensual(sNroMes, sRemuneracion, sOtrosIngresos, sRemuMesAnt, sRetMesAnteriores, sUIT, sRetencionesOtroLugar, sIngresosOtroLugar);
            return sRenta5ta;
        }

        private decimal CalculoESSALUD(int fila, decimal remuneracion_afecta)
        {
            decimal sEssalud = 0;
            decimal sRemuneracion = 0;
            sRemuneracion = remuneracion_afecta;
            if (txtRegimenLaboral.Text == "REGIMEN CAS 1057")
            {
                if (sRemuneracion <= sRemuneracionBasica)
                {
                    sEssalud = sRemuneracionBasica * 9 / 100;
                }
                else if (sRemuneracion >= sRemuneracionBasica && sRemuneracion <= sUIT * 45 / 100)
                {
                    sEssalud = sRemuneracion * 9 / 100;
                }
                else
                {
                    sEssalud = (sUIT * 45 / 100) * 9 / 100;
                }
            }
            else
            {
                if (sRemuneracion <= sRemuneracionBasica)
                {
                    sEssalud = sRemuneracionBasica * 9 / 100;
                }
                else
                {
                    sEssalud = sRemuneracion * 9 / 100;
                }
            }
            return sEssalud;
        }

        double CalcularFormula(int fila, double remuneracion, string formula, string FechaInicio, double remuneracionAntesFaltas, double remuneracionafectaessalud)
        {
        
            int index = formula.IndexOf("&&p");


            if (index != -1)
            {
                string formula2 = formula.Substring(0, index);
                formula = formula2;
            }

            ExpressionParser parser = new ExpressionParser();
            DoubleValue sval = new DoubleValue();
            DoubleValue aoval = new DoubleValue();
            DoubleValue cval = new DoubleValue();
            DoubleValue psval = new DoubleValue();
            DoubleValue ddval = new DoubleValue();
            DoubleValue mmval = new DoubleValue();
            DoubleValue ddval2 = new DoubleValue();
            DoubleValue mmval2 = new DoubleValue();
            DoubleValue rtval = new DoubleValue();
            DoubleValue raval = new DoubleValue();

            parser.Values.Add("s", sval);
            parser.Values.Add("ao", aoval);
            parser.Values.Add("c", cval);
            parser.Values.Add("ps", psval);
            parser.Values.Add("dd", ddval);
            parser.Values.Add("mm", mmval);
            parser.Values.Add("zz", ddval2);
            parser.Values.Add("yy", mmval2);
            parser.Values.Add("rt", rtval);
            parser.Values.Add("ra", raval);

            DateTime DateFechaInicio = Convert.ToDateTime(FechaInicio);

            //if (Settings.Default.RUC == "20159377696")
            //{
            //    if (DateFechaInicio <= (new DateTime(2023, 6, 1)))
            //    {
            //        DateFechaInicio =  new DateTime(2023, 6, 1);
            //    }
                
            //}


            DateTime DateFechaInicioTemporal = DateFechaInicio;
            DateTime DateFechaInicioTemporal2 = DateFechaInicio;

            if (DateFechaInicioTemporal.Day == 1)
            {
                DateFechaInicioTemporal = DateFechaInicioTemporal.AddDays(-1);
            }
            DateTime DateFechacalculo = new DateTime(2024, 11, 30);
            DateTime DateFechacalculo2 = new DateTime(2024, 11, 30);

            int numeroMeses = ((DateFechacalculo.Month - DateFechaInicioTemporal.Month) + 12 * (DateFechacalculo.Year - DateFechaInicioTemporal.Year));
            
            TimeSpan Restafechas = DateFechacalculo - DateFechaInicio;

            if (numeroMeses > 3)
            {
                numeroMeses = 3;
            }
            int Años=0;
            int Meses = 0;
            int Dias = 0;

            // si es 1 se considera todo un mes
            if (DateFechaInicioTemporal2.Day == 1)
            {
                Meses++;
                DateFechaInicioTemporal2 = DateFechaInicioTemporal2.AddMonths(1);
                Dias = 0;
            }
            else
            //calculamos los dias
            {
                int mestemporal = DateFechaInicioTemporal2.Month;

                while (DateFechaInicioTemporal2.Month == mestemporal) // finalmente comprobamos los dias que ha cumplido
                {
                    Dias = Dias + 1;
                    DateFechaInicioTemporal2 = DateFechaInicioTemporal2.AddDays(1);
                }
            }

            while (DateFechaInicioTemporal2.AddYears(1) <= DateFechacalculo2) // comprobamos los años que ha cumplido
            {
                Años = Años + 1;
                DateFechaInicioTemporal2 = DateFechaInicioTemporal2.AddYears(1); // añadiendo años a la fecha de nacimiento
            }


            while (DateFechaInicioTemporal2 <= DateFechacalculo2) // comprobamos los meses que ha cumplido
            {
                Meses = Meses + 1;
                DateFechaInicioTemporal2 = DateFechaInicioTemporal2.AddMonths(1); // añadiendo meses
            }


            

            

            

            ddval2.Value = Dias;
            mmval2.Value = Meses;

            

            mmval.Value = numeroMeses;
            

            

            switch (numeroMeses)
            {
                case 3:
                    ddval.Value = 0;
                    break;
                case 2:
                    ddval.Value = Convert.ToDouble(((new DateTime(2024, 09, 30)) - DateFechaInicio).Days + 1);
                    break;
                case 1:
                    ddval.Value = Convert.ToDouble(((new DateTime(2024, 10, 31)) - DateFechaInicio).Days + 1);
                    break;
                case 0:
                    ddval.Value = Convert.ToDouble(((new DateTime(2024, 11, 30)) - DateFechaInicio).Days +1);
                    break;
                
                default:
                    ddval.Value = 0;
                    mmval.Value = 0;
                    break;
            }

            if (index != -1)
            {
                numeroMeses = ((DateFechacalculo.Month - DateFechaInicioTemporal.Month) + 12 * (DateFechacalculo.Year - DateFechaInicioTemporal.Year));
                if (numeroMeses > 6)
                {
                    numeroMeses = 6;
                }

                

             

                mmval.Value = numeroMeses;

                switch (numeroMeses)
                {
                    case 6:
                        ddval.Value = 0;
                        break;
                    case 5:
                        ddval.Value = Convert.ToDouble(((new DateTime(2024, 06, 30)) - DateFechaInicio).Days);
                        break;

                    case 4:
                        ddval.Value = Convert.ToDouble(((new DateTime(2024, 07,31 )) - DateFechaInicio).Days);
                        break;
                    case 3:
                        ddval.Value = Convert.ToDouble(((new DateTime(2024, 08, 31)) - DateFechaInicio).Days);
                        break;
                    case 2:
                        ddval.Value = Convert.ToDouble(((new DateTime(2024, 09, 30)) - DateFechaInicio).Days);
                        break;
                    case 1:
                        ddval.Value = Convert.ToDouble(((new DateTime(2024, 10, 31)) - DateFechaInicio).Days);
                        break;
                    case 0:
                        ddval.Value = Convert.ToDouble(((new DateTime(2024, 11, 30)) - DateFechaInicio).Days);
                        break;

                    default:
                        ddval.Value = 0;
                        mmval.Value = 0;
                        break;
                }
            }

            if (ddval.Value < 0)
            {
                ddval.Value = 0;
            }
            sval.Value = remuneracion;
            rtval.Value = remuneracionAntesFaltas;
            raval.Value = remuneracionafectaessalud;
            aoval.Value = Convert.ToDouble(AporteObligatorio / 100);
            psval.Value = Convert.ToDouble(PrimaSeguros / 100);
            if (TipoComision == "FLUJO")
            { cval.Value = Convert.ToDouble(ComisionFlujo / 100); }
            else if ((TipoComision == "MIXTA"))
            { cval.Value = Convert.ToDouble(ComisionMixta / 100); }
            double result = parser.Parse(formula);
            return result;
        }

        private void Variables()
        {
            DataTable oDataVariables = new DataTable();
            CapaDeNegocios.cVariables miVariables = new CapaDeNegocios.cVariables();
            oDataVariables = miVariables.ListarVariables();
            foreach (DataRow rowvariables in oDataVariables.Select("año = '" + saño + "'"))
            {
                sRemuneracionBasica = Convert.ToDecimal(rowvariables[2].ToString());
                sUIT = Convert.ToDecimal(rowvariables[3].ToString());
            }
        }

        private void btnCambiarFechaInicio_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetallePlanilla.SelectedCells.Count > 0)
                {
                    frmCambiarFecha fCambiarFecha = new frmCambiarFecha();
                    fCambiarFecha.FechaSeleccionada = Convert.ToDateTime(dgvDetallePlanilla.Rows[dgvDetallePlanilla.SelectedCells[0].RowIndex].Cells["FechaInicio"].Value);
                    if (fCambiarFecha.ShowDialog() == DialogResult.OK)
                    {
                        dgvDetallePlanilla.Rows[dgvDetallePlanilla.SelectedCells[0].RowIndex].Cells["FechaInicio"].Value = fCambiarFecha.FechaSeleccionada;
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar fecha: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCambiarCargo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetallePlanilla.SelectedCells.Count > 0)
                {
                    frmCambiarString fCambiarString = new frmCambiarString();
                    fCambiarString.StringSeleccionado = dgvDetallePlanilla.Rows[dgvDetallePlanilla.SelectedCells[0].RowIndex].Cells["colCargo"].Value.ToString();
                    if (fCambiarString.ShowDialog() == DialogResult.OK)
                    {
                        dgvDetallePlanilla.Rows[dgvDetallePlanilla.SelectedCells[0].RowIndex].Cells["colCargo"].Value = fCambiarString.StringSeleccionado;
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar fecha: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCambiarFechaFin_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetallePlanilla.SelectedCells.Count > 0)
                {
                    frmCambiarFecha fCambiarFecha = new frmCambiarFecha();
                    if (dgvDetallePlanilla.Rows[dgvDetallePlanilla.SelectedCells[0].RowIndex].Cells["fechafin"].Value.ToString() == "")
                    {
                        fCambiarFecha.FechaSeleccionada = DateTime.Now;
                    }
                    else
                    {
                        fCambiarFecha.FechaSeleccionada = Convert.ToDateTime(dgvDetallePlanilla.Rows[dgvDetallePlanilla.SelectedCells[0].RowIndex].Cells["fechafin"].Value);
                    }
                    if (fCambiarFecha.ShowDialog() == DialogResult.OK)
                    {
                        dgvDetallePlanilla.Rows[dgvDetallePlanilla.SelectedCells[0].RowIndex].Cells["fechafin"].Value = fCambiarFecha.FechaSeleccionada;
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar fecha: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAsistenciaReloj_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetallePlanilla.SelectedCells.Count > 0)
                {
                    AsistenciaGen.frmJornadaLaboral fJornadaLaboral = new AsistenciaGen.frmJornadaLaboral();
                    fJornadaLaboral.miTrabajador = miTrabajador.traerTrabajador(Convert.ToInt32(dgvDetallePlanilla.Rows[dgvDetallePlanilla.SelectedCells[0].RowIndex].Cells[4].Value));
                    fJornadaLaboral.Mes = new DateTime(Convert.ToInt32(saño), Convert.ToInt32(Mes(smes)), 1);
                    if (fJornadaLaboral.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar la asistencia del reloj: " + ex.Message);
            }
        }

        private void btnImprimirReporteAsistencia_Click(object sender, EventArgs e)
        {
            try
            {
                CapaDeNegocios.Asistencia.cTrabajadorReloj miTrabajadorReloj;

                CapaDeNegocios.AsistenciaGeneral.cCatalogoJornadaLaboral miCatalogo = new CapaDeNegocios.AsistenciaGeneral.cCatalogoJornadaLaboral();
                CapaDeNegocios.Asistencia.cCatalogoAsistencia miCatalogoAsistencia = new CapaDeNegocios.Asistencia.cCatalogoAsistencia();
                CapaDeNegocios.Asistencia.cHorario oHorario = new CapaDeNegocios.Asistencia.cHorario();

                if (dgvDetallePlanilla.Rows.Count > 0)
                {
                    CapaDeNegocios.Reportes.cReporteAsistencia oReporte = new CapaDeNegocios.Reportes.cReporteAsistencia();

                    CapaDeNegocios.Reportes.cReportePDF miReporte = new CapaDeNegocios.Reportes.cReportePDF();
                    dlgGuardarReportePDF.FileName = "RepAsist_Nro_" + oPlanilla.Numero.Trim() + "_" + oPlanilla.Mes + "_" + oPlanilla.Año;
                    if (dlgGuardarReportePDF.ShowDialog() == DialogResult.OK)
                    {
                        List<CapaDeNegocios.Reportes.cReporteMultipleAsistencia> ListaMultiplesAsistencias = new List<CapaDeNegocios.Reportes.cReporteMultipleAsistencia>();
                        DateTime Inicio = DateTime.Now;
                        DateTime Fin = DateTime.Now;
                        DateTime MesActual = new DateTime(Convert.ToInt32(saño), Convert.ToInt32(Mes(smes)), 1);

                        for (int i = 0; i < dgvDetallePlanilla.Rows.Count; i++)
                        {
                            CapaDeNegocios.Reportes.cReporteMultipleAsistencia oMultiple = new CapaDeNegocios.Reportes.cReporteMultipleAsistencia();
                            oMultiple.Trabajador = miTrabajador.traerTrabajador(Convert.ToInt32(dgvDetallePlanilla.Rows[i].Cells[4].Value));
                            
                            miTrabajadorReloj = miCatalogoAsistencia.TraerTrabajadorReloj(oMultiple.Trabajador);
                            oHorario = miCatalogoAsistencia.TraerHorarioTrabajador(oMultiple.Trabajador);

                            //if (oHorario == null)
                            //{
                            //    MessageBox.Show("No existe asignado horario para el trabajador: " + oMultiple.Trabajador.ApellidoPaterno + " " + oMultiple.Trabajador.ApellidoMaterno + ", " + oMultiple.Trabajador.Nombres);
                            //}
                            oMultiple.AsistenciaMes = miCatalogoAsistencia.LLenarAsistencia(oMultiple.Trabajador, MesActual.Month, MesActual.Year, oHorario);
                            Inicio = oMultiple.AsistenciaMes.InicioMes;
                            Fin = oMultiple.AsistenciaMes.FinMes;
                            oMultiple.AsistenciaMes.ListaAsistenciaDia = oMultiple.AsistenciaMes.LlenarAsistencias(miCatalogoAsistencia.ListaPicadoEntreFechas(miTrabajadorReloj, oMultiple.AsistenciaMes.InicioMes, oMultiple.AsistenciaMes.FinMes),
                                                                                                                                   oMultiple.AsistenciaMes.InicioMes,
                                                                                                                                   oMultiple.AsistenciaMes.FinMes,
                                                                                                                                   miCatalogoAsistencia.TraerHorarioTrabajador(oMultiple.Trabajador),
                                                                                                                                   miCatalogoAsistencia.ListaSalidasEntreFechas(oMultiple.Trabajador, oMultiple.AsistenciaMes.InicioMes, oMultiple.AsistenciaMes.FinMes),
                                                                                                                                   miCatalogoAsistencia.ListaDiaFestivo(MesActual.Year));
                            oMultiple.AsistenciaMes.Actualizardatos();
                            oMultiple.JornadaLaboral = miCatalogo.TraerJornadaLaboralEntreFechas(oMultiple.Trabajador, oMultiple.AsistenciaMes.InicioMes, oMultiple.AsistenciaMes.FinMes);
                            ListaMultiplesAsistencias.Add(oMultiple);
                        }
                        oReporte.ImprimirReporteAsistenciMultipleAsistencia(ListaMultiplesAsistencias, dlgGuardarReportePDF.FileName,Inicio, Fin);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir reporte de asistencia." + ex.Message, "Reporte de Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerDetalleTrabajador_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetallePlanilla.SelectedCells.Count > 0)
                {
                    frmDetallePagosTrabajador fDetalle = new frmDetallePagosTrabajador();
                    fDetalle.oTrabajador = miTrabajador.traerTrabajador(Convert.ToInt32(dgvDetallePlanilla.Rows[dgvDetallePlanilla.SelectedCells[0].RowIndex].Cells[4].Value));
                    if (fDetalle.ShowDialog() == DialogResult.OK)
                    {

                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar la asistencia del reloj: " + ex.Message);
            }
        }

        private void chkObservaciones_CheckedChanged(object sender, EventArgs e)
        {
            dgvDetallePlanilla.Columns["SUELDOPACTADO"].Visible = chkObservaciones.Checked;
            dgvDetallePlanilla.Columns["SUELDOAFECTO"].Visible = chkObservaciones.Checked;
            dgvDetallePlanilla.Columns["OBSERVACIONES"].Visible = chkObservaciones.Checked;
        }

        private void DibujarDataGrid()
        {
            string abrev_ingresos = ""; string abrev_descuentos = ""; string abrev_atrabajador = ""; string abrev_aempleador = "";
            string id_ingresos = ""; string id_descuentos = ""; string id_atrabajador = ""; string id_aempleador = "";
            int j = dgvDetallePlanilla.ColumnCount;
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();

            
            CapaDeNegocios.Planillas.cPlantillaPlanilla miPlantillaPlanilla = new CapaDeNegocios.Planillas.cPlantillaPlanilla();
            oDataPlantillaPlanilla = miPlantillaPlanilla.ListarPlantillaPlanilla(splantilla);

            DataTable oDataMaestroIngresos = new DataTable();
            CapaDeNegocios.Sunat.cMaestroIngresos miMaestroIngresos = new CapaDeNegocios.Sunat.cMaestroIngresos();
            oDataMaestroIngresos = miMaestroIngresos.ListarMaestroIngresos("");

            DataTable oDataMaestroATrabajador = new DataTable();
            CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador miMaestroATrabajador = new CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador();
            oDataMaestroATrabajador = miMaestroATrabajador.ListarMaestroAportacionesTrabajador();

            DataTable oDataMaestroDescuentos = new DataTable();
            CapaDeNegocios.Sunat.cMaestroDescuentos miMaestroDescuentos = new CapaDeNegocios.Sunat.cMaestroDescuentos();
            oDataMaestroDescuentos = miMaestroDescuentos.ListarMaestroDescuentos();

            

            DataTable oDataMaestroAEmpleador = new DataTable();
            CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador miMaestroAEmpleador = new CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador();
            oDataMaestroAEmpleador = miMaestroAEmpleador.ListarMaestroAportacionesEmpleador();

            smingresos = new string[oDataPlantillaPlanilla.Rows.Count, 18];

            //codigo para ocultar los botones para cargar tareos segun la opcion de la plantilla, columna 5
            if (Convert.ToBoolean(oDataPlantillaPlanilla.Rows[0][5]))
            {
                btnAgregarTrabajador.Visible = false;
                btnImportar.Visible = true;
                esTareo = true;
            }
            else
            {
                btnAgregarTrabajador.Visible = true;
                btnImportar.Visible = false;

                esTareo = false;
            }

            // codigo para asignar si se va a sacar de la meta jornal o no, segun la columna 6 de la plantilla
            if (Convert.ToBoolean(oDataPlantillaPlanilla.Rows[0][6]))
            {
                esMetaJornal = true;
            }
            else
            {
                esMetaJornal = false;
            }

            foreach (DataRow row in oDataPlantillaPlanilla.Select("tipo='INGRESOS'"))
            {
                foreach (DataRow rowmingresos in oDataMaestroIngresos.Select("idtmaestroingresos = '" + row[4].ToString() + "'"))
                {
                    smingresos[con_ingresos, 0] = rowmingresos[0].ToString();
                    id_ingresos = rowmingresos[0].ToString();
                    smingresos[con_ingresos, 1] = rowmingresos[1].ToString();
                    smingresos[con_ingresos, 2] = rowmingresos[2].ToString();
                    smingresos[con_ingresos, 3] = rowmingresos[15].ToString();
                    smingresos[con_ingresos, 4] = rowmingresos[3].ToString();
                    smingresos[con_ingresos, 5] = rowmingresos[4].ToString();
                    smingresos[con_ingresos, 6] = rowmingresos[5].ToString();
                    smingresos[con_ingresos, 7] = rowmingresos[6].ToString();
                    smingresos[con_ingresos, 8] = rowmingresos[7].ToString();
                    smingresos[con_ingresos, 9] = rowmingresos[8].ToString();
                    smingresos[con_ingresos, 10] = rowmingresos[9].ToString();
                    smingresos[con_ingresos, 11] = rowmingresos[10].ToString();
                    smingresos[con_ingresos, 12] = rowmingresos[11].ToString();
                    smingresos[con_ingresos, 13] = rowmingresos[12].ToString();
                    smingresos[con_ingresos, 14] = rowmingresos[13].ToString();
                    smingresos[con_ingresos, 15] = rowmingresos[14].ToString();
                    smingresos[con_ingresos, 16] = rowmingresos[16].ToString();
                    smingresos[con_ingresos, 17] = rowmingresos[17].ToString();
                    abrev_ingresos = rowmingresos[16].ToString();
                }
                con_ingresos += 1;
                col = new DataGridViewTextBoxColumn();
                col.Name = "I" + id_ingresos;
                col.HeaderText = abrev_ingresos;
                dgvDetallePlanilla.Columns.Add(col);
                dgvDetallePlanilla.Columns["I" + id_ingresos].Width = 50;
                dgvDetallePlanilla.Columns["I" + id_ingresos].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dgvDetallePlanilla.Columns["I" + con_ingresos].DisplayIndex = 10 + con_ingresos;
            }
            //TOTAL INGRESOS
            col = new DataGridViewTextBoxColumn();
            col.Name = "SUMA_INGRESOS";
            col.HeaderText = "REMUNER. TOTAL BRUTA";
            dgvDetallePlanilla.Columns.Add(col);
            dgvDetallePlanilla.Columns["SUMA_INGRESOS"].ReadOnly = true;
            dgvDetallePlanilla.Columns["SUMA_INGRESOS"].Width = 50;
            dgvDetallePlanilla.Columns["SUMA_INGRESOS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //SUELDO AFECTO
            col = new DataGridViewTextBoxColumn();
            col.Name = "SUELDOAFECTO";
            col.HeaderText = "SUELDO AFECTO";
            dgvDetallePlanilla.Columns.Add(col);
            dgvDetallePlanilla.Columns["SUELDOAFECTO"].ReadOnly = true;
            dgvDetallePlanilla.Columns["SUELDOAFECTO"].Width = 65;
            dgvDetallePlanilla.Columns["SUELDOAFECTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetallePlanilla.Columns["SUELDOAFECTO"].Visible = false;


            //// AFP
            //col = new DataGridViewTextBoxColumn();
            //col.Name = "AFP";
            //col.HeaderText = "AFP";
            //dgvDetallePlanilla.Columns.Add(col);
            //dgvDetallePlanilla.Columns["AFP"].ReadOnly = true;
            //dgvDetallePlanilla.Columns["AFP"].Width = 80;
            //dgvDetallePlanilla.Columns["AFP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //// TipoComision
            //col = new DataGridViewTextBoxColumn();
            //col.Name = "TipoComision";
            //col.HeaderText = "TIPO COMISION";
            //dgvDetallePlanilla.Columns.Add(col);
            //dgvDetallePlanilla.Columns["TipoComision"].ReadOnly = true;
            //dgvDetallePlanilla.Columns["TipoComision"].Width = 50;
            //dgvDetallePlanilla.Columns["TipoComision"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //// Cuspp
            //col = new DataGridViewTextBoxColumn();
            //col.Name = "Cuspp";
            //col.HeaderText = "Cuspp";
            //dgvDetallePlanilla.Columns.Add(col);
            //dgvDetallePlanilla.Columns["Cuspp"].ReadOnly = true;
            //dgvDetallePlanilla.Columns["Cuspp"].Width = 90;
            //dgvDetallePlanilla.Columns["Cuspp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            sma_trabajador = new string[oDataPlantillaPlanilla.Rows.Count, 4];
            foreach (DataRow row in oDataPlantillaPlanilla.Select("tipo='A_TRABAJADOR'"))
            {
                foreach (DataRow rowmatrabajador in oDataMaestroATrabajador.Select("idtmaestroaportacionestrabajador = '" + row[4].ToString() + "'"))
                {
                    sma_trabajador[con_trabajador, 0] = rowmatrabajador[0].ToString();
                    id_atrabajador = rowmatrabajador[0].ToString();
                    sma_trabajador[con_trabajador, 1] = rowmatrabajador[1].ToString();
                    sma_trabajador[con_trabajador, 2] = rowmatrabajador[2].ToString();
                    sma_trabajador[con_trabajador, 3] = rowmatrabajador[3].ToString();
                    abrev_atrabajador = rowmatrabajador[4].ToString();
                }
                con_trabajador += 1;
                col = new DataGridViewTextBoxColumn();
                col.Name = "T" + id_atrabajador;
                col.HeaderText = abrev_atrabajador;
                dgvDetallePlanilla.Columns.Add(col);
                dgvDetallePlanilla.Columns["T" + id_atrabajador].Width = 50;
                dgvDetallePlanilla.Columns["T" + id_atrabajador].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            //TOTAL A_TRABAJADOR
            col = new DataGridViewTextBoxColumn();
            col.Name = "SUMA_A_TRABAJADOR";
            col.HeaderText = "TOTAL APORT. TRAB.";
            dgvDetallePlanilla.Columns.Add(col);
            dgvDetallePlanilla.Columns["SUMA_A_TRABAJADOR"].ReadOnly = true;
            dgvDetallePlanilla.Columns["SUMA_A_TRABAJADOR"].Width = 50;
            dgvDetallePlanilla.Columns["SUMA_A_TRABAJADOR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            smdescuentos = new string[oDataPlantillaPlanilla.Rows.Count, 7];
            foreach (DataRow row in oDataPlantillaPlanilla.Select("tipo='DESCUENTOS'"))
            {
                foreach (DataRow rowmdescuentos in oDataMaestroDescuentos.Select("idtmaestrodescuentos = '" + row[4].ToString() + "'"))
                {
                    smdescuentos[con_descuento, 0] = rowmdescuentos[0].ToString();
                    id_descuentos = rowmdescuentos[0].ToString();
                    smdescuentos[con_descuento, 1] = rowmdescuentos[1].ToString();
                    smdescuentos[con_descuento, 2] = rowmdescuentos[2].ToString();
                    smdescuentos[con_descuento, 3] = rowmdescuentos[3].ToString();
                    smdescuentos[con_descuento, 4] = rowmdescuentos[4].ToString();
                    smdescuentos[con_descuento, 5] = rowmdescuentos[5].ToString();
                    smdescuentos[con_descuento, 6] = rowmdescuentos[6].ToString();
                    abrev_descuentos = rowmdescuentos[4].ToString();
                }
                con_descuento += 1;
                col = new DataGridViewTextBoxColumn();
                col.Name = "D" + id_descuentos;
                col.HeaderText = abrev_descuentos;
                dgvDetallePlanilla.Columns.Add(col);
                dgvDetallePlanilla.Columns["D" + id_descuentos].Width = 50;
                dgvDetallePlanilla.Columns["D" + id_descuentos].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            //TOTAL DESCUENTOS
            col = new DataGridViewTextBoxColumn();
            col.Name = "SUMA_DESCUENTOS";
            col.HeaderText = "DESCUENTOS";
            dgvDetallePlanilla.Columns.Add(col);
            dgvDetallePlanilla.Columns["SUMA_DESCUENTOS"].ReadOnly = true;
            dgvDetallePlanilla.Columns["SUMA_DESCUENTOS"].Width = 60;
            dgvDetallePlanilla.Columns["SUMA_DESCUENTOS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //TOTAL A_TRABAJADOR + DESCUENTOS
            col = new DataGridViewTextBoxColumn();
            col.Name = "TOTAL_DESCUENTOS";
            col.HeaderText = "TOTAL DESCUENTOS";
            dgvDetallePlanilla.Columns.Add(col);
            dgvDetallePlanilla.Columns["TOTAL_DESCUENTOS"].ReadOnly = true;
            dgvDetallePlanilla.Columns["TOTAL_DESCUENTOS"].Width = 60;
            dgvDetallePlanilla.Columns["TOTAL_DESCUENTOS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            if (oPlanilla.TipoImpresionTardanzaFalta == CapaDeNegocios.Planillas.enumTipoImpresionTardanzaFalta.AfectaAlSueldo)
            {
                for (int i = 0; i < con_descuento; i++)
                {
                    if (smdescuentos[i, 1].ToString() == "0705")
                    {
                        dgvDetallePlanilla.Columns[inicioDescuentos + con_ingresos + con_trabajador + i].Visible = false;
                    }
                    if (smdescuentos[i, 1].ToString() == "0704")
                    {
                        dgvDetallePlanilla.Columns[inicioDescuentos + con_ingresos + con_trabajador + i].Visible = false;
                    }
                }
            }


            sma_empleador = new string[oDataPlantillaPlanilla.Rows.Count, 4];
            foreach (DataRow row in oDataPlantillaPlanilla.Select("tipo='A_EMPLEADOR'"))
            {
                foreach (DataRow rowmaempleador in oDataMaestroAEmpleador.Select("idtmaestroaportacionesempleador = '" + row[4].ToString() + "'"))
                {
                    sma_empleador[con_empleador, 0] = rowmaempleador[0].ToString();
                    id_aempleador = rowmaempleador[0].ToString();
                    sma_empleador[con_empleador, 1] = rowmaempleador[1].ToString();
                    sma_empleador[con_empleador, 2] = rowmaempleador[2].ToString();
                    sma_empleador[con_empleador, 3] = rowmaempleador[3].ToString();
                    abrev_aempleador = rowmaempleador[4].ToString();
                }
                con_empleador += 1;
                col = new DataGridViewTextBoxColumn();
                col.Name = "E" + id_aempleador;
                col.HeaderText = abrev_aempleador;
                dgvDetallePlanilla.Columns.Add(col);
                dgvDetallePlanilla.Columns["E" + id_aempleador].Width = 50;
                dgvDetallePlanilla.Columns["E" + id_aempleador].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            //TOTAL A_EMPLEADOR
            col = new DataGridViewTextBoxColumn();
            col.Name = "TOTAL_A_EMPLEADOR";
            col.HeaderText = "TOTAL A. EMPLE.";
            dgvDetallePlanilla.Columns.Add(col);
            dgvDetallePlanilla.Columns["TOTAL_A_EMPLEADOR"].ReadOnly = true;
            dgvDetallePlanilla.Columns["TOTAL_A_EMPLEADOR"].Width = 50;
            dgvDetallePlanilla.Columns["TOTAL_A_EMPLEADOR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //NETO A COBRAR
            col = new DataGridViewTextBoxColumn();
            col.Name = "NETOACOBRAR";
            col.HeaderText = "NETO A COBRAR";
            dgvDetallePlanilla.Columns.Add(col);
            dgvDetallePlanilla.Columns["NETOACOBRAR"].ReadOnly = true;
            dgvDetallePlanilla.Columns["NETOACOBRAR"].Width = 65;
            dgvDetallePlanilla.Columns["NETOACOBRAR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            ////SUELDO PACTADO
            //col = new DataGridViewTextBoxColumn();
            //col.Name = "SUELDOPACTADO";
            //col.HeaderText = "SUELDO PACTADO";
            //dgvDetallePlanilla.Columns.Add(col);
            //dgvDetallePlanilla.Columns["SUELDOPACTADO"].ReadOnly = true;
            //dgvDetallePlanilla.Columns["SUELDOPACTADO"].Width = 65;
            //dgvDetallePlanilla.Columns["SUELDOPACTADO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvDetallePlanilla.Columns["SUELDOPACTADO"].Visible = false;

            
            //OBSERVACIONES
            col = new DataGridViewTextBoxColumn();
            col.Name = "OBSERVACIONES";
            col.HeaderText = "OBSERVACIONES";
            col.MaxInputLength = 99;
            dgvDetallePlanilla.Columns.Add(col);
            dgvDetallePlanilla.Columns["OBSERVACIONES"].ReadOnly = false;
            dgvDetallePlanilla.Columns["OBSERVACIONES"].Width = 65;
            dgvDetallePlanilla.Columns["OBSERVACIONES"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetallePlanilla.Columns["OBSERVACIONES"].ValueType = typeof(String);
            dgvDetallePlanilla.Columns["OBSERVACIONES"].Visible = false;


            //JORNAL
            col = new DataGridViewTextBoxColumn();
            col.Name = "JORNAL";
            col.HeaderText = "JORNAL";
            dgvDetallePlanilla.Columns.Add(col);
            dgvDetallePlanilla.Columns["JORNAL"].ReadOnly = true;
            dgvDetallePlanilla.Columns["JORNAL"].Visible = false;
            dgvDetallePlanilla.Columns["JORNAL"].Width = 65;
            dgvDetallePlanilla.Columns["JORNAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            ////FECHA FIN
            //col = new DataGridViewTextBoxColumn();
            //col.Name = "FECHAFIN";
            //col.HeaderText = "FECHAFIN";
            //dgvDetallePlanilla.Columns.Add(col);
            //dgvDetallePlanilla.Columns["FECHAFIN"].ReadOnly = true;
            //dgvDetallePlanilla.Columns["FECHAFIN"].Visible = false;
            //dgvDetallePlanilla.Columns["FECHAFIN"].Width = 65;
            //dgvDetallePlanilla.Columns["FECHAFIN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //COD AFP
            col = new DataGridViewTextBoxColumn();
            col.Name = "CODAFP";
            col.HeaderText = "CODAFP";
            dgvDetallePlanilla.Columns.Add(col);
            dgvDetallePlanilla.Columns["CODAFP"].ReadOnly = true;
            dgvDetallePlanilla.Columns["CODAFP"].Visible = false;
            dgvDetallePlanilla.Columns["CODAFP"].Width = 65;
            dgvDetallePlanilla.Columns["CODAFP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void MostrarColumnas()
        {
            if (oPlanilla.TipoImpresionTardanzaFalta == CapaDeNegocios.Planillas.enumTipoImpresionTardanzaFalta.AfectaAlSueldo)
            {
                dgvDetallePlanilla.Columns["FALTAS"].Visible = true;
                dgvDetallePlanilla.Columns["TARDANZAS"].Visible = true;
                dgvDetallePlanilla.Columns["SUELDOFALTASTAR"].Visible = true;
            }
            else
            {
                dgvDetallePlanilla.Columns["FALTAS"].Visible = false;
                dgvDetallePlanilla.Columns["TARDANZAS"].Visible = false;
                dgvDetallePlanilla.Columns["SUELDOFALTASTAR"].Visible = false;
            }
            ////columna remuneracion o jornal
            //dgvDetallePlanilla.Columns[11].Visible = false;
            ////columna remuneracion total
            //dgvDetallePlanilla.Columns[13].Visible = false;
            dgvDetallePlanilla.Columns["SUMA_DESCUENTOS"].Visible = false;
            dgvDetallePlanilla.Columns["TOTAL_A_EMPLEADOR"].Visible = false;
            if (splantilla == "CESANTES")
            {
                dgvDetallePlanilla.Columns["colCargo"].Visible = false;
                dgvDetallePlanilla.Columns["SecFunc"].Visible = false;
                dgvDetallePlanilla.Columns["FechaInicio"].Visible = false;
                dgvDetallePlanilla.Columns["DiasLaborados"].Visible = false;
                dgvDetallePlanilla.Columns["colAFP"].Visible = false;
                dgvDetallePlanilla.Columns["colComision"].Visible = false;
                dgvDetallePlanilla.Columns["colCUSPP"].Visible = false;
                dgvDetallePlanilla.Columns["SUMA_A_TRABAJADOR"].Visible = false;
                dgvDetallePlanilla.Columns["fechafin"].Visible = false;
                dgvDetallePlanilla.Columns["DIASMES"].Visible = false;
                dgvDetallePlanilla.Columns["DIASSUSPENDIDOS"].Visible = false;
            }

            if (oPlanilla.TipoPlanilla == CapaDeNegocios.Planillas.enumTipoPlanilla.VACACIONES_TRUNCAS)
            {
                btnCambiarCargo.Visible = true;
            }
        }

        string Mes(string pmes)
        {
            string x = "";
            switch (pmes)
            {
                case "ENERO":
                    x = "01";
                    break;
                case "FEBRERO":
                    x = "02";
                    break;
                case "MARZO":
                    x = "03";
                    break;
                case "ABRIL":
                    x = "04";
                    break;
                case "MAYO":
                    x = "05";
                    break;
                case "JUNIO":
                    x = "06";
                    break;
                case "JULIO":
                    x = "07";
                    break;
                case "AGOSTO":
                    x = "08";
                    break;
                case "SETIEMBRE":
                    x = "09";
                    break;
                case "OCTUBRE":
                    x = "10";
                    break;
                case "NOVIEMBRE":
                    x = "11";
                    break;
                case "DICIEMBRE":
                    x = "12";
                    break;
            }
            return x;
        }
    }
}
