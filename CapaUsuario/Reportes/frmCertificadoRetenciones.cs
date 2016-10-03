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
using System.Runtime.InteropServices;

namespace CapaUsuario.Reportes
{
    public partial class frmCertificadoRetenciones : Form
    {
        int sidtregimenlaboral = 0;
        string plantilla = "";
        string pmes = "";
        string pmes_nro = "";
        string paño = "";

        string sMes = "";
        string sAño = "";

        int sidttrabajador = 0;
        int sidtplanilla = 0;

        public frmCertificadoRetenciones()
        {
            InitializeComponent();
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
            var headerfooter = FontFactory.GetFont("Arial", 8);
            HeaderFooter header = (new HeaderFooter(new Phrase("Boleta de Pago", headerfooter), false));
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

        private void frmCertificadoRetenciones_Load(object sender, EventArgs e)
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //PdfWriter.GetInstance(pdfDoc, stream);
            CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

            pmes = cboMes.GetItemText(this.cboMes.SelectedItem); ;
            paño = cboAño.GetItemText(this.cboAño.SelectedItem); ;

            switch (pmes)
            {
                case "ENERO": pmes_nro = "1"; break;
                case "FEBRERO": pmes_nro = "2"; break;
                case "MARZO": pmes_nro = "3"; break;
                case "ABRIL": pmes_nro = "4"; break;
                case "MAYO": pmes_nro = "5"; break;
                case "JUNIO": pmes_nro = "6"; break;
                case "JULIO": pmes_nro = "7"; break;
                case "AGOSTO": pmes_nro = "8"; break;
                case "SETIEMBRE": pmes_nro = "9"; break;
                case "OCTUBRE": pmes_nro = "10"; break;
                case "NOVIEMBRE": pmes_nro = "11"; break;
                case "DICIEMBRE": pmes_nro = "12"; break;
            }

            //Llenar data table BoletaPago verificando que tenga mas de un registro
            dgvBoletaPago.DataSource = oPlanilla.ListarPlanillaTrabajadorX(pmes, paño);

            int numero_boleta_pago = dgvBoletaPago.Rows.Count;

            if (numero_boleta_pago > 0)
            {
                dgvBoletaPago.Columns[0].Visible = false;
                dgvBoletaPago.Columns[1].Visible = false;
                dgvBoletaPago.Columns[3].Visible = false;
                dgvBoletaPago.Columns[5].Visible = false;
                dgvBoletaPago.Columns[6].Visible = false;

                dgvBoletaPago.Rows[0].Cells[7].Selected = true;

                sidtplanilla = Convert.ToInt32(dgvBoletaPago.Rows[0].Cells[0].Value);
                sidttrabajador = Convert.ToInt32(dgvBoletaPago.Rows[0].Cells[1].Value);
                sidtregimenlaboral = Convert.ToInt32(dgvBoletaPago.Rows[0].Cells[3].Value);
                sMes = dgvBoletaPago.Rows[0].Cells[5].Value.ToString();
                sAño = dgvBoletaPago.Rows[0].Cells[6].Value.ToString();
                plantilla = dgvBoletaPago.Rows[0].Cells[12].Value.ToString();

                dgvBoletaPago.Columns[2].Width = 200;
            }

            if (numero_boleta_pago == 0)
                MessageBox.Show("No hay datos para esta consulta.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvBoletaPago_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvBoletaPago_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int numero_filas = dgvBoletaPago.Rows.Count;
            if (e.RowIndex != -1)
            {
                sidtplanilla = Convert.ToInt32(dgvBoletaPago.Rows[e.RowIndex].Cells[0].Value);
                sidttrabajador = Convert.ToInt32(dgvBoletaPago.Rows[e.RowIndex].Cells[1].Value);
                sidtregimenlaboral = Convert.ToInt32(dgvBoletaPago.Rows[e.RowIndex].Cells[3].Value);
                sMes = dgvBoletaPago.Rows[e.RowIndex].Cells[5].Value.ToString();
                sAño = dgvBoletaPago.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo("C:\\PDFs\\CertificadoRetenciones.pdf");
            bool estaAbierto = IsFileinUse(file, "C:\\PDFs\\CertificadoRetenciones.pdf");

            if (!estaAbierto)
            {
                exportar_a_pdf();
            }
            else
                MessageBox.Show("Por favor cerrar BoletaPago.pdf", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public float[] GetTamañoColumnas(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
                if (i == 0) values[i] = 50;
                if (i == 1) values[i] = 200;
            }
            return values;
        }

        private void exportar_a_pdf()
        {
            //Creating iTextSharp Table from the DataTable data
            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 7);
            iTextSharp.text.Font fuenteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 9, 1, iTextSharp.text.Color.BLUE);

            PdfPTable pdfTableD = new PdfPTable(dgvRentasBrutas.ColumnCount);

            PdfPCell cell;

            int k = 0; int o = 0;

            if (dgvRentasBrutas.ColumnCount > 0)
            {

                Phrase objH_D = new Phrase("A", fuente);
                Phrase objP_D = new Phrase("A", fuente);
                float[] headerwidths_D = GetTamañoColumnas(dgvRentasBrutas);
                pdfTableD.DefaultCell.Padding = 1;
                pdfTableD.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTableD.DefaultCell.BorderWidth = 1;
                pdfTableD.SetWidths(headerwidths_D);
                pdfTableD.WidthPercentage = 48;

                /* -------------------------------INICIO DGVBOLETA_D */
                foreach (DataGridViewColumn column in dgvRentasBrutas.Columns)
                {
                    cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                    cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                    pdfTableD.AddCell(cell);
                }

                for (int i = 0; i < dgvRentasBrutas.RowCount - 1; i++)
                {
                    for (int j = 0; j < dgvRentasBrutas.ColumnCount; j++)
                    {
                        cell = new PdfPCell((new Phrase(dgvRentasBrutas[j, i].Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                        cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        pdfTableD.AddCell(cell);
                    }
                    pdfTableD.CompleteRow();
                }
                /* -------------------------------FIN DGVBOLETA_D */
            }
                                    

            //Exporting to PDF
            string folderPath = "C:\\PDFs\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            Document pdfDoc = new Document(PageSize.A4, 9, 9, 10, 10);

            pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4);

            Paragraph paragraph = new Paragraph();
            paragraph.Alignment = Element.ALIGN_CENTER;
            paragraph.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 8);
            paragraph.Add(" ");


            Paragraph paragraph2 = new Paragraph();
            paragraph2.Alignment = Element.ALIGN_LEFT;
            paragraph2.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 8);
            paragraph2.Add("\n\n             ......................................                              ......................................");

            Paragraph paragraph3 = new Paragraph();
            paragraph3.Alignment = Element.ALIGN_LEFT;
            paragraph3.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 8);
            paragraph3.Add("               EMPLEADOR                                          TRABAJADOR");

            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(folderPath + "BoletaPago.pdf", FileMode.Create));
            CreateHeaderFooter(ref pdfDoc);
            pdfDoc.Open();

            //Columnas 
            MultiColumnText columns = new MultiColumnText();
            columns.AddRegularColumns(36f, pdfDoc.PageSize.Width - 36f, 24f, 1);

            //Agregando pdfTable A, B, C, D, E a pdfDoc
            columns.AddElement(pdfTableD);
            columns.AddElement(paragraph);
 

            pdfDoc.Add(columns);

            pdfDoc.Close();
            //stream.Close();
            writer.Close();

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "C:\\PDFs\\CertificadoRetenciones.pdf";
            proc.Start();

        }

    }
}
