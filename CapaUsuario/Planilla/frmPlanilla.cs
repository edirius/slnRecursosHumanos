using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Planilla
{
    public partial class frmPlanilla : Form
    {
        int iAccion;
        int sidtplanilla;
        int sidtmeta;
        int sidtfuentefinanciamiento;
        int sidtregimenlaboral;
        string smeta;
        string sfuentefinanciamiento;
        string sregimenlaboral;
        string saño;
        string splantilla;

        public frmPlanilla()
        {
            InitializeComponent();
        }

        private void frmPlanilla_Load(object sender, EventArgs e)
        {
            CargarAños();
            CargarFuenteFinanciamiento();
            CargarRegimenLaboral();
            CargarPlantilla();
            cboFuenteFinanciamiento_SelectedIndexChanged(sender, e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumero.Text.Trim() == "" || cboMes.Text.Trim() == "" || cboAño.Text.Trim() == "" || sidtmeta == 0 || sidtfuentefinanciamiento == 0 || sidtregimenlaboral == 0 || txtDescripcion.Text.Trim() == "" || cboPlantilla.Text.Trim() == "" )
                {
                    if (txtNumero.Text.Trim() == "")
                    {
                        MessageBox.Show("Debe colocar un numero de planilla", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (cboMes.Text.Trim() == "")
                    {
                        MessageBox.Show("Debe escoger un mes.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (cboAño.Text.Trim() == "")
                    {
                        MessageBox.Show("Debe escoger un año.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (sidtmeta == 0)
                    {
                        MessageBox.Show("Debe escoger una meta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (sidtfuentefinanciamiento == 0)
                    {
                        MessageBox.Show("Debe escoger una fuente de financiamiento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (sidtregimenlaboral == 0)
                    {
                        MessageBox.Show("Debe escoger un Regimen Laboral.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (txtDescripcion.Text.Trim() == "")
                    {
                        MessageBox.Show("Debe escribir una descripción.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (cboPlantilla.Text.Trim() == "")
                    {
                        MessageBox.Show("Debe escoger una plantilla.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    bool bOk = false;
                    CapaDeNegocios.Planillas.cPlanilla miPlanilla = new CapaDeNegocios.Planillas.cPlanilla();
                    miPlanilla.IdtPlanilla = sidtplanilla;
                    miPlanilla.Numero = txtNumero.Text;
                    miPlanilla.Mes = cboMes.Text;
                    miPlanilla.Año = cboAño.Text;
                    miPlanilla.Fecha = dtpFecha.Value;
                    miPlanilla.IdtMeta = sidtmeta;
                    miPlanilla.IdtFuenteFinanciamiento = sidtfuentefinanciamiento;
                    miPlanilla.IdtRegimenLaboral = sidtregimenlaboral;
                    miPlanilla.Descripcion = txtDescripcion.Text;
                    miPlanilla.Plantilla = cboPlantilla.Text;
                    if (iAccion == 1)
                    {
                        miPlanilla.CrearPlanilla(miPlanilla);
                        bOk = true;
                    }
                    if (iAccion == 2)
                    {
                        miPlanilla.ModificarPlanilla(miPlanilla);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la planilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMeta();
            cboMeta_SelectedIndexChanged(sender, e);
        }

        private void cboRegimenLaboral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRegimenLaboral.Text != "System.Data.DataRowView" && cboRegimenLaboral.ValueMember != "")
            {
                sidtregimenlaboral = Convert.ToInt32(cboRegimenLaboral.SelectedValue);
            }
        }

        private void cboMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMeta.Text != "System.Data.DataRowView" && cboMeta.ValueMember != "" && cboMeta.SelectedValue != "0")
            {
                sidtmeta = Convert.ToInt32(cboMeta.SelectedValue);
            }
        }

        private void cboFuenteFinanciamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFuenteFinanciamiento.Text != "System.Data.DataRowView" && cboFuenteFinanciamiento.ValueMember != "")
            {
                sidtfuentefinanciamiento = Convert.ToInt32(cboFuenteFinanciamiento.SelectedValue);
            }
        }

        public void RecibirDatos(int pidtplanilla, string pnumero, string pmes, string paño, DateTime pfecha, int pidtmeta, string pmeta, int pidtfuentefinanciamiento, string pfuentefinanciamiento, int pidtregimenlaboral, string pregimenlaboral, string pdescripcion, string pplanilla, int pAccion)
        {
            sidtplanilla = pidtplanilla;
            txtNumero.Text = pnumero;
            cboMes.Text = pmes;
            saño = paño;
            dtpFecha.Value = pfecha;
            sidtmeta = pidtmeta;
            smeta = pmeta;
            sidtfuentefinanciamiento = pidtfuentefinanciamiento;
            sfuentefinanciamiento = pfuentefinanciamiento;
            sidtregimenlaboral = pidtregimenlaboral;
            sregimenlaboral = pregimenlaboral;
            txtDescripcion.Text = pdescripcion;
            splantilla = pplanilla;
            iAccion = pAccion;
        }

        private void CargarAños()
        {
            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                cboAño.Items.Add(i);
            }
            if (saño == "") { cboAño.SelectedIndex = -1; }
            else { cboAño.Text = saño; }
        }

        private void CargarMeta()
        {
            try
            {
                if (cboAño.Text != "")
                {
                    DataTable oDataMeta = new DataTable();
                    CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miMeta = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
                    oDataMeta = miMeta.ListarMetas();
                    Dictionary<string, string> test = new Dictionary<string, string>();
                    foreach (DataRow row in oDataMeta.Select("año = '" + cboAño.Text + "'"))
                    {
                        test.Add(row[0].ToString(), row[3].ToString() + " - " + row[2].ToString());
                    }
                    if (test.Count == 0)
                    {
                        MessageBox.Show("No existe metas para el año: " + cboAño.Text);
                    }
                    else
                    {
                        cboMeta.DataSource = new BindingSource(test, null);
                        cboMeta.DisplayMember = "Value";
                        cboMeta.ValueMember = "Key";
                    }
                }
                if (sidtmeta == 0) { cboMeta.SelectedIndex = -1; }
                else { cboMeta.SelectedValue = sidtmeta.ToString(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al traer las metas: " + ex.Message);
            }
            
        }

        private void CargarFuenteFinanciamiento()
        {
            CapaDeNegocios.cFuenteFinanciamiento miFuenteFinanciamiento = new CapaDeNegocios.cFuenteFinanciamiento();
            cboFuenteFinanciamiento.DataSource = miFuenteFinanciamiento.ListarFuenteFinanciamiento();
            cboFuenteFinanciamiento.DisplayMember = "descripcion";
            cboFuenteFinanciamiento.ValueMember = "idtfuentefinanciamiento";
            if (sfuentefinanciamiento == "") { cboFuenteFinanciamiento.SelectedIndex = -1; }
            else { cboFuenteFinanciamiento.Text = sfuentefinanciamiento; }
        }

        private void CargarRegimenLaboral()
        {
            CapaDeNegocios.DatosLaborales.cRegimenLaboral miRegimenLaboral = new CapaDeNegocios.DatosLaborales.cRegimenLaboral();
            cboRegimenLaboral.DataSource = miRegimenLaboral.ListarRegimenLaboral();
            cboRegimenLaboral.DisplayMember = "descripcion";
            cboRegimenLaboral.ValueMember = "idtregimenlaboral";
            if (sregimenlaboral == "") { cboRegimenLaboral.SelectedIndex = -1; }
            else { cboRegimenLaboral.Text = sregimenlaboral; }
        }

        private void CargarPlantilla()
        {
            CapaDeNegocios.Planillas.cPlantillaPlanilla miPlantillaPlanilla = new CapaDeNegocios.Planillas.cPlantillaPlanilla();
            cboPlantilla.DataSource = miPlantillaPlanilla.ListarDescripcionPlantillaPlanilla();
            cboPlantilla.DisplayMember = "descripcion";
            if (splantilla == "") { cboPlantilla.SelectedIndex = -1; }
            else { cboPlantilla.Text = splantilla; }
        }
    }
}
