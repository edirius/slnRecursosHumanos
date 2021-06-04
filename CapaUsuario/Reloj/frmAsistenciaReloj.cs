using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Reloj
{
    public partial class frmAsistenciaReloj : Form
    {
        public frmAsistenciaReloj()
        {
            InitializeComponent();
        }

        public CapaDeNegocios.Reloj.cServidorReloj oServidorReloj;

        List<CapaDeNegocios.Reloj.cHuellaUsuarioReloj> ListaHuellasReloj = new List<CapaDeNegocios.Reloj.cHuellaUsuarioReloj>();

        private CapaDeNegocios.Asistencia.cCatalogoAsistencia oCatalogo = new CapaDeNegocios.Asistencia.cCatalogoAsistencia();

        private void btnDescargarAsistencia_Click(object sender, EventArgs e)
        {

            try
            {
                ListaHuellasReloj =  oServidorReloj.sta_readAttLog(oServidorReloj.Reloj);
                dtgListaPicados.DataSource = ListaHuellasReloj;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los registros del reloj: " + ex.Message);
            }
        }

        private void frmAsistenciaReloj_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            DarFormatoGrid();
        }

        private void DarFormatoGrid()
        {
            string _IdUsuario = "";
            int _IdwVerifyMode = 0;
            int _IdwInOutMode = 0;
            int _IdwYear = 0;
            int _IdwMonth = 0;
            int _IdwDay = 0;
            int _IdwHour = 0;
            int _IdwMinute = 0;
            int _IdwSecond = 0;
            int _IdwWorkcode = 0;

            dtgListaPicados.Columns.Add("colIdUsuario", "Id Usuario");
            dtgListaPicados.Columns.Add("colFechaYHora", "Fecha y Hora");
            dtgListaPicados.Columns.Add("colIdwVerifyMode", "IdwVerifyMode");
            dtgListaPicados.Columns.Add("colIdwInOutMode", "IdwInOutMode");
            dtgListaPicados.Columns.Add("colIdwWorkcode", "IdwWorkcode");
            dtgListaPicados.Columns.Add("colIdwYear", "IdwYear");
            dtgListaPicados.Columns.Add("colIdwMonth", "_IdwMonth");
            dtgListaPicados.Columns.Add("colIdwDay", "IdwDay");
            dtgListaPicados.Columns.Add("colIdwHour", "IdwHour");
            dtgListaPicados.Columns.Add("colIdwMinute", "IdwMinute");
            dtgListaPicados.Columns.Add("colIdwSecond", "IdwSecond");

            dtgListaPicados.Columns["colFechaYHora"].Width = 200;
            dtgListaPicados.Columns["colIdwYear"].Visible = false;
            dtgListaPicados.Columns["colIdwMonth"].Visible = false;
            dtgListaPicados.Columns["colIdwDay"].Visible = false;
            dtgListaPicados.Columns["colIdwHour"].Visible = false;
            dtgListaPicados.Columns["colIdwMinute"].Visible = false;
            dtgListaPicados.Columns["colIdwSecond"].Visible = false;

        }

        private void btnGuardarAsistencia_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListaHuellasReloj.Count > 0)
                {
                    foreach (CapaDeNegocios.Reloj.cHuellaUsuarioReloj item in ListaHuellasReloj)
                    {
                        CapaDeNegocios.Asistencia.cPicado miPicado = new CapaDeNegocios.Asistencia.cPicado();
                        miPicado.Picado = item.FechaYHora;
                        miPicado.TrabajadorReloj = new CapaDeNegocios.Asistencia.cTrabajadorReloj();
                        miPicado.TrabajadorReloj.CodigoReloj = Convert.ToInt16(item.IdUsuario);
                        oCatalogo.CrearPicadoReloj(miPicado);
                    }
                }
                else
                {
                    MessageBox.Show("No existe records para guardar.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar asistencia: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
