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

namespace CapaUsuario.ExportarSunat
{
    public partial class frmExportarExcel : Form
    {
        CapaDeNegocios.ExportarSunat.cExportarSunat oexp = new CapaDeNegocios.ExportarSunat.cExportarSunat();
        public frmExportarExcel()
        {
            InitializeComponent();
            cargargrid();
        }
        private void cargargrid()
        {
            dataGridView.DataSource = oexp.ListarTrabajadores();
        }

        private void frmExportarExcel_Load(object sender, EventArgs e)
        {
            
        }

        private void btnExport_Click_1(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = Excel.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)Excel.ActiveSheet;
            Excel.Visible = true;
            ws.Cells[1, 1] = "";
            ws.Cells[1, 2] = "";
            ws.Cells[1, 3] = "";
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
            for (int j = 1; j <= dataGridView.Rows.Count; j++)//J debe ser igual a 2 en caso de que tenga titulo en las columnas
            {
                for (int i = 1; i <= dataGridView.Columns.Count; i++)
                {
                    ws.Cells[j, i] = dataGridView.Rows[j - 1].Cells[i - 1].Value;
                }

            }


        }
    }
}
