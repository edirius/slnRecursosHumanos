using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Trabajador
{
    public partial class frmMantenimientoPeriodoTrabajador : Form
    {
        int sidtperiodotrabajador = 0;
        string sfechainicio = "";
        string sfechafin = "";
        int sidtmotivofinperiodo = 0;
        int sidttrabajador = 0;
        string smotivofinperiodo = "";

        CapaDeNegocios.DatosLaborales.cPeriodoTrabajador miPeriodoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();

        public frmMantenimientoPeriodoTrabajador()
        {
            InitializeComponent();
        }

        private void frmPeriodoTrabajador_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnSeguridadSocial_Click(object sender, EventArgs e)
        {
            if (sidtperiodotrabajador == 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CapaUsuario.Trabajador.frmMantenimientoSeguroSocial fSeguroSocialTrabajador = new frmMantenimientoSeguroSocial();
            fSeguroSocialTrabajador.RecibirDatos(sidtperiodotrabajador, sfechainicio, sfechafin);
            fSeguroSocialTrabajador.ShowDialog();
        }

        private void btnRegimenTrabajador_Click(object sender, EventArgs e)
        {
            if (sidtperiodotrabajador == 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CapaUsuario.Trabajador.frmMantenimientoRegimenTrabajador fRegimenTrabajador = new frmMantenimientoRegimenTrabajador();
            fRegimenTrabajador.RecibirDatos(sidtperiodotrabajador, sfechainicio, sfechafin);
            fRegimenTrabajador.ShowDialog();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (dgvPeriodoTrabajador.Rows.Count > 0 && (Convert.ToString(dgvPeriodoTrabajador.Rows[dgvPeriodoTrabajador.Rows.Count - 1].Cells[3].Value) == "" || Convert.ToString(dgvPeriodoTrabajador.Rows[dgvPeriodoTrabajador.Rows.Count - 1].Cells[5].Value) == ""))
            {
                MessageBox.Show("No se puede agregar un nuevo periodo, hasta que el ultimo perido tenga un Fecha Fin y un Motivo de Fin de Periodo", "Mensaje Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CapaUsuario.Trabajador.frmPeriodoTrabajador fPeriodoTrabajador = new frmPeriodoTrabajador();
            if (dgvPeriodoTrabajador.Rows.Count == 0)
            { sfechainicio = ""; }
            else
            { sfechainicio = Convert.ToString(dgvPeriodoTrabajador.Rows[dgvPeriodoTrabajador.Rows.Count - 1].Cells[3].Value); }
            fPeriodoTrabajador.RecibirDatos(0, sfechainicio, "", 0, "", sidttrabajador, txtTrabajador.Text, 1);
            if (fPeriodoTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (sidtperiodotrabajador == 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CapaUsuario.Trabajador.frmPeriodoTrabajador fPeriodoTrabajador = new frmPeriodoTrabajador();
            fPeriodoTrabajador.RecibirDatos(sidtperiodotrabajador, sfechainicio, sfechafin, sidtmotivofinperiodo, smotivofinperiodo, sidttrabajador, txtTrabajador.Text, 2);
            if (fPeriodoTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void dgvPeriodoTrabajador_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPeriodoTrabajador_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) { 
                sidtperiodotrabajador = Convert.ToInt32(dgvPeriodoTrabajador.Rows[e.RowIndex].Cells[1].Value);
                sfechainicio = Convert.ToString(dgvPeriodoTrabajador.Rows[e.RowIndex].Cells[2].Value);
                sfechafin = Convert.ToString(dgvPeriodoTrabajador.Rows[e.RowIndex].Cells[3].Value);
                sidtmotivofinperiodo = Convert.ToInt32(dgvPeriodoTrabajador.Rows[e.RowIndex].Cells[4].Value);
                smotivofinperiodo = Convert.ToString(dgvPeriodoTrabajador.Rows[e.RowIndex].Cells[5].Value);
                if (dgvPeriodoTrabajador.Rows[e.RowIndex].Cells[0].Selected == true)
                {
                    if (sidtperiodotrabajador == 0)
                    {
                        MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (MessageBox.Show("Está seguro que desea eliminar el Periodo del Trabajador", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                    miPeriodoTrabajador.EliminarPeriodoTrabajador(sidtperiodotrabajador);
                    CargarDatos();
                }
            }
        }

        public void RecibirDatos(int pidttrabajador, string ptrabajador)
        {
            sidttrabajador = pidttrabajador;
            txtTrabajador.Text = ptrabajador;
        }

        public void CargarDatos()
        {
            DataTable oDataPeriodoTrabajador = new DataTable();
            DataTable oDataMotivoFinPeriodo = new DataTable();

            dgvPeriodoTrabajador.Rows.Clear();
            oDataPeriodoTrabajador = miPeriodoTrabajador.ListarPeriodoTrabajador(sidttrabajador);

            CapaDeNegocios.DatosLaborales.cMotivoFinPeriodo miMotivoFinPeriodo = new CapaDeNegocios.DatosLaborales.cMotivoFinPeriodo();
            oDataMotivoFinPeriodo = miMotivoFinPeriodo.ListaMotivosFinPeriodos();

            foreach (DataRow row in oDataPeriodoTrabajador.Rows)
            {
                foreach (DataRow row1 in oDataMotivoFinPeriodo.Select("idtmotivofinperiodo ='" + row[3].ToString() + "'"))
                {
                    dgvPeriodoTrabajador.Rows.Add("",row[0].ToString(), row[1].ToString(), row[2].ToString(), row1[0].ToString(), row1[2].ToString());
                }
            }
            if (dgvPeriodoTrabajador.Rows.Count > 0)
            {
                dgvPeriodoTrabajador.Rows[dgvPeriodoTrabajador.Rows.Count - 1].Cells[2].Selected = true;
                DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, dgvPeriodoTrabajador.Rows.Count - 1);
                dgvPeriodoTrabajador_CellClick(dgvPeriodoTrabajador, cea);
            }
        }
    }
}
