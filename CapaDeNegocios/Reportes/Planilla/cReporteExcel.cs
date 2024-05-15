using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SpreadsheetLight;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;


namespace CapaDeNegocios.Reportes.Planilla
{
    public class cReporteExcel
    {
        CapaDeNegocios.PlanillaNueva.blPlanilla oblPlanilla = new PlanillaNueva.blPlanilla();

        public void ExportarPlanillaExcel(string ruta, PlanillaNueva.cnPlanilla oPlanilla, string ruc, string municipalidad, string lugar, string nombreOficina)
        {
            try
            {
                SpreadsheetLight.SLDocument miReporte;

                miReporte = new SpreadsheetLight.SLDocument();
                int contador = 0;

                SLBorder bordeCuadrado = new SLBorder();
                bordeCuadrado.SetTopBorder(BorderStyleValues.Thin, System.Drawing.Color.Black); 
                bordeCuadrado.SetBottomBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                bordeCuadrado.SetLeftBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                bordeCuadrado.SetRightBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);

                SLStyle estiloTituloReporte = new SLStyle();
                estiloTituloReporte.SetFontBold(true);
                estiloTituloReporte.SetHorizontalAlignment(HorizontalAlignmentValues.Center);
                estiloTituloReporte.SetPatternFill(PatternValues.Solid, System.Drawing.Color.LightGray, System.Drawing.Color.LightGray);
                estiloTituloReporte.SetWrapText(true);
                estiloTituloReporte.Border = bordeCuadrado;

                SLStyle estiloCeldaReporte = new SLStyle();
                estiloCeldaReporte.SetHorizontalAlignment(HorizontalAlignmentValues.Right);
                estiloCeldaReporte.SetVerticalAlignment(VerticalAlignmentValues.Bottom);
                estiloCeldaReporte.SetWrapText(true);
                estiloCeldaReporte.Border = bordeCuadrado;

                SLStyle estiloCeldaTextoReporte = new SLStyle();
                estiloCeldaTextoReporte.SetHorizontalAlignment(HorizontalAlignmentValues.Left);
                estiloCeldaTextoReporte.SetWrapText(true);
                estiloCeldaTextoReporte.Border = bordeCuadrado;


                miReporte.SetCellValue("A2", municipalidad);
                miReporte.SetCellValue("A3", nombreOficina);

                miReporte.SetCellValue("A4", oPlanilla.Descripcion + " DE " + oPlanilla.Mes + " " + oPlanilla.Año);

                miReporte.SetCellValue("A6", "META: " + oPlanilla.Meta.Numero + " " + oPlanilla.Meta.Nombre);

                miReporte.SetCellValue("A8", "FUENTE FINANCIAMIENTO: " + oPlanilla.FuenteFinanciamiento.Descripcion);

                miReporte.SetCellValue("A10", "Nº");
                miReporte.SetColumnWidth("A", 4);
                miReporte.SetCellStyle("A10", estiloTituloReporte);

                miReporte.SetCellValue("B10", "Nombres y Apellidos");
                miReporte.SetColumnWidth("B", 30);
                miReporte.SetCellStyle("B10", estiloTituloReporte);

                miReporte.SetCellValue("C10", "CARGO");
                miReporte.SetColumnWidth("C", 15);
                miReporte.SetCellStyle("C10", estiloTituloReporte);

                miReporte.SetCellValue("D10", "DNI");
                miReporte.SetColumnWidth("D", 9);
                miReporte.SetCellStyle("D10", estiloTituloReporte);

                miReporte.SetCellValue("E10", "FECHA INICIO");
                miReporte.SetColumnWidth("E", 10.5);
                miReporte.SetCellStyle("E10", estiloTituloReporte);

                miReporte.SetCellValue("F10", "AFIL. AFP/SNP" + Environment.NewLine + "COMIS." + Environment.NewLine + "CUSPP");
                miReporte.SetColumnWidth("F", 9);
                miReporte.SetCellStyle("F10", estiloTituloReporte);

                foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanilla item in oPlanilla.ListaDetalle)
                {
                    contador++;
                    string celda = (contador + 10).ToString();
                    miReporte.SetCellValue("A" + celda, contador.ToString());
                    miReporte.SetCellStyle("A" + celda, estiloCeldaReporte);

                    miReporte.SetCellValue("B" + celda, item.miTrabajador.Nombres + " " + item.miTrabajador.ApellidoPaterno + " " + item.miTrabajador.ApellidoMaterno);
                    miReporte.SetCellStyle("B" + celda, estiloCeldaTextoReporte);
                    miReporte.SetCellValue("C" + celda, item.cargo);
                    miReporte.SetCellStyle("C" + celda, estiloCeldaTextoReporte);
                    miReporte.SetCellValue("D" + celda, item.miTrabajador.Dni);
                    miReporte.SetCellStyle("D" + celda, estiloCeldaTextoReporte);
                    miReporte.SetCellValue("E" + celda, item.fechaInicio.ToShortDateString());
                    miReporte.SetCellStyle("E" + celda, estiloCeldaTextoReporte);
                    //Ojoooooooooooooooooooooooooooooooooo
                    miReporte.SetCellValue("F" + celda, item.miTrabajador.ListaRegimenPensionario.Last().MiAFP.Nombre + Environment.NewLine + item.miTrabajador.ListaRegimenPensionario.Last().TipoComision
                        + Environment.NewLine + item.miTrabajador.ListaRegimenPensionario.Last().Cuspp);
                    miReporte.SetCellStyle("F" + celda, estiloCeldaTextoReporte);
                    //PARTE INGRESOS
                    string Ingresos = "";
                    string TituloIngresos = "";
                    foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaIngresos item2 in item.ListaDetalleIngresos)
                    {
                        TituloIngresos = TituloIngresos + item2.MaestroIngresos.Abreviacion + Environment.NewLine;
                        Ingresos = Ingresos + item2.Monto.ToString() + Environment.NewLine;
                    }
                    miReporte.SetCellValue("G10", TituloIngresos);
                    miReporte.SetCellStyle("G10", estiloTituloReporte);
                    miReporte.SetCellValue("G" + celda, Ingresos);
                    miReporte.SetCellStyle("G" + celda, estiloCeldaReporte);
                    miReporte.SetCellValue("H10", "TOTAL INGRESOS");
                    miReporte.SetCellStyle("H10", estiloTituloReporte);
                    miReporte.SetCellValue("H" + celda, item.totalIngreso);
                    miReporte.SetCellStyle("H" + celda, estiloCeldaReporte);
                    //PARTE APORTACIONES TRABAJADOR
                    string AportacionesT = "";
                    string TituloAportacionesT = "";
                    foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaAportacionesTrabajador item3 in item.ListaDetalleAportacionesTrabajador)
                    {
                        TituloAportacionesT = TituloAportacionesT + item3.MaestroAportacionTrabajador.Abreviacion + Environment.NewLine;
                        AportacionesT = AportacionesT + item3.Monto.ToString() + Environment.NewLine;
                    }
                    miReporte.SetCellValue("I10", TituloAportacionesT);
                    miReporte.SetCellStyle("I10", estiloTituloReporte);
                    miReporte.SetCellValue("I" + celda, AportacionesT);
                    miReporte.SetCellStyle("I" + celda, estiloCeldaReporte);
                    miReporte.SetCellValue("J10", "TOTAL APORTACIONES TRABAJADOR");
                    miReporte.SetCellStyle("J10", estiloTituloReporte);
                    miReporte.SetCellValue("J" + celda, item.totalAportacionesTrabajador);
                    miReporte.SetCellStyle("J" + celda, estiloCeldaReporte);
                    //PARTE DESCUENTOS TRABAJADOR
                    string Descuentos = "";
                    string TituloDescuentos = "";
                    foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaEgresos item4 in item.ListaDetalleEgresos)
                    {
                        TituloDescuentos = TituloDescuentos + item4.MaestroDescuentos.Abreviacion + Environment.NewLine;
                        Descuentos = Descuentos + item4.Monto.ToString() + Environment.NewLine;
                    }
                    miReporte.SetCellValue("K10", TituloDescuentos);
                    miReporte.SetCellStyle("K10", estiloTituloReporte);
                    miReporte.SetCellValue("K" + celda, Descuentos);
                    miReporte.SetCellStyle("K" + celda, estiloCeldaReporte);
                    miReporte.SetCellValue("L10", "TOTAL DESCUENTOS TRABAJADOR");
                    miReporte.SetCellStyle("L10", estiloTituloReporte);
                    miReporte.SetCellValue("L" + celda, item.totalDescuentos);
                    miReporte.SetCellStyle("L" + celda, estiloCeldaReporte);
                    //PARTE APORTACIONES EMPLEADOR
                    string AportacionesE = "";
                    string TituloAportacionesE = "";
                    foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaAportacionesEmpleador item5 in item.ListaDetalleAportacionesEmpleador)
                    {
                        TituloAportacionesE = TituloAportacionesE + item5.MaestroAportacionesEmpleador.Abreviacion + Environment.NewLine;
                        AportacionesE = AportacionesE + item5.Monto.ToString() + Environment.NewLine;
                    }
                    miReporte.SetCellValue("M10", TituloAportacionesE);
                    miReporte.SetCellStyle("M10", estiloTituloReporte);
                    miReporte.SetCellValue("M" + celda, AportacionesE);
                    miReporte.SetCellStyle("M" + celda, estiloCeldaReporte);
                    miReporte.SetCellValue("N10", "TOTAL APORTACIONES EMPLEADOR");
                    miReporte.SetCellStyle("N10", estiloTituloReporte);
                    miReporte.SetCellValue("N" + celda, item.totalAportacionesEmpleador);
                    miReporte.SetCellStyle("N" + celda, estiloCeldaReporte);

                    miReporte.SetCellValue("O10", "NETO A COBRAR");
                    miReporte.SetCellStyle("O10", estiloTituloReporte);
                    miReporte.SetCellValue("O" + celda, item.netoACobrar.ToString());
                    miReporte.SetCellStyle("O" + celda, estiloCeldaReporte);
                    miReporte.SetCellValue("P10", "DIAS LABORADOS");
                    miReporte.SetCellStyle("P10", estiloTituloReporte);
                    miReporte.SetCellValue("P" + celda, item.diasLaborados.ToString());
                    miReporte.SetCellStyle("P" + celda, estiloCeldaReporte);
                    miReporte.SetCellValue("Q10", "OBSERVACIONES");
                    miReporte.SetCellStyle("Q10", estiloTituloReporte);
                    miReporte.SetCellValue("Q" + celda, "");
                    miReporte.SetCellStyle("Q" + celda, estiloCeldaReporte);
                }
                

              

                SLStyle estiloTitulo = new SLStyle();
                estiloTitulo.SetPatternFill(PatternValues.Solid, System.Drawing.Color.LightGray, System.Drawing.Color.LightGray);
                estiloTitulo.SetBottomBorder(BorderStyleValues.Thin, SLThemeColorIndexValues.Dark1Color);
                estiloTitulo.SetTopBorder(BorderStyleValues.Thin, SLThemeColorIndexValues.Dark1Color);
                estiloTitulo.SetRightBorder(BorderStyleValues.Thin, SLThemeColorIndexValues.Dark1Color);
                estiloTitulo.SetLeftBorder(BorderStyleValues.Thin, SLThemeColorIndexValues.Dark1Color);

                miReporte.SetCellValue("A3", "Nº");
                miReporte.SetCellStyle("A3", estiloTitulo);

                miReporte.SaveAs(ruta);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo ExportarPlanillaExcel: " + ex.Message);
            }
        }
    }
}
