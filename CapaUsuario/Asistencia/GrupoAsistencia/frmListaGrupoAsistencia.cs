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
    public partial class frmListaGrupoAsistencia : Form
    {
        private cCatalogoGrupoAsistencia oCatalogo = new cCatalogoGrupoAsistencia();

        public frmListaGrupoAsistencia()
        {
            InitializeComponent();
        }

        private void frmListaGrupoAsistencia_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            dtgListaGrupos.DataSource = oCatalogo.TraerGrupoAsistencia(false);
        }

        private void btnNuevoGrupo_Click(object sender, EventArgs e)
        {
            frmMantenimientoGrupo fMantenimientoGrupo = new frmMantenimientoGrupo();
            fMantenimientoGrupo.oGrupoAsistencia = new cGrupoAsistencia();
            if (fMantenimientoGrupo.ShowDialog() == DialogResult.OK )
            {
                oCatalogo.CrearGrupoAsistencia(fMantenimientoGrupo.oGrupoAsistencia);
                MessageBox.Show("Grupo Creado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Operacion Cancelada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnModificarGrupo_Click(object sender, EventArgs e)
        {
            if (dtgListaGrupos.SelectedRows.Count > 0)
            {
                frmMantenimientoGrupo fMantenimientoGrupo = new frmMantenimientoGrupo();
                fMantenimientoGrupo.oGrupoAsistencia = (cGrupoAsistencia)dtgListaGrupos.SelectedRows[0].DataBoundItem;
                if (fMantenimientoGrupo.ShowDialog() == DialogResult.OK)
                {
                    oCatalogo.ModificarGrupoAsistencia(fMantenimientoGrupo.oGrupoAsistencia);
                    MessageBox.Show("Grupo Modificado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar un grupo para modificarlo.", "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminarGrupo_Click(object sender, EventArgs e)
        {
            if (dtgListaGrupos.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea Eliminar el grupo?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    cGrupoAsistencia oGrupoAEliminar = (cGrupoAsistencia)dtgListaGrupos.SelectedRows[0].DataBoundItem;
                    oCatalogo.EliminarGrupoAsistencia(oGrupoAEliminar);
                    MessageBox.Show("Grupo Eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar un grupo para eliminarlo.", "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgListaGrupos.SelectedRows.Count > 0)
                {
                    frmListaDetalle fListaDetalle = new frmListaDetalle();
                    fListaDetalle.oGrupo = (cGrupoAsistencia)dtgListaGrupos.SelectedRows[0].DataBoundItem;
                    if (fListaDetalle.ShowDialog() == DialogResult.OK)
                    {
                        CargarDatos();
                    }
                }
                else
                {
                    MessageBox.Show("Debe Seleccionar un grupo para ver sus detalles.", "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en ver detalles: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
