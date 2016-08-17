using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Trabajador
{
    public partial class frmNuevoObrero : Form
    {
        int sidtafp = 0;
        int sidttrabajador = 0;
        int sidtperiodotrabajador = 0;
        DataTable oDataTrabajador = new DataTable();
        DataTable oDataPeriodoTrabajador = new DataTable();

        CapaDeNegocios.cDepartamento miDepartamento = new CapaDeNegocios.cDepartamento();
        CapaDeNegocios.cProvincia miProvincia = new CapaDeNegocios.cProvincia();
        CapaDeNegocios.cDistrito miDistrito = new CapaDeNegocios.cDistrito();
        CapaDeNegocios.cTrabajador miTrabajador = new CapaDeNegocios.cTrabajador();

        CapaDeNegocios.cTipoVia miTipoVia = new CapaDeNegocios.cTipoVia();
        CapaDeNegocios.cTipoZona miTipoZona = new CapaDeNegocios.cTipoZona();
        CapaDeNegocios.cNacionalidad miNacionalidad = new CapaDeNegocios.cNacionalidad();

        public frmNuevoObrero()
        {
            InitializeComponent();
        }

        private void frmNuevoObrero_Load(object sender, EventArgs e)
        {
            CargarDepartamento();
            CargarAFP();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtDNI.Text == "" || txtNombre.Text == "" || txtApePaterno.Text == "" || txtApeMaterno.Text == "" || cboDepartamento.Text == "" || cboProvincia.Text == "" || cboDistrito.Text == "" || cboAFP.Text == "" || cboTipoComision.Text == "")
            {
                MessageBox.Show("Existen datos en Blanco, no se puede Guardar al nuevo Trabajador", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool bOk = false;
            miTrabajador.Nombres = txtNombre.Text;
            miTrabajador.ApellidoPaterno = txtApePaterno.Text;
            miTrabajador.ApellidoMaterno = txtApeMaterno.Text;
            if (rbtMasculino.Checked == true) { miTrabajador.Sexo = CapaDeNegocios.EnumSexo.Masculino; }
            else if (rbtFemenino.Checked == true) { miTrabajador.Sexo = CapaDeNegocios.EnumSexo.Femenino; }
            miTrabajador.FechaNacimiento = dtpFechaNacimiento.Value;
            miTrabajador.Dni = txtDNI.Text;
            miTrabajador.CelularPersonal = txtCelular.Text;
            miTrabajador.Direccion = txtDireccion.Text;
            miTrabajador.MiDistrito = miDistrito;
            miTrabajador.MiDistrito.Codigo = miDistrito.Codigo;

            miTrabajador.MiTipoVia = miTipoVia;
            miTrabajador.MiTipoVia.Codigo = 1;
            miTrabajador.MiTipoZOna = miTipoZona;
            miTrabajador.MiTipoZOna.Codigo = 1;
            miTrabajador.MiNacionalidad = miNacionalidad;
            miTrabajador.MiNacionalidad.Codigo = 1;

            miTrabajador.AgregarTrabajador(miTrabajador);
            oDataTrabajador = miTrabajador.ObtenerListaTrabajadores(true);
            sidttrabajador = Convert.ToInt32(oDataTrabajador.Compute("MAX(id_trabajador)", ""));

            CapaDeNegocios.DatosLaborales.cPeriodoTrabajador miPeriodoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
            miPeriodoTrabajador.IdtPeriodoTrabajador = sidtperiodotrabajador;
            miPeriodoTrabajador.FechaInicio = dtpFechaInicio.Value.ToShortDateString();
            //if (dtpFechaFin.Format == DateTimePickerFormat.Custom) { miPeriodoTrabajador.FechaFin = ""; }
            //else { miPeriodoTrabajador.FechaFin = dtpFechaFin.Value.ToShortDateString(); }
            miPeriodoTrabajador.IdtMotivoFinPeriodo = 1;
            miPeriodoTrabajador.IdtTrabajador = sidttrabajador;
            miPeriodoTrabajador.CrearPeriodoTrabajador(miPeriodoTrabajador);
            oDataPeriodoTrabajador = miPeriodoTrabajador.ListarPeriodoTrabajador(sidttrabajador);
            sidtperiodotrabajador = Convert.ToInt32(oDataPeriodoTrabajador.Compute("MAX(idtperiodotrabajador)", ""));

            CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador miRegimenPensionarioTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();
            miRegimenPensionarioTrabajador.IdtRegimenPensionarioTrabajador = 0;
            miRegimenPensionarioTrabajador.FechaInicio = dtpFechaInicio.Value.ToShortDateString();
            //if (dtpFechaFin.Format == DateTimePickerFormat.Custom) { miRegimenPensionarioTrabajador.FechaFin = ""; }
            //else { miRegimenPensionarioTrabajador.FechaFin = dtpFechaFin.Value.ToShortDateString(); }
            //miRegimenPensionarioTrabajador.CUSPP = txtCUSPP.Text;
            miRegimenPensionarioTrabajador.TipoComision = cboTipoComision.Text;
            miRegimenPensionarioTrabajador.IdtAFP = sidtafp;
            miRegimenPensionarioTrabajador.IdtPeriodoTrabajador = sidtperiodotrabajador;
            miRegimenPensionarioTrabajador.CrearRegimenPensionarioTrabajador(miRegimenPensionarioTrabajador);

            CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador miRegimenSaludTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador();
            miRegimenSaludTrabajador.IdtRegimenSaludTrabajador = 0;
            miRegimenSaludTrabajador.RegimenSalud = "ESSALUD REGULAR (Exclusivamente)";
            miRegimenSaludTrabajador.FechaInicio = dtpFechaInicio.Value.ToShortDateString();
            //if (dtpFechaFin.Format == DateTimePickerFormat.Custom) { miRegimenSaludTrabajador.FechaFin = ""; }
            //else { miRegimenSaludTrabajador.FechaFin = dtpFechaFin.Value.ToShortDateString(); }
            //miRegimenSaludTrabajador.EntidadPrestadoraSalud = cboEntidadPrestadoraSalud.Text;
            miRegimenSaludTrabajador.IdtPeriodoTrabajador = sidtperiodotrabajador;
            miRegimenSaludTrabajador.CrearRegimenSaludTrabajador(miRegimenSaludTrabajador);

            CapaDeNegocios.DatosLaborales.cRegimenTrabajador miRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
            miRegimenTrabajador.IdtRegimenTrabajador = 0;
            miRegimenTrabajador.Condicion = "CONTRATADO";
            //miRegimenTrabajador.ServidorConfianza = chkServidorConfianza.Checked;
            //miRegimenTrabajador.NumeroDocumento = txtNumero.Text;
            //miRegimenTrabajador.Periodicidad = cboPeriodicidad.Text;
            //miRegimenTrabajador.TipoPago = cboTipoPago.Text;
            //miRegimenTrabajador.MontoPago = Convert.ToInt32(nupMontoPago.Value);
            miRegimenTrabajador.FechaInicio = dtpFechaInicio.Value.ToShortDateString();
            //if (dtpFechaFin.Format == DateTimePickerFormat.Custom) { miRegimenTrabajador.FechaFin = ""; }
            //else { miRegimenTrabajador.FechaFin = dtpFechaFin.Value.ToShortDateString(); }
            //miRegimenTrabajador.RUC = txtRUC.Text;
            miRegimenTrabajador.IdtRegimenLaboral = 3;
            miRegimenTrabajador.IdtTipoTrabajador = 2;
            miRegimenTrabajador.IdtTipoContrato = 15;
            miRegimenTrabajador.IdtCategoriaOcupacional = 5;
            miRegimenTrabajador.IdtOcupacion = 1;
            //miRegimenTrabajador.IdtCargo = sidtcargo;
            //miRegimenTrabajador.IdtMeta = sidtmeta;
            miRegimenTrabajador.IdtPeriodoTrabajador = sidtperiodotrabajador;
            miRegimenTrabajador.CrearRegimenTrabajador(miRegimenTrabajador);

            bOk = true;
            if (bOk == true)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("No se puede registrar estos datos", "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.Text != "System.Data.DataRowView" && cboDepartamento.ValueMember != "")
            {
                miDepartamento.Codigo = Convert.ToInt32(cboDepartamento.SelectedValue);
                CargarProvincia();
            }
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.Text != "System.Data.DataRowView" && cboProvincia.ValueMember != "")
            {
                miProvincia.Codigo = Convert.ToInt32(cboProvincia.SelectedValue);
                CargarDistrito();
            }
        }

        private void cboDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDistrito.Text != "System.Data.DataRowView" && cboDistrito.ValueMember != "")
            {
                miDistrito.Codigo = Convert.ToInt32(cboDistrito.SelectedValue);
            }
        }

        private void cboAFP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAFP.Text != "System.Data.DataRowView" && cboAFP.ValueMember != "")
            {
                sidtafp = Convert.ToInt32(cboAFP.SelectedValue);
            }
        }

        private void CargarDepartamento()
        {
            cboDepartamento.DataSource = miDepartamento.ListaDepartamentos();
            cboDepartamento.DisplayMember = "descripcion";
            cboDepartamento.ValueMember = "idtdepartamento";
            cboDepartamento.SelectedIndex = -1;
        }

        private void CargarProvincia()
        {
            cboProvincia.DataSource = miProvincia.ListarProvincias(miDepartamento);
            cboProvincia.DisplayMember = "descripcion";
            cboProvincia.ValueMember = "idtprovincia";
            cboProvincia.SelectedIndex = -1;
        }

        private void CargarDistrito()
        {
            cboDistrito.DataSource = miDistrito.ListarDistritos(miProvincia);
            cboDistrito.DisplayMember = "descripcion";
            cboDistrito.ValueMember = "idtdistrito";
            cboDistrito.SelectedIndex = -1;
        }

        private void CargarAFP()
        {
            CapaDeNegocios.cListaAFP miAFP = new CapaDeNegocios.cListaAFP();
            cboAFP.DataSource = miAFP.ObtenerListaAFP();
            cboAFP.DisplayMember = "nombre";
            cboAFP.ValueMember = "idtafp";
            cboAFP.SelectedIndex = -1; 
        }
    }
}
