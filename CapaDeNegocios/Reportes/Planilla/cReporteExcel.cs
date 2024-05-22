using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SpreadsheetLight;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Globalization;

namespace CapaDeNegocios.Reportes.Planilla
{
    public enum enumTipoReporte
    {
        reporte1,
        reporte2,
        reporte3
    }

    public class cReporteExcel
    {
        
        CapaDeNegocios.PlanillaNueva.blPlanilla oblPlanilla = new PlanillaNueva.blPlanilla();
        CapaDeNegocios.Utilidades.cUtilidades miUtilidades = new Utilidades.cUtilidades();

        public void ExportarPlanillaExcel(string ruta, PlanillaNueva.cnPlanilla oPlanilla, string ruc, string municipalidad, string lugar, string nombreOficina, enumTipoReporte tipoReporte, List<string> Firmas)
        {
            try
            {
                SpreadsheetLight.SLDocument miReporte;

                miReporte = new SpreadsheetLight.SLDocument();
                string rutaLogo = System.IO.Directory.GetCurrentDirectory() + "\\logo-muni-fw.png";

                System.Drawing.Bitmap bm = new System.Drawing.Bitmap(rutaLogo);
                byte[] ba;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    bm.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ms.Close();
                    ba = ms.ToArray();
                }

                SpreadsheetLight.Drawing.SLPicture logo = new SpreadsheetLight.Drawing.SLPicture(ba, DocumentFormat.OpenXml.Packaging.ImagePartType.Png);
                logo.ResizeInPercentage(70, 70);
                miReporte.InsertPicture(logo);

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

                SLStyle estiloTITULOMunicipalidad = new SLStyle();
                estiloTITULOMunicipalidad.SetHorizontalAlignment(HorizontalAlignmentValues.Center);
                estiloTITULOMunicipalidad.SetWrapText(true);
                estiloTITULOMunicipalidad.Font = new SLFont();
                estiloTITULOMunicipalidad.Font.FontSize = 14;
                estiloTITULOMunicipalidad.Font.Bold = true;

                SLStyle estiloTITULOMeta = new SLStyle();
                estiloTITULOMeta.SetHorizontalAlignment(HorizontalAlignmentValues.Left);
                estiloTITULOMeta.SetWrapText(true);
                estiloTITULOMeta.Font = new SLFont();
                estiloTITULOMeta.Font.FontSize = 14;
                estiloTITULOMeta.Font.Bold = true;

                SLStyle estiloTITULONro = new SLStyle();
                estiloTITULONro.SetHorizontalAlignment(HorizontalAlignmentValues.Right);
                estiloTITULONro.SetWrapText(true);
                estiloTITULONro.Font = new SLFont();
                estiloTITULONro.Font.FontSize = 14;
                estiloTITULONro.Font.Bold = true;


                miReporte.MergeWorksheetCells("A1", "Q1");
                miReporte.MergeWorksheetCells("A2", "Q2");
                miReporte.MergeWorksheetCells("A3", "Q3");
                miReporte.MergeWorksheetCells("A4", "Q4");
                miReporte.MergeWorksheetCells("A6", "Q6");
                miReporte.MergeWorksheetCells("A5", "Q5");
                miReporte.MergeWorksheetCells("A8", "Q8");

                miReporte.SetCellValue("A2", municipalidad);
                miReporte.SetCellStyle("A2", estiloTITULOMunicipalidad);
                miReporte.SetCellValue("A3", nombreOficina);
                miReporte.SetCellStyle("A3", estiloTITULOMunicipalidad);

                miReporte.SetCellValue("A4", oPlanilla.Descripcion + " DE " + oPlanilla.Mes + " " + oPlanilla.Año);
                miReporte.SetCellStyle("A4", estiloTITULOMunicipalidad);

                miReporte.SetCellValue("A6", "META: " + oPlanilla.Meta.Numero + " " + oPlanilla.Meta.Nombre);
                miReporte.SetRowHeight(6, 35);
                miReporte.SetCellStyle("A6", estiloTITULOMeta);

                miReporte.SetCellValue("A5", "NRO. PLANILLA: " + oPlanilla.numeroPlanilla + " - " + oPlanilla.Fecha.Year);
                miReporte.SetCellStyle("A5", estiloTITULONro);

                miReporte.SetCellValue("A8", "FUENTE FINANCIAMIENTO: " + oPlanilla.FuenteFinanciamiento.Descripcion);
                miReporte.SetCellStyle("A8", estiloTITULOMeta);

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

                switch (tipoReporte)
                {
                    case enumTipoReporte.reporte1:
                        llenarReporte1(miReporte, oPlanilla, lugar, Firmas);
                        break;
                    case enumTipoReporte.reporte2:
                        llenarReporte2(miReporte, oPlanilla, lugar, Firmas);
                        break;
                    case enumTipoReporte.reporte3:
                        break;
                    default:
                        break;
                }

                CapaDeNegocios.PlanillaNueva.cnDetallePlanilla ListaTotales = oblPlanilla.ListaTotales(oPlanilla);

                

                miReporte.SaveAs(ruta);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo ExportarPlanillaExcel: " + ex.Message);
            }
        }

        private void llenarReporte1(SpreadsheetLight.SLDocument miReporte, PlanillaNueva.cnPlanilla oPlanilla, string lugar, List<string> firmas)
        {
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

            SLStyle estiloTITULOMunicipalidad = new SLStyle();
            estiloTITULOMunicipalidad.SetHorizontalAlignment(HorizontalAlignmentValues.Center);
            estiloTITULOMunicipalidad.SetWrapText(true);
            estiloTITULOMunicipalidad.Font = new SLFont();
            estiloTITULOMunicipalidad.Font.FontSize = 14;

            SLStyle estiloCeldaNumero = new SLStyle();
            estiloCeldaNumero.SetHorizontalAlignment(HorizontalAlignmentValues.Right);
            estiloCeldaNumero.SetVerticalAlignment(VerticalAlignmentValues.Bottom);
            estiloCeldaNumero.SetWrapText(true);
            estiloCeldaNumero.Border = bordeCuadrado;
            estiloCeldaNumero.FormatCode = "#,##0.00";

            string celda = "";
            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanilla item in oPlanilla.ListaDetalle)
            {
                contador++;
                celda = (contador + 10).ToString();
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
                item.afp = item.miTrabajador.ListaRegimenPensionario.Last().MiAFP;
                item.cuspp = item.miTrabajador.ListaRegimenPensionario.Last().Cuspp;
                item.comision = item.miTrabajador.ListaRegimenPensionario.Last().TipoComision;
                miReporte.SetCellValue("F" + celda, item.afp.Nombre + Environment.NewLine + item.comision + Environment.NewLine + item.cuspp);
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
                miReporte.SetColumnWidth("Q", 27);
                miReporte.SetCellStyle("Q10", estiloTituloReporte);
                miReporte.SetCellValue("Q" + celda, "");
                miReporte.SetCellStyle("Q" + celda, estiloCeldaReporte);
            }

            //Parte Totales
            contador++;
            celda = (contador + 10).ToString();
            CapaDeNegocios.PlanillaNueva.cnDetallePlanilla ListaTotales = oblPlanilla.ListaTotales(oPlanilla);



            string totalIngresos = "";
            double sumaIngresos = 0;
            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaIngresos item in ListaTotales.ListaDetalleIngresos)
            {
                totalIngresos = totalIngresos + item.Monto.ToString() + Environment.NewLine;
                sumaIngresos += item.Monto;
            }
            miReporte.MergeWorksheetCells("A" + celda, "F" + celda);
            miReporte.SetCellValue("A" + celda, "TOTAL");
            miReporte.SetCellStyle("A" + celda, "F" + celda, estiloCeldaTextoReporte);
            miReporte.SetCellValue("G" + celda, totalIngresos);
            miReporte.SetCellStyle("G" + celda, estiloCeldaReporte);
            miReporte.SetCellValue("H" + celda, sumaIngresos);
            miReporte.SetCellStyle("H" + celda, estiloCeldaReporte);

            string totalAportacionesTrabajador = "";
            double sumaAportaciones = 0;
            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaAportacionesTrabajador item3 in ListaTotales.ListaDetalleAportacionesTrabajador)
            {
                totalAportacionesTrabajador += item3.Monto.ToString() + Environment.NewLine;
                sumaAportaciones += item3.Monto;
            }
            miReporte.SetCellValue("I" + celda, totalAportacionesTrabajador);
            miReporte.SetCellStyle("I" + celda, estiloCeldaReporte);
            miReporte.SetCellValue("J" + celda, sumaAportaciones);
            miReporte.SetCellStyle("J" + celda, estiloCeldaReporte);

            string totalDescuentos = "";
            double sumaDescuentos = 0;
            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaEgresos item2 in ListaTotales.ListaDetalleEgresos)
            {
                totalDescuentos += item2.Monto.ToString() + Environment.NewLine;
                sumaDescuentos += item2.Monto;
            }
            miReporte.SetCellValue("K" + celda, totalDescuentos);
            miReporte.SetCellStyle("K" + celda, estiloCeldaReporte);
            miReporte.SetCellValue("L" + celda, sumaDescuentos);
            miReporte.SetCellStyle("L" + celda, estiloCeldaReporte);

            string totalAportacionesEmpleador = "";
            double sumaAportacionesEmpleador = 0;
            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaAportacionesEmpleador item4 in ListaTotales.ListaDetalleAportacionesEmpleador)
            {
                totalAportacionesEmpleador += item4.Monto.ToString() + Environment.NewLine;
                sumaAportacionesEmpleador += item4.Monto;
            }
            miReporte.SetCellValue("M" + celda, totalAportacionesEmpleador);
            miReporte.SetCellStyle("M" + celda, estiloCeldaReporte);
            miReporte.SetCellValue("N" + celda, sumaAportacionesEmpleador);
            miReporte.SetCellStyle("N" + celda, estiloCeldaReporte);

            miReporte.SetCellValue("O" + celda, ListaTotales.netoACobrar);
            miReporte.SetCellStyle("O" + celda, estiloCeldaReporte);
            miReporte.SetCellStyle("P" + celda, estiloCeldaReporte);
            miReporte.SetCellStyle("Q" + celda, estiloCeldaReporte);

            contador++;
            celda = (contador + 10).ToString();
            miReporte.MergeWorksheetCells("A" + celda, "Q" + celda);
            miReporte.SetCellValue("A" + celda, lugar + ", " + DateTime.Now.Day + " de " +DateTime.Now.ToString("MMMM") + " del " +DateTime.Now.Year.ToString());
            miReporte.SetCellStyle("A" + celda, estiloTITULOMunicipalidad);
            contador++;
            contador++;
            celda = (contador + 10).ToString();

            int FilaInicioResumenes = contador;
            //parte resumen afp
            miReporte.MergeWorksheetCells("B" + celda, "C" + celda);
            miReporte.SetCellValue("B" + celda, "RESUMEN AFP");
            miReporte.SetCellStyle("B" + celda, "C" + celda, estiloTituloReporte);
            
            List<cDetalleResumenAFP> ResumenAFP = new List<cDetalleResumenAFP>();
            cListaAFP listaAFP = new cListaAFP();
            List<cAFP> afps = listaAFP.TraerListaAFPS();

            foreach (cAFP item5 in afps )
            {
                cDetalleResumenAFP resumen = new cDetalleResumenAFP();
                resumen.AFP = item5;
                resumen.Monto = 0;
                ResumenAFP.Add(resumen);
            }
            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanilla item5 in oPlanilla.ListaDetalle)
            {
                foreach (cDetalleResumenAFP item6 in ResumenAFP)
                {
                    if (item6.AFP.CodigoAFP == item5.afp.CodigoAFP)
                    {
                        item6.Monto += item5.totalDescuentoAFP;
                    }
                }
            }

            double totalAFP = 0;
            foreach (cDetalleResumenAFP item7 in ResumenAFP)
            {
                if (item7.Monto > 0)
                {
                    contador++;
                    celda = (contador + 10).ToString();
                    miReporte.SetCellValue("B" + celda, item7.AFP.Nombre);
                    miReporte.SetCellStyle("B" + celda, estiloCeldaTextoReporte);
                    miReporte.SetCellValue("C" + celda, item7.Monto);
                    miReporte.SetCellStyle("C" + celda, estiloCeldaReporte);
                    totalAFP += item7.Monto;
                }
            }

            contador++;
            celda = (contador + 11).ToString();
            miReporte.SetCellValue("B" + celda, "TOTAL AFP");
            miReporte.SetCellStyle("B" + celda, estiloCeldaTextoReporte);
            miReporte.SetCellValue("C" + celda, totalAFP);
            miReporte.SetCellStyle("C" + celda, estiloCeldaNumero);

            //parte debe haber

            List<cDetalleDebeHaber> ResumenDebeHaber = new List<cDetalleDebeHaber>();

            cDetalleDebeHaber debeHaberIngresos = new cDetalleDebeHaber();
            debeHaberIngresos.TipoHaberDebe = enumTipoHaberDebe.haber;
            debeHaberIngresos.Concepto = "TOTAL INGRESOS";
            debeHaberIngresos.Monto = sumaIngresos;
            ResumenDebeHaber.Add(debeHaberIngresos);

            cDetalleDebeHaber debeHaberAportaciones = new cDetalleDebeHaber();
            debeHaberAportaciones.TipoHaberDebe = enumTipoHaberDebe.haber;
            debeHaberAportaciones.Concepto = "TOTAL APORTACIONES";
            debeHaberAportaciones.Monto = sumaAportacionesEmpleador;
            ResumenDebeHaber.Add(debeHaberAportaciones);

            cDetalleDebeHaber debeHaberNeto = new cDetalleDebeHaber();
            debeHaberNeto.TipoHaberDebe = enumTipoHaberDebe.debe;
            debeHaberNeto.Concepto = "NETO A COBRAR";
            debeHaberNeto.Monto = ListaTotales.netoACobrar;
            ResumenDebeHaber.Add(debeHaberNeto);

            cDetalleDebeHaber debeHaberAFP = new cDetalleDebeHaber();
            debeHaberAFP.TipoHaberDebe = enumTipoHaberDebe.debe;
            debeHaberAFP.Concepto = "AFP";
            debeHaberAFP.Monto = ListaTotales.totalDescuentoAFP;
            ResumenDebeHaber.Add(debeHaberAFP);

            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaAportacionesTrabajador item in ListaTotales.ListaDetalleAportacionesTrabajador)
            {
                if (item.MaestroAportacionTrabajador.Codigo != "0608" && item.MaestroAportacionTrabajador.Codigo != "0601" && item.MaestroAportacionTrabajador.Codigo != "0606")
                {
                    cDetalleDebeHaber debeHaber = new cDetalleDebeHaber();
                    debeHaber.TipoHaberDebe = enumTipoHaberDebe.debe;
                    debeHaber.Concepto = item.MaestroAportacionTrabajador.Abreviacion;
                    debeHaber.Monto = item.Monto;
                    ResumenDebeHaber.Add(debeHaber);
                }
            }

            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaEgresos item in ListaTotales.ListaDetalleEgresos)
            {
                cDetalleDebeHaber debeHaber = new cDetalleDebeHaber();
                debeHaber.TipoHaberDebe = enumTipoHaberDebe.debe;
                debeHaber.Concepto = item.MaestroDescuentos.Abreviacion;
                debeHaber.Monto = item.Monto;
                ResumenDebeHaber.Add(debeHaber);
            }

            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaAportacionesEmpleador item in ListaTotales.ListaDetalleAportacionesEmpleador)
            {
                cDetalleDebeHaber debeHaber = new cDetalleDebeHaber();
                debeHaber.TipoHaberDebe = enumTipoHaberDebe.debe;
                debeHaber.Concepto = item.MaestroAportacionesEmpleador.Abreviacion;
                debeHaber.Monto = item.Monto;
                ResumenDebeHaber.Add(debeHaber);
            }

            contador = FilaInicioResumenes;
            contador++;
            celda = (contador + 10).ToString();
            miReporte.SetCellValue("O" + celda, "DEBE");
            miReporte.SetCellStyle("O" + celda, estiloTituloReporte);
            miReporte.SetCellValue("P" + celda, "HABER");
            miReporte.SetCellStyle("P" + celda, estiloTituloReporte);

            double totalDebe = 0;
            double totalHaber = 0;

            foreach (cDetalleDebeHaber item7 in ResumenDebeHaber)
            {
                contador++;
                celda = (contador + 10).ToString();
                if (item7.TipoHaberDebe == enumTipoHaberDebe.haber)
                {
                    miReporte.MergeWorksheetCells("M" + celda, "N" + celda);
                    miReporte.SetCellValue("M" + celda, item7.Concepto);
                    miReporte.SetCellStyle("M" + celda,"N" + celda, estiloCeldaTextoReporte);
                    
                    miReporte.SetCellValue("O" + celda, item7.Monto);
                    miReporte.SetCellStyle("O" + celda, estiloCeldaReporte);
                    miReporte.SetCellStyle("P" + celda, estiloCeldaReporte);
                    totalHaber += item7.Monto; 
                }
                else
                {
                    miReporte.MergeWorksheetCells("M" + celda, "N" + celda);
                    miReporte.SetCellValue("M" + celda, item7.Concepto);
                    miReporte.SetCellStyle("M" + celda, "N" + celda, estiloCeldaTextoReporte);
                    miReporte.SetCellValue("P" + celda, item7.Monto);
                    miReporte.SetCellStyle("P" + celda, estiloCeldaReporte);
                    miReporte.SetCellStyle("O" + celda, estiloCeldaReporte);
                    totalDebe += item7.Monto;
                }
            }
            contador++;
            celda = (contador + 10).ToString();
            miReporte.MergeWorksheetCells("M" + celda, "N" + celda);
            miReporte.SetCellStyle("M" + celda, "N" + celda, estiloCeldaTextoReporte);
            miReporte.SetCellValue("M" + celda, "TOTAL");
            miReporte.SetCellValue("O" + celda, totalHaber);
            miReporte.SetCellStyle("O" + celda, estiloCeldaReporte);
            miReporte.SetCellValue("P" + celda, totalDebe);
            miReporte.SetCellStyle("P" + celda, estiloCeldaReporte);
        }

        private void llenarReporte2(SpreadsheetLight.SLDocument miReporte, PlanillaNueva.cnPlanilla oPlanilla, string lugar, List<string> firmas)
        {
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

            SLStyle estiloCeldaNumero = new SLStyle();
            estiloCeldaNumero.SetHorizontalAlignment(HorizontalAlignmentValues.Right);
            estiloCeldaNumero.SetVerticalAlignment(VerticalAlignmentValues.Bottom);
            estiloCeldaNumero.SetWrapText(true);
            estiloCeldaNumero.Border = bordeCuadrado;
            estiloCeldaNumero.FormatCode = "#,##0.00";

            SLStyle estiloCeldaMoneda = new SLStyle();
            estiloCeldaMoneda.SetHorizontalAlignment(HorizontalAlignmentValues.Right);
            estiloCeldaMoneda.SetVerticalAlignment(VerticalAlignmentValues.Bottom);
            estiloCeldaMoneda.SetWrapText(true);
            estiloCeldaMoneda.Border = bordeCuadrado;
            estiloCeldaMoneda.FormatCode = "#,##0.00";


            SLStyle estiloCeldaTextoReporte = new SLStyle();
            estiloCeldaTextoReporte.SetHorizontalAlignment(HorizontalAlignmentValues.Left);
            estiloCeldaTextoReporte.SetWrapText(true);
            estiloCeldaTextoReporte.Border = bordeCuadrado;

            SLStyle estiloTITULOMunicipalidad = new SLStyle();
            estiloTITULOMunicipalidad.SetHorizontalAlignment(HorizontalAlignmentValues.Center);
            estiloTITULOMunicipalidad.SetWrapText(true);
            estiloTITULOMunicipalidad.Font = new SLFont();
            estiloTITULOMunicipalidad.Font.FontSize = 14;

            string celda = "";
            int contadorColumna=0;
            int inicioColumnaIngresos = 0;
            int inicioColumnaAportacionesTrabajador = 0;
            int inicioColumnaDescuentos = 0;
            int inicioColumnaAportacionesEmple = 0;
            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanilla item in oPlanilla.ListaDetalle)
            {
                contador++;
                celda = (contador + 11).ToString();
                miReporte.SetCellValue("A" + celda, contador.ToString());
                miReporte.SetCellStyle("A" + celda, estiloCeldaReporte);
                miReporte.MergeWorksheetCells("A10", "A11");
                miReporte.SetCellStyle("A10", "A11", estiloTituloReporte);

                miReporte.SetCellValue("B" + celda, item.miTrabajador.Nombres + " " + item.miTrabajador.ApellidoPaterno + " " + item.miTrabajador.ApellidoMaterno);
                miReporte.SetCellStyle("B" + celda, estiloCeldaTextoReporte);
                miReporte.MergeWorksheetCells("B10", "B11");
                miReporte.SetCellValue("C" + celda, item.cargo);
                miReporte.SetCellStyle("C" + celda, estiloCeldaTextoReporte);
                miReporte.MergeWorksheetCells("C10", "C11");
                miReporte.SetCellValue("D" + celda, item.miTrabajador.Dni);
                miReporte.SetCellStyle("D" + celda, estiloCeldaTextoReporte);
                miReporte.MergeWorksheetCells("D10", "D11");
                miReporte.SetCellValue("E" + celda, item.fechaInicio.ToShortDateString());
                miReporte.SetCellStyle("E" + celda, estiloCeldaTextoReporte);
                miReporte.MergeWorksheetCells("E10", "E11");
                //Ojoooooooooooooooooooooooooooooooooo
                item.afp = item.miTrabajador.ListaRegimenPensionario.Last().MiAFP;
                item.cuspp = item.miTrabajador.ListaRegimenPensionario.Last().Cuspp;
                item.comision = item.miTrabajador.ListaRegimenPensionario.Last().TipoComision;
                string letraComision = "";
                if (item.comision.Length>0 && !(item.afp.Nombre.Contains("SNP")))
                {
                    letraComision = "(" + item.comision.Substring(0, 1) + ")";
                }
                miReporte.SetCellValue("F" + celda, item.afp.Nombre + letraComision);
                miReporte.SetCellStyle("F" + celda, estiloCeldaTextoReporte);
                miReporte.MergeWorksheetCells("F10", "F11");
                //PARTE INGRESOS
                inicioColumnaIngresos = 7;
                contadorColumna = inicioColumnaIngresos-1;
                foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaIngresos item2 in item.ListaDetalleIngresos)
                {
                    contadorColumna++;
                    miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + "11", item2.MaestroIngresos.Abreviacion);
                    miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + "11", estiloTituloReporte);

                    miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, item2.Monto);
                    miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, estiloCeldaNumero);
                    
                }
                contadorColumna++;
                miReporte.MergeWorksheetCells(miUtilidades.DevolverLetraExcel(inicioColumnaIngresos) + "10", miUtilidades.DevolverLetraExcel(contadorColumna) + 10);
                miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(inicioColumnaIngresos) + "10",  "INGRESOS");
                miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(inicioColumnaIngresos) + "10", miUtilidades.DevolverLetraExcel(contadorColumna) + 10, estiloTituloReporte);

                miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + "11", "TOTAL INGRESOS");
                miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + "11", estiloTituloReporte);
                miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, item.totalIngreso);
                miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, estiloCeldaNumero);
                //PARTE APORTACIONES TRABAJADOR

                
                inicioColumnaAportacionesTrabajador = contadorColumna+1;

                foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaAportacionesTrabajador item3 in item.ListaDetalleAportacionesTrabajador)
                {
                    contadorColumna++;
                    miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + "11", item3.MaestroAportacionTrabajador.Abreviacion);
                    miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + "11", estiloTituloReporte);

                    miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, item3.Monto);
                    miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, estiloCeldaNumero);
                }
                contadorColumna++;

                miReporte.MergeWorksheetCells(miUtilidades.DevolverLetraExcel(inicioColumnaAportacionesTrabajador) + "10", miUtilidades.DevolverLetraExcel(contadorColumna) + 10);
                miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(inicioColumnaAportacionesTrabajador) + "10", "APORTACIONES TRABAJADOR");
                miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(inicioColumnaAportacionesTrabajador) + "10", miUtilidades.DevolverLetraExcel(contadorColumna) + 10, estiloTituloReporte);

                miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + "11", "TOTAL APORTACIONES TRAB");
                miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + "11", estiloTituloReporte);
                miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, item.totalAportacionesTrabajador);
                miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, estiloCeldaNumero);

                //PARTE DESCUENTOS TRABAJADOR
                inicioColumnaDescuentos = contadorColumna + 1;

                foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaEgresos item4 in item.ListaDetalleEgresos)
                {
                    contadorColumna++;
                    miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + "11", item4.MaestroDescuentos.Abreviacion);
                    miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + "11", estiloTituloReporte);

                    miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, item4.Monto);
                    miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, estiloCeldaNumero);
                }
                contadorColumna++;

                miReporte.MergeWorksheetCells(miUtilidades.DevolverLetraExcel(inicioColumnaDescuentos) + "10", miUtilidades.DevolverLetraExcel(contadorColumna) + 10);
                miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(inicioColumnaDescuentos) + "10", "DESCUENTOS TRABAJADOR");
                miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(inicioColumnaDescuentos) + "10", miUtilidades.DevolverLetraExcel(contadorColumna) + 10,estiloTituloReporte);

                miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + "11", "TOTAL DESCUENTOS");
                miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + "11", estiloTituloReporte);
                miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, item.totalAportacionesTrabajador);
                miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, estiloCeldaNumero);

                //PARTE APORTACIONES EMPLEADOR
                inicioColumnaAportacionesEmple = contadorColumna + 1;

                foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaAportacionesEmpleador item5 in item.ListaDetalleAportacionesEmpleador)
                {
                    contadorColumna++;
                    miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + "11", item5.MaestroAportacionesEmpleador.Abreviacion);
                    miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + "11", estiloTituloReporte);

                    miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, item5.Monto);
                    miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, estiloCeldaNumero);
                }
                contadorColumna++;

                miReporte.MergeWorksheetCells(miUtilidades.DevolverLetraExcel(inicioColumnaAportacionesEmple) + "10", miUtilidades.DevolverLetraExcel(contadorColumna) + 10);
                miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(inicioColumnaAportacionesEmple) + "10", "APORTACIONES EMPLEADOR");
                miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(inicioColumnaAportacionesEmple) + "10", miUtilidades.DevolverLetraExcel(contadorColumna) + 10, estiloTituloReporte);

                miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + "11", "TOTAL APORTACIONES EMPLEADOR");
                miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + "11", estiloTituloReporte);
                miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, item.totalAportacionesTrabajador);
                miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, estiloCeldaNumero);

                contadorColumna++;
                miReporte.MergeWorksheetCells(miUtilidades.DevolverLetraExcel(contadorColumna) + "10", miUtilidades.DevolverLetraExcel(contadorColumna) + "11");
                miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + "10", "NETO A COBRAR");
                miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + "10", estiloTituloReporte);

                miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, item.netoACobrar);
                miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, estiloCeldaNumero);

                contadorColumna++;
                miReporte.MergeWorksheetCells(miUtilidades.DevolverLetraExcel(contadorColumna) + "10", miUtilidades.DevolverLetraExcel(contadorColumna) + "11");
                miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + "10", "DIAS LABORADOS");
                miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + "10", estiloTituloReporte);

                miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, item.diasLaborados.ToString());
                miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, estiloCeldaReporte);

                contadorColumna++;
                miReporte.MergeWorksheetCells(miUtilidades.DevolverLetraExcel(contadorColumna) + "10", miUtilidades.DevolverLetraExcel(contadorColumna) + "11");
                miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + "10", "OBSERVACIONES");
                miReporte.SetColumnWidth(miUtilidades.DevolverLetraExcel(contadorColumna),27);
                miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + "10", estiloTituloReporte);
                miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, estiloCeldaReporte);
            }
            //Parte Totales
            contador++;
            celda = (contador + 11).ToString();
            CapaDeNegocios.PlanillaNueva.cnDetallePlanilla ListaTotales = oblPlanilla.ListaTotales(oPlanilla);



            double sumaIngresos = 0;
            contadorColumna = inicioColumnaIngresos-1;
            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaIngresos item in ListaTotales.ListaDetalleIngresos)
            {
                contadorColumna++;
                miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, item.Monto);
                miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, estiloCeldaNumero);
                sumaIngresos += item.Monto;
            }
            contadorColumna++;
            miReporte.MergeWorksheetCells("A" + celda, "F" + celda);
            miReporte.SetCellValue("A" + celda, "TOTAL");
            miReporte.SetCellStyle("A" + celda, "F" + celda, estiloCeldaTextoReporte);
            
            miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, sumaIngresos);
            miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, estiloCeldaNumero);

            double sumaAportaciones = 0;

            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaAportacionesTrabajador item3 in ListaTotales.ListaDetalleAportacionesTrabajador)
            {
                contadorColumna++;
                miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, item3.Monto);
                miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, estiloCeldaNumero);
                sumaAportaciones += item3.Monto;
            }
            contadorColumna++;
            miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, sumaAportaciones);
            miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, estiloCeldaNumero);

            double sumaDescuentos = 0;
            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaEgresos item2 in ListaTotales.ListaDetalleEgresos)
            {
                contadorColumna++;
                miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, item2.Monto);
                miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, estiloCeldaNumero);
                sumaDescuentos += item2.Monto;
            }
            contadorColumna++;
            miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, sumaDescuentos);
            miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, estiloCeldaReporte);

            double sumaAportacionesEmpleador = 0;
            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaAportacionesEmpleador item4 in ListaTotales.ListaDetalleAportacionesEmpleador)
            {
                contadorColumna++;
                miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, item4.Monto);
                miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, estiloCeldaNumero);
                sumaAportacionesEmpleador += item4.Monto;
            }

            contadorColumna++;
            miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, sumaAportacionesEmpleador);
            miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, estiloCeldaReporte);

            contadorColumna++;
            miReporte.SetCellValue(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, ListaTotales.netoACobrar);
            miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, estiloCeldaNumero);
            contadorColumna++;
            miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, estiloCeldaReporte);
            contadorColumna++;
            miReporte.SetCellStyle(miUtilidades.DevolverLetraExcel(contadorColumna) + celda, estiloCeldaReporte);

            contador++;
            celda = (contador + 11).ToString();
            miReporte.MergeWorksheetCells("A" + celda, miUtilidades.DevolverLetraExcel(contadorColumna) + celda);
            miReporte.SetCellValue("A" + celda, lugar + ", " + DateTime.Now.Day + " de " + DateTime.Now.ToString("MMMM") + " del " + DateTime.Now.Year.ToString());
            miReporte.SetCellStyle("A" + celda, estiloTITULOMunicipalidad);
            contador++;
            contador++;
            celda = (contador + 11).ToString();

            int FilaInicioResumenes = contador;
            //parte resumen afp
            miReporte.MergeWorksheetCells("B" + celda, "C" + celda);
            miReporte.SetCellValue("B" + celda, "RESUMEN AFP");
            miReporte.SetCellStyle("B" + celda, "C" + celda, estiloTituloReporte);

            List<cDetalleResumenAFP> ResumenAFP = new List<cDetalleResumenAFP>();
            cListaAFP listaAFP = new cListaAFP();
            List<cAFP> afps = listaAFP.TraerListaAFPS();

            foreach (cAFP item5 in afps)
            {
                cDetalleResumenAFP resumen = new cDetalleResumenAFP();
                resumen.AFP = item5;
                resumen.Monto = 0;
                ResumenAFP.Add(resumen);
            }
            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanilla item5 in oPlanilla.ListaDetalle)
            {
                foreach (cDetalleResumenAFP item6 in ResumenAFP)
                {
                    if (item6.AFP.CodigoAFP == item5.afp.CodigoAFP)
                    {
                        item6.Monto += item5.totalDescuentoAFP;
                    }
                }
            }

            double totalAFP = 0;
            foreach (cDetalleResumenAFP item7 in ResumenAFP)
            {
                if (item7.Monto > 0)
                {
                    contador++;
                    celda = (contador + 11).ToString();
                    miReporte.SetCellValue("B" + celda, item7.AFP.Nombre);
                    miReporte.SetCellStyle("B" + celda, estiloCeldaTextoReporte);
                    miReporte.SetCellValue("C" + celda, item7.Monto);
                    miReporte.SetCellStyle("C" + celda, estiloCeldaNumero);
                    totalAFP += item7.Monto;
                }
            }

            contador++;
            celda = (contador + 11).ToString();
            miReporte.SetCellValue("B" + celda, "TOTAL AFP");
            miReporte.SetCellStyle("B" + celda, estiloCeldaTextoReporte);
            miReporte.SetCellValue("C" + celda, totalAFP);
            miReporte.SetCellStyle("C" + celda, estiloCeldaNumero);

            //parte debe haber

            List<cDetalleDebeHaber> ResumenDebeHaber = new List<cDetalleDebeHaber>();

            cDetalleDebeHaber debeHaberIngresos = new cDetalleDebeHaber();
            debeHaberIngresos.TipoHaberDebe = enumTipoHaberDebe.haber;
            debeHaberIngresos.Concepto = "TOTAL INGRESOS";
            debeHaberIngresos.Monto = sumaIngresos;
            ResumenDebeHaber.Add(debeHaberIngresos);

            cDetalleDebeHaber debeHaberAportaciones = new cDetalleDebeHaber();
            debeHaberAportaciones.TipoHaberDebe = enumTipoHaberDebe.haber;
            debeHaberAportaciones.Concepto = "TOTAL APORTACIONES";
            debeHaberAportaciones.Monto = sumaAportacionesEmpleador;
            ResumenDebeHaber.Add(debeHaberAportaciones);

            cDetalleDebeHaber debeHaberNeto = new cDetalleDebeHaber();
            debeHaberNeto.TipoHaberDebe = enumTipoHaberDebe.debe;
            debeHaberNeto.Concepto = "NETO A COBRAR";
            debeHaberNeto.Monto = ListaTotales.netoACobrar;
            ResumenDebeHaber.Add(debeHaberNeto);

            cDetalleDebeHaber debeHaberAFP = new cDetalleDebeHaber();
            debeHaberAFP.TipoHaberDebe = enumTipoHaberDebe.debe;
            debeHaberAFP.Concepto = "AFP";
            debeHaberAFP.Monto = ListaTotales.totalDescuentoAFP;
            ResumenDebeHaber.Add(debeHaberAFP);

            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaAportacionesTrabajador item in ListaTotales.ListaDetalleAportacionesTrabajador)
            {
                if (item.MaestroAportacionTrabajador.Codigo != "0608" && item.MaestroAportacionTrabajador.Codigo != "0601" && item.MaestroAportacionTrabajador.Codigo != "0606")
                {
                    cDetalleDebeHaber debeHaber = new cDetalleDebeHaber();
                    debeHaber.TipoHaberDebe = enumTipoHaberDebe.debe;
                    debeHaber.Concepto = item.MaestroAportacionTrabajador.Abreviacion;
                    debeHaber.Monto = item.Monto;
                    ResumenDebeHaber.Add(debeHaber);
                }
            }

            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaEgresos item in ListaTotales.ListaDetalleEgresos)
            {
                cDetalleDebeHaber debeHaber = new cDetalleDebeHaber();
                debeHaber.TipoHaberDebe = enumTipoHaberDebe.debe;
                debeHaber.Concepto = item.MaestroDescuentos.Abreviacion;
                debeHaber.Monto = item.Monto;
                ResumenDebeHaber.Add(debeHaber);
            }

            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaAportacionesEmpleador item in ListaTotales.ListaDetalleAportacionesEmpleador)
            {
                cDetalleDebeHaber debeHaber = new cDetalleDebeHaber();
                debeHaber.TipoHaberDebe = enumTipoHaberDebe.debe;
                debeHaber.Concepto = item.MaestroAportacionesEmpleador.Abreviacion;
                debeHaber.Monto = item.Monto;
                ResumenDebeHaber.Add(debeHaber);
            }

            contador = FilaInicioResumenes;
            contador++;
            celda = (contador + 11).ToString();
            miReporte.SetCellValue("O" + celda, "DEBE");
            miReporte.SetCellStyle("O" + celda, estiloTituloReporte);
            miReporte.SetCellValue("P" + celda, "HABER");
            miReporte.SetCellStyle("P" + celda, estiloTituloReporte);

            double totalDebe = 0;
            double totalHaber = 0;

            foreach (cDetalleDebeHaber item7 in ResumenDebeHaber)
            {
                contador++;
                celda = (contador + 11).ToString();
                if (item7.TipoHaberDebe == enumTipoHaberDebe.haber)
                {
                    miReporte.MergeWorksheetCells("M" + celda, "N" + celda);
                    miReporte.SetCellValue("M" + celda, item7.Concepto);
                    miReporte.SetCellStyle("M" + celda, "N" + celda, estiloCeldaTextoReporte);

                    miReporte.SetCellValue("O" + celda, item7.Monto); //.ToString("c", new CultureInfo("es-PE")));
                    miReporte.SetCellStyle("O" + celda, estiloCeldaMoneda);
                    miReporte.SetCellStyle("P" + celda, estiloCeldaReporte);
                    totalHaber += item7.Monto;
                }
                else
                {
                    miReporte.MergeWorksheetCells("M" + celda, "N" + celda);
                    miReporte.SetCellValue("M" + celda, item7.Concepto);
                    miReporte.SetCellStyle("M" + celda, "N" + celda, estiloCeldaTextoReporte);
                    miReporte.SetCellValue("P" + celda, item7.Monto);
                    miReporte.SetCellStyle("P" + celda, estiloCeldaMoneda);
                    miReporte.SetCellStyle("O" + celda, estiloCeldaReporte);
                    totalDebe += item7.Monto;
                }
            }
            contador++;
            celda = (contador + 11).ToString();
            miReporte.MergeWorksheetCells("M" + celda, "N" + celda);
            miReporte.SetCellStyle("M" + celda, "N" + celda, estiloCeldaTextoReporte);
            miReporte.SetCellValue("M" + celda, "TOTAL");
            miReporte.SetCellValue("O" + celda, totalHaber);
            miReporte.SetCellStyle("O" + celda, estiloCeldaReporte);
            miReporte.SetCellValue("P" + celda, totalDebe);
            miReporte.SetCellStyle("P" + celda, estiloCeldaReporte);

            contador+=3;
            celda = (contador + 11).ToString();
            miReporte.MergeWorksheetCells("A" + celda, miUtilidades.DevolverLetraExcel(contadorColumna) + celda);
            string todasFirmas = "        ";
            foreach (string firma in firmas)
            {
                
                todasFirmas +=firma + "      ";
            }

            miReporte.SetCellValue("A" + celda, todasFirmas);
        }
    }
}
