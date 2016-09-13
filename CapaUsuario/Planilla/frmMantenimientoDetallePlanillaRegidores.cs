using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using info.lundin.math;

namespace CapaUsuario.Planilla
{
    public partial class frmMantenimientoDetallePlanillaRegidores : Form
    {
        int con_ingresos = 0, con_trabajador = 0, con_descuento = 0, con_empleador = 0;
        int contador = 0;
        int sidtplanilla;
        int sidtregimenlaboral;
        int sidtmeta;
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
        decimal sDieta = 0;

        string AFP = "";
        string Cuspp = "";
        string TipoComision = "";
        decimal PrimaSeguros = 0;
        decimal AporteObligatorio = 0;
        decimal RemuneracionAsegurable = 0;
        decimal ComisionFlujo = 0;
        decimal ComisionMixta = 0;

        DataTable oDataDetallePlanilla = new DataTable();
        DataTable oDataTrabajador = new DataTable();
        DataTable oDataPeriodoTrabajador = new DataTable();
        DataTable oDataRegimenTrabajador = new DataTable();
        DataTable oDataRegimenPensionarioTrabajador = new DataTable();
        DataTable oDataRegimenSaludTrabajador = new DataTable();
        DataTable oDataCargo = new DataTable();
        DataTable oDataAFP = new DataTable();
        DataTable oDataComisionAFP = new DataTable();

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
        CapaDeNegocios.cListaAFP miAFP = new CapaDeNegocios.cListaAFP(); 
        CapaDeNegocios.cComisionesAFP miComisionAFP = new CapaDeNegocios.cComisionesAFP();

        public frmMantenimientoDetallePlanillaRegidores()
        {
            InitializeComponent();
        }

        private void frmMantenimientoDetallePlanilla_Load(object sender, EventArgs e)
        {
            DibujarDataGrid();
            MostrarColumnas();
            oDataTrabajador = miTrabajador.ObtenerListaTrabajadores(true);
            oDataPeriodoTrabajador = miPeriodoTrabajador.ListarPeriodoTrabajador(0);
            oDataRegimenTrabajador = miRegimenTrabajor.ListarRegimenTrabajador(0);
            oDataRegimenPensionarioTrabajador = miRegimenPensionarioTrabajor.ListarRegimenPensionarioTrabajador(0);
            oDataRegimenSaludTrabajador = miRegimenSaludTrajador.ListarRegimenSaludTrabajador(0);
            oDataCargo = miCargo.ListaCargos();
            oDataAFP = miAFP.ObtenerListaAFP();
            Variables();
            CargarDatos();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            decimal pagoobrero = 0;
            bool sexistsmetajornal = false;
            dgvDetallePlanilla.Rows.Clear();
            DataTable oDataTareo = new DataTable();
            DataTable oDataDetalleTareo = new DataTable();
            DataTable oDataMejaJornal = new DataTable();

            CapaDeNegocios.Tareos.cTareo miTareo = new CapaDeNegocios.Tareos.cTareo();
            CapaDeNegocios.Tareos.cDetalleTareo miDetalleTareo = new CapaDeNegocios.Tareos.cDetalleTareo();
            CapaDeNegocios.Obras.cMetaJornal miMetaJornal = new CapaDeNegocios.Obras.cMetaJornal();

            oDataTareo = miTareo.ListarTareo(sidtmeta);
            oDataMejaJornal = miMetaJornal.ListarMetaJornal(sidtmeta);
            oDataDetalleTareo = miDetalleTareo.ListarDetalleTareo(Convert.ToInt32(oDataTareo.Compute("MAX(idttareo)", "descripcion = '" + splantilla + "'")));
            foreach (DataRow rowdetalletareo in oDataDetalleTareo.Select("idttareo = '" + Convert.ToInt32(oDataTareo.Compute("MAX(idttareo)", "descripcion = '" + splantilla + "'")) + "'"))
            {
                pagoobrero = 0;
                if (splantilla == "PERSONAL OBRERO")
                {
                    foreach (DataRow rowmetajornal in oDataMejaJornal.Select("categoria = '" + rowdetalletareo[1].ToString() + "'"))
                    {
                        sexistsmetajornal = true;
                        pagoobrero = Convert.ToDecimal(rowmetajornal[2].ToString());
                    }
                    if (sexistsmetajornal == false)
                    {
                        MessageBox.Show("La Remuneración de los Obreros no existe, debe crearlo en MetaJornal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                CargarTrabajador(Convert.ToInt32(rowdetalletareo[4].ToString()));
                if (dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[4].Value.ToString() == rowdetalletareo[4].ToString())
                {
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[7].Value = rowdetalletareo[1].ToString();
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[12].Value = rowdetalletareo[3].ToString();
                    if (splantilla == "PERSONAL OBRERO")
                    {
                        dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[11].Value = String.Format("{0:0.00}", pagoobrero);
                    }
                }
                TotalRemuneracion(dgvDetallePlanilla.Rows.Count - 1);
            }
        }

        private void btnAgregarTrabajador_Click(object sender, EventArgs e)
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
                        CargarTrabajador(Convert.ToInt32(sselecciontrabajadores[i, 0].ToString()));
                        TotalRemuneracion(dgvDetallePlanilla.Rows.Count - 1);
                    }
                    else
                    {
                        MessageBox.Show("El trabajador ya se encuentra en la planilla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRegidores_Click(object sender, EventArgs e)
        {
            CargarRegidores();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (dgvDetallePlanilla.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos que se puedan calcular.", "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool bOk = false;
            foreach (DataGridViewRow row in dgvDetallePlanilla.Rows)
            {
                miDetallePlanilla.IdtDetallePlanilla = Convert.ToInt32(row.Cells[0].Value);
                miDetallePlanilla.Cargo = Convert.ToString(row.Cells[7].Value);
                miDetallePlanilla.FechaInicio = Convert.ToDateTime(row.Cells[10].Value);
                miDetallePlanilla.DiasLaborados = Convert.ToInt32(row.Cells[12].Value);
                miDetallePlanilla.TotalIngresos = Convert.ToDecimal(row.Cells[14 + con_ingresos].Value);
                miDetallePlanilla.TotalATrabajador = Convert.ToDecimal(row.Cells[18 + con_ingresos + con_trabajador].Value);
                miDetallePlanilla.TotalDescuentos = Convert.ToDecimal(row.Cells[19 + con_ingresos + con_trabajador + con_descuento].Value);
                miDetallePlanilla.TotalAEmpleador = Convert.ToDecimal(row.Cells[21 + con_ingresos + con_trabajador + con_descuento + con_empleador].Value);
                miDetallePlanilla.NetoaCobrar = Convert.ToDecimal(row.Cells[22 + con_ingresos + con_trabajador + con_descuento + con_empleador].Value);
                miDetallePlanilla.IdtTrabajador = Convert.ToInt32(row.Cells[4].Value);
                miDetallePlanilla.IdtPlanilla = sidtplanilla;
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
                        string z = dgvDetallePlanilla.Columns[14 + i].Name.ToString();
                        int x = dgvDetallePlanilla.Columns[14 + i].Name.Length;
                        int y = Convert.ToInt32(dgvDetallePlanilla.Columns[14 + i].Name.Substring(1, x - 1));
                        miDetallePlanillaIngresos.IdtDetallePlanillaIngresos = 0;
                        miDetallePlanillaIngresos.Monto = Convert.ToDecimal(row.Cells[14 + i].Value);
                        miDetallePlanillaIngresos.IdtMaestroIngresos = y;
                        miDetallePlanillaIngresos.IdtDetallePlanilla = Convert.ToInt32(row.Cells[0].Value);
                        miDetallePlanillaIngresos.CrearDetallePlanillaIngresos(miDetallePlanillaIngresos);
                    }
                }
                if (con_trabajador > 0)
                {
                    for (int i = 0; i < con_trabajador; i++)
                    {
                        string z = dgvDetallePlanilla.Columns[18 + con_ingresos + i].Name.ToString();
                        int x = dgvDetallePlanilla.Columns[18 + con_ingresos + i].Name.Length;
                        int y = Convert.ToInt32(dgvDetallePlanilla.Columns[18 + con_ingresos + i].Name.Substring(1, x - 1));
                        miDetallePlanillaATrabajador.IdtDetallePlanillaATrabajador = 0;
                        miDetallePlanillaATrabajador.Monto = Convert.ToDecimal(row.Cells[18 + con_ingresos + i].Value);
                        miDetallePlanillaATrabajador.IdtMaestroATrabajador = y;
                        miDetallePlanillaATrabajador.IdtDetallePlanilla = Convert.ToInt32(row.Cells[0].Value);
                        miDetallePlanillaATrabajador.CrearDetallePlanillaATrabajador(miDetallePlanillaATrabajador);
                    }
                }
                if (con_descuento > 0)
                {
                    for (int i = 0; i < con_descuento; i++)
                    {
                        string z = dgvDetallePlanilla.Columns[19 + con_ingresos + con_trabajador + i].Name.ToString();
                        int x = dgvDetallePlanilla.Columns[19 + con_ingresos + con_trabajador + i].Name.Length;
                        int y = Convert.ToInt32(dgvDetallePlanilla.Columns[19 + con_ingresos + con_trabajador + i].Name.Substring(1, x - 1));
                        miDetallePlanillaDescuentos.IdtDetallePlanillaDescuentos = 0;
                        miDetallePlanillaDescuentos.Monto = Convert.ToDecimal(row.Cells[19 + con_ingresos + con_trabajador + i].Value);
                        miDetallePlanillaDescuentos.IdtMaestroDescuentos = y;
                        miDetallePlanillaDescuentos.IdtDetallePlanilla = Convert.ToInt32(row.Cells[0].Value);
                        miDetallePlanillaDescuentos.CrearDetallePlanillaDescuentos(miDetallePlanillaDescuentos);
                    }
                }
                if (con_empleador > 0)
                {
                    for (int i = 0; i < con_empleador; i++)
                    {
                        string z = dgvDetallePlanilla.Columns[21 + con_ingresos + con_trabajador + con_descuento + i].Name.ToString();
                        int x = dgvDetallePlanilla.Columns[21 + con_ingresos + con_trabajador + con_descuento + i].Name.Length;
                        int y = Convert.ToInt32(dgvDetallePlanilla.Columns[21 + con_ingresos + con_trabajador + con_descuento + i].Name.Substring(1, x - 1));
                        miDetallePlanillaAEmpleador.IdtDetallePlanillaAEmpleador = 0;
                        miDetallePlanillaAEmpleador.Monto = Convert.ToDecimal(row.Cells[21 + con_ingresos + con_trabajador + con_descuento + i].Value);
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
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dgvDetallePlanilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetallePlanilla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string y = dgvDetallePlanilla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            decimal number2 = 0;
            if (decimal.TryParse(y, out number2) != true)
            {
                dgvDetallePlanilla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = String.Format("{0:0.00}", 0);
                return;
            }

            if (splantilla == "REGIDORES")
            {
                TotalRemuneracion(e.RowIndex);
            }
            else
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

        public void RecibirDatos(int pidtplanilla, string pnumero, string pmes, string paño, int pidtmeta, string pmeta, int pidtfuentefinanciamiento, string pfuentefinanciamiento, int pidtregimenlaboral, string pregimenlaboral, string pplantilla)
        {
            sidtplanilla = pidtplanilla;
            txtNumero.Text = pnumero;
            smes = pmes;
            saño = paño;
            txtFecha.Text = pmes + " - " + paño;
            sidtmeta = pidtmeta;
            txtMeta.Text = pmeta;
            //sidtfuentefinanciamiento = pidtfuentefinanciamiento;
            txtFuenteFinanciamiento.Text = pfuentefinanciamiento;
            sidtregimenlaboral = pidtregimenlaboral;
            txtRegimenLaboral.Text = pregimenlaboral;
            splantilla = pplantilla;
        }

        private void CargarDatos()
        {
            contador = 0;
            dgvDetallePlanilla.Rows.Clear();

            oDataDetallePlanilla = miDetallePlanilla.ListarDetallePlanilla(sidtplanilla);
            foreach (DataRow row in oDataDetallePlanilla.Rows)
            {
                CargarTrabajador(Convert.ToInt32(row[09].ToString()));
                TotalRemuneracion(dgvDetallePlanilla.Rows.Count - 1);
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells[0].Value = row[0].ToString();//IdtDetallePlanilla
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells[1].Value = "M";
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells[7].Value = row[1].ToString();//Cargo
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells[10].Value = row[2].ToString();//Fecha Inicio
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells[12].Value = row[3].ToString();//Dias Laborados
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells[14 + con_ingresos].Value = row[4].ToString();
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells[18 + con_ingresos + con_trabajador].Value = row[5].ToString();
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells[19 + con_ingresos + con_trabajador + con_descuento].Value = row[6].ToString();
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells[21 + con_ingresos + con_trabajador + con_descuento + con_empleador].Value = row[7].ToString();
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells[22 + con_ingresos + con_trabajador + con_descuento + con_empleador].Value = row[8].ToString();
                CargarIngresos(Convert.ToInt32(row[0].ToString()), dgvDetallePlanilla.RowCount - 1);
                CargarATrabajador(Convert.ToInt32(row[0].ToString()), dgvDetallePlanilla.RowCount - 1);
                CargarDescuentos(Convert.ToInt32(row[0].ToString()), dgvDetallePlanilla.RowCount - 1);
                CargarAEmpleador(Convert.ToInt32(row[0].ToString()), dgvDetallePlanilla.RowCount - 1);
                DatosAFP(dgvDetallePlanilla.RowCount - 1);
                CalcularTotalDescuentos(dgvDetallePlanilla.RowCount - 1);
            }
        }

        private void CargarTrabajador(int pidtrabajador)
        {
            string Nombre = "";
            string DNI = "";
            string FechaInicio = "";
            string MontoPago = "";
            int IdtCargo = 0;
            string Cargo = "";

            foreach (DataRow rowTrabajador in oDataTrabajador.Select("id_trabajador = '" + pidtrabajador + "'"))
            {
                Nombre = rowTrabajador[2].ToString() + " " + rowTrabajador[3].ToString() + " " + rowTrabajador[4].ToString();
                DNI = rowTrabajador[1].ToString();
                foreach (DataRow rowPeriodoTrabajador in oDataPeriodoTrabajador.Select("idttrabajador = '" + pidtrabajador + "'")) //and fechainicio <= '" + saño + "" + smes + "31' and(fechafin >= '" + saño + "" + smes + "01' or fechafin >= '')
                {
                    FechaInicio = rowPeriodoTrabajador[1].ToString();
                    foreach (DataRow rowRegimenTrabajador in oDataRegimenTrabajador.Select("idtperiodotrabajador = '" + Convert.ToInt32(rowPeriodoTrabajador[0].ToString()) + "'"))
                    {
                        MontoPago = rowRegimenTrabajador[6].ToString();
                        foreach (DataRow rowCargo in oDataCargo.Select("idtcargo = '" + Convert.ToInt32(rowRegimenTrabajador[15].ToString()) + "'"))
                        {
                            IdtCargo = Convert.ToInt32(rowCargo[0].ToString());
                            Cargo = rowCargo[1].ToString();
                        }
                    }
                    contador += 1;
                    if (splantilla == "REGIDORES")
                    { MontoPago = sDieta.ToString(); }
                    dgvDetallePlanilla.Rows.Add("0", "I", "", contador, pidtrabajador, Nombre, IdtCargo, Cargo, DNI, sidtmeta, FechaInicio, MontoPago, "", "");
                }
            }
        }

        private void CargarRegidores()
        {
            dgvDetallePlanilla.Rows.Clear();
            foreach (DataRow rowCargo in oDataCargo.Select("descripcion = 'REGIDOR'"))
            {
                foreach (DataRow rowRegimenTrabajador in oDataRegimenTrabajador.Select("idtmeta = '" + sidtmeta + "' and idtregimenlaboral = '" + sidtregimenlaboral + "' and fechainicio <= '31/" + smes + "/" + saño + "' and (fechafin >= '01/" + smes + "/" + saño + "' or fechafin>='') and idtcargo='" + rowCargo[0].ToString() + "'"))
                {
                    foreach (DataRow rowPeriodoTrabajador in oDataPeriodoTrabajador.Select("idtperiodotrabajador = '" + rowRegimenTrabajador[17].ToString() + "'"))
                    {
                        foreach (DataRow rowTrabajador in oDataTrabajador.Select("id_trabajador = '" + rowPeriodoTrabajador[4].ToString() + "'"))
                        {
                            CargarTrabajador(Convert.ToInt32(rowTrabajador[0].ToString()));
                        }
                    }
                }
            }
        }

        private void DatosAFP(int fila)
        {
            foreach (DataRow rowPeriodoTrabajador in oDataPeriodoTrabajador.Select("idttrabajador = '" + dgvDetallePlanilla.Rows[fila].Cells[4].Value.ToString() + "'"))
            {
                foreach (DataRow rowRegimenPensionarioTrabajador in oDataRegimenPensionarioTrabajador.Select("idtperiodotrabajador = '" + Convert.ToInt32(rowPeriodoTrabajador[0].ToString()) + "'"))
                {
                    Cuspp = rowRegimenPensionarioTrabajador[3].ToString();
                    TipoComision = rowRegimenPensionarioTrabajador[4].ToString();
                    foreach (DataRow rowAFP in oDataAFP.Select("idtafp = '" + Convert.ToInt32(rowRegimenPensionarioTrabajador[5].ToString()) + "'"))
                    {
                        AFP = rowAFP[1].ToString();
                    }
                    int xxx = Convert.ToInt32(rowRegimenPensionarioTrabajador[5].ToString());
                    oDataComisionAFP = miComisionAFP.ListarComisionAFP(Convert.ToInt32(rowRegimenPensionarioTrabajador[5].ToString()));
                    foreach (DataRow rowComisionAFP in oDataComisionAFP.Select(string.Format("mes=#{0:MM/dd/yyyy}#", "" + Mes(smes) + "/01/" + saño)))
                    {
                        PrimaSeguros = Convert.ToDecimal(rowComisionAFP[3].ToString());
                        AporteObligatorio = Convert.ToDecimal(rowComisionAFP[4].ToString());
                        RemuneracionAsegurable = Convert.ToDecimal(rowComisionAFP[5].ToString());
                        ComisionFlujo = Convert.ToDecimal(rowComisionAFP[6].ToString());
                        ComisionMixta = Convert.ToDecimal(rowComisionAFP[7].ToString());
                    }
                }
            }

            if (AFP == "") { dgvDetallePlanilla.Rows[fila].Cells[15 + con_ingresos].Value = "--"; }
            else { dgvDetallePlanilla.Rows[fila].Cells[15 + con_ingresos].Value = AFP; }
            if (TipoComision == "") { dgvDetallePlanilla.Rows[fila].Cells[16 + con_ingresos].Value = "--"; }
            else { dgvDetallePlanilla.Rows[fila].Cells[16 + con_ingresos].Value = TipoComision; }
            if (Cuspp == "") { dgvDetallePlanilla.Rows[fila].Cells[17 + con_ingresos].Value = "--"; }
            else { dgvDetallePlanilla.Rows[fila].Cells[17 + con_ingresos].Value = Cuspp; }
        }

        private void CargarIngresos(int pidtdetalleplanilla, int fila)
        {
            int celda_inicio = 14;
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
            int celda_inicio = 18;
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
            int celda_inicio = 19;
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
            int celda_inicio = 21;
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
            int DiasLaborados = 0;
            int AñoInicio = Convert.ToDateTime(dgvDetallePlanilla.Rows[fila].Cells[10].Value).Year;
            int MesInicio = Convert.ToDateTime(dgvDetallePlanilla.Rows[fila].Cells[10].Value).Month;
            int DiaInicio = Convert.ToDateTime(dgvDetallePlanilla.Rows[fila].Cells[10].Value).Day;
            int DiasMes = DateTime.DaysInMonth(Convert.ToInt32(saño), Convert.ToInt32(Mes(smes)));
            int sMes = Convert.ToInt32(Mes(smes));

            decimal PagoDia = Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells[11].Value) / 30;
            DiasLaborados = 1 + DateTime.DaysInMonth(AñoInicio, MesInicio) - DiaInicio;
            if (sidtregimenlaboral == 3 && splantilla == "PERSONAL OBRERO")
            {
                if (dgvDetallePlanilla.Rows[fila].Cells[12].Value != "")
                {
                    DiasLaborados = Convert.ToInt32(dgvDetallePlanilla.Rows[fila].Cells[12].Value);
                    PagoTotal = Math.Round(Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells[11].Value) * DiasLaborados, 0);
                }
            }
            if (sidtregimenlaboral == 2 && splantilla == "REGIDORES")
            {
                if (dgvDetallePlanilla.Rows[fila].Cells[12].Value != "")
                {
                    DiasLaborados = Convert.ToInt32(dgvDetallePlanilla.Rows[fila].Cells[12].Value);
                    PagoTotal = Math.Round(Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells[11].Value) * DiasLaborados, 0);
                }
            }
            else
            {
                if (sMes > MesInicio)
                {
                    DiasLaborados = DiasMes;
                    PagoTotal = Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells[11].Value);
                }
                else
                {
                    if (DiasLaborados == DiasMes)
                    {
                        PagoTotal = Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells[11].Value);
                    }
                    else
                    {
                        PagoTotal = Math.Round(PagoDia * DiasLaborados, 2);
                    }
                }
            }
            dgvDetallePlanilla.Rows[fila].Cells[12].Value = DiasLaborados;
            dgvDetallePlanilla.Rows[fila].Cells[13].Value = String.Format("{0:0.00}", PagoTotal);
        }

        private void CalcularIngresos(int fila)
        {
            int inicio_ingresos = 14;
            decimal total_ingresos = 0;

            for (int i = 0; i < con_ingresos; i++)
            {
                if (smingresos[i, 3].ToString() != "")//Verficamos que no tenga Formula
                {
                    dgvDetallePlanilla.Rows[fila].Cells[inicio_ingresos + i].ReadOnly = true;
                    decimal number2 = 0;
                    if (decimal.TryParse(smingresos[i, 3].ToString(), out number2) == true)//Verificamos si la formula es un Numero
                    {
                        dgvDetallePlanilla.Rows[fila].Cells[inicio_ingresos + i].Value = String.Format("{0:0.00}", number2);
                        if (smingresos[i, 17].ToString() == "0")
                        {
                            total_ingresos += decimal.Round(Convert.ToDecimal(smingresos[i, 3].ToString()), 2);
                        }
                    }
                    else
                    {
                        double result = CalcularFormula(fila, Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[13].Value), smingresos[i, 3].ToString());
                        dgvDetallePlanilla.Rows[fila].Cells[inicio_ingresos + i].Value = String.Format("{0:0.00}", result);

                        if (smingresos[i, 17].ToString() == "0")//Verificamos que la columna no sea Informativa.
                        {
                            total_ingresos += decimal.Round(Convert.ToDecimal(result), 2);
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
            int celda_inicio = 18;
            decimal total_atrabajador = 0;

            for (int i = 0; i < con_trabajador; i++)
            {
                if (sma_trabajador[i, 3].ToString() != "")
                {
                    dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + i].ReadOnly = true;
                    decimal number2 = 0;
                    if (decimal.TryParse(sma_trabajador[i, 3].ToString(), out number2) == true)
                    {
                        dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + i].Value = String.Format("{0:0.00}", number2);
                        total_atrabajador += decimal.Round(Convert.ToDecimal(sma_trabajador[i, 3].ToString()), 2);
                    }
                    else
                    {
                        double result = CalcularFormula(fila, Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[13].Value), sma_trabajador[i, 3].ToString());
                        //renta de 5ta Categoria
                        if (sma_trabajador[i, 1].ToString() == "0605")
                        {
                            dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + i].ReadOnly = true;
                            decimal renta5ta = CalculoRenta5ta(fila);
                            dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + i].Value = String.Format("{0:0.00}", renta5ta);
                            total_atrabajador += decimal.Round(Convert.ToDecimal(renta5ta), 2);
                        }
                        //renta 4ta Categoria
                        if (sma_trabajador[i, 1].ToString() == "0618" && Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[13].Value) <= 1500)
                        {
                            result = 0;
                        }
                        //
                        if (AFP == "SNP" && dgvDetallePlanilla.Columns[celda_inicio + con_ingresos + i].Name != "T9")
                        {
                            dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + i].Value = String.Format("{0:0.00}", 0);
                        }
                        else if (AFP != "SNP" && dgvDetallePlanilla.Columns[celda_inicio + con_ingresos + i].Name == "T9")
                        {
                            dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + i].Value = String.Format("{0:0.00}", 0);
                        }
                        else
                        {
                            dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + i].Value = String.Format("{0:0.00}", result);
                            total_atrabajador += decimal.Round(Convert.ToDecimal(result), 2);
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
            int celda_inicio = 19;
            decimal total_descuentos = 0;

            for (int i = 0; i < con_descuento; i++)
            {
                if (smdescuentos[i, 1].ToString() == "0605")
                {
                    dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + i].ReadOnly = true;
                    decimal renta5ta = CalculoRenta5ta(fila);
                    dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + i].Value = String.Format("{0:0.00}", renta5ta);
                    total_descuentos += decimal.Round(Convert.ToDecimal(renta5ta), 2);
                }
                else if (smdescuentos[i, 3].ToString() != "")
                {
                    dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + i].ReadOnly = true;
                    decimal number2 = 0;
                    if (decimal.TryParse(smdescuentos[i, 3].ToString(), out number2) == true)
                    {
                        dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + i].Value = String.Format("{0:0.00}", number2);
                        total_descuentos += decimal.Round(Convert.ToDecimal(smdescuentos[i, 3].ToString()), 2);
                    }
                    else
                    {
                        double result = CalcularFormula(fila, Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[13].Value), smdescuentos[i, 3].ToString());
                        //renta 4ta Categoria
                        if (smdescuentos[i, 1].ToString() == "0618" && Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[13].Value) <= 1500)
                        {
                            result = 0;
                        }
                        //
                        dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + i].Value = String.Format("{0:0.00}", result);
                        total_descuentos += decimal.Round(Convert.ToDecimal(result), 2);
                    }
                }
                else
                {
                    object xxx = dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + i].Value;
                    if (dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + i].Value == null)//Verificamos si hay datos en Datagridview
                    {
                        dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + i].Value = String.Format("{0:0.00}", 0);
                    }
                    else
                    {
                        total_descuentos += decimal.Round(Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + i].Value), 2);
                    }
                }
            }
            dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + con_descuento].Value = String.Format("{0:0.00}", total_descuentos);
        }

        private void CalcularA_Empleador(int fila)
        {
            int celda_inicio = 21;
            decimal total_aempleador = 0;

            for (int i = 0; i < con_empleador; i++)
            {
                if (sma_empleador[i, 1].ToString() == "0804")
                {
                    dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + con_descuento + i].ReadOnly = true;
                    decimal essalud = CalculoESSALUD(fila);
                    dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + con_descuento + i].Value = String.Format("{0:0.00}", essalud);
                    total_aempleador += decimal.Round(Convert.ToDecimal(essalud), 2);
                }
                else if (sma_empleador[i, 3].ToString() != "")
                {
                    dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + con_descuento + i].ReadOnly = true;
                    decimal number2 = 0;
                    if (decimal.TryParse(sma_empleador[i, 3].ToString(), out number2) == true)
                    {
                        dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + con_descuento + i].Value = String.Format("{0:0.00}", number2);
                        total_aempleador += decimal.Round(Convert.ToDecimal(sma_empleador[i, 3].ToString()), 2);
                    }
                    else
                    {
                        double result = CalcularFormula(fila, Convert.ToDouble(dgvDetallePlanilla.Rows[fila].Cells[13].Value), sma_empleador[i, 3].ToString());
                        dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + con_descuento + i].Value = String.Format("{0:0.00}", result);
                        total_aempleador += decimal.Round(Convert.ToDecimal(result), 2);
                    }
                }
                else
                {
                    object xxx = dgvDetallePlanilla.Rows[fila].Cells[celda_inicio + con_ingresos + con_trabajador + con_descuento + i].Value;
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

        private void CalcularTotalDescuentos(int fila)
        {
            decimal D = 0;
            D = Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells[18 + con_ingresos + con_trabajador].Value) + Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells[19 + con_ingresos + con_trabajador + con_descuento].Value);
            dgvDetallePlanilla.Rows[fila].Cells[20 + con_ingresos + con_trabajador + con_descuento].Value = String.Format("{0:0.00}", D);
        }

        private void CalcularNetoaCobrar(int fila)
        {
            decimal T = 0;
            T = Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells[14 + con_ingresos].Value) - Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells[20 + con_ingresos + con_trabajador + con_descuento].Value);
            dgvDetallePlanilla.Rows[fila].Cells[22 + con_ingresos + con_trabajador + con_descuento + con_empleador].Value = String.Format("{0:0.00}", T);
        }

        private decimal CalculoRenta5ta(int fila)
        {
            decimal sRenta5ta = 0;
            decimal sRemuneracion = 0;
            decimal sRemMesAnt = 0;
            int sNroMes = 0;
            decimal sGratificaciones = 0;
            decimal sRetMesAnteriores = 0;
            sRemuneracion = Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells[11].Value);
            sRemMesAnt = 0;//suma de las remuneraciones totales
            sNroMes = Convert.ToInt32(Mes(smes));
            sGratificaciones = 600;
            sRetMesAnteriores = 0;
            CapaDeNegocios.Planillas.cCalculo5taCategoria miCalculo5ta = new CapaDeNegocios.Planillas.cCalculo5taCategoria();
            sRenta5ta = miCalculo5ta.CalculoRentaMensual(sRemuneracion, sRemMesAnt, sNroMes, sGratificaciones, sUIT, sRetMesAnteriores);
            return sRenta5ta;
        }

        private decimal CalculoESSALUD(int fila)
        {
            decimal sEssalud = 0;
            decimal sRemuneracion = 0;
            sRemuneracion = Convert.ToDecimal(dgvDetallePlanilla.Rows[fila].Cells[13].Value);
            if (txtRegimenLaboral.Text == "REGIMEN CAS 1057")
            {
                if (sRemuneracion <= sRemuneracionBasica)
                {
                    sEssalud = sRemuneracionBasica * 9 / 100;
                }
                else if (sRemuneracion >= sRemuneracionBasica && sRemuneracion <= sUIT * 30 / 100)
                {
                    sEssalud = sRemuneracion * 9 / 100;
                }
                else
                {
                    sEssalud = (sUIT * 30 / 100) * 9 / 100;
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

        double CalcularFormula(int fila, double remuneracion, string formula)
        {
            DatosAFP(fila);
            ExpressionParser parser = new ExpressionParser();
            DoubleValue sval = new DoubleValue();
            DoubleValue aoval = new DoubleValue();
            DoubleValue cval = new DoubleValue();
            DoubleValue psval = new DoubleValue();
            parser.Values.Add("s", sval);
            parser.Values.Add("ao", aoval);
            parser.Values.Add("c", cval);
            parser.Values.Add("ps", psval);

            sval.Value = remuneracion;
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
                sDieta = Convert.ToDecimal(rowvariables[4].ToString());
            }
        }

        private void DibujarDataGrid()
        {
            string abrev_ingresos = ""; string abrev_descuentos = ""; string abrev_atrabajador = ""; string abrev_aempleador = "";
            string id_ingresos = ""; string id_descuentos = ""; string id_atrabajador = ""; string id_aempleador = "";
            int j = dgvDetallePlanilla.ColumnCount;
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();

            DataTable oDataPlantillaPlanilla = new DataTable();
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

            // AFP
            col = new DataGridViewTextBoxColumn();
            col.Name = "AFP";
            col.HeaderText = "AFP";
            dgvDetallePlanilla.Columns.Add(col);
            dgvDetallePlanilla.Columns["AFP"].ReadOnly = true;
            dgvDetallePlanilla.Columns["AFP"].Width = 80;
            dgvDetallePlanilla.Columns["AFP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // TipoComision
            col = new DataGridViewTextBoxColumn();
            col.Name = "TipoComision";
            col.HeaderText = "TIPO COMISION";
            dgvDetallePlanilla.Columns.Add(col);
            dgvDetallePlanilla.Columns["TipoComision"].ReadOnly = true;
            dgvDetallePlanilla.Columns["TipoComision"].Width = 50;
            dgvDetallePlanilla.Columns["TipoComision"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // Cuspp
            col = new DataGridViewTextBoxColumn();
            col.Name = "Cuspp";
            col.HeaderText = "Cuspp";
            dgvDetallePlanilla.Columns.Add(col);
            dgvDetallePlanilla.Columns["Cuspp"].ReadOnly = true;
            dgvDetallePlanilla.Columns["Cuspp"].Width = 90;
            dgvDetallePlanilla.Columns["Cuspp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            col.HeaderText = "TOTAL DESC. AFP/SNP";
            dgvDetallePlanilla.Columns.Add(col);
            dgvDetallePlanilla.Columns["SUMA_A_TRABAJADOR"].ReadOnly = true;
            dgvDetallePlanilla.Columns["SUMA_A_TRABAJADOR"].Width = 50;
            dgvDetallePlanilla.Columns["SUMA_A_TRABAJADOR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            smdescuentos = new string[oDataPlantillaPlanilla.Rows.Count, 4];
            foreach (DataRow row in oDataPlantillaPlanilla.Select("tipo='DESCUENTOS'"))
            {
                foreach (DataRow rowmdescuentos in oDataMaestroDescuentos.Select("idtmaestrodescuentos = '" + row[4].ToString() + "'"))
                {
                    smdescuentos[con_descuento, 0] = rowmdescuentos[0].ToString();
                    id_descuentos = rowmdescuentos[0].ToString();
                    smdescuentos[con_descuento, 1] = rowmdescuentos[1].ToString();
                    smdescuentos[con_descuento, 2] = rowmdescuentos[2].ToString();
                    smdescuentos[con_descuento, 3] = rowmdescuentos[3].ToString();
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
        }

        private void MostrarColumnas()
        {
            dgvDetallePlanilla.Columns[11].Visible = false;
            dgvDetallePlanilla.Columns[13].Visible = false;
            dgvDetallePlanilla.Columns["SUMA_DESCUENTOS"].Visible = false;
            dgvDetallePlanilla.Columns["TOTAL_A_EMPLEADOR"].Visible = false;
            if (splantilla == "CESANTES")
            {
                dgvDetallePlanilla.Columns[7].Visible = false;
                dgvDetallePlanilla.Columns[9].Visible = false;
                dgvDetallePlanilla.Columns[10].Visible = false;
                dgvDetallePlanilla.Columns[12].Visible = false;
                dgvDetallePlanilla.Columns["AFP"].Visible = false;
                dgvDetallePlanilla.Columns["TipoComision"].Visible = false;
                dgvDetallePlanilla.Columns["Cuspp"].Visible = false;
                dgvDetallePlanilla.Columns["SUMA_A_TRABAJADOR"].Visible = false;
            }
            if (splantilla == "REGIDORES")
            {
                dgvDetallePlanilla.Columns[11].Visible = true;
                dgvDetallePlanilla.Columns[11].HeaderText = "DIETA POR SESION";
                dgvDetallePlanilla.Columns[12].HeaderText = "SESION ASISTIDA";
                dgvDetallePlanilla.Columns[12].ReadOnly = false;

                dgvDetallePlanilla.Columns[9].Visible = false;
                dgvDetallePlanilla.Columns[10].Visible = false;
                dgvDetallePlanilla.Columns["AFP"].Visible = false;
                dgvDetallePlanilla.Columns["TipoComision"].Visible = false;
                dgvDetallePlanilla.Columns["Cuspp"].Visible = false;
                dgvDetallePlanilla.Columns["SUMA_A_TRABAJADOR"].Visible = false;
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
                case "SEPTIEMBRE":
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
