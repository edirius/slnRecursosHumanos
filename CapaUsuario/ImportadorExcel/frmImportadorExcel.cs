using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios;
using System.Windows.Forms;
using miExcel = Microsoft.Office.Interop.Excel;

namespace CapaUsuario.ImportadorExcel
{
   

    public partial class frmImportadorExcel : Form
    {
        private CapaDeNegocios.ImportadorDatos.ImportadorExcel miImportadorExcel;
        List<FilasExcel> misTrabajadores = new List<FilasExcel>();

        private Microsoft.Office.Interop.Excel.Application oExcel;
        private object oMissing;
        private Microsoft.Office.Interop.Excel.Workbook oLibro;
        private Microsoft.Office.Interop.Excel.Worksheet oHoja;

        private cTrabajador trabajadorPlantilla = new cTrabajador();
        private CapaDeNegocios.DatosLaborales.cPeriodoTrabajador miPeriodo = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
        private CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador miPeriodoAFP = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();

        public frmImportadorExcel()
        {
            InitializeComponent();
        }

        private void frmImportadorExcel_Load(object sender, EventArgs e)
        {

        }

        private void btnEscogerExcel_Click(object sender, EventArgs e)
        {
            try
            {
                dlgAbrirExcel.DefaultExt = "*.xls||*.xlxs";
                if (dlgAbrirExcel.ShowDialog() == DialogResult.OK)
                {

                    //miImportadorExcel = new CapaDeNegocios.ImportadorDatos.ImportadorExcel(dlgAbrirExcel.FileName);
                    //if (miImportadorExcel.ImportarDatosBasicos())
                    //{
                    //    for (int i = 0; i < miImportadorExcel.Nombres.Count; i++)
                    //    {
                    //        lstListaNombres.Items.Add(miImportadorExcel.Nombres[i].Nombres);
                    //    }

                    //}

                    try
                    {
                        string RutaExcel = dlgAbrirExcel.FileName;

                            oExcel = new Microsoft.Office.Interop.Excel.Application(); ;
                            oMissing = System.Reflection.Missing.Value;
                            oLibro = oExcel.Workbooks.Add(RutaExcel);
                            oHoja = (Microsoft.Office.Interop.Excel.Worksheet)oExcel.ActiveSheet;
                            oExcel.Visible = true;

                        int filaInicioBusqueda = 2;

                        if (oHoja != null)
                        {
                            var valorCelda = (string)(oHoja.Cells[filaInicioBusqueda, 2] as Microsoft.Office.Interop.Excel.Range).Value;
                            while (!(valorCelda == "") && !(valorCelda == null))
                            {
                                FilasExcel nombre = new FilasExcel();
                                nombre.dni = valorCelda;
                                nombre.cusspp = (string)(oHoja.Cells[filaInicioBusqueda, 6] as Microsoft.Office.Interop.Excel.Range).Value;
                                switch ((string)(oHoja.Cells[filaInicioBusqueda, 14] as Microsoft.Office.Interop.Excel.Range).Value)
                                {
                                    case "HABITAT":
                                        nombre.codigoafp = 1;
                                        nombre.afp = "HABITAT";
                                        break;
                                    case "PROFUTURO":
                                        nombre.codigoafp = 4;
                                        nombre.afp = "PROFUTURO";
                                        break;
                                    case "INTEGRA":
                                        nombre.codigoafp = 2;
                                        nombre.afp = "INTEGRA";
                                        break;
                                    case "PRIMA":
                                        nombre.codigoafp = 3;
                                        nombre.afp = "PRIMA";
                                        break;
                                    default:
                                        break;
                                }

                                if ((string)(oHoja.Cells[filaInicioBusqueda, 15] as Microsoft.Office.Interop.Excel.Range).Value == "0" || (string)(oHoja.Cells[filaInicioBusqueda, 15] as Microsoft.Office.Interop.Excel.Range).Value == "0.00")
                                {
                                    nombre.tipocomision = "MIXTA";
                                }
                                else
                                {
                                    nombre.tipocomision = "FLUJO";
                                }

                                trabajadorPlantilla =  trabajadorPlantilla.BuscarTrabajadorXDNI(nombre.dni);

                                nombre.codigoTrabajador = trabajadorPlantilla.IdTrabajador;

                                miPeriodo = miPeriodo.traerUltimoPeriodoTrabajador(nombre.codigoTrabajador);
                                nombre.codigoPeriodo = miPeriodo.IdtPeriodoTrabajador;
                                miPeriodoAFP = miPeriodoAFP.TraerUltimoRegimenPensionario(miPeriodo.IdtPeriodoTrabajador);
                                nombre.codigoPensionario = miPeriodoAFP.IdtRegimenPensionarioTrabajador;


                                

                                filaInicioBusqueda += 1;
                                valorCelda = (string)(oHoja.Cells[filaInicioBusqueda, 2] as Microsoft.Office.Interop.Excel.Range).Value;
                                misTrabajadores.Add(nombre);
                            }
                            dtgLista.DataSource = misTrabajadores;
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new cReglaNegociosException("Error al abrir archivo excel: ImportadorExcel.cs : " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir excel: " + ex.Message);
            }
            
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            DataTable oDataPeriodoTrabajador = new DataTable();

            int sidttrabajador;
            int sidtperiodotrabajador = 0;
            for (int i = 0; i < miImportadorExcel.Nombres.Count; i++)
            {
                
              
                //oDataTrabajador = miTrabajador.ObtenerListaTrabajadores("Sin Periodo Laboral", "", "", "", "", "Todos", "Todos");
                //sidttrabajador = Convert.ToInt32(oDataTrabajador.Compute("MAX(id_trabajador)", ""));

                //CapaDeNegocios.DatosLaborales.cPeriodoTrabajador miPeriodoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();

                //miPeriodoTrabajador.IdtPeriodoTrabajador = sidtperiodotrabajador;
                //miPeriodoTrabajador.FechaInicio ="01/04/2021";
                //miPeriodoTrabajador.FechaFin = "";
                //miPeriodoTrabajador.IdtMotivoFinPeriodo = 1;
                //miPeriodoTrabajador.IdtTrabajador = sidttrabajador;
                //miPeriodoTrabajador.CrearPeriodoTrabajador(miPeriodoTrabajador);

                //oDataPeriodoTrabajador = miPeriodoTrabajador.ListarPeriodoTrabajador(sidttrabajador);
                //sidtperiodotrabajador = Convert.ToInt32(oDataPeriodoTrabajador.Compute("MAX(idtperiodotrabajador)", ""));

                ////CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador miRegimenPensionarioTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();
                ////miRegimenPensionarioTrabajador.IdtRegimenPensionarioTrabajador = 0;
                ////miRegimenPensionarioTrabajador.FechaInicio = dtpFechaInicio.Value.ToShortDateString();
                ////miRegimenPensionarioTrabajador.FechaFin = "";
                ////miRegimenPensionarioTrabajador.CUSPP = txtCUSPP.Text;
                ////miRegimenPensionarioTrabajador.TipoComision = cboTipoComision.Text;
                ////miRegimenPensionarioTrabajador.IdtAFP = sidtafp;
                ////miRegimenPensionarioTrabajador.IdtPeriodoTrabajador = sidtperiodotrabajador;
                ////miRegimenPensionarioTrabajador.CrearRegimenPensionarioTrabajador(miRegimenPensionarioTrabajador);

                //CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador miRegimenSaludTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador();
                //miRegimenSaludTrabajador.IdtRegimenSaludTrabajador = 0;
                //miRegimenSaludTrabajador.RegimenSalud = "ESSALUD REGULAR (Exclusivamente)";
                //miRegimenSaludTrabajador.FechaInicio = "01/04/2021";
                //miRegimenSaludTrabajador.FechaFin = "";
                //miRegimenSaludTrabajador.EntidadPrestadoraSalud = "";
                //miRegimenSaludTrabajador.IdtPeriodoTrabajador = sidtperiodotrabajador;
                //miRegimenSaludTrabajador.CrearRegimenSaludTrabajador(miRegimenSaludTrabajador);

                //CapaDeNegocios.DatosLaborales.cRegimenTrabajador miRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
                //miRegimenTrabajador.IdtRegimenTrabajador = 0;
                //miRegimenTrabajador.Condicion = "CONTRATADO";
                //miRegimenTrabajador.ServidorConfianza = false;
                //miRegimenTrabajador.NumeroDocumento = "";
                //miRegimenTrabajador.Periodicidad = "MENSUAL";
                //miRegimenTrabajador.TipoPago = "EFECTIVO";
                //miRegimenTrabajador.MontoPago = 0;
                //miRegimenTrabajador.FechaInicio = "01/04/2021";
                //miRegimenTrabajador.FechaFin = "";
                //miRegimenTrabajador.RUC = "";
                //miRegimenTrabajador.IdtRegimenLaboral = 3;
                //miRegimenTrabajador.IdtTipoTrabajador = 2;
                //miRegimenTrabajador.IdtTipoContrato = 15;
                //miRegimenTrabajador.IdtCategoriaOcupacional = 5;
                //miRegimenTrabajador.IdtOcupacion = 1;
                //miRegimenTrabajador.IdtCargo = 49;
                //miRegimenTrabajador.IdtMeta = 75;
                //miRegimenTrabajador.IdtPeriodoTrabajador = sidtperiodotrabajador;
                //miRegimenTrabajador.CrearRegimenTrabajador(miRegimenTrabajador);
            }

        }
    }

    public class FilasExcel
    {
        public string dni { get; set; }
        public string cusspp { get; set; }
        public string afp { get; set; }
        public int codigoafp { get; set; }
        public string tipocomision { get; set; }
        public int codigoTrabajador { get; set; }
        public int codigoPeriodo { get; set; }
        public int codigoPensionario { get; set; }
    }
}
