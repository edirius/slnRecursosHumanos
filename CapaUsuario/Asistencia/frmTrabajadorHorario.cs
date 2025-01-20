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
    public partial class frmTrabajadorHorario : Form
    {
        public List<cTrabajador> ListaTrabajadores;

        public List<CapaDeNegocios.Asistencia.cHorarioTrabajador> ListaHorarioTrabajador = new List<CapaDeNegocios.Asistencia.cHorarioTrabajador>();

        CapaDeNegocios.Asistencia.cHorario oHorario = new CapaDeNegocios.Asistencia.cHorario();

        CapaDeNegocios.Asistencia.cCatalogoAsistencia ocatalogo = new CapaDeNegocios.Asistencia.cCatalogoAsistencia();

        public frmTrabajadorHorario()
        {
            InitializeComponent();
        }

        private void frmTrabajadorHorario_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            if (ListaTrabajadores.Count > 1)
            {
                lblNombredelTrabajador.Text = "Varios Trabajadores";
            }
            else
            {
                lblNombredelTrabajador.Text = ListaTrabajadores[0].Nombres + " " + ListaTrabajadores[0].ApellidoPaterno + " " + ListaTrabajadores[0].ApellidoMaterno;
            }

            cboListaHorarios.DataSource = ocatalogo.ListaHorarios();
            cboListaHorarios.DisplayMember = "NombreHorario";
            cboListaHorarios.ValueMember = "CodigoHorario";
        }

        private void btnAsignarHorario_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboListaHorarios.Text != "")
                {
                    foreach (cTrabajador item in ListaTrabajadores)
                    {
                        CapaDeNegocios.Asistencia.cHorarioTrabajador oHorarioTrabajador = ocatalogo.TraerHorarioTrabajadorSiTiene(item);
                        if (oHorarioTrabajador == null)
                        {
                            oHorarioTrabajador = new CapaDeNegocios.Asistencia.cHorarioTrabajador();
                            oHorarioTrabajador.Codigo = 0;
                        }
                        oHorarioTrabajador.Trabajador = item;
                        oHorarioTrabajador.FechaInicioHorario = dtpFechaInicio.Value;
                        oHorarioTrabajador.FechaFinHorario = dtpFechaFin.Value;
                        oHorarioTrabajador.Horario = (CapaDeNegocios.Asistencia.cHorario)cboListaHorarios.SelectedItem;
                        ListaHorarioTrabajador.Add(oHorarioTrabajador);
                        DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un horario", "Seleccionar Horario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en asignar el horario: " + ex.Message);
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
