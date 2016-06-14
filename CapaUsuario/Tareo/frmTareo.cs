using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios;
using CapaDeNegocios.Tareos;
using CapaDeNegocios.Obras;

namespace CapaUsuario.Tareo
{
    public partial class frmTareo : Form
    {
        cCatalogoTareos oCatalogoTareos = new cCatalogoTareos();
        cCadenaProgramaticaFuncional miCadena = new cCadenaProgramaticaFuncional();        

        public frmTareo()
        {
            InitializeComponent();
        }

        private void frmTareo_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            dtgTareos.DataSource = oCatalogoTareos.ListarTareos();
            cboListaMetas.DisplayMember = "nombre";
            cboListaMetas.ValueMember = "idMeta";
            cboListaMetas.DataSource = miCadena.ListarMetas();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmNuevoTareo fNuevoTareo = new frmNuevoTareo();
            fNuevoTareo.miTareo = new cTareo();
            fNuevoTareo.miTareo.FechaInicio = DateTime.Now;
            fNuevoTareo.miTareo.FechaFinal = DateTime.Now.AddDays(30);

            fNuevoTareo.miTareo.MiDetalleTareo = new cDetalleTareo();
            fNuevoTareo.miTareo.MiDetalleTareo.Tareo = fNuevoTareo.miTareo;
            fNuevoTareo.miTareo.MiDetalleTareo.Dias = new List<cDiaTareo>();

            
            if (fNuevoTareo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {


            }
	    
        }

        private void cboListaMetas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
