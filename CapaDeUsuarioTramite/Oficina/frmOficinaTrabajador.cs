using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDeUsuarioTramite.Oficina
{
    public partial class frmOficinaTrabajador : Form
    {
        CapaDeNegociosTramite.Oficina.cOficinaTrabajador miOficinaTrabajador = new CapaDeNegociosTramite.Oficina.cOficinaTrabajador();
        CapaDeNegociosTramite.Oficina.cOficina miOficina = new CapaDeNegociosTramite.Oficina.cOficina();
        public frmOficinaTrabajador()
        {
            InitializeComponent();
            ActualizarLista();
            CargarComboOficinas();
            CargarComboTrabajadores();
            ConfiguracionInicial();
        }
        public void ActualizarLista()
        {
            dgvTrabajadores.DataSource = miOficinaTrabajador.ListarOficinaTrabajador();
        }
        public void CargarComboTrabajadores()
        {
            cbTrabajadores.ValueMember = "id_trabajador";
            cbTrabajadores.DisplayMember = "Nombres";
            cbTrabajadores.DataSource = miOficinaTrabajador.ListarTrabajadores();
        }
        public void CargarComboOficinas()
        {
            cbOficinas.ValueMember = "id_oficina";
            cbOficinas.DisplayMember = "nombre_oficina";
            cbOficinas.DataSource = miOficina.ListarOficina();
        }
        public void AgregarTrabajadorOficina()
        {
            try
            {
                int numero;
                miOficinaTrabajador.CodigoTrabajador = int.Parse(cbTrabajadores.SelectedValue.ToString());
                miOficinaTrabajador.CodigoOficina = int.Parse(cbOficinas.SelectedValue.ToString());
                numero = miOficinaTrabajador.AgregarOficinaTrabajador();
                if (numero == 1)
                {
                    MessageBox.Show("El trabajador fue asignado a esa oficina correctamente");
                    ActualizarLista();
                }
                else
                {
                    const string message = "El trabajador ya ha sido asignado a una oficina";
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                const string message = "No ha seleccionado algun trabajador o alguna oficina";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ModificarTrabajadorOficina()
        {
            try
            {
                int numero;
                int valor = dgvTrabajadores.CurrentCell.RowIndex;
                miOficinaTrabajador.CodigoOficinaTrabajador = int.Parse(dgvTrabajadores[0, valor].Value.ToString());
                miOficinaTrabajador.CodigoTrabajador = int.Parse(cbTrabajadores.SelectedValue.ToString());
                miOficinaTrabajador.CodigoOficina = int.Parse(cbOficinas.SelectedValue.ToString());
                numero = miOficinaTrabajador.ModificarOficinaTrabajador();
                if (numero == 0)
                {
                    MessageBox.Show("Datos modificados correctamente");
                    ActualizarLista();
                }
                else
                {
                    const string message = "El trabajador ya ha sido asignado a una oficina";
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                const string message = "No ha seleccionado algún trabajador u oficina para modificar";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EliminarTrabajadorOficina()
        {
            try
            {
                int numero;
                int valor = dgvTrabajadores.CurrentCell.RowIndex;
                miOficinaTrabajador.CodigoOficinaTrabajador = int.Parse(dgvTrabajadores[0, valor].Value.ToString());
                numero = miOficinaTrabajador.EliminarOficinaTrabajador();
                if (numero == 1)
                {
                    ActualizarLista();
                    MessageBox.Show("El trabajador fue eliminado de esa oficina exitosamente");
                    
                }
                else
                {
                    const string message = "Debe seccionar un trabajador";
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                const string message = "No existe el trabajador en la base de datos";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ConfiguracionInicial()
        {
            cbTrabajadores.Text = "Seleccione un trabajador";
            cbOficinas.Text = "Seleccione una oficina";
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            AgregarTrabajadorOficina();
            ConfiguracionInicial();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarTrabajadorOficina();
            ConfiguracionInicial();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarTrabajadorOficina();
            ConfiguracionInicial();
        }

        private void dgvTrabajadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Valor = dgvTrabajadores.CurrentCell.RowIndex;
            cbTrabajadores.Text = dgvTrabajadores[1, Valor].Value.ToString();
            cbOficinas.Text = dgvTrabajadores[2, Valor].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
