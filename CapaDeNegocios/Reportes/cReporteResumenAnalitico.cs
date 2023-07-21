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
using CapaDeNegocios.Planillas;
using System.Globalization;

namespace CapaDeNegocios.Reportes
{
    public class cReporteResumenAnalitico
    {
        public cReporteResumenAnalitico(cPlanilla miPlanilla, string ruta)
        {
            try
            {
                System.Drawing.Color colorFondo;
                colorFondo = System.Drawing.Color.LightGray;

                cDatosGenerales oDatosGenerales = new cDatosGenerales();

                cReportePDF oReporte = new cReportePDF();
                oReporte.RutaArchivo = ruta;

                miPlanilla.LlenarDetallesPlanilla();

                cHojaPDF oHojaPDF = new cHojaPDF();

                

                cTablaPDF oTablaEncabezado = new cTablaPDF();
                oTablaEncabezado.columnas = 1;
                oTablaEncabezado.anchoColumnas = new float[] { 100 };

                cFilasPDF filaEncabezadoNombre = new cFilasPDF();
                cCeldaPDF celdaNombre = new cCeldaPDF();
                celdaNombre.Contenido = oDatosGenerales.Nombre;
                celdaNombre.AnchoBorde = 0f;
                celdaNombre.ImagenTranasparente = true;
                celdaNombre.QuitarBordes();
                filaEncabezadoNombre.ListaCeldas.Add(celdaNombre);
                oTablaEncabezado.ListaFilas.Add(filaEncabezadoNombre);

                cFilasPDF filaEncabezadoRUC = new cFilasPDF();
                cCeldaPDF celdaRUC = new cCeldaPDF();
                celdaRUC.Contenido = "RUC: " + oDatosGenerales.Ruc;
                celdaRUC.AnchoBorde = 0;
                celdaRUC.ImagenTranasparente = true;
                celdaRUC.QuitarBordes();
                
                filaEncabezadoRUC.ListaCeldas.Add(celdaRUC);
                oTablaEncabezado.ListaFilas.Add(filaEncabezadoRUC);

                cFilasPDF filaEncabezadoReporte = new cFilasPDF();
                cCeldaPDF celdaReporte = new cCeldaPDF();
                celdaReporte.Contenido = "REPORTE DE ANALISIS DE MONTOS POR PLANILLA";
                celdaReporte.AnchoBorde = 0;
                celdaReporte.QuitarBordes();
                celdaReporte.ImagenTranasparente = true;
                
                filaEncabezadoReporte.ListaCeldas.Add(celdaReporte);
                oTablaEncabezado.ListaFilas.Add(filaEncabezadoReporte);

                cFilasPDF filaEncabezadoMes = new cFilasPDF();
                cCeldaPDF celdaMes = new cCeldaPDF();
                celdaMes.Contenido = "Periodo: " +  miPlanilla.Mes + " " + miPlanilla.Año;

                celdaMes.AnchoBorde = 0;
                
                filaEncabezadoMes.ListaCeldas.Add(celdaMes);
                oTablaEncabezado.ListaFilas.Add(filaEncabezadoMes);

                cTablaPDF oTablaTitulo = new cTablaPDF();
                oTablaTitulo.columnas = 1;
                oTablaTitulo.anchoColumnas = new float[] { 100 };

                cFilasPDF filaTitulo = new cFilasPDF();
                cCeldaPDF TituloCelda = new cCeldaPDF("Nro y Descripcion: " +  miPlanilla.Numero + " - " +  miPlanilla.Descripcion);
                TituloCelda.BordeAnchos.AnchoAbajo = 0f;
                filaTitulo.ListaCeldas.Add(TituloCelda);
                oTablaTitulo.ListaFilas.Add(filaTitulo);

                cFilasPDF filaMeta = new cFilasPDF();
                cCeldaPDF TituloMeta = new cCeldaPDF("Meta: " + miPlanilla.MiMeta.Numero + " - " + miPlanilla.MiMeta.Nombre);
                TituloMeta.BordeAnchos.AnchoArriba = 0f;
                filaMeta.ListaCeldas.Add(TituloMeta);
                oTablaTitulo.ListaFilas.Add(filaMeta);

                cTablaPDF TablaSubtitulos = new cTablaPDF();
                TablaSubtitulos.columnas = 9;
                TablaSubtitulos.anchoColumnas = new float[] { 10, 40, 40,10, 20, 20, 20, 20 , 20 };

                cFilasPDF FilaSubtitulos = new cFilasPDF();
                cCeldaPDF sTituloNumero = new cCeldaPDF();
                sTituloNumero.Contenido = "Nro.";
                sTituloNumero.ColorFondo = colorFondo;
                FilaSubtitulos.ListaCeldas.Add(sTituloNumero);

                cCeldaPDF sTituloNombre = new cCeldaPDF();
                sTituloNombre.Contenido = "DNI - Nombres";
                sTituloNombre.ColorFondo = colorFondo;
                FilaSubtitulos.ListaCeldas.Add(sTituloNombre);

                cCeldaPDF sTituloCargo = new cCeldaPDF();
                sTituloCargo.Contenido = "Cargo";
                sTituloCargo.ColorFondo = colorFondo;
                FilaSubtitulos.ListaCeldas.Add(sTituloCargo);

                cCeldaPDF sTituloDias = new cCeldaPDF();
                sTituloDias.Contenido = "Dias";
                sTituloDias.ColorFondo = colorFondo;
                FilaSubtitulos.ListaCeldas.Add(sTituloDias);

                cCeldaPDF sTituloMonto = new cCeldaPDF();
                sTituloMonto.Contenido = "Monto";
                sTituloMonto.ColorFondo = colorFondo;
                FilaSubtitulos.ListaCeldas.Add(sTituloMonto);

                cCeldaPDF sTituloDescuentos = new cCeldaPDF();
                sTituloDescuentos.Contenido = "Descuentos al Trabajador";
                sTituloDescuentos.ColorFondo = colorFondo;
                FilaSubtitulos.ListaCeldas.Add(sTituloDescuentos);

                cCeldaPDF sTituloNeto = new cCeldaPDF();
                sTituloNeto.Contenido = "Sueldo Neto";
                sTituloNeto.ColorFondo = colorFondo;
                FilaSubtitulos.ListaCeldas.Add(sTituloNeto);

                cCeldaPDF sTituloAPortacion = new cCeldaPDF();
                sTituloAPortacion.Contenido = "Aportaciones Empleador";
                sTituloAPortacion.ColorFondo = colorFondo;
                FilaSubtitulos.ListaCeldas.Add(sTituloAPortacion);

                cCeldaPDF sTituloTotal = new cCeldaPDF();
                sTituloTotal.Contenido = "Total Planilla";
                sTituloTotal.ColorFondo = colorFondo;
                FilaSubtitulos.ListaCeldas.Add(sTituloTotal);
                TablaSubtitulos.ListaFilas.Add(FilaSubtitulos);

                oHojaPDF.ListaDeTablas.Add(oTablaEncabezado);
                oHojaPDF.ListaDeTablas.Add(oTablaTitulo);
                oHojaPDF.ListaDeTablas.Add(TablaSubtitulos);

                cTablaPDF TablaDetalles = new cTablaPDF();
                TablaDetalles.columnas = 9;
                TablaDetalles.anchoColumnas = new float[] { 10, 40, 40, 10, 20, 20, 20, 20, 20 };

                int contador=0;
                decimal sumaTotalIngresos=0;
                decimal sumaTotalAportaciones=0;
                decimal sumaTotalAportacionesEmpleador=0;
                decimal sumaTotalDescuentos=0;
                decimal SumaTotalPlanilla=0;
                decimal SumaTotalNeto = 0;

                foreach (cDetallePlanilla item in miPlanilla.ListaDetallePlanilla)
                {
                    contador++;
                    sumaTotalIngresos += item.TotalIngresos;
                    sumaTotalAportaciones += item.TotalATrabajador;
                    sumaTotalDescuentos += item.TotalDescuentos;
                    SumaTotalPlanilla += (item.TotalIngresos + item.TotalAEmpleador);
                    sumaTotalAportacionesEmpleador += item.TotalAEmpleador;
                    SumaTotalNeto += item.NetoaCobrar;

                    cFilasPDF filaItem = new cFilasPDF();
                    cCeldaPDF sNumero = new cCeldaPDF();
                    sNumero.Contenido = contador.ToString();
                    sNumero.QuitarBordes();
                    filaItem.ListaCeldas.Add(sNumero);

                    cCeldaPDF sNombre = new cCeldaPDF();
                    sNombre.Contenido = item.STrabajador.Dni + " -  " + item.STrabajador.Nombres + " " + item.STrabajador.ApellidoPaterno + " " + item.STrabajador.ApellidoMaterno ;
                    sNombre.Alineamiento = enumAlineamiento.izquierda;
                    sNombre.QuitarBordes();
                    filaItem.ListaCeldas.Add(sNombre);

                    cCeldaPDF sCargo = new cCeldaPDF();
                    sCargo.Contenido = item.Cargo;
                    sCargo.QuitarBordes();
                    filaItem.ListaCeldas.Add(sCargo);

                    cCeldaPDF sDias = new cCeldaPDF();
                    sDias.Contenido = item.DiasLaborados.ToString();
                    sDias.QuitarBordes();
                    filaItem.ListaCeldas.Add(sDias);

                    cCeldaPDF sMonto = new cCeldaPDF();
                    sMonto.Contenido = item.TotalIngresos.ToString("c", new CultureInfo("es-PE"));
                    sMonto.QuitarBordes();
                    filaItem.ListaCeldas.Add(sMonto);

                    cCeldaPDF sDescuentos = new cCeldaPDF();
                    sDescuentos.Contenido = (item.TotalATrabajador + item.TotalDescuentos).ToString("c", new CultureInfo("es-PE"));
                    sDescuentos.QuitarBordes();
                    filaItem.ListaCeldas.Add(sDescuentos);

                    cCeldaPDF sNeto = new cCeldaPDF();
                    sNeto.Contenido = item.NetoaCobrar.ToString("c", new CultureInfo("es-PE"));
                    sNeto.QuitarBordes();
                    filaItem.ListaCeldas.Add(sNeto);

                    cCeldaPDF sAPortacion = new cCeldaPDF();
                    sAPortacion.Contenido = item.TotalAEmpleador.ToString("c", new CultureInfo("es-PE"));
                    sAPortacion.QuitarBordes();
                    filaItem.ListaCeldas.Add(sAPortacion);

                    cCeldaPDF sTotal = new cCeldaPDF();
                    sTotal.Contenido = (item.TotalAEmpleador + item.TotalIngresos).ToString("c", new CultureInfo("es-PE"));
                    sTotal.QuitarBordes();
                    sTotal.Alineamiento = enumAlineamiento.derecha;
                    filaItem.ListaCeldas.Add(sTotal);

                    TablaDetalles.ListaFilas.Add(filaItem);
                }

                cTablaPDF TablaTotales = new cTablaPDF();
                TablaTotales.columnas = 6;
                TablaTotales.anchoColumnas = new float[] { 100, 20, 20, 20, 20, 20 };

                cFilasPDF filaItemTotal = new cFilasPDF();
                

                cCeldaPDF sNombreTotal = new cCeldaPDF();
                sNombreTotal.Contenido = "TOTAL S/. :";
                sNombreTotal.BordeAnchos.AnchoAbajo = 1f;
                sNombreTotal.BordeAnchos.AnchoArriba = 1f;
                sNombreTotal.BordeAnchos.AnchoDerecha = 1f;
                sNombreTotal.BordeAnchos.AnchoIzquierda = 1f;
                sNombreTotal.ColorFondo = colorFondo;
                filaItemTotal.ListaCeldas.Add(sNombreTotal);

                
                

                cCeldaPDF sMontoTotal = new cCeldaPDF();
                sMontoTotal.Contenido = sumaTotalIngresos.ToString("c", new CultureInfo("es-PE"));
                sMontoTotal.ColorFondo = colorFondo;
                filaItemTotal.ListaCeldas.Add(sMontoTotal);

                cCeldaPDF sDescuentosTotal = new cCeldaPDF();
                sDescuentosTotal.Contenido = (sumaTotalAportaciones + sumaTotalDescuentos).ToString("c", new CultureInfo("es-PE"));
                sDescuentosTotal.ColorFondo = colorFondo;
                filaItemTotal.ListaCeldas.Add(sDescuentosTotal);

                cCeldaPDF sNetoTotal = new cCeldaPDF();
                sNetoTotal.Contenido = SumaTotalNeto.ToString("c", new CultureInfo("es-PE"));
                sNetoTotal.ColorFondo = colorFondo;
                filaItemTotal.ListaCeldas.Add(sNetoTotal);

                cCeldaPDF sAPortacionTotal = new cCeldaPDF();
                sAPortacionTotal.Contenido = sumaTotalAportaciones.ToString("c", new CultureInfo("es-PE"));
                sAPortacionTotal.ColorFondo = colorFondo;
                filaItemTotal.ListaCeldas.Add(sAPortacionTotal);

                cCeldaPDF sTotalTotal = new cCeldaPDF();
                sTotalTotal.Contenido = SumaTotalPlanilla.ToString("c", new CultureInfo("es-PE"));
                sTotalTotal.ColorFondo = colorFondo;
                sTotalTotal.Alineamiento = enumAlineamiento.derecha;
                filaItemTotal.ListaCeldas.Add(sTotalTotal);
                TablaTotales.ListaFilas.Add(filaItemTotal);

                oHojaPDF.ListaDeTablas.Add(TablaDetalles);
                oHojaPDF.ListaDeTablas.Add(TablaTotales);
                oReporte.ListaHojasPDF.Add(oHojaPDF);

                cImprimirReportePDF impresion = new cImprimirReportePDF();

                impresion.ImprimirReportePDF(oReporte);

                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = ruta;
                proc.Start();
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al imprimir el reporte: " + ex.Message);
            }
        }


       
    }
}
