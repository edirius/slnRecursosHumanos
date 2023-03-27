using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpreadsheetLight;
using System.Data;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;

namespace CapaDeNegocios.Reloj
{
    public class cImprimirExcelAsistenciaReloj
    {
        SpreadsheetLight.SLDocument miReporte;

        public List<CapaDeNegocios.Reloj.cHuellaUsuarioReloj> ListaUsuarios;


        public string ruta;


        public void Imprimir(DateTime FechaInicioReporte, DateTime FechaFinReporte)
        {
            miReporte = new SpreadsheetLight.SLDocument();
            int contador = 0;

            try
            {
                foreach (CapaDeNegocios.Reloj.cHuellaUsuarioReloj row in ListaUsuarios)
                {

                    SLStyle EstiloX = miReporte.GetCellStyle("J11");

                    contador += 1;
                    miReporte.SetCellValue("A2", "LISTA DE PICADOS DEL RELOJ DEL " + FechaInicioReporte.ToString() + " AL " + FechaFinReporte.ToString());

                    miReporte.SetCellValue("A3", "Nro");
                    miReporte.SetCellValue("B3", "Nombre");
                    miReporte.SetCellValue("C3", "Codigo Reloj");
                    miReporte.SetCellValue("D3", "PICADO");
                    
                    miReporte.SetCellValue("A" + (4 + contador).ToString(), contador);
                    miReporte.SetCellStyle("A" + (4 + contador).ToString(), EstiloX);

                    miReporte.SetCellValue("B" + (4 + contador).ToString(), row.Nombres);//NOMBRES
                    miReporte.SetCellStyle("B" + (4 + contador).ToString(), EstiloX);

                    miReporte.SetCellValue("C" + (4 + contador).ToString(), row.IdUsuario);//META
                    miReporte.SetCellStyle("C" + (4 + contador).ToString(), EstiloX);

                    miReporte.SetCellValue("D" + (4 + contador).ToString(), row.FechaYHora.ToString());//CATEGORIA
                    miReporte.SetCellStyle("D" + (4 + contador).ToString(), EstiloX);

                }

                //_excel.Quit();
                miReporte.SaveAs(ruta);
            }
            catch (Exception e)
            {
                throw new cReglaNegociosException("Error al imprimir excel, verifique que su excel sea original: " + e.Message);
            }
        }


        public void Main()
        {
            SLDocument sl = new SLDocument();

            Random rand = new Random();
            int i, j;
            for (i = 1; i <= 20; ++i)
            {
                for (j = 1; j <= 10; ++j)
                {
                    sl.SetCellValue(i, j, 200 * rand.NextDouble());
                }
            }

            SLConditionalFormatting cf;

            cf = new SLConditionalFormatting("B2", "H5");
            cf.SetIconSet(IconSetValues.ThreeSymbols);
            sl.AddConditionalFormatting(cf);

            cf = new SLConditionalFormatting("D7", "G12");
            // Use the ThreeArrows icon set
            // "false" - don't reverse icon order
            // "false" - don't show only icons (show values too!)
            // "true" - it's greater than or equal to (instead of strictly greater than)
            // "100" - >= 100
            // Number - meaning "100" refers to actual value
            // "true" - it's greater than or equal to (instead of strictly greater than)
            // "150" - >= 150
            // Number - meaning "150" refers to actual value
            cf.SetCustomIconSet(SLThreeIconSetValues.ThreeArrows, false, false,
                true, "100", SLConditionalFormatRangeValues.Number,
                true, "150", SLConditionalFormatRangeValues.Number);
            sl.AddConditionalFormatting(cf);

            cf = new SLConditionalFormatting("C15", "J18");
            // Use the FiveRating icon set
            // Reverse the icon order!
            // Show only icons!
            // The whole range uses percentile values.
            // So it's:
            // 1st icon - whatever's before the condition for 2nd icon
            // 2nd icon > 15 percentile
            // 3rd icon > 35 percentile
            // 4th icon >= 67 percentile
            // 5th icon > 80 percentile
            cf.SetCustomIconSet(SLFiveIconSetValues.FiveRating, true, true,
                false, "15", SLConditionalFormatRangeValues.Percentile,
                false, "35", SLConditionalFormatRangeValues.Percentile,
                true, "67", SLConditionalFormatRangeValues.Percentile,
                false, "80", SLConditionalFormatRangeValues.Percentile);
            sl.AddConditionalFormatting(cf);

            sl.SaveAs(ruta);

            Console.WriteLine("End of program");
            Console.ReadLine();
        }
    }
}
