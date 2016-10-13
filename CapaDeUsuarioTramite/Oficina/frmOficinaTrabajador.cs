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
        DataTable Tabla = new DataTable();
        string mensaje = "";
        string respuesta = "";
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
            dgvTrabajadores.Columns["id_trabajador"].Visible = false;
            dgvTrabajadores.Columns["id_oficina"].Visible = false;
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
                miOficinaTrabajador.CodigoTrabajador = int.Parse(cbTrabajadores.SelectedValue.ToString());
                miOficinaTrabajador.CodigoOficina = int.Parse(cbOficinas.SelectedValue.ToString());
                Tabla = miOficinaTrabajador.AgregarOficinaTrabajador();
                respuesta = Tabla.Rows[0][0].ToString();
                mensaje = Tabla.Rows[0][1].ToString();
                if (respuesta == "1")
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConfiguracionInicial();
                    ActualizarLista();
                }
                else if (respuesta == "0")
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ConfiguracionInicial();
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
                int Valor = dgvTrabajadores.CurrentCell.RowIndex;
                miOficinaTrabajador.CodigoOficinaTrabajador = int.Parse(dgvTrabajadores[0, Valor].Value.ToString());
                miOficinaTrabajador.CodigoTrabajador = int.Parse(cbTrabajadores.SelectedValue.ToString());
                miOficinaTrabajador.CodigoOficina = int.Parse(cbOficinas.SelectedValue.ToString());
                Tabla = miOficinaTrabajador.ModificarOficinaTrabajador();
                respuesta = Tabla.Rows[0][0].ToString();
                mensaje = Tabla.Rows[0][1].ToString();
                if (respuesta == "1")
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConfiguracionInicial();
                    ActualizarLista();
                }
                else if (respuesta == "0")
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ConfiguracionInicial();
                }
            }
            catch
            {
                const string message = "No ha seleccionado algun trabajador o alguna oficina";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EliminarTrabajadorOficina()
        {
            try
            {
                int Valor = dgvTrabajadores.CurrentCell.RowIndex;
                miOficinaTrabajador.CodigoOficinaTrabajador = int.Parse(dgvTrabajadores[0, Valor].Value.ToString());
                Tabla = miOficinaTrabajador.EliminarOficinaTrabajador();
                respuesta = Tabla.Rows[0][0].ToString();
                mensaje = Tabla.Rows[0][1].ToString();
                if (respuesta == "1")
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConfiguracionInicial();
                    ActualizarLista();
                }
                else if (respuesta == "0")
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ConfiguracionInicial();
                }
            }
            catch
            {
                const string message = "No ha seleccionado algun trabajador para eliminar";
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
            cbTrabajadores.Text = dgvTrabajadores[2, Valor].Value.ToString();
            cbOficinas.Text = dgvTrabajadores[3, Valor].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbTrabajadores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
