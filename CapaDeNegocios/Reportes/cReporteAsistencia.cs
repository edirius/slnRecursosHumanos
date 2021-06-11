using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp;
using CapaDeNegocios.Asistencia;

namespace CapaDeNegocios.Reportes
{
    public class cReporteAsistencia
    {

        public void ImprimirReporteAsistenciaXTrabajador(cTrabajador oTrabajador,  cAsistenciaMes oAsistenciaMes )
        {
            //Creating iTextSharp Table from the DataTable data
            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 7);
            iTextSharp.text.Font fuenteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 9, 1, iTextSharp.text.Color.BLUE);

            cFilasPDF FilaTituloPrincipal = new cFilasPDF();

            cCeldaPDF TituloPrincipal = new cCeldaPDF();
            TituloPrincipal.Contenido = "Reporte de Asistencia";
            FilaTituloPrincipal.ListaCeldas.Add(TituloPrincipal);

            cFilasPDF FilaTitulo1 = new cFilasPDF();

            cCeldaPDF LabelEmpresa = new cCeldaPDF();
            LabelEmpresa.Contenido = "Empresa:";
            FilaTitulo1.ListaCeldas.Add(LabelEmpresa);

            cCeldaPDF NombreEmpresa = new cCeldaPDF();
            NombreEmpresa.Contenido = "Municipalidad Distrital de Maras";
            FilaTitulo1.ListaCeldas.Add(NombreEmpresa);

            cCeldaPDF LabelRuc = new cCeldaPDF();
            LabelRuc.Contenido = "RUC:";
            FilaTitulo1.ListaCeldas.Add(LabelRuc);

            cCeldaPDF NumeroRuc = new cCeldaPDF();
            NumeroRuc.Contenido = "20177432360";
            FilaTitulo1.ListaCeldas.Add(NumeroRuc);

            cCeldaPDF LabelFecha = new cCeldaPDF();
            LabelFecha.Contenido = "Fecha: ";
            FilaTitulo1.ListaCeldas.Add(LabelFecha);

            cCeldaPDF ValorFecha = new cCeldaPDF();
            ValorFecha.Contenido = DateTime.Now.ToString();
            FilaTitulo1.ListaCeldas.Add(ValorFecha);

            cFilasPDF FilaTitulos2 = new cFilasPDF();

            cCeldaPDF LabelDNI = new cCeldaPDF();
            LabelDNI.Contenido = "DNI: ";
            FilaTitulos2.ListaCeldas.Add(LabelDNI);

            cCeldaPDF NumeroDNI = new cCeldaPDF();
            NumeroDNI.Contenido = oTrabajador.Dni;
            FilaTitulos2.ListaCeldas.Add(NumeroDNI);

            cCeldaPDF LabelNombres = new cCeldaPDF();
            LabelNombres.Contenido = oTrabajador.ApellidoPaterno + " " + oTrabajador.ApellidoMaterno + ", " + oTrabajador.Nombres;
            FilaTitulos2.ListaCeldas.Add(LabelNombres);

            cFilasPDF FilaTitulos3 = new cFilasPDF();

            cCeldaPDF LabelCargo = new cCeldaPDF();
            LabelCargo.Contenido = "Cargo: ";
            FilaTitulos3.ListaCeldas.Add(LabelCargo);

            cCeldaPDF NombreCargo = new cCeldaPDF();
            NombreCargo.Contenido = "Cargo";
            FilaTitulos3.ListaCeldas.Add(NombreCargo);

            cCeldaPDF LabelPeriodo = new cCeldaPDF();
            LabelPeriodo.Contenido = "Periodo: ";
            FilaTitulos3.ListaCeldas.Add(LabelPeriodo);

            cCeldaPDF ValorFechas = new cCeldaPDF();
            ValorFechas.Contenido = oAsistenciaMes.InicioMes.ToShortDateString() + " Del: " + oAsistenciaMes.FinMes.ToShortDateString();
            FilaTitulos3.ListaCeldas.Add(ValorFechas);


            int semana = 1;
            foreach (cAsistenciaDia item in oAsistenciaMes.ListaAsistenciaDia)
            {
                if (item.Dia.DayOfWeek == DayOfWeek.Sunday)
                {
                    semana++;
                }
            }

            //PdfCell colTitulo = new Pdf;
            //Cell();
            //colTitulo.t
            //PdfPTable pdfTable = new PdfPTable(dgvPrueba.ColumnCount);

            //PdfPTable pdfTable2 = new PdfPTable(dgvAFP.ColumnCount);
            //PdfPTable pdfTableRedondear = new PdfPTable(dgvRedondear.ColumnCount);
            //PdfPTable pdfTableEEFF = new PdfPTable(dgvEEFF.ColumnCount);

            //Phrase objP = new Phrase("A", fuente);
            //Phrase objP2 = new Phrase("A", fuente);
            //Phrase objP3 = new Phrase("A", fuente);
            ////Phrase objH = new Phrase("A", fuenteTitulo);
            //PdfPCell cell;
            //PdfPCell cell2;
            //PdfPCell cell3;
            //PdfPCell cell4;

            //pdfTable.DefaultCell.Padding = 1;
            //pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            //pdfTable.DefaultCell.BorderWidth = 1;
            ////pdfTable.DefaultCell.FixedHeight = 600f;

            //pdfTable2.DefaultCell.Padding = 1;
            //pdfTable2.HorizontalAlignment = Element.ALIGN_LEFT;
            //pdfTable2.DefaultCell.BorderWidth = 1;

            //pdfTableRedondear.DefaultCell.Padding = 1;
            //pdfTableRedondear.HorizontalAlignment = Element.ALIGN_LEFT;
            //pdfTableRedondear.DefaultCell.BorderWidth = 1;

            //pdfTableEEFF.DefaultCell.Padding = 1;
            //pdfTableEEFF.HorizontalAlignment = Element.ALIGN_LEFT;
            //pdfTableEEFF.DefaultCell.BorderWidth = 1;

            //float[] headerwidths = GetTamañoColumnas(dgvPrueba);
            //float[] headerwidths2 = GetTamañoColumnas2(dgvAFP);
            //float[] headerwidths3 = GetTamañoColumnas2(dgvRedondear);
            //float[] headerwidths4 = GetTamañoColumnas2(dgvEEFF);
            ////float[] headerwidths = { 2f, 6f, 6f, 3f, 5f, 8f, 5f, 5f, 5f, 5f };

            ////cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#d1dbe0"));

            //pdfTable.SetWidths(headerwidths);
            //pdfTable.WidthPercentage = 100;

            //pdfTable2.SetWidths(headerwidths2);
            //pdfTable2.WidthPercentage = 100;

            //pdfTableRedondear.SetWidths(headerwidths3);
            //pdfTableRedondear.WidthPercentage = 100;

            //pdfTableEEFF.SetWidths(headerwidths4);
            //pdfTableEEFF.WidthPercentage = 100;

            //int iindice_nombre = 0;
            //int iindice_cargo = 0;
            //int iindice_fecha = 0;
            //int iindice_afi_com_cus = 0;

            ////Adding Header row
            //foreach (DataGridViewColumn column in dgvPrueba.Columns)
            //{
            //    cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
            //    //cell = new PdfPCell(new Phrase(column.HeaderText));
            //    //PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
            //    cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
            //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //    // objH = new Phrase(column.HeaderText, fuenteTitulo);
            //    pdfTable.AddCell(cell);
            //}

            ///*Indices de la secciones alineadas*/
            //iindice_nombre = BuscarIndiceColumna(odtPruebaCorta, "NOMBRE COMPLETO");
            //iindice_cargo = BuscarIndiceColumna(odtPruebaCorta, "CARGO");
            //iindice_fecha = BuscarIndiceColumna(odtPruebaCorta, "FECHA INICIO");
            //iindice_afi_com_cus = BuscarIndiceColumna(odtPruebaCorta, "AFIL. AFP/SNP \n\n COMIS. \n\n CUSP ");

            //for (int i = 0; i < dgvPrueba.RowCount - 1; i++)
            //{
            //    for (int j = 0; j < dgvPrueba.ColumnCount; j++)
            //    {
            //        //objP = new Phrase(dgvPrueba[j, i].Value.ToString(), fuente);

            //        cell = new PdfPCell((new Phrase(dgvPrueba[j, i].Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
            //        if (columnasFijas)
            //        {
            //            cell.FixedHeight = altoColumna;
            //        }

            //        //Alineando a la derecha la columna nº
            //        cell.HorizontalAlignment = Element.ALIGN_RIGHT;

            //        if (j == iindice_nombre || j == iindice_cargo || j == iindice_fecha || j == iindice_afi_com_cus)
            //            cell.HorizontalAlignment = Element.ALIGN_LEFT;

            //        pdfTable.AddCell(cell);
            //    }
            //    pdfTable.CompleteRow();
            //}

            ///* ---------------- dgvAFP */

            ////Adding Header row
            //foreach (DataGridViewColumn column in dgvAFP.Columns)
            //{
            //    cell2 = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
            //    //cell = new PdfPCell(new Phrase(column.HeaderText));
            //    //PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
            //    cell2.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
            //    // objH = new Phrase(column.HeaderText, fuenteTitulo);
            //    pdfTable2.AddCell(cell2);
            //}

            //for (int k = 0; k < dgvAFP.RowCount - 1; k++)
            //{
            //    for (int l = 0; l < dgvAFP.ColumnCount; l++)
            //    {
            //        cell = new PdfPCell((new Phrase(dgvAFP[l, k].Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));

            //        if (l == 1)
            //            cell.HorizontalAlignment = Element.ALIGN_RIGHT;

            //        pdfTable2.AddCell(cell);

            //    }
            //    pdfTable2.CompleteRow();
            //}

            ///*----------------fin dfvAFP*/

            ///* ------------- dgvRedondear ----------- */

            //foreach (DataGridViewColumn column in dgvRedondear.Columns)
            //{
            //    cell3 = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
            //    //cell = new PdfPCell(new Phrase(column.HeaderText));
            //    //PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
            //    cell3.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
            //    // objH = new Phrase(column.HeaderText, fuenteTitulo);
            //    pdfTableRedondear.AddCell(cell3);
            //}

            //for (int k = 0; k < dgvRedondear.RowCount - 1; k++)
            //{
            //    for (int l = 0; l < dgvRedondear.ColumnCount; l++)
            //    {
            //        cell3 = new PdfPCell((new Phrase(dgvRedondear[l, k].Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
            //        cell3.HorizontalAlignment = Element.ALIGN_RIGHT;
            //        pdfTableRedondear.AddCell(cell3);
            //    }
            //    pdfTableRedondear.CompleteRow();
            //}

            ///* -------------fin dgvRedondear ----------*/

            ///* ---------------- dgvEEFF */

            ////Adding Header row
            //foreach (DataGridViewColumn column in dgvEEFF.Columns)
            //{
            //    cell2 = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
            //    cell2.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
            //    pdfTableEEFF.AddCell(cell2);
            //}

            //for (int k = 0; k < dgvEEFF.RowCount - 1; k++)
            //{
            //    for (int l = 0; l < dgvEEFF.ColumnCount; l++)
            //    {
            //        cell2 = new PdfPCell((new Phrase(dgvEEFF[l, k].Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
            //        if (l == 1 || l == 2)
            //            cell2.HorizontalAlignment = Element.ALIGN_RIGHT;
            //        pdfTableEEFF.AddCell(cell2);
            //    }
            //}

            ///*----------------fin dgvEEFF*/

            ////Exporting to PDF
            //string folderPath = "C:\\PDFs\\";

            ////use a variable to let my code fit across the page...
            ////string path = Server.MapPath("PDFs");
            ////PdfWriter.GetInstance(doc1, new FileStream(path + "/Doc1.pdf", FileMode.Create));

            //if (!Directory.Exists(folderPath))
            //{
            //    Directory.CreateDirectory(folderPath);
            //}
            //using (FileStream stream = new FileStream(folderPath + "Planilla.pdf", FileMode.Create))
            //{

            //    Document pdfDoc = new Document(PageSize.A4, 9, 9, 30, 30);
            //    pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());



            //    Paragraph paragraph = new Paragraph();
            //    paragraph.Alignment = Element.ALIGN_CENTER;
            //    paragraph.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 12);
            //    paragraph.Add("MUNICIPALIDAD DISTRITAL DE MARAS \n UNIDAD DE PERSONAL \n ");
            //    paragraph.SpacingBefore = 0f;
            //    paragraph.SpacingAfter = 0f;


            //    Paragraph paragraph2 = new Paragraph();
            //    paragraph2.Alignment = Element.ALIGN_RIGHT;
            //    paragraph2.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            //    paragraph2.Add("PLANILLA Nº" + sNumeroPlanilla + " - " + saño + " \n ");
            //    paragraph2.SpacingBefore = 0f;
            //    paragraph2.SpacingAfter = 0f;
            //    paragraph2.SetLeading(0, 0);


            //    Paragraph paragraph3 = new Paragraph();
            //    paragraph3.Alignment = Element.ALIGN_CENTER;
            //    paragraph3.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            //    /*paragraph3.Add("PLANILLA DE RENUMERACIONES DEL PERSONAL DE " + sRegimenLaboral + " DE " + saño + " DE " + smes + ".");*/
            //    /*Titulo de planilla */
            //    paragraph3.Add(sdescripcion.ToString().ToUpper() + " DE " + smes + " DE " + saño + ".");
            //    paragraph3.SpacingBefore = 0f;
            //    paragraph3.SpacingAfter = 0f;


            //    Paragraph paragraph4 = new Paragraph();
            //    paragraph4.Alignment = Element.ALIGN_LEFT;
            //    paragraph4.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            //    paragraph4.IndentationLeft = 110f;
            //    paragraph4.SpacingAfter = 0;
            //    paragraph4.SpacingBefore = 0;


            //    string smeta_numero_con_ceros = string.Format("{0:000}", smeta_numero);

            //    paragraph4.Add("META:" + smeta_numero.PadLeft(3, '0') + " - " + smeta + ". \n\n");

            //    Paragraph paragraph40 = new Paragraph();
            //    paragraph40.Alignment = Element.ALIGN_LEFT;
            //    paragraph40.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            //    paragraph40.IndentationLeft = 110f;
            //    paragraph4.Add("FUENTE FINANCIAMIENTO:" + sfuentefinanciamiento + ". \n\n");
            //    paragraph40.SpacingAfter = 0;
            //    paragraph40.SpacingBefore = 0;


            //    Paragraph paragraph5 = new Paragraph();
            //    paragraph5.Alignment = Element.ALIGN_CENTER;
            //    paragraph5.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            //    paragraph5.Add("\n");

            //    DateTime fecha = DateTime.Now;

            //    Paragraph paragraph6 = new Paragraph();
            //    paragraph6.Alignment = Element.ALIGN_CENTER;
            //    paragraph6.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);

            //    CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

            //    fecha = Convert.ToDateTime(oPlanilla.ListarFechaPlanilla(sidtplanilla).Rows[0][1].ToString());

            //    paragraph6.Add("MARAS, " + String.Format("{0:dd}", fecha) + " DE " + String.Format("{0:MMMM}", fecha).ToUpper() + " DEL " + String.Format("{0:yyyy}", fecha) + ". \n");
            //    /*FEcha de hoy*/
            //    //paragraph6.Add("CCATCCA, " + String.Format("{0:dd}" , fecha) + " DE " + String.Format("{0:MMMM}", fecha).ToUpper() + " DEL " + String.Format("{0:yyyy}", fecha) + ". \n");




            //    PdfWriter.GetInstance(pdfDoc, stream);
            //    CreateHeaderFooter(ref pdfDoc);
            //    pdfDoc.Open();

            //    //string imageURL = "C:\\Users\\ADVANCE\\Source\\Repos\\slnRecursosHumanos\\slnRecursosHumanos\\Recursos Varios\\MUNICIPALIDAD-DISTRITAL-DE-CCATCCA-2.png";
            //    //string ruta = Directory.GetCurrentDirectory();
            //    string ruta = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            //    //string ruta2 = Application.StartupPath;
            //    //string ruta3 = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            //    //string[] palabras = ruta.Split('\\');

            //    //string ruta_imagen = palabras[0] + '\\' + palabras[1] + '\\' + palabras[2] + '\\' +
            //    //palabras[3] + '\\' + palabras[4] + '\\' + palabras[5] + '\\' + palabras[6] + '\\';

            //    //string ruta_carpeta = "Recursos Varios\\MUNICIPALIDAD-DISTRITAL-DE-CCATCCA-2.png";

            //    //ruta_imagen = ruta_imagen + ruta_carpeta ;

            //    //C:\\Users\\ADVANCE\\Source\\Repos\\slnRecursosHumanos\\slnRecursosHumanos\\CapaUsuario\\bin\\Debug
            //    //C:\\Users\\ADVANCE\\Source\\Repos\\slnRecursosHumanos\\slnRecursosHumanos\\CapaUsuario

            //    string ruta_imagen = ruta + "\\logo-muni-fw.png";

            //    string ruta_cuadro_oficinas = ruta + "\\LogoBicentenario2021.jpeg";

            //    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(ruta_imagen);
            //    logo.ScalePercent(64f);
            //    logo.SetAbsolutePosition(12f, pdfDoc.PageSize.Height - 100f);

            //    iTextSharp.text.Image oficinas = iTextSharp.text.Image.GetInstance(ruta_cuadro_oficinas);
            //    oficinas.ScalePercent(64f);
            //    oficinas.SetAbsolutePosition(pdfDoc.PageSize.Width - 150f, pdfDoc.PageSize.Height - 80f);

            //    //tabla que continene logo, meta y nº planilla
            //    PdfPTable tabla_bonus = new PdfPTable(3);
            //    tabla_bonus.DefaultCell.BorderWidth = 0;

            //    //tabla que continene rrhh, gerencia municipal, presupuesto y contabilidad
            //    PdfPTable tabla_firmas;
            //    PdfPTable tabla_firmas2;
            //    if (numeroRegimenLaboral == 1 || numeroRegimenLaboral == 2 || numeroRegimenLaboral == 4)
            //    {
            //        tabla_firmas = new PdfPTable(4);
            //        tabla_firmas2 = new PdfPTable(2);
            //        tabla_firmas.DefaultCell.BorderWidth = 0;
            //        tabla_firmas2.DefaultCell.BorderWidth = 0;
            //        //FIRMAS
            //        Paragraph firma_rrhh = new Paragraph();
            //        firma_rrhh.Alignment = Element.ALIGN_CENTER;
            //        firma_rrhh.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            //        firma_rrhh.Add("............................................. \n RECURSOS HUMANOS");

            //        Paragraph firma_gm = new Paragraph();
            //        firma_gm.Alignment = Element.ALIGN_CENTER;
            //        firma_gm.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            //        firma_gm.Add("............................................. \n GERENCIA MUNICIPAL");

            //        Paragraph firma_pre = new Paragraph();
            //        firma_pre.Alignment = Element.ALIGN_CENTER;
            //        firma_pre.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            //        firma_pre.Add("............................................. \n CONTABILIDAD Y PRESUPUESTO ");

            //        Paragraph firma_con = new Paragraph();
            //        firma_con.Alignment = Element.ALIGN_CENTER;
            //        firma_con.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            //        firma_con.Add("............................................. \n       TESORERIA");
            //        //aÑADIENDO FIRMAS A LA TABLA FIRMAS
            //        tabla_firmas.AddCell(firma_rrhh);
            //        tabla_firmas.AddCell(firma_gm);
            //        tabla_firmas.AddCell(firma_pre);
            //        tabla_firmas.AddCell(firma_con);
            //    }
            //    else
            //    {
            //        tabla_firmas = new PdfPTable(4);
            //        tabla_firmas2 = new PdfPTable(2);
            //        tabla_firmas.DefaultCell.BorderWidth = 0;
            //        tabla_firmas2.DefaultCell.BorderWidth = 0;
            //        //FIRMAS
            //        Paragraph p_rrhh = new Paragraph();
            //        p_rrhh.Alignment = Element.ALIGN_CENTER;
            //        p_rrhh.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            //        p_rrhh.Add(" ............................................. \n   RECURSOS HUMANOS");

            //        Paragraph p_gm = new Paragraph();
            //        p_gm.Alignment = Element.ALIGN_CENTER;
            //        p_gm.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            //        p_gm.Add(" ............................................... \n   GERENCIA MUNICIPAL");

            //        Paragraph p_pre = new Paragraph();
            //        p_pre.Alignment = Element.ALIGN_CENTER;
            //        p_pre.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            //        p_pre.Add(" ....................................... \n PRESUPUESTO Y CONTABILIDAD");

            //        Paragraph p_con = new Paragraph();
            //        p_con.Alignment = Element.ALIGN_CENTER;
            //        p_con.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            //        p_con.Add(" ");

            //        Paragraph firma_Tes = new Paragraph();
            //        firma_Tes.Alignment = Element.ALIGN_CENTER;
            //        firma_Tes.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            //        firma_Tes.Add(" ............................................... \n          TESORERIA");

            //        Paragraph firma_SUb = new Paragraph();
            //        firma_SUb.Alignment = Element.ALIGN_CENTER;
            //        firma_SUb.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            //        firma_SUb.Add(" ............................................................. \n RESIDENCIA DE OBRAS");
            //        //aÑADIENDO FIRMAS A LA TABLA FIRMAS
            //        tabla_firmas.AddCell(p_rrhh);
            //        tabla_firmas.AddCell(p_gm);
            //        tabla_firmas.AddCell(p_pre);
            //        tabla_firmas.AddCell(p_con);
            //        tabla_firmas2.AddCell(firma_Tes);
            //        tabla_firmas2.AddCell(firma_SUb);
            //    }

            //    //instanciando una columna y 3 columnas
            //    //Columnas 
            //    MultiColumnText column_one = new MultiColumnText();
            //    column_one.AddRegularColumns(36f, pdfDoc.PageSize.Width - 36f, 24f, 1);


            //    MultiColumnText column_3 = new MultiColumnText();
            //    column_3.AddRegularColumns(36f, pdfDoc.PageSize.Width - 36f, 24f, 4);

            //    PdfPTable tabla_Encabezado = new PdfPTable(3);
            //    tabla_Encabezado.DefaultCell.BorderWidth = 0;

            //    Paragraph vacio = new Paragraph();
            //    vacio.Alignment = Element.ALIGN_CENTER;
            //    vacio.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);

            //    tabla_Encabezado.SetWidths(new float[] { 30, 120, 40 });
            //    //tabla_Encabezado.SetWidthPercentage(new float[] { 20f, 60f, 20f }, iTextSharp.text.PageSize.A4.Rotate());
            //    tabla_Encabezado.AddCell(vacio);
            //    tabla_Encabezado.AddCell(paragraph3);
            //    tabla_Encabezado.AddCell(paragraph2);

            //    //Agrupando tabla titular
            //    tabla_bonus.AddCell(pdfTableRedondear);
            //    tabla_bonus.AddCell(pdfTable2);

            //    tabla_bonus.AddCell(pdfTableEEFF);



            //    //Agregando una columna 
            //    column_one.AddElement(paragraph);
            //    //column_one.AddElement(logo);
            //    //column_one.AddElement(paragraph2);
            //    //column_one.AddElement(paragraph3);
            //    column_one.AddElement(tabla_Encabezado);
            //    column_one.AddElement(paragraph4);
            //    column_one.AddElement(paragraph40);
            //    column_one.AddElement(pdfTable);
            //    //column_one.AddElement(paragraph5);
            //    column_one.AddElement(paragraph6);
            //    column_one.AddElement(tabla_bonus);
            //    column_one.AddElement(paragraph5);
            //    column_one.AddElement(paragraph5);
            //    column_one.AddElement(paragraph5);
            //    column_one.AddElement(paragraph5);
            //    column_one.AddElement(paragraph5);
            //    //column_one.AddElement(paragraph5);
            //    column_one.AddElement(tabla_firmas);
            //    if (numeroRegimenLaboral == 3)
            //    {
            //        column_one.AddElement(paragraph5);
            //        column_one.AddElement(paragraph5);
            //        column_one.AddElement(paragraph5);
            //        column_one.AddElement(paragraph5);
            //        column_one.AddElement(paragraph5);
            //        column_one.AddElement(paragraph5);
            //        column_one.AddElement(tabla_firmas2);
            //    }
            //    pdfDoc.Add(logo);
            //    pdfDoc.Add(oficinas);
            //    pdfDoc.Add(column_one);
            //    //pdfDoc.Add(column_dos);
            //    pdfDoc.Close();
            //    stream.Close();
            //}

            //System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //proc.EnableRaisingEvents = false;
            //proc.StartInfo.FileName = "C:\\PDFs\\Planilla.pdf";
            //proc.Start();
        }
        
    }
}
