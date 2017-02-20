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
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 7f, iTextSharp.text.Font.NORMAL, Color.BLACK );

            // Escribimos el encabezamiento en el documento
            doc.Add(new Paragraph(miPLanilla.Descripcion ));
            doc.Add(Chunk.NEWLINE);

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable tblPrueba = new PdfPTable(3);
            tblPrueba.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla
            PdfPCell clNumero = new PdfPCell(new Phrase("Numero", _standardFont));
            clNumero.BorderWidth = 0;
            clNumero.BorderWidthBottom = 0.75f;

            PdfPCell clNombre = new PdfPCell(new Phrase("NOMBRE COMPLETO", _standardFont));
            clNombre.BorderWidth = 0;
            clNombre.BorderWidthBottom = 0.75f;

            PdfPCell clApellido = new PdfPCell(new Phrase("CARGO", _standardFont));
            clApellido.BorderWidth = 0;
            clApellido.BorderWidthBottom = 0.75f;

            PdfPCell clFechaInicio = new PdfPCell(new Phrase("FECHA INICIO", _standardFont));
            clFechaInicio.BorderWidth = 0;
            clFechaInicio.BorderWidthBottom = 0.75f;

            PdfPCell clsnp = new PdfPCell(new Phrase("SNP/AFP", _standardFont));
            clsnp.BorderWidth = 0;
            clsnp.BorderWidthBottom = 0.75f;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clNumero);
            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clApellido);
            tblPrueba.AddCell(clFechaInicio);
            tblPrueba.AddCell(clsnp);


            for (int i = 0; i < miPLanilla.ListaDetalle.Count;i ++)
            {
                clNumero = new PdfPCell(new Phrase(miPLanilla.ListaDetalle[i].numero.ToString(), _standardFont));
                clNumero.HorizontalAlignment = Element.ALIGN_RIGHT;
                tblPrueba.AddCell(clNumero);

                clNumero = new PdfPCell(new Phrase(miPLanilla.ListaDetalle[i].miTrabajador.Nombres + " " + miPLanilla.ListaDetalle[i].miTrabajador.ApellidoPaterno + " " + miPLanilla.ListaDetalle[i].miTrabajador.ApellidoMaterno, _standardFont));
                clNumero.HorizontalAlignment = Element.ALIGN_RIGHT;
                tblPrueba.AddCell(clNumero);

                clNumero = new PdfPCell(new Phrase(miPLanilla.ListaDetalle[i].cargo, _standardFont));
                clNumero.HorizontalAlignment = Element.ALIGN_RIGHT;
                tblPrueba.AddCell(clNumero);

                clNumero = new PdfPCell(new Phrase(miPLanilla.ListaDetalle[i].fechaInicio.ToShortDateString() , _standardFont));
                clNumero.HorizontalAlignment = Element.ALIGN_RIGHT;
                tblPrueba.AddCell(clNumero);

                tblPrueba.CompleteRow();
            }
            // Llenamos la tabla con información
           
            // Finalmente, añadimos la tabla al documento PDF y cerramos el documento
            doc.Add(tblPrueba);

            doc.Close();
            writer.Close();
        }
    }
}
