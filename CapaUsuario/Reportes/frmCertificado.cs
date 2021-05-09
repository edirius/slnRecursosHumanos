using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp;


namespace CapaUsuario.Reportes
{
    public partial class frmCertificado : Form
    {
        int sidtregimenlaboral = 0;
        string plantilla = "";
        string pmes = "";
        int pmes_nro = 0;
        string paño = "";

        string sMes = "";
        int sAño = 0;

        int sidttrabajador = 0;
        int sidtplanilla = 0;

        decimal total_rentas_brutas = 0;
        decimal total_retencion = 0;

        public frmCertificado()
        {
            InitializeComponent();
        }

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

        class Item
        {
            string _Name;
            int _Id;

            public Item(string name, int id)
            {
                _Name = name;
                _Id = id;
            }

            public string Name
            {
                get { return _Name; }
                set { _Name = value; }
            }

            public int Id
            {
                get { return _Id; }
                set { _Id = value; }
            }
        }

        public void CreateHeaderFooter(ref Document _document)
        {
            var headerfooter = FontFactory.GetFont("Arial", 12);
            HeaderFooter header = (new HeaderFooter(new Phrase("Certificado de Retenciones de Quinta Categoria", headerfooter), false));
            header.BorderColorTop = new iTextSharp.text.Color(System.Drawing.Color.Red);
            header.BorderWidthTop = 0f;
            _document.Header = header;
            HeaderFooter Footer = new HeaderFooter(new Phrase(" ", headerfooter), true);
            Footer.BorderWidthBottom = 0f;
            Footer.BorderWidthTop = 0f;
            Footer.BorderWidthLeft = 0f;
            Footer.BorderWidthRight = 0f;
            _document.Footer = Footer;
        }

        private void frmCertificado_Load(object sender, EventArgs e)
        {
            DataTable odtA = new DataTable();
            DataTable odtAños = new DataTable();
            DataTable odtPlanilla = new DataTable();

            CapaDeNegocios.Reportes.cBoletaPago oBoletaPago = new CapaDeNegocios.Reportes.cBoletaPago();
            CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

            int numero_boleta_pago = 0;

            //dgvBoletaPago.DataSource = oPlanilla.ListarBoletaPagoXMesYRegimenLaboral();
            //Llenando combobox mes y año
            cboMes.DisplayMember = "Name";
            cboMes.ValueMember = "Id";

            cboMes.Items.Add(new Item("ENERO", 1));
            cboMes.Items.Add(new Item("FEBRERO", 2));
            cboMes.Items.Add(new Item("MARZO", 3));
            cboMes.Items.Add(new Item("ABRIL", 4));
            cboMes.Items.Add(new Item("MAYO", 5));
            cboMes.Items.Add(new Item("JUNIO", 6));
            cboMes.Items.Add(new Item("JULIO", 7));
            cboMes.Items.Add(new Item("AGOSTO", 8));
            cboMes.Items.Add(new Item("SETIEMBRE", 9));
            cboMes.Items.Add(new Item("OCTUBRE", 10));
            cboMes.Items.Add(new Item("NOVIEMBRE", 11));
            cboMes.Items.Add(new Item("DICIEMBRE", 12));

            cboMes.SelectedIndex = 0;
            odtAños = oPlanilla.ListarAñosPlanilla();
            cboAño.DataSource = odtAños;
            cboAño.DisplayMember = "añó";
            cboAño.ValueMember = "año";
        }

        private void dgvBoletaPago_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int numero_filas = dgvBoletaPago.Rows.Count;
            if (e.RowIndex != -1)
            {
                sidtplanilla = Convert.ToInt32(dgvBoletaPago.Rows[e.RowIndex].Cells[0].Value);
                sidttrabajador = Convert.ToInt32(dgvBoletaPago.Rows[e.RowIndex].Cells[1].Value);
                sidtregimenlaboral = Convert.ToInt32(dgvBoletaPago.Rows[e.RowIndex].Cells[3].Value);
                sMes =  dgvBoletaPago.Rows[e.RowIndex].Cells[5].Value.ToString();
                sAño = Convert.ToInt32(dgvBoletaPago.Rows[e.RowIndex].Cells[6].Value);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //PdfWriter.GetInstance(pdfDoc, stream);
            CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();
            DataTable odtPlanilla = new DataTable();

            pmes = cboMes.GetItemText(this.cboMes.SelectedItem); ;
            paño = cboAño.GetItemText(this.cboAño.SelectedItem); ;

            switch (pmes)
            {
                case "ENERO": pmes_nro = 1; break;
                case "FEBRERO": pmes_nro = 2; break;
                case "MARZO": pmes_nro = 3; break;
                case "ABRIL": pmes_nro = 4; break;
                case "MAYO": pmes_nro = 5; break;
                case "JUNIO": pmes_nro = 6; break;
                case "JULIO": pmes_nro = 7; break;
                case "AGOSTO": pmes_nro = 8; break;
                case "SETIEMBRE": pmes_nro = 9; break;
                case "OCTUBRE": pmes_nro = 10; break;
                case "NOVIEMBRE": pmes_nro = 11; break;
                case "DICIEMBRE": pmes_nro = 12; break;
            }

            //Llenar data table BoletaPago verificando que tenga mas de un registro
            odtPlanilla = oPlanilla.ListarPlanillaTrabajadorX(pmes, paño);
            dgvBoletaPago.DataSource = odtPlanilla;

            int numero_boleta_pago = dgvBoletaPago.Rows.Count;

            if (numero_boleta_pago > 0)
            {
                dgvBoletaPago.Columns[0].Visible = false;
                dgvBoletaPago.Columns[1].Visible = true;
                dgvBoletaPago.Columns[3].Visible = false;
                dgvBoletaPago.Columns[5].Visible = false;
                dgvBoletaPago.Columns[6].Visible = false;

                dgvBoletaPago.Rows[0].Cells[7].Selected = true;

                sidtplanilla = Convert.ToInt32(dgvBoletaPago.Rows[0].Cells[0].Value);
                sidttrabajador = Convert.ToInt32(dgvBoletaPago.Rows[0].Cells[1].Value);
                sidtregimenlaboral = Convert.ToInt32(dgvBoletaPago.Rows[0].Cells[3].Value);
                sMes = dgvBoletaPago.Rows[0].Cells[5].Value.ToString();
                sAño = Convert.ToInt32(dgvBoletaPago.Rows[0].Cells[6].Value);
                plantilla = dgvBoletaPago.Rows[0].Cells[12].Value.ToString();

                dgvBoletaPago.Columns[2].Width = 200;
            }

            if (numero_boleta_pago == 0)
                MessageBox.Show("No hay datos para esta consulta.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo("C:\\PDFs\\CertificadoRetenciones.pdf");
            bool estaAbierto = IsFileinUse(file, "C:\\PDFs\\CertificadoRetenciones.pdf");
            DataTable odtCertificado = new DataTable();
            DataRow odrCertificado = odtCertificado.NewRow();
            decimal renta_bruta = 0;
            decimal renta_quinta_cat = 0;

            total_rentas_brutas = 0;
            total_retencion = 0;
            renta_bruta = 0;
            renta_quinta_cat = 0;
                

            CapaDeNegocios.Trabajadores.cTrabajadorCas oTrabajador = new CapaDeNegocios.Trabajadores.cTrabajadorCas();

            odtCertificado = oTrabajador.ListarRentaBrutaXTrabajador(sidttrabajador, sAño);
            dgvRentasBrutas.DataSource = odtCertificado;

            /* Agregando totales a odtCertificado */
           

            if ( odtCertificado.Rows.Count>0 ) { 
                for (int i = 0; i < odtCertificado.Rows.Count; i++) {
                    renta_bruta = Convert.ToDecimal(odtCertificado.Rows[i][1]) ;
                    total_rentas_brutas += renta_bruta;

                    renta_quinta_cat = Convert.ToDecimal( odtCertificado.Rows[i][2] );
                    total_retencion += renta_quinta_cat;
                }

                odrCertificado = odtCertificado.NewRow();

                odrCertificado[0] = "TOTAL: ";
                odrCertificado[1] = total_rentas_brutas ;
                odrCertificado[2] = total_retencion;

                odtCertificado.Rows.InsertAt(odrCertificado, odtCertificado.Rows.Count );
            

                /*  Fin odtCertificado */

                if (dgvBoletaPago.Rows.Count > 0)
                {
                    if (!estaAbierto)
                    {
                        exportar_a_pdf();
                    }
                    else
                        MessageBox.Show("Por favor cerrar CertificadoRetenciones.pdf", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Certificado de Retenciones de Quinta Categoria vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("Certificado de Retenciones de Quinta Categoria vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public float[] GetTamañoColumnas(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
                if (i ==0) values[i] = 200;
                if (i ==2) values[i] = 180;
            }
            return values;
        }

        private void exportar_a_pdf()
        {
            //Creating iTextSharp Table from the DataTable data
            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 7);
            iTextSharp.text.Font fuenteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 9, 1, iTextSharp.text.Color.BLUE);
            DataTable odtTrabajador = new DataTable();
            PdfPTable pdfTableD = new PdfPTable(dgvRentasBrutas.ColumnCount);

            PdfPCell cell;

            int k = 0; int o = 0;

            if (dgvRentasBrutas.ColumnCount > 0)
            {

                Phrase objH_D = new Phrase("A", fuente);
                Phrase objP_D = new Phrase("A", fuente);
                float[] headerwidths_D = GetTamañoColumnas(dgvRentasBrutas);
                pdfTableD.DefaultCell.Padding = 1;
                pdfTableD.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTableD.DefaultCell.BorderWidth = 1;
                pdfTableD.SetWidths(headerwidths_D);
                pdfTableD.WidthPercentage = 50;

                /* -------------------------------INICIO dgvRentasBrutas */
                foreach (DataGridViewColumn column in dgvRentasBrutas.Columns)
                {
                    cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                    cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTableD.AddCell(cell);
                }

                for (int i = 0; i < dgvRentasBrutas.RowCount ; i++)
                {
                    for (int j = 0; j < dgvRentasBrutas.ColumnCount; j++)
                    {
                        cell = new PdfPCell((new Phrase(dgvRentasBrutas[j, i].Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 12f, iTextSharp.text.Font.TIMES_ROMAN, iTextSharp.text.Color.BLACK))));
                        if (j==1 || j==2)
                            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        pdfTableD.AddCell(cell);
                    }
                    pdfTableD.CompleteRow();
                }
                /* -------------------------------FIN dgvRentasBrutas */
            }


            //Exporting to PDF
            string folderPath = "C:\\PDFs\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "CertificadoRetenciones.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 9, 9, 10, 10);

                pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4);

                Paragraph paragraph = new Paragraph();
                paragraph.Alignment = Element.ALIGN_CENTER;
                paragraph.Font = FontFactory.GetFont(FontFactory.TIMES, 12);
                paragraph.Add(" ");


                Paragraph paragraph2 = new Paragraph();
                paragraph2.Alignment = Element.ALIGN_JUSTIFIED;
                paragraph2.Font = FontFactory.GetFont(FontFactory.TIMES, 12);
                paragraph2.Add("\n \n CERTIFICADO DE RENTAS Y RETENCIONES A CUENTA DEL IMPUESTO DE RENTA DE CUARTA CATEGORIA(Articulo 45º del D.S. Nº 122-94-EF, Reglamento de la ley de IR) \n");

                Paragraph paragraph3 = new Paragraph();
                paragraph3.Alignment = Element.ALIGN_CENTER;
                paragraph3.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 12);
                paragraph3.Add("\n EJERCICIO " + sAño +  " \n");

                CapaDeNegocios.Trabajadores.cTrabajadorCas oTrabajador = new CapaDeNegocios.Trabajadores.cTrabajadorCas();
                string sAlcalde = oTrabajador.ListarAlcalde().Rows[0][0].ToString();

                Paragraph paragraph4 = new Paragraph();
                paragraph4.Alignment = Element.ALIGN_JUSTIFIED;
                paragraph4.Font = FontFactory.GetFont(FontFactory.TIMES, 12);
                paragraph4.Add("\n Municipalidad Distrital de Maras con RUC 20177432360 domiciliado en la Plaza de Armas s/n del Distrito de Maras, provincia de Urubamba Departamento del Cusco debidamente representado por el Alcalde " + sAlcalde + " \n");

                Paragraph paragraph5 = new Paragraph();
                paragraph5.Alignment = Element.ALIGN_CENTER;
                paragraph5.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 14);
                paragraph5.Add("\n CERTIFICA \n");

                odtTrabajador = oTrabajador.ListarDatosTrabajador(sidttrabajador);

                string snombre_completo = odtTrabajador.Rows[0][1].ToString();
                int sDNI = Convert.ToInt32(odtTrabajador.Rows[0][2].ToString());
                string sCargo = odtTrabajador.Rows[0][3].ToString();

                Paragraph paragraph6 = new Paragraph();
                paragraph6.Alignment = Element.ALIGN_JUSTIFIED;
                paragraph6.Font = FontFactory.GetFont(FontFactory.TIMES, 12);
                paragraph6.Add("\n Por la presente se certifica que " + snombre_completo + " con DNI " + sDNI + " ha realizado en forma independiente el servicio o actividad de " + sCargo + " en el presente ejercicio percibiendo rentras brutas de acuerdo al siguiente detalle. \n \n");

                Paragraph paragraph7 = new Paragraph();
                paragraph7.Alignment = Element.ALIGN_JUSTIFIED;
                paragraph7.Font = FontFactory.GetFont(FontFactory.TIMES, 12);
                paragraph7.Add("\n RENTAS SUJETAS A RETENCION: " + total_retencion + "\n \n RENTAS NO SUJETAS A RETENCION: " + total_rentas_brutas);

                CapaDeNegocios.Reportes.NumLetra oNumLetra = new CapaDeNegocios.Reportes.NumLetra();

                string monto_letras = oNumLetra.Convertir(total_retencion.ToString() ,false) ;

                Paragraph paragraph8 = new Paragraph();
                paragraph8.Alignment = Element.ALIGN_JUSTIFIED;
                paragraph8.Font = FontFactory.GetFont(FontFactory.TIMES, 12);
                paragraph8.Add("\n Por tal motivo sobre el monto sujeto a retención se le ha retenido el impuesto a la Renta de Quinta Categoria, ascendente as S/. " + total_retencion + "( " + monto_letras  +")");
                              
                
                Paragraph paragraph9 = new Paragraph();
                paragraph9.Alignment = Element.ALIGN_JUSTIFIED;
                paragraph9.Font = FontFactory.GetFont(FontFactory.TIMES, 12);
                DateTime fecha = dtpFecha.Value.Date;
                paragraph9.Add("\n MARAS, " + String.Format("{0:dd}", fecha) + " DE " + String.Format("{0:MMMM}", fecha).ToUpper() + " DEL " + String.Format("{0:yyyy}", fecha) + ". \n");

                Paragraph paragraph10 = new Paragraph();
                paragraph10.Alignment = Element.ALIGN_CENTER;
                paragraph10.Font = FontFactory.GetFont(FontFactory.TIMES, 12);
                paragraph10.Add("\n  ...................... \n FIRMA");

                /*
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(folderPath + "CertificadoRetenciones.pdf", FileMode.Create));
                CreateHeaderFooter(ref pdfDoc);
                pdfDoc.Open();
                */

                PdfWriter.GetInstance(pdfDoc, stream);
                CreateHeaderFooter(ref pdfDoc);
                pdfDoc.Open();


                //Columnas 
                MultiColumnText columns = new MultiColumnText();
                columns.AddRegularColumns(36f, pdfDoc.PageSize.Width - 36f, 24f, 1);

                //Agregando pdfTable A, B, C, D, E a pdfDoc
                columns.AddElement(paragraph2);
                columns.AddElement(paragraph3);
                columns.AddElement(paragraph4);
                columns.AddElement(paragraph5);
                columns.AddElement(paragraph6);
                columns.AddElement(pdfTableD);
                columns.AddElement(paragraph7);
                columns.AddElement(paragraph8);
                columns.AddElement(paragraph9);
                columns.AddElement(paragraph10);

                pdfDoc.Add(columns);

                pdfDoc.Close();
                stream.Close();
                //writer.Close();
            }
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "C:\\PDFs\\CertificadoRetenciones.pdf";
            proc.Start();
        }
    }
}
