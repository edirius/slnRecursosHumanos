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
    public partial class frmMantenimientoDetallePlanilla : Form
    {
        int con_ingresos = 0, con_trabajador = 0, con_descuento = 0, con_empleador = 0;
        int contador = 0;
        int sidtplanilla;
        int sidtregimenlaboral;
        int sidtmeta;
        string smes = "";
        string saño = "";
        public string[,] sselecciontrabajadores;
        string[,] smingresos;
        string[,] sma_trabajador;
        string[,] smdescuentos;
        string[,] sma_empleador;
        int sfilasselecciontrabajadores;

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
                        TotalRemuneracion();
                        CalcularIngresos(AFP, TipoComision, Cuspp, PrimaSeguros, AporteObligatorio, RemuneracionAsegurable, ComisionFlujo, ComisionMixta);
                        CalcularA_Trabajador(AFP, TipoComision, Cuspp, PrimaSeguros, AporteObligatorio, RemuneracionAsegurable, ComisionFlujo, ComisionMixta);
                        CalcularDescuentos(AFP, TipoComision, Cuspp, PrimaSeguros, AporteObligatorio, RemuneracionAsegurable, ComisionFlujo, ComisionMixta);
                        CalcularA_Empleador(AFP, TipoComision, Cuspp, PrimaSeguros, AporteObligatorio, RemuneracionAsegurable, ComisionFlujo, ComisionMixta);
                        CalcularNetoaCobrar();
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
            bool bOk = false;
            foreach (DataGridViewRow row in dgvDetallePlanilla.Rows)
            {
                miDetallePlanilla.IdtDetallePlanilla = Convert.ToInt32(row.Cells[0].Value);
                miDetallePlanilla.Remuneracion = Convert.ToDecimal(row.Cells[9].Value);
                miDetallePlanilla.FechaInicio = Convert.ToDateTime(row.Cells[10].Value);
                miDetallePlanilla.DiasLaborados = Convert.ToInt32(row.Cells[11].Value);
                miDetallePlanilla.RemuneracionTotal = Convert.ToDecimal(row.Cells[12].Value);
                miDetallePlanilla.TotalIngresos = Convert.ToDecimal(row.Cells[13 + con_ingresos].Value);
                miDetallePlanilla.TotalATrabajador = Convert.ToDecimal(row.Cells[16 + con_ingresos + con_trabajador].Value);
                miDetallePlanilla.TotalDescuentos = Convert.ToDecimal(row.Cells[16 + con_ingresos + con_trabajador + con_descuento].Value);
                miDetallePlanilla.TotalAEmpleador = Convert.ToDecimal(row.Cells[16 + con_ingresos + con_trabajador + con_empleador].Value);
                miDetallePlanilla.IdtCargo = Convert.ToInt32(row.Cells[6].Value);
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
                    for (int i = 0; i < con_ingresos - 1; i++)
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
                    for (int i = 0; i < con_trabajador - 1; i++)
                    {
                        string z = dgvDetallePlanilla.Columns[17 + con_ingresos + i].Name.ToString();
                        int x = dgvDetallePlanilla.Columns[17 + con_ingresos + i].Name.Length;
                        int y = Convert.ToInt32(dgvDetallePlanilla.Columns[17 + con_ingresos + i].Name.Substring(1, x - 1));
                        miDetallePlanillaATrabajador.IdtDetallePlanillaATrabajador = 0;
                        miDetallePlanillaATrabajador.Monto = Convert.ToDecimal(row.Cells[17 + con_ingresos + i].Value);
                        miDetallePlanillaATrabajador.IdtMaestroATrabajador = y;
                        miDetallePlanillaATrabajador.IdtDetallePlanilla = Convert.ToInt32(row.Cells[0].Value);
                        miDetallePlanillaATrabajador.CrearDetallePlanillaATrabajador(miDetallePlanillaATrabajador);
                    }
                }
                if (con_descuento > 0)
                {
                    for (int i = 0; i < con_descuento - 1; i++)
                    {
                        string z = dgvDetallePlanilla.Columns[17 + con_ingresos + con_trabajador + i].Name.ToString();
                        int x = dgvDetallePlanilla.Columns[17 + con_ingresos + con_trabajador + i].Name.Length;
                        int y = Convert.ToInt32(dgvDetallePlanilla.Columns[17 + con_ingresos + con_trabajador + i].Name.Substring(1, x - 1));
                        miDetallePlanillaDescuentos.IdtDetallePlanillaDescuentos = 0;
                        miDetallePlanillaDescuentos.Monto = Convert.ToDecimal(row.Cells[17 + con_ingresos + con_trabajador + i].Value);
                        miDetallePlanillaDescuentos.IdtMaestroDescuentos = y;
                        miDetallePlanillaDescuentos.IdtDetallePlanilla = Convert.ToInt32(row.Cells[0].Value);
                        miDetallePlanillaDescuentos.CrearDetallePlanillaDescuentos(miDetallePlanillaDescuentos);
                    }
                }
                if (con_empleador > 0)
                {
                    for (int i = 0; i < con_empleador - 1; i++)
                    {
                        string z = dgvDetallePlanilla.Columns[17 + con_ingresos + con_trabajador + con_descuento + i].Name.ToString();
                        int x = dgvDetallePlanilla.Columns[17 + con_ingresos + con_trabajador + con_descuento + i].Name.Length;
                        int y = Convert.ToInt32(dgvDetallePlanilla.Columns[17 + con_ingresos + con_trabajador + con_descuento + i].Name.Substring(1, x - 1));
                        miDetallePlanillaAEmpleador.IdtDetallePlanillaAEmpleador = 0;
                        miDetallePlanillaAEmpleador.Monto = Convert.ToDecimal(row.Cells[17 + con_ingresos + con_trabajador + con_descuento + i].Value);
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

            string x = dgvDetallePlanilla.Columns[e.ColumnIndex].Name.Substring(0, 1);
            string y = dgvDetallePlanilla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            decimal z = 0;

            decimal number2 = 0;
            if (decimal.TryParse(y, out number2) != true)
            {
                dgvDetallePlanilla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = String.Format("{0:0.00}", 0);
                return;
            }

            dgvDetallePlanilla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = String.Format("{0:0.00}", Convert.ToDecimal(y));
            if (x == "I")
            {
                for (int i = 0; i < con_ingresos - 1; i++)
                {
                    z += Convert.ToDecimal(dgvDetallePlanilla.Rows[e.RowIndex].Cells[14 + i].Value);
                }
                dgvDetallePlanilla.Rows[e.RowIndex].Cells[13 + con_ingresos].Value = String.Format("{0:0.00}", z);
            }

            if (x == "T")
            {
                for (int i = 0; i < con_trabajador - 1; i++)
                {
                    z += Convert.ToDecimal(dgvDetallePlanilla.Rows[e.RowIndex].Cells[17 + con_ingresos + i].Value);
                }
                dgvDetallePlanilla.Rows[e.RowIndex].Cells[16 + con_ingresos + con_trabajador].Value = String.Format("{0:0.00}", z);
            }

            if (x == "D" || x == "T")
            {
                z = 0;
                for (int i = 0; i < con_descuento - 1; i++)
                {
                    z += Convert.ToDecimal(dgvDetallePlanilla.Rows[e.RowIndex].Cells[17 + con_ingresos + con_trabajador + i].Value);
                }
                dgvDetallePlanilla.Rows[e.RowIndex].Cells[16 + con_ingresos + con_trabajador + con_descuento].Value = String.Format("{0:0.00}", z + Convert.ToDecimal(dgvDetallePlanilla.Rows[e.RowIndex].Cells[16 + con_ingresos + con_trabajador].Value));
            }

            if (x == "E")
            {
                for (int i = 0; i < con_empleador - 1; i++)
                {
                    z += Convert.ToDecimal(dgvDetallePlanilla.Rows[e.RowIndex].Cells[17 + con_ingresos + con_trabajador + con_descuento + i].Value);
                }
                dgvDetallePlanilla.Rows[e.RowIndex].Cells[16 + con_ingresos + con_trabajador + con_descuento + con_empleador].Value = String.Format("{0:0.00}", z);
            }

            //Neto a Cobrar
            decimal T = 0;
            if (con_ingresos == 0)
            {
                T = Convert.ToDecimal(dgvDetallePlanilla.Rows[e.RowIndex].Cells[12].Value) - Convert.ToDecimal(dgvDetallePlanilla.Rows[e.RowIndex].Cells[16 + con_ingresos + con_trabajador + con_descuento].Value);
                dgvDetallePlanilla.Rows[e.RowIndex].Cells[16 + con_ingresos + con_trabajador + con_descuento + con_empleador].Value = String.Format("{0:0.00}", T);
            }
            else
            {
                T = Convert.ToDecimal(dgvDetallePlanilla.Rows[e.RowIndex].Cells[12].Value) + Convert.ToDecimal(dgvDetallePlanilla.Rows[e.RowIndex].Cells[13 + con_ingresos].Value) - Convert.ToDecimal(dgvDetallePlanilla.Rows[e.RowIndex].Cells[16 + con_ingresos + con_trabajador + con_descuento].Value);
                dgvDetallePlanilla.Rows[e.RowIndex].Cells[16 + con_ingresos + con_trabajador + con_descuento + con_empleador].Value = String.Format("{0:0.00}", T);
            }
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
            contador = 0;
            dgvDetallePlanilla.Rows.Clear();

            oDataDetallePlanilla = miDetallePlanilla.ListarDetallePlanilla(sidtplanilla);
            foreach (DataRow row in oDataDetallePlanilla.Rows)
            {
                CargarTrabajador(Convert.ToInt32(row[10].ToString()));
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells[0].Value = row[0].ToString();
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells[1].Value = "M";
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells[9].Value = row[1].ToString();
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells[10].Value = row[2].ToString();
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells[11].Value = row[3].ToString();

                //dgvDetallePlanilla.Rows[dgvDetallePlanilla.RowCount - 1].Cells[7].Value = row[1].ToString();
                TotalRemuneracion();
                CalcularIngresos(AFP, TipoComision, Cuspp, PrimaSeguros, AporteObligatorio, RemuneracionAsegurable, ComisionFlujo, ComisionMixta);
                CalcularA_Trabajador(AFP, TipoComision, Cuspp, PrimaSeguros, AporteObligatorio, RemuneracionAsegurable, ComisionFlujo, ComisionMixta);
                CalcularDescuentos(AFP, TipoComision, Cuspp, PrimaSeguros, AporteObligatorio, RemuneracionAsegurable, ComisionFlujo, ComisionMixta);
                CalcularA_Empleador(AFP, TipoComision, Cuspp, PrimaSeguros, AporteObligatorio, RemuneracionAsegurable, ComisionFlujo, ComisionMixta);
                CalcularNetoaCobrar();
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
                    foreach (DataRow rowRegimenPensionarioTrabajador in oDataRegimenPensionarioTrabajador.Select("idtperiodotrabajador = '" + Convert.ToInt32(rowPeriodoTrabajador[0].ToString()) + "'"))
                    {
                        Cuspp = rowRegimenPensionarioTrabajador[3].ToString();
                        TipoComision = rowRegimenPensionarioTrabajador[4].ToString();
                        foreach (DataRow rowAFP in oDataAFP.Select("idtafp = '" + Convert.ToInt32(rowRegimenPensionarioTrabajador[5].ToString()) + "'"))
                        {
                            AFP = rowAFP[1].ToString();
                        }
                        oDataComisionAFP = miComisionAFP.ListarComisionAFP(Convert.ToInt32(rowRegimenPensionarioTrabajador[5].ToString()));
                        foreach (DataRow rowComisionAFP in oDataComisionAFP.Select(string.Format("mes=#{0:MM/dd/yyyy}#", "" + Mes(smes) + "/01/" + saño)))
                        {
                            //string xxx = rowComisionAFP[2].ToString();
                            PrimaSeguros = Convert.ToDecimal(rowComisionAFP[3].ToString());
                            AporteObligatorio = Convert.ToDecimal(rowComisionAFP[4].ToString());
                            RemuneracionAsegurable = Convert.ToDecimal(rowComisionAFP[5].ToString());
                            ComisionFlujo = Convert.ToDecimal(rowComisionAFP[6].ToString());
                            ComisionMixta = Convert.ToDecimal(rowComisionAFP[7].ToString());
                        }
                    }
                    contador += 1;
                    dgvDetallePlanilla.Rows.Add("0", "I", "", contador, pidtrabajador, Nombre, IdtCargo, Cargo, DNI, MontoPago, FechaInicio, "", "", sidtmeta);
                }
            }
        }

        private void TotalRemuneracion()
        {
            decimal PagoDia = Math.Round(Convert.ToDecimal(dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[9].Value) / 30, 2);
            int AñoInicio = Convert.ToDateTime(dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[10].Value).Year;
            int MesInicio = Convert.ToDateTime(dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[10].Value).Month;
            int DiaInicio = Convert.ToDateTime(dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[10].Value).Day;
            int DiasLaborados = 0;
            decimal PagoTotal = 0;
            if (MesInicio < Convert.ToInt32(Mes(smes)))
            {
                DiasLaborados = DateTime.DaysInMonth(Convert.ToInt32(saño), Convert.ToInt32(Mes(smes)));
                PagoTotal = Math.Round(PagoDia * 30, 0);
            }
            else
            {
                DiasLaborados = 1 + DateTime.DaysInMonth(AñoInicio, MesInicio) - DiaInicio;
                PagoTotal = Math.Round(PagoDia * DiasLaborados, 0);
            }
            dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[11].Value = DiasLaborados;
            dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[12].Value = String.Format("{0:0.00}", PagoTotal);
        }

        private void CalcularIngresos(string AFP, string TipoComision, string Cuspp, decimal PrimaSeguros, decimal AporteObligatorio, decimal RemuneracionAsegurable, decimal ComisionFlujo, decimal ComisionMixta)
        {
            decimal total_ingresos = 0;

            for (int i = 0; i < con_ingresos - 1; i++)
            {
                dgvDetallePlanilla.Columns[14 + i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (smingresos[i, 3].ToString() != "")
                {
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[14 + i].ReadOnly = true;
                    //decimal xxx = Convert.ToDecimal(smingresos[i, 3].ToString());
                    decimal number2 = 0;
                    if (decimal.TryParse(smingresos[i, 3].ToString(), out number2) == true)
                    {
                        dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[14 + i].Value = String.Format("{0:0.00}", number2);
                        total_ingresos += decimal.Round(Convert.ToDecimal(smingresos[i, 3].ToString()), 2);
                    }
                    else
                    {
                        ExpressionParser parser = new ExpressionParser();
                        DoubleValue sval = new DoubleValue();
                        DoubleValue aoval = new DoubleValue();
                        DoubleValue cval = new DoubleValue();
                        DoubleValue psval = new DoubleValue();
                        parser.Values.Add("s", sval);
                        parser.Values.Add("ao", aoval);
                        parser.Values.Add("c", cval);
                        parser.Values.Add("ps", psval);

                        sval.Value = Convert.ToDouble(dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[12].Value);
                        aoval.Value = Convert.ToDouble(AporteObligatorio / 100);
                        psval.Value = Convert.ToDouble(PrimaSeguros / 100);
                        if (TipoComision == "FLUJO")
                        { cval.Value = Convert.ToDouble(ComisionFlujo / 100); }
                        else if ((TipoComision == "MIXTA"))
                        { cval.Value = Convert.ToDouble(ComisionMixta / 100); }

                        string formula = smingresos[i, 3].ToString();
                        double result = parser.Parse(formula);
                        dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[14 + i].Value = String.Format("{0:0.00}", result);
                        total_ingresos += decimal.Round(Convert.ToDecimal(result), 2);
                    }
                }
                else
                {
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[14 + i].Value = String.Format("{0:0.00}", 0);
                }
            }
            if (con_ingresos != 0)
            {
                dgvDetallePlanilla.Columns[13 + con_ingresos].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[13 + con_ingresos].Value = String.Format("{0:0.00}", total_ingresos);
            }
        }

        private void CalcularA_Trabajador(string AFP, string TipoComision, string Cuspp, decimal PrimaSeguros, decimal AporteObligatorio, decimal RemuneracionAsegurable, decimal ComisionFlujo, decimal ComisionMixta)
        {
            if (AFP == "") { dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[14 + con_ingresos].Value = "--"; }
            else { dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[14 + con_ingresos].Value = AFP; }
            if (TipoComision == "") { dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[15 + con_ingresos].Value = "--"; }
            else { dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[15 + con_ingresos].Value = TipoComision; }
            if (Cuspp == "") { dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[16 + con_ingresos].Value = "--"; }
            else { dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[16 + con_ingresos].Value = Cuspp; }
            dgvDetallePlanilla.Columns[14 + con_ingresos].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetallePlanilla.Columns[15 + con_ingresos].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetallePlanilla.Columns[16 + con_ingresos].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            decimal total_atrabajador = 0;

            for (int i = 0; i < con_trabajador - 1; i++)
            {
                dgvDetallePlanilla.Columns[17 + con_ingresos + i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (sma_trabajador[i, 3].ToString() != "")
                {
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[17 + con_ingresos + i].ReadOnly = true;
                    decimal number2 = 0;
                    if (decimal.TryParse(sma_trabajador[i, 3].ToString(), out number2) == true)
                    {
                        dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[17 + con_ingresos + i].Value = String.Format("{0:0.00}", number2);
                        total_atrabajador += decimal.Round(Convert.ToDecimal(sma_trabajador[i, 3].ToString()), 2);
                    }
                    else
                    {
                        ExpressionParser parser = new ExpressionParser();
                        DoubleValue sval = new DoubleValue();
                        DoubleValue aoval = new DoubleValue();
                        DoubleValue cval = new DoubleValue();
                        DoubleValue psval = new DoubleValue();
                        parser.Values.Add("s", sval);
                        parser.Values.Add("ao", aoval);
                        parser.Values.Add("c", cval);
                        parser.Values.Add("ps", psval);

                        sval.Value = Convert.ToDouble(dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[12].Value);
                        aoval.Value = Convert.ToDouble(AporteObligatorio/100);
                        psval.Value = Convert.ToDouble(PrimaSeguros/100);
                        if (TipoComision == "FLUJO")
                        { cval.Value = Convert.ToDouble(ComisionFlujo/100); }
                        else if ((TipoComision == "MIXTA"))
                        { cval.Value = Convert.ToDouble(ComisionMixta/100); }

                        string formula = sma_trabajador[i, 3].ToString();
                        double result = parser.Parse(formula);

                        if (AFP == "SNP" && dgvDetallePlanilla.Columns[17 + con_ingresos + i].Name != "T9")
                        {
                            dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[17 + con_ingresos + i].Value = String.Format("{0:0.00}", 0);
                        }
                        else if (AFP != "SNP" && dgvDetallePlanilla.Columns[17 + con_ingresos + i].Name == "T9")
                        {
                            dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[17 + con_ingresos + i].Value = String.Format("{0:0.00}", 0);
                        }
                        else
                        {
                            dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[17 + con_ingresos + i].Value = String.Format("{0:0.00}", result);
                            total_atrabajador += decimal.Round(Convert.ToDecimal(result), 2);
                        }
                    }
                }
                else
                {
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[17 + con_ingresos + i].Value = String.Format("{0:0.00}", 0);
                }
            }
            if (con_trabajador != 0)
            {
                dgvDetallePlanilla.Columns[16 + con_ingresos + con_trabajador].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[16 + con_ingresos + con_trabajador].Value = String.Format("{0:0.00}", total_atrabajador);
            }
        }

        private void CalcularDescuentos(string AFP, string TipoComision, string Cuspp, decimal PrimaSeguros, decimal AporteObligatorio, decimal RemuneracionAsegurable, decimal ComisionFlujo, decimal ComisionMixta)
        {
            decimal total_descuentos = 0;

            for (int i = 0; i < con_descuento - 1; i++)
            {
                dgvDetallePlanilla.Columns[17 + con_ingresos + con_trabajador + i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (smdescuentos[i, 3].ToString() != "")
                {
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[17 + con_ingresos + con_trabajador + i].ReadOnly = true;
                    decimal number2 = 0;
                    if (decimal.TryParse(smdescuentos[i, 3].ToString(), out number2) == true)
                    {
                        dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[17 + con_ingresos + con_trabajador + i].Value = String.Format("{0:0.00}", number2);
                        total_descuentos += decimal.Round(Convert.ToDecimal(smdescuentos[i, 3].ToString()), 2);
                    }
                    else
                    {
                        ExpressionParser parser = new ExpressionParser();
                        DoubleValue sval = new DoubleValue();
                        DoubleValue aoval = new DoubleValue();
                        DoubleValue cval = new DoubleValue();
                        DoubleValue psval = new DoubleValue();
                        parser.Values.Add("s", sval);
                        parser.Values.Add("ao", aoval);
                        parser.Values.Add("c", cval);
                        parser.Values.Add("ps", psval);

                        sval.Value = Convert.ToDouble(dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[12].Value);
                        aoval.Value = Convert.ToDouble(AporteObligatorio / 100);
                        psval.Value = Convert.ToDouble(PrimaSeguros / 100);
                        if (TipoComision == "FLUJO")
                        { cval.Value = Convert.ToDouble(ComisionFlujo / 100); }
                        else if ((TipoComision == "MIXTA"))
                        { cval.Value = Convert.ToDouble(ComisionMixta / 100); }

                        string formula = smdescuentos[i, 3].ToString();
                        double result = parser.Parse(formula);
                        dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[17 + con_ingresos + con_trabajador + i].Value = String.Format("{0:0.00}", result);
                        total_descuentos += decimal.Round(Convert.ToDecimal(result), 2);
                    }
                }
                else
                {
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[17 + con_ingresos + con_trabajador + i].Value = String.Format("{0:0.00}", 0);
                }
            }
            if (con_descuento != 0)
            {
                dgvDetallePlanilla.Columns[16 + con_ingresos + con_trabajador + con_descuento].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[16 + con_ingresos + con_trabajador + con_descuento].Value = String.Format("{0:0.00}", total_descuentos + Convert.ToDecimal(dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[15 + con_ingresos + con_trabajador].Value));
            }
        }

        private void CalcularA_Empleador(string AFP, string TipoComision, string Cuspp, decimal PrimaSeguros, decimal AporteObligatorio, decimal RemuneracionAsegurable, decimal ComisionFlujo, decimal ComisionMixta)
        {
            decimal total_aempleador = 0;

            for (int i = 0; i < con_empleador-1; i++)
            {
                dgvDetallePlanilla.Columns[17 + con_ingresos + con_trabajador + con_descuento + i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (sma_empleador[i, 3].ToString() != "")
                {
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[17 + con_ingresos + con_trabajador + con_descuento + i].ReadOnly = true;
                    decimal number2 = 0;
                    if (decimal.TryParse(sma_empleador[i, 3].ToString(), out number2) == true)
                    {
                        dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[17 + con_ingresos + con_trabajador + con_descuento + i].Value = String.Format("{0:0.00}", number2);
                        total_aempleador += decimal.Round(Convert.ToDecimal(sma_empleador[i, 3].ToString()), 2);
                    }
                    else
                    {
                        ExpressionParser parser = new ExpressionParser();
                        DoubleValue sval = new DoubleValue();
                        DoubleValue aoval = new DoubleValue();
                        DoubleValue cval = new DoubleValue();
                        DoubleValue psval = new DoubleValue();
                        parser.Values.Add("s", sval);
                        parser.Values.Add("ao", aoval);
                        parser.Values.Add("c", cval);
                        parser.Values.Add("ps", psval);

                        sval.Value = Convert.ToDouble(dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[12].Value);
                        aoval.Value = Convert.ToDouble(AporteObligatorio / 100);
                        psval.Value = Convert.ToDouble(PrimaSeguros / 100);
                        if (TipoComision == "FLUJO")
                        { cval.Value = Convert.ToDouble(ComisionFlujo / 100); }
                        else if ((TipoComision == "MIXTA"))
                        { cval.Value = Convert.ToDouble(ComisionMixta / 100); }

                        string formula = smdescuentos[i, 3].ToString();
                        double result = parser.Parse(formula);
                        dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[17 + con_ingresos + con_trabajador + con_descuento + i].Value = String.Format("{0:0.00}", result);
                        total_aempleador += decimal.Round(Convert.ToDecimal(result), 2);
                    }
                }
                else
                {
                    dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[17 + con_ingresos + con_trabajador + con_descuento + i].Value = String.Format("{0:0.00}", 0);
                }
            }
            //if (total_aempleador != 0)
            //{
            //    dgvDetallePlanilla.Columns[16 + con_ingresos + con_trabajador + con_descuento + con_empleador].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //    dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[16 + con_ingresos + con_trabajador + con_descuento + con_empleador].Value = String.Format("{0:0.00}", total_aempleador);
            //}
        }

        private void btn5taCategoria_Click(object sender, EventArgs e)
        {
            CapaUsuario.Planilla.frm5taCategoria frm5ta = new frm5taCategoria();
            frm5ta.Show();
        }

        private void CalcularNetoaCobrar()
        {
            decimal T = 0;
            dgvDetallePlanilla.Columns[16 + con_ingresos + con_trabajador + con_descuento + con_empleador].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            if (con_ingresos == 0)
            {
                T = Convert.ToDecimal(dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[12].Value) - Convert.ToDecimal(dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[16 + con_ingresos + con_trabajador + con_descuento].Value);
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[16 + con_ingresos + con_trabajador + con_descuento + con_empleador].Value = String.Format("{0:0.00}", T);
            }
            else
            {
                T = Convert.ToDecimal(dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[12].Value) + Convert.ToDecimal(dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[13 + con_ingresos].Value) - Convert.ToDecimal(dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[16 + con_ingresos + con_trabajador + con_descuento].Value);
                dgvDetallePlanilla.Rows[dgvDetallePlanilla.Rows.Count - 1].Cells[16 + con_ingresos + con_trabajador + con_descuento + con_empleador].Value = String.Format("{0:0.00}", T);
            }
        }

        private void DibujarDataGrid()
        {
            string abrev_ingresos = "";string  abrev_descuentos = ""; string abrev_atrabajador = ""; string abrev_aempleador = "";
            string id_ingresos = ""; string id_descuentos = ""; string id_atrabajador = ""; string id_aempleador = "";
            int j = dgvDetallePlanilla.ColumnCount;
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();

            DataTable oDataPlantillaPlanilla = new DataTable();
            CapaDeNegocios.Planillas.cPlantillaPlanilla miPlantillaPlanilla = new CapaDeNegocios.Planillas.cPlantillaPlanilla();
            oDataPlantillaPlanilla = miPlantillaPlanilla.ListarPlantillaPlanilla(sidtregimenlaboral);

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

            smingresos = new string[oDataPlantillaPlanilla.Rows.Count, 4];
            foreach (DataRow row in oDataPlantillaPlanilla.Select("tipo='INGRESOS'"))
            {
                foreach (DataRow rowmingresos in oDataMaestroIngresos.Select("idtmaestroingresos = '" + row[2].ToString() + "'"))
                {
                    smingresos[con_ingresos, 0] = rowmingresos[0].ToString();
                    id_ingresos= rowmingresos[0].ToString();
                    smingresos[con_ingresos, 1] = rowmingresos[1].ToString();
                    smingresos[con_ingresos, 2] = rowmingresos[2].ToString();
                    smingresos[con_ingresos, 3] = rowmingresos[15].ToString();
                    abrev_ingresos = rowmingresos[16].ToString();
                }
                con_ingresos += 1;
                col = new DataGridViewTextBoxColumn();
                col.Name = "I" + id_ingresos;
                col.HeaderText = abrev_ingresos;
                dgvDetallePlanilla.Columns.Add(col);
                dgvDetallePlanilla.Columns["I" + id_ingresos].Width = 50;
                //dgvDetallePlanilla.Columns["I" + con_ingresos].DisplayIndex = 10 + con_ingresos;
            }
            if (con_ingresos != 0)
            {
                con_ingresos += 1;
                col = new DataGridViewTextBoxColumn();
                col.Name = "TOTAL_INGRESOS";
                col.HeaderText = "TOTAL INGRESOS";
                dgvDetallePlanilla.Columns.Add(col);
                dgvDetallePlanilla.Columns["TOTAL_INGRESOS"].ReadOnly = true;
                dgvDetallePlanilla.Columns["TOTAL_INGRESOS"].Width = 50;
            }

            // AFP
            col = new DataGridViewTextBoxColumn();
            col.Name = "AFP";
            col.HeaderText = "AFP";
            dgvDetallePlanilla.Columns.Add(col);
            dgvDetallePlanilla.Columns["AFP"].ReadOnly = true;
            dgvDetallePlanilla.Columns["AFP"].Width = 80;
            // TipoComision
            col = new DataGridViewTextBoxColumn();
            col.Name = "TipoComision";
            col.HeaderText = "TIPO COMISION";
            dgvDetallePlanilla.Columns.Add(col);
            dgvDetallePlanilla.Columns["TipoComision"].ReadOnly = true;
            dgvDetallePlanilla.Columns["TipoComision"].Width = 50;
            // Cuspp
            col = new DataGridViewTextBoxColumn();
            col.Name = "Cuspp";
            col.HeaderText = "Cuspp";
            dgvDetallePlanilla.Columns.Add(col);
            dgvDetallePlanilla.Columns["Cuspp"].ReadOnly = true;
            dgvDetallePlanilla.Columns["Cuspp"].Width = 90;

            sma_trabajador = new string[oDataPlantillaPlanilla.Rows.Count, 4];
            foreach (DataRow row in oDataPlantillaPlanilla.Select("tipo='A_TRABAJADOR'"))
            {
                foreach (DataRow rowmatrabajador in oDataMaestroATrabajador.Select("idtmaestroaportacionestrabajador = '" + row[2].ToString() + "'"))
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
            }
            if (con_trabajador != 0)
            {
                con_trabajador += 1;
                col = new DataGridViewTextBoxColumn();
                col.Name = "TOTAL_A_TRABAJADOR";
                col.HeaderText = "TOTAL DESC. AFP/SNP";
                dgvDetallePlanilla.Columns.Add(col);
                dgvDetallePlanilla.Columns["TOTAL_A_TRABAJADOR"].ReadOnly = true;
                dgvDetallePlanilla.Columns["TOTAL_A_TRABAJADOR"].Width = 50;
            }

            smdescuentos = new string[oDataPlantillaPlanilla.Rows.Count, 4];
            foreach (DataRow row in oDataPlantillaPlanilla.Select("tipo='DESCUENTOS'"))
            {
                foreach (DataRow rowmdescuentos in oDataMaestroDescuentos.Select("idtmaestrodescuentos = '" + row[2].ToString() + "'"))
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
            }
            if (con_descuento != 0)
            {
                con_descuento += 1;
                col = new DataGridViewTextBoxColumn();
                col.Name = "TOTAL_DESCUENTOS";
                col.HeaderText = "TOTAL DESCUENTOS";
                dgvDetallePlanilla.Columns.Add(col);
                dgvDetallePlanilla.Columns["TOTAL_DESCUENTOS"].ReadOnly = true;
                dgvDetallePlanilla.Columns["TOTAL_DESCUENTOS"].Width = 60;
            }

            sma_empleador= new string[oDataPlantillaPlanilla.Rows.Count, 4];
            foreach (DataRow row in oDataPlantillaPlanilla.Select("tipo='A_EMPLEADOR'"))
            {
                foreach (DataRow rowmaempleador in oDataMaestroAEmpleador.Select("idtmaestroaportacionesempleador = '" + row[2].ToString() + "'"))
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
            }
            if (con_empleador != 0)
            {
                con_empleador += 1;
                //col = new DataGridViewTextBoxColumn();
                //col.Name = "TOTAL_A_EMPLEADOR";
                //col.HeaderText = "TOTAL A. EMPLE.";
                //dgvDetallePlanilla.Columns.Add(col);
                //dgvDetallePlanilla.Columns["TOTAL_A_EMPLEADOR"].ReadOnly = true;
                //dgvDetallePlanilla.Columns["TOTAL_A_EMPLEADOR"].Width = 50;
            }

            col = new DataGridViewTextBoxColumn();
            col.Name = "NETOACOBRAR";
            col.HeaderText = "NETO A COBRAR";
            dgvDetallePlanilla.Columns.Add(col);
            dgvDetallePlanilla.Columns["NETOACOBRAR"].ReadOnly = true;
            dgvDetallePlanilla.Columns["NETOACOBRAR"].Width = 65;

            //DIAS LABORADOS
            //col = new DataGridViewTextBoxColumn();
            //col.Name = "DIASLABORADOS";
            //col.HeaderText = "DIAS LABORADOS";
            //dgvDetallePlanilla.Columns.Add(col);
            //dgvDetallePlanilla.Columns["DIASLABORADOS"].ReadOnly = true;
            //dgvDetallePlanilla.Columns["DIASLABORADOS"].Width = 65;
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
                    //default:
                    //    Console.WriteLine("Default case");
                    //    break;
            }
            return x;
        }
    }
}
