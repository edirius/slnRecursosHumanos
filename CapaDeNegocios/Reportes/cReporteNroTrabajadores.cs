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
using System.Drawing;

namespace CapaDeNegocios.Reportes
{
    public class cReporteNroTrabajadores
    {
        public cReporteNroTrabajadores(List<cPlanilla> misPlanillas, string ruta, Boolean IncluirCategorias)
        {
            try
            {
                System.Drawing.Color colorFondo;

                if (IncluirCategorias)
                {
                    colorFondo = System.Drawing.Color.LightGray;
                }
                else
                {
                    colorFondo = System.Drawing.Color.White;
                }

                cDatosGenerales oDatosGenerales = new cDatosGenerales();

                cReportePDF oReporte = new cReportePDF();
                oReporte.RutaArchivo = ruta;

                foreach (cPlanilla item in misPlanillas)
                {
                    item.LlenarDetallesPlanilla();
                }
                

                cHojaPDF oHojaPDF = new cHojaPDF();

                cTablaPDF oTablaEncabezado = new cTablaPDF();
                oTablaEncabezado.columnas = 1;
                oTablaEncabezado.anchoColumnas = new float[] { 100 };

                cFilasPDF filaEncabezadoNombre = new cFilasPDF();
                cCeldaPDF celdaNombre = new cCeldaPDF();
                celdaNombre.Contenido = oDatosGenerales.Nombre;

                celdaNombre.AnchoBorde = 0f;
                celdaNombre.QuitarBordes();
                celdaNombre.ImagenTranasparente= true;
                filaEncabezadoNombre.ListaCeldas.Add(celdaNombre);
                oTablaEncabezado.ListaFilas.Add(filaEncabezadoNombre);

                cFilasPDF filaEncabezadoRUC = new cFilasPDF();
                cCeldaPDF celdaRUC = new cCeldaPDF();
                celdaRUC.Contenido = "RUC: " + oDatosGenerales.Ruc;
                celdaRUC.AnchoBorde = 0;
                celdaRUC.QuitarBordes();
                celdaRUC.ImagenTranasparente = true;
                filaEncabezadoRUC.ListaCeldas.Add(celdaRUC);
                oTablaEncabezado.ListaFilas.Add(filaEncabezadoRUC);

                cFilasPDF filaEncabezadoReporte = new cFilasPDF();
                cCeldaPDF celdaReporte = new cCeldaPDF();
                celdaReporte.Contenido = "REPORTE DE NRO DE TRABAJADORES  POR PLANILLA";
                celdaReporte.AnchoBorde = 0;
                celdaReporte.QuitarBordes();
                celdaReporte.ImagenTranasparente = true;
                filaEncabezadoReporte.ListaCeldas.Add(celdaReporte);
                oTablaEncabezado.ListaFilas.Add(filaEncabezadoReporte);

                cFilasPDF filaEncabezadoMes = new cFilasPDF();
                cCeldaPDF celdaMes = new cCeldaPDF();
                celdaMes.Contenido = "Periodo: " + misPlanillas[0].Mes + " " + misPlanillas[0].Año;
                celdaMes.AnchoBorde = 0;

                filaEncabezadoMes.ListaCeldas.Add(celdaMes);
                oTablaEncabezado.ListaFilas.Add(filaEncabezadoMes);

                cTablaPDF oTablaTitulo = new cTablaPDF();
                oTablaTitulo.columnas = 1;
                oTablaTitulo.anchoColumnas = new float[] { 100 };
                cFilasPDF filaTitulo = new cFilasPDF();
                cCeldaPDF TituloCelda = new cCeldaPDF("");
                filaTitulo.ListaCeldas.Add(TituloCelda);
                oTablaTitulo.ListaFilas.Add(filaTitulo);

                cTablaPDF TablaSubtitulos = new cTablaPDF();
                TablaSubtitulos.columnas = 5;
                TablaSubtitulos.anchoColumnas = new float[] { 10, 20, 50, 50, 20 };

                cFilasPDF FilaSubtitulos = new cFilasPDF();
                cCeldaPDF sTituloNumero = new cCeldaPDF();
                sTituloNumero.Contenido = "Nro.";
                sTituloNumero.ColorFondo = System.Drawing.Color.LightGray;
                FilaSubtitulos.ListaCeldas.Add(sTituloNumero);

                cCeldaPDF sTituloNombre = new cCeldaPDF();
                sTituloNombre.Contenido = "Nro. Planilla";
                sTituloNombre.ColorFondo = System.Drawing.Color.LightGray;
                FilaSubtitulos.ListaCeldas.Add(sTituloNombre);

                cCeldaPDF sTituloCargo = new cCeldaPDF();
                sTituloCargo.Contenido = "Meta";
                sTituloCargo.ColorFondo = System.Drawing.Color.LightGray;
                FilaSubtitulos.ListaCeldas.Add(sTituloCargo);

                cCeldaPDF sTituloDescripcion = new cCeldaPDF();
                sTituloDescripcion.Contenido = "Descripcion";
                sTituloDescripcion.ColorFondo = System.Drawing.Color.LightGray;
                FilaSubtitulos.ListaCeldas.Add(sTituloDescripcion);

                cCeldaPDF sTituloMonto = new cCeldaPDF();
                sTituloMonto.Contenido = "Total Nro Trabajadores";
                sTituloMonto.ColorFondo = System.Drawing.Color.LightGray;
                FilaSubtitulos.ListaCeldas.Add(sTituloMonto);

                TablaSubtitulos.ListaFilas.Add(FilaSubtitulos);

                oHojaPDF.ListaDeTablas.Add(oTablaEncabezado);
                oHojaPDF.ListaDeTablas.Add(oTablaTitulo);
                oHojaPDF.ListaDeTablas.Add(TablaSubtitulos);

                cTablaPDF TablaContenedor = new cTablaPDF();
                TablaContenedor.columnas = 1;
                TablaContenedor.anchoColumnas = new float[] { 100 };

                
                int contador = 0;
                decimal sumaTotalTrabajadores = 0;
                

                foreach (cPlanilla item in misPlanillas)
                {
                    contador++;

                    cFilasPDF fila1 = new cFilasPDF();
                    cCeldaPDF celda1 = new cCeldaPDF();
                    cFilasPDF fila2 = new cFilasPDF();
                    cCeldaPDF celda2 = new cCeldaPDF();

                    cTablaPDF TablaDetalles = new cTablaPDF();
                    TablaDetalles.columnas = 5;
                    TablaDetalles.anchoColumnas = new float[] { 10, 20, 50, 50, 20 };


                    cFilasPDF filaItem = new cFilasPDF();


                    cCeldaPDF sNumero = new cCeldaPDF();
                    sNumero.Contenido = contador.ToString();
                    sNumero.ColorFondo = colorFondo;
                    sNumero.QuitarBordes();
                    filaItem.ListaCeldas.Add(sNumero);

                    cCeldaPDF sNombre = new cCeldaPDF();
                    sNombre.Contenido = item.Numero;
                    sNombre.QuitarBordes();
                    sNombre.ColorFondo = colorFondo;
                    filaItem.ListaCeldas.Add(sNombre);

                    cCeldaPDF sCargo = new cCeldaPDF();
                    sCargo.Contenido = item.MiMeta.Numero + " - " + item.MiMeta.Nombre;
                    sCargo.QuitarBordes();
                    sCargo.ColorFondo = colorFondo;
                    filaItem.ListaCeldas.Add(sCargo);

                    cCeldaPDF sDescripcion = new cCeldaPDF();
                    sDescripcion.Contenido = item.Descripcion;
                    sDescripcion.QuitarBordes();
                    sDescripcion.ColorFondo = colorFondo;
                    filaItem.ListaCeldas.Add(sDescripcion);

                    List<iCategorias> NumeroCategorias = ContarCategorias(item);
                    int suma = sumarTotalCategorias(NumeroCategorias);

                    cCeldaPDF sDias = new cCeldaPDF();
                    sDias.Contenido = suma.ToString();
                    sDias.QuitarBordes();
                    sDias.ColorFondo = colorFondo;
                    filaItem.ListaCeldas.Add(sDias);

                    
                    cTablaPDF tablaCategorias = new cTablaPDF();
                    tablaCategorias.columnas = 2;
                    tablaCategorias.anchoColumnas = new float[] { 130, 20 };

                    foreach (iCategorias item2 in NumeroCategorias)
                    {
  
                        cFilasPDF filaCategorias = new cFilasPDF();
                        cCeldaPDF celdaCategoria = new cCeldaPDF();
                        celdaCategoria.QuitarBordes();
                        celdaCategoria.Contenido = item2.cargo;
                        filaCategorias.ListaCeldas.Add(celdaCategoria);

                        cCeldaPDF celdaNroCategoria = new cCeldaPDF();
                        celdaNroCategoria.QuitarBordes();
                        celdaNroCategoria.Contenido = item2.cantidad.ToString();
                        filaCategorias.ListaCeldas.Add(celdaNroCategoria);

                        tablaCategorias.ListaFilas.Add(filaCategorias);
                    }
                    

                    sumaTotalTrabajadores = sumaTotalTrabajadores + suma;
                    TablaDetalles.ListaFilas.Add(filaItem);

                    celda1.TablaPDF = TablaDetalles;
                    fila1.ListaCeldas.Add(celda1);
                    celda2.TablaPDF = tablaCategorias;
                    fila2.ListaCeldas.Add(celda2);

                    TablaContenedor.ListaFilas.Add(fila1);
                    if (IncluirCategorias)
                    {
                        TablaContenedor.ListaFilas.Add(fila2);
                    }
                    
                }

                cTablaPDF TablaTotales = new cTablaPDF();
                TablaTotales.columnas = 2;
                TablaTotales.anchoColumnas = new float[] { 130, 20 };

                cFilasPDF filaItemTotal = new cFilasPDF();

                cCeldaPDF sNombreTotal = new cCeldaPDF();
                sNombreTotal.Contenido = "TOTAL NRO TRABAJADORES :";
                sNombreTotal.BordeAnchos.AnchoAbajo = 1f;
                sNombreTotal.BordeAnchos.AnchoArriba = 1f;
                sNombreTotal.BordeAnchos.AnchoDerecha = 0f;
                sNombreTotal.BordeAnchos.AnchoIzquierda = 1f;
                sNombreTotal.ColorFondo = System.Drawing.Color.LightGray;
                filaItemTotal.ListaCeldas.Add(sNombreTotal);

                cCeldaPDF sTotalTotal = new cCeldaPDF();
                sTotalTotal.Contenido = sumaTotalTrabajadores.ToString();
                sTotalTotal.ColorFondo = System.Drawing.Color.LightGray;
                sTotalTotal.BordeAnchos.AnchoArriba = 1f;
                filaItemTotal.ListaCeldas.Add(sTotalTotal);
                TablaTotales.ListaFilas.Add(filaItemTotal);

                oHojaPDF.ListaDeTablas.Add(TablaContenedor);
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


        private List<iCategorias> ContarCategorias(cPlanilla oPLanilla)
        {
            List<iCategorias> ListaAuxiliar = new List<iCategorias>();

            foreach (cDetallePlanilla item in oPLanilla.ListaDetallePlanilla)
            {
                iCategorias auxiliar = new iCategorias();
                auxiliar.cargo = item.Cargo;
                auxiliar.cantidad++;

                bool encontrado = false;
                foreach (iCategorias item2 in ListaAuxiliar)
                {
                    if (auxiliar.cargo == item2.cargo)
                    {
                        item2.cantidad++;
                        encontrado = true;
                    }
                }

                if (!encontrado)
                {
                    ListaAuxiliar.Add(auxiliar);
                }
            }

            return ListaAuxiliar;
        }

        private int sumarTotalCategorias(List<iCategorias> lista)
        {
            int suma = 0;

            foreach (iCategorias item in lista)
            {
                suma = suma + item.cantidad;
            }
            return suma;
        }
        private class iCategorias
        {
            public iCategorias()
            {
                cargo = "";
                cantidad = 0;
            }
            public string cargo;
            public int cantidad;
        }
    }
}
