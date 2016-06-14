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


namespace CapaUsuario
{
    public partial class frmNuevoTrabajador : Form
    {
        public frmNuevoTrabajador()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
           
            
        }

        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Archivo JPG|*.jpg";

            if (file.ShowDialog() == DialogResult.OK)
            {
                picFoto.Image = Image.FromFile(file.FileName);
                picFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cTrabajadorCas nuevoTrabajador = new cTrabajadorCas();
            nuevoTrabajador.IdTrabajador = int.Parse ( txtId.Text);
            nuevoTrabajador.Nombres = txtNombres.Text;
            nuevoTrabajador.ApellidoPaterno = txtApellidoPaterno.Text ;
            nuevoTrabajador.ApellidoMaterno = txtApellidoMaterno.Text;
            nuevoTrabajador.CelularTrabajo = txtCelularTrabajo.Text;
            nuevoTrabajador.CelularPersonal = txtCelularPersonal.Text;
            nuevoTrabajador.Direccion = txtDireccion.Text;
            nuevoTrabajador.Dni = txtDNI.Text;
            if (cboSexo.Text == "Masculino") 
            { nuevoTrabajador.Sexo = EnumSexo.Masculino; }
            else { nuevoTrabajador.Sexo = EnumSexo.Femenino; }
            nuevoTrabajador.Foto = ConvertImage.ImageToByteArray(picFoto.Image);

        }
    }
}
