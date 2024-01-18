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


namespace CapaUsuario.Usuarios
{
    public partial class frmListaTrabajadores : Form
    {

        cTrabajador MiListaTrabajadores = new cTrabajador();
        CapaDeNegocios.Usuario.cUsuario MiUsuario = new CapaDeNegocios.Usuario.cUsuario();

        public frmListaTrabajadores()
        {
            InitializeComponent();
        }

        private void frmListaTrabajadores_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            dtgListaUsuarios.DataSource = MiUsuario.ListaUsuariosTrabajadores();
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(dtgListaUsuarios.SelectedRows[0].Cells[5].Value)== true)
                {
                    MessageBox.Show("El trabajador ya tiene un usuario", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    frmMantenimientoUsuarios fNuevoUsuario = new frmMantenimientoUsuarios();
                    fNuevoUsuario.miUsuario = new CapaDeNegocios.Usuario.cUsuario();
                    fNuevoUsuario.miUsuario.Trabajador.IdTrabajador = Convert.ToInt16(dtgListaUsuarios.SelectedRows[0].Cells[0].Value);
                    fNuevoUsuario.miUsuario.Trabajador.Nombres = Convert.ToString(dtgListaUsuarios.SelectedRows[0].Cells[1].Value);
                    fNuevoUsuario.miUsuario.Trabajador.ApellidoPaterno = Convert.ToString(dtgListaUsuarios.SelectedRows[0].Cells[2].Value);
                    fNuevoUsuario.miUsuario.Trabajador.ApellidoMaterno = Convert.ToString(dtgListaUsuarios.SelectedRows[0].Cells[3].Value);
                    if (fNuevoUsuario.ShowDialog() == DialogResult.OK)
                    {
                        fNuevoUsuario.miUsuario.CrearUsuario(fNuevoUsuario.miUsuario);
                        MessageBox.Show("Usuario Creado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dtgListaUsuarios.DataSource = MiUsuario.ListaUsuariosTrabajadores();
                    }
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoUsuarios fModificarUsuario = new frmMantenimientoUsuarios();
                fModificarUsuario.miUsuario = new CapaDeNegocios.Usuario.cUsuario();
                fModificarUsuario.miUsuario = MiUsuario.BuscarUsuarioPorCodigo(Convert.ToInt16(dtgListaUsuarios.SelectedRows[0].Cells[0].Value));
                if (fModificarUsuario.ShowDialog() == DialogResult.OK)
                {
                    fModificarUsuario.miUsuario.ModificarUsuario(fModificarUsuario.miUsuario);
                    dtgListaUsuarios.DataSource = MiUsuario.ListaUsuariosTrabajadores();
                }
            }
            catch (Exception h)
            {
                MessageBox.Show(h.Message);
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgListaUsuarios.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Desea cambiar la habilitacion del usuario?", "Deshabilitar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        MiUsuario = MiUsuario.BuscarUsuarioPorCodigo(Convert.ToInt16(dtgListaUsuarios.SelectedRows[0].Cells[0].Value));
                        MiUsuario.CambiarHabilitacionUsuario(MiUsuario, !Convert.ToBoolean(dtgListaUsuarios.SelectedRows[0].Cells[6].Value));
                        dtgListaUsuarios.DataSource = MiUsuario.ListaUsuariosTrabajadores();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar al usuario para cambiar la habilitación");
                }
            }
            catch (Exception g)
            {
                MessageBox.Show(g.Message);
            }
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            dtgListaUsuarios.DataSource = MiUsuario.ListaUsuariosTrabajadoresFiltro("%"+ txtFiltro.Text + "%");
            
        }

        private void btnNuevoResidente_Click(object sender, EventArgs e)
        {
            int idMeta = 1;

            Trabajador.frmNuevoTecnico fNuevoTecnico = new Trabajador.frmNuevoTecnico();
            fNuevoTecnico.RecibirDatos(idMeta);
            fNuevoTecnico.fechaInicio = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, 1);
            fNuevoTecnico.fechaFin = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, 1).AddMonths(1).AddDays(-1);
            if (fNuevoTecnico.ShowDialog() == DialogResult.OK)
            {

            }

        }
    }
}
