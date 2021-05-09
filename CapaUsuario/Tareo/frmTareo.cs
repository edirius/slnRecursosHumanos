using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Tareo
{
    public partial class frmTareo : Form
    {
        int sIdTTareo = 0;
        int sIdTMeta = 0;
        int iAccion;

        public frmTareo()
        {
            InitializeComponent();
        }

        private void frmTareo_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {
            bool bOk = false;
            CapaDeNegocios.Tareos.cTareo miTareo = new CapaDeNegocios.Tareos.cTareo();
            CapaDeNegocios.Obras.cMeta miMeta = new CapaDeNegocios.Obras.cMeta();
            miTareo.IdTTareo = sIdTTareo;
            miTareo.Numero = Convert.ToInt32(txtNumero.Text);
            miTareo.FechaInicio = dptFechaInicio.Value;
            miTareo.FechaFin = dptFechaFin.Value;
            miTareo.Descripcion = cboDescripcion.Text;
            miTareo.Estado = chkActivo.Checked;
            miMeta.Codigo = sIdTMeta;

            if (iAccion == 1)
            {
                miTareo.CrearTareo(miTareo, miMeta);
                bOk = true;
            }
            if (iAccion == 2)
            {
                miTareo.ModificarTareo(miTareo, miMeta);
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

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public void RecibirDatos(int pIdTTareo, int  pNumero, DateTime pFechaInicio, DateTime pFechaFin, string pDescripcion, bool pEstado, int pIdTMeta, string pNombre, int piAccion)
        {
            sIdTTareo = pIdTTareo;
            txtNumero.Text = Convert.ToString(pNumero);
            dptFechaInicio.Value = pFechaInicio;
            dptFechaFin.Value = pFechaFin;
            cboDescripcion.Text = pDescripcion;
            chkActivo.Checked = pEstado;
            sIdTMeta = pIdTMeta;
            txtMeta.Text = pNombre;
            iAccion = piAccion;
        }

        private void cboDescripcion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
