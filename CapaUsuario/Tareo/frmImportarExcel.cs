﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios.Tareos;
using CapaDeNegocios;
using CapaDeNegocios.VerificadorDNI;

namespace CapaUsuario.Tareo
{
    public partial class frmImportarExcel : Form
    {
        public cTrabajador oTrabajador = new cTrabajador();
        public CapaDeNegocios.Obras.cMeta oMeta;
        public CapaDeNegocios.Tareos.cTareo otareo;

        cImportarExcelTareo oImportadorExcelTareo = new cImportarExcelTareo();
        cArchivoExcel miArchivoExcel = new cArchivoExcel();
        cExcelHojaInformativa HojaInformativa = new cExcelHojaInformativa();

        cDistrito miDistrito = new cDistrito();

        CapaDeNegocios.Obras.cMetaJornal oMetaJornal = new CapaDeNegocios.Obras.cMetaJornal();

        public frmImportarExcel()
        {
            InitializeComponent();
        }

        private void frmImportarExcel_Load(object sender, EventArgs e)
        {
            cboTipoOrden.DataSource = Enum.GetValues(typeof(enumTipoNombres));
            cboTipoOrden.SelectedIndex = 0;
            dtpFechaInicio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        private void btnImportarExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog fichero = new OpenFileDialog();
            fichero.Filter = "Excel (*.xlsx)|*.xlsx| Excel (*.xls)|*.xls";
            fichero.FileName = "TAREO.xlsX";
        
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                
                miArchivoExcel.NombreHoja = txtHojaExcel.Text;
                miArchivoExcel.InicioFila = Convert.ToInt16(txtComienzoFila.Text);
                miArchivoExcel.FinFila = Convert.ToInt16(txtFinFila.Text);
                miArchivoExcel.ColumnaNombres = txtColumnaNombres.Text;
                miArchivoExcel.ColumnaApellidoPaterno = txtApellidoPaterno.Text;
                miArchivoExcel.ColumnaApellidoMaterno = txtApellidoMaterno.Text;
                miArchivoExcel.ColumnaDNI = txtColumnaDNI.Text;
                miArchivoExcel.ColumnaCargo = txtColumnaCategoria.Text;
                miArchivoExcel.ColumnaDias = txtColumnaDias.Text;
                miArchivoExcel.ColumnaCuentaBancaria = txtColumnaCuentaBancaria.Text;
                miArchivoExcel.TipoNombres = (enumTipoNombres) cboTipoOrden.SelectedValue;

                miArchivoExcel = oImportadorExcelTareo.Importar(fichero.FileName, miArchivoExcel);
                dtgDatos.DataSource = miArchivoExcel.Detalles;
            }

            List<string> ListaCategorias = new List<string>();

            foreach (cDetalleArchivoExcel item in miArchivoExcel.Detalles)
            {
                int codigoTrabajador = oTrabajador.BuscarTrabajadorXDNIFormaCorta(item.Dni);

                if (codigoTrabajador != 0)
                {
                    item.TrabajadorEncontrado = true;
                    item.CodigoTrabajador = codigoTrabajador;
                }
                else
                {
                    item.TrabajadorEncontrado = false;
                    item.CodigoTrabajador = 0;
                }

                ListaCategorias.Add(item.Cargo);

            
            }

            foreach (string item in ListaCategorias.Distinct().ToList())
            {
                if (oMetaJornal.TraerMetaJornalxCategoria(item, oMeta.Codigo) == null)
                {
                    MessageBox.Show("No existe la categoria: '" + item + "',  Ingrese la categoria antes de importar a la BD. ");
                }
                
            }

            foreach (DataGridViewRow row in dtgDatos.Rows)
            {
                Color color = Color.DarkOrange;

                if (!Convert.ToBoolean(row.Cells["colTrabajadorEncontrado"].Value))
                {
                    row.DefaultCellStyle.BackColor = color;
                } 
            }
        }



        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                int sidttrabajador;
                int sidtperiodotrabajador;

                DateTime dtpFechaInicio2 = dtpFechaInicio.Value;
                miDistrito = miDistrito.TraerDistrito(715);


                foreach (cDetalleArchivoExcel item in miArchivoExcel.Detalles)
                {

                    cTrabajador miTrabajador = new cTrabajador();
                    CapaDeNegocios.DatosLaborales.cPeriodoTrabajador miPeriodoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
                    CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador miRegimenPensionarioTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();
                    CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador miRegimenSaludTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador();
                    CapaDeNegocios.DatosLaborales.cRegimenTrabajador miRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();



                    if (item.CodigoTrabajador == 0)
                    {
                        if (item.TrabajadorValidado)
                        {
                            miTrabajador.Nombres = item.NombresValidado;
                            miTrabajador.ApellidoPaterno = item.ApellidoPaternoValidado;
                            miTrabajador.ApellidoMaterno = item.ApellidoMaternoValidado;
                            switch (item.Sexo)
                            {
                                case "Masculino":
                                    miTrabajador.Sexo = EnumSexo.Masculino;
                                    break;
                                case "Femenino":
                                    miTrabajador.Sexo = EnumSexo.Femenino;
                                    break;
                                default:
                                    break;
                            }
                            miTrabajador.FechaNacimiento = item.FechaNacimiento;
                            miTrabajador.Dni = item.Dni;
                            miTrabajador.CelularPersonal = "";
                            if (item.Direccion.Length > 49)
                            {
                                item.Direccion = item.Direccion.Substring(0, 48);
                            }
                            miTrabajador.Direccion = item.Direccion;
                            miTrabajador.MiDistrito = miDistrito;
                            miTrabajador.MiDistrito.Codigo = miDistrito.Codigo;

                            miTrabajador.CorreoElectronico = "";

                            miTrabajador.MiTipoVia = new cTipoVia();
                            miTrabajador.MiTipoVia.Codigo = 1;
                            miTrabajador.MiTipoZOna = new cTipoZona();
                            miTrabajador.MiTipoZOna.Codigo = 1;
                            miTrabajador.MiNacionalidad = new cNacionalidad();
                            miTrabajador.MiNacionalidad.Codigo = 1;
                            miTrabajador.Essaludvida = false;
                            miTrabajador.Scrt = true;
                            miTrabajador.NroRenta4ta = "1";
                            sidttrabajador = miTrabajador.AgregarTrabajadorConID(miTrabajador);
                            miTrabajador.IdTrabajador = sidttrabajador;

                           
                        }
                        else
                        {
                            MessageBox.Show("El trabajador: " + item.Dni + " " + item.Nombres + " " + item.Apellidopaterno + item.Apellidomaterno + " No esta validado, se utilizara los nombres del archivo excel, actualizar sus datos como fecha de nacimiento por el menu trabajadores", "Observacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            miTrabajador.Nombres = item.Nombres;
                            miTrabajador.ApellidoPaterno = item.Apellidopaterno;
                            miTrabajador.ApellidoMaterno = item.Apellidomaterno;
                            switch (item.Sexo)
                            {
                                case "Masculino":
                                    miTrabajador.Sexo = EnumSexo.Masculino;
                                    break;
                                case "Femenino":
                                    miTrabajador.Sexo = EnumSexo.Femenino;
                                    break;
                                default:
                                    break;
                            }
                            miTrabajador.FechaNacimiento = item.FechaNacimiento;
                            miTrabajador.Dni = item.Dni;
                            miTrabajador.CelularPersonal = "";
                            item.Direccion = "";
                            if (item.Direccion.Length > 49)
                            {
                                item.Direccion = item.Direccion.Substring(0, 48);
                            }
                            miTrabajador.Direccion = item.Direccion;
                            miTrabajador.MiDistrito = miDistrito;
                            miTrabajador.MiDistrito.Codigo = miDistrito.Codigo;

                            miTrabajador.CorreoElectronico = "";

                            miTrabajador.MiTipoVia = new cTipoVia();
                            miTrabajador.MiTipoVia.Codigo = 1;
                            miTrabajador.MiTipoZOna = new cTipoZona();
                            miTrabajador.MiTipoZOna.Codigo = 1;
                            miTrabajador.MiNacionalidad = new cNacionalidad();
                            miTrabajador.MiNacionalidad.Codigo = 1;
                            miTrabajador.Essaludvida = false;
                            miTrabajador.Scrt = true;
                            miTrabajador.NroRenta4ta = "1";
                            sidttrabajador = miTrabajador.AgregarTrabajadorConID(miTrabajador);
                            miTrabajador.IdTrabajador = sidttrabajador;

                        }

                        item.CodigoTrabajador = sidttrabajador;
                        miPeriodoTrabajador.FechaInicio = dtpFechaInicio2.ToShortDateString();
                        miRegimenPensionarioTrabajador.FechaInicio = dtpFechaInicio2.ToShortDateString();
                        miRegimenPensionarioTrabajador.CUSPP = "";
                        miRegimenPensionarioTrabajador.TipoComision = "";
                        miRegimenPensionarioTrabajador.IdtAFP = 5;
                        miRegimenSaludTrabajador.FechaInicio = dtpFechaInicio2.ToShortDateString();
                        miRegimenTrabajador.FechaInicio = dtpFechaInicio2.ToShortDateString();
                        miRegimenTrabajador.NumeroDocumento = "";

                        miRegimenTrabajador.Condicion = "CONTRATADO";
                        miRegimenTrabajador.ServidorConfianza = false;

                        miRegimenTrabajador.Periodicidad = "MENSUAL";
                        miRegimenTrabajador.TipoPago = "EFECTIVO";
                        miRegimenTrabajador.MontoPago = 0;
                        miRegimenTrabajador.NumeroDocumento = item.CuentaBancaria;

                        miRegimenTrabajador.FechaFin = "";
                        miRegimenTrabajador.RUC = "";
                        miRegimenTrabajador.IdtCategoriaOcupacional = 5;
                        miRegimenTrabajador.IdtOcupacion = 1;
                        miRegimenTrabajador.IdtCargo = 49;
                        miRegimenTrabajador.IdtMeta = oMeta.Codigo;

                        CapaDeNegocios.cDatosGenerales misDatosGenerales = new CapaDeNegocios.cDatosGenerales();

                        if (misDatosGenerales.Tecnicos276)
                        {
                            miRegimenTrabajador.IdtRegimenLaboral = 2;
                        }
                        else
                        {
                            miRegimenTrabajador.IdtRegimenLaboral = 3;
                        }


                        miRegimenTrabajador.IdtTipoTrabajador = 12;
                        miRegimenTrabajador.IdtTipoContrato = 15;


                        miPeriodoTrabajador.FechaFin = "";
                        miPeriodoTrabajador.IdtMotivoFinPeriodo = 1;
                        miPeriodoTrabajador.IdtTrabajador = item.CodigoTrabajador;
                        miPeriodoTrabajador.CrearPeriodoTrabajador(miPeriodoTrabajador);
                        DataTable oDataPeriodoTrabajador = miPeriodoTrabajador.ListarPeriodoTrabajador(item.CodigoTrabajador);
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


                        miRegimenTrabajador.IdtPeriodoTrabajador = sidtperiodotrabajador;
                        miRegimenTrabajador.CrearRegimenTrabajador(miRegimenTrabajador);
                    }
                    else
                    {
                        int periodoUltimo = 0;
                        periodoUltimo = miPeriodoTrabajador.traerUltimoPeriodoTrabajador(item.CodigoTrabajador).IdtPeriodoTrabajador;

                        miRegimenTrabajador = miRegimenTrabajador.TraerUltimoRegimenTrabajadorInclusoTerminado(periodoUltimo);
                        miRegimenTrabajador.NumeroDocumento = item.CuentaBancaria;
                        miRegimenTrabajador.ModificarRegimenTrabajador(miRegimenTrabajador);
                    }


                    //PARTE TAREO

                    CapaDeNegocios.Tareos.cDetalleTareo oDetalle = new cDetalleTareo();

                    oDetalle.IdtTrabajador = item.CodigoTrabajador;
                    oDetalle.IdtTareo = otareo.IdTTareo;
                    oDetalle.Categoria = item.Cargo.Trim();
                    oDetalle.TotalDias = item.Dias;
                    oDetalle.DiasTareo = Diastareo(item.Dias);

                    oDetalle.CrearDetalleTareo(oDetalle);
                }
                MessageBox.Show("Datos Importados", "Importacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al importar bd: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

            
        }

        public string Diastareo(int dias)
        {
            string detalledias = "";
            for (int i = 0; i < 31; i++)
            {
                if (i < dias)
                {
                    detalledias = detalledias + "X";
                }
                else
                {
                    detalledias = detalledias + "0";
                }
            }
            return detalledias;
            
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            try
            {
                btnValidar.Text = "Volver a Validar";
                cVerificadorDNI Verificador = new cVerificadorDNI();
                CapaDeNegocios.cDistrito oDistrito = new CapaDeNegocios.cDistrito();
                CapaDeNegocios.cProvincia oProvincia = new CapaDeNegocios.cProvincia();
                CapaDeNegocios.cDepartamento oDepartamento = new cDepartamento();
                dtgDatos.Columns["colNombreValidado"].Visible = true;
                dtgDatos.Columns["colApellidoValidado"].Visible = true;
                dtgDatos.Columns["colApellidoMaternoValidado"].Visible = true;
                foreach (cDetalleArchivoExcel item in miArchivoExcel.Detalles)
                {
                    //Si no esta validado todavia
                    if (!item.TrabajadorValidado)
                    {
                        trabajadorValidado MiTrabajadorValidado;
                        MiTrabajadorValidado = Verificador.TraerTrabajadorValidado(item.Dni, cDatosGeneralesEmpresa.Bearer2);
                        if (MiTrabajadorValidado != null)
                        {
                            item.NombresValidado = MiTrabajadorValidado.Data.nombres;
                            item.ApellidoPaternoValidado = MiTrabajadorValidado.Data.apellido_paterno;
                            item.ApellidoMaternoValidado = MiTrabajadorValidado.Data.apellido_materno;
                            item.Direccion = MiTrabajadorValidado.Data.direccion;
                            switch (MiTrabajadorValidado.Data.estado_civil)
                            {
                                case "SOLTERO":
                                    item.EstadoCivil = "Soltero";
                                    break;
                                case "CASADO":
                                    item.EstadoCivil = "Casado";
                                    break;
                                case "VIUDO":
                                    item.EstadoCivil = "Viudo";
                                    break;
                                case "DIVORCIADO":
                                    item.EstadoCivil = "Divorciado";
                                    break;
                                default:
                                    break;
                            }
                            switch (MiTrabajadorValidado.Data.sexo)
                            {
                                case "MASCULINO":
                                    item.Sexo = "Masculino";
                                    break;
                                case "FEMENINO":
                                    item.Sexo = "Femenino";
                                    break;
                                default:
                                    break;
                            }

                            item.FechaNacimiento = ToDateTime(MiTrabajadorValidado.Data.fecha_nacimiento);
                            oDistrito = oDistrito.TraerDistritoxUbigeo(MiTrabajadorValidado.Data.ubigeo_sunat);
                            oProvincia = oProvincia.TraerProvincia(oDistrito.MiProvincia.Codigo);
                            oDepartamento = oDepartamento.TraerDepartamento(oProvincia.MiDepartamento.Codigo);


                            item.Observaciones = validarFilaExcel(item);
                            item.TrabajadorValidado = true;
                            //txtDepartamento.Text = oDepartamento.Descripcion;
                            //txtProvincia.Text = oProvincia.Descripcion;
                            //txtDistrito.Text = oDistrito.Descripcion;
                        }
                        else
                        {
                            MessageBox.Show("Error al traer los datos, ingrese los nombres manualmente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                }
                MessageBox.Show("Datos validados.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo traer el nombre de internet: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DateTime ToDateTime(String value)
        {
            if (value == null)
                return DateTime.Now.AddYears(-1);
            return DateTime.Parse(value);
        }

        private string validarFilaExcel(cDetalleArchivoExcel det)
        {
            string observaciones = "";
            bool ValidadoNombres = string.Equals(det.Nombres.Trim(), det.NombresValidado, StringComparison.CurrentCultureIgnoreCase);
            bool ValidadoApellidoP = string.Equals(det.Apellidopaterno.Trim(), det.ApellidoPaternoValidado, StringComparison.CurrentCultureIgnoreCase);
            bool ValidadoApellidoM = string.Equals(det.Apellidomaterno.Trim(), det.ApellidoMaternoValidado, StringComparison.CurrentCultureIgnoreCase);
            if (!ValidadoNombres)
            {
                observaciones += "- Nombres no son iguales";
            }
            if (!ValidadoApellidoP)
            {
                observaciones += "- Apellido Paterno no son iguales";
            }
            if (!ValidadoApellidoM)
            {
                observaciones += "- Apellido Materno no son iguales";
            }

            return observaciones;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnImportarHojaInformativa_Click(object sender, EventArgs e)
        {
            

            OpenFileDialog fichero = new OpenFileDialog();
            fichero.Filter = "Excel (*.xlsx)|*.xlsx| Excel (*.xls)|*.xls";
            fichero.FileName = "FICHA_INFORMATIVA.xlsX";

            if (fichero.ShowDialog() == DialogResult.OK)
            {

               
                HojaInformativa = oImportadorExcelTareo.ImportarHojaInformativa(fichero.FileName, HojaInformativa);

                oImportadorExcelTareo.PonerNumerosCuentaBancaria(miArchivoExcel, HojaInformativa);

                dtgDatos.DataSource = miArchivoExcel.Detalles;
            }
        }

        private void btnFormatoHojaInformativa_Click(object sender, EventArgs e)
        {
            try
            {
                frmDatosHojaInformativa fDatosHojaInformativa = new frmDatosHojaInformativa();
                fDatosHojaInformativa.HojaInformativa = HojaInformativa;
                if (fDatosHojaInformativa.ShowDialog() == DialogResult.OK)
                {
                    HojaInformativa.ColumnaCuentaBancaria = fDatosHojaInformativa.HojaInformativa.ColumnaCuentaBancaria;
                    HojaInformativa.ColumnaDNI = fDatosHojaInformativa.HojaInformativa.ColumnaDNI;
                    HojaInformativa.InicioFila = fDatosHojaInformativa.HojaInformativa.InicioFila;
                    HojaInformativa.FinFila = fDatosHojaInformativa.HojaInformativa.FinFila;
                    HojaInformativa.NombreHoja = fDatosHojaInformativa.HojaInformativa.NombreHoja;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en dar formato a la Hoja Informativa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
