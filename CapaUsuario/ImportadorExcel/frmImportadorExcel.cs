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

namespace CapaUsuario.ImportadorExcel
{
    public partial class frmImportadorExcel : Form
    {
        private CapaDeNegocios.ImportadorDatos.ImportadorExcel miImportadorExcel;
        CapaDeNegocios.cTrabajador miTrabajador = new CapaDeNegocios.cTrabajador();
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
                    miImportadorExcel = new CapaDeNegocios.ImportadorDatos.ImportadorExcel(dlgAbrirExcel.FileName);
                    if (miImportadorExcel.ImportarDatosBasicos())
                    {
                        for (int i = 0; i < miImportadorExcel.Nombres.Count; i++)
                        {
                            lstListaNombres.Items.Add(miImportadorExcel.Nombres[i].Nombres);
                        }
                        
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
                
                miTrabajador.Nombres = miImportadorExcel.Nombres[i].Nombres;
                miTrabajador.ApellidoPaterno = miImportadorExcel.Nombres[i].ApellidoPaterno;
                miTrabajador.ApellidoMaterno = miImportadorExcel.Nombres[i].ApellidoMaterno;
                miTrabajador.Sexo = CapaDeNegocios.EnumSexo.Masculino;
                miTrabajador.FechaNacimiento = DateTime.Today;
                miTrabajador.Dni = miImportadorExcel.Nombres[i].Dni;
                miTrabajador.CelularPersonal = "";
                miTrabajador.Direccion = "";
                miTrabajador.MiDistrito = new cDistrito();
                miTrabajador.MiDistrito.Codigo = 789;

                miTrabajador.MiTipoVia = new cTipoVia();
                miTrabajador.MiTipoVia.Codigo = 1;
                miTrabajador.MiTipoZOna = new cTipoZona();
                miTrabajador.MiTipoZOna.Codigo = 1;
                miTrabajador.MiNacionalidad = new cNacionalidad();
                miTrabajador.MiNacionalidad.Codigo = 1;

                sidttrabajador = miTrabajador.AgregarTrabajadorConID(miTrabajador);
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
}
