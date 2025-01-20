using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;

namespace CapaDeNegocios.Asistencia.ImportarPapeleta
{
    
    public class cImportarExcelPapeleta
    {
        SpreadsheetLight.SLDocument miPapeleta;

        SpreadsheetLight.SLDocument miHoja;

        public CapaDeNegocios.Asistencia.cExcepcionesAsistencia ImportarExcel(string ruta, cArchivoExcelPapeleta miExcel )
        {
            try
            {
                miPapeleta = new SpreadsheetLight.SLDocument(ruta);
                List<string> listaHojas = miPapeleta.GetWorksheetNames();
                bool encontrado = listaHojas.Any(s => s.Contains(miExcel.NombreHoja));
                //listaHojas.fin .Find(miExcel.NombreHoja);
                if (!encontrado)
                {
                    throw new Exception("No se encontro el nombre de hoja '" + miExcel.NombreHoja + "' en el archivo ");
                }
                cExcepcionesAsistencia miNuevoExcel = new cExcepcionesAsistencia();

                miPapeleta = new SpreadsheetLight.SLDocument(ruta, miExcel.NombreHoja);

                miNuevoExcel.Aprobado = true;
                miNuevoExcel.Comentario = miPapeleta.GetCellValueAsString("D" + miExcel.FilaInicioJustificacion).Trim().ToUpper() + " " +
                    miPapeleta.GetCellValueAsString("D" + miExcel.FilaFinJustificacion).Trim().ToUpper();
                miNuevoExcel.InicioExcepcion = miPapeleta.GetCellValueAsDateTime("F11").AddHours(miPapeleta.GetCellValueAsDateTime("H11").Hour).AddMinutes(miPapeleta.GetCellValueAsDateTime("H11").Minute);
                miNuevoExcel.FinExcepcion = miPapeleta.GetCellValueAsDateTime("F12").AddHours(miPapeleta.GetCellValueAsDateTime("H12").Hour).AddMinutes(miPapeleta.GetCellValueAsDateTime("H12").Minute);

                if (miPapeleta.GetCellValueAsString("A"+ miExcel.FilaDescansoMedico).Trim().ToUpper() == "X")
                {
                    miNuevoExcel.Tipo = "DESCANSO MEDICO";
                }
                return miNuevoExcel;

            }
            catch (Exception ex)
            {
                throw new Exception("Error en el metodo Importar: cImportarExcelPapeleta " + ex.Message);
            }
        }
    }
}
