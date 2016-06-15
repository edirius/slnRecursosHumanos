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
        DataTable oDataTrabajador = new DataTable();
        DataTable oDataAFP = new DataTable();
        DataTable oDataDetalleTareo = new DataTable();
        DataTable oDataDiasTareo = new DataTable();

        CapaDeNegocios.Tareos.cTareo miTareo = new CapaDeNegocios.Tareos.cTareo();
        CapaDeNegocios.Tareos.cDetalleTareo miDetalleTareo = new CapaDeNegocios.Tareos.cDetalleTareo();
        CapaDeNegocios.Tareos.cDiasTareo miDiasTareo = new CapaDeNegocios.Tareos.cDiasTareo();
        CapaDeNegocios.cTrabajador miTrabajador = new CapaDeNegocios.cTrabajador();
        CapaDeNegocios.cListaAFP miAFP = new CapaDeNegocios.cListaAFP();

        public frmMantenimientoDetalleTareo()
        {
            InitializeComponent();
        }

        //public cTareo miTareo;
        //cDetalleTareo miDetalleTareo = new cDetalleTareo();

        //cListaAFP miListaAFP = new cListaAFP();
        //cAFP miAFP = new cAFP();
        //Boolean PrimerDibujo = false;

        private void frmMantenimientoDetalleTareo_Load(object sender, EventArgs e)
        {
            DibujarDataGrid(miTareo.FechaFin.Day - miTareo.FechaInicio.Day);
            oDataTrabajador = miTrabajador.ObtenerListaTrabajadores(true);
            oDataAFP = miAFP.ObtenerListaAFP();
            CargarDatos();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {

        }

        private void btnAprobacion_Click(object sender, EventArgs e)
        {

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
            foreach (DataGridViewRow row in dgvDetalleTareo.Rows)
            {
                if (Convert.ToString(row.Cells[1].Value) == "I")
                {
                    miDetalleTareo.Categoria = Convert.ToString(row.Cells[8].Value);
                    miTrabajador.IdTrabajador = Convert.ToInt32(row.Cells[4].Value);
                    miDetalleTareo.CrearDetalleTareo(miDetalleTareo, miTrabajador, miTareo);
                    oDataDetalleTareo = miDetalleTareo.ListarDetalleTareo(miTareo);
                    miDetalleTareo.IdTDetalleTareo = Convert.ToInt32(oDataDetalleTareo.Compute("MAX(idtdetalletareo)", ""));
                    row.Cells[0].Value = miDetalleTareo.IdTDetalleTareo.ToString();
                    row.Cells[1].Value = "M";
                    DateTime auxiliar;
                    for (int i = 0; i <= (miTareo.FechaFin.Day - miTareo.FechaInicio.Day); i++)
                    {
                        auxiliar = miTareo.FechaInicio.AddDays(i);
                        miDiasTareo.Fecha = auxiliar;
                        if (Convert.ToString(row.Cells[10 + i].Value) == "x")
                        {
                            miDiasTareo.Estado = true;
                        }
                        else
                        {
                            miDiasTareo.Estado = false;
                        }
                        miDiasTareo.CrearDiasTareo(miDiasTareo, miDetalleTareo);
                    }
                    bOk = true;
                }
                if (Convert.ToString(row.Cells[1].Value) == "M")
                {
                    //miTareo.ModificarTareo(miTareo, miMeta);
                    bOk = true;
                }
            }
            if (bOk == false)
            {
                MessageBox.Show("No existen datos que se puedan registrar", "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dgvDetalleTareo.Rows[e.RowIndex].Cells[9].Value = true;
                dgvDetalleTareo.EndEdit();
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
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[1].Value = "I";
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
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[3].Value = "";
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[4].Value = "";
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[5].Value = "";
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[6].Value = "";
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[7].Value = "";
                    MessageBox.Show("No existe el Trabajador, para agregar hacer clic en Nuevo Trabajador", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (dgvDetalleTareo.Rows[e.RowIndex].Cells[9].Selected == true)
            {
                for (int i = 0; i <= (miTareo.FechaFin.Day - miTareo.FechaInicio.Day); i++)
                {
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[10 + i].Value = "x";
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
                dgvDetalleTareo.CurrentCell = dgvDetalleTareo.CurrentRow.Cells[6];
            }
        }

        private void dgvDetalleTareos_Paint(object sender, PaintEventArgs e)
        {
            //for (int j = 4; j < (4 + miTareo.MiDetalleTareo.Dias.Count); j++)
            //{
            //    Rectangle r1 = this.dtgListaTareos.GetCellDisplayRectangle(j, -1, true);
            //    //r1.X += 1;
            //    r1.Y += 1;
            //    //r1.Width = r1.Width * 2 - 2;
            //    r1.Height = r1.Height / 2 - 2;
            //    e.Graphics.FillRectangle(new SolidBrush(this.dtgListaTareos.ColumnHeadersDefaultCellStyle.BackColor), r1);
            //    StringFormat format = new StringFormat();
            //    format.Alignment = StringAlignment.Center;
            //    format.LineAlignment = StringAlignment.Center;
            //    e.Graphics.DrawString(miTareo.MiDetalleTareo.Dias[j - 4].Fecha.Day.ToString(), this.dtgListaTareos.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(this.dtgListaTareos.ColumnHeadersDefaultCellStyle.ForeColor), r1, format);
            //    //j += 2;
            //}
        }

        public void RecibirDatos(int pIdTTareo, int pNumero, DateTime pFechaInicio, DateTime pFechaFin, string pNombre)
        {
            miTareo.IdTTareo = pIdTTareo;
            txtNumero.Text = Convert.ToString(pNumero);
            txtDesdeHasta.Text = Convert.ToString(pFechaInicio.ToLongDateString()) + "   -   " + Convert.ToString(pFechaFin.ToLongDateString());
            miTareo.FechaInicio = pFechaInicio;
            miTareo.FechaFin = pFechaFin;
            txtMeta.Text = pNombre;
        }

        private void CargarDatos()
        {
            int contador = 0;
            int fila = 0;
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
                dgvDetalleTareo.Rows[fila].Cells[4].Value = row[2].ToString();
                foreach (DataRow row1 in oDataTrabajador.Select("id_trabajador = '" + dgvDetalleTareo.Rows[fila].Cells[4].Value + "'"))
                {
                    dgvDetalleTareo.Rows[fila].Cells[4].Value = row1[0].ToString();
                    dgvDetalleTareo.Rows[fila].Cells[5].Value = row1[3].ToString() + " " + row1[4].ToString() + ", " + row1[2].ToString();
                    dgvDetalleTareo.Rows[fila].Cells[6].Value = row1[1].ToString();
                    foreach (DataRow row2 in oDataAFP.Select("idtafp = '1'"))
                    {
                        dgvDetalleTareo.Rows[fila].Cells[7].Value = row2[1].ToString();
                    }
                }
                miDetalleTareo.IdTDetalleTareo = Convert.ToInt32(row[0]);
                CargarDiasTareo(fila);
                dgvDetalleTareo.CurrentCell = dgvDetalleTareo.CurrentRow.Cells[6];
            }
            if (contador == 0)
            {
                dgvDetalleTareo.Rows.Add();
                dgvDetalleTareo.CurrentCell = dgvDetalleTareo.CurrentRow.Cells[6];
                btnImportar.Enabled = true;
            }
            else
            {
                btnImportar.Enabled = false;
            }
        }

        public void CargarDiasTareo(int fila)
        {
            int i = 0;
            int j = 0;
            oDataDiasTareo = miDiasTareo.ListarDiasTareo(miDetalleTareo);
            dataGridView1.DataSource = miDiasTareo.ListarDiasTareo(miDetalleTareo);
            foreach (DataRow row in oDataDiasTareo.Rows)
            {
                if (Convert.ToInt32(row[2]) == 1)
                {
                    j += 1;
                    dgvDetalleTareo.Rows[fila].Cells[10 + i].Value = "x";
                }
                else
                {
                    dgvDetalleTareo.Rows[fila].Cells[10 + i].Value = "";
                }
                i += 1;
            }

            dgvDetalleTareo.Rows[fila].Cells[dgvDetalleTareo.ColumnCount - 1].Value = j;
        }

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
            DateTime auxiliar;
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
            }
            DataGridViewTextBoxColumn TotalDias = new DataGridViewTextBoxColumn();
            TotalDias.Name = "txtTotalDias";
            TotalDias.HeaderText = "Total Dias";
            TotalDias.Width = 40;
            dgvDetalleTareo.Columns.Add(TotalDias);
        }
    }
}
