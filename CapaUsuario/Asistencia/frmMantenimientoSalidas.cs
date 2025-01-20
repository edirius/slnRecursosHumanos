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
    public partial class frmMantenimientoSalidas : Form
    {
        public CapaDeNegocios.Asistencia.cExcepcionesAsistencia oSalidaTrabajador;

        CapaDeNegocios.Asistencia.cTipoSalida oTipoSalida = new CapaDeNegocios.Asistencia.cTipoSalida();

        public frmMantenimientoSalidas()
        {
            InitializeComponent();
        }

        private void frmMantenimientoSalidas_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        public void Iniciar()
        {
            lblNombredelTrabajador.Text = oSalidaTrabajador.Trabajador.Nombres + " " + oSalidaTrabajador.Trabajador.ApellidoPaterno + " " + oSalidaTrabajador.Trabajador.ApellidoMaterno;
            cboTipoSalidas.DataSource = oTipoSalida.TraerTiposSalida();
            cboTipoSalidas.DisplayMember = "Descripcion";

            //cboTipoSalidas.Items.Add("Comision");
            //cboTipoSalidas.Items.Add("Salud");
            //cboTipoSalidas.Items.Add("Personal");

            cboTipoSalidas.Text = oSalidaTrabajador.Tipo;
            txtComentario.Text = oSalidaTrabajador.Comentario;
            dtpFechaInicio.Value = oSalidaTrabajador.InicioExcepcion;
            dtpFechaFin.Value = oSalidaTrabajador.FinExcepcion;
            chkAprobado.Checked = oSalidaTrabajador.Aprobado;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboTipoSalidas.Text != "")
                {
                    oSalidaTrabajador.Tipo = cboTipoSalidas.Text;
                    oSalidaTrabajador.Comentario = txtComentario.Text;
                    oSalidaTrabajador.InicioExcepcion = dtpFechaInicio.Value;
                    oSalidaTrabajador.FinExcepcion = dtpFechaFin.Value;
                    oSalidaTrabajador.Aprobado = chkAprobado.Checked;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Seleccione un tipo de salida");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar la salida del trabajador: " + ex.Message, "Mantenimiento Trabajador", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnImportarExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog fichero = new OpenFileDialog();
            fichero.Filter = "Excel (*.xlsx)|*.xlsx| Excel (*.xls)|*.xls";
            fichero.FileName = "PAPELETA.xlsX";

            CapaDeNegocios.Asistencia.ImportarPapeleta.cArchivoExcelPapeleta miArchivoExcel = new CapaDeNegocios.Asistencia.ImportarPapeleta.cArchivoExcelPapeleta();
            CapaDeNegocios.Asistencia.ImportarPapeleta.cImportarExcelPapeleta oImportadorExcelPapeleta = new CapaDeNegocios.Asistencia.ImportarPapeleta.cImportarExcelPapeleta();

            if (fichero.ShowDialog() == DialogResult.OK)
            {

                miArchivoExcel.NombreHoja = "Hoja1";
                miArchivoExcel.ColumnaDNI = "I";
                miArchivoExcel.ColumnaNombres = "D";
                miArchivoExcel.FilaAtencionMedica = 10;
                miArchivoExcel.FilaCapacitacionOficializada = 14;
                miArchivoExcel.FilaComisionServicio = 12;
                miArchivoExcel.FilaDescansoMedico = 9;
                miArchivoExcel.FilaFechaFin = 12;
                miArchivoExcel.FilaFechaInicio = 11;
                miArchivoExcel.FilaFinJustificacion = 21;
                miArchivoExcel.FilaHoraFin = 12;
                miArchivoExcel.FilaHoraInicio = 11;
                miArchivoExcel.FilaInicioJustificacion = 20;
                miArchivoExcel.FilaPermisoSinContraprestacion = 11;
                miArchivoExcel.FilaVacaciones = 13;

                CapaDeNegocios.Asistencia.cExcepcionesAsistencia oPapeletaSalidaExcel = oImportadorExcelPapeleta.ImportarExcel(fichero.FileName, miArchivoExcel);

                cboTipoSalidas.Text = oPapeletaSalidaExcel.Tipo;
                txtComentario.Text = oPapeletaSalidaExcel.Comentario;
                dtpFechaInicio.Value = oPapeletaSalidaExcel.InicioExcepcion;
                dtpFechaFin.Value = oPapeletaSalidaExcel.FinExcepcion;
                chkAprobado.Checked = oPapeletaSalidaExcel.Aprobado;
            }
        }
    }
}
