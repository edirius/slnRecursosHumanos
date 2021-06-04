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
    public partial class frmMantenimientoHorario : Form
    {

        CapaDeNegocios.Asistencia.cHorario oHorario = new CapaDeNegocios.Asistencia.cHorario();
        CapaDeNegocios.Asistencia.cCatalogoAsistencia oCatalogo = new CapaDeNegocios.Asistencia.cCatalogoAsistencia();

        public frmMantenimientoHorario()
        {
            InitializeComponent();
        }

        private void btnNuevoHorario_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoHorario fNuevoHorario = new frmNuevoHorario();
                fNuevoHorario.oHorario = new CapaDeNegocios.Asistencia.cHorario();
                if (fNuevoHorario.ShowDialog() == DialogResult.OK)
                {
                    oCatalogo.CrearHorario(fNuevoHorario.oHorario);
                    dtgListaMantenimeintoHorarios.DataSource = oCatalogo.ListaHorarios();
                }
                else
                {
                    MessageBox.Show("Se cancelo el ingreso de nuevo horario.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar el nuevo horario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmMantenimientoHorario_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            dtgListaMantenimeintoHorarios.DataSource = oCatalogo.ListaHorarios();
        }

        private void btnModificarHorario_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgListaMantenimeintoHorarios.SelectedRows.Count > 0)
                {
                    frmNuevoHorario fNuevoHorario = new frmNuevoHorario();
                    fNuevoHorario.oHorario = new CapaDeNegocios.Asistencia.cHorario();
                    fNuevoHorario.oHorario = oCatalogo.ListaHorarios().Find(x => x.CodigoHorario == Convert.ToInt16(dtgListaMantenimeintoHorarios.SelectedRows[0].Cells["CodigoHorario"].Value.ToString()));
                    if (fNuevoHorario.ShowDialog() == DialogResult.OK)
                    {
                        oCatalogo.ModificarHorario(fNuevoHorario.oHorario);
                        dtgListaMantenimeintoHorarios.DataSource = oCatalogo.ListaHorarios();
                    }
                    else
                    {
                        MessageBox.Show("Se cancelo la modificacion del horario.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un horario para modificarlo.", "Horario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el horario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarHorario_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgListaMantenimeintoHorarios.SelectedRows.Count > 0)
                {
                    if ((MessageBox.Show("Desea eliminar el horario?", "Horario", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes))
                    {
                        oCatalogo.EliminarHorario(oCatalogo.ListaHorarios().Find(x => x.CodigoHorario == Convert.ToInt16(dtgListaMantenimeintoHorarios.SelectedRows[0].Cells["CodigoHorario"].Value.ToString())));
                        dtgListaMantenimeintoHorarios.DataSource = oCatalogo.ListaHorarios();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un horario para modificarlo.", "Horario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el horario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
