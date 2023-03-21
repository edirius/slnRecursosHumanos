using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpreadsheetLight;
using System.Data;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;

namespace CapaDeNegocios.Meta
{
    public class cImprimirMetaJornal
    {
        SpreadsheetLight.SLDocument miReporte;

        public DataTable tablaMetaJornal = new DataTable();
      
        public string ruta;
      

        public void Imprimir()
        {
            miReporte = new SpreadsheetLight.SLDocument();
            int contador = 0;
        
            try
            {
                foreach (DataRow row in tablaMetaJornal.Rows)
                {

                    SLStyle EstiloX = miReporte.GetCellStyle("J11");

                    contador += 1;
                    miReporte.SetCellValue("A2", "LISTA DE META - JORNAL");

                    miReporte.SetCellValue("A3", "Nro");
                    miReporte.SetCellValue("B3", "Numero Meta");
                    miReporte.SetCellValue("C3", "META");
                    miReporte.SetCellValue("D3", "CATEGORIA");
                    miReporte.SetCellValue("E3", "PAGO X JORNAL");
                    miReporte.SetCellValue("F3", "PAGO MENSUAL");
                    miReporte.SetCellValue("G3", "TIPO PAGO");

                    miReporte.SetCellValue("A" + (4 + contador).ToString(), contador);
                    miReporte.SetCellStyle("A" + (4 + contador).ToString(), EstiloX);

                    miReporte.SetCellValue("B" + (4 + contador).ToString(), row[9].ToString());//Numero META
                    miReporte.SetCellStyle("B" + (4 + contador).ToString(), EstiloX);

                    miReporte.SetCellValue("C" + (4 + contador).ToString(), row[8].ToString());//META
                    miReporte.SetCellStyle("C" + (4 + contador).ToString(), EstiloX);

                    miReporte.SetCellValue("D" + (4 + contador).ToString(), row[1].ToString());//CATEGORIA
                    miReporte.SetCellStyle("D" + (4 + contador).ToString(), EstiloX);

                    miReporte.SetCellValue("E" + (4 + contador).ToString(), row[2].ToString());//JORNAL
                    miReporte.SetCellStyle("E" + (4 + contador).ToString(), EstiloX);

                    miReporte.SetCellValue("F" + (4 + contador).ToString(), row[4].ToString());//MENSUAL
                    miReporte.SetCellStyle("F" + (4 + contador).ToString(), EstiloX);


                    if (row[5] is DBNull || Convert.ToBoolean(row[5])== false)
                    {
                        miReporte.SetCellValue("G" + (4 + contador).ToString(), "PAGO DIARIO");//JORNAL
                        miReporte.SetCellStyle("G" + (4 + contador).ToString(), EstiloX);
                    }
                    else
                    {
                        miReporte.SetCellValue("G" + (4 + contador).ToString(), "PAGO MENSUAL");//JORNAL
                        miReporte.SetCellStyle("G" + (4 + contador).ToString(), EstiloX);
                    }

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
