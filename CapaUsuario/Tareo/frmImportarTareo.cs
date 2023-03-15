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
    public partial class frmImportarTareo : Form
    {
        public string sdescripcion = "";
        int sidttareo= 0;
        int sidtmeta = 0;
        public int sidttareoimportar = 0;

        public frmImportarTareo()
        {
            InitializeComponent();
        }

        private void frmImportarTareo_Load(object sender, EventArgs e)
        {
            CargarTareos();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (sidttareoimportar == 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dgvTareo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTareo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                sidttareoimportar = Convert.ToInt32(dgvTareo.Rows[e.RowIndex].Cells[0].Value);
            }
        }

        //public void RecibirDatos(int pIdTTareo, int pNumero, DateTime pFechaInicio, DateTime pFechaFin, string pDescripcion, string pNombre, int pIdTMeta)
        public void RecibirDatos(int pIdTTareo, string pDescripcion, int pIdTMeta)
        {
            sidttareo = pIdTTareo;
            //miTareo.Numero = pNumero;
            //txtNumero.Text = Convert.ToString(pNumero);
            //txtDesdeHasta.Text = Convert.ToString(pFechaInicio.ToLongDateString()) + "   -   " + Convert.ToString(pFechaFin.ToLongDateString());
            //miTareo.FechaInicio = pFechaInicio;
            //miTareo.FechaFin = pFechaFin;
            sdescripcion = pDescripcion;
            //txtMeta.Text = pNombre;
            sidtmeta = pIdTMeta;
            //if (pDescripcion == "PERSONAL TECNICO") { btnNuevoTrabajador.Visible = false; }
        }

        private void CargarTareos()
        {
            DataTable oDataTareo = new DataTable();
            CapaDeNegocios.Obras.cMeta miMeta = new CapaDeNegocios.Obras.cMeta();
            CapaDeNegocios.Tareos.cTareo miTareo = new CapaDeNegocios.Tareos.cTareo();
            dgvTareo.Rows.Clear();
            oDataTareo = miTareo.ListarTareo(sidtmeta);
            foreach (DataRow row in oDataTareo.Rows)
            {
                if (sidttareo != Convert.ToInt16(row[0]))
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
    }
}
