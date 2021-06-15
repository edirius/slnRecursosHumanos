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
using System.IO;

namespace CapaDeNegocios.Reportes
{
    public class cReporteAsistencia
    {

        public void ImprimirReporteAsistenciaXTrabajador(cTrabajador oTrabajador,  cAsistenciaMes oAsistenciaMes, string RutaArchivo )
        {
   
            cReportePDF oReporte = new cReportePDF();

            oReporte.RutaArchivo = RutaArchivo;

            cHojaPDF oHojaPDF = new cHojaPDF();
            
           
            cTablaPDF TablaTituloPrincipal = new cTablaPDF();
            TablaTituloPrincipal.columnas = 1;
            TablaTituloPrincipal.anchoColumnas = new float[] { 500f };

            cFilasPDF FilaTituloPrincipal = new cFilasPDF();

            cCeldaPDF TituloPrincipal = new cCeldaPDF();
            TituloPrincipal.Contenido = "Reporte de Asistencia";
            TituloPrincipal.ColorFondo = System.Drawing.Color.LightGray;
            FilaTituloPrincipal.ListaCeldas.Add(TituloPrincipal);

            TablaTituloPrincipal.ListaFilas.Add(FilaTituloPrincipal);

            cTablaPDF TablaTitulo1 = new cTablaPDF();
            TablaTitulo1.columnas = 6;
            TablaTitulo1.anchoColumnas = new float[] { 50f, 50f, 50f, 50f, 50f, 50f };

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

            TablaTitulo1.ListaFilas.Add(FilaTitulo1);

            cTablaPDF TablaTitulo2 = new cTablaPDF();
            TablaTitulo2.columnas = 3;
            TablaTitulo2.anchoColumnas = new float[] { 50f, 50f, 50f };
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

            TablaTitulo2.ListaFilas.Add(FilaTitulos2);

            cTablaPDF TablaTitulo3 = new cTablaPDF();
            TablaTitulo3.columnas = 4;
            TablaTitulo3.anchoColumnas = new float[] { 50f, 50f, 50f, 50f };

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

            TablaTitulo3.ListaFilas.Add(FilaTitulos3);

            //Encabezado de detalle de asistencia

            cTablaPDF TablaDetalle = new cTablaPDF();
            TablaDetalle.columnas = 7;
            TablaDetalle.anchoColumnas = new float[] { 100f, 100f, 150f, 125f, 125f, 50f, 50f };
            cFilasPDF FilaTituloDetalle = new cFilasPDF();

            cCeldaPDF labelFechaDetalle = new cCeldaPDF();
            labelFechaDetalle.Contenido = "Fechas";
            FilaTituloDetalle.ListaCeldas.Add(labelFechaDetalle);

            cCeldaPDF labelHorario = new cCeldaPDF();
            labelHorario.TablaPDF = new cTablaPDF();
            labelHorario.TablaPDF.columnas = 1;
            labelHorario.TablaPDF.anchoColumnas = new float[] { 50f };

            cFilasPDF filaTablaHorario1 = new cFilasPDF();
            cCeldaPDF labelTablaHorario = new cCeldaPDF();
            labelTablaHorario.Contenido = "HORARIO";
            filaTablaHorario1.ListaCeldas.Add(labelTablaHorario);
            cFilasPDF filaTablahorario2 = new cFilasPDF();
            cCeldaPDF labelEntradaSalida = new cCeldaPDF();
            labelEntradaSalida.TablaPDF = new cTablaPDF();
            labelEntradaSalida.TablaPDF.columnas = 2;
            labelEntradaSalida.TablaPDF.anchoColumnas = new float[] { 50f , 50f};
            cFilasPDF filaentradasalidaTitulo = new cFilasPDF();
            cCeldaPDF labelEntrada = new cCeldaPDF();
            labelEntrada.Contenido = "Entrada";
            filaentradasalidaTitulo.ListaCeldas.Add(labelEntrada);
            cCeldaPDF labelSalida = new cCeldaPDF();
            labelSalida.Contenido = "Salida";
            filaentradasalidaTitulo.ListaCeldas.Add(labelSalida);
            labelEntradaSalida.TablaPDF.ListaFilas.Add(filaentradasalidaTitulo);
            filaTablahorario2.ListaCeldas.Add(labelEntradaSalida);
            labelHorario.TablaPDF.ListaFilas.Add(filaTablaHorario1);
            labelHorario.TablaPDF.ListaFilas.Add(filaTablahorario2);
            FilaTituloDetalle.ListaCeldas.Add(labelHorario);

            cCeldaPDF labelJornadaReal = new cCeldaPDF();
            labelJornadaReal.TablaPDF = new cTablaPDF();
            labelJornadaReal.TablaPDF.columnas = 1;
            labelJornadaReal.TablaPDF.anchoColumnas = new float[] { 50f };
            cFilasPDF FilaJornadaReal = new cFilasPDF();
            cCeldaPDF labelDetalleJornada = new cCeldaPDF();
            labelDetalleJornada.Contenido = "JORNADA REAL";
            FilaJornadaReal.ListaCeldas.Add(labelDetalleJornada);
            cFilasPDF FilaJornadaReal2 = new cFilasPDF();
            cCeldaPDF labelEntradaDescanso = new cCeldaPDF();
            labelEntradaDescanso.TablaPDF = new cTablaPDF();
            labelEntradaDescanso.TablaPDF.columnas = 3;
            labelEntradaDescanso.TablaPDF.anchoColumnas = new float[] { 40f, 70f, 40f };
            cFilasPDF FilaEntradaDescanso = new cFilasPDF();
            cCeldaPDF labelEntradaReal = new cCeldaPDF();
            labelEntradaReal.Contenido = "Entrada";
            FilaEntradaDescanso.ListaCeldas.Add(labelEntradaReal);
            cCeldaPDF labelDescanso = new cCeldaPDF();
            labelDescanso.Contenido = "Descanso";
            FilaEntradaDescanso.ListaCeldas.Add(labelDescanso);
            cCeldaPDF labelSalidaReal = new cCeldaPDF();
            labelSalidaReal.Contenido = "Salida";
            FilaEntradaDescanso.ListaCeldas.Add(labelSalidaReal);
            labelEntradaDescanso.TablaPDF.ListaFilas.Add(FilaEntradaDescanso);
            FilaJornadaReal2.ListaCeldas.Add(labelEntradaDescanso);
            labelJornadaReal.TablaPDF.ListaFilas.Add(FilaJornadaReal);
            labelJornadaReal.TablaPDF.ListaFilas.Add(FilaJornadaReal2);
            FilaTituloDetalle.ListaCeldas.Add(labelJornadaReal);

            cCeldaPDF labelHorasAsignadas = new cCeldaPDF();
            labelHorasAsignadas.TablaPDF = new cTablaPDF();
            labelHorasAsignadas.TablaPDF.columnas = 1;
            labelHorasAsignadas.TablaPDF.anchoColumnas = new float[] { 50f };
            cFilasPDF filaHorasAsignadas = new cFilasPDF();
            cCeldaPDF labelDetalleHorasAsignadas = new cCeldaPDF();
            labelDetalleHorasAsignadas.Contenido = "HORAS";
            filaHorasAsignadas.ListaCeldas.Add(labelDetalleHorasAsignadas);
            cFilasPDF filaHorasAsignadas2 = new cFilasPDF();
            cCeldaPDF labelHorasAsignadasAsistidas = new cCeldaPDF();
            labelHorasAsignadasAsistidas.TablaPDF = new cTablaPDF();
            labelHorasAsignadasAsistidas.TablaPDF.columnas = 3;
            labelHorasAsignadasAsistidas.TablaPDF.anchoColumnas = new float[] { 50f, 50f, 50f };
            cFilasPDF FilaDetalleHorasAsignadasAsistidas = new cFilasPDF();
            cCeldaPDF LabelDetalleAsignadas = new cCeldaPDF("Horas Asignadas");
            FilaDetalleHorasAsignadasAsistidas.ListaCeldas.Add(LabelDetalleAsignadas);
            cCeldaPDF LabelDetalleAsistidas = new cCeldaPDF("Horas Usadas");
            FilaDetalleHorasAsignadasAsistidas.ListaCeldas.Add(LabelDetalleAsistidas);
            cCeldaPDF LabelDetalleTarde = new cCeldaPDF("Min. Tarde");
            FilaDetalleHorasAsignadasAsistidas.ListaCeldas.Add(LabelDetalleTarde);
            labelHorasAsignadasAsistidas.TablaPDF.ListaFilas.Add(FilaDetalleHorasAsignadasAsistidas);
            filaHorasAsignadas2.ListaCeldas.Add(labelHorasAsignadasAsistidas);
            labelHorasAsignadas.TablaPDF.ListaFilas.Add(filaHorasAsignadas);
            labelHorasAsignadas.TablaPDF.ListaFilas.Add(filaHorasAsignadas2);
            FilaTituloDetalle.ListaCeldas.Add(labelHorasAsignadas);

            cCeldaPDF labelPermisosySalidas = new cCeldaPDF();
            labelPermisosySalidas.TablaPDF = new cTablaPDF();
            labelPermisosySalidas.TablaPDF.columnas = 1;
            labelPermisosySalidas.TablaPDF.anchoColumnas = new float[] { 50f };
            cFilasPDF filaPermisosysalidas = new cFilasPDF();
            cCeldaPDF TituloPermisosSalidas = new cCeldaPDF("Permisos y Salidas");
            filaPermisosysalidas.ListaCeldas.Add(TituloPermisosSalidas);
            cFilasPDF filaPermisosySalidas2 = new cFilasPDF();
            cCeldaPDF labelTipoSalida = new cCeldaPDF();
            labelTipoSalida.TablaPDF = new cTablaPDF();
            labelTipoSalida.TablaPDF.columnas = 3;
            labelTipoSalida.TablaPDF.anchoColumnas = new float[] { 50f, 50f, 50f };
            cFilasPDF filaTipoSalida = new cFilasPDF();
            cCeldaPDF TituloEntradaComision = new cCeldaPDF("Entrada");
            filaTipoSalida.ListaCeldas.Add(TituloEntradaComision);
            cCeldaPDF TituloSalidaComision = new cCeldaPDF("Salida");
            filaTipoSalida.ListaCeldas.Add(TituloSalidaComision);
            cCeldaPDF TituloTipoComision = new cCeldaPDF("Tipo");
            filaTipoSalida.ListaCeldas.Add(TituloTipoComision);
            labelTipoSalida.TablaPDF.ListaFilas.Add(filaTipoSalida);
            filaPermisosySalidas2.ListaCeldas.Add(labelTipoSalida);
            labelPermisosySalidas.TablaPDF.ListaFilas.Add(filaPermisosysalidas);
            labelPermisosySalidas.TablaPDF.ListaFilas.Add(filaPermisosySalidas2);
            FilaTituloDetalle.ListaCeldas.Add(labelPermisosySalidas);

            cCeldaPDF LabelFalta = new cCeldaPDF("Falta");
            FilaTituloDetalle.ListaCeldas.Add(LabelFalta);

            cCeldaPDF labelTipoHorario = new cCeldaPDF("Tipo Horario");
            FilaTituloDetalle.ListaCeldas.Add(labelTipoHorario);

            TablaDetalle.ListaFilas.Add(FilaTituloDetalle);

            cTablaPDF TablaDetalleDetalle = new cTablaPDF();
            TablaDetalleDetalle.columnas = 13;
            TablaDetalleDetalle.anchoColumnas = new float[] { 100f, 50f, 50f, 40f, 70f, 40f, 50f, 50f, 50f, 50f, 50f, 50f, 50f };

            foreach (cAsistenciaDia item in oAsistenciaMes.ListaAsistenciaDia)
            {
                
                cFilasPDF FilaDetalle = new cFilasPDF();
                cCeldaPDF DetalleFecha = new cCeldaPDF();
                DetalleFecha.AltoColumna = 12f;
                DetalleFecha.Contenido = item.Dia.ToString("ddd dd/MM/yyyy" );
                FilaDetalle.ListaCeldas.Add(DetalleFecha);

                    cCeldaPDF DetalleInicioHorario = new cCeldaPDF("");
                    if (item.EventoDia == cAsistenciaDia.TipoDia.DiaLaborable)
                    {
                        DetalleInicioHorario.Contenido = item.TurnoDiaTrabajador.ListaTurnos[0].InicioTurno.ToShortTimeString();
                    }
                    
                    FilaDetalle.ListaCeldas.Add(DetalleInicioHorario);

                    cCeldaPDF DetalleFinHorario = new cCeldaPDF("");
                    if (item.EventoDia == cAsistenciaDia.TipoDia.DiaLaborable)
                    {
                    DetalleFinHorario.Contenido = item.TurnoDiaTrabajador.ListaTurnos[0].FinTurno.ToShortTimeString();
                }
                    
                    FilaDetalle.ListaCeldas.Add(DetalleFinHorario);

                    cCeldaPDF DetalleInicioPicado = new cCeldaPDF();
                    if (item.PicadoEntrada == null)
                    {
                        DetalleInicioPicado.Contenido = "";
                    }
                    else
                    {
                        DetalleInicioPicado.Contenido = item.PicadoEntrada.Picado.ToShortTimeString();
                    }
                    FilaDetalle.ListaCeldas.Add(DetalleInicioPicado);

                    cCeldaPDF DetalleInicioDescanso = new cCeldaPDF("13:00 14:00");
                    if (item.EventoDia == cAsistenciaDia.TipoDia.DiaLibre || item.EventoDia == cAsistenciaDia.TipoDia.DiaFestivo)
                    {
                        DetalleInicioDescanso.Contenido = "";
                    }
                    FilaDetalle.ListaCeldas.Add(DetalleInicioDescanso);

                    //cCeldaPDF DetalleFinDescanso = new cCeldaPDF("14:00");
                    //FilaDetalle.ListaCeldas.Add(DetalleFinDescanso);

                    cCeldaPDF DetalleFinPicado = new cCeldaPDF();
                    if (item.PicadoSalida == null)
                    {
                        DetalleFinPicado.Contenido = "";
                    }
                    else
                    {
                        DetalleFinPicado.Contenido = item.PicadoSalida.Picado.ToShortTimeString();
                    }
                    FilaDetalle.ListaCeldas.Add(DetalleFinPicado);

                    cCeldaPDF DetalleHorasAsignadas = new cCeldaPDF();
                    DetalleHorasAsignadas.Contenido = item.HorasAsignadas.TotalHours + ":" + item.HorasAsignadas.Minutes;
                    FilaDetalle.ListaCeldas.Add(DetalleHorasAsignadas);

                    cCeldaPDF DetalleHorasTrabjadas = new cCeldaPDF();
                    DetalleHorasTrabjadas.Contenido = item.HorasTrabajadas.TotalHours + ":" + item.HorasTrabajadas.Minutes;
                    FilaDetalle.ListaCeldas.Add(DetalleHorasTrabjadas);

                    cCeldaPDF DetalleMinutostarde = new cCeldaPDF();
                    DetalleMinutostarde.Contenido = item.MinutosTarde.ToString();
                    if (item.MinutosTarde > 0)
                    {
                        DetalleMinutostarde.ColorLetra = System.Drawing.Color.Red;
                    }
                    FilaDetalle.ListaCeldas.Add(DetalleMinutostarde);

                    cCeldaPDF DetalleExcepcionEntrada = new cCeldaPDF("");
                    if (item.ListaSalidas.Count > 0)
                    {
                        DetalleExcepcionEntrada.Contenido = item.ListaSalidas[0].InicioExcepcion.ToShortTimeString();
                    }
                    FilaDetalle.ListaCeldas.Add(DetalleExcepcionEntrada);

                    cCeldaPDF DetalleExcepcionFin = new cCeldaPDF("");
                    if (item.ListaSalidas.Count > 0)
                    {
                        DetalleExcepcionFin.Contenido = item.ListaSalidas[0].FinExcepcion.ToShortDateString();
                    }
                    FilaDetalle.ListaCeldas.Add(DetalleExcepcionFin);

                    cCeldaPDF DetalleFalta = new cCeldaPDF("");
                    if ((item.Falta == cAsistenciaDia.TipoFalta.FaltaTotal) || (item.Falta == cAsistenciaDia.TipoFalta.FaltaPicadoFinal) || (item.Falta == cAsistenciaDia.TipoFalta.FaltaPicadoEntrada))
                    {
                        DetalleFalta.Contenido = "1";
                        DetalleFalta.ColorLetra = System.Drawing.Color.Red;
                    }
                    FilaDetalle.ListaCeldas.Add(DetalleFalta);

                    cCeldaPDF DetalleTipoFalta = new cCeldaPDF();
                    switch (item.EventoDia)
                    {
                        case cAsistenciaDia.TipoDia.DiaLaborable:
                            DetalleTipoFalta.Contenido = "Normal";
                            break;
                        case cAsistenciaDia.TipoDia.DiaFestivo:
                            DetalleTipoFalta.Contenido = "Feriado";
                            DetalleTipoFalta.ColorLetra = System.Drawing.Color.Blue;
                            break;
                        case cAsistenciaDia.TipoDia.DiaLibre:
                            DetalleTipoFalta.Contenido = "Libre";
                            DetalleTipoFalta.ColorLetra = System.Drawing.Color.Blue;
                            break;
                        default:
                            break;
                    }
                    FilaDetalle.ListaCeldas.Add(DetalleTipoFalta);
                TablaDetalleDetalle.ListaFilas.Add(FilaDetalle);
               
            }

            oHojaPDF.ListaDeTablas.Add(TablaTituloPrincipal);
            oHojaPDF.ListaDeTablas.Add(TablaTitulo1);

            oHojaPDF.ListaDeTablas.Add(TablaTitulo2);
            oHojaPDF.ListaDeTablas.Add(TablaTitulo3);
            oHojaPDF.ListaDeTablas.Add(TablaDetalle);
            oHojaPDF.ListaDeTablas.Add(TablaDetalleDetalle);
            oReporte.ListaHojasPDF.Add(oHojaPDF);

            ImprimirReportePDF(oReporte);
         
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
