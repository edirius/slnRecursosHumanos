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
    public partial class frmMantenimientoDetallePlanilla : Form
    {
        int con_ingresos = 0, con_descuento = 0, con_trabajador = 0, con_empleador = 0;
        int contador = 0;
        int sidtplanilla;
        int sidtregimenlaboral;
        int sidtmeta;
        string smes = "";
        string saño = "";
        public string[,] sselecciontrabajadores;
        string[,] smingresos;
        string[,] smdescuentos;
        string[,] sma_trabajador;
        string[,] sma_empleador;
        int sfilasselecciontrabajadores;

        DataTable oDataTrabajador = new DataTable();
        DataTable oDataPeriodoTrabajador = new DataTable();
        DataTable oDataRegimenTrabajador = new DataTable();
        DataTable oDataRegimenPensionarioTrabajador = new DataTable();
        DataTable oDataRegimenSaludTrabajador = new DataTable();
        DataTable oDataCargo = new DataTable();
        DataTable oDataAFP = new DataTable();

        CapaDeNegocios.cTrabajador miTrabajador = new CapaDeNegocios.cTrabajador();
        CapaDeNegocios.DatosLaborales.cPeriodoTrabajador miPeriodoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
        CapaDeNegocios.DatosLaborales.cRegimenTrabajador miRegimenTrabajor = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
        CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador miRegimenPensionarioTrabajor = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();
        CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador miRegimenSaludTrajador = new CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador();
        CapaDeNegocios.Contrato.cCargo miCargo = new CapaDeNegocios.Contrato.cCargo();
        CapaDeNegocios.cListaAFP miAFP = new CapaDeNegocios.cListaAFP();

        public frmMantenimientoDetallePlanilla()
        {
            InitializeComponent();
        }

        private void frmMantenimientoDetallePlanilla_Load(object sender, EventArgs e)
        {
            DibujarDataGrid();
            oDataTrabajador = miTrabajador.ObtenerListaTrabajadores(true);
            oDataPeriodoTrabajador = miPeriodoTrabajador.ListarPeriodoTrabajador(0);
            oDataRegimenTrabajador = miRegimenTrabajor.ListarRegimenTrabajador(0);
            oDataRegimenPensionarioTrabajador = miRegimenPensionarioTrabajor.ListarRegimenPensionarioTrabajador(0);
            oDataRegimenSaludTrabajador = miRegimenSaludTrajador.ListarRegimenSaludTrabajador(0);
            oDataCargo = miCargo.ListaCargos();
            oDataAFP = miAFP.ObtenerListaAFP();
            CargarDatos();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            //int contador = 0;
            //dgvDetallePlanilla.Rows.Clear();

            //oDataRegimenTrabajador = miRegimenTrabajor.ListarRegimenTrabajador(0);
            //oDataPeriodoTrabajador = miPeriodoTrabajador.ListarPeriodoTrabajador(0);
            //oDataTrabajador = miTrabajador.ObtenerListaTrabajadores(true);

            //foreach (DataRow rowRegimenTrabajador in oDataRegimenTrabajador.Select("idtregimenlaboral = '" + sidtregimenlaboral + "' and fechainicio <= '" + saño + "" + smes + "31' and (fechafin >= '" + saño + "" + smes + "01' or fechafin>='')", "idtcargo"))
            //{
            //    string x = rowRegimenTrabajador[0].ToString();
            //    foreach (DataRow rowPeriodoTrabajador in oDataPeriodoTrabajador.Select("idtperiodotrabajador = '" + rowRegimenTrabajador[17].ToString() + "'"))
            //    {
            //        foreach (DataRow rowTrabajador in oDataTrabajador.Select("id_trabajador = '" + rowPeriodoTrabajador[4].ToString() + "'"))
            //        {
            //            contador += 1;
            //            dgvDetallePlanilla.Rows.Add("", "", "", contador, rowTrabajador[0].ToString(), rowTrabajador[2].ToString() + " " + rowTrabajador[3].ToString() + " " + rowTrabajador[4].ToString(), "", rowTrabajador[1].ToString(), rowRegimenTrabajador[6].ToString(), rowPeriodoTrabajador[1].ToString());
            //        }
            //    }
            //}

            //btnImportar.Enabled = false;
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
                    }
                    else
                    {
                        MessageBox.Show("El trabajador ya se encuentra en la planilla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public void RecibirDatos(int pidtplanilla, string pnumero, string pmes, string paño, int pidtmeta, string pmeta, int pidtfuentefinanciamiento, string pfuentefinanciamiento, int pidtregimenlaboral, string pregimenlaboral)
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
        }

        private void CargarDatos()
        {
            int contador = 0, contadordias = 0;
            int fila = 0;
            int j, k = 0;
            string r = "";
            string diastareo = "";
            dgvDetallePlanilla.Rows.Clear();

            //DataTable oDataDetalleTareo = new DataTable();
            //oDataDetalleTareo = miDetalleTareo.ListarDetalleTareo(miTareo);
            //foreach (DataRow row in oDataDetalleTareo.Rows)
            //{
            //    //contador += 1;
            //    //dgvDetalleTareo.Rows.Add();
            //    //fila = dgvDetalleTareo.RowCount - 1;
            //    //dgvDetalleTareo.Rows[fila].Cells[0].Value = row[0].ToString();
            //    //dgvDetalleTareo.Rows[fila].Cells[1].Value = "M";
            //    //dgvDetalleTareo.Rows[fila].Cells[3].Value = contador;
            //    //dgvDetalleTareo.Rows[fila].Cells[8].Value = row[1].ToString();
            //    //foreach (DataRow row1 in oDataTrabajador.Select("id_trabajador = '" + row[3].ToString() + "'"))
            //    //{
            //    //    dgvDetalleTareo.Rows[fila].Cells[4].Value = row1[0].ToString();
            //    //    dgvDetalleTareo.Rows[fila].Cells[5].Value = row1[3].ToString() + " " + row1[4].ToString() + ", " + row1[2].ToString();
            //    //    dgvDetalleTareo.Rows[fila].Cells[6].Value = row1[1].ToString();
            //    //    foreach (DataRow row2 in oDataAFP.Select("idtafp = '1'"))
            //    //    {
            //    //        dgvDetalleTareo.Rows[fila].Cells[7].Value = row2[1].ToString();
            //    //    }
            //    //}
            //    ////miDetalleTareo.IdTDetalleTareo = Convert.ToInt32(row[0]);
            //    ////CargarDiasTareo(fila);
            //    //j = 0;
            //    //contadordias = 0;
            //    //diastareo = row[2].ToString();
            //    ////if ((miTareo.FechaFin.Day - miTareo.FechaInicio.Day) > diastareo.Count()) { k = diastareo.Count() - 1; }
            //    ////else { k = (miTareo.FechaFin.Day - miTareo.FechaInicio.Day); }
            //    //for (int i = 1; i <= 31; i++)
            //    //{
            //    //    r = diastareo.Substring(i - 1, 1);
            //    //    if (i >= miTareo.FechaInicio.Day && i <= miTareo.FechaFin.Day)
            //    //    {
            //    //        dgvDetalleTareo.Rows[fila].Cells[9 + i - contadordias].Value = r;
            //    //        if (r == "x") { j += 1; }
            //    //        auxiliar = miTareo.FechaInicio.AddDays(i - contadordias - 1);
            //    //        if (auxiliar.DayOfWeek == DayOfWeek.Sunday)
            //    //        {
            //    //            int K = 0;
            //    //            k = i - contadordias - 1;
            //    //            dgvDetalleTareo.Rows[fila].Cells["col" + k.ToString()].Style.BackColor = Color.Red;
            //    //            dgvDetalleTareo.Rows[fila].Cells[9 + i - contadordias].Value = "D";
            //    //        }
            //    //    }
            //    //    else
            //    //    {
            //    //        contadordias += 1;
            //    //    }
            //    //}
            //    //dgvDetalleTareo.Rows[fila].Cells[dgvDetalleTareo.ColumnCount - 1].Value = j;
            //    //dgvDetalleTareo.CurrentCell = dgvDetalleTareo.CurrentRow.Cells[6];
            //}
            //if (contador == 0)
            //{
            //    dgvDetallePlanilla.Rows.Add();
            //    dgvDetallePlanilla.CurrentCell = dgvDetallePlanilla.CurrentRow.Cells[7];
            //    btnImportar.Enabled = true;
            //}
            //else
            //{
            //    btnImportar.Enabled = false;
            //}
        }

        private void CargarTrabajador(int pidtrabajador)
        {
            string Nombre = "";
            string DNI = "";
            string FechaInicio = "";
            string MontoPago = "";
            string Cargo = "";
            string AFP = "";
            string Cuspp = "";
            string TipoComision = "";
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
                            Cargo = rowCargo[1].ToString();
                        }
                    }
                    foreach (DataRow rowRegimenPensionarioTrabajador in oDataRegimenPensionarioTrabajador.Select("idtperiodotrabajador = '" + Convert.ToInt32(rowPeriodoTrabajador[0].ToString()) + "'"))
                    {
                        Cuspp = rowRegimenPensionarioTrabajador[3].ToString();
                        TipoComision  = rowRegimenPensionarioTrabajador[4].ToString();
                        foreach (DataRow rowAFP in oDataAFP.Select("idtafp = '" + Convert.ToInt32(rowRegimenPensionarioTrabajador[5].ToString()) + "'"))
                        {
                            AFP = rowAFP[1].ToString();
                        }
                    }
                    contador += 1;
                    dgvDetallePlanilla.Rows.Add("", "", "", contador, pidtrabajador, Nombre, Cargo, DNI, MontoPago, FechaInicio, sidtmeta, AFP, TipoComision, Cuspp);
                }
                CalcularIngresos();
            }
        }

        private void DibujarDataGrid()
        {
            int j = dgvDetallePlanilla.ColumnCount;
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();

            DataTable oDataPlantillaPlanilla = new DataTable();
            CapaDeNegocios.Planillas.cPlantillaPlanilla miPlantillaPlanilla = new CapaDeNegocios.Planillas.cPlantillaPlanilla();
            oDataPlantillaPlanilla = miPlantillaPlanilla.ListarPlantillaPlanilla(sidtregimenlaboral);

            DataTable oDataMaestroIngresos = new DataTable();
            CapaDeNegocios.Sunat.cMaestroIngresos miMaestroIngresos = new CapaDeNegocios.Sunat.cMaestroIngresos();
            oDataMaestroIngresos = miMaestroIngresos.ListarMaestroIngresos("");

            smingresos = new string[oDataPlantillaPlanilla.Rows.Count, 4];
            foreach (DataRow row in oDataPlantillaPlanilla.Select("tipo='INGRESOS'"))
            {
                foreach (DataRow rowmingresos in oDataMaestroIngresos.Select("idtmaestroingresos = '" + row[2].ToString() + "'"))
                {
                    smingresos[con_ingresos, 0] = rowmingresos[0].ToString();
                    smingresos[con_ingresos, 1] = rowmingresos[1].ToString();
                    smingresos[con_ingresos, 2] = rowmingresos[1].ToString();
                    smingresos[con_ingresos, 3] = rowmingresos[15].ToString();
                }

                con_ingresos += 1;
                col = new DataGridViewTextBoxColumn();
                col.Name = "I" + con_ingresos;
                col.HeaderText = row[1].ToString();
                dgvDetallePlanilla.Columns.Add(col);
                //dgvDetallePlanilla.Columns["I" + con_ingresos].DisplayIndex = 10 + con_ingresos;
                dgvDetallePlanilla.Columns["I" + con_ingresos].Width = 65;
            }
            col = new DataGridViewTextBoxColumn();
            col.Name = "TOTAL_INGRESOS";
            col.HeaderText = "TOTAL REMUNER.";
            dgvDetallePlanilla.Columns.Add(col);
            //dgvDetallePlanilla.Columns["TOTAL_INGRESOS"].DisplayIndex = 10 + con_ingresos;
            dgvDetallePlanilla.Columns["TOTAL_INGRESOS"].ReadOnly = true;
            dgvDetallePlanilla.Columns["TOTAL_INGRESOS"].Width = 65;

            //foreach (DataRow row in oDataPLantillaPlanilla.Select("tipo='A_TRABAJADOR'"))
            //{
            //    con_ingresos += 1;
            //    col = new DataGridViewTextBoxColumn();
            //    //col.Name = "I" + I_FIN;
            //    col.HeaderText = row[1].ToString();
            //    dgvDetallePlanilla.Columns.Add(col);
            //    //dgvDetallePlanilla.Columns["I" + I_FIN].DisplayIndex = 10 + I_FIN;
            //}
            //con_ingresos += 1;
            //col = new DataGridViewTextBoxColumn();
            //col.HeaderText = "TOTAL DESC. AFP/SNP";
            //dgvDetallePlanilla.Columns.Add(col);
            //foreach (DataRow row in oDataPLantillaPlanilla.Select("tipo='DESCUENTOS'"))
            //{
            //    con_ingresos += 1;
            //    col = new DataGridViewTextBoxColumn();
            //    //col.Name = "I" + I_FIN;
            //    col.HeaderText = row[1].ToString();
            //    dgvDetallePlanilla.Columns.Add(col);
            //    //dgvDetallePlanilla.Columns["I" + I_FIN].DisplayIndex = 10 + I_FIN;
            //}
            //con_ingresos += 1;
            //col = new DataGridViewTextBoxColumn();
            //col.HeaderText = "TOTAL DESCUENTO";
            //dgvDetallePlanilla.Columns.Add(col);
            //foreach (DataRow row in oDataPLantillaPlanilla.Select("tipo='A_EMPLEADOR'"))
            //{
            //    con_ingresos += 1;
            //    col = new DataGridViewTextBoxColumn();
            //    //col.Name = "I" + I_FIN;
            //    col.HeaderText = row[1].ToString();
            //    dgvDetallePlanilla.Columns.Add(col);
            //    //dgvDetallePlanilla.Columns["I" + I_FIN].DisplayIndex = 10 + I_FIN;
            //}
            //con_ingresos += 1;
            //col = new DataGridViewTextBoxColumn();
            //col.HeaderText = "TOTAL REMUNER.";
            //dgvDetallePlanilla.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.Name = "NETOACOBRAR";
            col.HeaderText = "NETO A COBRAR";
            dgvDetallePlanilla.Columns.Add(col);
            dgvDetallePlanilla.Columns["NETOACOBRAR"].ReadOnly = true;
            dgvDetallePlanilla.Columns["NETOACOBRAR"].Width = 65;
            col = new DataGridViewTextBoxColumn();
            col.Name = "DIASLABORADOS";
            col.HeaderText = "DIAS LABORADOS";
            dgvDetallePlanilla.Columns.Add(col);
            dgvDetallePlanilla.Columns["DIASLABORADOS"].ReadOnly = true;
            dgvDetallePlanilla.Columns["DIASLABORADOS"].Width = 65;
        }

        private void CalcularIngresos()
        {
            int total_ingresos = 0;
            double PagoDia = Math.Round(Convert.ToDouble(dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[8].Value) / 30, 2);
            int DiasLaborados = 1 + DateTime.DaysInMonth(Convert.ToDateTime(dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[9].Value).Year, Convert.ToDateTime(dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[9].Value).Month) - Convert.ToDateTime(dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[9].Value).Day;

            for (int i = 0; i < con_ingresos; i++)
            {
                if (smingresos[i, 3].ToString() != "")
                {
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[14 + i].ReadOnly = true;
                    int number2 = 0;
                    if (int.TryParse(smingresos[i, 3].ToString(), out number2) == true)
                    {
                        dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[14 + i].Value = smingresos[i, 3].ToString();
                        total_ingresos += Convert.ToInt32(smingresos[i, 3].ToString());
                    }
                }
            }

            dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[14 + con_ingresos].Value = Math.Round(PagoDia * DiasLaborados, 0) + total_ingresos;
            dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[15 + con_ingresos].Value = dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[14 + con_ingresos].Value;
            dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[16 + con_ingresos].Value = DiasLaborados;
        }
    }
}
