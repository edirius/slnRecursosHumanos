using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegociosTramite;
using CapaDeNegocios;
namespace CapaDeUsuarioTramite.Documento
{
    public partial class frmDocumento : Form
    {
        CapaDeNegocios.Contrato.cCargo miCargo = new CapaDeNegocios.Contrato.cCargo();
        CapaDeNegociosTramite.Documento.cDocumento miDocumento = new CapaDeNegociosTramite.Documento.cDocumento();
        CapaDeNegociosTramite.Documento.cTipoDocumento miTipoDocumento = new CapaDeNegociosTramite.Documento.cTipoDocumento();

        public frmDocumento()
        {
            InitializeComponent();
        }

        private void frmDocumento_Load(object sender, EventArgs e)
        {
            CargarComboCargo();
            CargarComboTipoDocumento();
            ActualizarLista();
            ConfiguracionInicial();
        }
        public void ActualizarLista()
        {
            dgvListaDocumentos.DataSource = miDocumento.ListarDocumento();
        }
        public void CargarComboCargo()
        {
            cbCargo.DisplayMember = "descripcion";
            cbCargo.ValueMember = "idtcargo";
            cbCargo.DataSource = miCargo.ListaCargos();
        }
        public void CargarComboTipoDocumento()
        {
            cbTipoDocumento.DisplayMember = "descripcion";
            cbTipoDocumento.ValueMember = "id_tipo_documento";
            cbTipoDocumento.DataSource = miTipoDocumento.ListarTipoDocumento();
        }
        public void ConfiguracionInicial()
        {
            txtExpediente.Text = "";
            txtExpediente.Focus();
            nudFolios.Value = 0;
            txtDependencia.Text = "";
            txtAsunto.Text = "";
            txtDe.Text = "";
            txtFirma.Text = "";
            cbCargo.Text = "seleccione un tipo de cargo";
            cbTipoDocumento.Text = "Seleccione un tipo de documento";
        }
        public void AgregarDocumento()
        {
            if (txtExpediente.Text != "")
            {
                int numero;
                miDocumento.Expediente = txtExpediente.Text;
                miDocumento.FechaDocumento = dtpFecha.Value;
                miDocumento.Folios = int.Parse(nudFolios.Value.ToString());
                miDocumento.Dependencia = txtDependencia.Text;
                miDocumento.Asunto = txtAsunto.Text;
                miDocumento.De = txtDe.Text;
                miDocumento.Firma = txtFirma.Text;
                miDocumento.CodigoCargo = int.Parse(cbCargo.SelectedValue.ToString());
                miDocumento.CodigoTipoDocumento = int.Parse(cbTipoDocumento.SelectedValue.ToString());
                numero = miDocumento.AgregarDocumento();
                //
                if (numero == 1)
                {
                    ActualizarLista();
                    MessageBox.Show("El documento fue agregado correctamente");
                }
                else
                {
                    const string message = "Ya existe un documento con los mismos datos";
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void ModificarDocumento()
        {
            if (txtExpediente.Text != "")
            {
                int numero;
                int valor = dgvListaDocumentos.CurrentCell.RowIndex;
                miDocumento.CodigoDocumento = int.Parse(dgvListaDocumentos[0, valor].Value.ToString());
                miDocumento.Expediente = txtExpediente.Text;
                miDocumento.FechaDocumento = dtpFecha.Value;
                miDocumento.Folios = int.Parse(nudFolios.Value.ToString());
                miDocumento.Dependencia = txtDependencia.Text;
                miDocumento.Asunto = txtAsunto.Text;
                miDocumento.De = txtDe.Text;
                miDocumento.Firma = txtFirma.Text;
                miDocumento.CodigoCargo = int.Parse(cbCargo.SelectedValue.ToString());
                miDocumento.CodigoTipoDocumento = int.Parse(cbTipoDocumento.SelectedValue.ToString());
                numero = miDocumento.ModificarDocumento();
                if (numero == 1)
                {
                    ActualizarLista();
                    MessageBox.Show("El documento fue modificado correctamente");
                }
                else
                {
                    const string message = "No ha seleccionado ningun documento para modificar";
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void EliminarDocumento()
        {
            int numero;
            int valor = dgvListaDocumentos.CurrentCell.RowIndex;
            miDocumento.CodigoDocumento = int.Parse(dgvListaDocumentos[0, valor].Value.ToString());
            numero = miDocumento.EliminarDocumento();
            if (numero == 1)
            {
                ActualizarLista();
                MessageBox.Show("El documento fue eliminado correctamente");
            }
            else
            {
                const string message = "Debe seleccionar un documento";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            AgregarDocumento();
            ConfiguracionInicial();
        }

        private void dgvListaDocumentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int valor = dgvListaDocumentos.CurrentCell.RowIndex;
            miDocumento.CodigoDocumento = int.Parse(dgvListaDocumentos[0, valor].Value.ToString());
            txtExpediente.Text = dgvListaDocumentos[1, valor].Value.ToString();
            dtpFecha.Text = dgvListaDocumentos[2, valor].Value.ToString();
            nudFolios.Text = dgvListaDocumentos[3, valor].Value.ToString();
            txtDependencia.Text = dgvListaDocumentos[4, valor].Value.ToString();
            txtAsunto.Text = dgvListaDocumentos[5, valor].Value.ToString(); ;
            txtDe.Text = dgvListaDocumentos[6, valor].Value.ToString();
            txtFirma.Text = dgvListaDocumentos[7, valor].Value.ToString();
            cbCargo.Text = dgvListaDocumentos[8, valor].Value.ToString();
            cbTipoDocumento.Text = dgvListaDocumentos[9, valor].Value.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarDocumento();
            ConfiguracionInicial();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarDocumento();
            ConfiguracionInicial();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ConfiguracionInicial();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
