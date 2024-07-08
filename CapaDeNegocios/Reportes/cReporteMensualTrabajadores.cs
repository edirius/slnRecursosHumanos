using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;
using System.IO;

using SpreadsheetLight;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;

namespace CapaDeNegocios.Reportes
{
    public class cReporteMensualTrabajadores
    {
        private Utilidades.cUtilidades miUtilidades = new Utilidades.cUtilidades();

        public DataTable TraerListaTrabajadores(string mes, string año)
        {
            try
            {
                return Conexion.GDatos.TraerDataTable("spListaTrabajadoresMensual", mes, año);
            }
            catch (Exception ex)
            {

                throw new cReglaNegociosException("Error en el metodo TraerListaTrabajadores: " + ex.Message);
            }
        }

        


        public void ImprimirReporteMensualaPDF(DataTable oTabla, string ruta, string mes, string año)
        {
            try
            {
                cReportePDF oReportePDF = new cReportePDF();
                oReportePDF.FormatoHoja = cReportePDF.enumFormatoHoja.Horizontal;
                oReportePDF.RutaArchivo = ruta;

                cHojaPDF NuevaHoja = new cHojaPDF();

                cTablaPDF tablaTitulos = new cTablaPDF();
                tablaTitulos.columnas = 1;
                tablaTitulos.anchoColumnas = new float[] { 100f };



                cFilasPDF FilaTitulos = new cFilasPDF();
                cCeldaPDF CeldaTitulo = new cCeldaPDF();
                CeldaTitulo.Contenido = "REPORTE DE TRABAJADORES";

                cCeldaPDF CeldaMes = new cCeldaPDF();
                CeldaMes.Contenido = mes + " " + año;

                FilaTitulos.ListaCeldas.Add(CeldaTitulo);

                cFilasPDF FilaMes = new cFilasPDF();
                FilaMes.ListaCeldas.Add(CeldaMes);

                tablaTitulos.ListaFilas.Add(FilaTitulos);
                tablaTitulos.ListaFilas.Add(FilaMes);

                cTablaPDF tablaDetalle = new cTablaPDF();
                tablaDetalle.columnas = oTabla.Columns.Count;
                tablaDetalle.anchoColumnas = traerAnchoColumnas(oTabla);
                cFilasPDF filaSubtitulos = new cFilasPDF();

                for (int i = 0; i < oTabla.Columns.Count; i++)
                {
                    tablaDetalle.columnas = oTabla.Columns.Count;
                    cCeldaPDF oCelda = new cCeldaPDF();
                    oCelda.Contenido = oTabla.Columns[i].ColumnName;

                    filaSubtitulos.ListaCeldas.Add(oCelda);
                }

                tablaDetalle.ListaFilas.Add(filaSubtitulos);

                for (int i = 0; i < oTabla.Rows.Count; i++)
                {
                    cFilasPDF oFila = new cFilasPDF();

                    for (int j = 0; j < oTabla.Columns.Count; j++)
                    {
                        cCeldaPDF oCelda = new cCeldaPDF();
                        oCelda.Contenido = oTabla.Rows[i][j].ToString();
                        oFila.ListaCeldas.Add(oCelda);
                    }
                    tablaDetalle.ListaFilas.Add(oFila);
                }

                NuevaHoja.ListaDeTablas.Add(tablaTitulos);
                NuevaHoja.ListaDeTablas.Add(tablaDetalle);
                oReportePDF.ListaHojasPDF.Add(NuevaHoja);

                cImprimirReportePDF oImprimir = new cImprimirReportePDF();
                oImprimir.ImprimirReportePDF(oReportePDF);

                

            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo ImprimirReporteMensualPDF: cReporteMensualTrabajadores: " + ex.Message);
            }
        }

        public void ImprimirReporteMensualaExcel(DataTable oTabla, string ruta, string mes, string año, Boolean Autoajustar)
        {
            try
            {
                SpreadsheetLight.SLDocument miReporte;

                miReporte = new SpreadsheetLight.SLDocument();
                int contador = 0;
                miReporte.SetCellValue("A1", "REPORTE MENSUAL TRABAJADORES");
                miReporte.SetCellValue("A2", mes + " " + año);
                miReporte.MergeWorksheetCells("A1", miUtilidades.DevolverLetraExcel(oTabla.Columns.Count+1) + "1");
                miReporte.MergeWorksheetCells("A2", miUtilidades.DevolverLetraExcel(oTabla.Columns.Count+1) + "2");

                SLStyle estiloTituloReporte = new SLStyle();
                estiloTituloReporte.SetFontBold(true);
                estiloTituloReporte.SetHorizontalAlignment(HorizontalAlignmentValues.Center);
                miReporte.SetCellStyle("A1", estiloTituloReporte);
                miReporte.SetCellStyle("A2", estiloTituloReporte);

                SLStyle estiloTitulo = new SLStyle();
                estiloTitulo.SetPatternFill(PatternValues.Solid, System.Drawing.Color.LightGray, System.Drawing.Color.LightGray);
                estiloTitulo.SetBottomBorder(BorderStyleValues.Thin, SLThemeColorIndexValues.Dark1Color);
                estiloTitulo.SetTopBorder(BorderStyleValues.Thin, SLThemeColorIndexValues.Dark1Color);
                estiloTitulo.SetRightBorder(BorderStyleValues.Thin, SLThemeColorIndexValues.Dark1Color);
                estiloTitulo.SetLeftBorder(BorderStyleValues.Thin, SLThemeColorIndexValues.Dark1Color);

                miReporte.SetCellValue("A3", "Nº");
                miReporte.SetCellStyle("A3", estiloTitulo);
                for (int i = 0; i < oTabla.Columns.Count; i++)
                {
                    miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(i+2) + "3", oTabla.Columns[i].ColumnName);
                    miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(i + 2) + "3", estiloTitulo);
                    miReporte.AutoFitColumn(i);
                   
                }

                for (int i = 0; i < oTabla.Rows.Count; i++)
                {
                    contador += 1;
                    miReporte.SetCellValue("A" + (i + 4), contador.ToString());
                    for (int j = 0; j < oTabla.Columns.Count; j++)
                    {
                        miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(j + 2) + (i + 4), oTabla.Rows[i][j].ToString());
                    }
                }
                if (Autoajustar)
                {
                    for (int i = 0; i < oTabla.Columns.Count; i++)
                    {
                        miReporte.AutoFitColumn(i);
                    }
                }
                //_excel.Quit();
                miReporte.SaveAs(ruta);
          
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo ImpirmirReporteMensualaExcel: " + ex.Message);
            }
        }

       

        public float[] traerAnchoColumnas( DataTable oTabla)
        {
            float[] anchos = new float[oTabla.Columns.Count];

            for (int i = 0; i < oTabla.Columns.Count; i++)
            {
                float ancho;
                ancho = (float) oTabla.Columns[i].ColumnName.Length;
                anchos[i] = ancho;
            }

            return anchos;
        }
    }
}
