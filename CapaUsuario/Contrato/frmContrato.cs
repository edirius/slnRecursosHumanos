using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Contrato
{
    public partial class frmContrato : Form
    {
        int iAccion = 0;
        int sidtcontrato = 0;
        int sidtplanillacontrato = 0;
        int sidtcargo = 0;
        int sidtmeta = 0;
        int sidttrabajador = 0;

        public frmContrato()
        {
            InitializeComponent();
        }

        private void frmRegimenTrabajador_Load(object sender, EventArgs e)
        {
            CargarPlanillaContrato();
            CargarCargo();
            CargarAños();
            AñoMeta();
            cboPlantillaContrato_SelectedIndexChanged(sender, e);
            cboCargo_SelectedIndexChanged(sender, e);
            cboMeta_SelectedIndexChanged(sender, e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool bOk = false;
            CapaDeNegocios.Contrato.cContrato miContrato = new CapaDeNegocios.Contrato.cContrato();
            miContrato.Idtcontrato = sidtcontrato;
            miContrato.Fecharegistro = dtpFechaRegistro.Value;
            miContrato.NumeroDocumento = txtNumeroContrato.Text;
            miContrato.FechaInicio = dtpFechaInicio.Value;
            miContrato.FechaFin = dtpFechaFin.Value;
            miContrato.MontoPago = Convert.ToDecimal(nupMontoPago.Value);
            miContrato.RUC = txtRUC.Text;
            miContrato.Idtplantillacontrato = sidtplanillacontrato;
            miContrato.IdtCargo = sidtcargo;
            miContrato.IdtMeta = sidtmeta;
            miContrato.Idttrabajador = sidttrabajador;

            if (iAccion == 1)
            {
                miContrato.CrearContrato(miContrato);
                bOk = true;
            }
            if (iAccion == 2)
            {
                miContrato.ModificarContrato(miContrato);
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

        private void btnPlantillaContrato_Click(object sender, EventArgs e)
        {
            CapaUsuario.Contrato.frmPlantillaContrato fPlantillaContrato = new Contrato.frmPlantillaContrato();
            if (fPlantillaContrato.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarPlanillaContrato();
            }
        }

        private void cboPlantillaContrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPlantillaContrato.Text != "System.Data.DataRowView" && cboPlantillaContrato.ValueMember != "")
            {
                sidtplanillacontrato = Convert.ToInt32(cboPlantillaContrato.SelectedValue);
            }
        }

        private void cboCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCargo.Text != "System.Data.DataRowView" && cboCargo.ValueMember != "")
            {
                sidtcargo = Convert.ToInt32(cboCargo.SelectedValue);
            }
        }

        private void cboMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMeta.Text != "System.Data.DataRowView" && cboMeta.ValueMember != "" && cboMeta.SelectedValue != "0")
            {
                sidtmeta = Convert.ToInt32(cboMeta.SelectedValue);
            }
        }

        public void RecibirDatos(int pidtcontrato, DateTime pfecharegistro, string pnumerodocumento, DateTime pfechainicio, DateTime pfechafin, decimal pmontopago, string pruc, int pidtplanillacontrato, int pidtcargo, int pidtmeta, int pidttrabajador, int pAccion)
        {
            sidtcontrato = pidtcontrato;
            dtpFechaRegistro.Value = pfecharegistro;
            txtNumeroContrato.Text = pnumerodocumento;
            dtpFechaInicio.Value = pfechainicio;
            dtpFechaFin.Value = pfechafin;
            nupMontoPago.Value = pmontopago;
            txtRUC.Text = pruc;
            sidtplanillacontrato = pidtplanillacontrato;
            sidtcargo = pidtcargo;
            sidtmeta = pidtmeta;
            sidttrabajador = pidttrabajador;
            iAccion = pAccion;
        }

        private void CargarPlanillaContrato()
        {
            CapaDeNegocios.Contrato.cPlantillaContrato miPlantillaContrato = new CapaDeNegocios.Contrato.cPlantillaContrato();
            cboPlantillaContrato.DataSource = miPlantillaContrato.ListarPlantillaContrato();
            cboPlantillaContrato.DisplayMember = "descripcion";
            cboPlantillaContrato.ValueMember = "idtplantillacontrato";
            if (sidtplanillacontrato == 0) { cboPlantillaContrato.SelectedIndex = -1; }
            else { cboPlantillaContrato.SelectedValue = sidtplanillacontrato.ToString(); }
        }

        private void CargarCargo()
        {
            CapaDeNegocios.Contrato.cCargo miCargo = new CapaDeNegocios.Contrato.cCargo();
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in miCargo.ListaCargos().Rows)
            {
                coleccion.Add(Convert.ToString(row["descripcion"]));
            }
            cboCargo.DataSource = miCargo.ListaCargos();
            cboCargo.DisplayMember = "descripcion";
            cboCargo.ValueMember = "idtcargo";
            cboCargo.AutoCompleteCustomSource = coleccion;
            cboCargo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboCargo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            if (sidtcargo == 0) { cboCargo.SelectedIndex = -1; }
            else { cboCargo.SelectedValue = sidtcargo.ToString(); }
        }

        private void CargarMeta()
        {
            try
            {
                //CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miMeta = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
                //cboMeta.DataSource = miMeta.ListarMetas();
                //cboMeta.DisplayMember = "nombre";
                //cboMeta.ValueMember = "idtmeta";
                //if (smeta == "") { cboMeta.SelectedIndex = -1; }
                //else { cboMeta.Text = smeta; }

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
                    cboMeta.DataSource = new BindingSource(test, null);
                    cboMeta.DisplayMember = "Value";
                    cboMeta.ValueMember = "Key";
                }
                if (sidtmeta == 0) { cboMeta.SelectedIndex = -1; }
                else { cboMeta.SelectedValue = sidtmeta.ToString(); }
            }
            catch
            { }
        }

        private void CargarAños()
        {
            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                cboAño.Items.Add(i);
            }
        }

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMeta();
        }

        private void AñoMeta()
        {
            if (sidtmeta != 0)
            {
                DataTable oDataMeta = new DataTable();
                CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miMeta = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
                oDataMeta = miMeta.ListarMetas();
                foreach (DataRow row in oDataMeta.Select("idtmeta = '" + sidtmeta + "'"))
                {
                    cboAño.Text = row[1].ToString();
                }
            }
        }

        //public static class AutoCompleClass
        //{
        //    //metodo para cargar los datos de la bd
        //    public static DataTable Datos()
        //    {
        //        DataTable dt = new DataTable();
        //        CapaDeNegocios.DatosLaborales.cOcupacion miOcupacion = new CapaDeNegocios.DatosLaborales.cOcupacion();
        //        dt = miOcupacion.ListarOcupacion();
        //        return dt;
        //    }

        //    //metodo para cargar la coleccion de datos para el autocomplete
        //    public static AutoCompleteStringCollection Autocomplete()
        //    {
        //        DataTable dt = Datos();
        //        AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
        //        //recorrer y cargar los items para el autocompletado
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            coleccion.Add(Convert.ToString(row["pais"]));
        //        }
        //        return coleccion;
        //    }
        //}
    }
}
