using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Asistencia
{
    public partial class frmDetalleAsistencia : Form
    {
        int sidtrabajador = 0;
        int filaseleccionada = 0;
        int columnaseleccionada = 0;

        public frmDetalleAsistencia()
        {
            InitializeComponent();
        }

        private void frmMantenimientoDetalleTareo_Load(object sender, EventArgs e)
        {
            CargarAños();
            cboMes.Text = DateTime.Now.ToString("MMMM");
        }

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAño.Text != "" && cboMes.Text != "")
            {
                DibujarDataGrid();
                CargarDatos();
            }
        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAño.Text != "" && cboMes.Text != "")
            {
                DibujarDataGrid();
                CargarDatos();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void dgvAsistenciaTrabajador_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvAsistenciaTrabajador_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    filaseleccionada = e.RowIndex;
                    columnaseleccionada = e.ColumnIndex;
                    if (e.Button == MouseButtons.Right)
                    {
                        dgvAsistenciaTrabajador.ClearSelection();
                        dgvAsistenciaTrabajador.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                        miMenu.Show(MousePosition);
                    }
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }

        public void RecibirDatos(int pidtrabajador,string ptrabajador)
        {
            sidtrabajador = pidtrabajador;
            txtTrabajador.Text = ptrabajador;
        }

        private void CargarDatos()
        {
            dgvAsistenciaTrabajador.Rows.Add();
        }

        private void CargarAños()
        {
            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                cboAño.Items.Add(i);
            }
            cboAño.Text = Convert.ToString(DateTime.Now.Year);
        }

        string Mes(string pmes)
        {
            string x = "";
            switch (pmes)
            {
                case "ENERO":
                    x = "01";
                    break;
                case "FEBRERO":
                    x = "02";
                    break;
                case "MARZO":
                    x = "03";
                    break;
                case "ABRIL":
                    x = "04";
                    break;
                case "MAYO":
                    x = "05";
                    break;
                case "JUNIO":
                    x = "06";
                    break;
                case "JULIO":
                    x = "07";
                    break;
                case "AGOSTO":
                    x = "08";
                    break;
                case "SEPTIEMBRE":
                    x = "09";
                    break;
                case "OCTUBRE":
                    x = "10";
                    break;
                case "NOVIEMBRE":
                    x = "11";
                    break;
                case "DICIEMBRE":
                    x = "12";
                    break;
            }
            return x;
        }

        private void DibujarDataGrid()
        {
            try
            {
                dgvAsistenciaTrabajador.Columns.Clear();
                DateTime auxiliar;
                int DiasMes = DateTime.DaysInMonth(Convert.ToInt32(cboAño.Text), Convert.ToInt32(Mes(cboMes.Text)));

                for (int i = 0; i < DiasMes; i++)
                {
                    auxiliar = Convert.ToDateTime("01/" + Mes(cboMes.Text) + "/" + cboAño.Text).AddDays(i);
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
                    col.Width = 22;
                    dgvAsistenciaTrabajador.Columns.Add(col);
                }
                DataGridViewTextBoxColumn TotalDias = new DataGridViewTextBoxColumn();
                TotalDias.Name = "txtTotalDias";
                TotalDias.HeaderText = "Total Dias";
                TotalDias.Width = 50;
                dgvAsistenciaTrabajador.Columns.Add(TotalDias);
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }

        private void miMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void miMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            dgvAsistenciaTrabajador.Rows[filaseleccionada].Cells[columnaseleccionada].Value = e.ClickedItem.Text;
        }
    }
}
