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
    public partial class frmListaTurnos : Form
    {
        CapaDeNegocios.Asistencia.cTurno oTurno = new CapaDeNegocios.Asistencia.cTurno();

        public frmListaTurnos()
        {
            InitializeComponent();
        }

        private void frmListaTurnos_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            dtgListaTurno.DataSource = oTurno.ListaTurnos();
        }

        private void btnNuevoTurno_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoTurno fMantenimientoTurno = new frmMantenimientoTurno();
                fMantenimientoTurno.oTurno = new CapaDeNegocios.Asistencia.cTurno();
                
                if (fMantenimientoTurno.ShowDialog() == DialogResult.OK)
                {

                }
                else
                {
                    MessageBox.Show("Se canceló la operacion", "Nuevo Turno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el nuevo turno: " + ex.Message, "Nuevo Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarTurnoXDia_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgListaTurno.SelectedRows.Count > 0)
                {
                    frmMantenimientoTurno fMantenimientoTurno = new frmMantenimientoTurno();
                    fMantenimientoTurno.oTurno = oTurno.ListaTurnos().Find(miTurno => miTurno.CodigoTurno == Convert.ToInt16(dtgListaTurno.SelectedRows[0].Cells["colCodigoTurno"].Value.ToString()));
                    if (fMantenimientoTurno.ShowDialog() == DialogResult.OK)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Se cancelo la operacion.", "Mantenimiento de Turno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un turno para modificarlo.", "Modificar Turno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el turno: " + ex.Message, "Modificar Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
