using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeDatos;
using CapaDeNegocios.Obras;
using cWord;
using CapaUsuario.Properties;
using MySql.Data;
using MySql.Data.MySqlClient;
using CapaDeNegocios;
using System.IO;

namespace CapaUsuario.Usuarios
{
    public partial class frmLogin : Form
    {
        public string Usuario;
        
        CapaDeNegocios.Usuario.cUsuario oUsuario = new CapaDeNegocios.Usuario.cUsuario();
        ////MySqlConnection Con = new MySqlConnection(Settings.Default.ConexionMySql, "bdPersonal", "root", "root");
        //MySqlConnection cn = new MySqlConnection("Server =  192.168.1.60; Uid = root; Password = root; Database = bdPersonal");
        //MySqlCommand cmd = new MySqlCommand();
        public frmLogin()
        {
            
            InitializeComponent();
            pbImagen.Image = Resources.logo_muni_fw_;

        }
        
        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                string ruta = System.IO.Directory.GetCurrentDirectory();
                //string ruta = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                string ruta_imagen = ruta + "\\logo-muni-fw.png";
                //string ruta_imagen = ruta + "\\logo_MuniMaras.png";
                pbImagen.Image = new System.Drawing.Bitmap(ruta_imagen);
                lblServidor.Text = "Conectando a: " + Settings.Default.ConexionMySql;
                //Server = MYSQL5049.site4now.net; Database = db_a9f03e_edirius; Uid = a9f03e_edirius; Pwd = YOUR_DB_PASSWORD
                Conexion.IniciarSesion(Settings.Default.ConexionMySql, "bdpersonal", "root", "root");
                //Conexion.IniciarSesion("MYSQL8001.site4now.net", "db_a85d09_ediriu2", "a85d09_ediriu2", "bahamut0");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar al Servidor : " +  ex.Message);
                btnCambiarServidor.Visible = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                IniciarSesion();
            }
        }

       

        public void IniciarSesion()
        {
            
            try
            {
                DataView objDataView = new DataView();
                System.Data.DataTable odata = oUsuario.ListaUsuarios();
                
               
                objDataView.Table = oUsuario.ListaUsuarios();
                
                                
                    objDataView.RowFilter = "nombre='" + txtUsuario.Text + "' and contraseña='" + oUsuario.ObtenerSHA1(txtPass.Text) + "'";
                
                dgvUsuarios.DataSource = objDataView;
                if (objDataView.Count > 0)
                {
                    frmPrincipal Principal = new frmPrincipal();
                    MessageBox.Show("Bienvenido al Sistema de Planillas usuario " + txtUsuario.Text + ".", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    
                    cVariablesUsuario.v_idtrabajador = dgvUsuarios.Rows[0].Cells[4].Value.ToString();
                    cVariablesUsuario.v_idusuario = dgvUsuarios.Rows[0].Cells[0].Value.ToString();
                    cVariablesUsuario.v_usuario = dgvUsuarios.Rows[0].Cells[1].Value.ToString();
                    cVariablesUsuario.v_password = dgvUsuarios.Rows[0].Cells[2].Value.ToString();

                    cDatosGenerales oDatosGenerales = new cDatosGenerales();

                    cDatosGeneralesEmpresa.NombreEmpresa = oDatosGenerales.Nombre;
                    cDatosGeneralesEmpresa.RUC = oDatosGenerales.Ruc;
                    cDatosGeneralesEmpresa.Lugar = oDatosGenerales.Lugar;
                    cDatosGeneralesEmpresa.NombreOficina = oDatosGenerales.NombreOficina;
                    Principal.DarPrivilegios(txtUsuario.Text);
                    Principal.Show();
                    this.Hide();
                }
                else
                {
                    const string message = "El Usuario no existe o la contraseña es incorrecta.";
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Text = ""; txtPass.Text = ""; txtUsuario.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //string existe = "@a";
            //string user = "@b";
            //try
            //{
            //    int numero;
            //    string Contraseña = oUsuario.ObtenerSHA1(txtPass.Text);
            //    numero = oUsuario.ValidarUsuarioContraseña(txtUsuario.Text, Contraseña, existe, user);

            //    Usuario = txtUsuario.Text;
            //    //
            //    if (numero == 1)
            //    {
            //        frmPrincipal Principal = new frmPrincipal();
            //        MessageBox.Show("Bienvenido al sistema de planillas usuario " + Usuario + ".");
            //        Principal.Show();
            //        this.Hide();
            //        Principal.DarPrivilegios(Usuario);
            //    }
            //    else
            //    {
            //        const string message = "El Usuario no existe o la contraseña es incorrecta.";
            //        const string caption = "Error";
            //        var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        txtUsuario.Text = ""; txtPass.Text = ""; txtUsuario.Focus();
            //    }
            //}
            //catch { }
        }

        private void btnCambiarServidor_Click(object sender, EventArgs e)
        {
            Usuarios.frmModificarServidor fModificarUsuarios = new Usuarios.frmModificarServidor();
            fModificarUsuarios.ShowDialog();
        }
    }
}
