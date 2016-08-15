using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Reportes
{
    public partial class fPrueba : Form
    {

        

        /*
        DataTable oDataMaestroIngresos = new DataTable();
        DataTable oDataMaestroDescuentos = new DataTable();
        DataTable oDataMaestroATrabajador = new DataTable();
        DataTable oDataMaestroAEmpleador = new DataTable();
        */

        public fPrueba()
        {
            InitializeComponent();
        }

        private void dgvPrueba_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        

        private void fPrueba_Load(object sender, EventArgs e)
        {
            DataTable odtPrueba = new DataTable();
            DataTable odtPlanilla = new DataTable();
            DataTable odtPlanillaXIngresos = new DataTable(); 
            CapaDeNegocios.Planillas.cDetallePlanilla oPlanilla = new CapaDeNegocios.Planillas.cDetallePlanilla();
            CapaDeNegocios.Planillas.cDetallePlanillaIngresos oPlanillaIngresos = new CapaDeNegocios.Planillas.cDetallePlanillaIngresos();
            CapaDeNegocios.Planillas.cDetallePlanillaDescuentos oPlanillaDescuentos = new CapaDeNegocios.Planillas.cDetallePlanillaDescuentos();
            CapaDeNegocios.Planillas.cDetallePlanillaATrabajador oPlanillaTrabajador = new CapaDeNegocios.Planillas.cDetallePlanillaATrabajador();
            CapaDeNegocios.Planillas.cDetallePlanillaAEmpleador oPlanillaEmpleador = new CapaDeNegocios.Planillas.cDetallePlanillaAEmpleador();



            /*
            foreach (DataRow row in oDataPrueba.Rows)
            {
                //dgvPrueba.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());

            }
            */

            //Mes  y Regimen laboral

            int pRegimenLaboral = 1;
            string pMes = "ENERO";
            int pidTrabajador = 0;
            int indice_ingreso = 0;


            DataRow drFila = odtPrueba.NewRow();

            //Establecer titulos de la planilla

            odtPrueba.Columns.Add("Nombre Completo", typeof(string));
            odtPrueba.Columns.Add("Cargo", typeof(string));
            odtPrueba.Columns.Add("DNI", typeof(string));
            odtPrueba.Columns.Add("Renumeración", typeof(string));
            odtPrueba.Columns.Add("Fecha Inicio", typeof(string));
            odtPrueba.Columns.Add("Renumeración Total", typeof(string));
            odtPrueba.Columns.Add("Sec. Func.", typeof(string));
            odtPrueba.Columns.Add("AFIL. AFP/SNP", typeof(string));
            odtPrueba.Columns.Add("Comisión", typeof(string));
            odtPrueba.Columns.Add("CUSP", typeof(string));

            //realizar consulta para planilla por mes y regimen laboral


            //odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboral(pMes, pRegimenLaboral);
            //Determinar si la consulta esta vacio
            odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboral(pMes, pRegimenLaboral);
            

            //recorrer consulta de planilla por mes y regimen laboral
            foreach (DataRow row in odtPlanilla.Rows)
            {
                //Determinar en base al id del trabajador sus ingresos
                pidTrabajador = Convert.ToInt32(row[6]);
                odtPlanillaXIngresos = oPlanillaIngresos.spListarPlanillaXIngresos(pMes, pRegimenLaboral, pidTrabajador);

                foreach (DataRow row_i in odtPlanillaXIngresos.Rows)
                {
                    // si no existe columna agregar titulo
                    if (!ExisteColumna(odtPrueba, row_i))
                        odtPrueba.Columns.Add(row_i[9].ToString().Trim(), typeof(string));

                    //Buscar indice del titulo respectivo al monto
                    indice_ingreso = BuscarIndiceColumna(odtPrueba, row_i[9].ToString());

                    //insertar monto de ingresos a la planilla
                    drFila[indice_ingreso] = row_i[10].ToString();
                }

                //insertar datos personales de la planilla al datatable
                drFila[0] = row[0].ToString(); drFila[3] = row[3].ToString(); drFila[6] = row[6].ToString();
                drFila[1] = row[1].ToString(); drFila[4] = row[4].ToString(); drFila[7] = row[7].ToString();
                drFila[2] = row[2].ToString(); drFila[5] = row[5].ToString(); drFila[8] = row[8].ToString();

                odtPrueba.Rows.Add(drFila);


                /*
                for (int i=0; i< odtPrueba.Columns.Count; i++ ) {
                    odtPrueba.Columns
                }
                */

                //odtPrueba.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());

                //oDataPlanillaXIngresos = oPlanillaIngresos.spListarPlanillaXIngresos("ENERO", 1, Convert.ToInt32(row[3]));


                /*
                foreach (DataRow row in oDataPlanillaXIngresos.Rows)
                {

                }
                */

                dgvPrueba.DataSource = odtPrueba;
           }


 
        }
    }
}
