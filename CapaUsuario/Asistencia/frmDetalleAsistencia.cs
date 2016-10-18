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
        int DiasMes = 0;
        DataTable oAsistenciaTrabajador = new DataTable();

        CapaDeNegocios.Asistencia.cAsistenciaTrabajador miAsistenciaTrabajador = new CapaDeNegocios.Asistencia.cAsistenciaTrabajador();
        CapaDeNegocios.Asistencia.cAsistenciaSuspencionLaboral miAsistenciaSuspencionLaboral = new CapaDeNegocios.Asistencia.cAsistenciaSuspencionLaboral();

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
                DiasMes = DateTime.DaysInMonth(Convert.ToInt32(cboAño.Text), Convert.ToInt32(Mes(cboMes.Text)));
                DibujarDataGrid();
                CargarDatos();
            }
        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAño.Text != "" && cboMes.Text != "")
            {
                DiasMes = DateTime.DaysInMonth(Convert.ToInt32(cboAño.Text), Convert.ToInt32(Mes(cboMes.Text)));
                DibujarDataGrid();
                CargarDatos();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < DiasMes; i++)
                {
                    string dia = i + 1 + "/" + Mes(cboMes.Text) + "/" + cboAño.Text;
                    miAsistenciaTrabajador.IdtAsistenciaTrabajador = Convert.ToInt32(dgvAsistenciaTrabajador.Rows[0].Cells[i].Value);
                    miAsistenciaTrabajador.Fecha = Convert.ToDateTime(dia);
                    miAsistenciaTrabajador.Tipo = Convert.ToString(dgvAsistenciaTrabajador.Rows[2].Cells[i].Value);
                    miAsistenciaTrabajador.IdtTrabajador = sidtrabajador;
                    miAsistenciaSuspencionLaboral.IdtAsistenciaTrabajador = Convert.ToInt32(dgvAsistenciaTrabajador.Rows[0].Cells[i].Value);
                    miAsistenciaSuspencionLaboral.IdtTipoSuspencionLaboral = Convert.ToInt32(dgvAsistenciaTrabajador.Rows[3].Cells[i].Value);

                    if (dgvAsistenciaTrabajador.Rows[2].Cells[i].Value.ToString() == "L")
                    {
                        if (dgvAsistenciaTrabajador.Rows[1].Cells[i].Value.ToString() == "E")
                        {
                            miAsistenciaSuspencionLaboral.EliminarAsistenciaSuspencionLaboral(Convert.ToInt32(dgvAsistenciaTrabajador.Rows[0].Cells[i].Value));
                            miAsistenciaTrabajador.EliminarAsistenciaTrabajador(Convert.ToInt32(dgvAsistenciaTrabajador.Rows[0].Cells[i].Value));
                        }
                    }
                    else
                    {
                        if (dgvAsistenciaTrabajador.Rows[1].Cells[i].Value.ToString() == "I")
                        {
                            miAsistenciaTrabajador.CrearAsistenciaTrabajador(miAsistenciaTrabajador);
                            if (dgvAsistenciaTrabajador.Rows[2].Cells[i].Value.ToString() == "S" || dgvAsistenciaTrabajador.Rows[2].Cells[i].Value.ToString() == "F")
                            {
                                oAsistenciaTrabajador = miAsistenciaTrabajador.ListarAsistenciaTrabajador(sidtrabajador);
                                miAsistenciaSuspencionLaboral.IdtAsistenciaTrabajador = Convert.ToInt32(oAsistenciaTrabajador.Compute("MAX(idtasistenciatrabajador)", ""));
                                miAsistenciaSuspencionLaboral.CrearAsistenciaSuspencionLaboral(miAsistenciaSuspencionLaboral);
                            }
                        }
                        else if (dgvAsistenciaTrabajador.Rows[1].Cells[i].Value.ToString() == "M")
                        {
                            if (dgvAsistenciaTrabajador.Rows[2].Cells[i].Value.ToString() == "T")
                            {
                                miAsistenciaSuspencionLaboral.EliminarAsistenciaSuspencionLaboral(Convert.ToInt32(dgvAsistenciaTrabajador.Rows[0].Cells[i].Value));
                            }
                            else
                            {
                                miAsistenciaSuspencionLaboral.ModificarAsistenciaSuspencionLaboral(miAsistenciaSuspencionLaboral);
                            }
                            miAsistenciaTrabajador.ModificarAsistenciaTrabajador(miAsistenciaTrabajador);
                        }
                    }
                }
                CargarDatos();
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
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
                    if (dgvAsistenciaTrabajador.Columns[e.ColumnIndex].Name != "txtTotalLaborados" && dgvAsistenciaTrabajador.Columns[e.ColumnIndex].Name != "txtTotalTardanza" && dgvAsistenciaTrabajador.Columns[e.ColumnIndex].Name != "txtTotalSubsidiados" && dgvAsistenciaTrabajador.Columns[e.ColumnIndex].Name != "txtTotalNoSubsidiadosNoLaborados")
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
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }

        private void dgvAsistenciaTrabajador_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAsistenciaTrabajador.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "L")
            {

            }
        }

        private void dgvAsistenciaTrabajador_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAsistenciaTrabajador.Rows[2].Cells[e.ColumnIndex].Value != null)
            {
                if (dgvAsistenciaTrabajador.Columns[e.ColumnIndex].Name != "txtTotalLaborados" && dgvAsistenciaTrabajador.Columns[e.ColumnIndex].Name != "txtTotalTardanza" && dgvAsistenciaTrabajador.Columns[e.ColumnIndex].Name != "txtTotalSubsidiados" && dgvAsistenciaTrabajador.Columns[e.ColumnIndex].Name != "txtTotalNoSubsidiadosNoLaborados")
                {
                    if (dgvAsistenciaTrabajador.Rows[2].Cells[e.ColumnIndex].Value.ToString() == "L")
                    {
                        dgvAsistenciaTrabajador.Rows[3].Cells[e.ColumnIndex].Value = "0";
                        if (dgvAsistenciaTrabajador.Rows[0].Cells[e.ColumnIndex].Value.ToString() == "0")
                        {
                            dgvAsistenciaTrabajador.Rows[1].Cells[e.ColumnIndex].Value = "";
                        }
                        else
                        {
                            dgvAsistenciaTrabajador.Rows[1].Cells[e.ColumnIndex].Value = "E";
                        }
                    }
                    else
                    {
                        if (dgvAsistenciaTrabajador.Rows[2].Cells[e.ColumnIndex].Value.ToString() == "T")
                        {
                            dgvAsistenciaTrabajador.Rows[3].Cells[e.ColumnIndex].Value = "0";
                        }
                        if (dgvAsistenciaTrabajador.Rows[0].Cells[e.ColumnIndex].Value.ToString() == "0")
                        {
                            dgvAsistenciaTrabajador.Rows[1].Cells[e.ColumnIndex].Value = "I";
                        }
                        else
                        {
                            dgvAsistenciaTrabajador.Rows[1].Cells[e.ColumnIndex].Value = "M";
                        }
                    }
                }
            }
        }

        private void miMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void miMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            CapaUsuario.Asistencia.frmBuscarSubsidio fBuscarSubsidio = new frmBuscarSubsidio();

            switch (e.ClickedItem.Text)
            {
                case "L = Laborados":
                    dgvAsistenciaTrabajador.Rows[filaseleccionada].Cells[columnaseleccionada].Value = "L";
                    break;
                case "T = Tardanza":
                    dgvAsistenciaTrabajador.Rows[filaseleccionada].Cells[columnaseleccionada].Value = "T";
                    break;
                case "S = Subsidiados":
                    dgvAsistenciaTrabajador.Rows[filaseleccionada].Cells[columnaseleccionada].Value = "S";
                    fBuscarSubsidio.RecibirDatos(true);
                    if (fBuscarSubsidio.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        dgvAsistenciaTrabajador.Rows[3].Cells[columnaseleccionada].Value = fBuscarSubsidio.sidttiposuspencionlaboral;
                    }
                    break;
                case "F = No Laborados y no Subsidiados":
                    dgvAsistenciaTrabajador.Rows[filaseleccionada].Cells[columnaseleccionada].Value = "F";
                    fBuscarSubsidio.RecibirDatos(false);
                    if (fBuscarSubsidio.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        dgvAsistenciaTrabajador.Rows[3].Cells[columnaseleccionada].Value = fBuscarSubsidio.sidttiposuspencionlaboral;
                    }
                    break;
            }
            CalcularTotales();
        }

        public void RecibirDatos(int pidtrabajador, string ptrabajador)
        {
            sidtrabajador = pidtrabajador;
            txtTrabajador.Text = ptrabajador;
        }

        private void CargarDatos()
        {
            try
            {
                LlenarDataGrid();
                oAsistenciaTrabajador = miAsistenciaTrabajador.ListarAsistenciaTrabajador(sidtrabajador);
                string fechainicio = "01/" + Mes(cboMes.Text) + "/" + cboAño.Text;
                string fechafin = DiasMes + "/" + Mes(cboMes.Text) + "/" + cboAño.Text;
                foreach (DataRow row in oAsistenciaTrabajador.Select("fecha >= '" + fechainicio + "' and fecha <= '" + fechafin + "'"))
                {
                    int dia = Convert.ToDateTime(row[1]).Day;
                    dgvAsistenciaTrabajador.Rows[0].Cells[dia - 1].Value = row[0].ToString();
                    dgvAsistenciaTrabajador.Rows[1].Cells[dia - 1].Value = "M";
                    dgvAsistenciaTrabajador.Rows[2].Cells[dia - 1].Value = row[2].ToString();
                    foreach (DataRow row2 in miAsistenciaSuspencionLaboral.ListarAsistenciaSuspencionLaboral(Convert.ToInt32(row[0].ToString())).Rows)
                    {
                        dgvAsistenciaTrabajador.Rows[3].Cells[dia - 1].Value = row2[1].ToString();
                    }
                }
                CalcularTotales();
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }

        private void CargarAños()
        {
            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                cboAño.Items.Add(i);
            }
            cboAño.Text = Convert.ToString(DateTime.Now.Year);
        }

        private void CalcularTotales()
        {
            if (dgvAsistenciaTrabajador.RowCount == 4)
            {
                int TotalLaborados = 0;
                int TotalTardanzas = 0;
                int TotalSubsidios = 0;
                int TotalNoLaboradosNoSubsidiados = 0;
                for (int i = 0; i < DiasMes; i++)
                {
                    switch (dgvAsistenciaTrabajador.Rows[2].Cells[i].Value.ToString())
                    {
                        case "L":
                            TotalLaborados += 1;
                            break;
                        case "T":
                            TotalTardanzas += 1;
                            break;
                        case "S":
                            TotalSubsidios += 1;
                            break;
                        case "F":
                            TotalNoLaboradosNoSubsidiados += 1;
                            break;
                    }
                }
                dgvAsistenciaTrabajador.Rows[2].Cells[DiasMes].Value = TotalLaborados;
                dgvAsistenciaTrabajador.Rows[2].Cells[DiasMes + 1].Value = TotalTardanzas;
                dgvAsistenciaTrabajador.Rows[2].Cells[DiasMes + 2].Value = TotalSubsidios;
                dgvAsistenciaTrabajador.Rows[2].Cells[DiasMes + 3].Value = TotalNoLaboradosNoSubsidiados;
            }
        }

        private void LlenarDataGrid()
        {
            for (int i = 0; i < DiasMes; i++)
            {
                dgvAsistenciaTrabajador.Rows[0].Cells[i].Value = "0";
                dgvAsistenciaTrabajador.Rows[2].Cells[i].Value = "L";
                dgvAsistenciaTrabajador.Rows[3].Cells[i].Value = "0";
            }
        }

        private void DibujarDataGrid()
        {
            try
            {
                dgvAsistenciaTrabajador.Columns.Clear();
                DateTime auxiliar;

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
                            col.DefaultCellStyle.BackColor = Color.Red;
                            break;
                        default:
                            break;
                    }
                    col.HeaderText = auxiliarDiaSemana;
                    col.Width = 22;
                    dgvAsistenciaTrabajador.Columns.Add(col);
                    dgvAsistenciaTrabajador.Columns["col" + i.ToString()].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                DataGridViewTextBoxColumn TotalLaborados= new DataGridViewTextBoxColumn();
                TotalLaborados.Name = "txtTotalLaborados";
                TotalLaborados.HeaderText = "Total Laborados";
                TotalLaborados.Width = 60;
                dgvAsistenciaTrabajador.Columns.Add(TotalLaborados);
                dgvAsistenciaTrabajador.Columns["txtTotalLaborados"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DataGridViewTextBoxColumn TotalTardanza = new DataGridViewTextBoxColumn();
                TotalTardanza.Name = "txtTotalTardanza";
                TotalTardanza.HeaderText = "Total Tardanzas";
                TotalTardanza.Width = 60;
                dgvAsistenciaTrabajador.Columns.Add(TotalTardanza);
                dgvAsistenciaTrabajador.Columns["txtTotalTardanza"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DataGridViewTextBoxColumn TotalSubsidiados = new DataGridViewTextBoxColumn();
                TotalSubsidiados.Name = "txtTotalSubsidiados";
                TotalSubsidiados.HeaderText = "Total Subsidiados";
                TotalSubsidiados.Width = 60;
                dgvAsistenciaTrabajador.Columns.Add(TotalSubsidiados);
                dgvAsistenciaTrabajador.Columns["txtTotalSubsidiados"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DataGridViewTextBoxColumn TotalNoSubsidiadosNoLaborados = new DataGridViewTextBoxColumn();
                TotalNoSubsidiadosNoLaborados.Name = "txtTotalNoSubsidiadosNoLaborados";
                TotalNoSubsidiadosNoLaborados.HeaderText = "Total No Sub. y No Lab.";
                TotalNoSubsidiadosNoLaborados.Width = 60;
                dgvAsistenciaTrabajador.Columns.Add(TotalNoSubsidiadosNoLaborados);
                dgvAsistenciaTrabajador.Columns["txtTotalNoSubsidiadosNoLaborados"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
            dgvAsistenciaTrabajador.Rows.Add();
            dgvAsistenciaTrabajador.Rows.Add();
            dgvAsistenciaTrabajador.Rows.Add();
            dgvAsistenciaTrabajador.Rows.Add();
            dgvAsistenciaTrabajador.Rows[0].Visible = false;
            dgvAsistenciaTrabajador.Rows[1].Visible = false;
            dgvAsistenciaTrabajador.Rows[3].Visible = false;
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
    }
}
