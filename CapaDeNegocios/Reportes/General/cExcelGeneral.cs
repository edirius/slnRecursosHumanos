using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpreadsheetLight;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Globalization;

namespace CapaDeNegocios.Reportes.General
{
    public class cExcelGeneral
    {
        public void ExportarExcelResidenteMeta(List<ResidenteMeta.cResidenteMeta> Lista, string ruta)
        {
            try
            {
                SpreadsheetLight.SLDocument miReporte;

                miReporte = new SpreadsheetLight.SLDocument();

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

                SLStyle estiloTituloReporteP = new SLStyle();
                estiloTituloReporteP.SetFontBold(true);
                estiloTituloReporteP.SetHorizontalAlignment(HorizontalAlignmentValues.Center);
                estiloTituloReporteP.SetWrapText(true);

                SLStyle estiloCeldaTextoReporte = new SLStyle();
                estiloCeldaTextoReporte.SetHorizontalAlignment(HorizontalAlignmentValues.Left);
                estiloCeldaTextoReporte.SetWrapText(true);
                estiloCeldaTextoReporte.Border = bordeCuadrado;

                miReporte.SetCellValue("A1", "REPORTE DE METAS ASIGNADAS");
                miReporte.MergeWorksheetCells("A1", "C1");
                miReporte.SetCellStyle("A1", estiloTituloReporteP);

                miReporte.SetCellValue("B4", "META");
                miReporte.SetCellStyle("B4", estiloTituloReporte);
                miReporte.SetColumnWidth("B", 100);

                miReporte.SetCellValue("C4", "ASIGNADO A:");
                miReporte.SetCellStyle("C4", estiloTituloReporte);
                miReporte.SetColumnWidth("C", 100);

                int filaInicial = 4;
                foreach (ResidenteMeta.cResidenteMeta item in Lista)
                {
                    filaInicial++;

                    miReporte.SetCellValue("B" + filaInicial.ToString(), item.Meta);
                    miReporte.SetCellStyle("B" + filaInicial.ToString(), estiloCeldaTextoReporte);
                    miReporte.SetCellValue("C" + filaInicial.ToString(), item.Trabajador);
                    miReporte.SetCellStyle("C" + filaInicial.ToString(), estiloCeldaTextoReporte);

                }
                miReporte.SaveAs(ruta);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo ExportarExcelResidenteMeta: " + ex.Message);
            }
        }
    }
}
