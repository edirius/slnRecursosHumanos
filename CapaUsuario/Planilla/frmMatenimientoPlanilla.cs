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
//using iTextSharp.text.pdf.PdfWriter;

namespace CapaUsuario.Planilla
{
    public partial class frmMatenimientoPlanilla : Form
    {
        int sidtplanilla = 0;
        string snumero = "";
        string smes = "";
        string saño = "";
        DateTime sfecha;
        int sidtmeta = 0;
        int sidtfuentefinanciamiento = 0;
        int sidtregimenlaboral = 0;
        string smeta = "";
        string sfuentefinanciamiento = "";

        CapaUsuario.Reportes.frmPlanilla fPlanilla = new CapaUsuario.Reportes.frmPlanilla();
        CapaDeNegocios.Planillas.cPlanilla miPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

        

        public frmMatenimientoPlanilla()
        {
            InitializeComponent();
        }

        private void frmMatenimientoPlanilla_Load(object sender, EventArgs e)
        {
            CargarRegimenLaboral();
            cboRegimenLaboral_SelectedIndexChanged(sender, e);
        }

        private void btnTipoTrabajador_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CapaUsuario.Planilla.frmPlanilla fPlanilla = new frmPlanilla();
            fPlanilla.RecibirDatos(0, "", "", "", DateTime.Today, 0, "", 0, "", sidtregimenlaboral, 1);
            if (fPlanilla.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (sidtplanilla == 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CapaUsuario.Planilla.frmPlanilla fPlanilla = new frmPlanilla();
            fPlanilla.RecibirDatos(sidtplanilla, snumero, smes, saño, sfecha, sidtmeta, smeta, sidtfuentefinanciamiento, sfuentefinanciamiento, sidtregimenlaboral, 2);
            if (fPlanilla.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (sidtplanilla == 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Está seguro que desea eliminar la Planilla", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            miPlanilla.EliminarPlanilla(sidtplanilla);
            CargarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDetallePlanilla_Click(object sender, EventArgs e)
        {
            CapaUsuario.frmPrincipal fPrincipal = new frmPrincipal();
            CapaUsuario.Planilla.frmMantenimientoDetallePlanilla fMantenimientoDetallePlanilla = new frmMantenimientoDetallePlanilla();
            fMantenimientoDetallePlanilla.RecibirDatos(sidtplanilla, snumero, smes, saño, sidtmeta, smeta, sidtfuentefinanciamiento, sfuentefinanciamiento, sidtregimenlaboral, cboRegimenLaboral.Text);
            //fMantenimientoDetallePlanilla.MdiParent = fPrincipal;
            if (fMantenimientoDetallePlanilla.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
            //fMantenimientoDetallePlanilla.Show();
        }

        public int BuscarIndiceColumna(DataTable odtPrueba, string titulo_columna)
        {
            int k = 0;
            //reseteando contador de indice de ingreso
            k = 0;
            int indice_titulo_buscado = -1;
            //Determinar si existe el tipo de ingreso en las columnas de odtPrueba
            foreach (DataColumn column in odtPrueba.Columns)
            {
                //comparar si el nombre de columna del datatable es igual a la descripcion del ingreso
                if (column.ColumnName.ToString().Trim() == titulo_columna.Trim())
                {
                    //guardar indice de tipo ingreso
                    indice_titulo_buscado = k;
                }
                k++;
            }

            return indice_titulo_buscado;
        }

        public bool ExisteColumna(DataTable odtPrueba, DataRow row_i)
        {

            bool fIngreso = false;

            //reseteando contador de indice de ingreso

            fIngreso = false;
            //Determinar si existe el tipo de ingreso en las columnas de odtPrueba
            foreach (DataColumn column in odtPrueba.Columns)
            {
                //comparar si el nombre de columna del datatable es igual a la descripcion del ingreso
                if (column.ColumnName.ToString().Trim() == row_i[9].ToString().Trim())
                {
                    //guardar indice de tipo ingreso
                    fIngreso = true;
                }

            }

            return fIngreso;
        }

        public bool ExisteColumnaTexto(DataTable odtPrueba, string row_i)
        {

            bool fIngreso = false;

            //reseteando contador de indice de ingreso

            fIngreso = false;
            //Determinar si existe el tipo de ingreso en las columnas de odtPrueba
            foreach (DataColumn column in odtPrueba.Columns)
            {
                //comparar si el nombre de columna del datatable es igual a la descripcion del ingreso
                if (column.ColumnName.ToString().Trim() == row_i)
                {
                    //guardar indice de tipo ingreso
                    fIngreso = true;
                }

            }

            return fIngreso;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataTable odtPrueba = new DataTable();
            DataTable odtPruebaCorta = new DataTable();

            DataTable odtPlanilla = new DataTable();
            DataTable odtPlanillaXIngresos = new DataTable();
            DataTable odtPlanillaXDescuentos = new DataTable();
            DataTable odtPlanillaAEmpleador = new DataTable();
            DataTable odtPlanillaATrabajador = new DataTable();


            CapaDeNegocios.Planillas.cDetallePlanilla oPlanilla = new CapaDeNegocios.Planillas.cDetallePlanilla();
            CapaDeNegocios.Planillas.cDetallePlanillaIngresos oPlanillaIngresos = new CapaDeNegocios.Planillas.cDetallePlanillaIngresos();
            CapaDeNegocios.Planillas.cDetallePlanillaDescuentos oPlanillaDescuentos = new CapaDeNegocios.Planillas.cDetallePlanillaDescuentos();
            CapaDeNegocios.Planillas.cDetallePlanillaATrabajador oPlanillaTrabajador = new CapaDeNegocios.Planillas.cDetallePlanillaATrabajador();
            CapaDeNegocios.Planillas.cDetallePlanillaAEmpleador oPlanillaEmpleador = new CapaDeNegocios.Planillas.cDetallePlanillaAEmpleador();

            //Mes  y Regimen laboral

            int pRegimenLaboral = 1;
            string pMes = "ENERO";
            int pidTrabajador = 0;
            int indice_ingreso = 0;
            int indice_descuento = 0;
            int indice_a_empleador = 0;
            int indice_a_trabajador = 0;

            int total_tipo_ingreso = 0;
            int total_tipo_descuento = 0;
            int total_tipo_a_empleador = 0;
            int total_tipo_a_trabajador = 0;

            int[] arr_ingresos = new int[160];
            int[] arr_descuento = new int[160];
            int[] arr_a_empleador = new int[160];
            int[] arr_a_trabajador = new int[160];

            int k = 0;
            int t = 0;
            DataRow drFila = odtPrueba.NewRow();
            DataRow drFilaCorta = odtPruebaCorta.NewRow();

            //Establecer titulos de la planilla

            odtPrueba.Columns.Add("NOMBRE COMPLETO", typeof(string));
            odtPrueba.Columns.Add("CARGO", typeof(string));
            odtPrueba.Columns.Add("DNI", typeof(string));
            odtPrueba.Columns.Add("REMUNERACION", typeof(string));
            odtPrueba.Columns.Add("FECHA INICIO", typeof(string));
            odtPrueba.Columns.Add("REMUNERACION TOTAL", typeof(string));
            odtPrueba.Columns.Add("SEC. FUNC.", typeof(string));
            odtPrueba.Columns.Add("AFIL. AFP/SNP", typeof(string));
            odtPrueba.Columns.Add("COMISION", typeof(string));
            odtPrueba.Columns.Add("CUSP", typeof(string));

            //realizar consulta para planilla por mes y regimen laboral


            //odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboral(pMes, pRegimenLaboral);
            //Determinar si la consulta esta vacio
            odtPlanilla = oPlanilla.ListarPlanillaXMesYRegimenLaboral(pMes, pRegimenLaboral);

            odtPrueba.Clear();

            //recorrer consulta de planilla por mes y regimen laboral
            foreach (DataRow row in odtPlanilla.Rows)
            {

                drFila = odtPrueba.NewRow();
                drFila.Delete();
                //Determinar en base al id del trabajador sus ingresos
                pidTrabajador = Convert.ToInt32(row[6]);
                odtPlanillaXIngresos = oPlanillaIngresos.spListarPlanillaXIngresos(pMes, pRegimenLaboral, pidTrabajador);

                foreach (DataRow row_i in odtPlanillaXIngresos.Rows)
                {
                    // si no existe columna agregar titulo
                    if (!ExisteColumna(odtPrueba, row_i))
                    {
                        odtPrueba.Columns.Add(row_i[9].ToString().Trim(), typeof(string));
                        total_tipo_ingreso++;

                    }
                    //Buscar indice del titulo respectivo al monto
                    indice_ingreso = BuscarIndiceColumna(odtPrueba, row_i[9].ToString());

                    //insertar monto de ingresos a la planilla
                    if (row_i[10].ToString() == "")
                        drFila[indice_ingreso] = 0.00;
                    else
                        drFila[indice_ingreso] = row_i[10];
                }

                //Insertando la sumatoria total de ingresos
                // Insertando la descripcion de columna del total de ingresos
                if (!ExisteColumnaTexto(odtPrueba, "TOTAL INGRESOS"))
                    odtPrueba.Columns.Add("TOTAL INGRESOS", typeof(string));

                //Buscar indice del titulo respectivo al monto
                indice_ingreso = BuscarIndiceColumna(odtPrueba, "TOTAL INGRESOS");

                //insertar monto total de ingresos a la planilla
                drFila[indice_ingreso] = row[15].ToString();


                //Determinar en base al id del trabajador sus descuentos
                odtPlanillaXDescuentos = oPlanillaDescuentos.spListarPlanillaXDescuentos(pMes, pRegimenLaboral, pidTrabajador);

                foreach (DataRow row_d in odtPlanillaXDescuentos.Rows)
                {
                    // si no existe columna agregar titulo
                    if (!ExisteColumna(odtPrueba, row_d))
                    {
                        odtPrueba.Columns.Add(row_d[9].ToString().Trim(), typeof(string));
                        total_tipo_descuento++;
                    }
                    //Buscar indice del titulo respectivo al monto
                    indice_descuento = BuscarIndiceColumna(odtPrueba, row_d[9].ToString());

                    //insertar monto de ingresos a la planilla
                    if (row_d[10].ToString() == "")
                        drFila[indice_descuento] = 0.00;
                    else
                        drFila[indice_descuento] = row_d[10];

                }

                //Insertando la sumatoria total de descuentos
                // Insertando la descripcion de columna del total de descuentos
                if (!ExisteColumnaTexto(odtPrueba, "TOTAL DESCUENTOS"))
                    odtPrueba.Columns.Add("TOTAL DESCUENTOS", typeof(string));

                //Buscar indice del titulo respectivo al monto
                indice_descuento = BuscarIndiceColumna(odtPrueba, "TOTAL DESCUENTOS");

                //insertar monto total de descuentos a la planilla
                drFila[indice_descuento] = row[14].ToString();


                //Determinar en base al id del trabajador sus aportaciones del trabajador
                odtPlanillaATrabajador = oPlanillaTrabajador.ListarPlanillaATrabajador(pMes, pRegimenLaboral, pidTrabajador);

                foreach (DataRow row_t in odtPlanillaATrabajador.Rows)
                {
                    // si no existe columna agregar titulo
                    if (!ExisteColumna(odtPrueba, row_t))
                    {
                        odtPrueba.Columns.Add(row_t[9].ToString().Trim(), typeof(string));
                        total_tipo_a_trabajador++;
                        arr_a_trabajador[t] = odtPrueba.Columns.Count;
                        t++;
                    }
                    //Buscar indice del titulo respectivo al monto
                    indice_a_trabajador = BuscarIndiceColumna(odtPrueba, row_t[9].ToString());

                    //insertar monto de ingresos a la planilla
                    if (row_t[10].ToString() == "")
                        drFila[indice_a_trabajador] = 0.00;
                    else
                        drFila[indice_a_trabajador] = row_t[10];

                }

                //Insertando la sumatoria total de Aportaciones Empleador
                // Insertando la descripcion de columna del total de Empleador
                if (!ExisteColumnaTexto(odtPrueba, "TOTAL APORTACIONES TRABAJADOR"))
                    odtPrueba.Columns.Add("TOTAL APORTACIONES TRABAJADOR", typeof(string));

                //Buscar indice del titulo respectivo al monto
                indice_a_trabajador = BuscarIndiceColumna(odtPrueba, "TOTAL APORTACIONES TRABAJADOR");

                //insertar monto total de Empleador a la planilla
                drFila[indice_a_trabajador] = row[13].ToString();

                //Determinar en base al id del trabajador sus aportaciones del empleador
                odtPlanillaAEmpleador = oPlanillaEmpleador.ListarPlanillaAEmpleador(pMes, pRegimenLaboral, pidTrabajador);

                foreach (DataRow row_e in odtPlanillaAEmpleador.Rows)
                {
                    // si no existe columna agregar titulo
                    if (!ExisteColumna(odtPrueba, row_e))
                    {
                        odtPrueba.Columns.Add(row_e[9].ToString().Trim(), typeof(string));
                        total_tipo_a_empleador++;
                    }
                    //Buscar indice del titulo respectivo al monto
                    indice_a_empleador = BuscarIndiceColumna(odtPrueba, row_e[9].ToString());

                    //insertar monto de ingresos a la planilla
                    if (row_e[10].ToString() == "")
                        drFila[indice_a_empleador] = 0.00;
                    else
                        drFila[indice_a_empleador] = row_e[10];

                }

                //Insertando la sumatoria total de Aportaciones Empleador
                // Insertando la descripcion de columna del total de Empleador
                if (!ExisteColumnaTexto(odtPrueba, "TOTAL APORTACIONES EMPLEADOR"))
                    odtPrueba.Columns.Add("TOTAL APORTACIONES EMPLEADOR", typeof(string));

                //Buscar indice del titulo respectivo al monto
                indice_a_empleador = BuscarIndiceColumna(odtPrueba, "TOTAL APORTACIONES EMPLEADOR");

                //insertar monto total de Empleador a la planilla
                drFila[indice_a_empleador] = row[12].ToString();

                //insertar datos personales de la planilla al datatable

                drFila[0] = row[0]; drFila[3] = row[3]; drFila[6] = row[6];
                drFila[1] = row[1]; drFila[4] = row[4]; drFila[7] = row[7];
                drFila[2] = row[2]; drFila[5] = row[5]; drFila[8] = row[8]; drFila[9] = row[9];

                //odtPrueba.Rows.Add(drFila);
                odtPrueba.Rows.InsertAt(drFila, k);

                k++;
            }

            //Rellenar con 0.00  los campos en blanco

            for (int i = 0; i < odtPrueba.Columns.Count; i++)
            {
                for (int l = 0; l < odtPrueba.Rows.Count; l++)
                {
                    if (odtPrueba.Rows[l][i].ToString().Trim() == "")
                        odtPrueba.Rows[l][i] = "0.00";
                }
            }

            //Establecer titulos de la planilla

            odtPruebaCorta.Columns.Add("NOMBRE COMPLETO", typeof(string));
            odtPruebaCorta.Columns.Add("CARGO", typeof(string));
            odtPruebaCorta.Columns.Add("DNI", typeof(string));
            odtPruebaCorta.Columns.Add("REMUNERACION", typeof(string));
            odtPruebaCorta.Columns.Add("FECHA INICIO", typeof(string));
            odtPruebaCorta.Columns.Add("REMUNERACION TOTAL", typeof(string));
            odtPruebaCorta.Columns.Add("SEC. FUNC.", typeof(string));
            odtPruebaCorta.Columns.Add("AFIL. AFP/SNP", typeof(string));
            odtPruebaCorta.Columns.Add("COMISION", typeof(string));
            odtPruebaCorta.Columns.Add("CUSP", typeof(string));

            //Unir descripciones de trabajador en maximo dos columnas


            /*
            int DivisionTrabajador = Convert.ToInt32( total_tipo_a_trabajador / 2 );
            for (int m=0 ; m<  ; )
            odtPruebaCorta.
            */
            this.dgvPrueba.DataSource = odtPrueba;

            /*
            if (SetupThePrinting(dgvPrueba, "Reporte"))
                MyPrintDocument.Print();
            */

            //var doc1 = new Document();

            exportar_a_pdf();

        }

        private void exportar_a_pdf()
        {
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(dgvPrueba.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 30;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            //Adding Header row
            foreach (DataGridViewColumn column in dgvPrueba.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in dgvPrueba.Rows)
            {
                foreach (DataGridViewCell celda in row.Cells)
                {
                    //pdfTable.AddCell(cell.Value.ToString());
                    pdfTable.AddCell(celda.Value.ToString());
                }
            }

            //Exporting to PDF
            string folderPath = "C:\\PDFs\\";

            //use a variable to let my code fit across the page...
            //string path = Server.MapPath("PDFs");
            //PdfWriter.GetInstance(doc1, new FileStream(path + "/Doc1.pdf", FileMode.Create));

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "DataGridViewExport.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
        }

        private void cboRegimenLaboral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRegimenLaboral.Text != "System.Data.DataRowView" && cboRegimenLaboral.ValueMember != "")
            {
                sidtregimenlaboral = Convert.ToInt32(cboRegimenLaboral.SelectedValue);
                CargarDatos();
            }
        }

        private void dgvPlanilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPlanilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                sidtplanilla = Convert.ToInt32(dgvPlanilla.Rows[e.RowIndex].Cells[0].Value);
                snumero = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[1].Value);
                smes = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[2].Value);
                saño = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[3].Value);
                sfecha = Convert.ToDateTime(dgvPlanilla.Rows[e.RowIndex].Cells[4].Value);
                sidtmeta = Convert.ToInt32(dgvPlanilla.Rows[e.RowIndex].Cells[5].Value);
                smeta = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[6].Value);
                sidtfuentefinanciamiento = Convert.ToInt32(dgvPlanilla.Rows[e.RowIndex].Cells[7].Value);
                sfuentefinanciamiento = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[8].Value);
                fPlanilla.RecibirDatos(Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[1].Value) );
            }
        }

        private void CargarRegimenLaboral()
        {
            CapaDeNegocios.DatosLaborales.cRegimenLaboral miRegimenLaboral = new CapaDeNegocios.DatosLaborales.cRegimenLaboral();
            cboRegimenLaboral.DataSource = miRegimenLaboral.ListarRegimenLaboral();
            cboRegimenLaboral.DisplayMember = "descripcion";
            cboRegimenLaboral.ValueMember = "idtregimenlaboral";
        }

        private void CargarDatos()
        {
            dgvPlanilla.Rows.Clear();
            DataTable oDataPlanilla = new DataTable();
            oDataPlanilla = miPlanilla.ListarPlanilla(sidtregimenlaboral);

            DataTable oDataMeta = new DataTable();
            CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miMeta = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
            oDataMeta = miMeta.ListarMetas();
            DataTable oDataFuenteFinanciamiento = new DataTable();
            CapaDeNegocios.cFuenteFinanciamiento miFuenteFinanciamietno = new CapaDeNegocios.cFuenteFinanciamiento();
            oDataFuenteFinanciamiento = miFuenteFinanciamietno.ListarFuenteFinanciamiento();

            foreach (DataRow row in oDataPlanilla.Rows)
            {
                foreach (DataRow roww in oDataMeta.Select("idtmeta ='" + row[5].ToString() + "'"))
                {
                    sidtmeta = Convert.ToInt32(roww[0]);
                    smeta = roww[2].ToString();
                }
                foreach (DataRow roww in oDataFuenteFinanciamiento.Select("idtfuentefinanciamiento ='" + row[6].ToString() + "'"))
                {
                    sidtfuentefinanciamiento = Convert.ToInt32(roww[0]);
                    sfuentefinanciamiento = roww[2].ToString();
                }
                dgvPlanilla.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), sidtmeta, smeta, sidtfuentefinanciamiento, sfuentefinanciamiento);
                
            }
            if (dgvPlanilla.Rows.Count > 0)
            {
                DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, dgvPlanilla.Rows.Count - 1);
                dgvPlanilla.Rows[dgvPlanilla.Rows.Count - 1].Selected = true;
                dgvPlanilla_CellClick(dgvPlanilla, cea);
            }
        }
    }
}
