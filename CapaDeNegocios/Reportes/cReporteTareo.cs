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
using System.IO;

namespace CapaDeNegocios.Reportes
{
    public class cReporteTareo
    {
        public void ImprimirTareo(CapaDeNegocios.Tareos.cTareo oTareo, string ruta)
        {
            try
            {
                cReportePDF oReporte = new cReportePDF();
                oReporte.RutaArchivo = ruta;

                cHojaPDF oHojaPDF = new cHojaPDF();

                cTablaPDF oTablaTitulo = new cTablaPDF();
                oTablaTitulo.columnas = 1;
                oTablaTitulo.anchoColumnas = new float[] { 100 };
                cFilasPDF filaTitulo = new cFilasPDF();
                cCeldaPDF TituloCelda = new cCeldaPDF("HOJA DE INFORMACIÓN DE ASISTENCIA DE " + oTareo.Descripcion);
                filaTitulo.ListaCeldas.Add(TituloCelda);
                oTablaTitulo.ListaFilas.Add(filaTitulo);

                cTablaPDF TablaSubtitulos = new cTablaPDF();
                TablaSubtitulos.columnas = 5;
                TablaSubtitulos.anchoColumnas = new float[] { 10, 30, 10, 30, 10 };

                cFilasPDF FilaSubtitulos = new cFilasPDF();
                
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al imprimir en PDF el tareo: " + ex.Message);
            }

        }



        private void ImprimirReportePDF(cReportePDF oReportePDF)
        {
            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 7);
            iTextSharp.text.Font fuenteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 9, 1, iTextSharp.text.Color.BLUE);
            Document pdfDoc = new Document(PageSize.A4, 30, 9, 10, 10);
            pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4);
            FileStream stream = new FileStream(oReportePDF.RutaArchivo, FileMode.Create);
            PdfWriter.GetInstance(pdfDoc, stream);
            pdfDoc.Open();
            foreach (cHojaPDF item in oReportePDF.ListaHojasPDF)
            {
                foreach (cTablaPDF item2 in item.ListaDeTablas)
                {
                    PdfPTable pdfTable = new PdfPTable(item2.columnas);
                    pdfTable.DefaultCell.Padding = 1;
                    pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                    pdfTable.DefaultCell.BorderWidth = 1;
                    pdfTable.SetWidths(item2.anchoColumnas);

                    foreach (cFilasPDF item3 in item2.ListaFilas)
                    {
                        foreach (cCeldaPDF item4 in item3.ListaCeldas)
                        {
                            if (item4.TablaPDF != null)
                            {
                                PdfPTable oNuevaTabla = new PdfPTable(item4.TablaPDF.columnas);
                                oNuevaTabla.SetWidths(item4.TablaPDF.anchoColumnas);
                                foreach (cFilasPDF item5 in item4.TablaPDF.ListaFilas)
                                {
                                    foreach (cCeldaPDF item6 in item5.ListaCeldas)
                                    {
                                        if (item6.TablaPDF != null)
                                        {
                                            PdfPTable oNuevaTabla2 = new PdfPTable(item6.TablaPDF.columnas);
                                            oNuevaTabla2.SetWidths(item6.TablaPDF.anchoColumnas);

                                            foreach (cFilasPDF item7 in item6.TablaPDF.ListaFilas)
                                            {
                                                foreach (cCeldaPDF item8 in item7.ListaCeldas)
                                                {
                                                    PdfPCell cell = new PdfPCell((new Phrase(item8.Contenido, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, new iTextSharp.text.Color(item8.ColorLetra)))));
                                                    cell.BackgroundColor = new iTextSharp.text.Color(item8.ColorFondo);
                                                    cell.FixedHeight = item8.AltoColumna;
                                                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                                    // objH = new Phrase(column.HeaderText, fuenteTitulo);
                                                    oNuevaTabla2.AddCell(cell);
                                                }
                                                oNuevaTabla2.CompleteRow();
                                            }
                                            oNuevaTabla.AddCell(oNuevaTabla2);
                                        }
                                        else
                                        {
                                            PdfPCell cell = new PdfPCell((new Phrase(item6.Contenido, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, new iTextSharp.text.Color(item6.ColorLetra)))));
                                            cell.BackgroundColor = new iTextSharp.text.Color(item4.ColorFondo);
                                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                            cell.FixedHeight = item6.AltoColumna;
                                            // objH = new Phrase(column.HeaderText, fuenteTitulo);
                                            oNuevaTabla.AddCell(cell);
                                        }

                                    }
                                    oNuevaTabla.CompleteRow();
                                }
                                pdfTable.AddCell(oNuevaTabla);
                            }
                            else
                            {
                                PdfPCell cell = new PdfPCell((new Phrase(item4.Contenido, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, new iTextSharp.text.Color(item4.ColorLetra)))));
                                //cell = new PdfPCell(new Phrase(column.HeaderText));
                                //PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                cell.BackgroundColor = new iTextSharp.text.Color(item4.ColorFondo);
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.FixedHeight = item4.AltoColumna;
                                // objH = new Phrase(column.HeaderText, fuenteTitulo);
                                pdfTable.AddCell(cell);
                            }

                        }
                        pdfTable.CompleteRow();
                    }
                    pdfDoc.Add(pdfTable);
                }

            }
            pdfDoc.Close();
        }
    }
}
