using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios.Asistencia.GrupoAsistencia;

namespace CapaUsuario.Asistencia.GrupoAsistencia
{
    public partial class frmListaDetalle : Form
    {
        private cCatalogoGrupoAsistencia oCatalogo = new cCatalogoGrupoAsistencia();
        public cGrupoAsistencia oGrupo;

        public frmListaDetalle()
        {
            InitializeComponent();
        }

        private void frmListaDetalle_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            CargarDatos();
            lblNombre.Text = "Nombre Grupo:" + oGrupo.Descripcion;
        }

        private void CargarDatos()
        {
            dtgDetallesGrupo.DataSource = oCatalogo.TraerDetallesGrupoAsistencia(oGrupo.IdtGrupoAsistencia);
        }

        private void btnAgregarTrabajador_Click(object sender, EventArgs e)
        {
            Planilla.frmTraerTrabajadorVac fTraerTrabajador = new Planilla.frmTraerTrabajadorVac();
            if (fTraerTrabajador.ShowDialog() == DialogResult.OK)
            {
                cDetalleGrupoAsistencia oDetalle = new cDetalleGrupoAsistencia();
                oDetalle.Id_Trabajador = fTraerTrabajador.TrabajadorSeleccionado.IdTrabajador;
                oDetalle.GrupoAsistencia.IdtGrupoAsistencia = oGrupo.IdtGrupoAsistencia;
                oCatalogo.CrearDetalleGrupoAsistencia(oDetalle);
                CargarDatos();
                MessageBox.Show("Trabajador Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Operacion Cancelada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminarTrabajador_Click(object sender, EventArgs e)
        {
            if (dtgDetallesGrupo.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar al trabajador?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    cDetalleGrupoAsistencia oDetalle = (cDetalleGrupoAsistencia)dtgDetallesGrupo.SelectedRows[0].DataBoundItem;
                    oCatalogo.EliminarDetalleGrupoAsistencia(oDetalle);
                    MessageBox.Show("Trabajador Eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Operacion Cancelada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un trabajador para eliminarlo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
           
        }
    }
}
