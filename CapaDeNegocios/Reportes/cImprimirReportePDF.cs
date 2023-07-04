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
    public  class cImprimirReportePDF
    {
        public void ImprimirReportePDF(cReportePDF oReportePDF)
        {
            string ruta = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

            string ruta_imagen = ruta + "\\logo-muni-fw.png";


            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 7);
            iTextSharp.text.Font fuenteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 9, 1, iTextSharp.text.Color.BLUE);
            Document pdfDoc = new Document(PageSize.A4, 80, 9, 0, 0);

            pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            FileStream stream = new FileStream(oReportePDF.RutaArchivo, FileMode.Create);
            PdfWriter.GetInstance(pdfDoc, stream);
            pdfDoc.Open();

            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(ruta_imagen);
            logo.ScalePercent(64f);
            logo.SetAbsolutePosition(22f, pdfDoc.PageSize.Height - 100f);

            pdfDoc.Add(logo);


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
                                oNuevaTabla.DefaultCell.Border = Rectangle.NO_BORDER;
                                foreach (cFilasPDF item5 in item4.TablaPDF.ListaFilas)
                                {
                                    foreach (cCeldaPDF item6 in item5.ListaCeldas)
                                    {
                                        if (item6.TablaPDF != null)
                                        {
                                            PdfPTable oNuevaTabla2 = new PdfPTable(item6.TablaPDF.columnas);
                                            oNuevaTabla2.SetWidths(item6.TablaPDF.anchoColumnas);
                                            oNuevaTabla.DefaultCell.Border = Rectangle.NO_BORDER;
                                            foreach (cFilasPDF item7 in item6.TablaPDF.ListaFilas)
                                            {
                                                foreach (cCeldaPDF item8 in item7.ListaCeldas)
                                                {
                                                    PdfPCell cell = new PdfPCell((new Phrase(item8.Contenido, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, new iTextSharp.text.Color(item8.ColorLetra)))));
                                                    if (!item8.ImagenTranasparente)
                                                    {
                                                        cell.BackgroundColor = new iTextSharp.text.Color(item8.ColorFondo);
                                                    }

                                                    cell.FixedHeight = item8.AltoColumna;
                                                    switch (item8.Alineamiento)
                                                    {
                                                        case enumAlineamiento.defecto:
                                                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                                            break;
                                                        case enumAlineamiento.derecha:
                                                            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                                                            break;
                                                        case enumAlineamiento.izquierda:
                                                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                                                            break;
                                                        case enumAlineamiento.centro:
                                                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                                            break;
                                                    }
                                                    
                                                    cell.UseVariableBorders = true;
                                                    cell.BorderWidth = item8.AnchoBorde;
                                                    cell.BorderWidthBottom = item8.BordeAnchos.AnchoAbajo;
                                                    cell.BorderWidthLeft = item8.BordeAnchos.AnchoIzquierda;
                                                    cell.BorderWidthRight = item8.BordeAnchos.AnchoDerecha;
                                                    cell.BorderWidthTop = item8.BordeAnchos.AnchoArriba;

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
                                            if (!item6.ImagenTranasparente)
                                            {
                                                cell.BackgroundColor = new iTextSharp.text.Color(item6.ColorFondo);
                                            }

                                            switch (item6.Alineamiento)
                                            {
                                                case enumAlineamiento.defecto:
                                                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                                    break;
                                                case enumAlineamiento.derecha:
                                                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                                                    break;
                                                case enumAlineamiento.izquierda:
                                                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                                                    break;
                                                case enumAlineamiento.centro:
                                                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                                    break;
                                            }

                                            cell.FixedHeight = item6.AltoColumna;
                                            cell.UseVariableBorders = true;

                                            cell.BorderWidth = item6.AnchoBorde;
                                            cell.BorderWidthBottom = item6.BordeAnchos.AnchoAbajo;
                                            cell.BorderWidthLeft = item6.BordeAnchos.AnchoIzquierda;
                                            cell.BorderWidthRight = item6.BordeAnchos.AnchoDerecha;
                                            cell.BorderWidthTop = item6.BordeAnchos.AnchoArriba;
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
                                if (!item4.ImagenTranasparente)
                                {
                                    cell.BackgroundColor = new iTextSharp.text.Color(item4.ColorFondo);
                                }

                                switch (item4.Alineamiento)
                                {
                                    case enumAlineamiento.defecto:
                                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                        break;
                                    case enumAlineamiento.derecha:
                                        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                                        break;
                                    case enumAlineamiento.izquierda:
                                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                                        break;
                                    case enumAlineamiento.centro:
                                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                        break;
                                }
                                cell.FixedHeight = item4.AltoColumna;
                                cell.UseVariableBorders = true;
                                cell.BorderWidth = item4.AnchoBorde;
                                cell.BorderWidthBottom = item4.BordeAnchos.AnchoAbajo;
                                cell.BorderWidthLeft = item4.BordeAnchos.AnchoIzquierda;
                                cell.BorderWidthRight = item4.BordeAnchos.AnchoDerecha;
                                cell.BorderWidthTop = item4.BordeAnchos.AnchoArriba;

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

        public void ImprimirReportePDFBOLETA(cReportePDF oReportePDF)
        {
            string ruta = System.IO.Directory.GetCurrentDirectory();

            string ruta_imagen = ruta + "\\logo-muni-fw.png";


            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 7);
            iTextSharp.text.Font fuenteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 9, 1, iTextSharp.text.Color.BLUE);
            Rectangle tamañoHoja = new Rectangle(841, 298); // 841   595

            Document pdfDoc = new Document(PageSize.A4, 80, 9, 10, 10);

            pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            //pdfDoc.SetPageSize(tamañoHoja);
            FileStream stream = new FileStream(oReportePDF.RutaArchivo, FileMode.Create);
            PdfWriter.GetInstance(pdfDoc, stream);
            pdfDoc.Open();

            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(ruta_imagen);
            logo.ScalePercent(44f);
            //logo.SetAbsolutePosition(5f, pdfDoc.PageSize.Height - 100f);
            //logo.SetAbsolutePosition(10f, pdfDoc.PageSize.Height - Convert.ToSingle(logo.Height * 0.64)-10f);
            //pdfDoc.Add(logo);



            foreach (cHojaPDF item in oReportePDF.ListaHojasPDF)
            {
               
                foreach (cTablaPDF item2 in item.ListaDeTablas)
                {
                    PdfPTable pdfTable = new PdfPTable(item2.columnas);
                    pdfTable.DefaultCell.Padding = 0;
                    pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                    //pdfTable.DefaultCell.BorderWidth = 1;
                    pdfTable.DefaultCell.BorderWidth = Rectangle.NO_BORDER;
                    pdfTable.SetWidths(item2.anchoColumnas);

                    foreach (cFilasPDF item3 in item2.ListaFilas)
                    {
                        foreach (cCeldaPDF item4 in item3.ListaCeldas)
                        {
                            if (item4.TablaPDF != null)
                            {
                                PdfPTable oNuevaTabla = new PdfPTable(item4.TablaPDF.columnas);
                                oNuevaTabla.SetWidths(item4.TablaPDF.anchoColumnas);
                                oNuevaTabla.DefaultCell.Border = Rectangle.NO_BORDER;
                                foreach (cFilasPDF item5 in item4.TablaPDF.ListaFilas)
                                {
                                    foreach (cCeldaPDF item6 in item5.ListaCeldas)
                                    {
                                        if (item6.TablaPDF != null)
                                        {
                                            PdfPTable oNuevaTabla2 = new PdfPTable(item6.TablaPDF.columnas);
                                            oNuevaTabla2.SetWidths(item6.TablaPDF.anchoColumnas);
                                            oNuevaTabla2.DefaultCell.Border = Rectangle.NO_BORDER;
                                            foreach (cFilasPDF item7 in item6.TablaPDF.ListaFilas)
                                            {
                                                foreach (cCeldaPDF item8 in item7.ListaCeldas)
                                                {
                                                    PdfPCell cell = new PdfPCell((new Phrase(item8.Contenido, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, item8.TamañoLetra, iTextSharp.text.Font.BOLD, new iTextSharp.text.Color(item8.ColorLetra)))));
                                                    if (item8.esImagen)
                                                    {
                                                        cell = new PdfPCell(logo);
                                                    }
                                                    if (!item8.ImagenTranasparente)
                                                    {
                                                        cell.BackgroundColor = new iTextSharp.text.Color(item8.ColorFondo);
                                                    }

                                                    cell.FixedHeight = item8.AltoColumna;
                                                    switch (item8.Alineamiento)
                                                    {
                                                        case enumAlineamiento.defecto:
                                                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                                            break;
                                                        case enumAlineamiento.derecha:
                                                            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                                                            break;
                                                        case enumAlineamiento.izquierda:
                                                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                                                            break;
                                                        case enumAlineamiento.centro:
                                                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                                            break;
                                                        case enumAlineamiento.abajo:
                                                            cell.VerticalAlignment = Element.ALIGN_BOTTOM;
                                                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                                            break;
                                                    }

                                                    switch (item8.ALineamientoVertical)
                                                    {
                                                        case enumAlineamientoVertical.defecto:
                                                            cell.VerticalAlignment = Element.ALIGN_CENTER;
                                                            break;
                                                        case enumAlineamientoVertical.arriba:
                                                            cell.VerticalAlignment = Element.ALIGN_TOP;
                                                            break;
                                                        case enumAlineamientoVertical.centro:
                                                            cell.VerticalAlignment = Element.ALIGN_CENTER;
                                                            break;
                                                        case enumAlineamientoVertical.abajo:
                                                            cell.VerticalAlignment = Element.ALIGN_BOTTOM;
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    cell.UseVariableBorders = true;
                                                    cell.BorderWidth = item8.AnchoBorde;
                                                    cell.BorderWidthBottom = item8.BordeAnchos.AnchoAbajo;
                                                    cell.BorderWidthLeft = item8.BordeAnchos.AnchoIzquierda;
                                                    cell.BorderWidthRight = item8.BordeAnchos.AnchoDerecha;
                                                    cell.BorderWidthTop = item8.BordeAnchos.AnchoArriba;

                                                    // objH = new Phrase(column.HeaderText, fuenteTitulo);
                                                    oNuevaTabla2.AddCell(cell);
                                                }
                                                oNuevaTabla2.CompleteRow();
                                            }
                                           
                                            
                                            oNuevaTabla.AddCell(oNuevaTabla2);

                                        }
                                        else
                                        {
                                            PdfPCell cell = new PdfPCell((new Phrase(item6.Contenido, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, item6.TamañoLetra, iTextSharp.text.Font.BOLD, new iTextSharp.text.Color(item6.ColorLetra)))));
                                            if (!item6.ImagenTranasparente)
                                            {
                                                cell.BackgroundColor = new iTextSharp.text.Color(item6.ColorFondo);
                                            }
                                            if (item6.esImagen)
                                            {
                                                cell = new PdfPCell(logo);
                                            }

                                            switch (item6.Alineamiento)
                                            {
                                                case enumAlineamiento.defecto:
                                                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                                    break;
                                                case enumAlineamiento.derecha:
                                                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                                                    break;
                                                case enumAlineamiento.izquierda:
                                                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                                                    break;
                                                case enumAlineamiento.centro:
                                                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                                    break;
                                                case enumAlineamiento.abajo:
                                                    cell.VerticalAlignment = Element.ALIGN_BOTTOM;
                                                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                                    break;
                                            }
                                            switch (item6.ALineamientoVertical)
                                            {
                                                case enumAlineamientoVertical.defecto:
                                                    cell.VerticalAlignment = Element.ALIGN_CENTER;
                                                    break;
                                                case enumAlineamientoVertical.arriba:
                                                    cell.VerticalAlignment = Element.ALIGN_TOP;
                                                    break;
                                                case enumAlineamientoVertical.centro:
                                                    cell.VerticalAlignment = Element.ALIGN_CENTER;
                                                    break;
                                                case enumAlineamientoVertical.abajo:
                                                    cell.VerticalAlignment = Element.ALIGN_BOTTOM;
                                                    break;
                                                default:
                                                    break;
                                            }

                                            cell.FixedHeight = item6.AltoColumna;
                                            cell.UseVariableBorders = true;

                                            cell.BorderWidth = item6.AnchoBorde;
                                            cell.BorderWidthBottom = item6.BordeAnchos.AnchoAbajo;
                                            cell.BorderWidthLeft = item6.BordeAnchos.AnchoIzquierda;
                                            cell.BorderWidthRight = item6.BordeAnchos.AnchoDerecha;
                                            cell.BorderWidthTop = item6.BordeAnchos.AnchoArriba;
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
                                PdfPCell cell;
                                //cell = new PdfPCell(new Phrase(column.HeaderText));
                                //PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                if (item4.esImagen)
                                {
                                    cell = new PdfPCell(logo);
                                }
                                else
                                {
                                    cell = new PdfPCell((new Phrase(item4.Contenido, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, item4.TamañoLetra, iTextSharp.text.Font.BOLD, new iTextSharp.text.Color(item4.ColorLetra)))));
                                }

                                if (!item4.ImagenTranasparente)
                                {
                                    cell.BackgroundColor = new iTextSharp.text.Color(item4.ColorFondo);
                                }

                                switch (item4.Alineamiento)
                                {
                                    case enumAlineamiento.defecto:
                                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                        break;
                                    case enumAlineamiento.derecha:
                                        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                                        break;
                                    case enumAlineamiento.izquierda:
                                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                                        break;
                                    case enumAlineamiento.centro:
                                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                        break;
                                    case enumAlineamiento.abajo:
                                        cell.VerticalAlignment = Element.ALIGN_BOTTOM;
                                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                        break;
                                }

                                switch (item4.ALineamientoVertical)
                                {
                                    case enumAlineamientoVertical.defecto:
                                        cell.VerticalAlignment = Element.ALIGN_CENTER;
                                        break;
                                    case enumAlineamientoVertical.arriba:
                                        cell.VerticalAlignment = Element.ALIGN_TOP;
                                        break;
                                    case enumAlineamientoVertical.centro:
                                        cell.VerticalAlignment = Element.ALIGN_CENTER;
                                        break;
                                    case enumAlineamientoVertical.abajo:
                                        cell.VerticalAlignment = Element.ALIGN_BOTTOM;
                                        break;
                                    default:
                                        break;
                                }

                                if (!item4.esImagen)
                                {
                                    cell.FixedHeight = item4.AltoColumna;
                                }
                                
                                cell.UseVariableBorders = true;
                                cell.BorderWidth = item4.AnchoBorde;
                                cell.BorderWidthBottom = item4.BordeAnchos.AnchoAbajo;
                                cell.BorderWidthLeft = item4.BordeAnchos.AnchoIzquierda;
                                cell.BorderWidthRight = item4.BordeAnchos.AnchoDerecha;
                                cell.BorderWidthTop = item4.BordeAnchos.AnchoArriba;

                                // objH = new Phrase(column.HeaderText, fuenteTitulo);
                                pdfTable.AddCell(cell);
                            }

                        }
                        pdfTable.CompleteRow();
                    }

                    pdfDoc.Add(pdfTable);

                }
                pdfDoc.NewPage();
                //pdfDoc.Add(logo);
            }

            pdfDoc.Close();


        }
    }
}
