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
        int sIdTSunatTipoTrabajador = 0;
        string sTipo = "";
        int sCodigo = 0;

        DataTable oDataPlantillaPlanilla = new DataTable();
        DataTable oDataMaestroIngresos = new DataTable();
        DataTable oDataMaestroDescuentos = new DataTable();
        DataTable oDataMaestroATrabajador = new DataTable();
        DataTable oDataMaestroAEmpleador = new DataTable();

        CapaDeNegocios.Planillas.cPlantillaPlanilla miPlantillaPlanilla = new CapaDeNegocios.Planillas.cPlantillaPlanilla();
        CapaDeNegocios.cTipoTrabajador miTipoTrabajador = new CapaDeNegocios.cTipoTrabajador();

        public frmMantenimientoPlantillaPlanilla()
        {
            InitializeComponent();
        }

        private void frmPlantillaPlanilla_Load(object sender, EventArgs e)
        {
            CargarTipoTrabajador();
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
                fPlantillaPlanilla.RecibirDatos(sIdTSunatTipoTrabajador, sTipo, cboTipoTrabajador.Text, 1);
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
            if (cboTipoTrabajador.Text != "System.Data.DataRowView" && cboTipoTrabajador.ValueMember != "")
            {
                sIdTSunatTipoTrabajador = Convert.ToInt32(cboTipoTrabajador.SelectedValue);
                CargarDatos();
            }
        }

        private void CargarTipoTrabajador()
        {
            cboTipoTrabajador.DataSource = miTipoTrabajador.ListarTiposDeTrabajadores();
            cboTipoTrabajador.DisplayMember = "descripcion";
            cboTipoTrabajador.ValueMember = "idtsunattipotrabajador";
        }

        private void CargarDatos()
        {
            int filaI = 0;
            dgvMaestroIngresos.Rows.Clear();
            dgvMaestroDescuentos.Rows.Clear();
            dgvMaestroATrabajador.Rows.Clear();
            dgvMaestroAEmpleador.Rows.Clear();

            miTipoTrabajador.Codigo = sIdTSunatTipoTrabajador;
            oDataPlantillaPlanilla = miPlantillaPlanilla.ListarPlantillaPlanilla(miTipoTrabajador);

            CapaDeNegocios.Sunat.cMaestroIngresos miMaestroIngresos = new CapaDeNegocios.Sunat.cMaestroIngresos();
            miMaestroIngresos.Tipo = "";
            oDataMaestroIngresos = miMaestroIngresos.ListarMaestroIngresos(miMaestroIngresos);
            CapaDeNegocios.Sunat.cMaestroDescuentos miMaestroDescuentos = new CapaDeNegocios.Sunat.cMaestroDescuentos();
            oDataMaestroDescuentos = miMaestroDescuentos.ListarMaestroDescuentos();
            CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador miMaestroATrabajador = new CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador();
            oDataMaestroATrabajador = miMaestroATrabajador.ListarMaestroAportacionesTrabajador();
            CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador miMaestroAEmpleador = new CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador();
            oDataMaestroAEmpleador = miMaestroAEmpleador.ListarMaestroAportacionesEmpleador();

            foreach (DataRow row in oDataPlantillaPlanilla.Rows)
            {
                if (row[2].ToString() == "INGRESOS")
                {
                    foreach (DataRow rowI in oDataMaestroIngresos.Select("idtmaestroingresos = '" + row[3].ToString() + "'"))
                    {
                        dgvMaestroIngresos.Rows.Add();
                        filaI = dgvMaestroIngresos.RowCount - 1;
                        dgvMaestroIngresos.Rows[filaI].Cells[1].Value = row[0].ToString();
                        dgvMaestroIngresos.Rows[filaI].Cells[2].Value = rowI[1].ToString();
                        dgvMaestroIngresos.Rows[filaI].Cells[3].Value = rowI[2].ToString();
                    }
                }
                else if (row[2].ToString() == "DESCUENTOS")
                {
                    foreach (DataRow rowI in oDataMaestroDescuentos.Select("idtmaestrodescuentos = '" + row[3].ToString() + "'"))
                    {
                        dgvMaestroDescuentos.Rows.Add();
                        filaI = dgvMaestroDescuentos.RowCount - 1;
                        dgvMaestroDescuentos.Rows[filaI].Cells[1].Value = row[0].ToString();
                        dgvMaestroDescuentos.Rows[filaI].Cells[2].Value = rowI[1].ToString();
                        dgvMaestroDescuentos.Rows[filaI].Cells[3].Value = rowI[2].ToString();
                    }
                }
                else if (row[2].ToString() == "A_TRABAJADOR")
                {
                    foreach (DataRow rowI in oDataMaestroATrabajador.Select("idtmaestroaportacionestrabajador = '" + row[3].ToString() + "'"))
                    {
                        dgvMaestroATrabajador.Rows.Add();
                        filaI = dgvMaestroATrabajador.RowCount - 1;
                        dgvMaestroATrabajador.Rows[filaI].Cells[1].Value = row[0].ToString();
                        dgvMaestroATrabajador.Rows[filaI].Cells[2].Value = rowI[1].ToString();
                        dgvMaestroATrabajador.Rows[filaI].Cells[3].Value = rowI[2].ToString();
                    }
                }
                else if (row[2].ToString() == "A_EMPLEADOR")
                {
                    foreach (DataRow rowI in oDataMaestroAEmpleador.Select("idtmaestroaportacionesempleador = '" + row[3].ToString() + "'"))
                    {
                        dgvMaestroAEmpleador.Rows.Add();
                        filaI = dgvMaestroAEmpleador.RowCount - 1;
                        dgvMaestroAEmpleador.Rows[filaI].Cells[1].Value = row[0].ToString();
                        dgvMaestroAEmpleador.Rows[filaI].Cells[2].Value = rowI[1].ToString();
                        dgvMaestroAEmpleador.Rows[filaI].Cells[3].Value = rowI[2].ToString();
                    }
                }
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
                miPlantillaPlanilla.IdtPlantillaPlanilla = Convert.ToInt32(dgvMaestroIngresos.Rows[e.RowIndex].Cells[1].Value);
                miPlantillaPlanilla.EliminarPlantillaPlanilla(miPlantillaPlanilla);
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
                miPlantillaPlanilla.IdtPlantillaPlanilla = Convert.ToInt32(dgvMaestroDescuentos.Rows[e.RowIndex].Cells[1].Value);
                miPlantillaPlanilla.EliminarPlantillaPlanilla(miPlantillaPlanilla);
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
                miPlantillaPlanilla.IdtPlantillaPlanilla = Convert.ToInt32(dgvMaestroATrabajador.Rows[e.RowIndex].Cells[1].Value);
                miPlantillaPlanilla.EliminarPlantillaPlanilla(miPlantillaPlanilla);
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
                miPlantillaPlanilla.IdtPlantillaPlanilla = Convert.ToInt32(dgvMaestroAEmpleador.Rows[e.RowIndex].Cells[1].Value);
                miPlantillaPlanilla.EliminarPlantillaPlanilla(miPlantillaPlanilla);
                CargarDatos();
            }
        }
    }
}
