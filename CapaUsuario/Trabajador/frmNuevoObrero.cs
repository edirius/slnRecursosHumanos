using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CapaDeNegocios.VerificadorDNI;

namespace CapaUsuario.Trabajador
{
    public partial class frmNuevoObrero : Form
    {
        bool Validado = false;
        int numeroIntentos = 0;

        int sidtmeta = 0;
        int sidtafp = 0;
        int sidttrabajador = 0;
        int sidtperiodotrabajador = 0;
        
        DataTable oDataTrabajador = new DataTable();
        DataTable oDataPeriodoTrabajador = new DataTable();

        public Boolean modoEdicion = false;

        public Boolean modoAltaTrabajador = false;

        CapaDeNegocios.cDepartamento miDepartamento = new CapaDeNegocios.cDepartamento();
        CapaDeNegocios.cProvincia miProvincia = new CapaDeNegocios.cProvincia();
        CapaDeNegocios.cDistrito miDistrito = new CapaDeNegocios.cDistrito();
        public CapaDeNegocios.cTrabajador miTrabajador = new CapaDeNegocios.cTrabajador();

        CapaDeNegocios.cTipoVia miTipoVia = new CapaDeNegocios.cTipoVia();
        CapaDeNegocios.cTipoZona miTipoZona = new CapaDeNegocios.cTipoZona();
        CapaDeNegocios.cNacionalidad miNacionalidad = new CapaDeNegocios.cNacionalidad();

        public CapaDeNegocios.DatosLaborales.cPeriodoTrabajador miPeriodoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
        public  CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador miRegimenPensionarioTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();
        public CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador miRegimenSaludTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador();
        public CapaDeNegocios.DatosLaborales.cRegimenTrabajador miRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();

        public DateTime fechaInicio;
        public DateTime fechaFin;

        public frmNuevoObrero()
        {
            InitializeComponent();
        }

        private void frmNuevoObrero_Load(object sender, EventArgs e)
        {
            oDataTrabajador = miTrabajador.ObtenerListaTrabajadores("Todos");
            CargarDepartamento();
            CargarAFP();
            LimitarMes();
            
            if (modoEdicion || modoAltaTrabajador)
            {
                CargarTrabajador();
            }
        }

        public void LimitarMes()
        {
            dtpFechaInicio.MinDate = fechaInicio;
            dtpFechaInicio.MaxDate = fechaFin;
            dtpFechaNacimiento.Value = DateTime.Now.AddYears(-1);
        }
        public void CargarTrabajador()
        {
            txtApeMaterno.Text = miTrabajador.ApellidoMaterno;
            txtApePaterno.Text = miTrabajador.ApellidoPaterno;
            txtNombre.Text = miTrabajador.Nombres;
            txtDNI.Text = miTrabajador.Dni;
            txtCelular.Text = miTrabajador.CelularPersonal;
            txtCorreoElectronico.Text = miTrabajador.CorreoElectronico;
            if (miTrabajador.Sexo == CapaDeNegocios.EnumSexo.Masculino)
            {
                rbtMasculino.Checked = true;
            }
            else
            {
                rbtFemenino.Checked = true;
            }

            dtpFechaNacimiento.Value = miTrabajador.FechaNacimiento;
            dtpFechaInicio.Value = Convert.ToDateTime(miPeriodoTrabajador.FechaInicio) ;
            txtDireccion.Text = miTrabajador.Direccion;
            cboDepartamento.SelectedValue = miTrabajador.MiDepartamento.Codigo;
            cboProvincia.SelectedValue = miTrabajador.MiProvincia.Codigo;
            cboDistrito.SelectedValue = miTrabajador.MiDistrito.Codigo;


            txtCUSPP.Text = miRegimenPensionarioTrabajador.CUSPP;
            cboTipoComision.Text = miRegimenPensionarioTrabajador.TipoComision;
            cboAFP.SelectedValue = miRegimenPensionarioTrabajador.IdtAFP;
            sidtafp = miRegimenPensionarioTrabajador.IdtAFP;
            sidtperiodotrabajador = miRegimenPensionarioTrabajador.IdtPeriodoTrabajador;
            

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtDNI.Text.Length != 8)
            {
                MessageBox.Show("El DNI no es correcto, no se puede Guardar al nuevo Trabajador", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!EsvalidoCorreoElectronico(txtCorreoElectronico.Text))
            {
                MessageBox.Show("El correo es invalido, debe contener @ y .com y sin Ñ ", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (txtDNI.Text == "" || txtNombre.Text == "" || txtApePaterno.Text == "" || txtApeMaterno.Text == "" || cboDepartamento.Text == "" || cboProvincia.Text == "" || cboDistrito.Text == "" || cboAFP.Text == "")
            {
                MessageBox.Show("Existen datos en Blanco, no se puede Guardar al nuevo Trabajador", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime edadTrabajador = new DateTime(1, 1, 1);
            edadTrabajador = edadTrabajador + (DateTime.Now.Date - dtpFechaNacimiento.Value.Date);
            if ((edadTrabajador.Year -1) < 18)
            {
                MessageBox.Show("La edad del trabajador es: " + (edadTrabajador.Year - 1).ToString() + " años.");
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
            miTrabajador.CorreoElectronico = txtCorreoElectronico.Text;

            miTrabajador.MiTipoVia = miTipoVia;
            miTrabajador.MiTipoVia.Codigo = 1;
            miTrabajador.MiTipoZOna = miTipoZona;
            miTrabajador.MiTipoZOna.Codigo = 1;
            miTrabajador.MiNacionalidad = miNacionalidad;
            miTrabajador.MiNacionalidad.Codigo = 1;
            miTrabajador.Essaludvida = false;
            miTrabajador.Scrt = true;

            miPeriodoTrabajador.FechaInicio = dtpFechaInicio.Value.ToShortDateString();
            miRegimenPensionarioTrabajador.FechaInicio = dtpFechaInicio.Value.ToShortDateString();
            miRegimenPensionarioTrabajador.CUSPP = txtCUSPP.Text;
            miRegimenPensionarioTrabajador.TipoComision = cboTipoComision.Text;
            miRegimenPensionarioTrabajador.IdtAFP = sidtafp;
            miRegimenSaludTrabajador.FechaInicio = dtpFechaInicio.Value.ToShortDateString();
            miRegimenTrabajador.FechaInicio = dtpFechaInicio.Value.ToShortDateString();
            miRegimenTrabajador.NumeroDocumento = txtCuentaBancaria.Text;
            if (modoEdicion == false || modoAltaTrabajador == true)
            {

                miTrabajador.NroRenta4ta = "1";
                if (modoAltaTrabajador == false)
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
               
                miPeriodoTrabajador.FechaFin = "";
                miPeriodoTrabajador.IdtMotivoFinPeriodo = 1;
                miPeriodoTrabajador.IdtTrabajador = sidttrabajador;
                miPeriodoTrabajador.CrearPeriodoTrabajador(miPeriodoTrabajador);
                oDataPeriodoTrabajador = miPeriodoTrabajador.ListarPeriodoTrabajador(sidttrabajador);
                sidtperiodotrabajador = Convert.ToInt32(oDataPeriodoTrabajador.Compute("MAX(idtperiodotrabajador)", ""));


                miRegimenPensionarioTrabajador.IdtRegimenPensionarioTrabajador = 0;
               
                miRegimenPensionarioTrabajador.FechaFin = "";
                
               
                miRegimenPensionarioTrabajador.IdtPeriodoTrabajador = sidtperiodotrabajador;
                miRegimenPensionarioTrabajador.CrearRegimenPensionarioTrabajador(miRegimenPensionarioTrabajador);

               
                miRegimenSaludTrabajador.IdtRegimenSaludTrabajador = 0;
                miRegimenSaludTrabajador.RegimenSalud = "ESSALUD REGULAR (Exclusivamente)";
               
                miRegimenSaludTrabajador.FechaFin = "";
                miRegimenSaludTrabajador.EntidadPrestadoraSalud = "";
                miRegimenSaludTrabajador.IdtPeriodoTrabajador = sidtperiodotrabajador;
                miRegimenSaludTrabajador.CrearRegimenSaludTrabajador(miRegimenSaludTrabajador);

                
                miRegimenTrabajador.IdtRegimenTrabajador = 0;
                miRegimenTrabajador.Condicion = "CONTRATADO";
                miRegimenTrabajador.ServidorConfianza = false;
               
                miRegimenTrabajador.Periodicidad = "MENSUAL";
                miRegimenTrabajador.TipoPago = "EFECTIVO";
                miRegimenTrabajador.MontoPago = 0;
                
                miRegimenTrabajador.FechaFin = "";
                miRegimenTrabajador.RUC = "";
                miRegimenTrabajador.IdtRegimenLaboral = 3;
                miRegimenTrabajador.IdtTipoTrabajador = 2;
                miRegimenTrabajador.IdtTipoContrato = 9;
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
            if (modoEdicion == true || modoAltaTrabajador)
            {
                if (txtDNI.Text.Length == 8)
                {
                    if (txtDNI.Text != miTrabajador.Dni)
                    {
                        foreach (DataRow row in oDataTrabajador.Select("dni = '" + txtDNI.Text + "'"))
                        {
                            MessageBox.Show("El DNI ingresado ya pertenece a otro Obrero:" + row[0].ToString() + " " + row[1].ToString() + " " + row[2].ToString() + " " + row[3].ToString() + " " + row[4].ToString(), "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtDNI.Text = miTrabajador.Dni;
                            return;
                        }
                    }
                    
                }
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

        private void cboAFP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAFP.Text != "System.Data.DataRowView" && cboAFP.ValueMember != "")
            {
                sidtafp = Convert.ToInt32(cboAFP.SelectedValue);
                if (cboAFP.Text == "SNP")
                {
                    cboTipoComision.SelectedIndex = -1;
                    txtCUSPP.Text = "";
                    cboTipoComision.Enabled = false;
                    txtCUSPP.Enabled = false;
                }
                else
                {
                    cboTipoComision.Enabled = true;
                    txtCUSPP.Enabled = true;
                }
            }
        }

        public void RecibirDatos(int pidtmeta)
        {
            sidtmeta = pidtmeta;
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void txtValidador_TextChanged(object sender, EventArgs e)
        {
            if (txtDNI.Text.Length == 8)
            {
                if (ValidateIdentificationDocumentPeru(txtDNI.Text + txtValidador.Text) == true)
                {
                    picValidado.Image = Properties.Resources.check;
                    Validado = true;
                    btnTraerNombre.Visible = true;
                }
                else
                {
                    picValidado.Image = Properties.Resources.equis;
                    Validado = false;
                    btnTraerNombre.Visible = false;
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

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private bool EsvalidoCorreoElectronico(string correo)
        {
            // Expresión regular para validar un correo electrónico.
            // Esta expresión permite letras, números, guiones, puntos y subrayados en el nombre de usuario y el dominio,
            // y admite dominios de segundo nivel de dos a seis letras (por ejemplo, .com, .net, .org, .edu, etc.).
            // También permite que el nombre de dominio tenga un subdominio opcional.
            string expresionRegular = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$";

            // Se crea una instancia de la clase Regex con la expresión regular.
            Regex regex = new Regex(expresionRegular);

            // Se devuelve si el correo electrónico coincide con la expresión regular.
            return regex.IsMatch(correo);
        }

        private void btnArroba_Click(object sender, EventArgs e)
        {
            txtCorreoElectronico.Text = txtCorreoElectronico.Text + "@";
        }

        private void btnTraerNombre_Click(object sender, EventArgs e)
        {
            try
            {
                cVerificadorDNI Verificador = new cVerificadorDNI();
                CapaDeNegocios.cDistrito oDistrito = new CapaDeNegocios.cDistrito();
                CapaDeNegocios.cProvincia oProvincia = new CapaDeNegocios.cProvincia();

                trabajadorValidado MiTrabajadorValidado;
                MiTrabajadorValidado = Verificador.TraerTrabajadorValidado(txtDNI.Text, cDatosGeneralesEmpresa.Bearer2);
                if (MiTrabajadorValidado != null)
                {
                    txtNombre.Text = MiTrabajadorValidado.Data.nombres;
                    txtApePaterno.Text = MiTrabajadorValidado.Data.apellido_paterno;
                    txtApeMaterno.Text = MiTrabajadorValidado.Data.apellido_materno;
                    txtDireccion.Text = MiTrabajadorValidado.Data.direccion;

                    switch (MiTrabajadorValidado.Data.sexo)
                    {
                        case "MASCULINO":
                            rbtMasculino.Checked = true; ;
                            break;
                        case "FEMENINO":
                            rbtFemenino.Checked = true;
                            break;
                        default:
                            break;
                    }

                    dtpFechaNacimiento.Value = ToDateTime(MiTrabajadorValidado.Data.fecha_nacimiento);
                    oDistrito = miDistrito.TraerDistritoxUbigeo(MiTrabajadorValidado.Data.ubigeo_reniec);
                    oProvincia = miProvincia.TraerProvincia(oDistrito.MiProvincia.Codigo);

                    cboDepartamento.SelectedValue = oProvincia.MiDepartamento.Codigo;
                    cboProvincia.SelectedValue = oProvincia.Codigo;
                    cboDistrito.SelectedValue = oDistrito.Codigo;
                }
                else
                {
                    MessageBox.Show("Error al traer los datos, ingrese los nombres manualmente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo traer el nombre de internet,  intenet de nuevo o ingrese los nombres manualmente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DateTime ToDateTime(String value)
        {
            if (value == null)
                return DateTime.Now.AddYears(-1);
            return DateTime.Parse(value);
        }
    }
}
