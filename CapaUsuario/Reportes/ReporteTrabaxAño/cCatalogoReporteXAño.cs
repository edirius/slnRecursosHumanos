using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios;
using CapaDeDatos;
using System.Data;
using SpreadsheetLight;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;

namespace CapaUsuario.Reportes.ReporteTrabaxAño
{
    public class cCatalogoReporteXAño
    {
        CapaDeNegocios.Utilidades.cUtilidades util = new CapaDeNegocios.Utilidades.cUtilidades();
        public cReporteTrabajadoresXAño LLenarReporteXAño (int año)
        {
            DataTable oTabla = Conexion.GDatos.TraerDataTable("spReporteTrabajadoresXAño", año);
            int codigoTrabajadorTemporal = 0;
            cReporteTrabajadoresXAño Reporte = new cReporteTrabajadoresXAño();

            int contador = 0;
            foreach (DataRow item in oTabla.Rows)
            {
                
                //Significa que sigue el trabajador
                if (Convert.ToInt32(item[0]) == codigoTrabajadorTemporal)
                {
                    cDetallesReporteTrabajadores det = Reporte.Detalles.Find(a => a.Codigo == codigoTrabajadorTemporal);
                    cDetalleMeses meses = new cDetalleMeses();
                    meses.Cargo = item[5].ToString();
                    meses.Mes = new DateTime(año, util.ConvertirMesANumero(item[6].ToString()), 1);
                    meses.DiasLaborados = Convert.ToInt16(item[7]);
                    det.Meses.Add(meses);
                }
                else
                {
                    contador++;
                    cDetallesReporteTrabajadores detalle = new cDetallesReporteTrabajadores();
                    detalle.NumeroOrden = contador;
                    detalle.Codigo = Convert.ToInt32(item[0]);
                    detalle.DNI = item[4].ToString();
                    detalle.Nombres = item[1].ToString();
                    detalle.ApellidoPaterno = item[2].ToString();
                    detalle.ApellidoMaterno = item[3].ToString();
                    cDetalleMeses meses = new cDetalleMeses();
                    meses.Cargo = item[5].ToString();
                    meses.Mes = new DateTime(año, util.ConvertirMesANumero(item[6].ToString()), 1);
                    meses.DiasLaborados = Convert.ToInt16(item[7]);
                    detalle.Meses.Add(meses);

                    Reporte.Detalles.Add(detalle);
                    codigoTrabajadorTemporal = detalle.Codigo;
                }
            }
            return Reporte;
        }

        public void ImprimirExcelTrabajadoresXAño(cReporteTrabajadoresXAño oReporte, int año, string ruta)
        {
            try
            {
                SpreadsheetLight.SLDocument miReporte;

                miReporte = new SpreadsheetLight.SLDocument();
                miReporte.SetCellValue("A1", "REPORTE TRABAJADORES DEL AÑO " + año);
                miReporte.MergeWorksheetCells("A1", "Q1");


                SLStyle estiloTituloReporte = new SLStyle();
                estiloTituloReporte.SetFontBold(true);
                estiloTituloReporte.SetHorizontalAlignment(HorizontalAlignmentValues.Center);
                miReporte.SetCellStyle("A1", estiloTituloReporte);
                
                SLStyle estiloTitulo = new SLStyle();
                estiloTitulo.SetPatternFill(PatternValues.Solid, System.Drawing.Color.LightGray, System.Drawing.Color.LightGray);
                estiloTitulo.SetBottomBorder(BorderStyleValues.Thin, SLThemeColorIndexValues.Dark1Color);
                estiloTitulo.SetTopBorder(BorderStyleValues.Thin, SLThemeColorIndexValues.Dark1Color);
                estiloTitulo.SetRightBorder(BorderStyleValues.Thin, SLThemeColorIndexValues.Dark1Color);
                estiloTitulo.SetLeftBorder(BorderStyleValues.Thin, SLThemeColorIndexValues.Dark1Color);

                miReporte.SetCellValue("A3", "Nº");
                miReporte.SetCellStyle("A3", estiloTitulo);
                miReporte.SetColumnWidth("A", 3.5);
                miReporte.SetCellValue("B3", "DNI");
                miReporte.SetCellStyle("B3", estiloTitulo);
                miReporte.SetColumnWidth("B", 9);
                miReporte.SetCellValue("C3", "Nombres");
                miReporte.SetCellStyle("C3", estiloTitulo);
                miReporte.SetColumnWidth("C", 22);
                miReporte.SetCellValue("D3", "Apellido Paterno");
                miReporte.SetCellStyle("D3", estiloTitulo);
                miReporte.SetColumnWidth("D", 22);
                miReporte.SetCellValue("E3", "Apellido Materno");
                miReporte.SetCellStyle("E3", estiloTitulo);
                miReporte.SetColumnWidth("E", 22);
                miReporte.SetCellValue("F3", "ENERO");
                miReporte.SetCellStyle("F3", estiloTitulo);
                miReporte.SetColumnWidth("F", 20);
                miReporte.SetCellValue("G3", "FEBRERO");
                miReporte.SetCellStyle("G3", estiloTitulo);
                miReporte.SetColumnWidth("G", 20);
                miReporte.SetCellValue("H3", "MARZO");
                miReporte.SetCellStyle("H3", estiloTitulo);
                miReporte.SetColumnWidth("H", 20);
                miReporte.SetCellValue("I3", "ABRIL");
                miReporte.SetCellStyle("I3", estiloTitulo);
                miReporte.SetColumnWidth("I", 20);
                miReporte.SetCellValue("J3", "MAYO");
                miReporte.SetCellStyle("J3", estiloTitulo);
                miReporte.SetColumnWidth("J", 20);
                miReporte.SetCellValue("K3", "JUNIO");
                miReporte.SetCellStyle("K3", estiloTitulo);
                miReporte.SetColumnWidth("K", 20);
                miReporte.SetCellValue("L3", "JULIO");
                miReporte.SetCellStyle("L3", estiloTitulo);
                miReporte.SetColumnWidth("L", 20);
                miReporte.SetCellValue("M3", "AGOSTO");
                miReporte.SetCellStyle("M3", estiloTitulo);
                miReporte.SetColumnWidth("M", 20);
                miReporte.SetCellValue("N3", "SETIEMBRE");
                miReporte.SetCellStyle("N3", estiloTitulo);
                miReporte.SetColumnWidth("N", 20);
                miReporte.SetCellValue("O3", "OCTUBRE");
                miReporte.SetCellStyle("O3", estiloTitulo);
                miReporte.SetColumnWidth("O", 20);
                miReporte.SetCellValue("P3", "NOVIEMBRE");
                miReporte.SetCellStyle("P3", estiloTitulo);
                miReporte.SetColumnWidth("P", 20);
                miReporte.SetCellValue("Q3", "DICIEMBRE");
                miReporte.SetCellStyle("Q3", estiloTitulo);
                miReporte.SetColumnWidth("Q", 20);
                foreach (cDetallesReporteTrabajadores item in oReporte.Detalles)
                {
                    miReporte.SetCellValue("A" + (3 + item.NumeroOrden), item.NumeroOrden);
                    miReporte.SetCellValue("B" + (3 + item.NumeroOrden), item.DNI);
                    miReporte.SetCellValue("C" + (3 + item.NumeroOrden), item.Nombres);
                    miReporte.SetCellValue("D" + (3 + item.NumeroOrden), item.ApellidoPaterno);
                    miReporte.SetCellValue("E" + (3 + item.NumeroOrden), item.ApellidoMaterno);

                    foreach (cDetalleMeses item2 in item.Meses)
                    {
                        switch (item2.Mes.Month)
                        {
                            case 1:
                                miReporte.SetCellValue("F" + (3 + item.NumeroOrden), item2.Cargo + Environment.NewLine +  item2.DiasLaborados) ;
                                break;
                            case 2:
                                miReporte.SetCellValue("G" + (3 + item.NumeroOrden), item2.Cargo + Environment.NewLine + item2.DiasLaborados);
                                break;
                            case 3:
                                miReporte.SetCellValue("H" + (3 + item.NumeroOrden), item2.Cargo + Environment.NewLine + item2.DiasLaborados);
                                break;
                            case 4:
                                miReporte.SetCellValue("I" + (3 + item.NumeroOrden), item2.Cargo + Environment.NewLine + item2.DiasLaborados);
                                break;
                            case 5:
                                miReporte.SetCellValue("J" + (3 + item.NumeroOrden), item2.Cargo + Environment.NewLine + item2.DiasLaborados);
                                break;
                            case 6:
                                miReporte.SetCellValue("K" + (3 + item.NumeroOrden), item2.Cargo + Environment.NewLine + item2.DiasLaborados);
                                break;
                            case 7:
                                miReporte.SetCellValue("L" + (3 + item.NumeroOrden), item2.Cargo + Environment.NewLine + item2.DiasLaborados);
                                break;
                            case 8:
                                miReporte.SetCellValue("M" + (3 + item.NumeroOrden), item2.Cargo + Environment.NewLine + item2.DiasLaborados);
                                break;
                            case 9:
                                miReporte.SetCellValue("N" + (3 + item.NumeroOrden), item2.Cargo + Environment.NewLine + item2.DiasLaborados);
                                break;
                            case 10:
                                miReporte.SetCellValue("O" + (3 + item.NumeroOrden), item2.Cargo + Environment.NewLine + item2.DiasLaborados);
                                break;
                            case 11:
                                miReporte.SetCellValue("P" + (3 + item.NumeroOrden), item2.Cargo + Environment.NewLine + item2.DiasLaborados);
                                break;
                            case 12:
                                miReporte.SetCellValue("Q" + (3 + item.NumeroOrden), item2.Cargo + Environment.NewLine + item2.DiasLaborados);
                                break;
                            default:
                                break;
                        }
                    }
                }
                //_excel.Quit();
                miReporte.SaveAs(ruta);

            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo ImprimirExcelTrabajadoresXAño: cCatalogoReporteXAño " + ex.Message);
            }
        }
    }
}
