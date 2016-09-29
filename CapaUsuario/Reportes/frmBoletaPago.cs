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
    public partial class frmBoletaPago : Form
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
  

        public frmBoletaPago()
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

        private void frmBoletaPago_Load(object sender, EventArgs e)
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

        private int nro_dias_mes(int pmes, int paño) {
            int dias_mes = 0;
            bool bisiesto = false;

            if (paño % 4 == 0 && (paño % 100 != 0 || paño % 400 == 0)){
                bisiesto = true;
            }

            if (!bisiesto)
            {
                switch (pmes)
                {
                    case 2: dias_mes = 28; break;
                }
            }
            else {
                switch (pmes)
                {
                    case 2: dias_mes = 29; break;
                }
            }


            switch (pmes)
            {
                case 1: dias_mes = 31; break;
                case 3: dias_mes = 31; break;
                case 4: dias_mes = 30; break;
                case 5: dias_mes = 31; break;
                case 6: dias_mes = 30; break;
                case 7: dias_mes = 31; break;
                case 8: dias_mes = 31; break;
                case 9: dias_mes = 30; break;
                case 10: dias_mes = 31; break;
                case 11: dias_mes = 30; break;
                case 12: dias_mes = 31; break;
            }

            return dias_mes;
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
            _document.Footer = Footer;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo("C:\\PDFs\\BoletaPago.pdf");
            bool estaAbierto = IsFileinUse(file, "C:\\PDFs\\BoletaPago.pdf");

            DataTable odtA = new DataTable();
            DataTable odtB = new DataTable();
            DataTable odtC = new DataTable();
            DataTable odtD = new DataTable();
            DataTable odtE = new DataTable();
            DataTable odtF = new DataTable();
            DataTable odtG = new DataTable();
            DataTable odtH = new DataTable();
            DataTable odtI = new DataTable();
            DataTable odtPlanilla = new DataTable();

            DataRow drFilaD = odtD.NewRow();
            DataRow drFilaF = odtF.NewRow();

            CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();
            CapaDeNegocios.Reportes.cBoletaPago oBoletaPago = new CapaDeNegocios.Reportes.cBoletaPago();
            CapaDeNegocios.Planillas.cDetallePlanillaIngresos oDetallePlanillaIngresos = new CapaDeNegocios.Planillas.cDetallePlanillaIngresos();
            CapaDeNegocios.Planillas.cDetallePlanillaDescuentos oDetallePlanillaDescuentos = new CapaDeNegocios.Planillas.cDetallePlanillaDescuentos();
            CapaDeNegocios.Planillas.cDetallePlanillaATrabajador oDetallePlanillaATrabajador = new CapaDeNegocios.Planillas.cDetallePlanillaATrabajador();
            CapaDeNegocios.Planillas.cDetallePlanillaAEmpleador oDetallePlanillaAEmpleador = new CapaDeNegocios.Planillas.cDetallePlanillaAEmpleador();

            int dias_laborados = 0;
            int mes_dias = 0;

            if (dgvBoletaPago.Rows.Count > 0) { 

                //*-------------Primera parte de la boleta de pago */ 
                odtD.Columns.Add("RUC:", typeof(string));
                odtD.Columns.Add("20226560824", typeof(string));

                drFilaD = odtD.NewRow();
                drFilaD.Delete();
                drFilaD[0] = "EMPLEADOR:"; drFilaD[1] = "MUNICIPALIDAD DISTRITAL DE CCATCAA";
                odtD.Rows.InsertAt(drFilaD, 1);

                drFilaD = odtD.NewRow();
                drFilaD.Delete();
                drFilaD[0] = "PERIODO:"; drFilaD[1] = sMes + "/" + sAño;
                odtD.Rows.InsertAt(drFilaD, 2);

                drFilaD = odtD.NewRow();
                drFilaD.Delete();
                drFilaD[0] = "PDT PLANILLA ELECTRONICA - PLAME "; drFilaD[1] = "NUMERO DE ORDEN:";
                odtD.Rows.InsertAt(drFilaD, 3);
                /*------------Fin primera parte de la boleta de pago */

                //odtPlanilla = oPlanilla.ListarDetallePlanillaX(sidtplanilla);

                //sidttrabajador = Convert.ToInt16(odtPlanilla.Rows[0][1]);

                /*---------inicio parte a de boleta de pago */
                odtA = oBoletaPago.ListarPlanillaXMesYRegimenLaboralYTrabajadorA(sidtplanilla, sidtregimenlaboral , sidttrabajador, pmes, pmes_nro, paño);

                odtA.Columns.Add("DOCUMENTO DE IDENTIDAD", typeof(string)).SetOrdinal(0);
                odtA.Columns.Add("SITUACION", typeof(string));

                if (odtA.Rows.Count > 0)
                {

                    odtA.Rows[0][3] = "ACTIVO O SUBSIDIADO";
                    odtA.Rows[0][0] = "DNI";

                    /*---------fin de parte a de boleta de pago */


                    /*--------- inicio de parte c de boleta de pago, donde se aumentan columnas y se calcula dias no laborados asi como total de horas y minutos */
                    odtC = oBoletaPago.ListarPlanillaXMesYRegimenLaboralYTrabajadorC(sidtplanilla, sidtregimenlaboral, sidttrabajador, pmes, pmes_nro, paño);

                    odtC.Columns.Add("DIAS NO LABORADOS", typeof(string));
                    odtC.Columns.Add("DIAS SUBSIDIADOS", typeof(string));
                    odtC.Columns.Add("CONDICION", typeof(string));
                    odtC.Columns.Add("TOTAL HORAS", typeof(string));
                    odtC.Columns.Add("MINUTOS", typeof(string));
                    odtC.Columns.Add("TOTAL HORAS ", typeof(string));
                    odtC.Columns.Add("MINUTOS ", typeof(string));

                    dias_laborados = Convert.ToInt32(odtC.Rows[0][0]);

                    mes_dias = nro_dias_mes(8, 2016);

                    odtC.Rows[0][1] = mes_dias - dias_laborados;
                    odtC.Rows[0][2] = 0;
                    odtC.Rows[0][3] = "Domiciliado";
                    odtC.Rows[0][4] = dias_laborados * 8;
                    //odtC.Rows[0][5] = dias_laborados * 8 * 60;
                    odtC.Rows[0][5] = 0;
                    /*------------fin parte c de boleta de pago*/

                    /*---------------Inicio de Obligaciones de boleta de pago - Ingresos*/
                    odtE = oDetallePlanillaIngresos.ListarPlanillaXIngresosXBoletaPago(sidtplanilla, sidtregimenlaboral, sidttrabajador);

                    odtF.Columns.Add("Conceptos", typeof(string));
                    odtF.Columns.Add("Ingresos S/.", typeof(string));
                    odtF.Columns.Add("Descuentos S/.", typeof(string));
                    odtF.Columns.Add("Neto S/.", typeof(string));

                    int jj = 0;

                    if (odtE.Rows.Count > 0)
                    {
                        drFilaF = odtF.NewRow();
                        drFilaF.Delete();
                        drFilaF[0] = "Ingresos";
                        odtF.Rows.InsertAt(drFilaF, jj);
                        jj++;

                        for (int k = 0; k < odtE.Rows.Count; k++)
                        {
                            drFilaF = odtF.NewRow();
                            drFilaF.Delete();
                            drFilaF[0] = odtE.Rows[k][0];
                            drFilaF[1] = odtE.Rows[k][1];
                            odtF.Rows.InsertAt(drFilaF, jj);
                            jj++;
                        }
                    }

                    odtG = oDetallePlanillaDescuentos.ListarPlanillaXDescuentosXBoletaPago(sidtplanilla, sidtregimenlaboral, sidttrabajador);

                    if (odtG.Rows.Count > 0)
                    {
                        drFilaF = odtF.NewRow();
                        drFilaF.Delete();
                        drFilaF[0] = "Descuentos";
                        odtF.Rows.InsertAt(drFilaF, jj);
                        jj++;

                        for (int k = 0; k < odtG.Rows.Count; k++)
                        {
                            drFilaF = odtF.NewRow();
                            drFilaF.Delete();
                            drFilaF[0] = odtG.Rows[k][0];
                            drFilaF[2] = odtG.Rows[k][1];
                            odtF.Rows.InsertAt(drFilaF, jj);
                            jj++;
                        }
                    }

                    odtH = oDetallePlanillaATrabajador.ListarPlanillaATrabajadorXBoletaPago(sidtplanilla, sidtregimenlaboral, sidttrabajador);

                    if (odtH.Rows.Count > 0)
                    {
                        drFilaF = odtF.NewRow();
                        drFilaF.Delete();
                        drFilaF[0] = "Aportaciones de Trabajador";
                        odtF.Rows.InsertAt(drFilaF, jj);
                        jj++;

                        for (int k = 0; k < odtH.Rows.Count; k++)
                        {
                            drFilaF = odtF.NewRow();
                            drFilaF.Delete();
                            drFilaF[0] = odtH.Rows[k][0];
                            drFilaF[2] = odtH.Rows[k][1];
                            odtF.Rows.InsertAt(drFilaF, jj);
                            jj++;
                        }
                    }

                    /*------------Calculando el Neto S/.*/

                    decimal dIngresos = 0;
                    decimal dIngresosParcial = 0;
                    decimal dEgresos = 0;
                    decimal dEgresosParcial = 0;
                    decimal dNeto = 0;

                    for (int k = 0; k < odtF.Rows.Count; k++)
                    {
                        if (odtF.Rows[k][1].ToString() == "")
                            dIngresosParcial = 0;
                        else
                            dIngresosParcial = Convert.ToDecimal(odtF.Rows[k][1].ToString());

                        if (odtF.Rows[k][2].ToString() == "")
                            dEgresosParcial = 0;
                        else
                            dEgresosParcial = Convert.ToDecimal(odtF.Rows[k][2].ToString());

                        dIngresos += dIngresosParcial;
                        dEgresos += dEgresosParcial;
                    }

                    dNeto = dIngresos - dEgresos;

                    drFilaF = odtF.NewRow();
                    drFilaF.Delete();
                    drFilaF[0] = "Neto a Pagar";
                    drFilaF[3] = dNeto.ToString();
                    odtF.Rows.InsertAt(drFilaF, jj);
                    jj++;

                    /*-----------Fin Calculando el Neto*/

                    drFilaF = odtF.NewRow();
                    drFilaF.Delete();
                    drFilaF[0] = " ";
                    drFilaF[1] = " ";
                    drFilaF[2] = " ";
                    drFilaF[3] = " ";
                    odtF.Rows.InsertAt(drFilaF, jj);
                    jj++;
                    /*-----------Inicio Aportaciones del Empleador*/
                    odtI = oDetallePlanillaAEmpleador.ListarPlanillaAEmpleadorXBoletaPago(sidtplanilla, sidtregimenlaboral, sidttrabajador);

                    if (odtI.Rows.Count > 0)
                    {
                        drFilaF = odtF.NewRow();
                        drFilaF.Delete();
                        drFilaF[0] = "Aportaciones de Empleador";
                        odtF.Rows.InsertAt(drFilaF, jj);
                        jj++;

                        for (int k = 0; k < odtI.Rows.Count; k++)
                        {
                            drFilaF = odtF.NewRow();
                            drFilaF.Delete();
                            drFilaF[0] = odtI.Rows[k][0];
                            drFilaF[3] = odtI.Rows[k][1];
                            odtF.Rows.InsertAt(drFilaF, jj);
                            jj++;
                        }
                    }
                    /*------------Fin Aportaciones del Empleador*/

                    /*----------------Fin de obligaciones de boleta de pago - Ingresos*/

                    dgvBoletaPago_D.DataSource = odtD;
                    dgvBoletaPago_A.DataSource = odtA;
                    dgvBoletaPago_B.DataSource = oBoletaPago.ListarPlanillaXMesYRegimenLaboralYTrabajadorB(sidtplanilla, sidtregimenlaboral, sidttrabajador, pmes, pmes_nro, paño);
                    dgvBoletaPago_C.DataSource = odtC;
                    dgvBoletaPago_E.DataSource = odtF;

                    if (!estaAbierto)
                    {
                        exportar_a_pdf();
                    }
                    else
                        MessageBox.Show("Por favor cerrar BoletaPago.pdf", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Boleta de pago vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }else
                MessageBox.Show("Boleta de pago vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public int mayor(int a, int b)
        {
            int mayor = 0;

            if (a > b)
                mayor = a;
            else
                mayor = b;

            return mayor;
        }

        public float[] GetTamañoColumnas3(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
                if (i == 0) values[i] = 160;
            }
            return values;
        }

        public float[] GetTamañoColumnas2(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
            }
            return values;
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

            PdfPTable pdfTableD = new PdfPTable(dgvBoletaPago_D.ColumnCount);
            PdfPTable pdfTableA = new PdfPTable(dgvBoletaPago_A.ColumnCount);
            PdfPTable pdfTableB = new PdfPTable(dgvBoletaPago_B.ColumnCount);
            PdfPTable pdfTableC = new PdfPTable(dgvBoletaPago_C.ColumnCount);
            PdfPTable pdfTableE = new PdfPTable(dgvBoletaPago_E.ColumnCount);

            PdfPCell cell;
  
            int k = 0; int o = 0;

            if (dgvBoletaPago_D.ColumnCount > 0)
            {

                Phrase objH_D = new Phrase("A", fuente);
                Phrase objP_D = new Phrase("A", fuente);
                float[] headerwidths_D = GetTamañoColumnas2(dgvBoletaPago_D);
                pdfTableD.DefaultCell.Padding = 1;
                pdfTableD.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTableD.DefaultCell.BorderWidth = 1;
                pdfTableD.SetWidths(headerwidths_D);
                pdfTableD.WidthPercentage = 100;

                /* -------------------------------INICIO DGVBOLETA_D */
                foreach (DataGridViewColumn column in dgvBoletaPago_D.Columns)
                {
                    cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                    cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                    pdfTableD.AddCell(cell);
                }

                for (int i = 0; i < dgvBoletaPago_D.RowCount - 1; i++)
                {
                    for (int j = 0; j < dgvBoletaPago_D.ColumnCount; j++)
                    {
                        cell = new PdfPCell((new Phrase(dgvBoletaPago_D[j, i].Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                        cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        pdfTableD.AddCell(cell);
                    }
                    pdfTableD.CompleteRow();
                }
                /* -------------------------------FIN DGVBOLETA_D */
            }

            if (dgvBoletaPago_A.ColumnCount > 0) {
                
                Phrase objH_A = new Phrase("A", fuenteTitulo);
                Phrase objP_A = new Phrase("A", fuente);
                float[] headerwidths_A = GetTamañoColumnas(dgvBoletaPago_A);
                pdfTableA.DefaultCell.Padding = 1;
                pdfTableA.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTableA.DefaultCell.BorderWidth = 1;
                pdfTableA.SetWidths(headerwidths_A);
                pdfTableA.WidthPercentage = 100;
                
                /* -------------------------------INICIO DGVBOLETA_A */


                

                    foreach (DataGridViewColumn column in dgvBoletaPago_A.Columns)
                {
                    cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                    cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                    cell.Colspan = 1;
                    cell.Rowspan = 1;
                    if (k == 0) {
                        cell.Colspan = 2;
                        cell.HorizontalAlignment = 1;
                    }

                    if (k != 1) {
                        if (k>1)
                            cell.Rowspan = 2;

                        cell.HorizontalAlignment = 1;
                        pdfTableA.AddCell(cell);
                    }
                    
                    k++;
                }

                foreach (DataGridViewColumn column in dgvBoletaPago_A.Columns)
                {
                    
                    if (o == 0)
                    {
                        cell = new PdfPCell((new Phrase("TIPO", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                        cell.Rowspan = 1;
                        cell.Colspan = 1;
                        cell.HorizontalAlignment = 1;
                        cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        pdfTableA.AddCell(cell);
                    }
  
                    if (o == 1) {
                        cell = new PdfPCell((new Phrase("NUMERO", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                        cell.Rowspan = 1;
                        cell.Colspan = 1;
                        cell.HorizontalAlignment = 1;
                        cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        pdfTableA.AddCell(cell);
                    }
                        

                    
                    o++;

                }

                for (int i = 0; i < dgvBoletaPago_A.RowCount - 1; i++)
                {
                    for (int j = 0; j < dgvBoletaPago_A.ColumnCount; j++)
                    {
                        objP_A = new Phrase(dgvBoletaPago_A[j, i].Value.ToString(), fuente);
                        pdfTableA.AddCell(objP_A);
                    }
                    pdfTableA.CompleteRow();
                }
                /* -------------------------------FIN DGVBOLETA_A */
            }

            if (dgvBoletaPago_B.ColumnCount > 0) {

                Phrase objH_B = new Phrase("A", fuenteTitulo);
                Phrase objP_B = new Phrase("A", fuente);
                float[] headerwidths_B = GetTamañoColumnas2(dgvBoletaPago_B);
                pdfTableB.DefaultCell.Padding = 1;
                pdfTableB.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTableB.DefaultCell.BorderWidth = 1;
                pdfTableB.SetWidths(headerwidths_B);
                pdfTableB.WidthPercentage = 100;
                /* -------------------------------INICIO DGVBOLETA_B */

                foreach (DataGridViewColumn column in dgvBoletaPago_B.Columns)
                {
                    cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                    cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTableB.AddCell(cell);
                }

                for (int i = 0; i < dgvBoletaPago_B.RowCount - 1; i++)
                {
                    for (int j = 0; j < dgvBoletaPago_B.ColumnCount; j++)
                    {
                        objP_B = new Phrase(dgvBoletaPago_B[j, i].Value.ToString(), fuente);
                        pdfTableB.AddCell(objP_B);
                    }
                    pdfTableB.CompleteRow();
                }
                /* -------------------------------FIN DGVBOLETA_B */
            }

            if (dgvBoletaPago_C.ColumnCount > 0) {


                Phrase objH_C = new Phrase("A", fuenteTitulo);
                Phrase objP_C = new Phrase("A", fuente);
                float[] headerwidths_C = GetTamañoColumnas2(dgvBoletaPago_C);
                pdfTableC.DefaultCell.Padding = 1;
                pdfTableC.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTableC.DefaultCell.BorderWidth = 1;
                pdfTableC.SetWidths(headerwidths_C);
                pdfTableC.WidthPercentage = 100;
                /* -------------------------------INICIO DGVBOLETA_C */

                o = 0;
                foreach (DataGridViewColumn column in dgvBoletaPago_C.Columns)
                {

                    if (o == 4)
                    {
                        cell = new PdfPCell((new Phrase("JORNADA ORDINARIA", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                        cell.Colspan = 2;
                        cell.Rowspan = 1;
                        cell.HorizontalAlignment = 1;
                        cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        pdfTableC.AddCell(cell);
                    }

                    if (o == 6)
                    {
                        cell = new PdfPCell((new Phrase("SOBRE TIEMPO", new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                        cell.Colspan = 2;
                        cell.Rowspan = 1;
                        cell.HorizontalAlignment = 1;
                        cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        pdfTableC.AddCell(cell);
                    }

                    if (o < 4 || o > 7)
                    {
                        cell = new PdfPCell((new Phrase(column.HeaderText , new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                        cell.Rowspan = 2;
                        cell.Colspan = 1;
                        cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        pdfTableC.AddCell(cell);
                    }

                    o++;     
                }

                k = 0;
                
                foreach (DataGridViewColumn column in dgvBoletaPago_C.Columns)
                {
 
                    if (k == 4 || k == 5 || k == 6 || k == 7) { 
                        cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.Colspan = 1;
                        cell.Rowspan = 1;
                        cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        pdfTableC.AddCell(cell);
                    }

                    k ++;
                }



                for (int i = 0; i < dgvBoletaPago_C.RowCount - 1; i++)
                {
                    for (int j = 0; j < dgvBoletaPago_C.ColumnCount; j++)
                    {
                        objP_C = new Phrase(dgvBoletaPago_C[j, i].Value.ToString(), fuente);
                        pdfTableC.AddCell(objP_C);
                    }
                    pdfTableC.CompleteRow();
                }
                /* -------------------------------FIN DGVBOLETA_C */
            }



            if (dgvBoletaPago_E.ColumnCount > 0) {
                
                Phrase objH_E = new Phrase("A", fuenteTitulo);
                Phrase objP_E = new Phrase("A", fuente);
                float[] headerwidths_E = GetTamañoColumnas3(dgvBoletaPago_E);
                pdfTableE.DefaultCell.Padding = 1;
                pdfTableE.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTableE.DefaultCell.BorderWidth = 1;
                pdfTableE.SetWidths(headerwidths_E);
                pdfTableE.WidthPercentage = 100;

                /* -------------------------------INICIO DGVBOLETA_E */

                foreach (DataGridViewColumn column in dgvBoletaPago_E.Columns)
                {
                    cell = new PdfPCell((new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));
                    cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                    pdfTableE.AddCell(cell);
                }

                for (int i = 0; i < dgvBoletaPago_E.RowCount - 1; i++)
                {
                    for (int j = 0; j < dgvBoletaPago_E.ColumnCount; j++)
                    {
                        cell = new PdfPCell((new Phrase(dgvBoletaPago_E[j, i].Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 7f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK))));

                        if (dgvBoletaPago_E[j, i].Value.ToString() == "Aportaciones de Empleador")
                        {
                            cell.Colspan = 1;
                            cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        }
                        if (dgvBoletaPago_E[j, i].Value.ToString() == "Aportaciones de Trabajador")
                        {
                            cell.Colspan = 1;
                            cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        }
                        if (dgvBoletaPago_E[j, i].Value.ToString() == "Descuentos")
                        {
                            cell.Colspan = 1;
                            cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        }
                        if (dgvBoletaPago_E[j, i].Value.ToString() == "Ingresos")
                        {
                            cell.Colspan = 1;
                            cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        }
                        if (dgvBoletaPago_E[j, i].Value.ToString() == "Neto a Pagar")
                        {
                            cell.HorizontalAlignment = 1;
                            cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        }
                        //Alineando a la derecha la columna de ingresos, egresos y neto
                        if (j == 1 || j == 2 || j == 3  )
                            cell.HorizontalAlignment = Element.ALIGN_RIGHT;


                        pdfTableE.AddCell(cell);
                    }
                    pdfTableE.CompleteRow();
                }
                /* -------------------------------FIN DGVBOLETA_E */
 
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
            columns.AddRegularColumns(36f, pdfDoc.PageSize.Width - 36f, 24f, 2);

            //Agregando pdfTable A, B, C, D, E a pdfDoc
            columns.AddElement(pdfTableD);
            columns.AddElement(paragraph);
            columns.AddElement(pdfTableA);
            columns.AddElement(pdfTableB);
            columns.AddElement(pdfTableC);
            columns.AddElement(paragraph);
            columns.AddElement(pdfTableE);
            columns.AddElement(paragraph2);
            columns.AddElement(paragraph3);
 
            pdfDoc.Add(columns);

            pdfDoc.Close();
            //stream.Close();
            writer.Close();

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "C:\\PDFs\\BoletaPago.pdf";
            proc.Start();

        }
 

        private void dgvBoletaPago_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvBoletaPago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvBoletaPago_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
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
            }

            if (numero_boleta_pago == 0)
                MessageBox.Show("No hay datos para esta consulta.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    
    }
}
