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
            /*Reporte en datatable de plantilla*/

            DataTable odtPrueba = new DataTable();
            DataTable odtPlanilla = new DataTable();
            DataTable odtPlanillaXIngresos = new DataTable();
            DataTable odtPlanillaXDescuentos = new DataTable();
            DataTable odtPlanillaAEmpleador = new DataTable();
            DataTable odtPlanillaATrabajador = new DataTable();


            CapaDeNegocios.Planillas.cDetallePlanilla oPlanilla = new CapaDeNegocios.Planillas.cDetallePlanilla();
            CapaDeNegocios.Planillas.cDetallePlanillaIngresos oPlanillaIngresos = new CapaDeNegocios.Planillas.cDetallePlanillaIngresos();
            CapaDeNegocios.Planillas.cDetallePlanillaDescuentos oPlanillaDescuentos = new CapaDeNegocios.Planillas.cDetallePlanillaDescuentos();
            CapaDeNegocios.Planillas.cDetallePlanillaATrabajador oPlanillaTrabajador = new CapaDeNegocios.Planillas.cDetallePlanillaATrabajador();
            CapaDeNegocios.Planillas.cDetallePlanillaAEmpleador oPlanillaEmpleador = new CapaDeNegocios.Planillas.cDetallePlanillaAEmpleador();

            //Mes  y Regimen laboral

            int pRegimenLaboral = 1;
            string pMes = "ENERO";
            string pAño = "";

            int pidTrabajador = 0;
            int indice_ingreso = 0;
            int indice_descuento = 0;
            int indice_a_empleador = 0;
            int indice_a_trabajador = 0;

            int total_tipo_ingreso = 0;
            int total_tipo_descuento = 0;
            int total_tipo_a_empleador = 0;
            int total_tipo_a_trabajador = 0;

            int k = 0;
            DataRow drFila = odtPrueba.NewRow();

            //Establecer titulos de la planilla

            odtPrueba.Columns.Add("NOMBRE COMPLETO", typeof(string));
            odtPrueba.Columns.Add("CARGO", typeof(string));
            odtPrueba.Columns.Add("DNI", typeof(string));
            odtPrueba.Columns.Add("REMUNERACION", typeof(string));
            odtPrueba.Columns.Add("FECHA INICIO", typeof(string));
            odtPrueba.Columns.Add("REMUNERACION TOTAL", typeof(string));
            odtPrueba.Columns.Add("SEC. FUNC.", typeof(string));
            odtPrueba.Columns.Add("AFIL. AFP/SNP", typeof(string));
            odtPrueba.Columns.Add("COMISION", typeof(string));
            odtPrueba.Columns.Add("CUSP", typeof(string));

            //realizar consulta para planilla por mes y regimen laboral


            //odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboral(pMes, pRegimenLaboral);
            //Determinar si la consulta esta vacio
            odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboral(pAño,pMes, pRegimenLaboral);

            odtPrueba.Clear();

            //recorrer consulta de planilla por mes y regimen laboral
            foreach (DataRow row in odtPlanilla.Rows)
            {

                drFila = odtPrueba.NewRow();
                drFila.Delete();
                //Determinar en base al id del trabajador sus ingresos
                pidTrabajador = Convert.ToInt32(row[6]);
                odtPlanillaXIngresos = oPlanillaIngresos.spListarPlanillaXIngresos(pAño, pMes, pRegimenLaboral, pidTrabajador);

                foreach (DataRow row_i in odtPlanillaXIngresos.Rows)
                {
                    // si no existe columna agregar titulo
                    if (!ExisteColumna(odtPrueba, row_i))
                    {
                        odtPrueba.Columns.Add(row_i[9].ToString().Trim(), typeof(string));
                        total_tipo_ingreso++;
                    }
                    //Buscar indice del titulo respectivo al monto
                    indice_ingreso = BuscarIndiceColumna(odtPrueba, row_i[9].ToString());

                    //insertar monto de ingresos a la planilla
                    if (row_i[10].ToString() == "")
                        drFila[indice_ingreso] = 0.00;
                    else
                        drFila[indice_ingreso] = row_i[10];
                }

                //Insertando la sumatoria total de ingresos
                // Insertando la descripcion de columna del total de ingresos
                if (!ExisteColumnaTexto(odtPrueba, "TOTAL INGRESOS"))
                    odtPrueba.Columns.Add("TOTAL INGRESOS", typeof(string));

                //Buscar indice del titulo respectivo al monto
                indice_ingreso = BuscarIndiceColumna(odtPrueba, "TOTAL INGRESOS");

                //insertar monto total de ingresos a la planilla
                drFila[indice_ingreso] = row[15].ToString();


                //Determinar en base al id del trabajador sus descuentos
                odtPlanillaXDescuentos = oPlanillaDescuentos.spListarPlanillaXDescuentos(pAño,pMes, pRegimenLaboral, pidTrabajador);

                foreach (DataRow row_d in odtPlanillaXDescuentos.Rows)
                {
                    // si no existe columna agregar titulo
                    if (!ExisteColumna(odtPrueba, row_d))
                    {
                        odtPrueba.Columns.Add(row_d[9].ToString().Trim(), typeof(string));
                        total_tipo_descuento++;
                    }
                    //Buscar indice del titulo respectivo al monto
                    indice_descuento = BuscarIndiceColumna(odtPrueba, row_d[9].ToString());

                    //insertar monto de ingresos a la planilla
                    if (row_d[10].ToString() == "")
                        drFila[indice_descuento] = 0.00;
                    else
                        drFila[indice_descuento] = row_d[10];

                }

                //Insertando la sumatoria total de descuentos
                // Insertando la descripcion de columna del total de descuentos
                if (!ExisteColumnaTexto(odtPrueba, "TOTAL DESCUENTOS"))
                    odtPrueba.Columns.Add("TOTAL DESCUENTOS", typeof(string));

                //Buscar indice del titulo respectivo al monto
                indice_descuento = BuscarIndiceColumna(odtPrueba, "TOTAL DESCUENTOS");

                //insertar monto total de descuentos a la planilla
                drFila[indice_descuento] = row[14].ToString();

                //Determinar en base al id del trabajador sus aportaciones del trabajador
                odtPlanillaATrabajador = oPlanillaTrabajador.ListarPlanillaATrabajador(pAño,pMes, pRegimenLaboral, pidTrabajador);

                foreach (DataRow row_t in odtPlanillaATrabajador.Rows)
                {
                    // si no existe columna agregar titulo
                    if (!ExisteColumna(odtPrueba, row_t))
                    {
                        odtPrueba.Columns.Add(row_t[9].ToString().Trim(), typeof(string));
                        total_tipo_a_trabajador++;
                    }
                    //Buscar indice del titulo respectivo al monto
                    indice_a_trabajador = BuscarIndiceColumna(odtPrueba, row_t[9].ToString());

                    //insertar monto de ingresos a la planilla
                    if (row_t[10].ToString() == "")
                        drFila[indice_a_trabajador] = 0.00;
                    else
                        drFila[indice_a_trabajador] = row_t[10];

                }

                //Insertando la sumatoria total de Aportaciones Empleador
                // Insertando la descripcion de columna del total de Empleador
                if (!ExisteColumnaTexto(odtPrueba, "TOTAL APORTACIONES TRABAJADOR"))
                    odtPrueba.Columns.Add("TOTAL APORTACIONES TRABAJADOR", typeof(string));

                //Buscar indice del titulo respectivo al monto
                indice_a_trabajador = BuscarIndiceColumna(odtPrueba, "TOTAL APORTACIONES TRABAJADOR");

                //insertar monto total de Empleador a la planilla
                drFila[indice_a_trabajador] = row[13].ToString();

                //Determinar en base al id del trabajador sus aportaciones del empleador
                odtPlanillaAEmpleador = oPlanillaEmpleador.ListarPlanillaAEmpleador(pAño,pMes, pRegimenLaboral, pidTrabajador);

                foreach (DataRow row_e in odtPlanillaAEmpleador.Rows)
                {
                    // si no existe columna agregar titulo
                    if (!ExisteColumna(odtPrueba, row_e))
                    {
                        odtPrueba.Columns.Add(row_e[9].ToString().Trim(), typeof(string));
                        total_tipo_a_empleador++;
                    }
                    //Buscar indice del titulo respectivo al monto
                    indice_a_empleador = BuscarIndiceColumna(odtPrueba, row_e[9].ToString());

                    //insertar monto de ingresos a la planilla
                    if (row_e[10].ToString() == "")
                        drFila[indice_a_empleador] = 0.00;
                    else
                        drFila[indice_a_empleador] = row_e[10];

                }

                //Insertando la sumatoria total de Aportaciones Empleador
                // Insertando la descripcion de columna del total de Empleador
                if (!ExisteColumnaTexto(odtPrueba, "TOTAL APORTACIONES EMPLEADOR"))
                    odtPrueba.Columns.Add("TOTAL APORTACIONES EMPLEADOR", typeof(string));

                //Buscar indice del titulo respectivo al monto
                indice_a_empleador = BuscarIndiceColumna(odtPrueba, "TOTAL APORTACIONES EMPLEADOR");

                //insertar monto total de Empleador a la planilla
                drFila[indice_a_empleador] = row[12].ToString();

                //insertar datos personales de la planilla al datatable

                drFila[0] = row[0]; drFila[3] = row[3]; drFila[6] = row[6];
                drFila[1] = row[1]; drFila[4] = row[4]; drFila[7] = row[7];
                drFila[2] = row[2]; drFila[5] = row[5]; drFila[8] = row[8]; drFila[9] = row[9];

                //odtPrueba.Rows.Add(drFila);
                odtPrueba.Rows.InsertAt(drFila, k);

                k++;
            }

            //Rellenar con 0.00  los campos en blanco

            for (int i = 0; i < odtPrueba.Columns.Count; i++)
            {
                for (int l = 0; l < odtPrueba.Rows.Count; l++)
                {
                    if (odtPrueba.Rows[l][i].ToString().Trim() == "")
                        odtPrueba.Rows[l][i] = "0.00";
                }
            }

            //Combinar celdas de columna cuando sean mayor a dos item para ingresos

            //Establecer origen de datos: odtPrueba a crystal report 
            //Crear dataset con los campos respectivos de odtPrueba
            //DataSet odsPrueba = new DataSet("Planilla");
            DataSet odsPrueba = new DataSet();

            //dsPlanilla odsPrueba = new dsPlanilla();

            //for (int m = 0; m < odtPrueba.Columns.Count; m++)
            //{}
            odsPrueba.Tables.Add(odtPrueba);
            //odsPrueba.Namespace = "y";
            //odsPrueba.Prefix = "x";

            //dgvPrueba.DataSource = odtPrueba;

            /*Fin reporte en datatable de plantilla*/


            /* Titulo y numero de planilla */

            bdpersonalEntities pe = new bdpersonalEntities();
            crPlanilla cr1 = new crPlanilla();
            ReportDocument rd = new ReportDocument();

            //numero de planilla
            CrystalDecisions.CrystalReports.Engine.TextObject to = (CrystalDecisions.CrystalReports.Engine.TextObject)cr1.ReportDefinition.ReportObjects["toNumero"];
            to.Text = numeroPlanilla;
            //this.crvPlanilla.ReportSource = cr1;
            //regimen laboral
            //cr1.SetParameterValue("pnumero", numeroPlanilla);
            ReportDocument oRep = new ReportDocument();
            ParameterField oPf = new ParameterField();
            ParameterFields oPfs = new ParameterFields();
            ParameterDiscreteValue oPdv = new ParameterDiscreteValue();

            oPf.Name = "pnumero";
            oPdv.Value = numeroPlanilla;
            oPf.CurrentValues.Add(oPdv);
            oPfs.Add(oPf);
            this.crvPlanilla.ParameterFieldInfo = oPfs;
            oRep.Load("C:/Users/ADVANCE/Source/Repos/slnRecursosHumanos/CapaUsuario/Reportes/crPlanilla.rpt");
            //this.crvPlanilla.ReportSource = oRep;
            //this.crvPlanilla.ReportSource = cr1;

            //ReportDocument ordPrueba = new ReportDocument();

            //ordPrueba.Load();
            //ordPrueba.Database.Tables[0].SetDataSource(odsPrueba.Tables[0]);

            cr1.SetDataSource(odsPrueba);
            this.crvPlanilla.ReportSource = cr1;
            
            this.crvPlanilla.Refresh();

            /*Fin titulo y numero de planilla*/

            /*
            cr1.SetDataSource(pe.tplanilla.Select(c => new
            {
                Id = c.idtplanilla,
                Numero = c.numero
            }).ToList());
            this.crvPlanilla.ReportSource = cr1;
            */
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
