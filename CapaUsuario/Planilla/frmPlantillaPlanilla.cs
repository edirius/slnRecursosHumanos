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
        string sTipo = "";
        public string[,] smaestro;
        public int sfilasseleccionmaestro = 0;

        DataTable oDataMaestroIngresos = new DataTable();
        DataTable oDataMaestroDescuentos = new DataTable();
        DataTable oDataMaestroATrabajador = new DataTable();
        DataTable oDataMaestroAEmpleador = new DataTable();

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
            int i = 0, j = 0;
            foreach (DataGridViewRow row in dgvMaestro.Rows)
            {
                if (Convert.ToInt32(row.Cells[3].Value) == 1)
                {
                    sfilasseleccionmaestro += 1;
                }
            }
            smaestro = new string[sfilasseleccionmaestro, 3];
            for (i = 0; i < dgvMaestro.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvMaestro.Rows[i].Cells[3].Value) == 1)
                {
                    smaestro[j, 0] = dgvMaestro.Rows[i].Cells[0].Value.ToString();
                    smaestro[j, 1] = dgvMaestro.Rows[i].Cells[1].Value.ToString();
                    smaestro[j, 2] = dgvMaestro.Rows[i].Cells[2].Value.ToString();
                    j += 1;
                }
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public void RecibirDatos(string ptipo)
        {
            sTipo = ptipo;
        }

        private void CargarDatos()
        {
            dgvMaestro.Rows.Clear();

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
                    dgvMaestro.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString());
                }
            }
            else if (sTipo == "DESCUENTOS")
            {
                foreach (DataRow row in oDataMaestroDescuentos.Rows)
                {
                    dgvMaestro.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString());
                }
            }
            else if (sTipo == "A_TRABAJADOR")
            {
                foreach (DataRow row in oDataMaestroATrabajador.Rows)
                {
                    dgvMaestro.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString());
                }
            }
            else if (sTipo == "A_EMPLEADOR")
            {
                foreach (DataRow row in oDataMaestroAEmpleador.Rows)
                {
                    dgvMaestro.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString());
                }
            }
        }
    }
}
