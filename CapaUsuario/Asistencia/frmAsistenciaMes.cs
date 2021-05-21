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
        public cTrabajador miTrabajador;

        int totalFaltas = 0;
        int totalTardanzas = 0;

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

            lblNombredelTrabajador.Text = miTrabajador.Nombres + " " + miTrabajador.ApellidoPaterno + " " + miTrabajador.ApellidoMaterno;

            DarFormato();
            
        }

        private void CargarCalendario()
        {
            

            oAsistenciaMes = oCatalogoAsistencia.LLenarAsistencia(miTrabajador, cboMes.SelectedIndex + 1, Convert.ToInt16(cboAño.Text));
            CalendarioAsistencia.MinDate = oAsistenciaMes.InicioMes;
            CalendarioAsistencia.MaxDate = oAsistenciaMes.FinMes;
            
            
            foreach (CapaDeNegocios.Asistencia.cAsistenciaDia item in oAsistenciaMes.ListaAsistenciaDia)
            {
                if (item.Falta == true)
                {
                    CalendarioAsistencia.AddBoldedDate(item.Dia);
                    totalFaltas += 1;
                }

                if (item.Tarde == true)
                {
                    totalTardanzas += 1;
                }

            }

            lblTotalFaltas.Text = totalFaltas.ToString();
            lblTotaltardanzas.Text = totalTardanzas.ToString();

        }

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAño.Text != "" || cboMes.Text !="")
            {
                CargarCalendario();
            }
        }

        private void CalendarioAsistencia_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (oAsistenciaMes != null)
            {
                foreach (CapaDeNegocios.Asistencia.cAsistenciaDia item in oAsistenciaMes.ListaAsistenciaDia)
                {
                    if (item.Dia.Date == e.Start)
                    {
                        dtgDetalleAsistencia.DataSource = item.ListaPicados;
                        dtgListaSalidas.DataSource = item.ListaSalidas;
                    }
                }
            }
        }

        private void DarFormato()
        {
            dtgDetalleAsistencia.Columns.Add("colTrabajador", "Trabajador");
            dtgDetalleAsistencia.Columns["colTrabajador"].DataPropertyName = "Trabajador";
            dtgDetalleAsistencia.Columns["colTrabajador"].Visible = false;
            dtgDetalleAsistencia.Columns.Add("colPicado", "Picado");
            dtgDetalleAsistencia.Columns["colPicado"].DataPropertyName = "Picado";
            dtgDetalleAsistencia.Columns["colPicado"].Visible = true;
            dtgDetalleAsistencia.Columns.Add("colDireccionFoto", "Foto");
            dtgDetalleAsistencia.Columns["colDireccionFoto"].DataPropertyName = "DireccionFoto";
            dtgDetalleAsistencia.Columns["colDireccionFoto"].Visible = false;
        }
    }
}
