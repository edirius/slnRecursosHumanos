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
                ListaHuellasReloj = oServidorReloj.sta_readAttLog(oServidorReloj.Reloj);
                ListaHuellasReloj = oCatalogo.FiltrarHuellasPorFecha(ListaHuellasReloj, dtpInicioFecha.Value, dtpFinFecha.Value);
                oCatalogo.LlenarDatosDelTrabajadorListaReloj(ListaHuellasReloj);
                dtgListaPicados.DataSource = ListaHuellasReloj;


                //if (chkRangoFechas.Checked == true)
                //{
                //    ListaHuellasReloj = oServidorReloj.sta_readAttLog(oServidorReloj.Reloj, dtpInicioFecha.Text.Trim().ToString(), dtpFinFecha.Text.Trim().ToString());
                //    dtgListaPicados.DataSource = ListaHuellasReloj;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los registros del reloj: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAsistenciaReloj_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            DarFormatoGrid();
            dtpInicioFecha.Value = DateTime.Now.Date.AddMinutes(1);
            dtpFinFecha.Value = DateTime.Now.Date.AddDays(1).AddMinutes(-1);
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
                        miPicado.TrabajadorReloj.CodigoReloj = Convert.ToInt32(item.IdUsuario);

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

        private void btnFiltrarRangoFecha_Click(object sender, EventArgs e)
        {

        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                CapaDeNegocios.Reloj.cImprimirExcelAsistenciaReloj oImprimir = new CapaDeNegocios.Reloj.cImprimirExcelAsistenciaReloj();
                

                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "AsistenciaDel_" + dtpInicioFecha.Value.ToString("dd_MM_yyyy") + "_al_" + dtpFinFecha.Value.ToString("dd_MM_yyyy") + ".xls";

                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    oImprimir.ruta = fichero.FileName;
                    oImprimir.ListaUsuarios = ListaHuellasReloj;
                    if (oImprimir.ListaUsuarios.Count == 0)
                    {
                        MessageBox.Show("La consulta esta vacia o no hay picados para exportar a excel. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        oImprimir.Imprimir(dtpInicioFecha.Value, dtpFinFecha.Value);
                        //oImprimir.Main();
                        MessageBox.Show("Excel Exportado.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
