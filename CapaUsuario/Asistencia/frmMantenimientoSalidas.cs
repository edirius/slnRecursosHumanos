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
    }
}
