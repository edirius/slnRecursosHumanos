using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaDeNegocios;

using System.Xml;


using System.Data.OleDb;
using System.Reflection;

namespace CapaUsuario.CargaInicial
{
    public partial class frmCargaInicial : Form
    {
        private List<cDetalleCargaInicial> ListaDetalles = new List<cDetalleCargaInicial>();

        private cTrabajador trabajadorPlantilla = new cTrabajador();

        public frmCargaInicial()
        {
            InitializeComponent();
        }

        private void frmCargaInicial_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog fichero = new OpenFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls|Excel (*.xlsx)|*.xlsx|xml(*.xml) |*.xml";
            fichero.FileName = "r07.xml";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                LLenarGrid(fichero.FileName, "Hoja1");
            }
        }

        private void LLenarGrid(string archivo, string hoja)
        {
          
            XmlDocument miXML = new XmlDocument();
            miXML.Load(archivo);

            foreach (XmlNode item in miXML.ChildNodes)
            {
                if (item.Name == "ss:Workbook")
                {
                    foreach (XmlNode item2 in item.ChildNodes)
                    {
                        if (item2.Name == "ss:Worksheet")
                        {
                            if (item2.HasChildNodes)
                            {
                                foreach (XmlNode item3 in item2.ChildNodes)
                                {
                                    if (item3.Name == "ss:Table")
                                    {
                                        if (item3.HasChildNodes)
                                        {
                                            foreach (XmlNode item4 in item3.ChildNodes)
                                            {
                                                if (item4.Name == "ss:Row" && item4.ChildNodes[0].Attributes[0].Value != "7")
                                                {

                                                    int numero = Convert.ToInt32(item4.Attributes[0].Value);

                                                    if (numero >= 14)
                                                    {
                                                        
                                                        cDetalleCargaInicial nuevoDetalle = new cDetalleCargaInicial();
                                                        nuevoDetalle.MiTrabajador.MiNacionalidad = trabajadorPlantilla.MiNacionalidad;
                                                        nuevoDetalle.MiTrabajador.MiDistrito = trabajadorPlantilla.MiDistrito;
                                                        nuevoDetalle.MiTrabajador.MiTipoZOna = trabajadorPlantilla.MiTipoZOna;
                                                        nuevoDetalle.MiTrabajador.MiTipoVia = trabajadorPlantilla.MiTipoVia;
                                                        nuevoDetalle.MiTrabajador.NumeroVia = "0";
                                                        foreach (XmlNode item5 in item4.ChildNodes)
                                                        {
                                                            

                                                            // nodo cell
                                                            switch (item5.Attributes[0].Value)
                                                            {
                                                                //NODO CELL
                                                                //dni
                                                                case "2":
                                                                    nuevoDetalle.MiTrabajador.Dni = item5.ChildNodes[0].ChildNodes[0].Value;
                                                                    break;
                                                                //apellido paterno
                                                                case "3":
                                                                    nuevoDetalle.MiTrabajador.ApellidoPaterno = item5.ChildNodes[0].ChildNodes[0].Value;
                                                                    break;
                                                                //apellido materno
                                                                case "4":
                                                                    nuevoDetalle.MiTrabajador.ApellidoMaterno = item5.ChildNodes[0].ChildNodes[0].Value;
                                                                    break;
                                                                //nombres
                                                                case "5":
                                                                    nuevoDetalle.MiTrabajador.Nombres = item5.ChildNodes[0].ChildNodes[0].Value;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }

                                                           
                                                        }
                                                        ListaDetalles.Add(nuevoDetalle);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
    
                        }
                    }
                }
            }
            cargarDatagrid();
            
        }


        private void cargarDatagrid()
        {
            dtgDatosExcel.DataSource = ListaDetalles;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListaDetalles.Count == 0)
                {
                    MessageBox.Show("No hay datos para guardar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    foreach (cDetalleCargaInicial item in ListaDetalles)
                    {
                        if (item.MiTrabajador.BuscarTrabajadorXDNI(item.MiTrabajador.Dni) != null)
                        {

                        } 
                        else
                        {
                            int id;
                            item.MiTrabajador.Scrt = true;
                            item.MiTrabajador.NroRenta4ta = "1";
                            item.MiTrabajador.FechaNacimiento = new DateTime(2022, 1, 1);

                            id = item.MiTrabajador.AgregarTrabajadorConID(item.MiTrabajador);
                            item.MiTrabajador.IdTrabajador = id;

                            item.MiPeriodo = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
                            item.MiPeriodo.FechaInicio = "01/08/2023";
                            item.MiPeriodo.FechaFin = "";
                            item.MiPeriodo.IdtMotivoFinPeriodo = 1;
                            item.MiPeriodo.IdtTrabajador = id;
                            item.MiPeriodo.CrearPeriodoTrabajador(item.MiPeriodo);

                            item.MiPeriodo = item.MiPeriodo.traerUltimoPeriodoTrabajador(id);

                            item.MiPeriodoAFP = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();
                            item.MiPeriodoAFP.IdtAFP = 5;
                            item.MiPeriodoAFP.FechaInicio = "01/08/2023";
                            item.MiPeriodoAFP.FechaFin = "";
                            item.MiPeriodoAFP.IdtPeriodoTrabajador = item.MiPeriodo.IdtPeriodoTrabajador;

                            item.MiPeriodoAFP.CrearRegimenPensionarioTrabajador(item.MiPeriodoAFP);

                            item.MiPeriodoSalud = new CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador();
                            item.MiPeriodoSalud.IdtRegimenSaludTrabajador = 0;
                            item.MiPeriodoSalud.RegimenSalud = "ESSALUD REGULAR (Exclusivamente)";

                            item.MiPeriodoSalud.FechaInicio = "01/08/2023";
                            item.MiPeriodoSalud.FechaFin = "";
                            item.MiPeriodoSalud.EntidadPrestadoraSalud = "";
                            item.MiPeriodoSalud.IdtPeriodoTrabajador = item.MiPeriodo.IdtPeriodoTrabajador;
                            item.MiPeriodoSalud.CrearRegimenSaludTrabajador(item.MiPeriodoSalud);


                            item.MiTipoTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
                            item.MiTipoTrabajador.IdtRegimenTrabajador = 0;
                            item.MiTipoTrabajador.Condicion = "CONTRATADO";
                            item.MiTipoTrabajador.ServidorConfianza = false;

                            item.MiTipoTrabajador.Periodicidad = "MENSUAL";
                            item.MiTipoTrabajador.TipoPago = "EFECTIVO";
                            item.MiTipoTrabajador.MontoPago = 0;
                            item.MiTipoTrabajador.FechaInicio = "01/08/2023";
                            item.MiTipoTrabajador.FechaFin = "";
                            item.MiTipoTrabajador.RUC = "";
                            item.MiTipoTrabajador.IdtRegimenLaboral = 2;
                            item.MiTipoTrabajador.IdtTipoTrabajador = 2;
                            item.MiTipoTrabajador.IdtTipoContrato = 9;
                            item.MiTipoTrabajador.IdtCategoriaOcupacional = 5;
                            item.MiTipoTrabajador.IdtOcupacion = 1;
                            item.MiTipoTrabajador.IdtCargo = 49;
                            item.MiTipoTrabajador.IdtMeta = 88;
                            item.MiTipoTrabajador.IdtPeriodoTrabajador = item.MiPeriodo.IdtPeriodoTrabajador;
                            item.MiTipoTrabajador.CrearRegimenTrabajador(item.MiTipoTrabajador);
                        }
                        
                    }
                    cargarDatagrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al salvar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDatosFijos_Click(object sender, EventArgs e)
        {
            try
            {
                frmDatosFijos fDatosFijos = new frmDatosFijos();
                fDatosFijos.miNacionalidad = new cNacionalidad();
                fDatosFijos.miDistrito = new cDistrito();
                fDatosFijos.miTipoVia = new cTipoVia();
                fDatosFijos.miTipoZona = new cTipoZona();

                if (fDatosFijos.ShowDialog() == DialogResult.OK)
                {
                    trabajadorPlantilla.MiNacionalidad = fDatosFijos.miNacionalidad;
                    trabajadorPlantilla.MiDistrito = fDatosFijos.miDistrito;
                    trabajadorPlantilla.MiTipoVia = fDatosFijos.miTipoVia;
                    trabajadorPlantilla.MiTipoZOna = fDatosFijos.miTipoZona;
                    trabajadorPlantilla.NumeroVia = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al dar datos fijos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgDatosExcel_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dtgDatosExcel.Rows[e.RowIndex].DataBoundItem != null) && (dtgDatosExcel.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(dtgDatosExcel.Rows[e.RowIndex].DataBoundItem, dtgDatosExcel.Columns[e.ColumnIndex].DataPropertyName);
            }
        }

        private string BindProperty(object property, string propertyName)
        {
            string retValue = "";
            if (propertyName.Contains("."))
            {
                PropertyInfo[] arrayProperties;
                string leftPropertyName;
                leftPropertyName = propertyName.Substring(0, propertyName.IndexOf("."));
                arrayProperties = property.GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in arrayProperties)
                {
                    if (propertyInfo.Name == leftPropertyName)
                    {
                        retValue = BindProperty(
                          propertyInfo.GetValue(property, null),
                          propertyName.Substring(propertyName.IndexOf(".") + 1));
                        break;
                    }
                }
            }
            else
            {
                Type propertyType;
                PropertyInfo propertyInfo;
                propertyType = property.GetType();
                propertyInfo = propertyType.GetProperty(propertyName);
                retValue = propertyInfo.GetValue(property, null).ToString();
            }
            return retValue;
        }
    }
}
