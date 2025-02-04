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
        cDatosGenerales oDatosGenerales = new cDatosGenerales();

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
            NombreEmpresa.Contenido = oDatosGenerales.Nombre;
            FilaTitulo1.ListaCeldas.Add(NombreEmpresa);

            cCeldaPDF LabelRuc = new cCeldaPDF();
            LabelRuc.Contenido = "RUC:";
            FilaTitulo1.ListaCeldas.Add(LabelRuc);

            cCeldaPDF NumeroRuc = new cCeldaPDF();
            NumeroRuc.Contenido =oDatosGenerales.Ruc ;
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
                        DetalleExcepcionEntrada.Contenido = item.ListaSalidas[0].InicioExcepcion.ToShortTimeString() + Environment.NewLine + item.ListaSalidas[0].FinExcepcion.ToShortTimeString();
                    }
                    FilaDetalle.ListaCeldas.Add(DetalleExcepcionEntrada);

                    cCeldaPDF DetalleExcepcionFin = new cCeldaPDF("");
                    if (item.ListaSalidas.Count > 0)
                    {
                        DetalleExcepcionFin.Contenido = item.ListaSalidas[0].Tipo + Environment.NewLine + "Nº" + item.ListaSalidas[0].CodigoExcepcion.ToString();
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
                        switch (item.Falta)
                        {
                            case cAsistenciaDia.TipoFalta.FaltaPicadoEntrada:
                                DetalleTipoFalta.Contenido = "Falta(E)";
                                DetalleTipoFalta.ColorLetra = System.Drawing.Color.OrangeRed;
                                break;
                            case cAsistenciaDia.TipoFalta.FaltaPicadoFinal:
                                DetalleTipoFalta.Contenido = "Falta(S)";
                                DetalleTipoFalta.ColorLetra = System.Drawing.Color.OrangeRed;
                                break;
                            case cAsistenciaDia.TipoFalta.FaltaJustificada:
                                DetalleTipoFalta.Contenido = "Justificada";
                                DetalleTipoFalta.ColorLetra = System.Drawing.Color.Green;
                                break;
                            case cAsistenciaDia.TipoFalta.FaltaTotal:
                                DetalleTipoFalta.Contenido = "Falta(ES)";
                                DetalleTipoFalta.ColorLetra = System.Drawing.Color.OrangeRed;
                                break;
                            case cAsistenciaDia.TipoFalta.SinFalta:
                                DetalleTipoFalta.Contenido = "Normal";
                                break;
                            default:
                                break;
                        }
                            break;
                        case cAsistenciaDia.TipoDia.DiaFestivo:
                            DetalleTipoFalta.Contenido = "Feriado";
                            DetalleTipoFalta.ColorLetra = System.Drawing.Color.LightSteelBlue;
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

            cTablaPDF TablaResumenDetalle = new cTablaPDF();
            TablaResumenDetalle.columnas = 6;
            TablaResumenDetalle.anchoColumnas = new float[] { 350f, 100f, 50f, 100f, 50f, 50f };

            cFilasPDF FilaResumen = new cFilasPDF();
            cCeldaPDF ResumenTitulo = new cCeldaPDF();
            ResumenTitulo.AltoColumna = 12f;
            ResumenTitulo.Contenido = "Resumen"; 
            FilaResumen.ListaCeldas.Add(ResumenTitulo);

            cCeldaPDF ResumenTituloTardanzas = new cCeldaPDF();
            ResumenTituloTardanzas.AltoColumna = 12f;
            ResumenTituloTardanzas.Contenido = "Total Min.";
            FilaResumen.ListaCeldas.Add(ResumenTituloTardanzas);

            cCeldaPDF ResumenTardanzas = new cCeldaPDF();
            ResumenTardanzas.AltoColumna = 12f;
            ResumenTardanzas.Contenido = oAsistenciaMes.TotalMinutosTarde.ToString();
            FilaResumen.ListaCeldas.Add(ResumenTardanzas);

            cCeldaPDF ResumenTituloFaltas = new cCeldaPDF();
            ResumenTituloFaltas.AltoColumna = 12f;
            ResumenTituloFaltas.Contenido = "Total Falt.";
            FilaResumen.ListaCeldas.Add(ResumenTituloFaltas);

            cCeldaPDF ResumenFaltas = new cCeldaPDF();
            ResumenFaltas.AltoColumna = 12f;
            ResumenFaltas.Contenido = oAsistenciaMes.TotalFaltasMes.ToString();
            FilaResumen.ListaCeldas.Add(ResumenFaltas);

            TablaResumenDetalle.ListaFilas.Add(FilaResumen);

            oHojaPDF.ListaDeTablas.Add(TablaTituloPrincipal);
            oHojaPDF.ListaDeTablas.Add(TablaTitulo1);

            oHojaPDF.ListaDeTablas.Add(TablaTitulo2);
            oHojaPDF.ListaDeTablas.Add(TablaTitulo3);
            oHojaPDF.ListaDeTablas.Add(TablaDetalle);
            oHojaPDF.ListaDeTablas.Add(TablaDetalleDetalle);
            oHojaPDF.ListaDeTablas.Add(TablaResumenDetalle);
            oReporte.ListaHojasPDF.Add(oHojaPDF);

            ImprimirReportePDF(oReporte);
         
        }


        public void ImprimirReporteAsistenciaGrupal(List<CapaDeNegocios.Reportes.cReporteMultipleAsistencia> AsistenciasMes, string RutaArchivo)
        {
            try
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
                NombreEmpresa.Contenido = oDatosGenerales.Nombre;
                FilaTitulo1.ListaCeldas.Add(NombreEmpresa);

                cCeldaPDF LabelRuc = new cCeldaPDF();
                LabelRuc.Contenido = "RUC:";
                FilaTitulo1.ListaCeldas.Add(LabelRuc);

                cCeldaPDF NumeroRuc = new cCeldaPDF();
                NumeroRuc.Contenido = oDatosGenerales.Ruc;
                FilaTitulo1.ListaCeldas.Add(NumeroRuc);

                cCeldaPDF LabelFecha = new cCeldaPDF();
                LabelFecha.Contenido = "Fecha: ";
                FilaTitulo1.ListaCeldas.Add(LabelFecha);

                cCeldaPDF ValorFecha = new cCeldaPDF();
                ValorFecha.Contenido = DateTime.Now.ToString();
                FilaTitulo1.ListaCeldas.Add(ValorFecha);

                TablaTitulo1.ListaFilas.Add(FilaTitulo1);

                oHojaPDF.ListaDeTablas.Add(TablaTituloPrincipal);
                oHojaPDF.ListaDeTablas.Add(TablaTitulo1);

                cTablaPDF TablaVacia = new cTablaPDF();
                TablaVacia.columnas = 3;
                TablaVacia.anchoColumnas = new float[] { 50f, 50f, 50f };
                cFilasPDF FilaVacia = new cFilasPDF();
                cCeldaPDF CeldaVacia = new cCeldaPDF();
                CeldaVacia.QuitarBordes();
                CeldaVacia.BordeAnchos.AnchoDerecha = 0;
                CeldaVacia.BordeAnchos.AnchoIzquierda = 0;
                FilaVacia.ListaCeldas.Add(CeldaVacia);
                FilaVacia.ListaCeldas.Add(CeldaVacia);
                FilaVacia.ListaCeldas.Add(CeldaVacia);
                TablaVacia.ListaFilas.Add(FilaVacia);


                foreach (cReporteMultipleAsistencia reporte in AsistenciasMes)
                {
                    cAsistenciaMes oAsistenciaMes = reporte.AsistenciaMes;
                    cTablaPDF TablaTitulo2 = new cTablaPDF();
                    TablaTitulo2.columnas = 3;
                    TablaTitulo2.anchoColumnas = new float[] { 50f, 50f, 50f };
                    cFilasPDF FilaTitulos2 = new cFilasPDF();

                    cCeldaPDF LabelDNI = new cCeldaPDF();
                    LabelDNI.Contenido = "DNI: ";
                    FilaTitulos2.ListaCeldas.Add(LabelDNI);

                    cCeldaPDF NumeroDNI = new cCeldaPDF();
                    NumeroDNI.Contenido = oAsistenciaMes.Trabajador.Dni;
                    FilaTitulos2.ListaCeldas.Add(NumeroDNI);

                    cCeldaPDF LabelNombres = new cCeldaPDF();
                    LabelNombres.Contenido = oAsistenciaMes.Trabajador.ApellidoPaterno + " " + oAsistenciaMes.Trabajador.ApellidoMaterno + ", " + oAsistenciaMes.Trabajador.Nombres;
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
                    labelEntradaSalida.TablaPDF.anchoColumnas = new float[] { 50f, 50f };
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
                        DetalleFecha.Contenido = item.Dia.ToString("ddd dd/MM/yyyy");
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
                            DetalleExcepcionEntrada.Contenido = item.ListaSalidas[0].InicioExcepcion.ToShortTimeString() + Environment.NewLine + item.ListaSalidas[0].FinExcepcion.ToShortTimeString();
                        }
                        FilaDetalle.ListaCeldas.Add(DetalleExcepcionEntrada);

                        cCeldaPDF DetalleExcepcionFin = new cCeldaPDF("");
                        if (item.ListaSalidas.Count > 0)
                        {
                            DetalleExcepcionFin.Contenido = item.ListaSalidas[0].Tipo + Environment.NewLine + "Nº" + item.ListaSalidas[0].CodigoExcepcion.ToString();
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
                                switch (item.Falta)
                                {
                                    case cAsistenciaDia.TipoFalta.FaltaPicadoEntrada:
                                        DetalleTipoFalta.Contenido = "Falta(E)";
                                        DetalleTipoFalta.ColorLetra = System.Drawing.Color.Red;
                                        break;
                                    case cAsistenciaDia.TipoFalta.FaltaPicadoFinal:
                                        DetalleTipoFalta.Contenido = "Falta(S)";
                                        DetalleTipoFalta.ColorLetra = System.Drawing.Color.Red;
                                        break;
                                    case cAsistenciaDia.TipoFalta.FaltaJustificada:
                                        DetalleTipoFalta.Contenido = "Justificada";
                                        DetalleTipoFalta.ColorLetra = System.Drawing.Color.Green;
                                        break;
                                    case cAsistenciaDia.TipoFalta.FaltaTotal:
                                        DetalleTipoFalta.Contenido = "Falta(ES)";
                                        DetalleTipoFalta.ColorLetra = System.Drawing.Color.Red;
                                        break;
                                    case cAsistenciaDia.TipoFalta.SinFalta:
                                        DetalleTipoFalta.Contenido = "Normal";
                                        if (item.Tarde)
                                        {
                                            DetalleTipoFalta.Contenido = "Normal" + Environment.NewLine + "Tarde";
                                            DetalleTipoFalta.ColorLetra = System.Drawing.Color.OrangeRed;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case cAsistenciaDia.TipoDia.DiaFestivo:
                                DetalleTipoFalta.Contenido = "Feriado";
                                DetalleTipoFalta.ColorLetra = System.Drawing.Color.LightSteelBlue;
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

                    cTablaPDF TablaResumenDetalle = new cTablaPDF();
                    TablaResumenDetalle.columnas = 6;
                    TablaResumenDetalle.anchoColumnas = new float[] { 350f, 100f, 50f, 100f, 50f, 50f };

                    cFilasPDF FilaResumen = new cFilasPDF();
                    cCeldaPDF ResumenTitulo = new cCeldaPDF();
                    ResumenTitulo.AltoColumna = 12f;
                    ResumenTitulo.Contenido = "Resumen";
                    FilaResumen.ListaCeldas.Add(ResumenTitulo);

                    cCeldaPDF ResumenTituloTardanzas = new cCeldaPDF();
                    ResumenTituloTardanzas.AltoColumna = 12f;
                    ResumenTituloTardanzas.Contenido = "Total Min.";
                    FilaResumen.ListaCeldas.Add(ResumenTituloTardanzas);

                    cCeldaPDF ResumenTardanzas = new cCeldaPDF();
                    ResumenTardanzas.AltoColumna = 12f;
                    ResumenTardanzas.Contenido = oAsistenciaMes.TotalMinutosTarde.ToString();
                    FilaResumen.ListaCeldas.Add(ResumenTardanzas);

                    cCeldaPDF ResumenTituloFaltas = new cCeldaPDF();
                    ResumenTituloFaltas.AltoColumna = 12f;
                    ResumenTituloFaltas.Contenido = "Total Falt.";
                    FilaResumen.ListaCeldas.Add(ResumenTituloFaltas);

                    cCeldaPDF ResumenFaltas = new cCeldaPDF();
                    ResumenFaltas.AltoColumna = 12f;
                    ResumenFaltas.Contenido = oAsistenciaMes.TotalFaltasMes.ToString();
                    FilaResumen.ListaCeldas.Add(ResumenFaltas);

                    TablaResumenDetalle.ListaFilas.Add(FilaResumen);

                    oHojaPDF.ListaDeTablas.Add(TablaTitulo2);
                    oHojaPDF.ListaDeTablas.Add(TablaTitulo3);
                    oHojaPDF.ListaDeTablas.Add(TablaDetalle);
                    oHojaPDF.ListaDeTablas.Add(TablaDetalleDetalle);
                    oHojaPDF.ListaDeTablas.Add(TablaResumenDetalle);
                    oHojaPDF.ListaDeTablas.Add(TablaVacia);
                }
                oReporte.ListaHojasPDF.Add(oHojaPDF);

                ImprimirReportePDF(oReporte);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo ImprimirReporteAsistenciaGrupal: " + ex.Message);
            }
        }


        public void ImprimirReporteAsistenciaGrupal2(List<CapaDeNegocios.Reportes.cReporteMultipleAsistencia> AsistenciasMes, string RutaArchivo)
        {
            try
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
                NombreEmpresa.Contenido = oDatosGenerales.Nombre;
                FilaTitulo1.ListaCeldas.Add(NombreEmpresa);

                cCeldaPDF LabelRuc = new cCeldaPDF();
                LabelRuc.Contenido = "RUC:";
                FilaTitulo1.ListaCeldas.Add(LabelRuc);

                cCeldaPDF NumeroRuc = new cCeldaPDF();
                NumeroRuc.Contenido = oDatosGenerales.Ruc;
                FilaTitulo1.ListaCeldas.Add(NumeroRuc);

                cCeldaPDF LabelFecha = new cCeldaPDF();
                LabelFecha.Contenido = "Fecha: ";
                FilaTitulo1.ListaCeldas.Add(LabelFecha);

                cCeldaPDF ValorFecha = new cCeldaPDF();
                ValorFecha.Contenido = DateTime.Now.ToString();
                FilaTitulo1.ListaCeldas.Add(ValorFecha);

                TablaTitulo1.ListaFilas.Add(FilaTitulo1);

                oHojaPDF.ListaDeTablas.Add(TablaTituloPrincipal);
                oHojaPDF.ListaDeTablas.Add(TablaTitulo1);

                cTablaPDF TablaVacia = new cTablaPDF();
                TablaVacia.columnas = 3;
                TablaVacia.anchoColumnas = new float[] { 50f, 50f, 50f };
                cFilasPDF FilaVacia = new cFilasPDF();
                cCeldaPDF CeldaVacia = new cCeldaPDF();
                CeldaVacia.QuitarBordes();
                CeldaVacia.BordeAnchos.AnchoDerecha = 0;
                CeldaVacia.BordeAnchos.AnchoIzquierda = 0;
                FilaVacia.ListaCeldas.Add(CeldaVacia);
                FilaVacia.ListaCeldas.Add(CeldaVacia);
                FilaVacia.ListaCeldas.Add(CeldaVacia);
                TablaVacia.ListaFilas.Add(FilaVacia);


                foreach (cReporteMultipleAsistencia reporte in AsistenciasMes)
                {
                    cAsistenciaMes oAsistenciaMes = reporte.AsistenciaMes;
                    cTablaPDF TablaTitulo2 = new cTablaPDF();
                    TablaTitulo2.columnas = 3;
                    TablaTitulo2.anchoColumnas = new float[] { 50f, 50f, 50f };
                    cFilasPDF FilaTitulos2 = new cFilasPDF();

                    cCeldaPDF LabelNombres = new cCeldaPDF();
                    LabelNombres.Contenido = oAsistenciaMes.Trabajador.ApellidoPaterno + " " + oAsistenciaMes.Trabajador.ApellidoMaterno + ", " + oAsistenciaMes.Trabajador.Nombres;
                    LabelNombres.ColorFondo = System.Drawing.Color.LightGray;
                    FilaTitulos2.ListaCeldas.Add(LabelNombres);

                    cCeldaPDF LabelDNI = new cCeldaPDF();
                    LabelDNI.Contenido = "DNI: ";
                    FilaTitulos2.ListaCeldas.Add(LabelDNI);

                    cCeldaPDF NumeroDNI = new cCeldaPDF();
                    NumeroDNI.Contenido = oAsistenciaMes.Trabajador.Dni;
                    FilaTitulos2.ListaCeldas.Add(NumeroDNI);

                   

                    TablaTitulo2.ListaFilas.Add(FilaTitulos2);

                    cTablaPDF TablaTitulo3 = new cTablaPDF();
                    TablaTitulo3.columnas = 4;
                    TablaTitulo3.anchoColumnas = new float[] { 50f, 50f, 50f, 50f };

                    cFilasPDF FilaTitulos3 = new cFilasPDF();

                    cCeldaPDF LabelCargo = new cCeldaPDF();
                    LabelCargo.Contenido = "Cargo: ";
                    FilaTitulos3.ListaCeldas.Add(LabelCargo);

                    cCeldaPDF NombreCargo = new cCeldaPDF();
                    NombreCargo.Contenido = "-";
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
                    labelEntradaSalida.TablaPDF.anchoColumnas = new float[] { 50f, 50f };
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

                    cCeldaPDF labelTipoHorario = new cCeldaPDF("Ocurren cia");
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
                        DetalleFecha.Contenido = item.Dia.ToString("ddd dd/MM/yyyy");
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
                            DetalleExcepcionEntrada.Contenido = item.ListaSalidas[0].InicioExcepcion.ToShortTimeString() + Environment.NewLine + item.ListaSalidas[0].FinExcepcion.ToShortTimeString();
                        }
                        FilaDetalle.ListaCeldas.Add(DetalleExcepcionEntrada);

                        cCeldaPDF DetalleExcepcionFin = new cCeldaPDF("");
                        if (item.ListaSalidas.Count > 0)
                        {
                            DetalleExcepcionFin.Contenido = item.ListaSalidas[0].Tipo + Environment.NewLine + "Nº" + item.ListaSalidas[0].CodigoExcepcion.ToString();
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
                                switch (item.Falta)
                                {
                                    case cAsistenciaDia.TipoFalta.FaltaPicadoEntrada:
                                        DetalleTipoFalta.Contenido = "Falta(E)";
                                        DetalleTipoFalta.ColorLetra = System.Drawing.Color.Red;
                                        break;
                                    case cAsistenciaDia.TipoFalta.FaltaPicadoFinal:
                                        DetalleTipoFalta.Contenido = "Falta(S)";
                                        DetalleTipoFalta.ColorLetra = System.Drawing.Color.Red;
                                        break;
                                    case cAsistenciaDia.TipoFalta.FaltaJustificada:
                                        DetalleTipoFalta.Contenido = "Justificada";
                                        DetalleTipoFalta.ColorLetra = System.Drawing.Color.Green;
                                        break;
                                    case cAsistenciaDia.TipoFalta.FaltaTotal:
                                        DetalleTipoFalta.Contenido = "Falta(ES)";
                                        DetalleTipoFalta.ColorLetra = System.Drawing.Color.Red;
                                        break;
                                    case cAsistenciaDia.TipoFalta.SinFalta:
                                        DetalleTipoFalta.Contenido = "Normal";
                                        if (item.Tarde)
                                        {
                                            DetalleTipoFalta.Contenido = "Normal" + Environment.NewLine + "Tarde";
                                            DetalleTipoFalta.ColorLetra = System.Drawing.Color.OrangeRed;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case cAsistenciaDia.TipoDia.DiaFestivo:
                                DetalleTipoFalta.Contenido = "Feriado";
                                DetalleTipoFalta.ColorLetra = System.Drawing.Color.LightSteelBlue;
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

                    cTablaPDF TablaResumenDetalle = new cTablaPDF();
                    TablaResumenDetalle.columnas = 6;
                    TablaResumenDetalle.anchoColumnas = new float[] { 350f, 100f, 50f, 100f, 50f, 50f };

                    cFilasPDF FilaResumen = new cFilasPDF();
                    cCeldaPDF ResumenTitulo = new cCeldaPDF();
                    ResumenTitulo.AltoColumna = 12f;
                    ResumenTitulo.Contenido = "Resumen";
                    FilaResumen.ListaCeldas.Add(ResumenTitulo);

                    cCeldaPDF ResumenTituloTardanzas = new cCeldaPDF();
                    ResumenTituloTardanzas.AltoColumna = 12f;
                    ResumenTituloTardanzas.Contenido = "Total Min.";
                    FilaResumen.ListaCeldas.Add(ResumenTituloTardanzas);

                    cCeldaPDF ResumenTardanzas = new cCeldaPDF();
                    ResumenTardanzas.AltoColumna = 12f;
                    ResumenTardanzas.Contenido = oAsistenciaMes.TotalMinutosTarde.ToString();
                    FilaResumen.ListaCeldas.Add(ResumenTardanzas);

                    cCeldaPDF ResumenTituloFaltas = new cCeldaPDF();
                    ResumenTituloFaltas.AltoColumna = 12f;
                    ResumenTituloFaltas.Contenido = "Total Falt.";
                    FilaResumen.ListaCeldas.Add(ResumenTituloFaltas);

                    cCeldaPDF ResumenFaltas = new cCeldaPDF();
                    ResumenFaltas.AltoColumna = 12f;
                    ResumenFaltas.Contenido = oAsistenciaMes.TotalFaltasMes.ToString();
                    FilaResumen.ListaCeldas.Add(ResumenFaltas);

                    TablaResumenDetalle.ListaFilas.Add(FilaResumen);

                    oHojaPDF.ListaDeTablas.Add(TablaTitulo2);
                    //oHojaPDF.ListaDeTablas.Add(TablaTitulo3);
                    oHojaPDF.ListaDeTablas.Add(TablaDetalle);
                    oHojaPDF.ListaDeTablas.Add(TablaDetalleDetalle);
                    oHojaPDF.ListaDeTablas.Add(TablaResumenDetalle);
                    oHojaPDF.ListaDeTablas.Add(TablaVacia);
                }
                oReporte.ListaHojasPDF.Add(oHojaPDF);

                ImprimirReportePDF(oReporte);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo ImprimirReporteAsistenciaGrupal: " + ex.Message);
            }
        }

        public void ImprimirReporteAsistenciaXTrabajadorXMes(cTrabajador oTrabajador, cAsistenciaMes oAsistenciaMes, string RutaArchivo)
        {

            cReportePDF oReporte = new cReportePDF();
            oReporte.FormatoHoja = cReportePDF.enumFormatoHoja.Horizontal;
            oReporte.RutaArchivo = RutaArchivo;

            cHojaPDF oHojaPDF = new cHojaPDF();

            
            cTablaPDF TablaTituloPrincipal = new cTablaPDF();
            TablaTituloPrincipal.columnas = 1;
            TablaTituloPrincipal.anchoColumnas = new float[] { 600f };

            cFilasPDF FilaTituloPrincipal = new cFilasPDF();

            cCeldaPDF TituloPrincipal = new cCeldaPDF();
            TituloPrincipal.Contenido = "Reporte de Asistencia del " + oAsistenciaMes.InicioMes.ToShortDateString() + " al " + oAsistenciaMes.FinMes.ToShortDateString();
            TituloPrincipal.ColorFondo = System.Drawing.Color.LightGray;
            FilaTituloPrincipal.ListaCeldas.Add(TituloPrincipal);

            TablaTituloPrincipal.ListaFilas.Add(FilaTituloPrincipal);

            cTablaPDF TablaTitulo1 = new cTablaPDF();
            TablaTitulo1.columnas = 4;
            TablaTitulo1.anchoColumnas = new float[] { 150f, 150f, 150f, 150f};

            cFilasPDF FilaTitulo1 = new cFilasPDF();

            cCeldaPDF LabelEmpresa = new cCeldaPDF();
            LabelEmpresa.Contenido = "Empresa:";
            FilaTitulo1.ListaCeldas.Add(LabelEmpresa);

            cCeldaPDF NombreEmpresa = new cCeldaPDF();
            NombreEmpresa.Contenido = oDatosGenerales.Nombre;
            FilaTitulo1.ListaCeldas.Add(NombreEmpresa);

            cCeldaPDF LabelRuc = new cCeldaPDF();
            LabelRuc.Contenido = "RUC:";
            FilaTitulo1.ListaCeldas.Add(LabelRuc);

            cCeldaPDF NumeroRuc = new cCeldaPDF();
            NumeroRuc.Contenido = oDatosGenerales.Ruc;
            FilaTitulo1.ListaCeldas.Add(NumeroRuc);
            TablaTitulo1.ListaFilas.Add(FilaTitulo1);
           

            cTablaPDF TablaTitulo2 = new cTablaPDF();
            TablaTitulo2.columnas = 1;
            TablaTitulo2.anchoColumnas = new float[] { 100f};
            cFilasPDF FilaTitulos2 = new cFilasPDF();

            cCeldaPDF LabelDNI = new cCeldaPDF();
            LabelDNI.Contenido = "";
            FilaTitulos2.ListaCeldas.Add(LabelDNI);

            TablaTitulo2.ListaFilas.Add(FilaTitulos2);


            //Encabezado de detalle de asistencia
            int numeroDias = (oAsistenciaMes.FinMes - oAsistenciaMes.InicioMes).Days + 1;


            cTablaPDF TablaDetalle = new cTablaPDF();
            TablaDetalle.columnas = numeroDias + 5;
            TablaDetalle.anchoColumnas = new float[numeroDias + 5];


            
            TablaDetalle.anchoColumnas[0] = 50f;
            TablaDetalle.anchoColumnas[1] = 280f;
            TablaDetalle.anchoColumnas[2] = 110f;

            for (int i = 3; i < numeroDias+ 3; i++)
            {
                TablaDetalle.anchoColumnas[i] = 55f;
            }
            //Ancho del resumen de faltas y tardanzas
            TablaDetalle.anchoColumnas[numeroDias+3] = 100f;
            TablaDetalle.anchoColumnas[numeroDias+4] = 100f;

            cFilasPDF FilaTituloDetalle = new cFilasPDF();
            cFilasPDF FilaTituloDetalle2 = new cFilasPDF();

            cCeldaPDF TituloNro = new cCeldaPDF();
            TituloNro.Contenido = "Nº";
            FilaTituloDetalle.ListaCeldas.Add(TituloNro);

            cCeldaPDF TituloNombres = new cCeldaPDF();
            TituloNombres.Contenido = "Nombres";
            FilaTituloDetalle.ListaCeldas.Add(TituloNombres);

            cCeldaPDF TituloDNI = new cCeldaPDF();
            TituloDNI.Contenido = "DNI";
            FilaTituloDetalle.ListaCeldas.Add(TituloDNI);

            cCeldaPDF Vacio1 = new cCeldaPDF();
            FilaTituloDetalle2.ListaCeldas.Add(Vacio1);

            cCeldaPDF Vacio2 = new cCeldaPDF();
            FilaTituloDetalle2.ListaCeldas.Add(Vacio2);

            cCeldaPDF Vacio3 = new cCeldaPDF();
            FilaTituloDetalle2.ListaCeldas.Add(Vacio3);

            for (int i = 0; i < numeroDias; i++)
            {
                cCeldaPDF labelTituloDetalle = new cCeldaPDF();
                labelTituloDetalle.Contenido = ConvertirFecha(oAsistenciaMes.InicioMes.AddDays(i));
                FilaTituloDetalle.ListaCeldas.Add(labelTituloDetalle);

                cCeldaPDF labelTituloDetalle2 = new cCeldaPDF();
                labelTituloDetalle2.Contenido = oAsistenciaMes.InicioMes.AddDays(i).Day .ToString();
                FilaTituloDetalle2.ListaCeldas.Add(labelTituloDetalle2);
            }

            cCeldaPDF labelTituloResumenT = new cCeldaPDF();
            labelTituloResumenT.Contenido = "Resum. Tar.";
            FilaTituloDetalle.ListaCeldas.Add(labelTituloResumenT);
            FilaTituloDetalle2.ListaCeldas.Add(Vacio3);

            cCeldaPDF labelTituloResumenF = new cCeldaPDF();
            labelTituloResumenF.Contenido = "Resum. Fal.";
            FilaTituloDetalle.ListaCeldas.Add(labelTituloResumenF);
            FilaTituloDetalle2.ListaCeldas.Add(Vacio3);

            cFilasPDF FilaDetalle = new cFilasPDF();

            cCeldaPDF Numero = new cCeldaPDF();
            Numero.Contenido = "1";
            FilaDetalle.ListaCeldas.Add(Numero);

            cCeldaPDF LabelNombres = new cCeldaPDF();
            LabelNombres.Contenido = oTrabajador.ApellidoPaterno + " " + oTrabajador.ApellidoMaterno + ", " + oTrabajador.Nombres;
            FilaDetalle.ListaCeldas.Add(LabelNombres);

            cCeldaPDF NumeroDNI = new cCeldaPDF();
            NumeroDNI.Contenido = oTrabajador.Dni;
            FilaDetalle.ListaCeldas.Add(NumeroDNI);

            for (int i = 0; i < numeroDias; i++)
            {
                cCeldaPDF labelDetalle = new cCeldaPDF();
                switch (oAsistenciaMes.ListaAsistenciaDia[i].EventoDia)
                {
                    case cAsistenciaDia.TipoDia.DiaLaborable:
                        switch (oAsistenciaMes.ListaAsistenciaDia[i].Falta)
                        {
                            case cAsistenciaDia.TipoFalta.FaltaPicadoEntrada:
                                labelDetalle.Contenido = "F" + Environment.NewLine + "(E)";
                                labelDetalle.ColorLetra = System.Drawing.Color.Red;
                                break;
                            case cAsistenciaDia.TipoFalta.FaltaPicadoFinal:
                                labelDetalle.Contenido = "F" + Environment.NewLine + "(S)";
                                labelDetalle.ColorLetra = System.Drawing.Color.Red;
                                break;
                            case cAsistenciaDia.TipoFalta.FaltaJustificada:
                                labelDetalle.Contenido = "J";
                                labelDetalle.ColorLetra = System.Drawing.Color.Green;
                                break;
                            case cAsistenciaDia.TipoFalta.FaltaTotal:
                                labelDetalle.Contenido = "F" + Environment.NewLine + "(ES)";
                                labelDetalle.ColorLetra = System.Drawing.Color.Red;
                                break;
                            case cAsistenciaDia.TipoFalta.SinFalta:
                                labelDetalle.Contenido = "N";
                                break;
                            default:
                                break;
                        }
                        break;
                    case cAsistenciaDia.TipoDia.DiaFestivo:
                        labelDetalle.Contenido = "LF";
                        labelDetalle.ColorLetra = System.Drawing.Color.LightSteelBlue;
                        break;
                    case cAsistenciaDia.TipoDia.DiaLibre:
                        labelDetalle.Contenido = "L";
                        labelDetalle.ColorLetra = System.Drawing.Color.Blue;
                        break;
                    default:
                        break;
                }     
                
                if (oAsistenciaMes.ListaAsistenciaDia[i].Tarde)
                {
                    labelDetalle.Contenido = "T";
                    labelDetalle.ColorLetra = System.Drawing.Color.OrangeRed;
                }
                FilaDetalle.ListaCeldas.Add(labelDetalle);
            }
            cCeldaPDF ResumenTardanzas = new cCeldaPDF();
            ResumenTardanzas.Contenido = oAsistenciaMes.TotalTardanzas.ToString();
            FilaDetalle.ListaCeldas.Add(ResumenTardanzas);

            cCeldaPDF ResumenFaltas = new cCeldaPDF();
            ResumenFaltas.Contenido = oAsistenciaMes.TotalFaltasMes.ToString();
            FilaDetalle.ListaCeldas.Add(ResumenFaltas);

            TablaDetalle.ListaFilas.Add(FilaTituloDetalle);
            TablaDetalle.ListaFilas.Add(FilaTituloDetalle2);
            TablaDetalle.ListaFilas.Add(FilaDetalle);

            cTablaPDF TablaLeyenda = new cTablaPDF();
            TablaLeyenda.columnas = 2;
            TablaLeyenda.anchoColumnas = new float[] { 20f, 20f};

            cFilasPDF FilaDiaNormal = new cFilasPDF();
            cCeldaPDF CeldaTituloDiaNormal = new cCeldaPDF();
            CeldaTituloDiaNormal.Contenido = "Dia Normal";
            FilaDiaNormal.ListaCeldas.Add(CeldaTituloDiaNormal);

            cCeldaPDF CeldaDiaNormal = new cCeldaPDF();
            CeldaDiaNormal.Contenido = "N";
            FilaDiaNormal.ListaCeldas.Add(CeldaDiaNormal);

            TablaLeyenda.ListaFilas.Add(FilaDiaNormal);

            cFilasPDF FilaDiaJustificado = new cFilasPDF();
            cCeldaPDF CeldaTituloDiaJustificado = new cCeldaPDF();
            CeldaTituloDiaJustificado.Contenido = "Justificada -" + Environment.NewLine + "Papelete de Salida";
            FilaDiaJustificado.ListaCeldas.Add(CeldaTituloDiaJustificado);

            cCeldaPDF CeldaDiaJustificado = new cCeldaPDF();
            CeldaDiaJustificado.Contenido = "J";
            FilaDiaJustificado.ListaCeldas.Add(CeldaDiaJustificado);

            TablaLeyenda.ListaFilas.Add(FilaDiaJustificado);

            cFilasPDF FilaDiaFalta = new cFilasPDF();
            cCeldaPDF CeldaTituloDiaFalta = new cCeldaPDF();
            CeldaTituloDiaFalta.Contenido = "Falta Injustificada" +Environment.NewLine + "(ENTRADA-SALIDA)";
            FilaDiaFalta.ListaCeldas.Add(CeldaTituloDiaFalta);

            cCeldaPDF CeldaDiaFalta = new cCeldaPDF();
            CeldaDiaFalta.Contenido = "F" + Environment.NewLine + "(E-S)";
            FilaDiaFalta.ListaCeldas.Add(CeldaDiaFalta);

            TablaLeyenda.ListaFilas.Add(FilaDiaFalta);

            cFilasPDF FilaDiaTarde = new cFilasPDF();
            cCeldaPDF CeldaTituloDiatarde = new cCeldaPDF();
            CeldaTituloDiatarde.Contenido = "Tardanza";
            FilaDiaTarde.ListaCeldas.Add(CeldaTituloDiatarde);

            cCeldaPDF CeldaDiatarde = new cCeldaPDF();
            CeldaDiatarde.Contenido = "T";
            FilaDiaTarde.ListaCeldas.Add(CeldaDiatarde);

            TablaLeyenda.ListaFilas.Add(FilaDiaTarde);

            cFilasPDF FilaDiaFestivo = new cFilasPDF();
            cCeldaPDF CeldaTituloDiaFestivo = new cCeldaPDF();
            CeldaTituloDiaFestivo.Contenido = "Dia Festivo -" + Environment.NewLine + "Feriado";
            FilaDiaFestivo.ListaCeldas.Add(CeldaTituloDiaFestivo);

            cCeldaPDF CeldaDiaFestivo = new cCeldaPDF();
            CeldaDiaFestivo.Contenido = "LF";
            FilaDiaFestivo.ListaCeldas.Add(CeldaDiaFestivo);

            TablaLeyenda.ListaFilas.Add(FilaDiaFestivo);

            oHojaPDF.ListaDeTablas.Add(TablaTituloPrincipal);
            oHojaPDF.ListaDeTablas.Add(TablaTitulo1);
            oHojaPDF.ListaDeTablas.Add(TablaTitulo2);
            oHojaPDF.ListaDeTablas.Add(TablaDetalle);
            oHojaPDF.ListaDeTablas.Add(TablaLeyenda);

            oReporte.ListaHojasPDF.Add(oHojaPDF);

            ImprimirReportePDF(oReporte);

        }


        public void ImprimirReporteAsistenciMultipleAsistencia(List<cReporteMultipleAsistencia> ListaMultiple, string RutaArchivo, DateTime Inicio, DateTime Fin)
        {

            cReportePDF oReporte = new cReportePDF();

            oReporte.RutaArchivo = RutaArchivo;
            oReporte.FormatoHoja = cReportePDF.enumFormatoHoja.Horizontal;

            cHojaPDF oHojaPDF = new cHojaPDF();


            cTablaPDF TablaTituloPrincipal = new cTablaPDF();
            TablaTituloPrincipal.columnas = 1;
            TablaTituloPrincipal.anchoColumnas = new float[] { 500f };

            cFilasPDF FilaTituloPrincipal = new cFilasPDF();

            cCeldaPDF TituloPrincipal = new cCeldaPDF();
            TituloPrincipal.Contenido = "Reporte de Asistencia del " +  Inicio.ToShortDateString() + " al " + Fin.ToShortDateString();
            TituloPrincipal.ColorFondo = System.Drawing.Color.LightGray;
            FilaTituloPrincipal.ListaCeldas.Add(TituloPrincipal);

            TablaTituloPrincipal.ListaFilas.Add(FilaTituloPrincipal);

            cTablaPDF TablaTitulo1 = new cTablaPDF();
            TablaTitulo1.columnas = 4;
            TablaTitulo1.anchoColumnas = new float[] { 50f, 50f, 50f, 50f };

            cFilasPDF FilaTitulo1 = new cFilasPDF();

            cCeldaPDF LabelEmpresa = new cCeldaPDF();
            LabelEmpresa.Contenido = "Municipalidad:";
            FilaTitulo1.ListaCeldas.Add(LabelEmpresa);

            cCeldaPDF NombreEmpresa = new cCeldaPDF();
            NombreEmpresa.Contenido = oDatosGenerales.Nombre;
            FilaTitulo1.ListaCeldas.Add(NombreEmpresa);

            cCeldaPDF LabelRuc = new cCeldaPDF();
            LabelRuc.Contenido = "RUC:";
            FilaTitulo1.ListaCeldas.Add(LabelRuc);

            cCeldaPDF NumeroRuc = new cCeldaPDF();
            NumeroRuc.Contenido = oDatosGenerales.Ruc;
            FilaTitulo1.ListaCeldas.Add(NumeroRuc);
            TablaTitulo1.ListaFilas.Add(FilaTitulo1);


            cTablaPDF TablaTitulo2 = new cTablaPDF();
            TablaTitulo2.columnas = 1;
            TablaTitulo2.anchoColumnas = new float[] { 100f };
            cFilasPDF FilaTitulos2 = new cFilasPDF();

            cCeldaPDF LabelDNI = new cCeldaPDF();
            LabelDNI.Contenido = "";
            FilaTitulos2.ListaCeldas.Add(LabelDNI);

            TablaTitulo2.ListaFilas.Add(FilaTitulos2);


            //Encabezado de detalle de asistencia
            int numeroDias = (Fin - Inicio).Days + 1;


            cTablaPDF TablaDetalle = new cTablaPDF();
            TablaDetalle.columnas = numeroDias + 5;
            TablaDetalle.anchoColumnas = new float[numeroDias + 5];



            TablaDetalle.anchoColumnas[0] = 50f;
            TablaDetalle.anchoColumnas[1] = 280f;
            TablaDetalle.anchoColumnas[2] = 110f;

            for (int i = 3; i < numeroDias + 3; i++)
            {
                TablaDetalle.anchoColumnas[i] = 55f;
            }

            //Ancho del resumen de faltas y tardanzas
            TablaDetalle.anchoColumnas[numeroDias + 3] = 100f;
            TablaDetalle.anchoColumnas[numeroDias + 4] = 100f;

            cFilasPDF FilaTituloDetalle = new cFilasPDF();
            cFilasPDF FilaTituloDetalle2 = new cFilasPDF();

            cCeldaPDF TituloNro = new cCeldaPDF();
            TituloNro.Contenido = "Nº";
            FilaTituloDetalle.ListaCeldas.Add(TituloNro);

            cCeldaPDF TituloNombres = new cCeldaPDF();
            TituloNombres.Contenido = "Nombres";
            FilaTituloDetalle.ListaCeldas.Add(TituloNombres);

            cCeldaPDF TituloDNI = new cCeldaPDF();
            TituloDNI.Contenido = "DNI";
            FilaTituloDetalle.ListaCeldas.Add(TituloDNI);

            cCeldaPDF Vacio1 = new cCeldaPDF();
            FilaTituloDetalle2.ListaCeldas.Add(Vacio1);

            cCeldaPDF Vacio2 = new cCeldaPDF();
            FilaTituloDetalle2.ListaCeldas.Add(Vacio2);

            cCeldaPDF Vacio3 = new cCeldaPDF();
            FilaTituloDetalle2.ListaCeldas.Add(Vacio3);

            for (int i = 0; i < numeroDias; i++)
            {
                cCeldaPDF labelTituloDetalle = new cCeldaPDF();
                labelTituloDetalle.Contenido = ConvertirFecha(Inicio.AddDays(i));
                FilaTituloDetalle.ListaCeldas.Add(labelTituloDetalle);

                cCeldaPDF labelTituloDetalle2 = new cCeldaPDF();
                labelTituloDetalle2.Contenido = Inicio.AddDays(i).Day.ToString();
                FilaTituloDetalle2.ListaCeldas.Add(labelTituloDetalle2);
            }

            cCeldaPDF labelTituloResumenT = new cCeldaPDF();
            labelTituloResumenT.Contenido = "Resum. Tar.";
            FilaTituloDetalle.ListaCeldas.Add(labelTituloResumenT);
            FilaTituloDetalle2.ListaCeldas.Add(Vacio3);

            cCeldaPDF labelTituloResumenF = new cCeldaPDF();
            labelTituloResumenF.Contenido = "Resum. Fal.";
            FilaTituloDetalle.ListaCeldas.Add(labelTituloResumenF);
            FilaTituloDetalle2.ListaCeldas.Add(Vacio3);

            TablaDetalle.ListaFilas.Add(FilaTituloDetalle);
            TablaDetalle.ListaFilas.Add(FilaTituloDetalle2);

            int contador = 1;
            foreach (cReporteMultipleAsistencia item in ListaMultiple)
            {
                
                cFilasPDF FilaDetalle = new cFilasPDF();

                cCeldaPDF Numero = new cCeldaPDF();
                Numero.Contenido = contador.ToString();
                contador++;

                FilaDetalle.ListaCeldas.Add(Numero);

                cCeldaPDF LabelNombres = new cCeldaPDF();
                LabelNombres.Contenido = item.Trabajador.ApellidoPaterno + " " + item.Trabajador.ApellidoMaterno + ", " + item.Trabajador.Nombres;
                FilaDetalle.ListaCeldas.Add(LabelNombres);

                cCeldaPDF NumeroDNI = new cCeldaPDF();
                NumeroDNI.Contenido = item.Trabajador.Dni;
                FilaDetalle.ListaCeldas.Add(NumeroDNI);

                for (int i = 0; i < numeroDias; i++)
                {
                    cCeldaPDF labelDetalle = new cCeldaPDF();
                    switch (item.AsistenciaMes.ListaAsistenciaDia[i].EventoDia)
                    {
                        case cAsistenciaDia.TipoDia.DiaLaborable:
                            switch (item.AsistenciaMes.ListaAsistenciaDia[i].Falta)
                            {
                                case cAsistenciaDia.TipoFalta.FaltaPicadoEntrada:
                                    labelDetalle.Contenido = "F" + Environment.NewLine + "(E)";
                                    labelDetalle.ColorLetra = System.Drawing.Color.Red;
                                    break;
                                case cAsistenciaDia.TipoFalta.FaltaPicadoFinal:
                                    labelDetalle.Contenido = "F" + Environment.NewLine + "(S)";
                                    labelDetalle.ColorLetra = System.Drawing.Color.Red;
                                    break;
                                case cAsistenciaDia.TipoFalta.FaltaJustificada:
                                    labelDetalle.Contenido = "J";
                                    labelDetalle.ColorLetra = System.Drawing.Color.Green;
                                    break;
                                case cAsistenciaDia.TipoFalta.FaltaTotal:
                                    labelDetalle.Contenido = "F" + Environment.NewLine + "(ES)";
                                    labelDetalle.ColorLetra = System.Drawing.Color.Red;
                                    break;
                                case cAsistenciaDia.TipoFalta.SinFalta:
                                    labelDetalle.Contenido = "N";
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case cAsistenciaDia.TipoDia.DiaFestivo:
                            labelDetalle.Contenido = "DF";
                            labelDetalle.ColorLetra = System.Drawing.Color.LightSteelBlue;
                            break;
                        case cAsistenciaDia.TipoDia.DiaLibre:
                            labelDetalle.Contenido = "L";
                            labelDetalle.ColorLetra = System.Drawing.Color.Blue;
                            break;
                        
                        default:
                            break;
                    }
                    //if (item.AsistenciaMes.ListaAsistenciaDia[i].Falta == cAsistenciaDia.TipoFalta.SinFalta || item.AsistenciaMes.ListaAsistenciaDia[i].Falta == cAsistenciaDia.TipoFalta.FaltaJustificada)
                    //{
                    //    if (item.AsistenciaMes.ListaAsistenciaDia[i].Falta == cAsistenciaDia.TipoFalta.SinFalta)
                    //    {
                    //        labelDetalle.Contenido = "N";
                    //    }
                    //    else
                    //    {
                    //        labelDetalle.Contenido = "C";
                    //    }
                    //}
                    //else
                    //{
                    //    CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral jor = BuscarJornada(item.AsistenciaMes.ListaAsistenciaDia[i].Dia, item.JornadaLaboral);
                    //    if (jor == null)
                    //    {
                    //        labelDetalle.Contenido = "C";
                    //        labelDetalle.ColorLetra = System.Drawing.Color.Blue;
                    //    }
                    //    else
                    //    {
                    //        if (jor.TipoDia == AsistenciaGeneral.cDetalleJornadaLaboral.enumTipoDiaJornada.NoLaborado)
                    //        {
                    //            labelDetalle.Contenido = "F";
                    //            labelDetalle.ColorLetra = System.Drawing.Color.Red;
                    //        }
                    //        else
                    //        {
                    //            if (jor.TipoDia == AsistenciaGeneral.cDetalleJornadaLaboral.enumTipoDiaJornada.Subsidiado)
                    //            {
                    //                labelDetalle.Contenido = "S";
                    //                labelDetalle.ColorLetra = System.Drawing.Color.Blue;
                    //            }
                    //            if (jor.TipoDia == AsistenciaGeneral.cDetalleJornadaLaboral.enumTipoDiaJornada.Tardanza)
                    //            {
                    //                labelDetalle.Contenido = "T";
                    //                labelDetalle.ColorLetra = System.Drawing.Color.DarkOrange;
                    //            }
                    //        }
                    //    }

                    //}
                    if (item.AsistenciaMes.ListaAsistenciaDia[i].Tarde)
                    {
                        CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral jor = BuscarJornada(item.AsistenciaMes.ListaAsistenciaDia[i].Dia, item.JornadaLaboral);
                        if (jor == null)
                        {

                            labelDetalle.Contenido = "N";
                            labelDetalle.ColorLetra = System.Drawing.Color.Black;
                        }
                        else
                        {
                            if (jor.TipoDia == AsistenciaGeneral.cDetalleJornadaLaboral.enumTipoDiaJornada.Tardanza)
                            {

                                labelDetalle.Contenido = "T";
                                labelDetalle.ColorLetra = System.Drawing.Color.Orange;
                            }
                            else
                            {
                                labelDetalle.Contenido = "T";
                                labelDetalle.ColorLetra = System.Drawing.Color.Orange;
                            }
                        }
                        
                        
                    }
                    FilaDetalle.ListaCeldas.Add(labelDetalle);

                  
                }
                cCeldaPDF ResumenTardanzas = new cCeldaPDF();
                ResumenTardanzas.Contenido = item.AsistenciaMes.TotalTardanzas.ToString();
                FilaDetalle.ListaCeldas.Add(ResumenTardanzas);

                cCeldaPDF ResumenFaltas = new cCeldaPDF();
                ResumenFaltas.Contenido = item.AsistenciaMes.TotalFaltasMes.ToString();
                FilaDetalle.ListaCeldas.Add(ResumenFaltas);

                TablaDetalle.ListaFilas.Add(FilaDetalle);
            }

            cTablaPDF Tablavacia = new cTablaPDF();
            Tablavacia.columnas = 1;
            Tablavacia.anchoColumnas = new float[1] { 50f };
            cFilasPDF FilaVacia = new cFilasPDF();
            cCeldaPDF Celdavacia = new cCeldaPDF();
            FilaVacia.ListaCeldas.Add(Celdavacia);
            Tablavacia.ListaFilas.Add(FilaVacia);

            cTablaPDF TablaLeyenda = new cTablaPDF();
            TablaLeyenda.columnas = 2;
            TablaLeyenda.anchoColumnas = new float[] { 20f, 20f };

            cFilasPDF FilaDiaNormal = new cFilasPDF();
            cCeldaPDF CeldaTituloDiaNormal = new cCeldaPDF();
            CeldaTituloDiaNormal.Contenido = "Dia Normal";
            FilaDiaNormal.ListaCeldas.Add(CeldaTituloDiaNormal);

            cCeldaPDF CeldaDiaNormal = new cCeldaPDF();
            CeldaDiaNormal.Contenido = "N";
            FilaDiaNormal.ListaCeldas.Add(CeldaDiaNormal);

            TablaLeyenda.ListaFilas.Add(FilaDiaNormal);

            cFilasPDF FilaDiaJustificado = new cFilasPDF();
            cCeldaPDF CeldaTituloDiaJustificado = new cCeldaPDF();
            CeldaTituloDiaJustificado.Contenido = "Comision";
            FilaDiaJustificado.ListaCeldas.Add(CeldaTituloDiaJustificado);

            cCeldaPDF CeldaDiaJustificado = new cCeldaPDF();
            CeldaDiaJustificado.Contenido = "C";
            FilaDiaJustificado.ListaCeldas.Add(CeldaDiaJustificado);

            TablaLeyenda.ListaFilas.Add(FilaDiaJustificado);

            cFilasPDF FilaDiaFalta = new cFilasPDF();
            cCeldaPDF CeldaTituloDiaFalta = new cCeldaPDF();
            CeldaTituloDiaFalta.Contenido = "Falta Injustificada" + Environment.NewLine + "(ENTRADA-SALIDA)";
            FilaDiaFalta.ListaCeldas.Add(CeldaTituloDiaFalta);

            cCeldaPDF CeldaDiaFalta = new cCeldaPDF();
            CeldaDiaFalta.Contenido = "F" + Environment.NewLine + "(E-S)";
            FilaDiaFalta.ListaCeldas.Add(CeldaDiaFalta);

            TablaLeyenda.ListaFilas.Add(FilaDiaFalta);

            cFilasPDF FilaDiaTarde = new cFilasPDF();
            cCeldaPDF CeldaTituloDiatarde = new cCeldaPDF();
            CeldaTituloDiatarde.Contenido = "Tardanza";
            FilaDiaTarde.ListaCeldas.Add(CeldaTituloDiatarde);

            cCeldaPDF CeldaDiatarde = new cCeldaPDF();
            CeldaDiatarde.Contenido = "T";
            FilaDiaTarde.ListaCeldas.Add(CeldaDiatarde);

            TablaLeyenda.ListaFilas.Add(FilaDiaTarde);

            cFilasPDF FilaDiaFestivo = new cFilasPDF();
            cCeldaPDF CeldaTituloDiaFestivo = new cCeldaPDF();
            CeldaTituloDiaFestivo.Contenido = "Dia Festivo -" + Environment.NewLine + "Feriado";
            FilaDiaFestivo.ListaCeldas.Add(CeldaTituloDiaFestivo);

            cCeldaPDF CeldaDiaFestivo = new cCeldaPDF();
            CeldaDiaFestivo.Contenido = "DF";
            FilaDiaFestivo.ListaCeldas.Add(CeldaDiaFestivo);

            TablaLeyenda.ListaFilas.Add(FilaDiaFestivo);

            cFilasPDF FilaDiaSUB = new cFilasPDF();
            cCeldaPDF CeldaTituloDiaSUB = new cCeldaPDF();
            CeldaTituloDiaSUB.Contenido = "Subsidiado";
            FilaDiaSUB.ListaCeldas.Add(CeldaTituloDiaSUB);

            cCeldaPDF CeldaDiaSUB = new cCeldaPDF();
            CeldaDiaSUB.Contenido = "S";
            FilaDiaSUB.ListaCeldas.Add(CeldaDiaSUB);

            TablaLeyenda.ListaFilas.Add(FilaDiaSUB);

            oHojaPDF.ListaDeTablas.Add(TablaTituloPrincipal);
            oHojaPDF.ListaDeTablas.Add(TablaTitulo1);
            oHojaPDF.ListaDeTablas.Add(TablaTitulo2);
            oHojaPDF.ListaDeTablas.Add(TablaDetalle);
            oHojaPDF.ListaDeTablas.Add(Tablavacia);
            oHojaPDF.ListaDeTablas.Add(TablaLeyenda);

            oReporte.ListaHojasPDF.Add(oHojaPDF);

            ImprimirReportePDF(oReporte);

        }


        public CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral BuscarJornada(DateTime fecha, CapaDeNegocios.AsistenciaGeneral.cJornadaLaboral JornadaLaboral)
        {
            CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral Jornada = null;
            
            foreach (CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral item in JornadaLaboral.ListaDetalleJornadaLaboral)
            {
                if (item.Dia.Date == fecha.Date)
                {
                    Jornada = item;
                }
            }

            return Jornada;
        }
        private void ImprimirReportePDF(cReportePDF oReportePDF)
        {
            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 7);
            iTextSharp.text.Font fuenteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 9, 1, iTextSharp.text.Color.BLUE);
            Document pdfDoc = new Document(PageSize.A4, 50, 9, 50, 10);
            
            if (oReportePDF.FormatoHoja == cReportePDF.enumFormatoHoja.Horizontal)
            {
                pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            }
            else
            {
                //pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            }
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
                    //pdfTable.DefaultCell.BorderWidth = 1;
                    pdfTable.WidthPercentage = 100;
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
                                                    cell.BorderWidth = 0;
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
                                            cell.BackgroundColor = new iTextSharp.text.Color(item4.ColorFondo);
                                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                            cell.FixedHeight = item6.AltoColumna;
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
                                cell.BackgroundColor = new iTextSharp.text.Color(item4.ColorFondo);
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.FixedHeight = item4.AltoColumna;
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

        private string ConvertirFecha(DateTime Fecha)
        {
            switch (Fecha.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return "D";
                case DayOfWeek.Monday:
                    return "L";
                case DayOfWeek.Tuesday:
                    return "M";
                case DayOfWeek.Wednesday:
                    return "M";
                case DayOfWeek.Thursday:
                    return "J";
                case DayOfWeek.Friday:
                    return "V";
                case DayOfWeek.Saturday:
                    return "S";
                default:
                    return "E";
            }
        }

    }
}
