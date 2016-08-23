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
        public cTrabajador miTrabajador;
        //public cPeriodo miPeriodo ;
        

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
            
           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
             miTrabajador.IdTrabajador = Convert.ToInt16 ( txtCodigo.Text);
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
                     miTrabajador.EstadoCivil= enumEstadoCivil.Soltero ;
                     break;
                 case "Viudo":
                     miTrabajador.EstadoCivil = enumEstadoCivil.Viudo;
                     break;
                 case "Divorciado":
                     miTrabajador.EstadoCivil = enumEstadoCivil.Divorciado ;
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
            miTrabajador.CelularTrabajo =  txtCelularTrabajo.Text;
            miTrabajador.CelularPersonal = txtCelularPersonal.Text;
            miTrabajador.FechaNacimiento =  dtpFechaNacimiento.Value;
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
        
            
            DialogResult = System.Windows.Forms.DialogResult.OK;
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
        #endregion


    }



}
