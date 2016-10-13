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
    public partial class frmAsistenciaTrabajadores : Form
    {
        int sidttrabajador = 0;
        string strabajador = "";

        private string filtroRegimeLaboral = "Todos";
        private string filtroSituacionLaboral = "Todos";

        private DataTable tablaAuxiliar;

        public cTrabajador miListaTrabajadores = new cTrabajador();

        public frmAsistenciaTrabajadores()
        {
            InitializeComponent();
        }

        private void frmListaTrabajadores_Load(object sender, EventArgs e)
        {
            tablaAuxiliar = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral);
            dtgListaTrabajadores.DataSource = tablaAuxiliar;
            treeFiltro.ExpandAll();
        }

        private void btnBuscarDNI_Click(object sender, EventArgs e)
        {
            tablaAuxiliar = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, "", "", "", txtDNI.Text, filtroRegimeLaboral, "Todos");
            dtgListaTrabajadores.DataSource = tablaAuxiliar;
        }

        private void btnAsistencia_Click(object sender, EventArgs e)
        {
            try
            {
                if (sidttrabajador == 0 || dtgListaTrabajadores.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CapaUsuario.Asistencia.frmDetalleAsistencia fDetalleAsistencia = new frmDetalleAsistencia();
                fDetalleAsistencia.RecibirDatos(sidttrabajador, strabajador);
                //fDetalleAsistencia.MdiParent = this.MdiParent;
                //if (fDetalleAsistencia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //{
                //    //CargarDatos();
                //}
                fDetalleAsistencia.ShowDialog();
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDNI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscarDNI.Focus();
            }
        }

        private void dtgListaTrabajadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgListaTrabajadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                sidttrabajador = Convert.ToInt32(dtgListaTrabajadores.Rows[e.RowIndex].Cells[0].Value);
                strabajador = dtgListaTrabajadores.Rows[e.RowIndex].Cells[2].Value.ToString() + " " + dtgListaTrabajadores.Rows[e.RowIndex].Cells[3].Value.ToString() + " " + dtgListaTrabajadores.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void treeFiltro_AfterSelect(object sender, TreeViewEventArgs e)
        {

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
                        foreach (TreeNode fnode in e.Node.Parent.Nodes )
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
                        }
                        break;
                }
                tablaAuxiliar = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, "", "", "", "", filtroRegimeLaboral, "Todos");
                dtgListaTrabajadores.DataSource = tablaAuxiliar;
            }
        }
    }
}
