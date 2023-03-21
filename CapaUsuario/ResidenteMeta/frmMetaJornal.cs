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
    public partial class frmMetaJornal : Form
    {
        DataTable oDataMetaJornal = new DataTable();
        int sidtmeta = 0;

        CapaDeNegocios.Obras.cMeta miMeta = new CapaDeNegocios.Obras.cMeta();
        CapaDeNegocios.Obras.cMetaJornal miMejaJornal = new CapaDeNegocios.Obras.cMetaJornal();

        public frmMetaJornal()
        {
            InitializeComponent();
        }

        private void frmMetaJornal_Load(object sender, EventArgs e)
        {
            CargarAños();
            cboAño_SelectedIndexChanged(sender, e);
        }

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMeta();
            cboMeta_SelectedIndexChanged(sender, e);
        }

        private void btnMeta_Click(object sender, EventArgs e)
        {

        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            dgvMetaJornal.Rows.Clear();
            dgvMetaJornal.Rows.Add("I", "0", "MAESTRO DE OBRA", "0");
            dgvMetaJornal.Rows.Add("I", "0", "OPERARIO", "0");
            dgvMetaJornal.Rows.Add("I", "0", "OFICIAL", "0");
            dgvMetaJornal.Rows.Add("I", "0", "PEON", "0");
            dgvMetaJornal.Rows.Add("I", "0", "ALMACENERO", "0");
            dgvMetaJornal.Rows.Add("I", "0", "GUARDIAN", "0");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            bool bOk = false;
            foreach (DataGridViewRow row in dgvMetaJornal.Rows)
            {
                miMejaJornal.IdtMetaJornal = Convert.ToInt32(row.Cells[1].Value);
                miMejaJornal.Categoria = Convert.ToString(row.Cells[2].Value);
                miMejaJornal.Jornal = Convert.ToDouble(row.Cells[3].Value);
                miMejaJornal.Mensual = Convert.ToDouble(row.Cells[4].Value);
                //jornal = 0 false, Mensual = 1 true
                if (row.Cells[5].Value == null || row.Cells[5].Value.ToString() == "Jornal")
                {
                    miMejaJornal.Opcion = false;
                }
                else
                {
                    miMejaJornal.Opcion = true;
                }

                miMeta.Codigo = sidtmeta;
                if (Convert.ToString(row.Cells[0].Value) == "I")
                {
                    miMejaJornal.CrearMetaJornal(miMejaJornal, miMeta);
                    oDataMetaJornal = miMejaJornal.ListarMetaJornal(miMeta.Codigo);
                    miMejaJornal.IdtMetaJornal = Convert.ToInt32(oDataMetaJornal.Compute("MAX(idtmetajornal)", ""));
                    row.Cells[1].Value = miMejaJornal.IdtMetaJornal.ToString();
                    row.Cells[0].Value = "M";
                    bOk = true;
                    MessageBox.Show("Se creo la meta jornal", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Convert.ToString(row.Cells[0].Value) == "M")
                {
                    miMejaJornal.ModificarMetaJornal(miMejaJornal, miMeta);
                    bOk = true;
                    MessageBox.Show("Se modificó la meta jornal", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (bOk == false)
            {
                MessageBox.Show("No existen datos que se puedan registrar", "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CargarDatos();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMeta.Text != "System.Data.DataRowView" && cboMeta.ValueMember != "")
            {
                sidtmeta = Convert.ToInt32(cboMeta.SelectedValue);
                CargarDatos();
            }
        }

        private void CargarMeta()
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
                cboMeta.DataSource = new BindingSource(test, null);
                cboMeta.DisplayMember = "Value";
                cboMeta.ValueMember = "Key";
            }
            if (sidtmeta == 0) { cboMeta.SelectedIndex = -1; }
            else { cboMeta.SelectedValue = sidtmeta.ToString(); }
        }

        private void CargarDatos()
        {
            string valorOpcion;
            string valorMensual;

            dgvMetaJornal.Rows.Clear();
            oDataMetaJornal = miMejaJornal.ListarMetaJornal(sidtmeta);
            if (oDataMetaJornal.Rows.Count == 0)
            {
                btnCategorias.Enabled = true;
            }
            else
            {
                btnCategorias.Enabled = false;
                foreach (DataRow row in oDataMetaJornal.Rows)
                {
                    //jornal = 0 false, Mensual = 1 true
                    if (row[5].ToString() == "" || row[5].ToString() == "0")
                    {
                        valorOpcion = "Jornal";
                        
                    }
                    else
                    {
                        valorOpcion = "Mensual";
                    }

                    if(row[4].ToString() == "")
                    {
                        valorMensual = "0";
                    }
                    else
                    {
                        valorMensual = row[4].ToString();
                    }
                    dgvMetaJornal.Rows.Add("M", row[0].ToString(), row[1].ToString(), row[2].ToString(), valorMensual, valorOpcion);
                }
            }
        }

        private void CargarAños()
        {
            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                cboAño.Items.Add(i);
            }
            cboAño.Text = Convert.ToString(DateTime.Now.Year);
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevaCategoriaJornal fNuevaCategoriaJornal = new frmNuevaCategoriaJornal();
                fNuevaCategoriaJornal.oMetaJornal = new CapaDeNegocios.Obras.cMetaJornal();
                fNuevaCategoriaJornal.oMetaJornal.Meta.Codigo = sidtmeta;
                if (fNuevaCategoriaJornal.ShowDialog() == DialogResult.OK)
                {
                    miMejaJornal.CrearMetaJornal(fNuevaCategoriaJornal.oMetaJornal, fNuevaCategoriaJornal.oMetaJornal.Meta);
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la categoria: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMetaJornal.SelectedCells.Count > 0)
                {
                    frmModificarcategoriaJornal fNuevaCategoriaJornal = new frmModificarcategoriaJornal();
                    fNuevaCategoriaJornal.oMetaJornal = new CapaDeNegocios.Obras.cMetaJornal();

                    fNuevaCategoriaJornal.oMetaJornal.Categoria = dgvMetaJornal.Rows[dgvMetaJornal.SelectedCells[0].RowIndex].Cells[2].Value.ToString();
                    fNuevaCategoriaJornal.oMetaJornal.IdtMetaJornal =Convert.ToInt32( dgvMetaJornal.Rows[dgvMetaJornal.SelectedCells[0].RowIndex].Cells[1].Value.ToString());
                    fNuevaCategoriaJornal.oMetaJornal.Jornal = Convert.ToDouble(dgvMetaJornal.Rows[dgvMetaJornal.SelectedCells[0].RowIndex].Cells[3].Value.ToString());
                    fNuevaCategoriaJornal.oMetaJornal.Mensual = Convert.ToDouble(dgvMetaJornal.Rows[dgvMetaJornal.SelectedCells[0].RowIndex].Cells[4].Value.ToString());

                    //jornal = 0 false, Mensual = 1 true
                    if (dgvMetaJornal.Rows[dgvMetaJornal.SelectedCells[0].RowIndex].Cells[5].Value.ToString() == "Jornal") 
                    {
                        fNuevaCategoriaJornal.oMetaJornal.Opcion = false;
                    }
                    else
                    {
                        fNuevaCategoriaJornal.oMetaJornal.Opcion = true;
                    }
                    
                    fNuevaCategoriaJornal.oMetaJornal.Meta.Codigo = sidtmeta;

                    if (fNuevaCategoriaJornal.ShowDialog() == DialogResult.OK)
                    {
                        miMejaJornal.ModificarMetaJornal(fNuevaCategoriaJornal.oMetaJornal, fNuevaCategoriaJornal.oMetaJornal.Meta);
                        CargarDatos();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una categoria", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la categoria: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                CapaDeNegocios.Meta.cImprimirMetaJornal oImprimir = new CapaDeNegocios.Meta.cImprimirMetaJornal();
                CapaDeNegocios.Obras.cMetaJornal oMetaJornal = new CapaDeNegocios.Obras.cMetaJornal();

                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "ListaMetaJornal" + cboAño.Text + ".xls";

                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    oImprimir.ruta = fichero.FileName;
                    oImprimir.tablaMetaJornal = oMetaJornal.TraerMetaJornalxAnio(Convert.ToInt16(cboAño.Text));
                    if (oImprimir.tablaMetaJornal.Rows.Count == 0)
                    {
                        MessageBox.Show("La consulta esta vacia o no hay metas para el año: " + cboAño.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        oImprimir.Imprimir();
                        //oImprimir.Main();
                        MessageBox.Show("Excel Exportado.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
