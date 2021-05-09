using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.ClasificadorMeta
{
    public partial class frmClasificadorMeta : Form
    {
        int sidtplanilla;
        int sidtmeta;
        string smeta;

        string saño;
        string splantilla;


        CapaDeNegocios.ClasificadorMeta.cClasificadoresxMetaxPlantilla oClasificadorxMetaxPlantilla = new CapaDeNegocios.ClasificadorMeta.cClasificadoresxMetaxPlantilla();

        CapaDeNegocios.Obras.cMeta oMetaSeleccionada = new CapaDeNegocios.Obras.cMeta();
        CapaDeNegocios.Planillas.cPlantillaPlanilla oPlantillaSeleccionada = new CapaDeNegocios.Planillas.cPlantillaPlanilla();

        public frmClasificadorMeta()
        {
            InitializeComponent();
        }

        private void frmClasificadorMeta_Load(object sender, EventArgs e)
        {
            CargarAños();
          

            CargarPlantilla();


        }

        private void CargarTabla()
        {
            if ((oMetaSeleccionada.Codigo != 0) && (oPlantillaSeleccionada.Descripcion != ""))
            {
                dtgClasificadorMeta.Rows.Clear();
                List<CapaDeNegocios.ClasificadorMeta.cClasificadorMeta> Lista = new List<CapaDeNegocios.ClasificadorMeta.cClasificadorMeta>();

                Lista = oClasificadorxMetaxPlantilla.ListaClasificadoresMeta(oPlantillaSeleccionada, oMetaSeleccionada);

                foreach (CapaDeNegocios.ClasificadorMeta.cClasificadorMeta item in Lista)
                {
                    dtgClasificadorMeta.Rows.Add(item.Idttdatosmetaclasificador, item.Plantilla.Descripcion, item.Especifica.IdtEspecifica2,  item.Especifica.Codigo, item.Concepto);
                }
            }
        }

        private void btnNuevoClasificador_Click(object sender, EventArgs e)
        {
            try
            {
                if (sidtmeta == 0)
                {
                    MessageBox.Show("Seleccione la meta");
                    
                }
                else
                {
                    if (cboPlantilla.Text == "")
                    {
                        MessageBox.Show("Seleccione la plantilla");
                    }
                    else
                    {
                        frmMantenimientoClasificador fMantenimientoClasificador = new frmMantenimientoClasificador();
                        fMantenimientoClasificador.sDescripcionPlanilla = cboPlantilla.Text;
                        fMantenimientoClasificador.oClasificadorMeta = new CapaDeNegocios.ClasificadorMeta.cClasificadorMeta();
                        fMantenimientoClasificador.oClasificadorMeta.Meta = oMetaSeleccionada;
                        fMantenimientoClasificador.oClasificadorMeta.Plantilla = oPlantillaSeleccionada;

                        if (fMantenimientoClasificador.ShowDialog() == DialogResult.OK)
                        {
                            oClasificadorxMetaxPlantilla.CrearClasificadorMeta(fMantenimientoClasificador.oClasificadorMeta);
                            CargarTabla();
                        }
                    }
                    
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro al seleccionarclasificador: " + ex.Message);
            }
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
                    cboMeta.DataSource = new BindingSource(test, null);
                    cboMeta.DisplayMember = "Value";
                    cboMeta.ValueMember = "Key";
                }
                if (sidtmeta == 0) { cboMeta.SelectedIndex = -1; }
                else { cboMeta.SelectedValue = sidtmeta.ToString();
                    CargarTabla();
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("Error al cargar las metas para el año :" + cboAño.Text + ": " + EX.Message);
            }

           
        }

        private void CargarPlantilla()
        {
            CapaDeNegocios.Planillas.cPlantillaPlanilla miPlantillaPlanilla = new CapaDeNegocios.Planillas.cPlantillaPlanilla();
            cboPlantilla.DataSource = miPlantillaPlanilla.ListarDescripcionPlantillaPlanilla();
            cboPlantilla.DisplayMember = "descripcion";
            if (splantilla == "") { cboPlantilla.SelectedIndex = -1; }
            else { cboPlantilla.Text = splantilla;
                oPlantillaSeleccionada.Descripcion = splantilla;
                CargarTabla();
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

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMeta();
            cboMeta_SelectedIndexChanged(sender, e);
        }

        private void cboMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMeta.Text != "System.Data.DataRowView" && cboMeta.ValueMember != "" && cboMeta.SelectedValue != "0")
            {
                sidtmeta = Convert.ToInt32(cboMeta.SelectedValue);
                oMetaSeleccionada.Codigo = sidtmeta;
            }
        }

        private void cboPlantilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            oPlantillaSeleccionada.Descripcion = cboPlantilla.Text;
            CargarTabla();
        }

        private void btnModificarClasificador_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgClasificadorMeta.SelectedRows.Count > 0)
                {


                    frmMantenimientoClasificador fMantenimientoClasificador = new frmMantenimientoClasificador();
                    fMantenimientoClasificador.sDescripcionPlanilla = cboPlantilla.Text;
                    fMantenimientoClasificador.oClasificadorMeta = new CapaDeNegocios.ClasificadorMeta.cClasificadorMeta();
                    fMantenimientoClasificador.oClasificadorMeta.Meta = oMetaSeleccionada;
                    fMantenimientoClasificador.oClasificadorMeta.Plantilla = oPlantillaSeleccionada;
                    fMantenimientoClasificador.oClasificadorMeta.Especifica.IdtEspecifica2 = Convert.ToInt16(dtgClasificadorMeta.SelectedRows[0].Cells[2].Value.ToString());
                    fMantenimientoClasificador.oClasificadorMeta.Especifica.Codigo = dtgClasificadorMeta.SelectedRows[0].Cells[3].Value.ToString();
                    fMantenimientoClasificador.oClasificadorMeta.Idttdatosmetaclasificador = Convert.ToInt16(dtgClasificadorMeta.SelectedRows[0].Cells[0].Value.ToString());

                    fMantenimientoClasificador.oClasificadorMeta.Concepto = dtgClasificadorMeta.SelectedRows[0].Cells[4].Value.ToString();
                    if (fMantenimientoClasificador.ShowDialog() == DialogResult.OK)
                    {
                        oClasificadorxMetaxPlantilla.ModificarClasificadorMeta(fMantenimientoClasificador.oClasificadorMeta);
                        CargarTabla();
                        MessageBox.Show("Se modifico correctamente.", "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("La operacion se canceló", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
               
                else
                {
                    MessageBox.Show("Seleccione un concepto para modificarlo", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro al seleccionarclasificador: " + ex.Message);
            }
        }
    }
}
