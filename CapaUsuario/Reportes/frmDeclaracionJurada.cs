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
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp;
using System.Runtime.InteropServices;

namespace CapaUsuario.Reportes
{
    public partial class frmDeclaracionJurada : Form
    {
        string paño = "";
        int id_trabajador = 0;

        public frmDeclaracionJurada()
        {
            InitializeComponent();
        }

        

        protected virtual bool IsFileinUse(FileInfo file, string path)
        {
            FileStream stream = null;

            if (!File.Exists(path))
            {
                return false;
            }
            else
            {
                try
                {
                    stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);

                }
                catch (IOException)
                {
                    //the file is unavailable because it is:
                    //still being written to
                    //or being processed by another thread
                    //or does not exist (has already been processed)
                    return true;

                }
                finally
                {
                    if (stream != null)
                        stream.Close();
                }
                return false;
            }
        }

        private void frmDeclaracionJurada_Load(object sender, EventArgs e)
        {
            CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();
            DataTable odtAños = new DataTable();

            odtAños = oPlanilla.ListarAñosPlanilla();
            cboAño.DataSource = odtAños;
            cboAño.DisplayMember = "añó";
            cboAño.ValueMember = "año";

            if (odtAños.Rows.Count > 0)
                cboAño.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CapaDeNegocios.Trabajadores.cTrabajadorCas oTrabajador = new CapaDeNegocios.Trabajadores.cTrabajadorCas();
            paño = cboAño.GetItemText(this.cboAño.SelectedItem);
            dgvDeclaracionJurada.DataSource = oTrabajador.ListarTrabajadoresParaDeclaracionJurada(paño);
            dgvDeclaracionJurada.Columns[1].Visible = false;
            dgvDeclaracionJurada.Columns[7].Visible = false;


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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataTable odtCabeza = new DataTable();
            DataTable odtDeclaracionJurada = new DataTable();
            DataTable odtAlcalde = new DataTable();
            DataTable odt2039 = new DataTable();

            int indice_2039 = 0;
            decimal monto_2039 = 0;


            DataRow odrCabeza = odtCabeza.NewRow();

            CapaDeNegocios.Trabajadores.cTrabajadorCas oTrabajador = new CapaDeNegocios.Trabajadores.cTrabajadorCas();

            /*Inicio de formato de declaracion jurada de nombramientos a contraloria */
            /*Cuadro 1 :*/
            odtAlcalde = oTrabajador.ListarAlcalde();

            odtCabeza.Columns.Clear();
            odtCabeza.Columns.Add("DATOS GENERAL DE LA ENTIDAD", typeof(string));

            odrCabeza = odtCabeza.NewRow();
            odrCabeza[0] = "ENTIDAD:";
            odrCabeza[1] = "MUNICIPALIDAD DISTRITAL DE CCATCCA";
            odtCabeza.Rows.InsertAt(odrCabeza, 0);

            odrCabeza = odtCabeza.NewRow();
            odrCabeza[0] = "DIRECCION:";
            odrCabeza[1] = "PLAZA DE ARMAS S/N DISTRITO DE CCATCCA";
            odtCabeza.Rows.InsertAt(odrCabeza, 1);

            odrCabeza = odtCabeza.NewRow();
            odrCabeza[0] = "NOMBRE DEL TITULAR DEL PLIEGO PRESUPUESTAL";
            odrCabeza[1] = odtAlcalde.Rows[0][0] ;
            odtCabeza.Rows.InsertAt(odrCabeza, 2);

            odrCabeza = odtCabeza.NewRow();
            odrCabeza[0] = "EJERCICIO PRESUPUESTAL";
            odrCabeza[1] = paño ;
            odtCabeza.Rows.InsertAt(odrCabeza, 3);

            odrCabeza = odtCabeza.NewRow();
            odrCabeza[0] = "FECHA:";
            odrCabeza[1] =  DateTime.Now ;
            odtCabeza.Rows.InsertAt(odrCabeza, 4);

            dgvCabeza.DataSource = odtCabeza;

            /* Fin cuadro 1  */
            /* Inicio cuadro 2 */

            odtDeclaracionJurada = oTrabajador.ListarDeclaracionJuradaNombramientoContraloria(id_trabajador, Convert.ToInt32(paño) );

            odt2039 = oTrabajador.ListarDeclaracionJNC(id_trabajador, Convert.ToInt32(paño),"2039");

            if (odt2039.Rows.Count > 0) {
                monto_2039 = Convert.ToDecimal(odt2039.Rows[0][4]);
                if (monto_2039 > 0 ) {
                    odtDeclaracionJurada.Columns.Add(odt2039.Rows[0][3].ToString(), typeof(string));
                    indice_2039 = BuscarIndiceColumna(odtDeclaracionJurada, "REMUNER. TOTAL");
                    if (indice_2039 != -1)
                        odtDeclaracionJurada.Rows[0][indice_2039] = odt2039.Rows[0][4];
                }
            }
            


            /*Fin cuadro 2*/
            /*Fin de formato de declaracion jurada de nombramientos a contraloria */



        }

        private void dgvDeclaracionJurada_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDeclaracionJurada_CellClick(object sender, DataGridViewCellEventArgs e)
        {
 
            if (e.RowIndex != -1)
            {
                id_trabajador = Convert.ToInt32(dgvDeclaracionJurada.Rows[e.RowIndex].Cells[0].Value);

            }
        }
    }
}
