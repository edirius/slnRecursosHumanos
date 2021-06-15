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

namespace CapaUsuario.Asistencia
{
    public partial class frmAsistenciaMes : Form
    {
        public CapaDeNegocios.Asistencia.cTrabajadorReloj miTrabajador;

        CapaDeNegocios.Asistencia.cAsistenciaDia oAsistenciaDia = new CapaDeNegocios.Asistencia.cAsistenciaDia();

        CapaDeNegocios.Asistencia.cCatalogoAsistencia oCatalogoAsistencia = new CapaDeNegocios.Asistencia.cCatalogoAsistencia();

        CapaDeNegocios.Asistencia.cAsistenciaMes oAsistenciaMes = new CapaDeNegocios.Asistencia.cAsistenciaMes();

        public frmAsistenciaMes()
        {
            InitializeComponent();
        }

        private void AsistenciaMes_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            for (int i = 0 ; i < 5; i++)
            {
                cboAño.Items.Add(DateTime.Now.Year - i);
            }

            cboMes.Items.Add("Enero");
            cboMes.Items.Add("Febrero");
            cboMes.Items.Add("Marzo");
            cboMes.Items.Add("Abril");
            cboMes.Items.Add("Mayo");
            cboMes.Items.Add("Junio");
            cboMes.Items.Add("Julio");
            cboMes.Items.Add("Agosto");
            cboMes.Items.Add("Setiembre");
            cboMes.Items.Add("Octubre");
            cboMes.Items.Add("Noviembre");
            cboMes.Items.Add("Diciembre");

            cboMes.SelectedIndex = DateTime.Now.Month - 1;

            lblNombredelTrabajador.Text = miTrabajador.OTrabajador.Nombres + " " + miTrabajador.OTrabajador.ApellidoPaterno + " " + miTrabajador.OTrabajador.ApellidoMaterno;

            DarFormato();
            
        }

        private void CargarCalendario()
        {
            oAsistenciaMes = oCatalogoAsistencia.LLenarAsistencia(miTrabajador.OTrabajador, cboMes.SelectedIndex + 1, Convert.ToInt16(cboAño.Text), oCatalogoAsistencia.TraerHorarioTrabajador(miTrabajador.OTrabajador));
            if (CalendarioAsistencia.MaxDate < oAsistenciaMes.InicioMes)
            {
                CalendarioAsistencia.MaxDate = oAsistenciaMes.FinMes;
                CalendarioAsistencia.MinDate = oAsistenciaMes.InicioMes;
                
            }
            else
            {
                CalendarioAsistencia.MinDate = oAsistenciaMes.InicioMes;
                CalendarioAsistencia.MaxDate = oAsistenciaMes.FinMes;
            }
   
            oAsistenciaMes.ListaAsistenciaDia = oAsistenciaMes.LlenarAsistencias(oCatalogoAsistencia.ListaPicadoEntreFechas(miTrabajador, oAsistenciaMes.InicioMes, oAsistenciaMes.FinMes),
                                                                                                                    oAsistenciaMes.InicioMes,
                                                                                                                    oAsistenciaMes.FinMes,
                                                                                                                    oCatalogoAsistencia.TraerHorarioTrabajador(miTrabajador.OTrabajador), 
                                                                                                                    oCatalogoAsistencia.ListaSalidasEntreFechas(miTrabajador.OTrabajador, oAsistenciaMes.InicioMes, oAsistenciaMes.FinMes), 
                                                                                                                    oCatalogoAsistencia.ListaDiaFestivo(CalendarioAsistencia.SelectionStart.Year));
            oAsistenciaMes.Actualizardatos();

            lblTotalFaltas.Text = oAsistenciaMes.TotalFaltasMes.ToString();
            lblTotaltardanzas.Text = oAsistenciaMes.TotalMinutosTarde.ToString(); // .TotalTardanzas.ToString();

            foreach (CapaDeNegocios.Asistencia.cAsistenciaDia item in oAsistenciaMes.ListaAsistenciaDia)
            {
                if ((item.Falta == CapaDeNegocios.Asistencia.cAsistenciaDia.TipoFalta.FaltaPicadoEntrada) || (item.Falta == CapaDeNegocios.Asistencia.cAsistenciaDia.TipoFalta.FaltaPicadoFinal) || (item.Falta == CapaDeNegocios.Asistencia.cAsistenciaDia.TipoFalta.FaltaTotal))
                {
                    CalendarioAsistencia.AddBoldedDate(item.Dia);
                  
                }

                if (item.Tarde == true)
                {
                    CalendarioAsistencia.AddBoldedDate(item.Dia);
                }

            }

        }

      

        private void CargarDatos()
        {
            if (!chkTodoElMes.Checked)
            {
                dtgDetalleAsistencia.DataSource = oCatalogoAsistencia.ListaPicadoxDia(miTrabajador, CalendarioAsistencia.SelectionStart);
            }
            else
            {
                dtgDetalleAsistencia.DataSource = oCatalogoAsistencia.ListaPicadoEntreFechas(miTrabajador, oAsistenciaMes.InicioMes, oAsistenciaMes.FinMes);
            }
            dtgListaSalidas.DataSource = oCatalogoAsistencia.ListaSalidas(miTrabajador.OTrabajador, CalendarioAsistencia.SelectionStart);

            if (oAsistenciaMes.ListaAsistenciaDia.Count > 0)
            {
                oAsistenciaDia = oAsistenciaMes.ListaAsistenciaDia.Find(x => x.Dia.Date == CalendarioAsistencia.SelectionStart);
                if (oAsistenciaDia != null)
                {
                    lblMinutostarde.Text = oAsistenciaDia.MinutosTarde.ToString();
                    switch (oAsistenciaDia.Falta)
                    {
                        case CapaDeNegocios.Asistencia.cAsistenciaDia.TipoFalta.FaltaPicadoEntrada:
                            lblFaltaDia.Text = "Falta al picar Entrada";
                            lblFaltaDia.ForeColor = Color.Red;
                            break;
                        case CapaDeNegocios.Asistencia.cAsistenciaDia.TipoFalta.FaltaPicadoFinal:
                            lblFaltaDia.Text = "Falta al picar Salida";
                            lblFaltaDia.ForeColor = Color.Red;
                            break;
                        case CapaDeNegocios.Asistencia.cAsistenciaDia.TipoFalta.FaltaJustificada:
                            lblFaltaDia.Text = "Falta Justificada";
                            lblFaltaDia.ForeColor = Color.Blue;
                            break;
                        case CapaDeNegocios.Asistencia.cAsistenciaDia.TipoFalta.FaltaTotal:
                            lblFaltaDia.Text = "Falta al picar entrada y salida";
                            lblFaltaDia.ForeColor = Color.Red;
                            break;
                        case CapaDeNegocios.Asistencia.cAsistenciaDia.TipoFalta.SinFalta:
                            lblFaltaDia.Text = "No";
                            lblFaltaDia.ForeColor = Color.Green;
                            break;
                        default:
                            break;
                    }
                    
                    
                }
                
            }
            
        }

        private void CalendarioAsistencia_DateSelected(object sender, DateRangeEventArgs e)
        {
            //if (oAsistenciaMes != null)
            //{
            //    foreach (CapaDeNegocios.Asistencia.cAsistenciaDia item in oAsistenciaMes.ListaAsistenciaDia)
            //    {
            //        if (item.Dia.Date == e.Start)
            //        {
            //            dtgDetalleAsistencia.DataSource = item.ListaPicados;
            //            dtgListaSalidas.DataSource = item.ListaSalidas;
            //        }
            //    }
            //}
        }

        private void DarFormato()
        {
            dtgDetalleAsistencia.Columns.Add("colTrabajador", "Trabajador");
            dtgDetalleAsistencia.Columns["colTrabajador"].DataPropertyName = "TrabajadorReloj";
            dtgDetalleAsistencia.Columns["colTrabajador"].Visible = false;
            dtgDetalleAsistencia.Columns.Add("colPicado", "Picado");
            dtgDetalleAsistencia.Columns["colPicado"].DataPropertyName = "Picado";
            dtgDetalleAsistencia.Columns["colPicado"].Visible = true;
            dtgDetalleAsistencia.Columns.Add("colCodigoPicado", "Codigo");
            dtgDetalleAsistencia.Columns["colCodigoPicado"].DataPropertyName = "CodigoPicado";
            dtgDetalleAsistencia.Columns["colCodigoPicado"].Visible = false;
            dtgDetalleAsistencia.Columns.Add("colDireccionFoto", "Foto");
            dtgDetalleAsistencia.Columns["colDireccionFoto"].DataPropertyName = "DireccionFoto";
            dtgDetalleAsistencia.Columns["colDireccionFoto"].Visible = false;

            dtgListaSalidas.Columns.Add("CodigoExcepcion", "Codigo");
            dtgListaSalidas.Columns["CodigoExcepcion"].DataPropertyName = "CodigoExcepcion";
            dtgListaSalidas.Columns["CodigoExcepcion"].Width = 30;

            dtgListaSalidas.Columns.Add("Tipo", "Tipo");
            dtgListaSalidas.Columns["Tipo"].DataPropertyName = "Tipo";
            dtgListaSalidas.Columns["Tipo"].Width = 80;

            dtgListaSalidas.Columns.Add("Comentario", "Comentario");
            dtgListaSalidas.Columns["Comentario"].DataPropertyName = "Comentario";

            dtgListaSalidas.Columns.Add("InicioExcepcion", "InicioExcepcion");
            dtgListaSalidas.Columns["InicioExcepcion"].DataPropertyName = "InicioExcepcion";

            dtgListaSalidas.Columns.Add("FinExcepcion", "FinExcepcion");
            dtgListaSalidas.Columns["FinExcepcion"].DataPropertyName = "FinExcepcion";

            dtgListaSalidas.Columns.Add("Trabajador", "Trabajador");
            dtgListaSalidas.Columns["Trabajador"].DataPropertyName = "Trabajador";
            dtgListaSalidas.Columns["Trabajador"].Visible = false;
        }

        private void CalendarioAsistencia_DateChanged(object sender, DateRangeEventArgs e)
        {
            CargarDatos();
        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAño.Text != "" && cboMes.Text != "")
            {
                CargarCalendario();
            }
        }

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAño.Text != "" && cboMes.Text != "")
            {
                CargarCalendario();
            }
        }

        private void chkTodoElMes_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                CapaDeNegocios.Reportes.cReporteAsistencia oReporte = new CapaDeNegocios.Reportes.cReporteAsistencia();

                CapaDeNegocios.Reportes.cReportePDF miReporte = new CapaDeNegocios.Reportes.cReportePDF();

                if (dlgGuardarReportePDF.ShowDialog() == DialogResult.OK)
                {
                    oReporte.ImprimirReporteAsistenciaXTrabajador(miTrabajador.OTrabajador, oAsistenciaMes, dlgGuardarReportePDF.FileName);
                }    

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir reporte de asistencia." + ex.Message, "Reporte de Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
