using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDeUsuarioTramite.Tramite
{
    public partial class frmTramite : Form
    {
        CapaDeNegociosTramite.Tramite.cTramite miTramite = new CapaDeNegociosTramite.Tramite.cTramite();
        CapaDeNegociosTramite.Oficina.cOficina miOficina = new CapaDeNegociosTramite.Oficina.cOficina();
        CapaDeNegociosTramite.Documento.cDocumento miDocumento = new CapaDeNegociosTramite.Documento.cDocumento();
        public frmTramite()
        {
            InitializeComponent();
            ActualizarLista();
            CargarCombos();
        }
        public void ActualizarLista()
        {
            dgvListarTramites.DataSource = miTramite.ListarTramite();
        }
        public void CargarCombos()
        {
            //cbSede.ValueMember = "id_local_sede";
            //cbSede.DisplayMember = "descripcion";
            //cbSede.DataSource = miSede.ListarSedes();

            //cboOperacion.ValueMember = "id_operacion";
            //cboOperacion.DisplayMember = "descripcion";
            //cboOperacion.DataSource = miOperacion.ListarOperaciones();

            cbOficina.ValueMember = "id_oficina";
            cbOficina.DisplayMember = "nombre_oficina";
            cbOficina.DataSource = miOficina.ListarOficina();

            //cbTrabajador.ValueMember = "";
            //cbTrabajador.DisplayMember = "";
            //cbTrabajador.DataSource = miTramite.ListarTrabajadores();

            cbUnidadDestino.ValueMember = "id_oficina";
            cbUnidadDestino.DisplayMember = "nombre_oficina";
            cbUnidadDestino.DataSource = miOficina.ListarOficina();

            //cboUsuarioDestino.ValueMember = "id_oficina_trabajador";
            //cboUsuarioDestino.DisplayMember = "nombres";
            //cboUsuarioDestino.DataSource = miTramite.ListarTrabajadores();

            cbDocumento.ValueMember = "id_documento";
            cbDocumento.DisplayMember = "expediente";
            cbDocumento.DataSource = miDocumento.ListarDocumento();
        }
        public void AgregarTramite()
        {
            try
            {
                int numero;
                miTramite.CodigoLocalSede = int.Parse(cbSede.SelectedValue.ToString());
                miTramite.FechaHora = dtpFechaHora.Value;
                miTramite.CodigoOperacion = int.Parse(cboOperacion.SelectedValue.ToString());
                miTramite.CodigoOficina = int.Parse(cbOficina.SelectedValue.ToString());
                miTramite.CodigoOficinaTrabajador = int.Parse(cbTrabajador.SelectedValue.ToString());
                miTramite.UnidadDestino = int.Parse(cbUnidadDestino.SelectedValue.ToString());
                miTramite.UsuarioDestino = int.Parse(cboUsuarioDestino.SelectedValue.ToString());
                miTramite.Proveido = txtProveido.Text;
                miTramite.CodigoDocumento = int.Parse(cbDocumento.SelectedValue.ToString());
                numero = miTramite.AgregarTramite();
                if (numero == 1)
                {
                    MessageBox.Show("El tramite se efectuo correctamente");
                    ActualizarLista();
                }
                else
                {
                    const string message = "Ya existe un mismo tramite en esa oficina";
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                const string message = "No ha llenado los datos necesarios";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            AgregarTramite();
        }
    }
}
