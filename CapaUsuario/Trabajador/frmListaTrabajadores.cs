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

namespace CapaUsuario.Trabajador
{
    public partial class frmListaTrabajadores : Form
    {
        CapaDeNegocios.Obras.cCadenaProgramaticaFuncional oCadena = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional(); 

        int pidttrabajador = 0;
        string trabajador = "";

        private string filtroRegimeLaboral = "Todos";
        private string filtroSituacionLaboral = "Todos";

        public frmListaTrabajadores()
        {
            InitializeComponent();
        }

        public cTrabajador miListaTrabajadores = new cTrabajador();

        private void Iniciar()
        {
            dtgListaTrabajadores.DataSource = miListaTrabajadores.ObtenerListaTrabajadores(cboFiltroTrabajadores.Text);
            if (dtgListaTrabajadores.Rows.Count > 0)
            {
                DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, 0);
                dtgListaTrabajadores.Rows[dtgListaTrabajadores.Rows.Count - 1].Selected = true;
                dtgListaTrabajadores_CellClick(dtgListaTrabajadores, cea);
            }

            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                cboAño.Items.Add(i);
            }
            cboAño.Text = DateTime.Now.Year.ToString();
            cboMeta.DisplayMember = "nombreMeta";
            cboMeta.ValueMember = "idtmeta";
            cboMeta.DataSource = oCadena.ListarMetas(Convert.ToInt16(cboAño.Text));

            
        }

          

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListaTrabajadores_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void btnNuevoTrabajador_Click_1(object sender, EventArgs e)
        {
            try
            {
                Trabajador.frmNuevoTrabajador fNuevoTrabajador = new frmNuevoTrabajador();
                fNuevoTrabajador.miTrabajador = new CapaDeNegocios.Trabajadores.cTrabajadorServidorPersonal();
                fNuevoTrabajador.miTrabajador.FechaNacimiento = DateTime.Now;
                if (fNuevoTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miListaTrabajadores.AgregarTrabajador(fNuevoTrabajador.miTrabajador);
                    dtgListaTrabajadores.DataSource = miListaTrabajadores.ObtenerListaTrabajadores(cboFiltroTrabajadores.Text);
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message); 
            }
           
        }

        private void btnModificarTrabajador_Click(object sender, EventArgs e)
        {
            try
            {
                Trabajador.frmNuevoTrabajador fModificarTrabajador = new frmNuevoTrabajador();
                fModificarTrabajador.miTrabajador = new CapaDeNegocios.Trabajadores.cTrabajadorServidorPersonal();
                fModificarTrabajador.miTrabajador = fModificarTrabajador.miTrabajador.traerTrabajador(Convert.ToInt16(dtgListaTrabajadores.SelectedRows[0].Cells[0].Value.ToString()));

                if (fModificarTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miListaTrabajadores.ModificarTrabajador(fModificarTrabajador.miTrabajador);
                    dtgListaTrabajadores.DataSource = miListaTrabajadores.ObtenerListaTrabajadores(cboFiltroTrabajadores.Text);
                }
            }
            catch (Exception g)
            {
                MessageBox.Show(g.Message); 
                
            }
          
        }


       private void btnEliminarTrabajador_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Eliminar", "¿Desea eliminar al trabajador?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    cTrabajador miTrabajador = new cTrabajador();
                    miTrabajador.IdTrabajador = Convert.ToInt16(dtgListaTrabajadores.SelectedRows[0].Cells[0].Value.ToString());
                    miListaTrabajadores.EliminarTrabajador(miTrabajador);
                    dtgListaTrabajadores.DataSource = miListaTrabajadores.ObtenerListaTrabajadores(cboFiltroTrabajadores.Text);
                }
            }
            catch (Exception h)
            {
                MessageBox.Show(h.Message);
            }
            
        }

        private void dtgListaTrabajadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgListaTrabajadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 ) { 
                pidttrabajador = Convert.ToInt32(dtgListaTrabajadores.Rows[e.RowIndex].Cells[0].Value);
                trabajador = Convert.ToString(dtgListaTrabajadores.Rows[e.RowIndex].Cells[2].Value) + " " + Convert.ToString(dtgListaTrabajadores.Rows[e.RowIndex].Cells[3].Value) + " " + Convert.ToString(dtgListaTrabajadores.Rows[e.RowIndex].Cells[4].Value);
            }
        }

        private void btnDatosLaborales_Click(object sender, EventArgs e)
        {
            CapaUsuario.Trabajador.frmMantenimientoPeriodoTrabajador fPeriodoTrabajador = new CapaUsuario.Trabajador.frmMantenimientoPeriodoTrabajador();
            fPeriodoTrabajador.RecibirDatos(pidttrabajador, trabajador);
            fPeriodoTrabajador.ShowDialog();
        }

        private void btnBuscarDNI_Click(object sender, EventArgs e)
        {
            dtgListaTrabajadores.DataSource = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, txtBuscarNombre.Text, txtBuscarApellidoPaterno.Text, txtBuscarApellidoMaterno.Text, txtDNI.Text, filtroRegimeLaboral , "Todos" );
        }

        private void cboFiltroTrabajadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgListaTrabajadores.DataSource = miListaTrabajadores.ObtenerListaTrabajadores(cboFiltroTrabajadores.Text);
        }

        private void btnBuscarNombre_Click(object sender, EventArgs e)
        {
            dtgListaTrabajadores.DataSource = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, txtBuscarNombre.Text, txtBuscarApellidoPaterno.Text, txtBuscarApellidoMaterno.Text, txtDNI.Text, filtroRegimeLaboral, "Todos");
        }

        private void btnBuscarAPaterno_Click(object sender, EventArgs e)
        {
            dtgListaTrabajadores.DataSource = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, txtBuscarNombre.Text, txtBuscarApellidoPaterno.Text, txtBuscarApellidoMaterno.Text, txtDNI.Text, filtroRegimeLaboral, "Todos");
        }

        private void btnBuscarAMaterno_Click(object sender, EventArgs e)
        {
            dtgListaTrabajadores.DataSource = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, txtBuscarNombre.Text, txtBuscarApellidoPaterno.Text, txtBuscarApellidoMaterno.Text, txtDNI.Text, filtroRegimeLaboral, "Todos");
        }

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMeta.DisplayMember = "nombreMeta";
            cboMeta.ValueMember = "idtmeta";
            cboMeta.DataSource = oCadena.ListarMetas(Convert.ToInt16(cboAño.Text));
        }

        private void treeFiltro_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                switch (e.Node.Parent.Text)
                {
                    case "Situacion Laboral":
                        switch (e.Node.Text)
                        {
                            case "Todos":
                                e.Node.BackColor = Color.Aquamarine;
                                filtroSituacionLaboral = "Todos";
                                break;
                            case "Activos":
                                e.Node.BackColor = Color.Aquamarine;
                                filtroSituacionLaboral = "Activos";
                                break;
                            case "Inactivos":
                                e.Node.BackColor = Color.Aquamarine;
                                filtroSituacionLaboral = "Inactivos";
                                break;
                            case "Sin Periodo Laboral":
                                e.Node.BackColor = Color.Aquamarine;
                                filtroSituacionLaboral = "Sin Periodo Laboral";
                                break;
                        }
                        
                        break;
                        
                    case "Regimen Laboral":
                        switch (e.Node.Text)
                        {
                            case "Todos":
                                e.Node.BackColor = Color.Aquamarine;
                                filtroRegimeLaboral = "Todos";
                                break;
                            case "Regimen CAS":
                                e.Node.BackColor = Color.Aquamarine;
                                filtroRegimeLaboral = "CAS";
                                break;
                            case "DL. 276":
                                e.Node.BackColor = Color.Aquamarine;
                                filtroRegimeLaboral = "276";
                                break;
                            case "DL. 728":
                                e.Node.BackColor = Color.Aquamarine;
                                filtroRegimeLaboral = "728";
                                break;
                        }
                        break;
                }
                dtgListaTrabajadores.DataSource = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, "","","","",filtroRegimeLaboral, "Todos");
            }
            
        }

        private void btnBuscarXMeta_Click(object sender, EventArgs e)
        {
            if (cboMeta.SelectedIndex >= 0)
            {
                dtgListaTrabajadores.DataSource = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, txtBuscarNombre.Text, txtBuscarApellidoPaterno.Text, txtBuscarApellidoMaterno.Text, txtDNI.Text, filtroRegimeLaboral, cboMeta.SelectedValue.ToString() );
            }
            
        }
    }
}
