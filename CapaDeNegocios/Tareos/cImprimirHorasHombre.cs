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
    public class cImprimirHorasHombre
    {
        private Microsoft.Office.Interop.Excel.Application oExcel;
        private object oMissing;
        private Microsoft.Office.Interop.Excel.Workbook oLibro;
        private Microsoft.Office.Interop.Excel.Worksheet oHoja;

        public string tipotareo;
        public DateTime fechainicio;
        public string rutaarchivo = AppDomain.CurrentDomain.BaseDirectory + "Horas Hombre.xltx";
        public DataTable oImprimirTareo = new DataTable();
        public DataTable oImprimirHorasActual = new DataTable();
        public DataTable oImprimirHorasAcumuladas = new DataTable();
        int contadorobrero_general = 0;
        int contadortecnico_general = 0;
        double MAESTRO_DE_OBRA = 0;
        double OPERARIO = 0;
        double OFICIAL = 0;
        double PEON = 0;
        double ALMACENERO = 0;
        double GUARDIAN = 0;
        double INGENIERO_RESIDENTE = 0;
        double INSPECTOR_DE_OBRA = 0;
        double ASISTENTE_ADMINISTRATIVO = 0;
        double ASISTENTE_TECNICO = 0;
        double OPERADOR_DE_CAMIONETA = 0;
        double MAESTRO_DE_OBRA_ACULUMADO = 0;
        double OPERARIO_ACULUMADO = 0;
        double OFICIAL_ACULUMADO = 0;
        double PEON_ACULUMADO = 0;
        double ALMACENERO_ACULUMADO = 0;
        double GUARDIAN_ACULUMADO = 0;
        double INGENIERO_RESIDENTE_ACULUMADO = 0;
        double INSPECTOR_DE_OBRA_ACULUMADO = 0;
        double ASISTENTE_ADMINISTRATIVO_ACULUMADO = 0;
        double ASISTENTE_TECNICO_ACULUMADO = 0;
        double OPERADOR_DE_CAMIONETA_ACULUMADO = 0;

        public void Iniciar()
        {
            if (File.Exists(@rutaarchivo))
            {
                oExcel = new Microsoft.Office.Interop.Excel.Application(); ;
                oMissing = System.Reflection.Missing.Value;
                oLibro = oExcel.Workbooks.Add(@rutaarchivo);
                oExcel.Visible = true;
            }
            else
            {
                throw new Exception("La plantilla Horas Hombre.xltx no se encuentra en la ruta");
            }
        }

        public void Tipo()
        {
            oHoja = (Microsoft.Office.Interop.Excel.Worksheet)oExcel.ActiveSheet;
            Dias_Mes();
            if (tipotareo == "PERSONAL OBRERO")
            {
                ImprimirHorasObrero();
                HorasCategoriaObrero();
            }
            else if (tipotareo == "PERSONAL TECNICO")
            {
                ImprimirHorasTecnico();
                HorasCategoriaTecnico();
            }
        }

        public void TotalHorasActual()
        {
            try
            {
                int celda_final = 0;
                if (contadorobrero_general == 0) { celda_final += contadorobrero_general; }
                else { celda_final += (contadorobrero_general - 1); }
                if (contadortecnico_general == 0) { celda_final += contadortecnico_general; }
                else { celda_final += (contadortecnico_general - 1); }

                oHoja.Range["E" + (28 + celda_final).ToString()].Formula = MAESTRO_DE_OBRA;
                oHoja.Range["E" + (29 + celda_final).ToString()].Formula = OPERARIO;
                oHoja.Range["E" + (30 + celda_final).ToString()].Formula = OFICIAL;
                oHoja.Range["E" + (31 + celda_final).ToString()].Formula = PEON;
                oHoja.Range["E" + (32 + celda_final).ToString()].Formula = ALMACENERO;
                oHoja.Range["E" + (33 + celda_final).ToString()].Formula = GUARDIAN;
                oHoja.Range["E" + (34 + celda_final).ToString()].Formula = INGENIERO_RESIDENTE;
                oHoja.Range["E" + (35 + celda_final).ToString()].Formula = INSPECTOR_DE_OBRA;
                oHoja.Range["E" + (36 + celda_final).ToString()].Formula = ASISTENTE_ADMINISTRATIVO;
                oHoja.Range["E" + (37 + celda_final).ToString()].Formula = ASISTENTE_TECNICO;
                oHoja.Range["E" + (38 + celda_final).ToString()].Formula = OPERADOR_DE_CAMIONETA;

                oHoja.Range["U" + (22 + celda_final).ToString()].Formula = MAESTRO_DE_OBRA + OPERARIO + OFICIAL + PEON + ALMACENERO + GUARDIAN;
                oHoja.Range["U" + (23 + celda_final).ToString()].Formula = INGENIERO_RESIDENTE + INSPECTOR_DE_OBRA + ASISTENTE_ADMINISTRATIVO + ASISTENTE_TECNICO + OPERADOR_DE_CAMIONETA;
            }
            catch (Exception e)
            {

            }
        }

        public void TotalHorasAcumuladas()
        {
            try
            {
                HorasCategoriaAcumulado();
                int celda_final = 0;
                if (contadorobrero_general == 0) { celda_final += contadorobrero_general; }
                else { celda_final += (contadorobrero_general - 1); }
                if (contadortecnico_general == 0) { celda_final += contadortecnico_general; }
                else { celda_final += (contadortecnico_general - 1); }

                oHoja.Range["D" + (28 + celda_final).ToString()].Formula = MAESTRO_DE_OBRA_ACULUMADO;
                oHoja.Range["D" + (29 + celda_final).ToString()].Formula = OPERARIO_ACULUMADO;
                oHoja.Range["D" + (30 + celda_final).ToString()].Formula = OFICIAL_ACULUMADO;
                oHoja.Range["D" + (31 + celda_final).ToString()].Formula = PEON_ACULUMADO;
                oHoja.Range["D" + (32 + celda_final).ToString()].Formula = ALMACENERO_ACULUMADO;
                oHoja.Range["D" + (33 + celda_final).ToString()].Formula = GUARDIAN_ACULUMADO;
                oHoja.Range["D" + (34 + celda_final).ToString()].Formula = INGENIERO_RESIDENTE_ACULUMADO;
                oHoja.Range["D" + (35 + celda_final).ToString()].Formula = INSPECTOR_DE_OBRA_ACULUMADO;
                oHoja.Range["D" + (36 + celda_final).ToString()].Formula = ASISTENTE_ADMINISTRATIVO_ACULUMADO;
                oHoja.Range["D" + (37 + celda_final).ToString()].Formula = ASISTENTE_TECNICO_ACULUMADO;
                oHoja.Range["D" + (38 + celda_final).ToString()].Formula = OPERADOR_DE_CAMIONETA_ACULUMADO;

                oHoja.Range["O" + (22 + celda_final).ToString()].Formula = MAESTRO_DE_OBRA_ACULUMADO + OPERARIO_ACULUMADO + OFICIAL_ACULUMADO + PEON_ACULUMADO + ALMACENERO_ACULUMADO + GUARDIAN_ACULUMADO;
                oHoja.Range["O" + (23 + celda_final).ToString()].Formula = INGENIERO_RESIDENTE_ACULUMADO + INSPECTOR_DE_OBRA_ACULUMADO + ASISTENTE_ADMINISTRATIVO_ACULUMADO + ASISTENTE_TECNICO_ACULUMADO + OPERADOR_DE_CAMIONETA_ACULUMADO;
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
                    if (dia + 1 == 1) { dia_celda = "F"; }
                    if (dia + 1 == 2) { dia_celda = "G"; }
                    if (dia + 1 == 3) { dia_celda = "H"; }
                    if (dia + 1 == 4) { dia_celda = "I"; }
                    if (dia + 1 == 5) { dia_celda = "J"; }
                    if (dia + 1 == 6) { dia_celda = "K"; }
                    if (dia + 1 == 7) { dia_celda = "L"; }
                    if (dia + 1 == 8) { dia_celda = "M"; }
                    if (dia + 1 == 9) { dia_celda = "N"; }
                    if (dia + 1 == 10) { dia_celda = "O"; }
                    if (dia + 1 == 11) { dia_celda = "P"; }
                    if (dia + 1 == 12) { dia_celda = "Q"; }
                    if (dia + 1 == 13) { dia_celda = "R"; }
                    if (dia + 1 == 14) { dia_celda = "S"; }
                    if (dia + 1 == 15) { dia_celda = "T"; }
                    if (dia + 1 == 16) { dia_celda = "U"; }
                    if (dia + 1 == 17) { dia_celda = "V"; }
                    if (dia + 1 == 18) { dia_celda = "W"; }
                    if (dia + 1 == 19) { dia_celda = "X"; }
                    if (dia + 1 == 20) { dia_celda = "Y"; }
                    if (dia + 1 == 21) { dia_celda = "Z"; }
                    if (dia + 1 == 22) { dia_celda = "AA"; }
                    if (dia + 1 == 23) { dia_celda = "AB"; }
                    if (dia + 1 == 24) { dia_celda = "AC"; }
                    if (dia + 1 == 25) { dia_celda = "AD"; }
                    if (dia + 1 == 26) { dia_celda = "AE"; }
                    if (dia + 1 == 27) { dia_celda = "AF"; }
                    if (dia + 1 == 28) { dia_celda = "AG"; }
                    if (dia + 1 == 29) { dia_celda = "AH"; }
                    if (dia + 1 == 30) { dia_celda = "AI"; }
                    if (dia + 1 == 31) { dia_celda = "AJ"; }

                    oHoja.Range[dia_celda + (celda_inicio).ToString()].Formula = Convert.ToString(Convert.ToDateTime((dia + 1).ToString() + "/" + mes + "/" + año).ToString("dddd")).Substring(0, 1).ToUpper();
                    oHoja.Range[dia_celda + (celda_inicio + 1).ToString()].Formula = dia + 1;
                }
            }
            catch (Exception e)
            {

            }
        }

        private void ImprimirHorasObrero()
        {
            try
            {
                int contadorobrero = 0;
                int celda_inicio = 11 + contadorobrero_general;
                double costo_dia = 8.5;
                double costo_sabado = 5.5;
                string costo_domingo = "";
                string dia_celda = "";
                string mes = "";
                string año = "";
                int nro_dias = 0;

                foreach (DataRow row in oImprimirTareo.Rows)
                {
                    contadorobrero += 1;
                    if (contadorobrero_general == 0)
                    {
                        if (contadorobrero < oImprimirTareo.Rows.Count)
                        {
                            oHoja.Range[(celda_inicio + 1 + contadorobrero).ToString() + ":" + (celda_inicio + 1 + contadorobrero).ToString()].Insert();
                        }
                    }
                    else
                    {
                        if (contadorobrero <= oImprimirTareo.Rows.Count)
                        {
                            oHoja.Range[(celda_inicio + contadorobrero).ToString() + ":" + (celda_inicio + contadorobrero).ToString()].Insert();
                        }
                    }

                    oHoja.Range["F5"].Formula = row[1].ToString();//META
                    oHoja.Range["F6"].Formula = row[2].ToString() + "-" + Convert.ToString(Convert.ToDateTime(row[8].ToString()).ToString("yyyy"));//NUMERO DE META
                    oHoja.Range["F7"].Formula = Convert.ToString(Convert.ToDateTime(row[8].ToString()).ToString("MMMM")).ToUpper() + " DEL " + Convert.ToString(Convert.ToDateTime(row[8].ToString()).ToString("yyyy"));//FECHA

                    oHoja.Range["A" + (celda_inicio + contadorobrero).ToString()].Formula = contadorobrero + contadorobrero_general;//NRO
                    oHoja.Range["B" + (celda_inicio + contadorobrero).ToString()].Formula = row[16].ToString() + " " + row[17].ToString() + ", " + row[15].ToString();//APELLIDSO Y NOMBRES
                    oHoja.Range["E" + (celda_inicio + contadorobrero).ToString()].Formula = row[11].ToString();//CATEGORIA

                    mes = Convert.ToDateTime(row[8].ToString()).Month.ToString();
                    año = Convert.ToDateTime(row[8].ToString()).Year.ToString();
                    nro_dias = DateTime.DaysInMonth(Convert.ToDateTime(row[8].ToString()).Year, Convert.ToDateTime(row[8].ToString()).Month);
                    for (int dia = 0; dia < nro_dias; dia++)
                    {
                        if (dia + 1 == 1) { dia_celda = "F"; }
                        if (dia + 1 == 2) { dia_celda = "G"; }
                        if (dia + 1 == 3) { dia_celda = "H"; }
                        if (dia + 1 == 4) { dia_celda = "I"; }
                        if (dia + 1 == 5) { dia_celda = "J"; }
                        if (dia + 1 == 6) { dia_celda = "K"; }
                        if (dia + 1 == 7) { dia_celda = "L"; }
                        if (dia + 1 == 8) { dia_celda = "M"; }
                        if (dia + 1 == 9) { dia_celda = "N"; }
                        if (dia + 1 == 10) { dia_celda = "O"; }
                        if (dia + 1 == 11) { dia_celda = "P"; }
                        if (dia + 1 == 12) { dia_celda = "Q"; }
                        if (dia + 1 == 13) { dia_celda = "R"; }
                        if (dia + 1 == 14) { dia_celda = "S"; }
                        if (dia + 1 == 15) { dia_celda = "T"; }
                        if (dia + 1 == 16) { dia_celda = "U"; }
                        if (dia + 1 == 17) { dia_celda = "V"; }
                        if (dia + 1 == 18) { dia_celda = "W"; }
                        if (dia + 1 == 19) { dia_celda = "X"; }
                        if (dia + 1 == 20) { dia_celda = "Y"; }
                        if (dia + 1 == 21) { dia_celda = "Z"; }
                        if (dia + 1 == 22) { dia_celda = "AA"; }
                        if (dia + 1 == 23) { dia_celda = "AB"; }
                        if (dia + 1 == 24) { dia_celda = "AC"; }
                        if (dia + 1 == 25) { dia_celda = "AD"; }
                        if (dia + 1 == 26) { dia_celda = "AE"; }
                        if (dia + 1 == 27) { dia_celda = "AF"; }
                        if (dia + 1 == 28) { dia_celda = "AG"; }
                        if (dia + 1 == 29) { dia_celda = "AH"; }
                        if (dia + 1 == 30) { dia_celda = "AI"; }
                        if (dia + 1 == 31) { dia_celda = "AJ"; }
                        if (row[12].ToString().Substring(dia, 1).ToUpper() == "X")
                        {
                            if (Convert.ToString(Convert.ToDateTime((dia + 1).ToString() + "/" + mes + "/" + año).ToString("dddd")).ToUpper() == "DOMINGO")
                            {
                                oHoja.Range[dia_celda + (celda_inicio + contadorobrero).ToString()].Formula = costo_domingo;
                            }
                            else if (Convert.ToString(Convert.ToDateTime((dia + 1).ToString() + "/" + mes + "/" + año).ToString("dddd")).ToUpper() == "SÁBADO")
                            {
                                oHoja.Range[dia_celda + (celda_inicio + contadorobrero).ToString()].Formula = costo_sabado;
                            }
                            else
                            {
                                oHoja.Range[dia_celda + (celda_inicio + contadorobrero).ToString()].Formula = costo_dia;
                            }
                        }
                    }
                    oHoja.Range["AK" + (celda_inicio + contadorobrero).ToString()].Formula = "--";
                    oHoja.Range["AL" + (celda_inicio + contadorobrero).ToString()].Formula = oExcel.WorksheetFunction.Sum(oHoja.Range["F" + (celda_inicio + contadorobrero).ToString() + ":AJ" + (celda_inicio + contadorobrero).ToString()]);
                }
                oHoja.Range["AL" + (celda_inicio + 1 + contadorobrero).ToString()].Formula = oExcel.WorksheetFunction.Sum(oHoja.Range["AL12:AL" + (celda_inicio + contadorobrero).ToString()]);
                contadorobrero_general += contadorobrero;
            }
            catch (Exception e)
            {

            }
        }

        private void ImprimirHorasTecnico()
        {
            try
            {
                int contadortecnico = 0;
                int celda_inicio = 0;
                double costo_dia = 8.5;
                double costo_sabado = 5.5;
                string costo_domingo = "";
                string dia_celda = "";
                string mes = "";
                string año = "";
                int nro_dias = 0;

                if (contadorobrero_general == 0) { celda_inicio = 14 + contadortecnico_general + contadorobrero_general; }
                else { celda_inicio = 14 + contadortecnico_general + contadorobrero_general - 1; }
                    
                foreach (DataRow row in oImprimirTareo.Rows)
                {
                    contadortecnico += 1;
                    if (contadortecnico_general == 0)
                    {
                        if (contadortecnico < oImprimirTareo.Rows.Count)
                        {
                            oHoja.Range[(celda_inicio + 1 + contadortecnico).ToString() + ":" + (celda_inicio + 1 + contadortecnico).ToString()].Insert();
                        }
                    }
                    else
                    {
                        if (contadortecnico <= oImprimirTareo.Rows.Count)
                        {
                            oHoja.Range[(celda_inicio + contadortecnico).ToString() + ":" + (celda_inicio + contadortecnico).ToString()].Insert();
                        }
                    }

                    oHoja.Range["F5"].Formula = row[1].ToString();//META
                    oHoja.Range["F6"].Formula = row[2].ToString() + "-" + Convert.ToString(Convert.ToDateTime(row[8].ToString()).ToString("yyyy"));//NUMERO DE META
                    oHoja.Range["F7"].Formula = Convert.ToString(Convert.ToDateTime(row[8].ToString()).ToString("MMMM")) + " DEL " + Convert.ToString(Convert.ToDateTime(row[8].ToString()).ToString("yyyy"));//FECHA

                    oHoja.Range["A" + (celda_inicio + contadortecnico).ToString()].Formula = contadortecnico + contadortecnico_general;//NRO
                    oHoja.Range["B" + (celda_inicio + contadortecnico).ToString()].Formula = row[16].ToString() + " " + row[17].ToString() + ", " + row[15].ToString();//APELLIDSO Y NOMBRES
                    oHoja.Range["E" + (celda_inicio + contadortecnico).ToString()].Formula = row[11].ToString();//CATEGORIA

                    mes = Convert.ToDateTime(row[8].ToString()).Month.ToString();
                    año = Convert.ToDateTime(row[8].ToString()).Year.ToString();
                    nro_dias = DateTime.DaysInMonth(Convert.ToDateTime(row[8].ToString()).Year, Convert.ToDateTime(row[8].ToString()).Month);
                    for (int dia = 0; dia < nro_dias; dia++)
                    {
                        if (dia + 1 == 1) { dia_celda = "F"; }
                        if (dia + 1 == 2) { dia_celda = "G"; }
                        if (dia + 1 == 3) { dia_celda = "H"; }
                        if (dia + 1 == 4) { dia_celda = "I"; }
                        if (dia + 1 == 5) { dia_celda = "J"; }
                        if (dia + 1 == 6) { dia_celda = "K"; }
                        if (dia + 1 == 7) { dia_celda = "L"; }
                        if (dia + 1 == 8) { dia_celda = "M"; }
                        if (dia + 1 == 9) { dia_celda = "N"; }
                        if (dia + 1 == 10) { dia_celda = "O"; }
                        if (dia + 1 == 11) { dia_celda = "P"; }
                        if (dia + 1 == 12) { dia_celda = "Q"; }
                        if (dia + 1 == 13) { dia_celda = "R"; }
                        if (dia + 1 == 14) { dia_celda = "S"; }
                        if (dia + 1 == 15) { dia_celda = "T"; }
                        if (dia + 1 == 16) { dia_celda = "U"; }
                        if (dia + 1 == 17) { dia_celda = "V"; }
                        if (dia + 1 == 18) { dia_celda = "W"; }
                        if (dia + 1 == 19) { dia_celda = "X"; }
                        if (dia + 1 == 20) { dia_celda = "Y"; }
                        if (dia + 1 == 21) { dia_celda = "Z"; }
                        if (dia + 1 == 22) { dia_celda = "AA"; }
                        if (dia + 1 == 23) { dia_celda = "AB"; }
                        if (dia + 1 == 24) { dia_celda = "AC"; }
                        if (dia + 1 == 25) { dia_celda = "AD"; }
                        if (dia + 1 == 26) { dia_celda = "AE"; }
                        if (dia + 1 == 27) { dia_celda = "AF"; }
                        if (dia + 1 == 28) { dia_celda = "AG"; }
                        if (dia + 1 == 29) { dia_celda = "AH"; }
                        if (dia + 1 == 30) { dia_celda = "AI"; }
                        if (dia + 1 == 31) { dia_celda = "AJ"; }
                        if (row[12].ToString().Substring(dia, 1).ToUpper() == "X")
                        {
                            if (Convert.ToString(Convert.ToDateTime((dia + 1).ToString() + "/" + mes + "/" + año).ToString("dddd")).ToUpper() == "DOMINGO")
                            {
                                oHoja.Range[dia_celda + (celda_inicio + contadortecnico).ToString()].Formula = costo_domingo;
                            }
                            else if (Convert.ToString(Convert.ToDateTime((dia + 1).ToString() + "/" + mes + "/" + año).ToString("dddd")).ToUpper() == "SÁBADO")
                            {
                                oHoja.Range[dia_celda + (celda_inicio + contadortecnico).ToString()].Formula = costo_sabado;
                            }
                            else
                            {
                                oHoja.Range[dia_celda + (celda_inicio + contadortecnico).ToString()].Formula = costo_dia;
                            }
                        }
                    }
                    oHoja.Range["AK" + (celda_inicio + contadortecnico).ToString()].Formula = "--";
                    oHoja.Range["AL" + (celda_inicio + contadortecnico).ToString()].Formula = oExcel.WorksheetFunction.Sum(oHoja.Range["F" + (celda_inicio + contadortecnico).ToString() + ":AJ" + (celda_inicio + contadortecnico).ToString()]);
                }
                oHoja.Range["AL" + (celda_inicio + 1 + contadortecnico).ToString()].Formula = oExcel.WorksheetFunction.Sum(oHoja.Range["AL" + (14 + contadorobrero_general).ToString() + ":AL" + (celda_inicio + contadortecnico).ToString()]);
                contadortecnico_general += contadortecnico;
            }
            catch (Exception e)
            {

            }
        }

        private void HorasCategoriaObrero()
        {
            try
            {
                foreach (DataRow row in oImprimirHorasActual.Rows)
                {
                    switch (row[3].ToString())
                    {
                        case "MAESTRO DE OBRA":
                            MAESTRO_DE_OBRA += Convert.ToDouble(row[4].ToString());
                            break;
                        case "OPERARIO":
                            OPERARIO += Convert.ToDouble(row[4].ToString());
                            break;
                        case "OFICIAL":
                            OFICIAL += Convert.ToDouble(row[4].ToString());
                            break;
                        case "PEON":
                            PEON += Convert.ToDouble(row[4].ToString());
                            break;
                        case "ALMACENERO":
                            ALMACENERO += Convert.ToDouble(row[4].ToString());
                            break;
                        case "GUARDIAN":
                            GUARDIAN += Convert.ToDouble(row[4].ToString());
                            break;
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        private void HorasCategoriaTecnico()
        {
            try
            {
                foreach (DataRow row in oImprimirHorasActual.Rows)
                {
                    string xx = row[3].ToString();
                    switch (row[3].ToString())
                    {
                        case "INGENIERO RESIDENTE":
                            INGENIERO_RESIDENTE += Convert.ToDouble(row[4].ToString());
                            break;
                        case "RESIDENTE":
                            INGENIERO_RESIDENTE += Convert.ToDouble(row[4].ToString());
                            break;
                        case "INSPECTOR DE OBRA":
                            INSPECTOR_DE_OBRA += Convert.ToDouble(row[4].ToString());
                            break;
                        case "ASISTENTE ADMINISTRATIVO":
                            ASISTENTE_ADMINISTRATIVO += Convert.ToDouble(row[4].ToString());
                            break;
                        case "ASISTENTE TECNICO":
                            ASISTENTE_TECNICO += Convert.ToDouble(row[4].ToString());
                            break;
                        case "OPERADOR DE CAMIONETA":
                            OPERADOR_DE_CAMIONETA += Convert.ToDouble(row[4].ToString());
                            break;
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        private void HorasCategoriaAcumulado()
        {
            try
            {
                foreach (DataRow row in oImprimirHorasAcumuladas.Rows)
                {
                    string xx = row[3].ToString();
                    switch (row[3].ToString())
                    {
                        case "INGENIERO RESIDENTE":
                            INGENIERO_RESIDENTE_ACULUMADO += Convert.ToDouble(row[4].ToString());
                            break;
                        case "RESIDENTE":
                            INGENIERO_RESIDENTE_ACULUMADO += Convert.ToDouble(row[4].ToString());
                            break;
                        case "INSPECTOR DE OBRA":
                            INSPECTOR_DE_OBRA_ACULUMADO += Convert.ToDouble(row[4].ToString());
                            break;
                        case "ASISTENTE ADMINISTRATIVO":
                            ASISTENTE_ADMINISTRATIVO_ACULUMADO += Convert.ToDouble(row[4].ToString());
                            break;
                        case "ASISTENTE TECNICO":
                            ASISTENTE_TECNICO_ACULUMADO += Convert.ToDouble(row[4].ToString());
                            break;
                        case "OPERADOR DE CAMIONETA":
                            OPERADOR_DE_CAMIONETA_ACULUMADO += Convert.ToDouble(row[4].ToString());
                            break;
                        case "MAESTRO DE OBRA":
                            MAESTRO_DE_OBRA_ACULUMADO += Convert.ToDouble(row[4].ToString());
                            break;
                        case "OPERARIO":
                            OPERARIO_ACULUMADO += Convert.ToDouble(row[4].ToString());
                            break;
                        case "OFICIAL":
                            OFICIAL_ACULUMADO += Convert.ToDouble(row[4].ToString());
                            break;
                        case "PEON":
                            PEON_ACULUMADO += Convert.ToDouble(row[4].ToString());
                            break;
                        case "ALMACENERO":
                            ALMACENERO_ACULUMADO += Convert.ToDouble(row[4].ToString());
                            break;
                        case "GUARDIAN":
                            GUARDIAN_ACULUMADO += Convert.ToDouble(row[4].ToString());
                            break;
                    }
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}
