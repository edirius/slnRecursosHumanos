using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CapaDeNegocios;

namespace CapaUsuario.ExportarSunat
{
    public partial class frmConsultaMasivaSunat : Form
    {
        CapaDeNegocios.ExportarSunat.cExportarSunat oEXP = new CapaDeNegocios.ExportarSunat.cExportarSunat();
        string FechaTexto = "";
        public frmConsultaMasivaSunat()
        {
            InitializeComponent();
            CargarGrid();
            DateTime Ahora = DateTime.Today;
            CargarMes(Ahora);
            cbMes.Text = FechaTexto;
            CargarAños();
            
        }

        private void CargarGrid()
        {
            dgvConsultaMasivaAFP.DataSource = oEXP.ConsultaMasivaAFP(cbMes.Text, cbAños.Text);
            dgvListarTrabajadores.DataSource = oEXP.ListarTrabajadoresporFechaInicio(cbMes.Text, cbAños.Text);
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
                        FechaTexto = "SEPTIEMBRE";
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
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvConsultaMasivaAFP.Rows.Count != 0)
            {
                ExportarDataGridViewExcel(dgvConsultaMasivaAFP);
            }
            else MessageBox.Show("No se encontraron datos para la exportacion");
        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvConsultaMasivaAFP.DataSource = oEXP.ConsultaMasivaAFP(cbMes.Text, cbAños.Text);
            dgvListarTrabajadores.DataSource = oEXP.ListarTrabajadoresporFechaInicio(cbMes.Text, cbAños.Text);
        }

        private void cbAños_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvConsultaMasivaAFP.DataSource = oEXP.ConsultaMasivaAFP(cbMes.Text, cbAños.Text);
            dgvListarTrabajadores.DataSource = oEXP.ListarTrabajadoresporFechaInicio(cbMes.Text, cbAños.Text);
        }
    }
}
