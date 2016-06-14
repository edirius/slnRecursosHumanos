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

        CapaDeNegocios.Tareos.cDetalleTareo miDetalleTareo = new CapaDeNegocios.Tareos.cDetalleTareo();
        CapaDeNegocios.Tareos.cTareo miTareo = new CapaDeNegocios.Tareos.cTareo();
        CapaDeNegocios.cListaTrabajadores miListaTrabajadores = new CapaDeNegocios.cListaTrabajadores();

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

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvDetalleTareo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetalleTareo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalleTareo.Rows[e.RowIndex].Cells[8].Selected == true)
            {
                dgvDetalleTareo.Rows[e.RowIndex].Cells[8].Value = true;
                dgvDetalleTareo.EndEdit();
            }
        }

        private void dgvDetalleTareo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalleTareo.Rows[e.RowIndex].Cells[5].Selected == true)
            {
                int contador = 0;
                foreach (DataRow row in oDataTrabajador.Select("dni = '" + dgvDetalleTareo.Rows[e.RowIndex].Cells[5].Value + "'"))
                {
                    contador += 1;
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[2].Value = e.RowIndex + 1;
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[3].Value = row[0].ToString();
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[4].Value = row[3].ToString() + " " + row[4].ToString() + ", " + row[2].ToString();

                    CapaDeNegocios.cListaAFP miAFP = new CapaDeNegocios.cListaAFP();
                    DataTable oDataAFP = miAFP.ObtenerListaAFP();
                    foreach (DataRow row1 in oDataAFP.Select("idtafp = '1'"))
                    {
                        dgvDetalleTareo.Rows[e.RowIndex].Cells[6].Value = row1[1].ToString();
                    }
                }
                if (contador == 0)
                {
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[2].Value = "";
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[3].Value = "";
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[4].Value = "";
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[5].Value = "";
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[6].Value = "";
                    MessageBox.Show("No existe el Trabajador, para agregar hacer clic en Nuevo Trabajador", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (dgvDetalleTareo.Rows[e.RowIndex].Cells[8].Selected == true)
            {
                for (int i = 0; i <= (miTareo.FechaFin.Day - miTareo.FechaInicio.Day); i++)
                {
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[10 + i].Value = "x";
                }
            }
        }

        private void dgvDetalleTareo_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string titleText = dgvDetalleTareo.Columns[5].HeaderText;
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
                dgvDetalleTareo.CurrentCell = dgvDetalleTareo.CurrentRow.Cells[5];
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

        public void CargarTrabajador(AutoCompleteStringCollection col)
        {
            oDataTrabajador = miListaTrabajadores.ObtenerListaTrabajadores(true);
            foreach (DataRow row in oDataTrabajador.Rows)
            {
                col.Add(row[1].ToString());
            }
        }

        private void CargarDatos()
        {
            dataGridView1.DataSource = miDetalleTareo.ListarDetalleTareo(miTareo);
        }
        private void DibujarDataGrid(int pDias)
        {
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
                dgvDetalleTareo.Columns["col" + i.ToString()].DisplayIndex = 9 + i;
            }
            dgvDetalleTareo.Rows.Add();
            dgvDetalleTareo.CurrentCell = dgvDetalleTareo.CurrentRow.Cells[5];
        }
    }
}
