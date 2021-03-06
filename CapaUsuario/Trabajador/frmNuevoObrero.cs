﻿using System;
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
            if (txtDNI.Text == "" || txtNombre.Text == "" || txtApePaterno.Text == "" || txtApeMaterno.Text == "" || cboDepartamento.Text == "" || cboProvincia.Text == "" || cboDistrito.Text == "" || cboAFP.Text == "")
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
            miRegimenPensionarioTrabajador.FechaInicio = dtpFechaInicio.Value.ToShortDateString();
            miRegimenPensionarioTrabajador.CUSPP = txtCUSPP.Text;
            miRegimenPensionarioTrabajador.TipoComision = cboTipoComision.Text;
            miRegimenPensionarioTrabajador.IdtAFP = sidtafp;
            miRegimenSaludTrabajador.FechaInicio = dtpFechaInicio.Value.ToShortDateString();
            miRegimenTrabajador.FechaInicio = dtpFechaInicio.Value.ToShortDateString();

            if (modoEdicion == false || modoAltaTrabajador == true)
            {


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
                miRegimenTrabajador.NumeroDocumento = "";
                miRegimenTrabajador.Periodicidad = "MENSUAL";
                miRegimenTrabajador.TipoPago = "EFECTIVO";
                miRegimenTrabajador.MontoPago = 0;
                
                miRegimenTrabajador.FechaFin = "";
                miRegimenTrabajador.RUC = "";
                miRegimenTrabajador.IdtRegimenLaboral = 3;
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
    }
}
