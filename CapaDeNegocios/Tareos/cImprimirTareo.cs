using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using miExcel = Microsoft.Office.Interop.Excel;

namespace CapaDeNegocios.Tareos
{
    public class cImprimirTareo
    {
        private Microsoft.Office.Interop.Excel.Application oExcel;
        private object oMissing;
        private Microsoft.Office.Interop.Excel.Workbook oLibro;
        private Microsoft.Office.Interop.Excel.Worksheet oHoja;

        public DateTime fechainicio;
        public string rutaarchivo = AppDomain.CurrentDomain.BaseDirectory + "Tareo.xltx";
        public DataTable oImprimirTareo = new DataTable();

        public void Iniciar()
        {
            if (File.Exists(@rutaarchivo))
            {
                oExcel = new Microsoft.Office.Interop.Excel.Application(); ;
                oMissing = System.Reflection.Missing.Value;
                oLibro = oExcel.Workbooks.Add(@rutaarchivo);
                oHoja = (Microsoft.Office.Interop.Excel.Worksheet)oExcel.ActiveSheet;
                oExcel.Visible = true;
            }
            else
            {
                throw new Exception("La plantilla Tareo.xltx no se encuentra en la ruta");
            }
            Dias_Mes();
            ImprimirTareo();
        }

        private void ImprimirTareo()
        {
            int contador = 0;
            int celda_inicio = 10;
            string dia_celda = "";
            string mes = "";
            string año = "";
            int nro_dias = 0;
            try
            {
                foreach (DataRow row in oImprimirTareo.Rows)
                {
                    contador += 1;
                    oHoja.Range["I8"].Formula = oImprimirTareo.Rows.Count;//TOTAL DE TRABAJADORES
                    oHoja.Range["O4"].Formula = row[1].ToString();//META
                    oHoja.Range["O6"].Formula = row[2].ToString();//NUMERO DE META
                    oHoja.Range["AA6"].Formula = Convert.ToString(Convert.ToDateTime(row[8].ToString()).ToString("MMMM")).ToUpper() + " DEL " + Convert.ToString(Convert.ToDateTime(row[8].ToString()).ToString("yyyy"));//FECHA
                    //hoja.Range["O7"].Formula = row[8].ToString();//FUENTE DE FINANCIAMIENTO
                    oHoja.Range["O8"].Formula = row[5].ToString() + " " + row[6].ToString() + ", " + row[4].ToString();//RESIDENTE

                    oHoja.Range["A" + (10 + contador).ToString()].Formula = contador;
                    oHoja.Range["B" + (10 + contador).ToString()].Formula = row[16].ToString() + " " + row[17].ToString() + ", " + row[15].ToString();//APELLIDSO Y NOMBRES
                    oHoja.Range["E" + (10 + contador).ToString()].Formula = row[19].ToString();//DNI
                    oHoja.Range["F" + (10 + contador).ToString()].Formula = Convert.ToDateTime(row[20].ToString()).Date;//FECHA NACIMIENTO
                    oHoja.Range["G" + (10 + contador).ToString()].Formula = row[18].ToString();//SEXO
                    oHoja.Range["H" + (10 + contador).ToString()].Formula = row[11].ToString();//CATEGORIA
                    oHoja.Range["I" + (10 + contador).ToString()].Formula = Convert.ToDateTime(row[21].ToString()).Date;//FECHA DE INGRESO
                    oHoja.Range["AO" + (10 + contador).ToString()].Formula = row[13].ToString();//TOTAL DIAS TRABAJADOS

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
                        oHoja.Range[dia_celda + (celda_inicio + contador).ToString()].Formula = row[12].ToString().Substring(dia, 1);
                    }

                    if (contador < oImprimirTareo.Rows.Count)
                    {
                        oHoja.Range[(11 + contador).ToString() + ":" + (11 + contador).ToString()].Insert();
                    }
                }
                //_excel.Quit();
            }
            catch (Exception e)
            {

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

                    oHoja.Range[dia_celda + (celda_inicio).ToString()].Formula = Convert.ToString(Convert.ToDateTime((dia + 1).ToString() + "/" + mes + "/" + año).ToString("dddd")).Substring(0, 1).ToUpper();
                    oHoja.Range[dia_celda + (celda_inicio + 1).ToString()].Formula = dia + 1;
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}
