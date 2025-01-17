using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Reloj
{
    public partial class frmBajarDatosReloj : Form
    {
        public frmBajarDatosReloj()
        {
            InitializeComponent();
        }
        CapaDeNegocios.Reloj.cCatalogoMaquinaReloj oCatalogo = new CapaDeNegocios.Reloj.cCatalogoMaquinaReloj();
        List<CapaDeNegocios.Reloj.cMaquinaReloj> ListaRelojes = new List<CapaDeNegocios.Reloj.cMaquinaReloj>();
        List<CapaDeNegocios.Reloj.cHuellaUsuarioReloj> ListaHuellasReloj = new List<CapaDeNegocios.Reloj.cHuellaUsuarioReloj>();
        private CapaDeNegocios.Asistencia.cCatalogoAsistencia oCatalogoReloj = new CapaDeNegocios.Asistencia.cCatalogoAsistencia();

        private void frmBajarDatosReloj_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            CargarDatosRelojes();
            DarFormatoGrid();
            dtpFecha.Value = DateTime.Now.Date.AddMinutes(1);
        }

        private void CargarDatosRelojes()
        {
            ListaRelojes = oCatalogo.ListaRelojes(true);
            dtgListaRelojes.DataSource = ListaRelojes;
            foreach (DataGridViewRow item in dtgListaRelojes.Rows)
            {
                item.Cells["colSeleccion"].Value = true;
            }
        }

        private void DarFormatoGrid()
        {
            dtgListaPicados.Columns.Add("colIdUsuario", "Id Usuario");
            dtgListaPicados.Columns["colIdUsuario"].DataPropertyName = "IdUsuario";
            dtgListaPicados.Columns.Add("colFechaYHora", "Fecha y Hora");
            dtgListaPicados.Columns["colFechaYHora"].DataPropertyName = "FechaYHora";

            dtgListaPicados.Columns.Add("colNombres", "Nombres");
            dtgListaPicados.Columns["colNombres"].DataPropertyName = "Nombres";

            dtgListaPicados.Columns.Add("colIdwVerifyMode", "IdwVerifyMode");
            dtgListaPicados.Columns["colIdwVerifyMode"].DataPropertyName = "IdwVerifyMode";
            dtgListaPicados.Columns.Add("colIdwInOutMode", "IdwInOutMode");
            dtgListaPicados.Columns["colIdwInOutMode"].DataPropertyName = "IdwInOutMode";
            dtgListaPicados.Columns.Add("colIdwWorkcode", "IdwWorkcode");
            dtgListaPicados.Columns["colIdwWorkcode"].DataPropertyName = "IdwWorkcode";
            dtgListaPicados.Columns.Add("colIdwYear", "IdwYear");
            dtgListaPicados.Columns["colIdwYear"].DataPropertyName = "IdwYear";
            dtgListaPicados.Columns.Add("colIdwMonth", "IdwMonth");
            dtgListaPicados.Columns["colIdwMonth"].DataPropertyName = "IdwMonth";
            dtgListaPicados.Columns.Add("colIdwDay", "IdwDay");
            dtgListaPicados.Columns["colIdwDay"].DataPropertyName = "IdwDay";
            dtgListaPicados.Columns.Add("colIdwHour", "IdwHour");
            dtgListaPicados.Columns["colIdwHour"].DataPropertyName = "IdwHour";
            dtgListaPicados.Columns.Add("colIdwMinute", "IdwMinute");
            dtgListaPicados.Columns["colIdwMinute"].DataPropertyName = "IdwMinute";
            dtgListaPicados.Columns.Add("colIdwSecond", "IdwSecond");
            dtgListaPicados.Columns["colIdwSecond"].DataPropertyName = "IdwSecond";

            dtgListaPicados.Columns["colFechaYHora"].Width = 200;
            dtgListaPicados.Columns["colNombres"].Width = 300;
            dtgListaPicados.Columns["colIdwYear"].Visible = false;
            dtgListaPicados.Columns["colIdwMonth"].Visible = false;
            dtgListaPicados.Columns["colIdwDay"].Visible = false;
            dtgListaPicados.Columns["colIdwHour"].Visible = false;
            dtgListaPicados.Columns["colIdwMinute"].Visible = false;
            dtgListaPicados.Columns["colIdwSecond"].Visible = false;

        }

        private void btnDescargarAsistencia_Click(object sender, EventArgs e)
        {
            foreach ( CapaDeNegocios.Reloj.cMaquinaReloj item in ListaRelojes)
            {
                CapaDeNegocios.Reloj.cServidorReloj oServidorReloj = new CapaDeNegocios.Reloj.cServidorReloj();
                oServidorReloj.Reloj.IP = item.Ip;
                oServidorReloj.Reloj.NumeroMaquina = Convert.ToInt16("0");
                oServidorReloj.Reloj.Puerto = Convert.ToInt16(item.Puerto);
                if (oServidorReloj.ConectarRelojXIP(ref oServidorReloj.Reloj) == 1)
                {
                    DescargaEventos(oServidorReloj);
                    Thread.Sleep(2000);
                }
                else
                {
                    MessageBox.Show("No se puede conectar el reloj: " + item.Activo, "Conectar Reloj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            MessageBox.Show("Datos descargados, presione el boton Guardar para salvar los picados. " , "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DescargaEventos(CapaDeNegocios.Reloj.cServidorReloj oServidorReloj)
        {
            try
            {
                ListaHuellasReloj = oServidorReloj.sta_readAttLog(oServidorReloj.Reloj);
                ListaHuellasReloj = oCatalogoReloj.FiltrarHuellasPorFecha(ListaHuellasReloj, dtpFecha.Value, dtpFecha.Value.AddDays(1).AddMinutes(-1));
                oCatalogoReloj.LlenarDatosDelTrabajadorListaReloj(ListaHuellasReloj);
                dtgListaPicados.DataSource = ListaHuellasReloj;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los registros del reloj: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarAsistencia_Click(object sender, EventArgs e)
        {
            try
            {
                int datosGuardados = 0;

                if (ListaHuellasReloj.Count > 0)
                {
                    foreach (CapaDeNegocios.Reloj.cHuellaUsuarioReloj item in ListaHuellasReloj)
                    {
                        CapaDeNegocios.Asistencia.cPicado miPicado = new CapaDeNegocios.Asistencia.cPicado();
                        miPicado.Picado = item.FechaYHora;
                        miPicado.TrabajadorReloj = new CapaDeNegocios.Asistencia.cTrabajadorReloj();
                        miPicado.TrabajadorReloj.CodigoReloj = Convert.ToInt32(item.IdUsuario);

                        if (oCatalogoReloj.TraerPicadoRelojXTrabajadorFecha(miPicado.TrabajadorReloj.CodigoReloj, miPicado.Picado) == null)
                        {
                            oCatalogoReloj.CrearPicadoReloj(miPicado);
                        }
                        datosGuardados += 1;
                    }
                    MessageBox.Show("Datos guardados: " + datosGuardados.ToString(), "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No existe records para guardar.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                label1.Text = "Datos guardados: " + datosGuardados.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar asistencia: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
