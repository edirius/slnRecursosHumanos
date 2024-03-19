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

using CapaUsuario.Properties;


namespace CapaUsuario.Reportes
{
    public partial class frmBoletaPagoXPlanilla : Form
    {
        int sidtregimenlaboral = 0;

        string pmes = "";
        string pmes_nro = "";
        string paño = "";

        string sMes = "";
        string sAño = "";

        int sidttrabajador = 0;
        int sidtplanilla = 0;

        string plantilla = "";
        int iii = 0;
        int total_trabajadores = 0;

        int total_lineas_hoja = 0;
        float ftotal_lineas_hoja = 0;
        bool boleta_pago_vacia = false;

        string folderPath = "C:\\PDFs\\";
 
        PdfPCell cell;

        const int ERROR_SHARING_VIOLATION = 32;
        const int ERROR_LOCK_VIOLATION = 33;


        //PdfWriter writer = PdfWriter.GetInstance(new Document(PageSize.A4, 9, 9, 10, 10), new FileStream("C:\\PDFs\\" + "BoletaPago.pdf", FileMode.Create));

        public frmBoletaPagoXPlanilla()
        {
            InitializeComponent();
        }

 

        public bool IsFileLocked(string filename)
        {
            bool Locked = false;
            try
            {
                FileStream fs =
                    File.Open(filename, FileMode.OpenOrCreate,
                    FileAccess.ReadWrite, FileShare.None);
                fs.Close();
            }
            catch (IOException ex)
            {
                Locked = true;
            }
            return Locked;
        }

        protected virtual bool IsFileinUse2(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
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

        Boolean isInUse(String filename)
        {
            try
            {
                using (Stream stream = new FileStream(filename, FileMode.Open))
                {
                    stream.Close();
                    return false;
                }
            }
            catch
            {
                return true;
            }
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

        private int nro_dias_mes(int pmes, int paño)
        {
            int dias_mes = 0;
            bool bisiesto = false;

            if (paño % 4 == 0 && (paño % 100 != 0 || paño % 400 == 0))
            {
                bisiesto = true;
            }

            if (!bisiesto)
            {
                switch (pmes)
                {
                    case 2: dias_mes = 28; break;
                }
            }
            else
            {
                switch (pmes)
                {
                    case 2: dias_mes = 29; break;
                }
            }


            switch (pmes)
            {
                case 1: dias_mes = 31; break;
                case 3: dias_mes = 31; break;
                case 4: dias_mes = 30; break;
                case 5: dias_mes = 31; break;
                case 6: dias_mes = 30; break;
                case 7: dias_mes = 31; break;
                case 8: dias_mes = 31; break;
                case 9: dias_mes = 30; break;
                case 10: dias_mes = 31; break;
                case 11: dias_mes = 30; break;
                case 12: dias_mes = 31; break;
            }

            return dias_mes;
        }


        private bool LockedFile(FileInfo file)
        {
            try
            {
                //string filePath = file.FullName;
                string filePath = "C:\\PDFs\\BoletaPagoPlanilla.pdf";
                FileStream fs = File.OpenWrite(filePath);
                fs.Close();
                return false;
            }
            catch (Exception) { return true; }
        }

        protected virtual bool IsFileLocked2(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
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

            //file is not locked
            return false;
        }

        public static bool IsFileLocked2(string file)
        {
            try
            {
                using (var stream = File.OpenRead(file))
                    return false;
            }
            catch (IOException)
            {
                return true;
            }
        }

        public static bool IsLocked(FileInfo f)
        {
            try
            {
                string fpath = f.FullName;
                FileStream fs = File.OpenWrite(fpath);
                fs.Close();
                return false;
            }

            catch (Exception) { return true; }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo(@"C:\PDFs\BoletaPagoPlanilla.pdf");
            bool estaAbierto = false;
            estaAbierto = IsFileinUse(file, @"C:\PDFs\BoletaPagoPlanilla.pdf");

            boleta_pago_vacia = false;

            if (plantilla != "REGIDORES")
            {
                if (!estaAbierto)
                {
                    exportar_a_pdf();
                }
                else
                {
                    MessageBox.Show("Por favor cerrar BoletaPagoPlanilla.pdf", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else {
                   MessageBox.Show("La plantilla regidores no cuenta con Boleta de Pago.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        public float[] GetTamañoColumnas2(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
            }
            return values;
        }

        public float[] GetTamañoColumnas(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
                if (i == 0) values[i] = 50;
                if (i == 1) values[i] = 200;
            }
            return values;
        }

        public float[] GetTamañoColumnas_D(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
                if (i == 2) values[i] = 10;
            }
            return values;
        }

        public float[] GetTamañoColumnas_A(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
                if (i == 3) values[i] = 17;
            }
            return values;
        }

        public float[] GetTamañoColumnas_B(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
                if (i == 4) values[i] = 22;
            }
            return values;
        }

        public float[] GetTamañoColumnas_C(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
                if (i == 8) values[i] = 45;
            }
            return values;
        }

        public float[] GetTamañoColumnas_E(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
                if (i == 4) values[i] = 22;
                if (i == 0) values[i] = 180;
                if (i == 5) values[i] = 180;
            }
            return values;
        }


        public float[] GetTamañoColumnas_E2(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
                if (i == 6) values[i] = 30;
                if (i == 0) values[i] = 150;
                if (i == 2) values[i] = 150;
                if (i == 4) values[i] = 150;
                if (i == 7) values[i] = 150;
                if (i == 9) values[i] = 150;
                if (i == 11) values[i] = 150;

            }
            return values;
        }
        public void exportar_a_pdf()
        {
            CapaDeNegocios.Reportes.cBoletaPago oBoletaPago = new CapaDeNegocios.Reportes.cBoletaPago();
            DataTable odtA = new DataTable();

            //PdfWriter.GetInstance(pdfDoc, stream);
            DataTable odtPlanilla = new DataTable();
            CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

            Paragraph paragraph = new Paragraph();
            Paragraph paragraph2 = new Paragraph();
            Paragraph paragraph3 = new Paragraph();

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            //using (FileStream stream = new FileStream(folderPath + "Graphics.pdf", FileMode.Create))
            //{


            // Add a new page to the pdf file
            //pdfDoc.NewPage();
            Document pdfDoc = new Document(PageSize.A4, 9, 9, 10, 10);

            if ( rdbVertical.Checked == true )
                pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4);
            else
                pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());


            paragraph.Alignment = Element.ALIGN_CENTER;
            paragraph.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 8);
            paragraph.Add(" ");

            if (rdbVertical.Checked == true)
            {
                paragraph2.Alignment = Element.ALIGN_LEFT;
                paragraph2.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 8);
                paragraph2.Add("\n\n             ......................................                              ......................................                                ......................................                              ......................................");
                paragraph3.Alignment = Element.ALIGN_LEFT;
                paragraph3.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 8);
                paragraph3.Add("                  EMPLEADOR                                          TRABAJADOR                                          EMPLEADOR                                          TRABAJADOR");
            }
            else {
                paragraph2.Alignment = Element.ALIGN_LEFT;
                paragraph2.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 8);
                paragraph2.Add("\n\n             ......................................                              ......................................                                                                                                                                ......................................                              ......................................");
                paragraph3.Alignment = Element.ALIGN_LEFT;
                paragraph3.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 8);
                paragraph3.Add("                  EMPLEADOR                                          TRABAJADOR                                                                                                                                          EMPLEADOR                                          TRABAJADOR");
            }


            //PdfContentByte cb = writer.DirectContent;

            //pdfDoc.Open();
            /*
            cb.MoveTo(pdfDoc.PageSize.Width / 2,0);
            cb.LineTo( pdfDoc.PageSize.Width/2, pdfDoc.PageSize.Height);
            cb.Stroke();
            cb.MoveTo( 0 , pdfDoc.PageSize.Height/2 );
            cb.LineTo(pdfDoc.PageSize.Width, pdfDoc.PageSize.Height / 2);
            cb.Stroke();
            */

            /*              Llenar datagrids            */
            odtPlanilla = oPlanilla.ListarDetallePlanillaX(sidtplanilla);

            if (odtPlanilla.Rows.Count > 0) {

                FileStream fs = new FileStream(folderPath + "BoletaPagoPlanilla.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fs);
                CreateHeaderFooter(ref pdfDoc);
                //Abrir pagina
                pdfDoc.Open();

                for (int jjj=0; jjj<odtPlanilla.Rows.Count ; jjj++)
                {
                    //recorrer trabajadores de una planilla
                    sidttrabajador = Convert.ToInt16(odtPlanilla.Rows[jjj][1]);
                    
                    //obtener datagridview de trabajador
                    datagridviews_boleta_pago();

                    if (boleta_pago_vacia)
                    {

                        MessageBox.Show("Boleta de pago vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MultiColumnText columns2 = new MultiColumnText();
                        columns2.AddRegularColumns(36f, pdfDoc.PageSize.Width - 36f, 24f, 1);
                        columns2.AddElement(paragraph);
                        pdfDoc.Add(columns2);
                        pdfDoc.Close();
                        //stream.Close();
                        writer.Close();
                        break;
                    }

                    //Total de filas en dgvBoletaPago_A, si es mayor a 0 procede a reporte
                    //instanciando pdfTable A , B , C , D , E
                    PdfPTable pdfTableD = new PdfPTable(dgvBoletaPago_D.ColumnCount);
                    PdfPTable pdfTableA = new PdfPTable(dgvBoletaPago_A.ColumnCount);
                    PdfPTable pdfTableB = new PdfPTable(dgvBoletaPago_B.ColumnCount);
                    PdfPTable pdfTableC = new PdfPTable(dgvBoletaPago_C.ColumnCount);
                    PdfPTable pdfTableE = new PdfPTable(dgvBoletaPago_E.ColumnCount);
 
                    //Nueva pagina
                    pdfDoc.NewPage();
 
                    //obtener pdfTableA,B,C,D,E 
                    pdfTableD = pdf_d(0,100);
                    pdfTableA = pdf_a(0,100);
                    pdfTableB = pdf_b(0,100);
                    pdfTableC = pdf_c(0,100);
                    pdfTableE = pdf_e(0,100);
                    
                    //Columnas 
                    MultiColumnText columns = new MultiColumnText();
                    columns.AddRegularColumns(36f, pdfDoc.PageSize.Width - 36f, 24f, 1);
                    //Agregando pdfTable A, B, C, D, E a pdfDoc

                    if (chkIncluirLogo.Checked)
                    {
                        string ruta = System.IO.Directory.GetCurrentDirectory();

                        string ruta_imagen = ruta + "\\logo-muni-fw.png";

                        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(ruta_imagen);
                        logo.ScalePercent(54f);
                        logo.SetAbsolutePosition(12f, pdfDoc.PageSize.Height - 100f);
                        logo.Border = 0;

                        PdfPTable pdftabledd = new PdfPTable(5);
                        float[] anchosNuevos = new float[] { 20, 100, 5, 20, 100 };
                        pdftabledd.SetWidths(anchosNuevos);
                        pdftabledd.WidthPercentage = 100;
                        pdftabledd.AddCell(logo);
                        pdftabledd.AddCell(pdfTableD);
                        pdftabledd.AddCell(paragraph);
                        pdftabledd.AddCell(logo);
                        pdftabledd.AddCell(pdfTableD);
                        columns.AddElement(pdftabledd);

                    }
                    else
                    {
                        columns.AddElement(pdfTableD);
                    }


                    //columns.AddElement(pdfTableD);
                    columns.AddElement(paragraph);
                    columns.AddElement(pdfTableA);
                    columns.AddElement(pdfTableB);
                    columns.AddElement(pdfTableC);
                    columns.AddElement(paragraph);
                    columns.AddElement(pdfTableE);
                    columns.AddElement(paragraph2);
                    columns.AddElement(paragraph3);
 
                    pdfDoc.Add(columns);
 
                }
 
                if (!boleta_pago_vacia)
                {
                    //int numero_pagina = writer.PageNumber;
                    //pdfDoc.Open();
                    pdfDoc.Close();
                    //stream.Close();
                    writer.Close();
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = "C:\\PDFs\\BoletaPagoPlanilla.pdf";
                    proc.Start();
                }

            }
            else{ 
                MessageBox.Show("Planilla vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

 

        public void CreateHeaderFooter(ref Document _document )
        {
            var headerfooter = FontFactory.GetFont("Arial", 8);
            HeaderFooter header = (new HeaderFooter(new Phrase("Boleta de Pago", headerfooter), false));
            header.BorderColorTop = new iTextSharp.text.Color(System.Drawing.Color.Red);
            header.BorderWidthTop = 0f;
            _document.Header = header;
            HeaderFooter Footer = new HeaderFooter(new Phrase(" ", headerfooter), true);
            //Footer.BorderWidthBottom = 0f;
            Footer.BorderWidthBottom =  0f;
            Footer.BorderWidthTop = 0f;
            Footer.BorderWidthLeft = 0f;
            Footer.BorderWidthRight = 0f;
            _document.Footer = Footer;
        }

        public static DataTable MergeTablesByIndex(DataTable t1, DataTable t2)
        {
            if (t1 == null || t2 == null) throw new ArgumentNullException("t1 or t2", "Both tables must not be null");

            DataTable t3 = t1.Clone();  // first add columns from table1
            foreach (DataColumn col in t2.Columns)
            {
                string newColumnName = col.ColumnName;
                int colNum = 1;
                while (t3.Columns.Contains(newColumnName))
                {
                    //newColumnName = string.Format("{0}_{1}", col.ColumnName, ++colNum);
                    newColumnName = string.Format("{0} {1}", col.ColumnName, "  ");
                }
                t3.Columns.Add(newColumnName, col.DataType);
            }
            var mergedRows = t1.AsEnumerable().Zip(t2.AsEnumerable(),
                (r1, r2) => r1.ItemArray.Concat(r2.ItemArray).ToArray());
            foreach (object[] rowFields in mergedRows)
                t3.Rows.Add(rowFields);

            return t3;
        }

        private void datagridviews_boleta_pago()
        {
            //bool dgv_boleta_pago = true;

            DataTable odtA = new DataTable();
            DataTable odtB = new DataTable();
            DataTable odtC = new DataTable();
            DataTable odtD = new DataTable();
            DataTable odtE = new DataTable();
            DataTable odtF = new DataTable();
            DataTable odtG = new DataTable();
            DataTable odtH = new DataTable();
            DataTable odtI = new DataTable();
            DataTable odtD2 = new DataTable();
            DataTable odtEB = new DataTable();
            DataTable odtAB = new DataTable();
            DataTable odtA2 = new DataTable();
            DataTable odtBB = new DataTable();
            DataTable odtB2 = new DataTable();
            DataTable odtCB = new DataTable();
            DataTable odtC2 = new DataTable();
            DataTable odtOB = new DataTable();
            DataTable odtE2 = new DataTable();

            DataTable odtID = new DataTable();

            DataTable odtC3 = new DataTable();

            DataTable odtPlanilla = new DataTable();

            DataRow drFilaD = odtD.NewRow();
            DataRow drFilaF = odtF.NewRow();
            DataRow drFilaEB = odtEB.NewRow();
            DataRow drFilaAB = odtAB.NewRow();
            DataRow drFilaBB = odtBB.NewRow();
            DataRow drFilaCB = odtCB.NewRow();
            DataRow drFilaOB = odtOB.NewRow();
            DataRow drFilaC3 = odtC3.NewRow();

            CapaDeNegocios.Reportes.cBoletaPago oBoletaPago = new CapaDeNegocios.Reportes.cBoletaPago();
            CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();
            CapaDeNegocios.Planillas.cDetallePlanillaIngresos oDetallePlanillaIngresos = new CapaDeNegocios.Planillas.cDetallePlanillaIngresos();
            CapaDeNegocios.Planillas.cDetallePlanillaDescuentos oDetallePlanillaDescuentos = new CapaDeNegocios.Planillas.cDetallePlanillaDescuentos();
            CapaDeNegocios.Planillas.cDetallePlanillaATrabajador oDetallePlanillaATrabajador = new CapaDeNegocios.Planillas.cDetallePlanillaATrabajador();
            CapaDeNegocios.Planillas.cDetallePlanillaAEmpleador oDetallePlanillaAEmpleador = new CapaDeNegocios.Planillas.cDetallePlanillaAEmpleador();

            //odtPlanilla = oPlanilla.ListarDetallePlanillaX(sidtplanilla);
            
                int dias_laborados = 0;
                int mes_dias = 0;

                //sidttrabajador = Convert.ToInt16(odtPlanilla.Rows[iii][1]);

                //*-------------Primera parte de la boleta de pago */ 
                odtD.Columns.Clear();
                odtD.Rows.Clear();

                odtD.Columns.Add(" ", typeof(string));
                odtD.Columns.Add("  ", typeof(string));

                drFilaD = odtD.NewRow();
                drFilaD.Delete();
                drFilaD[0] = "RUC:"; drFilaD[1] = Settings.Default.RUC;
                odtD.Rows.InsertAt(drFilaD, 0);

                drFilaD = odtD.NewRow();
                drFilaD.Delete();
                drFilaD[0] = "EMPLEADOR:"; drFilaD[1] = Settings.Default.Empresa;
                odtD.Rows.InsertAt(drFilaD, 1);

                drFilaD = odtD.NewRow();
                drFilaD.Delete();
                drFilaD[0] = "PERIODO:"; drFilaD[1] = sMes + "/" + sAño;
                odtD.Rows.InsertAt(drFilaD, 2);

                drFilaD = odtD.NewRow();
                drFilaD.Delete();
                drFilaD[0] = "PLANILLA ELECTRONICA - PLAME "; drFilaD[1] = "NUMERO DE ORDEN:";
                odtD.Rows.InsertAt(drFilaD, 3);

                odtEB.Columns.Clear();
                odtEB.Rows.Clear();

                odtEB.Columns.Add("   ");
                drFilaEB[0] = " ";
                odtEB.Rows.InsertAt(drFilaEB,0);
                drFilaEB = odtEB.NewRow();
                drFilaEB[0] = " ";
                odtEB.Rows.InsertAt(drFilaEB, 1);
                drFilaEB = odtEB.NewRow();
                drFilaEB[0] = " ";
                odtEB.Rows.InsertAt(drFilaEB, 2);
                drFilaEB = odtEB.NewRow();
                drFilaEB[0] = " ";
                odtEB.Rows.InsertAt(drFilaEB, 3);
            //CAMBIOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
            if (chkIncluirLogo.Checked)
            {
                odtD2 = odtD;
            }
            else
            {
                odtD2 = MergeTablesByIndex(odtD, odtEB);
                odtD2 = MergeTablesByIndex(odtD2, odtD);
            }


            /*------------Fin primera parte de la boleta de pago */

            /*---------inicio parte a de boleta de pago */
            odtA.Columns.Clear();
                odtA.Rows.Clear();
                odtA = oBoletaPago.ListarPlanillaXMesYRegimenLaboralYTrabajadorA(sidtplanilla, sidtregimenlaboral,sidttrabajador, pmes,pmes_nro, paño);

                odtA.Columns.Add("SITUACION", typeof(string));

            if (odtA.Rows.Count > 0)
            {

                odtA.Rows[0][2] = "ACTIVO O SUBSIDIADO";

                odtAB.Columns.Clear();
                odtAB.Rows.Clear();
                odtAB.Columns.Add(" ");
                for (int kkk = 0; kkk < odtA.Rows.Count; kkk++) {
                    drFilaAB = odtAB.NewRow();
                    drFilaAB[0] = "";
                    odtAB.Rows.InsertAt(drFilaAB, kkk);
                }

                odtA2 = MergeTablesByIndex(odtA, odtAB);
                odtA2 = MergeTablesByIndex(odtA2, odtA);

                /*---------fin de parte a de boleta de pago */

                /* Parte B  */

                odtB.Columns.Clear();
                odtB.Rows.Clear();
                odtB = oBoletaPago.ListarPlanillaXMesYRegimenLaboralYTrabajadorB(sidtplanilla, sidtregimenlaboral, sidttrabajador, pmes, pmes_nro, paño);

                odtBB.Columns.Clear();
                odtBB.Rows.Clear();

                odtBB.Columns.Add(" ");

                for (int kkk = 0; kkk < odtB.Rows.Count; kkk++)
                {
                    drFilaBB = odtBB.NewRow();
                    drFilaBB[0] = "";
                    odtBB.Rows.InsertAt(drFilaBB, kkk);
                }

                odtB2 = MergeTablesByIndex(odtB, odtBB);
                odtB2 = MergeTablesByIndex(odtB2, odtB);

                /* Fin Parte B */


                /*--------- inicio de parte c de boleta de pago, donde se aumentan columnas y se calcula dias no laborados asi como total de horas y minutos */
                odtC.Columns.Clear();
                odtC.Rows.Clear();
                odtC = oBoletaPago.ListarPlanillaXMesYRegimenLaboralYTrabajadorC(sidtplanilla, sidtregimenlaboral, sidttrabajador, pmes, pmes_nro, paño);

                odtC.Columns.Add("DIAS NO LABORADOS", typeof(string));
                odtC.Columns.Add("DIAS SUBSIDIADOS", typeof(string));
                odtC.Columns.Add("CONDICION", typeof(string));
                odtC.Columns.Add("TOTAL HORAS", typeof(string));
                odtC.Columns.Add("MINUTOS", typeof(string));
                odtC.Columns.Add("TOTAL HORAS ", typeof(string));
                odtC.Columns.Add("MINUTOS ", typeof(string));

                dias_laborados = Convert.ToInt32(odtC.Rows[0][0]);

                mes_dias = nro_dias_mes(Convert.ToInt16(pmes_nro), Convert.ToInt16( paño));

                odtC.Rows[0][1] = mes_dias - dias_laborados;
                odtC.Rows[0][2] = 0;
                odtC.Rows[0][3] = "Domiciliado";
                odtC.Rows[0][4] = (dias_laborados - (dias_laborados / 7))*8;
                //odtC.Rows[0][5] = dias_laborados * 8 * 60;
                odtC.Rows[0][5] = 0;

                odtCB.Columns.Clear();
                odtCB.Rows.Clear();

                odtCB.Columns.Add(" ");

                for (int kkk = 0; kkk < odtC.Rows.Count; kkk++)
                {
                    drFilaCB = odtCB.NewRow();
                    drFilaCB[0] = "";
                    odtCB.Rows.InsertAt(drFilaCB, kkk);
                }

                odtC2 = MergeTablesByIndex(odtC, odtCB);
                odtC2 = MergeTablesByIndex(odtC2, odtC);

                /*------------fin parte c de boleta de pago*/

                /*---------------Inicio de Obligaciones de boleta de pago - Ingresos*/
                odtE.Columns.Clear();
                odtE.Rows.Clear();
                odtE = oDetallePlanillaIngresos.ListarPlanillaXIngresosXBoletaPago(sidtplanilla, sidtregimenlaboral, sidttrabajador);

                odtF.Columns.Clear();
                odtF.Rows.Clear();

                odtF.Columns.Add("Conceptos", typeof(string));
                odtF.Columns.Add("Ingresos S/.", typeof(string));
                odtF.Columns.Add("Descuentos S/.", typeof(string));
                odtF.Columns.Add("Neto S/.", typeof(string));

                int jj = 0;

                if (odtE.Rows.Count > 0)
                {
                    drFilaF = odtF.NewRow();
                    drFilaF.Delete();
                    drFilaF[0] = "Ingresos";
                    odtF.Rows.InsertAt(drFilaF, jj);
                    jj++;

                    for (int k = 0; k < odtE.Rows.Count; k++)
                    {
                        drFilaF = odtF.NewRow();
                        drFilaF.Delete();
                        drFilaF[0] = odtE.Rows[k][0];
                        drFilaF[1] = odtE.Rows[k][1];
                        odtF.Rows.InsertAt(drFilaF, jj);
                        jj++;
                    }
                }

                odtG.Columns.Clear();
                odtG.Rows.Clear();
                odtG = oDetallePlanillaDescuentos.ListarPlanillaXDescuentosXBoletaPago(sidtplanilla, sidtregimenlaboral, sidttrabajador);

                if (odtG.Rows.Count > 0)
                {
                    drFilaF = odtF.NewRow();
                    drFilaF.Delete();
                    drFilaF[0] = "Descuentos";
                    odtF.Rows.InsertAt(drFilaF, jj);
                    jj++;

                    for (int k = 0; k < odtG.Rows.Count; k++)
                    {
                        drFilaF = odtF.NewRow();
                        drFilaF.Delete();
                        drFilaF[0] = odtG.Rows[k][0];
                        drFilaF[2] = odtG.Rows[k][1];
                        odtF.Rows.InsertAt(drFilaF, jj);
                        jj++;
                    }
                }

                odtH.Columns.Clear();
                odtH.Rows.Clear();
                odtH = oDetallePlanillaATrabajador.ListarPlanillaATrabajadorXBoletaPago(sidtplanilla, sidtregimenlaboral, sidttrabajador);

                if (odtH.Rows.Count > 0)
                {
                    drFilaF = odtF.NewRow();
                    drFilaF.Delete();
                    drFilaF[0] = "Aportaciones de Trabajador";
                    odtF.Rows.InsertAt(drFilaF, jj);
                    jj++;

                    for (int k = 0; k < odtH.Rows.Count; k++)
                    {
                        drFilaF = odtF.NewRow();
                        drFilaF.Delete();
                        drFilaF[0] = odtH.Rows[k][0];
                        drFilaF[2] = odtH.Rows[k][1];
                        odtF.Rows.InsertAt(drFilaF, jj);
                        jj++;
                    }
                }

                /*------------Calculando el Neto S/.*/

                decimal dIngresos = 0;
                decimal dIngresosParcial = 0;
                decimal dDescuentos = 0;
                decimal dEgresosParcial = 0;
                decimal dNeto = 0;
                decimal dTrabajador = 0;
            

                for (int k = 0; k < odtF.Rows.Count; k++)
                {
                    if (odtF.Rows[k][1].ToString() == "")
                        dIngresosParcial = 0;
                    else
                        dIngresosParcial = Convert.ToDecimal(odtF.Rows[k][1].ToString());

                    if (odtF.Rows[k][2].ToString() == "")
                        dEgresosParcial = 0;
                    else
                        dEgresosParcial = Convert.ToDecimal(odtF.Rows[k][2].ToString());

                    dIngresos += dIngresosParcial;
                    dDescuentos += dEgresosParcial;
                }

                /* Ingresos y Egresos */
                odtID = oDetallePlanillaATrabajador.ListarDetallePlanillaXTrabajador(sidtplanilla, sidtregimenlaboral, sidttrabajador);

                dIngresos = Convert.ToDecimal(odtID.Rows[0][1]);
                dTrabajador = Convert.ToDecimal(odtID.Rows[0][2]);
                dDescuentos = Convert.ToDecimal(odtID.Rows[0][4]);

                dNeto = dIngresos - dDescuentos - dTrabajador;

                drFilaF = odtF.NewRow();
                drFilaF.Delete();
                drFilaF[0] = "Neto a Pagar";
                drFilaF[3] = dNeto.ToString();
                odtF.Rows.InsertAt(drFilaF, jj);
                jj++;

                /*-----------Fin Calculando el Neto*/

                drFilaF = odtF.NewRow();
                drFilaF.Delete();
                drFilaF[0] = " ";
                drFilaF[1] = " ";
                drFilaF[2] = " ";
                drFilaF[3] = " ";
                odtF.Rows.InsertAt(drFilaF, jj);
                jj++;
                /*-----------Inicio Aportaciones del Empleador*/
                odtI = oDetallePlanillaAEmpleador.ListarPlanillaAEmpleadorXBoletaPago(sidtplanilla,sidtregimenlaboral,sidttrabajador );

                if (odtI.Rows.Count > 0)
                {
                    drFilaF = odtF.NewRow();
                    drFilaF.Delete();
                    drFilaF[0] = "Aportaciones de Empleador";
                    odtF.Rows.InsertAt(drFilaF, jj);
                    jj++;

                    for (int k = 0; k < odtI.Rows.Count; k++)
                    {
                        drFilaF = odtF.NewRow();
                        drFilaF.Delete();
                        drFilaF[0] = odtI.Rows[k][0];
                        drFilaF[3] = odtI.Rows[k][1];
                        odtF.Rows.InsertAt(drFilaF, jj);
                        jj++;
                    }
                }
                /*------------Fin Aportaciones del Empleador*/

                odtOB.Columns.Clear();
                odtOB.Rows.Clear();

                odtOB.Columns.Add(" ");

                for (int kkk = 0; kkk < odtF.Rows.Count; kkk++)
                {
                    drFilaOB = odtOB.NewRow();
                    drFilaOB[0] = "";
                    odtOB.Rows.InsertAt(drFilaOB, kkk);
                }

                odtE2 = MergeTablesByIndex(odtF, odtOB);
                odtE2 = MergeTablesByIndex(odtE2, odtF);

                /*----------------Fin de obligaciones de boleta de pago - Ingresos*/

                //dgvBoletaPago_D.DataSource = odtD;
                dgvBoletaPago_D.DataSource = odtD2;
                //dgvBoletaPago_A.DataSource = odtA;
                dgvBoletaPago_A.DataSource = odtA2;
                dgvBoletaPago_B.DataSource = odtB2;
                //dgvBoletaPago_B.DataSource = odtA;
                dgvBoletaPago_C.DataSource = odtC2;
                dgvBoletaPago_E.DataSource = odtE2;

            }         
            else
            {
                //MessageBox.Show("Boleta de pago vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                boleta_pago_vacia = true;
            }
        }

        private PdfPTable pdf_d( int alineacion, int ancho  )
        {
            string texto = "";
            PdfPTable pdfTableD = new PdfPTable(dgvBoletaPago_D.ColumnCount);
            //Creating iTextSharp Table from the DataTable data
            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 7);
            iTextSharp.text.Font fuenteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 9, 1, iTextSharp.text.Color.BLUE);

            if (dgvBoletaPago_D.ColumnCount > 0)
            {

                Phrase objH_D = new Phrase("A", fuente);
                Phrase objP_D = new Phrase("A", fuente);
                float[] headerwidths_D = GetTamañoColumnas_D(dgvBoletaPago_D);
                pdfTableD.DefaultCell.Padding = 0;
                pdfTableD.HorizontalAlignment = alineacion;
                
                pdfTableD.DefaultCell.BorderWidth = 1;
                pdfTableD.SetWidths(headerwidths_D);
                pdfTableD.WidthPercentage = ancho;


                /* -------------------------------INICIO DGVBOLETA_D */
 
                for (int i = 0; i < dgvBoletaPago_D.RowCount - 1; i++)
                {
                    for (int j = 0; j < dgvBoletaPago_D.ColumnCount; j++)
                    {
                        texto = dgvBoletaPago_D[j, i].Value.ToString();
                        cell = new PdfPCell((new Phrase(texto , new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                        cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);

                        if (j == 2) { 
                            cell.BorderColorLeft = CMYKColor.BLACK;
                            cell.BorderColorRight = CMYKColor.BLACK;
                            cell.BorderColorTop = CMYKColor.WHITE;
                            cell.BorderColorBottom = CMYKColor.WHITE;
                            cell.BorderWidthLeft = 1f;
                            cell.BorderWidthRight = 1f;
                            cell.BorderWidthTop = 0f;
                            cell.BorderWidthBottom = 0f;
                            cell.BackgroundColor = CMYKColor.WHITE;
                        }
                        pdfTableD.AddCell(cell);
                    }
                    pdfTableD.CompleteRow();
                    total_lineas_hoja++;
                }
                /* -------------------------------FIN DGVBOLETA_D */
            }

            return pdfTableD;
        }

        

        private PdfPTable pdf_a(int alineacion, int ancho)
        {
            PdfPTable pdfTableA = new PdfPTable(dgvBoletaPago_A.ColumnCount);
            //Creating iTextSharp Table from the DataTable data
            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 7);
            iTextSharp.text.Font fuenteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 9, 1, iTextSharp.text.Color.BLUE);
            int o = 0; int k = 0;
            if (dgvBoletaPago_A.ColumnCount > 0)
            {

                Phrase objH_A = new Phrase("A", fuenteTitulo);
                Phrase objP_A = new Phrase("A", fuente);
                float[] headerwidths_A = GetTamañoColumnas_A(dgvBoletaPago_A);
                pdfTableA.DefaultCell.Padding = 0;
                pdfTableA.HorizontalAlignment = alineacion;
                pdfTableA.DefaultCell.BorderWidth = 1;
                pdfTableA.SetWidths(headerwidths_A);
                pdfTableA.WidthPercentage = ancho;

                /* -------------------------------INICIO DGVBOLETA_A */




                foreach (DataGridViewColumn column in dgvBoletaPago_A.Columns)
                {
                    cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                    cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                    cell.Colspan = 1;
                    cell.Rowspan = 1;
                    cell.HorizontalAlignment = 1;

                    if (k == 3)
                    {
                        cell.BorderColorLeft = CMYKColor.BLACK;
                        cell.BorderColorRight = CMYKColor.BLACK;
                        cell.BorderColorTop = CMYKColor.WHITE;
                        cell.BorderColorBottom = CMYKColor.WHITE;
                        cell.BorderWidthLeft = 1f;
                        cell.BorderWidthRight = 1f;
                        cell.BorderWidthTop = 0f;
                        cell.BorderWidthBottom = 0f;
                        cell.BackgroundColor = CMYKColor.WHITE;
                    }
                    pdfTableA.AddCell(cell);
                    k++;
                }
 

                for (int i = 0; i < dgvBoletaPago_A.RowCount - 1; i++)
                {
                    for (int j = 0; j < dgvBoletaPago_A.ColumnCount; j++)
                    {
                        //objP_A = new Phrase(dgvBoletaPago_A[j, i].Value.ToString(), fuente);
                        cell = new PdfPCell((new Phrase(dgvBoletaPago_A[j, i].Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));

                        if (j == 3)
                        {
                            cell.BorderColorLeft = CMYKColor.BLACK;
                            cell.BorderColorRight = CMYKColor.BLACK;
                            cell.BorderColorTop = CMYKColor.WHITE;
                            cell.BorderColorBottom = CMYKColor.WHITE;
                            cell.BorderWidthLeft = 1f;
                            cell.BorderWidthRight = 1f;
                            cell.BorderWidthTop = 0f;
                            cell.BorderWidthBottom = 0f;
                            cell.BackgroundColor = CMYKColor.WHITE;
                        }

                        pdfTableA.AddCell(cell);


                    }
                    pdfTableA.CompleteRow();
                    total_lineas_hoja++;
                }
                /* -------------------------------FIN DGVBOLETA_A */
            }
            return pdfTableA;
        }

        private PdfPTable pdf_b(int alineacion,int ancho)
        {
            PdfPTable pdfTableB = new PdfPTable(dgvBoletaPago_B.ColumnCount);
            //Creating iTextSharp Table from the DataTable data
            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 7);
            iTextSharp.text.Font fuenteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 9, 1, iTextSharp.text.Color.BLUE);
            int k = 0;
            if (dgvBoletaPago_B.ColumnCount > 0)
            {

                Phrase objH_B = new Phrase("A", fuenteTitulo);
                Phrase objP_B = new Phrase("A", fuente);
                float[] headerwidths_B = GetTamañoColumnas_B(dgvBoletaPago_B);
                pdfTableB.DefaultCell.Padding = 0;
                pdfTableB.HorizontalAlignment = alineacion;
                pdfTableB.DefaultCell.BorderWidth = 1;
                pdfTableB.SetWidths(headerwidths_B);
                pdfTableB.WidthPercentage = ancho;
                /* -------------------------------INICIO DGVBOLETA_B */

                foreach (DataGridViewColumn column in dgvBoletaPago_B.Columns)
                {
                    cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                    cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                    if (k ==4)
                    {
                        cell.BorderColorLeft = CMYKColor.BLACK;
                        cell.BorderColorRight = CMYKColor.BLACK;
                        cell.BorderColorTop = CMYKColor.WHITE;
                        cell.BorderColorBottom = CMYKColor.WHITE;
                        cell.BorderWidthLeft = 1f;
                        cell.BorderWidthRight = 1f;
                        cell.BorderWidthTop = 0f;
                        cell.BorderWidthBottom = 0f;
                        cell.BackgroundColor = CMYKColor.WHITE;
                    }
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTableB.AddCell(cell);
                    k++;
                }

                for (int i = 0; i < dgvBoletaPago_B.RowCount - 1; i++)
                {
                    for (int j = 0; j < dgvBoletaPago_B.ColumnCount; j++)
                    {

                        cell = new PdfPCell((new Phrase(dgvBoletaPago_B[j, i].Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                        if (j == 4)
                        {
                            cell.BorderColorLeft = CMYKColor.BLACK;
                            cell.BorderColorRight = CMYKColor.BLACK;
                            cell.BorderColorTop = CMYKColor.WHITE;
                            cell.BorderColorBottom = CMYKColor.WHITE;
                            cell.BorderWidthLeft = 1f;
                            cell.BorderWidthRight = 1f;
                            cell.BorderWidthTop = 0f;
                            cell.BorderWidthBottom = 0f;
                            cell.BackgroundColor = CMYKColor.WHITE;
                        }
                        pdfTableB.AddCell(cell);
                    }
                    pdfTableB.CompleteRow();
                    total_lineas_hoja++;
                }
                /* -------------------------------FIN DGVBOLETA_B */
            }

            return pdfTableB;
        }

        private PdfPTable pdf_c(int alineacion, int ancho)
        {
            PdfPTable pdfTableC = new PdfPTable(dgvBoletaPago_C.ColumnCount);
            //Creating iTextSharp Table from the DataTable data
            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 7);
            iTextSharp.text.Font fuenteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 9, 1, iTextSharp.text.Color.BLUE);
            int o = 0; int k = 0;
             if (dgvBoletaPago_C.ColumnCount > 0)
            {


                Phrase objH_C = new Phrase("A", fuenteTitulo);
                Phrase objP_C = new Phrase("A", fuente);
                float[] headerwidths_C = GetTamañoColumnas_C(dgvBoletaPago_C);
                pdfTableC.DefaultCell.Padding = 0;
                pdfTableC.HorizontalAlignment = alineacion;
                pdfTableC.DefaultCell.BorderWidth = 1;
                pdfTableC.SetWidths(headerwidths_C);
                pdfTableC.WidthPercentage = ancho;
                /* -------------------------------INICIO DGVBOLETA_C */

                o = 0;
                
                foreach (DataGridViewColumn column in dgvBoletaPago_C.Columns)
                {
                    if (o == 8)
                    {
                        cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                        cell.BorderColorLeft = CMYKColor.BLACK;
                        cell.BorderColorRight = CMYKColor.BLACK;
                        cell.BorderColorTop = CMYKColor.WHITE;
                        cell.BorderColorBottom = CMYKColor.WHITE;
                        cell.BorderWidthLeft = 1f;
                        cell.BorderWidthRight = 1f;
                        cell.BorderWidthTop = 0f;
                        cell.BorderWidthBottom = 0f;
                        cell.BackgroundColor = CMYKColor.WHITE;
                        pdfTableC.AddCell(cell);
                    }

                    if (o == 4 || o == 13 ) 
                    {
                        cell = new PdfPCell((new Phrase("JORNADA ORDINARIA", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                        cell.Colspan = 2;
                        cell.Rowspan = 1;
                        cell.HorizontalAlignment = 1;
                        cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        pdfTableC.AddCell(cell);
                    }
                    
                    if (o == 6 || o==15 )
                    {
                        cell = new PdfPCell((new Phrase("SOBRE TIEMPO", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                        cell.Colspan = 2;
                        cell.Rowspan = 1;
                        cell.HorizontalAlignment = 1;
                        cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        pdfTableC.AddCell(cell);
                    }

                    if (o == 0 || o == 1 || o == 2 || o == 3 || o == 9 || o == 10 || o == 11 || o == 12 )
                    {
                        cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.Rowspan = 2;
                        cell.Colspan = 1;
                        cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        pdfTableC.AddCell(cell);
                    }

                    o++;
                }
                

                k = 0;

                foreach (DataGridViewColumn column in dgvBoletaPago_C.Columns)
                {
                    if (k == 8)
                    {
                        cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                        cell.BorderColorLeft = CMYKColor.BLACK;
                        cell.BorderColorRight = CMYKColor.BLACK;
                        cell.BorderColorTop = CMYKColor.WHITE;
                        cell.BorderColorBottom = CMYKColor.WHITE;
                        cell.BorderWidthLeft = 1f;
                        cell.BorderWidthRight = 1f;
                        cell.BorderWidthTop = 0f;
                        cell.BorderWidthBottom = 0f;
                        cell.BackgroundColor = CMYKColor.WHITE;
                        pdfTableC.AddCell(cell);
                    }

                    if (k == 4 || k == 5 || k == 6 || k == 7 || k== 13 || k==14 || k==15 || k==16)
                    {
                        cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                        cell.Colspan = 1;
                        cell.Rowspan = 1;
                        cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
   
                        pdfTableC.AddCell(cell);
                    }

                    k++;
                }



                for (int i = 0; i < dgvBoletaPago_C.RowCount - 1; i++)
                {
                    for (int j = 0; j < dgvBoletaPago_C.ColumnCount; j++)
                    {
                        cell = new PdfPCell((new Phrase(dgvBoletaPago_C[j, i].Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                        if (j == 8)
                        {
                            cell.BorderColorLeft = CMYKColor.BLACK;
                            cell.BorderColorRight = CMYKColor.BLACK;
                            cell.BorderColorTop = CMYKColor.WHITE;
                            cell.BorderColorBottom = CMYKColor.WHITE;
                            cell.BorderWidthLeft = 1f;
                            cell.BorderWidthRight = 1f;
                            cell.BorderWidthTop = 0f;
                            cell.BorderWidthBottom = 0f;
                            cell.BackgroundColor = CMYKColor.WHITE;
                        }
                        pdfTableC.AddCell(cell);
                    }
                    pdfTableC.CompleteRow();
                    total_lineas_hoja++;
                }
                /* -------------------------------FIN DGVBOLETA_C */
            }

            return pdfTableC;
        }

        private PdfPTable pdf_e(int alineacion,int ancho)
        {
            PdfPTable pdfTableE = new PdfPTable(dgvBoletaPago_E.ColumnCount);
            //Creating iTextSharp Table from the DataTable data
            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 7);
            iTextSharp.text.Font fuenteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 9, 1, iTextSharp.text.Color.BLUE);


            if (dgvBoletaPago_E.ColumnCount > 0)
            {

                Phrase objH_E = new Phrase("A", fuenteTitulo);
                Phrase objP_E = new Phrase("A", fuente);
                float[] headerwidths_E = GetTamañoColumnas_E(dgvBoletaPago_E);
                pdfTableE.DefaultCell.Padding = 0;
                pdfTableE.HorizontalAlignment = alineacion;
                pdfTableE.DefaultCell.BorderWidth = 1;
                pdfTableE.SetWidths(headerwidths_E);
                pdfTableE.WidthPercentage = ancho;
                int iindice_ingresos = 0;
                int iindice_descuentos = 0;
                int iindice_a_empleador_i = 0;
                int iindice_a_empleador_j = 0;
                int iindice_a_trabajador = 0;

                bool fAportacionesEmpleador = false;


                /* -------------------------------INICIO DGVBOLETA_E */
                int k = 0;
                foreach (DataGridViewColumn column in dgvBoletaPago_E.Columns)
                {
                    cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                    cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);

                    if (k == 4)
                    {
                        cell.BorderColorLeft = CMYKColor.BLACK;
                        cell.BorderColorRight = CMYKColor.BLACK;
                        cell.BorderColorTop = CMYKColor.WHITE;
                        cell.BorderColorBottom = CMYKColor.WHITE;
                        cell.BorderWidthLeft = 1f;
                        cell.BorderWidthRight = 1f;
                        cell.BorderWidthTop = 0f;
                        cell.BorderWidthBottom = 0f;
                        cell.BackgroundColor = CMYKColor.WHITE;
                    }
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTableE.AddCell(cell);
                    k++;
                }

                for (int i = 0; i < dgvBoletaPago_E.RowCount - 1; i++)
                {
                    for (int j = 0; j < dgvBoletaPago_E.ColumnCount; j++)
                    {
                        cell = new PdfPCell((new Phrase(dgvBoletaPago_E[j, i].Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));

                        if (j == 4)
                        {
                            cell.BorderColorLeft = CMYKColor.BLACK;
                            cell.BorderColorRight = CMYKColor.BLACK;
                            cell.BorderColorTop = CMYKColor.WHITE;
                            cell.BorderColorBottom = CMYKColor.WHITE;
                            cell.BorderWidthLeft = 1f;
                            cell.BorderWidthRight = 1f;
                            cell.BorderWidthTop = 0f;
                            cell.BorderWidthBottom = 0f;
                            cell.BackgroundColor = CMYKColor.WHITE;
                        }

                        if (dgvBoletaPago_E[j, i].Value.ToString() == "Aportaciones de Empleador")
                        {
                            iindice_a_empleador_i = i;
                            iindice_a_empleador_j = j;
                            fAportacionesEmpleador = true;

                            cell.Colspan = 1;
                            cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        }
                        if (dgvBoletaPago_E[j, i].Value.ToString() == "Aportaciones de Trabajador")
                        {
                            cell.Colspan = 1;
                            cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        }
                        if (dgvBoletaPago_E[j, i].Value.ToString() == "Descuentos")
                        {
                            cell.Colspan = 1;
                            cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        }
                        if (dgvBoletaPago_E[j, i].Value.ToString() == "Ingresos")
                        {
                            cell.Colspan = 1;
                            cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        }
                        if (dgvBoletaPago_E[j, i].Value.ToString() == "Neto a Pagar")
                        {
                            cell.HorizontalAlignment = 1;
                            cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        }
                        //Alineando a la derecha la columna de ingresos, egresos y neto
                        if (j == 1 || j ==2 || j==3 || j == 5 || j == 6 || j == 7)
                            cell.HorizontalAlignment = Element.ALIGN_RIGHT;

                        //Alineando a la derecha la columna de ingresos, egresos y neto
                        if (j == 0 || j == 5 )
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;


                        //cell.FixedHeight = 25f;
                        pdfTableE.AddCell(cell);
                        

                    }
                    //float total_altura = pdfTableE.CalculateHeights(true);
                    //ftotal_lineas_hoja += cell.GetMaxHeight();
                    ftotal_lineas_hoja = pdfTableE.TotalHeight;
                    pdfTableE.CompleteRow();
                    total_lineas_hoja++;
                }
                /* -------------------------------FIN DGVBOLETA_E */
            }
            return pdfTableE;
        }


        private PdfPTable pdf_e2(int alineacion, int ancho)
        {
            PdfPTable pdfTableE = new PdfPTable(dgvBoletaPago_E.ColumnCount);
            //Creating iTextSharp Table from the DataTable data
            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 7);
            iTextSharp.text.Font fuenteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 9, 1, iTextSharp.text.Color.BLUE);


            if (dgvBoletaPago_E.ColumnCount > 0)
            {

                Phrase objH_E = new Phrase("A", fuenteTitulo);
                Phrase objP_E = new Phrase("A", fuente);
                float[] headerwidths_E = GetTamañoColumnas_E2(dgvBoletaPago_E);
                pdfTableE.DefaultCell.Padding = 0;
                pdfTableE.HorizontalAlignment = alineacion;
                pdfTableE.DefaultCell.BorderWidth = 1;
                pdfTableE.SetWidths(headerwidths_E);
                pdfTableE.WidthPercentage = ancho;
                int iindice_ingresos = 0;
                int iindice_descuentos = 0;
                int iindice_a_empleador_i = 0;
                int iindice_a_empleador_j = 0;
                int iindice_a_trabajador = 0;

                bool fAportacionesEmpleador = false;


                /* -------------------------------INICIO DGVBOLETA_E */
                int k = 0;
                foreach (DataGridViewColumn column in dgvBoletaPago_E.Columns)
                {
                    cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                    cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);

                    if (k == 6)
                    {
                        cell.BorderColorLeft = CMYKColor.BLACK;
                        cell.BorderColorRight = CMYKColor.BLACK;
                        cell.BorderColorTop = CMYKColor.WHITE;
                        cell.BorderColorBottom = CMYKColor.WHITE;
                        cell.BorderWidthLeft = 1f;
                        cell.BorderWidthRight = 1f;
                        cell.BorderWidthTop = 0f;
                        cell.BorderWidthBottom = 0f;
                        cell.BackgroundColor = CMYKColor.WHITE;
                    }
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTableE.AddCell(cell);
                    k++;
                }

                for (int i = 0; i < dgvBoletaPago_E.RowCount - 1; i++)
                {
                    for (int j = 0; j < dgvBoletaPago_E.ColumnCount; j++)
                    {
                        cell = new PdfPCell((new Phrase(dgvBoletaPago_E[j, i].Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));

                        if (j == 6)
                        {
                            cell.BorderColorLeft = CMYKColor.BLACK;
                            cell.BorderColorRight = CMYKColor.BLACK;
                            cell.BorderColorTop = CMYKColor.WHITE;
                            cell.BorderColorBottom = CMYKColor.WHITE;
                            cell.BorderWidthLeft = 1f;
                            cell.BorderWidthRight = 1f;
                            cell.BorderWidthTop = 0f;
                            cell.BorderWidthBottom = 0f;
                            cell.BackgroundColor = CMYKColor.WHITE;
                        }
                        if (j == 0 || j == 2 || j== 4 || j==7 || j== 9 || j==11)
                        {
                            cell.BorderColorRight = CMYKColor.WHITE;
                            cell.BorderWidthRight = 0f;
                        }
                        if (j == 1 || j== 3 || j==5 || j==8 || j== 10 || j==12)
                        {
                            cell.BorderColorLeft = CMYKColor.WHITE;
                            cell.BorderWidthLeft = 0f;
                        }

                        if (dgvBoletaPago_E[j, i].Value.ToString() == "Aportaciones de Empleador")
                        {
                            iindice_a_empleador_i = i;
                            iindice_a_empleador_j = j;
                            fAportacionesEmpleador = true;

                            cell.Colspan = 1;
                            cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        }
                        if (dgvBoletaPago_E[j, i].Value.ToString() == "Aportaciones de Trabajador")
                        {
                            cell.Colspan = 1;
                            cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        }
                        if (dgvBoletaPago_E[j, i].Value.ToString() == "Descuentos")
                        {
                            cell.Colspan = 1;
                            cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        }
                        if (dgvBoletaPago_E[j, i].Value.ToString() == "Ingresos")
                        {
                            cell.Colspan = 1;
                            cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        }
                        if (dgvBoletaPago_E[j, i].Value.ToString() == "Neto a Pagar")
                        {
                            cell.HorizontalAlignment = 1;
                            cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        }
                        //Alineando a la derecha la columna de ingresos, egresos y neto
                        if (j == 1 || j == 3 || j == 5 || j == 8 || j == 10 || j == 12)
                            cell.HorizontalAlignment = Element.ALIGN_RIGHT;

                        //Alineando a la derecha la columna de ingresos, egresos y neto
                        if (j == 0 || j == 2 || j == 4 || j == 7 || j == 9 || j == 11)
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;


                        //cell.FixedHeight = 25f;
                        pdfTableE.AddCell(cell);


                    }
                    //float total_altura = pdfTableE.CalculateHeights(true);
                    //ftotal_lineas_hoja += cell.GetMaxHeight();
                    ftotal_lineas_hoja = pdfTableE.TotalHeight;
                    pdfTableE.CompleteRow();
                    total_lineas_hoja++;
                }
                /* -------------------------------FIN DGVBOLETA_E */
            }
            return pdfTableE;
        }

        private void frmBoletaPagoXPlanilla_Load(object sender, EventArgs e)
        {
            DataTable odtA = new DataTable();
            DataTable odtAños = new DataTable();
            DataTable odtPlanilla = new DataTable();

            CapaDeNegocios.Reportes.cBoletaPago oBoletaPago = new CapaDeNegocios.Reportes.cBoletaPago();
            CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

            if (cDatosGeneralesEmpresa.RUC == "20200737211")
            {
                chkIncluirLogo.Checked = true;
            }

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
        }

        private void dgvBoletaPago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numero_filas = dgvBoletaPago.Rows.Count;
            if (e.RowIndex != -1)
            {
                sidtplanilla = Convert.ToInt32(dgvBoletaPago.Rows[e.RowIndex].Cells[0].Value);
                sidtregimenlaboral = Convert.ToInt32(dgvBoletaPago.Rows[e.RowIndex].Cells[1].Value);
                sMes = dgvBoletaPago.Rows[e.RowIndex].Cells[3].Value.ToString();
                sAño = dgvBoletaPago.Rows[e.RowIndex].Cells[4].Value.ToString();
                plantilla = dgvBoletaPago.Rows[e.RowIndex].Cells[10].Value.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //PdfWriter.GetInstance(pdfDoc, stream);
            CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

            pmes = cboMes.GetItemText(this.cboMes.SelectedItem);
            paño = cboAño.GetItemText(this.cboAño.SelectedItem);

            switch (pmes) {
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

            dgvBoletaPago.DataSource = oPlanilla.ListarPlanillaX(pmes,paño );

            int numero_boleta_pago = dgvBoletaPago.Rows.Count;
            
            if (numero_boleta_pago > 0)
            {
                dgvBoletaPago.Columns[0].Visible = false;
                dgvBoletaPago.Columns[1].Visible = false;
                dgvBoletaPago.Columns[3].Visible = false;
                dgvBoletaPago.Columns[4].Visible = false;

                dgvBoletaPago.Rows[0].Cells[5].Selected = true;

                sidtplanilla = Convert.ToInt32(dgvBoletaPago.Rows[0].Cells[0].Value);
                sidtregimenlaboral = Convert.ToInt32(dgvBoletaPago.Rows[0].Cells[1].Value);
                sMes = dgvBoletaPago.Rows[0].Cells[3].Value.ToString();
                sAño = dgvBoletaPago.Rows[0].Cells[4].Value.ToString();
                plantilla = dgvBoletaPago.Rows[0].Cells[10].Value.ToString();
            }
            if (numero_boleta_pago==0)
                MessageBox.Show("No hay datos para esta consulta.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnImprimirSegundoFormato_Click(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo(@"C:\PDFs\BoletaPagoPlanilla2.pdf");
            bool estaAbierto = false;
            estaAbierto = IsFileinUse(file, @"C:\PDFs\BoletaPagoPlanilla2.pdf");

            boleta_pago_vacia = false;

            if (plantilla != "REGIDORES")
            {
                if (!estaAbierto)
                {
                    exportar_a_pdf2();
                }
                else
                {
                    MessageBox.Show("Por favor cerrar BoletaPagoPlanilla2.pdf", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("La plantilla regidores no cuenta con Boleta de Pago.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void exportar_a_pdf2()
        {
            CapaDeNegocios.Reportes.cBoletaPago oBoletaPago = new CapaDeNegocios.Reportes.cBoletaPago();
            DataTable odtA = new DataTable();

            //PdfWriter.GetInstance(pdfDoc, stream);
            DataTable odtPlanilla = new DataTable();
            CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

            Paragraph paragraph = new Paragraph();
            Paragraph paragraph2 = new Paragraph();
            Paragraph paragraph3 = new Paragraph();

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            //using (FileStream stream = new FileStream(folderPath + "Graphics.pdf", FileMode.Create))
            //{


            // Add a new page to the pdf file
            //pdfDoc.NewPage();
            Document pdfDoc = new Document(PageSize.A4, 9, 9, 10, 10);

            if (rdbVertical.Checked == true)
                pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4);
            else
                pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());


            paragraph.Alignment = Element.ALIGN_CENTER;
            paragraph.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 8);
            paragraph.Add(" ");

            if (rdbVertical.Checked == true)
            {
                paragraph2.Alignment = Element.ALIGN_LEFT;
                paragraph2.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 8);
                paragraph2.Add("\n\n             ......................................                              ......................................                                ......................................                              ......................................");
                paragraph3.Alignment = Element.ALIGN_LEFT;
                paragraph3.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 8);
                paragraph3.Add("                  EMPLEADOR                                          TRABAJADOR                                          EMPLEADOR                                          TRABAJADOR");
            }
            else
            {
                paragraph2.Alignment = Element.ALIGN_LEFT;
                paragraph2.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 8);
                paragraph2.Add("\n\n             ......................................                              ......................................                                                                                                                                ......................................                              ......................................");
                paragraph3.Alignment = Element.ALIGN_LEFT;
                paragraph3.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 8);
                paragraph3.Add("                  EMPLEADOR                                          TRABAJADOR                                                                                                                                          EMPLEADOR                                          TRABAJADOR");
            }


            //PdfContentByte cb = writer.DirectContent;

            //pdfDoc.Open();
            /*
            cb.MoveTo(pdfDoc.PageSize.Width / 2,0);
            cb.LineTo( pdfDoc.PageSize.Width/2, pdfDoc.PageSize.Height);
            cb.Stroke();
            cb.MoveTo( 0 , pdfDoc.PageSize.Height/2 );
            cb.LineTo(pdfDoc.PageSize.Width, pdfDoc.PageSize.Height / 2);
            cb.Stroke();
            */

            /*              Llenar datagrids            */
            odtPlanilla = oPlanilla.ListarDetallePlanillaX(sidtplanilla);

            if (odtPlanilla.Rows.Count > 0)
            {

                FileStream fs = new FileStream(folderPath + "BoletaPagoPlanilla2.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fs);
                CreateHeaderFooter(ref pdfDoc);
                //Abrir pagina
                pdfDoc.Open();

                for (int jjj = 0; jjj < odtPlanilla.Rows.Count; jjj++)
                {
                    //recorrer trabajadores de una planilla
                    sidttrabajador = Convert.ToInt16(odtPlanilla.Rows[jjj][1]);

                    //obtener datagridview de trabajador
                    datagridviews_boleta_pago2();

                    if (boleta_pago_vacia)
                    {

                        MessageBox.Show("Boleta de pago vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MultiColumnText columns2 = new MultiColumnText();
                        columns2.AddRegularColumns(36f, pdfDoc.PageSize.Width - 36f, 24f, 1);
                        columns2.AddElement(paragraph);
                        pdfDoc.Add(columns2);
                        pdfDoc.Close();
                        //stream.Close();
                        writer.Close();
                        break;
                    }

                    //Total de filas en dgvBoletaPago_A, si es mayor a 0 procede a reporte
                    //instanciando pdfTable A , B , C , D , E
                    PdfPTable pdfTableD = new PdfPTable(dgvBoletaPago_D.ColumnCount);
                    PdfPTable pdfTableA = new PdfPTable(dgvBoletaPago_A.ColumnCount);
                    PdfPTable pdfTableB = new PdfPTable(dgvBoletaPago_B.ColumnCount);
                    PdfPTable pdfTableC = new PdfPTable(dgvBoletaPago_C.ColumnCount);
                    PdfPTable pdfTableE = new PdfPTable(dgvBoletaPago_E.ColumnCount);

                    //Nueva pagina
                    pdfDoc.NewPage();

                    //obtener pdfTableA,B,C,D,E 
                    pdfTableD = pdf_d(0, 100);
                    pdfTableA = pdf_a(0, 100);
                    pdfTableB = pdf_b(0, 100);
                    pdfTableC = pdf_c(0, 100);
                    pdfTableE = pdf_e2(0, 100);

                    //Columnas 
                    MultiColumnText columns = new MultiColumnText();
                    columns.AddRegularColumns(36f, pdfDoc.PageSize.Width - 36f, 24f, 1);


                    if (chkIncluirLogo.Checked)
                    {
                        string ruta = System.IO.Directory.GetCurrentDirectory();

                        string ruta_imagen = ruta + "\\logo-muni-fw.png";

                        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(ruta_imagen);
                        logo.ScalePercent(54f);
                        logo.SetAbsolutePosition(12f, pdfDoc.PageSize.Height - 100f);
                        logo.Border = 0;

                        PdfPTable pdftabledd = new PdfPTable(5);
                        float[] anchosNuevos = new float[] { 20, 100, 5, 20, 100 };
                        pdftabledd.SetWidths(anchosNuevos);
                        pdftabledd.WidthPercentage = 100;
                        pdftabledd.AddCell(logo);
                        pdftabledd.AddCell(pdfTableD);
                        pdftabledd.AddCell(paragraph);
                        pdftabledd.AddCell(logo);
                        pdftabledd.AddCell(pdfTableD);
                        columns.AddElement(pdftabledd);

                    }
                    else
                    {
                        columns.AddElement(pdfTableD);
                    }
                    //Agregando pdfTable A, B, C, D, E a pdfDoc
                    
                    columns.AddElement(paragraph);
                    columns.AddElement(pdfTableA);
                    columns.AddElement(pdfTableB);
                    columns.AddElement(pdfTableC);
                    columns.AddElement(paragraph);
                    columns.AddElement(pdfTableE);
                    columns.AddElement(paragraph2);
                    columns.AddElement(paragraph3);

                    pdfDoc.Add(columns);
                   
                }

                if (!boleta_pago_vacia)
                {
                    //int numero_pagina = writer.PageNumber;
                    //pdfDoc.Open();
                    pdfDoc.Close();
                    //stream.Close();
                    writer.Close();
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = "C:\\PDFs\\BoletaPagoPlanilla2.pdf";
                    proc.Start();
                }

            }
            else
            {
                MessageBox.Show("Planilla vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void datagridviews_boleta_pago2()
        {
            //bool dgv_boleta_pago = true;
             int contadorTablas= 0;

            DataTable odtA = new DataTable();
            DataTable odtB = new DataTable();
            DataTable odtC = new DataTable();
            DataTable odtD = new DataTable();
            DataTable odtE = new DataTable();
            DataTable odtF = new DataTable();
            DataTable odtG = new DataTable();
            DataTable odtH = new DataTable();
            DataTable odtI = new DataTable();
            DataTable odtD2 = new DataTable();
            DataTable odtEB = new DataTable();
            DataTable odtAB = new DataTable();
            DataTable odtA2 = new DataTable();
            DataTable odtBB = new DataTable();
            DataTable odtB2 = new DataTable();
            DataTable odtCB = new DataTable();
            DataTable odtC2 = new DataTable();
            DataTable odtOB = new DataTable();
            DataTable odtE2 = new DataTable();

            DataTable odtID = new DataTable();

            DataTable odtC3 = new DataTable();

            DataTable odtPlanilla = new DataTable();

            DataRow drFilaD = odtD.NewRow();
            DataRow drFilaF = odtF.NewRow();
            DataRow drFilaEB = odtEB.NewRow();
            DataRow drFilaAB = odtAB.NewRow();
            DataRow drFilaBB = odtBB.NewRow();
            DataRow drFilaCB = odtCB.NewRow();
            DataRow drFilaOB = odtOB.NewRow();
            DataRow drFilaC3 = odtC3.NewRow();

            CapaDeNegocios.Reportes.cBoletaPago oBoletaPago = new CapaDeNegocios.Reportes.cBoletaPago();
            CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();
            CapaDeNegocios.Planillas.cDetallePlanillaIngresos oDetallePlanillaIngresos = new CapaDeNegocios.Planillas.cDetallePlanillaIngresos();
            CapaDeNegocios.Planillas.cDetallePlanillaDescuentos oDetallePlanillaDescuentos = new CapaDeNegocios.Planillas.cDetallePlanillaDescuentos();
            CapaDeNegocios.Planillas.cDetallePlanillaATrabajador oDetallePlanillaATrabajador = new CapaDeNegocios.Planillas.cDetallePlanillaATrabajador();
            CapaDeNegocios.Planillas.cDetallePlanillaAEmpleador oDetallePlanillaAEmpleador = new CapaDeNegocios.Planillas.cDetallePlanillaAEmpleador();

            //odtPlanilla = oPlanilla.ListarDetallePlanillaX(sidtplanilla);

            int dias_laborados = 0;
            int mes_dias = 0;

            //sidttrabajador = Convert.ToInt16(odtPlanilla.Rows[iii][1]);

            //*-------------Primera parte de la boleta de pago */ 
            odtD.Columns.Clear();
            odtD.Rows.Clear();

            odtD.Columns.Add(" ", typeof(string));
            odtD.Columns.Add("  ", typeof(string));

            drFilaD = odtD.NewRow();
            drFilaD.Delete();
            drFilaD[0] = "RUC:"; drFilaD[1] = Settings.Default.RUC;
            odtD.Rows.InsertAt(drFilaD, 0);

            drFilaD = odtD.NewRow();
            drFilaD.Delete();
            drFilaD[0] = "EMPLEADOR:"; drFilaD[1] = Settings.Default.Empresa;
            odtD.Rows.InsertAt(drFilaD, 1);

            drFilaD = odtD.NewRow();
            drFilaD.Delete();
            drFilaD[0] = "PERIODO:"; drFilaD[1] = sMes + " / " + sAño;
            odtD.Rows.InsertAt(drFilaD, 2);

            drFilaD = odtD.NewRow();
            drFilaD.Delete();
            drFilaD[0] = "PLANILLA ELECTRONICA "; drFilaD[1] = "NUMERO DE ORDEN:";
            odtD.Rows.InsertAt(drFilaD, 3);

            odtEB.Columns.Clear();
            odtEB.Rows.Clear();

            odtEB.Columns.Add("   ");
            drFilaEB[0] = " ";
            odtEB.Rows.InsertAt(drFilaEB, 0);
            drFilaEB = odtEB.NewRow();
            drFilaEB[0] = " ";
            odtEB.Rows.InsertAt(drFilaEB, 1);
            drFilaEB = odtEB.NewRow();
            drFilaEB[0] = " ";
            odtEB.Rows.InsertAt(drFilaEB, 2);
            drFilaEB = odtEB.NewRow();
            drFilaEB[0] = " ";
            odtEB.Rows.InsertAt(drFilaEB, 3);

            odtD2 = MergeTablesByIndex(odtD, odtEB);
            odtD2 = MergeTablesByIndex(odtD2, odtD);

            /*------------Fin primera parte de la boleta de pago */

            /*---------inicio parte a de boleta de pago */
            odtA.Columns.Clear();
            odtA.Rows.Clear();
            odtA = oBoletaPago.ListarPlanillaXMesYRegimenLaboralYTrabajadorA(sidtplanilla, sidtregimenlaboral, sidttrabajador, pmes, pmes_nro, paño);

            odtA.Columns.Add("SITUACION", typeof(string));

            if (odtA.Rows.Count > 0)
            {

                odtA.Rows[0][2] = "ACTIVO O SUBSIDIADO";

                odtAB.Columns.Clear();
                odtAB.Rows.Clear();
                odtAB.Columns.Add(" ");
                for (int kkk = 0; kkk < odtA.Rows.Count; kkk++)
                {
                    drFilaAB = odtAB.NewRow();
                    drFilaAB[0] = "";
                    odtAB.Rows.InsertAt(drFilaAB, kkk);
                }

                odtA2 = MergeTablesByIndex(odtA, odtAB);
                odtA2 = MergeTablesByIndex(odtA2, odtA);

                /*---------fin de parte a de boleta de pago */

                /* Parte B  */

                odtB.Columns.Clear();
                odtB.Rows.Clear();
                odtB = oBoletaPago.ListarPlanillaXMesYRegimenLaboralYTrabajadorB(sidtplanilla, sidtregimenlaboral, sidttrabajador, pmes, pmes_nro, paño);

                odtBB.Columns.Clear();
                odtBB.Rows.Clear();

                odtBB.Columns.Add(" ");

                for (int kkk = 0; kkk < odtB.Rows.Count; kkk++)
                {
                    drFilaBB = odtBB.NewRow();
                    drFilaBB[0] = "";
                    odtBB.Rows.InsertAt(drFilaBB, kkk);
                }

                odtB2 = MergeTablesByIndex(odtB, odtBB);
                odtB2 = MergeTablesByIndex(odtB2, odtB);

                /* Fin Parte B */


                /*--------- inicio de parte c de boleta de pago, donde se aumentan columnas y se calcula dias no laborados asi como total de horas y minutos */
                odtC.Columns.Clear();
                odtC.Rows.Clear();
                odtC = oBoletaPago.ListarPlanillaXMesYRegimenLaboralYTrabajadorC(sidtplanilla, sidtregimenlaboral, sidttrabajador, pmes, pmes_nro, paño);

                odtC.Columns.Add("DIAS NO LABORADOS", typeof(string));
                odtC.Columns.Add("DIAS SUBSIDIADOS", typeof(string));
                odtC.Columns.Add("CONDICION", typeof(string));
                odtC.Columns.Add("TOTAL HORAS", typeof(string));
                odtC.Columns.Add("MINUTOS", typeof(string));
                odtC.Columns.Add("TOTAL HORAS ", typeof(string));
                odtC.Columns.Add("MINUTOS ", typeof(string));

                dias_laborados = Convert.ToInt32(odtC.Rows[0][0]);

                mes_dias = nro_dias_mes(8, 2016);

                odtC.Rows[0][1] = mes_dias - dias_laborados;
                odtC.Rows[0][2] = 0;
                odtC.Rows[0][3] = "Domiciliado";
                odtC.Rows[0][4] = dias_laborados * 8;
                //odtC.Rows[0][5] = dias_laborados * 8 * 60;
                odtC.Rows[0][5] = 0;

                odtCB.Columns.Clear();
                odtCB.Rows.Clear();

                odtCB.Columns.Add(" ");

                for (int kkk = 0; kkk < odtC.Rows.Count; kkk++)
                {
                    drFilaCB = odtCB.NewRow();
                    drFilaCB[0] = "";
                    odtCB.Rows.InsertAt(drFilaCB, kkk);
                }

                odtC2 = MergeTablesByIndex(odtC, odtCB);
                odtC2 = MergeTablesByIndex(odtC2, odtC);

                /*------------fin parte c de boleta de pago*/

                /*---------------Inicio de Obligaciones de boleta de pago - Ingresos*/
                odtE.Columns.Clear();
                odtE.Rows.Clear();
                odtE = oDetallePlanillaIngresos.ListarPlanillaXIngresosXBoletaPago(sidtplanilla, sidtregimenlaboral, sidttrabajador);

                odtG.Columns.Clear();
                odtG.Rows.Clear();
                odtG = oDetallePlanillaDescuentos.ListarPlanillaXDescuentosXBoletaPago(sidtplanilla, sidtregimenlaboral, sidttrabajador);

                odtH.Columns.Clear();
                odtH.Rows.Clear();
                odtH = oDetallePlanillaATrabajador.ListarPlanillaATrabajadorXBoletaPago(sidtplanilla, sidtregimenlaboral, sidttrabajador);


                contadorTablas = odtE.Rows.Count;

                if (contadorTablas < (odtG.Rows.Count + odtH.Rows.Count))
                {
                    contadorTablas = odtG.Rows.Count + odtH.Rows.Count;
                }

                odtF.Columns.Clear();
                odtF.Rows.Clear();

                odtF.Columns.Add("Ingresos ", typeof(string));
                odtF.Columns.Add("S/.", typeof(string));
                odtF.Columns.Add("Descuentos ", typeof(string));
                odtF.Columns.Add("S/ .", typeof(string));
                odtF.Columns.Add("Aportaciones ", typeof(string));
                odtF.Columns.Add("S /.", typeof(string));

                for (int i = 0; i < contadorTablas; i++)
                {
                    drFilaF = odtF.NewRow();
                    drFilaF.Delete();
                    odtF.Rows.InsertAt(drFilaF, i);
                }

                

                if (odtE.Rows.Count > 0)
                {
                   
                    for (int k = 0; k < odtE.Rows.Count; k++)
                    {
                        odtF.Rows[k][0] = odtE.Rows[k][0];
                        odtF.Rows[k][1] = odtE.Rows[k][1];
                    }
                }

                

                if (odtG.Rows.Count > 0)
                {
                    for (int k = 0; k < odtG.Rows.Count; k++)
                    {
                        odtF.Rows[k][2] = odtG.Rows[k][0];
                        odtF.Rows[k][3] = odtG.Rows[k][1];
                    }
                }

                

                if (odtH.Rows.Count > 0)
                {
                    for (int k = 0; k < odtH.Rows.Count; k++)
                    {
                        odtF.Rows[k + odtG.Rows.Count][2] = odtH.Rows[k][0];
                        odtF.Rows[k + odtG.Rows.Count][3] = odtH.Rows[k][1];
                    }
                }

                /*------------Calculando el Neto S/.*/

                decimal dIngresos = 0;
                decimal dIngresosParcial = 0;
                decimal dDescuentos = 0;
                decimal dEgresosParcial = 0;
                decimal dNeto = 0;
                decimal dTrabajador = 0;


                for (int k = 0; k < odtF.Rows.Count; k++)
                {
                    if (odtF.Rows[k][1].ToString() == "")
                        dIngresosParcial = 0;
                    else
                        dIngresosParcial = Convert.ToDecimal(odtF.Rows[k][1].ToString());

                    if (odtF.Rows[k][3].ToString() == "")
                        dEgresosParcial = 0;
                    else
                        dEgresosParcial = Convert.ToDecimal(odtF.Rows[k][3].ToString());

                    dIngresos += dIngresosParcial;
                    dDescuentos += dEgresosParcial;
                }

                drFilaF = odtF.NewRow();
                drFilaF.Delete();
                drFilaF[0] = " ";
                drFilaF[1] = " ";
                drFilaF[2] = " ";
                drFilaF[3] = " ";
                odtF.Rows.InsertAt(drFilaF, odtF.Rows.Count);


                /* Ingresos y Egresos */
                odtID = oDetallePlanillaATrabajador.ListarDetallePlanillaXTrabajador(sidtplanilla, sidtregimenlaboral, sidttrabajador);

                dIngresos = Convert.ToDecimal(odtID.Rows[0][1]);
                dTrabajador = Convert.ToDecimal(odtID.Rows[0][2]);
                dDescuentos = Convert.ToDecimal(odtID.Rows[0][4]);

                dNeto = dIngresos - dDescuentos - dTrabajador;

                drFilaF = odtF.NewRow();
                drFilaF.Delete();
                drFilaF[0] = "Total Ingresos";
                drFilaF[1] = dIngresos.ToString();
                drFilaF[2] = "Total Descuentos ";
                drFilaF[3] = (dDescuentos + dTrabajador).ToString();
                odtF.Rows.InsertAt(drFilaF, odtF.Rows.Count);



                drFilaF = odtF.NewRow();
                drFilaF.Delete();
                drFilaF[0] = "Neto a Pagar";
                drFilaF[5] = dNeto.ToString();
                odtF.Rows.InsertAt(drFilaF, odtF.Rows.Count);
                

                /*-----------Fin Calculando el Neto*/

                
                
                /*-----------Inicio Aportaciones del Empleador*/
                odtI = oDetallePlanillaAEmpleador.ListarPlanillaAEmpleadorXBoletaPago(sidtplanilla, sidtregimenlaboral, sidttrabajador);

                if (odtI.Rows.Count > 0)
                {
                    
                    for (int k = 0; k < odtI.Rows.Count; k++)
                    {
                        odtF.Rows[k][4] = odtI.Rows[k][0];
                        odtF.Rows[k][5] = odtI.Rows[k][1];
                    }
                }
                /*------------Fin Aportaciones del Empleador*/

                odtOB.Columns.Clear();
                odtOB.Rows.Clear();

                odtOB.Columns.Add(" ");

                for (int kkk = 0; kkk < odtF.Rows.Count; kkk++)
                {
                    drFilaOB = odtOB.NewRow();
                    drFilaOB[0] = "";
                    odtOB.Rows.InsertAt(drFilaOB, kkk);
                }

                odtE2 = MergeTablesByIndex(odtF, odtOB);
                odtE2 = MergeTablesByIndex(odtE2, odtF);

                /*----------------Fin de obligaciones de boleta de pago - Ingresos*/

                //dgvBoletaPago_D.DataSource = odtD;
                dgvBoletaPago_D.DataSource = odtD2;
                //dgvBoletaPago_A.DataSource = odtA;
                dgvBoletaPago_A.DataSource = odtA2;
                dgvBoletaPago_B.DataSource = odtB2;
                //dgvBoletaPago_B.DataSource = odtA;
                dgvBoletaPago_C.DataSource = odtC2;
                dgvBoletaPago_E.DataSource = odtE2;

            }
            else
            {
                //MessageBox.Show("Boleta de pago vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                boleta_pago_vacia = true;
            }
        }
    }
}
