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
    public partial class frmTrabajadorExcepcion : Form
    {
        CapaDeNegocios.Obras.cCadenaProgramaticaFuncional oCadena = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();

        CapaDeNegocios.Asistencia.cHorarioTrabajador oHorarioTrabajador = new CapaDeNegocios.Asistencia.cHorarioTrabajador();

        CapaDeNegocios.Asistencia.cCatalogoAsistencia oCatalogo = new CapaDeNegocios.Asistencia.cCatalogoAsistencia();

        int pidttrabajador = 0;
        string trabajador = "";

        private string filtroRegimeLaboral = "Todos";
        private string filtroSituacionLaboral = "Todos";

        private DataTable tablaAuxiliar;
        public cTrabajador miListaTrabajadores = new cTrabajador();


        public frmTrabajadorExcepcion()
        {
            InitializeComponent();
            Iniciar();
        }

        private void frmTrabajadorExcepcion_Load(object sender, EventArgs e)
        {
            
        }

        private void Iniciar()
        {
            tablaAuxiliar = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, "", "", "", "", filtroRegimeLaboral, "Todos");

            dtgListaTrabajadores.DataSource = tablaAuxiliar;

            DataGridViewCheckBoxColumn Check = new DataGridViewCheckBoxColumn();//creamos un objeto check
            {
                Check.Name = "☑";//le damos un nombre de cabecera
                dtgListaTrabajadores.Columns.Add(Check);//agregamos los check a cada items

            }
            dtgListaTrabajadores.Columns["☑"].DisplayIndex = 0;
            dtgListaTrabajadores.Columns["☑"].ReadOnly = false;
            dtgListaTrabajadores.Columns["☑"].Width = 30;
            //tablaAuxiliar.Columns["colseleccionar"].DataType = bool;

            //tablaAuxiliar = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral);
            
           
            //if (dtgListaTrabajadores.Rows.Count > 0)
            //{
            //    DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, 0);
            //    dtgListaTrabajadores.Rows[dtgListaTrabajadores.Rows.Count - 1].Selected = true;
            //    dtgListaTrabajadores_CellClick(dtgListaTrabajadores, cea);
            //}

            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                cboAño.Items.Add(i);
            }
            cboAño.Text = DateTime.Now.Year.ToString();
            cboMeta.DisplayMember = "nombreMeta";
            cboMeta.ValueMember = "idtmeta";
            cboMeta.DataSource = oCadena.ListarMetas(Convert.ToInt16(cboAño.Text));
            treeFiltro.ExpandAll();
        }

        private void treeFiltro_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                switch (e.Node.Parent.Text)
                {
                    case "Situacion Laboral":
                        foreach (TreeNode fnode in e.Node.Parent.Nodes)
                        {
                            fnode.BackColor = Color.White;
                        }
                        switch (e.Node.Text)
                        {
                            case "Todos":
                                e.Node.BackColor = Color.Teal;
                                filtroSituacionLaboral = "Todos";
                                break;
                            case "Activos":
                                e.Node.BackColor = Color.Teal;
                                filtroSituacionLaboral = "Activos";
                                break;
                            case "Inactivos":
                                e.Node.BackColor = Color.Teal;
                                filtroSituacionLaboral = "Inactivos";
                                break;
                            case "Sin Periodo Laboral":
                                e.Node.BackColor = Color.Teal;
                                filtroSituacionLaboral = "Sin Periodo Laboral";
                                break;
                        }
                        break;

                    case "Regimen Laboral":
                        foreach (TreeNode fnode in e.Node.Parent.Nodes)
                        {
                            fnode.BackColor = Color.White;
                        }
                        switch (e.Node.Text)
                        {
                            case "Todos":
                                e.Node.BackColor = Color.Teal;
                                filtroRegimeLaboral = "Todos";
                                break;
                            case "Regimen CAS":
                                e.Node.BackColor = Color.Teal;
                                filtroRegimeLaboral = "CAS";
                                break;
                            case "DL. 276":
                                e.Node.BackColor = Color.Teal;
                                filtroRegimeLaboral = "276";
                                break;
                            case "DL. 728":
                                e.Node.BackColor = Color.Teal;
                                filtroRegimeLaboral = "728";
                                break;
                            case "Racionamiento":
                                e.Node.BackColor = Color.Teal;
                                filtroRegimeLaboral = "racionamiento";
                                break;
                            case "DL. 30057":
                                e.Node.BackColor = Color.Teal;
                                filtroRegimeLaboral = "30057";
                                break;
                        }
                        break;
                }
                tablaAuxiliar = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, "", "", "", "", filtroRegimeLaboral, "Todos");
                dtgListaTrabajadores.DataSource = tablaAuxiliar;
               
            }
        }

        private void btnAsignarHorario_Click(object sender, EventArgs e)
        {
            List<cTrabajador> listaTrabajadores = new List<cTrabajador>();

            try
            {
                foreach (DataGridViewRow item in dtgListaTrabajadores.Rows)
                {
                    if (Convert.ToBoolean(item.Cells["☑"].Value) == true)
                    {
                        cTrabajador otrabajador = new cTrabajador();
                        otrabajador = miListaTrabajadores.traerTrabajador(Convert.ToInt16(item.Cells["id_trabajador"].Value.ToString()));
                        listaTrabajadores.Add(otrabajador);
                    }
                }
               

                if (listaTrabajadores.Count > 0)
                {
                    frmTrabajadorHorario fTrabajadorHorario = new frmTrabajadorHorario();
                    fTrabajadorHorario.ListaTrabajadores = listaTrabajadores;
                    if (fTrabajadorHorario.ShowDialog() == DialogResult.OK)
                    {
                        foreach (CapaDeNegocios.Asistencia.cHorarioTrabajador item in fTrabajadorHorario.ListaHorarioTrabajador)
                        {
                            oCatalogo.CrearHorarioTrabajador(item);
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Se canceló la operación.", "Asignar Horarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un trabajador.", "Seleccionar Horario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar horario del trabajador: " + ex.Message, "Asignar Horario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgListaTrabajadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dtgListaTrabajadores_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dtgListaTrabajadores.IsCurrentCellDirty && this.dtgListaTrabajadores.CurrentCell is DataGridViewCheckBoxCell)
            {
                this.dtgListaTrabajadores.EndEdit();
            }
        }

        private void btnNuevaSalidaTrabajador_Click(object sender, EventArgs e)
        {
            List<cTrabajador> listaTrabajadores = new List<cTrabajador>();

            try
            {
                foreach (DataGridViewRow item in dtgListaTrabajadores.Rows)
                {
                    if (Convert.ToBoolean(item.Cells["☑"].Value) == true)
                    {
                        cTrabajador otrabajador = new cTrabajador();
                        otrabajador = miListaTrabajadores.traerTrabajador(Convert.ToInt16(item.Cells["id_trabajador"].Value.ToString()));
                        listaTrabajadores.Add(otrabajador);
                    }
                }


                if (listaTrabajadores.Count > 0)
                {
                    frmMantenimientoSalidas fMantenimientoSalidas = new frmMantenimientoSalidas();
                    fMantenimientoSalidas.oSalidaTrabajador = new CapaDeNegocios.Asistencia.cExcepcionesAsistencia();
                    fMantenimientoSalidas.oSalidaTrabajador.InicioExcepcion = DateTime.Now.Date.AddHours(8);
                    fMantenimientoSalidas.oSalidaTrabajador.FinExcepcion = DateTime.Now;
                    fMantenimientoSalidas.oSalidaTrabajador.Trabajador = listaTrabajadores[0];

                    if (fMantenimientoSalidas.ShowDialog() == DialogResult.OK)
                    {
                        oCatalogo.IngresarNuevaSalida(fMantenimientoSalidas.oSalidaTrabajador);
                        MessageBox.Show("Se ingreso correctamente.", "Ingreso salida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Se canceló la operación.", "Mantenimiento Salidas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un trabajador.", "Seleccionar Horario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar horario del trabajador: " + ex.Message, "Asignar Horario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAsistenciaMes_Click(object sender, EventArgs e)
        {
            List<cTrabajador> listaTrabajadores = new List<cTrabajador>();

            try
            {
                foreach (DataGridViewRow item in dtgListaTrabajadores.Rows)
                {
                    if (Convert.ToBoolean(item.Cells["☑"].Value) == true)
                    {
                        cTrabajador otrabajador = new cTrabajador();
                        otrabajador = miListaTrabajadores.traerTrabajador(Convert.ToInt32(item.Cells["id_trabajador"].Value.ToString()));
                        listaTrabajadores.Add(otrabajador);
                    }
                }


                if (listaTrabajadores.Count > 0)
                {
                    frmAsistenciaMes fAsistenciaMes = new frmAsistenciaMes();
                    

                    fAsistenciaMes.miTrabajador = oCatalogo.TraerTrabajadorReloj(listaTrabajadores[0]);

                    if (fAsistenciaMes.miTrabajador == null)
                    {
                        MessageBox.Show("El trabajador no tiene asignado un codigo del reloj.", "Reloj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (fAsistenciaMes.ShowDialog() == DialogResult.OK)
                        {


                        }
                        else
                        {
                            MessageBox.Show("Se canceló la operación.", "Asistencia Mes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Seleccione un trabajador.", "Seleccionar Horario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar horario del trabajador: " + ex.Message, "Asignar Horario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAsignarNumeroReloj_Click(object sender, EventArgs e)
        {
            List<cTrabajador> listaTrabajadores = new List<cTrabajador>();

            try
            {
                foreach (DataGridViewRow item in dtgListaTrabajadores.Rows)
                {
                    if (Convert.ToBoolean(item.Cells["☑"].Value) == true)
                    {
                        cTrabajador otrabajador = new cTrabajador();
                        otrabajador = miListaTrabajadores.traerTrabajador(Convert.ToInt16(item.Cells["id_trabajador"].Value.ToString()));
                        listaTrabajadores.Add(otrabajador);
                    }
                }


                if (listaTrabajadores.Count > 0)
                {
                    if (listaTrabajadores.Count == 1)
                    {
                        AsignarCodigoReloj fAsignarCodigoReloj = new AsignarCodigoReloj();
                        fAsignarCodigoReloj.oTrabajadorReloj = new CapaDeNegocios.Asistencia.cTrabajadorReloj();
                        fAsignarCodigoReloj.oTrabajadorReloj.OTrabajador = listaTrabajadores[0];

                        if (oCatalogo.TraerTrabajadorRelojXidTrabajador(listaTrabajadores[0].IdTrabajador)== null)
                        {
                            fAsignarCodigoReloj.oTrabajadorReloj.CodigoReloj = -1;
                        }
                        else
                        {
                            fAsignarCodigoReloj.oTrabajadorReloj.CodigoReloj = oCatalogo.TraerTrabajadorRelojXidTrabajador(listaTrabajadores[0].IdTrabajador).CodigoReloj;

                        }
                        

                        if (fAsignarCodigoReloj.ShowDialog() == DialogResult.OK)
                        {
                            if (fAsignarCodigoReloj.modificado == false)
                            {
                                oCatalogo.CrearTrabajadorReloj(fAsignarCodigoReloj.oTrabajadorReloj);
                                MessageBox.Show("Se ingreso el codigo del reloj: " + fAsignarCodigoReloj.oTrabajadorReloj.CodigoReloj + " al trabajador: " + fAsignarCodigoReloj.oTrabajadorReloj.OTrabajador.Nombres + " " + fAsignarCodigoReloj.oTrabajadorReloj.OTrabajador.ApellidoPaterno + " " + fAsignarCodigoReloj.oTrabajadorReloj.OTrabajador.ApellidoMaterno, "Asignado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                oCatalogo.ModificarTrabajadorReloj(fAsignarCodigoReloj.oTrabajadorReloj.OTrabajador, fAsignarCodigoReloj.oTrabajadorReloj.CodigoReloj);
                                MessageBox.Show("Se modifico el codigo del reloj: " + fAsignarCodigoReloj.oTrabajadorReloj.CodigoReloj + " al trabajador: " + fAsignarCodigoReloj.oTrabajadorReloj.OTrabajador.Nombres + " " + fAsignarCodigoReloj.oTrabajadorReloj.OTrabajador.ApellidoPaterno + " " + fAsignarCodigoReloj.oTrabajadorReloj.OTrabajador.ApellidoMaterno, "Asignado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            

                        }
                        else
                        {
                            MessageBox.Show("Se canceló la operación.", "Mantenimiento Salidas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para esta operacion solo debe seleccionar un solo trabajador", "Seleccionar Horario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un trabajador.", "Seleccionar Horario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar horario del trabajador: " + ex.Message, "Asignar Horario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarDNI_Click(object sender, EventArgs e)
        {
            tablaAuxiliar = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, txtBuscarNombre.Text, txtBuscarApellidoPaterno.Text, txtBuscarApellidoMaterno.Text, txtDNI.Text, filtroRegimeLaboral, "Todos");
            dtgListaTrabajadores.DataSource = tablaAuxiliar;
        }

        private void btnBuscarNombre_Click(object sender, EventArgs e)
        {
            tablaAuxiliar = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, txtBuscarNombre.Text, txtBuscarApellidoPaterno.Text, txtBuscarApellidoMaterno.Text, txtDNI.Text, filtroRegimeLaboral, "Todos");
            dtgListaTrabajadores.DataSource = tablaAuxiliar;
        }

        private void btnBuscarAPaterno_Click(object sender, EventArgs e)
        {
            tablaAuxiliar = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, txtBuscarNombre.Text, txtBuscarApellidoPaterno.Text, txtBuscarApellidoMaterno.Text, txtDNI.Text, filtroRegimeLaboral, "Todos");
            dtgListaTrabajadores.DataSource = tablaAuxiliar;
        }

        private void btnBuscarAMaterno_Click(object sender, EventArgs e)
        {
            tablaAuxiliar = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, txtBuscarNombre.Text, txtBuscarApellidoPaterno.Text, txtBuscarApellidoMaterno.Text, txtDNI.Text, filtroRegimeLaboral, "Todos");
            dtgListaTrabajadores.DataSource = tablaAuxiliar;
        }

        private void btnSalidas_Click(object sender, EventArgs e)
        {
            List<cTrabajador> listaTrabajadores = new List<cTrabajador>();

            try
            {
                foreach (DataGridViewRow item in dtgListaTrabajadores.Rows)
                {
                    if (Convert.ToBoolean(item.Cells["☑"].Value) == true)
                    {
                        cTrabajador otrabajador = new cTrabajador();
                        otrabajador = miListaTrabajadores.traerTrabajador(Convert.ToInt16(item.Cells["id_trabajador"].Value.ToString()));
                        listaTrabajadores.Add(otrabajador);
                    }
                }


                if (listaTrabajadores.Count > 0)
                {
                    if (listaTrabajadores.Count == 1)
                    {
                        frmListaSalidas fListaSalidas = new frmListaSalidas();
                        fListaSalidas.miTrabajador = listaTrabajadores[0];
                        fListaSalidas.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Para esta operacion solo debe seleccionar un solo trabajador", "Seleccionar Horario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un trabajador.", "Seleccionar Horario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar horario del trabajador: " + ex.Message, "Asignar Horario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
