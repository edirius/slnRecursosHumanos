using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Planilla
{
    public partial class frmMantenimientoPlantillaPlanilla : Form
    {
        int sIdTPlantillaPlanilla = 0;
        string sTipo = "";
        int sCodigo = 0;
        int sidtregimenlaboral = 0;

        DataTable oDataPlantillaPlanilla = new DataTable();
        DataTable oDataMaestroIngresos = new DataTable();
        DataTable oDataMaestroDescuentos = new DataTable();
        DataTable oDataMaestroATrabajador = new DataTable();
        DataTable oDataMaestroAEmpleador = new DataTable();

        CapaDeNegocios.Planillas.cPlantillaPlanilla miPlantillaPlanilla = new CapaDeNegocios.Planillas.cPlantillaPlanilla();

        public frmMantenimientoPlantillaPlanilla()
        {
            InitializeComponent();
        }

        private void frmPlantillaPlanilla_Load(object sender, EventArgs e)
        {
            CargarRegimenLaboral();
            cboTipoTrabajador_SelectedIndexChanged(sender, e);
        }

        private void btnTipoTrabajador_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CapaUsuario.Planilla.frmMensajeIngreso fMensaje = new CapaUsuario.Planilla.frmMensajeIngreso();
            if (fMensaje.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sTipo = fMensaje.sMensaje;
                
                CapaUsuario.Planilla.frmPlantillaPlanilla fPlantillaPlanilla = new CapaUsuario.Planilla.frmPlantillaPlanilla();
                fPlantillaPlanilla.RecibirDatos(sTipo, cboRegimenLaboral.Text, sidtregimenlaboral, 1);
                if (fPlantillaPlanilla.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CargarDatos();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboTipoTrabajador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRegimenLaboral.Text != "System.Data.DataRowView" && cboRegimenLaboral.ValueMember != "")
            {
                sidtregimenlaboral = Convert.ToInt32(cboRegimenLaboral.SelectedValue);
                CargarDatos();
            }
        }

        private void dgvMaestroIngresos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMaestroIngresos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMaestroIngresos.Rows[e.RowIndex].Cells[0].Selected == true)
            {
                if (Convert.ToString(dgvMaestroIngresos.Rows[e.RowIndex].Cells[1].Value) == "")
                {
                    MessageBox.Show("No existena datos que se puedan Eliminar", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Está seguro que desea eliminar el Ingreso de la Plantilla de Planilla", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
                sIdTPlantillaPlanilla = Convert.ToInt32(dgvMaestroIngresos.Rows[e.RowIndex].Cells[1].Value);
                miPlantillaPlanilla.EliminarPlantillaPlanilla(sIdTPlantillaPlanilla);
                CargarDatos();
            }
        }

        private void dgvMaestroDescuentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMaestroDescuentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMaestroDescuentos.Rows[e.RowIndex].Cells[0].Selected == true)
            {
                if (Convert.ToString(dgvMaestroDescuentos.Rows[e.RowIndex].Cells[1].Value) == "")
                {
                    MessageBox.Show("No existena datos que se puedan Eliminar", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Está seguro que desea eliminar el Descuento de la Plantilla de Planilla", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
                sIdTPlantillaPlanilla = Convert.ToInt32(dgvMaestroDescuentos.Rows[e.RowIndex].Cells[1].Value);
                miPlantillaPlanilla.EliminarPlantillaPlanilla(sIdTPlantillaPlanilla);
                CargarDatos();
            }
        }

        private void dgvMaestroATrabajador_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMaestroATrabajador_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMaestroATrabajador.Rows[e.RowIndex].Cells[0].Selected == true)
            {
                if (Convert.ToString(dgvMaestroATrabajador.Rows[e.RowIndex].Cells[1].Value) == "")
                {
                    MessageBox.Show("No existena datos que se puedan Eliminar", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Está seguro que desea eliminar las Aportaciones del Trabajador de la Plantilla de Planilla", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
                sIdTPlantillaPlanilla = Convert.ToInt32(dgvMaestroATrabajador.Rows[e.RowIndex].Cells[1].Value);
                miPlantillaPlanilla.EliminarPlantillaPlanilla(sIdTPlantillaPlanilla);
                CargarDatos();
            }
        }

        private void dgvMaestroAEmpleador_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMaestroAEmpleador_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMaestroAEmpleador.Rows[e.RowIndex].Cells[0].Selected == true)
            {
                if (Convert.ToString(dgvMaestroAEmpleador.Rows[e.RowIndex].Cells[1].Value) == "")
                {
                    MessageBox.Show("No existena datos que se puedan Eliminar", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Está seguro que desea eliminar las Aportacion del Empleador de la Plantilla de Planilla", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
                sIdTPlantillaPlanilla = Convert.ToInt32(dgvMaestroAEmpleador.Rows[e.RowIndex].Cells[1].Value);
                miPlantillaPlanilla.EliminarPlantillaPlanilla(sIdTPlantillaPlanilla);
                CargarDatos();
            }
        }

        private void CargarRegimenLaboral()
        {
            CapaDeNegocios.DatosLaborales.cRegimenLaboral miRegimenLaboral = new CapaDeNegocios.DatosLaborales.cRegimenLaboral();
            cboRegimenLaboral.DataSource = miRegimenLaboral.ListarRegimenLaboral();
            cboRegimenLaboral.DisplayMember = "descripcion";
            cboRegimenLaboral.ValueMember = "idtregimenlaboral";
        }

        private void CargarDatos()
        {
            int filaI = 0;
            dgvMaestroIngresos.Rows.Clear();
            dgvMaestroDescuentos.Rows.Clear();
            dgvMaestroATrabajador.Rows.Clear();
            dgvMaestroAEmpleador.Rows.Clear();

            oDataPlantillaPlanilla = miPlantillaPlanilla.ListarPlantillaPlanilla(sidtregimenlaboral);

            CapaDeNegocios.Sunat.cMaestroIngresos miMaestroIngresos = new CapaDeNegocios.Sunat.cMaestroIngresos();
            oDataMaestroIngresos = miMaestroIngresos.ListarMaestroIngresos("");
            CapaDeNegocios.Sunat.cMaestroDescuentos miMaestroDescuentos = new CapaDeNegocios.Sunat.cMaestroDescuentos();
            oDataMaestroDescuentos = miMaestroDescuentos.ListarMaestroDescuentos();
            CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador miMaestroATrabajador = new CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador();
            oDataMaestroATrabajador = miMaestroATrabajador.ListarMaestroAportacionesTrabajador();
            CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador miMaestroAEmpleador = new CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador();
            oDataMaestroAEmpleador = miMaestroAEmpleador.ListarMaestroAportacionesEmpleador();

            foreach (DataRow row in oDataPlantillaPlanilla.Rows)
            {
                if (row[1].ToString() == "INGRESOS")
                {
                    foreach (DataRow rowI in oDataMaestroIngresos.Select("idtmaestroingresos = '" + row[2].ToString() + "'"))
                    {
                        dgvMaestroIngresos.Rows.Add("", row[0].ToString(), rowI[1].ToString(), rowI[2].ToString());
                    }
                }
                else if (row[1].ToString() == "DESCUENTOS")
                {
                    foreach (DataRow rowI in oDataMaestroDescuentos.Select("idtmaestrodescuentos = '" + row[2].ToString() + "'"))
                    {
                        dgvMaestroDescuentos.Rows.Add("", row[0].ToString(), rowI[1].ToString(), rowI[2].ToString());
                    }
                }
                else if (row[1].ToString() == "A_TRABAJADOR")
                {
                    foreach (DataRow rowI in oDataMaestroATrabajador.Select("idtmaestroaportacionestrabajador = '" + row[2].ToString() + "'"))
                    {
                        dgvMaestroATrabajador.Rows.Add("", row[0].ToString(), rowI[1].ToString(), rowI[2].ToString());
                    }
                }
                else if (row[1].ToString() == "A_EMPLEADOR")
                {
                    foreach (DataRow rowI in oDataMaestroAEmpleador.Select("idtmaestroaportacionesempleador = '" + row[2].ToString() + "'"))
                    {
                        dgvMaestroAEmpleador.Rows.Add("", row[0].ToString(), rowI[1].ToString(), rowI[2].ToString());
                    }
                }
            }
        }
    }
}
