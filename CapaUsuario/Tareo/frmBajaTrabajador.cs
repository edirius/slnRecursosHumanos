using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Tareo
{
    public partial class frmBajaTrabajador : Form
    {
        public string sfechafin = "";
        int sidtperiodotrabajador = 0;
        int sidtmotivofinperiodo = 0;
        int sidtTRabajador = 0;

        public frmBajaTrabajador()
        {
            InitializeComponent();
        }

        private void frmBajaTrabajador_Load(object sender, EventArgs e)
        {
            CargarMotivoFinPeriodo();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cboFinPeriodo.SelectedIndex == -1 || cboFinPeriodo.SelectedIndex == 0)
            {
                cboFinPeriodo.BackColor = Color.LightBlue;
                cboFinPeriodo.Focus();
                
                MessageBox.Show("Debe seleccionar un motivo de baja, el mas usual es terminacion de la obra o servicio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Está seguro que desea Dar de Baja al Trabajador, este ya no aparecera en proximos tareos", "Gestion de Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            CapaDeNegocios.Planillas.cDetallePlanilla oDetalle = new CapaDeNegocios.Planillas.cDetallePlanilla();
            sfechafin = monthCalendar1.SelectionRange.Start.ToShortDateString();

            DataTable auxiliar =  oDetalle.EncontrarDetallesPosteriorFecha(monthCalendar1.SelectionRange.Start, sidtTRabajador);

            if (auxiliar.Rows.Count > 0 )
            {
                string mensaje="";
                if (auxiliar.Rows.Count > 2)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        mensaje = mensaje + auxiliar.Rows[i][1].ToString() + " " + auxiliar.Rows[i][13].ToString() + " " + auxiliar.Rows[i][14].ToString() + Environment.NewLine;
                    }

                    mensaje = mensaje + "." + Environment.NewLine;
                    mensaje = mensaje + "." + Environment.NewLine;
                    mensaje = mensaje + "." + Environment.NewLine;
                }
                else
                {
                    for (int i = 0; i < auxiliar.Rows.Count; i++)
                    {
                        mensaje = mensaje + auxiliar.Rows[i][1].ToString() + " " + auxiliar.Rows[i][13].ToString() + " " + auxiliar.Rows[i][13].ToString() + Environment.NewLine;
                    }
                }
                
                MessageBox.Show("Error al dar de baja al trabajador con la fecha: " + sfechafin + ". Se encontró planillas posteriores al mes que quiere dar de baja:  " +Environment.NewLine + mensaje , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            //Periodo Trabajador
            CapaDeNegocios.DatosLaborales.cPeriodoTrabajador miPeriodoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
            miPeriodoTrabajador.BajaPeriodoTrabajador(sfechafin, sidtmotivofinperiodo, sidtperiodotrabajador);

            //Regimen Trabajador
            CapaDeNegocios.DatosLaborales.cRegimenTrabajador miRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
            miRegimenTrabajador.BajaRegimenTrabajador(sfechafin, sidtperiodotrabajador);

            //Regimen Salud Trabajador
            CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador miRegimenSaludTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador();
            miRegimenSaludTrabajador.BajaRegimenSaludTrabajador(sfechafin, sidtperiodotrabajador);

            //Regimen Pensionario Trabajador
            CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador miRegimenPensionarioTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();
            miRegimenPensionarioTrabajador.BajaRegimenPensionarioTrabajador(sfechafin, sidtperiodotrabajador);

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void cboFinPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFinPeriodo.Text != "System.Data.DataRowView" && cboFinPeriodo.ValueMember != "")
            {
                sidtmotivofinperiodo = Convert.ToInt32(cboFinPeriodo.SelectedValue);
            }
        }

        public void RecibirDatos(DateTime fechainicio, int pidtperiodotrabajador, string fechaInicioTrabajador, int idtrabajador)
        {
            sidtperiodotrabajador = pidtperiodotrabajador;
            sidtTRabajador = idtrabajador;
            int AñoInicio = fechainicio.Year;
            int MesInicio = fechainicio.Month;
            int DiasMes = DateTime.DaysInMonth(AñoInicio, MesInicio);
            string fechafin = DiasMes + "/" + MesInicio + "/" + AñoInicio;
            monthCalendar1.MaxDate = Convert.ToDateTime(fechafin);
            monthCalendar1.MinDate = Convert.ToDateTime(fechaInicioTrabajador);
        }

        private void CargarMotivoFinPeriodo()
        {
            CapaDeNegocios.DatosLaborales.cMotivoFinPeriodo miMotivoFinPeriodo = new CapaDeNegocios.DatosLaborales.cMotivoFinPeriodo();
            cboFinPeriodo.DataSource = miMotivoFinPeriodo.ListaMotivosFinPeriodos();
            cboFinPeriodo.DisplayMember = "descripcion";
            cboFinPeriodo.ValueMember = "idtmotivofinperiodo";
            cboFinPeriodo.SelectedIndex = 0;
        }
    }
}
