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
        string iSeleccion = "";
        int sidtperiodotrabajador = 0;
        string sfechainicioperiodo = "";
        string sfechafinperiodo = "";

        int sidtregimensaludtrabajador = 0;
        string sregimensalud = "";
        string sfechainiciosalud = "";
        string sfechafinsalud = "";
        string sentidadprestadorasalud = "";

        int sidtregimenpensionariotrabajador = 0;
        string sfechainiciopensionario = "";
        string sfechafinpensionario = "";
        string scuspp = "";
        string stipocomision = "";
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
            CargarRegimenPensionarioTrabajador();
            CargarRegimenSaludTrabajador();
            if (dgvRegimenSalud.Rows.Count == 0 && dgvRegimenPensionario.Rows.Count == 0) { dgvRegimenSalud_Click(sender, e); }
            else if (dgvRegimenSalud.Rows.Count > 0) { dgvRegimenSalud_Click(sender, e); }
            else { dgvRegimenPensionario_Click(sender, e); }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (iSeleccion == "SALUD")
            {
                if (dgvRegimenSalud.Rows.Count > 0)
                {
                    sfechainiciosalud = Convert.ToString(dgvRegimenSalud.Rows[dgvRegimenSalud.Rows.Count - 1].Cells[3].Value);
                    sfechafinsalud = Convert.ToString(dgvRegimenSalud.Rows[dgvRegimenSalud.Rows.Count - 1].Cells[4].Value);
                    if (sfechafinsalud == "")
                    {
                        MessageBox.Show("El ultimen regimen de salud debe tener una fecha final, no se puede agregar uno nuevo", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (sfechafinsalud == sfechafinperiodo)
                    {
                        MessageBox.Show("No quedan dias libres en el periodo, no se puede agregar uno nuevo", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                CapaUsuario.Trabajador.frmRegimenSaludTrabajador fRegimenSaludTrabajador = new frmRegimenSaludTrabajador();
                fRegimenSaludTrabajador.RecibirDatos(0, "", sfechainiciosalud, sfechafinsalud, "", sidtperiodotrabajador, 1, sfechainicioperiodo, sfechafinperiodo);
                if (fRegimenSaludTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    i = 1;
                }
            }
            else if (iSeleccion == "PENSIONARIO")
            {
                if (dgvRegimenPensionario.Rows.Count > 0)
                {
                    sfechainiciopensionario = Convert.ToString(dgvRegimenPensionario.Rows[dgvRegimenPensionario.Rows.Count - 1].Cells[4].Value);
                    sfechafinpensionario = Convert.ToString(dgvRegimenPensionario.Rows[dgvRegimenPensionario.Rows.Count - 1].Cells[5].Value);
                    if (sfechafinpensionario == "")
                    {
                        MessageBox.Show("El ultimen regimen de salud debe tener una fecha final, no se puede agregar uno nuevo", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (sfechafinpensionario == sfechafinperiodo)
                    {
                        MessageBox.Show("No quedan dias libres en el periodo, no se puede agregar uno nuevo", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                CapaUsuario.Trabajador.frmRegimenPensionarioTrabajador fRegimenPensionarioTrabajador = new frmRegimenPensionarioTrabajador();
                fRegimenPensionarioTrabajador.RecibirDatos(0, sfechainiciopensionario, sfechafinpensionario, "", "", 0, "", sidtperiodotrabajador, 1, sfechainicioperiodo, sfechafinperiodo);
                if (fRegimenPensionarioTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    i = 2;
                }
            }
            if (i == 1) { CargarRegimenSaludTrabajador();}
            else if (i == 2) {CargarRegimenPensionarioTrabajador(); }
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (iSeleccion == "SALUD")
            {
                if (sidtregimensaludtrabajador == 0)
                {
                    MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CapaUsuario.Trabajador.frmRegimenSaludTrabajador fRegimenSaludTrabajador = new frmRegimenSaludTrabajador();
                fRegimenSaludTrabajador.RecibirDatos(sidtregimensaludtrabajador, sregimensalud, sfechainiciosalud, sfechafinsalud, sentidadprestadorasalud, sidtperiodotrabajador, 2, sfechainicioperiodo, sfechafinperiodo);
                if (fRegimenSaludTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    i = 1;
                }
            }
            else if (iSeleccion == "PENSIONARIO")
            {
                if (sidtregimenpensionariotrabajador == 0)
                {
                    MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CapaUsuario.Trabajador.frmRegimenPensionarioTrabajador fRegimenPensionarioTrabajador = new frmRegimenPensionarioTrabajador();
                fRegimenPensionarioTrabajador.RecibirDatos(sidtregimenpensionariotrabajador, sfechainiciopensionario, sfechafinpensionario, scuspp, stipocomision, sidtafp, safp, sidtperiodotrabajador, 2, sfechainicioperiodo, sfechafinperiodo);
                if (fRegimenPensionarioTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    i = 2;
                }
            }
            if (i == 1) { CargarRegimenSaludTrabajador(); }
            else if (i == 2) { CargarRegimenPensionarioTrabajador(); }
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
            //Solo para indices diferentes a -1
            if (e.RowIndex != -1){
                sidtregimensaludtrabajador = Convert.ToInt32(dgvRegimenSalud.Rows[e.RowIndex].Cells[1].Value);
                sregimensalud = Convert.ToString(dgvRegimenSalud.Rows[e.RowIndex].Cells[2].Value);
                sfechainiciosalud = Convert.ToString(dgvRegimenSalud.Rows[e.RowIndex].Cells[3].Value);
                sfechafinsalud = Convert.ToString(dgvRegimenSalud.Rows[e.RowIndex].Cells[4].Value);
                sentidadprestadorasalud = Convert.ToString(dgvRegimenSalud.Rows[e.RowIndex].Cells[5].Value);
                if (dgvRegimenSalud.Rows[e.RowIndex].Cells[0].Selected == true)
                {
                    if (sidtregimensaludtrabajador == 0)
                    {
                        MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (MessageBox.Show("Está seguro que desea eliminar el Regimen de Salud del Trabajador", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                    miRegimenSaludTrabajador.EliminarRegimenSaludTrabajador(sidtregimensaludtrabajador);
                    CargarRegimenSaludTrabajador();
                }
            }
        }

        private void dgvRegimenSalud_Click(object sender, EventArgs e)
        {
            if (dgvRegimenPensionario.Rows.Count > 0)
            {
                dgvRegimenPensionario.Rows[0].Cells[3].Selected = true;
                dgvRegimenPensionario.Rows[0].Cells[3].Selected = false;
            }
            iSeleccion = "SALUD";
        }

        private void dgvRegimenPensionario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvRegimenPensionario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) { 
                sidtregimenpensionariotrabajador = Convert.ToInt32(dgvRegimenPensionario.Rows[e.RowIndex].Cells[1].Value);
                sidtafp = Convert.ToInt32(dgvRegimenPensionario.Rows[e.RowIndex].Cells[2].Value);
                safp = Convert.ToString(dgvRegimenPensionario.Rows[e.RowIndex].Cells[3].Value);
                sfechainiciopensionario = Convert.ToString(dgvRegimenPensionario.Rows[e.RowIndex].Cells[4].Value);
                sfechafinpensionario = Convert.ToString(dgvRegimenPensionario.Rows[e.RowIndex].Cells[5].Value);
                scuspp = Convert.ToString(dgvRegimenPensionario.Rows[e.RowIndex].Cells[6].Value);
                stipocomision = Convert.ToString(dgvRegimenPensionario.Rows[e.RowIndex].Cells[7].Value);
                if (dgvRegimenPensionario.Rows[e.RowIndex].Cells[0].Selected == true)
                {
                    if (sidtregimenpensionariotrabajador == 0)
                    {
                        MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (MessageBox.Show("Está seguro que desea eliminar el Regimen Pensionario del Trabajador", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                    miRegimenPensionarioTrabajador.EliminarRegimenPensionarioTrabajador(sidtregimenpensionariotrabajador);
                    CargarRegimenPensionarioTrabajador();
                }
            }
        }

        private void dgvRegimenPensionario_Click(object sender, EventArgs e)
        {
            if (dgvRegimenSalud.Rows.Count > 0)
            {
                dgvRegimenSalud.Rows[0].Cells[2].Selected = true;
                dgvRegimenSalud.Rows[0].Cells[2].Selected = false;
            }
            iSeleccion = "PENSIONARIO";
        }

        public void RecibirDatos(int pidttrabajador, string pfechainicioperiodo, string pfechafinperiodo)
        {
            sidtperiodotrabajador = pidttrabajador;
            sfechainicioperiodo = pfechainicioperiodo;
            sfechafinperiodo = pfechafinperiodo;
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
            else
            {
                sfechainiciosalud = "";
                sfechafinsalud = "";
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
                foreach (DataRow row1 in oDataAFP.Select("idtafp ='" + row[5].ToString() + "'"))
                {
                    dgvRegimenPensionario.Rows.Add("", row[0].ToString(), row1[0].ToString(), row1[1].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                }
            }
            if (dgvRegimenPensionario.Rows.Count > 0)
            {
                dgvRegimenPensionario.Rows[dgvRegimenPensionario.Rows.Count - 1].Cells[3].Selected = true;
                DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, dgvRegimenPensionario.Rows.Count - 1);
                dgvRegimenPensionario_CellClick(dgvRegimenPensionario, cea);
            }
            else
            {
                sfechainiciopensionario= "";
                sfechafinpensionario = "";
            }
        }
    }
}
