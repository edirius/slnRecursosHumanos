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
    public partial class frmNuevoHorario : Form
    {
        public CapaDeNegocios.Asistencia.cHorario oHorario;

        CapaDeNegocios.Asistencia.cTurnoDia oTurnoDia = new CapaDeNegocios.Asistencia.cTurnoDia();

        CapaDeNegocios.Asistencia.cCatalogoAsistencia oCatalogo= new CapaDeNegocios.Asistencia.cCatalogoAsistencia();


        public frmNuevoHorario()
        {
            InitializeComponent();
        }

        private void frmNuevoHorario_Load(object sender, EventArgs e)
        {
            CargarCombos();
            Iniciar();
        }

        private void CargarCombos()
        {
            List<CapaDeNegocios.Asistencia.cTurnoDia> ListaTurnosLunes = new List<CapaDeNegocios.Asistencia.cTurnoDia>();
            ListaTurnosLunes = oCatalogo.ListaTurnosDiasyVacio();
            List<CapaDeNegocios.Asistencia.cTurnoDia> ListaTurnosMartes = new List<CapaDeNegocios.Asistencia.cTurnoDia>();
            ListaTurnosMartes = oCatalogo.ListaTurnosDiasyVacio();
            List<CapaDeNegocios.Asistencia.cTurnoDia> ListaTurnosMiercoles = new List<CapaDeNegocios.Asistencia.cTurnoDia>();
            ListaTurnosMiercoles = oCatalogo.ListaTurnosDiasyVacio();
            List<CapaDeNegocios.Asistencia.cTurnoDia> ListaTurnosJueves = new List<CapaDeNegocios.Asistencia.cTurnoDia>();
            ListaTurnosJueves = oCatalogo.ListaTurnosDiasyVacio();
            List<CapaDeNegocios.Asistencia.cTurnoDia> ListaTurnosViernes = new List<CapaDeNegocios.Asistencia.cTurnoDia>();
            ListaTurnosViernes = oCatalogo.ListaTurnosDiasyVacio();
            List<CapaDeNegocios.Asistencia.cTurnoDia> ListaTurnosSabado = new List<CapaDeNegocios.Asistencia.cTurnoDia>();
            ListaTurnosSabado = oCatalogo.ListaTurnosDiasyVacio();
            List<CapaDeNegocios.Asistencia.cTurnoDia> ListaTurnosDomingo = new List<CapaDeNegocios.Asistencia.cTurnoDia>();
            ListaTurnosDomingo = oCatalogo.ListaTurnosDiasyVacio();

            cboTurnoLunes.DataSource = ListaTurnosLunes;
            cboTurnoLunes.DisplayMember = "NombreTurnoDia";
            cboTurnoLunes.ValueMember = "CodigoTurnoDia";
            cboTurnoMartes.DataSource = ListaTurnosMartes;
            cboTurnoMartes.DisplayMember = "NombreTurnoDia";
            cboTurnoMartes.ValueMember = "CodigoTurnoDia";
            cboTurnoMiercoles.DataSource = ListaTurnosMiercoles;
            cboTurnoMiercoles.DisplayMember = "NombreTurnoDia";
            cboTurnoMiercoles.ValueMember = "CodigoTurnoDia";
            cboTurnoJueves.DataSource = ListaTurnosJueves;
            cboTurnoJueves.DisplayMember = "NombreTurnoDia";
            cboTurnoJueves.ValueMember = "CodigoTurnoDia";
            cboTurnoViernes.DataSource = ListaTurnosViernes;
            cboTurnoViernes.DisplayMember = "NombreTurnoDia";
            cboTurnoViernes.ValueMember = "CodigoTurnoDia";
            cboTurnoSabado.DataSource = ListaTurnosSabado;
            cboTurnoSabado.DisplayMember = "NombreTurnoDia";
            cboTurnoSabado.ValueMember = "CodigoTurnoDia";
            cboTurnoDomingo.DataSource = ListaTurnosDomingo;
            cboTurnoDomingo.DisplayMember = "NombreTurnoDia";
            cboTurnoDomingo.ValueMember = "CodigoTurnoDia";

            
        }

        private void Iniciar()
        {
            txtNombreHorario.Text = oHorario.NombreHorario;

            if (oHorario.TurnoLunes != null)
            {
                cboTurnoLunes.SelectedValue = oHorario.TurnoLunes.CodigoTurnoDia;
            }
            else
            {
                cboTurnoLunes.SelectedValue = 0;
            }

            if (oHorario.TurnoMartes != null)
            {
                cboTurnoMartes.SelectedValue = oHorario.TurnoMartes.CodigoTurnoDia;
            }
            else
            {
                cboTurnoMartes.SelectedValue = 0;
            }

            if (oHorario.TurnoMiercoles != null)
            {
                cboTurnoMiercoles.SelectedValue = oHorario.TurnoMiercoles.CodigoTurnoDia;
            }
            else
            {
                cboTurnoMiercoles.SelectedValue = 0;
            }

            if (oHorario.TurnoJueves != null)
            {
                cboTurnoJueves.SelectedValue = oHorario.TurnoJueves.CodigoTurnoDia;
            }
            else
            {
                cboTurnoJueves.SelectedValue = 0;
            }

            if (oHorario.TurnoViernes != null)
            {
                cboTurnoViernes.SelectedValue = oHorario.TurnoViernes.CodigoTurnoDia;
            }
            else
            {
                cboTurnoViernes.SelectedValue = 0;
            }

            if (oHorario.TurnoSabado != null)
            {
                cboTurnoSabado.SelectedValue = oHorario.TurnoSabado.CodigoTurnoDia;
            }
            else
            {
                cboTurnoSabado.SelectedValue = 0;
            }

            if (oHorario.TurnoDomingo != null)
            {
                cboTurnoDomingo.SelectedValue = oHorario.TurnoDomingo.CodigoTurnoDia;
            }
            else
            {
                cboTurnoDomingo.SelectedValue = 0;
            }
            if (oHorario.InicioMes == 0)
            {
                oHorario.InicioMes = 1;
            }

                if (oHorario.InicioMes == 1)
            {
                chkInicioMensual.Checked = true;
                numInicioMes.Value = 1;
            }
            else
            {
                chkInicioMensual.Checked = false;
                numInicioMes.Value = oHorario.InicioMes;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtNombreHorario.Text == "")
                {
                    MessageBox.Show("El nombre de horario esta vacio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    oHorario.NombreHorario = txtNombreHorario.Text;
                    oHorario.TurnoLunes = (CapaDeNegocios.Asistencia.cTurnoDia)cboTurnoLunes.SelectedItem;
                    oHorario.TurnoMartes = (CapaDeNegocios.Asistencia.cTurnoDia)cboTurnoMartes.SelectedItem;
                    oHorario.TurnoMiercoles = (CapaDeNegocios.Asistencia.cTurnoDia)cboTurnoMiercoles.SelectedItem;
                    oHorario.TurnoJueves = (CapaDeNegocios.Asistencia.cTurnoDia)cboTurnoJueves.SelectedItem;
                    oHorario.TurnoViernes = (CapaDeNegocios.Asistencia.cTurnoDia)cboTurnoViernes.SelectedItem;
                    oHorario.TurnoSabado = (CapaDeNegocios.Asistencia.cTurnoDia)cboTurnoSabado.SelectedItem;
                    oHorario.TurnoDomingo = (CapaDeNegocios.Asistencia.cTurnoDia)cboTurnoDomingo.SelectedItem;
                    oHorario.InicioMes = Convert.ToInt16(numInicioMes.Value);
                    DialogResult = DialogResult.OK;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkInicioMensual_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInicioMensual.Checked)
            {
                numInicioMes.Enabled = false;
            }
            else
            {
                numInicioMes.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
