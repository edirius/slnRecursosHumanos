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

namespace CapaUsuario.Reportes
{
    public partial class frmBoletaPagoXPlanilla : Form
    {

        int sidtregimenlaboral = 0;

        string sMes = "";
        string sAño = "";

        int sidttrabajador = 0;
        int sidtplanilla = 0;

        int iii = 0;
        int total_trabajadores = 0;

        string folderPath = "C:\\PDFs\\";

        Document pdfDoc = new Document(PageSize.A4, 9, 9, 10, 10);
 
        PdfPCell cell;

        Paragraph paragraph = new Paragraph();
        Paragraph paragraph2 = new Paragraph();
        Paragraph paragraph3 = new Paragraph();


        //PdfWriter writer = PdfWriter.GetInstance(new Document(PageSize.A4, 9, 9, 10, 10), new FileStream("C:\\PDFs\\" + "BoletaPago.pdf", FileMode.Create));

        public frmBoletaPagoXPlanilla()
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo("C:\\PDFs\\BPP.pdf");
            bool estaAbierto = IsFileinUse(file, "C:\\PDFs\\BPP.pdf");
 
            if (!estaAbierto)
            {
                //datagridviews_boleta_pago();
                exportar_a_pdf();
            }
            else
                MessageBox.Show("Por favor cerrar BoletaPagoPlanilla.pdf", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
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

        private void exportar_a_pdf()
        {

            
            //PdfWriter.GetInstance(pdfDoc, stream);
            DataTable odtPlanilla = new DataTable();
            CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            //using (FileStream stream = new FileStream(folderPath + "Graphics.pdf", FileMode.Create))
            //{


            // Add a new page to the pdf file
            //pdfDoc.NewPage();

            pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4);

            paragraph.Alignment = Element.ALIGN_CENTER;
            paragraph.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 8);
            paragraph.Add(" ");


            paragraph2.Alignment = Element.ALIGN_LEFT;
            paragraph2.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 8);
            paragraph2.Add("\n\n             ......................................                              ......................................");


            paragraph3.Alignment = Element.ALIGN_LEFT;
            paragraph3.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 8);
            paragraph3.Add("               EMPLEADOR                                          TRABAJADOR");


            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(folderPath + "BPP.pdf", System.IO.FileMode.Create));
            int total_paginas_pdf = writer.PageNumber - 1;
            CreateHeaderFooter(ref pdfDoc, total_paginas_pdf);
            pdfDoc.Open();
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

            /*     Llenar datagrids   */
            odtPlanilla = oPlanilla.ListarDetallePlanillaX(sidtplanilla);

            

            for (int jjj=0; jjj<odtPlanilla.Rows.Count ; jjj++)
            {
                
                
                //recorrer trabajadores de una planilla
                sidttrabajador = Convert.ToInt16(odtPlanilla.Rows[jjj][1]);
                
                //obtener datagridview de trabajador
                datagridviews_boleta_pago();

                //instanciando pdfTable A , B , C , D , E
                PdfPTable pdfTableD = new PdfPTable(dgvBoletaPago_D.ColumnCount);
                PdfPTable pdfTableA = new PdfPTable(dgvBoletaPago_A.ColumnCount);
                PdfPTable pdfTableB = new PdfPTable(dgvBoletaPago_B.ColumnCount);
                PdfPTable pdfTableC = new PdfPTable(dgvBoletaPago_C.ColumnCount);
                PdfPTable pdfTableE = new PdfPTable(dgvBoletaPago_E.ColumnCount);

                //obtener pdfTableA,B,C,D,E 
                /*
                if (jjj % 2 == 0) {
                    pdfTableD = pdf_d(0);
                    pdfTableA = pdf_a(0);
                    pdfTableB = pdf_b(0);
                    pdfTableC = pdf_c(0);
                    pdfTableE = pdf_e(0);
                }
                else {
                    pdfTableD = pdf_d(2);
                    pdfTableA = pdf_a(2);
                    pdfTableB = pdf_b(2);
                    pdfTableC = pdf_c(2);
                    pdfTableE = pdf_e(2);
                }*/

                pdfTableD = pdf_d(0,100);
                pdfTableA = pdf_a(0,100);
                pdfTableB = pdf_b(0,100);
                pdfTableC = pdf_c(0,100);
                pdfTableE = pdf_e(0,100);

                //Nueva pagina
                
                //if (jjj % 2 == 0)
                    pdfDoc.NewPage();
                //Columnas 
                MultiColumnText columns = new MultiColumnText();
                columns.AddRegularColumns(36f, pdfDoc.PageSize.Width - 36f, 24f, 2);

                //Abrir pagina
 
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
            /*  fin llenar datagrids */

                //pdfDoc.Open();
                pdfDoc.Close();
                //stream.Close();
                writer.Close();
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "C:\\PDFs\\BPP.pdf";
                proc.Start();                

 

        }

 

        public void CreateHeaderFooter(ref Document _document, int total_paginas )
        {
            var headerfooter = FontFactory.GetFont("Arial", 8);
            HeaderFooter header = (new HeaderFooter(new Phrase("Boleta de Pago", headerfooter), false));
            header.BorderColorTop = new iTextSharp.text.Color(System.Drawing.Color.Red);
            header.BorderWidthTop = 0f;
            _document.Header = header;
            HeaderFooter Footer = new HeaderFooter(new Phrase(" ", headerfooter), true);
            Footer.BorderWidthBottom = 0f;
            _document.Footer = Footer;
        }

        private void datagridviews_boleta_pago()
        {
            DataTable odtA = new DataTable();
            DataTable odtB = new DataTable();
            DataTable odtC = new DataTable();
            DataTable odtD = new DataTable();
            DataTable odtE = new DataTable();
            DataTable odtF = new DataTable();
            DataTable odtG = new DataTable();
            DataTable odtH = new DataTable();
            DataTable odtI = new DataTable();

            DataTable odtPlanilla = new DataTable();

            DataRow drFilaD = odtD.NewRow();
            DataRow drFilaF = odtF.NewRow();



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

                odtD.Columns.Add("RUC:", typeof(string));
                odtD.Columns.Add("20226560824", typeof(string));

                drFilaD = odtD.NewRow();
                drFilaD.Delete();
                drFilaD[0] = "EMPLEADOR:"; drFilaD[1] = "MUNICIPALIDAD DISTRITAL DE CCATCAA";
                odtD.Rows.InsertAt(drFilaD, 1);

                drFilaD = odtD.NewRow();
                drFilaD.Delete();
                drFilaD[0] = "PERIODO:"; drFilaD[1] = sMes + "/" + sAño;
                odtD.Rows.InsertAt(drFilaD, 2);

                drFilaD = odtD.NewRow();
                drFilaD.Delete();
                drFilaD[0] = "PDT PLANILLA ELECTRONICA - PLAME "; drFilaD[1] = "NUMERO DE ORDEN:";
                odtD.Rows.InsertAt(drFilaD, 3);
                /*------------Fin primera parte de la boleta de pago */


                /*---------inicio parte a de boleta de pago */
                odtA.Columns.Clear();
                odtA.Rows.Clear();
                odtA = oBoletaPago.ListarPlanillaXMesYRegimenLaboralYTrabajadorA(sidtplanilla, sidtregimenlaboral, sidttrabajador);

                odtA.Columns.Add("DOCUMENTO DE IDENTIDAD", typeof(string)).SetOrdinal(0);
                odtA.Columns.Add("SITUACION", typeof(string));

                if (odtA.Rows.Count > 0)
                {

                    odtA.Rows[0][3] = "ACTIVO O SUBSIDIADO";
                    odtA.Rows[0][0] = "DNI";

                    /*---------fin de parte a de boleta de pago */


                    /*--------- inicio de parte c de boleta de pago, donde se aumentan columnas y se calcula dias no laborados asi como total de horas y minutos */
                    odtC.Columns.Clear();
                    odtC.Rows.Clear();
                    odtC = oBoletaPago.ListarPlanillaXMesYRegimenLaboralYTrabajadorC(sidtplanilla, sidtregimenlaboral, sidttrabajador);

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
                    odtC.Rows[0][5] = dias_laborados * 8 * 60;
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
                    decimal dEgresos = 0;
                    decimal dEgresosParcial = 0;
                    decimal dNeto = 0;

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
                        dEgresos += dEgresosParcial;
                    }

                    dNeto = dIngresos - dEgresos;

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
                    odtI = oDetallePlanillaAEmpleador.ListarPlanillaAEmpleadorXBoletaPago(sidtplanilla, sidtregimenlaboral, sidttrabajador);

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

                    /*----------------Fin de obligaciones de boleta de pago - Ingresos*/

                    dgvBoletaPago_D.DataSource = odtD;
                    dgvBoletaPago_A.DataSource = odtA;
                    dgvBoletaPago_B.DataSource = oBoletaPago.ListarPlanillaXMesYRegimenLaboralYTrabajadorB(sidtplanilla, sidtregimenlaboral, sidttrabajador);
                    dgvBoletaPago_C.DataSource = odtC;
                    dgvBoletaPago_E.DataSource = odtF;

                     
                }
                else
                    MessageBox.Show("Boleta de pago vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

 

        private PdfPTable pdf_d( int alineacion, int ancho  )
        {
            PdfPTable pdfTableD = new PdfPTable(dgvBoletaPago_D.ColumnCount);
            //Creating iTextSharp Table from the DataTable data
            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 7);
            iTextSharp.text.Font fuenteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 9, 1, iTextSharp.text.Color.BLUE);

            if (dgvBoletaPago_D.ColumnCount > 0)
            {

                Phrase objH_D = new Phrase("A", fuente);
                Phrase objP_D = new Phrase("A", fuente);
                float[] headerwidths_D = GetTamañoColumnas(dgvBoletaPago_D);
                pdfTableD.DefaultCell.Padding = 0;
                pdfTableD.HorizontalAlignment = alineacion;
                
                pdfTableD.DefaultCell.BorderWidth = 1;
                pdfTableD.SetWidths(headerwidths_D);
                pdfTableD.WidthPercentage = ancho;
                

                /* -------------------------------INICIO DGVBOLETA_D */
                foreach (DataGridViewColumn column in dgvBoletaPago_D.Columns)
                {
                    cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                    cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                    pdfTableD.AddCell(cell);
                }

                for (int i = 0; i < dgvBoletaPago_D.RowCount - 1; i++)
                {
                    for (int j = 0; j < dgvBoletaPago_D.ColumnCount; j++)
                    {
                        cell = new PdfPCell((new Phrase(dgvBoletaPago_D[j, i].Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                        cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        pdfTableD.AddCell(cell);
                    }
                    pdfTableD.CompleteRow();
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
                float[] headerwidths_A = GetTamañoColumnas(dgvBoletaPago_A);
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
                    if (k == 0)
                    {
                        cell.Colspan = 2;
                        cell.HorizontalAlignment = 1;
                    }

                    if (k != 1)
                    {
                        if (k > 1)
                            cell.Rowspan = 2;

                        cell.HorizontalAlignment = 1;
                        pdfTableA.AddCell(cell);
                    }

                    k++;
                }

                foreach (DataGridViewColumn column in dgvBoletaPago_A.Columns)
                {

                    if (o == 0)
                    {
                        cell = new PdfPCell((new Phrase("TIPO", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                        cell.Rowspan = 1;
                        cell.Colspan = 1;
                        cell.HorizontalAlignment = 1;
                        cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        pdfTableA.AddCell(cell);
                    }

                    if (o == 1)
                    {
                        cell = new PdfPCell((new Phrase("NUMERO", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                        cell.Rowspan = 1;
                        cell.Colspan = 1;
                        cell.HorizontalAlignment = 1;
                        cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        pdfTableA.AddCell(cell);
                    }



                    o++;

                }

                for (int i = 0; i < dgvBoletaPago_A.RowCount - 1; i++)
                {
                    for (int j = 0; j < dgvBoletaPago_A.ColumnCount; j++)
                    {
                        objP_A = new Phrase(dgvBoletaPago_A[j, i].Value.ToString(), fuente);
                        pdfTableA.AddCell(objP_A);
                    }
                    pdfTableA.CompleteRow();
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

            if (dgvBoletaPago_B.ColumnCount > 0)
            {

                Phrase objH_B = new Phrase("A", fuenteTitulo);
                Phrase objP_B = new Phrase("A", fuente);
                float[] headerwidths_B = GetTamañoColumnas(dgvBoletaPago_B);
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
                    pdfTableB.AddCell(cell);
                }

                for (int i = 0; i < dgvBoletaPago_B.RowCount - 1; i++)
                {
                    for (int j = 0; j < dgvBoletaPago_B.ColumnCount; j++)
                    {
                        objP_B = new Phrase(dgvBoletaPago_B[j, i].Value.ToString(), fuente);
                        pdfTableB.AddCell(objP_B);
                    }
                    pdfTableB.CompleteRow();
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
                float[] headerwidths_C = GetTamañoColumnas2(dgvBoletaPago_C);
                pdfTableC.DefaultCell.Padding = 0;
                pdfTableC.HorizontalAlignment = alineacion;
                pdfTableC.DefaultCell.BorderWidth = 1;
                pdfTableC.SetWidths(headerwidths_C);
                pdfTableC.WidthPercentage = ancho;
                /* -------------------------------INICIO DGVBOLETA_C */

                o = 0;
                foreach (DataGridViewColumn column in dgvBoletaPago_C.Columns)
                {

                    if (o == 4)
                    {
                        cell = new PdfPCell((new Phrase("JORNADA ORDINARIA", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                        cell.Colspan = 2;
                        cell.Rowspan = 1;
                        cell.HorizontalAlignment = 1;
                        cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        pdfTableC.AddCell(cell);
                    }

                    if (o == 6)
                    {
                        cell = new PdfPCell((new Phrase("SOBRE TIEMPO", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                        cell.Colspan = 2;
                        cell.Rowspan = 1;
                        cell.HorizontalAlignment = 1;
                        cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        pdfTableC.AddCell(cell);
                    }

                    if (o < 4 || o > 7)
                    {
                        cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
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

                    if (k == 4 || k == 5 || k == 6 || k == 7)
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
                        objP_C = new Phrase(dgvBoletaPago_C[j, i].Value.ToString(), fuente);
                        pdfTableC.AddCell(objP_C);
                    }
                    pdfTableC.CompleteRow();
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
                float[] headerwidths_E = GetTamañoColumnas2(dgvBoletaPago_E);
                pdfTableE.DefaultCell.Padding = 0;
                pdfTableE.HorizontalAlignment = alineacion;
                pdfTableE.DefaultCell.BorderWidth = 1;
                pdfTableE.SetWidths(headerwidths_E);
                pdfTableE.WidthPercentage = ancho;

                /* -------------------------------INICIO DGVBOLETA_E */

                foreach (DataGridViewColumn column in dgvBoletaPago_E.Columns)
                {
                    cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                    cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                    pdfTableE.AddCell(cell);
                }

                for (int i = 0; i < dgvBoletaPago_E.RowCount - 1; i++)
                {
                    for (int j = 0; j < dgvBoletaPago_E.ColumnCount; j++)
                    {
                        objP_E = new Phrase(dgvBoletaPago_E[j, i].Value.ToString(), fuente);
                        pdfTableE.AddCell(objP_E);
                    }
                    pdfTableE.CompleteRow();
                }
                /* -------------------------------FIN DGVBOLETA_E */



            }

            return pdfTableE;
        }

        private void pdfTable_todos()
        {
            

            PdfPTable pdfTableD = new PdfPTable(dgvBoletaPago_D.ColumnCount);
            PdfPTable pdfTableA = new PdfPTable(dgvBoletaPago_A.ColumnCount);
            PdfPTable pdfTableB = new PdfPTable(dgvBoletaPago_B.ColumnCount);
            PdfPTable pdfTableC = new PdfPTable(dgvBoletaPago_C.ColumnCount);
            PdfPTable pdfTableE = new PdfPTable(dgvBoletaPago_E.ColumnCount);
  
            //Exporting to PDF

            //use a variable to let my code fit across the page...
            //string path = Server.MapPath("PDFs");
            //PdfWriter.GetInstance(doc1, new FileStream(path + "/Doc1.pdf", FileMode.Create));

            

        }

        /*
        private void dgvBoletaPago_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int numero_filas = dgvBoletaPago.Rows.Count;
            if (e.RowIndex != -1)
            {
                sidtplanilla = Convert.ToInt32(dgvBoletaPago.Rows[e.RowIndex].Cells[0].Value);
                sidtregimenlaboral = Convert.ToInt32(dgvBoletaPago.Rows[e.RowIndex].Cells[1].Value);
                sMes = dgvBoletaPago.Rows[e.RowIndex].Cells[3].Value.ToString();
                sAño = dgvBoletaPago.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }
        */

        private void frmBoletaPagoXPlanilla_Load(object sender, EventArgs e)
        {
            int numero_boleta_pago = 0;
            CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

            //dgvBoletaPago.DataSource = oPlanilla.ListarBoletaPagoXMesYRegimenLaboral() ;
            dgvBoletaPago.DataSource = oPlanilla.ListarPlanillaX();

            numero_boleta_pago = dgvBoletaPago.Rows.Count;

            if (numero_boleta_pago > 0) { 
                dgvBoletaPago.Columns[0].Visible = false;
                dgvBoletaPago.Columns[1].Visible = false;

            }
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
            }
        }
    }
}