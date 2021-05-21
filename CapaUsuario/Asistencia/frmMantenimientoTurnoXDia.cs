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
    public partial class frmMantenimientoTurnoXDia : Form
    {
        BindingSource bindingTurnos = new BindingSource();

        public CapaDeNegocios.Asistencia.cTurnoDia oTurnoDia;

        CapaDeNegocios.Asistencia.cTurno oTurno = new CapaDeNegocios.Asistencia.cTurno();

        public frmMantenimientoTurnoXDia()
        {
            InitializeComponent();
        }

        private void frmMantenimientoTurnoXDia_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            txtNombreTurnoXDia.Text = oTurnoDia.NombreTurnoDia;



            bindingTurnos.DataSource = oTurnoDia.ListaTurnos;

            dtgListaTurnos.DataSource = bindingTurnos;
            
            cboListaTurnos.DataSource = oTurno.ListaTurnos();
            cboListaTurnos.DisplayMember = "NombreTurno";
            cboListaTurnos.ValueMember = "CodigoTurno";
        }

        private void FormatearDTGListaTurnos()
        {
            
            dtgListaTurnos.AllowUserToAddRows = false;
            dtgListaTurnos.AllowUserToDeleteRows = false;
            
            dtgListaTurnos.Columns.Add("colCodigoTurno", "Codigo");
            dtgListaTurnos.Columns["colCodigoTurno"].DataPropertyName = "CodigoTurno";
            dtgListaTurnos.Columns["colCodigoTurno"].Width = 50;
            dtgListaTurnos.Columns.Add("colNombreTurno", "Nombre");
            dtgListaTurnos.Columns["colNombreTurno"].DataPropertyName = "NombreTurno";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboListaTurnos.SelectedItem != null)
                {
                    CapaDeNegocios.Asistencia.cTurno NuevoTurno = new CapaDeNegocios.Asistencia.cTurno();
                    NuevoTurno = (CapaDeNegocios.Asistencia.cTurno)cboListaTurnos.SelectedItem;
                    oTurnoDia.ListaTurnos.Add(NuevoTurno);
                    //dtgListaTurnos.DataSource = null;
                    
                    //dtgListaTurnos.DataSource = oTurnoDia.ListaTurnos;
                    bindingTurnos.DataSource = null;
                    FormatearDTGListaTurnos();
                    bindingTurnos.DataSource = oTurnoDia.ListaTurnos;
                    dtgListaTurnos.Refresh();
                    dtgListaTurnos.Update();
                  
                }
                else
                {
                    MessageBox.Show("Seleccione un turno", "Seleccionar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el turno: " + ex.Message, "Agregar Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgListaTurnos.SelectedRows.Count > 0)
                {
                    CapaDeNegocios.Asistencia.cTurno NuevoTurno = new CapaDeNegocios.Asistencia.cTurno();
                    NuevoTurno = oTurnoDia.ListaTurnos.Find(turno => turno.CodigoTurno == Convert.ToInt16(dtgListaTurnos.SelectedRows[0].Cells["colCodigoTurno"].Value.ToString()));
                    oTurnoDia.ListaTurnos.Remove(NuevoTurno);
                    bindingTurnos.DataSource = null;
                    FormatearDTGListaTurnos();
                    bindingTurnos.DataSource = oTurnoDia.ListaTurnos;
                    dtgListaTurnos.Refresh();
                    dtgListaTurnos.Update();
                }
                else
                {
                    MessageBox.Show("Seleccione un turno para quitar.", "Seleccionar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al quitar el turno: " + ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreTurnoXDia.Text != "")
                {
                    oTurnoDia.NombreTurnoDia = txtNombreTurnoXDia.Text;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Debe escribir un nombre del Turno", "Turno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el turno x Dia: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
