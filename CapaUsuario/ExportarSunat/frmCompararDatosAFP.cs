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
            fichero.Filter = "Excel (*.xls)|*.xls|Excel (*.xlsx)|*.xlsx";
            fichero.FileName = "consultaCUSPPMasiva.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                LLenarGrid(fichero.FileName, "Sheet0");
            }
        }

        private void LLenarGrid(string archivo, string hoja)
        {
            //declaramos las variables         
            OleDbConnection conexion = null;
            DataSet dataSet = null;
            OleDbDataAdapter dataAdapter = null;
            string consultaHojaExcel = "Select * from [" + hoja + "$]";

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
        

        }

        private void frmCompararDatosAFP_Load(object sender, EventArgs e)
        {
            dtgDatosPlanilla.DataSource = detallePlanilla.ListarDetallePlanillaParaAFP(planilla.IdtPlanilla);
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

        private void frmCompararDatosAFP_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            Rectangle rectangulo = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush brocha = new LinearGradientBrush(rectangulo, Color.SteelBlue, Color.LightSteelBlue, LinearGradientMode.ForwardDiagonal);
            gr.FillRectangle(brocha, rectangulo);
        }
    }
}
