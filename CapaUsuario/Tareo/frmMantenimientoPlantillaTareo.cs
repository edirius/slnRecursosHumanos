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

namespace CapaUsuario.Tareo
{
    public partial class frmMantenimientoPlantillaTareo : Form
    {
        public CapaDeNegocios.Tareos.cPlantillaTareo oPlantillaTareo;

        public frmMantenimientoPlantillaTareo()
        {
            InitializeComponent();
        }

        private void frmMantenimientoPlantillaTareo_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            txtDescripcion.Text = oPlantillaTareo.Descripcion;
            chkJornal.Checked = oPlantillaTareo.Jornal;
            chkRacionamiento.Checked = oPlantillaTareo.Racionamiento;
            chkObrero.Checked = oPlantillaTareo.Obrero;
            chkActivo.Checked = oPlantillaTareo.Activo;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDescripcion.Text.Trim()!= "")
                {
                    oPlantillaTareo.Descripcion = txtDescripcion.Text;
                    oPlantillaTareo.Jornal = chkJornal.Checked;
                    oPlantillaTareo.Racionamiento = chkRacionamiento.Checked;
                    oPlantillaTareo.Obrero = chkObrero.Checked;
                    oPlantillaTareo.Activo = chkActivo.Checked;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Debe ingresar una descripcion.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
