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

namespace CapaUsuario.Planilla
{
    public partial class frmMatenimientoPlanilla : Form
    {
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
        string sNumeroPlanilla = "";
        string sRegimenLaboral = "";
        //int idTRegimenLaboral = -1;

        CapaUsuario.Reportes.frmPlanilla fPlanilla = new CapaUsuario.Reportes.frmPlanilla();
        CapaDeNegocios.Planillas.cPlanilla miPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

        

        public frmMatenimientoPlanilla()
        {
            InitializeComponent();
        }

        private void frmMatenimientoPlanilla_Load(object sender, EventArgs e)
        {
            CargarRegimenLaboral();
            cboRegimenLaboral_SelectedIndexChanged(sender, e);
        }

        private void btnTipoTrabajador_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CapaUsuario.Planilla.frmPlanilla fPlanilla = new frmPlanilla();
            fPlanilla.RecibirDatos(0, "", "", "", DateTime.Today, 0, "", 0, "", sidtregimenlaboral, 1);
            if (fPlanilla.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (sidtplanilla == 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CapaUsuario.Planilla.frmPlanilla fPlanilla = new frmPlanilla();
            fPlanilla.RecibirDatos(sidtplanilla, snumero, smes, saño, sfecha, sidtmeta, smeta, sidtfuentefinanciamiento, sfuentefinanciamiento, sidtregimenlaboral, 2);
            if (fPlanilla.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (sidtplanilla == 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Está seguro que desea eliminar la Planilla", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            miPlanilla.EliminarPlanilla(sidtplanilla);
            CargarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDetallePlanilla_Click(object sender, EventArgs e)
        {
            CapaUsuario.frmPrincipal fPrincipal = new frmPrincipal();
            CapaUsuario.Planilla.frmMantenimientoDetallePlanilla fMantenimientoDetallePlanilla = new frmMantenimientoDetallePlanilla();
            fMantenimientoDetallePlanilla.RecibirDatos(sidtplanilla, snumero, smes, saño, sidtmeta, smeta, sidtfuentefinanciamiento, sfuentefinanciamiento, sidtregimenlaboral, cboRegimenLaboral.Text);
            //fMantenimientoDetallePlanilla.MdiParent = fPrincipal;
            if (fMantenimientoDetallePlanilla.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
            //fMantenimientoDetallePlanilla.Show();
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

        protected virtual bool IsFileinUse(FileInfo file,string path)
        {
            FileStream stream = null;

            if (!File.Exists(path))
            {
                return false;
            }
            else { 
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo("C:\\PDFs\\DataGridViewExport.pdf");
            bool estaAbierto = IsFileinUse(file, "C:\\PDFs\\DataGridViewExport.pdf");
            if (!estaAbierto)
            {
                 
                DataTable odtPrueba = new DataTable();
                DataTable odtPruebaCorta = new DataTable();

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

                decimal renumeracion = 0;
                decimal total_ingresos = 0;
                decimal total_descuentos = 0;
                decimal total_trabajador = 0;
                decimal total_empleador = 0;


                string pMes = smes;
                int pRegimenLaboral = sidtregimenlaboral;

                int indice_neto_cobrar = 0;
                int indice_prueba_neto_cobrar = 0;
                int indice_prueba_corta_neto_cobrar = 0;
                

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

                string[] arr_ingresos_max_2 = new string[80];
                string[] arr_descuento_max_2 = new string[80];
                string[] arr_a_empleador_max_2 = new string[80];
                string[] arr_a_trabajador_max_2 = new string[80];

                int k = 0;
                int t = 0;
                DataRow drFila = odtPrueba.NewRow();
                DataRow drFilaCorta = odtPruebaCorta.NewRow();

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
                odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboral(pMes, pRegimenLaboral);

                odtPrueba.Clear();

                //recorrer consulta de planilla por mes y regimen laboral
                foreach (DataRow row in odtPlanilla.Rows)
                {

                    drFila = odtPrueba.NewRow();
                    drFila.Delete();
                    //Determinar en base al id del trabajador sus ingresos
                    pidTrabajador = Convert.ToInt32(row[6]);
                    odtPlanillaXIngresos = oPlanillaIngresos.spListarPlanillaXIngresos(pMes, pRegimenLaboral, pidTrabajador);

                    foreach (DataRow row_i in odtPlanillaXIngresos.Rows)
                    {
                        // si no existe columna agregar titulo
                        if (!ExisteColumna(odtPrueba, row_i))
                        {
                            odtPrueba.Columns.Add(row_i[9].ToString().Trim(), typeof(string));
                            total_tipo_ingreso++;
                            arr_ingresos[t] = (odtPrueba.Columns.Count - 1).ToString();
                            t++;

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
                    //Buscar indice del titulo respectivo al monto
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

                    t = 0;
                    //Determinar en base al id del trabajador sus descuentos
                    odtPlanillaXDescuentos = oPlanillaDescuentos.spListarPlanillaXDescuentos(pMes, pRegimenLaboral, pidTrabajador);

                    foreach (DataRow row_d in odtPlanillaXDescuentos.Rows)
                    {
                        // si no existe columna agregar titulo
                        if (!ExisteColumna(odtPrueba, row_d))
                        {
                            odtPrueba.Columns.Add(row_d[9].ToString().Trim(), typeof(string));
                            total_tipo_descuento++;
 
                            arr_descuento[t] = (odtPrueba.Columns.Count - 1).ToString();
                            t++;
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


                    //Determinar en base al id del trabajador sus aportaciones del trabajador
                    odtPlanillaATrabajador = oPlanillaTrabajador.ListarPlanillaATrabajador(pMes, pRegimenLaboral, pidTrabajador);

                    t = 0;

                    foreach (DataRow row_t in odtPlanillaATrabajador.Rows)
                    {
                        // si no existe columna agregar titulo
                        if (!ExisteColumna(odtPrueba, row_t))
                        {
                            odtPrueba.Columns.Add(row_t[9].ToString().Trim(), typeof(string));
                            total_tipo_a_trabajador++;
                            arr_a_trabajador[t] = (odtPrueba.Columns.Count -1).ToString();
                            t++;
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

                    //Determinar en base al id del trabajador sus aportaciones del empleador
                    odtPlanillaAEmpleador = oPlanillaEmpleador.ListarPlanillaAEmpleador(pMes, pRegimenLaboral, pidTrabajador);
                    t = 0;
                    foreach (DataRow row_e in odtPlanillaAEmpleador.Rows)
                    {
                        // si no existe columna agregar titulo
                        if (!ExisteColumna(odtPrueba, row_e))
                        {
                            odtPrueba.Columns.Add(row_e[9].ToString().Trim(), typeof(string));
                            total_tipo_a_empleador++;
                            arr_a_empleador[t] = (odtPrueba.Columns.Count - 1).ToString();
                            t++;
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

                    //insertar datos personales de la planilla al datatable

                    drFila[0] = row[0]; drFila[3] = row[3]; drFila[6] = row[8];
                    drFila[1] = row[1]; drFila[4] = row[4]; drFila[7] = row[9];
                    drFila[2] = row[2]; drFila[5] = row[7]; drFila[8] = row[10]; drFila[9] = row[11];

                    renumeracion = Convert.ToDecimal(row[7]);
                    total_ingresos = Convert.ToDecimal(row[15]);
                    total_descuentos = Convert.ToDecimal(row[14]);
                    total_trabajador = Convert.ToDecimal(row[13]);
                    total_empleador = Convert.ToDecimal(row[12]);

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

                    drFila[indice_neto_cobrar] = renumeracion - total_descuentos + total_ingresos + total_trabajador + total_empleador;
                    drFila[indice_prueba_dias_laborados] = row[16];
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

                //Establecer titulos de la planilla

                odtPruebaCorta.Columns.Add("Nº", typeof(string));
                odtPruebaCorta.Columns.Add("NOMBRE COMPLETO", typeof(string));
                odtPruebaCorta.Columns.Add("CARGO", typeof(string));
                odtPruebaCorta.Columns.Add("DNI", typeof(string));
                odtPruebaCorta.Columns.Add("REMUNERACION", typeof(string));
                odtPruebaCorta.Columns.Add("FECHA INICIO", typeof(string));
                odtPruebaCorta.Columns.Add("REMUNERACION TOTAL", typeof(string));
                odtPruebaCorta.Columns.Add("SEC. FUNC.", typeof(string));
                odtPruebaCorta.Columns.Add("AFIL. AFP/SNP", typeof(string));
                odtPruebaCorta.Columns.Add("COMISION", typeof(string));
                odtPruebaCorta.Columns.Add("CUSP", typeof(string));
                                                               
                
                decimal DivisionTrabajador =   Math.Ceiling(total_tipo_a_trabajador/2);
                decimal DivisionEmpleador = Math.Ceiling( total_tipo_a_empleador/2 );
                decimal DivisionIngresos = Math.Ceiling( total_tipo_ingreso/2 );
                decimal DivisionDescuentos = Math.Ceiling( total_tipo_descuento/2 );

                int cantidad_total_ingresos = 0;
                int cantidad_total_descuentos = 0;
                int cantidad_total_a_trabajador = 0;
                int cantidad_total_a_empleador = 0;

                int nro_max_filas_x_columna = 0;

                string columna = "";

                string nueva_columna="";
                string nueva_celda = "";
                int columna_indice = 0;
                int c = 0;
                int cc = 0;
 

                //Determinar el numero maximo de filas por columna.
                nro_max_filas_x_columna = mayor(Convert.ToInt16(DivisionIngresos), mayor(mayor( Convert.ToInt16(DivisionTrabajador), Convert.ToInt16( DivisionEmpleador)), Convert.ToInt16(DivisionDescuentos)));

                //Unir descripciones de ingresos en maximo dos columnas

                if (total_tipo_ingreso > 2)
                    cantidad_total_ingresos = 2;
                else
                    cantidad_total_ingresos = 1;
                   

                for (int a = 0; a < cantidad_total_ingresos ; a++)
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

                //Unir descripciones de descuentos en maximo dos columnas

                c = 0; cc = 0;

                if (total_tipo_descuento > 2)
                    cantidad_total_descuentos = 2;
                else
                    cantidad_total_descuentos = 1;


                for (int a = 0; a < cantidad_total_descuentos; a++)
                {
                    nueva_columna = "";
                    for (int b = 0; b < nro_max_filas_x_columna; b++)
                    {
                        if (arr_descuento[c] != null)
                        {
                            // Añade la columna de total de ingresos
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


                //Unir descripciones de trabajador en maximo dos columnas
                c = 0; cc = 0;
                if (total_tipo_a_trabajador > 2)
                    cantidad_total_a_trabajador = 2;
                else
                    cantidad_total_a_trabajador = 1;
 

                for (int a=0; a < cantidad_total_a_trabajador; a++)
                {
                    nueva_columna = "";
                    for (int b = 0; b < nro_max_filas_x_columna; b++)
                    {
                        if ( arr_a_trabajador[c] != null)
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

                //Unir descripciones de empleador en maximo dos columnas
                c = 0; cc = 0;
                if (total_tipo_a_empleador > 2)
                    cantidad_total_a_empleador = 2;
                else
                    cantidad_total_a_empleador = 1;


                for (int a = 0; a < cantidad_total_a_empleador; a++)
                {
                    nueva_columna = "";
                    for (int b = 0; b < nro_max_filas_x_columna; b++)
                    {
                        if (arr_a_empleador[c] != null)
                        {
                            columna = odtPrueba.Columns[Convert.ToInt32(arr_a_empleador[c])].ToString();

                            if(c == 0 || c == nro_max_filas_x_columna) nueva_columna = columna;
                            else nueva_columna = nueva_columna + "\n\n" + columna;


                            c++;
                        }
                    }
                    odtPruebaCorta.Columns.Add(nueva_columna);
                    arr_a_empleador_max_2[cc] = (odtPruebaCorta.Columns.Count - 1).ToString();
                    cc++;
                }

                //esribir datos de planilla

                for (int d=0; d < odtPrueba.Rows.Count ; d++)
                {
                    drFilaCorta = odtPruebaCorta.NewRow();
                    drFilaCorta.Delete();


                    //Obteniendo los montos respectivos de la descripcion de ingresos agrupados en un maximo de dos columnas
                    c = 0;
                    for (int a = 0; a < cantidad_total_ingresos; a++)
                    {
                        nueva_celda = "";
                        for (int b = 0; b < nro_max_filas_x_columna; b++)
                        {
                            if (arr_ingresos[c] != null)
                            {
                                if (c == 0 || c == nro_max_filas_x_columna) nueva_celda = nueva_celda + odtPrueba.Rows[d][Convert.ToInt32(arr_ingresos[c])];
                                else nueva_celda = nueva_celda + "\n\n" + odtPrueba.Rows[d][Convert.ToInt32(arr_ingresos[c])] ;
                                c++;
                            }

                        }
                                                
                        if (arr_ingresos_max_2[a] != null)
                        {
                            columna_indice = Convert.ToInt16(arr_ingresos_max_2[a]) ;
                            drFilaCorta[columna_indice] = nueva_celda;
                        }
 
                    }

                    //Obteniendo los montos respectivos de la descripcion de descuentos agrupados en un maximo de dos columnas
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

                    //Obteniendo los montos respectivos de la descripcion de aportaciones del trabajador agrupados en un maximo de dos columnas
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

                    //Obteniendo los montos respectivos de la descripcion de aportaciones del empleador agrupados en un maximo de dos columnas
                    c = 0;
                    for (int a = 0; a < cantidad_total_a_empleador ; a++)
                    {
                        nueva_celda = "";
                        for (int b = 0; b < nro_max_filas_x_columna; b++)
                        {
                            if (arr_a_empleador[c] != null)
                            {
                                if (c==0 || c== nro_max_filas_x_columna) nueva_celda = nueva_celda + odtPrueba.Rows[d][Convert.ToInt32(arr_a_empleador[c])];
                                else    nueva_celda = nueva_celda + "\n\n" + odtPrueba.Rows[d][Convert.ToInt32(arr_a_empleador[c])];
                                c++;
                            }

                        }

                        if (arr_a_empleador_max_2[a] != null)
                        {
                            columna_indice = Convert.ToInt16(arr_a_empleador_max_2[a]);
                            drFilaCorta[columna_indice] = nueva_celda;
                        }

                    }


                    //insertar datos personales de la planilla al datatable

                    drFilaCorta[0] = (d + 1); drFilaCorta[3] = odtPrueba.Rows[d][2]; drFilaCorta[6] = odtPrueba.Rows[d][5];
                    drFilaCorta[1] = odtPrueba.Rows[d][0]; drFilaCorta[4] = odtPrueba.Rows[d][3]; drFilaCorta[7] = odtPrueba.Rows[d][6];
                    drFilaCorta[2] = odtPrueba.Rows[d][1]; drFilaCorta[8] = odtPrueba.Rows[d][7];

                    drFilaCorta[5] = Convert.ToDateTime(odtPrueba.Rows[d][4]).Date.ToString("MM/dd/yyyy");

                    drFilaCorta[9] = odtPrueba.Rows[d][8]; drFilaCorta[10] = odtPrueba.Rows[d][9];

                    if (!ExisteColumnaTexto(odtPruebaCorta, "NETO A COBRAR"))
                    {
                        odtPruebaCorta.Columns.Add("NETO A COBRAR", typeof(string));
                        indice_prueba_corta_neto_cobrar = BuscarIndiceColumna(odtPruebaCorta, "NETO A COBRAR");
                        indice_prueba_neto_cobrar = BuscarIndiceColumna(odtPrueba, "NETO A COBRAR");
                    }

                    if (!ExisteColumnaTexto(odtPruebaCorta, "DIAS LABORADOS"))
                    {
                        odtPruebaCorta.Columns.Add("DIAS LABORADOS", typeof(string));
                        indice_prueba_corta_dias_laborados = BuscarIndiceColumna(odtPruebaCorta, "DIAS LABORADOS");
                        indice_prueba_dias_laborados = BuscarIndiceColumna(odtPrueba, "DIAS LABORADOS");
                    }

                    drFilaCorta[indice_prueba_corta_dias_laborados] = odtPrueba.Rows[d][indice_prueba_dias_laborados];
                    drFilaCorta[indice_prueba_corta_neto_cobrar] = odtPrueba.Rows[d][indice_prueba_neto_cobrar];
                    odtPruebaCorta.Rows.InsertAt(drFilaCorta, d);

                }


                odtPruebaCorta.Columns.Add("FIRMA", typeof(string));

                this.dgvPrueba.DataSource = odtPruebaCorta;
                exportar_a_pdf();
            }
            else
                MessageBox.Show("Por favor cerrar PDF Reporte.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public int mayor(int a, int b) {
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
                if (i == 1) values[i] =200;
            }
            return values;
        }

        private void exportar_a_pdf(  )
        {
            //Creating iTextSharp Table from the DataTable data
            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 7);
            iTextSharp.text.Font fuenteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 9,1, iTextSharp.text.Color.BLUE);
            



            PdfPTable pdfTable = new PdfPTable(dgvPrueba.ColumnCount);

            Phrase objP = new Phrase("A", fuente);
            //Phrase objH = new Phrase("A", fuenteTitulo);
            PdfPCell cell;

            


            pdfTable.DefaultCell.Padding = 1;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            float[] headerwidths = GetTamañoColumnas(dgvPrueba);
            //float[] headerwidths = { 2f, 6f, 6f, 3f, 5f, 8f, 5f, 5f, 5f, 5f };

            //cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#d1dbe0"));

            pdfTable.SetWidths(headerwidths);
            pdfTable.WidthPercentage = 100;

            //Adding Header row
            foreach (DataGridViewColumn column in dgvPrueba.Columns)
            {
                cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font( iTextSharp.text.Font.BOLD , 7f, iTextSharp.text.Font.BOLD , iTextSharp.text.Color.BLACK ))));
                //cell = new PdfPCell(new Phrase(column.HeaderText));
                //PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                 

                // objH = new Phrase(column.HeaderText, fuenteTitulo);


                pdfTable.AddCell(cell);
            }

            

            for (int i = 0; i < dgvPrueba.RowCount - 1; i++)
            {
                for (int j = 0; j < dgvPrueba.ColumnCount; j++)
                {
                    objP = new Phrase(dgvPrueba[j, i].Value.ToString(), fuente);

                    pdfTable.AddCell(objP);

                }
                pdfTable.CompleteRow();
            }



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

                Document pdfDoc = new Document(PageSize.A4, 9, 9, 10, 10);
                pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());

                Paragraph paragraph = new Paragraph();
                paragraph.Alignment = Element.ALIGN_CENTER;
                paragraph.Font = FontFactory.GetFont( FontFactory.TIMES_BOLD , 12);
                paragraph.Add("MUNICIPALIDAD DISTRITAL DE CCATCCA \n UNIDAD DE PERSONAL \n ");

                Paragraph paragraph2 = new Paragraph();
                paragraph2.Alignment = Element.ALIGN_RIGHT;
                paragraph2.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                paragraph2.Add("PLANILLA Nº"+ sNumeroPlanilla + "\n ");

                Paragraph paragraph3 = new Paragraph();
                paragraph3.Alignment = Element.ALIGN_CENTER;
                paragraph3.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                paragraph3.Add("PLANILLA DE RENUMERACIONES DEL PERSONAL DE " + sRegimenLaboral + "\n ");
               
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(paragraph);
                pdfDoc.Add(paragraph2);
                pdfDoc.Add(paragraph3);
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "C:\\PDFs\\DataGridViewExport.pdf";
            proc.Start();

        }

        private void cboRegimenLaboral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRegimenLaboral.Text != "System.Data.DataRowView" && cboRegimenLaboral.ValueMember != "")
            {
                sidtregimenlaboral = Convert.ToInt32(cboRegimenLaboral.SelectedValue);
                CargarDatos();
            }
        }

        private void dgvPlanilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPlanilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

            if (e.RowIndex != -1)
            {
                sidtplanilla = Convert.ToInt32(dgvPlanilla.Rows[e.RowIndex].Cells[0].Value);
                snumero = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[1].Value);
                smes = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[2].Value);
                saño = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[3].Value);
                sfecha = Convert.ToDateTime(dgvPlanilla.Rows[e.RowIndex].Cells[4].Value);
                sidtmeta = Convert.ToInt32(dgvPlanilla.Rows[e.RowIndex].Cells[5].Value);
                smeta = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[6].Value);
                sidtfuentefinanciamiento = Convert.ToInt32(dgvPlanilla.Rows[e.RowIndex].Cells[7].Value);
                sfuentefinanciamiento = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[8].Value);
                sNumeroPlanilla = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[1].Value);


                DataTable odtPrueba = new DataTable();
                odtPrueba = oPlanilla.ListarRegimenLaboralPlanilla(sNumeroPlanilla);

                foreach (DataRow row in odtPrueba.Rows)
                    sRegimenLaboral = row[0].ToString();

            }
        }

        private void CargarRegimenLaboral()
        {
            CapaDeNegocios.DatosLaborales.cRegimenLaboral miRegimenLaboral = new CapaDeNegocios.DatosLaborales.cRegimenLaboral();
            cboRegimenLaboral.DataSource = miRegimenLaboral.ListarRegimenLaboral();
            cboRegimenLaboral.DisplayMember = "descripcion";
            cboRegimenLaboral.ValueMember = "idtregimenlaboral";
        }

        private void CargarDatos()
        {
            dgvPlanilla.Rows.Clear();
            DataTable oDataPlanilla = new DataTable();
            oDataPlanilla = miPlanilla.ListarPlanilla(sidtregimenlaboral);

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
                dgvPlanilla.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), sidtmeta, smeta, sidtfuentefinanciamiento, sfuentefinanciamiento);
                
            }
            if (dgvPlanilla.Rows.Count > 0)
            {
                DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, dgvPlanilla.Rows.Count - 1);
                dgvPlanilla.Rows[dgvPlanilla.Rows.Count - 1].Selected = true;
                dgvPlanilla_CellClick(dgvPlanilla, cea);
            }
        }

        private void dgvPrueba_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
