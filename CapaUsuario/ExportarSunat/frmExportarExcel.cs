using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CapaDeNegocios;

namespace CapaUsuario.ExportarSunat
{
    public partial class frmExportarExcel : Form
    {
        CapaDeNegocios.ExportarSunat.cExportarSunat oexp = new CapaDeNegocios.ExportarSunat.cExportarSunat();
        string FechaTexto = "";
        public frmExportarExcel()
        {
            InitializeComponent();
            DateTime Ahora = DateTime.Today;
            CargarMes(Ahora);
            cbMes.Text = FechaTexto;
            CargarAños();
            CargarGrid();
        }
        private void CargarGrid()
        {
            dataGridView.DataSource = oexp.ListarExportarAFPaExcel(cbMes.Text, cbAños.Text);
            dataGridView.Columns[0].Width = 50;
            dataGridView.Columns[1].Width = 90;
            dataGridView.Columns[2].Width = 50;
            dataGridView.Columns[3].Width = 70;
            dataGridView.Columns[4].Width = 150;
            dataGridView.Columns[5].Width = 150;
            dataGridView.Columns[6].Width = 150;
            dataGridView.Columns[7].Width = 90;
            dataGridView.Columns[8].Width = 90;
            dataGridView.Columns[9].Width = 90;
            dataGridView.Columns[10].Width = 90;
            dataGridView.Columns[1].Visible = false;
            dataGridView.Columns[2].Visible = false;
            dataGridView.Columns[7].Visible = false;
            dataGridView.Columns[8].Visible = false;
            dataGridView.Columns[9].Visible = false;
            dataGridView.Columns[10].Visible = false;
            dataGridView.Columns[12].Visible = false;
            dataGridView.Columns[13].Visible = false;
            dataGridView.Columns[14].Visible = false;
            dataGridView.Columns[15].Visible = false;
        }

        private void frmExportarExcel_Load(object sender, EventArgs e)
        {
            
        }
        private void CargarAños()
        {
            string años = "";
            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                cbAños.Items.Add(i);
            }
            cbAños.Text = años;
            cbAños.Text = Convert.ToString(DateTime.Now.Year);
        }
        private void ExportarDataGridViewExcel(DataGridView datagrid)
        {
            //añadir la siguiente referencia al proyecto de tipo COM:
            //Microsoft Excel 12.0 Object Library

            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            fichero.FileName = "AFP.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

                int headr = 1;
                //Recorremos el DataGridView rellenando la hoja de trabajo
                for (int i = 0; i < datagrid.Rows.Count; i++)
                {

                    for (int j = 0; j < datagrid.Columns.Count; j++)
                    {
                        //if (headr <= datagrid.Columns.Count)//añadimos cabecera de excel
                        //{
                        //    string cabesa = datagrid.Columns[j].HeaderCell.Value.ToString();
                        //    hoja_trabajo.Cells[i + 1, j + 1] = datagrid.Columns[j].HeaderCell.Value.ToString();
                        //    headr++;
                        //}
                        //añadimos contenido de excel
                        hoja_trabajo.Cells[i + 1, j + 1] = datagrid.Rows[i].Cells[j].Value.ToString();
                    }

                }
                libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                MessageBox.Show("Los datos fueron exportados exitosamente.");
                aplicacion.Quit();
            }
        }
        private void ExportarExcel()
        {
            Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = Excel.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)Excel.ActiveSheet;
            Excel.Visible = true;
            //Para poner Título en la cabecera de las Columnas del Excel
            ws.Cells[1, 1] = "";
            for (int j = 2; j <= dataGridView.Rows.Count; j++)//J debe ser igual a 2 en caso de que tenga titulo en las columnas
            {
                for (int i = 1; i <= dataGridView.Columns.Count; i++)
                {
                    ws.Cells[j, i] = dataGridView.Rows[j - 1].Cells[i - 1].Value;
                }

            }
        }
        private void btnExport_Click_1(object sender, EventArgs e)
        {
            
            if (dataGridView.Rows.Count != 0)
            {
                ExportarDataGridViewExcel(dataGridView);
                
            }
            else
                MessageBox.Show("No se encontraron datos para la exportación.");

        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView.DataSource = oexp.ListarExportarAFPaExcel(cbMes.Text, cbAños.Text);
        }

        private void cbAños_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView.DataSource = oexp.ListarExportarAFPaExcel(cbMes.Text, cbAños.Text);
        }
        private void CargarMes(DateTime FechaActual)
        {
            string Ahora = Convert.ToString(FechaActual.Date.Month);
            switch (Ahora)
            {
                case "1":
                    {
                        FechaTexto = "ENERO";
                        break;
                    }
                case "2":
                    {
                        FechaTexto = "FEBRERO";
                        break;
                    }
                case "3":
                    {
                        FechaTexto = "MARZO";
                        break;
                    }
                case "4":
                    {
                        FechaTexto = "ABRIL";
                        break;
                    }
                case "5":
                    {
                        FechaTexto = "MAYO";
                        break;
                    }
                case "6":
                    {
                        FechaTexto = "JUNIO";
                        break;
                    }
                case "7":
                    {
                        FechaTexto = "JULIO";
                        break;
                    }
                case "8":
                    {
                        FechaTexto = "AGOSTO";
                        break;
                    }
                case "9":
                    {
                        FechaTexto = "SETIEMBRE";
                        break;
                    }
                case "10":
                    {
                        FechaTexto = "OCTUBRE";
                        break;
                    }
                case "11":
                    {
                        FechaTexto = "NOVIEMBRE";
                        break;
                    }
                case "12":
                    {
                        FechaTexto = "DICIEMBRE";
                        break;
                    }

            }
        }

    }
}
