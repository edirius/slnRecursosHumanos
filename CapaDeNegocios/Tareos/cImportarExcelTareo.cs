using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;


namespace CapaDeNegocios.Tareos
{
    public class cImportarExcelTareo
    {
        SpreadsheetLight.SLDocument miTareo;

        public cArchivoExcel Importar(string ruta, cArchivoExcel miExcel)
        {
            try
            {
                miTareo = new SpreadsheetLight.SLDocument(ruta);
                List<string> listaHojas = miTareo.GetWorksheetNames();
                bool encontrado = listaHojas.Any(s => s.Contains(miExcel.NombreHoja));
                //listaHojas.fin .Find(miExcel.NombreHoja);
                if (!encontrado)
                {
                    throw new Exception("No se encontro el nombre de hoja '"  + miExcel.NombreHoja + "' en el archivo ");
                }
                cArchivoExcel miNuevoExcel = new cArchivoExcel();

                miTareo = new SpreadsheetLight.SLDocument(ruta, miExcel.NombreHoja);
                
                for (int i = miExcel.InicioFila; i <= miExcel.FinFila; i++)
                {
                    cDetalleArchivoExcel oDetalle = new cDetalleArchivoExcel();
                    List<string> nombreReal = new List<string>();
                    nombreReal = SepararNombres(miExcel.TipoNombres, miTareo.GetCellValueAsString(miExcel.ColumnaNombres + i).Trim());
                    oDetalle.Nombres = nombreReal[0];
                    oDetalle.Apellidopaterno = nombreReal[1];
                    oDetalle.Apellidomaterno = nombreReal[2];
                    oDetalle.Cargo = miTareo.GetCellValueAsString(miExcel.ColumnaCargo + i).Trim().ToUpper();
                    oDetalle.Dni = miTareo.GetCellValueAsString(miExcel.ColumnaDNI + i).Trim();
                    string prueba = miTareo.GetCellValueAsString(miExcel.ColumnaDias + i);
                    oDetalle.Dias =  Convert.ToInt16(prueba);
                    miNuevoExcel.Detalles.Add(oDetalle);
                }

                return miNuevoExcel;
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el metodo Importar: cImportarExcelTareo " + ex.Message);
            }
        }

        public List<string> SepararNombres(enumTipoNombres enumTipo, string nombreCompleto)
        {
            string lolol = nombreCompleto.Replace( ','.ToString(), String.Empty);
            nombreCompleto = nombreCompleto.Replace(','.ToString(), String.Empty);
            List<string> nombreReal = new List<string>();
            string[] nombres;

            string nombre = "";
            string apellidoPaterno;
            string apellidoMaterno;

            switch (enumTipo)
            {
                case enumTipoNombres.primeroNombres:
                    nombres = nombreCompleto.Split(new char[0]);

                    

                    switch (nombres.Length)
                    {
                        case 4:
                            nombre = nombres[0] + " " + nombres[1];
                            apellidoPaterno = nombres[2];
                            apellidoMaterno = nombres[3];

                            nombreReal.Add(nombre);
                            nombreReal.Add(apellidoPaterno);
                            nombreReal.Add(apellidoMaterno);
                            break;
                        case 3:
                            nombre = nombres[0];
                            apellidoPaterno = nombres[1];
                            apellidoMaterno = nombres[2];

                            nombreReal.Add(nombre);
                            nombreReal.Add(apellidoPaterno);
                            nombreReal.Add(apellidoMaterno);
                            break;
                        case 2:
                            nombre = nombres[0];
                            apellidoPaterno = nombres[1];
                            apellidoMaterno = "";

                            nombreReal.Add(nombre);
                            nombreReal.Add(apellidoPaterno);
                            nombreReal.Add(apellidoMaterno);
                            break;
                        case 5:  case 6: case 7:
                            nombre = nombres[0] + nombres[1];
                            apellidoPaterno = nombres[2];
                            apellidoMaterno = nombres[3];

                            nombreReal.Add(nombre);
                            nombreReal.Add(apellidoPaterno);
                            nombreReal.Add(apellidoMaterno);
                            break;

                        default:
                            break;
                    }
                    break;
                case enumTipoNombres.primeroApellidos:
                    nombres = nombreCompleto.Split(new char[0]);

                    switch (nombres.Length)
                    {
                        case 4:
                            apellidoPaterno = nombres[0];
                            apellidoMaterno = nombres[1];
                            nombre = nombres[2] + " " + nombres[3];

                            nombreReal.Add(nombre);
                            nombreReal.Add(apellidoPaterno);
                            nombreReal.Add(apellidoMaterno);
                            break;
                        case 3:
                            apellidoPaterno = nombres[0];
                            apellidoMaterno = nombres[1];
                            nombre = nombres[2];

                            nombreReal.Add(nombre);
                            nombreReal.Add(apellidoPaterno);
                            nombreReal.Add(apellidoMaterno);
                            break;
                        case 2:
                            apellidoPaterno = nombres[0];
                            apellidoMaterno = "";
                            nombre = nombres[1];

                            nombreReal.Add(nombre);
                            nombreReal.Add(apellidoPaterno);
                            nombreReal.Add(apellidoMaterno);
                            break;
                        case 5:
                        case 6:
                        case 7:
                            apellidoPaterno = nombres[0];
                            apellidoMaterno = nombres[1];
                            nombre = nombres[2] + nombres[3];

                            nombreReal.Add(nombre);
                            nombreReal.Add(apellidoPaterno);
                            nombreReal.Add(apellidoMaterno);
                            break;

                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            return nombreReal;
        }
    }
}
