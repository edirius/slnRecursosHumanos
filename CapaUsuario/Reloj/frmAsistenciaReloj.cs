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
                if (chkRangoFechas.Checked == false)
                {
                    ListaHuellasReloj = oServidorReloj.sta_readAttLog(oServidorReloj.Reloj);
                    dtgListaPicados.DataSource = ListaHuellasReloj;
                }
                else
                {
                    ListaHuellasReloj = oServidorReloj.sta_readAttLog(oServidorReloj.Reloj, dtpInicioFecha.Text.Trim().ToString(), dtpFinFecha.Text.Trim().ToString());
                    dtgListaPicados.DataSource = ListaHuellasReloj;
                }
                
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
            dtpInicioFecha.Value = DateTime.Now;
            dtpFinFecha.Value = DateTime.Now;
        }

        private void DarFormatoGrid()
        {
       

            dtgListaPicados.Columns.Add("colIdUsuario", "Id Usuario");
            dtgListaPicados.Columns["colIdUsuario"].DataPropertyName = "IdUsuario";
            dtgListaPicados.Columns.Add("colFechaYHora", "Fecha y Hora");
            dtgListaPicados.Columns["colFechaYHora"].DataPropertyName = "FechaYHora";
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
                int datosGuardados=0;
                
                if (ListaHuellasReloj.Count > 0)
                {
                    foreach (CapaDeNegocios.Reloj.cHuellaUsuarioReloj item in ListaHuellasReloj)
                    {
                        CapaDeNegocios.Asistencia.cPicado miPicado = new CapaDeNegocios.Asistencia.cPicado();
                        miPicado.Picado = item.FechaYHora;
                        miPicado.TrabajadorReloj = new CapaDeNegocios.Asistencia.cTrabajadorReloj();
                        miPicado.TrabajadorReloj.CodigoReloj = Convert.ToInt16(item.IdUsuario);

                        if (oCatalogo.TraerPicadoRelojXTrabajadorFecha(miPicado.TrabajadorReloj.CodigoReloj, miPicado.Picado)== null)
                        {
                            oCatalogo.CrearPicadoReloj(miPicado);
                        }
                        datosGuardados += 1;
                    }
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

        private void chkRangoFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRangoFechas.Checked)
            {
                dtpFinFecha.Enabled = true;
                dtpInicioFecha.Enabled = true;
            }
            else
            {
                dtpFinFecha.Enabled = false;
                dtpInicioFecha.Enabled = false;
            }
        }
    }
}
