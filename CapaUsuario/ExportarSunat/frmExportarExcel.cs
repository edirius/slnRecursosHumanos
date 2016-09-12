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
        public frmExportarExcel()
        {
            InitializeComponent();
            cbAños.Text = "2015";
            cbMes.Text = "ENERO";
            CargarAños();
            cargargrid();
        }
        private void cargargrid()
        {
            //dataGridView.DataSource = oexp.ListarExportarAFPaExcel(cbMes.ToString(), cbAños.ToString());
            //dataGridView.Columns[3].Width = 400;
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
            cbAños.Text = "2015";
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
                aplicacion.Quit();
                MessageBox.Show("Exitoso");
            }
        }
        private void ExportarExcel()
        {
            Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = Excel.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)Excel.ActiveSheet;
            Excel.Visible = true;
            //Para poner Título en la cabecera de las Columnas del Excel
            ws.Cells[1, 1] = "TipoDoc";
            ws.Cells[1, 2] = "NroDoc";
            ws.Cells[1, 3] = "Titulo2";
            ws.Cells[1, 4] = "";
            ws.Cells[1, 5] = "";
            ws.Cells[1, 6] = "";
            ws.Cells[1, 7] = "";
            ws.Cells[1, 8] = "";
            ws.Cells[1, 9] = "";
            ws.Cells[1, 10] = "";
            ws.Cells[1, 11] = "";
            ws.Cells[1, 12] = "";
            ws.Cells[1, 13] = "";
            ws.Cells[1, 14] = "";
            ws.Cells[1, 15] = "";
            ws.Cells[1, 16] = "";
            ws.Cells[1, 17] = "";
            ws.Cells[1, 18] = "";
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
            ExportarDataGridViewExcel(dataGridView);
            //if (dataGridView.Rows.Count != 0)
            //{
            //    MessageBox.Show("Los datos fueron exportados exitosamente.");
            //    ExportarExcel();
            //}
            //else
            //    MessageBox.Show("No se encontraron datos para la exportación.");

        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView.DataSource = oexp.ListarExportarAFPaExcel(cbMes.Text, cbAños.Text);
        }

        private void cbAños_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView.DataSource = oexp.ListarExportarAFPaExcel(cbMes.Text, cbAños.Text);
        }
    }
}
