using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

using System.Data;
using System.Data.SqlClient;


namespace CapaUsuario.Reportes
{
    public partial class frmPlanilla : Form
    {
        

        string numeroPlanilla = "";

        public frmPlanilla()
        {
            InitializeComponent();
        }

        public int BuscarIndiceColumna(DataTable odtPrueba, string titulo_columna)
        {
            int k = 0;
            //reseteando contador de indice de ingreso
            k = 0;
            int indice_titulo_buscado = -1;
            //Determinar si existe el tipo de ingreso en las columnas de odtPrueba
            foreach (DataColumn column in odtPrueba.Columns)
            {
                //comparar si el nombre de columna del datatable es igual a la descripcion del ingreso
                if (column.ColumnName.ToString().Trim() == titulo_columna.Trim())
                {
                    //guardar indice de tipo ingreso
                    indice_titulo_buscado = k;
                }
                k++;
            }

            return indice_titulo_buscado;
        }

        public bool ExisteColumna(DataTable odtPrueba, DataRow row_i)
        {

            bool fIngreso = false;

            //reseteando contador de indice de ingreso

            fIngreso = false;
            //Determinar si existe el tipo de ingreso en las columnas de odtPrueba
            foreach (DataColumn column in odtPrueba.Columns)
            {
                //comparar si el nombre de columna del datatable es igual a la descripcion del ingreso
                if (column.ColumnName.ToString().Trim() == row_i[9].ToString().Trim())
                {
                    //guardar indice de tipo ingreso
                    fIngreso = true;
                }

            }

            return fIngreso;
        }

        public bool ExisteColumnaTexto(DataTable odtPrueba, string row_i)
        {

            bool fIngreso = false;

            //reseteando contador de indice de ingreso

            fIngreso = false;
            //Determinar si existe el tipo de ingreso en las columnas de odtPrueba
            foreach (DataColumn column in odtPrueba.Columns)
            {
                //comparar si el nombre de columna del datatable es igual a la descripcion del ingreso
                if (column.ColumnName.ToString().Trim() == row_i)
                {
                    //guardar indice de tipo ingreso
                    fIngreso = true;
                }

            }

            return fIngreso;
        }

        private void crvPlanilla_Load(object sender, EventArgs e)
        {
             
        }

        private void frmPlanilla_Load(object sender, EventArgs e)
        {
            
        }

        public void RecibirDatos(string pnumeroPlanilla)
        {
            this.numeroPlanilla = pnumeroPlanilla;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
