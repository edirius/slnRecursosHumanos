using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios;
using CapaDeNegocios.Contrato;
using CapaDeNegocios.Obras;
using CapaDeNegocios.Trabajadores;
using CapaDeNegocios.DatosLaborales;

namespace CapaUsuario.Trabajador
{
    public partial class frmNuevoTrabajador : Form
    {
        int numeroIntentos = 0;

        bool Validado = false;
        ImageConverter imageConverter = new ImageConverter();

        public cTrabajador miTrabajador;
        //public cPeriodo miPeriodo ;
        public Boolean modoEdicion;
        public frmNuevoTrabajador()
        {
            InitializeComponent();
        }

        private void frmNuevoTrabajador_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        #region CodigoTrabajador
        private void Iniciar()
        {
            //miPeriodo = new cPeriodo(miTrabajador);
            txtCodigo.Text = miTrabajador.IdTrabajador.ToString();
            txtDNI.Text = miTrabajador.Dni;
            txtNombres.Text = miTrabajador.Nombres;
            txtApellidoPaterno.Text = miTrabajador.ApellidoPaterno;
            txtApellidoMaterno.Text = miTrabajador.ApellidoMaterno;
            cboEstadoCivil.Text = miTrabajador.EstadoCivil.ToString();
            cboSexo.Text = miTrabajador.Sexo.ToString();
            txtDireccion.Text = miTrabajador.Direccion;
            txtCelularTrabajo.Text = miTrabajador.CelularTrabajo;
            txtCelularPersonal.Text = miTrabajador.CelularPersonal;
            dtpFechaNacimiento.Value = miTrabajador.FechaNacimiento;
            txtCorreo.Text = miTrabajador.CorreoElectronico;
            txtNombreVia.Text  = miTrabajador.NombreVia;
            txtNumeroVia.Text = miTrabajador.NumeroVia;
            txtDepartamentoInterior.Text = miTrabajador.DepartamentoInterior;
            txtNombreZona.Text = miTrabajador.NombreZona;
            txtReferencia.Text = miTrabajador.Referencia;
            txtDepartamento.Text = miTrabajador.MiDepartamento.Descripcion;
            txtProvincia.Text = miTrabajador.MiProvincia.Descripcion;
            txtDistrito.Text = miTrabajador.MiDistrito.Descripcion;
            txtTipoVia.Text = miTrabajador.MiTipoVia.Descripcion;
            txtTipoZona.Text = miTrabajador.MiTipoZOna.Descripcion;
            txtNacionalidad.Text = miTrabajador.MiNacionalidad.Descripcion;
            if (miTrabajador.Foto != null )
            {
                pbFoto.Image = ConvertImage.ByteArrayToImage(miTrabajador.Foto);
            }
            chkEssaludVida.Checked = miTrabajador.Essaludvida;
            chkRenta4ta.Checked = miTrabajador.Suspencionrenta4ta;
            chkScrt.Checked = miTrabajador.Scrt;
            txtNroRenta4ta.Text = miTrabajador.NroRenta4ta;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNacionalidad.Text == "")
                {
                    txtNacionalidad.Focus();
                    throw new cReglaNegociosException("Seleccione una nacionalidad.");
                }

                if (txtDepartamento.Text == "")
                {
                    txtDepartamento.Focus();
                    throw new cReglaNegociosException("Seleccione un departamento.");
                }

                if (txtProvincia.Text == "")
                {
                    txtProvincia.Focus();
                    throw new cReglaNegociosException("Seleccione una provincia.");
                }

                if (txtDistrito.Text == "")
                {
                    txtDistrito.Focus();
                    throw new cReglaNegociosException("Seleccione un distrito.");
                }

                if (txtTipoVia.Text == "")
                {
                    txtTipoVia.Focus();
                    throw new cReglaNegociosException("Seleccione un tipovia.");
                }

                if (txtTipoZona.Text == "")
                {
                    txtTipoZona.Focus();
                    throw new cReglaNegociosException("Seleccione un tipo de zona.");
                }

                if (modoEdicion == false)
                {
                    if (Validado== false)
                    {
                        if (numeroIntentos < 3)
                        {
                            txtValidador.Focus();
                            numeroIntentos++;
                            throw new cReglaNegociosException("Ingrese el digito validador");

                        }
                        else
                        {
                            MessageBox.Show("Usted no ha validado el DNI con el digito validador, verifique bien el DNI porque puede traer datos incorrectos al consultar AFP y demas procesos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }

                }

                miTrabajador.IdTrabajador = Convert.ToInt16(txtCodigo.Text);
                miTrabajador.Dni = txtDNI.Text;
                miTrabajador.Nombres = txtNombres.Text;
                miTrabajador.ApellidoPaterno = txtApellidoPaterno.Text;
                miTrabajador.ApellidoMaterno = txtApellidoMaterno.Text;
                switch (cboEstadoCivil.Text)
                {
                    case "Casado":
                        miTrabajador.EstadoCivil = enumEstadoCivil.Casado;
                        break;
                    case "Soltero":
                        miTrabajador.EstadoCivil = enumEstadoCivil.Soltero;
                        break;
                    case "Viudo":
                        miTrabajador.EstadoCivil = enumEstadoCivil.Viudo;
                        break;
                    case "Divorciado":
                        miTrabajador.EstadoCivil = enumEstadoCivil.Divorciado;
                        break;
                    default:
                        break;
                }

                switch (cboSexo.Text)
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
                miTrabajador.Direccion = txtDireccion.Text;
                miTrabajador.CelularTrabajo = txtCelularTrabajo.Text;
                miTrabajador.CelularPersonal = txtCelularPersonal.Text;
                miTrabajador.FechaNacimiento = dtpFechaNacimiento.Value;
                miTrabajador.CorreoElectronico = txtCorreo.Text;
                miTrabajador.NombreVia = txtNombreVia.Text;
                miTrabajador.NumeroVia = txtNumeroVia.Text;
                miTrabajador.DepartamentoInterior = txtDepartamentoInterior.Text;
                miTrabajador.NombreZona = txtNombreZona.Text;
                miTrabajador.Referencia = txtReferencia.Text;

                if (pbFoto.Image != null)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    // Se guarda la imagen en el buffer
                    pbFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    // Se extraen los bytes del buffer para asignarlos como valor para el 
                    // parámetro.
                    miTrabajador.Foto = ms.GetBuffer();
                }
                else
                {
                    miTrabajador.Foto = null;
                }

                miTrabajador.Essaludvida = chkEssaludVida.Checked;
                miTrabajador.Suspencionrenta4ta = chkRenta4ta.Checked;
                miTrabajador.NroRenta4ta = txtNroRenta4ta.Text;
                miTrabajador.Scrt = chkScrt.Checked;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Ingresar el Nuevo Trabajador: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txtNacionalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtNacionalidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode  == Keys.F2)
            {
                frmNacionalidad fNacionalidad = new frmNacionalidad();
                if (fNacionalidad.ShowDialog() == System.Windows.Forms.DialogResult.OK  )
                {
                    miTrabajador.MiNacionalidad = fNacionalidad.miNacionalidad;
                    txtNacionalidad.Text = miTrabajador.MiNacionalidad.Descripcion; 
                }
            }
            else
            {
                if (txtNacionalidad.Text == "")
                {
                    MessageBox.Show("Debe seleccionar la nacionalidad.");
                }
                else
                {
                    txtDepartamento.Focus();
                }
            }
        }

        private void txtNacionalidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTipoVia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmTipoVia fTipoVia = new frmTipoVia();
                if (fTipoVia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miTrabajador.MiTipoVia = fTipoVia.miTipoVia;
                    txtTipoVia.Text = miTrabajador.MiTipoVia.Descripcion;
                }
            }
            else
            {
                if (txtTipoVia.Text == "")
                {
                    MessageBox.Show("Debe seleccionar el Tipo de Via.");
                }
                else
                {
                    txtNombreVia.Focus();
                }
            }
        }

        private void txtTipoVia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTipoZona_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTipoZona_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmTipoZona fTipoZona = new frmTipoZona();
                if (fTipoZona.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miTrabajador.MiTipoZOna = fTipoZona.miTipoZona;
                    txtTipoZona.Text = miTrabajador.MiTipoZOna.Descripcion;
                }
            }
            else
            {
                if (txtTipoZona.Text == "")
                {
                    MessageBox.Show("Seleccione el tipo de zona (F2).");
                }
                else
                {
                    txtNombreZona.Focus();
                }
            }
        }

        private void txtDepartamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmDepartamento fDepartamento = new frmDepartamento();
                if (fDepartamento.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miTrabajador.MiDepartamento = fDepartamento.miDepartamento;
                    txtDepartamento.Text = miTrabajador.MiDepartamento.Descripcion;
                }
            }
            else
            {
                if (txtDepartamento.Text == "")
                {
                    MessageBox.Show("Debe seleccionar el departamento.");
                }
                else
                {
                    txtProvincia.Focus();
                }
            }
        }

        private void txtDepartamento_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProvincia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 )
            {
                if (txtDepartamento.Text.Length > 0)
                {
                    frmProvincia fProvincia = new frmProvincia();
                    fProvincia.miProvincia = new cProvincia();
                    fProvincia.miProvincia.MiDepartamento = miTrabajador.MiDepartamento;
                    if (fProvincia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        miTrabajador.MiProvincia = fProvincia.miProvincia;
                        txtProvincia.Text = miTrabajador.MiProvincia.Descripcion;
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione primero el departamento");
                }
            }
            else
            {
                if (txtProvincia.Text == "")
                {
                    MessageBox.Show("Debe seleccionar la provincia (F2).");
                }
                else
                {
                    txtDistrito.Focus();
                }
            }
        }

        private void txtDistrito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (txtProvincia.Text.Length > 0)
                {
                    frmListaDistritos fListaDistritos = new frmListaDistritos();
                    fListaDistritos.miDistrito = new cDistrito();
                    fListaDistritos.miDistrito.MiProvincia = miTrabajador.MiProvincia;
                    if (fListaDistritos.ShowDialog()  == System.Windows.Forms.DialogResult.OK )
                    {
                        miTrabajador.MiDistrito = fListaDistritos.miDistrito;
                        txtDistrito.Text = miTrabajador.MiDistrito.Descripcion;
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione primero la provincia");
                }
            }
            else
            {
                if (txtDistrito.Text == "")
                {
                    MessageBox.Show("Debe seleccionar el distrito (F2).");
                }
                else
                {
                    txtTipoVia.Focus();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void lblCargarFoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ofdAbrirImagen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string lstrFile = ofdAbrirImagen.FileName;
                Bitmap myBitmap = new Bitmap(lstrFile);
                pbFoto.Image = myBitmap;
                pbFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void lblBorrarFoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbFoto.Image = null;
        }

        private void btnNuevoPeriodo_Click(object sender, EventArgs e)
        {
          
        }

        private void btnModificarPeriodo_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region CodigoContrato
        cContrato miContrato = new cContrato();
        Boolean ingresoPrimeraVez { get; set; }
        cCadenaProgramaticaFuncional miCadenaProgramaticaFuncional = new cCadenaProgramaticaFuncional();
       
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ////try
            ////{
            //    miContrato.MiTrabajador = miTrabajador;
            //    miContrato.MiMeta = new cMeta();
            //    miContrato.MiMeta.Codigo = Convert.ToInt16(cboMeta.SelectedValue);
            //    miContrato.MiTipoTrabajador = new cTipoTrabajador();
            //    miContrato.MiTipoTrabajador.Codigo = Convert.ToInt16(cboTipoTrabajador.SelectedValue);
            //    miContrato.NumeroContrato = Convert.ToInt16(txtNumeroContrato.Text);

            //    miContrato.FechaInicio = dtpInicioContrato.Value;
            //    miContrato.FechaFinal = dtpFinContrato.Value;

            //    miContrato.AgregarContrato(miContrato);
            //    dtgContratos.DataSource = miContrato.ListaContrato(miTrabajador);
            ////}
            ////catch (Exception ex)
            ////{
            ////    MessageBox.Show(ex.Message);
               
            ////}
            
        }
        private void tabDatosContrato_Enter(object sender, EventArgs e)
        {
            IniciarDatosContrato();
        }

        private void IniciarDatosContrato()
        {
            //if (ingresoPrimeraVez == false)
            //{

            //    miContrato.MiTipoTrabajador = new cTipoTrabajador();
            //    CapaDeNegocios.Contrato.cCargo miCargo = new cCargo();
            //    miContrato.TipoContrato = new cTipoContrato();

            //    cboTipoTrabajador.DisplayMember = "Descripcion";
            //    cboTipoTrabajador.ValueMember = "idtsunattipotrabajador";
            //    cboTipoTrabajador.DataSource = miContrato.MiTipoTrabajador.ListarTiposDeTrabajadores();

            //    cboTipoContrato.DisplayMember = "Descripcion";
            //    cboTipoContrato.ValueMember = "idttipoContrato";
            //    cboTipoContrato.DataSource = miContrato.TipoContrato.ListaTipoContratos();

            //    cboMeta.DisplayMember = "Nombre";
            //    cboMeta.ValueMember = "idtMeta";
            //    cboMeta.DataSource = miCadenaProgramaticaFuncional.ListarMetas();

            //    dtgContratos.DataSource = miContrato.ListaContrato(miTrabajador);
            //    ingresoPrimeraVez = true;

            //    cboListaCargos.DisplayMember = "descripcion";
            //    cboListaCargos.ValueMember = "idtCargo";
            //    cboListaCargos.DataSource = miCargo.ListaCargos();

            //    cPeriodoTipoTrabajador miTipoTrabajador = new cPeriodoTipoTrabajador(miTrabajador);
            //    dtgTipoTrabajador.DataSource = miTipoTrabajador.ListarPeriodoTipoTrabajador();
            //}
        }
        #endregion

        private void btnNuevoTipoTrabajador_Click(object sender, EventArgs e)
        {
            frmNuevoTipoTrabajador fNuevoTipoTrabajador = new frmNuevoTipoTrabajador();
            fNuevoTipoTrabajador.miPeriodoTipoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTipoTrabajador(miTrabajador);
            fNuevoTipoTrabajador.miPeriodoTipoTrabajador.FechaInicio = DateTime.Now;
            fNuevoTipoTrabajador.miPeriodoTipoTrabajador.FechaFinal.FechaFin = DateTime.Now;
            fNuevoTipoTrabajador.miPeriodoTipoTrabajador.FechaFinal.TieneFin = false;
            
            if (fNuevoTipoTrabajador.ShowDialog() == DialogResult.OK)
            {
                fNuevoTipoTrabajador.miPeriodoTipoTrabajador.AgregarPeriodoTipoTrabajador(fNuevoTipoTrabajador.miPeriodoTipoTrabajador);
            }
        }

        private void btnModificarTipoTrabajador_Click(object sender, EventArgs e)
        {
            //frmNuevoTipoTrabajador fModificarTrabajador = new frmNuevoTipoTrabajador();
            //fModificarTrabajador.miPeriodoTipoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTipoTrabajador(miTrabajador);
            //if (dtgTipoTrabajador.SelectedRows.Count > 0)
            //{
            //    fModificarTrabajador.miPeriodoTipoTrabajador.Codigo = Convert.ToInt16(dtgTipoTrabajador.SelectedRows[0].Cells[0].Value);
            //    fModificarTrabajador.miPeriodoTipoTrabajador.FechaInicio = Convert.ToDateTime(dtgTipoTrabajador.SelectedRows[0].Cells[2].Value);

            //    if (dtgTipoTrabajador.SelectedRows[0].Cells[3].Value != Convert.DBNull)
            //    {
            //        fModificarTrabajador.miPeriodoTipoTrabajador.FechaFinal.TieneFin = true;
            //        fModificarTrabajador.miPeriodoTipoTrabajador.FechaFinal.FechaFin = Convert.ToDateTime(dtgTipoTrabajador.SelectedRows[0].Cells[3].Value);
            //        fModificarTrabajador.miPeriodoTipoTrabajador.TipoTrabajador.Codigo = Convert.ToInt16(dtgTipoTrabajador.SelectedRows[0].Cells[4].Value);
            //        fModificarTrabajador.miPeriodoTipoTrabajador.TipoTrabajador.Descripcion = Convert.ToString(dtgTipoTrabajador.SelectedRows[0].Cells[6].Value);
            //    }
            //    else
            //    {
            //        fModificarTrabajador.miPeriodoTipoTrabajador.FechaFinal.TieneFin = false;
            //    }

            //}

            //if (fModificarTrabajador.ShowDialog() == DialogResult.OK)
            //{

            //}  
        }

        #region Codigo Para Facilitar al Usuario
        private void txtNacionalidad_Enter(object sender, EventArgs e)
        {
            toolTrabajador.ToolTipTitle = "TIP";
            toolTrabajador.Show("Presione F2 para seleccionar la nacionalidad", txtNacionalidad);
        }

        private void txtDepartamento_Enter(object sender, EventArgs e)
        {
            toolTrabajador.ToolTipTitle = "TIP";
            toolTrabajador.Show("Presione F2 para seleccionar el Departamento", txtDepartamento);
        }

        private void txtProvincia_Enter(object sender, EventArgs e)
        {
            toolTrabajador.ToolTipTitle = "TIP";
            toolTrabajador.Show("Presione F2 para seleccionar la Provincia", txtProvincia);
        }

        private void txtDistrito_Enter(object sender, EventArgs e)
        {
            toolTrabajador.ToolTipTitle = "TIP";
            toolTrabajador.Show("Presione F2 para seleccionar el distrito", txtDistrito);
        }

        private void txtTipoVia_Enter(object sender, EventArgs e)
        {
            toolTrabajador.ToolTipTitle = "TIP";
            toolTrabajador.Show("Presione F2 para seleccionar el tipo de via", txtTipoVia);
        }

        private void txtTipoZona_Enter(object sender, EventArgs e)
        {
            toolTrabajador.ToolTipTitle = "TIP";
            toolTrabajador.Show("Presione F2 para seleccionar el tipo de zona", txtTipoZona);
        }

        private void btnNacionalidad_Click(object sender, EventArgs e)
        {
            frmNacionalidad fNacionalidad = new frmNacionalidad();
            if (fNacionalidad.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                miTrabajador.MiNacionalidad = fNacionalidad.miNacionalidad;
                txtNacionalidad.Text = miTrabajador.MiNacionalidad.Descripcion;
            }
        }

        private void btnApartamento_Click(object sender, EventArgs e)
        {
            frmDepartamento fDepartamento = new frmDepartamento();
            if (fDepartamento.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                miTrabajador.MiDepartamento = fDepartamento.miDepartamento;
                txtDepartamento.Text = miTrabajador.MiDepartamento.Descripcion;
            }
        }

        private void btnProvincia_Click(object sender, EventArgs e)
        {
            if (txtDepartamento.Text.Length > 0)
            {
                frmProvincia fProvincia = new frmProvincia();
                fProvincia.miProvincia = new cProvincia();
                fProvincia.miProvincia.MiDepartamento = miTrabajador.MiDepartamento;
                if (fProvincia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miTrabajador.MiProvincia = fProvincia.miProvincia;
                    txtProvincia.Text = miTrabajador.MiProvincia.Descripcion;
                }
            }
            else
            {
                MessageBox.Show("Seleccione primero el departamento");
            }
        }

        private void btnDistrito_Click(object sender, EventArgs e)
        {
            if (txtProvincia.Text.Length > 0)
            {
                frmListaDistritos fListaDistritos = new frmListaDistritos();
                fListaDistritos.miDistrito = new cDistrito();
                fListaDistritos.miDistrito.MiProvincia = miTrabajador.MiProvincia;
                if (fListaDistritos.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miTrabajador.MiDistrito = fListaDistritos.miDistrito;
                    txtDistrito.Text = miTrabajador.MiDistrito.Descripcion;
                }
            }
        }

        private void btnTipoVia_Click(object sender, EventArgs e)
        {
            frmTipoVia fTipoVia = new frmTipoVia();
            if (fTipoVia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                miTrabajador.MiTipoVia = fTipoVia.miTipoVia;
                txtTipoVia.Text = miTrabajador.MiTipoVia.Descripcion;
            }
        }

        private void btnTipoZona_Click(object sender, EventArgs e)
        {
            frmTipoZona fTipoZona = new frmTipoZona();
            if (fTipoZona.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                miTrabajador.MiTipoZOna = fTipoZona.miTipoZona;
                txtTipoZona.Text = miTrabajador.MiTipoZOna.Descripcion;
            }
        }

        private void txtDNI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNombres.Focus();
            }
        }

        private void txtNombres_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtApellidoPaterno.Focus();
            }
        }

        private void txtApellidoPaterno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtApellidoMaterno.Focus();
            }
        }
        private void txtApellidoMaterno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboEstadoCivil.Focus();
                cboEstadoCivil.DroppedDown = true;
            }
        }

        private void cboSexo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDireccion.Focus();
            }
        }

        private void cboEstadoCivil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboSexo.Focus();
                cboSexo.DroppedDown = true;
            }
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCelularTrabajo.Focus();
            }
        }

        private void txtCelularTrabajo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCelularPersonal.Focus();
            }
        }

        private void txtCelularPersonal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpFechaNacimiento.Focus();
            }
        }

        private void dtpFechaNacimiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCorreo.Focus();
            }
        }

        private void txtCorreo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNacionalidad.Focus();
            }
        }

        private void txtNombreVia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNumeroVia.Focus();
            }
        }

        private void txtNumeroVia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDepartamentoInterior.Focus();
            }
        }

        private void txtDepartamentoInterior_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTipoZona.Focus();
            }
        }

        private void txtNombreZona_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtReferencia.Focus();
            }
        }

        private void txtReferencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar.Focus();
            }
        }
        #endregion

        private void chkEssaludVida_CheckedChanged(object sender, EventArgs e)
        {

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

        private void chkRenta4ta_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRenta4ta.Checked == true)
            {
                label11.Visible = true;
                txtNroRenta4ta.Visible = true;
            }
            else
            {
                label11.Visible = false;
                txtNroRenta4ta.Visible = false;
            }
        }

        private void txtCelularTrabajo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
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

        private void txtCelularPersonal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            if (modoEdicion == true )
            {

            }
            else
            {
                if (txtDNI.Text.Length == 8)
                {
                    cTrabajador TrabajadorDNI = miTrabajador.BuscarTrabajadorXDNI(txtDNI.Text);
                    if (TrabajadorDNI != null)
                    {
                        MessageBox.Show("El DNI ingresado ya pertenece a otro Obrero:" + TrabajadorDNI.Nombres + " "  + TrabajadorDNI.ApellidoPaterno + " " + TrabajadorDNI.ApellidoMaterno, "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDNI.Text = "";
                    }

                    
                }
            }
        }

        public static bool ValidateIdentificationDocumentPeru(string identificationDocument)
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

        private void txtValidador_TextChanged(object sender, EventArgs e)
        {
            if (txtDNI.Text.Length == 8)
            {
                if (ValidateIdentificationDocumentPeru(txtDNI.Text + txtValidador.Text)== true)
                {
                    picValidado.Image = Properties.Resources.check;
                    Validado = true;
                } 
                else
                {
                    picValidado.Image =  Properties.Resources.equis;
                    Validado = false;
                }
            }
            
        }
    }
}
