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
            DataGridViewCheckBoxColumn Check = new DataGridViewCheckBoxColumn();//creamos un objeto check
            {
                Check.Name = "☑";//le damos un nombre de cabecera
                dgvListaPlanillas.Columns.Add(Check);//agregamos los check a cada items

            }
            dgvListaPlanillas.Columns["☑"].DisplayIndex = 0;
            dgvListaPlanillas.Columns["☑"].ReadOnly = false;
            dgvListaPlanillas.Columns["☑"].Width = 30;
        }
        private void CargarGrid()
        {
            dgvListaPlanillas.DataSource = oexp.BuscarPlanillas(cbMes.Text, cbAños.Text);
            dgvListaPlanillas.Columns[0].Visible = false;
            dgvListaPlanillas.Columns[1].Width = 50;
            dgvListaPlanillas.Columns[2].Width = 75;
            dgvListaPlanillas.Columns[3].Width = 50;
            dgvListaPlanillas.Columns[4].Width = 130;
            dgvListaPlanillas.Columns[5].Width = 637;
            dgvListaPlanillas.Columns[6].Width = 300;
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
                for (int i = 0; i < dgv2.Rows.Count; i++)
                {

                    for (int j = 0; j < dgv2.Columns.Count; j++)
                    {
                        //if (headr <= datagrid.Columns.Count)//añadimos cabecera de excel
                        //{
                        //    string cabesa = datagrid.Columns[j].HeaderCell.Value.ToString();
                        //    hoja_trabajo.Cells[i + 1, j + 1] = datagrid.Columns[j].HeaderCell.Value.ToString();
                        //    headr++;
                        //}
                        //añadimos contenido de excel
                        hoja_trabajo.Cells[i + 1, j + 1] = dgv2.Rows[i].Cells[j].Value.ToString();
                    }

                }
                libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                MessageBox.Show("Los datos fueron exportados exitosamente.");
                aplicacion.Quit();
            }
        }
        //private void ExportarExcel()
        //{
        //    Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
        //    Workbook wb = Excel.Workbooks.Add(XlSheetType.xlWorksheet);
        //    Worksheet ws = (Worksheet)Excel.ActiveSheet;
        //    Excel.Visible = true;
        //    //Para poner Título en la cabecera de las Columnas del Excel
        //    ws.Cells[1, 1] = "";
        //    for (int j = 2; j <= dgv2.Rows.Count; j++)//J debe ser igual a 2 en caso de que tenga titulo en las columnas
        //    {
        //        for (int i = 1; i <= dgv2.Columns.Count; i++)
        //        {
        //            ws.Cells[j, i] = dgv2.Rows[j - 1].Cells[i - 1].Value;
        //        }

        //    }
        //}
        private void btnExport_Click_1(object sender, EventArgs e)
        {
            ListarTrabajadores();
            try
            {
                if (dgv2.Rows.Count != 0)
                {
                    ExportarDataGridViewExcel(dgv2);
                }
                else
                    MessageBox.Show("No se encontraron datos para la exportación.");

            }
            catch
            {
                MessageBox.Show("Cierre antes el otro archivo Excel.");
            }
            

        }
        private void Buscar()
        {
            dgvListaPlanillas.DataSource = oexp.BuscarPlanillas(cbMes.Text, cbAños.Text);
            
        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar();
            dgvListaPlanillas.Columns["Nro"].Width = 50;
        }

        private void cbAños_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar();
            dgvListaPlanillas.Columns["Nro"].Width = 50;
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
        private void dgvListaPlanillas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Valor = dgvListaPlanillas.CurrentCell.RowIndex;
            string numero = "";
            numero = dgvListaPlanillas[1, Valor].Value.ToString();
            dataGridView.DataSource = oexp.ListarExportarAFPaExcel(numero.ToString());
        }

        private void dgvListaPlanillas_SelectionChanged(object sender, EventArgs e)
        {
            //int Valor = dgvListaPlanillas.CurrentCell.RowIndex;
            //string numero = "";
            //numero = dgvListaPlanillas[1, Valor].Value.ToString();
            //dataGridView.DataSource = oexp.ListarExportarAFPaExcel(numero.ToString());
        }

        private void bntListarTodo_Click(object sender, EventArgs e)
        {
            dgvListaPlanillas.DataSource = oexp.ListarPlanillas(cbAños.Text);
            dgvListaPlanillas.Columns["Nro"].Width = 50;

        }
        private void ListarTrabajadores()
        {
            LimpiarGrid();
            foreach (DataGridViewRow fila in dgvListaPlanillas.Rows)
            {
                if (Convert.ToBoolean(fila.Cells["☑"].Value) == true)
                {
                    string Valor = fila.Cells["idtplanilla"].Value.ToString();
                    dataGridView.DataSource = oexp.ListarExportarAFPaExcel(Valor);
                    AgregarTrabajadores();

                }

            }
        }
        private void AgregarTrabajadores()
        {
            
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                dgv2.Rows.Add(new string[]
                {  Convert.ToString(dataGridView[0, i].Value),
                   Convert.ToString(dataGridView[1, i].Value),
                   Convert.ToString(dataGridView[2, i].Value),
                   Convert.ToString(dataGridView[3, i].Value),
                   Convert.ToString(dataGridView[4, i].Value),
                   Convert.ToString(dataGridView[5, i].Value),
                   Convert.ToString(dataGridView[6, i].Value),
                   Convert.ToString(dataGridView[7, i].Value),
                   Convert.ToString(dataGridView[8, i].Value),
                   Convert.ToString(dataGridView[9, i].Value),
                   Convert.ToString(dataGridView[10, i].Value),
                   Convert.ToString(dataGridView[11, i].Value),
                   Convert.ToString(dataGridView[12, i].Value),
                   Convert.ToString(dataGridView[13, i].Value),
                   Convert.ToString(dataGridView[14, i].Value),
                   Convert.ToString(dataGridView[15, i].Value)
                });
            }
            numerar();
            cont = 1;
        }
        private void LimpiarGrid()
        {
            dgv2.Rows.Clear();
        }
        private void numerar()
        {
            for (int i = 0; i < dgv2.Rows.Count; i++)
            {
                dgv2.Rows[i].Cells["Numero"].Value = cont;
                cont = cont + 1;
            }
        }
        int cont = 1;
    }
}
//