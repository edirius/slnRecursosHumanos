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
            ImprimirTareo();
        }

        private void ImprimirTareo()
        {
            int contador = 0;
            try
            {
                foreach (DataRow row in oImprimirTareo.Rows)
                {
                    contador += 1;
                    oHoja.Range["I8"].Formula = oImprimirTareo.Rows.Count;//TOTAL DE TRABAJADORES
                    oHoja.Range["O4"].Formula = row[1].ToString();//META
                    oHoja.Range["O6"].Formula = row[2].ToString();//NUMERO DE META
                    oHoja.Range["AA6"].Formula = row[8].ToString();//FECHA
                    //hoja.Range["O7"].Formula = row[8].ToString();//FUENTE DE FINANCIAMIENTO
                    oHoja.Range["O8"].Formula = row[5].ToString() + " " + row[6].ToString() + ", " + row[4].ToString();//RESIDENTE

                    oHoja.Range["A" + (10 + contador).ToString()].Formula = contador;
                    oHoja.Range["B" + (10 + contador).ToString()].Formula = row[16].ToString() + " " + row[17].ToString() + ", " + row[15].ToString();//APELLIDSO Y NOMBRES
                    oHoja.Range["E" + (10 + contador).ToString()].Formula = row[19].ToString();//DNI
                    oHoja.Range["F" + (10 + contador).ToString()].Formula = row[20].ToString();//FECHA NACIMIENTO
                    oHoja.Range["G" + (10 + contador).ToString()].Formula = row[18].ToString();//SEXO
                    oHoja.Range["H" + (10 + contador).ToString()].Formula = row[11].ToString();//CATEGORIA
                    oHoja.Range["I" + (10 + contador).ToString()].Formula = row[21].ToString();//FECHA DE INGRESO
                    oHoja.Range["AO" + (10 + contador).ToString()].Formula = row[13].ToString();//TOTAL DIAS TRABAJADOS

                    oHoja.Range["J" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(0, 1);
                    oHoja.Range["K" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(1, 1);
                    oHoja.Range["L" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(2, 1);
                    oHoja.Range["M" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(3, 1);
                    oHoja.Range["N" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(4, 1);
                    oHoja.Range["O" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(5, 1);
                    oHoja.Range["P" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(6, 1);
                    oHoja.Range["Q" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(7, 1);
                    oHoja.Range["R" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(8, 1);
                    oHoja.Range["S" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(9, 1);
                    oHoja.Range["T" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(10, 1);
                    oHoja.Range["U" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(11, 1);
                    oHoja.Range["V" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(12, 1);
                    oHoja.Range["W" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(13, 1);
                    oHoja.Range["X" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(14, 1);
                    oHoja.Range["Y" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(15, 1);
                    oHoja.Range["Z" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(16, 1);
                    oHoja.Range["AA" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(17, 1);
                    oHoja.Range["AB" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(18, 1);
                    oHoja.Range["AC" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(19, 1);
                    oHoja.Range["AD" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(20, 1);
                    oHoja.Range["AE" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(21, 1);
                    oHoja.Range["AF" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(22, 1);
                    oHoja.Range["AG" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(23, 1);
                    oHoja.Range["AH" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(24, 1);
                    oHoja.Range["AI" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(25, 1);
                    oHoja.Range["AJ" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(26, 1);
                    oHoja.Range["AK" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(27, 1);
                    oHoja.Range["AL" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(28, 1);
                    oHoja.Range["AM" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(29, 1);
                    oHoja.Range["AN" + (10 + contador).ToString()].Formula = row[12].ToString().Substring(30, 1);

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
    }
}
