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
    public partial class frmHorasHombre : Form
    {
        int sIdTTareo = 0;
        int sNumero = 0;
        DateTime sFechaInicio= DateTime.Now;
        DateTime sFechaFin= DateTime.Now;
        string sDescripcion = "";
        bool sEstado = false;
        int sIdTMeta = 0;
        int[] sIdTMetaVinculada;

        CapaDeNegocios.Obras.cMeta miMeta = new CapaDeNegocios.Obras.cMeta();
        CapaDeNegocios.Tareos.cTareo miTareo = new CapaDeNegocios.Tareos.cTareo();
        CapaDeNegocios.Tareos.cTareoHorasAcumuladas miTareoHorasAcumuladas = new CapaDeNegocios.Tareos.cTareoHorasAcumuladas();

        public frmHorasHombre()
        {
            InitializeComponent();
        }

        private void frmMantenimientoCronogramaTareo_Load(object sender, EventArgs e)
        {
            cboMes.Text = Convert.ToString(DateTime.Now.ToString("MMMM"));
            CargarAños();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                string fecha = "";
                CapaDeNegocios.Tareos.cImprimirHorasHombre cImprimirHorasHombre = new CapaDeNegocios.Tareos.cImprimirHorasHombre();
                cImprimirHorasHombre.Iniciar();
                for (int i = 0; i < dgvTareo.Rows.Count; i++)
                {
                    cImprimirHorasHombre.tipotareo = Convert.ToString(dgvTareo.Rows[i].Cells[2].Value);
                    cImprimirHorasHombre.fechainicio = Convert.ToDateTime(dgvTareo.Rows[i].Cells[3].Value);
                    cImprimirHorasHombre.oImprimirTareo = miTareo.ImprimirTareo(sIdTMeta, Convert.ToInt32(dgvTareo.Rows[i].Cells[0].Value));
                    cImprimirHorasHombre.oImprimirHorasActual = miTareoHorasAcumuladas.ListarTareoHorasAcumuladas(Convert.ToInt32(dgvTareo.Rows[i].Cells[0].Value));
                    cImprimirHorasHombre.Tipo();
                }
                cImprimirHorasHombre.TotalHorasActual();
                fecha = cboAño.Text + Mes(cboMes.Text) + "01";
                for (int i = 0; i < sIdTMetaVinculada.Count(); i++)
                {
                    cImprimirHorasHombre.oImprimirHorasAcumuladas = miTareoHorasAcumuladas.ImprimirTareoHorasAcumuladas(sIdTMetaVinculada[i], fecha);
                    cImprimirHorasHombre.TotalHorasAcumuladas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMeta();
            cboMeta_SelectedIndexChanged(sender, e);
        }

        private void cboMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMeta.Text != "(Colección)" && cboMeta.ValueMember != "")
            {
                sIdTMeta = Convert.ToInt32(cboMeta.SelectedValue);
                CargarDatos();

                sIdTMetaVinculada = new int[1];
                sIdTMetaVinculada[0] = sIdTMeta;
                for (int i = 0; i < sIdTMetaVinculada.Count(); i++)
                {
                    if (MetasVinculadas(sIdTMetaVinculada[i]) != 0)
                    {
                        Array.Resize(ref sIdTMetaVinculada, 2 + i);
                        sIdTMetaVinculada[1 + i] = MetasVinculadas(sIdTMetaVinculada[i]);
                    }
                }
            }
        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMes.Text != "")
            {
                CargarDatos();
            }
        }

        private void dgvTareo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTareo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            { 
                sIdTTareo = Convert.ToInt32(dgvTareo.Rows[e.RowIndex].Cells[0].Value);
                sNumero = Convert.ToInt32(dgvTareo.Rows[e.RowIndex].Cells[1].Value);
                sDescripcion = Convert.ToString(dgvTareo.Rows[e.RowIndex].Cells[2].Value);
                sFechaInicio = Convert.ToDateTime(dgvTareo.Rows[e.RowIndex].Cells[3].Value);
                sFechaFin = Convert.ToDateTime(dgvTareo.Rows[e.RowIndex].Cells[4].Value);
                sEstado = Convert.ToBoolean(dgvTareo.Rows[e.RowIndex].Cells[5].Value);
            }
        }

        private void CargarAños()
        {
            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                cboAño.Items.Add(i);
            }
            cboAño.SelectedIndex = 0;
        }

        private void CargarMeta()
        {
            try
            {
                dgvTareo.Rows.Clear();
                CapaDeNegocios.cTrabajador miTrabajador = new CapaDeNegocios.cTrabajador();
                CapaDeNegocios.ResidenteMeta.cResidenteMeta miResidenteMeta = new CapaDeNegocios.ResidenteMeta.cResidenteMeta();
                miTrabajador.IdTrabajador = Convert.ToInt32(cVariablesUsuario.v_idtrabajador);
                DataTable oDataMeta = new DataTable();
                CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miCadena = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
                oDataMeta = miCadena.ListarMetas();
                Dictionary<string, string> test = new Dictionary<string, string>();
                if (cVariablesUsuario.v_cargo == "ADMINISTRADOR")
                {
                    foreach (DataRow row in oDataMeta.Select("año = '" + cboAño.Text + "'"))
                    {
                        test.Add(row[0].ToString(), row[3].ToString() + " - " + row[2].ToString());
                    }
                }
                else
                {
                    foreach (DataRow rowResidenteMeta in miResidenteMeta.ListarResidenteMeta(miTrabajador).Rows)
                    {
                        string xx = rowResidenteMeta[1].ToString();
                        foreach (DataRow row in oDataMeta.Select("idtmeta = '" + rowResidenteMeta[1].ToString() + "' and año = '" + cboAño.Text + "'"))
                        {
                            test.Add(row[0].ToString(), row[3].ToString() + " - " + row[2].ToString());
                        }
                    }
                }
                cboMeta.DataSource = new BindingSource(test, null);
                cboMeta.DisplayMember = "Value";
                cboMeta.ValueMember = "Key";
            }
            catch
            { }
        }

        private void CargarDatos()
        {
            dgvTareo.Rows.Clear();
            foreach (DataRow row in miTareo.ListarTareo(sIdTMeta).Rows)
            {
                string XX = Convert.ToString(Convert.ToDateTime(row[2].ToString()).ToString("MMMM"));
                if (cboMes.Text.ToUpper() == XX.ToUpper())
                {
                    dgvTareo.Rows.Add(row[0].ToString(), row[1].ToString(), row[4].ToString(), row[2].ToString(), row[3].ToString(), Convert.ToBoolean(row[5]));
                }
            }
            if (dgvTareo.Rows.Count > 0)
            {
                DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, 0);
                dgvTareo.Rows[0].Selected = true;
                dgvTareo_CellClick(dgvTareo, cea);
            }
        }

        private int MetasVinculadas(int pidtmeta)
        {
            int idtmetavinculada = 0;
            try
            {
                CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miCadena = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
                DataTable oDataMetaVinculo = new DataTable();
                oDataMetaVinculo = miCadena.ListarMetas();
                foreach (DataRow row in oDataMetaVinculo.Select("idtmeta = '" + pidtmeta + "'"))
                {
                    idtmetavinculada = Convert.ToInt32(row[6].ToString());
                }
            }
            catch
            { }
            return idtmetavinculada;
        }

        string Mes(string pmes)
        {
            string x = "";
            switch (pmes)
            {
                case "ENERO":
                    x = "01";
                    break;
                case "FEBRERO":
                    x = "02";
                    break;
                case "MARZO":
                    x = "03";
                    break;
                case "ABRIL":
                    x = "04";
                    break;
                case "MAYO":
                    x = "05";
                    break;
                case "JUNIO":
                    x = "06";
                    break;
                case "JULIO":
                    x = "07";
                    break;
                case "AGOSTO":
                    x = "08";
                    break;
                case "SETIEMBRE":
                    x = "09";
                    break;
                case "OCTUBRE":
                    x = "10";
                    break;
                case "NOVIEMBRE":
                    x = "11";
                    break;
                case "DICIEMBRE":
                    x = "12";
                    break;
            }
            return x;
        }
    }
}
