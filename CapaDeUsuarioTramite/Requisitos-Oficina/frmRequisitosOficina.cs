using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDeUsuarioTramite.Solicitud_Oficina
{
    public partial class frmRequisitos : Form
    {
        CapaDeNegociosTramite.Requisito_Oficina.cRequisitoOficina miRequisito = new CapaDeNegociosTramite.Requisito_Oficina.cRequisitoOficina();
        CapaDeNegociosTramite.Oficina.cOficina miOficina = new CapaDeNegociosTramite.Oficina.cOficina();
        public frmRequisitos()
        {
            InitializeComponent();
            ActualizarLista();
        }
        public void ActualizarLista()
        {
            cbOficinas.DisplayMember = "nombre_oficina";
            cbOficinas.ValueMember = "id_oficina";
            dgvListarRequisitos.DataSource = miRequisito.ListarRequisito();
            cbOficinas.DataSource = miOficina.ListarOficina();
            ConfiguracionInicial();
        }
        public void ConfiguracionInicial()
        {
            txtRequisitos.Text = "";
            txtRequisitos.Focus();
        }
        public void AgregarRequisito()
        {
            if (txtRequisitos.Text != "")
            {
                int numero;
                miRequisito.NombreRequisito = txtRequisitos.Text;
                miRequisito.CodigoOficina = int.Parse(cbOficinas.SelectedValue.ToString());
                numero = miRequisito.AgregarRequisito();
                //
                if (numero == 1)
                {
                    ActualizarLista();
                    MessageBox.Show("El requisito fue agregado correctamente");
                }
                else
                {
                    const string message = "Ya existe un requisito con el mismo nombre para esa oficina";
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                const string message = "No escrito el nombre del requisito para esa oficina";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ModificarRequisito()
        {
            if (txtRequisitos.Text != "")
            {
                int numero;
                int valor = dgvListarRequisitos.CurrentCell.RowIndex;
                miRequisito.CodigoRequisitoOficina = int.Parse(dgvListarRequisitos[0, valor].Value.ToString());
                miRequisito.NombreRequisito = txtRequisitos.Text;
                miRequisito.CodigoOficina = int.Parse(cbOficinas.SelectedValue.ToString());
                numero = miRequisito.ModificarRequisito();
                if (numero == 0)
                {
                    ActualizarLista();
                    MessageBox.Show("El requisito fue modificado correctamente");
                }
                else
                {
                    const string message = "No ha seleccionado ninguna Oficina para modificar";
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                const string message = "No ha seleccionado ninguna Oficina para modificar";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EliminarRequisito()
        {
            try
            {
                int numero;
                int valor = dgvListarRequisitos.CurrentCell.RowIndex;
                miRequisito.CodigoRequisitoOficina = int.Parse(dgvListarRequisitos[0, valor].Value.ToString());
                numero = miRequisito.EliminarRequisito();
                if (numero == 1)
                {
                    ActualizarLista();
                    MessageBox.Show("El requisito fue eliminado correctamente");
                }
                else
                {
                    const string message = "Debe seleccionar un requisito";
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                const string message = "No existe el requisito en la base de datos";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            AgregarRequisito();
        }

        private void dgvListarRequisitos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int valor = dgvListarRequisitos.CurrentCell.RowIndex;
            miRequisito.CodigoRequisitoOficina= int.Parse(dgvListarRequisitos[0, valor].Value.ToString());
            txtRequisitos.Text = dgvListarRequisitos[1, valor].Value.ToString();
            cbOficinas.Text = dgvListarRequisitos[2, valor].Value.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarRequisito();
            ActualizarLista();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarRequisito();
            ActualizarLista();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            ConfiguracionInicial();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
