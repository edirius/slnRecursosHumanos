using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpreadsheetLight;
using System.Data;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;

namespace CapaDeNegocios.Tareos
{

    public class cImprimirTareo2
    {
        SpreadsheetLight.SLDocument miTareo; 
        

        public DataTable tablaTareo = new DataTable();
        public DateTime fechainicio;
        public string ruta;
        public string rutaarchivo = AppDomain.CurrentDomain.BaseDirectory + "Tareo.xltx";

        public void Imprimir()
        {
            miTareo = new SpreadsheetLight.SLDocument(rutaarchivo, "Tareo");
            Dias_Mes();
            int contador = 0;
            int celda_inicio = 10;
            string dia_celda = "";
            string mes = "";
            string año = "";
            int nro_dias = 0;
            try
            {
                foreach (DataRow row in tablaTareo.Rows)
                {
                    SLStyle Estilo = miTareo.GetCellStyle("A11");
                    SLStyle EstiloNombre = miTareo.GetCellStyle("B11");
                    SLStyle EstiloFecha = miTareo.GetCellStyle("F11");
                    SLStyle EstiloX = miTareo.GetCellStyle("J11");
                   
                    contador += 1;
                    miTareo.SetCellValue("A2" , "HOJA DE INFORMACIÓN DE ASISTENCIA DE " + row[10].ToString());
                    
                    miTareo.SetCellValue("I8", tablaTareo.Rows.Count);//TOTAL DE TRABAJADORES
                    miTareo.SetCellValue("O4", row[1].ToString());//META
                    miTareo.SetCellValue("O6",row[2].ToString());//NUMERO DE META
                    miTareo.SetCellValue("AA6", Convert.ToString(Convert.ToDateTime(row[8].ToString()).ToString("MMMM")).ToUpper() + " DEL " + Convert.ToString(Convert.ToDateTime(row[8].ToString()).ToString("yyyy")));//FECHA
                    //hoja.Range["O7"].Formula = row[8].ToString();//FUENTE DE FINANCIAMIENTO
                    miTareo.SetCellValue("O8", row[5].ToString() + " " + row[6].ToString() + ", " + row[4].ToString());//RESIDENTE

                    miTareo.SetCellValue("A" + (10 + contador).ToString(), contador);
                    miTareo.SetCellStyle("A" + (10 + contador).ToString(), Estilo);

                    miTareo.SetCellValue("B" + (10 + contador).ToString(), row[16].ToString() + " " + row[17].ToString() + ", " + row[15].ToString());//APELLIDSO Y NOMBRES
                    miTareo.SetCellStyle("B" + (10 + contador).ToString(), EstiloNombre);//APELLIDSO Y NOMBRES

                    miTareo.SetCellValue("E" + (10 + contador).ToString(), row[19].ToString());//DNI
                    miTareo.SetCellStyle("E" + (10 + contador).ToString(), Estilo);//DNI

                    miTareo.SetCellValue("F" + (10 + contador).ToString(), Convert.ToDateTime(row[20].ToString()).Date);//FECHA NACIMIENTO
                    miTareo.SetCellStyle("F" + (10 + contador).ToString(), EstiloFecha);//FECHA NACIMIENTO

                    miTareo.SetCellValue("G" + (10 + contador).ToString(), row[18].ToString());//SEXO
                    miTareo.SetCellStyle("G" + (10 + contador).ToString(), Estilo);//SEXO

                    miTareo.SetCellValue("H" + (10 + contador).ToString(), row[11].ToString());//CATEGORIA
                    miTareo.SetCellStyle("H" + (10 + contador).ToString(), Estilo);//CATEGORIA

                    miTareo.SetCellValue("I" + (10 + contador).ToString(), Convert.ToDateTime(row[21].ToString()).Date);//FECHA DE INGRESO
                    miTareo.SetCellStyle("I" + (10 + contador).ToString(), EstiloFecha);//FECHA DE INGRESO

                    miTareo.SetCellValue("AO" + (10 + contador).ToString(), row[13].ToString());//TOTAL DIAS TRABAJADOS
                    miTareo.SetCellStyle("AO" + (10 + contador).ToString(), Estilo);//TOTAL DIAS TRABAJADOS

                    mes = Convert.ToDateTime(row[8].ToString()).Month.ToString();
                    año = Convert.ToDateTime(row[8].ToString()).Year.ToString();
                    nro_dias = DateTime.DaysInMonth(Convert.ToDateTime(row[8].ToString()).Year, Convert.ToDateTime(row[8].ToString()).Month);
                    
                    for (int dia = 0; dia < nro_dias; dia++)
                    {
                        if (dia + 1 == 1) { dia_celda = "J"; }
                        if (dia + 1 == 2) { dia_celda = "K"; }
                        if (dia + 1 == 3) { dia_celda = "L"; }
                        if (dia + 1 == 4) { dia_celda = "M"; }
                        if (dia + 1 == 5) { dia_celda = "N"; }
                        if (dia + 1 == 6) { dia_celda = "O"; }
                        if (dia + 1 == 7) { dia_celda = "P"; }
                        if (dia + 1 == 8) { dia_celda = "Q"; }
                        if (dia + 1 == 9) { dia_celda = "R"; }
                        if (dia + 1 == 10) { dia_celda = "S"; }
                        if (dia + 1 == 11) { dia_celda = "T"; }
                        if (dia + 1 == 12) { dia_celda = "U"; }
                        if (dia + 1 == 13) { dia_celda = "V"; }
                        if (dia + 1 == 14) { dia_celda = "W"; }
                        if (dia + 1 == 15) { dia_celda = "X"; }
                        if (dia + 1 == 16) { dia_celda = "Y"; }
                        if (dia + 1 == 17) { dia_celda = "Z"; }
                        if (dia + 1 == 18) { dia_celda = "AA"; }
                        if (dia + 1 == 19) { dia_celda = "AB"; }
                        if (dia + 1 == 20) { dia_celda = "AC"; }
                        if (dia + 1 == 21) { dia_celda = "AD"; }
                        if (dia + 1 == 22) { dia_celda = "AE"; }
                        if (dia + 1 == 23) { dia_celda = "AF"; }
                        if (dia + 1 == 24) { dia_celda = "AG"; }
                        if (dia + 1 == 25) { dia_celda = "AH"; }
                        if (dia + 1 == 26) { dia_celda = "AI"; }
                        if (dia + 1 == 27) { dia_celda = "AJ"; }
                        if (dia + 1 == 28) { dia_celda = "AK"; }
                        if (dia + 1 == 29) { dia_celda = "AL"; }
                        if (dia + 1 == 30) { dia_celda = "AM"; }
                        if (dia + 1 == 31) { dia_celda = "AN"; }
                        miTareo.SetCellValue(dia_celda + (celda_inicio + contador).ToString(), row[12].ToString().Substring(dia, 1));
                        miTareo.SetCellStyle(dia_celda + (celda_inicio + contador).ToString(), EstiloX);

                        if (miTareo.GetCellValueAsString(dia_celda + 9) == "D")
                        {
                            
                        }


                    }

                    SLConditionalFormatting cf;
                    SLStyle style = new SLStyle();
                    style = EstiloX;
                    style.SetPatternFill(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkRed);
                    cf = new SLConditionalFormatting("J9", dia_celda + (celda_inicio + tablaTareo.Rows.Count).ToString());
                    cf.HighlightCellsWithFormula("=J$9=\"D\"", style);
                    miTareo.AddConditionalFormatting(cf);
                    //miTareo.SetCellStyle(dia_celda + (celda_inicio + contador).ToString(), style);

                    if (contador < tablaTareo.Rows.Count)
                    {
                        miTareo.InsertRow(11 + contador, 1);
                        
                    }
                }
               
                //_excel.Quit();
                miTareo.SaveAs(ruta);
            }
            catch (Exception e)
            {
                throw new cReglaNegociosException("Error al imprimir excel, verifique que su excel sea original: " + e.Message);
            }
        }

        private void Dias_Mes()
        {
            try
            {
                int celda_inicio = 9;
                string dia_celda = "";
                string mes = "";
                string año = "";
                int nro_dias = 0;

                mes = fechainicio.Month.ToString();
                año = fechainicio.Year.ToString();
                nro_dias = DateTime.DaysInMonth(fechainicio.Year, fechainicio.Month);
                for (int dia = 0; dia < nro_dias; dia++)
                {
                    if (dia + 1 == 1) { dia_celda = "J"; }
                    if (dia + 1 == 2) { dia_celda = "K"; }
                    if (dia + 1 == 3) { dia_celda = "L"; }
                    if (dia + 1 == 4) { dia_celda = "M"; }
                    if (dia + 1 == 5) { dia_celda = "N"; }
                    if (dia + 1 == 6) { dia_celda = "O"; }
                    if (dia + 1 == 7) { dia_celda = "P"; }
                    if (dia + 1 == 8) { dia_celda = "Q"; }
                    if (dia + 1 == 9) { dia_celda = "R"; }
                    if (dia + 1 == 10) { dia_celda = "S"; }
                    if (dia + 1 == 11) { dia_celda = "T"; }
                    if (dia + 1 == 12) { dia_celda = "U"; }
                    if (dia + 1 == 13) { dia_celda = "V"; }
                    if (dia + 1 == 14) { dia_celda = "W"; }
                    if (dia + 1 == 15) { dia_celda = "X"; }
                    if (dia + 1 == 16) { dia_celda = "Y"; }
                    if (dia + 1 == 17) { dia_celda = "Z"; }
                    if (dia + 1 == 18) { dia_celda = "AA"; }
                    if (dia + 1 == 19) { dia_celda = "AB"; }
                    if (dia + 1 == 20) { dia_celda = "AC"; }
                    if (dia + 1 == 21) { dia_celda = "AD"; }
                    if (dia + 1 == 22) { dia_celda = "AE"; }
                    if (dia + 1 == 23) { dia_celda = "AF"; }
                    if (dia + 1 == 24) { dia_celda = "AG"; }
                    if (dia + 1 == 25) { dia_celda = "AH"; }
                    if (dia + 1 == 26) { dia_celda = "AI"; }
                    if (dia + 1 == 27) { dia_celda = "AJ"; }
                    if (dia + 1 == 28) { dia_celda = "AK"; }
                    if (dia + 1 == 29) { dia_celda = "AL"; }
                    if (dia + 1 == 30) { dia_celda = "AM"; }
                    if (dia + 1 == 31) { dia_celda = "AN"; }

                    miTareo.SetCellValue(dia_celda + (celda_inicio).ToString(), Convert.ToString(Convert.ToDateTime((dia + 1).ToString() + "/" + mes + "/" + año).ToString("dddd")).Substring(0, 1).ToUpper());
                    miTareo.SetCellValue(dia_celda + (celda_inicio + 1).ToString(), dia + 1);
                }
            }
            catch (Exception e)
            {

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
