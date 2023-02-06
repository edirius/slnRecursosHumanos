using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using CapaDeNegocios;
using CapaDeNegocios.Planillas;
namespace CapaUsuario.ExportarSunat
{
    public partial class frmCompararDatosAFP : Form
    {
        cComparativoAFP oComparativoAFP = new cComparativoAFP();

        ImageConverter imageConverter = new ImageConverter();

        public frmCompararDatosAFP()
        {
            InitializeComponent();
        }

        public cPlanilla planilla;

        cDetallePlanilla detallePlanilla = new cDetallePlanilla();

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            DataGridView datagrid = new DataGridView();

            OpenFileDialog fichero = new OpenFileDialog();
            fichero.Filter = "Excel (*.xlsx)|*.xlsx| Excel (*.xls)|*.xls";
            fichero.FileName = "consultaCUSPPMasiva.xlsX";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                LLenarGrid(fichero.FileName, "Hoja1");
            }
        }

        private void LLenarGrid(string archivo, string hoja)
        {
            //declaramos las variables         
            OleDbConnection conexion = null;
            DataSet dataSet = null;
            OleDbDataAdapter dataAdapter = null;
            string consultaHojaExcel = "SELECT * FROM [" + hoja + "$];";

            //esta cadena es para archivos excel 2007 y 2010
            string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + archivo + "';Extended Properties=Excel 12.0;";

            //para archivos de 97-2003 usar la siguiente cadena
            //string cadenaConexionArchivoExcel = "provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + archivo + "';Extended Properties=Excel 8.0;";

            //Validamos que el usuario ingrese el nombre de la hoja del archivo de excel a leer
            if (string.IsNullOrEmpty(hoja))
            {
                MessageBox.Show("No hay una hoja para leer. ¿Esta abriendo el archivo correcto?");
            }
            else
            {
                try
                {
                    //Si el usuario escribio el nombre de la hoja se procedera con la busqueda
                    conexion = new OleDbConnection(cadenaConexionArchivoExcel);//creamos la conexion con la hoja de excel
                    conexion.Open(); //abrimos la conexion
                    dataAdapter = new OleDbDataAdapter(consultaHojaExcel, conexion); //traemos los datos de la hoja y las guardamos en un dataSdapter
                    dataSet = new DataSet(); // creamos la instancia del objeto DataSet
                    dataAdapter.Fill(dataSet, hoja);//llenamos el dataset
                    dtgDatosExcel.DataSource = dataSet.Tables[0]; //le asignamos al DataGridView el contenido del dataSet
                    conexion.Close();//cerramos la conexion
                    dtgDatosExcel.AllowUserToAddRows = false;       //eliminamos la ultima fila del datagridview que se autoagrega
                    DarFormato();
                }
                catch (Exception ex)
                {
                    dtgDatosExcel.Columns.Clear();
                    //en caso de haber una excepcion que nos mande un mensaje de error
                    MessageBox.Show("Error, Verificar el archivo o el nombre de la hoja", ex.Message);
                }
            }
        }

        private void DarFormato ()
        {
            dtgDatosExcel.Columns[0].Visible = false;
            dtgDatosExcel.Columns[2].Visible = false;
            dtgDatosExcel.Columns[3].Visible = false;
            dtgDatosExcel.Columns[4].Visible = false;
            dtgDatosExcel.Columns[9].Visible = false;
            dtgDatosExcel.Columns[10].Visible = false;
            dtgDatosExcel.Columns[11].Visible = false;
            dtgDatosExcel.Columns[12].Visible = false;

            CompararResultados();
        }

        private void CompararResultados()
        {
            try
            {
                if (dtgDatosExcel.Rows.Count != dtgDatosPlanilla.Rows.Count)
                {
                    throw new cReglaNegociosException("El numero de filas de los datos no coinciden.");
                }
                oComparativoAFP.ListaDetalles.Clear();
                for (int i = 0; i < dtgDatosPlanilla.RowCount; i++)
                {
                    cDetalleComparativoAFP nuevo = new cDetalleComparativoAFP();
                    nuevo.Fila = i;

                    if (dtgDatosPlanilla.Rows[i].Cells[8].Value.ToString() == "SNP")
                    {
                        if (dtgDatosExcel.Rows[i].Cells[13].Value.ToString() == "")
                        {
                            nuevo.ErrorAFP = false;
                        }
                        else
                        {
                            nuevo.ErrorAFP = true;
                        }
                    }
                    else
                    {
                        //datos AFP
                        if (dtgDatosPlanilla.Rows[i].Cells[8].Value.ToString() != dtgDatosExcel.Rows[i].Cells[13].Value.ToString())
                        {
                            nuevo.ErrorAFP = true;
                        }
                        else
                        {
                            nuevo.ErrorAFP = false;
                        }

                        //Datos cussp
                        if (dtgDatosPlanilla.Rows[i].Cells[2].Value.ToString() != dtgDatosExcel.Rows[i].Cells[5].Value.ToString())
                        {
                            nuevo.ErrorCUSPP = true;
                        }
                        else
                        {
                            nuevo.ErrorCUSPP = false;
                        }

                        //Datos DNI
                        if (dtgDatosPlanilla.Rows[i].Cells[1].Value.ToString() != dtgDatosExcel.Rows[i].Cells[1].Value.ToString())
                        {
                            nuevo.ErrorDNI = true;
                        }
                        else
                        {
                            nuevo.ErrorDNI = false;
                        }

                        //Datos Comision
                        if (Convert.ToDouble(dtgDatosPlanilla.Rows[i].Cells[10].Value.ToString()) != Convert.ToDouble(dtgDatosExcel.Rows[i].Cells[14].Value.ToString()))
                        {
                            nuevo.ErrorComision = true;
                        }
                        else
                        {
                            if (dtgDatosPlanilla.Rows[i].Cells[9].Value.ToString()=="")
                            {
                                nuevo.ErrorComision = true;
                            }
                            else
                            {
                                nuevo.ErrorComision = false;
                            }
                            
                        }

                    }
                    if (nuevo.ErrorGeneral())
                    {
                        dtgDatosPlanilla.Rows[i].Cells["colCheck"].Value = imageConverter.ConvertTo(Properties.Resources.equis, System.Type.GetType("System.Byte[]"));
                    }
                    else
                    {
                        dtgDatosPlanilla.Rows[i].Cells["colCheck"].Value = imageConverter.ConvertTo(Properties.Resources.check, System.Type.GetType("System.Byte[]"));
                    }
                    oComparativoAFP.ListaDetalles.Add(nuevo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al comparar los resultados: " + ex.Message);
            }
        }

        private void frmCompararDatosAFP_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            dtgDatosPlanilla.Columns.Clear();
            dtgDatosPlanilla.DataSource = detallePlanilla.ListarDetallePlanillaParaAFP(planilla.IdtPlanilla, planilla.Mes, planilla.Año);
            dtgDatosPlanilla.Columns[0].Visible = false;
            dtgDatosPlanilla.Columns[6].Visible = false;
            dtgDatosPlanilla.Columns[7].Visible = false;

            dtgDatosPlanilla.Columns[1].HeaderText = "DNI";
            dtgDatosPlanilla.Columns[2].HeaderText = "CUSSP";
            dtgDatosPlanilla.Columns[3].HeaderText = "Apellido Paterno";
            dtgDatosPlanilla.Columns[4].HeaderText = "Apellido Materno";
            dtgDatosPlanilla.Columns[5].HeaderText = "Nombres";
            dtgDatosPlanilla.Columns[8].HeaderText = "AFP";
            dtgDatosPlanilla.Columns[9].HeaderText = "TIPO COMISION AFP";
            DataGridViewColumn nuevo = new DataGridViewColumn();
            nuevo.Name = "colCheck";
            nuevo.HeaderText = "Correcto";
            nuevo.CellTemplate = new DataGridViewImageCell();


            dtgDatosPlanilla.Columns.Add(nuevo);

            foreach (DataGridViewRow item in dtgDatosPlanilla.Rows)
            {


                item.Cells["colCheck"].Value = imageConverter.ConvertTo(Properties.Resources.question, System.Type.GetType("System.Byte[]"));

            }
        }

        private void dtgDatosPlanilla_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           
           


        }

        private void dtgDatosPlanilla_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgDatosPlanilla.Rows[e.RowIndex].Cells[0].Value != null)
            {
                switch (dtgDatosPlanilla.Rows[e.RowIndex].Cells["nombre"].Value.ToString())
                {
                    case "PROFUTURO":
                        foreach (DataGridViewCell celda in this.dtgDatosPlanilla.Rows[e.RowIndex].Cells)
                        {
                            celda.Style.BackColor = Color.LightGreen;

                        }
                        break;
                    case "PRIMA":
                        foreach (DataGridViewCell celda in this.dtgDatosPlanilla.Rows[e.RowIndex].Cells)
                        {
                            celda.Style.BackColor = Color.Orange;

                        }
                        break;
                    case "HABITAT":
                        foreach (DataGridViewCell celda in this.dtgDatosPlanilla.Rows[e.RowIndex].Cells)
                        {
                            celda.Style.BackColor = Color.Red;

                        }
                        break;
                    case "INTEGRA":
                        foreach (DataGridViewCell celda in this.dtgDatosPlanilla.Rows[e.RowIndex].Cells)
                        {
                            celda.Style.BackColor = Color.LightBlue;

                        }
                        break;
                    default:
                        break;
                }
                
            }
        }

        private void dtgDatosExcel_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dtgDatosExcel.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    switch (dtgDatosExcel.Rows[e.RowIndex].Cells["AFP"].Value.ToString())
                    {
                        case "PROFUTURO":
                            foreach (DataGridViewCell celda in this.dtgDatosExcel.Rows[e.RowIndex].Cells)
                            {
                                celda.Style.BackColor = Color.LightGreen;

                            }
                            break;
                        case "PRIMA":
                            foreach (DataGridViewCell celda in this.dtgDatosExcel.Rows[e.RowIndex].Cells)
                            {
                                celda.Style.BackColor = Color.Orange;

                            }
                            break;
                        case "HABITAT":
                            foreach (DataGridViewCell celda in this.dtgDatosExcel.Rows[e.RowIndex].Cells)
                            {
                                celda.Style.BackColor = Color.Red;

                            }
                            break;
                        case "INTEGRA":
                            foreach (DataGridViewCell celda in this.dtgDatosExcel.Rows[e.RowIndex].Cells)
                            {
                                celda.Style.BackColor = Color.LightBlue;

                            }
                            break;
                        default:
                            break;
                    }

                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("Error al cargar archivo: " + EX.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void frmCompararDatosAFP_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            Rectangle rectangulo = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush brocha = new LinearGradientBrush(rectangulo, Color.SteelBlue, Color.LightSteelBlue, LinearGradientMode.ForwardDiagonal);
            gr.FillRectangle(brocha, rectangulo);
        }

        private void dtgDatosPlanilla_Scroll(object sender, ScrollEventArgs e)
        {
            if ((e.ScrollOrientation == ScrollOrientation.VerticalScroll) & (dtgDatosExcel.Rows.Count > 0)  )
            {
                dtgDatosExcel.FirstDisplayedScrollingRowIndex = e.NewValue; 
                
            }
           
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgDatosPlanilla.SelectedRows.Count > 0)
                {
                    CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador miRegimenPensionarioTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();
                    miRegimenPensionarioTrabajador = miRegimenPensionarioTrabajador.TraerRegimenPensionario(Convert.ToInt16(dtgDatosPlanilla.SelectedRows[0].Cells[7].Value));

                    Trabajador.frmRegimenPensionarioTrabajador fRegimenPensionarioTrabajador = new Trabajador.frmRegimenPensionarioTrabajador();
                    fRegimenPensionarioTrabajador.RecibirDatos(miRegimenPensionarioTrabajador.IdtRegimenPensionarioTrabajador, miRegimenPensionarioTrabajador.FechaInicio, miRegimenPensionarioTrabajador.FechaFin, miRegimenPensionarioTrabajador.CUSPP, miRegimenPensionarioTrabajador.TipoComision, miRegimenPensionarioTrabajador.IdtAFP, dtgDatosPlanilla.SelectedRows[0].Cells["nombre"].Value.ToString(), miRegimenPensionarioTrabajador.IdtPeriodoTrabajador, 2,miRegimenPensionarioTrabajador.FechaInicio, "");
                    if (fRegimenPensionarioTrabajador.ShowDialog() == DialogResult.OK)
                    {
                        Iniciar();
                        if (dtgDatosExcel.RowCount > 0)
                        {
                            CompararResultados();
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila completa en el detalle de la izquierda.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en actualizar la afp. " + ex.Message, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgDatosPlanilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((dtgDatosPlanilla.Columns[e.ColumnIndex].Name == "colCheck") && oComparativoAFP.ListaDetalles.Count > 0 )
            {
                cDetalleComparativoAFP auxiliar = new cDetalleComparativoAFP();

                auxiliar = oComparativoAFP.ListaDetalles.Find(x => x.Fila == e.RowIndex);

                if (auxiliar.ErrorAFP)
                {
                    mnuAFPError.Text = "Existe error en AFP";
                }
                else
                {
                    mnuAFPError.Text = "";
                }

                if (auxiliar.ErrorCUSPP)
                {
                    mnuCUSSPError.Text = "Existe error en el CUSSP";
                }
                else
                {
                    mnuCUSSPError.Text = "";
                }

                if (auxiliar.ErrorComision)
                {
                    mnuComisionError.Text = "Existe error en la comision";
                }
                else
                {
                    mnuComisionError.Text = "";
                }

                //mnuAFP.Left = dtgDatosPlanilla.Left + dtgDatosPlanilla.Size.Width; // dtgDatosPlanilla[e.ColumnIndex, e.RowIndex].Size.Width;
                //mnuAFP.Top = dtgDatosPlanilla.Top + dtgDatosPlanilla[e.ColumnIndex, e.RowIndex].Size.Height;

                mnuAFP.Show();
            }
        }
    }
}
