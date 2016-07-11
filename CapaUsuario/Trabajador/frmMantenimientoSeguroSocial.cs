using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Trabajador
{
    public partial class frmMantenimientoSeguroSocial : Form
    {
        int sidtperiodotrabajador = 0;

        int sidtregimensaludtrabajador = 0;
        string sregimensalud = "";
        string sfechainiciosalud = "";
        string sfechafinsalud = "";
        string sentidadprestadorasalud = "";

        int sidtregimenpensionariotrabajador = 0;
        string sfechainiciopensionario = "";
        string sfechafinpensionario = "";
        string scuspp = "";
        int sidtafp = 0;
        string safp = "";


        CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador miRegimenSaludTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador();
        CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador miRegimenPensionarioTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();

        public frmMantenimientoSeguroSocial()
        {
            InitializeComponent();
        }

        private void frmMantenimientoSeguroSocial_Load(object sender, EventArgs e)
        {
            CargarRegimenSaludTrabajador();
            CargarRegimenPensionarioTrabajador();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //CapaUsuario.Trabajador.frmRegimenSaludTrabajador fRegimenSaludTrabajador = new frmRegimenSaludTrabajador();
            //fRegimenSaludTrabajador.RecibirDatos(0, "", "", "", "", sidtperiodotrabajador, 1);
            //if (fRegimenSaludTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    CargarRegimenSaludTrabajador();
            //}

            CapaUsuario.Trabajador.frmRegimenPensionarioTrabajador fRegimenPensionarioTrabajador = new frmRegimenPensionarioTrabajador();
            fRegimenPensionarioTrabajador.RecibirDatos(0, "", "", "", 0, "", sidtperiodotrabajador, 1);
            if (fRegimenPensionarioTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarRegimenPensionarioTrabajador();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void dgvRegimenSalud_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvRegimenSalud_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sidtregimensaludtrabajador = Convert.ToInt32(dgvRegimenSalud.Rows[e.RowIndex].Cells[1].Value);
            sregimensalud = Convert.ToString(dgvRegimenSalud.Rows[e.RowIndex].Cells[2].Value);
            sfechainiciosalud = Convert.ToString(dgvRegimenSalud.Rows[e.RowIndex].Cells[3].Value);
            sfechafinsalud = Convert.ToString(dgvRegimenSalud.Rows[e.RowIndex].Cells[4].Value);
            sentidadprestadorasalud = Convert.ToString(dgvRegimenSalud.Rows[e.RowIndex].Cells[5].Value);
        }

        private void dgvRegimenPensionario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvRegimenPensionario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sidtregimenpensionariotrabajador = Convert.ToInt32(dgvRegimenPensionario.Rows[e.RowIndex].Cells[1].Value);
            sidtafp = Convert.ToInt32(dgvRegimenPensionario.Rows[e.RowIndex].Cells[2].Value);
            safp = Convert.ToString(dgvRegimenPensionario.Rows[e.RowIndex].Cells[3].Value);
            sfechainiciopensionario = Convert.ToString(dgvRegimenPensionario.Rows[e.RowIndex].Cells[4].Value);
            sfechafinpensionario = Convert.ToString(dgvRegimenPensionario.Rows[e.RowIndex].Cells[5].Value);
            scuspp = Convert.ToString(dgvRegimenPensionario.Rows[e.RowIndex].Cells[6].Value);
        }

        public void RecibirDatos(int pidttrabajador)
        {
            sidtperiodotrabajador = pidttrabajador;
        }

        private void CargarRegimenSaludTrabajador()
        {
            DataTable oDataRegimenSaludTrabajador = new DataTable();

            dgvRegimenSalud.Rows.Clear();
            oDataRegimenSaludTrabajador = miRegimenSaludTrabajador.ListarRegimenSaludTrabajador(sidtperiodotrabajador);
            foreach (DataRow row in oDataRegimenSaludTrabajador.Rows)
            {
                dgvRegimenSalud.Rows.Add("", row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
            }
            if (dgvRegimenSalud.Rows.Count > 0)
            {
                dgvRegimenSalud.Rows[dgvRegimenSalud.Rows.Count - 1].Cells[2].Selected = true;
                DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, dgvRegimenSalud.Rows.Count - 1);
                dgvRegimenSalud_CellClick(dgvRegimenSalud, cea);
            }
        }

        private void CargarRegimenPensionarioTrabajador()
        {
            DataTable oDataRegimenPensionario = new DataTable();
            DataTable oDataAFP = new DataTable();

            dgvRegimenPensionario.Rows.Clear();
            oDataRegimenPensionario = miRegimenPensionarioTrabajador.ListarRegimenPensionarioTrabajador(sidtperiodotrabajador);
            CapaDeNegocios.cListaAFP miAFP= new CapaDeNegocios.cListaAFP();
            oDataAFP = miAFP.ObtenerListaAFP();
            foreach (DataRow row in oDataRegimenPensionario.Rows)
            {
                foreach (DataRow row1 in oDataAFP.Select("idtafp ='" + row[4].ToString() + "'"))
                {
                    dgvRegimenPensionario.Rows.Add("", row[0].ToString(), row1[0].ToString(), row1[1].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                }
            }
            if (dgvRegimenPensionario.Rows.Count > 0)
            {
                dgvRegimenPensionario.Rows[dgvRegimenPensionario.Rows.Count - 1].Cells[2].Selected = true;
                DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, dgvRegimenPensionario.Rows.Count - 1);
                dgvRegimenPensionario_CellClick(dgvRegimenPensionario, cea);
            }
        }
    }
}
