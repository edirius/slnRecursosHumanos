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
    public partial class frmPlantillaPlanilla : Form
    {
        int iAccion = 0;
        int sIdTPlantillaPlanilla = 0;
        string sTipo = "";
        int sidtregimenlaboral = 0;

        DataTable oDataPlantillaPlanilla = new DataTable();
        DataTable oDataMaestroIngresos = new DataTable();
        DataTable oDataMaestroDescuentos = new DataTable();
        DataTable oDataMaestroATrabajador = new DataTable();
        DataTable oDataMaestroAEmpleador = new DataTable();

        CapaDeNegocios.Planillas.cPlantillaPlanilla miPlantillaPlanilla = new CapaDeNegocios.Planillas.cPlantillaPlanilla();

        public frmPlantillaPlanilla()
        {
            InitializeComponent();
        }

        private void frmPlantillaPlanilla_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool bOk = false;
            if (iAccion == 1)
            {
                miPlantillaPlanilla.Tipo = sTipo;
                miPlantillaPlanilla.IdtRegimenLaboral = sidtregimenlaboral;
                foreach (DataGridViewRow row in dgvMaestro.Rows)
                {
                    if (Convert.ToInt32(row.Cells[3].Value) == 1)
                    {
                        miPlantillaPlanilla.Codigo = Convert.ToInt32(row.Cells[0].Value);
                        miPlantillaPlanilla.CrearPlantillaPlanilla(miPlantillaPlanilla);
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

        public void RecibirDatos(string ptipo, string pregimenlaboral, int pidtregimenlaboral, int piAccion)
        {
            sTipo = ptipo;
            txtTipoTrabajador.Text = pregimenlaboral;
            sidtregimenlaboral = pidtregimenlaboral;
            iAccion = piAccion;
        }

        private void CargarDatos()
        {
            int contador = 0;
            dgvMaestro.Rows.Clear();

            oDataPlantillaPlanilla = miPlantillaPlanilla.ListarPlantillaPlanilla(sidtregimenlaboral);

            CapaDeNegocios.Sunat.cMaestroIngresos miMaestroIngresos = new CapaDeNegocios.Sunat.cMaestroIngresos();
            oDataMaestroIngresos = miMaestroIngresos.ListarMaestroIngresos("");
            CapaDeNegocios.Sunat.cMaestroDescuentos miMaestroDescuentos = new CapaDeNegocios.Sunat.cMaestroDescuentos();
            oDataMaestroDescuentos = miMaestroDescuentos.ListarMaestroDescuentos();
            CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador miMaestroATrabajador = new CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador();
            oDataMaestroATrabajador = miMaestroATrabajador.ListarMaestroAportacionesTrabajador();
            CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador miMaestroAEmpleador = new CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador();
            oDataMaestroAEmpleador = miMaestroAEmpleador.ListarMaestroAportacionesEmpleador();

            if (sTipo == "INGRESOS")
            {
                foreach (DataRow row in oDataMaestroIngresos.Rows)
                {
                    contador = 0;
                    foreach (DataRow row1 in oDataPlantillaPlanilla.Select("codigo = '" + row[0].ToString() + "' AND tipo = '" + sTipo + "'"))
                    {
                        contador += 1;
                    }
                    if (contador == 0)
                    {
                        dgvMaestro.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString());
                    }
                }
            }
            else if (sTipo == "DESCUENTOS")
            {
                foreach (DataRow row in oDataMaestroDescuentos.Rows)
                {
                    contador = 0;
                    foreach (DataRow row1 in oDataPlantillaPlanilla.Select("codigo = '" + row[0].ToString() + "' AND tipo = '" + sTipo + "'"))
                    {
                        contador += 1;
                    }
                    if (contador == 0)
                    {
                        dgvMaestro.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString());
                    }
                }
            }
            else if (sTipo == "A_TRABAJADOR")
            {
                foreach (DataRow row in oDataMaestroATrabajador.Rows)
                {
                    contador = 0;
                    foreach (DataRow row1 in oDataPlantillaPlanilla.Select("codigo = '" + row[0].ToString() + "' AND tipo = '" + sTipo + "'"))
                    {
                        contador += 1;
                    }
                    if (contador == 0)
                    {
                        dgvMaestro.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString());
                    }
                }
            }
            else if (sTipo == "A_EMPLEADOR")
            {
                foreach (DataRow row in oDataMaestroAEmpleador.Rows)
                {
                    contador = 0;
                    foreach (DataRow row1 in oDataPlantillaPlanilla.Select("codigo = '" + row[0].ToString() + "' AND tipo = '" + sTipo + "'"))
                    {
                        contador += 1;
                    }
                    if (contador == 0)
                    {
                        dgvMaestro.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString());
                    }
                }
            }
        }
    }
}
