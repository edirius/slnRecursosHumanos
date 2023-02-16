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
        string sDescripcion = "";
        int sOrden = 0;
        string sTipo = "";
        int sCodigo = 0;
 
        public string[,] smaestro;
        public int sfilasseleccionmaestro = 0;

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
            CargarDescripcion();
            cboDescripcion_SelectedIndexChanged(sender, e);
            if (cboDescripcion.Text == "")
            {
                btnAgregar.Enabled = false;
                btnGuardar.Enabled = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CapaUsuario.Planilla.frmMensajeIngreso fMensaje = new CapaUsuario.Planilla.frmMensajeIngreso();
            if (fMensaje.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sTipo = fMensaje.sMensaje;
                
                CapaUsuario.Planilla.frmPlantillaPlanilla fPlantillaPlanilla = new CapaUsuario.Planilla.frmPlantillaPlanilla();
                fPlantillaPlanilla.RecibirDatos(sTipo);
                if (fPlantillaPlanilla.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    smaestro = fPlantillaPlanilla.smaestro;
                    sfilasseleccionmaestro = fPlantillaPlanilla.sfilasseleccionmaestro;

                    int z = 0;
                    for (int i = 0; i < sfilasseleccionmaestro; i++)
                    {
                        z = 0;
                        if (sTipo == "INGRESOS")
                        {
                            foreach (DataGridViewRow rowDgvIngresos in dgvMaestroIngresos.Rows)
                            {
                                if (Convert.ToString(rowDgvIngresos.Cells[3].Value) == smaestro[i, 0].ToString())
                                {
                                    z = 1;
                                }
                            }
                            if (z == 0)
                            {
                                dgvMaestroIngresos.Rows.Add("", "I", "0", smaestro[i, 0].ToString(), "", smaestro[i, 1].ToString(), smaestro[i, 2].ToString());
                            }
                            else
                            {
                                MessageBox.Show("El Ingreso ya se encuentra en la Formato de Planilla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if (sTipo == "A_TRABAJADOR")
                        {
                            foreach (DataGridViewRow rowDgvTrabajador in dgvMaestroATrabajador.Rows)
                            {
                                if (Convert.ToString(rowDgvTrabajador.Cells[3].Value) == smaestro[i, 0].ToString())
                                {
                                    z = 1;
                                }
                            }
                            if (z == 0)
                            {
                                dgvMaestroATrabajador.Rows.Add("", "I", "0", smaestro[i, 0].ToString(), "", smaestro[i, 1].ToString(), smaestro[i, 2].ToString());
                            }
                            else
                            {
                                MessageBox.Show("El Aporte del Trabajador ya se encuentra en la Formato de Planilla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if (sTipo == "DESCUENTOS")
                        {
                            foreach (DataGridViewRow rowDgvDescuentos in dgvMaestroDescuentos.Rows)
                            {
                                if (Convert.ToString(rowDgvDescuentos.Cells[3].Value) == smaestro[i, 0].ToString())
                                {
                                    z = 1;
                                }
                            }
                            if (z == 0)
                            {
                                dgvMaestroDescuentos.Rows.Add("", "I", "0", smaestro[i, 0].ToString(), "", smaestro[i, 1].ToString(), smaestro[i, 2].ToString());
                            }
                            else
                            {
                                MessageBox.Show("El Descuento ya se encuentra en la Formato de Planilla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if (sTipo == "A_EMPLEADOR")
                        {
                            foreach (DataGridViewRow rowDgvEmpleador in dgvMaestroAEmpleador.Rows)
                            {
                                if (Convert.ToString(rowDgvEmpleador.Cells[3].Value) == smaestro[i, 0].ToString())
                                {
                                    z = 1;
                                }
                            }
                            if (z == 0)
                            {
                                dgvMaestroAEmpleador.Rows.Add("", "I", "0", smaestro[i, 0].ToString(), "", smaestro[i, 1].ToString(), smaestro[i, 2].ToString());
                            }
                            else
                            {
                                MessageBox.Show("El Aporte del Empleador ya se encuentra en la Formato de Planilla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    Numeracion();
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dgvMaestroIngresos.Rows.Clear();
            dgvMaestroATrabajador.Rows.Clear();
            dgvMaestroDescuentos.Rows.Clear();
            dgvMaestroAEmpleador.Rows.Clear();
            cboDescripcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            cboDescripcion.Focus();
            btnAgregar.Enabled = true;
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvMaestroIngresos.Rows.Count == 0 && dgvMaestroATrabajador.Rows.Count == 0 && dgvMaestroDescuentos.Rows.Count == 0 && dgvMaestroAEmpleador.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para Guardar, agrege por lo menos un detalle.", "Gestion del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            miPlantillaPlanilla.Tareo = chkTareo.Checked;
            foreach (DataGridViewRow rowDgvIngresos in dgvMaestroIngresos.Rows)
            {
                miPlantillaPlanilla.IdtPlantillaPlanilla = Convert.ToInt32(rowDgvIngresos.Cells[2].Value);
                miPlantillaPlanilla.Descripcion = cboDescripcion.Text;
                miPlantillaPlanilla.Orden = Convert.ToInt32(rowDgvIngresos.Cells[4].Value);
                miPlantillaPlanilla.Tipo = "INGRESOS";
                miPlantillaPlanilla.Codigo = Convert.ToInt32(rowDgvIngresos.Cells[3].Value);
                if (rowDgvIngresos.Cells[1].Value.ToString() == "I")
                {
                    miPlantillaPlanilla.CrearPlantillaPlanilla(miPlantillaPlanilla);
                }
                else
                {
                    miPlantillaPlanilla.ModificarPlantillaPlanilla(miPlantillaPlanilla);
                }
            }

            foreach (DataGridViewRow rowDgvTrabajador in dgvMaestroATrabajador.Rows)
            {
                miPlantillaPlanilla.IdtPlantillaPlanilla = Convert.ToInt32(rowDgvTrabajador.Cells[2].Value);
                miPlantillaPlanilla.Descripcion = cboDescripcion.Text;
                miPlantillaPlanilla.Orden = Convert.ToInt32(rowDgvTrabajador.Cells[4].Value);
                miPlantillaPlanilla.Tipo = "A_TRABAJADOR";
                miPlantillaPlanilla.Codigo = Convert.ToInt32(rowDgvTrabajador.Cells[3].Value);
                if (rowDgvTrabajador.Cells[1].Value.ToString() == "I")
                {
                    miPlantillaPlanilla.CrearPlantillaPlanilla(miPlantillaPlanilla);
                }
                else
                {
                    miPlantillaPlanilla.ModificarPlantillaPlanilla(miPlantillaPlanilla);
                }
            }

            foreach (DataGridViewRow rowDgvDescuentos in dgvMaestroDescuentos.Rows)
            {
                miPlantillaPlanilla.IdtPlantillaPlanilla = Convert.ToInt32(rowDgvDescuentos.Cells[2].Value);
                miPlantillaPlanilla.Descripcion = cboDescripcion.Text;
                miPlantillaPlanilla.Orden = Convert.ToInt32(rowDgvDescuentos.Cells[4].Value);
                miPlantillaPlanilla.Tipo = "DESCUENTOS";
                miPlantillaPlanilla.Codigo = Convert.ToInt32(rowDgvDescuentos.Cells[3].Value);
                if (rowDgvDescuentos.Cells[1].Value.ToString() == "I")
                {
                    miPlantillaPlanilla.CrearPlantillaPlanilla(miPlantillaPlanilla);
                }
                else
                {
                    miPlantillaPlanilla.ModificarPlantillaPlanilla(miPlantillaPlanilla);
                }
            }

            foreach (DataGridViewRow rowDgvEmpleador in dgvMaestroAEmpleador.Rows)
            {
                miPlantillaPlanilla.IdtPlantillaPlanilla = Convert.ToInt32(rowDgvEmpleador.Cells[2].Value);
                miPlantillaPlanilla.Descripcion = cboDescripcion.Text;
                miPlantillaPlanilla.Orden = Convert.ToInt32(rowDgvEmpleador.Cells[4].Value);
                miPlantillaPlanilla.Tipo = "A_EMPLEADOR";
                miPlantillaPlanilla.Codigo = Convert.ToInt32(rowDgvEmpleador.Cells[3].Value);
                if (rowDgvEmpleador.Cells[1].Value.ToString() == "I")
                {
                    miPlantillaPlanilla.CrearPlantillaPlanilla(miPlantillaPlanilla);
                }
                else
                {
                    miPlantillaPlanilla.ModificarPlantillaPlanilla(miPlantillaPlanilla);
                }
            }

            btnNuevo.Enabled = true;
            cboDescripcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CargarDescripcion();
            cboDescripcion_SelectedIndexChanged(sender, e);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboDescripcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDescripcion.Text != "System.Data.DataRowView")
            {
                sDescripcion = cboDescripcion.Text;
                CargarDatos();
            }
        }

        private void dgvMaestroIngresos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMaestroIngresos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgvMaestroIngresos.Rows[e.RowIndex].Cells[0].Selected == true)
                {
                    if (Convert.ToString(dgvMaestroIngresos.Rows[e.RowIndex].Cells[2].Value) == "0")
                    {
                        dgvMaestroIngresos.Rows.RemoveAt(e.RowIndex);
                        return;
                    }
                    if (MessageBox.Show("Está seguro que desea eliminar el Ingreso de la Plantilla de Planilla", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                    sIdTPlantillaPlanilla = Convert.ToInt32(dgvMaestroIngresos.Rows[e.RowIndex].Cells[2].Value);
                    miPlantillaPlanilla.EliminarPlantillaPlanilla(sIdTPlantillaPlanilla);
                    CargarDatos();
                }
            }
        }

        private void dgvMaestroDescuentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMaestroDescuentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgvMaestroDescuentos.Rows[e.RowIndex].Cells[0].Selected == true)
                {
                    if (Convert.ToString(dgvMaestroDescuentos.Rows[e.RowIndex].Cells[2].Value) == "0")
                    {
                        dgvMaestroDescuentos.Rows.RemoveAt(e.RowIndex);
                        return;
                    }
                    if (MessageBox.Show("Está seguro que desea eliminar el Descuento de la Plantilla de Planilla", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                    sIdTPlantillaPlanilla = Convert.ToInt32(dgvMaestroDescuentos.Rows[e.RowIndex].Cells[2].Value);
                    miPlantillaPlanilla.EliminarPlantillaPlanilla(sIdTPlantillaPlanilla);
                    CargarDatos();
                }
            }
        }

        private void dgvMaestroATrabajador_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMaestroATrabajador_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgvMaestroATrabajador.Rows[e.RowIndex].Cells[0].Selected == true)
                {
                    if (Convert.ToString(dgvMaestroATrabajador.Rows[e.RowIndex].Cells[2].Value) == "0")
                    {
                        dgvMaestroATrabajador.Rows.RemoveAt(e.RowIndex);
                        return;
                    }
                    if (MessageBox.Show("Está seguro que desea eliminar las Aportaciones del Trabajador de la Plantilla de Planilla", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                    sIdTPlantillaPlanilla = Convert.ToInt32(dgvMaestroATrabajador.Rows[e.RowIndex].Cells[2].Value);
                    miPlantillaPlanilla.EliminarPlantillaPlanilla(sIdTPlantillaPlanilla);
                    CargarDatos();
                }
            }
        }

        private void dgvMaestroAEmpleador_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMaestroAEmpleador_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgvMaestroAEmpleador.Rows[e.RowIndex].Cells[0].Selected == true)
                {
                    if (Convert.ToString(dgvMaestroAEmpleador.Rows[e.RowIndex].Cells[2].Value) == "0")
                    {
                        dgvMaestroAEmpleador.Rows.RemoveAt(e.RowIndex);
                        return;
                    }
                    if (MessageBox.Show("Está seguro que desea eliminar las Aportacion del Empleador de la Plantilla de Planilla", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                    sIdTPlantillaPlanilla = Convert.ToInt32(dgvMaestroAEmpleador.Rows[e.RowIndex].Cells[2].Value);
                    miPlantillaPlanilla.EliminarPlantillaPlanilla(sIdTPlantillaPlanilla);
                    CargarDatos();
                }
            }
        }

        private void CargarDescripcion()
        {
            cboDescripcion.DataSource = miPlantillaPlanilla.ListarDescripcionPlantillaPlanilla();
            cboDescripcion.DisplayMember = "descripcion";
        }

        private void CargarDatos()
        {
            dgvMaestroIngresos.Rows.Clear();
            dgvMaestroDescuentos.Rows.Clear();
            dgvMaestroATrabajador.Rows.Clear();
            dgvMaestroAEmpleador.Rows.Clear();

            oDataPlantillaPlanilla = miPlantillaPlanilla.ListarPlantillaPlanilla(sDescripcion);

            CapaDeNegocios.Sunat.cMaestroIngresos miMaestroIngresos = new CapaDeNegocios.Sunat.cMaestroIngresos();
            oDataMaestroIngresos = miMaestroIngresos.ListarMaestroIngresos("");
            CapaDeNegocios.Sunat.cMaestroDescuentos miMaestroDescuentos = new CapaDeNegocios.Sunat.cMaestroDescuentos();
            oDataMaestroDescuentos = miMaestroDescuentos.ListarMaestroDescuentos();
            CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador miMaestroATrabajador = new CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador();
            oDataMaestroATrabajador = miMaestroATrabajador.ListarMaestroAportacionesTrabajador();
            CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador miMaestroAEmpleador = new CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador();
            oDataMaestroAEmpleador = miMaestroAEmpleador.ListarMaestroAportacionesEmpleador();

            if (oDataPlantillaPlanilla.Rows.Count != 0)
            {
                if (Convert.ToBoolean(oDataPlantillaPlanilla.Rows[0][5]))
                {
                    chkTareo.Checked = true;
                }
                else
                {
                    chkTareo.Checked = false;
                }
            }

            foreach (DataRow row in oDataPlantillaPlanilla.Rows)
            {
                if (row[3].ToString() == "INGRESOS")
                {
                    foreach (DataRow rowI in oDataMaestroIngresos.Select("idtmaestroingresos = '" + row[4].ToString() + "'"))
                    {
                        dgvMaestroIngresos.Rows.Add("", "M", row[0].ToString(), rowI[0].ToString(), row[2].ToString(), rowI[1].ToString(), rowI[2].ToString());
                    }
                }
                else if (row[3].ToString() == "DESCUENTOS")
                {
                    foreach (DataRow rowI in oDataMaestroDescuentos.Select("idtmaestrodescuentos = '" + row[4].ToString() + "'"))
                    {
                        dgvMaestroDescuentos.Rows.Add("", "M", row[0].ToString(), rowI[0].ToString(), row[2].ToString(), rowI[1].ToString(), rowI[2].ToString());
                    }
                }
                else if (row[3].ToString() == "A_TRABAJADOR")
                {
                    foreach (DataRow rowI in oDataMaestroATrabajador.Select("idtmaestroaportacionestrabajador = '" + row[4].ToString() + "'"))
                    {
                        dgvMaestroATrabajador.Rows.Add("", "M", row[0].ToString(), rowI[0].ToString(), row[2].ToString(), rowI[1].ToString(), rowI[2].ToString());
                    }
                }
                else if (row[3].ToString() == "A_EMPLEADOR")
                {
                    foreach (DataRow rowI in oDataMaestroAEmpleador.Select("idtmaestroaportacionesempleador = '" + row[4].ToString() + "'"))
                    {
                        dgvMaestroAEmpleador.Rows.Add("", "M", row[0].ToString(), rowI[0].ToString(), row[2].ToString(), rowI[1].ToString(), rowI[2].ToString());
                    }
                }
            }
        }

        private void Numeracion()
        {
            int nro = 0;

            foreach (DataGridViewRow rowDgvIngresos in dgvMaestroIngresos.Rows)
            {
                nro += 1;
                rowDgvIngresos.Cells[4].Value = nro;
            }

            foreach (DataGridViewRow rowDgvTrabajador in dgvMaestroATrabajador.Rows)
            {
                nro += 1;
                rowDgvTrabajador.Cells[4].Value = nro;
            }

            foreach (DataGridViewRow rowDgvDescuentos in dgvMaestroDescuentos.Rows)
            {
                nro += 1;
                rowDgvDescuentos.Cells[4].Value = nro;
            }

            foreach (DataGridViewRow rowDgvEmpleador in dgvMaestroAEmpleador.Rows)
            {
                nro += 1;
                rowDgvEmpleador.Cells[4].Value = nro;
            }
        }
    }
}
