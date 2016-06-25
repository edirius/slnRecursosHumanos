using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Tareo
{
    public partial class frmMantenimientoDetalleTareo : Form
    {
        DateTime auxiliar;

        DataTable oDataTrabajador = new DataTable();
        DataTable oDataAFP = new DataTable();
        DataTable oDataDetalleTareo = new DataTable();
        DataTable oDataTareo = new DataTable();

        CapaDeNegocios.Tareos.cTareo miTareo = new CapaDeNegocios.Tareos.cTareo();
        CapaDeNegocios.Tareos.cDetalleTareo miDetalleTareo = new CapaDeNegocios.Tareos.cDetalleTareo();
        CapaDeNegocios.cTrabajador miTrabajador = new CapaDeNegocios.cTrabajador();
        CapaDeNegocios.cListaAFP miAFP = new CapaDeNegocios.cListaAFP();
        CapaDeNegocios.Obras.cMeta miMeta = new CapaDeNegocios.Obras.cMeta();

        public frmMantenimientoDetalleTareo()
        {
            InitializeComponent();
        }

        private void frmMantenimientoDetalleTareo_Load(object sender, EventArgs e)
        {
            DibujarDataGrid(miTareo.FechaFin.Day - miTareo.FechaInicio.Day);
            oDataTrabajador = miTrabajador.ObtenerListaTrabajadores(true);
            oDataAFP = miAFP.ObtenerListaAFP();
            CargarDatos();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            int pIdTTareo = 0;
            int contador = 0;
            int fila = 0;
            dgvDetalleTareo.Rows.Clear();
            pIdTTareo = miTareo.IdTTareo;
            oDataTareo = miTareo.ListarTareo(miMeta);
            foreach (DataRow row1 in oDataTareo.Select("numero = '" + (Convert.ToInt32(txtNumero.Text) - 1) + "'"))
            {
                miTareo.IdTTareo = Convert.ToInt32(row1[0]);
            }
            oDataDetalleTareo = miDetalleTareo.ListarDetalleTareo(miTareo);
            foreach (DataRow row in oDataDetalleTareo.Rows)
            {
                contador += 1;
                dgvDetalleTareo.Rows.Add();
                fila = dgvDetalleTareo.RowCount - 1;
                dgvDetalleTareo.Rows[fila].Cells[1].Value = "I";
                dgvDetalleTareo.Rows[fila].Cells[3].Value = contador;
                dgvDetalleTareo.Rows[fila].Cells[8].Value = row[1].ToString();
                foreach (DataRow row1 in oDataTrabajador.Select("id_trabajador = '" + row[3].ToString() + "'"))
                {
                    dgvDetalleTareo.Rows[fila].Cells[4].Value = row1[0].ToString();
                    dgvDetalleTareo.Rows[fila].Cells[5].Value = row1[3].ToString() + " " + row1[4].ToString() + ", " + row1[2].ToString();
                    dgvDetalleTareo.Rows[fila].Cells[6].Value = row1[1].ToString();
                    foreach (DataRow row2 in oDataAFP.Select("idtafp = '1'"))
                    {
                        dgvDetalleTareo.Rows[fila].Cells[7].Value = row2[1].ToString();
                    }
                }
                for (int i = 0; i <= (miTareo.FechaFin.Day - miTareo.FechaInicio.Day); i++)
                {
                    auxiliar = miTareo.FechaInicio.AddDays(i);
                    if (auxiliar.DayOfWeek == DayOfWeek.Sunday)
                    {
                        dgvDetalleTareo.Rows[fila].Cells["col" + i.ToString()].Style.BackColor = Color.Red;
                        dgvDetalleTareo.Rows[fila].Cells[10 + i].Value = "D";
                    }
                }
                
            }
            if (contador == 0)
            {
                dgvDetalleTareo.Rows.Add();
                for (int i = 0; i <= (miTareo.FechaFin.Day - miTareo.FechaInicio.Day); i++)
                {
                    auxiliar = miTareo.FechaInicio.AddDays(i);
                    if (auxiliar.DayOfWeek == DayOfWeek.Sunday)
                    {
                        dgvDetalleTareo.Rows[fila].Cells["col" + i.ToString()].Style.BackColor = Color.Red;
                        dgvDetalleTareo.Rows[fila].Cells[10 + i].Value = "D";
                    }
                }
            }
            dgvDetalleTareo.CurrentCell = dgvDetalleTareo.CurrentRow.Cells[6];
            btnImportar.Enabled = false;
            miTareo.IdTTareo = pIdTTareo;
        }

        private void btnAprobacion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro de poner en aprobacion el Tareo de Obra, ya no podra Modificarlo.", "Confirmar Aprobacion", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            miTareo.Estado = true;
            miTareo.ModificarTareo(miTareo, miMeta);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnNuevoTrabajador_Click(object sender, EventArgs e)
        {
            Trabajador.frmNuevoObrero fNuevoObrero = new Trabajador.frmNuevoObrero();
            if (fNuevoObrero.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //CargarTrabajador();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool bOk = false;
            string diastareo = "";
            int contadordias = 0;
            foreach (DataGridViewRow row in dgvDetalleTareo.Rows)
            {
                contadordias = 0;
                diastareo = "";
                for (int i = 1; i <= 31; i++)
                {
                    if (i >= miTareo.FechaInicio.Day && i <= miTareo.FechaFin.Day)
                    {
                        if (Convert.ToString(row.Cells[9 + i - contadordias].Value) == "")
                        {
                            diastareo += "0";
                        }
                        diastareo += Convert.ToString(row.Cells[9 + i - contadordias].Value);
                    }
                    else
                    {
                        contadordias += 1;
                        diastareo += "0";
                    }
                }
                miDetalleTareo.IdTDetalleTareo = Convert.ToInt32(row.Cells[0].Value);
                miDetalleTareo.Categoria = Convert.ToString(row.Cells[8].Value);
                miDetalleTareo.DiasTareo = diastareo;
                miTrabajador.IdTrabajador = Convert.ToInt32(row.Cells[4].Value);
                if (Convert.ToString(row.Cells[1].Value) == "I")
                {
                    miDetalleTareo.CrearDetalleTareo(miDetalleTareo, miTrabajador, miTareo);
                    oDataDetalleTareo = miDetalleTareo.ListarDetalleTareo(miTareo);
                    miDetalleTareo.IdTDetalleTareo = Convert.ToInt32(oDataDetalleTareo.Compute("MAX(idtdetalletareo)", ""));
                    row.Cells[0].Value = miDetalleTareo.IdTDetalleTareo.ToString();
                    row.Cells[1].Value = "M";
                    //DateTime auxiliar;
                    //for (int i = 0; i <= (miTareo.FechaFin.Day - miTareo.FechaInicio.Day); i++)
                    //{
                    //    auxiliar = miTareo.FechaInicio.AddDays(i);
                    //    miDiasTareo.Fecha = auxiliar;
                    //    if (Convert.ToString(row.Cells[10 + i].Value) == "x")
                    //    {
                    //        miDiasTareo.Estado = true;
                    //    }
                    //    else
                    //    {
                    //        miDiasTareo.Estado = false;
                    //    }
                    //    miDiasTareo.CrearDiasTareo(miDiasTareo, miDetalleTareo);
                    //}
                    bOk = true;
                }
                if (Convert.ToString(row.Cells[1].Value) == "M")
                {
                    miDetalleTareo.ModificarDetalleTareo(miDetalleTareo, miTrabajador, miTareo);
                    bOk = true;
                }
            }
            if (bOk == false)
            {
                MessageBox.Show("No existen datos que se puedan registrar", "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CargarDatos();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void dgvDetalleTareo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetalleTareo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalleTareo.Rows[e.RowIndex].Cells[9].Selected == true)
            {
                //string xxx = Convert.ToString(dgvDetalleTareo.Rows[e.RowIndex].Cells[9].Value);
                //object xxxxx = dgvDetalleTareo.Rows[e.RowIndex].Cells[9].Value ;
                for (int i = 0; i <= (miTareo.FechaFin.Day - miTareo.FechaInicio.Day); i++)
                {
                    auxiliar = miTareo.FechaInicio.AddDays(i);
                    if (auxiliar.DayOfWeek != DayOfWeek.Sunday)
                    {
                        dgvDetalleTareo.Rows[e.RowIndex].Cells[10 + i].Value = "x";
                    }
                }
            }
            else if (dgvDetalleTareo.Rows[e.RowIndex].Cells[2].Selected == true)
            {
                if (Convert.ToString(dgvDetalleTareo.Rows[e.RowIndex].Cells[0].Value) == "")
                {
                    MessageBox.Show("No existena datos que se puedan Eliminar", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Está seguro que desea eliminar al Trabajador del Tareo de Obra", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
                miDetalleTareo.IdTDetalleTareo = Convert.ToInt32(dgvDetalleTareo.Rows[e.RowIndex].Cells[0].Value);
                miDetalleTareo.EliminarDetalleTareo(miDetalleTareo);
                CargarDatos();
            }
        }

        private void dgvDetalleTareo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalleTareo.Rows[e.RowIndex].Cells[6].Selected == true)
            {
                int contador = 0;
                foreach (DataRow row in oDataTrabajador.Select("dni = '" + dgvDetalleTareo.Rows[e.RowIndex].Cells[6].Value + "'"))
                {
                    contador += 1;
                    if (Convert.ToString(dgvDetalleTareo.Rows[e.RowIndex].Cells[1].Value) == "") { dgvDetalleTareo.Rows[e.RowIndex].Cells[1].Value = "I"; }
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[3].Value = e.RowIndex + 1;
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[4].Value = row[0].ToString();
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[5].Value = row[3].ToString() + " " + row[4].ToString() + ", " + row[2].ToString();
                    foreach (DataRow row1 in oDataAFP.Select("idtafp = '1'"))
                    {
                        dgvDetalleTareo.Rows[e.RowIndex].Cells[7].Value = row1[1].ToString();
                    }
                }
                if (contador == 0)
                {
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[5].Value = "";
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[6].Value = "";
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[7].Value = "";
                    MessageBox.Show("No existe el Trabajador, para agregar hacer clic en Nuevo Trabajador", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void dgvDetalleTareo_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string titleText = dgvDetalleTareo.Columns[6].HeaderText;
            if (titleText.Equals("DNI"))
            {
                TextBox autoText = e.Control as TextBox;
                if (autoText != null)
                {
                    autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
                    CargarTrabajador(DataCollection);
                    autoText.AutoCompleteCustomSource = DataCollection;
                }
            }
        }

        private void dgvDetalleTareo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dgvDetalleTareo.Rows.Add();
                for (int i = 0; i <= (miTareo.FechaFin.Day - miTareo.FechaInicio.Day); i++)
                {
                    auxiliar = miTareo.FechaInicio.AddDays(i);
                    if (auxiliar.DayOfWeek == DayOfWeek.Sunday)
                    {
                        dgvDetalleTareo.Rows[dgvDetalleTareo.RowCount - 1].Cells["col" + i.ToString()].Style.BackColor = Color.Red;
                        dgvDetalleTareo.Rows[dgvDetalleTareo.RowCount - 1].Cells[10 + i].Value = "D";
                    }
                }
                dgvDetalleTareo.CurrentCell = dgvDetalleTareo.CurrentRow.Cells[6];
            }
        }

        public void RecibirDatos(int pIdTTareo, int pNumero, DateTime pFechaInicio, DateTime pFechaFin, string pDescripcion, string pNombre, int pIdTMeta)
        {
            miTareo.IdTTareo = pIdTTareo;
            miTareo.Numero = pNumero;
            txtNumero.Text = Convert.ToString(pNumero);
            txtDesdeHasta.Text = Convert.ToString(pFechaInicio.ToLongDateString()) + "   -   " + Convert.ToString(pFechaFin.ToLongDateString());
            miTareo.FechaInicio = pFechaInicio;
            miTareo.FechaFin = pFechaFin;
            miTareo.Descripcion = pDescripcion;
            txtMeta.Text = pNombre;
            miMeta.Codigo = pIdTMeta;
        }

        private void CargarDatos()
        {
            int contador = 0, contadordias = 0;
            int fila = 0;
            int j, k = 0;
            string r = "";
            string diastareo = "";
            dgvDetalleTareo.Rows.Clear();
            oDataDetalleTareo = miDetalleTareo.ListarDetalleTareo(miTareo);
            foreach (DataRow row in oDataDetalleTareo.Rows)
            {
                contador += 1;
                dgvDetalleTareo.Rows.Add();
                fila = dgvDetalleTareo.RowCount - 1;
                dgvDetalleTareo.Rows[fila].Cells[0].Value = row[0].ToString();
                dgvDetalleTareo.Rows[fila].Cells[1].Value = "M";
                dgvDetalleTareo.Rows[fila].Cells[3].Value = contador;
                dgvDetalleTareo.Rows[fila].Cells[8].Value = row[1].ToString();
                foreach (DataRow row1 in oDataTrabajador.Select("id_trabajador = '" + row[3].ToString() + "'"))
                {
                    dgvDetalleTareo.Rows[fila].Cells[4].Value = row1[0].ToString();
                    dgvDetalleTareo.Rows[fila].Cells[5].Value = row1[3].ToString() + " " + row1[4].ToString() + ", " + row1[2].ToString();
                    dgvDetalleTareo.Rows[fila].Cells[6].Value = row1[1].ToString();
                    foreach (DataRow row2 in oDataAFP.Select("idtafp = '1'"))
                    {
                        dgvDetalleTareo.Rows[fila].Cells[7].Value = row2[1].ToString();
                    }
                }
                //miDetalleTareo.IdTDetalleTareo = Convert.ToInt32(row[0]);
                //CargarDiasTareo(fila);
                j = 0;
                contadordias = 0;
                diastareo = row[2].ToString();
                //if ((miTareo.FechaFin.Day - miTareo.FechaInicio.Day) > diastareo.Count()) { k = diastareo.Count() - 1; }
                //else { k = (miTareo.FechaFin.Day - miTareo.FechaInicio.Day); }
                for (int i = 1; i <= 31; i++)
                {
                    r = diastareo.Substring(i - 1, 1);
                    if (i >= miTareo.FechaInicio.Day && i <= miTareo.FechaFin.Day)
                    {
                        dgvDetalleTareo.Rows[fila].Cells[9 + i - contadordias].Value = r;
                        if (r == "x") { j += 1; }
                        auxiliar = miTareo.FechaInicio.AddDays(i - contadordias - 1);
                        if (auxiliar.DayOfWeek == DayOfWeek.Sunday)
                        {
                            int K = 0;
                            k = i - contadordias - 1;
                            dgvDetalleTareo.Rows[fila].Cells["col" + k.ToString()].Style.BackColor = Color.Red;
                            dgvDetalleTareo.Rows[fila].Cells[9 + i - contadordias].Value = "D";
                        }
                    }
                    else
                    {
                        contadordias += 1;
                    }
                }
                dgvDetalleTareo.Rows[fila].Cells[dgvDetalleTareo.ColumnCount - 1].Value = j;
                dgvDetalleTareo.CurrentCell = dgvDetalleTareo.CurrentRow.Cells[6];
            }
            if (contador == 0)
            {
                dgvDetalleTareo.Rows.Add();
                for (int i = 0; i <= (miTareo.FechaFin.Day - miTareo.FechaInicio.Day); i++)
                {
                    auxiliar = miTareo.FechaInicio.AddDays(i);
                    if (auxiliar.DayOfWeek == DayOfWeek.Sunday)
                    {
                        dgvDetalleTareo.Rows[fila].Cells["col" + i.ToString()].Style.BackColor = Color.Red;
                        dgvDetalleTareo.Rows[fila].Cells[10 + i].Value = "D";
                    }
                }
                dgvDetalleTareo.CurrentCell = dgvDetalleTareo.CurrentRow.Cells[6];
                btnImportar.Enabled = true;
            }
            else
            {
                btnImportar.Enabled = false;
            }
        }

        //public void CargarDiasTareo(int fila)
        //{
        //    int i = 0;
        //    int j = 0;
        //    oDataDiasTareo = miDiasTareo.ListarDiasTareo(miDetalleTareo);
        //    foreach (DataRow row in oDataDiasTareo.Rows)
        //    {
        //        if (Convert.ToInt32(row[2]) == 1)
        //        {
        //            j += 1;
        //            dgvDetalleTareo.Rows[fila].Cells[10 + i].Value = "x";
        //        }
        //        else
        //        {
        //            dgvDetalleTareo.Rows[fila].Cells[10 + i].Value = "";
        //        }
        //        i += 1;
        //    }

        //    dgvDetalleTareo.Rows[fila].Cells[dgvDetalleTareo.ColumnCount - 1].Value = j;
        //}

        public void CargarTrabajador(AutoCompleteStringCollection col)
        {
            foreach (DataRow row in oDataTrabajador.Rows)
            {
                col.Add(row[1].ToString());
            }
        }

        private void DibujarDataGrid(int pDias)
        {
            int j = dgvDetalleTareo.ColumnCount;
            for (int i = 0; i <= pDias; i++)
            {
                auxiliar = miTareo.FechaInicio.AddDays(i);
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Name = "col" + i.ToString();
                string auxiliarDiaSemana = "";
                switch (auxiliar.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        auxiliarDiaSemana = "L " + auxiliar.Day;
                        break;
                    case DayOfWeek.Tuesday:
                        auxiliarDiaSemana = "M " + auxiliar.Day;
                        break;
                    case DayOfWeek.Wednesday:
                        auxiliarDiaSemana = "M " + auxiliar.Day;
                        break;
                    case DayOfWeek.Friday:
                        auxiliarDiaSemana = "V " + auxiliar.Day;
                        break;
                    case DayOfWeek.Thursday:
                        auxiliarDiaSemana = "J " + auxiliar.Day;
                        break;
                    case DayOfWeek.Saturday:
                        auxiliarDiaSemana = "S " + auxiliar.Day;
                        break;
                    case DayOfWeek.Sunday:
                        auxiliarDiaSemana = "D " + auxiliar.Day;
                        break;
                    default:
                        break;
                }
                col.HeaderText = auxiliarDiaSemana;
                col.Width = 20;
                dgvDetalleTareo.Columns.Add(col);
                dgvDetalleTareo.Columns["col" + i.ToString()].DisplayIndex = 10 + i;
                if (auxiliar.DayOfWeek == DayOfWeek.Sunday)
                {
                    dgvDetalleTareo.Columns["col" + i.ToString()].ReadOnly = true;
                }
            }
            DataGridViewTextBoxColumn TotalDias = new DataGridViewTextBoxColumn();
            TotalDias.Name = "txtTotalDias";
            TotalDias.HeaderText = "Total Dias";
            TotalDias.Width = 40;
            dgvDetalleTareo.Columns.Add(TotalDias);
        }
    }
}
