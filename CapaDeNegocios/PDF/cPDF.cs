using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using CapaDeNegocios.PlanillaNueva;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp;
using System.IO;
using System.Globalization;

namespace CapaDeNegocios.PDF
{
    public class cPDF
    {
        protected virtual bool IsFileinUse(FileInfo file, string path)
        {
            FileStream stream = null;

            if (!File.Exists(path))
            {
                return false;
            }
            else
            {
                try
                {
                    stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);

                }
                catch (IOException)
                {
                    //the file is unavailable because it is:
                    //still being written to
                    //or being processed by another thread
                    //or does not exist (has already been processed)
                    return true;

                }
                finally
                {
                    if (stream != null)
                        stream.Close();
                }
                return false;
            }
        }

        public void ImprimirPlanilla(cnPlanilla miPLanilla)
        {
            FileInfo file = new FileInfo("C:\\PDFs\\DeclaracionJurada.pdf");
            bool estaAbierto = IsFileinUse(file, "C:\\PDFs\\DeclaracionJurada.pdf");

         
            blPlanilla oblPlanilla = new blPlanilla();
            Document doc = new Document(PageSize.A4, 9, 9, 40, 30);
            doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());

           

            PdfWriter writer = PdfWriter.GetInstance(doc,
                            new FileStream(@"c:\PDFs\listaTrabajadores.pdf", FileMode.Create));

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Planilla" + miPLanilla.Descripcion);
            doc.AddCreator("EDIRIUS SOFT");

            // Abrimos el archivo
            doc.Open();


            // Creamos el tipo de Font que vamos utilizar
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 7f, iTextSharp.text.Font.NORMAL, Color.BLACK);

          

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable tblPrueba = new PdfPTable(16);
            float[] Ancho = new float[16];
            Ancho[0] = 10;
            Ancho[1] = 60;
            Ancho[2] = 50;
            Ancho[3] = 50;
            Ancho[4] = 20;
            Ancho[5] = 20;
            Ancho[6] = 20;
            Ancho[7] = 20;
            Ancho[8] = 20;
            Ancho[9] = 20;
            Ancho[10] = 20;
            Ancho[11] = 20;
            Ancho[12] = 20;
            Ancho[13] = 20;
            Ancho[14] = 10;
            Ancho[15] = 80;
            //tblPrueba.SetWidths(Ancho );
            tblPrueba.WidthPercentage = 100;

            iTextSharp.text.Color colorTitulos = new Color(240, 240, 240);

            // Configuramos el título de las columnas de la tabla
            PdfPCell clNumero = new PdfPCell(new Phrase("N°", _standardFont));
            clNumero.HorizontalAlignment = Element.ALIGN_LEFT;
            clNumero.BackgroundColor = colorTitulos;
            clNumero.BorderWidthBottom = 0.75f;

            PdfPCell clNombre = new PdfPCell(new Phrase("NOMBRE COMPLETO", _standardFont));
            clNombre.HorizontalAlignment = Element.ALIGN_LEFT;
            clNombre.BackgroundColor = colorTitulos;
            clNombre.BorderWidthBottom = 0.75f;

            PdfPCell clApellido = new PdfPCell(new Phrase("CARGO", _standardFont));
            clApellido.HorizontalAlignment = Element.ALIGN_CENTER;
            clApellido.BackgroundColor = colorTitulos;
            clApellido.BorderWidthBottom = 0.75f;

            PdfPCell clFechaInicio = new PdfPCell(new Phrase("FECHA INICIO", _standardFont));
            clFechaInicio.HorizontalAlignment = Element.ALIGN_CENTER;
            clFechaInicio.BackgroundColor = colorTitulos;
            clFechaInicio.BorderWidthBottom = 0.75f;

            PdfPCell clSecuenciaFuncional = new PdfPCell(new Phrase("Sec. \n\n Func.", _standardFont));
            clSecuenciaFuncional.HorizontalAlignment = Element.ALIGN_CENTER;
            clSecuenciaFuncional.BackgroundColor = colorTitulos;
            clSecuenciaFuncional.BorderWidthBottom = 0.75f;

            PdfPCell clsnp = new PdfPCell(new Phrase("AFIL. AFP/SNP \n\n COMISION \n\n CUSP ", _standardFont));
            clsnp.HorizontalAlignment = Element.ALIGN_CENTER;
            clsnp.BackgroundColor = colorTitulos;
            clsnp.BorderWidthBottom = 0.75f;

            
            string celda = "";
            for (int j = 0; j < miPLanilla.ListaDetalle[0].ListaDetalleIngresos.Count; j++)
            {

                celda = celda + miPLanilla.ListaDetalle[0].ListaDetalleIngresos[j].MaestroIngresos.Abreviacion + "\n \n";

                
            }

            PdfPCell clNumeroIngresos = new PdfPCell(new Phrase(celda,_standardFont));
            clNumeroIngresos.HorizontalAlignment = Element.ALIGN_RIGHT;
            clNumeroIngresos.BackgroundColor = colorTitulos;
            clNumeroIngresos.BorderWidthBottom = 0.75f;

            
            PdfPCell clTotalIngresos = new PdfPCell(new Phrase("Total \n \n Ingresos",_standardFont));
            clTotalIngresos.HorizontalAlignment = Element.ALIGN_CENTER;
            clTotalIngresos.BackgroundColor = colorTitulos;
            clTotalIngresos.BorderWidthBottom = 0.75f;

            string tituloAportaciones = "";
            for (int j = 0; j < miPLanilla.ListaDetalle[0].ListaDetalleAportacionesTrabajador.Count; j++)
            {

                tituloAportaciones  = tituloAportaciones  + miPLanilla.ListaDetalle[0].ListaDetalleAportacionesTrabajador[j].MaestroAportacionTrabajador.Abreviacion + "\n \n";


            }

            PdfPCell clAportaciones = new PdfPCell(new Phrase(tituloAportaciones, _standardFont));
            clAportaciones.HorizontalAlignment = Element.ALIGN_CENTER;
            clAportaciones.BackgroundColor = colorTitulos;
            clAportaciones.BorderWidthBottom = 0.75f;

            PdfPCell clTotalAPortacionesTrabajador = new PdfPCell(new Phrase("Total \n \n Aportaciones \n \n Trabajador", _standardFont));
            clTotalAPortacionesTrabajador.HorizontalAlignment = Element.ALIGN_RIGHT;
            clTotalAPortacionesTrabajador.BackgroundColor = colorTitulos;
            clTotalAPortacionesTrabajador.BorderWidthBottom = 0.75f;

            PdfPCell clTotalAFP = new PdfPCell(new Phrase("Total AFP", _standardFont));
            clTotalAFP.HorizontalAlignment = Element.ALIGN_CENTER;
            clTotalAFP.BackgroundColor = colorTitulos;
            clTotalAFP.BorderWidthBottom = 0.75f;

            string tituloAportacionesEmpleador = "";
            for (int i = 0; i < miPLanilla.ListaDetalle[0].ListaDetalleAportacionesEmpleador.Count ; i++)
            {
                tituloAportacionesEmpleador = tituloAportacionesEmpleador + miPLanilla.ListaDetalle[0].ListaDetalleAportacionesEmpleador[i].MaestroAportacionesEmpleador.Abreviacion + "\n \n";
            }

            PdfPCell clAportacionesEmpleador = new PdfPCell(new Phrase(tituloAportacionesEmpleador, _standardFont));
            clAportacionesEmpleador.HorizontalAlignment = Element.ALIGN_CENTER;
            clAportacionesEmpleador.BackgroundColor = colorTitulos;
            clAportacionesEmpleador.BorderWidthBottom = 0.75f;

            PdfPCell clTotalAportacionesEmpleador = new PdfPCell(new Phrase("Total Aportaciones", _standardFont));
            clTotalAportacionesEmpleador.HorizontalAlignment = Element.ALIGN_CENTER;
            clTotalAportacionesEmpleador.BackgroundColor = colorTitulos;
            clTotalAportacionesEmpleador.BorderWidthBottom = 0.75f;

            PdfPCell clNetoACobrar = new PdfPCell(new Phrase("NETO A COBRAR", _standardFont));
            clNetoACobrar.HorizontalAlignment = Element.ALIGN_CENTER;
            clNetoACobrar.BackgroundColor = colorTitulos;
            clNetoACobrar.BorderWidthBottom = 0.75F;

            PdfPCell clDias = new PdfPCell(new Phrase("Dias Laborados", _standardFont));
            clDias.HorizontalAlignment = Element.ALIGN_CENTER;
            clDias.BackgroundColor = colorTitulos;
            clNetoACobrar.BorderWidthBottom = 0.75f;

            PdfPCell clFirma = new PdfPCell(new Phrase("Firma", _standardFont));
            clFirma.HorizontalAlignment = Element.ALIGN_CENTER;
            clFirma.BackgroundColor = colorTitulos;
            clFirma.BorderWidthBottom = 0.75f;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clNumero);
            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clApellido);

            tblPrueba.AddCell(clFechaInicio);
            tblPrueba.AddCell(clSecuenciaFuncional);
            tblPrueba.AddCell(clsnp);
            tblPrueba.AddCell(clNumeroIngresos);
            tblPrueba.AddCell(clTotalIngresos);
            tblPrueba.AddCell(clAportaciones);
            tblPrueba.AddCell(clTotalAPortacionesTrabajador);
            tblPrueba.AddCell(clTotalAFP);
            tblPrueba.AddCell(clAportacionesEmpleador);
            tblPrueba.AddCell(clTotalAportacionesEmpleador);
            tblPrueba.AddCell(clNetoACobrar);
            tblPrueba.AddCell(clDias);
            tblPrueba.AddCell(clFirma);
            tblPrueba.SetWidths(Ancho);

            cnDetallePlanilla ListaTotales = new cnDetallePlanilla();
            ListaTotales = oblPlanilla.ListaTotales(miPLanilla);
            double profuturo = 0;
            double prima = 0;
            double habitat = 0;
            double integra = 0;
            double snp = 0;
            double totalIngresos = 0;
            double totalAportacionesEmpleador = 0;
            double totalAportacionesTrabajador = 0;
            double totalAFP = 0;
            double totalNetoACobrar = 0;
            double totalEssaludRiesgo = 0;
            double totalEssalud = 0;
            for (int i = 0; i < miPLanilla.ListaDetalle.Count + 1;i ++)
            {
                if (i < miPLanilla.ListaDetalle.Count)
                {


                    clNumero = new PdfPCell(new Phrase(miPLanilla.ListaDetalle[i].numero.ToString(), _standardFont));
                    clNumero.HorizontalAlignment = Element.ALIGN_CENTER;
                    tblPrueba.AddCell(clNumero);

                    clNumero = new PdfPCell(new Phrase(miPLanilla.ListaDetalle[i].miTrabajador.Nombres + ", " + miPLanilla.ListaDetalle[i].miTrabajador.ApellidoPaterno + " " + miPLanilla.ListaDetalle[i].miTrabajador.ApellidoMaterno, _standardFont));
                    clNumero.HorizontalAlignment = Element.ALIGN_LEFT;
                    tblPrueba.AddCell(clNumero);

                    clNumero = new PdfPCell(new Phrase(miPLanilla.ListaDetalle[i].cargo, _standardFont));
                    clNumero.HorizontalAlignment = Element.ALIGN_CENTER;
                    tblPrueba.AddCell(clNumero);

                    clNumero = new PdfPCell(new Phrase(miPLanilla.ListaDetalle[i].fechaInicio.ToShortDateString(), _standardFont));
                    clNumero.HorizontalAlignment = Element.ALIGN_CENTER;
                    tblPrueba.AddCell(clNumero);

                    clNumero = new PdfPCell(new Phrase(miPLanilla.Meta.Numero.ToString(), _standardFont));
                    clNumero.HorizontalAlignment = Element.ALIGN_CENTER;
                    tblPrueba.AddCell(clNumero);

                    clNumero = new PdfPCell(new Phrase(miPLanilla.ListaDetalle[i].miTrabajador.ListaRegimenPensionario[0].MiAFP.Nombre + "\n \n" + miPLanilla.ListaDetalle[i].miTrabajador.ListaRegimenPensionario[0].Cuspp + "\n \n" + miPLanilla.ListaDetalle[i].miTrabajador.ListaRegimenPensionario[0].TipoComision, _standardFont));
                    clNumero.HorizontalAlignment = Element.ALIGN_CENTER;
                    tblPrueba.AddCell(clNumero);


                    celda = "";
                     totalIngresos = 0;

                    for (int j = 0; j < miPLanilla.ListaDetalle[i].ListaDetalleIngresos.Count; j++)
                    {

                        celda = celda + miPLanilla.ListaDetalle[i].ListaDetalleIngresos[j].Monto.ToString("0.00", CultureInfo.InvariantCulture) + "\n \n";
                        totalIngresos = totalIngresos + miPLanilla.ListaDetalle[i].ListaDetalleIngresos[j].Monto;


                    }

                    clNumero = new PdfPCell(new Phrase(celda, _standardFont));
                    clNumero.HorizontalAlignment = Element.ALIGN_RIGHT;
                    tblPrueba.AddCell(clNumero);

                    clNumero = new PdfPCell(new Phrase(totalIngresos.ToString("0.00", CultureInfo.InvariantCulture), _standardFont));
                    clNumero.HorizontalAlignment = Element.ALIGN_RIGHT;
                    tblPrueba.AddCell(clNumero);

                    celda = "";
                    totalAportacionesTrabajador = 0;
                    totalAFP = 0;
                    

                    for (int k = 0; k < miPLanilla.ListaDetalle[i].ListaDetalleAportacionesTrabajador.Count; k++)
                    {
                        celda = celda + miPLanilla.ListaDetalle[i].ListaDetalleAportacionesTrabajador[k].Monto.ToString("0.00", CultureInfo.InvariantCulture) + "\n \n";
                        totalAportacionesTrabajador = totalAportacionesTrabajador + miPLanilla.ListaDetalle[i].ListaDetalleAportacionesTrabajador[k].Monto;
                        switch (miPLanilla.ListaDetalle[i].ListaDetalleAportacionesTrabajador[k].MaestroAportacionTrabajador.Codigo)
                        {
                            case "0606":
                            case "0608":
                            case "0601":
                            case "9998":
                                totalAFP = totalAFP + miPLanilla.ListaDetalle[i].ListaDetalleAportacionesTrabajador[k].Monto;

                                break;
                            case "0607":
                                snp += miPLanilla.ListaDetalle[i].ListaDetalleAportacionesTrabajador[k].Monto;
                                break;
                            default:
                                break;
                        }
                    }

                    switch (miPLanilla.ListaDetalle[i].miTrabajador.ListaRegimenPensionario[0].MiAFP.Nombre)
                    {
                        case "PROFUTURO":
                            profuturo += totalAFP;
                                break;
                        case "PRIMA":
                            prima += totalAFP;
                            break;
                        case "HABITAT":
                            habitat += totalAFP;
                            break;
                        case "INTEGRA":
                            integra += totalAFP;
                            break;
                        case "SNP":
                            snp += totalAFP;
                            break;
                            default:
                            break;
                    }

                    clNumero = new PdfPCell(new Phrase(celda, _standardFont));
                    clNumero.HorizontalAlignment = Element.ALIGN_RIGHT;
                    tblPrueba.AddCell(clNumero);

                    clNumero = new PdfPCell(new Phrase(totalAportacionesTrabajador.ToString("0.00", CultureInfo.InvariantCulture), _standardFont));
                    clNumero.HorizontalAlignment = Element.ALIGN_RIGHT;
                    tblPrueba.AddCell(clNumero);

                    clNumero = new PdfPCell(new Phrase(totalAFP.ToString("0.00", CultureInfo.InvariantCulture), _standardFont));
                    clNumero.HorizontalAlignment = Element.ALIGN_RIGHT;
                    tblPrueba.AddCell(clNumero);

                    celda = "";
                    totalAportacionesEmpleador = 0;

                    for (int l = 0; l < miPLanilla.ListaDetalle[i].ListaDetalleAportacionesEmpleador.Count; l++)
                    {
                        celda = celda + miPLanilla.ListaDetalle[i].ListaDetalleAportacionesEmpleador[l].Monto.ToString("0.00", CultureInfo.InvariantCulture) + "\n \n";
                        totalAportacionesEmpleador = totalAportacionesEmpleador + miPLanilla.ListaDetalle[i].ListaDetalleAportacionesEmpleador[l].Monto;

                    }

                    clNumero = new PdfPCell(new Phrase(celda, _standardFont));
                    clNumero.HorizontalAlignment = Element.ALIGN_RIGHT;
                    tblPrueba.AddCell(clNumero);

                    clNumero = new PdfPCell(new Phrase(totalAportacionesEmpleador.ToString("0.00", CultureInfo.InvariantCulture), _standardFont));
                    clNumero.HorizontalAlignment = Element.ALIGN_RIGHT;
                    tblPrueba.AddCell(clNumero);

                    clNumero = new PdfPCell(new Phrase(miPLanilla.ListaDetalle[i].netoACobrar.ToString(), _standardFont));
                    clNumero.HorizontalAlignment = Element.ALIGN_RIGHT;
                    tblPrueba.AddCell(clNumero);

                    clNumero = new PdfPCell(new Phrase(miPLanilla.ListaDetalle[i].diasLaborados.ToString(), _standardFont));
                    tblPrueba.AddCell(clNumero);


                    tblPrueba.CompleteRow();
                    totalNetoACobrar += miPLanilla.ListaDetalle[i].netoACobrar;
                }
                else
                {

                    clNumero = new PdfPCell(new Phrase(""));
                    clNumero.HorizontalAlignment = Element.ALIGN_CENTER;
                    clNumero.BorderWidthRight = 0;
                    tblPrueba.AddCell(clNumero);

                    clNumero = new PdfPCell(new Phrase ("TOTAL"));
                    clNumero.HorizontalAlignment = Element.ALIGN_CENTER;
                    clNumero.VerticalAlignment = Element.ALIGN_CENTER;
                    clNumero.BorderWidthRight = 0;
                    clNumero.BorderWidthLeft = 0;
                    tblPrueba.AddCell(clNumero);

                    clNumero = new PdfPCell(new Phrase(""));
                    clNumero.HorizontalAlignment = Element.ALIGN_CENTER;
                    clNumero.BorderWidthRight = 0;
                    clNumero.BorderWidthLeft = 0;
                    tblPrueba.AddCell(clNumero);

                    clNumero = new PdfPCell(new Phrase(""));
                    clNumero.HorizontalAlignment = Element.ALIGN_CENTER;
                    clNumero.BorderWidthRight = 0;
                    clNumero.BorderWidthLeft = 0;
                    tblPrueba.AddCell(clNumero);

                    clNumero = new PdfPCell(new Phrase(""));
                    clNumero.HorizontalAlignment = Element.ALIGN_CENTER;
                    clNumero.BorderWidthRight = 0;
                    clNumero.BorderWidthLeft = 0;
                    tblPrueba.AddCell(clNumero);

                    clNumero = new PdfPCell(new Phrase(""));
                    clNumero.HorizontalAlignment = Element.ALIGN_CENTER;
                    clNumero.BorderWidthLeft = 0;
                    tblPrueba.AddCell(clNumero);


                    celda = "";
                    totalIngresos = 0;

                    for (int j = 0; j < ListaTotales.ListaDetalleIngresos.Count; j++)
                    {

                        celda = celda + ListaTotales.ListaDetalleIngresos[j].Monto.ToString("0.00", CultureInfo.InvariantCulture) + "\n \n";
                        totalIngresos = totalIngresos + ListaTotales.ListaDetalleIngresos[j].Monto;
                        

                    }

                    clNumero = new PdfPCell(new Phrase(celda, _standardFont));
                    clNumero.HorizontalAlignment = Element.ALIGN_RIGHT;
                    tblPrueba.AddCell(clNumero);

                    clNumero = new PdfPCell(new Phrase(totalIngresos.ToString("0.00", CultureInfo.InvariantCulture), _standardFont));
                    clNumero.HorizontalAlignment = Element.ALIGN_RIGHT;
                    tblPrueba.AddCell(clNumero);

                    celda = "";
                    totalAportacionesTrabajador = 0;
                    totalAFP = 0;


                    for (int k = 0; k < ListaTotales.ListaDetalleAportacionesTrabajador.Count; k++)
                    {
                        celda = celda + ListaTotales.ListaDetalleAportacionesTrabajador[k].Monto.ToString("0.00", CultureInfo.InvariantCulture) + "\n \n";
                        totalAportacionesTrabajador = totalAportacionesTrabajador + ListaTotales.ListaDetalleAportacionesTrabajador[k].Monto;
                        switch (ListaTotales.ListaDetalleAportacionesTrabajador[k].MaestroAportacionTrabajador.Codigo)
                        {
                            case "0606":
                            case "0608":
                            case "0601":
                            case "9998":
                                totalAFP = totalAFP + ListaTotales.ListaDetalleAportacionesTrabajador[k].Monto;

                                break;
                            
                            
                            default:
                                break;
                        }
                    }

                    for (int m = 0; m < ListaTotales.ListaDetalleAportacionesEmpleador.Count  ; m++)
                    {
                        switch (ListaTotales.ListaDetalleAportacionesEmpleador[m].MaestroAportacionesEmpleador.Codigo  )
                        {
                            case "0804":
                                totalEssalud += ListaTotales.ListaDetalleAportacionesEmpleador[m].Monto;
                                break;
                            case "0805":
                                totalEssaludRiesgo += ListaTotales.ListaDetalleAportacionesEmpleador[m].Monto;
                                break;
                            default:
                                break;
                        }
                    }
                    
                    clNumero = new PdfPCell(new Phrase(celda, _standardFont));
                    clNumero.HorizontalAlignment = Element.ALIGN_RIGHT;
                    tblPrueba.AddCell(clNumero);

                    clNumero = new PdfPCell(new Phrase(totalAportacionesTrabajador.ToString("0.00", CultureInfo.InvariantCulture), _standardFont));
                    clNumero.HorizontalAlignment = Element.ALIGN_RIGHT;
                    tblPrueba.AddCell(clNumero);

                    clNumero = new PdfPCell(new Phrase(totalAFP.ToString("0.00", CultureInfo.InvariantCulture), _standardFont));
                    clNumero.HorizontalAlignment = Element.ALIGN_RIGHT;
                    tblPrueba.AddCell(clNumero);

                    celda = "";
                    totalAportacionesEmpleador = 0;

                    for (int l = 0; l < ListaTotales.ListaDetalleAportacionesEmpleador.Count; l++)
                    {
                        celda = celda + ListaTotales.ListaDetalleAportacionesEmpleador[l].Monto.ToString("0.00", CultureInfo.InvariantCulture) + "\n \n";
                        totalAportacionesEmpleador = totalAportacionesEmpleador + ListaTotales.ListaDetalleAportacionesEmpleador[l].Monto;

                    }

                    clNumero = new PdfPCell(new Phrase(celda, _standardFont));
                    clNumero.HorizontalAlignment = Element.ALIGN_RIGHT;
                    tblPrueba.AddCell(clNumero);

                    clNumero = new PdfPCell(new Phrase(totalAportacionesEmpleador.ToString("0.00", CultureInfo.InvariantCulture), _standardFont));
                    clNumero.HorizontalAlignment = Element.ALIGN_RIGHT;
                    tblPrueba.AddCell(clNumero);

                    clNumero = new PdfPCell(new Phrase(totalNetoACobrar.ToString("0.00", CultureInfo.InvariantCulture ), _standardFont));
                    clNumero.HorizontalAlignment = Element.ALIGN_RIGHT;
                    tblPrueba.AddCell(clNumero);

                    clNumero = new PdfPCell(new Phrase(""));
                    tblPrueba.AddCell(clNumero);


                    tblPrueba.CompleteRow();
                }
            }
 

            // Llenamos la tabla con información

            Paragraph Encabezado = new Paragraph();
            Encabezado.Alignment = Element.ALIGN_CENTER;
            Encabezado.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 12);
            Encabezado.Add("MUNICIPALIDAD DISTRITAL DE CCATCCA \n UNIDAD DE PERSONAL \n ");

            Paragraph numeroPLanilla = new Paragraph();
            numeroPLanilla.Alignment = Element.ALIGN_RIGHT;
            numeroPLanilla.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            numeroPLanilla.Add("PLANILLA Nº" + miPLanilla.numeroPlanilla + " - " + miPLanilla.Año + " \n ");

            Paragraph descripcionPlanilla = new Paragraph();
            descripcionPlanilla.Alignment = Element.ALIGN_CENTER;
            descripcionPlanilla.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            descripcionPlanilla.Add(miPLanilla.Descripcion.ToString().ToUpper() + " DE " + miPLanilla.Mes + " DE " + miPLanilla.Año + ".");

            Paragraph metaPlanilla = new Paragraph();
            metaPlanilla.Alignment = Element.ALIGN_LEFT;
            metaPlanilla.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            metaPlanilla.IndentationLeft = 110f;

            string smeta_numero_con_ceros = string.Format("{0:000}", miPLanilla.Meta.Numero);

            metaPlanilla.Add("META:" + miPLanilla.Meta.Numero.ToString().PadLeft(3, '0') + " - " + miPLanilla.Meta.Nombre   + ". \n\n");

            string ruta = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string ruta_imagen = ruta + "\\MUNICIPALIDAD-DISTRITAL-DE-CCATCCA-2.png";

            string ruta_cuadro_oficinas = ruta + "\\oficinas.png";

            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(ruta_imagen);
            logo.ScalePercent(64f);
            logo.SetAbsolutePosition(12f, doc.PageSize.Height - 36f - 100f);

            iTextSharp.text.Image oficinas = iTextSharp.text.Image.GetInstance(ruta_cuadro_oficinas);
            oficinas.ScalePercent(64f);
            oficinas.SetAbsolutePosition(doc.PageSize.Width - 150f, doc.PageSize.Height - 80f);


            PdfPTable tablaAFP = new PdfPTable(2);
            PdfPCell clAFP = new PdfPCell(new Phrase("Profuturo"));
            clAFP.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaAFP.AddCell(clAFP);

            clAFP = new PdfPCell(new Phrase(profuturo.ToString("0.00", CultureInfo.InvariantCulture)));
            tablaAFP.AddCell(clAFP);

            tablaAFP.CompleteRow();


            clAFP = new PdfPCell(new Phrase("Integra"));
            clAFP.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaAFP.AddCell(clAFP);

            clAFP = new PdfPCell(new Phrase(integra.ToString("0.00", CultureInfo.InvariantCulture)));
            tablaAFP.AddCell(clAFP);
            tablaAFP.CompleteRow();

            clAFP = new PdfPCell(new Phrase("Prima"));
            clAFP.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaAFP.AddCell(clAFP);
            clAFP = new PdfPCell(new Phrase(prima.ToString("0.00", CultureInfo.InvariantCulture)));
            tablaAFP.AddCell(clAFP);

            tablaAFP.CompleteRow();

            clAFP = new PdfPCell(new Phrase("Habitat"));
            clAFP.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaAFP.AddCell(clAFP);
            clAFP = new PdfPCell(new Phrase(habitat.ToString("0.00", CultureInfo.InvariantCulture)));
            tablaAFP.AddCell(clAFP);

            tablaAFP.CompleteRow();

            PdfPTable tablaDebeHaber = new PdfPTable(3);

            PdfPCell clDebe = new PdfPCell(new Phrase(""));
            tablaDebeHaber.AddCell(clDebe);
            clDebe = new PdfPCell(new Phrase("DEBE"));
            clDebe.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaDebeHaber.AddCell(clDebe);
            clDebe = new PdfPCell(new Phrase("HABER"));
            clDebe.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaDebeHaber.AddCell(clDebe);

            tablaDebeHaber.CompleteRow();

            clDebe = new PdfPCell(new Phrase("TOTAL INGRESOS"));
            tablaDebeHaber.AddCell(clDebe);
            clDebe = new PdfPCell(new Phrase(totalIngresos.ToString("0.00", CultureInfo.InvariantCulture)));
            clDebe.HorizontalAlignment = Element.ALIGN_RIGHT;
            tablaDebeHaber.AddCell(clDebe);

            clDebe = new PdfPCell(new Phrase(""));
            tablaDebeHaber.AddCell(clDebe);

            tablaDebeHaber.CompleteRow();

            clDebe = new PdfPCell(new Phrase("TOTAL APORTACIONES"));
            tablaDebeHaber.AddCell(clDebe);
            clDebe = new PdfPCell(new Phrase(totalAportacionesEmpleador.ToString("0.00", CultureInfo.InvariantCulture)));
            clDebe.HorizontalAlignment = Element.ALIGN_RIGHT;
            tablaDebeHaber.AddCell(clDebe);
            clDebe = new PdfPCell(new Phrase(""));
            tablaDebeHaber.AddCell(clDebe);

            tablaDebeHaber.CompleteRow();

            clDebe = new PdfPCell(new Phrase("NETO A COBRAR"));
            tablaDebeHaber.AddCell(clDebe);
            clDebe = new PdfPCell(new Phrase(""));
            tablaDebeHaber.AddCell(clDebe);
            clDebe = new PdfPCell(new Phrase(totalNetoACobrar.ToString("0.00", CultureInfo.InvariantCulture  )));
            tablaDebeHaber.AddCell(clDebe);

            tablaDebeHaber.CompleteRow();

            clDebe = new PdfPCell(new Phrase("TOTAL AFP"));
            tablaDebeHaber.AddCell(clDebe);
            clDebe = new PdfPCell(new Phrase(""));
            tablaDebeHaber.AddCell(clDebe);
            clDebe = new PdfPCell(new Phrase((habitat + prima + profuturo + integra).ToString("0.00", CultureInfo.InvariantCulture)));
            tablaDebeHaber.AddCell(clDebe);
            tablaDebeHaber.CompleteRow();

            clDebe = new PdfPCell(new Phrase("TOTAL SNP"));
            tablaDebeHaber.AddCell(clDebe);
            clDebe = new PdfPCell(new Phrase(""));
            tablaDebeHaber.AddCell(clDebe);
            clDebe = new PdfPCell(new Phrase(snp.ToString("0.00", CultureInfo.InvariantCulture)));
            tablaDebeHaber.AddCell(clDebe);
            tablaDebeHaber.CompleteRow();

            clDebe = new PdfPCell(new Phrase());
            //FIRMAS
            Paragraph firma_rrhh = new Paragraph();
            firma_rrhh.Alignment = Element.ALIGN_CENTER;
            firma_rrhh.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            firma_rrhh.Add(" ............................................. \n RECURSOS HUMANOS");

            Paragraph firma_gm = new Paragraph();
            firma_gm.Alignment = Element.ALIGN_CENTER;
            firma_gm.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            firma_gm.Add(" ............................................... \n GERENCIA MUNICIPAL");

            Paragraph firma_pre = new Paragraph();
            firma_pre.Alignment = Element.ALIGN_CENTER;
            firma_pre.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            firma_pre.Add(" .................................... \n PRESUPUESTO");

            Paragraph firma_con = new Paragraph();
            firma_con.Alignment = Element.ALIGN_CENTER;
            firma_con.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            firma_con.Add(" .................................... \n CONTABILIDAD");

            Paragraph firma_Tes = new Paragraph();
            firma_con.Alignment = Element.ALIGN_CENTER;
            firma_con.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            firma_con.Add(" .................................... \n TESORERIA");

            Paragraph firma_SUb = new Paragraph();
            firma_con.Alignment = Element.ALIGN_CENTER;
            firma_con.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 10);
            firma_con.Add(" .................................... \n SubGerencia y/o Supervision");

            PdfPTable tabla_firmas;
            if (miPLanilla.RegimenLaboral.IdTRegimenLaboral == 5)
            {
                tabla_firmas = new PdfPTable(4);
                tabla_firmas.DefaultCell.BorderWidth = 0;
            }
            else
            {
                tabla_firmas = new PdfPTable(6);
                tabla_firmas.DefaultCell.BorderWidth = 0;
            }
            

            tabla_firmas.AddCell(firma_rrhh);
            tabla_firmas.AddCell(firma_gm);
            tabla_firmas.AddCell(firma_pre);
            tabla_firmas.AddCell(firma_con);

            if (miPLanilla.RegimenLaboral.IdTRegimenLaboral == 5)
            {
                
            }
            else
            {
                tabla_firmas.AddCell(firma_Tes);
                tabla_firmas.AddCell(firma_SUb);
            }

            PdfPTable tablaPieInforme = new PdfPTable(2);
            tablaPieInforme.AddCell(tablaAFP);
            tablaPieInforme.AddCell(tablaDebeHaber);
            /*FEcha de hoy*/
            // Finalmente, añadimos la tabla al documento PDF y cerramos el documento
            doc.Add(logo);
            doc.Add(oficinas);
            doc.Add(Encabezado);
            doc.Add(numeroPLanilla);
            doc.Add(descripcionPlanilla);
            doc.Add(metaPlanilla);
            doc.Add(tblPrueba);
            doc.Add(tablaPieInforme );
            
            doc.Add(tabla_firmas);

            doc.Close();
            writer.Close();
        }

        public void ImprimirListaTrabajadores(DataTable ListaTrabajadores, string TipoFiltro)
        {
            FileInfo file = new FileInfo(@"c:\PDFs\listaTrabajadores.pdf");
            bool estaAbierto = IsFileinUse(file, @"c:\PDFs\listaTrabajadores.pdf");


            if (!estaAbierto)
            {
                Document doc = new Document(PageSize.A4, 9, 9, 40, 30);
                doc.AddTitle("Lista Trabajadores " + TipoFiltro);
                doc.AddCreator("EDIRIUS SOFT");

                PdfWriter writer = PdfWriter.GetInstance(doc,
                               new FileStream(@"c:\PDFs\listaTrabajadores.pdf", FileMode.Create));

                doc.Open();


                // Creamos el tipo de Font que vamos utilizar
                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 7f, iTextSharp.text.Font.NORMAL, Color.BLACK);

                iTextSharp.text.Font _tituloFont = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 12f, iTextSharp.text.Font.UNDERLINE, Color.BLACK);


                // Creamos una tabla que contendrá el nombre, apellido y país
                // de nuestros visitante.
                PdfPTable tblTrabajadores = new PdfPTable(5);
                float[] Ancho = new float[7];
                Ancho[0] = 10;
                Ancho[1] = 60;
                Ancho[2] = 50;
                Ancho[3] = 50;
                Ancho[4] = 20;
                Ancho[5] = 20;
                Ancho[6] = 20;
                //tblPrueba.SetWidths(Ancho );
                tblTrabajadores.WidthPercentage = 100;
                tblTrabajadores.DefaultCell.Padding = 1;
                tblTrabajadores.HorizontalAlignment = Element.ALIGN_LEFT;

                iTextSharp.text.Color colorTitulos = new Color(240, 240, 240);
                iTextSharp.text.Color colorBlanco = new Color(255, 255, 255);


                //tabla de titulo
                PdfPTable tblTitulo = new PdfPTable(1);
                tblTitulo.DefaultCell.Padding = 1;
                tblTitulo.HorizontalAlignment = Element.ALIGN_LEFT;

                PdfPCell tituloPrincipal = new PdfPCell(new Phrase("Lista de Trabajadores", _tituloFont));
                tituloPrincipal.HorizontalAlignment = Element.ALIGN_CENTER;
                tituloPrincipal.BorderWidthBottom = 0f;
                tituloPrincipal.BorderWidthLeft = 0f;
                tituloPrincipal.BorderWidthRight = 0f;
                tituloPrincipal.BorderWidthTop = 0f;
                tituloPrincipal.BackgroundColor = colorBlanco;

                tblTitulo.AddCell(tituloPrincipal);

                PdfPCell tituloFiltro = new PdfPCell(new Phrase(TipoFiltro, _tituloFont));
                tituloFiltro.HorizontalAlignment = Element.ALIGN_LEFT;
                tituloFiltro.BorderWidthBottom = 0f;
                tituloFiltro.BorderWidthLeft = 0f;
                tituloFiltro.BorderWidthRight = 0f;
                tituloFiltro.BorderWidthTop = 0f;
                tituloFiltro.BackgroundColor = colorBlanco;
                tblTitulo.AddCell(tituloFiltro);

                PdfPCell tituloFecha = new PdfPCell(new Phrase("Fecha: " + DateTime.Today.ToShortDateString(), _tituloFont));
                tituloFecha.HorizontalAlignment = Element.ALIGN_LEFT;
                tituloFecha.BorderWidthBottom = 0f;
                tituloFecha.BorderWidthLeft = 0f;
                tituloFecha.BorderWidthRight = 0f;
                tituloFecha.BorderWidthTop = 0f;
                tituloFecha.BackgroundColor = colorBlanco;
                tblTitulo.AddCell(tituloFecha);

                // Configuramos el título de las columnas de la tabla
                PdfPCell clNumero = new PdfPCell(new Phrase("N°", _standardFont));
                clNumero.HorizontalAlignment = Element.ALIGN_LEFT;
                clNumero.BackgroundColor = colorTitulos;
                clNumero.BorderWidthBottom = 0.75f;

                tblTrabajadores.AddCell(clNumero);

                PdfPCell clDni = new PdfPCell(new Phrase("DNI", _standardFont));
                clDni.HorizontalAlignment = Element.ALIGN_CENTER;
                clDni.BackgroundColor = colorTitulos;
                clDni.BorderWidthBottom = 0.75f;

                tblTrabajadores.AddCell(clDni);

                PdfPCell clNombre = new PdfPCell(new Phrase("NOMBRE COMPLETO", _standardFont));
                clNombre.HorizontalAlignment = Element.ALIGN_LEFT;
                clNombre.BackgroundColor = colorTitulos;
                clNombre.BorderWidthBottom = 0.75f;

                tblTrabajadores.AddCell(clNombre);

                PdfPCell clApellido = new PdfPCell(new Phrase("CARGO", _standardFont));
                clApellido.HorizontalAlignment = Element.ALIGN_CENTER;
                clApellido.BackgroundColor = colorTitulos;
                clApellido.BorderWidthBottom = 0.75f;
                tblTrabajadores.AddCell(clApellido);

                PdfPCell clFechaInicio = new PdfPCell(new Phrase("FECHA INICIO", _standardFont));
                clFechaInicio.HorizontalAlignment = Element.ALIGN_CENTER;
                clFechaInicio.BackgroundColor = colorTitulos;
                clFechaInicio.BorderWidthBottom = 0.75f;
                tblTrabajadores.AddCell(clFechaInicio);



                string ruta = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                string ruta_imagen = ruta + "\\MUNICIPALIDAD-DISTRITAL-DE-CCATCCA-2.png";

                int numero = 0;

                foreach (DataRow row in ListaTrabajadores.Rows)
                {
                    numero += 1;
                    PdfPCell celNumero = new PdfPCell(new Phrase(numero.ToString(), _standardFont));
                    celNumero.HorizontalAlignment = Element.ALIGN_LEFT;
                    celNumero.BackgroundColor = colorBlanco;
                    celNumero.BorderWidthBottom = 0.75f;
                    tblTrabajadores.AddCell(celNumero);

                    PdfPCell celDNI = new PdfPCell(new Phrase(row[1].ToString(), _standardFont));
                    celDNI.HorizontalAlignment = Element.ALIGN_CENTER;
                    celDNI.BackgroundColor = colorBlanco;
                    celDNI.BorderWidthBottom = 0.75f;
                    tblTrabajadores.AddCell(celDNI);

                    PdfPCell celNombre = new PdfPCell(new Phrase(row[2].ToString() + " " + row[3].ToString() + " " + row[4].ToString(), _standardFont));
                    celNombre.HorizontalAlignment = Element.ALIGN_LEFT;
                    celNombre.BackgroundColor = colorBlanco;
                    celNombre.BorderWidthBottom = 0.75f;
                    tblTrabajadores.AddCell(celNombre);

                    PdfPCell celFechaInicio = new PdfPCell(new Phrase(row[8].ToString(), _standardFont));
                    celFechaInicio.HorizontalAlignment = Element.ALIGN_CENTER;
                    celFechaInicio.BackgroundColor = colorBlanco;
                    celFechaInicio.BorderWidthBottom = 0.75f;
                    tblTrabajadores.AddCell(celFechaInicio);

                    PdfPCell celFecha2Inicio = new PdfPCell(new Phrase(row[7].ToString(), _standardFont));
                    celFecha2Inicio.HorizontalAlignment = Element.ALIGN_CENTER;
                    celFecha2Inicio.BackgroundColor = colorBlanco;
                    celFecha2Inicio.BorderWidthBottom = 0.75f;
                    tblTrabajadores.AddCell(celFecha2Inicio);
                }

                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(ruta_imagen);
                logo.ScalePercent(64f);
                logo.SetAbsolutePosition(12f, doc.PageSize.Height - 36f - 100f);

                //doc.Add(logo);
                doc.Add(tblTitulo);
                doc.Add(tblTrabajadores);
                doc.Close();
                writer.Close();
            }

            else
            {
                throw new cReglaNegociosException("Cerrar porfavor ListaTrabajadores.pdf");
            } 

        }


        public void ImprimirListaTrabajadoresConReloj(DataTable ListaTrabajadores, string TipoFiltro)
        {
            FileInfo file = new FileInfo(@"c:\PDFs\listaTrabajadores.pdf");
            bool estaAbierto = IsFileinUse(file, @"c:\PDFs\listaTrabajadores.pdf");


            if (!estaAbierto)
            {
                Document doc = new Document(PageSize.A4, 9, 9, 40, 30);
                doc.AddTitle("Lista Trabajadores " + TipoFiltro);
                doc.AddCreator("EDIRIUS SOFT");

                PdfWriter writer = PdfWriter.GetInstance(doc,
                               new FileStream(@"c:\PDFs\listaTrabajadores.pdf", FileMode.Create));

                doc.Open();


                // Creamos el tipo de Font que vamos utilizar
                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 7f, iTextSharp.text.Font.NORMAL, Color.BLACK);

                iTextSharp.text.Font _tituloFont = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 12f, iTextSharp.text.Font.UNDERLINE, Color.BLACK);


                // Creamos una tabla que contendrá el nombre, apellido y país
                // de nuestros visitante.
                PdfPTable tblTrabajadores = new PdfPTable(6);
                float[] Ancho = new float[7];
                Ancho[0] = 10;
                Ancho[1] = 60;
                Ancho[2] = 50;
                Ancho[3] = 50;
                Ancho[4] = 20;
                Ancho[5] = 20;
                Ancho[6] = 20;
                //tblPrueba.SetWidths(Ancho );
                tblTrabajadores.WidthPercentage = 100;
                tblTrabajadores.DefaultCell.Padding = 1;
                tblTrabajadores.HorizontalAlignment = Element.ALIGN_LEFT;

                iTextSharp.text.Color colorTitulos = new Color(240, 240, 240);
                iTextSharp.text.Color colorBlanco = new Color(255, 255, 255);


                //tabla de titulo
                PdfPTable tblTitulo = new PdfPTable(1);
                tblTitulo.DefaultCell.Padding = 1;
                tblTitulo.HorizontalAlignment = Element.ALIGN_LEFT;

                PdfPCell tituloPrincipal = new PdfPCell(new Phrase("Lista de Trabajadores", _tituloFont));
                tituloPrincipal.HorizontalAlignment = Element.ALIGN_CENTER;
                tituloPrincipal.BorderWidthBottom = 0f;
                tituloPrincipal.BorderWidthLeft = 0f;
                tituloPrincipal.BorderWidthRight = 0f;
                tituloPrincipal.BorderWidthTop = 0f;
                tituloPrincipal.BackgroundColor = colorBlanco;

                tblTitulo.AddCell(tituloPrincipal);

                PdfPCell tituloFiltro = new PdfPCell(new Phrase(TipoFiltro, _tituloFont));
                tituloFiltro.HorizontalAlignment = Element.ALIGN_LEFT;
                tituloFiltro.BorderWidthBottom = 0f;
                tituloFiltro.BorderWidthLeft = 0f;
                tituloFiltro.BorderWidthRight = 0f;
                tituloFiltro.BorderWidthTop = 0f;
                tituloFiltro.BackgroundColor = colorBlanco;
                tblTitulo.AddCell(tituloFiltro);

                PdfPCell tituloFecha = new PdfPCell(new Phrase("Fecha: " + DateTime.Today.ToShortDateString(), _tituloFont));
                tituloFecha.HorizontalAlignment = Element.ALIGN_LEFT;
                tituloFecha.BorderWidthBottom = 0f;
                tituloFecha.BorderWidthLeft = 0f;
                tituloFecha.BorderWidthRight = 0f;
                tituloFecha.BorderWidthTop = 0f;
                tituloFecha.BackgroundColor = colorBlanco;
                tblTitulo.AddCell(tituloFecha);

                // Configuramos el título de las columnas de la tabla
                PdfPCell clNumero = new PdfPCell(new Phrase("N°", _standardFont));
                clNumero.HorizontalAlignment = Element.ALIGN_LEFT;
                clNumero.BackgroundColor = colorTitulos;
                clNumero.BorderWidthBottom = 0.75f;

                tblTrabajadores.AddCell(clNumero);

                PdfPCell clDni = new PdfPCell(new Phrase("DNI", _standardFont));
                clDni.HorizontalAlignment = Element.ALIGN_CENTER;
                clDni.BackgroundColor = colorTitulos;
                clDni.BorderWidthBottom = 0.75f;

                tblTrabajadores.AddCell(clDni);

                PdfPCell clNombre = new PdfPCell(new Phrase("NOMBRE COMPLETO", _standardFont));
                clNombre.HorizontalAlignment = Element.ALIGN_LEFT;
                clNombre.BackgroundColor = colorTitulos;
                clNombre.BorderWidthBottom = 0.75f;

                tblTrabajadores.AddCell(clNombre);

                PdfPCell clApellido = new PdfPCell(new Phrase("CARGO", _standardFont));
                clApellido.HorizontalAlignment = Element.ALIGN_CENTER;
                clApellido.BackgroundColor = colorTitulos;
                clApellido.BorderWidthBottom = 0.75f;
                tblTrabajadores.AddCell(clApellido);

                PdfPCell clFechaInicio = new PdfPCell(new Phrase("FECHA INICIO", _standardFont));
                clFechaInicio.HorizontalAlignment = Element.ALIGN_CENTER;
                clFechaInicio.BackgroundColor = colorTitulos;
                clFechaInicio.BorderWidthBottom = 0.75f;
                tblTrabajadores.AddCell(clFechaInicio);

                PdfPCell clFechaPicado = new PdfPCell(new Phrase("FECHA PICADO", _standardFont));
                clFechaInicio.HorizontalAlignment = Element.ALIGN_CENTER;
                clFechaInicio.BackgroundColor = colorTitulos;
                clFechaInicio.BorderWidthBottom = 0.75f;
                tblTrabajadores.AddCell(clFechaPicado);


                string ruta = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                string ruta_imagen = ruta + "\\MUNICIPALIDAD-DISTRITAL-DE-CCATCCA-2.png";

                int numero = 0;

                foreach (DataRow row in ListaTrabajadores.Rows)
                {
                    numero += 1;
                    PdfPCell celNumero = new PdfPCell(new Phrase(numero.ToString(), _standardFont));
                    celNumero.HorizontalAlignment = Element.ALIGN_LEFT;
                    celNumero.BackgroundColor = colorBlanco;
                    celNumero.BorderWidthBottom = 0.75f;
                    tblTrabajadores.AddCell(celNumero);

                    PdfPCell celDNI = new PdfPCell(new Phrase(row[1].ToString(), _standardFont));
                    celDNI.HorizontalAlignment = Element.ALIGN_CENTER;
                    celDNI.BackgroundColor = colorBlanco;
                    celDNI.BorderWidthBottom = 0.75f;
                    tblTrabajadores.AddCell(celDNI);

                    PdfPCell celNombre = new PdfPCell(new Phrase(row[2].ToString() + " " + row[3].ToString() + " " + row[4].ToString(), _standardFont));
                    celNombre.HorizontalAlignment = Element.ALIGN_LEFT;
                    celNombre.BackgroundColor = colorBlanco;
                    celNombre.BorderWidthBottom = 0.75f;
                    tblTrabajadores.AddCell(celNombre);

                    PdfPCell celFechaInicio = new PdfPCell(new Phrase(row[8].ToString(), _standardFont));
                    celFechaInicio.HorizontalAlignment = Element.ALIGN_CENTER;
                    celFechaInicio.BackgroundColor = colorBlanco;
                    celFechaInicio.BorderWidthBottom = 0.75f;
                    tblTrabajadores.AddCell(celFechaInicio);

                    PdfPCell celFecha2Inicio = new PdfPCell(new Phrase(row[7].ToString(), _standardFont));
                    celFecha2Inicio.HorizontalAlignment = Element.ALIGN_CENTER;
                    celFecha2Inicio.BackgroundColor = colorBlanco;
                    celFecha2Inicio.BorderWidthBottom = 0.75f;
                    tblTrabajadores.AddCell(celFecha2Inicio);

                    PdfPCell celFechaPicado = new PdfPCell(new Phrase(row[9].ToString(), _standardFont));
                    celFechaPicado.HorizontalAlignment = Element.ALIGN_CENTER;
                    celFechaPicado.BackgroundColor = colorBlanco;
                    celFechaPicado.BorderWidthBottom = 0.75f;
                    tblTrabajadores.AddCell(celFechaPicado);
                }

                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(ruta_imagen);
                logo.ScalePercent(64f);
                logo.SetAbsolutePosition(12f, doc.PageSize.Height - 36f - 100f);

                doc.Add(logo);
                doc.Add(tblTitulo);
                doc.Add(tblTrabajadores);
                doc.Close();
                writer.Close();
            }

            else
            {
                throw new cReglaNegociosException("Cerrar porfavor ListaTrabajadores.pdf");
            }

        }
    }
}
