using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios.PlanillaNueva;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp;
using System.IO;

namespace CapaDeNegocios.PDF
{
    public class cPDF
    {

        public void ImprimirPlanilla(cnPlanilla miPLanilla)
        {
            Document doc = new Document(PageSize.A4, 9, 9, 40, 30);
            doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            PdfWriter writer = PdfWriter.GetInstance(doc,
                            new FileStream(@"D:\prueba222.pdf", FileMode.Create));

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
            PdfPTable tblPrueba = new PdfPTable(10);
            float[] Ancho = new float[10];
            Ancho[0] = 50;
            Ancho[1] = 100;
            Ancho[2] = 50;
            Ancho[3] = 50;
            Ancho[4] = 50;
            Ancho[5] = 20;
            Ancho[6] = 20;
            Ancho[7] = 20;
            Ancho[8] = 20;
            Ancho[9] = 20;
            //tblPrueba.SetWidths(Ancho );
            tblPrueba.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla
            PdfPCell clNumero = new PdfPCell(new Phrase("Numero", _standardFont));
            clNumero.HorizontalAlignment = Element.ALIGN_LEFT;
            
            clNumero.BorderWidthBottom = 0.75f;

            PdfPCell clNombre = new PdfPCell(new Phrase("NOMBRE COMPLETO", _standardFont));
            clNombre.HorizontalAlignment = Element.ALIGN_LEFT;
            clNombre.BorderWidthBottom = 0.75f;

            PdfPCell clApellido = new PdfPCell(new Phrase("CARGO", _standardFont));
            clApellido.HorizontalAlignment = Element.ALIGN_CENTER;
            clApellido.BorderWidthBottom = 0.75f;

            PdfPCell clFechaInicio = new PdfPCell(new Phrase("FECHA INICIO", _standardFont));
            clFechaInicio.HorizontalAlignment = Element.ALIGN_CENTER;
            clFechaInicio.BorderWidthBottom = 0.75f;

            PdfPCell clSecuenciaFuncional = new PdfPCell(new Phrase("Sec. \n\n Func.", _standardFont));
            clSecuenciaFuncional.HorizontalAlignment = Element.ALIGN_CENTER;
            clSecuenciaFuncional.BorderWidthBottom = 0.75f;

            PdfPCell clsnp = new PdfPCell(new Phrase("AFIL. AFP/SNP \n\n COMISION \n\n CUSP ", _standardFont));
            clsnp.HorizontalAlignment = Element.ALIGN_CENTER;
            clsnp.BorderWidthBottom = 0.75f;

            
            string celda = "";
            for (int j = 0; j < miPLanilla.ListaDetalle[0].ListaDetalleIngresos.Count; j++)
            {

                celda = celda + miPLanilla.ListaDetalle[0].ListaDetalleIngresos[j].MaestroIngresos.Abreviacion + "\n \n";

                
            }

            PdfPCell clNumeroIngresos = new PdfPCell(new Phrase(celda));
            clNumeroIngresos.HorizontalAlignment = Element.ALIGN_RIGHT;
            clNumeroIngresos.BorderWidthBottom = 0.75f;

            
            PdfPCell clTotalIngresos = new PdfPCell(new Phrase("Total \n \n Ingresos"));
            clTotalIngresos.HorizontalAlignment = Element.ALIGN_CENTER;
            clTotalIngresos.BorderWidthBottom = 0.75f;

            string tituloAportaciones = "";
            for (int j = 0; j < miPLanilla.ListaDetalle[0].ListaDetalleAportacionesTrabajador.Count; j++)
            {

                tituloAportaciones  = tituloAportaciones  + miPLanilla.ListaDetalle[0].ListaDetalleAportacionesTrabajador[j].MaestroAportacionTrabajador.Abreviacion + "\n \n";


            }

            PdfPCell clAportaciones = new PdfPCell(new Phrase(tituloAportaciones));
            clAportaciones.HorizontalAlignment = Element.ALIGN_CENTER;
            clAportaciones.BorderWidthBottom = 0.75f;

            PdfPCell clTotalAPortacionesTrabajador = new PdfPCell(new Phrase("Total \n \n Aportaciones \n \n Trabajador"));
            clTotalAPortacionesTrabajador.HorizontalAlignment = Element.ALIGN_RIGHT;
            clTotalAPortacionesTrabajador.BorderWidthBottom = 0.75f;

            PdfPCell clTotalAFP = new PdfPCell(new Phrase("Total AFP"));
            clTotalAFP.HorizontalAlignment = Element.ALIGN_CENTER;
            clTotalAFP.BorderWidthBottom = 0.75f;
             
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
            tblPrueba.SetWidths(Ancho);

            for (int i = 0; i < miPLanilla.ListaDetalle.Count;i ++)
            {
                clNumero = new PdfPCell(new Phrase(miPLanilla.ListaDetalle[i].numero.ToString(), _standardFont));
                clNumero.HorizontalAlignment = Element.ALIGN_CENTER ;
                tblPrueba.AddCell(clNumero);

                clNumero = new PdfPCell(new Phrase(miPLanilla.ListaDetalle[i].miTrabajador.Nombres + " " + miPLanilla.ListaDetalle[i].miTrabajador.ApellidoPaterno + " " + miPLanilla.ListaDetalle[i].miTrabajador.ApellidoMaterno, _standardFont));
                clNumero.HorizontalAlignment = Element.ALIGN_LEFT;
                tblPrueba.AddCell(clNumero);

                clNumero = new PdfPCell(new Phrase(miPLanilla.ListaDetalle[i].cargo, _standardFont));
                clNumero.HorizontalAlignment = Element.ALIGN_CENTER ;
                tblPrueba.AddCell(clNumero);

                clNumero = new PdfPCell(new Phrase(miPLanilla.ListaDetalle[i].fechaInicio.ToShortDateString() , _standardFont));
                clNumero.HorizontalAlignment = Element.ALIGN_CENTER;
                tblPrueba.AddCell(clNumero);

                clNumero = new PdfPCell(new Phrase(miPLanilla.Meta.Numero ));
                clNumero.HorizontalAlignment = Element.ALIGN_CENTER;
                tblPrueba.AddCell(clNumero);

                clNumero = new PdfPCell(new Phrase(miPLanilla.ListaDetalle[i].miTrabajador.ListaRegimenPensionario[0].MiAFP.Nombre + "\n \n" + miPLanilla.ListaDetalle[i].miTrabajador.ListaRegimenPensionario[0].Cuspp + "\n \n" + miPLanilla.ListaDetalle[i].miTrabajador.ListaRegimenPensionario[0].TipoComision));
                clNumero.HorizontalAlignment = Element.ALIGN_CENTER;
                tblPrueba.AddCell(clNumero);


                celda = "";
                double totalIngresos = 0;
                for (int j = 0; j < miPLanilla.ListaDetalle[i].ListaDetalleIngresos.Count ; j++)
                {
                    
                    celda = celda + miPLanilla.ListaDetalle[i].ListaDetalleIngresos[j].Monto + "\n \n";
                    totalIngresos = totalIngresos + miPLanilla.ListaDetalle[i].ListaDetalleIngresos[j].Monto;


                }
                clNumero = new PdfPCell(new Phrase(celda));
                tblPrueba.AddCell(clNumero);

                clNumero = new PdfPCell(new Phrase(totalIngresos.ToString()));
                tblPrueba.AddCell(clNumero);

                celda = "";
                double totalAportacionesTrabajador = 0;
                for (int k = 0; k < miPLanilla.ListaDetalle[i].ListaDetalleAportacionesTrabajador.Count; k++)
                {
                    celda = celda + miPLanilla.ListaDetalle[i].ListaDetalleAportacionesTrabajador[k].Monto + "\n \n";
                    totalAportacionesTrabajador = totalAportacionesTrabajador + miPLanilla.ListaDetalle[i].ListaDetalleAportacionesTrabajador[k].Monto;
                }

                clNumero = new PdfPCell(new Phrase(celda));
                tblPrueba.AddCell(clNumero);

                clNumero = new PdfPCell(new Phrase(totalAportacionesTrabajador.ToString()));
                tblPrueba.AddCell(clNumero); 

                tblPrueba.CompleteRow();
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


            /*FEcha de hoy*/
            // Finalmente, añadimos la tabla al documento PDF y cerramos el documento
            doc.Add(Encabezado);
            doc.Add(numeroPLanilla);
            doc.Add(descripcionPlanilla);
            doc.Add(metaPlanilla);
            doc.Add(tblPrueba);
            doc.Add(logo);
            doc.Add(oficinas);

            doc.Close();
            writer.Close();
        }
    }
}
