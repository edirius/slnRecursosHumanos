using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios.Tareos;
using CapaDeNegocios;

namespace CapaUsuario.Tareo
{
    public partial class frmImportarExcel : Form
    {
        public cTrabajador oTrabajador = new cTrabajador();
        public CapaDeNegocios.Obras.cMeta oMeta;
        public CapaDeNegocios.Tareos.cTareo otareo;

        cImportarExcelTareo oImportadorExcelTareo = new cImportarExcelTareo();
        cArchivoExcel miArchivoExcel = new cArchivoExcel();
        cDistrito miDistrito = new cDistrito();

        public frmImportarExcel()
        {
            InitializeComponent();
        }

        private void frmImportarExcel_Load(object sender, EventArgs e)
        {
            cboTipoOrden.DataSource = Enum.GetValues(typeof(enumTipoNombres));
        }

        private void btnImportarExcel_Click(object sender, EventArgs e)
        {
            

            OpenFileDialog fichero = new OpenFileDialog();
            fichero.Filter = "Excel (*.xlsx)|*.xlsx| Excel (*.xls)|*.xls";
            fichero.FileName = "consultaCUSPPMasiva.xlsX";
        
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                
                miArchivoExcel.NombreHoja = txtHojaExcel.Text;
                miArchivoExcel.InicioFila = Convert.ToInt16(txtComienzoFila.Text);
                miArchivoExcel.FinFila = Convert.ToInt16(txtFinFila.Text);
                miArchivoExcel.ColumnaNombres = txtColumnaNombres.Text;
                miArchivoExcel.ColumnaDNI = txtColumnaDNI.Text;
                miArchivoExcel.ColumnaCargo = txtColumnaCategoria.Text;
                miArchivoExcel.ColumnaDias = txtColumnaDias.Text;
                miArchivoExcel.TipoNombres = (enumTipoNombres) cboTipoOrden.SelectedValue;

                miArchivoExcel = oImportadorExcelTareo.Importar(fichero.FileName, miArchivoExcel);
                dtgDatos.DataSource = miArchivoExcel.Detalles;
            }

            foreach (cDetalleArchivoExcel item in miArchivoExcel.Detalles)
            {
                int codigoTrabajador = oTrabajador.BuscarTrabajadorXDNIFormaCorta(item.Dni);

                if (codigoTrabajador != 0)
                {
                    item.TrabajadorEncontrado = true;
                    item.CodigoTrabajador = codigoTrabajador;
                }
                else
                {
                    item.TrabajadorEncontrado = false;
                    item.CodigoTrabajador = 0;
                }
            }


            foreach (DataGridViewRow row in dtgDatos.Rows)
            {
                Color color = Color.DarkOrange;

                if (!Convert.ToBoolean(row.Cells["TrabajadorEncontrado"].Value))
                {
                    row.DefaultCellStyle.BackColor = color;
                } 
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                int sidttrabajador;
                int sidtperiodotrabajador;

                DateTime dtpFechaInicio = new DateTime(2023, 10, 1);
                miDistrito = miDistrito.TraerDistrito(790);


                foreach (cDetalleArchivoExcel item in miArchivoExcel.Detalles)
                {
                    cTrabajador miTrabajador = new cTrabajador();
                    CapaDeNegocios.DatosLaborales.cPeriodoTrabajador miPeriodoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
                    CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador miRegimenPensionarioTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();
                    CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador miRegimenSaludTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador();
                    CapaDeNegocios.DatosLaborales.cRegimenTrabajador miRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();

                    if (item.CodigoTrabajador == 0)
                    {
                        miTrabajador.Nombres = item.Nombres;
                        miTrabajador.ApellidoPaterno = item.Apellidopaterno;
                        miTrabajador.ApellidoMaterno = item.Apellidomaterno;
                        miTrabajador.Sexo = EnumSexo.Masculino;
                        miTrabajador.FechaNacimiento = new DateTime(2022, 1, 1);
                        miTrabajador.Dni = item.Dni;
                        miTrabajador.CelularPersonal = "";
                        miTrabajador.Direccion = "";
                        miTrabajador.MiDistrito = miDistrito;
                        miTrabajador.MiDistrito.Codigo = miDistrito.Codigo;

                        miTrabajador.CorreoElectronico = "";

                        miTrabajador.MiTipoVia = new cTipoVia();
                        miTrabajador.MiTipoVia.Codigo = 1;
                        miTrabajador.MiTipoZOna = new cTipoZona();
                        miTrabajador.MiTipoZOna.Codigo = 1;
                        miTrabajador.MiNacionalidad = new cNacionalidad();
                        miTrabajador.MiNacionalidad.Codigo = 1;
                        miTrabajador.Essaludvida = false;
                        miTrabajador.Scrt = true;
                        miTrabajador.NroRenta4ta = "1";
                        sidttrabajador = miTrabajador.AgregarTrabajadorConID(miTrabajador);
                        miTrabajador.IdTrabajador = sidttrabajador;

                        item.CodigoTrabajador = sidttrabajador;
                        miPeriodoTrabajador.FechaInicio = dtpFechaInicio.ToShortDateString();
                        miRegimenPensionarioTrabajador.FechaInicio = dtpFechaInicio.ToShortDateString();
                        miRegimenPensionarioTrabajador.CUSPP = "";
                        miRegimenPensionarioTrabajador.TipoComision = "";
                        miRegimenPensionarioTrabajador.IdtAFP = 5;
                        miRegimenSaludTrabajador.FechaInicio = dtpFechaInicio.ToShortDateString();
                        miRegimenTrabajador.FechaInicio = dtpFechaInicio.ToShortDateString();
                        miRegimenTrabajador.NumeroDocumento = "";

                        miRegimenTrabajador.Condicion = "CONTRATADO";
                        miRegimenTrabajador.ServidorConfianza = false;

                        miRegimenTrabajador.Periodicidad = "MENSUAL";
                        miRegimenTrabajador.TipoPago = "EFECTIVO";
                        miRegimenTrabajador.MontoPago = 0;

                        miRegimenTrabajador.FechaFin = "";
                        miRegimenTrabajador.RUC = "";
                        miRegimenTrabajador.IdtCategoriaOcupacional = 5;
                        miRegimenTrabajador.IdtOcupacion = 1;
                        miRegimenTrabajador.IdtCargo = 49;
                        miRegimenTrabajador.IdtMeta = oMeta.Codigo;

                        CapaDeNegocios.cDatosGenerales misDatosGenerales = new CapaDeNegocios.cDatosGenerales();

                        if (misDatosGenerales.Tecnicos276)
                        {
                            miRegimenTrabajador.IdtRegimenLaboral = 2;
                        }
                        else
                        {
                            miRegimenTrabajador.IdtRegimenLaboral = 3;
                        }


                        miRegimenTrabajador.IdtTipoTrabajador = 12;
                        miRegimenTrabajador.IdtTipoContrato = 15;


                        miPeriodoTrabajador.FechaFin = "";
                        miPeriodoTrabajador.IdtMotivoFinPeriodo = 1;
                        miPeriodoTrabajador.IdtTrabajador = item.CodigoTrabajador;
                        miPeriodoTrabajador.CrearPeriodoTrabajador(miPeriodoTrabajador);
                        DataTable oDataPeriodoTrabajador = miPeriodoTrabajador.ListarPeriodoTrabajador(item.CodigoTrabajador);
                        sidtperiodotrabajador = Convert.ToInt32(oDataPeriodoTrabajador.Compute("MAX(idtperiodotrabajador)", ""));

                        miRegimenPensionarioTrabajador.IdtRegimenPensionarioTrabajador = 0;

                        miRegimenPensionarioTrabajador.FechaFin = "";


                        miRegimenPensionarioTrabajador.IdtPeriodoTrabajador = sidtperiodotrabajador;
                        miRegimenPensionarioTrabajador.CrearRegimenPensionarioTrabajador(miRegimenPensionarioTrabajador);


                        miRegimenSaludTrabajador.IdtRegimenSaludTrabajador = 0;
                        miRegimenSaludTrabajador.RegimenSalud = "ESSALUD REGULAR (Exclusivamente)";

                        miRegimenSaludTrabajador.FechaFin = "";
                        miRegimenSaludTrabajador.EntidadPrestadoraSalud = "";
                        miRegimenSaludTrabajador.IdtPeriodoTrabajador = sidtperiodotrabajador;
                        miRegimenSaludTrabajador.CrearRegimenSaludTrabajador(miRegimenSaludTrabajador);


                        miRegimenTrabajador.IdtRegimenTrabajador = 0;


                        miRegimenTrabajador.IdtPeriodoTrabajador = sidtperiodotrabajador;
                        miRegimenTrabajador.CrearRegimenTrabajador(miRegimenTrabajador);
                    }



                    //PARTE TAREO

                    CapaDeNegocios.Tareos.cDetalleTareo oDetalle = new cDetalleTareo();

                    oDetalle.IdtTrabajador = item.CodigoTrabajador;
                    oDetalle.IdtTareo = otareo.IdTTareo;
                    oDetalle.Categoria = item.Cargo;
                    oDetalle.TotalDias = item.Dias;
                    oDetalle.DiasTareo = Diastareo(item.Dias);

                    oDetalle.CrearDetalleTareo(oDetalle);
                }
                MessageBox.Show("Datos Importador", "Importacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al importar bd: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

            
        }

        public string Diastareo(int dias)
        {
            string detalledias = "";
            for (int i = 0; i < 31; i++)
            {
                if (i < dias)
                {
                    detalledias = detalledias + "X";
                }
                else
                {
                    detalledias = detalledias + "0";
                }
            }
            return detalledias;
            
        }
    }
}
