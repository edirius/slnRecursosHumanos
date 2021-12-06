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

        private CapaDeNegocios.Asistencia.cCatalogoAsistencia oCatalogoAsistencia = new CapaDeNegocios.Asistencia.cCatalogoAsistencia();

        private ViewJornadaLaboral vJordanaLaboral = new ViewJornadaLaboral();

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

                //Llenar la vista jornada laboral
                vJordanaLaboral.Inicio = AsistenciaMes.InicioMes;
                vJordanaLaboral.Fin = AsistenciaMes.FinMes;
                vJordanaLaboral.AsistenciaMes = AsistenciaMes;
                vJordanaLaboral.OHorario = oHorario;
                vJordanaLaboral.JornadaLaboral = miJornada;
                vJordanaLaboral.LlenarDetalleJornadaLaboral();

                DibujarDataGrid();
                CargarDatosJornadaLaboral(vJordanaLaboral);
                CalcularTotales();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar la jornada laboral: " + ex.Message);
            }
        }

        private void CargarDatosJornadaLaboral(ViewJornadaLaboral miVistaJornada)
        {
            try
            {
                int DiasMes = (miVistaJornada.Fin - miVistaJornada.Inicio).Days + 1;
                for (int i = 0; i < DiasMes; i++)
                {
                    foreach (DetalleViewJornadaLaboral item in miVistaJornada.ListaDetalleViewJornadaLaboral)
                    {
                        if (item.Dia.Date == AsistenciaMes.InicioMes.AddDays(i).Date)
                        { 
                            //Si es 0, no tiene asignado un turno
                            if ((item.TurnoDia.CodigoTurnoDia == 0)|| (item.AsistenciaDia.EventoDia == CapaDeNegocios.Asistencia.cAsistenciaDia.TipoDia.DiaFestivo))
                            {
                                dgvAsistenciaTrabajador.Rows[0].Cells[i].Value = "L";
                            }
                            else
                            {
                                dgvAsistenciaTrabajador.Rows[0].Cells[i].Value = "N";
                            }
                            if (item.DetalleJornadaLaboral != null)
                            {
                                switch (item.DetalleJornadaLaboral.TipoDia)
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
                TotalNoSubsidiadosNoLaborados.HeaderText = "Total Faltas y No Sub.";
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

            miCatalogo.ActualizarDetalleSuspensionLaboral(vJordanaLaboral.AsistenciaMes, vJordanaLaboral.JornadaLaboral);
            Iniciar();

        }

        private void miMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            CapaUsuario.Asistencia.frmBuscarSubsidio fBuscarSubsidio = new Asistencia.frmBuscarSubsidio();

            CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral NuevoDetalleJornadaLaboral = new CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral();
            NuevoDetalleJornadaLaboral.Codigo = 0;
            NuevoDetalleJornadaLaboral.Dia = vJordanaLaboral.AsistenciaMes.InicioMes.AddDays(columnaseleccionada).Date;
            NuevoDetalleJornadaLaboral.Trabajador = vJordanaLaboral.AsistenciaMes.Trabajador;

            switch (e.ClickedItem.Text)
            {
                case "N = Normal- Laborado":
                    NuevoDetalleJornadaLaboral = null;
                    break;
                case "T = Tardanza":
                    NuevoDetalleJornadaLaboral.TipoDia = CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral.enumTipoDiaJornada.Tardanza;
                    break;
                case "S = Subsidiados":

                    fBuscarSubsidio.RecibirDatos(true);
                    if (fBuscarSubsidio.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        NuevoDetalleJornadaLaboral.TipoDia = CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral.enumTipoDiaJornada.Subsidiado;
                        NuevoDetalleJornadaLaboral.SuspensionLaboral = new CapaDeNegocios.Sunat.cTipoSuspencionLaboral();
                        NuevoDetalleJornadaLaboral.SuspensionLaboral.IdtTipoSuspencionLaboral = fBuscarSubsidio.sidttiposuspencionlaboral;
                    }
                    break;
                case "F = No Laborados y no Subsidiados":
                    NuevoDetalleJornadaLaboral.TipoDia = CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral.enumTipoDiaJornada.NoLaborado;
                    fBuscarSubsidio.RecibirDatos(false);
                    if (fBuscarSubsidio.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        NuevoDetalleJornadaLaboral.SuspensionLaboral = new CapaDeNegocios.Sunat.cTipoSuspencionLaboral();
                        NuevoDetalleJornadaLaboral.SuspensionLaboral.IdtTipoSuspencionLaboral = fBuscarSubsidio.sidttiposuspencionlaboral;
                    }
                    break;
            }


            if (dgvAsistenciaTrabajador.Rows[0].Cells[columnaseleccionada].Value.ToString() != "N")
            {
                foreach (CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral item in vJordanaLaboral.JornadaLaboral.ListaDetalleJornadaLaboral)
                {
                    if (item.Dia.Date == vJordanaLaboral.AsistenciaMes.InicioMes.AddDays(columnaseleccionada).Date)
                    {
                        miCatalogo.ActualizarDetalleSuspensionLaboral(item, NuevoDetalleJornadaLaboral);  
                    }
                }
            }
            else
            {
                miCatalogo.ActualizarDetalleSuspensionLaboral(null, NuevoDetalleJornadaLaboral);
            }

            Iniciar();
        }

        private void CalcularTotales()
        {
            int DiasMes = (AsistenciaMes.FinMes - AsistenciaMes.InicioMes).Days + 1;
                int TotalLaborados = 0;
                int TotalTardanzas = 0;
                int TotalSubsidios = 0;
                int TotalNoLaboradosNoSubsidiados = 0;
                for (int i = 0; i <  DiasMes; i++)
                {
                    switch (dgvAsistenciaTrabajador.Rows[0].Cells[i].Value.ToString())
                    {
                        case "N":
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

        private void dgvAsistenciaTrabajador_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (dgvAsistenciaTrabajador.Columns[e.ColumnIndex].Name != "txtTotalLaborados" && dgvAsistenciaTrabajador.Columns[e.ColumnIndex].Name != "txtTotalTardanza" && dgvAsistenciaTrabajador.Columns[e.ColumnIndex].Name != "txtTotalSubsidiados" && dgvAsistenciaTrabajador.Columns[e.ColumnIndex].Name != "txtTotalNoSubsidiadosNoLaborados")
                    {
                        //filaseleccionada = e.RowIndex;
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

        private void dgvAsistenciaTrabajador_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int DiasMes = (AsistenciaMes.FinMes - AsistenciaMes.InicioMes).Days + 1;
                if (vJordanaLaboral.ListaDetalleViewJornadaLaboral.Count > 0 && e.ColumnIndex < DiasMes)
                {
                    LlenarDetalle(vJordanaLaboral.ListaDetalleViewJornadaLaboral.Find(x => x.Dia.Date == vJordanaLaboral.Inicio.AddDays(e.ColumnIndex)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar celda: " + ex.Message);
            }
        }

        private void LlenarDetalle(DetalleViewJornadaLaboral miDetalle)
        {
            try
            {
                lblTipoSuspension.Text = "";
                if (miDetalle.TurnoDia.CodigoTurnoDia == 0)
                {
                    lblNombreTurno.Text = "Sin Turno";
                    lblNombreTurno.ForeColor = Color.Black;
                }
                else
                {
                    if (miDetalle.AsistenciaDia.DiaFestivo == null)
                    {
                        lblNombreTurno.Text = "Dia Laborable";
                        lblNombreTurno.ForeColor = Color.Blue;
                    }
                    else
                    {
                        lblNombreTurno.Text = "Dia Festivo: " + miDetalle.AsistenciaDia.DiaFestivo.Nombre;
                        lblNombreTurno.ForeColor = Color.Red;
                    }
                }

                //parte para llenar la jornada laboral
                if (miDetalle.DetalleJornadaLaboral != null)
                {
                    switch (miDetalle.DetalleJornadaLaboral.TipoDia)
                    {
                        case CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral.enumTipoDiaJornada.Laborado:
                            lblTipoDia.Text = miDetalle.DetalleJornadaLaboral.TipoDia.ToString();
                            lblTipoDia.ForeColor = Color.Black;
                            lblTipoSuspension.Text = "";
                            break;
                        case CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral.enumTipoDiaJornada.Justificado:
                            lblTipoDia.Text = "Justificado";
                            lblTipoDia.ForeColor = Color.Black;
                            lblTipoSuspension.Text = "";
                            break;
                        case CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral.enumTipoDiaJornada.Subsidiado:
                            lblTipoDia.Text = "Subsidiado";
                            lblTipoDia.ForeColor = Color.DarkBlue;
                            if (miDetalle.DetalleJornadaLaboral.SuspensionLaboral != null)
                            {
                                lblTipoSuspension.Text = miDetalle.DetalleJornadaLaboral.SuspensionLaboral.Abreviacion;
                                lblTipoSuspension.ForeColor = Color.DarkBlue;
                            }
                            break;
                        case CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral.enumTipoDiaJornada.NoLaborado:
                            lblTipoDia.Text = "Falta";
                            lblTipoDia.ForeColor = Color.Red;
                            if (miDetalle.DetalleJornadaLaboral.SuspensionLaboral != null)
                            {
                                lblTipoSuspension.Text = miDetalle.DetalleJornadaLaboral.SuspensionLaboral.Abreviacion;
                                lblTipoSuspension.ForeColor = Color.Red;
                            }
                            break;
                        case CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral.enumTipoDiaJornada.Tardanza:
                            lblTipoDia.Text = "Tardanza";
                            lblTipoDia.ForeColor = Color.Red;
                            lblTipoSuspension.Text = "";
                            break;
                        case CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral.enumTipoDiaJornada.Feriado:
                            lblTipoDia.Text = "Feriado";
                            lblTipoDia.ForeColor = Color.Red;
                            lblTipoSuspension.Text = "";
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    lblTipoDia.Text = "Normal";
                    lblTipoDia.ForeColor = Color.Black;
                }

                //parte para llenar el picado de entrada y salida
                lstPicados.Items.Clear();
                if (miDetalle.AsistenciaDia != null)
                {
                    
                    foreach (CapaDeNegocios.Asistencia.cPicado item in miDetalle.AsistenciaDia.ListaPicados)
                    {
                        lstPicados.Items.Add(item.Picado);
                    }
                    if (miDetalle.AsistenciaDia.PicadoEntrada != null)
                    {
                        lblPicadoEntrada.Text = miDetalle.AsistenciaDia.PicadoEntrada.Picado.ToString();
                        
                    }
                    
                    if (miDetalle.AsistenciaDia.PicadoSalida != null)
                    {
                        lblPicadoSalida.Text = miDetalle.AsistenciaDia.PicadoSalida.Picado.ToString();
                    }

                    switch (miDetalle.AsistenciaDia.Falta)
                    {
                        case CapaDeNegocios.Asistencia.cAsistenciaDia.TipoFalta.FaltaPicadoEntrada:
                            lblPicadoEntrada.Text = "Sin Picado-Entrada";
                            lblPicadoEntrada.ForeColor = Color.DarkOrange;
                            break;
                        case CapaDeNegocios.Asistencia.cAsistenciaDia.TipoFalta.FaltaPicadoFinal:
                            lblPicadoSalida.Text = "Sin Picado - Salida";
                            lblPicadoSalida.ForeColor = Color.DarkOrange;
                            break;
                        case CapaDeNegocios.Asistencia.cAsistenciaDia.TipoFalta.FaltaJustificada:
                            lblPicadoEntrada.Text = "Falta Justificada";
                            lblPicadoEntrada.ForeColor = Color.Blue;
                            break;
                        case CapaDeNegocios.Asistencia.cAsistenciaDia.TipoFalta.FaltaTotal:
                            lblPicadoEntrada.Text = "Sin Picado-Entrada";
                            lblPicadoEntrada.ForeColor = Color.Orange;
                            lblPicadoSalida.Text = "Sin Picado - Salida";
                            lblPicadoSalida.ForeColor = Color.Orange;
                            break;
                        case CapaDeNegocios.Asistencia.cAsistenciaDia.TipoFalta.SinFalta:
                            lblPicadoEntrada.ForeColor = Color.Black;
                            lblPicadoSalida.ForeColor = Color.Black;
                            break;
                        default:
                            break;
                    }
                }

                //parte para llenar las salidas
                lstListaSalidas.Items.Clear();
                if (miDetalle.AsistenciaDia != null)
                {
                    foreach (CapaDeNegocios.Asistencia.cExcepcionesAsistencia item in miDetalle.AsistenciaDia.ListaSalidas)
                    {
                        string dato = "";
                        dato = item.Tipo.ToString() + " : " + item.InicioExcepcion.ToString() + " - " + item.FinExcepcion.ToString();
                        
                        lstListaSalidas.Items.Add(dato);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar detalle: " + ex.Message) ;
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarSalida_Click(object sender, EventArgs e)
        {
            Asistencia.frmMantenimientoSalidas fMantenimientoSalidas = new Asistencia.frmMantenimientoSalidas();
            fMantenimientoSalidas.oSalidaTrabajador = new CapaDeNegocios.Asistencia.cExcepcionesAsistencia();
            fMantenimientoSalidas.oSalidaTrabajador.InicioExcepcion = DateTime.Now;
            fMantenimientoSalidas.oSalidaTrabajador.FinExcepcion = DateTime.Now;
            fMantenimientoSalidas.oSalidaTrabajador.Trabajador = miTrabajador;

            if (fMantenimientoSalidas.ShowDialog() == DialogResult.OK)
            {
                oCatalogoAsistencia.IngresarNuevaSalida(fMantenimientoSalidas.oSalidaTrabajador);
                MessageBox.Show("Se ingreso correctamente.", "Ingreso salida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Iniciar();
            }
            else
            {
                MessageBox.Show("Se canceló la operación.", "Mantenimiento Salidas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
