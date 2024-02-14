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
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Collections.Generic;
using iTextSharp;
using System.Web;
using System.Globalization;

//using iTextSharp.text.pdf.PdfWriter;


namespace CapaUsuario.Reportes
{
    public partial class frmPlanilla : Form
    {
        Boolean columnasFijas = false;
        float altoColumna;
        DataTable odtPrueba = new DataTable();
        DataTable odtPruebaCorta = new DataTable();
        DataTable odtATrabajador = new DataTable();
        DataTable odtRedondear = new DataTable();
        DataTable odtEEFF = new DataTable();

        DataTable odtPlanilla = new DataTable();
        DataTable odtPlanillaXIngresos = new DataTable();
        DataTable odtPlanillaXDescuentos = new DataTable();
        DataTable odtPlanillaAEmpleador = new DataTable();
        DataTable odtPlanillaATrabajador = new DataTable();
        DataTable odtMeta = new DataTable();

        string pmes = "";
        string paño = "";
        string pmes_nro = "";

        decimal monto_renta_quinta = 0;

        int iindice_essalud_vida = 0;
        int iindice_4ta = 0;
        int iindice_essalud_seguro_regular = 0;
        int iindice_essalud_cbbsp = 0;
        int iindice_essalud_seguro_complementario = 0;

        int iindice_snp_dl = 0;
        int iindice_renta_quinta = 0;

        int sidtplanilla = 0;
        string snumero = "";
        string smes = "";
        string saño = "";
        string smeta = "";
        string smeta_numero = "";
        DateTime sfecha;
        int sidtmeta = 0;
        int sidtfuentefinanciamiento = 0;
        int sidtregimenlaboral = 0;
        //string smeta = "";
        string sfuentefinanciamiento = "";
        string sdescripcion = "";
        string splantilla = "";

        string sNumeroPlanilla = "";
        string sRegimenLaboral = "";

        string FechaTexto = "";

        //CapaUsuario.Reportes.frmPlanilla fPlanilla = new CapaUsuario.Reportes.frmPlanilla();
        CapaDeNegocios.Planillas.cPlanilla miPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

        CapaDeNegocios.cDatosGenerales oDatosGenerales = new CapaDeNegocios.cDatosGenerales();


        string numeroPlanilla = "";

        public frmPlanilla()
        {
           
            InitializeComponent();
            DateTime Ahora = DateTime.Today;
            CargarMes(Ahora);
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

         



        public void CreateHeaderFooter(ref Document _document)
        {
            var headerfooter = FontFactory.GetFont("Arial", 8);
            HeaderFooter header = (new HeaderFooter(new Phrase("Boleta de Pago", headerfooter), false));
            header.BorderColorTop = new iTextSharp.text.Color(System.Drawing.Color.Red);
            header.BorderWidthTop = 0f;
            //_document.Header = header;
            //string ppath = "C:\\PDFs\\Planilla.pdf";
            //PdfReader pdfReader = new PdfReader(ppath);
            //int cantidad_paginas = _pdfreader.PageNumber;
            //int numberOfPages = pdfReader.NumberOfPages;
            
            HeaderFooter Footer = new HeaderFooter(new Phrase("  "  , headerfooter), true);
            Footer.BorderColorBottom = new iTextSharp.text.Color(System.Drawing.Color.White);
            Footer.BorderWidthBottom = 0f;
            Footer.BorderWidthTop = 0f;
            Footer.BorderWidthLeft = 0f;
            Footer.BorderWidthRight = 0f;
            _document.Footer = Footer;
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

        class Item
        {
            string _Name;
            int _Id;



            public Item(string name, int id)
            {
                _Name = name;
                _Id = id;
            }

            public string Name
            {
                get { return _Name; }
                set { _Name = value; }
            }


            public int Id
            {
                get { return _Id; }
                set { _Id = value; }
            }
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

        private void frmPlanilla_Load(object sender, EventArgs e)
        {
            if (oDatosGenerales.Ruc == "20159308708")
            {
                chkSubGerenciaObras.Text = "GERENCIA";
                chkGerenciaAdministracion.Text = "GERENCIA DE ADMINISTRACION";
            }
            DataTable odtA = new DataTable();
            DataTable odtAños = new DataTable();
            DataTable odtPlanilla = new DataTable();

            CapaDeNegocios.Reportes.cBoletaPago oBoletaPago = new CapaDeNegocios.Reportes.cBoletaPago();
            CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

            int numero_boleta_pago = 0;

            //dgvBoletaPago.DataSource = oPlanilla.ListarBoletaPagoXMesYRegimenLaboral();
            //Llenando combobox mes y año
            cboMes.DisplayMember = "Name";
            cboMes.ValueMember = "Id";

            cboMes.Items.Add(new Item("ENERO", 1));
            cboMes.Items.Add(new Item("FEBRERO", 2));
            cboMes.Items.Add(new Item("MARZO", 3));
            cboMes.Items.Add(new Item("ABRIL", 4));
            cboMes.Items.Add(new Item("MAYO", 5));
            cboMes.Items.Add(new Item("JUNIO", 6));
            cboMes.Items.Add(new Item("JULIO", 7));
            cboMes.Items.Add(new Item("AGOSTO", 8));
            cboMes.Items.Add(new Item("SETIEMBRE", 9));
            cboMes.Items.Add(new Item("OCTUBRE", 10));
            cboMes.Items.Add(new Item("NOVIEMBRE", 11));
            cboMes.Items.Add(new Item("DICIEMBRE", 12));

            cboMes.SelectedIndex = 0;
            odtAños = oPlanilla.ListarAñosPlanilla();
            cboAño.DataSource = odtAños;
            cboAño.DisplayMember = "añó";
            cboAño.ValueMember = "año";
            cboMes.Text = FechaTexto;
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
            oDataPlanilla = miPlanilla.ListarPlanillaXmesYaño(pmes, paño);

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
                smeta_numero = row[10].ToString();
                dgvPlanilla.Rows.Add(row[0].ToString(), row[1].ToString(), row[8].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), sidtmeta, smeta, smeta_numero, sidtfuentefinanciamiento, sfuentefinanciamiento, row[7].ToString(), row[9].ToString());
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
            if (txtAltoColumnas.Text == "")
            {
                altoColumna = 0;
            }
            else
            {
                altoColumna = Convert.ToInt16(txtAltoColumnas.Text);
            }
           
            FileInfo file = new FileInfo("C:\\PDFs\\Planilla.pdf");
            bool estaAbierto = IsFileinUse(file, "C:\\PDFs\\Planilla.pdf");
            if (!estaAbierto)
            {
                decimal haber_total = 0;


                int ultima_fila_planilla = 0;
                int ultima_fila_prueba = 0;


                decimal snp_total = 0;
                decimal afp_total = 0;
                decimal neto_cobrar_total = 0;
                decimal aportacion_entidad_total = 0;
                decimal ad_total = 0;
                decimal cs_total = 0;
                decimal daomj_total = 0;
                decimal ta_total = 0;
                decimal in_total = 0;
                decimal odndbm_total = 0;
                decimal oddbi_total = 0;
                decimal desc_caja_total = 0;
                decimal renta_5ta_cat_total = 0;
                decimal renta_4ta_cat_total = 0;
                decimal desc_judi_total = 0;
                decimal desc_rimac_total = 0;
                decimal faltas_sanciones_total = 0;
                decimal aporte_essalud_total = 0;

                CapaDeNegocios.ClasificadorMeta.cClasificadoresxMetaxPlantilla oClasificadoresxMetaxPLantilla = new CapaDeNegocios.ClasificadorMeta.cClasificadoresxMetaxPlantilla();

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


                decimal monto_essalud_vida = 0;
                decimal monto_essalud_seguro_regular = 0;
                decimal monto_essalud_cbbsp = 0;
                decimal monto_essalud_seguro_complementario = 0;
                decimal monto_essalud_seguro_complementario_Pension = 0;
                decimal monto_essalud_seguro_complementario_Privado = 0;

                decimal monto_snp_dl = 0;

                decimal total_tipo_ingreso = 0;
                decimal total_tipo_descuento = 0;
                decimal total_tipo_a_empleador = 0;
                decimal total_tipo_a_trabajador = 0;

                int indice_prueba_dias_laborados = 0;
                int indice_prueba_corta_dias_laborados = 0;
                int indice_cuenta_bancaria = 0;
                int indice_prueba_corta_cuenta_bancaria = 0;

                string[] arr_ingresos = new string[160];
                string[] arr_descuento = new string[160];
                string[] arr_a_empleador = new string[160];
                string[] arr_a_trabajador = new string[160];

                bool fIngresos = false;
                bool fDescuentos = false;
                bool fATrabajador = false;
                bool fAEmpleador = false;



                string[] arr_ingresos_max_2 = new string[80];
                string[] arr_descuento_max_2 = new string[80];
                string[] arr_a_empleador_max_2 = new string[80];
                string[] arr_a_trabajador_max_2 = new string[80];

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
                decimal sumatoria_aporte_entidad = 0;
                decimal monto_dec_afp = 0;
                decimal sumatoria_dec_afp = 0;

                string columna_essalud_vida = "";
                string columna_essalud_regular = "";
                string columna_essalud_trabajador = "";
                string columna_essalud_complementario = "";
                string columna_essalud_trabajador_pension = "";
                string columna_essalud_complementario_privado = "";
                string columna_aporte_entidad = "";
                string columna_renta_5ta = "";
                string columna_snp = "";

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
                int indice_dec_afp = 0;


                decimal remuneracion_jornal_total = 0;
                decimal remuneracion_permanente_total = 0;
                decimal ingresos_cas_total = 0;
                decimal remuneracion_total = 0;
                decimal essalud_vida_total = 0;
                decimal essalud_seguro_regular_total = 0;
                decimal essalud_cbbsp_total = 0;
                decimal essalud_seguro_complementario_total = 0;
                decimal aportacion_trabajador_total = 0;
                decimal total_ingresos_total = 0;
                decimal total_a_empleador_total = 0;
                decimal total_debe = 0;

                int cantidad_ingresos = 0;
                int cantidad_descuentos = 0;
                int cantidad_a_trabajador = 0;
                int cantidad_a_empleador = 0;

                int pRegimenLaboral = sidtregimenlaboral;

                int indice_dsco_afp = 0;
                int indice_neto_cobrar = 0;
                int indice_prueba_neto_cobrar = 0;
                int indice_prueba_corta_neto_cobrar = 0;
                int indice_aporte_entidad = 0;

                int iindice_snp_13 = 0;
                int iindice_afp = 0;
                int iindice_neto_cobrar = 0;
                int iindice_aportacion_entidad = 0;
                int iindice_ad = 0;
                int iindice_cs = 0;
                int iindice_daomj = 0;
                int iindice_ta = 0;
                int iindice_in = 0;
                int iindice_odndbm = 0;
                int iindice_oddbi = 0;
                int iindice_desc_caja = 0;
                int iindice_renta_5ta_cat = 0;
                int iindice_renta_4ta_cat = 0;
                int iindice_desc_judi = 0;
                int iindice_desc_rimac = 0;
                int iindice_faltas_sanciones = 0;
                int iindice_aporte_essalud = 0;

                int pidTrabajador = 0;
                int indice_ingreso = 0;
                int indice_descuento = 0;

                int indice_a_empleador = 0;
                int indice_a_trabajador = 0;

                int iindice_ingresos = 0;
                int iindice_descuentos = 0;
                int iindice_a_empleador = 0;
                int iindice_a_trabajador = 0;
                int iindice_dec_afp = 0;
                int iindice_aporte_entidad = 0;
                /* Agregando SNP 13% y AFP */
                int indice_snp = 0;
                int indice_afp = 0;

                int lll = 0;
                int iindice_remuneracion = 0;
                int iindice_essalud = 0;
                int iindice_remuneracion_jornal_basico = 0;
                int iindice_remuneracion_permanente = 0;
                int iindice_ingresos_cas = 0;
                int iindice_aportacion_trabajador = 0;

                int iindice_seguro_essalud_privado = 0;
                int iindice_seguro_pension = 0;

                int iindice_total_ingresos = 0;
                int iindice_total_a_empleador = 0;
                int ultima_fila_prueba_corta = 0;

                int ultima_fila = 0;
                int cantidad_total_ingresos = 0;
                int cantidad_total_descuentos = 0;
                int cantidad_total_a_trabajador = 0;
                int cantidad_total_a_empleador = 0;
                int nro_max_filas_x_columna = 0;
                int columna_indice = 0;
                int c = 0;
                int cc = 0;
                int k = 0;
                int t = 0;

                string columna = "";
                string nueva_columna = "";
                string nueva_celda = "";

                DataRow drFila = odtPrueba.NewRow();
                DataRow drFilaCorta = odtPruebaCorta.NewRow();
                DataRow drFilaATrabajador = odtATrabajador.NewRow();
                DataRow drFilaRedondear = odtRedondear.NewRow();
                DataRow drFilaEEFF = odtEEFF.NewRow();

                #region Regidores
                if (splantilla == "REGIDORES")
                {
                    //Limpiando titulos de la plantilla
                    odtPrueba.Columns.Clear();

                    //Establecer titulos de la planilla
                    odtPrueba.Columns.Add("Nro.", typeof(string));
                    odtPrueba.Columns.Add("NOMBRE COMPLETO", typeof(string));
                    odtPrueba.Columns.Add("CARGO", typeof(string));
                    odtPrueba.Columns.Add("DNI", typeof(string));

                    odtPrueba.Columns.Add("NRO. SESIONES", typeof(string));
                    odtPrueba.Columns.Add("PAGO x SESION", typeof(string));
                    odtPrueba.Columns.Add("NETO A COBRAR", typeof(string));
                    if (chkCuentaBancaria.Checked)
                    {
                        odtPrueba.Columns.Add("CUENTA BANCARIA", typeof(string));
                        odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboralRacionamientoBancaria(sidtplanilla, pRegimenLaboral, pmes_nro, paño);
                    }
                    else
                    {
                        odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboralRacionamiento(sidtplanilla, pRegimenLaboral, pmes_nro, paño);
                    }
                    odtPlanilla = buscarDuplicados(odtPlanilla);
                    odtPrueba.Clear();
                    indice_prueba_dias_laborados = BuscarIndiceColumna(odtPrueba, "NRO. SESIONES");
                    indice_neto_cobrar = BuscarIndiceColumna(odtPrueba, "NETO A COBRAR");

                    DataTable auxiliarNumeroTrabPlanilla = oPlanilla.ListarDetallePlanilla(sidtplanilla);

                    if (odtPlanilla.Rows.Count != auxiliarNumeroTrabPlanilla.Rows.Count)
                    {
                        MessageBox.Show("El numero de trabajadores " + odtPlanilla.Rows.Count.ToString() + " , es diferente al numero de trabajadores activos en el mes " + auxiliarNumeroTrabPlanilla.Rows.Count.ToString(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (odtPlanilla.Rows.Count > 0)
                    {
                        //Consultar meta de planilla
                        decimal sumatoria = 0;
                        int indice = 0;
                        //recorrer consulta de planilla por id plantilla y regimen laboral
                        foreach (DataRow row in odtPlanilla.Rows)
                        {
                            indice++;

                            drFila = odtPrueba.NewRow();
                            drFila.Delete();
                            //Determinar en base al id del trabajador sus ingresos
                            pidTrabajador = Convert.ToInt32(row[5]);

                            drFila[0] = indice.ToString();
                            drFila[1] = row[0];
                            drFila[2] = row[1];
                            drFila[3] = row[2];
                            drFila[4] = row[12];
                            if (Convert.ToDecimal(row[12]) == 0)
                            {
                                drFila[5] = 0;
                            }
                            else
                            {
                                drFila[5] = Math.Round(Convert.ToDecimal(row[11]) / Convert.ToDecimal(row[12]), 2);
                            }
                            
                            drFila[6] = row[11];
                            if (chkCuentaBancaria.Checked)
                            {
                                drFila[7] = row[13];
                            }
                            sumatoria = sumatoria + Convert.ToDecimal(row[11]);

                            //odtPrueba.Rows.Add(drFila);
                            odtPrueba.Rows.InsertAt(drFila, k);

                            k++;
                        }
                        if (oDatosGenerales.Ruc == "20159308708")
                        {
                           // odtPrueba.Columns.Add("OBSERVACIONES", typeof(string));
                        }
                        else
                        {
                            odtPrueba.Columns.Add("OBSERVACIONES", typeof(string));
                        }

                        this.dgvPrueba.DataSource = odtPrueba;

                        drFila = odtPrueba.NewRow();
                        //Insertando totales de las obligaciones
                        drFila[0] = "TOTAL";
                        drFila[6] = sumatoria;

                        odtPrueba.Rows.InsertAt(drFila, k);


                        /* Cuadro de redondear a entero */
                        odtRedondear.Columns.Clear();
                        odtRedondear.Rows.Clear();

                        CapaDeNegocios.Obras.cMeta ooMeta = new CapaDeNegocios.Obras.cMeta();
                        CapaDeNegocios.Planillas.cPlantillaPlanilla ooPlantilla = new CapaDeNegocios.Planillas.cPlantillaPlanilla();
                        List<CapaDeNegocios.ClasificadorMeta.cClasificadorMeta> ListaClasificadoresMeta = new List<CapaDeNegocios.ClasificadorMeta.cClasificadorMeta>();
                        ooMeta.Codigo = sidtmeta;
                        ooPlantilla.Descripcion = splantilla;



                        ListaClasificadoresMeta = oClasificadoresxMetaxPLantilla.ListaClasificadoresMeta(ooPlantilla, ooMeta);
                        //Agregando columnas al cuadro redondear a entero
                        odtRedondear.Columns.Add("Clasificador", typeof(string));
                        odtRedondear.Columns.Add("Concepto", typeof(string));
                        odtRedondear.Columns.Add("Monto", typeof(string));

                        //iindice_total_ingresos = BuscarIndiceColumna(odtPruebaCorta, "TOTAL");
                        ////iindice_total_a_empleador = BuscarIndiceColumna(odtPruebaCorta, "TOTAL APORTACIONES EMPLEADOR");

                        //ultima_fila_prueba_corta = odtPruebaCorta.Rows.Count - 1;
                        //total_ingresos_total = Convert.ToDecimal(odtPruebaCorta.Rows[ultima_fila_prueba_corta][iindice_total_ingresos]);

                        //ultima_fila_prueba_corta = odtPruebaCorta.Rows.Count - 1;
                        ////total_a_empleador_total = Convert.ToDecimal(odtPruebaCorta.Rows[ultima_fila_prueba_corta][iindice_total_a_empleador]);

                        foreach (CapaDeNegocios.ClasificadorMeta.cClasificadorMeta item in ListaClasificadoresMeta)
                        {
                            string MontoConcepto = "";

                            int index = item.Concepto.IndexOf("&&");



                            if (index != -1)
                            {
                                MontoConcepto = "";
                            }
                            else
                            {



                                switch (item.Concepto)
                                {
                                    case "Todo":
                                        MontoConcepto = sumatoria.ToString("0.00");
                                        break;
                                    //case "0122":
                                    //    MontoConcepto = total_ingresos_total.ToString("0.00");
                                    //    break;
                                    //case "2039":
                                    //    MontoConcepto = total_ingresos_total.ToString("0.00");
                                    //    break;
                                    case "0804":
                                        MontoConcepto = monto_essalud_seguro_regular.ToString("0.00");
                                        break;
                                    case "0806":
                                        MontoConcepto = monto_essalud_seguro_complementario.ToString("0.00");
                                        break;
                                    case "Total Ingresos":
                                        MontoConcepto = total_ingresos_total.ToString("0.00");
                                        break;
                                    case "Total Aportaciones":
                                        MontoConcepto = total_a_empleador_total.ToString("0.00");
                                        break;
                                    default:
                                        DataTable maestroIngreso = oClasificadoresxMetaxPLantilla.BuscarMaestroIngresoXCodigo(item.Concepto);
                                        string abreviacion = maestroIngreso.Rows[0]["abreviacion"].ToString();

                                        int indice_Ingresos_clasificador = BuscarIndiceColumna(odtPrueba, abreviacion);
                                        if (indice_Ingresos_clasificador != -1)
                                        {
                                            decimal montoClasificaor = Convert.ToDecimal(odtPrueba.Rows[odtPrueba.Rows.Count - 1][indice_Ingresos_clasificador]);
                                            MontoConcepto = montoClasificaor.ToString("0.00");
                                        }
                                        else
                                        {
                                            MontoConcepto = "0.00";
                                        }

                                        break;
                                }
                            }
                            odtRedondear.Rows.Add(item.Especifica.Codigo, item.Especifica.Nombre, MontoConcepto);
                            dgvRedondear.DataSource = odtRedondear;
                        }


                        exportar_a_pdf_Racionamiento(sidtregimenlaboral);
                    }
                }
                #endregion
                else
                {
                    #region Planilla Racionamiento
                    if (splantilla == "RACIONAMIENTO")
                    {
                        //Limpiando titulos de la plantilla
                        odtPrueba.Columns.Clear();

                        //Establecer titulos de la planilla
                        odtPrueba.Columns.Add("Nro.", typeof(string));
                        odtPrueba.Columns.Add("NOMBRE COMPLETO", typeof(string));
                        odtPrueba.Columns.Add("CARGO", typeof(string));
                        odtPrueba.Columns.Add("DNI", typeof(string));

                        odtPrueba.Columns.Add("DIAS LABORADOS", typeof(string));
                        //OJO
                        if (chkJornalRacionamiento.Checked)
                        {
                            odtPrueba.Columns.Add("JORNAL", typeof(string));
                        }
                        else
                        {
                            odtPrueba.Columns.Add("MENSUAL", typeof(string));
                        }
                        
                        odtPrueba.Columns.Add("NETO A COBRAR", typeof(string));
                        if (chkCuentaBancaria.Checked)
                        {
                            odtPrueba.Columns.Add("CUENTA BANCARIA", typeof(string));
                            odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboralRacionamientoBancaria(sidtplanilla, pRegimenLaboral, pmes_nro, paño);
                        }
                        else
                        {
                            odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboralRacionamiento(sidtplanilla, pRegimenLaboral, pmes_nro, paño);
                        }
                        odtPlanilla = buscarDuplicados(odtPlanilla);
                        odtPrueba.Clear();

                        indice_prueba_dias_laborados = BuscarIndiceColumna(odtPrueba, "DIAS LABORADOS");
                        indice_neto_cobrar = BuscarIndiceColumna(odtPrueba, "NETO A COBRAR");

                        DataTable auxiliarNumeroTrabPlanilla = oPlanilla.ListarDetallePlanilla(sidtplanilla);

                        if (odtPlanilla.Rows.Count != auxiliarNumeroTrabPlanilla.Rows.Count)
                        {
                            MessageBox.Show("El numero de trabajadores " + odtPlanilla.Rows.Count.ToString() + " , es diferente al numero de trabajadores activos en el mes " + auxiliarNumeroTrabPlanilla.Rows.Count.ToString(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        if (odtPlanilla.Rows.Count > 0)
                        {
                            //Consultar meta de planilla
                            decimal sumatoria = 0;
                            int indice = 0;
                            //recorrer consulta de planilla por id plantilla y regimen laboral
                            foreach (DataRow row in odtPlanilla.Rows)
                            {
                                indice++;

                                drFila = odtPrueba.NewRow();
                                drFila.Delete();
                                //Determinar en base al id del trabajador sus ingresos
                                pidTrabajador = Convert.ToInt32(row[5]);

                                drFila[0] = indice.ToString();
                                drFila[1] = row[0];
                                drFila[2] = row[1];
                                drFila[3] = row[2];
                                drFila[4] = row[12];
                                if (chkJornalRacionamiento.Checked)
                                {
                                    drFila[5] = Math.Round(Convert.ToDecimal(row[11]) / Convert.ToDecimal(row[12]), 2);
                                }
                                else
                                {
                                    drFila[5] = row[11]; // Math.Round(Convert.ToDecimal(row[11]) / Convert.ToDecimal(row[12]), 2);
                                }
                                
                                drFila[6] = row[11];
                                if (chkCuentaBancaria.Checked)
                                {
                                    drFila[7] = row[13];
                                }
                                sumatoria = sumatoria + Convert.ToDecimal(row[11]);

                                //odtPrueba.Rows.Add(drFila);
                                odtPrueba.Rows.InsertAt(drFila, k);

                                k++;
                            }
                            if (oDatosGenerales.Ruc == "20159308708")
                            {
                                //odtPrueba.Columns.Add("OBSERVACIONES", typeof(string));
                            }
                            else
                            {
                                odtPrueba.Columns.Add("OBSERVACIONES", typeof(string));
                            }

                            this.dgvPrueba.DataSource = odtPrueba;

                            drFila = odtPrueba.NewRow();
                            //Insertando totales de las obligaciones
                            drFila[0] = "TOTAL";
                            drFila[6] = sumatoria;

                            odtPrueba.Rows.InsertAt(drFila, k);


                            /* Cuadro de redondear a entero */
                            odtRedondear.Columns.Clear();
                            odtRedondear.Rows.Clear();

                            CapaDeNegocios.Obras.cMeta ooMeta = new CapaDeNegocios.Obras.cMeta();
                            CapaDeNegocios.Planillas.cPlantillaPlanilla ooPlantilla = new CapaDeNegocios.Planillas.cPlantillaPlanilla();
                            List<CapaDeNegocios.ClasificadorMeta.cClasificadorMeta> ListaClasificadoresMeta = new List<CapaDeNegocios.ClasificadorMeta.cClasificadorMeta>();
                            ooMeta.Codigo = sidtmeta;
                            ooPlantilla.Descripcion = splantilla;



                            ListaClasificadoresMeta = oClasificadoresxMetaxPLantilla.ListaClasificadoresMeta(ooPlantilla, ooMeta);
                            //Agregando columnas al cuadro redondear a entero
                            odtRedondear.Columns.Add("Clasificador", typeof(string));
                            odtRedondear.Columns.Add("Concepto", typeof(string));
                            odtRedondear.Columns.Add("Monto", typeof(string));

                            //iindice_total_ingresos = BuscarIndiceColumna(odtPruebaCorta, "TOTAL");
                            ////iindice_total_a_empleador = BuscarIndiceColumna(odtPruebaCorta, "TOTAL APORTACIONES EMPLEADOR");

                            //ultima_fila_prueba_corta = odtPruebaCorta.Rows.Count - 1;
                            //total_ingresos_total = Convert.ToDecimal(odtPruebaCorta.Rows[ultima_fila_prueba_corta][iindice_total_ingresos]);

                            //ultima_fila_prueba_corta = odtPruebaCorta.Rows.Count - 1;
                            ////total_a_empleador_total = Convert.ToDecimal(odtPruebaCorta.Rows[ultima_fila_prueba_corta][iindice_total_a_empleador]);

                            foreach (CapaDeNegocios.ClasificadorMeta.cClasificadorMeta item in ListaClasificadoresMeta)
                            {
                                string MontoConcepto = "";

                                int index = item.Concepto.IndexOf("&&");



                                if (index != -1)
                                {
                                    MontoConcepto = "";
                                }
                                else
                                {



                                    switch (item.Concepto)
                                    {
                                        case "Todo":
                                            MontoConcepto = sumatoria.ToString("0.00");
                                            break;
                                        //case "0122":
                                        //    MontoConcepto = total_ingresos_total.ToString("0.00");
                                        //    break;
                                        //case "2039":
                                        //    MontoConcepto = total_ingresos_total.ToString("0.00");
                                        //    break;
                                        case "0804":
                                            MontoConcepto = monto_essalud_seguro_regular.ToString("0.00");
                                            break;
                                        case "0806":
                                            MontoConcepto = monto_essalud_seguro_complementario.ToString("0.00");
                                            break;
                                        case "Total Ingresos":
                                            MontoConcepto = total_ingresos_total.ToString("0.00");
                                            break;
                                        case "Total Aportaciones":
                                            MontoConcepto = total_a_empleador_total.ToString("0.00");
                                            break;
                                        default:
                                            DataTable maestroIngreso = oClasificadoresxMetaxPLantilla.BuscarMaestroIngresoXCodigo(item.Concepto);
                                            string abreviacion = maestroIngreso.Rows[0]["abreviacion"].ToString();

                                            int indice_Ingresos_clasificador = BuscarIndiceColumna(odtPrueba, abreviacion);
                                            if (indice_Ingresos_clasificador != -1)
                                            {
                                                decimal montoClasificaor = Convert.ToDecimal(odtPrueba.Rows[odtPrueba.Rows.Count - 1][indice_Ingresos_clasificador]);
                                                MontoConcepto = montoClasificaor.ToString("0.00");
                                            }
                                            else
                                            {
                                                MontoConcepto = "0.00";
                                            }

                                            break;
                                    }
                                }
                                odtRedondear.Rows.Add(item.Especifica.Codigo, item.Especifica.Nombre, MontoConcepto);
                                dgvRedondear.DataSource = odtRedondear;
                            }



                            exportar_a_pdf_Racionamiento(sidtregimenlaboral);
                        }
                    }
                    #endregion

                    #region Planilla Cesantes
                    else
                    {
                        /*Evaluando a plantillas CASO CESANTES y OTROS*/
                        if (splantilla == "CESANTES")
                        {
                            //Limpiando titulos de la plantilla
                            odtPrueba.Columns.Clear();

                            //Establecer titulos de la planilla

                            odtPrueba.Columns.Add("NOMBRE COMPLETO", typeof(string));
                            odtPrueba.Columns.Add("CARGO", typeof(string));
                            odtPrueba.Columns.Add("DNI", typeof(string));
                            odtPrueba.Columns.Add("FECHA INICIO", typeof(string));
                            odtPrueba.Columns.Add("SEC. FUNC.", typeof(string));
                            odtPrueba.Columns.Add("AFP", typeof(string));
                            odtPrueba.Columns.Add("COMISION", typeof(string));
                            odtPrueba.Columns.Add("CUSP", typeof(string));

                            //realizar consulta para planilla por mes y regimen laboral


                            //odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboral(pMes, pRegimenLaboral);
                            //Determinar si la consulta esta vacio
                            odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboral(sidtplanilla, pRegimenLaboral, pmes_nro, paño);

                            odtPrueba.Clear();


                            if (odtPlanilla.Rows.Count > 0)
                            {
                                //recorrer consulta de planilla por id plantilla y regimen laboral
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

                                odtPruebaCorta.Columns.Clear();
                                odtPruebaCorta.Rows.Clear();

                                odtPruebaCorta.Columns.Add("Nº", typeof(string));
                                odtPruebaCorta.Columns.Add("NOMBRE COMPLETO", typeof(string));
                                odtPruebaCorta.Columns.Add("CARGO", typeof(string));
                                odtPruebaCorta.Columns.Add("DNI", typeof(string));

                                odtPruebaCorta.Columns.Add("FECHA INICIO", typeof(string));

                                odtPruebaCorta.Columns.Add("SEC. FUNC.", typeof(string));
                                odtPruebaCorta.Columns.Add("COMISION \n\n CUSP ", typeof(string));

                                decimal DivisionTrabajador = Math.Ceiling(total_tipo_a_trabajador / 2);
                                decimal DivisionEmpleador = Math.Ceiling(total_tipo_a_empleador / 2);
                                decimal DivisionIngresos = Math.Ceiling(total_tipo_ingreso / 2);
                                decimal DivisionDescuentos = Math.Ceiling(total_tipo_descuento / 2);




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
                                odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboral(sidtplanilla, pRegimenLaboral, pmes_nro, paño);

                                int ll = 0;
                                //esribir datos de planilla
                                int total_prueba_corta = odtPrueba.Rows.Count;

                                for (int d = 0; d < total_prueba_corta; d++)
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


                                        if (d != odtPrueba.Rows.Count - 1)
                                        {
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
                                    if (d != total_prueba_corta - 1)
                                        drFilaCorta[0] = (d + 1);

                                    drFilaCorta[1] = odtPrueba.Rows[d][0];
                                    drFilaCorta[2] = odtPrueba.Rows[d][1];
                                    drFilaCorta[3] = odtPrueba.Rows[d][2];

                                    if (odtPrueba.Rows[d][3].ToString() != "")
                                        drFilaCorta[4] = Convert.ToDateTime(odtPrueba.Rows[d][3]).Date.ToString("MM/dd/yyyy");

                                    //drFilaCorta[5] = odtPrueba.Rows[d][4];

                                    drFilaCorta[5] = odtPrueba.Rows[d][4];
                                    drFilaCorta[6] = odtPrueba.Rows[d][6] + " \n\n " + odtPrueba.Rows[d][7];


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

                                    iindice_ingresos = BuscarIndiceColumna(odtPlanilla, "totalingresos");
                                    iindice_descuentos = BuscarIndiceColumna(odtPlanilla, "totaldescuentos");
                                    iindice_a_empleador = BuscarIndiceColumna(odtPlanilla, "totalaempleador");
                                    iindice_a_trabajador = BuscarIndiceColumna(odtPlanilla, "totalatrabajador");

                                    CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador oMaestroATrabajador = new CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador();

                                    /*Aportaciones trabajador ESSALUD +VIDA y ESSALUD - SEGURO REGULAR - PENSIONISTA*/
                                    columna_essalud_vida = oMaestroATrabajador.ListarAbreviacionDeIdtmaestroatrabajador(6).Rows[0][1].ToString();
                                    iindice_essalud_vida = BuscarIndiceColumna(odtPrueba, columna_essalud_vida);

                                    columna_essalud_regular = oMaestroATrabajador.ListarAbreviacionDeIdtmaestroatrabajador(12).Rows[0][1].ToString();
                                    iindice_essalud_seguro_regular = BuscarIndiceColumna(odtPrueba, columna_essalud_regular);

                                    /*Aportaciones empleador ESSALUD (SEGURO REGULAR, CBBSP, AGRARIO/ACUICULTOR) - TRABAJADOR 
                                     * y ESSALUD – SEGURO COMPLEMENTARIO DE TRABAJO DE RIESGO Y APORTE ENTIDAD*/

                                    CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador oMaestroAEmpleador = new CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador();

                                    columna_essalud_trabajador = oMaestroAEmpleador.ListarAbreviacionDeIdtmaestroaempleador(5).Rows[0][1].ToString();
                                    iindice_essalud_cbbsp = BuscarIndiceColumna(odtPrueba, columna_essalud_trabajador);

                                    columna_essalud_complementario = oMaestroAEmpleador.ListarAbreviacionDeIdtmaestroaempleador(7).Rows[0][1].ToString();
                                    iindice_essalud_seguro_complementario = BuscarIndiceColumna(odtPrueba, columna_essalud_complementario);

                                    columna_aporte_entidad = oMaestroAEmpleador.ListarAbreviacionDeIdtmaestroaempleador(14).Rows[0][1].ToString();
                                    iindice_aporte_entidad = BuscarIndiceColumna(odtPrueba, columna_aporte_entidad);

                                    /* Descuentos: Renta de 5ta categoria*/
                                    CapaDeNegocios.Sunat.cMaestroDescuentos oMaestroDctos = new CapaDeNegocios.Sunat.cMaestroDescuentos();

                                    columna_renta_5ta = oMaestroDctos.ListarAbreviacionDeIdtmaestrodescuentos(18).Rows[0][1].ToString();
                                    iindice_renta_quinta = BuscarIndiceColumna(odtPrueba, columna_renta_5ta);

                                    if (ll == odtPrueba.Rows.Count - 1)
                                    {
                                        for (int l = 0; l < odtPrueba.Rows.Count - 1; l++)
                                        {
                                            if (iindice_aporte_entidad != -1)
                                            {
                                                monto_aporte_entidad = Convert.ToDecimal(odtPrueba.Rows[l][iindice_aporte_entidad]);
                                                sumatoria_aporte_entidad += monto_aporte_entidad;
                                            }

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



                                            //sumatoria ESSALUD
                                            if (iindice_essalud_vida != -1)
                                                monto_essalud_vida += Convert.ToDecimal(odtPrueba.Rows[l][iindice_essalud_vida]);

                                            if (iindice_essalud_seguro_regular != -1)
                                                monto_essalud_seguro_regular += Convert.ToDecimal(odtPrueba.Rows[l][iindice_essalud_seguro_regular]);

                                            if (iindice_essalud_cbbsp != -1)
                                                monto_essalud_cbbsp += Convert.ToDecimal(odtPrueba.Rows[l][iindice_essalud_cbbsp]);

                                            if (iindice_essalud_seguro_complementario != -1)
                                                monto_essalud_seguro_complementario += Convert.ToDecimal(odtPrueba.Rows[l][iindice_essalud_seguro_complementario]);

                                            //Sumatoria Renta de 5ta 
                                            if (iindice_renta_quinta != -1)
                                                monto_renta_quinta += Convert.ToDecimal(odtPrueba.Rows[l][iindice_renta_quinta]);
                                        }

                                        indice_prueba_corta_neto_cobrar = BuscarIndiceColumna(odtPruebaCorta, "NETO A COBRAR");
                                        drFilaCorta[indice_prueba_corta_neto_cobrar] = sumatoria.ToString();

                                        //Si no existe total ingresos .no agrega a drFilaCorta
                                        iindice_ingresos = BuscarIndiceColumna(odtPruebaCorta, "TOTAL INGRESOS");
                                        if (iindice_ingresos != -1)
                                            drFilaCorta[iindice_ingresos] = sumatoria_ingresos.ToString();

                                        iindice_descuentos = BuscarIndiceColumna(odtPruebaCorta, "TOTAL DESCUENTOS");
                                        if (iindice_descuentos != -1)
                                            drFilaCorta[iindice_descuentos] = sumatoria_descuentos.ToString();

                                        iindice_a_trabajador = BuscarIndiceColumna(odtPruebaCorta, "TOTAL APORTACIONES TRABAJADOR");
                                        if (iindice_a_trabajador != -1)
                                            drFilaCorta[iindice_a_trabajador] = sumatoria_a_trabajador.ToString();

                                        iindice_a_empleador = BuscarIndiceColumna(odtPruebaCorta, "TOTAL APORTACIONES EMPLEADOR");
                                        if (iindice_a_empleador != -1)
                                            drFilaCorta[iindice_a_empleador] = sumatoria_a_empleador.ToString();

                                        /* 14 = Aporte entidad */

                                        iindice_aporte_entidad = BuscarIndiceColumna(odtPruebaCorta, columna_aporte_entidad);
                                        if (iindice_aporte_entidad != -1)
                                        {
                                            //monto_aporte_entidad = Convert.ToDecimal(odtPruebaCorta.Rows[d][iindice_aporte_entidad]);
                                            drFilaCorta[iindice_aporte_entidad] = sumatoria_aporte_entidad;
                                        }

                                    }
                                    //Planilla 728 ------ DEC. AFP = total aportaciones trabajador + aportaciones entidad

                                    /* DEC. AFP --- llenando datos  */

                                    //Insertando una fila al datatable odtPruebaCorta
                                    odtPruebaCorta.Rows.InsertAt(drFilaCorta, d);
                                    ll++;
                                }

                                if (oDatosGenerales.Ruc == "20159308708")
                                {

                                }
                                else
                                {
                                    odtPruebaCorta.Columns.Add("OBSERVACIONES", typeof(string));
                                }


                                this.dgvPrueba.DataSource = odtPruebaCorta;

                                odtATrabajador.Columns.Clear();
                                odtATrabajador.Rows.Clear();

                                //Agregando columnas al cuadro de AFP
                                odtATrabajador.Columns.Add("DESCUENTOS", typeof(string));
                                odtATrabajador.Columns.Add(" ", typeof(string));
                                //Calculando cuadro de AFP

                                /* Fin SNP y AFP */

                                /*Hallando AFP*/
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





                                drFilaATrabajador = odtATrabajador.NewRow();
                                drFilaATrabajador.Delete();

                                drFilaATrabajador[0] = "TOTAL";
                                drFilaATrabajador[1] = "";
                                odtATrabajador.Rows.InsertAt(drFilaATrabajador, nn);

                                dgvAFP.DataSource = odtATrabajador;

                                /* Cuadro de redondear a entero */
                                odtRedondear.Columns.Clear();
                                odtRedondear.Rows.Clear();

                                //Agregando columnas al cuadro redondear a entero

                                if (iindice_essalud_vida != -1) odtRedondear.Columns.Add(columna_essalud_vida, typeof(string));
                                if (iindice_essalud_seguro_regular != -1) odtRedondear.Columns.Add(columna_essalud_regular, typeof(string));
                                if (iindice_essalud_cbbsp != -1) odtRedondear.Columns.Add(columna_essalud_trabajador, typeof(string));
                                if (iindice_essalud_seguro_complementario != -1) odtRedondear.Columns.Add(columna_essalud_complementario, typeof(string));

                                if (iindice_renta_quinta != -1) odtRedondear.Columns.Add(columna_renta_5ta, typeof(string));
                                odtRedondear.Columns.Add("TOTAL", typeof(string));

                                //Actualizando indices para agregar valores a odtRedondear
                                iindice_essalud_vida = BuscarIndiceColumna(odtRedondear, columna_essalud_vida);
                                iindice_essalud_seguro_regular = BuscarIndiceColumna(odtRedondear, columna_essalud_regular);
                                iindice_essalud_cbbsp = BuscarIndiceColumna(odtRedondear, columna_essalud_trabajador);
                                iindice_essalud_seguro_complementario = BuscarIndiceColumna(odtRedondear, columna_essalud_complementario);

                                iindice_renta_quinta = BuscarIndiceColumna(odtRedondear, columna_renta_5ta);

                                drFilaRedondear = odtRedondear.NewRow();
                                drFilaRedondear.Delete();

                                decimal monto_redondear_total = 0;
                                int iindice_monto_redondear_total = 0;

                                iindice_monto_redondear_total = BuscarIndiceColumna(odtRedondear, "TOTAL");

                                if (iindice_essalud_vida != -1)
                                {
                                    drFilaRedondear[iindice_essalud_vida] = Math.Round(monto_essalud_vida, 0);
                                    monto_redondear_total += monto_essalud_vida;
                                }
                                if (iindice_essalud_seguro_regular != -1)
                                {
                                    drFilaRedondear[iindice_essalud_seguro_regular] = Math.Round(monto_essalud_seguro_regular, 0);
                                    monto_redondear_total += monto_essalud_seguro_regular;
                                }
                                if (iindice_essalud_cbbsp != -1)
                                {
                                    drFilaRedondear[iindice_essalud_cbbsp] = Math.Round(monto_essalud_cbbsp, 0);
                                    monto_redondear_total += monto_essalud_cbbsp;
                                }
                                if (iindice_essalud_seguro_complementario != -1)
                                {
                                    drFilaRedondear[iindice_essalud_seguro_complementario] = Math.Round(monto_essalud_seguro_complementario, 0);
                                    monto_redondear_total += monto_essalud_seguro_complementario;
                                }

                                if (iindice_renta_quinta != -1)
                                {
                                    drFilaRedondear[iindice_renta_quinta] = Math.Round(monto_renta_quinta, 0);
                                    monto_redondear_total += monto_renta_quinta;
                                }

                                drFilaRedondear[iindice_monto_redondear_total] = Math.Round(monto_redondear_total, 0);

                                odtRedondear.Rows.InsertAt(drFilaRedondear, 0);
                                dgvRedondear.DataSource = odtRedondear;
                                /* fin cuadro de redondear a entero */

                                /*3er cuadro de la ultima parte de la planilla*/
                                odtEEFF.Columns.Clear();
                                odtEEFF.Rows.Clear();
                                /*Insertando columnas DEBE Y HABER*/
                                odtEEFF.Columns.Add(" ", typeof(string));
                                odtEEFF.Columns.Add("DEBE", typeof(string));
                                odtEEFF.Columns.Add("HABER", typeof(string));

                                /*Agregando Remuneración total*/

                                /*DEBE */

                                iindice_total_ingresos = BuscarIndiceColumna(odtPruebaCorta, "TOTAL INGRESOS");
                                iindice_total_a_empleador = BuscarIndiceColumna(odtPruebaCorta, "TOTAL APORTACIONES EMPLEADOR");

                                if (iindice_total_ingresos != -1)
                                {
                                    ultima_fila_prueba_corta = odtPruebaCorta.Rows.Count - 1;
                                    total_ingresos_total = Convert.ToDecimal(odtPruebaCorta.Rows[ultima_fila_prueba_corta][iindice_total_ingresos]);
                                    drFilaEEFF = odtEEFF.NewRow();
                                    drFilaEEFF.Delete();
                                    drFilaEEFF[0] = "TOTAL INGRESOS";
                                    drFilaEEFF[1] = total_ingresos_total;
                                    total_debe += total_ingresos_total;
                                    odtEEFF.Rows.InsertAt(drFilaEEFF, lll);
                                    lll++;
                                }
                                if (iindice_total_a_empleador != -1)
                                {
                                    ultima_fila_prueba_corta = odtPruebaCorta.Rows.Count - 1;
                                    total_a_empleador_total = Convert.ToDecimal(odtPruebaCorta.Rows[ultima_fila_prueba_corta][iindice_total_a_empleador]);
                                    drFilaEEFF = odtEEFF.NewRow();
                                    drFilaEEFF.Delete();
                                    drFilaEEFF[0] = "TOTAL APORTACIONES EMPLEADOR";
                                    drFilaEEFF[1] = total_a_empleador_total;
                                    total_debe += total_a_empleador_total;
                                    odtEEFF.Rows.InsertAt(drFilaEEFF, lll);
                                    lll++;
                                }

                                /*FIN DEBE */

                                /* HABER */

                                iindice_snp_13 = BuscarIndiceColumna(odtPrueba, columna_snp);
                                iindice_afp = BuscarIndiceColumna(odtPruebaCorta, "DEC. AFP");
                                iindice_aportacion_entidad = BuscarIndiceColumna(odtPrueba, columna_aporte_entidad);
                                iindice_neto_cobrar = BuscarIndiceColumna(odtPruebaCorta, "NETO A COBRAR");

                                iindice_essalud_cbbsp = BuscarIndiceColumna(odtPrueba, columna_essalud_trabajador);
                                iindice_essalud_seguro_complementario = BuscarIndiceColumna(odtPrueba, columna_essalud_complementario);

                                if (odtPruebaCorta.Rows.Count > 0) ultima_fila_prueba_corta = odtPruebaCorta.Rows.Count - 1;
                                if (odtPrueba.Rows.Count > 0) ultima_fila_prueba = odtPrueba.Rows.Count - 1;



                                if (iindice_snp_13 != -1)
                                {
                                    snp_total = Convert.ToDecimal(odtPrueba.Rows[ultima_fila_prueba][iindice_snp_13]);
                                    drFilaEEFF = odtEEFF.NewRow();
                                    drFilaEEFF.Delete();
                                    drFilaEEFF[0] = columna_snp;
                                    drFilaEEFF[2] = snp_total;
                                    haber_total += snp_total;
                                    odtEEFF.Rows.InsertAt(drFilaEEFF, lll);
                                    lll++;
                                }

                                if (iindice_aportacion_entidad != -1)
                                    aportacion_entidad_total = Convert.ToDecimal(odtPrueba.Rows[ultima_fila_prueba_corta][iindice_aportacion_entidad]);



                                if (iindice_afp != -1)
                                {
                                    afp_total = Convert.ToDecimal(odtPruebaCorta.Rows[ultima_fila_prueba_corta][iindice_afp]);
                                    //afp_total = afp_total + aportacion_entidad_total;
                                    drFilaEEFF = odtEEFF.NewRow();
                                    drFilaEEFF.Delete();
                                    drFilaEEFF[0] = "AFP";
                                    drFilaEEFF[2] = afp_total;

                                    haber_total += afp_total;

                                    odtEEFF.Rows.InsertAt(drFilaEEFF, lll);
                                    lll++;
                                }

                                //if (iindice_essalud_vida != -1)
                                //{
                                //    //essalud_vida_total = Convert.ToDecimal(odtPruebaCorta.Rows[ultima_fila_prueba_corta][iindice_essalud_vida]);
                                //    drFilaEEFF = odtEEFF.NewRow();
                                //    drFilaEEFF.Delete();
                                //    drFilaEEFF[0] = "ESSALUD VIDA";
                                //    drFilaEEFF[2] = monto_essalud_vida;
                                //    haber_total += monto_essalud_vida;
                                //    odtEEFF.Rows.InsertAt(drFilaEEFF, lll);
                                //    lll++;
                                //}


                                iindice_afp = BuscarIndiceColumna(odtPruebaCorta, "TOTAL APORTACIONES TRABAJADOR");
                                iindice_aportacion_entidad = BuscarIndiceColumna(odtPrueba, columna_aporte_entidad);
                                iindice_neto_cobrar = BuscarIndiceColumna(odtPruebaCorta, "NETO A COBRAR");

                                iindice_essalud_cbbsp = BuscarIndiceColumna(odtPrueba, columna_essalud_trabajador);
                                iindice_essalud_seguro_complementario = BuscarIndiceColumna(odtPrueba, columna_essalud_complementario);

                                if (odtPruebaCorta.Rows.Count > 0) ultima_fila_prueba_corta = odtPruebaCorta.Rows.Count - 1;
                                if (odtPrueba.Rows.Count > 0) ultima_fila_prueba = odtPrueba.Rows.Count - 1;

                                if (iindice_aportacion_entidad != -1)
                                    aportacion_entidad_total = Convert.ToDecimal(odtPrueba.Rows[ultima_fila_prueba_corta][iindice_aportacion_entidad]);

                                if (iindice_neto_cobrar != -1)
                                {
                                    neto_cobrar_total = Convert.ToDecimal(odtPruebaCorta.Rows[ultima_fila_prueba_corta][iindice_neto_cobrar]);
                                    drFilaEEFF = odtEEFF.NewRow();
                                    drFilaEEFF.Delete();
                                    drFilaEEFF[0] = "NETO A PAGAR";
                                    drFilaEEFF[2] = neto_cobrar_total;
                                    haber_total += neto_cobrar_total;
                                    odtEEFF.Rows.InsertAt(drFilaEEFF, lll);
                                    lll++;
                                }

                                /* CONCEPTOS DE MAESTRO DESCUENTOS, EMPLEADOR, TRABAJADOR */

                                CapaDeNegocios.Sunat.cMaestroDescuentos oMaestroDescuentos = new CapaDeNegocios.Sunat.cMaestroDescuentos();
                                DataTable odtMaestroDescuentos = new DataTable();
                                string titulo_maestro_descuento = "";

                                odtMaestroDescuentos = oMaestroDescuentos.ListarMaestroDescuentos();

                                for (int i = 0; i < odtMaestroDescuentos.Rows.Count; i++)
                                {

                                    titulo_maestro_descuento = odtMaestroDescuentos.Rows[i][4].ToString();
                                    iindice_ad = BuscarIndiceColumna(odtPrueba, titulo_maestro_descuento);

                                    if (iindice_ad != -1)
                                    {
                                        ad_total = Convert.ToDecimal(odtPrueba.Rows[ultima_fila_prueba][iindice_ad]);
                                        drFilaEEFF = odtEEFF.NewRow();
                                        drFilaEEFF.Delete();
                                        drFilaEEFF[0] = titulo_maestro_descuento;
                                        drFilaEEFF[2] = ad_total;
                                        haber_total += ad_total;
                                        odtEEFF.Rows.InsertAt(drFilaEEFF, lll);
                                        lll++;
                                    }
                                }

                                CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador oMaestroEmpleador = new CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador();
                                DataTable odtMaestroEmpleador = new DataTable();
                                string titulo_maestro_empleador = "";

                                odtMaestroEmpleador = oMaestroEmpleador.ListarMaestroAportacionesEmpleador();

                                for (int i = 0; i < odtMaestroEmpleador.Rows.Count; i++)
                                {
                                    titulo_maestro_empleador = odtMaestroEmpleador.Rows[i][4].ToString();
                                    iindice_ad = BuscarIndiceColumna(odtPrueba, titulo_maestro_empleador);

                                    if (iindice_ad != -1)
                                    {
                                        ad_total = Convert.ToDecimal(odtPrueba.Rows[ultima_fila_prueba][iindice_ad]);
                                        drFilaEEFF = odtEEFF.NewRow();
                                        drFilaEEFF.Delete();
                                        drFilaEEFF[0] = titulo_maestro_empleador;
                                        drFilaEEFF[2] = ad_total;
                                        haber_total += ad_total;
                                        odtEEFF.Rows.InsertAt(drFilaEEFF, lll);
                                        lll++;
                                    }
                                }

                                CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador oMaestroTrabajador = new CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador();
                                DataTable odtMaestroTrabajador = new DataTable();
                                string titulo_maestro_trabajador = "";

                                odtMaestroTrabajador = oMaestroTrabajador.ListarMaestroAportacionesTrabajador();

                                for (int i = 0; i < odtMaestroTrabajador.Rows.Count; i++)
                                {
                                    titulo_maestro_trabajador = odtMaestroTrabajador.Rows[i][4].ToString();
                                    iindice_ad = BuscarIndiceColumna(odtPrueba, titulo_maestro_trabajador);

                                    if (iindice_ad != -1)
                                    {
                                        ad_total = Convert.ToDecimal(odtPrueba.Rows[ultima_fila_prueba][iindice_ad]);
                                        drFilaEEFF = odtEEFF.NewRow();
                                        drFilaEEFF.Delete();
                                        drFilaEEFF[0] = titulo_maestro_trabajador;
                                        drFilaEEFF[2] = ad_total;
                                        haber_total += ad_total;
                                        odtEEFF.Rows.InsertAt(drFilaEEFF, lll);
                                        lll++;
                                    }
                                }


                                /* Insertando totales de debe y haber*/

                                drFilaEEFF = odtEEFF.NewRow();
                                drFilaEEFF.Delete();
                                drFilaEEFF[0] = "TOTAL";
                                drFilaEEFF[1] = total_debe;
                                drFilaEEFF[2] = haber_total;
                                odtEEFF.Rows.InsertAt(drFilaEEFF, lll);

                                dgvEEFF.DataSource = odtEEFF;
                                /* FIN HABER */

                                /*Fin del 3er cuadro de la ultima parte de la planilla*/

                                exportar_a_pdf(0);
                            }
                            else
                                MessageBox.Show("Plantilla sin datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        #endregion
                        //FINAL DE CESANTES
                       
                        else
                        {
                            #region CTSyGratificacion
                            if (splantilla == "CTS" || splantilla == "GRATIFICACION")
                            {
                                if (splantilla == "CTS")
                                {
                                    //Limpiando titulos de la plantilla
                                    odtPrueba.Columns.Clear();

                                    //Establecer titulos de la planilla
                                    odtPrueba.Columns.Add("Nro.", typeof(string));
                                    odtPrueba.Columns.Add("NOMBRE COMPLETO", typeof(string));
                                    odtPrueba.Columns.Add("CARGO", typeof(string));
                                    odtPrueba.Columns.Add("DNI", typeof(string));

                                    odtPrueba.Columns.Add("PERIODO", typeof(string));
                                    odtPrueba.Columns.Add("TOTAL DIAS LABORADOS", typeof(string));
                                    odtPrueba.Columns.Add("TOTAL CTS", typeof(string));
                                    if (chkCuentaBancaria.Checked)
                                    {
                                        odtPrueba.Columns.Add("CUENTA BANCARIA", typeof(string));
                                        odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboralRacionamientoBancaria(sidtplanilla, pRegimenLaboral, pmes_nro, paño);
                                    }
                                    else
                                    {
                                        odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboralRacionamiento(sidtplanilla, pRegimenLaboral, pmes_nro, paño);
                                    }
                                    odtPlanilla = buscarDuplicados(odtPlanilla);
                                    odtPrueba.Clear();

                                    indice_prueba_dias_laborados = BuscarIndiceColumna(odtPrueba, "PERIODO");
                                    indice_neto_cobrar = BuscarIndiceColumna(odtPrueba, "TOTAL CTS");

                                    DataTable auxiliarNumeroTrabPlanilla = oPlanilla.ListarDetallePlanilla(sidtplanilla);

                                    if (odtPlanilla.Rows.Count != auxiliarNumeroTrabPlanilla.Rows.Count)
                                    {
                                        MessageBox.Show("El numero de trabajadores " + odtPlanilla.Rows.Count.ToString() + " , es diferente al numero de trabajadores activos en el mes " + auxiliarNumeroTrabPlanilla.Rows.Count.ToString(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    if (odtPlanilla.Rows.Count > 0)
                                    {
                                        //Consultar meta de planilla
                                        decimal sumatoria = 0;
                                        int indice = 0;
                                        //recorrer consulta de planilla por id plantilla y regimen laboral
                                        foreach (DataRow row in odtPlanilla.Rows)
                                        {
                                            indice++;

                                            drFila = odtPrueba.NewRow();
                                            drFila.Delete();
                                            //Determinar en base al id del trabajador sus ingresos
                                            pidTrabajador = Convert.ToInt32(row[5]);

                                            drFila[0] = indice.ToString();
                                            drFila[1] = row[0];
                                            drFila[2] = row[1];
                                            drFila[3] = row[2];
                                            if (Convert.ToDateTime(row[3].ToString()) < new DateTime(2022, 11, 1))
                                            {
                                                drFila[4] = "DEL 01/05/2023 AL 30/10/2023";
                                                drFila[5] = "6 MESES";
                                            }
                                            else
                                            {
                                                drFila[4] = "DEL 01/05/2023 AL 30/10/2023";
                                                drFila[5] = "6 MESES";
                                            }


                                            drFila[6] = row[11];
                                            if (chkCuentaBancaria.Checked)
                                            {
                                                drFila[7] = row[13];
                                            }
                                            sumatoria = sumatoria + Convert.ToDecimal(row[11]);

                                            //odtPrueba.Rows.Add(drFila);
                                            odtPrueba.Rows.InsertAt(drFila, k);

                                            k++;
                                        }
                                        if (oDatosGenerales.Ruc == "20159308708")
                                        {
                                            //odtPrueba.Columns.Add("OBSERVACIONES", typeof(string));
                                        }
                                        else
                                        {
                                            odtPrueba.Columns.Add("OBSERVACIONES", typeof(string));
                                            switch (oDatosGenerales.Ruc)
                                            {
                                                case "20147495600":
                                                        odtPrueba.Rows[0][8] = " SUELDO ALCALDE = ((4752.21 + 4752.21/6)*6/12)";
                                                    break;
                                                case "20159377696":
                                                    odtPrueba.Rows[0][7] = " SUELDO ALCALDE = ((4752.21 + 4752.21/6)*6/12)";
                                                    break;
                                                case "20159377424":
                                                    odtPrueba.Rows[0][7] = " SUELDO ALCALDE = ((4152.21 + 4152.21/6)*6/12)";
                                                    break;
                                                case "20177432360":
                                                    odtPrueba.Rows[0][7] = " SUELDO ALCALDE = ((5300 + 5300/6)*6/12)";
                                                    break;
                                                case "20200737211":
                                                    odtPrueba.Rows[0][7] = " SUELDO ALCALDE = ((5352.21+ 5352.21/6)*6/12)";
                                                    break;
                                                default:
                                                    break;
                                            }

                                        }

                                        this.dgvPrueba.DataSource = odtPrueba;

                                        drFila = odtPrueba.NewRow();
                                        //Insertando totales de las obligaciones
                                        drFila[0] = "TOTAL";
                                        drFila[6] = sumatoria;

                                        odtPrueba.Rows.InsertAt(drFila, k);


                                        exportar_a_pdf_CTS(sidtregimenlaboral);
                                    }
                                }
                                else
                                {
                                    //Limpiando titulos de la plantilla
                                    odtPrueba.Columns.Clear();

                                    //Establecer titulos de la planilla
                                    odtPrueba.Columns.Add("Nro.", typeof(string));
                                    odtPrueba.Columns.Add("NOMBRE COMPLETO", typeof(string));
                                    odtPrueba.Columns.Add("CARGO", typeof(string));
                                    odtPrueba.Columns.Add("DNI", typeof(string));

                                    odtPrueba.Columns.Add("PERIODO", typeof(string));
                                    odtPrueba.Columns.Add("TOTAL DIAS LABORADOS", typeof(string));
                                    odtPrueba.Columns.Add("TOTAL GRATIFICACION", typeof(string));
                                    if (chkCuentaBancaria.Checked)
                                    {
                                        odtPrueba.Columns.Add("CUENTA BANCARIA", typeof(string));
                                        odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboralRacionamientoBancaria(sidtplanilla, pRegimenLaboral, pmes_nro, paño);
                                    }
                                    else
                                    {
                                        odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboralRacionamiento(sidtplanilla, pRegimenLaboral, pmes_nro, paño);
                                    }
                                    odtPlanilla = buscarDuplicados(odtPlanilla);
                                    odtPrueba.Clear();

                                    indice_prueba_dias_laborados = BuscarIndiceColumna(odtPrueba, "PERIODO");
                                    indice_neto_cobrar = BuscarIndiceColumna(odtPrueba, "TOTAL GRATIFICACION");

                                    DataTable auxiliarNumeroTrabPlanilla = oPlanilla.ListarDetallePlanilla(sidtplanilla);

                                    if (odtPlanilla.Rows.Count != auxiliarNumeroTrabPlanilla.Rows.Count)
                                    {
                                        MessageBox.Show("El numero de trabajadores " + odtPlanilla.Rows.Count.ToString() + " , es diferente al numero de trabajadores activos en el mes " + auxiliarNumeroTrabPlanilla.Rows.Count.ToString(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    if (odtPlanilla.Rows.Count > 0)
                                    {
                                        //Consultar meta de planilla
                                        decimal sumatoria = 0;
                                        int indice = 0;
                                        //recorrer consulta de planilla por id plantilla y regimen laboral
                                        foreach (DataRow row in odtPlanilla.Rows)
                                        {
                                            indice++;

                                            drFila = odtPrueba.NewRow();
                                            drFila.Delete();
                                            //Determinar en base al id del trabajador sus ingresos
                                            pidTrabajador = Convert.ToInt32(row[5]);

                                            drFila[0] = indice.ToString();
                                            drFila[1] = row[0];
                                            drFila[2] = row[1];
                                            drFila[3] = row[2];
                                            if (Convert.ToDateTime(row[3].ToString()) < new DateTime(2022, 11, 1))
                                            {
                                                drFila[4] = "DEL 01/01/2023 AL 30/06/2023";
                                                drFila[5] = "6 MESES";
                                            }
                                            else
                                            {
                                                drFila[4] = "DEL 01/01/2023 AL 30/06/2023";
                                                drFila[5] = "6 MESES";
                                            }


                                            drFila[6] = row[11];
                                            if (chkCuentaBancaria.Checked)
                                            {
                                                drFila[7] = row[13];
                                            }
                                            sumatoria = sumatoria + Convert.ToDecimal(row[11]);

                                            //odtPrueba.Rows.Add(drFila);
                                            odtPrueba.Rows.InsertAt(drFila, k);

                                            k++;
                                        }
                                        if (oDatosGenerales.Ruc == "20159308708")
                                        {
                                            //odtPrueba.Columns.Add("OBSERVACIONES", typeof(string));
                                        }
                                        else
                                        {
                                            odtPrueba.Columns.Add("OBSERVACIONES", typeof(string));
                                            if (oDatosGenerales.Ruc == "20147495600")
                                            {
                                                odtPrueba.Rows[0][8] = " SUELDO ALCALDE = (4752.21*6/6)";
                                            }
                                            else
                                            {
                                                odtPrueba.Rows[0][7] = " SUELDO ALCALDE = (4752.21*6/6)";
                                            }

                                        }

                                        this.dgvPrueba.DataSource = odtPrueba;

                                        drFila = odtPrueba.NewRow();
                                        //Insertando totales de las obligaciones
                                        drFila[0] = "TOTAL";
                                        drFila[6] = sumatoria;

                                        odtPrueba.Rows.InsertAt(drFila, k);


                                        exportar_a_pdf_CTS(sidtregimenlaboral);
                                    }
                                }
                                    

                            }
#endregion
                            else
                            {
                                if (splantilla == "")
                                {

                                }
                                else
                                {
                                    #region Planilla Normal
                                    //Limpiando titulos de la plantilla
                                    odtPrueba.Columns.Clear();

                                    //Establecer titulos de la planilla

                                    odtPrueba.Columns.Add("NOMBRE COMPLETO", typeof(string));
                                    odtPrueba.Columns.Add("CARGO", typeof(string));
                                    odtPrueba.Columns.Add("DNI", typeof(string));
                                    odtPrueba.Columns.Add("FECHA INICIO", typeof(string));
                                    odtPrueba.Columns.Add("SEC. FUNC.", typeof(string));
                                    odtPrueba.Columns.Add("AFIL. AFP/SNP", typeof(string));
                                    odtPrueba.Columns.Add("COMISION", typeof(string));
                                    odtPrueba.Columns.Add("CUSSP", typeof(string));

                                    //realizar consulta para planilla por mes y regimen laboral


                                    //odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboral(pMes, pRegimenLaboral);
                                    //Determinar si la consulta esta vacio
                                    if (chkCuentaBancaria.Checked)
                                    {
                                        odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboralBancaria(sidtplanilla, pRegimenLaboral, pmes_nro, paño);
                                    }
                                    else
                                    {
                                        odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboral(sidtplanilla, pRegimenLaboral, pmes_nro, paño);
                                    }

                                    odtPlanilla = buscarDuplicados(odtPlanilla);

                                    odtPrueba.Clear();

                                    DataTable auxiliarNumeroTrabPlanilla = oPlanilla.ListarDetallePlanilla(sidtplanilla);

                                    if (odtPlanilla.Rows.Count != auxiliarNumeroTrabPlanilla.Rows.Count)
                                    {
                                        MessageBox.Show("El numero de trabajadores " + odtPlanilla.Rows.Count.ToString() + " , es diferente al numero de trabajadores activos en el mes " + auxiliarNumeroTrabPlanilla.Rows.Count.ToString(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }



                                    if (odtPlanilla.Rows.Count > 0)
                                    {
                                        //Consultar meta de planilla


                                        //recorrer consulta de planilla por id plantilla y regimen laboral
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
                                            //secuencia funcional
                                            drFila[4] = smeta_numero;
                                            //drFila[4] = row[6];
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

                                            if (chkCuentaBancaria.Checked)
                                            {
                                                if (!ExisteColumnaTexto(odtPrueba, "CUENTA BANCARIA"))
                                                {
                                                    odtPrueba.Columns.Add("CUENTA BANCARIA", typeof(string));
                                                    indice_cuenta_bancaria = BuscarIndiceColumna(odtPrueba, "CUENTA BANCARIA");
                                                }

                                                drFila[indice_cuenta_bancaria] = row[16];
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

                                                if (i == indice_cuenta_bancaria)
                                                {
                                                    if (odtPrueba.Rows[l][i].ToString().Trim() == "0.00")
                                                        odtPrueba.Rows[l][i] = "-";
                                                }
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

                                        odtPruebaCorta.Columns.Clear();
                                        odtPruebaCorta.Rows.Clear();

                                        odtPruebaCorta.Columns.Add("Nº", typeof(string));
                                        odtPruebaCorta.Columns.Add("NOMBRE COMPLETO", typeof(string));
                                        odtPruebaCorta.Columns.Add("CARGO", typeof(string));
                                        odtPruebaCorta.Columns.Add("DNI", typeof(string));

                                        odtPruebaCorta.Columns.Add("FECHA INICIO", typeof(string));

                                        odtPruebaCorta.Columns.Add("SEC. FUNC.", typeof(string));
                                        odtPruebaCorta.Columns.Add("AFIL. AFP/SNP \n\n COMIS. \n\n CUSP ", typeof(string));

                                        decimal DivisionTrabajador = Math.Ceiling(total_tipo_a_trabajador / 2);
                                        decimal DivisionEmpleador = Math.Ceiling(total_tipo_a_empleador / 2);
                                        decimal DivisionIngresos = Math.Ceiling(total_tipo_ingreso / 2);
                                        decimal DivisionDescuentos = Math.Ceiling(total_tipo_descuento / 2);




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
                                        odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboral(sidtplanilla, pRegimenLaboral, pmes_nro, paño);
                                        odtPlanilla = buscarDuplicados(odtPlanilla);
                                        int ll = 0;
                                        //esribir datos de planilla
                                        int total_prueba_corta = odtPrueba.Rows.Count;

                                        for (int d = 0; d < total_prueba_corta; d++)
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


                                                if (d != odtPrueba.Rows.Count - 1)
                                                {
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
                                            if (d != total_prueba_corta - 1)
                                                drFilaCorta[0] = (d + 1);

                                            drFilaCorta[1] = odtPrueba.Rows[d][0];
                                            drFilaCorta[2] = odtPrueba.Rows[d][1];
                                            drFilaCorta[3] = odtPrueba.Rows[d][2];

                                            if (odtPrueba.Rows[d][3].ToString() != "")
                                                drFilaCorta[4] = Convert.ToDateTime(odtPrueba.Rows[d][3]).Date.ToString("dd/MM/yyyy");

                                            //drFilaCorta[5] = odtPrueba.Rows[d][4];

                                            drFilaCorta[5] = odtPrueba.Rows[d][4];
                                            drFilaCorta[6] = odtPrueba.Rows[d][5] + " \n\n " + odtPrueba.Rows[d][6] + " \n\n " + odtPrueba.Rows[d][7];


                                            //drFilaCorta[10] = odtPrueba.Rows[d][9];

                                            if (!ExisteColumnaTexto(odtPruebaCorta, "DEC. AFP"))
                                            {
                                                odtPruebaCorta.Columns.Add("DEC. AFP", typeof(string));
                                                iindice_dec_afp = BuscarIndiceColumna(odtPrueba, "DEC. AFP");
                                            }


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

                                            if (chkCuentaBancaria.Checked)
                                            {
                                                if (!ExisteColumnaTexto(odtPruebaCorta, "CUENTA BANCARIA"))
                                                {
                                                    odtPruebaCorta.Columns.Add("CUENTA BANCARIA", typeof(string));
                                                    indice_prueba_corta_cuenta_bancaria = BuscarIndiceColumna(odtPruebaCorta, "CUENTA BANCARIA");
                                                    indice_cuenta_bancaria = BuscarIndiceColumna(odtPrueba, "CUENTA BANCARIA");
                                                }
                                                drFilaCorta[indice_prueba_corta_cuenta_bancaria] = odtPrueba.Rows[d][indice_cuenta_bancaria];
                                            }

                                            string neto_cobrar = odtPrueba.Rows[d][indice_prueba_neto_cobrar].ToString();

                                            drFilaCorta[indice_prueba_corta_dias_laborados] = odtPrueba.Rows[d][indice_prueba_dias_laborados];
                                            drFilaCorta[indice_prueba_corta_neto_cobrar] = neto_cobrar.ToString();

                                            //Sumando total de neto a cobrar y sumatoria total de total ingresos, total descuentos, total empleador, total trabajador
                                            sumatoria = 0;
                                            indice_prueba_corta_neto_cobrar = BuscarIndiceColumna(odtPrueba, "NETO A COBRAR");

                                            iindice_ingresos = BuscarIndiceColumna(odtPlanilla, "totalingresos");
                                            iindice_descuentos = BuscarIndiceColumna(odtPlanilla, "totaldescuentos");
                                            iindice_a_empleador = BuscarIndiceColumna(odtPlanilla, "totalaempleador");
                                            iindice_a_trabajador = BuscarIndiceColumna(odtPlanilla, "totalatrabajador");

                                            CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador oMaestroATrabajador = new CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador();

                                            /*Aportaciones trabajador ESSALUD +VIDA y ESSALUD - SEGURO REGULAR - PENSIONISTA*/
                                            columna_essalud_vida = oMaestroATrabajador.ListarAbreviacionDeIdtmaestroatrabajador(6).Rows[0][1].ToString();
                                            iindice_essalud_vida = BuscarIndiceColumna(odtPrueba, columna_essalud_vida);

                                            columna_essalud_regular = oMaestroATrabajador.ListarAbreviacionDeIdtmaestroatrabajador(12).Rows[0][1].ToString();
                                            iindice_essalud_seguro_regular = BuscarIndiceColumna(odtPrueba, columna_essalud_regular);

                                            iindice_4ta = BuscarIndiceColumna(odtPrueba, "RENTA 4TA CAT");
                                            iindice_renta_5ta_cat = BuscarIndiceColumna(odtPrueba, "RENTA 5TA CAT");
                                            /*Aportaciones empleador ESSALUD (SEGURO REGULAR, CBBSP, AGRARIO/ACUICULTOR) - TRABAJADOR 
                                             * y ESSALUD – SEGURO COMPLEMENTARIO DE TRABAJO DE RIESGO Y APORTE ENTIDAD*/

                                            CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador oMaestroAEmpleador = new CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador();

                                            columna_essalud_trabajador = oMaestroAEmpleador.ListarAbreviacionDeIdtmaestroaempleador(5).Rows[0][1].ToString();
                                            iindice_essalud_cbbsp = BuscarIndiceColumna(odtPrueba, columna_essalud_trabajador);

                                            columna_essalud_complementario = oMaestroAEmpleador.ListarAbreviacionDeIdtmaestroaempleador(7).Rows[0][1].ToString();
                                            iindice_essalud_seguro_complementario = BuscarIndiceColumna(odtPrueba, columna_essalud_complementario);

                                            columna_essalud_complementario_privado = oMaestroAEmpleador.ListarAbreviacionDeIdtmaestroaempleador(15).Rows[0][1].ToString();
                                            iindice_seguro_essalud_privado = BuscarIndiceColumna(odtPrueba, columna_essalud_complementario_privado);

                                            columna_essalud_trabajador_pension = oMaestroAEmpleador.ListarAbreviacionDeIdtmaestroaempleador(16).Rows[0][1].ToString();
                                            iindice_seguro_pension = BuscarIndiceColumna(odtPrueba, columna_essalud_trabajador_pension);

                                            columna_aporte_entidad = oMaestroAEmpleador.ListarAbreviacionDeIdtmaestroaempleador(14).Rows[0][1].ToString();
                                            iindice_aporte_entidad = BuscarIndiceColumna(odtPrueba, columna_aporte_entidad);

                                            /* Descuentos: Renta de 5ta categoria*/
                                            CapaDeNegocios.Sunat.cMaestroDescuentos oMaestroDctos = new CapaDeNegocios.Sunat.cMaestroDescuentos();

                                            columna_renta_5ta = oMaestroDctos.ListarAbreviacionDeIdtmaestrodescuentos(18).Rows[0][1].ToString();
                                            iindice_renta_quinta = BuscarIndiceColumna(odtPrueba, columna_renta_5ta);

                                            columna_snp = oMaestroATrabajador.ListarAbreviacionDeIdtmaestroatrabajador(9).Rows[0][1].ToString();
                                            iindice_snp_dl = BuscarIndiceColumna(odtPrueba, columna_snp);

                                            iindice_dec_afp = BuscarIndiceColumna(odtPruebaCorta, "DEC. AFP");

                                            if (ll == odtPrueba.Rows.Count - 1)
                                            {
                                                for (int l = 0; l < odtPrueba.Rows.Count - 1; l++)
                                                {
                                                    if (iindice_aporte_entidad != -1)
                                                    {
                                                        monto_aporte_entidad = Convert.ToDecimal(odtPrueba.Rows[l][iindice_aporte_entidad]);
                                                        sumatoria_aporte_entidad += monto_aporte_entidad;
                                                    }

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




                                                    //sumatoria ESSALUD
                                                    if (iindice_essalud_vida != -1)
                                                    {
                                                        monto_essalud_vida += Convert.ToDecimal(odtPrueba.Rows[l][iindice_essalud_vida]);

                                                    }

                                                    /* DEC. AFP para cada registro*/
                                                    //monto_dec_afp
                                                    int indice_AFP_SNP = BuscarIndiceColumna(odtPrueba, "AFIL. AFP/SNP");
                                                    string AFP_SNP = odtPrueba.Rows[l][indice_AFP_SNP].ToString();

                                                    if (AFP_SNP == "SNP")
                                                    {
                                                        odtPruebaCorta.Rows[l][iindice_dec_afp] = "0.00";
                                                        monto_dec_afp = monto_aporte_entidad;
                                                        sumatoria_dec_afp += monto_dec_afp;
                                                    }
                                                    else
                                                    {

                                                        monto_dec_afp = monto_a_trabajador + monto_aporte_entidad;
                                                        if (iindice_4ta != -1)
                                                        {
                                                            monto_dec_afp = monto_dec_afp - Convert.ToDecimal(odtPrueba.Rows[l][iindice_4ta]);
                                                        }
                                                        if (iindice_essalud_vida != -1)
                                                        {
                                                            monto_dec_afp = monto_dec_afp - Convert.ToDecimal(odtPrueba.Rows[l][iindice_essalud_vida]);

                                                        }
                                                        if (iindice_renta_5ta_cat != -1)
                                                        {
                                                            monto_dec_afp = monto_dec_afp - Convert.ToDecimal(odtPrueba.Rows[l][iindice_renta_5ta_cat]);
                                                        }

                                                        odtPruebaCorta.Rows[l][iindice_dec_afp] = monto_dec_afp;

                                                        sumatoria_dec_afp += monto_dec_afp;
                                                    }




                                                    if (iindice_essalud_cbbsp != -1)
                                                        monto_essalud_seguro_regular += Convert.ToDecimal(odtPrueba.Rows[l][iindice_essalud_cbbsp]);

                                                    if (iindice_essalud_cbbsp != -1)
                                                        monto_essalud_cbbsp += Convert.ToDecimal(odtPrueba.Rows[l][iindice_essalud_cbbsp]);

                                                    if (iindice_essalud_seguro_complementario != -1)
                                                        monto_essalud_seguro_complementario += Convert.ToDecimal(odtPrueba.Rows[l][iindice_essalud_seguro_complementario]);

                                                    if (iindice_seguro_essalud_privado != -1)
                                                        monto_essalud_seguro_complementario_Privado += Convert.ToDecimal(odtPrueba.Rows[l][iindice_seguro_essalud_privado]);

                                                    if (iindice_seguro_pension != -1)
                                                        monto_essalud_seguro_complementario_Pension += Convert.ToDecimal(odtPrueba.Rows[l][iindice_seguro_pension]);

                                                    //Sumatoria SNP
                                                    if (iindice_snp_dl != -1)
                                                        monto_snp_dl += Convert.ToDecimal(odtPrueba.Rows[l][iindice_snp_dl]);

                                                    //Sumatoria Renta de 5ta 
                                                    if (iindice_renta_quinta != -1)
                                                        monto_renta_quinta += Convert.ToDecimal(odtPrueba.Rows[l][iindice_renta_quinta]);
                                                }

                                                indice_prueba_corta_neto_cobrar = BuscarIndiceColumna(odtPruebaCorta, "NETO A COBRAR");
                                                drFilaCorta[indice_prueba_corta_neto_cobrar] = sumatoria.ToString();

                                                //Si no existe total ingresos .no agrega a drFilaCorta
                                                iindice_ingresos = BuscarIndiceColumna(odtPruebaCorta, "TOTAL INGRESOS");
                                                if (iindice_ingresos != -1)
                                                    drFilaCorta[iindice_ingresos] = sumatoria_ingresos.ToString();

                                                iindice_descuentos = BuscarIndiceColumna(odtPruebaCorta, "TOTAL DESCUENTOS");
                                                if (iindice_descuentos != -1)
                                                    drFilaCorta[iindice_descuentos] = sumatoria_descuentos.ToString();

                                                iindice_a_trabajador = BuscarIndiceColumna(odtPruebaCorta, "TOTAL APORTACIONES TRABAJADOR");
                                                if (iindice_a_trabajador != -1)
                                                    drFilaCorta[iindice_a_trabajador] = sumatoria_a_trabajador.ToString();

                                                iindice_a_empleador = BuscarIndiceColumna(odtPruebaCorta, "TOTAL APORTACIONES EMPLEADOR");
                                                if (iindice_a_empleador != -1)
                                                    drFilaCorta[iindice_a_empleador] = sumatoria_a_empleador.ToString();

                                                iindice_dec_afp = BuscarIndiceColumna(odtPruebaCorta, "DEC. AFP");
                                                if (iindice_dec_afp != -1)
                                                    drFilaCorta[iindice_dec_afp] = sumatoria_dec_afp.ToString();

                                                iindice_aporte_entidad = BuscarIndiceColumna(odtPruebaCorta, columna_aporte_entidad);
                                                if (iindice_aporte_entidad != -1)
                                                {
                                                    //monto_aporte_entidad = Convert.ToDecimal(odtPruebaCorta.Rows[d][iindice_aporte_entidad]);
                                                    //drFilaCorta[iindice_dec_afp] = monto_aporte_entidad + sumatoria_a_trabajador;
                                                    drFilaCorta[iindice_aporte_entidad] = sumatoria_aporte_entidad;
                                                }

                                            }
                                            //Planilla 728 ------ DEC. AFP = total aportaciones trabajador + aportaciones entidad

                                            /* DEC. AFP --- llenando datos  */

                                            //Insertando una fila al datatable odtPruebaCorta
                                            odtPruebaCorta.Rows.InsertAt(drFilaCorta, d);
                                            ll++;
                                        }

                                        if (oDatosGenerales.Ruc == "20159308708")
                                        {

                                        }
                                        else
                                        {
                                            odtPruebaCorta.Columns.Add("OBSERVACIONES", typeof(string));
                                        }


                                        this.dgvPrueba.DataSource = odtPruebaCorta;

                                        odtATrabajador.Columns.Clear();
                                        odtATrabajador.Rows.Clear();

                                        //Agregando columnas al cuadro de AFP
                                        odtATrabajador.Columns.Add("RESUMEN AFP", typeof(string));
                                        odtATrabajador.Columns.Add(" ", typeof(string));
                                        //Calculando cuadro de AFP


                                        indice_snp = BuscarIndiceColumna(odtPrueba, columna_snp);
                                        indice_afp = BuscarIndiceColumna(odtPrueba, "DEC. AFP");
                                        /*
                                        if (indice_snp != -1)
                                        {
                                            drFilaATrabajador = odtATrabajador.NewRow();
                                            drFilaATrabajador.Delete();
                                            drFilaATrabajador[0] = "SNP 13%";
                                            drFilaATrabajador[1] = monto_snp_dl;
                                            odtATrabajador.Rows.InsertAt(drFilaATrabajador, nn);
                                            nn++;
                                        }

                                        if (indice_afp != -1)
                                        {
                                            drFilaATrabajador = odtATrabajador.NewRow();
                                            drFilaATrabajador.Delete();
                                            drFilaATrabajador[0] = "AFP";
                                            drFilaATrabajador[1] = sumatoria_dec_afp;
                                            odtATrabajador.Rows.InsertAt(drFilaATrabajador, nn);
                                            nn++;
                                        }
                                        */
                                        /* Fin SNP y AFP */

                                        /*Hallando AFP*/
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
                                                indice_dec_afp = BuscarIndiceColumna(odtPruebaCorta, "DEC. AFP");
                                                prueba_afp = odtPrueba.Rows[l][5].ToString().Trim();
                                                arr_prueba_trabajador = arr_aportaciones_trabajador[k].ToString().Trim();

                                                if (prueba_afp == arr_prueba_trabajador)
                                                {
                                                    if (odtPruebaCorta.Rows[l][indice_dec_afp] == DBNull.Value)
                                                        sumatoria_afp_parcial = 0;
                                                    else
                                                        sumatoria_afp_parcial = Convert.ToDecimal(odtPruebaCorta.Rows[l][indice_dec_afp]);


                                                    if (iindice_snp_dl != -1)
                                                    {
                                                        if (prueba_afp == "SNP")
                                                            sumatoria_afp_parcial = Convert.ToDecimal(odtPrueba.Rows[l][iindice_snp_dl]);
                                                    }


                                                    sumatoria_afp += sumatoria_afp_parcial;
                                                }
                                            }
                                            drFilaATrabajador[0] = arr_aportaciones_trabajador[k];
                                            drFilaATrabajador[1] = sumatoria_afp;
                                            if (arr_aportaciones_trabajador[k] != "SNP")
                                            {
                                                odtATrabajador.Rows.InsertAt(drFilaATrabajador, nn);
                                            }

                                            nn++;
                                        }



                                        //Calcular la sumatoria total del cuadro AFP
                                        sumatoria_afp = 0;
                                        for (int m = 0; m < odtATrabajador.Rows.Count; m++)
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

                                        /* Cuadro de redondear a entero */
                                        odtRedondear.Columns.Clear();
                                        odtRedondear.Rows.Clear();

                                        CapaDeNegocios.Obras.cMeta ooMeta = new CapaDeNegocios.Obras.cMeta();
                                        CapaDeNegocios.Planillas.cPlantillaPlanilla ooPlantilla = new CapaDeNegocios.Planillas.cPlantillaPlanilla();
                                        List<CapaDeNegocios.ClasificadorMeta.cClasificadorMeta> ListaClasificadoresMeta = new List<CapaDeNegocios.ClasificadorMeta.cClasificadorMeta>();
                                        ooMeta.Codigo = sidtmeta;
                                        ooPlantilla.Descripcion = splantilla;



                                        ListaClasificadoresMeta = oClasificadoresxMetaxPLantilla.ListaClasificadoresMeta(ooPlantilla, ooMeta);
                                        //Agregando columnas al cuadro redondear a entero
                                        odtRedondear.Columns.Add("Clasificador", typeof(string));
                                        odtRedondear.Columns.Add("Concepto", typeof(string));
                                        odtRedondear.Columns.Add("Monto", typeof(string));

                                        iindice_total_ingresos = BuscarIndiceColumna(odtPruebaCorta, "TOTAL INGRESOS");
                                        iindice_total_a_empleador = BuscarIndiceColumna(odtPruebaCorta, "TOTAL APORTACIONES EMPLEADOR");

                                        ultima_fila_prueba_corta = odtPruebaCorta.Rows.Count - 1;
                                        total_ingresos_total = Convert.ToDecimal(odtPruebaCorta.Rows[ultima_fila_prueba_corta][iindice_total_ingresos]);

                                        ultima_fila_prueba_corta = odtPruebaCorta.Rows.Count - 1;
                                        total_a_empleador_total = Convert.ToDecimal(odtPruebaCorta.Rows[ultima_fila_prueba_corta][iindice_total_a_empleador]);

                                        foreach (CapaDeNegocios.ClasificadorMeta.cClasificadorMeta item in ListaClasificadoresMeta)
                                        {
                                            string MontoConcepto = "";

                                            int index = item.Concepto.IndexOf("&&");



                                            if (index != -1)
                                            {
                                                MontoConcepto = "";
                                            }
                                            else
                                            {



                                                switch (item.Concepto)
                                                {
                                                    case "Todo":
                                                        MontoConcepto = (total_ingresos_total + total_a_empleador_total).ToString("0.00");
                                                        break;
                                                    //case "0122":
                                                    //    MontoConcepto = total_ingresos_total.ToString("0.00");
                                                    //    break;
                                                    //case "2039":
                                                    //    MontoConcepto = total_ingresos_total.ToString("0.00");
                                                    //    break;
                                                    case "0804":
                                                        MontoConcepto = monto_essalud_seguro_regular.ToString("0.00");
                                                        break;
                                                    case "0806":
                                                        MontoConcepto = monto_essalud_seguro_complementario.ToString("0.00");
                                                        break;
                                                    case "0810":
                                                        MontoConcepto = monto_essalud_seguro_complementario_Privado.ToString("0.00");
                                                        break;
                                                    case "0805":
                                                        MontoConcepto = monto_essalud_seguro_complementario_Pension.ToString("0.00");
                                                        break;
                                                    case "Total Ingresos":
                                                        MontoConcepto = total_ingresos_total.ToString("0.00");
                                                        break;
                                                    case "Total Aportaciones":
                                                        MontoConcepto = total_a_empleador_total.ToString("0.00");
                                                        break;
                                                    default:
                                                        
                                                        DataTable maestroIngreso = oClasificadoresxMetaxPLantilla.BuscarMaestroIngresoXCodigo(item.Concepto);
                                                        string abreviacion = maestroIngreso.Rows[0]["abreviacion"].ToString();

                                                        int indice_Ingresos_clasificador = BuscarIndiceColumna(odtPrueba, abreviacion);
                                                        if (indice_Ingresos_clasificador != -1)
                                                        {
                                                            decimal montoClasificaor = Convert.ToDecimal(odtPrueba.Rows[odtPrueba.Rows.Count - 1][indice_Ingresos_clasificador]);
                                                            MontoConcepto = montoClasificaor.ToString("0.00");
                                                        }
                                                        else
                                                        {
                                                            MontoConcepto = "0.00";
                                                        }

                                                        break;
                                                }
                                            }
                                            odtRedondear.Rows.Add(item.Especifica.Codigo, item.Especifica.Nombre, MontoConcepto);
                                        }

                                        //if (iindice_essalud_vida != -1) odtRedondear.Columns.Add(columna_essalud_vida, typeof(string));
                                        //if (iindice_essalud_seguro_regular != -1) odtRedondear.Columns.Add(columna_essalud_regular, typeof(string));
                                        //if (iindice_essalud_cbbsp != -1) odtRedondear.Columns.Add(columna_essalud_trabajador , typeof(string));
                                        //if (iindice_essalud_seguro_complementario != -1) odtRedondear.Columns.Add(columna_essalud_complementario, typeof(string));
                                        //if (iindice_snp_dl != -1) odtRedondear.Columns.Add( columna_snp, typeof(string));
                                        //if (iindice_renta_quinta != -1) odtRedondear.Columns.Add( columna_renta_5ta, typeof(string));
                                        //odtRedondear.Columns.Add("TOTAL", typeof(string));

                                        //Actualizando indices para agregar valores a odtRedondear
                                        //iindice_essalud_vida = BuscarIndiceColumna(odtRedondear, columna_essalud_vida);
                                        //iindice_essalud_seguro_regular = BuscarIndiceColumna(odtRedondear, columna_essalud_regular);
                                        //iindice_essalud_cbbsp = BuscarIndiceColumna(odtRedondear, columna_essalud_trabajador);
                                        //iindice_essalud_seguro_complementario = BuscarIndiceColumna(odtRedondear, columna_essalud_complementario);
                                        //iindice_snp_dl = BuscarIndiceColumna(odtRedondear, columna_snp);
                                        //iindice_renta_quinta = BuscarIndiceColumna(odtRedondear, columna_renta_5ta);

                                        //drFilaRedondear = odtRedondear.NewRow();
                                        //drFilaRedondear.Delete();

                                        //decimal monto_redondear_total = 0;
                                        //int iindice_monto_redondear_total = 0;

                                        //iindice_monto_redondear_total = BuscarIndiceColumna(odtRedondear, "TOTAL");

                                        //if (iindice_essalud_vida != -1)
                                        //{
                                        //    drFilaRedondear[iindice_essalud_vida] = Math.Round(monto_essalud_vida, 0);
                                        //    monto_redondear_total += monto_essalud_vida;
                                        //}
                                        //if (iindice_essalud_seguro_regular != -1)
                                        //{
                                        //    drFilaRedondear[iindice_essalud_seguro_regular] = Math.Round(monto_essalud_seguro_regular, 0);
                                        //    monto_redondear_total += monto_essalud_seguro_regular;
                                        //}
                                        //if (iindice_essalud_cbbsp != -1)
                                        //{
                                        //    drFilaRedondear[iindice_essalud_cbbsp] = Math.Round(monto_essalud_cbbsp, 0);
                                        //    monto_redondear_total += monto_essalud_cbbsp;
                                        //}
                                        //if (iindice_essalud_seguro_complementario != -1)
                                        //{
                                        //    drFilaRedondear[iindice_essalud_seguro_complementario] = Math.Round(monto_essalud_seguro_complementario, 0);
                                        //    monto_redondear_total += monto_essalud_seguro_complementario;
                                        //}
                                        //if (iindice_snp_dl != -1)
                                        //{
                                        //    drFilaRedondear[iindice_snp_dl] = Math.Round(monto_snp_dl, 0);
                                        //    monto_redondear_total += monto_snp_dl;
                                        //}
                                        //if (iindice_renta_quinta != -1)
                                        //{
                                        //    drFilaRedondear[iindice_renta_quinta] = Math.Round(monto_renta_quinta, 0);
                                        //    monto_redondear_total += monto_renta_quinta;
                                        //}

                                        //drFilaRedondear[iindice_monto_redondear_total] = Math.Round(monto_redondear_total, 0);

                                        //odtRedondear.Rows.InsertAt(drFilaRedondear, 0);
                                        dgvRedondear.DataSource = odtRedondear;
                                        /* fin cuadro de redondear a entero */

                                        /*3er cuadro de la ultima parte de la planilla*/
                                        odtEEFF.Columns.Clear();
                                        odtEEFF.Rows.Clear();

                                        /*Insertando columnas DEBE Y HABER*/
                                        odtEEFF.Columns.Add(" ", typeof(string));
                                        odtEEFF.Columns.Add("DEBE", typeof(string));
                                        odtEEFF.Columns.Add("HABER", typeof(string));

                                        /*Agregando Remuneración total*/

                                        /*DEBE */
                                        iindice_total_ingresos = BuscarIndiceColumna(odtPruebaCorta, "TOTAL INGRESOS");
                                        iindice_total_a_empleador = BuscarIndiceColumna(odtPruebaCorta, "TOTAL APORTACIONES EMPLEADOR");

                                        if (iindice_total_ingresos != -1)
                                        {
                                            ultima_fila_prueba_corta = odtPruebaCorta.Rows.Count - 1;
                                            total_ingresos_total = Convert.ToDecimal(odtPruebaCorta.Rows[ultima_fila_prueba_corta][iindice_total_ingresos]);
                                            drFilaEEFF = odtEEFF.NewRow();
                                            drFilaEEFF.Delete();
                                            drFilaEEFF[0] = "TOTAL INGRESOS";
                                            drFilaEEFF[1] = total_ingresos_total.ToString("c", new CultureInfo("es-PE"));
                                            total_debe += total_ingresos_total;
                                            odtEEFF.Rows.InsertAt(drFilaEEFF, lll);
                                            lll++;
                                        }
                                        if (iindice_total_a_empleador != -1)
                                        {
                                            ultima_fila_prueba_corta = odtPruebaCorta.Rows.Count - 1;
                                            total_a_empleador_total = Convert.ToDecimal(odtPruebaCorta.Rows[ultima_fila_prueba_corta][iindice_total_a_empleador]);
                                            drFilaEEFF = odtEEFF.NewRow();
                                            drFilaEEFF.Delete();
                                            drFilaEEFF[0] = "TOTAL APORTACIONES EMPLEADOR";
                                            drFilaEEFF[1] = total_a_empleador_total.ToString("c", new CultureInfo("es-PE"));
                                            total_debe += total_a_empleador_total;
                                            odtEEFF.Rows.InsertAt(drFilaEEFF, lll);
                                            lll++;
                                        }

                                        /*FIN DEBE */

                                        /* HABER */
                                        iindice_snp_13 = BuscarIndiceColumna(odtPrueba, columna_snp);
                                        iindice_afp = BuscarIndiceColumna(odtPruebaCorta, "DEC. AFP");
                                        iindice_aportacion_entidad = BuscarIndiceColumna(odtPrueba, columna_aporte_entidad);
                                        iindice_neto_cobrar = BuscarIndiceColumna(odtPruebaCorta, "NETO A COBRAR");

                                        iindice_essalud_cbbsp = BuscarIndiceColumna(odtPrueba, columna_essalud_trabajador);
                                        iindice_essalud_seguro_complementario = BuscarIndiceColumna(odtPrueba, columna_essalud_complementario);

                                        if (odtPruebaCorta.Rows.Count > 0) ultima_fila_prueba_corta = odtPruebaCorta.Rows.Count - 1;
                                        if (odtPrueba.Rows.Count > 0) ultima_fila_prueba = odtPrueba.Rows.Count - 1;



                                        if (iindice_snp_13 != -1)
                                        {
                                            snp_total = Convert.ToDecimal(odtPrueba.Rows[ultima_fila_prueba][iindice_snp_13]);
                                            drFilaEEFF = odtEEFF.NewRow();
                                            drFilaEEFF.Delete();
                                            drFilaEEFF[0] = columna_snp;
                                            drFilaEEFF[2] = snp_total.ToString("c", new CultureInfo("es-PE"));
                                            haber_total += snp_total;
                                            odtEEFF.Rows.InsertAt(drFilaEEFF, lll);
                                            lll++;
                                        }

                                        if (iindice_aportacion_entidad != -1)
                                            aportacion_entidad_total = Convert.ToDecimal(odtPrueba.Rows[ultima_fila_prueba_corta][iindice_aportacion_entidad]);



                                        if (iindice_afp != -1)
                                        {
                                            afp_total = Convert.ToDecimal(odtPruebaCorta.Rows[ultima_fila_prueba_corta][iindice_afp]);
                                            //afp_total = afp_total + aportacion_entidad_total;
                                            drFilaEEFF = odtEEFF.NewRow();
                                            drFilaEEFF.Delete();
                                            drFilaEEFF[0] = "AFP";
                                            drFilaEEFF[2] = afp_total.ToString("c", new CultureInfo("es-PE"));

                                            haber_total += afp_total;

                                            odtEEFF.Rows.InsertAt(drFilaEEFF, lll);
                                            lll++;
                                        }

                                        if (iindice_essalud_vida != -1)
                                        {
                                            //essalud_vida_total = Convert.ToDecimal(odtPruebaCorta.Rows[ultima_fila_prueba_corta][iindice_essalud_vida]);
                                            drFilaEEFF = odtEEFF.NewRow();
                                            drFilaEEFF.Delete();
                                            drFilaEEFF[0] = "ESSALUD VIDA";
                                            drFilaEEFF[2] = monto_essalud_vida.ToString("c", new CultureInfo("es-PE"));
                                            haber_total += monto_essalud_vida;
                                            odtEEFF.Rows.InsertAt(drFilaEEFF, lll);
                                            lll++;
                                        }

                                        if (iindice_neto_cobrar != -1)
                                        {
                                            neto_cobrar_total = Convert.ToDecimal(odtPruebaCorta.Rows[ultima_fila_prueba_corta][iindice_neto_cobrar]);
                                            drFilaEEFF = odtEEFF.NewRow();
                                            drFilaEEFF.Delete();
                                            drFilaEEFF[0] = "NETO A COBRAR";
                                            drFilaEEFF[2] = neto_cobrar_total.ToString("c", new CultureInfo("es-PE"));
                                            haber_total += neto_cobrar_total;
                                            odtEEFF.Rows.InsertAt(drFilaEEFF, lll);
                                            lll++;
                                        }

                                        CapaDeNegocios.Sunat.cMaestroDescuentos oMaestroDescuentos = new CapaDeNegocios.Sunat.cMaestroDescuentos();
                                        DataTable odtMaestroDescuentos = new DataTable();
                                        string titulo_maestro_descuento = "";

                                        odtMaestroDescuentos = oMaestroDescuentos.ListarMaestroDescuentos();

                                        for (int i = 0; i < odtMaestroDescuentos.Rows.Count; i++)
                                        {

                                            titulo_maestro_descuento = odtMaestroDescuentos.Rows[i][4].ToString();
                                            iindice_ad = BuscarIndiceColumna(odtPrueba, titulo_maestro_descuento);

                                            if (iindice_ad != -1)
                                            {
                                                ad_total = Convert.ToDecimal(odtPrueba.Rows[ultima_fila_prueba][iindice_ad]);
                                                drFilaEEFF = odtEEFF.NewRow();
                                                drFilaEEFF.Delete();
                                                drFilaEEFF[0] = titulo_maestro_descuento;
                                                drFilaEEFF[2] = ad_total.ToString("c", new CultureInfo("es-PE"));
                                                haber_total += ad_total;
                                                odtEEFF.Rows.InsertAt(drFilaEEFF, lll);
                                                lll++;
                                            }
                                        }

                                        CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador oMaestroAportacion = new CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador();
                                        DataTable odtMaestroAportacion = new DataTable();
                                        string titulo_maestro_Aportacion = "";

                                        odtMaestroAportacion = oMaestroAportacion.ListarMaestroAportacionesEmpleador();

                                        for (int i = 0; i < odtMaestroAportacion.Rows.Count; i++)
                                        {

                                            titulo_maestro_Aportacion = odtMaestroAportacion.Rows[i][4].ToString();
                                            iindice_ad = BuscarIndiceColumna(odtPrueba, titulo_maestro_Aportacion);

                                            if (iindice_ad != -1)
                                            {
                                                ad_total = Convert.ToDecimal(odtPrueba.Rows[ultima_fila_prueba][iindice_ad]);
                                                drFilaEEFF = odtEEFF.NewRow();
                                                drFilaEEFF.Delete();
                                                drFilaEEFF[0] = titulo_maestro_Aportacion;
                                                drFilaEEFF[2] = ad_total.ToString("c", new CultureInfo("es-PE"));
                                                haber_total += ad_total;
                                                odtEEFF.Rows.InsertAt(drFilaEEFF, lll);
                                                lll++;
                                            }
                                        }


                                        /* Insertando totales de debe y haber*/

                                        drFilaEEFF = odtEEFF.NewRow();
                                        drFilaEEFF.Delete();
                                        drFilaEEFF[0] = "TOTAL";
                                        drFilaEEFF[1] = total_debe.ToString("c", new CultureInfo("es-PE"));
                                        drFilaEEFF[2] = haber_total.ToString("c", new CultureInfo("es-PE"));
                                        odtEEFF.Rows.InsertAt(drFilaEEFF, lll);

                                        dgvEEFF.DataSource = odtEEFF;
                                        /* FIN HABER */

                                        /*Fin del 3er cuadro de la ultima parte de la planilla*/

                                        exportar_a_pdf(sidtregimenlaboral);
                                    }
                                    else
                                        MessageBox.Show("Plantilla sin datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    #endregion
                                }

                            }
                        }
                       
                    }
                }
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


        public DataTable buscarDuplicados(DataTable auxiliar)
        {
           
            int contador = 0;



            List<string> dniDuplicados = new List<string>();
            DataTable auxiliar2;
            auxiliar2 = auxiliar;

            for (int i = 0; i < auxiliar.Rows.Count; i++)
            {
                contador = 0;
                for (int j = 0; j < auxiliar.Rows.Count; j++)
                {
                    if (auxiliar.Rows[i][2].ToString() == auxiliar.Rows[j][2].ToString())
                    {
                        contador = contador + 1;
                        
                    }

                    if (contador > 1)
                    {
                        dniDuplicados.Add(auxiliar.Rows[i][2].ToString());
                        break;
                    }
                }
            }

            
            IEnumerable <string> dniDuplicadosEnum = dniDuplicados.Distinct();
            foreach (string item in dniDuplicadosEnum)
            {
                auxiliar2 = QuitarDuplicado(auxiliar2, item);
            }


            return auxiliar2;
        }

        public DataTable QuitarDuplicado(DataTable auxiliar, string dni)
        {
            for (int i = 0; i < auxiliar.Rows.Count; i++)
            {
                if (auxiliar.Rows[i][2].ToString() == dni)
                {
                    auxiliar.Rows[i].Delete();
                    auxiliar.AcceptChanges();
                    break;
                }
            }

            return auxiliar;
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
                if (i == 4) values[i] = 120;
                if (i == 3) values[i] = 100;

                if (i == dg.ColumnCount - 1) values[i] = 300;
                if (i == dg.ColumnCount - 2) values[i] = 50;

                if (chkCuentaBancaria.Checked)
                {
                    if (i == dg.ColumnCount - 1) values[i] = 250;
                    if (i == dg.ColumnCount - 2) values[i] = 150;
                    if (i == dg.ColumnCount - 3) values[i] = 50;
                }
                if (oDatosGenerales.Ruc == "20159308708")
                {
                    if (i == 4) values[i] = 110;
                    if (i == 6) values[i] = 110;
                    if (i == dg.ColumnCount - 1) values[i] = 50;
                    if (i == dg.ColumnCount - 2) values[i] = 150;
                   
                }
                if (i == 5) values[i] = 50;
                if (i == 6) values[i] = 120;
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


        
        private void exportar_a_pdf(int numeroRegimenLaboral)
        {
            //Creating iTextSharp Table from the DataTable data
            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 7);
            iTextSharp.text.Font fuenteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 9, 1, iTextSharp.text.Color.BLUE);

            PdfPTable pdfTable = new PdfPTable(dgvPrueba.ColumnCount);

            PdfPTable pdfObservaciones = new PdfPTable(1);

            PdfPTable pdfTable2 = new PdfPTable(dgvAFP.ColumnCount);
            PdfPTable pdfTableRedondear = new PdfPTable(dgvRedondear.ColumnCount);
            PdfPTable pdfTableEEFF = new PdfPTable(dgvEEFF.ColumnCount);

            Phrase objP = new Phrase("A", fuente);
            Phrase objP2 = new Phrase("A", fuente);
            Phrase objP3 = new Phrase("A", fuente);
            //Phrase objH = new Phrase("A", fuenteTitulo);
            PdfPCell cell;
            PdfPCell cell2;
            PdfPCell cell3;
            PdfPCell cell4;

            pdfTable.DefaultCell.Padding = 1;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            //pdfTable.DefaultCell.FixedHeight = 600f;

            pdfObservaciones.DefaultCell.Padding = 1;
            pdfObservaciones.HorizontalAlignment = Element.ALIGN_JUSTIFIED_ALL;
            pdfObservaciones.DefaultCell.BorderWidth = 1;

            pdfTable2.DefaultCell.Padding = 1;
            pdfTable2.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable2.DefaultCell.BorderWidth = 1;

            pdfTableRedondear.DefaultCell.Padding = 1;
            pdfTableRedondear.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTableRedondear.DefaultCell.BorderWidth = 1;

            pdfTableEEFF.DefaultCell.Padding = 1;
            pdfTableEEFF.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTableEEFF.DefaultCell.BorderWidth = 1;

            float[] headerwidths = GetTamañoColumnas(dgvPrueba);
            float[] headerwidths2 = GetTamañoColumnas2(dgvAFP);
            float[] headerwidths3 = GetTamañoColumnas2(dgvRedondear);
            float[] headerwidths4 = GetTamañoColumnas2(dgvEEFF);
            //float[] headerwidths = { 2f, 6f, 6f, 3f, 5f, 8f, 5f, 5f, 5f, 5f };

            //cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#d1dbe0"));

            pdfTable.SetWidths(headerwidths);
            pdfTable.WidthPercentage = 100;
            
            pdfTable2.SetWidths(headerwidths2);
            pdfTable2.WidthPercentage = 100;

            pdfTableRedondear.SetWidths(headerwidths3);
            pdfTableRedondear.WidthPercentage = 100;

            pdfTableEEFF.SetWidths(headerwidths4);
            pdfTableEEFF.WidthPercentage = 100;

            int iindice_nombre = 0;
            int iindice_cargo = 0;
            int iindice_fecha = 0;
            int iindice_afi_com_cus = 0;

            //parte para las observaciones
            PdfPCell tituloObservaciones = new PdfPCell((new Phrase("OBSERVACIONES", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
            tituloObservaciones.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
            tituloObservaciones.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfObservaciones.AddCell(tituloObservaciones);

             CapaDeNegocios.Planillas.cPlanilla  planplnilla =  miPlanilla.TraerPlanilla(sidtplanilla);

            if (planplnilla.Observaciones.Trim() != "")
            {
                PdfPCell tituloObservaciones2 = new PdfPCell((new Phrase(planplnilla.Observaciones, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                //tituloObservaciones2.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                tituloObservaciones2.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfObservaciones.AddCell(tituloObservaciones2);

            }
            /* -------------fin observaciones ----------*/

            //Adding Header row
            foreach (DataGridViewColumn column in dgvPrueba.Columns)
            {
                cell = new PdfPCell((new Phrase( column.HeaderText , new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                //cell = new PdfPCell(new Phrase(column.HeaderText));
                //PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                // objH = new Phrase(column.HeaderText, fuenteTitulo);
                pdfTable.AddCell(cell);
            }

            /*Indices de la secciones alineadas*/
            iindice_nombre = BuscarIndiceColumna(odtPruebaCorta, "NOMBRE COMPLETO");
            iindice_cargo = BuscarIndiceColumna(odtPruebaCorta, "CARGO");
            iindice_fecha = BuscarIndiceColumna(odtPruebaCorta, "FECHA INICIO");
            iindice_afi_com_cus = BuscarIndiceColumna(odtPruebaCorta, "AFIL. AFP/SNP \n\n COMIS. \n\n CUSP ");

            for (int i = 0; i < dgvPrueba.RowCount - 1; i++)
            {
                for (int j = 0; j < dgvPrueba.ColumnCount; j++)
                {
                    //objP = new Phrase(dgvPrueba[j, i].Value.ToString(), fuente);
                    
                    cell = new PdfPCell((new Phrase(dgvPrueba[j, i].Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                    if (columnasFijas)
                    {
                        cell.FixedHeight = altoColumna;
                    }
                    
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
                    cell = new PdfPCell((new Phrase(dgvAFP[l, k].Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));

                    if (l == 1)
                        cell.HorizontalAlignment = Element.ALIGN_RIGHT;

                    pdfTable2.AddCell(cell);

                }
                pdfTable2.CompleteRow();
            }

            /*----------------fin dfvAFP*/

            /* ------------- dgvRedondear ----------- */

            foreach (DataGridViewColumn column in dgvRedondear.Columns)
            {
                cell3 = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                //cell = new PdfPCell(new Phrase(column.HeaderText));
                //PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell3.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                // objH = new Phrase(column.HeaderText, fuenteTitulo);
                pdfTableRedondear.AddCell(cell3);
            }

            for (int k = 0; k < dgvRedondear.RowCount - 1; k++)
            {
                for (int l = 0; l < dgvRedondear.ColumnCount; l++)
                {
                    cell3 = new PdfPCell((new Phrase(dgvRedondear[l, k].Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                    cell3.HorizontalAlignment = Element.ALIGN_RIGHT;
                    pdfTableRedondear.AddCell(cell3);
                }
                pdfTableRedondear.CompleteRow();
            }

            /* -------------fin dgvRedondear ----------*/

            /* ---------------- dgvEEFF */

            //Adding Header row
            foreach (DataGridViewColumn column in dgvEEFF.Columns)
            {
                cell2 = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                cell2.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                pdfTableEEFF.AddCell(cell2);
            }

            for (int k = 0; k < dgvEEFF.RowCount - 1; k++)
            {
                for (int l = 0; l < dgvEEFF.ColumnCount; l++)
                {
                    cell2 = new PdfPCell((new Phrase(dgvEEFF[l, k].Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                    if (l == 1 || l == 2)
                        cell2.HorizontalAlignment = Element.ALIGN_RIGHT;
                    pdfTableEEFF.AddCell(cell2);
                }
            }

            /*----------------fin dgvEEFF*/

            //Exporting to PDF
            string folderPath = "C:\\PDFs\\";

            //use a variable to let my code fit across the page...
            //string path = Server.MapPath("PDFs");
            //PdfWriter.GetInstance(doc1, new FileStream(path + "/Doc1.pdf", FileMode.Create));

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "Planilla.pdf", FileMode.Create))
            {

                Document pdfDoc = new Document(PageSize.A4, 9, 9, 25, 10);
                pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());

                

                Paragraph paragraph = new Paragraph();
                paragraph.Alignment = Element.ALIGN_CENTER;
                paragraph.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 12);
               
                paragraph.Add(oDatosGenerales.Nombre + " \n " + oDatosGenerales.NombreOficina + " \n ");

               
                paragraph.SpacingBefore = 0f;
                paragraph.SpacingAfter = 0f;
                
                
                Paragraph paragraph2 = new Paragraph();
                paragraph2.Alignment = Element.ALIGN_RIGHT;
                paragraph2.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                paragraph2.Add("PLANILLA Nº " + sNumeroPlanilla + " - " + saño + " \n ");
                paragraph2.SpacingBefore = 0f;
                paragraph2.SpacingAfter = 0f;
                paragraph2.SetLeading(0, 0);


                Paragraph paragraph3 = new Paragraph();
                paragraph3.Alignment = Element.ALIGN_CENTER;
                paragraph3.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                /*paragraph3.Add("PLANILLA DE RENUMERACIONES DEL PERSONAL DE " + sRegimenLaboral + " DE " + saño + " DE " + smes + ".");*/
                /*Titulo de planilla */
                paragraph3.Add(sdescripcion.ToString().ToUpper() + " DE " + smes + " DE " + saño + ".");
                paragraph3.SpacingBefore = 0f;
                paragraph3.SpacingAfter = 0f;


                Paragraph paragraph4 = new Paragraph();
                paragraph4.Alignment = Element.ALIGN_LEFT;
                paragraph4.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                paragraph4.IndentationLeft = 110f;
                paragraph4.SpacingAfter = 0;
                paragraph4.SpacingBefore = 0;
                

                string smeta_numero_con_ceros = string.Format("{0:000}", smeta_numero);
                
                paragraph4.Add("META:" + smeta_numero.PadLeft(3,'0') + " - " + smeta + ". \n\n");

                Paragraph paragraph40 = new Paragraph();
                paragraph40.Alignment = Element.ALIGN_LEFT;
                paragraph40.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                paragraph40.IndentationLeft = 110f;
                paragraph4.Add("FUENTE FINANCIAMIENTO:" + sfuentefinanciamiento + ". \n\n");
                paragraph40.SpacingAfter = 0;
                paragraph40.SpacingBefore = 0;
             

                Paragraph paragraph5 = new Paragraph();
                paragraph5.Alignment = Element.ALIGN_CENTER;
                paragraph5.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                paragraph5.Add("\n");

                DateTime fecha = DateTime.Now;
                 
                Paragraph paragraph6 = new Paragraph();
                paragraph6.Alignment = Element.ALIGN_CENTER;
                paragraph6.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);

                CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

                fecha = Convert.ToDateTime( oPlanilla.ListarFechaPlanilla(sidtplanilla).Rows[0][1].ToString() );

                paragraph6.Add(oDatosGenerales.Lugar +  ", " + String.Format("{0:dd}", fecha) + " DE " + String.Format("{0:MMMM}", fecha).ToUpper() + " DEL " + String.Format("{0:yyyy}", fecha) + ". \n");
                /*FEcha de hoy*/
                //paragraph6.Add("CCATCCA, " + String.Format("{0:dd}" , fecha) + " DE " + String.Format("{0:MMMM}", fecha).ToUpper() + " DEL " + String.Format("{0:yyyy}", fecha) + ". \n");


                



                PdfWriter.GetInstance(pdfDoc, stream);
                CreateHeaderFooter(ref pdfDoc);
                pdfDoc.Open();

                //string imageURL = "C:\\Users\\ADVANCE\\Source\\Repos\\slnRecursosHumanos\\slnRecursosHumanos\\Recursos Varios\\MUNICIPALIDAD-DISTRITAL-DE-CCATCCA-2.png";
                //string ruta = Directory.GetCurrentDirectory();
                string ruta = System.IO.Directory.GetCurrentDirectory();

                string ruta_imagen = ruta + "\\logo-muni-fw.png";

                string ruta_cuadro_oficinas = ruta + "\\LogoBicentenario2021.jpeg";

                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(ruta_imagen);
                logo.ScalePercent(64f);
                logo.SetAbsolutePosition(12f, pdfDoc.PageSize.Height-100f);

                iTextSharp.text.Image oficinas = iTextSharp.text.Image.GetInstance(ruta_cuadro_oficinas);
                oficinas.ScalePercent(64f);
                oficinas.SetAbsolutePosition(pdfDoc.PageSize.Width - 150f , pdfDoc.PageSize.Height - 80f);

                //tabla que continene logo, meta y nº planilla
                PdfPTable tabla_bonus = new PdfPTable(3);
                tabla_bonus.DefaultCell.BorderWidth = 0;



                //tabla que continene rrhh, gerencia municipal, presupuesto y contabilidad
                int NumeroFirmas = 0;
                if (chkFirmaElaborado.Checked){NumeroFirmas++;}
                if (chkFirmaRecursos.Checked){NumeroFirmas++;}
                if (chkFirmaGerencia.Checked) { NumeroFirmas++; }
                if (chkFirmaContabilidad.Checked) { NumeroFirmas++; }
                if (chkFirmaTesoreria.Checked) { NumeroFirmas++; }
                if (chkFirmaResidencia.Checked) { NumeroFirmas++; }
                if (chkSubGerenciaObras.Checked) { NumeroFirmas++; }
                if (chkSupervision.Checked) { NumeroFirmas++; }
                if (chkFirmaPresupuesto.Checked) { NumeroFirmas++; }
                if (chkGerenciaAdministracion.Checked) { NumeroFirmas++; }
                PdfPTable tabla_firmas;
                PdfPTable tabla_firmas2;
                PdfPTable tabla_firmas3;

                List<Paragraph> ArregloFirmas = new List<Paragraph>(); 

                //Se coloca en una sola tabla
                if (NumeroFirmas <= 5)
                {
                    tabla_firmas = new PdfPTable(NumeroFirmas);
                    tabla_firmas.DefaultCell.BorderWidth = 0;
                    tabla_firmas2 = new PdfPTable(1);
                    tabla_firmas3 = new PdfPTable(1);
                    foreach (CheckBox item in this.groupBox2.Controls.OfType<CheckBox>().OrderBy(tb => tb.TabIndex))
                    {
                        if (item.Name != "chkAltoColumna" && item.Checked== true)
                        {
                            Paragraph auxiliar = new Paragraph();
                            auxiliar.Alignment = Element.ALIGN_CENTER;
                            auxiliar.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                            auxiliar.Add(".............................................\n   " + item.Text);
                            tabla_firmas.AddCell(auxiliar);
                        }
                    }
                }
                else
                {
                    // se coloca en 2 tablas
                    if (NumeroFirmas <=8)
                    {
                        tabla_firmas = new PdfPTable(4);
                        tabla_firmas2 = new PdfPTable(NumeroFirmas-4);
                        tabla_firmas.DefaultCell.BorderWidth = 0;
                        tabla_firmas2.DefaultCell.BorderWidth = 0;
                        tabla_firmas3 = new PdfPTable(1);

                        int contador = 0;
                        foreach (CheckBox item in this.groupBox2.Controls.OfType<CheckBox>().OrderBy(tb => tb.TabIndex))
                        {
                            
                            if (item.Name != "chkAltoColumna" && item.Checked == true)
                            {
                                contador++;
                                Paragraph auxiliar = new Paragraph();
                                auxiliar.Alignment = Element.ALIGN_CENTER;
                                auxiliar.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                                auxiliar.Add(".............................................\n   " + item.Text);
                                if (contador <=4)
                                {
                                    tabla_firmas.AddCell(auxiliar);
                                }
                                else
                                {
                                    tabla_firmas2.AddCell(auxiliar);
                                }
                            }
                        }
                    }
                    else
                    {
                        tabla_firmas = new PdfPTable(3);
                        tabla_firmas2 = new PdfPTable(3);
                        tabla_firmas3 = new PdfPTable(NumeroFirmas- 6);
                        tabla_firmas.DefaultCell.BorderWidth = 0;
                        tabla_firmas2.DefaultCell.BorderWidth = 0;
                        tabla_firmas3.DefaultCell.BorderWidth = 0;

                        int contador = 0;
                        foreach (CheckBox item in this.groupBox2.Controls.OfType<CheckBox>().OrderBy(tb => tb.TabIndex))
                        {
                            if (item.Name != "chkAltoColumna" && item.Checked == true)
                            {
                                contador++;
                                Paragraph auxiliar = new Paragraph();
                                auxiliar.Alignment = Element.ALIGN_CENTER;
                                auxiliar.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                                auxiliar.Add(".............................................\n   " + item.Text);
                                if (contador <= 3)
                                {
                                    tabla_firmas.AddCell(auxiliar);
                                }
                                else
                                {
                                    if (contador <= 6)
                                    {
                                        tabla_firmas2.AddCell(auxiliar);
                                    }
                                    else
                                    {
                                        tabla_firmas3.AddCell(auxiliar);
                                    }
                                }
                            }
                        }
                    }

                }

             
             
                //instanciando una columna y 3 columnas
                //Columnas 
                MultiColumnText column_one = new MultiColumnText();
                column_one.AddRegularColumns(36f, pdfDoc.PageSize.Width - 36f, 24f, 1);


                MultiColumnText column_3 = new MultiColumnText();
                column_3.AddRegularColumns(36f, pdfDoc.PageSize.Width - 36f, 24f, 4);

                PdfPTable tabla_Encabezado = new PdfPTable(3);
                tabla_Encabezado.DefaultCell.BorderWidth = 0;

                Paragraph vacio = new Paragraph();
                vacio.Alignment = Element.ALIGN_CENTER;
                vacio.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);

                tabla_Encabezado.SetWidths(new float[] { 30, 120, 40 });
                //tabla_Encabezado.SetWidthPercentage(new float[] { 20f, 60f, 20f }, iTextSharp.text.PageSize.A4.Rotate());
                tabla_Encabezado.AddCell(vacio);
                tabla_Encabezado.AddCell(paragraph3);
                tabla_Encabezado.AddCell(paragraph2);

                //Agrupando tabla titular
                tabla_bonus.AddCell(pdfTableRedondear);
                tabla_bonus.AddCell(pdfTable2);
                
                tabla_bonus.AddCell(pdfTableEEFF);

               
                
                //Agregando una columna 
                column_one.AddElement(paragraph);
                //column_one.AddElement(logo);
                //column_one.AddElement(paragraph2);
                //column_one.AddElement(paragraph3);
                column_one.AddElement(tabla_Encabezado);
                column_one.AddElement(paragraph4);
                column_one.AddElement(paragraph40);
                column_one.AddElement(pdfTable);
                //column_one.AddElement(paragraph5);
                if (planplnilla.Observaciones.Trim() != "")
                {
                    column_one.AddElement(pdfObservaciones);
                }

                column_one.AddElement(paragraph6);
                column_one.AddElement(tabla_bonus);
                column_one.AddElement(paragraph5);
                column_one.AddElement(paragraph5);
                column_one.AddElement(paragraph5);
                column_one.AddElement(paragraph5);
                column_one.AddElement(paragraph5);
                //column_one.AddElement(paragraph5);
                column_one.AddElement(tabla_firmas);

                if (NumeroFirmas <= 10)
                {
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(tabla_firmas2);
                }
                if (NumeroFirmas >= 9)
                {
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(tabla_firmas3);
                }
                
                pdfDoc.Add(logo);
                pdfDoc.Add(oficinas);
                pdfDoc.Add(column_one);
                //pdfDoc.Add(column_dos);
                pdfDoc.Close();
                stream.Close();
            }

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "C:\\PDFs\\Planilla.pdf";
            proc.Start();

        }


        private void exportar_a_pdf_Racionamiento(int numeroRegimenLaboral)
        {
            //Creating iTextSharp Table from the DataTable data
            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 7);
            iTextSharp.text.Font fuenteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 9, 1, iTextSharp.text.Color.BLUE);

            PdfPTable pdfTable = new PdfPTable(dgvPrueba.ColumnCount);
            PdfPTable pdfTableRedondear;
            float[] headerwidths3;

            if (dgvRedondear.ColumnCount > 0)
            {
                pdfTableRedondear  = new PdfPTable(dgvRedondear.ColumnCount);
                headerwidths3 = GetTamañoColumnas2(dgvRedondear);
            }
            
            else
            {
                pdfTableRedondear = new PdfPTable(1);
                headerwidths3 = new float[] { 100f};
            }

            Phrase objP = new Phrase("A", fuente);
            Phrase objP2 = new Phrase("A", fuente);
            Phrase objP3 = new Phrase("A", fuente);
            //Phrase objH = new Phrase("A", fuenteTitulo);
            PdfPCell cell;
            PdfPCell cell2;
            PdfPCell cell3;
            PdfPCell cell4;

            pdfTable.DefaultCell.Padding = 1;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            //pdfTable.DefaultCell.FixedHeight = 600f;

            float[] headerwidths = GetTamañoColumnas(dgvPrueba);
            float[] headerwidths2 = GetTamañoColumnas2(dgvAFP);
           
            float[] headerwidths4 = GetTamañoColumnas2(dgvEEFF);
            //float[] headerwidths = { 2f, 6f, 6f, 3f, 5f, 8f, 5f, 5f, 5f, 5f };

            //cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#d1dbe0"));

            pdfTable.SetWidths(headerwidths);
            pdfTable.WidthPercentage = 100;


            pdfTableRedondear.DefaultCell.Padding = 1;
            pdfTableRedondear.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTableRedondear.DefaultCell.BorderWidth = 1;


            pdfTableRedondear.SetWidths(headerwidths3);
            pdfTableRedondear.WidthPercentage = 100;

            int iindice_nombre = 0;
            int iindice_cargo = 0;
            int iindice_fecha = 0;
            int iindice_afi_com_cus = 0;

            //Adding Header row
            foreach (DataGridViewColumn column in dgvPrueba.Columns)
            {
                cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                //cell = new PdfPCell(new Phrase(column.HeaderText));
                //PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                // objH = new Phrase(column.HeaderText, fuenteTitulo);
                pdfTable.AddCell(cell);
            }

            /*Indices de la secciones alineadas*/
            iindice_nombre = BuscarIndiceColumna(odtPrueba, "NOMBRE COMPLETO");
            iindice_cargo = BuscarIndiceColumna(odtPrueba, "CARGO");
            iindice_fecha = BuscarIndiceColumna(odtPrueba, "FECHA INICIO");
            iindice_afi_com_cus = BuscarIndiceColumna(odtPrueba, "AFIL. AFP/SNP \n\n COMISION \n\n CUSP ");

            for (int i = 0; i < dgvPrueba.RowCount - 1; i++)
            {
                for (int j = 0; j < dgvPrueba.ColumnCount; j++)
                {
                    //objP = new Phrase(dgvPrueba[j, i].Value.ToString(), fuente);

                    cell = new PdfPCell((new Phrase(dgvPrueba[j, i].Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                    if (columnasFijas)
                    {
                        cell.FixedHeight = altoColumna;
                    }

                    //Alineando a la derecha la columna nº
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;

                    if (j == iindice_nombre || j == iindice_cargo || j == iindice_fecha || j == iindice_afi_com_cus)
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;

                    pdfTable.AddCell(cell);
                }
                pdfTable.CompleteRow();
            }


            /* ------------- dgvRedondear ----------- */

            foreach (DataGridViewColumn column in dgvRedondear.Columns)
            {
                cell3 = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                //cell = new PdfPCell(new Phrase(column.HeaderText));
                //PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell3.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                // objH = new Phrase(column.HeaderText, fuenteTitulo);
                pdfTableRedondear.AddCell(cell3);
            }

            for (int k = 0; k < dgvRedondear.RowCount - 1; k++)
            {
                for (int l = 0; l < dgvRedondear.ColumnCount; l++)
                {
                    cell3 = new PdfPCell((new Phrase(dgvRedondear[l, k].Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                    cell3.HorizontalAlignment = Element.ALIGN_RIGHT;
                    pdfTableRedondear.AddCell(cell3);
                }
                pdfTableRedondear.CompleteRow();
            }

            /* -------------fin dgvRedondear ----------*/




            /*----------------fin dgvEEFF*/

            //Exporting to PDF
            string folderPath = "C:\\PDFs\\";

            //use a variable to let my code fit across the page...
            //string path = Server.MapPath("PDFs");
            //PdfWriter.GetInstance(doc1, new FileStream(path + "/Doc1.pdf", FileMode.Create));

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "Planilla.pdf", FileMode.Create))
            {

                Document pdfDoc = new Document(PageSize.A4, 9, 9, 40, 30);
                pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());



                Paragraph paragraph = new Paragraph();
                paragraph.Alignment = Element.ALIGN_CENTER;
                paragraph.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 12);

                paragraph.Add(oDatosGenerales.Nombre + " \n " + oDatosGenerales.NombreOficina + " \n ");

                

                Paragraph paragraph2 = new Paragraph();
                paragraph2.Alignment = Element.ALIGN_RIGHT;
                paragraph2.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                paragraph2.Add("PLANILLA Nº " + sNumeroPlanilla + " - " + saño + " \n ");

                Paragraph paragraph3 = new Paragraph();
                paragraph3.Alignment = Element.ALIGN_CENTER;
                paragraph3.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                /*paragraph3.Add("PLANILLA DE RENUMERACIONES DEL PERSONAL DE " + sRegimenLaboral + " DE " + saño + " DE " + smes + ".");*/
                /*Titulo de planilla */
                paragraph3.Add(sdescripcion.ToString().ToUpper() + " DE " + smes + " DE " + saño + ".");

                Paragraph paragraph4 = new Paragraph();
                paragraph4.Alignment = Element.ALIGN_LEFT;
                paragraph4.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                paragraph4.IndentationLeft = 110f;

                string smeta_numero_con_ceros = string.Format("{0:000}", smeta_numero);

                paragraph4.Add("META:" + smeta_numero.PadLeft(3, '0') + " - " + smeta + ". \n\n");

                Paragraph paragraph40 = new Paragraph();
                paragraph40.Alignment = Element.ALIGN_LEFT;
                paragraph40.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                paragraph40.IndentationLeft = 110f;
                paragraph4.Add("FUENTE FINANCIAMIENTO:" + sfuentefinanciamiento + ". \n\n");

                Paragraph paragraph5 = new Paragraph();
                paragraph5.Alignment = Element.ALIGN_CENTER;
                paragraph5.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                paragraph5.Add("\n");

                DateTime fecha = DateTime.Now;

                Paragraph paragraph6 = new Paragraph();
                paragraph6.Alignment = Element.ALIGN_CENTER;
                paragraph6.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);

                CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

                fecha = Convert.ToDateTime(oPlanilla.ListarFechaPlanilla(sidtplanilla).Rows[0][1].ToString());

                paragraph6.Add(oDatosGenerales.Lugar + ", " + String.Format("{0:dd}", fecha) + " DE " + String.Format("{0:MMMM}", fecha).ToUpper() + " DEL " + String.Format("{0:yyyy}", fecha) + ". \n");
                /*FEcha de hoy*/
                //paragraph6.Add("CCATCCA, " + String.Format("{0:dd}" , fecha) + " DE " + String.Format("{0:MMMM}", fecha).ToUpper() + " DEL " + String.Format("{0:yyyy}", fecha) + ". \n");




                PdfWriter.GetInstance(pdfDoc, stream);
                CreateHeaderFooter(ref pdfDoc);
                pdfDoc.Open();

                //string imageURL = "C:\\Users\\ADVANCE\\Source\\Repos\\slnRecursosHumanos\\slnRecursosHumanos\\Recursos Varios\\MUNICIPALIDAD-DISTRITAL-DE-CCATCCA-2.png";
                //string ruta = Directory.GetCurrentDirectory();
                string ruta = System.IO.Directory.GetCurrentDirectory();
                //string ruta2 = Application.StartupPath;
                //string ruta3 = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

                //string[] palabras = ruta.Split('\\');

                //string ruta_imagen = palabras[0] + '\\' + palabras[1] + '\\' + palabras[2] + '\\' +
                //palabras[3] + '\\' + palabras[4] + '\\' + palabras[5] + '\\' + palabras[6] + '\\';

                //string ruta_carpeta = "Recursos Varios\\MUNICIPALIDAD-DISTRITAL-DE-CCATCCA-2.png";

                //ruta_imagen = ruta_imagen + ruta_carpeta ;

                //C:\\Users\\ADVANCE\\Source\\Repos\\slnRecursosHumanos\\slnRecursosHumanos\\CapaUsuario\\bin\\Debug
                //C:\\Users\\ADVANCE\\Source\\Repos\\slnRecursosHumanos\\slnRecursosHumanos\\CapaUsuario

                string ruta_imagen = ruta + "\\logo-muni-fw.png";

                string ruta_cuadro_oficinas = ruta + "\\LogoBicentenario2021.jpeg";

                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(ruta_imagen);
                logo.ScalePercent(64f);
                logo.SetAbsolutePosition(12f, pdfDoc.PageSize.Height - 6f - 100f);

                iTextSharp.text.Image oficinas = iTextSharp.text.Image.GetInstance(ruta_cuadro_oficinas);
                oficinas.ScalePercent(64f);
                oficinas.SetAbsolutePosition(pdfDoc.PageSize.Width - 150f, pdfDoc.PageSize.Height - 80f);

                //tabla que continene logo, meta y nº planilla
                PdfPTable tabla_bonus = new PdfPTable(3);
                tabla_bonus.DefaultCell.BorderWidth = 0;

                //tabla que continene rrhh, gerencia municipal, presupuesto y contabilidad
                //tabla que continene rrhh, gerencia municipal, presupuesto y contabilidad
                int NumeroFirmas = 0;
                if (chkFirmaElaborado.Checked) { NumeroFirmas++; }
                if (chkFirmaRecursos.Checked) { NumeroFirmas++; }
                if (chkFirmaGerencia.Checked) { NumeroFirmas++; }
                if (chkFirmaContabilidad.Checked) { NumeroFirmas++; }
                if (chkFirmaTesoreria.Checked) { NumeroFirmas++; }
                if (chkFirmaResidencia.Checked) { NumeroFirmas++; }
                if (chkSubGerenciaObras.Checked) { NumeroFirmas++; }
                if (chkSupervision.Checked) { NumeroFirmas++; }
                if (chkFirmaPresupuesto.Checked) { NumeroFirmas++; }
                if (chkGerenciaAdministracion.Checked) { NumeroFirmas++; }
                PdfPTable tabla_firmas;
                PdfPTable tabla_firmas2;
                PdfPTable tabla_firmas3;

                List<Paragraph> ArregloFirmas = new List<Paragraph>();

                //Se coloca en una sola tabla
                if (NumeroFirmas <= 5)
                {
                    tabla_firmas = new PdfPTable(NumeroFirmas);
                    tabla_firmas.DefaultCell.BorderWidth = 0;
                    tabla_firmas2 = new PdfPTable(1);
                    tabla_firmas3 = new PdfPTable(1);
                    foreach (CheckBox item in this.groupBox2.Controls.OfType<CheckBox>().OrderBy(tb => tb.TabIndex))
                    {
                        if (item.Name != "chkAltoColumna" && item.Checked == true)
                        {
                            Paragraph auxiliar = new Paragraph();
                            auxiliar.Alignment = Element.ALIGN_CENTER;
                            auxiliar.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                            auxiliar.Add(".............................................\n   " + item.Text);
                            tabla_firmas.AddCell(auxiliar);
                        }
                    }
                }
                else
                {
                    // se coloca en 2 tablas
                    if (NumeroFirmas <= 8)
                    {
                        tabla_firmas = new PdfPTable(4);
                        tabla_firmas2 = new PdfPTable(NumeroFirmas - 4);
                        tabla_firmas.DefaultCell.BorderWidth = 0;
                        tabla_firmas2.DefaultCell.BorderWidth = 0;
                        tabla_firmas3 = new PdfPTable(1);

                        int contador = 0;
                        foreach (CheckBox item in this.groupBox2.Controls.OfType<CheckBox>().OrderBy(tb => tb.TabIndex))
                        {

                            if (item.Name != "chkAltoColumna" && item.Checked == true)
                            {
                                contador++;
                                Paragraph auxiliar = new Paragraph();
                                auxiliar.Alignment = Element.ALIGN_CENTER;
                                auxiliar.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                                auxiliar.Add(".............................................\n   " + item.Text);
                                if (contador <= 4)
                                {
                                    tabla_firmas.AddCell(auxiliar);
                                }
                                else
                                {
                                    tabla_firmas2.AddCell(auxiliar);
                                }
                            }
                        }
                    }
                    else
                    {
                        tabla_firmas = new PdfPTable(3);
                        tabla_firmas2 = new PdfPTable(3);
                        tabla_firmas3 = new PdfPTable(NumeroFirmas - 6);
                        tabla_firmas.DefaultCell.BorderWidth = 0;
                        tabla_firmas2.DefaultCell.BorderWidth = 0;
                        tabla_firmas3.DefaultCell.BorderWidth = 0;

                        int contador = 0;
                        foreach (CheckBox item in this.groupBox2.Controls.OfType<CheckBox>().OrderBy(tb => tb.TabIndex))
                        {
                            if (item.Name != "chkAltoColumna" && item.Checked == true)
                            {
                                contador++;
                                Paragraph auxiliar = new Paragraph();
                                auxiliar.Alignment = Element.ALIGN_CENTER;
                                auxiliar.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                                auxiliar.Add(".............................................\n   " + item.Text);
                                if (contador <= 3)
                                {
                                    tabla_firmas.AddCell(auxiliar);
                                }
                                else
                                {
                                    if (contador <= 6)
                                    {
                                        tabla_firmas2.AddCell(auxiliar);
                                    }
                                    else
                                    {
                                        tabla_firmas3.AddCell(auxiliar);
                                    }
                                }
                            }
                        }
                    }

                }

                tabla_bonus.AddCell(pdfTableRedondear);
                PdfPCell celdaVacia = new PdfPCell((new Phrase("", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                celdaVacia.Border = 0;

                tabla_bonus.AddCell(celdaVacia);
                tabla_bonus.AddCell(celdaVacia);

                //instanciando una columna y 3 columnas
                //Columnas 
                MultiColumnText column_one = new MultiColumnText();
                column_one.AddRegularColumns(36f, pdfDoc.PageSize.Width - 36f, 24f, 1);


                MultiColumnText column_3 = new MultiColumnText();
                column_3.AddRegularColumns(36f, pdfDoc.PageSize.Width - 36f, 24f, 4);

                //Agregando una columna 
                column_one.AddElement(paragraph);
                //column_one.AddElement(logo);
                column_one.AddElement(paragraph2);
                column_one.AddElement(paragraph3);
                column_one.AddElement(paragraph4);
                column_one.AddElement(paragraph40);
                column_one.AddElement(pdfTable);
                column_one.AddElement(paragraph5);
                column_one.AddElement(paragraph6);

                //SI LA PLANILLA DE RACIONAMIENTO NO TIENE , NO SE AGREGA
                if (dgvRedondear.RowCount > 1)
                {
                    column_one.AddElement(tabla_bonus);
                }
                
                column_one.AddElement(paragraph5);
                column_one.AddElement(paragraph5);
                column_one.AddElement(paragraph5);
                column_one.AddElement(paragraph5);
                column_one.AddElement(paragraph5);
                column_one.AddElement(tabla_firmas);
                if (NumeroFirmas <= 10)
                {
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(tabla_firmas2);
                }
                if (NumeroFirmas >= 9)
                {
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(tabla_firmas3);
                }
                pdfDoc.Add(logo);
                pdfDoc.Add(oficinas);
                pdfDoc.Add(column_one);
                //pdfDoc.Add(column_dos);
                pdfDoc.Close();
                stream.Close();
            }

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "C:\\PDFs\\Planilla.pdf";
            proc.Start();

        }

        private void exportar_a_pdf_CTS(int numeroRegimenLaboral)
        {
            //Creating iTextSharp Table from the DataTable data
            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 7);
            iTextSharp.text.Font fuenteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 9, 1, iTextSharp.text.Color.BLUE);

            PdfPTable pdfTable = new PdfPTable(dgvPrueba.ColumnCount);



            Phrase objP = new Phrase("A", fuente);
            Phrase objP2 = new Phrase("A", fuente);
            Phrase objP3 = new Phrase("A", fuente);
            //Phrase objH = new Phrase("A", fuenteTitulo);
            PdfPCell cell;
            PdfPCell cell2;
            PdfPCell cell3;
            PdfPCell cell4;

            pdfTable.DefaultCell.Padding = 1;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            //pdfTable.DefaultCell.FixedHeight = 600f;

            float[] headerwidths = GetTamañoColumnas(dgvPrueba);
            float[] headerwidths2 = GetTamañoColumnas2(dgvAFP);
            float[] headerwidths3 = GetTamañoColumnas2(dgvRedondear);
            float[] headerwidths4 = GetTamañoColumnas2(dgvEEFF);
            //float[] headerwidths = { 2f, 6f, 6f, 3f, 5f, 8f, 5f, 5f, 5f, 5f };

            //cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#d1dbe0"));

            pdfTable.SetWidths(headerwidths);
            pdfTable.WidthPercentage = 100;

            int iindice_nombre = 0;
            int iindice_cargo = 0;
            int iindice_fecha = 0;
            int iindice_afi_com_cus = 0;

            //Adding Header row
            foreach (DataGridViewColumn column in dgvPrueba.Columns)
            {
                cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                //cell = new PdfPCell(new Phrase(column.HeaderText));
                //PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                // objH = new Phrase(column.HeaderText, fuenteTitulo);
                pdfTable.AddCell(cell);
            }

            /*Indices de la secciones alineadas*/
            iindice_nombre = BuscarIndiceColumna(odtPrueba, "NOMBRE COMPLETO");
            iindice_cargo = BuscarIndiceColumna(odtPrueba, "CARGO");
            iindice_fecha = BuscarIndiceColumna(odtPrueba, "FECHA INICIO");
            iindice_afi_com_cus = BuscarIndiceColumna(odtPrueba, "AFIL. AFP/SNP \n\n COMISION \n\n CUSP ");

            for (int i = 0; i < dgvPrueba.RowCount - 1; i++)
            {
                for (int j = 0; j < dgvPrueba.ColumnCount; j++)
                {
                    //objP = new Phrase(dgvPrueba[j, i].Value.ToString(), fuente);

                    cell = new PdfPCell((new Phrase(dgvPrueba[j, i].Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                    if (columnasFijas)
                    {
                        cell.FixedHeight = altoColumna;
                    }

                    //Alineando a la derecha la columna nº
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;

                    if (j == iindice_nombre || j == iindice_cargo || j == iindice_fecha || j == iindice_afi_com_cus)
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;

                    pdfTable.AddCell(cell);
                }
                pdfTable.CompleteRow();
            }





            /*----------------fin dgvEEFF*/

            //Exporting to PDF
            string folderPath = "C:\\PDFs\\";

            //use a variable to let my code fit across the page...
            //string path = Server.MapPath("PDFs");
            //PdfWriter.GetInstance(doc1, new FileStream(path + "/Doc1.pdf", FileMode.Create));

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "Planilla.pdf", FileMode.Create))
            {

                Document pdfDoc = new Document(PageSize.A4, 9, 9, 40, 30);
                pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());



                Paragraph paragraph = new Paragraph();
                paragraph.Alignment = Element.ALIGN_CENTER;
                paragraph.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 12);

                paragraph.Add(oDatosGenerales.Nombre + " \n " + oDatosGenerales.NombreOficina + " \n ");

                Paragraph paragraph2 = new Paragraph();
                paragraph2.Alignment = Element.ALIGN_RIGHT;
                paragraph2.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                paragraph2.Add("PLANILLA Nº " + sNumeroPlanilla + " - " + saño + " \n ");

                Paragraph paragraph3 = new Paragraph();
                paragraph3.Alignment = Element.ALIGN_CENTER;
                paragraph3.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                /*paragraph3.Add("PLANILLA DE RENUMERACIONES DEL PERSONAL DE " + sRegimenLaboral + " DE " + saño + " DE " + smes + ".");*/
                /*Titulo de planilla */
                paragraph3.Add(sdescripcion.ToString().ToUpper() + " DE " + smes + " DE " + saño + ".");

                Paragraph paragraph4 = new Paragraph();
                paragraph4.Alignment = Element.ALIGN_LEFT;
                paragraph4.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                paragraph4.IndentationLeft = 110f;

                string smeta_numero_con_ceros = string.Format("{0:000}", smeta_numero);

                paragraph4.Add("META:" + smeta_numero.PadLeft(3, '0') + " - " + smeta + ". \n\n");

                Paragraph paragraph40 = new Paragraph();
                paragraph40.Alignment = Element.ALIGN_LEFT;
                paragraph40.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                paragraph40.IndentationLeft = 110f;
                paragraph4.Add("FUENTE FINANCIAMIENTO:" + sfuentefinanciamiento + ". \n\n");

                Paragraph paragraph5 = new Paragraph();
                paragraph5.Alignment = Element.ALIGN_CENTER;
                paragraph5.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                paragraph5.Add("\n");

                DateTime fecha = DateTime.Now;

                Paragraph paragraph6 = new Paragraph();
                paragraph6.Alignment = Element.ALIGN_CENTER;
                paragraph6.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);

                CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

                fecha = Convert.ToDateTime(oPlanilla.ListarFechaPlanilla(sidtplanilla).Rows[0][1].ToString());

                paragraph6.Add(oDatosGenerales.Lugar + ", " + String.Format("{0:dd}", fecha) + " DE " + String.Format("{0:MMMM}", fecha).ToUpper() + " DEL " + String.Format("{0:yyyy}", fecha) + ". \n");
                /*FEcha de hoy*/
                //paragraph6.Add("CCATCCA, " + String.Format("{0:dd}" , fecha) + " DE " + String.Format("{0:MMMM}", fecha).ToUpper() + " DEL " + String.Format("{0:yyyy}", fecha) + ". \n");




                PdfWriter.GetInstance(pdfDoc, stream);
                CreateHeaderFooter(ref pdfDoc);
                pdfDoc.Open();

                //string imageURL = "C:\\Users\\ADVANCE\\Source\\Repos\\slnRecursosHumanos\\slnRecursosHumanos\\Recursos Varios\\MUNICIPALIDAD-DISTRITAL-DE-CCATCCA-2.png";
                //string ruta = Directory.GetCurrentDirectory();
                string ruta = System.IO.Directory.GetCurrentDirectory();
                //string ruta2 = Application.StartupPath;
                //string ruta3 = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

                //string[] palabras = ruta.Split('\\');

                //string ruta_imagen = palabras[0] + '\\' + palabras[1] + '\\' + palabras[2] + '\\' +
                //palabras[3] + '\\' + palabras[4] + '\\' + palabras[5] + '\\' + palabras[6] + '\\';

                //string ruta_carpeta = "Recursos Varios\\MUNICIPALIDAD-DISTRITAL-DE-CCATCCA-2.png";

                //ruta_imagen = ruta_imagen + ruta_carpeta ;

                //C:\\Users\\ADVANCE\\Source\\Repos\\slnRecursosHumanos\\slnRecursosHumanos\\CapaUsuario\\bin\\Debug
                //C:\\Users\\ADVANCE\\Source\\Repos\\slnRecursosHumanos\\slnRecursosHumanos\\CapaUsuario

                string ruta_imagen = ruta + "\\logo-muni-fw.png";

                string ruta_cuadro_oficinas = ruta + "\\LogoBicentenario2021.jpeg";

                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(ruta_imagen);
                logo.ScalePercent(64f);
                logo.SetAbsolutePosition(12f, pdfDoc.PageSize.Height - 6f - 100f);

                iTextSharp.text.Image oficinas = iTextSharp.text.Image.GetInstance(ruta_cuadro_oficinas);
                oficinas.ScalePercent(64f);
                oficinas.SetAbsolutePosition(pdfDoc.PageSize.Width - 150f, pdfDoc.PageSize.Height - 80f);

                //tabla que continene logo, meta y nº planilla
                PdfPTable tabla_bonus = new PdfPTable(3);
                tabla_bonus.DefaultCell.BorderWidth = 0;

                //tabla que continene rrhh, gerencia municipal, presupuesto y contabilidad
                //tabla que continene rrhh, gerencia municipal, presupuesto y contabilidad
                int NumeroFirmas = 0;
                if (chkFirmaElaborado.Checked) { NumeroFirmas++; }
                if (chkFirmaRecursos.Checked) { NumeroFirmas++; }
                if (chkFirmaGerencia.Checked) { NumeroFirmas++; }
                if (chkFirmaContabilidad.Checked) { NumeroFirmas++; }
                if (chkFirmaTesoreria.Checked) { NumeroFirmas++; }
                if (chkFirmaResidencia.Checked) { NumeroFirmas++; }
                if (chkSubGerenciaObras.Checked) { NumeroFirmas++; }
                if (chkSupervision.Checked) { NumeroFirmas++; }
                if (chkFirmaPresupuesto.Checked) { NumeroFirmas++; }
                if (chkGerenciaAdministracion.Checked) { NumeroFirmas++; }
                PdfPTable tabla_firmas;
                PdfPTable tabla_firmas2;
                PdfPTable tabla_firmas3;

                List<Paragraph> ArregloFirmas = new List<Paragraph>();

                //Se coloca en una sola tabla
                if (NumeroFirmas <= 5)
                {
                    tabla_firmas = new PdfPTable(NumeroFirmas);
                    tabla_firmas.DefaultCell.BorderWidth = 0;
                    tabla_firmas2 = new PdfPTable(1);
                    tabla_firmas3 = new PdfPTable(1);
                    foreach (CheckBox item in this.groupBox2.Controls.OfType<CheckBox>().OrderBy(tb => tb.TabIndex))
                    {
                        if (item.Name != "chkAltoColumna" && item.Checked == true)
                        {
                            Paragraph auxiliar = new Paragraph();
                            auxiliar.Alignment = Element.ALIGN_CENTER;
                            auxiliar.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                            auxiliar.Add(".............................................\n   " + item.Text);
                            tabla_firmas.AddCell(auxiliar);
                        }
                    }
                }
                else
                {
                    // se coloca en 2 tablas
                    if (NumeroFirmas <= 8)
                    {
                        tabla_firmas = new PdfPTable(4);
                        tabla_firmas2 = new PdfPTable(NumeroFirmas - 4);
                        tabla_firmas.DefaultCell.BorderWidth = 0;
                        tabla_firmas2.DefaultCell.BorderWidth = 0;
                        tabla_firmas3 = new PdfPTable(1);

                        int contador = 0;
                        foreach (CheckBox item in this.groupBox2.Controls.OfType<CheckBox>().OrderBy(tb => tb.TabIndex))
                        {

                            if (item.Name != "chkAltoColumna" && item.Checked == true)
                            {
                                contador++;
                                Paragraph auxiliar = new Paragraph();
                                auxiliar.Alignment = Element.ALIGN_CENTER;
                                auxiliar.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                                auxiliar.Add(".............................................\n   " + item.Text);
                                if (contador <= 4)
                                {
                                    tabla_firmas.AddCell(auxiliar);
                                }
                                else
                                {
                                    tabla_firmas2.AddCell(auxiliar);
                                }
                            }
                        }
                    }
                    else
                    {
                        tabla_firmas = new PdfPTable(3);
                        tabla_firmas2 = new PdfPTable(3);
                        tabla_firmas3 = new PdfPTable(NumeroFirmas - 6);
                        tabla_firmas.DefaultCell.BorderWidth = 0;
                        tabla_firmas2.DefaultCell.BorderWidth = 0;
                        tabla_firmas3.DefaultCell.BorderWidth = 0;

                        int contador = 0;
                        foreach (CheckBox item in this.groupBox2.Controls.OfType<CheckBox>().OrderBy(tb => tb.TabIndex))
                        {
                            if (item.Name != "chkAltoColumna" && item.Checked == true)
                            {
                                contador++;
                                Paragraph auxiliar = new Paragraph();
                                auxiliar.Alignment = Element.ALIGN_CENTER;
                                auxiliar.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
                                auxiliar.Add(".............................................\n   " + item.Text);
                                if (contador <= 3)
                                {
                                    tabla_firmas.AddCell(auxiliar);
                                }
                                else
                                {
                                    if (contador <= 6)
                                    {
                                        tabla_firmas2.AddCell(auxiliar);
                                    }
                                    else
                                    {
                                        tabla_firmas3.AddCell(auxiliar);
                                    }
                                }
                            }
                        }
                    }

                }

                //instanciando una columna y 3 columnas
                //Columnas 
                MultiColumnText column_one = new MultiColumnText();
                column_one.AddRegularColumns(36f, pdfDoc.PageSize.Width - 36f, 24f, 1);


                MultiColumnText column_3 = new MultiColumnText();
                column_3.AddRegularColumns(36f, pdfDoc.PageSize.Width - 36f, 24f, 4);

                //Agregando una columna 
                column_one.AddElement(paragraph);
                //column_one.AddElement(logo);
                column_one.AddElement(paragraph2);
                column_one.AddElement(paragraph3);
                column_one.AddElement(paragraph4);
                column_one.AddElement(paragraph40);
                column_one.AddElement(pdfTable);
                column_one.AddElement(paragraph5);
                column_one.AddElement(paragraph6);
                column_one.AddElement(tabla_bonus);
                column_one.AddElement(paragraph5);
                column_one.AddElement(paragraph5);
                column_one.AddElement(paragraph5);
                column_one.AddElement(paragraph5);
                column_one.AddElement(paragraph5);
                column_one.AddElement(tabla_firmas);
                if (NumeroFirmas <= 10)
                {
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(tabla_firmas2);
                }
                if (NumeroFirmas >= 9)
                {
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(paragraph5);
                    column_one.AddElement(tabla_firmas3);
                }
                pdfDoc.Add(logo);
                pdfDoc.Add(oficinas);
                pdfDoc.Add(column_one);
                //pdfDoc.Add(column_dos);
                pdfDoc.Close();
                stream.Close();
            }

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "C:\\PDFs\\Planilla.pdf";
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
                smeta_numero = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[8].Value);
                sidtfuentefinanciamiento = Convert.ToInt32(dgvPlanilla.Rows[e.RowIndex].Cells[9].Value);
                sfuentefinanciamiento = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[10].Value);
                sidtregimenlaboral = Convert.ToInt32(dgvPlanilla.Rows[e.RowIndex].Cells[11].Value);
                splantilla = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[12].Value);

                sNumeroPlanilla = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[1].Value);
                DataTable odtPrueba = new DataTable();
                odtPrueba = oPlanilla.ListarRegimenLaboralPlanilla(sNumeroPlanilla);
                foreach (DataRow row in odtPrueba.Rows)
                    sRegimenLaboral = row[0].ToString();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

            pmes = cboMes.GetItemText(this.cboMes.SelectedItem); ;
            paño = cboAño.GetItemText(this.cboAño.SelectedItem); ;

            switch (pmes)
            {
                case "ENERO": pmes_nro = "1"; break;
                case "FEBRERO": pmes_nro = "2"; break;
                case "MARZO": pmes_nro = "3"; break;
                case "ABRIL": pmes_nro = "4"; break;
                case "MAYO": pmes_nro = "5"; break;
                case "JUNIO": pmes_nro = "6"; break;
                case "JULIO": pmes_nro = "7"; break;
                case "AGOSTO": pmes_nro = "8"; break;
                case "SETIEMBRE": pmes_nro = "9"; break;
                case "OCTUBRE": pmes_nro = "10"; break;
                case "NOVIEMBRE": pmes_nro = "11"; break;
                case "DICIEMBRE": pmes_nro = "12"; break;
            }

            //Llenar data table BoletaPago verificando que tenga mas de un registro
            
            int numero_boleta_pago = dgvPlanilla.Rows.Count;
 
            CargarDatos();

            if (dgvPlanilla.Rows.Count > 0) {
                dgvPlanilla.Rows[0].Selected = true;

                sidtplanilla = Convert.ToInt32(dgvPlanilla.Rows[0].Cells[0].Value);
                snumero = Convert.ToString(dgvPlanilla.Rows[0].Cells[1].Value);
                sdescripcion = Convert.ToString(dgvPlanilla.Rows[0].Cells[2].Value);
                smes = Convert.ToString(dgvPlanilla.Rows[0].Cells[3].Value);
                saño = Convert.ToString(dgvPlanilla.Rows[0].Cells[4].Value);
                sfecha = Convert.ToDateTime(dgvPlanilla.Rows[0].Cells[5].Value);
                sidtmeta = Convert.ToInt32(dgvPlanilla.Rows[0].Cells[6].Value);
                smeta = Convert.ToString(dgvPlanilla.Rows[0].Cells[7].Value);
                smeta_numero = Convert.ToString(dgvPlanilla.Rows[0].Cells[8].Value);
                sidtfuentefinanciamiento = Convert.ToInt32(dgvPlanilla.Rows[0].Cells[9].Value);
                sfuentefinanciamiento = Convert.ToString(dgvPlanilla.Rows[0].Cells[10].Value);
                sidtregimenlaboral = Convert.ToInt32(dgvPlanilla.Rows[0].Cells[11].Value);
                splantilla = Convert.ToString(dgvPlanilla.Rows[0].Cells[12].Value);

                sNumeroPlanilla = Convert.ToString(dgvPlanilla.Rows[0].Cells[1].Value);
                DataTable odtPrueba = new DataTable();

                odtPrueba = oPlanilla.ListarRegimenLaboralPlanilla(sNumeroPlanilla);
                foreach (DataRow row in odtPrueba.Rows)
                    sRegimenLaboral = row[0].ToString();
            }
        }

        private void txtAltoColumnas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void chkAltoColumna_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAltoColumna.Checked)
            {
                txtAltoColumnas.Visible = true;
                columnasFijas = true;
            }
            else
            {
                txtAltoColumnas.Visible = false;
                columnasFijas = false;
            }
        }

        private void txtAltoColumnas_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
