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
            oAsistenciaMes = oCatalogoAsistencia.LLenarAsistencia(miTrabajador.OTrabajador, cboMes.SelectedIndex + 1, Convert.ToInt16(cboAño.Text));
            CalendarioAsistencia.MinDate = oAsistenciaMes.InicioMes;
            CalendarioAsistencia.MaxDate = oAsistenciaMes.FinMes;
            
            


            oAsistenciaMes.ListaAsistenciaDia = oAsistenciaMes.LlenarAsistencias(oCatalogoAsistencia.ListaPicadoxMes(miTrabajador, CalendarioAsistencia.SelectionStart),oAsistenciaMes.InicioMes, oCatalogoAsistencia.TraerHorarioTrabajador(miTrabajador.OTrabajador));
            oAsistenciaMes.Actualizardatos();

            lblTotalFaltas.Text = oAsistenciaMes.TotalFaltasMes.ToString();
            lblTotaltardanzas.Text = oAsistenciaMes.TotalMinutosTarde.ToString(); // .TotalTardanzas.ToString();

            foreach (CapaDeNegocios.Asistencia.cAsistenciaDia item in oAsistenciaMes.ListaAsistenciaDia)
            {
                if (item.Falta == true)
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
                dtgDetalleAsistencia.DataSource = oCatalogoAsistencia.ListaPicadoxMes(miTrabajador, CalendarioAsistencia.SelectionStart);
            }
            dtgListaSalidas.DataSource = oCatalogoAsistencia.ListaSalidas(miTrabajador.OTrabajador);

            if (oAsistenciaMes.ListaAsistenciaDia.Count > 0)
            {
                oAsistenciaDia = oAsistenciaMes.ListaAsistenciaDia.Find(x => x.Dia.Date == CalendarioAsistencia.SelectionStart);
                if (oAsistenciaDia != null)
                {
                    lblMinutostarde.Text = oAsistenciaDia.MinutosTarde.ToString();
                    if (oAsistenciaDia.Falta == true)
                    {
                        lblFaltaDia.Text = "Si";
                    }
                    else
                    {
                        lblFaltaDia.Text = "No";
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
    }
}
