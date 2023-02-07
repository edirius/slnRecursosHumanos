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
    public partial class frmNuevoObreroRacionamiento : Form
    {
        bool Validado = false;
        int numeroIntentos = 0;

        int sidtmeta = 0;
        int sidtafp = 0;
        int sidttrabajador = 0;
        int sidtperiodotrabajador = 0;
        DataTable oDataTrabajador = new DataTable();
        DataTable oDataPeriodoTrabajador = new DataTable();

        CapaDeNegocios.cDepartamento miDepartamento = new CapaDeNegocios.cDepartamento();
        CapaDeNegocios.cProvincia miProvincia = new CapaDeNegocios.cProvincia();
        CapaDeNegocios.cDistrito miDistrito = new CapaDeNegocios.cDistrito();
        public CapaDeNegocios.cTrabajador miTrabajador = new CapaDeNegocios.cTrabajador();

        public bool modoEdicion = false;

        public bool modoAltatrabajador = false;
        CapaDeNegocios.cTipoVia miTipoVia = new CapaDeNegocios.cTipoVia();
        CapaDeNegocios.cTipoZona miTipoZona = new CapaDeNegocios.cTipoZona();
        CapaDeNegocios.cNacionalidad miNacionalidad = new CapaDeNegocios.cNacionalidad();

        public CapaDeNegocios.DatosLaborales.cPeriodoTrabajador miPeriodoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
        public DateTime fechaInicio;
        public DateTime fechaFin;

        public frmNuevoObreroRacionamiento()
        {
            InitializeComponent();
        }

        private void frmNuevoObreroRacionamiento_Load(object sender, EventArgs e)
        {
            oDataTrabajador = miTrabajador.ObtenerListaTrabajadores("Todos");
            CargarDepartamento();
            if (modoEdicion)
            {
                CargarTrabajador();
            }
            LimitarMes();
        }

        public void LimitarMes()
        {
            dtpFechaInicio.MinDate = fechaInicio;
            dtpFechaInicio.MaxDate = fechaFin;
        }

        public void CargarTrabajador()
        {
            txtApeMaterno.Text = miTrabajador.ApellidoMaterno;
            txtApePaterno.Text = miTrabajador.ApellidoPaterno;
            txtNombre.Text = miTrabajador.Nombres;
            txtDNI.Text = miTrabajador.Dni;
            txtCelular.Text = miTrabajador.CelularPersonal;
            if (miTrabajador.Sexo == CapaDeNegocios.EnumSexo.Masculino)
            {
                rbtMasculino.Checked = true;
            }
            else
            {
                rbtFemenino.Checked = true;
            }

            dtpFechaNacimiento.Value = miTrabajador.FechaNacimiento;
           
            dtpFechaInicio.Value = Convert.ToDateTime(miPeriodoTrabajador.FechaInicio);
            txtDireccion.Text = miTrabajador.Direccion;
            cboDepartamento.SelectedValue = miTrabajador.MiDepartamento.Codigo;
            cboProvincia.SelectedValue = miTrabajador.MiProvincia.Codigo;
            cboDistrito.SelectedValue = miTrabajador.MiDistrito.Codigo;


         


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

        public void RecibirDatos(int pidtmeta)
        {
            sidtmeta = pidtmeta;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtDNI.Text.Length != 8)
            {
                MessageBox.Show("El DNI no es correcto, no se puede Guardar al nuevo Trabajador", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (modoEdicion == false)
            {
                if (Validado == false)
                {
                    if (numeroIntentos < 3)
                    {
                        txtValidador.Focus();
                        numeroIntentos++;
                        MessageBox.Show("Ingrese el digito validador correcto para poder guardar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Usted no ha validado el DNI con el digito validador 3 veces, verifique bien el DNI porque puede traer datos incorrectos al consultar AFP y demas procesos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }

            }
            if (txtDNI.Text == "" || txtNombre.Text == "" || txtApePaterno.Text == "" || txtApeMaterno.Text == "" || cboDepartamento.Text == "" || cboProvincia.Text == "" || cboDistrito.Text == "" )
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
            miTrabajador.Essaludvida = false;
            miTrabajador.Scrt = true;
            miPeriodoTrabajador.FechaInicio = dtpFechaInicio.Value.ToShortDateString();
            if (modoEdicion == false || modoAltatrabajador == true)
            {

                if (modoAltatrabajador == false)
                {
                    sidttrabajador = miTrabajador.AgregarTrabajadorConID(miTrabajador);
                }
                else
                {
                    sidttrabajador = miTrabajador.IdTrabajador;
                }
                //oDataTrabajador = miTrabajador.ObtenerListaTrabajadores("Sin Periodo Laboral", "", "", "", "", "Todos", "Todos");
                //sidttrabajador = Convert.ToInt32(oDataTrabajador.Compute("MAX(id_trabajador)", ""));


                miPeriodoTrabajador.IdtPeriodoTrabajador = sidtperiodotrabajador;
                miPeriodoTrabajador.FechaInicio = dtpFechaInicio.Value.ToShortDateString();
                miPeriodoTrabajador.FechaFin = "";
                miPeriodoTrabajador.IdtMotivoFinPeriodo = 1;
                miPeriodoTrabajador.IdtTrabajador = sidttrabajador;
                miPeriodoTrabajador.CrearPeriodoTrabajador(miPeriodoTrabajador);
                oDataPeriodoTrabajador = miPeriodoTrabajador.ListarPeriodoTrabajador(sidttrabajador);
                sidtperiodotrabajador = Convert.ToInt32(oDataPeriodoTrabajador.Compute("MAX(idtperiodotrabajador)", ""));



                CapaDeNegocios.DatosLaborales.cRegimenTrabajador miRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
                miRegimenTrabajador.IdtRegimenTrabajador = 0;
                miRegimenTrabajador.Condicion = "CONTRATADO";
                miRegimenTrabajador.ServidorConfianza = false;
                miRegimenTrabajador.NumeroDocumento = "";
                miRegimenTrabajador.Periodicidad = "MENSUAL";
                miRegimenTrabajador.TipoPago = "EFECTIVO";
                miRegimenTrabajador.MontoPago = 0;
                miRegimenTrabajador.FechaInicio = dtpFechaInicio.Value.ToShortDateString();
                miRegimenTrabajador.FechaFin = "";
                miRegimenTrabajador.RUC = "";
                miRegimenTrabajador.IdtRegimenLaboral = 5;
                miRegimenTrabajador.IdtTipoTrabajador = 2;
                miRegimenTrabajador.IdtTipoContrato = 15;
                miRegimenTrabajador.IdtCategoriaOcupacional = 5;
                miRegimenTrabajador.IdtOcupacion = 1;
                miRegimenTrabajador.IdtCargo = 49;
                miRegimenTrabajador.IdtMeta = sidtmeta;
                miRegimenTrabajador.IdtPeriodoTrabajador = sidtperiodotrabajador;
                miRegimenTrabajador.CrearRegimenTrabajador(miRegimenTrabajador);

                bOk = true;
            }
            else
            {
                bOk = true;
            }
            if (bOk == true)
            {
                MessageBox.Show("Datos Guardados", "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            if (modoEdicion || modoAltatrabajador)
            {

            }
            else
            {
                if (txtDNI.Text.Length == 8)
                {
                    foreach (DataRow row in oDataTrabajador.Select("dni = '" + txtDNI.Text + "'"))
                    {
                        MessageBox.Show("El DNI ingresado ya pertenece a otro Obrero.", "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDNI.Text = "";
                        return;
                    }
                }
            }
            
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

        private void txtValidador_TextChanged(object sender, EventArgs e)
        {
            if (txtDNI.Text.Length == 8)
            {
                if (ValidateIdentificationDocumentPeru(txtDNI.Text + txtValidador.Text) == true)
                {
                    picValidado.Image = Properties.Resources.check;
                    Validado = true;
                }
                else
                {
                    picValidado.Image = Properties.Resources.equis;
                    Validado = false;
                }
            }
        }

        public bool ValidateIdentificationDocumentPeru(string identificationDocument)
        {
            if (!string.IsNullOrEmpty(identificationDocument))
            {
                int addition = 0;
                int[] hash = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                int identificationDocumentLength = identificationDocument.Length;

                string identificationComponent = identificationDocument.Substring(0, identificationDocumentLength - 1);

                int identificationComponentLength = identificationComponent.Length;

                int diff = hash.Length - identificationComponentLength;

                for (int i = identificationComponentLength - 1; i >= 0; i--)
                {
                    addition += (identificationComponent[i] - '0') * hash[i + diff];
                }

                addition = 11 - (addition % 11);

                if (addition == 11)
                {
                    addition = 0;
                }

                char last = char.ToUpperInvariant(identificationDocument[identificationDocumentLength - 1]);

                if (identificationDocumentLength == 11)
                {
                    // The identification document corresponds to a RUC.
                    return addition.Equals(last - '0');
                }
                else if (char.IsDigit(last))
                {
                    // The identification document corresponds to a DNI with a number as verification digit.
                    char[] hashNumbers = { '6', '7', '8', '9', '0', '1', '1', '2', '3', '4', '5' };
                    return last.Equals(hashNumbers[addition]);
                }
                else if (char.IsLetter(last))
                {
                    // The identification document corresponds to a DNI with a letter as verification digit.
                    char[] hashLetters = { 'K', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
                    return last.Equals(hashLetters[addition]);
                }
            }

            return false;
        }
    }
}
