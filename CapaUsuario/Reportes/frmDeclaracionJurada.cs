﻿using System;
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
        string folderPath = "C:\\PDFs\\";
        PdfPCell cell;
        DataTable odtTrabajadores = new DataTable();
        DataTable odtDeclaracion = new DataTable();
        int c = 0;

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
            DataTable odtTrabajadoresDeclaracionJurada = new DataTable();
            DataGridViewCheckBoxColumn dgvcbc = new DataGridViewCheckBoxColumn();
            
            paño = cboAño.GetItemText(this.cboAño.SelectedItem);
            
            odtTrabajadoresDeclaracionJurada = oTrabajador.ListarTrabajadoresParaDeclaracionJurada(paño);

            for (int i = 0; i < odtTrabajadoresDeclaracionJurada.Rows.Count ; i++) {
                odtTrabajadoresDeclaracionJurada.Rows[i][0] = i + 1;
            }
            
            dgvDeclaracionJurada.Columns.Clear();
            dgvDeclaracionJurada.DataSource = odtTrabajadoresDeclaracionJurada;
            dgvDeclaracionJurada.Columns[1].Visible = true;
            dgvDeclaracionJurada.Columns[7].Visible = false;
 
            dgvcbc.HeaderText = "Seleccionar";
            dgvcbc.Width = 70;
            dgvcbc.Name = "cbc";
            
            dgvDeclaracionJurada.Columns.Insert(0, dgvcbc);
            dgvDeclaracionJurada.Columns["cbc"].DisplayIndex = 0;
            dgvDeclaracionJurada.Columns["cbc"].ReadOnly = false;
            dgvDeclaracionJurada.ReadOnly = false;

            dgvDeclaracionJurada.Columns[0].Width = 30;
            dgvDeclaracionJurada.Columns[1].Width = 250;

            dgvDeclaracionJurada.Columns[1].ReadOnly = true;
            dgvDeclaracionJurada.Columns[2].ReadOnly = true;

            dgvDeclaracionJurada.Columns[2].Visible = false;
            //dgvDeclaracionJurada.Columns.Add(dgvcbc);

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
            DataTable odtAlcalde = new DataTable();
            DataRow odrCabeza = odtCabeza.NewRow();
            string alcalde = "";
            int c = 0;
            FileInfo file = new FileInfo("C:\\PDFs\\DeclaracionJurada.pdf");
            bool estaAbierto = IsFileinUse(file, "C:\\PDFs\\DeclaracionJurada.pdf");
            CapaDeNegocios.Trabajadores.cTrabajadorCas oTrabajador = new CapaDeNegocios.Trabajadores.cTrabajadorCas();

            DataRow odrTrabajadores = odtTrabajadores.NewRow();
             
            /*Inicio de formato de declaracion jurada de nombramientos a contraloria */
            /*Cuadro 1 :*/
            odtAlcalde = oTrabajador.ListarAlcalde();

            odtCabeza.Columns.Clear();
            odtCabeza.Rows.Clear();

            odtCabeza.Columns.Add("DATOS GENERAL DE LA ENTIDAD", typeof(string));
            odtCabeza.Columns.Add(" ", typeof(string));

            odrCabeza = odtCabeza.NewRow();
            odrCabeza[0] = "ENTIDAD:";
            odrCabeza[1] = "MUNICIPALIDAD DISTRITAL DE CCATCCA";
            odtCabeza.Rows.InsertAt(odrCabeza, 0);

            odrCabeza = odtCabeza.NewRow();
            odrCabeza[0] = "DIRECCION:";
            odrCabeza[1] = "PLAZA DE ARMAS S/N DISTRITO DE CCATCCA";
            odtCabeza.Rows.InsertAt(odrCabeza, 1);

            if (odtAlcalde.Rows.Count > 0)
                alcalde = odtAlcalde.Rows[0][0].ToString();

            odrCabeza = odtCabeza.NewRow();
            odrCabeza[0] = "NOMBRE DEL TITULAR DEL PLIEGO PRESUPUESTAL";
            odrCabeza[1] = alcalde ;
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
            odtTrabajadores.Columns.Clear();
            odtTrabajadores.Rows.Clear();

            odtTrabajadores.Columns.Add("Trabajador",typeof(string));

            /* Escribiendo titulos pàra odtDeclaracion  */
            odtDeclaracion.Rows.Clear();
            odtDeclaracion.Columns.Clear();

            odtDeclaracion.Columns.Add("N°");
            odtDeclaracion.Columns.Add("NOMBRES Y APELLIDOS DEL OBLIGADO");
            odtDeclaracion.Columns.Add("DNI");
            odtDeclaracion.Columns.Add("CONDICION LABORAL -NOMBRADO(N) (INDICAR N° DE RESOLUCION) - CONTRATADO (C) (INDICAR TIPO O MODALIDAD)");
            odtDeclaracion.Columns.Add("CARGO FUNCION O LABOR");
            odtDeclaracion.Columns.Add("INGRESO MENSUAL");
            odtDeclaracion.Columns.Add("FECHA EN QUE ASUME dd/mm/aaaa");

            /* Leyendo datagridviewcheckbox que esten en check */
            foreach (DataGridViewRow row in dgvDeclaracionJurada.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["cbc"].Value);
                if (isSelected)
                {
                    //odtTrabajador.Rows[k][0] = dgvDeclaracionJurada.Rows[k].Cells[1] ;
                    odrTrabajadores = odtTrabajadores.NewRow();
                    odrTrabajadores[0] = row.Cells["ID TRABAJADOR"].Value.ToString();
                    odtTrabajadores.Rows.InsertAt(odrTrabajadores, c);
                }
                c++;
            }

            c = 0;

            if (dgvDeclaracionJurada.Rows.Count > 0) { 
                if (!estaAbierto) exportar_a_pdf();
                else MessageBox.Show("Cerrar porfavor DeclaracionJurada.pdf", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Cuadro de Declaraciónes Jurada vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void cargar_cuerpo_declaracion(){

            DataTable odtDeclaracionJurada = new DataTable();
            DataTable odt2039 = new DataTable();
            DataTable odt_121 = new DataTable();
            DataTable odt_122 = new DataTable();
            DataTable odt_2039 = new DataTable();
            DataTable odt_0401 = new DataTable();
            DataTable odt_0402 = new DataTable();
            DataTable odt_0403 = new DataTable();
            DataTable odt_0404 = new DataTable();
            DataTable odt_0405 = new DataTable();
            DataTable odt_0406 = new DataTable();
            DataTable odt_0407 = new DataTable();
            CapaDeNegocios.Trabajadores.cTrabajadorCas oTrabajador = new CapaDeNegocios.Trabajadores.cTrabajadorCas();
            CapaDeNegocios.Sunat.cMaestroIngresos oMaestroIngresos = new CapaDeNegocios.Sunat.cMaestroIngresos();


            DataRow odrDeclaracion = odtDeclaracion.NewRow();

            int indice_2039 = 0;
            int indice_121 = 0;
            int indice_122 = 0;
            int indice_0401 = 0;
            int indice_0402 = 0;
            int indice_0403 = 0;
            int indice_0404 = 0;
            int indice_0405 = 0;
            int indice_0406 = 0;
            int indice_0407 = 0;
            int k = 0;

            string monto_2039 = "";
            string monto_121 = "";
            string monto_122 = "";
            string monto_0401 = "";
            string monto_0402 = "";
            string monto_0403 = "";
            string monto_0404 = "";
            string monto_0405 = "";
            string monto_0406 = "";
            string monto_0407 = "";
            string nombre_columna = "";

            /*llenando odtDeclaracion con Declaracion juradada de nombramiento a contraloria */
            odrDeclaracion = odtDeclaracion.NewRow();
 
            odtDeclaracionJurada = oTrabajador.ListarDeclaracionJuradaNombramientoContraloria(id_trabajador, Convert.ToInt32(paño));
            odrDeclaracion[0] = c+1;
            odrDeclaracion[1] = odtDeclaracionJurada.Rows[0][1];
            odrDeclaracion[2] = odtDeclaracionJurada.Rows[0][2];
            odrDeclaracion[3] = odtDeclaracionJurada.Rows[0][3];
            odrDeclaracion[4] = odtDeclaracionJurada.Rows[0][4];
            odrDeclaracion[5] = odtDeclaracionJurada.Rows[0][5];
            odrDeclaracion[6] = odtDeclaracionJurada.Rows[0][6];

            odtDeclaracion.Rows.InsertAt(odrDeclaracion,c);

            if (odtDeclaracionJurada.Rows.Count > 0)
            {

                odt2039 = oTrabajador.ListarDeclaracionJNC(id_trabajador, Convert.ToInt32(paño), "2039");

                if (odt2039.Rows.Count > 0)
                {
                    nombre_columna = oMaestroIngresos.ListarAbreviacionDeIdtmaestroingresos(174).Rows[0][1].ToString();
                    indice_2039 = BuscarIndiceColumna(odtDeclaracion, nombre_columna);
                    monto_2039 = odt2039.Rows[0][4].ToString();
                    if (monto_2039 != "" && indice_2039 != -1)
                    {
                        odtDeclaracion.Rows[c][indice_2039] = monto_2039;
                    }
                }

                odt_121 = oTrabajador.ListarDeclaracionJNC(id_trabajador, Convert.ToInt32(paño), "121");

                if (odt_121.Rows.Count > 0)
                {
                    nombre_columna = oMaestroIngresos.ListarAbreviacionDeIdtmaestroingresos(47).Rows[0][1].ToString();
                    indice_121 = BuscarIndiceColumna(odtDeclaracion, nombre_columna);
                    monto_121 = odt_121.Rows[0][4].ToString();
                    if (monto_121 != "" && indice_121 != -1)
                    {
                        odtDeclaracion.Rows[c][indice_121] = monto_121;
                    }
                }

                odt_122 = oTrabajador.ListarDeclaracionJNC(id_trabajador, Convert.ToInt32(paño), "122");

                if (odt_122.Rows.Count > 0)
                {
                    nombre_columna = oMaestroIngresos.ListarAbreviacionDeIdtmaestroingresos(48).Rows[0][1].ToString();
                    indice_122 = BuscarIndiceColumna(odtDeclaracion, nombre_columna);
                    monto_122 = odt_122.Rows[0][4].ToString();
                    if (monto_122 != "" && indice_122 != -1)
                    {
                        odtDeclaracion.Rows[c][indice_122] = monto_122;
                    }
                }

                odt_0401 = oTrabajador.ListarDeclaracionJNC(id_trabajador, Convert.ToInt32(paño), "0401");

                if (odt_0401.Rows.Count > 0)
                {
                    nombre_columna = oMaestroIngresos.ListarAbreviacionDeIdtmaestroingresos(77).Rows[0][1].ToString();
                    indice_0401 = BuscarIndiceColumna(odtDeclaracion, nombre_columna);
                    monto_0401 = odt_0401.Rows[0][4].ToString();
                    if (monto_0401 != "" && indice_0401 != -1)
                    {
                        odtDeclaracion.Rows[c][indice_0401] = monto_0401;
                    }
                }

                odt_0402 = oTrabajador.ListarDeclaracionJNC(id_trabajador, Convert.ToInt32(paño), "0402");

                if (odt_0402.Rows.Count > 0)
                {
                    nombre_columna = oMaestroIngresos.ListarAbreviacionDeIdtmaestroingresos(78).Rows[0][1].ToString();
                    indice_0402 = BuscarIndiceColumna(odtDeclaracion, nombre_columna);
                    monto_0402 = odt_0402.Rows[0][4].ToString();
                    if (monto_0402 != "" && indice_0402 != -1)
                    {
                        odtDeclaracion.Rows[c][indice_0402] = monto_0402;
                    }
                }

                odt_0403 = oTrabajador.ListarDeclaracionJNC(id_trabajador, Convert.ToInt32(paño), "0403");

                if (odt_0403.Rows.Count > 0)
                {
                    nombre_columna = oMaestroIngresos.ListarAbreviacionDeIdtmaestroingresos(79).Rows[0][1].ToString();
                    indice_0403 = BuscarIndiceColumna(odtDeclaracion, nombre_columna);
                    monto_0403 = odt_0403.Rows[0][4].ToString();
                    if (monto_0403 != "" && indice_0403 != -1)
                    {
                        odtDeclaracion.Rows[c][indice_0403] = monto_0403;
                    }
                }

                odt_0404 = oTrabajador.ListarDeclaracionJNC(id_trabajador, Convert.ToInt32(paño), "0404");

                if (odt_0404.Rows.Count > 0)
                {
                    nombre_columna = oMaestroIngresos.ListarAbreviacionDeIdtmaestroingresos(80).Rows[0][1].ToString();
                    indice_0404 = BuscarIndiceColumna(odtDeclaracion, nombre_columna);
                    monto_0404 = odt_0404.Rows[0][4].ToString();
                    if (monto_0404 != "" && indice_0404 != -1)
                    {
                        odtDeclaracion.Rows[c][indice_0404] = monto_0404;
                    }
                }

                odt_0405 = oTrabajador.ListarDeclaracionJNC(id_trabajador, Convert.ToInt32(paño), "0405");

                if (odt_0405.Rows.Count > 0)
                {
                    nombre_columna = oMaestroIngresos.ListarAbreviacionDeIdtmaestroingresos(81).Rows[0][1].ToString();
                    indice_0405 = BuscarIndiceColumna(odtDeclaracion, nombre_columna);
                    monto_0405 = odt_0405.Rows[0][4].ToString();
                    if (monto_0405 != "" && indice_0405 != -1)
                    {
                        odtDeclaracion.Rows[c][indice_0405] = monto_0405;
                    }
                }

                odt_0406 = oTrabajador.ListarDeclaracionJNC(id_trabajador, Convert.ToInt32(paño), "0406");

                if (odt_0406.Rows.Count > 0)
                {
                    nombre_columna = oMaestroIngresos.ListarAbreviacionDeIdtmaestroingresos(82).Rows[0][1].ToString();
                    indice_0406 = BuscarIndiceColumna(odtDeclaracion, nombre_columna);
                    monto_0406 = odt_0406.Rows[0][4].ToString();
                    if (monto_0406 != "" && indice_0406 != -1)
                    {
                        odtDeclaracion.Rows[c][indice_0406] = monto_0406;
                    }
                }

                odt_0407 = oTrabajador.ListarDeclaracionJNC(id_trabajador, Convert.ToInt32(paño), "0407");

                if (odt_0407.Rows.Count > 0)
                {
                    nombre_columna = oMaestroIngresos.ListarAbreviacionDeIdtmaestroingresos(83).Rows[0][1].ToString();
                    indice_0407 = BuscarIndiceColumna(odtDeclaracion, nombre_columna);
                    monto_0407 = odt_0407.Rows[0][4].ToString();
                    if (monto_0407 != "" && indice_0406 != -1)
                    {
                        odtDeclaracion.Rows[c][indice_0407] = monto_0407;
                    }
                }

                c++;
                /*Fin cuadro 2*/
                /*Fin de formato de declaracion jurada de nombramientos a contraloria */
            }
            else
                MessageBox.Show("No se han seleccionado trabajadores.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void exportar_a_pdf()
        {
            if (odtTrabajadores.Rows.Count > 0)
            {

                Paragraph paragraph = new Paragraph();
 
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
  
                // Add a new page to the pdf file
                //pdfDoc.NewPage();
                Document pdfDoc = new Document(PageSize.A4, 9, 9, 10, 10);
                pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4);

                paragraph.Alignment = Element.ALIGN_CENTER;
                paragraph.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 8);
                paragraph.Add(" ");
 


                FileStream fs = new FileStream(folderPath + "DeclaracionJurada.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fs);
                CreateHeaderFooter(ref pdfDoc);
                //Abrir pagina
                pdfDoc.Open();

            
                //Total de filas en dgvBoletaPago_A, si es mayor a 0 procede a reporte
                //instanciando pdfTable A , B , C , D , E
                PdfPTable pdfTableCabeza = new PdfPTable(dgvCabeza.ColumnCount);
            

                //Nueva pagina
                pdfDoc.NewPage();

                //obtener pdfTableA,B,C,D,E 
                pdfTableCabeza = pdf_cabeza(0, 100);

                //Columnas 
                MultiColumnText columns = new MultiColumnText();
                columns.AddRegularColumns(36f, pdfDoc.PageSize.Width - 36f, 24f, 1);
            
                //Agregando pdfTable A, B, C, D, E a pdfDoc
                columns.AddElement(pdfTableCabeza);
                columns.AddElement(paragraph);

            
                for (int i = 0; i < odtTrabajadores.Rows.Count; i++)
                {
                    /* Primero, Hallar todas las columnas de declaracion jurada de nombramientos a contraloria */
                    id_trabajador = Convert.ToInt32(odtTrabajadores.Rows[i][0]);
                    hallar_columnas();
                }

                //dgvCuerpo.DataSource = odtDeclaracion;
                c = 0;
                for (int i = 0; i < odtTrabajadores.Rows.Count; i++)
                {
                    /* Llenar datos segun las columnas halladas en declaracion jurada de nombramientos a contraloria */
                    id_trabajador = Convert.ToInt32(odtTrabajadores.Rows[i][0]);
                    cargar_cuerpo_declaracion();
                }

                dgvCuerpo.DataSource = odtDeclaracion;

                PdfPTable pdfTableCuerpo = new PdfPTable(dgvCuerpo.ColumnCount);

                pdfTableCuerpo = pdf_cuerpo(0, 100);
                columns.AddElement(pdfTableCuerpo);

                pdfDoc.Add(columns);
                pdfDoc.Close();

                writer.Close();
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "C:\\PDFs\\DeclaracionJurada.pdf";
                proc.Start();
            }
            else
                MessageBox.Show("No hay trabajadores seleccionados.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            

            
             

        }

        public void hallar_columnas() {
            /*hallar columnas*/

            DataTable odtDeclaracionJurada = new DataTable();
            DataTable odt2039 = new DataTable();
            DataTable odt_121 = new DataTable();
            DataTable odt_122 = new DataTable();
            DataTable odt_2039 = new DataTable();
            DataTable odt_0401 = new DataTable();
            DataTable odt_0402 = new DataTable();
            DataTable odt_0403 = new DataTable();
            DataTable odt_0404 = new DataTable();
            DataTable odt_0405 = new DataTable();
            DataTable odt_0406 = new DataTable();
            DataTable odt_0407 = new DataTable();
            CapaDeNegocios.Trabajadores.cTrabajadorCas oTrabajador = new CapaDeNegocios.Trabajadores.cTrabajadorCas();
            CapaDeNegocios.Sunat.cMaestroIngresos oMaestroIngresos = new CapaDeNegocios.Sunat.cMaestroIngresos();
            //DataRow odrTrabajador = odtrTrabajador.NewRow();

            int indice_2039 = 0;
            int indice_121 = 0;
            int indice_122 = 0;
            int indice_0401 = 0;
            int indice_0402 = 0;
            int indice_0403 = 0;
            int indice_0404 = 0;
            int indice_0405 = 0;
            int indice_0406 = 0;
            int indice_0407 = 0;
            string nombre_columna = "";
            string abreviacion_ingreso = "";
            decimal monto_ingreso = 0;

            odt2039 = oTrabajador.ListarDeclaracionJNC(id_trabajador, Convert.ToInt32(paño), "2039");

            if (odt2039.Rows.Count > 0)
            {
                nombre_columna = oMaestroIngresos.ListarAbreviacionDeIdtmaestroingresos(174).Rows[0][1].ToString();
                indice_2039 = BuscarIndiceColumna(odtDeclaracion, nombre_columna);
                abreviacion_ingreso = odt2039.Rows[0][3].ToString();
                //monto_ingreso =  Convert.ToDecimal(odt2039.Rows[0][4]) ;
                if (indice_2039 == -1 && odt2039.Rows[0][4] != DBNull.Value )
                    odtDeclaracion.Columns.Add( abreviacion_ingreso , typeof(string));
            }

            odt_121 = oTrabajador.ListarDeclaracionJNC(id_trabajador, Convert.ToInt32(paño), "121");

            if (odt_121.Rows.Count > 0)
            {
                nombre_columna = oMaestroIngresos.ListarAbreviacionDeIdtmaestroingresos(47).Rows[0][1].ToString();
                indice_121 = BuscarIndiceColumna(odtDeclaracion, nombre_columna);
                abreviacion_ingreso = odt_121.Rows[0][3].ToString();
                //monto_ingreso = Convert.ToDecimal(odt_121.Rows[0][4]);
                if (indice_121 == -1 && odt_121.Rows[0][4] != DBNull.Value  )
                    odtDeclaracion.Columns.Add(abreviacion_ingreso, typeof(string));
            }

            odt_122 = oTrabajador.ListarDeclaracionJNC(id_trabajador, Convert.ToInt32(paño), "122");

            if (odt_122.Rows.Count > 0)
            {
                nombre_columna = oMaestroIngresos.ListarAbreviacionDeIdtmaestroingresos(48).Rows[0][1].ToString();
                indice_122 = BuscarIndiceColumna(odtDeclaracion, nombre_columna);
                if (indice_122 == -1 && odt_122.Rows[0][4] != DBNull.Value)
                    odtDeclaracion.Columns.Add(odt_122.Rows[0][3].ToString(), typeof(string));
            }

            odt_0401 = oTrabajador.ListarDeclaracionJNC(id_trabajador, Convert.ToInt32(paño), "0401");

            if (odt_0401.Rows.Count > 0)
            {
                nombre_columna = oMaestroIngresos.ListarAbreviacionDeIdtmaestroingresos(77).Rows[0][1].ToString();
                indice_0401 = BuscarIndiceColumna(odtDeclaracion, nombre_columna);
                if (indice_0401 == -1 && odt_0401.Rows[0][4] != DBNull.Value)
                    odtDeclaracion.Columns.Add(odt_0401.Rows[0][3].ToString(), typeof(string));
             }

            odt_0402 = oTrabajador.ListarDeclaracionJNC(id_trabajador, Convert.ToInt32(paño), "0402");

            if (odt_0402.Rows.Count > 0)
            {
                nombre_columna = oMaestroIngresos.ListarAbreviacionDeIdtmaestroingresos(78).Rows[0][1].ToString();
                indice_0402 = BuscarIndiceColumna(odtDeclaracion, nombre_columna);
                if (indice_0402 == -1 && odt_0402.Rows[0][4] != DBNull.Value)
                    odtDeclaracion.Columns.Add(odt_0402.Rows[0][3].ToString(), typeof(string));
            }

            odt_0403 = oTrabajador.ListarDeclaracionJNC(id_trabajador, Convert.ToInt32(paño), "0403");

            if (odt_0403.Rows.Count > 0)
            {
                nombre_columna = oMaestroIngresos.ListarAbreviacionDeIdtmaestroingresos(79).Rows[0][1].ToString();
                indice_0403 = BuscarIndiceColumna(odtDeclaracion, nombre_columna);
                if (indice_0403 == -1 && odt_0403.Rows[0][4] != DBNull.Value)
                    odtDeclaracion.Columns.Add(odt_0403.Rows[0][3].ToString(), typeof(string));
            }

            odt_0404 = oTrabajador.ListarDeclaracionJNC(id_trabajador, Convert.ToInt32(paño), "0404");

            if (odt_0404.Rows.Count > 0)
            {
                nombre_columna = oMaestroIngresos.ListarAbreviacionDeIdtmaestroingresos(80).Rows[0][1].ToString();
                indice_0404 = BuscarIndiceColumna(odtDeclaracion, nombre_columna);
                if (indice_0404 == -1 && odt_0404.Rows[0][4] != DBNull.Value)
                    odtDeclaracion.Columns.Add(odt_0404.Rows[0][3].ToString(), typeof(string));
            }

            odt_0405 = oTrabajador.ListarDeclaracionJNC(id_trabajador, Convert.ToInt32(paño), "0405");

            if (odt_0405.Rows.Count > 0)
            {
                nombre_columna = oMaestroIngresos.ListarAbreviacionDeIdtmaestroingresos(81).Rows[0][1].ToString();
                indice_0405 = BuscarIndiceColumna(odtDeclaracion, nombre_columna);
                if (indice_0405 == -1 && odt_0405.Rows[0][4] != DBNull.Value)
                    odtDeclaracion.Columns.Add(odt_0405.Rows[0][3].ToString(), typeof(string));
            }

            odt_0406 = oTrabajador.ListarDeclaracionJNC(id_trabajador, Convert.ToInt32(paño), "0406");

            if (odt_0406.Rows.Count > 0)
            {
                nombre_columna = oMaestroIngresos.ListarAbreviacionDeIdtmaestroingresos(82).Rows[0][1].ToString();
                indice_0406 = BuscarIndiceColumna(odtDeclaracion, nombre_columna);

                if (indice_0406 == -1 && odt_0406.Rows[0][4] != DBNull.Value)
                    odtDeclaracion.Columns.Add(odt_0406.Rows[0][3].ToString(), typeof(string));
            }

            odt_0407 = oTrabajador.ListarDeclaracionJNC(id_trabajador, Convert.ToInt32(paño), "0407");

            if (odt_0407.Rows.Count > 0)
            {
                nombre_columna = oMaestroIngresos.ListarAbreviacionDeIdtmaestroingresos(83).Rows[0][1].ToString();
                indice_0407 = BuscarIndiceColumna(odtDeclaracion, nombre_columna);
                if (indice_0407 == -1 && odt_0407.Rows[0][4] != DBNull.Value)
                    odtDeclaracion.Columns.Add(odt_0407.Rows[0][3].ToString(), typeof(string));
            }

            /*Fin cuadro 2*/
            /*Fin de formato de declaracion jurada de nombramientos a contraloria */

        }

        private PdfPTable pdf_cuerpo(int alineacion, int ancho)
        {
            PdfPTable pdfTableA = new PdfPTable(dgvCuerpo.ColumnCount);
            //Creating iTextSharp Table from the DataTable data
            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 7);
            iTextSharp.text.Font fuenteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 9, 1, iTextSharp.text.Color.BLUE);
            int o = 0; int k = 0; string celda = "";
            if (dgvCuerpo.ColumnCount > 0)
            {
                Phrase objH_A = new Phrase("A", fuenteTitulo);
                Phrase objP_A = new Phrase("A", fuente);
                float[] headerwidths_A = GetTamañoColumnas(dgvCuerpo);
                pdfTableA.DefaultCell.Padding = 0;
                pdfTableA.HorizontalAlignment = alineacion;
                pdfTableA.DefaultCell.BorderWidth = 1;
                pdfTableA.SetWidths(headerwidths_A);
                pdfTableA.WidthPercentage = ancho;
                /* -------------------------------INICIO DGVBOLETA_A */
                foreach (DataGridViewColumn column in dgvCuerpo.Columns)
                {
                    cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                    cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                    cell.Colspan = 1;
                    cell.Rowspan = 1;
                    cell.HorizontalAlignment = 1;

                    pdfTableA.AddCell(cell);
                    k++;
                }

                for (int i = 0; i < dgvCuerpo.RowCount; i++)
                {
                    for (int j = 0; j < dgvCuerpo.ColumnCount; j++)
                    {
                        //objP_A = new Phrase(dgvBoletaPago_A[j, i].Value.ToString(), fuente);
                        celda = dgvCuerpo[j, i].Value.ToString();
                        cell = new PdfPCell((new Phrase(celda, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));

                        if (j == 2 || j == 5 || j >= 7) {
                            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        }

                        pdfTableA.AddCell(cell);
                    }
                    pdfTableA.CompleteRow();
                }
                /* -------------------------------FIN DGVBOLETA_A */
            }
            return pdfTableA;
        }

        private PdfPTable pdf_cabeza(int alineacion, int ancho)
        {
            PdfPTable pdfTableA = new PdfPTable(dgvCabeza.ColumnCount);
            //Creating iTextSharp Table from the DataTable data
            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 7);
            iTextSharp.text.Font fuenteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 9, 1, iTextSharp.text.Color.BLUE);
            int o = 0; int k = 0;
            if (dgvCabeza.ColumnCount > 0)
            { 
                Phrase objH_A = new Phrase("A", fuenteTitulo);
                Phrase objP_A = new Phrase("A", fuente);
                float[] headerwidths_A = GetTamañoColumnas(dgvCabeza);
                pdfTableA.DefaultCell.Padding = 0;
                pdfTableA.HorizontalAlignment = alineacion;
                pdfTableA.DefaultCell.BorderWidth = 1;
                pdfTableA.SetWidths(headerwidths_A);
                pdfTableA.WidthPercentage = ancho; 
                /* -------------------------------INICIO DGVBOLETA_A */ 
                foreach (DataGridViewColumn column in dgvCabeza.Columns)
                {
                    cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                    cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                    cell.Colspan = 1;
                    cell.Rowspan = 1;
                    cell.HorizontalAlignment = 1;

                    pdfTableA.AddCell(cell);
                    k++;
                }

                for (int i = 0; i < dgvCabeza.RowCount - 1; i++)
                {
                    for (int j = 0; j < dgvCabeza.ColumnCount; j++)
                    {
                        //objP_A = new Phrase(dgvBoletaPago_A[j, i].Value.ToString(), fuente);
                        cell = new PdfPCell((new Phrase(dgvCabeza[j, i].Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                        pdfTableA.AddCell(cell);
                    }
                    pdfTableA.CompleteRow();
                }
                /* -------------------------------FIN DGVBOLETA_A */
            }
            return pdfTableA;
        }

        public float[] GetTamañoColumnas(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
            }
            return values;
        }

        public void CreateHeaderFooter(ref Document _document)
        {
            var headerfooter = FontFactory.GetFont("Arial", 8);
            HeaderFooter header = (new HeaderFooter(new Phrase("Formato Declaración Jurada de Nombramientos a Contraloria", headerfooter), false));
            header.BorderColorTop = new iTextSharp.text.Color(System.Drawing.Color.Red);
            header.BorderWidthTop = 0f;
            _document.Header = header;
            HeaderFooter Footer = new HeaderFooter(new Phrase(" ", headerfooter), true);
            Footer.BorderWidthBottom = 0f;
            _document.Footer = Footer;
        }

        private void dgvDeclaracionJurada_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDeclaracionJurada_CellClick(object sender, DataGridViewCellEventArgs e)
        {
 
            if (e.RowIndex != -1)
            {
                id_trabajador = Convert.ToInt32(dgvDeclaracionJurada.Rows[e.RowIndex].Cells[1].Value);

            }
        }

        private void cboAño_SelectedValueChanged(object sender, EventArgs e)
        {
             
        }
    }
}
