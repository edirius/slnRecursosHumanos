using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios;


namespace CapaUsuario.AsistenciaGen
{
    public partial class frmJornadaLaboral : Form
    {
        int filaseleccionada = 0;
        int columnaseleccionada = 0;

        public cTrabajador miTrabajador;
        public DateTime Mes;
        public CapaDeNegocios.Asistencia.cTrabajadorReloj miTrabajadorReloj;

        private CapaDeNegocios.AsistenciaGeneral.cCatalogoJornadaLaboral miCatalogo = new CapaDeNegocios.AsistenciaGeneral.cCatalogoJornadaLaboral();
        private CapaDeNegocios.Asistencia.cCatalogoAsistencia miCatalogoAsistencia = new CapaDeNegocios.Asistencia.cCatalogoAsistencia();
        private CapaDeNegocios.Asistencia.cHorario oHorario = new CapaDeNegocios.Asistencia.cHorario();

        CapaDeNegocios.Asistencia.cAsistenciaSuspencionLaboral miAsistenciaSuspencionLaboral = new CapaDeNegocios.Asistencia.cAsistenciaSuspencionLaboral();
        private CapaDeNegocios.AsistenciaGeneral.cJornadaLaboral miJornada = new CapaDeNegocios.AsistenciaGeneral.cJornadaLaboral();
        private CapaDeNegocios.Asistencia.cAsistenciaMes AsistenciaMes = new CapaDeNegocios.Asistencia.cAsistenciaMes();

        public frmJornadaLaboral()
        {
            InitializeComponent();
        }

        private void frmJornadaLaboral_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                txtTrabajador.Text = miTrabajador.Nombres + " " + miTrabajador.ApellidoPaterno + " " + miTrabajador.ApellidoMaterno;
                miTrabajadorReloj = miCatalogoAsistencia.TraerTrabajadorReloj(miTrabajador);
                oHorario = miCatalogoAsistencia.TraerHorarioTrabajador(miTrabajador);
                AsistenciaMes = miCatalogoAsistencia.LLenarAsistencia(miTrabajador, Mes.Month, Mes.Year, oHorario);
                AsistenciaMes.ListaAsistenciaDia = AsistenciaMes.LlenarAsistencias(miCatalogoAsistencia.ListaPicadoEntreFechas(miTrabajadorReloj, AsistenciaMes.InicioMes, AsistenciaMes.FinMes),
                                                                                                                       AsistenciaMes.InicioMes,
                                                                                                                       AsistenciaMes.FinMes,
                                                                                                                       miCatalogoAsistencia.TraerHorarioTrabajador(miTrabajador),
                                                                                                                       miCatalogoAsistencia.ListaSalidasEntreFechas(miTrabajador, AsistenciaMes.InicioMes, AsistenciaMes.FinMes),
                                                                                                                       miCatalogoAsistencia.ListaDiaFestivo(Mes.Year));
                AsistenciaMes.Actualizardatos();

                miJornada = miCatalogo.TraerJornadaLaboralEntreFechas(miTrabajador, AsistenciaMes.InicioMes, AsistenciaMes.FinMes);
                DibujarDataGrid();
                CargarDatosJornadaLaboral();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar la jornada laboral: " + ex.Message);
            }
        }

        private void CargarDatosJornadaLaboral()
        {
            try
            {
                int DiasMes = (AsistenciaMes.FinMes - AsistenciaMes.InicioMes).Days + 1;
                for (int i = 0; i < DiasMes; i++)
                {
                    dgvAsistenciaTrabajador.Rows[0].Cells[i].Value = "N";

                    foreach (CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral item in miJornada.ListaDetalleJornadaLaboral)
                    {
                        if (item.Dia.Date == AsistenciaMes.InicioMes.AddDays(i).Date)
                        {
                            switch (item.TipoDia)
                            {
                                case CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral.enumTipoDiaJornada.Laborado:
                                    dgvAsistenciaTrabajador.Rows[0].Cells[i].Value = "N";
                                    break;
                                case CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral.enumTipoDiaJornada.Justificado:
                                    dgvAsistenciaTrabajador.Rows[0].Cells[i].Value = "J";
                                    break;
                                case CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral.enumTipoDiaJornada.Subsidiado:
                                    dgvAsistenciaTrabajador.Rows[0].Cells[i].Value = "S";
                                    break;
                                case CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral.enumTipoDiaJornada.NoLaborado:
                                    dgvAsistenciaTrabajador.Rows[0].Cells[i].Value = "F";
                                    break;
                                case CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral.enumTipoDiaJornada.Tardanza:
                                    dgvAsistenciaTrabajador.Rows[0].Cells[i].Value = "T";
                                    break;
                                case CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral.enumTipoDiaJornada.Feriado:
                                    dgvAsistenciaTrabajador.Rows[0].Cells[i].Value = "L";
                                    break;
                                default:
                                    break;
                            }
                            
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de jornada laboral: " + ex.Message);
            }
        }

        private void DibujarDataGrid()
        {
            try
            {
                int DiasMes = (AsistenciaMes.FinMes - AsistenciaMes.InicioMes).Days + 1;
                dgvAsistenciaTrabajador.Columns.Clear();
                DateTime auxiliar;

                for (int i = 0; i < DiasMes; i++)
                {
                    auxiliar = AsistenciaMes.InicioMes.AddDays(i);
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
                DataGridViewTextBoxColumn TotalLaborados = new DataGridViewTextBoxColumn();
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
        }

        private void btnSincronizarReloj_Click(object sender, EventArgs e)
        {
            int DiasMes = (AsistenciaMes.FinMes - AsistenciaMes.InicioMes).Days + 1;
            for (int i = 0; i < DiasMes; i++)
            {
                foreach (CapaDeNegocios.Asistencia.cAsistenciaDia item in AsistenciaMes.ListaAsistenciaDia)
                {
                    if (item.Dia.Date == AsistenciaMes.InicioMes.AddDays(i))
                    {
                        if (dgvAsistenciaTrabajador.Rows[0].Cells[i].Value.ToString() == "N" )
                        {
                            if (item.Tarde)
                            {
                                dgvAsistenciaTrabajador.Rows[0].Cells[i].Value = "T";
                            }
                            else if (item.DiaLibre)
                            {
                                dgvAsistenciaTrabajador.Rows[0].Cells[i].Value = "L";
                            }
                            else 
                            {
                                switch (item.Falta)
                                {
                                    case CapaDeNegocios.Asistencia.cAsistenciaDia.TipoFalta.FaltaPicadoEntrada:
                                        dgvAsistenciaTrabajador.Rows[0].Cells[i].Value = "F";
                                        break;
                                    case CapaDeNegocios.Asistencia.cAsistenciaDia.TipoFalta.FaltaPicadoFinal:
                                        dgvAsistenciaTrabajador.Rows[0].Cells[i].Value = "F";
                                        break;
                                    case CapaDeNegocios.Asistencia.cAsistenciaDia.TipoFalta.FaltaJustificada:
                                        dgvAsistenciaTrabajador.Rows[0].Cells[i].Value = "J";
                                        break;
                                    case CapaDeNegocios.Asistencia.cAsistenciaDia.TipoFalta.FaltaTotal:
                                        dgvAsistenciaTrabajador.Rows[0].Cells[i].Value = "F";
                                        break;
                                    case CapaDeNegocios.Asistencia.cAsistenciaDia.TipoFalta.SinFalta:
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void miMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            CapaUsuario.Asistencia.frmBuscarSubsidio fBuscarSubsidio = new Asistencia.frmBuscarSubsidio();
            CapaDeNegocios.Asistencia.cAsistenciaTrabajador miAsistencia = new CapaDeNegocios.Asistencia.cAsistenciaTrabajador();
            miAsistencia.Fecha = AsistenciaMes.InicioMes.AddDays(filaseleccionada);

            DataTable tablaAsistencia = new DataTable();

            switch (e.ClickedItem.Text)
            {
                case "L = Laborados":
                    dgvAsistenciaTrabajador.Rows[filaseleccionada].Cells[columnaseleccionada].Value = "L";
                    break;
                case "T = Tardanza":
                    dgvAsistenciaTrabajador.Rows[filaseleccionada].Cells[columnaseleccionada].Value = "T";
                    miAsistencia.Tipo = "T";
                    miAsistencia.CrearAsistenciaTrabajador(miAsistencia);
                    break;
                case "S = Subsidiados":
                    
                    fBuscarSubsidio.RecibirDatos(true);
                    if (fBuscarSubsidio.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        dgvAsistenciaTrabajador.Rows[filaseleccionada].Cells[columnaseleccionada].Value = "S";
                        miAsistencia.CrearAsistenciaTrabajador(miAsistencia);
                        dgvAsistenciaTrabajador.Rows[0].Cells[columnaseleccionada].Value = fBuscarSubsidio.sidttiposuspencionlaboral;

                        tablaAsistencia = miAsistencia.ListarAsistenciaTrabajador(miTrabajador.IdTrabajador);
                        miAsistenciaSuspencionLaboral.IdtAsistenciaTrabajador = Convert.ToInt32(tablaAsistencia.Compute("MAX(idtasistenciatrabajador)", ""));
                        miAsistenciaSuspencionLaboral.CrearAsistenciaSuspencionLaboral(miAsistenciaSuspencionLaboral);
                    }
                    break;
                case "F = No Laborados y no Subsidiados":
                    dgvAsistenciaTrabajador.Rows[filaseleccionada].Cells[columnaseleccionada].Value = "F";
                    fBuscarSubsidio.RecibirDatos(false);
                    if (fBuscarSubsidio.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        dgvAsistenciaTrabajador.Rows[0].Cells[columnaseleccionada].Value = fBuscarSubsidio.sidttiposuspencionlaboral;
                    }
                    break;
            }
            CalcularTotales();
        }

        private void CalcularTotales()
        {
            int DiasMes = (AsistenciaMes.FinMes - AsistenciaMes.InicioMes).Days + 1;
            if (dgvAsistenciaTrabajador.RowCount == 4)
            {
                int TotalLaborados = 0;
                int TotalTardanzas = 0;
                int TotalSubsidios = 0;
                int TotalNoLaboradosNoSubsidiados = 0;
                for (int i = 0; i <  DiasMes; i++)
                {
                    switch (dgvAsistenciaTrabajador.Rows[0].Cells[i].Value.ToString())
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
                dgvAsistenciaTrabajador.Rows[0].Cells[DiasMes].Value = TotalLaborados;
                dgvAsistenciaTrabajador.Rows[0].Cells[DiasMes + 1].Value = TotalTardanzas;
                dgvAsistenciaTrabajador.Rows[0].Cells[DiasMes + 2].Value = TotalSubsidios;
                dgvAsistenciaTrabajador.Rows[0].Cells[DiasMes + 3].Value = TotalNoLaboradosNoSubsidiados;
            }
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
    }
}
