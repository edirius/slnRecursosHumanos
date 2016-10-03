using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            dtgDatosExcel.Columns[10].Visible = false;
            dtgDatosExcel.Columns[11].Visible = false;
            dtgDatosExcel.Columns[12].Visible = false;
            dtgDatosExcel.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure;

        }

        private void frmCompararDatosAFP_Load(object sender, EventArgs e)
        {
            dtgDatosPlanilla.DataSource = detallePlanilla.ListarDetallePlanillaParaAFP(planilla.IdtPlanilla);
            //for (int i = 0; i < dtgDatosPlanilla.Rows.Count -1; i++)
            //{
            //    dtgDatosPlanilla.Rows[i].Cells.
            //}
        }

        private void dtgDatosPlanilla_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           
           


        }

        private void dtgDatosPlanilla_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgDatosPlanilla.Rows[e.RowIndex].Cells[0].Value != null)
            {
                if (dtgDatosPlanilla.Rows[e.RowIndex].Cells["nombre"].Value.ToString() == "PROFUTURO")
                {
                    foreach (DataGridViewCell celda in this.dtgDatosPlanilla.Rows[e.RowIndex].Cells)
                    {
                        celda.Style.BackColor = Color.Orange;
   
                    }
                }

                
                
            }
        }
    }
}
