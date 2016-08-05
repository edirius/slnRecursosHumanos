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
    public partial class frmSeleccionTrabajadorPlanilla : Form
    {
        int sidtregimenlaboral;
        int sidtmeta;
        string smes = "";
        string saño = "";
        public string[,] strabajadores;
        public int sfilasselecciontrabajadores = 0;

        public frmSeleccionTrabajadorPlanilla()
        {
            InitializeComponent();
        }

        private void frmSeleccionTrabajadorPlanilla_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int i = 0, j = 0;
            foreach (DataGridViewRow row in dgvTrabajador.Rows)
            {
                if (Convert.ToInt32(row.Cells[3].Value) == 1)
                {
                    sfilasselecciontrabajadores += 1;
                }
            }
            strabajadores = new string[sfilasselecciontrabajadores, 2];
            for (i = 0; i < dgvTrabajador.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvTrabajador.Rows[i].Cells[3].Value) == 1)
                {
                    strabajadores[j, 0] = dgvTrabajador.Rows[i].Cells[0].Value.ToString();
                    strabajadores[j, 1] = dgvTrabajador.Rows[i].Cells[2].Value.ToString();
                    j += 1;
                }
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public void RecibirDatos(string pmes, string paño, int pidtmeta, int pidtregimenlaboral)
        {
            Mes(pmes);
            saño = paño;
            sidtmeta = pidtmeta;
            sidtregimenlaboral = pidtregimenlaboral;
        }

        private void CargarDatos()
        {
            dgvTrabajador.Rows.Clear();

            DataTable oDataTrabajador = new DataTable();
            DataTable oDataPeriodoTrabajador = new DataTable();
            DataTable oDataRegimenTrabajador = new DataTable();

            CapaDeNegocios.cTrabajador miTrabajador = new CapaDeNegocios.cTrabajador();
            CapaDeNegocios.DatosLaborales.cPeriodoTrabajador miPeriodoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
            CapaDeNegocios.DatosLaborales.cRegimenTrabajador miRegimenTrabajor = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();

            oDataRegimenTrabajador = miRegimenTrabajor.ListarRegimenTrabajador(0);
            oDataPeriodoTrabajador = miPeriodoTrabajador.ListarPeriodoTrabajador(0);
            oDataTrabajador = miTrabajador.ObtenerListaTrabajadores(true);

            foreach (DataRow rowRegimenTrabajador in oDataRegimenTrabajador.Select("idtmeta = '" + sidtmeta + "' and idtregimenlaboral = '" + sidtregimenlaboral + "' and fechainicio <= '31/" + smes + "/" + saño + "' and (fechafin >= '01/" + smes + "/" + saño + "' or fechafin>='')", "idtcargo"))
            {
                foreach (DataRow rowPeriodoTrabajador in oDataPeriodoTrabajador.Select("idtperiodotrabajador = '" + rowRegimenTrabajador[17].ToString() + "'"))
                {
                    foreach (DataRow rowTrabajador in oDataTrabajador.Select("id_trabajador = '" + rowPeriodoTrabajador[4].ToString() + "'"))
                    {
                        dgvTrabajador.Rows.Add(rowTrabajador[0].ToString(), rowTrabajador[1].ToString(), rowTrabajador[2].ToString() + " " + rowTrabajador[3].ToString() + " " + rowTrabajador[4].ToString());
                    }
                }
            }
        }

        private void Mes(string pmes)
        {
            switch (pmes)
            {
                case "ENERO":
                    smes = "01";
                    break;
                case "FEBRERO":
                    smes = "02";
                    break;
                case "MARZO":
                    smes = "03";
                    break;
                case "ABRIL":
                    smes = "04";
                    break;
                case "MAYO":
                    smes = "05";
                    break;
                case "JUNIO":
                    smes = "06";
                    break;
                case "JULIO":
                    smes = "07";
                    break;
                case "AGOSTO":
                    smes = "08";
                    break;
                case "SEPTIEMBRE":
                    smes = "09";
                    break;
                case "OCTUBRE":
                    smes = "10";
                    break;
                case "NOVIEMBRE":
                    smes = "11";
                    break;
                case "DICIEMBRE":
                    smes = "12";
                    break;
                    //default:
                    //    Console.WriteLine("Default case");
                    //    break;
            }
        }
    }
}
