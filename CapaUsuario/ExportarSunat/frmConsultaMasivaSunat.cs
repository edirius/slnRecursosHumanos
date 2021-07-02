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
            DataGridViewCheckBoxColumn Check = new DataGridViewCheckBoxColumn();//creamos un objeto check
            {
                Check.Name = "☑";//le damos un nombre de cabecera
                dgvListarPlanillas.Columns.Add(Check);//agregamos los check a cada items

            }
            dgvListarPlanillas.Columns["☑"].DisplayIndex = 0;
            dgvListarPlanillas.Columns["☑"].ReadOnly = false;
            dgvListarPlanillas.Columns["☑"].Width = 30;

        }

        private void CargarGrid()
        {
            dgvListarPlanillas.DataSource = oEXP.BuscarPlanillas(cbMes.Text, cbAños.Text);
            dgvListarPlanillas.Columns[0].Visible = false;
            dgvListarPlanillas.Columns[1].Width = 50;
            dgvListarPlanillas.Columns[2].Width = 75;
            dgvListarPlanillas.Columns[3].Width = 50;
            dgvListarPlanillas.Columns[4].Width = 130;
            dgvListarPlanillas.Columns[5].Width = 637;
            dgvListarPlanillas.Columns[6].Width = 300;
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
        public void CargarMes(DateTime FechaActual)
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
        private void ExportarDataGridViewExcel(DataGridView datagrid)
        {
            //añadir la siguiente referencia al proyecto de tipo COM:
            //Microsoft Excel 12.0 Object Library

            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            fichero.FileName = "AFPCargaMasiva.xls";
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
                        
                        hoja_trabajo.Cells[i + 1, j + 1] = "'" + datagrid.Rows[i].Cells[j].Value.ToString();
                    }

                }
                libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                MessageBox.Show("Los datos fueron exportados.");
                aplicacion.Quit();
            }
        }
        private void btnExportar_Click(object sender, EventArgs e)
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
            dgvListarPlanillas.DataSource = oEXP.BuscarPlanillas(cbMes.Text, cbAños.Text);
            checkSeleccionar.Checked = false;

        }
        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar();
            dgvListarPlanillas.Columns["Nro"].Width = 50;
        }

        private void cbAños_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar();
            dgvListarPlanillas.Columns["Nro"].Width = 50;
        }

        private void bntListarTodo_Click(object sender, EventArgs e)
        {
            dgvListarPlanillas.DataSource = oEXP.ListarPlanillas(cbAños.Text);
            dgvListarPlanillas.Columns["Nro"].Width = 50;
            checkSeleccionar.Checked = false;
        }
        private void ListarTrabajadores()
        {
            LimpiarGrid();
            foreach (DataGridViewRow fila in dgvListarPlanillas.Rows)
            {
                if (Convert.ToBoolean(fila.Cells["☑"].Value) == true)
                {
                    string Valor = fila.Cells["idtplanilla"].Value.ToString();
                    dgv1.DataSource = oEXP.ConsultaMasivaAFP(Valor);
                    AgregarTrabajadores();

                }

            }
        }
        private void AgregarTrabajadores()
        {

            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                dgv2.Rows.Add(new string[]
                {  Convert.ToString(dgv1[0, i].Value),
                   Convert.ToString(dgv1[1, i].Value)
                });
            }
            
        }
        private void LimpiarGrid()
        {
            dgv2.Rows.Clear();
        }

        private void dgvListarPlanillas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Valor = dgvListarPlanillas.CurrentCell.RowIndex;
            string numero = "";
            numero = dgvListarPlanillas[1, Valor].Value.ToString();
            dgv1.DataSource = oEXP.ConsultaMasivaAFP(numero.ToString());
        }

        private void checkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSeleccionar.Checked == true)
            {
                for (int i = 0; i < dgvListarPlanillas.Rows.Count; i++)
                {
                    dgvListarPlanillas[0, i].Value = true;
                }
            }
            else
                for (int i = 0; i < dgvListarPlanillas.Rows.Count; i++)
                {
                    dgvListarPlanillas[0, i].Value = false;
                }
        }

        private void frmConsultaMasivaSunat_Load(object sender, EventArgs e)
        {

        }

        private void btnComparar_Click(object sender, EventArgs e)
        {
            if (dgvListarPlanillas.SelectedRows.Count > 0  )
            {
                frmCompararDatosAFP fCompararDatosAFP = new frmCompararDatosAFP();
                fCompararDatosAFP.planilla = new CapaDeNegocios.Planillas.cPlanilla();
                fCompararDatosAFP.planilla = fCompararDatosAFP.planilla.TraerPlanilla(Convert.ToInt16(dgvListarPlanillas.SelectedRows[0].Cells[1].Value));  
                fCompararDatosAFP.ShowDialog();
            }
          else
            {
                MessageBox.Show("Debe seleccionar una planilla.");
            }
        }
    }
}
