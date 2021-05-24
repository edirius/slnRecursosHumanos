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
    public partial class frmSeleccionarConceptos : Form
    {
        public string sDescripcion;

        public string ConceptoSeleccionado;

        DataTable oDataPlantillaPlanilla = new DataTable();
        DataTable oDataMaestroIngresos = new DataTable();
        DataTable oDataMaestroDescuentos = new DataTable();
        DataTable oDataMaestroATrabajador = new DataTable();
        DataTable oDataMaestroAEmpleador = new DataTable();

        CapaDeNegocios.Planillas.cPlantillaPlanilla miPlantillaPlanilla = new CapaDeNegocios.Planillas.cPlantillaPlanilla();

        public frmSeleccionarConceptos()
        {
            InitializeComponent();
        }

        private void frmSeleccionarConceptos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            dtgIngresos.Rows.Clear();
            
            dtgAportaciones.Rows.Clear();
            
            oDataPlantillaPlanilla = miPlantillaPlanilla.ListarPlantillaPlanilla(sDescripcion);

            CapaDeNegocios.Sunat.cMaestroIngresos miMaestroIngresos = new CapaDeNegocios.Sunat.cMaestroIngresos();
            oDataMaestroIngresos = miMaestroIngresos.ListarMaestroIngresos("");
            CapaDeNegocios.Sunat.cMaestroDescuentos miMaestroDescuentos = new CapaDeNegocios.Sunat.cMaestroDescuentos();
            oDataMaestroDescuentos = miMaestroDescuentos.ListarMaestroDescuentos();
            CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador miMaestroATrabajador = new CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador();
            oDataMaestroATrabajador = miMaestroATrabajador.ListarMaestroAportacionesTrabajador();
            CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador miMaestroAEmpleador = new CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador();
            oDataMaestroAEmpleador = miMaestroAEmpleador.ListarMaestroAportacionesEmpleador();

            foreach (DataRow row in oDataPlantillaPlanilla.Rows)
            {
                if (row[3].ToString() == "INGRESOS" && chkIngresos.Checked)
                {
                    foreach (DataRow rowI in oDataMaestroIngresos.Select("idtmaestroingresos = '" + row[4].ToString() + "'"))
                    {
                        dtgIngresos.Rows.Add("", "M", row[0].ToString(), rowI[0].ToString(), row[2].ToString(), rowI[1].ToString(), rowI[2].ToString());
                    }
                }
                
                else if (row[3].ToString() == "A_EMPLEADOR" && chkAportaciones.Checked)
                {
                    foreach (DataRow rowI in oDataMaestroAEmpleador.Select("idtmaestroaportacionesempleador = '" + row[4].ToString() + "'"))
                    {
                        dtgAportaciones.Rows.Add("", "M", row[0].ToString(), rowI[0].ToString(), row[2].ToString(), rowI[1].ToString(), rowI[2].ToString());
                    }
                }
            }
        }

        private void chkVacio_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void chkTotalIngresos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTotalIngresos.Checked)
            {
                chkTotalAportaciones.Checked = false;
                chkIngresos.Checked = false;
                chkAportaciones.Checked = false;
                ConceptoSeleccionado = "Total Ingresos";
            }
            else
            {
               
            }
        }

        private void chkTotalAportaciones_CheckedChanged(object sender, EventArgs e)
        {
            if(chkTotalAportaciones.Checked)
            {
                chkTotalIngresos.Checked = false;
                chkIngresos.Checked = false;
                chkAportaciones.Checked = false;
                ConceptoSeleccionado = "Total Aportaciones";
            }
            else
            {
             
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((dtgAportaciones.SelectedRows.Count==0)&& (dtgIngresos.SelectedRows.Count == 0)&& (chkTotalAportaciones.Checked == false) && (chkTotalIngresos.Checked == true))
                {
                    MessageBox.Show("Debe seleccionar una de las 4 opciones");
                }
                else
                {
                    if (chkVacio.Checked)
                    {
                        ConceptoSeleccionado = ConceptoSeleccionado + "&&Vacio";
                    }
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar concepto: " +ex.Message);
            }
        }

        private void dtgIngresos_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgIngresos.SelectedRows.Count > 0)
            {
                ConceptoSeleccionado = dtgIngresos.SelectedRows[0].Cells["txtCodigoMaestroIngresos"].Value.ToString();
            }
        }

        private void chkAportaciones_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAportaciones.Checked)
            {
                dtgAportaciones.Enabled = true;
                chkIngresos.Checked = false;
                chkTotalAportaciones.Checked = false;
                chkTotalIngresos.Checked = false;
                CargarDatos();
            }
            else
            {
                dtgAportaciones.Enabled = false;
                
            }
        }

        private void chkIngresos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIngresos.Checked)
            {
                dtgIngresos.Enabled = true;
                chkAportaciones.Checked = false;
                chkTotalAportaciones.Checked = false;
                chkTotalIngresos.Checked = false;
                CargarDatos();
            }
            else
            {
                dtgIngresos.Enabled = false;
            }
        }

        private void dtgAportaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgAportaciones.SelectedRows.Count > 0) 
            {
                ConceptoSeleccionado = dtgAportaciones.SelectedRows[0].Cells["dataGridViewTextBoxColumn8"].Value.ToString();
            }
        }

        private void dtgIngresos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chkTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodo.Checked)
            {
                dtgIngresos.Enabled = false;
                chkAportaciones.Checked = false;
                chkTotalAportaciones.Checked = false;
                chkTotalIngresos.Checked = false;
                ConceptoSeleccionado = "Todo";
            }
        }
    }
}
