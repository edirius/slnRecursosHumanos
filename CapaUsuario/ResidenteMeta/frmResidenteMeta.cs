using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.ResidenteMeta
{
    public partial class frmResidenteMeta : Form
    {
        int sIdTResidenteMeta = 0;
        int sIdTTrabajador = 0;
        int iAccion = 0;
        string saño;
        CapaDeNegocios.ResidenteMeta.cResidenteMeta miResidenteMeta = new CapaDeNegocios.ResidenteMeta.cResidenteMeta();
        CapaDeNegocios.Obras.cMeta miMeta = new CapaDeNegocios.Obras.cMeta();
        CapaDeNegocios.cTrabajador miTrabajador = new CapaDeNegocios.cTrabajador();
        CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miCadena = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();

        public frmResidenteMeta()
        {
            InitializeComponent();
        }

        private void frmResidenteMeta_Load(object sender, EventArgs e)
        {
            CargarAños();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool bOk = false;
            if (iAccion == 1)
            {
                miTrabajador.IdTrabajador = sIdTTrabajador;
                foreach (DataGridViewRow row in dgvResidenteMeta.Rows)
                {
                    if (Convert.ToInt32(row.Cells[3].Value) == 1)
                    {
                        miMeta.Codigo = Convert.ToInt32(row.Cells[0].Value);
                        miResidenteMeta.CrearResidenteMeta(miMeta, miTrabajador);
                    }
                }
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

        public void RecibirDatos(int pIdTResidenteMeta, int pIdTTrabajador, string pResidente, int piAccion)
        {
            sIdTResidenteMeta = pIdTResidenteMeta;
            sIdTTrabajador = pIdTTrabajador;
            txtResidente.Text = pResidente;
            iAccion = piAccion;
        }

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMetas();
        }

        private void CargarMetas()
        {

            if (cboAño.Text != "")
            {
                int contador = 0;
                DataTable oDataTable, oDataTable1 = new DataTable();
                miTrabajador.IdTrabajador = 0;
                oDataTable = miResidenteMeta.ListarResidenteMeta(miTrabajador);
                oDataTable1 = miCadena.ListarMetas();

                dgvResidenteMeta.Rows.Clear();
                foreach (DataRow row in oDataTable1.Select("año = '" + cboAño.Text + "'"))
                {
                    contador = 0;
                    foreach (DataRow row1 in oDataTable.Select("idtmeta = '" + row[0].ToString() + "'"))
                    {
                        contador += 1;
                    }
                    if (contador == 0)
                    {
                        dgvResidenteMeta.Rows.Add(row[0].ToString(), row[3].ToString(), row[2].ToString());
                    }
                }
            }
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
    }
}
