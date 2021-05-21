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
    public partial class frmListaTurnosDia : Form
    {
        CapaDeNegocios.Asistencia.cTurnoDia oTurnoDia = new CapaDeNegocios.Asistencia.cTurnoDia();

        public frmListaTurnosDia()
        {
            InitializeComponent();
        }


        private void frmListaTurnosDia_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            dtgListaTurnoXDia.DataSource = oTurnoDia.ListaTurnosDia();
        }

        private void btnNuevoTurnoxDia_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoTurnoXDia fMantenimientoTurnoXDia = new frmMantenimientoTurnoXDia();
                fMantenimientoTurnoXDia.oTurnoDia = new CapaDeNegocios.Asistencia.cTurnoDia();
                if (fMantenimientoTurnoXDia.ShowDialog() == DialogResult.OK)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el nuevo turno x dia: " + ex.Message, "Nuevo Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarTurnoXDia_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgListaTurnoXDia.SelectedRows.Count > 0)
                {
                    frmMantenimientoTurnoXDia fMantenimientoTurnoXDia = new frmMantenimientoTurnoXDia();
                    fMantenimientoTurnoXDia.oTurnoDia = new CapaDeNegocios.Asistencia.cTurnoDia();
                    fMantenimientoTurnoXDia.oTurnoDia = fMantenimientoTurnoXDia.oTurnoDia.ListaTurnosDia().Find(turnoxdia => turnoxdia.CodigoTurnoDia == Convert.ToInt16(dtgListaTurnoXDia.SelectedRows[0].Cells["colCodigoTurnoDia"].Value.ToString()));
                    if (fMantenimientoTurnoXDia.ShowDialog() == DialogResult.OK)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Se cancelo la operacion", "Modificar Turno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un turno x dia para modificarlo.", "Modificar Turno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el turno x dia: " + ex.Message, "Modificar Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
