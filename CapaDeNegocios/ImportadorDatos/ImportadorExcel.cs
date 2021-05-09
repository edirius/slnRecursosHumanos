using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using miExcel = Microsoft.Office.Interop.Excel;

namespace CapaDeNegocios.ImportadorDatos
{
    public class ImportadorExcel
    {
        string RutaExcel;

        private Microsoft.Office.Interop.Excel.Application oExcel;
        private object oMissing;
        private Microsoft.Office.Interop.Excel.Workbook oLibro;
        private Microsoft.Office.Interop.Excel.Worksheet oHoja;

        public List<archivoImportador> Nombres;

        public ImportadorExcel(string rutaarchivo)
        {
            try
            {
                RutaExcel = rutaarchivo;
                if (File.Exists(RutaExcel))
                {
                    oExcel = new Microsoft.Office.Interop.Excel.Application(); ;
                    oMissing = System.Reflection.Missing.Value;
                    oLibro = oExcel.Workbooks.Add(RutaExcel);
                    oHoja = (Microsoft.Office.Interop.Excel.Worksheet)oExcel.ActiveSheet;
                    oExcel.Visible = true;
                    Nombres = new List<archivoImportador>();
                }
                else
                {
                    throw new Exception("El archivo no se encuentra: " + RutaExcel);
                }
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al abrir archivo excel: ImportadorExcel.cs : " + ex.Message);
            }
          
        }

        public bool ImportarDatosBasicos()
        {
            try
            {
                int filaInicioBusqueda = 14;
                 
                if (oHoja != null)
                {
                    var valorCelda = (string)(oHoja.Cells[filaInicioBusqueda, 2] as Microsoft.Office.Interop.Excel.Range).Value;
                    while (!(valorCelda == "") && !(valorCelda == null))
                    {
                        
                        archivoImportador nombre = new archivoImportador();
                        nombre.Dni = valorCelda;
                        nombre.Nombres = (string)(oHoja.Cells[filaInicioBusqueda, 3] as Microsoft.Office.Interop.Excel.Range).Value;
                        nombre.ApellidoPaterno = (string)(oHoja.Cells[filaInicioBusqueda, 4] as Microsoft.Office.Interop.Excel.Range).Value;
                        nombre.ApellidoMaterno = (string)(oHoja.Cells[filaInicioBusqueda, 5] as Microsoft.Office.Interop.Excel.Range).Value;
                        if ((string)(oHoja.Cells[filaInicioBusqueda, 6] as Microsoft.Office.Interop.Excel.Range).Value == "ACTIVO o SUBSIDIADO")
                        {
                            nombre.Activo = true;
                        }
                        else
                        {
                            nombre.Activo = false;
                        }
                       
                        filaInicioBusqueda += 1;
                        valorCelda = (string)(oHoja.Cells[filaInicioBusqueda, 2] as Microsoft.Office.Interop.Excel.Range).Value;
                        Nombres.Add(nombre);
                    }
                }
                else
                {
                    throw new cReglaNegociosException("Error al abrir la hoja del archivo excel:  " + RutaExcel);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al importar datos Excel: ImportadorExcel.cs : " + ex.Message);
            }
        }


    }
}
