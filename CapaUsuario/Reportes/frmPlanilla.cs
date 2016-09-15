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
//using iTextSharp.text.pdf.PdfWriter;


namespace CapaUsuario.Reportes
{
    public partial class frmPlanilla : Form
    {
        DataTable odtPrueba = new DataTable();
        DataTable odtPruebaCorta = new DataTable();
        DataTable odtATrabajador = new DataTable();

        DataTable odtPlanilla = new DataTable();
        DataTable odtPlanillaXIngresos = new DataTable();
        DataTable odtPlanillaXDescuentos = new DataTable();
        DataTable odtPlanillaAEmpleador = new DataTable();
        DataTable odtPlanillaATrabajador = new DataTable();

        int sidtplanilla = 0;
        string snumero = "";
        string smes = "";
        string saño = "";
        DateTime sfecha;
        int sidtmeta = 0;
        int sidtfuentefinanciamiento = 0;
        int sidtregimenlaboral = 0;
        string smeta = "";
        string sfuentefinanciamiento = "";
        string sdescripcion = "";
        string splantilla = "";

        string sNumeroPlanilla = "";
        string sRegimenLaboral = "";

        //CapaUsuario.Reportes.frmPlanilla fPlanilla = new CapaUsuario.Reportes.frmPlanilla();
        CapaDeNegocios.Planillas.cPlanilla miPlanilla = new CapaDeNegocios.Planillas.cPlanilla();


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
                if (column.ColumnName.ToString().Trim() == row_i[8].ToString().Trim())
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
            CargarDatos();
        }

        public void RecibirDatos(string pnumeroPlanilla)
        {
            this.numeroPlanilla = pnumeroPlanilla;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void CargarDatos()
        {
            dgvPlanilla.Rows.Clear();
            DataTable oDataPlanilla = new DataTable();
            oDataPlanilla = miPlanilla.ListarPlanilla();

            DataTable oDataMeta = new DataTable();
            CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miMeta = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
            oDataMeta = miMeta.ListarMetas();
            DataTable oDataFuenteFinanciamiento = new DataTable();
            CapaDeNegocios.cFuenteFinanciamiento miFuenteFinanciamietno = new CapaDeNegocios.cFuenteFinanciamiento();
            oDataFuenteFinanciamiento = miFuenteFinanciamietno.ListarFuenteFinanciamiento();

            foreach (DataRow row in oDataPlanilla.Rows)
            {
                foreach (DataRow roww in oDataMeta.Select("idtmeta ='" + row[5].ToString() + "'"))
                {
                    sidtmeta = Convert.ToInt32(roww[0]);
                    smeta = roww[2].ToString();
                }
                foreach (DataRow roww in oDataFuenteFinanciamiento.Select("idtfuentefinanciamiento ='" + row[6].ToString() + "'"))
                {
                    sidtfuentefinanciamiento = Convert.ToInt32(roww[0]);
                    sfuentefinanciamiento = roww[2].ToString();
                }
                dgvPlanilla.Rows.Add(row[0].ToString(), row[1].ToString(), row[8].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), sidtmeta, smeta, sidtfuentefinanciamiento, sfuentefinanciamiento, row[7].ToString(), row[9].ToString());
            }
            if (dgvPlanilla.Rows.Count > 0)
            {
                DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, dgvPlanilla.Rows.Count - 1);
                dgvPlanilla.Rows[dgvPlanilla.Rows.Count - 1].Selected = true;
                dgvPlanilla_CellClick(dgvPlanilla, cea);
            }
        }

        private void dgvPlanilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvPlanilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        private int contarItems(string[] arr_obligaciones)
        {
            int items = 0;

            for (int i = 0; i < arr_obligaciones.Count(); i++)
            {
                if (arr_obligaciones[i] != null)
                    items++;
            }

            return items;
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

        protected bool estaSoloTitulo(DataTable odtPrueba, string titulo, string[] arr_obligaciones)
        {
            bool fTitulo = false;

            string celda_titulo = "";
            int indice_columna = 0;
            int total_obligaciones = arr_obligaciones.Count();

            for (int i = 0; i < total_obligaciones; i++)
            {

                indice_columna = Convert.ToInt32(arr_obligaciones[i]);
                celda_titulo = odtPrueba.Columns[indice_columna].ToString().Trim();

                if (celda_titulo == titulo)
                    fTitulo = true;
            }

            if (fTitulo && contarItems(arr_obligaciones) == 1)
                fTitulo = true;
            else
                fTitulo = false;

            return fTitulo;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo("C:\\PDFs\\DataGridViewExport.pdf");
            bool estaAbierto = IsFileinUse(file, "C:\\PDFs\\DataGridViewExport.pdf");
            if (!estaAbierto)
            {

                


                CapaDeNegocios.Planillas.cDetallePlanilla oPlanilla = new CapaDeNegocios.Planillas.cDetallePlanilla();
                CapaDeNegocios.Planillas.cDetallePlanillaIngresos oPlanillaIngresos = new CapaDeNegocios.Planillas.cDetallePlanillaIngresos();
                CapaDeNegocios.Planillas.cDetallePlanillaDescuentos oPlanillaDescuentos = new CapaDeNegocios.Planillas.cDetallePlanillaDescuentos();
                CapaDeNegocios.Planillas.cDetallePlanillaATrabajador oPlanillaTrabajador = new CapaDeNegocios.Planillas.cDetallePlanillaATrabajador();
                CapaDeNegocios.Planillas.cDetallePlanillaAEmpleador oPlanillaEmpleador = new CapaDeNegocios.Planillas.cDetallePlanillaAEmpleador();

                //Mes  y Regimen laboral

                decimal renumeracion = 0;
                decimal total_ingresos = 0;
                decimal total_descuentos = 0;
                decimal total_trabajador = 0;
                decimal total_empleador = 0;
                decimal aporte_entidad = 0;

                string pAño = saño;
                string pMes = smes;
                int pRegimenLaboral = sidtregimenlaboral;

                int indice_dsco_afp = 0;
                int indice_neto_cobrar = 0;
                int indice_prueba_neto_cobrar = 0;
                int indice_prueba_corta_neto_cobrar = 0;
                int indice_aporte_entidad = 0;


                int pidTrabajador = 0;
                int indice_ingreso = 0;
                int indice_descuento = 0;

                int indice_a_empleador = 0;
                int indice_a_trabajador = 0;

                decimal total_tipo_ingreso = 0;
                decimal total_tipo_descuento = 0;
                decimal total_tipo_a_empleador = 0;
                decimal total_tipo_a_trabajador = 0;

                int indice_prueba_dias_laborados = 0;
                int indice_prueba_corta_dias_laborados = 0;

                string[] arr_ingresos = new string[160];
                string[] arr_descuento = new string[160];
                string[] arr_a_empleador = new string[160];
                string[] arr_a_trabajador = new string[160];

                bool fIngresos = false;
                bool fDescuentos = false;
                bool fATrabajador = false;
                bool fAEmpleador = false;

                int cantidad_ingresos = 0;
                int cantidad_descuentos = 0;
                int cantidad_a_trabajador = 0;
                int cantidad_a_empleador = 0;

                string[] arr_ingresos_max_2 = new string[80];
                string[] arr_descuento_max_2 = new string[80];
                string[] arr_a_empleador_max_2 = new string[80];
                string[] arr_a_trabajador_max_2 = new string[80];

                int k = 0;
                int t = 0;
                DataRow drFila = odtPrueba.NewRow();
                DataRow drFilaCorta = odtPruebaCorta.NewRow();
                DataRow drFilaATrabajador = odtATrabajador.NewRow();

                //Establecer titulos de la planilla

                odtPrueba.Columns.Add("NOMBRE COMPLETO", typeof(string));
                odtPrueba.Columns.Add("CARGO", typeof(string));
                odtPrueba.Columns.Add("DNI", typeof(string));

                odtPrueba.Columns.Add("FECHA INICIO", typeof(string));

                odtPrueba.Columns.Add("SEC. FUNC.", typeof(string));
                odtPrueba.Columns.Add("AFIL. AFP/SNP", typeof(string));
                odtPrueba.Columns.Add("COMISION", typeof(string));
                odtPrueba.Columns.Add("CUSP", typeof(string));

                //realizar consulta para planilla por mes y regimen laboral


                //odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboral(pMes, pRegimenLaboral);
                //Determinar si la consulta esta vacio
                odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboral(sidtplanilla, pRegimenLaboral);

                odtPrueba.Clear();

                if (odtPlanilla.Rows.Count > 0)
                {    //recorrer consulta de planilla por id plantilla y regimen laboral
                    foreach (DataRow row in odtPlanilla.Rows)
                    {

                        drFila = odtPrueba.NewRow();
                        drFila.Delete();
                        //Determinar en base al id del trabajador sus ingresos
                        pidTrabajador = Convert.ToInt32(row[5]);
                        odtPlanillaXIngresos = oPlanillaIngresos.ListarPlanillaXIngresos(sidtplanilla, pRegimenLaboral, pidTrabajador);

                        foreach (DataRow row_i in odtPlanillaXIngresos.Rows)
                        {
                            // si no existe columna agregar titulo
                            if (!ExisteColumna(odtPrueba, row_i))
                            {
                                odtPrueba.Columns.Add(row_i[8].ToString().Trim(), typeof(string));
                                total_tipo_ingreso++;
                                arr_ingresos[t] = (odtPrueba.Columns.Count - 1).ToString();
                                t++;

                            }
                            //Buscar indice del titulo respectivo al monto
                            indice_ingreso = BuscarIndiceColumna(odtPrueba, row_i[8].ToString());

                            //insertar monto de ingresos a la planilla
                            if (row_i[9].ToString() == "")
                                drFila[indice_ingreso] = 0.00;
                            else
                                drFila[indice_ingreso] = row_i[9];
                        }

                        //Insertando la sumatoria total de ingresos
                        //Buscar indice del titulo respectivo al monto
                        /*
                        indice_ingreso = BuscarIndiceColumna(odtPrueba, "TOTAL INGRESOS");

                        // Insertando la descripcion de columna del total de ingresos
                        if (!ExisteColumnaTexto(odtPrueba, "TOTAL INGRESOS"))
                        {
                            odtPrueba.Columns.Add("TOTAL INGRESOS", typeof(string));
                            indice_ingreso = BuscarIndiceColumna(odtPrueba, "TOTAL INGRESOS");
                            arr_ingresos[t] = indice_ingreso.ToString();
                            total_tipo_ingreso++;
                        }

                        //insertar monto total de ingresos a la planilla
                        drFila[indice_ingreso] = row[15].ToString();
                        */

                        t = 0;
                        //Determinar en base al id del trabajador sus descuentos
                        odtPlanillaXDescuentos = oPlanillaDescuentos.ListarPlanillaXDescuentos(sidtplanilla, pRegimenLaboral, pidTrabajador);

                        foreach (DataRow row_d in odtPlanillaXDescuentos.Rows)
                        {
                            // si no existe columna agregar titulo
                            if (!ExisteColumna(odtPrueba, row_d))
                            {
                                odtPrueba.Columns.Add(row_d[8].ToString().Trim(), typeof(string));
                                total_tipo_descuento++;

                                arr_descuento[t] = (odtPrueba.Columns.Count - 1).ToString();
                                t++;
                            }
                            //Buscar indice del titulo respectivo al monto
                            indice_descuento = BuscarIndiceColumna(odtPrueba, row_d[8].ToString());

                            //insertar monto de ingresos a la planilla
                            if (row_d[9].ToString() == "")
                                drFila[indice_descuento] = 0.00;
                            else
                                drFila[indice_descuento] = row_d[9];

                        }

                        /*
                        //Insertando la sumatoria total de descuentos
                        // Insertando la descripcion de columna del total de descuentos
                        if (!ExisteColumnaTexto(odtPrueba, "TOTAL DESCUENTOS")) { 
                            odtPrueba.Columns.Add("TOTAL DESCUENTOS", typeof(string));
                            indice_descuento = BuscarIndiceColumna(odtPrueba, "TOTAL DESCUENTOS");
                            arr_descuento[t] = indice_descuento.ToString();
                            total_tipo_descuento++;
                        }
                        //Buscar indice del titulo respectivo al monto
                        indice_descuento = BuscarIndiceColumna(odtPrueba, "TOTAL DESCUENTOS");

                        //insertar monto total de descuentos a la planilla
                        drFila[indice_descuento] = row[14].ToString();
                        */


                        //Determinar en base al id del trabajador sus aportaciones del trabajador
                        odtPlanillaATrabajador = oPlanillaTrabajador.ListarPlanillaATrabajador(sidtplanilla, pRegimenLaboral, pidTrabajador);

                        t = 0;

                        foreach (DataRow row_t in odtPlanillaATrabajador.Rows)
                        {
                            // si no existe columna agregar titulo
                            if (!ExisteColumna(odtPrueba, row_t))
                            {
                                odtPrueba.Columns.Add(row_t[8].ToString().Trim(), typeof(string));
                                total_tipo_a_trabajador++;
                                arr_a_trabajador[t] = (odtPrueba.Columns.Count - 1).ToString();
                                t++;
                            }
                            //Buscar indice del titulo respectivo al monto
                            indice_a_trabajador = BuscarIndiceColumna(odtPrueba, row_t[8].ToString());

                            //insertar monto de ingresos a la planilla
                            if (row_t[9].ToString() == "")
                                drFila[indice_a_trabajador] = 0.00;
                            else
                                drFila[indice_a_trabajador] = row_t[9];

                        }
                        /*
                        //Insertando la sumatoria total de Aportaciones Empleador
                        // Insertando la descripcion de columna del total de Empleador
                        if (!ExisteColumnaTexto(odtPrueba, "TOTAL APORTACIONES TRABAJADOR"))
                        {
                            odtPrueba.Columns.Add("TOTAL APORTACIONES TRABAJADOR", typeof(string));
                            indice_a_trabajador = BuscarIndiceColumna(odtPrueba, "TOTAL APORTACIONES TRABAJADOR");
                            arr_a_trabajador[t] = indice_a_trabajador.ToString();
                            total_tipo_a_trabajador++;

                        }
                            //Buscar indice del titulo respectivo al monto
                            indice_a_trabajador = BuscarIndiceColumna(odtPrueba, "TOTAL APORTACIONES TRABAJADOR");

                        //insertar monto total de Empleador a la planilla
                        drFila[indice_a_trabajador] = row[13].ToString();
                        */

                        //Determinar en base al id del trabajador sus aportaciones del empleador
                        odtPlanillaAEmpleador = oPlanillaEmpleador.ListarPlanillaAEmpleador(sidtplanilla, pRegimenLaboral, pidTrabajador);
                        t = 0;
                        foreach (DataRow row_e in odtPlanillaAEmpleador.Rows)
                        {
                            // si no existe columna agregar titulo
                            if (!ExisteColumna(odtPrueba, row_e))
                            {
                                odtPrueba.Columns.Add(row_e[8].ToString().Trim(), typeof(string));
                                total_tipo_a_empleador++;
                                arr_a_empleador[t] = (odtPrueba.Columns.Count - 1).ToString();
                                t++;
                            }
                            //Buscar indice del titulo respectivo al monto
                            indice_a_empleador = BuscarIndiceColumna(odtPrueba, row_e[8].ToString());

                            //insertar monto de ingresos a la planilla
                            if (row_e[9].ToString() == "")
                                drFila[indice_a_empleador] = 0.00;
                            else
                                drFila[indice_a_empleador] = row_e[9];
 
                        }


                        //Insertando la sumatoria total de Aportaciones Empleador
                        // Insertando la descripcion de columna del total de Empleador

                        /*
                        if (!ExisteColumnaTexto(odtPrueba, "TOTAL APORTACIONES EMPLEADOR")) {
                            odtPrueba.Columns.Add("TOTAL APORTACIONES EMPLEADOR", typeof(string));
                            indice_a_empleador = BuscarIndiceColumna(odtPrueba, "TOTAL APORTACIONES EMPLEADOR");
                            arr_a_empleador[t] = indice_a_empleador.ToString();
                            total_tipo_a_empleador++;
                        }
                        //Buscar indice del titulo respectivo al monto
                        indice_a_empleador = BuscarIndiceColumna(odtPrueba, "TOTAL APORTACIONES EMPLEADOR");

                        //insertar monto total de Empleador a la planilla
                        drFila[indice_a_empleador] = row[12].ToString();
                        */

                        //insertar datos personales de la planilla al datatable

                        drFila[0] = row[0];
                        drFila[1] = row[1];
                        drFila[2] = row[2];
                        drFila[3] = row[3];
                        drFila[4] = row[6];
                        drFila[5] = row[7];
                        drFila[6] = row[8];
                        drFila[7] = row[9];

                        //renumeracion = Convert.ToDecimal(row[7]);
                        /*
                        total_ingresos = Convert.ToDecimal(row[13]);
                        total_descuentos = Convert.ToDecimal(row[12]);
                        total_trabajador = Convert.ToDecimal(row[11]);
                        total_empleador = Convert.ToDecimal(row[10]);
                        */
                        

                        if (!ExisteColumnaTexto(odtPrueba, "DEC. AFP"))
                        {
                            odtPrueba.Columns.Add("DEC. AFP", typeof(string));
                            indice_dsco_afp = BuscarIndiceColumna(odtPrueba, "DEC. AFP");
                        }

                        if (!ExisteColumnaTexto(odtPrueba, "NETO A COBRAR"))
                        {
                            odtPrueba.Columns.Add("NETO A COBRAR", typeof(string));
                            indice_neto_cobrar = BuscarIndiceColumna(odtPrueba, "NETO A COBRAR");
                        }


                        if (!ExisteColumnaTexto(odtPrueba, "DIAS LABORADOS"))
                        {
                            odtPrueba.Columns.Add("DIAS LABORADOS", typeof(string));
                            indice_prueba_dias_laborados = BuscarIndiceColumna(odtPrueba, "DIAS LABORADOS");
                        }

                        

                        //drFila[indice_neto_cobrar] = renumeracion - total_descuentos + total_ingresos + total_trabajador + total_empleador;
                        drFila[indice_neto_cobrar] = Convert.ToDecimal(row[14]);
                        drFila[indice_prueba_dias_laborados] = row[15];


                        //Calculando aporte entidad
                        /*
                        indice_aporte_entidad = BuscarIndiceColumna(odtPlanillaAEmpleador, "APORTA ENT");
                        aporte_entidad = Convert.ToDecimal(row[indice_aporte_entidad]);

                        drFila[indice_dsco_afp] = total_trabajador + aporte_entidad;
                        */

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

                    drFila = odtPrueba.NewRow();
                    //Insertando totales de las obligaciones
                    drFila[0] = "TOTAL";

                    //Insertando totales de aportaciones trabajador
                    decimal sumatoria = 0;
                    int indice_sumatoria = 0;
                    int indice_atrajador = 0;
                    int indice_aempleador = 0;
                    int indice_descuentos = 0;
                    int indice_ingresos = 0;

                    if (total_tipo_a_trabajador > 0)
                    {
                        for (int j = 0; j < contarItems(arr_a_trabajador); j++)
                        {
                            sumatoria = 0;
                            for (int l = 0; l < odtPrueba.Rows.Count; l++)
                            {
                                indice_sumatoria = Convert.ToInt32(arr_a_trabajador[j]);
                                sumatoria = sumatoria + Convert.ToDecimal(odtPrueba.Rows[l][indice_sumatoria]);

                            }
                            indice_atrajador = Convert.ToInt32(arr_a_trabajador[j]);
                            drFila[indice_atrajador] = sumatoria.ToString();
                        }
                    }

                    //Insertando totales de descuentos
                    if (total_tipo_descuento > 0)
                    {
                        for (int j = 0; j < contarItems(arr_descuento); j++)
                        {
                            sumatoria = 0;
                            for (int l = 0; l < odtPrueba.Rows.Count; l++)
                            {
                                indice_sumatoria = Convert.ToInt32(arr_descuento[j]);
                                sumatoria = sumatoria + Convert.ToDecimal(odtPrueba.Rows[l][indice_sumatoria]);

                            }
                            indice_descuentos = Convert.ToInt32(arr_descuento[j]);
                            drFila[indice_descuentos] = sumatoria.ToString();
                        }
                    }

                    //Insertando totales de ingresos
                    if (total_tipo_ingreso > 0)
                    {
                        for (int j = 0; j < contarItems(arr_ingresos); j++)
                        {
                            sumatoria = 0;
                            for (int l = 0; l < odtPrueba.Rows.Count; l++)
                            {
                                indice_sumatoria = Convert.ToInt32(arr_ingresos[j]);
                                sumatoria = sumatoria + Convert.ToDecimal(odtPrueba.Rows[l][indice_sumatoria]);

                            }
                            indice_ingresos = Convert.ToInt32(arr_ingresos[j]);
                            drFila[indice_ingresos] = sumatoria.ToString();
                        }
                    }
                    //Insertando totales de aportaciones empleador
                    if (total_tipo_a_empleador > 0)
                    {
                        for (int j = 0; j < contarItems(arr_a_empleador); j++)
                        {
                            sumatoria = 0;
                            for (int l = 0; l < odtPrueba.Rows.Count; l++)
                            {
                                indice_sumatoria = Convert.ToInt32(arr_a_empleador[j]);
                                sumatoria = sumatoria + Convert.ToDecimal(odtPrueba.Rows[l][indice_sumatoria]);

                            }
                            indice_aempleador = Convert.ToInt32(arr_a_empleador[j]);
                            drFila[indice_aempleador] = sumatoria.ToString();
                        }
                    }

                    //Insertando fila a datatable odtprueba
                    odtPrueba.Rows.InsertAt(drFila, k);

                    //Establecer titulos de la planilla

                    odtPruebaCorta.Columns.Add("Nº", typeof(string));
                    odtPruebaCorta.Columns.Add("NOMBRE COMPLETO", typeof(string));
                    odtPruebaCorta.Columns.Add("CARGO", typeof(string));
                    odtPruebaCorta.Columns.Add("DNI", typeof(string));

                    odtPruebaCorta.Columns.Add("FECHA INICIO", typeof(string));

                    odtPruebaCorta.Columns.Add("SEC. FUNC.", typeof(string));
                    odtPruebaCorta.Columns.Add("AFIL. AFP/SNP \n\n COMISION \n\n CUSP ", typeof(string));

                    decimal DivisionTrabajador = Math.Ceiling(total_tipo_a_trabajador / 2);
                    decimal DivisionEmpleador = Math.Ceiling(total_tipo_a_empleador / 2);
                    decimal DivisionIngresos = Math.Ceiling(total_tipo_ingreso / 2);
                    decimal DivisionDescuentos = Math.Ceiling(total_tipo_descuento / 2);

                    int cantidad_total_ingresos = 0;
                    int cantidad_total_descuentos = 0;
                    int cantidad_total_a_trabajador = 0;
                    int cantidad_total_a_empleador = 0;

                    int nro_max_filas_x_columna = 0;

                    string columna = "";

                    string nueva_columna = "";
                    string nueva_celda = "";
                    int columna_indice = 0;
                    int c = 0;
                    int cc = 0;


                    //Determinar el numero maximo de filas por columna.
                    //nro_max_filas_x_columna = mayor(Convert.ToInt16(DivisionIngresos), mayor(mayor(Convert.ToInt16(DivisionTrabajador), Convert.ToInt16(DivisionEmpleador)), Convert.ToInt16(DivisionDescuentos)));
                    nro_max_filas_x_columna = mayor(Convert.ToInt16(DivisionIngresos), mayor(mayor(Convert.ToInt16(DivisionTrabajador), Convert.ToInt16(DivisionEmpleador)), Convert.ToInt16(DivisionDescuentos)));
                    if (nro_max_filas_x_columna == 3) nro_max_filas_x_columna = 4;
                    //Unir descripciones de ingresos en maximo dos columnas
                    c = 0; cc = 0;
                    if (total_tipo_ingreso > nro_max_filas_x_columna)
                        cantidad_total_ingresos = 2;
                    else
                        cantidad_total_ingresos = 1;

                    //fIngresos = estaSoloTitulo(odtPrueba, "TOTAL INGRESOS", arr_ingresos );
                    cantidad_ingresos = contarItems(arr_ingresos);

                    if (cantidad_ingresos > 0)
                    {
                        for (int a = 0; a < cantidad_total_ingresos; a++)
                        {
                            nueva_columna = "";
                            for (int b = 0; b < nro_max_filas_x_columna; b++)
                            {
                                if (arr_ingresos[c] != null)
                                {
                                    // Añade la columna de total de ingresos
                                    columna = odtPrueba.Columns[Convert.ToInt32(arr_ingresos[c])].ToString();

                                    if (c == 0 || c == nro_max_filas_x_columna) nueva_columna = columna;
                                    else nueva_columna = nueva_columna + "\n\n" + columna;

                                    c++;
                                }
                            }
                            odtPruebaCorta.Columns.Add(nueva_columna);
                            arr_ingresos_max_2[cc] = (odtPruebaCorta.Columns.Count - 1).ToString();
                            cc++;
                        }
                        odtPruebaCorta.Columns.Add("TOTAL INGRESOS", typeof(string));
                    }

                    //Unir descripciones de aportes trabajador en maximo dos columnas
                    c = 0; cc = 0;
                    if (total_tipo_a_trabajador > nro_max_filas_x_columna)
                        cantidad_total_a_trabajador = 2;
                    else
                        cantidad_total_a_trabajador = 1;

                    //fATrabajador = estaSoloTitulo(odtPrueba, "TOTAL APORTACIONES TRABAJADOR", arr_a_trabajador);
                    cantidad_a_trabajador = contarItems(arr_a_trabajador);


                    if (cantidad_a_trabajador > 0)
                    {
                        for (int a = 0; a < cantidad_total_a_trabajador; a++)
                        {
                            nueva_columna = "";
                            for (int b = 0; b < nro_max_filas_x_columna; b++)
                            {
                                if (arr_a_trabajador[c] != null)
                                {
                                    columna = odtPrueba.Columns[Convert.ToInt32(arr_a_trabajador[c])].ToString();

                                    if (c == 0 || c == nro_max_filas_x_columna) nueva_columna = columna;
                                    else nueva_columna = nueva_columna + "\n\n" + columna;

                                    c++;
                                }
                            }
                            odtPruebaCorta.Columns.Add(nueva_columna);
                            arr_a_trabajador_max_2[cc] = (odtPruebaCorta.Columns.Count - 1).ToString();
                            cc++;
                        }
                        odtPruebaCorta.Columns.Add("TOTAL APORTACIONES TRABAJADOR", typeof(string));
                    }

                    //Unir descripciones de descuentos en maximo dos columnas

                    c = 0; cc = 0;

                    if (total_tipo_descuento > nro_max_filas_x_columna)
                        cantidad_total_descuentos = 2;
                    else
                        cantidad_total_descuentos = 1;

                    //fDescuentos = estaSoloTitulo(odtPrueba, "TOTAL DESCUENTOS", arr_descuento);
                    cantidad_descuentos = contarItems(arr_descuento);

                    if (cantidad_descuentos > 0)
                    {
                        for (int a = 0; a < cantidad_total_descuentos; a++)
                        {
                            nueva_columna = "";
                            for (int b = 0; b < nro_max_filas_x_columna; b++)
                            {
                                if (arr_descuento[c] != null)
                                {
                                    // Añade la columna de total de descuentos
                                    columna = odtPrueba.Columns[Convert.ToInt32(arr_descuento[c])].ToString();

                                    if (c == 0 || c == nro_max_filas_x_columna) nueva_columna = columna;
                                    else nueva_columna = nueva_columna + "\n\n" + columna;

                                    c++;
                                }
                            }
                            odtPruebaCorta.Columns.Add(nueva_columna);
                            arr_descuento_max_2[cc] = (odtPruebaCorta.Columns.Count - 1).ToString();
                            cc++;
                        }
                        odtPruebaCorta.Columns.Add("TOTAL DESCUENTOS", typeof(string));
                    }




                    //Unir descripciones de empleador en maximo dos columnas
                    c = 0; cc = 0;
                    if (total_tipo_a_empleador > nro_max_filas_x_columna)
                        cantidad_total_a_empleador = 2;
                    else
                        cantidad_total_a_empleador = 1;

                    //fAEmpleador = estaSoloTitulo(odtPrueba, "TOTAL APORTACIONES EMPLEADOR", arr_a_empleador);
                    cantidad_a_empleador = contarItems(arr_a_empleador);

                    if (cantidad_a_empleador > 0)
                    {
                        for (int a = 0; a < cantidad_total_a_empleador; a++)
                        {
                            nueva_columna = "";
                            for (int b = 0; b < nro_max_filas_x_columna; b++)
                            {
                                if (arr_a_empleador[c] != null)
                                {
                                    columna = odtPrueba.Columns[Convert.ToInt32(arr_a_empleador[c])].ToString();

                                    if (c == 0 || c == nro_max_filas_x_columna) nueva_columna = columna;
                                    else nueva_columna = nueva_columna + "\n\n" + columna;


                                    c++;
                                }
                            }
                            odtPruebaCorta.Columns.Add(nueva_columna);
                            arr_a_empleador_max_2[cc] = (odtPruebaCorta.Columns.Count - 1).ToString();
                            cc++;
                        }
                        odtPruebaCorta.Columns.Add("TOTAL APORTACIONES EMPLEADOR", typeof(string));
                    }

                    //Planilla por mes y regimen laboral
                    odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboral(sidtplanilla, pRegimenLaboral);

                    int ll = 0;
                    //esribir datos de planilla
                    int total_prueba_corta = odtPrueba.Rows.Count;

                    for (int d = 0; d < total_prueba_corta ; d++)
                    {
                        drFilaCorta = odtPruebaCorta.NewRow();
                        drFilaCorta.Delete();

                        //Obteniendo los montos respectivos de la descripcion de ingresos agrupados en un maximo de dos columnas
                        if (cantidad_ingresos > 0)
                        {
                            c = 0;
                            for (int a = 0; a < cantidad_total_ingresos; a++)
                            {
                                nueva_celda = "";
                                for (int b = 0; b < nro_max_filas_x_columna; b++)
                                {
                                    if (arr_ingresos[c] != null)
                                    {
                                        if (c == 0 || c == nro_max_filas_x_columna) nueva_celda = nueva_celda + odtPrueba.Rows[d][Convert.ToInt32(arr_ingresos[c])];
                                        else nueva_celda = nueva_celda + "\n\n" + odtPrueba.Rows[d][Convert.ToInt32(arr_ingresos[c])];
                                        c++;
                                    }

                                }

                                if (arr_ingresos_max_2[a] != null)
                                {
                                    columna_indice = Convert.ToInt16(arr_ingresos_max_2[a]);
                                    drFilaCorta[columna_indice] = nueva_celda;
                                }

                            }


                            if ( d != odtPrueba.Rows.Count-1) { 
                                indice_ingreso = BuscarIndiceColumna(odtPruebaCorta, "TOTAL INGRESOS");
                                drFilaCorta[indice_ingreso] = odtPlanilla.Rows[d][13];
                            }

                        }


                        //Obteniendo los montos respectivos de la descripcion de aportaciones del trabajador agrupados en un maximo de dos columnas
                        if (cantidad_a_trabajador > 0)
                        {
                            c = 0;
                            for (int a = 0; a < cantidad_total_a_trabajador; a++)
                            {
                                nueva_celda = "";
                                for (int b = 0; b < nro_max_filas_x_columna; b++)
                                {
                                    if (arr_a_trabajador[c] != null)
                                    {
                                        if (c == 0 || c == nro_max_filas_x_columna) nueva_celda = nueva_celda + odtPrueba.Rows[d][Convert.ToInt32(arr_a_trabajador[c])];
                                        else nueva_celda = nueva_celda + "\n\n" + odtPrueba.Rows[d][Convert.ToInt32(arr_a_trabajador[c])];
                                        c++;
                                    }

                                }

                                if (arr_a_trabajador_max_2[a] != null)
                                {
                                    columna_indice = Convert.ToInt16(arr_a_trabajador_max_2[a]);
                                    drFilaCorta[columna_indice] = nueva_celda;
                                }

                            }

                            if (d != odtPrueba.Rows.Count - 1)
                            {
                                indice_a_trabajador = BuscarIndiceColumna(odtPruebaCorta, "TOTAL APORTACIONES TRABAJADOR");
                                drFilaCorta[indice_a_trabajador] = odtPlanilla.Rows[d][11];
                            }
                        }

                        //Obteniendo los montos respectivos de la descripcion de descuentos agrupados en un maximo de dos columnas
                        if (cantidad_descuentos > 0)
                        {
                            c = 0;
                            for (int a = 0; a < cantidad_total_descuentos; a++)
                            {
                                nueva_celda = "";
                                for (int b = 0; b < nro_max_filas_x_columna; b++)
                                {
                                    if (arr_descuento[c] != null)
                                    {
                                        if (c == 0 || c == nro_max_filas_x_columna) nueva_celda = nueva_celda + odtPrueba.Rows[d][Convert.ToInt32(arr_descuento[c])];
                                        else nueva_celda = nueva_celda + "\n\n" + odtPrueba.Rows[d][Convert.ToInt32(arr_descuento[c])];
                                        c++;
                                    }

                                }

                                if (arr_descuento_max_2[a] != null)
                                {
                                    columna_indice = Convert.ToInt16(arr_descuento_max_2[a]);
                                    drFilaCorta[columna_indice] = nueva_celda;
                                }

                            }

                            if (d != odtPrueba.Rows.Count - 1)
                            {
                                indice_descuento = BuscarIndiceColumna(odtPruebaCorta, "TOTAL DESCUENTOS");
                                drFilaCorta[indice_descuento] = odtPlanilla.Rows[d][12];
                            }
                        }




                        //Obteniendo los montos respectivos de la descripcion de aportaciones del empleador agrupados en un maximo de dos columnas
                        if (cantidad_a_empleador > 0)
                        {
                            c = 0;
                            for (int a = 0; a < cantidad_total_a_empleador; a++)
                            {
                                nueva_celda = "";
                                for (int b = 0; b < nro_max_filas_x_columna; b++)
                                {
                                    if (arr_a_empleador[c] != null)
                                    {
                                        if (c == 0 || c == nro_max_filas_x_columna) nueva_celda = nueva_celda + odtPrueba.Rows[d][Convert.ToInt32(arr_a_empleador[c])];
                                        else nueva_celda = nueva_celda + "\n\n" + odtPrueba.Rows[d][Convert.ToInt32(arr_a_empleador[c])];
                                        c++;
                                    }

                                }

                                if (arr_a_empleador_max_2[a] != null)
                                {
                                    columna_indice = Convert.ToInt16(arr_a_empleador_max_2[a]);
                                    drFilaCorta[columna_indice] = nueva_celda;
                                }

                                if (d != odtPrueba.Rows.Count - 1)
                                {
                                    indice_a_empleador = BuscarIndiceColumna(odtPruebaCorta, "TOTAL APORTACIONES EMPLEADOR");
                                    drFilaCorta[indice_a_empleador] = odtPlanilla.Rows[d][10];
                                }
                            }
                        }




                        //insertar datos personales de la planilla al datatable
                        if ( d != total_prueba_corta-1 )
                            drFilaCorta[0] = (d + 1);

                        drFilaCorta[1] = odtPrueba.Rows[d][0];
                        drFilaCorta[2] = odtPrueba.Rows[d][1];
                        drFilaCorta[3] = odtPrueba.Rows[d][2];

                        if (odtPrueba.Rows[d][3].ToString() != "")
                            drFilaCorta[4] = Convert.ToDateTime(odtPrueba.Rows[d][3]).Date.ToString("MM/dd/yyyy");

                        //drFilaCorta[5] = odtPrueba.Rows[d][4];

                        drFilaCorta[5] = odtPrueba.Rows[d][4];
                        drFilaCorta[6] = odtPrueba.Rows[d][5] + " \n\n " + odtPrueba.Rows[d][6] + " \n\n " + odtPrueba.Rows[d][7];


                        //drFilaCorta[10] = odtPrueba.Rows[d][9];

                        if (!ExisteColumnaTexto(odtPruebaCorta, "NETO A COBRAR"))
                        {
                            odtPruebaCorta.Columns.Add("NETO A COBRAR", typeof(string));
                            indice_prueba_neto_cobrar = BuscarIndiceColumna(odtPrueba, "NETO A COBRAR");
                        }
                        indice_prueba_corta_neto_cobrar = BuscarIndiceColumna(odtPruebaCorta, "NETO A COBRAR");

                        if (!ExisteColumnaTexto(odtPruebaCorta, "DIAS LABORADOS"))
                        {
                            odtPruebaCorta.Columns.Add("DIAS LABORADOS", typeof(string));
                            indice_prueba_corta_dias_laborados = BuscarIndiceColumna(odtPruebaCorta, "DIAS LABORADOS");
                            indice_prueba_dias_laborados = BuscarIndiceColumna(odtPrueba, "DIAS LABORADOS");
                        }

                        string neto_cobrar = odtPrueba.Rows[d][indice_prueba_neto_cobrar].ToString();

                        drFilaCorta[indice_prueba_corta_dias_laborados] = odtPrueba.Rows[d][indice_prueba_dias_laborados];
                        drFilaCorta[indice_prueba_corta_neto_cobrar] = neto_cobrar.ToString();

                        //Sumando total de neto a cobrar y sumatoria total de total ingresos, total descuentos, total empleador, total trabajador
                        sumatoria = 0;
                        indice_prueba_corta_neto_cobrar = BuscarIndiceColumna(odtPrueba, "NETO A COBRAR");
                        decimal monto = 0;

                        decimal monto_ingresos = 0;
                        decimal sumatoria_ingresos = 0;
                        decimal monto_descuentos = 0;
                        decimal sumatoria_descuentos = 0;
                        decimal monto_a_empleador = 0;
                        decimal sumatoria_a_empleador = 0;
                        decimal monto_a_trabajador = 0;
                        decimal sumatoria_a_trabajador = 0;

                        decimal monto_aporte_entidad = 0;

                        int iindice_ingresos = 0;
                        int iindice_descuentos = 0;
                        int iindice_a_empleador = 0;
                        int iindice_a_trabajador = 0;
                        int iindice_dec_afp = 0;
                        int iindice_aporte_entidad = 0;

                        iindice_ingresos = BuscarIndiceColumna(odtPlanilla, "totalingresos");
                        iindice_descuentos = BuscarIndiceColumna(odtPlanilla, "totaldescuentos");
                        iindice_a_empleador = BuscarIndiceColumna(odtPlanilla, "totalaempleador");
                        iindice_a_trabajador = BuscarIndiceColumna(odtPlanilla, "totalatrabajador");

                        if (ll == odtPrueba.Rows.Count - 1)
                        {
                            for (int l = 0; l < odtPrueba.Rows.Count - 1; l++)
                            {
                                monto = Convert.ToDecimal(odtPrueba.Rows[l][indice_prueba_corta_neto_cobrar]);
                                sumatoria = sumatoria + monto;

                                monto_ingresos = Convert.ToDecimal(odtPlanilla.Rows[l][iindice_ingresos]);
                                sumatoria_ingresos += monto_ingresos;

                                monto_descuentos = Convert.ToDecimal(odtPlanilla.Rows[l][iindice_descuentos]);
                                sumatoria_descuentos += monto_descuentos;

                                monto_a_empleador = Convert.ToDecimal(odtPlanilla.Rows[l][iindice_a_empleador]);
                                sumatoria_a_empleador += monto_a_empleador;

                                monto_a_trabajador = Convert.ToDecimal(odtPlanilla.Rows[l][iindice_a_trabajador]);
                                sumatoria_a_trabajador += monto_a_trabajador;

                            }
                            indice_prueba_corta_neto_cobrar = BuscarIndiceColumna(odtPruebaCorta, "NETO A COBRAR");
                            drFilaCorta[indice_prueba_corta_neto_cobrar] = sumatoria.ToString();

                            iindice_ingresos = BuscarIndiceColumna(odtPruebaCorta, "TOTAL INGRESOS");
                            drFilaCorta[iindice_ingresos] = sumatoria_ingresos.ToString();

                            iindice_descuentos = BuscarIndiceColumna(odtPruebaCorta, "TOTAL DESCUENTOS");
                            drFilaCorta[iindice_descuentos] = sumatoria_descuentos.ToString();

                            iindice_a_trabajador = BuscarIndiceColumna(odtPruebaCorta, "TOTAL APORTACIONES TRABAJADOR");
                            drFilaCorta[iindice_a_trabajador] = sumatoria_a_trabajador.ToString();

                            iindice_a_empleador = BuscarIndiceColumna(odtPruebaCorta, "TOTAL APORTACIONES EMPLEADOR");
                            drFilaCorta[iindice_a_empleador] = sumatoria_a_empleador.ToString();
                             
                            if (!ExisteColumnaTexto(odtPruebaCorta, "DEC. AFP"))
                            {
                                odtPruebaCorta.Columns.Add("DEC. AFP", typeof(string));
                                iindice_dec_afp = BuscarIndiceColumna(odtPrueba, "DEC. AFP");
                            }


                                iindice_aporte_entidad = BuscarIndiceColumna(odtPruebaCorta, "APORT. ENTIDAD");

                            if (iindice_aporte_entidad != -1) { 
                                monto_aporte_entidad = Convert.ToDecimal( odtPruebaCorta.Rows[d][iindice_aporte_entidad]);
                                drFilaCorta[iindice_dec_afp] = monto_aporte_entidad + sumatoria_a_trabajador;
                            }


                        }


                        //Planilla 728 ------ DEC. AFP = total aportaciones trabajador + aportaciones entidad



                        //Insertando una fila al datatable odtPruebaCorta
                        odtPruebaCorta.Rows.InsertAt(drFilaCorta, d);
                        ll++;
                    }
                     

                    odtPruebaCorta.Columns.Add("FIRMA", typeof(string));

                    this.dgvPrueba.DataSource = odtPruebaCorta;
                     

                    //Agregando columnas al cuadro de AFP
                    odtATrabajador.Columns.Add("DESCUENTOS", typeof(string));
                    odtATrabajador.Columns.Add(" ", typeof(string));
                    //Calculando cuadro de AFP
                    string[] arr_aportaciones_trabajador = new string[160];
                    //Calcular cuantas AFP existen en el datatable odtPrueba
                    int kk = 0;
                    int nn = 0;
                    string afp = "";
                    decimal sumatoria_afp = 0;
                    decimal sumatoria_afp_parcial = 0;
                    bool AFP = false;
                    string prueba_afp = "";
                    string arr_prueba_trabajador = "";

                    for (k = 0; k < odtPrueba.Rows.Count; k++)
                    {
                        afp = odtPrueba.Rows[k][5].ToString();
                        AFP = estaAFP(arr_aportaciones_trabajador, afp);
                        if (!AFP && afp != "")
                        {
                            arr_aportaciones_trabajador[kk] = afp;
                            kk++;
                        }
                    }

                    //Calcular la sumatoria por cada AFP encontrada.
                    for (k = 0; k < contarItems(arr_aportaciones_trabajador); k++)
                    {
                        drFilaATrabajador = odtATrabajador.NewRow();
                        drFilaATrabajador.Delete();
                        sumatoria_afp = 0;
                        for (int l = 0; l < odtPrueba.Rows.Count; l++)
                        {
                            prueba_afp = odtPrueba.Rows[l][7].ToString().Trim();
                            arr_prueba_trabajador = arr_aportaciones_trabajador[k].ToString().Trim();

                            if (prueba_afp == arr_prueba_trabajador)
                            {
                                sumatoria_afp_parcial = Convert.ToDecimal(odtPrueba.Rows[l][13].ToString().Trim());
                                sumatoria_afp += sumatoria_afp_parcial;
                            }
                        }
                        drFilaATrabajador[0] = arr_aportaciones_trabajador[k];
                        drFilaATrabajador[1] = sumatoria_afp;
                        odtATrabajador.Rows.InsertAt(drFilaATrabajador, k);
                        nn++;
                    }


                    //Calcular la sumatoria total del cuadro AFP
                    sumatoria_afp = 0;
                    for (int m = 0; m < contarItems(arr_aportaciones_trabajador); m++)
                    {
                        sumatoria_afp_parcial = Convert.ToDecimal(odtATrabajador.Rows[m][1]);
                        sumatoria_afp += sumatoria_afp_parcial;
                        nn++;
                    }

                    drFilaATrabajador = odtATrabajador.NewRow();
                    drFilaATrabajador.Delete();

                    drFilaATrabajador[0] = "TOTAL";
                    drFilaATrabajador[1] = sumatoria_afp;
                    odtATrabajador.Rows.InsertAt(drFilaATrabajador, nn);

                    dgvAFP.DataSource = odtATrabajador;

                    exportar_a_pdf();
                }
                else
                    MessageBox.Show("Plantilla sin datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Por favor cerrar PDF Reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool estaAFP(string[] arr_pruebas, string afp)
        {
            bool AFP = false;
            string prueba = "";

            for (int i = 0; i < arr_pruebas.Count(); i++)
            {
                prueba = arr_pruebas[i];
                if (prueba == afp.Trim())
                {
                    AFP = true;
                }
            }

            return AFP;
        }

        public int mayor(int a, int b)
        {
            int mayor = 0;

            if (a > b)
                mayor = a;
            else
                mayor = b;

            return mayor;
        }

        public float[] GetTamañoColumnas(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
                if (i == 0) values[i] = 50;
                if (i == 1) values[i] = 200;

                if (i == dg.ColumnCount - 1) values[i] = 150;
            }
            return values;
        }

        public float[] GetTamañoColumnas2(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
                //if (i == 0) values[i] = 50;
                //if (i == 1) values[i] = 50;

            }
            return values;
        }

        private void exportar_a_pdf()
        {
            //Creating iTextSharp Table from the DataTable data
            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 7);
            iTextSharp.text.Font fuenteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 9, 1, iTextSharp.text.Color.BLUE);

            PdfPTable pdfTable = new PdfPTable(dgvPrueba.ColumnCount);
            PdfPTable pdfTable2 = new PdfPTable(dgvAFP.ColumnCount);
            Phrase objP = new Phrase("A", fuente);
            Phrase objP2 = new Phrase("A", fuente);
            //Phrase objH = new Phrase("A", fuenteTitulo);
            PdfPCell cell;
            PdfPCell cell2;

            pdfTable.DefaultCell.Padding = 1;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            pdfTable2.DefaultCell.Padding = 1;
            pdfTable2.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable2.DefaultCell.BorderWidth = 1;

            float[] headerwidths = GetTamañoColumnas(dgvPrueba);
            float[] headerwidths2 = GetTamañoColumnas(dgvAFP);
            //float[] headerwidths = { 2f, 6f, 6f, 3f, 5f, 8f, 5f, 5f, 5f, 5f };

            //cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#d1dbe0"));

            pdfTable.SetWidths(headerwidths);
            pdfTable.WidthPercentage = 100;

            pdfTable2.SetWidths(headerwidths2);
            pdfTable2.WidthPercentage = 30;

 
            int iindice_nombre = 0;
            int iindice_cargo = 0;
            int iindice_fecha = 0;
            int iindice_afi_com_cus = 0;


            //Adding Header row
            foreach (DataGridViewColumn column in dgvPrueba.Columns)
            {
                cell = new PdfPCell((new Phrase( column.HeaderText , new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                //cell = new PdfPCell(new Phrase(column.HeaderText));
                //PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                // objH = new Phrase(column.HeaderText, fuenteTitulo);
                pdfTable.AddCell(cell);
            }

            /*Indices de la secciones alineadas*/
            iindice_nombre = BuscarIndiceColumna(odtPruebaCorta, "NOMBRE COMPLETO");
            iindice_cargo = BuscarIndiceColumna(odtPruebaCorta, "CARGO");
            iindice_fecha = BuscarIndiceColumna(odtPruebaCorta, "FECHA INICIO");
            iindice_afi_com_cus = BuscarIndiceColumna(odtPruebaCorta, "AFIL. AFP/SNP \n\n COMISION \n\n CUSP ");

            for (int i = 0; i < dgvPrueba.RowCount - 1; i++)
            {
                for (int j = 0; j < dgvPrueba.ColumnCount; j++)
                {
                    //objP = new Phrase(dgvPrueba[j, i].Value.ToString(), fuente);
                    cell = new PdfPCell((new Phrase(dgvPrueba[j, i].Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));

                    //Alineando a la derecha la columna nº
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;

                    if ( j == iindice_nombre || j == iindice_cargo || j == iindice_fecha || j == iindice_afi_com_cus)
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
 
                    pdfTable.AddCell(cell);
                }
                pdfTable.CompleteRow();
            }

            /* ---------------- dgvAFP */

            //Adding Header row
            foreach (DataGridViewColumn column in dgvAFP.Columns)
            {
                cell2 = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                //cell = new PdfPCell(new Phrase(column.HeaderText));
                //PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell2.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                // objH = new Phrase(column.HeaderText, fuenteTitulo);
                pdfTable2.AddCell(cell2);
            }

            for (int k = 0; k < dgvAFP.RowCount - 1; k++)
            {
                for (int l = 0; l < dgvAFP.ColumnCount; l++)
                {
                    objP2 = new Phrase(dgvAFP[l, k].Value.ToString(), fuente);
                    pdfTable2.AddCell(objP2);
                }
                pdfTable2.CompleteRow();
            }

            /*----------------fin dfvAFP*/

            //Exporting to PDF
            string folderPath = "C:\\PDFs\\";

            //use a variable to let my code fit across the page...
            //string path = Server.MapPath("PDFs");
            //PdfWriter.GetInstance(doc1, new FileStream(path + "/Doc1.pdf", FileMode.Create));

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "DataGridViewExport.pdf", FileMode.Create))
            {

                Document pdfDoc = new Document(PageSize.A4, 9, 9, 10, 30);
                pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());

                Paragraph paragraph = new Paragraph();
                paragraph.Alignment = Element.ALIGN_CENTER;
                paragraph.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 12);
                paragraph.Add("MUNICIPALIDAD DISTRITAL DE CCATCCA \n UNIDAD DE PERSONAL \n ");

                Paragraph paragraph2 = new Paragraph();
                paragraph2.Alignment = Element.ALIGN_RIGHT;
                paragraph2.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                paragraph2.Add("PLANILLA Nº" + sNumeroPlanilla + "\n ");

                Paragraph paragraph3 = new Paragraph();
                paragraph3.Alignment = Element.ALIGN_CENTER;
                paragraph3.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                paragraph3.Add("PLANILLA DE RENUMERACIONES DEL PERSONAL DE " + sRegimenLaboral + "\n ");

                Paragraph paragraph4 = new Paragraph();
                paragraph4.Alignment = Element.ALIGN_CENTER;
                paragraph4.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                paragraph4.Add("\n");

                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(paragraph);
                pdfDoc.Add(paragraph2);
                pdfDoc.Add(paragraph3);

                pdfDoc.Add(pdfTable);
                pdfDoc.Add(paragraph4);
                pdfDoc.Add(pdfTable2);
                pdfDoc.Close();
                stream.Close();
            }

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "C:\\PDFs\\DataGridViewExport.pdf";
            proc.Start();

        }

        private void dgvPlanilla_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPlanilla_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

            if (e.RowIndex != -1)
            {
                sidtplanilla = Convert.ToInt32(dgvPlanilla.Rows[e.RowIndex].Cells[0].Value);
                snumero = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[1].Value);
                sdescripcion = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[2].Value);
                smes = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[3].Value);
                saño = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[4].Value);
                sfecha = Convert.ToDateTime(dgvPlanilla.Rows[e.RowIndex].Cells[5].Value);
                sidtmeta = Convert.ToInt32(dgvPlanilla.Rows[e.RowIndex].Cells[6].Value);
                smeta = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[7].Value);
                sidtfuentefinanciamiento = Convert.ToInt32(dgvPlanilla.Rows[e.RowIndex].Cells[8].Value);
                sfuentefinanciamiento = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[9].Value);
                sidtregimenlaboral = Convert.ToInt32(dgvPlanilla.Rows[e.RowIndex].Cells[10].Value);
                splantilla = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[11].Value);

                sNumeroPlanilla = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[1].Value);
                DataTable odtPrueba = new DataTable();
                odtPrueba = oPlanilla.ListarRegimenLaboralPlanilla(sNumeroPlanilla);
                foreach (DataRow row in odtPrueba.Rows)
                    sRegimenLaboral = row[0].ToString();
            }
        }
    }
}
